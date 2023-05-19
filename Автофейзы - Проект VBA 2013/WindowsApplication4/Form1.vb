Public Class Form1

    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Declare Sub Sleep Lib "kernel32" (ByVal milliseconds As Integer)

    Const KEYEVENT_up = &H2
    Const VK_NUMPAD1 = &H61
    Const VK_NUMPAD2 = &H62
    Const VK_NUMPAD4 = &H64
    Const VK_NUMPAD5 = &H65
    Const VK_NUMPAD7 = &H67
    Const VK_NUMPAD8 = &H68
    Const VK_NUMPAD9 = &H69

    Dim turn As Boolean = False
    Public bind As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.bind
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        turn = Not turn
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        bind = My.Settings.bind

        If turn Then

            Button1.Text = "Отключить"

            If GetAsyncKeyState(bind) <> 0 And bind > 0 Then
                If Timer2.Enabled = True Then
                    Timer2.Stop()
                Else
                    Timer2.Interval = 1
                    Timer2.Start()
                End If
            End If

        Else

            Button1.Text = "Запустить"
            My.Settings.bind = Convert.ToInt32(TextBox1.Text)

        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Timer2.Interval = 8400

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

    End Sub
End Class
