using System;
using System.Text;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.UtilityResource;

[ExpressType("IfcGloballyUniqueId", 443)]
[DefinedType(typeof(string))]
public struct IfcGloballyUniqueId : IExpressValueType, IPersist, IExpressStringType, IEquatable<string>
{
	private string _value;

	private const string CConversionTable = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_$";

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcGloballyUniqueId(string val)
	{
		_value = val;
	}

	public static implicit operator IfcGloballyUniqueId(string value)
	{
		return new IfcGloballyUniqueId(value);
	}

	public static implicit operator string(IfcGloballyUniqueId obj)
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
		return ((IfcGloballyUniqueId)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcGloballyUniqueId)other;
	}

	public static bool operator ==(IfcGloballyUniqueId obj1, IfcGloballyUniqueId obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcGloballyUniqueId obj1, IfcGloballyUniqueId obj2)
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
		_value = value.StringVal;
	}

	public static IfcGloballyUniqueId FromGuid(Guid gid)
	{
		return new IfcGloballyUniqueId
		{
			_value = ConvertToBase64(gid)
		};
	}

	public static Guid ConvertFromBase64(string base64StrId)
	{
		if (base64StrId.Length != 22)
		{
			throw new ArgumentOutOfRangeException("base64StrId", "The Guid must be 22 characters long");
		}
		if (Convert.ToByte(base64StrId[0]) - 48 > 3)
		{
			throw new ArgumentOutOfRangeException("base64StrId", $"Illegal Guid {base64StrId} found, it is greater than 128 bits");
		}
		uint[] array = new uint[6];
		int num = 2;
		int i = 0;
		int num2 = 0;
		for (; i < 6; i++)
		{
			array[i] = From64String(base64StrId.Substring(num2, num));
			num2 += num;
			num = 4;
		}
		byte[] array2 = new byte[16];
		uint value = array[0] * 16777216 + array[1];
		ushort value2 = (ushort)(array[2] / 256);
		ushort value3 = (ushort)(array[2] % 256 * 256 + array[3] / 65536);
		array2[8] = (byte)(array[3] / 256 % 256);
		array2[9] = (byte)(array[3] % 256);
		array2[10] = (byte)(array[4] / 65536);
		array2[11] = (byte)(array[4] / 256 % 256);
		array2[12] = (byte)(array[4] % 256);
		array2[13] = (byte)(array[5] / 65536);
		array2[14] = (byte)(array[5] / 256 % 256);
		array2[15] = (byte)(array[5] % 256);
		byte[] bytes = BitConverter.GetBytes(value);
		byte[] bytes2 = BitConverter.GetBytes(value2);
		byte[] bytes3 = BitConverter.GetBytes(value3);
		for (int j = 0; j < bytes.Length; j++)
		{
			array2[j] = bytes[j];
		}
		array2[4] = bytes2[0];
		array2[5] = bytes2[1];
		array2[6] = bytes3[0];
		array2[7] = bytes3[1];
		return new Guid(array2);
	}

	public static string ConvertToBase64(Guid guid)
	{
		byte[] array = guid.ToByteArray();
		uint num = BitConverter.ToUInt32(array, 0);
		ushort num2 = BitConverter.ToUInt16(array, 4);
		ushort num3 = BitConverter.ToUInt16(array, 6);
		uint[] array2 = new uint[6]
		{
			num / 16777216,
			num % 16777216,
			(uint)(num2 * 256 + num3 / 256),
			(uint)(num3 % 256 * 65536 + array[8] * 256 + array[9]),
			(uint)(array[10] * 65536 + array[11] * 256 + array[12]),
			(uint)(array[13] * 65536 + array[14] * 256 + array[15])
		};
		int nDigits = 2;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 6; i++)
		{
			stringBuilder.Append(To64String(array2[i], nDigits));
			nDigits = 4;
		}
		return stringBuilder.ToString();
	}

	public static string AsPart21(Guid guid)
	{
		return $"'{ConvertToBase64(guid)}'";
	}

	private static string To64String(uint num, int nDigits)
	{
		char[] array = new char[nDigits];
		uint num2 = num;
		for (int i = 0; i < nDigits; i++)
		{
			array[nDigits - i - 1] = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_$"[(int)(num2 % 64)];
			num2 /= 64;
		}
		return new string(array);
	}

	private static uint From64String(string str)
	{
		uint num = 0u;
		foreach (char value in str)
		{
			uint num2 = (uint)"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_$".IndexOf(value);
			num = num * 64 + num2;
		}
		return num;
	}

	public static implicit operator Guid(IfcGloballyUniqueId gid)
	{
		return ConvertFromBase64(gid._value);
	}
}
