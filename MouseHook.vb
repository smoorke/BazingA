
Imports System.Runtime.InteropServices

Public Class MouseHook : Implements IDisposable

    Private Const HC_ACTION As Integer = 0
    Private Const WH_MOUSE_LL As Integer = 14

    Private Const WM_MOUSEMOVE = &H200

    Private Const WM_LBUTTONDOWN = &H201
    Private Const WM_LBUTTONUP = &H202

    Private Const WM_RBUTTONDOWN = &H204
    Private Const WM_RBUTTONUP = &H205

    Private Const WM_MBUTTONDOWN = &H207
    Private Const WM_MBUTTONUP = &H208

    Private Const WM_MOUSEWHEEL = &H20A

    Private Const WM_XBUTTONDOWN = &H20B
    Private Const WM_XBUTTONUP = &H20C

    Public Structure MSLLHOOKSTRUCT
        Public pt As Point
        Public mousedata As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure


    Public Delegate Function MouseHookCallBack(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As Integer

    <DllImport("Kernel32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function GetModuleHandle(ByVal ModuleName As String) As IntPtr : End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function SetWindowsHookEx(idHook As Integer, HookProc As MouseHookCallBack,
           hInstance As IntPtr, ThreadId As Integer) As IntPtr : End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function CallNextHookEx(hHook As IntPtr, nCode As Integer,
           wParam As IntPtr, lParam As IntPtr) As Integer : End Function

    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function UnhookWindowsHookEx(hHook As IntPtr) As Boolean : End Function


    <DllImport("user32.dll", SetLastError:=True, CharSet:=Runtime.InteropServices.CharSet.Auto)>
    Public Shared Function WindowFromPoint(pt As Point) As IntPtr : End Function

    Public HookHandle As IntPtr = IntPtr.Zero

    Private Function MouseProc(
        ByVal nCode As Integer,
        ByVal wParam As IntPtr,
        ByVal lParam As IntPtr) As Integer
        If nCode <> HC_ACTION Then Return CallNextHookEx(HookHandle, nCode, wParam, lParam)

        Dim mhs As MSLLHOOKSTRUCT = Marshal.PtrToStructure(Of MSLLHOOKSTRUCT)(lParam)

        If nCode = HC_ACTION Then
            If AstoniaHandles.Any(Function(ah) ah = WindowFromPoint(mhs.pt)) Then
                Select Case wParam.ToInt32()
                    Case WM_XBUTTONDOWN
                        If mhs.flags = 0 Then 'don't click on injected event
                            Dim button As Integer = (mhs.mousedata And &HFFFF0000) >> 16
                            If button = 1 AndAlso My.Settings.mm1 OrElse
                               button = 2 AndAlso My.Settings.mm2 Then

                                Debug.Print($"xmbdown {mhs.flags} {button}")
                                frmMain.TrayIcon.Icon = My.Resources.disaster
                                Task.Run(Sub()
                                             SendMouseInput(MouseEventF.XDown, button) 'inject xmb to activate window
                                             SendMouseInput(MouseEventF.MiddleDown, 0)
                                         End Sub)
                                Return 1

                            End If
                        End If
                    Case WM_XBUTTONUP
                        If mhs.flags = 0 Then 'don't click on injected event
                            Dim button As Integer = (mhs.mousedata And &HFFFF0000) >> 16
                            If button = 1 AndAlso My.Settings.mm1 OrElse
                               button = 2 AndAlso My.Settings.mm2 Then

                                Debug.Print($"xmbup {mhs.flags} {button}")
                                frmMain.TrayIcon.Icon = My.Resources.lightning
                                Task.Run(Sub()
                                             SendMouseInput(MouseEventF.XUp, button) 'inject xmb to activate window
                                             SendMouseInput(MouseEventF.MiddleUp, 0)
                                         End Sub)
                                Return 1

                            End If
                        End If
                End Select
            End If
        End If
        Return CallNextHookEx(HookHandle, nCode, wParam, lParam)
    End Function

    Private mhCallBack As MouseHookCallBack = New MouseHookCallBack(AddressOf MouseProc)
    Private disposedValue As Boolean

    Public Sub HookMouse()
        HookHandle = SetWindowsHookEx(WH_MOUSE_LL, mhCallBack,
            GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0)
        If HookHandle = IntPtr.Zero Then Throw New System.Exception("Mouse hook bab0")
    End Sub

    Public Sub UnhookMouse()
        If HookHandle <> IntPtr.Zero Then
            UnhookWindowsHookEx(HookHandle)
            HookHandle = IntPtr.Zero
        End If
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            UnhookMouse()
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    Protected Overrides Sub Finalize()
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=False)
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
