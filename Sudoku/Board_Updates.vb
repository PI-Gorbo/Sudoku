Imports Microsoft.VisualBasic

Partial Public Class Gameboard

    Dim HighlightedCandidates As New ArrayList

    ''' <summary>
    ''' Updates Cell by removing or adding a certain value from the candidates
    ''' </summary>
    ''' <param name="ParentCell">Display Cell</param>
    ''' <param name="value">Value from 1 ot 9</param>
    ''' <param name="Removing"> True for removing a candidae, False for adding candides</param>
    Public Sub UpdateLabels(ParentCell As Display_Cells, value As Integer, Removing As Boolean?)

        If Removing = True Then
            ParentCell.DisplayCandidates.Remove(value)
        ElseIf Removing = False Then
            ParentCell.DisplayCandidates.Add(value)
        End If

        For rows = 0 To 2
            For cols = 0 To 2

                ParentCell.Labels(rows, cols).Text = ""
                For Each ele In ParentCell.DisplayCandidates
                    If ((rows * 3 + cols) + 1) = Integer.Parse(ele) Then
                        ParentCell.Labels(rows, cols).Text = ele
                    End If
                Next
            Next
        Next

    End Sub 'd

    ''' <summary>
    ''' Updates Cell by removing or adding a certain value from the candidates
    ''' </summary>
    ''' <param name="ParentCell">Display Cell</param>
    ''' <param name="value">Value from 1 ot 9</param>
    ''' <param name="Removing"> True for removing a candidae, False for adding candides</param>
    ''' <param name="Labels">True for converting to candidates</param>
    Public Sub UpdatesLabes(ParentCell As Display_Cells, value As Integer, Removing As Boolean?, Labels As Boolean?)

        If Removing = True Then
            ParentCell.DisplayCandidates.Remove(value)
        ElseIf Removing = False Then
            ParentCell.DisplayCandidates.Add(value)
        End If

        For rows = 0 To 2
            For cols = 0 To 2
                If Labels = True And ParentCell.DisplayCandidates.Count = 1 Then
                    DisplayValueLabel(ParentCell, ParentCell.DisplayCandidates(0))
                Else
                    ParentCell.Labels(rows, cols).Text = ""
                    For Each ele In ParentCell.DisplayCandidates
                        If ((rows * 3 + cols) + 1) = Integer.Parse(ele) Then
                            ParentCell.Labels(rows, cols).Text = ele
                        End If
                    Next
                End If

            Next
        Next

    End Sub 'd

    Public Sub UpdateLabels(DisplayCells(,) As Display_Cells, DataCells(,) As ObjCell)

        For rows = 0 To 8
            For cols = 0 To 8

                If DisplayCells(rows, cols).DisplayCandidates.Count = 0 And DataCells(rows, cols).HasValueFromImport = False Then
                    DisplayValueLabel(DisplayCells(rows, cols), DataCells(rows, cols).Value)
                End If
                If DisplayCells(rows, cols).DisplayCandidates.Count <> 0 Then

                    For lblrows = 0 To 2
                        For lblcols = 0 To 2
                            DisplayCells(rows, cols).Labels(lblrows, lblcols).Text = ""
                            For Each ele In DisplayCells(rows, cols).DisplayCandidates
                                If ((lblrows * 3 + lblcols) + 1) = Integer.Parse(ele) Then
                                    DisplayCells(rows, cols).Labels(lblrows, lblcols).Text = ele
                                End If
                            Next
                        Next
                    Next
                End If


            Next
        Next


    End Sub 'd

    Shared Sub UpdateDisplayValues(ByRef Display(,) As Display_Cells, ByRef Data(,) As ObjCell)

        For rows = 0 To 8
            For cols = 0 To 8

                Display(rows, cols).DisplayCandidates.Clear()

                For Each ele In Data(rows, cols).DataCandidates
                    Display(rows, cols).DisplayCandidates.Add(ele)
                Next
            Next
        Next

    End Sub 'd

    'Label input handler
    Public Sub InputLbl(ByVal sender As Label, e As System.EventArgs)
        'Input handler for Labels.
        AllocateSelectLbl(sender.Tag)
    End Sub 'd

    'Preforms the logic for showing which label has been recently clicked
    Public Sub AllocateSelectLbl(ParentCell As Display_Cells)

        If Form1.Check_CandidateHighlighting.Checked = False Then


            If Not IsNothing(LastClicked) Then
                LastClicked.SelectedLabel.Visible = False
                LastClicked.ValueLabel.BackColor = Color.White
            End If
            LastClicked = ParentCell

            If LastClicked.HasValueLabel Then
                LastClicked.ValueLabel.BackColor = Color.DarkSalmon
                LastClicked.SelectedLabel.BackColor = Color.DarkSalmon

            Else
                LastClicked.SelectedLabel.BackColor = Color.DarkSalmon
                LastClicked.ValueLabel.BackColor = Color.DarkSalmon
                LastClicked.SelectedLabel.Visible = True
            End If

            UpdateKeypads()
        Else
            If Not IsNothing(LastClicked) Then
                LastClicked.SelectedLabel.Visible = False
                LastClicked.ValueLabel.BackColor = Color.White
                LastClicked = Nothing
            End If
        End If
    End Sub 'd

    'Handles the logic for adding and removing candidates and value labels from cells by the Keypads
    Public Sub Keypad_Input(ByVal sender As Button, e As System.EventArgs)
        'Input handler for keypads

        Dim val = Integer.Parse(sender.Tag)
        InputIntepreter(val)



    End Sub 'd

    'Takes a value, and manages it but either adding it or removing it from the current selected cell
    Public Sub InputIntepreter(val As Integer)

        If Form1.Check_CandidateHighlighting.Checked = True Then

            ' if the candidate is not already part of the Highlighted candidates, then add it
            If HighlightedCandidates.Contains(val) = False Then

                HighlightedCandidates.Add(val)

            Else 'If the value is already part of the higglighted candidates then remove it

                HighlightedCandidates.Remove(val)

            End If

            For rows = 0 To 8
                For cols = 0 To 8

                    For lbl_rows = 0 To 2
                        For lbl_cols = 0 To 2

                            If HighlightedCandidates.Contains(((lbl_rows * 3 + lbl_cols) + 1)) And Cells(rows, cols).DisplayCandidates.Contains((lbl_rows * 3 + lbl_cols) + 1) Then

                                Cells(rows, cols).Labels(lbl_rows, lbl_cols).BackColor = Colours(((lbl_rows * 3 + lbl_cols) + 1))
                            Else
                                Cells(rows, cols).Labels(lbl_rows, lbl_cols).BackColor = Color.White
                            End If

                        Next
                    Next

                Next
            Next
            UpdateKeypads()

            Exit Sub

        End If

        If Form1.Check_Medusa.Checked = True Then

            'Clear all Highlighted candidates

            UpdateKeypads()
            Exit Sub

        End If

        If Form1.Rad_Pen.Checked = True Then

            If LastClicked.DataCell.HasValueFromImport = True Then

                Exit Sub

            ElseIf LastClicked.HasValueLabel = True Then

                ClearValues(LastClicked)
                Keypads(val - 1).BackColor = Color.White

            Else

                DisplayValueLabel(LastClicked, val)
                Keypads(val - 1).BackColor = Color.DarkSalmon

            End If

        ElseIf Form1.Rad_Pencil.Checked = True Then

            Dim LocY As Integer = 0
            Dim LocX As Integer = 0

            Select Case val
                Case 1
                    LocY = 0
                    LocX = 0
                Case 2
                    LocY = 0
                    LocX = 1
                Case 3
                    LocY = 0
                    LocX = 2
                Case 4
                    LocY = 1
                    LocX = 0
                Case 5
                    LocY = 1
                    LocX = 1
                Case 6
                    LocY = 1
                    LocX = 2
                Case 7
                    LocY = 2
                    LocX = 0
                Case 8
                    LocY = 2
                    LocX = 1
                Case 9
                    LocY = 2
                    LocX = 2

                Case Else
                    LocY = -1 And LocX = -1

            End Select

            'If the value is the correct value for that cell, and we are removing that value from the possible candidates then
            If val = Gameboard.SolvedBoard.Cells(LastClicked.DataCell.CellLocation.Y, LastClicked.DataCell.CellLocation.X).Value And LastClicked.DisplayCandidates.Contains(val) And Form1.Check_CandidateAltert.Checked = True Then
                'Highlight that value has red. 
                LastClicked.Labels(LocY, LocX).ForeColor = Color.IndianRed
                Exit Sub
            End If

            If LastClicked.DataCell.HasValueFromImport = True Then
                Exit Sub

            ElseIf Keypads(val - 1).BackColor = Color.DarkSalmon Then
                UpdateLabels(LastClicked, val, True)
                Keypads(val - 1).BackColor = Color.White
            Else
                UpdateLabels(LastClicked, val, False)
                Keypads(val - 1).BackColor = Color.DarkSalmon
            End If

        End If

        UpdateKeypads()

    End Sub 'd

    'Updates the Keypad to reflect the current cell clicked on 
    Public Sub UpdateKeypads()

        If Form1.Check_CandidateHighlighting.Checked = True Then
            'Goes through all the chosen highlighted candidates, then correspondes that with the keypads

            For i = 0 To 8
                If HighlightedCandidates.Contains(i + 1) Then
                    Keypads(i).BackColor = Colours(i + 1)
                Else
                    Keypads(i).BackColor = Color.White
                End If
            Next

        ElseIf Form1.Check_Medusa.Checked = True Then



        Else

            If IsNothing(LastClicked) Then
                Exit Sub
            End If

            For Each ele As Button In Keypads
                ele.BackColor = Color.White
            Next

            If Form1.Rad_Pen.Checked = True Then

                If LastClicked.HasValueLabel = True Then
                    For Each ele As Button In Keypads
                        If ele.Tag = LastClicked.ValueLabel.Text Then
                            ele.BackColor = Color.DarkSalmon
                        End If
                    Next
                Else
                    Exit Sub
                End If

            Else

                For Each ele As Button In Keypads
                    If LastClicked.DisplayCandidates.Contains(Integer.Parse(ele.Tag)) Then
                        ele.BackColor = Color.DarkSalmon
                    End If
                Next

            End If

        End If

    End Sub 'd

End Class
