Option Explicit On

Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Public Class Form1

    Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Declare Sub Sleep Lib "kernel32" (ByVal milliseconds As Integer)

    Private Const VK_CAPITAL = &H14
    Const KEYEVENT_up = &H2
    Const MOUSEEVENTF_RIGHTDOWN = &H8  'Нажать правую кнопку
    Const MOUSEEVENTF_RIGHTUP = &H10  'Отпустить правую кнопку
    Const MOUSEEVENTF_LEFTDOWN = &H2
    Const MOUSEEVENTF_LEFTUP = &H4

    Const VK_NUMPAD1 = &H61
    Const VK_NUMPAD2 = &H62
    Const VK_NUMPAD4 = &H64
    Const VK_NUMPAD5 = &H65
    Const VK_NUMPAD7 = &H67
    Const VK_NUMPAD8 = &H68
    Const VK_NUMPAD9 = &H69

    Public ping = 200
    Public tattrib As Integer = 1
    Public turn As Boolean = False

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateContextMenu()
        TextBox1.Text = My.Settings.sila
        TextBox2.Text = My.Settings.lovkost
        TextBox3.Text = My.Settings.intelekt
        TextBox4.Text = My.Settings.ping
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        turn = Not turn
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim sila = My.Settings.sila
        Dim intelekt = My.Settings.intelekt
        Dim lovkost = My.Settings.lovkost

        If turn = True Then

            Button1.Text = "Отключить"

            If GetAsyncKeyState(sila) <> 0 And sila <> 0 Then
                If tattrib = 3 Then usept(2)
                If tattrib = 2 Then usept(1)
                tattrib = 1
            End If

            If GetAsyncKeyState(lovkost) <> 0 And lovkost <> 0 Then
                If tattrib = 1 Then usept(2)
                If tattrib = 3 Then usept(1)
                tattrib = 2
            End If

            If GetAsyncKeyState(intelekt) <> 0 And intelekt <> 0 Then
                If tattrib = 2 Then usept(2)
                If tattrib = 1 Then usept(1)
                tattrib = 3
            End If

        Else
            My.Settings.sila = Convert.ToInt32(TextBox1.Text)
            My.Settings.lovkost = Convert.ToInt32(TextBox2.Text)
            My.Settings.intelekt = Convert.ToInt32(TextBox3.Text)
            My.Settings.ping = Convert.ToInt32(TextBox4.Text)
            Button1.Text = "Запустить"
        End If

    End Sub

    Function usept(attrib)

        Dim int = 0

        While int < attrib
            int += 1

            If RadioButton1.Checked = True Then

                Call keybd_event(VK_NUMPAD7, 0, 0, 0)
                Call keybd_event(VK_NUMPAD7, 0, KEYEVENT_up, 0)

            ElseIf RadioButton2.Checked = True Then

                Call keybd_event(VK_NUMPAD8, 0, 0, 0)
                Call keybd_event(VK_NUMPAD8, 0, KEYEVENT_up, 0)

            ElseIf RadioButton3.Checked = True Then

                Call keybd_event(VK_NUMPAD4, 0, 0, 0)
                Call keybd_event(VK_NUMPAD4, 0, KEYEVENT_up, 0)

            ElseIf RadioButton4.Checked = True Then

                Call keybd_event(VK_NUMPAD5, 0, 0, 0)
                Call keybd_event(VK_NUMPAD5, 0, KEYEVENT_up, 0)

            ElseIf RadioButton5.Checked = True Then

                Call keybd_event(VK_NUMPAD1, 0, 0, 0)
                Call keybd_event(VK_NUMPAD1, 0, KEYEVENT_up, 0)

            ElseIf RadioButton6.Checked = True Then

                Call keybd_event(VK_NUMPAD2, 0, 0, 0)
                Call keybd_event(VK_NUMPAD2, 0, KEYEVENT_up, 0)

            End If

            Sleep(My.Settings.ping)

        End While

        Return 0
    End Function

End Class
