// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.LockBitmap
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace buEyeBaseVer5;

public class LockBitmap
{
  public int ConvertedGCodeLineCount;
  public double FilterLength;
  public bool CheckComma;
  public bool TrimLines;
  public bool UseMCode;
  public bool UseTCode;
  public bool UseSCode;

  public static string ArrayListToString(ArrayList AL, bool NewLineEnable)
  {
    string str = "";
    for (int index = 0; index <= AL.Count - 1; ++index)
    {
      str += AL[index].ToString();
      if (index < AL.Count - 1)
        str = !NewLineEnable ? str + " " : str + Environment.NewLine;
    }
    return str;
  }

  public static void StringToArrayListByNewLine(string RefString, ref ArrayList Lines)
  {
    LockBitmap.SplitStringByNewLine(RefString, ref Lines);
  }

  public static void StringToListByNewLine(string RefString, ref List<string> Lines)
  {
    LockBitmap.SplitStringByNewLine(RefString, ref Lines);
  }

  public static void StringToArrayByNewLine(string RefString, ref string[] Lines)
  {
    Lines = RefString.Split(new string[2]{ "\r\n", "\n" }, StringSplitOptions.None);
  }

  public static void AddToArrayList(ArrayList refAL, ref ArrayList AddedAL)
  {
    for (int index = 0; index <= refAL.Count - 1; ++index)
      AddedAL.Add(refAL[index]);
  }

  public static void SplitStringByNewLine(string RefString, ref List<string> Lines)
  {
    Lines = new List<string>();
    string[] strArray = RefString.Split(new string[2]
    {
      "\r\n",
      "\n"
    }, StringSplitOptions.None);
    for (int index = 0; index <= strArray.Length - 1; ++index)
      Lines.Add(strArray[index]);
  }

  public static void SplitStringByNewLine(string RefString, ref ArrayList Lines)
  {
    Lines = new ArrayList();
    string[] strArray = RefString.Split(new string[2]
    {
      "\r\n",
      "\n"
    }, StringSplitOptions.None);
    for (int index = 0; index <= strArray.Length - 1; ++index)
      Lines.Add((object) strArray[index]);
  }

  public static void SplitStringByRefWord(string RefString, string RefWord, ref string[] Lines)
  {
    Lines = RefString.Split(new string[1]{ RefWord }, StringSplitOptions.RemoveEmptyEntries);
  }

  public static void AddStringsToList(
    string S1,
    ref List<string> SL,
    bool ClearList = true,
    string S2 = "",
    string S3 = "",
    string S4 = "",
    string S5 = "",
    string S6 = "",
    string S7 = "",
    string S8 = "",
    string S9 = "",
    string S10 = "")
  {
    if (SL == null)
      SL = new List<string>();
    if (ClearList)
      SL.Clear();
    if (S1.Length > 0)
      SL.Add(S1);
    if (S2.Length > 0)
      SL.Add(S2);
    if (S3.Length > 0)
      SL.Add(S3);
    if (S4.Length > 0)
      SL.Add(S4);
    if (S5.Length > 0)
      SL.Add(S5);
    if (S6.Length > 0)
      SL.Add(S6);
    if (S7.Length > 0)
      SL.Add(S7);
    if (S8.Length > 0)
      SL.Add(S8);
    if (S9.Length > 0)
      SL.Add(S9);
    if (S10.Length <= 0)
      return;
    SL.Add(S10);
  }

  public static void AddStringsToList1(
    string S1,
    ref List<string> SL,
    bool ClearList = true,
    string S2 = "",
    string S3 = "",
    string S4 = "",
    string S5 = "")
  {
    if (SL == null)
      SL = new List<string>();
    if (ClearList)
      SL.Clear();
    if (S1.Length > 0)
      SL.Add(S1);
    if (S2.Length > 0)
      SL.Add(S2);
    if (S3.Length > 0)
      SL.Add(S3);
    if (S4.Length > 0)
      SL.Add(S4);
    if (S5.Length <= 0)
      return;
    SL.Add(S5);
  }

  public static void AddStringsToList1(string S1, ref List<string> SL, bool ClearList = true, string S2 = "")
  {
    if (SL == null)
      SL = new List<string>();
    if (ClearList)
      SL.Clear();
    if (S1.Length > 0)
      SL.Add(S1);
    if (S2.Length <= 0)
      return;
    SL.Add(S2);
  }

  public static void GetItemsAccordingToTheLang(
    List<string> RefList,
    int Language,
    List<string> CalcList)
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
            CalcList.Add(strArray2[Language].Trim());
        }
        else
        {
          string[] strArray3 = RefList[index].Split(';');
          if (Language <= strArray3.Length - 1)
            CalcList.Add(strArray3[Language].Trim());
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
    List<string> RefList,
    int Language,
    ref List<string> CalcList)
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
            CalcList.Add(strArray2[Language].Trim());
        }
        else
        {
          string[] strArray3 = RefList[index].Split(';');
          if (Language <= strArray3.Length - 1)
            CalcList.Add(strArray3[Language].Trim());
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog(nameof (GetItemsAccordingToTheLang), "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public byte[] Pixels
  {
    [CompilerGenerated, SpecialName] get => ((MachineGCodeConfigrasyon) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((MachineGCodeConfigrasyon) this).\u0001 = value;
  }

  public int Depth
  {
    [CompilerGenerated, SpecialName] get => ((MachineAxisInfo) this).\u0001;
    [CompilerGenerated, SpecialName] [param: In] private set
    {
      ((MachineAxisInfo) this).\u0001 = value;
    }
  }

  public int Width
  {
    [CompilerGenerated, SpecialName] get => ((MachineAxisInfo) this).\u0002;
    [CompilerGenerated, SpecialName] [param: In] private set
    {
      ((MachineAxisInfo) this).\u0002 = value;
    }
  }

  public int Height
  {
    [CompilerGenerated, SpecialName] get => ((MachineAxisInfo) this).\u0003;
    [CompilerGenerated, SpecialName] [param: In] private set
    {
      ((MachineAxisInfo) this).\u0003 = value;
    }
  }
}
