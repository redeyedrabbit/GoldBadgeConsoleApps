using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repo
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> BadgeDictionary = new Dictionary<int, List<string>>();
        // Add Badge
        public bool AddBadge(Badge newBadge)
        {
            int startingCount = BadgeDictionary.Count;
            BadgeDictionary.Add(newBadge.BadgeID, newBadge.DoorAccess);
            bool wasAdded = (BadgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }
        // View All Badges
        public Dictionary<int, List<string>> ViewAllBadges()
        {
            return BadgeDictionary;
        }
        // View Specific Badge by Badge ID
        public Badge ViewBadgeByID(int badgeID)
        {
            Badge tempBadge = new Badge();
            foreach (KeyValuePair<int, List<string>> badgeDoorAccess in BadgeDictionary)
            {
                if (BadgeDictionary.ContainsKey(badgeID))
                {
                    tempBadge.BadgeID = badgeDoorAccess.Key;
                    tempBadge.DoorAccess = badgeDoorAccess.Value;
                    return tempBadge;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        // Remove Door Access
        public bool RemoveDoorAccess(int badgeID, string itemToDelete)
        {
            Badge tempBadge = ViewBadgeByID(badgeID);            
            {
                if (!tempBadge.DoorAccess.Contains(itemToDelete))
                {
                    return false;
                }
                else
                {
                    tempBadge.DoorAccess.Remove(itemToDelete);
                    BadgeDictionary[badgeID] = tempBadge.DoorAccess;
                    return true;
                }
            }         
            
        }
        // Get Badge
        public Badge GetBadgeByID(int badgeID)
        {
            Badge badge = new Badge(badgeID, BadgeDictionary[badgeID]);
            return badge;
        }

    }
}
