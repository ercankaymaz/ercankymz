// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MacroItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MacroItem : buSerilization5
{
  public double FMultiply;
  public double SMultiply;
  public double FilterLength;
  public static List<string> Captions;
  public static byte f0008D0;
  public Pnt9D Offset;
  public Pnt9D Positions;
  public int CodeType;
  public bool isMCode;
  public bool isGCode;
  public bool isTCode;
  public bool isG0Move;
  public ToolBase5 Tool;
  public IJK IJKValue;
  public double SpindleSpeed;
  public double Feed;
  public double R;
  public double MValue;
  public double GValue;
  public double TValue;
  public string CodeString;
  public string Aux;

  public MacroItem()
  {
    ((GCodeSetting5) this).PartTypeInfo = "";
    ((GCodeSetting5) this).PartTypeAdder = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MacroItem(MachineConfigSettings data)
  {
    ((GCodeSetting5) this).PartTypeInfo = "";
    ((GCodeSetting5) this).PartTypeAdder = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
