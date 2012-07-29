using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetOrganized.Models;

namespace GetOrganized.Controllers
{
	public class TopicController : Controller
	{
		//
		// GET: /Topic/

		public ActionResult Index()
		{
			var list = new List<Topic>();
			return View(list);
		}

		//
		// GET: /Topic/Details/5

		public ActionResult Details(int id)
		{
			return View();
		}

		//
		// GET: /Topic/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Topic/Create

		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				var newTopic = new Topic();
				newTopic.ID = Convert.ToInt32(collection["ID"]);
				newTopic.Name = collection["Name"];
				newTopic.Color = ColorTranslator.FromHtml("#" + collection["Color"]);

				TopicSource.Topics.Add(newTopic);
				TempData["Message"] = "Your topic has been successfully.";
				return RedirectToAction("Index");

			}
			catch
			{
				return View();
			}
		}

		//
		// GET: /Topic/Edit/5

		public ActionResult Edit(int id)
		{
			return View();
		}

		//
		// POST: /Topic/Edit/5

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
		// GET: /Topic/Delete/5

		public ActionResult Delete(int id)
		{
			return View();
		}

		//
		// POST: /Topic/Delete/5

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
