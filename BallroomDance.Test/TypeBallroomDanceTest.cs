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
    public class TypeBallroomDanceTest : TestCommandBase
    {
        [Fact]
        public async Task Create_Success()
        {
            var rep = unitOfWork.GetRepository<TypeBallroomDance>();

            var inputName = "Восточные";

            var item = new TypeBallroomDance()
            {
                Name = inputName
            };

            // Act
            var outputItem = rep.Create(item);

            unitOfWork.SaveChanges();

            //Assert
            Assert.NotNull(rep.GetAll().Where(mdg => mdg.Id == outputItem.Id).First());

        }
    }
}
