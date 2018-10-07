using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.personkartotek
{
    public class Note
    {
        public Note(int personID, int noteID, string noteData)
        {
            this.personID = personID;
            this.noteID = noteID;
            this.noteData = noteData;
        }

        public int personID { get; set; }
        public int noteID { get; set; }
        public string noteData { get; set; }

        
    }
}
