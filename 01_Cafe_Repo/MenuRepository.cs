using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repo
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _itemDirectory = new List<MenuItem>();
        public bool AddItemToDirectory(MenuItem newItem)
        {
            int startingCount = _itemDirectory.Count;
            _itemDirectory.Add(newItem);
            bool wasAdded = (_itemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<MenuItem> GetContents()
        {
            return _itemDirectory;
        }
        public MenuItem GetMenuItemByNumber(int mealNumber)
        {
            foreach (MenuItem content in _itemDirectory)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }
            return null;
        }
        public bool UpdateExistingMenuItem(int originalMealNumber, MenuItem newItemValue)
        {
            MenuItem oldItem = GetMenuItemByNumber(originalMealNumber);
            if (oldItem != null)
            {
                oldItem.MealNumber = newItemValue.MealNumber;
                oldItem.MealName = newItemValue.MealName;
                oldItem.MealDescription = newItemValue.MealDescription;
                oldItem.MealIngredients = newItemValue.MealIngredients;
                oldItem.MealPrice = newItemValue.MealPrice;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteExistingItem(int itemToDelete)
        {
            MenuItem menuItemToDelete = GetMenuItemByNumber(itemToDelete);
            if (menuItemToDelete == null)
            {
                return false;
            }
            else
            {
                _itemDirectory.Remove(menuItemToDelete);
                return true;
            }
        }
    }
}
