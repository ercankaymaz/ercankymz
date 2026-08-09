using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt4D : Pnt3D
{
	public double W;

	public Pnt4D()
	{
	}

	public Pnt4D(Pnt4D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		W = Pnt.W;
	}

	public Pnt4D(Pnt9D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		W = 0.0;
	}

	public Pnt4D(Pnt6D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		W = 0.0;
	}

	public Pnt4D(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
		W = 0.0;
	}

	public Pnt4D(double x, double y, double z, double w)
	{
		X = x;
		Y = y;
		Z = z;
		W = w;
	}

	public static bool Equal(Pnt4D RefP1, Pnt4D RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Pnt4D RefP1, Pnt4D RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public static bool EqualXY(Pnt4D RefP1, Pnt4D RefP2)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXYZ(Pnt4D RefP1, Pnt4D RefP2)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		double num3 = Math.Abs(RefP1.Z - RefP2.Z);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare) & (num3 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public bool Equal(Pnt4D RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(Pnt4D RefP, double Resolution)
	{
		double num = X - RefP.X;
		double num2 = Y - RefP.Y;
		double num3 = Z - RefP.Z;
		double num4 = W - RefP.W;
		double num5 = Math.Sqrt(num * num + num2 * num2 + num3 * num3 + num4 * num4);
		if (num5 < buSystem.resolutionCompare)
		{
			return true;
		}
		return false;
	}

	public bool IsInside(Pnt4D MinPnt, Pnt4D MaxPnt)
	{
		try
		{
			bool result = false;
			if (((X >= MinPnt.X) & (X <= MaxPnt.X)) && ((Y >= MinPnt.Y) & (Y <= MaxPnt.Y)) && ((Z >= MinPnt.Z) & (Z <= MaxPnt.Z)) && ((W >= MinPnt.W) & (W <= MaxPnt.W)))
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

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		Pnt4D pnt4D = new Pnt4D();
		pnt4D = (Pnt4D)obj;
		return Equal(pnt4D);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Pnt4D Copy(Pnt4D P)
	{
		return new Pnt4D(P.X, P.Y, P.Z, P.W);
	}

	public static Pnt4D[] Copy(Pnt4D[] pts)
	{
		Pnt4D[] array = new Pnt4D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt4D> Copy(List<Pnt4D> pts)
	{
		List<Pnt4D> list = new List<Pnt4D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pnt4D> pts, ref List<Pnt4D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt4D(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt4D> pts, ref List<List<Pnt4D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		List<Pnt4D> CopiedPnt2 = new List<Pnt4D>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Copy(List<List<Pnt4D>> pts, ref List<List<Pnt4D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt4D> list = new List<Pnt4D>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<Pnt4D> pts, ref Pnt4D[] CopiedPnt)
	{
		try
		{
			CopiedPnt = new Pnt4D[pts.Count];
			if (pts.Count > 0)
			{
				for (int i = 0; i <= pts.Count - 1; i++)
				{
					CopiedPnt[i] = new Pnt4D(pts[i]);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Copy(List<List<Pnt4D>> SourceList, ref List<Pnt4D> TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			TargetList = new List<Pnt4D>();
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					TargetList.Add(new Pnt4D(SourceList[i][j]));
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Add(List<Pnt4D> pts, ref List<Pnt4D> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Pnt4D> pts, ref List<List<Pnt4D>> CopiedPnt)
	{
		List<Pnt4D> CopiedPnt2 = new List<Pnt4D>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Add(List<List<Pnt4D>> SourceList, ref List<List<Pnt4D>> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					List<Pnt4D> CopiedPnt = new List<Pnt4D>();
					Copy(SourceList[i], ref CopiedPnt);
					TargetList.Add(CopiedPnt);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static Pnt4D operator +(Pnt4D P1, Pnt4D P2)
	{
		Pnt4D pnt4D = new Pnt4D();
		pnt4D.X = P1.X + P2.X;
		pnt4D.Y = P1.Y + P2.Y;
		pnt4D.Z = P1.Z + P2.Z;
		pnt4D.W = P1.W + P2.W;
		return pnt4D;
	}

	public static Pnt4D operator -(Pnt4D P1, Pnt4D P2)
	{
		Pnt4D pnt4D = new Pnt4D();
		pnt4D.X = P1.X - P2.X;
		pnt4D.Y = P1.Y - P2.Y;
		pnt4D.Z = P1.Z - P2.Z;
		pnt4D.W = P1.W - P2.W;
		return pnt4D;
	}

	public static bool operator ==(Pnt4D P1, Pnt4D P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return true;
		}
		bool flag = false;
		return P1.Equal(P2);
	}

	public static bool operator !=(Pnt4D P1, Pnt4D P2)
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
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4") + "; W:" + W.ToString("f4");
	}

	public new string ToString(int Decimal)
	{
		return "X:" + X.ToString("f" + Decimal) + "; Y:" + Y.ToString("f" + Decimal) + "; Z:" + Z.ToString("f" + Decimal) + "; W:" + W.ToString("f" + Decimal);
	}

	public new static Pnt4D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt4D pnt4D = new Pnt4D();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("W:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt4D.X = double.Parse(array[0], provider);
				pnt4D.Y = double.Parse(array[1], provider);
				pnt4D.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pnt4D.X = double.Parse(array[0], provider);
				pnt4D.Y = double.Parse(array[1], provider);
				pnt4D.Z = double.Parse(array[2], provider);
			}
			if (array.Length > 3)
			{
				pnt4D.X = double.Parse(array[0], provider);
				pnt4D.Y = double.Parse(array[1], provider);
				pnt4D.Z = double.Parse(array[2], provider);
				pnt4D.W = double.Parse(array[3], provider);
			}
			return pnt4D;
		}
		catch (Exception)
		{
			return new Pnt4D();
		}
	}

	public new string ToDef()
	{
		return "X:" + X.ToString("") + "; Y:" + Y.ToString("") + "; Z:" + Z.ToString("") + "; W:" + W.ToString("");
	}

	public new string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X.ToString("") + "; Y:" + Y.ToString("") + "; Z:" + Z.ToString("") + "; W:" + W.ToString("");
	}
}
