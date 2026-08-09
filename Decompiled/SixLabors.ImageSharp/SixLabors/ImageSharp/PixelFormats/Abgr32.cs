using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats.Utils;

namespace SixLabors.ImageSharp.PixelFormats;

public struct Abgr32 : IPixel<Abgr32>, IPixel, IEquatable<Abgr32>, IPackedVector<uint>
{
	internal class PixelOperations : PixelOperations<Abgr32>
	{
		private static readonly Lazy<PixelTypeInfo> LazyInfo = new Lazy<PixelTypeInfo>(() => PixelTypeInfo.Create<Abgr32>(PixelAlphaRepresentation.Unassociated), isThreadSafe: true);

		public override PixelTypeInfo GetPixelTypeInfo()
		{
			return LazyInfo.Value;
		}

		public override void FromAbgr32(Configuration configuration, ReadOnlySpan<Abgr32> source, Span<Abgr32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(source, destinationPixels, "destinationPixels");
			source.CopyTo(destinationPixels.Slice(0, source.Length));
		}

		public override void ToAbgr32(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Abgr32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			sourcePixels.CopyTo(destinationPixels.Slice(0, sourcePixels.Length));
		}

		public override void FromVector4Destructive(Configuration configuration, Span<Vector4> sourceVectors, Span<Abgr32> destinationPixels, PixelConversionModifiers modifiers)
		{
			Vector4Converters.RgbaCompatible.FromVector4(configuration, this, sourceVectors, destinationPixels, modifiers.Remove(PixelConversionModifiers.Scale));
		}

		public override void ToVector4(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Vector4> destVectors, PixelConversionModifiers modifiers)
		{
			Vector4Converters.RgbaCompatible.ToVector4(configuration, this, sourcePixels, destVectors, modifiers.Remove(PixelConversionModifiers.Scale));
		}

		public override void ToRgba32(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Rgba32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Abgr32, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Rgba32, byte>(destinationPixels);
			PixelConverter.FromAbgr32.ToRgba32(source, dest);
		}

		public override void FromRgba32(Configuration configuration, ReadOnlySpan<Rgba32> sourcePixels, Span<Abgr32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Rgba32, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Abgr32, byte>(destinationPixels);
			PixelConverter.FromRgba32.ToAbgr32(source, dest);
		}

		public override void ToArgb32(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Argb32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Abgr32, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Argb32, byte>(destinationPixels);
			PixelConverter.FromAbgr32.ToArgb32(source, dest);
		}

		public override void FromArgb32(Configuration configuration, ReadOnlySpan<Argb32> sourcePixels, Span<Abgr32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Argb32, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Abgr32, byte>(destinationPixels);
			PixelConverter.FromArgb32.ToAbgr32(source, dest);
		}

		public override void ToBgra32(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Bgra32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Abgr32, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Bgra32, byte>(destinationPixels);
			PixelConverter.FromAbgr32.ToBgra32(source, dest);
		}

		public override void FromBgra32(Configuration configuration, ReadOnlySpan<Bgra32> sourcePixels, Span<Abgr32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Bgra32, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Abgr32, byte>(destinationPixels);
			PixelConverter.FromBgra32.ToAbgr32(source, dest);
		}

		public override void ToRgb24(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Rgb24> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Abgr32, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Rgb24, byte>(destinationPixels);
			PixelConverter.FromAbgr32.ToRgb24(source, dest);
		}

		public override void FromRgb24(Configuration configuration, ReadOnlySpan<Rgb24> sourcePixels, Span<Abgr32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Rgb24, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Abgr32, byte>(destinationPixels);
			PixelConverter.FromRgb24.ToAbgr32(source, dest);
		}

		public override void ToBgr24(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Bgr24> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Abgr32, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Bgr24, byte>(destinationPixels);
			PixelConverter.FromAbgr32.ToBgr24(source, dest);
		}

		public override void FromBgr24(Configuration configuration, ReadOnlySpan<Bgr24> sourcePixels, Span<Abgr32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ReadOnlySpan<byte> source = MemoryMarshal.Cast<Bgr24, byte>(sourcePixels);
			Span<byte> dest = MemoryMarshal.Cast<Abgr32, byte>(destinationPixels);
			PixelConverter.FromBgr24.ToAbgr32(source, dest);
		}

		public override void ToL8(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<L8> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ref Abgr32 reference = ref MemoryMarshal.GetReference<Abgr32>(sourcePixels);
			ref L8 reference2 = ref MemoryMarshal.GetReference<L8>(destinationPixels);
			for (nuint num = 0u; num < (uint)sourcePixels.Length; num++)
			{
				ref Abgr32 reference3 = ref Unsafe.Add(ref reference, num);
				Unsafe.Add(ref reference2, num).FromAbgr32(reference3);
			}
		}

		public override void ToL16(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<L16> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ref Abgr32 reference = ref MemoryMarshal.GetReference<Abgr32>(sourcePixels);
			ref L16 reference2 = ref MemoryMarshal.GetReference<L16>(destinationPixels);
			for (nuint num = 0u; num < (uint)sourcePixels.Length; num++)
			{
				ref Abgr32 reference3 = ref Unsafe.Add(ref reference, num);
				Unsafe.Add(ref reference2, num).FromAbgr32(reference3);
			}
		}

		public override void ToLa16(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<La16> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ref Abgr32 reference = ref MemoryMarshal.GetReference<Abgr32>(sourcePixels);
			ref La16 reference2 = ref MemoryMarshal.GetReference<La16>(destinationPixels);
			for (nuint num = 0u; num < (uint)sourcePixels.Length; num++)
			{
				ref Abgr32 reference3 = ref Unsafe.Add(ref reference, num);
				Unsafe.Add(ref reference2, num).FromAbgr32(reference3);
			}
		}

		public override void ToLa32(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<La32> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ref Abgr32 reference = ref MemoryMarshal.GetReference<Abgr32>(sourcePixels);
			ref La32 reference2 = ref MemoryMarshal.GetReference<La32>(destinationPixels);
			for (nuint num = 0u; num < (uint)sourcePixels.Length; num++)
			{
				ref Abgr32 reference3 = ref Unsafe.Add(ref reference, num);
				Unsafe.Add(ref reference2, num).FromAbgr32(reference3);
			}
		}

		public override void ToRgb48(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Rgb48> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ref Abgr32 reference = ref MemoryMarshal.GetReference<Abgr32>(sourcePixels);
			ref Rgb48 reference2 = ref MemoryMarshal.GetReference<Rgb48>(destinationPixels);
			for (nuint num = 0u; num < (uint)sourcePixels.Length; num++)
			{
				ref Abgr32 reference3 = ref Unsafe.Add(ref reference, num);
				Unsafe.Add(ref reference2, num).FromAbgr32(reference3);
			}
		}

		public override void ToRgba64(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Rgba64> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ref Abgr32 reference = ref MemoryMarshal.GetReference<Abgr32>(sourcePixels);
			ref Rgba64 reference2 = ref MemoryMarshal.GetReference<Rgba64>(destinationPixels);
			for (nuint num = 0u; num < (uint)sourcePixels.Length; num++)
			{
				ref Abgr32 reference3 = ref Unsafe.Add(ref reference, num);
				Unsafe.Add(ref reference2, num).FromAbgr32(reference3);
			}
		}

		public override void ToBgra5551(Configuration configuration, ReadOnlySpan<Abgr32> sourcePixels, Span<Bgra5551> destinationPixels)
		{
			Guard.NotNull(configuration, "configuration");
			Guard.DestinationShouldNotBeTooShort(sourcePixels, destinationPixels, "destinationPixels");
			ref Abgr32 reference = ref MemoryMarshal.GetReference<Abgr32>(sourcePixels);
			ref Bgra5551 reference2 = ref MemoryMarshal.GetReference<Bgra5551>(destinationPixels);
			for (nuint num = 0u; num < (uint)sourcePixels.Length; num++)
			{
				ref Abgr32 reference3 = ref Unsafe.Add(ref reference, num);
				Unsafe.Add(ref reference2, num).FromAbgr32(reference3);
			}
		}

		public override void From<TSourcePixel>(Configuration configuration, ReadOnlySpan<TSourcePixel> sourcePixels, Span<Abgr32> destinationPixels)
		{
			PixelOperations<TSourcePixel>.Instance.ToAbgr32(configuration, sourcePixels, destinationPixels.Slice(0, sourcePixels.Length));
		}
	}

	public byte A;

	public byte B;

	public byte G;

	public byte R;

	private static readonly Vector4 MaxBytes;

	private static readonly Vector4 Half;

	public uint Abgr
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		readonly get
		{
			return Unsafe.As<Abgr32, uint>(ref Unsafe.AsRef<Abgr32>(this));
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			Unsafe.As<Abgr32, uint>(ref this) = value;
		}
	}

	public uint PackedValue
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		readonly get
		{
			return Abgr;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		set
		{
			Abgr = value;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Abgr32(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
		A = byte.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Abgr32(byte r, byte g, byte b, byte a)
	{
		R = r;
		G = g;
		B = b;
		A = a;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Abgr32(float r, float g, float b, float a = 1f)
	{
		this = default(Abgr32);
		Pack(r, g, b, a);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Abgr32(Vector3 vector)
	{
		this = default(Abgr32);
		Pack(ref vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Abgr32(Vector4 vector)
	{
		this = default(Abgr32);
		Pack(ref vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Abgr32(uint packed)
	{
		this = default(Abgr32);
		Abgr = packed;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Color(Abgr32 source)
	{
		return new Color(source);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static implicit operator Abgr32(Color color)
	{
		return color.ToAbgr32();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(Abgr32 left, Abgr32 right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(Abgr32 left, Abgr32 right)
	{
		return !left.Equals(right);
	}

	public readonly PixelOperations<Abgr32> CreatePixelOperations()
	{
		return new PixelOperations();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromScaledVector4(Vector4 vector)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		FromVector4(vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly Vector4 ToScaledVector4()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return ToVector4();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromVector4(Vector4 vector)
	{
		Pack(ref vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly Vector4 ToVector4()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		return new Vector4((float)(int)R, (float)(int)G, (float)(int)B, (float)(int)A) / MaxBytes;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromAbgr32(Abgr32 source)
	{
		this = source;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromBgra5551(Bgra5551 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromBgr24(Bgr24 source)
	{
		Unsafe.As<byte, Bgr24>(ref Unsafe.AddByteOffset(ref Unsafe.As<Abgr32, byte>(ref this), 1u)) = source;
		A = byte.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromArgb32(Argb32 source)
	{
		R = source.R;
		G = source.G;
		B = source.B;
		A = source.A;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromBgra32(Bgra32 source)
	{
		R = source.R;
		G = source.G;
		B = source.B;
		A = source.A;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromL8(L8 source)
	{
		R = source.PackedValue;
		G = source.PackedValue;
		B = source.PackedValue;
		A = byte.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromL16(L16 source)
	{
		B = (G = (R = ColorNumerics.DownScaleFrom16BitTo8Bit(source.PackedValue)));
		A = byte.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromLa16(La16 source)
	{
		R = source.L;
		G = source.L;
		B = source.L;
		A = source.A;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromLa32(La32 source)
	{
		B = (G = (R = ColorNumerics.DownScaleFrom16BitTo8Bit(source.L)));
		A = ColorNumerics.DownScaleFrom16BitTo8Bit(source.A);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromRgb24(Rgb24 source)
	{
		R = source.R;
		G = source.G;
		B = source.B;
		A = byte.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromRgba32(Rgba32 source)
	{
		R = source.R;
		G = source.G;
		B = source.B;
		A = source.A;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToRgba32(ref Rgba32 dest)
	{
		dest.R = R;
		dest.G = G;
		dest.B = B;
		dest.A = A;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromRgb48(Rgb48 source)
	{
		R = ColorNumerics.DownScaleFrom16BitTo8Bit(source.R);
		G = ColorNumerics.DownScaleFrom16BitTo8Bit(source.G);
		B = ColorNumerics.DownScaleFrom16BitTo8Bit(source.B);
		A = byte.MaxValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromRgba64(Rgba64 source)
	{
		R = ColorNumerics.DownScaleFrom16BitTo8Bit(source.R);
		G = ColorNumerics.DownScaleFrom16BitTo8Bit(source.G);
		B = ColorNumerics.DownScaleFrom16BitTo8Bit(source.B);
		A = ColorNumerics.DownScaleFrom16BitTo8Bit(source.A);
	}

	public override readonly bool Equals(object? obj)
	{
		if (obj is Abgr32 other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(Abgr32 other)
	{
		return Abgr == other.Abgr;
	}

	public override readonly string ToString()
	{
		return $"Abgr({A}, {B}, {G}, {R})";
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override readonly int GetHashCode()
	{
		return Abgr.GetHashCode();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Pack(float x, float y, float z, float w)
	{
		Vector4 vector = default(Vector4);
		((Vector4)(ref vector))._002Ector(x, y, z, w);
		Pack(ref vector);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Pack(ref Vector3 vector)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		Vector4 vector2 = default(Vector4);
		((Vector4)(ref vector2))._002Ector(vector, 1f);
		Pack(ref vector2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Pack(ref Vector4 vector)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		vector *= MaxBytes;
		vector += Half;
		vector = Numerics.Clamp(vector, Vector4.Zero, MaxBytes);
		R = (byte)vector.X;
		G = (byte)vector.Y;
		B = (byte)vector.Z;
		A = (byte)vector.W;
	}

	static Abgr32()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		MaxBytes = new Vector4(255f);
		Half = new Vector4(0.5f);
	}
}
