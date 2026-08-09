using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Vec3D : buSerilization
{
	public double X;

	public double Y;

	public double Z;

	public double Magnitude => Math.Sqrt(X * X + Y * Y + Z * Z);

	public Vec3D()
	{
	}

	public Vec3D(Vec3D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
	}

	public Vec3D(Pnt9D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
	}

	public Vec3D(Pnt6D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
	}

	public Vec3D(Pnt3D startPoint, Pnt3D endPoint)
	{
		X = endPoint.X - startPoint.X;
		Y = endPoint.Y - startPoint.Y;
		Z = endPoint.Z - startPoint.Z;
	}

	public Vec3D(double x, double y)
	{
		X = x;
		Y = y;
		Z = 0.0;
	}

	public Vec3D(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public void Normalise()
	{
		double num = Math.Sqrt(X * X + Y * Y + Z * Z);
		if (num > 0.001)
		{
			X /= num;
			Y /= num;
			Z /= num;
		}
	}

	public static Vec3D Normalise(Vec3D RefVector)
	{
		Vec3D vec3D = new Vec3D();
		double num = Math.Sqrt(RefVector.X * RefVector.X + RefVector.Y * RefVector.Y + RefVector.Z * RefVector.Z);
		if (num > 0.001)
		{
			vec3D.X = RefVector.X / num;
			vec3D.Y = RefVector.Y / num;
			vec3D.Z = RefVector.Z / num;
		}
		return vec3D;
	}

	public static Vec3D CrossProduct(Vec3D v1, Vec3D v2)
	{
		return new Vec3D(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
	}

	public static double DotProduct(Vec3D v1, Vec3D v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
	}

	public Vec3D CrossProduct(Vec3D v)
	{
		return CrossProduct(this, v);
	}

	public double DotProduct(Vec3D v)
	{
		return DotProduct(this, v);
	}

	public static bool isForeFace(Pnt3D pt1, Pnt3D pt2, Pnt3D pt3)
	{
		Vec3D vec3D = new Vec3D(pt2, pt1);
		Vec3D v = new Vec3D(pt2, pt3);
		Vec3D vec3D2 = vec3D.CrossProduct(v);
		return vec3D2.DotProduct(new Vec3D(0.0, 0.0, 1.0)) < 0.0;
	}

	public static bool isBackFace(Pnt3D pt1, Pnt3D pt2, Pnt3D pt3)
	{
		Vec3D vec3D = new Vec3D(pt2, pt1);
		Vec3D v = new Vec3D(pt2, pt3);
		Vec3D vec3D2 = vec3D.CrossProduct(v);
		return vec3D2.DotProduct(new Vec3D(0.0, 0.0, 1.0)) > 0.0;
	}

	public static bool Equal(Vec3D RefP1, Vec3D RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Vec3D RefP1, Vec3D RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public bool Equal(Vec3D RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(Vec3D RefP, double Resolution)
	{
		double num = X - RefP.X;
		double num2 = Y - RefP.Y;
		double num3 = Z - RefP.Z;
		double num4 = Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		if (num4 < buSystem.resolutionCompare)
		{
			return true;
		}
		return false;
	}

	public bool IsInside(Vec3D MinPnt, Vec3D MaxPnt)
	{
		try
		{
			bool result = false;
			if (((X >= MinPnt.X) & (X <= MaxPnt.X)) && ((Y >= MinPnt.Y) & (Y <= MaxPnt.Y)) && ((Z >= MinPnt.Z) & (Z <= MaxPnt.Z)))
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

	public bool IsInside(double dX, double dY, double dZ)
	{
		try
		{
			Vec3D minPnt = new Vec3D(X - dX, Y - dY, Z - dZ);
			Vec3D maxPnt = new Vec3D(X + dX, Y + dY, Z + dZ);
			return IsInside(minPnt, maxPnt);
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
			Vec3D minPnt = new Vec3D(X - dX, Y - dY, Z);
			Vec3D maxPnt = new Vec3D(X + dX, Y + dY, Z);
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
		Vec3D vec3D = new Vec3D();
		vec3D = (Vec3D)obj;
		return Equal(vec3D);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Vec3D Copy(Vec3D P)
	{
		return new Vec3D(P.X, P.Y, P.Z);
	}

	public static Vec3D[] Copy(Vec3D[] pts)
	{
		Vec3D[] array = new Vec3D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Vec3D> Copy(List<Vec3D> pts)
	{
		List<Vec3D> list = new List<Vec3D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public void Offset(double x, double y, double z)
	{
		X += x;
		Y += y;
		Z += z;
	}

	public static void Offset(List<Vec3D> pts, double offsetX, double offsetY, double offsetZ)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ);
		}
	}

	public static void Offset(Vec3D[] pts, double offsetX, double offsetY, double offsetZ)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ);
		}
	}

	public static void Offset(Vec3D pts, double offsetX, double offsetY, double offsetZ)
	{
		pts.Offset(offsetX, offsetY, offsetZ);
	}

	public static Vec3D operator +(Vec3D P1, Vec3D P2)
	{
		Vec3D vec3D = new Vec3D();
		vec3D.X = P1.X + P2.X;
		vec3D.Y = P1.Y + P2.Y;
		vec3D.Z = P1.Z + P2.Z;
		return vec3D;
	}

	public static Vec3D operator -(Vec3D P1, Vec3D P2)
	{
		Vec3D vec3D = new Vec3D();
		vec3D.X = P1.X - P2.X;
		vec3D.Y = P1.Y - P2.Y;
		vec3D.Z = P1.Z - P2.Z;
		return vec3D;
	}

	public static bool operator ==(Vec3D P1, Vec3D P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return true;
		}
		bool flag = false;
		return P1.Equal(P2);
	}

	public static bool operator !=(Vec3D P1, Vec3D P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return false;
		}
		bool flag = false;
		flag = P1.Equal(P2);
		return !flag;
	}

	public static bool isVectorXAxis(Vec3D V)
	{
		double num = Math.Abs(V.X - 1.0);
		double num2 = Math.Abs(V.Y - 0.0);
		double num3 = Math.Abs(V.Z - 0.0);
		if (num <= 0.001 && num2 <= 0.001 && num3 <= 0.001)
		{
			return true;
		}
		return false;
	}

	public static bool isVectorYAxis(Vec3D V)
	{
		double num = Math.Abs(V.X - 0.0);
		double num2 = Math.Abs(V.Y - 1.0);
		double num3 = Math.Abs(V.Z - 0.0);
		if (num <= 0.001 && num2 <= 0.001 && num3 <= 0.001)
		{
			return true;
		}
		return false;
	}

	public static bool isVectorZAxis(Vec3D V)
	{
		double num = Math.Abs(V.X - 0.0);
		double num2 = Math.Abs(V.Y - 0.0);
		double num3 = Math.Abs(V.Z - 1.0);
		if (num <= 0.001 && num2 <= 0.001 && num3 <= 0.001)
		{
			return true;
		}
		return false;
	}

	public static Vec3D XAxis()
	{
		return new Vec3D(1.0, 0.0, 0.0);
	}

	public static Vec3D YAxis()
	{
		return new Vec3D(0.0, 1.0, 0.0);
	}

	public static Vec3D ZAxis()
	{
		return new Vec3D(0.0, 0.0, 1.0);
	}

	public override string ToString()
	{
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4");
	}

	public static Vec3D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Vec3D vec3D = new Vec3D();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				vec3D.X = double.Parse(array[0], provider);
				vec3D.Y = double.Parse(array[1], provider);
				vec3D.Z = 0.0;
			}
			if (array.Length > 2)
			{
				vec3D.X = double.Parse(array[0], provider);
				vec3D.Y = double.Parse(array[1], provider);
				vec3D.Z = double.Parse(array[2], provider);
			}
			return vec3D;
		}
		catch (Exception)
		{
			return new Vec3D();
		}
	}

	public string ToDefNumber()
	{
		return X.ToString("") + ";" + Y.ToString("") + ";" + Z.ToString("");
	}

	public string ToDef()
	{
		return "X:" + X.ToString("") + "; Y:" + Y.ToString("") + "; Z:" + Z.ToString("");
	}

	public string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X.ToString("") + "; Y:" + Y.ToString("") + "; Z:" + Z.ToString("");
	}
}
