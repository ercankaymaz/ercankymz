// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ShapeLeadInOut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5;

public class ShapeLeadInOut : buSerilization5
{
  public bool UsePlane;
  public bool UseCamSelectedProps;
  public bool IgnoreCamSelected;
  public bool UseEntitySelectedProps;

  public ShapeLeadInOut(ViewportRefType viewportRef)
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
    ((SortOptions) this).ViewportRef = viewportRef;
  }

  public ShapeLeadInOut(ViewportRefType viewportRef, int indexSelectdop, int indexSelectdopSub)
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
    ((SortOptions) this).ViewportRef = viewportRef;
    ((SortOptions) this).indexSelectdOP = indexSelectdop;
    ((SortOptions) this).indexSelectdOPSub = indexSelectdopSub;
  }

  public ShapeLeadInOut()
  {
    ((SortOptions) this).Name = "Material";
    ((SortOptions) this).Points = new List<Point3D>();
    ((SortOptions) this).InnerPoints = (List<List<Point3D>>) null;
    ((SortOptions) this).Display = new SolidItemDisplay(Color.Linen, 100, Color.Brown, 200);
    ((SortOptions) this).StartPoint = new Point3D();
    ((SortOptions) this).BoxMinPoint = new Point3D();
    ((SortCamData) this).BoxMaxPoint = new Point3D();
    ((SortResult) this).Sing = new Point3D(1.0, 1.0, 1.0);
    ((SortResult) this).matImage = (Image) null;
    ((SortResult) this).Size = new SizeObject(400.0, 200.0, 25.0);
    ((SortResult) this).FrontAngle = 0.0;
    ((SortResult) this).BackAngle = 0.0;
    ((SortResult) this).LeftAngle = 0.0;
    ((SortResult) this).RightAngle = 0.0;
    ((SortAskMe) this).Shapes = MaterialShapes.Rectangle;
    ((SortAskMe) this).Purpose = MaterialPurpose.Door;
    ((SortAskMe) this).Enable = true;
    ((SortAskMe) this).Angle = 0.0;
    ((SortAskMe) this).Radius = 10.0;
    ((SortAskMe) this).Diameter = 100.0;
    ((SortAskMe) this).MajorRadius = 100.0;
    ((SortAskMe) this).MinorRadius = 50.0;
    ((SortAskMe) this).RoundRadiue = 5.0;
    ((SortAskMe) this).ChamferLength = 5.0;
    ((SortAskMe) this).dX = 0.0;
    ((SortAskMe) this).dY = 0.0;
    ((SortFoundItems) this).dZ = 0.0;
    ((SortFoundItems) this).OffsetX = 0.0;
    ((SortFoundItems) this).OffsetY = 0.0;
    ((SortFoundItems) this).TopIsZeroPosition = false;
    ((SortFoundItems) this).FileName = Application.StartupPath;
    ((SortFoundItems) this).FileNameImage = Application.StartupPath;
    ((MostClosestPointOption) this).Entities = new List<Entity>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
