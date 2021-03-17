using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Data;
using NoticiasAPI.Models;

namespace NoticiasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly provaContext _context;

        public LoginController(provaContext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogin()
        {
            return await _context.Login.ToListAsync();
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Login/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.id)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Login>> PostLogin(Login login)
        {
            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.id }, login);
        }

        // POST: api/Login/auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("auth")]
        public ActionResult<Login> LoginAuth(Login login)
        {
            if (LoginValidate(login))
            {
                return Content("Autorizado");
            }

            return Content("Não autorizado");
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.id == id);
        }

        private bool LoginValidate(Login login)
        {
            if ( _context.Login.Any(c => login.email == "teste@email.com.br" && login.senha == "123456"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
