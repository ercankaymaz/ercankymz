using System;
using System.Runtime.CompilerServices;

namespace ns61;

internal struct Struct67(long long_1, ulong ulong_1)
{
	private long long_0 = long_1;

	private ulong ulong_0 = ulong_1;

	[SpecialName]
	public static bool smethod_0(Struct67 struct67_0, Struct67 struct67_1)
	{
		if ((object)struct67_0 != (object)struct67_1)
		{
			if ((object)struct67_0 != null && (object)struct67_1 != null)
			{
				return struct67_0.long_0 == struct67_1.long_0 && struct67_0.ulong_0 == struct67_1.ulong_0;
			}
			return false;
		}
		return true;
	}

	bool ValueType.Equals(object obj)
	{
		if (obj != null && obj is Struct67)
		{
			Struct67 @struct = (Struct67)obj;
			return @struct.long_0 == long_0 && @struct.ulong_0 == ulong_0;
		}
		return false;
	}

	int ValueType.GetHashCode()
	{
		return long_0.GetHashCode() ^ ulong_0.GetHashCode();
	}

	[SpecialName]
	public static Struct67 smethod_1(Struct67 struct67_0)
	{
		if (struct67_0.ulong_0 != 0L)
		{
			return new Struct67(~struct67_0.long_0, ~struct67_0.ulong_0 + 1L);
		}
		return new Struct67(-struct67_0.long_0, 0uL);
	}

	public static Struct67 smethod_2(long long_1, long long_2)
	{
		bool flag = long_1 < 0L != long_2 < 0L;
		if (long_1 < 0L)
		{
			long_1 = -long_1;
		}
		if (long_2 < 0L)
		{
			long_2 = -long_2;
		}
		ulong num = (ulong)long_1 >> 32;
		ulong num2 = (ulong)(long_1 & 0xFFFFFFFFL);
		ulong num3 = (ulong)long_2 >> 32;
		ulong num4 = (ulong)(long_2 & 0xFFFFFFFFL);
		ulong num5 = num * num3;
		ulong num6 = num2 * num4;
		ulong num7 = num * num4 + num2 * num3;
		long num8 = (long)(num5 + (num7 >> 32));
		ulong num9 = (num7 << 32) + num6;
		if (num9 < num6)
		{
			num8++;
		}
		Struct67 @struct = new Struct67(num8, num9);
		return (!flag) ? @struct : smethod_1(@struct);
	}
}
