// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.MemberRefsProxy
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using buClass;
using buOpcUA;
using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class MemberRefsProxy
{
  private TaskAwaiter<Session> \u0001;
  public static byte f000037;

  public static string ReadSTRINGArray(Session session, string nodeid, ref string[] Values)
  {
    try
    {
      object obj = session.ReadValue(new NodeId(nodeid)).Value;
      if ((obj == null ? 0 : (obj.GetType() == typeof (string[]) ? 1 : 0)) == 0)
        return "Type Mismatch string[]";
      Values = (string[]) obj;
      return "Ok";
    }
    catch (Exception ex)
    {
      return "Exception - " + ex.Message;
    }
  }

  public static string ClassToPLC(
    object Variable,
    string RootString,
    Session session,
    string AfterString = "")
  {
    int tickCount = Environment.TickCount;
    try
    {
      if (!AppBool.Connected)
        return "Communication Offline";
      if (Variable == null)
      {
        int num = (int) MessageBox.Show("Variable is Null - ClassToPLC");
        return "Variable Null";
      }
      object obj1 = Variable;
      List<VariableREALDef> VarsRealList = new List<VariableREALDef>();
      List<VariableLREALDef> VarsStringList1 = new List<VariableLREALDef>();
      List<VariableINTDef> VarsStringList2 = new List<VariableINTDef>();
      List<VariableDINTDef> VarsStringList3 = new List<VariableDINTDef>();
      List<VariableSTRINGDef> VarsStringList4 = new List<VariableSTRINGDef>();
      List<VariableBOOLDef> VarsStringList5 = new List<VariableBOOLDef>();
      List<VariableENUMDef> VarsStringList6 = new List<VariableENUMDef>();
      if (obj1 == null)
        return "Variable Null";
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
              short int16 = Convert.ToInt16(obj2);
              VariableINTDef variableIntDef = new VariableINTDef(RootString + name1 + AfterString, int16);
              VarsStringList2.Add(variableIntDef);
            }
            if (obj2.GetType() == typeof (double))
            {
              double val = Convert.ToDouble(obj2);
              VariableLREALDef variableLrealDef = new VariableLREALDef(RootString + name1 + AfterString, val);
              VarsStringList1.Add(variableLrealDef);
            }
            if (obj2.GetType() == typeof (float))
            {
              float single = Convert.ToSingle(obj2);
              VariableREALDef variableRealDef = new VariableREALDef(RootString + name1 + AfterString, single);
              VarsRealList.Add(variableRealDef);
            }
            if (obj2.GetType() == typeof (int))
            {
              int int32 = Convert.ToInt32(obj2);
              VariableDINTDef variableDintDef = new VariableDINTDef(RootString + name1 + AfterString, int32);
              VarsStringList3.Add(variableDintDef);
            }
            if (obj2.GetType() == typeof (short))
            {
              short int16 = Convert.ToInt16(obj2);
              VariableINTDef variableIntDef = new VariableINTDef(RootString + name1 + AfterString, int16);
              VarsStringList2.Add(variableIntDef);
            }
            if (obj2.GetType() == typeof (bool))
            {
              bool boolean = Convert.ToBoolean(obj2);
              VariableBOOLDef variableBoolDef = new VariableBOOLDef(RootString + name1 + AfterString, boolean);
              VarsStringList5.Add(variableBoolDef);
            }
            if (obj2.GetType() == typeof (string))
            {
              string val = Convert.ToString(obj2);
              if (val.Length > 0)
              {
                VariableSTRINGDef variableStringDef = new VariableSTRINGDef(RootString + name1 + AfterString, val);
                VarsStringList4.Add(variableStringDef);
              }
            }
          }
        }
      }
      List<string> collection = new List<string>();
      string plc = "";
      if (VarsStringList5.Count > 0)
      {
        string str = OPCReadWrite.WriteBOOLList(VarsStringList5, session);
        if (plc == "" & str != "Ok")
          plc = str;
        collection.AddRange((IEnumerable<string>) \u0003.\u0001.ErrorList);
        \u0003.\u0001.ErrorList.Clear();
      }
      if (VarsStringList2.Count > 0)
      {
        string str = OPCReadWrite.WriteINTList(VarsStringList2, session);
        if (plc == "" & str != "Ok")
          plc = str;
        collection.AddRange((IEnumerable<string>) \u0003.\u0001.ErrorList);
        \u0003.\u0001.ErrorList.Clear();
      }
      if (VarsStringList3.Count > 0)
      {
        string str = OPCReadWrite.WriteDINTList(VarsStringList3, session);
        if (plc == "" & str != "Ok")
          plc = str;
        collection.AddRange((IEnumerable<string>) \u0003.\u0001.ErrorList);
        \u0003.\u0001.ErrorList.Clear();
      }
      if (VarsRealList.Count > 0)
      {
        string str = OPCReadWrite.WriteREALList(VarsRealList, session);
        if (plc == "" & str != "Ok")
          plc = str;
        collection.AddRange((IEnumerable<string>) \u0003.\u0001.ErrorList);
        \u0003.\u0001.ErrorList.Clear();
      }
      if (VarsStringList1.Count > 0)
      {
        string str = OPCReadWrite.WriteLREALList(VarsStringList1, session);
        if (plc == "" & str != "Ok")
          plc = str;
        collection.AddRange((IEnumerable<string>) \u0003.\u0001.ErrorList);
        \u0003.\u0001.ErrorList.Clear();
      }
      if (VarsStringList4.Count > 0)
      {
        string str = OPCReadWrite.WriteSTRINGList(VarsStringList4, session);
        if (plc == "" & str != "Ok")
          plc = str;
        collection.AddRange((IEnumerable<string>) \u0003.\u0001.ErrorList);
        \u0003.\u0001.ErrorList.Clear();
      }
      if (VarsStringList6.Count > 0)
      {
        string str = OPCReadWrite.WriteENUMList(VarsStringList6, session);
        if (plc == "" & str != "Ok")
          plc = str;
        collection.AddRange((IEnumerable<string>) \u0003.\u0001.ErrorList);
        \u0003.\u0001.ErrorList.Clear();
      }
      if (plc == "")
        plc = "Ok";
      \u0003.\u0001.ErrorList.AddRange((IEnumerable<string>) collection);
      return plc;
    }
    catch (Exception ex)
    {
      buException.throwException(ex, nameof (ClassToPLC), false, "Variable : " + Variable.ToString());
      return "Error : Exception";
    }
  }
}
