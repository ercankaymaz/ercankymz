// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeSlot
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using devDept.Geometry;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeSlot : buShape
{
  public buSpin spn_bottomoffst;
  public buButton btn_cancel;
  public buSpin spn_depthstep;

  public buShapeSlot(buEntity outer)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).SortAndOrient = true;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).CurveList.Add(buAngularDim.Copy(outer));
    ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CustomDataSurrogate) outer).Orientation);
    ((buUpperLine) this).Update((buEntityUpdateType) 34);
  }

  public buShapeSlot(buEntity[] contours)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).SortAndOrient = true;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    buRadialDim.Copy(((IEnumerable<buEntity>) contours).ToList<buEntity>(), ref ((CustomDataSurrogate) this).CurveList);
    ((buUpperLine) this).Update((buEntityUpdateType) 34);
  }

  public buShapeSlot(List<buEntity> contours)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).SortAndOrient = true;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    buRadialDim.Copy(contours, ref ((CustomDataSurrogate) this).CurveList);
    ((buUpperLine) this).Update((buEntityUpdateType) 34);
  }

  public buShapeSlot(buEntity outer, Plane pln, bool sortAndOrient = true)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).SortAndOrient = true;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).CurveList.Add(buAngularDim.Copy(outer));
    ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CustomDataSurrogate) outer).Orientation);
    ((CustomDataSurrogate) this).Plane = (Plane) pln.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 34);
  }

  public buShapeSlot(List<buEntity> contours, Plane pln, bool sortAndOrient = true)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).SortAndOrient = true;
    ((CustomDataSurrogate) this).Plane = Plane.XY;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).SortAndOrient = sortAndOrient;
    buRadialDim.Copy(contours, ref ((CustomDataSurrogate) this).CurveList);
    ((CustomDataSurrogate) this).Plane = (Plane) pln.Clone();
    ((buUpperLine) this).Update((buEntityUpdateType) 35);
  }
}
