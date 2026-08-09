using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Line3D
{
	public Pnt3D Start = new Pnt3D();

	public Pnt3D End = new Pnt3D();

	public Line3D()
	{
	}

	public Line3D(Pnt3D StartPoint, Pnt3D EndPoint)
	{
		Start = new Pnt3D(StartPoint);
		End = new Pnt3D(EndPoint);
	}

	public Line3D(Line3D Line)
	{
		Start = new Pnt3D(Line.Start);
		End = new Pnt3D(Line.End);
	}

	public static Line3D Copy(Line3D P)
	{
		return new Line3D(P.Start, P.End);
	}

	public static Line3D[] Copy(Line3D[] pts)
	{
		Line3D[] array = new Line3D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Line3D> Copy(List<Line3D> pts)
	{
		List<Line3D> list = new List<Line3D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Line3D> pts, ref List<Line3D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public override string ToString()
	{
		return "Start  [ X:" + Start.X.ToString("f4") + "; Y:" + Start.Y.ToString("f4") + "; Z:" + Start.Z.ToString("f4") + " ]  |  End  [ X:" + End.X.ToString("f4") + "; Y:" + End.Y.ToString("f4") + "; Z:" + End.Z.ToString("f4") + " ]";
	}

	public static Line3D DecodeFromString(string Value)
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
			if (array.Length == 2)
			{
				Pnt3D startPoint = new Pnt3D(Pnt3D.DecodeFromString(array[0]));
				Pnt3D endPoint = new Pnt3D(Pnt3D.DecodeFromString(array[1]));
				return new Line3D(startPoint, endPoint);
			}
			return new Line3D();
		}
		catch (Exception)
		{
			return new Line3D();
		}
	}

	public string ToDef()
	{
		return "X:" + Start.X.ToString("") + "; Y:" + Start.Y.ToString("") + "; Z:" + Start.Z.ToString("") + " | X:" + End.X.ToString("") + "; Y:" + End.Y.ToString("") + "; Z:" + End.Z.ToString("");
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + Start.X.ToString("") + "; Y:" + Start.Y.ToString("") + "; Z:" + Start.Z.ToString("") + " | X:" + End.X.ToString("") + "; Y:" + End.Y.ToString("") + "; Z:" + End.Z.ToString("");
	}
}
