using BallroomDance.API.Controllers.UserInteraction;
using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BallroomDance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(Roles = "admin")]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IOptions<AppSettings> conf, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("api/[controller]/Create")]
        public async Task<ActionResult> Create([FromBody] UserRequest request)
        {
            var rep = _unitOfWork.GetRepository<User>();

            var newEntity = new User()
            {
                IdUserRole = request.IdUserRole,
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                Created = request.Created,
                Updated = request.Updated
            };

            rep.Create(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("api/[controller]/Get")]
        public async Task<ActionResult<List<UserResponse>>> Get([FromBody] UserDTO request)
        {
            var rep = _unitOfWork.GetRepository<User>();

            var list = rep.GetAll();

            list = list.OrderBy(e => e.Id);

            if (!string.IsNullOrEmpty(request.Login))
                list = list
                    .Where(e => EF.Functions.Like(e.Login, $"%{request.Login}%"));

            if (!string.IsNullOrEmpty(request.Email))
                list = list
                    .Where(e => EF.Functions.Like(e.Login, $"%{request.Email}%"));

            if (request.IdUserRole is not null)
                list = list
                    .Where(e => e.IdUserRole == request.IdUserRole);

            list = list
                    .Skip(request.Offset)
                    .Take(request.Number);

            var paginatedList = await list.ToListAsync();

            var resopnse = new List<UserResponse>();

            foreach (var item in paginatedList)
                resopnse.Add(new UserResponse()
                {
                    Id = item.Id,
                    IdUserRole = item.IdUserRole,
                    Login = item.Login,
                    Email = item.Email,
                    Password = item.Password,
                    Created = item.Created,
                    Updated = item.Updated
                });

            return resopnse;
        }

        [HttpGet("api/[controller]/Get/{id}")]
        public async Task<ActionResult<UserResponse?>> GetById(int id)
        {
            var rep = _unitOfWork.GetRepository<User>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            var response = new UserResponse()
            {
                Id = entity.Id,
                IdUserRole = entity.IdUserRole,
                Login = entity.Login,
                Email = entity.Email,
                Password = entity.Password,
                Created = entity.Created,
                Updated = entity.Updated
            };

            return response;
        }

        [HttpDelete("api/[controller]/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rep = _unitOfWork.GetRepository<User>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            rep.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("api/[controller]/Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserRequest newEntity)
        {
            var rep = _unitOfWork.GetRepository<User>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            entity.IdUserRole = newEntity.IdUserRole;
            entity.Login = newEntity.Login;
            entity.Email = newEntity.Email;
            entity.Password = newEntity.Password;
            entity.Created = newEntity.Created;
            entity.Updated = newEntity.Updated;

            rep.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
