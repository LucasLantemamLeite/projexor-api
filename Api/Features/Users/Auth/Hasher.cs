using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Api.Features.Users.Auth;

public static class Hasher
{
    private readonly static int Memory = 1024 * 128;
    private readonly static int Iterations = 3;
    private readonly static int Parallelism = 2;

    public static string GenerateHash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);

        var argon = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            MemorySize = Memory,
            Iterations = Iterations,
            DegreeOfParallelism = Parallelism
        };

        var hash = argon.GetBytes(32);

        return Convert.ToBase64String(salt.Concat(hash).ToArray());
    }

    public static bool VerifyHash(string passwordStore, string passwordVerify)
    {
        var originalHash = Convert.FromBase64String(passwordStore);

        var salt = originalHash.Take(16).ToArray();

        var hashStore = originalHash.Skip(16).ToArray();

        var argon = new Argon2id(Encoding.UTF8.GetBytes(passwordVerify))
        {
            Salt = salt,
            MemorySize = Memory,
            Iterations = Iterations,
            DegreeOfParallelism = Parallelism
        };

        var passwordHash = argon.GetBytes(32);

        return CryptographicOperations.FixedTimeEquals(hashStore, passwordHash);
    }
}