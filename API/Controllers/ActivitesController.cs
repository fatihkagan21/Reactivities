using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    // already have api route etc. 
    public class ActivitiesController : BaseApiController
    {
        //creating endpoints --> utilize dependency injection
        
        //when http request comes in our program class knows where to go and creates new intstances to activities 
        // then creates data context instance 
        private readonly DataContext _context;
        //cto creates below 
        public ActivitiesController(DataContext context)
        {
            _context = context;

        }

        //endpoint creation
        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities() // should come from domain
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] //api/activities/FFFFF
        public async  Task<ActionResult<Activity>> GetActivity(Guid id) // should come from domain
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}