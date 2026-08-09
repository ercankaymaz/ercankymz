using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Formats;

namespace SixLabors.ImageSharp.PixelFormats;

public struct HalfSingle(float value) : IPixel<HalfSingle>, IPixel, IEquatable<HalfSingle>, IPackedVector<ushort>
{
	internal class PixelOperations : PixelOperations<HalfSingle>
	{
		private static readonly Lazy<PixelTypeInfo> LazyInfo = new Lazy<PixelTypeInfo>(() => PixelTypeInfo.Create<HalfSingle>(PixelAlphaRepresentation.None), isThreadSafe: true);

		public override PixelTypeInfo GetPixelTypeInfo()
		{
			return LazyInfo.Value;
		}
	}

	public ushort PackedValue { get; set; } = HalfTypeHelper.Pack(value);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator ==(HalfSingle left, HalfSingle right)
	{
		return left.Equals(right);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool operator !=(HalfSingle left, HalfSingle right)
	{
		return !left.Equals(right);
	}

	public PixelOperations<HalfSingle> CreatePixelOperations()
	{
		return new PixelOperations();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromScaledVector4(Vector4 vector)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		float x = vector.X;
		x *= 2f;
		x -= 1f;
		PackedValue = HalfTypeHelper.Pack(x);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly Vector4 ToScaledVector4()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		return new Vector4((ToSingle() + 1f) / 2f, 0f, 0f, 1f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromVector4(Vector4 vector)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		PackedValue = HalfTypeHelper.Pack(vector.X);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly Vector4 ToVector4()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		return new Vector4(ToSingle(), 0f, 0f, 1f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromArgb32(Argb32 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromBgr24(Bgr24 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromBgra32(Bgra32 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromAbgr32(Abgr32 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromBgra5551(Bgra5551 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromL8(L8 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromL16(L16 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromLa16(La16 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromLa32(La32 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromRgb24(Rgb24 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromRgba32(Rgba32 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void ToRgba32(ref Rgba32 dest)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		dest.FromScaledVector4(ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromRgb48(Rgb48 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void FromRgba64(Rgba64 source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		FromScaledVector4(source.ToScaledVector4());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly float ToSingle()
	{
		return HalfTypeHelper.Unpack(PackedValue);
	}

	public override readonly bool Equals(object? obj)
	{
		if (obj is HalfSingle other)
		{
			return Equals(other);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly bool Equals(HalfSingle other)
	{
		return PackedValue.Equals(other.PackedValue);
	}

	public override readonly string ToString()
	{
		return FormattableString.Invariant($"HalfSingle({ToSingle():#0.##})");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public override readonly int GetHashCode()
	{
		return PackedValue.GetHashCode();
	}
}
