﻿Imports System.IO

Public Class Form1
    Dim Game As Gameboard
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Game = New Gameboard(20, 20)
        AddHandler Keypad_1.Click, AddressOf Game.Edit
        AddHandler Keypad_2.Click, AddressOf Game.Edit
        AddHandler Keypad_3.Click, AddressOf Game.Edit
        AddHandler Keypad_4.Click, AddressOf Game.Edit
        AddHandler Keypad_5.Click, AddressOf Game.Edit
        AddHandler Keypad_6.Click, AddressOf Game.Edit
        AddHandler Keypad_7.Click, AddressOf Game.Edit
        AddHandler Keypad_8.Click, AddressOf Game.Edit
        AddHandler Keypad_9.Click, AddressOf Game.Edit
        Rad_Pencil.Checked = True
    End Sub

    Private Sub Btn_NewGame_Click(sender As Object, e As EventArgs) Handles Btn_NewGame.Click
        Game.Import_New_Board()
        Game.Update_Display()
    End Sub

    Private Sub Rad_Pencil_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_Pencil.CheckedChanged
        Game.UpdateButtons()
    End Sub

    Private Sub Rad_Pen_CheckedChanged(sender As Object, e As EventArgs) Handles Rad_Pen.CheckedChanged
        Game.UpdateButtons()
    End Sub

    Private Sub Lstbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lstbx.SelectedIndexChanged

    End Sub
End Class

