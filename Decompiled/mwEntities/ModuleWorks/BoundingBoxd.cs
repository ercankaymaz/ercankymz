using System;
using System.Globalization;

namespace ModuleWorks;

[Serializable]
public class BoundingBoxd
{
	public Vectord LowerLeft { get; set; }

	public Vectord UpperRight { get; set; }

	public double Diagonal => Math.Sqrt(DeltaX * DeltaX + DeltaY * DeltaY + DeltaZ * DeltaZ);

	public double DeltaX => UpperRight.X - LowerLeft.X;

	public double DeltaY => UpperRight.Y - LowerLeft.Y;

	public double DeltaZ => UpperRight.Z - LowerLeft.Z;

	public Vectord Center => 0.5 * (LowerLeft + UpperRight);

	public double MaxExtent => Math.Max(Math.Max(DeltaX, DeltaY), DeltaZ);

	public BoundingBoxd()
	{
		LowerLeft = new Vectord();
		UpperRight = new Vectord();
	}

	public BoundingBoxd(Vectord lowerLeft, Vectord upperRight)
	{
		LowerLeft = new Vectord(lowerLeft);
		UpperRight = new Vectord(upperRight);
	}

	public BoundingBoxd(BoundingBoxf floatBoundingBox)
	{
		if (floatBoundingBox == null)
		{
			throw new ArgumentNullException("floatBoundingBox");
		}
		LowerLeft = new Vectord(floatBoundingBox.LowerLeft);
		UpperRight = new Vectord(floatBoundingBox.UpperRight);
	}

	public void Scale(double factor)
	{
		double num = DeltaX * factor;
		double num2 = DeltaY * factor;
		double num3 = DeltaZ * factor;
		double num4 = (num - DeltaX) * 0.5;
		double num5 = (num2 - DeltaY) * 0.5;
		double num6 = (num3 - DeltaZ) * 0.5;
		LowerLeft.X -= num4;
		LowerLeft.Y -= num5;
		LowerLeft.Z -= num6;
		UpperRight.X += num4;
		UpperRight.Y += num5;
		UpperRight.Z += num6;
	}

	public void Union(Vectord vector)
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

	public BoundingBoxd Clone()
	{
		return new BoundingBoxd
		{
			LowerLeft = new Vectord(LowerLeft.X, LowerLeft.Y, LowerLeft.Z),
			UpperRight = new Vectord(UpperRight.X, UpperRight.Y, UpperRight.Z)
		};
	}

	public void Sort()
	{
		double x = Math.Min(LowerLeft.X, UpperRight.X);
		double y = Math.Min(LowerLeft.Y, UpperRight.Y);
		double z = Math.Min(LowerLeft.Z, UpperRight.Z);
		double x2 = Math.Max(LowerLeft.X, UpperRight.X);
		double y2 = Math.Max(LowerLeft.Y, UpperRight.Y);
		double z2 = Math.Max(LowerLeft.Z, UpperRight.Z);
		LowerLeft = new Vectord(x, y, z);
		UpperRight = new Vectord(x2, y2, z2);
	}

	public bool Contains(Vectord point)
	{
		double num = Math.Max(LowerLeft.X, point.X);
		double num2 = Math.Max(LowerLeft.Y, point.Y);
		double num3 = Math.Max(LowerLeft.Z, point.Z);
		double num4 = Math.Min(UpperRight.X, point.X);
		double num5 = Math.Min(UpperRight.Y, point.Y);
		double num6 = Math.Min(UpperRight.Z, point.Z);
		if (point.X == num && point.Y == num2 && point.Z == num3 && point.X == num4 && point.Y == num5)
		{
			return point.Z == num6;
		}
		return false;
	}

	public void Uninitialize()
	{
		LowerLeft.X = 1E+308;
		LowerLeft.Y = 1E+308;
		LowerLeft.Z = 1E+308;
		UpperRight.X = -1E+308;
		UpperRight.Y = -1E+308;
		UpperRight.Z = -1E+308;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "DeltaX: {0:0.000}; DeltaY: {1:0.000}, DeltaZ: {2:0.000}", DeltaX, DeltaY, DeltaZ);
	}

	public static BoundingBoxd ComputeOverall(params BoundingBoxd[] boundingBoxes)
	{
		BoundingBoxd boundingBoxd = new BoundingBoxd(Vectord.Max, Vectord.Min);
		for (int i = 0; i < boundingBoxes.Length; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (boundingBoxes[i].LowerLeft[j] < boundingBoxd.LowerLeft[j])
				{
					boundingBoxd.LowerLeft[j] = boundingBoxes[i].LowerLeft[j];
				}
				if (boundingBoxes[i].UpperRight[j] > boundingBoxd.UpperRight[j])
				{
					boundingBoxd.UpperRight[j] = boundingBoxes[i].UpperRight[j];
				}
			}
		}
		return boundingBoxd;
	}
}
