using System.Diagnostics;

namespace mega.Api.Application;

public record Result<T>
{
    public T? Data { get; set; }
    public ResultCode Code { get; set; } = ResultCode.Success;
    public bool IsSuccess => Code == ResultCode.Success;

    public Result(T data)
    {
        Data = data;
    }

    public Result(ResultCode code)
    {
        Debug.Assert(code != ResultCode.Success, "Success code should not be used for failure");
        Code = code;
    }
}

public record ResultContext<T> : Result<T>
{
    public ResultContext(string message, string correlationId, ResultCode code) : base(code)
    {
        Message = message;
        CorrelationId = correlationId;
    }

    public string Message { get; set; }
    public string CorrelationId { get; set; }
}

public enum ResultCode
{
    Success = 0,
    EntityNotFound,
    InternalServerError,
    BusinessRuleViolation,
}
