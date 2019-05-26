using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    public class Person : IDeserializationCallback
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [NonSerialized]
        private int Age;

        public Person()
        {

        }

        public int GetAge()
        {
            return Age;
        }

        public Person(string name, DateTime dob, Gender gender)
        {
            Name = name;
            DateOfBirth = dob;
            Gender = gender;
            Age = calculateAge();
        }

        public void Serialize(string output)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(output, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, this);
            stream.Close();
        }

        public override string ToString()
        {
            return $"Name: {Name}; DateOfBirth: {DateOfBirth.Date}; Gender: {Gender}; Age: {Age}";
        }


        public static Person Deserialize(string filename)
        {
            Person person;

            //Format the object as Binary
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Open(filename, FileMode.Open);
            object obj = formatter.Deserialize(stream);
            person = (Person)obj;

            stream.Flush();
            stream.Close();
            stream.Dispose();

            return person;
        }

        public void OnDeserialization(object sender)
        {
            this.Age = calculateAge();
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
