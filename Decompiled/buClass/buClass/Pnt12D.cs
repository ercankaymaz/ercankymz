using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt12D : Pnt9D
{
	public double I;

	public double J;

	public double K;

	public Pnt12D()
	{
	}

	public Pnt12D(Pnt12D Pnt)
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
		I = Pnt.I;
		J = Pnt.J;
		K = Pnt.K;
	}

	public Pnt12D(Pnt9D Pnt)
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
		I = 0.0;
		J = 0.0;
		K = 0.0;
	}

	public Pnt12D(Pnt6D Pnt)
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
		I = 0.0;
		J = 0.0;
		K = 0.0;
	}

	public Pnt12D(Pnt3D Pnt)
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
		I = 0.0;
		J = 0.0;
		K = 0.0;
	}

	public Pnt12D(double x, double y, double z, double a, double b, double c, double u, double v, double w, double i, double j, double k)
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
		I = i;
		J = j;
		K = k;
	}

	public Pnt12D(double x, double y, double z)
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
		I = 0.0;
		J = 0.0;
		K = 0.0;
	}

	public static bool Equal(Pnt12D RefP1, Pnt12D RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Pnt12D RefP1, Pnt12D RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public static bool EqualXY(Pnt12D RefP1, Pnt12D RefP2)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXYZ(Pnt12D RefP1, Pnt12D RefP2)
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

	public bool Equal(Pnt12D RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(Pnt12D RefP, double Resolution)
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
		double num10 = I - RefP.I;
		double num11 = J - RefP.J;
		double num12 = K - RefP.K;
		double num13 = Math.Sqrt(num * num + num2 * num2 + num3 * num3 + num4 * num4 + num5 * num5 + num6 * num6 + num7 * num7 + num8 * num8 + num9 * num9 + num10 * num10 + num11 * num11 + num12 * num12);
		if (num13 < buSystem.resolutionCompare)
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
		Pnt12D pnt12D = new Pnt12D();
		pnt12D = (Pnt12D)obj;
		return Equal(pnt12D);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Pnt12D Copy(Pnt12D P)
	{
		return new Pnt12D(P.X, P.Y, P.Z, P.A, P.B, P.C, P.U, P.V, P.W, P.I, P.J, P.K);
	}

	public new static Pnt12D Copy(Pnt6D P)
	{
		return new Pnt12D(P.X, P.Y, P.Z, P.A, P.B, P.C, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
	}

	public new static Pnt12D Copy(Pnt3D P)
	{
		return new Pnt12D(P.X, P.Y, P.Z, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
	}

	public static Pnt12D[] Copy(Pnt12D[] pts)
	{
		Pnt12D[] array = new Pnt12D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public new static List<Pnt12D> Copy(List<Pnt3D> pts)
	{
		List<Pnt12D> list = new List<Pnt12D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static List<Pnt12D> Copy(List<Pnt12D> pts)
	{
		List<Pnt12D> list = new List<Pnt12D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pnt12D> pts, ref List<Pnt12D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt12D(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt3D> pts, ref List<Pnt12D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt12D(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt6D> pts, ref List<Pnt12D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt12D(Copy(pts[i])));
		}
	}

	public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt12D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt12D> list = new List<Pnt12D>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<List<Pnt12D>> pts, ref List<List<Pnt12D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt12D> list = new List<Pnt12D>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<Pnt12D> pts, ref Pnt12D[] CopiedPnt)
	{
		try
		{
			CopiedPnt = new Pnt12D[pts.Count];
			if (pts.Count > 0)
			{
				for (int i = 0; i <= pts.Count - 1; i++)
				{
					CopiedPnt[i] = new Pnt12D(pts[i]);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Add(List<Pnt12D> pts, ref List<Pnt12D> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public void Offset(double x, double y, double z, double a, double b, double c, double u, double v, double w, double i, double j, double k)
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
		I += i;
		J += j;
		K += k;
	}

	public static void Offset(List<Pnt12D> pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW, double offsetI, double offsetJ, double offsetK)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW, offsetI, offsetJ, offsetK);
		}
	}

	public static void Offset(Pnt12D[] pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW, double offsetI, double offsetJ, double offsetK)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW, offsetI, offsetJ, offsetK);
		}
	}

	public static void Offset(Pnt12D pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC, double offsetU, double offsetV, double offsetW, double offsetI, double offsetJ, double offsetK)
	{
		pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC, offsetU, offsetV, offsetW, offsetI, offsetJ, offsetK);
	}

	public static Pnt12D operator +(Pnt12D P1, Pnt12D P2)
	{
		Pnt12D pnt12D = new Pnt12D();
		pnt12D.X = P1.X + P2.X;
		pnt12D.Y = P1.Y + P2.Y;
		pnt12D.Z = P1.Z + P2.Z;
		pnt12D.A = P1.A + P2.A;
		pnt12D.B = P1.B + P2.B;
		pnt12D.C = P1.C + P2.C;
		pnt12D.U = P1.U + P2.U;
		pnt12D.V = P1.V + P2.V;
		pnt12D.W = P1.W + P2.W;
		pnt12D.I = P1.I + P2.I;
		pnt12D.J = P1.J + P2.J;
		pnt12D.K = P1.K + P2.K;
		return pnt12D;
	}

	public static Pnt12D operator -(Pnt12D P1, Pnt12D P2)
	{
		Pnt12D pnt12D = new Pnt12D();
		pnt12D.X = P1.X - P2.X;
		pnt12D.Y = P1.Y - P2.Y;
		pnt12D.Z = P1.Z - P2.Z;
		pnt12D.A = P1.A - P2.A;
		pnt12D.B = P1.B - P2.B;
		pnt12D.C = P1.C - P2.C;
		pnt12D.U = P1.U - P2.U;
		pnt12D.V = P1.V - P2.V;
		pnt12D.W = P1.W - P2.W;
		pnt12D.I = P1.I - P2.I;
		pnt12D.J = P1.J - P2.J;
		pnt12D.K = P1.K - P2.K;
		return pnt12D;
	}

	public static bool operator ==(Pnt12D P1, Pnt12D P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return true;
		}
		bool flag = false;
		return P1.Equal(P2);
	}

	public static bool operator !=(Pnt12D P1, Pnt12D P2)
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
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4") + "; A:" + A.ToString("f4") + "; B:" + B.ToString("f4") + "; C:" + C.ToString("f4") + "; U:" + U.ToString("f4") + "; V:" + V.ToString("f4") + "; W:" + W.ToString("f4") + "; I:" + I.ToString("f4") + "; J:" + J.ToString("f4") + "; K:" + K.ToString("f4");
	}

	public new static Pnt12D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt12D pnt12D = new Pnt12D();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("A:", "");
			Value = Value.Replace("B:", "");
			Value = Value.Replace("C:", "");
			Value = Value.Replace("U:", "");
			Value = Value.Replace("V:", "");
			Value = Value.Replace("W:", "");
			Value = Value.Replace("I:", "");
			Value = Value.Replace("J:", "");
			Value = Value.Replace("K:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
				pnt12D.B = double.Parse(array[4], provider);
			}
			if (array.Length == 6)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
				pnt12D.B = double.Parse(array[4], provider);
				pnt12D.C = double.Parse(array[5], provider);
			}
			if (array.Length == 7)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
				pnt12D.B = double.Parse(array[4], provider);
				pnt12D.C = double.Parse(array[5], provider);
				pnt12D.U = double.Parse(array[6], provider);
			}
			if (array.Length == 8)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
				pnt12D.B = double.Parse(array[4], provider);
				pnt12D.C = double.Parse(array[5], provider);
				pnt12D.U = double.Parse(array[6], provider);
				pnt12D.V = double.Parse(array[7], provider);
			}
			if (array.Length >= 9)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
				pnt12D.B = double.Parse(array[4], provider);
				pnt12D.C = double.Parse(array[5], provider);
				pnt12D.U = double.Parse(array[6], provider);
				pnt12D.V = double.Parse(array[7], provider);
				pnt12D.W = double.Parse(array[8], provider);
			}
			if (array.Length >= 10)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
				pnt12D.B = double.Parse(array[4], provider);
				pnt12D.C = double.Parse(array[5], provider);
				pnt12D.U = double.Parse(array[6], provider);
				pnt12D.V = double.Parse(array[7], provider);
				pnt12D.W = double.Parse(array[8], provider);
				pnt12D.I = double.Parse(array[9], provider);
			}
			if (array.Length >= 11)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
				pnt12D.B = double.Parse(array[4], provider);
				pnt12D.C = double.Parse(array[5], provider);
				pnt12D.U = double.Parse(array[6], provider);
				pnt12D.V = double.Parse(array[7], provider);
				pnt12D.W = double.Parse(array[8], provider);
				pnt12D.I = double.Parse(array[9], provider);
				pnt12D.J = double.Parse(array[10], provider);
			}
			if (array.Length >= 12)
			{
				pnt12D.X = double.Parse(array[0], provider);
				pnt12D.Y = double.Parse(array[1], provider);
				pnt12D.Z = double.Parse(array[2], provider);
				pnt12D.A = double.Parse(array[3], provider);
				pnt12D.B = double.Parse(array[4], provider);
				pnt12D.C = double.Parse(array[5], provider);
				pnt12D.U = double.Parse(array[6], provider);
				pnt12D.V = double.Parse(array[7], provider);
				pnt12D.W = double.Parse(array[8], provider);
				pnt12D.I = double.Parse(array[9], provider);
				pnt12D.J = double.Parse(array[10], provider);
				pnt12D.K = double.Parse(array[11], provider);
			}
			return pnt12D;
		}
		catch (Exception)
		{
			return new Pnt12D();
		}
	}

	public new string ToDef()
	{
		return "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; U:" + U + "; V:" + V + "; W:" + W + "; I:" + I + "; J:" + J + "; K:" + K;
	}

	public new string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; U:" + U + "; V:" + V + "; W:" + W + "; I:" + U + "; J:" + V + "; K:" + W;
	}
}
