using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class OrientationAngle : buSerilization
{
	public double A;

	public double B;

	public double C;

	public double Magnitude => Math.Sqrt(A * A + B * B + C * C);

	public OrientationAngle()
	{
	}

	public OrientationAngle(OrientationAngle Pnt)
	{
		if (Pnt != null)
		{
			A = Pnt.A;
			B = Pnt.B;
			C = Pnt.C;
		}
	}

	public OrientationAngle(double a, double b, double c)
	{
		A = a;
		B = b;
		C = c;
	}

	public OrientationAngle(Pnt6D Pnt)
	{
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
	}

	public OrientationAngle(Pnt9D Pnt)
	{
		A = Pnt.A;
		B = Pnt.B;
		C = Pnt.C;
	}

	public void Normalise()
	{
		double num = Math.Sqrt(A * A + B * B + C * C);
		if (num > 0.001)
		{
			A /= num;
			B /= num;
			C /= num;
		}
	}

	public static bool Equal(OrientationAngle RefP1, OrientationAngle RefP2)
	{
		if ((RefP1 == null) | (RefP2 == null))
		{
			return false;
		}
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(OrientationAngle RefP1, OrientationAngle RefP2, double Resolution)
	{
		if ((RefP1 == null) | (RefP2 == null))
		{
			return false;
		}
		return RefP1.Equal(RefP2, Resolution);
	}

	public bool Equal(OrientationAngle RefP)
	{
		if (RefP == null)
		{
			return false;
		}
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(OrientationAngle RefP, double Resolution)
	{
		if (RefP == null)
		{
			return false;
		}
		double num = A - RefP.A;
		double num2 = B - RefP.B;
		double num3 = C - RefP.C;
		double num4 = Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		if (num4 < buSystem.resolutionCompare)
		{
			return true;
		}
		return false;
	}

	public bool IsInside(OrientationAngle MinPnt, OrientationAngle MaxPnt)
	{
		try
		{
			if ((MinPnt == null) | (MaxPnt == null))
			{
				return false;
			}
			bool result = false;
			if (((A >= MinPnt.A) & (A <= MaxPnt.A)) && ((B >= MinPnt.B) & (B <= MaxPnt.B)) && ((C >= MinPnt.C) & (C <= MaxPnt.C)))
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

	public bool IsInside(double dA, double dB, double dZ)
	{
		try
		{
			OrientationAngle minPnt = new OrientationAngle(A - dA, B - dB, C - dZ);
			OrientationAngle maxPnt = new OrientationAngle(A + dA, B + dB, C + dZ);
			return IsInside(minPnt, maxPnt);
		}
		catch
		{
			return false;
		}
	}

	public bool IsInside(double dA, double dB)
	{
		try
		{
			OrientationAngle minPnt = new OrientationAngle(A - dA, B - dB, C);
			OrientationAngle maxPnt = new OrientationAngle(A + dA, B + dB, C);
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
		OrientationAngle orientationAngle = new OrientationAngle();
		orientationAngle = (OrientationAngle)obj;
		return Equal(orientationAngle);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static OrientationAngle Copy(OrientationAngle P)
	{
		return new OrientationAngle(P.A, P.B, P.C);
	}

	public static OrientationAngle[] Copy(OrientationAngle[] pts)
	{
		OrientationAngle[] array = new OrientationAngle[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<OrientationAngle> Copy(List<OrientationAngle> pts)
	{
		List<OrientationAngle> list = new List<OrientationAngle>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public void Offset(double x, double y, double z)
	{
		A += x;
		B += y;
		C += z;
	}

	public static void Offset(List<OrientationAngle> pts, double offsetX, double offsetY, double offsetZ)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ);
		}
	}

	public static void Offset(OrientationAngle[] pts, double offsetX, double offsetY, double offsetZ)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ);
		}
	}

	public static void Offset(OrientationAngle pts, double offsetX, double offsetY, double offsetZ)
	{
		pts.Offset(offsetX, offsetY, offsetZ);
	}

	public static OrientationAngle operator +(OrientationAngle P1, OrientationAngle P2)
	{
		if ((P1 == null) | (P2 == null))
		{
			return new OrientationAngle();
		}
		OrientationAngle orientationAngle = new OrientationAngle();
		orientationAngle.A = P1.A + P2.A;
		orientationAngle.B = P1.B + P2.B;
		orientationAngle.C = P1.C + P2.C;
		return orientationAngle;
	}

	public static OrientationAngle operator -(OrientationAngle P1, OrientationAngle P2)
	{
		if ((P1 == null) | (P2 == null))
		{
			return new OrientationAngle();
		}
		OrientationAngle orientationAngle = new OrientationAngle();
		orientationAngle.A = P1.A - P2.A;
		orientationAngle.B = P1.B - P2.B;
		orientationAngle.C = P1.C - P2.C;
		return orientationAngle;
	}

	public static bool operator ==(OrientationAngle P1, OrientationAngle P2)
	{
		if ((object)P1 == null || (object)P2 == null)
		{
			return false;
		}
		bool flag = false;
		return P1.Equal(P2);
	}

	public static bool operator !=(OrientationAngle P1, OrientationAngle P2)
	{
		if ((object)P1 == null || (object)P2 == null)
		{
			return true;
		}
		bool flag = false;
		flag = P1.Equal(P2);
		return !flag;
	}

	public override string ToString()
	{
		return "A:" + A.ToString("f4") + "; B:" + B.ToString("f4") + "; C:" + C.ToString("f4");
	}

	public static OrientationAngle DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			OrientationAngle orientationAngle = new OrientationAngle();
			Value = Value.Replace("A:", "");
			Value = Value.Replace("B:", "");
			Value = Value.Replace("C:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				orientationAngle.A = double.Parse(array[0], provider);
				orientationAngle.B = double.Parse(array[1], provider);
				orientationAngle.C = 0.0;
			}
			if (array.Length > 2)
			{
				orientationAngle.A = double.Parse(array[0], provider);
				orientationAngle.B = double.Parse(array[1], provider);
				orientationAngle.C = double.Parse(array[2], provider);
			}
			return orientationAngle;
		}
		catch (Exception)
		{
			return new OrientationAngle();
		}
	}

	public string ToDef()
	{
		return "A:" + A.ToString("") + "; B:" + B.ToString("") + "; C:" + C.ToString("");
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + A.ToString("") + "; Y:" + B.ToString("") + "; Z:" + C.ToString("");
	}
}
