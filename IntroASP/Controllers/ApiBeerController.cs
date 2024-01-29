using IntroASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly ASP_Context _context;

        public ApiBeerController(ASP_Context context)
        {
            _context = context;
        }

        public async Task<List<Beer>> Get()
            => await _context.Beers.ToListAsync();
    }
}
