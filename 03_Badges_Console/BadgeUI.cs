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
        private void AddBadge()
        {
            Console.Clear();
            Badge newContent = new Badge();
            // Badge Number
            Console.WriteLine("What is the number on the badge:");
            string badgeNumberAsString = Console.ReadLine();
            int badgeNumberAsInt = Convert.ToInt32(badgeNumberAsString);
            newContent.BadgeNumber = badgeNumberAsInt;
            // Door Access
            Console.WriteLine("List a door that it needs access to:");
            newContent.DoorAccess = Console.ReadLine();
            Console.WriteLine("Any other doors (y/n)?");
            string input = Console.ReadLine().ToLower();
            if (input.Contains("y"))
            {
                _repo.AddDoor(content);
            }
            else
            {
                Menu();
            }
            bool wasAddedCorrectly = _repo.AddItemToDirectory(newContent);
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
        public void EditBadge()
        {
            Console.Clear();
            ListAllBadges();
            Console.WriteLine("What is the badge number to update? ");
            int oldBadgeNumber = Convert.ToInt32(Console.ReadLine());
            Badge newBadgeValue = new BadgeNumber();
            // Display badge door access
            displayAccess();
            // Edit badge
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door");
            string input = Console.ReadLine().ToLower();
            if (input.Contains("1"))
            {
                Console.WriteLine("Which door would you like to remove?");
                bool wasDeleted = _repo.DeleteExistingDoorAccess(Console.ReadLine());
                if (wasDeleted)
                {
                    Console.WriteLine("Door removed.\n" +
                        {input.BadgeNumber}" has access to door "{ displayAccess});

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
            List<Badge> allContent = _repo.BadgeDictionary();
            foreach (Badge content in allContent)
            {
                Console.WriteLine($"Key\n" +
                    $"Badge # {content.BadgeID}\n" +
                    $"Door Access: {content.DoorAccess}");
            }
        }
        public void SeedContentList()
        {
            Badge badgeOne = new Badge(12345, "A7");
            Badge badgeTwo = new Badge(22345, "A1, A4, B1, B2");
            Badge badgeThree = new Badge(32345, "A4, A5");
            _repo.AddBadgeToDirectory(badgeOne);
            _repo.AddBadgeToDirectory(badgeTwo);
            _repo.AddBadgeToDirectory(badgeThree);
        }
    }
}
