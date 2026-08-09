namespace Org.BouncyCastle.Math.Raw;

internal static class Bits
{
	internal static uint BitPermuteStep(uint x, uint m, int s)
	{
		uint num = (x ^ (x >> s)) & m;
		return num ^ (num << s) ^ x;
	}

	internal static ulong BitPermuteStep(ulong x, ulong m, int s)
	{
		ulong num = (x ^ (x >> s)) & m;
		return num ^ (num << s) ^ x;
	}

	internal static void BitPermuteStep2(ref uint hi, ref uint lo, uint m, int s)
	{
		uint num = ((lo >> s) ^ hi) & m;
		lo ^= num << s;
		hi ^= num;
	}

	internal static void BitPermuteStep2(ref ulong hi, ref ulong lo, ulong m, int s)
	{
		ulong num = ((lo >> s) ^ hi) & m;
		lo ^= num << s;
		hi ^= num;
	}

	internal static uint BitPermuteStepSimple(uint x, uint m, int s)
	{
		return ((x & m) << s) | ((x >> s) & m);
	}

	internal static ulong BitPermuteStepSimple(ulong x, ulong m, int s)
	{
		return ((x & m) << s) | ((x >> s) & m);
	}
}
