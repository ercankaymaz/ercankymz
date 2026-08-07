// Decompiled with JetBrains decompiler
// Type: buClass.GCodeToSimulationConversionSettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class GCodeToSimulationConversionSettings : buSerilization
{
  public Pnt6D StartPositions = new Pnt6D(0.0, 0.0, 200.0, 0.0, 0.0, 0.0);
  public Pnt6D G53Positions = new Pnt6D(0.0, 0.0, 200.0, 0.0, 0.0, 0.0);
  public Pnt6D OffsetPositions = new Pnt6D(0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
  public bool AddMCodes = false;
  public bool UseStartPosition = false;
  public int ClamperCount = 0;
  public bool ReverseG3 = false;
  public bool ReverseG2 = false;
  public string CommentChar = "";
  public List<string> CommandList = (List<string>) null;

  public GCodeToSimulationConversionSettings()
  {
  }

  public GCodeToSimulationConversionSettings(GCodeToSimulationConversionSettings data)
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
