using System.Linq;
using System.Web.Mvc;
using GetOrganized.Models;

namespace GetOrganized.Controllers
{
	public class ThoughtController : Controller
	{
		//
		// GET: /Thought/

		public ActionResult Index()
		{
			return View(ThoughtSuroce.Thoughts);
		}
		public ActionResult Process()
		{
			return View(ThoughtSuroce.Thoughts.First());
		}
		//
		// GET: /Thought/Details/5

		public ActionResult Details(int id)
		{
			return View();
		}

		//
		// GET: /Thought/Create

		public ActionResult Create()
		{
			var thoughts = ThoughtSuroce.Thoughts;
			return View(thoughts);
		}

		//
		// POST: /Thought/Create

		[HttpPost]
		public ActionResult Create(Thought thoughts)
		{
			try
			{
			
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Thought/Edit/5

		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /Thought/Edit/5

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Thought/Delete/5

		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /Thought/Delete/5

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
	}
}