// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CamEntitiesToEntities
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CamEntitiesToEntities : buSerilization5
{
  public bool ShowLeadInOutPage;
  public bool ShowOptionPage;
  public bool ShowProgressForm;
  public bool ToolDataToCamData;
  public bool CheckIsCLosedEntities;
  public bool AllowIntercetionCurve;
  public bool SaveDefaultMWParameter;
  public Pnt3D BoxBoundingMin;
  public Pnt3D BoxBoundingMax;

  public CamEntitiesToEntities(LeadIn5 data)
  {
    ((MWCalculationOptions) this).Enable = false;
    ((MWCalculationOptions) this).TangentAngle = 90.0;
    ((MWCalculationOptions) this).LeadType = LeadInOutType.Arc;
    ((MWCalculationOptions) this).ArcRadius = 10.0;
    ((MWCalculationOptions) this).ArcSweepAngle = 90.0;
    ((MWCalculationOptions) this).Length = 10.0;
    ((MWCalculationOptions) this).ExtendLength = 0.0;
    ((MWCalculationOptions) this).ClockDir = ClockDirectionType.CW;
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
    return $"{((MWCalculationOptions) this).Enable.ToString()} ; {((MWCalculationOptions) this).LeadType.ToString()} ; Ang: {((MWCalculationOptions) this).TangentAngle.ToString()} ; Len: {((MWCalculationOptions) this).Length.ToString()}";
  }
}
