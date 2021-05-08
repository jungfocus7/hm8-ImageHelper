Imports System
Imports System.Windows.Forms






Public Class CBumListView : Inherits ListView
    Public Sub New()
        MyBase.New()
        Me.DoubleBuffered = True
    End Sub


    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    Const WM_RBUTTONUP As Integer = &H205
    '    Const WM_RBUTTONDOWN As Integer = &H204
    '    If m.Msg <> WM_RBUTTONDOWN AndAlso m.Msg <> WM_RBUTTONUP Then
    '        MyBase.WndProc(m)
    '    End If
    'End Sub
End Class





Public NotInheritable Class CKxButton : Inherits Button
    Public Sub New()
        Me.Cursor = Cursors.Hand
        Me.SetStyle(ControlStyles.Selectable, False)
    End Sub
End Class





