using System;
using SixLabors.ImageSharp.Metadata;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal readonly struct JFifMarker : IEquatable<JFifMarker>
{
	public const int Length = 13;

	public byte MajorVersion { get; }

	public byte MinorVersion { get; }

	public PixelResolutionUnit DensityUnits { get; }

	public short XDensity { get; }

	public short YDensity { get; }

	private JFifMarker(byte majorVersion, byte minorVersion, byte densityUnits, short xDensity, short yDensity)
	{
		MajorVersion = majorVersion;
		MinorVersion = minorVersion;
		DensityUnits = (PixelResolutionUnit)densityUnits;
		XDensity = xDensity;
		YDensity = yDensity;
	}

	public static bool TryParse(ReadOnlySpan<byte> bytes, out JFifMarker marker)
	{
		if (ProfileResolver.IsProfile(bytes, ProfileResolver.JFifMarker) || ProfileResolver.IsProfile(bytes, ProfileResolver.JFxxMarker))
		{
			byte majorVersion = bytes[5];
			byte minorVersion = bytes[6];
			byte densityUnits = bytes[7];
			short xDensity = (short)((bytes[8] << 8) | bytes[9]);
			short yDensity = (short)((bytes[10] << 8) | bytes[11]);
			marker = new JFifMarker(majorVersion, minorVersion, densityUnits, xDensity, yDensity);
			return true;
		}
		marker = default(JFifMarker);
		return false;
	}

	public bool Equals(JFifMarker other)
	{
		if (MajorVersion == other.MajorVersion && MinorVersion == other.MinorVersion && DensityUnits == other.DensityUnits && XDensity == other.XDensity)
		{
			return YDensity == other.YDensity;
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is JFifMarker other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(MajorVersion, MinorVersion, DensityUnits, XDensity, YDensity);
	}
}
