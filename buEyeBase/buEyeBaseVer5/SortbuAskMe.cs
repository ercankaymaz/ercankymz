// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortbuAskMe
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortbuAskMe : buSerilization5
{
  public List<Entity> AskMeEntites;
  public List<int> LastSelectedEntitiesIndex;
  public bool Return;
  public bool ReturnNextGroup;
  public bool GetBack;
  public bool GetBackFromMultiSelection;
  public int SelectedIndex;
  public Point3D CatchPoint;
  public List<int> EntitiesIndex;
  public List<Entity> FoundEntities;
  public List<Entity> SortedEntities;
  public List<Entity> TempEntities;
  public List<List<Entity>> RemovedEntities;
  public List<Point3D> LastMarkPosition;

  public SortbuAskMe()
  {
    ((ViewportDrawOptions) this).MinPoint = new Point3D();
    ((ViewportDrawOptions) this).MidPoint = new Point3D();
    ((ViewportDrawOptions) this).MaxPoint = new Point3D();
    ((ViewportDrawOptions) this).Width = 0.0;
    ((ViewportDrawOptions) this).Height = 0.0;
    ((ViewportDrawOptions) this).Depth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
