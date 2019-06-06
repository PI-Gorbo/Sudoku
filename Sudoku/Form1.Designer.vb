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
        Me.Lstbx = New System.Windows.Forms.ListBox()
        Me.Btn_NewGame = New System.Windows.Forms.Button()
        Me.Gp_Editing = New System.Windows.Forms.GroupBox()
        Me.Rad_Pen = New System.Windows.Forms.RadioButton()
        Me.Rad_Pencil = New System.Windows.Forms.RadioButton()
        Me.Keypad_2 = New System.Windows.Forms.Button()
        Me.Keypad_3 = New System.Windows.Forms.Button()
        Me.Keypad_6 = New System.Windows.Forms.Button()
        Me.Keypad_5 = New System.Windows.Forms.Button()
        Me.Keypad_4 = New System.Windows.Forms.Button()
        Me.Keypad_9 = New System.Windows.Forms.Button()
        Me.Keypad_8 = New System.Windows.Forms.Button()
        Me.Keypad_7 = New System.Windows.Forms.Button()
        Me.Keypad_1 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Gp_Editing.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lstbx
        '
        Me.Lstbx.FormattingEnabled = True
        Me.Lstbx.Location = New System.Drawing.Point(708, 20)
        Me.Lstbx.Name = "Lstbx"
        Me.Lstbx.Size = New System.Drawing.Size(244, 602)
        Me.Lstbx.TabIndex = 0
        '
        'Btn_NewGame
        '
        Me.Btn_NewGame.Location = New System.Drawing.Point(581, 55)
        Me.Btn_NewGame.Name = "Btn_NewGame"
        Me.Btn_NewGame.Size = New System.Drawing.Size(75, 23)
        Me.Btn_NewGame.TabIndex = 1
        Me.Btn_NewGame.Text = "New Game"
        Me.Btn_NewGame.UseVisualStyleBackColor = True
        '
        'Gp_Editing
        '
        Me.Gp_Editing.BackColor = System.Drawing.Color.White
        Me.Gp_Editing.Controls.Add(Me.Rad_Pen)
        Me.Gp_Editing.Controls.Add(Me.Rad_Pencil)
        Me.Gp_Editing.Location = New System.Drawing.Point(562, 102)
        Me.Gp_Editing.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Gp_Editing.Name = "Gp_Editing"
        Me.Gp_Editing.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Gp_Editing.Size = New System.Drawing.Size(126, 66)
        Me.Gp_Editing.TabIndex = 2
        Me.Gp_Editing.TabStop = False
        Me.Gp_Editing.Text = "Editing Mode"
        '
        'Rad_Pen
        '
        Me.Rad_Pen.AutoSize = True
        Me.Rad_Pen.Location = New System.Drawing.Point(5, 41)
        Me.Rad_Pen.Name = "Rad_Pen"
        Me.Rad_Pen.Size = New System.Drawing.Size(44, 17)
        Me.Rad_Pen.TabIndex = 4
        Me.Rad_Pen.TabStop = True
        Me.Rad_Pen.Text = "Pen"
        Me.Rad_Pen.UseVisualStyleBackColor = True
        '
        'Rad_Pencil
        '
        Me.Rad_Pencil.AutoSize = True
        Me.Rad_Pencil.Location = New System.Drawing.Point(5, 18)
        Me.Rad_Pencil.Name = "Rad_Pencil"
        Me.Rad_Pencil.Size = New System.Drawing.Size(54, 17)
        Me.Rad_Pencil.TabIndex = 5
        Me.Rad_Pencil.TabStop = True
        Me.Rad_Pencil.Text = "Pencil"
        Me.Rad_Pencil.UseVisualStyleBackColor = True
        '
        'Keypad_2
        '
        Me.Keypad_2.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_2.Location = New System.Drawing.Point(605, 188)
        Me.Keypad_2.Name = "Keypad_2"
        Me.Keypad_2.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_2.TabIndex = 4
        Me.Keypad_2.Tag = "2"
        Me.Keypad_2.Text = "2"
        Me.Keypad_2.UseVisualStyleBackColor = True
        '
        'Keypad_3
        '
        Me.Keypad_3.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_3.Location = New System.Drawing.Point(650, 188)
        Me.Keypad_3.Name = "Keypad_3"
        Me.Keypad_3.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_3.TabIndex = 5
        Me.Keypad_3.Tag = "3"
        Me.Keypad_3.Text = "3"
        Me.Keypad_3.UseVisualStyleBackColor = True
        '
        'Keypad_6
        '
        Me.Keypad_6.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_6.Location = New System.Drawing.Point(650, 223)
        Me.Keypad_6.Name = "Keypad_6"
        Me.Keypad_6.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_6.TabIndex = 8
        Me.Keypad_6.Tag = "6"
        Me.Keypad_6.Text = "6"
        Me.Keypad_6.UseVisualStyleBackColor = True
        '
        'Keypad_5
        '
        Me.Keypad_5.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_5.Location = New System.Drawing.Point(605, 223)
        Me.Keypad_5.Name = "Keypad_5"
        Me.Keypad_5.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_5.TabIndex = 7
        Me.Keypad_5.Tag = "5"
        Me.Keypad_5.Text = "5"
        Me.Keypad_5.UseVisualStyleBackColor = True
        '
        'Keypad_4
        '
        Me.Keypad_4.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_4.Location = New System.Drawing.Point(562, 223)
        Me.Keypad_4.Name = "Keypad_4"
        Me.Keypad_4.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_4.TabIndex = 6
        Me.Keypad_4.Tag = "4"
        Me.Keypad_4.Text = "4"
        Me.Keypad_4.UseVisualStyleBackColor = True
        '
        'Keypad_9
        '
        Me.Keypad_9.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_9.Location = New System.Drawing.Point(650, 258)
        Me.Keypad_9.Name = "Keypad_9"
        Me.Keypad_9.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_9.TabIndex = 11
        Me.Keypad_9.Tag = "9"
        Me.Keypad_9.Text = "9"
        Me.Keypad_9.UseVisualStyleBackColor = True
        '
        'Keypad_8
        '
        Me.Keypad_8.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_8.Location = New System.Drawing.Point(605, 258)
        Me.Keypad_8.Name = "Keypad_8"
        Me.Keypad_8.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_8.TabIndex = 10
        Me.Keypad_8.Tag = "8"
        Me.Keypad_8.Text = "8"
        Me.Keypad_8.UseVisualStyleBackColor = True
        '
        'Keypad_7
        '
        Me.Keypad_7.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_7.Location = New System.Drawing.Point(562, 258)
        Me.Keypad_7.Name = "Keypad_7"
        Me.Keypad_7.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_7.TabIndex = 9
        Me.Keypad_7.Tag = "7"
        Me.Keypad_7.Text = "7"
        Me.Keypad_7.UseVisualStyleBackColor = True
        '
        'Keypad_1
        '
        Me.Keypad_1.Font = New System.Drawing.Font("Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Keypad_1.Location = New System.Drawing.Point(562, 187)
        Me.Keypad_1.Name = "Keypad_1"
        Me.Keypad_1.Size = New System.Drawing.Size(38, 29)
        Me.Keypad_1.TabIndex = 14
        Me.Keypad_1.Tag = "1"
        Me.Keypad_1.Text = "1"
        Me.Keypad_1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(581, 303)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 47)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "CalcCandidates"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(581, 356)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 65)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Debug Candidates"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(581, 427)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 50)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "partially Solve Board"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(581, 483)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 50)
        Me.Button4.TabIndex = 18
        Me.Button4.Text = "Check Board Validity"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1228, 637)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Keypad_1)
        Me.Controls.Add(Me.Keypad_9)
        Me.Controls.Add(Me.Keypad_8)
        Me.Controls.Add(Me.Keypad_7)
        Me.Controls.Add(Me.Keypad_6)
        Me.Controls.Add(Me.Keypad_5)
        Me.Controls.Add(Me.Keypad_4)
        Me.Controls.Add(Me.Keypad_3)
        Me.Controls.Add(Me.Keypad_2)
        Me.Controls.Add(Me.Gp_Editing)
        Me.Controls.Add(Me.Btn_NewGame)
        Me.Controls.Add(Me.Lstbx)
        Me.Name = "Form1"
        Me.Tag = ""
        Me.Text = "Form1"
        Me.Gp_Editing.ResumeLayout(False)
        Me.Gp_Editing.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lstbx As ListBox
    Friend WithEvents Btn_NewGame As Button
    Friend WithEvents Gp_Editing As GroupBox
    Friend WithEvents Rad_Pen As RadioButton
    Friend WithEvents Rad_Pencil As RadioButton
    Friend WithEvents Keypad_2 As Button
    Friend WithEvents Keypad_3 As Button
    Friend WithEvents Keypad_6 As Button
    Friend WithEvents Keypad_5 As Button
    Friend WithEvents Keypad_4 As Button
    Friend WithEvents Keypad_9 As Button
    Friend WithEvents Keypad_8 As Button
    Friend WithEvents Keypad_7 As Button
    Friend WithEvents Keypad_1 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
