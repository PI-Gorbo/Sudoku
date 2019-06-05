﻿Imports System.IO

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ObjBoard.CalculateCandidates(Game.Board.BaseBoardCells)
        For rows = 0 To 8
            For cols = 0 To 8
                Game.Cells(rows, cols).DisplayCandidates = Game.Board.BaseBoardCells(rows, cols).DataCandidates.Clone()
                Game.UpdateLabels(Game.Cells(rows, cols), 10, vbNull)
            Next
        Next

        Game.UpdateKeypads()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Lstbx.Items.Clear()

        For rows = 0 To 8
            For cols = 0 To 8
                Game.Board.PrintCandidates(Game.Board.BaseBoardCells(rows, cols))
            Next
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim X As Boolean = False
        Game.Board.Buteforce(Game.Board.BaseBoardCells, X)
        'For rows = 0 To 8
        '    For cols = 0 To 8
        '        Game.Cells(rows, cols).DisplayCandidates = Game.Board.BaseBoardCells(rows, cols).DataCandidates.Clone()
        '        Game.UpdateLabels(Game.Cells(rows, cols), 10, vbNull)
        '    Next
        'Next
        'Lstbx.Items.Clear()
        'Lstbx.Items.Add(Game.Board.BoardSolved(Game.Board.BaseBoardCells))
    End Sub
End Class
