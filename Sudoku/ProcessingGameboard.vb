Imports System.IO

Partial Public Class Gameboard

    'Imports a new board text file  from a file location. 
    Public Sub Import_New_Board()
        LastClicked = Nothing

        Dim r As New Random
        Dim f = Convert.ToString(FileList(r.Next(0, FileList.Count)).Fullname)
        Form1.Lstbx.Items.Add(Convert.ToString(f))

        'C:\Users\Samn\source\repos\Sudoku\Sudoku\bin\Debug\Easy1.Txt
        Using reader As New StreamReader(f) ' Temp File Location

            Dim Line As String

            For Rows = 0 To 8
                'Read in a new line, which comes in row form
                Line = reader.ReadLine
                For Cols = 0 To 8
                    'Clears the values of the board ready for a new set of values
                    Cells(Rows, Cols).Candidates.Clear()
                    Cells(Rows, Cols).HasValue = False
                    Cells(Rows, Cols).HasValueFromImport = False

                    If Not IsNothing(Cells(Rows, Cols).ValueLabel) Then
                        Cells(Rows, Cols).ValueLabel.Dispose()
                        Cells(Rows, Cols).ValueLabel = New Label
                        Cells(Rows, Cols).Selectlabel.Visible = True
                        For ro = 0 To 2
                            For c = 0 To 2
                                Cells(Rows, Cols).Candidate_Labels(ro, c).Enabled = True
                                Cells(Rows, Cols).Candidate_Labels(ro, c).Visible = True
                            Next
                        Next
                    End If

                    If Line(Cols) = "0" Then
                        'Fill the co-ordinated cell's candidates with all possible values
                        For i = 1 To 9
                            Cells(Rows, Cols).Candidates.Add(i)
                        Next
                    Else
                        'Fill the candidates with one value. Therefore we know that the candidate has a value
                        Cells(Rows, Cols).HasValueFromImport = True
                        Cells(Rows, Cols).HasValue = True
                        Cells(Rows, Cols).Value = (Integer.Parse(Line(Cols)))
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
                    RemovePossibleCandidates(Cells(Rows, Cols))
                End If
            Next
        Next

    End Sub

    'Displays the current board. As is.
    Public Sub Update_Display()

        For Rows = 0 To 8
            For Cols = 0 To 8
                If Cells(Rows, Cols).HasValueFromImport = True Then
                    DisplayValueLabel(Cells(Rows, Cols), Cells(Rows, Cols).Value)
                Else
                    MatchCandidatestoLabels(Cells(Rows, Cols))
                End If
            Next
        Next

    End Sub

    'Removes possible candidates based on the current value lables
    Private Sub RemovePossibleCandidates(_Cell As Cell)

        'Remove from each cell in the box. NB. Remove will try and remove the first instance of the value form the array. If there is none, it is fine with that too!
        For Each c As Cell In Box(_Cell.Parent_Box.X, _Cell.Parent_Box.Y)
            If c.HasValueFromImport = False Then
                'c.Candidates.Remove(Integer.Parse(_Cell.ValueLabel.Text)) 
                c.Candidates.Remove(_Cell.Value)
            End If
        Next

        'Remove Candidate from the row

        For Cols = 0 To 8
            If Cells(_Cell.CellLocation.Y, Cols).HasValue = False Then
                'Cells(_Cell.CellLocation.Y, Cols).Candidates.Remove(Integer.Parse(_Cell.ValueLabel.Text))
                Cells(_Cell.CellLocation.Y, Cols).Candidates.Remove(_Cell.Value)
            End If
        Next

        'Remove Candidate form the column

        For Rows = 0 To 8
            If Cells(Rows, _Cell.CellLocation.X).HasValue = False Then
                'Cells(Rows, _Cell.CellLocation.X).Candidates.Remove(Integer.Parse(_Cell.ValueLabel.Text))
                Cells(Rows, _Cell.CellLocation.X).Candidates.Remove(_Cell.Value)
            End If
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



End Class
