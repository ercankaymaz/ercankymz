// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineConfigSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MachineConfigSettings : buSerilization5
{
  public double NotchDepth;
  public double NotchStartHeight;

  public MachineConfigSettings(SortbuCamData data)
  {
    ((ShapeUpdateArg) this).Tool = (ToolBase5) new ToolGeometry5();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    ((ShapeUpdateArg) this).Tool = (ToolBase5) new ToolGeometry5(((ShapeUpdateArg) data).Tool);
  }

  public MachineConfigSettings()
  {
    ((ShapeSettingData) this).FirstPoint = new Point3D();
    ((ShapeRuntimeData) this).LastPoint = new Point3D();
    ((ShapeRuntimeData) this).ResultType = SortingResultType.None;
    ((ShapeRuntimeData) this).SelectedEntitiesIndex = new List<int>();
    ((ShapeRuntimeData) this).LastCalculatedEntities = new List<buEntity>();
    ((ShapeRuntimeData) this).AskMeEntites = new List<buEntity>();
    ((ShapeRuntimeData) this).LastSelectedEntitiesIndex = new List<int>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
