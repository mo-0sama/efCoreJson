namespace Infra.EntityFrameworkCore.Entities;
public class Request
{
    public int Id { get; set; }
    public int Status { get; set; }
    public int CreatorId { get; set; }
    public BasicInformation BasicInformation { get; set; }
}