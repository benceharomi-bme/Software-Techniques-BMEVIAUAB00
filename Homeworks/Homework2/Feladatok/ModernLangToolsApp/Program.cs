using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ModernLangToolsApp
{
    //New delegate
    public delegate void CouncilChangedDelegate(string message);
    class Program
    {
        
        static void Main(string[] args)
        {
            JediCouncil council = new JediCouncil();
            feladat2();
            feladat3();
            feladat4(council);

            Console.ReadKey();
        }

        //This method will be subscribed to the JediCouncil
        static void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }

        //The solution of the 2nd exercise
        [Description("Feladat2")]
        public static void feladat2()
        {
            Jedi obiwan = new Jedi();
            obiwan.Name = "Obi-wan";
            obiwan.MidiChlorianCount = 18000;
            //Serializing into the jedi.txt file
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream outStream = new FileStream("jedi.txt", FileMode.Create);
            serializer.Serialize(outStream, obiwan);
            outStream.Close();

            //Reading back the file, and creating the clone
            serializer = new XmlSerializer(typeof(Jedi));
            FileStream inStream = new FileStream("jedi.txt", FileMode.Open);
            Jedi obiwanClone = (Jedi)serializer.Deserialize(inStream);
            inStream.Close();
        }

        //The solution of the 3rd exercise
        [Description("Feladat3")]
        static void feladat3()
        {
            JediCouncil council = new JediCouncil();
            //Subscription
            council.CouncilChanged += MessageReceived;

            //Adding 2 jedi to the council
            Jedi anakin = new Jedi();
            anakin.Name = "Anakin";
            anakin.MidiChlorianCount = 20000;
            council.Add(anakin);

            Jedi yoda = new Jedi();
            yoda.Name = "Yoda";
            yoda.MidiChlorianCount = 19000;
            council.Add(yoda);

            //Removing the last ones
            council.Remove();
            council.Remove();
        }

        //Initalizer to avoid code duplication
        static void Initialize(JediCouncil council)
        {
            //Adding 3 jedi to the council
            Jedi anakin = new Jedi();
            anakin.Name = "Anakin";
            anakin.MidiChlorianCount = 20000;
            council.Add(anakin);

            Jedi yoda = new Jedi();
            yoda.Name = "Yoda";
            yoda.MidiChlorianCount = 19000;
            council.Add(yoda);

            Jedi luke = new Jedi();
            luke.Name = "Luke";
            luke.MidiChlorianCount = 160;
            council.Add(luke);
        }

        //Solution of the 4th exercise
        [Description("Feladat4")]
        static void feladat4(JediCouncil council)
        {
            List<Jedi> list = new List<Jedi>();
            //Initializing the 3 jedi to the council
            Initialize(council);
            //Using the filter on the list
            list = council.GetBeginners();
            //Printing out the names
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Name);
            }
        }
    }
}
