using Resaba.Data;
using System.Text.Json;

namespace Resaba.DataLogic
{
    public class PayslipJsonData : IPayslipDataService
    {
        private List<Employee> employees = new List<Employee>();
        private string _jsonFileName;

        public PayslipJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Employees.json";
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            if (File.Exists(_jsonFileName))
            {
                RetrieveDataFromJsonFile();
            }
            else
            {
                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Employee>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true }),
                    employees);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                employees = JsonSerializer.Deserialize<List<Employee>>(
                    jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
            SaveDataToJsonFile();
        }

        public List<Employee> GetEmployees()
        {
            RetrieveDataFromJsonFile();
            return employees;
        }

        public void Update(Employee employee)
        {
            RetrieveDataFromJsonFile();
            var existing = employees.FirstOrDefault(e => e.Name == employee.Name);
            if (existing != null)
            {
                employees.Remove(existing);
                employees.Add(employee);
                SaveDataToJsonFile();
            }
        }

        public void Delete(string name)
        {
            RetrieveDataFromJsonFile();
            var existing = employees.FirstOrDefault(e => e.Name == name);
            if (existing != null)
            {
                employees.Remove(existing);
                SaveDataToJsonFile();
            }
        }
    }
}