namespace Projexor.Domain.ValueObjects;

public class Name : ValueObject
{
    public string NameObject { get; }

    public Name(string name)
    {

        if (!IsValidName(name))
            throw new ArgumentException("Name não pode ser Vazio ou Nulo.");

        NameObject = name;
    }

    private bool IsValidName(string name) => !string.IsNullOrEmpty(name);
}