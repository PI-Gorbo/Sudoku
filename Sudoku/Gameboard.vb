Imports Microsoft.VisualBasic

Public Class Gameboard
    '_________________________________________'
    ''A BIT OF TERMONOLOGY''
    'The gameboard refers to the whole of the Sudoku board
    'The Gameboard consists of 9 Boxes. 3*3
    'Each Box has 9 Cells in it
    'Eeach Cell can have a max of 9 candidates - represented by 9 boxes
    '________________________________________'

    Dim OriginX, OriginY As Integer

    Public Const CANDIDATE_SIZEpx As Integer = 14
    Public Const CANDIDATE_PADDINGpx As Integer = 1

    Public Const TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
    Public Const CELL_PADDINGpx As Integer = 12

    Public Const TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
    Public Const BOX_PADDINGpx As Integer = 20

    Public Const GAME_SIZEpx = (3 * TOTAL_BOX_SIZEpx) + (2 * BOX_PADDINGpx)
    Public Const LINE_WIDTH As Integer = 5

    Public Boxes(2, 2) As Box
    Public Cell_Array(8, 8) As Cell

    Public Sub New(Ox As Integer, Oy As Integer)
        OriginX = Ox
        OriginY = Oy
        CreateGameBoard()
        'Form1.Size = New Size(OriginX + (GAME_SIZEpx + 40), OriginY + (GAME_SIZEpx + 60))
        Cell_Array = Cell.Temp_Cell_Array
    End Sub

    Private Sub CreateGameBoard()
        Dim Box_Point As Point
        For CountX = 0 To 2
            For CountY = 0 To 2
                Box_Point.X = CountX
                Box_Point.Y = CountY
                Boxes(CountX, CountY) = New Box(OriginX + (CountX * (TOTAL_BOX_SIZEpx + BOX_PADDINGpx)), OriginY + (CountY * (TOTAL_BOX_SIZEpx + BOX_PADDINGpx)), Box_Point)
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

    Public Sub Import_NewBoard()
        Dim TempCells = Database.ExportNewBoard()

        For cols = 0 To 8
            For rows = 0 To 8
                Cell_Array(cols, rows).Import_Candidates(TempCells(cols, rows))
            Next
        Next

    End Sub


End Class

Public Class Box

    Dim Box_Point, Cell_Point As Point

    Public Cells(2, 2) As Cell
    Private OriginX, OriginY As Integer

    Public Sub New(Ox As Integer, Oy As Integer, _BoxLocation As Point)
        Box_Point = _BoxLocation
        OriginX = Ox
        OriginY = Oy
        For CountX = 0 To 2
            For CountY = 0 To 2
                Cell_Point.X = (3 * Box_Point.X) + CountX
                Cell_Point.Y = (3 * Box_Point.Y) + CountX
                Cells(CountX, CountY) = New Cell(OriginX + (CountX * (Gameboard.TOTAL_CELL_SIZEpx + Gameboard.CELL_PADDINGpx)), OriginY + (CountY * (Gameboard.TOTAL_CELL_SIZEpx + Gameboard.CELL_PADDINGpx)), Cell_Point, Box_Point)
            Next
        Next

    End Sub
End Class

Public Class Cell

    'Properties used for calculation
    Dim Parent_Box_Point As Point
    Dim Cell_Point As Point
    Dim Row As Integer
    Dim Column As Integer
    Public Shared Temp_Cell_Array(8, 8) As Cell

    'Properties that are used for drawing
    Dim OriginX, OriginY, count, defaultvalue As Integer
    Public Candidates(2, 2) As Label
    Public Valuelabel As New Label
    Dim Val_Candidates As New ArrayList

    Public Sub New(Ox As Integer, Oy As Integer, CellLocation As Point, _Parent_Box_Location As Point)
        'Define Origin as Origin X and Origin Y
        Parent_Box_Point = _Parent_Box_Location
        Cell_Point = CellLocation
        Temp_Cell_Array(CellLocation.X, CellLocation.Y) = Me
        OriginX = Ox
        OriginY = Oy
        count = 1
        For i = 1 To 9
            Val_Candidates.Add(Convert.ToString(i))
        Next

        'Draw Candidates
        For CountY = 0 To 2
            For CountX = 0 To 2

                Candidates(CountX, CountY) = New Label
                defaultvalue = count
                With Candidates(CountX, CountY)
                    .BackColor = Color.GhostWhite
                    .Size = New Size(Gameboard.CANDIDATE_SIZEpx, Gameboard.CANDIDATE_SIZEpx)
                    .Location = New Drawing.Point(OriginX + (CountX * (Gameboard.CANDIDATE_SIZEpx + Gameboard.CANDIDATE_PADDINGpx)), OriginY + (CountY * (Gameboard.CANDIDATE_SIZEpx + Gameboard.CANDIDATE_PADDINGpx)))
                    .Text = Convert.ToString(count)
                    .TextAlign = ContentAlignment.MiddleCenter
                End With

                Form1.Controls.Add(Candidates(CountX, CountY))
                'Adds an event to each label which calls Lbl_Click function
                AddHandler Candidates(CountX, CountY).Click, AddressOf Me.Lbl_Click
                count += 1
            Next
        Next

        'Create and Draw valuelabel - DEFAUlT as Dissappeared.
        With Valuelabel
            .Size = New Size(Gameboard.TOTAL_CELL_SIZEpx, Gameboard.TOTAL_CELL_SIZEpx)
            .BackColor = Color.DarkSlateGray
            .Location = New Drawing.Point(OriginX, OriginY)
            .Visible = False
            .Enabled = False
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = New Font("Symbol", 30, FontStyle.Bold)

        End With
        Form1.Controls.Add(Valuelabel)

    End Sub

    'Event Handler for labels
    Private Sub Lbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Converts the sender object into a label "x"
        Dim x As Label = DirectCast(sender, Label)
        'Removes x from Valus and Removes its text from the gameboard
        Val_Candidates.Remove(x.Text)
        x.Text = ""
        'If there is only 1 value in the array.
        If Val_Candidates.Count = 1 Then
            For Cols = 0 To 2
                For Rows = 0 To 2
                    Candidates(Cols, Rows).Visible = False
                    Candidates(Cols, Rows).Enabled = False
                Next
            Next

            With Valuelabel
                .Visible = True
                .BackColor = Color.White
                .Enabled = True
                .BringToFront()
                'Set Value Label as the remaining Val_Candidates
                .Text = Val_Candidates(0)
            End With
        End If
    End Sub

    Public Sub Import_Candidates(Imported_Candidates As ArrayList)
        For cols = 0 To 2
            For rows = 0 To 2
                For Each ele In Imported_Candidates
                    If ele = defaultvalue Then
                        Candidates(cols, rows).Text = defaultvalue
                    End If
                Next
            Next
        Next

    End Sub


End Class
