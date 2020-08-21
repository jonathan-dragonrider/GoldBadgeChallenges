using System;
using System.Collections.Generic;
using KomodoClaims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoClaimsTests
{
    [TestClass]
    public class ClaimRepositoryTests
    {

        private ClaimRepository _repo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(1, Claim.ClaimType.FlyingDutchman, "Just need to buff out those scratches", 1000000.00, new DateTime(2001, 3, 9), new DateTime(2001, 3, 9));
            _repo.AddClaimToDirectory(_claim);
        }

        [TestMethod]
        public void GetClaims_ShouldConfirmClaimExists()
        {
            var newClaim = new Claim();
            _repo.AddClaimToDirectory(newClaim);

            List<Claim> directory = _repo.GetClaims();
            bool directoryHasClaim = directory.Contains(newClaim);

            Assert.IsTrue(directoryHasClaim);
        }

        [TestMethod]
        public void UpdateExistingClaim_ShouldReplaceAndReturnTrue()
        {
            var updatedClaim = new Claim(1, Claim.ClaimType.PattyMobile, "You don't need a license to drive a sandwich", 5000.00, new DateTime(2004, 11, 14), new DateTime(2004, 11, 14));

            bool isUpdated = _repo.UpdateExistingClaim(_claim, updatedClaim);
            var checkUpdatedClaim = _repo.FindClaimByID(1);

            Assert.IsTrue(isUpdated);
            Assert.AreEqual(checkUpdatedClaim, updatedClaim);
        }

        [TestMethod]
        public void DeleteExistingClaim_ShouldReturnTrue()
        {
            var isDeleted = _repo.DeleteExistingClaim(_claim);

            Assert.IsTrue(isDeleted);
        }
    }
}
