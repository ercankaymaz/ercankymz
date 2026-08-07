// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Printer3DJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class Printer3DJob : buSerilization5
{
  public double ManuelSheetWidth;
  public double ManuelSheetHeight;
  public static byte f003B04;
  public double MachineWidth;
  public double MachineHeight;
  public double RepeatCount;
  public bool ShowMachineSize;
  public double PastalWidth;
  public string DrillLayerName;
  public string MirrorLayerName;
  public string RopeDirectionLayerName;

  public Printer3DJob(CutterIsoEntities data)
  {
    ((WoodItemType) this).InnerCenterEntities = new List<List<Entity>>();
    ((WoodItemType) this).DirectionCenterEntities = new List<List<Entity>>();
    ((WoodItemType) this).InnerPlotterCenterEntities = new List<List<Entity>>();
    ((WoodItemType) this).InnerPlotterAuxCenterEntities = new List<List<Entity>>();
    ((WoodItemType) this).TextCenterEntities = new List<Entity>();
    ((WoodItemType) this).NotchCenterEntities = new List<Entity>();
    ((WoodItemType) this).DrillMainEntities = new List<Entity>();
    ((WoodItemType) this).DrillAuxEntities = new List<Entity>();
    ((buPrinter3D) this).OutsideCenterEntities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  public Printer3DJob()
  {
    ((buPrinter3D) this).DrillDiameterError = false;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
  }

  public Printer3DJob(CutterIsoError data)
  {
    ((buPrinter3D) this).DrillDiameterError = false;
    // ISSUE: explicit constructor call
    ((buSerilization) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
}
