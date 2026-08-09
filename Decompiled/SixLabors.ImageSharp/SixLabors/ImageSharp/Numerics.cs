using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp;

internal static class Numerics
{
	public const int BlendAlphaControl = 136;

	private const int ShuffleAlphaControl = 255;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GreatestCommonDivisor(int a, int b)
	{
		while (b != 0)
		{
			int num = b;
			b = a % b;
			a = num;
		}
		return a;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int LeastCommonMultiple(int a, int b)
	{
		return a / GreatestCommonDivisor(a, b) * b;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Modulo2(int x)
	{
		return x & 1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Modulo4(int x)
	{
		return x & 3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Modulo4(nint x)
	{
		return x & 3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Modulo8(int x)
	{
		return x & 7;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Modulo8(nint x)
	{
		return x & 7;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Modulo64(int x)
	{
		return x & 0x3F;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Modulo64(nint x)
	{
		return x & 0x3F;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Modulo256(int x)
	{
		return x & 0xFF;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Modulo256(nint x)
	{
		return x & 0xFF;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ModuloP2(int x, int m)
	{
		return x & (m - 1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Abs(int x)
	{
		int num = x >> 31;
		return (x ^ num) - num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Pow2(float x)
	{
		return x * x;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Pow3(float x)
	{
		return x * x * x;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Gaussian(float x, float sigma)
	{
		float num = MathF.Sqrt((float)Math.PI * 2f) * sigma;
		float num2 = (0f - x) * x;
		float num3 = 2f * Pow2(sigma);
		float num4 = 1f / num;
		float num5 = MathF.Exp(num2 / num3);
		return num4 * num5;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float SinC(float f)
	{
		if (MathF.Abs(f) > Constants.Epsilon)
		{
			f *= (float)Math.PI;
			float num = MathF.Sin(f) / f;
			if (!(MathF.Abs(num) < Constants.Epsilon))
			{
				return num;
			}
			return 0f;
		}
		return 1f;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte Clamp(byte value, byte min, byte max)
	{
		if (value > max)
		{
			return max;
		}
		if (value < min)
		{
			return min;
		}
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint Clamp(uint value, uint min, uint max)
	{
		if (value > max)
		{
			return max;
		}
		if (value < min)
		{
			return min;
		}
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int Clamp(int value, int min, int max)
	{
		if (value > max)
		{
			return max;
		}
		if (value < min)
		{
			return min;
		}
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Clamp(float value, float min, float max)
	{
		if (value > max)
		{
			return max;
		}
		if (value < min)
		{
			return min;
		}
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Clamp(double value, double min, double max)
	{
		if (value > max)
		{
			return max;
		}
		if (value < min)
		{
			return min;
		}
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Clamp(Vector4 value, Vector4 min, Vector4 max)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return Vector4.Min(Vector4.Max(value, min), max);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Clamp(Span<byte> span, byte min, byte max)
	{
		int num = ClampReduce(span, min, max);
		Span<byte> span2 = span.Slice(num, span.Length - num);
		if (span2.Length > 0)
		{
			ref byte reference = ref MemoryMarshal.GetReference<byte>(span2);
			ref byte right = ref Unsafe.Add(ref reference, (uint)span2.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = Clamp(reference, min, max);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Clamp(Span<uint> span, uint min, uint max)
	{
		int num = ClampReduce(span, min, max);
		Span<uint> span2 = span.Slice(num, span.Length - num);
		if (span2.Length > 0)
		{
			ref uint reference = ref MemoryMarshal.GetReference<uint>(span2);
			ref uint right = ref Unsafe.Add(ref reference, (uint)span2.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = Clamp(reference, min, max);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Clamp(Span<int> span, int min, int max)
	{
		int num = ClampReduce(span, min, max);
		Span<int> span2 = span.Slice(num, span.Length - num);
		if (span2.Length > 0)
		{
			ref int reference = ref MemoryMarshal.GetReference<int>(span2);
			ref int right = ref Unsafe.Add(ref reference, (uint)span2.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = Clamp(reference, min, max);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Clamp(Span<float> span, float min, float max)
	{
		int num = ClampReduce(span, min, max);
		Span<float> span2 = span.Slice(num, span.Length - num);
		if (span2.Length > 0)
		{
			ref float reference = ref MemoryMarshal.GetReference<float>(span2);
			ref float right = ref Unsafe.Add(ref reference, (uint)span2.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = Clamp(reference, min, max);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Clamp(Span<double> span, double min, double max)
	{
		int num = ClampReduce(span, min, max);
		Span<double> span2 = span.Slice(num, span.Length - num);
		if (span2.Length > 0)
		{
			ref double reference = ref MemoryMarshal.GetReference<double>(span2);
			ref double right = ref Unsafe.Add(ref reference, (uint)span2.Length);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				reference = Clamp(reference, min, max);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static int ClampReduce<T>(Span<T> span, T min, T max) where T : unmanaged
	{
		if (Vector.IsHardwareAccelerated && span.Length >= Vector<T>.Count)
		{
			int num = ModuloP2(span.Length, Vector<T>.Count);
			int num2 = span.Length - num;
			if (num2 > 0)
			{
				ClampImpl(span.Slice(0, num2), min, max);
			}
			return num2;
		}
		return 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ClampImpl<T>(Span<T> span, T min, T max) where T : unmanaged
	{
		MemoryMarshal.GetReference<T>(span);
		Vector<T> left = new Vector<T>(min);
		Vector<T> right = new Vector<T>(max);
		nint num = (nint)(uint)span.Length / (nint)Vector<T>.Count;
		nint num2 = Modulo4(num);
		nint elementOffset = num - num2;
		ref Vector<T> reference = ref Unsafe.As<T, Vector<T>>(ref MemoryMarshal.GetReference<T>(span));
		ref Vector<T> reference2 = ref Unsafe.Add(ref reference, 1);
		ref Vector<T> reference3 = ref Unsafe.Add(ref reference, 2);
		ref Vector<T> reference4 = ref Unsafe.Add(ref reference, 3);
		ref Vector<T> reference5 = ref Unsafe.Add(ref reference, elementOffset);
		while (Unsafe.IsAddressLessThan(ref reference, ref reference5))
		{
			reference = Vector.Min(Vector.Max(left, reference), right);
			reference2 = Vector.Min(Vector.Max(left, reference2), right);
			reference3 = Vector.Min(Vector.Max(left, reference3), right);
			reference4 = Vector.Min(Vector.Max(left, reference4), right);
			reference = ref Unsafe.Add(ref reference, 4);
			reference2 = ref Unsafe.Add(ref reference2, 4);
			reference3 = ref Unsafe.Add(ref reference3, 4);
			reference4 = ref Unsafe.Add(ref reference4, 4);
		}
		if (num2 > 0)
		{
			reference = ref reference5;
			reference5 = ref Unsafe.Add(ref reference5, num2);
			while (Unsafe.IsAddressLessThan(ref reference, ref reference5))
			{
				reference = Vector.Min(Vector.Max(left, reference), right);
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Premultiply(ref Vector4 source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = source;
		Vector4 val2 = PermuteW(val);
		source = WithW(val * val2, val2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Premultiply(Span<Vector4> vectors)
	{
		if (Avx.IsSupported && vectors.Length >= 2)
		{
			ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(vectors));
			ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)vectors.Length / 2u);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				Vector256<float> vector = reference;
				Vector256<float> right2 = Avx.Permute(vector, byte.MaxValue);
				reference = Avx.Blend(Avx.Multiply(vector, right2), vector, 136);
				reference = ref Unsafe.Add(ref reference, 1);
			}
			if (Modulo2(vectors.Length) != 0)
			{
				int length = vectors.Length;
				int num = length - 1;
				Premultiply(ref MemoryMarshal.GetReference<Vector4>(vectors.Slice(num, length - num)));
			}
		}
		else
		{
			ref Vector4 reference2 = ref MemoryMarshal.GetReference<Vector4>(vectors);
			ref Vector4 right3 = ref Unsafe.Add(ref reference2, (uint)vectors.Length);
			while (Unsafe.IsAddressLessThan(ref reference2, ref right3))
			{
				Premultiply(ref reference2);
				reference2 = ref Unsafe.Add(ref reference2, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void UnPremultiply(ref Vector4 source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		Vector4 alpha = PermuteW(source);
		UnPremultiply(ref source, alpha);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void UnPremultiply(ref Vector4 source, Vector4 alpha)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (!(alpha == Vector4.Zero))
		{
			source = WithW(source / alpha, alpha);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void UnPremultiply(Span<Vector4> vectors)
	{
		if (Avx.IsSupported && vectors.Length >= 2)
		{
			ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(vectors));
			ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)vectors.Length / 2u);
			Vector256.Create(Constants.Epsilon);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				Vector256<float> vector = reference;
				Vector256<float> alpha = Avx.Permute(vector, byte.MaxValue);
				reference = UnPremultiply(vector, alpha);
				reference = ref Unsafe.Add(ref reference, 1);
			}
			if (Modulo2(vectors.Length) != 0)
			{
				int length = vectors.Length;
				int num = length - 1;
				UnPremultiply(ref MemoryMarshal.GetReference<Vector4>(vectors.Slice(num, length - num)));
			}
		}
		else
		{
			ref Vector4 reference2 = ref MemoryMarshal.GetReference<Vector4>(vectors);
			ref Vector4 right2 = ref Unsafe.Add(ref reference2, (uint)vectors.Length);
			while (Unsafe.IsAddressLessThan(ref reference2, ref right2))
			{
				UnPremultiply(ref reference2);
				reference2 = ref Unsafe.Add(ref reference2, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> UnPremultiply(Vector256<float> source, Vector256<float> alpha)
	{
		Vector256<float> mask = Avx.CompareEqual(alpha, Vector256<float>.Zero);
		return Avx.Blend(Avx.BlendVariable(Avx.Divide(source, alpha), source, mask), alpha, 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 PermuteW(Vector4 value)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (Sse.IsSupported)
		{
			return Vector128.AsVector4(Sse.Shuffle(Vector128.AsVector128(value), Vector128.AsVector128(value), byte.MaxValue));
		}
		return new Vector4(value.W);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 WithW(Vector4 value, Vector4 w)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (Sse41.IsSupported)
		{
			return Vector128.AsVector4(Sse41.Insert(Vector128.AsVector128(value), Vector128.AsVector128(w), 240));
		}
		if (Sse.IsSupported)
		{
			Vector128<float> right = Sse.Shuffle(Vector128.AsVector128(w), Vector128.AsVector128(value), 35);
			return Vector128.AsVector4(Sse.Shuffle(Vector128.AsVector128(value), right, 36));
		}
		value.W = w.W;
		return value;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void CubePowOnXYZ(Span<Vector4> vectors)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		ref Vector4 reference = ref MemoryMarshal.GetReference<Vector4>(vectors);
		ref Vector4 right = ref Unsafe.Add(ref reference, (uint)vectors.Length);
		while (Unsafe.IsAddressLessThan(ref reference, ref right))
		{
			Vector4 val = reference;
			Vector4 w = PermuteW(val);
			val = val * val * val;
			val = WithW(val, w);
			reference = val;
			reference = ref Unsafe.Add(ref reference, 1);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static void CubeRootOnXYZ(Span<Vector4> vectors)
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		if (Sse41.IsSupported)
		{
			ref Vector128<float> reference = ref Unsafe.As<Vector4, Vector128<float>>(ref MemoryMarshal.GetReference<Vector4>(vectors));
			ref Vector128<float> right = ref Unsafe.Add(ref reference, (uint)vectors.Length);
			Vector128<int> right2 = Vector128.Create(341);
			Vector128<int> vector = Vector128.Create(-0f).AsInt32();
			Vector128<int> right3 = Vector128.Create(1f).AsInt32();
			Vector128<float> left = Vector128.Create(1f / 3f);
			Vector128<float> vector2 = Vector128.Create(2f / 3f);
			while (Unsafe.IsAddressLessThan(ref reference, ref right))
			{
				Vector128<float> vector3 = reference;
				Vector128<int> right4 = vector3.AsInt32();
				right4 = Sse2.AndNot(vector, right4);
				right4 = Sse2.Subtract(right4, right3);
				right4 = Sse2.ShiftRightArithmetic(right4, 10);
				right4 = Sse41.MultiplyLow(right4, right2);
				right4 = Sse2.Add(right4, right3);
				right4 = Sse2.AndNot(vector, right4);
				right4 = Sse2.Or(right4, Sse2.And(vector3.AsInt32(), vector));
				Vector128<float> vector4 = right4.AsSingle();
				if (Fma.IsSupported)
				{
					vector4 = Fma.MultiplyAdd(vector2, vector4, Sse.Multiply(left, Sse.Divide(vector3, Sse.Multiply(vector4, vector4))));
					vector4 = Fma.MultiplyAdd(vector2, vector4, Sse.Multiply(left, Sse.Divide(vector3, Sse.Multiply(vector4, vector4))));
				}
				else
				{
					vector4 = Sse.Add(Sse.Multiply(vector2, vector4), Sse.Multiply(left, Sse.Divide(vector3, Sse.Multiply(vector4, vector4))));
					vector4 = Sse.Add(Sse.Multiply(vector2, vector4), Sse.Multiply(left, Sse.Divide(vector3, Sse.Multiply(vector4, vector4))));
				}
				vector4 = Sse41.Insert(vector4, vector3, 240);
				reference = vector4;
				reference = ref Unsafe.Add(ref reference, 1);
			}
		}
		else
		{
			ref Vector4 reference2 = ref MemoryMarshal.GetReference<Vector4>(vectors);
			ref Vector4 right5 = ref Unsafe.Add(ref reference2, (uint)vectors.Length);
			Vector4 val2 = default(Vector4);
			while (Unsafe.IsAddressLessThan(ref reference2, ref right5))
			{
				Vector4 val = reference2;
				double num = val.X;
				double num2 = val.Y;
				double num3 = val.Z;
				float w = val.W;
				ulong num4 = *(ulong*)(&num);
				ulong num5 = *(ulong*)(&num2);
				ulong num6 = *(ulong*)(&num3);
				num4 = 3071325735593686528L + num4 / 3;
				num5 = 3071325735593686528L + num5 / 3;
				num6 = 3071325735593686528L + num6 / 3;
				val2.X = (float)(*(double*)(&num4));
				val2.Y = (float)(*(double*)(&num5));
				val2.Z = (float)(*(double*)(&num6));
				val2.W = 0f;
				val2 = 2f / 3f * val2 + 1f / 3f * (val / (val2 * val2));
				val2 = 2f / 3f * val2 + 1f / 3f * (val / (val2 * val2));
				val2.W = w;
				reference2 = val2;
				reference2 = ref Unsafe.Add(ref reference2, 1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Lerp(in Vector256<float> value1, in Vector256<float> value2, in Vector256<float> amount)
	{
		Vector256<float> vector = Avx.Subtract(value2, value1);
		if (Fma.IsSupported)
		{
			return Fma.MultiplyAdd(vector, amount, value1);
		}
		return Avx.Add(Avx.Multiply(vector, amount), value1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Lerp(float value1, float value2, float amount)
	{
		return (value2 - value1) * amount + value1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void Accumulate(ref Vector<uint> accumulator, Vector<byte> values)
	{
		Vector.Widen(values, out var low, out var high);
		Vector.Widen(low, out var low2, out var high2);
		accumulator += low2;
		accumulator += high2;
		Vector.Widen(high, out low2, out high2);
		accumulator += low2;
		accumulator += high2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ReduceSum(Vector128<int> accumulator)
	{
		Vector128<int> vector = Sse2.Add(accumulator, Sse2.Shuffle(accumulator, 245));
		return Sse2.ConvertToInt32(Sse2.Add(vector, Sse2.Shuffle(vector, 238)));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ReduceSum(Vector256<int> accumulator)
	{
		Vector128<int> vector = Sse2.Add(accumulator.GetLower(), accumulator.GetUpper());
		Vector128<int> vector2 = Sse2.Add(vector, Sse2.Shuffle(vector, 245));
		return Sse2.ConvertToInt32(Sse2.Add(vector2, Sse2.Shuffle(vector2, 238)));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ReduceSumArm(Vector128<uint> accumulator)
	{
		if (AdvSimd.Arm64.IsSupported)
		{
			return (int)AdvSimd.Extract(AdvSimd.Arm64.AddAcross(accumulator), 0);
		}
		Vector128<ulong> vector = AdvSimd.AddPairwiseWidening(accumulator);
		return (int)AdvSimd.Extract(AdvSimd.Add(vector.GetLower().AsUInt32(), vector.GetUpper().AsUInt32()), 0);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int EvenReduceSum(Vector128<int> accumulator)
	{
		return Sse2.ConvertToInt32(Sse2.Add(accumulator, Sse2.Shuffle(accumulator, 238)));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int EvenReduceSum(Vector256<int> accumulator)
	{
		Vector128<int> vector = Sse2.Add(accumulator.GetLower(), accumulator.GetUpper());
		return Sse2.ConvertToInt32(Sse2.Add(vector, Sse2.Shuffle(vector, 238)));
	}

	public static uint DivideCeil(uint value, uint divisor)
	{
		return (value + divisor - 1) / divisor;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsOutOfRange(int value, int min, int max)
	{
		return (uint)(value - min) > (uint)(max - min);
	}

	public static nuint VectorCount<TVector>(this Span<byte> span) where TVector : struct
	{
		return (uint)span.Length / (uint)Vector<TVector>.Count;
	}

	public static nuint Vector128Count<TVector>(this Span<byte> span) where TVector : struct
	{
		return (uint)span.Length / (uint)Vector128<TVector>.Count;
	}

	public static nuint Vector128Count<TVector>(this ReadOnlySpan<byte> span) where TVector : struct
	{
		return (uint)span.Length / (uint)Vector128<TVector>.Count;
	}

	public static nuint Vector256Count<TVector>(this Span<byte> span) where TVector : struct
	{
		return (uint)span.Length / (uint)Vector256<TVector>.Count;
	}

	public static nuint Vector256Count<TVector>(this ReadOnlySpan<byte> span) where TVector : struct
	{
		return (uint)span.Length / (uint)Vector256<TVector>.Count;
	}

	public static nuint VectorCount<TVector>(this Span<float> span) where TVector : struct
	{
		return (uint)span.Length / (uint)Vector<TVector>.Count;
	}

	public static nuint Vector128Count<TVector>(this Span<float> span) where TVector : struct
	{
		return (uint)span.Length / (uint)Vector128<TVector>.Count;
	}

	public static nuint Vector256Count<TVector>(this Span<float> span) where TVector : struct
	{
		return (uint)span.Length / (uint)Vector256<TVector>.Count;
	}

	public static nuint Vector256Count<TVector>(int length) where TVector : struct
	{
		return (uint)length / (uint)Vector256<TVector>.Count;
	}
}
