// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleReadSurfacePars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleReadSurfacePars : buSerilization5
{
  public bool ShowInsideLocations;
  public bool ShowInsideAngleText;
  public bool ShowOutsideDimensions;

  public void GetBoxSizeSelectedItems(ref MarbleSelection Selected)
  {
    List<Point3D> Points = new List<Point3D>();
    for (int index = 0; index <= ((buMarbleForms) Selected).SelectionItems.Count - 1; ++index)
    {
      Points.Add(((buMarbleForms) ((buMarbleForms) Selected).SelectionItems[index]).pntMin);
      Points.Add(((buMarbleForms) ((buMarbleForms) Selected).SelectionItems[index]).pntMax);
    }
    buCall.\u0001.BoxSizeCalculate(Points, ref ((buMarbleForms) Selected).pntTotalMin, ref ((buMarbleForms) Selected).pntTotalMax);
  }

  public void GetBoxSizeJobItems(MarbleJob activeJob, ref Point3D pntMin, ref Point3D pntMax)
  {
    List<Point3D> Points = new List<Point3D>();
    pntMin = new Point3D();
    pntMax = new Point3D();
    for (int index = 0; index <= ((MarbleProgramSettings) activeJob).Items.Count - 1; ++index)
    {
      Points.Add(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) activeJob).Items[index]).SizeItem).MinPoint);
      Points.Add(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) activeJob).Items[index]).SizeItem).MaxPoint);
    }
    if (Points.Count <= 0)
      return;
    buCall.\u0001.BoxSizeCalculate(Points, ref pntMin, ref pntMax);
  }

  public void GetBoxSizeJobItems(List<MarbleItem> Items, ref Point3D pntMin, ref Point3D pntMax)
  {
    List<Point3D> Points = new List<Point3D>();
    pntMin = new Point3D();
    pntMax = new Point3D();
    for (int index = 0; index <= Items.Count - 1; ++index)
    {
      Points.Add(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Items[index]).SizeItem).MinPoint);
      Points.Add(((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Items[index]).SizeItem).MaxPoint);
    }
    if (Points.Count <= 0)
      return;
    buCall.\u0001.BoxSizeCalculate(Points, ref pntMin, ref pntMax);
  }

  public void GetItemIndexFromItemID(MarbleJob Job, int ItemID, ref int ItemIndex)
  {
    ItemIndex = -1;
    for (int index = 0; index <= ((MarbleProgramSettings) Job).Items.Count - 1; ++index)
    {
      if (((MarbleProgramSettings) ((MarbleProgramSettings) Job).Items[index]).ID == ItemID)
      {
        ItemIndex = index;
        break;
      }
    }
  }

  public void ItemClockDirectionCheck(ref MarbleItem Item, ClockDirectionType CheckDirection)
  {
    if ((Item == null ? 0 : (((MarbleScreenCaptureSettings) Item).EntGroup != null ? 1 : 0)) == 0)
      return;
    ((\u0008.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Direction = buCall.\u0001.EntitiesClockDirection(((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities);
    if (((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Points == null)
      ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Points = new List<Point3D>();
    if (((\u0008.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Direction != CheckDirection)
    {
      ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Points.Clear();
      buCall.\u0001.ChangeEntitiesDirection(ref ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities);
      ((\u0008.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Direction = CheckDirection;
    }
    if (((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Points.Count == 0)
      buCall.\u0001.EntitiesToPointsWithCamDirection(((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities, ref ((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Points);
    ((IntersectNode) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).pntMassCenter = buCall.\u0001.CalculateCentroid(((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Points);
  }
}
