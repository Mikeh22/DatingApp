using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc; // Modern view Controller - use .net to serve HTML pages
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //specify API/users to get this controller
    public class UsersController : ControllerBase // Derive from controllerbase
    {
        private readonly DataContext _context; // private readonly varible
        public UsersController(DataContext context) // Generated constructor - Dependancy Injection
        {
            _context = context; // Initializing field from parameter
        }
  
      // End point to get all the users in the DB
      [HttpGet] 

      // Ienumberable allows us to use simple interation over a collection of specified type
      // More appropriate as we do not need to sort or research
      // We need to import the AppUser 

      public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers( ) //sending back a list of users to the client 
      {
          return await _context.Users.ToListAsync(); //return users as end point

      
      }
// for example if ID = 3 give me all user info for - api/users/3 - Specificed route parameter where 3 is the ID to be fetched
      [HttpGet("{id}")] 

      // Ienumberable is a built in function
      // We need to import the AppUser 

      public async Task<ActionResult<AppUser>> GetUser(int id)
      {
          return await _context.Users.FindAsync(id);       
      }      
    }
}
/* VAR - Used to declare variable
 Return - Returning an endpoint eg Users
*/