Public Class Gameboard

    Public Const OriginX As Integer = 20
    Public Const OriginY As Integer = 20

    Public Const CANDIDATE_SIZEpx As Integer = 16
    Public Const CANDIDATE_PADDINGpx As Integer = 0

    Public Const TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
    Public Const CELL_PADDINGpx As Integer = 6

    Public Const TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
    Public Const BOX_PADDINGpx As Integer = 12

    Public Cells(8, 8) As Display_Cells
    Public Board As ObjBoard

    Public Sub New()
        'Create a new board
        CreateLabels()
        Board = New ObjBoard
        Board.NewBoard()
        PrimeBoard()
        'Create 9x9 display cells object and add the datacell property to it. 
    End Sub

    Public Sub NewGame()
        Board.NewBoard()
        PrimeBoard()
    End Sub

    'Takes the current board object and creates labels with the values on the board
    Public Sub CreateLabels()

        For Rows = 0 To 8
            For Cols = 0 To 8
                For LblRows = 0 To 2
                    For LblCols = 0 To 2
                        If IsNothing(Cells(Rows, Cols)) Then
                            Cells(Rows, Cols) = New Display_Cells
                        End If
                        'Sets up the Cell's Candidate Labels
                        Cells(Rows, Cols).Labels(LblRows, LblCols) = New Label
                        With Cells(Rows, Cols).Labels(LblRows, LblCols)
                            .Tag = Cells(Rows, Cols)
                            .BackColor = Color.GhostWhite
                            .Size = New Size(CANDIDATE_SIZEpx, CANDIDATE_SIZEpx)
                            .Location = New Point(OriginX + (Math.Floor(Cols / 3) * BOX_PADDINGpx) + (Cols * (TOTAL_CELL_SIZEpx + CELL_PADDINGpx)) + (LblCols * (CANDIDATE_SIZEpx + CANDIDATE_PADDINGpx)), OriginY + (Math.Floor(Rows / 3) * BOX_PADDINGpx) + (Rows * (TOTAL_CELL_SIZEpx + CELL_PADDINGpx)) + (LblRows * (CANDIDATE_PADDINGpx + CANDIDATE_SIZEpx)))
                            .Font = New Font("Symbol", CANDIDATE_SIZEpx * 0.65, FontStyle.Regular)
                            .TextAlign = ContentAlignment.TopCenter
                        End With
                        Form1.Controls.Add(Cells(Rows, Cols).Labels(LblRows, LblCols))

                    Next
                Next

                'Sets up the Cell's Value Label
                Cells(Rows, Cols).ValueLabel = New Label
                With Cells(Rows, Cols).ValueLabel
                    .Location = New Point(Cells(Rows, Cols).Labels(0, 0).Location.X, Cells(Rows, Cols).Labels(0, 0).Location.Y)
                    .Size = New Size(TOTAL_CELL_SIZEpx, TOTAL_CELL_SIZEpx)
                    .BackColor = Color.White
                    .Font = New Font("Symbol", 22, FontStyle.Bold)
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Enabled = False
                    .Visible = False
                End With
                Form1.Controls.Add(Cells(Rows, Cols).ValueLabel)

                'Sets up the Cell's Select label
                Cells(Rows, Cols).SelectedLabel = New Label
                With Cells(Rows, Cols).SelectedLabel
                    .Size = New Size(TOTAL_CELL_SIZEpx + 6, TOTAL_CELL_SIZEpx + 6)
                    .Location = New Point(Cells(Rows, Cols).Labels(0, 0).Location.X - 3, Cells(Rows, Cols).Labels(0, 0).Location.Y - 3)
                    .BackColor = Color.DarkSalmon
                    .Enabled = False
                    .Visible = False
                End With
                Form1.Controls.Add(Cells(Rows, Cols).SelectedLabel)


            Next
        Next


    End Sub
    'Takes an input board, and displays it on the screen.
    Public Sub PrimeBoard()

        'Add the values to the labels

        For Rows = 0 To 8
            For Cols = 0 To 8
                Cells(Rows, Cols).DataCell = Board.BoardCells(Rows, Cols)
                ClearValues(Cells(Rows, Cols))
                ClearCandidates(Cells(Rows, Cols))
                If Cells(Rows, Cols).DataCell.HasValueFromImport = True Then
                    'Display Value Label
                    DisplayValueLabel(Cells(Rows, Cols))
                End If
            Next
        Next

    End Sub
    'Sets up a value to be displayed on the Value Lablel. Disables The select label, Disables the Candidate Labels
    Public Sub DisplayValueLabel(ParentCell As Display_Cells)
        Dim value As Integer = ParentCell.DataCell.Value
        ParentCell.SelectedLabel.Visible = False

        With ParentCell.ValueLabel
            .Visible = True
            .Enabled = True
            .Text = value
        End With

        For rows = 0 To 2
            For cols = 0 To 2
                With ParentCell.Labels(rows, cols)
                    .Enabled = False
                    .Visible = False
                End With
            Next
        Next
    End Sub

    'Clears the Value label as if the Cell was new, just like creation 
    Public Sub ClearValues(ParentCell As Display_Cells)

        With ParentCell.ValueLabel
            .Enabled = False
            .Visible = False
            .Text = ""
        End With

    End Sub

    'Clears the Candidates and Labels, as if the cell was new
    Public Sub ClearCandidates(ParentCell As Display_Cells)

        For Each lbl As Label In ParentCell.Labels

            With lbl
                .Text = ""
                .Enabled = True
                .Visible = True
            End With
        Next

        ParentCell.DisplayCandidates.Clear()

    End Sub

    Public Sub UpdateLabels()

    End Sub

    Public Sub Choosedifficulty()
        'Create a bit of logic to choose the difficulty for the user.
    End Sub

    Public Sub PrimeForManualEntry()
        'Ready the board for manual entry. Create some new buttons that tell the computer when the user is done with manual entry.
        'Maybe a boolean value can be used to know what mode the game is in, so the input hander can know what is going on.

        'Build a board for manual entry. 

        'Load that board into the baseboard file so it can be auto solved.
        'Then resume as normal.
        'Potentially give the user an option to save their file.
    End Sub

    Public Sub InputLbl()
        'Input handler for Labels.
    End Sub

    Public Sub InputKeypad()
        'Input handler for keypads
    End Sub

    Public Sub UpdateKeypads()
        'Updates the colour of the keypad to reflect which label has last been clicked. 
    End Sub

End Class

Public Class Display_Cells
    Public DataCell As ObjCell
    Public Labels(2, 2) As Label
    Public ValueLabel As Label
    Public SelectedLabel As Label
    Public DisplayCandidates As New ArrayList

    Public Sub New()
        DataCell = Nothing
        DisplayCandidates.Clear()
        DisplayCandidates.Capacity = 9
        ValueLabel = Nothing
        SelectedLabel = Nothing
    End Sub

End Class