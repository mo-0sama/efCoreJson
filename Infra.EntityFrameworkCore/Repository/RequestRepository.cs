namespace Infra.EntityFrameworkCore.Repository;
public class RequestRepository : IRequestRepository
{
    private readonly ApplicationDbContext _context;
    public RequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Request> GetTrackedAsync(Expression<Func<Request, bool>> filter)
    {
        var request = await _context.Requests.Include(x => x.BasicInformation).Where(x => x.BasicInformation.UserInfo.JsonValue("$.UserId") == x.Id.ToString()).FirstOrDefaultAsync(filter);
        if (request is null)
            throw new Exception("Request Not Found");
        return request;
    }
    public async Task<Request> InsertRequest(Request request)
    {
        await _context.Requests.AddAsync(request);
        await _context.SaveChangesAsync();
        return request;
    }
}