Imports System.IO

Public Class ObjBoard

    Public Filelist As New ArrayList
    Public BaseBoardCells(8, 8) As ObjCell

    'New: Gets board. Gives Newly Created Cells a get Value. gives them a location relative to the board. 
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

                    If IsNothing(BaseBoardCells(Rows, Cols)) = True Then
                        BaseBoardCells(Rows, Cols) = New ObjCell
                    Else
                        With BaseBoardCells(Rows, Cols)
                            .HasValueFromImport = False
                            .Value = vbNull
                            .DataCandidates.Clear()
                        End With
                    End If

                    With BaseBoardCells(Rows, Cols)

                        If line(Cols) = "0" Then
                            For i = 1 To 9
                                .DataCandidates.Add(i)
                            Next
                        Else
                            .Value = Integer.Parse(line(Cols))
                            .HasValueFromImport = True
                        End If

                    End With

                    If Rows >= 0 And Rows <= 2 Then
                        BaseBoardCells(Rows, Cols).BoxLocation.Y = 0
                    ElseIf Rows >= 3 And Rows <= 5 Then
                        BaseBoardCells(Rows, Cols).BoxLocation.Y = 3
                    Else
                        BaseBoardCells(Rows, Cols).BoxLocation.Y = 6
                    End If

                    If Cols >= 0 And Cols <= 2 Then
                        BaseBoardCells(Rows, Cols).BoxLocation.X = 0
                    ElseIf Cols >= 3 And Cols <= 5 Then
                        BaseBoardCells(Rows, Cols).BoxLocation.X = 3
                    Else
                        BaseBoardCells(Rows, Cols).BoxLocation.X = 6
                    End If

                    BaseBoardCells(Rows, Cols).CellLocation = New Point(Cols, Rows)
                Next
            Next
        End Using
    End Sub

    Public Sub InputManualBoard()

    End Sub

    Public Sub CalculateCandidates(ByRef Cells(,) As ObjCell)

        For rows = 0 To 8
            For cols = 0 To 8

                Form1.Lstbx.Items.Add(Cells(rows, cols).Value = vbNull)

            Next
        Next

    End Sub

End Class

Public Class ObjCell
    Public Value As Integer?
    Public HasValueFromImport As Boolean

    Public DataCandidates As New ArrayList
    ''NOTE ABOUT BOX LOCATION. THE X AND Y CO-ORDS ARE THE COLS AND ROWS RESPECTIVELY.
    ''THE X And Y VALUES REPRESENT THE LOCATION Of THE FIRST CELL In THAT BOX
    ''IF YOU WANT TO IDERATE THROUGH A BOX, IDERATE BY GOING FOR X TO X+2. SAME FOR Y
    Public BoxLocation As Point
    Public CellLocation As Point

    Public Sub New()
        HasValueFromImport = False
        Value = vbNull
        DataCandidates.Clear()
        DataCandidates.Capacity = 9
    End Sub
End Class