using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class Badge
    {
        public Badge()
        {

        }

        public Badge(int badgeId, List<string> doorAccessList)
        {
            BadgeID = badgeId;
            DoorAccessList = doorAccessList;
        }

        public int BadgeID { get; set; }
        public List<string> DoorAccessList { get; set; }

    }
}
