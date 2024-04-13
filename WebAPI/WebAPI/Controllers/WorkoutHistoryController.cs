using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WorkoutHistoryController : ControllerBase
    {

        private readonly WorkoutHistoryContext _workoutHistoryContext;

        // GET: WorkoutHistoryController/Details/5
        [HttpGet("{id}")]
        public async Task<WorkoutHistory> Read([FromRoute] int id, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {

            return await _workoutHistoryContext.ReadAsync(id, navigationalProperties);
        }
        [HttpGet]
        public async Task<ICollection<WorkoutHistory>> ReadAll([FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            return await _workoutHistoryContext.ReadAllAsync(navigationalProperties);
        }

        // POST: WorkoutHistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create([FromBody] WorkoutHistory item)
        {
            await _workoutHistoryContext.CreateAsync(item);
        }


        // POST: WorkoutHistoryController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task Update([FromBody] WorkoutHistory item, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            await _workoutHistoryContext.UpdateAsync(item, navigationalProperties);
        }



        // POST: WorkoutHistoryController/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task Delete([FromRoute] int id)
        {
            await _workoutHistoryContext.DeleteAsync(id);
        }

        public WorkoutHistoryController(MusclesDBContext dBContext)
        {
            _workoutHistoryContext = new WorkoutHistoryContext(dBContext);
        }
    }
}
