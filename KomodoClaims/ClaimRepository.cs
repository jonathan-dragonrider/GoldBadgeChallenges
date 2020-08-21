using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ClaimRepository
    {
        private readonly List<Claim> _claims = new List<Claim>();

        // Create
        public void AddClaimToDirectory(Claim claim)
        {
            _claims.Add(claim);
        }

        // Read
        public List<Claim> GetClaims()
        {
            return _claims;
        }

        public Claim FindClaimByID(int claimID)
        {

            foreach (var claim in _claims)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }

            return null;
        }

        // Update
        public bool UpdateExistingClaim(Claim existingClaim, Claim updatedClaim)
        {
            if (_claims.Contains(existingClaim))
            {
                var existingClaimIndex = _claims.IndexOf(existingClaim);
                _claims[existingClaimIndex] = updatedClaim;

                return true;
            }

            return false;
        }

        public bool UpdateExistingClaim(int existingClaimID, Claim updatedClaim)
        {
            var existingClaim = FindClaimByID(existingClaimID);

            if (_claims.Contains(existingClaim))
            {
                var existingClaimIndex = _claims.IndexOf(existingClaim);
                _claims[existingClaimIndex] = updatedClaim;
            }

            return false;

        }

        // Delete
        public bool DeleteExistingClaim(Claim itemToBeDeleted)
        {
            return _claims.Remove(itemToBeDeleted);
        }

        public bool DeleteExistingClaim(int id)
        {
            return _claims.Remove(FindClaimByID(id));
        }
    }
}
