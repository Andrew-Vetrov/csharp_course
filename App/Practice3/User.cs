using System.Text.RegularExpressions;

namespace App.Practice3;

public class User
{
    private static readonly Regex regex = new Regex(@"^(?:\+7|8|7)?[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$");
    
    private readonly Guid id;
    private readonly DateTime registerDate;
    
    private string login;
    private string password;
    private string name;
    private string surname;
    private string inn;
    private string phone;

    public User(string login, string password, string name, string surname, string inn, string phone)
    {
        this.id = Guid.NewGuid();
        this.registerDate = DateTime.Now;
        this.login = login;
        this.password = password;
        this.name = name;
        this.surname = surname;
        this.inn = inn;
        this.phone = phone;
    }
    
    private static bool IsPhoneValid(string inputString) 
    {
        var matches = regex.Matches(inputString);

        if (matches.Count != 1 || matches[0].Value.Length != inputString.Length) // второе условие - проверка на то, что в строке нет ничего лишнего
        {
            return false;
        }

        return true;
    }

    public bool TryUpdatePhone(string phone)
    {
        if (IsPhoneValid(phone))
        {
            this.phone = phone;
            return true;
        }
        
        return false;
    }
    
    public string GetUserFullName()
    {
        return $"{name} {surname}";
    }
}