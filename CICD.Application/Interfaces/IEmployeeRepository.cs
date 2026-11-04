using CICD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CICD.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>>  GetAllAsync();
    }
}
