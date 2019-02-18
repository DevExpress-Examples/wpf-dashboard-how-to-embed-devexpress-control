using DevExpress.DashboardWpf.Internal;
using System.Windows;
using System.Windows.Controls;

namespace Sample {
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class Window : System.Windows.Window {
        public Window() {
            InitializeComponent();
        }
    }
    public class GanttStyleSelector : StyleSelector {
        public Style GanttStyle { get; set; }
        public override Style SelectStyle(object item, DependencyObject container) {
            string name = ((BaseDashboardItemViewModelXpf)item).DashboardItemName;
            return name == "gridDashboardItem1" ? GanttStyle : base.SelectStyle(item, container);
        }
    }
}