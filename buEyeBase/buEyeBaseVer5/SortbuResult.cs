// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortbuResult
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class SortbuResult : buSerilization5
{
  public List<Point3D> ClickList;
  public ToolBase5 Tool;
  public Point3D FirstPoint;
  public Point3D LastPoint;
  public SortingResultType ResultType;
  public List<int> SelectedEntitiesIndex;
  public List<Entity> LastCalculatedEntities;

  public abstract void m0002B7();
}
