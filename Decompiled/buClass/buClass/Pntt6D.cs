using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pntt6D : buSerilization
{
	public double X;

	public double Y;

	public double Z;

	public double A;

	public double B;

	public double C;

	public Pntt6D()
	{
	}

	public Pntt6D(double x, double y, double z, double a, double b, double c)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
	}

	public static bool EqualXY(Pntt6D RefP1, Pntt6D RefP2)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXYZ(Pntt6D RefP1, Pntt6D RefP2)
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

	public static bool Equal(Pntt6D RefP1, Pntt6D RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Pntt6D RefP1, Pntt6D RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public bool Equal(Pntt6D RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(Pntt6D RefP, double Resolution)
	{
		if (RefP != null)
		{
			double num = X - RefP.X;
			double num2 = Y - RefP.Y;
			double num3 = Z - RefP.Z;
			double num4 = A - RefP.A;
			double num5 = B - RefP.B;
			double num6 = C - RefP.C;
			double num7 = Math.Sqrt(num * num + num2 * num2 + num3 * num3 + num4 * num4 + num5 * num5 + num6 * num6);
			if (num7 < buSystem.resolutionCompare)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		Pntt6D pntt6D = new Pntt6D();
		pntt6D = (Pntt6D)obj;
		return Equal(pntt6D);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Pntt6D Copy(Pntt6D P)
	{
		return new Pntt6D(P.X, P.Y, P.Z, P.A, P.B, P.C);
	}

	public static Pntt6D Copy(Pnt3D P)
	{
		return new Pntt6D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0);
	}

	public static Pntt6D[] Copy(Pntt6D[] pts)
	{
		Pntt6D[] array = new Pntt6D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pntt6D> Copy(List<Pntt6D> pts)
	{
		List<Pntt6D> list = new List<Pntt6D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pntt6D> pts, ref List<Pntt6D> CopiedPnt)
	{
	}

	public static void Copy(List<Pnt3D> pts, ref List<Pntt6D> CopiedPnt)
	{
	}

	public static void Copy(List<Pntt6D> pts, ref List<Pnt3D> CopiedPnt)
	{
	}

	public static void Copy(List<List<Pntt6D>> pts, ref List<List<Pntt6D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pntt6D> list = new List<Pntt6D>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pntt6D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pntt6D> CopiedPnt2 = new List<Pntt6D>();
			Copy(pts[i], ref CopiedPnt2);
			CopiedPnt.Add(CopiedPnt2);
		}
	}

	public static void Copy(List<Pnt3D> pts, OrientationAngle Orientation, ref List<Pntt6D> CopiedPnt)
	{
	}

	public static void Add(List<Pntt6D> pts, ref List<Pntt6D> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Pnt3D> pts, ref List<Pntt6D> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Pntt6D> pts, ref List<List<Pntt6D>> CopiedPnt)
	{
		List<Pntt6D> CopiedPnt2 = new List<Pntt6D>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Add(List<List<Pntt6D>> SourceList, ref List<List<Pntt6D>> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					List<Pntt6D> CopiedPnt = new List<Pntt6D>();
					Copy(SourceList[i], ref CopiedPnt);
					TargetList.Add(CopiedPnt);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void Offset(double x, double y, double z)
	{
		X += x;
		Y += y;
		Z += z;
	}

	public void Offset(double x, double y, double z, double a, double b, double c)
	{
		X += x;
		Y += y;
		Z += z;
		A += a;
		B += b;
		C += c;
	}

	public static void Offset(List<Pntt6D> pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
		}
	}

	public static void Offset(Pntt6D[] pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
		}
	}

	public static void Offset(Pntt6D pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC)
	{
		pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
	}

	public static Pntt6D operator +(Pntt6D P1, Pntt6D P2)
	{
		Pntt6D pntt6D = new Pntt6D();
		pntt6D.X = P1.X + P2.X;
		pntt6D.Y = P1.Y + P2.Y;
		pntt6D.Z = P1.Z + P2.Z;
		pntt6D.A = P1.A + P2.A;
		pntt6D.B = P1.B + P2.B;
		pntt6D.C = P1.C + P2.C;
		return pntt6D;
	}

	public static Pntt6D operator -(Pntt6D P1, Pntt6D P2)
	{
		Pntt6D pntt6D = new Pntt6D();
		pntt6D.X = P1.X - P2.X;
		pntt6D.Y = P1.Y - P2.Y;
		pntt6D.Z = P1.Z - P2.Z;
		pntt6D.A = P1.A - P2.A;
		pntt6D.B = P1.B - P2.B;
		pntt6D.C = P1.C - P2.C;
		return pntt6D;
	}

	public static bool operator ==(Pntt6D P1, Pntt6D P2)
	{
		try
		{
			if ((object)P1 == null && (object)P2 == null)
			{
				return true;
			}
			bool flag = false;
			return P1.Equal(P2);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool operator !=(Pntt6D P1, Pntt6D P2)
	{
		try
		{
			if ((object)P1 == null && (object)P2 == null)
			{
				return false;
			}
			bool flag = false;
			flag = P1.Equal(P2);
			return !flag;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public override string ToString()
	{
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4") + "; A:" + A.ToString("f4") + "; B:" + B.ToString("f4") + "; C:" + C.ToString("f4");
	}

	public static Pntt6D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pntt6D pntt6D = new Pntt6D();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("A:", "");
			Value = Value.Replace("B:", "");
			Value = Value.Replace("C:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pntt6D.X = double.Parse(array[0], provider);
				pntt6D.Y = double.Parse(array[1], provider);
				pntt6D.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pntt6D.X = double.Parse(array[0], provider);
				pntt6D.Y = double.Parse(array[1], provider);
				pntt6D.Z = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				pntt6D.X = double.Parse(array[0], provider);
				pntt6D.Y = double.Parse(array[1], provider);
				pntt6D.Z = double.Parse(array[2], provider);
				pntt6D.A = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				pntt6D.X = double.Parse(array[0], provider);
				pntt6D.Y = double.Parse(array[1], provider);
				pntt6D.Z = double.Parse(array[2], provider);
				pntt6D.A = double.Parse(array[3], provider);
				pntt6D.B = double.Parse(array[4], provider);
			}
			if (array.Length >= 6)
			{
				pntt6D.X = double.Parse(array[0], provider);
				pntt6D.Y = double.Parse(array[1], provider);
				pntt6D.Z = double.Parse(array[2], provider);
				pntt6D.A = double.Parse(array[3], provider);
				pntt6D.B = double.Parse(array[4], provider);
				pntt6D.C = double.Parse(array[5], provider);
			}
			return pntt6D;
		}
		catch (Exception)
		{
			return new Pntt6D();
		}
	}

	public string ToDef()
	{
		return "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C;
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C;
	}
}
