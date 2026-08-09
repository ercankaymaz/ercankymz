using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public struct NumericRange : IFormattable, IEquatable<NumericRange>
{
	private static readonly NumericRange s_Empty = new NumericRange(-1, -1);

	private int m_begin;

	private int m_end;

	private NumericRange[] m_subranges;

	public int Begin
	{
		get
		{
			return m_begin;
		}
		set
		{
			if (value < -1)
			{
				throw new ArgumentOutOfRangeException("value", "Begin");
			}
			if (m_end != -1 && (m_begin > m_end || m_begin < 0))
			{
				throw new ArgumentOutOfRangeException("value", "Begin > End");
			}
			m_begin = value;
		}
	}

	public int End
	{
		get
		{
			return m_end;
		}
		set
		{
			if (value < -1)
			{
				throw new ArgumentOutOfRangeException("value", "End");
			}
			if (m_end != -1 && (m_begin > m_end || m_begin < 0))
			{
				throw new ArgumentOutOfRangeException("value", "Begin > End");
			}
			m_end = value;
		}
	}

	public int Count
	{
		get
		{
			if (m_begin == -1)
			{
				return 0;
			}
			if (m_end == -1)
			{
				return 1;
			}
			return m_end - m_begin + 1;
		}
	}

	public int Dimensions
	{
		get
		{
			if (m_begin == -1)
			{
				return 0;
			}
			if (m_subranges == null)
			{
				return 1;
			}
			return m_subranges.Length;
		}
	}

	public NumericRange[] SubRanges
	{
		get
		{
			return m_subranges;
		}
		set
		{
			m_subranges = value;
		}
	}

	public static NumericRange Empty => s_Empty;

	public NumericRange(int begin)
	{
		if (begin < -1)
		{
			throw new ArgumentOutOfRangeException("begin");
		}
		m_begin = -1;
		m_end = -1;
		m_subranges = null;
		Begin = begin;
	}

	public NumericRange(int begin, int end)
	{
		m_begin = -1;
		m_end = -1;
		m_subranges = null;
		Begin = begin;
		End = end;
	}

	public bool EnsureValid(object value)
	{
		int count = -1;
		if (value is ICollection collection)
		{
			count = collection.Count;
		}
		else if (value is Array array)
		{
			count = array.Length;
		}
		return EnsureValid(count);
	}

	public bool EnsureValid(int count)
	{
		if (count == -1)
		{
			return false;
		}
		if (m_begin > count || m_end >= count)
		{
			return false;
		}
		if (m_begin < 0)
		{
			m_begin = 0;
		}
		if (m_end < 0)
		{
			m_end = count;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (obj is NumericRange)
		{
			return Equals((NumericRange)obj);
		}
		return false;
	}

	public bool Equals(NumericRange other)
	{
		if (other.m_begin == m_begin)
		{
			return other.m_end == m_end;
		}
		return false;
	}

	public static bool operator ==(NumericRange value1, NumericRange value2)
	{
		return value1.Equals(value2);
	}

	public static bool operator !=(NumericRange value1, NumericRange value2)
	{
		return !value1.Equals(value2);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(m_begin, m_end);
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			if (m_end < 0)
			{
				return string.Format(formatProvider, "{0}", m_begin);
			}
			return string.Format(formatProvider, "{0}:{1}", m_begin, m_end);
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public static ServiceResult Validate(string textToParse, out NumericRange range)
	{
		range = Empty;
		if (string.IsNullOrEmpty(textToParse))
		{
			return ServiceResult.Good;
		}
		int num = textToParse.IndexOf(',');
		if (num >= 0)
		{
			int num2 = 0;
			List<NumericRange> list = new List<NumericRange>();
			for (int i = 0; i < textToParse.Length; i++)
			{
				char c = textToParse[i];
				if (c == ',' || i == textToParse.Length - 1)
				{
					NumericRange range2 = default(NumericRange);
					ServiceResult serviceResult = Validate((c == ',') ? textToParse.Substring(num2, i - num2) : textToParse.Substring(num2), out range2);
					if (ServiceResult.IsBad(serviceResult))
					{
						return serviceResult;
					}
					list.Add(range2);
					num2 = i + 1;
				}
			}
			if (list.Count < 2)
			{
				return 2151022592u;
			}
			range.m_begin = list[0].Begin;
			range.m_end = list[0].End;
			range.m_subranges = list.ToArray();
			return ServiceResult.Good;
		}
		try
		{
			num = textToParse.IndexOf(':');
			if (num != -1)
			{
				range.Begin = Convert.ToInt32(textToParse.Substring(0, num), CultureInfo.InvariantCulture);
				range.End = Convert.ToInt32(textToParse.Substring(num + 1), CultureInfo.InvariantCulture);
				if (range.End < 0)
				{
					return ServiceResult.Create(2151022592u, "NumericRange does not have a valid end index ({0}).", range.End);
				}
				if (range.Begin >= range.End)
				{
					return ServiceResult.Create(2151022592u, "NumericRange does not have a start index that is less than the end index ({0}).", range);
				}
			}
			else
			{
				range.Begin = Convert.ToInt32(textToParse, CultureInfo.InvariantCulture);
				range.End = -1;
			}
			if (range.Begin < 0)
			{
				return ServiceResult.Create(2151022592u, "NumericRange does not have a valid start index ({0}).", range.Begin);
			}
		}
		catch (Exception e)
		{
			return ServiceResult.Create(e, 2151022592u, "NumericRange cannot be parsed ({0}).", textToParse);
		}
		return ServiceResult.Good;
	}

	private StatusCode ApplyMultiRange(ref object value)
	{
		Array array = value as Array;
		TypeInfo typeInfo = null;
		if (array == null)
		{
			if (!(value is Matrix matrix) || matrix.Dimensions.Length != m_subranges.Length)
			{
				value = null;
				return 2151088128u;
			}
			array = matrix.ToArray();
		}
		typeInfo = TypeInfo.Construct(array);
		NumericRange? numericRange = null;
		if (m_subranges.Length > typeInfo.ValueRank)
		{
			if ((typeInfo.BuiltInType == BuiltInType.ByteString || typeInfo.BuiltInType == BuiltInType.String) && m_subranges.Length == typeInfo.ValueRank + 1)
			{
				numericRange = m_subranges[m_subranges.Length - 1];
			}
			if (!numericRange.HasValue)
			{
				value = null;
				return 2151088128u;
			}
		}
		int[] array2 = new int[typeInfo.ValueRank];
		for (int i = 0; i < array2.Length; i++)
		{
			if (m_subranges.Length > i)
			{
				if (m_subranges[i].m_begin >= array.GetLength(i))
				{
					value = null;
					return 2151088128u;
				}
				array2[i] = m_subranges[i].Count;
			}
			else
			{
				array2[i] = array.GetLength(i);
			}
		}
		Array array3 = TypeInfo.CreateArray(typeInfo.BuiltInType, array2);
		int length = array3.Length;
		int[] array4 = new int[array2.Length];
		int[] array5 = new int[array2.Length];
		bool flag = false;
		for (int j = 0; j < length; j++)
		{
			int num = array3.Length;
			bool flag2 = false;
			for (int k = 0; k < array4.Length; k++)
			{
				num /= array2[k];
				array4[k] = j / num % array2[k];
				array5[k] = array4[k] + m_subranges[k].m_begin;
				if (array.GetLength(k) <= array5[k])
				{
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				continue;
			}
			object value2 = array.GetValue(array5);
			if (value2 == null)
			{
				continue;
			}
			if (numericRange.HasValue)
			{
				StatusCode statusCode = numericRange.Value.ApplyRange(ref value2);
				if (StatusCode.IsBad(statusCode))
				{
					if (statusCode != 2151088128u)
					{
						value = null;
						return statusCode;
					}
					continue;
				}
			}
			flag = true;
			array3.SetValue(value2, array4);
		}
		if (!flag)
		{
			value = null;
			return 2151088128u;
		}
		value = array3;
		return 0u;
	}

	public StatusCode UpdateRange(ref object dst, object src)
	{
		if (dst == null)
		{
			return 2151088128u;
		}
		TypeInfo typeInfo = TypeInfo.Construct(dst);
		if (typeInfo.ValueRank == -1)
		{
			if (Dimensions > 1)
			{
				return 2151022592u;
			}
			if (typeInfo.BuiltInType == BuiltInType.String)
			{
				char[] array = ((string)dst).ToCharArray();
				if (!(src is string text) || text.Length != Count)
				{
					return 2151022592u;
				}
				if (m_begin >= array.Length || (m_end > 0 && m_end >= array.Length))
				{
					return 2151088128u;
				}
				for (int i = 0; i < text.Length; i++)
				{
					array[m_begin + i] = text[i];
				}
				dst = new string(array);
				return 0u;
			}
			if (typeInfo.BuiltInType == BuiltInType.ByteString)
			{
				byte[] array2 = (byte[])dst;
				if (!(src is byte[] array3) || array3.Length != Count)
				{
					return 2151022592u;
				}
				if (m_begin >= array2.Length || (m_end > 0 && m_end >= array2.Length))
				{
					return 2151088128u;
				}
				for (int j = 0; j < array3.Length; j++)
				{
					array2[m_begin + j] = array3[j];
				}
				return 0u;
			}
			return 2151022592u;
		}
		Array array4 = src as Array;
		Array array5 = dst as Array;
		if (array5 == null)
		{
			if (!(dst is Matrix matrix) || m_subranges == null || matrix.Dimensions.Length != m_subranges.Length)
			{
				return 2151022592u;
			}
			array5 = matrix.ToArray();
		}
		if (array4 == null)
		{
			if (!(src is Matrix matrix2) || m_subranges == null || matrix2.Dimensions.Length != m_subranges.Length)
			{
				return 2151022592u;
			}
			array4 = matrix2.ToArray();
		}
		TypeInfo typeInfo2 = TypeInfo.Construct(array4);
		if (typeInfo2.BuiltInType != typeInfo.BuiltInType)
		{
			return 2151022592u;
		}
		if (typeInfo2.ValueRank != typeInfo.ValueRank)
		{
			return 2151022592u;
		}
		if (m_subranges == null)
		{
			if (typeInfo.ValueRank > 1)
			{
				return 2151022592u;
			}
			if (array4.Length != Count)
			{
				return 2151022592u;
			}
			if (m_begin >= array5.Length || (m_end > 0 && m_end >= array5.Length))
			{
				return 2151088128u;
			}
			for (int k = 0; k < array4.Length; k++)
			{
				array5.SetValue(array4.GetValue(k), m_begin + k);
			}
			if (dst is Matrix)
			{
				dst = new Matrix(array5, typeInfo.BuiltInType);
			}
			return 0u;
		}
		NumericRange? numericRange = null;
		if (m_subranges != null && m_subranges.Length > typeInfo2.ValueRank)
		{
			if ((typeInfo2.BuiltInType == BuiltInType.ByteString || typeInfo2.BuiltInType == BuiltInType.String) && m_subranges.Length == typeInfo2.ValueRank + 1)
			{
				numericRange = m_subranges[m_subranges.Length - 1];
			}
			if (!numericRange.HasValue)
			{
				return 2151088128u;
			}
		}
		int num = 1;
		int[] array6 = new int[typeInfo2.ValueRank];
		for (int l = 0; l < array6.Length; l++)
		{
			if (m_subranges.Length < l && m_subranges[l].Count != array4.GetLength(l))
			{
				return 2151022592u;
			}
			array6[l] = array4.GetLength(l);
			num *= array6[l];
		}
		int[] array7 = new int[array6.Length];
		for (int m = 0; m < num; m++)
		{
			int num2 = num;
			for (int n = 0; n < array6.Length; n++)
			{
				num2 /= array6[n];
				int num3 = m / num2 % array6[n];
				int num4 = 0;
				if (m_subranges.Length > n)
				{
					num4 = m_subranges[n].m_begin;
				}
				if (num4 + num3 >= array5.GetLength(n))
				{
					return 2151088128u;
				}
				array7[n] = num4 + num3;
			}
			if (!numericRange.HasValue)
			{
				continue;
			}
			int num5 = numericRange.Value.m_begin;
			if (numericRange.Value.m_end > 0)
			{
				num5 = numericRange.Value.m_end;
			}
			object value = array5.GetValue(array7);
			if (typeInfo.BuiltInType == BuiltInType.String)
			{
				string text2 = (string)value;
				if (text2 == null || num5 >= text2.Length)
				{
					return 2151088128u;
				}
			}
			else if (typeInfo.BuiltInType == BuiltInType.ByteString)
			{
				byte[] array8 = (byte[])value;
				if (array8 == null || num5 >= array8.Length)
				{
					return 2151088128u;
				}
			}
		}
		int[] array9 = new int[array6.Length];
		for (int num6 = 0; num6 < num; num6++)
		{
			int num7 = num;
			for (int num8 = 0; num8 < array6.Length; num8++)
			{
				num7 /= array6[num8];
				int num9 = num6 / num7 % array6[num8];
				int num10 = 0;
				if (m_subranges.Length > num8)
				{
					num10 = m_subranges[num8].m_begin;
				}
				if (num10 + num9 >= array5.GetLength(num8))
				{
					return 2151088128u;
				}
				array9[num8] = num9;
				array7[num8] = num10 + num9;
			}
			object value2 = array4.GetValue(array9);
			if (!numericRange.HasValue)
			{
				array5.SetValue(value2, array7);
				continue;
			}
			object value3 = array5.GetValue(array7);
			if (typeInfo.BuiltInType == BuiltInType.String)
			{
				string text3 = (string)value2;
				char[] array10 = ((string)value3).ToCharArray();
				if (text3 != null)
				{
					for (int num11 = 0; num11 < text3.Length; num11++)
					{
						array10[numericRange.Value.m_begin + num11] = text3[num11];
					}
				}
				array5.SetValue(new string(array10), array7);
			}
			else
			{
				if (typeInfo.BuiltInType != BuiltInType.ByteString)
				{
					continue;
				}
				byte[] array11 = (byte[])value2;
				byte[] array12 = (byte[])value3;
				if (array11 != null)
				{
					for (int num12 = 0; num12 < array11.Length; num12++)
					{
						array12[numericRange.Value.m_begin + num12] = array11[num12];
					}
				}
			}
		}
		if (dst is Matrix)
		{
			dst = new Matrix(array5, typeInfo.BuiltInType);
		}
		return 0u;
	}

	public StatusCode ApplyRange(ref object value)
	{
		if (m_begin == -1 && m_end == -1)
		{
			return 0u;
		}
		if (value == null)
		{
			return 0u;
		}
		Array array = value as Array;
		IList list = null;
		TypeInfo typeInfo = null;
		if (array == null)
		{
			list = value as IList;
			if (list != null)
			{
				typeInfo = TypeInfo.Construct(list);
			}
		}
		bool flag = false;
		if (array == null && list == null && value is string text)
		{
			flag = true;
			array = text.ToCharArray();
		}
		if (m_subranges != null)
		{
			return ApplyMultiRange(ref value);
		}
		if (list == null && array == null)
		{
			value = null;
			return 2151088128u;
		}
		int num = 0;
		num = list?.Count ?? array.Length;
		int num2 = m_begin;
		if (num2 == -1)
		{
			num2 = 0;
		}
		if (num2 >= num)
		{
			value = null;
			return 2151088128u;
		}
		int num3 = m_end;
		if (num3 == -1)
		{
			num3 = num2;
		}
		else if (num3 >= num - 1)
		{
			num3 = num - 1;
		}
		Array array2 = null;
		int num4 = num3 - num2 + 1;
		if (list != null && typeInfo != null)
		{
			array2 = TypeInfo.CreateArray(typeInfo.BuiltInType, num4);
			for (int i = num2; i < num4; i++)
			{
				array2.SetValue(list[i], i - num2);
			}
			return 0u;
		}
		array2 = ((!flag) ? Array.CreateInstance(array.GetType().GetElementType(), num4) : new char[num4]);
		Array.Copy(array, num2, array2, 0, array2.Length);
		if (flag)
		{
			value = new string((char[])array2);
		}
		else
		{
			value = array2;
		}
		return 0u;
	}

	public static NumericRange Parse(string textToParse)
	{
		NumericRange range = Empty;
		ServiceResult status = Validate(textToParse, out range);
		if (ServiceResult.IsBad(status))
		{
			throw new ServiceResultException(status);
		}
		return range;
	}
}
