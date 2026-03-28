using Resaba.Data;
namespace Resaba.DataLogic
{
    public class PayslipDataLogic
    {
        public Employee GetEmployee(string name, string position, string department, int regHours, int otHours, int payGrade, int leaves)
        {
            return new Employee
            {
                Name = name,
                Position = position,
                Department = department,
                RegularHours = regHours,
                OvertimeHours = otHours,
                TotalHours = regHours + otHours,
                PayGrade = payGrade,
                Leaves = leaves
            };
        }
    }
}