# How to Embed a DevExpress Control in the WPF Dashboard

This example demonstrates how to embed a [DevExpress Gantt Control](https://community.devexpress.com/blogs/wpf/archive/2018/10/31/wpf-gantt-control-ctp-v18-2.aspx) in a dashboard loaded in [WPF Viewer](https://docs.devexpress.com/Dashboard/119813) and bind the Gantt control to the dashboard's data. It uses a style selector to substitute a regular dashboard item with an arbitrary WPF control, and handles its SizeChanged event to provide it with data.

![screenshot](https://github.com/DevExpress-Examples/wpf-dashboard-how-to-embed-devexpress-control/blob/18.2.6%2B/images/screenshot.png)

The application displays a sample dashboard [created in Visual Studio ](https://docs.devexpress.com/Dashboard/17519) that contains the [Grid dashboard item](https://docs.devexpress.com/Dashboard/15150) bound to Gantt-specific data (data fields contain hierarchical tasks, start and end values).

The main application's window contains the Gantt control placed in the _ganttStyle_ style included in XAML as a resource. The Gantt control is bound to the window's data context. The GanttControl's **ItemsSource** property is bound to the _GanttTasks_ View Model's property declared in a [POCO View Model](https://docs.devexpress.com/WPF/17352).

The main application's window uses the [DashboardControl.GridItemStyleSelector](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControlBase.GridItemStyleSelector) property to assign the _ganttStyle_ style as the Grid dashboard item's content. The **Gantt control** is rendered and displayed instead of the [GridDashboardItem](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.GridDashboardItem).

The Gantt control's **SizeChanged event** is handled to provide data to the control. The handler code waits until the data is loaded and calls the [DashboardControl.GetItemData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardWpf.DashboardControl.GetItemData(System.String)) method to obtain the [MultiDimensionalData](https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.ViewerData.MultiDimensionalData) object that contains the embedded control's data. The **ConfigureGanttTasks** method converts data to the _ObservableCollection&lt;GanttTask&gt;_ type. The resultant collection is assigned to the _GanttTasks_ View Model's property.

> This approach is not limited to DevExpress data-bound controls and can be used to embed any WPF control in a dashboard.

**See also:**

* [DevExpress WPF Controls Common Concepts](https://docs.devexpress.com/WPF/6794)
* [DevExpress MVVM Framework for WPF](https://docs.devexpress.com/WPF/15112)
* [WPF Dashboard Viewer - Styles and Templates](https://docs.devexpress.com/Dashboard/400142)
* [How to Customize the GridDashboardItem Using Template](https://github.com/DevExpress-Examples/wpf-dashboard-how-to-customize-items-using-templates)
