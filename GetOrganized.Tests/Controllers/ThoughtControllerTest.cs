using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GetOrganized.Controllers;
using GetOrganized.Models;
using NUnit.Framework;

namespace GetOrganized.Tests.Controllers
{
	[TestFixture]
	public class ThoughtControllerTest
	{
		[Test]
		public void Should_List_Thought_When_Index_Is_Called()
		{
			var result = (ViewResult)new ThoughtController().Index();
			Assert.AreEqual(ThoughtSuroce.Thoughts, result.Model);
		}

		[Test]
		public void Should_Provide_A_List_Of_Topic_For_Creating_New_Thoughts()
		{
			List<SelectListItem> expectedListItem =
				TopicSource.Topics.ConvertAll(topic => new SelectListItem
					{
						Text = topic.Name,
						Value = topic.ID.ToString()
					});

			var thoughts = new Thought();
			var result = (ViewResult)new ThoughtController().Create();
			var redirectToRoutResult = (RedirectToRouteResult)new ThoughtController().Create(thoughts);
			//var firstTopic = ((List<SelectListItem>)result.ViewData["Topics"])[0];

			//Assert.AreEqual(expectedListItem[0].Value, firstTopic.Value);
			//Assert.AreEqual(expectedListItem[0].Text, firstTopic.Text);
			Assert.AreEqual("Index", redirectToRoutResult.RouteValues["action"]);

		}
		[Test]
		public void Should_Display_First_Thought_Whene_Processing_Thoughts()
		{
			var expectedThought = ThoughtSuroce.Thoughts.First();
			var result = (ViewResult) new ThoughtController().Process();
			Assert.AreEqual(expectedThought,result.Model);
		}
	}
}