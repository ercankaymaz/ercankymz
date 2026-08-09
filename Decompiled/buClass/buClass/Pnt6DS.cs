using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt6DS : buSerilization
{
	public double X;

	public double Y;

	public double Z;

	public double A;

	public double B;

	public double C;

	public string S = "";

	public Pnt6DS()
	{
	}

	public Pnt6DS(Pnt6D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
		S = "";
	}

	public Pnt6DS(Pnt6DS Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
		S = Pnt.S;
	}

	public Pnt6DS(Pnt9D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
	}

	public Pnt6DS(Pnt9DCam Pnt)
	{
		X = Pnt.P9.X;
		Y = Pnt.P9.Y;
		Z = Pnt.P9.Z;
		A = Pnt.P9.A;
		B = Pnt.P9.B;
		C = Pnt.P9.C;
	}

	public Pnt6DS(Pnt3D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = 0.0;
		B = 0.0;
		C = 0.0;
	}

	public Pnt6DS(Pnt3D Pnt, double a, double b, double c)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = a;
		B = b;
		C = c;
	}

	public Pnt6DS(Pnt3D Pnt, OrientationAngle Angles)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
		A = Angles.A;
		B = Angles.B;
		C = Angles.C;
	}

	public Pnt6DS(double x, double y, double z, double a, double b, double c)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
	}

	public Pnt6DS(double x, double y, double z, double a, double b, double c, string s)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		B = b;
		C = c;
		S = s;
	}

	public Pnt6DS(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
		A = 0.0;
		B = 0.0;
		C = 0.0;
	}

	public static bool EqualXY(Pnt6DS RefP1, Pnt6DS RefP2)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXYZ(Pnt6DS RefP1, Pnt6DS RefP2)
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

	public static bool Equal(Pnt6DS RefP1, Pnt6DS RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Pnt6DS RefP1, Pnt6DS RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public bool Equal(Pnt6DS RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(Pnt6DS RefP, double Resolution)
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
		Pnt6DS pnt6DS = new Pnt6DS();
		pnt6DS = (Pnt6DS)obj;
		return Equal(pnt6DS);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static void CoordinateCopy(Pnt6DS refPoint, ref Pnt6DS copyPoint)
	{
		if (refPoint != null)
		{
			if (copyPoint == null)
			{
				copyPoint = new Pnt6DS();
			}
			copyPoint.X = refPoint.X;
			copyPoint.Y = refPoint.Y;
			copyPoint.Z = refPoint.Z;
			copyPoint.A = refPoint.A;
			copyPoint.B = refPoint.B;
			copyPoint.C = refPoint.C;
		}
	}

	public static Pnt6DS Copy(Pnt6DS P)
	{
		return new Pnt6DS(P.X, P.Y, P.Z, P.A, P.B, P.C);
	}

	public static Pnt6DS Copy(Pnt3D P)
	{
		return new Pnt6DS(P.X, P.Y, P.Z, 0.0, 0.0, 0.0);
	}

	public static Pnt6DS[] Copy(Pnt6DS[] pts)
	{
		Pnt6DS[] array = new Pnt6DS[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt6DS> Copy(List<Pnt6DS> pts)
	{
		List<Pnt6DS> list = new List<Pnt6DS>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pnt6DS> pts, ref List<Pnt6DS> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DS(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt3D> pts, ref List<Pnt6DS> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DS(pts[i]));
		}
	}

	public static void Copy(List<Pnt6DS> pts, ref List<Pnt3D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt3D(pts[i].X, pts[i].Y, pts[i].Z));
		}
	}

	public static void Copy(List<List<Pnt6DS>> pts, ref List<List<Pnt6DS>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt6DS> list = new List<Pnt6DS>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt6DS>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt6DS> CopiedPnt2 = new List<Pnt6DS>();
			Copy(pts[i], ref CopiedPnt2);
			CopiedPnt.Add(CopiedPnt2);
		}
	}

	public static void Copy(List<Pnt3D> pts, OrientationAngle Orientation, ref List<Pnt6DS> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt6DS(new Pnt3D(pts[i]), new OrientationAngle(Orientation)));
		}
	}

	public static void Add(List<Pnt6DS> pts, ref List<Pnt6DS> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Pnt3D> pts, ref List<Pnt6DS> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Pnt6DS> pts, ref List<List<Pnt6DS>> CopiedPnt)
	{
		List<Pnt6DS> CopiedPnt2 = new List<Pnt6DS>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Add(List<List<Pnt6DS>> SourceList, ref List<List<Pnt6DS>> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					List<Pnt6DS> CopiedPnt = new List<Pnt6DS>();
					Copy(SourceList[i], ref CopiedPnt);
					TargetList.Add(CopiedPnt);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void GetDifferences(Pnt6DS First, Pnt6DS Second, ref Length6D Delta)
	{
		Delta.dX = Second.X - First.X;
		Delta.dY = Second.Y - First.Y;
		Delta.dZ = Second.Z - First.Z;
		Delta.dA = Second.A - First.A;
		Delta.dB = Second.B - First.B;
		Delta.dC = Second.C - First.C;
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

	public static void Offset(List<Pnt6DS> pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
		}
	}

	public static void Offset(Pnt6DS[] pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
		}
	}

	public static void Offset(Pnt6DS pts, double offsetX, double offsetY, double offsetZ, double offsetA, double offsetB, double offsetC)
	{
		pts.Offset(offsetX, offsetY, offsetZ, offsetA, offsetB, offsetC);
	}

	public static Pnt6DS operator +(Pnt6DS P1, Pnt6DS P2)
	{
		Pnt6DS pnt6DS = new Pnt6DS();
		pnt6DS.X = P1.X + P2.X;
		pnt6DS.Y = P1.Y + P2.Y;
		pnt6DS.Z = P1.Z + P2.Z;
		pnt6DS.A = P1.A + P2.A;
		pnt6DS.B = P1.B + P2.B;
		pnt6DS.C = P1.C + P2.C;
		return pnt6DS;
	}

	public static Pnt6DS operator -(Pnt6DS P1, Pnt6DS P2)
	{
		Pnt6DS pnt6DS = new Pnt6DS();
		pnt6DS.X = P1.X - P2.X;
		pnt6DS.Y = P1.Y - P2.Y;
		pnt6DS.Z = P1.Z - P2.Z;
		pnt6DS.A = P1.A - P2.A;
		pnt6DS.B = P1.B - P2.B;
		pnt6DS.C = P1.C - P2.C;
		return pnt6DS;
	}

	public static bool operator ==(Pnt6DS P1, Pnt6DS P2)
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

	public static bool operator !=(Pnt6DS P1, Pnt6DS P2)
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
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4") + "; A:" + A.ToString("f4") + "; B:" + B.ToString("f4") + "; C:" + C.ToString("f4") + "; S:" + S;
	}

	public static Pnt6DS DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt6DS pnt6DS = new Pnt6DS();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("A:", "");
			Value = Value.Replace("B:", "");
			Value = Value.Replace("C:", "");
			Value = Value.Replace("S:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt6DS.X = double.Parse(array[0], provider);
				pnt6DS.Y = double.Parse(array[1], provider);
				pnt6DS.Z = 0.0;
			}
			if (array.Length == 3)
			{
				pnt6DS.X = double.Parse(array[0], provider);
				pnt6DS.Y = double.Parse(array[1], provider);
				pnt6DS.Z = double.Parse(array[2], provider);
			}
			if (array.Length == 4)
			{
				pnt6DS.X = double.Parse(array[0], provider);
				pnt6DS.Y = double.Parse(array[1], provider);
				pnt6DS.Z = double.Parse(array[2], provider);
				pnt6DS.A = double.Parse(array[3], provider);
			}
			if (array.Length == 5)
			{
				pnt6DS.X = double.Parse(array[0], provider);
				pnt6DS.Y = double.Parse(array[1], provider);
				pnt6DS.Z = double.Parse(array[2], provider);
				pnt6DS.A = double.Parse(array[3], provider);
				pnt6DS.B = double.Parse(array[4], provider);
			}
			if (array.Length >= 6)
			{
				pnt6DS.X = double.Parse(array[0], provider);
				pnt6DS.Y = double.Parse(array[1], provider);
				pnt6DS.Z = double.Parse(array[2], provider);
				pnt6DS.A = double.Parse(array[3], provider);
				pnt6DS.B = double.Parse(array[4], provider);
				pnt6DS.C = double.Parse(array[5], provider);
			}
			if (array.Length >= 7)
			{
				pnt6DS.X = double.Parse(array[0], provider);
				pnt6DS.Y = double.Parse(array[1], provider);
				pnt6DS.Z = double.Parse(array[2], provider);
				pnt6DS.A = double.Parse(array[3], provider);
				pnt6DS.B = double.Parse(array[4], provider);
				pnt6DS.C = double.Parse(array[5], provider);
				pnt6DS.S = array[6];
			}
			return pnt6DS;
		}
		catch (Exception)
		{
			return new Pnt6DS();
		}
	}

	public string ToDef()
	{
		return "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; S:" + S;
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X + "; Y:" + Y + "; Z:" + Z + "; A:" + A + "; B:" + B + "; C:" + C + "; S:" + S;
	}
}
