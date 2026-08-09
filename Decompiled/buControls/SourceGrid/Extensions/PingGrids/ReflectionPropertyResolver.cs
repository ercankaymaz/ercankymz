using System.Reflection;

namespace SourceGrid.Extensions.PingGrids;

public class ReflectionPropertyResolver : IPropertyResolver
{
	public static ReflectionPropertyResolver SharedInstance = new ReflectionPropertyResolver();

	public object ReadValue(object obj, string propertyPath)
	{
		PropertyInfo property = obj.GetType().GetProperty(propertyPath);
		if (!(property == null))
		{
			return property.GetValue(obj, null);
		}
		return string.Empty;
	}
}
