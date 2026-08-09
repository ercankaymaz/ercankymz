using System;
using System.Globalization;

namespace ModuleWorks;

[Serializable]
public class BoundingBoxi
{
	public Vectori LowerLeft { get; set; }

	public Vectori UpperRight { get; set; }

	public int DiagonalSquare => DeltaX * DeltaX + DeltaY * DeltaY + DeltaZ * DeltaZ;

	public Vectori DiagonalVector => UpperRight - LowerLeft;

	public int DeltaX => UpperRight.X - LowerLeft.X;

	public int DeltaY => UpperRight.Y - LowerLeft.Y;

	public int DeltaZ => UpperRight.Z - LowerLeft.Z;

	public int MaxExtent => Math.Max(Math.Max(DeltaX, DeltaY), DeltaZ);

	public BoundingBoxi()
	{
		LowerLeft = new Vectori();
		UpperRight = new Vectori();
	}

	public BoundingBoxi(Vectori lowerLeft, Vectori upperRight)
	{
		LowerLeft = new Vectori(lowerLeft);
		UpperRight = new Vectori(upperRight);
	}

	public void Scale(int factor)
	{
		int num = DeltaX * factor;
		int num2 = DeltaY * factor;
		int num3 = DeltaZ * factor;
		int num4 = (num - DeltaX) / 2;
		int num5 = (num2 - DeltaY) / 2;
		int num6 = (num3 - DeltaZ) / 2;
		LowerLeft.X -= num4;
		LowerLeft.Y -= num5;
		LowerLeft.Z -= num6;
		UpperRight.X += num4;
		UpperRight.Y += num5;
		UpperRight.Z += num6;
	}

	public void Union(Vectori vector)
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

	public BoundingBoxi Clone()
	{
		return new BoundingBoxi
		{
			LowerLeft = new Vectori(LowerLeft.X, LowerLeft.Y, LowerLeft.Z),
			UpperRight = new Vectori(UpperRight.X, UpperRight.Y, UpperRight.Z)
		};
	}

	public void Sort()
	{
		int x = Math.Min(LowerLeft.X, UpperRight.X);
		int y = Math.Min(LowerLeft.Y, UpperRight.Y);
		int z = Math.Min(LowerLeft.Z, UpperRight.Z);
		int x2 = Math.Max(LowerLeft.X, UpperRight.X);
		int y2 = Math.Max(LowerLeft.Y, UpperRight.Y);
		int z2 = Math.Max(LowerLeft.Z, UpperRight.Z);
		LowerLeft = new Vectori(x, y, z);
		UpperRight = new Vectori(x2, y2, z2);
	}

	public bool Contains(Vectori point)
	{
		int num = Math.Max(LowerLeft.X, point.X);
		int num2 = Math.Max(LowerLeft.Y, point.Y);
		int num3 = Math.Max(LowerLeft.Z, point.Z);
		int num4 = Math.Min(UpperRight.X, point.X);
		int num5 = Math.Min(UpperRight.Y, point.Y);
		int num6 = Math.Min(UpperRight.Z, point.Z);
		if (point.X == num && point.Y == num2 && point.Z == num3 && point.X == num4 && point.Y == num5)
		{
			return point.Z == num6;
		}
		return false;
	}

	public void Uninitialize()
	{
		LowerLeft.X = int.MaxValue;
		LowerLeft.Y = int.MaxValue;
		LowerLeft.Z = int.MaxValue;
		UpperRight.X = -2147483647;
		UpperRight.Y = -2147483647;
		UpperRight.Z = -2147483647;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "DeltaX: {0:0}; DeltaY: {1:0}, DeltaZ: {2:0}", DeltaX, DeltaY, DeltaZ);
	}

	public static BoundingBoxi ComputeOverall(params BoundingBoxi[] boundingBoxes)
	{
		BoundingBoxi boundingBoxi = new BoundingBoxi(Vectori.Max, Vectori.Min);
		for (int i = 0; i < boundingBoxes.Length; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (boundingBoxes[i].LowerLeft[j] < boundingBoxi.LowerLeft[j])
				{
					boundingBoxi.LowerLeft[j] = boundingBoxes[i].LowerLeft[j];
				}
				if (boundingBoxes[i].UpperRight[j] > boundingBoxi.UpperRight[j])
				{
					boundingBoxi.UpperRight[j] = boundingBoxes[i].UpperRight[j];
				}
			}
		}
		return boundingBoxi;
	}
}
