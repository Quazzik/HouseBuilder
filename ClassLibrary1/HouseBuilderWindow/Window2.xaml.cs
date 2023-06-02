using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace HouseBuilderWindow
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Builder _builder = new Builder();
        public Window2()
        {
            InitializeComponent();
        }
        public Window2(Builder builder) : this() 
        {
            _builder = builder;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Label_CalculateFinishingCost.Content = _builder.CalculateFinishingCost();
            Label_CalculateLaborCost.Content = _builder.CalculateLaborCost();
            Label_CalculateMaterialCost .Content = _builder.CalculateMaterialCost();
            Label_CalculateMonthlyPayment.Content = _builder.CalculateMonthlyPayment();
            Label_CalculateMonthlySavings.Content = _builder.CalculateMonthlySavings();
            Label_CalculateOptionCost.Content = _builder.CalculateOptionCost();
            Label_CalculatePermitCost.Content = _builder.CalculatePermitCost();
            Label_CalculateTotalArea.Content = _builder.CalculateTotalArea();
            Label_CalculateTotalCost.Content = _builder.CalculateTotalCost();
            Label_CalculateTotalSavingsNeeded.Content = _builder.CalculateTotalSavingsNeeded();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
