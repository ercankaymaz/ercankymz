// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillUpdateArg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillUpdateArg : buSerilization5
{
  public double Y1Position;
  public double Y2Position;
  public double Y3Position;

  public abstract void m001B86();

  public DrillUpdateArg()
  {
    ((DrillCalcItem) this).BlockName = "Block";
    ((DrillItemBase) this).TopZ = 100.0;
    ((DrillItemBase) this).BottomZ = 100.0;
    ((DrillItemBase) this).LeftMin = 0.0;
    ((DrillItemBase) this).LeftMax = 0.0;
    ((DrillItemBase) this).isError = false;
    ((DrillItemBase) this).isVertical = false;
    ((DrillItemBase) this).SizeObj = new SizeObject();
    ((DrillItemBase) this).TextureName = "";
    ((DrillItemBase) this).colorFoam = Color.DarkGray;
    ((DrillItemBase) this).Transparency = 120;
    ((DrillItemBase) this).MinPoint = new Point3D();
    ((DrillItemBase) this).MaxPoint = new Point3D();
    ((DrillItemBase) this).planeName = FoamPlaneType.XZ;
    ((DrillItemBase) this).Speeds = (FoamSpeeds) new buNestingCalc();
    ((DrillItemBase) this).Settings = (FoamRuntimeSettings) new buNestingCalc();
    ((DrillItemBase) this).basePattern = (FoamPattern) null;
    ((DrillItemBase) this).BlockFoamType = FoamType.SlicesVertical;
    ((DrillItemBase) this).isWaveOperation = false;
    ((DrillItemBase) this).Pattern = new List<FoamPattern>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillUpdateArg(FoamBlock data)
  {
    ((DrillCalcItem) this).BlockName = "Block";
    ((DrillItemBase) this).TopZ = 100.0;
    ((DrillItemBase) this).BottomZ = 100.0;
    ((DrillItemBase) this).LeftMin = 0.0;
    ((DrillItemBase) this).LeftMax = 0.0;
    ((DrillItemBase) this).isError = false;
    ((DrillItemBase) this).isVertical = false;
    ((DrillItemBase) this).SizeObj = new SizeObject();
    ((DrillItemBase) this).TextureName = "";
    ((DrillItemBase) this).colorFoam = Color.DarkGray;
    ((DrillItemBase) this).Transparency = 120;
    ((DrillItemBase) this).MinPoint = new Point3D();
    ((DrillItemBase) this).MaxPoint = new Point3D();
    ((DrillItemBase) this).planeName = FoamPlaneType.XZ;
    ((DrillItemBase) this).Speeds = (FoamSpeeds) new buNestingCalc();
    ((DrillItemBase) this).Settings = (FoamRuntimeSettings) new buNestingCalc();
    ((DrillItemBase) this).basePattern = (FoamPattern) null;
    ((DrillItemBase) this).BlockFoamType = FoamType.SlicesVertical;
    ((DrillItemBase) this).isWaveOperation = false;
    ((DrillItemBase) this).Pattern = new List<FoamPattern>();
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
    if (((DrillItemBase) data).basePattern != null)
      ((DrillItemBase) this).basePattern = (FoamPattern) new DrillJobCreateEventHandler(((DrillItemBase) data).basePattern);
    ((DrillItemBase) this).Settings = (FoamRuntimeSettings) new buNestingCalc(((DrillItemBase) data).Settings);
    ((DrillItemBase) this).Speeds = (FoamSpeeds) new buNestingCalc(((DrillItemBase) data).Speeds);
    for (int index = 0; index <= ((DrillItemBase) data).Pattern.Count - 1; ++index)
      ((DrillItemBase) this).Pattern.Add((FoamPattern) new DrillJobCreateEventHandler(((DrillItemBase) data).Pattern[index]));
    ((DrillItemBase) this).SizeObj = new SizeObject(((DrillItemBase) data).SizeObj);
  }
}
