// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingSheet
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSheet : buSerilization5
{
  public double MaterialBigLimit;
  public bool MoveSafeDistanceAtClamperSideForTop;
  public bool ResetDrillPistonWhileMoveSafeAfterDrill;
  public bool SearchVerToolEvenMultiHorDrillAvailableForTop;
  public bool SearchVerToolEvenMultiHorDrillAvailableForBottom;
  public bool MoveSafeDistanceAtClamperSideForFront;
  public bool MoveSafeDistanceAtClamperSideForBack;
  public bool MoveSafeDistanceAtClamperSideForLeftRight;
  public bool MoveY3AxisToSafeIfOperationAtClamperSideFroBottom;
  public bool MirrorCalculationForFront;
  public bool MirrorCalculationForBack;
  public bool MirrorCalculationForTop;
  public bool MoveXYSameTimeForBottom;
  public bool LeaveClamperSideWhileClamperChangeForBottom;
  public double LeaveYDistanceWhileClamperChangeForBottom;
  public bool BackOperationsAlwaysWillLastOperation;

  public buNestingSheet()
  {
    ((DrillCNCSettings) this).PointThickness = 5.0;
    ((DrillCNCSettings) this).PointColor = Color.Blue;
    ((DrillCNCSettings) this).PointLayerName = "";
    ((DrillCNCSettings) this).DrawigThickness = 1.0;
    ((DrillCNCSettings) this).DrawingColor = Color.Red;
    ((DrillCNCSettings) this).DrawingLayerName = "";
    ((DrillCNCSettings) this).StartIndex = -1;
    ((DrillCNCSettings) this).EndIndex = -1;
    ((DrillCNCSettings) this).ProtectEntityStitchLen = false;
    ((DrillCNCSettings) this).ApplyNewLenUpToEnd = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingSheet(SewingDevideOptions data)
  {
    ((DrillCNCSettings) this).PointThickness = 5.0;
    ((DrillCNCSettings) this).PointColor = Color.Blue;
    ((DrillCNCSettings) this).PointLayerName = "";
    ((DrillCNCSettings) this).DrawigThickness = 1.0;
    ((DrillCNCSettings) this).DrawingColor = Color.Red;
    ((DrillCNCSettings) this).DrawingLayerName = "";
    ((DrillCNCSettings) this).StartIndex = -1;
    ((DrillCNCSettings) this).EndIndex = -1;
    ((DrillCNCSettings) this).ProtectEntityStitchLen = false;
    ((DrillCNCSettings) this).ApplyNewLenUpToEnd = false;
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

  public abstract void m001BD3();

  public buNestingSheet()
  {
    ((DrillCNCSettings) this).CornerTyppe = OffsetCornerType.Line;
    ((DrillCNCSettings) this).ClosedType = CamClosedContourType.Inner;
    ((DrillCNCSettings) this).OpenType = CamOpenContourType.Left;
    ((DrillCNCSettings) this).MakeSameStartOffsetYLevel = true;
    ((DrillCNCSettings) this).MakeSameEndOffsetYLevel = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingSheet(SewingOffsetOptions data)
  {
    ((DrillCNCSettings) this).CornerTyppe = OffsetCornerType.Line;
    ((DrillCNCSettings) this).ClosedType = CamClosedContourType.Inner;
    ((DrillCNCSettings) this).OpenType = CamOpenContourType.Left;
    ((DrillCNCSettings) this).MakeSameStartOffsetYLevel = true;
    ((DrillCNCSettings) this).MakeSameEndOffsetYLevel = true;
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

  public buNestingSheet()
  {
    ((DrillCNCSettings) this).EntityIndex = -1;
    ((DrillCNCSettings) this).VertexIndex = -1;
    ((DrillCNCSettings) this).PickType = SewingPickClickType.None;
    ((DrillCNCSettings) this).EntitySelectType = SewingPickEntitySelectType.StartPoint;
    ((DrillCNCSettings) this).refPoint = new Point3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buNestingSheet(SewingPickType data)
  {
    ((DrillCNCSettings) this).EntityIndex = -1;
    ((DrillCNCSettings) this).VertexIndex = -1;
    ((DrillCNCSettings) this).PickType = SewingPickClickType.None;
    ((DrillCNCSettings) this).EntitySelectType = SewingPickEntitySelectType.StartPoint;
    ((DrillCNCSettings) this).refPoint = new Point3D();
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

  public override string ToString()
  {
    return $"Ent: {((DrillCNCSettings) this).EntityIndex.ToString()} - Ver: {((DrillCNCSettings) this).VertexIndex.ToString()} - Pick Type: {((DrillCNCSettings) this).PickType.ToString()}";
  }
}
