Option Explicit On

Imports System
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1

    Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long)
    Private Declare Sub Sleep Lib "kernel32" (ByVal milliseconds As Integer)

    Dim allpuph As Integer
    Dim selectother As Integer
    Dim selectall As Integer
    Dim blinkpuph As Integer

    Private Const VK_CAPITAL = &H14
    Const KEYEVENT_up = &H2
    Const MOUSEEVENTF_RIGHTDOWN = &H8  'Нажать правую кнопку
    Const MOUSEEVENTF_RIGHTUP = &H10  'Отпустить правую кнопку
    Const MOUSEEVENTF_LEFTDOWN = &H2
    Const MOUSEEVENTF_LEFTUP = &H4

    Const F1 = &H70
    Const F2 = &H71
    Const F3 = &H72
    Const F4 = &H73
    Const F5 = &H74
    Const VK_F = &H46
    Const VK_LSHIFT = &HA0

    Const VK_NUMPAD1 = &H61
    Const VK_NUMPAD2 = &H62
    Const VK_NUMPAD4 = &H64
    Const VK_NUMPAD5 = &H65
    Const VK_NUMPAD7 = &H67
    Const VK_NUMPAD8 = &H68

    Public turn As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateContextMenu()
        TextBox1.Text = My.Settings.Allpuph
        TextBox2.Text = My.Settings.Selectother
        TextBox3.Text = My.Settings.Selectall
        TextBox4.Text = My.Settings.Blinkpuph
        TextBox5.Text = My.Settings.ping
    End Sub

    Public Sub CreateContextMenu()

        Dim contextMenu As New ContextMenu
        Dim closemenu As New MenuItem("Закрыть")
        Dim pausemenu As New MenuItem("Пауза/Старт")
        contextMenu.MenuItems.Add(closemenu)
        contextMenu.MenuItems.Add(pausemenu)

        NotifyIcon1.ContextMenu = contextMenu

        AddHandler closemenu.Click, AddressOf closemenu_Click
        AddHandler pausemenu.Click, AddressOf pausemenu_Click

    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub closemenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub pausemenu_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        turn = Not turn
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim allpuph = Convert.ToInt32(My.Settings.Allpuph)
        Dim selectother = Convert.ToInt32(My.Settings.Selectother)
        Dim selectall = Convert.ToInt32(My.Settings.Selectall)
        Dim blinkpuph = Convert.ToInt32(My.Settings.Blinkpuph)

        If turn Then

            Button1.Text = "Отключить"

            If GetAsyncKeyState(allpuph) <> 0 And allpuph <> 0 Then

                Call keybd_event(F1, 0, 0, 0)
                Call keybd_event(F1, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Call keybd_event(F2, 0, 0, 0)
                Call keybd_event(F2, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Call keybd_event(F3, 0, 0, 0)
                Call keybd_event(F3, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Call keybd_event(F4, 0, 0, 0)
                Call keybd_event(F4, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Call keybd_event(F5, 0, 0, 0)
                Call keybd_event(F5, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Sleep(1500)

                SelectMeepo()

            End If

            If GetAsyncKeyState(selectall) <> 0 And selectall <> 0 Then
                SelectMeepo()
            End If

            If GetAsyncKeyState(selectother) <> 0 And selectother <> 0 Then
                Call keybd_event(F2, 0, 0, 0)
                Call keybd_event(F2, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_LSHIFT, 0, 0, 0)
                Call keybd_event(F3, 0, 0, 0)
                Call keybd_event(F3, 0, KEYEVENT_up, 0)
                Call keybd_event(F4, 0, 0, 0)
                Call keybd_event(F4, 0, KEYEVENT_up, 0)
                Call keybd_event(F5, 0, 0, 0)
                Call keybd_event(F5, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_LSHIFT, 0, KEYEVENT_up, 0)
            End If

            If GetAsyncKeyState(blinkpuph) <> 0 And blinkpuph <> 0 Then

                Call keybd_event(F2, 0, 0, 0)
                Call keybd_event(F2, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Call keybd_event(F3, 0, 0, 0)
                Call keybd_event(F3, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Call keybd_event(F4, 0, 0, 0)
                Call keybd_event(F4, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Call keybd_event(F5, 0, 0, 0)
                Call keybd_event(F5, 0, KEYEVENT_up, 0)
                Call keybd_event(VK_F, 0, 0, 0)
                Call keybd_event(VK_F, 0, KEYEVENT_up, 0)

                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Call keybd_event(F1, 0, 0, 0)
                Call keybd_event(F1, 0, KEYEVENT_up, 0)

                If RadioButton1.Checked = True Then
                    Call keybd_event(VK_NUMPAD7, 0, 0, 0)
                    Call keybd_event(VK_NUMPAD7, 0, KEYEVENT_up, 0)
                End If
                If RadioButton2.Checked Then
                    Call keybd_event(VK_NUMPAD8, 0, 0, 0)
                    Call keybd_event(VK_NUMPAD8, 0, KEYEVENT_up, 0)
                End If
                If RadioButton3.Checked Then
                    Call keybd_event(VK_NUMPAD4, 0, 0, 0)
                    Call keybd_event(VK_NUMPAD4, 0, KEYEVENT_up, 0)
                End If
                If RadioButton4.Checked Then
                    Call keybd_event(VK_NUMPAD5, 0, 0, 0)
                    Call keybd_event(VK_NUMPAD5, 0, KEYEVENT_up, 0)
                End If
                If RadioButton5.Checked Then
                    Call keybd_event(VK_NUMPAD1, 0, 0, 0)
                    Call keybd_event(VK_NUMPAD1, 0, KEYEVENT_up, 0)
                End If
                If RadioButton6.Checked Then
                    Call keybd_event(VK_NUMPAD2, 0, 0, 0)
                    Call keybd_event(VK_NUMPAD2, 0, KEYEVENT_up, 0)
                End If

                Sleep(1250)

                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

                Sleep(250)

                SelectMeepo()

            End If

        Else
            My.Settings.Allpuph = TextBox1.Text
            My.Settings.Selectother = TextBox2.Text
            My.Settings.Selectall = TextBox3.Text
            My.Settings.Blinkpuph = TextBox4.Text
            My.Settings.ping = TextBox5.Text

            Button1.Text = "Запустить"
        End If

        Timer1.Interval = Val(TextBox5.Text) + 5

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        turn = Not turn
    End Sub

    Function SelectMeepo()

        Call keybd_event(F1, 0, 0, 0)
        Call keybd_event(F1, 0, KEYEVENT_up, 0)

        Call keybd_event(VK_LSHIFT, 0, 0, 0)
        Call keybd_event(F2, 0, 0, 0)
        Call keybd_event(F2, 0, KEYEVENT_up, 0)
        Call keybd_event(F3, 0, 0, 0)
        Call keybd_event(F3, 0, KEYEVENT_up, 0)
        Call keybd_event(F4, 0, 0, 0)
        Call keybd_event(F4, 0, KEYEVENT_up, 0)
        Call keybd_event(F5, 0, 0, 0)
        Call keybd_event(F5, 0, KEYEVENT_up, 0)
        Call keybd_event(VK_LSHIFT, 0, KEYEVENT_up, 0)

        Return 0
    End Function
End Class
