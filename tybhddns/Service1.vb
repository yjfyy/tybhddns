Imports System.IO

Public Class Service1
    Dim myTimer As New Timers.Timer

    Private sw As StreamWriter
    Private sr As StreamReader
    Public strread() As String

    Protected Overrides Sub OnStart(ByVal args() As String)
        myTimer.Enabled = True
        myTimer.Interval = 30000 ' 时间
        myTimer.Start()
        AddHandler myTimer.Elapsed, AddressOf mytimer_elapsed
        'Timer1.Enabled = True
        'Timer1.Interval = 1000
        'Timer1.Start()
        ' 请在此处添加代码以启动您的服务。此方法应完成设置工作，
        ' 以使您的服务开始工作。
    End Sub

    Protected Overrides Sub OnStop()
        ' 在此处添加代码以执行任何必要的拆解操作，从而停止您的服务。
    End Sub


    Private Sub mytimer_elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs)
        modify_host()
    End Sub

    Public Sub hosts_writer(ByVal parth As String, ByVal str() As String)

        Dim i As Integer
        sw = New StreamWriter(parth, False, System.Text.Encoding.Default)
        For i = 0 To str.Length - 1
            sw.WriteLine(str(i))
            sw.Flush()
        Next
        sw.Close()
        sw = Nothing
    End Sub

    Public Sub modify_host()
        hosts_reader("C:\Windows\System32\drivers\etc\hosts")
        Dim i As Integer = 0
        Dim youtybh As Boolean = False
        For i = 0 To strread.Length - 1
            If strread（i） <> Nothing Then
                If strread(i)(0) = "#" Then

                Else
                    If InStr(strread(i), "tybh.vicp.net") Then
                        youtybh = True

                        Try
                            Dim dFile As New System.Net.WebClient
                            Dim ip = "127.0.0.1"
                            ip = dFile.DownloadString("http://code.taobao.org/svn/BHBnet/trunk/ip/ip.txt")
                            strread(i) = Replace(ip, vbCrLf, "") & "     tybh.vicp.net"
                        Catch ex As Exception

                        End Try
                    End If
                End If
            Else
                strread(i) = "#"

            End If
        Next

        If youtybh = False Then
            ReDim Preserve strread(strread.Length)
            Try
                Dim dFile As New System.Net.WebClient
                Dim ip = "127.0.0.1"
                ip = dFile.DownloadString("http://code.taobao.org/svn/BHBnet/trunk/ip/ip.txt")
                strread(strread.Length - 1) = Replace(ip, vbCrLf, "") & "     tybh.vicp.net"
            Catch ex As Exception

            End Try

        End If

        hosts_writer("C:\Windows\System32\drivers\etc\hosts", strread)
        'hosts_writer("log.txt", strread)
        'strread = Nothing
        'My.Computer.FileSystem.WriteAllText("log.txt", "asdfasdf", True)
    End Sub

    Public Function hosts_reader(ByVal parth As String)
        Dim i As Integer = 0
        Dim s As String
        strread = Nothing

        sr = New StreamReader(parth, System.Text.Encoding.Default)
        Do While sr.Peek() <> -1
            s = sr.ReadLine()
            ReDim Preserve strread(i)

            strread(i) = s
            i = i + 1
        Loop
        sr.Close()
        sr = Nothing

        If i = 0 Then
            ReDim Preserve strread(0)
            strread(0) = "null"
            Return strread

        Else
            Return strread
        End If

    End Function

End Class
