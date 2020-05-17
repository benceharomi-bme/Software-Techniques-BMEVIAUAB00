using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PropertyDemo
{
    [XmlRoot("Személy")]
    public class Person
    {
        public event AgeChangingDelegate AgeChanging;

        private int age;

        [XmlAttribute("Kor")]
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Gondolkozz!!!");
                if (AgeChanging != null)
                    AgeChanging(age, value);
                age = value;
            }
        }

        [XmlIgnore]
        public string Name { get; set; }
    }
}

