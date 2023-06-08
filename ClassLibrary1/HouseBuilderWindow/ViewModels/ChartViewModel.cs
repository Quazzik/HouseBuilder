using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using LiveChartsCore;
using Microsoft.Windows.Themes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HouseBuilderWindow.ViewModels
{
    class ChartViewModel : ReactiveObject
    {
        public ChartViewModel(Dictionary<string, double> values)
        {
            Series = values.ToList().Select(p => new PieSeries
            {
                LabelPoint = PointLabel,
                Values = new List<double> { p.Value }.AsChartValues(),
                DataLabels = true,
                LabelPosition = PieLabelPosition.OutsideSlice,
                Foreground = new SolidColorBrush(Colors.Black),
                Title = p.Key switch
                {
                    "LaborCost" => "Стоимость работы",
                    "PermitCost" => "Стоимость всех разрешений",
                    "FinishingCost" => "Общая стоимость отделочных материалов",
                    "OptionCost" => "Общая стоимость доп. опций",
                    "TotalCost" => "Общая стоимость материавлов",
                    _ => "Unknown"
                }
            }).AsSeriesCollection();
        }

        public Func<ChartPoint, string> PointLabel { get; } = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        private SeriesCollection _series;
        public SeriesCollection Series 
        { 
            get => _series; 
            set => this.RaiseAndSetIfChanged(ref _series, value); 
        }
    }
}
