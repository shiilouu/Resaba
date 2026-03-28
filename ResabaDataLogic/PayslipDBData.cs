using Resaba.Data;
using Microsoft.Data.SqlClient;

namespace Resaba.DataLogic
{
    public class PayslipDBData : IPayslipDataService
    {
        private string connectionString =
            "Data Source=.\\SQLEXPRESS; Initial Catalog=ResabaDB; Integrated Security=True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public PayslipDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Add(Employee employee)
        {
            var insertStatement = @"INSERT INTO Employees 
                VALUES (@Name, @Position, @Department, @TotalHours, @RegularHours, 
                @OvertimeHours, @PayGrade, @Leaves, @Gross, @SSS, @PhilHealth, 
                @PagIbig, @WithholdingTax, @TotalDeduction, @NetPay)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@Name", employee.Name);
            insertCommand.Parameters.AddWithValue("@Position", employee.Position);
            insertCommand.Parameters.AddWithValue("@Department", employee.Department);
            insertCommand.Parameters.AddWithValue("@TotalHours", employee.TotalHours);
            insertCommand.Parameters.AddWithValue("@RegularHours", employee.RegularHours);
            insertCommand.Parameters.AddWithValue("@OvertimeHours", employee.OvertimeHours);
            insertCommand.Parameters.AddWithValue("@PayGrade", employee.PayGrade);
            insertCommand.Parameters.AddWithValue("@Leaves", employee.Leaves);
            insertCommand.Parameters.AddWithValue("@Gross", employee.Gross);
            insertCommand.Parameters.AddWithValue("@SSS", employee.SSS);
            insertCommand.Parameters.AddWithValue("@PhilHealth", employee.PhilHealth);
            insertCommand.Parameters.AddWithValue("@PagIbig", employee.PagIbig);
            insertCommand.Parameters.AddWithValue("@WithholdingTax", employee.WithholdingTax);
            insertCommand.Parameters.AddWithValue("@TotalDeduction", employee.TotalDeduction);
            insertCommand.Parameters.AddWithValue("@NetPay", employee.NetPay);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Employee> GetEmployees()
        {
            string selectStatement = "SELECT * FROM Employees";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var employees = new List<Employee>();

            while (reader.Read())
            {
                Employee employee = new Employee
                {
                    Name = reader["Name"].ToString(),
                    Position = reader["Position"].ToString(),
                    Department = reader["Department"].ToString(),
                    TotalHours = Convert.ToInt32(reader["TotalHours"]),
                    RegularHours = Convert.ToInt32(reader["RegularHours"]),
                    OvertimeHours = Convert.ToInt32(reader["OvertimeHours"]),
                    PayGrade = Convert.ToInt32(reader["PayGrade"]),
                    Leaves = Convert.ToInt32(reader["Leaves"]),
                    Gross = Convert.ToDecimal(reader["Gross"]),
                    SSS = Convert.ToDecimal(reader["SSS"]),
                    PhilHealth = Convert.ToDecimal(reader["PhilHealth"]),
                    PagIbig = Convert.ToDecimal(reader["PagIbig"]),
                    WithholdingTax = Convert.ToDecimal(reader["WithholdingTax"]),
                    TotalDeduction = Convert.ToDecimal(reader["TotalDeduction"]),
                    NetPay = Convert.ToDecimal(reader["NetPay"])
                };
                employees.Add(employee);
            }

            sqlConnection.Close();
            return employees;
        }
    }
}