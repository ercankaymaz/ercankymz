// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingProgramSettings
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
public class buNestingProgramSettings : buSerilization5
{
  public double ellipseDepth;
  public double ellipseWidth;
  public double ellipseHeigth;
  public double ellipseAngle;
  public bool ellipseFromCenter;
  public bool ellipsePocket;
  public Point3D circlePoint;
  public double circleDepth;
  public double circleDiameter;
  public bool circleFromCenter;
  public bool circlePocket;
  public bool shapeDrill;
  public double singleCornerWidth;
  public double singleCornerHeight;
  public double singleCornerDepth;
  public bool singleCornerPocket;
  public bool singleCornerStepEnable;
  public double singleCornerStepValue;
  public double VerticalDistance;
  public int VerticalCount;
  public double HorizontalDistance;
  public int HorizontalCount;
  public bool CopyEnable;
  public bool CollisionCheck;

  public void DrillItemToEntity(DrillItemBase Item, SizeObject Size, ref List<buEntity> Entities)
  {
    List<Entity> Entities1 = new List<Entity>();
    this.DrillItemToEntity(Item, Size, ref Entities1);
    Entities = new List<buEntity>();
    buOrdinateDim.Copy(Entities1, ref Entities);
  }

  public void DrillItemToEntity(DrillItemBase Item, SizeObject Size, ref List<Entity> Entities)
  {
    for (int index1 = 0; index1 <= ((DrillRuntimeSettings) Item).Items.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((DrillRuntimeSettings) ((DrillRuntimeSettings) Item).Items[index1]).shapeEntitites.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= ((DrillRuntimeSettings) ((DrillRuntimeSettings) Item).Items[index1]).shapeEntitites[index2].Count - 1; ++index3)
        {
          Entity copiedEntity = (Entity) null;
          buAngularDim.Copy(((DrillRuntimeSettings) ((DrillRuntimeSettings) Item).Items[index1]).shapeEntitites[index2][index3], ref copiedEntity);
          Entities.Add(copiedEntity);
        }
      }
    }
  }

  public void DrillItemToEntity1(DrillItemBase Item, SizeObject Size, ref List<Entity> Entities)
  {
    Entities.Clear();
  }
}
