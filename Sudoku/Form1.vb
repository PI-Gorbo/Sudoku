Imports System.IO

Public Class Form1
    Dim Game As Gameboard

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

    End Sub

    Private Sub Btn_NewGame_Click(sender As Object, e As EventArgs) Handles Btn_NewGame.Click

        Game.NewGame()

    End Sub

    Private Sub Rad_Pen_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_Pen.CheckedChanged
        Game.UpdateKeypads()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Btn_SolveBoard.Click

        DebugBox.Items.Clear()

        Dim _sol, _err As Boolean
        _sol = False
        _err = False
        Dim TempBoard As Board
        TempBoard = New Board(Game.Gameboard.MainBoard)


        Game.Gameboard.BruteForce(TempBoard, _sol, _err)
        If _err = True Then
            MsgBox("Error with inputted board. : " + Game.Gameboard.BoardChosen)
        Else

        End If
        Gameboard.UpdateDisplayValues(Game.Cells, TempBoard.Cells)
        Game.UpdateLabels(Game.Cells, TempBoard.Cells)


    End Sub

    Private Sub DropDown_Difficulty_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDown_Difficulty.SelectedIndexChanged

        If Btn_NewGame.Enabled = False Then
            Btn_NewGame.Enabled = True
        End If

        Group_Controls.Enabled = True

        Game.NewGame()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Game.PrimeForManualEntry()
        Btn_FinishEntry.Enabled = True
        ManualEntry()



    End Sub

    Private Sub Btn_FinishEntry_Click(sender As Object, e As EventArgs) Handles Btn_FinishEntry.Click

        Game.FinaliseManualEntry()

    End Sub

    Public Sub BeginningState()

        Btn_NewGame.Enabled = False
        Group_Controls.Enabled = False
        Btn_FinishEntry.Enabled = False
        Lbl_ManualEntryWarning.Visible = False

    End Sub

    Public Sub NormalPlay()

        Group_Controls.Enabled = True
        Btn_SolveBoard.Enabled = True
        Rad_Pencil.Enabled = True
        Btn_Debug.Enabled = True
        Btn_FinishEntry.Enabled = False
        DropDown_Difficulty.Enabled = True
        Lbl_ManualEntryWarning.Visible = False

    End Sub

    Public Sub ManualEntry()

        Group_Controls.Enabled = True
        Btn_SolveBoard.Enabled = False
        Btn_Debug.Enabled = False
        Lbl_ManualEntryWarning.Visible = True
        Rad_Pencil.Enabled = False
        Btn_NewGame.Enabled = False
        DropDown_Difficulty.Enabled = False
        Rad_Pen.Checked = True


    End Sub

End Class
