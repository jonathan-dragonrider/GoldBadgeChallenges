using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesUI
    {
        private bool _isRunning = true;
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();

        public BadgesUI()
        {

        }

        public void Start()
        {
            SeedMenuList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine(
                "Enter a Number:\n" +
                "1. List all badges\n" +
                "2. Add a new badge\n" +
                "3. Edit a badge\n" +
                "4. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    // list all badges
                    ListBadges();
                    break;
                case "2":
                    // add a new badge
                    AddNewBadge();
                    break;
                case "3":
                    // edit a badge
                    EditBadge();
                    break;
                case "4":
                    // exit
                    _isRunning = false;
                    return;
                default:
                    // invalid selection
                    return;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private void ListBadges()
        {

            var badges = _badgeRepo.GetBadgeDictionary();

            Console.WriteLine("Badge #\t" +
                "Door Access");

            foreach (var badge in badges)
            {
                DisplayContent(badge);
            }
        }

        private void DisplayContent(KeyValuePair<int, List<string>> badge)
        {
            string doors = "";
            foreach (var door in badge.Value)
            {
                doors = doors + door + " ";
            }
            Console.WriteLine($"{badge.Key}\t" +
                $"{doors}");
        }

        private void AddNewBadge()
        {

            var badge = new Badge();

            Console.WriteLine("Enter Badge ID:");
            int badgeId = Convert.ToInt32(Console.ReadLine());
            badge.BadgeID = badgeId;

            badge.DoorAccessList = GetListOfDoors();

            _badgeRepo.AddBadge(badge);
        }

        private List<string> GetListOfDoors()
        {
            Console.WriteLine("Enter access door(s) separated by a space:");

            while (true)
            {
                string doorsString = Console.ReadLine();
                List<string> doorsList = doorsString.Split(' ').ToList();
                return doorsList;

            }
        }

        private void EditBadge()
        {
            Console.WriteLine("Enter badge ID:");
            int badgeId = Convert.ToInt32(Console.ReadLine());
            var badges = _badgeRepo.GetBadgeDictionary();

            string doors = "";
            foreach (var door in badges[badgeId])
            {
                doors = doors + door + " ";
            }

            Console.WriteLine($"Badge {badgeId} has access to doors {doors}");

            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");

            var response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string doorRemove = Console.ReadLine();
                    badges[badgeId].Remove(doorRemove);
                    Console.WriteLine("Door removed.");
                    break;
                case "2":
                    Console.WriteLine("Which door would you like to add?");
                    string doorAdd = Console.ReadLine();
                    badges[badgeId].Add(doorAdd);
                    Console.WriteLine($"{badgeId} now has access to door(s) {doorAdd}");
                    break;
                default:
                    break;
            }

        }

        private void SeedMenuList()
        {
            var badgeOne = new Badge(1, new List<string>() { "A1" });
            var badgeTwo = new Badge(2, new List<string>() { "A2" });
            var badgeThree = new Badge(3, new List<string>() { "A3" });

            _badgeRepo.AddBadge(badgeOne);
            _badgeRepo.AddBadge(badgeTwo);
            _badgeRepo.AddBadge(badgeThree);
        }
    }
}
