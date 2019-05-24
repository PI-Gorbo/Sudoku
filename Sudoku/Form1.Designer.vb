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
        Me.Rad_Remove = New System.Windows.Forms.RadioButton()
        Me.Rad_Add = New System.Windows.Forms.RadioButton()
        Me.Gp_Editing.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lstbx
        '
        Me.Lstbx.FormattingEnabled = True
        Me.Lstbx.ItemHeight = 16
        Me.Lstbx.Location = New System.Drawing.Point(1002, 60)
        Me.Lstbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Lstbx.Name = "Lstbx"
        Me.Lstbx.Size = New System.Drawing.Size(403, 596)
        Me.Lstbx.TabIndex = 0
        '
        'Btn_NewGame
        '
        Me.Btn_NewGame.Location = New System.Drawing.Point(809, 60)
        Me.Btn_NewGame.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Btn_NewGame.Name = "Btn_NewGame"
        Me.Btn_NewGame.Size = New System.Drawing.Size(100, 28)
        Me.Btn_NewGame.TabIndex = 1
        Me.Btn_NewGame.Text = "New Game"
        Me.Btn_NewGame.UseVisualStyleBackColor = True
        '
        'Gp_Editing
        '
        Me.Gp_Editing.BackColor = System.Drawing.Color.White
        Me.Gp_Editing.Controls.Add(Me.Rad_Add)
        Me.Gp_Editing.Controls.Add(Me.Rad_Remove)
        Me.Gp_Editing.Location = New System.Drawing.Point(809, 133)
        Me.Gp_Editing.Name = "Gp_Editing"
        Me.Gp_Editing.Size = New System.Drawing.Size(168, 110)
        Me.Gp_Editing.TabIndex = 2
        Me.Gp_Editing.TabStop = False
        Me.Gp_Editing.Text = "Editing Mode"
        '
        'Rad_Remove
        '
        Me.Rad_Remove.AutoSize = True
        Me.Rad_Remove.Location = New System.Drawing.Point(9, 24)
        Me.Rad_Remove.Name = "Rad_Remove"
        Me.Rad_Remove.Size = New System.Drawing.Size(148, 21)
        Me.Rad_Remove.TabIndex = 0
        Me.Rad_Remove.TabStop = True
        Me.Rad_Remove.Text = "Remove Candiates"
        Me.Rad_Remove.UseVisualStyleBackColor = True
        '
        'Rad_Add
        '
        Me.Rad_Add.AutoSize = True
        Me.Rad_Add.Location = New System.Drawing.Point(9, 63)
        Me.Rad_Add.Name = "Rad_Add"
        Me.Rad_Add.Size = New System.Drawing.Size(129, 21)
        Me.Rad_Add.TabIndex = 1
        Me.Rad_Add.TabStop = True
        Me.Rad_Add.Text = "Add Candidates"
        Me.Rad_Add.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1637, 784)
        Me.Controls.Add(Me.Gp_Editing)
        Me.Controls.Add(Me.Btn_NewGame)
        Me.Controls.Add(Me.Lstbx)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Gp_Editing.ResumeLayout(False)
        Me.Gp_Editing.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lstbx As ListBox
    Friend WithEvents Btn_NewGame As Button
    Friend WithEvents Gp_Editing As GroupBox
    Friend WithEvents Rad_Add As RadioButton
    Friend WithEvents Rad_Remove As RadioButton
End Class
