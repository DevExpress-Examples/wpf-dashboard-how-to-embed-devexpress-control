Imports System
Imports System.Collections.ObjectModel

Namespace Sample
	Public Class DashboardData
		Private privateData As ObservableCollection(Of DataRecord)
		Public Property Data() As ObservableCollection(Of DataRecord)
			Get
				Return privateData
			End Get
			Private Set(ByVal value As ObservableCollection(Of DataRecord))
				privateData = value
			End Set
		End Property

		Public Sub New()
			Data = GetData()
		End Sub
		Private Function GetData() As ObservableCollection(Of DataRecord)
			Dim rnd As New Random()
			Dim recordList As New ObservableCollection(Of DataRecord)()
			For series As Integer = 1 To 3
				For argument As Integer = 1 To 4
					Dim startDate As Date = Date.Now.AddDays(rnd.Next(10))
					Dim endDate As Date = startDate.AddDays(rnd.Next(5))
					recordList.Add(New DataRecord() With {.SubTask = "Sub Task " & argument, .GlobalTask = "Task " & series, .StartDate = startDate, .EndDate = endDate})
				Next argument
			Next series
			Return recordList
		End Function
	End Class
	Public Class DataRecord
		Public Property GlobalTask() As String
		Public Property SubTask() As String
		Public Property StartDate() As Date
		Public Property EndDate() As Date
	End Class
End Namespace
