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

            bool exitProgram = false;

            do
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("      PAYSLIP SYSTEM    ");
                Console.WriteLine("========================");
                Console.WriteLine("1. View Payslip Record");
                Console.WriteLine("2. HR Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine("========================");
                Console.Write("Choose an option: ");

                string mainChoice = Console.ReadLine();

                if (mainChoice == "1")
                {
                    Console.Clear();
                    Console.WriteLine("====================View Payslip Record====================");
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
                    Console.WriteLine("=======================YOUR PAYSLIP========================");

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

                else if (mainChoice == "2")
                {
                    bool loggedIn = false;
                    int attempts = 0;

                    while (!loggedIn && attempts < 3)
                    {
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("       HR LOGIN         ");
                        Console.WriteLine("========================");

                        Console.Write("Username: ");
                        string username = Console.ReadLine();

                        Console.Write("Password: ");
                        string password = Console.ReadLine();

                        if (username == "hr" && password == "hr123")
                        {
                            loggedIn = true;

                            Console.WriteLine(" ");
                            Console.WriteLine("Login successful!");
                            Console.WriteLine(" ");
                            Console.WriteLine("=================Welcome to HR===================");
                            Console.WriteLine(" ");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            attempts++;

                            Console.WriteLine(" ");
                            Console.WriteLine("Invalid credentials. Attempts left: " + (3 - attempts));
                            Console.WriteLine("Press any key to try again...");
                            Console.ReadKey();
                        }
                    }

                    if (!loggedIn)
                    {
                        Console.Clear();
                        Console.WriteLine("Too many failed attempts.");
                        Console.WriteLine(" ");
                        Console.WriteLine("=========================================");
                        Console.WriteLine("       Returning to main menu...         ");
                        Console.WriteLine("=========================================");
                        Console.WriteLine(" ");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    bool hrLoggedIn = true;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("========================");
                        Console.WriteLine("       HR MENU          ");
                        Console.WriteLine("========================");
                        Console.WriteLine("1. Compute Payslip");
                        Console.WriteLine("2. View Records");
                        Console.WriteLine("3. Edit Record");
                        Console.WriteLine("4. Delete Record");
                        Console.WriteLine("5. Logout");
                        Console.WriteLine("========================");
                        Console.Write("Choose an option: ");

                        string hrChoice = Console.ReadLine();

                        if (hrChoice == "1")
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("======================Employee Info===================== ");
                            Console.WriteLine(" ");

                            Console.Write("Employee Name: ");
                            string userName = Console.ReadLine();

                            Console.WriteLine(" ");
                            Console.WriteLine("=====================Position====================");
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
                            Console.WriteLine("=====================Department====================");
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
                            Console.WriteLine("=====================Working Hours====================");
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
                            Console.WriteLine("========================PAYSLIP========================");
                            Console.WriteLine(" ");
                            Console.WriteLine("Total Hours Worked: " + emplo.TotalHours + " Hours");
                            Console.WriteLine("Regular Hours: " + emplo.RegularHours + " Hours");
                            Console.WriteLine("Overtime Hours: " + emplo.OvertimeHours + " Hours");
                            Console.WriteLine("Unpaid Leaves: " + emplo.Leaves);
                            Console.WriteLine("Hourly Rate: " + hourlyRate + " Pesos/hr");
                            Console.WriteLine("Gross: " + gross + " Pesos");
                            Console.WriteLine(" ");
                            Console.WriteLine("==================Monthly Salary Deductions=============");
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
                            Console.WriteLine("============Press Any Key To Return to Menu============");
                            Console.ReadKey();
                        }

                        else if (hrChoice == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("====================Search Records====================");
                            Console.WriteLine(" ");

                            Console.Write("Enter Name: ");
                            string searchName = Console.ReadLine();

                            Console.WriteLine(" ");
                            Console.WriteLine("====================Position=====================");
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
                            Console.WriteLine("=====================Department====================");
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
                            Console.WriteLine("=======================RECORDS=========================");

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

                        else if (hrChoice == "3")
                        {
                            Console.Clear();
                            Console.WriteLine("====================Edit Record====================");
                            Console.WriteLine(" ");

                            Console.Write("Enter Employee Name to edit: ");
                            string editName = Console.ReadLine();

                            var employeeToEdit = business.GetEmployees()
                                .FirstOrDefault(e => e.Name.ToLower() == editName.ToLower());

                            if (employeeToEdit == null)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("No record found with that name.");
                                Console.WriteLine("Press any key to return to menu...");
                                Console.ReadKey();
                                continue;
                            }

                            Console.WriteLine(" ");
                            Console.WriteLine("Editing record for: " + employeeToEdit.Name);
                            Console.WriteLine("(Press ENTER to keep current value)");

                            Console.WriteLine(" ");
                            Console.WriteLine("====================Position====================");
                            Console.WriteLine("Current Position: " + employeeToEdit.Position);
                            Console.WriteLine("1 - Junior");
                            Console.WriteLine("2 - Senior");
                            Console.WriteLine("3 - Manager");
                            Console.Write("New Position (or ENTER to skip): ");
                            string posInput = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(posInput))
                            {
                                int posChoice = Convert.ToInt32(posInput);

                                switch (posChoice)
                                {
                                    case 1:
                                        employeeToEdit.Position = "Junior";
                                        employeeToEdit.PayGrade = 1;
                                        break;
                                    case 2:
                                        employeeToEdit.Position = "Senior";
                                        employeeToEdit.PayGrade = 2;
                                        break;
                                    case 3:
                                        employeeToEdit.Position = "Manager";
                                        employeeToEdit.PayGrade = 3;
                                        break;
                                }
                            }

                            Console.WriteLine(" ");
                            Console.WriteLine("====================Department====================");
                            Console.WriteLine("Current Department: " + employeeToEdit.Department);
                            Console.WriteLine("1 - IT");
                            Console.WriteLine("2 - HR");
                            Console.WriteLine("3 - Finance");
                            Console.WriteLine("4 - Marketing");
                            Console.WriteLine("5 - Operations");
                            Console.WriteLine("6 - Admin");
                            Console.Write("New Department (or ENTER to skip): ");
                            string deptInput = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(deptInput))
                            {
                                int deptChoice = Convert.ToInt32(deptInput);

                                switch (deptChoice)
                                {
                                    case 1:
                                        employeeToEdit.Department = "IT";
                                        employeeToEdit.RegularHours = 160;
                                        break;
                                    case 2:
                                        employeeToEdit.Department = "HR";
                                        employeeToEdit.RegularHours = 160;
                                        break;
                                    case 3:
                                        employeeToEdit.Department = "Finance";
                                        employeeToEdit.RegularHours = 176;
                                        break;
                                    case 4:
                                        employeeToEdit.Department = "Marketing";
                                        employeeToEdit.RegularHours = 168;
                                        break;
                                    case 5:
                                        employeeToEdit.Department = "Operations";
                                        employeeToEdit.RegularHours = 176;
                                        break;
                                    case 6:
                                        employeeToEdit.Department = "Admin";
                                        employeeToEdit.RegularHours = 160;
                                        break;
                                }
                            }

                            Console.WriteLine(" ");
                            Console.WriteLine("====================Working Hours====================");
                            Console.WriteLine(" ");
                            Console.Write("Current OT Hours: " + employeeToEdit.OvertimeHours + ". New OT Hours (or ENTER to skip): ");
                            string otInput = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(otInput))
                                employeeToEdit.OvertimeHours = Convert.ToInt32(otInput);

                            Console.Write("Current Leaves: " + employeeToEdit.Leaves + ". New Leaves (or ENTER to skip): ");
                            string leavesInput = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(leavesInput))
                                employeeToEdit.Leaves = Convert.ToInt32(leavesInput);

                            employeeToEdit.TotalHours = employeeToEdit.RegularHours + employeeToEdit.OvertimeHours;

                            decimal newGross = business.ComputeGross(employeeToEdit.RegularHours, employeeToEdit.OvertimeHours, employeeToEdit.PayGrade, employeeToEdit.Leaves);
                            decimal newSSS = business.ComputeSSS(newGross);
                            decimal newPhilHealth = business.ComputePhilHealth(newGross);
                            decimal newPagIbig = business.ComputePagIbig(newGross);
                            decimal newWithholdingTax = business.ComputeWithholdingTax(newGross);
                            decimal newTotalDeduction = business.ComputeTotalDeduction(newGross);
                            decimal newNetPay = business.ComputeNetPay(newGross);

                            employeeToEdit.Gross = newGross;
                            employeeToEdit.SSS = newSSS;
                            employeeToEdit.PhilHealth = newPhilHealth;
                            employeeToEdit.PagIbig = newPagIbig;
                            employeeToEdit.WithholdingTax = newWithholdingTax;
                            employeeToEdit.TotalDeduction = newTotalDeduction;
                            employeeToEdit.NetPay = newNetPay;

                            business.UpdateEmployee(employeeToEdit);

                            Console.WriteLine(" ");
                            Console.WriteLine("Record updated successfully!");
                            Console.WriteLine("New Net Pay: " + employeeToEdit.NetPay + " Pesos");
                            Console.WriteLine(" ");
                            Console.WriteLine("===========Press Any Key To Return to Menu===========");
                            Console.ReadKey();
                        }

                        else if (hrChoice == "4")
                        {
                            Console.Clear();
                            Console.WriteLine("====================Delete Record====================");
                            Console.WriteLine(" ");

                            Console.Write("Enter Employee Name to delete: ");
                            string deleteName = Console.ReadLine();

                            var employeeToDelete = business.GetEmployees()
                                .FirstOrDefault(e => e.Name.ToLower() == deleteName.ToLower());

                            if (employeeToDelete == null)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("No record found with that name.");
                                Console.WriteLine("Press any key to return to menu...");
                                Console.ReadKey();
                                continue;
                            }

                            Console.WriteLine(" ");
                            Console.WriteLine("====================Record Found====================");
                            Console.WriteLine(" ");
                            Console.WriteLine("Name: " + employeeToDelete.Name);
                            Console.WriteLine("Position: " + employeeToDelete.Position);
                            Console.WriteLine("Department: " + employeeToDelete.Department);
                            Console.WriteLine("Net Pay: " + employeeToDelete.NetPay + " Pesos");

                            Console.WriteLine(" ");
                            Console.Write("Are you sure you want to delete this record? (Y/N): ");
                            string confirm = Console.ReadLine();

                            if (confirm.ToLower() == "y")
                            {
                                business.DeleteEmployee(employeeToDelete.Name);

                                Console.WriteLine(" ");
                                Console.WriteLine("Record deleted successfully!");
                            }
                            else
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Delete cancelled.");
                            }

                            Console.WriteLine(" ");
                            Console.WriteLine("===========Press Any Key To Return to Menu===========");
                            Console.ReadKey();
                        }

                        else if (hrChoice == "5")
                        {
                            hrLoggedIn = false;
                            Console.WriteLine("Logging out...");
                            Console.WriteLine("Press any key to return to main menu...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Menu Option. Please press any key...");
                            Console.ReadKey();
                        }
                    } while (hrLoggedIn);
                }

                else if (mainChoice == "3")
                {
                    exitProgram = true;
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid Menu Option. Please press any key...");
                    Console.ReadKey();
                }
            } while (!exitProgram);
        }
    }
}