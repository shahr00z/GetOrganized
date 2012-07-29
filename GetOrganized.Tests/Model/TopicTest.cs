using System.Drawing;
using GetOrganized.Models;
using NUnit.Framework;

namespace GetOrganized.Tests.Model
{
	[TestFixture]
	public class TopicTest
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			workTopic = new Topic {ID = 1, Color = Color.White, Name = "work"};
		}

		#endregion

		private Topic workTopic;

		[Test]
		public void Sholud_Convert_Color_To_Hex_Value()
		{
			var aShadeOfRedTopic =
				new Topic {Color = Color.FromArgb(0, 208, 0, 0)};
			Assert.AreEqual("#D00000", aShadeOfRedTopic.ColorInWebHex());
		}

		[Test]
		public void Should_Be_Equal_By_Value()
		{
			var anotherWorkTopic = new Topic {ID = 1, Color = Color.White, Name = "work"};
			Assert.AreEqual(workTopic, anotherWorkTopic);
		}

		[Test]
		public void Should_Not_Be_Equal_By_Value()
		{
			var anotherWorkTopic = new Topic {ID = 1, Color = Color.DarkRed, Name = "Personal"};
			Assert.AreNotEqual(workTopic, anotherWorkTopic);
		}
	}
}