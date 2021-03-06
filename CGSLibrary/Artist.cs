using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGSLibrary
{
    public class Artist : Person
    {
        public string ArtistID { get; set; }
        public Artist()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            ArtistID = string.Empty;
        }
        //OVERRIDE ToString() METHOD FOR ARTIST
        public override string ToString()
        {
            return $"Artist ID: {this.ArtistID}\t\tName: {this.FirstName} {this.LastName}\n";
        }
    }
}
