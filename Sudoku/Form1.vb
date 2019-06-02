Imports System.IO

Public Class Form1
    Dim Game As Gameboard

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Game = New Gameboard

        AddHandler Keypad_1.Click, AddressOf Game.InputKeypad
        AddHandler Keypad_2.Click, AddressOf Game.InputKeypad
        AddHandler Keypad_3.Click, AddressOf Game.InputKeypad
        AddHandler Keypad_4.Click, AddressOf Game.InputKeypad
        AddHandler Keypad_5.Click, AddressOf Game.InputKeypad
        AddHandler Keypad_6.Click, AddressOf Game.InputKeypad
        AddHandler Keypad_7.Click, AddressOf Game.InputKeypad
        AddHandler Keypad_8.Click, AddressOf Game.InputKeypad
        AddHandler Keypad_9.Click, AddressOf Game.InputKeypad

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

End Class

'Dim Game As Gameboard
'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'    Game = New Gameboard(20, 20)
'AddHandler() Keypad_1.Click, AddressOf Game.Edit
'    AddHandler() Keypad_2.Click, AddressOf Game.Edit
'    AddHandler() Keypad_3.Click, AddressOf Game.Edit
'    AddHandler() Keypad_4.Click, AddressOf Game.Edit
'    AddHandler() Keypad_5.Click, AddressOf Game.Edit
'    AddHandler() Keypad_6.Click, AddressOf Game.Edit
'    AddHandler() Keypad_7.Click, AddressOf Game.Edit
'    AddHandler() Keypad_8.Click, AddressOf Game.Edit
'    AddHandler() Keypad_9.Click, AddressOf Game.Edit
'    Rad_Pencil.Checked = True
'End Sub

'Private Sub Btn_NewGame_Click(sender As Object, e As EventArgs) Handles Btn_NewGame.Click
'    Game.Import_New_Board()
'    Game.Update_Display()
'End Sub

'Private Sub Rad_Pencil_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_Pencil.CheckedChanged
'    Game.UpdateButtons()
'End Sub

'Private Sub Rad_Pen_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_Pen.CheckedChanged
'    Game.UpdateButtons()
'End Sub

'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'    Game.Match_DataCandidates_To_Candidates()
'End Sub

'Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
'    Game.ClearLabels()
'End Sub