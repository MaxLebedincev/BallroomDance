using BallroomDance.API.DAL;
using BallroomDance.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallroomDance.Test.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ApplicationDbContext Context;

        public readonly IUnitOfWork unitOfWork;

        public TestCommandBase()
        {
            Context = BallromDanceContextFactory.Create();

            unitOfWork = new UnitOfWork(Context);
        }

        public void Dispose()
        {
            BallromDanceContextFactory.Destroy(Context);
        }
    }
}
