using Projexor.Domain.ValueObjects;

namespace Projexor.Domain.Entities;

public class UserAccount
{

    public int Id { get; private set; }
    public Name Name { get; private set; }
    public Login Login { get; private set; }
    public Password PasswordHash { get; private set; }



    public UserAccount(string name, string login, string password)
    {
        Name = new Name(name);
        Login = new Login(login);
        PasswordHash = new Password(password);
    }

}