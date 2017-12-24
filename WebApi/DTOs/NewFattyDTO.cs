using System;

namespace WebApi.DTOs
{
    public class NewFattyDTO
    {
        public DateTime birthday;
        public string email;
        public string name;
        public short sex;
        public string password;
        public string surname;
        public double currentWeight;
        public double desireWeight;
        public double height;
        public bool hideFoodTrack;
        public bool hideAge;
        public bool hideEmail;
    }
}