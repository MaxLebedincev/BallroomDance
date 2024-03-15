using BallroomDanceAPI.Controllers.UserRoleInteraction;
using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BallroomDanceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class UserRoleController : ControllerBase
    {
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleController(IOptions<AppSettings> conf, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("api/[controller]/Create")]
        public async Task<ActionResult> Create([FromBody] UserRoleRequest request)
        {
            var rep = _unitOfWork.GetRepository<UserRole>();

            var newEntity = new UserRole()
            {
                Name = request.Name,
            };

            rep.Create(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("api/[controller]/Get")]
        public async Task<ActionResult<List<UserRoleResponse>>> Get([FromBody] UserRoleDTO request)
        {
            var rep = _unitOfWork.GetRepository<UserRole>();

            var list = rep.GetAll();

            list = list.OrderBy(e => e.Id);

            if (!string.IsNullOrEmpty(request.Name))
                list = list
                    .Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"));

            list = list
                    .Skip(request.Offset)
                    .Take(request.Number);

            var paginatedList = await list.ToListAsync();

            var resopnse = new List<UserRoleResponse>();

            foreach (var item in paginatedList)
                resopnse.Add(new UserRoleResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                });

            return resopnse;
        }

        [HttpGet("api/[controller]/Get/{id}")]
        public async Task<ActionResult<UserRoleResponse?>> GetById(int id)
        {
            var rep = _unitOfWork.GetRepository<UserRole>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            var response = new UserRoleResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            return response;
        }

        [HttpDelete("api/[controller]/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rep = _unitOfWork.GetRepository<UserRole>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            rep.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("api/[controller]/Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserRoleRequest newEntity)
        {
            var rep = _unitOfWork.GetRepository<UserRole>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            entity.Name = newEntity.Name;

            rep.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
