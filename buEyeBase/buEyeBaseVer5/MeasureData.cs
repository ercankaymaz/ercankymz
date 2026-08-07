// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MeasureData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5;

public class MeasureData
{
  public double TappingDepth;
  public double CutDiameter;
  public double CutLength;
  public double CutDepth;
  public double CutStartDistance;
  public double CutEndDistance;

  public MeasureData()
  {
    ((ShapeArray) this).NotSelectEntities = new List<buEntity>();
    ((ShapeMirror) this).SelectableEntities = new List<buEntity>();
    ((ShapeMirror) this).NotSelectIndex = new List<int>();
    ((ShapeMirror) this).SelectableIndex = new List<int>();
    ((ShapeMirror) this).NotSelectColor = new List<Color>();
    ((ShapeMirror) this).SelectableColor = new List<Color>();
    ((ShapeSizeInfo) this).MostClosestType = MostClosestPointType.OnlyNotCamSelectedEntities;
    ((ShapeSizeInfo) this).UsePointEntities = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
