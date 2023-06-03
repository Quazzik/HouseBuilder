using FastReport;
using FastReport.Export.Image;
using FastReport.Export.PdfSimple;
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

        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Data> reportData = new();
            reportData.Add(new Data { Name = "Общая площадь дома", Value = Convert.ToInt32(Label_CalculateTotalArea.Content) });
            reportData.Add(new Data { Name = "Общая стоимость строительных материалов", Value = Convert.ToInt32(Label_CalculateMaterialCost.Content) });
            reportData.Add(new Data { Name = "Стоимость работы", Value = Convert.ToInt32(Label_CalculateLaborCost.Content) });
            reportData.Add(new Data { Name = "Стоимость всех разрешений", Value = Convert.ToInt32(Label_CalculatePermitCost.Content) });
            reportData.Add(new Data { Name = "Общая стоимость отделочных материалов", Value = Convert.ToInt32(Label_CalculateFinishingCost.Content) });
            reportData.Add(new Data { Name = "Общая стоимость доп. опций", Value = Convert.ToInt32(Label_CalculateOptionCost.Content) });
            reportData.Add(new Data { Name = "общая стоимость строительстваы", Value = Convert.ToInt32(Label_CalculateTotalCost.Content) });
            reportData.Add(new Data { Name = "ежемесячный платеж по кредиту", Value = Convert.ToInt32(Label_CalculateMonthlyPayment.Content) });
            reportData.Add(new Data { Name = "расчёт необходимых накоплений для оплаты строительства + резервный фонд", Value = Convert.ToInt32(Label_CalculateTotalSavingsNeeded.Content) });
            reportData.Add(new Data { Name = "сколько нужно откладывать каждый месяц чтобы скопить сумму к началу строительства", Value = Convert.ToInt32(Label_CalculateMonthlySavings.Content) });
            Report report = new();
            report.Load("Table.frx");
            report.RegisterData(reportData, "Data");
            report.Prepare();

            report.SavePrepared("Prepared_Table.fpx");

            ImageExport image = new();
            image.ImageFormat = ImageExportFormat.Jpeg;
            report.Export(image, "report.jpg");

            PDFSimpleExport pdfExport = new();

            pdfExport.Export(report, "report.pdf");

            report.Dispose();
        }
    }
}
