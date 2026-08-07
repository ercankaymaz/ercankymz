// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeMirror
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class ShapeMirror : buSerilization5
{
  public List<buEntity> SelectableEntities;
  public List<int> NotSelectIndex;
  public List<int> SelectableIndex;
  public List<Color> NotSelectColor;
  public List<Color> SelectableColor;

  public ShapeMirror()
  {
    ((ShapeCreateParameters) this).ShowCoordinateSystemIcon = true;
    ((ShapeCreateParameters) this).ShowOrigineIcon = true;
    ((ShapeCreateParameters) this).ShowOrigineCaption = true;
    ((ShapeCreateParameters) this).MovePositionEnable = false;
    ((ShapeCreateParameters) this).ShowCubeIcon = true;
    ((ShapeCreateParameters) this).ShowToolbar = true;
    ((ShapeCreateParameters) this).ShowGrid = false;
    ((ShapeCreateParameters) this).ZoomReverse = false;
    ((ShapeCreateParameters) this).View2D = false;
    ((ShapeCreateParameters) this).OrigineSize = 5;
    ((ShapeCreateParameters) this).GridStepX = 10.0;
    ((ShapeCreateParameters) this).GridStepY = 10.0;
    ((SortSettings) this).Projection = ProjectionModeType.Perspective;
    ((SortSettings) this).DisplayMode = DisplayModeType.Rendered;
    ((SortSettings) this).OrigineIcon = OriginIconType.Ball;
    ((SortSettings) this).BottomColor = Color.DarkGray;
    ((SortFilter) this).IntermediateColor = Color.White;
    ((SortFilter) this).TopColor = Color.SlateGray;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public ShapeMirror(ViewportSettings data)
  {
    ((ShapeCreateParameters) this).ShowCoordinateSystemIcon = true;
    ((ShapeCreateParameters) this).ShowOrigineIcon = true;
    ((ShapeCreateParameters) this).ShowOrigineCaption = true;
    ((ShapeCreateParameters) this).MovePositionEnable = false;
    ((ShapeCreateParameters) this).ShowCubeIcon = true;
    ((ShapeCreateParameters) this).ShowToolbar = true;
    ((ShapeCreateParameters) this).ShowGrid = false;
    ((ShapeCreateParameters) this).ZoomReverse = false;
    ((ShapeCreateParameters) this).View2D = false;
    ((ShapeCreateParameters) this).OrigineSize = 5;
    ((ShapeCreateParameters) this).GridStepX = 10.0;
    ((ShapeCreateParameters) this).GridStepY = 10.0;
    ((SortSettings) this).Projection = ProjectionModeType.Perspective;
    ((SortSettings) this).DisplayMode = DisplayModeType.Rendered;
    ((SortSettings) this).OrigineIcon = OriginIconType.Ball;
    ((SortSettings) this).BottomColor = Color.DarkGray;
    ((SortFilter) this).IntermediateColor = Color.White;
    ((SortFilter) this).TopColor = Color.SlateGray;
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

  public ShapeMirror()
  {
    ((SortFilter) this).ShowEdges = true;
    ((SortFilter) this).EdgeColor = Color.Black;
    ((SortFilter) this).EdgeThickness = 2f;
    ((SortFilter) this).SilhouettesDrawingMode = silhouettesDrawingType.Never;
    ((SortFilter) this).SilhouetteThickness = 2f;
    ((SortFilter) this).EdgeColorMethod = edgeColorMethodType.SingleColor;
    ((SortOptions) this).ShowInternalWires = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
