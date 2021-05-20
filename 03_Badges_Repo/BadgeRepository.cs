using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _BadgeDictionary = new Dictionary<int, List<string>>();
        public bool EditBadge(int originalMealNumber, MenuItem newItemValue)
        {
            Badge oldDoorAccess = GetBadgeID(originalBadgeID);
            if (oldDoorAccess != null)
            {
                oldDoorAccess.DoorAccess = newDoorAccess.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
