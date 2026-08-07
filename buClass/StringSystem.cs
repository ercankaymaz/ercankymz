// Decompiled with JetBrains decompiler
// Type: buClass.StringSystem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class StringSystem : buSerilization
{
  public static string strSystemRuntimeVar = "sysRun.";
  public static string strSystemSettingsVar = "sysSet.";
  public static string strCNCRuntimeVar = "CncRunMaster.";
  public static string strCNCSettingsVar = "CncSetMaster.";
  public static string strAppRuntimeVar = "appRun.";
  public static string strAppSettingsVar = "appSet.";
  public static string strKinematicVar = "Kinematic.";
  public static List<string> Captions = new List<string>();

  public StringSystem()
  {
  }

  public StringSystem(StringSystem data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }

  public override string ToString()
  {
    return "strSystemRuntimeVar : " + StringSystem.strSystemRuntimeVar.ToString();
  }
}
