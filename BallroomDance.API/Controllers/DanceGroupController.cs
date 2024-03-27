using BallroomDance.API.Controllers.DanceGroupInteraction;
using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BallroomDance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DanceGroupController : ControllerBase
    {
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public DanceGroupController(IOptions<AppSettings> conf, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] DanceGroupRequest request)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var newEntity = new DanceGroup()
            {
                RussiaTrainerBallroomDanceId = request.RussiaTrainerBallroomDanceId,
                Name = request.Name,
                Created = request.Created,
            };

            rep.Create(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Get")]
        public async Task<ActionResult<List<DanceGroupResponse>>> Get([FromBody] DanceGroupDTO request)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var list = rep.GetAll();

            list = list.OrderBy(e => e.Id);

            if (!string.IsNullOrEmpty(request.Name))
                list = list.Where(e => EF.Functions.Like(e.Name, $"%{request.Name}%"));

            if (!string.IsNullOrEmpty(request.Created))
                list = list.Where(e => e.Created >= DateTime.Parse(request.Created));

            if (!string.IsNullOrEmpty(request.Finish))
                list = list.Where(e => e.Created <= DateTime.Parse(request.Finish));

            list = list
                    .Skip(request.Offset)
                    .Take(request.Number);

            var paginatedList = await list.ToListAsync();

            var resopnse = new List<DanceGroupResponse>();

            foreach (var item in paginatedList)
                resopnse.Add(new DanceGroupResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    RussiaTrainerBallroomDanceId = item.RussiaTrainerBallroomDanceId,
                    Created = item.Created,
                });

            return resopnse;
        }

        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<DanceGroupResponse?>> GetById(int id)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            var response = new DanceGroupResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                RussiaTrainerBallroomDanceId = entity.RussiaTrainerBallroomDanceId,
                Created = entity.Created,
            };

            return response;
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            rep.Delete(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] DanceGroupRequest newEntity)
        {
            var rep = _unitOfWork.GetRepository<DanceGroup>();

            var entity = await rep.GetAll().Where(r => r.Id == id).FirstAsync();

            if (entity is null)
                return NotFound();

            entity.Name = newEntity.Name;
            entity.RussiaTrainerBallroomDanceId = newEntity.RussiaTrainerBallroomDanceId;
            entity.Created = newEntity.Created;

            rep.Update(entity);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
