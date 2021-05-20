using _01_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Cafe_Test
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            MenuItem content = new MenuItem();
            MenuRepository repository = new MenuRepository();
            bool addResult = repository.AddItemToDirectory(content);
            Assert.IsTrue(addResult);
        }       
        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            MenuItem content = new MenuItem();
            MenuRepository repository = new MenuRepository();
            repository.AddItemToDirectory(content);
            List<MenuItem> directory = repository.GetContents();
            bool directoryHasContent = directory.Contains(content);
            Assert.IsTrue(directoryHasContent);
        }
        private MenuItem _content;
        private MenuRepository _repo;        
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _content = new MenuItem(5, "Double Chz", "Double patty cheese burger with fries and a drink", "Meat, cheese, bun, lettuce, tomato, onion, potato", 3.99);
            _repo.AddItemToDirectory(_content);
        }
        
    }
}
