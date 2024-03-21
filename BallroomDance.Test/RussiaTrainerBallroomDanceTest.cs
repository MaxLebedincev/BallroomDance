using BallroomDance.Test.Common;
using BallroomDance.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BallroomDance.Test
{
    public class RussiaTrainerBallroomDanceTest : TestCommandBase
    {
        [Fact]
        public async Task Create_Success()
        {
            var rep = unitOfWork.GetRepository<RussiaTrainerBallroomDance>();

            var inputFirstName = "Иван";
            var inputLastName = "Иванов";
            var inputMiddleName = "Иванович";

            var item = new RussiaTrainerBallroomDance()
            {
                FirstName = inputFirstName,
                LastName = inputLastName,
                MiddleName = inputMiddleName
            };

            // Act
            var outputItem = rep.Create(item);

            unitOfWork.SaveChanges();

            //Assert
            Assert.NotNull(rep.GetAll().Where(mdg => mdg.Id == outputItem.Id).First());

        }
    }
}
