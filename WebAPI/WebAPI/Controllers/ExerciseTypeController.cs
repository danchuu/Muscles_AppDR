using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExerciseTypeController : ControllerBase
    {

        private readonly ExerciseTypeContext _exerciseTypeContext;

        // GET: ExerciseTypeController/Details/5
        [HttpGet("{id}")]
        public async Task<ExerciseType> Read([FromRoute] int id, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {

            return await _exerciseTypeContext.ReadAsync(id, navigationalProperties);
        }
        [HttpGet]
        public async Task<ICollection<ExerciseType>> ReadAll([FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            return await _exerciseTypeContext.ReadAllAsync(navigationalProperties);
        }

        // POST: ExerciseTypeController/Create
        [HttpPost]
        public async Task Create([FromBody] ExerciseType item)
        {
            await _exerciseTypeContext.CreateAsync(item);
        }


        // POST: ExerciseTypeController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task Update([FromBody] ExerciseType item, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            await _exerciseTypeContext.UpdateAsync(item, navigationalProperties);
        }



        // POST: ExerciseTypeController/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task Delete([FromRoute] int id)
        {
            await _exerciseTypeContext.DeleteAsync(id);
        }

        public ExerciseTypeController(MusclesDBContext dBContext)
        {
            _exerciseTypeContext = new ExerciseTypeContext(dBContext);
        }
    }
}

