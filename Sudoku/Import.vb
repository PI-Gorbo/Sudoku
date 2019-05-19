Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Random
Public Class InputOutputGameboard
    Shared Function Import(Directory As String) As Array
        'Pull a board form a file and turn it into the Baseboard Array

        Dim BaseBoard(8, 8) As Integer
        Using reader As New StreamReader(GetRandomFile(Directory))

            For cols = 0 To 8
                For rows = 0 To 8
                    BaseBoard(cols, rows) = reader.ReadLine()
                Next
            Next
        End Using
        Return BaseBoard
        'Return BaseBoard

    End Function

    Private Shared Function GetRandomFile(FolderName As String) As String
        Static r As New Random
        Dim Files = New DirectoryInfo(FolderName).GetFiles()
        Return Convert.ToString(Files(r.Next(0, Files.Length)))
    End Function
End Class
