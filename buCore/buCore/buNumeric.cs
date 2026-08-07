// Decompiled with JetBrains decompiler
// Type: buCore.buNumeric
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buCore;

public class buNumeric
{
  public buNumeric()
  {
    if (!buVector.smethod_0(nameof (buNumeric)))
      throw new RegisterException(nameof (buNumeric));
  }

  public static void CheckDuplicatedPointsWithPrevious(ref List<double> Points, double CompLevel)
  {
    try
    {
      List<double> doubleList = new List<double>();
      if (Points.Count <= 0)
        return;
      for (int index = 0; index <= Points.Count - 1; ++index)
        doubleList.Add(Points[index]);
      Points.Clear();
      Points.Add(doubleList[0]);
      for (int index = 1; index <= doubleList.Count - 1; ++index)
      {
        if (!buCompare.EQ(Points[Points.Count - 1], doubleList[index], CompLevel))
          Points.Add(doubleList[index]);
      }
      if (Points.Count <= 0 || buCompare.EQ(Points[Points.Count - 1], doubleList[doubleList.Count - 1], CompLevel))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add(doubleList[doubleList.Count - 1]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CheckDuplicatedPointsWithPrevious(ref List<int> Points)
  {
    try
    {
      List<int> intList = new List<int>();
      if (Points.Count <= 0)
        return;
      for (int index = 0; index <= Points.Count - 1; ++index)
        intList.Add(Points[index]);
      Points.Clear();
      Points.Add(intList[0]);
      for (int index = 1; index <= intList.Count - 1; ++index)
      {
        if (!buCompare.EQ((double) Points[Points.Count - 1], (double) intList[index]))
          Points.Add(intList[index]);
      }
      if (Points.Count <= 0 || buCompare.EQ((double) Points[Points.Count - 1], (double) intList[intList.Count - 1]))
        return;
      Points.RemoveAt(Points.Count - 1);
      Points.Add(intList[intList.Count - 1]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static bool IsNumeric(string Value)
  {
    try
    {
      if (Value == null)
        return false;
      double result = 0.0;
      bool flag = double.TryParse(Value, out result);
      return !(Value == "Infinity" | Value == "-Infinity" | Value == "NaN") && flag;
    }
    catch (Exception ex)
    {
      string str = "Value: " + Value.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static double RoundToLower(double Value) => Math.Floor(Value);

  public static double RoundToUpper(double Value) => Math.Ceiling(Value);

  public static void EquationLineer(
    double X1,
    double X2,
    double Y1,
    double Y2,
    double Y3,
    ref double X3)
  {
    try
    {
      if (Math.Abs(X1 - X2) < 1E-10)
      {
        X3 = X1;
      }
      else
      {
        double num = (Y2 - Y1) / (X2 - X1);
        X3 = (Y3 - Y1) / num + X1;
      }
    }
    catch (Exception ex)
    {
      string str = $"X1: {X1.ToString()} - X2: {X2.ToString()} - Y1: {Y1.ToString()} - Y2: {Y2.ToString()} - Y3: {Y3.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void GetValueListFromMinMaxByCount(
    double FirstValue,
    double LastValue,
    int Count,
    ref List<double> ValueList)
  {
    double num1 = (LastValue - FirstValue) / ((double) Count - 1.0);
    for (double num2 = 0.0; num2 <= (double) Count - 2.0; ++num2)
      ValueList.Add(FirstValue + num1 * num2);
    ValueList.Add(LastValue);
  }

  public static void GetMinXYZFromPointList(
    List<Pnt3D> Points,
    ref double MinX,
    ref double MinY,
    ref double MinZ)
  {
    try
    {
      if (Points.Count > 0)
      {
        MinX = Points[0].X;
        MinY = Points[0].Y;
        MinZ = Points[0].Z;
        for (int index = 1; index <= Points.Count - 1; ++index)
        {
          if (Points[index].X < MinX)
            MinX = Points[index].X;
          if (Points[index].Y < MinY)
            MinY = Points[index].Y;
          if (Points[index].Z < MinZ)
            MinZ = Points[index].Z;
        }
      }
      else
      {
        MinX = 0.0;
        MinY = 0.0;
        MinZ = 0.0;
      }
    }
    catch (Exception ex)
    {
      string str = "Points: " + Points.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void GetMaxXYZFromPointList(
    List<Pnt3D> Points,
    ref double MaxX,
    ref double MaxY,
    ref double MaxZ)
  {
    try
    {
      if (Points.Count > 0)
      {
        MaxX = Points[0].X;
        MaxY = Points[0].Y;
        MaxZ = Points[0].Z;
        for (int index = 1; index <= Points.Count - 1; ++index)
        {
          if (Points[index].X > MaxX)
            MaxX = Points[index].X;
          if (Points[index].Y > MaxY)
            MaxY = Points[index].Y;
          if (Points[index].Z > MaxZ)
            MaxZ = Points[index].Z;
        }
      }
      else
      {
        MaxX = 0.0;
        MaxY = 0.0;
        MaxZ = 0.0;
      }
    }
    catch (Exception ex)
    {
      string str = "Points: " + Points.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static double ValueFromMinMaxValues(
    double MinValue,
    double MaxValue,
    double Value,
    double MultiplyValue,
    MinMaxValuesType Type)
  {
    try
    {
      if (MinValue >= MaxValue)
        return 0.0;
      double num = 0.0;
      if (Type == MinMaxValuesType.MinIsBigValue)
      {
        if (Value >= MaxValue)
          return 0.0;
        if (Value <= MinValue)
          return MultiplyValue;
        num = MultiplyValue * ((MaxValue - Value) / (MaxValue - MinValue));
      }
      if (Type == MinMaxValuesType.MaxIsBigValue)
      {
        if (Value >= MaxValue)
          return MultiplyValue;
        if (Value <= MinValue)
          return 0.0;
        num = MultiplyValue * ((Value - MinValue) / (MaxValue - MinValue));
      }
      return num;
    }
    catch (Exception ex)
    {
      string str = $"MinValue: {MinValue.ToString()} - MaxValue: {MaxValue.ToString()} - Value: {Value.ToString()} - MultiplyValue: {MultiplyValue.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return 0.0;
    }
  }

  public static bool IsValueInsideMinMaxValues(double Value, double MinValue, double MaxValue)
  {
    return Value <= MaxValue && Value >= MinValue;
  }

  public static bool IsValueInsideList(List<int> CheckList, int RefValue)
  {
    try
    {
      for (int index = 0; index <= CheckList.Count - 1; ++index)
      {
        if (RefValue == CheckList[index])
          return true;
      }
      return false;
    }
    catch (Exception ex)
    {
      string str = $"CheckList: {CheckList.Count.ToString()} - RefValue: {RefValue.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static bool IsValueInsideList(List<double> CheckList, double RefValue)
  {
    try
    {
      for (int index = 0; index <= CheckList.Count - 1; ++index)
      {
        if (RefValue == CheckList[index])
          return true;
      }
      return false;
    }
    catch (Exception ex)
    {
      string str = $"CheckList: {CheckList.Count.ToString()} - RefValue: {RefValue.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static bool IsValueInsideList(List<float> CheckList, float RefValue)
  {
    try
    {
      for (int index = 0; index <= CheckList.Count - 1; ++index)
      {
        if ((double) RefValue == (double) CheckList[index])
          return true;
      }
      return false;
    }
    catch (Exception ex)
    {
      string str = $"CheckList: {CheckList.Count.ToString()} - RefValue: {RefValue.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static bool IsValueInsideList(List<Pnt3D> CheckList, Pnt3D RefValue)
  {
    try
    {
      for (int index = 0; index <= CheckList.Count - 1; ++index)
      {
        if (buCompare.EQ(RefValue, CheckList[index]))
          return true;
      }
      return false;
    }
    catch (Exception ex)
    {
      string str = $"CheckList: {CheckList.Count.ToString()} - RefValue: {RefValue.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static double ReadNumericalValueOfString(string CheckChar, string AllLine)
  {
    int num1 = -1;
    double num2;
    for (int startIndex = 0; startIndex <= AllLine.Length - 1; ++startIndex)
    {
      if (num1 < 0 || buNumeric.IsCharBelongToNumerical(AllLine.Substring(startIndex, 1)))
      {
        if (AllLine.Substring(startIndex, 1) == CheckChar)
          num1 = startIndex;
      }
      else
      {
        num2 = Convert.ToDouble(AllLine.Substring(num1 + 1, startIndex - num1));
        goto label_8;
      }
    }
    num2 = 0.0;
label_8:
    return num2;
  }

  public static double GetParameterNumericValue(
    string FullLine,
    string ParameterName,
    string EqualChar,
    ref double ReadValue)
  {
    try
    {
      string ReadValue1 = "";
      buNumeric.GetParameterValue(FullLine, ParameterName, EqualChar, ref ReadValue1);
      if (ReadValue1.Trim().Length > 0)
      {
        if (buNumeric.IsNumeric(ReadValue1))
        {
          ReadValue = Convert.ToDouble(ReadValue1);
          return ReadValue;
        }
        ReadValue = 0.0;
        return 0.0;
      }
      ReadValue = 0.0;
      return 0.0;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      ReadValue = 0.0;
      return 0.0;
    }
  }

  public static string GetParameterValue(
    string FullLine,
    string ParameterName,
    string EqualChar,
    ref string ReadValue)
  {
    try
    {
      ReadValue = "";
      string[] strArray = FullLine.Split(new string[1]
      {
        EqualChar
      }, StringSplitOptions.None);
      if (strArray != null)
      {
        if (strArray[0].Trim().IndexOf(ParameterName) >= 0)
        {
          if (strArray.Length == 2)
          {
            ReadValue = strArray[1].Trim();
            return ReadValue;
          }
          ReadValue = "";
          return ReadValue;
        }
        ReadValue = "";
        return ReadValue;
      }
      ReadValue = "";
      return ReadValue;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      ReadValue = "";
      return ReadValue;
    }
  }

  public static void CheckValueMinMax(ref double Value, double MinVal, double MaxVal)
  {
    if (Value < MinVal)
      Value = MinVal;
    if (Value <= MaxVal)
      return;
    Value = MaxVal;
  }

  public static void CheckValueMinMax(ref int Value, int MinVal, int MaxVal)
  {
    if (Value < MinVal)
      Value = MinVal;
    if (Value <= MaxVal)
      return;
    Value = MaxVal;
  }

  public static void CheckValueMinMax(ref float Value, float MinVal, float MaxVal)
  {
    if ((double) Value < (double) MinVal)
      Value = MinVal;
    if ((double) Value <= (double) MaxVal)
      return;
    Value = MaxVal;
  }

  public static bool ReadNumericalValueOfString(string CheckChar, string AllLine, ref double Value)
  {
    int num = -1;
    bool flag;
    for (int startIndex = 0; startIndex <= AllLine.Length - 1; ++startIndex)
    {
      if (num < 0 || buNumeric.IsCharBelongToNumerical(AllLine.Substring(startIndex, 1)))
      {
        if (AllLine.Substring(startIndex, 1) == CheckChar)
          num = startIndex;
      }
      else
      {
        Value = Convert.ToDouble(AllLine.Substring(num + 1, startIndex - num));
        flag = true;
        goto label_11;
      }
    }
    if (num >= 0)
    {
      string s = AllLine.Substring(num + 1, AllLine.Length - 1 - num);
      if (buNumeric.IsNumeric(s))
      {
        Value = double.Parse(s);
        flag = true;
        goto label_11;
      }
    }
    Value = 0.0;
    flag = false;
label_11:
    return flag;
  }

  public static bool ReadCodeFromStringLineWithRefChar(
    string Line,
    string RefChar,
    ref double Value)
  {
    bool flag1;
    if (Line.Length <= 1)
    {
      flag1 = false;
    }
    else
    {
      int num = Line.IndexOf(RefChar);
      if (num >= 0)
      {
        for (int startIndex = num + 1; startIndex <= Line.Length - 1; ++startIndex)
        {
          string str = Line.Substring(startIndex, 1);
          bool flag2 = false;
          if (buNumeric.IsNumeric(str))
            flag2 = true;
          if (!flag2)
          {
            string s = Line.Substring(num + 1, startIndex - (num + 1));
            if (buNumeric.IsNumeric(s))
            {
              Value = double.Parse(s);
              flag1 = true;
              goto label_15;
            }
            Value = -999999999.0;
            flag1 = false;
            goto label_15;
          }
        }
        string s1 = Line.Substring(num + 1, Line.Length - num - 1);
        if (buNumeric.IsNumeric(s1))
        {
          Value = double.Parse(s1);
          flag1 = true;
          goto label_15;
        }
      }
      flag1 = false;
    }
label_15:
    return flag1;
  }

  public static bool IsCharBelongToNumerical(string CheckChar)
  {
    bool numerical;
    switch (CheckChar)
    {
      case "1":
        numerical = true;
        break;
      case "2":
        numerical = true;
        break;
      case "3":
        numerical = true;
        break;
      case "4":
        numerical = true;
        break;
      case "5":
        numerical = true;
        break;
      case "6":
        numerical = true;
        break;
      case "7":
        numerical = true;
        break;
      case "8":
        numerical = true;
        break;
      case "9":
        numerical = true;
        break;
      case "0":
        numerical = true;
        break;
      case "-":
        numerical = true;
        break;
      case "+":
        numerical = true;
        break;
      case ",":
        numerical = true;
        break;
      case ".":
        numerical = true;
        break;
      default:
        numerical = false;
        break;
    }
    return numerical;
  }

  public static void DevideMinMaxValueByNumber(
    double StartValue,
    double EndValue,
    int DevideCount,
    ref List<double> Values)
  {
    Values.Clear();
    double num1 = (EndValue - StartValue) / (double) (DevideCount - 1);
    double num2 = StartValue;
    Values.Add(StartValue);
    for (int index = 0; index <= DevideCount - 3; ++index)
    {
      num2 += num1;
      Values.Add(num2);
    }
    Values.Add(EndValue);
  }
}
