namespace API_pacPay.Services;

public class PassWordVerificationService
{

    public  bool CheckPassword(string hashedPassword, string dbHashedPassword)
    {

        return hashedPassword.Equals(dbHashedPassword);
    }

    public static string HashPassword(string password)
    {
        Console.WriteLine("asdas " + password);
        var salt = BCrypt.Net.BCrypt.GenerateSalt(16);
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }
}
