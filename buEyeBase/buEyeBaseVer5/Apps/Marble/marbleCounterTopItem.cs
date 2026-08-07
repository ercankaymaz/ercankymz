// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCounterTopItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCounterTopItem : buSerilization5
{
  public Color colorMainAngleText;
  public Color colorMainDimension;

  public void AddCurvatureToConcaveEntities(
    buEntity Ent,
    List<buEntity> CurveEntities,
    ref List<buEntity> concaveEL)
  {
    if (!(((AnalyseEntitiesSetting) ((CustomData) Ent).Info).RefIndex >= 0 & ((AnalyseEntitiesSetting) ((CustomData) Ent).Info).RefIndex <= CurveEntities.Count - 1))
      return;
    int refIndex = ((AnalyseEntitiesSetting) ((CustomData) Ent).Info).RefIndex;
    double num1 = buCall.\u0001.Length3D(((CustomDataSurrogate) concaveEL[0]).Vertices[0], ((CustomDataSurrogate) CurveEntities[refIndex]).Vertices[0]);
    double num2 = buCall.\u0001.Length3D(((CustomDataSurrogate) concaveEL[0]).Vertices[0], ((CustomDataSurrogate) CurveEntities[refIndex]).Vertices[((CustomDataSurrogate) CurveEntities[refIndex]).Vertices.Count - 1]);
    List<Point3D> points = new List<Point3D>();
    points.Add(((CustomDataSurrogate) concaveEL[0]).Vertices[0]);
    if (num1 <= num2)
    {
      buVector5.Add(((CustomDataSurrogate) CurveEntities[refIndex]).Vertices, ref points);
    }
    else
    {
      List<Point3D> copiedPoint = new List<Point3D>();
      buVector5.Copy(((CustomDataSurrogate) CurveEntities[refIndex]).Vertices, ref copiedPoint);
      copiedPoint.Reverse();
      buVector5.Add(copiedPoint, ref points);
    }
    points.Add(((CustomDataSurrogate) concaveEL[0]).Vertices[((CustomDataSurrogate) concaveEL[0]).Vertices.Count - 1]);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref points);
    concaveEL[0] = (buEntity) new buShape(points);
  }
}
