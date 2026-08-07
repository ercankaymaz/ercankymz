// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ToolCamData5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ToolCamData5 : buSerilization5
{
  public double FromFileAngle;
  public List<Pnt3D> ArborPoints;
  public List<Pnt3D> HolderPoints;
  public static byte f0003FC;
  public SolidItemDisplay Solid;
  public SolidItemDisplay ToolCutSolid;
  public SolidItemDisplay ToolBodySolid;
  public SolidItemDisplay HolderSolid;
  public SolidItemDisplay ArborSolid;
  public Color CamColor;
  public double CamThickness;
  public Color PlungeColor;
  public double PlungeThickness;
  public Color LeaveColor;
  public double LeaveThickness;
  public Color UpperCamColor;
  public double UpperCamThickness;
  public static byte f00040A;
  public string Name;
  public int No;
  public int Sector;
  public int HeightOffsetIndex;
  public string Tag;
  public bool Clone;
  public bool Used;
  public int CloneToolNo;
  public bool Broken;
  public double MaxUsageHour;
  public double ActiveUsageHour;
  public double TappingInfo;
  public bool TimeLimitExceed;
  public int Priority;
  public bool isAgregateLeft;
  public bool isAgregate;
  public int GroupIndex;

  public static void Decode(ArrayList AL, ref ToolBase5 Tool)
  {
    Tool = (ToolBase5) new ToolGeometry5();
    if (AL.Count >= 1)
    {
      EnumConverter enumConverter = new EnumConverter(typeof (ToolPurpose));
      ((ToolGeometry5) Tool).Purpose = (ToolPurpose) enumConverter.ConvertFromString(AL[0].ToString());
    }
    if (AL.Count >= 2)
    {
      object data = (object) ((ToolGeometry5) Tool).Data;
      buSerilization5.StringToClass(ref data, AL[1].ToString());
    }
    if (AL.Count >= 3)
    {
      object geometry = (object) ((ToolGeometry5) Tool).Geometry;
      buSerilization5.StringToClass(ref geometry, AL[2].ToString());
    }
    if (AL.Count < 4)
      return;
    object camData = (object) ((ToolGeometry5) Tool).CamData;
    buSerilization5.StringToClass(ref camData, AL[3].ToString());
  }

  public static void DecodeShort(ArrayList AL, ref ToolBase5 Tool)
  {
    Tool = (ToolBase5) new ToolGeometry5();
    if (AL.Count >= 1)
    {
      EnumConverter enumConverter = new EnumConverter(typeof (ToolPurpose));
      ((ToolGeometry5) Tool).Purpose = (ToolPurpose) enumConverter.ConvertFromString(AL[0].ToString());
    }
    if (AL.Count >= 2)
    {
      object data = (object) ((ToolGeometry5) Tool).Data;
      buSerilization5.StringToClass(ref data, AL[1].ToString());
    }
    if (AL.Count >= 3)
    {
      object geometry = (object) ((ToolGeometry5) Tool).Geometry;
      buSerilization5.StringToClass(ref geometry, AL[2].ToString());
    }
    if (AL.Count >= 4)
    {
      object camData = (object) ((ToolGeometry5) Tool).CamData;
      buSerilization5.StringToClass(ref camData, AL[3].ToString());
    }
    if (AL.Count >= 5)
    {
      object limits = (object) ((ToolGeometry5) Tool).Limits;
      buSerilization5.StringToClass(ref limits, AL[4].ToString());
    }
    if (AL.Count < 6)
      return;
    object positions = (object) ((ToolGeometry5) Tool).Positions;
    buSerilization5.StringToClass(ref positions, AL[5].ToString());
  }

  public static void DecodeShort(List<string> SL, ref ToolBase5 Tool)
  {
    Tool = (ToolBase5) new ToolGeometry5();
    if (SL.Count >= 1)
    {
      EnumConverter enumConverter = new EnumConverter(typeof (ToolPurpose));
      ((ToolGeometry5) Tool).Purpose = (ToolPurpose) enumConverter.ConvertFromString(SL[0].ToString());
    }
    if (SL.Count >= 2)
    {
      object data = (object) ((ToolGeometry5) Tool).Data;
      buSerilization5.StringToClass(ref data, SL[1].ToString());
    }
    if (SL.Count >= 3)
    {
      object geometry = (object) ((ToolGeometry5) Tool).Geometry;
      buSerilization5.StringToClass(ref geometry, SL[2].ToString());
    }
    if (SL.Count >= 4)
    {
      object camData = (object) ((ToolGeometry5) Tool).CamData;
      buSerilization5.StringToClass(ref camData, SL[3].ToString());
    }
    if (SL.Count >= 5)
    {
      object limits = (object) ((ToolGeometry5) Tool).Limits;
      buSerilization5.StringToClass(ref limits, SL[4].ToString());
    }
    if (SL.Count < 6)
      return;
    object positions = (object) ((ToolGeometry5) Tool).Positions;
    buSerilization5.StringToClass(ref positions, SL[5].ToString());
  }

  public static void Copy(ToolBase5 RefTools, ref ToolBase5 CopiedTool)
  {
    if (!(RefTools.GetType() == typeof (ToolBase5)))
      return;
    CopiedTool = (ToolBase5) new ToolGeometry5(RefTools);
  }
}
