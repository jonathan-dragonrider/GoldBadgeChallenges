using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class KomodoCafeUI
    {
        private bool _isRunning = true;
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public KomodoCafeUI()
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
                "1. View All Menu Items\n" +
                "2. Add New Menu Item\n" +
                "3. Remove Menu Item\n" +
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
                    DisplayAllMenuItems();
                    break;
                case "2":
                    // add new item
                    AddNewMenuItem();
                    break;
                case "3":
                    // remove item
                    RemoveMenuItem();
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

        private void DisplayAllMenuItems()
        {
            // Get item
            // Go to the repository and get the directory
            List<MenuItem> menuItems = _menuRepo.GetMenuItems();

            // Display item
            foreach (var item in menuItems)
            {
                DisplayContent(item);
            }
        }

        private void DisplayContent(MenuItem item)
        {
            Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                $"Meal Name: {item.MealName}\n" +
                $"Description: {item.Description}\n" +
                $"Ingredients: {item.Ingredients}\n" +
                $"Price: ${item.Price}");
        }

        private void AddNewMenuItem()
        {
            // Enter number, title, description, ingredients, price

            var item = new MenuItem();

            Console.WriteLine("Enter Meal Number:");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            item.MealNumber = mealNumber;

            Console.WriteLine("Enter Meal Name:");
            string mealName = Console.ReadLine();
            item.MealName = mealName;

            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();
            item.Description = description;

            Console.WriteLine("Enter a List of Ingredients:");
            string ingredients = Console.ReadLine();
            item.Ingredients = ingredients;

            Console.WriteLine("Enter Price:");
            double price = Convert.ToDouble(Console.ReadLine());
            item.Price = price;

            _menuRepo.AddItemToDirectory(item);
        }

        private void RemoveMenuItem()
        {
            Console.WriteLine("Enter Name of Item to Delete:");
            string itemToDelete = Console.ReadLine();

            if (_menuRepo.FindMenuItemByName(itemToDelete) == null)
            {
                Console.WriteLine("Item does not exist.");
            }
            else
            {
                _menuRepo.DeleteExistingItem(itemToDelete);
                Console.WriteLine($"{itemToDelete} was removed from the directory.");
            }
        }

        private void SeedMenuList()
        {
            var satay = new MenuItem(1, "Satay Ayam", "Chicken satay served with peanut sauce and steamed rice", "chicken, peanut sauce, rice", 9.50);
            var nasi = new MenuItem(2, "Nasi Bakar Ikan", "Seasoned rice and marinated fish, wrapped in banans leaves and grilled, served with fried tofu", "fish, tofu, rice", 9.50);
            var mie = new MenuItem(3, "Mie Ayam Jamur", "Indonesian style egg noodles with chicken and mushroom.", "egg noodles, chicken, mushrooms", 9.50);

            _menuRepo.AddItemToDirectory(satay);
            _menuRepo.AddItemToDirectory(nasi);
            _menuRepo.AddItemToDirectory(mie);
        }
    }
}
