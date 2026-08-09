using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace buClass;

[Serializable]
public class Pnt3D : Pnt2D
{
	public double Z;

	public Pnt3D()
	{
	}

	public Pnt3D(Pnt3D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
	}

	public Pnt3D(Vec3D Vec)
	{
		X = Vec.X;
		Y = Vec.Y;
		Z = Vec.Z;
	}

	public Pnt3D(Pnt9D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
	}

	public Pnt3D(Pnt9DCam Pnt)
	{
		X = Pnt.P9.X;
		Y = Pnt.P9.Y;
		Z = Pnt.P9.Z;
	}

	public Pnt3D(Pnt4D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
	}

	public Pnt3D(Pnt6D Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
	}

	public Pnt3D(Pnt6DSim Pnt)
	{
		X = Pnt.X;
		Y = Pnt.Y;
		Z = Pnt.Z;
	}

	public Pnt3D(double x, double y)
	{
		X = x;
		Y = y;
		Z = 0.0;
	}

	public Pnt3D(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	public static bool Equal(Pnt3D RefP1, Pnt3D RefP2)
	{
		return RefP1.Equal(RefP2);
	}

	public static bool Equal(Pnt3D RefP1, Pnt3D RefP2, double Resolution)
	{
		return RefP1.Equal(RefP2, Resolution);
	}

	public static bool EqualXY(Pnt3D RefP1, Pnt3D RefP2)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXY(Pnt3D RefP1, Pnt3D RefP2, double Resolution)
	{
		double num = Math.Abs(RefP1.X - RefP2.X);
		double num2 = Math.Abs(RefP1.Y - RefP2.Y);
		if ((num < buSystem.resolutionCompare) & (num2 < buSystem.resolutionCompare))
		{
			return true;
		}
		return false;
	}

	public static bool EqualXYZ(Pnt3D RefP1, Pnt3D RefP2)
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

	public static void SetValue(double value, AxesXYZ Axis, ref Pnt3D RefPoint)
	{
		if (Axis == AxesXYZ.X)
		{
			RefPoint.X = value;
		}
		if (Axis == AxesXYZ.Y)
		{
			RefPoint.Y = value;
		}
		if (Axis == AxesXYZ.Z)
		{
			RefPoint.Z = value;
		}
	}

	public static void SetValue(double value, AxesXYZ Axis, ref List<Pnt3D> RefPoint)
	{
		for (int i = 0; i <= RefPoint.Count - 1; i++)
		{
			Pnt3D pnt3D = new Pnt3D(RefPoint[i]);
			if (Axis == AxesXYZ.X)
			{
				pnt3D.X = value;
			}
			if (Axis == AxesXYZ.Y)
			{
				pnt3D.Y = value;
			}
			if (Axis == AxesXYZ.Z)
			{
				pnt3D.Z = value;
			}
			RefPoint[i] = new Pnt3D(pnt3D);
		}
	}

	public static void SetValue(double value, AxesXYZ Axis, ref List<List<Pnt3D>> RefPoint)
	{
		for (int i = 0; i <= RefPoint.Count - 1; i++)
		{
			for (int j = 0; j <= RefPoint[i].Count - 1; j++)
			{
				Pnt3D pnt3D = new Pnt3D(RefPoint[i][j]);
				if (Axis == AxesXYZ.X)
				{
					pnt3D.X = value;
				}
				if (Axis == AxesXYZ.Y)
				{
					pnt3D.Y = value;
				}
				if (Axis == AxesXYZ.Z)
				{
					pnt3D.Z = value;
				}
				RefPoint[i][j] = new Pnt3D(pnt3D);
			}
		}
	}

	public bool Equal(Pnt3D RefP)
	{
		return Equal(RefP, buSystem.resolutionCompare);
	}

	public bool Equal(Pnt3D RefP, double Resolution)
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

	public bool IsInside(Pnt3D MinPnt, Pnt3D MaxPnt)
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
			Pnt3D minPnt = new Pnt3D(X - dX, Y - dY, Z - dZ);
			Pnt3D maxPnt = new Pnt3D(X + dX, Y + dY, Z + dZ);
			return IsInside(minPnt, maxPnt);
		}
		catch
		{
			return false;
		}
	}

	public new bool IsInside(double dX, double dY)
	{
		try
		{
			Pnt3D minPnt = new Pnt3D(X - dX, Y - dY, Z);
			Pnt3D maxPnt = new Pnt3D(X + dX, Y + dY, Z);
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
		Pnt3D pnt3D = new Pnt3D();
		pnt3D = (Pnt3D)obj;
		return Equal(pnt3D);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static Pnt3D Copy(Pnt3D P)
	{
		return new Pnt3D(P.X, P.Y, P.Z);
	}

	public static Pnt3D[] Copy(Pnt3D[] pts)
	{
		Pnt3D[] array = new Pnt3D[pts.Length];
		for (int i = 0; i < pts.Length; i++)
		{
			array[i] = Copy(pts[i]);
		}
		return array;
	}

	public static List<Pnt3D> Copy(List<Pnt3D> pts)
	{
		List<Pnt3D> list = new List<Pnt3D>();
		for (int i = 0; i < pts.Count; i++)
		{
			list.Add(Copy(pts[i]));
		}
		return list;
	}

	public static void Copy(List<Pnt3D> pts, ref List<Pnt3D> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(new Pnt3D(Copy(pts[i])));
		}
	}

	public static void Copy(List<Pnt3D> pts, ref List<List<Pnt3D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Copy(List<List<Pnt3D>> pts, ref List<List<Pnt3D>> CopiedPnt)
	{
		CopiedPnt.Clear();
		for (int i = 0; i < pts.Count; i++)
		{
			List<Pnt3D> list = new List<Pnt3D>();
			list = Copy(pts[i]);
			CopiedPnt.Add(list);
		}
	}

	public static void Copy(List<Pnt3D> pts, ref Pnt3D[] CopiedPnt)
	{
		try
		{
			CopiedPnt = new Pnt3D[pts.Count];
			if (pts.Count > 0)
			{
				for (int i = 0; i <= pts.Count - 1; i++)
				{
					CopiedPnt[i] = new Pnt3D(pts[i]);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Copy(List<List<Pnt3D>> SourceList, ref List<Pnt3D> TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			TargetList = new List<Pnt3D>();
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					TargetList.Add(new Pnt3D(SourceList[i][j]));
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Add(List<Pnt3D> pts, ref List<Pnt3D> CopiedPnt)
	{
		for (int i = 0; i < pts.Count; i++)
		{
			CopiedPnt.Add(Copy(pts[i]));
		}
	}

	public static void Add(List<Pnt3D> pts, ref List<List<Pnt3D>> CopiedPnt)
	{
		List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
		Copy(pts, ref CopiedPnt2);
		CopiedPnt.Add(CopiedPnt2);
	}

	public static void Add(List<List<Pnt3D>> SourceList, ref List<List<Pnt3D>> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					List<Pnt3D> CopiedPnt = new List<Pnt3D>();
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

	public void Offset(Pnt3D AdditionalPnt)
	{
		X += AdditionalPnt.X;
		Y += AdditionalPnt.Y;
		Z += AdditionalPnt.Z;
	}

	public static void Offset(ref Pnt3D RefPoint, Pnt3D AdditionalPnt)
	{
		RefPoint.X += AdditionalPnt.X;
		RefPoint.Y += AdditionalPnt.Y;
		RefPoint.Z += AdditionalPnt.Z;
	}

	public static void Offset(ref List<Pnt3D> pnt, double offsetX, double offsetY, double offsetZ)
	{
		for (int i = 0; i < pnt.Count; i++)
		{
			Pnt3D RefPoint = new Pnt3D(pnt[i]);
			Offset(ref RefPoint, new Pnt3D(offsetX, offsetY, offsetZ));
			pnt[i] = RefPoint;
		}
	}

	public static void Offset(ref Pnt3D[] pts, double offsetX, double offsetY, double offsetZ)
	{
		for (int i = 0; i < pts.Length; i++)
		{
			pts[i].Offset(offsetX, offsetY, offsetZ);
		}
	}

	public static void Offset(ref Pnt3D pts, double offsetX, double offsetY, double offsetZ)
	{
		pts.Offset(offsetX, offsetY, offsetZ);
	}

	public static void BoxSizeOfPoint(Pnt3D FirstPoint, Pnt3D SecondPoint, ref Pnt3D MinPoint, ref Pnt3D MidPoint, ref Pnt3D MaxPoint)
	{
		List<Pnt3D> list = new List<Pnt3D>();
		list.Add(FirstPoint);
		list.Add(SecondPoint);
		BoxSizeOfPoint(list, ref MinPoint, ref MidPoint, ref MaxPoint);
	}

	public static void BoxSizeOfPoint(List<Pnt3D> Points, ref Pnt3D MinPoint, ref Pnt3D MidPoint, ref Pnt3D MaxPoint)
	{
		try
		{
			MinPoint = new Pnt3D(double.MaxValue, double.MaxValue, double.MaxValue);
			MaxPoint = new Pnt3D(double.MinValue, double.MinValue, double.MinValue);
			for (int i = 0; i <= Points.Count - 1; i++)
			{
				if (Points[i].X > MaxPoint.X)
				{
					MaxPoint.X = Points[i].X;
				}
				if (Points[i].Y > MaxPoint.Y)
				{
					MaxPoint.Y = Points[i].Y;
				}
				if (Points[i].Z > MaxPoint.Z)
				{
					MaxPoint.Z = Points[i].Z;
				}
				if (Points[i].X < MinPoint.X)
				{
					MinPoint.X = Points[i].X;
				}
				if (Points[i].Y < MinPoint.Y)
				{
					MinPoint.Y = Points[i].Y;
				}
				if (Points[i].Z < MinPoint.Z)
				{
					MinPoint.Z = Points[i].Z;
				}
			}
			MiddlePointOfLine(MinPoint, MaxPoint, ref MidPoint);
		}
		catch (Exception mSException)
		{
			string text = "Count: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void BoxSizeOfPoint(List<List<Pnt3D>> Points, ref Pnt3D MinPoint, ref Pnt3D MidPoint, ref Pnt3D MaxPoint)
	{
		try
		{
			MinPoint = new Pnt3D(double.MaxValue, double.MaxValue, double.MaxValue);
			MaxPoint = new Pnt3D(double.MinValue, double.MinValue, double.MinValue);
			for (int i = 0; i <= Points.Count - 1; i++)
			{
				for (int j = 0; j <= Points[i].Count - 1; j++)
				{
					if (Points[i][j].X > MaxPoint.X)
					{
						MaxPoint.X = Points[i][j].X;
					}
					if (Points[i][j].Y > MaxPoint.Y)
					{
						MaxPoint.Y = Points[i][j].Y;
					}
					if (Points[i][j].Z > MaxPoint.Z)
					{
						MaxPoint.Z = Points[i][j].Z;
					}
					if (Points[i][j].X < MinPoint.X)
					{
						MinPoint.X = Points[i][j].X;
					}
					if (Points[i][j].Y < MinPoint.Y)
					{
						MinPoint.Y = Points[i][j].Y;
					}
					if (Points[i][j].Z < MinPoint.Z)
					{
						MinPoint.Z = Points[i][j].Z;
					}
				}
			}
			MiddlePointOfLine(MinPoint, MaxPoint, ref MidPoint);
		}
		catch (Exception mSException)
		{
			string text = "Count: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static Pnt3D MiddlePointOfLine(Pnt3D Pnt1, Pnt3D Pnt2)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			pnt3D.X = (Pnt1.X + Pnt2.X) / 2.0;
			pnt3D.Y = (Pnt1.Y + Pnt2.Y) / 2.0;
			pnt3D.Z = (Pnt1.Z + Pnt2.Z) / 2.0;
			return pnt3D;
		}
		catch (Exception mSException)
		{
			string text = "Pnt1: " + Pnt1.ToString() + " - Pnt2: " + Pnt2.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new Pnt3D();
		}
	}

	public static void MiddlePointOfLine(Pnt3D Pnt1, Pnt3D Pnt2, ref Pnt3D MiddlePoint)
	{
		MiddlePoint = new Pnt3D(MiddlePointOfLine(Pnt1, Pnt2));
	}

	public static Pnt3D operator +(Pnt3D P1, Pnt3D P2)
	{
		Pnt3D pnt3D = new Pnt3D();
		pnt3D.X = P1.X + P2.X;
		pnt3D.Y = P1.Y + P2.Y;
		pnt3D.Z = P1.Z + P2.Z;
		return pnt3D;
	}

	public static Pnt3D operator -(Pnt3D P1, Pnt3D P2)
	{
		Pnt3D pnt3D = new Pnt3D();
		pnt3D.X = P1.X - P2.X;
		pnt3D.Y = P1.Y - P2.Y;
		pnt3D.Z = P1.Z - P2.Z;
		return pnt3D;
	}

	public static bool operator ==(Pnt3D P1, Pnt3D P2)
	{
		if ((object)P1 == null && (object)P2 == null)
		{
			return true;
		}
		bool flag = false;
		return P1.Equal(P2);
	}

	public static bool operator !=(Pnt3D P1, Pnt3D P2)
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
		return "X:" + X.ToString("f4") + "; Y:" + Y.ToString("f4") + "; Z:" + Z.ToString("f4");
	}

	public string ToString(int Decimal)
	{
		return "X:" + X.ToString("f" + Decimal) + "; Y:" + Y.ToString("f" + Decimal) + "; Z:" + Z.ToString("f" + Decimal);
	}

	public new static Pnt3D DecodeFromString(string Value)
	{
		try
		{
			CultureInfo provider = new CultureInfo("en-US", useUserOverride: false);
			string numberDecimalSeparator = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			if (numberDecimalSeparator == ",")
			{
				Value = Value.Replace(",", ".");
			}
			Pnt3D pnt3D = new Pnt3D();
			Value = Value.Replace("X:", "");
			Value = Value.Replace("Y:", "");
			Value = Value.Replace("Z:", "");
			Value = Value.Replace("(", "");
			Value = Value.Replace(")", "");
			string[] array = Value.Split(';');
			if (array.Length == 2)
			{
				pnt3D.X = double.Parse(array[0], provider);
				pnt3D.Y = double.Parse(array[1], provider);
				pnt3D.Z = 0.0;
			}
			if (array.Length > 2)
			{
				pnt3D.X = double.Parse(array[0], provider);
				pnt3D.Y = double.Parse(array[1], provider);
				pnt3D.Z = double.Parse(array[2], provider);
			}
			return pnt3D;
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public new string ToDef()
	{
		return "X:" + X.ToString("") + "; Y:" + Y.ToString("") + "; Z:" + Z.ToString("");
	}

	public string ToDefNumber()
	{
		return X.ToString("") + ";" + Y.ToString("") + ";" + Z.ToString("");
	}

	public new string ToDef(int Space)
	{
		string text = new string(' ', Space);
		return text + "X:" + X.ToString("") + "; Y:" + Y.ToString("") + "; Z:" + Z.ToString("");
	}
}
