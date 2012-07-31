using System.Web.Mvc;
using GetOrganized.Controllers;
using GetOrganized.Models;
using GetOrganized.Tests.Helper;
using NUnit.Framework;

namespace GetOrganized.Tests.Controllers
{
	[TestFixture]
	public class TodoControllerTest
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
		}

		#endregion

		[Test]
		public void Should_Add_Todo_Item()
		{
			var todo = new Todo {Title = "Learn mbout MVC Controller"};
			var redirectToRoutResult = (RedirectToRouteResult) new TodoController().Create(todo);
			Assert.Contains(todo, TodoSource.ThingsToBeDone);
			Assert.AreEqual("Index", redirectToRoutResult.RouteValues["action"]);
		}

		[Test]
		public void Should_Be_Logged_In_To_Do_Anything_With_Todos()
		{
			TestHelper.AssertIsAouthorized(typeof (TodoController));
		}

		[Test]
		public void Should_Convert_A_Thought_A_Todo()
		{
			var exeptedTodo = new Todo
				{
					Title = "Bulid a killer web site",
					Outcome = "Site has 100 visitors per day",
					Topic = TopicSource.Topics[0]
				};
			var thought = new Thought {Name = "Bulid a killer web site", Topic = TopicSource.Topics[0]};

			var result = (RedirectToRouteResult) new TodoController().Convert(thought, "Site has 100 visitors per day");
			Assert.Contains(exeptedTodo, TodoSource.ThingsToBeDone);
			Assert.IsFalse(ThoughtSuroce.Thoughts.Contains(thought));
			Assert.AreEqual("Process", result.RouteValues["action"]);
			Assert.AreEqual("Thought", result.RouteValues["controller"]);
		}

		[Test]
		public void Should_Delete_Todo_Item()
		{
			Todo mistakeTodo = TodoSource.ThingsToBeDone[0];
			var redirectToRoutResult = (RedirectToRouteResult) new TodoController().Delete(mistakeTodo.Title);
			Assert.IsFalse(TodoSource.ThingsToBeDone.Contains(mistakeTodo));
			Assert.AreEqual("Index", redirectToRoutResult.RouteValues["action"]);
		}

		[Test]
		public void Should_Display_A_List_Od_Todo_Items()
		{
			var viewResult = (ViewResult) new TodoController().Index();
			Assert.AreEqual(TodoSource.ThingsToBeDone, viewResult.Model);
		}

		[Test]
		public void Should_Edit_Todo_Item()
		{
			var editedTodo = new Todo {Title = "Get Organized"};
			var redirectToroutResult = (RedirectToRouteResult) new TodoController().Edit("Get Mike", editedTodo);
			Assert.Contains(editedTodo, TodoSource.ThingsToBeDone);
			Assert.AreEqual("Index", redirectToroutResult.RouteValues["action"]);
		}

		[Test]
		public void Should_Load_A_Todo_Item_For_Editing()
		{
			Todo editTodo = TodoSource.ThingsToBeDone[0];
			var viewResult = (ViewResult) new TodoController().Edit(editTodo.Title);

			Assert.AreEqual(editTodo, viewResult.Model);
		}

		[Test]
		public void Should_Load_Create_View()
		{
			var viewResult = (ViewResult) new TodoController().Create();
			Assert.AreEqual(string.Empty, viewResult.ViewName);
		}
		[Test]
		public void Should_Be_Login_To_Create()
		{
			TestHelper.AssertIsAouthorized(typeof(TodoController), "Create");
			TestHelper.AssertIsAouthorized(typeof(TodoController), "Create",typeof(Todo));
		}
	}
}