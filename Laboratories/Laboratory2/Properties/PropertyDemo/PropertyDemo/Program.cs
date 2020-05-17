using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PropertyDemo
{
    public delegate void AgeChangingDelegate(int oldAge, int newAge);
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            //p.AgeChanging = new AgeChangingDelegate(PersonAgeChanging);
            p.AgeChanging += PersonAgeChanging;
            p.AgeChanging += PersonAgeChanging;
            p.AgeChanging -= PersonAgeChanging;
            //p.AgeChanging = null;
            p.Age = 24;
            p.Name = "Luke";
            p.Age++;
            Console.WriteLine(p.Age);
            Console.WriteLine(p.Name);
            //p.AgeChanging(67, 12);

            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            FileStream stream = new FileStream("person.txt", FileMode.Create);
            serializer.Serialize(stream, p);
            stream.Close();
            Process.Start("person.txt");
        }

        static void PersonAgeChanging(int oldAge, int newAge)
        {
            Console.WriteLine(oldAge + " => " + newAge);
        }
    }
}
