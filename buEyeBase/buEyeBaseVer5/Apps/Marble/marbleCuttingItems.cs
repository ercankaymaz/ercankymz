// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCuttingItems
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCuttingItems : buSerilization5
{
  public double ShapeArcOutsideLength;
  public double ShapeArcHeight;
  public double ShapeArcThickness;
  public double ShapeEllipsePieWidth;
  public double ShapeEllipsePieHeight;
  public double ShapeEllipsePieSweepAngle;
  public double ShapeEllipsePieAngle;

  public marbleCuttingItems()
  {
    ((MarbleRuntimeSettings) this).Length = 1000.0;
    ((MarbleRuntimeSettings) this).NeededWidth = 0.0;
    ((MarbleRuntimeSettings) this).NeededHeight = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockZWidth = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockZHeight = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockY1Width = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockY1Height = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockY2Width = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockY2Height = 0.0;
    ((MarbleRuntimeSettings) this).ConnectSmallGap = true;
    ((MarbleRuntimeSettings) this).GapConnection = 0.1;
    ((MarbleRuntimeSettings) this).SortResolituon = 0.05;
    ((MarbleRuntimeSettings) this).MinPointFilterLength = 0.0;
    ((MarbleRuntimeSettings) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((MarbleRuntimeSettings) this).NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((MarbleRuntimeSettings) this).MaxClamper = 4;
    ((MarbleRuntimeSettings) this).Transparency = 200;
    ((MarbleRuntimeSettings) this).color = Color.DarkGray;
    ((MarbleRuntimeSettings) this).FileName = "";
    ((MarbleRuntimeSettings) this).FullName = "";
    ((MarbleRuntimeSettings) this).Name = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleCuttingItems(CreateProfileFromDataOptions data)
  {
    ((MarbleRuntimeSettings) this).Length = 1000.0;
    ((MarbleRuntimeSettings) this).NeededWidth = 0.0;
    ((MarbleRuntimeSettings) this).NeededHeight = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockZWidth = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockZHeight = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockY1Width = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockY1Height = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockY2Width = 0.0;
    ((MarbleRuntimeSettings) this).SupportBlockY2Height = 0.0;
    ((MarbleRuntimeSettings) this).ConnectSmallGap = true;
    ((MarbleRuntimeSettings) this).GapConnection = 0.1;
    ((MarbleRuntimeSettings) this).SortResolituon = 0.05;
    ((MarbleRuntimeSettings) this).MinPointFilterLength = 0.0;
    ((MarbleRuntimeSettings) this).IntersectionRules = SortingIntersectionRulesType.LowerIndex;
    ((MarbleRuntimeSettings) this).NextFroupRules = SortingNextGroupFindRulesType.ClosestLength;
    ((MarbleRuntimeSettings) this).MaxClamper = 4;
    ((MarbleRuntimeSettings) this).Transparency = 200;
    ((MarbleRuntimeSettings) this).color = Color.DarkGray;
    ((MarbleRuntimeSettings) this).FileName = "";
    ((MarbleRuntimeSettings) this).FullName = "";
    ((MarbleRuntimeSettings) this).Name = "";
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
    return "Length :" + ((MarbleRuntimeSettings) this).Length.ToString();
  }

  public abstract void m001ED7();

  public marbleCuttingItems()
  {
    ((MarbleRuntimeSettings) this).UpdateRuntime = false;
    ((MarbleRuntimeSettings) this).Finished = false;
    ((MarbleRuntimeSettings) this).ToolName = "";
    ((MarbleRuntimeSettings) this).ToolIndex = -1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleCuttingItems(OperationUpdateArg data)
  {
    ((MarbleRuntimeSettings) this).UpdateRuntime = false;
    ((MarbleRuntimeSettings) this).Finished = false;
    ((MarbleRuntimeSettings) this).ToolName = "";
    ((MarbleRuntimeSettings) this).ToolIndex = -1;
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
    return "Finished :" + ((MarbleRuntimeSettings) this).Finished.ToString();
  }

  public abstract void m001EDB();
}
