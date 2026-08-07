// Decompiled with JetBrains decompiler
// Type: buCore.buGeneral
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buCore;

public class buGeneral
{
  public buGeneral()
  {
    if (!buVector.smethod_0(nameof (buGeneral)))
      throw new RegisterException(nameof (buGeneral));
  }

  public static void ExchangeDatas(ref double FirstData, ref double SecondData)
  {
    try
    {
      double num = FirstData;
      FirstData = SecondData;
      SecondData = num;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static void ExchangeDatas(ref int FirstData, ref int SecondData)
  {
    try
    {
      int num = FirstData;
      FirstData = SecondData;
      SecondData = num;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static void ExchangeDatas(ref float FirstData, ref float SecondData)
  {
    try
    {
      float num = FirstData;
      FirstData = SecondData;
      SecondData = num;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static void ExchangeDatas(ref object FirstData, ref object SecondData)
  {
    try
    {
      object obj1 = (object) 0;
      object obj2 = FirstData;
      FirstData = SecondData;
      SecondData = obj2;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static void ExchangeDatas(ref Pnt3D FirstData, ref Pnt3D SecondData)
  {
    try
    {
      Pnt3D pnt3D = new Pnt3D();
      Pnt3D Pnt = new Pnt3D(FirstData);
      FirstData = new Pnt3D(SecondData);
      SecondData = new Pnt3D(Pnt);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static void ExchangeDatas(ref Pnt2D FirstData, ref Pnt2D SecondData)
  {
    try
    {
      Pnt2D pnt2D = new Pnt2D();
      Pnt2D Pnt = new Pnt2D(FirstData);
      FirstData = new Pnt2D(SecondData);
      SecondData = new Pnt2D(Pnt);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static void ExchangeDatas(ref List<Pnt3D> FirstData, ref List<Pnt3D> SecondData)
  {
    try
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index = 0; index <= FirstData.Count - 1; ++index)
        pnt3DList.Add(new Pnt3D(FirstData[index]));
      FirstData.Clear();
      for (int index = 0; index <= SecondData.Count - 1; ++index)
        FirstData.Add(new Pnt3D(SecondData[index]));
      SecondData.Clear();
      for (int index = 0; index <= pnt3DList.Count - 1; ++index)
        SecondData.Add(new Pnt3D(pnt3DList[index]));
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static bool SwapBool(bool RefVal) => !RefVal;

  public static void SwapBool(ref bool RefVal)
  {
    if (RefVal)
      RefVal = false;
    else
      RefVal = true;
  }

  public static void CopyLists(List<int> SourceList, ref List<int> TargetList)
  {
    try
    {
      TargetList.Clear();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(SourceList[index]);
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void AddLists(List<int> SourceList, ref List<int> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(SourceList[index]);
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<double> SourceList, ref List<double> TargetList)
  {
    try
    {
      TargetList.Clear();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(SourceList[index]);
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void AddLists(List<double> SourceList, ref List<double> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(SourceList[index]);
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<string> SourceList, ref List<string> TargetList)
  {
    try
    {
      TargetList.Clear();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(SourceList[index]);
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static List<string> CopyLists(List<string> SourceList)
  {
    try
    {
      List<string> stringList = new List<string>();
      if (SourceList.Count <= 0)
        return stringList;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        stringList.Add(SourceList[index]);
      return stringList;
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return new List<string>();
    }
  }

  public static void CopyLists(List<string> SourceList, ref ArrayList TargetList)
  {
    try
    {
      TargetList.Clear();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add((object) SourceList[index]);
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void AddLists(List<Pnt3D> SourceList, ref List<Pnt3D> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(new Pnt3D(SourceList[index]));
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<Pnt3D> SourceList, ref List<Pnt3D> TargetList)
  {
    try
    {
      TargetList.Clear();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(new Pnt3D(SourceList[index]));
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<List<Pnt3D>> SourceList, ref List<Pnt3D> TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      TargetList = new List<Pnt3D>();
      for (int index1 = 0; index1 <= SourceList.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
          TargetList.Add(new Pnt3D(SourceList[index1][index2]));
      }
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<Pnt3D> SourceList, ref ArrayList TargetList)
  {
    try
    {
      TargetList.Clear();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add((object) new Pnt3D(SourceList[index]));
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(ArrayList SourceList, ref ArrayList TargetList)
  {
    try
    {
      TargetList.Clear();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(SourceList[index]);
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<Pnt3D>[] SourceList, ref List<Pnt3D>[] TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      TargetList = new List<Pnt3D>[SourceList.Length];
      for (int index1 = 0; index1 <= SourceList.Length - 1; ++index1)
      {
        TargetList[index1] = new List<Pnt3D>();
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
          TargetList[index1].Add(new Pnt3D(SourceList[index1][index2]));
      }
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Length.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void AddLists(List<eEntities> SourceList, ref List<eEntities> TargetList)
  {
    try
    {
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        eEntities eEntities1 = new eEntities();
        eEntities eEntities2 = eEntities.CopyEntity(SourceList[index]);
        TargetList.Add(eEntities2);
      }
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<eEntities> SourceList, ref List<eEntities> TargetList)
  {
    try
    {
      TargetList = new List<eEntities>();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
      {
        eEntities eEntities1 = new eEntities();
        eEntities eEntities2 = eEntities.CopyEntity(SourceList[index]);
        TargetList.Add(eEntities2);
      }
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<eEntities>[] SourceList, ref List<eEntities>[] TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      TargetList = new List<eEntities>[SourceList.Length];
      for (int index1 = 0; index1 <= SourceList.Length - 1; ++index1)
      {
        TargetList[index1] = new List<eEntities>();
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
        {
          eEntities eEntities1 = new eEntities();
          eEntities eEntities2 = eEntities.CopyEntity(SourceList[index1][index2]);
          TargetList[index1].Add(eEntities2);
        }
      }
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Length.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(
    List<List<eEntities>> SourceList,
    ref List<List<eEntities>> TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      TargetList = new List<List<eEntities>>();
      for (int index1 = 0; index1 <= SourceList.Count - 1; ++index1)
      {
        List<eEntities> eEntitiesList = new List<eEntities>();
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
        {
          eEntities eEntities1 = new eEntities();
          eEntities eEntities2 = eEntities.CopyEntity(SourceList[index1][index2]);
          eEntitiesList.Add(eEntities2);
        }
        TargetList.Add(eEntitiesList);
      }
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<List<eEntities>> SourceList, ref List<eEntities> TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      TargetList = new List<eEntities>();
      for (int index1 = 0; index1 <= SourceList.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
        {
          eEntities eEntities1 = new eEntities();
          eEntities eEntities2 = eEntities.CopyEntity(SourceList[index1][index2]);
          TargetList.Add(eEntities2);
        }
      }
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void AddLists(List<List<eEntities>> SourceList, ref List<eEntities> TargetList)
  {
    try
    {
      if (SourceList == null)
        return;
      for (int index1 = 0; index1 <= SourceList.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= SourceList[index1].Count - 1; ++index2)
        {
          eEntities eEntities1 = new eEntities();
          eEntities eEntities2 = eEntities.CopyEntity(SourceList[index1][index2]);
          TargetList.Add(eEntities2);
        }
      }
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CopyLists(List<Pnt9D> SourceList, ref List<Pnt9D> TargetList)
  {
    try
    {
      TargetList.Clear();
      if (SourceList.Count <= 0)
        return;
      for (int index = 0; index <= SourceList.Count - 1; ++index)
        TargetList.Add(new Pnt9D(SourceList[index]));
    }
    catch (Exception ex)
    {
      string str = "SourceList : " + SourceList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static object EnumValueFromInt(object EnumVar, int Index)
  {
    try
    {
      return (object) (Enum) Enum.ToObject(EnumVar.GetType(), Index);
    }
    catch (Exception ex)
    {
      string str = $"EnumVar : {EnumVar.ToString()} - Index: {Index.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return (object) null;
    }
  }

  public static object EnumValueFromString(object EnumVar, string EnumString)
  {
    try
    {
      return Enum.Parse(EnumVar.GetType(), EnumString, true);
    }
    catch (Exception ex)
    {
      string str = $"EnumVar : {EnumVar.ToString()} - EnumString: {EnumString.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return (object) null;
    }
  }

  public static void GetEnumTypeValues(object EnumType, ref ArrayList EnumItems)
  {
    try
    {
      if (EnumType == null || !EnumType.GetType().IsEnum)
        return;
      Array values = Enum.GetValues(EnumType.GetType());
      EnumItems.Clear();
      for (int index = 0; index <= values.Length - 1; ++index)
        EnumItems.Add(values.GetValue(index));
    }
    catch (Exception ex)
    {
      string str = "EnumType : " + EnumType?.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
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

  public static ShortCutKey DecodeShortKey(string ShortKeyCode)
  {
    try
    {
      string[] strArray = ShortKeyCode.Replace("ShortKey", "").Replace("(", "").Replace(")", "").Split(',');
      ShortCutKey shortCutKey = new ShortCutKey();
      if (strArray != null && strArray.Length == 4)
      {
        shortCutKey.FirstControlKey = (ControlKeys) buGeneral.EnumValueFromString((object) shortCutKey.FirstControlKey, strArray[0].Trim());
        shortCutKey.SecondControlKey = (ControlKeys) buGeneral.EnumValueFromString((object) shortCutKey.SecondControlKey, strArray[1].Trim());
        string str = strArray[2].Trim().ToUpper();
        if (str == "0" | str == "1" | str == "2" | str == "3" | str == "4" | str == "5" | str == "6" | str == "7" | str == "8" | str == "9")
          str = "Key" + str;
        if (str == "F0" | str == "F1" | str == "F2" | str == "F3" | str == "F4" | str == "F5" | str == "F6" | str == "F7" | str == "F8" | str == "F9" | str == "F10" | str == "F11" | str == "F12")
          str = "Key" + str;
        if (str == "SPACE" | str == "ESC" | str == "ENTER" | str == "DELETE" | str == "HOME" | str == "END" | str == "PAGEUP" | str == "PAGEDOWN")
          str = "Key" + str;
        shortCutKey.Key = (ActionKeys) buGeneral.EnumValueFromString((object) shortCutKey.Key, str.Trim());
        shortCutKey.Command = strArray[3].Trim();
      }
      return shortCutKey;
    }
    catch (Exception ex)
    {
      string str = ShortKeyCode;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return new ShortCutKey();
    }
  }

  public static MacroBase DecodeMacro(string MacroCode)
  {
    try
    {
      MacroBase macroBase = new MacroBase();
      string[] strArray1 = MacroCode.Split('=');
      if (strArray1 != null)
      {
        if (strArray1.Length == 1)
          macroBase.Command = strArray1[0].Trim();
        if (strArray1.Length == 2)
        {
          macroBase.Command = strArray1[0].Trim();
          string str = strArray1[1].Replace("(", "").Replace(")", "").Trim();
          if (str.Length > 0)
          {
            string[] strArray2 = str.Split(',');
            if (strArray2 != null)
            {
              for (int index = 0; index <= strArray2.Length - 1; ++index)
                macroBase.Args.Add((object) strArray2[index]);
            }
          }
        }
      }
      return macroBase;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
      return new MacroBase();
    }
  }

  public static void CultureSettings()
  {
    int[] numArray = new int[3]{ 3, 2, 2 };
    CultureInfo cultureInfo = new CultureInfo("en-US");
    DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
    cultureInfo.NumberFormat = new NumberFormatInfo()
    {
      CurrencySymbol = "Rs",
      CurrencyDecimalDigits = 3,
      CurrencyDecimalSeparator = ".",
      CurrencyGroupSizes = numArray,
      CurrencyGroupSeparator = ",",
      PositiveInfinitySymbol = " "
    };
    Application.CurrentCulture = cultureInfo;
    Thread.CurrentThread.CurrentCulture = cultureInfo;
    Thread.CurrentThread.CurrentUICulture = cultureInfo;
  }

  public static void DoEventCountCalc(int MaxCount, ref int CalcEventCount)
  {
    if (MaxCount <= 10)
      CalcEventCount = 1;
    if (MaxCount > 10 & MaxCount <= 50)
      CalcEventCount = 2;
    if (MaxCount > 50 & MaxCount <= 100)
      CalcEventCount = 5;
    if (MaxCount > 100 & MaxCount <= 500)
      CalcEventCount = 20;
    if (MaxCount > 500 & MaxCount <= 1000)
      CalcEventCount = 25;
    if (MaxCount > 1000 & MaxCount <= 5000)
      CalcEventCount = 50;
    if (MaxCount <= 5000)
      return;
    CalcEventCount = Convert.ToInt32((double) MaxCount / 100.0);
  }

  public static long GetMemorySizeofObject(object Obj)
  {
    long memorySizeofObject = 0;
    using (Stream serializationStream = (Stream) new MemoryStream())
    {
      new BinaryFormatter().Serialize(serializationStream, Obj);
      memorySizeofObject = serializationStream.Length;
    }
    return memorySizeofObject;
  }

  public static void RulerSteps(double Length, ref double Step)
  {
    try
    {
      if (Length >= 0.0 & Length < 0.2)
        Step = 0.1;
      if (Length >= 0.2 & Length < 0.5)
        Step = 0.2;
      if (Length >= 0.5 & Length < 1.0)
        Step = 0.5;
      if (Length >= 1.0 & Length < 2.0)
        Step = 1.0;
      if (Length >= 2.0 & Length < 5.0)
        Step = 2.0;
      if (Length >= 5.0 & Length < 10.0)
        Step = 5.0;
      if (Length >= 10.0 & Length < 20.0)
        Step = 10.0;
      if (Length >= 20.0 & Length < 50.0)
        Step = 20.0;
      if (Length >= 50.0 & Length < 100.0)
        Step = 50.0;
      if (Length >= 100.0 & Length < 200.0)
        Step = 100.0;
      if (Length >= 200.0 & Length < 300.0)
        Step = 200.0;
      if (Length >= 300.0 & Length < 500.0)
        Step = 300.0;
      if (Length >= 500.0 & Length < 1000.0)
        Step = 500.0;
      if (Length >= 1000.0 & Length < 2000.0)
        Step = 1000.0;
      if (Length >= 2000.0 & Length < 4000.0)
        Step = 2000.0;
      if (Length >= 4000.0 & Length < 10000.0)
        Step = 4000.0;
      if (Length >= 10000.0 & Length < 20000.0)
        Step = 10000.0;
      if (Length < 20000.0)
        return;
      Step = 20000.0;
    }
    catch (Exception ex)
    {
      string str = "Length : " + Length.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static string SecondToTime(double Second, bool Usems)
  {
    try
    {
      TimeSpan timeSpan = TimeSpan.FromSeconds(Second);
      string time;
      if (Usems)
        time = $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s:{timeSpan.Milliseconds:D3}ms";
      else
        time = $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
      return time;
    }
    catch (Exception ex)
    {
      string str = $"Second : {Second.ToString()} - Usems: {Usems.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "00:00:00";
    }
  }

  public static string GetToolExplanation(ToolBase Tool)
  {
    string toolExplanation = nameof (Tool);
    if (Tool.Geometry.GeometryType == ToolType.Flat)
      toolExplanation = $"{$"{$"{$"{$"{$"{$"{$"Name = {Tool.Data.Name.ToString()}{Environment.NewLine}"}No = {Tool.Data.No.ToString()}{Environment.NewLine}"}Diameter = {Tool.Geometry.Diameter.ToString()}{Environment.NewLine}"}Length = {Tool.Geometry.Length.ToString()}{Environment.NewLine}"}Spindle = {Tool.CamData.SpindleSpeed.ToString()}{Environment.NewLine}"}Feed = {Tool.CamData.FeedSpeed.ToString()}{Environment.NewLine}"}Plunge = {Tool.CamData.PlungeSpeed.ToString()}{Environment.NewLine}"}Purpose = {Tool.Purpose.ToString()}{Environment.NewLine}";
    if (Tool.Geometry.GeometryType == ToolType.Sphere)
      toolExplanation = $"{$"{$"{$"{$"{$"{$"{$"Name = {Tool.Data.Name.ToString()}{Environment.NewLine}"}No = {Tool.Data.No.ToString()}{Environment.NewLine}"}Diameter = {Tool.Geometry.Diameter.ToString()}{Environment.NewLine}"}Length = {Tool.Geometry.Length.ToString()}{Environment.NewLine}"}Spindle = {Tool.CamData.SpindleSpeed.ToString()}{Environment.NewLine}"}Feed = {Tool.CamData.FeedSpeed.ToString()}{Environment.NewLine}"}Plunge = {Tool.CamData.PlungeSpeed.ToString()}{Environment.NewLine}"}Purpose = {Tool.Purpose.ToString()}{Environment.NewLine}";
    if (Tool.Geometry.GeometryType == ToolType.Saw)
      toolExplanation = $"{$"{$"{$"{$"{$"{$"{$"Name = {Tool.Data.Name.ToString()}{Environment.NewLine}"}No = {Tool.Data.No.ToString()}{Environment.NewLine}"}Diameter = {Tool.Geometry.Diameter.ToString()}{Environment.NewLine}"}Thickness = {Tool.Geometry.Thickness.ToString()}{Environment.NewLine}"}Spindle = {Tool.CamData.SpindleSpeed.ToString()}{Environment.NewLine}"}Feed = {Tool.CamData.FeedSpeed.ToString()}{Environment.NewLine}"}Plunge = {Tool.CamData.PlungeSpeed.ToString()}{Environment.NewLine}"}Purpose = {Tool.Purpose.ToString()}{Environment.NewLine}";
    return toolExplanation;
  }

  public static void FitObjectByWidth(
    int TotalWidth,
    int ObjectHeigth,
    int ObjectTopPosition,
    int ObjectLeftOffset,
    int Space,
    int ObjectCount,
    ref List<Rectangle> Rects)
  {
    try
    {
      float num1 = (float) (TotalWidth - Space * 2 - Space * (ObjectCount - 1));
      Rectangle rectangle = new Rectangle();
      int num2 = (int) Math.Floor((double) num1 / (double) ObjectCount);
      rectangle.Height = ObjectHeigth;
      Rects.Clear();
      for (int index = 0; index <= ObjectCount - 1; ++index)
      {
        int num3 = Space + (num2 + Space) * index;
        rectangle.Width = num2;
        rectangle.Location = new Point(num3 + ObjectLeftOffset, ObjectTopPosition);
        Rects.Add(rectangle);
      }
    }
    catch (Exception ex)
    {
      string str = $"TotalWidth : {TotalWidth.ToString()} - ObjectHeigth: {ObjectHeigth.ToString()} - ObjectTopPosition: {ObjectTopPosition.ToString()} - ObjectLeftOffset: {ObjectLeftOffset.ToString()} - Space: {Space.ToString()} - ObjectCount: {ObjectCount.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void CreatParameterDefaultFiles(
    object Par,
    string RefString,
    ref string DefaultStr)
  {
    try
    {
      List<string> stringList = new List<string>();
      List<object> objectList = new List<object>();
      List<System.Type> typeList = new List<System.Type>();
      List<cParameter> Vars = new List<cParameter>();
      buSerilization.GetClassVariables(Par, ref Vars);
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        string str1 = Vars[index].Value.ToString();
        if (str1.ToLower() == "false" | str1.ToLower() == "true")
          str1 = str1.ToLower();
        if (typeList[index] == typeof (string))
          str1 = $"\"{str1}\"";
        if (typeList[index].BaseType == typeof (Enum))
        {
          string str2 = $"\"{str1}\"";
          str1 = "";
        }
        if (str1.Length > 0)
        {
          string str3 = $"{RefString}{Vars[index].Name} = {str1};";
          DefaultStr = DefaultStr + str3 + Environment.NewLine;
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"Par : {Par.ToString()} - RefString: {RefString.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static bool isFirstInit(string path)
  {
    string callMethod = nameof (isFirstInit);
    try
    {
      path = path.Replace("\\\\", "\\");
      return new FileInfo(path + "\\FirstInit.dll").Exists;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
      return false;
    }
  }

  public static void DeleteFirstInit(string path)
  {
    string callMethod = nameof (DeleteFirstInit);
    try
    {
      path = path.Replace("\\\\", "\\");
      FileInfo fileInfo = new FileInfo(path + "\\FirstInit.dll");
      if (!fileInfo.Exists)
        return;
      fileInfo.Delete();
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }
}
