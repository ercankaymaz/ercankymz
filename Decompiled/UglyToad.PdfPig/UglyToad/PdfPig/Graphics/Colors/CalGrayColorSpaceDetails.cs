using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class CalGrayColorSpaceDetails : ColorSpaceDetails
{
	private readonly CIEBasedColorSpaceTransformer colorSpaceTransformer;

	public override int NumberOfColorComponents => 1;

	public override int BaseNumberOfColorComponents => NumberOfColorComponents;

	public IReadOnlyList<double> WhitePoint { get; }

	public IReadOnlyList<double> BlackPoint { get; }

	public double Gamma { get; }

	public CalGrayColorSpaceDetails(double[] whitePoint, double[]? blackPoint, double? gamma)
		: base(ColorSpace.CalGray)
	{
		WhitePoint = whitePoint ?? throw new ArgumentNullException("whitePoint");
		if (WhitePoint.Count != 3)
		{
			throw new ArgumentOutOfRangeException("whitePoint", whitePoint, $"Must consist of exactly three numbers, but was passed {whitePoint.Length}.");
		}
		BlackPoint = blackPoint ?? new double[3];
		if (BlackPoint.Count != 3)
		{
			throw new ArgumentOutOfRangeException("blackPoint", blackPoint, $"Must consist of exactly three numbers, but was passed {((blackPoint != null) ? blackPoint.Length : 0)}.");
		}
		Gamma = gamma ?? 1.0;
		colorSpaceTransformer = new CIEBasedColorSpaceTransformer((X: WhitePoint[0], Y: WhitePoint[1], Z: WhitePoint[2]), RGBWorkingSpace.sRGB)
		{
			DecoderABC = ((double A, double B, double C) color) => (A: Math.Pow(color.A, Gamma), B: Math.Pow(color.B, Gamma), C: Math.Pow(color.C, Gamma)),
			MatrixABC = new Matrix3x3(WhitePoint[0], 0.0, 0.0, 0.0, WhitePoint[1], 0.0, 0.0, 0.0, WhitePoint[2])
		};
	}

	private RGBColor TransformToRGB(double colorA)
	{
		var (r, g, b) = colorSpaceTransformer.TransformToRGB((A: colorA, B: colorA, C: colorA));
		return new RGBColor(r, g, b);
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		byte[] array = new byte[decoded.Length];
		for (int i = 0; i < decoded.Length; i++)
		{
			double num = (double)(int)decoded[i] / 255.0;
			double[] array2 = Process(num);
			array[i] = ColorSpaceDetails.ConvertToByte(array2[0]);
		}
		return array;
	}

	internal override double[] Process(params double[] values)
	{
		double item = colorSpaceTransformer.TransformToRGB((A: values[0], B: values[0], C: values[0])).R;
		return new double[1] { item };
	}

	public override IColor GetColor(params double[] values)
	{
		if (values == null || values.Length != NumberOfColorComponents)
		{
			throw new ArgumentException($"Invalid number of inputs, expecting {NumberOfColorComponents} but got {((values != null) ? values.Length : 0)}", "values");
		}
		return TransformToRGB(values[0]);
	}

	public override IColor GetInitializeColor()
	{
		return GetColor(default(double));
	}
}
