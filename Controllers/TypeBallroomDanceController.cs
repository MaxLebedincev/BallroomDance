using BallroomDanceAPI.DAL;
using BallroomDanceAPI.DAL.Interfaces;
using BallroomDanceAPI.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BallroomDanceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeBallroomDanceController : ControllerBase
    {

        private readonly ILogger<TypeBallroomDanceController> _logger;
        private readonly AppSettings _conf;
        private readonly IUnitOfWork _unitOfWork;

        public TypeBallroomDanceController(IOptions<AppSettings> conf, ILogger<TypeBallroomDanceController> logger, IUnitOfWork unitOfWork)
        {
            _conf = conf.Value;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetTypesBallroomDance")]
        public async Task<IEnumerable<TypeBallroomDance>> Get()
        {
            var a = _unitOfWork.GetRepository<TypeBallroomDance>().GetAll();

            return a.AsQueryable();
        }
    }
}
