// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCounterTopPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCounterTopPars : buSerilization5
{
  public Color colorSocketAngle;
  public Color colorSocketDimension;
  public Color colorSocketLoction;
  public Color colorTapAngle;
  public Color colorTapDimension;
  public Color colorTapLoction;
  public Color colorCavitySolid;
  public Color colorCavityAngle;
  public Color colorCavityDimension;
  public Color colorCavityLoction;
  public Color colorSlatAngle;
  public Color colorCollapse;
  public marbleCountertopMainData MainData;
  public marbleCountertopInsideData SinkFirstData;
  public marbleCountertopInsideData SinkSecondData;
  public marbleCountertopInsideData BuiltInFirstData;
  public marbleCountertopInsideData BuiltInSecondData;
  public marbleCountertopInsideData SocketFirstData;
  public marbleCountertopInsideData SocketSecondData;

  public bool MarbleItemIntersectionWithLine(
    MarbleJob Job,
    Point3D pntMin,
    Point3D pntMax,
    ref double MinX,
    ref double MaxX)
  {
    bool flag = false;
    MaxX = -999999.0;
    MinX = 99999999.0;
    for (int index1 = 0; index1 <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index1)
    {
      Entity entRectangle = (Entity) null;
      Entity entity = (Entity) new Line(new Point3D(0.0, pntMin.Y), new Point3D(100000.0, pntMax.Y));
      Point3D FirstPoint = new Point3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MinPoint.X + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index1]).OffsetX, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MinPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index1]).OffsetY, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MinPoint.Z);
      Point3D SecondPoint = new Point3D(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MaxPoint.X + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index1]).OffsetX, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MaxPoint.Y + ((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index1]).OffsetY, ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) Job).Items[index1]).SizeItem).MaxPoint.Z);
      buCall.\u0001.Rectangle2Point(FirstPoint, SecondPoint, Plane.XY, ref entRectangle);
      Point3D[] point3DArray = ((ICurve) entity).IntersectWith((ICurve) entRectangle);
      if ((point3DArray == null ? 0 : (point3DArray.Length != 0 ? 1 : 0)) != 0)
      {
        flag = true;
        for (int index2 = 0; index2 <= point3DArray.Length - 1; ++index2)
        {
          if (point3DArray[index2].X > MaxX)
            MaxX = point3DArray[index2].X;
          if (point3DArray[index2].X < MinX)
            MinX = point3DArray[index2].X;
        }
      }
    }
    return flag;
  }

  public void GetAutoMagnetPosition(MarbleJob Job, MarbleItem Item, ref List<Point3D> foundPoint)
  {
  }

  public void CreateMaterial(
    List<Point3D> PLOutter,
    List<List<Point3D>> PLInner,
    MaterialShapes ShapeType,
    double Thickness,
    Image refImage,
    ref MaterialBase5 Mat)
  {
    Entity entSurface = (Entity) null;
    buCall.\u0001.surfaceFromOutterInner(PLOutter, PLInner, Thickness, ref entSurface);
    if (entSurface == null)
      return;
    ((SortOptions) Mat).Points.Clear();
    if (((SortOptions) Mat).InnerPoints != null)
      ((SortOptions) Mat).InnerPoints.Clear();
    if (refImage != null)
      ((SortResult) Mat).matImage = (Image) refImage.Clone();
    entSurface.Regen(0.1);
    ((MostClosestPointOption) Mat).Entities.Clear();
    ((MostClosestPointOption) Mat).Entities.Add(entSurface);
    buVector5.Copy(PLOutter, ref ((SortOptions) Mat).Points);
    buVector5.Copy(PLInner, ref ((SortOptions) Mat).InnerPoints);
    ((SortAskMe) Mat).Shapes = ShapeType;
    Point3D MidPoint = new Point3D();
    buCall.\u0001.BoxSizeCalculate(((SortOptions) Mat).Points, ref ((SortOptions) Mat).BoxMinPoint, ref MidPoint, ref ((SortCamData) Mat).BoxMaxPoint);
    CustomData customData = (CustomData) new ClipperOffset();
    ((CutterRuntimeSettings) customData).set_typeDefination(entityTypeDefination.Material);
    entSurface.EntityData = (object) customData;
    entSurface.LayerName = MarbleColorSettings.layerMarbleSheet.Name;
    entSurface.Color = Color.FromArgb(((hmiUIOptions) ((marbleChamferPars) MarbleEntitiesSettings.varMarbleColorSettings).colorMaterial).Transperancy, ((hmiUIOptions) ((marbleChamferPars) MarbleEntitiesSettings.varMarbleColorSettings).colorMaterial).Color);
    entSurface.ColorMethod = colorMethodType.byEntity;
    entSurface.Selectable = false;
    ((SortAskMe) Mat).Enable = true;
    ((SortResult) Mat).Size.Width = ((SortCamData) Mat).BoxMaxPoint.X - ((SortOptions) Mat).BoxMinPoint.X;
    ((SortResult) Mat).Size.Height = ((SortCamData) Mat).BoxMaxPoint.Y - ((SortOptions) Mat).BoxMinPoint.Y;
    ((SortResult) Mat).Size.Depth = Thickness;
  }

  public int FindMaterialWithPoint(
    List<MaterialBase5> Mats,
    Point3D refPoint,
    ref MaterialBase5 FoundMat)
  {
    int materialWithPoint = -1;
    for (int index = 0; index <= Mats.Count - 1; ++index)
    {
      MaterialBase5 mat = Mats[index];
      if (buCall.\u0001.IsPointInsideBoxsize(refPoint, ((SortOptions) mat).BoxMinPoint, ((SortCamData) mat).BoxMaxPoint, Plane.XY))
      {
        FoundMat = (MaterialBase5) new ShapeMultiCenterData(Mats[index]);
        materialWithPoint = index;
      }
    }
    return materialWithPoint;
  }
}
