// Decompiled with JetBrains decompiler
// Type: buCore.buString
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace buCore;

public class buString
{
  private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
  private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  private static string string_2 = "";
  private static string string_3 = "";
  private static double double_0 = 0.0;
  private static double double_1 = 0.0;

  public buString()
  {
    if (!buVector.smethod_0(nameof (buString)))
      throw new RegisterException(nameof (buString));
  }

  public static void MessageBoxInfo(string Message)
  {
    int num = (int) MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
  }

  public static void MessageBoxError(string Message)
  {
    int num = (int) MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.OK, MessageBoxIcon.Hand);
  }

  public static void MessageBoxWarning(string Message)
  {
    int num = (int) MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
  }

  public static DialogResult MessageBoxQuestion(string Message)
  {
    return MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
  }

  public static DialogResult MessageBoxQuestionYesNoCancel(string Message)
  {
    return MessageBox.Show(Message, $"{Application.ProductName} ,  Ver : {Application.ProductVersion}", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    ArrayList RefList,
    ref List<List<string>> CalcList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      CalcList = new List<List<string>>();
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) ((string) RefList[index]).Trim();
        if (((string) RefList[index]).Length >= 2 && RefList[index].ToString().Trim() == EndKey & flag)
        {
          if (AddStartEndKey)
            stringList.Add(EndKey);
          CalcList.Add(stringList);
          stringList = new List<string>();
          flag = false;
        }
        if (flag)
          stringList.Add(RefList[index].ToString());
        if (RefList[index].ToString().Trim() == StartKey)
        {
          flag = true;
          if (AddStartEndKey)
            stringList.Add(StartKey);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"StartKey : {StartKey} - EndKey : {EndKey}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    ArrayList RefList,
    ref List<string> CalcList)
  {
    try
    {
      CalcList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length < 2 || !(RefList[index].ToString().Trim() == EndKey & flag))
        {
          if (flag)
            CalcList.Add(RefList[index].ToString());
          if (RefList[index].ToString().Trim() == StartKey)
          {
            flag = true;
            if (AddStartEndKey)
              CalcList.Add(StartKey);
          }
        }
        else
        {
          if (AddStartEndKey)
            CalcList.Add(EndKey);
          break;
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"StartKey : {StartKey} - EndKey : {EndKey}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    ArrayList RefList,
    ref ArrayList CalcList)
  {
    try
    {
      CalcList = new ArrayList();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = (object) RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length < 2 || !(RefList[index].ToString().Trim() == EndKey & flag))
        {
          if (flag)
            CalcList.Add((object) RefList[index].ToString());
          if (RefList[index].ToString().Trim() == StartKey)
          {
            flag = true;
            if (AddStartEndKey)
              CalcList.Add((object) StartKey);
          }
        }
        else
        {
          if (AddStartEndKey)
            CalcList.Add((object) EndKey);
          break;
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"StartKey : {StartKey} - EndKey : {EndKey}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    List<string> RefList,
    ref List<string> CalcList)
  {
    try
    {
      CalcList = new List<string>();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length < 2 || !(RefList[index].ToString().Trim() == EndKey & flag))
        {
          if (flag)
            CalcList.Add(RefList[index].ToString());
          if (RefList[index].ToString().Trim() == StartKey)
          {
            flag = true;
            if (AddStartEndKey)
              CalcList.Add(StartKey);
          }
        }
        else
        {
          if (AddStartEndKey)
            CalcList.Add(EndKey);
          break;
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"StartKey : {StartKey} - EndKey : {EndKey}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    List<string> RefList,
    ref ArrayList CalcList)
  {
    try
    {
      CalcList = new ArrayList();
      bool flag = false;
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].ToString().TrimStart();
        if (RefList[index].ToString().Length < 2 || !(RefList[index].ToString().Trim() == EndKey & flag))
        {
          if (flag)
            CalcList.Add((object) RefList[index].ToString());
          if (RefList[index].ToString().Trim() == StartKey)
          {
            flag = true;
            if (AddStartEndKey)
              CalcList.Add((object) StartKey);
          }
        }
        else
        {
          if (AddStartEndKey)
            CalcList.Add((object) EndKey);
          break;
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"StartKey : {StartKey} - EndKey : {EndKey}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ListToSpecificList(
    string StartKey,
    string EndKey,
    bool AddStartEndKey,
    List<string> RefList,
    ref List<List<string>> CalcList)
  {
    try
    {
      List<string> stringList = new List<string>();
      bool flag = false;
      CalcList = new List<List<string>>();
      for (int index = 0; index <= RefList.Count - 1; ++index)
      {
        if (flag)
          RefList[index] = RefList[index].Trim();
        if (RefList[index].Length >= 2 && RefList[index].Trim() == EndKey & flag)
        {
          if (AddStartEndKey)
            stringList.Add(EndKey);
          CalcList.Add(stringList);
          stringList = new List<string>();
          flag = false;
        }
        if (flag)
          stringList.Add(RefList[index]);
        if (RefList[index].Trim() == StartKey)
        {
          flag = true;
          if (AddStartEndKey)
            stringList.Add(StartKey);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"StartKey : {StartKey} - EndKey : {EndKey}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void AddFileToRecentFileList(
    string FileName,
    int MaxCount,
    ref ArrayList RecentFiles)
  {
    for (int index = 0; index <= RecentFiles.Count - 1; ++index)
    {
      if (RecentFiles[index].ToString() == FileName)
      {
        RecentFiles.RemoveAt(index);
        index = RecentFiles.Count;
      }
    }
    if (RecentFiles.Count > 0 && RecentFiles[0].ToString() != FileName)
      RecentFiles.Insert(0, (object) FileName);
    if (RecentFiles.Count == 0)
      RecentFiles.Add((object) FileName);
    if (RecentFiles.Count <= MaxCount)
      return;
    RecentFiles.RemoveRange(6, RecentFiles.Count - 6);
  }

  public static string StringListToString(List<string> SL)
  {
    StringBuilder stringBuilder = new StringBuilder();
    foreach (object obj in SL)
      stringBuilder.Append(obj);
    return stringBuilder.ToString();
  }

  public static string StringListToString(List<string> SL, bool NewLineEnable)
  {
    string str = "";
    for (int index = 0; index <= SL.Count - 1; ++index)
    {
      str += SL[index].ToString();
      if (index < SL.Count - 1)
        str = !NewLineEnable ? str + " " : str + Environment.NewLine;
    }
    return str;
  }

  public static string ArrayListToString(ArrayList AL)
  {
    StringBuilder stringBuilder = new StringBuilder();
    foreach (object obj in AL)
      stringBuilder.Append(obj);
    return stringBuilder.ToString();
  }

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
    buString.SplitStringByNewLine(RefString, ref Lines);
  }

  public static void StringToArrayByNewLine(string RefString, ref string[] Lines)
  {
    Lines = RefString.Split(new string[2]{ "\r\n", "\n" }, StringSplitOptions.None);
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

  public static void GetWarningInfo(
    List<string> WarningList,
    int WarningID,
    string WarningText,
    string WarningAxis,
    double WarningCode,
    int WarningOption,
    string WarningAux,
    ref string ResultWarning,
    ref AppWarning Wars)
  {
    try
    {
      string str1 = $"Axis [ {WarningAxis} ]";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      if (WarningCode != 0.0)
        str2 = " | Code = " + WarningCode.ToString();
      if (WarningOption != 0)
        str3 = " | Option = " + WarningOption.ToString();
      if (WarningAux.Trim().Length > 0)
        str4 = " | Aux = " + WarningAux;
      if (WarningAxis.Trim().ToLower() == "system")
        str1 = "System";
      string str5 = WarningAxis;
      string str6 = WarningText;
      if (WarningID <= WarningList.Count - 1)
      {
        str6 = WarningList[WarningID];
        ResultWarning = $"{str1}{WarningAxis} : {WarningList[WarningID]} - ID : {WarningID.ToString()}{str2}{str3}{str4}";
      }
      else
        ResultWarning = $"{str1}{WarningAxis} : {WarningText} - ID : {WarningID.ToString()}";
      Wars.Aux = str4;
      Wars.Axis = str5;
      Wars.Code = WarningCode;
      Wars.ID = WarningID;
      Wars.Option = WarningOption;
      Wars.Text = str6;
    }
    catch (Exception ex)
    {
      string str = $"WarningList : {WarningList.Count.ToString()} - WarningID : {WarningID.ToString()} - WarningText : {WarningText} - WarningAxis : {WarningAxis.ToString()} - WarningAux : {WarningAux.ToString()} - WarningCode : {WarningCode.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void GetAlarmInfo(
    List<string> AlarmList,
    int AlarmID,
    string AlarmText,
    string AlarmAxis,
    double AlarmCode,
    int AlarmOption,
    string AlarmAux,
    ref string ResultAlarm,
    ref AppAlarm Alrm)
  {
    try
    {
      string str1 = $"Axis [ {AlarmAxis} ]";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      if (AlarmCode != 0.0)
        str2 = " | Code = " + AlarmCode.ToString();
      if (AlarmOption != 0)
        str3 = " | Option = " + AlarmOption.ToString();
      if (AlarmAux.Trim().Length > 0)
        str4 = " | Aux = " + AlarmAux;
      if (AlarmAxis.Trim().ToLower() == "system")
        str1 = "System";
      string str5 = AlarmAxis;
      string str6 = AlarmText;
      if (AlarmID <= AlarmList.Count - 1)
      {
        str6 = AlarmList[AlarmID];
        ResultAlarm = $"{str1} : {AlarmList[AlarmID]} - ID = {AlarmID.ToString()}{str2}{str3}{str4}";
      }
      else
        ResultAlarm = $"{str1}{AlarmAxis} : {AlarmText} - ID = {AlarmID.ToString()}";
      Alrm.Aux = str4;
      Alrm.Axis = str5;
      Alrm.Code = AlarmCode;
      Alrm.ID = AlarmID;
      Alrm.Option = AlarmOption;
      Alrm.Text = str6;
    }
    catch (Exception ex)
    {
      string str = $"AlarmList : {AlarmList.Count.ToString()} - AlarmID : {AlarmID.ToString()} - AlarmText : {AlarmText} - AlarmAxis : {AlarmAxis.ToString()} - AlarmAux : {AlarmAux.ToString()} - AlarmCode : {AlarmCode.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static string SpaceChar(int Space) => new string(' ', Space);

  public static string StringFromBool(bool State, string TrueString, string FalseString)
  {
    return !State ? FalseString : TrueString;
  }

  public static string InchValueToString(double Value, int Base)
  {
    int int32_1 = Convert.ToInt32(buNumeric.RoundToLower(Value));
    double num = Value - (double) int32_1;
    int int32_2 = Convert.ToInt32((double) Base * num);
    return $"{int32_1.ToString()}\\{int32_2.ToString()}";
  }

  public static double StringToInchValue(string Value, int Base)
  {
    string[] strArray = Value.Split('\\');
    double inchValue;
    if (strArray != null)
    {
      if (strArray.Length == 1)
      {
        double result = 0.0;
        double.TryParse(strArray[0], out result);
        inchValue = result;
      }
      else if (strArray.Length == 2)
      {
        double result1 = 0.0;
        double result2 = 0.0;
        double.TryParse(strArray[0], out result1);
        double.TryParse(strArray[1], out result2);
        inchValue = result1 + result2 / 16.0;
      }
      else
        inchValue = 0.0;
    }
    else
      inchValue = 0.0;
    return inchValue;
  }

  public static string CharToString(int Unicode) => ((char) Unicode).ToString();

  public static void ReadCharValue(string FullLine, string Chr, ref double Value)
  {
    try
    {
      int num = FullLine.IndexOf(Chr);
      for (int startIndex = num + 1; startIndex <= FullLine.Length - 1; ++startIndex)
      {
        string str = FullLine.Substring(startIndex, 1);
        bool flag = false;
        if (buNumeric.IsNumeric(str))
          flag = true;
        if (!flag)
        {
          string s = FullLine.Substring(num + 1, startIndex - (num + 1));
          if (!buNumeric.IsNumeric(s))
            return;
          Value = double.Parse(s);
          return;
        }
      }
      string s1 = FullLine.Substring(num + 1, FullLine.Length - num - 1);
      if (!buNumeric.IsNumeric(s1))
        return;
      Value = double.Parse(s1);
    }
    catch (Exception ex)
    {
      string str = $"FullLine : {FullLine.ToString()}- Chr : {Chr.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static bool ReadStringValue(string Char, string Line, ref double Value)
  {
    int num = Line.IndexOf(Char);
    bool flag1;
    for (int startIndex = num + 1; startIndex <= Line.Length - 1; ++startIndex)
    {
      string str = Line.Substring(startIndex, 1);
      bool flag2;
      if (!(flag2 = buNumeric.IsNumeric(str)))
      {
        if (str == ".")
          flag2 = true;
        if (str == "-")
          flag2 = true;
      }
      if (!flag2)
      {
        string s = Line.Substring(num + 1, startIndex - (num + 1));
        if (buNumeric.IsNumeric(s))
        {
          Value = double.Parse(s);
          flag1 = true;
          goto label_15;
        }
        flag1 = false;
        goto label_15;
      }
    }
    string s1 = Line.Substring(num + 1, Line.Length - num - 1);
    if (buNumeric.IsNumeric(s1))
    {
      Value = double.Parse(s1);
      flag1 = true;
    }
    else
      flag1 = false;
label_15:
    return flag1;
  }

  public static bool ReadXYZFromString(
    string Line,
    bool XEnable,
    bool YEnable,
    bool ZEnable,
    ref Pnt3D Value)
  {
    string str = Line.ToLower().Replace(",", ".");
    int num1 = -1;
    int num2 = -1;
    int num3 = -1;
    if (XEnable)
    {
      num1 = str.IndexOf("x");
      if (num1 >= 0)
      {
        bool flag = false;
        for (int startIndex = num1 + 1; startIndex <= str.Length - 1; ++startIndex)
        {
          if (!buNumeric.IsCharBelongToNumerical(str.Substring(startIndex, 1)))
          {
            double.TryParse(str.Substring(num1 + 1, startIndex - num1), out Value.X);
            startIndex = str.Length;
          }
        }
        if (!flag)
          double.TryParse(str.Substring(num1 + 1, str.Length - 1 - num1), out Value.X);
      }
    }
    if (YEnable)
    {
      num2 = str.IndexOf("y");
      if (num2 >= 0)
      {
        bool flag = false;
        for (int startIndex = num2 + 1; startIndex <= str.Length - 1; ++startIndex)
        {
          if (!buNumeric.IsCharBelongToNumerical(str.Substring(startIndex, 1)))
          {
            double.TryParse(str.Substring(num2 + 1, startIndex - num2), out Value.Y);
            startIndex = str.Length;
            flag = true;
          }
        }
        if (!flag)
          double.TryParse(str.Substring(num2 + 1, str.Length - 1 - num2), out Value.Y);
      }
    }
    if (XEnable)
    {
      num3 = str.IndexOf("y");
      if (num3 >= 0)
      {
        bool flag = false;
        for (int startIndex = num3 + 1; startIndex <= str.Length - 1; ++startIndex)
        {
          if (!buNumeric.IsCharBelongToNumerical(str.Substring(startIndex, 1)))
          {
            double.TryParse(str.Substring(num3 + 1, startIndex - num3), out Value.Z);
            startIndex = str.Length;
            flag = true;
          }
        }
        if (!flag)
          double.TryParse(str.Substring(num3 + 1, str.Length - 1 - num3), out Value.Z);
      }
    }
    return !(num1 == -1 & num2 == -1 & num3 == -1);
  }

  public static void RemoveCharsFromString(bool Trim, bool Tab, ref List<string> Str)
  {
    for (int index = 0; index <= Str.Count - 1; ++index)
    {
      string Str1 = Str[index];
      buString.RemoveCharsFromString(Trim, Tab, new List<string>(), ref Str1);
      Str[index] = Str1;
    }
  }

  public static void RemoveCharsFromString(
    bool Trim,
    bool Tab,
    List<string> RemoveChars,
    ref List<string> Str)
  {
    for (int index = 0; index <= Str.Count - 1; ++index)
    {
      string Str1 = Str[index];
      buString.RemoveCharsFromString(Trim, Tab, RemoveChars, ref Str1);
      Str[index] = Str1;
    }
  }

  public static void RemoveCharsFromString(
    bool Trim,
    bool Tab,
    List<string> RemoveChars,
    ref string Str)
  {
    try
    {
      if (Trim)
        Str = Str.Trim();
      if (Tab)
        RemoveChars.Add("\t");
      if (RemoveChars.Count > 0)
      {
        for (int index = 0; index <= RemoveChars.Count - 1; ++index)
          Str = Str.Replace(RemoveChars[index], "");
      }
      if (!Trim)
        return;
      Str = Str.Trim();
    }
    catch (Exception ex)
    {
      string str = $"Trim : {Trim.ToString()}- Tab : {Tab.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static string SetDialogFileExtensionFilters(ArrayList ExtensionList)
  {
    try
    {
      string str = "";
      for (int index = 0; index <= ExtensionList.Count - 1; ++index)
        str = index != 0 ? $"{str}|{ExtensionList[index].ToString()}" : ExtensionList[index].ToString();
      return str;
    }
    catch (Exception ex)
    {
      string str = "ExtensionList : " + ExtensionList.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static string DecimalString(int Decimal)
  {
    try
    {
      return Decimal >= 0 ? "f" + Decimal.ToString() : "f0";
    }
    catch (Exception ex)
    {
      string str = "Decimal : " + Decimal.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }
}
