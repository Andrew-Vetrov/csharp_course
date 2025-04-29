using System.Security.Cryptography;
using System.Text;

namespace App.Practice3;

public static class UserCreator
{
    public static User CreateUser(
        string login, string password, string name, 
        string surname, string inn, string phone)
    {
        var hash = ComputeHash(password);
        return new User(login, hash, name, surname, inn, phone);
    }

    private static string ComputeHash(string password)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
        md5.Dispose();
        
        var res = new StringBuilder();
        foreach (var b in hash)
        {
            res.Append(b.ToString("x2"));
        }
        
        return res.ToString();
    }
}