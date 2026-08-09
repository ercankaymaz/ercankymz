using System.Reflection;

namespace Xbim.Common.Delta;

public class PropertyChange
{
	public string Name { get; internal set; }

	public int Order { get; set; }

	public PropertyInfo PropertyInfo { get; internal set; }

	public string OriginalValue { get; internal set; }

	public string CurrentValue { get; internal set; }

	internal PropertyChange()
	{
	}
}
