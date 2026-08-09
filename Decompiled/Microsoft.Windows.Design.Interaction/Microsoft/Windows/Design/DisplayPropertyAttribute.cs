using System;

namespace Microsoft.Windows.Design;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public sealed class DisplayPropertyAttribute : Attribute
{
	private string _displayPropertyName;

	private Type _valueConverterType;

	public string DisplayPropertyName => _displayPropertyName;

	public Type ValueConverterType => _valueConverterType;

	public override object TypeId => typeof(DisplayPropertyAttribute);

	public DisplayPropertyAttribute(string displayPropertyName)
	{
		_displayPropertyName = displayPropertyName;
	}

	public DisplayPropertyAttribute(string displayPropertyName, Type valueConverterType)
	{
		_displayPropertyName = displayPropertyName;
		_valueConverterType = valueConverterType;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj is DisplayPropertyAttribute displayPropertyAttribute && object.Equals(DisplayPropertyName, displayPropertyAttribute.DisplayPropertyName))
		{
			return object.Equals(ValueConverterType, displayPropertyAttribute.ValueConverterType);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 0;
		if (DisplayPropertyName != null)
		{
			num ^= DisplayPropertyName.GetHashCode();
		}
		if ((object)ValueConverterType != null)
		{
			num ^= ValueConverterType.GetHashCode();
		}
		return num;
	}
}
