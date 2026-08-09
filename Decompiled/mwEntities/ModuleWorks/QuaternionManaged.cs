using System;

namespace ModuleWorks;

[Serializable]
public class QuaternionManaged
{
	public float X { get; set; }

	public float Y { get; set; }

	public float Z { get; set; }

	public float W { get; set; }

	public QuaternionManaged()
	{
	}

	public QuaternionManaged(TransformationMatrixManaged matrix)
	{
		FromMatrix(matrix);
	}

	public void FromMatrix(TransformationMatrixManaged matrix)
	{
		float[] data = matrix.GetData();
		Vectorf vectorf = new Vectorf(data[0], data[4], data[8]);
		Vectorf vectorf2 = new Vectorf(data[1], data[5], data[9]);
		Vectorf vectorf3 = new Vectorf(data[2], data[6], data[10]);
		Vectorf vectorf4 = vectorf;
		Vectorf vectorf5 = vectorf2;
		Vectorf vectorf6 = vectorf3;
		vectorf4.Normalize();
		vectorf5.Normalize();
		vectorf6.Normalize();
		float num = vectorf4.X + vectorf5.Y + vectorf6.Z;
		if ((double)num > 0.0)
		{
			W = (float)Math.Sqrt(1.0 + (double)num) * 0.5f;
			float num2 = (float)(1.0 / (4.0 * (double)W));
			X = num2 * (vectorf5.Z - vectorf6.Y);
			Y = num2 * (vectorf6.X - vectorf4.Z);
			Z = num2 * (vectorf4.Y - vectorf5.X);
		}
		else if ((double)vectorf4.X >= (double)vectorf5.Y && (double)vectorf4.X >= (double)vectorf6.Z)
		{
			X = (float)Math.Sqrt(1.0 + (double)vectorf4.X - (double)vectorf5.Y - (double)vectorf6.Z) * 0.5f;
			float num3 = (float)(1.0 / (4.0 * (double)X));
			W = num3 * (vectorf5.Z - vectorf6.Y);
			Y = num3 * (vectorf4.Y + vectorf5.X);
			Z = num3 * (vectorf6.X + vectorf4.Z);
		}
		else if ((double)vectorf5.Y >= (double)vectorf6.Z && (double)vectorf5.Y >= (double)vectorf4.X)
		{
			Y = (float)Math.Sqrt(1.0 - (double)vectorf4.X + (double)vectorf5.Y - (double)vectorf6.Z) * 0.5f;
			float num4 = (float)(1.0 / (4.0 * (double)Y));
			W = num4 * (vectorf6.X - vectorf4.Z);
			X = num4 * (vectorf4.Y + vectorf5.X);
			Z = num4 * (vectorf5.Z + vectorf6.Y);
		}
		else
		{
			Z = (float)Math.Sqrt(1.0 - (double)vectorf4.X - (double)vectorf5.Y + (double)vectorf6.Z) * 0.5f;
			float num5 = (float)(1.0 / (4.0 * (double)Z));
			W = num5 * (vectorf4.Y - vectorf5.X);
			X = num5 * (vectorf4.Z + vectorf6.X);
			Y = num5 * (vectorf5.Z + vectorf6.Y);
		}
		float num6 = 1f / (float)Math.Sqrt((double)X * (double)X + (double)Y * (double)Y + (double)Z * (double)Z + (double)W * (double)W);
		X *= num6;
		Y *= num6;
		Z *= num6;
		W *= num6;
	}
}
