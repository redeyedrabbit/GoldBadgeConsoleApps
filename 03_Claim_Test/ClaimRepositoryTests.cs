using _02_Claim_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Claim_Test
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void AddToQueue_ShouldGetCorrectBoolean()
        {
            Claim content = new Claim();
            ClaimRepository repository = new ClaimRepository();
            bool addResult = repository.AddClaimToDirectory(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            Claim content = new Claim();
            ClaimRepository repository = new ClaimRepository();
            repository.AddClaimToDirectory(content);
            Queue<Claim>directory = repository.GetClaims();
            bool directoryHasContent = directory.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        private Claim _content;
        private ClaimRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _content = new Claim(1, ClaimType.Theft, "This is theft", 100.00, new DateTime(2021, 5, 7), new DateTime (2021, 5, 20), true);
            _repo.AddClaimToDirectory(_content);
        }

    }
}
