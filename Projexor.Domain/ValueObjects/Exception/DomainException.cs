namespace Projexor.Domain.ExceptionExtension;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }

    public static void ThrowIfError(string message)
    {
        if (!string.IsNullOrWhiteSpace(message))
            throw new DomainException(message);
    }

}