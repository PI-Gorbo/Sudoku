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

                    'PrintCandidates(BaseBoardCells(Rows, Cols))

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
    Shared Sub ResolveCandidates(ByRef Cells(,) As ObjCell, ByRef ValueToBeChanged As Boolean, ByRef InvalidBoard As Boolean)

        Form1.Lstbx.Items.Add(" ")
        Form1.Lstbx.Items.Add("CALCULATING CADIDATES [...]")
        Form1.Lstbx.Items.Add(" ")

        ValueToBeChanged = False
        InvalidBoard = False

        For rows = 0 To 8
            For cols = 0 To 8

                If (Cells(rows, cols).Value) <> -1 Then

                    For TEMPROWS = 0 To 8
                        Cells(TEMPROWS, cols).DataCandidates.Remove(Cells(rows, cols).Value)
                        If Cells(TEMPROWS, cols).DataCandidates.Count = 1 And ValueToBeChanged = False Then
                            ValueToBeChanged = True
                            Form1.Lstbx.Items.Add("Found a Cell that can be upgraded at [ " + Convert.ToString(TEMPROWS) + " " + Convert.ToString(cols) + " ]")
                        End If

                        If Cells(TEMPROWS, cols).DataCandidates.Count = 0 And Cells(TEMPROWS, cols).Value = -1 And InvalidBoard = False Then
                            Form1.Lstbx.Items.Add(1)
                            InvalidBoard = True
                        End If
                    Next

                    For TEMPCOLS = 0 To 8
                        Cells(rows, TEMPCOLS).DataCandidates.Remove(Cells(rows, cols).Value)
                        If Cells(rows, TEMPCOLS).DataCandidates.Count = 1 And ValueToBeChanged = False Then
                            Form1.Lstbx.Items.Add("Found a Cell that can be upgraded at [ " + Convert.ToString(rows) + " " + Convert.ToString(TEMPCOLS) + " ]")
                            ValueToBeChanged = True
                        End If

                        If Cells(rows, TEMPCOLS).DataCandidates.Count = 0 And Cells(rows, TEMPCOLS).Value = -1 And InvalidBoard = False Then
                            Form1.Lstbx.Items.Add(2)

                            InvalidBoard = True
                        End If
                    Next

                    For TEMPROWS_ = Cells(rows, cols).BoxLocation.Y To Cells(rows, cols).BoxLocation.Y + 2
                        For TEMPCOLS_ = Cells(rows, cols).BoxLocation.X To Cells(rows, cols).BoxLocation.X + 2
                            Cells(TEMPROWS_, TEMPCOLS_).DataCandidates.Remove(Cells(rows, cols).Value)

                            If Cells(TEMPROWS_, TEMPCOLS_).DataCandidates.Count = 1 And ValueToBeChanged = False Then
                                Form1.Lstbx.Items.Add("Found a Cell that can be upgraded at [ " + Convert.ToString(TEMPROWS_) + " " + Convert.ToString(TEMPCOLS_) + " ]")
                                ValueToBeChanged = True
                            End If

                            If Cells(TEMPROWS_, TEMPCOLS_).DataCandidates.Count = 0 And Cells(TEMPROWS_, TEMPCOLS_).Value = -1 And InvalidBoard = False Then
                                Form1.Lstbx.Items.Add(3)

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

    Public Sub DebugCellStatement(OCRow As Integer, OCCol As Integer, TCRow As Integer, TCCol As Integer, DebugStatement As String)
        Form1.Lstbx.Items.Add("Cell [" + CStr(OCCol) + " " + CStr(OCRow) + "] --> Cell [" + CStr(TCCol) + " " + CStr(TCRow) + "] : " + DebugStatement)
    End Sub

    'Sweeps the board to check if the board has SOlved. Makes calls to isValidCell
    Public Function isBoardSolved(Board As ObjCell(,))

        Form1.Lstbx.Items.Add("")
        Form1.Lstbx.Items.Add("CHECKING SOLVED [...]")
        Form1.Lstbx.Items.Add("")



        Dim solved As Boolean = False

        For rows = 0 To 8
            For cols = 0 To 8
                solved = isValidCell(Board, rows, cols)
                If solved = False Then

                    Form1.Lstbx.Items.Add("FALSE!")

                    Return False
                End If
            Next
        Next

        Form1.Lstbx.Items.Add("TRUE!")

        Return True

    End Function

    'Checks a cell's value against its rows, cols and box for any cell with the same value. If this is true, then the board is false
    Public Function isValidCell(Board As ObjCell(,), rows As Integer, cols As Integer)

        For TempRows = 0 To 8
            If TempRows = rows Then
                Continue For
            End If
            If Board(TempRows, cols).Value = Board(rows, cols).Value Or Board(TempRows, cols).Value = -1 Then
                DebugCellStatement(cols, rows, cols, TempRows, "ERROR with Cell in column.")
                Return False
            End If
        Next

        For TempCols = 0 To 8
            If TempCols = cols Then
                Continue For
            End If

            If Board(rows, TempCols).Value = Board(rows, cols).Value Or Board(rows, TempCols).Value = -1 Then
                DebugCellStatement(cols, rows, TempCols, rows, "ERROR with Cell in row.")
                Return False
            End If
        Next

        For TempRows = Board(rows, cols).BoxLocation.Y To Board(rows, cols).BoxLocation.Y + 2
            For TempCols = Board(rows, cols).BoxLocation.X To Board(rows, cols).BoxLocation.X + 2

                If TempRows = rows And TempCols = cols Then
                    Continue For
                End If

                If Board(TempRows, TempCols).Value = Board(rows, cols).Value Or Board(TempRows, TempCols).Value = -1 Then
                    DebugCellStatement(cols, rows, TempCols, TempRows, "ERROR with Cell in box.")
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    'Returns True of the Board inputted has no empty candidate Cells, and no Duplicate values 
    Public Function isBoardValid(Board As ObjCell(,))

        Form1.Lstbx.Items.Add(" ")
        Form1.Lstbx.Items.Add("CHECKING VALIDITY [...]")
        Form1.Lstbx.Items.Add(" ")

        Dim NumberOfClues As Integer = 0

        For rows = 0 To 8
            For cols = 0 To 8

                If Board(rows, cols).Value <> -1 Then
                    NumberOfClues += 1
                End If

                'Checks if there are no empty candidates when the cell does not have a value
                If Board(rows, cols).DataCandidates.Count = 0 And Board(rows, cols).Value = -1 Then
                    Form1.Lstbx.Items.Clear()
                    Form1.Lstbx.Items.Add("Error with a Cell having no candidates and no Value")
                    Return False
                End If

                'Checks every col and row a cell has access to. Returns false the Cell has the same value as any other cell selected. 
                For TempRows = 0 To 8
                    If Board(TempRows, cols).Value = Board(rows, cols).Value And Board(rows, cols).Value <> -1 And Board(TempRows, cols).Equals(Board(rows, cols)) = False Then
                        Form1.Lstbx.Items.Clear()
                        DebugCellStatement(cols, rows, cols, TempRows, "ERROR with Cell in col.")
                        Return False
                    End If
                Next

                For TempCols = 0 To 8
                    If Board(rows, TempCols).Value = Board(rows, cols).Value And Board(rows, cols).Value <> -1 And Board(rows, TempCols).Equals(Board(rows, cols)) = False Then
                        Form1.Lstbx.Items.Clear()
                        DebugCellStatement(cols, rows, TempCols, rows, "ERROR with Cell in row.")
                        Return False
                    End If
                Next

                'Checks every cell in the orginial cell's box to check if they dont have the same value as it. 
                For TempRows = Board(rows, cols).BoxLocation.Y To Board(rows, cols).BoxLocation.Y + 2
                    For TempCols = Board(rows, cols).BoxLocation.X To Board(rows, cols).BoxLocation.X + 2

                        If Board(TempRows, TempCols).Value = Board(rows, cols).Value And Board(rows, cols).Value <> -1 And Board(rows, TempCols).Equals(Board(rows, cols)) = False Then
                            Form1.Lstbx.Items.Clear()
                            DebugCellStatement(cols, rows, cols, TempRows, "ERROR with Cell in box.")
                            Return False
                        End If

                    Next
                Next

            Next
        Next

        If NumberOfClues <= 17 Then
            Return False
        End If

        Form1.Lstbx.Items.Add("Board Valid!")
        Return True

    End Function

    'If the Cell has one candidate in it, it can be deduced tha the candidate has to be the value of the cell. Therefore, set the candidate to the value of the cell.
    Public Sub ResolveValues(Board As ObjCell(,))

		For rows = 0 To 8
			For cols = 0 To 8
				If Board(rows, cols).DataCandidates.Count = 1 Then
					Form1.Lstbx.Items.Add("Cell at [ " + Convert.ToString(rows) + " " + Convert.ToString(cols) + " ]")
					Board(rows, cols).Value = Board(rows, cols).DataCandidates(0)
					Board(rows, cols).DataCandidates.Clear()
				End If
			Next
		Next

	End Sub

    'Loop [ResolveCandidates] untill there is no progress in the board. Return solved or Error
    Public Sub ResolveBoard(ByRef Board As ObjCell(,), ByRef solved As Boolean, ByRef _Err As Boolean)

        solved = False
        _Err = False

        Dim _Continue As Boolean = True
        While _Continue = True

            ResolveCandidates(Board, _Continue, _Err)
            ResolveValues(Board)

            If _Err = True Then
                Form1.Lstbx.Items.Add("ERROR!")
                Exit Sub
            End If

            If isBoardSolved(Board) = True Then
                Form1.Lstbx.Items.Add("Exited Early")
                solved = isBoardSolved(Board)
                Exit Sub
            End If

        End While

        solved = isBoardSolved(Board)

    End Sub
    'Deep Copies An array of ObjCells to Another ObjCell

    Public Sub DeepClone(ByRef Tempboard(,) As ObjCell, ByRef OrigBoard(,) As ObjCell)
        For rows = 0 To 8
            For cols = 0 To 8
                Tempboard(rows, cols) = New ObjCell
                Tempboard(rows, cols).BoxLocation.X = OrigBoard(rows, cols).BoxLocation.X
                Tempboard(rows, cols).BoxLocation.Y = OrigBoard(rows, cols).BoxLocation.Y
                Tempboard(rows, cols).CellLocation.X = OrigBoard(rows, cols).CellLocation.X
                Tempboard(rows, cols).CellLocation.Y = OrigBoard(rows, cols).CellLocation.Y
                Tempboard(rows, cols).DataCandidates.Clear()
                For Each ele In OrigBoard(rows, cols).DataCandidates
                    Tempboard(rows, cols).DataCandidates.Add(ele)
                Next
                Tempboard(rows, cols).Value = OrigBoard(rows, cols).Value
                Tempboard(rows, cols).HasValueFromImport = OrigBoard(rows, cols).HasValueFromImport


            Next
        Next
    End Sub
    '__________________________________________________________________'

    'Brute Force.
    Function BruteForce(ByRef Board As ObjCell(,), ByRef _Solved As Boolean, ByRef _Error As Boolean)

        _Error = False
        _Solved = False

        'Check if Board is Valid. If Invalid, escape and set Error to True. 
        If isBoardValid(Board) = False Then
            _Error = True
            Return Board
        End If

        'Eliminate Candidates 
        ResolveBoard(Board, _Solved, _Error)

        'If _Error is true after Elimiating Candidates, Escape and Set Error To True
        'Check if the Board is Solved, If True, Return the board and set _Solved to True. 
        If _Error = True Or _Solved = True Then
            Return Board
        End If

        '_________________________________'

        If Not _Solved Then
            Dim TempSolved As Boolean = False
            Dim TempError As Boolean = False
            Dim SelectedLabelLocation As New Point(-1, -1)
            Dim Tempboard(8, 8) As ObjCell
            Dim MaxCandidateIndex As Integer = -1
            Dim CurrentIndex As Integer = -1

            'At this point it is assumed that the board is valid and unsolved. 
            'Candidates has been calculated, and therefore, we know that one of the candidates must be the correct one.


            'Find a cell without a value. This cell will have 2 or more candidates and we know that one of them must be correct.
            'Make this cell the "Selected Cell"
            For rows = 0 To 8
                For cols = 0 To 8

                    If Board(rows, cols).Value = -1 Then
                        SelectedLabelLocation.X = cols
                        SelectedLabelLocation.Y = rows
                        Exit For
                    End If
                Next
                If SelectedLabelLocation.X <> -1 And SelectedLabelLocation.Y <> -1 Then
                    Exit For
                End If
            Next
            Form1.Lstbx.Items.Add("(((" + CStr(SelectedLabelLocation.X) + " " + CStr(SelectedLabelLocation.Y) + ")))")
            If SelectedLabelLocation.X = -1 And SelectedLabelLocation.Y = -1 Then
                _Error = True
                _Solved = False
                Return Board
            End If


            'Get the number of Candidates in the Selected Cell. Make a count starting at 0 
            MaxCandidateIndex = Board(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates.Count - 1
                Form1.Lstbx.Items.Add(MaxCandidateIndex)
                CurrentIndex = 0

                'DO:
                Do
                    TempSolved = False
                    TempError = False

                    'Make a TempBoard that is the same as the orignial board. 
                    DeepClone(Tempboard, Board)

                    'Choose the (count) candidate of the Selected Cell and Make it the value of the cell. 
                    PrintCandidates(Tempboard(SelectedLabelLocation.Y, SelectedLabelLocation.X))
                    Tempboard(SelectedLabelLocation.Y, SelectedLabelLocation.X).Value = Tempboard(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates(CurrentIndex)
                    Tempboard(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates.Clear()

                    'Bruteforce the board
                    BruteForce(Tempboard, TempSolved, TempError)

                    'Check if the TempError Value is True. Then Clear the Tempboard. Count + 1, Next loop
                    If TempError = True Then
                        CurrentIndex += 1
                        Continue Do
                    End If
                    'If TempSolved = True, Break the Loop and Set solved  = True. and Return the board. 
                    If TempSolved = True Then
                        Exit Do
                    End If
                    CurrentIndex += 1

                    Form1.Lstbx.Items.Add("Current Index:: " + CStr(CurrentIndex))

                Loop While CurrentIndex <= MaxCandidateIndex
                'END WHILE

                DeepClone(Board, Tempboard)

                If TempError = True Then
                    _Error = True
                    _Solved = False
                    Return Board
                End If

                If TempSolved = True Then
                    _Solved = True
                    Return Board
                End If

            End If
    End Function


End Class

Public Class ObjCell
	Public Value As Integer
    Public HasValueFromImport As Boolean
    Public DataCandidates As New ArrayList
	''NOTE ABOUT BOX LOCATION. THE X AND Y CO-ORDS ARE THE COLS AND ROWS RESPECTIVELY.
	''THE X And Y VALUES REPRESENT THE LOCATION Of THE FIRST CELL In THAT BOX
	''IF YOU WANT TO IDERATE THROUGH A BOX, IDERATE BY GOING FOR X TO X+2. SAME FOR Y
	Public BoxLocation As Point
	Public CellLocation As Point

    Public Sub New()
        HasValueFromImport = False
        Value = -1
        DataCandidates.Clear()
        DataCandidates.Capacity = 9
    End Sub


End Class