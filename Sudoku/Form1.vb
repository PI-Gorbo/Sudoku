Imports System.IO

Public Class Form1

    Dim Game As Gameboard
    Dim ValidForEntry As Boolean

    'On form creation...
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Game = New Gameboard

        AddHandler Keypad_1.Click, AddressOf Game.Keypad_Input
        AddHandler Keypad_2.Click, AddressOf Game.Keypad_Input
        AddHandler Keypad_3.Click, AddressOf Game.Keypad_Input
        AddHandler Keypad_4.Click, AddressOf Game.Keypad_Input
        AddHandler Keypad_5.Click, AddressOf Game.Keypad_Input
        AddHandler Keypad_6.Click, AddressOf Game.Keypad_Input
        AddHandler Keypad_7.Click, AddressOf Game.Keypad_Input
        AddHandler Keypad_8.Click, AddressOf Game.Keypad_Input
        AddHandler Keypad_9.Click, AddressOf Game.Keypad_Input

        Game.Keypads.Add(Keypad_1)
        Game.Keypads.Add(Keypad_2)
        Game.Keypads.Add(Keypad_3)
        Game.Keypads.Add(Keypad_4)
        Game.Keypads.Add(Keypad_5)
        Game.Keypads.Add(Keypad_6)
        Game.Keypads.Add(Keypad_7)
        Game.Keypads.Add(Keypad_8)
        Game.Keypads.Add(Keypad_9)

        Rad_Pencil.Checked = True
        KeyPreview = True
        BeginningState()
    End Sub

    'Creates a new Game
    Private Sub Btn_NewGame_Click(sender As Object, e As EventArgs) Handles Btn_NewGame.Click
        NormalPlay()
        Game.NewGame()
    End Sub

    'Updates which keypads are highlighted when the Pen option changes
    Private Sub Rad_Pen_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_Pen.CheckedChanged
        Game.UpdateKeypads()
    End Sub

    'Solves the board
    Private Sub SolveBoard(sender As Object, e As EventArgs) Handles Btn_SolveBoard.Click

        Gameboard.UpdateDisplayValues(Game.Cells, Game.Gameboard.SolvedBoard.Cells)
        Game.UpdateLabels(Game.Cells, Game.Gameboard.SolvedBoard.Cells)

    End Sub

    'Updates the board when the difficulty changes
    Private Sub DropDown_Difficulty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDown_Difficulty.SelectedIndexChanged
        NormalPlay()

        If Btn_NewGame.Enabled = False Then
            Btn_NewGame.Enabled = True
        End If

        Group_Controls.Enabled = True

        Game.NewGame()
    End Sub

    'Primes board for manual entry
    Private Sub Btn_ManualEntry_Click(sender As Object, e As EventArgs) Handles Btn_ManualEntry.Click

        Game.PrimeForManualEntry()
        Btn_FinishEntry.Enabled = True
        ManualEntry()



    End Sub

    'Finishes manual entry
    Private Sub Btn_FinishEntry_Click(sender As Object, e As EventArgs) Handles Btn_FinishEntry.Click

        Game.FinaliseManualEntry()

    End Sub

    'Changes the state of the board so certain controls are enabled or disabled
    Public Sub BeginningState()

        ValidForEntry = False
        Btn_NewGame.Enabled = False
        Group_Controls.Enabled = False
        Group_Solving.Enabled = False
        Btn_FinishEntry.Enabled = False
        Lbl_ManualEntryWarning.Visible = False
        Group_settings.Enabled = False
        Check_CandidateAltert.Enabled = True
        Check_CandidateAltert.Checked = False

    End Sub

    Public Sub NormalPlay()

        ValidForEntry = True
        Group_Controls.Enabled = True
        Group_Solving.Enabled = True
        Btn_SolveBoard.Enabled = True
        Rad_Pencil.Enabled = True
        Btn_PrelimSolve.Enabled = True
        Btn_FinishEntry.Enabled = False
        DropDown_Difficulty.Enabled = True
        Lbl_ManualEntryWarning.Visible = False
        Group_settings.Enabled = True
        Check_CandidateAltert.Enabled = True
        Check_CandidateAltert.Checked = False


    End Sub

    Public Sub ManualEntry()

        ValidForEntry = True
        Group_Controls.Enabled = True
        Group_Solving.Enabled = False
        Lbl_ManualEntryWarning.Visible = True
        Rad_Pencil.Enabled = False
        Btn_NewGame.Enabled = False
        DropDown_Difficulty.Enabled = False
        Rad_Pen.Checked = True
        Group_settings.Enabled = False
        Check_CandidateAltert.Enabled = True
        Check_CandidateAltert.Checked = False

    End Sub

    'handles Form Keypresses and changes values accordingly
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If ValidForEntry = True Then
            If IsNothing(Game.LastClicked) = False Then

                If e.KeyCode >= 49 And e.KeyCode <= 57 Then

                    Dim val As Integer

                    If e.KeyCode = 49 Then
                        val = 1
                    ElseIf e.KeyCode = 50 Then
                        val = 2
                    ElseIf e.KeyCode = 51 Then
                        val = 3
                    ElseIf e.KeyCode = 52 Then
                        val = 4
                    ElseIf e.KeyCode = 53 Then
                        val = 5
                    ElseIf e.KeyCode = 54 Then
                        val = 6
                    ElseIf e.KeyCode = 55 Then
                        val = 7
                    ElseIf e.KeyCode = 56 Then
                        val = 8
                    ElseIf e.KeyCode = 57 Then
                        val = 9

                    End If

                    Game.InputIntepreter(val)

                End If
            End If
        End If
    End Sub

    'Does only the initial prelimiary reductions (subtraction and isolated candidates)
    Private Sub PrelimSolve(sender As Object, e As EventArgs) Handles Btn_PrelimSolve.Click

        Game.Gameboard.CalculateCandidates(Game.Gameboard.MainBoard, vbNull, vbNull)
        Game.Gameboard.__CalculateIsolatedCandidates(Game.Gameboard.MainBoard, vbNull)
        Game.Gameboard.Convert_To_Values(Game.Gameboard.MainBoard)
        Gameboard.UpdateDisplayValues(Game.Cells, Game.Gameboard.MainBoard.Cells)
        Game.UpdateLabels(Game.Cells, Game.Gameboard.MainBoard.Cells)

    End Sub

    'Debugs Candidates
    Private Sub Btn_Debug_Click_1(sender As Object, e As EventArgs) Handles Btn_Debug.Click

        DebugBox.Items.Clear()
        Game.Gameboard.PrintCandidates(Game.Gameboard.MainBoard)

    End Sub

    'Changes the Highlight removed candidates checked button


    Private Sub Check_Medusa_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Medusa.CheckedChanged
        Check_CandidateHighlighting.Checked = False

        For Each ele As Button In Game.Keypads
            ele.BackColor = Color.White
        Next

        Game.UpdateKeypads()


    End Sub

    Private Sub Check_CandidateHighlighting_CheckedChanged(sender As Object, e As EventArgs) Handles Check_CandidateHighlighting.CheckedChanged
        Check_Medusa.Checked = False

        For Each ele As Button In Game.Keypads
            ele.BackColor = Color.White
        Next

        Game.UpdateKeypads()
    End Sub

End Class
