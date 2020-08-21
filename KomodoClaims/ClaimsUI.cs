using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    class ClaimsUI
    {
        private bool _isRunning = true;
        private readonly ClaimRepository _claimRepo = new ClaimRepository();

        public ClaimsUI()
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
                "Choose a menu item:\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. Modify an existing claim\n" +
                "5. Exit");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    // See all claims
                    DisplayAllClaims();
                    break;
                case "2":
                    // Take care of next claim
                    TakeCareOfClaim();
                    break;
                case "3":
                    // Enter a new claim
                    EnterNewClaim();
                    break;
                case "4":
                    // Modify an existing claim
                    ModifyClaim();
                    break;
                case "5":
                    // Exit
                    _isRunning = false;
                    return;
                default:
                    // invalid selection
                    return;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private void DisplayAllClaims()
        {
            // Get item
            // Go to the repository and get the directory
            List<Claim> claims = _claimRepo.GetClaims();

            Console.WriteLine("ClaimID\t" +
                "Type\t" +
                "Description\t" + "\t" +
                "Amount\t" +
                "DateOfAccident\t" + "\t" +
                "DateOfClaim\t" + "\t" +
                "IsValid");

            // Display item
            foreach (var claim in claims)
            {
                DisplayClaim(claim);
            }
        }

        private void DisplayClaim(Claim claim)
        {
            Console.WriteLine($"{claim.ClaimID}\t" +
                $"{claim.TypeOfClaim}\t" +
                $"{claim.Description}\t" +
                $"${claim.ClaimAmount}\t" +
                $"{claim.DateOfIncident}\t" +
                $"{claim.DateOfClaim}\t" +
                $"{claim.IsValid}");
        }

        // Take care of next claim
        // Make list of claims into a queue, display first claim in the queue, ask "Do you want to deal with this claim now(y/n)?, if "y", the claim gets pulled off the top of the queue, if "n" go back to the main menu

        private void TakeCareOfClaim()
        {

            var claims = _claimRepo.GetClaims();
            var firstClaimInList = claims[0];

            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine($"ClaimID: {firstClaimInList.ClaimID}\n" +
                $"Type: {firstClaimInList.TypeOfClaim}\n" +
                $"Description: {firstClaimInList.Description}\n" +
                $"Amount: ${firstClaimInList.ClaimAmount}\n" +
                $"DateOfAccident: {firstClaimInList.DateOfIncident}\n" +
                $"DateOfClaim: {firstClaimInList.DateOfClaim}\n" +
                $"IsValid: {firstClaimInList.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string response = Console.ReadLine();

            if (response == "y")
            {
                _claimRepo.DeleteExistingClaim(firstClaimInList);
            }
        }

        private void EnterNewClaim()
        {

            var claim = new Claim();

            Console.WriteLine("Enter claim id:");
            int claimID = Convert.ToInt32(Console.ReadLine());
            claim.ClaimID = claimID;

            Console.WriteLine("Enter claim type:");
            claim.TypeOfClaim = GetClaimType();

            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();
            claim.Description = description;

            Console.WriteLine("Enter amount:");
            double amount = Convert.ToDouble(Console.ReadLine());
            claim.ClaimAmount = amount;

            Console.WriteLine("Enter date of accident:");
            DateTime dateOfAccident = Convert.ToDateTime(Console.ReadLine());
            claim.DateOfIncident = dateOfAccident;

            Console.WriteLine("Enter date of claim:");
            DateTime dateOfClaim = Convert.ToDateTime(Console.ReadLine());
            claim.DateOfClaim = dateOfClaim;

            _claimRepo.AddClaimToDirectory(claim);
        }

        private Claim.ClaimType GetClaimType()
        {
            Console.WriteLine("Select claim type:\n" +
                "1. Car\n" +
                "2. House\n" +
                "3. Theft\n" +
                "4. FlyingDutchman\n" +
                "5. PattyMobile");

            while (true)
            {
                string claimTypeString = Console.ReadLine();
                int claimTypeId = int.Parse(claimTypeString);
                Claim.ClaimType claimType = (Claim.ClaimType)claimTypeId - 1;
                return claimType;

                Console.WriteLine("Invalid selection.");
            }
        }

        public void ModifyClaim()
        {
            Console.WriteLine("Enter the claim id corresponding to the claim to be modified:");
            int claimId = Convert.ToInt32(Console.ReadLine());

            var claimToBeModified = _claimRepo.FindClaimByID(claimId);

            var claim = new Claim();

            Console.WriteLine("Enter claim id:");
            int claimID = Convert.ToInt32(Console.ReadLine());
            claim.ClaimID = claimID;

            Console.WriteLine("Enter claim type:");
            claim.TypeOfClaim = GetClaimType();

            Console.WriteLine("Enter description:");
            string description = Console.ReadLine();
            claim.Description = description;

            Console.WriteLine("Enter amount:");
            double amount = Convert.ToDouble(Console.ReadLine());
            claim.ClaimAmount = amount;

            Console.WriteLine("Enter date of accident:");
            DateTime dateOfAccident = Convert.ToDateTime(Console.ReadLine());
            claim.DateOfIncident = dateOfAccident;

            Console.WriteLine("Enter date of claim:");
            DateTime dateOfClaim = Convert.ToDateTime(Console.ReadLine());
            claim.DateOfClaim = dateOfClaim;

            _claimRepo.UpdateExistingClaim(claimId, claim);


        }

        private void SeedMenuList()
        {
            var car = new Claim(1, Claim.ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            var house = new Claim(2, Claim.ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            var theft = new Claim(3, Claim.ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));
            //var flyingDutchman = new Claim(4, Claim.ClaimType.FlyingDutchman, "Just need to buff out those scratches", 1000000.00, new DateTime(2001, 3, 9), new DateTime(2001, 3, 9));
            //var pattyMobile = new Claim(5, Claim.ClaimType.PattyMobile, "You don't need a license to drive a sandwich", 5000.00, new DateTime(2004, 11, 14), new DateTime(2004, 11, 14));

            _claimRepo.AddClaimToDirectory(car);
            _claimRepo.AddClaimToDirectory(house);
            _claimRepo.AddClaimToDirectory(theft);
            //_claimRepo.AddClaimToDirectory(flyingDutchman);
            //_claimRepo.AddClaimToDirectory(pattyMobile);
        }
    }
}

