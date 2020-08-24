using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
  //'[controller]' is basically a placeholder for whatever is in front of 'Controller' in the below class, so 
  // http:localhost:5000/api/values is the address that would get the 2 values
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly DataContext _context;

    //constructor injecting the DataContext service into our controller and setting the value of the private 
    //readonly field _context to equal the DataContext.  Now when we want to access our context in our class, 
    //we refer to it as _context.
    public ValuesController(DataContext context)
    {
      _context = context;

    }
    // GET api/values
    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
      var values = await _context.Values.ToListAsync();

      return Ok(values);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetValue(int id)
    {
      var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

      return Ok(value);
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
