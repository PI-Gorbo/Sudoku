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
        Me.SuspendLayout()
        '
        'Lstbx
        '
        Me.Lstbx.FormattingEnabled = True
        Me.Lstbx.Location = New System.Drawing.Point(674, 49)
        Me.Lstbx.Name = "Lstbx"
        Me.Lstbx.Size = New System.Drawing.Size(303, 485)
        Me.Lstbx.TabIndex = 0
        '
        'Btn_NewGame
        '
        Me.Btn_NewGame.Location = New System.Drawing.Point(564, 49)
        Me.Btn_NewGame.Name = "Btn_NewGame"
        Me.Btn_NewGame.Size = New System.Drawing.Size(75, 23)
        Me.Btn_NewGame.TabIndex = 1
        Me.Btn_NewGame.Text = "New Game"
        Me.Btn_NewGame.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1228, 637)
        Me.Controls.Add(Me.Btn_NewGame)
        Me.Controls.Add(Me.Lstbx)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lstbx As ListBox
    Friend WithEvents Btn_NewGame As Button
End Class
