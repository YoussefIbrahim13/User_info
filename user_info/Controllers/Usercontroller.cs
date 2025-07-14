using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_info.Data;
using user_info.Models;

namespace user_info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usercontroller : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public Usercontroller(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // Handle user creation with CV upload (POST: api/Usercontroller)
        [HttpPost]
        public async Task<ActionResult<Usermodel>> CreateUser([FromForm] UserCreateDto dto)
        {
            if (dto.CVFile == null || dto.CVFile.Length == 0)
                return BadRequest("CV file is required.");

            var uploadsFolder = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
            // Make sure the uploads folder exists
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}_{dto.CVFile.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.CVFile.CopyToAsync(stream);
            }

            var user = new Usermodel
            {
                Fname = dto.Fname,
                Lname = dto.Lname,
                Email = dto.Email,
                Phone = dto.Phone,
                Cvfilepatht = Path.Combine("uploads", uniqueFileName)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
        }

        // Get all users (GET: api/Usercontroller)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usermodel>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // Download user's CV by user ID (GET: api/Usercontroller/cv/{id})
        [HttpGet("cv/{id}")]
        public async Task<IActionResult> DownloadCV(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null || string.IsNullOrEmpty(user.Cvfilepatht))
                return NotFound();

            var fullPath = Path.Combine(_env.WebRootPath ?? "wwwroot", user.Cvfilepatht);
            if (!System.IO.File.Exists(fullPath))
                return NotFound("CV file not found on server.");

            var contentType = "application/octet-stream";
            return PhysicalFile(fullPath, contentType, Path.GetFileName(fullPath));
        }
    }
}
