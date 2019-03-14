using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElectronicColorCode.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using ElectronicColorCodeCalculator;

namespace ElectronicColorCode.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void getResistanceValueTest()
        {
            ////Create Instance           
            HomeController hController = new HomeController();

            ////Act
            JsonResult result = (JsonResult)hController.getResistanceValue(null, null, null, null);

            ////convert JSON to string
            string stringResult = new JavaScriptSerializer().Serialize(result.Data);

            ////parse json string
            JObject joResponse = JObject.Parse(stringResult);
            
            ////get error
            string error = (string)joResponse["error"];

            ////Assert
            Assert.AreEqual("Exception ocurred while calculating resistance value: Value cannot be null.\r\nParameter name: key", error);
        }


        [TestMethod()]
        public void CalculateOhmValueTest()
        {
            ////Arrange
            IOhmValueCalculator ohmValueCalculator = new ResistanceCalculator();

            ////Act
            ColorCodeResult result = ohmValueCalculator.CalculateOhmValue("brown", "black", "black", "brown");

            ////Assert
            Assert.AreEqual("10.1", result.MaximumResistance);
        }
    }
}