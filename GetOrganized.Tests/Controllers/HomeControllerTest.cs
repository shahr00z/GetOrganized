using System.Web.Mvc;
using GetOrganized.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetOrganized.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			var controller = new HomeController();

			// Act
			var result = controller.Index() as ViewResult;

			// Assert
			Assert.AreEqual("Modify this template to kick-start your ASP.NET MVC application.", result.ViewBag.Message);
		}

		[TestMethod]
		public void About()
		{
			// Arrange
			var controller = new HomeController();

			// Act
			var result = controller.About() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void Contact()
		{
			// Arrange
			var controller = new HomeController();

			// Act
			var result = controller.Contact() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}