using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using NUnit.Framework;

namespace GetOrganized.Tests.Helper
{
	public class TestHelper
	{
		public static void AssertIsAouthorized(ICustomAttributeProvider type)
		{
			Assert.IsTrue(type.GetCustomAttributes(false).Any(o => o.GetType() == typeof (AuthorizeAttribute)));
		}
	}
}