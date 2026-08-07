// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buShapeEllipse
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class buShapeEllipse : buShape
{
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;

  public buShapeEllipse(buEntity[] curveList)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).\u0001 = true;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    buRadialDim.Copy(((IEnumerable<buEntity>) curveList).ToList<buEntity>(), ref ((CustomDataSurrogate) this).CurveList);
    ((buUpperLine) this).Update((buEntityUpdateType) 26);
  }

  public buShapeEllipse(buEntity another)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).\u0001 = true;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).CurveList.Add(buAngularDim.Copy(another));
    ((CustomDataSurrogate) this).Orientation = new OrientationAngle(((CustomDataSurrogate) another).Orientation);
    ((buUpperLine) this).Update((buEntityUpdateType) 26);
  }

  public buShapeEllipse(List<buEntity> curveList, bool sortAndOrient)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).\u0001 = true;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).\u0001 = sortAndOrient;
    buRadialDim.Copy(curveList, ref ((CustomDataSurrogate) this).CurveList);
    ((buUpperLine) this).Update((buEntityUpdateType) 27);
  }

  public buShapeEllipse(List<buEntity> curveList, double closureTol)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).\u0001 = true;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).\u0001 = closureTol;
    buRadialDim.Copy(curveList, ref ((CustomDataSurrogate) this).CurveList);
    ((buUpperLine) this).Update((buEntityUpdateType) 28);
  }

  public buShapeEllipse(List<buEntity> curveList, double closureTol, bool sortAndOrient)
  {
    ((CustomDataSurrogate) this).CurveList = new List<buEntity>();
    ((CustomDataSurrogate) this).\u0001 = true;
    // ISSUE: explicit constructor call
    ((buMultilineText) this).\u002Ector();
    ((CustomDataSurrogate) this).\u0001 = sortAndOrient;
    ((CustomDataSurrogate) this).\u0001 = closureTol;
    buRadialDim.Copy(curveList, ref ((CustomDataSurrogate) this).CurveList);
    ((buUpperLine) this).Update((buEntityUpdateType) 29);
  }
}
