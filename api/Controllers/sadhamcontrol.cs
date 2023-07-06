using api.model;
using Dataaccessset.alldba;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sadhamcontrol : ControllerBase
    {
        private readonly Db employeeContext;
        public sadhamcontrol(Db employeeContext)
        {

            this.employeeContext = employeeContext;
        }
        [HttpGet]



        public async Task<ActionResult<IEnumerable<employee>>> Get()
        {
            return await employeeContext.Employees.ToListAsync();
        }




        [HttpGet("{id}")]



        public async Task<ActionResult<employee>> Get(int id)
        {
            if (employeeContext.Employees == null)
            {
                return NotFound();
            }



            var result = await employeeContext.Employees.FindAsync(id);



            if (result == null)
            {
                return NotFound();
            }



            return result;
        }



        [HttpPost]



        public async Task<ActionResult<employee>> postEmployee(employee emp)
        {
            employeeContext.Employees.Add(emp);
            await employeeContext.SaveChangesAsync();



            // return CreatedAtAction(nameof(Get), new { id = student.id }, student);



            return Ok(emp);
        }



        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> updateEmployee([FromRoute] int id, employee employee)
        {

/*
            if (id != employee.ID)
            {
                return BadRequest();
            }
            employeeContext.Entry(employee).State = EntityState.Modified;



            try
            {
                await employeeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeAvailable(id))
                {



                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
*/
  if(EmployeeAvailable(id))
            {
                employeeContext.Employees.Update(employee);

 

                await employeeContext.SaveChangesAsync();

 

                return Ok(employee);
            }

 

            return BadRequest();

        }
        private bool EmployeeAvailable(int id)
        {
            return (employeeContext.Employees?.Any(x => x.ID == id)).GetValueOrDefault();
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            // Find the value by the id of the customer.
            var employeeSearch = employeeContext.Employees.FirstOrDefault(x => x.ID.Equals(id));



            if (employeeSearch != null)
            {
                // Remove from the storage
                employeeContext.Remove(employeeSearch);
                // saves the result to the database
                await employeeContext.SaveChangesAsync();
            }



            return Ok(employeeSearch);



        }

    }
}
