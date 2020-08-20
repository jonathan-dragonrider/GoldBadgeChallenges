using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuItemDirectory = new List<MenuItem>();

        // Create
        public void AddItemToDirectory(MenuItem menuItem)
        {
            _menuItemDirectory.Add(menuItem);
        }

        // Read
        public List<MenuItem> GetMenuItems()
        {
            return _menuItemDirectory;
        }

        public MenuItem FindMenuItemByName(string menuItemName)
        {
            //var menuItem = _menuItemDirectory.Where(item => item.MealName == menuItemName);
            //return (MenuItem)menuItem;

            foreach (var item in _menuItemDirectory)
            {
                if (item.MealName.ToLower() == menuItemName.ToLower())
                {
                    return item;
                }
            }

            return null;
        }

        // Update
        public bool UpdateExistingItem(MenuItem existingItem, MenuItem updatedItem)
        {
            if (_menuItemDirectory.Contains(existingItem))
            {
                var existingItemIndex = _menuItemDirectory.IndexOf(existingItem);
                _menuItemDirectory[existingItemIndex] = updatedItem;

                return true;
            }

            return false;
        }

        public bool UpdateExistingItem(string existingName, MenuItem updatedItem)
        {
            var existingItem = FindMenuItemByName(existingName);

            if (_menuItemDirectory.Contains(existingItem))
            {
                var existingItemIndex = _menuItemDirectory.IndexOf(existingItem);
                _menuItemDirectory[existingItemIndex] = updatedItem;
            }

            return false;

        }

        // Delete
        public bool DeleteExistingItem(MenuItem itemToBeDeleted)
        {
            return _menuItemDirectory.Remove(itemToBeDeleted);
        }

        public bool DeleteExistingItem(string name)
        {
            return _menuItemDirectory.Remove(FindMenuItemByName(name));
        }
    }
}
