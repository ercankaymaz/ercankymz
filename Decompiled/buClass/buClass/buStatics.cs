using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace buClass;

public class buStatics
{
	public static void LoadbuClassLanguages(string FileName, int Language)
	{
		List<Type> list = (from t in Assembly.GetExecutingAssembly().GetTypes()
			where t.Namespace == "buClass"
			select t).ToList();
		List<string> StringList = new List<string>();
		OpenFromFile(FileName, ref StringList);
		for (int num = 0; num <= list.Count - 1; num++)
		{
			if (!(list[num].GetType().IsClass & !list[num].GetType().IsEnum))
			{
				continue;
			}
			FieldInfo[] fields = list[num].GetFields();
			if (fields == null)
			{
				continue;
			}
			for (int num2 = 0; num2 <= fields.Length - 1; num2++)
			{
				if (fields[num2].IsStatic && ((fields[num2].Name == "Captions") | (fields[num2].Name == "Caption")))
				{
					List<string> CalcList = new List<string>();
					string name = list[num].Name;
					GetItemsAccordingToTheLang(ReadXmlItem("<" + name + ">", "</" + name + ">", StringList), Language, ref CalcList);
					if (CalcList.Count > 0)
					{
						fields[num2].SetValue(list[num], CalcList);
					}
				}
			}
		}
	}

	public static void GetItemsAccordingToTheLang(List<string> RefList, int Language, ref List<string> CalcList)
	{
		try
		{
			if (RefList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				string[] array = RefList[i].Split('|');
				if (array.Length > 1)
				{
					string[] array2 = array[1].Split(';');
					if (Language <= array2.Length - 1)
					{
						CalcList.Add(array2[Language].Trim());
					}
				}
				else
				{
					string[] array3 = RefList[i].Split(';');
					if (Language <= array3.Length - 1)
					{
						CalcList.Add(array3[Language].Trim());
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static List<string> ReadXmlItem(string StartString, string EndString, List<string> SourceList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				if (SourceList[i].ToString().Trim() == EndString)
				{
					return list;
				}
				if (flag)
				{
					list.Add(SourceList[i].ToString().Trim());
				}
				string text = SourceList[i].ToString().Trim();
				if (SourceList[i].ToString().Trim() == StartString)
				{
					flag = true;
				}
			}
			return list;
		}
		catch (Exception mSException)
		{
			buLog.addLog("ReadXmlItem", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new List<string>();
		}
	}

	public static void BoxSizeCalculate(List<Pnt3D> Points, ref Pnt3D MinPoint, ref Pnt3D MaxPoint)
	{
		try
		{
			if (Points.Count == 0)
			{
				MinPoint = new Pnt3D();
				MaxPoint = new Pnt3D();
				return;
			}
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
		}
		catch (Exception mSException)
		{
			string text = "Count: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void BoxSizeCalculate(List<List<Pnt3D>> Points, ref Pnt3D MinPoint, ref Pnt3D MaxPoint)
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
		}
		catch (Exception mSException)
		{
			string text = "Count: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static double Length3D(Pnt3D Pnt1, Pnt3D Pnt2)
	{
		try
		{
			double num = 0.0;
			return Math.Sqrt((Pnt1.X - Pnt2.X) * (Pnt1.X - Pnt2.X) + (Pnt1.Y - Pnt2.Y) * (Pnt1.Y - Pnt2.Y) + (Pnt1.Z - Pnt2.Z) * (Pnt1.Z - Pnt2.Z));
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static double Length3D(List<Pnt3D> Points)
	{
		double num = 0.0;
		try
		{
			for (int i = 1; i < Points.Count; i++)
			{
				num += Math.Sqrt((Points[i].X - Points[i - 1].X) * (Points[i].X - Points[i - 1].X) + (Points[i].Y - Points[i - 1].Y) * (Points[i].Y - Points[i - 1].Y) + (Points[i].Z - Points[i - 1].Z) * (Points[i].Z - Points[i - 1].Z));
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
		return num;
	}

	public static void EllipseToLineerByCount(Pnt3D Center, double Major, double Minor, double Angle, int Count, WorkPlane Plane, ref List<Pnt3D> Vertices)
	{
		try
		{
			ArcEllipseToLineerByCount(Center, Major, Minor, 0.0, 360.0, Angle, Count, Plane, ref Vertices);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ArcEllipseToLineerByCount(Pnt3D Center, double Major, double Minor, double StartAngle, double EndAngle, double Angle, int Count, WorkPlane Plane, ref List<Pnt3D> Vertices)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			Pnt3D pnt3D = new Pnt3D();
			Vertices.Clear();
			num = EndAngle - StartAngle;
			num3 = Math.PI * 2.0 * Math.Sqrt(0.5 * (Math.Pow(Major, 2.0) + Math.Pow(Minor, 2.0)));
			if (Count <= 0)
			{
				return;
			}
			if (Count > 0)
			{
				num2 = num / (double)Count;
			}
			num6 = (360.0 - Angle) * Math.PI / 180.0;
			num4 = Math.Sin(num6);
			num5 = Math.Cos(num6);
			for (int i = 0; i <= Count; i++)
			{
				pnt3D = new Pnt3D();
				num7 = StartAngle + (double)i * num2;
				num8 = Major * Math.Cos(DegreeToRadianGreat360(num7));
				num9 = Minor * Math.Sin(DegreeToRadianGreat360(num7));
				if (Plane.PlaneType == planeType.XY)
				{
					pnt3D.X = Center.X + num8 * num5 + num9 * num4;
					pnt3D.Y = Center.Y - num8 * num4 + num9 * num5;
					pnt3D.Z = Center.Z;
				}
				if (Plane.PlaneType == planeType.XZ)
				{
					pnt3D.X = Center.X + num8 * num5 + num9 * num4;
					pnt3D.Y = Center.Y;
					pnt3D.Z = Center.Z - num8 * num4 + num9 * num5;
				}
				if (Plane.PlaneType == planeType.YZ)
				{
					pnt3D.X = Center.X;
					pnt3D.Y = Center.Y + num8 * num5 + num9 * num4;
					pnt3D.Z = Center.Z - num8 * num4 + num9 * num5;
				}
				Vertices.Add(pnt3D);
			}
		}
		catch (Exception mSException)
		{
			string text = "Center: " + Center.ToString() + " - MajRad: " + Major + " - MinRad: " + Minor + " - SA: " + StartAngle + " - EA: " + EndAngle + " - Ang: " + Angle + " - Cnt: " + Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void Arc3Point(Pnt3D FirstPoint, Pnt3D SecondPoint, Pnt3D ThirdPoint, WorkPlane Plane, ref Pnt3D Center, ref double Radius, ref double StartAngle, ref double EndAngle, ref List<Pnt3D> Vertices)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		double num14 = 0.0;
		if (Plane.PlaneType == planeType.XY)
		{
			num = 0.5 * Math.Pow((Math.Pow(SecondPoint.Y, 2.0) - 2.0 * SecondPoint.Y * ThirdPoint.Y + Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(ThirdPoint.X, 2.0) - 2.0 * SecondPoint.X * ThirdPoint.X) * (-2.0 * FirstPoint.X * ThirdPoint.X + Math.Pow(FirstPoint.X, 2.0) - 2.0 * FirstPoint.Y * ThirdPoint.Y + Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(ThirdPoint.X, 2.0)) * (Math.Pow(FirstPoint.X, 2.0) - 2.0 * SecondPoint.X * FirstPoint.X + Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(SecondPoint.Y, 2.0) - 2.0 * FirstPoint.Y * SecondPoint.Y), 0.5) / (FirstPoint.X * SecondPoint.Y - FirstPoint.X * ThirdPoint.Y - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X);
			num2 = -0.5 * Math.Pow((Math.Pow(SecondPoint.Y, 2.0) - 2.0 * SecondPoint.Y * ThirdPoint.Y + Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(ThirdPoint.X, 2.0) - 2.0 * SecondPoint.X * ThirdPoint.X) * (-2.0 * FirstPoint.X * ThirdPoint.X + Math.Pow(FirstPoint.X, 2.0) - 2.0 * FirstPoint.Y * ThirdPoint.Y + Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(ThirdPoint.X, 2.0)) * (Math.Pow(FirstPoint.X, 2.0) - 2.0 * SecondPoint.X * FirstPoint.X + Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(SecondPoint.Y, 2.0) - 2.0 * FirstPoint.Y * SecondPoint.Y), 0.5) / (FirstPoint.X * SecondPoint.Y - FirstPoint.X * ThirdPoint.Y - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X);
			num3 = 0.5 * ((SecondPoint.Y - ThirdPoint.Y) * Math.Pow(FirstPoint.X, 2.0) - FirstPoint.Y * Math.Pow(SecondPoint.X, 2.0) + ThirdPoint.Y * Math.Pow(SecondPoint.X, 2.0) - ThirdPoint.Y * Math.Pow(FirstPoint.Y, 2.0) + FirstPoint.Y * Math.Pow(ThirdPoint.X, 2.0) - SecondPoint.Y * Math.Pow(ThirdPoint.Y, 2.0) - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.Y + Math.Pow(ThirdPoint.Y, 2.0) * FirstPoint.Y + SecondPoint.Y * Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(SecondPoint.Y, 2.0) * ThirdPoint.Y - Math.Pow(SecondPoint.Y, 2.0) * FirstPoint.Y) / ((SecondPoint.Y - ThirdPoint.Y) * FirstPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X);
			num4 = 0.5 * ((SecondPoint.Y - ThirdPoint.Y) * Math.Pow(FirstPoint.X, 2.0) - FirstPoint.Y * Math.Pow(SecondPoint.X, 2.0) + ThirdPoint.Y * Math.Pow(SecondPoint.X, 2.0) - ThirdPoint.Y * Math.Pow(FirstPoint.Y, 2.0) + FirstPoint.Y * Math.Pow(ThirdPoint.X, 2.0) - SecondPoint.Y * Math.Pow(ThirdPoint.Y, 2.0) - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.Y + Math.Pow(ThirdPoint.Y, 2.0) * FirstPoint.Y + SecondPoint.Y * Math.Pow(FirstPoint.Y, 2.0) + Math.Pow(SecondPoint.Y, 2.0) * ThirdPoint.Y - Math.Pow(SecondPoint.Y, 2.0) * FirstPoint.Y) / ((SecondPoint.Y - ThirdPoint.Y) * FirstPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X);
			num5 = -0.5 * ((SecondPoint.X - ThirdPoint.X) * Math.Pow(FirstPoint.X, 2.0) + (Math.Pow(ThirdPoint.X, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) - Math.Pow(SecondPoint.X, 2.0) - Math.Pow(SecondPoint.Y, 2.0)) * FirstPoint.X - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.X, 2.0) + Math.Pow(FirstPoint.Y, 2.0) * SecondPoint.X - Math.Pow(FirstPoint.Y, 2.0) * ThirdPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.Y, 2.0) - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.X) / ((SecondPoint.Y - ThirdPoint.Y) * FirstPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X);
			num6 = -0.5 * ((SecondPoint.X - ThirdPoint.X) * Math.Pow(FirstPoint.X, 2.0) + (Math.Pow(ThirdPoint.X, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) - Math.Pow(SecondPoint.X, 2.0) - Math.Pow(SecondPoint.Y, 2.0)) * FirstPoint.X - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.X, 2.0) + Math.Pow(FirstPoint.Y, 2.0) * SecondPoint.X - Math.Pow(FirstPoint.Y, 2.0) * ThirdPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.Y, 2.0) - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.X) / ((SecondPoint.Y - ThirdPoint.Y) * FirstPoint.X - ThirdPoint.X * SecondPoint.Y + ThirdPoint.Y * SecondPoint.X - FirstPoint.Y * SecondPoint.X + FirstPoint.Y * ThirdPoint.X);
			Radius = Math.Abs(num);
			Center.X = num3;
			Center.Y = num5;
			Center.Z = FirstPoint.Z;
			num9 = PointAngle(FirstPoint.X, FirstPoint.Y, Center.X, Center.Y);
			num10 = PointAngle(SecondPoint.X, SecondPoint.Y, Center.X, Center.Y);
			num11 = PointAngle(ThirdPoint.X, ThirdPoint.Y, Center.X, Center.Y);
		}
		if (Plane.PlaneType == planeType.XZ)
		{
			num = 0.5 * Math.Pow((Math.Pow(SecondPoint.Z, 2.0) - 2.0 * SecondPoint.Z * ThirdPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(ThirdPoint.X, 2.0) - 2.0 * SecondPoint.X * ThirdPoint.X) * (-2.0 * FirstPoint.X * ThirdPoint.X + Math.Pow(FirstPoint.X, 2.0) - 2.0 * FirstPoint.Z * ThirdPoint.Z + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(ThirdPoint.X, 2.0)) * (Math.Pow(FirstPoint.X, 2.0) - 2.0 * SecondPoint.X * FirstPoint.X + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(SecondPoint.Z, 2.0) - 2.0 * FirstPoint.Z * SecondPoint.Z), 0.5) / (FirstPoint.X * SecondPoint.Z - FirstPoint.X * ThirdPoint.Z - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X);
			num2 = -0.5 * Math.Pow((Math.Pow(SecondPoint.Z, 2.0) - 2.0 * SecondPoint.Z * ThirdPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(ThirdPoint.X, 2.0) - 2.0 * SecondPoint.X * ThirdPoint.X) * (-2.0 * FirstPoint.X * ThirdPoint.X + Math.Pow(FirstPoint.X, 2.0) - 2.0 * FirstPoint.Z * ThirdPoint.Z + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(ThirdPoint.X, 2.0)) * (Math.Pow(FirstPoint.X, 2.0) - 2.0 * SecondPoint.X * FirstPoint.X + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.X, 2.0) + Math.Pow(SecondPoint.Z, 2.0) - 2.0 * FirstPoint.Z * SecondPoint.Z), 0.5) / (FirstPoint.X * SecondPoint.Z - FirstPoint.X * ThirdPoint.Z - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X);
			num3 = 0.5 * ((SecondPoint.Z - ThirdPoint.Z) * Math.Pow(FirstPoint.X, 2.0) - FirstPoint.Z * Math.Pow(SecondPoint.X, 2.0) + ThirdPoint.Z * Math.Pow(SecondPoint.X, 2.0) - ThirdPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + FirstPoint.Z * Math.Pow(ThirdPoint.X, 2.0) - SecondPoint.Z * Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) * FirstPoint.Z + SecondPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Z, 2.0) * ThirdPoint.Z - Math.Pow(SecondPoint.Z, 2.0) * FirstPoint.Z) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X);
			num4 = 0.5 * ((SecondPoint.Z - ThirdPoint.Z) * Math.Pow(FirstPoint.X, 2.0) - FirstPoint.Z * Math.Pow(SecondPoint.X, 2.0) + ThirdPoint.Z * Math.Pow(SecondPoint.X, 2.0) - ThirdPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + FirstPoint.Z * Math.Pow(ThirdPoint.X, 2.0) - SecondPoint.Z * Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) * FirstPoint.Z + SecondPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Z, 2.0) * ThirdPoint.Z - Math.Pow(SecondPoint.Z, 2.0) * FirstPoint.Z) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X);
			num7 = -0.5 * ((SecondPoint.X - ThirdPoint.X) * Math.Pow(FirstPoint.X, 2.0) + (Math.Pow(ThirdPoint.X, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(SecondPoint.X, 2.0) - Math.Pow(SecondPoint.Z, 2.0)) * FirstPoint.X - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.X, 2.0) + Math.Pow(FirstPoint.Z, 2.0) * SecondPoint.X - Math.Pow(FirstPoint.Z, 2.0) * ThirdPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.Z, 2.0) - Math.Pow(ThirdPoint.Z, 2.0) * SecondPoint.X) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X);
			num8 = -0.5 * ((SecondPoint.X - ThirdPoint.X) * Math.Pow(FirstPoint.X, 2.0) + (Math.Pow(ThirdPoint.X, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(SecondPoint.X, 2.0) - Math.Pow(SecondPoint.Z, 2.0)) * FirstPoint.X - Math.Pow(ThirdPoint.X, 2.0) * SecondPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.X, 2.0) + Math.Pow(FirstPoint.Z, 2.0) * SecondPoint.X - Math.Pow(FirstPoint.Z, 2.0) * ThirdPoint.X + ThirdPoint.X * Math.Pow(SecondPoint.Z, 2.0) - Math.Pow(ThirdPoint.Z, 2.0) * SecondPoint.X) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.X - ThirdPoint.X * SecondPoint.Z + ThirdPoint.Z * SecondPoint.X - FirstPoint.Z * SecondPoint.X + FirstPoint.Z * ThirdPoint.X);
			Radius = Math.Abs(num);
			Center.X = num3;
			Center.Z = num7;
			Center.Y = FirstPoint.Y;
			num9 = PointAngle(FirstPoint.X, FirstPoint.Z, Center.X, Center.Z);
			num10 = PointAngle(SecondPoint.X, SecondPoint.Z, Center.X, Center.Z);
			num11 = PointAngle(ThirdPoint.X, ThirdPoint.Z, Center.X, Center.Z);
		}
		if (Plane.PlaneType == planeType.YZ)
		{
			num = 0.5 * Math.Pow((Math.Pow(SecondPoint.Z, 2.0) - 2.0 * SecondPoint.Z * ThirdPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) - 2.0 * SecondPoint.Y * ThirdPoint.Y) * (-2.0 * FirstPoint.Y * ThirdPoint.Y + Math.Pow(FirstPoint.Y, 2.0) - 2.0 * FirstPoint.Z * ThirdPoint.Z + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(ThirdPoint.Y, 2.0)) * (Math.Pow(FirstPoint.Y, 2.0) - 2.0 * SecondPoint.Y * FirstPoint.Y + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(SecondPoint.Z, 2.0) - 2.0 * FirstPoint.Z * SecondPoint.Z), 0.5) / (FirstPoint.Y * SecondPoint.Z - FirstPoint.Y * ThirdPoint.Z - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y);
			num2 = -0.5 * Math.Pow((Math.Pow(SecondPoint.Z, 2.0) - 2.0 * SecondPoint.Z * ThirdPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(ThirdPoint.Y, 2.0) - 2.0 * SecondPoint.Y * ThirdPoint.Y) * (-2.0 * FirstPoint.Y * ThirdPoint.Y + Math.Pow(FirstPoint.Y, 2.0) - 2.0 * FirstPoint.Z * ThirdPoint.Z + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) + Math.Pow(ThirdPoint.Y, 2.0)) * (Math.Pow(FirstPoint.Y, 2.0) - 2.0 * SecondPoint.Y * FirstPoint.Y + Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(SecondPoint.Z, 2.0) - 2.0 * FirstPoint.Z * SecondPoint.Z), 0.5) / (FirstPoint.Y * SecondPoint.Z - FirstPoint.Y * ThirdPoint.Z - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y);
			num5 = 0.5 * ((SecondPoint.Z - ThirdPoint.Z) * Math.Pow(FirstPoint.Y, 2.0) - FirstPoint.Z * Math.Pow(SecondPoint.Y, 2.0) + ThirdPoint.Z * Math.Pow(SecondPoint.Y, 2.0) - ThirdPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + FirstPoint.Z * Math.Pow(ThirdPoint.Y, 2.0) - SecondPoint.Z * Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) * FirstPoint.Z + SecondPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Z, 2.0) * ThirdPoint.Z - Math.Pow(SecondPoint.Z, 2.0) * FirstPoint.Z) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y);
			num6 = 0.5 * ((SecondPoint.Z - ThirdPoint.Z) * Math.Pow(FirstPoint.Y, 2.0) - FirstPoint.Z * Math.Pow(SecondPoint.Y, 2.0) + ThirdPoint.Z * Math.Pow(SecondPoint.Y, 2.0) - ThirdPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + FirstPoint.Z * Math.Pow(ThirdPoint.Y, 2.0) - SecondPoint.Z * Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.Z + Math.Pow(ThirdPoint.Z, 2.0) * FirstPoint.Z + SecondPoint.Z * Math.Pow(FirstPoint.Z, 2.0) + Math.Pow(SecondPoint.Z, 2.0) * ThirdPoint.Z - Math.Pow(SecondPoint.Z, 2.0) * FirstPoint.Z) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y);
			num7 = -0.5 * ((SecondPoint.Y - ThirdPoint.Y) * Math.Pow(FirstPoint.Y, 2.0) + (Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(SecondPoint.Y, 2.0) - Math.Pow(SecondPoint.Z, 2.0)) * FirstPoint.Y - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.Y + ThirdPoint.Y * Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(FirstPoint.Z, 2.0) * SecondPoint.Y - Math.Pow(FirstPoint.Z, 2.0) * ThirdPoint.Y + ThirdPoint.Y * Math.Pow(SecondPoint.Z, 2.0) - Math.Pow(ThirdPoint.Z, 2.0) * SecondPoint.Y) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y);
			num8 = -0.5 * ((SecondPoint.Y - ThirdPoint.Y) * Math.Pow(FirstPoint.Y, 2.0) + (Math.Pow(ThirdPoint.Y, 2.0) + Math.Pow(ThirdPoint.Z, 2.0) - Math.Pow(SecondPoint.Y, 2.0) - Math.Pow(SecondPoint.Z, 2.0)) * FirstPoint.Y - Math.Pow(ThirdPoint.Y, 2.0) * SecondPoint.Y + ThirdPoint.Y * Math.Pow(SecondPoint.Y, 2.0) + Math.Pow(FirstPoint.Z, 2.0) * SecondPoint.Y - Math.Pow(FirstPoint.Z, 2.0) * ThirdPoint.Y + ThirdPoint.Y * Math.Pow(SecondPoint.Z, 2.0) - Math.Pow(ThirdPoint.Z, 2.0) * SecondPoint.Y) / ((SecondPoint.Z - ThirdPoint.Z) * FirstPoint.Y - ThirdPoint.Y * SecondPoint.Z + ThirdPoint.Z * SecondPoint.Y - FirstPoint.Z * SecondPoint.Y + FirstPoint.Z * ThirdPoint.Y);
			Radius = Math.Abs(num);
			Center.X = FirstPoint.X;
			Center.Y = num5;
			Center.Z = num7;
			num9 = PointAngle(FirstPoint.Y, FirstPoint.Z, Center.Y, Center.Z);
			num10 = PointAngle(SecondPoint.Y, SecondPoint.Z, Center.Y, Center.Z);
			num11 = PointAngle(ThirdPoint.Y, ThirdPoint.Z, Center.Y, Center.Z);
		}
		if (num11 > num9)
		{
			if (num11 > num10 && num10 > num9)
			{
				num12 = num9;
				num13 = num11;
			}
			else
			{
				num13 = num9 + 360.0;
				num12 = num11;
			}
		}
		if (num9 > num11)
		{
			if (num9 > num10 && num10 > num11)
			{
				num14 = num9;
				num9 = num11;
				num11 = num14;
				num12 = num9;
				num13 = num11;
			}
			else
			{
				num12 = num9;
				num13 = num11 + 360.0;
			}
		}
		StartAngle = num12;
		EndAngle = num13;
	}

	public static void ArcToLineerByCount(Pnt3D Center, double Radius, double SA, double EA, int Count, WorkPlane Plane, ref List<Pnt3D> Vertices)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			Pnt3D pnt3D = new Pnt3D();
			if (EQ(SA, EA))
			{
				Vertices.Clear();
				return;
			}
			num = EA - SA;
			num3 = Math.PI * 2.0 * Radius * (EA - SA) / 360.0;
			if (Count <= 0)
			{
				Vertices.Clear();
				return;
			}
			if (Count > 0)
			{
				num2 = num / (double)Count;
			}
			Vertices.Clear();
			for (int i = 0; i <= Count; i++)
			{
				pnt3D = new Pnt3D();
				if (Plane.PlaneType == planeType.XY)
				{
					pnt3D.X = Center.X + Radius * Math.Cos(DegreeToRadian(SA + (double)i * num2));
					pnt3D.Y = Center.Y + Radius * Math.Sin(DegreeToRadian(SA + (double)i * num2));
					pnt3D.Z = Center.Z;
				}
				if (Plane.PlaneType == planeType.XZ)
				{
					pnt3D.X = Center.X + Radius * Math.Cos(DegreeToRadian(SA + (double)i * num2));
					pnt3D.Y = Center.Y;
					pnt3D.Z = Center.Z + Radius * Math.Sin(DegreeToRadian(SA + (double)i * num2));
				}
				if (Plane.PlaneType == planeType.YZ)
				{
					pnt3D.X = Center.X;
					pnt3D.Y = Center.Y + Radius * Math.Cos(DegreeToRadian(SA + (double)i * num2));
					pnt3D.Z = Center.Z + Radius * Math.Sin(DegreeToRadian(SA + (double)i * num2));
				}
				Vertices.Add(pnt3D);
			}
		}
		catch (Exception mSException)
		{
			string text = "Center:" + Center.ToString() + "R: " + Radius + " - SA: " + SA + " - EA: " + EA + " - Plane: " + Plane.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ArcToLineer3D(Pnt3D Center, double Radius, double SA, double EA, double Length, WorkPlane Plane, ref List<Pnt3D> Vertices)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = 0;
			Pnt3D pnt3D = new Pnt3D();
			if (EQ(SA, EA, 0.001))
			{
				Vertices.Clear();
				return;
			}
			num = EA - SA;
			num3 = Math.PI * 2.0 * Radius * (EA - SA) / 360.0;
			num4 = Convert.ToInt32(num3 / Length);
			if (num4 <= 0)
			{
				Vertices.Clear();
				return;
			}
			if (num4 > 0)
			{
				num2 = num / (double)num4;
			}
			Vertices.Clear();
			for (int i = 0; i <= num4; i++)
			{
				pnt3D = new Pnt3D();
				if (Plane.PlaneType == planeType.XY)
				{
					pnt3D.X = Center.X + Radius * Math.Cos(DegreeToRadian(SA + (double)i * num2));
					pnt3D.Y = Center.Y + Radius * Math.Sin(DegreeToRadian(SA + (double)i * num2));
					pnt3D.Z = Center.Z;
				}
				if (Plane.PlaneType == planeType.XZ)
				{
					pnt3D.X = Center.X + Radius * Math.Cos(DegreeToRadian(SA + (double)i * num2));
					pnt3D.Y = Center.Y;
					pnt3D.Z = Center.Z + Radius * Math.Sin(DegreeToRadian(SA + (double)i * num2));
				}
				if (Plane.PlaneType == planeType.YZ)
				{
					pnt3D.X = Center.X;
					pnt3D.Y = Center.Y + Radius * Math.Cos(DegreeToRadian(SA + (double)i * num2));
					pnt3D.Z = Center.Z + Radius * Math.Sin(DegreeToRadian(SA + (double)i * num2));
				}
				Vertices.Add(pnt3D);
			}
		}
		catch (Exception mSException)
		{
			string auxMessage = "Center:" + Center.ToString() + "R: " + Radius + " - SA: " + SA + " - EA: " + EA + " - Plane: " + Plane.ToString();
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, auxMessage);
		}
	}

	public static void EllipseToLineer3D(Pnt3D Center, double Major, double Minor, double Angle, double Length, WorkPlane Plane, ref List<Pnt3D> Vertices)
	{
		try
		{
			ArcEllipseToLineer3D(Center, Major, Minor, 0.0, 360.0, Angle, Length, Plane, ref Vertices);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ArcEllipseToLineer3D(Pnt3D Center, double Major, double Minor, double StartAngle, double EndAngle, double Angle, double Length, WorkPlane Plane, ref List<Pnt3D> Vertices)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			int num7 = 0;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			Pnt3D pnt3D = new Pnt3D();
			Vertices.Clear();
			if (Length <= 0.0)
			{
				return;
			}
			num = EndAngle - StartAngle;
			num3 = Math.PI * 2.0 * Math.Sqrt(0.5 * (Math.Pow(Major, 2.0) + Math.Pow(Minor, 2.0)));
			num7 = Convert.ToInt32(num3 / Length);
			if (num7 <= 0)
			{
				return;
			}
			if (num7 > 0)
			{
				num2 = num / (double)num7;
			}
			num6 = (360.0 - Angle) * Math.PI / 180.0;
			num4 = Math.Sin(num6);
			num5 = Math.Cos(num6);
			for (int i = 0; i <= num7; i++)
			{
				pnt3D = new Pnt3D();
				num8 = StartAngle + (double)i * num2;
				num9 = Major * Math.Cos(DegreeToRadianGreat360(num8));
				num10 = Minor * Math.Sin(DegreeToRadianGreat360(num8));
				if (Plane.PlaneType == planeType.XY)
				{
					pnt3D.X = Center.X + num9 * num5 + num10 * num4;
					pnt3D.Y = Center.Y - num9 * num4 + num10 * num5;
					pnt3D.Z = Center.Z;
				}
				if (Plane.PlaneType == planeType.XZ)
				{
					pnt3D.X = Center.X + num9 * num5 + num10 * num4;
					pnt3D.Y = Center.Y;
					pnt3D.Z = Center.Z - num9 * num4 + num10 * num5;
				}
				if (Plane.PlaneType == planeType.YZ)
				{
					pnt3D.X = Center.X;
					pnt3D.Y = Center.Y + num9 * num5 + num10 * num4;
					pnt3D.Z = Center.Z - num9 * num4 + num10 * num5;
				}
				Vertices.Add(pnt3D);
			}
		}
		catch (Exception mSException)
		{
			string text = "Center: " + Center.ToString() + " - MajRad: " + Major + " - MinRad: " + Minor + " - SA: " + StartAngle + " - EA: " + EndAngle + " - Ang: " + Angle + " - Len: " + Length;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static int EllipseVerticeCountByResolution(double MajorRadius, double MinorRadius, EntityResolution EntResolution)
	{
		try
		{
			int result = 10;
			double num = 0.0;
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByNumber)
			{
				result = EntResolution.GeometricCount;
			}
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByLength)
			{
				num = EllipseCircumference(MajorRadius, MinorRadius);
				result = Convert.ToInt32(num / EntResolution.GeometricLength);
			}
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByLnRadius && (MajorRadius > 0.0 || MinorRadius > 0.0))
			{
				result = Convert.ToInt32(Math.Log((Math.Abs(MajorRadius) + Math.Abs(MinorRadius)) / 2.0, Math.E) * EntResolution.LnRatio);
			}
			return result;
		}
		catch (Exception mSException)
		{
			string text = "Major R: " + MajorRadius + " - Minor R: " + MinorRadius + " - Entitiy Res: " + EntResolution.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return -1;
		}
	}

	public static int ArcEllipseVerticeCountByResolution(double MajorRadius, double MinorRadius, double StartAngle, double EndAngle, EntityResolution EntResolution)
	{
		try
		{
			int result = 10;
			double num = 0.0;
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByNumber)
			{
				result = EntResolution.GeometricCount;
			}
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByLength)
			{
				num = EllipseCircumference(MajorRadius, MinorRadius);
				result = Convert.ToInt32(num * ((EndAngle - StartAngle) / 360.0) / EntResolution.GeometricLength);
			}
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByLnRadius && (MajorRadius > 0.0 || MinorRadius > 0.0))
			{
				result = Convert.ToInt32(Math.Log((MajorRadius + MinorRadius) / 2.0, Math.E) * EntResolution.LnRatio);
			}
			return result;
		}
		catch (Exception mSException)
		{
			string text = "Major R: " + MajorRadius + " - Minor R: " + MinorRadius + "- SA: " + StartAngle + " - EA: " + EndAngle + " - Entitiy Res: " + EntResolution.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return -1;
		}
	}

	public static int ArcVerticeCountByResolution(double Radius, double StartAngle, double EndAngle, EntityResolution EntResolution)
	{
		try
		{
			int num = 10;
			double num2 = 0.0;
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByNumber)
			{
				num = EntResolution.GeometricCount;
				if (num < 10)
				{
					num = 10;
				}
			}
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByLength)
			{
				if (IsNumeric(Radius.ToString()))
				{
					num2 = Math.PI * 2.0 * Radius;
					num = Convert.ToInt32(num2 * ((EndAngle - StartAngle) / 360.0) / EntResolution.GeometricLength);
				}
				if (num < 10)
				{
					num = 10;
				}
			}
			if (EntResolution.ResolutionTypes == EntityResolutionType.ByLnRadius)
			{
				if (IsNumeric(Radius.ToString()) && Radius > 0.0)
				{
					num = Convert.ToInt32(Math.Log(Radius, Math.E) * EntResolution.LnRatio);
				}
				if (num < 10)
				{
					num = 10;
				}
			}
			return num;
		}
		catch (Exception mSException)
		{
			string text = "R: " + Radius + " - SA: " + StartAngle + " - EA: " + EndAngle + " - Ent Res:" + EntResolution.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return -1;
		}
	}

	public static void ArcStartMiddleEndPoint(Pnt3D CenterPoint, double Radius, double StartAngle, double EndAngle, WorkPlane Plane, ref Pnt3D StartPoint, ref Pnt3D MiddlePoint, ref Pnt3D EndPoint)
	{
		try
		{
			if (WorkPlane.isPlaneXY(Plane))
			{
				StartPoint.X = CenterPoint.X + Radius * Math.Cos(DegreeToRadian(StartAngle));
				StartPoint.Y = CenterPoint.Y + Radius * Math.Sin(DegreeToRadian(StartAngle));
				StartPoint.Z = CenterPoint.Z;
				MiddlePoint.X = CenterPoint.X + Radius * Math.Cos(DegreeToRadian((StartAngle + EndAngle) / 2.0));
				MiddlePoint.Y = CenterPoint.Y + Radius * Math.Sin(DegreeToRadian((StartAngle + EndAngle) / 2.0));
				MiddlePoint.Z = CenterPoint.Z;
				EndPoint.X = CenterPoint.X + Radius * Math.Cos(DegreeToRadian(EndAngle));
				EndPoint.Y = CenterPoint.Y + Radius * Math.Sin(DegreeToRadian(EndAngle));
				EndPoint.Z = CenterPoint.Z;
			}
			if (WorkPlane.isPlaneXZ(Plane))
			{
				StartPoint.X = CenterPoint.X + Radius * Math.Cos(DegreeToRadian(StartAngle));
				StartPoint.Y = CenterPoint.Y;
				StartPoint.Z = CenterPoint.Z + Radius * Math.Sin(DegreeToRadian(StartAngle));
				MiddlePoint.X = CenterPoint.X + Radius * Math.Cos(DegreeToRadian((StartAngle + EndAngle) / 2.0));
				MiddlePoint.Y = CenterPoint.Y;
				MiddlePoint.Z = CenterPoint.Z + Radius * Math.Sin(DegreeToRadian((StartAngle + EndAngle) / 2.0));
				EndPoint.X = CenterPoint.X + Radius * Math.Cos(DegreeToRadian(EndAngle));
				EndPoint.Y = CenterPoint.Y;
				EndPoint.Z = CenterPoint.Z + Radius * Math.Sin(DegreeToRadian(EndAngle));
			}
			if (WorkPlane.isPlaneYZ(Plane))
			{
				StartPoint.X = CenterPoint.X;
				StartPoint.Y = CenterPoint.Y + Radius * Math.Cos(DegreeToRadian(StartAngle));
				StartPoint.Z = CenterPoint.Z + Radius * Math.Sin(DegreeToRadian(StartAngle));
				MiddlePoint.X = CenterPoint.X;
				MiddlePoint.Y = CenterPoint.Y + Radius * Math.Cos(DegreeToRadian((StartAngle + EndAngle) / 2.0));
				MiddlePoint.Z = CenterPoint.Z + Radius * Math.Sin(DegreeToRadian((StartAngle + EndAngle) / 2.0));
				EndPoint.X = CenterPoint.X;
				EndPoint.Y = CenterPoint.Y + Radius * Math.Cos(DegreeToRadian(EndAngle));
				EndPoint.Z = CenterPoint.Z + Radius * Math.Sin(DegreeToRadian(EndAngle));
			}
		}
		catch (Exception mSException)
		{
			string text = "CenterPoint: " + CenterPoint.ToString() + " - Radius: " + Radius + " - StartAngle: " + StartAngle + " - EndAngle: " + EndAngle + " - Plane: " + Plane.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static double EllipseCircumference(double MajorRadius, double MinorRadius)
	{
		try
		{
			return Math.Sqrt((MajorRadius * MajorRadius + MinorRadius * MinorRadius) * 0.5) * Math.PI * 2.0;
		}
		catch (Exception mSException)
		{
			string text = "Major R: " + MajorRadius + " - Minor R: " + MinorRadius;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return 0.0;
		}
	}

	public static double ArcEllipseCircumference(double MajorRadius, double MinorRadius, double StartAngle, double EndAngle)
	{
		try
		{
			return Math.Sqrt((MajorRadius * MajorRadius + MinorRadius * MinorRadius) * 0.5) * Math.PI * 2.0 * (EndAngle - StartAngle) / 360.0;
		}
		catch (Exception mSException)
		{
			string text = "Major R: " + MajorRadius + " - Minor R: " + MinorRadius + "- SA: " + StartAngle + " - EA: " + EndAngle;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return 0.0;
		}
	}

	public static void RectangleCorner(Pnt3D FirstPoint, Pnt3D SecondPoint, WorkPlane Plane, ref List<Pnt3D> Vertices)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			Vertices.Clear();
			if (Plane.PlaneType == planeType.XY)
			{
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = SecondPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = SecondPoint.X;
				pnt3D.Y = SecondPoint.Y;
				pnt3D.Z = SecondPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = SecondPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
			}
			if (Plane.PlaneType == planeType.XZ)
			{
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = SecondPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = SecondPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = SecondPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = SecondPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
			}
			if (Plane.PlaneType == planeType.YZ)
			{
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = SecondPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = SecondPoint.Y;
				pnt3D.Z = SecondPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = SecondPoint.Z;
				Vertices.Add(pnt3D);
				pnt3D = new Pnt3D();
				pnt3D.X = FirstPoint.X;
				pnt3D.Y = FirstPoint.Y;
				pnt3D.Z = FirstPoint.Z;
				Vertices.Add(pnt3D);
			}
		}
		catch (Exception mSException)
		{
			string text = "FirstPoint: " + FirstPoint.ToString() + " - SecondPoint: " + SecondPoint.ToString() + " - Plane: " + Plane.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static bool IsNumeric(string Value)
	{
		double result = 0.0;
		return double.TryParse(Value, out result);
	}

	public static double DegreeToRadian(double Degree)
	{
		try
		{
			double result = 0.0;
			if (Degree > 360.0)
			{
				Degree -= 360.0;
				result = Degree * Math.PI / 180.0;
				Degree += 360.0;
			}
			if (Degree <= 360.0)
			{
				result = Degree * Math.PI / 180.0;
			}
			return result;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static double DegreeToRadianGreat360(double Degree)
	{
		try
		{
			double result = 0.0;
			if (Degree > 360.0)
			{
				Degree -= 360.0;
				result = Degree * Math.PI / 180.0 + Math.PI * 2.0;
				Degree += 360.0;
			}
			if (Degree <= 360.0)
			{
				result = Degree * Math.PI / 180.0;
			}
			return result;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static bool EQ(double Value1, double Value2)
	{
		return EQ(Value1, Value2, 0.001);
	}

	public static bool EQ(double Value1, double Value2, double Resolution)
	{
		double num = Math.Abs(Value1 - Value2);
		if (num < Resolution)
		{
			return true;
		}
		return false;
	}

	public static bool EQ(Pnt2D Value1, Pnt2D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y));
		if (num < Resolution)
		{
			return true;
		}
		return false;
	}

	public static bool EQ(Pnt3D Value1, Pnt3D Value2, double Resolution)
	{
		double num = Math.Sqrt((Value1.X - Value2.X) * (Value1.X - Value2.X) + (Value1.Y - Value2.Y) * (Value1.Y - Value2.Y) + (Value1.Z - Value2.Z) * (Value1.Z - Value2.Z));
		if (num < Resolution)
		{
			return true;
		}
		return false;
	}

	public static void CreatBSplineQuadraticUniform(List<Pnt3D> ControlPoints, double dt, bool Closed, ref List<Pnt3D> CalculatedPoints)
	{
		try
		{
			List<Pnt3D> list = new List<Pnt3D>();
			List<Pnt3D> CalculatedPoints2 = new List<Pnt3D>();
			List<Pnt3D> list2 = new List<Pnt3D>();
			Pnt3D pnt3D = new Pnt3D();
			Pnt3D pnt3D2 = new Pnt3D();
			int num = 0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 1.0;
			double num6 = 1.0;
			double num7 = -2.0;
			double num8 = 1.0;
			double num9 = -2.0;
			double num10 = 2.0;
			double num11 = 0.0;
			double num12 = 1.0;
			double num13 = 1.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			CalculatedPoints.Clear();
			num = Convert.ToInt32(1.0 / dt);
			if (Closed)
			{
				pnt3D = new Pnt3D(ControlPoints[0]);
				pnt3D2 = new Pnt3D(ControlPoints[ControlPoints.Count - 1]);
				for (int i = 0; i <= ControlPoints.Count - 1; i++)
				{
					list2.Add(new Pnt3D(ControlPoints[i]));
				}
				list2.Insert(0, new Pnt3D(pnt3D2));
				list2.Add(new Pnt3D(pnt3D));
			}
			else
			{
				for (int j = 0; j <= ControlPoints.Count - 1; j++)
				{
					list2.Add(new Pnt3D(ControlPoints[j]));
				}
				if (list2.Count <= 1)
				{
					return;
				}
				if (list2.Count == 2)
				{
					pnt3D = new Pnt3D(MiddlePointOfTwoPoint(list2[0], list2[1]));
					list2.Insert(1, new Pnt3D(pnt3D));
				}
			}
			for (int k = 1; k <= list2.Count - 2; k++)
			{
				for (int l = 0; l <= num; l++)
				{
					pnt3D = new Pnt3D();
					num5 = (double)l * dt;
					num15 = 0.5 * (num6 * Math.Pow(num5, 2.0) + num9 * num5 + num12) * list2[k - 1].X;
					num16 = 0.5 * (num7 * Math.Pow(num5, 2.0) + num10 * num5 + num13) * list2[k].X;
					num17 = 0.5 * (num8 * Math.Pow(num5, 2.0) + num11 * num5 + num14) * list2[k + 1].X;
					num2 = num15 + num16 + num17;
					num15 = 0.5 * (num6 * Math.Pow(num5, 2.0) + num9 * num5 + num12) * list2[k - 1].Y;
					num16 = 0.5 * (num7 * Math.Pow(num5, 2.0) + num10 * num5 + num13) * list2[k].Y;
					num17 = 0.5 * (num8 * Math.Pow(num5, 2.0) + num11 * num5 + num14) * list2[k + 1].Y;
					num3 = num15 + num16 + num17;
					num15 = 0.5 * (num6 * Math.Pow(num5, 2.0) + num9 * num5 + num12) * list2[k - 1].Z;
					num16 = 0.5 * (num7 * Math.Pow(num5, 2.0) + num10 * num5 + num13) * list2[k].Z;
					num17 = 0.5 * (num8 * Math.Pow(num5, 2.0) + num11 * num5 + num14) * list2[k + 1].Z;
					num4 = num15 + num16 + num17;
					pnt3D.X = num2;
					pnt3D.Y = num3;
					pnt3D.Z = num4;
					CalculatedPoints.Add(pnt3D);
				}
			}
			if (!Closed && CalculatedPoints.Count > 0)
			{
				list.Add(new Pnt3D(ControlPoints[0]));
				list.Add(new Pnt3D(CalculatedPoints[0]));
				num18 = ControlPoints[1].X - ControlPoints[0].X;
				num19 = ControlPoints[1].Y - ControlPoints[0].Y;
				num20 = ControlPoints[1].Z - ControlPoints[0].Z;
				num21 = (CalculatedPoints[1].X - CalculatedPoints[0].X) * (1000.0 / (dt * 1000.0));
				num22 = (CalculatedPoints[1].Y - CalculatedPoints[0].Y) * (1000.0 / (dt * 1000.0));
				num23 = (CalculatedPoints[1].Z - CalculatedPoints[0].Z) * (1000.0 / (dt * 1000.0));
				CreatHermiteCubicSplineWithStartEndVector(list, dt, 1.0, 0.0, new Vec3D(num18, num19, num20), new Vec3D(num21, num22, num23), ref CalculatedPoints2);
				for (int num24 = CalculatedPoints2.Count - 1; num24 >= 0; num24--)
				{
					CalculatedPoints.Insert(0, new Pnt3D(CalculatedPoints2[num24]));
				}
				list.Clear();
				CalculatedPoints2.Clear();
				list.Add(new Pnt3D(CalculatedPoints[CalculatedPoints.Count - 1]));
				list.Add(new Pnt3D(ControlPoints[ControlPoints.Count - 1]));
				num18 = (CalculatedPoints[CalculatedPoints.Count - 1].X - CalculatedPoints[CalculatedPoints.Count - 2].X) * (1000.0 / (dt * 1000.0));
				num19 = (CalculatedPoints[CalculatedPoints.Count - 1].Y - CalculatedPoints[CalculatedPoints.Count - 2].Y) * (1000.0 / (dt * 1000.0));
				num20 = (CalculatedPoints[CalculatedPoints.Count - 1].Z - CalculatedPoints[CalculatedPoints.Count - 2].Z) * (1000.0 / (dt * 1000.0));
				num21 = ControlPoints[ControlPoints.Count - 1].X - ControlPoints[ControlPoints.Count - 2].X;
				num22 = ControlPoints[ControlPoints.Count - 1].Y - ControlPoints[ControlPoints.Count - 2].Y;
				num23 = ControlPoints[ControlPoints.Count - 1].Z - ControlPoints[ControlPoints.Count - 2].Z;
				CreatHermiteCubicSplineWithStartEndVector(list, dt, 1.0, 0.0, new Vec3D(num18, num19, num20), new Vec3D(num21, num22, num23), ref CalculatedPoints2);
				for (int m = 0; m <= CalculatedPoints2.Count - 1; m++)
				{
					CalculatedPoints.Add(new Pnt3D(CalculatedPoints2[m]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "dt: " + dt + " - ControlPoints: " + ControlPoints.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CreatBSplineCubicUniform(List<Pnt3D> ControlPoints, double dt, bool Closed, ref List<Pnt3D> CalculatedPoints)
	{
		try
		{
			List<Pnt3D> list = new List<Pnt3D>();
			List<Pnt3D> CalculatedPoints2 = new List<Pnt3D>();
			List<Pnt3D> list2 = new List<Pnt3D>();
			Pnt3D pnt3D = new Pnt3D();
			Pnt3D pnt3D2 = new Pnt3D();
			Pnt3D pnt3D3 = new Pnt3D();
			int num = 0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 1.0;
			double num6 = -1.0;
			double num7 = 3.0;
			double num8 = -3.0;
			double num9 = 1.0;
			double num10 = 3.0;
			double num11 = -6.0;
			double num12 = 3.0;
			double num13 = 0.0;
			double num14 = -3.0;
			double num15 = 0.0;
			double num16 = 3.0;
			double num17 = 0.0;
			double num18 = 1.0;
			double num19 = 4.0;
			double num20 = 1.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			double num24 = 0.0;
			double num25 = 0.0;
			double num26 = 0.0;
			double num27 = 0.0;
			double num28 = 0.0;
			double num29 = 0.0;
			double num30 = 0.0;
			double num31 = 0.0;
			CalculatedPoints.Clear();
			if (Closed)
			{
				pnt3D = new Pnt3D(ControlPoints[0]);
				pnt3D2 = new Pnt3D(ControlPoints[1]);
				pnt3D3 = new Pnt3D(ControlPoints[ControlPoints.Count - 1]);
				for (int i = 0; i <= ControlPoints.Count - 1; i++)
				{
					list2.Add(new Pnt3D(ControlPoints[i]));
				}
				list2.Insert(0, new Pnt3D(pnt3D3));
				list2.Add(new Pnt3D(pnt3D));
				list2.Add(new Pnt3D(pnt3D2));
			}
			else
			{
				if (ControlPoints.Count <= 1)
				{
					return;
				}
				if (ControlPoints.Count == 2)
				{
					pnt3D = new Pnt3D(MiddlePointOfTwoPoint(ControlPoints[0], ControlPoints[1]));
					ControlPoints.Insert(1, new Pnt3D(pnt3D));
				}
				for (int j = 0; j <= ControlPoints.Count - 1; j++)
				{
					list2.Add(new Pnt3D(ControlPoints[j]));
				}
			}
			num = Convert.ToInt32(1.0 / dt);
			for (int k = 1; k <= list2.Count - 3; k++)
			{
				for (int l = 0; l <= num; l++)
				{
					pnt3D = new Pnt3D();
					num5 = (double)l * dt;
					num22 = (Math.Pow(num5, 3.0) * num6 + Math.Pow(num5, 2.0) * num10 + num5 * num14 + num18) * list2[k - 1].X / 6.0;
					num23 = (Math.Pow(num5, 3.0) * num7 + Math.Pow(num5, 2.0) * num11 + num5 * num15 + num19) * list2[k].X / 6.0;
					num24 = (Math.Pow(num5, 3.0) * num8 + Math.Pow(num5, 2.0) * num12 + num5 * num16 + num20) * list2[k + 1].X / 6.0;
					num25 = (Math.Pow(num5, 3.0) * num9 + Math.Pow(num5, 2.0) * num13 + num5 * num17 + num21) * list2[k + 2].X / 6.0;
					num2 = num22 + num23 + num24 + num25;
					num22 = (Math.Pow(num5, 3.0) * num6 + Math.Pow(num5, 2.0) * num10 + num5 * num14 + num18) * list2[k - 1].Y / 6.0;
					num23 = (Math.Pow(num5, 3.0) * num7 + Math.Pow(num5, 2.0) * num11 + num5 * num15 + num19) * list2[k].Y / 6.0;
					num24 = (Math.Pow(num5, 3.0) * num8 + Math.Pow(num5, 2.0) * num12 + num5 * num16 + num20) * list2[k + 1].Y / 6.0;
					num25 = (Math.Pow(num5, 3.0) * num9 + Math.Pow(num5, 2.0) * num13 + num5 * num17 + num21) * list2[k + 2].Y / 6.0;
					num3 = num22 + num23 + num24 + num25;
					num22 = (Math.Pow(num5, 3.0) * num6 + Math.Pow(num5, 2.0) * num10 + num5 * num14 + num18) * list2[k - 1].Z / 6.0;
					num23 = (Math.Pow(num5, 3.0) * num7 + Math.Pow(num5, 2.0) * num11 + num5 * num15 + num19) * list2[k].Z / 6.0;
					num24 = (Math.Pow(num5, 3.0) * num8 + Math.Pow(num5, 2.0) * num12 + num5 * num16 + num20) * list2[k + 1].Z / 6.0;
					num25 = (Math.Pow(num5, 3.0) * num9 + Math.Pow(num5, 2.0) * num13 + num5 * num17 + num21) * list2[k + 2].Z / 6.0;
					num4 = num22 + num23 + num24 + num25;
					pnt3D.X = num2;
					pnt3D.Y = num3;
					pnt3D.Z = num4;
					CalculatedPoints.Add(pnt3D);
				}
			}
			if (!Closed && CalculatedPoints.Count > 0)
			{
				list.Add(new Pnt3D(ControlPoints[0]));
				list.Add(new Pnt3D(CalculatedPoints[0]));
				num26 = ControlPoints[1].X - ControlPoints[0].X;
				num27 = ControlPoints[1].Y - ControlPoints[0].Y;
				num28 = ControlPoints[1].Z - ControlPoints[0].Z;
				num29 = (CalculatedPoints[1].X - CalculatedPoints[0].X) * (1000.0 / (dt * 1000.0));
				num30 = (CalculatedPoints[1].Y - CalculatedPoints[0].Y) * (1000.0 / (dt * 1000.0));
				num31 = (CalculatedPoints[1].Z - CalculatedPoints[0].Z) * (1000.0 / (dt * 1000.0));
				CreatHermiteCubicSplineWithStartEndVector(list, dt, 1.0, 0.0, new Vec3D(num26, num27, num28), new Vec3D(num29, num30, num31), ref CalculatedPoints2);
				for (int num32 = CalculatedPoints2.Count - 1; num32 >= 0; num32--)
				{
					CalculatedPoints.Insert(0, new Pnt3D(CalculatedPoints2[num32]));
				}
				list.Clear();
				CalculatedPoints2.Clear();
				list.Add(new Pnt3D(CalculatedPoints[CalculatedPoints.Count - 1]));
				list.Add(new Pnt3D(ControlPoints[ControlPoints.Count - 1]));
				num26 = (CalculatedPoints[CalculatedPoints.Count - 1].X - CalculatedPoints[CalculatedPoints.Count - 2].X) * (1000.0 / (dt * 1000.0));
				num27 = (CalculatedPoints[CalculatedPoints.Count - 1].Y - CalculatedPoints[CalculatedPoints.Count - 2].Y) * (1000.0 / (dt * 1000.0));
				num28 = (CalculatedPoints[CalculatedPoints.Count - 1].Z - CalculatedPoints[CalculatedPoints.Count - 2].Z) * (1000.0 / (dt * 1000.0));
				num29 = ControlPoints[ControlPoints.Count - 1].X - ControlPoints[ControlPoints.Count - 2].X;
				num30 = ControlPoints[ControlPoints.Count - 1].Y - ControlPoints[ControlPoints.Count - 2].Y;
				num31 = ControlPoints[ControlPoints.Count - 1].Z - ControlPoints[ControlPoints.Count - 2].Z;
				CreatHermiteCubicSplineWithStartEndVector(list, dt, 1.0, 0.0, new Vec3D(num26, num27, num28), new Vec3D(num29, num30, num31), ref CalculatedPoints2);
				for (int m = 0; m <= CalculatedPoints2.Count - 1; m++)
				{
					CalculatedPoints.Add(new Pnt3D(CalculatedPoints2[m]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "dt: " + dt + " - ControlPoints: " + ControlPoints.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CreatBsplineRationalKnotVector(List<Pnt3D> ControlPoints, int Order, double dt, List<double> Weigth, ref List<Pnt3D> CalculatedPoints)
	{
		try
		{
			List<int> list = new List<int>();
			List<double> list2 = new List<double>();
			Pnt3D pnt3D = new Pnt3D();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			CalculatedPoints.Clear();
			int num4 = ControlPoints.Count + Order;
			for (int i = 0; i <= ControlPoints.Count - 1; i++)
			{
				list2.Add(0.0);
			}
			for (int j = 0; j <= num4 - 1; j++)
			{
				list.Add(0);
			}
			int num5 = Convert.ToInt32((double)ControlPoints.Count / dt);
			KnotBSpline(ControlPoints.Count, Order, list);
			double num6 = 0.0;
			double num7 = (double)list[num4 - 1] / (double)(num5 - 1);
			for (int k = 0; k <= num5 - 1; k++)
			{
				pnt3D = new Pnt3D();
				if ((double)list[num4 - 1] - num6 < 5E-06)
				{
					num6 = list[num4 - 1];
				}
				BasisRegionalBSpline(Order, num6, ControlPoints.Count, list, Weigth, list2);
				num = 0.0;
				num2 = 0.0;
				num3 = 0.0;
				for (int l = 0; l <= ControlPoints.Count - 1; l++)
				{
					num += list2[l] * ControlPoints[l].X;
					num2 += list2[l] * ControlPoints[l].Y;
					num3 += list2[l] * ControlPoints[l].Z;
				}
				pnt3D.X = num;
				pnt3D.Y = num2;
				pnt3D.Z = num3;
				CalculatedPoints.Add(pnt3D);
				num6 += num7;
			}
		}
		catch (Exception mSException)
		{
			string text = "dt: " + dt + " - ControlPoints: " + ControlPoints.Count + " - Order: " + Order;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CreatHermiteCubicSplineWithStartEndVector(List<Pnt3D> ControlPoints, double dt, double Multiply, double Offset, Vec3D StartVector, Vec3D EndVector, ref List<Pnt3D> CalculatedPoints)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			double num = 2.0;
			double num2 = -2.0;
			double num3 = 1.0;
			double num4 = 1.0;
			double num5 = -3.0;
			double num6 = 3.0;
			double num7 = -2.0;
			double num8 = -1.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 1.0;
			double num12 = 0.0;
			double num13 = 1.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			double num22 = 0.0;
			double num23 = 0.0;
			double num24 = 0.0;
			double num25 = 0.0;
			double num26 = 0.0;
			double num27 = 0.0;
			double num28 = 0.0;
			double num29 = 0.0;
			double num30 = 0.0;
			double num31 = 0.0;
			double num32 = 0.0;
			double num33 = 0.0;
			double num34 = 0.0;
			double num35 = 0.0;
			double num36 = 0.0;
			double num37 = 0.0;
			int num38 = 0;
			CalculatedPoints.Clear();
			num38 = Convert.ToInt32(1.0 / dt);
			for (int i = 0; i <= ControlPoints.Count - 2; i++)
			{
				if (ControlPoints.Count > 2)
				{
					if (i == 0)
					{
						num34 = AngleOfTwoLines(ControlPoints[i], ControlPoints[i + 1], ControlPoints[i + 1], ControlPoints[i + 2]);
						num36 = (180.0 - num34) / 2.0;
						num34 = PointAngle(ControlPoints[i], ControlPoints[i + 1]);
						num35 = PointAngle(ControlPoints[i + 2], ControlPoints[i + 1]);
						num36 = (num34 + num35) / 2.0;
						num36 = ((!(num35 > num34)) ? (num36 - 90.0) : (num36 + 90.0));
						num36 += Offset;
						num21 = StartVector.X;
						num23 = StartVector.Y;
						num27 = Math.Abs(ControlPoints[i + 1].X - ControlPoints[i].X) * Multiply;
						num28 = Math.Abs(ControlPoints[i + 1].Y - ControlPoints[i].Y) * Multiply;
						num29 = Math.Abs(ControlPoints[i + 1].Z - ControlPoints[i].Z) * Multiply;
						num22 = num27 * Math.Cos(DegreeToRadian(num36));
						num24 = num28 * Math.Sin(DegreeToRadian(num36));
						num26 = num29 * Math.Cos(DegreeToRadian(num36));
					}
					if ((i > 0) & (i < ControlPoints.Count - 2))
					{
						num34 = AngleOfTwoLines(ControlPoints[i], ControlPoints[i + 1], ControlPoints[i + 1], ControlPoints[i + 2]);
						num36 = (180.0 - num34) / 2.0;
						num34 = PointAngle(ControlPoints[i], ControlPoints[i + 1]);
						num35 = PointAngle(ControlPoints[i + 2], ControlPoints[i + 1]);
						num36 = (num34 + num35) / 2.0;
						num36 = ((!(num35 > num34)) ? (num36 - 90.0) : (num36 + 90.0));
						num36 += Offset;
						num27 = Math.Abs(ControlPoints[i + 1].X - ControlPoints[i].X) * Multiply;
						num28 = Math.Abs(ControlPoints[i + 1].Y - ControlPoints[i].Y) * Multiply;
						num29 = Math.Abs(ControlPoints[i + 1].Z - ControlPoints[i].Z) * Multiply;
						num22 = num27 * Math.Cos(DegreeToRadian(num36));
						num24 = num28 * Math.Sin(DegreeToRadian(num36));
						num26 = num29 * Math.Cos(DegreeToRadian(num36));
					}
					if (i == ControlPoints.Count - 2)
					{
						num22 = EndVector.X;
						num24 = EndVector.Y;
						num26 = EndVector.Z;
					}
				}
				else
				{
					num21 = StartVector.X;
					num23 = StartVector.Y;
					num25 = StartVector.Z;
					num22 = EndVector.X;
					num24 = EndVector.Y;
					num26 = EndVector.Z;
				}
				for (int j = 0; j <= num38; j++)
				{
					pnt3D = new Pnt3D();
					num37 = (double)j * dt;
					num17 = ControlPoints[i].X;
					num18 = ControlPoints[i + 1].X;
					num19 = num21;
					num20 = num22;
					num30 = (Math.Pow(num37, 3.0) * num + Math.Pow(num37, 2.0) * num5 + num37 * num9 + num13) * num17;
					num31 = (Math.Pow(num37, 3.0) * num2 + Math.Pow(num37, 2.0) * num6 + num37 * num10 + num14) * num18;
					num32 = (Math.Pow(num37, 3.0) * num3 + Math.Pow(num37, 2.0) * num7 + num37 * num11 + num15) * num19;
					num33 = (Math.Pow(num37, 3.0) * num4 + Math.Pow(num37, 2.0) * num8 + num37 * num12 + num16) * num20;
					pnt3D.X = num30 + num31 + num32 + num33;
					num17 = ControlPoints[i].Y;
					num18 = ControlPoints[i + 1].Y;
					num19 = num23;
					num20 = num24;
					num30 = (Math.Pow(num37, 3.0) * num + Math.Pow(num37, 2.0) * num5 + num37 * num9 + num13) * num17;
					num31 = (Math.Pow(num37, 3.0) * num2 + Math.Pow(num37, 2.0) * num6 + num37 * num10 + num14) * num18;
					num32 = (Math.Pow(num37, 3.0) * num3 + Math.Pow(num37, 2.0) * num7 + num37 * num11 + num15) * num19;
					num33 = (Math.Pow(num37, 3.0) * num4 + Math.Pow(num37, 2.0) * num8 + num37 * num12 + num16) * num20;
					pnt3D.Y = num30 + num31 + num32 + num33;
					num17 = ControlPoints[i].Z;
					num18 = ControlPoints[i + 1].Z;
					num19 = num25;
					num20 = num26;
					num30 = (Math.Pow(num37, 3.0) * num + Math.Pow(num37, 2.0) * num5 + num37 * num9 + num13) * num17;
					num31 = (Math.Pow(num37, 3.0) * num2 + Math.Pow(num37, 2.0) * num6 + num37 * num10 + num14) * num18;
					num32 = (Math.Pow(num37, 3.0) * num3 + Math.Pow(num37, 2.0) * num7 + num37 * num11 + num15) * num19;
					num33 = (Math.Pow(num37, 3.0) * num4 + Math.Pow(num37, 2.0) * num8 + num37 * num12 + num16) * num20;
					pnt3D.Z = num30 + num31 + num32 + num33;
					CalculatedPoints.Add(pnt3D);
				}
				num21 = num22;
				num23 = num24;
				num25 = num26;
			}
		}
		catch (Exception mSException)
		{
			string text = "dt: " + dt + " - ControlPoints: " + ControlPoints.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CreatBezeirCurve(List<Pnt3D> ControlPoints, double dt, ref List<Pnt3D> CalculatedPoints)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			int num = 0;
			int num2 = 0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			CalculatedPoints.Clear();
			if (dt <= 0.0)
			{
				dt = 0.1;
			}
			dt /= (double)ControlPoints.Count;
			num = Convert.ToInt32(1.0 / dt);
			num2 = ControlPoints.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				pnt3D = new Pnt3D();
				num6 = (double)i * dt;
				num3 = 0.0;
				num4 = 0.0;
				num5 = 0.0;
				for (int j = 0; j <= ControlPoints.Count - 1; j++)
				{
					num7 = BezeirBlend(num2, j, num6);
					num3 += ControlPoints[j].X * BezeirBlend(num2, j, num6);
					num4 += ControlPoints[j].Y * BezeirBlend(num2, j, num6);
					num5 += ControlPoints[j].Z * BezeirBlend(num2, j, num6);
				}
				pnt3D.X = num3;
				pnt3D.Y = num4;
				pnt3D.Z = num5;
				CalculatedPoints.Add(pnt3D);
			}
		}
		catch (Exception mSException)
		{
			string text = "dt: " + dt + " - ControlPoints: " + ControlPoints.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CreatSplineCubicUniform(List<Pnt3D> ControlPoints, double dt, ref List<Pnt3D> CalculatedPoints)
	{
		try
		{
			if (dt <= 0.0)
			{
				dt = 0.1;
			}
			CalculatedPoints.Clear();
			double[] array = new double[ControlPoints.Count];
			double[] array2 = new double[ControlPoints.Count];
			double[] array3 = new double[ControlPoints.Count];
			int nOutputPoints = Convert.ToInt32(1.0 / dt * (double)ControlPoints.Count);
			for (int i = 0; i <= ControlPoints.Count - 1; i++)
			{
				array[i] = ControlPoints[i].X;
				array2[i] = ControlPoints[i].Y;
				array3[i] = ControlPoints[i].Z;
			}
			CubicSpline.FitGeometric(array, array2, array3, nOutputPoints, out var xs, out var ys, out var zs);
			for (int j = 0; j <= xs.Length - 1; j++)
			{
				CalculatedPoints.Add(new Pnt3D(xs[j], ys[j], zs[j]));
			}
		}
		catch (Exception mSException)
		{
			string text = "dt: " + dt + " - ControlPoints: " + ControlPoints.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	private static double BezeirBlend(int n, int i, double t)
	{
		try
		{
			double num = 0.0;
			double num2 = Math.Pow(t, i);
			double num3 = Math.Pow(1.0 - t, n - i);
			return Factorial(n) / (Factorial(i) * Factorial(n - i)) * Math.Pow(t, i) * Math.Pow(1.0 - t, n - i);
		}
		catch (Exception mSException)
		{
			string text = "n: " + n + " - i: " + i + " - t: " + t;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return 0.0;
		}
	}

	private static void KnotBSpline(int PointNumber, int Order, List<int> KnotVector)
	{
		try
		{
			int num = PointNumber + Order;
			int num2 = PointNumber + 1;
			KnotVector.Clear();
			KnotVector.Add(0);
			for (int i = 1; i <= num - 1; i++)
			{
				if (i > Order - 1 && i < num2)
				{
					KnotVector.Add(KnotVector[i - 1] + 1);
				}
				else
				{
					KnotVector.Add(KnotVector[i - 1]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "PointNumber: " + PointNumber + " - Order: " + Order + " - KnotVector: " + KnotVector.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	private static void BasisRegionalBSpline(int Order, double Parameter, int PointNumber, List<int> KnotVector, List<double> Weigth, List<double> BasisFunctions)
	{
		try
		{
			List<double> list = new List<double>();
			int num = PointNumber + Order;
			for (int i = 0; i <= num - 2; i++)
			{
				if (Parameter >= (double)KnotVector[i] && Parameter < (double)KnotVector[i + 1])
				{
					list.Add(1.0);
				}
				else
				{
					list.Add(0.0);
				}
			}
			for (int j = 2; j <= Order; j++)
			{
				for (int i = 0; i <= num - j - 1; i++)
				{
					double num2 = ((list[i] == 0.0) ? 0.0 : ((Parameter - (double)KnotVector[i]) * list[i] / (double)(KnotVector[i + j - 1] - KnotVector[i])));
					double num3 = ((list[i + 1] == 0.0) ? 0.0 : (((double)KnotVector[i + j] - Parameter) * list[i + 1] / (double)(KnotVector[i + j] - KnotVector[i + 1])));
					list[i] = num2 + num3;
				}
			}
			if (Parameter == (double)KnotVector[num - 1])
			{
				list[PointNumber - 1] = 1.0;
			}
			double num4 = 0.0;
			for (int i = 0; i <= PointNumber - 1; i++)
			{
				num4 += list[i] * Weigth[i];
			}
			for (int i = 0; i <= PointNumber - 1; i++)
			{
				if (num4 != 0.0)
				{
					BasisFunctions[i] = list[i] * Weigth[i] / num4;
				}
				else
				{
					BasisFunctions[i] = 0.0;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Order: " + Order + " - Parameter: " + Parameter + " - PointNumber: " + PointNumber;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	private static double Factorial(int Value)
	{
		try
		{
			int num = 1;
			for (int i = 1; i <= Value; i++)
			{
				num *= i;
			}
			return num;
		}
		catch (Exception mSException)
		{
			string text = "Value: " + Value;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return 0.0;
		}
	}

	private static Pnt3D MiddlePointOfTwoPoint(Pnt3D Value1, Pnt3D Value2)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			pnt3D.X = (Value1.X + Value2.X) / 2.0;
			pnt3D.Y = (Value1.Y + Value2.Y) / 2.0;
			pnt3D.Z = (Value1.Z + Value2.Z) / 2.0;
			return pnt3D;
		}
		catch (Exception mSException)
		{
			string text = "Value1: " + Value1.ToString() + " - Value2: " + Value2.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new Pnt3D();
		}
	}

	public static double PointAngle(Pnt3D PntEnd, Pnt3D PntCenter)
	{
		double XY = 0.0;
		double XZ = 0.0;
		double YZ = 0.0;
		return PointAngle(PntEnd, PntCenter, ref XY, ref XZ, ref YZ);
	}

	public static double PointAngle(Pnt3D PntEnd, Pnt3D PntCenter, ref double XY, ref double XZ, ref double YZ)
	{
		double num = RadianToDegree(Math.Atan(DeltaY(PntEnd.Y, PntCenter.Y) / DeltaX(PntEnd.X, PntCenter.X)));
		if (PntEnd.X == PntCenter.X)
		{
			num = 90.0;
		}
		if (PntEnd.Y > PntCenter.Y && num < 0.0)
		{
			num = 180.0 + num;
		}
		if (PntEnd.Y < PntCenter.Y)
		{
			num = ((!(num < 0.0)) ? (180.0 + num) : (360.0 + num));
		}
		if ((PntCenter.Y == PntEnd.Y) & (PntCenter.X > PntEnd.X))
		{
			num = 180.0;
		}
		if ((PntCenter.X == PntEnd.X) & (PntCenter.Y == PntEnd.Y))
		{
			num = -1.0;
		}
		XY = num;
		num = RadianToDegree(Math.Atan(DeltaZ(PntEnd.Z, PntCenter.Z) / DeltaX(PntEnd.X, PntCenter.X)));
		if (PntEnd.X == PntCenter.X)
		{
			num = 90.0;
		}
		if (PntEnd.Z > PntCenter.Z && num < 0.0)
		{
			num = 180.0 + num;
		}
		if (PntEnd.Z < PntCenter.Z)
		{
			num = ((!(num < 0.0)) ? (180.0 + num) : (360.0 + num));
		}
		if ((PntCenter.Z == PntEnd.Z) & (PntCenter.X > PntEnd.X))
		{
			num = 180.0;
		}
		if ((PntCenter.X == PntEnd.X) & (PntCenter.Z == PntEnd.Z))
		{
			num = -1.0;
		}
		XZ = num;
		num = RadianToDegree(Math.Atan(DeltaZ(PntEnd.Z, PntCenter.Z) / DeltaY(PntEnd.Y, PntCenter.Y)));
		if (PntEnd.Y == PntCenter.Y)
		{
			num = 90.0;
		}
		if (PntEnd.Z > PntCenter.Z && num < 0.0)
		{
			num = 180.0 + num;
		}
		if (PntEnd.Z < PntCenter.Z)
		{
			num = ((!(num < 0.0)) ? (180.0 + num) : (360.0 + num));
		}
		if ((PntCenter.Z == PntEnd.Z) & (PntCenter.Y > PntEnd.Y))
		{
			num = 180.0;
		}
		if ((PntCenter.Y == PntEnd.Y) & (PntCenter.Z == PntEnd.Z))
		{
			num = -1.0;
		}
		YZ = num;
		return XY;
	}

	public static float PointAngle(Pnt3D PntEnd, Pnt3D PntCenter, ref float XY, ref float XZ, ref float YZ)
	{
		float num = Convert.ToSingle(RadianToDegree(Math.Atan(DeltaY(PntEnd.Y, PntCenter.Y) / DeltaX(PntEnd.X, PntCenter.X))));
		if (PntEnd.X == PntCenter.X)
		{
			num = 90f;
		}
		if (PntEnd.Y > PntCenter.Y && num < 0f)
		{
			num = 180f + num;
		}
		if (PntEnd.Y < PntCenter.Y)
		{
			num = ((!(num < 0f)) ? (180f + num) : (360f + num));
		}
		if ((PntCenter.Y == PntEnd.Y) & (PntCenter.X > PntEnd.X))
		{
			num = 180f;
		}
		if ((PntCenter.X == PntEnd.X) & (PntCenter.Y == PntEnd.Y))
		{
			num = -1f;
		}
		XY = num;
		num = Convert.ToSingle(RadianToDegree(Math.Atan(DeltaZ(PntEnd.Z, PntCenter.Z) / DeltaX(PntEnd.X, PntCenter.X))));
		if (PntEnd.X == PntCenter.X)
		{
			num = 90f;
		}
		if (PntEnd.Z > PntCenter.Z && num < 0f)
		{
			num = 180f + num;
		}
		if (PntEnd.Z < PntCenter.Z)
		{
			num = ((!(num < 0f)) ? (180f + num) : (360f + num));
		}
		if ((PntCenter.Z == PntEnd.Z) & (PntCenter.X > PntEnd.X))
		{
			num = 180f;
		}
		if ((PntCenter.X == PntEnd.X) & (PntCenter.Z == PntEnd.Z))
		{
			num = -1f;
		}
		XZ = num;
		num = Convert.ToSingle(RadianToDegree(Math.Atan(DeltaZ(PntEnd.Z, PntCenter.Z) / DeltaY(PntEnd.Y, PntCenter.Y))));
		if (PntEnd.Y == PntCenter.Y)
		{
			num = 90f;
		}
		if (PntEnd.Z > PntCenter.Z && num < 0f)
		{
			num = 180f + num;
		}
		if (PntEnd.Z < PntCenter.Z)
		{
			num = ((!(num < 0f)) ? (180f + num) : (360f + num));
		}
		if ((PntCenter.Z == PntEnd.Z) & (PntCenter.Y > PntEnd.Y))
		{
			num = 180f;
		}
		if ((PntCenter.Y == PntEnd.Y) & (PntCenter.Z == PntEnd.Z))
		{
			num = -1f;
		}
		YZ = num;
		return XY;
	}

	public static double PointAngle(double PointX, double PointY, double CenterX, double CenterY)
	{
		Pnt3D pnt3D = new Pnt3D();
		Pnt3D pnt3D2 = new Pnt3D();
		pnt3D2.X = CenterX;
		pnt3D2.Y = CenterY;
		pnt3D2.Z = 0.0;
		pnt3D.X = PointX;
		pnt3D.Y = PointY;
		pnt3D.Z = 0.0;
		return PointAngle(pnt3D, pnt3D2);
	}

	public static double RadianToDegree(double Radian)
	{
		double num = 0.0;
		return Radian * 180.0 / Math.PI;
	}

	public static double DeltaX(double X1, double X2)
	{
		return X2 - X1;
	}

	public static double DeltaX(Pnt2D Pnt1, Pnt2D Pnt2)
	{
		return Pnt2.X - Pnt1.X;
	}

	public static double DeltaX(Pnt3D Pnt1, Pnt3D Pnt2)
	{
		return Pnt2.X - Pnt1.X;
	}

	public static double DeltaY(double Y1, double Y2)
	{
		return Y2 - Y1;
	}

	public static double DeltaY(Pnt2D Pnt1, Pnt2D Pnt2)
	{
		return Pnt2.Y - Pnt1.Y;
	}

	public static double DeltaY(Pnt3D Pnt1, Pnt3D Pnt2)
	{
		return Pnt2.Y - Pnt1.Y;
	}

	public static double DeltaZ(double Z1, double Z2)
	{
		return Z2 - Z1;
	}

	private static double AngleOfTwoLines(Pnt3D FirstLineStart, Pnt3D FirstLineEnd, Pnt3D SecondLineStart, Pnt3D SecondLineEnd)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		if (EQ(FirstLineStart.X, SecondLineStart.X) & EQ(FirstLineStart.Y, SecondLineStart.Y))
		{
			num = PointAngle(FirstLineEnd.X, FirstLineEnd.Y, FirstLineStart.X, FirstLineStart.Y);
			num2 = PointAngle(SecondLineEnd.X, SecondLineEnd.Y, SecondLineStart.X, SecondLineStart.Y);
		}
		if (EQ(FirstLineStart.X, SecondLineEnd.X) & EQ(FirstLineStart.Y, SecondLineEnd.Y))
		{
			num = PointAngle(FirstLineEnd.X, FirstLineEnd.Y, FirstLineStart.X, FirstLineStart.Y);
			num2 = PointAngle(SecondLineStart.X, SecondLineStart.Y, SecondLineEnd.X, SecondLineEnd.Y);
		}
		if (EQ(FirstLineEnd.X, SecondLineEnd.X) & EQ(FirstLineEnd.Y, SecondLineEnd.Y))
		{
			num = PointAngle(FirstLineStart.X, FirstLineStart.Y, FirstLineEnd.X, FirstLineEnd.Y);
			num2 = PointAngle(SecondLineStart.X, SecondLineStart.Y, FirstLineEnd.X, FirstLineEnd.Y);
		}
		if (EQ(FirstLineEnd.X, SecondLineStart.X) & EQ(FirstLineEnd.Y, SecondLineStart.Y))
		{
			num = PointAngle(FirstLineStart.X, FirstLineStart.Y, FirstLineEnd.X, FirstLineEnd.Y);
			num2 = PointAngle(SecondLineEnd.X, SecondLineEnd.Y, SecondLineStart.X, SecondLineStart.Y);
		}
		if (num < num2)
		{
			num3 = num2 - num;
			if (num3 > 180.0)
			{
				num3 = 360.0 + num - num2;
			}
		}
		if (num2 < num)
		{
			num3 = num - num2;
			if (num3 > 180.0)
			{
				num3 = 360.0 + num2 - num;
			}
		}
		return num3;
	}

	public static string ColorToString(Color clr, ColorConvertType Type)
	{
		try
		{
			if (Type == ColorConvertType.Html)
			{
				return ColorTranslator.ToHtml(clr);
			}
			return clr.ToString();
		}
		catch (Exception)
		{
			return "Black";
		}
	}

	public static Color StringToColor(string Code, ColorConvertType Type)
	{
		Color color = default(Color);
		color = Color.Black;
		try
		{
			string[] array = null;
			array = Code.Split(',');
			if (array.Length >= 4)
			{
				array[0] = array[0].Replace("[", "");
				array[3] = array[3].Replace("]", "");
				int alpha = Convert.ToInt32(array[0].Substring(array[0].IndexOf('=') + 1));
				int red = Convert.ToInt32(array[1].Substring(array[1].IndexOf('=') + 1));
				int green = Convert.ToInt32(array[2].Substring(array[2].IndexOf('=') + 1));
				int blue = Convert.ToInt32(array[3].Substring(array[3].IndexOf('=') + 1));
				Color color2 = default(Color);
				return Color.FromArgb(alpha, red, green, blue);
			}
			if (Type == ColorConvertType.Html)
			{
				return ColorTranslator.FromHtml(Code);
			}
			Code = Code.Replace("Color", "");
			Code = Code.Replace("[", "");
			Code = Code.Replace("]", "");
			Code = Code.Trim();
			return ColorTranslator.FromHtml(Code);
		}
		catch (Exception)
		{
			return Color.Black;
		}
	}

	public static string FontToString(Font fnt)
	{
		try
		{
			FontConverter fontConverter = new FontConverter();
			return fontConverter.ConvertToString(fnt);
		}
		catch (Exception)
		{
			Font value = new Font("Arial", 10f);
			FontConverter fontConverter2 = new FontConverter();
			return fontConverter2.ConvertToString(value);
		}
	}

	public static DateTime StringToDateTime(string Code)
	{
		try
		{
			return DateTime.Parse(Code);
		}
		catch (Exception)
		{
			return DateTime.Now;
		}
	}

	public static string StringToSting(string Code)
	{
		try
		{
			if (Code != null)
			{
				return Code;
			}
			return "";
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static Size StringToSize(string Code)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			Size result = default(Size);
			if (array != null && array.Length >= 2)
			{
				result.Width = int.Parse(array[0]);
				result.Height = int.Parse(array[1]);
			}
			return result;
		}
		catch (Exception)
		{
			return default(Size);
		}
	}

	public static SizeF StringToSizeF(string Code)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			SizeF result = default(SizeF);
			if (array != null && array.Length >= 2)
			{
				result.Width = float.Parse(array[0]);
				result.Height = float.Parse(array[1]);
			}
			return result;
		}
		catch (Exception)
		{
			return default(SizeF);
		}
	}

	public static Point StringToPoint(string Code)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			Point result = default(Point);
			if (array != null && array.Length >= 2)
			{
				result.X = int.Parse(array[0]);
				result.Y = int.Parse(array[1]);
			}
			return result;
		}
		catch (Exception)
		{
			return default(Point);
		}
	}

	public static PointF StringToPointF(string Code)
	{
		try
		{
			string[] array = null;
			array = Code.Split(';');
			PointF result = default(PointF);
			if (array != null && array.Length >= 2)
			{
				result.X = float.Parse(array[0]);
				result.Y = float.Parse(array[1]);
			}
			return result;
		}
		catch (Exception)
		{
			return default(PointF);
		}
	}

	public static Font StringToFont(string Code)
	{
		Font result = new Font("Arial", 10f);
		try
		{
			FontConverter fontConverter = new FontConverter();
			result = fontConverter.ConvertFromString(Code) as Font;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, ArrayList RefList, ref List<List<string>> CalcList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			CalcList = new List<List<string>>();
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = ((string)RefList[i]).Trim();
				}
				if (((string)RefList[i]).Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					if (AddStartEndKey)
					{
						list.Add(EndKey);
					}
					CalcList.Add(list);
					list = new List<string>();
					flag = false;
				}
				if (flag)
				{
					list.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					flag = true;
					if (AddStartEndKey)
					{
						list.Add(StartKey);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "StartKey : " + StartKey + " - EndKey : " + EndKey;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, ArrayList RefList, ref List<List<string>> CalcList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			CalcList = new List<List<string>>();
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = ((string)RefList[i]).Trim();
				}
				if (((string)RefList[i]).Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					CalcList.Add(list);
					list = new List<string>();
					flag = false;
				}
				if (flag)
				{
					list.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, ArrayList RefList, ref List<string> CalcList)
	{
		try
		{
			CalcList = new List<string>();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					if (AddStartEndKey)
					{
						CalcList.Add(EndKey);
					}
					flag = false;
					break;
				}
				if (flag)
				{
					CalcList.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					if (AddStartEndKey)
					{
						CalcList.Add(StartKey);
					}
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, ArrayList RefList, ref ArrayList CalcList)
	{
		try
		{
			CalcList = new ArrayList();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					if (AddStartEndKey)
					{
						CalcList.Add(EndKey);
					}
					flag = false;
					break;
				}
				if (flag)
				{
					CalcList.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					if (AddStartEndKey)
					{
						CalcList.Add(StartKey);
					}
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, List<string> RefList, ref ArrayList CalcList)
	{
		try
		{
			CalcList = new ArrayList();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					if (AddStartEndKey)
					{
						CalcList.Add(EndKey);
					}
					flag = false;
					break;
				}
				if (flag)
				{
					CalcList.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					if (AddStartEndKey)
					{
						CalcList.Add(StartKey);
					}
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, ArrayList RefList, ref List<string> CalcList)
	{
		try
		{
			CalcList = new List<string>();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					flag = false;
					break;
				}
				if (flag)
				{
					CalcList.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, ArrayList RefList, ref ArrayList CalcList)
	{
		try
		{
			CalcList = new ArrayList();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					flag = false;
					break;
				}
				if (flag)
				{
					CalcList.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, List<string> RefList, ref List<string> CalcList)
	{
		try
		{
			CalcList = new List<string>();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					flag = false;
					break;
				}
				if (flag)
				{
					CalcList.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, List<string> RefList, ref List<string> CalcList)
	{
		try
		{
			CalcList = new List<string>();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					if (AddStartEndKey)
					{
						CalcList.Add(EndKey);
					}
					flag = false;
					break;
				}
				if (flag)
				{
					CalcList.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					if (AddStartEndKey)
					{
						CalcList.Add(StartKey);
					}
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, List<string> RefList, ref ArrayList CalcList)
	{
		try
		{
			CalcList = new ArrayList();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					flag = false;
					break;
				}
				if (flag)
				{
					CalcList.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, List<string> RefList, ref List<List<string>> CalcList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			CalcList = new List<List<string>>();
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].Trim();
				}
				if (RefList[i].Length >= 2 && RefList[i].Trim() == EndKey && flag)
				{
					CalcList.Add(list);
					list = new List<string>();
					flag = false;
				}
				if (flag)
				{
					list.Add(RefList[i]);
				}
				if (RefList[i].Trim() == StartKey)
				{
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, List<string> RefList, ref List<List<string>> CalcList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			CalcList = new List<List<string>>();
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].Trim();
				}
				if (RefList[i].Length >= 2 && RefList[i].Trim() == EndKey && flag)
				{
					if (AddStartEndKey)
					{
						list.Add(EndKey);
					}
					CalcList.Add(list);
					list = new List<string>();
					flag = false;
				}
				if (flag)
				{
					list.Add(RefList[i]);
				}
				if (RefList[i].Trim() == StartKey)
				{
					flag = true;
					if (AddStartEndKey)
					{
						list.Add(StartKey);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "StartKey : " + StartKey + " - EndKey : " + EndKey;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void OpenFromFile(string FileName, ref List<string> StringList)
	{
		try
		{
			string text = "";
			StringList = new List<string>();
			TextReader textReader = File.OpenText(FileName);
			while ((text = textReader.ReadLine()) != null)
			{
				StringList.Add(text);
			}
			textReader.Close();
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, FileName);
		}
	}
}
