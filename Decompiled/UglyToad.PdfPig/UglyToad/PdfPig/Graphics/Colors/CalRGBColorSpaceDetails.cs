using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class CalRGBColorSpaceDetails : ColorSpaceDetails
{
	private readonly CIEBasedColorSpaceTransformer colorSpaceTransformer;

	public override int NumberOfColorComponents => 3;

	public override int BaseNumberOfColorComponents => NumberOfColorComponents;

	public IReadOnlyList<double> WhitePoint { get; }

	public IReadOnlyList<double> BlackPoint { get; }

	public IReadOnlyList<double> Gamma { get; }

	public IReadOnlyList<double> Matrix { get; }

	public CalRGBColorSpaceDetails(double[] whitePoint, double[]? blackPoint, double[]? gamma, double[]? matrix)
		: base(ColorSpace.CalRGB)
	{
		WhitePoint = whitePoint ?? throw new ArgumentNullException("whitePoint");
		if (WhitePoint.Count != 3)
		{
			throw new ArgumentOutOfRangeException("whitePoint", whitePoint, $"Must consist of exactly three numbers, but was passed {whitePoint.Length}.");
		}
		BlackPoint = blackPoint ?? new double[3];
		if (BlackPoint.Count != 3)
		{
			throw new ArgumentOutOfRangeException("blackPoint", blackPoint, $"Must consist of exactly three numbers, but was passed {blackPoint.Length}.");
		}
		Gamma = gamma ?? new double[3] { 1.0, 1.0, 1.0 };
		if (Gamma.Count != 3)
		{
			throw new ArgumentOutOfRangeException("gamma", gamma, $"Must consist of exactly three numbers, but was passed {gamma.Length}.");
		}
		Matrix = matrix ?? new double[9] { 1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0 };
		if (Matrix.Count != 9)
		{
			throw new ArgumentOutOfRangeException("matrix", matrix, $"Must consist of exactly nine numbers, but was passed {matrix.Length}.");
		}
		colorSpaceTransformer = new CIEBasedColorSpaceTransformer((X: WhitePoint[0], Y: WhitePoint[1], Z: WhitePoint[2]), RGBWorkingSpace.sRGB)
		{
			DecoderABC = ((double A, double B, double C) color) => (A: Math.Pow(color.A, Gamma[0]), B: Math.Pow(color.B, Gamma[1]), C: Math.Pow(color.C, Gamma[2])),
			MatrixABC = new Matrix3x3(Matrix[0], Matrix[3], Matrix[6], Matrix[1], Matrix[4], Matrix[7], Matrix[2], Matrix[5], Matrix[8])
		};
	}

	private RGBColor TransformToRGB((double A, double B, double C) colorAbc)
	{
		var (r, g, b) = colorSpaceTransformer.TransformToRGB((A: colorAbc.A, B: colorAbc.B, C: colorAbc.C));
		return new RGBColor(r, g, b);
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

	internal override double[] Process(params double[] values)
	{
		var (num, num2, num3) = colorSpaceTransformer.TransformToRGB((A: values[0], B: values[1], C: values[2]));
		return new double[3] { num, num2, num3 };
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
		return TransformToRGB((A: 0.0, B: 0.0, C: 0.0));
	}
}
