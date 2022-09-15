using Microsoft.AspNetCore.Mvc;
namespace WebAPITest.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RequestController : ControllerBase
{
    private readonly ILogger<RequestController> _logger;
    private readonly IRequestRepository _requestRepository;
    public RequestController(ILogger<RequestController> logger, IRequestRepository requestRepository)
    {
        _logger = logger;
        _requestRepository = requestRepository;
    }
    [HttpGet]
    public async Task<ActionResult<Request>> Get(int id)
    {
        var request = await _requestRepository.GetTrackedAsync(x => x.Id == id);
        return Ok(request);
    }
    [HttpPost]
    public async Task<ActionResult<Request>> Post(Request request)
    {
        await _requestRepository.InsertRequest(request);

        return Ok(request);
    }
}