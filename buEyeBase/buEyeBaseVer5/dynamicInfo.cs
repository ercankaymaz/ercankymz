// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.dynamicInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

public class dynamicInfo
{
  public double NotchCutPersentage;
  public ProfileNotchOperationType NotchOPType;
  public UpDownLocationType NotchUpDown;
  public FrontBackType NotchFrontBack;
  public ProfileNotchLocationType NotchSideLocation;
  public ProfileNotchLocationType NotchLengthLocation;
  public UpDownDirectionType CutDirection;
  public ProfileNotchCutType NotchCutType;
  public CamCuttingWayDirectionType NotchCutDirection;
  public bool UpdateEditOperationWithoutOk;
  public List<double> DepthLevels;
  public static byte f00083B;
  public ShapeDataValueType ValueType;
  public int ValueGridIndex;
  public static byte f00083E;
  public double SurfaceOffset;
  public double MinDistance;
  public double MaxDistance;

  public dynamicInfo()
  {
    ((ShapeRuntimeData) this).Return = false;
    ((ShapeRuntimeData) this).ReturnNextGroup = false;
    ((ShapeRuntimeData) this).GetBack = false;
    ((ShapeRuntimeData) this).GetBackFromMultiSelection = false;
    ((ShapeRuntimeData) this).isPointOnEntity = false;
    ((ShapeRuntimeData) this).SelectedIndex = 0;
    ((ShapeRuntimeData) this).CatchPoint = new Point3D();
    ((ShapeRuntimeData) this).FoundEntitiesIndex = new List<int>();
    ((ShapeRuntimeData) this).FoundEntitiesID = new List<string>();
    ((ShapeRuntimeData) this).FoundEntities = new List<buEntity>();
    ((ShapeRuntimeData) this).SortedEntities = new List<buEntity>();
    ((ShapeRuntimeData) this).TempEntities = new List<buEntity>();
    ((ShapeRuntimeData) this).RemovedEntities = new List<List<buEntity>>();
    ((ShapeRuntimeData) this).LastMarkPosition = new List<Point3D>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public dynamicInfo()
  {
    ((ShapeRuntimeData) this).Index = -1;
    ((ShapeRuntimeData) this).BaseIndex = -1;
    ((ShapeRuntimeData) this).Direction = camPathDirectionType.Normal;
    ((ShapeRuntimeData) this).RefPoint = new Point3D();
    ((ShapeRuntimeData) this).StartPoint = new Point3D();
    ((ShapeRuntimeData) this).NextPoint = new Point3D();
    ((ShapeRuntimeData) this).Entity = (buEntity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
