using System;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public sealed class ToolboxTabNameAttribute : Attribute
{
	public const string CommonTab = "Common";

	public string TabName { get; private set; }

	public ToolboxTabNameAttribute(string tabName)
	{
		TabName = tabName;
	}
}
