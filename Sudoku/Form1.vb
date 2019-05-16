Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Game As GameBoard = New GameBoard(20, 20)
        Game.Boxes(2, 1).Cells(1, 1).Candidates(1, 1).BackColor = Color.White
        Game.Boxes(2, 1).Cells(1, 1).Candidates(1, 1).Text = "4"
    End Sub


End Class

Class GameBoard
    '_________________________________________'
    ''A BIT OF TERMONOLOGY''
    'The gameboard refers to the whole of the Sudoku board
    'The Gameboard consists of 9 Boxes. 3*3
    'Each Box has 9 Cells in it
    'Eeach Cell can have a max of 9 candidates - represented by 9 boxes
    '________________________________________'

    Dim OriginX, OriginY As Integer

    Public Shared CANDIDATE_SIZEpx As Integer = 14
    Public Shared CANDIDATE_PADDINGpx As Integer = 4

    Public Shared TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
    Public Shared CELL_PADDINGpx As Integer = 12

    Public Shared TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
    Public Shared BOX_PADDINGpx As Integer = 20

    Public Shared GAME_SIZEpx = (3 * TOTAL_BOX_SIZEpx) + (2 * BOX_PADDINGpx)
    Public Shared LINE_WIDTH As Integer = 5

    Public Boxes(2, 2) As Box

    Public Sub New(Ox As Integer, Oy As Integer)
        OriginX = Ox
        OriginY = Oy
        CreateGameBoard()
        Form1.Size = New Size(OriginX + (GAME_SIZEpx + 40), OriginY + (GAME_SIZEpx + 60))
    End Sub

    Private Sub CreateGameBoard()
        For CountX = 0 To 2
            For CountY = 0 To 2
                Boxes(CountX, CountY) = New Box(OriginX + (CountX * (TOTAL_BOX_SIZEpx + BOX_PADDINGpx)), OriginY + (CountY * (TOTAL_BOX_SIZEpx + BOX_PADDINGpx)))
            Next
        Next

        'Create Lines in-between different boxes.
        Dim Line_Vert_1, Line_Vert_2, Line_Hor_1, Line_Hor_2 As New Label

        With Line_Vert_1
            .Size = New Size(LINE_WIDTH, GAME_SIZEpx)
            .Location = New Drawing.Point(OriginX + (TOTAL_BOX_SIZEpx + BOX_PADDINGpx / 2 - LINE_WIDTH / 2), OriginY)
            .BackColor = Color.Black
        End With
        Form1.Controls.Add(Line_Vert_1)

        With Line_Vert_2
            .Size = New Size(LINE_WIDTH, GAME_SIZEpx)
            .Location = New Drawing.Point(OriginX + (TOTAL_BOX_SIZEpx * 2 + BOX_PADDINGpx * 1.5 - LINE_WIDTH / 2), OriginY)
            .BackColor = Color.Black
        End With
        Form1.Controls.Add(Line_Vert_2)

        With Line_Hor_1
            .Size = New Size(GAME_SIZEpx, LINE_WIDTH)
            .Location = New Drawing.Point(OriginX, OriginY + (TOTAL_BOX_SIZEpx + BOX_PADDINGpx / 2 - LINE_WIDTH / 2))
            .BackColor = Color.Black
        End With
        Form1.Controls.Add(Line_Hor_1)

        With Line_Hor_2
            .Size = New Size(GAME_SIZEpx, LINE_WIDTH)
            .Location = New Drawing.Point(OriginX, OriginY + (TOTAL_BOX_SIZEpx * 2 + BOX_PADDINGpx * 1.5 - LINE_WIDTH / 2))
            .BackColor = Color.Black
        End With
        Form1.Controls.Add(Line_Hor_2)

    End Sub

    Private Sub Output_Board_Data()

    End Sub

    Private Sub Input_Board_Data()

    End Sub

End Class

Class Box
    Public Cells(2, 2) As Cell
    Dim OriginX, OriginY As Integer

    Public Sub New(Ox As Integer, Oy As Integer)
        OriginX = Ox
        OriginY = Oy
        For CountX = 0 To 2
            For CountY = 0 To 2
                Cells(CountX, CountY) = New Cell(OriginX + (CountX * (GameBoard.TOTAL_CELL_SIZEpx + GameBoard.CELL_PADDINGpx)), OriginY + (CountY * (GameBoard.TOTAL_CELL_SIZEpx + GameBoard.CELL_PADDINGpx)))
            Next
        Next

    End Sub
End Class

Class Cell

    Dim OriginX, OriginY, count As Integer
    Public Candidates(2, 2) As Label
    Public Valuelabel As New Label
    Public Value As String

    Public Sub New(Ox As Integer, Oy As Integer)
        count = 1
        OriginX = Ox
        OriginY = Oy

        For CountY = 0 To 2
            For CountX = 0 To 2

                Candidates(CountX, CountY) = New Label

                With Candidates(CountX, CountY)
                    .BackColor = Color.GhostWhite
                    .Size = New Size(GameBoard.CANDIDATE_SIZEpx, GameBoard.CANDIDATE_SIZEpx)
                    .Location = New Drawing.Point(OriginX + (CountX * (GameBoard.CANDIDATE_SIZEpx + GameBoard.CANDIDATE_PADDINGpx)), OriginY + (CountY * (GameBoard.CANDIDATE_SIZEpx + GameBoard.CANDIDATE_PADDINGpx)))
                    .Text = Convert.ToString(count)
                    .TextAlign = ContentAlignment.MiddleCenter
                End With

                Form1.Controls.Add(Candidates(CountX, CountY))
                AddHandler Candidates(CountX, CountY).Click, AddressOf Me.Lbl_Click
                count += 1
            Next
        Next

        With Valuelabel
            .Size = New Size(GameBoard.TOTAL_CELL_SIZEpx, GameBoard.TOTAL_CELL_SIZEpx)
            .BackColor = Color.White
            .Location = New Drawing.Point(OriginX, OriginY)
            .Visible = False
            .Enabled = False
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = New Font("Symbol", 14, FontStyle.Bold)

        End With

        Form1.Controls.Add(Valuelabel)
    End Sub

    Sub Lbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        DirectCast(sender, Label).Text = ""
        If ValueCheck() Then
            For Cols = 0 To 2
                For Rows = 0 To 2
                    Candidates(Cols, Rows).Visible = False
                    Candidates(Cols, Rows).Enabled = False
                Next
            Next

            Valuelabel.Visible = True
            Valuelabel.Enabled = True
            Valuelabel.Text = Value

        End If
    End Sub

    Private Function ValueCheck()
        Value = ""
        Dim count As Integer
        count = 0

        For Cols = 0 To 2
            For Rows = 0 To 2
                If count > 1 Then
                    Return False

                Else
                    If Candidates(Cols, Rows).Text <> "" Then
                        count += 1
                        Value = Candidates(Cols, Rows).Text
                    End If
                End If
            Next
        Next
        Return True
    End Function

End Class

