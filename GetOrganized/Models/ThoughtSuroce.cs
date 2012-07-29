using System.Collections.Generic;
using System.Drawing;

namespace GetOrganized.Models
{
	public class ThoughtSuroce
	{
		public static List<Thought> Thoughts = new List<Thought>
			{
				new Thought
					{
						Topic = new Topic
							{
								Name = "Shahrooz",
								Color = Color.White
							},
						Name = "Test"
					},
				new Thought
					{
						Topic = new Topic
							{
								Name = "Shahrooz",
								Color = Color.White
							},
						Name = "Test"
					},
				new Thought
					{
						Topic = new Topic
							{
								Name = "Shahrooz",
								Color = Color.White
							},
						Name = "Test"
					}

			};
	}
}