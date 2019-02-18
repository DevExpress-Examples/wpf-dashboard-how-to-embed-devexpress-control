Namespace Sample
	Partial Public Class Dashboard
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Overloads Sub InitializeComponent()
			Dim dimension1 As New DevExpress.DashboardCommon.Dimension()
			Dim gridDimensionColumn1 As New DevExpress.DashboardCommon.GridDimensionColumn()
			Dim dimension2 As New DevExpress.DashboardCommon.Dimension()
			Dim gridDimensionColumn2 As New DevExpress.DashboardCommon.GridDimensionColumn()
			Dim measure1 As New DevExpress.DashboardCommon.Measure()
			Dim gridMeasureColumn1 As New DevExpress.DashboardCommon.GridMeasureColumn()
			Dim measure2 As New DevExpress.DashboardCommon.Measure()
			Dim gridMeasureColumn2 As New DevExpress.DashboardCommon.GridMeasureColumn()
			Dim objectConstructorInfo1 As New DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo()
			Dim dimension3 As New DevExpress.DashboardCommon.Dimension()
			Dim dashboardLayoutGroup1 As New DevExpress.DashboardCommon.DashboardLayoutGroup()
			Dim dashboardLayoutItem1 As New DevExpress.DashboardCommon.DashboardLayoutItem()
			Dim dashboardLayoutItem2 As New DevExpress.DashboardCommon.DashboardLayoutItem()
			Me.gridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
			Me.dashboardObjectDataSource1 = New DevExpress.DashboardCommon.DashboardObjectDataSource()
			Me.listBoxDashboardItem1 = New DevExpress.DashboardCommon.ListBoxDashboardItem()
			DirectCast(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(measure1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(measure2, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.dashboardObjectDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.listBoxDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' gridDashboardItem1
			' 
			dimension1.DataMember = "GlobalTask"
			gridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
			gridDimensionColumn1.AddDataItem("Dimension", dimension1)
			dimension2.DataMember = "SubTask"
			gridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
			gridDimensionColumn2.AddDataItem("Dimension", dimension2)
			measure1.DataMember = "StartDate"
			measure1.SummaryType = DevExpress.DashboardCommon.SummaryType.Min
			gridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
			gridMeasureColumn1.AddDataItem("Measure", measure1)
			measure2.DataMember = "EndDate"
			measure2.SummaryType = DevExpress.DashboardCommon.SummaryType.Max
			gridMeasureColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
			gridMeasureColumn2.AddDataItem("Measure", measure2)
			Me.gridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() { gridDimensionColumn1, gridDimensionColumn2, gridMeasureColumn1, gridMeasureColumn2})
			Me.gridDashboardItem1.ComponentName = "gridDashboardItem1"
			Me.gridDashboardItem1.DataItemRepository.Clear()
			Me.gridDashboardItem1.DataItemRepository.Add(measure1, "DataItem2")
			Me.gridDashboardItem1.DataItemRepository.Add(measure2, "DataItem1")
			Me.gridDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0")
			Me.gridDashboardItem1.DataItemRepository.Add(dimension2, "DataItem3")
			Me.gridDashboardItem1.DataSource = Me.dashboardObjectDataSource1
			Me.gridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
			Me.gridDashboardItem1.Name = "Grid 1"
			Me.gridDashboardItem1.ShowCaption = True
			' 
			' dashboardObjectDataSource1
			' 
			Me.dashboardObjectDataSource1.ComponentName = "dashboardObjectDataSource1"
			Me.dashboardObjectDataSource1.Constructor = objectConstructorInfo1
			Me.dashboardObjectDataSource1.DataMember = "Data"
			Me.dashboardObjectDataSource1.DataSource = GetType(DashboardData)
			Me.dashboardObjectDataSource1.Name = "Object Data Source 1"
			' 
			' listBoxDashboardItem1
			' 
			Me.listBoxDashboardItem1.ComponentName = "listBoxDashboardItem1"
			dimension3.DataMember = "GlobalTask"
			Me.listBoxDashboardItem1.DataItemRepository.Clear()
			Me.listBoxDashboardItem1.DataItemRepository.Add(dimension3, "DataItem0")
			Me.listBoxDashboardItem1.DataSource = Me.dashboardObjectDataSource1
			Me.listBoxDashboardItem1.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() { dimension3})
			Me.listBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
			Me.listBoxDashboardItem1.Name = "List Box 1"
			Me.listBoxDashboardItem1.ShowCaption = True
			' 
			' Dashboard1
			' 
			Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() { Me.dashboardObjectDataSource1})
			Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() { Me.gridDashboardItem1, Me.listBoxDashboardItem1})
			dashboardLayoutItem1.DashboardItem = Me.gridDashboardItem1
			dashboardLayoutItem1.Weight = 82.793867120954R
			dashboardLayoutItem2.DashboardItem = Me.listBoxDashboardItem1
			dashboardLayoutItem2.Weight = 17.206132879045995R
			dashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() { dashboardLayoutItem1, dashboardLayoutItem2})
			dashboardLayoutGroup1.DashboardItem = Nothing
			dashboardLayoutGroup1.Weight = 100R
			Me.LayoutRoot = dashboardLayoutGroup1
			Me.Title.Text = "Dashboard"
			DirectCast(dimension1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(dimension2, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(measure1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(measure2, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.gridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.dashboardObjectDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(dimension3, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.listBoxDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private dashboardObjectDataSource1 As DevExpress.DashboardCommon.DashboardObjectDataSource
		Private gridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem
		Private listBoxDashboardItem1 As DevExpress.DashboardCommon.ListBoxDashboardItem
	End Class
End Namespace
