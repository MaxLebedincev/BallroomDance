﻿using BallroomDance.API.Domain.Entity;

namespace BallroomDance.API.Controllers.TypeBallroomDanceInteraction
{
    public class TypeBallroomDanceDTO : TypeBallroomDanceRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
    }
}
