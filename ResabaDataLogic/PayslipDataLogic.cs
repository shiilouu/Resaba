using Resaba.Data;

namespace Resaba.DataLogic
{
    public class PayslipDataLogic
    {
        IPayslipDataService _dataService;

        public PayslipDataLogic(IPayslipDataService dataService)
        {
            _dataService = dataService;
        }

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

        public void SaveEmployee(Employee employee)
        {
            _dataService.Add(employee);
        }

        public List<Employee> GetEmployees()
        {
            return _dataService.GetEmployees();
        }

        public void UpdateEmployee(Employee employee)
        {
            _dataService.Update(employee);
        }

        public void DeleteEmployee(string name)
        {
            _dataService.Delete(name);
        }
    }
}