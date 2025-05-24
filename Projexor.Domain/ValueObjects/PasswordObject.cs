namespace Projexor.Domain.ValueObjects;

public class Password : ValueObject
{
    public string PassowordValue { get; }

    public Password(string passoword)
    {
        if (!IsValidPassword(passoword))
            throw new ArgumentException("Password não pode ser Vazio ou Nulo.");

        PassowordValue = passoword;
    }

    private bool IsValidPassword(string passoword) => !string.IsNullOrWhiteSpace(passoword);

}