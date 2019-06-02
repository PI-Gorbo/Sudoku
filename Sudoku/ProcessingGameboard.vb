Partial Class Gameboard

    Public Sub ForceSolve()
        'Preform a force solve
    End Sub

    'Calculates the Candidates that are meant to be on the board at any one time
    Shared Sub CalculateCandidates(ByRef Cells(,) As ObjCell)
        Dim ChangedValue As Boolean = False

        For rows = 0 To 8
            For cols = 0 To 8

                Form1.Lstbx.Items.Add(Cells(rows, cols).Value = vbNull)

            Next
        Next

    End Sub


End Class