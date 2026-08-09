using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt2D : buSerilization
{
	public double X;

	public double Y;

	public double Option;

	public Pnt2D()
	{
	}

	public Pnt2D(Pnt2D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
	}

	public Pnt2D(Pnt9D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
	}

	public Pnt2D(Pnt6D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
	}

	public Pnt2D(double x, double y)
	{
		X = x;
		Y = y;
	}

	public static bool Equal(Pnt2D RefP1, Pnt2D RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Pnt2D RefP1, Pnt2D RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public bool Equal(Pnt2D RefP)
	{
		double num = X - RefP.X;
		double num2 = Y - RefP.Y;
		double num3 = Math.Sqrt(num * num + num2 * num2);
		if (num3 < buSystem.resolutionCompare)
		{
			return true;
		}
		return false;
	}

	public bool Equal(Pnt2D RefP, double Resolution)
	{
		double num = X - RefP.X;
		double num2 = Y - RefP.Y;
		double num3 = Math.Sqrt(num * num + num2 * num2);
		if (num3 < buSystem.resolutionCompare)
		{
			return true;
		}
		return false;
	}

	public bool IsInside(Pnt2D MinPnt, Pnt2D MaxPnt)
	{
		try
		{
			bool result = false;
			if (((X >= MinPnt.X) & (X <= MaxPnt.X)) && ((Y >= MinPnt.Y) & (Y <= MaxPnt.Y)))
			{
				result = true;
			}
			return result;
		}
		catch
		{
			return false;
		}
	}

	public bool IsInside(double dX, double dY)
	{
		try
		{
			Pnt2D minPnt = new Pnt2D(X - dX, Y - dY);
			Pnt2D maxPnt = new Pnt2D(X + dX, Y + dY);
			return IsInside(minPnt, maxPnt);
		}
		catch
		{
			return false;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		Pnt2D pnt2D = new Pnt2D();
		pnt2D = (Pnt2D)obj;
		return Equal(pnt2D);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Pnt2D Copy(Pnt2D P)
	{
		return new Pnt2D(P.X, P.Y);
	}

	public static Pnt2D[] Copy(Pnt2D[] pts)
	{
		Pnt2D[] array = new Pnt2D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt2D> Copy(List<Pnt2D> pts)
	{
		List<Pnt2D> list = new List<Pnt2D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public void Offset(double x, double y)
	{
		X += x;
		Y += y;
	}

	public static void Offset(List<Pnt2D> pts, double offsetX, double offsetY)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			pts[i].Offset(offsetX, offsetY);
		}
	}

	public static void Offset(Pnt2D[] pts, double offsetX, double offsetY)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY);
		}
	}

	public static void Offset(Pnt2D pts, double offsetX, double offsetY)
	{
		pts.Offset(offsetX, offsetY);
	}

	public static Pnt2D operator +(Pnt2D P1, Pnt2D P2)
	{
		Pnt2D pnt2D = new Pnt2D();
		pnt2D.X = P1.X + P2.X;
		pnt2D.Y = P1.Y + P2.Y;
		return pnt2D;
	}

	public static Pnt2D operator -(Pnt2D P1, Pnt2D P2)
	{
		Pnt2D pnt2D = new Pnt2D();
		pnt2D.X = P1.X - P2.X;
		pnt2D.Y = P1.Y - P2.Y;
		return pnt2D;
	}

	public static bool operator ==(Pnt2D P1, Pnt2D P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return true;
		}
		bool flag = false;
		return P1.Equal(P2);
	}

	public static bool operator !=(Pnt2D P1, Pnt2D P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return false;
		}
		bool flag = false;
		flag = P1.Equal(P2);
		return !flag;
	}

	public override string ToString()
	{
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4");
	}

	public static Pnt2D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt2D pnt2D = new Pnt2D();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt2D.X = double.Parse(array[0], provider);
				pnt2D.Y = double.Parse(array[1], provider);
			}
			return pnt2D;
		}
		catch (Exception)
		{
			return new Pnt2D();
		}
	}

	public string ToDef()
	{
		return "X:" + X.ToString("") + "; Y:" + Y.ToString("");
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X.ToString("") + "; Y:" + Y.ToString("");
	}
}
