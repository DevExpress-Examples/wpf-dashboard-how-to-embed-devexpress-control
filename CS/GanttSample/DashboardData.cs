using System;
using System.Collections.ObjectModel;

namespace Sample {
    public class DashboardData {
        public ObservableCollection<DataRecord> Data { get; private set; }

        public DashboardData() {
            Data = GetData();
        }
        ObservableCollection<DataRecord> GetData() {
            Random rnd = new Random();
            ObservableCollection<DataRecord> recordList = new ObservableCollection<DataRecord>();
            for(int series = 1; series < 4; series++) {
                for(int argument = 1; argument < 5; argument++) {
                    DateTime startDate = DateTime.Now.AddDays(rnd.Next(10));
                    DateTime endDate = startDate.AddDays(rnd.Next(5));
                    recordList.Add(new DataRecord() {
                        SubTask = "Sub Task " + argument,
                        GlobalTask = "Task " + series,
                        StartDate = startDate,
                        EndDate = endDate });
                }
            }
            return recordList;
        }
    }
    public class DataRecord {
        public string GlobalTask { get; set; }
        public string SubTask { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
