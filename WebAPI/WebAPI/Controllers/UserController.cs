using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")] 
    public class UserController : ControllerBase
    {

        private readonly UserContext _userContext;

        // GET: UserController/Details/5
        [HttpGet("{id}")]
        public async Task<User> Read([FromRoute] int id, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {

            return await _userContext.ReadAsync(id,navigationalProperties);
        }
        [HttpGet]
        public async Task<ICollection<User>> ReadAll([FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            return await _userContext.ReadAllAsync(navigationalProperties);
        }

        // POST: UserController/Create
        [HttpPost]
        public async Task Create([FromBody] User item)
        {
            await _userContext.CreateAsync(item);
        }


        // POST: UserController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task Update([FromBody] User item, [FromQuery(Name = "useNavigationalProperties")] bool navigationalProperties)
        {
            await _userContext.UpdateAsync(item,navigationalProperties);
        }



        // POST: UserController/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task Delete([FromRoute] int id)
        {
            await _userContext.DeleteAsync(id);
        }

        public UserController(MusclesDBContext dBContext)
        {
            _userContext = new UserContext(dBContext);
        }
    }
}
