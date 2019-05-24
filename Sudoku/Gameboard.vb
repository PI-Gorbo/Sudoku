Imports Microsoft.VisualBasic
Imports System.IO


Public Class Gameboard

    Dim Keypad As New ArrayList
    Dim Cells(8, 8) As Cell
    Dim Box(2, 2) As ArrayList
    Dim LastClicked As Cell

    Public Const CANDIDATE_SIZEpx As Integer = 16
    Public Const CANDIDATE_PADDINGpx As Integer = 0

    Public Const TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
    Public Const CELL_PADDINGpx As Integer = 6

    Public Const TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
    Public Const BOX_PADDINGpx As Integer = 12

    Public Const GAME_SIZEpx = (3 * TOTAL_BOX_SIZEpx) + (2 * BOX_PADDINGpx)
    Public Const LINE_WIDTH As Integer = 5

    'On creation of a new board, creates cell objects and groups them into their boxes for future changes
    Public Sub New(OriginX, OriginY)

        Dim BoxX, BoxY As Integer

        Keypad.Add(Form1.Keypad_1)
        Keypad.Add(Form1.Keypad_2)
        Keypad.Add(Form1.Keypad_3)
        Keypad.Add(Form1.Keypad_4)
        Keypad.Add(Form1.Keypad_5)
        Keypad.Add(Form1.Keypad_6)
        Keypad.Add(Form1.Keypad_7)
        Keypad.Add(Form1.Keypad_8)
        Keypad.Add(Form1.Keypad_9)

        'Iderate Through Cells.
        For Rows = 0 To 8
            For Cols = 0 To 8
                'Create the new Cell Object

                Cells(Rows, Cols) = New Cell

                'Determine the box that each Cell belongs to. 
                If Rows <= 2 Then
                    BoxY = 0
                ElseIf Rows >= 3 And Rows <= 5 Then
                    BoxY = 1
                ElseIf Rows >= 6 And Rows <= 8 Then
                    BoxY = 2
                End If

                If Cols <= 2 Then
                    BoxX = 0
                ElseIf Cols >= 3 And Cols <= 5 Then
                    BoxX = 1
                ElseIf Cols >= 6 And Cols <= 8 Then
                    BoxX = 2
                End If

                'Add the Cell to its parent box
                Box(BoxX, BoxY) = New ArrayList
                Box(BoxX, BoxY).Add(Cells(Rows, Cols))
                'Add a refrence to the parent box for each cell
                Cells(Rows, Cols).Parent_Box.X = BoxX
                Cells(Rows, Cols).Parent_Box.Y = BoxY
            Next
        Next


        New_Display(OriginX, OriginY)

    End Sub

    'Imports a new board text file  from a file location. 
    Public Sub Import_New_Board()
        'C:\Users\Samn\source\repos\Sudoku\Sudoku\bin\Debug\Easy1.Txt
        Using reader As New StreamReader("Easy1.Txt") ' Temp File Location

            Dim Line As String

            For Rows = 0 To 8
                'Read in a new line, which comes in row form
                Line = reader.ReadLine
                For Cols = 0 To 8
                    'Clears the values of the board ready for a new set of values
                    Cells(Rows, Cols).Candidates.Clear()
                    Cells(Rows, Cols).HasValue = False
                    Cells(Rows, Cols).HasValueFromImport = False

                    If Line(Cols) = "0" Then
                        'Fill the co-ordinated cell's candidates with all possible values
                        For i = 1 To 9
                            Cells(Rows, Cols).Candidates.Add(i)
                        Next
                    Else
                        'Fill the candidates with one value. Therefore we know that the candidate has a value
                        Cells(Rows, Cols).HasValueFromImport = True
                        Cells(Rows, Cols).HasValue = True
                        Cells(Rows, Cols).Candidates.Add(Integer.Parse(Line(Cols)))
                    End If

                Next
            Next
            reader.Close()
        End Using

        'Now that the board has been built, remove possible candidates from value boxes, rows and colums where HasValue = Ture

        For Rows = 0 To 8
            For Cols = 0 To 8
                If Cells(Rows, Cols).HasValueFromImport Then
                    'Function Removes candidates equal to the value of the cell in the cell's row, col and box
                    RemovePossibleCandidates(Cells(Rows, Cols), Rows, Cols)
                End If
            Next
        Next

    End Sub

    'Removes possible candidates based on the current value lables
    Private Sub RemovePossibleCandidates(_Cell As Cell, row As Integer, col As Integer)

        'Remove from each cell in the box. NB. Remove will try and remove the first instance of the value form the array. If there is none, it is fine with that too!
        For Each c In Box(_Cell.Parent_Box.X, _Cell.Parent_Box.X)
            c.Candidates.Remove(_Cell.Candidates(0))
        Next

        'Remove Candidate from the row

        For Cols = 0 To 8
            If Cells(row, Cols).HasValue = False Then
                Cells(row, Cols).Candidates.Remove(_Cell.Candidates(0))
            End If
        Next

        'Remove Candidate form the column

        For Rows = 0 To 8
            If Cells(Rows, col).HasValue = False Then
                Cells(Rows, col).Candidates.Remove(_Cell.Candidates(0))
            End If
        Next

    End Sub

    'Creates a new display with no information. Used when creating the gameboard for the very fist time
    Public Sub New_Display(Ox As Integer, Oy As Integer)

        Dim OriginX = Ox
        Dim OriginY = Oy
        Dim count As Integer

        For rows = 0 To 8
            For cols = 0 To 8

                count = 0

                For Can_rows = 0 To 2
                    For Can_cols = 0 To 2
                        'Set the default value for the candidate
                        count += 1
                        Cells(rows, cols).DefaultValue = count
                        'Create a new label
                        Cells(rows, cols).Candidate_Labels(Can_rows, Can_cols) = New Label

                        With Cells(rows, cols).Candidate_Labels(Can_rows, Can_cols)
                            .Tag = Cells(rows, cols)
                            .BackColor = Color.GhostWhite
                            .Size = New Size(CANDIDATE_SIZEpx, CANDIDATE_SIZEpx)
                            .Location = New Point(OriginX + (Cells(rows, cols).Parent_Box.X * BOX_PADDINGpx) + (cols * (TOTAL_CELL_SIZEpx + CELL_PADDINGpx)) + (Can_cols * (CANDIDATE_SIZEpx + CANDIDATE_PADDINGpx)), OriginY + (Cells(rows, cols).Parent_Box.Y * BOX_PADDINGpx) + (rows * (TOTAL_CELL_SIZEpx + CELL_PADDINGpx)) + (Can_rows * (CANDIDATE_PADDINGpx + CANDIDATE_SIZEpx)))
                            .Font = New Font("Symbol", CANDIDATE_SIZEpx * 0.65, FontStyle.Regular)
                            .TextAlign = ContentAlignment.TopCenter
                            .Text = count
                        End With
                        'Add a event to each label
                        AddHandler Cells(rows, cols).Candidate_Labels(Can_rows, Can_cols).Click, AddressOf Me.LblClick

                        'Add the label to the display
                        Form1.Controls.Add(Cells(rows, cols).Candidate_Labels(Can_rows, Can_cols))
                    Next
                Next

                Cells(rows, cols).Selectlabel = New Label
                With Cells(rows, cols).Selectlabel
                    .Size = New Size(TOTAL_CELL_SIZEpx + 6, TOTAL_CELL_SIZEpx + 6)
                    .Location = New Point(Cells(rows, cols).Candidate_Labels(0, 0).Location.X - 3, Cells(rows, cols).Candidate_Labels(0, 0).Location.Y - 3)
                    .BackColor = Color.FromArgb(45, 45, 45)
                    .Enabled = False
                    .Visible = True
                End With
                Form1.Controls.Add(Cells(rows, cols).Selectlabel)

            Next
        Next

    End Sub

    'Displays the current board. As is.
    Public Sub Update_Display()

        For Rows = 0 To 8
            For Cols = 0 To 8
                If Cells(Rows, Cols).HasValueFromImport = True Then
                    DisplayValueLabel(Cells(Rows, Cols), Cells(Rows, Cols).Candidates(0))
                Else
                    MatchCandidatestoLabels(Cells(Rows, Cols))
                End If
            Next
        Next

    End Sub

    'Mactches what the candidates are to what the labels display
    Public Sub MatchCandidatestoLabels(ParentCell As Cell)
        For rows = 0 To 2
            For cols = 0 To 2
                ParentCell.Candidate_Labels(rows, cols).Text = ""
                For Each ele In ParentCell.Candidates
                    If ((rows * 3 + cols) + 1) = ele Then
                        ParentCell.Candidate_Labels(rows, cols).Text = ele
                    End If
                Next
            Next
        Next
    End Sub

    'Input handlder for labels
    '_____________________________________________' 
    Public Sub LblClick(ByVal Sender As Label, e As System.EventArgs)

        SetLastClicked(Sender.Tag)

    End Sub
    '__________________________________________________'
    'Updates Lasted Clicked display and variable
    Private Sub SetLastClicked(ParentCell As Cell)

        If IsNothing(LastClicked) = False Then
            LastClicked.Selectlabel.BackColor = Color.FromArgb(45, 45, 45)
            If IsNothing(LastClicked.ValueLabel) = False Then
                LastClicked.ValueLabel.BackColor = Color.White
            End If
        End If

        LastClicked = ParentCell

        If LastClicked.HasValue = True Then
            LastClicked.ValueLabel.BackColor = Color.DarkSalmon
        End If
        LastClicked.Selectlabel.BackColor = Color.DarkSalmon
        UpdateButtons()

    End Sub

    'Handles the input for buttons
    Public Sub Edit(sender As Button, e As System.EventArgs)

        If Form1.Rad_Pen.Checked = True Then
            If LastClicked.HasValueFromImport = True Then
                Exit Sub
            End If
            If LastClicked.HasValue = False Then
                DisplayValueLabel(LastClicked, sender.Tag)
            Else
                sender.BackColor = Color.White
                DisableValueLabel(LastClicked)
            End If

        ElseIf Form1.Rad_Pencil.Checked = True Then

            'If the button when clicked is already selected, then we know we want to remove the label from candidates and reflect that back on the board
            If sender.BackColor = Color.DarkSalmon Then

                LastClicked.Candidates.Remove(Integer.Parse(sender.Tag))
                MatchCandidatestoLabels(LastClicked)
                sender.BackColor = Color.White

            Else 'we know that the user wants to add and we will add to the candidates and make the label match

                LastClicked.Candidates.Add(Integer.Parse(sender.Tag))
                MatchCandidatestoLabels(LastClicked)
                sender.BackColor = Color.DarkSalmon

            End If


        End If
        UpdateButtons()
    End Sub

    'Updates Button Colors according to the Value shown in display
    Public Sub UpdateButtons()
        If IsNothing(LastClicked) Then
            Exit Sub
        End If

        If Form1.Rad_Pen.Checked = True Then
            If LastClicked.HasValue = True Then

                'IF the cell has a value, reflect that in the buttons. Therefore, the button should light up DarkSalmon.
                For Each ele As Button In Keypad
                    ele.BackColor = Color.White
                    If Integer.Parse(LastClicked.ValueLabel.Text) = ele.Tag Then
                        ele.BackColor = Color.DarkSalmon
                    End If
                Next
            Else
                For Each ele As Button In Keypad
                    ele.BackColor = Color.White
                Next
                Exit Sub
            End If
        Else
            'The buttons should be coloured for the candidates of the cells
            If LastClicked.HasValue = False Then

                For Each ele As Button In Keypad
                    ele.BackColor = Color.White
                    For Each can In LastClicked.Candidates
                        If can = ele.Tag Then
                            ele.BackColor = Color.DarkSalmon

                        End If
                    Next
                Next
            Else
                For Each ele As Button In Keypad
                    ele.BackColor = Color.White
                Next
            End If
        End If
    End Sub

    'Displays a Value Label
    Public Sub DisplayValueLabel(ParentCell As Cell, value As Integer)

        ParentCell.Selectlabel.Visible = False
        ParentCell.ValueLabel = New Label
            ParentCell.HasValue = True
            With ParentCell.ValueLabel
                .Size = New Size(TOTAL_CELL_SIZEpx, TOTAL_CELL_SIZEpx)
                .Location = ParentCell.Candidate_Labels(0, 0).Location
                .Text = Convert.ToString(value)
                .Font = New Font("Symbol", 30, FontStyle.Bold)
                .TextAlign = ContentAlignment.TopCenter
                .BackColor = Color.White
                .BringToFront()
                .Visible = True
                .Enabled = True
                .Tag = ParentCell
            End With

            AddHandler ParentCell.ValueLabel.Click, AddressOf Me.LblClick

        Form1.Controls.Add(ParentCell.ValueLabel)


        For rows = 0 To 2
            For cols = 0 To 2
                With ParentCell.Candidate_Labels(rows, cols)
                    .Enabled = False
                    .Visible = False
                End With
            Next
        Next

    End Sub

    Public Sub DisableValueLabel(ParentCell As Cell)
        If ParentCell.HasValueFromImport = True Then
            Exit Sub
        End If

        ParentCell.HasValue = False
        ParentCell.ValueLabel.Dispose()
        ParentCell.Selectlabel.Visible = True


        For rows = 0 To 2
            For cols = 0 To 2
                With ParentCell.Candidate_Labels(rows, cols)
                    .Enabled = True
                    .Visible = True
                End With
            Next
        Next

    End Sub

End Class

Public Class Cell

    'Calculation Properties and Methods Here
    Public HasValueFromImport As Boolean
    Public HasValue As Boolean
    Public Parent_Box As Point
    Public Candidates As New ArrayList

    Public Sub New()
        HasValueFromImport = False
        HasValue = False
        Candidates.Clear()
        Candidates.Capacity = 9
    End Sub

    '________________________'

    'Display Properties and Methods Here
    Public Display_Candidates As New ArrayList
    Public Candidate_Labels(2, 2) As Label
    Public Selectlabel As New Label
    Public ValueLabel As Label
    Public DefaultValue As Integer
End Class

