using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.CatsUI.Controllers;
using MVC.CatsUI.Models;
using MVC.CatsUI.UIModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.CatsUI.Tests
{
    [TestClass]
    public class CatsControllerTests
    {
        // Default Settings
        private static AppSettings appSettings = new AppSettings() { CatsMediaType = "application/json", CatsUrl = "http://agl-developer-test.azurewebsites.net/people.json" };
        private static IOptions<AppSettings> options = Options.Create(appSettings);

        private CatsController catsController = new CatsController(options);


        #region CatsByGender 
        // Fixed Data - Scenario 1
        [TestMethod]
        public async Task CatsByGender_1()
        {
            try
            {
                List<PetNameByGender> cats = await catsController.CatsByGender();
                
                Assert.AreEqual(7, cats.Count, "Total Cats");                
                Assert.AreEqual(4, cats.FindAll(m => m.OwnerGender == Gender.Male.ToString()).Count, "Total Cats - Male");                
                Assert.AreEqual(3, cats.FindAll(m => m.OwnerGender == Gender.Male.ToString()).Count, "Total Cats - Female");                
                Assert.IsTrue(cats.Find(m => m.OwnerGender == Gender.Male.ToString() && m.PetName == "Garfield") != null, "Male cats contains Garfield");
                Assert.IsTrue(cats.Find(m => m.OwnerGender == Gender.Female.ToString() && m.PetName == "Garfield") != null, "Female cats contains Garfield");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Duplicated Values (must be removed) - Scenario 2
        [TestMethod]
        public async Task CatsByGender_2()
        {

        }

        // Null response from API - Scenario 3
        [TestMethod]
        public async Task CatsByGender_3()
        {

        }
        #endregion
    }
}
