// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingSheetSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSheetSettings : buSerilization5
{
  public double SlotClamperSideClamperMoveMinLength;
  public bool FindFastestPattern;
  public double DoubleHeadWorkTogetherLimit;
  public double DrillPlungeFeed;
  public double MillingFeed;
  public double MillingPlungeFeed;
  public double TopSpindleSpeed;
  public double BottomSpindleSpeed;
  public double distanceSafe;
  public double distanceSmallSafe;
  public double SlotSawPlungeSpeed;
  public double SlotSawCuttingSpeed;
  public bool SlotSawReverseDirection;
  public double SlotSawSafeDistance;
  public double SlotSawRapidDistance;
  public double ContourMinLimit;
  public double ContourMidLimit;
  public double MaterialZeroYMinPosition;
  public double MaterialZeroYMaxPosition;

  public abstract void m001BD9();

  public buNestingSheetSettings()
  {
    ((DrillCNCSettings) this).No = 0;
    ((DrillCNCSettings) this).Defination = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingSheetSettings(SewingCodeDef data)
  {
    ((DrillCNCSettings) this).No = 0;
    ((DrillCNCSettings) this).Defination = "";
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
}
