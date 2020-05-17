using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi")]
    public class Jedi
    {
        //Attributes
        private string name;
        private int midiChlorianCount;

        //Properties
        [XmlAttribute("Nev")]
        public string Name { get; set; }

        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianCount
        {
            get { return midiChlorianCount; }
            set 
            {
                //Checking if the value of the Midi-chlorian is more than 10 or not
                //If not it throws an exception
                if(value<=10)
                    throw new ArgumentException("You are not a true jedi!");
                //Default
                midiChlorianCount = value; 
            }
        }
    }
}
