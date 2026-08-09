using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Functions;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class ICCBasedColorSpaceDetails : ColorSpaceDetails
{
	public override int NumberOfColorComponents { get; }

	public override int BaseNumberOfColorComponents => NumberOfColorComponents;

	public ColorSpaceDetails AlternateColorSpace { get; }

	public IReadOnlyList<double> Range { get; }

	public XmpMetadata? Metadata { get; }

	internal ICCBasedColorSpaceDetails(int numberOfColorComponents, ColorSpaceDetails? alternateColorSpaceDetails, IReadOnlyList<double>? range, XmpMetadata? metadata)
		: base(ColorSpace.ICCBased)
	{
		if (numberOfColorComponents != 1 && numberOfColorComponents != 3 && numberOfColorComponents != 4)
		{
			throw new ArgumentOutOfRangeException("numberOfColorComponents", "must be 1, 3 or 4");
		}
		NumberOfColorComponents = numberOfColorComponents;
		AlternateColorSpace = alternateColorSpaceDetails ?? ((NumberOfColorComponents == 1) ? DeviceGrayColorSpaceDetails.Instance : ((NumberOfColorComponents == 3) ? ((ColorSpaceDetails)DeviceRgbColorSpaceDetails.Instance) : ((ColorSpaceDetails)DeviceCmykColorSpaceDetails.Instance)));
		base.BaseType = AlternateColorSpace.BaseType;
		Range = range ?? (from x in Enumerable.Range(0, numberOfColorComponents)
			select new double[2] { 0.0, 1.0 }).SelectMany((double[] x) => x).ToArray();
		if (Range.Count != 2 * numberOfColorComponents)
		{
			throw new ArgumentOutOfRangeException("range", range, $"Must consist of exactly {2 * numberOfColorComponents} (2 x NumberOfColorComponents), but was passed {range?.Count ?? 0}");
		}
		Metadata = metadata;
	}

	internal override double[] Process(params double[] values)
	{
		return AlternateColorSpace.Process(values);
	}

	public override IColor GetColor(params double[] values)
	{
		if (values == null || values.Length != NumberOfColorComponents)
		{
			throw new ArgumentException($"Invalid number of inputs, expecting {NumberOfColorComponents} but got {((values != null) ? values.Length : 0)}", "values");
		}
		for (int i = 0; i < values.Length; i++)
		{
			int num = 2 * i;
			values[i] = PdfFunction.ClipToRange(values[i], Range[num], Range[num + 1]);
		}
		return AlternateColorSpace.GetColor(values);
	}

	public override IColor GetInitializeColor()
	{
		double[] values = Enumerable.Repeat(PdfFunction.ClipToRange(0.0, Range[0], Range[1]), NumberOfColorComponents).ToArray();
		return GetColor(values);
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		return AlternateColorSpace.Transform(decoded);
	}
}
