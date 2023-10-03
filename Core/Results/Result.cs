namespace Core.Results;

public class Result
{
    public string? Message { get; set; }
    public ResultStatus Status { get; set; }

    public Result(string? message, ResultStatus status = ResultStatus.Ok)
    {
        Message = message;
        Status = status;
    }
}

public enum ResultStatus
{
    Ok,
    Error,
    Forbidden,
    Unauthorized,
    Invalid,
    NotFound
}