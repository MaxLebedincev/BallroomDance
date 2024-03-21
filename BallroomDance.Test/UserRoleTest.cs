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
    public class UserRoleTest : TestCommandBase
    {
        [Fact]
        public async Task Create_Success()
        {
            var rep = unitOfWork.GetRepository<UserRole>();

            var inputName = "customer";

            var item = new UserRole()
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
