<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Formulář přepisuje metodu Dispose, aby vyčistil seznam součástí.
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

    'Vyžadováno Návrhářem Windows Form
    Private components As System.ComponentModel.IContainer

    'POZNÁMKA: Následující procedura je vyžadována Návrhářem Windows Form
    'Může být upraveno pomocí Návrháře Windows Form.  
    'Neupravovat pomocí editoru kódu
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pbHra = New System.Windows.Forms.PictureBox()
        Me.StartTimer = New System.Windows.Forms.Timer(Me.components)
        Me.bw = New System.ComponentModel.BackgroundWorker()
        CType(Me.pbHra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbHra
        '
        Me.pbHra.Location = New System.Drawing.Point(0, 0)
        Me.pbHra.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pbHra.Name = "pbHra"
        Me.pbHra.Size = New System.Drawing.Size(500, 600)
        Me.pbHra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbHra.TabIndex = 0
        Me.pbHra.TabStop = False
        '
        'StartTimer
        '
        Me.StartTimer.Enabled = True
        Me.StartTimer.Interval = 300
        '
        'bw
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(194, 150)
        Me.Controls.Add(Me.pbHra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmMain"
        Me.Text = "Flappy Denim"
        CType(Me.pbHra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbHra As PictureBox
    Friend WithEvents StartTimer As Timer
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
End Class
