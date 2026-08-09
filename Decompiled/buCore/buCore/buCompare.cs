using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buCore;

public class buCompare
{
	public static bool EQ(double Value1, double Value2)
	{
		return EQ(Value1, Value2, buSystem.resolutionCompare);
	}

	public static bool EQ(Pnt2D Value1, Pnt2D Value2)
	{
		return EQ(Value1, Value2, buSystem.resolutionCompare);
	}

	public static bool EQ(Pnt3D Value1, Pnt3D Value2)
	{
		return EQ(Value1, Value2, buSystem.resolutionCompare);
	}

	public static bool EQ(Pnt4D Value1, Pnt4D Value2)
	{
		return EQ(Value1, Value2, buSystem.resolutionCompare);
	}

	public static bool EQ(Pnt6D Value1, Pnt6D Value2)
	{
		return EQ(Value1, Value2, buSystem.resolutionCompare);
	}

	public static bool EQ(Pnt9D Value1, Pnt9D Value2)
	{
		return EQ(Value1, Value2, buSystem.resolutionCompare);
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
				List<Pnt3D> TargetList = new List<Pnt3D>();
				buGeneral.CopyLists(Points[i], ref TargetList);
				CheckDuplicatedPointsWithPrevious(ref TargetList);
				list.Add(TargetList);
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
			List<Pnt3D> TargetList = new List<Pnt3D>();
			if (Points.Count <= 0)
			{
				return;
			}
			buGeneral.CopyLists(Points, ref TargetList);
			Points.Clear();
			Points.Add(new Pnt3D(TargetList[0]));
			for (int i = 1; i <= TargetList.Count - 1; i++)
			{
				if (!EQ(Points[Points.Count - 1], TargetList[i]))
				{
					Points.Add(new Pnt3D(TargetList[i]));
				}
			}
			if (Points.Count > 0 && !EQ(Points[Points.Count - 1], TargetList[TargetList.Count - 1]))
			{
				Points.RemoveAt(Points.Count - 1);
				Points.Add(new Pnt3D(TargetList[TargetList.Count - 1]));
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
			List<Pnt3D> TargetList = new List<Pnt3D>();
			if (Points.Count <= 0)
			{
				return;
			}
			buGeneral.CopyLists(Points, ref TargetList);
			Points.Clear();
			Points.Add(new Pnt3D(TargetList[0]));
			for (int i = 1; i <= TargetList.Count - 1; i++)
			{
				if (!EQ(Points[Points.Count - 1], TargetList[i], Resolution))
				{
					Points.Add(new Pnt3D(TargetList[i]));
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
