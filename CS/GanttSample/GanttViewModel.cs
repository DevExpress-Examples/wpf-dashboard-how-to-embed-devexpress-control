using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.ViewerData;
using DevExpress.DashboardWpf;
using DevExpress.DashboardWpf.Internal;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace Sample {
    public class GanttViewModel : ViewModelBase {
        ObservableCollection<GanttTask> ganttTasks;
        public virtual ObservableCollection<GanttTask> GanttTasks {
            get { return ganttTasks; }
            set {
                if(ganttTasks == value)
                    return;
                ganttTasks = value;
                RaisePropertyChanged("GanttTasks");
            }
        }
        bool IsEmpty { get { return GanttTasks == null; } }

        // The GanttControl.OnSizeChanged event is handled to update the Gantt control.
        public virtual void OnSizeChanged(SizeChangedEventArgs args) {
            if(IsEmpty) {
                DependencyObject source = (DependencyObject)args.OriginalSource;
                DashboardControl dashboardControl = LayoutTreeHelper.GetVisualParents(source).OfType<DashboardControl>().First();
                Action updateGantt = () => {
                    string itemName = GetItemName(source);
                    ConfigureGantt(dashboardControl, itemName);
                };
                dashboardControl.MasterFilterSet += (s, e) => {
                    updateGantt.Invoke();
                };
                updateGantt.Invoke();
            }
        }

        string GetItemName(DependencyObject source) {
            DevExpress.DashboardWpf.DashboardLayoutItem layoutItem = LayoutTreeHelper.GetVisualParents(source).OfType<DevExpress.DashboardWpf.DashboardLayoutItem>().First();
            return ((BaseDashboardItemViewModelXpf)layoutItem.DataContext).DashboardItemName;
        }

        public void ConfigureGantt(DashboardControl dashboardControl, string name) {
            Func<bool> func = () => dashboardControl.DashboardViewModel.GetItemModel(name).IsLoaded;
            // Wait until the dashoard item data is ready and convert the data to the Gantt format.
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
            bool result = false;
            while(!result) {
                var operation = dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, func);
                operation.Wait();
                result = (bool)operation.Result;
            }
            MultiDimensionalData data = dashboardControl.GetItemData(name);
            GanttTasks = ConfigureGanttTasks(data);
        }

        // Converts data from a dashboard data model to the Gantt chart data model.
        ObservableCollection<GanttTask> ConfigureGanttTasks(MultiDimensionalData data) {
            DimensionDescriptorCollection dimensions = data.GetDimensions(DashboardDataAxisNames.DefaultAxis);
            MeasureDescriptorCollection measures = data.GetMeasures();

            ReadOnlyCollection<AxisPoint> gridRows = data.GetAxisPoints(DashboardDataAxisNames.DefaultAxis);
            ObservableCollection<GanttTask> tasks = new ObservableCollection<GanttTask>();
            List<string> keys = new List<string>();
            keys.Add("root");

            foreach(AxisPoint row in gridRows) {
                string parentKey = "root";
                foreach(DimensionDescriptor dimension in dimensions.Cast<DimensionDescriptor>()) {
                    string currentKey = parentKey + "|" + row.GetDimensionValue(dimension).DisplayText;
                    if(keys.Contains(currentKey)) {
                        GanttTask currentTask = tasks.Where(t => t.Id == keys.IndexOf(currentKey)).First();
                        DateTime start = (DateTime)data.GetSlice(row).GetValue(measures[0]).Value;
                        DateTime finish = (DateTime)data.GetSlice(row).GetValue(measures[1]).Value;
                        currentTask.Start = new DateTime(Math.Min(currentTask.Start.Ticks, start.Ticks));
                        currentTask.Finish = new DateTime(Math.Max(currentTask.Finish.Ticks, finish.Ticks));
                    } else {
                        keys.Add(currentKey);
                        data.GetSlice(row).GetValue(measures[0]);
                        tasks.Add(new GanttTask() {
                            Id = keys.IndexOf(currentKey),
                            ParentId = keys.IndexOf(parentKey),
                            Name = row.GetDimensionValue(dimension).DisplayText,
                            Start = (DateTime)data.GetSlice(row).GetValue(measures[0]).Value,
                            Finish = (DateTime)data.GetSlice(row).GetValue(measures[1]).Value
                        });
                    }
                    parentKey = currentKey;
                }
            }
            return tasks;
        }
    }

    public class GanttTask {
        public int Id { get; set; }
        public int ParentId { get; set; } = -1;
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}
