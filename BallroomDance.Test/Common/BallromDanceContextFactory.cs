using BallroomDance.API.DAL;
using BallroomDance.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BallroomDance.Test.Common
{
    public class BallromDanceContextFactory
    {

        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            var uow = new UnitOfWork(context);

            var repTypeBallroomDance = uow.GetRepository<TypeBallroomDance>();
            var repRussiaTrainerBallroomDance = uow.GetRepository<RussiaTrainerBallroomDance>();
            var repDanceGroup = uow.GetRepository<DanceGroup>();
            var repServerFile = uow.GetRepository<ServerFile>();
            var repMemberDanceGroup = uow.GetRepository<MemberDanceGroup>();
            var repUserRole = uow.GetRepository<UserRole>();
            var repUser = uow.GetRepository<User>();

            repTypeBallroomDance.AddRange(
                new TypeBallroomDance
                {
                    Name = "Самба"
                },
                new TypeBallroomDance
                {
                    Name = "Румба"
                },
                new TypeBallroomDance
                {
                    Name = "Ча-ча-ча"
                },
                new TypeBallroomDance
                {
                    Name = "Танго"
                },
                new TypeBallroomDance
                {
                    Name = "Фокстрот"
                }
            );

            repRussiaTrainerBallroomDance.AddRange(
                new RussiaTrainerBallroomDance
                {
                    TypeBallroomDanceId = 0,
                    FirstName = "Александрова",
                    LastName = "Ольга",
                    MiddleName = "Ивановна"
                },
                new RussiaTrainerBallroomDance
                {
                    TypeBallroomDanceId = 1,
                    FirstName = "Попов",
                    LastName = "Станислав",
                    MiddleName = "Александрович"
                },
                new RussiaTrainerBallroomDance
                {
                    TypeBallroomDanceId = 1,
                    FirstName = "Шалкевич",
                    LastName = "Борис",
                    MiddleName = "Владимирович"
                },
                new RussiaTrainerBallroomDance
                {
                    TypeBallroomDanceId = 1,
                    FirstName = "Попова",
                    LastName = "Татьяна",
                    MiddleName = "Сергеевна"
                },
                new RussiaTrainerBallroomDance
                {
                    TypeBallroomDanceId = 1,
                    FirstName = "Симаков",
                    LastName = "Сергей",
                    MiddleName = "Александрович"
                }
            );

            repDanceGroup.AddRange(
                new DanceGroup
                {
                    RussiaTrainerBallroomDanceId = 0,
                    Name = "Ансамбль танца \"Русские узоры\"",
                    Created = DateTime.Parse("01.01.1995")
                },
                new DanceGroup
                {
                    RussiaTrainerBallroomDanceId = 1,
                    Name = "Танцевальный коллектив \"Элегия\"",
                    Created = DateTime.Parse("01.01.1995")
                },
                new DanceGroup
                {
                    RussiaTrainerBallroomDanceId = 2,
                    Name = "Студенческий танцевальный ансамбль \"Степ\"",
                    Created = DateTime.Parse("01.01.1987")
                },
                new DanceGroup
                {
                    RussiaTrainerBallroomDanceId = 3,
                    Name = "Детский хореографический ансамбль \"Вихрь\"",
                    Created = DateTime.Parse("01.01.1995")
                },
                new DanceGroup
                {
                    RussiaTrainerBallroomDanceId = 4,
                    Name = "Школа танцев \"Harmony\"",
                    Created = DateTime.Parse("01.01.1998")
                }
            );

            repServerFile.AddRange(
                new ServerFile
                {
                    Name = "sunset_paradise.png",
                    Size = 265
                },
                new ServerFile
                {
                    Name = "winter_wonderland.png",
                    Size = 228
                },
                new ServerFile
                {
                    Name = "enchanted_forest.png",
                    Size = 42
                },
                new ServerFile
                {
                    Name = "crystal_clear.png",
                    Size = 616
                },
                new ServerFile
                {
                    Name = "starry_sky.png",
                    Size = 146
                }
            );

            repMemberDanceGroup.AddRange(
                new MemberDanceGroup
                {
                    DanceGroupId = 0,
                    GuidPhotoFile = Guid.Parse("b2cf222f-f8bc-4d9f-bdf3-0793548b9b4e"),
                    FirstName = "Михаил",
                    LastName = "Михайлов",
                    MiddleName = "Михайлович",
                    City = "Москва",
                    Category = "3а",
                    Score = 2
                },
                new MemberDanceGroup
                {
                    DanceGroupId = 1,
                    GuidPhotoFile = Guid.Parse("81b32613-9432-4acd-b325-a69e47859b3f"),
                    FirstName = "Михаил",
                    LastName = "Михайлов",
                    MiddleName = "Михайлович",
                    City = "Москва",
                    Category = "3а",
                    Score = 2
                },
                new MemberDanceGroup
                {
                    DanceGroupId = 0,
                    GuidPhotoFile = Guid.Parse("277501f5-5604-4d6e-bb36-9ceb2ba29462"),
                    FirstName = "Михаил",
                    LastName = "Михайлов",
                    MiddleName = "Михайлович",
                    City = "Москва",
                    Category = "3а",
                    Score = 2
                },
                new MemberDanceGroup
                {
                    DanceGroupId = 0,
                    GuidPhotoFile = Guid.Parse("5392ff98-b209-47f6-bd7f-94f4be0599b8"),
                    FirstName = "Михаил",
                    LastName = "Михайлов",
                    MiddleName = "Михайлович",
                    City = "Москва",
                    Category = "3а",
                    Score = 2
                },
                new MemberDanceGroup
                {
                    DanceGroupId = 1,
                    GuidPhotoFile = Guid.Parse("a63e5ec8-67a7-431b-a3a8-b6898c3c96c4"),
                    FirstName = "Михаил",
                    LastName = "Михайлов",
                    MiddleName = "Михайлович",
                    City = "Москва",
                    Category = "3а",
                    Score = 2
                }
            );

            repUserRole.AddRange(
                new UserRole
                {
                    Name = "admin"
                },
                new UserRole
                {
                    Name = "client"
                }
            );

            repUser.AddRange(
                new User
                {
                    IdUserRole = 0,
                    Login = "Kira",
                    Email = "Kira@email.com",
                    Password = "8On8WBVO4/96H1HaMsc2hw7eYlGRLnz2WrqEnuL12R7TCwHLTC2WUXyxf4W9h+8gZY/w0b7hs7Z8NEYL/UnO7g==",
                    Created = DateTime.Parse("2024-03-15 01:52:03.9154364"),
                    Updated = null
                }
            );

            context.SaveChanges();
            return context;
        }
        
        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
