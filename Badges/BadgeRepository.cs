using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgeRepository
    {

        private readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        // Create
        public void AddBadge(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.DoorAccessList);
        }

        // Read
        public Dictionary<int, List<string>> GetBadgeDictionary()
        {
            return _badgeDictionary;
        }

        // Update
        public bool UpdateBadge(int badgeId, List<string> updatedDoorAccessList)
        {
            if (_badgeDictionary.ContainsKey(badgeId))
            {
                _badgeDictionary[badgeId] = updatedDoorAccessList;
                return true;
            }

            return false;
        }

        // Delete
        public bool DeleteBadge(int badgeId)
        {
            return _badgeDictionary.Remove(badgeId);
        }

       
    }
}
