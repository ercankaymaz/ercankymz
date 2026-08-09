using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Functions;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class LabColorSpaceDetails : ColorSpaceDetails
{
	private readonly CIEBasedColorSpaceTransformer colorSpaceTransformer;

	public override int NumberOfColorComponents => 3;

	public override int BaseNumberOfColorComponents => NumberOfColorComponents;

	public IReadOnlyList<double> WhitePoint { get; }

	public IReadOnlyList<double> BlackPoint { get; }

	public IReadOnlyList<double> Matrix { get; }

	public LabColorSpaceDetails(double[] whitePoint, double[]? blackPoint, double[]? matrix)
		: base(ColorSpace.Lab)
	{
		WhitePoint = whitePoint ?? throw new ArgumentNullException("whitePoint");
		if (whitePoint.Length != 3)
		{
			throw new ArgumentOutOfRangeException("whitePoint", whitePoint, $"Must consist of exactly three numbers, but was passed {whitePoint.Length}.");
		}
		BlackPoint = blackPoint ?? new double[3];
		if (BlackPoint.Count != 3)
		{
			throw new ArgumentOutOfRangeException("blackPoint", blackPoint, $"Must consist of exactly three numbers, but was passed {blackPoint.Length}.");
		}
		Matrix = matrix ?? new double[4] { -100.0, 100.0, -100.0, 100.0 };
		if (Matrix.Count != 4)
		{
			throw new ArgumentOutOfRangeException("matrix", matrix, $"Must consist of exactly four numbers, but was passed {matrix.Length}.");
		}
		colorSpaceTransformer = new CIEBasedColorSpaceTransformer((X: WhitePoint[0], Y: WhitePoint[1], Z: WhitePoint[2]), RGBWorkingSpace.sRGB);
	}

	private RGBColor TransformToRGB((double A, double B, double C) colorAbc)
	{
		double[] array = Process(colorAbc.A, colorAbc.B, colorAbc.C);
		return new RGBColor(array[0], array[1], array[2]);
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		byte[] array = new byte[decoded.Length];
		int num = 0;
		for (int i = 0; i < decoded.Length; i += 3)
		{
			double[] array2 = Process((double)(int)decoded[i] / 255.0, (double)(int)decoded[i + 1] / 255.0, (double)(int)decoded[i + 2] / 255.0);
			array[num++] = ColorSpaceDetails.ConvertToByte(array2[0]);
			array[num++] = ColorSpaceDetails.ConvertToByte(array2[1]);
			array[num++] = ColorSpaceDetails.ConvertToByte(array2[2]);
		}
		return array;
	}

	private static double g(double x)
	{
		if (x > 0.20689655172413793)
		{
			return x * x * x;
		}
		return 0.12841854934601665 * (x - 0.13793103448275862);
	}

	internal override double[] Process(params double[] values)
	{
		double num = PdfFunction.ClipToRange(values[1], Matrix[0], Matrix[1]);
		double num2 = PdfFunction.ClipToRange(values[2], Matrix[2], Matrix[3]);
		double num3 = (values[0] + 16.0) / 116.0;
		double x = num3 + num / 500.0;
		double x2 = num3 - num2 / 200.0;
		double item = WhitePoint[0] * g(x);
		double item2 = WhitePoint[1] * g(num3);
		double item3 = WhitePoint[2] * g(x2);
		var (num4, num5, num6) = colorSpaceTransformer.TransformToRGB((A: item, B: item2, C: item3));
		return new double[3] { num4, num5, num6 };
	}

	public override IColor GetColor(params double[] values)
	{
		if (values == null || values.Length != NumberOfColorComponents)
		{
			throw new ArgumentException($"Invalid number of inputs, expecting {NumberOfColorComponents} but got {((values != null) ? values.Length : 0)}", "values");
		}
		return TransformToRGB((A: values[0], B: values[1], C: values[2]));
	}

	public override IColor GetInitializeColor()
	{
		double item = PdfFunction.ClipToRange(0.0, Matrix[0], Matrix[1]);
		double item2 = PdfFunction.ClipToRange(0.0, Matrix[2], Matrix[3]);
		return TransformToRGB((A: 0.0, B: item, C: item2));
	}
}
