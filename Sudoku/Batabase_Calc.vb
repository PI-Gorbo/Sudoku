Imports System.IO

Public Class ObjBoard

    Dim BoardCells(8, 8) As ObjCell
    Dim Box(2, 2) As ArrayList

    'New: Gets board. Gives Newly Created Cells a get Value. Adds Cells to their box and gives then a location relative to the board. 
    Public Sub New()
        Dim r As New Random
        Dim f = Convert.ToString(Form1.Filelist(r.Next(0, Form1.Filelist.Count)).Fullname)
        Using reader As New StreamReader(f)
            Dim line As String

            For Rows = 0 To 8

                line = reader.ReadLine

                For Cols = 0 To 8

                    BoardCells(Rows, Cols) = New ObjCell

                    If line(Cols) = "0" Then
                        For i = 1 To 9
                            BoardCells(Rows, Cols).DataCandidates.Add(i)
                        Next
                    End If



                Next
            Next
        End Using
    End Sub



End Class

Public Class ObjCell
    Public Value As Integer?
    Public HasValueFromImport As Boolean

    Public DataCandidates As New ArrayList
    Public DisplayCandidates As New ArrayList
    Public ParentBox As Point
    Public CellLocation As Point

    'Public Labels(2, 2) As Label
    'Public Valuelabel As Label

    Public Sub New()
        HasValueFromImport = False
        Value = vbNull
        DataCandidates.Clear()
        DataCandidates.Capacity = 9
        DisplayCandidates.Clear()
        DisplayCandidates.Capacity = 9
        ParentBox = New Point(-1, -1)
        CellLocation = New Point(-1, -1)
    End Sub
End Class