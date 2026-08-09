using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt9D : Pnt6D
{
	public double U;

	public double V;

	public double W;

	public Pnt9D()
	{
	}

	public Pnt9D(Pnt9D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
		U = Pnt.U;
		V = Pnt.V;
		W = Pnt.W;
	}

	public Pnt9D(Pnt6D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
		U = 0.0;
		V = 0.0;
		W = 0.0;
	}

	public Pnt9D(Pnt3D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = 0.0;
		B = 0.0;
		C = 0.0;
		U = 0.0;
		V = 0.0;
		W = 0.0;
	}

	public Pnt9D(Pnt9DCam Pnt)
	{
		X = Pnt.P9.X;
		Y = Pnt.P9.Y;
		Z = Pnt.P9.Z;
		A = Pnt.P9.A;
		B = Pnt.P9.B;
		C = Pnt.P9.C;
		U = Pnt.P9.U;
		V = Pnt.P9.V;
		W = Pnt.P9.W;
	}

	public Pnt9D(double x, double y, double z, double a, double b, double c)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
		U = 0.0;
		V = 0.0;
		W = 0.0;
	}

	public Pnt9D(double x, double y, double z, double a, double b, double c, double u, double v, double w)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
		U = u;
		V = v;
		W = w;
	}

	public Pnt9D(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
		A = 0.0;
		B = 0.0;
		C = 0.0;
		A = 0.0;
		B = 0.0;
		C = 0.0;
		U = 0.0;
		V = 0.0;
		W = 0.0;
	}

	public static bool Equal(Pnt9D RefP1, Pnt9D RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Pnt9D RefP1, Pnt9D RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public static bool EqualXY(Pnt9D RefP1, Pnt9D RefP2)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXY(Pnt9D RefP1, Pnt9D RefP2, double Resolution)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXYZ(Pnt9D RefP1, Pnt9D RefP2)
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

	public static bool EqualXYZ(Pnt9D RefP1, Pnt9D RefP2, double Resolution)
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

	public bool Equal(Pnt9D RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(Pnt9D RefP, double Resolution)
	{
		double num = X - RefP.X;
		double num2 = Y - RefP.Y;
		double num3 = Z - RefP.Z;
		double num4 = A - RefP.A;
		double num5 = B - RefP.B;
		double num6 = C - RefP.C;
		double num7 = U - RefP.U;
		double num8 = V - RefP.V;
		double num9 = W - RefP.W;
		double num10 = Math.Sqrt(num * num + num2 * num2 + num3 * num3 + num4 * num4 + num5 * num5 + num6 * num6 + num7 * num7 + num8 * num8 + num9 * num9);
		if (num10 < buSystem.resolutionCompare)
		{
			return true;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		Pnt9D pnt9D = new Pnt9D();
		pnt9D = (Pnt9D)obj;
		return Equal(pnt9D);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Pnt9D Copy(Pnt9D P)
	{
		return new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
	}

	public new static Pnt9D Copy(Pnt6D P)
	{
		return new Pnt9D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
	}

	public new static Pnt9D Copy(Pnt3D P)
	{
		return new Pnt9D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
	}

	public static Pnt9D[] Copy(Pnt9D[] pts)
	{
		Pnt9D[] array = new Pnt9D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt9D> Copy(List<Pnt3D> pts)
	{
		List<Pnt9D> list = new List<Pnt9D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static List<Pnt9D> Copy(List<Pnt9D> pts)
	{
		List<Pnt9D> list = new List<Pnt9D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pnt9D> pts, ref List<Pnt9D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt9D(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt3D> pts, ref List<Pnt9D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt9D(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt6D> pts, ref List<Pnt9D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt9D(Copy(pts[i])));
		}
	}

	public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt9D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt9D> list = new List<Pnt9D>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<List<Pnt9D>> pts, ref List<List<Pnt9D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt9D> list = new List<Pnt9D>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<Pnt9D> pts, ref Pnt9D[] CopiedPnt)
	{
		try
		{
			CopiedPnt = new Pnt9D[pts.Count];
			if (pts.Count > 0)
			{
				for (int i = 0; i <= pts.Count - 1; i++)
				{
					CopiedPnt[i] = new Pnt9D(pts[i]);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Add(List<Pnt9D> pts, ref List<Pnt9D> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public new void Offset(double x, double y, double z)
	{
		X += x;
		Y += y;
		Z += z;
	}

	public void Offset(double x, double y, double z, double a, double b, double c, double u, double v, double w)
	{
		X += x;
		Y += y;
		Z += z;
		A += a;
		B += b;
		C += c;
		U += u;
		V += v;
		W += w;
	}

	public static void Offset(List<Pnt9D> pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
		}
	}

	public static void Offset(Pnt9D[] pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
		}
	}

	public static void Offset(Pnt9D pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW)
	{
		pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
	}

	public static Pnt9D operator +(Pnt9D P1, Pnt9D P2)
	{
		Pnt9D pnt9D = new Pnt9D();
		pnt9D.X = P1.X + P2.X;
		pnt9D.Y = P1.Y + P2.Y;
		pnt9D.Z = P1.Z + P2.Z;
		pnt9D.A = P1.A + P2.A;
		pnt9D.B = P1.B + P2.B;
		pnt9D.C = P1.C + P2.C;
		pnt9D.U = P1.U + P2.U;
		pnt9D.V = P1.V + P2.V;
		pnt9D.W = P1.W + P2.W;
		return pnt9D;
	}

	public static Pnt9D operator -(Pnt9D P1, Pnt9D P2)
	{
		Pnt9D pnt9D = new Pnt9D();
		pnt9D.X = P1.X - P2.X;
		pnt9D.Y = P1.Y - P2.Y;
		pnt9D.Z = P1.Z - P2.Z;
		pnt9D.A = P1.A - P2.A;
		pnt9D.B = P1.B - P2.B;
		pnt9D.C = P1.C - P2.C;
		pnt9D.U = P1.U - P2.U;
		pnt9D.V = P1.V - P2.V;
		pnt9D.W = P1.W - P2.W;
		return pnt9D;
	}

	public static bool operator ==(Pnt9D P1, Pnt9D P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return true;
		}
		bool flag = false;
		return P1.Equal(P2);
	}

	public static bool operator !=(Pnt9D P1, Pnt9D P2)
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
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4") + "; A:" + A.ToString("f4") + "; B:" + B.ToString("f4") + "; C:" + C.ToString("f4") + "; U:" + U.ToString("f4") + "; V:" + V.ToString("f4") + "; W:" + W.ToString("f4");
	}

	public new static Pnt9D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt9D pnt9D = new Pnt9D();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("A:", "");
			Value = Value.Replace("B:", "");
			Value = Value.Replace("C:", "");
			Value = Value.Replace("U:", "");
			Value = Value.Replace("V:", "");
			Value = Value.Replace("W:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
			}
			if (array.Length == 6)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
				pnt9D.C = double.Parse(array[5], provider);
			}
			if (array.Length == 7)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
				pnt9D.C = double.Parse(array[5], provider);
				pnt9D.U = double.Parse(array[6], provider);
			}
			if (array.Length == 8)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
				pnt9D.C = double.Parse(array[5], provider);
				pnt9D.U = double.Parse(array[6], provider);
				pnt9D.V = double.Parse(array[7], provider);
			}
			if (array.Length >= 9)
			{
				pnt9D.X = double.Parse(array[0], provider);
				pnt9D.Y = double.Parse(array[1], provider);
				pnt9D.Z = double.Parse(array[2], provider);
				pnt9D.A = double.Parse(array[3], provider);
				pnt9D.B = double.Parse(array[4], provider);
				pnt9D.C = double.Parse(array[5], provider);
				pnt9D.U = double.Parse(array[6], provider);
				pnt9D.V = double.Parse(array[7], provider);
				pnt9D.W = double.Parse(array[8], provider);
			}
			return pnt9D;
		}
		catch (Exception)
		{
			return new Pnt9D();
		}
	}

	public new string ToDef()
	{
		return "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; U:" + U + "; V:" + V + "; W:" + W;
	}

	public new string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; U:" + U + "; V:" + V + "; W:" + W;
	}
}
