using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace SixLabors.ImageSharp.PixelFormats.PixelBlenders;

internal static class DefaultPixelBlenders<TPixel> where TPixel : unmanaged, IPixel<TPixel>
{
	public class NormalSrc : PixelBlender<TPixel>
	{
		public static NormalSrc Instance { get; } = new NormalSrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalSrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalSrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalSrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplySrc : PixelBlender<TPixel>
	{
		public static MultiplySrc Instance { get; } = new MultiplySrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplySrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplySrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplySrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddSrc : PixelBlender<TPixel>
	{
		public static AddSrc Instance { get; } = new AddSrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddSrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddSrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddSrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractSrc : PixelBlender<TPixel>
	{
		public static SubtractSrc Instance { get; } = new SubtractSrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractSrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractSrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractSrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenSrc : PixelBlender<TPixel>
	{
		public static ScreenSrc Instance { get; } = new ScreenSrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenSrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenSrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenSrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenSrc : PixelBlender<TPixel>
	{
		public static DarkenSrc Instance { get; } = new DarkenSrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenSrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenSrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenSrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenSrc : PixelBlender<TPixel>
	{
		public static LightenSrc Instance { get; } = new LightenSrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenSrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenSrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenSrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlaySrc : PixelBlender<TPixel>
	{
		public static OverlaySrc Instance { get; } = new OverlaySrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlaySrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlaySrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlaySrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightSrc : PixelBlender<TPixel>
	{
		public static HardLightSrc Instance { get; } = new HardLightSrc();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightSrc(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightSrc(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrc(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrc(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightSrc(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrc(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrc(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalSrcAtop : PixelBlender<TPixel>
	{
		public static NormalSrcAtop Instance { get; } = new NormalSrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalSrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalSrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalSrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplySrcAtop : PixelBlender<TPixel>
	{
		public static MultiplySrcAtop Instance { get; } = new MultiplySrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplySrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplySrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplySrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddSrcAtop : PixelBlender<TPixel>
	{
		public static AddSrcAtop Instance { get; } = new AddSrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddSrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddSrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddSrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractSrcAtop : PixelBlender<TPixel>
	{
		public static SubtractSrcAtop Instance { get; } = new SubtractSrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractSrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractSrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractSrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenSrcAtop : PixelBlender<TPixel>
	{
		public static ScreenSrcAtop Instance { get; } = new ScreenSrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenSrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenSrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenSrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenSrcAtop : PixelBlender<TPixel>
	{
		public static DarkenSrcAtop Instance { get; } = new DarkenSrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenSrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenSrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenSrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenSrcAtop : PixelBlender<TPixel>
	{
		public static LightenSrcAtop Instance { get; } = new LightenSrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenSrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenSrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenSrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlaySrcAtop : PixelBlender<TPixel>
	{
		public static OverlaySrcAtop Instance { get; } = new OverlaySrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlaySrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlaySrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlaySrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightSrcAtop : PixelBlender<TPixel>
	{
		public static HardLightSrcAtop Instance { get; } = new HardLightSrcAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightSrcAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightSrcAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrcAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrcAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightSrcAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrcAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrcAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalSrcOver : PixelBlender<TPixel>
	{
		public static NormalSrcOver Instance { get; } = new NormalSrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalSrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalSrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalSrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplySrcOver : PixelBlender<TPixel>
	{
		public static MultiplySrcOver Instance { get; } = new MultiplySrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplySrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplySrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplySrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddSrcOver : PixelBlender<TPixel>
	{
		public static AddSrcOver Instance { get; } = new AddSrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddSrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddSrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddSrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractSrcOver : PixelBlender<TPixel>
	{
		public static SubtractSrcOver Instance { get; } = new SubtractSrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractSrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractSrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractSrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenSrcOver : PixelBlender<TPixel>
	{
		public static ScreenSrcOver Instance { get; } = new ScreenSrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenSrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenSrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenSrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenSrcOver : PixelBlender<TPixel>
	{
		public static DarkenSrcOver Instance { get; } = new DarkenSrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenSrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenSrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenSrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenSrcOver : PixelBlender<TPixel>
	{
		public static LightenSrcOver Instance { get; } = new LightenSrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenSrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenSrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenSrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlaySrcOver : PixelBlender<TPixel>
	{
		public static OverlaySrcOver Instance { get; } = new OverlaySrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlaySrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlaySrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlaySrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightSrcOver : PixelBlender<TPixel>
	{
		public static HardLightSrcOver Instance { get; } = new HardLightSrcOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightSrcOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightSrcOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrcOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrcOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightSrcOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrcOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrcOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalSrcIn : PixelBlender<TPixel>
	{
		public static NormalSrcIn Instance { get; } = new NormalSrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalSrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalSrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalSrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplySrcIn : PixelBlender<TPixel>
	{
		public static MultiplySrcIn Instance { get; } = new MultiplySrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplySrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplySrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplySrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddSrcIn : PixelBlender<TPixel>
	{
		public static AddSrcIn Instance { get; } = new AddSrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddSrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddSrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddSrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractSrcIn : PixelBlender<TPixel>
	{
		public static SubtractSrcIn Instance { get; } = new SubtractSrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractSrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractSrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractSrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenSrcIn : PixelBlender<TPixel>
	{
		public static ScreenSrcIn Instance { get; } = new ScreenSrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenSrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenSrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenSrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenSrcIn : PixelBlender<TPixel>
	{
		public static DarkenSrcIn Instance { get; } = new DarkenSrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenSrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenSrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenSrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenSrcIn : PixelBlender<TPixel>
	{
		public static LightenSrcIn Instance { get; } = new LightenSrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenSrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenSrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenSrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlaySrcIn : PixelBlender<TPixel>
	{
		public static OverlaySrcIn Instance { get; } = new OverlaySrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlaySrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlaySrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlaySrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightSrcIn : PixelBlender<TPixel>
	{
		public static HardLightSrcIn Instance { get; } = new HardLightSrcIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightSrcIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightSrcIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrcIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrcIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightSrcIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrcIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrcIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalSrcOut : PixelBlender<TPixel>
	{
		public static NormalSrcOut Instance { get; } = new NormalSrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalSrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalSrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalSrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalSrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalSrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplySrcOut : PixelBlender<TPixel>
	{
		public static MultiplySrcOut Instance { get; } = new MultiplySrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplySrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplySrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplySrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplySrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplySrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddSrcOut : PixelBlender<TPixel>
	{
		public static AddSrcOut Instance { get; } = new AddSrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddSrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddSrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddSrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddSrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddSrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractSrcOut : PixelBlender<TPixel>
	{
		public static SubtractSrcOut Instance { get; } = new SubtractSrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractSrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractSrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractSrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractSrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractSrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenSrcOut : PixelBlender<TPixel>
	{
		public static ScreenSrcOut Instance { get; } = new ScreenSrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenSrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenSrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenSrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenSrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenSrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenSrcOut : PixelBlender<TPixel>
	{
		public static DarkenSrcOut Instance { get; } = new DarkenSrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenSrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenSrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenSrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenSrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenSrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenSrcOut : PixelBlender<TPixel>
	{
		public static LightenSrcOut Instance { get; } = new LightenSrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenSrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenSrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenSrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenSrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenSrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlaySrcOut : PixelBlender<TPixel>
	{
		public static OverlaySrcOut Instance { get; } = new OverlaySrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlaySrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlaySrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlaySrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlaySrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlaySrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightSrcOut : PixelBlender<TPixel>
	{
		public static HardLightSrcOut Instance { get; } = new HardLightSrcOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightSrcOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightSrcOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrcOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrcOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightSrcOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightSrcOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightSrcOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalDest : PixelBlender<TPixel>
	{
		public static NormalDest Instance { get; } = new NormalDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplyDest : PixelBlender<TPixel>
	{
		public static MultiplyDest Instance { get; } = new MultiplyDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplyDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplyDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplyDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddDest : PixelBlender<TPixel>
	{
		public static AddDest Instance { get; } = new AddDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractDest : PixelBlender<TPixel>
	{
		public static SubtractDest Instance { get; } = new SubtractDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenDest : PixelBlender<TPixel>
	{
		public static ScreenDest Instance { get; } = new ScreenDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenDest : PixelBlender<TPixel>
	{
		public static DarkenDest Instance { get; } = new DarkenDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenDest : PixelBlender<TPixel>
	{
		public static LightenDest Instance { get; } = new LightenDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlayDest : PixelBlender<TPixel>
	{
		public static OverlayDest Instance { get; } = new OverlayDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlayDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlayDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlayDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightDest : PixelBlender<TPixel>
	{
		public static HardLightDest Instance { get; } = new HardLightDest();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightDest(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightDest(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDest(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDest(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightDest(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDest(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDest(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalDestAtop : PixelBlender<TPixel>
	{
		public static NormalDestAtop Instance { get; } = new NormalDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplyDestAtop : PixelBlender<TPixel>
	{
		public static MultiplyDestAtop Instance { get; } = new MultiplyDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplyDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplyDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplyDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddDestAtop : PixelBlender<TPixel>
	{
		public static AddDestAtop Instance { get; } = new AddDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractDestAtop : PixelBlender<TPixel>
	{
		public static SubtractDestAtop Instance { get; } = new SubtractDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenDestAtop : PixelBlender<TPixel>
	{
		public static ScreenDestAtop Instance { get; } = new ScreenDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenDestAtop : PixelBlender<TPixel>
	{
		public static DarkenDestAtop Instance { get; } = new DarkenDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenDestAtop : PixelBlender<TPixel>
	{
		public static LightenDestAtop Instance { get; } = new LightenDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlayDestAtop : PixelBlender<TPixel>
	{
		public static OverlayDestAtop Instance { get; } = new OverlayDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlayDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlayDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlayDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightDestAtop : PixelBlender<TPixel>
	{
		public static HardLightDestAtop Instance { get; } = new HardLightDestAtop();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightDestAtop(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightDestAtop(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDestAtop(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDestAtop(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightDestAtop(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDestAtop(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDestAtop(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalDestOver : PixelBlender<TPixel>
	{
		public static NormalDestOver Instance { get; } = new NormalDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplyDestOver : PixelBlender<TPixel>
	{
		public static MultiplyDestOver Instance { get; } = new MultiplyDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplyDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplyDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplyDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddDestOver : PixelBlender<TPixel>
	{
		public static AddDestOver Instance { get; } = new AddDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractDestOver : PixelBlender<TPixel>
	{
		public static SubtractDestOver Instance { get; } = new SubtractDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenDestOver : PixelBlender<TPixel>
	{
		public static ScreenDestOver Instance { get; } = new ScreenDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenDestOver : PixelBlender<TPixel>
	{
		public static DarkenDestOver Instance { get; } = new DarkenDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenDestOver : PixelBlender<TPixel>
	{
		public static LightenDestOver Instance { get; } = new LightenDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlayDestOver : PixelBlender<TPixel>
	{
		public static OverlayDestOver Instance { get; } = new OverlayDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlayDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlayDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlayDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightDestOver : PixelBlender<TPixel>
	{
		public static HardLightDestOver Instance { get; } = new HardLightDestOver();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightDestOver(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightDestOver(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDestOver(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDestOver(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightDestOver(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDestOver(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDestOver(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalDestIn : PixelBlender<TPixel>
	{
		public static NormalDestIn Instance { get; } = new NormalDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplyDestIn : PixelBlender<TPixel>
	{
		public static MultiplyDestIn Instance { get; } = new MultiplyDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplyDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplyDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplyDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddDestIn : PixelBlender<TPixel>
	{
		public static AddDestIn Instance { get; } = new AddDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractDestIn : PixelBlender<TPixel>
	{
		public static SubtractDestIn Instance { get; } = new SubtractDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenDestIn : PixelBlender<TPixel>
	{
		public static ScreenDestIn Instance { get; } = new ScreenDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenDestIn : PixelBlender<TPixel>
	{
		public static DarkenDestIn Instance { get; } = new DarkenDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenDestIn : PixelBlender<TPixel>
	{
		public static LightenDestIn Instance { get; } = new LightenDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlayDestIn : PixelBlender<TPixel>
	{
		public static OverlayDestIn Instance { get; } = new OverlayDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlayDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlayDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlayDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightDestIn : PixelBlender<TPixel>
	{
		public static HardLightDestIn Instance { get; } = new HardLightDestIn();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightDestIn(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightDestIn(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDestIn(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDestIn(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightDestIn(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDestIn(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDestIn(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalDestOut : PixelBlender<TPixel>
	{
		public static NormalDestOut Instance { get; } = new NormalDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplyDestOut : PixelBlender<TPixel>
	{
		public static MultiplyDestOut Instance { get; } = new MultiplyDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplyDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplyDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplyDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddDestOut : PixelBlender<TPixel>
	{
		public static AddDestOut Instance { get; } = new AddDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractDestOut : PixelBlender<TPixel>
	{
		public static SubtractDestOut Instance { get; } = new SubtractDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenDestOut : PixelBlender<TPixel>
	{
		public static ScreenDestOut Instance { get; } = new ScreenDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenDestOut : PixelBlender<TPixel>
	{
		public static DarkenDestOut Instance { get; } = new DarkenDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenDestOut : PixelBlender<TPixel>
	{
		public static LightenDestOut Instance { get; } = new LightenDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlayDestOut : PixelBlender<TPixel>
	{
		public static OverlayDestOut Instance { get; } = new OverlayDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlayDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlayDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlayDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightDestOut : PixelBlender<TPixel>
	{
		public static HardLightDestOut Instance { get; } = new HardLightDestOut();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightDestOut(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightDestOut(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDestOut(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDestOut(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightDestOut(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightDestOut(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightDestOut(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalClear : PixelBlender<TPixel>
	{
		public static NormalClear Instance { get; } = new NormalClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplyClear : PixelBlender<TPixel>
	{
		public static MultiplyClear Instance { get; } = new MultiplyClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplyClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplyClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplyClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddClear : PixelBlender<TPixel>
	{
		public static AddClear Instance { get; } = new AddClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractClear : PixelBlender<TPixel>
	{
		public static SubtractClear Instance { get; } = new SubtractClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenClear : PixelBlender<TPixel>
	{
		public static ScreenClear Instance { get; } = new ScreenClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenClear : PixelBlender<TPixel>
	{
		public static DarkenClear Instance { get; } = new DarkenClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenClear : PixelBlender<TPixel>
	{
		public static LightenClear Instance { get; } = new LightenClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlayClear : PixelBlender<TPixel>
	{
		public static OverlayClear Instance { get; } = new OverlayClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlayClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlayClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlayClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightClear : PixelBlender<TPixel>
	{
		public static HardLightClear Instance { get; } = new HardLightClear();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightClear(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightClear(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightClear(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightClear(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightClear(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightClear(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightClear(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class NormalXor : PixelBlender<TPixel>
	{
		public static NormalXor Instance { get; } = new NormalXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.NormalXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.NormalXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.NormalXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.NormalXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.NormalXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class MultiplyXor : PixelBlender<TPixel>
	{
		public static MultiplyXor Instance { get; } = new MultiplyXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.MultiplyXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.MultiplyXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.MultiplyXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.MultiplyXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.MultiplyXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class AddXor : PixelBlender<TPixel>
	{
		public static AddXor Instance { get; } = new AddXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.AddXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.AddXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.AddXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.AddXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.AddXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class SubtractXor : PixelBlender<TPixel>
	{
		public static SubtractXor Instance { get; } = new SubtractXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.SubtractXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.SubtractXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.SubtractXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.SubtractXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.SubtractXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class ScreenXor : PixelBlender<TPixel>
	{
		public static ScreenXor Instance { get; } = new ScreenXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.ScreenXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.ScreenXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.ScreenXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.ScreenXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.ScreenXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class DarkenXor : PixelBlender<TPixel>
	{
		public static DarkenXor Instance { get; } = new DarkenXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.DarkenXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.DarkenXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.DarkenXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.DarkenXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.DarkenXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class LightenXor : PixelBlender<TPixel>
	{
		public static LightenXor Instance { get; } = new LightenXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.LightenXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.LightenXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.LightenXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.LightenXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.LightenXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class OverlayXor : PixelBlender<TPixel>
	{
		public static OverlayXor Instance { get; } = new OverlayXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.OverlayXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.OverlayXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.OverlayXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.OverlayXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.OverlayXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}

	public class HardLightXor : PixelBlender<TPixel>
	{
		public static HardLightXor Instance { get; } = new HardLightXor();

		public override TPixel Blend(TPixel background, TPixel source, float amount)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			TPixel result = default(TPixel);
			result.FromScaledVector4(PorterDuffFunctions.HardLightXor(background.ToScaledVector4(), source.ToScaledVector4(), Numerics.Clamp(amount, 0f, 1f)));
			return result;
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, float amount)
		{
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			amount = Numerics.Clamp(amount, 0f, 1f);
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				Vector256<float> opacity = Vector256.Create(amount);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					reference = PorterDuffFunctions.HardLightXor(reference2, reference3, opacity);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightXor(background[index], source[index], amount);
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightXor(background[i], source[i], amount);
				}
			}
		}

		protected override void BlendFunction(Span<Vector4> destination, ReadOnlySpan<Vector4> background, ReadOnlySpan<Vector4> source, ReadOnlySpan<float> amount)
		{
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Avx2.IsSupported && destination.Length >= 2)
			{
				ref Vector256<float> reference = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(destination));
				ref Vector256<float> right = ref Unsafe.Add(ref reference, (uint)destination.Length / 2u);
				ref Vector256<float> reference2 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(background));
				ref Vector256<float> reference3 = ref Unsafe.As<Vector4, Vector256<float>>(ref MemoryMarshal.GetReference<Vector4>(source));
				ref float reference4 = ref MemoryMarshal.GetReference<float>(amount);
				Vector256<float> right2 = Vector256.Create(1f);
				while (Unsafe.IsAddressLessThan(ref reference, ref right))
				{
					Vector256<float> right3 = Vector256.Create(Vector128.Create(reference4), Vector128.Create(Unsafe.Add(ref reference4, 1)));
					right3 = Avx.Min(Avx.Max(Vector256<float>.Zero, right3), right2);
					reference = PorterDuffFunctions.HardLightXor(reference2, reference3, right3);
					reference = ref Unsafe.Add(ref reference, 1);
					reference2 = ref Unsafe.Add(ref reference2, 1);
					reference3 = ref Unsafe.Add(ref reference3, 1);
					reference4 = ref Unsafe.Add(ref reference4, 2);
				}
				if (Numerics.Modulo2(destination.Length) != 0)
				{
					int index = destination.Length - 1;
					destination[index] = PorterDuffFunctions.HardLightXor(background[index], source[index], Numerics.Clamp(amount[index], 0f, 1f));
				}
			}
			else
			{
				for (int i = 0; i < destination.Length; i++)
				{
					destination[i] = PorterDuffFunctions.HardLightXor(background[i], source[i], Numerics.Clamp(amount[i], 0f, 1f));
				}
			}
		}
	}
}
