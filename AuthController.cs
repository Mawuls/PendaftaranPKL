using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PendaftaranPKL.Data;
using PendaftaranPKL.DTOs;
using PendaftaranPKL.Models;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace PendaftaranPKL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email sudah terdaftar");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("Registrasi berhasil");
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginUser)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == loginUser.Email && u.Password == loginUser.Password);

            if (user == null)
                return Unauthorized("Email atau password salah");

            return Ok(new
            {
                message = "Login berhasil",
                user.Id,
                user.Nama,
                user.Email,
                user.Sekolah
            });
        }


        // PUT: api/auth/edit/1
        [HttpPut("edit/{id}")]
        public IActionResult EditProfile(int id, [FromBody] User updatedUser)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound("User tidak ditemukan");

            user.Nama = updatedUser.Nama;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            user.Sekolah = updatedUser.Sekolah;

            _context.SaveChanges();
            return Ok("Profil berhasil diperbarui");
        }
    }
}
