using Resaba.Data;

namespace Resaba.DataLogic
{
    public interface IPayslipDataService
    {
        void Add(Employee employee);
        List<Employee> GetEmployees();
    }
}