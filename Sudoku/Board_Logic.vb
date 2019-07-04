Imports System.IO
Imports System.Threading

Public Class ObjCell

    Public Value As Integer
    Public HasValueFromImport As Boolean
    Public DataCandidates As New ArrayList
    Public Row As New ArrayList
    Public Column As New ArrayList
    Public Box As New ArrayList
    Public CellLocation As Point

    Public Sub New()
        HasValueFromImport = False
        Value = -1
        DataCandidates.Clear()
        DataCandidates.Capacity = 9

        Row.Clear()
        Row.Capacity = 9
        Column.Clear()
        Column.Capacity = 9
        Box.Clear()
        Box.Capacity = 9

    End Sub


End Class

Public Class Board

    Public Cells(8, 8) As ObjCell
    Public Rows(8) As ArrayList
    Public Columns(8) As ArrayList
    Public Box(2, 2) As ArrayList

    'Creates a board, and then adds the cells to each of the rows, cols and box. Also Gives the Cell its Location
    Public Sub New()

        Dim Box_rows As Integer = -1
        Dim Box_cols As Integer = -1

        For _rows = 0 To 8
            For _cols = 0 To 8

                'Creates a new cell
                Cells(_rows, _cols) = New ObjCell
                If IsNothing(Rows(_rows)) Then
                    Rows(_rows) = New ArrayList
                End If

                'Adds the cell to the right row
                Rows(_rows).Add(Cells(_rows, _cols))
                Cells(_rows, _cols).Row = Rows(_rows)

                If IsNothing(Columns(_cols)) Then
                    Columns(_cols) = New ArrayList
                End If

                'Adds the cell to the right column
                Columns(_cols).Add(Cells(_rows, _cols))
                Cells(_rows, _cols).Column = Columns(_cols)

                If _rows <= 2 Then

                    Box_rows = 0

                ElseIf _rows >= 3 And _rows <= 5 Then

                    Box_rows = 1

                ElseIf _rows >= 6 Then

                    Box_rows = 2

                End If

                If _cols <= 2 Then

                    Box_cols = 0

                ElseIf _cols >= 3 And _cols <= 5 Then

                    Box_cols = 1

                ElseIf _cols >= 6 Then

                    Box_cols = 2

                End If

                If IsNothing(Box(Box_rows, Box_cols)) Then

                    Box(Box_rows, Box_cols) = New ArrayList

                End If

                'Adds the cell to the correct box.
                Box(Box_rows, Box_cols).Add(Cells(_rows, _cols))
                Cells(_rows, _cols).Box = Box(Box_rows, Box_cols)

                Cells(_rows, _cols).CellLocation = New Point(_cols, _rows)

            Next
        Next

    End Sub

    'Creates a copy of a board from inputted board
    Public Sub New(OriginalBoard As Board)

        Dim Box_rows As Integer = -1
        Dim Box_cols As Integer = -1

        For _rows = 0 To 8
            For _cols = 0 To 8

                Cells(_rows, _cols) = New ObjCell
                Cells(_rows, _cols).Value = OriginalBoard.Cells(_rows, _cols).Value
                Cells(_rows, _cols).HasValueFromImport = OriginalBoard.Cells(_rows, _cols).HasValueFromImport

                For Each ele In OriginalBoard.Cells(_rows, _cols).DataCandidates
                    Cells(_rows, _cols).DataCandidates.Add(ele)
                Next

                Cells(_rows, _cols).CellLocation.X = OriginalBoard.Cells(_rows, _cols).CellLocation.X
                Cells(_rows, _cols).CellLocation.Y = OriginalBoard.Cells(_rows, _cols).CellLocation.Y

                If IsNothing(Rows(_rows)) Then
                    Rows(_rows) = New ArrayList
                End If

                'Adds the cell to the right row
                Rows(_rows).Add(Cells(_rows, _cols))
                Cells(_rows, _cols).Row = Rows(_rows)

                If IsNothing(Columns(_cols)) Then
                    Columns(_cols) = New ArrayList
                End If

                'Adds the cell to the right column
                Columns(_cols).Add(Cells(_rows, _cols))
                Cells(_rows, _cols).Column = Columns(_cols)

                If _rows <= 2 Then

                    Box_rows = 0

                ElseIf _rows >= 3 And _rows <= 5 Then

                    Box_rows = 1

                ElseIf _rows >= 6 Then

                    Box_rows = 2

                End If

                If _cols <= 2 Then

                    Box_cols = 0

                ElseIf _cols >= 3 And _cols <= 5 Then

                    Box_cols = 1

                ElseIf _cols >= 6 Then

                    Box_cols = 2

                End If

                If IsNothing(Box(Box_rows, Box_cols)) Then

                    Box(Box_rows, Box_cols) = New ArrayList

                End If

                'Adds the cell to the correct box.
                Box(Box_rows, Box_cols).Add(Cells(_rows, _cols))
                Cells(_rows, _cols).Box = Box(Box_rows, Box_cols)

            Next
        Next
    End Sub


End Class

Public Class BoardHandler

    Public Filelist As New ArrayList
    Public MainBoard As New Board
    Public SolvedBoard As Board
    Public DifficultyDirectories(5) As String
    Public BoardChosen As String

    Public Sub New()

        DifficultyDirectories(0) = "Boards\Easy"
        DifficultyDirectories(1) = "Boards\Medium"
        DifficultyDirectories(2) = "Boards\Hard"
        DifficultyDirectories(3) = "Boards\Evil"
        DifficultyDirectories(4) = "Boards\Custom"

    End Sub

    Public Sub NewBoard(ByVal Blank_Board As Boolean)


        If Blank_Board = False Then

            Dim Dr As New DirectoryInfo(DifficultyDirectories(Form1.DropDown_Difficulty.SelectedIndex))
            Filelist.Clear()
            For Each file In Dr.GetFiles()
                Filelist.Add(file)
            Next

            Dim r As New Random
            Dim x = r.Next(0, Filelist.Count)
            Dim f = Convert.ToString(Filelist(x).Fullname)
            BoardChosen = Filelist(x).ToString
            ''TODO --> REMOVES BOARDS ALREADY SEEN FROM LIST. MAYBE A NOTIFICATION TO THE USER IS REQ'D

            Using reader As New StreamReader(f)
                Dim line As String

                For _rows = 0 To 8
                    line = reader.ReadLine
                    For _cols = 0 To 8

                        If IsNothing(MainBoard.Cells(_rows, _cols)) = True Then
                            MainBoard.Cells(_rows, _cols) = New ObjCell
                        Else
                            With MainBoard.Cells(_rows, _cols)
                                .HasValueFromImport = False
                                .Value = -1
                                .DataCandidates.Clear()
                            End With
                        End If

                        With MainBoard.Cells(_rows, _cols)

                            If line(_cols) = "0" Then
                                For i = 1 To 9
                                    .DataCandidates.Add(i)
                                    .Value = -1
                                Next
                            Else
                                .Value = Integer.Parse(line(_cols))
                                .HasValueFromImport = True
                            End If

                        End With
                    Next
                Next
            End Using

        Else
            For _rows = 0 To 8
                For _cols = 0 To 8

                    If IsNothing(MainBoard.Cells(_rows, _cols)) = True Then
                        MainBoard.Cells(_rows, _cols) = New ObjCell
                    Else
                        With MainBoard.Cells(_rows, _cols)
                            .HasValueFromImport = False
                            .Value = -1
                            .DataCandidates.Clear()
                        End With
                    End If

                    With MainBoard.Cells(_rows, _cols)

                        For i = 1 To 9
                            .DataCandidates.Add(i)
                            .Value = -1
                        Next
                    End With
                Next
            Next
        End If

        SolvedBoard = New Board(MainBoard)

        Dim Solved As Boolean = False
        Dim _Error As Boolean = False

        BruteForce(SolvedBoard, Solved, _Error)
        If _Error = True Then
            Form1.DebugBox.Items.Add("Error with loaded board.")
        Else
            Form1.DebugBox.Items.Clear()
            Form1.DebugBox.Items.Add("Board Solved in Background!")
        End If

    End Sub

    '___________________________________________ Candidate Calculations ___________________________________________'

    'Removes Candidates, Through Subtraction for an inputted board.
    Public Sub CalculateCandidates(ByRef Board As Board, ByRef Continue_Calculating As Boolean, ByRef Error_Detected As Boolean)

        'Form1.DebugBox.Items.Add(" ")
        'Form1.DebugBox.Items.Add("Calculating Candidates")
        'Form1.DebugBox.Items.Add(" ")

        Continue_Calculating = False
        Error_Detected = False
        Dim Val As Integer = -1

        For rows = 0 To 8
            For cols = 0 To 8

                If (Board.Cells(rows, cols).Value) <> -1 Then

                    Val = Board.Cells(rows, cols).Value

                    For Each ele As ObjCell In Board.Cells(rows, cols).Row
                        ele.DataCandidates.Remove(Val)

                        If ele.DataCandidates.Count = 1 Then
                            Continue_Calculating = True
                            'TODO --> Debug Statement
                        End If

                        If ele.DataCandidates.Count = 0 And ele.Value = -1 Then
                            Error_Detected = True
                        End If

                    Next

                    For Each ele As ObjCell In Board.Cells(rows, cols).Column
                        ele.DataCandidates.Remove(Val)

                        If ele.DataCandidates.Count = 1 Then
                            Continue_Calculating = True
                            'TODO --> Debug Statement
                        End If

                        If ele.DataCandidates.Count = 0 And ele.Value = -1 Then
                            Error_Detected = True
                        End If

                    Next

                    For Each ele As ObjCell In Board.Cells(rows, cols).Box
                        ele.DataCandidates.Remove(Val)

                        If ele.DataCandidates.Count = 1 Then
                            Continue_Calculating = True
                            'TODO --> Debug Statement
                        End If

                        If ele.DataCandidates.Count = 0 And ele.Value = -1 Then
                            Error_Detected = True
                        End If

                    Next

                End If
            Next
        Next

    End Sub

    'Finds any Cells that have a single candidate, Converts the cell's candidate into its value
    Public Sub Convert_To_Values(ByRef Board As Board)

        For rows = 0 To 8
            For cols = 0 To 8
                If Board.Cells(rows, cols).DataCandidates.Count = 1 Then

                    ''TODO --> DEBUG STATEMENT

                    Board.Cells(rows, cols).Value = Board.Cells(rows, cols).DataCandidates(0)
                    Board.Cells(rows, cols).DataCandidates.Clear()
                End If
            Next
        Next

    End Sub

    'Continually subtractively calculates candidates untill the board is either solved, or no more progress can be made.
    Public Sub ResolveBoard(ByRef Board As Board, ByRef Board_Solved As Boolean, ByRef Error_Dectected As Boolean)

        Board_Solved = False
        Error_Dectected = False

        Dim _Continue As Boolean = True
        While _Continue = True

            CalculateCandidates(Board, _Continue, Error_Dectected)
            __CalculateIsolatedCandidates(Board, _Continue)
            Convert_To_Values(Board)

            If Error_Dectected = True Then
                Form1.DebugBox.Items.Add("ERROR!")
                Exit Sub
            End If

            If isBoardSolved(Board) = True Then
                Form1.DebugBox.Items.Add("Exited Early")
                Board_Solved = isBoardSolved(Board)
                Exit Sub
            End If

        End While

        Board_Solved = isBoardSolved(Board)

    End Sub

    'Finds any unique candidates in each row, column and box. Then sets that 
    Public Sub __CalculateIsolatedCandidates(ByRef Board As Board, ByRef Continue_Solving As Boolean)

        'Goes through each row in the inputted board
        For rowcount = 0 To 8

            'Goes through each possible number
            For num = 1 To 9
                'If the number is a value of the row, then exit
                For Each ele As ObjCell In Board.Rows(rowcount)

                    If ele.Value = num Then
                        Exit For
                    End If

                Next

                Dim tempcount As Integer = 0
                Dim tempcell As ObjCell

                'Checks if there is exactly 1 occourance of that candidate in the row, exits if there is more than 1
                For Each ele As ObjCell In Board.Rows(rowcount)

                    If ele.DataCandidates.Contains(num) Then
                        If tempcount > 1 Then
                            tempcell = Nothing
                            Exit For
                        Else
                            tempcell = ele
                            tempcount += 1
                        End If
                    End If

                Next
                'If there is exactly 1 occourance of the candidate in that row, then make that candidate the value of that cell.
                If tempcount = 1 Then

                    tempcell.DataCandidates.Clear()
                    tempcell.DataCandidates.Add(num)
                    Continue_Solving = True
                End If
            Next
        Next

        For colcount = 0 To 8

            'Goes through each possible number
            For num = 1 To 9
                'If the number is a value of the row, then exit
                For Each ele As ObjCell In Board.Columns(colcount)

                    If ele.Value = num Then
                        Exit For
                    End If

                Next

                Dim tempcount As Integer = 0
                Dim tempcell As ObjCell

                'Checks if there is exactly 1 occourance of that candidate in the row, exits if there is more than 1
                For Each ele As ObjCell In Board.Columns(colcount)

                    If ele.DataCandidates.Contains(num) Then
                        If tempcount > 1 Then
                            tempcell = Nothing
                            Exit For
                        Else
                            tempcell = ele
                            tempcount += 1
                        End If
                    End If

                Next
                'If there is exactly 1 occourance of the candidate in that row, then make that candidate the value of that cell.
                If tempcount = 1 Then
                    tempcell.DataCandidates.Clear()
                    tempcell.DataCandidates.Add(num)
                End If
            Next
        Next

        For BoxRows = 0 To 2
            For BoxCols = 0 To 2

                For num = 1 To 9
                    'If the number is a value of the row, then exit
                    For Each ele As ObjCell In Board.Box(BoxRows, BoxCols)

                        If ele.Value = num Then
                            Exit For
                        End If

                    Next

                    Dim tempcount As Integer = 0
                    Dim tempcell As ObjCell

                    'Checks if there is exactly 1 occourance of that candidate in the row, exits if there is more than 1
                    For Each ele As ObjCell In Board.Box(BoxRows, BoxCols)

                        If ele.DataCandidates.Contains(num) Then
                            If tempcount > 1 Then
                                tempcell = Nothing
                                Exit For
                            Else
                                tempcell = ele
                                tempcount += 1
                            End If
                        End If

                    Next
                    'If there is exactly 1 occourance of the candidate in that row, then make that candidate the value of that cell.
                    If tempcount = 1 Then
                        tempcell.DataCandidates.Clear()
                        tempcell.DataCandidates.Add(num)
                    End If
                Next

            Next
        Next

    End Sub

    '_______________________________________________ Board Validity _______________________________________________'

    'Sweeps the board to check if the board has Solved.
    Public Function isBoardSolved(Board As Board)

        Form1.DebugBox.Items.Add("")
        Form1.DebugBox.Items.Add("CHECKING SOLVED [...]")
        Form1.DebugBox.Items.Add("")

        For rows = 0 To 8
            For cols = 0 To 8

                For Each ele As ObjCell In Board.Cells(rows, cols).Row

                    If ele.Equals(Board.Cells(rows, cols)) = True Then
                        Continue For
                    End If

                    If ele.Value = Board.Cells(rows, cols).Value Or ele.Value = -1 Then

                        ''TODO --> DEBUG STATEMENT
                        Return False
                    End If

                Next

                For Each ele As ObjCell In Board.Cells(rows, cols).Column

                    If ele.Equals(Board.Cells(rows, cols)) = True Then
                        Continue For
                    End If

                    If ele.Value = Board.Cells(rows, cols).Value Or ele.Value = -1 Then

                        ''TODO --> DEBUG STATEMENT
                        Return False
                    End If

                Next

                For Each ele As ObjCell In Board.Cells(rows, cols).Box

                    If ele.Equals(Board.Cells(rows, cols)) = True Then
                        Continue For
                    End If

                    If ele.Value = Board.Cells(rows, cols).Value Or ele.Value = -1 Then

                        ''TODO --> DEBUG STATEMENT
                        Return False
                    End If

                Next
            Next
        Next

        Form1.DebugBox.Items.Add("TRUE!")

        Return True

    End Function

    'Returns True of the Board inputted has no empty candidate Cells, and no Duplicate values 
    Public Function isBoardValid(Board As Board)

        Form1.DebugBox.Items.Add(" ")
        Form1.DebugBox.Items.Add("CHECKING VALIDITY [...]")
        Form1.DebugBox.Items.Add(" ")

        Dim NumberOfClues As Integer = 0

        For rows = 0 To 8
            For cols = 0 To 8

                If Board.Cells(rows, cols).Value <> -1 Then
                    NumberOfClues += 1
                End If

                'Checks if there are no empty candidates when the cell does not have a value
                If Board.Cells(rows, cols).DataCandidates.Count = 0 And Board.Cells(rows, cols).Value = -1 Then
                    ''TODO --> DEBUG STATEMENT
                    Return False
                End If

                For Each ele As ObjCell In Board.Cells(rows, cols).Row
                    If ele.Value = Board.Cells(rows, cols).Value And Board.Cells(rows, cols).Value <> -1 And ele.Equals(Board.Cells(rows, cols)) = False Then
                        ''DEBUG STATEMENT
                        Return False
                    End If
                Next

                For Each ele As ObjCell In Board.Cells(rows, cols).Column
                    If ele.Value = Board.Cells(rows, cols).Value And Board.Cells(rows, cols).Value <> -1 And ele.Equals(Board.Cells(rows, cols)) = False Then
                        ''DEBUG STATEMENT
                        Return False
                    End If
                Next

                For Each ele As ObjCell In Board.Cells(rows, cols).Box
                    If ele.Value = Board.Cells(rows, cols).Value And Board.Cells(rows, cols).Value <> -1 And ele.Equals(Board.Cells(rows, cols)) = False Then
                        ''DEBUG STATEMENT
                        Return False
                    End If
                Next

            Next
        Next

        If NumberOfClues < 17 Then
            Return False
        End If

        ''TODO --> DEBUG STATEMENT (BOARD COMPLETE)
        Return True

    End Function

    '______________________________________________ Board AutoSolving _____________________________________________'

    Function BruteForce(ByRef Board As Board, ByRef _Solved As Boolean, ByRef _Error As Boolean)

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
            Dim Tempboard As Board
            Dim MaxCandidateIndex As Integer = -1
            Dim CurrentIndex As Integer = -1

            'At this point it is assumed that the board is valid and unsolved. 
            'Candidates has been calculated, and therefore, we know that one of the candidates must be the correct one.


            'Find a cell without a value. This cell will have 2 or more candidates and we know that one of them must be correct.
            'Make this cell the "Selected Cell"
            For rows = 0 To 8
                For cols = 0 To 8

                    If Board.Cells(rows, cols).Value = -1 Then
                        SelectedLabelLocation.X = cols
                        SelectedLabelLocation.Y = rows
                        Exit For
                    End If
                Next
                If SelectedLabelLocation.X <> -1 And SelectedLabelLocation.Y <> -1 Then
                    Exit For
                End If
            Next

            ''TODO --> DEBUG STATEMENT

            If SelectedLabelLocation.X = -1 And SelectedLabelLocation.Y = -1 Then
                _Error = True
                _Solved = False
                Return Board
            End If


            'Get the number of Candidates in the Selected Cell. Make a count starting at 0 
            MaxCandidateIndex = Board.Cells(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates.Count - 1
            'Form1.DebugBox.Items.Add(MaxCandidateIndex)
            CurrentIndex = 0

            'DO:
            Do
                TempSolved = False
                TempError = False

                'Make a TempBoard that is the same as the orignial board. 
                Tempboard = New Board(Board)

                'Choose the (count) candidate of the Selected Cell and Make it the value of the cell. 

                ''TODO --> DEBUG STATEMENT ABOUT WHICH CELL VALUE HAS BEEN CHOSEN

                Tempboard.Cells(SelectedLabelLocation.Y, SelectedLabelLocation.X).Value = Tempboard.Cells(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates(CurrentIndex)
                Tempboard.Cells(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates.Clear()

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

                'Form1.DebugBox.Items.Add("Current Index:: " + CStr(CurrentIndex))

            Loop While CurrentIndex <= MaxCandidateIndex
            'END WHILE

            Board = New Board(Tempboard)

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

    'Public Sub BruteForce_Sub(ByRef SolvedStruct As ThreadingStruct)
    '    SolvedStruct._Error = False
    '    SolvedStruct.Solved = False

    '    'Check if Board is Valid. If Invalid, escape and set Error to True. 
    '    If isBoardValid(SolvedStruct.SolvedBoard) = False Then
    '        SolvedStruct._Error = True
    '        SolvedStruct.SolvedBoard = New Board(SolvedStruct.OiginalBoard)
    '        Exit Sub
    '    End If

    '    'Eliminate Candidates 
    '    ResolveBoard(SolvedStruct.SolvedBoard, SolvedStruct.Solved, SolvedStruct._Error)

    '    'If _Error is true after Elimiating Candidates, Escape and Set Error To True
    '    'Check if the Board is Solved, If True, Return the board and set _Solved to True. 
    '    If SolvedStruct._Error = True Or SolvedStruct.Solved = True Then
    '        Exit Sub
    '    End If

    '    '_________________________________'

    '    If Not SolvedStruct.Solved Then
    '        Dim TempSolved As Boolean = False
    '        Dim TempError As Boolean = False
    '        Dim SelectedLabelLocation As New Point(-1, -1)
    '        Dim Tempboard As Board
    '        Dim MaxCandidateIndex As Integer = -1
    '        Dim CurrentIndex As Integer = -1

    '        'At this point it is assumed that the board is valid and unsolved. 
    '        'Candidates has been calculated, and therefore, we know that one of the candidates must be the correct one.


    '        'Find a cell without a value. This cell will have 2 or more candidates and we know that one of them must be correct.
    '        'Make this cell the "Selected Cell"
    '        For rows = 0 To 8
    '            For cols = 0 To 8

    '                If SolvedStruct.OiginalBoard.Cells(rows, cols).Value = -1 Then
    '                    SelectedLabelLocation.X = cols
    '                    SelectedLabelLocation.Y = rows
    '                    Exit For
    '                End If
    '            Next
    '            If SelectedLabelLocation.X <> -1 And SelectedLabelLocation.Y <> -1 Then
    '                Exit For
    '            End If
    '        Next

    '        ''TODO --> DEBUG STATEMENT

    '        If SelectedLabelLocation.X = -1 And SelectedLabelLocation.Y = -1 Then
    '            SolvedStruct._Error = True
    '            SolvedStruct.Solved = False
    '            SolvedBoard = New Board(SolvedStruct.OiginalBoard)
    '            Exit Sub
    '        End If


    '        'Get the number of Candidates in the Selected Cell. Make a count starting at 0 
    '        MaxCandidateIndex = SolvedStruct.SolvedBoard.Cells(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates.Count - 1
    '        'Form1.DebugBox.Items.Add(MaxCandidateIndex)
    '        CurrentIndex = 0

    '        'DO:
    '        Do
    '            TempSolved = False
    '            TempError = False

    '            'Make a TempBoard that is the same as the orignial board. 
    '            Tempboard = New Board(SolvedStruct.SolvedBoard)

    '            'Choose the (count) candidate of the Selected Cell and Make it the value of the cell. 

    '            ''TODO --> DEBUG STATEMENT ABOUT WHICH CELL VALUE HAS BEEN CHOSEN

    '            Tempboard.Cells(SelectedLabelLocation.Y, SelectedLabelLocation.X).Value = Tempboard.Cells(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates(CurrentIndex)
    '            Tempboard.Cells(SelectedLabelLocation.Y, SelectedLabelLocation.X).DataCandidates.Clear()

    '            'Bruteforce the board
    '            BruteForce(Tempboard, TempSolved, TempError)

    '            'Check if the TempError Value is True. Then Clear the Tempboard. Count + 1, Next loop
    '            If TempError = True Then
    '                CurrentIndex += 1
    '                Continue Do
    '            End If
    '            'If TempSolved = True, Break the Loop and Set solved  = True. and Return the board. 
    '            If TempSolved = True Then
    '                Exit Do
    '            End If
    '            CurrentIndex += 1

    '            'Form1.DebugBox.Items.Add("Current Index:: " + CStr(CurrentIndex))

    '        Loop While CurrentIndex <= MaxCandidateIndex
    '        'END WHILE

    '        'THIS MAY BE UNESSICARY
    '        SolvedStruct.SolvedBoard = New Board(Tempboard)

    '        If TempError = True Then
    '            SolvedStruct._Error = True
    '            SolvedStruct.Solved = False
    '            Exit Sub
    '        End If

    '        If TempSolved = True Then
    '            SolvedStruct.Solved = True
    '            Exit Sub
    '        End If

    '    End If
    'End Sub

    '____________________________________________ Debug and Manual Entry ___________________________________________'

    'Import manually entered board
    Public Sub ManualBoardImport(Cells(,) As Display_Cells, ByRef valid As Boolean)

        For _rows = 0 To 8
            For _cols = 0 To 8
                If Cells(_rows, _cols).HasValueLabel Then

                    MainBoard.Cells(_rows, _cols).Value = CInt(Cells(_rows, _cols).ValueLabel.Text)
                    MainBoard.Cells(_rows, _cols).DataCandidates.Clear()
                    MainBoard.Cells(_rows, _cols).HasValueFromImport = True

                End If
            Next
        Next

        valid = isBoardValid(MainBoard)
    End Sub

    'Save current board as new file
    Public Sub SaveCurrentBoard()

        Dim Currenttime = DateTime.Now.ToString("dd_MM_yyyy__ss_mm_HH")
        Dim filepath = My.Application.Info.DirectoryPath + "\Boards\Custom\" + Currenttime + ".txt"

        File.Create(filepath).Dispose()
        Dim objwriter As New StreamWriter(filepath)
        'file = My.Computer.FileSystem.OpenTextFileWriter("Boards\Custom\" + Currenttime, False)

        For rows = 0 To 8
            Dim line As String = ""
            For cols = 0 To 8

                If MainBoard.Cells(rows, cols).Value <> -1 Then

                    line += CStr(MainBoard.Cells(rows, cols).Value)
                Else

                    line += "0"

                End If
            Next
            objwriter.WriteLine(line)

        Next

        objwriter.Close()
    End Sub

    'Prints the candiates in a certain cell
    Public Sub PrintCandidates(Board As Board)
        Dim str As String
        For rows = 0 To 8
            For cols = 0 To 8

                str = "[ "
                For Each ele In Board.Cells(rows, cols).DataCandidates
                    str = str + Convert.ToString(ele) + ","
                Next
                str += "]"
                Form1.DebugBox.Items.Add("[ " + Convert.ToString(rows) + " " + Convert.ToString(cols) + " ] -->" + str)

            Next
        Next


    End Sub

End Class