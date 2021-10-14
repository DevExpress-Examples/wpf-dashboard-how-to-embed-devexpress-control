Imports System
Imports System.Collections.ObjectModel

Namespace Sample

    Public Class DashboardData

        Private _Data As ObservableCollection(Of Sample.DataRecord)

        Public Property Data As ObservableCollection(Of Sample.DataRecord)
            Get
                Return _Data
            End Get

            Private Set(ByVal value As ObservableCollection(Of Sample.DataRecord))
                _Data = value
            End Set
        End Property

        Public Sub New()
            Me.Data = Me.GetData()
        End Sub

        Private Function GetData() As ObservableCollection(Of Sample.DataRecord)
            Dim rnd As System.Random = New System.Random()
            Dim recordList As System.Collections.ObjectModel.ObservableCollection(Of Sample.DataRecord) = New System.Collections.ObjectModel.ObservableCollection(Of Sample.DataRecord)()
            For series As Integer = 1 To 4 - 1
                For argument As Integer = 1 To 5 - 1
                    Dim startDate As System.DateTime = System.DateTime.Now.AddDays(rnd.[Next](10))
                    Dim endDate As System.DateTime = startDate.AddDays(rnd.[Next](5))
                    recordList.Add(New Sample.DataRecord() With {.SubTask = "Sub Task " & argument, .GlobalTask = "Task " & series, .StartDate = startDate, .EndDate = endDate})
                Next
            Next

            Return recordList
        End Function
    End Class

    Public Class DataRecord

        Public Property GlobalTask As String

        Public Property SubTask As String

        Public Property StartDate As DateTime

        Public Property EndDate As DateTime
    End Class
End Namespace
