using System.Collections.Generic;

namespace GetOrganized.Models
{
	public class Todo
	{

		public bool Completed { get; set; }
		public string Title { get; set; }
		public string Outcome { get; set; }
		public Topic Topic { get; set; }
	}
}