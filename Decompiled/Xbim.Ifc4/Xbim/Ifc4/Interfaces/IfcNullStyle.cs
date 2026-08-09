using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.Interfaces;

[ExpressType("IfcNullStyle", 0)]
[DefinedType(typeof(IfcNullStyleEnum))]
public struct IfcNullStyle : IfcPresentationStyleSelect, IIfcPresentationStyleSelect, IExpressSelectType, IPersist, IExpressValueType, IEquatable<IfcNullStyleEnum>
{
	private IfcNullStyleEnum _value;

	public object Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(IfcNullStyleEnum);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcNullStyle(IfcNullStyleEnum val)
	{
		_value = val;
	}

	public IfcNullStyle(string val)
	{
		if (!Enum.TryParse<IfcNullStyleEnum>(val.Trim(new char[1] { '.' }), ignoreCase: true, out _value))
		{
			throw new ArgumentException();
		}
	}

	public static implicit operator IfcNullStyle(IfcNullStyleEnum value)
	{
		return new IfcNullStyle(value);
	}

	public static implicit operator IfcNullStyleEnum(IfcNullStyle obj)
	{
		return obj._value;
	}

	public override bool Equals(object obj)
	{
		if (obj == null && Value == null)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (GetType() != obj.GetType())
		{
			return false;
		}
		return ((IfcNullStyle)obj)._value == _value;
	}

	public bool Equals(IfcNullStyleEnum other)
	{
		return this == other;
	}

	public static bool operator ==(IfcNullStyle obj1, IfcNullStyle obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcNullStyle obj1, IfcNullStyle obj2)
	{
		return !object.Equals(obj1, obj2);
	}

	public override int GetHashCode()
	{
		if (Value == null)
		{
			return base.GetHashCode();
		}
		return _value.GetHashCode();
	}

	void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex != 0)
		{
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
		Enum.TryParse<IfcNullStyleEnum>(value.EnumVal, ignoreCase: true, out _value);
	}
}
