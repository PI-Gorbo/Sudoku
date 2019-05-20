Imports System.IO

Public Class Form1
    Public Game As Gameboard
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Game = New Gameboard(40, 20)
        'InputOutputGameboard.Import("C:\Users\Samn\source\repos\Sudoku\Sudoku\My Project\Boards")  
    End Sub

    Private Sub Btn_NewGame_Click(sender As Object, e As EventArgs) Handles Btn_NewGame.Click
        Game.Import_NewBoard()
    End Sub
End Class

