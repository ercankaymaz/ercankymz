using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Math.EC.Rfc8032;

internal static class ScalarUtilities
{
	internal static void AddShifted_NP(int last, int s, uint[] Nu, uint[] Nv, uint[] _p)
	{
		int num = s >> 5;
		int num2 = s & 0x1F;
		ulong num3 = 0uL;
		ulong num4 = 0uL;
		if (num2 == 0)
		{
			for (int i = num; i <= last; i++)
			{
				num4 += Nu[i];
				num4 += _p[i - num];
				num3 += _p[i];
				num3 += Nv[i - num];
				_p[i] = (uint)num3;
				num3 >>= 32;
				num4 += _p[i - num];
				Nu[i] = (uint)num4;
				num4 >>= 32;
			}
			return;
		}
		uint num5 = 0u;
		uint num6 = 0u;
		uint num7 = 0u;
		for (int j = num; j <= last; j++)
		{
			uint num8 = _p[j - num];
			uint num9 = (num8 << num2) | (num5 >> -num2);
			num5 = num8;
			num4 += Nu[j];
			num4 += num9;
			uint num10 = Nv[j - num];
			uint num11 = (num10 << num2) | (num7 >> -num2);
			num7 = num10;
			num3 += _p[j];
			num3 += num11;
			_p[j] = (uint)num3;
			num3 >>= 32;
			uint num12 = _p[j - num];
			uint num13 = (num12 << num2) | (num6 >> -num2);
			num6 = num12;
			num4 += num13;
			Nu[j] = (uint)num4;
			num4 >>= 32;
		}
	}

	internal static void AddShifted_UV(int last, int s, uint[] u0, uint[] u1, uint[] v0, uint[] v1)
	{
		int num = s >> 5;
		int num2 = s & 0x1F;
		ulong num3 = 0uL;
		ulong num4 = 0uL;
		if (num2 == 0)
		{
			for (int i = num; i <= last; i++)
			{
				num3 += u0[i];
				num4 += u1[i];
				num3 += v0[i - num];
				num4 += v1[i - num];
				u0[i] = (uint)num3;
				num3 >>= 32;
				u1[i] = (uint)num4;
				num4 >>= 32;
			}
			return;
		}
		uint num5 = 0u;
		uint num6 = 0u;
		for (int j = num; j <= last; j++)
		{
			uint num7 = v0[j - num];
			uint num8 = v1[j - num];
			uint num9 = (num7 << num2) | (num5 >> -num2);
			uint num10 = (num8 << num2) | (num6 >> -num2);
			num5 = num7;
			num6 = num8;
			num3 += u0[j];
			num4 += u1[j];
			num3 += num9;
			num4 += num10;
			u0[j] = (uint)num3;
			num3 >>= 32;
			u1[j] = (uint)num4;
			num4 >>= 32;
		}
	}

	internal static int GetBitLength(int last, uint[] x)
	{
		int num = last;
		uint num2 = (uint)((int)x[num] >> 31);
		while (num > 0 && x[num] == num2)
		{
			num--;
		}
		return num * 32 + 32 - Integers.NumberOfLeadingZeros((int)(x[num] ^ num2));
	}

	internal static int GetBitLengthPositive(int last, uint[] x)
	{
		int num = last;
		while (num > 0 && x[num] == 0)
		{
			num--;
		}
		return num * 32 + 32 - Integers.NumberOfLeadingZeros((int)x[num]);
	}

	internal static bool LessThan(int last, uint[] x, uint[] y)
	{
		int num = last;
		do
		{
			if (x[num] < y[num])
			{
				return true;
			}
			if (x[num] > y[num])
			{
				return false;
			}
		}
		while (--num >= 0);
		return false;
	}

	internal static void SubShifted_NP(int last, int s, uint[] Nu, uint[] Nv, uint[] _p)
	{
		int num = s >> 5;
		int num2 = s & 0x1F;
		long num3 = 0L;
		long num4 = 0L;
		if (num2 == 0)
		{
			for (int i = num; i <= last; i++)
			{
				num4 += Nu[i];
				num4 -= _p[i - num];
				num3 += _p[i];
				num3 -= Nv[i - num];
				_p[i] = (uint)num3;
				num3 >>= 32;
				num4 -= _p[i - num];
				Nu[i] = (uint)num4;
				num4 >>= 32;
			}
			return;
		}
		uint num5 = 0u;
		uint num6 = 0u;
		uint num7 = 0u;
		for (int j = num; j <= last; j++)
		{
			uint num8 = _p[j - num];
			uint num9 = (num8 << num2) | (num5 >> -num2);
			num5 = num8;
			num4 += Nu[j];
			num4 -= num9;
			uint num10 = Nv[j - num];
			uint num11 = (num10 << num2) | (num7 >> -num2);
			num7 = num10;
			num3 += _p[j];
			num3 -= num11;
			_p[j] = (uint)num3;
			num3 >>= 32;
			uint num12 = _p[j - num];
			uint num13 = (num12 << num2) | (num6 >> -num2);
			num6 = num12;
			num4 -= num13;
			Nu[j] = (uint)num4;
			num4 >>= 32;
		}
	}

	internal static void SubShifted_UV(int last, int s, uint[] u0, uint[] u1, uint[] v0, uint[] v1)
	{
		int num = s >> 5;
		int num2 = s & 0x1F;
		long num3 = 0L;
		long num4 = 0L;
		if (num2 == 0)
		{
			for (int i = num; i <= last; i++)
			{
				num3 += u0[i];
				num4 += u1[i];
				num3 -= v0[i - num];
				num4 -= v1[i - num];
				u0[i] = (uint)num3;
				num3 >>= 32;
				u1[i] = (uint)num4;
				num4 >>= 32;
			}
			return;
		}
		uint num5 = 0u;
		uint num6 = 0u;
		for (int j = num; j <= last; j++)
		{
			uint num7 = v0[j - num];
			uint num8 = v1[j - num];
			uint num9 = (num7 << num2) | (num5 >> -num2);
			uint num10 = (num8 << num2) | (num6 >> -num2);
			num5 = num7;
			num6 = num8;
			num3 += u0[j];
			num4 += u1[j];
			num3 -= num9;
			num4 -= num10;
			u0[j] = (uint)num3;
			num3 >>= 32;
			u1[j] = (uint)num4;
			num4 >>= 32;
		}
	}

	internal static void Swap(ref uint[] x, ref uint[] y)
	{
		uint[] array = x;
		x = y;
		y = array;
	}
}
