// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingPart
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingPart : buSerilization5
{
  public double ParkY2;
  public double ParkY3;
  public double ParkZ1;
  public double ParkZ2;
  public double ParkZ3;
  public double BottimPressZ1Position;
  public double BottimPressZ2Position;
  public double X1SafeDistance;
  public double X1SmallSafeDistance;
  public double X2SafeDistance;
  public double X2SmallSafeDistance;
  public double Y1SafeDistance;
  public double Y1SmallSafeDistance;
  public double Y2SafeDistance;
  public double Y2SmallSafeDistance;
  public double Z1SafeDistance;
  public double Z1SmallSafeDistance;
  public double Z2SafeDistance;
  public double Z2SmallSafeDistance;
  public double Z2SupportDistance;
  public double Z3SafeDistance;
  public double Z3SmallSafeDistance;
  public double XSafeDistance;
  public double XSmallSafeDistance;
  public double YSafeDistance;
  public double YSmallSafeDistance;
  public double Y1MaxPosition;
  public double Y2MinPosition;
  public double BottomDrillPressLimitForEndMaterial;
  public double BottomDrillPressDisForY1AndY2FromMatTop;
  public double BottomDrillBothY1AndY2PressLimit;

  public buNestingPart(SewingTempVars data)
    : this()
  {
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

  public buNestingPart()
  {
    // ISSUE: unable to decompile the method.
  }

  public buNestingPart(SewingSettings data)
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001BE6();

  public buNestingPart()
  {
    ((DrillCNCSettings) this).pathTeachFile = Application.StartupPath;
    ((DrillCNCSettings) this).PunterizWidth = 2.0;
    ((DrillCNCSettings) this).PunterizHeigth = 3.0;
    ((DrillCNCSettings) this).PunterizLength = 30.0;
    ((DrillCNCSettings) this).MoveDistance = 1.0;
    ((DrillCNCSettings) this).RotateDegree = 10.0;
    ((DrillCNCSettings) this).FootHeight = 15.0;
    ((DrillCNCSettings) this).StitchLen = 0.0;
    ((DrillCNCSettings) this).SewingOffset = 0.0;
    ((DrillCNCSettings) this).SewingSpeed = 0.0;
    ((DrillCNCSettings) this).LockStitcCount = 0;
    ((DrillCNCSettings) this).LockStitchType = SewingAddStitchType.OneWay;
    ((DrillCNCSettings) this).PunterizType = SewingPunterizType.CenterLeft;
    ((DrillCNCSettings) this).OffsetType = LeftRightType.Left;
    ((DrillCNCSettings) this).NextRules = SortingNextGroupFindRulesType.ClosestLength;
    ((DrillCNCSettings) this).ShowDialog = false;
    ((DrillCNCSettings) this).pntStart = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingPart(SewingRuntimeSettings data)
  {
    ((DrillCNCSettings) this).pathTeachFile = Application.StartupPath;
    ((DrillCNCSettings) this).PunterizWidth = 2.0;
    ((DrillCNCSettings) this).PunterizHeigth = 3.0;
    ((DrillCNCSettings) this).PunterizLength = 30.0;
    ((DrillCNCSettings) this).MoveDistance = 1.0;
    ((DrillCNCSettings) this).RotateDegree = 10.0;
    ((DrillCNCSettings) this).FootHeight = 15.0;
    ((DrillCNCSettings) this).StitchLen = 0.0;
    ((DrillCNCSettings) this).SewingOffset = 0.0;
    ((DrillCNCSettings) this).SewingSpeed = 0.0;
    ((DrillCNCSettings) this).LockStitcCount = 0;
    ((DrillCNCSettings) this).LockStitchType = SewingAddStitchType.OneWay;
    ((DrillCNCSettings) this).PunterizType = SewingPunterizType.CenterLeft;
    ((DrillCNCSettings) this).OffsetType = LeftRightType.Left;
    ((DrillCNCSettings) this).NextRules = SortingNextGroupFindRulesType.ClosestLength;
    ((DrillCNCSettings) this).ShowDialog = false;
    ((DrillCNCSettings) this).pntStart = new Point3D();
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

  public buNestingPart()
  {
    ((DrillCNCSettings) this).PositionX = 0.0;
    ((DrillCNCSettings) this).PositionY = 0.0;
    ((DrillCNCSettings) this).PositionA = 0.0;
    ((DrillCNCSettings) this).StitchStep = 0.0;
    ((DrillCNCSettings) this).HeadSpeed = 0.0;
    ((DrillCNCSettings) this).FootHeight = 0.0;
    ((DrillCNCSettings) this).StitchedWay = false;
    ((DrillCNCSettings) this).StitchCount = 0;
    ((DrillCNCSettings) this).Style = 0;
    ((DrillCNCSettings) this).Code0 = 0;
    ((DrillCNCSettings) this).Code1 = 0;
    ((DrillCNCSettings) this).Code2 = 0;
    ((DrillCNCSettings) this).Code3 = 0;
    ((DrillCNCSettings) this).Code4 = 0;
    ((DrillCNCSettings) this).Code5 = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingPart(SewingJobItem data)
  {
    ((DrillCNCSettings) this).PositionX = 0.0;
    ((DrillCNCSettings) this).PositionY = 0.0;
    ((DrillCNCSettings) this).PositionA = 0.0;
    ((DrillCNCSettings) this).StitchStep = 0.0;
    ((DrillCNCSettings) this).HeadSpeed = 0.0;
    ((DrillCNCSettings) this).FootHeight = 0.0;
    ((DrillCNCSettings) this).StitchedWay = false;
    ((DrillCNCSettings) this).StitchCount = 0;
    ((DrillCNCSettings) this).Style = 0;
    ((DrillCNCSettings) this).Code0 = 0;
    ((DrillCNCSettings) this).Code1 = 0;
    ((DrillCNCSettings) this).Code2 = 0;
    ((DrillCNCSettings) this).Code3 = 0;
    ((DrillCNCSettings) this).Code4 = 0;
    ((DrillCNCSettings) this).Code5 = 0;
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
}
