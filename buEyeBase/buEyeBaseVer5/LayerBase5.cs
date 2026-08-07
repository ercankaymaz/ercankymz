// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.LayerBase5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class LayerBase5 : buSerilization5
{
  public double SafeDistance;
  public double RapidDistance;
  public double WaitTime;
  public double DepthOffset;
  public bool Air;
  public bool Water;
  public bool Oil;
  public bool Dust;
  public bool InnerCooling;
  public bool FeedFromTool;
  public bool DistanceFromTool;
  public bool DepthFromTool;
  public bool CutOverrideFromTool;
  public bool SpindleReverseDir;
  public ArrayList AirText;
  public ArrayList OilText;
  public ArrayList WaterText;
  public ArrayList InnerCoolText;
  public Pnt6D SimMoveOffset;
  public ClockDirectionType SpindleDirection;
  public static byte f000442;
  public Pnt6D AxesMinLimits;
  public Pnt6D AxesMaxLimits;
  public bool PlaneTop;
  public bool PlaneBottom;

  public abstract void m000199();

  public LayerBase5()
  {
    ((ToolCamData5) this).Solid = new SolidItemDisplay(Color.Red, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ToolCutSolid = new SolidItemDisplay(Color.DarkOrange, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ToolBodySolid = new SolidItemDisplay(Color.DarkOliveGreen, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).HolderSolid = new SolidItemDisplay(Color.DarkGray, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ArborSolid = new SolidItemDisplay(Color.DarkSlateBlue, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).CamColor = Color.Red;
    ((ToolCamData5) this).CamThickness = 2.0;
    ((ToolCamData5) this).PlungeColor = Color.Green;
    ((ToolCamData5) this).PlungeThickness = 2.0;
    ((ToolCamData5) this).LeaveColor = Color.Gold;
    ((ToolCamData5) this).LeaveThickness = 2.0;
    ((ToolCamData5) this).UpperCamColor = Color.Blue;
    ((ToolCamData5) this).UpperCamThickness = 2.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public LayerBase5(ToolDisplay5 display)
  {
    ((ToolCamData5) this).Solid = new SolidItemDisplay(Color.Red, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ToolCutSolid = new SolidItemDisplay(Color.DarkOrange, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ToolBodySolid = new SolidItemDisplay(Color.DarkOliveGreen, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).HolderSolid = new SolidItemDisplay(Color.DarkGray, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ArborSolid = new SolidItemDisplay(Color.DarkSlateBlue, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).CamColor = Color.Red;
    ((ToolCamData5) this).CamThickness = 2.0;
    ((ToolCamData5) this).PlungeColor = Color.Green;
    ((ToolCamData5) this).PlungeThickness = 2.0;
    ((ToolCamData5) this).LeaveColor = Color.Gold;
    ((ToolCamData5) this).LeaveThickness = 2.0;
    ((ToolCamData5) this).UpperCamColor = Color.Blue;
    ((ToolCamData5) this).UpperCamThickness = 2.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) display, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    ((ToolCamData5) this).ToolBodySolid = new SolidItemDisplay(((ToolCamData5) display).ToolBodySolid);
  }

  public LayerBase5(ToolDisplay display)
  {
    ((ToolCamData5) this).Solid = new SolidItemDisplay(Color.Red, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ToolCutSolid = new SolidItemDisplay(Color.DarkOrange, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ToolBodySolid = new SolidItemDisplay(Color.DarkOliveGreen, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).HolderSolid = new SolidItemDisplay(Color.DarkGray, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).ArborSolid = new SolidItemDisplay(Color.DarkSlateBlue, 220, Color.DarkRed, 240 /*0xF0*/);
    ((ToolCamData5) this).CamColor = Color.Red;
    ((ToolCamData5) this).CamThickness = 2.0;
    ((ToolCamData5) this).PlungeColor = Color.Green;
    ((ToolCamData5) this).PlungeThickness = 2.0;
    ((ToolCamData5) this).LeaveColor = Color.Gold;
    ((ToolCamData5) this).LeaveThickness = 2.0;
    ((ToolCamData5) this).UpperCamColor = Color.Blue;
    ((ToolCamData5) this).UpperCamThickness = 2.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) display, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    ((ToolCamData5) this).ToolBodySolid = new SolidItemDisplay(display.ToolBodySolid);
  }

  public override string ToString()
  {
    return $"Tool Color: {((ToolCamData5) this).Solid.SkinColor.ToString()} - Cam Color: {((ToolCamData5) this).CamColor.ToString()} - Up Cam Color: {((ToolCamData5) this).UpperCamColor.ToString()}";
  }

  public abstract void m00019E();

  public LayerBase5()
  {
    ((ToolCamData5) this).Name = "Tool";
    ((ToolCamData5) this).No = 1;
    ((ToolCamData5) this).Sector = 1;
    ((ToolCamData5) this).HeightOffsetIndex = 0;
    ((ToolCamData5) this).Tag = "";
    ((ToolCamData5) this).Clone = false;
    ((ToolCamData5) this).Used = false;
    ((ToolCamData5) this).CloneToolNo = 1;
    ((ToolCamData5) this).Broken = false;
    ((ToolCamData5) this).MaxUsageHour = 100.0;
    ((ToolCamData5) this).ActiveUsageHour = 0.0;
    ((ToolCamData5) this).TappingInfo = 1.0;
    ((ToolCamData5) this).TimeLimitExceed = false;
    ((ToolCamData5) this).Priority = 10;
    ((ToolCamData5) this).isAgregateLeft = false;
    ((ToolCamData5) this).isAgregate = false;
    ((ToolCamData5) this).GroupIndex = -1;
    ((ToolLimits5) this).GroupItemIndex = -1;
    ((ToolLimits5) this).HeadNumber = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public LayerBase5(ToolData5 data)
  {
    ((ToolCamData5) this).Name = "Tool";
    ((ToolCamData5) this).No = 1;
    ((ToolCamData5) this).Sector = 1;
    ((ToolCamData5) this).HeightOffsetIndex = 0;
    ((ToolCamData5) this).Tag = "";
    ((ToolCamData5) this).Clone = false;
    ((ToolCamData5) this).Used = false;
    ((ToolCamData5) this).CloneToolNo = 1;
    ((ToolCamData5) this).Broken = false;
    ((ToolCamData5) this).MaxUsageHour = 100.0;
    ((ToolCamData5) this).ActiveUsageHour = 0.0;
    ((ToolCamData5) this).TappingInfo = 1.0;
    ((ToolCamData5) this).TimeLimitExceed = false;
    ((ToolCamData5) this).Priority = 10;
    ((ToolCamData5) this).isAgregateLeft = false;
    ((ToolCamData5) this).isAgregate = false;
    ((ToolCamData5) this).GroupIndex = -1;
    ((ToolLimits5) this).GroupItemIndex = -1;
    ((ToolLimits5) this).HeadNumber = 1;
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

  public LayerBase5(ToolData data)
  {
    ((ToolCamData5) this).Name = "Tool";
    ((ToolCamData5) this).No = 1;
    ((ToolCamData5) this).Sector = 1;
    ((ToolCamData5) this).HeightOffsetIndex = 0;
    ((ToolCamData5) this).Tag = "";
    ((ToolCamData5) this).Clone = false;
    ((ToolCamData5) this).Used = false;
    ((ToolCamData5) this).CloneToolNo = 1;
    ((ToolCamData5) this).Broken = false;
    ((ToolCamData5) this).MaxUsageHour = 100.0;
    ((ToolCamData5) this).ActiveUsageHour = 0.0;
    ((ToolCamData5) this).TappingInfo = 1.0;
    ((ToolCamData5) this).TimeLimitExceed = false;
    ((ToolCamData5) this).Priority = 10;
    ((ToolCamData5) this).isAgregateLeft = false;
    ((ToolCamData5) this).isAgregate = false;
    ((ToolCamData5) this).GroupIndex = -1;
    ((ToolLimits5) this).GroupItemIndex = -1;
    ((ToolLimits5) this).HeadNumber = 1;
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
    return $"Name: {((ToolCamData5) this).Name.ToString()} - No: {((ToolCamData5) this).No.ToString()} - Sector: {((ToolCamData5) this).Sector.ToString()}";
  }
}
