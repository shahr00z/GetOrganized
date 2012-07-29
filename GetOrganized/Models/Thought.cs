using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetOrganized.Models
{
	public class Thought
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public Topic Topic { get; set; }
	}
}