using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static ModernLangToolsApp.Program;

namespace ModernLangToolsApp
{
    class JediCouncil
    {
        //The event handler
        public event CouncilChangedDelegate CouncilChanged;

        //Empty list
        List<Jedi> members = new List<Jedi>();
        public void Add(Jedi newJedi)
        {
            members.Add(newJedi);
            //When a new member added then starts event
            if (CouncilChanged != null)
                CouncilChanged("Új taggal bővültünk");
        }
        public void Remove()
        {
            // Removing the last item of the list
            members.RemoveAt(members.Count - 1);

            //When someone leaves the council then starts event
            if (CouncilChanged != null)
            {
                if (members.Count > 0)
                    CouncilChanged("Zavart érzek az erőben");
                else
                    //And a different message when the council becomes empty
                    CouncilChanged("A tanács elesett!");

            }
        }

        //FindAll method returns with the values where the filter true
        public List<Jedi> GetBeginners()
        {
            return members = members.FindAll(MyFilter);
        }

        //The filter for the list
        public bool MyFilter(Jedi j)
        {
            return (j.MidiChlorianCount < 300);
        }

    }
}
