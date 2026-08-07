// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.PolyNode
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Geometry;
using dummy_ptr;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buClipperLib;

public class PolyNode
{
  public Point3D ExtLine1;
  public Point3D ExtLine2;
  public Point3D DimLinePosition;
  public Point3D InsertionPoint;
  public double Height;
  public string TextOverride;
  public Plane Plane;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoLength(double value) => ((Router3AXItem) this).\u0002 = value;

  [CompilerGenerated]
  [SpecialName]
  public double get_infoAngle() => ((Router3AXItem) this).\u0003;

  [CompilerGenerated]
  [SpecialName]
  public void set_infoAngle(double value) => ((Router3AXItem) this).\u0003 = value;

  [CompilerGenerated]
  [SpecialName]
  public entitySortDirection get_sortDirection() => ((Router3AXItem) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_sortDirection(entitySortDirection value) => ((Router3AXItem) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public string get_Tags() => ((Router3AXItem) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_Tags(string value) => ((Router3AXItem) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_CamID() => ((Router3AXItem) this).\u0001;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamID(int value) => ((Router3AXItem) this).\u0001 = value;

  public int ChildCount
  {
    [SpecialName] get => ((DoorRuntimeSettings) this).\u0001.Count;
  }

  public List<IntPoint> Contour
  {
    [SpecialName] get => ((DoorRuntimeSettings) this).\u0001;
  }

  public List<PolyNode> Childs
  {
    [SpecialName] get => ((DoorRuntimeSettings) this).\u0001;
  }

  public PolyNode Parent
  {
    [SpecialName] get => ((DoorRuntimeSettings) this).\u0001;
  }

  public bool IsHole
  {
    [SpecialName] get
    {
      return \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((PolyNode) this);
    }
  }

  public bool IsOpen
  {
    [CompilerGenerated, SpecialName] get => ((DoorRuntimeSettings) this).\u0001;
    [CompilerGenerated, SpecialName] set => ((DoorRuntimeSettings) this).\u0001 = value;
  }
}
