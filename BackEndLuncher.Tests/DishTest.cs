using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BackEndLuncher.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEndLuncher.Tests
{
    [TestClass]
   public class DishTest
    {
        //Obs detta var en tidig test-klass vi skapade
        [TestMethod]
        public void GetAllDishesShouldReturnAListOfDishes()
        {
            //1: Vi behöver vår Db Context för att få tillgång till vår lista och skapa fake data
            var context = new TestLuncherAppContext();
            context.Dishes.Add(new Dishes { Id = 10, DishName = "FishLax", Description = "YAANE", Category = "Fish", Price = 200, AllergyInformation = "Räkor" });
            context.Dishes.Add(new Dishes { Id = 11, DishName = "Rödspetts", Description = "YAANE", Category = "Fish", Price = 100, AllergyInformation = "FiskSkal" });
            context.Dishes.Add(new Dishes { Id = 12, DishName = "Lasagne", Description = "YAANE", Category = "Fish", Price = 50, AllergyInformation = "Tomat" });


            //2: Nu ska vi få tillgång till kontrollern  
            var controller = new DishController(context);

            //Arrange

            //Act
            var result = controller.GetDishes() as TestDishDbSet;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);


        }
        [TestMethod]
        public void GetDishWithId_ShouldReturnDishWithSameId()
        {
            //Arrange
            var context = new TestLuncherAppContext(); //the context
            context.Dishes.Add(GetDemoDishes());


            //Act 

            var controller = new DishController(context);
            var result = controller.GetDishes(3) as OkNegotiatedContentResult<Dishes>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.Id);

        }

        public Dishes GetDemoDishes()
        {
            return new Dishes { Id = 3, DishName = "FishLax", Description = "YAANE", Category = "Fish", Price = 200, AllergyInformation = "Räkor" };
        }

    }
}
