using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyManagerApi.Data;
using MoneyManagerApi.Models;

namespace MoneyManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private ApplicationDbContext _context;
        private User _user;

        public TagsController(ApplicationDbContext context, IHttpContextAccessor http)
        {
            _context = context;
            _user = (User)http.HttpContext.Items["ApplicationUser"];
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> Post([FromBody] Tag tag)
        {
            if(!ModelState.IsValid){
                return UnprocessableEntity(ModelState);
            }

            var existingTag = await _context.Tags.Where(c => c.Name == tag.Name).FirstOrDefaultAsync();
            if(existingTag != null){
                return Ok(existingTag);
            }
            
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return Ok(tag);
        }
    }
}
