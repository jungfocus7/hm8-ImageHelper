<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CMainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CMainForm))
        Me._lbl1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._txb1 = New System.Windows.Forms.TextBox()
        Me._txb2 = New System.Windows.Forms.TextBox()
        Me._btnx3 = New ImageHelper.CKxButton()
        Me._btnx1 = New ImageHelper.CKxButton()
        Me._btnx2 = New ImageHelper.CKxButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._btnx4 = New ImageHelper.CKxButton()
        Me._btnx5 = New ImageHelper.CKxButton()
        Me._lstv1 = New ImageHelper.CBumListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        '_lbl1
        '
        Me._lbl1.Location = New System.Drawing.Point(12, 9)
        Me._lbl1.Name = "_lbl1"
        Me._lbl1.Size = New System.Drawing.Size(200, 20)
        Me._lbl1.TabIndex = 8
        Me._lbl1.Text = "■ 이미지 저장 문자열"
        Me._lbl1.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "■ 이미지 목록"
        '
        '_txb1
        '
        Me._txb1.Location = New System.Drawing.Point(12, 33)
        Me._txb1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me._txb1.Multiline = True
        Me._txb1.Name = "_txb1"
        Me._txb1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me._txb1.Size = New System.Drawing.Size(576, 80)
        Me._txb1.TabIndex = 0
        Me._txb1.Visible = False
        Me._txb1.WordWrap = False
        '
        '_txb2
        '
        Me._txb2.Location = New System.Drawing.Point(12, 333)
        Me._txb2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me._txb2.Multiline = True
        Me._txb2.Name = "_txb2"
        Me._txb2.ReadOnly = True
        Me._txb2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me._txb2.Size = New System.Drawing.Size(576, 160)
        Me._txb2.TabIndex = 2
        Me._txb2.WordWrap = False
        '
        '_btnx3
        '
        Me._btnx3.Cursor = System.Windows.Forms.Cursors.Hand
        Me._btnx3.Location = New System.Drawing.Point(12, 538)
        Me._btnx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me._btnx3.Name = "_btnx3"
        Me._btnx3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._btnx3.Size = New System.Drawing.Size(159, 29)
        Me._btnx3.TabIndex = 4
        Me._btnx3.Text = """캡처 도구"" 열기 (F3)"
        Me._btnx3.UseVisualStyleBackColor = True
        '
        '_btnx1
        '
        Me._btnx1.Cursor = System.Windows.Forms.Cursors.Hand
        Me._btnx1.Location = New System.Drawing.Point(408, 501)
        Me._btnx1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me._btnx1.Name = "_btnx1"
        Me._btnx1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._btnx1.Size = New System.Drawing.Size(180, 66)
        Me._btnx1.TabIndex = 6
        Me._btnx1.Text = "클립보드 이미지 저장 (F1)"
        Me._btnx1.UseVisualStyleBackColor = True
        '
        '_btnx2
        '
        Me._btnx2.Cursor = System.Windows.Forms.Cursors.Hand
        Me._btnx2.Location = New System.Drawing.Point(247, 538)
        Me._btnx2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me._btnx2.Name = "_btnx2"
        Me._btnx2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._btnx2.Size = New System.Drawing.Size(155, 29)
        Me._btnx2.TabIndex = 5
        Me._btnx2.Text = "이미지 폴더 열기 (F2)"
        Me._btnx2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 309)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 20)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "■ 결과 출력"
        '
        '_btnx4
        '
        Me._btnx4.Cursor = System.Windows.Forms.Cursors.Hand
        Me._btnx4.Location = New System.Drawing.Point(12, 501)
        Me._btnx4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me._btnx4.Name = "_btnx4"
        Me._btnx4.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._btnx4.Size = New System.Drawing.Size(159, 29)
        Me._btnx4.TabIndex = 3
        Me._btnx4.Text = "Output 비우기 (F4)"
        Me._btnx4.UseVisualStyleBackColor = True
        '
        '_btnx5
        '
        Me._btnx5.Cursor = System.Windows.Forms.Cursors.Hand
        Me._btnx5.Location = New System.Drawing.Point(209, 501)
        Me._btnx5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me._btnx5.Name = "_btnx5"
        Me._btnx5.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._btnx5.Size = New System.Drawing.Size(193, 29)
        Me._btnx5.TabIndex = 17
        Me._btnx5.Text = "폴더에 이미지들 지우기 (F5)"
        Me._btnx5.UseVisualStyleBackColor = True
        '
        '_lstv1
        '
        Me._lstv1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me._lstv1.FullRowSelect = True
        Me._lstv1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me._lstv1.HideSelection = False
        Me._lstv1.Location = New System.Drawing.Point(12, 32)
        Me._lstv1.MultiSelect = False
        Me._lstv1.Name = "_lstv1"
        Me._lstv1.Size = New System.Drawing.Size(576, 264)
        Me._lstv1.TabIndex = 1
        Me._lstv1.UseCompatibleStateImageBehavior = False
        Me._lstv1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "FILE PATH"
        Me.ColumnHeader1.Width = 500
        '
        'CMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 580)
        Me.Controls.Add(Me._btnx5)
        Me.Controls.Add(Me._btnx4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me._lstv1)
        Me.Controls.Add(Me._btnx2)
        Me.Controls.Add(Me._btnx1)
        Me.Controls.Add(Me._btnx3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lbl1)
        Me.Controls.Add(Me._txb1)
        Me.Controls.Add(Me._txb2)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(10, 10)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "CMainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents _lbl1 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents _txb1 As System.Windows.Forms.TextBox
    Private WithEvents _txb2 As System.Windows.Forms.TextBox
    Private WithEvents _btnx3 As CKxButton
    Private WithEvents _btnx1 As CKxButton
    Private WithEvents _btnx2 As CKxButton
    Friend WithEvents _lstv1 As ImageHelper.CBumListView
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents _btnx4 As CKxButton
    Private WithEvents _btnx5 As CKxButton
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader

End Class
