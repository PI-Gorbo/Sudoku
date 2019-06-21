

Public Class Gameboard

    Public OriginX As Integer = Form1.Group_Menu.Location.X
    Public OriginY As Integer = Form1.Group_Menu.Location.X + Form1.Group_Menu.Size.Height + Form1.Lbl_FileName.Height + 10

    Public Const OuterPadding As Integer = 10

    Public Const CANDIDATE_SIZEpx As Integer = 18
    Public Const CANDIDATE_PADDINGpx As Integer = 0

    Public Const TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
    Public Const CELL_PADDINGpx As Integer = 3

    Public Const TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
    Public Const BOX_PADDINGpx As Integer = 8

    Public Const BOARDSIZE As Integer = 3 * TOTAL_BOX_SIZEpx + 2 * BOX_PADDINGpx - 12

    Public Cells(8, 8) As Display_Cells
    Public Gameboard As BoardHandler
    Public LastClicked As Display_Cells
    Public Keypads As New ArrayList

    Public Sub New()
        'Create a new board
        Gameboard = New BoardHandler
        LastClicked = Nothing
        CreateLabels()

        'Create 9x9 display cells object and add the datacell property to it. 
    End Sub


    Public Sub NewGame()

        PrimeNewBoard()
        LastClicked = Nothing
        Gameboard.NewBoard(False)
        PrimeNewBoard()
        Form1.Lbl_FileName.Text = Gameboard.BoardChosen
    End Sub

    'Takes the current board object and creates labels with the values on the board
    Public Sub CreateLabels()

        Dim UpperboundY As Integer = OriginY
        Dim LowerboundY As Integer = OriginY + BOARDSIZE
        Dim LeftboundX As Integer = OriginX
        Dim RightboundX As Integer = OriginX + BOARDSIZE

        LastClicked = Nothing

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
                            .Font = New Font("Roboto", CANDIDATE_SIZEpx * 0.65, FontStyle.Regular)
                            .TextAlign = ContentAlignment.TopCenter
                            .BringToFront()
                        End With
                        AddHandler Cells(Rows, Cols).Labels(LblRows, LblCols).Click, AddressOf InputLbl
                        Form1.Controls.Add(Cells(Rows, Cols).Labels(LblRows, LblCols))

                    Next
                Next

                'Sets up the Cell's Value Label
                Cells(Rows, Cols).ValueLabel = New Label
                With Cells(Rows, Cols).ValueLabel
                    .Tag = Cells(Rows, Cols)
                    .Location = New Point(Cells(Rows, Cols).Labels(0, 0).Location.X, Cells(Rows, Cols).Labels(0, 0).Location.Y)
                    .Size = New Size(TOTAL_CELL_SIZEpx, TOTAL_CELL_SIZEpx)
                    .BackColor = Color.White
                    .Font = New Font("Roboto", CANDIDATE_SIZEpx * 1.5, FontStyle.Bold)
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Enabled = False
                    .Visible = False
                End With
                Cells(Rows, Cols).HasValueLabel = False
                AddHandler Cells(Rows, Cols).ValueLabel.Click, AddressOf InputLbl
                Form1.Controls.Add(Cells(Rows, Cols).ValueLabel)

                'Sets up the Cell's Select label
                Cells(Rows, Cols).SelectedLabel = New Label
                With Cells(Rows, Cols).SelectedLabel
                    .Tag = Cells(Rows, Cols)
                    .Size = New Size(TOTAL_CELL_SIZEpx + 6, TOTAL_CELL_SIZEpx + 6)
                    .Location = New Point(Cells(Rows, Cols).Labels(0, 0).Location.X - 3, Cells(Rows, Cols).Labels(0, 0).Location.Y - 3)
                    .BackColor = Color.DarkSalmon
                    .Enabled = False
                    .Visible = False
                    .SendToBack()
                End With
                Form1.Controls.Add(Cells(Rows, Cols).SelectedLabel)


            Next
        Next

        Form1.Group_Menu.Size = New Size(RightboundX + Form1.Group_Controls.Size.Width + OuterPadding, Form1.Group_Menu.Size.Height)
        Form1.Group_Controls.Location = New Point(RightboundX + OriginX + OuterPadding, UpperboundY)
        Form1.DebugBox.Location = New Point(RightboundX + 24 + OuterPadding + 10 + Form1.Group_Controls.Size.Width, Form1.Group_Menu.Height - 25)
        Form1.DebugBox.Size = New Size(Form1.DebugBox.Size.Width, BOARDSIZE + Form1.Group_Menu.Size.Height + 45)
        Form1.Size = New Size(Form1.DebugBox.Location.X + Form1.DebugBox.Size.Width + 30, LowerboundY + OriginY)
        Form1.Lbl_FileName.Location = New Point(RightboundX - RightboundX / 2 - LeftboundX + 5, Form1.Lbl_FileName.Location.Y)
    End Sub

    'Takes an input board, and displays it on the screen.
    Public Sub PrimeNewBoard()

        'Add the values to the labels

        For Rows = 0 To 8
            For Cols = 0 To 8

                Cells(Rows, Cols).DataCell = Gameboard.MainBoard.Cells(Rows, Cols)
                ClearValues(Cells(Rows, Cols))
                ClearCandidates(Cells(Rows, Cols))
                Cells(Rows, Cols).ValueLabel.BackColor = Color.White

                If Cells(Rows, Cols).DataCell.HasValueFromImport = True Then
                    'Display Value Label
                    DisplayValueLabel(Cells(Rows, Cols), Cells(Rows, Cols).DataCell.Value)

                End If
            Next
        Next

    End Sub

    'Sets up a value to be displayed on the Value Lablel. Disables The select label, Disables the Candidate Labels
    Public Sub DisplayValueLabel(ParentCell As Display_Cells, value As Integer)

        Dim val = value
        ParentCell.SelectedLabel.Visible = False

        ParentCell.HasValueLabel = True
        With ParentCell.ValueLabel
            .Visible = True
            .Enabled = True
            .Text = value
            If ParentCell.DataCell.HasValueFromImport = True Then
                .ForeColor = Color.FromArgb(1, 51, 121, 118)
            Else
                .ForeColor = Color.Black
            End If

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
        ParentCell.HasValueLabel = False
        For Each lbl As Label In ParentCell.Labels
            With lbl
                .Text = ""
                .Enabled = True
                .Visible = True
            End With
        Next

        ParentCell.SelectedLabel.Visible = False
        If Not IsNothing(LastClicked) Then

            If LastClicked.Equals(ParentCell) Then
                ParentCell.SelectedLabel.Visible = True
            End If

        End If

    End Sub

    'Clears the Candidates and Labels, as if the cell was new
    Public Sub ClearCandidates(ParentCell As Display_Cells)

        For Each lbl As Label In ParentCell.Labels

            With lbl
                .Text = ""
            End With
        Next

        ParentCell.DisplayCandidates.Clear()

    End Sub

    Public Sub PrimeForManualEntry()

        Gameboard.NewBoard(True)
        PrimeNewBoard()

    End Sub

    'Handles the interaction between user and computer for inputting a manual board
    Public Sub FinaliseManualEntry()

        Dim result As DialogResult
        Dim valid As Boolean = False
        'Ask the user if they are sure they are done.
        result = MessageBox.Show("Are you sure you are finished with manual entry? Yes will initialise the check for the validiity of the board.", "", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            'If False, exit
            Exit Sub
        End If

        'Takes inputted board and checks if it is valid, if it is not, then provides the option to retry entry
        Gameboard.ManualBoardImport(Cells, valid)

        If valid = False Then
            result = MessageBox.Show("Inputted Board Invalid! Would you like to retry or cancel manual entry?", "", MessageBoxButtons.RetryCancel)
            If result = DialogResult.Retry Then
                Gameboard.NewBoard(True)
                Exit Sub
            Else
                Gameboard.NewBoard(True)
                PrimeNewBoard()
                Form1.BeginningState()
                Exit Sub
            End If
        Else
            result = MessageBox.Show("Board Valid! Would you like to save it as a custom board?. Boardname will be saved as a combination of time and date", "", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Gameboard.SaveCurrentBoard()
                MsgBox("Board Saved!")
            End If
            Form1.NormalPlay()
            PrimeNewBoard()
            Exit Sub

        End If




    End Sub

End Class

Public Class Display_Cells
    Public DataCell As ObjCell
    Public Labels(2, 2) As Label
    Public ValueLabel As Label
    Public HasValueLabel As Boolean
    Public SelectedLabel As Label
    Public DisplayCandidates As New ArrayList

    Public Sub New()
        HasValueLabel = False
        DataCell = Nothing
        DisplayCandidates.Clear()
        DisplayCandidates.Capacity = 9
        ValueLabel = Nothing
        SelectedLabel = Nothing
    End Sub

End Class