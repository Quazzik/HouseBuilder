class Program
{
    static void Main(string[] args)
    {
        //инициализация объекта класса Builder
        Builder builder = new Builder();
        bool success;
        double result;
        Console.WriteLine("Enter the number of floors");
        success = int.TryParse(Console.ReadLine(), out int intresult);
        if (success) { builder.CountOfFloor = intresult; } else { Console.WriteLine("Parse exception, default one-storied house used"); builder.CountOfFloor = 1; }

        //считывание от пользователя площади этажей и количества доп.функций
        switch (builder.CountOfFloor)
        {
            case 1:
                {
                    Console.WriteLine("Enter the area of the first floor");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.FirstFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.FirstFloorArea = 120.0; }
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Enter the area of the first floor");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.FirstFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.FirstFloorArea = 120.0; }
                    Console.WriteLine("Enter the area of the remaining floors");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.SecondFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.SecondFloorArea = 80.0; }
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Enter the area of the first floor");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.FirstFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.FirstFloorArea = 120.0; }
                    Console.WriteLine("Enter the area of the remaining floors");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.SecondFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.SecondFloorArea = 80.0; }
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.ThirdFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.ThirdFloorArea = 80.0; }
                    break;
                }
            case 4:
                {
                    Console.WriteLine("Enter the area of the first floor");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.FirstFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.FirstFloorArea = 120.0; }
                    Console.WriteLine("Enter the area of the remaining floors");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.SecondFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.SecondFloorArea = 80.0; }
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.ThirdFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.ThirdFloorArea = 80.0; }
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.FourthFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.FourthFloorArea = 60.0; }
                    break;
                }
            case 5:
                {
                    Console.WriteLine("Enter the area of the first floor");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.FirstFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.FirstFloorArea = 120.0; }
                    Console.WriteLine("Enter the area of the remaining floors");
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.SecondFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.SecondFloorArea = 80.0; }
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.ThirdFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.ThirdFloorArea = 80.0; }
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.FourthFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.FourthFloorArea = 60.0; }
                    success = double.TryParse(Console.ReadLine(), out result);
                    if (success) { builder.FifthFloorArea = result; } else { Console.WriteLine("Parse exception, default value used"); builder.FifthFloorArea = 60.0; }
                    break;
                }
        }
        //если то, что человек ввел в поле не может быть приведено к нужномуу типу данных, программа пишет что это невозможно и устанавливает стандартное значение

        Console.WriteLine("Enter the number of additional options");
        success = int.TryParse(Console.ReadLine(), out intresult);
        if (success) { builder.NumberOfOptions = intresult; } else { Console.WriteLine("Parse exception, default number of options used"); builder.NumberOfOptions = 1; }
        //Проверяем работоспособность всех методов класса
        Console.WriteLine(builder.CalculateTotalArea());
        Console.WriteLine(builder.CalculateMaterialCost());
        Console.WriteLine(builder.CalculateLaborCost());
        Console.WriteLine(builder.CalculatePermitCost());
        Console.WriteLine(builder.CalculateFinishingCost());
        Console.WriteLine(builder.CalculateOptionCost());
        Console.WriteLine(builder.CalculateTotalCost());
        Console.WriteLine(builder.CalculateMonthlyPayment());
        Console.WriteLine(builder.CalculateTotalSavingsNeeded());
        Console.WriteLine(builder.CalculateMonthlySavings());

    }
}