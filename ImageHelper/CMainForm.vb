Imports System
Imports System.ComponentModel
Imports System.Configuration
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms
Imports System.Text
Imports System.Globalization
Imports System.Linq
Imports System.Collections.Generic







Public NotInheritable Class CMainForm
    Public Shared Sub GcCollect()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub


    Private Shared _btx As Boolean = True
    Public Shared Sub Test(tmsg As String)
        If _btx Then
            Trace.Listeners.Clear()
            Trace.Listeners.Add(New ConsoleTraceListener())
            Trace.Listeners.Add(New TextWriterTraceListener("Logs.txt"))
            Trace.AutoFlush = True
            Trace.WriteLine("File Log")
            _btx = False
        End If
        Trace.WriteLine(tmsg)

        'Debug.WriteLine(">>> 3 " & tr.ToString())
    End Sub






    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Sub pf_Load(tsd As Object, tea As EventArgs) Handles MyBase.Load
        Me.Text = "이미지 도구  ver 1.00c"

        Dim tcs As Screen = Screen.FromPoint(Cursor.Position)
        Dim tcr As Rectangle = tcs.Bounds
        Dim tlp As New Point(tcr.Right, tcr.Bottom)
        Dim tws As Size = Me.Size
        tlp.Offset(-(tws.Width + 40), -(tws.Height + 40))
        Me.Location = tlp



        _mpcdp = Environment.GetCommandLineArgs()(0)
        _mpcdp = Path.GetDirectoryName(_mpcdp)

        _stfs = ConfigurationManager.AppSettings("SaveTimeFormatString")



        '~~~~
        _fsw = New FileSystemWatcher(pf_GetImgDir(), "*.png")
        _fsw.IncludeSubdirectories = False
        '_fsw.WaitForChanged(WatcherChangeTypes.Created Or WatcherChangeTypes.Deleted Or WatcherChangeTypes.Renamed, 15000) '동기실행시사용됨
        _fsw.NotifyFilter = NotifyFilters.FileName
        AddHandler _fsw.Created, _
            Sub(tsd2 As Object, tea2 As FileSystemEventArgs)
                pf_UpdateImageList(True)
            End Sub
        AddHandler _fsw.Deleted, _
            Sub(tsd2 As Object, tea2 As FileSystemEventArgs)
                pf_UpdateImageList(True)
            End Sub
        AddHandler _fsw.Renamed, _
            Sub(tsd2 As Object, tea2 As RenamedEventArgs)
                pf_UpdateImageList(True)
            End Sub
        _fsw.EnableRaisingEvents = True



        pf_ContextMenuSetting()

        pf_UpdateImageList(True)

    End Sub




    ''' <summary>
    ''' Output 출력
    ''' </summary>
    ''' <param name="tmsg"></param>
    ''' <remarks></remarks>
    Private Sub pf_Output(tmsg As String)
        Try
            If Not tmsg Is Nothing Then
                Dim tstr As String = tmsg & vbNewLine
                _txb2.AppendText(tstr)
                Test(tstr)
            Else
                _txb2.Clear()
            End If
        Catch
        End Try
    End Sub



    ''' <summary>
    ''' Base64 디코딩
    ''' </summary>
    ''' <param name="tvrf"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function pf_DecodeBase64Str(tvrf As String) As String
        Try
            Dim tba() As Byte = Convert.FromBase64String(tvrf)
            tvrf = Encoding.Default.GetString(tba)
            Return tvrf
        Catch tex As Exception
            pf_Output(tex.ToString())
        End Try
        Return Nothing
    End Function



    ''' <summary>
    ''' 이미지 경로 가져오기
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function pf_GetImgDir() As String
        Try
            If _isdp Is Nothing Then
                _isdp = Path.Combine(_mpcdp, "__SaveImages")
            End If
            If Not Directory.Exists(_isdp) Then
                Directory.CreateDirectory(_isdp)
            End If
            Return _isdp
        Catch tex As Exception
            pf_Output(tex.ToString())
        End Try
        Return Nothing
    End Function



    ''' <summary>
    ''' 파일 목록 업데이트
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub pf_UpdateImageList(tba As Boolean)
        Dim tact As Action = _
            Sub()
                Try
                    If tba Then
                        pf_UpdateImageList(False)
                        Dim tfpa() As String = Directory.GetFiles( _
                            pf_GetImgDir(), "*.png", SearchOption.TopDirectoryOnly)
                        If Not tfpa Is Nothing AndAlso tfpa.Length > 0 Then
                            Dim tarr() As ListViewItem = tfpa.Select( _
                                Function(tx As String) As ListViewItem
                                    Return New ListViewItem(tx)
                                End Function).ToArray()
                            Dim tli As Integer = tarr.Length
                            If tli > 0 Then
                                tli -= 1
                            End If
                            _lstv1.Items.AddRange(tarr)
                            _lstv1.EnsureVisible(tli)
                            _lstv1.Items(tli).Selected = True
                            _lstv1.Select()
                        End If
                    Else
                        _lstv1.Items.Clear()
                    End If
                Catch tex As Exception
                    pf_Output(tex.ToString())
                End Try
            End Sub

        If Me.InvokeRequired Then
            Me.Invoke(tact)
        Else
            tact()
        End If
    End Sub



    Protected Overrides Sub OnKeyDown(tea As KeyEventArgs)
        MyBase.OnKeyDown(tea)

        Select Case tea.KeyCode
            Case Keys.F1
                pf_btnx1_Click(Nothing, Nothing)
            Case Keys.F2
                pf_btnx2_Click(Nothing, Nothing)
            Case Keys.F3
                pf_btnx3_Click(Nothing, Nothing)
            Case Keys.F4
                pf_btnx4_Click(Nothing, Nothing)
            Case Keys.F5
                pf_btnx5_Click(Nothing, Nothing)
            Case Keys.F6

        End Select
    End Sub



    Private Sub pf_ContextMenuSetting()
        Dim tcms As New ContextMenuStrip()

        Dim ttsmi1 As New ToolStripMenuItem("파일 보기")
        AddHandler ttsmi1.Click, _
            Sub(tsd As Object, tea As EventArgs)
                Try
                    Dim tlvi As ListViewItem = _lstv1.FocusedItem
                    If Not tlvi Is Nothing Then
                        Dim tfp As String = tlvi.Text
                        Process.Start(tfp)
                    End If
                Catch tex As Exception
                    pf_Output(tex.ToString())
                End Try
            End Sub
        tcms.Items.Add(ttsmi1)

        Dim ttsmi2 As New ToolStripMenuItem("파일 위치 열기")
        AddHandler ttsmi2.Click, _
            Sub(tsd As Object, tea As EventArgs)
                Try
                    Dim tlvi As ListViewItem = _lstv1.FocusedItem
                    If Not tlvi Is Nothing Then
                        Dim tfp As String = tlvi.Text
                        Process.Start("explorer.exe", "/select, " + tfp)
                    End If
                Catch tex As Exception
                    pf_Output(tex.ToString())
                End Try
            End Sub
        tcms.Items.Add(ttsmi2)

        _lstv1.ContextMenuStrip = tcms

    End Sub






    '~~~ MainProcessCurrentDirectoryPath
    Private _mpcdp As String

    '~~~ SaveTimeFormatString
    Private _stfs As String


    '~~~ ImageSaveDirectoryPath
    Private _isdp As String

    '~~~ FilePath1
    Private _fp1 As String

    '~~~ FileSystemWatcher
    Private _fsw As FileSystemWatcher








    ''' <summary>
    ''' 폴더에 이미지들 비우기
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pf_btnx5_Click(tsd As Object, tea As EventArgs) Handles _btnx5.Click
        Try
            Dim tfpa() As String = Directory.GetFiles(_isdp, "*.png", SearchOption.TopDirectoryOnly)
            For Each tfp As String In tfpa
                Try
                    File.SetAttributes(tfp, FileAttributes.Normal)
                    File.Delete(tfp)
                Catch
                End Try
            Next
        Catch tex As Exception
            pf_Output(tex.ToString())
        End Try
    End Sub



    ''' <summary>
    ''' Output 비우기
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pf_btnx4_Click(tsd As Object, tea As EventArgs) Handles _btnx4.Click
        pf_Output(Nothing)
    End Sub






    Private Sub pf_CaptureImageUpdate(timg As Image)
        Try
            If Not timg Is Nothing Then
                Dim txb As String = DateTime.Now.ToString(_stfs, CultureInfo.InvariantCulture)
                Dim txc As String = txb & ".png"
                Dim tifp As String = Path.Combine(pf_GetImgDir(), txc)
                timg.Save(tifp)
                pf_Output("[Success] " & txc)
                GcCollect()
            Else
                pf_Output("[Error] 클립보드에 이미지가 없음")
            End If
        Catch tex As Exception
            pf_Output("[Error] " & tex.ToString())
        End Try
    End Sub

    Private Sub pf_ScreenCallback(targs As Object())
        Dim timg As Image = CType(targs(0), Image)
        pf_CaptureImageUpdate(timg)
    End Sub
    Private Sub pf_ShowScreenForm()
        Me.Opacity = 0.0
        Dim tssf As New CScreenForm(AddressOf pf_ScreenCallback)
        tssf.ShowDialog(Me)
        Me.Opacity = 1.0
    End Sub



    ''' <summary>
    ''' 캡처 도구 열기
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pf_btnx3_Click(tsd As Object, tea As EventArgs) Handles _btnx3.Click
        pf_ShowScreenForm()
    End Sub



    ''' <summary>
    ''' 이미지 폴더 열기
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pf_btnx2_Click(tsd As Object, tea As EventArgs) Handles _btnx2.Click
        Try
            Process.Start("explorer", pf_GetImgDir())
        Catch tex As Exception
            pf_Output(tex.ToString())
        End Try
    End Sub



    ''' <summary>
    ''' 클립보드 이미지 저장
    ''' </summary>
    ''' <param name="tsd"></param>
    ''' <param name="tea"></param>
    ''' <remarks></remarks>
    Private Sub pf_btnx1_Click(tsd As Object, tea As EventArgs) Handles _btnx1.Click
        pf_CaptureImageUpdate(Clipboard.GetImage())
    End Sub



End Class
















































Public NotInheritable Class CScreenForm : Inherits Form
    ''' <summary>
    ''' 생성자
    ''' </summary>
    ''' <param name="tactcb"></param>
    ''' <remarks></remarks>
    Public Sub New(tactcb As Action(Of Object()))
        _actcb = tactcb
        _rctrt = Screen.GetBounds(Cursor.Position)

        pf_InitOnce()
    End Sub
    Private Sub pf_InitOnce()
        Me.SuspendLayout()
        Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = _rctrt.Size
        Me.Location = New Point(0, 0)
        Me.Font = New Font("맑은 고딕", 9.0!, FontStyle.Regular, GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New Padding(3, 4, 3, 4)
        Me.StartPosition = FormStartPosition.Manual
        Me.TopMost = True
        Me.WindowState = FormWindowState.Normal
        Me.Cursor = Cursors.Cross
        Me.TabStop = False
        Me.ShowInTaskbar = False
        'Me.Bounds = _rctrt
        Me.ResumeLayout(False)

        Me.SetStyle( _
            ControlStyles.OptimizedDoubleBuffer Or _
            ControlStyles.AllPaintingInWmPaint Or _
            ControlStyles.UserPaint, True)

        pf_UpdateCaptureImage()
    End Sub


    '~~ ActionCallback
    Private _actcb As Action(Of Object())

    '~~
    Private _rctrt As Rectangle

    '~~ ScreenImage
    Private _img As Image

    '~~ MouseDragArea 
    Private _rct As Rectangle

    '~~ BooleanMouseDown
    Private _bmd As Boolean




    Private Sub pf_Callback(targs() As Object)
        If Not _actcb Is Nothing Then
            _actcb(targs)
        End If
    End Sub



    Protected Overrides Sub OnClosing(tea As CancelEventArgs)
        If Not _actcb Is Nothing Then
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()

            _actcb = Nothing
        End If

        MyBase.OnClosing(tea)
    End Sub



    Protected Overrides Sub OnLoad(tea As EventArgs)
        MyBase.OnLoad(tea)

        Me.Activate()
    End Sub



    Private _bcd As Boolean = False
    Private Sub pf_CloseCore(tdr As DialogResult)
        If Not _bcd Then
            _bcd = True

            Me.DialogResult = tdr
            Me.Close()
        End If
    End Sub



    Protected Overrides Sub OnDeactivate(tea As EventArgs)
        MyBase.OnDeactivate(tea)

        pf_CloseCore(DialogResult.Cancel)
    End Sub



    Protected Overrides Function ProcessCmdKey(ByRef tmsg As Message, tkd As Keys) As Boolean
        If tkd = Keys.Escape Then
            pf_CloseCore(DialogResult.Cancel)
        End If

        Return MyBase.ProcessCmdKey(tmsg, tkd)
    End Function



    Private Function pf_GetScreenBitmap() As Image
        Dim tbmp As New Bitmap(_rctrt.Width, _rctrt.Height, PixelFormat.Format32bppArgb)
        Using tg As Graphics = Graphics.FromImage(tbmp)
            tg.CopyFromScreen(_rctrt.Left, _rctrt.Top, 0, 0, _rctrt.Size)
        End Using

        Return tbmp
    End Function
    Private Sub pf_UpdateCaptureImage()
        Try
            _img.Dispose()
        Catch
        End Try
        _img = pf_GetScreenBitmap()

        Me.BackgroundImage = _img
    End Sub



    Private Shared Sub pf_DrawBorder(tg As Graphics, tr As Rectangle, tc As Color, tlw As Integer, tbbs As ButtonBorderStyle)
        tg.InterpolationMode = InterpolationMode.Default
        tg.SmoothingMode = SmoothingMode.Default

        tr.Inflate(tlw, tlw)
        CMainForm.Test(">>> 3 " & tr.ToString())
        ControlPaint.DrawBorder(tg, tr, _
            tc, tlw, tbbs, _
            tc, tlw, tbbs, _
            tc, tlw, tbbs, _
            tc, tlw, tbbs)
    End Sub
    Protected Overrides Sub OnPaint(tea As PaintEventArgs)
        MyBase.OnPaint(tea)

        Dim tg As Graphics = tea.Graphics
        Dim trg As New Region(New RectangleF(New Point(0, 0), Me.Size))
        If Not _rct = Rectangle.Empty Then
            Dim tc As Color = Color.FromArgb(255, Color.Red)
            CMainForm.Test(">>> 1 " & _rct.ToString())
            pf_DrawBorder(tg, _rct, tc, 4, ButtonBorderStyle.Dashed)
            CMainForm.Test(">>> 2 " & _rct.ToString())

            trg.Xor(_rct)
        End If
        tg.FillRegion(New SolidBrush(Color.FromArgb(100, 200, 200, 200)), trg)
    End Sub



    Private Sub pf_DrawUpdate()
        Invalidate()
        Update()
        Refresh()
    End Sub



    Private Function pf_GetFragmentedBitmap() As Image
        Try
            Dim tr2 As Rectangle = _
                Rectangle.FromLTRB( _
                    Math.Min(_rct.Left, _rct.Right), _
                    Math.Min(_rct.Top, _rct.Bottom), _
                    Math.Max(_rct.Left, _rct.Right), _
                    Math.Max(_rct.Top, _rct.Bottom))
            Debug.WriteLine(">>> _rct >> " & _rct.ToString())
            Debug.WriteLine(">>> tr2 >> " & tr2.ToString())
            Dim tbmp As Bitmap = New Bitmap(tr2.Width, tr2.Height, _img.PixelFormat)
            Using tg As Graphics = Graphics.FromImage(tbmp)
                tg.DrawImage(_img, 0, 0, tr2, GraphicsUnit.Pixel)
            End Using

            Return tbmp
        Catch tex As Exception
            CMainForm.Test(tex.ToString())
        End Try

        Return Nothing
    End Function
    Protected Overrides Sub OnMouseUp(tea As MouseEventArgs)
        If Not tea Is Nothing Then
            MyBase.OnMouseUp(tea)
        End If

        If _bmd Then
            _bmd = False
            If Not _actcb Is Nothing Then
                Dim timg As Image = pf_GetFragmentedBitmap()
                _actcb({timg})
            End If
            pf_CloseCore(DialogResult.Yes)
        End If
    End Sub



    Protected Overrides Sub OnMouseCaptureChanged(tea As EventArgs)
        MyBase.OnMouseCaptureChanged(tea)

        OnMouseUp(Nothing)
    End Sub



    Protected Overrides Sub OnMouseMove(tea As MouseEventArgs)
        MyBase.OnMouseMove(tea)

        If _bmd Then
            _rct.Width = tea.X - _rct.Left
            _rct.Height = tea.Y - _rct.Top
            pf_DrawUpdate()
        End If
    End Sub



    Protected Overrides Sub OnMouseDown(tea As MouseEventArgs)
        MyBase.OnMouseDown(tea)

        If Not _bmd Then
            _bmd = True
            _rct = New Rectangle(tea.X, tea.Y, 0, 0)
            OnMouseMove(tea)
        End If
    End Sub








End Class

