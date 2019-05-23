Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Game As New Gameboard(20, 20)
        Rad_Remove.Checked = True
        Game.Import_New_Board()
        Game.Update_Display()
    End Sub


End Class

