#How to Embed DevExpress Control in WPF Dashboard

This example demonstrates how to embed a [DevExpress Gantt Control](https://community.devexpress.com/blogs/wpf/archive/2018/10/31/wpf-gantt-control-ctp-v18-2.aspx) in a dashboard loaded in [WPF Viewer](https://docs.devexpress.com/Dashboard/119813) and bind the Gantt control to the dashboard's data. It uses a style selector to substitute the regular dashboard item with an arbitrary WPF control and handles its SizeChanged event to provide it with data.

![screenshot](https://github.com/DevExpress-Examples/wpf-dashboard-how-to-embed-devexpress-control/blob/18.2.6%2B/images/screenshot.png)

The application displays a sample dashboard [created in Visual Studio ](https://docs.devexpress.com/Dashboard/17519) that contains the [Grid dashboard item](https://docs.devexpress.com/Dashboard/15150) bound to Gantt-specific data (hierarchical tasks, with start and end values). 

The main application's window uses the [DashboardControl.GridItemStyleSelector](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControlBase.GridItemStyleSelector) property to assign the data template with the Gantt control as the Grid dashboard item's content.

The Gantt control's SizeChanged event handler waits until the dashboard view model loads completely and uses the [DashboardControl.GetItemData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.GetItemData(System.String)) method to obtain the [MultiDimensionalData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.ViewerData.MultiDimensionalData). The **ConfigureGanttTasks** method converts data to the _ObservableCollection<GanttTask>_type. The resultant data is the Gantt control's data context.

**See also:**

* [DevExpress WPF Controls Common Concepts](https://docs.devexpress.com/WPF/6794)
* [DevExpress MVVM Framework for WPF](https://docs.devexpress.com/WPF/15112)
* [WPF Dashboard Viewer - Styles and Templates](https://docs.devexpress.com/Dashboard/400142)
* [How to Customize the GridDashboardItem Using Template](https://github.com/DevExpress-Examples/wpf-dashboard-how-to-customize-items-using-templates)