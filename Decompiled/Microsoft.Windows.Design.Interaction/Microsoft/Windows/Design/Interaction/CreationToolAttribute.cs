using System;
using System.Globalization;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Interaction;

[AttributeUsage(AttributeTargets.Class)]
public sealed class CreationToolAttribute : Attribute
{
	private Type _toolType;

	public Type ToolType => _toolType;

	public CreationToolAttribute(Type toolType)
	{
		if ((object)toolType != null && !typeof(CreationTool).IsAssignableFrom(toolType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ArgIncorrectType, new object[2]
			{
				"toolType",
				typeof(CreationTool).Name
			}));
		}
		_toolType = toolType;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj is CreationToolAttribute creationToolAttribute)
		{
			return (object)creationToolAttribute._toolType == _toolType;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if ((object)_toolType != null)
		{
			return _toolType.GetHashCode();
		}
		return typeof(CreationToolAttribute).GetHashCode();
	}
}
