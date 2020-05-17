using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApp
{
    class Song
    {
        public readonly string Artist;
        public readonly string Title;
        public Song(string artist, string title)
        {
            Artist = artist;
            Title = title;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Artist, Title);
        }

    }
}
