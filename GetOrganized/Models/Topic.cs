using System.Collections;
using System.Drawing;

namespace GetOrganized.Models
{
	public class Topic
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public Color Color { get; set; }
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Topic)) return false;

			var other = obj as Topic;

			//return other.ID == ID
			//	&& other.Color.Equals(Color)
			//	&& Equals(other.Name, Name);
			return other.ID == ID
				   && other.Color == Color
				   && other.Name == Name;
		}

		public override int GetHashCode()
		{
			return ID;
		}

		public string ColorInWebHex()
		{
			return ColorTranslator.ToHtml(Color);
		}
	}
}