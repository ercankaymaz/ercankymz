// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillFound
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillFound : buSerilization5
{
  public Color ConenctionColor;
  public Color LimitExceedColor;

  public DrillFound()
  {
    ((DrillJob) this).SelectMode = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillFound(Printer3DRuntimeSettings data)
  {
    ((DrillJob) this).SelectMode = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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

  public DrillFound()
  {
    ((DrillJob) this).layerSliceName = "Slice";
    ((DrillJob) this).layerRegionName = "Region";
    ((DrillJob) this).layerOffsetSliceName = "OffsetSlice";
    ((DrillJob) this).layerSimulationName = "Simulation";
    ((DrillJob) this).layerTessellationName = "Tessellation";
    ((DrillJob) this).layerCamName = "Cam";
    ((DrillJob) this).layerOnlineSimulationName = "OnlineSimulation";
    ((DrillJob) this).layerInFill = "InFill";
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public DrillFound(Printer3DTempVars data)
  {
    ((DrillJob) this).layerSliceName = "Slice";
    ((DrillJob) this).layerRegionName = "Region";
    ((DrillJob) this).layerOffsetSliceName = "OffsetSlice";
    ((DrillJob) this).layerSimulationName = "Simulation";
    ((DrillJob) this).layerTessellationName = "Tessellation";
    ((DrillJob) this).layerCamName = "Cam";
    ((DrillJob) this).layerOnlineSimulationName = "OnlineSimulation";
    ((DrillJob) this).layerInFill = "InFill";
    // ISSUE: explicit constructor call
    base.\u002Ector();
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
