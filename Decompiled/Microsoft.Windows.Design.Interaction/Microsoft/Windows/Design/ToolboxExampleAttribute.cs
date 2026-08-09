using System;
using System.Globalization;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class ToolboxExampleAttribute : Attribute
{
	public Type ToolboxExampleFactoryType { get; private set; }

	public ToolboxExampleAttribute(Type toolboxExampleFactoryType)
	{
		if (!typeof(IToolboxExampleFactory).IsAssignableFrom(toolboxExampleFactoryType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_InvalidToolboxExampleFactoryType, new object[1] { typeof(IToolboxExampleFactory).Name }), "toolboxExampleFactoryType");
		}
		ToolboxExampleFactoryType = toolboxExampleFactoryType;
	}
}
