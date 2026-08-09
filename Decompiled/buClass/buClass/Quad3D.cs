using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Quad3D
{
	public Pnt3D FirstPoint = new Pnt3D();

	public Pnt3D SecondPoint = new Pnt3D();

	public Pnt3D ThirdPoint = new Pnt3D();

	public Pnt3D FourthPoint = new Pnt3D();

	public Quad3D()
	{
	}

	public Quad3D(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint, Pnt3D FourthPoint)
	{
		this.FirstPoint = new Pnt3D(FirstPoint);
		this.SecondPoint = new Pnt3D(SecondPoint);
		this.ThirdPoint = new Pnt3D(ThirdPoint);
		this.FourthPoint = new Pnt3D(FourthPoint);
	}

	public Quad3D(Quad3D Quad)
	{
		FirstPoint = new Pnt3D(Quad.FirstPoint);
		SecondPoint = new Pnt3D(Quad.SecondPoint);
		ThirdPoint = new Pnt3D(Quad.ThirdPoint);
		FourthPoint = new Pnt3D(Quad.FourthPoint);
	}

	public static Quad3D Copy(Quad3D P)
	{
		return new Quad3D(P.FirstPoint, P.SecondPoint, P.ThirdPoint, P.FourthPoint);
	}

	public static Quad3D[] Copy(Quad3D[] pts)
	{
		Quad3D[] array = new Quad3D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Quad3D> Copy(List<Quad3D> pts)
	{
		List<Quad3D> list = new List<Quad3D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Quad3D> pts, ref List<Quad3D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static bool IsValid(Quad3D quad)
	{
		try
		{
			if (quad == null)
			{
				return false;
			}
			Pnt3D MinPoint = new Pnt3D();
			Pnt3D MidPoint = new Pnt3D();
			Pnt3D MaxPoint = new Pnt3D();
			List<Pnt3D> list = new List<Pnt3D>();
			list.Add(new Pnt3D(quad.FirstPoint));
			list.Add(new Pnt3D(quad.SecondPoint));
			list.Add(new Pnt3D(quad.ThirdPoint));
			list.Add(new Pnt3D(quad.FourthPoint));
			Pnt3D.BoxSizeOfPoint(list, ref MinPoint, ref MidPoint, ref MaxPoint);
			if (MinPoint == MaxPoint)
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public override string ToString()
	{
		return "First  [ X:" + FirstPoint.X.ToString("f4") + "; Y:" + FirstPoint.Y.ToString("f4") + "; Z:" + FirstPoint.Z.ToString("f4") + " ]  |  Second  [ X:" + SecondPoint.X.ToString("f4") + "; Y:" + SecondPoint.Y.ToString("f4") + "; Z:" + SecondPoint.Z.ToString("f4") + " ]  |  Third  [ X:" + ThirdPoint.X.ToString("f4") + "; Y:" + ThirdPoint.Y.ToString("f4") + "; Z:" + ThirdPoint.Z.ToString("f4") + " ]  |  Fourth  [ X:" + FourthPoint.X.ToString("f4") + "; Y:" + FourthPoint.Y.ToString("f4") + "; Z:" + FourthPoint.Z.ToString("f4") + " ]";
	}

	public static Quad3D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo cultureInfo = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			string[] array = Value.Split('|');
			if (array.Length == 4)
			{
				Pnt3D firstPoint = new Pnt3D(Pnt3D.DecodeFromString(array[0]));
				Pnt3D secondPoint = new Pnt3D(Pnt3D.DecodeFromString(array[1]));
				Pnt3D thirdPoint = new Pnt3D(Pnt3D.DecodeFromString(array[2]));
				Pnt3D fourthPoint = new Pnt3D(Pnt3D.DecodeFromString(array[3]));
				return new Quad3D(firstPoint, secondPoint, thirdPoint, fourthPoint);
			}
			return new Quad3D();
		}
		catch (Exception)
		{
			return new Quad3D();
		}
	}

	public string ToDef()
	{
		return "X:" + FirstPoint.X.ToString("") + "; Y:" + FirstPoint.Y.ToString("") + "; Z:" + FirstPoint.Z.ToString("") + " | X:" + SecondPoint.X.ToString("") + "; Y:" + SecondPoint.Y.ToString("") + "; Z:" + SecondPoint.Z.ToString("") + " | X:" + ThirdPoint.X.ToString("") + "; Y:" + ThirdPoint.Y.ToString("") + "; Z:" + ThirdPoint.Z.ToString("") + " | X:" + FourthPoint.X.ToString("") + "; Y:" + FourthPoint.Y.ToString("") + "; Z:" + FourthPoint.Z.ToString("");
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + FirstPoint.X.ToString("") + "; Y:" + FirstPoint.Y.ToString("") + "; Z:" + FirstPoint.Z.ToString("") + " | X:" + SecondPoint.X.ToString("") + "; Y:" + SecondPoint.Y.ToString("") + "; Z:" + SecondPoint.Z.ToString("") + " | X:" + ThirdPoint.X.ToString("") + "; Y:" + ThirdPoint.Y.ToString("") + "; Z:" + ThirdPoint.Z.ToString("") + " | X:" + FourthPoint.X.ToString("") + "; Y:" + FourthPoint.Y.ToString("") + "; Z:" + FourthPoint.Z.ToString("");
	}
}
