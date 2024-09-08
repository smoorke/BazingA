<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmsTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.XMB1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NothingToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiddleMouseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.XMB2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NothingToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MiddleMouseToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrTick = New System.Windows.Forms.Timer(Me.components)
        Me.cmsTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.cmsTray
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "BazingA"
        '
        'cmsTray
        '
        Me.cmsTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XMB1ToolStripMenuItem, Me.XMB2ToolStripMenuItem, Me.ToolStripMenuItem1, Me.QuitToolStripMenuItem})
        Me.cmsTray.Name = "cmsTray"
        Me.cmsTray.Size = New System.Drawing.Size(106, 76)
        '
        'XMB1ToolStripMenuItem
        '
        Me.XMB1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NothingToolStripMenuItem1, Me.MiddleMouseToolStripMenuItem1})
        Me.XMB1ToolStripMenuItem.Name = "XMB1ToolStripMenuItem"
        Me.XMB1ToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.XMB1ToolStripMenuItem.Text = "XMB1"
        '
        'NothingToolStripMenuItem1
        '
        Me.NothingToolStripMenuItem1.Name = "NothingToolStripMenuItem1"
        Me.NothingToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.NothingToolStripMenuItem1.Text = "Nothing"
        '
        'MiddleMouseToolStripMenuItem1
        '
        Me.MiddleMouseToolStripMenuItem1.Name = "MiddleMouseToolStripMenuItem1"
        Me.MiddleMouseToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.MiddleMouseToolStripMenuItem1.Text = "Middle Mouse"
        '
        'XMB2ToolStripMenuItem
        '
        Me.XMB2ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NothingToolStripMenuItem2, Me.MiddleMouseToolStripMenuItem2})
        Me.XMB2ToolStripMenuItem.Name = "XMB2ToolStripMenuItem"
        Me.XMB2ToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.XMB2ToolStripMenuItem.Text = "XMB2"
        '
        'NothingToolStripMenuItem2
        '
        Me.NothingToolStripMenuItem2.Name = "NothingToolStripMenuItem2"
        Me.NothingToolStripMenuItem2.Size = New System.Drawing.Size(150, 22)
        Me.NothingToolStripMenuItem2.Text = "Nothing"
        '
        'MiddleMouseToolStripMenuItem2
        '
        Me.MiddleMouseToolStripMenuItem2.Name = "MiddleMouseToolStripMenuItem2"
        Me.MiddleMouseToolStripMenuItem2.Size = New System.Drawing.Size(150, 22)
        Me.MiddleMouseToolStripMenuItem2.Text = "Middle Mouse"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(102, 6)
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Image = Global.BazingA.My.Resources.Resources.Close
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'tmrTick
        '
        Me.tmrTick.Interval = 1337
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(0, 0)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMain"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.Text = "BazingA"
        Me.cmsTray.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents cmsTray As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tmrTick As Timer
    Friend WithEvents XMB1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NothingToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MiddleMouseToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents XMB2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NothingToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents MiddleMouseToolStripMenuItem2 As ToolStripMenuItem
End Class
