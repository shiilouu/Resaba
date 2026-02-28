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

            Console.Write("Position: ");
            string userPosition = Console.ReadLine();

            Console.Write("Department: ");
            string userDepartment = Console.ReadLine();

            Console.Write("Total Hours: ");
            int userTotalHours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Regular Hours: ");
            int userRegHours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Overtime Hours: ");
            int userOTHours = Convert.ToInt32(Console.ReadLine());

            int sum = userTotalHours * 1000;

            Console.WriteLine("Hello " + userName + ", from " + userPosition + " " + userDepartment + "!" + " Here's your Payslip, ");
            Console.WriteLine(" ");
            Console.WriteLine("========================PAYSLIP=========================");
            Console.WriteLine(" ");
            Console.WriteLine("Total Hours Worked: " + userTotalHours );
            Console.WriteLine("Overtime Hours: " + userOTHours);
            Console.WriteLine("Gross: " + sum + " Pesos" );

            Console.WriteLine("==================Montly Salary Deductions==============");
            Console.WriteLine("SSS (-5%)");
            Console.WriteLine("PhilHealth (-2.5%)" );
            Console.WriteLine("PagIbig (-1%)");
            Console.WriteLine("Withholding Tax");
            Console.WriteLine("Total Deduction");
            Console.WriteLine(" ");
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