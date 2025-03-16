namespace mega.Api.Application.Exceptions;

public class BusinessRuleViolationException(string message) : Exception(message)
{
}
