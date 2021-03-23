using BackEndLuncher.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace BackEndLuncher.Tests
{

    [TestClass]
    public class MenuTest
    {
        //Get All Menu
        [TestMethod]
        public void GetMenu_ShouldReturnAllMenu()
        {
            //Arrange
            var context = new TestLuncherAppContext();
            context.Menu.Add(new Menu { Id = 1, ImageUrl = "Game.jpg", WeekNumber = 1});
            context.Menu.Add(new Menu { Id = 2, ImageUrl = "Mario.jpg", WeekNumber = 2 });
            context.Menu.Add(new Menu { Id = 3, ImageUrl = "Mario.jpg", WeekNumber = 3 });
            //Act
            var controller = new MenuController(context);
            var result = controller.GetMenu() as TestMenuDbSet;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }


        //Get One Menu
        [TestMethod]
        public void GetMenuWithId_ShouldReturnMenuWithSameId()
        {
            //Arrange
            var context = new TestLuncherAppContext(); //the context
            context.Menu.Add(GetDemoMenu());


            //Act 

            var controller = new MenuController(context);
            var result = controller.GetMenu(3) as OkNegotiatedContentResult<Menu>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);

        }

        public Menu GetDemoMenu()
        {
            return new Menu { Id = 3, ImageUrl = "Fish.jpg", WeekNumber = 4 };
        }


    }
}
