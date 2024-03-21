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
    public class MemberDanceGroupTest : TestCommandBase
    {
        [Fact]
        public async Task Create_Success()
        {
            var rep = unitOfWork.GetRepository<MemberDanceGroup>();

            var inputFirstName = "Иван";
            var inputLastName = "Иванов";
            var inputMiddleName = "Иванович";
            var inputCity = "Ульяновск";
            var inputCategory = "9Б";

            var item = new MemberDanceGroup()
            {
                FirstName = inputFirstName,
                LastName = inputLastName,
                MiddleName = inputMiddleName,
                City = inputCity,
                Category = inputCategory,
                Score = 10
            };

            // Act
            var outputItem = rep.Create(item);

            unitOfWork.SaveChanges();

            //Assert
            Assert.NotNull(rep.GetAll().Where(mdg => mdg.Id == item.Id).First());

        }
    }
}
