using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Repo
{
    
    public class ClaimRepository
    {
        // See all claims
        private readonly Queue<Claim> _claimsDirectory = new Queue<Claim>();
        public Queue<Claim> GetClaims()
        {
            return _claimsDirectory;
        }
        // Take care of next claim
        public Claim ViewClaims()
        {
            Claim viewClaims = _claimsDirectory.Peek();
            return viewClaims;
        }
        public bool HandleClaim(Claim claim)
        {
            Claim takeCareOfClaim = claim;
            //while (_claimsDirectory.Count > 0)
            if (claim != null)
            {
                _claimsDirectory.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }
        // Enter a new Claim
        public bool AddClaimToDirectory(Claim newClaims)
        {
            int startingCount = _claimsDirectory.Count;
            _claimsDirectory.Enqueue(newClaims);
            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        
    }
}
