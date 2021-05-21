using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }        
        public Badge() { }
        public Badge(int badgeID, List<string> doorAccess)
        {
            BadgeID = badgeID;
            DoorAccess = doorAccess;            
        }

    }
}
