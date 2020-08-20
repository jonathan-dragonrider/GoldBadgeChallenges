using System;
using System.Collections.Generic;
using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafeTests
{
    [TestClass]
    public class MenuRepositoryTests
    {

        // Arrange objects for use in testing
        private MenuRepository _repo;
        private MenuItem _item;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            string description = "Marinated chicken meat cooked over charcoal grill.";
            string ingredients = "chicken, sauce";
            _item = new MenuItem(1, "Satay", description, ingredients, 5.50);
            _repo.AddItemToDirectory(_item);
        }

        // Tests AddItemToDirectory and GetMenuItems
        [TestMethod]
        public void GetMenuItems_ShouldReturnListOfItems()
        {
            var newMenuItem = new MenuItem();
            _repo.AddItemToDirectory(newMenuItem);

            List<MenuItem> directory = _repo.GetMenuItems();
            bool directoryHasSatay = directory.Contains(newMenuItem);

            Assert.IsTrue(directoryHasSatay);
        }

        // Tests UpdateExistingItem and FindMenuItemByName
        [TestMethod]
        public void UpdateExistingItem_ShouldReplaceAndReturnTrue()
        {
            string description = "Marinated chicken meat cooked over charcoal grill.";
            string updatedIngredientList = "goat, soy sauce, spice blend";
            var updatedMenuItem = new MenuItem(1, "Satay", description, updatedIngredientList, 5.50);

            bool isUpdated = _repo.UpdateExistingItem(_item, updatedMenuItem);
            var checkUpdatedMenuItem = _repo.FindMenuItemByName("Satay");

            Assert.IsTrue(isUpdated);
            Assert.AreEqual(checkUpdatedMenuItem, updatedMenuItem);
        }

        [TestMethod]
        public void DeleteExistingItem_ShouldReturnTrue()
        {
            var isDeleted =_repo.DeleteExistingItem(_item);

            Assert.IsTrue(isDeleted);
        }
    }
}






