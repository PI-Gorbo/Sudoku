Imports Microsoft.VisualBasic

Public Class Database

    Shared Baseboard(8, 8) As Integer
    Shared TempCells(8, 8) As ArrayList

    Public Shared Function ExportNewBoard() As ArrayList(,)

        'Import BaseBoard
        Baseboard = InputOutputGameboard.Import("C:\Users\Samn\source\repos\Sudoku\Sudoku\My Project\Boards")

        'Build Fullboard 
        For cols = 0 To 8
            For rows = 0 To 8
                'If the BaseBoard does not have a value of 0 (meaning empty) then fill candidates
                If Baseboard(cols, rows) <> 0 Then
                    TempCells(cols, rows).Add(Baseboard(cols, rows))
                Else
                    For i = 1 To 9
                        TempCells(cols, rows).Add(i)
                    Next
                End If

            Next
        Next

        'Remvoing possible candidates from 
        For cols = 0 To 8
            For rows = 0 To 8

                If TempCells(cols, rows).Count = 1 Then
                    RemoveCandiateFromBoxColRow(TempCells(cols, rows)(0), cols, rows)
                End If

            Next
        Next

        'Pass TempCells To gameboard
        Return TempCells

    End Function

    Public Shared Sub RemoveCandiateFromBoxColRow(Candidate As Integer, col As Integer, row As Integer)

        RemoveCandidateFromBox(Candidate, col, row)
        RemoveCandidateFromColRow(Candidate, col, row)

    End Sub

    Private Shared Sub RemoveCandidateFromBox(Candidate As Integer, col As Integer, row As Integer)
        Dim MaxRows, MinRows, MaxCols, MinCols As Integer
        If col <= 2 Then
            MinCols = 0
            MaxCols = 2
        ElseIf col >= 3 And col <= 5 Then
            MinCols = 3
            MaxCols = 5
        ElseIf col >= 6 And col <= 8 Then
            MinCols = 6
            MaxCols = 8
        End If

        If row <= 2 Then
            MinRows = 0
            MaxRows = 2
        ElseIf row >= 3 And col <= 5 Then
            MinRows = 3
            MaxRows = 5
        ElseIf row >= 6 And col <= 8 Then
            MinRows = 6
            MaxRows = 8
        End If

        For cols = MinCols To MaxCols
            For rows = MinRows To MaxRows
                TempCells(cols, rows).Remove(Candidate)
            Next
        Next

    End Sub

    Private Shared Sub RemoveCandidateFromColRow(Candidate As Integer, col As Integer, row As Integer)

        For cols = 0 To 8
            TempCells(cols, row).Remove(Candidate)
        Next

        For rows = 0 To 8
            TempCells(col, rows).Remove(Candidate)
        Next

    End Sub

End Class
