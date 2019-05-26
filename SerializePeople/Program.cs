using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializePersonDemo();
            SerializePerson2Demo();

        }

        public static void SerializePerson2Demo()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SerializePerson2(@"C:\SerializedPerson2.txt", formatter);

            Person2 person = DeserializePerson2(@"C:\SerializedPerson2.txt", formatter);
            Console.WriteLine(person.ToString());
            Console.ReadLine();
        }

        public static void SerializePersonDemo()
        {
            DateTime dob = new DateTime(1993, 9, 17, 18, 32, 0);
            Person person1 = new Person("Zoli", dob, Gender.Male);
            person1.Serialize(@"C:\SerializedPerson.txt");
            person1 = null;

            person1 = Person.Deserialize(@"C:\SerializedPerson.txt");

            Console.WriteLine(person1.ToString());
            Console.ReadLine();
        }


        public static void SerializePerson2(string fileName, IFormatter formatter)
        {
            Person2 person = new Person2();
            person.DateOfBirth = new DateTime(1998, 9, 17, 18, 32, 0);
            person.Name = "Máté";
            person.Gender = Gender.Male;
            person.SetAgeManually();

            FileStream stream = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(stream, person);
            stream.Close();
        }

        public static Person2 DeserializePerson2(string fileName, IFormatter formatter)
        {
            FileStream stream = new FileStream(fileName, FileMode.Open);
            Person2 person = (Person2)formatter.Deserialize(stream);

            return person;
        }
    }
}
