// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingMaterials
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingMaterials : buSerilization5
{
  public double Y3GroupToolMillingZOffset;
  public double Y3GroupXOffset;
  public double Y3GroupYOffset;
  public double Y3GroupZOffset;
  public double Tool61XZeroOffset;
  public double Tool62XZeroOffset;
  public double Tool63XZeroOffset;

  public buNestingMaterials(QuiltingRuntimeSettings data)
  {
    ((DrillCNCSettings) this).QuiltSortSettings = (SortSettings) new ShapeRuntimeData();
    ((DrillCNCSettings) this).Heads = quiltingHeadType.Both;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    ((DrillCNCSettings) this).QuiltSortSettings = (SortSettings) new ShapeRuntimeData(((DrillCNCSettings) data).QuiltSortSettings);
  }

  public static void Copy(QuiltingRuntimeSettings Source, ref QuiltingRuntimeSettings Target)
  {
    Target = (QuiltingRuntimeSettings) new buNestingMaterials(Source);
  }

  public override string ToString() => "";

  public abstract void m001BF4();

  public buNestingMaterials()
  {
    ((DrillCNCSettings) this).CornerAngle = 30.0;
    ((DrillCNCSettings) this).SharpCornerEnable = false;
    ((DrillCNCSettings) this).DevideOnlyLines = true;
    ((DrillCNCSettings) this).DevideLength = 0.0;
    ((DrillMachineSettings) this).HeadDistance = 1000.0;
    ((DrillMachineSettings) this).RoundCorner = 0.0;
    ((DrillMachineSettings) this).ClosedPatternEndExtentLength = 0.0;
    ((DrillMachineSettings) this).OpenPatternEndExtentLength = 0.0;
    ((DrillMachineSettings) this).SortType = quiltingSortType.FirstDoubleHeadThenSingleHead;
    ((DrillMachineSettings) this).MiddleDirection = quiltingDirectionType.FirstHorizontal;
    ((DrillMachineSettings) this).MiddleDirectionCompareAngle = 1.0;
    ((DrillMachineSettings) this).StartFromMiddle = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingMaterials(QuiltingProgramSettings data)
  {
    ((DrillCNCSettings) this).CornerAngle = 30.0;
    ((DrillCNCSettings) this).SharpCornerEnable = false;
    ((DrillCNCSettings) this).DevideOnlyLines = true;
    ((DrillCNCSettings) this).DevideLength = 0.0;
    ((DrillMachineSettings) this).HeadDistance = 1000.0;
    ((DrillMachineSettings) this).RoundCorner = 0.0;
    ((DrillMachineSettings) this).ClosedPatternEndExtentLength = 0.0;
    ((DrillMachineSettings) this).OpenPatternEndExtentLength = 0.0;
    ((DrillMachineSettings) this).SortType = quiltingSortType.FirstDoubleHeadThenSingleHead;
    ((DrillMachineSettings) this).MiddleDirection = quiltingDirectionType.FirstHorizontal;
    ((DrillMachineSettings) this).MiddleDirectionCompareAngle = 1.0;
    ((DrillMachineSettings) this).StartFromMiddle = true;
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

  public static void Copy(QuiltingProgramSettings Source, ref QuiltingProgramSettings Target)
  {
    Target = (QuiltingProgramSettings) new buNestingMaterials(Source);
  }

  public override string ToString()
  {
    return "CornerAngle : " + ((DrillCNCSettings) this).CornerAngle.ToString();
  }

  static buNestingMaterials() => DrillMachineSettings.Captions = new List<string>();
}
