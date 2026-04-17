using Resaba.Data;
using Resaba.DataLogic;

namespace Resaba.Business
{
    public class PayslipBusiness
    {
        private PayslipDataLogic _dataLogic;

        public PayslipBusiness(PayslipDataLogic dataLogic)
        {
            _dataLogic = dataLogic;
        }

        public Employee GetEmployee(string name, string position, string department, int regHours, int otHours, int payGrade, int leaves)
        {
            return _dataLogic.GetEmployee(name, position, department, regHours, otHours, payGrade, leaves);
        }

        public void SaveEmployee(Employee employee)
        {
            _dataLogic.SaveEmployee(employee);
        }

        public List<Employee> GetEmployees()
        {
            return _dataLogic.GetEmployees();
        }

        public void UpdateEmployee(Employee employee)
        {
            _dataLogic.UpdateEmployee(employee);
        }

        public void DeleteEmployee(string name)
        {
            _dataLogic.DeleteEmployee(name);
        }

        public decimal GetHourlyRate(int payGrade)
        {
            if (payGrade == 1) return 500;
            else if (payGrade == 2) return 750;
            else return 1000;
        }

        public decimal ComputeGross(int regHours, int otHours, int payGrade, int leaves)
        {
            decimal rate = GetHourlyRate(payGrade);
            decimal otRate = rate * 1.25m;
            decimal leaveDeduction = leaves * rate * 8;
            return (regHours * rate) + (otHours * otRate) - leaveDeduction;
        }

        public decimal ComputeSSS(decimal gross) => gross * 0.05m;
        public decimal ComputePhilHealth(decimal gross) => gross * 0.025m;
        public decimal ComputePagIbig(decimal gross) => gross * 0.01m;
        public decimal ComputeWithholdingTax(decimal gross)
        {
            if (gross <= 20833) return 0;
            else if (gross <= 33332) return (gross - 20833) * 0.20m;
            else if (gross <= 66666) return 2500 + (gross - 33333) * 0.25m;
            else if (gross <= 166666) return 10833 + (gross - 66667) * 0.30m;
            else if (gross <= 666666) return 40833 + (gross - 166667) * 0.32m;
            else return 200833 + (gross - 666667) * 0.35m;
        }
        public decimal ComputeTotalDeduction(decimal gross) => ComputeSSS(gross) + ComputePhilHealth(gross) + ComputePagIbig(gross) + ComputeWithholdingTax(gross);
        public decimal ComputeNetPay(decimal gross) => gross - ComputeTotalDeduction(gross);
    }
}