using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiOneFeb7_9AM.Model;

namespace WebApiOneFeb7_9AM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1,FName="Suresh",LName="Reddy",salary=50000},
            new Employee { Id = 2,FName="Narendra",LName="Babu",salary=60000},
            new Employee { Id = 3,FName="Surenra",LName="babu",salary=70000}
        };
        [HttpGet(Name = "GetEmployee")]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            Employee emp = employees.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id)
        {
            Employee emp = employees.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                employees.Remove(emp);
                return NoContent();
            }
        }
        [HttpPost]
        public ActionResult<Employee> Post(Employee emp)
        {
            employees.Add(emp);
            return CreatedAtAction(nameof(Get), emp);
        }
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, Employee nemp)
        {
            Employee oemp = employees.SingleOrDefault(x => x.Id == id);
            if(oemp == null)
            {
                return NotFound();
            }
            else
            {
                oemp.FName = nemp.FName;
                oemp.LName = nemp.LName;
                oemp.salary = nemp.salary;
                return NoContent();
            }
        }
    }
}
