namespace Infra.EntityFrameworkCore.Entities;
public class UserInfoModel
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string LicenseNumber { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
}