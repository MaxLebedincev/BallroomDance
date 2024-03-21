using BallroomDance.Test.Common;
using BallroomDance.API.DAL;
using BallroomDance.API.DAL.Interfaces;
using BallroomDance.API.Domain.Entity;
using BallroomDance.API.Service.Registeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BallroomDance.Test
{
    public class DanceGroupTest : TestCommandBase
    {

        [Fact]
        public async Task Create_Success()
        {
            var rep = unitOfWork.GetRepository<TypeBallroomDance>();

            var inputId = 999;
            var inputName = "Какой-то";

            var item = new TypeBallroomDance()
            {
                Id = inputId,
                Name = inputName
            };

            // Act
            var outputItem = rep.Create(item);

            unitOfWork.SaveChanges();

            //Assert
            Assert.NotNull(rep.GetAll().Where(tbc => tbc.Id == inputId && tbc.Name == inputName).First());

        }
    }
}
