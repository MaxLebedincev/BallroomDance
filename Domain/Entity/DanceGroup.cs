namespace BallroomDanceAPI.Domain.Entity
{
    public class DanceGroup
    {
        public int Id { get; set; }

        public int? RussiaTrainerBallroomDanceId { get; set; }
        public RussiaTrainerBallroomDance? RussiaTrainerBallroomDance { get; set; }

        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }

        public List<MemberDanceGroup> MemberDanceGroups { get; set; } = new();
    }
}
