'Imports Microsoft.VisualBasic
'Imports System.IO


'Public Class Gameboard
'    Dim FileList As New ArrayList
'    Dim Keypad As New ArrayList
'    Dim Cells(8, 8) As Cell
'    Dim Box(2, 2) As ArrayList
'    Dim LastClicked As Cell

'    Public Const CANDIDATE_SIZEpx As Integer = 16
'    Public Const CANDIDATE_PADDINGpx As Integer = 0

'    Public Const TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
'    Public Const CELL_PADDINGpx As Integer = 6

'    Public Const TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
'    Public Const BOX_PADDINGpx As Integer = 12

'    Public Const GAME_SIZEpx = (3 * TOTAL_BOX_SIZEpx) + (2 * BOX_PADDINGpx)
'    Public Const LINE_WIDTH As Integer = 5

'    'On creation of a new board, creates cell objects and groups them into their boxes for future changes
'    Public Sub New(OriginX, OriginY)

'        Dim BoxX, BoxY As Integer

'        Keypad.Add(Form1.Keypad_1)
'        Keypad.Add(Form1.Keypad_2)
'        Keypad.Add(Form1.Keypad_3)
'        Keypad.Add(Form1.Keypad_4)
'        Keypad.Add(Form1.Keypad_5)
'        Keypad.Add(Form1.Keypad_6)
'        Keypad.Add(Form1.Keypad_7)
'        Keypad.Add(Form1.Keypad_8)
'        Keypad.Add(Form1.Keypad_9)


'        'Iderate Through Cells.
'        For Rows = 0 To 8
'            For Cols = 0 To 8
'                'Create the new Cell Object
'                Cells(Rows, Cols) = New Cell
'                Cells(Rows, Cols).CellLocation.X = Cols
'                Cells(Rows, Cols).CellLocation.Y = Rows
'                'Determine the box that each Cell belongs to. 
'                BoxY = Math.Floor(Rows / 3)
'                BoxX = Math.Floor(Cols / 3)

'                'Add the Cell to its parent box
'                If IsNothing(Box(BoxX, BoxY)) Then
'                    Box(BoxX, BoxY) = New ArrayList
'                End If
'                Box(BoxX, BoxY).Add(Cells(Rows, Cols))
'                'Add a refrence to the parent box for each cell
'                Cells(Rows, Cols).Parent_Box.X = BoxX
'                Cells(Rows, Cols).Parent_Box.Y = BoxY
'            Next
'        Next

'        'Add all files to the list of files
'        Dim Dr As New DirectoryInfo("Boards")
'        For Each file In Dr.GetFiles()
'            FileList.Add(file)
'        Next


'        New_Display(OriginX, OriginY)

'    End Sub

'    'Creates a new display with no information. Used when creating the gameboard for the very fist time
'    Public Sub New_Display(Ox As Integer, Oy As Integer)

'        Dim OriginX = Ox
'        Dim OriginY = Oy
'        Dim count As Integer

'        For rows = 0 To 8
'            For cols = 0 To 8

'                count = 0

'                For Can_rows = 0 To 2
'                    For Can_cols = 0 To 2
'                        'Set the default value for the candidate
'                        count += 1
'                        Cells(rows, cols).DefaultValue = count
'                        'Create a new label
'                        Cells(rows, cols).Candidate_Labels(Can_rows, Can_cols) = New Label

'                        With Cells(rows, cols).Candidate_Labels(Can_rows, Can_cols)
'                            
'                        End With
'                        'Add a event to each label
'                        AddHandler Cells(rows, cols).Candidate_Labels(Can_rows, Can_cols).Click, AddressOf Me.LblClick

'                        'Add the label to the display
'                        Form1.Controls.Add(Cells(rows, cols).Candidate_Labels(Can_rows, Can_cols))
'                    Next
'                Next

'                Cells(rows, cols).Selectlabel = New Label
'                With Cells(rows, cols).Selectlabel
'                    .Size = New Size(TOTAL_CELL_SIZEpx + 6, TOTAL_CELL_SIZEpx + 6)
'                    .Location = New Point(Cells(rows, cols).Candidate_Labels(0, 0).Location.X - 3, Cells(rows, cols).Candidate_Labels(0, 0).Location.Y - 3)
'                    .BackColor = Color.FromArgb(45, 45, 45)
'                    .Enabled = False
'                    .Visible = True
'                End With
'                Form1.Controls.Add(Cells(rows, cols).Selectlabel)

'            Next
'        Next

'    End Sub

'    'Input handlder for labels
'    Public Sub LblClick(ByVal Sender As Label, e As System.EventArgs)

'        SetLastClicked(Sender.Tag)

'    End Sub

'    'Updates Lasted Clicked display and variable
'    Private Sub SetLastClicked(ParentCell As Cell)

'        If IsNothing(LastClicked) = False Then
'            LastClicked.Selectlabel.BackColor = Color.FromArgb(45, 45, 45)
'            If IsNothing(LastClicked.ValueLabel) = False Then
'                LastClicked.ValueLabel.BackColor = Color.White
'            End If
'        End If

'        LastClicked = ParentCell

'        If LastClicked.HasValue = True Then
'            LastClicked.ValueLabel.BackColor = Color.DarkSalmon
'        End If
'        LastClicked.Selectlabel.BackColor = Color.DarkSalmon
'        UpdateButtons()

'    End Sub

'    'Handles the input for buttons
'    Public Sub Edit(sender As Button, e As System.EventArgs)

'        If Form1.Rad_Pen.Checked = True Then
'            If LastClicked.HasValueFromImport = True Then
'                Exit Sub
'            End If
'            If LastClicked.HasValue = False Then
'                DisplayValueLabel(LastClicked, sender.Tag)
'            Else
'                sender.BackColor = Color.White
'                DisableValueLabel(LastClicked)
'            End If

'        ElseIf Form1.Rad_Pencil.Checked = True Then

'            'If the button when clicked is already selected, then we know we want to remove the label from candidates and reflect that back on the board
'            If sender.BackColor = Color.DarkSalmon Then

'                LastClicked.Candidates.Remove(Integer.Parse(sender.Tag))
'                MatchCandidatestoLabels(LastClicked)
'                sender.BackColor = Color.White

'            Else 'we know that the user wants to add and we will add to the candidates and make the label match

'                LastClicked.Candidates.Add(Integer.Parse(sender.Tag))
'                MatchCandidatestoLabels(LastClicked)
'                sender.BackColor = Color.DarkSalmon

'            End If


'        End If
'        UpdateButtons()
'    End Sub

'    'Updates Button Colors according to the Value shown in display
'    Public Sub UpdateButtons()
'        If IsNothing(LastClicked) Then
'            Exit Sub
'        End If

'        If Form1.Rad_Pen.Checked = True Then
'            If LastClicked.HasValue = True Then

'                'IF the cell has a value, reflect that in the buttons. Therefore, the button should light up DarkSalmon.
'                For Each ele As Button In Keypad
'                    ele.BackColor = Color.White
'                    If LastClicked.Value = ele.Tag Then
'                        ele.BackColor = Color.DarkSalmon
'                    End If
'                Next
'            Else
'                For Each ele As Button In Keypad
'                    ele.BackColor = Color.White
'                Next
'                Exit Sub
'            End If
'        Else
'            'The buttons should be coloured for the candidates of the cells
'            If LastClicked.HasValue = False Then

'                For Each ele As Button In Keypad
'                    ele.BackColor = Color.White
'                    For Each can In LastClicked.Candidates
'                        If can = ele.Tag Then
'                            ele.BackColor = Color.DarkSalmon

'                        End If
'                    Next
'                Next
'            Else
'                For Each ele As Button In Keypad
'                    ele.BackColor = Color.White
'                Next
'            End If
'        End If
'    End Sub

'    'Displays and disables Value Label
'    Public Sub DisplayValueLabel(ParentCell As Cell, _value As Integer)

'        ParentCell.Selectlabel.Visible = False
'        ParentCell.ValueLabel = New Label
'        ParentCell.HasValue = True
'        ParentCell.Value = _value
'        With ParentCell.ValueLabel
'            .Size = New Size(TOTAL_CELL_SIZEpx, TOTAL_CELL_SIZEpx)
'            .Location = ParentCell.Candidate_Labels(0, 0).Location
'            .Text = Convert.ToString(ParentCell.Value)
'            .Font = New Font("Symbol", 30, FontStyle.Bold)
'            If ParentCell.HasValueFromImport Then
'                .ForeColor = Color.Blue
'            End If
'            .TextAlign = ContentAlignment.TopCenter
'            .BackColor = Color.White
'            .BringToFront()
'            .Visible = True
'            .Enabled = True
'            .Tag = ParentCell
'        End With

'        AddHandler ParentCell.ValueLabel.Click, AddressOf Me.LblClick

'        Form1.Controls.Add(ParentCell.ValueLabel)


'        For rows = 0 To 2
'            For cols = 0 To 2
'                With ParentCell.Candidate_Labels(rows, cols)
'                    .Enabled = False
'                    .Visible = False
'                End With
'            Next
'        Next

'    End Sub

'    Public Sub DisableValueLabel(ParentCell As Cell)
'        If ParentCell.HasValueFromImport = True Then
'            Exit Sub
'        End If

'        ParentCell.HasValue = False
'        ParentCell.Value = vbNull
'        ParentCell.ValueLabel.Dispose()
'        ParentCell.Selectlabel.Visible = True


'        For rows = 0 To 2
'            For cols = 0 To 2
'                With ParentCell.Candidate_Labels(rows, cols)
'                    .Enabled = True
'                    .Visible = True
'                End With
'            Next
'        Next

'    End Sub
'    'Matches the Data Candidates to the Display Candidates
'    Public Sub Match_DataCandidates_To_Candidates()
'        For rows = 0 To 8
'            For cols = 0 To 8
'                Cells(rows, cols).Candidates.Clear()
'                Cells(rows, cols).Candidates = Cells(rows, cols).CalcCandidates
'                Form1.Lstbx.Items.Add(Cells(rows, cols).CalcCandidates.Count)
'            Next
'        Next

'        Update_Display()
'    End Sub

'    'Clears Labels
'    Public Sub ClearLabels()
'        For row = 0 To 8
'            For cols = 0 To 8
'                For lblrow = 0 To 2
'                    For lblcol = 0 To 8
'                        Cells(row, cols).Candidates.Clear()
'                    Next
'                Next
'            Next
'        Next
'        Update_Display()

'    End Sub

'End Class

'Public Class Cell

'    'Calculation Properties and Methods Here
'    Public HasValueFromImport As Boolean
'    Public HasValue As Boolean
'    Public Value As Integer?
'    Public Parent_Box As Point
'    Public CalcCandidates As New ArrayList

'    '________________________'

'    'Display Properties and Methods Here
'    'Public Display_Candidates As New ArrayList
'    Public Candidate_Labels(2, 2) As Label
'    Public Selectlabel As New Label
'    Public ValueLabel As Label
'    Public DefaultValue As Integer
'    Public Candidates As New ArrayList
'    Public CellLocation As Point


'    Public Sub New()
'        HasValueFromImport = False
'        HasValue = False
'        Value = vbnull
'        Candidates.Clear()
'        Candidates.Capacity = 9
'        CalcCandidates.Capacity = 9
'    End Sub

'End Class

