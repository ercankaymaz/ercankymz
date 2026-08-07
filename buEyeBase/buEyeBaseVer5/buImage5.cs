// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buImage5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

#nullable disable
namespace buEyeBaseVer5;

public class buImage5
{
  public static byte f0008FC;
  public int OriginalGCodeLineCount;

  public static Font UpdateFontStyle(
    Font refFont,
    bool Bold,
    bool Italic,
    bool Undeline,
    bool StrikeOut)
  {
    try
    {
      FontStyle style = FontStyle.Regular;
      if (Bold)
        style |= FontStyle.Bold;
      if (Undeline)
        style |= FontStyle.Underline;
      if (Italic)
        style |= FontStyle.Italic;
      if (StrikeOut)
        style |= FontStyle.Strikeout;
      refFont = new Font(refFont.Name, refFont.Size, style);
      return refFont;
    }
    catch (Exception ex)
    {
      return refFont;
    }
  }

  public static Font UpdateFontStyle(
    Font refFont,
    double Size,
    bool Bold,
    bool Italic,
    bool Undeline,
    bool StrikeOut)
  {
    try
    {
      FontStyle style = FontStyle.Regular;
      if (Bold)
        style |= FontStyle.Bold;
      if (Undeline)
        style |= FontStyle.Underline;
      if (Italic)
        style |= FontStyle.Italic;
      if (StrikeOut)
        style |= FontStyle.Strikeout;
      float emSize = (float) Size;
      if ((double) emSize <= 0.0)
        emSize = refFont.Size;
      refFont = new Font(refFont.Name, emSize, style);
      return refFont;
    }
    catch (Exception ex)
    {
      return refFont;
    }
  }

  public static Font GetFontFromName(string fontName, double Size, bool Bold)
  {
    float emSize = (float) Size;
    string familyName = fontName;
    if (familyName.Trim().Length <= 0)
      familyName = "Microsoft Sans Serif";
    if ((double) emSize <= 0.0)
      emSize = 10f;
    try
    {
      FontStyle style = FontStyle.Regular;
      if (Bold)
        style |= FontStyle.Bold;
      return new Font(familyName, emSize, style);
    }
    catch (Exception ex)
    {
      return new Font("Microsoft Sans Serif", emSize);
    }
  }

  public static Font GetFontFromName(
    string fontName,
    double Size,
    bool Bold,
    bool Italic,
    bool Undeline,
    bool StrikeOut)
  {
    float emSize = (float) Size;
    string familyName = fontName;
    if (familyName.Trim().Length <= 0)
      familyName = "Microsoft Sans Serif";
    if ((double) emSize <= 0.0)
      emSize = 10f;
    try
    {
      FontStyle style = FontStyle.Regular;
      if (Bold)
        style |= FontStyle.Bold;
      if (Undeline)
        style |= FontStyle.Underline;
      if (Italic)
        style |= FontStyle.Italic;
      if (StrikeOut)
        style |= FontStyle.Strikeout;
      return new Font(familyName, emSize, style);
    }
    catch (Exception ex)
    {
      return new Font("Microsoft Sans Serif", emSize);
    }
  }

  public static string StringArrayToStringByIndex(string[] strArr, int Index, bool Trim = true)
  {
    return strArr != null ? (strArr.Length != 0 ? (Index <= strArr.Length ? (Index > strArr.Length ? "" : (strArr[Index] == null ? "" : (Trim ? strArr[Index].Trim() : strArr[Index]))) : "") : "") : "";
  }

  public static void GetLanguageItem(List<string> LanguageList, int Index, ref string refItem)
  {
    if (Index >= 0 & Index <= LanguageList.Count - 1)
      refItem = LanguageList[Index];
    else
      refItem = "_" + refItem;
  }

  public static string GetAlfabetLetter(int index)
  {
    string str1 = "";
    char ch;
    if (index >= "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length)
    {
      string str2 = str1;
      ch = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[index / "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length - 1];
      string str3 = ch.ToString();
      str1 = str2 + str3;
    }
    string str4 = str1;
    ch = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[index % "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length];
    string str5 = ch.ToString();
    return str4 + str5;
  }

  public static string GetLetterFromAscii(int AsciiNumber) => ((char) AsciiNumber).ToString();

  public static void ReadStringValue(
    string Line,
    string Paramater,
    ref string Value,
    string EqualChar = "=")
  {
    try
    {
      string[] strArray = Line.Split(Convert.ToChar(EqualChar));
      if (strArray == null)
        return;
      if (strArray.Length == 2)
        Value = strArray[1].Trim();
      if (strArray.Length <= 2)
        return;
      Value = "";
      for (int index = 1; index <= strArray.Length - 1; ++index)
      {
        string str = strArray[index].Trim();
        if (index > 1)
          str = "=" + str;
        if (str.Length == 0)
          str = "=";
        Value += str;
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static void ReadStringValue(
    string Line,
    string Paramater,
    ref double Value,
    string EqualChar = "=")
  {
    try
    {
      string s = "";
      string[] strArray = Line.Split(Convert.ToChar(EqualChar));
      if (strArray == null)
        return;
      if (strArray.Length == 2)
        s = strArray[1].Trim();
      if (strArray.Length > 2)
      {
        s = "";
        for (int index = 1; index <= strArray.Length - 1; ++index)
        {
          string str = strArray[index].Trim();
          if (index > 1)
            str = "=" + str;
          if (str.Length == 0)
            str = "=";
          s += str;
        }
      }
      if (s.Length <= 0)
        return;
      double.TryParse(s, out Value);
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public static bool ReadCharValue(string FullLine, string Chr, ref double Value)
  {
    try
    {
      int num = FullLine.IndexOf(Chr);
      int length = Chr.Length;
      for (int startIndex = num + length; startIndex <= FullLine.Length - 1; ++startIndex)
      {
        string str = FullLine.Substring(startIndex, 1);
        bool flag = false;
        if (buFile5.IsNumeric(str))
          flag = true;
        if (!flag & (str == "." | str == "-"))
          flag = true;
        if (!flag)
        {
          string s = FullLine.Substring(num + 1, startIndex - (num + 1));
          if (!buFile5.IsNumeric(s))
            return false;
          Value = double.Parse(s);
          return true;
        }
      }
      string s1 = FullLine.Substring(num + length, FullLine.Length - num - length);
      if (!buFile5.IsNumeric(s1))
        return false;
      Value = double.Parse(s1);
      return true;
    }
    catch (Exception ex)
    {
      string str = $"FullLine : {FullLine.ToString()}- Chr : {Chr.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public static bool ReadStringValue(string Char, string Line, ref double Value)
  {
    int num = Line.ToLower().IndexOf(Char.ToLower());
    bool flag1;
    if (num < 0)
    {
      flag1 = false;
    }
    else
    {
      for (int startIndex = num + 1; startIndex <= Line.Length - 1; ++startIndex)
      {
        string str = Line.Substring(startIndex, 1);
        bool flag2;
        if (!(flag2 = buFile5.IsNumeric(str)))
        {
          if (str == ".")
            flag2 = true;
          if (str == "-")
            flag2 = true;
        }
        if (!flag2)
        {
          string s = Line.Substring(num + 1, startIndex - (num + 1));
          if (buFile5.IsNumeric(s))
          {
            Value = double.Parse(s);
            flag1 = true;
            goto label_17;
          }
          flag1 = false;
          goto label_17;
        }
      }
      string s1 = Line.Substring(num + 1, Line.Length - num - 1);
      if (buFile5.IsNumeric(s1))
      {
        Value = double.Parse(s1);
        flag1 = true;
      }
      else
        flag1 = false;
    }
label_17:
    return flag1;
  }

  public static bool ReadXYZFromString(
    string Line,
    bool XEnable,
    bool YEnable,
    bool ZEnable,
    ref Point3D Value)
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
          if (!buFile5.IsCharBelongToNumerical(str.Substring(startIndex, 1)))
          {
            double.TryParse(str.Substring(num1 + 1, startIndex - num1), out Value.X);
            startIndex = str.Length;
            flag = true;
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
          if (!buFile5.IsCharBelongToNumerical(str.Substring(startIndex, 1)))
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
    if (ZEnable)
    {
      num3 = str.IndexOf("z");
      if (num3 >= 0)
      {
        bool flag = false;
        for (int startIndex = num3 + 1; startIndex <= str.Length - 1; ++startIndex)
        {
          if (!buFile5.IsCharBelongToNumerical(str.Substring(startIndex, 1)))
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

  public static void RemoveLastNewLineFromString(ref string Str)
  {
    Str = Str.ToString().TrimEnd(Environment.NewLine.ToCharArray());
  }

  public static string RemoveLastNewLineFromString(string Str)
  {
    return Str.ToString().TrimEnd(Environment.NewLine.ToCharArray());
  }

  public static void RemoveCharsFromString(bool Trim, bool Tab, ref List<string> Str)
  {
    for (int index = 0; index <= Str.Count - 1; ++index)
    {
      string Str1 = Str[index];
      buImage5.RemoveCharsFromString(Trim, Tab, new List<string>(), ref Str1);
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
      buImage5.RemoveCharsFromString(Trim, Tab, RemoveChars, ref Str1);
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

  public static string SpaceChar(int Space) => new string(' ', Space);

  public static string DefItem(
    string strBase,
    object Value,
    string Decimal = "f2",
    string SeperastorPre = " , ",
    string ValEqual = ": ",
    string SeperatorNext = "")
  {
    string str = SeperastorPre + strBase + ValEqual;
    return (!(Value.GetType() == typeof (double)) ? (!(Value.GetType() == typeof (Decimal)) ? (!(Value.GetType() == typeof (float)) ? str + Value.ToString() : str + ((float) Value).ToString(Decimal)) : str + ((Decimal) Value).ToString(Decimal)) : str + ((double) Value).ToString(Decimal)) + SeperatorNext;
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
}
