using CICD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CICDProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeerepo;

        public EmployeeController(IEmployeeRepository employeerepo)
        {
            _employeerepo = employeerepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var data = await _employeerepo.GetAllAsync();
            return Json(data);
            
        }
    }
}
