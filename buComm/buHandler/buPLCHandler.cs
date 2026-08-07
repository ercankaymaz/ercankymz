// Decompiled with JetBrains decompiler
// Type: buHandler.buPLCHandler
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using \u0005;
using buClass;
using buCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace buHandler;

public class buPLCHandler
{
  private static bool \u0001 = false;
  public static string DeviceIP = "192.168.10.50";
  public static string DeviceAddress = "0";
  public static string DeviceName = "CMD";
  public static bool isConnect = false;
  public static int ThreatCount = 0;
  public static bool ThreadEnable = true;
  public static int ThreadWaitCount = 0;
  public static List<string> ErrorList = new List<string>();
  public static int PLCStatus = 0;

  public buPLCHandler()
  {
    if (!buPLCHandler.\u0001(nameof (buPLCHandler)))
    {
      buPLCHandler.\u0001 = false;
      throw new RegisterException(nameof (buPLCHandler));
    }
    buPLCHandler.\u0001 = true;
  }

  internal static bool \u0001([In] string obj0)
  {
    try
    {
      if (!(buVector.AskMeResult != "TesxCEguItdxXery89+dxdx+456(9004dxXXx5678X4Dfgytex &7fdxHRewxWw2" | buVector.AskMeValue != -5861345679435.9121))
        return true;
      BinaryReader binaryReader = (BinaryReader) null;
      try
      {
        FileInfo fileInfo = new FileInfo(AppPath.Base + "\\mnbucfd.dll");
        if (!fileInfo.Exists)
          throw new RegisterException(obj0);
        if (fileInfo.Exists)
        {
          List<double> doubleList = new List<double>();
          List<string> stringList1 = new List<string>();
          List<string> stringList2 = new List<string>();
          bool flag1;
          bool flag2;
          try
          {
            buLogVer5.addToLog("DefK", "Mode 14100", "mnb", "1", 0.0, 0.0);
            binaryReader = new BinaryReader((Stream) new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None));
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = "";
            string str14 = "";
            Decimal num1 = 0M;
            for (int index = 0; index < 755; ++index)
            {
              double num2 = (double) binaryReader.ReadSingle();
            }
            for (int index = 0; index < 1274; ++index)
              binaryReader.ReadDouble();
            for (int index = 0; index < 1498; ++index)
              num1 = binaryReader.ReadDecimal();
            for (int index = 0; index < 5614; ++index)
            {
              double num3 = (double) binaryReader.ReadInt32();
            }
            for (int index = 0; index < 4243; ++index)
            {
              double num4 = (double) binaryReader.ReadSingle();
            }
            for (int index = 0; index < 9867; ++index)
              binaryReader.ReadDouble();
            for (int index = 0; index < 3886; ++index)
              num1 = binaryReader.ReadDecimal();
            for (int index = 0; index < 5765; ++index)
            {
              double num5 = (double) binaryReader.ReadInt32();
            }
            int num6 = binaryReader.ReadInt32();
            doubleList.Clear();
            stringList1.Clear();
            stringList2.Clear();
            char ch;
            for (int index1 = 0; index1 <= num6 - 1; ++index1)
            {
              double num7 = binaryReader.ReadDouble() / 65.87;
              doubleList.Add(num7);
              int num8 = binaryReader.ReadInt32();
              string str15 = "";
              for (int index2 = 0; index2 < num8; ++index2)
              {
                byte num9 = Convert.ToByte(binaryReader.ReadDouble() / 46.8613);
                string str16 = str15;
                ch = Convert.ToChar(num9);
                string str17 = ch.ToString();
                str15 = str16 + str17;
              }
              stringList1.Add(str15);
              int num10 = binaryReader.ReadInt32();
              string str18 = "";
              for (int index3 = 0; index3 < num10; ++index3)
              {
                byte num11 = Convert.ToByte(binaryReader.ReadDouble() / 86.3456);
                string str19 = str18;
                ch = Convert.ToChar(num11);
                string str20 = ch.ToString();
                str18 = str19 + str20;
              }
              stringList2.Add(str18);
            }
            int num12 = binaryReader.ReadInt32();
            for (int index = 0; index < num12; ++index)
            {
              byte num13 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str21 = str1;
              ch = Convert.ToChar(num13);
              string str22 = ch.ToString();
              str1 = str21 + str22;
            }
            int num14 = binaryReader.ReadInt32();
            for (int index = 0; index < num14; ++index)
            {
              byte num15 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str23 = str2;
              ch = Convert.ToChar(num15);
              string str24 = ch.ToString();
              str2 = str23 + str24;
            }
            int num16 = binaryReader.ReadInt32();
            for (int index = 0; index < num16; ++index)
            {
              byte num17 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str25 = str3;
              ch = Convert.ToChar(num17);
              string str26 = ch.ToString();
              str3 = str25 + str26;
            }
            int num18 = binaryReader.ReadInt32();
            for (int index = 0; index < num18; ++index)
            {
              byte num19 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str27 = str4;
              ch = Convert.ToChar(num19);
              string str28 = ch.ToString();
              str4 = str27 + str28;
            }
            int num20 = binaryReader.ReadInt32();
            for (int index = 0; index < num20; ++index)
            {
              byte num21 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str29 = str5;
              ch = Convert.ToChar(num21);
              string str30 = ch.ToString();
              str5 = str29 + str30;
            }
            int num22 = binaryReader.ReadInt32();
            for (int index = 0; index < num22; ++index)
            {
              byte num23 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str31 = str6;
              ch = Convert.ToChar(num23);
              string str32 = ch.ToString();
              str6 = str31 + str32;
            }
            int num24 = binaryReader.ReadInt32();
            for (int index = 0; index < num24; ++index)
            {
              byte num25 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str33 = str7;
              ch = Convert.ToChar(num25);
              string str34 = ch.ToString();
              str7 = str33 + str34;
            }
            int num26 = binaryReader.ReadInt32();
            for (int index = 0; index < num26; ++index)
            {
              byte num27 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str35 = str8;
              ch = Convert.ToChar(num27);
              string str36 = ch.ToString();
              str8 = str35 + str36;
            }
            int num28 = binaryReader.ReadInt32();
            for (int index = 0; index < num28; ++index)
            {
              byte num29 = Convert.ToByte(binaryReader.ReadDouble() / 54.3685);
              string str37 = str9;
              ch = Convert.ToChar(num29);
              string str38 = ch.ToString();
              str9 = str37 + str38;
            }
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            int num30 = binaryReader.ReadInt32();
            for (int index = 0; index < num30; ++index)
            {
              byte num31 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              string str39 = str10;
              ch = Convert.ToChar(num31);
              string str40 = ch.ToString();
              str10 = str39 + str40;
            }
            int num32 = binaryReader.ReadInt32();
            for (int index = 0; index < num32; ++index)
            {
              byte num33 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              string str41 = str11;
              ch = Convert.ToChar(num33);
              string str42 = ch.ToString();
              str11 = str41 + str42;
            }
            int num34 = binaryReader.ReadInt32();
            for (int index = 0; index < num34; ++index)
            {
              byte num35 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              string str43 = str12;
              ch = Convert.ToChar(num35);
              string str44 = ch.ToString();
              str12 = str43 + str44;
            }
            int num36 = binaryReader.ReadInt32();
            for (int index = 0; index < num36; ++index)
            {
              byte num37 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              string str45 = str13;
              ch = Convert.ToChar(num37);
              string str46 = ch.ToString();
              str13 = str45 + str46;
            }
            int num38 = binaryReader.ReadInt32();
            for (int index = 0; index < num38; ++index)
            {
              byte num39 = Convert.ToByte(binaryReader.ReadDouble() / 64.3685);
              string str47 = str14;
              ch = Convert.ToChar(num39);
              string str48 = ch.ToString();
              str14 = str47 + str48;
            }
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            flag1 = binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            flag2 = binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadBoolean();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.ReadDouble();
            binaryReader.Close();
            buLogVer5.addToLog("DefK", "Mode 14101", "mnb", "100", 0.0, 0.0);
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(ex.Message);
            binaryReader.Close();
            throw new RegisterException(obj0);
          }
          List<string> MacAddress = new List<string>();
          List<string> CpuAddress = new List<string>();
          string MBAddress = "";
          buVector.getMacAddress(ref MacAddress);
          buLogVer5.addToLog("DefK", "Mode 14102", "mnb", "100", 0.0, 0.0);
          buVector.getCpuID(ref CpuAddress);
          buLogVer5.addToLog("DefK", "Mode 14103", "mnb", "100", 0.0, 0.0);
          buVector.GetMotherBoardID(ref MBAddress);
          buLogVer5.addToLog("DefK", "Mode 14104", "mnb", "100", 0.0, 0.0);
          if (!flag1 & !flag2)
          {
            bool flag3 = \u0004.\u0001(obj0, CpuAddress, doubleList, MacAddress, MBAddress);
            buLogVer5.addToLog("DefK", "Mode 14104", "mnb", "100", 0.0, 0.0);
            if (flag3)
              return true;
          }
          throw new RegisterException(obj0);
        }
        throw new RegisterException(obj0);
      }
      catch (Exception ex)
      {
        throw new RegisterException(obj0);
      }
    }
    catch (Exception ex)
    {
      throw new RegisterException(obj0);
    }
  }

  public static event buPLCHandler.PLCHandlerCommError CommError;

  public static unsafe void ConnectPLC(bool ByIP)
  {
    if (!buPLCHandler.\u0001)
    {
      int num1 = (int) MessageBox.Show("Not Inited");
    }
    else
    {
      if (!(!buPLCHandler.isConnect & buPLCHandler.\u0001))
        return;
      int num2 = 0;
      byte[] bytes1 = Encoding.Default.GetBytes(buPLCHandler.DeviceIP.Trim());
      byte[] bytes2 = Encoding.Default.GetBytes(buPLCHandler.DeviceAddress.Trim());
      fixed (byte* numPtr = Encoding.Default.GetBytes(buPLCHandler.DeviceName.Trim()))
        \u0004.\u0001(numPtr);
      fixed (byte* numPtr = bytes1)
        \u0004.\u0001(numPtr);
      fixed (byte* numPtr = bytes2)
        \u0004.\u0001(numPtr);
      num2 = \u0004.\u0001();
      num2 = \u0004.\u0001();
      int num3 = !ByIP ? \u0004.\u0001() : \u0004.\u0001();
      if (!(num3 == 0 | num3 == 1))
        return;
      buPLCHandler.isConnect = true;
      num2 = \u0004.\u0001();
    }
  }

  public static void DisConnectPLC()
  {
    \u0004.\u0001();
    buPLCHandler.isConnect = false;
    try
    {
    }
    catch
    {
    }
  }

  public static int GetState(ref int State)
  {
    try
    {
      State = \u0004.\u0001();
      return 1;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static int ReadSymbolAll(ref List<string> SymbolNames)
  {
    SymbolNames.Clear();
    uint num = \u0004.\u0001();
    for (int Index = 0; (long) Index <= (long) (num - 1U); ++Index)
    {
      string SymbolName = "";
      buPLCHandler.ReadSymbolByIndex(Index, ref SymbolName);
      if (SymbolName.Trim().Length > 0)
        SymbolNames.Add(SymbolName);
    }
    return 1;
  }

  public static int ReadSymbolAll(ref List<WatchItem> SymbolNames)
  {
    SymbolNames.Clear();
    uint num = \u0004.\u0001();
    for (int Index = 0; (long) Index <= (long) (num - 1U); ++Index)
    {
      WatchItem watchItem = new WatchItem();
      buPLCHandler.ReadSymbolByIndex(Index, ref watchItem.Name);
      if (watchItem.Name.Trim().Length > 0)
      {
        string[] strArray = watchItem.Name.Split('.');
        if (strArray != null && strArray.Length != 0)
          watchItem.NameShort = strArray[strArray.Length - 1];
        SymbolNames.Add(watchItem);
      }
    }
    return 1;
  }

  public static unsafe int ReadSymbolByIndex(int Index, ref string SymbolName)
  {
    try
    {
      uint num1 = \u0004.\u0001();
      if (Index >= 0 & (long) Index <= (long) (num1 - 1U))
      {
        byte[] numArray = new byte[(int) byte.MaxValue];
        fixed (byte* numPtr = numArray)
        {
          int length = 0;
          uint num2 = \u0004.\u0001(Index, numPtr, ref length);
          if (num2 > 0U)
          {
            string Error = $"ReadSymbolByIndex =  ErrorVal = {num2.ToString()}  ;  {SymbolName} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          if (length > 0)
          {
            byte[] bytes = new byte[length];
            for (int index = 0; index < length; ++index)
              bytes[index] = numArray[index];
            SymbolName = Encoding.ASCII.GetString(bytes);
          }
          return 1;
        }
      }
      SymbolName = "";
      return -1;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static int ReadAnyValue(buHandleVariableType Var, ref object Value)
  {
    try
    {
      if (Var.VarType == typeof (double))
      {
        double num1 = 0.0;
        int num2 = buPLCHandler.ReadVariableLREAL(Var.VarName, ref num1);
        Value = (object) num1;
        return num2;
      }
      if (Var.VarType == typeof (float))
      {
        float num3 = 0.0f;
        int num4 = buPLCHandler.ReadVariableREAL(Var.VarName, ref num3);
        Value = (object) num3;
        return num4;
      }
      if (Var.VarType == typeof (int))
      {
        int num5 = 0;
        int num6 = buPLCHandler.ReadVariableDINT(Var.VarName, ref num5);
        Value = (object) num5;
        return num6;
      }
      if (Var.VarType == typeof (short))
      {
        short num7 = 0;
        int num8 = buPLCHandler.ReadVariableINT(Var.VarName, ref num7);
        Value = (object) num7;
        return num8;
      }
      if (!(Var.VarType == typeof (bool)))
        return -1;
      bool flag = false;
      int num = buPLCHandler.ReadVariableBOOL(Var.VarName, ref flag);
      Value = (object) flag;
      return num;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadMultiVariableLREAL(List<string> VarName, ref List<double> Value)
  {
    try
    {
      string[] strArray = new string[VarName.Count];
      double[] numArray1 = new double[VarName.Count];
      byte[] numArray2 = new byte[8 * VarName.Count];
      Value.Clear();
      for (int index = 0; index <= VarName.Count - 1; ++index)
      {
        strArray[index] = VarName[index];
        Value.Add(0.0);
      }
      fixed (double* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, VarName.Count, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadVariableLREAL =  ErrorVal = {num.ToString()}  ;  {VarName[0]} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          int index1 = 0;
          for (int index2 = 0; index2 <= numArray2.Length - 1; index2 += 8)
          {
            byte[] numArray3 = new byte[8]
            {
              numArray2[index1 * 8],
              numArray2[index1 * 8 + 1],
              numArray2[index1 * 8 + 2],
              numArray2[index1 * 8 + 3],
              numArray2[index1 * 8 + 4],
              numArray2[index1 * 8 + 5],
              numArray2[index1 * 8 + 6],
              numArray2[index1 * 8 + 7]
            };
            Value[index1] = \u0004.\u0001(numArray3);
            ++index1;
          }
          return 1;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadMultiVariableLREAL(ref List<VariableLREALDef> Vars)
  {
    try
    {
      string[] strArray = new string[Vars.Count];
      double[] numArray1 = new double[Vars.Count];
      byte[] numArray2 = new byte[8 * Vars.Count];
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        strArray[index] = Vars[index].Name;
        Vars[index].Value = 0.0;
      }
      fixed (double* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, Vars.Count, numPtr1, numPtr2);
          int index1 = 0;
          if (num != 0)
          {
            string Error = $"ReadVariableLREAL =  ErrorVal = {num.ToString()}  ;  {Vars[0].Name} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          for (int index2 = 0; index2 <= numArray2.Length - 1; index2 += 8)
          {
            byte[] numArray3 = new byte[8]
            {
              numArray2[index1 * 8],
              numArray2[index1 * 8 + 1],
              numArray2[index1 * 8 + 2],
              numArray2[index1 * 8 + 3],
              numArray2[index1 * 8 + 4],
              numArray2[index1 * 8 + 5],
              numArray2[index1 * 8 + 6],
              numArray2[index1 * 8 + 7]
            };
            Vars[index1].Value = \u0004.\u0001(numArray3);
            ++index1;
          }
          return 1;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadVariableLREAL(string VarName, ref double Value)
  {
    try
    {
      string[] strArray = new string[1]{ VarName };
      double[] numArray1 = new double[1];
      byte[] numArray2 = new byte[8];
      fixed (double* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, 1, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadVariableLREAL =  ErrorVal = {num.ToString()}  ;  {VarName} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          Value = \u0004.\u0001(numArray2);
          return num;
        }
    }
    catch (Exception ex)
    {
      buPLCHandler.ErrorList.Add($"WriteVariableLREAL =  ErrorVal = {-1.ToString()}  ;  {VarName} := {Value.ToString()}");
      return -1;
    }
  }

  public static unsafe int ReadVariableREAL(string VarName, ref float Value)
  {
    try
    {
      string[] strArray = new string[1]{ VarName };
      float[] numArray1 = new float[1];
      byte[] numArray2 = new byte[4];
      fixed (float* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, 1, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadVariableREAL =  ErrorVal = {num.ToString()}  ;  {VarName} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          Value = numArray1[0];
          return num;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadMultiVariableREAL(List<string> VarName, ref List<float> Value)
  {
    try
    {
      string[] strArray = new string[VarName.Count];
      float[] numArray1 = new float[VarName.Count];
      byte[] numArray2 = new byte[4 * VarName.Count];
      Value.Clear();
      for (int index = 0; index <= VarName.Count - 1; ++index)
      {
        strArray[index] = VarName[index];
        Value.Add(0.0f);
      }
      fixed (float* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, VarName.Count, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadVariableREAL =  ErrorVal = {num.ToString()}  ;  {VarName?.ToString()} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          for (int index = 0; index <= numArray1.Length - 1; ++index)
            Value[index] = numArray1[index];
          return 1;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadMultiVariableREAL(ref List<VariableREALDef> Vars)
  {
    try
    {
      string[] strArray = new string[Vars.Count];
      float[] numArray1 = new float[Vars.Count];
      byte[] numArray2 = new byte[4 * Vars.Count];
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        strArray[index] = Vars[index].Name;
        Vars[index].Value = 0.0f;
      }
      fixed (float* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, Vars.Count, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadVariableREAL =  ErrorVal = {num.ToString()}  ;  {Vars[0].Name} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          for (int index = 0; index <= numArray1.Length - 1; ++index)
            Vars[index].Value = numArray1[index];
          return 1;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static int ReadVariable(string VarName, ref object Value, VariableType Type)
  {
    int num1;
    switch (Type)
    {
      case VariableType.Bool:
        bool flag = false;
        buPLCHandler.ReadVariableBOOL(VarName, ref flag);
        Value = (object) flag;
        num1 = 1;
        break;
      case VariableType.INT:
        int num2 = 0;
        buPLCHandler.ReadVariableINT(VarName, ref num2);
        Value = (object) num2;
        num1 = 1;
        break;
      case VariableType.DINT:
        int num3 = 0;
        buPLCHandler.ReadVariableDINT(VarName, ref num3);
        Value = (object) num3;
        num1 = 1;
        break;
      case VariableType.REAL:
        float num4 = 0.0f;
        buPLCHandler.ReadVariableREAL(VarName, ref num4);
        Value = (object) num4;
        num1 = 1;
        break;
      case VariableType.LREAL:
        double num5 = 0.0;
        buPLCHandler.ReadVariableLREAL(VarName, ref num5);
        Value = (object) num5;
        num1 = 1;
        break;
      case VariableType.STRING:
        string str = "";
        buPLCHandler.ReadVariableSTRING(VarName, ref str);
        Value = (object) str;
        num1 = 1;
        break;
      default:
        num1 = -1;
        break;
    }
    return num1;
  }

  public static unsafe int ReadVariableSTRING(string VarName, ref string Value)
  {
    try
    {
      string[] strArray = new string[1]{ VarName };
      byte[] numArray = new byte[(int) byte.MaxValue];
      fixed (byte* numPtr = numArray)
      {
        int num = \u0004.\u0001(strArray, numPtr);
        int length = 0;
        if (num != 0)
        {
          string Error = $"ReadVariableSTRING =  ErrorVal = {num.ToString()}  ;  {VarName} := ??";
          buPLCHandler.ErrorList.Add(Error);
          // ISSUE: reference to a compiler-generated field
          if (buPLCHandler.\u0001 != null)
          {
            // ISSUE: reference to a compiler-generated field
            buPLCHandler.\u0001(Error);
          }
        }
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          if (numArray[index] == (byte) 0)
          {
            length = index;
            index = 1000;
          }
        }
        byte[] bytes = new byte[length];
        for (int index = 0; index < length; ++index)
          bytes[index] = numArray[index];
        Value = Encoding.ASCII.GetString(bytes);
        return num;
      }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadVariableINT(string VarName, ref short Value)
  {
    try
    {
      string[] strArray = new string[1]{ VarName };
      short[] numArray = new short[1];
      fixed (short* numPtr = numArray)
      {
        int num = \u0004.\u0001(strArray, 1, numPtr);
        if (num != 0)
        {
          string Error = $"ReadVariableINT =  ErrorVal = {num.ToString()}  ;  {VarName} := ??";
          buPLCHandler.ErrorList.Add(Error);
          // ISSUE: reference to a compiler-generated field
          if (buPLCHandler.\u0001 != null)
          {
            // ISSUE: reference to a compiler-generated field
            buPLCHandler.\u0001(Error);
          }
        }
        Value = numArray[0];
        return num;
      }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadVariableINT(string VarName, ref int Value)
  {
    try
    {
      string[] strArray = new string[1]{ VarName };
      short[] numArray = new short[1];
      fixed (short* numPtr = numArray)
      {
        int num = \u0004.\u0001(strArray, 1, numPtr);
        if (num != 0)
        {
          string Error = $"ReadVariableINT =  ErrorVal = {num.ToString()}  ;  {VarName} := ??";
          buPLCHandler.ErrorList.Add(Error);
          // ISSUE: reference to a compiler-generated field
          if (buPLCHandler.\u0001 != null)
          {
            // ISSUE: reference to a compiler-generated field
            buPLCHandler.\u0001(Error);
          }
        }
        Value = (int) numArray[0];
        return num;
      }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadVariableDINT(string VarName, ref int Value)
  {
    try
    {
      string[] strArray = new string[1]{ VarName };
      int[] numArray = new int[1];
      fixed (int* numPtr = numArray)
      {
        int num = \u0004.\u0001(strArray, 1, numPtr);
        if (num != 0)
        {
          string Error = $"ReadMultiVariableDINT =  ErrorVal = {num.ToString()}  ;  {VarName} := ??";
          buPLCHandler.ErrorList.Add(Error);
          // ISSUE: reference to a compiler-generated field
          if (buPLCHandler.\u0001 != null)
          {
            // ISSUE: reference to a compiler-generated field
            buPLCHandler.\u0001(Error);
          }
        }
        Value = numArray[0];
        return num;
      }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadMultiVariableDINT(List<string> VarName, ref List<int> Value)
  {
    try
    {
      string[] strArray = new string[VarName.Count];
      int[] numArray1 = new int[VarName.Count];
      byte[] numArray2 = new byte[4 * VarName.Count];
      Value.Clear();
      for (int index = 0; index <= VarName.Count - 1; ++index)
      {
        strArray[index] = VarName[index];
        Value.Add(0);
      }
      fixed (int* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, VarName.Count, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadMultiVariableDINT =  ErrorVal = {num.ToString()}  ;  {VarName[0]} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          for (int index = 0; index <= numArray1.Length - 1; ++index)
            Value[index] = numArray1[index];
          return 1;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadMultiVariableDINT(ref List<VariableDINTDef> Vars)
  {
    try
    {
      string[] strArray = new string[Vars.Count];
      int[] numArray1 = new int[Vars.Count];
      byte[] numArray2 = new byte[4 * Vars.Count];
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        strArray[index] = Vars[index].Name;
        Vars[index].Value = 0;
      }
      fixed (int* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, Vars.Count, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadMultiVariableDINT =  ErrorVal = {num.ToString()}  ;  {Vars[0].Name} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          for (int index = 0; index <= numArray1.Length - 1; ++index)
            Vars[index].Value = numArray1[index];
          return 1;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadVariableBOOL(string VarName, ref bool Value)
  {
    try
    {
      string[] strArray = new string[1]{ VarName };
      bool[] flagArray = new bool[1];
      fixed (bool* flagPtr = flagArray)
      {
        int num = \u0004.\u0001(strArray, 1, flagPtr);
        if (num != 0)
        {
          string Error = $"ReadVariableBOOL =  ErrorVal = {num.ToString()}  ;  {VarName} := ??";
          buPLCHandler.ErrorList.Add(Error);
          // ISSUE: reference to a compiler-generated field
          if (buPLCHandler.\u0001 != null)
          {
            // ISSUE: reference to a compiler-generated field
            buPLCHandler.\u0001(Error);
          }
        }
        Value = flagArray[0];
        return num;
      }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadMultiVariableBOOL(List<string> VarName, ref List<bool> Value)
  {
    try
    {
      string[] strArray = new string[VarName.Count];
      byte[] numArray1 = new byte[VarName.Count];
      byte[] numArray2 = new byte[VarName.Count];
      Value.Clear();
      for (int index = 0; index <= VarName.Count - 1; ++index)
      {
        strArray[index] = VarName[index];
        Value.Add(false);
      }
      fixed (byte* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, VarName.Count, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadMultiVariableBOOL =  ErrorVal = {num.ToString()}  ;  {VarName[0]} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          for (int index = 0; index <= numArray1.Length - 1; ++index)
            Value[index] = numArray1[index] >= (byte) 1;
          return 1;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe int ReadMultiVariableBOOL(ref List<VariableBOOLDef> Vars)
  {
    try
    {
      string[] strArray = new string[Vars.Count];
      byte[] numArray1 = new byte[Vars.Count];
      byte[] numArray2 = new byte[Vars.Count];
      for (int index = 0; index <= Vars.Count - 1; ++index)
      {
        strArray[index] = Vars[index].Name;
        Vars[index].Value = false;
      }
      fixed (byte* numPtr1 = numArray1)
        fixed (byte* numPtr2 = numArray2)
        {
          int num = \u0004.\u0001(strArray, Vars.Count, numPtr1, numPtr2);
          if (num != 0)
          {
            string Error = $"ReadMultiVariableBOOL =  ErrorVal = {num.ToString()}  ;  {Vars[0].Name} := ??";
            buPLCHandler.ErrorList.Add(Error);
            // ISSUE: reference to a compiler-generated field
            if (buPLCHandler.\u0001 != null)
            {
              // ISSUE: reference to a compiler-generated field
              buPLCHandler.\u0001(Error);
            }
          }
          for (int index = 0; index <= numArray1.Length - 1; ++index)
            Vars[index].Value = numArray1[index] >= (byte) 1;
          return 1;
        }
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static int WriteVariableLREAL(string VarName, object Value)
  {
    try
    {
      uint num = buPLCHandler.SetPLCvalue(Encoding.ASCII.GetBytes(VarName), BitConverter.GetBytes(Math.Round(Convert.ToDouble(Value), 5)));
      if (num > 0U)
      {
        string Error = $"WriteVariableLREAL =  ErrorVal = {num.ToString()}  ;  {VarName} := {Value.ToString()}";
        buPLCHandler.ErrorList.Add(Error);
        // ISSUE: reference to a compiler-generated field
        if (buPLCHandler.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          buPLCHandler.\u0001(Error);
        }
      }
      return (int) num;
    }
    catch (Exception ex)
    {
      buPLCHandler.ErrorList.Add($"WriteVariableLREAL =  ErrorVal = {-1.ToString()}  ;  {VarName} := {Value.ToString()}");
      return -1;
    }
  }

  public static int WriteVariableREAL(string VarName, object Value)
  {
    try
    {
      uint num = buPLCHandler.SetPLCvalue(Encoding.ASCII.GetBytes(VarName), BitConverter.GetBytes(Convert.ToSingle(Value)));
      if (num > 0U)
      {
        string Error = $"WriteVariableREAL =  ErrorVal = {num.ToString()}  ;  {VarName} := {Value.ToString()}";
        buPLCHandler.ErrorList.Add(Error);
        // ISSUE: reference to a compiler-generated field
        if (buPLCHandler.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          buPLCHandler.\u0001(Error);
        }
      }
      return (int) num;
    }
    catch (Exception ex)
    {
      buPLCHandler.ErrorList.Add($"WriteVariableREAL =  ErrorVal = {-1.ToString()}  ;  {VarName} := {Value.ToString()}");
      return -1;
    }
  }

  public static int WriteVariableDINT(string VarName, object Value)
  {
    try
    {
      uint num = buPLCHandler.SetPLCvalue(Encoding.ASCII.GetBytes(VarName), BitConverter.GetBytes(Convert.ToInt32(Value)));
      if (num > 0U)
      {
        string Error = $"WriteVariableDINT =  ErrorVal = {num.ToString()}  ;  {VarName} := {Value.ToString()}";
        buPLCHandler.ErrorList.Add(Error);
        // ISSUE: reference to a compiler-generated field
        if (buPLCHandler.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          buPLCHandler.\u0001(Error);
        }
      }
      return (int) num;
    }
    catch (Exception ex)
    {
      buPLCHandler.ErrorList.Add($"WriteVariableDINT =  ErrorVal = {-1.ToString()}  ;  {VarName} := {Value.ToString()}");
      return -1;
    }
  }

  public static int WriteVariableINT(string VarName, object Value)
  {
    try
    {
      uint num = buPLCHandler.SetPLCvalue(Encoding.ASCII.GetBytes(VarName), BitConverter.GetBytes(Convert.ToInt16(Value)));
      if (num > 0U)
      {
        string Error = $"WriteVariableINT =  ErrorVal = {num.ToString()}  ;  {VarName} := {Value.ToString()}";
        buPLCHandler.ErrorList.Add(Error);
        // ISSUE: reference to a compiler-generated field
        if (buPLCHandler.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          buPLCHandler.\u0001(Error);
        }
      }
      return (int) num;
    }
    catch (Exception ex)
    {
      buPLCHandler.ErrorList.Add($"WriteVariableINT =  ErrorVal = {-1.ToString()}  ;  {VarName} := {Value.ToString()}");
      return -1;
    }
  }

  public static int WriteVariableBOOL(string VarName, object Value)
  {
    try
    {
      uint num = buPLCHandler.SetPLCvalue(Encoding.ASCII.GetBytes(VarName), BitConverter.GetBytes(Convert.ToBoolean(Value)));
      if (num > 0U)
      {
        string Error = $"WriteVariableBOOL =  ErrorVal = {num.ToString()}  ;  {VarName} := {Value.ToString()}";
        buPLCHandler.ErrorList.Add(Error);
        // ISSUE: reference to a compiler-generated field
        if (buPLCHandler.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          buPLCHandler.\u0001(Error);
        }
      }
      return (int) num;
    }
    catch (Exception ex)
    {
      buPLCHandler.ErrorList.Add($"WriteVariableBOOL =  ErrorVal = {-1.ToString()}  ;  {VarName} := {Value.ToString()}");
      return -1;
    }
  }

  public static int WriteVariableSTRING(string VarName, object Value)
  {
    try
    {
      uint num = buPLCHandler.SetPLCvalue(Encoding.ASCII.GetBytes(VarName), Encoding.ASCII.GetBytes(Convert.ToString(Value)));
      if (num > 0U)
      {
        string Error = $"WriteVariableSTRING =  ErrorVal = {num.ToString()}  ;  {VarName} := {Value.ToString()}";
        buPLCHandler.ErrorList.Add(Error);
        // ISSUE: reference to a compiler-generated field
        if (buPLCHandler.\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          buPLCHandler.\u0001(Error);
        }
      }
      return (int) num;
    }
    catch (Exception ex)
    {
      buPLCHandler.ErrorList.Add($"WriteVariableSTRING =  ErrorVal = {-1.ToString()}  ;  {VarName} := {Value.ToString()}");
      return -1;
    }
  }

  public static int WriteVariable(string VarName, object Value)
  {
    try
    {
      int num = -1;
      if (Value.GetType() == typeof (double))
        num = buPLCHandler.WriteVariableLREAL(VarName, Value);
      if (Value.GetType() == typeof (float))
        num = buPLCHandler.WriteVariableREAL(VarName, Value);
      if (Value.GetType() == typeof (short))
        num = buPLCHandler.WriteVariableINT(VarName, Value);
      if (Value.GetType() == typeof (int))
        num = buPLCHandler.WriteVariableDINT(VarName, Value);
      if (Value.GetType() == typeof (bool))
        num = buPLCHandler.WriteVariableBOOL(VarName, Value);
      if (Value.GetType() == typeof (string))
        num = buPLCHandler.WriteVariableSTRING(VarName, Value);
      return num;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static int WriteVariable(string VarName, object Value, System.Type VarType)
  {
    try
    {
      int num = -1;
      if (VarType == typeof (double))
        num = buPLCHandler.WriteVariableLREAL(VarName, Value);
      if (VarType == typeof (float))
        num = buPLCHandler.WriteVariableREAL(VarName, Value);
      if (VarType == typeof (short))
        num = buPLCHandler.WriteVariableINT(VarName, Value);
      if (VarType == typeof (int))
        num = buPLCHandler.WriteVariableDINT(VarName, Value);
      if (VarType == typeof (bool))
        num = buPLCHandler.WriteVariableBOOL(VarName, Value);
      return num;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static int WriteVariable(string VarName, object Value, VariableType VarType)
  {
    try
    {
      int num = -1;
      if (VarType == VariableType.LREAL)
        num = buPLCHandler.WriteVariableLREAL(VarName, Value);
      if (VarType == VariableType.REAL)
        num = buPLCHandler.WriteVariableREAL(VarName, Value);
      if (VarType == VariableType.INT)
        num = buPLCHandler.WriteVariableINT(VarName, Value);
      if (VarType == VariableType.DINT)
        num = buPLCHandler.WriteVariableDINT(VarName, Value);
      if (VarType == VariableType.Bool)
        num = buPLCHandler.WriteVariableBOOL(VarName, Value);
      if (VarType == VariableType.STRING)
        num = buPLCHandler.WriteVariableSTRING(VarName, Value);
      return num;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public static unsafe uint SetPLCvalue(byte[] pszName, byte[] data)
  {
    fixed (byte* numPtr1 = pszName)
      fixed (byte* numPtr2 = data)
        return \u0004.\u0001(numPtr1, numPtr2);
  }

  public static int ClassToPLC(object Variable, string RootString, string AfterString = "")
  {
    int tickCount = Environment.TickCount;
    try
    {
      if (!AppBool.Connected)
        return -1;
      if (Variable == null)
      {
        int num = (int) MessageBox.Show("Variable is Null - ClassToPLC");
        return -1;
      }
      object obj1 = Variable;
      if (obj1 == null)
        return -1;
      FieldInfo[] fields = obj1.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          FieldInfo fieldInfo = fields[index];
          string name1 = fieldInfo.Name;
          string name2 = fieldInfo.Name;
          if (fieldInfo.FieldType.ToString().IndexOf("List") < 0)
          {
            object obj2 = fieldInfo.GetValue(obj1);
            if (fieldInfo.FieldType.BaseType == typeof (Enum))
            {
              int int32 = Convert.ToInt32(obj2);
              buPLCHandler.WriteVariableDINT(RootString + name1 + AfterString, (object) int32);
            }
            if (obj2.GetType() == typeof (double))
            {
              double num = Convert.ToDouble(obj2);
              buPLCHandler.WriteVariableLREAL(RootString + name1 + AfterString, (object) num);
            }
            if (obj2.GetType() == typeof (float))
            {
              float single = Convert.ToSingle(obj2);
              buPLCHandler.WriteVariableREAL(RootString + name1 + AfterString, (object) single);
            }
            if (obj2.GetType() == typeof (int))
            {
              int int32 = Convert.ToInt32(obj2);
              buPLCHandler.WriteVariableDINT(RootString + name1 + AfterString, (object) int32);
            }
            if (obj2.GetType() == typeof (short))
            {
              short int16 = Convert.ToInt16(obj2);
              buPLCHandler.WriteVariableINT(RootString + name1 + AfterString, (object) int16);
            }
            if (obj2.GetType() == typeof (bool))
            {
              bool boolean = Convert.ToBoolean(obj2);
              buPLCHandler.WriteVariableBOOL(RootString + name1 + AfterString, (object) boolean);
            }
            if (obj2.GetType() == typeof (string))
            {
              string str = Convert.ToString(obj2);
              if (str.Length > 0)
                buPLCHandler.WriteVariableSTRING(RootString + name1 + AfterString, (object) str);
            }
          }
        }
      }
      return 1;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, nameof (ClassToPLC), false, "Variable : " + Variable.ToString());
      return -1;
    }
  }

  public delegate void PLCHandlerCommError(string Error);
}
