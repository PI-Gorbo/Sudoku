Imports System.IO

Public Class ObjBoard

    Public Filelist As New ArrayList
    Public BoardCells(8, 8) As ObjCell
    Dim Box(2, 2) As ArrayList

    'New: Gets board. Gives Newly Created Cells a get Value. Adds Cells to their box and gives then a location relative to the board. 
    Public Sub NewBoard()

        Dim Dr As New DirectoryInfo("Boards")
        For Each file In Dr.GetFiles()
            Filelist.Add(file)
        Next

        Dim r As New Random
        Dim f = Convert.ToString(Filelist(r.Next(0, Filelist.Count)).Fullname)
        Using reader As New StreamReader(f)
            Dim line As String

            For Rows = 0 To 8
                line = reader.ReadLine
                For Cols = 0 To 8
                    If IsNothing(BoardCells(Rows, Cols)) = True Then
                        BoardCells(Rows, Cols) = New ObjCell
                    End If

                    With BoardCells(Rows, Cols)

                        If line(Cols) = "0" Then
                            For i = 1 To 9
                                .DataCandidates.Add(i)
                            Next
                        Else
                            .Value = Integer.Parse(line(Cols))
                            .HasValueFromImport = True
                        End If

                        .CellLocation = New Point(Rows, Cols)
                        .ParentBox = New Point(Math.Floor(Rows / 3), Math.Floor(Cols / 3))

                    End With
                Next
            Next
        End Using
    End Sub

    Public Sub InputManualBoard()

    End Sub

    Public Sub ForceSolve()
        'Preform a force solve
    End Sub

    Public Sub RemoveCandidates()
        'Removes candidates.
    End Sub


End Class

Public Class ObjCell
    Public Value As Integer?
    Public HasValueFromImport As Boolean

    Public DataCandidates As New ArrayList
    Public ParentBox As Point
    Public CellLocation As Point


    Public Sub New()
        HasValueFromImport = False
        Value = vbNull
        DataCandidates.Clear()
        DataCandidates.Capacity = 9
        ParentBox = New Point(-1, -1)
        CellLocation = New Point(-1, -1)
    End Sub
End Class