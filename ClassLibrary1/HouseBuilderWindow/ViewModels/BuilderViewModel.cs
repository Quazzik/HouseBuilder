using FastReport;
using FastReport.Export.Image;
using FastReport.Export.PdfSimple;
using HouseBuilderWindow.Models;
using Library;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace HouseBuilderWindow.ViewModels
{
    public class BuilderViewModel : ReactiveObject
    {
        public BuilderViewModel()
        {
            this.WhenAnyValue(vm => vm.FloorsCount).Subscribe( val => {
                var strs = new List<string>();
                Enumerable.Range(1, (int)val).ToList().ForEach(i =>
                {
                    strs.Add($"Enter area of {i} floor: ");
                });

                FloorsGenerator = new(strs.Select(s => new FloorGeneratorModel() { Label = s }));
            });

            CountCommand = ReactiveCommand.Create(Count);
            ReportCommand = ReactiveCommand.Create(CreateReport);
            RefInfoCommand = ReactiveCommand.Create(ShowRefInfo);
            DiagramCommand = ReactiveCommand.Create(ShowDiagram);
        }

        #region Properties
        private uint _numberOfOptions;
        public uint NumberOfOptions
        {
            get => _numberOfOptions;
            set => this.RaiseAndSetIfChanged(ref _numberOfOptions, value);
        }


        private uint _floorsCount;

        public uint FloorsCount
        {
            get => _floorsCount;
            set => this.RaiseAndSetIfChanged(ref _floorsCount, value);
        }

        private double _totalArea;
        public double TotalArea
        {
            get => _totalArea;
            set => this.RaiseAndSetIfChanged(ref _totalArea, value);
        }

        private double _materialCost;
        public double MaterialCost
        {
            get => _materialCost;
            set => this.RaiseAndSetIfChanged(ref _materialCost, value);
        }

        private double _laborCost;
        public double LaborCost
        {
            get => _laborCost;
            set => this.RaiseAndSetIfChanged(ref _laborCost, value);
        }

        private double _permitCost;
        public double PermitCost
        {
            get => _permitCost;
            set => this.RaiseAndSetIfChanged(ref _permitCost, value);
        }

        private double _finishingCost;
        public double FinishingCost
        {
            get => _finishingCost;
            set => this.RaiseAndSetIfChanged(ref _finishingCost, value);
        }

        private double _optionCost;
        public double OptionCost
        {
            get => _optionCost;
            set => this.RaiseAndSetIfChanged(ref _optionCost, value);
        }

        private double _totalCost;
        public double TotalCost
        {
            get => _totalCost;
            set => this.RaiseAndSetIfChanged(ref _totalCost, value);
        }

        private double _monthlyPayment;
        public double MonthlyPayment
        {
            get => _monthlyPayment;
            set => this.RaiseAndSetIfChanged(ref _monthlyPayment, value);
        }

        private double _totalSavingsNeeded;
        public double TotalSavingsNeeded
        {
            get => _totalSavingsNeeded;
            set => this.RaiseAndSetIfChanged(ref _totalSavingsNeeded, value);
        }

        private double _monthlySavings;
        public double MonthlySavings
        {
            get => _monthlySavings;
            set => this.RaiseAndSetIfChanged(ref _monthlySavings, value);
        }

        private ObservableCollection<FloorGeneratorModel> _floorsGenerator;

        public ObservableCollection<FloorGeneratorModel> FloorsGenerator
        {
            get => _floorsGenerator;
            set => this.RaiseAndSetIfChanged(ref _floorsGenerator, value);
        }

        #endregion

        #region Commands
        public ReactiveCommand<Unit, Unit> CountCommand { get; set; }
        private void Count()
        {
            if (!FloorsGenerator.Any())
                return;

            if (!FloorsGenerator.All(g => g.Area != 0))
                return;

            var builder = new Builder(NumberOfOptions, FloorsGenerator.Select(g => g.Area).ToList());

            TotalArea = builder.CalculateTotalArea();
            MaterialCost = builder.CalculateMaterialCost();
            LaborCost = builder.CalculateLaborCost();
            PermitCost = builder.CalculatePermitCost();
            FinishingCost = builder.CalculateFinishingCost();
            OptionCost = builder.CalculateOptionCost();
            TotalCost = builder.CalculateTotalCost();
            MonthlyPayment = builder.CalculateMonthlyPayment();
            TotalSavingsNeeded = builder.CalculateTotalSavingsNeeded();
            MonthlySavings = builder.CalculateMonthlySavings();
        }

        public ReactiveCommand<Unit, Unit> ReportCommand { get; set; }
        private void CreateReport()
        {
            List<Data> reportData = new()
            {
                new Data { Name = "Общая площадь дома", Value = TotalArea },
                new Data { Name = "Общая стоимость строительных материалов", Value = MaterialCost },
                new Data { Name = "Стоимость работы", Value = LaborCost },
                new Data { Name = "Стоимость всех разрешений", Value = PermitCost},
                new Data { Name = "Общая стоимость отделочных материалов", Value = FinishingCost },
                new Data { Name = "Общая стоимость доп. опций", Value = OptionCost },
                new Data { Name = "Общая стоимость строительства", Value = TotalCost },
                new Data { Name = "Ежемесячный платеж по кредиту", Value = MonthlyPayment },
                new Data { Name = "Расчёт необходимых накоплений для оплаты строительства + резервный фонд", Value = TotalSavingsNeeded },
                new Data { Name = "Сколько нужно откладывать каждый месяц чтобы скопить сумму к началу строительства", Value = MonthlySavings }
            };

            if (reportData.Any(d => d.Value <= 0))
            {
                MessageBox.Show("Нет данных для создания отчета.", "Builder", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Report report = new();
            report.Load($"{AppDomain.CurrentDomain.BaseDirectory}/Table.frx");
            report.RegisterData(reportData, "Data");
            report.Prepare();

            string piecePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullPath = Path.GetFullPath(piecePath);

            if (!Directory.Exists($"{fullPath}/reportFolder"))
                Directory.CreateDirectory($"{fullPath}/reportFolder");
            report.SavePrepared($"{fullPath}/reportFolder/Prepared_Table.fpx");

            ImageExport image = new()
            {
                ImageFormat = ImageExportFormat.Jpeg
            };
            report.Export(image, $"{fullPath}/reportFolder/report-{DateTime.Now:d}.jpg");

            PDFSimpleExport pdfExport = new();

            pdfExport.Export(report, $"{fullPath}/reportFolder/report-{DateTime.Now:d}.pdf");

            report.Dispose();
        }

        public ReactiveCommand<Unit, Unit> RefInfoCommand { get; set; }
        private void ShowRefInfo()
        {
            MessageBox.Show("Пользование приложением:\r\n" +
                "1. Для начала нужно ввести в верхнем поле количество этажей для строющегося здания (это количество должно быть от 1 до 10).\r\n" +
                "2. Далее (или после п. 3) нужно ввести количество дополнительных опций, количество которых определяется после согласования проекта с заказчиком (количество дополнительных опций не имеет ограничений)\r\n" +
                "3. Введите площадь каждого этажа дома, начиная с 1-го\r\n" +
                "4. Нажмите кнопку \"Рассчитать\" - после этого вы увидете на полях справа вместе с подписями общую площадь дома, стоимость каждой услуги строительства а также дополнительную информацию, полезную для заказчика\r\n" +
                "5. Далее вы можете сгенерировать отчет в виде PDF-файла, для общей отчетности по работе и для предоставления информации заказчику. Для генерации отчета нажмите кнопку \"Сгенерировать отчет\", отчет появится в PDF-виде по пути: \"Диск ..\":\\Users\\\"Пользователь\"\\AppData\\Roaming\\reportFolder\\report-\"Дата формирования отчета\"\r\n" +
                "6. Вы также можете менять любые поля куда вводили информацию, после изменений снова нажмите кнопку \"Рассчитать\" и изменения вступят в силу - вы увидите новую информацию после всех рассчетов.\r\n" +
                "7. После работы в приложении - для его закрытия - нажмите крестик \"Х\" в правом верхнем углу окна приложения\r\n",
                "Builder", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public ReactiveCommand<Unit,Unit> DiagramCommand { get; set; }
        private void ShowDiagram() 
        {
            var neededPropsNames = new HashSet<string>() { "LaborCost", "PermitCost", "FinishingCost", "OptionCost", "TotalCost" };


            var props = GetType().GetProperties().Where(p => neededPropsNames.Contains(p.Name));

            var propValues = new Dictionary<string, double>(props.Select(p => KeyValuePair.Create(p.Name, (double)p.GetValue(this))));

            if (propValues.Values.Any(v => v <= 0))
            {
                MessageBox.Show("Нет данных для создания диаграммы.", "Builder", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            new WindowDiagramm(propValues).Show();
        }
        #endregion
    }
}
