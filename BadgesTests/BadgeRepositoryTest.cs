using System;
using System.Collections.Generic;
using Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgesTests
{
    [TestClass]
    public class BadgeRepositoryTest
    {
        private BadgeRepository _badgeRepo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepository();
            var doors = new List<string>() { "A1", "A2", "B1", "B2"};
            _badge = new Badge(1, doors);
            _badgeRepo.AddBadge(_badge);
        }

        [TestMethod]
        public void GetBadgeDictionary_ShouldReturn()
        {
            var badges = _badgeRepo.GetBadgeDictionary();

            Assert.IsTrue(badges.ContainsKey(1));
        }

        [TestMethod]
        public void UpdateBadge_ShouldReturnTrue()
        {
            var updatedDoors = new List<string>() { "D3", "D4" };
            var isUpdated = _badgeRepo.UpdateBadge(1, updatedDoors);

            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            Assert.IsTrue(_badgeRepo.DeleteBadge(1));
        }

    }
}
