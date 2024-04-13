using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WorkoutController : ControllerBase
    {
       
        private readonly WorkoutContext _workoutContext;

        // GET: WorkoutController/Details/5
        [HttpGet("{id}")]
        public async Task<Workout> Read([FromRoute]int id, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {

            return await _workoutContext.ReadAsync(id,navigationalProperties);
        }
        [HttpGet]
        public async Task<ICollection<Workout>> ReadAll( [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            return await _workoutContext.ReadAllAsync(navigationalProperties);
        }

        // POST: WorkoutController/Create
        [HttpPost]
        public async Task Create([FromBody] Workout item)
        {
           // Console.WriteLine(WorkoutId);
           await _workoutContext.CreateAsync(item);
        }


        // POST: WorkoutController/Edit/5
        [HttpPut]
        public async Task Update([FromBody]Workout item, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
          await  _workoutContext.UpdateAsync(item,navigationalProperties);

        }



        // POST: WorkoutController/Delete/5
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
          await  _workoutContext.DeleteAsync(id);
        }

        public WorkoutController(MusclesDBContext dBContext)
        {
            _workoutContext = new WorkoutContext(dBContext) ;
        }
    }
}
