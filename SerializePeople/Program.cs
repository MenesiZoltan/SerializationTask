using System;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dob = new DateTime(1993, 9, 17, 18, 32, 0);
            Person person1 = new Person("Zoli", dob, Gender.Male);
            person1.Serialize(@"C:\SerializedPerson.txt");
            person1 = null;

            person1 = Person.Deserialize(@"C:\SerializedPerson.txt");

            Console.WriteLine(person1.ToString());
            Console.ReadLine();
        }
    }
}
