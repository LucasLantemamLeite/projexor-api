using Projexor.Domain.ValueObjects;

namespace Projexor.Domain.Entities;

public class UserAccount
{

    public int Id { get; private set; }
    public Name Name { get; private set; }




    public UserAccount(string name)
    {
        Name = new Name(name);
    }

}