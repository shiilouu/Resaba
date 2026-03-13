using Resaba.Data;
namespace Resaba.DataLogic
{
    public class PayslipDataLogic
    {
        public Employee GetEmployee(string name, string position, string department, int totalHours, int regHours, int otHours)
        {
            return new Employee
            {
                Name = name,
                Position = position,
                Department = department,
                TotalHours = totalHours,
                RegularHours = regHours,
                OvertimeHours = otHours };
            }
        }
    }