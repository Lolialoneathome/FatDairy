using System;

namespace FatDairy.Domain.Models
{
    public class UserInfo
    {
        public UserInfo(string name, string surname, string password, string email, DateTime birthday, Sex sex)
        {
            Name = (!string.IsNullOrEmpty(name)) ? name : throw new ArgumentNullException(nameof(name));
            Surname = (!string.IsNullOrEmpty(surname)) ? surname : throw new ArgumentNullException(nameof(surname));
            Password = (!string.IsNullOrEmpty(password)) ? password : throw new ArgumentNullException(nameof(password));
            Email = (!string.IsNullOrEmpty(email)) ? email : throw new ArgumentNullException(nameof(email));
            Birthday = (DateTime.Now.Year - Birthday.Year > 0) ? birthday : throw new InvalidOperationException("Birthday in future");
            Sex = sex;

        }

        public string Name { get; }
        public string Surname { get; }
        public string Password { get; } //Yes, ofcource it is very very BAD, but now it is not important
        public string Email { get;  }
        public DateTime Birthday { get; }
        public int Age => DateTime.Now.Year - Birthday.Year;
        public Sex Sex { get; }
    }
}