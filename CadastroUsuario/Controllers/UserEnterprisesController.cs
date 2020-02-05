using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroUsuario.Models;
using Microsoft.AspNetCore.Authorization;

namespace CadastroUsuario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserEnterprisesController : ControllerBase
    {
        private readonly UsersContext _context;

        public UserEnterprisesController(UsersContext context)
        {
            _context = context;
        }

        // GET: api/UserEnterprises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserEnterprise>>> GetUserEnterprise()
        {
            return await _context.UserEnterprise.ToListAsync();
        }

        // GET: api/UserEnterprises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEnterprise>> GetUserEnterprise(int id)
        {
            var userEnterprise = await _context.UserEnterprise.FindAsync(id);

            if (userEnterprise == null)
            {
                return NotFound();
            }

            return userEnterprise;
        }

        public bool valid { get; set; }

        // PUT: api/UserEnterprises/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEnterprise(int id, UserEnterprise userEnterprise)
        {
            if (id != userEnterprise.Id)
            {
                return BadRequest();
            }

            _context.Entry(userEnterprise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEnterpriseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserEnterprises
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserEnterprise>> PostUserEnterprise(UserEnterprise userEnterprise)
        {
            _context.UserEnterprise.Add(userEnterprise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserEnterprise", new { id = userEnterprise.Id }, userEnterprise);
        }

        // DELETE: api/UserEnterprises/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserEnterprise>> DeleteUserEnterprise(int id)
        {
            var userEnterprise = await _context.UserEnterprise.FindAsync(id);
            if (userEnterprise == null)
            {
                return NotFound();
            }

            _context.UserEnterprise.Remove(userEnterprise);
            await _context.SaveChangesAsync();

            return userEnterprise;
        }

        private bool UserEnterpriseExists(int id)
        {
            return _context.UserEnterprise.Any(e => e.Id == id);
        }

        public void UserValidate(UserEnterprise user)
        {
            if(user.BirthDate > DateTime.Now )
                throw new ArgumentOutOfRangeException("BirthDate");

            if(user.FirstName.Length > 100)
                throw new ArgumentOutOfRangeException("FirstName");

            if (user.LastName.Length > 100)
                throw new ArgumentOutOfRangeException("LastName");

            if (user.UserName.Length > 100)
                throw new ArgumentOutOfRangeException("UserName");

            if (user.Email.Length > 200 || !user.Email.Contains('@'))
                throw new ArgumentException("Email");

            if (user.Gender != "M" && user.Gender != "F")
                throw new ArgumentException("Gender");

            valid = true;
        }
    }
}
