using _03_Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    class BadgeUI
    {
        private BadgeRepository _repo = new BadgeRepository();
        public void Run()
        {
            SeedContentList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        //Exit Menu
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number");
                        break;
                }
                Console.WriteLine("Please Press Any Key To Continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void AddBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            // Badge Number
            Console.WriteLine("What is the number on the badge:");
            string badgeNumberAsString = Console.ReadLine();
            int badgeNumberAsInt = Convert.ToInt32(badgeNumberAsString);
            newBadge.BadgeID = badgeNumberAsInt;
            // Door Access
            Console.WriteLine("List a door that it needs access to:");
            string door = Console.ReadLine();
            newBadge.DoorAccess.Add(door);
            bool addMoreDoors = true;
            while (addMoreDoors)
            {
                Console.WriteLine("Any other doors (y/n)?");
                string input = Console.ReadLine().ToLower();
                if (input.Contains("y"))
                {
                    Console.WriteLine("List a door that it needs access to:");
                    string doorTwo = Console.ReadLine();
                    newBadge.DoorAccess.Add(doorTwo);
                }
                else
                {
                    addMoreDoors = false;
                    Menu();
                }
                bool wasAddedCorrectly = _repo.AddBadge(newBadge);
                if (wasAddedCorrectly)
                {
                    Console.WriteLine("Great success!\n" +
                        "The badge was added correctly! ");
                }
                else
                {
                    Console.WriteLine("Fail\n" +
                        "The badge could not be added. Please try again.");
                }
            }

        }
        public void EditBadge()
        {
            Console.Clear();
            ViewAllBadges();
            Console.WriteLine("What is the badge number to update? ");
            int IDOfBadgeToUpdate = Convert.ToInt32(Console.ReadLine());
            Badge selectedBadge = _repo.GetBadgeByID(IDOfBadgeToUpdate);
            //Badge doorAccess = new Badge();
            // Display badge door access

            Console.WriteLine($"{IDOfBadgeToUpdate} has access to doors {selectedBadge.DoorAccess}");
            // Edit badge
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            string input = Console.ReadLine().ToLower();
            if (input.Contains("1"))
            {
                Console.WriteLine("Which door would you like to remove?");
                string door = Console.ReadLine();
                selectedBadge.DoorAccess.Add(door);
                bool wasDeleted = _repo.RemoveDoorAccess(IDOfBadgeToUpdate, Console.ReadLine());
                if (wasDeleted)
                {
                    Console.WriteLine($"Door removed.\n" +
                        input +
                    $" has access to door {door}");
                }
                else
                {
                    Console.WriteLine("The badge door access could not be removed. Please try again.");
                }
            }
            else
            {
                Menu();
            }
        }
        private void ViewAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> allContent = _repo.ViewAllBadges();
            foreach (KeyValuePair<int, List<string>> content in allContent)
            {
                Console.WriteLine($"Key\n" +
                    $"Badge # {content.Key}\n" +
                    $"Door Access: {content.Value}\n");
            }
        }
        public void SeedContentList()
        {
            Badge badgeOne = new Badge(12345, new List<string> { "A7" });
            Badge badgeTwo = new Badge(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badge badgeThree = new Badge(32345, new List<string> { "A4", "A5" });
            _repo.AddBadge(badgeOne);
            _repo.AddBadge(badgeTwo);
            _repo.AddBadge(badgeThree);
        }
    }
}
