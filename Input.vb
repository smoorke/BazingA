Imports System.Runtime.InteropServices

Module Input
    Private Declare Function SendInput Lib "user32.dll" (nInputs As Integer, pInputs() As INPUT, cbSize As Integer) As UInteger

    Private ReadOnly MouseInpt As INPUT() = {
                   New INPUT With {   '.type = InputType.INPUT_MOUSE, 'INPUT_MOUSE is 0 so we can omit
                                    .mi = New MOUSEINPUT
                                  }
                   }
    <StructLayout(LayoutKind.Explicit)>
    Structure INPUT
        <FieldOffset(0)> Public type As Integer
        <FieldOffset(4)> Public mi As MOUSEINPUT
        <FieldOffset(4)> Public ki As KEYBDINPUT
        <FieldOffset(4)> Public hi As HARDWAREINPUT
    End Structure
    Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As MouseEventF
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure
    <Flags>
    Public Enum MouseEventF
        Move = &H1
        LeftDown = &H2
        LeftUp = &H4
        RightDown = &H8
        RightUp = &H10
        MiddleDown = &H20
        MiddleUp = &H40
        XDown = &H80
        XUp = &H100
        Wheel = &H800
        HWheel = &H1000
        Move_NoCoalece = &H2000
        VirtualDesk = &H4000
        ABSOLUTE = &H8000
    End Enum
    Structure KEYBDINPUT
        Public wVk As UShort
        Public wScan As UShort
        Public dwFlags As KeyEventF
        Public time As Integer
        Public dwExtraInfo As IntPtr
    End Structure
    <Flags>
    Public Enum KeyEventF
        KeyDown = &H0
        ExtendedKey = &H1
        KeyUp = &H2
        Unicode = &H4
        Scancode = &H8
    End Enum
    Structure HARDWAREINPUT
        Public uMsg As Integer
        Public wParamL As Short
        Public wParamH As Short
    End Structure

    Public Sub SendMouseInput(flags As MouseEventF, mouseData As UInt32)
        MouseInpt(0).mi.dwFlags = flags
        MouseInpt(0).mi.mouseData = mouseData
        SendInput(1, MouseInpt, Marshal.SizeOf(GetType(INPUT)))
    End Sub
End Module