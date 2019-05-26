using System;
using System.Text;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace SerializePeople
{
    [Serializable]
    public class Person2 : ISerializable
    {
        private string NameValue;
        private DateTime DateOfBirthValue;
        private Gender GenderValue;
        private int AgeValue;

        public string Name
        {
            get { return NameValue; }
            set { NameValue = value; }
        }
        public DateTime DateOfBirth
        {
            get { return DateOfBirthValue; }
            set { DateOfBirthValue = value; }
        }
        public Gender Gender
        {
            get { return GenderValue; }
            set { GenderValue = value; }
        }
        public int Age
        {
            get { return AgeValue; }
        }


        public Person2()
        {
            /// empty constructor for compile
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", NameValue);
            info.AddValue("DateOfBirthValue", DateOfBirthValue);
            info.AddValue("Gender", GenderValue);
        }

        public Person2(SerializationInfo info, StreamingContext context)
        {
            this.Name = (string)info.GetValue("Name", typeof(string));
            this.DateOfBirth = (DateTime)info.GetValue("DateOfBirthValue", typeof(DateTime));
            this.Gender = (Gender)info.GetValue("Gender", typeof(Gender));
            this.AgeValue = calculateAge();   

        }

        public void SetAgeManually() { AgeValue = calculateAge(); }

        public override string ToString()
        {
            return $"Name: {Name}; DateOfBirth: {DateOfBirth.Date}; Gender: {Gender}; Age: {Age}";
        }

        private int calculateAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
