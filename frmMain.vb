Public Class frmMain

    Private mh As MouseHook

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.mm1 OrElse My.Settings.mm2 Then
            mh = New MouseHook
            mh.HookMouse()
        End If

        TrayIcon.Visible = True

        tmrTick_Tick(tmrTick, Nothing)
        tmrTick.Start()

        Me.Hide()

        SetMenuTheme(Color.FromArgb(&HFF7AB2F4))

    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Const WS_EX_TOOLWINDOW = &H80UI
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or WS_EX_TOOLWINDOW
            Return cp
        End Get
    End Property

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        mh.UnhookMouse()
        Me.Close()
    End Sub

    Private Sub tmrTick_Tick(sender As Timer, e As EventArgs) Handles tmrTick.Tick
        AstoniaHandles = Process.GetProcessesByName("new").Concat(Process.GetProcessesByName("moac")) _
                        .Where(Function(pp) isAstonia(pp) AndAlso elevator(pp)).Select(Function(ap) ap.MainWindowHandle).ToList
    End Sub

    <System.Runtime.InteropServices.DllImport("user32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Auto)>
    Private Shared Function GetClassName(ByVal hWnd As System.IntPtr, ByVal lpClassName As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer : End Function
    Private Function GetWindowClass(ByVal hwnd As IntPtr) As String
        Static sClassName As New System.Text.StringBuilder("", 256)
        Call GetClassName(hwnd, sClassName, 256)
        Return sClassName.ToString
    End Function

    Public Function isAstonia(pp As Process) As Boolean
        Return {"MAINWNDMOAC", "SDL_app"}.Contains(GetWindowClass(pp.MainWindowHandle))
    End Function

    Private Function elevator(pp As Process)
        Try
            Dim dummy = pp.HasExited
        Catch ex As Exception
            RestartSelf(True)
        End Try
        Return True
    End Function

    Public Sub RestartSelf(Optional asAdmin As Boolean = True)

        tmrTick.Stop()
        mh.UnhookMouse()

        Dim procStartInfo As New ProcessStartInfo With {
            .UseShellExecute = True,
            .FileName = Environment.GetCommandLineArgs()(0),
            .WindowStyle = ProcessWindowStyle.Normal,
            .Verb = If(asAdmin, "runas", "") 'add this to prompt for elevation
        }

        My.Settings.Save()
        Try
            Process.Start(procStartInfo).WaitForInputIdle()
        Catch e As System.ComponentModel.Win32Exception
            'operation cancelled
        Catch e As InvalidOperationException
            'wait for inputidle is needed
        Catch e As Exception
            Throw e
        End Try
        TrayIcon.Visible = False
        TrayIcon.Dispose()
        End
    End Sub
    Private Sub XMB1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMB1ToolStripMenuItem.DropDownOpening
        NothingToolStripMenuItem1.Checked = Not My.Settings.mm1
        MiddleMouseToolStripMenuItem1.Checked = My.Settings.mm1
    End Sub
    Private Sub XMB2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMB2ToolStripMenuItem.DropDownOpening
        NothingToolStripMenuItem2.Checked = Not My.Settings.mm2
        MiddleMouseToolStripMenuItem2.Checked = My.Settings.mm2
    End Sub

    Private Sub NothingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NothingToolStripMenuItem1.Click
        My.Settings.mm1 = False
    End Sub
    Private Sub NothingToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NothingToolStripMenuItem2.Click
        My.Settings.mm2 = False
    End Sub

    Private Sub MiddleMouseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MiddleMouseToolStripMenuItem1.Click
        My.Settings.mm1 = Not My.Settings.mm1
        If My.Settings.mm1 OrElse My.Settings.mm2 Then
            mh = New MouseHook
            mh.HookMouse()
        End If

    End Sub
    Private Sub MiddleMouseToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles MiddleMouseToolStripMenuItem2.Click
        My.Settings.mm2 = Not My.Settings.mm2
        If My.Settings.mm1 OrElse My.Settings.mm2 Then
            mh = New MouseHook
            mh.HookMouse()
        End If

    End Sub

#Region "Menu Theming"
    Private Sub SetMenuTheme(col As Color)
        cmsTray.RenderMode = ToolStripRenderMode.Professional
        cmsTray.Renderer = New ThemedRenderer(col)
        SetForeColorRecurse(cmsTray.Items, col)
    End Sub
    Private Sub SetForeColorRecurse(collection As ToolStripItemCollection, col As Color)
        For Each item As ToolStripMenuItem In collection.OfType(Of ToolStripMenuItem) ' skip separators
            item.ForeColor = col
            If item.HasDropDown Then SetForeColorRecurse(item.DropDownItems, col)
        Next
    End Sub
#End Region

End Class
