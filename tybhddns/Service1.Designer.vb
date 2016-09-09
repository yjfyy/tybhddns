Imports System.ServiceProcess

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Service1
    Inherits System.ServiceProcess.ServiceBase

    'UserService 重写 Dispose，以清理组件列表。
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

    ' 此进程的主入口点
    <MTAThread()>
    <System.Diagnostics.DebuggerNonUserCode()>
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' 同一进程内可运行多个 NT 服务。若要将
        ' 另一个服务添加到此进程中，请更改下行以
        ' 创建另一个服务对象。例如，
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New Service1}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    '组件设计器所必需的
    Private components As System.ComponentModel.IContainer

    ' 注意: 以下过程是组件设计器所必需的
    ' 可使用组件设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Timer1 As System.Windows.Forms.Timer
        Timer1 = New System.Windows.Forms.Timer(Me.components)
        '
        'Timer1
        '
        Timer1.Enabled = True
        Timer1.Interval = 10000
        AddHandler Timer1.Tick, AddressOf Me.Timer1_Tick
        '
        'Service1
        '
        Me.ServiceName = "Service1"

    End Sub
End Class
