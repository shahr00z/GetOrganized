using System.Collections.Generic;

namespace GetOrganized.Models
{
	public class TodoSource
	{
		public static List<Todo> ThingsToBeDone = new List<Todo>
			{
				new Todo {Title = "Get Mike", Completed = false},
				new Todo {Title = " Birng Home Bacon", Completed = false},
				new Todo {Title = "Buy Home ", Completed = false}
			};
	}
}