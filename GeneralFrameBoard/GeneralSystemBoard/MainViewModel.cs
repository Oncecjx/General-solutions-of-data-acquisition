using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralSystemBoard.Tool;
using System.Data;

namespace GeneralSystemBoard
{
    public class MainViewModel
    {

        public ChartValues<ObservableValue> ProductRateValues1 { get; set; }
        public ChartValues<ObservableValue> ProductRateValues2 { get; set; }
        public string[] ProductRateLabels { get; set; }


        public SeriesCollection SeriesTotalNumCollection { get; set; }
        public string[] TotalNumLabels { get; set; }

        public Func<ChartPoint, string> NGNumPointLabel { get; set; }
        public SeriesCollection NGNumSeries { get; set; } = new SeriesCollection();
        

        public SeriesCollection NowMonthCompleteSeriesCollection { get; set; }
        public string[] NowMonthCompleteLabels { get; set; }

        public MainViewModel()
        {
            Random random = new Random();


            #region 生产良品率统计

            ProductRateValues1 = new ChartValues<ObservableValue>();
            for (int i = 0; i < 12; i++)
            {
                ProductRateValues1.Add(new ObservableValue(random.Next(0, 100)));
            }

            ProductRateValues2 = new ChartValues<ObservableValue>();
            for (int i = 0; i < 12; i++)
            {
                ProductRateValues2.Add(new ObservableValue(random.Next(0, 100)));
            }

            ProductRateLabels = new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };

            #endregion


            #region 设备产量统计
            ChartValues<double> totalNum = new ChartValues<double>();
            for (int i = 0; i < 12; i++)
            {
                totalNum.Add(random.Next(0, 200));
            }
            SeriesTotalNumCollection = new SeriesCollection
            {
                new ColumnSeries{   Values = totalNum  }
            };
            TotalNumLabels = new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };

            #endregion



            #region 不良产品统计

            NGNumPointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            string[] NGNumTitle = new string[] { "产品A", "产品B", "产品C", "产品D" };
            string[] NGNumValue = new string[] { "30", "25", "35", "10" };
            for (int i = 0; i < NGNumTitle.Length; i++)
            {
                NGNumSeries.Add(new PieSeries()
                {
                    Title = NGNumTitle[i],
                    Values = new ChartValues<int>()    //Values表示标签的值
                    {
                        Convert.ToInt32(NGNumValue[i])
                    },
                    DataLabels = true,
                    LabelPoint = NGNumPointLabel
                });
            }


            #endregion


            #region 当月完成情况

            NowMonthCompleteSeriesCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "实际完成",
                    Values = new ChartValues<double> { 150, 250, 390, 350 }
                }
            };

            //adding series will update and animate the chart automatically
            NowMonthCompleteSeriesCollection.Add(new RowSeries
            {
                Title = "计划完成",
                Values = new ChartValues<double> { 130, 200, 350, 250 }
            });

            NowMonthCompleteLabels = new[] { "产品A", "产品B", "产品C", "产品D" };


            #endregion


        }
    }
}
