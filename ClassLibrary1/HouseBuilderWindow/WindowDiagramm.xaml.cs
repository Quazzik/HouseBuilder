using HouseBuilderWindow.ViewModels;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HouseBuilderWindow
{
    /// <summary>
    /// Логика взаимодействия для WindowDiagramm.xaml
    /// </summary>
    public partial class WindowDiagramm : Window
    {
        public WindowDiagramm(Dictionary<string, double> values)
        {
            InitializeComponent();
            DataContext = new ChartViewModel(values);
        }
    }
}