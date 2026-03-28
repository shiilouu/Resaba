using System.Security.Cryptography.X509Certificates;
using Resaba.Business;
using Resaba.Data;

namespace Playslip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PayslipBusiness business = new PayslipBusiness();
            bool running = true;

            do
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("      PAYSLIP SYSTEM    ");
                Console.WriteLine("========================");
                Console.WriteLine("1. Compute Payslip");
                Console.WriteLine("2. Exit");
                Console.WriteLine("========================");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
            Console.WriteLine(" ");
            Console.WriteLine("=====================Employee Info===================== ");
            Console.WriteLine(" ");

            Console.Write("Employee Name: ");
            string userName = Console.ReadLine();

            Console.Write("Position: ");
            string userPosition = Console.ReadLine();

            Console.Write("Department: ");
            string userDepartment = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("====================Working Hours==================== ");
            Console.WriteLine(" ");

            Console.Write("Total Hours: ");
            int userTotalHours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Regular Hours: ");
            int userRegHours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Overtime Hours: ");
            int userOTHours = Convert.ToInt32(Console.ReadLine());

            Employee emplo = business.GetEmployee(userName, userPosition, userDepartment, userTotalHours, userRegHours, userOTHours);
            
            decimal gross = business.ComputeGross(emplo.TotalHours);
            decimal sss = business.ComputeSSS(gross);
            decimal philhealth = business.ComputePhilHealth(gross);
            decimal pagibig = business.ComputePagIbig(gross);
            decimal withholdingTax = business.ComputeWithholdingTax(gross);
            decimal totalDeduction = business.ComputeTotalDeduction(gross);
            decimal netPay = business.ComputeNetPay(gross);
            
            //int sum = userTotalHours * 1000;
            Console.WriteLine(" ");
            Console.WriteLine("Hello " + emplo.Name + ", from " + emplo.Position + " " + emplo.Department + "! Here's your Payslip:");
            Console.WriteLine(" ");
            Console.WriteLine("=======================PAYSLIP========================");
            Console.WriteLine(" ");
            Console.WriteLine("Total Hours Worked: " + emplo.TotalHours + " Hours");
            Console.WriteLine("Overtime Hours: " + emplo.OvertimeHours + " Hours");
            Console.WriteLine("Gross: " + gross + " Pesos");
            Console.WriteLine(" ");
            Console.WriteLine("=================Montly Salary Deductions=============");
            Console.WriteLine(" ");
            Console.WriteLine("SSS (-5%): " + sss + " Pesos");
            Console.WriteLine("PhilHealth (-2.5%): " + philhealth + " Pesos" );
            Console.WriteLine("PagIbig (-1%): " + pagibig + " Pesos");
            Console.WriteLine("Withholding Tax: " + business.ComputeWithholdingTax(gross) + " Pesos");
            Console.WriteLine("Total Deduction: " + totalDeduction + " Pesos");
            Console.WriteLine("Net Pay: " + netPay + " Pesos");
            Console.WriteLine(" ");
            Console.WriteLine("===========Press Any Key To Return to Menu===========");
            Console.ReadKey();
        }
        else if (choice == "2")
        {
            running = false;
            Console.WriteLine("Goodbye!");
        }
        else
        {
            Console.WriteLine("Invalid Menu Option. Please press any key...");
            Console.ReadKey();
        }
} while (running);
        }
    }
}