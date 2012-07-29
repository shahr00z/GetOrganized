using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;
using GetOrganized.Controllers;
using GetOrganized.Models;
using NUnit.Framework;

namespace GetOrganized.Tests.Controllers
{
	[TestFixture]
	public class TopicControllerTest
	{
		[Test]
		public void Shoud_Have_A_List_Od_Topic_With_Name_And_Color()
		{
			var list = new List<Topic>();
			var topic = new Topic { ID = 1, Color = Color.Red, Name = "Work" };
			object model = ((ViewResult)new TopicController().Index()).Model;
			Assert.AreEqual(list, model);
		}

		[Test]
		public void Should_Create_Topic_And_Notify_The_User()
		{
			var PerofessionalDevelopment = new Topic
				{
					ID = 3
					,
					Color = ColorTranslator.FromHtml("#000000"),
					Name = "Perofessional Development"
				};

			var formValue = new FormCollection();
			formValue.Add("ID", PerofessionalDevelopment.ID.ToString());
			formValue.Add("Name", PerofessionalDevelopment.Name);
			formValue.Add("Color", PerofessionalDevelopment.ColorInWebHex().Trim('#'));

			var controller = new TopicController();

			var result = (RedirectToRouteResult)controller.Create(formValue);

			Assert.Contains(PerofessionalDevelopment, TopicSource.Topics);
			Assert.AreEqual("Index", result.RouteValues["action"]);
			Assert.AreEqual("Your topic has been successfully.", controller.TempData["Message"]);

		}
	}
}