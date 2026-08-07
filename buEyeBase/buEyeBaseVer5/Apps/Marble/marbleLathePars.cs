// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleLathePars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleLathePars : buSerilization5
{
  public ColorType colorItemEdge;
  public ColorType colorItemCollopse;
  public ColorType colorItemVacuumCutMaterial;
  public ColorType colorItemVacuumCutEdge;
  public ColorDrawType colorText;
  public ColorDrawType colorItemWire;
  public ColorDrawType colorItemExtension;
  public ColorDrawType colorDirArrowSequence;

  public void FindCornerPathFromContour(
    Entity entBox,
    double zDepth,
    double Offset,
    Entity BaseEntity,
    MarbleCorners Corner,
    ref List<List<Point3D>> PLLOffset)
  {
    // ISSUE: unable to decompile the method.
  }

  public void FindTrimedContour(
    Entity entOffset,
    Entity refEntities,
    ref List<Point3D> TrimedPoints)
  {
    Point3D[] point3DArray = ((ICurve) refEntities).IntersectWith((ICurve) entOffset);
    if (point3DArray.Length != 0)
    {
      List<Point3D> points = new List<Point3D>();
      for (int index = 0; index <= point3DArray.Length - 1; ++index)
        points.Add(point3DArray[index]);
      ICurve[] segments = (ICurve[]) null;
      ((ICurve) entOffset).SplitBy((IList<Point3D>) points, out segments);
      Entity entity = (Entity) null;
      for (int index = 0; index <= segments.Length - 1; ++index)
      {
        if (points.Count == 2)
        {
          if (buConversion5.EQ(segments[index].StartPoint, points[0]) & buConversion5.EQ(segments[index].EndPoint, points[1]))
            entity = (Entity) segments[index];
          else if (buConversion5.EQ(segments[index].StartPoint, points[1]) & buConversion5.EQ(segments[index].EndPoint, points[0]))
            entity = (Entity) segments[index];
        }
      }
      TrimedPoints.Clear();
      if (entity == null)
        return;
      buVector5.Copy(entity.Vertices, ref TrimedPoints);
    }
    else
    {
      bool flag = true;
      for (int index = 0; index <= entOffset.Vertices.Length - 1; ++index)
        flag &= buCall.\u0001.IsPointInsideBoxsize(entOffset.Vertices[index], refEntities.BoxMin, refEntities.BoxMax, Plane.XY);
      if (!flag)
        return;
      buVector5.Copy(entOffset.Vertices, ref TrimedPoints);
    }
  }

  public void CamSawCRotationFeedAnalyze(
    marbleCamSawFeedAnalysisPars Options,
    KinematicBase5 Kinematic,
    ref camTp refCam)
  {
    if (refCam == null)
      return;
    for (int index1 = 0; index1 <= refCam.CamPoints.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= refCam.CamPoints[index1].Points.Count - 2; ++index2)
      {
        if (refCam.CamPoints[index1].Points[index2].Type == 1)
        {
          double num1 = ((TpArcData) refCam.CamPoints[index1].Points[index2 + 1]).P9.C - ((TpArcData) refCam.CamPoints[index1].Points[index2]).P9.C;
          double num2 = buCall.\u0001.Length2D(((TpArcData) refCam.CamPoints[index1].Points[index2]).P9.X, ((TpArcData) refCam.CamPoints[index1].Points[index2]).P9.Y, ((TpArcData) refCam.CamPoints[index1].Points[index2 + 1]).P9.X, ((TpArcData) refCam.CamPoints[index1].Points[index2 + 1]).P9.Y);
          if (num1 > ((MarbleCamType) Options).MaxCStepDegree)
          {
            double num3 = ((MarbleCamType) Options).MaxCStepDegree / num1;
            double num4 = num2 / ((MarbleCamType) Options).MaxXYLength;
            if (num4 > 1.0)
              num4 = 1.0;
            double num5 = refCam.CamPoints[index1].Points[index2 + 1].Feed * num3 * num4 - ((MarbleCamType) Options).FixRatio;
            if (num5 < ((MarbleCamType) Options).MinFeedValue)
              num5 = ((MarbleCamType) Options).MinFeedValue;
            refCam.CamPoints[index1].Points[index2 + 1].Feed = num5;
          }
          else if (num2 >= ((MarbleCamType) Options).MaxXYLength || num1 > ((MarbleCamType) Options).MaxCStepDegree / 2.0)
            ;
        }
      }
    }
  }

  public void MarbleEntityCamDataSet(
    MarbleToolType ToolType,
    double TargetZ,
    ref marbleEntityData Data)
  {
    // ISSUE: unable to decompile the method.
  }

  public void MarbleCamParameterToCamParameter(
    marbleCamPars Data,
    MarbleToolType ToolType,
    CamWireFrameType WireType,
    ref camParameters5 CamPar)
  {
    // ISSUE: unable to decompile the method.
  }
}
