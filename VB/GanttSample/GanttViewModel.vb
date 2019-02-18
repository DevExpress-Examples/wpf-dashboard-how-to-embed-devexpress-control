Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.ViewerData
Imports DevExpress.DashboardWpf
Imports DevExpress.DashboardWpf.Internal
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.UI
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Windows
Imports System.Windows.Threading

Namespace Sample
	Public Class GanttViewModel
		Inherits ViewModelBase

'INSTANT VB NOTE: The variable ganttTasks was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private ganttTasks_Renamed As ObservableCollection(Of GanttTask)
		Public Overridable Property GanttTasks() As ObservableCollection(Of GanttTask)
			Get
				Return ganttTasks_Renamed
			End Get
			Set(ByVal value As ObservableCollection(Of GanttTask))
				If ganttTasks_Renamed Is value Then
					Return
				End If
				ganttTasks_Renamed = value
				RaisePropertyChanged("GanttTasks")
			End Set
		End Property
		Private ReadOnly Property IsEmpty() As Boolean
			Get
				Return GanttTasks Is Nothing
			End Get
		End Property

		' The GanttControl.OnSizeChanged event is handled to update the Gantt control.
		Public Overridable Sub OnSizeChanged(ByVal args As SizeChangedEventArgs)
			If IsEmpty Then
				Dim source As DependencyObject = DirectCast(args.OriginalSource, DependencyObject)
				Dim dashboardControl As DashboardControl = LayoutTreeHelper.GetVisualParents(source).OfType(Of DashboardControl)().First()
				Dim updateGantt As Action = Sub()
					Dim itemName As String = GetItemName(source)
					ConfigureGantt(dashboardControl, itemName)
				End Sub
				AddHandler dashboardControl.MasterFilterSet, Sub(s, e)
					updateGantt.Invoke()
				End Sub
				updateGantt.Invoke()
			End If
		End Sub

		Private Function GetItemName(ByVal source As DependencyObject) As String
			Dim layoutItem As DevExpress.DashboardWpf.DashboardLayoutItem = LayoutTreeHelper.GetVisualParents(source).OfType(Of DevExpress.DashboardWpf.DashboardLayoutItem)().First()
			Return DirectCast(layoutItem.DataContext, BaseDashboardItemViewModelXpf).DashboardItemName
		End Function

		Public Sub ConfigureGantt(ByVal dashboardControl As DashboardControl, ByVal name As String)
			Dim func As Func(Of Boolean) = Function() dashboardControl.DashboardViewModel.GetItemModel(name).IsLoaded
			' Wait until the dashoard item data is ready and convert the data to the Gantt format.
			Dim dispatcher As Dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher
			Dim result As Boolean = False
			Do While Not result
				Dim operation = dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, func)
				operation.Wait()
				result = DirectCast(operation.Result, Boolean)
			Loop
			Dim data As MultiDimensionalData = dashboardControl.GetItemData(name)
			GanttTasks = ConfigureGanttTasks(data)
		End Sub

		' Converts data from a dashboard data model to the Gantt chart data model.
		Private Function ConfigureGanttTasks(ByVal data As MultiDimensionalData) As ObservableCollection(Of GanttTask)
			Dim dimensions As DimensionDescriptorCollection = data.GetDimensions(DashboardDataAxisNames.DefaultAxis)
			Dim measures As MeasureDescriptorCollection = data.GetMeasures()

			Dim gridRows As ReadOnlyCollection(Of AxisPoint) = data.GetAxisPoints(DashboardDataAxisNames.DefaultAxis)
			Dim tasks As New ObservableCollection(Of GanttTask)()
			Dim keys As New List(Of String)()
			keys.Add("root")

			For Each row As AxisPoint In gridRows
				Dim parentKey As String = "root"
				For Each dimension As DimensionDescriptor In dimensions.Cast(Of DimensionDescriptor)()
					Dim currentKey As String = parentKey & "|" & row.GetDimensionValue(dimension).DisplayText
					If keys.Contains(currentKey) Then
						Dim currentTask As GanttTask = tasks.Where(Function(t) t.Id = keys.IndexOf(currentKey)).First()
						Dim start As Date = DirectCast(data.GetSlice(row).GetValue(measures(0)).Value, Date)
						Dim finish As Date = DirectCast(data.GetSlice(row).GetValue(measures(1)).Value, Date)
						currentTask.Start = New Date(Math.Min(currentTask.Start.Ticks, start.Ticks))
						currentTask.Finish = New Date(Math.Max(currentTask.Finish.Ticks, finish.Ticks))
					Else
						keys.Add(currentKey)
						data.GetSlice(row).GetValue(measures(0))
						tasks.Add(New GanttTask() With {.Id = keys.IndexOf(currentKey), .ParentId = keys.IndexOf(parentKey), .Name = row.GetDimensionValue(dimension).DisplayText, .Start = DirectCast(data.GetSlice(row).GetValue(measures(0)).Value, Date), .Finish = DirectCast(data.GetSlice(row).GetValue(measures(1)).Value, Date)})
					End If
					parentKey = currentKey
				Next dimension
			Next row
			Return tasks
		End Function
	End Class

	Public Class GanttTask
		Public Property Id() As Integer
		Public Property ParentId() As Integer = -1
		Public Property Name() As String
		Public Property Start() As Date
		Public Property Finish() As Date
	End Class
End Namespace
