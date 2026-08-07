// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buCompare5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Foam;
using buEyeBaseVer5.Forms.Holes;
using buEyeBaseVer5.Forms.KeyPad;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class buCompare5
{
  public Pnt9D Positions;
  public double Radius;

  public buCompare5(
    SortingIntersectionRulesType intersectionRules,
    SortingNextGroupFindRulesType nextFroupRules,
    double sortResolution,
    ClockDirectionType clockDirection,
    ClockDirectionType insideClockDirection)
  {
    ((buGCodeCreate) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((buGCodeCreate) this).NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((buGCodeCreate) this).SortResolution = 0.05;
    ((buGCodeCreate) this).ClockDirection = ClockDirectionType.CCW;
    ((buGCodeCreate) this).InsideClockDirection = ClockDirectionType.CCW;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((buGCodeCreate) this).IntersectionRules = intersectionRules;
    ((buGCodeCreate) this).NextFroupRules = nextFroupRules;
    ((buGCodeCreate) this).SortResolution = sortResolution;
    ((buGCodeCreate) this).ClockDirection = clockDirection;
    ((buGCodeCreate) this).InsideClockDirection = insideClockDirection;
  }

  public buCompare5(FindEntitiesGroupSettings data)
  {
    ((buGCodeCreate) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((buGCodeCreate) this).NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((buGCodeCreate) this).SortResolution = 0.05;
    ((buGCodeCreate) this).ClockDirection = ClockDirectionType.CCW;
    ((buGCodeCreate) this).InsideClockDirection = ClockDirectionType.CCW;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString() => ((buGCodeCreate) this).ClockDirection.ToString();

  public buCompare5()
  {
    ((buGCodeCreate) this).DiameterMin = 0.0;
    ((buGCodeCreate) this).DiameterMax = 500.0;
    ((buGCodeCreate) this).DevideLength = 10.0;
    ((SerilizationMode5) this).RegenDeviation = 0.1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buCompare5(
    double diameterMin,
    double diameterMax,
    double devideLength,
    double regenDeviation)
  {
    ((buGCodeCreate) this).DiameterMin = 0.0;
    ((buGCodeCreate) this).DiameterMax = 500.0;
    ((buGCodeCreate) this).DevideLength = 10.0;
    ((SerilizationMode5) this).RegenDeviation = 0.1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((buGCodeCreate) this).DiameterMax = diameterMax;
    ((buGCodeCreate) this).DiameterMin = diameterMin;
    ((buGCodeCreate) this).DevideLength = devideLength;
    ((SerilizationMode5) this).RegenDeviation = regenDeviation;
  }

  public buCompare5(GeometryTableItem data)
  {
    ((buGCodeCreate) this).DiameterMin = 0.0;
    ((buGCodeCreate) this).DiameterMax = 500.0;
    ((buGCodeCreate) this).DevideLength = 10.0;
    ((SerilizationMode5) this).RegenDeviation = 0.1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"DiameterMin: {((buGCodeCreate) this).DiameterMin.ToString()} - DiameterMax: {((buGCodeCreate) this).DiameterMax.ToString()} - DevideLength: {((buGCodeCreate) this).DevideLength.ToString()} - RegenDeviation: {((SerilizationMode5) this).RegenDeviation.ToString()}";
  }

  public abstract void m0003BB();

  public buCompare5()
  {
    ((SerilizationMode5) this).MinDiameter = 0.0;
    ((SerilizationMode5) this).MaxDiameter = 500.0;
    ((cParameter5) this).Persentage = 100.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buCompare5(double mindiameter, double maxdiameter, double persentage)
  {
    ((SerilizationMode5) this).MinDiameter = 0.0;
    ((SerilizationMode5) this).MaxDiameter = 500.0;
    ((cParameter5) this).Persentage = 100.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((SerilizationMode5) this).MinDiameter = mindiameter;
    ((SerilizationMode5) this).MaxDiameter = maxdiameter;
    ((cParameter5) this).Persentage = persentage;
  }

  public buCompare5(CircularSpeedReduction data)
  {
    ((SerilizationMode5) this).MinDiameter = 0.0;
    ((SerilizationMode5) this).MaxDiameter = 500.0;
    ((cParameter5) this).Persentage = 100.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public static void GetPersentage(
    List<CircularSpeedReduction> SpeedList,
    double Diameter,
    ref double FoundPersentage)
  {
    if (SpeedList.Count > 0)
    {
      FoundPersentage = 100.0;
      for (int index = 0; index <= SpeedList.Count - 1; ++index)
      {
        if ((Diameter < ((SerilizationMode5) SpeedList[index]).MinDiameter ? 0 : (Diameter <= ((SerilizationMode5) SpeedList[index]).MaxDiameter ? 1 : 0)) != 0)
        {
          FoundPersentage = ((cParameter5) SpeedList[index]).Persentage;
          index = SpeedList.Count;
        }
      }
    }
    else
      FoundPersentage = 100.0;
  }

  public override string ToString()
  {
    return $"MinDiameter: {((SerilizationMode5) this).MinDiameter.ToString()} - MaxDiameter: {((SerilizationMode5) this).MaxDiameter.ToString()} - Persentage: {((cParameter5) this).Persentage.ToString()}";
  }

  public abstract void m0003C1();

  public buCompare5()
  {
    ((cParameter5) this).FoundAngle = 0.0;
    ((cParameter5) this).Outside = false;
    ((cParameter5) this).pntPick = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public override string ToString()
  {
    return $"FoundAngle: {((cParameter5) this).FoundAngle.ToString()} - Outside: {((cParameter5) this).Outside.ToString()} - pntPick: {((cParameter5) this).pntPick.ToString()}";
  }

  public abstract void m0003C4();

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

  public static string getCpuID(ref List<string> CpuAddress)
  {
    string cpuId = "";
    try
    {
      foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("Select ProcessorID From Win32_processor").Get())
      {
        cpuId = managementBaseObject["ProcessorID"].ToString();
        CpuAddress.Add(cpuId);
      }
      return cpuId;
    }
    catch (Exception ex)
    {
      return cpuId;
    }
  }

  public static string getHddID(ref List<string> HddAddress)
  {
    ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
    HddAddress.Clear();
    foreach (ManagementObject managementObject in managementObjectSearcher.Get())
    {
      if (managementObject["SerialNumber"] != null)
      {
        string str = managementObject["SerialNumber"].ToString();
        HddAddress.Add(str);
      }
    }
    return "";
  }

  public static void getMacAddress(ref List<string> MacAddress)
  {
    MacAddress.Clear();
    NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
    for (int index = 0; index <= networkInterfaces.Length - 1; ++index)
    {
      string str = networkInterfaces[index].GetPhysicalAddress().ToString();
      if (str.Length == 12 & (networkInterfaces[index].NetworkInterfaceType == NetworkInterfaceType.Ethernet | networkInterfaces[index].NetworkInterfaceType == NetworkInterfaceType.Wireless80211) && str.Substring(0, 4) != "0000")
        MacAddress.Add(str);
    }
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

  public static void ExchangeDatas(ref Point3D FirstData, ref Point3D SecondData)
  {
    try
    {
      Point3D point3D = new Point3D(FirstData.X, FirstData.Y, FirstData.Z);
      FirstData = new Point3D(SecondData.X, SecondData.Y, SecondData.Z);
      SecondData = new Point3D(point3D.X, point3D.Y, point3D.Z);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
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

  public static void GetEnumTypeValues(object EnumType, ref List<string> EnumItems)
  {
    try
    {
      if (EnumType == null || !EnumType.GetType().IsEnum)
        return;
      Array values = Enum.GetValues(EnumType.GetType());
      EnumItems.Clear();
      for (int index = 0; index <= values.Length - 1; ++index)
        EnumItems.Add(values.GetValue(index).ToString());
    }
    catch (Exception ex)
    {
      string str = "EnumType : " + EnumType?.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void ComboboxAddItem(ArrayList Items, int SelectedIndex, ref ComboBox Combobox)
  {
    if (Items.Count <= 0)
      return;
    Combobox.Items.Clear();
    for (int index = 0; index <= Items.Count - 1; ++index)
      Combobox.Items.Add(Items[index]);
    if (SelectedIndex >= 0 & SelectedIndex <= Items.Count - 1)
      Combobox.SelectedIndex = SelectedIndex;
    else
      Combobox.SelectedIndex = 0;
  }

  public static double GetDPIScale()
  {
    double dpiScale = 1.0;
    using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\FontDPI"))
    {
      if (registryKey != null)
      {
        object obj = registryKey.GetValue("LogPixels");
        if (obj != null)
          dpiScale = (double) (int) obj / 96.0;
      }
    }
    return dpiScale;
  }

  public static void ShowKeyPad(
    Form Parent,
    Control Ctrl,
    string VarName = "",
    int Version = 1,
    string passchar = "")
  {
    try
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      string s = " ";
      if (passchar.Length == 0)
        s = passchar;
      if (Ctrl == null)
      {
        buNumeric5.MessageBoxWarning("Null Control");
      }
      else
      {
        if (Ctrl.GetType() == typeof (buTextBox))
        {
          flag2 = true;
          flag3 = true;
        }
        if (Ctrl.GetType() == typeof (TextBox))
          flag2 = true;
        if (Ctrl.GetType().BaseType == typeof (TextBox))
          flag2 = true;
        if (Ctrl.GetType() == typeof (buSpin))
        {
          flag1 = true;
          flag3 = true;
        }
        if (Ctrl.GetType() == typeof (NumericUpDown))
          flag1 = true;
        if (Ctrl.GetType().BaseType == typeof (NumericUpDown))
          flag1 = true;
        if (flag1 && Version == 1)
        {
          F_KeyPadNumV1 fKeyPadNumV1 = (F_KeyPadNumV1) new F_FoamSlicesList();
          ((F_HolesTemp) fKeyPadNumV1).Caption = VarName;
          if (s.Length > 0)
          {
            ((F_HolesTemp) fKeyPadNumV1).textCtrl1.PasswordChar = char.Parse(s);
            ((F_HolesTemp) fKeyPadNumV1).PasswordChar = char.Parse(s);
          }
          fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
          ((F_FoamSlicesList) fKeyPadNumV1).ShowDialog(((buSpin) Ctrl).Value.ToString(), (IWin32Window) Parent);
          if (flag3)
          {
            ((buSpin) Ctrl).Value = double.Parse(((F_HolesTemp) fKeyPadNumV1).Value);
            ((buSpin) Ctrl).CursorToEnd();
          }
          else
          {
            ((NumericUpDown) Ctrl).Value = Decimal.Parse(((F_HolesTemp) fKeyPadNumV1).Value);
            ((UpDownBase) Ctrl).Select(0, 100);
          }
        }
        if (!flag2 || Version != 1)
          return;
        F_KeyPadCharV1 fKeyPadCharV1 = (F_KeyPadCharV1) new F_FoamSpeedList();
        ((F_HolesTemp) fKeyPadCharV1).Caption = VarName;
        if (s.Length > 0)
        {
          ((F_HolesTemp) fKeyPadCharV1).textCtrl1.PasswordChar = char.Parse(s);
          ((F_HolesTemp) fKeyPadCharV1).PasswordChar = char.Parse(s);
        }
        fKeyPadCharV1.StartPosition = FormStartPosition.CenterParent;
        ((F_FoamSpeedList) fKeyPadCharV1).ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
        if (flag3)
        {
          Ctrl.Text = ((F_HolesTemp) fKeyPadCharV1).Value;
          ((buTextBox) Ctrl).CursorToEnd();
        }
        else
        {
          Ctrl.Text = ((F_HolesTemp) fKeyPadCharV1).Value;
          ((TextBoxBase) Ctrl).Select(0, 500);
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static void ShowKeyPad(
    Form Parent,
    Control Ctrl,
    ref string Value,
    string VarName = "",
    int Version = 1,
    string passchar = "")
  {
    try
    {
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      string s = " ";
      if (passchar.Length == 0)
        s = passchar;
      if (Ctrl == null)
      {
        F_KeyPadNumV1 fKeyPadNumV1 = (F_KeyPadNumV1) new F_FoamSlicesList();
        ((F_HolesTemp) fKeyPadNumV1).Caption = VarName;
        if (s.Length > 0)
        {
          ((F_HolesTemp) fKeyPadNumV1).textCtrl1.PasswordChar = char.Parse(s);
          ((F_HolesTemp) fKeyPadNumV1).PasswordChar = char.Parse(s);
        }
        fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
        ((F_FoamSlicesList) fKeyPadNumV1).ShowDialog(Value, (IWin32Window) Parent);
        Value = ((F_HolesTemp) fKeyPadNumV1).Value;
      }
      else
      {
        if (Ctrl.GetType() == typeof (buTextBox))
        {
          flag2 = true;
          flag3 = true;
        }
        if (Ctrl.GetType() == typeof (TextBox))
          flag2 = true;
        if (Ctrl.GetType().BaseType == typeof (TextBox))
          flag2 = true;
        if (Ctrl.GetType() == typeof (buSpin))
        {
          flag1 = true;
          flag3 = true;
        }
        if (Ctrl.GetType() == typeof (NumericUpDown))
          flag1 = true;
        if (Ctrl.GetType().BaseType == typeof (NumericUpDown))
          flag1 = true;
        if (flag1 && Version == 1)
        {
          F_KeyPadNumV1 fKeyPadNumV1 = (F_KeyPadNumV1) new F_FoamSlicesList();
          ((F_HolesTemp) fKeyPadNumV1).Caption = VarName;
          if (s.Length > 0)
          {
            ((F_HolesTemp) fKeyPadNumV1).textCtrl1.PasswordChar = char.Parse(s);
            ((F_HolesTemp) fKeyPadNumV1).PasswordChar = char.Parse(s);
          }
          fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
          ((F_FoamSlicesList) fKeyPadNumV1).ShowDialog(((buSpin) Ctrl).Value.ToString(), (IWin32Window) Parent);
          if (flag3)
          {
            ((buSpin) Ctrl).Value = double.Parse(((F_HolesTemp) fKeyPadNumV1).Value);
            ((buSpin) Ctrl).CursorToEnd();
          }
          else
          {
            ((NumericUpDown) Ctrl).Value = Decimal.Parse(((F_HolesTemp) fKeyPadNumV1).Value);
            ((UpDownBase) Ctrl).Select(0, 100);
          }
        }
        if (!flag2 || Version != 1)
          return;
        F_KeyPadCharV1 fKeyPadCharV1 = (F_KeyPadCharV1) new F_FoamSpeedList();
        ((F_HolesTemp) fKeyPadCharV1).Caption = VarName;
        if (s.Length > 0)
        {
          ((F_HolesTemp) fKeyPadCharV1).textCtrl1.PasswordChar = char.Parse(s);
          ((F_HolesTemp) fKeyPadCharV1).PasswordChar = char.Parse(s);
        }
        fKeyPadCharV1.StartPosition = FormStartPosition.CenterParent;
        ((F_FoamSpeedList) fKeyPadCharV1).ShowDialog(Ctrl.Text.ToString(), (IWin32Window) Parent);
        if (flag3)
        {
          Ctrl.Text = ((F_HolesTemp) fKeyPadCharV1).Value;
          ((buTextBox) Ctrl).CursorToEnd();
        }
        else
        {
          Ctrl.Text = ((F_HolesTemp) fKeyPadCharV1).Value;
          ((TextBoxBase) Ctrl).Select(0, 500);
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, "");
    }
  }

  public static void ShotDownPC()
  {
    if (buNumeric5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWanttoClosePC) != DialogResult.Yes)
      return;
    Process.Start(new ProcessStartInfo("shutdown", "/s /t 0")
    {
      CreateNoWindow = true,
      UseShellExecute = false
    });
  }

  public static string GetDateAsString()
  {
    DateTime dateTime1 = DateTime.Now;
    dateTime1 = dateTime1.Date;
    int num = dateTime1.Year;
    string str1 = num.ToString("D4");
    DateTime dateTime2 = DateTime.Now;
    dateTime2 = dateTime2.Date;
    num = dateTime2.Month;
    string str2 = num.ToString("D2");
    DateTime dateTime3 = DateTime.Now;
    dateTime3 = dateTime3.Date;
    num = dateTime3.Day;
    string str3 = num.ToString("D2");
    return str1 + str2 + str3;
  }

  public static string GetTimeAsString()
  {
    int num = DateTime.Now.Hour;
    string str1 = num.ToString("D2");
    num = DateTime.Now.Minute;
    string str2 = num.ToString("D2");
    num = DateTime.Now.Second;
    string str3 = num.ToString("D2");
    return str1 + str2 + str3;
  }

  public buCompare5()
  {
  }

  public abstract void m0003DA();

  public buCompare5()
  {
    ((buVector5) this).\u0001 = new List<Entity>();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
