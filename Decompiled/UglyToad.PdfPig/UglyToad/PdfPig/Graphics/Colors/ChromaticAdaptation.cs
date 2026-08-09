using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Graphics.Colors;

internal class ChromaticAdaptation
{
	public enum Method
	{
		XYZScaling,
		Bradford,
		VonKries
	}

	private readonly Matrix3x3 adaptationMatrix;

	public ChromaticAdaptation((double Xws, double Yws, double Zws) sourceReferenceWhite, (double Xwd, double Ywd, double Zwd) destinationReferenceWhite, Method method = Method.Bradford)
	{
		Matrix3x3 coneResponseDomain = GetConeResponseDomain(method);
		Matrix3x3 matrix3x = coneResponseDomain.Inverse();
		(double, double, double) tuple = coneResponseDomain.Multiply(sourceReferenceWhite);
		double item = tuple.Item1;
		double item2 = tuple.Item2;
		double item3 = tuple.Item3;
		(double, double, double) tuple2 = coneResponseDomain.Multiply(destinationReferenceWhite);
		double item4 = tuple2.Item1;
		double item5 = tuple2.Item2;
		double item6 = tuple2.Item3;
		Matrix3x3 matrix = new Matrix3x3(item4 / item, 0.0, 0.0, 0.0, item5 / item2, 0.0, 0.0, 0.0, item6 / item3);
		adaptationMatrix = matrix3x.Multiply(matrix).Multiply(coneResponseDomain);
	}

	public (double X, double Y, double Z) Transform((double X, double Y, double Z) sourceColor)
	{
		return adaptationMatrix.Multiply(sourceColor);
	}

	private static Matrix3x3 GetConeResponseDomain(Method method)
	{
		return method switch
		{
			Method.XYZScaling => new Matrix3x3(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 1.0), 
			Method.Bradford => new Matrix3x3(0.8951, 0.2664, -0.1614, -0.7502, 1.7135, 0.0367, 0.0389, -0.0685, 1.0296), 
			Method.VonKries => new Matrix3x3(0.40024, 0.7076, -0.08081, -0.2263, 1.16532, 0.0457, 0.0, 0.0, 0.91822), 
			_ => GetConeResponseDomain(Method.Bradford), 
		};
	}
}
