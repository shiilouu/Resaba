namespace Playslip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Info ");
            Console.WriteLine(" ");

            Console.Write("Employee Name: ");
            string userName = Console.ReadLine();

            Console.Write("Department: ");
            string userDepartment = Console.ReadLine();

            Console.Write("Position: ");
            string userPosition = Console.ReadLine();

            Console.Write("First Period | Second Period: ");
            string userPeriod = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Hello " + userName + ", from " + userDepartment + " " + userPosition + "!" + " Here's your Payslip, ");
            Console.WriteLine(" ");
            Console.WriteLine("Total Hours Worked: ");
            Console.WriteLine("Overtime Hours: ");
            Console.WriteLine("Montly Salary Deductions: ");
            Console.WriteLine("SSS (-4.5%)");
            Console.WriteLine("Tax (-10%)");
            Console.WriteLine("Total Salary: ");
        }
    }
}
/*Console.Write("Name");
string name = Console.ReadLine();

Console.Write("Hourly Rates");
decimal hourlyRate = decimal.Parse(Console.ReadLine());

decimal grossPay = (decimal)hoursWorked = hourlyRate;
Console.WriteLine("Payslip");
Console.WriteLine($"Name: {name} ");
} } }*/