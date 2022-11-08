using Microsoft.AspNetCore.Mvc;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Arguments;

public class BaseResponse<T>
{
    public BaseResponse()
    {
    }

    public BaseResponse(T data, List<string> messages = null, int statusCode = 200)
    {
        Data = data;
        Messages = messages;
        StatusCode = statusCode;
    }

    public BaseResponse(T data)
    {
        Data = data;
        Messages = new List<string>();
        StatusCode = 200;
    }

    public int StatusCode { get; set; }
    public bool Success => StatusCode >= 200 && StatusCode <= 299;
    public List<string> Messages { get; set; }
    public T Data { get; set; }

    public ActionResult ToActionResult
    {
        get
        {
            switch (StatusCode)
            {
                case 200:
                    return new OkObjectResult(this);
                case 400:
                    return new BadRequestObjectResult(this);
                case 401:
                    return new UnauthorizedObjectResult(this);
                case 404:
                    return new NotFoundObjectResult(this);
                case 500:
                    return new StatusCodeResult(500);
                default:
                    return new StatusCodeResult(500);
            }
        }
    }

    public void AddNotifications(IReadOnlyCollection<Notification> roomServiceNotifications)
    {
        roomServiceNotifications.ToList().ForEach(x => Messages.Add(x.Message));
    }
}
