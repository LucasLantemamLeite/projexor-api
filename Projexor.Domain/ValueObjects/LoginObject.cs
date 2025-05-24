namespace Projexor.Domain.ValueObjects;

public class Login : ValueObject
{
    public string LoginValue { get; }

    public Login(string login)
    {
        if (IsValidLogin(login))
            throw new ArgumentException("Login não pode ser Vazio ou Nulo.");

        LoginValue = login;
    }

    public bool IsValidLogin(string login) => !string.IsNullOrEmpty(login);
}