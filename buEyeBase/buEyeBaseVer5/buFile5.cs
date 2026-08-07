// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buFile5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Variables;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class buFile5
{
  public static byte f000905;
  public buControlDisplay ButtonNormal;
  public buControlDisplay ButtonOver;

  public static void GetItemsAccordingToTheLang(
    List<string> RefList,
    int Language,
    ref ArrayList CalcList)
  {
    try
    {
      if (RefList.Count <= 0)
        return;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        string[] strArray1 = RefList[index].Split('|');
        if (strArray1.Length > 1)
        {
          string[] strArray2 = strArray1[1].Split(';');
          if (Language <= strArray2.Length - 1)
            CalcList.Add((object) strArray2[Language].Trim());
        }
        else
        {
          string[] strArray3 = RefList[index].Split(';');
          if (Language <= strArray3.Length - 1)
            CalcList.Add((object) strArray3[Language].Trim());
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (GetItemsAccordingToTheLang), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void GetItemsAccordingToTheLang(
    string RefString,
    int Language,
    ref string CalcStirng)
  {
    try
    {
      string[] strArray1 = RefString.Split('|');
      if (strArray1.Length > 1)
      {
        string[] strArray2 = strArray1[1].Split(';');
        if (Language > strArray2.Length - 1)
          return;
        CalcStirng = strArray2[Language].Trim();
      }
      else
      {
        string[] strArray3 = RefString.Split(';');
        if (Language > strArray3.Length - 1)
          return;
        CalcStirng = strArray3[Language].Trim();
      }
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (GetItemsAccordingToTheLang), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static string FindStringBetweenTwoChar(
    string RefString,
    string FirstStr,
    string SecondStr)
  {
    try
    {
      int num1 = RefString.IndexOf(FirstStr);
      int num2 = RefString.IndexOf(SecondStr);
      if (num1 == num2 || !(num1 >= 0 & num2 >= 0))
        return "";
      return num2 > num1 ? RefString.Substring(num1 + FirstStr.Length, num2 - num1 - FirstStr.Length) : RefString.Substring(num2 + FirstStr.Length, num1 - num2 - FirstStr.Length);
    }
    catch (Exception ex)
    {
      string str = $"RefString : {RefString} - FirstStr : {FirstStr} - SecondStr : {SecondStr}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static bool isCharsInStringList(string refString, List<string> StringList)
  {
    bool flag;
    for (int index = 0; index <= StringList.Count - 1; ++index)
    {
      if (StringList[index] == refString)
      {
        flag = true;
        goto label_6;
      }
    }
    flag = false;
label_6:
    return flag;
  }

  public static List<string> Copy(List<string> refList)
  {
    List<string> stringList = new List<string>();
    if (refList != null)
    {
      for (int index = 0; index <= refList.Count - 1; ++index)
        stringList.Add(refList[index]);
    }
    return stringList;
  }

  public static ArrayList Copy(ArrayList refList)
  {
    ArrayList arrayList = new ArrayList();
    if (refList != null)
    {
      for (int index = 0; index <= refList.Count - 1; ++index)
        arrayList.Add(refList[index]);
    }
    return arrayList;
  }

  public static int TotalLineCountOfString(string refString)
  {
    try
    {
      return refString.Split('\n').Length;
    }
    catch (Exception ex)
    {
      return 0;
    }
  }

  public static void MoveUp(ref List<string> refList, int Index)
  {
    if (!(refList.Count >= 0 & Index > 0 & Index <= refList.Count - 1))
      return;
    string str = refList[Index];
    refList.RemoveAt(Index);
    --Index;
    refList.Insert(Index, str);
  }

  public static void MoveDown(ref List<string> refList, int Index)
  {
    if (!(refList.Count >= 0 & Index <= refList.Count - 2 & Index <= refList.Count - 1))
      return;
    string str = refList[Index];
    refList.RemoveAt(Index);
    ++Index;
    refList.Insert(Index, str);
  }

  public static List<string> ReadXmlItem(
    string StartString,
    string EndString,
    ArrayList SourceList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= SourceList.Count - 1 && !(SourceList[index].ToString() == EndString); ++index)
      {
        if (flag)
          stringList.Add(SourceList[index].ToString());
        if (SourceList[index].ToString() == StartString)
          flag = true;
      }
      return stringList;
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (ReadXmlItem), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new List<string>();
    }
  }

  public static List<string> ReadXmlItem(
    string StartString,
    string EndString,
    List<string> SourceList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= SourceList.Count - 1 && !(SourceList[index].ToString().Trim() == EndString); ++index)
      {
        if (flag)
          stringList.Add(SourceList[index].ToString().Trim());
        SourceList[index].ToString().Trim();
        if (SourceList[index].ToString().Trim() == StartString)
          flag = true;
      }
      return stringList;
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (ReadXmlItem), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
      return new List<string>();
    }
  }

  public static void ReadXmlItem(
    string StartString,
    string EndString,
    ArrayList SourceList,
    ref ArrayList CalcList)
  {
    try
    {
      CalcList = new ArrayList();
      bool flag = false;
      for (int index = 0; index <= SourceList.Count - 1 && !(SourceList[index].ToString().Trim() == EndString); ++index)
      {
        if (flag)
          CalcList.Add((object) SourceList[index].ToString().Trim());
        SourceList[index].ToString().Trim();
        if (SourceList[index].ToString().Trim() == StartString)
          flag = true;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (ReadXmlItem), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void ReadXmlItem(
    string StartString,
    string EndString,
    List<string> SourceList,
    ref List<List<string>> DecodeList)
  {
    try
    {
      bool flag = false;
      List<string> stringList = new List<string>();
      DecodeList = new List<List<string>>();
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        if (SourceList[index].ToString() == EndString)
        {
          DecodeList.Add(stringList);
          flag = false;
          stringList = new List<string>();
        }
        if (flag)
          stringList.Add(SourceList[index].ToString());
        if (SourceList[index].ToString() == StartString)
          flag = true;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (ReadXmlItem), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public abstract void m0004DE();

  public buFile5()
  {
    if (!buVector5.\u0001("buNumeric5"))
      throw new RegisterException("buNumeric5");
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
    return List.Count != 0 && List.Contains(Val);
  }

  public static bool isNumberAvailableList(double Val, List<double> List)
  {
    return List.Count != 0 && List.Contains(Val);
  }

  public static double GetValueFromTwoValueFromPercentage(
    double FirstVal,
    double SecondVal,
    double Percentage)
  {
    double valueFromPercentage;
    if (Percentage <= 0.0)
      valueFromPercentage = FirstVal;
    else if (Percentage >= 0.0)
    {
      valueFromPercentage = SecondVal;
    }
    else
    {
      double num = SecondVal - FirstVal;
      valueFromPercentage = FirstVal + Percentage / 100.0 * num;
    }
    return valueFromPercentage;
  }

  public static bool IsValueInsideMinMaxList(double Value, List<MinMax> ListMinMax, bool AllIn = false)
  {
    bool flag;
    if (AllIn)
    {
      for (int index = 0; index <= ListMinMax.Count - 1; ++index)
      {
        if (!buFile5.IsValueInsideMinMaxValues(Value, ListMinMax[index].Min, ListMinMax[index].Max))
        {
          flag = false;
          goto label_13;
        }
      }
      flag = true;
    }
    else
    {
      for (int index = 0; index <= ListMinMax.Count - 1; ++index)
      {
        if (buFile5.IsValueInsideMinMaxValues(Value, ListMinMax[index].Min, ListMinMax[index].Max))
        {
          flag = true;
          goto label_13;
        }
      }
      flag = false;
    }
label_13:
    return flag;
  }

  public static bool IsValueInsideMinMaxValues(
    double Value,
    double MinValue,
    double MaxValue,
    double Resolution = 0.01)
  {
    double num1 = MinValue;
    double num2 = MaxValue;
    if (num1 > num2)
    {
      num1 = MaxValue;
      num2 = MinValue;
    }
    return !buConversion5.GT(Value, num2, Resolution) && !buConversion5.LT(Value, num1, Resolution);
  }

  public static void AddValueToList(int Val, ref List<int> List, bool CheckIfExist = true)
  {
    if (!CheckIfExist)
      List.Add(Val);
    else if (List.Count == 0)
    {
      List.Add(Val);
    }
    else
    {
      if (List.Contains(Val))
        return;
      List.Add(Val);
    }
  }

  public static void AddValueToList(double Val, ref List<double> List, bool CheckIfExist = true)
  {
    if (!CheckIfExist)
      List.Add(Val);
    else if (List.Count == 0)
    {
      List.Add(Val);
    }
    else
    {
      if (List.Contains(Val))
        return;
      List.Add(Val);
    }
  }

  public static void AddValueToList(float Val, ref List<float> List, bool CheckIfExist = true)
  {
    if (!CheckIfExist)
      List.Add(Val);
    else if (List.Count == 0)
    {
      List.Add(Val);
    }
    else
    {
      if (List.Contains(Val))
        return;
      List.Add(Val);
    }
  }

  public static bool IsNumeric(string Value)
  {
    try
    {
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

  public static bool IsNumeric(object Value)
  {
    try
    {
      if (Value == null)
        return false;
      double result = 0.0;
      bool flag = double.TryParse(Value.ToString(), out result);
      return !(Value.ToString() == "Infinity" | Value.ToString() == "-Infinity" | Value.ToString() == "NaN") && flag;
    }
    catch (Exception ex)
    {
      string str = "Value: " + Value.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static bool IsNumericDigit(string Value)
  {
    try
    {
      return Value == "0" | Value == "1" | Value == "2" | Value == "3" | Value == "4" | Value == "5" | Value == "6" | Value == "7" | Value == "8" | Value == "9";
    }
    catch (Exception ex)
    {
      string str = "Value: " + Value.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static void StepCalculation(
    double StartValue,
    double EndValue,
    double Step,
    ref List<double> CalcValues)
  {
    double num1 = EndValue - StartValue;
    double num2 = 1.0;
    if (EndValue < StartValue)
      num2 = -1.0;
    int int32 = Convert.ToInt32(buNumeric.RoundToLower(Math.Abs(num1) / Math.Abs(Step)));
    double num3 = Step;
    if (num3 == 0.0)
      return;
    double num4 = 0.0;
    for (int index = 1; index <= int32; ++index)
    {
      double num5 = StartValue + num2 * Math.Abs(num3) * (double) index;
      CalcValues.Add(Math.Round(num5, 5));
      num4 = num5;
    }
    if (CalcValues.Count <= 0 || buCompare.EQ(num4, EndValue, 0.001))
      return;
    CalcValues.Add(EndValue);
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

  public static void GetMinXYZFromPointList(
    List<Point3D> Points,
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
    List<Point3D> Points,
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

  public static double RoundOneDigit(double Value) => Math.Round(Value, 1);

  public static double RoundTwoDigit(double Value) => Math.Round(Value, 2);

  public static double RoundThreeDigit(double Value) => Math.Round(Value, 3);

  public static double RoundFourDigit(double Value) => Math.Round(Value, 4);

  public static double RoundFiveDigit(double Value) => Math.Round(Value, 5);

  public static double RoundEightDigit(double Value) => Math.Round(Value, 8);

  public static double RoundToLower(double Value) => Math.Floor(Value);

  public static double RoundToUpper(double Value) => Math.Ceiling(Value);

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

  public static void DevideMinMaxValueByNumber(
    Point3D StartValue,
    Point3D EndValue,
    int DevideCount,
    ref List<Point3D> Values)
  {
    Values.Clear();
    double num1 = (EndValue.X - StartValue.X) / (double) (DevideCount - 1);
    double num2 = (EndValue.Y - StartValue.Y) / (double) (DevideCount - 1);
    double num3 = (EndValue.Z - StartValue.Z) / (double) (DevideCount - 1);
    Point3D point3D = new Point3D(StartValue.X, StartValue.Y, StartValue.Z);
    Values.Add(new Point3D(StartValue.X, StartValue.Y, StartValue.Z));
    for (int index = 0; index <= DevideCount - 3; ++index)
    {
      point3D.X += num1;
      point3D.Y += num2;
      point3D.Z += num3;
      Values.Add(new Point3D(point3D.X, point3D.Y, point3D.Z));
    }
    Values.Add(new Point3D(EndValue.X, EndValue.Y, EndValue.Z));
  }

  public static void DevideMinMaxValueByNumber(
    Vector3D StartValue,
    Vector3D EndValue,
    int DevideCount,
    ref List<Vector3D> Values)
  {
    Values.Clear();
    double num1 = (EndValue.X - StartValue.X) / (double) (DevideCount - 1);
    double num2 = (EndValue.Y - StartValue.Y) / (double) (DevideCount - 1);
    double num3 = (EndValue.Z - StartValue.Z) / (double) (DevideCount - 1);
    Vector3D vector3D = new Vector3D(StartValue.X, StartValue.Y, StartValue.Z);
    Values.Add(new Vector3D(StartValue.X, StartValue.Y, StartValue.Z));
    for (int index = 0; index <= DevideCount - 3; ++index)
    {
      vector3D.X += num1;
      vector3D.Y += num2;
      vector3D.Z += num3;
      Values.Add(new Vector3D(vector3D.X, vector3D.Y, vector3D.Z));
    }
    Values.Add(new Vector3D(EndValue.X, EndValue.Y, EndValue.Z));
  }

  public static void DevideMinMaxValueByNumber(
    EulerAngles StartValue,
    EulerAngles EndValue,
    int DevideCount,
    ref List<EulerAngles> Values)
  {
    Values.Clear();
    double num1 = (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).Roll - ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Roll) / (double) (DevideCount - 1);
    double num2 = (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).Pitch - ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Pitch) / (double) (DevideCount - 1);
    double num3 = (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).Yaw - ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Yaw) / (double) (DevideCount - 1);
    EulerAngles eulerAngles = (EulerAngles) new \u0007.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Roll, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Pitch, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Yaw);
    Values.Add((EulerAngles) new \u0007.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Roll, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Pitch, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).Yaw));
    for (int index = 0; index <= DevideCount - 3; ++index)
    {
      ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Roll = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Roll + num1;
      ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Pitch = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Pitch + num2;
      ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Yaw = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Yaw + num3;
      Values.Add((EulerAngles) new \u0007.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Roll, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Pitch, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) eulerAngles).Yaw));
    }
    Values.Add((EulerAngles) new \u0007.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).Roll, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).Pitch, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).Yaw));
  }

  public static void DevideMinMaxValueByNumber(
    PlaneAngles StartValue,
    PlaneAngles EndValue,
    int DevideCount,
    ref List<PlaneAngles> Values)
  {
    Values.Clear();
    double num1 = (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).A - ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).A) / (double) (DevideCount - 1);
    double num2 = (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).B - ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).B) / (double) (DevideCount - 1);
    double num3 = (((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).C - ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).C) / (double) (DevideCount - 1);
    PlaneAngles planeAngles = (PlaneAngles) new \u0007.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).A, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).B, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).C);
    Values.Add((PlaneAngles) new \u0007.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).A, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).B, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) StartValue).C));
    for (int index = 0; index <= DevideCount - 3; ++index)
    {
      ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).A = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).A + num1;
      ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).B = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).B + num2;
      ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).C = ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).C + num3;
      Values.Add((PlaneAngles) new \u0007.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).A, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).B, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) planeAngles).C));
    }
    Values.Add((PlaneAngles) new \u0007.\u0001(((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).A, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).B, ((\u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D) EndValue).C));
  }

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

  public static void SortList(SortDirectionType Direction, ref List<double> RefList)
  {
    try
    {
      bool flag = false;
      if (RefList.Count <= 1)
        return;
      RefList.Sort();
      if (Direction == SortDirectionType.Lower)
      {
        for (int index = 1; index <= RefList.Count - 1; ++index)
        {
          if (RefList[index - 1] > RefList[index])
          {
            index = RefList.Count;
            flag = true;
          }
        }
        if (flag)
          RefList.Reverse();
      }
      if (Direction != SortDirectionType.Bigger)
        return;
      for (int index = 1; index <= RefList.Count - 1; ++index)
      {
        if (RefList[index - 1] < RefList[index])
        {
          index = RefList.Count;
          flag = true;
        }
      }
      if (!flag)
        return;
      RefList.Reverse();
    }
    catch (Exception ex)
    {
      string str = "Direction: " + Direction.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void SortList(SortDirectionType Direction, ref List<int> RefList)
  {
    try
    {
      bool flag = false;
      if (RefList.Count <= 1)
        return;
      RefList.Sort();
      if (Direction == SortDirectionType.Lower)
      {
        for (int index = 1; index <= RefList.Count - 1; ++index)
        {
          if (RefList[index - 1] > RefList[index])
          {
            index = RefList.Count;
            flag = true;
          }
        }
        if (flag)
          RefList.Reverse();
      }
      if (Direction != SortDirectionType.Bigger)
        return;
      for (int index = 1; index <= RefList.Count - 1; ++index)
      {
        if (RefList[index - 1] < RefList[index])
        {
          index = RefList.Count;
          flag = true;
        }
      }
      if (!flag)
        return;
      RefList.Reverse();
    }
    catch (Exception ex)
    {
      string str = "Direction: " + Direction.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static bool isValueAvailableInList(List<double> refValues, double Value)
  {
    bool flag;
    if (refValues == null)
      flag = false;
    else if (refValues.Count == 0)
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index <= refValues.Count - 1; ++index)
      {
        if (refValues[index] == Value)
        {
          flag = true;
          goto label_10;
        }
      }
      flag = false;
    }
label_10:
    return flag;
  }

  public static bool isValueAvailableInList(List<int> refValues, int Value)
  {
    bool flag;
    if (refValues == null)
      flag = false;
    else if (refValues.Count == 0)
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index <= refValues.Count - 1; ++index)
      {
        if (refValues[index] == Value)
        {
          flag = true;
          goto label_10;
        }
      }
      flag = false;
    }
label_10:
    return flag;
  }

  public static bool isValueAvailableInList(List<float> refValues, float Value)
  {
    bool flag;
    if (refValues == null)
      flag = false;
    else if (refValues.Count == 0)
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index <= refValues.Count - 1; ++index)
      {
        if ((double) refValues[index] == (double) Value)
        {
          flag = true;
          goto label_10;
        }
      }
      flag = false;
    }
label_10:
    return flag;
  }

  public static bool isValueAvailableInList(List<bool> refValues, bool Value)
  {
    bool flag;
    if (refValues == null)
      flag = false;
    else if (refValues.Count == 0)
    {
      flag = false;
    }
    else
    {
      for (int index = 0; index <= refValues.Count - 1; ++index)
      {
        if (refValues[index] == Value)
        {
          flag = true;
          goto label_10;
        }
      }
      flag = false;
    }
label_10:
    return flag;
  }

  public static void Copy(List<double> refValues, ref List<double> copyValues)
  {
    copyValues = new List<double>();
    if (refValues == null)
      return;
    for (int index = 0; index <= refValues.Count - 1; ++index)
      copyValues.Add(refValues[index]);
  }

  public static void Copy(List<int> refValues, ref List<int> copyValues)
  {
    copyValues = new List<int>();
    if (refValues == null)
      return;
    for (int index = 0; index <= refValues.Count - 1; ++index)
      copyValues.Add(refValues[index]);
  }

  public static void Copy(List<float> refValues, ref List<float> copyValues)
  {
    copyValues = new List<float>();
    if (refValues == null)
      return;
    for (int index = 0; index <= refValues.Count - 1; ++index)
      copyValues.Add(refValues[index]);
  }

  public static void Copy(List<bool> refValues, ref List<bool> copyValues)
  {
    copyValues = new List<bool>();
    if (refValues == null)
      return;
    for (int index = 0; index <= refValues.Count - 1; ++index)
      copyValues.Add(refValues[index]);
  }

  public static void ArrayIndexIncrease(
    ref int ActualIndex,
    int MaxValue,
    int IncreaseStep,
    int VisibleCount)
  {
    try
    {
      if (ActualIndex + IncreaseStep > MaxValue)
        ActualIndex = MaxValue - VisibleCount;
      else
        ActualIndex += IncreaseStep;
    }
    catch (Exception ex)
    {
      string str = $"ActualIndex : {ActualIndex.ToString()} - MaxValue: {MaxValue.ToString()} - IncreaseStep: {IncreaseStep.ToString()} - VisibleCount: {VisibleCount.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ArrayIndexDecrease(
    ref int ActualIndex,
    int MinValue,
    int DecreaseStep,
    int VisibleCount)
  {
    try
    {
      if (ActualIndex - DecreaseStep < MinValue)
        ActualIndex = MinValue;
      else
        ActualIndex -= DecreaseStep;
    }
    catch (Exception ex)
    {
      string str = $"ActualIndex : {ActualIndex.ToString()} - MinValue: {MinValue.ToString()} - DecreaseStep: {DecreaseStep.ToString()} - VisibleCount: {VisibleCount.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CheckDuplicatedWithPrevious(ref List<double> Values, double Resolution = 0.001)
  {
    try
    {
      List<double> copyValues = new List<double>();
      if (Values.Count <= 0)
        return;
      buFile5.Copy(Values, ref copyValues);
      Values.Clear();
      Values.Add(copyValues[0]);
      for (int index = 1; index <= copyValues.Count - 1; ++index)
      {
        if (!buConversion5.EQ(Values[Values.Count - 1], copyValues[index], Resolution))
          Values.Add(copyValues[index]);
      }
      if (Values.Count <= 0 || buConversion5.EQ(Values[Values.Count - 1], copyValues[copyValues.Count - 1], Resolution))
        return;
      Values.RemoveAt(Values.Count - 1);
      Values.Add(copyValues[copyValues.Count - 1]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CheckDuplicatedWithPrevious(ref List<int> Values)
  {
    try
    {
      List<int> copyValues = new List<int>();
      if (Values.Count <= 0)
        return;
      buFile5.Copy(Values, ref copyValues);
      Values.Clear();
      Values.Add(copyValues[0]);
      for (int index = 1; index <= copyValues.Count - 1; ++index)
      {
        if (!buConversion5.EQ((double) Values[Values.Count - 1], (double) copyValues[index]))
          Values.Add(copyValues[index]);
      }
      if (Values.Count <= 0 || buConversion5.EQ((double) Values[Values.Count - 1], (double) copyValues[copyValues.Count - 1]))
        return;
      Values.RemoveAt(Values.Count - 1);
      Values.Add(copyValues[copyValues.Count - 1]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CheckDuplicatedWithPrevious(ref List<float> Values)
  {
    try
    {
      List<float> copyValues = new List<float>();
      if (Values.Count <= 0)
        return;
      buFile5.Copy(Values, ref copyValues);
      Values.Clear();
      Values.Add(copyValues[0]);
      for (int index = 1; index <= copyValues.Count - 1; ++index)
      {
        if (!buConversion5.EQ((double) Values[Values.Count - 1], (double) copyValues[index]))
          Values.Add(copyValues[index]);
      }
      if (Values.Count <= 0 || buConversion5.EQ((double) Values[Values.Count - 1], (double) copyValues[copyValues.Count - 1]))
        return;
      Values.RemoveAt(Values.Count - 1);
      Values.Add(copyValues[copyValues.Count - 1]);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public abstract void m000511();

  public buFile5()
  {
    if (!buVector5.\u0001("buImage5"))
      throw new RegisterException("buImage5");
  }

  public static Bitmap CropBitmap(Bitmap bmp, int x, int y, int width, int height)
  {
    Rectangle srcRect = new Rectangle(x, y, width, height);
    Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
    Graphics.FromImage((Image) bitmap).DrawImage((Image) bmp, new Rectangle(0, 0, bitmap.Width, bitmap.Height), srcRect, GraphicsUnit.Pixel);
    return bitmap;
  }

  public static Bitmap CropBitmap(Image bmp, int x, int y, int width, int height)
  {
    Rectangle srcRect = new Rectangle(x, y, width, height);
    Bitmap bitmap = new Bitmap(srcRect.Width, srcRect.Height);
    Graphics.FromImage((Image) bitmap).DrawImage(bmp, new Rectangle(0, 0, bitmap.Width, bitmap.Height), srcRect, GraphicsUnit.Pixel);
    return bitmap;
  }

  public static Color ColorFromBool(bool State, Color TrueColor, Color FalseColor)
  {
    return !State ? FalseColor : TrueColor;
  }

  public static Color InvertColor(Color BaseColor)
  {
    return Color.FromArgb((int) byte.MaxValue - (int) BaseColor.R, (int) byte.MaxValue - (int) BaseColor.G, (int) byte.MaxValue - (int) BaseColor.B);
  }

  public static Color InvertColorNoGray(Color BaseColor)
  {
    byte red = ~BaseColor.R;
    byte green = ~BaseColor.G;
    byte blue = ~BaseColor.B;
    Color color = Color.FromArgb((int) BaseColor.A, (int) red, (int) green, (int) blue);
    if (Math.Abs(Convert.ToInt32(BaseColor.R) - Convert.ToInt32(color.R)) < 2 & Math.Abs(Convert.ToInt32(BaseColor.G) - Convert.ToInt32(color.G)) < 2 & Math.Abs(Convert.ToInt32(BaseColor.B) - Convert.ToInt32(color.B)) < 2)
      color = Color.Black;
    return color;
  }

  public static void GetKnowColorToList(ref List<Color> ColorList)
  {
    ColorList.Clear();
    foreach (string name in Enum.GetNames(typeof (KnownColor)))
    {
      Color color = Color.FromName(name);
      ColorList.Add(color);
    }
  }

  public static string GetColorKnownName(Color clr)
  {
    return !clr.IsKnownColor ? clr.ToString() : clr.ToKnownColor().ToString();
  }

  public static Color ColorToneChange(Color BaseColor, double factor)
  {
    double red = (double) BaseColor.R * factor > (double) byte.MaxValue ? (double) byte.MaxValue : (double) BaseColor.R * factor;
    double green = (double) BaseColor.G * factor > (double) byte.MaxValue ? (double) byte.MaxValue : (double) BaseColor.G * factor;
    double blue = (double) BaseColor.B * factor > (double) byte.MaxValue ? (double) byte.MaxValue : (double) BaseColor.B * factor;
    return Color.FromArgb((int) BaseColor.A, (int) red, (int) green, (int) blue);
  }

  public static void GetImageSizeWithFilename(string FileName, ref int Width, ref int Height)
  {
    Image image = Image.FromFile(FileName);
    Width = image.Width;
    Height = image.Height;
  }

  public static Bitmap ResizeImage(Image image, int width, int height)
  {
    Rectangle destRect = new Rectangle(0, 0, width, height);
    Bitmap bitmap = new Bitmap(width, height);
    bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    using (Graphics graphics = Graphics.FromImage((Image) bitmap))
    {
      graphics.CompositingMode = CompositingMode.SourceCopy;
      graphics.CompositingQuality = CompositingQuality.HighQuality;
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      using (ImageAttributes imageAttr = new ImageAttributes())
      {
        imageAttr.SetWrapMode(WrapMode.TileFlipXY);
        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttr);
      }
    }
    return bitmap;
  }

  public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
  {
    Bitmap bitmap = new Bitmap(width, height);
    using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      graphics.DrawImage((Image) bmp, 0, 0, width, height);
    return bitmap;
  }

  public static Bitmap Rotate(Bitmap OriginalImage, double Angle)
  {
    Bitmap bitmap1 = OriginalImage;
    Angle %= 360.0;
    double num1 = (double) (OriginalImage.Width / 2);
    double num2 = (double) (OriginalImage.Height / 2);
    double pi = Math.PI;
    double num3 = Angle * pi / 180.0;
    Bitmap bitmap2 = new Bitmap(OriginalImage.Width, OriginalImage.Height);
    for (int x = 0; x < bitmap1.Width; ++x)
    {
      for (int y = 0; y < bitmap1.Height; ++y)
      {
        int num4 = (int) (Math.Cos(num3) * ((double) x - num1) - Math.Sin(num3) * ((double) y - num2) + num1);
        int num5 = (int) (Math.Sin(num3) * ((double) x - num1) + Math.Cos(num3) * ((double) y - num2) + num2);
        double num6 = Math.Sqrt((num1 - (double) x) * (num1 - (double) x) + (num2 - (double) y) * (num2 - (double) y));
        int int32_1 = Convert.ToInt32(num1 + Math.Cos(num3) * num6);
        int int32_2 = Convert.ToInt32(num2 + Math.Sin(num3) * num6);
        Color color = new Color();
        if ((int32_1 < 0 ? 1 : (int32_1 >= OriginalImage.Width ? 1 : 0)) == 0 && (int32_2 < 0 ? 1 : (int32_2 >= OriginalImage.Height ? 1 : 0)) == 0)
        {
          Color pixel = OriginalImage.GetPixel(int32_1, int32_2);
          bitmap2.SetPixel(x, y, pixel);
        }
      }
    }
    return bitmap2;
  }

  public static Image RotateImage(Image bmp, double angle)
  {
    float height = (float) bmp.Height;
    float width = (float) bmp.Width;
    int int32 = Convert.ToInt32(Math.Floor(Math.Sqrt((double) height * (double) height + (double) width * (double) width)));
    Bitmap bitmap = new Bitmap(int32, int32);
    using (Graphics graphics = Graphics.FromImage((Image) bitmap))
    {
      graphics.TranslateTransform((float) bitmap.Width / 2f, (float) bitmap.Height / 2f);
      graphics.RotateTransform((float) angle);
      graphics.TranslateTransform((float) (-(double) bitmap.Width / 2.0), (float) (-(double) bitmap.Height / 2.0));
      graphics.DrawImage(bmp, (float) (((double) int32 - (double) width) / 2.0), (float) (((double) int32 - (double) height) / 2.0), width, height);
    }
    return (Image) bitmap;
  }

  public static Bitmap RotateImage(Bitmap bmp, double angle)
  {
    float height = (float) bmp.Height;
    float width = (float) bmp.Width;
    int int32 = Convert.ToInt32(Math.Floor(Math.Sqrt((double) height * (double) height + (double) width * (double) width)));
    Bitmap bitmap = new Bitmap((int) width, (int) height);
    using (Graphics graphics = Graphics.FromImage((Image) bitmap))
    {
      graphics.TranslateTransform((float) bitmap.Width / 2f, (float) bitmap.Height / 2f);
      graphics.RotateTransform((float) angle);
      graphics.TranslateTransform((float) (-(double) bitmap.Width / 2.0), (float) (-(double) bitmap.Height / 2.0));
      graphics.DrawImage((Image) bmp, (float) (((double) int32 - (double) width) / 2.0), (float) (((double) int32 - (double) height) / 2.0), width, height);
    }
    return bitmap;
  }

  public static bool isColorSame(Color BaseColor, Color SimilarColor)
  {
    return (int) BaseColor.R == (int) SimilarColor.R && (int) BaseColor.G == (int) SimilarColor.G && (int) BaseColor.B == (int) SimilarColor.B && (int) BaseColor.A == (int) SimilarColor.A;
  }

  public static bool isColorSimilar(Color BaseColor, Color SimilarColor, double Limit)
  {
    double num1 = Convert.ToDouble(BaseColor.R);
    double num2 = Convert.ToDouble(BaseColor.G);
    double num3 = Convert.ToDouble(BaseColor.B);
    double num4 = Math.Pow(Convert.ToDouble(SimilarColor.R) - num1, 2.0);
    double num5 = Math.Pow(Convert.ToDouble(SimilarColor.G) - num2, 2.0);
    double num6 = Math.Sqrt(Math.Pow(Convert.ToDouble(SimilarColor.B) - num3, 2.0) + num5 + num4);
    bool flag;
    if (num6 == 0.0)
      flag = true;
    else if (num6 < Limit)
    {
      Limit = num6;
      flag = true;
    }
    else
      flag = false;
    return flag;
  }

  public static Color Darken(Color c, float level)
  {
    return Color.FromArgb((int) c.A, (int) ((double) c.R / (double) level), (int) ((double) c.G / (double) level), (int) ((double) c.B / (double) level));
  }

  public static void SetSimilarColor(Color BaseColor, ref Color SimilarColor, int Limit)
  {
    Convert.ToDouble(BaseColor.R);
    Convert.ToDouble(BaseColor.G);
    Convert.ToDouble(BaseColor.B);
    int num1 = (int) BaseColor.R + Limit;
    int green = (int) BaseColor.G + Limit;
    int blue = (int) BaseColor.B + Limit;
    if (num1 > (int) byte.MaxValue)
      num1 = (int) byte.MaxValue;
    int num2;
    if (num1 < 0)
      num2 = 0;
    if (green > (int) byte.MaxValue)
      green = (int) byte.MaxValue;
    if (green < 0)
      green = 0;
    if (blue > (int) byte.MaxValue)
      blue = (int) byte.MaxValue;
    if (blue < 0)
      blue = 0;
    num2 = 160 /*0xA0*/;
    SimilarColor = Color.FromArgb((int) BaseColor.A, 160 /*0xA0*/, green, blue);
  }

  public static string ColorToString(Color clr, ColorConvertType Type)
  {
    try
    {
      return clr.IsKnownColor || clr.IsNamedColor || Type != ColorConvertType.Html ? clr.ToString() : ColorTranslator.ToHtml(clr);
    }
    catch (Exception ex)
    {
      return "Black";
    }
  }

  public static Color StringToColor(string Code, ColorConvertType Type)
  {
    Color color1 = new Color();
    color1 = Color.Black;
    try
    {
      string[] strArray = Code.Split(',');
      if (strArray.Length >= 4)
      {
        strArray[0] = strArray[0].Replace("[", "");
        strArray[3] = strArray[3].Replace("]", "");
        int int32_1 = Convert.ToInt32(strArray[0].Substring(strArray[0].IndexOf('=') + 1));
        int int32_2 = Convert.ToInt32(strArray[1].Substring(strArray[1].IndexOf('=') + 1));
        int int32_3 = Convert.ToInt32(strArray[2].Substring(strArray[2].IndexOf('=') + 1));
        int int32_4 = Convert.ToInt32(strArray[3].Substring(strArray[3].IndexOf('=') + 1));
        Color color2 = new Color();
        return Color.FromArgb(int32_1, int32_2, int32_3, int32_4);
      }
      if (Type == ColorConvertType.Html)
        return ColorTranslator.FromHtml(Code);
      Code = Code.Replace("Color", "");
      Code = Code.Replace("[", "");
      Code = Code.Replace("]", "");
      Code = Code.Replace(":", "");
      Code = Code.Trim();
      return ColorTranslator.FromHtml(Code);
    }
    catch (Exception ex)
    {
      return Color.Black;
    }
  }

  public static void GetScreenShot(Form frm, ref Bitmap SSBmp)
  {
    ref Bitmap local = ref SSBmp;
    Rectangle bounds = frm.Bounds;
    int width = bounds.Width;
    bounds = frm.Bounds;
    int height = bounds.Height;
    Bitmap bitmap = new Bitmap(width, height);
    local = bitmap;
    Graphics.FromImage((Image) SSBmp).CopyFromScreen(frm.Left, frm.Top, 0, 0, new Size(frm.Width, frm.Height), CopyPixelOperation.SourceCopy);
  }

  public static void GetScreenShot(int Left, int Top, int Width, int Height, ref Bitmap SSBmp)
  {
    SSBmp = new Bitmap(Width, Height);
    Graphics.FromImage((Image) SSBmp).CopyFromScreen(Left, Top, 0, 0, new Size(Width, Height), CopyPixelOperation.SourceCopy);
  }

  public static void GetScreenShotAndSaveFile(
    int Left,
    int Top,
    int Width,
    int Height,
    bool AutoSave,
    string FileName,
    string FileFolder)
  {
    Bitmap bitmap = new Bitmap(Width, Height);
    Graphics.FromImage((Image) bitmap).CopyFromScreen(Left, Top, 0, 0, new Size(Width, Height), CopyPixelOperation.SourceCopy);
    if (AutoSave)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(FileFolder);
      if (!directoryInfo.Exists)
        directoryInfo.Create();
      bitmap.Save($"{FileFolder}\\{FileName}");
    }
    else
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = FileFolder;
      saveFileDialog.Filter = "Image File (*.png,*.jpeg)|*.png;*.jpg|PNG File (*.png)|*.png|Jepg File (*.jpg)|*.jpg";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
        bitmap.Save(saveFileDialog.FileName);
    }
  }

  public static Color GetColorFrom50ListByIndex(int index)
  {
    int index1 = index % 50;
    if (index1 >= 50)
      index1 = 0;
    return MachineGCodeConfigrasyon.ColorList50UnPopular[index1];
  }

  [Serializable]
  public class Ply : buSerilization
  {
    public static byte[] ImageToByteArray(Image imageIn)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        imageIn.Save((Stream) memoryStream, imageIn.RawFormat);
        return memoryStream.ToArray();
      }
    }

    public static void OpenImageAsStream(string FileName, ref Image image)
    {
      try
      {
        Bitmap bitmap;
        using (FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
        {
          Image original = Image.FromStream((Stream) fileStream);
          bitmap = new Bitmap(original);
          original.Dispose();
        }
        image = (Image) bitmap;
      }
      catch (Exception ex)
      {
      }
    }
  }

  public class PLYToSchematic : buSerilization
  {
    public static Image OpenImageAsStream(string FileName)
    {
      try
      {
        Bitmap bitmap;
        using (FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
        {
          Image original = Image.FromStream((Stream) fileStream);
          bitmap = new Bitmap(original);
          original.Dispose();
        }
        return (Image) bitmap;
      }
      catch (Exception ex)
      {
        return (Image) null;
      }
    }

    public static void OpenImageAsStream(string FileName, ref Bitmap image)
    {
      try
      {
        Bitmap bitmap;
        using (FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
        {
          Image original = Image.FromStream((Stream) fileStream);
          bitmap = new Bitmap(original);
          original.Dispose();
        }
        image = bitmap;
      }
      catch (Exception ex)
      {
      }
    }

    internal enum \u0001
    {
    }

    internal class \u0002
    {
      public bool ShowPersentage;
      public int TopHeight;
      public int BottomHeight;
      public Color LineColor;

      static \u0002()
      {
        // ISSUE: reference to a compiler-generated field
        buVector5.\u0002.ColorList = new List<Color>()
        {
          Color.Blue,
          Color.Green,
          Color.Cyan,
          Color.Magenta,
          Color.Yellow,
          Color.Pink,
          Color.Brown,
          Color.Lime,
          Color.Orange,
          Color.Khaki,
          Color.Linen,
          Color.Firebrick,
          Color.IndianRed,
          Color.LightSalmon,
          Color.Gold,
          Color.YellowGreen,
          Color.PaleGreen,
          Color.Turquoise,
          Color.LightCyan,
          Color.Teal,
          Color.SteelBlue,
          Color.Navy,
          Color.Orchid,
          Color.DeepPink,
          Color.Coral,
          Color.DarkKhaki,
          Color.FloralWhite,
          Color.MediumAquamarine,
          Color.Peru
        };
        MachineGCodeConfigrasyon.ColorList50UnPopular = new List<Color>()
        {
          Color.SteelBlue,
          Color.Lavender,
          Color.CadetBlue,
          Color.CornflowerBlue,
          Color.Crimson,
          Color.DarkGoldenrod,
          Color.DarkMagenta,
          Color.DarkSalmon,
          Color.DarkSlateBlue,
          Color.DeepSkyBlue,
          Color.FloralWhite,
          Color.HotPink,
          Color.Khaki,
          Color.Coral,
          Color.LemonChiffon,
          Color.LightSteelBlue,
          Color.Maroon,
          Color.MediumOrchid,
          Color.MediumSeaGreen,
          Color.MistyRose,
          Color.Olive,
          Color.PaleGreen,
          Color.PaleTurquoise,
          Color.PeachPuff,
          Color.Peru,
          Color.Plum,
          Color.PowderBlue,
          Color.RosyBrown,
          Color.RoyalBlue,
          Color.Sienna,
          Color.SlateGray,
          Color.Tan,
          Color.Teal,
          Color.Thistle,
          Color.Tomato,
          Color.Violet,
          Color.Wheat,
          Color.YellowGreen,
          Color.OliveDrab,
          Color.OldLace,
          Color.LightYellow,
          Color.Honeydew,
          Color.LawnGreen,
          Color.LimeGreen,
          Color.LightSalmon,
          Color.Indigo,
          Color.DarkGray,
          Color.Firebrick,
          Color.MediumPurple,
          Color.MediumVioletRed,
          Color.AliceBlue
        };
      }
    }

    internal class \u0003
    {
      public Color ArrowColor;
      public Color DropColor;
      public Color ValueColor;

      [CompilerGenerated]
      [SpecialName]
      public byte[] get_Pixels() => ((MachineGCodeConfigrasyon) this).\u0001;
    }
  }

  [Serializable]
  public class Cf2 : buSerilization
  {
    public ContentAlignment ImageAlignment;
    public ShapeType GeometryType;
    public int GeometryArcDiameer;
    public static byte f000926;
    public bool VisibleStatus;
    public int ControlLeft;
    public int ControlTop;
    public int ControlWidth;
    public int ControlHeight;
    public int ImageIndex;

    [CompilerGenerated]
    [SpecialName]
    public void set_Pixels(byte[] value) => ((MachineGCodeConfigrasyon) this).\u0001 = value;

    [CompilerGenerated]
    [SpecialName]
    public int get_Depth() => ((MachineAxisInfo) this).\u0001;

    [CompilerGenerated]
    [SpecialName]
    public int get_Width() => ((MachineAxisInfo) this).\u0002;
  }

  public class GCodeRead
  {
    public static byte f00092D;
    public Font fontHeader;
    public Font fontCell;
    public Color colorBackGround;
    public Color colorHeader;
    public Color colorHeaderFore;
    public Color colorFore;
    public Color colorCell;
    public Color colorCellSelected;
    public Color colorGrid;
    public static byte f000937;
    public double ArrowTotalLen;
    public double ArrowDiameter;
    public double ArrowConeDiameter;

    [CompilerGenerated]
    [SpecialName]
    public int get_Height() => ((MachineAxisInfo) this).\u0003;

    public GCodeRead(Bitmap source)
    {
      ((MachineGCodeConfigrasyon) this).\u0001 = (Bitmap) null;
      ((MachineGCodeConfigrasyon) this).\u0001 = IntPtr.Zero;
      ((MachineGCodeConfigrasyon) this).\u0001 = (BitmapData) null;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ((MachineGCodeConfigrasyon) this).\u0001 = source;
    }
  }

  public class GCodeAssingmentArgs
  {
    public double ArrowConeLen;
    public double BallDiameter;

    public void LockBits()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        ((buFile5.Cf2) this).\u0002(((MachineGCodeConfigrasyon) this).\u0001.Width);
        // ISSUE: reference to a compiler-generated method
        ((buFile5.GCodeRead) this).\u0003(((MachineGCodeConfigrasyon) this).\u0001.Height);
        int num1 = ((buFile5.Cf2) this).get_Width() * ((buFile5.GCodeRead) this).get_Height();
        Rectangle rect = new Rectangle(0, 0, ((buFile5.Cf2) this).get_Width(), ((buFile5.GCodeRead) this).get_Height());
        // ISSUE: reference to a compiler-generated method
        ((buFile5.Cf2) this).\u0001(Image.GetPixelFormatSize(((MachineGCodeConfigrasyon) this).\u0001.PixelFormat));
        if ((((buFile5.Cf2) this).get_Depth() == 8 || ((buFile5.Cf2) this).get_Depth() == 24 ? 0 : (((buFile5.Cf2) this).get_Depth() != 32 /*0x20*/ ? 1 : 0)) != 0)
          throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
        ((MachineGCodeConfigrasyon) this).\u0001 = ((MachineGCodeConfigrasyon) this).\u0001.LockBits(rect, ImageLockMode.ReadWrite, ((MachineGCodeConfigrasyon) this).\u0001.PixelFormat);
        int num2 = ((buFile5.Cf2) this).get_Depth() / 8;
        ((buFile5.Cf2) this).set_Pixels(new byte[num1 * num2]);
        ((MachineGCodeConfigrasyon) this).\u0001 = ((MachineGCodeConfigrasyon) this).\u0001.Scan0;
        Marshal.Copy(((MachineGCodeConfigrasyon) this).\u0001, ((buFile5.PLYToSchematic.\u0003) this).get_Pixels(), 0, ((buFile5.PLYToSchematic.\u0003) this).get_Pixels().Length);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void UnlockBits()
    {
      try
      {
        Marshal.Copy(((buFile5.PLYToSchematic.\u0003) this).get_Pixels(), 0, ((MachineGCodeConfigrasyon) this).\u0001, ((buFile5.PLYToSchematic.\u0003) this).get_Pixels().Length);
        ((MachineGCodeConfigrasyon) this).\u0001.UnlockBits(((MachineGCodeConfigrasyon) this).\u0001);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }

  public class HPGLFile
  {
    public Color XAxisColor;

    public Color GetPixel(int x, int y)
    {
      Color pixel = Color.Empty;
      int num1 = ((buFile5.Cf2) this).get_Depth() / 8;
      int index = (y * ((buFile5.Cf2) this).get_Width() + x) * num1;
      if (index > ((buFile5.PLYToSchematic.\u0003) this).get_Pixels().Length - num1)
        throw new IndexOutOfRangeException();
      if (((buFile5.Cf2) this).get_Depth() == 32 /*0x20*/)
      {
        byte blue = ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index];
        byte green = ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 1];
        byte red = ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 2];
        pixel = Color.FromArgb((int) ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 3], (int) red, (int) green, (int) blue);
      }
      if (((buFile5.Cf2) this).get_Depth() == 24)
      {
        byte blue = ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index];
        byte green = ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 1];
        pixel = Color.FromArgb((int) ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 2], (int) green, (int) blue);
      }
      if (((buFile5.Cf2) this).get_Depth() == 8)
      {
        byte num2 = ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index];
        pixel = Color.FromArgb((int) num2, (int) num2, (int) num2);
      }
      return pixel;
    }

    public void SetPixel(int x, int y, Color color)
    {
      int num = ((buFile5.Cf2) this).get_Depth() / 8;
      int index = (y * ((buFile5.Cf2) this).get_Width() + x) * num;
      if (((buFile5.Cf2) this).get_Depth() == 32 /*0x20*/)
      {
        ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index] = color.B;
        ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 1] = color.G;
        ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 2] = color.R;
        ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 3] = color.A;
      }
      if (((buFile5.Cf2) this).get_Depth() == 24)
      {
        ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index] = color.B;
        ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 1] = color.G;
        ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index + 2] = color.R;
      }
      if (((buFile5.Cf2) this).get_Depth() != 8)
        return;
      ((buFile5.PLYToSchematic.\u0003) this).get_Pixels()[index] = color.B;
    }

    public abstract void m00053D();

    public HPGLFile()
    {
      if (!buVector5.\u0001("buFile"))
        throw new RegisterException("buFile");
      MachineAxisInfo.\u0001 = 6.57597432524649E+16;
      MachineAxisInfo.\u0002 = -94571056733.0;
      MachineMCodeInfo.\u0001 = "Ur43576Gc/+%6_*uwqvbuesETRQEUNFDANTRJWJTHTN(+%+%/754734BDFREHERH";
    }
  }

  public class IsoCutter
  {
    public static void GetFilesWithKeyword(
      string folder,
      string keyword,
      ref List<string> FileNames)
    {
      // ISSUE: variable of a compiler-generated type
      buFile5.\u0001 obj = (buFile5.\u0001) new buVector5();
      ((EditorSettings) obj).\u0001 = keyword;
      try
      {
        FileNames.Clear();
        foreach (string str in Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories).Where<string>(new Func<string, bool>(((buVector5) obj).\u0001)))
          FileNames.Add(str);
      }
      catch (Exception ex)
      {
        FileNames = new List<string>();
      }
    }

    public static void GetFilesWithKeywordWithExtension(
      string folder,
      string keyword,
      string Extension,
      ref List<string> FileNames)
    {
      // ISSUE: variable of a compiler-generated type
      buFile5.\u0002 obj = (buFile5.\u0002) new buVector5();
      ((EditorSettings) obj).\u0001 = keyword;
      try
      {
        FileNames.Clear();
        foreach (string str in Directory.EnumerateFiles(folder, "*." + Extension, SearchOption.AllDirectories).Where<string>(new Func<string, bool>(((buVector5) obj).\u0001)))
          FileNames.Add(str);
      }
      catch (Exception ex)
      {
        FileNames = new List<string>();
      }
    }
  }

  [Serializable]
  public class bunesting : buSerilization
  {
    public static void DeleteAllFilesInDirectory(string sourceDir)
    {
      DirectoryInfo directoryInfo = new DirectoryInfo(sourceDir);
      foreach (string file in Directory.GetFiles(sourceDir))
        File.Delete(file);
      foreach (string directory in Directory.GetDirectories(sourceDir))
        buFile5.bunesting.DeleteAllFilesInDirectory(directory);
    }

    public static void DeleteAllEmptyDirectoryInDirectory(string sourceDir)
    {
      foreach (string directory in Directory.GetDirectories(sourceDir))
      {
        string[] directories = Directory.GetDirectories(directory);
        if (directories.Length == 0)
        {
          new DirectoryInfo(directory).Delete();
        }
        else
        {
          for (int index = 0; index <= directories.Length - 1; ++index)
            buFile5.bunesting.DeleteAllEmptyDirectoryInDirectory(directories[index]);
          new DirectoryInfo(directory).Delete();
        }
      }
    }

    public static string GetDesktopFolder()
    {
      return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }

    public static void getFiles(string Path, ref List<string> Files)
    {
      try
      {
        if (!new DirectoryInfo(Path).Exists)
          return;
        Files = new List<string>();
        string[] files = Directory.GetFiles(Path);
        if (files == null)
          return;
        for (int index = 0; index <= files.Length - 1; ++index)
          Files.Add(files[index]);
      }
      catch (Exception ex)
      {
        string str = "Path: " + Path.ToString();
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      }
    }

    public static string getFileName(string FullPath) => Path.GetFileName(FullPath);

    public static string getFileNameWithoutExtension(string FullPath)
    {
      return Path.GetFileNameWithoutExtension(FullPath);
    }

    public static string getFileExtension(string FullPath) => Path.GetExtension(FullPath);

    public static string GetPreviousPath(string FullPath)
    {
      try
      {
        return Directory.GetParent(FullPath).FullName;
      }
      catch (Exception ex)
      {
        string str = "FullPath: " + FullPath.ToString();
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
        return "";
      }
    }

    public static string GetPath(string FullFileName)
    {
      try
      {
        return FullFileName.Length > 1 ? Path.GetDirectoryName(FullFileName) : "";
      }
      catch (Exception ex)
      {
        string str = "FullFileName: " + FullFileName.ToString();
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
        return "";
      }
    }

    public static void getPathsInFullPath(string Path, ref List<string> Paths)
    {
      try
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path);
        Paths = new List<string>();
        if (!directoryInfo.Exists)
          return;
        foreach (string directory in Directory.GetDirectories(directoryInfo.FullName))
          Paths.Add(directory);
      }
      catch (Exception ex)
      {
        string str = "Path: " + Path.ToString();
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      }
    }

    public static void getPathsInPath(string BasePath, ref List<string> Paths)
    {
      try
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(BasePath);
        Paths = new List<string>();
        if (!directoryInfo.Exists)
          return;
        foreach (string str in ((IEnumerable<string>) Directory.GetDirectories(directoryInfo.FullName)).Select<string, string>(new Func<string, string>(Path.GetFileName)).OrderBy<string, string>(EditorSettings.\u003C\u003E9__17_0 ?? (EditorSettings.\u003C\u003E9__17_0 = new Func<string, string>(((buVector5) EditorSettings.\u003C\u003E9).\u0001))).ToArray<string>())
          Paths.Add(str);
      }
      catch (Exception ex)
      {
        string str = "Path: " + BasePath.ToString();
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      }
    }

    public static void GetFilesInDirectory(string Dir, string Extension, ref List<string> Files)
    {
      try
      {
        string str = Extension.Replace(".", "").Replace("*", "");
        if (!new DirectoryInfo(Dir).Exists)
          return;
        string[] files = Directory.GetFiles(Dir, "*." + str);
        for (int index = 0; index <= files.Length - 1; ++index)
          Files.Add(files[index]);
      }
      catch (Exception ex)
      {
        string str = $"Dir: {Dir.ToString()} - FileType: {Extension.ToString()}";
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      }
    }
  }
}
