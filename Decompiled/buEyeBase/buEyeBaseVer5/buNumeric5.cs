using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buCore;
using buEyeBaseVer5.Apps.Robotic;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class buNumeric5
{
	public buNumeric5()
	{
		if (!buVector5.smethod_0("buNumeric5"))
		{
			throw new RegisterException("buNumeric5");
		}
	}

	public static void ExchangeTwoVaues(ref int Val1, ref int Val2)
	{
		int num = Val1;
		Val1 = Val2;
		Val2 = num;
	}

	public static void ExchangeTwoVaues(ref double Val1, ref double Val2)
	{
		double num = Val1;
		Val1 = Val2;
		Val2 = num;
	}

	public static void ExchangeTwoVaues(ref bool Val1, ref bool Val2)
	{
		bool flag = Val1;
		Val1 = Val2;
		Val2 = flag;
	}

	public static bool isNumberAvailableList(int Val, List<int> List)
	{
		if (List.Count != 0)
		{
			if (!List.Contains(Val))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool isNumberAvailableList(double Val, List<double> List)
	{
		if (List.Count != 0)
		{
			if (!List.Contains(Val))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static double GetValueFromTwoValueFromPercentage(double FirstVal, double SecondVal, double Percentage)
	{
		double num = 0.0;
		if (!(Percentage <= 0.0))
		{
			if (!(Percentage >= 0.0))
			{
				double num2 = SecondVal - FirstVal;
				return FirstVal + Percentage / 100.0 * num2;
			}
			return SecondVal;
		}
		return FirstVal;
	}

	public static bool IsValueInsideMinMaxList(double Value, List<MinMax> ListMinMax, bool AllIn = false)
	{
		if (!AllIn)
		{
			for (int i = 0; i <= ListMinMax.Count - 1; i++)
			{
				if (IsValueInsideMinMaxValues(Value, ListMinMax[i].Min, ListMinMax[i].Max))
				{
					return true;
				}
			}
			return false;
		}
		for (int j = 0; j <= ListMinMax.Count - 1; j++)
		{
			if (!IsValueInsideMinMaxValues(Value, ListMinMax[j].Min, ListMinMax[j].Max))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsValueInsideMinMaxValues(double Value, double MinValue, double MaxValue, double Resolution = 0.01)
	{
		double num = MinValue;
		double num2 = MaxValue;
		if (num > num2)
		{
			num = MaxValue;
			num2 = MinValue;
		}
		if (!buCompare5.GT(Value, num2, Resolution))
		{
			if (!buCompare5.LT(Value, num, Resolution))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static void AddValueToList(int Val, ref List<int> List, bool CheckIfExist = true)
	{
		if (CheckIfExist)
		{
			if (List.Count != 0)
			{
				if (!List.Contains(Val))
				{
					List.Add(Val);
				}
			}
			else
			{
				List.Add(Val);
			}
		}
		else
		{
			List.Add(Val);
		}
	}

	public static void AddValueToList(double Val, ref List<double> List, bool CheckIfExist = true)
	{
		if (CheckIfExist)
		{
			if (List.Count != 0)
			{
				if (!List.Contains(Val))
				{
					List.Add(Val);
				}
			}
			else
			{
				List.Add(Val);
			}
		}
		else
		{
			List.Add(Val);
		}
	}

	public static void AddValueToList(float Val, ref List<float> List, bool CheckIfExist = true)
	{
		if (CheckIfExist)
		{
			if (List.Count != 0)
			{
				if (!List.Contains(Val))
				{
					List.Add(Val);
				}
			}
			else
			{
				List.Add(Val);
			}
		}
		else
		{
			List.Add(Val);
		}
	}

	public static bool IsNumeric(string Value)
	{
		try
		{
			double result = 0.0;
			bool result2 = double.TryParse(Value, out result);
			if (!((Value == "Infinity") | (Value == "-Infinity") | (Value == "NaN")))
			{
				return result2;
			}
			return false;
		}
		catch (Exception mSException)
		{
			string text = "Value: " + Value.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public static bool IsNumeric(object Value)
	{
		try
		{
			if (Value != null)
			{
				double result = 0.0;
				bool result2 = double.TryParse(Value.ToString(), out result);
				if (!((Value.ToString() == "Infinity") | (Value.ToString() == "-Infinity") | (Value.ToString() == "NaN")))
				{
					return result2;
				}
				return false;
			}
			return false;
		}
		catch (Exception mSException)
		{
			string text = "Value: " + Value.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public static bool IsNumericDigit(string Value)
	{
		try
		{
			if (!((Value == "0") | (Value == "1") | (Value == "2") | (Value == "3") | (Value == "4") | (Value == "5") | (Value == "6") | (Value == "7") | (Value == "8") | (Value == "9")))
			{
				return false;
			}
			return true;
		}
		catch (Exception mSException)
		{
			string text = "Value: " + Value.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public static void StepCalculation(double StartValue, double EndValue, double Step, ref List<double> CalcValues)
	{
		double value = EndValue - StartValue;
		double num = 1.0;
		if (EndValue < StartValue)
		{
			num = -1.0;
		}
		int num2 = Convert.ToInt32(buNumeric.RoundToLower(Math.Abs(value) / Math.Abs(Step)));
		if (Step != 0.0)
		{
			double value2 = 0.0;
			for (int i = 1; i <= num2; i++)
			{
				double num3 = StartValue + num * Math.Abs(Step) * (double)i;
				CalcValues.Add(Math.Round(num3, 5));
				value2 = num3;
			}
			if (CalcValues.Count > 0 && !buCompare.EQ(value2, EndValue, 0.001))
			{
				CalcValues.Add(EndValue);
			}
		}
	}

	public static bool IsCharBelongToNumerical(string CheckChar)
	{
		return CheckChar switch
		{
			"1" => true, 
			"2" => true, 
			"3" => true, 
			"4" => true, 
			"5" => true, 
			"6" => true, 
			"7" => true, 
			"8" => true, 
			"9" => true, 
			"0" => true, 
			"-" => true, 
			"+" => true, 
			"," => true, 
			"." => true, 
			_ => false, 
		};
	}

	public static void GetMinXYZFromPointList(List<Pnt3D> Points, ref double MinX, ref double MinY, ref double MinZ)
	{
		try
		{
			if (Points.Count <= 0)
			{
				MinX = 0.0;
				MinY = 0.0;
				MinZ = 0.0;
				return;
			}
			MinX = Points[0].X;
			MinY = Points[0].Y;
			MinZ = Points[0].Z;
			for (int i = 1; i <= Points.Count - 1; i++)
			{
				if (Points[i].X < MinX)
				{
					MinX = Points[i].X;
				}
				if (Points[i].Y < MinY)
				{
					MinY = Points[i].Y;
				}
				if (Points[i].Z < MinZ)
				{
					MinZ = Points[i].Z;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Points: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void GetMaxXYZFromPointList(List<Pnt3D> Points, ref double MaxX, ref double MaxY, ref double MaxZ)
	{
		try
		{
			if (Points.Count <= 0)
			{
				MaxX = 0.0;
				MaxY = 0.0;
				MaxZ = 0.0;
				return;
			}
			MaxX = Points[0].X;
			MaxY = Points[0].Y;
			MaxZ = Points[0].Z;
			for (int i = 1; i <= Points.Count - 1; i++)
			{
				if (Points[i].X > MaxX)
				{
					MaxX = Points[i].X;
				}
				if (Points[i].Y > MaxY)
				{
					MaxY = Points[i].Y;
				}
				if (Points[i].Z > MaxZ)
				{
					MaxZ = Points[i].Z;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Points: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void GetMinXYZFromPointList(List<Point3D> Points, ref double MinX, ref double MinY, ref double MinZ)
	{
		try
		{
			if (Points.Count <= 0)
			{
				MinX = 0.0;
				MinY = 0.0;
				MinZ = 0.0;
				return;
			}
			MinX = Points[0].X;
			MinY = Points[0].Y;
			MinZ = Points[0].Z;
			for (int i = 1; i <= Points.Count - 1; i++)
			{
				if (Points[i].X < MinX)
				{
					MinX = Points[i].X;
				}
				if (Points[i].Y < MinY)
				{
					MinY = Points[i].Y;
				}
				if (Points[i].Z < MinZ)
				{
					MinZ = Points[i].Z;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Points: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void GetMaxXYZFromPointList(List<Point3D> Points, ref double MaxX, ref double MaxY, ref double MaxZ)
	{
		try
		{
			if (Points.Count <= 0)
			{
				MaxX = 0.0;
				MaxY = 0.0;
				MaxZ = 0.0;
				return;
			}
			MaxX = Points[0].X;
			MaxY = Points[0].Y;
			MaxZ = Points[0].Z;
			for (int i = 1; i <= Points.Count - 1; i++)
			{
				if (Points[i].X > MaxX)
				{
					MaxX = Points[i].X;
				}
				if (Points[i].Y > MaxY)
				{
					MaxY = Points[i].Y;
				}
				if (Points[i].Z > MaxZ)
				{
					MaxZ = Points[i].Z;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Points: " + Points.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static double RoundOneDigit(double Value)
	{
		return Math.Round(Value, 1);
	}

	public static double RoundTwoDigit(double Value)
	{
		return Math.Round(Value, 2);
	}

	public static double RoundThreeDigit(double Value)
	{
		return Math.Round(Value, 3);
	}

	public static double RoundFourDigit(double Value)
	{
		return Math.Round(Value, 4);
	}

	public static double RoundFiveDigit(double Value)
	{
		return Math.Round(Value, 5);
	}

	public static double RoundEightDigit(double Value)
	{
		return Math.Round(Value, 8);
	}

	public static double RoundToLower(double Value)
	{
		return Math.Floor(Value);
	}

	public static double RoundToUpper(double Value)
	{
		return Math.Ceiling(Value);
	}

	public static void DevideMinMaxValueByNumber(double StartValue, double EndValue, int DevideCount, ref List<double> Values)
	{
		Values.Clear();
		double num = (EndValue - StartValue) / (double)(DevideCount - 1);
		double num2 = StartValue;
		Values.Add(StartValue);
		for (int i = 0; i <= DevideCount - 3; i++)
		{
			num2 += num;
			Values.Add(num2);
		}
		Values.Add(EndValue);
	}

	public static void DevideMinMaxValueByNumber(Point3D StartValue, Point3D EndValue, int DevideCount, ref List<Point3D> Values)
	{
		Values.Clear();
		double num = (EndValue.X - StartValue.X) / (double)(DevideCount - 1);
		double num2 = (EndValue.Y - StartValue.Y) / (double)(DevideCount - 1);
		double num3 = (EndValue.Z - StartValue.Z) / (double)(DevideCount - 1);
		Point3D point3D = new Point3D(StartValue.X, StartValue.Y, StartValue.Z);
		Values.Add(new Point3D(StartValue.X, StartValue.Y, StartValue.Z));
		for (int i = 0; i <= DevideCount - 3; i++)
		{
			point3D.X += num;
			point3D.Y += num2;
			point3D.Z += num3;
			Values.Add(new Point3D(point3D.X, point3D.Y, point3D.Z));
		}
		Values.Add(new Point3D(EndValue.X, EndValue.Y, EndValue.Z));
	}

	public static void DevideMinMaxValueByNumber(Vector3D StartValue, Vector3D EndValue, int DevideCount, ref List<Vector3D> Values)
	{
		Values.Clear();
		double num = (EndValue.X - StartValue.X) / (double)(DevideCount - 1);
		double num2 = (EndValue.Y - StartValue.Y) / (double)(DevideCount - 1);
		double num3 = (EndValue.Z - StartValue.Z) / (double)(DevideCount - 1);
		Vector3D vector3D = new Vector3D(StartValue.X, StartValue.Y, StartValue.Z);
		Values.Add(new Vector3D(StartValue.X, StartValue.Y, StartValue.Z));
		for (int i = 0; i <= DevideCount - 3; i++)
		{
			vector3D.X += num;
			vector3D.Y += num2;
			vector3D.Z += num3;
			Values.Add(new Vector3D(vector3D.X, vector3D.Y, vector3D.Z));
		}
		Values.Add(new Vector3D(EndValue.X, EndValue.Y, EndValue.Z));
	}

	public static void DevideMinMaxValueByNumber(EulerAngles StartValue, EulerAngles EndValue, int DevideCount, ref List<EulerAngles> Values)
	{
		Values.Clear();
		double num = (EndValue.Roll - StartValue.Roll) / (double)(DevideCount - 1);
		double num2 = (EndValue.Pitch - StartValue.Pitch) / (double)(DevideCount - 1);
		double num3 = (EndValue.Yaw - StartValue.Yaw) / (double)(DevideCount - 1);
		EulerAngles eulerAngles = new EulerAngles(StartValue.Roll, StartValue.Pitch, StartValue.Yaw);
		Values.Add(new EulerAngles(StartValue.Roll, StartValue.Pitch, StartValue.Yaw));
		for (int i = 0; i <= DevideCount - 3; i++)
		{
			eulerAngles.Roll += num;
			eulerAngles.Pitch += num2;
			eulerAngles.Yaw += num3;
			Values.Add(new EulerAngles(eulerAngles.Roll, eulerAngles.Pitch, eulerAngles.Yaw));
		}
		Values.Add(new EulerAngles(EndValue.Roll, EndValue.Pitch, EndValue.Yaw));
	}

	public static void DevideMinMaxValueByNumber(PlaneAngles StartValue, PlaneAngles EndValue, int DevideCount, ref List<PlaneAngles> Values)
	{
		Values.Clear();
		double num = (EndValue.A - StartValue.A) / (double)(DevideCount - 1);
		double num2 = (EndValue.B - StartValue.B) / (double)(DevideCount - 1);
		double num3 = (EndValue.C - StartValue.C) / (double)(DevideCount - 1);
		PlaneAngles planeAngles = new PlaneAngles(StartValue.A, StartValue.B, StartValue.C);
		Values.Add(new PlaneAngles(StartValue.A, StartValue.B, StartValue.C));
		for (int i = 0; i <= DevideCount - 3; i++)
		{
			planeAngles.A += num;
			planeAngles.B += num2;
			planeAngles.C += num3;
			Values.Add(new PlaneAngles(planeAngles.A, planeAngles.B, planeAngles.C));
		}
		Values.Add(new PlaneAngles(EndValue.A, EndValue.B, EndValue.C));
	}

	public static void EquationLineer(double X1, double X2, double Y1, double Y2, double Y3, ref double X3)
	{
		try
		{
			double num = 1.0;
			if (!(Math.Abs(X1 - X2) < 1E-10))
			{
				num = (Y2 - Y1) / (X2 - X1);
				X3 = (Y3 - Y1) / num + X1;
			}
			else
			{
				X3 = X1;
			}
		}
		catch (Exception mSException)
		{
			string text = "X1: " + X1 + " - X2: " + X2 + " - Y1: " + Y1 + " - Y2: " + Y2 + " - Y3: " + Y3;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void SortList(SortDirectionType Direction, ref List<double> RefList)
	{
		try
		{
			bool flag = false;
			if (RefList.Count <= 1)
			{
				return;
			}
			RefList.Sort();
			if (Direction == SortDirectionType.Lower)
			{
				for (int i = 1; i <= RefList.Count - 1; i++)
				{
					if (RefList[i - 1] > RefList[i])
					{
						i = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			if (Direction != SortDirectionType.Bigger)
			{
				return;
			}
			for (int j = 1; j <= RefList.Count - 1; j++)
			{
				if (RefList[j - 1] < RefList[j])
				{
					j = RefList.Count;
					flag = true;
				}
			}
			if (flag)
			{
				RefList.Reverse();
			}
		}
		catch (Exception mSException)
		{
			string text = "Direction: " + Direction;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void SortList(SortDirectionType Direction, ref List<int> RefList)
	{
		try
		{
			bool flag = false;
			if (RefList.Count <= 1)
			{
				return;
			}
			RefList.Sort();
			if (Direction == SortDirectionType.Lower)
			{
				for (int i = 1; i <= RefList.Count - 1; i++)
				{
					if (RefList[i - 1] > RefList[i])
					{
						i = RefList.Count;
						flag = true;
					}
				}
				if (flag)
				{
					RefList.Reverse();
				}
			}
			if (Direction != SortDirectionType.Bigger)
			{
				return;
			}
			for (int j = 1; j <= RefList.Count - 1; j++)
			{
				if (RefList[j - 1] < RefList[j])
				{
					j = RefList.Count;
					flag = true;
				}
			}
			if (flag)
			{
				RefList.Reverse();
			}
		}
		catch (Exception mSException)
		{
			string text = "Direction: " + Direction;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static bool isValueAvailableInList(List<double> refValues, double Value)
	{
		if (refValues != null)
		{
			if (refValues.Count != 0)
			{
				for (int i = 0; i <= refValues.Count - 1; i++)
				{
					if (refValues[i] == Value)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool isValueAvailableInList(List<int> refValues, int Value)
	{
		if (refValues != null)
		{
			if (refValues.Count != 0)
			{
				for (int i = 0; i <= refValues.Count - 1; i++)
				{
					if (refValues[i] == Value)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool isValueAvailableInList(List<float> refValues, float Value)
	{
		if (refValues != null)
		{
			if (refValues.Count != 0)
			{
				for (int i = 0; i <= refValues.Count - 1; i++)
				{
					if (refValues[i] == Value)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool isValueAvailableInList(List<bool> refValues, bool Value)
	{
		if (refValues != null)
		{
			if (refValues.Count != 0)
			{
				for (int i = 0; i <= refValues.Count - 1; i++)
				{
					if (refValues[i] == Value)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static void Copy(List<double> refValues, ref List<double> copyValues)
	{
		copyValues = new List<double>();
		if (refValues != null)
		{
			for (int i = 0; i <= refValues.Count - 1; i++)
			{
				copyValues.Add(refValues[i]);
			}
		}
	}

	public static void Copy(List<int> refValues, ref List<int> copyValues)
	{
		copyValues = new List<int>();
		if (refValues != null)
		{
			for (int i = 0; i <= refValues.Count - 1; i++)
			{
				copyValues.Add(refValues[i]);
			}
		}
	}

	public static void Copy(List<float> refValues, ref List<float> copyValues)
	{
		copyValues = new List<float>();
		if (refValues != null)
		{
			for (int i = 0; i <= refValues.Count - 1; i++)
			{
				copyValues.Add(refValues[i]);
			}
		}
	}

	public static void Copy(List<bool> refValues, ref List<bool> copyValues)
	{
		copyValues = new List<bool>();
		if (refValues != null)
		{
			for (int i = 0; i <= refValues.Count - 1; i++)
			{
				copyValues.Add(refValues[i]);
			}
		}
	}

	public static void ArrayIndexIncrease(ref int ActualIndex, int MaxValue, int IncreaseStep, int VisibleCount)
	{
		try
		{
			if (ActualIndex + IncreaseStep <= MaxValue)
			{
				ActualIndex += IncreaseStep;
			}
			else
			{
				ActualIndex = MaxValue - VisibleCount;
			}
		}
		catch (Exception mSException)
		{
			string text = "ActualIndex : " + ActualIndex + " - MaxValue: " + MaxValue + " - IncreaseStep: " + IncreaseStep + " - VisibleCount: " + VisibleCount;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ArrayIndexDecrease(ref int ActualIndex, int MinValue, int DecreaseStep, int VisibleCount)
	{
		try
		{
			if (ActualIndex - DecreaseStep >= MinValue)
			{
				ActualIndex -= DecreaseStep;
			}
			else
			{
				ActualIndex = MinValue;
			}
		}
		catch (Exception mSException)
		{
			string text = "ActualIndex : " + ActualIndex + " - MinValue: " + MinValue + " - DecreaseStep: " + DecreaseStep + " - VisibleCount: " + VisibleCount;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CheckDuplicatedWithPrevious(ref List<double> Values, double Resolution = 0.001)
	{
		try
		{
			List<double> copyValues = new List<double>();
			if (Values.Count <= 0)
			{
				return;
			}
			Copy(Values, ref copyValues);
			Values.Clear();
			Values.Add(copyValues[0]);
			for (int i = 1; i <= copyValues.Count - 1; i++)
			{
				if (!buCompare5.EQ(Values[Values.Count - 1], copyValues[i], Resolution))
				{
					Values.Add(copyValues[i]);
				}
			}
			if (Values.Count > 0 && !buCompare5.EQ(Values[Values.Count - 1], copyValues[copyValues.Count - 1], Resolution))
			{
				Values.RemoveAt(Values.Count - 1);
				Values.Add(copyValues[copyValues.Count - 1]);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CheckDuplicatedWithPrevious(ref List<int> Values)
	{
		try
		{
			List<int> copyValues = new List<int>();
			if (Values.Count <= 0)
			{
				return;
			}
			Copy(Values, ref copyValues);
			Values.Clear();
			Values.Add(copyValues[0]);
			for (int i = 1; i <= copyValues.Count - 1; i++)
			{
				if (!buCompare5.EQ(Values[Values.Count - 1], copyValues[i]))
				{
					Values.Add(copyValues[i]);
				}
			}
			if (Values.Count > 0 && !buCompare5.EQ(Values[Values.Count - 1], copyValues[copyValues.Count - 1]))
			{
				Values.RemoveAt(Values.Count - 1);
				Values.Add(copyValues[copyValues.Count - 1]);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CheckDuplicatedWithPrevious(ref List<float> Values)
	{
		try
		{
			List<float> copyValues = new List<float>();
			if (Values.Count <= 0)
			{
				return;
			}
			Copy(Values, ref copyValues);
			Values.Clear();
			Values.Add(copyValues[0]);
			for (int i = 1; i <= copyValues.Count - 1; i++)
			{
				if (!buCompare5.EQ(Values[Values.Count - 1], copyValues[i]))
				{
					Values.Add(copyValues[i]);
				}
			}
			if (Values.Count > 0 && !buCompare5.EQ(Values[Values.Count - 1], copyValues[copyValues.Count - 1]))
			{
				Values.RemoveAt(Values.Count - 1);
				Values.Add(copyValues[copyValues.Count - 1]);
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
