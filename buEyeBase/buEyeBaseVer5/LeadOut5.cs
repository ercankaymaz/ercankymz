// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.LeadOut5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class LeadOut5 : buSerilization5
{
  public double ProjectionStartAngles;
  public double ProjectionEndAngles;
  public CamProjectionDirection ProjectionDirection;
  public bool MultiPass;
  public int MultiPassNumberOfRoughCuts;
  public double MultiPassRoughPassSpacing;
  public int MultiPassNumberOFinishCuts;
  public double MultiPassFinishPassSpacing;
  public CamRoughSortType MultiPassSortType;

  public override string ToString() => "AngleLimit: " + ((camStrategy5) this).AngleLimit.ToString();

  static LeadOut5() => camResult.Captions = new List<string>();

  public LeadOut5()
  {
    ((MWCalculationOptions) this).NotchCutPersentage = 90.0;
    ((MWCalculationOptions) this).CutDirection = UpDownDirectionType.UpToDown;
    ((MWCalculationOptions) this).NotchCutType = ProfileNotchCutType.BySawAndMilling;
    ((MWCalculationOptions) this).NotchCutDirection = CamCuttingWayDirectionType.TwoWayDirection;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public LeadOut5(camNotch5 Data)
  {
    ((MWCalculationOptions) this).NotchCutPersentage = 90.0;
    ((MWCalculationOptions) this).CutDirection = UpDownDirectionType.UpToDown;
    ((MWCalculationOptions) this).NotchCutType = ProfileNotchCutType.BySawAndMilling;
    ((MWCalculationOptions) this).NotchCutDirection = CamCuttingWayDirectionType.TwoWayDirection;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
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
    return $"CutDirection: {((MWCalculationOptions) this).CutDirection.ToString()} , NotchCutType: {((MWCalculationOptions) this).NotchCutType.ToString()} , NotchCutDirection: {((MWCalculationOptions) this).NotchCutDirection.ToString()}";
  }
}
