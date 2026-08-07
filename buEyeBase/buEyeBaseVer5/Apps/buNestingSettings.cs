// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingSettings : buSerilization5
{
  public int polygonSides;
  public double polygonAngle;
  public bool polygonPocket;
  public Point3D slotShapePoint;
  public double slotShapeDepth;
  public double slotShapeWidth;
  public double slotShapeHeight;
  public double slotShapeAngle;
  public bool slotShapePocket;
  public Point3D ellipsePoint;

  public void CreateEntitiesOfItem(DrillItemBase ItemBase, ref DrillItem Item, double Sing = -1.0)
  {
    // ISSUE: unable to decompile the method.
  }

  public void DrillItemToEntity(
    DrillItemBase Item,
    SizeObject Size,
    ref List<List<buEntity>> Entities)
  {
    List<List<Entity>> Entities1 = new List<List<Entity>>();
    this.DrillItemToEntity(Item, Size, ref Entities1);
    Entities = new List<List<buEntity>>();
    buOrdinateDim.Copy(Entities1, ref Entities);
  }

  public void DrillItemToEntity(
    DrillItemBase Item,
    SizeObject Size,
    ref List<List<Entity>> Entities)
  {
    Entities = new List<List<Entity>>();
    List<Entity> Entities1 = new List<Entity>();
    ((buNestingProgramSettings) this).DrillItemToEntity(Item, Size, ref Entities1);
    Entities.Add(Entities1);
  }
}
