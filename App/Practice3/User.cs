using System.Text.RegularExpressions;

namespace App.Practice3;

public class User
{
    public Guid Id { get; init; }
    public DateTime RegisterDate { get; init; }
    
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Inn { get; set; }

    private string _phone;
    public string Phone
    {
        get => _phone;
        set
        {
            if (!TryUpdatePhone(value))
            {
                throw new ArgumentException("Incorrect phone number.");
            }
        } 
    }

    public User()
    {
        Id = Guid.NewGuid();
        RegisterDate = DateTime.Now;
    }

    public User(string login, string password, string name, string surname, string inn, string phone) : this()
    {
        Login = login;
        Password = password;
        Name = name;
        Surname = surname;
        Inn = inn;
        Phone = phone;
    }
    
    private static bool IsPhoneValid(string inputString) 
    {
        MatchCollection matches = new Regex(@"^(?:\+7|8|7)?[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$").Matches(inputString);

        if (matches.Count != 1 || matches[0].Value.Length != inputString.Length) // второе условие - проверка на то, что в строке нет ничего лишнего
        {
            return false;
        }

        return true;
    }

    private bool TryUpdatePhone(string phone)
    {
        if (IsPhoneValid(phone))
        {
            this._phone = phone;
            return true;
        }
        
        return false;
    }
    
    public string GetUserFullName()
    {
        return $"{Name} {Surname}";
    }
}