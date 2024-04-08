using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ExerciseTypeGroupController : ControllerBase
    {

        private readonly ExerciseTypeGroupContext _exerciseTypeGroupContext;

        // GET: ExerciseTypeGroupController/Details/5
        [HttpGet("{id}")]
        public async Task<ExerciseTypeGroup> Read([FromRoute] int id, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {

            return await _exerciseTypeGroupContext.ReadAsync(id, navigationalProperties);
        }
        [HttpGet]
        public async Task<ICollection<ExerciseTypeGroup>> ReadAll([FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            return await _exerciseTypeGroupContext.ReadAllAsync(navigationalProperties);
        }

        // POST: ExerciseTypeGroupController/Create
        [HttpPost]
        public async Task Create([FromBody] ExerciseTypeGroup item)
        {
            await _exerciseTypeGroupContext.CreateAsync(item);
        }


        // POST: ExerciseTypeGroupController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task Update([FromBody] ExerciseTypeGroup item, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            await _exerciseTypeGroupContext.UpdateAsync(item, navigationalProperties);
        }



        // POST: ExerciseTypeGroupController/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task Delete([FromRoute] int id)
        {
            await _exerciseTypeGroupContext.DeleteAsync(id);
        }

        public ExerciseTypeGroupController(MusclesDBContext dBContext)
        {
            _exerciseTypeGroupContext = new ExerciseTypeGroupContext(dBContext);
        }
    }
}
