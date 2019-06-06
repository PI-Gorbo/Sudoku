Imports System.IO

Public Class ObjBoard

    Public Filelist As New ArrayList
    Public BaseBoardCells(8, 8) As ObjCell

    'New: Gets board. Gives Newly Created Cells a get Value. gives them a location relative to the board. 
    Public Sub New()

        Dim Dr As New DirectoryInfo("Boards")
        For Each file In Dr.GetFiles()
            Filelist.Add(file)
        Next

    End Sub

    Public Sub NewBoard()

        'Form1.Lstbx.Items.Clear()

        Dim r As New Random
        Dim f = Convert.ToString(Filelist(r.Next(0, Filelist.Count)).Fullname)
        Using reader As New StreamReader(f)
            Dim line As String

            For Rows = 0 To 8
                line = reader.ReadLine
                For Cols = 0 To 8

                    If IsNothing(BaseBoardCells(Rows, Cols)) = True Then
                        BaseBoardCells(Rows, Cols) = New ObjCell
                    Else
                        With BaseBoardCells(Rows, Cols)
                            .HasValueFromImport = False
                            .Value = -1
                            .DataCandidates.Clear()
                        End With
                    End If

                    With BaseBoardCells(Rows, Cols)

                        If line(Cols) = "0" Then
                            For i = 1 To 9
                                .DataCandidates.Add(i)
                                .Value = -1
                            Next
                        Else
                            .Value = Integer.Parse(line(Cols))
                            .HasValueFromImport = True
                        End If

                    End With


                    If Rows >= 0 And Rows <= 2 Then
                        BaseBoardCells(Rows, Cols).BoxLocation.Y = 0
                    ElseIf Rows >= 3 And Rows <= 5 Then
                        BaseBoardCells(Rows, Cols).BoxLocation.Y = 3
                    Else
                        BaseBoardCells(Rows, Cols).BoxLocation.Y = 6
                    End If

                    If Cols >= 0 And Cols <= 2 Then
                        BaseBoardCells(Rows, Cols).BoxLocation.X = 0
                    ElseIf Cols >= 3 And Cols <= 5 Then
                        BaseBoardCells(Rows, Cols).BoxLocation.X = 3
                    Else
                        BaseBoardCells(Rows, Cols).BoxLocation.X = 6
                    End If

                    BaseBoardCells(Rows, Cols).CellLocation = New Point(Cols, Rows)

                    PrintCandidates(BaseBoardCells(Rows, Cols))

                Next
            Next
        End Using
    End Sub

    Public Sub InputManualBoard()

    End Sub

    'Calculates which candidates must be removed from each cell
    Shared Sub CalculateCandidates(ByVal Cells(,) As ObjCell)

        For rows = 0 To 8
            For cols = 0 To 8

                If (Cells(rows, cols).Value) <> -1 Then

                    For TEMPROWS = 0 To 8
                        Cells(TEMPROWS, cols).DataCandidates.Remove(Cells(rows, cols).Value)
                    Next

                    For TEMPCOLS = 0 To 8
                        Cells(rows, TEMPCOLS).DataCandidates.Remove(Cells(rows, cols).Value)
                    Next

                    For TEMPROWS_ = Cells(rows, cols).BoxLocation.Y To Cells(rows, cols).BoxLocation.Y + 2
                        For TEMPCOLS_ = Cells(rows, cols).BoxLocation.X To Cells(rows, cols).BoxLocation.X + 2
                            Cells(TEMPROWS_, TEMPCOLS_).DataCandidates.Remove(Cells(rows, cols).Value)
                        Next
                    Next

                End If
            Next
        Next

    End Sub

    ''' <summary>
    ''' Calculates the Candidates that are possible for a current board. But also returns if a value has changed and if the board is invalid 
    ''' </summary>
    ''' <param name="Cells"> Valid 8x8 cell array </param>
    ''' <param name="ValueToBeChanged"> A byVal bool that returns if a value needs to be changed </param>
    ''' <param name="InvalidBoard"> A byVal bool that retuns if a value needs to be changed </param>
    Shared Sub CalculateCandidates(ByVal Cells(,) As ObjCell, ByVal ValueToBeChanged As Boolean, ByVal InvalidBoard As Boolean)

        ValueToBeChanged = False
        InvalidBoard = False

        For rows = 0 To 8
            For cols = 0 To 8

                If (Cells(rows, cols).Value) <> -1 Then

                    For TEMPROWS = 0 To 8
                        Cells(TEMPROWS, cols).DataCandidates.Remove(Cells(rows, cols).Value)
                        If Cells(TEMPROWS, cols).DataCandidates.Count = 1 Then
                            ValueToBeChanged = True
                        End If

                        If Cells(TEMPROWS, cols).DataCandidates.Count = 0 Then
                            InvalidBoard = True
                        End If
                    Next

                    For TEMPCOLS = 0 To 8
                        Cells(rows, TEMPCOLS).DataCandidates.Remove(Cells(rows, cols).Value)
                        If Cells(rows, TEMPCOLS).DataCandidates.Count = 1 Then
                            ValueToBeChanged = True
                        End If

                        If Cells(rows, TEMPCOLS).DataCandidates.Count = 0 Then
                            InvalidBoard = True
                        End If
                    Next

                    For TEMPROWS_ = Cells(rows, cols).BoxLocation.Y To Cells(rows, cols).BoxLocation.Y + 2
                        For TEMPCOLS_ = Cells(rows, cols).BoxLocation.X To Cells(rows, cols).BoxLocation.X + 2
                            Cells(TEMPROWS_, TEMPCOLS_).DataCandidates.Remove(Cells(rows, cols).Value)

                            If Cells(TEMPROWS_, TEMPCOLS_).DataCandidates.Count = 1 Then
                                ValueToBeChanged = True
                            End If

                            If Cells(TEMPROWS_, TEMPCOLS_).DataCandidates.Count = 0 Then
                                InvalidBoard = True
                            End If

                        Next
                    Next

                End If
            Next
        Next

    End Sub

    'Prints the candiates in a certain cell
    Public Sub PrintCandidates(ParentCell As ObjCell)

        Dim str As String = "[ "
        For Each ele In ParentCell.DataCandidates
            str = str + Convert.ToString(ele) + ","
        Next
        str += "]"
        Form1.Lstbx.Items.Add("[ " + Convert.ToString(ParentCell.CellLocation.X) + " " + Convert.ToString(ParentCell.CellLocation.Y) + " ] -->" + str)
    End Sub

    'Sweeps the board to check if the board has SOlved. Makes calls to isValidCell
    Public Function BoardSolved(Board As ObjCell(,))
        Dim solved As Boolean = False

        For rows = 0 To 8
            For cols = 0 To 8
                solved = isValidCell(Board, rows, cols)
                If solved = False Then
                    Return False
                End If
            Next
        Next

        Return True

    End Function

    'Checks a cell's value against its rows, cols and box for any cell with the same value. If this is true, then the board is false
    Public Function isValidCell(Board As ObjCell(,), rows As Integer, cols As Integer)

        For TempRows = 0 To 8
            If TempRows = rows Then
                Continue For
            End If
            If Board(TempRows, cols).Value = Board(rows, cols).Value Then
                Form1.Lstbx.Items.Add("ERROR AT [" + Convert.ToString(cols) + " " + Convert.ToString(rows) + " ]" + " with [" + Convert.ToString(cols) + " " + Convert.ToString(TempRows) + " ]")

                Return False
            End If
        Next

        For TempCols = 0 To 8
            If TempCols = cols Then
                Continue For
            End If

            If Board(rows, TempCols).Value = Board(rows, cols).Value Then
                Form1.Lstbx.Items.Add("ERROR AT [" + Convert.ToString(cols) + " " + Convert.ToString(rows) + " ]")
                Return False
            End If
        Next

        For TempRows = Board(rows, cols).BoxLocation.Y To Board(rows, cols).BoxLocation.Y + 2
            For TempCols = Board(rows, cols).BoxLocation.X To Board(rows, cols).BoxLocation.X + 2

                If TempRows = rows And TempCols = cols Then
                    Continue For
                End If

                If Board(TempRows, TempCols).Value = Board(rows, cols).Value Then
                    Form1.Lstbx.Items.Add("ERROR AT [" + cols + " " + rows + " ]")

                    Return False
                End If
            Next
        Next
        'Or Board(TempRows, TempCols).Value = -1 Or Board(rows, TempCols).Value = -1 Or Board(TempRows, cols).Value = -1
        Return True
    End Function

    'If the Cell has one candidate in it, it can be deduced tha the candidate has to be the value of the cell. Therefore, set the candidate to the value of the cell.
    Public Sub SetValues(Board As ObjCell(,))

        For rows = 0 To 8
            For cols = 0 To 8
                If Board(rows, cols).DataCandidates.Count = 1 Then
                    Board(rows, cols).Value = Board(rows, cols).DataCandidates(0)
                    Board(rows, cols).DataCandidates.Clear()
                End If
            Next
        Next

    End Sub

    'Brute Force.
    Public Sub Buteforce(ByRef Board As ObjCell(,))


    End Sub


End Class

Public Class ObjCell
    Public Value As Integer
    Public HasValueFromImport As Boolean
    Public Attempted As Integer
    Public DataCandidates As New ArrayList
    ''NOTE ABOUT BOX LOCATION. THE X AND Y CO-ORDS ARE THE COLS AND ROWS RESPECTIVELY.
    ''THE X And Y VALUES REPRESENT THE LOCATION Of THE FIRST CELL In THAT BOX
    ''IF YOU WANT TO IDERATE THROUGH A BOX, IDERATE BY GOING FOR X TO X+2. SAME FOR Y
    Public BoxLocation As Point
    Public CellLocation As Point

    Public Sub New()
        Attempted = 0
        HasValueFromImport = False
        Value = -1
        DataCandidates.Clear()
        DataCandidates.Capacity = 9
    End Sub
End Class