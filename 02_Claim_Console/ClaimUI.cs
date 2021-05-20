using _02_Claim_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim_Console
{
    public class ClaimUI
    {
        private ClaimRepository _repo = new ClaimRepository();
        public void Run()
        {
            SeedContentList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Choose a Menu Item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new clam\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        HandleClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;                    
                    case "4":
                        //Exit Menu
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number");
                        break;
                }
                Console.WriteLine("Please Press Any Key To Continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claim> allContent = _repo.GetClaims();
            foreach (Claim content in allContent)
            {
                Console.WriteLine($"ClaimID: {content.ClaimID}\n" +
                    $"Type: {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"Amount: {content.ClaimAmount}\n" +
                    $"DateOfAccident: ${content.DateOfIncident}\n" +
                    $"DateOfClaim: ${content.DateOfClaim}\n" +
                    $"IsValid: ${content.IsValid}\n");
            }
        }
        private void HandleClaim()
        {
            Console.Clear();
            Claim content = _repo.ViewClaims();
            Console.WriteLine($"ClaimID: {content.ClaimID}\n" +
                    $"Type: {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"Amount: ${content.ClaimAmount}\n" +
                    $"DateOfAccident: {content.DateOfIncident}\n" +
                    $"DateOfClaim: {content.DateOfClaim}\n" +
                    $"IsValid: {content.IsValid}\n");

            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string input = Console.ReadLine().ToLower();
            if (input.Contains("y"))
            {
                _repo.HandleClaim(content);
            }
            else
            {
                Menu();
            }
                
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claim newContent = new Claim();
            // Claim ID
            Console.WriteLine("Enter the claim id:");
            string claimIDAsString = Console.ReadLine();
            int claimIDAsInt = Convert.ToInt32(claimIDAsString);
            newContent.ClaimID = claimIDAsInt;
            // Claim Type
            Console.WriteLine("Enter the claim type:");
            string claimTypeAsString = Console.ReadLine();
            int claimTypeAsInt = Convert.ToInt32(claimTypeAsString);
            newContent.ClaimType = (ClaimType)claimTypeAsInt;
            // Claim Description
            Console.WriteLine("Enter a claim description:");
            newContent.Description = Console.ReadLine();
            // Claim Amount
            Console.WriteLine("Amount of Damage:");
            newContent.ClaimAmount = Convert.ToDouble(Console.ReadLine());   
            // Claim Date of Incident
            Console.WriteLine("Date of Accident:");
            newContent.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
            // Date of Claim
            Console.WriteLine("Date of Claim:");
            newContent.DateOfClaim = Convert.ToDateTime(Console.ReadLine());
            // Added correctly 
            bool wasAddedCorrectly = _repo.AddClaimToDirectory(newContent);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("Great success!\n" +
                    "The claim item was added correctly! ");
            }
            else
            {
                Console.WriteLine("Fail\n" +
                    "The claim item could not be added. Please try again.");
            }
        }
        public void SeedContentList()
        {
            Claim claimOne = new Claim(1, ClaimType.Car, "Car Accident on 465.", 400.00, new DateTime (2018, 04, 28), new DateTime(2018, 04, 27), true);
            Claim claimTwo = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 04, 11), new DateTime (2018, 04, 12), true);
            Claim claimThree = new Claim(3, ClaimType.Theft, "Stolen Pancakes.", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 05, 01), false);
            _repo.AddClaimToDirectory(claimOne);
            _repo.AddClaimToDirectory(claimTwo);
            _repo.AddClaimToDirectory(claimThree);
        }
    }
}
