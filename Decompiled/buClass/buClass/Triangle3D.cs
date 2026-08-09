using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Triangle3D
{
	public Pnt3D FirstPoint = new Pnt3D();

	public Pnt3D SecondPoint = new Pnt3D();

	public Pnt3D ThirdPoint = new Pnt3D();

	public Triangle3D()
	{
	}

	public Triangle3D(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint)
	{
		this.FirstPoint = new Pnt3D(FirstPoint);
		this.SecondPoint = new Pnt3D(SecondPoint);
		this.ThirdPoint = new Pnt3D(ThirdPoint);
	}

	public Triangle3D(Triangle3D Triangle)
	{
		FirstPoint = new Pnt3D(Triangle.FirstPoint);
		SecondPoint = new Pnt3D(Triangle.SecondPoint);
		ThirdPoint = new Pnt3D(Triangle.ThirdPoint);
	}

	public static Triangle3D Copy(Triangle3D P)
	{
		return new Triangle3D(P.FirstPoint, P.SecondPoint, P.ThirdPoint);
	}

	public static Triangle3D[] Copy(Triangle3D[] pts)
	{
		Triangle3D[] array = new Triangle3D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Triangle3D> Copy(List<Triangle3D> pts)
	{
		List<Triangle3D> list = new List<Triangle3D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Triangle3D> pts, ref List<Triangle3D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Triangle3D> pts, ref List<Triangle3D> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public override string ToString()
	{
		return "First  [ X:" + FirstPoint.X.ToString("f4") + "; Y:" + FirstPoint.Y.ToString("f4") + "; Z:" + FirstPoint.Z.ToString("f4") + " ]  |  Second  [ X:" + SecondPoint.X.ToString("f4") + "; Y:" + SecondPoint.Y.ToString("f4") + "; Z:" + SecondPoint.Z.ToString("f4") + " ]  |  Third  [ X:" + ThirdPoint.X.ToString("f4") + "; Y:" + ThirdPoint.Y.ToString("f4") + "; Z:" + ThirdPoint.Z.ToString("f4") + " ]";
	}

	public static Triangle3D DecodeFromString(string Value)
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
			if (array.Length == 3)
			{
				Pnt3D firstPoint = new Pnt3D(Pnt3D.DecodeFromString(array[0]));
				Pnt3D secondPoint = new Pnt3D(Pnt3D.DecodeFromString(array[1]));
				Pnt3D thirdPoint = new Pnt3D(Pnt3D.DecodeFromString(array[2]));
				return new Triangle3D(firstPoint, secondPoint, thirdPoint);
			}
			return new Triangle3D();
		}
		catch (Exception)
		{
			return new Triangle3D();
		}
	}

	public string ToDef()
	{
		return "X:" + FirstPoint.X.ToString("") + "; Y:" + FirstPoint.Y.ToString("") + "; Z:" + FirstPoint.Z.ToString("") + " | X:" + SecondPoint.X.ToString("") + "; Y:" + SecondPoint.Y.ToString("") + "; Z:" + SecondPoint.Z.ToString("") + " | X:" + ThirdPoint.X.ToString("") + "; Y:" + ThirdPoint.Y.ToString("") + "; Z:" + ThirdPoint.Z.ToString("");
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + FirstPoint.X.ToString("") + "; Y:" + FirstPoint.Y.ToString("") + "; Z:" + FirstPoint.Z.ToString("") + " | X:" + SecondPoint.X.ToString("") + "; Y:" + SecondPoint.Y.ToString("") + "; Z:" + SecondPoint.Z.ToString("") + " | X:" + ThirdPoint.X.ToString("") + "; Y:" + ThirdPoint.Y.ToString("") + "; Z:" + ThirdPoint.Z.ToString("");
	}
}
