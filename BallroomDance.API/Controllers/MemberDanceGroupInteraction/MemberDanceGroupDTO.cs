namespace BallroomDance.API.Controllers.MemberDanceGroupInteraction
{
    public class MemberDanceGroupDTO : MemberDanceGroupRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
    }
}
