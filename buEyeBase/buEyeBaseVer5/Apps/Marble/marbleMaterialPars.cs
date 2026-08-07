// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleMaterialPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleMaterialPars : buSerilization5
{
  public double CountertopTrapezHeight;
  public double SocketDefaultWidth;
  public double SocketDefaultHeight;
  public bool InsideAngleCutOnTopAsSize;
  public bool DimensionFromCenter;
  public bool ShowInsideDimensions;

  public string GetItemInfo(marbleCuttingItems[] cutItems, double CutLength)
  {
    string itemInfo = "";
    double num1 = 0.0;
    double num2 = 0.0;
    double ticks = 0.0;
    int num3 = 0;
    for (int index = 0; index <= cutItems.Length - 1; ++index)
    {
      num1 += ((marbleCountertopMainData) cutItems[index]).Length * (double) ((marbleCountertopMainData) cutItems[index]).Count;
      num2 += ((marbleCountertopMainData) cutItems[index]).Length / 100.0 * (CutLength / 100.0) * (double) ((marbleCountertopMainData) cutItems[index]).Count;
      num3 += ((marbleCountertopMainData) cutItems[index]).Count;
    }
    if (Math.Abs(num1) > 0.0)
    {
      $"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} : {num1.ToString("f1")}";
      TimeSpan timeSpan = new TimeSpan((long) ticks);
      string str = $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
      itemInfo = $"{$"{$"{$"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Length} : {num1.ToString("f1")}{Environment.NewLine}"}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Area} : {num2.ToString("f1")}{Environment.NewLine}"}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Count} : {num3.ToString("")}{Environment.NewLine}"}{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Execution} {buLangTranslate.preDef.Time} : {str}";
    }
    return itemInfo;
  }

  public void GetMarbleItemByID(MarbleJob activeJob, int ID, ref MarbleItem MI)
  {
    for (int index = 0; index <= ((MarbleProgramSettings) activeJob).Items.Count - 1; ++index)
    {
      if (((MarbleProgramSettings) ((MarbleProgramSettings) activeJob).Items[index]).ID == ID)
        MI = ((MarbleProgramSettings) activeJob).Items[index];
    }
  }

  public void GetMarbleItemByID(MarbleJob activeJob, int ID, ref MarbleItem MI, ref int IndexITem)
  {
    IndexITem = -1;
    for (int index = 0; index <= ((MarbleProgramSettings) activeJob).Items.Count - 1; ++index)
    {
      if (((MarbleProgramSettings) ((MarbleProgramSettings) activeJob).Items[index]).ID == ID)
      {
        MI = ((MarbleProgramSettings) activeJob).Items[index];
        IndexITem = index;
      }
    }
  }

  public string ItemShapeToName(MarbleShapeTypes Type)
  {
    string name;
    switch (Type)
    {
      case MarbleShapeTypes.Circle:
        name = buLangTranslate.preDef.Cirlce;
        break;
      case MarbleShapeTypes.Rectangle:
        name = buLangTranslate.preDef.Rectangle;
        break;
      case MarbleShapeTypes.RoundRectangle:
        name = buLangTranslate.preDef.Rectangle;
        break;
      case MarbleShapeTypes.KeyHole:
        name = buLangTranslate.preDef.KeyHole;
        break;
      case MarbleShapeTypes.Ellipse:
        name = buLangTranslate.preDef.Ellipse;
        break;
      case MarbleShapeTypes.Hole:
        name = buLangTranslate.preDef.Hole;
        break;
      case MarbleShapeTypes.Polygon:
        name = buLangTranslate.preDef.Polygon;
        break;
      case MarbleShapeTypes.FreeDraw:
        name = buLangTranslate.preDef.FreeDraw;
        break;
      case MarbleShapeTypes.Text:
        name = buLangTranslate.preDef.Text;
        break;
      case MarbleShapeTypes.Triangle:
        name = buLangTranslate.preDef.Triangle;
        break;
      case MarbleShapeTypes.Slot:
        name = buLangTranslate.preDef.Slot;
        break;
      case MarbleShapeTypes.Trepezoid:
        name = buLangTranslate.preDef.Trapezoid;
        break;
      case MarbleShapeTypes.Arc:
        name = buLangTranslate.preDef.Arc;
        break;
      case MarbleShapeTypes.ShipNose:
        name = buLangTranslate.preDef.ShipNose;
        break;
      default:
        name = "";
        break;
    }
    return name;
  }

  public void ItemSizeCalculation(ref MarbleItem Item)
  {
    if ((((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity == null ? 0 : (((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity.Count > 0 ? 1 : 0)) != 0)
    {
      List<Entity> refEntities = new List<Entity>();
      refEntities.AddRange((IEnumerable<Entity>) ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SolidEntity);
      for (int index = 0; index <= ((MarbleScreenCaptureSettings) Item).Edges.Count - 1; ++index)
      {
        if ((!((MarbleMotionCommands) ((MarbleConcaveArcOffsetCalculationType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).DataSlat).Enable ? 0 : (((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid != null ? 1 : 0)) != 0)
          refEntities.Add(((MarbleMachineToolType) ((MarbleContourMenuType) ((MarbleScreenCaptureSettings) Item).Edges[index]).Slat).Solid);
      }
      buCall.\u0001.BoxSizeCalculate(refEntities, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint);
      SortbuFoundItems.CalculateSize(ref ((MarbleScreenCaptureSettings) Item).SizeItem);
    }
    else if ((((MarbleScreenCaptureSettings) Item).EntGroup == null ? 0 : (((\u0084.\u0001) ((MarbleScreenCaptureSettings) Item).EntGroup.Outside).Entities.Count > 0 ? 1 : 0)) != 0)
    {
      buCall.\u0001.BoxSizeCalculate(((MarbleScreenCaptureSettings) Item).EntGroup, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint);
      SortbuFoundItems.CalculateSize(ref ((MarbleScreenCaptureSettings) Item).SizeItem);
    }
    else if ((((MarbleScreenCaptureSettings) Item).EntGroup == null || ((MarbleScreenCaptureSettings) Item).EntGroup.Inside == null ? 0 : (((MarbleScreenCaptureSettings) Item).EntGroup.Inside.Count > 0 ? 1 : 0)) != 0)
    {
      buCall.\u0001.BoxSizeCalculate(((MarbleScreenCaptureSettings) Item).EntGroup, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint);
      SortbuFoundItems.CalculateSize(ref ((MarbleScreenCaptureSettings) Item).SizeItem);
    }
    else
    {
      if ((((MarbleScreenCaptureSettings) Item).EntGroup == null || ((MarbleScreenCaptureSettings) Item).EntGroup.OpenEntities == null ? 0 : (((MarbleScreenCaptureSettings) Item).EntGroup.OpenEntities.Count > 0 ? 1 : 0)) == 0)
        return;
      buCall.\u0001.BoxSizeCalculate(((MarbleScreenCaptureSettings) Item).EntGroup, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MinPoint, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MidPoint, ref ((ViewportDrawOptions) ((MarbleScreenCaptureSettings) Item).SizeItem).MaxPoint);
      SortbuFoundItems.CalculateSize(ref ((MarbleScreenCaptureSettings) Item).SizeItem);
    }
  }
}
