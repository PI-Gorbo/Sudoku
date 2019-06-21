<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DebugBox = New System.Windows.Forms.ListBox()
        Me.Btn_NewGame = New System.Windows.Forms.Button()
        Me.Keypad_2 = New System.Windows.Forms.Button()
        Me.Keypad_3 = New System.Windows.Forms.Button()
        Me.Keypad_6 = New System.Windows.Forms.Button()
        Me.Keypad_5 = New System.Windows.Forms.Button()
        Me.Keypad_4 = New System.Windows.Forms.Button()
        Me.Keypad_9 = New System.Windows.Forms.Button()
        Me.Keypad_8 = New System.Windows.Forms.Button()
        Me.Keypad_7 = New System.Windows.Forms.Button()
        Me.Keypad_1 = New System.Windows.Forms.Button()
        Me.Btn_Debug = New System.Windows.Forms.Button()
        Me.Btn_SolveBoard = New System.Windows.Forms.Button()
        Me.Group_Menu = New System.Windows.Forms.GroupBox()
        Me.Lbl_ManualEntryWarning = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_FinishEntry = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Difficulty_Lbl = New System.Windows.Forms.Label()
        Me.Btn_Help = New System.Windows.Forms.Button()
        Me.DropDown_Difficulty = New System.Windows.Forms.ComboBox()
        Me.Group_Controls = New System.Windows.Forms.GroupBox()
        Me.Rad_Pen = New System.Windows.Forms.RadioButton()
        Me.Rad_Pencil = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lbl_FileName = New System.Windows.Forms.Label()
        Me.Group_Menu.SuspendLayout()
        Me.Group_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'DebugBox
        '
        Me.DebugBox.Font = New System.Drawing.Font("Roboto", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebugBox.FormattingEnabled = True
        Me.DebugBox.ItemHeight = 17
        Me.DebugBox.Location = New System.Drawing.Point(761, 25)
        Me.DebugBox.Name = "DebugBox"
        Me.DebugBox.Size = New System.Drawing.Size(209, 463)
        Me.DebugBox.TabIndex = 0
        '
        'Btn_NewGame
        '
        Me.Btn_NewGame.BackColor = System.Drawing.Color.White
        Me.Btn_NewGame.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_NewGame.Location = New System.Drawing.Point(10, 10)
        Me.Btn_NewGame.Name = "Btn_NewGame"
        Me.Btn_NewGame.Size = New System.Drawing.Size(100, 30)
        Me.Btn_NewGame.TabIndex = 1
        Me.Btn_NewGame.Text = "New Game"
        Me.Btn_NewGame.UseVisualStyleBackColor = False
        '
        'Keypad_2
        '
        Me.Keypad_2.BackColor = System.Drawing.Color.White
        Me.Keypad_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_2.Location = New System.Drawing.Point(67, 41)
        Me.Keypad_2.Name = "Keypad_2"
        Me.Keypad_2.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_2.TabIndex = 4
        Me.Keypad_2.Tag = "2"
        Me.Keypad_2.Text = "2"
        Me.Keypad_2.UseVisualStyleBackColor = False
        '
        'Keypad_3
        '
        Me.Keypad_3.BackColor = System.Drawing.Color.White
        Me.Keypad_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_3.Location = New System.Drawing.Point(120, 41)
        Me.Keypad_3.Name = "Keypad_3"
        Me.Keypad_3.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_3.TabIndex = 5
        Me.Keypad_3.Tag = "3"
        Me.Keypad_3.Text = "3"
        Me.Keypad_3.UseVisualStyleBackColor = False
        '
        'Keypad_6
        '
        Me.Keypad_6.BackColor = System.Drawing.Color.White
        Me.Keypad_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_6.Location = New System.Drawing.Point(120, 86)
        Me.Keypad_6.Name = "Keypad_6"
        Me.Keypad_6.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_6.TabIndex = 8
        Me.Keypad_6.Tag = "6"
        Me.Keypad_6.Text = "6"
        Me.Keypad_6.UseVisualStyleBackColor = False
        '
        'Keypad_5
        '
        Me.Keypad_5.BackColor = System.Drawing.Color.White
        Me.Keypad_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_5.Location = New System.Drawing.Point(67, 86)
        Me.Keypad_5.Name = "Keypad_5"
        Me.Keypad_5.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_5.TabIndex = 7
        Me.Keypad_5.Tag = "5"
        Me.Keypad_5.Text = "5"
        Me.Keypad_5.UseVisualStyleBackColor = False
        '
        'Keypad_4
        '
        Me.Keypad_4.BackColor = System.Drawing.Color.White
        Me.Keypad_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_4.Location = New System.Drawing.Point(14, 86)
        Me.Keypad_4.Name = "Keypad_4"
        Me.Keypad_4.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_4.TabIndex = 6
        Me.Keypad_4.Tag = "4"
        Me.Keypad_4.Text = "4"
        Me.Keypad_4.UseVisualStyleBackColor = False
        '
        'Keypad_9
        '
        Me.Keypad_9.BackColor = System.Drawing.Color.White
        Me.Keypad_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_9.Location = New System.Drawing.Point(120, 131)
        Me.Keypad_9.Name = "Keypad_9"
        Me.Keypad_9.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_9.TabIndex = 11
        Me.Keypad_9.Tag = "9"
        Me.Keypad_9.Text = "9"
        Me.Keypad_9.UseVisualStyleBackColor = False
        '
        'Keypad_8
        '
        Me.Keypad_8.BackColor = System.Drawing.Color.White
        Me.Keypad_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_8.Location = New System.Drawing.Point(67, 131)
        Me.Keypad_8.Name = "Keypad_8"
        Me.Keypad_8.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_8.TabIndex = 10
        Me.Keypad_8.Tag = "8"
        Me.Keypad_8.Text = "8"
        Me.Keypad_8.UseVisualStyleBackColor = False
        '
        'Keypad_7
        '
        Me.Keypad_7.BackColor = System.Drawing.Color.White
        Me.Keypad_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_7.Location = New System.Drawing.Point(14, 131)
        Me.Keypad_7.Name = "Keypad_7"
        Me.Keypad_7.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_7.TabIndex = 9
        Me.Keypad_7.Tag = "7"
        Me.Keypad_7.Text = "7"
        Me.Keypad_7.UseVisualStyleBackColor = False
        '
        'Keypad_1
        '
        Me.Keypad_1.BackColor = System.Drawing.Color.White
        Me.Keypad_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keypad_1.Location = New System.Drawing.Point(14, 41)
        Me.Keypad_1.Name = "Keypad_1"
        Me.Keypad_1.Size = New System.Drawing.Size(47, 39)
        Me.Keypad_1.TabIndex = 14
        Me.Keypad_1.Tag = "1"
        Me.Keypad_1.Text = "1"
        Me.Keypad_1.UseVisualStyleBackColor = False
        '
        'Btn_Debug
        '
        Me.Btn_Debug.BackColor = System.Drawing.Color.White
        Me.Btn_Debug.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Debug.Location = New System.Drawing.Point(14, 176)
        Me.Btn_Debug.Name = "Btn_Debug"
        Me.Btn_Debug.Size = New System.Drawing.Size(153, 37)
        Me.Btn_Debug.TabIndex = 16
        Me.Btn_Debug.Text = "Debug Candidates"
        Me.Btn_Debug.UseVisualStyleBackColor = False
        '
        'Btn_SolveBoard
        '
        Me.Btn_SolveBoard.BackColor = System.Drawing.Color.White
        Me.Btn_SolveBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_SolveBoard.Location = New System.Drawing.Point(14, 220)
        Me.Btn_SolveBoard.Name = "Btn_SolveBoard"
        Me.Btn_SolveBoard.Size = New System.Drawing.Size(153, 31)
        Me.Btn_SolveBoard.TabIndex = 17
        Me.Btn_SolveBoard.Text = "Solve Board"
        Me.Btn_SolveBoard.UseVisualStyleBackColor = False
        '
        'Group_Menu
        '
        Me.Group_Menu.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Group_Menu.Controls.Add(Me.Lbl_ManualEntryWarning)
        Me.Group_Menu.Controls.Add(Me.Label1)
        Me.Group_Menu.Controls.Add(Me.Btn_FinishEntry)
        Me.Group_Menu.Controls.Add(Me.Button1)
        Me.Group_Menu.Controls.Add(Me.Difficulty_Lbl)
        Me.Group_Menu.Controls.Add(Me.Btn_Help)
        Me.Group_Menu.Controls.Add(Me.DropDown_Difficulty)
        Me.Group_Menu.Controls.Add(Me.Btn_NewGame)
        Me.Group_Menu.Font = New System.Drawing.Font("Roboto", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Menu.Location = New System.Drawing.Point(25, 25)
        Me.Group_Menu.Name = "Group_Menu"
        Me.Group_Menu.Size = New System.Drawing.Size(713, 50)
        Me.Group_Menu.TabIndex = 18
        Me.Group_Menu.TabStop = False
        '
        'Lbl_ManualEntryWarning
        '
        Me.Lbl_ManualEntryWarning.AutoSize = True
        Me.Lbl_ManualEntryWarning.BackColor = System.Drawing.Color.DimGray
        Me.Lbl_ManualEntryWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ManualEntryWarning.ForeColor = System.Drawing.Color.Snow
        Me.Lbl_ManualEntryWarning.Location = New System.Drawing.Point(518, 17)
        Me.Lbl_ManualEntryWarning.Name = "Lbl_ManualEntryWarning"
        Me.Lbl_ManualEntryWarning.Size = New System.Drawing.Size(123, 16)
        Me.Lbl_ManualEntryWarning.TabIndex = 20
        Me.Lbl_ManualEntryWarning.Text = "Manual Entry Mode"
        Me.Lbl_ManualEntryWarning.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Roboto", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(303, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 38)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "|"
        '
        'Btn_FinishEntry
        '
        Me.Btn_FinishEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btn_FinishEntry.Enabled = False
        Me.Btn_FinishEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_FinishEntry.Location = New System.Drawing.Point(449, 10)
        Me.Btn_FinishEntry.Name = "Btn_FinishEntry"
        Me.Btn_FinishEntry.Size = New System.Drawing.Size(57, 30)
        Me.Btn_FinishEntry.TabIndex = 23
        Me.Btn_FinishEntry.Text = "Finish"
        Me.Btn_FinishEntry.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(331, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 30)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Manual Entry"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Difficulty_Lbl
        '
        Me.Difficulty_Lbl.AutoSize = True
        Me.Difficulty_Lbl.BackColor = System.Drawing.Color.White
        Me.Difficulty_Lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Difficulty_Lbl.Location = New System.Drawing.Point(116, 12)
        Me.Difficulty_Lbl.Name = "Difficulty_Lbl"
        Me.Difficulty_Lbl.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
        Me.Difficulty_Lbl.Size = New System.Drawing.Size(71, 26)
        Me.Difficulty_Lbl.TabIndex = 21
        Me.Difficulty_Lbl.Text = "Difficulty :"
        '
        'Btn_Help
        '
        Me.Btn_Help.BackColor = System.Drawing.Color.White
        Me.Btn_Help.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Help.Location = New System.Drawing.Point(648, 9)
        Me.Btn_Help.Name = "Btn_Help"
        Me.Btn_Help.Size = New System.Drawing.Size(59, 30)
        Me.Btn_Help.TabIndex = 20
        Me.Btn_Help.Text = "Help"
        Me.Btn_Help.UseVisualStyleBackColor = False
        '
        'DropDown_Difficulty
        '
        Me.DropDown_Difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDown_Difficulty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DropDown_Difficulty.FormattingEnabled = True
        Me.DropDown_Difficulty.Items.AddRange(New Object() {"Easy", "Medium", "Hard", "Evil!", "Custom board"})
        Me.DropDown_Difficulty.Location = New System.Drawing.Point(198, 12)
        Me.DropDown_Difficulty.Name = "DropDown_Difficulty"
        Me.DropDown_Difficulty.Size = New System.Drawing.Size(100, 26)
        Me.DropDown_Difficulty.TabIndex = 19
        '
        'Group_Controls
        '
        Me.Group_Controls.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Group_Controls.Controls.Add(Me.Rad_Pen)
        Me.Group_Controls.Controls.Add(Me.Keypad_2)
        Me.Group_Controls.Controls.Add(Me.Btn_SolveBoard)
        Me.Group_Controls.Controls.Add(Me.Rad_Pencil)
        Me.Group_Controls.Controls.Add(Me.Btn_Debug)
        Me.Group_Controls.Controls.Add(Me.Keypad_5)
        Me.Group_Controls.Controls.Add(Me.Keypad_9)
        Me.Group_Controls.Controls.Add(Me.Keypad_1)
        Me.Group_Controls.Controls.Add(Me.Keypad_3)
        Me.Group_Controls.Controls.Add(Me.Keypad_6)
        Me.Group_Controls.Controls.Add(Me.Keypad_8)
        Me.Group_Controls.Controls.Add(Me.Keypad_4)
        Me.Group_Controls.Controls.Add(Me.Keypad_7)
        Me.Group_Controls.Font = New System.Drawing.Font("Roboto", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_Controls.Location = New System.Drawing.Point(553, 200)
        Me.Group_Controls.Name = "Group_Controls"
        Me.Group_Controls.Size = New System.Drawing.Size(185, 267)
        Me.Group_Controls.TabIndex = 19
        Me.Group_Controls.TabStop = False
        '
        'Rad_Pen
        '
        Me.Rad_Pen.AutoSize = True
        Me.Rad_Pen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Pen.Location = New System.Drawing.Point(98, 13)
        Me.Rad_Pen.Name = "Rad_Pen"
        Me.Rad_Pen.Size = New System.Drawing.Size(52, 22)
        Me.Rad_Pen.TabIndex = 4
        Me.Rad_Pen.TabStop = True
        Me.Rad_Pen.Text = "Pen"
        Me.Rad_Pen.UseVisualStyleBackColor = True
        '
        'Rad_Pencil
        '
        Me.Rad_Pencil.AutoSize = True
        Me.Rad_Pencil.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Pencil.Location = New System.Drawing.Point(25, 13)
        Me.Rad_Pencil.Name = "Rad_Pencil"
        Me.Rad_Pencil.Size = New System.Drawing.Size(66, 22)
        Me.Rad_Pencil.TabIndex = 5
        Me.Rad_Pencil.TabStop = True
        Me.Rad_Pencil.Text = "Pencil"
        Me.Rad_Pencil.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Label2"
        '
        'Lbl_FileName
        '
        Me.Lbl_FileName.AutoSize = True
        Me.Lbl_FileName.Font = New System.Drawing.Font("Roboto", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_FileName.ForeColor = System.Drawing.Color.White
        Me.Lbl_FileName.Location = New System.Drawing.Point(291, 79)
        Me.Lbl_FileName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_FileName.Name = "Lbl_FileName"
        Me.Lbl_FileName.Size = New System.Drawing.Size(0, 18)
        Me.Lbl_FileName.TabIndex = 21
        Me.Lbl_FileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1443, 661)
        Me.Controls.Add(Me.Lbl_FileName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Group_Controls)
        Me.Controls.Add(Me.Group_Menu)
        Me.Controls.Add(Me.DebugBox)
        Me.Name = "Form1"
        Me.Tag = ""
        Me.Text = "Sudoku Game and Sovler!"
        Me.Group_Menu.ResumeLayout(False)
        Me.Group_Menu.PerformLayout()
        Me.Group_Controls.ResumeLayout(False)
        Me.Group_Controls.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DebugBox As ListBox
    Friend WithEvents Btn_NewGame As Button
    Friend WithEvents Keypad_2 As Button
    Friend WithEvents Keypad_3 As Button
    Friend WithEvents Keypad_6 As Button
    Friend WithEvents Keypad_5 As Button
    Friend WithEvents Keypad_4 As Button
    Friend WithEvents Keypad_9 As Button
    Friend WithEvents Keypad_8 As Button
    Friend WithEvents Keypad_7 As Button
    Friend WithEvents Keypad_1 As Button
    Friend WithEvents Btn_Debug As Button
    Friend WithEvents Btn_SolveBoard As Button
    Friend WithEvents Group_Menu As GroupBox
    Friend WithEvents Btn_Help As Button
    Friend WithEvents DropDown_Difficulty As ComboBox
    Friend WithEvents Group_Controls As GroupBox
    Friend WithEvents Rad_Pencil As RadioButton
    Friend WithEvents Rad_Pen As RadioButton
    Friend WithEvents Difficulty_Lbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_FinishEntry As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Lbl_ManualEntryWarning As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Lbl_FileName As Label
End Class
