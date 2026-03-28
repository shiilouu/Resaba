namespace Resaba.Data
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public int TotalHours { get; set; }
        public int RegularHours { get; set; }
        public int OvertimeHours { get; set; }
        public int PayGrade { get; set; }
        public int Leaves { get; set; }
        public decimal Gross { get; set; }
        public decimal SSS { get; set; }
        public decimal PhilHealth { get; set; }
        public decimal PagIbig { get; set; }
        public decimal WithholdingTax { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetPay { get; set; }
    }
}