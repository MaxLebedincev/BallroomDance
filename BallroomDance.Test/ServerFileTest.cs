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
    public class ServerFileTest : TestCommandBase
    {
        [Fact]
        public async Task Create_Success()
        {
            var rep = unitOfWork.GetRepository<ServerFile>();

            var inputName = "Иван";
            var size = 10;

            var item = new ServerFile()
            {
                Name = inputName,
                Size = size
            };

            // Act
            var outputItem = rep.Create(item);

            unitOfWork.SaveChanges();

            //Assert
            Assert.NotNull(rep.GetAll().Where(mdg => mdg.Guid == outputItem.Guid).First());

        }
    }
}
