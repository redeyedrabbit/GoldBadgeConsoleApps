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
        public bool AddBadge(Badge newBadge)
        {
            int startingCount = _itemDirectory.Count;
            _itemDirectory.Add(newItem);
            bool wasAdded = (_itemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        
    }
}
