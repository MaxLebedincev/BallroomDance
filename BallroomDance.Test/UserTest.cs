using BallroomDance.Test.Common;
using BallroomDance.API.DAL;
using BallroomDance.API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BallroomDance.Test
{
    public class UserTest : TestCommandBase
    {
        [Fact]
        public async Task Create_Success()
        {
            var rep = unitOfWork.GetRepository<User>();

            var inputLogin = "lol";
            var inputEmail = "kyky@mail.com";
            var inputPassword = "asdasdfsadfa";

            var item = new User()
            {
                Login = inputLogin,
                Email = inputEmail,
                Password = inputPassword
            };

            // Act
            var outputItem = rep.Create(item);

            unitOfWork.SaveChanges();

            //Assert
            Assert.NotNull(rep.GetAll().Where(mdg => mdg.Id == outputItem.Id).First());

        }
    }
}
