using BestBook2.Data;
using Microsoft.AspNetCore.Mvc;

namespace BestBook2.Controllers
{
    public class BookMasterController : Controller
    {

        [Route("api/[controller]")]
        [ApiController]
        public class BookMastersController : ControllerBase
        {
            private readonly SqlDbContext _context;

            public BookMastersController(SqlDbContext context)
            {
                _context = context;
            }


           
        }
    }
}
