Imports Microsoft.VisualBasic

Public Class Database

    Dim Baseboard(8, 8) As Integer

    Public Sub New()
        'Import BaseBoard
        Baseboard = InputOutputGameboard.Import("C:\Users\Samn\source\repos\Sudoku\Sudoku\My Project\Boards")
        'Build Fullboard

        'Iterate through Cells and pass them to display

    End Sub

    Public Sub BuildPossilbeCandidates()

    End Sub


End Class

