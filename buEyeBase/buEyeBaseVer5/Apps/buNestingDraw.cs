// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buNestingDraw
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class buNestingDraw : buSerilization5
{
  public double drillDiameter;
  public double drillStartDistance;
  public double drillEndDistance;
  public double drillHeight;
  public bool drillUseMilling;
  public Point3D drillGroupEndPoint;
  public Point3D slotPoint;
  public double slotDepth;
  public double slotLength;
  public double slotWidth;
  public double slotStartDistance;
  public double slotEndDistance;
  public double slotHeight;
  public double slotAngle;
  public bool slotUseMilling;
  public Point3D slotGroupEndPoint;
  public Point3D rectanglePoint;
  public double rectangleDepth;
  public double rectangleWidth;
  public double rectangleHeigth;
  public double rectangleAngle;
  public bool rectangleFromCenter;
  public bool rectanglePocket;
  public Point3D polygonPoint;
  public double polygonDepth;
  public double polygonDiameter;

  public void GetDirectionVectorFromCornerAndPlane(ref DrillItem Item)
  {
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Top)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 0.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 0.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(0.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(0.0, 1.0, 1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Bottom)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 0.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 0.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(0.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(0.0, 1.0, -1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Front)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 0.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 0.0, 1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Back)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 0.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 0.0, 1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Right)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName != planeBoxNames.Left)
      return;
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 1.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, -1.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 0.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 0.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, -1.0);
    if (((DrillRuntimeSettings) Item).Corner != CornerLocation.BottomCenter)
      return;
    ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
  }

  public void GetDirectionVectorFromCornerAndPlane(ref DrillItemBase Item)
  {
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Top)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 0.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 0.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(0.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(0.0, 1.0, 1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Bottom)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 0.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 0.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(0.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(0.0, 1.0, -1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Front)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 0.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 0.0, 1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Back)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 0.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 0.0, 1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName == planeBoxNames.Right)
    {
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 0.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, -1.0, -1.0);
      if (((DrillRuntimeSettings) Item).Corner == CornerLocation.BottomCenter)
        ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, -1.0, 1.0);
    }
    if (((DrillRuntimeSettings) Item).planeName != planeBoxNames.Left)
      return;
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftBottom)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 1.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftTop)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, -1.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightBottom)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightTop)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, -1.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.LeftCenter)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, 0.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.RightCenter)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 0.0);
    if (((DrillRuntimeSettings) Item).Corner == CornerLocation.TopCenter)
      ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(1.0, 1.0, -1.0);
    if (((DrillRuntimeSettings) Item).Corner != CornerLocation.BottomCenter)
      return;
    ((DrillRuntimeSettings) Item).CornerDirection = new Vector3D(-1.0, 1.0, 1.0);
  }

  public void CreateContourItemOfPanel(ref DrillItem Item, DrillJob Job)
  {
    // ISSUE: unable to decompile the method.
  }
}
