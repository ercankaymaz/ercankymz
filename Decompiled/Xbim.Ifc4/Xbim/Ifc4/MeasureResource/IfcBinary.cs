using System;
using System.Text;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcBinary", 986)]
[DefinedType(typeof(byte[]))]
public struct IfcBinary : IfcSimpleValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcSimpleValue, IExpressBinaryType, IEquatable<byte[]>
{
	private byte[] _value;

	public object Value => _value;

	byte[] IExpressBinaryType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(byte[]);

	public byte[] Bytes => _value;

	public override string ToString()
	{
		if (_value == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(_value.Length * 2);
		byte[] value = _value;
		foreach (byte b in value)
		{
			stringBuilder.AppendFormat("{0:X2}", b);
		}
		return stringBuilder.ToString();
	}

	public IfcBinary(byte[] val)
	{
		_value = val;
	}

	public IfcBinary(string val)
	{
		string text = val.Trim(new char[1] { '"' }).Substring(1);
		int length = text.Length;
		_value = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			_value[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
		}
	}

	public static implicit operator IfcBinary(byte[] value)
	{
		return new IfcBinary(value);
	}

	public static implicit operator byte[](IfcBinary obj)
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
		return ((IfcBinary)obj)._value == _value;
	}

	public bool Equals(byte[] other)
	{
		return this == other;
	}

	public static bool operator ==(IfcBinary obj1, IfcBinary obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcBinary obj1, IfcBinary obj2)
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
		_value = value.HexadecimalVal;
	}

	private static string ByteArrayToString(byte[] ba)
	{
		StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
		foreach (byte b in ba)
		{
			stringBuilder.AppendFormat("{0:X2}", b);
		}
		return stringBuilder.ToString();
	}

	private static byte[] StringToByteArray(string hex)
	{
		int length = hex.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		}
		return array;
	}
}
