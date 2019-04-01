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
    public class CategoriesController : ControllerBase
    {
        private ApplicationDbContext _context;
        private User _user;

        public CategoriesController(ApplicationDbContext context, IHttpContextAccessor http)
        {
            _context = context;
            _user = (User)http.HttpContext.Items["ApplicationUser"];
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            if(!ModelState.IsValid){
                return UnprocessableEntity(ModelState);
            }

            var existingCategory = await _context.Categories.Where(c => c.Name == category.Name).FirstOrDefaultAsync();
            if(existingCategory != null){
                return Ok(existingCategory);
            }
            
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
    }
}