using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace seriliazation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person(346875) { Name = "Jack", Age = 34 },
                new Person(975648) { Name = "Bob", Age = 37 },
                new Person(870312) { Name = "John", Age = 23 }

            };
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Person>));
            using(Stream fs = File.Create("test.txt"))
            {
                xmlFormat.Serialize(fs, persons);
            }
            Console.WriteLine("BinarySerialize OK!\n");

            List<Person> list = null;
            using (Stream fs = File.OpenRead("test.txt"))
            {
                list = (List<Person>)xmlFormat.Deserialize(fs);
            }
            foreach(Person item in list)
            {
                Console.WriteLine(item);
            }
            
            //Person person = new Person(38273) { Name = "Jack", Age = 34 };

            //BinaryFormatter binFormat = new BinaryFormatter();

            //using (Stream fs = File.Create("test.txt"))
            //{
            //    binFormat.Serialize(fs, person);
            //}
            //Console.WriteLine("BinarySerialize OK!\n");
            //Person p = null;
            //using(Stream fs = File.OpenRead("test.txt"))
            //{
            //    p = (Person)binFormat.Deserialize(fs);
            //}
            //Console.WriteLine(p);
        }
    }
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int _identNumber;
        [NonSerialized]
        const string Planet = "Earth";

        public Person() { }
        public Person(int number)
        { this._identNumber = number; }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, " + $"Identification number: {_identNumber}, " + $"Planet: {Planet}.";

        }
    }


    
}
