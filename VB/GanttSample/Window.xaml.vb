Imports DevExpress.DashboardWpf.Internal
Imports System.Windows
Imports System.Windows.Controls

Namespace Sample

    ''' <summary>
    ''' Interaction logic for Window.xaml
    ''' </summary>
    Public Partial Class Window
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class

    Public Class GanttStyleSelector
        Inherits StyleSelector

        Public Property GanttStyle As Style

        Public Overrides Function SelectStyle(ByVal item As Object, ByVal container As DependencyObject) As Style
            Dim name As String = CType(item, BaseDashboardItemViewModelXpf).DashboardItemName
            Return If(Equals(name, "gridDashboardItem1"), GanttStyle, MyBase.SelectStyle(item, container))
        End Function
    End Class
End Namespace
