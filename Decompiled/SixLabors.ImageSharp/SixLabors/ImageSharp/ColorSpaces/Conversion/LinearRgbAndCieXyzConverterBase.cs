using System.Numerics;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal abstract class LinearRgbAndCieXyzConverterBase
{
	public static Matrix4x4 GetRgbToCieXyzMatrix(RgbWorkingSpace workingSpace)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		RgbPrimariesChromaticityCoordinates chromaticityCoordinates = workingSpace.ChromaticityCoordinates;
		float x = chromaticityCoordinates.R.X;
		float x2 = chromaticityCoordinates.G.X;
		float x3 = chromaticityCoordinates.B.X;
		float y = chromaticityCoordinates.R.Y;
		float y2 = chromaticityCoordinates.G.Y;
		float y3 = chromaticityCoordinates.B.Y;
		float num = x / y;
		float num2 = (1f - x - y) / y;
		float num3 = x2 / y2;
		float num4 = (1f - x2 - y2) / y2;
		float num5 = x3 / y3;
		float num6 = (1f - x3 - y3) / y3;
		Matrix4x4 val = default(Matrix4x4);
		Matrix4x4.Invert(new Matrix4x4
		{
			M11 = num,
			M21 = num3,
			M31 = num5,
			M12 = 1f,
			M22 = 1f,
			M32 = 1f,
			M13 = num2,
			M23 = num4,
			M33 = num6,
			M44 = 1f
		}, ref val);
		Vector3 val2 = Vector3.Transform(workingSpace.WhitePoint.ToVector3(), val);
		return new Matrix4x4
		{
			M11 = val2.X * num,
			M21 = val2.Y * num3,
			M31 = val2.Z * num5,
			M12 = val2.X * 1f,
			M22 = val2.Y * 1f,
			M32 = val2.Z * 1f,
			M13 = val2.X * num2,
			M23 = val2.Y * num4,
			M33 = val2.Z * num6,
			M44 = 1f
		};
	}
}
