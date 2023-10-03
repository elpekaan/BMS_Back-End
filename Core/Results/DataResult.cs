namespace Core.Results;

public class DataResult<T> : Result where T : class
{
    public T? Data { get; set; }

    public DataResult(T? data = null, string ? message = null, ResultStatus status = ResultStatus.Ok) : base(message, status)
    {
        Data = data;
    }
}