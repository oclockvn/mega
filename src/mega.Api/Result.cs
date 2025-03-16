using System.Diagnostics;

namespace mega.Api;

public record struct Result<T>
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

public enum ResultCode
{
    Success = 0,
    EntityNotFound,
}
