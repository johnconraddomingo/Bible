using Bible.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadController : ControllerBase
    { 
        private readonly ILogger<ReadController> _logger;
        private readonly AppDbContext _context;

        public ReadController(ILogger<ReadController> logger, AppDbContext context)
        { 
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public Book Get()
        { 
            var book = _context.Books.First(); 
            return book;
          
        }
    }
}
