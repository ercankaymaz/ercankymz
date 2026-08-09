using System;
using System.Collections.Concurrent;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

public class ColorSpaceConverter
{
	private static readonly ConcurrentDictionary<RgbWorkingSpace, LinearRgbToCieXyzConverter> ConverterCache = new ConcurrentDictionary<RgbWorkingSpace, LinearRgbToCieXyzConverter>();

	private static readonly ColorSpaceConverterOptions DefaultOptions = new ColorSpaceConverterOptions();

	private readonly Matrix4x4 lmsAdaptationMatrix;

	private readonly CieXyz whitePoint;

	private readonly CieXyz targetLuvWhitePoint;

	private readonly CieXyz targetLabWhitePoint;

	private readonly CieXyz targetHunterLabWhitePoint;

	private readonly RgbWorkingSpace targetRgbWorkingSpace;

	private readonly IChromaticAdaptation? chromaticAdaptation;

	private readonly bool performChromaticAdaptation;

	private readonly CieXyzAndLmsConverter cieXyzAndLmsConverter;

	private readonly CieXyzToCieLabConverter cieXyzToCieLabConverter;

	private readonly CieXyzToCieLuvConverter cieXyzToCieLuvConverter;

	private readonly CieXyzToHunterLabConverter cieXyzToHunterLabConverter;

	private readonly CieXyzToLinearRgbConverter cieXyzToLinearRgbConverter;

	public CieXyz Adapt(in CieXyz color, in CieXyz sourceWhitePoint)
	{
		return Adapt(in color, in sourceWhitePoint, in whitePoint);
	}

	public CieXyz Adapt(in CieXyz color, in CieXyz sourceWhitePoint, in CieXyz targetWhitePoint)
	{
		if (!performChromaticAdaptation || sourceWhitePoint.Equals(targetWhitePoint))
		{
			return color;
		}
		return chromaticAdaptation.Transform(in color, in sourceWhitePoint, in targetWhitePoint);
	}

	public CieLab Adapt(in CieLab color)
	{
		if (!performChromaticAdaptation || color.WhitePoint.Equals(targetLabWhitePoint))
		{
			return color;
		}
		return ToCieLab(ToCieXyz(in color));
	}

	public CieLch Adapt(in CieLch color)
	{
		if (!performChromaticAdaptation || color.WhitePoint.Equals(targetLabWhitePoint))
		{
			return color;
		}
		return ToCieLch(ToCieLab(in color));
	}

	public CieLchuv Adapt(in CieLchuv color)
	{
		if (!performChromaticAdaptation || color.WhitePoint.Equals(targetLabWhitePoint))
		{
			return color;
		}
		return ToCieLchuv(ToCieLuv(in color));
	}

	public CieLuv Adapt(in CieLuv color)
	{
		if (!performChromaticAdaptation || color.WhitePoint.Equals(targetLuvWhitePoint))
		{
			return color;
		}
		return ToCieLuv(ToCieXyz(in color));
	}

	public HunterLab Adapt(in HunterLab color)
	{
		if (!performChromaticAdaptation || color.WhitePoint.Equals(targetHunterLabWhitePoint))
		{
			return color;
		}
		return ToHunterLab(ToCieXyz(in color));
	}

	public LinearRgb Adapt(in LinearRgb color)
	{
		if (!performChromaticAdaptation || color.WorkingSpace.Equals(targetRgbWorkingSpace))
		{
			return color;
		}
		CieXyz source = GetLinearRgbToCieXyzConverter(color.WorkingSpace).Convert(in color);
		CieXyz input = chromaticAdaptation.Transform(in source, color.WorkingSpace.WhitePoint, targetRgbWorkingSpace.WhitePoint);
		return cieXyzToLinearRgbConverter.Convert(in input);
	}

	public Rgb Adapt(in Rgb color)
	{
		if (!performChromaticAdaptation)
		{
			return color;
		}
		return ToRgb(Adapt(ToLinearRgb(in color)));
	}

	public CieLab ToCieLab(in CieLch color)
	{
		return Adapt(CieLchToCieLabConverter.Convert(in color));
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in CieLchuv color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in CieLuv color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in CieXyy color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in CieXyz color)
	{
		CieXyz input = Adapt(in color, in whitePoint, in targetLabWhitePoint);
		return cieXyzToCieLabConverter.Convert(in input);
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in Cmyk color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Cmyk> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in Hsl color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsl> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in Hsv color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsv> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in HunterLab color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in Lms color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in LinearRgb color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<LinearRgb> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in Rgb color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Rgb> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLab ToCieLab(in YCbCr color)
	{
		return ToCieLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<CieLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref CieLab reference2 = ref MemoryMarshal.GetReference<CieLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLab(in color);
		}
	}

	public CieLch ToCieLch(in CieLab color)
	{
		return CieLabToCieLchConverter.Convert(Adapt(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in CieLchuv color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in CieLuv color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in CieXyy color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in CieXyz color)
	{
		return ToCieLch(ToCieLab(in color));
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in Cmyk color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Cmyk> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in Hsl color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsl> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in Hsv color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsv> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in HunterLab color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in LinearRgb color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<LinearRgb> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in Lms color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in Rgb color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Rgb> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLch ToCieLch(in YCbCr color)
	{
		return ToCieLch(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<CieLch> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref CieLch reference2 = ref MemoryMarshal.GetReference<CieLch>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLch(in color);
		}
	}

	public CieLchuv ToCieLchuv(in CieLab color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in CieLch color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in CieLuv color)
	{
		return CieLuvToCieLchuvConverter.Convert(Adapt(in color));
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in CieXyy color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in CieXyz color)
	{
		return ToCieLchuv(ToCieLuv(in color));
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in Cmyk color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Cmyk> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in Hsl color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsl> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in Hsv color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsv> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in HunterLab color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in LinearRgb color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<LinearRgb> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in Lms color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in Rgb color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Rgb> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLchuv ToCieLchuv(in YCbCr color)
	{
		return ToCieLchuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<CieLchuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref CieLchuv reference2 = ref MemoryMarshal.GetReference<CieLchuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLchuv(in color);
		}
	}

	public CieLuv ToCieLuv(in CieLab color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in CieLch color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in CieLchuv color)
	{
		return Adapt(CieLchuvToCieLuvConverter.Convert(in color));
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in CieXyy color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in CieXyz color)
	{
		CieXyz input = Adapt(in color, in whitePoint, in targetLuvWhitePoint);
		return cieXyzToCieLuvConverter.Convert(in input);
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in Cmyk color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Cmyk> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in Hsl color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsl> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in Hsv color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsv> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in HunterLab color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in Lms color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in LinearRgb color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<LinearRgb> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in Rgb color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Rgb> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieLuv ToCieLuv(in YCbCr color)
	{
		return ToCieLuv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<CieLuv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref CieLuv reference2 = ref MemoryMarshal.GetReference<CieLuv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieLuv(in color);
		}
	}

	public CieXyy ToCieXyy(in CieLab color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in CieLch color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in CieLchuv color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in CieLuv color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public static CieXyy ToCieXyy(in CieXyz color)
	{
		return CieXyzAndCieXyyConverter.Convert(in color);
	}

	public static void Convert(ReadOnlySpan<CieXyz> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in Cmyk color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Cmyk> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(Hsl color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsl> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl reference3 = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(reference3);
		}
	}

	public CieXyy ToCieXyy(in Hsv color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Hsv> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in HunterLab color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in LinearRgb color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<LinearRgb> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in Lms color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in Rgb color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Rgb> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyy ToCieXyy(in YCbCr color)
	{
		return ToCieXyy(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<CieXyy> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref CieXyy reference2 = ref MemoryMarshal.GetReference<CieXyy>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyy(in color);
		}
	}

	public CieXyz ToCieXyz(in CieLab color)
	{
		return Adapt(CieLabToCieXyzConverter.Convert(in color), color.WhitePoint);
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in CieLch color)
	{
		return ToCieXyz(CieLchToCieLabConverter.Convert(in color));
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in CieLchuv color)
	{
		return ToCieXyz(CieLchuvToCieLuvConverter.Convert(in color));
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in CieLuv color)
	{
		return Adapt(CieLuvToCieXyzConverter.Convert(in color), color.WhitePoint);
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public static CieXyz ToCieXyz(in CieXyy color)
	{
		return CieXyzAndCieXyyConverter.Convert(in color);
	}

	public static void Convert(ReadOnlySpan<CieXyy> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in Cmyk color)
	{
		return ToCieXyz(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<Cmyk> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in Hsl color)
	{
		return ToCieXyz(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<Hsl> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in Hsv color)
	{
		return ToCieXyz(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<Hsv> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in HunterLab color)
	{
		return Adapt(HunterLabToCieXyzConverter.Convert(in color), color.WhitePoint);
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in LinearRgb color)
	{
		return Adapt(GetLinearRgbToCieXyzConverter(color.WorkingSpace).Convert(in color), color.WorkingSpace.WhitePoint);
	}

	public void Convert(ReadOnlySpan<LinearRgb> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in Lms color)
	{
		return cieXyzAndLmsConverter.Convert(in color);
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in Rgb color)
	{
		return ToCieXyz(RgbToLinearRgbConverter.Convert(in color));
	}

	public void Convert(ReadOnlySpan<Rgb> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	public CieXyz ToCieXyz(in YCbCr color)
	{
		return ToCieXyz(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<CieXyz> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref CieXyz reference2 = ref MemoryMarshal.GetReference<CieXyz>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCieXyz(in color);
		}
	}

	private static LinearRgbToCieXyzConverter GetLinearRgbToCieXyzConverter(RgbWorkingSpace workingSpace)
	{
		return ConverterCache.GetOrAdd(workingSpace, (RgbWorkingSpace key) => new LinearRgbToCieXyzConverter(key));
	}

	public Cmyk ToCmyk(in CieLab color)
	{
		return ToCmyk(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public Cmyk ToCmyk(in CieLch color)
	{
		return ToCmyk(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public Cmyk ToCmyk(in CieLchuv color)
	{
		return ToCmyk(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public Cmyk ToCmyk(in CieLuv color)
	{
		return ToCmyk(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public Cmyk ToCmyk(in CieXyy color)
	{
		return ToCmyk(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public Cmyk ToCmyk(in CieXyz color)
	{
		return CmykAndRgbConverter.Convert(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public static Cmyk ToCmyk(in Hsl color)
	{
		return CmykAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<Hsl> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public static Cmyk ToCmyk(in Hsv color)
	{
		return CmykAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<Hsv> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public Cmyk ToCmyk(in HunterLab color)
	{
		return ToCmyk(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public static Cmyk ToCmyk(in LinearRgb color)
	{
		return CmykAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<LinearRgb> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public Cmyk ToCmyk(in Lms color)
	{
		return ToCmyk(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public static Cmyk ToCmyk(in Rgb color)
	{
		return CmykAndRgbConverter.Convert(in color);
	}

	public static void Convert(ReadOnlySpan<Rgb> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public Cmyk ToCmyk(in YCbCr color)
	{
		return CmykAndRgbConverter.Convert(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<Cmyk> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref Cmyk reference2 = ref MemoryMarshal.GetReference<Cmyk>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToCmyk(in color);
		}
	}

	public ColorSpaceConverter()
		: this(DefaultOptions)
	{
	}

	public ColorSpaceConverter(ColorSpaceConverterOptions options)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(options, "options");
		whitePoint = options.WhitePoint;
		targetLuvWhitePoint = options.TargetLuvWhitePoint;
		targetLabWhitePoint = options.TargetLabWhitePoint;
		targetHunterLabWhitePoint = options.TargetHunterLabWhitePoint;
		targetRgbWorkingSpace = options.TargetRgbWorkingSpace;
		chromaticAdaptation = options.ChromaticAdaptation;
		performChromaticAdaptation = chromaticAdaptation != null;
		lmsAdaptationMatrix = options.LmsAdaptationMatrix;
		cieXyzAndLmsConverter = new CieXyzAndLmsConverter(lmsAdaptationMatrix);
		cieXyzToCieLabConverter = new CieXyzToCieLabConverter(targetLabWhitePoint);
		cieXyzToCieLuvConverter = new CieXyzToCieLuvConverter(targetLuvWhitePoint);
		cieXyzToHunterLabConverter = new CieXyzToHunterLabConverter(targetHunterLabWhitePoint);
		cieXyzToLinearRgbConverter = new CieXyzToLinearRgbConverter(targetRgbWorkingSpace);
	}

	public Hsl ToHsl(in CieLab color)
	{
		return ToHsl(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsl ToHsl(in CieLch color)
	{
		return ToHsl(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsl ToHsl(in CieLchuv color)
	{
		return ToHsl(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsl ToHsl(in CieLuv color)
	{
		return ToHsl(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsl ToHsl(in CieXyy color)
	{
		return ToHsl(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsl ToHsl(in CieXyz color)
	{
		return HslAndRgbConverter.Convert(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public static Hsl ToHsl(in Cmyk color)
	{
		return HslAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<Cmyk> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public static Hsl ToHsl(in Hsv color)
	{
		return HslAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<Hsv> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsl ToHsl(in HunterLab color)
	{
		return ToHsl(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public static Hsl ToHsl(in LinearRgb color)
	{
		return HslAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<LinearRgb> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsl ToHsl(Lms color)
	{
		return ToHsl(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms reference3 = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(reference3);
		}
	}

	public static Hsl ToHsl(in Rgb color)
	{
		return HslAndRgbConverter.Convert(in color);
	}

	public static void Convert(ReadOnlySpan<Rgb> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsl ToHsl(in YCbCr color)
	{
		return HslAndRgbConverter.Convert(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<Hsl> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref Hsl reference2 = ref MemoryMarshal.GetReference<Hsl>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsl(in color);
		}
	}

	public Hsv ToHsv(in CieLab color)
	{
		return ToHsv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public Hsv ToHsv(in CieLch color)
	{
		return ToHsv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public Hsv ToHsv(in CieLchuv color)
	{
		return ToHsv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public Hsv ToHsv(in CieLuv color)
	{
		return ToHsv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public Hsv ToHsv(in CieXyy color)
	{
		return ToHsv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public Hsv ToHsv(in CieXyz color)
	{
		return HsvAndRgbConverter.Convert(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public static Hsv ToHsv(in Cmyk color)
	{
		return HsvAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<Cmyk> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public static Hsv ToHsv(in Hsl color)
	{
		return HsvAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<Hsl> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public Hsv ToHsv(in HunterLab color)
	{
		return ToHsv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public static Hsv ToHsv(in LinearRgb color)
	{
		return HsvAndRgbConverter.Convert(ToRgb(in color));
	}

	public static void Convert(ReadOnlySpan<LinearRgb> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public Hsv ToHsv(Lms color)
	{
		return ToHsv(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms reference3 = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(reference3);
		}
	}

	public static Hsv ToHsv(in Rgb color)
	{
		return HsvAndRgbConverter.Convert(in color);
	}

	public static void Convert(ReadOnlySpan<Rgb> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public Hsv ToHsv(in YCbCr color)
	{
		return HsvAndRgbConverter.Convert(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<Hsv> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref Hsv reference2 = ref MemoryMarshal.GetReference<Hsv>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHsv(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<Cmyk> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<Hsl> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<Hsv> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<LinearRgb> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<Rgb> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<HunterLab> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref HunterLab reference2 = ref MemoryMarshal.GetReference<HunterLab>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToHunterLab(in color);
		}
	}

	public HunterLab ToHunterLab(in CieLab color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in CieLch color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in CieLchuv color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in CieLuv color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in CieXyy color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in CieXyz color)
	{
		CieXyz input = Adapt(in color, in whitePoint, in targetHunterLabWhitePoint);
		return cieXyzToHunterLabConverter.Convert(in input);
	}

	public HunterLab ToHunterLab(in Cmyk color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in Hsl color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in Hsv color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in LinearRgb color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in Lms color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in Rgb color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public HunterLab ToHunterLab(in YCbCr color)
	{
		return ToHunterLab(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Cmyk> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Hsl> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Hsv> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Rgb> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<LinearRgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref LinearRgb reference2 = ref MemoryMarshal.GetReference<LinearRgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLinearRgb(in color);
		}
	}

	public LinearRgb ToLinearRgb(in CieLab color)
	{
		return ToLinearRgb(ToCieXyz(in color));
	}

	public LinearRgb ToLinearRgb(in CieLch color)
	{
		return ToLinearRgb(ToCieXyz(in color));
	}

	public LinearRgb ToLinearRgb(in CieLchuv color)
	{
		return ToLinearRgb(ToCieXyz(in color));
	}

	public LinearRgb ToLinearRgb(in CieLuv color)
	{
		return ToLinearRgb(ToCieXyz(in color));
	}

	public LinearRgb ToLinearRgb(in CieXyy color)
	{
		return ToLinearRgb(ToCieXyz(in color));
	}

	public LinearRgb ToLinearRgb(in CieXyz color)
	{
		CieXyz input = Adapt(in color, in whitePoint, targetRgbWorkingSpace.WhitePoint);
		return cieXyzToLinearRgbConverter.Convert(in input);
	}

	public static LinearRgb ToLinearRgb(in Cmyk color)
	{
		return ToLinearRgb(ToRgb(in color));
	}

	public static LinearRgb ToLinearRgb(in Hsl color)
	{
		return ToLinearRgb(ToRgb(in color));
	}

	public static LinearRgb ToLinearRgb(in Hsv color)
	{
		return ToLinearRgb(ToRgb(in color));
	}

	public LinearRgb ToLinearRgb(in HunterLab color)
	{
		return ToLinearRgb(ToCieXyz(in color));
	}

	public LinearRgb ToLinearRgb(in Lms color)
	{
		return ToLinearRgb(ToCieXyz(in color));
	}

	public static LinearRgb ToLinearRgb(in Rgb color)
	{
		return RgbToLinearRgbConverter.Convert(in color);
	}

	public LinearRgb ToLinearRgb(in YCbCr color)
	{
		return ToLinearRgb(ToRgb(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<Cmyk> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<Hsl> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<Hsv> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<LinearRgb> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<Rgb> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<Lms> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref Lms reference2 = ref MemoryMarshal.GetReference<Lms>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToLms(in color);
		}
	}

	public Lms ToLms(in CieLab color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in CieLch color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in CieLchuv color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in CieLuv color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in CieXyy color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in CieXyz color)
	{
		return cieXyzAndLmsConverter.Convert(in color);
	}

	public Lms ToLms(in Cmyk color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in Hsl color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in Hsv color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in HunterLab color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in LinearRgb color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in Rgb color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public Lms ToLms(in YCbCr color)
	{
		return ToLms(ToCieXyz(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLchuv> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLchuv reference = ref MemoryMarshal.GetReference<CieLchuv>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLchuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Cmyk> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Hsv> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Hsl> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public static void Convert(ReadOnlySpan<LinearRgb> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public void Convert(ReadOnlySpan<YCbCr> source, Span<Rgb> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref YCbCr reference = ref MemoryMarshal.GetReference<YCbCr>(source);
		ref Rgb reference2 = ref MemoryMarshal.GetReference<Rgb>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref YCbCr color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToRgb(in color);
		}
	}

	public Rgb ToRgb(in CieLab color)
	{
		return ToRgb(ToCieXyz(in color));
	}

	public Rgb ToRgb(in CieLch color)
	{
		return ToRgb(ToCieXyz(in color));
	}

	public Rgb ToRgb(in CieLchuv color)
	{
		return ToRgb(ToCieXyz(in color));
	}

	public Rgb ToRgb(in CieLuv color)
	{
		return ToRgb(ToCieXyz(in color));
	}

	public Rgb ToRgb(in CieXyy color)
	{
		return ToRgb(ToCieXyz(in color));
	}

	public Rgb ToRgb(in CieXyz color)
	{
		return ToRgb(ToLinearRgb(in color));
	}

	public static Rgb ToRgb(in Cmyk color)
	{
		return CmykAndRgbConverter.Convert(in color);
	}

	public static Rgb ToRgb(in Hsv color)
	{
		return HsvAndRgbConverter.Convert(in color);
	}

	public static Rgb ToRgb(in Hsl color)
	{
		return HslAndRgbConverter.Convert(in color);
	}

	public Rgb ToRgb(in HunterLab color)
	{
		return ToRgb(ToCieXyz(in color));
	}

	public static Rgb ToRgb(in LinearRgb color)
	{
		return LinearRgbToRgbConverter.Convert(in color);
	}

	public Rgb ToRgb(in Lms color)
	{
		return ToRgb(ToCieXyz(in color));
	}

	public Rgb ToRgb(in YCbCr color)
	{
		return Adapt(YCbCrAndRgbConverter.Convert(in color));
	}

	public void Convert(ReadOnlySpan<CieLab> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLab reference = ref MemoryMarshal.GetReference<CieLab>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLch> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLch reference = ref MemoryMarshal.GetReference<CieLch>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLch color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieLuv> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieLuv reference = ref MemoryMarshal.GetReference<CieLuv>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieLuv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyy> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyy reference = ref MemoryMarshal.GetReference<CieXyy>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyy color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public void Convert(ReadOnlySpan<CieXyz> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref CieXyz reference = ref MemoryMarshal.GetReference<CieXyz>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref CieXyz color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Cmyk> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Cmyk reference = ref MemoryMarshal.GetReference<Cmyk>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Cmyk color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Hsl> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsl reference = ref MemoryMarshal.GetReference<Hsl>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsl color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Hsv> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Hsv reference = ref MemoryMarshal.GetReference<Hsv>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Hsv color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public void Convert(ReadOnlySpan<HunterLab> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref HunterLab reference = ref MemoryMarshal.GetReference<HunterLab>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref HunterLab color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public static void Convert(ReadOnlySpan<LinearRgb> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref LinearRgb reference = ref MemoryMarshal.GetReference<LinearRgb>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref LinearRgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public void Convert(ReadOnlySpan<Lms> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Lms reference = ref MemoryMarshal.GetReference<Lms>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Lms color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public static void Convert(ReadOnlySpan<Rgb> source, Span<YCbCr> destination)
	{
		Guard.DestinationShouldNotBeTooShort(source, destination, "destination");
		int length = source.Length;
		ref Rgb reference = ref MemoryMarshal.GetReference<Rgb>(source);
		ref YCbCr reference2 = ref MemoryMarshal.GetReference<YCbCr>(destination);
		for (nuint num = 0u; num < (uint)length; num++)
		{
			ref Rgb color = ref Unsafe.Add(ref reference, num);
			Unsafe.Add(ref reference2, num) = ToYCbCr(in color);
		}
	}

	public YCbCr ToYCbCr(in CieLab color)
	{
		return ToYCbCr(ToCieXyz(in color));
	}

	public YCbCr ToYCbCr(in CieLch color)
	{
		return ToYCbCr(ToCieXyz(in color));
	}

	public YCbCr ToYCbCr(in CieLuv color)
	{
		return ToYCbCr(ToCieXyz(in color));
	}

	public YCbCr ToYCbCr(in CieXyy color)
	{
		return ToYCbCr(ToCieXyz(in color));
	}

	public YCbCr ToYCbCr(in CieXyz color)
	{
		return YCbCrAndRgbConverter.Convert(ToRgb(in color));
	}

	public static YCbCr ToYCbCr(in Cmyk color)
	{
		return YCbCrAndRgbConverter.Convert(ToRgb(in color));
	}

	public static YCbCr ToYCbCr(in Hsl color)
	{
		return YCbCrAndRgbConverter.Convert(ToRgb(in color));
	}

	public static YCbCr ToYCbCr(in Hsv color)
	{
		return YCbCrAndRgbConverter.Convert(ToRgb(in color));
	}

	public YCbCr ToYCbCr(in HunterLab color)
	{
		return ToYCbCr(ToCieXyz(in color));
	}

	public static YCbCr ToYCbCr(in LinearRgb color)
	{
		return YCbCrAndRgbConverter.Convert(ToRgb(in color));
	}

	public YCbCr ToYCbCr(in Lms color)
	{
		return ToYCbCr(ToCieXyz(in color));
	}

	public static YCbCr ToYCbCr(in Rgb color)
	{
		return YCbCrAndRgbConverter.Convert(in color);
	}
}
