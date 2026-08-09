using System;
using System.Globalization;

namespace ModuleWorks;

[Serializable]
public class BoundingBoxf
{
	public Vectorf LowerLeft { get; set; }

	public Vectorf UpperRight { get; set; }

	public float Diagonal => (float)Math.Sqrt(DiagonalSquare);

	public float DiagonalSquare => DeltaX * DeltaX + DeltaY * DeltaY + DeltaZ * DeltaZ;

	public Vectorf DiagonalVector => UpperRight - LowerLeft;

	public float DeltaX => UpperRight.X - LowerLeft.X;

	public float DeltaY => UpperRight.Y - LowerLeft.Y;

	public float DeltaZ => UpperRight.Z - LowerLeft.Z;

	public Vectorf Center => 0.5f * (LowerLeft + UpperRight);

	public float MaxExtent => Math.Max(Math.Max(DeltaX, DeltaY), DeltaZ);

	public BoundingBoxf()
	{
		LowerLeft = new Vectorf();
		UpperRight = new Vectorf();
	}

	public BoundingBoxf(Vectorf lowerLeft, Vectorf upperRight)
	{
		LowerLeft = new Vectorf(lowerLeft);
		UpperRight = new Vectorf(upperRight);
	}

	public BoundingBoxf(BoundingBoxd doubleBoundingBox)
	{
		if (doubleBoundingBox == null)
		{
			throw new ArgumentNullException("doubleBoundingBox");
		}
		LowerLeft = new Vectorf(doubleBoundingBox.LowerLeft);
		UpperRight = new Vectorf(doubleBoundingBox.UpperRight);
	}

	public void Scale(float factor)
	{
		float num = DeltaX * factor;
		float num2 = DeltaY * factor;
		float num3 = DeltaZ * factor;
		float num4 = (num - DeltaX) * 0.5f;
		float num5 = (num2 - DeltaY) * 0.5f;
		float num6 = (num3 - DeltaZ) * 0.5f;
		LowerLeft.X -= num4;
		LowerLeft.Y -= num5;
		LowerLeft.Z -= num6;
		UpperRight.X += num4;
		UpperRight.Y += num5;
		UpperRight.Z += num6;
	}

	public void Union(Vectorf vector)
	{
		for (int i = 0; i < 3; i++)
		{
			if (vector[i] < LowerLeft[i])
			{
				LowerLeft[i] = vector[i];
			}
			if (vector[i] > UpperRight[i])
			{
				UpperRight[i] = vector[i];
			}
		}
	}

	public BoundingBoxf Clone()
	{
		return new BoundingBoxf
		{
			LowerLeft = new Vectorf(LowerLeft.X, LowerLeft.Y, LowerLeft.Z),
			UpperRight = new Vectorf(UpperRight.X, UpperRight.Y, UpperRight.Z)
		};
	}

	public void Sort()
	{
		float x = Math.Min(LowerLeft.X, UpperRight.X);
		float y = Math.Min(LowerLeft.Y, UpperRight.Y);
		float z = Math.Min(LowerLeft.Z, UpperRight.Z);
		float x2 = Math.Max(LowerLeft.X, UpperRight.X);
		float y2 = Math.Max(LowerLeft.Y, UpperRight.Y);
		float z2 = Math.Max(LowerLeft.Z, UpperRight.Z);
		LowerLeft = new Vectorf(x, y, z);
		UpperRight = new Vectorf(x2, y2, z2);
	}

	public bool Contains(Vectorf point)
	{
		float num = Math.Max(LowerLeft.X, point.X);
		float num2 = Math.Max(LowerLeft.Y, point.Y);
		float num3 = Math.Max(LowerLeft.Z, point.Z);
		float num4 = Math.Min(UpperRight.X, point.X);
		float num5 = Math.Min(UpperRight.Y, point.Y);
		float num6 = Math.Min(UpperRight.Z, point.Z);
		if (point.X == num && point.Y == num2 && point.Z == num3 && point.X == num4 && point.Y == num5)
		{
			return point.Z == num6;
		}
		return false;
	}

	public void Uninitialize()
	{
		LowerLeft.X = 3E+38f;
		LowerLeft.Y = 3E+38f;
		LowerLeft.Z = 3E+38f;
		UpperRight.X = -3E+38f;
		UpperRight.Y = -3E+38f;
		UpperRight.Z = -3E+38f;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "DeltaX: {0:0.000}; DeltaY: {1:0.000}, DeltaZ: {2:0.000}", DeltaX, DeltaY, DeltaZ);
	}

	public static BoundingBoxf ComputeOverall(params BoundingBoxf[] boundingBoxes)
	{
		BoundingBoxf boundingBoxf = new BoundingBoxf(Vectorf.Max, Vectorf.Min);
		for (int i = 0; i < boundingBoxes.Length; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (boundingBoxes[i].LowerLeft[j] < boundingBoxf.LowerLeft[j])
				{
					boundingBoxf.LowerLeft[j] = boundingBoxes[i].LowerLeft[j];
				}
				if (boundingBoxes[i].UpperRight[j] > boundingBoxf.UpperRight[j])
				{
					boundingBoxf.UpperRight[j] = boundingBoxes[i].UpperRight[j];
				}
			}
		}
		return boundingBoxf;
	}
}
