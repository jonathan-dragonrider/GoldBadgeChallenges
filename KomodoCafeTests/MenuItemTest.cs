using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static KomodoCafe.MenuItem;
using KomodoCafe;

namespace KomodoCafeTests
{
    [TestClass]
    public class MenuItemTest
    {
        [TestMethod]
        public void MenuItemConstructor_ShouldAssignCorrectValues()
        {
            // Arrange
            string description = "Marinated chicken meat cooked over charcoal grill.";
            string ingredients = "chicken, sauce";
            var menuItem = new MenuItem(1, "Satay", description, ingredients, 5.50);

            // Act
            var menuItemNumber = menuItem.MealNumber;
            var menuItemName = menuItem.MealName;
            var menuItemDescription = menuItem.Description;
            var menuItemIngredients = menuItem.Ingredients;
            var menuItemPrice = menuItem.Price;

            // Assert
            Assert.AreEqual(menuItemNumber, 1);
            Assert.AreEqual(menuItemName, "Satay");
            Assert.AreEqual(menuItemDescription, "Marinated chicken meat cooked over charcoal grill.");
            Assert.AreEqual(menuItemIngredients, "chicken, sauce");
            Assert.AreEqual(menuItemPrice, 5.50);

        }
    }
}
