using System.Collections.Generic;
using System.Web.Mvc;
using GetOrganized.Models;

namespace GetOrganized.Controllers
{
	[Authorize]
	public class TodoController : Controller
	{
		//
		// GET: /Todo/

		public ActionResult Index()
		{
			List<Todo> list = TodoSource.ThingsToBeDone;
			return View(list);
		}

		//
		// GET: /Todo/Details/5

		public ActionResult Details(int id)
		{
			return View();
		}

		//
		// GET: /Todo/Create

		public ActionResult Create()
		{
			return View("");
		}

		//
		// POST: /Todo/Create

		[HttpPost]
		public ActionResult Create(Todo todo)
		{
			try
			{
				// TODO: Add insert logic here
				TodoSource.ThingsToBeDone.Add(todo);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Todo/Edit/5

		public ActionResult Edit(string title)
		{
			Todo model = TodoSource.ThingsToBeDone.Find(x => x.Title == title);
			return View(model);
		}

		//
		// POST: /Todo/Edit/5

		[HttpPost]
		public ActionResult Edit(string title, Todo todo)
		{
			try
			{
				int model = TodoSource.ThingsToBeDone.RemoveAll(x => x.Title == title);
				TodoSource.ThingsToBeDone.Add(todo);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Todo/Delete/5

		public ActionResult Delete(string title)
		{
			TodoSource.ThingsToBeDone.RemoveAll(x => x.Title == title);
			return RedirectToAction("Index");
		}

		//
		// POST: /Todo/Delete/5

		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}


		public ActionResult Convert(Thought thought, string p)
		{
			var newTodo = new Todo
			{
				Title = thought.Name,
				Outcome = p,
				Topic = TopicSource.Topics.Find(topic=>topic.ID==thought.Topic.ID)
			};
			CreateTodo(newTodo);
			ThoughtSuroce.Thoughts.RemoveAll(thoughtToRemove =>
			                                 thoughtToRemove.Name == thought.Name);
			return RedirectToAction("Process", "Thought");
		}

		private void CreateTodo(Todo newTodo)
		{
			TodoSource.ThingsToBeDone.Add(newTodo);
		}
	}
}