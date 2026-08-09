using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt9DS : buSerilization
{
	public double X;

	public double Y;

	public double Z;

	public double A;

	public double B;

	public double C;

	public double U;

	public double V;

	public double W;

	public string S = "";

	public Pnt9DS()
	{
	}

	public Pnt9DS(Pnt9DS Pnt)
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
		S = Pnt.S;
	}

	public Pnt9DS(Pnt6D Pnt)
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

	public Pnt9DS(Pnt3D Pnt)
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

	public Pnt9DS(Pnt9DCam Pnt)
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

	public Pnt9DS(double x, double y, double z, double a, double b, double c)
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

	public Pnt9DS(double x, double y, double z, double a, double b, double c, double u, double v, double w)
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

	public Pnt9DS(double x, double y, double z)
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

	public static bool Equal(Pnt9DS RefP1, Pnt9DS RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Pnt9DS RefP1, Pnt9DS RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public static bool EqualXY(Pnt9DS RefP1, Pnt9DS RefP2)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXY(Pnt9DS RefP1, Pnt9DS RefP2, double Resolution)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXYZ(Pnt9DS RefP1, Pnt9DS RefP2)
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

	public static bool EqualXYZ(Pnt9DS RefP1, Pnt9DS RefP2, double Resolution)
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

	public bool Equal(Pnt9DS RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(Pnt9DS RefP, double Resolution)
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
		Pnt9DS pnt9DS = new Pnt9DS();
		pnt9DS = (Pnt9DS)obj;
		return Equal(pnt9DS);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Pnt9DS Copy(Pnt9DS P)
	{
		return new Pnt9DS(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W);
	}

	public static Pnt9DS Copy(Pnt6D P)
	{
		return new Pnt9DS(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0);
	}

	public static Pnt9DS Copy(Pnt3D P)
	{
		return new Pnt9DS(P.X, P.Y, P.Z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
	}

	public static Pnt9DS[] Copy(Pnt9DS[] pts)
	{
		Pnt9DS[] array = new Pnt9DS[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt9DS> Copy(List<Pnt3D> pts)
	{
		List<Pnt9DS> list = new List<Pnt9DS>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static List<Pnt9DS> Copy(List<Pnt9DS> pts)
	{
		List<Pnt9DS> list = new List<Pnt9DS>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pnt9DS> pts, ref List<Pnt9DS> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt9DS(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt3D> pts, ref List<Pnt9DS> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt9DS(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt6D> pts, ref List<Pnt9DS> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt9DS(Copy(pts[i])));
		}
	}

	public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt9DS>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt9DS> list = new List<Pnt9DS>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<List<Pnt9DS>> pts, ref List<List<Pnt9DS>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt9DS> list = new List<Pnt9DS>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<Pnt9DS> pts, ref Pnt9DS[] CopiedPnt)
	{
		try
		{
			CopiedPnt = new Pnt9DS[pts.Count];
			if (pts.Count > 0)
			{
				for (int i = 0; i <= pts.Count - 1; i++)
				{
					CopiedPnt[i] = new Pnt9DS(pts[i]);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Add(List<Pnt9DS> pts, ref List<Pnt9DS> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public void Offset(double x, double y, double z)
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

	public static void Offset(List<Pnt9DS> pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
		}
	}

	public static void Offset(Pnt9DS[] pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
		}
	}

	public static void Offset(Pnt9DS pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW)
	{
		pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW);
	}

	public static Pnt9DS operator +(Pnt9DS P1, Pnt9DS P2)
	{
		Pnt9DS pnt9DS = new Pnt9DS();
		pnt9DS.X = P1.X + P2.X;
		pnt9DS.Y = P1.Y + P2.Y;
		pnt9DS.Z = P1.Z + P2.Z;
		pnt9DS.A = P1.A + P2.A;
		pnt9DS.B = P1.B + P2.B;
		pnt9DS.C = P1.C + P2.C;
		pnt9DS.U = P1.U + P2.U;
		pnt9DS.V = P1.V + P2.V;
		pnt9DS.W = P1.W + P2.W;
		return pnt9DS;
	}

	public static Pnt9DS operator -(Pnt9DS P1, Pnt9DS P2)
	{
		Pnt9DS pnt9DS = new Pnt9DS();
		pnt9DS.X = P1.X - P2.X;
		pnt9DS.Y = P1.Y - P2.Y;
		pnt9DS.Z = P1.Z - P2.Z;
		pnt9DS.A = P1.A - P2.A;
		pnt9DS.B = P1.B - P2.B;
		pnt9DS.C = P1.C - P2.C;
		pnt9DS.U = P1.U - P2.U;
		pnt9DS.V = P1.V - P2.V;
		pnt9DS.W = P1.W - P2.W;
		return pnt9DS;
	}

	public static bool operator ==(Pnt9DS P1, Pnt9DS P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return true;
		}
		bool flag = false;
		return P1.Equal(P2);
	}

	public static bool operator !=(Pnt9DS P1, Pnt9DS P2)
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
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4") + "; A:" + A.ToString("f4") + "; B:" + B.ToString("f4") + "; C:" + C.ToString("f4") + "; U:" + U.ToString("f4") + "; V:" + V.ToString("f4") + "; W:" + W.ToString("f4") + "; S:" + S;
	}

	public static Pnt9DS DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt9DS pnt9DS = new Pnt9DS();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("A:", "");
			Value = Value.Replace("B:", "");
			Value = Value.Replace("C:", "");
			Value = Value.Replace("U:", "");
			Value = Value.Replace("V:", "");
			Value = Value.Replace("W:", "");
			Value = Value.Replace("S:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = double.Parse(array[2], provider);
				pnt9DS.A = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = double.Parse(array[2], provider);
				pnt9DS.A = double.Parse(array[3], provider);
				pnt9DS.B = double.Parse(array[4], provider);
			}
			if (array.Length == 6)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = double.Parse(array[2], provider);
				pnt9DS.A = double.Parse(array[3], provider);
				pnt9DS.B = double.Parse(array[4], provider);
				pnt9DS.C = double.Parse(array[5], provider);
			}
			if (array.Length == 7)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = double.Parse(array[2], provider);
				pnt9DS.A = double.Parse(array[3], provider);
				pnt9DS.B = double.Parse(array[4], provider);
				pnt9DS.C = double.Parse(array[5], provider);
				pnt9DS.U = double.Parse(array[6], provider);
			}
			if (array.Length == 8)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = double.Parse(array[2], provider);
				pnt9DS.A = double.Parse(array[3], provider);
				pnt9DS.B = double.Parse(array[4], provider);
				pnt9DS.C = double.Parse(array[5], provider);
				pnt9DS.U = double.Parse(array[6], provider);
				pnt9DS.V = double.Parse(array[7], provider);
			}
			if (array.Length >= 9)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = double.Parse(array[2], provider);
				pnt9DS.A = double.Parse(array[3], provider);
				pnt9DS.B = double.Parse(array[4], provider);
				pnt9DS.C = double.Parse(array[5], provider);
				pnt9DS.U = double.Parse(array[6], provider);
				pnt9DS.V = double.Parse(array[7], provider);
				pnt9DS.W = double.Parse(array[8], provider);
			}
			if (array.Length >= 10)
			{
				pnt9DS.X = double.Parse(array[0], provider);
				pnt9DS.Y = double.Parse(array[1], provider);
				pnt9DS.Z = double.Parse(array[2], provider);
				pnt9DS.A = double.Parse(array[3], provider);
				pnt9DS.B = double.Parse(array[4], provider);
				pnt9DS.C = double.Parse(array[5], provider);
				pnt9DS.U = double.Parse(array[6], provider);
				pnt9DS.V = double.Parse(array[7], provider);
				pnt9DS.W = double.Parse(array[8], provider);
				pnt9DS.S = array[9];
			}
			return pnt9DS;
		}
		catch (Exception)
		{
			return new Pnt9DS();
		}
	}

	public string ToDef()
	{
		return "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; U:" + U + "; V:" + V + "; W:" + W + ";S:" + S;
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; U:" + U + "; V:" + V + "; W:" + W + ";S:" + S;
	}
}
