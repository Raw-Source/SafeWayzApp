using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeWayzAppApi.Data;
using SafeWayzLibrary.Models;

namespace SafeWayzAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly UserDetailsContext _context;

        public UserDetailsController(UserDetailsContext context)
        {
            _context = context;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserDetail()
        {
            return await _context.UserDetail.ToListAsync();
        }

        // GET: api/UserDetails/{username}

        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<UserDetails>> Login(string username, string password)
        {
            var userDetails = await _context.UserDetail.Where(x => x.UserName.ToLower() == username.ToLower()).FirstOrDefaultAsync();

            if (userDetails == null)
            {
                return NotFound();
            }
            if (userDetails.Password.ToLower() == password.ToLower())
            {
                return userDetails;
            }
            else
                return NotFound();

        }

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProfile(int id, string username, UserDetails userDetails)
        {
            if (id != userDetails.Id)
            {
                return BadRequest();
            }

           

            _context.Entry(userDetails).State = EntityState.Modified;

            if (!UserUserNameExists(username))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserDetailsExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }
            else
            {
                return BadRequest();
            }
            

            return NoContent();
        }

        // POST: api/UserDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDetails>> SignUp(UserDetails user)
        {
            _context.UserDetail.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDetails", new { id = user.Id }, user);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDetails>> DeleteUserDetails(int id)
        {
            var userDetails = await _context.UserDetail.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }

            _context.UserDetail.Remove(userDetails);
            await _context.SaveChangesAsync();

            return userDetails;
        }

        private bool UserUserNameExists(string username)
        {
            return _context.UserDetail.Any(e => e.UserName == username);
        }

        private bool UserDetailsExists(int id)
        {
            return _context.UserDetail.Any(e => e.Id == id);
        }
    }
}
