// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeSizeInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class ShapeSizeInfo : buSerilization5
{
  public MostClosestPointType MostClosestType;
  public bool UsePointEntities;
  public double Resolution;

  public ShapeSizeInfo(FlatViewSettings data)
  {
    ((SortFilter) this).ShowEdges = true;
    ((SortFilter) this).EdgeColor = Color.Black;
    ((SortFilter) this).EdgeThickness = 2f;
    ((SortFilter) this).SilhouettesDrawingMode = devDept.Eyeshot.silhouettesDrawingType.Never;
    ((SortFilter) this).SilhouetteThickness = 2f;
    ((SortFilter) this).EdgeColorMethod = edgeColorMethodType.SingleColor;
    ((SortOptions) this).ShowInternalWires = false;
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

  public ShapeSizeInfo()
  {
    ((SortOptions) this).SimMovePartIndex = new List<int>();
    ((SortOptions) this).pntSimOffset = new Pnt6D();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public ShapeSizeInfo()
  {
    ((SortOptions) this).Sing = 1.0;
    ((SortOptions) this).ViewportRef = ViewportRefType.Main;
    ((SortOptions) this).GroupType = ShapeGroup.Drill;
    ((SortOptions) this).SetView = viewType.Other;
    ((SortOptions) this).DrawItems = true;
    ((SortOptions) this).ZoomFit = false;
    ((SortOptions) this).OtherEntities = (List<Entity>) null;
    ((SortOptions) this).calcPoint = (Point3D) null;
    ((SortOptions) this).refPoint = (Point3D) null;
    ((SortOptions) this).indexSelectdOP = -1;
    ((SortOptions) this).indexSelectdOPSub = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
