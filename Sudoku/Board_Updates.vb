Imports Microsoft.VisualBasic

Partial Public Class Gameboard

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

    End Sub

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

    End Sub

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


    End Sub

    Shared Sub UpdateDisplayValues(ByRef Display(,) As Display_Cells, ByRef Data(,) As ObjCell)

        For rows = 0 To 8
            For cols = 0 To 8

                Display(rows, cols).DisplayCandidates.Clear()

                For Each ele In Data(rows, cols).DataCandidates
                    Display(rows, cols).DisplayCandidates.Add(ele)
                Next
            Next
        Next

    End Sub

    'Label input handler
    Public Sub InputLbl(ByVal sender As Label, e As System.EventArgs)
        'Input handler for Labels.
        AllocateSelectLbl(sender.Tag)
    End Sub

    'Preforms the logic for showing which label has been recently clicked
    Public Sub AllocateSelectLbl(ParentCell As Display_Cells)

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
    End Sub

    'Handles the logic for adding and removing candidates and value labels from cells by the Keypads
    Public Sub Keypad_Input(ByVal sender As Button, e As System.EventArgs)
        'Input handler for keypads

        Dim val = Integer.Parse(sender.Tag)
        InputIntepreter(val)

    End Sub

    'Takes a value, and manages it but either adding it or removing it from the current selected cell
    Public Sub InputIntepreter(val As Integer)

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

    End Sub


    'Updates the Keypad to reflect the current cell clicked on 
    Public Sub UpdateKeypads()

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
    End Sub

End Class
