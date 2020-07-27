using System;
using System.Globalization;
using Worker_Contracts.Entitys;
using Worker_Contracts.Entitys.Enums;


namespace Worker_Contracts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter Worker data: ");
            Console.WriteLine("Name: ");
            string workerName = Console.ReadLine();
            Console.WriteLine("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("BaseSalary: R$ ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);

            Worker worker = new Worker(workerName, level, baseSalary, dept);

            Console.WriteLine("How many contracts to this worker? ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine("Enter {0} contract data: ", i);
                Console.WriteLine("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value Per Hour: R$ ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, duration);

                worker.AddContract(contract);
            }

            Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " +
                                worker.Name +
                              " Department: + " +
                              worker.Department.Name +
                              " Income for " + monthAndYear + " : R$ " +
                              worker.Income(month, year)
                );
            

            
        }
    }
}
