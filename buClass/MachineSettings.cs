// Decompiled with JetBrains decompiler
// Type: buClass.MachineSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class MachineSettings : buSerilization
{
  public double AxisNumber = 3.0;
  public int InputCount = 16 /*0x10*/;
  public int OutputCount = 16 /*0x10*/;
  public int ToolCount = 6;
  public int G54Count = 2;
  public int ParkCount = 5;
  public int ToolChangerCount = 10;
  public static List<string> Captions = new List<string>();

  public MachineSettings()
  {
  }

  public MachineSettings(MachineSettings data)
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
}
