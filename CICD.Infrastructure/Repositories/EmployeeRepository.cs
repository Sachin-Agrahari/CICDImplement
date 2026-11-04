using CICD.Application.Interfaces;
using CICD.Domain.Entities;
using CICD.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICD.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlConnectionFactory _factory;

        public EmployeeRepository(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<List<En_Employee>> GetAllAsync()
        {
            var employees = new List<En_Employee>();

            using var con = _factory.CreateConnection();

            const string query = @"
                    SELECT CODE,EMPL_NAME,FATHER_NAME,MOTH_NAME,ADD1 FROM EMPLOYEE WHERE CODE  ='RA000659'";

            using var cmd = new SqlCommand(query, con);

            await con.OpenAsync();
             
            using var reader = await cmd.ExecuteReaderAsync(); 

            while (await reader.ReadAsync()) 
            {
                employees.Add(new En_Employee
                {
                    //CODE = reader["CODE"]?.ToString() ?? "",
                    EMPL_NAME = reader["EMPL_NAME"]?.ToString() ?? "",
                    FATHER_NAME = reader["FATHER_NAME"].ToString() ?? "",
                    MOTH_NAME = reader["MOTH_NAME"].ToString() ?? "",
                    ADD1 = reader["ADD1"].ToString() ?? ""
                });
            }

            return employees;
        }
    }
}
