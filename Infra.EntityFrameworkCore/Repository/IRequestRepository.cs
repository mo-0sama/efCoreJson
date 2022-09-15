namespace Infra.EntityFrameworkCore.Interfaces;
public interface IRequestRepository 
{
    Task<Request> GetTrackedAsync(Expression<Func<Request, bool>> filter);
    Task<Request> InsertRequest(Request request);
}
