using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NATA.Data;
using NATA.Entities;

namespace NATA.Controllers
{
    
       public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            this._context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public  async Task <ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await this._context.Users.ToListAsync();

        }

         //api/users/3
         [Authorize]
          [HttpGet("{id}")]
        public  async Task <ActionResult<AppUser>> GetUser(int id)
        {
            return await this._context.Users.FindAsync(id);
        }
    }
}