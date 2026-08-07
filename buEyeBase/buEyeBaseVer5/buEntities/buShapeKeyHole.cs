// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeKeyHole
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using devDept.Geometry;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeKeyHole : buShape
{
  public buSpin spn_toolstepover;
  public buSpin spn_depthstartoffset;
  public buSpin spn_depthendoffset;
  public buSpin spn_plungespeed;

  public override string ToString()
  {
    string str = $"Region Cnt: {((CustomDataSurrogate) this).CurveList.Count.ToString()} - Dir: {((CustomData) this).sortDirection.ToString()}";
    if (((CustomDataSurrogate) this).typeDefination != 0)
      str = $"{str} Type: {((CustomDataSurrogate) this).typeDefination.ToString()}";
    if (((AnalyseEntitiesResult) ((CustomData) this).Info).CamSelected)
      str = $"{str} CamSelected: {((AnalyseEntitiesResult) ((CustomData) this).Info).CamSelected.ToString()}";
    if (((DirectionArrowSetting) ((CustomData) this).Info).Calculated)
      str = $"{str} Calculated: {((DirectionArrowSetting) ((CustomData) this).Info).Calculated.ToString()}";
    if (((AnalyseEntitiesSetting) ((CustomData) this).Info).RefIndex >= 0)
      str = $"{str} Ref Index: {((AnalyseEntitiesSetting) ((CustomData) this).Info).RefIndex.ToString()}";
    return str;
  }

  public abstract void m0017FE();

  public buShapeKeyHole()
    : this()
  {
  }

  public buShapeKeyHole(Point3D start, Point3D end)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(start.X, start.Y, start.Z);
    ((CustomData) this).EndPoint = new Point3D(end.X, end.Y, end.Z);
    ((buUpperLine) this).Update((buEntityUpdateType) 18);
  }

  public buShapeKeyHole(double x1, double y1, double x2, double y2)
    : this()
  {
    ((CustomData) this).StartPoint = new Point3D(x1, y1, 0.0);
    ((CustomData) this).EndPoint = new Point3D(x1, y1, 0.0);
    ((buUpperLine) this).Update((buEntityUpdateType) 18);
  }
}
