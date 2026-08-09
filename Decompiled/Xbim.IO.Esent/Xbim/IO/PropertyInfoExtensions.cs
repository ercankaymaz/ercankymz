using System.Reflection;

namespace Xbim.IO;

public static class PropertyInfoExtensions
{
	internal static object GetValue(this PropertyInfo propInfo, object obj)
	{
		return propInfo.GetValue(obj, null);
	}

	internal static void SetValue(this PropertyInfo propInfo, object obj, object value)
	{
		propInfo.SetValue(obj, value, null);
	}
}
