namespace Library;

public class Builder
{
    public List<double> FloorsArea { get; init; }     //площадь этажей
    public uint NumberOfOptions { get; set; }          //количество необходимых доп. опций
    const double unitPrice = 50000;                   //цена за *единицу* здания
    const int quantity = 2;                           //количество таких зданий которые необходимо построить
    const double hourlyRate = 50;                     //почасовая ставка за работу строителей
    const int hoursWorked = 1000;                     //количество часов необходимых для постройки здания
    const double buildingPermitCost = 10000;          //стоимость разрешения на строительство
    const double otherDocumentCosts = 5000;           //стоимость других документов необходимых для строительства
    const double finishingMaterialCost = 20000;       //стоимость отделочных материалов
    const double optionInstallationPrice = 5000;      //стоимость установки одной доп. опции
    const double interestRate = 0.05;                 //процентная стака по кредиту
    const int numberOfMonthsInLoan = 120;             //количество месяцев на которые берется кредит
    const int numberOfMonthsUntilConstruction = 24;   //через сколько месяцев начнется строительство

    public Builder(uint numberOfOptions, List<double> floorsArea = null)
    {
        FloorsArea = floorsArea ?? new();
        NumberOfOptions = numberOfOptions;
    }

    public double CalculateTotalArea() //общая площадь дома
    {
        if (FloorsArea.All(f => f < 0))
        {
            throw new ArgumentException("Floors area cannot be negative");
        }
        return FloorsArea.Sum();
    }

    public double CalculateMaterialCost() => unitPrice * quantity;//общая стоимость строительных материалов

    public double CalculateLaborCost() => hourlyRate * hoursWorked;//стоимость работы

    public double CalculatePermitCost() => buildingPermitCost + otherDocumentCosts;//стоимость всех разрешений

    public double CalculateFinishingCost() => finishingMaterialCost * CalculateTotalArea();//общая стоимость отделочных материалов

    public double CalculateOptionCost() //общая стоимость доп. опций
    {
        if (NumberOfOptions < 0)
        {
            throw new ArgumentException("Values cannot be negative.");
        }
        return optionInstallationPrice * NumberOfOptions;
    }

    public double CalculateTotalCost() => CalculateMaterialCost() + CalculateLaborCost() + CalculatePermitCost() + CalculateFinishingCost() + CalculateOptionCost(); //общая стоимость строительства

    public double CalculateMonthlyPayment() => Math.Ceiling((CalculateTotalCost() * interestRate / numberOfMonthsInLoan) * 100) / 100; //ежемесячный платеж по кредиту


    public double CalculateTotalSavingsNeeded() => CalculateTotalCost() + (CalculateTotalCost() * 0.2); //расчёт необходимых накоплений для оплаты строительства + резервный фонд


    public double CalculateMonthlySavings() => Math.Ceiling((CalculateTotalSavingsNeeded() / numberOfMonthsUntilConstruction) * 100) / 100; //сколько нужно откладывать каждый месяц чтобы скопить сумму к началу строительства

}