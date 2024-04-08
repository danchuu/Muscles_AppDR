using DataLayer1;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExerciseController : ControllerBase
    {

        private readonly ExerciseContext _exerciseContext;

        // GET: ExerciseController/Details/5
        [HttpGet("{id}")]
        public async Task<Exercise> Read([FromRoute] int id, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {

            return await _exerciseContext.ReadAsync(id, navigationalProperties);
        }
        [HttpGet]
        public async Task<ICollection<Exercise>> ReadAll([FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            return await _exerciseContext.ReadAllAsync(navigationalProperties);
        }

        // POST: ExerciseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create([FromBody] Exercise item)
        {
            await _exerciseContext.CreateAsync(item);
        }


        // POST: ExerciseController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task Update([FromBody] Exercise item, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            await _exerciseContext.UpdateAsync(item, navigationalProperties);
        }



        // POST: ExerciseController/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task Delete([FromRoute] int id)
        {
            await _exerciseContext.DeleteAsync(id);
        }

        public ExerciseController(MusclesDBContext dBContext)
        {
            _exerciseContext = new ExerciseContext(dBContext);
        }
    }
}
