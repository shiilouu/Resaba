using Resaba.Business;
using Resaba.Data;
using Resaba.DataLogic;

namespace Playslip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PayslipDataLogic dataLogic = new PayslipDataLogic(new PayslipDBData());
            PayslipBusiness business = new PayslipBusiness(dataLogic);

            bool running = true;

            do
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("      PAYSLIP SYSTEM    ");
                Console.WriteLine("========================");
                Console.WriteLine("1. Compute Payslip");
                Console.WriteLine("2. View Records");
                Console.WriteLine("3. Exit");
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

                    Console.WriteLine(" ");
                    Console.WriteLine("====================Position====================");
                    Console.WriteLine("1 - Junior");
                    Console.WriteLine("2 - Senior");
                    Console.WriteLine("3 - Manager");
                    Console.Write("Choose Position (1-3): ");
                    int positionChoice = Convert.ToInt32(Console.ReadLine());

                    string userPosition;
                    int userPayGrade;

                    switch (positionChoice)
                    {
                        case 1:
                            userPosition = "Junior";
                            userPayGrade = 1;
                            break;
                        case 2:
                            userPosition = "Senior";
                            userPayGrade = 2;
                            break;
                        case 3:
                            userPosition = "Manager";
                            userPayGrade = 3;
                            break;
                        default:
                            userPosition = "Junior";
                            userPayGrade = 1;
                            break;
                    }

                    Console.WriteLine(" ");
                    Console.WriteLine("====================Department====================");
                    Console.WriteLine("1 - IT (160 hrs)");
                    Console.WriteLine("2 - HR (160 hrs)");
                    Console.WriteLine("3 - Finance (176 hrs)");
                    Console.WriteLine("4 - Marketing (168 hrs)");
                    Console.WriteLine("5 - Operations (176 hrs)");
                    Console.WriteLine("6 - Admin (160 hrs)");
                    Console.Write("Choose Department (1-6): ");
                    int deptChoice = Convert.ToInt32(Console.ReadLine());

                    string userDepartment;
                    int userRegHours;

                    switch (deptChoice)
                    {
                        case 1:
                            userDepartment = "IT";
                            userRegHours = 160;
                            break;
                        case 2:
                            userDepartment = "HR";
                            userRegHours = 160;
                            break;
                        case 3:
                            userDepartment = "Finance";
                            userRegHours = 176;
                            break;
                        case 4: 
                            userDepartment = "Marketing";
                            userRegHours = 168;
                            break;
                        case 5: 
                            userDepartment = "Operations";
                            userRegHours = 176;
                            break;
                        case 6: 
                            userDepartment = "Admin";
                            userRegHours = 160;
                            break;
                        default: 
                            userDepartment = "IT";
                            userRegHours = 160;
                            break;
                    }

                    Console.WriteLine(" ");
                    Console.WriteLine("====================Working Hours====================");
                    Console.WriteLine(" ");
                    Console.Write("Overtime Hours: ");
                    int userOTHours = Convert.ToInt32(Console.ReadLine());

                    int userTotalHours = userRegHours + userOTHours;

                    Console.Write("Number of Unpaid Leaves: ");
                    int userLeaves = Convert.ToInt32(Console.ReadLine());

                    Employee emplo = business.GetEmployee(userName, userPosition, userDepartment, userRegHours, userOTHours, userPayGrade, userLeaves);

                    decimal gross = business.ComputeGross(emplo.RegularHours, emplo.OvertimeHours, emplo.PayGrade, emplo.Leaves);
                    decimal sss = business.ComputeSSS(gross);
                    decimal philhealth = business.ComputePhilHealth(gross);
                    decimal pagibig = business.ComputePagIbig(gross);
                    decimal withholdingTax = business.ComputeWithholdingTax(gross);
                    decimal totalDeduction = business.ComputeTotalDeduction(gross);
                    decimal netPay = business.ComputeNetPay(gross);
                    decimal hourlyRate = business.GetHourlyRate(emplo.PayGrade);

                    emplo.Gross = gross;
                    emplo.SSS = sss;
                    emplo.PhilHealth = philhealth;
                    emplo.PagIbig = pagibig;
                    emplo.WithholdingTax = withholdingTax;
                    emplo.TotalDeduction = totalDeduction;
                    emplo.NetPay = netPay;

                    business.SaveEmployee(emplo);

                    Console.WriteLine(" ");
                    Console.WriteLine("Hello " + emplo.Name + ", from " + emplo.Position + " " + emplo.Department + "! Here's your Payslip:");
                    Console.WriteLine(" ");
                    Console.WriteLine("=======================PAYSLIP========================");
                    Console.WriteLine(" ");
                    Console.WriteLine("Total Hours Worked: " + emplo.TotalHours + " Hours");
                    Console.WriteLine("Regular Hours: " + emplo.RegularHours + " Hours");
                    Console.WriteLine("Overtime Hours: " + emplo.OvertimeHours + " Hours");
                    Console.WriteLine("Unpaid Leaves: " + emplo.Leaves);
                    Console.WriteLine("Hourly Rate: " + hourlyRate + " Pesos/hr");
                    Console.WriteLine("Gross: " + gross + " Pesos");
                    Console.WriteLine(" ");
                    Console.WriteLine("=================Monthly Salary Deductions=============");
                    Console.WriteLine(" ");
                    Console.WriteLine("SSS (-5%): " + sss + " Pesos");
                    Console.WriteLine("PhilHealth (-2.5%): " + philhealth + " Pesos");
                    Console.WriteLine("PagIbig (-1%): " + pagibig + " Pesos");
                    Console.WriteLine("Withholding Tax: " + withholdingTax + " Pesos");
                    Console.WriteLine("Total Deduction: " + totalDeduction + " Pesos");
                    Console.WriteLine(" ");
                    Console.WriteLine("Net Pay: " + netPay + " Pesos");
                    Console.WriteLine(" ");
                    Console.WriteLine("Record saved!");
                    Console.WriteLine("===========Press Any Key To Return to Menu===========");
                    Console.ReadKey();
                }

                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("====================Search Records====================");
                    Console.WriteLine(" ");

                    Console.Write("Enter Name: ");
                    string searchName = Console.ReadLine();

                    Console.WriteLine(" ");
                    Console.WriteLine("====================Position====================");
                    Console.WriteLine("1 - Junior");
                    Console.WriteLine("2 - Senior");
                    Console.WriteLine("3 - Manager");
                    Console.Write("Choose Position (1-3): ");
                    int searchPositionChoice = Convert.ToInt32(Console.ReadLine());

                    string searchPosition;
                    switch (searchPositionChoice)
                    {
                        case 1:
                            searchPosition = "Junior";
                            break;
                        case 2:
                            searchPosition = "Senior";
                            break;
                        case 3:
                            searchPosition = "Manager";
                            break;
                        default:
                            searchPosition = "Junior";
                            break;
                    }

                    Console.WriteLine(" ");
                    Console.WriteLine("====================Department====================");
                    Console.WriteLine("1 - IT");
                    Console.WriteLine("2 - HR");
                    Console.WriteLine("3 - Finance");
                    Console.WriteLine("4 - Marketing");
                    Console.WriteLine("5 - Operations");
                    Console.WriteLine("6 - Admin");
                    Console.Write("Choose Department (1-6): ");
                    int searchDeptChoice = Convert.ToInt32(Console.ReadLine());

                    string searchDepartment;
                    switch (searchDeptChoice)
                    {
                        case 1:
                            searchDepartment = "IT";
                            break;
                        case 2:
                            searchDepartment = "HR";
                            break;
                        case 3:
                            searchDepartment = "Finance";
                            break;
                        case 4:
                            searchDepartment = "Marketing";
                            break;
                        case 5:
                            searchDepartment = "Operations";
                            break;
                        case 6:
                            searchDepartment = "Admin";
                            break;
                        default:
                            searchDepartment = "IT";
                            break;
                    }

                    var records = business.GetEmployees()
                        .Where(e => e.Name.ToLower().Contains(searchName.ToLower())
                            && e.Position == searchPosition
                            && e.Department == searchDepartment)
                        .ToList();

                    Console.Clear();
                    Console.WriteLine("=======================RECORDS========================");

                    if (records.Count == 0)
                    {
                        Console.WriteLine("No records found.");
                    }
                    else
                    {
                        foreach (var r in records)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Name: " + r.Name + " | Position: " + r.Position + " | Dept: " + r.Department);
                            Console.WriteLine("Total Hours: " + r.TotalHours + " | OT Hours: " + r.OvertimeHours + " | Leaves: " + r.Leaves);
                            Console.WriteLine("Gross: " + r.Gross + " | Net Pay: " + r.NetPay);
                            Console.WriteLine("------------------------------------------------------");
                        }
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("===========Press Any Key To Return to Menu===========");
                    Console.ReadKey();
                }
                else if (choice == "3")
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