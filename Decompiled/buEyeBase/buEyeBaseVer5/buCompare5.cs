using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class buCompare5
{
	public static double resolutionCompare = 0.001;

	public static double RegenDeviation = 0.001;

	public static bool GT(double Value1, double Value2, double Resolution = 0.001)
	{
		if (!(!EQ(Value1, Value2, Resolution) && Value1 > Value2))
		{
			return false;
		}
		return true;
	}

	public static bool GE(double Value1, double Value2, double Resolution = 0.001)
	{
		if (!(EQ(Value1, Value2, Resolution) || Value1 > Value2))
		{
			return false;
		}
		return true;
	}

	public static bool LT(double Value1, double Value2, double Resolution = 0.001)
	{
		if (!(!EQ(Value1, Value2, Resolution) && Value1 < Value2))
		{
			return false;
		}
		return true;
	}

	public static bool LE(double Value1, double Value2, double Resolution = 0.001)
	{
		if (!(EQ(Value1, Value2, Resolution) || Value1 < Value2))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(double Value1, double Value2)
	{
		return EQ(Value1, Value2, resolutionCompare);
	}

	public static bool EQ(Pnt2D Value1, Pnt2D Value2)
	{
		return EQ(Value1, Value2, resolutionCompare);
	}

	public static bool EQ(Point3D Value1, Point3D Value2)
	{
		return EQ(Value1, Value2, resolutionCompare);
	}

	public static bool EQ(Point3D Value1, Point3D Value2, Plane refPlane)
	{
		return EQ(Value1, Value2, resolutionCompare, refPlane);
	}

	public static bool EQ(Pnt3D Value1, Pnt3D Value2)
	{
		return EQ(Value1, Value2, resolutionCompare);
	}

	public static bool EQ(Pnt4D Value1, Pnt4D Value2)
	{
		return EQ(Value1, Value2, resolutionCompare);
	}

	public static bool EQ(Pnt6D Value1, Pnt6D Value2)
	{
		return EQ(Value1, Value2, resolutionCompare);
	}

	public static bool EQ(Pnt6DSimMove Value1, Pnt6DSimMove Value2)
	{
		return EQ(Value1, Value2, resolutionCompare);
	}

	public static bool EQ(Pnt9D Value1, Pnt9D Value2)
	{
		return EQ(Value1, Value2, resolutionCompare);
	}

	public static bool EQ(TpPnt9D Value1, TpPnt9D Value2)
	{
		return EQ(Value1.P9, Value2.P9, resolutionCompare);
	}

	public static bool EQ(Pnt6D Value1, TpPnt9D Value2)
	{
		return EQ(Value1, new Pnt6D(Value2.P9), resolutionCompare);
	}

	public static bool EQ(double Value1, double Value2, double Resolution)
	{
		double num = Math.Abs(Value1 - Value2);
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt2D Value1, Pnt2D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt3D Value1, Pnt3D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(OrientationAngle Value1, OrientationAngle Value2, double Resolution = 0.001)
	{
		double num = Math.Sqrt((Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Point2D Value1, Point2D Value2, double Resolution = 0.001)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(List<Point3D> refList1, List<Point3D> refList2, double Resolution = 0.001)
	{
		if (!((refList1.Count == 0) | (refList2.Count == 0)))
		{
			if (refList1.Count == refList2.Count)
			{
				for (int i = 0; i <= refList1.Count - 1; i++)
				{
					if (!EQ(refList1[i], refList2[i], Resolution))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool EQ(List<Point3D> refList1, Point3D[] refList2, double Resolution = 0.001)
	{
		if (!((refList1.Count == 0) | (refList2.Length == 0)))
		{
			if (refList1.Count == refList2.Length)
			{
				for (int i = 0; i <= refList1.Count - 1; i++)
				{
					if (!EQ(refList1[i], refList2[i], Resolution))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool EQ(Point3D Value1, Point3D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Point4D Value1, Point4D Value2, bool UseW = false, double Resolution = 0.001)
	{
		double num = 0.0;
		num = ((!UseW) ? Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) : Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.W - Value2.W) * (Value1.W - Value2.W)));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Point3D Value1, Point3D Value2, double Resolution, Plane refPlane)
	{
		double num = (((refPlane == Plane.XY) | (refPlane == Plane.YX)) ? Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y)) : (((refPlane == Plane.XZ) | (refPlane == Plane.ZX)) ? Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) : (((refPlane == Plane.YZ) | (refPlane == Plane.ZY)) ? Math.Sqrt((Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)) : Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z)))));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Vector3D Value1, Vector3D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt4D Value1, Pnt4D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.W - Value2.W) * (Value1.W - Value2.W));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt3D Value1, Pnt9D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt9D Value1, Pnt3D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt6D Value1, Pnt6D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt6DS Value1, Pnt6DS Value2, double Resolution = 0.001)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt6DSim Value1, Pnt6DSim Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt6DSimMove Value1, Pnt6DSimMove Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C));
		if (Value1.isMCode == Value2.isMCode)
		{
			if (Value1.isMCode != Value2.isMCode || Value1.MCode == Value2.MCode)
			{
				if (Value1.ToolNo == Value2.ToolNo)
				{
					return (num < Resolution) ? true : false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool EQ(Pnt9D Value1, Pnt9D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z) + (Value1.A - Value2.A) * (Value1.A - Value2.A) + (Value1.B - Value2.B) * (Value1.B - Value2.B) + (Value1.C - Value2.C) * (Value1.C - Value2.C) + (Value1.U - Value2.U) * (Value1.U - Value2.U) + (Value1.V - Value2.V) * (Value1.V - Value2.V) + (Value1.W - Value2.W) * (Value1.W - Value2.W));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static bool EQ(Pnt3D Value1, Pnt9DCam Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.P9.X) * (Value1.X - Value2.P9.X) + (Value1.Y - Value2.P9.Y) * (Value1.Y - Value2.P9.Y) + (Value1.Z - Value2.P9.Z) * (Value1.Z - Value2.P9.Z));
		if (!(num < Resolution))
		{
			return false;
		}
		return true;
	}

	public static void CheckDuplicatedPointsWithPrevious(ref List<List<Pnt3D>> Points)
	{
		try
		{
			List<List<Pnt3D>> list = new List<List<Pnt3D>>();
			for (int i = 0; i <= Points.Count - 1; i++)
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				Pnt3D.Copy(Points[i], ref CopiedPnt);
				CheckDuplicatedPointsWithPrevious(ref CopiedPnt);
				list.Add(CopiedPnt);
			}
			Points.Clear();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				Points.Add(list[j]);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CheckDuplicatedPointsWithPrevious(ref List<Pnt3D> Points)
	{
		try
		{
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			if (Points.Count <= 0)
			{
				return;
			}
			Pnt3D.Copy(Points, ref CopiedPnt);
			Points.Clear();
			Points.Add(new Pnt3D(CopiedPnt[0]));
			for (int i = 1; i <= CopiedPnt.Count - 1; i++)
			{
				if (!EQ(Points[Points.Count - 1], CopiedPnt[i]))
				{
					Points.Add(new Pnt3D(CopiedPnt[i]));
				}
			}
			if (Points.Count > 0 && !EQ(Points[Points.Count - 1], CopiedPnt[CopiedPnt.Count - 1]))
			{
				Points.RemoveAt(Points.Count - 1);
				Points.Add(new Pnt3D(CopiedPnt[CopiedPnt.Count - 1]));
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CheckDuplicatedPointsWithPrevious(ref List<Pnt3D> Points, double Resolution)
	{
		try
		{
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			if (Points.Count <= 0)
			{
				return;
			}
			Pnt3D.Copy(Points, ref CopiedPnt);
			Points.Clear();
			Points.Add(new Pnt3D(CopiedPnt[0]));
			for (int i = 1; i <= CopiedPnt.Count - 1; i++)
			{
				if (!EQ(Points[Points.Count - 1], CopiedPnt[i], Resolution))
				{
					Points.Add(new Pnt3D(CopiedPnt[i]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}
}
