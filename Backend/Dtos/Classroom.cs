using System;

namespace Backend.Dtos;

public abstract class ClassroomDto
{
    public string RoomNumber { get; set; }
    public int Capacity { get; set; }
}

public class ShowClassroomDto : ClassroomDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class CreateClassroomDto : ClassroomDto
{

}
