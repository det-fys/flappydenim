<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStart
    Inherits System.Windows.Forms.Form

    'Formulář přepisuje metodu Dispose, aby vyčistil seznam součástí.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Vyžadováno Návrhářem Windows Form
    Private components As System.ComponentModel.IContainer

    'POZNÁMKA: Následující procedura je vyžadována Návrhářem Windows Form
    'Může být upraveno pomocí Návrháře Windows Form.  
    'Neupravovat pomocí editoru kódu
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStart))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.tbNick = New System.Windows.Forms.TextBox()
        Me.lblLabel = New System.Windows.Forms.Label()
        Me.lblAllwd = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(172, 32)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(39, 29)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'tbNick
        '
        Me.tbNick.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.tbNick.Location = New System.Drawing.Point(12, 32)
        Me.tbNick.Name = "tbNick"
        Me.tbNick.Size = New System.Drawing.Size(154, 29)
        Me.tbNick.TabIndex = 1
        '
        'lblLabel
        '
        Me.lblLabel.AutoSize = True
        Me.lblLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lblLabel.Location = New System.Drawing.Point(12, 9)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(135, 20)
        Me.lblLabel.TabIndex = 2
        Me.lblLabel.Text = "Tvuj čudný nick:"
        '
        'lblAllwd
        '
        Me.lblAllwd.AutoSize = True
        Me.lblAllwd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAllwd.Location = New System.Drawing.Point(13, 64)
        Me.lblAllwd.Name = "lblAllwd"
        Me.lblAllwd.Size = New System.Drawing.Size(158, 13)
        Me.lblAllwd.TabIndex = 3
        Me.lblAllwd.Text = "povolený znaky: a-z A-Z 0-9 ""_"""
        '
        'frmStart
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 86)
        Me.Controls.Add(Me.lblAllwd)
        Me.Controls.Add(Me.tbNick)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStart"
        Me.Text = "Flappy Denim"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents tbNick As TextBox
    Friend WithEvents lblLabel As Label
    Friend WithEvents lblAllwd As Label
End Class
