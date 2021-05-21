using _01_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    public class CafeUI
    {
        private MenuRepository _repo = new MenuRepository();
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
                Console.WriteLine("Select a Menu Option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. Update Menu Item\n" +
                    "3. Delete Menu Item" +
                    "4. View All Menu Items \n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        UpdateMenuItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        DisplayAllMenuItems();
                        break;
                    case "5":
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
        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem newContent = new MenuItem();
            // Meal Number
            Console.WriteLine("Enter a Meal Number:");
            string mealNumberAsString = Console.ReadLine();
            int mealNumberAsInt = Convert.ToInt32(mealNumberAsString);
            newContent.MealNumber = mealNumberAsInt;
            // Meal Name
            Console.WriteLine("Enter a Meal Name:");
            newContent.MealName = Console.ReadLine();
            // Meal Description
            Console.WriteLine("Enter the description for this meal:");
            newContent.MealDescription = Console.ReadLine();
            // Ingredients
            Console.WriteLine("List the ingredients included in this meal:");
            newContent.MealIngredients = Console.ReadLine();
            // Price
            Console.WriteLine("Enter the price for this meal (ie: 5.99):");
            string mealPriceAsString = Console.ReadLine();
            double mealPriceAsDouble = Convert.ToDouble(mealPriceAsString);
            newContent.MealPrice = mealPriceAsDouble;
            // Confirmation Message
            bool wasAddedCorrectly = _repo.AddItemToDirectory(newContent);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("Great success!\n" +
                    "The new menu item was added correctly! ");
            }
            else
            {
                Console.WriteLine("Fail\n" +
                    "The new menu item could not be added. Please try again.");
            }
        }
        public void UpdateMenuItem()
        {
            Console.Clear();
            DisplayAllMenuItems();
            Console.WriteLine("Enter the meal number of the menu item you would like to update");
            int oldMealNumber = Convert.ToInt32(Console.ReadLine());
            MenuItem newItemValue = _repo.GetMenuItemByNumber(oldMealNumber);
            // Meal Number
            Console.WriteLine("What is the new meal number?");
            string mealNumberAsString = Console.ReadLine();
            int mealNumberAsInt = Convert.ToInt32(mealNumberAsString);            
            newItemValue.MealNumber = mealNumberAsInt;
            // Meal Name
            Console.WriteLine("What is the new meal name?");
            newItemValue.MealName = Console.ReadLine();
            // Meal Description
            Console.WriteLine("What is the new meal description?");
            newItemValue.MealDescription = Console.ReadLine();
            // Meal Ingredients
            Console.WriteLine("What are the new meal ingredients?");
            newItemValue.MealIngredients = Console.ReadLine();
            // Meal Price
            Console.WriteLine("What is the new meal price?");
            string mealPriceAsString = Console.ReadLine();
            double mealPriceAsInt = Convert.ToDouble(mealPriceAsString);
            newItemValue.MealPrice = mealPriceAsInt;
        }
        private void DeleteMenuItem()
        {
            Console.Clear();
            DisplayAllMenuItems();
            Console.WriteLine("Enter the menu item number you want to delete:");
            bool wasDeleted = _repo.DeleteExistingItem(Convert.ToInt32(Console.ReadLine()));
            if (wasDeleted)
            {
                Console.WriteLine("The menu item was successfully deleted!");
            }
            else
            {
                Console.WriteLine("The menu item could not be deleted. Please try again.");
            }
        }
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> allContent = _repo.GetContents();
            foreach (MenuItem content in allContent)
            {
                Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Meal Description: {content.MealDescription}\n" +
                    $"Meal Ingredients: {content.MealIngredients}\n" +
                    $"Meal Price: ${content.MealPrice}\n");
            }
        }
        public void SeedContentList()
        {
            MenuItem blackNBlue = new MenuItem(1, "Black n Blue Burger", "Blackend burger topped with blue cheese and bacon", "Patty, blue cheese, bacon, seasoning, bread bun", 5.99);
            MenuItem chickenTenders = new MenuItem(2, "Chicken Tender Basket", "5 Chicken tenders tossed in our secret seasoning", "Chicken, seasoning, oil", 4.99);
            MenuItem bLT = new MenuItem(3, "Classic BLT", "Bacon, lettuce, tomato on toasted sourdough bread", "Bacon, Lettuce, Tomato, Sourdough bread", 5.99);
            _repo.AddItemToDirectory(blackNBlue);
            _repo.AddItemToDirectory(chickenTenders);
            _repo.AddItemToDirectory(bLT);
        }
    }
}
