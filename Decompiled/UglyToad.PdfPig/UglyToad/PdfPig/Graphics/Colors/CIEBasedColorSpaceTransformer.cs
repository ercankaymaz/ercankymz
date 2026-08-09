using System;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Graphics.Colors;

internal class CIEBasedColorSpaceTransformer
{
	private readonly RGBWorkingSpace destinationWorkingSpace;

	private readonly Matrix3x3 transformationMatrix;

	private readonly ChromaticAdaptation chromaticAdaptation;

	public Func<(double A, double B, double C), (double A, double B, double C)> DecoderABC { get; set; } = ((double A, double B, double C) color) => color;

	public Func<(double L, double M, double N), (double L, double M, double N)> DecoderLMN { get; set; } = ((double L, double M, double N) color) => color;

	public Matrix3x3 MatrixABC { get; set; } = Matrix3x3.Identity;

	public Matrix3x3 MatrixLMN { get; set; } = Matrix3x3.Identity;

	public CIEBasedColorSpaceTransformer((double X, double Y, double Z) sourceReferenceWhite, RGBWorkingSpace destinationWorkingSpace)
	{
		this.destinationWorkingSpace = destinationWorkingSpace;
		chromaticAdaptation = new ChromaticAdaptation(sourceReferenceWhite, destinationWorkingSpace.ReferenceWhite);
		double item = destinationWorkingSpace.RedPrimary.x;
		double item2 = destinationWorkingSpace.RedPrimary.y;
		double item3 = destinationWorkingSpace.GreenPrimary.x;
		double item4 = destinationWorkingSpace.GreenPrimary.y;
		double item5 = destinationWorkingSpace.BluePrimary.x;
		double item6 = destinationWorkingSpace.BluePrimary.y;
		double num = item / item2;
		int num2 = 1;
		double num3 = (1.0 - item - item2) / item2;
		double num4 = item3 / item4;
		int num5 = 1;
		double num6 = (1.0 - item3 - item4) / item4;
		double num7 = item5 / item6;
		int num8 = 1;
		double num9 = (1.0 - item5 - item6) / item6;
		(double, double, double) tuple = new Matrix3x3(num, num4, num7, num2, num5, num8, num3, num6, num9).Inverse().Multiply(destinationWorkingSpace.ReferenceWhite);
		double item7 = tuple.Item1;
		double item8 = tuple.Item2;
		double item9 = tuple.Item3;
		Matrix3x3 matrix3x = new Matrix3x3(item7 * num, item8 * num4, item9 * num7, item7 * (double)num2, item8 * (double)num5, item9 * (double)num8, item7 * num3, item8 * num6, item9 * num9);
		transformationMatrix = matrix3x.Inverse();
	}

	public (double R, double G, double B) TransformToRGB((double A, double B, double C) color)
	{
		(double, double, double) sourceColor = TransformToXYZ(color);
		(double, double, double) vector = chromaticAdaptation.Transform(sourceColor);
		(double, double, double) tuple = transformationMatrix.Multiply(vector);
		double value = destinationWorkingSpace.GammaCorrection(tuple.Item1);
		double value2 = destinationWorkingSpace.GammaCorrection(tuple.Item2);
		return new ValueTuple<double, double, double>(item3: Clamp(destinationWorkingSpace.GammaCorrection(tuple.Item3)), item1: Clamp(value), item2: Clamp(value2));
	}

	private (double X, double Y, double Z) TransformToXYZ((double A, double B, double C) color)
	{
		(double, double, double) vector = DecoderABC(color);
		(double, double, double) arg = MatrixABC.Multiply(vector);
		(double, double, double) vector2 = DecoderLMN(arg);
		return MatrixLMN.Multiply(vector2);
	}

	private static double Clamp(double value)
	{
		if (!(value < 0.0))
		{
			if (!(value > 1.0))
			{
				return value;
			}
			return 1.0;
		}
		return 0.0;
	}
}
