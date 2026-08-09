using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buCore;

public class buNumeric
{
	public buNumeric()
	{
		if (!buVector.smethod_0("buNumeric"))
		{
			throw new RegisterException("buNumeric");
		}
	}

	public static void CheckDuplicatedPointsWithPrevious(ref List<double> Points, double CompLevel)
	{
		try
		{
			List<double> list = new List<double>();
			if (Points.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= Points.Count - 1; i++)
			{
				list.Add(Points[i]);
			}
			Points.Clear();
			Points.Add(list[0]);
			for (int j = 1; j <= list.Count - 1; j++)
			{
				if (!buCompare.EQ(Points[Points.Count - 1], list[j], CompLevel))
				{
					Points.Add(list[j]);
				}
			}
			if (Points.Count > 0 && !buCompare.EQ(Points[Points.Count - 1], list[list.Count - 1], CompLevel))
			{
				Points.RemoveAt(Points.Count - 1);
				Points.Add(list[list.Count - 1]);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CheckDuplicatedPointsWithPrevious(ref List<int> Points)
	{
		try
		{
			List<int> list = new List<int>();
			if (Points.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= Points.Count - 1; i++)
			{
				list.Add(Points[i]);
			}
			Points.Clear();
			Points.Add(list[0]);
			for (int j = 1; j <= list.Count - 1; j++)
			{
				if (!buCompare.EQ(Points[Points.Count - 1], list[j]))
				{
					Points.Add(list[j]);
				}
			}
			if (Points.Count > 0 && !buCompare.EQ(Points[Points.Count - 1], list[list.Count - 1]))
			{
				Points.RemoveAt(Points.Count - 1);
				Points.Add(list[list.Count - 1]);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static bool IsNumeric(string Value)
	{
		try
		{
			if (Value != null)
			{
				double result = 0.0;
				bool result2 = double.TryParse(Value, out result);
				if (!((Value == "Infinity") | (Value == "-Infinity") | (Value == "NaN")))
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

	public static double RoundToLower(double Value)
	{
		return Math.Floor(Value);
	}

	public static double RoundToUpper(double Value)
	{
		return Math.Ceiling(Value);
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

	public static void GetValueListFromMinMaxByCount(double FirstValue, double LastValue, int Count, ref List<double> ValueList)
	{
		double num = LastValue - FirstValue;
		double num2 = num / ((double)Count - 1.0);
		for (double num3 = 0.0; num3 <= (double)Count - 2.0; num3 += 1.0)
		{
			ValueList.Add(FirstValue + num2 * num3);
		}
		ValueList.Add(LastValue);
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

	public static double ValueFromMinMaxValues(double MinValue, double MaxValue, double Value, double MultiplyValue, MinMaxValuesType Type)
	{
		try
		{
			if (!(MinValue >= MaxValue))
			{
				double result = 0.0;
				if (Type == MinMaxValuesType.MinIsBigValue)
				{
					if (Value >= MaxValue)
					{
						return 0.0;
					}
					if (Value <= MinValue)
					{
						return MultiplyValue;
					}
					result = MultiplyValue * ((MaxValue - Value) / (MaxValue - MinValue));
				}
				if (Type == MinMaxValuesType.MaxIsBigValue)
				{
					if (Value >= MaxValue)
					{
						return MultiplyValue;
					}
					if (Value <= MinValue)
					{
						return 0.0;
					}
					result = MultiplyValue * ((Value - MinValue) / (MaxValue - MinValue));
				}
				return result;
			}
			return 0.0;
		}
		catch (Exception mSException)
		{
			string text = "MinValue: " + MinValue + " - MaxValue: " + MaxValue + " - Value: " + Value + " - MultiplyValue: " + MultiplyValue;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return 0.0;
		}
	}

	public static bool IsValueInsideMinMaxValues(double Value, double MinValue, double MaxValue)
	{
		if (!(Value > MaxValue))
		{
			if (!(Value < MinValue))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static bool IsValueInsideList(List<int> CheckList, int RefValue)
	{
		try
		{
			for (int i = 0; i <= CheckList.Count - 1; i++)
			{
				if (RefValue == CheckList[i])
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception mSException)
		{
			string text = "CheckList: " + CheckList.Count + " - RefValue: " + RefValue;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public static bool IsValueInsideList(List<double> CheckList, double RefValue)
	{
		try
		{
			for (int i = 0; i <= CheckList.Count - 1; i++)
			{
				if (RefValue == CheckList[i])
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception mSException)
		{
			string text = "CheckList: " + CheckList.Count + " - RefValue: " + RefValue;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public static bool IsValueInsideList(List<float> CheckList, float RefValue)
	{
		try
		{
			for (int i = 0; i <= CheckList.Count - 1; i++)
			{
				if (RefValue == CheckList[i])
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception mSException)
		{
			string text = "CheckList: " + CheckList.Count + " - RefValue: " + RefValue;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public static bool IsValueInsideList(List<Pnt3D> CheckList, Pnt3D RefValue)
	{
		try
		{
			for (int i = 0; i <= CheckList.Count - 1; i++)
			{
				if (buCompare.EQ(RefValue, CheckList[i]))
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception mSException)
		{
			string text = "CheckList: " + CheckList.Count + " - RefValue: " + RefValue.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public static double ReadNumericalValueOfString(string CheckChar, string AllLine)
	{
		int num = -1;
		for (int i = 0; i <= AllLine.Length - 1; i++)
		{
			if (num < 0 || IsCharBelongToNumerical(AllLine.Substring(i, 1)))
			{
				if (AllLine.Substring(i, 1) == CheckChar)
				{
					num = i;
				}
				continue;
			}
			return Convert.ToDouble(AllLine.Substring(num + 1, i - num));
		}
		return 0.0;
	}

	public static double GetParameterNumericValue(string FullLine, string ParameterName, string EqualChar, ref double ReadValue)
	{
		try
		{
			string ReadValue2 = "";
			GetParameterValue(FullLine, ParameterName, EqualChar, ref ReadValue2);
			if (ReadValue2.Trim().Length <= 0)
			{
				ReadValue = 0.0;
				return 0.0;
			}
			if (!IsNumeric(ReadValue2))
			{
				ReadValue = 0.0;
				return 0.0;
			}
			ReadValue = Convert.ToDouble(ReadValue2);
			return ReadValue;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			ReadValue = 0.0;
			return 0.0;
		}
	}

	public static string GetParameterValue(string FullLine, string ParameterName, string EqualChar, ref string ReadValue)
	{
		try
		{
			string[] array = null;
			ReadValue = "";
			array = FullLine.Split(new string[1] { EqualChar }, StringSplitOptions.None);
			if (array == null)
			{
				ReadValue = "";
				return ReadValue;
			}
			string text = array[0].Trim();
			if (text.IndexOf(ParameterName) < 0)
			{
				ReadValue = "";
				return ReadValue;
			}
			if (array.Length != 2)
			{
				ReadValue = "";
				return ReadValue;
			}
			ReadValue = array[1].Trim();
			return ReadValue;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			ReadValue = "";
			return ReadValue;
		}
	}

	public static void CheckValueMinMax(ref double Value, double MinVal, double MaxVal)
	{
		if (Value < MinVal)
		{
			Value = MinVal;
		}
		if (Value > MaxVal)
		{
			Value = MaxVal;
		}
	}

	public static void CheckValueMinMax(ref int Value, int MinVal, int MaxVal)
	{
		if (Value < MinVal)
		{
			Value = MinVal;
		}
		if (Value > MaxVal)
		{
			Value = MaxVal;
		}
	}

	public static void CheckValueMinMax(ref float Value, float MinVal, float MaxVal)
	{
		if (Value < MinVal)
		{
			Value = MinVal;
		}
		if (Value > MaxVal)
		{
			Value = MaxVal;
		}
	}

	public static bool ReadNumericalValueOfString(string CheckChar, string AllLine, ref double Value)
	{
		int num = -1;
		for (int i = 0; i <= AllLine.Length - 1; i++)
		{
			if (num < 0 || IsCharBelongToNumerical(AllLine.Substring(i, 1)))
			{
				if (AllLine.Substring(i, 1) == CheckChar)
				{
					num = i;
				}
				continue;
			}
			Value = Convert.ToDouble(AllLine.Substring(num + 1, i - num));
			return true;
		}
		if (num >= 0)
		{
			string text = AllLine.Substring(num + 1, AllLine.Length - 1 - num);
			if (IsNumeric(text))
			{
				Value = double.Parse(text);
				return true;
			}
		}
		Value = 0.0;
		return false;
	}

	public static bool ReadCodeFromStringLineWithRefChar(string Line, string RefChar, ref double Value)
	{
		int num = 0;
		bool flag = false;
		string text = "";
		if (Line.Length > 1)
		{
			num = Line.IndexOf(RefChar);
			if (num >= 0)
			{
				for (int i = num + 1; i <= Line.Length - 1; i++)
				{
					string value = Line.Substring(i, 1);
					flag = false;
					if (IsNumeric(value))
					{
						flag = true;
					}
					if (!flag)
					{
						text = Line.Substring(num + 1, i - (num + 1));
						if (!IsNumeric(text))
						{
							Value = -999999999.0;
							return false;
						}
						Value = double.Parse(text);
						return true;
					}
				}
				text = Line.Substring(num + 1, Line.Length - num - 1);
				if (IsNumeric(text))
				{
					Value = double.Parse(text);
					return true;
				}
			}
			return false;
		}
		return false;
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
}
