using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.PixelFormats.PixelBlenders;

internal static class PorterDuffFunctions
{
	private const int BlendAlphaControl = 136;

	private const int ShuffleAlphaControl = 255;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Normal(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Normal(Vector256<float> backdrop, Vector256<float> source)
	{
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Multiply(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return backdrop * source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Multiply(Vector256<float> backdrop, Vector256<float> source)
	{
		return Avx.Multiply(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Add(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return Vector4.Min(Vector4.One, backdrop + source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Add(Vector256<float> backdrop, Vector256<float> source)
	{
		return Avx.Min(Vector256.Create(1f), Avx.Add(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Subtract(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return Vector4.Max(Vector4.Zero, backdrop - source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Subtract(Vector256<float> backdrop, Vector256<float> source)
	{
		return Avx.Max(Vector256<float>.Zero, Avx.Subtract(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Screen(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		return Vector4.One - (Vector4.One - backdrop) * (Vector4.One - source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Screen(Vector256<float> backdrop, Vector256<float> source)
	{
		Vector256<float> vector = Vector256.Create(1f);
		return SimdUtils.HwIntrinsics.MultiplyAddNegated(Avx.Subtract(vector, backdrop), Avx.Subtract(vector, source), vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Darken(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return Vector4.Min(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Darken(Vector256<float> backdrop, Vector256<float> source)
	{
		return Avx.Min(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Lighten(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return Vector4.Max(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Lighten(Vector256<float> backdrop, Vector256<float> source)
	{
		return Avx.Max(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Overlay(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		float num = OverlayValueFunction(backdrop.X, source.X);
		float num2 = OverlayValueFunction(backdrop.Y, source.Y);
		float num3 = OverlayValueFunction(backdrop.Z, source.Z);
		return Vector4.Min(Vector4.One, new Vector4(num, num2, num3, 0f));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Overlay(Vector256<float> backdrop, Vector256<float> source)
	{
		Vector256<float> left = OverlayValueFunction(backdrop, source);
		return Avx.Min(Vector256.Create(1f), Avx.Blend(left, Vector256<float>.Zero, 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLight(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		float num = OverlayValueFunction(source.X, backdrop.X);
		float num2 = OverlayValueFunction(source.Y, backdrop.Y);
		float num3 = OverlayValueFunction(source.Z, backdrop.Z);
		return Vector4.Min(Vector4.One, new Vector4(num, num2, num3, 0f));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLight(Vector256<float> backdrop, Vector256<float> source)
	{
		Vector256<float> left = OverlayValueFunction(source, backdrop);
		return Avx.Min(Vector256.Create(1f), Avx.Blend(left, Vector256<float>.Zero, 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float OverlayValueFunction(float backdrop, float source)
	{
		if (!(backdrop <= 0.5f))
		{
			return 1f - 2f * (1f - source) * (1f - backdrop);
		}
		return 2f * backdrop * source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlayValueFunction(Vector256<float> backdrop, Vector256<float> source)
	{
		Vector256<float> vector = Vector256.Create(1f);
		Vector256<float> left = Avx.Multiply(Avx.Add(backdrop, backdrop), source);
		Vector256<float> vector2 = Avx.Subtract(vector, source);
		Vector256<float> right = SimdUtils.HwIntrinsics.MultiplyAddNegated(Avx.Add(vector2, vector2), Avx.Subtract(vector, backdrop), vector);
		Vector256<float> mask = Avx.CompareGreaterThan(backdrop, Vector256.Create(0.5f));
		return Avx.BlendVariable(left, right, mask);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Over(Vector4 destination, Vector4 source, Vector4 blend)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = Numerics.PermuteW(source);
		Vector4 val2 = Numerics.PermuteW(destination);
		Vector4 val3 = val * val2;
		Vector4 val4 = val2 - val3;
		Vector4 val5 = val - val3;
		Vector4 alpha = val4 + val;
		Vector4 source2 = destination * val4 + source * val5 + blend * val3;
		Numerics.UnPremultiply(ref source2, alpha);
		return source2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Over(Vector256<float> destination, Vector256<float> source, Vector256<float> blend)
	{
		Vector256<float> vector = Avx.Permute(source, byte.MaxValue);
		Vector256<float> vector2 = Avx.Permute(destination, byte.MaxValue);
		Vector256<float> vector3 = Avx.Multiply(vector, vector2);
		Vector256<float> vector4 = Avx.Subtract(vector2, vector3);
		Vector256<float> vm = Avx.Subtract(vector, vector3);
		Vector256<float> alpha = Avx.Add(vector4, vector);
		return Numerics.UnPremultiply(SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(destination, vector4), source, vm), blend, vector3), alpha);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Atop(Vector4 destination, Vector4 source, Vector4 blend)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = Numerics.PermuteW(source);
		Vector4 val2 = Numerics.PermuteW(destination);
		Vector4 val3 = val * val2;
		Vector4 val4 = val2 - val3;
		Vector4 alpha = val2;
		Vector4 source2 = destination * val4 + blend * val3;
		Numerics.UnPremultiply(ref source2, alpha);
		return source2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Atop(Vector256<float> destination, Vector256<float> source, Vector256<float> blend)
	{
		Vector256<float> vector = Avx.Permute(destination, byte.MaxValue);
		Vector256<float> right = Avx.Multiply(Avx.Permute(source, byte.MaxValue), vector);
		Vector256<float> vm = Avx.Subtract(vector, right);
		return Numerics.UnPremultiply(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(blend, right), destination, vm), vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 In(Vector4 destination, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = Numerics.PermuteW(source);
		Vector4 val2 = Numerics.PermuteW(destination) * val;
		Vector4 source2 = source * val2;
		Numerics.UnPremultiply(ref source2, val2);
		return source2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> In(Vector256<float> destination, Vector256<float> source)
	{
		Vector256<float> vector = Avx.Permute(Avx.Multiply(source, destination), byte.MaxValue);
		return Numerics.UnPremultiply(Avx.Multiply(source, vector), vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Out(Vector4 destination, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = Numerics.PermuteW(source);
		Vector4 val2 = Numerics.PermuteW(destination);
		Vector4 val3 = (Vector4.One - val2) * val;
		Vector4 source2 = source * val3;
		Numerics.UnPremultiply(ref source2, val3);
		return source2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Out(Vector256<float> destination, Vector256<float> source)
	{
		Vector256<float> vector = Avx.Permute(Avx.Multiply(source, Avx.Subtract(Vector256.Create(1f), destination)), byte.MaxValue);
		return Numerics.UnPremultiply(Avx.Multiply(source, vector), vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 Xor(Vector4 destination, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		Vector4 val = Numerics.PermuteW(source);
		Vector4 val2 = Numerics.PermuteW(destination);
		Vector4 val3 = Vector4.One - val2;
		Vector4 val4 = Vector4.One - val;
		Vector4 alpha = val * val3 + val2 * val4;
		Vector4 source2 = val * source * val3 + val2 * destination * val4;
		Numerics.UnPremultiply(ref source2, alpha);
		return source2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> Xor(Vector256<float> destination, Vector256<float> source)
	{
		Vector256<float> vector = Avx.Shuffle(source, source, byte.MaxValue);
		Vector256<float> vector2 = Avx.Shuffle(destination, destination, byte.MaxValue);
		Vector256<float> left = Vector256.Create(1f);
		Vector256<float> vm = Avx.Subtract(left, vector2);
		Vector256<float> right = Avx.Subtract(left, vector);
		Vector256<float> alpha = SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(vector2, right), vector, vm);
		return Numerics.UnPremultiply(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(Avx.Multiply(vector2, destination), right), Avx.Multiply(vector, source), vm), alpha);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector4 Clear(Vector4 backdrop, Vector4 source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return Vector4.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector256<float> Clear(Vector256<float> backdrop, Vector256<float> source)
	{
		return Vector256<float>.Zero;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalSrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalSrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalSrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, Normal(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalSrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, Normal(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalSrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, Normal(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalSrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, Normal(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalSrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalSrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalSrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalSrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, Normal(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, Normal(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, Normal(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, Normal(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 NormalClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> NormalClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalSrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalSrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalSrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalSrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalSrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalSrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalSrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalSrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalSrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalSrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel NormalXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(NormalXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplySrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplySrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplySrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, Multiply(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplySrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, Multiply(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplySrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, Multiply(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplySrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, Multiply(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplySrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplySrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplySrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplySrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplyDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplyDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplyDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, Multiply(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplyDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, Multiply(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplyDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, Multiply(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplyDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, Multiply(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplyDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplyDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplyDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplyDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplyXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplyXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 MultiplyClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> MultiplyClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplySrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplySrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplySrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplySrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplySrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplySrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplySrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplySrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplySrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplySrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplyDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplyDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplyDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplyDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplyDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplyDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplyDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplyDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplyDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplyDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplyClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplyClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel MultiplyXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(MultiplyXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddSrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddSrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddSrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, Add(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddSrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, Add(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddSrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, Add(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddSrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, Add(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddSrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddSrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddSrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddSrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, Add(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, Add(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, Add(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, Add(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 AddClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> AddClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddSrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddSrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddSrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddSrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddSrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddSrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddSrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddSrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddSrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddSrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel AddXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(AddXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractSrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractSrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractSrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, Subtract(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractSrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, Subtract(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractSrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, Subtract(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractSrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, Subtract(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractSrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractSrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractSrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractSrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, Subtract(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, Subtract(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, Subtract(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, Subtract(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 SubtractClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> SubtractClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractSrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractSrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractSrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractSrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractSrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractSrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractSrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractSrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractSrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractSrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel SubtractXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(SubtractXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenSrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenSrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenSrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, Screen(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenSrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, Screen(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenSrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, Screen(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenSrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, Screen(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenSrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenSrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenSrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenSrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, Screen(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, Screen(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, Screen(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, Screen(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 ScreenClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> ScreenClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenSrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenSrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenSrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenSrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenSrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenSrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenSrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenSrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenSrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenSrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel ScreenXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(ScreenXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenSrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenSrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenSrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, Darken(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenSrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, Darken(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenSrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, Darken(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenSrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, Darken(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenSrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenSrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenSrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenSrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, Darken(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, Darken(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, Darken(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, Darken(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 DarkenClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> DarkenClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenSrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenSrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenSrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenSrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenSrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenSrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenSrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenSrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenSrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenSrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel DarkenXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(DarkenXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenSrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenSrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenSrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, Lighten(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenSrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, Lighten(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenSrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, Lighten(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenSrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, Lighten(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenSrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenSrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenSrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenSrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, Lighten(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, Lighten(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, Lighten(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, Lighten(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 LightenClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> LightenClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenSrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenSrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenSrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenSrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenSrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenSrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenSrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenSrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenSrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenSrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel LightenXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(LightenXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlaySrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlaySrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlaySrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, Overlay(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlaySrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, Overlay(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlaySrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, Overlay(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlaySrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, Overlay(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlaySrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlaySrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlaySrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlaySrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlayDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlayDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlayDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, Overlay(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlayDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, Overlay(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlayDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, Overlay(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlayDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, Overlay(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlayDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlayDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlayDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlayDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlayXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlayXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 OverlayClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> OverlayClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlaySrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlaySrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlaySrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlaySrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlaySrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlaySrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlaySrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlaySrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlaySrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlaySrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlayDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlayDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlayDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlayDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlayDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlayDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlayDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlayDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlayDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlayDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlayClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlayClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel OverlayXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(OverlayXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightSrc(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightSrc(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Avx.Blend(source, Avx.Multiply(source, opacity), 136);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightSrcAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(backdrop, source, HardLight(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightSrcAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(backdrop, source, HardLight(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightSrcOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(backdrop, source, HardLight(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightSrcOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(backdrop, source, HardLight(backdrop, source));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightSrcIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightSrcIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightSrcOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightSrcOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightDest(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightDest(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return backdrop;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightDestAtop(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Atop(source, backdrop, HardLight(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightDestAtop(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Atop(source, backdrop, HardLight(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightDestOver(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Over(source, backdrop, HardLight(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightDestOver(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		source = Avx.Blend(source, Avx.Multiply(source, opacity), 136);
		return Over(source, backdrop, HardLight(source, backdrop));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightDestIn(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return In(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightDestIn(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return In(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightDestOut(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Out(source, backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightDestOut(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Out(Avx.Blend(source, Avx.Multiply(source, opacity), 136), backdrop);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightXor(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Xor(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightXor(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Xor(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector4 HardLightClear(Vector4 backdrop, Vector4 source, float opacity)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		source = Numerics.WithW(source, source * opacity);
		return Clear(backdrop, source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Vector256<float> HardLightClear(Vector256<float> backdrop, Vector256<float> source, Vector256<float> opacity)
	{
		return Clear(backdrop, Avx.Blend(source, Avx.Multiply(source, opacity), 136));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightSrc<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightSrc(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightSrcAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightSrcAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightSrcOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightSrcOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightSrcIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightSrcIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightSrcOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightSrcOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightDest<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightDest(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightDestAtop<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightDestAtop(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightDestOver<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightDestOver(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightDestIn<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightDestIn(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightDestOut<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightDestOut(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightClear<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightClear(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TPixel HardLightXor<TPixel>(TPixel backdrop, TPixel source, float opacity) where TPixel : unmanaged, IPixel<TPixel>
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		opacity = Numerics.Clamp(opacity, 0f, 1f);
		TPixel result = default(TPixel);
		result.FromScaledVector4(HardLightXor(backdrop.ToScaledVector4(), source.ToScaledVector4(), opacity));
		return result;
	}
}
