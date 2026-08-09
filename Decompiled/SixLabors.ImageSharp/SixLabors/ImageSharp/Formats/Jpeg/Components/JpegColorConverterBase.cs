using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;
using SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder;
using SixLabors.ImageSharp.Memory;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

internal abstract class JpegColorConverterBase
{
	internal sealed class CmykArm64 : JpegColorConverterArm64
	{
		public CmykArm64(int precision)
			: base(JpegColorSpace.Cmyk, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector128<float> source3 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector128<float> source4 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			Vector128<float> right = Vector128.Create(1f / (base.MaximumValue * base.MaximumValue));
			nint num = (nint)(uint)values.Component0.Length / (nint)Vector128<float>.Count;
			for (nint num2 = 0; num2 < num; num2++)
			{
				ref Vector128<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector128<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector128<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector128<float> left = Unsafe.Add(ref source4, num2);
				left = AdvSimd.Multiply(left, right);
				reference = AdvSimd.Multiply(reference, left);
				reference2 = AdvSimd.Multiply(reference2, left);
				reference3 = AdvSimd.Multiply(reference3, left);
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ConvertFromRgb(in values, base.MaximumValue, rLane, gLane, bLane);
		}

		public static void ConvertFromRgb(in ComponentValues values, float maxValue, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector128<float> source3 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector128<float> source4 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			ref Vector128<float> source5 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(rLane));
			ref Vector128<float> source6 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(gLane));
			ref Vector128<float> source7 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(bLane));
			Vector128<float> vector = Vector128.Create(maxValue);
			nint num = (nint)(uint)values.Component0.Length / (nint)Vector128<float>.Count;
			for (nint num2 = 0; num2 < num; num2++)
			{
				Vector128<float> left = AdvSimd.Subtract(vector, Unsafe.Add(ref source5, num2));
				Vector128<float> left2 = AdvSimd.Subtract(vector, Unsafe.Add(ref source6, num2));
				Vector128<float> vector2 = AdvSimd.Subtract(vector, Unsafe.Add(ref source7, num2));
				Vector128<float> vector3 = AdvSimd.Min(left, AdvSimd.Min(left2, vector2));
				Vector128<float> right = AdvSimd.Not(AdvSimd.CompareEqual(vector3, vector));
				left = AdvSimd.And(AdvSimd.Arm64.Divide(AdvSimd.Subtract(left, vector3), AdvSimd.Subtract(vector, vector3)), right);
				left2 = AdvSimd.And(AdvSimd.Arm64.Divide(AdvSimd.Subtract(left2, vector3), AdvSimd.Subtract(vector, vector3)), right);
				vector2 = AdvSimd.And(AdvSimd.Arm64.Divide(AdvSimd.Subtract(vector2, vector3), AdvSimd.Subtract(vector, vector3)), right);
				Unsafe.Add(ref source, num2) = AdvSimd.Subtract(vector, AdvSimd.Multiply(left, vector));
				Unsafe.Add(ref source2, num2) = AdvSimd.Subtract(vector, AdvSimd.Multiply(left2, vector));
				Unsafe.Add(ref source3, num2) = AdvSimd.Subtract(vector, AdvSimd.Multiply(vector2, vector));
				Unsafe.Add(ref source4, num2) = AdvSimd.Subtract(vector, vector3);
			}
		}
	}

	internal sealed class CmykAvx : JpegColorConverterAvx
	{
		public CmykAvx(int precision)
			: base(JpegColorSpace.Cmyk, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector256<float> source4 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			Vector256<float> right = Vector256.Create(1f / (base.MaximumValue * base.MaximumValue));
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector256<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector256<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector256<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector256<float> left = Unsafe.Add(ref source4, num2);
				left = Avx.Multiply(left, right);
				reference = Avx.Multiply(reference, left);
				reference2 = Avx.Multiply(reference2, left);
				reference3 = Avx.Multiply(reference3, left);
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ConvertFromRgb(in values, base.MaximumValue, rLane, gLane, bLane);
		}

		public static void ConvertFromRgb(in ComponentValues values, float maxValue, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector256<float> source4 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			ref Vector256<float> source5 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(rLane));
			ref Vector256<float> source6 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(gLane));
			ref Vector256<float> source7 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(bLane));
			Vector256<float> vector = Vector256.Create(maxValue);
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector256<float> left = Avx.Subtract(vector, Unsafe.Add(ref source5, num2));
				Vector256<float> left2 = Avx.Subtract(vector, Unsafe.Add(ref source6, num2));
				Vector256<float> vector2 = Avx.Subtract(vector, Unsafe.Add(ref source7, num2));
				Vector256<float> vector3 = Avx.Min(left, Avx.Min(left2, vector2));
				Vector256<float> right = Avx.CompareNotEqual(vector3, vector);
				left = Avx.And(Avx.Divide(Avx.Subtract(left, vector3), Avx.Subtract(vector, vector3)), right);
				left2 = Avx.And(Avx.Divide(Avx.Subtract(left2, vector3), Avx.Subtract(vector, vector3)), right);
				vector2 = Avx.And(Avx.Divide(Avx.Subtract(vector2, vector3), Avx.Subtract(vector, vector3)), right);
				Unsafe.Add(ref source, num2) = Avx.Subtract(vector, Avx.Multiply(left, vector));
				Unsafe.Add(ref source2, num2) = Avx.Subtract(vector, Avx.Multiply(left2, vector));
				Unsafe.Add(ref source3, num2) = Avx.Subtract(vector, Avx.Multiply(vector2, vector));
				Unsafe.Add(ref source4, num2) = Avx.Subtract(vector, vector3);
			}
		}
	}

	internal sealed class CmykScalar : JpegColorConverterScalar
	{
		public CmykScalar(int precision)
			: base(JpegColorSpace.Cmyk, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ConvertToRgbInplace(in values, base.MaximumValue);
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			ConvertFromRgb(in values, base.MaximumValue, r, g, b);
		}

		public static void ConvertToRgbInplace(in ComponentValues values, float maxValue)
		{
			Span<float> component = values.Component0;
			Span<float> component2 = values.Component1;
			Span<float> component3 = values.Component2;
			Span<float> component4 = values.Component3;
			float num = 1f / (maxValue * maxValue);
			for (int i = 0; i < component.Length; i++)
			{
				float num2 = component[i];
				float num3 = component2[i];
				float num4 = component3[i];
				float num5 = component4[i];
				num5 *= num;
				component[i] = num2 * num5;
				component2[i] = num3 * num5;
				component3[i] = num4 * num5;
			}
		}

		public static void ConvertFromRgb(in ComponentValues values, float maxValue, Span<float> r, Span<float> g, Span<float> b)
		{
			Span<float> component = values.Component0;
			Span<float> component2 = values.Component1;
			Span<float> component3 = values.Component2;
			Span<float> component4 = values.Component3;
			for (int i = 0; i < component.Length; i++)
			{
				float num = 255f - r[i];
				float num2 = 255f - g[i];
				float num3 = 255f - b[i];
				float num4 = MathF.Min(MathF.Min(num, num2), num3);
				if (num4 >= 255f)
				{
					num = 0f;
					num2 = 0f;
					num3 = 0f;
				}
				else
				{
					num = (num - num4) / (255f - num4);
					num2 = (num2 - num4) / (255f - num4);
					num3 = (num3 - num4) / (255f - num4);
				}
				component[i] = maxValue - num * maxValue;
				component2[i] = maxValue - num2 * maxValue;
				component3[i] = maxValue - num3 * maxValue;
				component4[i] = maxValue - num4;
			}
		}
	}

	internal sealed class CmykVector : JpegColorConverterVector
	{
		public CmykVector(int precision)
			: base(JpegColorSpace.Cmyk, precision)
		{
		}

		protected override void ConvertToRgbInplaceVectorized(in ComponentValues values)
		{
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector<float> source2 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector<float> source3 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector<float> source4 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			Vector<float> vector = new Vector<float>(1f / (base.MaximumValue * base.MaximumValue));
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector<float> vector2 = Unsafe.Add(ref source4, num2);
				vector2 *= vector;
				reference *= vector2;
				reference2 *= vector2;
				reference3 *= vector2;
			}
		}

		protected override void ConvertToRgbInplaceScalarRemainder(in ComponentValues values)
		{
			CmykScalar.ConvertToRgbInplace(in values, base.MaximumValue);
		}

		protected override void ConvertFromRgbVectorized(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			ConvertFromRgbInplaceVectorized(in values, base.MaximumValue, r, g, b);
		}

		protected override void ConvertFromRgbScalarRemainder(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			ConvertFromRgbInplaceRemainder(in values, base.MaximumValue, r, g, b);
		}

		public static void ConvertFromRgbInplaceVectorized(in ComponentValues values, float maxValue, Span<float> r, Span<float> g, Span<float> b)
		{
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector<float> source2 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector<float> source3 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector<float> source4 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			ref Vector<float> source5 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(r));
			ref Vector<float> source6 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(g));
			ref Vector<float> source7 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(b));
			Vector<float> vector = new Vector<float>(maxValue);
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector<float> vector2 = vector - Unsafe.Add(ref source5, num2);
				Vector<float> vector3 = vector - Unsafe.Add(ref source6, num2);
				Vector<float> vector4 = vector - Unsafe.Add(ref source7, num2);
				Vector<float> vector5 = Vector.Min(vector2, Vector.Min(vector3, vector4));
				Vector<int> vector6 = Vector.Equals(vector5, vector);
				vector2 = Vector.AndNot((vector2 - vector5) / (vector - vector5), Vector.As<int, float>(vector6));
				vector3 = Vector.AndNot((vector3 - vector5) / (vector - vector5), Vector.As<int, float>(vector6));
				vector4 = Vector.AndNot((vector4 - vector5) / (vector - vector5), Vector.As<int, float>(vector6));
				Unsafe.Add(ref source, num2) = vector - vector2 * vector;
				Unsafe.Add(ref source2, num2) = vector - vector3 * vector;
				Unsafe.Add(ref source3, num2) = vector - vector4 * vector;
				Unsafe.Add(ref source4, num2) = vector - vector5;
			}
		}

		public static void ConvertFromRgbInplaceRemainder(in ComponentValues values, float maxValue, Span<float> r, Span<float> g, Span<float> b)
		{
			CmykScalar.ConvertFromRgb(in values, maxValue, r, g, b);
		}
	}

	internal sealed class GrayscaleArm : JpegColorConverterArm
	{
		public GrayscaleArm(int precision)
			: base(JpegColorSpace.Grayscale, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			Vector128<float> right = Vector128.Create(1f / base.MaximumValue);
			nuint num = values.Component0.Vector128Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector128<float> reference = ref Unsafe.Add(ref source, num2);
				reference = AdvSimd.Multiply(reference, right);
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(rLane));
			ref Vector128<float> source3 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(gLane));
			ref Vector128<float> source4 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(bLane));
			Vector128<float> vm = Vector128.Create(0.299f);
			Vector128<float> vm2 = Vector128.Create(0.587f);
			Vector128<float> left = Vector128.Create(0.114f);
			nuint num = values.Component0.Vector128Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector128<float> reference = ref Unsafe.Add(ref source2, num2);
				ref Vector128<float> reference2 = ref Unsafe.Add(ref source3, num2);
				ref Vector128<float> reference3 = ref Unsafe.Add(ref source4, num2);
				Unsafe.Add(ref source, num2) = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(AdvSimd.Multiply(left, reference3), vm2, reference2), vm, reference);
			}
		}
	}

	internal sealed class GrayscaleAvx : JpegColorConverterAvx
	{
		public GrayscaleAvx(int precision)
			: base(JpegColorSpace.Grayscale, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			Vector256<float> right = Vector256.Create(1f / base.MaximumValue);
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector256<float> reference = ref Unsafe.Add(ref source, num2);
				reference = Avx.Multiply(reference, right);
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(rLane));
			ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(gLane));
			ref Vector256<float> source4 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(bLane));
			Vector256<float> vm = Vector256.Create(0.299f);
			Vector256<float> vm2 = Vector256.Create(0.587f);
			Vector256<float> left = Vector256.Create(0.114f);
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector256<float> reference = ref Unsafe.Add(ref source2, num2);
				ref Vector256<float> reference2 = ref Unsafe.Add(ref source3, num2);
				ref Vector256<float> reference3 = ref Unsafe.Add(ref source4, num2);
				Unsafe.Add(ref source, num2) = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(left, reference3), vm2, reference2), vm, reference);
			}
		}
	}

	internal sealed class GrayscaleScalar : JpegColorConverterScalar
	{
		public GrayscaleScalar(int precision)
			: base(JpegColorSpace.Grayscale, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ConvertToRgbInplace(values.Component0, base.MaximumValue);
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			ConvertCoreInplaceFromRgb(in values, r, g, b);
		}

		internal static void ConvertToRgbInplace(Span<float> values, float maxValue)
		{
			ref float reference = ref MemoryMarshal.GetReference<float>(values);
			float num = 1f / maxValue;
			for (nuint num2 = 0u; num2 < (uint)values.Length; num2++)
			{
				Unsafe.Add(ref reference, num2) *= num;
			}
		}

		internal static void ConvertCoreInplaceFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			Span<float> component = values.Component0;
			for (int i = 0; i < component.Length; i++)
			{
				float num = 0.299f * rLane[i] + 0.587f * gLane[i] + 0.114f * bLane[i];
				component[i] = num;
			}
		}
	}

	internal sealed class GrayScaleVector : JpegColorConverterVector
	{
		public GrayScaleVector(int precision)
			: base(JpegColorSpace.Grayscale, precision)
		{
		}

		protected override void ConvertToRgbInplaceVectorized(in ComponentValues values)
		{
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			Vector<float> vector = new Vector<float>(1f / base.MaximumValue);
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Unsafe.Add(ref source, num2) *= vector;
			}
		}

		protected override void ConvertToRgbInplaceScalarRemainder(in ComponentValues values)
		{
			GrayscaleScalar.ConvertToRgbInplace(values.Component0, base.MaximumValue);
		}

		protected override void ConvertFromRgbVectorized(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector<float> source2 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(rLane));
			Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(gLane));
			Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(bLane));
			Vector<float> vector = new Vector<float>(0.299f);
			Vector<float> vector2 = new Vector<float>(0.587f);
			Vector<float> vector3 = new Vector<float>(0.114f);
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector<float> vector4 = Unsafe.Add(ref source2, num2);
				Vector<float> vector5 = Unsafe.Add(ref source2, num2);
				Vector<float> vector6 = Unsafe.Add(ref source2, num2);
				Unsafe.Add(ref source, num2) = vector * vector4 + vector2 * vector5 + vector3 * vector6;
			}
		}

		protected override void ConvertFromRgbScalarRemainder(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			GrayscaleScalar.ConvertCoreInplaceFromRgb(in values, r, g, b);
		}
	}

	internal sealed class RgbArm : JpegColorConverterArm
	{
		public RgbArm(int precision)
			: base(JpegColorSpace.RGB, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector128<float> source3 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector128<float> right = Vector128.Create(1f / base.MaximumValue);
			nuint num = values.Component0.Vector128Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector128<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector128<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector128<float> reference3 = ref Unsafe.Add(ref source3, num2);
				reference = AdvSimd.Multiply(reference, right);
				reference2 = AdvSimd.Multiply(reference2, right);
				reference3 = AdvSimd.Multiply(reference3, right);
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			rLane.CopyTo(values.Component0);
			gLane.CopyTo(values.Component1);
			bLane.CopyTo(values.Component2);
		}
	}

	internal sealed class RgbAvx : JpegColorConverterAvx
	{
		public RgbAvx(int precision)
			: base(JpegColorSpace.RGB, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector256<float> right = Vector256.Create(1f / base.MaximumValue);
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector256<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector256<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector256<float> reference3 = ref Unsafe.Add(ref source3, num2);
				reference = Avx.Multiply(reference, right);
				reference2 = Avx.Multiply(reference2, right);
				reference3 = Avx.Multiply(reference3, right);
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			rLane.CopyTo(values.Component0);
			gLane.CopyTo(values.Component1);
			bLane.CopyTo(values.Component2);
		}
	}

	internal sealed class RgbScalar : JpegColorConverterScalar
	{
		public RgbScalar(int precision)
			: base(JpegColorSpace.RGB, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ConvertToRgbInplace(values, base.MaximumValue);
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			ConvertFromRgb(values, r, g, b);
		}

		internal static void ConvertToRgbInplace(ComponentValues values, float maxValue)
		{
			GrayscaleScalar.ConvertToRgbInplace(values.Component0, maxValue);
			GrayscaleScalar.ConvertToRgbInplace(values.Component1, maxValue);
			GrayscaleScalar.ConvertToRgbInplace(values.Component2, maxValue);
		}

		internal static void ConvertFromRgb(ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			r.CopyTo(values.Component0);
			g.CopyTo(values.Component1);
			b.CopyTo(values.Component2);
		}
	}

	internal sealed class RgbVector : JpegColorConverterVector
	{
		public RgbVector(int precision)
			: base(JpegColorSpace.RGB, precision)
		{
		}

		protected override void ConvertToRgbInplaceVectorized(in ComponentValues values)
		{
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector<float> source2 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector<float> source3 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector<float> vector = new Vector<float>(1f / base.MaximumValue);
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector<float> reference3 = ref Unsafe.Add(ref source3, num2);
				reference *= vector;
				reference2 *= vector;
				reference3 *= vector;
			}
		}

		protected override void ConvertToRgbInplaceScalarRemainder(in ComponentValues values)
		{
			RgbScalar.ConvertToRgbInplace(values, base.MaximumValue);
		}

		protected override void ConvertFromRgbVectorized(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			r.CopyTo(values.Component0);
			g.CopyTo(values.Component1);
			b.CopyTo(values.Component2);
		}

		protected override void ConvertFromRgbScalarRemainder(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			RgbScalar.ConvertFromRgb(values, r, g, b);
		}
	}

	internal sealed class YCbCrArm : JpegColorConverterArm
	{
		public YCbCrArm(int precision)
			: base(JpegColorSpace.YCbCr, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector128<float> source3 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector128<float> right = Vector128.Create(0f - base.HalfValue);
			Vector128<float> right2 = Vector128.Create(1f / base.MaximumValue);
			Vector128<float> vm = Vector128.Create(1.402f);
			Vector128<float> vm2 = Vector128.Create(-0.3441363f);
			Vector128<float> vm3 = Vector128.Create(-0.7141363f);
			Vector128<float> vm4 = Vector128.Create(1.772f);
			nuint num = (uint)values.Component0.Length / (uint)Vector128<float>.Count;
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector128<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector128<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector128<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector128<float> va = reference;
				Vector128<float> vm5 = AdvSimd.Add(reference2, right);
				Vector128<float> vm6 = AdvSimd.Add(reference3, right);
				Vector128<float> value = SimdUtils.HwIntrinsics.MultiplyAdd(va, vm6, vm);
				Vector128<float> value2 = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(va, vm5, vm2), vm6, vm3);
				Vector128<float> value3 = SimdUtils.HwIntrinsics.MultiplyAdd(va, vm5, vm4);
				value = AdvSimd.Multiply(AdvSimd.RoundToNearest(value), right2);
				value2 = AdvSimd.Multiply(AdvSimd.RoundToNearest(value2), right2);
				value3 = AdvSimd.Multiply(AdvSimd.RoundToNearest(value3), right2);
				reference = value;
				reference2 = value2;
				reference3 = value3;
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector128<float> source3 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector128<float> source4 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(rLane));
			ref Vector128<float> source5 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(gLane));
			ref Vector128<float> source6 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(bLane));
			Vector128<float> left = Vector128.Create(base.HalfValue);
			Vector128<float> vm = Vector128.Create(0.299f);
			Vector128<float> vm2 = Vector128.Create(0.587f);
			Vector128<float> left2 = Vector128.Create(0.114f);
			Vector128<float> vm3 = Vector128.Create(-0.168736f);
			Vector128<float> vm4 = Vector128.Create(-0.331264f);
			Vector128<float> vm5 = Vector128.Create(-0.418688f);
			Vector128<float> left3 = Vector128.Create(-0.081312f);
			Vector128<float> vector = Vector128.Create(0.5f);
			nuint num = (uint)values.Component0.Length / (uint)Vector128<float>.Count;
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector128<float> vm6 = Unsafe.Add(ref source4, num2);
				Vector128<float> vm7 = Unsafe.Add(ref source5, num2);
				Vector128<float> right = Unsafe.Add(ref source6, num2);
				Vector128<float> vector2 = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(AdvSimd.Multiply(left2, right), vm2, vm7), vm, vm6);
				Vector128<float> vector3 = AdvSimd.Add(left, SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(AdvSimd.Multiply(vector, right), vm4, vm7), vm3, vm6));
				Vector128<float> vector4 = AdvSimd.Add(left, SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(AdvSimd.Multiply(left3, right), vm5, vm7), vector, vm6));
				Unsafe.Add(ref source, num2) = vector2;
				Unsafe.Add(ref source2, num2) = vector3;
				Unsafe.Add(ref source3, num2) = vector4;
			}
		}
	}

	internal sealed class YCbCrAvx : JpegColorConverterAvx
	{
		public YCbCrAvx(int precision)
			: base(JpegColorSpace.YCbCr, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector256<float> right = Vector256.Create(0f - base.HalfValue);
			Vector256<float> right2 = Vector256.Create(1f / base.MaximumValue);
			Vector256<float> vm = Vector256.Create(1.402f);
			Vector256<float> vm2 = Vector256.Create(-0.3441363f);
			Vector256<float> vm3 = Vector256.Create(-0.7141363f);
			Vector256<float> vm4 = Vector256.Create(1.772f);
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector256<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector256<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector256<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector256<float> va = reference;
				Vector256<float> vm5 = Avx.Add(reference2, right);
				Vector256<float> vm6 = Avx.Add(reference3, right);
				Vector256<float> value = SimdUtils.HwIntrinsics.MultiplyAdd(va, vm6, vm);
				Vector256<float> value2 = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(va, vm5, vm2), vm6, vm3);
				Vector256<float> value3 = SimdUtils.HwIntrinsics.MultiplyAdd(va, vm5, vm4);
				value = Avx.Multiply(Avx.RoundToNearestInteger(value), right2);
				value2 = Avx.Multiply(Avx.RoundToNearestInteger(value2), right2);
				value3 = Avx.Multiply(Avx.RoundToNearestInteger(value3), right2);
				reference = value;
				reference2 = value2;
				reference3 = value3;
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector256<float> source4 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(rLane));
			ref Vector256<float> source5 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(gLane));
			ref Vector256<float> source6 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(bLane));
			Vector256<float> left = Vector256.Create(base.HalfValue);
			Vector256<float> vm = Vector256.Create(0.299f);
			Vector256<float> vm2 = Vector256.Create(0.587f);
			Vector256<float> left2 = Vector256.Create(0.114f);
			Vector256<float> vm3 = Vector256.Create(-0.168736f);
			Vector256<float> vm4 = Vector256.Create(-0.331264f);
			Vector256<float> vm5 = Vector256.Create(-0.418688f);
			Vector256<float> left3 = Vector256.Create(-0.081312f);
			Vector256<float> vector = Vector256.Create(0.5f);
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector256<float> vm6 = Unsafe.Add(ref source4, num2);
				Vector256<float> vm7 = Unsafe.Add(ref source5, num2);
				Vector256<float> right = Unsafe.Add(ref source6, num2);
				Vector256<float> vector2 = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(left2, right), vm2, vm7), vm, vm6);
				Vector256<float> vector3 = Avx.Add(left, SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(vector, right), vm4, vm7), vm3, vm6));
				Vector256<float> vector4 = Avx.Add(left, SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(left3, right), vm5, vm7), vector, vm6));
				Unsafe.Add(ref source, num2) = vector2;
				Unsafe.Add(ref source2, num2) = vector3;
				Unsafe.Add(ref source3, num2) = vector4;
			}
		}
	}

	internal sealed class YCbCrScalar : JpegColorConverterScalar
	{
		internal const float RCrMult = 1.402f;

		internal const float GCbMult = 0.3441363f;

		internal const float GCrMult = 0.7141363f;

		internal const float BCbMult = 1.772f;

		public YCbCrScalar(int precision)
			: base(JpegColorSpace.YCbCr, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ConvertToRgbInplace(in values, base.MaximumValue, base.HalfValue);
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			ConvertFromRgb(in values, base.HalfValue, r, g, b);
		}

		public static void ConvertToRgbInplace(in ComponentValues values, float maxValue, float halfValue)
		{
			Span<float> component = values.Component0;
			Span<float> component2 = values.Component1;
			Span<float> component3 = values.Component2;
			float num = 1f / maxValue;
			for (int i = 0; i < component.Length; i++)
			{
				float num2 = component[i];
				float num3 = component2[i] - halfValue;
				float num4 = component3[i] - halfValue;
				component[i] = MathF.Round(num2 + 1.402f * num4, MidpointRounding.AwayFromZero) * num;
				component2[i] = MathF.Round(num2 - 0.3441363f * num3 - 0.7141363f * num4, MidpointRounding.AwayFromZero) * num;
				component3[i] = MathF.Round(num2 + 1.772f * num3, MidpointRounding.AwayFromZero) * num;
			}
		}

		public static void ConvertFromRgb(in ComponentValues values, float halfValue, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			Span<float> component = values.Component0;
			Span<float> component2 = values.Component1;
			Span<float> component3 = values.Component2;
			for (int i = 0; i < component.Length; i++)
			{
				float num = rLane[i];
				float num2 = gLane[i];
				float num3 = bLane[i];
				component[i] = 0.299f * num + 0.587f * num2 + 0.114f * num3;
				component2[i] = halfValue - 0.168736f * num - 0.331264f * num2 + 0.5f * num3;
				component3[i] = halfValue + 0.5f * num - 0.418688f * num2 - 0.081312f * num3;
			}
		}
	}

	internal sealed class YCbCrVector : JpegColorConverterVector
	{
		public YCbCrVector(int precision)
			: base(JpegColorSpace.YCbCr, precision)
		{
		}

		protected override void ConvertToRgbInplaceVectorized(in ComponentValues values)
		{
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector<float> source2 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector<float> source3 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector<float> vector = new Vector<float>(0f - base.HalfValue);
			Vector<float> vector2 = new Vector<float>(1f / base.MaximumValue);
			Vector<float> vector3 = new Vector<float>(1.402f);
			Vector<float> vector4 = new Vector<float>(-0.3441363f);
			Vector<float> vector5 = new Vector<float>(-0.7141363f);
			Vector<float> vector6 = new Vector<float>(1.772f);
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector<float> vector7 = Unsafe.Add(ref source, num2);
				Vector<float> vector8 = Unsafe.Add(ref source2, num2) + vector;
				Vector<float> vector9 = Unsafe.Add(ref source3, num2) + vector;
				Vector<float> v = vector7 + vector9 * vector3;
				Vector<float> v2 = vector7 + vector8 * vector4 + vector9 * vector5;
				Vector<float> v3 = vector7 + vector8 * vector6;
				v = v.FastRound();
				v2 = v2.FastRound();
				v3 = v3.FastRound();
				v *= vector2;
				v2 *= vector2;
				v3 *= vector2;
				reference = v;
				reference2 = v2;
				reference3 = v3;
			}
		}

		protected override void ConvertToRgbInplaceScalarRemainder(in ComponentValues values)
		{
			YCbCrScalar.ConvertToRgbInplace(in values, base.MaximumValue, base.HalfValue);
		}

		protected override void ConvertFromRgbVectorized(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector<float> source2 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector<float> source3 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector<float> source4 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(rLane));
			ref Vector<float> source5 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(gLane));
			ref Vector<float> source6 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(bLane));
			Vector<float> vector = new Vector<float>(base.HalfValue);
			Vector<float> vector2 = new Vector<float>(0.299f);
			Vector<float> vector3 = new Vector<float>(0.587f);
			Vector<float> vector4 = new Vector<float>(0.114f);
			Vector<float> vector5 = new Vector<float>(0.168736f);
			Vector<float> vector6 = new Vector<float>(0.331264f);
			Vector<float> vector7 = new Vector<float>(0.5f);
			Vector<float> vector8 = new Vector<float>(0.5f);
			Vector<float> vector9 = new Vector<float>(0.418688f);
			Vector<float> vector10 = new Vector<float>(0.081312f);
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector<float> vector11 = Unsafe.Add(ref source4, num2);
				Vector<float> vector12 = Unsafe.Add(ref source5, num2);
				Vector<float> vector13 = Unsafe.Add(ref source6, num2);
				Unsafe.Add(ref source, num2) = vector2 * vector11 + vector3 * vector12 + vector4 * vector13;
				Unsafe.Add(ref source2, num2) = vector - vector5 * vector11 - vector6 * vector12 + vector7 * vector13;
				Unsafe.Add(ref source3, num2) = vector + vector8 * vector11 - vector9 * vector12 - vector10 * vector13;
			}
		}

		protected override void ConvertFromRgbScalarRemainder(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			YCbCrScalar.ConvertFromRgb(in values, base.HalfValue, r, g, b);
		}
	}

	internal sealed class YccKArm64 : JpegColorConverterArm64
	{
		public YccKArm64(int precision)
			: base(JpegColorSpace.Ycck, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector128<float> source3 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector128<float> source4 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			Vector128<float> right = Vector128.Create(0f - base.HalfValue);
			Vector128<float> right2 = Vector128.Create(1f / (base.MaximumValue * base.MaximumValue));
			Vector128<float> left = Vector128.Create(base.MaximumValue);
			Vector128<float> vm = Vector128.Create(1.402f);
			Vector128<float> vm2 = Vector128.Create(-0.3441363f);
			Vector128<float> vm3 = Vector128.Create(-0.7141363f);
			Vector128<float> vm4 = Vector128.Create(1.772f);
			nuint num = (uint)values.Component0.Length / (uint)Vector128<float>.Count;
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector128<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector128<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector128<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector128<float> va = reference;
				Vector128<float> vm5 = AdvSimd.Add(reference2, right);
				Vector128<float> vm6 = AdvSimd.Add(reference3, right);
				Vector128<float> right3 = AdvSimd.Multiply(Unsafe.Add(ref source4, num2), right2);
				Vector128<float> value = SimdUtils.HwIntrinsics.MultiplyAdd(va, vm6, vm);
				Vector128<float> value2 = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(va, vm5, vm2), vm6, vm3);
				Vector128<float> value3 = SimdUtils.HwIntrinsics.MultiplyAdd(va, vm5, vm4);
				value = AdvSimd.Subtract(left, AdvSimd.RoundToNearest(value));
				value2 = AdvSimd.Subtract(left, AdvSimd.RoundToNearest(value2));
				value3 = AdvSimd.Subtract(left, AdvSimd.RoundToNearest(value3));
				value = AdvSimd.Multiply(value, right3);
				value2 = AdvSimd.Multiply(value2, right3);
				value3 = AdvSimd.Multiply(value3, right3);
				reference = value;
				reference2 = value2;
				reference3 = value3;
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			CmykArm64.ConvertFromRgb(in values, base.MaximumValue, rLane, gLane, bLane);
			ref Vector128<float> source = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector128<float> source2 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector128<float> source3 = ref Unsafe.As<float, Vector128<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector128<float> left = Vector128.Create(base.MaximumValue);
			Vector128<float> left2 = Vector128.Create(base.HalfValue);
			Vector128<float> vm = Vector128.Create(0.299f);
			Vector128<float> vm2 = Vector128.Create(0.587f);
			Vector128<float> left3 = Vector128.Create(0.114f);
			Vector128<float> vm3 = Vector128.Create(-0.168736f);
			Vector128<float> vm4 = Vector128.Create(-0.331264f);
			Vector128<float> vm5 = Vector128.Create(-0.418688f);
			Vector128<float> left4 = Vector128.Create(-0.081312f);
			Vector128<float> vector = Vector128.Create(0.5f);
			nuint num = (uint)values.Component0.Length / (uint)Vector128<float>.Count;
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector128<float> vm6 = AdvSimd.Subtract(left, Unsafe.Add(ref source, num2));
				Vector128<float> vm7 = AdvSimd.Subtract(left, Unsafe.Add(ref source2, num2));
				Vector128<float> right = AdvSimd.Subtract(left, Unsafe.Add(ref source3, num2));
				Vector128<float> vector2 = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(AdvSimd.Multiply(left3, right), vm2, vm7), vm, vm6);
				Vector128<float> vector3 = AdvSimd.Add(left2, SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(AdvSimd.Multiply(vector, right), vm4, vm7), vm3, vm6));
				Vector128<float> vector4 = AdvSimd.Add(left2, SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(AdvSimd.Multiply(left4, right), vm5, vm7), vector, vm6));
				Unsafe.Add(ref source, num2) = vector2;
				Unsafe.Add(ref source2, num2) = vector3;
				Unsafe.Add(ref source3, num2) = vector4;
			}
		}
	}

	internal sealed class YccKAvx : JpegColorConverterAvx
	{
		public YccKAvx(int precision)
			: base(JpegColorSpace.Ycck, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector256<float> source4 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			Vector256<float> right = Vector256.Create(0f - base.HalfValue);
			Vector256<float> right2 = Vector256.Create(1f / (base.MaximumValue * base.MaximumValue));
			Vector256<float> left = Vector256.Create(base.MaximumValue);
			Vector256<float> vm = Vector256.Create(1.402f);
			Vector256<float> vm2 = Vector256.Create(-0.3441363f);
			Vector256<float> vm3 = Vector256.Create(-0.7141363f);
			Vector256<float> vm4 = Vector256.Create(1.772f);
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector256<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector256<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector256<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector256<float> va = reference;
				Vector256<float> vm5 = Avx.Add(reference2, right);
				Vector256<float> vm6 = Avx.Add(reference3, right);
				Vector256<float> right3 = Avx.Multiply(Unsafe.Add(ref source4, num2), right2);
				Vector256<float> value = SimdUtils.HwIntrinsics.MultiplyAdd(va, vm6, vm);
				Vector256<float> value2 = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(va, vm5, vm2), vm6, vm3);
				Vector256<float> value3 = SimdUtils.HwIntrinsics.MultiplyAdd(va, vm5, vm4);
				value = Avx.Subtract(left, Avx.RoundToNearestInteger(value));
				value2 = Avx.Subtract(left, Avx.RoundToNearestInteger(value2));
				value3 = Avx.Subtract(left, Avx.RoundToNearestInteger(value3));
				value = Avx.Multiply(value, right3);
				value2 = Avx.Multiply(value2, right3);
				value3 = Avx.Multiply(value3, right3);
				reference = value;
				reference2 = value2;
				reference3 = value3;
			}
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			CmykAvx.ConvertFromRgb(in values, base.MaximumValue, rLane, gLane, bLane);
			ref Vector256<float> source = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector256<float> source2 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector256<float> source3 = ref Unsafe.As<float, Vector256<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector256<float> left = Vector256.Create(base.MaximumValue);
			Vector256<float> left2 = Vector256.Create(base.HalfValue);
			Vector256<float> vm = Vector256.Create(0.299f);
			Vector256<float> vm2 = Vector256.Create(0.587f);
			Vector256<float> left3 = Vector256.Create(0.114f);
			Vector256<float> vm3 = Vector256.Create(-0.168736f);
			Vector256<float> vm4 = Vector256.Create(-0.331264f);
			Vector256<float> vm5 = Vector256.Create(-0.418688f);
			Vector256<float> left4 = Vector256.Create(-0.081312f);
			Vector256<float> vector = Vector256.Create(0.5f);
			nuint num = values.Component0.Vector256Count<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector256<float> vm6 = Avx.Subtract(left, Unsafe.Add(ref source, num2));
				Vector256<float> vm7 = Avx.Subtract(left, Unsafe.Add(ref source2, num2));
				Vector256<float> right = Avx.Subtract(left, Unsafe.Add(ref source3, num2));
				Vector256<float> vector2 = SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(left3, right), vm2, vm7), vm, vm6);
				Vector256<float> vector3 = Avx.Add(left2, SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(vector, right), vm4, vm7), vm3, vm6));
				Vector256<float> vector4 = Avx.Add(left2, SimdUtils.HwIntrinsics.MultiplyAdd(SimdUtils.HwIntrinsics.MultiplyAdd(Avx.Multiply(left4, right), vm5, vm7), vector, vm6));
				Unsafe.Add(ref source, num2) = vector2;
				Unsafe.Add(ref source2, num2) = vector3;
				Unsafe.Add(ref source3, num2) = vector4;
			}
		}
	}

	internal sealed class YccKScalar : JpegColorConverterScalar
	{
		internal const float RCrMult = 1.402f;

		internal const float GCbMult = 0.3441363f;

		internal const float GCrMult = 0.7141363f;

		internal const float BCbMult = 1.772f;

		public YccKScalar(int precision)
			: base(JpegColorSpace.Ycck, precision)
		{
		}

		public override void ConvertToRgbInplace(in ComponentValues values)
		{
			ConvertToRgpInplace(in values, base.MaximumValue, base.HalfValue);
		}

		public override void ConvertFromRgb(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			ConvertFromRgb(in values, base.HalfValue, base.MaximumValue, r, g, b);
		}

		public static void ConvertToRgpInplace(in ComponentValues values, float maxValue, float halfValue)
		{
			Span<float> component = values.Component0;
			Span<float> component2 = values.Component1;
			Span<float> component3 = values.Component2;
			Span<float> component4 = values.Component3;
			float num = 1f / (maxValue * maxValue);
			for (int i = 0; i < values.Component0.Length; i++)
			{
				float num2 = component[i];
				float num3 = component2[i] - halfValue;
				float num4 = component3[i] - halfValue;
				float num5 = component4[i] * num;
				component[i] = (maxValue - MathF.Round(num2 + 1.402f * num4, MidpointRounding.AwayFromZero)) * num5;
				component2[i] = (maxValue - MathF.Round(num2 - 0.3441363f * num3 - 0.7141363f * num4, MidpointRounding.AwayFromZero)) * num5;
				component3[i] = (maxValue - MathF.Round(num2 + 1.772f * num3, MidpointRounding.AwayFromZero)) * num5;
			}
		}

		public static void ConvertFromRgb(in ComponentValues values, float halfValue, float maxValue, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			CmykScalar.ConvertFromRgb(in values, maxValue, rLane, gLane, bLane);
			Span<float> component = values.Component0;
			Span<float> component2 = values.Component1;
			Span<float> component3 = values.Component2;
			for (int i = 0; i < component3.Length; i++)
			{
				float num = maxValue - component[i];
				float num2 = maxValue - component2[i];
				float num3 = maxValue - component3[i];
				component[i] = 0.299f * num + 0.587f * num2 + 0.114f * num3;
				component2[i] = halfValue - 0.168736f * num - 0.331264f * num2 + 0.5f * num3;
				component3[i] = halfValue + 0.5f * num - 0.418688f * num2 - 0.081312f * num3;
			}
		}
	}

	internal sealed class YccKVector : JpegColorConverterVector
	{
		public YccKVector(int precision)
			: base(JpegColorSpace.Ycck, precision)
		{
		}

		protected override void ConvertToRgbInplaceVectorized(in ComponentValues values)
		{
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector<float> source2 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector<float> source3 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			ref Vector<float> source4 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component3));
			Vector<float> vector = new Vector<float>(0f - base.HalfValue);
			Vector<float> vector2 = new Vector<float>(1f / (base.MaximumValue * base.MaximumValue));
			Vector<float> vector3 = new Vector<float>(base.MaximumValue);
			Vector<float> vector4 = new Vector<float>(1.402f);
			Vector<float> vector5 = new Vector<float>(-0.3441363f);
			Vector<float> vector6 = new Vector<float>(-0.7141363f);
			Vector<float> vector7 = new Vector<float>(1.772f);
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				ref Vector<float> reference = ref Unsafe.Add(ref source, num2);
				ref Vector<float> reference2 = ref Unsafe.Add(ref source2, num2);
				ref Vector<float> reference3 = ref Unsafe.Add(ref source3, num2);
				Vector<float> vector8 = reference;
				Vector<float> vector9 = reference2 + vector;
				Vector<float> vector10 = reference3 + vector;
				Vector<float> vector11 = Unsafe.Add(ref source4, num2) * vector2;
				Vector<float> v = vector8 + vector10 * vector4;
				Vector<float> v2 = vector8 + vector9 * vector5 + vector10 * vector6;
				Vector<float> v3 = vector8 + vector9 * vector7;
				v = (vector3 - v.FastRound()) * vector11;
				v2 = (vector3 - v2.FastRound()) * vector11;
				v3 = (vector3 - v3.FastRound()) * vector11;
				reference = v;
				reference2 = v2;
				reference3 = v3;
			}
		}

		protected override void ConvertToRgbInplaceScalarRemainder(in ComponentValues values)
		{
			YccKScalar.ConvertToRgpInplace(in values, base.MaximumValue, base.HalfValue);
		}

		protected override void ConvertFromRgbVectorized(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane)
		{
			CmykVector.ConvertFromRgbInplaceVectorized(in values, base.MaximumValue, rLane, gLane, bLane);
			ref Vector<float> source = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component0));
			ref Vector<float> source2 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component1));
			ref Vector<float> source3 = ref Unsafe.As<float, Vector<float>>(ref MemoryMarshal.GetReference<float>(values.Component2));
			Vector<float> vector = new Vector<float>(base.MaximumValue);
			Vector<float> vector2 = new Vector<float>(base.HalfValue);
			Vector<float> vector3 = new Vector<float>(0.299f);
			Vector<float> vector4 = new Vector<float>(0.587f);
			Vector<float> vector5 = new Vector<float>(0.114f);
			Vector<float> vector6 = new Vector<float>(0.168736f);
			Vector<float> vector7 = new Vector<float>(0.331264f);
			Vector<float> vector8 = new Vector<float>(0.5f);
			Vector<float> vector9 = new Vector<float>(0.5f);
			Vector<float> vector10 = new Vector<float>(0.418688f);
			Vector<float> vector11 = new Vector<float>(0.081312f);
			nuint num = values.Component0.VectorCount<float>();
			for (nuint num2 = 0u; num2 < num; num2++)
			{
				Vector<float> vector12 = vector - Unsafe.Add(ref source, num2);
				Vector<float> vector13 = vector - Unsafe.Add(ref source2, num2);
				Vector<float> vector14 = vector - Unsafe.Add(ref source3, num2);
				Unsafe.Add(ref source, num2) = vector3 * vector12 + vector4 * vector13 + vector5 * vector14;
				Unsafe.Add(ref source2, num2) = vector2 - vector6 * vector12 - vector7 * vector13 + vector8 * vector14;
				Unsafe.Add(ref source3, num2) = vector2 + vector9 * vector12 - vector10 * vector13 - vector11 * vector14;
			}
		}

		protected override void ConvertFromRgbScalarRemainder(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			CmykScalar.ConvertFromRgb(in values, base.MaximumValue, r, g, b);
			YccKScalar.ConvertFromRgb(in values, base.HalfValue, base.MaximumValue, r, g, b);
		}
	}

	internal abstract class JpegColorConverterArm : JpegColorConverterBase
	{
		public static bool IsSupported => AdvSimd.IsSupported;

		public sealed override bool IsAvailable => IsSupported;

		public sealed override int ElementsPerBatch => Vector128<float>.Count;

		protected JpegColorConverterArm(JpegColorSpace colorSpace, int precision)
			: base(colorSpace, precision)
		{
		}
	}

	internal abstract class JpegColorConverterArm64 : JpegColorConverterBase
	{
		public static bool IsSupported => AdvSimd.Arm64.IsSupported;

		public sealed override bool IsAvailable => IsSupported;

		public sealed override int ElementsPerBatch => Vector128<float>.Count;

		protected JpegColorConverterArm64(JpegColorSpace colorSpace, int precision)
			: base(colorSpace, precision)
		{
		}
	}

	internal abstract class JpegColorConverterAvx : JpegColorConverterBase
	{
		public static bool IsSupported => Avx.IsSupported;

		public sealed override bool IsAvailable => IsSupported;

		public sealed override int ElementsPerBatch => Vector256<float>.Count;

		protected JpegColorConverterAvx(JpegColorSpace colorSpace, int precision)
			: base(colorSpace, precision)
		{
		}
	}

	public readonly ref struct ComponentValues
	{
		public readonly int ComponentCount;

		public readonly Span<float> Component0;

		public readonly Span<float> Component1;

		public readonly Span<float> Component2;

		public readonly Span<float> Component3;

		public ComponentValues(IReadOnlyList<Buffer2D<float>> componentBuffers, int row)
		{
			ComponentCount = componentBuffers.Count;
			Component0 = componentBuffers[0].DangerousGetRowSpan(row);
			Component1 = ((ComponentCount > 1) ? componentBuffers[1].DangerousGetRowSpan(row) : Component0);
			Component2 = ((ComponentCount > 2) ? componentBuffers[2].DangerousGetRowSpan(row) : Component0);
			Component3 = ((ComponentCount > 3) ? componentBuffers[3].DangerousGetRowSpan(row) : Span<float>.Empty);
		}

		public ComponentValues(IReadOnlyList<SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder.ComponentProcessor> processors, int row)
		{
			ComponentCount = processors.Count;
			Component0 = processors[0].GetColorBufferRowSpan(row);
			Component1 = ((ComponentCount > 1) ? processors[1].GetColorBufferRowSpan(row) : Component0);
			Component2 = ((ComponentCount > 2) ? processors[2].GetColorBufferRowSpan(row) : Component0);
			Component3 = ((ComponentCount > 3) ? processors[3].GetColorBufferRowSpan(row) : Span<float>.Empty);
		}

		public ComponentValues(IReadOnlyList<SixLabors.ImageSharp.Formats.Jpeg.Components.Encoder.ComponentProcessor> processors, int row)
		{
			ComponentCount = processors.Count;
			Component0 = processors[0].GetColorBufferRowSpan(row);
			Component1 = ((ComponentCount > 1) ? processors[1].GetColorBufferRowSpan(row) : Component0);
			Component2 = ((ComponentCount > 2) ? processors[2].GetColorBufferRowSpan(row) : Component0);
			Component3 = ((ComponentCount > 3) ? processors[3].GetColorBufferRowSpan(row) : Span<float>.Empty);
		}

		internal ComponentValues(int componentCount, Span<float> c0, Span<float> c1, Span<float> c2, Span<float> c3)
		{
			ComponentCount = componentCount;
			Component0 = c0;
			Component1 = c1;
			Component2 = c2;
			Component3 = c3;
		}

		public ComponentValues Slice(int start, int length)
		{
			Span<float> c = Component0.Slice(start, length);
			Span<float> c2 = ((Component1.Length > 0) ? Component1.Slice(start, length) : Span<float>.Empty);
			Span<float> c3 = ((Component2.Length > 0) ? Component2.Slice(start, length) : Span<float>.Empty);
			Span<float> c4 = ((Component3.Length > 0) ? Component3.Slice(start, length) : Span<float>.Empty);
			return new ComponentValues(ComponentCount, c, c2, c3, c4);
		}
	}

	internal abstract class JpegColorConverterScalar : JpegColorConverterBase
	{
		public sealed override bool IsAvailable => true;

		public sealed override int ElementsPerBatch => 1;

		protected JpegColorConverterScalar(JpegColorSpace colorSpace, int precision)
			: base(colorSpace, precision)
		{
		}
	}

	internal abstract class JpegColorConverterVector : JpegColorConverterBase
	{
		public static bool IsSupported
		{
			get
			{
				if (Vector.IsHardwareAccelerated)
				{
					return Vector<float>.Count % 4 == 0;
				}
				return false;
			}
		}

		public sealed override bool IsAvailable => IsSupported;

		public override int ElementsPerBatch => Vector<float>.Count;

		protected JpegColorConverterVector(JpegColorSpace colorSpace, int precision)
			: base(colorSpace, precision)
		{
		}

		public sealed override void ConvertToRgbInplace(in ComponentValues values)
		{
			int length = values.Component0.Length;
			int num = (int)((uint)length % (uint)Vector<float>.Count);
			int num2 = length - num;
			ComponentValues values2;
			if (num2 > 0)
			{
				values2 = values.Slice(0, num2);
				ConvertToRgbInplaceVectorized(in values2);
			}
			if (num > 0)
			{
				values2 = values.Slice(num2, num);
				ConvertToRgbInplaceScalarRemainder(in values2);
			}
		}

		public sealed override void ConvertFromRgb(in ComponentValues values, Span<float> r, Span<float> g, Span<float> b)
		{
			int length = values.Component0.Length;
			int num = (int)((uint)length % (uint)Vector<float>.Count);
			int num2 = length - num;
			ComponentValues values2;
			if (num2 > 0)
			{
				values2 = values.Slice(0, num2);
				ConvertFromRgbVectorized(in values2, r.Slice(0, num2), g.Slice(0, num2), b.Slice(0, num2));
			}
			if (num > 0)
			{
				values2 = values.Slice(num2, num);
				ConvertFromRgbScalarRemainder(in values2, r.Slice(num2, num), g.Slice(num2, num), b.Slice(num2, num));
			}
		}

		protected abstract void ConvertToRgbInplaceVectorized(in ComponentValues values);

		protected abstract void ConvertToRgbInplaceScalarRemainder(in ComponentValues values);

		protected abstract void ConvertFromRgbVectorized(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane);

		protected abstract void ConvertFromRgbScalarRemainder(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane);
	}

	private static readonly JpegColorConverterBase[] Converters = CreateConverters();

	public abstract bool IsAvailable { get; }

	public abstract int ElementsPerBatch { get; }

	public JpegColorSpace ColorSpace { get; }

	public int Precision { get; }

	private float MaximumValue { get; }

	private float HalfValue { get; }

	protected JpegColorConverterBase(JpegColorSpace colorSpace, int precision)
	{
		ColorSpace = colorSpace;
		Precision = precision;
		MaximumValue = MathF.Pow(2f, precision) - 1f;
		HalfValue = MathF.Ceiling(MaximumValue * 0.5f);
	}

	public static JpegColorConverterBase GetConverter(JpegColorSpace colorSpace, int precision)
	{
		return Array.Find(Converters, (JpegColorConverterBase c) => c.ColorSpace == colorSpace && c.Precision == precision) ?? throw new InvalidImageContentException($"Could not find any converter for JpegColorSpace {colorSpace}!");
	}

	public abstract void ConvertToRgbInplace(in ComponentValues values);

	public abstract void ConvertFromRgb(in ComponentValues values, Span<float> rLane, Span<float> gLane, Span<float> bLane);

	private static JpegColorConverterBase[] CreateConverters()
	{
		return new JpegColorConverterBase[10]
		{
			GetYCbCrConverter(8),
			GetYccKConverter(8),
			GetCmykConverter(8),
			GetGrayScaleConverter(8),
			GetRgbConverter(8),
			GetYCbCrConverter(12),
			GetYccKConverter(12),
			GetCmykConverter(12),
			GetGrayScaleConverter(12),
			GetRgbConverter(12)
		};
	}

	private static JpegColorConverterBase GetYCbCrConverter(int precision)
	{
		if (JpegColorConverterAvx.IsSupported)
		{
			return new YCbCrAvx(precision);
		}
		if (JpegColorConverterArm.IsSupported)
		{
			return new YCbCrArm(precision);
		}
		if (JpegColorConverterVector.IsSupported)
		{
			return new YCbCrVector(precision);
		}
		return new YCbCrScalar(precision);
	}

	private static JpegColorConverterBase GetYccKConverter(int precision)
	{
		if (JpegColorConverterAvx.IsSupported)
		{
			return new YccKAvx(precision);
		}
		if (JpegColorConverterArm64.IsSupported)
		{
			return new YccKArm64(precision);
		}
		if (JpegColorConverterVector.IsSupported)
		{
			return new YccKVector(precision);
		}
		return new YccKScalar(precision);
	}

	private static JpegColorConverterBase GetCmykConverter(int precision)
	{
		if (JpegColorConverterAvx.IsSupported)
		{
			return new CmykAvx(precision);
		}
		if (JpegColorConverterArm64.IsSupported)
		{
			return new CmykArm64(precision);
		}
		if (JpegColorConverterVector.IsSupported)
		{
			return new CmykVector(precision);
		}
		return new CmykScalar(precision);
	}

	private static JpegColorConverterBase GetGrayScaleConverter(int precision)
	{
		if (JpegColorConverterAvx.IsSupported)
		{
			return new GrayscaleAvx(precision);
		}
		if (JpegColorConverterArm.IsSupported)
		{
			return new GrayscaleArm(precision);
		}
		if (JpegColorConverterVector.IsSupported)
		{
			return new GrayScaleVector(precision);
		}
		return new GrayscaleScalar(precision);
	}

	private static JpegColorConverterBase GetRgbConverter(int precision)
	{
		if (JpegColorConverterAvx.IsSupported)
		{
			return new RgbAvx(precision);
		}
		if (JpegColorConverterArm.IsSupported)
		{
			return new RgbArm(precision);
		}
		if (JpegColorConverterVector.IsSupported)
		{
			return new RgbVector(precision);
		}
		return new RgbScalar(precision);
	}
}
