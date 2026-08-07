// Decompiled with JetBrains decompiler
// Type: buCore.buCamCalc
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using buClass.Apps;
using buCore.buClipperLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCore;

public class buCamCalc
{
  public EntitiesResolution EntityDevideResolution = new EntitiesResolution();
  public Pnt3D Pnt3LastPoint = new Pnt3D();
  public Pnt6D Pnt6LastPoint = new Pnt6D();
  public Pnt9D Pnt9LastPoint = new Pnt9D();
  public Pnt9DCam Pnt9CamLastPoint = new Pnt9DCam();
  public Color colorG1 = Color.Blue;
  public Color colorG0 = Color.Brown;
  public Color colorLeadIn = Color.Cyan;
  public Color colorLeadOut = Color.Orange;
  public Color colorPlunge = Color.Lime;
  public Color colorLeave = Color.Red;
  public Color colorMark = Color.Blue;
  public double entThickness = 2.0;
  public static List<List<Pnt3D>> pntTeachGrids = new List<List<Pnt3D>>();

  public buCamCalc()
  {
    if (!buVector.smethod_0(nameof (buCamCalc)))
      throw new RegisterException(nameof (buCamCalc));
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_0(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_1(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_2 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationEventHandler_3 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "", ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.calculationErrorEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.calculationErrorEventHandler_0(new CalculationErrorEventArg("", "", "", 0));
  }

  public event CalculationEventHandler CalculationInProgress;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;

  public void CalculateGrindingContour(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    camParameters camPars,
    SimulationBase simPars,
    ref camBase calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      calcCam.Tool = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      List<Triangle3D> Triangles = new List<Triangle3D>();
      KinematicItem kinematicItem = new KinematicItem();
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
      kinematicItem.Axis.A = false;
      kinematicItem.Axis.C = false;
      eEntities eEntities = (eEntities) new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      kinematicItem.Entities.Add(eEntities);
      calcCam.Kinematic.Items.Add(kinematicItem);
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      int int32 = Convert.ToInt32((double) Entities.Count / 100.0);
      int num1 = 0;
      for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
      {
        eEntities copiedEnt1 = new eEntities();
        if (Entities[index1].Count > 0)
        {
          eEntities copiedEnt2 = new eEntities();
          List<Pnt3D> TargetList = new List<Pnt3D>();
          eEntities.CopyEntity(Entities[index1][0], ref copiedEnt2);
          buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList);
          List<Pnt6D> Points = new List<Pnt6D>();
          buAppCalc.cVector.EntityToPoint(Entities[index1], buSystem.EntitiesResolution, ref Points);
          if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
            TargetList.Reverse();
          CamPoint camPoint2 = new CamPoint();
          camPoint2.Type = 0;
          camPoint2.IsRapid = true;
          if (Points.Count > 1)
          {
            Pnt3D Pnt1 = new Pnt3D(Points[0]);
            OrientationAngle orientationAngle1 = new OrientationAngle(Points[0]);
            OrientationAngle orientationAngle2 = new OrientationAngle(Points[0]);
            Pnt6D pnt6D2 = new Pnt6D();
            Pnt6D pnt6D3 = new Pnt6D(new Pnt3D(Pnt1.X, Pnt1.Y, camPars.Distances.Safe), new OrientationAngle());
            Pnt3D Pnt2 = new Pnt3D(Pnt1.X, Pnt1.Y, camPars.Distances.Safe);
            Pnt6D pnt6D4 = new Pnt6D(pnt6D3);
            Pnt9DCam pnt9Dcam1 = new Pnt9DCam(new Pnt6D(0.0, 0.0, camPars.Distances.Safe), camPars.Speeds.Leave, 0, false, true);
            camPoint2.EntitiesPlunge.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(Pnt1), this.colorPlunge, this.entThickness));
            camPoint2.Points.Add(pnt9Dcam1);
            ++camPoint2.NumberOfLeaveMovement;
            Pnt3D Pnt3 = new Pnt3D(Pnt1);
            Pnt6D pnt6D5 = new Pnt6D(pnt6D3);
            Pnt9DCam pnt9Dcam2 = new Pnt9DCam(pnt6D3, camPars.Speeds.Rapid, 0, false);
            camPoint2.Points.Add(pnt9Dcam2);
            Pnt9DCam pnt9Dcam3 = new Pnt9DCam(new Pnt6D(new Pnt3D(Pnt1.X, Pnt1.Y, Pnt1.Z), new OrientationAngle()), camPars.Speeds.Plunge, 1, true, false);
            camPoint2.Points.Add(pnt9Dcam3);
            ++camPoint2.NumberOfPlungeMovement;
            List<Pnt3D> vertice = new List<Pnt3D>();
            double num2 = 0.0;
            if (Points.Count > 0)
              vertice.Add(new Pnt3D(Points[0]));
            for (int index2 = 1; index2 <= Points.Count - 1; ++index2)
            {
              Pnt3D pnt3D2 = new Pnt3D(Points[index2]);
              OrientationAngle Pnt4 = new OrientationAngle(Points[index2]);
              double feed = camPars.Speeds.Feed;
              Pnt6D pnt6D6 = new Pnt6D(new Pnt3D(Points[index2].X, Points[index2].Y, Points[index2].Z), new OrientationAngle());
              camPoint2.Points.Add(new Pnt9DCam(pnt6D6, feed, 1));
              vertice.Add(new Pnt3D(Points[index2]));
              Pnt3 = new Pnt3D(Points[index2]);
              Pnt6D pnt6D7 = new Pnt6D(pnt6D6);
              OrientationAngle orientationAngle3 = new OrientationAngle(Pnt4);
            }
            if (vertice.Count >= 2)
            {
              geoPolyline geoPolyline = new geoPolyline(vertice, this.colorG1, this.entThickness);
              if (num2 == Convert.ToDouble((object) EntityPurposeType.LeadIn))
              {
                geoPolyline.Color = this.colorLeadIn;
                camPoint2.EntitiesLeadIn.Add((geoEntity) geoPolyline);
              }
              else if (num2 == Convert.ToDouble((object) EntityPurposeType.LeadOut))
              {
                geoPolyline.Color = this.colorLeadOut;
                camPoint2.EntitiesLeadOut.Add((geoEntity) geoPolyline);
              }
              else
                camPoint2.EntitiesG1.Add((geoEntity) geoPolyline);
              List<Pnt3D> pnt3DList = new List<Pnt3D>();
            }
            Pnt6D pnt6D8 = new Pnt6D(new Pnt3D(Pnt3.X, Pnt3.Y, camPars.Distances.Safe), new OrientationAngle());
            Pnt9DCam pnt9Dcam4 = new Pnt9DCam(pnt6D8, camPars.Speeds.Leave, 1, false, true);
            camPoint2.Points.Add(pnt9Dcam4);
            ++camPoint2.NumberOfLeaveMovement;
            camPoint2.EntitiesLeave.Add((geoEntity) new geoLine(new Pnt3D(Pnt3), new Pnt3D(pnt6D8), this.colorLeave, this.entThickness));
            if (camPoint2.Points.Count > 0)
              camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
            double num3 = 0.0;
            for (int index3 = 1; index3 <= camPoint2.Points.Count - 1; ++index3)
            {
              List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
              double num4 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index3 - 1]), new Pnt3D(camPoint2.Points[index3]));
              if (camPoint2.Points[index3].Type == 0)
              {
                if (simPars.DevideG0Movement)
                {
                  if (num4 > simPars.G0DevideLength & simPars.G0DevideLength > 0.0)
                  {
                    double dt = simPars.G0DevideLength / num4;
                    buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index3 - 1]), new Pnt6D(camPoint2.Points[index3]), dt, ref CalculatedPoints);
                    CalculatedPoints.RemoveAt(0);
                    camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
                  }
                  else
                    camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index3]));
                }
                else
                  camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index3]));
              }
              else if (simPars.DevideG1Movement)
              {
                if (num4 > simPars.G1DevideLength & simPars.G1DevideLength > 0.0)
                {
                  double dt = simPars.G1DevideLength / num4;
                  buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index3 - 1]), new Pnt6D(camPoint2.Points[index3]), dt, ref CalculatedPoints);
                  CalculatedPoints.RemoveAt(0);
                  camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
                  num3 = 0.0;
                }
                else if (simPars.UseG1Filter)
                {
                  if (num3 > simPars.G1FilterLength)
                  {
                    camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index3]));
                    num3 = 0.0;
                  }
                  else
                    num3 += num4;
                }
                else
                  camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index3]));
              }
              else
                camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index3]));
            }
            eEntities.CopyEntity(copiedEnt2, ref copiedEnt1);
            calcCam.CamPoints.Add(camPoint2);
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double) index1 / (double) (Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num1 > 0 && num1 % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num1;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
          }
          buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculateGrindingContourSaw(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    camParameters camPars,
    GrindingOperations Operation,
    ref camBase calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      calcCam.Tool = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      List<List<Pnt6D>> pnt6DListList = new List<List<Pnt6D>>();
      List<Triangle3D> Triangles = new List<Triangle3D>();
      KinematicItem kinematicItem = new KinematicItem();
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
      kinematicItem.Axis.A = false;
      kinematicItem.Axis.C = true;
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, -Kinematic.RotateCenterOffsetOfC.Y, -Kinematic.RotateCenterOffsetOfC.Z), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 1.0, 0.0), new EntityResolution(), ref Triangles);
      eSurface eSurface = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      calcCam.Kinematic.Items.Add(kinematicItem);
      calcCam.Kinematic.MovePartRuntimeOffset.X = 0.0;
      calcCam.Kinematic.MovePartRuntimeOffset.Y = -Kinematic.RotateCenterOffsetOfC.Y;
      calcCam.Kinematic.MovePartRuntimeOffset.Z = -Kinematic.RotateCenterOffsetOfC.Z;
      bool useTangentLimit = camPars.Strategy.UseTangentLimit;
      double angleLimit = camPars.Strategy.AngleLimit;
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      int int32 = Convert.ToInt32((double) Entities.Count / 100.0);
      int num1 = 0;
      for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
      {
        List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
        if (Entities[index1].Count >= 1)
        {
          List<Pnt6D> Points = new List<Pnt6D>();
          List<Pnt6D> pnt6DList2 = new List<Pnt6D>();
          buAppCalc.cVector.EntityToPoint(Entities[index1], buSystem.EntitiesResolution, ref Points);
          buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points, 0.01);
          if (Points.Count > 1)
          {
            double num2 = 0.0;
            double c1 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[1]), new Pnt3D(Points[0]));
            if (Entities[index1].Count == 1 & Points[0].C != 0.0)
              c1 = Points[0].C;
            double num3 = c1;
            pnt6DList1.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, c1));
            for (int index2 = 1; index2 <= Points.Count - 2; ++index2)
            {
              bool flag = false;
              double c2 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index2]), new Pnt3D(Points[index2 - 1]));
              double c3;
              double num4;
              if (useTangentLimit)
              {
                num2 = Points[index2 - 1].A - Points[index2].A;
                if (Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C) > 185.0)
                {
                  if (pnt6DList1[pnt6DList1.Count - 1].C > c2)
                    c2 += 360.0;
                  else
                    c2 -= 360.0;
                }
                c3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index2 + 1]), new Pnt3D(Points[index2]));
                angleLimit = camPars.Strategy.AngleLimit;
                double num5 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index2]), new Pnt3D(Points[index2]), new Pnt3D(Points[index2 + 1]), new WorkPlane());
                num4 = 180.0 - num5;
                if (num4 >= 360.0 - angleLimit)
                  num4 = 360.0 - num5;
                Math.Abs(c2 - num3);
                if (Math.Abs(num2) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
                {
                  pnt6DListList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c3));
                  flag = true;
                }
              }
              else
              {
                angleLimit = camPars.Strategy.AngleLimit;
                double num6 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index2]), new Pnt3D(Points[index2]), new Pnt3D(Points[index2 + 1]), new WorkPlane());
                num4 = 180.0 - num6;
                if (num4 >= 360.0 - angleLimit)
                  num4 = 360.0 - num6;
                c3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index2 + 1]), new Pnt3D(Points[index2]));
                if (num4 > angleLimit)
                {
                  pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                  pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2 + 1].A, 0.0, c3));
                  flag = true;
                }
                Math.Abs(c2 - num3);
                if (Math.Abs(num2) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
                {
                  pnt6DListList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c3));
                  flag = true;
                }
              }
              if (!flag)
              {
                if (num4 > angleLimit & useTangentLimit)
                {
                  pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                  pnt6DListList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2 + 1].A, 0.0, c3));
                }
                else
                {
                  if (useTangentLimit)
                  {
                    double num7 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                    if (num7 >= 360.0 - angleLimit)
                    {
                      if (c2 > pnt6DList1[pnt6DList1.Count - 1].C)
                        c2 -= 360.0;
                      else
                        c2 += 360.0;
                      num7 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                    }
                    if (num7 > 185.0)
                      c2 += 360.0;
                  }
                  pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                  if (Math.Abs(c2 - c3) > 180.1)
                  {
                    double num8 = c2 - c3;
                    if (c2 > c3)
                    {
                      double lower = buNumeric.RoundToLower(Math.Abs(num8) / 360.0);
                      c3 += 360.0 + lower * 360.0;
                    }
                    else
                    {
                      double lower = buNumeric.RoundToLower(Math.Abs(num8) / 360.0);
                      c3 -= 360.0 + lower * 360.0;
                    }
                  }
                  if (camPars.Options.AxesLimit.MinLimit != camPars.Options.AxesLimit.MaxLimit)
                  {
                    if (c3 > camPars.Options.AxesLimit.MaxLimit.C)
                    {
                      pnt6DListList.Add(pnt6DList1);
                      c2 -= 360.0;
                      pnt6DList1 = new List<Pnt6D>();
                      pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                    }
                    if (c3 < camPars.Options.AxesLimit.MinLimit.C)
                    {
                      pnt6DListList.Add(pnt6DList1);
                      c2 += 360.0;
                      pnt6DList1 = new List<Pnt6D>();
                      pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                    }
                  }
                }
              }
              num3 = c2;
            }
            if (pnt6DList1.Count > 0)
            {
              double c4 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[Points.Count - 1]), new Pnt3D(Points[Points.Count - 2]));
              if (Entities[index1].Count == 1 & Points[Points.Count - 1].C != 0.0)
                c4 = Points[Points.Count - 1].C;
              double num9 = Math.Abs(c4 - pnt6DList1[pnt6DList1.Count - 1].C);
              if (num9 >= 360.0 - angleLimit)
              {
                num9 = 360.0 - c4;
                if (c4 > pnt6DList1[pnt6DList1.Count - 1].C)
                  c4 -= 360.0;
              }
              if (num9 > 185.0)
                c4 += 360.0;
              pnt6DList1.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, c4));
              pnt6DListList.Add(pnt6DList1);
            }
          }
        }
      }
      Pnt6D pnt6D2 = new Pnt6D();
      Pnt6D pnt6D3 = new Pnt6D();
      double num10 = camPars.Distances.Safe;
      OrientationAngle orientationAngle1 = new OrientationAngle();
      if (Operation.SawRampEnable & Operation.SawRampType != CamZRampType.None)
      {
        for (int index3 = 0; index3 <= pnt6DListList.Count - 1; ++index3)
        {
          List<double> doubleList = new List<double>();
          List<Pnt6D> CopiedPnt = new List<Pnt6D>();
          List<Pnt6D> calcStartPoints = new List<Pnt6D>();
          List<Pnt6D> calcMiddlePoints = new List<Pnt6D>();
          List<Pnt6D> calcEndPoints = new List<Pnt6D>();
          Pnt6D.Copy(pnt6DListList[index3], ref CopiedPnt);
          buAppCalc.cVector.DevidePointList(CopiedPnt, Operation.SawDevideLength, Operation.SawRampLenght, Operation.SawRampLenght, true, DevideTipType.StartAndEnd, ref calcStartPoints, ref calcMiddlePoints, ref calcEndPoints);
          if (Operation.SawRampType == CamZRampType.Linear)
          {
            doubleList = new List<double>();
            buNumeric.DevideMinMaxValueByNumber(Operation.SawRampHeight, camPars.Operations.TargetZ, calcStartPoints.Count, ref doubleList);
            for (int index4 = 0; index4 <= doubleList.Count - 1; ++index4)
              calcStartPoints[index4] = new Pnt6D(calcStartPoints[index4].X, calcStartPoints[index4].Y, doubleList[index4], calcStartPoints[index4].A, calcStartPoints[index4].B, calcStartPoints[index4].C);
            doubleList = new List<double>();
            buNumeric.DevideMinMaxValueByNumber(camPars.Operations.TargetZ, Operation.SawRampHeight, calcEndPoints.Count, ref doubleList);
            for (int index5 = 0; index5 <= doubleList.Count - 1; ++index5)
              calcEndPoints[index5] = new Pnt6D(calcEndPoints[index5].X, calcEndPoints[index5].Y, doubleList[index5], calcEndPoints[index5].A, calcEndPoints[index5].B, calcEndPoints[index5].C);
          }
          if (Operation.SawRampType == CamZRampType.Circular)
          {
            List<Pnt3D> Points = new List<Pnt3D>();
            doubleList = new List<double>();
            buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.SawRampHeight, camPars.Operations.TargetZ, 1.0, 200, ref doubleList, ref Points);
            double num11 = 0.0;
            calcStartPoints[0] = new Pnt6D(calcStartPoints[0].X, calcStartPoints[0].Y, doubleList[0], calcStartPoints[0].A, calcStartPoints[0].B, calcStartPoints[0].C);
            for (int index6 = 1; index6 <= calcStartPoints.Count - 1; ++index6)
            {
              double num12 = buAppCalc.cVector.Length3D(new Pnt3D(calcStartPoints[index6 - 1]), new Pnt3D(calcStartPoints[index6]), new WorkPlane());
              num11 += num12;
              double num13 = 0.0;
              double num14 = 0.0;
              for (int index7 = 1; index7 <= Points.Count - 1; ++index7)
              {
                double num15 = buAppCalc.cVector.Length3D(new Pnt3D(Points[index7 - 1].X, Points[index7 - 1].Y), new Pnt3D(Points[index7].X, Points[index7].Y));
                num13 += num15;
                if (num14 <= num11 & num11 <= num13)
                {
                  calcStartPoints[index6] = new Pnt6D(calcStartPoints[index6].X, calcStartPoints[index6].Y, doubleList[index7], calcStartPoints[index6].A, calcStartPoints[index6].B, calcStartPoints[index6].C);
                  index7 = 100000;
                }
                num14 = num13;
              }
            }
            calcStartPoints[calcStartPoints.Count - 1] = new Pnt6D(calcStartPoints[calcStartPoints.Count - 1].X, calcStartPoints[calcStartPoints.Count - 1].Y, doubleList[doubleList.Count - 1], calcStartPoints[calcStartPoints.Count - 1].A, calcStartPoints[calcStartPoints.Count - 1].B, calcStartPoints[calcStartPoints.Count - 1].C);
            doubleList = new List<double>();
            buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, camPars.Operations.TargetZ, Operation.SawRampHeight, 1.0, 200, ref doubleList, ref Points);
            double num16 = 0.0;
            calcEndPoints[0] = new Pnt6D(calcEndPoints[0].X, calcEndPoints[0].Y, doubleList[0], calcEndPoints[0].A, calcEndPoints[0].B, calcEndPoints[0].C);
            for (int index8 = 1; index8 <= calcEndPoints.Count - 1; ++index8)
            {
              double num17 = buAppCalc.cVector.Length3D(new Pnt3D(calcEndPoints[index8 - 1]), new Pnt3D(calcEndPoints[index8]), new WorkPlane());
              num16 += num17;
              double num18 = 0.0;
              double num19 = 0.0;
              for (int index9 = 1; index9 <= Points.Count - 1; ++index9)
              {
                double num20 = buAppCalc.cVector.Length3D(new Pnt3D(Points[index9 - 1].X, Points[index9 - 1].Y), new Pnt3D(Points[index9].X, Points[index9].Y));
                num18 += num20;
                if (num19 <= num16 & num16 <= num18)
                {
                  calcEndPoints[index8] = new Pnt6D(calcEndPoints[index8].X, calcEndPoints[index8].Y, doubleList[index9], calcEndPoints[index8].A, calcEndPoints[index8].B, calcEndPoints[index8].C);
                  index9 = 100000;
                }
                num19 = num18;
              }
            }
            calcEndPoints[calcEndPoints.Count - 1] = new Pnt6D(calcEndPoints[calcEndPoints.Count - 1].X, calcEndPoints[calcEndPoints.Count - 1].Y, doubleList[doubleList.Count - 1], calcEndPoints[calcEndPoints.Count - 1].A, calcEndPoints[calcEndPoints.Count - 1].B, calcEndPoints[calcEndPoints.Count - 1].C);
          }
          List<Pnt6D> Points1 = new List<Pnt6D>();
          Points1.AddRange((IEnumerable<Pnt6D>) calcStartPoints);
          Points1.AddRange((IEnumerable<Pnt6D>) calcMiddlePoints);
          Points1.AddRange((IEnumerable<Pnt6D>) calcEndPoints);
          buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points1);
          pnt6DListList[index3] = new List<Pnt6D>();
          pnt6DListList[index3] = Points1;
        }
      }
      for (int index10 = 0; index10 <= pnt6DListList.Count - 1; ++index10)
      {
        double ToolLength = Tool.Geometry.Diameter / 2.0;
        double feed1 = camPars.Speeds.Feed;
        double num21 = camPars.Distances.Safe;
        Pnt6D pnt6D4 = new Pnt6D();
        Pnt6D pnt6D5 = new Pnt6D();
        Pnt6D pnt6D6 = new Pnt6D();
        Pnt3D pnt3D2 = new Pnt3D();
        Pnt3D pnt3D3 = new Pnt3D();
        Pnt3D pnt3D4 = new Pnt3D();
        OrientationAngle orientationAngle2 = new OrientationAngle();
        OrientationAngle orientationAngle3 = new OrientationAngle();
        Pnt9DCam pnt9Dcam1 = new Pnt9DCam();
        Pnt9DCam pnt9Dcam2 = new Pnt9DCam();
        if (index10 <= pnt6DListList.Count - 2)
          orientationAngle3 = new OrientationAngle(new Pnt6D(pnt6DListList[index10 + 1][0]));
        CamPoint camPoint2 = new CamPoint();
        camPoint2.Type = 0;
        camPoint2.IsRapid = true;
        pnt6D6 = new Pnt6D();
        Pnt6D Pnt1 = new Pnt6D(pnt6DListList[index10][0]);
        Pnt3D pnt3D5 = new Pnt3D(Pnt1);
        pnt3D3 = new Pnt3D();
        pnt3D4 = new Pnt3D();
        OrientationAngle orientationAngle4 = new OrientationAngle(Pnt1);
        double feed2 = camPars.Speeds.Feed;
        num21 = (num10 - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        double safe1 = camPars.Distances.Safe;
        Pnt6D CalcPoint1 = new Pnt6D();
        Pnt3D calcPoint1 = new Pnt3D();
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe1 - pnt3D5.Z, ref calcPoint1);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint1), ref CalcPoint1);
        CalcPoint1.Z = CalcPoint1.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        if (orientationAngle4.A != orientationAngle1.A && pnt6D3.Z > CalcPoint1.Z)
          CalcPoint1.Z = pnt6D3.Z;
        Pnt9DCam pnt9Dcam3 = new Pnt9DCam(CalcPoint1, camPars.Speeds.Rapid, 0, true);
        if (index10 > 0)
          camPoint2.Points.Add(pnt9Dcam3);
        pnt3D1 = new Pnt3D(calcPoint1);
        Pnt6D pnt6D7 = new Pnt6D(CalcPoint1);
        Pnt6D CalcPoint2 = new Pnt6D();
        Pnt3D calcPoint2 = new Pnt3D();
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe1 - pnt3D5.Z, ref calcPoint2);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint2), ref CalcPoint2);
        CalcPoint2.Z = CalcPoint2.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        Pnt9DCam pnt9Dcam4 = new Pnt9DCam(CalcPoint2, camPars.Speeds.Rapid, 0);
        if (index10 == 0)
          pnt9Dcam4.EnableAxes.Z = false;
        camPoint2.Points.Add(pnt9Dcam4);
        Pnt3D Pnt2 = new Pnt3D(calcPoint2);
        Pnt6D pnt6D8 = new Pnt6D(CalcPoint2);
        if (index10 == 0)
        {
          camPoint2.Points.Add(pnt9Dcam3);
          Pnt6D pnt6D9 = new Pnt6D(CalcPoint2);
        }
        Pnt6D CalcPoint3 = new Pnt6D();
        Pnt3D Pnt3 = new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(Pnt3), ref CalcPoint3);
        CalcPoint3.Z = CalcPoint3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint3, camPars.Speeds.Plunge, 1));
        camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(Pnt3), Color.Lime));
        Pnt3D pnt3D6 = new Pnt3D(pnt3D5);
        Pnt6D pnt6D10 = new Pnt6D(CalcPoint3);
        List<Pnt3D> vertice = new List<Pnt3D>();
        vertice.Add(new Pnt3D(pnt3D6));
        for (int index11 = 1; index11 <= pnt6DListList[index10].Count - 1; ++index11)
        {
          Pnt1 = new Pnt6D(pnt6DListList[index10][index11]);
          orientationAngle4 = new OrientationAngle(Pnt1);
          Pnt6D CalcPoint4 = new Pnt6D();
          Pnt3D Pnt4 = new Pnt3D(Pnt1);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(Pnt4), ref CalcPoint4);
          CalcPoint4.Z = CalcPoint4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint4, feed2, 1));
          vertice.Add(new Pnt3D(Pnt4));
          pnt3D6 = new Pnt3D(Pnt1);
          Pnt6D pnt6D11 = new Pnt6D(CalcPoint4);
          OrientationAngle orientationAngle5 = new OrientationAngle(orientationAngle4);
        }
        if (vertice.Count > 0)
          camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
        num21 = (camPars.Distances.Safe - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        double num22 = (camPars.Material.Thickness + camPars.Distances.StepUp - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        double safe2 = camPars.Distances.Safe;
        bool flag = orientationAngle4.A != orientationAngle3.A;
        if (index10 == pnt6DListList.Count - 1)
          flag = true;
        Pnt6D CalcPoint5 = new Pnt6D();
        Pnt3D calcPoint3 = new Pnt3D();
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe2 - pnt3D6.Z, ref calcPoint3);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint3), ref CalcPoint5);
        CalcPoint5.Z = CalcPoint5.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint5, camPars.Speeds.Leave, 1));
        camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(pnt3D6), new Pnt3D(calcPoint3), Color.Red));
        num10 = camPars.Material.Thickness + camPars.Distances.StepUp;
        orientationAngle1 = new OrientationAngle(orientationAngle4);
        if (flag)
        {
          CalcPoint5 = new Pnt6D();
          Pnt3D calcPoint4 = new Pnt3D();
          pnt3D4 = new Pnt3D(pnt3D6.X, pnt3D6.Y, pnt3D6.Z + safe2);
          buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), safe2 - pnt3D6.Z, ref calcPoint4);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint4), ref CalcPoint5);
          CalcPoint5.Z = CalcPoint5.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint5, camPars.Speeds.Rapid, 0));
          camPoint2.EntitiesG0.Add((geoEntity) new geoLine(new Pnt3D(pnt3D6), new Pnt3D(calcPoint4), Color.Gold));
          num10 = camPars.Distances.Safe;
        }
        pnt6D3 = new Pnt6D(CalcPoint5);
        if (camPoint2.Points.Count > 0)
          camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
        for (int index12 = 1; index12 <= camPoint2.Points.Count - 1; ++index12)
        {
          List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
          double dt = 0.1;
          if (camPoint2.Points[index12].Type == 0)
            dt = 0.25;
          if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index12 - 1]), new Pnt3D(camPoint2.Points[index12])) > 3.0)
          {
            buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index12 - 1]), new Pnt6D(camPoint2.Points[index12]), dt, ref CalculatedPoints);
            CalculatedPoints.RemoveAt(0);
            camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
          }
          else
            camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index12]));
        }
        calcCam.CamPoints.Add(camPoint2);
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double) index10 / (double) (pnt6DListList.Count - 1)) * 100.0, Convert.ToDouble((double) index10 / (double) (pnt6DListList.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num1 > 0 && num1 % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num1;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
          }
          buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculateGrindingHole(
    Pnt3D RefPoint,
    KinematicBase Kinematic,
    ToolBase Tool,
    camParameters camPars,
    ref camBase calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      calcCam.Tool = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      List<Triangle3D> Triangles = new List<Triangle3D>();
      KinematicItem kinematicItem = new KinematicItem();
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
      kinematicItem.Axis.A = false;
      kinematicItem.Axis.C = false;
      eEntities eEntities = (eEntities) new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      kinematicItem.Entities.Add(eEntities);
      calcCam.Kinematic.Items.Add(kinematicItem);
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      int num1 = 1;
      int num2 = 1;
      CamPoint camPoint2 = new CamPoint();
      camPoint2.Type = 0;
      camPoint2.IsRapid = true;
      Pnt3D pnt3D2 = new Pnt3D(RefPoint);
      Pnt6D pnt6D2 = new Pnt6D();
      Pnt6D pnt6D3 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.Safe), new OrientationAngle());
      Pnt6D pnt6D4 = new Pnt6D(pnt6D3);
      Pnt9DCam pnt9Dcam1 = new Pnt9DCam(pnt6D3, camPars.Speeds.Leave, 0, true);
      camPoint2.Points.Add(pnt9Dcam1);
      pnt3D1 = new Pnt3D(pnt6D3.X, pnt6D3.Y, pnt6D3.Z);
      Pnt6D pnt6D5 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.Safe), new OrientationAngle());
      Pnt6D pnt6D6 = new Pnt6D(pnt6D5);
      Pnt9DCam pnt9Dcam2 = new Pnt9DCam(pnt6D5, camPars.Speeds.Leave, 0, false);
      camPoint2.Points.Add(pnt9Dcam2);
      Pnt3D Pnt1 = new Pnt3D(pnt6D5.X, pnt6D5.Y, pnt6D5.Z);
      Pnt6D pnt6D7 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.FirstApproach), new OrientationAngle());
      Pnt6D pnt6D8 = new Pnt6D(pnt6D7);
      Pnt9DCam pnt9Dcam3 = new Pnt9DCam(pnt6D7, camPars.Speeds.Plunge, 0, true);
      camPoint2.Points.Add(pnt9Dcam3);
      geoLine geoLine1 = new geoLine(new Pnt3D(Pnt1), new Pnt3D(pnt6D7), this.colorPlunge, this.entThickness);
      camPoint2.EntitiesPlunge.Add((geoEntity) geoLine1);
      Pnt3D Pnt2 = new Pnt3D(pnt6D7.X, pnt6D7.Y, pnt6D7.Z);
      if (camPars.Hole.HoleType == grindingHoleType.OneTimeToDown)
      {
        Pnt6D pnt6D9 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Hole.EndHeight), new OrientationAngle());
        Pnt6D pnt6D10 = new Pnt6D(pnt6D9);
        Pnt9DCam pnt9Dcam4 = new Pnt9DCam(pnt6D9, camPars.Speeds.Plunge, 1, false);
        camPoint2.Points.Add(pnt9Dcam4);
        geoLine geoLine2 = new geoLine(new Pnt3D(Pnt2), new Pnt3D(pnt6D9), this.colorG1, this.entThickness);
        camPoint2.EntitiesG1.Add((geoEntity) geoLine2);
        Pnt2 = new Pnt3D(pnt6D9.X, pnt6D9.Y, pnt6D9.Z);
        geoCircle geoCircle = new geoCircle(new Pnt3D(pnt6D9), Tool.Geometry.Diameter / 2.0);
        geoCircle.Color = this.colorMark;
        camPoint2.EntitiesMark.Add((geoEntity) geoCircle);
      }
      double num3 = 0.0;
      if (camPars.Hole.HoleType == grindingHoleType.UpDownByStep)
      {
        for (double z = camPars.Hole.StartHeight - Math.Abs(camPars.Hole.DownStep); z >= camPars.Hole.EndHeight; z -= Math.Abs(camPars.Hole.DownStep))
        {
          Pnt6D pnt6D11 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, z), new OrientationAngle());
          Pnt6D pnt6D12 = new Pnt6D(pnt6D11);
          Pnt9DCam pnt9Dcam5 = new Pnt9DCam(pnt6D11, camPars.Speeds.Plunge, 1, false);
          camPoint2.Points.Add(pnt9Dcam5);
          geoLine geoLine3 = new geoLine(new Pnt3D(Pnt2), new Pnt3D(pnt6D11), this.colorPlunge, this.entThickness);
          camPoint2.EntitiesPlunge.Add((geoEntity) geoLine3);
          pnt3D1 = new Pnt3D(pnt6D11.X, pnt6D11.Y, pnt6D11.Z);
          geoCircle geoCircle = new geoCircle(new Pnt3D(pnt6D11), Tool.Geometry.Diameter / 2.0);
          geoCircle.Color = this.colorMark;
          camPoint2.EntitiesMark.Add((geoEntity) geoCircle);
          Pnt6D pnt6D13 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, z + camPars.Hole.UpStep), new OrientationAngle());
          Pnt6D pnt6D14 = new Pnt6D(pnt6D13);
          Pnt9DCam pnt9Dcam6 = new Pnt9DCam(pnt6D13, camPars.Speeds.Leave, 1, false);
          camPoint2.Points.Add(pnt9Dcam6);
          Pnt2 = new Pnt3D(pnt6D13.X, pnt6D13.Y, pnt6D13.Z);
          num3 = z;
        }
        if (num3 > camPars.Hole.EndHeight)
        {
          Pnt6D pnt6D15 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Hole.EndHeight), new OrientationAngle());
          Pnt6D pnt6D16 = new Pnt6D(pnt6D15);
          Pnt9DCam pnt9Dcam7 = new Pnt9DCam(pnt6D15, camPars.Speeds.Plunge, 1, false);
          camPoint2.Points.Add(pnt9Dcam7);
          geoLine geoLine4 = new geoLine(new Pnt3D(Pnt2), new Pnt3D(pnt6D15), this.colorPlunge, this.entThickness);
          camPoint2.EntitiesPlunge.Add((geoEntity) geoLine4);
          pnt3D1 = new Pnt3D(pnt6D15.X, pnt6D15.Y, pnt6D15.Z);
          geoCircle geoCircle = new geoCircle(new Pnt3D(pnt6D15), Tool.Geometry.Diameter / 2.0);
          geoCircle.Color = this.colorMark;
          camPoint2.EntitiesMark.Add((geoEntity) geoCircle);
          Pnt6D pnt6D17 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Hole.EndHeight + camPars.Hole.UpStep), new OrientationAngle());
          Pnt6D pnt6D18 = new Pnt6D(pnt6D17);
          Pnt9DCam pnt9Dcam8 = new Pnt9DCam(pnt6D17, camPars.Speeds.Leave, 1, false);
          camPoint2.Points.Add(pnt9Dcam8);
          Pnt2 = new Pnt3D(pnt6D17.X, pnt6D17.Y, pnt6D17.Z);
        }
      }
      Pnt6D pnt6D19 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.Safe), new OrientationAngle());
      Pnt6D pnt6D20 = new Pnt6D(pnt6D19);
      Pnt9DCam pnt9Dcam9 = new Pnt9DCam(pnt6D19, camPars.Speeds.Leave, 0, true);
      camPoint2.Points.Add(pnt9Dcam9);
      geoLine geoLine5 = new geoLine(new Pnt3D(Pnt2), new Pnt3D(pnt6D19), this.colorLeave, this.entThickness);
      camPoint2.EntitiesLeave.Add((geoEntity) geoLine5);
      pnt3D1 = new Pnt3D(pnt6D19.X, pnt6D19.Y, pnt6D19.Z);
      if (camPoint2.Points.Count > 0)
        camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
      for (int index = 1; index <= camPoint2.Points.Count - 1; ++index)
      {
        List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
        double dt = 0.1;
        if (camPoint2.Points[index].Type == 0)
          dt = 0.25;
        if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index - 1]), new Pnt3D(camPoint2.Points[index])) > 3.0)
        {
          buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index - 1]), new Pnt6D(camPoint2.Points[index]), dt, ref CalculatedPoints);
          CalculatedPoints.RemoveAt(0);
          camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
        }
        else
          camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index]));
      }
      calcCam.CamPoints.Add(camPoint2);
      // ISSUE: reference to a compiler-generated field
      if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_0(new CalculationEventArg(50.0, 100.0, 0, "Calculate Marble Code", ""));
      }
      if (buSystem.DoEventEnable & num1 > 0 & num2 > 0 && num2 % num1 == 0)
        Application.DoEvents();
      if (buSystem.Cancel)
      {
        buSystem.Cancel = false;
        buSystem.Canceled = true;
        // ISSUE: reference to a compiler-generated field
        if (this.calculationEventHandler_2 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_2(new CalculationEventArg());
        }
        // ISSUE: reference to a compiler-generated field
        if (this.calculationEventHandler_3 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
        }
        buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
      }
      else
      {
        int num4 = num2 + 1;
        // ISSUE: reference to a compiler-generated field
        if (this.calculationEventHandler_2 == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_2(new CalculationEventArg());
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void HatchCamCalculationGrinding(
    KinematicBase Kinematic,
    ToolBase Tool,
    camParameters camPars,
    SimulationBase simPars,
    ref camBase calcCam,
    ref List<eEntities> Entities)
  {
    if (camPars.Hatch.CutStep <= 0.0 || camPars.Hatch.TotalWidth <= 0.0 || camPars.Hatch.CutLength <= 0.0 || camPars.Hatch.CutStep > camPars.Hatch.TotalWidth)
      return;
    List<List<eEntities>> Entities1 = new List<List<eEntities>>();
    Entities.Clear();
    int num1 = (int) buNumeric.RoundToLower(camPars.Hatch.TotalWidth / camPars.Hatch.CutStep);
    if (num1 == 0)
      num1 = 1;
    double num2 = camPars.Hatch.TotalWidth / (double) num1;
    if (camPars.Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
    {
      Pnt3D Pnt = new Pnt3D();
      List<eEntities> eEntitiesList = new List<eEntities>();
      for (int index = 0; index <= num1 - 1; ++index)
      {
        if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
        {
          eEntitiesList = new List<eEntities>();
          double num3 = (double) index * num2;
          eEntities eEntities = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Entities1.Add(eEntitiesList);
        }
        if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
        {
          eEntitiesList = new List<eEntities>();
          double num4 = (double) index * num2;
          eEntities eEntities1 = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + num4, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + num4, camPars.Hatch.OperationZ));
          Entities.Add(eEntities1);
          eEntitiesList.Add(eEntities1);
          eEntities eEntities2 = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + num4, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + num4, camPars.Hatch.OperationZ));
          Entities.Add(eEntities2);
          eEntitiesList.Add(eEntities2);
          Entities1.Add(eEntitiesList);
        }
        if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        {
          double y = (double) index * num2;
          eEntities eEntities = (eEntities) null;
          if (Entities.Count > 0)
          {
            eEntities = (eEntities) new eLine(new Pnt3D(Pnt), new Pnt3D(Pnt.X, y, camPars.Hatch.OperationZ));
            Entities.Add(eEntities);
            eEntitiesList.Add(eEntities);
          }
          if (index % 2 == 0)
            eEntities = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + y, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + y, camPars.Hatch.OperationZ));
          if (index % 2 == 1)
            eEntities = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + y, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + y, camPars.Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Pnt = new Pnt3D(eEntities.Vertice[eEntities.Vertice.Count - 1]);
        }
      }
      if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        Entities1.Add(eEntitiesList);
    }
    if (camPars.Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
    {
      Pnt3D Pnt = new Pnt3D();
      List<eEntities> eEntitiesList = new List<eEntities>();
      for (int index = 0; index <= num1 - 1; ++index)
      {
        if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
        {
          eEntitiesList = new List<eEntities>();
          double num5 = (double) index * num2;
          eEntities eEntities = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + num5, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + num5, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Entities1.Add(eEntitiesList);
        }
        if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
        {
          eEntitiesList = new List<eEntities>();
          double num6 = (double) index * num2;
          eEntities eEntities3 = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + num6, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + num6, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ));
          Entities.Add(eEntities3);
          eEntitiesList.Add(eEntities3);
          eEntities eEntities4 = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + num6, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + num6, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ));
          Entities.Add(eEntities4);
          eEntitiesList.Add(eEntities4);
          Entities1.Add(eEntitiesList);
        }
        if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        {
          double x = (double) index * num2;
          eEntities eEntities = (eEntities) null;
          if (Entities.Count > 0)
          {
            eEntities = (eEntities) new eLine(new Pnt3D(Pnt), new Pnt3D(x, Pnt.Y, camPars.Hatch.OperationZ));
            Entities.Add(eEntities);
            eEntitiesList.Add(eEntities);
          }
          if (index % 2 == 0)
            eEntities = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + x, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + x, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ));
          if (index % 2 == 1)
            eEntities = (eEntities) new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + x, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + x, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Pnt = new Pnt3D(eEntities.Vertice[eEntities.Vertice.Count - 1]);
        }
      }
      if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        Entities1.Add(eEntitiesList);
    }
    this.CalculateGrindingContour(Entities1, Kinematic, Tool, camPars, simPars, ref calcCam);
  }

  public void CalculateMarbleItem(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    marbleOperation OperationPars,
    marbleCamParameters CamPars,
    camSpeeds Speed,
    camDistances Distance,
    ref camBase calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D P = new Pnt6D();
      calcCam = new camBase();
      calcCam.Tool = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      int int32 = Convert.ToInt32((double) Entities.Count / 100.0);
      int num1 = 0;
      double safe1 = Distance.Safe;
      for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
      {
        eEntities copiedEnt1 = new eEntities();
        if (Entities[index1].Count > 0)
        {
          eEntities copiedEnt2 = new eEntities();
          List<Pnt3D> TargetList1 = new List<Pnt3D>();
          eEntities.CopyEntity(Entities[index1][0], ref copiedEnt2);
          buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList1);
          if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
            TargetList1.Reverse();
          CamPoint camPoint2 = new CamPoint();
          camPoint2.Type = 0;
          camPoint2.IsRapid = true;
          double safe2 = Distance.Safe;
          double feed1 = Speed.Feed;
          Pnt3D calcPoint = new Pnt3D();
          Pnt3D BasePoint1 = new Pnt3D(TargetList1[0]);
          Pnt3D Pnt1 = new Pnt3D(TargetList1[TargetList1.Count - 1]);
          Pnt3D pnt3D2 = new Pnt3D();
          OrientationAngle Orientation = new OrientationAngle(copiedEnt2.Orientation);
          OrientationAngle orientationAngle1 = new OrientationAngle();
          OrientationAngle orientationAngle2 = new OrientationAngle();
          feed1 = Speed.Feed;
          double Length1 = (safe1 - BasePoint1.Z) / Math.Cos(buConversion.DegreeToRadian(Orientation.A));
          Pnt6D CalcPoint = new Pnt6D();
          double ToolLength = Tool.Geometry.Diameter / 2.0;
          calcCam.Tool.Geometry.Length = ToolLength;
          calcPoint = new Pnt3D();
          pnt3D2 = new Pnt3D(BasePoint1.X, BasePoint1.Y, 0.0);
          buAppCalc.cVector.LineWithOrientationAngle(BasePoint1, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length1, ref calcPoint);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, Speed.Rapid, 0));
          if (index1 == 0)
            P = new Pnt6D(CalcPoint.X, CalcPoint.Y, CalcPoint.Z, 0.0, 0.0, Orientation.C);
          Pnt3D Pnt2 = new Pnt3D(calcPoint);
          Pnt3D pnt3D3 = new Pnt3D(BasePoint1.X, BasePoint1.Y, BasePoint1.Z);
          buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Distance.Safe, ref calcPoint);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, Speed.Plunge, 1));
          camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(pnt3D3), Color.Lime));
          Pnt3D Pnt3 = new Pnt3D(calcPoint);
          for (int index2 = 0; index2 <= Entities[index1].Count - 1; ++index2)
          {
            double feed2 = Speed.Feed;
            if (Entities[index1][index2].auxText != null && Entities[index1][index2].auxText == "Backward")
              feed2 = Speed.BackwardFeed;
            copiedEnt2 = new eEntities();
            List<Pnt3D> TargetList2 = new List<Pnt3D>();
            eEntities.CopyEntity(Entities[index1][index2], ref copiedEnt2);
            buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList2);
            if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
              TargetList2.Reverse();
            calcPoint = new Pnt3D();
            Pnt3D Pnt4 = new Pnt3D(TargetList2[0]);
            Pnt1 = new Pnt3D(TargetList2[TargetList2.Count - 1]);
            pnt3D2 = new Pnt3D();
            Orientation = new OrientationAngle(copiedEnt2.Orientation);
            CalcPoint = new Pnt6D();
            Pnt3D Pnt5 = new Pnt3D(Pnt4.X, Pnt4.Y, Pnt4.Z);
            buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(Pnt5), ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
            camPoint2.Points.Add(new Pnt9DCam(CalcPoint, Speed.Plunge, 1));
            camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt3), new Pnt3D(Pnt4), Color.Lime));
            CalcPoint = new Pnt6D();
            Pnt3D Pnt6 = new Pnt3D(Pnt1.X, Pnt1.Y, Pnt1.Z);
            buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(Pnt6), ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
            camPoint2.Points.Add(new Pnt9DCam(CalcPoint, feed2, 1));
            camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt4), new Pnt3D(Pnt1), Color.Blue));
            Pnt3 = new Pnt3D(Pnt1);
          }
          double Length2 = (Distance.Safe - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(Orientation.A));
          double num2 = (OperationPars.MaterialThickness + Distance.StepUp - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(Orientation.A));
          if (Orientation.A == orientationAngle1.A)
            ;
          if (index1 != Entities.Count - 1)
            ;
          CalcPoint = new Pnt6D();
          Pnt3D BasePoint2 = new Pnt3D(Pnt1.X, Pnt1.Y, Pnt1.Z);
          calcPoint = new Pnt3D();
          buAppCalc.cVector.LineWithOrientationAngle(BasePoint2, new OrientationAngle(Orientation.A * -1.0, 0.0, Orientation.C), Length2, ref calcPoint);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, Orientation, new Pnt3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, Speed.Leave, 1));
          camPoint2.EntitiesG0.Add((geoEntity) new geoLine(new Pnt3D(Pnt1), new Pnt3D(calcPoint)));
          for (int index3 = 1; index3 <= camPoint2.Points.Count - 1; ++index3)
          {
            List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
            double dt = 0.1;
            if (camPoint2.Points[index3].Type == 0)
              dt = 0.25;
            buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index3 - 1]), new Pnt6D(camPoint2.Points[index3]), dt, ref CalculatedPoints);
            camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
          }
          pnt3D1 = new Pnt3D(Pnt1);
          eEntities.CopyEntity(copiedEnt2, ref copiedEnt1);
          calcCam.CamPoints.Add(camPoint2);
        }
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double) index1 / (double) (Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num1 > 0 && num1 % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num1;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble Code", ""));
          }
          buLog.addLog("Calculate Marble Code", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      calcCam.CamPoints.Add(new CamPoint()
      {
        Type = 0,
        IsRapid = true,
        Points = {
          new Pnt9DCam(P, Speed.Rapid, 0)
        }
      });
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculateMarbleWireFrameWithSaw(
    List<List<eEntities>> Entities,
    List<List<eEntities>> ReCalculatedEntities,
    KinematicBase Kinematic,
    ToolBase Tool,
    marbleOperation Operation,
    marbleCamParameters CamMarblePars,
    camParameters camPar,
    EntitiesResolution Resolution,
    ref camBase calcCam)
  {
    try
    {
      List<List<eEntities>> CopiedEnt = new List<List<eEntities>>();
      if (Operation.ApplySurfaceReadData & Operation.SurfaceReadDevideLength > 0.0 & buCamCalc.pntTeachGrids.Count > 0)
      {
        for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
        {
          List<eEntities> eEntitiesList = new List<eEntities>();
          List<Pnt3D> Points = new List<Pnt3D>();
          buAppCalc.cVector.EntitiesToPoint(Entities[index1], new EntitiesResolution()
          {
            ArcResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            CircleResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            CurveResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            EllipseResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            LineResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            OtherResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            PolylineResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength)
          }, ref Points);
          Points[Points.Count - 1] = new Pnt3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
          for (int index2 = 0; index2 <= Points.Count - 1; ++index2)
          {
            double num = 0.0;
            int index3 = Convert.ToInt32(Points[index2].X);
            int index4 = Convert.ToInt32(Points[index2].Y);
            if (index3 < 0)
              index3 = 0;
            if (index4 < 0)
              index4 = 0;
            if (index4 >= 0 & index4 <= buCamCalc.pntTeachGrids.Count - 1 && index3 >= 0 & index3 <= buCamCalc.pntTeachGrids[index4].Count - 1)
              num = buCamCalc.pntTeachGrids[index4][index3].Z;
            Points[index2] = new Pnt3D(Points[index2].X, Points[index2].Y, Points[index2].Z + num);
          }
          ePolyline ePolyline = new ePolyline(Points);
          ePolyline.Orientation = new OrientationAngle(Entities[index1][0].Orientation);
          eEntitiesList.Add((eEntities) ePolyline);
          CopiedEnt.Add(eEntitiesList);
        }
      }
      else
        eEntities.CopyEntities(Entities, ref CopiedEnt);
      bool flag1 = camPar.Strategy.UseTangentLimit;
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      double num1 = camPar.Strategy.AngleLimit;
      List<Triangle3D> Triangles = new List<Triangle3D>();
      calcCam = new camBase();
      calcCam.Tool = new ToolBase(Tool);
      calcCam.Kinematic = new KinematicBase(Kinematic);
      KinematicItem kinematicItem = new KinematicItem();
      kinematicItem.Axis.A = true;
      kinematicItem.Axis.C = true;
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, -Kinematic.RotateCenterOffsetOfC.Y, -Kinematic.RotateCenterOffsetOfC.Z), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 1.0, 0.0), new EntityResolution(), ref Triangles);
      eSurface eSurface = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      calcCam.Kinematic.Items.Add(kinematicItem);
      calcCam.Kinematic.MovePartRuntimeOffset.X = 0.0;
      calcCam.Kinematic.MovePartRuntimeOffset.Y = -Kinematic.RotateCenterOffsetOfC.Y;
      calcCam.Kinematic.MovePartRuntimeOffset.Z = -Kinematic.RotateCenterOffsetOfC.Z;
      CamPoint camPoint1 = new CamPoint();
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      List<List<Pnt6D>> pnt6DListList = new List<List<Pnt6D>>();
      if (Operation.UseSweepOperation && !Operation.SweepZUpSharpCorner)
        flag1 = false;
      int CalcEventCount = 1;
      int num2 = 0;
      Pnt6D pnt6D2 = new Pnt6D();
      Pnt6D pnt6D3 = new Pnt6D();
      double num3 = camPar.Distances.Safe;
      OrientationAngle orientationAngle1 = new OrientationAngle();
      Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
      if (ReCalculatedEntities.Count > 0)
        eEntities.CopyEntities(ReCalculatedEntities, ref CopiedEnt);
      if (CopiedEnt.Count <= 10)
        CalcEventCount = 1;
      buGeneral.DoEventCountCalc(CopiedEnt.Count, ref CalcEventCount);
      for (int index5 = 0; index5 <= CopiedEnt.Count - 1; ++index5)
      {
        List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
        List<List<Pnt6D>> SourceList = new List<List<Pnt6D>>();
        if (CopiedEnt[index5].Count >= 1)
        {
          List<Pnt6D> Points = new List<Pnt6D>();
          List<Pnt6D> pnt6DList2 = new List<Pnt6D>();
          buAppCalc.cVector.EntitiesToPoint(CopiedEnt[index5], Resolution, ref Points);
          buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points, 0.01);
          if (Points.Count > 1)
          {
            double num4 = 0.0;
            double c1 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[1]), new Pnt3D(Points[0]));
            if (CamMarblePars.UseCZero)
              c1 = 0.0;
            if (CopiedEnt[index5].Count == 1 & Points[0].C != 0.0)
              c1 = Points[0].C;
            if (Operation.ProfileCutFinishEnable & Operation.ProfileCutFinishVector == VectorXYType.XVector)
              c1 = 0.0;
            double num5 = c1;
            pnt6DList1.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, c1));
            for (int index6 = 1; index6 <= Points.Count - 2; ++index6)
            {
              bool flag2 = false;
              double c2 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index6]), new Pnt3D(Points[index6 - 1]));
              if (CamMarblePars.UseCZero)
                c2 = 0.0;
              if (Operation.ProfileCutFinishEnable & Operation.ProfileCutFinishVector == VectorXYType.XVector)
                c2 = 0.0;
              if (index6 != 90)
                ;
              double c3;
              double num6;
              if (flag1)
              {
                num4 = Points[index6 - 1].A - Points[index6].A;
                if (Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C) > 185.0)
                {
                  if (pnt6DList1[pnt6DList1.Count - 1].C > c2)
                    c2 += 360.0;
                  else
                    c2 -= 360.0;
                }
                c3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index6 + 1]), new Pnt3D(Points[index6]));
                if (CamMarblePars.UseCZero)
                  c3 = 0.0;
                if (Operation.ProfileCutFinishEnable & Operation.ProfileCutFinishVector == VectorXYType.XVector)
                  c3 = 0.0;
                num1 = camPar.Strategy.AngleLimit;
                double num7 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6 + 1]), new WorkPlane());
                if (CopiedEnt[index5][0].OperationPlane == planeType.YZ)
                {
                  if (camPar.Strategy.UseLimitAngleForOtherPlane)
                    num1 = camPar.Strategy.AngleLimitYZ;
                  num7 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6 + 1]), new WorkPlane(planeType.YZ, 1));
                }
                num6 = 180.0 - num7;
                if (num6 >= 360.0 - num1)
                  num6 = 360.0 - num7;
                Math.Abs(c2 - num5);
                if (Math.Abs(num4) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
                {
                  SourceList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c3));
                  flag2 = true;
                }
              }
              else
              {
                num1 = camPar.Strategy.AngleLimit;
                double num8 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6 + 1]), new WorkPlane());
                num6 = 180.0 - num8;
                if (num6 >= 360.0 - num1)
                  num6 = 360.0 - num8;
                c3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index6 + 1]), new Pnt3D(Points[index6]));
                if (CamMarblePars.UseCZero)
                  c3 = 0.0;
                if (Operation.ProfileCutFinishEnable & Operation.ProfileCutFinishVector == VectorXYType.XVector)
                  c3 = 0.0;
                if (num6 > num1)
                {
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6 + 1].A, 0.0, c3));
                  flag2 = true;
                }
                Math.Abs(c2 - num5);
                if (Math.Abs(num4) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
                {
                  SourceList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c3));
                  flag2 = true;
                }
              }
              if (!flag2)
              {
                if (num6 > num1 & flag1)
                {
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                  SourceList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6 + 1].A, 0.0, c3));
                }
                else
                {
                  if (flag1)
                  {
                    double num9 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                    if (num9 >= 360.0 - num1)
                    {
                      if (c2 > pnt6DList1[pnt6DList1.Count - 1].C)
                        c2 -= 360.0;
                      else
                        c2 += 360.0;
                      num9 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                    }
                    if (num9 > 185.0)
                      c2 += 360.0;
                  }
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                  if (Math.Abs(c2 - c3) > 180.1)
                  {
                    double num10 = c2 - c3;
                    if (c2 > c3)
                    {
                      double num11 = c3 + 360.0;
                      double lower = buNumeric.RoundToLower(Math.Abs(c2 - num11) / 360.0);
                      c3 = num11 + lower * 360.0;
                    }
                    else
                    {
                      double num12 = c3 - 360.0;
                      double lower = buNumeric.RoundToLower(Math.Abs(c2 - num12) / 360.0);
                      c3 = num12 - lower * 360.0;
                    }
                  }
                  if (camPar.Options.AxesLimit.MinLimit != camPar.Options.AxesLimit.MaxLimit)
                  {
                    if (c3 > camPar.Options.AxesLimit.MaxLimit.C)
                    {
                      SourceList.Add(pnt6DList1);
                      c2 -= 360.0;
                      pnt6DList1 = new List<Pnt6D>();
                      pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                    }
                    if (c3 < camPar.Options.AxesLimit.MinLimit.C)
                    {
                      SourceList.Add(pnt6DList1);
                      c2 += 360.0;
                      pnt6DList1 = new List<Pnt6D>();
                      pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                    }
                  }
                }
              }
              num5 = c2;
            }
            if (pnt6DList1.Count > 0)
            {
              double c4 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[Points.Count - 1]), new Pnt3D(Points[Points.Count - 2]));
              if (CamMarblePars.UseCZero)
                c4 = 0.0;
              if (CopiedEnt[index5].Count == 1 & Points[Points.Count - 1].C != 0.0)
                c4 = Points[Points.Count - 1].C;
              double num13 = Math.Abs(c4 - pnt6DList1[pnt6DList1.Count - 1].C);
              if (num13 >= 360.0 - num1)
              {
                num13 = 360.0 - c4;
                if (c4 > pnt6DList1[pnt6DList1.Count - 1].C)
                  c4 -= 360.0;
              }
              if (num13 > 185.0)
                c4 += 360.0;
              pnt6DList1.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, c4));
              SourceList.Add(pnt6DList1);
            }
          }
        }
        if (Operation.SawRampEnable & Operation.SawRampType != CamZRampType.None)
        {
          for (int index7 = 0; index7 <= SourceList.Count - 1; ++index7)
          {
            List<double> doubleList = new List<double>();
            List<Pnt6D> CopiedPnt = new List<Pnt6D>();
            List<Pnt6D> calcStartPoints = new List<Pnt6D>();
            List<Pnt6D> calcMiddlePoints = new List<Pnt6D>();
            List<Pnt6D> calcEndPoints = new List<Pnt6D>();
            Pnt6D.Copy(SourceList[index7], ref CopiedPnt);
            buAppCalc.cVector.DevidePointList(CopiedPnt, Operation.SawDevideLength, Operation.SawRampLenght, Operation.SawRampLenght, true, DevideTipType.StartAndEnd, ref calcStartPoints, ref calcMiddlePoints, ref calcEndPoints);
            if (Operation.SawRampType == CamZRampType.Linear)
            {
              List<double> Values1 = new List<double>();
              buNumeric.DevideMinMaxValueByNumber(Operation.SawRampHeight, Operation.TargetZ, calcStartPoints.Count, ref Values1);
              for (int index8 = 0; index8 <= Values1.Count - 1; ++index8)
                calcStartPoints[index8] = new Pnt6D(calcStartPoints[index8].X, calcStartPoints[index8].Y, Values1[index8], calcStartPoints[index8].A, calcStartPoints[index8].B, calcStartPoints[index8].C);
              List<double> Values2 = new List<double>();
              buNumeric.DevideMinMaxValueByNumber(Operation.TargetZ, Operation.SawRampHeight, calcEndPoints.Count, ref Values2);
              for (int index9 = 0; index9 <= Values2.Count - 1; ++index9)
                calcEndPoints[index9] = new Pnt6D(calcEndPoints[index9].X, calcEndPoints[index9].Y, Values2[index9], calcEndPoints[index9].A, calcEndPoints[index9].B, calcEndPoints[index9].C);
            }
            if (Operation.SawRampType == CamZRampType.Circular)
            {
              List<Pnt3D> Points = new List<Pnt3D>();
              List<double> Heights1 = new List<double>();
              buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.SawRampHeight, Operation.TargetZ, 1.0, 200, ref Heights1, ref Points);
              double num14 = 0.0;
              calcStartPoints[0] = new Pnt6D(calcStartPoints[0].X, calcStartPoints[0].Y, Heights1[0], calcStartPoints[0].A, calcStartPoints[0].B, calcStartPoints[0].C);
              for (int index10 = 1; index10 <= calcStartPoints.Count - 1; ++index10)
              {
                double num15 = buAppCalc.cVector.Length3D(new Pnt3D(calcStartPoints[index10 - 1]), new Pnt3D(calcStartPoints[index10]), new WorkPlane());
                num14 += num15;
                double num16 = 0.0;
                double num17 = 0.0;
                for (int index11 = 1; index11 <= Points.Count - 1; ++index11)
                {
                  double num18 = buAppCalc.cVector.Length3D(new Pnt3D(Points[index11 - 1].X, Points[index11 - 1].Y), new Pnt3D(Points[index11].X, Points[index11].Y));
                  num16 += num18;
                  if (num17 <= num14 & num14 <= num16)
                  {
                    calcStartPoints[index10] = new Pnt6D(calcStartPoints[index10].X, calcStartPoints[index10].Y, Heights1[index11], calcStartPoints[index10].A, calcStartPoints[index10].B, calcStartPoints[index10].C);
                    index11 = 100000;
                  }
                  num17 = num16;
                }
              }
              calcStartPoints[calcStartPoints.Count - 1] = new Pnt6D(calcStartPoints[calcStartPoints.Count - 1].X, calcStartPoints[calcStartPoints.Count - 1].Y, Heights1[Heights1.Count - 1], calcStartPoints[calcStartPoints.Count - 1].A, calcStartPoints[calcStartPoints.Count - 1].B, calcStartPoints[calcStartPoints.Count - 1].C);
              List<double> Heights2 = new List<double>();
              buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.TargetZ, Operation.SawRampHeight, 1.0, 200, ref Heights2, ref Points);
              double num19 = 0.0;
              calcEndPoints[0] = new Pnt6D(calcEndPoints[0].X, calcEndPoints[0].Y, Heights2[0], calcEndPoints[0].A, calcEndPoints[0].B, calcEndPoints[0].C);
              for (int index12 = 1; index12 <= calcEndPoints.Count - 1; ++index12)
              {
                double num20 = buAppCalc.cVector.Length3D(new Pnt3D(calcEndPoints[index12 - 1]), new Pnt3D(calcEndPoints[index12]), new WorkPlane());
                num19 += num20;
                double num21 = 0.0;
                double num22 = 0.0;
                for (int index13 = 1; index13 <= Points.Count - 1; ++index13)
                {
                  double num23 = buAppCalc.cVector.Length3D(new Pnt3D(Points[index13 - 1].X, Points[index13 - 1].Y), new Pnt3D(Points[index13].X, Points[index13].Y));
                  num21 += num23;
                  if (num22 <= num19 & num19 <= num21)
                  {
                    calcEndPoints[index12] = new Pnt6D(calcEndPoints[index12].X, calcEndPoints[index12].Y, Heights2[index13], calcEndPoints[index12].A, calcEndPoints[index12].B, calcEndPoints[index12].C);
                    index13 = 100000;
                  }
                  num22 = num21;
                }
              }
              calcEndPoints[calcEndPoints.Count - 1] = new Pnt6D(calcEndPoints[calcEndPoints.Count - 1].X, calcEndPoints[calcEndPoints.Count - 1].Y, Heights2[Heights2.Count - 1], calcEndPoints[calcEndPoints.Count - 1].A, calcEndPoints[calcEndPoints.Count - 1].B, calcEndPoints[calcEndPoints.Count - 1].C);
            }
            List<Pnt6D> Points1 = new List<Pnt6D>();
            Points1.AddRange((IEnumerable<Pnt6D>) calcStartPoints);
            Points1.AddRange((IEnumerable<Pnt6D>) calcMiddlePoints);
            Points1.AddRange((IEnumerable<Pnt6D>) calcEndPoints);
            buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points1);
            SourceList[index7] = new List<Pnt6D>();
            SourceList[index7] = Points1;
          }
        }
        for (int index14 = 0; index14 <= SourceList.Count - 1; ++index14)
        {
          double ToolLength = Tool.Geometry.Diameter / 2.0;
          double feed1 = camPar.Speeds.Feed;
          double safe = camPar.Distances.Safe;
          double stepUp = camPar.Distances.StepUp;
          Pnt6D pnt6D4 = new Pnt6D();
          Pnt6D pnt6D5 = new Pnt6D();
          Pnt6D CalcPoint = new Pnt6D();
          Pnt3D pnt3D2 = new Pnt3D();
          Pnt3D pnt3D3 = new Pnt3D();
          Pnt3D pnt3D4 = new Pnt3D();
          OrientationAngle orientationAngle2 = new OrientationAngle();
          OrientationAngle orientationAngle3 = new OrientationAngle();
          if (index5 <= CopiedEnt.Count - 2)
            orientationAngle3 = new OrientationAngle(CopiedEnt[index5 + 1][0].Orientation);
          CamPoint camPoint2 = new CamPoint();
          camPoint2.Type = 0;
          camPoint2.IsRapid = true;
          CalcPoint = new Pnt6D();
          Pnt6D Pnt1 = new Pnt6D(SourceList[index14][0]);
          Pnt3D pnt3D5 = new Pnt3D(Pnt1);
          pnt3D3 = new Pnt3D();
          pnt3D4 = new Pnt3D();
          OrientationAngle orientationAngle4 = new OrientationAngle(Pnt1);
          if (Operation.UseSweepOperation)
          {
            if (Operation.SweepFollowTangent)
              orientationAngle4.C += Operation.SweepOffsetAngleForTangent;
            else
              orientationAngle4.C = Operation.SweepConstantAngle;
          }
          double feed2 = camPar.Speeds.Feed;
          double Length1 = (num3 - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
          CalcPoint = new Pnt6D();
          Pnt3D calcPoint1 = new Pnt3D();
          buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length1, ref calcPoint1);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint1), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          if (orientationAngle4.A != orientationAngle1.A && pnt6D3.Z > CalcPoint.Z)
            CalcPoint.Z = pnt6D3.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Rapid, 0, true));
          pnt3D1 = new Pnt3D(calcPoint1);
          Pnt6D pnt6D6 = new Pnt6D(CalcPoint);
          CalcPoint = new Pnt6D();
          Pnt3D calcPoint2 = new Pnt3D();
          buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length1, ref calcPoint2);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint2), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Rapid, 0));
          Pnt3D Pnt2 = new Pnt3D(calcPoint2);
          Pnt6D pnt6D7 = new Pnt6D(CalcPoint);
          if (index14 == 0)
          {
            Pnt6D pnt6D8 = new Pnt6D(CalcPoint);
          }
          CalcPoint = new Pnt6D();
          Pnt3D Pnt3 = new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(Pnt3), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Plunge, 1));
          camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(Pnt3), Color.Lime));
          camPoint2.EntitiesG1[camPoint2.EntitiesG1.Count - 1].BaseEntityIndex = CopiedEnt[index5][0].EntityIndex;
          Pnt3D pnt3D6 = new Pnt3D(pnt3D5);
          Pnt6D pnt6D9 = new Pnt6D(CalcPoint);
          List<Pnt3D> vertice = new List<Pnt3D>();
          vertice.Add(new Pnt3D(pnt3D6));
          for (int index15 = 1; index15 <= SourceList[index14].Count - 1; ++index15)
          {
            Pnt1 = new Pnt6D(SourceList[index14][index15]);
            if (index15 == 1)
            {
              Pnt1.X += 0.02;
              Pnt1.Y += 0.02;
            }
            orientationAngle4 = new OrientationAngle(Pnt1);
            CalcPoint = new Pnt6D();
            Pnt3D Pnt4 = new Pnt3D(Pnt1);
            if (Operation.UseSweepOperation)
            {
              if (Operation.SweepFollowTangent)
                orientationAngle4.C += Operation.SweepOffsetAngleForTangent;
              else
                orientationAngle4.C = Operation.SweepConstantAngle;
            }
            buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(Pnt4), ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
            camPoint2.Points.Add(new Pnt9DCam(CalcPoint, feed2, 1));
            vertice.Add(new Pnt3D(Pnt4));
            pnt3D6 = new Pnt3D(Pnt1);
            Pnt6D pnt6D10 = new Pnt6D(CalcPoint);
            OrientationAngle orientationAngle5 = new OrientationAngle(orientationAngle4);
            if (index15 == 1)
              camPoint2.Points[camPoint2.Points.Count - 1].PreCodes.Add((object) "G38 O1");
          }
          camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G39 O1");
          if (vertice.Count > 0)
          {
            camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
            camPoint2.EntitiesG1[camPoint2.EntitiesG1.Count - 1].BaseEntityIndex = CopiedEnt[index5][0].EntityIndex;
          }
          if (Operation.SawDistanceWithDepth > 0.0 && vertice.Count > 1)
          {
            Pnt3D EndPnt1 = new Pnt3D();
            double num24 = buAppCalc.cVector.PointAngle(vertice[1], vertice[0]);
            buAppCalc.cVector.LineWithLengthAndAngle(vertice[0], Operation.SawDistanceWithDepth, num24 + 180.0, new WorkPlane(), ref EndPnt1);
            geoLine geoLine1 = new geoLine(vertice[0], EndPnt1);
            camPoint2.EntitiesMark.Add((geoEntity) geoLine1);
            camPoint2.EntitiesMark[camPoint2.EntitiesMark.Count - 1].BaseEntityIndex = CopiedEnt[index5][0].EntityIndex;
            Pnt3D EndPnt2 = new Pnt3D();
            double Angle = buAppCalc.cVector.PointAngle(vertice[vertice.Count - 1], vertice[vertice.Count - 2]);
            buAppCalc.cVector.LineWithLengthAndAngle(vertice[vertice.Count - 1], Operation.SawDistanceWithDepth, Angle, new WorkPlane(), ref EndPnt2);
            geoLine geoLine2 = new geoLine(vertice[vertice.Count - 1], EndPnt2);
            camPoint2.EntitiesMark.Add((geoEntity) geoLine2);
            camPoint2.EntitiesMark[camPoint2.EntitiesMark.Count - 1].BaseEntityIndex = CopiedEnt[index5][0].EntityIndex;
          }
          double Length2 = (camPar.Distances.Safe - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
          double Length3 = (Operation.MaterialThickness + camPar.Distances.StepUp - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
          bool flag3 = orientationAngle4.A != orientationAngle3.A;
          if (index14 == SourceList.Count - 1)
            flag3 = true;
          CalcPoint = new Pnt6D();
          Pnt3D calcPoint3 = new Pnt3D();
          pnt3D4 = new Pnt3D(pnt3D6.X, pnt3D6.Y, pnt3D6.Z + Length3);
          buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length3, ref calcPoint3);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint3), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Leave, 1));
          camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(pnt3D6), new Pnt3D(calcPoint3), Color.Red));
          camPoint2.EntitiesG1[camPoint2.EntitiesG1.Count - 1].BaseEntityIndex = CopiedEnt[index5][0].EntityIndex;
          num3 = Operation.MaterialThickness + camPar.Distances.StepUp;
          orientationAngle1 = new OrientationAngle(orientationAngle4);
          if (flag3)
          {
            CalcPoint = new Pnt6D();
            Pnt3D calcPoint4 = new Pnt3D();
            pnt3D4 = new Pnt3D(pnt3D6.X, pnt3D6.Y, pnt3D6.Z + Length2);
            buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length2, ref calcPoint4);
            buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint4), ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
            camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Rapid, 0));
            camPoint2.EntitiesG0.Add((geoEntity) new geoLine(new Pnt3D(pnt3D6), new Pnt3D(calcPoint4), Color.Gold));
            camPoint2.EntitiesG0[camPoint2.EntitiesG0.Count - 1].BaseEntityIndex = CopiedEnt[index5][0].EntityIndex;
            num3 = camPar.Distances.Safe;
          }
          pnt6D3 = new Pnt6D(CalcPoint);
          if (index14 != SourceList.Count - 1)
            ;
          if (camPoint2.Points.Count > 0)
          {
            Pnt6D Pnt5 = new Pnt6D(camPoint2.Points[0]);
            camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(Pnt5));
          }
          for (int index16 = 1; index16 <= camPoint2.Points.Count - 1; ++index16)
          {
            List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
            double dt = 0.1;
            Pnt6D pnt6D11 = new Pnt6D(camPoint2.Points[index16 - 1].P9);
            Pnt6D pnt6D12 = new Pnt6D(camPoint2.Points[index16].P9);
            if (camPoint2.Points[index16].Type == 0)
              dt = 0.25;
            if (buAppCalc.cVector.Length3D(pnt6D11, pnt6D12) > 3.0)
            {
              buAppCalc.cVector.LineerInterpolation(new Pnt6D(pnt6D11), new Pnt6D(pnt6D12), dt, ref CalculatedPoints);
              CalculatedPoints.RemoveAt(0);
              camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
            }
            else
              camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(pnt6D12));
          }
          calcCam.CamPoints.Add(camPoint2);
        }
        Pnt6D.Add(SourceList, ref calcCam.CalculatedPnt6D);
        for (int index17 = 0; index17 <= CopiedEnt[index5].Count - 1; ++index17)
          calcCam.BaseEntitiesIndex.Add(CopiedEnt[index5][index17].EntityIndex);
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null && CalcEventCount > 0 & num2 > 0 && num2 % CalcEventCount == 0)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double) index5 / (double) (CopiedEnt.Count - 1)) * 100.0, Convert.ToDouble((double) index5 / (double) (CopiedEnt.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & CalcEventCount > 0 & num2 > 0 && num2 % CalcEventCount == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num2;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
          }
          buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      eEntities.CopyEntities(CopiedEnt, ref calcCam.CalculatedEntities);
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculateMarbleWireFrameWithSaw2(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    marbleOperation Operation,
    marbleCamParameters CamMarblePars,
    camParameters camPar,
    EntitiesResolution Resolution,
    ref camBase calcCam)
  {
    try
    {
      List<List<eEntities>> CopiedEnt = new List<List<eEntities>>();
      if (Operation.ApplySurfaceReadData & Operation.SurfaceReadDevideLength > 0.0)
      {
        for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
        {
          List<eEntities> eEntitiesList = new List<eEntities>();
          List<Pnt3D> Points = new List<Pnt3D>();
          buAppCalc.cVector.EntitiesToPoint(Entities[index1], new EntitiesResolution()
          {
            ArcResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            CircleResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            CurveResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            EllipseResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            LineResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            OtherResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength),
            PolylineResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength)
          }, ref Points);
          Points[Points.Count - 1] = new Pnt3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
          for (int index2 = 0; index2 <= Points.Count - 1; ++index2)
          {
            double num = 0.0;
            int index3 = Convert.ToInt32(Points[index2].X);
            int index4 = Convert.ToInt32(Points[index2].Y);
            if (index3 < 0)
              index3 = 0;
            if (index4 < 0)
              index4 = 0;
            if (index4 >= 0 & index4 <= buCamCalc.pntTeachGrids.Count - 1 && index3 >= 0 & index3 <= buCamCalc.pntTeachGrids[index4].Count - 1)
              num = buCamCalc.pntTeachGrids[index4][index3].Z;
            Points[index2] = new Pnt3D(Points[index2].X, Points[index2].Y, Points[index2].Z + num);
          }
          ePolyline ePolyline = new ePolyline(Points);
          ePolyline.Orientation = new OrientationAngle(Entities[index1][0].Orientation);
          eEntitiesList.Add((eEntities) ePolyline);
          CopiedEnt.Add(eEntitiesList);
        }
      }
      else
        eEntities.CopyEntities(Entities, ref CopiedEnt);
      bool flag1 = camPar.Strategy.UseTangentLimit;
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      double num1 = camPar.Strategy.AngleLimit;
      List<Triangle3D> Triangles = new List<Triangle3D>();
      calcCam = new camBase();
      calcCam.Tool = new ToolBase(Tool);
      calcCam.Kinematic = new KinematicBase(Kinematic);
      KinematicItem kinematicItem = new KinematicItem();
      kinematicItem.Axis.A = true;
      kinematicItem.Axis.C = true;
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, -Kinematic.RotateCenterOffsetOfC.Y, -Kinematic.RotateCenterOffsetOfC.Z), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 1.0, 0.0), new EntityResolution(), ref Triangles);
      eSurface eSurface = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      calcCam.Kinematic.Items.Add(kinematicItem);
      calcCam.Kinematic.MovePartRuntimeOffset.X = 0.0;
      calcCam.Kinematic.MovePartRuntimeOffset.Y = -Kinematic.RotateCenterOffsetOfC.Y;
      calcCam.Kinematic.MovePartRuntimeOffset.Z = -Kinematic.RotateCenterOffsetOfC.Z;
      CamPoint camPoint1 = new CamPoint();
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      List<List<Pnt6D>> pnt6DListList = new List<List<Pnt6D>>();
      if (Operation.UseSweepOperation && !Operation.SweepZUpSharpCorner)
        flag1 = false;
      Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
      for (int index5 = 0; index5 <= CopiedEnt.Count - 1; ++index5)
      {
        List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
        if (CopiedEnt[index5].Count >= 1)
        {
          List<Pnt6D> Points = new List<Pnt6D>();
          List<Pnt6D> pnt6DList2 = new List<Pnt6D>();
          buAppCalc.cVector.EntitiesToPoint(CopiedEnt[index5], Resolution, ref Points);
          buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points, 0.01);
          if (Points.Count > 1)
          {
            double num2 = 0.0;
            double c1 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[1]), new Pnt3D(Points[0]));
            if (CamMarblePars.UseCZero)
              c1 = 0.0;
            if (CopiedEnt[index5].Count == 1 & Points[0].C != 0.0)
              c1 = Points[0].C;
            if (Operation.ProfileCutFinishEnable & Operation.ProfileCutFinishVector == VectorXYType.XVector)
              c1 = 0.0;
            double num3 = c1;
            pnt6DList1.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, c1));
            for (int index6 = 1; index6 <= Points.Count - 2; ++index6)
            {
              bool flag2 = false;
              double c2 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index6]), new Pnt3D(Points[index6 - 1]));
              if (CamMarblePars.UseCZero)
                c2 = 0.0;
              if (Operation.ProfileCutFinishEnable & Operation.ProfileCutFinishVector == VectorXYType.XVector)
                c2 = 0.0;
              if (index6 != 90)
                ;
              double c3;
              double num4;
              if (flag1)
              {
                num2 = Points[index6 - 1].A - Points[index6].A;
                if (Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C) > 185.0)
                {
                  if (pnt6DList1[pnt6DList1.Count - 1].C > c2)
                    c2 += 360.0;
                  else
                    c2 -= 360.0;
                }
                c3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index6 + 1]), new Pnt3D(Points[index6]));
                if (CamMarblePars.UseCZero)
                  c3 = 0.0;
                if (Operation.ProfileCutFinishEnable & Operation.ProfileCutFinishVector == VectorXYType.XVector)
                  c3 = 0.0;
                num1 = camPar.Strategy.AngleLimit;
                double num5 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6 + 1]), new WorkPlane());
                if (CopiedEnt[index5][0].OperationPlane == planeType.YZ)
                {
                  if (camPar.Strategy.UseLimitAngleForOtherPlane)
                    num1 = camPar.Strategy.AngleLimitYZ;
                  num5 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6 + 1]), new WorkPlane(planeType.YZ, 1));
                }
                num4 = 180.0 - num5;
                if (num4 >= 360.0 - num1)
                  num4 = 360.0 - num5;
                Math.Abs(c2 - num3);
                if (Math.Abs(num2) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
                {
                  pnt6DListList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c3));
                  flag2 = true;
                }
              }
              else
              {
                num1 = camPar.Strategy.AngleLimit;
                double num6 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6]), new Pnt3D(Points[index6 + 1]), new WorkPlane());
                num4 = 180.0 - num6;
                if (num4 >= 360.0 - num1)
                  num4 = 360.0 - num6;
                c3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index6 + 1]), new Pnt3D(Points[index6]));
                if (CamMarblePars.UseCZero)
                  c3 = 0.0;
                if (Operation.ProfileCutFinishEnable & Operation.ProfileCutFinishVector == VectorXYType.XVector)
                  c3 = 0.0;
                if (num4 > num1)
                {
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6 + 1].A, 0.0, c3));
                  flag2 = true;
                }
                Math.Abs(c2 - num3);
                if (Math.Abs(num2) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
                {
                  pnt6DListList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c3));
                  flag2 = true;
                }
              }
              if (!flag2)
              {
                if (num4 > num1 & flag1)
                {
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                  pnt6DListList.Add(pnt6DList1);
                  pnt6DList1 = new List<Pnt6D>();
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6 + 1].A, 0.0, c3));
                }
                else
                {
                  if (flag1)
                  {
                    double num7 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                    if (num7 >= 360.0 - num1)
                    {
                      if (c2 > pnt6DList1[pnt6DList1.Count - 1].C)
                        c2 -= 360.0;
                      else
                        c2 += 360.0;
                      num7 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                    }
                    if (num7 > 185.0)
                      c2 += 360.0;
                  }
                  pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                  if (Math.Abs(c2 - c3) > 180.1)
                  {
                    double num8 = c2 - c3;
                    if (c2 > c3)
                    {
                      double num9 = c3 + 360.0;
                      double lower = buNumeric.RoundToLower(Math.Abs(c2 - num9) / 360.0);
                      c3 = num9 + lower * 360.0;
                    }
                    else
                    {
                      double num10 = c3 - 360.0;
                      double lower = buNumeric.RoundToLower(Math.Abs(c2 - num10) / 360.0);
                      c3 = num10 - lower * 360.0;
                    }
                  }
                  if (camPar.Options.AxesLimit.MinLimit != camPar.Options.AxesLimit.MaxLimit)
                  {
                    if (c3 > camPar.Options.AxesLimit.MaxLimit.C)
                    {
                      pnt6DListList.Add(pnt6DList1);
                      c2 -= 360.0;
                      pnt6DList1 = new List<Pnt6D>();
                      pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                    }
                    if (c3 < camPar.Options.AxesLimit.MinLimit.C)
                    {
                      pnt6DListList.Add(pnt6DList1);
                      c2 += 360.0;
                      pnt6DList1 = new List<Pnt6D>();
                      pnt6DList1.Add(new Pnt6D(Points[index6].X, Points[index6].Y, Points[index6].Z, Points[index6].A, 0.0, c2));
                    }
                  }
                }
              }
              num3 = c2;
            }
            if (pnt6DList1.Count > 0)
            {
              double c4 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[Points.Count - 1]), new Pnt3D(Points[Points.Count - 2]));
              if (CamMarblePars.UseCZero)
                c4 = 0.0;
              if (CopiedEnt[index5].Count == 1 & Points[Points.Count - 1].C != 0.0)
                c4 = Points[Points.Count - 1].C;
              double num11 = Math.Abs(c4 - pnt6DList1[pnt6DList1.Count - 1].C);
              if (num11 >= 360.0 - num1)
              {
                num11 = 360.0 - c4;
                if (c4 > pnt6DList1[pnt6DList1.Count - 1].C)
                  c4 -= 360.0;
              }
              if (num11 > 185.0)
                c4 += 360.0;
              pnt6DList1.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, c4));
              pnt6DListList.Add(pnt6DList1);
            }
          }
        }
      }
      int int32 = Convert.ToInt32((double) pnt6DListList.Count / 100.0);
      int num12 = 0;
      Pnt6D pnt6D2 = new Pnt6D();
      Pnt6D pnt6D3 = new Pnt6D();
      double num13 = camPar.Distances.Safe;
      OrientationAngle orientationAngle1 = new OrientationAngle();
      if (Operation.SawRampEnable & Operation.SawRampType != CamZRampType.None)
      {
        for (int index7 = 0; index7 <= pnt6DListList.Count - 1; ++index7)
        {
          List<double> doubleList = new List<double>();
          List<Pnt6D> CopiedPnt = new List<Pnt6D>();
          List<Pnt6D> calcStartPoints = new List<Pnt6D>();
          List<Pnt6D> calcMiddlePoints = new List<Pnt6D>();
          List<Pnt6D> calcEndPoints = new List<Pnt6D>();
          Pnt6D.Copy(pnt6DListList[index7], ref CopiedPnt);
          buAppCalc.cVector.DevidePointList(CopiedPnt, Operation.SawDevideLength, Operation.SawRampLenght, Operation.SawRampLenght, true, DevideTipType.StartAndEnd, ref calcStartPoints, ref calcMiddlePoints, ref calcEndPoints);
          if (Operation.SawRampType == CamZRampType.Linear)
          {
            doubleList = new List<double>();
            buNumeric.DevideMinMaxValueByNumber(Operation.SawRampHeight, Operation.TargetZ, calcStartPoints.Count, ref doubleList);
            for (int index8 = 0; index8 <= doubleList.Count - 1; ++index8)
              calcStartPoints[index8] = new Pnt6D(calcStartPoints[index8].X, calcStartPoints[index8].Y, doubleList[index8], calcStartPoints[index8].A, calcStartPoints[index8].B, calcStartPoints[index8].C);
            doubleList = new List<double>();
            buNumeric.DevideMinMaxValueByNumber(Operation.TargetZ, Operation.SawRampHeight, calcEndPoints.Count, ref doubleList);
            for (int index9 = 0; index9 <= doubleList.Count - 1; ++index9)
              calcEndPoints[index9] = new Pnt6D(calcEndPoints[index9].X, calcEndPoints[index9].Y, doubleList[index9], calcEndPoints[index9].A, calcEndPoints[index9].B, calcEndPoints[index9].C);
          }
          if (Operation.SawRampType == CamZRampType.Circular)
          {
            List<Pnt3D> Points = new List<Pnt3D>();
            doubleList = new List<double>();
            buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.SawRampHeight, Operation.TargetZ, 1.0, 200, ref doubleList, ref Points);
            double num14 = 0.0;
            calcStartPoints[0] = new Pnt6D(calcStartPoints[0].X, calcStartPoints[0].Y, doubleList[0], calcStartPoints[0].A, calcStartPoints[0].B, calcStartPoints[0].C);
            for (int index10 = 1; index10 <= calcStartPoints.Count - 1; ++index10)
            {
              double num15 = buAppCalc.cVector.Length3D(new Pnt3D(calcStartPoints[index10 - 1]), new Pnt3D(calcStartPoints[index10]), new WorkPlane());
              num14 += num15;
              double num16 = 0.0;
              double num17 = 0.0;
              for (int index11 = 1; index11 <= Points.Count - 1; ++index11)
              {
                double num18 = buAppCalc.cVector.Length3D(new Pnt3D(Points[index11 - 1].X, Points[index11 - 1].Y), new Pnt3D(Points[index11].X, Points[index11].Y));
                num16 += num18;
                if (num17 <= num14 & num14 <= num16)
                {
                  calcStartPoints[index10] = new Pnt6D(calcStartPoints[index10].X, calcStartPoints[index10].Y, doubleList[index11], calcStartPoints[index10].A, calcStartPoints[index10].B, calcStartPoints[index10].C);
                  index11 = 100000;
                }
                num17 = num16;
              }
            }
            calcStartPoints[calcStartPoints.Count - 1] = new Pnt6D(calcStartPoints[calcStartPoints.Count - 1].X, calcStartPoints[calcStartPoints.Count - 1].Y, doubleList[doubleList.Count - 1], calcStartPoints[calcStartPoints.Count - 1].A, calcStartPoints[calcStartPoints.Count - 1].B, calcStartPoints[calcStartPoints.Count - 1].C);
            doubleList = new List<double>();
            buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.TargetZ, Operation.SawRampHeight, 1.0, 200, ref doubleList, ref Points);
            double num19 = 0.0;
            calcEndPoints[0] = new Pnt6D(calcEndPoints[0].X, calcEndPoints[0].Y, doubleList[0], calcEndPoints[0].A, calcEndPoints[0].B, calcEndPoints[0].C);
            for (int index12 = 1; index12 <= calcEndPoints.Count - 1; ++index12)
            {
              double num20 = buAppCalc.cVector.Length3D(new Pnt3D(calcEndPoints[index12 - 1]), new Pnt3D(calcEndPoints[index12]), new WorkPlane());
              num19 += num20;
              double num21 = 0.0;
              double num22 = 0.0;
              for (int index13 = 1; index13 <= Points.Count - 1; ++index13)
              {
                double num23 = buAppCalc.cVector.Length3D(new Pnt3D(Points[index13 - 1].X, Points[index13 - 1].Y), new Pnt3D(Points[index13].X, Points[index13].Y));
                num21 += num23;
                if (num22 <= num19 & num19 <= num21)
                {
                  calcEndPoints[index12] = new Pnt6D(calcEndPoints[index12].X, calcEndPoints[index12].Y, doubleList[index13], calcEndPoints[index12].A, calcEndPoints[index12].B, calcEndPoints[index12].C);
                  index13 = 100000;
                }
                num22 = num21;
              }
            }
            calcEndPoints[calcEndPoints.Count - 1] = new Pnt6D(calcEndPoints[calcEndPoints.Count - 1].X, calcEndPoints[calcEndPoints.Count - 1].Y, doubleList[doubleList.Count - 1], calcEndPoints[calcEndPoints.Count - 1].A, calcEndPoints[calcEndPoints.Count - 1].B, calcEndPoints[calcEndPoints.Count - 1].C);
          }
          List<Pnt6D> Points1 = new List<Pnt6D>();
          Points1.AddRange((IEnumerable<Pnt6D>) calcStartPoints);
          Points1.AddRange((IEnumerable<Pnt6D>) calcMiddlePoints);
          Points1.AddRange((IEnumerable<Pnt6D>) calcEndPoints);
          buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points1);
          pnt6DListList[index7] = new List<Pnt6D>();
          pnt6DListList[index7] = Points1;
        }
      }
      for (int index14 = 0; index14 <= pnt6DListList.Count - 1; ++index14)
      {
        double ToolLength = Tool.Geometry.Diameter / 2.0;
        double feed1 = camPar.Speeds.Feed;
        double safe = camPar.Distances.Safe;
        double stepUp = camPar.Distances.StepUp;
        Pnt6D pnt6D4 = new Pnt6D();
        Pnt6D pnt6D5 = new Pnt6D();
        Pnt6D CalcPoint = new Pnt6D();
        Pnt3D pnt3D2 = new Pnt3D();
        Pnt3D pnt3D3 = new Pnt3D();
        Pnt3D pnt3D4 = new Pnt3D();
        OrientationAngle orientationAngle2 = new OrientationAngle();
        OrientationAngle orientationAngle3 = new OrientationAngle();
        if (index14 <= pnt6DListList.Count - 2)
          orientationAngle3 = new OrientationAngle(new Pnt6D(pnt6DListList[index14 + 1][0]));
        CamPoint camPoint2 = new CamPoint();
        camPoint2.Type = 0;
        camPoint2.IsRapid = true;
        CalcPoint = new Pnt6D();
        Pnt6D Pnt1 = new Pnt6D(pnt6DListList[index14][0]);
        Pnt3D pnt3D5 = new Pnt3D(Pnt1);
        pnt3D3 = new Pnt3D();
        pnt3D4 = new Pnt3D();
        OrientationAngle orientationAngle4 = new OrientationAngle(Pnt1);
        if (Operation.UseSweepOperation)
        {
          if (Operation.SweepFollowTangent)
            orientationAngle4.C += Operation.SweepOffsetAngleForTangent;
          else
            orientationAngle4.C = Operation.SweepConstantAngle;
        }
        double feed2 = camPar.Speeds.Feed;
        double Length1 = (num13 - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        CalcPoint = new Pnt6D();
        Pnt3D calcPoint1 = new Pnt3D();
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length1, ref calcPoint1);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint1), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        if (orientationAngle4.A != orientationAngle1.A && pnt6D3.Z > CalcPoint.Z)
          CalcPoint.Z = pnt6D3.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Rapid, 0, true));
        pnt3D1 = new Pnt3D(calcPoint1);
        Pnt6D pnt6D6 = new Pnt6D(CalcPoint);
        CalcPoint = new Pnt6D();
        Pnt3D calcPoint2 = new Pnt3D();
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length1, ref calcPoint2);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint2), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Rapid, 0));
        Pnt3D Pnt2 = new Pnt3D(calcPoint2);
        Pnt6D pnt6D7 = new Pnt6D(CalcPoint);
        if (index14 == 0)
        {
          Pnt6D pnt6D8 = new Pnt6D(CalcPoint);
        }
        CalcPoint = new Pnt6D();
        Pnt3D Pnt3 = new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(Pnt3), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Plunge, 1));
        camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(Pnt3), Color.Lime));
        Pnt3D pnt3D6 = new Pnt3D(pnt3D5);
        Pnt6D pnt6D9 = new Pnt6D(CalcPoint);
        List<Pnt3D> vertice = new List<Pnt3D>();
        vertice.Add(new Pnt3D(pnt3D6));
        for (int index15 = 1; index15 <= pnt6DListList[index14].Count - 1; ++index15)
        {
          Pnt1 = new Pnt6D(pnt6DListList[index14][index15]);
          orientationAngle4 = new OrientationAngle(Pnt1);
          CalcPoint = new Pnt6D();
          Pnt3D Pnt4 = new Pnt3D(Pnt1);
          if (Operation.UseSweepOperation)
          {
            if (Operation.SweepFollowTangent)
              orientationAngle4.C += Operation.SweepOffsetAngleForTangent;
            else
              orientationAngle4.C = Operation.SweepConstantAngle;
          }
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(Pnt4), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, feed2, 1));
          vertice.Add(new Pnt3D(Pnt4));
          pnt3D6 = new Pnt3D(Pnt1);
          Pnt6D pnt6D10 = new Pnt6D(CalcPoint);
          OrientationAngle orientationAngle5 = new OrientationAngle(orientationAngle4);
        }
        if (vertice.Count > 0)
          camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
        if (Operation.SawDistanceWithDepth > 0.0 && vertice.Count > 1)
        {
          Pnt3D EndPnt1 = new Pnt3D();
          double num24 = buAppCalc.cVector.PointAngle(vertice[1], vertice[0]);
          buAppCalc.cVector.LineWithLengthAndAngle(vertice[0], Operation.SawDistanceWithDepth, num24 + 180.0, new WorkPlane(), ref EndPnt1);
          geoLine geoLine1 = new geoLine(vertice[0], EndPnt1);
          camPoint2.EntitiesMark.Add((geoEntity) geoLine1);
          Pnt3D EndPnt2 = new Pnt3D();
          double Angle = buAppCalc.cVector.PointAngle(vertice[vertice.Count - 1], vertice[vertice.Count - 2]);
          buAppCalc.cVector.LineWithLengthAndAngle(vertice[vertice.Count - 1], Operation.SawDistanceWithDepth, Angle, new WorkPlane(), ref EndPnt2);
          geoLine geoLine2 = new geoLine(vertice[vertice.Count - 1], EndPnt2);
          camPoint2.EntitiesMark.Add((geoEntity) geoLine2);
        }
        double Length2 = (camPar.Distances.Safe - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        double Length3 = (Operation.MaterialThickness + camPar.Distances.StepUp - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        bool flag3 = orientationAngle4.A != orientationAngle3.A;
        if (index14 == pnt6DListList.Count - 1)
          flag3 = true;
        CalcPoint = new Pnt6D();
        Pnt3D calcPoint3 = new Pnt3D();
        pnt3D4 = new Pnt3D(pnt3D6.X, pnt3D6.Y, pnt3D6.Z + Length3);
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length3, ref calcPoint3);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint3), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Leave, 1));
        camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(pnt3D6), new Pnt3D(calcPoint3), Color.Red));
        num13 = Operation.MaterialThickness + camPar.Distances.StepUp;
        orientationAngle1 = new OrientationAngle(orientationAngle4);
        if (flag3)
        {
          CalcPoint = new Pnt6D();
          Pnt3D calcPoint4 = new Pnt3D();
          pnt3D4 = new Pnt3D(pnt3D6.X, pnt3D6.Y, pnt3D6.Z + Length2);
          buAppCalc.cVector.LineWithOrientationAngle(pnt3D6, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length2, ref calcPoint4);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint4), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camPar.Speeds.Rapid, 0));
          camPoint2.EntitiesG0.Add((geoEntity) new geoLine(new Pnt3D(pnt3D6), new Pnt3D(calcPoint4), Color.Gold));
          num13 = camPar.Distances.Safe;
        }
        pnt6D3 = new Pnt6D(CalcPoint);
        if (index14 != pnt6DListList.Count - 1)
          ;
        if (camPoint2.Points.Count > 0)
          camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
        for (int index16 = 1; index16 <= camPoint2.Points.Count - 1; ++index16)
        {
          List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
          double dt = 0.1;
          if (camPoint2.Points[index16].Type == 0)
            dt = 0.25;
          if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index16 - 1]), new Pnt3D(camPoint2.Points[index16])) > 3.0)
          {
            buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index16 - 1]), new Pnt6D(camPoint2.Points[index16]), dt, ref CalculatedPoints);
            CalculatedPoints.RemoveAt(0);
            camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
          }
          else
            camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index16]));
        }
        calcCam.CamPoints.Add(camPoint2);
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null && int32 > 0 & num12 > 0 && num12 % int32 == 0)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double) index14 / (double) (pnt6DListList.Count - 1)) * 100.0, Convert.ToDouble((double) index14 / (double) (pnt6DListList.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num12 > 0 && num12 % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num12;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
          }
          buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      if (calcCam.CamPoints.Count > 0)
      {
        for (int index17 = 0; index17 <= Entities.Count - 1; ++index17)
        {
          for (int index18 = 0; index18 <= Entities[index17].Count - 1; ++index18)
            calcCam.BaseEntitiesIndex.Add(Entities[index17][index18].EntityIndex);
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculateMarbleWireFrameWithMillingAndWaterJetTool3Ax(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    bool WaterJetMode,
    camParameters CamParameter,
    double AValue,
    double CValue,
    string WaterJetAirUpCmd,
    string WaterJetDownOperationCmd,
    string WaterJetOnCmd,
    string WaterJetOffCmd,
    string WaterJetNextOn,
    string WaterJetNextOff,
    string WaterJetApproach,
    EntitiesResolution Resolution,
    ref camBase calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      calcCam = new camBase();
      calcCam.Tool = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      List<Triangle3D> Triangles = new List<Triangle3D>();
      KinematicItem kinematicItem = new KinematicItem();
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
      kinematicItem.Axis.A = false;
      kinematicItem.Axis.C = false;
      eEntities eEntities = (eEntities) new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      kinematicItem.Entities.Add(eEntities);
      calcCam.Kinematic.Items.Add(kinematicItem);
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      int int32 = Convert.ToInt32((double) Entities.Count / 100.0);
      int num1 = 0;
      Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
      for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
      {
        eEntities copiedEnt1 = new eEntities();
        if (Entities[index1].Count > 0)
        {
          eEntities copiedEnt2 = new eEntities();
          List<Pnt3D> TargetList = new List<Pnt3D>();
          eEntities.CopyEntity(Entities[index1][0], ref copiedEnt2);
          buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList);
          List<Pnt6D> Points = new List<Pnt6D>();
          buAppCalc.cVector.EntitiesToPoint(Entities[index1], Resolution, ref Points);
          if (CamParameter.Strategy.OverrideCEnable)
          {
            for (int index2 = 0; index2 <= Points.Count - 1; ++index2)
              Points[index2] = new Pnt6D(Points[index2])
              {
                C = CamParameter.Strategy.OverrideC
              };
            buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points);
          }
          if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
            TargetList.Reverse();
          CamPoint camPoint2 = new CamPoint();
          camPoint2.Type = 0;
          camPoint2.IsRapid = true;
          if (Points.Count > 1)
          {
            Pnt3D Pnt1 = new Pnt3D(Points[0]);
            OrientationAngle orientationAngle1 = new OrientationAngle(Points[0]);
            OrientationAngle orientationAngle2 = new OrientationAngle(Points[0]);
            Pnt6D pnt6D2 = new Pnt6D();
            Pnt6D pnt6D3 = new Pnt6D(new Pnt3D(Pnt1.X, Pnt1.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
            if (!WaterJetMode)
            {
              camPoint2.Points.Add(new Pnt9DCam(pnt6D3, CamParameter.Speeds.Rapid, 0)
              {
                PlungeAxisMovement = true
              });
              camPoint2.Points.Add(new Pnt9DCam(pnt6D3, CamParameter.Speeds.Rapid, 0));
            }
            Pnt3D Pnt2 = new Pnt3D(Pnt1.X, Pnt1.Y, CamParameter.Distances.Safe);
            Pnt6D pnt6D4 = new Pnt6D(pnt6D3);
            Pnt6D pnt6D5 = new Pnt6D(Pnt1, new OrientationAngle(AValue, 0.0, CValue));
            if (!WaterJetMode)
            {
              camPoint2.Points.Add(new Pnt9DCam(pnt6D5, CamParameter.Speeds.Plunge, 1));
            }
            else
            {
              Pnt9DCam pnt9Dcam = new Pnt9DCam(pnt6D5, CamParameter.Speeds.Plunge, 0);
              if (index1 == 0)
              {
                pnt9Dcam.AfterCodes.Add((object) WaterJetApproach);
                pnt9Dcam.AfterCodes.Add((object) WaterJetDownOperationCmd);
                pnt9Dcam.AfterCodes.Add((object) WaterJetOnCmd);
              }
              else
                pnt9Dcam.AfterCodes.Add((object) WaterJetNextOn);
              camPoint2.Points.Add(pnt9Dcam);
            }
            camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(Pnt1), Color.Lime));
            Pnt3D Pnt3 = new Pnt3D(Pnt1);
            Pnt6D pnt6D6 = new Pnt6D(pnt6D5);
            List<Pnt3D> vertice = new List<Pnt3D>();
            vertice.Add(new Pnt3D(Pnt3));
            for (int index3 = 1; index3 <= Points.Count - 1; ++index3)
            {
              Pnt3D pnt3D2 = new Pnt3D(Points[index3]);
              OrientationAngle Pnt4 = new OrientationAngle(Points[index3]);
              double feed = CamParameter.Speeds.Feed;
              Pnt6D pnt6D7 = new Pnt6D(new Pnt3D(Points[index3].X, Points[index3].Y, Points[index3].Z), new OrientationAngle(AValue, 0.0, CValue));
              camPoint2.Points.Add(new Pnt9DCam(pnt6D7, feed, 1));
              vertice.Add(new Pnt3D(pnt6D7));
              Pnt3 = new Pnt3D(Points[index3]);
              Pnt6D pnt6D8 = new Pnt6D(pnt6D7);
              OrientationAngle orientationAngle3 = new OrientationAngle(Pnt4);
            }
            camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
            Pnt6D pnt6D9;
            if (!WaterJetMode)
            {
              pnt6D9 = new Pnt6D(new Pnt3D(Pnt3.X, Pnt3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
              camPoint2.Points.Add(new Pnt9DCam(pnt6D9, CamParameter.Speeds.Leave, 1));
            }
            else
            {
              pnt6D9 = new Pnt6D(new Pnt3D(Pnt3.X, Pnt3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
              Pnt9DCam pnt9Dcam = new Pnt9DCam(pnt6D9, CamParameter.Speeds.Plunge, 1);
              if (index1 == Entities.Count - 1)
              {
                pnt9Dcam.AfterCodes.Add((object) WaterJetOffCmd);
                pnt9Dcam.AfterCodes.Add((object) WaterJetApproach);
                pnt9Dcam.AfterCodes.Add((object) WaterJetAirUpCmd);
              }
              else
                pnt9Dcam.AfterCodes.Add((object) WaterJetNextOff);
              camPoint2.Points.Add(pnt9Dcam);
            }
            camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt3), new Pnt3D(pnt6D9), Color.Red));
            double num2 = 0.0;
            if (Tool.Purpose == ToolPurpose.Saw)
              num2 = Tool.Geometry.Diameter / 2.0;
            if (camPoint2.Points.Count > 0)
              camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0].P9.X, camPoint2.Points[0].P9.Y, camPoint2.Points[0].P9.Z + num2, camPoint2.Points[0].P9.A, camPoint2.Points[0].P9.B, camPoint2.Points[0].P9.C));
            for (int index4 = 1; index4 <= camPoint2.Points.Count - 1; ++index4)
            {
              List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
              double dt = 0.1;
              if (camPoint2.Points[index4].Type == 0)
                dt = 0.25;
              Pnt6D pnt6D10 = new Pnt6D(camPoint2.Points[index4 - 1].P9.X, camPoint2.Points[index4 - 1].P9.Y, camPoint2.Points[index4 - 1].P9.Z + num2, camPoint2.Points[index4 - 1].P9.A, camPoint2.Points[index4 - 1].P9.B, camPoint2.Points[index4 - 1].P9.C);
              Pnt6D pnt6D11 = new Pnt6D(camPoint2.Points[index4].P9.X, camPoint2.Points[index4].P9.Y, camPoint2.Points[index4].P9.Z + num2, camPoint2.Points[index4].P9.A, camPoint2.Points[index4].P9.B, camPoint2.Points[index4].P9.C);
              if (buAppCalc.cVector.Length3D(new Pnt3D(pnt6D10), new Pnt3D(pnt6D11)) > 3.0)
              {
                buAppCalc.cVector.LineerInterpolation(pnt6D10, pnt6D11, dt, ref CalculatedPoints);
                CalculatedPoints.RemoveAt(0);
                camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
              }
              else
                camPoint2.SimilationPoint.SimPoints.Add(pnt6D11);
            }
            eEntities.CopyEntity(copiedEnt2, ref copiedEnt1);
            calcCam.CamPoints.Add(camPoint2);
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double) index1 / (double) (Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num1 > 0 && num1 % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num1;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
          }
          buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      eEntities.CopyEntities(Entities, ref calcCam.CalculatedEntities);
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalculateMarbleWireFrameWithMillingAndWaterJetTool5Ax(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    bool WaterJetMode,
    marbleCamParameters CamMarblePars,
    camParameters camPar,
    marbleOperation Operation,
    double AValue,
    double CValue,
    string WaterJetAirUpCmd,
    string WaterJetDownOperationCmd,
    string WaterJetOnCmd,
    string WaterJetOffCmd,
    string WaterJetNextOn,
    string WaterJetNextOff,
    string WaterJetApproach,
    EntitiesResolution Resolution,
    ref camBase calcCam)
  {
    try
    {
      List<List<Pnt6D>> ContinousPoints = new List<List<Pnt6D>>();
      Pnt3D BasePoint = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      calcCam = new camBase();
      calcCam.Tool = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      double num1 = 0.0;
      List<Triangle3D> Triangles = new List<Triangle3D>();
      KinematicItem kinematicItem = new KinematicItem();
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
      kinematicItem.Axis.A = false;
      kinematicItem.Axis.C = false;
      eEntities eEntities = (eEntities) new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      kinematicItem.Entities.Add(eEntities);
      calcCam.Kinematic.Items.Add(kinematicItem);
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      Convert.ToInt32((double) Entities.Count / 100.0);
      int num2 = 0;
      Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
      this.CalcMarbleEntitiesToContinousPoint(Entities, Resolution, CamMarblePars, camPar, Operation, ref ContinousPoints);
      int int32 = Convert.ToInt32((double) ContinousPoints.Count / 100.0);
      Pnt6D pnt6D2 = new Pnt6D();
      Pnt6D pnt6D3 = new Pnt6D();
      OrientationAngle orientationAngle1 = new OrientationAngle();
      if (!Operation.WaterJet5AxisConcaveCalculation)
      {
        for (int index1 = 0; index1 <= ContinousPoints.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= ContinousPoints[index1].Count - 1; ++index2)
          {
            if (index1 > 0)
            {
              double c = ContinousPoints[index1][index2].C;
              if (camPar.Operations.Direction == ClockDirectionType.CCW && c < num1)
                ContinousPoints[index1][index2] = new Pnt6D(ContinousPoints[index1][index2].X, ContinousPoints[index1][index2].Y, ContinousPoints[index1][index2].Z, ContinousPoints[index1][index2].A, ContinousPoints[index1][index2].B, ContinousPoints[index1][index2].C + 360.0);
              if (camPar.Operations.Direction == ClockDirectionType.CW && c > num1)
                ContinousPoints[index1][index2] = new Pnt6D(ContinousPoints[index1][index2].X, ContinousPoints[index1][index2].Y, ContinousPoints[index1][index2].Z, ContinousPoints[index1][index2].A, ContinousPoints[index1][index2].B, ContinousPoints[index1][index2].C - 360.0);
            }
            num1 = ContinousPoints[index1][index2].C;
          }
        }
        for (int index3 = 0; index3 <= ContinousPoints.Count - 1; ++index3)
        {
          bool flag1 = false;
          double ToolLength = Tool.Geometry.Diameter / 2.0;
          double feed1 = camPar.Speeds.Feed;
          double safe = camPar.Distances.Safe;
          double stepUp = camPar.Distances.StepUp;
          Pnt6D pnt6D4 = new Pnt6D();
          Pnt6D pnt6D5 = new Pnt6D();
          Pnt6D pnt6D6 = new Pnt6D();
          Pnt3D pnt3D1 = new Pnt3D();
          Pnt3D pnt3D2 = new Pnt3D();
          Pnt3D pnt3D3 = new Pnt3D();
          OrientationAngle orientationAngle2 = new OrientationAngle();
          OrientationAngle orientationAngle3 = new OrientationAngle();
          if (index3 <= ContinousPoints.Count - 2)
            orientationAngle3 = new OrientationAngle(new Pnt6D(ContinousPoints[index3 + 1][0]));
          CamPoint camPoint2 = new CamPoint();
          camPoint2.Type = 0;
          camPoint2.IsRapid = true;
          pnt6D6 = new Pnt6D();
          Pnt6D Pnt1 = new Pnt6D(ContinousPoints[index3][0]);
          Pnt3D Pnt2 = new Pnt3D(Pnt1);
          pnt3D2 = new Pnt3D();
          Pnt3D pnt3D4 = new Pnt3D();
          OrientationAngle orientationAngle4 = new OrientationAngle(Pnt1);
          double feed2 = camPar.Speeds.Feed;
          pnt6D6 = new Pnt6D(Pnt2);
          pnt3D2 = new Pnt3D();
          double num3 = 0.0;
          if (index3 == 0 && orientationAngle4.A != 0.0)
          {
            num3 = orientationAngle4.A;
            Pnt1.A = 0.0;
          }
          Pnt6D pnt6D7 = new Pnt6D(Pnt1);
          pnt3D2 = new Pnt3D();
          Pnt9DCam pnt9Dcam = new Pnt9DCam(pnt6D7, camPar.Speeds.Rapid, 0);
          if (!buCompare.EQ(new Pnt3D(Pnt1), BasePoint) & index3 > 0)
            flag1 = true;
          if (index3 == 0)
          {
            pnt9Dcam.AfterCodes.Add((object) WaterJetApproach);
            pnt9Dcam.AfterCodes.Add((object) WaterJetDownOperationCmd);
            pnt9Dcam.AfterCodes.Add((object) WaterJetOnCmd);
            if (num3 != 0.0)
              pnt9Dcam.AfterCodes.Add((object) ("G0 A" + num3.ToString("f2")));
          }
          if (flag1)
          {
            pnt9Dcam.PreCodes.Add((object) WaterJetNextOff);
            pnt9Dcam.AfterCodes.Add((object) WaterJetNextOn);
          }
          if (orientationAngle4.A == orientationAngle1.A)
            ;
          camPoint2.Points.Add(pnt9Dcam);
          Pnt6D pnt6D8 = new Pnt6D(pnt6D7);
          if (index3 == 0)
          {
            Pnt6D pnt6D9 = new Pnt6D(pnt6D7);
          }
          List<Pnt3D> vertice = new List<Pnt3D>();
          vertice.Add(new Pnt3D(ContinousPoints[index3][0]));
          for (int index4 = 1; index4 <= ContinousPoints[index3].Count - 1; ++index4)
          {
            Pnt1 = new Pnt6D(ContinousPoints[index3][index4]);
            orientationAngle4 = new OrientationAngle(Pnt1);
            Pnt6D pnt6D10 = new Pnt6D(Pnt1);
            camPoint2.Points.Add(new Pnt9DCam(pnt6D10, feed2, 1));
            vertice.Add(new Pnt3D(Pnt1));
            BasePoint = new Pnt3D(Pnt1);
            Pnt6D pnt6D11 = new Pnt6D(pnt6D10);
            OrientationAngle orientationAngle5 = new OrientationAngle(orientationAngle4);
          }
          camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
          if (camPoint2.Points.Count > 0 & index3 == ContinousPoints.Count - 1)
          {
            camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) WaterJetOffCmd);
            camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) WaterJetApproach);
            camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G0 A0.0");
            camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G0 C0.0");
            camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) WaterJetAirUpCmd);
          }
          if (vertice.Count > 0)
            camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
          double Length = (camPar.Distances.Safe - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
          bool flag2 = orientationAngle4.A != orientationAngle3.A;
          if (index3 == ContinousPoints.Count - 1)
            flag2 = true;
          Pnt6D CalcPoint = new Pnt6D();
          pnt3D2 = new Pnt3D();
          Pnt3D pnt3D5 = new Pnt3D(BasePoint.X, BasePoint.Y, BasePoint.Z + stepUp);
          orientationAngle1 = new OrientationAngle(orientationAngle4);
          if (flag2)
          {
            CalcPoint = new Pnt6D();
            Pnt3D calcPoint = new Pnt3D();
            Pnt3D pnt3D6 = new Pnt3D(BasePoint.X, BasePoint.Y, BasePoint.Z + Length);
            buAppCalc.cVector.LineWithOrientationAngle(BasePoint, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length, ref calcPoint);
            buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint), ref CalcPoint);
            CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          }
          Pnt6D pnt6D12 = new Pnt6D(CalcPoint);
          if (camPoint2.Points.Count > 0)
            camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
          for (int index5 = 1; index5 <= camPoint2.Points.Count - 1; ++index5)
          {
            List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
            double dt = 0.1;
            if (camPoint2.Points[index5].Type == 0)
              dt = 0.25;
            if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index5 - 1]), new Pnt3D(camPoint2.Points[index5])) > 3.0)
            {
              buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index5 - 1]), new Pnt6D(camPoint2.Points[index5]), dt, ref CalculatedPoints);
              CalculatedPoints.RemoveAt(0);
              camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
            }
            else
              camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index5]));
          }
          calcCam.CamPoints.Add(camPoint2);
          // ISSUE: reference to a compiler-generated field
          if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null && int32 > 0 & num2 > 0 && num2 % int32 == 0)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double) index3 / (double) (ContinousPoints.Count - 1)) * 100.0, Convert.ToDouble((double) index3 / (double) (ContinousPoints.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
          }
          if (buSystem.DoEventEnable & int32 > 0 & num2 > 0 && num2 % int32 == 0)
            Application.DoEvents();
          if (!buSystem.Cancel)
          {
            ++num2;
          }
          else
          {
            buSystem.Cancel = false;
            buSystem.Canceled = true;
            // ISSUE: reference to a compiler-generated field
            if (this.calculationEventHandler_2 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.calculationEventHandler_2(new CalculationEventArg());
            }
            // ISSUE: reference to a compiler-generated field
            if (this.calculationEventHandler_3 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
            }
            buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
            return;
          }
        }
      }
      if (Operation.ApplySurfaceReadData & Operation.SurfaceReadDevideLength > 0.0 & buCamCalc.pntTeachGrids.Count > 0)
      {
        for (int index6 = 0; index6 <= ContinousPoints.Count - 1; ++index6)
        {
          List<eEntities> eEntitiesList = new List<eEntities>();
          List<Pnt3D> pnt3DList = new List<Pnt3D>();
          for (int index7 = 0; index7 <= ContinousPoints[index6].Count - 1; ++index7)
          {
            double num4 = 0.0;
            int index8 = Convert.ToInt32(ContinousPoints[index6][index7].X);
            int index9 = Convert.ToInt32(ContinousPoints[index6][index7].Y);
            if (index8 < 0)
              index8 = 0;
            if (index9 < 0)
              index9 = 0;
            if (index9 >= 0 & index9 <= buCamCalc.pntTeachGrids.Count - 1 && index8 >= 0 & index8 <= buCamCalc.pntTeachGrids[index9].Count - 1)
              num4 = buCamCalc.pntTeachGrids[index9][index8].Z;
            ContinousPoints[index6][index7] = new Pnt6D(ContinousPoints[index6][index7].X, ContinousPoints[index6][index7].Y, ContinousPoints[index6][index7].Z + num4, ContinousPoints[index6][index7].A, 0.0, ContinousPoints[index6][index7].C);
          }
        }
      }
      if (Operation.WaterJet5AxisConcaveCalculation)
        this.CalcMarbleWaterjet5AxisConcaveCalculation(Kinematic, Tool, CamMarblePars, camPar, Operation, AValue, CValue, WaterJetAirUpCmd, WaterJetDownOperationCmd, WaterJetOnCmd, WaterJetOffCmd, WaterJetNextOn, WaterJetNextOff, WaterJetApproach, Resolution, ref calcCam, ref ContinousPoints);
      eEntities.CopyEntities(Entities, ref calcCam.CalculatedEntities);
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CalcMarbleEntitiesToContinousPoint(
    List<List<eEntities>> Entities,
    EntitiesResolution Resolution,
    marbleCamParameters CamMarblePars,
    camParameters camPar,
    marbleOperation Operation,
    ref List<List<Pnt6D>> ContinousPoints)
  {
    double num1 = camPar.Strategy.AngleLimit;
    List<List<eEntities>> eEntitiesListList = new List<List<eEntities>>();
    for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
    {
      List<eEntities> eEntitiesList1 = new List<eEntities>();
      for (int index2 = 0; index2 <= Entities[index1].Count - 1; ++index2)
      {
        if (Entities[index1][index2].GetType() == typeof (eCircle))
        {
          if (camPar.Operations.Direction == ClockDirectionType.CCW)
          {
            eArc eArc1 = new eArc(((ePlaneEntities) Entities[index1][index2]).CenterPoint, ((eCircle) Entities[index1][index2]).Radius, 0.0, 180.0, ((ePlaneEntities) Entities[index1][index2]).Plane);
            eArc1.Orientation = new OrientationAngle(Entities[index1][index2].Orientation);
            eEntitiesList1.Add((eEntities) eArc1);
            eEntitiesListList.Add(eEntitiesList1);
            List<eEntities> eEntitiesList2 = new List<eEntities>();
            eArc eArc2 = new eArc(((ePlaneEntities) Entities[index1][index2]).CenterPoint, ((eCircle) Entities[index1][index2]).Radius, 180.0, 360.0, ((ePlaneEntities) Entities[index1][index2]).Plane);
            eArc2.Orientation = new OrientationAngle(Entities[index1][index2].Orientation);
            eEntitiesList2.Add((eEntities) eArc2);
            eEntitiesListList.Add(eEntitiesList2);
          }
          else
          {
            eArc eArc3 = new eArc(((ePlaneEntities) Entities[index1][index2]).CenterPoint, ((eCircle) Entities[index1][index2]).Radius, 180.0, 360.0, ((ePlaneEntities) Entities[index1][index2]).Plane);
            eArc3.Orientation = new OrientationAngle(Entities[index1][index2].Orientation);
            eArc3.camDirections = camPathDirectionType.Reverse;
            eEntitiesList1.Add((eEntities) eArc3);
            eEntitiesListList.Add(eEntitiesList1);
            List<eEntities> eEntitiesList3 = new List<eEntities>();
            eArc eArc4 = new eArc(((ePlaneEntities) Entities[index1][index2]).CenterPoint, ((eCircle) Entities[index1][index2]).Radius, 0.0, 180.0, ((ePlaneEntities) Entities[index1][index2]).Plane);
            eArc4.Orientation = new OrientationAngle(Entities[index1][index2].Orientation);
            if (camPar.Operations.Direction == ClockDirectionType.CW)
              eArc4.camDirections = camPathDirectionType.Reverse;
            eEntitiesList3.Add((eEntities) eArc4);
            eEntitiesListList.Add(eEntitiesList3);
          }
          eEntitiesList1 = new List<eEntities>();
        }
        else if (Entities[index1][index2].GetType() == typeof (eArc))
        {
          if (eEntitiesList1.Count > 0)
            eEntitiesListList.Add(eEntitiesList1);
          List<eEntities> eEntitiesList4 = new List<eEntities>();
          eEntities copiedEnt = new eEntities();
          eEntities.CopyEntity(Entities[index1][index2], ref copiedEnt);
          eEntitiesList4.Add(copiedEnt);
          eEntitiesListList.Add(eEntitiesList4);
          eEntitiesList1 = new List<eEntities>();
        }
        else
        {
          eEntities copiedEnt = new eEntities();
          eEntities.CopyEntity(Entities[index1][index2], ref copiedEnt);
          eEntitiesList1.Add(copiedEnt);
        }
      }
      if (eEntitiesList1.Count > 0)
        eEntitiesListList.Add(eEntitiesList1);
    }
    for (int index3 = 0; index3 <= eEntitiesListList.Count - 1; ++index3)
    {
      List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
      if (eEntitiesListList[index3].Count >= 1)
      {
        List<Pnt6D> Points = new List<Pnt6D>();
        List<Pnt6D> pnt6DList2 = new List<Pnt6D>();
        buAppCalc.cVector.EntitiesToPoint(eEntitiesListList[index3], Resolution, ref Points);
        Pnt6D pnt6D1 = new Pnt6D(Points[0]);
        Pnt6D pnt6D2 = new Pnt6D(Points[Points.Count - 1]);
        buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points, Operation.PointFilterLength);
        if (!buCompare.EQ(Points[0], pnt6D1, 0.01))
          Points.Insert(0, pnt6D1);
        if (!buCompare.EQ(Points[Points.Count - 1], pnt6D2, 0.01))
          Points.Add(pnt6D2);
        if (Points.Count > 1)
        {
          double num2 = 0.0;
          double c1 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[1]), new Pnt3D(Points[0]));
          if (buCompare.EQ(c1, 360.0))
            c1 = 0.0;
          if (CamMarblePars.UseCZero)
            c1 = 0.0;
          if (eEntitiesListList[index3].Count == 1 & Points[0].C != 0.0)
            c1 = Points[0].C;
          double num3 = c1;
          pnt6DList1.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, c1));
          for (int index4 = 1; index4 <= Points.Count - 2; ++index4)
          {
            bool flag = false;
            double c2 = buCompare.EQ(new Pnt3D(Points[index4]), new Pnt3D(Points[index4 - 1]), 0.01) ? num3 : buAppCalc.cVector.PointAngle(new Pnt3D(Points[index4]), new Pnt3D(Points[index4 - 1]));
            buAppCalc.cVector.Length3D(new Pnt3D(Points[index4]), new Pnt3D(Points[index4 - 1]));
            if (CamMarblePars.UseCZero)
              c2 = 0.0;
            double c3;
            double num4;
            if (camPar.Strategy.UseTangentLimit)
            {
              num2 = Points[index4 - 1].A - Points[index4].A;
              if (Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C) > 185.0)
              {
                if (pnt6DList1[pnt6DList1.Count - 1].C > c2)
                  c2 += 360.0;
                else
                  c2 -= 360.0;
              }
              c3 = buCompare.EQ(new Pnt3D(Points[index4 + 1]), new Pnt3D(Points[index4]), 0.01) ? c2 : buAppCalc.cVector.PointAngle(new Pnt3D(Points[index4 + 1]), new Pnt3D(Points[index4]));
              if (CamMarblePars.UseCZero)
                c3 = 0.0;
              num1 = camPar.Strategy.AngleLimit;
              double num5 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index4]), new Pnt3D(Points[index4]), new Pnt3D(Points[index4 + 1]), new WorkPlane());
              if (eEntitiesListList[index3][0].OperationPlane == planeType.YZ)
              {
                if (camPar.Strategy.UseLimitAngleForOtherPlane)
                  num1 = camPar.Strategy.AngleLimitYZ;
                num5 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index4]), new Pnt3D(Points[index4]), new Pnt3D(Points[index4 + 1]), new WorkPlane(planeType.YZ, 1));
              }
              num4 = 180.0 - num5;
              if (num4 >= 360.0 - num1)
                num4 = 360.0 - num5;
              Math.Abs(c2 - num3);
              if (Math.Abs(num2) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
              {
                ContinousPoints.Add(pnt6DList1);
                pnt6DList1 = new List<Pnt6D>();
                pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4].A, 0.0, c3));
                flag = true;
              }
            }
            else
            {
              num1 = camPar.Strategy.AngleLimit;
              double num6 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index4]), new Pnt3D(Points[index4]), new Pnt3D(Points[index4 + 1]), new WorkPlane());
              num4 = 180.0 - num6;
              if (num4 >= 360.0 - num1)
                num4 = 360.0 - num6;
              c3 = buCompare.EQ(new Pnt3D(Points[index4 + 1]), new Pnt3D(Points[index4]), 0.01) ? c2 : buAppCalc.cVector.PointAngle(new Pnt3D(Points[index4 + 1]), new Pnt3D(Points[index4]));
              if (CamMarblePars.UseCZero)
                c3 = 0.0;
              if (num4 > num1)
              {
                pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4].A, 0.0, c2));
                pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4 + 1].A, 0.0, c3));
                flag = true;
              }
              Math.Abs(c2 - num3);
              if (Math.Abs(num2) > buSystem.resolutionCompare && pnt6DList1.Count > 1)
              {
                ContinousPoints.Add(pnt6DList1);
                pnt6DList1 = new List<Pnt6D>();
                pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4].A, 0.0, c3));
                flag = true;
              }
            }
            if (!flag)
            {
              if (num4 > num1 & camPar.Strategy.UseTangentLimit)
              {
                pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4].A, 0.0, c2));
                ContinousPoints.Add(pnt6DList1);
                pnt6DList1 = new List<Pnt6D>();
                pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4 + 1].A, 0.0, c3));
              }
              else
              {
                if (camPar.Strategy.UseTangentLimit)
                {
                  double num7 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                  if (num7 >= 360.0 - num1)
                  {
                    if (c2 > pnt6DList1[pnt6DList1.Count - 1].C)
                      c2 -= 360.0;
                    else
                      c2 += 360.0;
                    num7 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                  }
                  if (num7 > 185.0)
                    c2 += 360.0;
                }
                pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4].A, 0.0, c2));
                if (Math.Abs(c2 - c3) > 180.1)
                {
                  double num8 = c2 - c3;
                  if (c2 > c3)
                  {
                    double lower = buNumeric.RoundToLower(Math.Abs(num8) / 360.0);
                    c3 += 360.0 + lower * 360.0;
                  }
                  else
                  {
                    double lower = buNumeric.RoundToLower(Math.Abs(num8) / 360.0);
                    c3 -= 360.0 + lower * 360.0;
                  }
                }
                if (camPar.Options.AxesLimit.MinLimit != camPar.Options.AxesLimit.MaxLimit)
                {
                  if (c3 > camPar.Options.AxesLimit.MaxLimit.C)
                  {
                    ContinousPoints.Add(pnt6DList1);
                    c2 -= 360.0;
                    pnt6DList1 = new List<Pnt6D>();
                    pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4].A, 0.0, c2));
                  }
                  if (c3 < camPar.Options.AxesLimit.MinLimit.C)
                  {
                    ContinousPoints.Add(pnt6DList1);
                    c2 += 360.0;
                    pnt6DList1 = new List<Pnt6D>();
                    pnt6DList1.Add(new Pnt6D(Points[index4].X, Points[index4].Y, Points[index4].Z, Points[index4].A, 0.0, c2));
                  }
                }
              }
            }
            num3 = c2;
          }
          if (pnt6DList1.Count > 0)
          {
            double c4 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[Points.Count - 1]), new Pnt3D(Points[Points.Count - 2]));
            if (CamMarblePars.UseCZero)
              c4 = 0.0;
            if (eEntitiesListList[index3].Count == 1 & Points[Points.Count - 1].C != 0.0)
              c4 = Points[Points.Count - 1].C;
            double num9 = Math.Abs(c4 - pnt6DList1[pnt6DList1.Count - 1].C);
            if (num9 >= 360.0 - num1)
            {
              num9 = 360.0 - c4;
              if (c4 > pnt6DList1[pnt6DList1.Count - 1].C)
                c4 -= 360.0;
            }
            if (num9 > 185.0)
              c4 += 360.0;
            pnt6DList1.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, c4));
            ContinousPoints.Add(pnt6DList1);
          }
        }
      }
    }
  }

  public void CalcMarbleWaterjet5AxisConcaveCalculation(
    KinematicBase Kinematic,
    ToolBase Tool,
    marbleCamParameters CamMarblePars,
    camParameters camPar,
    marbleOperation Operation,
    double AValue,
    double CValue,
    string WaterJetAirUpCmd,
    string WaterJetDownOperationCmd,
    string WaterJetOnCmd,
    string WaterJetOffCmd,
    string WaterJetNextOn,
    string WaterJetNextOff,
    string WaterJetApproach,
    EntitiesResolution Resolution,
    ref camBase calcCam,
    ref List<List<Pnt6D>> ContinousPoints)
  {
    int int32 = Convert.ToInt32((double) ContinousPoints.Count / 100.0);
    int num1 = 0;
    Pnt6D pnt6D1 = new Pnt6D();
    Pnt6D pnt6D2 = new Pnt6D();
    double num2 = 0.0;
    OrientationAngle orientationAngle1 = new OrientationAngle();
    ClockDirectionType clockDirectionType = camPar.Operations.Direction;
    CamPoint camPoint1 = new CamPoint();
    Pnt3D BasePoint = new Pnt3D();
    Pnt6D pnt6D3 = new Pnt6D();
    bool flag1 = false;
    for (int index1 = 0; index1 <= ContinousPoints.Count - 1; ++index1)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      double num3 = 0.0;
      if (index1 < ContinousPoints.Count - 1)
      {
        for (int index2 = 0; index2 <= ContinousPoints[index1].Count - 1; ++index2)
          pnt3DList.Add(new Pnt3D(ContinousPoints[index1][index2]));
        pnt3DList.Add(new Pnt3D(ContinousPoints[index1 + 1][1]));
        if (pnt3DList.Count == 3)
          num3 = buAppCalc.cVector.CrossProductLength(pnt3DList[0], pnt3DList[1], pnt3DList[pnt3DList.Count - 1]);
        if (pnt3DList.Count > 3)
          num3 = buAppCalc.cVector.CrossProductLength(pnt3DList[0], pnt3DList[1], pnt3DList[2]);
        if (!buAppCalc.cVector.IsClosed(pnt3DList))
          clockDirectionType = buAppCalc.cVector.PolygonDirection(pnt3DList);
        if (clockDirectionType == ClockDirectionType.CCW && num3 < 0.0 & camPar.Offsets.OpenContourOld == CamOpenContourType2.Left)
          flag1 = true;
        if (clockDirectionType == ClockDirectionType.CW && num3 > 0.0 & camPar.Offsets.OpenContourOld == CamOpenContourType2.Right)
          flag1 = true;
      }
      for (int index3 = 0; index3 <= ContinousPoints[index1].Count - 1; ++index3)
      {
        if (index1 > 0)
        {
          double c = ContinousPoints[index1][index3].C;
          if (clockDirectionType == ClockDirectionType.CCW)
          {
            if (c < num2 & num2 - c > 180.0 & !flag1)
              ContinousPoints[index1][index3] = new Pnt6D(ContinousPoints[index1][index3].X, ContinousPoints[index1][index3].Y, ContinousPoints[index1][index3].Z, ContinousPoints[index1][index3].A, ContinousPoints[index1][index3].B, ContinousPoints[index1][index3].C + 360.0);
            if (c > num2 & c - num2 > 180.0 & flag1)
              ContinousPoints[index1][index3] = new Pnt6D(ContinousPoints[index1][index3].X, ContinousPoints[index1][index3].Y, ContinousPoints[index1][index3].Z, ContinousPoints[index1][index3].A, ContinousPoints[index1][index3].B, ContinousPoints[index1][index3].C - 360.0);
            if (num2 > c & num2 - c > 180.0 & flag1)
              ContinousPoints[index1][index3] = new Pnt6D(ContinousPoints[index1][index3].X, ContinousPoints[index1][index3].Y, ContinousPoints[index1][index3].Z, ContinousPoints[index1][index3].A, ContinousPoints[index1][index3].B, ContinousPoints[index1][index3].C + 360.0);
          }
          if (clockDirectionType == ClockDirectionType.CW)
          {
            if (c > num2 & c - num2 > 180.0 & !flag1)
              ContinousPoints[index1][index3] = new Pnt6D(ContinousPoints[index1][index3].X, ContinousPoints[index1][index3].Y, ContinousPoints[index1][index3].Z, ContinousPoints[index1][index3].A, ContinousPoints[index1][index3].B, ContinousPoints[index1][index3].C - 360.0);
            if (c > num2 & c - num2 > 180.0 & flag1)
              ContinousPoints[index1][index3] = new Pnt6D(ContinousPoints[index1][index3].X, ContinousPoints[index1][index3].Y, ContinousPoints[index1][index3].Z, ContinousPoints[index1][index3].A, ContinousPoints[index1][index3].B, ContinousPoints[index1][index3].C - 360.0);
            if (num2 > c & num2 - c > 180.0 & flag1)
              ContinousPoints[index1][index3] = new Pnt6D(ContinousPoints[index1][index3].X, ContinousPoints[index1][index3].Y, ContinousPoints[index1][index3].Z, ContinousPoints[index1][index3].A, ContinousPoints[index1][index3].B, ContinousPoints[index1][index3].C + 360.0);
          }
        }
        num2 = ContinousPoints[index1][index3].C;
      }
    }
    List<List<Pnt6D>> pnt6DListList = new List<List<Pnt6D>>();
    for (int index4 = 0; index4 <= ContinousPoints.Count - 1; ++index4)
    {
      List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
      if (index4 == 0)
      {
        if (camPar.Operations.Direction == ClockDirectionType.CW)
        {
          if (Operation.WaterJetLeadInLength > 0.0)
          {
            Pnt3D CenterPnt = new Pnt3D(ContinousPoints[index4][0]);
            Pnt3D EndPnt = new Pnt3D();
            buAppCalc.cVector.LineWithLengthAndAngle(CenterPnt, Operation.WaterJetLeadInLength, ContinousPoints[index4][0].C - Operation.WaterJetLeadInInsideAngle, new WorkPlane(), ref EndPnt);
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(EndPnt.X, EndPnt.Y, 0.0, ContinousPoints[index4][0].A, 0.0, ContinousPoints[index4][0].C - Operation.WaterJetLeadInInsideAngle + 180.0),
              new Pnt6D(ContinousPoints[index4][0].X, ContinousPoints[index4][0].Y, ContinousPoints[index4][0].Z, ContinousPoints[index4][0].A, 0.0, ContinousPoints[index4][0].C - Operation.WaterJetLeadInInsideAngle + 180.0)
            });
          }
          Pnt6D MiddlePoint = new Pnt6D();
          List<Pnt6D> pnt6DList2 = new List<Pnt6D>();
          if (ContinousPoints[index4].Count == 2)
          {
            buAppCalc.cVector.MiddlePointOfLine(ContinousPoints[index4][0], ContinousPoints[index4][1], ref MiddlePoint);
            pnt6DList2.Add(new Pnt6D(ContinousPoints[index4][0]));
            pnt6DList2.Add(new Pnt6D(MiddlePoint));
            pnt6DListList.Add(pnt6DList2);
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(MiddlePoint),
              new Pnt6D(ContinousPoints[index4][1])
            });
          }
          else
          {
            List<Pnt6D> CopiedPnt = new List<Pnt6D>();
            Pnt6D.Copy(ContinousPoints[index4], ref CopiedPnt);
            pnt6DListList.Add(CopiedPnt);
          }
        }
        if (camPar.Operations.Direction == ClockDirectionType.CCW)
        {
          List<Pnt6D> pnt6DList3 = new List<Pnt6D>();
          if (Operation.WaterJetLeadInLength > 0.0)
          {
            if (Operation.WaterJetLeadInOutsideAngle == 180.0)
            {
              Pnt3D CenterPnt = new Pnt3D(ContinousPoints[index4][0]);
              Pnt3D EndPnt = new Pnt3D();
              buAppCalc.cVector.LineWithLengthAndAngle(CenterPnt, Operation.WaterJetLeadInLength, ContinousPoints[index4][0].C + Operation.WaterJetLeadInOutsideAngle, new WorkPlane(), ref EndPnt);
              ContinousPoints[index4][0] = new Pnt6D(EndPnt.X, EndPnt.Y, ContinousPoints[index4][0].Z, ContinousPoints[index4][0].A, ContinousPoints[index4][0].B, ContinousPoints[index4][0].C);
            }
            else
            {
              Pnt3D CenterPnt = new Pnt3D(ContinousPoints[index4][0]);
              Pnt3D EndPnt = new Pnt3D();
              buAppCalc.cVector.LineWithLengthAndAngle(CenterPnt, Operation.WaterJetLeadInLength, ContinousPoints[index4][0].C - Operation.WaterJetLeadInOutsideAngle, new WorkPlane(), ref EndPnt);
              Pnt6D Pnt = new Pnt6D(ContinousPoints[index4][0]);
              Pnt.X = EndPnt.X;
              Pnt.Y = EndPnt.Y;
              Pnt.C = ContinousPoints[index4][0].C - Operation.WaterJetLeadInOutsideAngle + 180.0;
              pnt6DListList.Add(new List<Pnt6D>()
              {
                new Pnt6D(Pnt),
                new Pnt6D(ContinousPoints[index4][0].X, ContinousPoints[index4][0].Y, ContinousPoints[index4][0].Z, ContinousPoints[index4][0].A, ContinousPoints[index4][0].B, Pnt.C)
              });
            }
          }
          List<Pnt6D> CopiedPnt = new List<Pnt6D>();
          Pnt6D.Copy(ContinousPoints[index4], ref CopiedPnt);
          pnt6DListList.Add(CopiedPnt);
        }
      }
      if (index4 == ContinousPoints.Count - 1)
      {
        if (camPar.Operations.Direction == ClockDirectionType.CW)
        {
          pnt6DList1 = new List<Pnt6D>();
          Pnt6D MiddlePoint = new Pnt6D();
          if (ContinousPoints[index4].Count == 2)
          {
            buAppCalc.cVector.MiddlePointOfLine(ContinousPoints[index4][ContinousPoints[index4].Count - 2], ContinousPoints[index4][ContinousPoints[index4].Count - 1], ref MiddlePoint);
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(ContinousPoints[index4][ContinousPoints[index4].Count - 2]),
              new Pnt6D(MiddlePoint)
            });
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(MiddlePoint),
              new Pnt6D(ContinousPoints[index4][ContinousPoints[index4].Count - 1])
            });
          }
          else if (ContinousPoints.Count > 1)
          {
            List<Pnt6D> CopiedPnt = new List<Pnt6D>();
            Pnt6D.Copy(ContinousPoints[index4], ref CopiedPnt);
            pnt6DListList.Add(CopiedPnt);
          }
          if (Operation.WaterJetLeadOutLength > 0.0)
          {
            Pnt3D CenterPnt = new Pnt3D(ContinousPoints[index4][ContinousPoints[index4].Count - 1]);
            Pnt3D EndPnt = new Pnt3D();
            buAppCalc.cVector.LineWithLengthAndAngle(CenterPnt, Operation.WaterJetLeadOutLength, ContinousPoints[index4][ContinousPoints[index4].Count - 1].C + Operation.WaterJetLeadOutInsideAngle - 180.0, new WorkPlane(), ref EndPnt);
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(ContinousPoints[index4][ContinousPoints[index4].Count - 1].X, ContinousPoints[index4][ContinousPoints[index4].Count - 1].Y, ContinousPoints[index4][ContinousPoints[index4].Count - 1].Z, ContinousPoints[index4][ContinousPoints[index4].Count - 1].A, 0.0, ContinousPoints[index4][ContinousPoints[index4].Count - 1].C + Operation.WaterJetLeadOutInsideAngle - 180.0),
              new Pnt6D(EndPnt.X, EndPnt.Y, 0.0, ContinousPoints[index4][0].A, 0.0, ContinousPoints[index4][0].C + Operation.WaterJetLeadOutInsideAngle - 180.0)
            });
          }
        }
        if (camPar.Operations.Direction == ClockDirectionType.CCW)
        {
          List<Pnt6D> CopiedPnt = new List<Pnt6D>();
          if (ContinousPoints.Count > 1)
          {
            Pnt6D.Copy(ContinousPoints[index4], ref CopiedPnt);
            pnt6DListList.Add(CopiedPnt);
          }
          if (Operation.WaterJetLeadOutLength > 0.0)
          {
            if (Operation.WaterJetLeadInOutsideAngle == 180.0)
            {
              Pnt3D CenterPnt = new Pnt3D(ContinousPoints[index4][ContinousPoints[index4].Count - 1]);
              Pnt3D EndPnt = new Pnt3D();
              buAppCalc.cVector.LineWithLengthAndAngle(CenterPnt, Operation.WaterJetLeadOutLength, ContinousPoints[index4][ContinousPoints[index4].Count - 1].C + 180.0 - Operation.WaterJetLeadOutOutsideAngle, new WorkPlane(), ref EndPnt);
              pnt6DListList[pnt6DListList.Count - 1][pnt6DListList[pnt6DListList.Count - 1].Count - 1] = new Pnt6D(new Pnt6D(pnt6DListList[pnt6DListList.Count - 1][pnt6DListList[pnt6DListList.Count - 1].Count - 1])
              {
                X = EndPnt.X,
                Y = EndPnt.Y
              });
            }
            else
            {
              Pnt3D CenterPnt = new Pnt3D(ContinousPoints[index4][ContinousPoints[index4].Count - 1]);
              Pnt3D EndPnt = new Pnt3D();
              buAppCalc.cVector.LineWithLengthAndAngle(CenterPnt, Operation.WaterJetLeadOutLength, ContinousPoints[index4][ContinousPoints[index4].Count - 1].C - (180.0 - Operation.WaterJetLeadOutOutsideAngle), new WorkPlane(), ref EndPnt);
              Pnt6D Pnt = new Pnt6D(pnt6DListList[pnt6DListList.Count - 1][pnt6DListList[pnt6DListList.Count - 1].Count - 1]);
              Pnt6D pnt6D4 = new Pnt6D(pnt6DListList[pnt6DListList.Count - 1][pnt6DListList[pnt6DListList.Count - 1].Count - 1]);
              Pnt.X = EndPnt.X;
              Pnt.Y = EndPnt.Y;
              Pnt.C = pnt6D4.C + Operation.WaterJetLeadOutOutsideAngle - 180.0;
              pnt6DListList.Add(new List<Pnt6D>()
              {
                new Pnt6D(ContinousPoints[index4][ContinousPoints[index4].Count - 1].X, ContinousPoints[index4][ContinousPoints[index4].Count - 1].Y, ContinousPoints[index4][ContinousPoints[index4].Count - 1].Z, ContinousPoints[index4][ContinousPoints[index4].Count - 1].A, ContinousPoints[index4][ContinousPoints[index4].Count - 1].B, Pnt.C),
                new Pnt6D(Pnt)
              });
            }
          }
        }
      }
      if (index4 > 0 & index4 < ContinousPoints.Count - 1 && index4 <= ContinousPoints.Count - 2)
      {
        List<Pnt3D> pnt3DList1 = new List<Pnt3D>();
        List<Pnt3D> pnt3DList2 = new List<Pnt3D>();
        for (int index5 = 0; index5 <= ContinousPoints[index4 - 1].Count - 1; ++index5)
          pnt3DList1.Add(new Pnt3D(ContinousPoints[index4 - 1][index5]));
        pnt3DList1.Add(new Pnt3D(ContinousPoints[index4][1]));
        if (pnt3DList1.Count == 3)
          buAppCalc.cVector.CrossProductLength(pnt3DList1[0], pnt3DList1[1], pnt3DList1[pnt3DList1.Count - 1]);
        if (pnt3DList1.Count > 3)
          buAppCalc.cVector.CrossProductLength(pnt3DList1[0], pnt3DList1[1], pnt3DList1[2]);
        for (int index6 = 0; index6 <= ContinousPoints[index4].Count - 1; ++index6)
          pnt3DList2.Add(new Pnt3D(ContinousPoints[index4][index6]));
        pnt3DList2.Add(new Pnt3D(ContinousPoints[index4 + 1][1]));
        if (pnt3DList2.Count == 3)
          buAppCalc.cVector.CrossProductLength(pnt3DList2[0], pnt3DList2[1], pnt3DList2[pnt3DList2.Count - 1]);
        if (pnt3DList2.Count > 3)
          buAppCalc.cVector.CrossProductLength(pnt3DList2[0], pnt3DList2[1], pnt3DList2[2]);
        if (camPar.Operations.Direction == ClockDirectionType.CW)
        {
          if (ContinousPoints[index4].Count == 2)
          {
            Pnt6D MiddlePoint = new Pnt6D();
            buAppCalc.cVector.MiddlePointOfLine(ContinousPoints[index4][0], ContinousPoints[index4][1], ref MiddlePoint);
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(ContinousPoints[index4][0]),
              new Pnt6D(MiddlePoint)
            });
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(MiddlePoint),
              new Pnt6D(ContinousPoints[index4][1])
            });
          }
          else
          {
            List<Pnt6D> CopiedPnt = new List<Pnt6D>();
            Pnt6D.Copy(ContinousPoints[index4], ref CopiedPnt);
            pnt6DListList.Add(CopiedPnt);
          }
        }
        if (camPar.Operations.Direction == ClockDirectionType.CCW)
        {
          if (ContinousPoints[index4].Count == 2)
          {
            Pnt6D MiddlePoint = new Pnt6D();
            buAppCalc.cVector.MiddlePointOfLine(ContinousPoints[index4][0], ContinousPoints[index4][1], ref MiddlePoint);
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(ContinousPoints[index4][0]),
              new Pnt6D(MiddlePoint)
            });
            pnt6DListList.Add(new List<Pnt6D>()
            {
              new Pnt6D(MiddlePoint),
              new Pnt6D(ContinousPoints[index4][1])
            });
          }
          else
          {
            List<Pnt6D> CopiedPnt = new List<Pnt6D>();
            Pnt6D.Copy(ContinousPoints[index4], ref CopiedPnt);
            pnt6DListList.Add(CopiedPnt);
          }
        }
      }
    }
    ContinousPoints.Clear();
    ContinousPoints = new List<List<Pnt6D>>();
    for (int index = 0; index <= pnt6DListList.Count - 1; ++index)
    {
      List<Pnt6D> CopiedPnt = new List<Pnt6D>();
      Pnt6D.Copy(pnt6DListList[index], ref CopiedPnt);
      ContinousPoints.Add(CopiedPnt);
    }
    double num4 = 0.0;
    bool flag2 = false;
    List<List<Pnt6D>> CopiedPnt1 = new List<List<Pnt6D>>();
    Pnt6D.Copy(ContinousPoints, ref CopiedPnt1);
    for (int index7 = 0; index7 <= ContinousPoints.Count - 1; ++index7)
    {
      List<Pnt3D> pnt3DList3 = new List<Pnt3D>();
      List<Pnt3D> pnt3DList4 = new List<Pnt3D>();
      double num5 = 0.0;
      double AngleDiff = 0.0;
      double num6 = 0.0;
      double num7 = 0.0;
      int index8 = 0;
      int index9 = ContinousPoints[index7].Count - 1;
      if (index7 < ContinousPoints.Count - 1)
        index8 = ContinousPoints[index7 + 1].Count - 1;
      if (index7 < ContinousPoints.Count - 1)
      {
        for (int index10 = 0; index10 <= ContinousPoints[index7].Count - 1; ++index10)
          pnt3DList3.Add(new Pnt3D(ContinousPoints[index7][index10]));
        pnt3DList3.Add(new Pnt3D(ContinousPoints[index7 + 1][1]));
        if (pnt3DList3.Count == 3)
          num6 = buAppCalc.cVector.CrossProductLength(pnt3DList3[0], pnt3DList3[1], pnt3DList3[pnt3DList3.Count - 1]);
        if (pnt3DList3.Count > 3)
          num6 = buAppCalc.cVector.CrossProductLength(pnt3DList3[pnt3DList3.Count - 3], pnt3DList3[pnt3DList3.Count - 2], pnt3DList3[pnt3DList3.Count - 1]);
        if (index7 < ContinousPoints.Count - 2)
        {
          for (int index11 = 0; index11 <= ContinousPoints[index7 + 1].Count - 1; ++index11)
            pnt3DList4.Add(new Pnt3D(ContinousPoints[index7 + 1][index11]));
          pnt3DList4.Add(new Pnt3D(ContinousPoints[index7 + 2][1]));
          if (pnt3DList4.Count == 3)
            num7 = buAppCalc.cVector.CrossProductLength(pnt3DList4[0], pnt3DList4[1], pnt3DList4[pnt3DList4.Count - 1]);
          if (pnt3DList4.Count > 3)
            num7 = buAppCalc.cVector.CrossProductLength(pnt3DList4[0], pnt3DList4[1], pnt3DList4[2]);
        }
        double RatioAFromC1 = 1.0;
        double RatioAFromA1 = 1.0;
        double X3_1 = 1.0;
        double RatioAFromC2 = 1.0;
        double RatioAFromA2 = 1.0;
        double X3_2 = 1.0;
        if (index7 < ContinousPoints.Count - 2)
        {
          if (ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A > 0.0 & ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A <= 1.0)
            buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA0, Operation.WaterJet5AxisCRtForA1, 0.0, 1.0, ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A, ref X3_2);
          if (ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A > 1.0 & ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A <= 10.0)
            buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA1, Operation.WaterJet5AxisCRtForA10, 1.0, 10.0, ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A, ref X3_2);
          if (ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A > 10.0 & ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A <= 20.0)
            buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA10, Operation.WaterJet5AxisCRtForA20, 10.0, 20.0, ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A, ref X3_2);
          if (ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A > 20.0 & ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A <= 30.0)
            buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA20, Operation.WaterJet5AxisCRtForA30, 20.0, 30.0, ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A, ref X3_2);
          if (ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A > 30.0 & ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A <= 40.0)
            buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA30, Operation.WaterJet5AxisCRtForA40, 30.0, 40.0, ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A, ref X3_2);
          if (ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A > 40.0 & ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A <= 45.0)
            buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA40, Operation.WaterJet5AxisCRtForA45, 40.0, 45.0, ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A, ref X3_2);
          if (ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A > 45.0 & ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A <= 50.0)
            buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA45, Operation.WaterJet5AxisCRtForA50, 45.0, 50.0, ContinousPoints[index7 + 1][ContinousPoints[index7 + 1].Count - 1].A, ref X3_2);
        }
        if (ContinousPoints[index7][ContinousPoints[index7].Count - 1].A > 0.0 & ContinousPoints[index7][ContinousPoints[index7].Count - 1].A <= 1.0)
          buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA0, Operation.WaterJet5AxisCRtForA1, 0.0, 1.0, ContinousPoints[index7][ContinousPoints[index7].Count - 1].A, ref X3_1);
        if (ContinousPoints[index7][ContinousPoints[index7].Count - 1].A > 1.0 & ContinousPoints[index7][ContinousPoints[index7].Count - 1].A <= 10.0)
          buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA1, Operation.WaterJet5AxisCRtForA10, 1.0, 10.0, ContinousPoints[index7][ContinousPoints[index7].Count - 1].A, ref X3_1);
        if (ContinousPoints[index7][ContinousPoints[index7].Count - 1].A > 10.0 & ContinousPoints[index7][ContinousPoints[index7].Count - 1].A <= 20.0)
          buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA10, Operation.WaterJet5AxisCRtForA20, 10.0, 20.0, ContinousPoints[index7][ContinousPoints[index7].Count - 1].A, ref X3_1);
        if (ContinousPoints[index7][ContinousPoints[index7].Count - 1].A > 20.0 & ContinousPoints[index7][ContinousPoints[index7].Count - 1].A <= 30.0)
          buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA20, Operation.WaterJet5AxisCRtForA30, 20.0, 30.0, ContinousPoints[index7][ContinousPoints[index7].Count - 1].A, ref X3_1);
        if (ContinousPoints[index7][ContinousPoints[index7].Count - 1].A > 30.0 & ContinousPoints[index7][ContinousPoints[index7].Count - 1].A <= 40.0)
          buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA30, Operation.WaterJet5AxisCRtForA40, 30.0, 40.0, ContinousPoints[index7][ContinousPoints[index7].Count - 1].A, ref X3_1);
        if (ContinousPoints[index7][ContinousPoints[index7].Count - 1].A > 40.0 & ContinousPoints[index7][ContinousPoints[index7].Count - 1].A <= 45.0)
          buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA40, Operation.WaterJet5AxisCRtForA45, 40.0, 45.0, ContinousPoints[index7][ContinousPoints[index7].Count - 1].A, ref X3_1);
        if (ContinousPoints[index7][ContinousPoints[index7].Count - 1].A > 45.0 & ContinousPoints[index7][ContinousPoints[index7].Count - 1].A <= 50.0)
          buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA45, Operation.WaterJet5AxisCRtForA50, 45.0, 50.0, ContinousPoints[index7][ContinousPoints[index7].Count - 1].A, ref X3_1);
        if (camPar.Operations.Direction == ClockDirectionType.CCW)
        {
          Pnt6D pnt6D5 = new Pnt6D();
          double DeltaAngle1 = CopiedPnt1[index7 + 1][0].C - CopiedPnt1[index7][index9].C;
          if (DeltaAngle1 < -360.0)
            DeltaAngle1 += 360.0;
          if (DeltaAngle1 > 360.0)
            DeltaAngle1 -= 360.0;
          num5 = CopiedPnt1[index7][index9].A;
          this.calcARatio(DeltaAngle1, num5, Operation, ref RatioAFromC1, ref RatioAFromA1);
          double num8 = CopiedPnt1[index7][index9].A * RatioAFromC1 * RatioAFromA1;
          double num9 = CopiedPnt1[index7][index9].C - CopiedPnt1[index7][index9].A * X3_1 + Operation.WaterJet5AxisCOffsetStartEnd;
          double num10 = CopiedPnt1[index7 + 1][index8].C - CopiedPnt1[index7 + 1][index8].A * X3_1 + Operation.WaterJet5AxisCOffsetStartEnd;
          double num11 = CopiedPnt1[index7][index9].C + DeltaAngle1 / 2.0 - num8 * X3_1 + Operation.WaterJet5AxisCOffsetMiddle;
          if (index7 < CopiedPnt1.Count - 2)
          {
            double DeltaAngle2 = CopiedPnt1[index7 + 2][0].C - CopiedPnt1[index7 + 1][index8].C;
            num5 = CopiedPnt1[index7 + 1][index8].A;
            this.calcARatio(DeltaAngle2, num5, Operation, ref RatioAFromC2, ref RatioAFromA2);
            double num12 = CopiedPnt1[index7 + 1][index8].A * RatioAFromC2 * RatioAFromA2;
            double num13 = CopiedPnt1[index7 + 1][index8].C - CopiedPnt1[index7 + 1][index8].A * X3_1 + Operation.WaterJet5AxisCOffsetStartEnd;
            double num14 = CopiedPnt1[index7 + 2][CopiedPnt1[index7 + 2].Count - 1].C - CopiedPnt1[index7 + 2][CopiedPnt1[index7 + 2].Count - 1].A * X3_1 + Operation.WaterJet5AxisCOffsetStartEnd;
            double num15 = CopiedPnt1[index7][index9].C + DeltaAngle2 / 2.0 - num12 * X3_1 + Operation.WaterJet5AxisCOffsetMiddle;
          }
          if (num6 > 1E-05)
          {
            if (index7 == 0)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                C = num9
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num8,
                C = num11
              });
            }
            else
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              if (Math.Abs(ContinousPoints[index7][0].C - num11) > 360.0)
              {
                if (ContinousPoints[index7][0].C > num11)
                  num11 += 360.0;
                else
                  num11 -= 360.0;
              }
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num8,
                C = num11
              });
            }
            ContinousPoints[index7 + 1][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7 + 1][0])
            {
              A = num8,
              C = num11
            });
            if (Math.Abs(num11 - num10) > 360.0)
            {
              if (num11 > num10)
                num10 += 360.0;
              else
                num10 -= 360.0;
            }
            ContinousPoints[index7 + 1][index8] = new Pnt6D(new Pnt6D(ContinousPoints[index7 + 1][index8])
            {
              A = ContinousPoints[index7 + 1][index8].A,
              C = num10
            });
          }
          else if (num6 < -1E-07)
          {
            if (index7 == 0)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                C = num9
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num8,
                C = num11
              });
            }
            else
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num8,
                C = num11
              });
            }
            ContinousPoints[index7 + 1][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7 + 1][0])
            {
              A = num8,
              C = num11
            });
            ContinousPoints[index7 + 1][index8] = new Pnt6D(new Pnt6D(ContinousPoints[index7 + 1][index8])
            {
              A = ContinousPoints[index7 + 1][index8].A,
              C = num10
            });
          }
          else
          {
            if (num4 >= 0.0 & num7 >= 0.0 & index7 > 0)
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
            if (num4 >= 0.0 & num7 < 0.0 & index7 > 0 && index7 < ContinousPoints.Count - 2)
              ContinousPoints[index7][1] = new Pnt6D(new Pnt6D(ContinousPoints[index7][1])
              {
                A = ContinousPoints[index7][0].A,
                C = ContinousPoints[index7][0].C
              });
            if (num4 < 0.0 & num7 > 0.0 & index7 > 0)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              ContinousPoints[index7][1] = new Pnt6D(new Pnt6D(ContinousPoints[index7][1])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
            }
            if (num4 < 0.0 & num7 < 0.0 & index7 > 0)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num8,
                C = num9
              });
            }
          }
          if (index7 > 0)
          {
            double c1 = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C;
            double c2 = ContinousPoints[index7][0].C;
            if (num4 == 0.0 & !buCompare.EQ(c1, c2, 0.1) & Math.Abs(c1 - c2) < 90.0)
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                C = c1
              });
          }
        }
        if (camPar.Operations.Direction == ClockDirectionType.CW)
        {
          Pnt6D pnt6D6 = new Pnt6D();
          if (index7 < ContinousPoints.Count - 2)
          {
            double DeltaAngle = CopiedPnt1[index7 + 2][0].C - CopiedPnt1[index7 + 1][index8].C;
            double a = CopiedPnt1[index7 + 1][index8].A;
            this.calcARatio(DeltaAngle, a, Operation, ref RatioAFromC2, ref RatioAFromA2);
            double num16 = CopiedPnt1[index7 + 1][index8].A * RatioAFromC2 * RatioAFromA2;
            double num17 = CopiedPnt1[index7 + 1][index8].C - CopiedPnt1[index7 + 1][index8].A * X3_1 + Operation.WaterJet5AxisCOffsetStartEnd;
            double num18 = CopiedPnt1[index7 + 2][CopiedPnt1[index7 + 2].Count - 1].C - CopiedPnt1[index7 + 2][CopiedPnt1[index7 + 2].Count - 1].A * X3_1 + Operation.WaterJet5AxisCOffsetStartEnd;
            double num19 = CopiedPnt1[index7][index9].C + DeltaAngle / 2.0 - num16 * X3_1 + Operation.WaterJet5AxisCOffsetMiddle;
          }
          double DeltaAngle3 = CopiedPnt1[index7 + 1][0].C - CopiedPnt1[index7][index9].C;
          if (DeltaAngle3 < -360.0)
            DeltaAngle3 += 360.0;
          if (DeltaAngle3 > 360.0)
            DeltaAngle3 -= 360.0;
          num5 = CopiedPnt1[index7][index9].A;
          this.calcARatio(DeltaAngle3, num5, Operation, ref RatioAFromC1, ref RatioAFromA1);
          double num20 = CopiedPnt1[index7][index9].A * RatioAFromC1 * RatioAFromA1;
          double num21 = CopiedPnt1[index7][index9].C - CopiedPnt1[index7][index9].A * X3_1 + Operation.WaterJet5AxisCOffsetStartEnd;
          double num22 = CopiedPnt1[index7 + 1][index8].C - CopiedPnt1[index7 + 1][index8].A * X3_1 + Operation.WaterJet5AxisCOffsetStartEnd;
          double num23 = CopiedPnt1[index7][index9].C + DeltaAngle3 / 2.0 - num20 * X3_1 + Operation.WaterJet5AxisCOffsetMiddle;
          if (num6 > 1E-06)
          {
            pnt6D6 = new Pnt6D();
            if (index7 == 0)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                C = num21
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num20,
                C = num23
              });
            }
            else
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num20,
                C = num23
              });
            }
            ContinousPoints[index7 + 1][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7 + 1][0])
            {
              A = num20,
              C = num23
            });
            ContinousPoints[index7 + 1][index8] = new Pnt6D(new Pnt6D(ContinousPoints[index7 + 1][index8])
            {
              A = ContinousPoints[index7 + 1][index8].A,
              C = num22
            });
            flag2 = false;
          }
          else if (num6 < -1E-06)
          {
            if (num4 >= 0.0 & index7 > 0 & !flag2)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num20,
                C = num23
              });
            }
            if (num4 < 0.0 & index7 > 0 | flag2)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num20,
                C = num23
              });
            }
            flag2 = true;
          }
          else
          {
            if (num4 >= 0.0 & num7 >= 0.0 & index7 > 0)
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
            if (num4 < 0.0 & num7 > 0.0 & index7 > 0)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
            }
            if (num4 < 0.0 & num7 < 0.0 & index7 > 0)
            {
              ContinousPoints[index7][0] = new Pnt6D(new Pnt6D(ContinousPoints[index7][0])
              {
                A = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].A,
                C = ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C
              });
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = num20,
                C = num21
              });
            }
            if (num7 < 0.0 & num4 >= 0.0 & index7 > 0 && index7 < ContinousPoints.Count - 2)
              ContinousPoints[index7][index9] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index9])
              {
                A = ContinousPoints[index7][0].A,
                C = ContinousPoints[index7][0].C
              });
          }
        }
        num4 = Math.Round(num6, 5);
      }
      if (index7 > 0)
      {
        double num24 = ContinousPoints[index7][0].C - ContinousPoints[index7 - 1][ContinousPoints[index7 - 1].Count - 1].C;
        if (Math.Abs(num24) > 180.0)
        {
          if (num24 < 0.0)
          {
            Pnt6D Pnt1 = new Pnt6D(ContinousPoints[index7][0]);
            Pnt1.C += 360.0;
            ContinousPoints[index7][0] = new Pnt6D(Pnt1);
            Pnt6D Pnt2 = new Pnt6D(ContinousPoints[index7][1]);
            Pnt2.C += 360.0;
            ContinousPoints[index7][1] = new Pnt6D(Pnt2);
          }
          else
          {
            Pnt6D Pnt3 = new Pnt6D(ContinousPoints[index7][0]);
            Pnt3.C -= 360.0;
            ContinousPoints[index7][0] = new Pnt6D(Pnt3);
            Pnt6D Pnt4 = new Pnt6D(ContinousPoints[index7][1]);
            Pnt4.C -= 360.0;
            ContinousPoints[index7][1] = new Pnt6D(Pnt4);
          }
        }
      }
      List<Pnt6D> Points = new List<Pnt6D>();
      if (ContinousPoints[index7].Count == 2)
      {
        for (int index12 = 1; index12 <= ContinousPoints[index7].Count - 1; ++index12)
        {
          List<Pnt6D> collection = new List<Pnt6D>();
          if (!buCompare.EQ(new Pnt3D(ContinousPoints[index7][index12 - 1]), new Pnt3D(ContinousPoints[index7][index12])))
            buAppCalc.cVector.LineerInterpolation(ContinousPoints[index7][index12 - 1], ContinousPoints[index7][index12], 0.1, ref collection);
          else
            collection.Add(new Pnt6D(ContinousPoints[index7][index12]));
          this.ReAdjustAngleA(num5, AngleDiff, Operation, ref collection);
          Points.AddRange((IEnumerable<Pnt6D>) collection);
        }
        buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points);
        if (Points.Count >= 2)
          ContinousPoints[index7] = Points;
      }
      else if (ContinousPoints[index7].Count > 2)
      {
        List<double> Values1 = new List<double>();
        List<double> Values2 = new List<double>();
        double c3 = ContinousPoints[index7][0].C;
        double c4 = ContinousPoints[index7][ContinousPoints[index7].Count - 1].C;
        double a1 = ContinousPoints[index7][0].A;
        double a2 = ContinousPoints[index7][ContinousPoints[index7].Count - 1].A;
        buNumeric.DevideMinMaxValueByNumber(c3, c4, ContinousPoints[index7].Count, ref Values1);
        buNumeric.DevideMinMaxValueByNumber(a1, a2, ContinousPoints[index7].Count, ref Values2);
        for (int index13 = 0; index13 <= ContinousPoints[index7].Count - 1; ++index13)
          ContinousPoints[index7][index13] = new Pnt6D(new Pnt6D(ContinousPoints[index7][index13])
          {
            C = Values1[index13],
            A = Values2[index13]
          });
      }
    }
    for (int index14 = 0; index14 <= ContinousPoints.Count - 1; ++index14)
    {
      bool flag3 = false;
      CamPoint camPoint2 = new CamPoint();
      camPoint2.Type = 0;
      camPoint2.IsRapid = true;
      Pnt6D pnt6D7 = new Pnt6D();
      Pnt6D Pnt5 = new Pnt6D(ContinousPoints[index14][0]);
      Pnt3D Pnt6 = new Pnt3D(Pnt5);
      Pnt3D calcPoint = new Pnt3D();
      Pnt3D pnt3D1 = new Pnt3D();
      OrientationAngle orientationAngle2 = new OrientationAngle(Pnt5);
      OrientationAngle orientationAngle3 = new OrientationAngle();
      double feed = camPar.Speeds.Feed;
      double ToolLength = Tool.Geometry.Diameter / 2.0;
      double safe = camPar.Distances.Safe;
      double stepUp = camPar.Distances.StepUp;
      if (index14 <= ContinousPoints.Count - 2)
        orientationAngle3 = new OrientationAngle(ContinousPoints[index14 + 1][0]);
      pnt6D7 = new Pnt6D(Pnt6);
      calcPoint = new Pnt3D();
      double num25 = 0.0;
      if (index14 == 0 && orientationAngle2.A != 0.0)
      {
        num25 = orientationAngle2.A;
        Pnt5.A = 0.0;
      }
      Pnt6D pnt6D8 = new Pnt6D(Pnt5);
      calcPoint = new Pnt3D();
      Pnt9DCam pnt9Dcam = new Pnt9DCam(pnt6D8, camPar.Speeds.Rapid, 0);
      if (!buCompare.EQ(new Pnt3D(Pnt5), BasePoint) & index14 > 0)
        flag3 = true;
      if (index14 == 0)
      {
        pnt9Dcam.AfterCodes.Add((object) WaterJetApproach);
        pnt9Dcam.AfterCodes.Add((object) WaterJetDownOperationCmd);
        pnt9Dcam.AfterCodes.Add((object) WaterJetOnCmd);
        if (num25 != 0.0)
        {
          pnt9Dcam.AfterCodes.Add((object) "G75");
          pnt9Dcam.AfterCodes.Add((object) "M102");
          pnt9Dcam.AfterCodes.Add((object) ("G1 A" + num25.ToString("f2")));
          pnt9Dcam.AfterCodes.Add((object) "G75");
        }
        pnt9Dcam.AfterCodes.Add((object) "G38 O1");
      }
      if (flag3)
      {
        pnt9Dcam.PreCodes.Add((object) WaterJetNextOff);
        pnt9Dcam.AfterCodes.Add((object) WaterJetNextOn);
      }
      if (orientationAngle2.A == orientationAngle1.A)
        ;
      camPoint2.Points.Add(pnt9Dcam);
      Pnt6D pnt6D9 = new Pnt6D(pnt6D8);
      if (index14 == 0)
      {
        Pnt6D pnt6D10 = new Pnt6D(pnt6D8);
      }
      List<Pnt3D> vertice = new List<Pnt3D>();
      vertice.Add(new Pnt3D(ContinousPoints[index14][0]));
      for (int index15 = 1; index15 <= ContinousPoints[index14].Count - 1; ++index15)
      {
        Pnt5 = new Pnt6D(ContinousPoints[index14][index15]);
        orientationAngle2 = new OrientationAngle(Pnt5);
        Pnt6D pnt6D11 = new Pnt6D(Pnt5);
        camPoint2.Points.Add(new Pnt9DCam(pnt6D11, feed, 1));
        vertice.Add(new Pnt3D(Pnt5));
        BasePoint = new Pnt3D(Pnt5);
        Pnt6D pnt6D12 = new Pnt6D(pnt6D11);
        OrientationAngle orientationAngle4 = new OrientationAngle(orientationAngle2);
      }
      camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
      if (camPoint2.Points.Count > 0 & index14 == ContinousPoints.Count - 1)
      {
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G39 O1");
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) WaterJetOffCmd);
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) WaterJetApproach);
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G75");
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G0 A0.0");
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G75");
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G0 C0.0");
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) "G75");
        camPoint2.Points[camPoint2.Points.Count - 1].AfterCodes.Add((object) WaterJetAirUpCmd);
      }
      if (vertice.Count > 0)
        camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
      double Length = (camPar.Distances.Safe - Pnt5.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
      bool flag4 = orientationAngle2.A != orientationAngle3.A;
      if (index14 == ContinousPoints.Count - 1)
        flag4 = true;
      Pnt6D CalcPoint = new Pnt6D();
      calcPoint = new Pnt3D();
      Pnt3D pnt3D2 = new Pnt3D(BasePoint.X, BasePoint.Y, BasePoint.Z + stepUp);
      orientationAngle1 = new OrientationAngle(orientationAngle2);
      if (flag4)
      {
        CalcPoint = new Pnt6D();
        calcPoint = new Pnt3D();
        Pnt3D pnt3D3 = new Pnt3D(BasePoint.X, BasePoint.Y, BasePoint.Z + Length);
        buAppCalc.cVector.LineWithOrientationAngle(BasePoint, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), Length, ref calcPoint);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle2, new Pnt3D(calcPoint), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
      }
      Pnt6D pnt6D13 = new Pnt6D(CalcPoint);
      if (camPoint2.Points.Count > 0)
        camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
      for (int index16 = 1; index16 <= camPoint2.Points.Count - 1; ++index16)
      {
        List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
        double dt = 0.1;
        if (camPoint2.Points[index16].Type == 0)
          dt = 0.25;
        if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index16 - 1]), new Pnt3D(camPoint2.Points[index16])) > 3.0)
        {
          buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index16 - 1]), new Pnt6D(camPoint2.Points[index16]), dt, ref CalculatedPoints);
          CalculatedPoints.RemoveAt(0);
          camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
        }
        else
          camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index16]));
      }
      calcCam.CamPoints.Add(camPoint2);
      // ISSUE: reference to a compiler-generated field
      if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null && int32 > 0 & num1 > 0 && num1 % int32 == 0)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double) index14 / (double) (ContinousPoints.Count - 1)) * 100.0, Convert.ToDouble((double) index14 / (double) (ContinousPoints.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
      }
      if (buSystem.DoEventEnable & int32 > 0 & num1 > 0 && num1 % int32 == 0)
        Application.DoEvents();
      if (!buSystem.Cancel)
      {
        ++num1;
      }
      else
      {
        buSystem.Cancel = false;
        buSystem.Canceled = true;
        // ISSUE: reference to a compiler-generated field
        if (this.calculationEventHandler_2 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_2(new CalculationEventArg());
        }
        // ISSUE: reference to a compiler-generated field
        if (this.calculationEventHandler_3 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
        }
        buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
        break;
      }
    }
  }

  public void CalculateMarbleWireFrameWithLaserTool3Ax(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    camParameters CamParameter,
    double AValue,
    double CValue,
    string LaserEnableCmd,
    string LaserDisableCmd,
    string LaserStartCmd,
    string LaserStopCmd,
    string LaserDoneCmd,
    EntitiesResolution Resolution,
    ref camBase calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      calcCam = new camBase();
      calcCam.Tool = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      List<Triangle3D> Triangles = new List<Triangle3D>();
      KinematicItem kinematicItem = new KinematicItem();
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
      kinematicItem.Axis.A = false;
      kinematicItem.Axis.C = false;
      eEntities eEntities = (eEntities) new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      kinematicItem.Entities.Add(eEntities);
      calcCam.Kinematic.Items.Add(kinematicItem);
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      int int32 = Convert.ToInt32((double) Entities.Count / 100.0);
      int num = 0;
      Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
      Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
      for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
      {
        eEntities copiedEnt1 = new eEntities();
        if (Entities[index1].Count > 0)
        {
          eEntities copiedEnt2 = new eEntities();
          List<Pnt3D> TargetList = new List<Pnt3D>();
          eEntities.CopyEntity(Entities[index1][0], ref copiedEnt2);
          buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList);
          List<Pnt6D> Points = new List<Pnt6D>();
          buAppCalc.cVector.EntitiesToPoint(Entities[index1], Resolution, ref Points);
          if (CamParameter.Strategy.OverrideCEnable)
          {
            for (int index2 = 0; index2 <= Points.Count - 1; ++index2)
              Points[index2] = new Pnt6D(Points[index2])
              {
                C = CamParameter.Strategy.OverrideC
              };
            buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points);
          }
          if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
            TargetList.Reverse();
          CamPoint camPoint2 = new CamPoint();
          camPoint2.Type = 0;
          camPoint2.IsRapid = true;
          if (Points.Count > 1)
          {
            Pnt3D Pnt1 = new Pnt3D(Points[0]);
            OrientationAngle orientationAngle1 = new OrientationAngle(Points[0]);
            OrientationAngle orientationAngle2 = new OrientationAngle(Points[0]);
            Pnt6D pnt6D2 = new Pnt6D();
            Pnt6D pnt6D3 = new Pnt6D(new Pnt3D(Pnt1.X, Pnt1.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
            camPoint2.Points.Add(new Pnt9DCam(pnt6D3, CamParameter.Speeds.Rapid, 0));
            Pnt3D Pnt2 = new Pnt3D(Pnt1.X, Pnt1.Y, CamParameter.Distances.Safe);
            Pnt6D pnt6D4 = new Pnt6D(pnt6D3);
            Pnt6D pnt6D5 = new Pnt6D(Pnt1, new OrientationAngle(AValue, 0.0, CValue));
            Pnt9DCam pnt9Dcam1 = new Pnt9DCam(pnt6D5, CamParameter.Speeds.Plunge, 0);
            if (index1 == 0)
            {
              pnt9Dcam1.AfterCodes.Add((object) LaserEnableCmd);
              pnt9Dcam1.AfterCodes.Add((object) LaserStartCmd);
            }
            else
              pnt9Dcam1.AfterCodes.Add((object) LaserStartCmd);
            camPoint2.Points.Add(pnt9Dcam1);
            camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(Pnt1), Color.Lime));
            Pnt3D Pnt3 = new Pnt3D(Pnt1);
            Pnt6D pnt6D6 = new Pnt6D(pnt6D5);
            List<Pnt3D> vertice = new List<Pnt3D>();
            vertice.Add(new Pnt3D(Pnt3));
            for (int index3 = 1; index3 <= Points.Count - 1; ++index3)
            {
              Pnt3D pnt3D2 = new Pnt3D(Points[index3]);
              OrientationAngle Pnt4 = new OrientationAngle(Points[index3]);
              double feed = CamParameter.Speeds.Feed;
              Pnt6D pnt6D7 = new Pnt6D(new Pnt3D(Points[index3].X, Points[index3].Y, Points[index3].Z), new OrientationAngle(AValue, 0.0, CValue));
              camPoint2.Points.Add(new Pnt9DCam(pnt6D7, feed, 1));
              vertice.Add(new Pnt3D(pnt6D7));
              Pnt3 = new Pnt3D(Points[index3]);
              Pnt6D pnt6D8 = new Pnt6D(pnt6D7);
              OrientationAngle orientationAngle3 = new OrientationAngle(Pnt4);
            }
            camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Color.Blue));
            Pnt6D pnt6D9 = new Pnt6D(new Pnt3D(Pnt3.X, Pnt3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
            Pnt9DCam pnt9Dcam2 = new Pnt9DCam(pnt6D9, CamParameter.Speeds.Plunge, 1);
            if (index1 == Entities.Count - 1)
            {
              pnt9Dcam2.PreCodes.Add((object) LaserStopCmd);
              pnt9Dcam2.PreCodes.Add((object) LaserDoneCmd);
              pnt9Dcam2.AfterCodes.Add((object) LaserDisableCmd);
            }
            else
              pnt9Dcam2.PreCodes.Add((object) LaserStopCmd);
            camPoint2.Points.Add(pnt9Dcam2);
            camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt3), new Pnt3D(pnt6D9), Color.Red));
            if (camPoint2.Points.Count > 0)
              camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
            for (int index4 = 1; index4 <= camPoint2.Points.Count - 1; ++index4)
            {
              List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
              double dt = 0.1;
              if (camPoint2.Points[index4].Type == 0)
                dt = 0.25;
              if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index4 - 1]), new Pnt3D(camPoint2.Points[index4])) > 3.0)
              {
                buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index4 - 1]), new Pnt6D(camPoint2.Points[index4]), dt, ref CalculatedPoints);
                CalculatedPoints.RemoveAt(0);
                camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
              }
              else
                camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index4]));
            }
            eEntities.CopyEntity(copiedEnt2, ref copiedEnt1);
            calcCam.CamPoints.Add(camPoint2);
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double) index1 / (double) (Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num > 0 && num % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
          }
          buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void calcARatio(
    double DeltaAngle,
    double RefAngleA,
    marbleOperation Operation,
    ref double RatioAFromC,
    ref double RatioAFromA)
  {
    double Y3 = Math.Round(180.0 - Math.Abs(DeltaAngle), 5);
    if (Y3 <= 60.0)
      RatioAFromC = 1.462;
    if (Y3 > 60.0 & Y3 <= 70.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle60, Operation.WaterJet5AxisARatioCornerAngle70, 60.0, 70.0, Y3, ref RatioAFromC);
    if (Y3 > 70.0 & Y3 <= 80.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle70, Operation.WaterJet5AxisARatioCornerAngle80, 70.0, 80.0, Y3, ref RatioAFromC);
    if (Y3 > 80.0 & Y3 <= 90.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle80, Operation.WaterJet5AxisARatioCornerAngle90, 80.0, 90.0, Y3, ref RatioAFromC);
    if (Y3 > 90.0 & Y3 <= 100.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle90, Operation.WaterJet5AxisARatioCornerAngle100, 90.0, 100.0, Y3, ref RatioAFromC);
    if (Y3 > 100.0 & Y3 <= 110.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle100, Operation.WaterJet5AxisARatioCornerAngle110, 100.0, 110.0, Y3, ref RatioAFromC);
    if (Y3 > 110.0 & Y3 <= 120.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle110, Operation.WaterJet5AxisARatioCornerAngle120, 110.0, 120.0, Y3, ref RatioAFromC);
    if (Y3 > 120.0 & Y3 <= 130.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle120, Operation.WaterJet5AxisARatioCornerAngle130, 120.0, 130.0, Y3, ref RatioAFromC);
    if (Y3 > 130.0 & Y3 <= 140.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle130, Operation.WaterJet5AxisARatioCornerAngle140, 130.0, 140.0, Y3, ref RatioAFromC);
    if (Y3 > 140.0 & Y3 <= 150.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle140, Operation.WaterJet5AxisARatioCornerAngle150, 140.0, 150.0, Y3, ref RatioAFromC);
    if (Y3 > 150.0 & Y3 <= 160.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle150, Operation.WaterJet5AxisARatioCornerAngle160, 150.0, 160.0, Y3, ref RatioAFromC);
    if (Y3 > 160.0 & Y3 <= 170.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle160, Operation.WaterJet5AxisARatioCornerAngle170, 160.0, 170.0, Y3, ref RatioAFromC);
    if (Y3 > 170.0 & Y3 <= 180.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle170, Operation.WaterJet5AxisARatioCornerAngle180, 170.0, 180.0, Y3, ref RatioAFromC);
    if (Y3 > 180.0)
      RatioAFromC = 1.0;
    if (RefAngleA == 0.0)
      RatioAFromA = 1.0;
    if (RefAngleA > 0.0 & RefAngleA <= 1.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA0, Operation.WaterJet5AxisARtForA1, 0.0, 1.0, RefAngleA, ref RatioAFromA);
    if (RefAngleA > 1.0 & RefAngleA <= 5.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA1, Operation.WaterJet5AxisARtForA5, 1.0, 5.0, RefAngleA, ref RatioAFromA);
    if (RefAngleA > 5.0 & RefAngleA <= 10.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA5, Operation.WaterJet5AxisARtForA10, 5.0, 10.0, RefAngleA, ref RatioAFromA);
    if (RefAngleA > 10.0 & RefAngleA <= 20.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA10, Operation.WaterJet5AxisARtForA20, 10.0, 20.0, RefAngleA, ref RatioAFromA);
    if (RefAngleA > 20.0 & RefAngleA <= 30.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA20, Operation.WaterJet5AxisARtForA30, 20.0, 30.0, RefAngleA, ref RatioAFromA);
    if (RefAngleA > 30.0 & RefAngleA <= 40.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA30, Operation.WaterJet5AxisARtForA40, 30.0, 40.0, RefAngleA, ref RatioAFromA);
    if (RefAngleA > 40.0 & RefAngleA <= 45.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA40, Operation.WaterJet5AxisARtForA45, 40.0, 45.0, RefAngleA, ref RatioAFromA);
    if (RefAngleA > 45.0 & RefAngleA <= 50.0)
      buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA45, Operation.WaterJet5AxisARtForA50, 45.0, 50.0, RefAngleA, ref RatioAFromA);
    if (RefAngleA <= 50.0)
      return;
    RatioAFromA = Operation.WaterJet5AxisARtForA50;
  }

  public void ReAdjustAngleA(
    double refAngle,
    double AngleDiff,
    marbleOperation Operation,
    ref List<Pnt6D> Points)
  {
    bool flag = false;
    if (Points.Count >= 2)
    {
      if (Points[0].A > Points[1].A)
      {
        flag = true;
        AngleDiff = Points[0].A - Points[Points.Count - 1].A;
        refAngle = Points[Points.Count - 1].A;
      }
      else
      {
        AngleDiff = Points[Points.Count - 1].A - Points[0].A;
        refAngle = Points[0].A;
      }
    }
    if (!flag)
    {
      for (int index = 1; index <= Points.Count - 1; ++index)
      {
        Pnt6D Pnt = new Pnt6D(Points[index]);
        if (index == 1)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc1 / 100.0;
        if (index == 2)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc2 / 100.0;
        if (index == 3)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc3 / 100.0;
        if (index == 4)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc4 / 100.0;
        if (index == 5)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc5 / 100.0;
        if (index == 6)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc6 / 100.0;
        if (index == 7)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc7 / 100.0;
        if (index == 8)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc8 / 100.0;
        if (index == 9)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc9 / 100.0;
        if (index == 10)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc10 / 100.0;
        Points[index] = new Pnt6D(Pnt);
      }
    }
    else
    {
      for (int index = 0; index <= Points.Count - 2; ++index)
      {
        Pnt6D Pnt = new Pnt6D(Points[index]);
        if (index == 0)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc10 / 100.0;
        if (index == 1)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc9 / 100.0;
        if (index == 2)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc8 / 100.0;
        if (index == 3)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc7 / 100.0;
        if (index == 4)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc6 / 100.0;
        if (index == 5)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc5 / 100.0;
        if (index == 6)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc4 / 100.0;
        if (index == 7)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc3 / 100.0;
        if (index == 8)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc2 / 100.0;
        if (index == 9)
          Pnt.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc1 / 100.0;
        Points[index] = new Pnt6D(Pnt);
      }
    }
  }

  public void CalculateMarbleHoleWithMillingTool(
    List<eEntities> Holes,
    KinematicBase Kinematic,
    ToolBase Tool,
    marbleCamParameters CamPars,
    camParameters CamParameter,
    double AValue,
    double CValue,
    ref camBase calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      calcCam = new camBase();
      calcCam.Tool = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      List<Triangle3D> Triangles = new List<Triangle3D>();
      KinematicItem kinematicItem = new KinematicItem();
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
      kinematicItem.Axis.A = false;
      kinematicItem.Axis.C = false;
      eEntities eEntities = (eEntities) new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      kinematicItem.Entities.Add(eEntities);
      calcCam.Kinematic.Items.Add(kinematicItem);
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      int int32 = Convert.ToInt32((double) Holes.Count / 100.0);
      int num1 = 0;
      if (CamParameter.Hole.HoleType == grindingHoleType.OneTimeToDown)
      {
        for (int index1 = 0; index1 <= Holes.Count - 1; ++index1)
        {
          eEntities copiedEnt = new eEntities();
          eEntities.CopyEntity(Holes[index1], ref copiedEnt);
          CamPoint camPoint2 = new CamPoint();
          camPoint2.Type = 0;
          camPoint2.IsRapid = true;
          Pnt3D pnt3D2 = new Pnt3D(Holes[index1].Vertice[0]);
          OrientationAngle orientationAngle = new OrientationAngle(Holes[index1].Orientation);
          Pnt6D pnt6D2 = new Pnt6D();
          Pnt6D P1 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
          camPoint2.Points.Add(new Pnt9DCam(P1, CamParameter.Speeds.Rapid, 0, true));
          Pnt6D pnt6D3 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
          camPoint2.Points.Add(new Pnt9DCam(pnt6D3, CamParameter.Speeds.Rapid, 0, false));
          Pnt3D Pnt1 = new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe);
          Pnt6D pnt6D4 = new Pnt6D(pnt6D3);
          Pnt6D P2 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.StartHeight), new OrientationAngle(AValue, 0.0, CValue));
          camPoint2.Points.Add(new Pnt9DCam(P2, CamParameter.Speeds.Rapid, 0, true));
          camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt1), new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.StartHeight), Color.Lime));
          Pnt3D Pnt2 = new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.StartHeight);
          Pnt6D pnt6D5 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.EndHeight), new OrientationAngle(AValue, 0.0, CValue));
          camPoint2.Points.Add(new Pnt9DCam(pnt6D5, CamParameter.Speeds.Plunge, 1, false));
          camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.EndHeight), Color.Lime));
          List<Pnt3D> Vertices = new List<Pnt3D>();
          buAppCalc.cVector.CircleWithCenter(pnt3D2, Tool.Geometry.Diameter / 2.0, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices);
          camPoint2.EntitiesMark.Add((geoEntity) new geoPolyline(Vertices, Color.Brown));
          Pnt3D Pnt3 = new Pnt3D(pnt3D2);
          Pnt6D pnt6D6 = new Pnt6D(pnt6D5);
          Pnt6D pnt6D7 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
          camPoint2.Points.Add(new Pnt9DCam(pnt6D7, CamParameter.Speeds.Leave, 1));
          camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt3), new Pnt3D(pnt3D2), Color.Red));
          pnt3D1 = new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe);
          Pnt6D pnt6D8 = new Pnt6D(pnt6D7);
          if (camPoint2.Points.Count > 0)
            camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
          for (int index2 = 1; index2 <= camPoint2.Points.Count - 1; ++index2)
          {
            List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
            double dt = 0.1;
            if (camPoint2.Points[index2].Type == 0)
              dt = 0.25;
            if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index2 - 1]), new Pnt3D(camPoint2.Points[index2])) > 3.0)
            {
              buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index2 - 1]), new Pnt6D(camPoint2.Points[index2]), dt, ref CalculatedPoints);
              CalculatedPoints.RemoveAt(0);
              camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
            }
            else
              camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index2]));
          }
          calcCam.CamPoints.Add(camPoint2);
          // ISSUE: reference to a compiler-generated field
          if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double) index1 / (double) (Holes.Count - 1)) * 100.0, 0, "Calculate Marble Hole", ""));
          }
          if (buSystem.DoEventEnable & int32 > 0 & num1 > 0 && num1 % int32 == 0)
            Application.DoEvents();
          if (!buSystem.Cancel)
          {
            ++num1;
          }
          else
          {
            buSystem.Cancel = false;
            buSystem.Canceled = true;
            // ISSUE: reference to a compiler-generated field
            if (this.calculationEventHandler_2 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.calculationEventHandler_2(new CalculationEventArg());
            }
            // ISSUE: reference to a compiler-generated field
            if (this.calculationEventHandler_3 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
            }
            buLog.addLog("Calculate Marble Hole", "Canceled", MethodBase.GetCurrentMethod().Name);
            return;
          }
        }
      }
      if (CamParameter.Hole.HoleType == grindingHoleType.UpDownByStep)
      {
        for (int index3 = 0; index3 <= Holes.Count - 1; ++index3)
        {
          eEntities copiedEnt = new eEntities();
          eEntities.CopyEntity(Holes[index3], ref copiedEnt);
          CamPoint camPoint3 = new CamPoint();
          camPoint3.Type = 0;
          camPoint3.IsRapid = true;
          Pnt3D pnt3D3 = new Pnt3D(Holes[index3].Vertice[0]);
          OrientationAngle orientationAngle = new OrientationAngle(Holes[index3].Orientation);
          Pnt6D pnt6D9 = new Pnt6D();
          Pnt6D P = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
          camPoint3.Points.Add(new Pnt9DCam(P, CamParameter.Speeds.Rapid, 0, true));
          Pnt6D pnt6D10 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
          camPoint3.Points.Add(new Pnt9DCam(pnt6D10, CamParameter.Speeds.Rapid, 0, false));
          Pnt3D Pnt = new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe);
          Pnt6D pnt6D11 = new Pnt6D(pnt6D10);
          double num2 = 0.0;
          Pnt9DCam pnt9Dcam1 = new Pnt9DCam();
          geoLine geoLine1 = new geoLine();
          for (double z = CamParameter.Hole.StartHeight - Math.Abs(CamParameter.Hole.DownStep); z >= CamParameter.Hole.EndHeight; z -= Math.Abs(CamParameter.Hole.DownStep))
          {
            Pnt6D pnt6D12 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, z), new OrientationAngle(AValue, 0.0, CValue));
            Pnt6D pnt6D13 = new Pnt6D(pnt6D12);
            Pnt9DCam pnt9Dcam2 = new Pnt9DCam(pnt6D12, CamParameter.Speeds.Plunge, 1, false);
            camPoint3.Points.Add(pnt9Dcam2);
            geoLine geoLine2 = new geoLine(new Pnt3D(Pnt), new Pnt3D(pnt6D12), this.colorPlunge, this.entThickness);
            camPoint3.EntitiesPlunge.Add((geoEntity) geoLine2);
            pnt3D1 = new Pnt3D(pnt6D12.X, pnt6D12.Y, pnt6D12.Z);
            geoCircle geoCircle = new geoCircle(new Pnt3D(pnt6D12), Tool.Geometry.Diameter / 2.0);
            geoCircle.Color = this.colorMark;
            camPoint3.EntitiesMark.Add((geoEntity) geoCircle);
            Pnt6D pnt6D14 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, z + CamParameter.Hole.UpStep), new OrientationAngle(AValue, 0.0, CValue));
            Pnt6D pnt6D15 = new Pnt6D(pnt6D14);
            Pnt9DCam pnt9Dcam3 = new Pnt9DCam(pnt6D14, CamParameter.Speeds.Leave, 1, false);
            camPoint3.Points.Add(pnt9Dcam3);
            Pnt = new Pnt3D(pnt6D14.X, pnt6D14.Y, pnt6D14.Z);
            num2 = z;
          }
          if (num2 > CamParameter.Hole.EndHeight)
          {
            Pnt6D pnt6D16 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Hole.EndHeight), new OrientationAngle(AValue, 0.0, CValue));
            Pnt6D pnt6D17 = new Pnt6D(pnt6D16);
            Pnt9DCam pnt9Dcam4 = new Pnt9DCam(pnt6D16, CamParameter.Speeds.Plunge, 1, false);
            camPoint3.Points.Add(pnt9Dcam4);
            geoLine geoLine3 = new geoLine(new Pnt3D(Pnt), new Pnt3D(pnt6D16), this.colorPlunge, this.entThickness);
            camPoint3.EntitiesPlunge.Add((geoEntity) geoLine3);
            pnt3D1 = new Pnt3D(pnt6D16.X, pnt6D16.Y, pnt6D16.Z);
            geoCircle geoCircle = new geoCircle(new Pnt3D(pnt6D16), Tool.Geometry.Diameter / 2.0);
            geoCircle.Color = this.colorMark;
            camPoint3.EntitiesMark.Add((geoEntity) geoCircle);
            Pnt6D pnt6D18 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Hole.EndHeight + CamParameter.Hole.UpStep), new OrientationAngle(AValue, 0.0, CValue));
            Pnt6D pnt6D19 = new Pnt6D(pnt6D18);
            Pnt9DCam pnt9Dcam5 = new Pnt9DCam(pnt6D18, CamParameter.Speeds.Leave, 1, false);
            camPoint3.Points.Add(pnt9Dcam5);
            Pnt = new Pnt3D(pnt6D18.X, pnt6D18.Y, pnt6D18.Z);
          }
          Pnt6D pnt6D20 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
          camPoint3.Points.Add(new Pnt9DCam(pnt6D20, CamParameter.Speeds.Leave, 1));
          camPoint3.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt), new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe), Color.Red));
          pnt3D1 = new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe);
          Pnt6D pnt6D21 = new Pnt6D(pnt6D20);
          if (camPoint3.Points.Count > 0)
            camPoint3.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint3.Points[0]));
          for (int index4 = 1; index4 <= camPoint3.Points.Count - 1; ++index4)
          {
            List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
            double dt = 0.1;
            if (camPoint3.Points[index4].Type == 0)
              dt = 0.25;
            if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint3.Points[index4 - 1]), new Pnt3D(camPoint3.Points[index4])) > 3.0)
            {
              buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint3.Points[index4 - 1]), new Pnt6D(camPoint3.Points[index4]), dt, ref CalculatedPoints);
              CalculatedPoints.RemoveAt(0);
              camPoint3.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
            }
            else
              camPoint3.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint3.Points[index4]));
          }
          calcCam.CamPoints.Add(camPoint3);
          // ISSUE: reference to a compiler-generated field
          if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double) index3 / (double) (Holes.Count - 1)) * 100.0, 0, "Calculate Marble Hole", ""));
          }
          if (buSystem.DoEventEnable & int32 > 0 & num1 > 0 && num1 % int32 == 0)
            Application.DoEvents();
          if (!buSystem.Cancel)
          {
            ++num1;
          }
          else
          {
            buSystem.Cancel = false;
            buSystem.Canceled = true;
            // ISSUE: reference to a compiler-generated field
            if (this.calculationEventHandler_2 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.calculationEventHandler_2(new CalculationEventArg());
            }
            // ISSUE: reference to a compiler-generated field
            if (this.calculationEventHandler_3 != null)
            {
              // ISSUE: reference to a compiler-generated field
              this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
            }
            buLog.addLog("Calculate Marble Hole", "Canceled", MethodBase.GetCurrentMethod().Name);
            return;
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void HatchCamCalculationMarble(
    camHatch Hatch,
    camDistances Distances,
    camSpeeds Velocity,
    camStep Steps,
    camStrategy Strategy,
    KinematicBase Kinematic,
    ToolBase Tool,
    EntitiesResolution Resolution,
    ref camBase calcCam,
    ref List<eEntities> Entities)
  {
    if (Hatch.CutStep <= 0.0 || Hatch.TotalWidth <= 0.0 || Hatch.CutLength <= 0.0 || Hatch.CutStep > Hatch.TotalWidth)
      return;
    List<List<eEntities>> Entities1 = new List<List<eEntities>>();
    Entities.Clear();
    int num1 = (int) buNumeric.RoundToLower(Hatch.TotalWidth / Hatch.CutStep);
    if (num1 == 0)
      num1 = 1;
    double num2 = Hatch.TotalWidth / (double) num1;
    if (Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
    {
      Pnt3D Pnt = new Pnt3D();
      List<eEntities> eEntitiesList = new List<eEntities>();
      for (int index = 0; index <= num1 - 1; ++index)
      {
        if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
        {
          eEntitiesList = new List<eEntities>();
          double num3 = (double) index * num2;
          eEntities eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Entities1.Add(eEntitiesList);
        }
        if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
        {
          eEntitiesList = new List<eEntities>();
          Strategy.OverrideCEnable = true;
          Strategy.OverrideC = 0.0;
          double num4 = (double) index * num2;
          eEntities eEntities1 = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num4, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num4, Hatch.OperationZ));
          Entities.Add(eEntities1);
          eEntitiesList.Add(eEntities1);
          eEntities eEntities2 = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num4, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num4, Hatch.OperationZ));
          Entities.Add(eEntities2);
          eEntitiesList.Add(eEntities2);
          Entities1.Add(eEntitiesList);
        }
        if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        {
          double y = (double) index * num2;
          eEntities eEntities = (eEntities) null;
          if (Entities.Count > 0)
          {
            eEntities = (eEntities) new eLine(new Pnt3D(Pnt), new Pnt3D(Pnt.X, y, Hatch.OperationZ));
            Entities.Add(eEntities);
            eEntitiesList.Add(eEntities);
          }
          if (index % 2 == 0)
            eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + y, Hatch.OperationZ));
          if (index % 2 == 1)
            eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + y, Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Pnt = new Pnt3D(eEntities.Vertice[eEntities.Vertice.Count - 1]);
        }
      }
      if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
      {
        Strategy.AngleLimit = 20.0;
        Entities1.Add(eEntitiesList);
      }
    }
    if (Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
    {
      Pnt3D Pnt = new Pnt3D();
      List<eEntities> eEntitiesList = new List<eEntities>();
      for (int index = 0; index <= num1 - 1; ++index)
      {
        if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
        {
          eEntitiesList = new List<eEntities>();
          double num5 = (double) index * num2;
          eEntities eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + num5, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num5, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Entities1.Add(eEntitiesList);
        }
        if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
        {
          eEntitiesList = new List<eEntities>();
          Strategy.OverrideCEnable = true;
          Strategy.OverrideC = 90.0;
          double num6 = (double) index * num2;
          eEntities eEntities3 = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + num6, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num6, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
          Entities.Add(eEntities3);
          eEntitiesList.Add(eEntities3);
          eEntities eEntities4 = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + num6, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num6, Hatch.CornerPoint.Y, Hatch.OperationZ));
          Entities.Add(eEntities4);
          eEntitiesList.Add(eEntities4);
          Entities1.Add(eEntitiesList);
        }
        if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        {
          double x = (double) index * num2;
          eEntities eEntities = (eEntities) null;
          if (Entities.Count > 0)
          {
            eEntities = (eEntities) new eLine(new Pnt3D(Pnt), new Pnt3D(x, Pnt.Y, Hatch.OperationZ));
            Entities.Add(eEntities);
            eEntitiesList.Add(eEntities);
          }
          if (index % 2 == 0)
            eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + x, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + x, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
          if (index % 2 == 1)
            eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + x, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + x, Hatch.CornerPoint.Y, Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Pnt = new Pnt3D(eEntities.Vertice[eEntities.Vertice.Count - 1]);
        }
      }
      if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
      {
        Strategy.AngleLimit = 20.0;
        Entities1.Add(eEntitiesList);
      }
    }
    new marbleOperation().TargetZ = Hatch.OperationZ;
    camParameters camParameters = new camParameters(Distances, Velocity, Steps, new camOffset(), new camOperation(), new camOptions(), Strategy, new camPocket(), new LeadIn(), new LeadOut(), new camHole(), new camMaterial(), new camHatch());
    this.CalculateMarbleWireFrameWithMillingAndWaterJetTool3Ax(Entities1, Kinematic, Tool, false, new camParameters(Distances, Velocity, Steps, new camOffset(), new camOperation(), new camOptions(), Strategy, new camPocket(), new LeadIn(), new LeadOut(), new camHole(), new camMaterial(), new camHatch()), 0.0, 0.0, "", "", "", "", "", "", "", Resolution, ref calcCam);
  }

  public int PunchWithTwoPoint(
    double Start,
    double End,
    double Offset,
    double ToolWidth,
    double ToolUsePersentage,
    punchParameters Par,
    ref List<double> calcPoints)
  {
    double num1 = Math.Abs(End - Start);
    calcPoints = new List<double>();
    double num2 = ToolUsePersentage <= 1.0 ? ToolUsePersentage : ToolUsePersentage / 100.0;
    double num3 = ToolWidth * num2;
    int num4;
    if (Math.Round(num1, 3) > Math.Round(ToolWidth, 3) && !Par.Options.IfToolWidthBiggerThanPunchLengthMakeOperation)
    {
      buString.MessageBoxError(AppLanguage.CadCamMessages[42]);
      num4 = -1;
    }
    else
    {
      int int32 = Convert.ToInt32(buNumeric.RoundToUpper(Math.Round(num1 / ToolWidth, 3)));
      if (End > Start)
      {
        if (int32 == 1)
        {
          double num5 = Start + Offset + ToolWidth / 2.0;
          calcPoints.Add(num5);
        }
        if (int32 > 1)
        {
          double num6 = 0.0;
          double num7 = num1;
          for (int index = 0; index <= int32; ++index)
          {
            if (num7 > 0.0)
            {
              if (num7 > ToolWidth)
              {
                double num8 = Start + Offset + num6 + num3 / 2.0;
                calcPoints.Add(num8);
                num6 += num3;
                num7 -= num3;
              }
              else
              {
                double num9 = End + Offset - ToolWidth / 2.0;
                calcPoints.Add(num9);
                num7 = 0.0;
              }
            }
          }
        }
      }
      if (Start > End)
      {
        if (int32 == 1)
        {
          double num10 = Start + Offset - ToolWidth / 2.0;
          calcPoints.Add(num10);
        }
        if (int32 > 1)
        {
          double num11 = 0.0;
          double num12 = num1;
          for (int index = 0; index <= int32; ++index)
          {
            if (num12 > 0.0)
            {
              if (num12 > ToolWidth)
              {
                double num13 = Start + Offset - num11 - num3 / 2.0;
                calcPoints.Add(num13);
                num11 += num3;
                num12 -= num3;
              }
              else
              {
                double num14 = End + Offset + ToolWidth / 2.0;
                calcPoints.Add(num14);
                num12 = 0.0;
              }
            }
          }
        }
      }
      num4 = 1;
    }
    return num4;
  }

  public int ProfileOperationTopPlaneCalc(
    ref ProfileOperation P,
    ref List<eEntities> CadEntities,
    ref camBase CamCalc,
    actionTypeBU Action,
    ToolBase Tool,
    WorkPlane Plane,
    ProfileOperationData OperationData,
    camParameters camParMilling,
    ProfileTempData TempData,
    int LayerIndex,
    ProfileItem Profile)
  {
    try
    {
      List<Pnt3D> pnt3DList1 = new List<Pnt3D>();
      double Thickness = 1.0;
      List<List<Pnt3D>> pnt3DListList1 = new List<List<Pnt3D>>();
      List<double> doubleList = new List<double>();
      CamCalc = new camBase();
      ToolBase toolBase = new ToolBase(Tool);
      CamPoint camPoint1 = new CamPoint();
      CamZHeightType OperationCamType = CamZHeightType.Contour;
      Pnt9D Pnt1 = new Pnt9D();
      Pnt3D pnt3D1 = new Pnt3D();
      eEntities eEntities1 = new eEntities();
      List<eEntities> BaseRefEntities = new List<eEntities>();
      Pnt3D Pnt2 = new Pnt3D();
      double num1 = camParMilling.Speeds.Feed;
      double num2 = camParMilling.Speeds.Finish;
      double num3 = camParMilling.Speeds.AreaClearance;
      double num4 = camParMilling.Speeds.Plunge;
      if (!camParMilling.Speeds.FeedEnable)
        num1 = Tool.CamData.FeedSpeed;
      if (!camParMilling.Speeds.PlungeEnable)
        num4 = Tool.CamData.PlungeSpeed;
      if (!camParMilling.Speeds.AreaClearanceEnable)
        num3 = Tool.CamData.AreaClearanceSpeed;
      if (!camParMilling.Speeds.FinishEnable)
        num2 = Tool.CamData.FinishSpeed;
      if (camParMilling.Operations.AreaClearanceEnable)
      {
        OperationCamType = CamZHeightType.AreaClearance;
        num1 = num3;
      }
      if (Action == actionTypeBU.profileCircle)
      {
        P = (ProfileOperation) new ProfileOperationCircle();
        ((ProfileOperationCircle) P).Diameter = OperationData.CircleData.CircleDiameter;
        P.Name = "Circle";
        doubleList.Add(OperationData.CircleData.CircleDiameter / 2.0);
        if (camParMilling.Operations.FinishEnable)
          doubleList.Add(OperationData.CircleData.CircleDiameter / 2.0);
        if (camParMilling.Operations.AreaClearanceEnable)
        {
          int int32 = Convert.ToInt32(buNumeric.RoundToUpper(OperationData.CircleData.CircleDiameter / toolBase.Geometry.Diameter));
          for (int index = 0; index <= int32; ++index)
          {
            double num5 = OperationData.CircleData.CircleDiameter / 2.0 - toolBase.Geometry.Diameter / 2.0 * (double) (index + 1);
            if (num5 > 0.0)
              doubleList.Add(num5);
          }
        }
        if (camParMilling.Operations.AreaClearanceDirection == InToOutType.InToOut & camParMilling.Operations.AreaClearanceEnable)
          doubleList.Reverse();
        pnt3D1 = new Pnt3D(OperationData.Position.X, OperationData.Position.Y, 0.0);
      }
      if (Action == actionTypeBU.profileRectangle)
      {
        P = (ProfileOperation) new ProfileOperationRectangle();
        ((ProfileOperationRectangle) P).Width = OperationData.RectangleData.RectangleWidth;
        ((ProfileOperationRectangle) P).Height = OperationData.RectangleData.RectangleHeight;
        ((ProfileOperationRectangle) P).Angle = OperationData.RectangleData.RectangleAngle;
        P.Name = "Rectangle";
      }
      if (Action == actionTypeBU.profileRoundRectangle)
      {
        P = (ProfileOperation) new ProfileOperationRoundRectangle();
        ((ProfileOperationRoundRectangle) P).Width = OperationData.RectangleRoundData.RoundRectangleWidth;
        ((ProfileOperationRoundRectangle) P).Height = OperationData.RectangleRoundData.RoundRectangleHeight;
        ((ProfileOperationRoundRectangle) P).Angle = OperationData.RectangleRoundData.RoundRectangleAngle;
        ((ProfileOperationRoundRectangle) P).Radius = OperationData.RectangleRoundData.RoundRectangleRadius;
        P.Name = "Round Rectangle";
      }
      if (Action == actionTypeBU.profileSlot)
      {
        P = (ProfileOperation) new ProfileOperationSlot();
        ((ProfileOperationSlot) P).Width = OperationData.SlotData.SlotWidth;
        ((ProfileOperationSlot) P).Diameter = OperationData.SlotData.SlotDiameter;
        ((ProfileOperationSlot) P).Angle = OperationData.SlotData.SlotAngle;
        P.Name = "Slot";
      }
      if (Action == actionTypeBU.profileCut)
      {
        P = (ProfileOperation) new ProfileOperationCut();
        ((ProfileOperationCut) P).CutWidth = OperationData.CutData.CutWidth;
        ((ProfileOperationCut) P).CutHeight = OperationData.CutData.CutHeigth;
        ((ProfileOperationCut) P).Angle = OperationData.CutData.CutAngle;
        P.Name = "Cut";
      }
      if (Action == actionTypeBU.profileBarrel)
      {
        P = (ProfileOperation) new ProfileOperationBarrel();
        ((ProfileOperationBarrel) P).Diameter = OperationData.BarelData.BarrelDiameter;
        ((ProfileOperationBarrel) P).Width = OperationData.BarelData.BarrelWidth;
        ((ProfileOperationBarrel) P).Length = OperationData.BarelData.BarrelLength;
        ((ProfileOperationBarrel) P).Angle = OperationData.BarelData.BarrelAngle;
        P.Name = "Barrel";
      }
      if (Action == actionTypeBU.profileEllipse)
      {
        P = (ProfileOperation) new ProfileOperationEllipse();
        ((ProfileOperationEllipse) P).Width = OperationData.EllipseData.EllipseWidth;
        ((ProfileOperationEllipse) P).Height = OperationData.EllipseData.EllipseHeight;
        ((ProfileOperationEllipse) P).Angle = OperationData.EllipseData.EllipseAngle;
        P.Name = "Ellipse";
      }
      if (Action == actionTypeBU.profileHole)
      {
        P = (ProfileOperation) new ProfileOperationHole();
        ((ProfileOperationHole) P).Diameter = toolBase.Geometry.Diameter;
        P.Name = "Hole";
      }
      if (Action == actionTypeBU.profileNotch)
      {
        P = (ProfileOperation) new ProfileOperationNotch();
        ((ProfileOperationNotch) P).Width = OperationData.NotchData.NotchLWidth;
        ((ProfileOperationNotch) P).Height = OperationData.NotchData.NotchLHeight;
        ((ProfileOperationNotch) P).ToolCutPersentage = OperationData.NotchData.NotchCutPersentage;
        P.Depth = OperationData.NotchData.NotchLDepth;
        P.Name = "Notch";
      }
      if (Action == actionTypeBU.profileFreeDraw)
      {
        P = (ProfileOperation) new ProfileOperationFreeDraw();
        ((ProfileOperationFreeDraw) P).Width = OperationData.FreeDrawData.FreeDrawWidth;
        ((ProfileOperationFreeDraw) P).Height = OperationData.FreeDrawData.FreeDrawHeight;
        ((ProfileOperationFreeDraw) P).Angle = OperationData.FreeDrawData.FreeDrawAngle;
        P.Name = "Free Draw";
      }
      if (Action == actionTypeBU.profileFromSelection)
      {
        Pnt3D MinPoint = new Pnt3D();
        Pnt3D MaxPoint = new Pnt3D();
        buAppCalc.cVector.BoxSizeCalculate(TempData.ScaledEntitiesPoints, ref MinPoint, ref MaxPoint);
        double num6 = MaxPoint.X - MinPoint.X;
        double num7 = MaxPoint.Y - MinPoint.Y;
        P = (ProfileOperation) new ProfileOperationFreeDraw();
        ((ProfileOperationFreeDraw) P).Width = num6;
        ((ProfileOperationFreeDraw) P).Height = num7;
        ((ProfileOperationFreeDraw) P).Angle = 0.0;
        P.Name = "Free Draw";
      }
      if (Action == actionTypeBU.profileText)
      {
        P = (ProfileOperation) new ProfileOperationText();
        ((ProfileOperationText) P).Width = OperationData.TextData.TextWidth;
        ((ProfileOperationText) P).Height = OperationData.TextData.TextHeight;
        ((ProfileOperationText) P).Angle = OperationData.TextData.TextAngle;
        ((ProfileOperationText) P).Text = OperationData.TextData.TextString;
        ((ProfileOperationText) P).TextFont = new Font(OperationData.TextData.TextFont.FontFamily, OperationData.TextData.TextFont.Size, OperationData.TextData.TextFont.Style);
        P.Name = "Text";
      }
      P.Action = Action;
      double z1 = camParMilling.Distances.Safe;
      double z2 = camParMilling.Distances.FirstApproach;
      double num8 = camParMilling.Distances.FirstApproach;
      double num9 = camParMilling.Distances.Safe;
      if (OperationData.PlaneSelectedName == planeNames.Top)
      {
        z1 = camParMilling.Distances.Safe + Profile.Height;
        z2 = camParMilling.Distances.FirstApproach + Profile.Height;
        num8 = camParMilling.Distances.FirstApproach;
        num9 = camParMilling.Distances.Safe;
      }
      if (OperationData.PlaneSelectedName == planeNames.Left)
      {
        z1 = camParMilling.Distances.LeftSafe;
        z2 = camParMilling.Distances.LeftFirstApproach;
        num8 = camParMilling.Distances.LeftFirstApproach;
        num9 = camParMilling.Distances.LeftSafe;
      }
      if (OperationData.PlaneSelectedName == planeNames.Right)
      {
        z1 = -Profile.Width - camParMilling.Distances.RightSafe;
        z2 = -Profile.Width - camParMilling.Distances.RightFirstApproach;
        num8 = camParMilling.Distances.RightFirstApproach;
        num9 = camParMilling.Distances.RightSafe;
      }
      List<camZHeight> RefList = new List<camZHeight>();
      for (int index1 = 0; index1 <= OperationData.DepthSelectedValues.Count - 1; ++index1)
      {
        if (!camParMilling.Steps.Enable)
        {
          camZHeight camZheight = new camZHeight();
          camZheight.Depth = OperationData.DepthSelectedValues[index1].Position + OperationData.DepthSelectedValues[index1].Depth;
          camZheight.Type = CamZHeightType.Contour;
          camZheight.FinalStep = true;
          if (camParMilling.Operations.FinishEnable)
            camZheight.Type = CamZHeightType.Finish;
          if (camParMilling.Operations.AreaClearanceEnable)
            camZheight.Type = CamZHeightType.AreaClearance;
          if (OperationData.PlaneSelectedName == planeNames.Left | OperationData.PlaneSelectedName == planeNames.Right)
          {
            if (OperationData.YDirection == ProfileYAxisDirection.PositiveDirection)
              RefList.Add(camZheight);
            else
              RefList.Add(camZheight);
          }
          else
            RefList.Add(camZheight);
        }
        else
        {
          double num10 = Convert.ToDouble(camParMilling.Steps.Count) * camParMilling.Steps.Step;
          int count = camParMilling.Steps.Count;
          List<double> CalcValues = new List<double>();
          camStep Steps = new camStep(true, OperationData.DepthSelectedValues[index1].Position, 0.0, OperationData.DepthSelectedValues[index1].Depth, 0, camParMilling.Steps.Step, CamStepType.StartToDistanceByTrueStep);
          buAppCalc.cVector.CamStepCalculation(Steps, ref CalcValues);
          for (int index2 = 0; index2 <= CalcValues.Count - 1; ++index2)
          {
            Math.Round(OperationData.DepthSelectedValues[index1].Depth / (double) count * (double) index2, 5);
            double num11 = CalcValues[index2];
            camZHeight camZheight = new camZHeight();
            if (OperationData.PlaneSelectedName == planeNames.Top | OperationData.PlaneSelectedName == planeNames.Left)
              camZheight.Depth = Math.Round(num11, 5);
            if (OperationData.PlaneSelectedName == planeNames.Right | OperationData.PlaneSelectedName == planeNames.Left)
              camZheight.Depth = Math.Round(num11, 5);
            if (OperationData.PlaneSelectedName == planeNames.Free)
              camZheight.Depth = Math.Round(num11, 5);
            camZheight.Type = CamZHeightType.Contour;
            if (camParMilling.Operations.FinishEnable)
              camZheight.Type = CamZHeightType.Finish;
            if (camParMilling.Operations.AreaClearanceEnable)
              camZheight.Type = CamZHeightType.AreaClearance;
            if (index2 == CalcValues.Count - 1)
              camZheight.FinalStep = true;
            RefList.Add(camZheight);
          }
        }
      }
      if (OperationData.PlaneSelectedName == planeNames.Top | OperationData.PlaneSelectedName == planeNames.Left && RefList.Count > 0)
        buAppCalc.cVector.SortList(SortDirectionType.Bigger, ref RefList);
      List<Pnt3D> pnt3DList2 = new List<Pnt3D>();
      List<List<Pnt3D>> pnt3DListList2 = new List<List<Pnt3D>>();
      if (Action == actionTypeBU.profileCircle & (OperationData.PlaneSelectedName == planeNames.Free | camParMilling.Strategy.ArcToPoints))
      {
        eCircle RefEntity = new eCircle(new Pnt3D(Pnt2), ((ProfileOperationCircle) P).Diameter / 2.0, new WorkPlane(), (float) Thickness, toolBase.Display.CamColor);
        buAppCalc.cVector.EntitiesToPoint((eEntities) RefEntity, this.EntityDevideResolution, ref pnt3DList2);
        eEntities eEntities2 = (eEntities) new ePolyline(pnt3DList2);
        eEntities2.LayerIndex = LayerIndex;
        BaseRefEntities.Add(eEntities2);
        pnt3DListList2.Add(pnt3DList2);
      }
      if (Action == actionTypeBU.profileRectangle)
      {
        Pnt3D Center = new Pnt3D(Pnt2);
        buAppCalc.cVector.RectangleAngleWithCenter(Center, ((ProfileOperationRectangle) P).Width, ((ProfileOperationRectangle) P).Height, ((ProfileOperationRectangle) P).Angle, new WorkPlane(), ref pnt3DList2);
        eEntities eEntities3 = (eEntities) new ePolyline(pnt3DList2);
        eEntities3.LayerIndex = LayerIndex;
        BaseRefEntities.Add(eEntities3);
        pnt3DListList2.Add(pnt3DList2);
      }
      if (Action == actionTypeBU.profileRoundRectangle)
      {
        Pnt3D Center = new Pnt3D(Pnt2);
        buAppCalc.cVector.RectangleFillet(Center, ((ProfileOperationRoundRectangle) P).Width, ((ProfileOperationRoundRectangle) P).Height, ((ProfileOperationRoundRectangle) P).Radius, ((ProfileOperationRoundRectangle) P).Angle, new WorkPlane(), ref pnt3DList2);
        eEntities eEntities4 = (eEntities) new ePolyline(pnt3DList2);
        eEntities4.LayerIndex = LayerIndex;
        BaseRefEntities.Add(eEntities4);
        pnt3DListList2.Add(pnt3DList2);
      }
      if (Action == actionTypeBU.profileSlot)
      {
        Pnt3D pnt3D2 = new Pnt3D(Pnt2);
        buAppCalc.cVector.RectangleFillet(pnt3D2, ((ProfileOperationSlot) P).Width, ((ProfileOperationSlot) P).Diameter, ((ProfileOperationSlot) P).Diameter / 2.0, ((ProfileOperationSlot) P).Angle, new WorkPlane(), ref pnt3DList2);
        eEntities eEntities5 = (eEntities) new ePolyline(pnt3DList2);
        eEntities5.LayerIndex = LayerIndex;
        BaseRefEntities.Add(eEntities5);
        if (Tool.Geometry.Diameter >= ((ProfileOperationSlot) P).Diameter)
        {
          pnt3DList2.Clear();
          Pnt3D StartPoint = new Pnt3D();
          Pnt3D EndPoint = new Pnt3D();
          buAppCalc.cVector.LineWithCenterPointByLengthAndAngle(pnt3D2, ((ProfileOperationSlot) P).Width / 2.0 - ((ProfileOperationSlot) P).Diameter / 2.0, ((ProfileOperationSlot) P).Angle, new WorkPlane(), ref StartPoint, ref EndPoint);
          pnt3DList2.Add(StartPoint);
          pnt3DList2.Add(EndPoint);
        }
        pnt3DListList2.Add(pnt3DList2);
      }
      if (Action == actionTypeBU.profileCut)
      {
        Pnt3D pnt3D3 = new Pnt3D(Pnt2);
        buAppCalc.cVector.RectangleAngleWithCenter(pnt3D3, ((ProfileOperationCut) P).CutWidth, ((ProfileOperationCut) P).CutHeight, ((ProfileOperationCut) P).Angle, new WorkPlane(), ref pnt3DList2);
        eEntities eEntities6 = (eEntities) new ePolyline(pnt3DList2);
        eEntities6.LayerIndex = LayerIndex;
        BaseRefEntities.Add(eEntities6);
        if (Tool.Geometry.Diameter >= ((ProfileOperationCut) P).CutWidth)
        {
          pnt3DList2.Clear();
          Pnt3D StartPoint = new Pnt3D();
          Pnt3D EndPoint = new Pnt3D();
          buAppCalc.cVector.LineWithCenterPointByLengthAndAngle(pnt3D3, ((ProfileOperationCut) P).CutWidth / 2.0 - ((ProfileOperationCut) P).CutHeight / 2.0, ((ProfileOperationCut) P).Angle + 90.0, new WorkPlane(), ref StartPoint, ref EndPoint);
          pnt3DList2.Add(StartPoint);
          pnt3DList2.Add(EndPoint);
        }
        pnt3DListList2.Add(pnt3DList2);
      }
      if (Action == actionTypeBU.profileBarrel)
      {
        Pnt3D HeadPosition = new Pnt3D(Pnt2);
        buAppCalc.cVector.Barrel(HeadPosition, ((ProfileOperationBarrel) P).Diameter / 2.0, ((ProfileOperationBarrel) P).Width / 2.0, ((ProfileOperationBarrel) P).Length, ((ProfileOperationBarrel) P).Angle, false, new WorkPlane(), buSystem.EntitiesResolution, ref pnt3DList2);
        eEntities eEntities7 = (eEntities) new ePolyline(pnt3DList2);
        eEntities7.LayerIndex = LayerIndex;
        BaseRefEntities.Add(eEntities7);
        pnt3DListList2.Add(pnt3DList2);
      }
      if (Action == actionTypeBU.profileEllipse)
      {
        Pnt3D Center = new Pnt3D(Pnt2);
        buAppCalc.cVector.EllipseWithCenter(Center, ((ProfileOperationEllipse) P).Width, ((ProfileOperationEllipse) P).Height, ((ProfileOperationEllipse) P).Angle, new WorkPlane(), buSystem.EntitiesResolution, ref pnt3DList2);
        eEntities eEntities8 = (eEntities) new ePolyline(pnt3DList2);
        eEntities8.LayerIndex = LayerIndex;
        BaseRefEntities.Add(eEntities8);
        pnt3DListList2.Add(pnt3DList2);
      }
      if (Action == actionTypeBU.profileHole)
      {
        if (OperationData.PlaneSelectedName != planeNames.Free)
        {
          Pnt3D pnt3D4 = new Pnt3D(Pnt2);
          pnt3DListList2.Add(new List<Pnt3D>()
          {
            new Pnt3D(pnt3D4)
          });
          eEntities eEntities9 = (eEntities) new eCircle(pnt3D4, OperationData.HoleData.HoleDiameter / 2.0, new WorkPlane());
          eEntities9.LayerIndex = LayerIndex;
          BaseRefEntities.Add(eEntities9);
        }
        else
        {
          Pnt3D pnt3D5 = new Pnt3D(Pnt2);
          eCircle RefEntity = new eCircle(pnt3D5, OperationData.HoleData.HoleDiameter / 2.0, new WorkPlane(), (float) Thickness, toolBase.Display.CamColor);
          buAppCalc.cVector.EntitiesToPoint((eEntities) RefEntity, this.EntityDevideResolution, ref pnt3DList2);
          eEntities eEntities10 = (eEntities) new ePolyline(pnt3DList2);
          eEntities10.LayerIndex = LayerIndex;
          BaseRefEntities.Add(eEntities10);
          pnt3DListList2.Add(new List<Pnt3D>()
          {
            new Pnt3D(pnt3D5)
          });
          pnt3DList2 = new List<Pnt3D>();
        }
      }
      if (Action == actionTypeBU.profileFreeDraw)
      {
        for (int index3 = 0; index3 <= TempData.SortedAndScaledAndRotatedEntitiesPointsList.Count - 1; ++index3)
        {
          pnt3DList2 = new List<Pnt3D>();
          for (int index4 = 0; index4 <= TempData.SortedAndScaledAndRotatedEntitiesPointsList[index3].Count - 1; ++index4)
          {
            Pnt3D pnt3D6 = new Pnt3D(TempData.SortedAndScaledAndRotatedEntitiesPointsList[index3][index4].X, TempData.SortedAndScaledAndRotatedEntitiesPointsList[index3][index4].Y, TempData.SortedAndScaledAndRotatedEntitiesPointsList[index3][index4].Z);
            pnt3DList2.Add(pnt3D6);
          }
          if (buAppCalc.cVector.IsClosed(pnt3DList2))
          {
            eEntities eEntities11 = (eEntities) new ePolyline(pnt3DList2);
            eEntities11.LayerIndex = LayerIndex;
            BaseRefEntities.Add(eEntities11);
          }
          else
          {
            eEntities eEntities12 = (eEntities) new ePolyline(pnt3DList2);
            eEntities12.LayerIndex = LayerIndex;
            BaseRefEntities.Add(eEntities12);
          }
          pnt3DListList2.Add(pnt3DList2);
        }
      }
      if (Action == actionTypeBU.profileText)
      {
        for (int index5 = 0; index5 <= TempData.SortedAndScaledAndRotatedEntitiesPointsList.Count - 1; ++index5)
        {
          pnt3DList2 = new List<Pnt3D>();
          for (int index6 = 0; index6 <= TempData.SortedAndScaledAndRotatedEntitiesPointsList[index5].Count - 1; ++index6)
          {
            Pnt3D pnt3D7 = new Pnt3D(TempData.SortedAndScaledAndRotatedEntitiesPointsList[index5][index6].X, TempData.SortedAndScaledAndRotatedEntitiesPointsList[index5][index6].Y, TempData.SortedAndScaledAndRotatedEntitiesPointsList[index5][index6].Z);
            pnt3DList2.Add(pnt3D7);
          }
          buAppCalc.cVector.IsClosed(pnt3DList2);
          eEntities eEntities13 = (eEntities) new ePolyline(pnt3DList2);
          eEntities13.LayerIndex = LayerIndex;
          BaseRefEntities.Add(eEntities13);
          List<Pnt3D> CopiedPnt = new List<Pnt3D>();
          Pnt3D.Copy(pnt3DList2, ref CopiedPnt);
          pnt3DListList2.Add(CopiedPnt);
          pnt3DList2.Clear();
        }
      }
      if (camParMilling.Offsets.ClosedContour == CamClosedContourType.Center)
        camParMilling.Operations.MakeCenterOffset = true;
      if (RefList.Count == 0)
        RefList.Add(new camZHeight()
        {
          Depth = 0.0,
          Type = CamZHeightType.Contour
        });
      List<eEntities> SortedEntities = new List<eEntities>();
      List<List<eEntities>> SplitedEntitites = new List<List<eEntities>>();
      buAppCalc.cSort.SortEntitiesByRefPoint(new Pnt3D(), ref BaseRefEntities, new SortingOptions(), ref SortedEntities);
      buAppCalc.cVector.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
      if (RefList.Count > 0)
      {
        for (int index7 = 0; index7 <= RefList.Count - 1; ++index7)
        {
          Pnt3D MinPoint = new Pnt3D();
          Pnt3D MaxPoint = new Pnt3D();
          buAppCalc.cVector.BoxSizeCalculate(BaseRefEntities, ref MinPoint, ref MaxPoint);
          for (int index8 = 0; index8 <= SplitedEntitites.Count - 1; ++index8)
          {
            List<eEntities> eEntitiesList = new List<eEntities>();
            for (int index9 = 0; index9 <= SplitedEntitites[index8].Count - 1; ++index9)
            {
              eEntities baseEnt = new eEntities();
              eEntities.CopyEntity(SplitedEntitites[index8][index9], ref baseEnt);
              buAppCalc.cVector.Move(new Pnt3D(0.0, 0.0, MinPoint.Z), new Pnt3D(0.0, 0.0, RefList[index7].Depth), ref baseEnt);
              eEntitiesList.Add(eEntities.CopyEntity(baseEnt));
              CadEntities.Add(eEntities.CopyEntity(baseEnt));
            }
            if (eEntitiesList.Count > 0)
              P.Entities.Add(eEntitiesList);
          }
        }
      }
      else
      {
        for (int index10 = 0; index10 <= SplitedEntitites.Count - 1; ++index10)
        {
          List<eEntities> eEntitiesList = new List<eEntities>();
          for (int index11 = 0; index11 <= SplitedEntitites[index10].Count - 1; ++index11)
          {
            eEntities copiedEnt = new eEntities();
            eEntities.CopyEntity(SplitedEntitites[index10][index11], ref copiedEnt);
            eEntitiesList.Add(eEntities.CopyEntity(copiedEnt));
            CadEntities.Add(eEntities.CopyEntity(copiedEnt));
          }
          if (eEntitiesList.Count > 0)
            P.Entities.Add(eEntitiesList);
        }
      }
      CamCalc.Name = "Profile -" + P.Name;
      Pnt9DCam Pnt3 = new Pnt9DCam();
      Pnt3D pnt3D8 = new Pnt3D();
      Pnt3D RefP2 = new Pnt3D();
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = true;
      if (Action == actionTypeBU.profileCircle & OperationData.PlaneSelectedName != planeNames.Free & !camParMilling.Strategy.ArcToPoints)
      {
        for (int index12 = 0; index12 <= RefList.Count - 1; ++index12)
        {
          CamPoint camPoint2 = new CamPoint();
          camPoint2.GCodeOffset = new Pnt9D(Pnt1);
          eCircle ent = new eCircle(new Pnt3D(Pnt2.X, Pnt2.Y, RefList[index12].Depth), ((ProfileOperationCircle) P).Diameter / 2.0, new WorkPlane(), (float) Thickness, toolBase.Display.CamColor);
          ent.LayerIndex = LayerIndex;
          P.Entities.Add(new List<eEntities>()
          {
            (eEntities) new eCircle((eEntities) ent)
          });
          CadEntities.Add((eEntities) new eCircle((eEntities) ent));
          if (camParMilling.Operations.Direction == ClockDirectionType.CCW | camParMilling.Operations.Direction == ClockDirectionType.CW)
          {
            if (index12 == 0)
            {
              camPoint2.Points.Add(new Pnt9DCam(new Pnt6D(ent.CenterPoint.X + ent.Radius - toolBase.Geometry.Diameter / 2.0, ent.CenterPoint.Y, z1), camParMilling.Speeds.Rapid, 0)
              {
                PlungeAction = CamPlungeActionType.GoUpFirstPoint,
                PlungeAxis = "Z",
                PlungeAxisMovement = true,
                PlungeValue = num9,
                Feed = camParMilling.Speeds.Rapid
              });
              Pnt3 = new Pnt9DCam(new Pnt6D(ent.CenterPoint.X + ent.Radius - toolBase.Geometry.Diameter / 2.0, ent.CenterPoint.Y, z1), camParMilling.Speeds.Rapid, 0);
              geoLine geoLine = new geoLine(new Pnt3D(Pnt3.P9.X, Pnt3.P9.Y, z1), new Pnt3D(Pnt3.P9.X, Pnt3.P9.Y, RefList[index12].Depth), -1);
              geoLine.Color = Tool.Display.PlungeColor;
              geoLine.Thickness = Thickness;
              Pnt3.Type = 0;
              Pnt3.Feed = camParMilling.Speeds.Rapid;
              camPoint2.Points.Add(Pnt3);
            }
            if (camParMilling.Operations.AreaClearanceDirection == InToOutType.InToOut & camParMilling.Operations.AreaClearanceEnable)
              doubleList.Reverse();
            for (int index13 = 0; index13 <= doubleList.Count - 1; ++index13)
            {
              if (index13 == 0)
                camPoint2.Points.Add(new Pnt9DCam()
                {
                  P9 = new Pnt9D(new Pnt3D(ent.CenterPoint.X + doubleList[index13] - toolBase.Geometry.Diameter / 2.0, ent.CenterPoint.Y, ent.CenterPoint.Z)),
                  Type = 1,
                  Feed = num4
                });
              if (index13 > 0)
              {
                camPoint2.Points.Add(new Pnt9DCam()
                {
                  P9 = new Pnt9D(new Pnt3D(ent.CenterPoint.X + doubleList[index13] - toolBase.Geometry.Diameter / 2.0, ent.CenterPoint.Y, ent.CenterPoint.Z)),
                  Type = 1,
                  Feed = num1
                });
                geoLine geoLine = new geoLine(pnt3D8, new Pnt3D(ent.CenterPoint.X + doubleList[index13] - toolBase.Geometry.Diameter / 2.0, ent.CenterPoint.Y, ent.CenterPoint.Z));
                geoLine.Color = OperationData.CircleData.CircleColor;
                geoLine.Thickness = OperationData.CircleData.CircleThickness;
              }
              Pnt9DCam pnt9Dcam = new Pnt9DCam();
              pnt9Dcam.P9 = new Pnt9D(new Pnt3D(ent.CenterPoint.X - doubleList[index13] + toolBase.Geometry.Diameter / 2.0, ent.CenterPoint.Y, ent.CenterPoint.Z));
              pnt9Dcam.ArcData = new geoArc(ent.CenterPoint, doubleList[index13], 0.0, 180.0);
              if (camParMilling.Operations.Direction == ClockDirectionType.CW)
                pnt9Dcam.Type = 2;
              if (camParMilling.Operations.Direction == ClockDirectionType.CCW)
                pnt9Dcam.Type = 3;
              pnt9Dcam.Feed = num1;
              pnt9Dcam.IsArc = true;
              camPoint2.Points.Add(pnt9Dcam);
              Pnt3 = new Pnt9DCam();
              Pnt3.P9 = new Pnt9D(new Pnt3D(ent.CenterPoint.X + doubleList[index13] - toolBase.Geometry.Diameter / 2.0, ent.CenterPoint.Y, ent.CenterPoint.Z));
              Pnt3.ArcData = new geoArc(ent.CenterPoint, doubleList[index13], 180.0, 360.0);
              if (camParMilling.Operations.Direction == ClockDirectionType.CW)
                Pnt3.Type = 2;
              if (camParMilling.Operations.Direction == ClockDirectionType.CCW)
                Pnt3.Type = 3;
              Pnt3.IsArc = true;
              Pnt3.Feed = num1;
              camPoint2.Points.Add(Pnt3);
              pnt3D8 = new Pnt3D(Pnt3.P9);
              geoCircle geoCircle = new geoCircle(ent.CenterPoint, doubleList[index13] - toolBase.Geometry.Diameter / 2.0, new WorkPlane());
              geoCircle.Color = OperationData.CircleData.CircleColor;
              geoCircle.Thickness = OperationData.CircleData.CircleThickness;
              camPoint2.EntitiesG1.Add((geoEntity) geoCircle);
              if (camParMilling.Operations.Direction == ClockDirectionType.CCW)
                this.SimPointCreatForDetailedPoints(camPoint2.Points, 0.25, 0.1, 3.0, ref camPoint2.SimilationPoint);
              if (camParMilling.Operations.Direction == ClockDirectionType.CW)
              {
                List<Pnt3D> CopiedPnt = new List<Pnt3D>();
                Pnt3D.Copy(geoCircle.Vertice, ref CopiedPnt);
                CopiedPnt.Reverse();
                this.SimPointCreatForDetailedPoints(camPoint2.Points, 0.25, 0.1, 3.0, ref camPoint2.SimilationPoint);
              }
            }
          }
          if (index12 == RefList.Count - 1)
          {
            Pnt3 = new Pnt9DCam(new Pnt6D(0.0, 0.0, z1), camParMilling.Speeds.Rapid, 0);
            Pnt3.PlungeAction = CamPlungeActionType.GoUpLastPoint;
            Pnt3.PlungeAxis = "Z";
            Pnt3.PlungeAxisMovement = true;
            Pnt3.PlungeValue = num9;
            geoLine geoLine = new geoLine(new Pnt3D(pnt3D8), new Pnt3D(pnt3D8.X, pnt3D8.Y, z1), -1);
            geoLine.Color = Tool.Display.LeaveColor;
            geoLine.Thickness = Thickness;
            camPoint2.EntitiesG0.Add((geoEntity) geoLine);
            Pnt3.PlungeAxisMovement = true;
            camPoint2.Points.Add(Pnt3);
          }
          CamCalc.CamPoints.Add(camPoint2);
          CamCalc.Tool = new ToolBase(toolBase);
        }
      }
      for (int index14 = 0; index14 <= pnt3DListList2.Count - 1; ++index14)
      {
        CamPoint camPoint3 = new CamPoint();
        bool flag4 = false;
        if (index14 < pnt3DListList2.Count - 1)
        {
          List<List<Pnt3D>> pntCalculated = new List<List<Pnt3D>>();
          this.ProfileContourOffsets(pnt3DListList2[index14 + 1], 0.0, camParMilling, toolBase, OperationCamType, ref pntCalculated);
          if (pntCalculated.Count > 0 && pntCalculated[0].Count > 0)
          {
            flag4 = true;
            RefP2 = new Pnt3D(pntCalculated[0][0]);
          }
        }
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        Pnt3D.Copy(pnt3DListList2[index14], ref CopiedPnt);
        for (int index15 = 0; index15 <= RefList.Count - 1; ++index15)
        {
          List<List<Pnt3D>> pntCalculated = new List<List<Pnt3D>>();
          double ExtraOffset = 0.0;
          if (camParMilling.Operations.FinishEnable && camParMilling.Steps.Enable && !RefList[index15].FinalStep)
            ExtraOffset = camParMilling.Offsets.FinishOffset;
          bool flag5 = buAppCalc.cVector.IsClosed(pnt3DListList2[index14]);
          this.ProfileContourOffsets(pnt3DListList2[index14], ExtraOffset, camParMilling, toolBase, OperationCamType, ref pntCalculated);
          if (!flag5 & camParMilling.Strategy.OpenContourTwoDirectionCut && index15 % 2 == 1)
          {
            for (int index16 = 0; index16 <= pntCalculated.Count - 1; ++index16)
              pntCalculated[index16].Reverse();
          }
          int type = (int) RefList[index15].Type;
          camPoint3.GCodeOffset = new Pnt9D(Pnt1);
          for (int index17 = 0; index17 <= pntCalculated.Count - 1; ++index17)
          {
            List<Pnt3D> pnt3DList3 = new List<Pnt3D>();
            for (int index18 = 0; index18 <= pntCalculated[index17].Count - 1; ++index18)
            {
              Pnt3D pnt3D9 = new Pnt3D(pntCalculated[index17][index18].X, pntCalculated[index17][index18].Y, RefList[index15].Depth);
              pnt3DList3.Add(pnt3D9);
            }
            if (buAppCalc.cVector.IsClosed(pnt3DList3) & flag3 && buAppCalc.cVector.PolygonDirection(pnt3DList3, Plane) != camParMilling.Operations.Direction)
              pnt3DList3.Reverse();
            if (index14 == 0 & index15 > 0 | index14 > 0 && !Pnt3D.EqualXY(pnt3D8, pntCalculated[index17][0]))
              flag2 = true;
            if (index14 == 0 & index15 == 0 | flag2)
            {
              if (OperationData.PlaneSelectedName == planeNames.Top | OperationData.PlaneSelectedName == planeNames.Free)
              {
                camPoint3.Points.Add(new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), camParMilling.Speeds.Rapid, 0)
                {
                  Type = 0,
                  Feed = camParMilling.Speeds.Rapid,
                  SpindleSpeed = Tool.CamData.SpindleSpeed,
                  ToolNo = (double) Tool.Data.No,
                  EnableAxes = {
                    Z = false
                  }
                });
                camPoint3.Points.Add(new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), camParMilling.Speeds.Rapid, 0)
                {
                  PlungeAction = CamPlungeActionType.GoUpFirstPoint,
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true,
                  SpindleSpeed = Tool.CamData.SpindleSpeed,
                  PlungeValue = num9,
                  ToolNo = (double) Tool.Data.No
                });
                Pnt3 = new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z2), camParMilling.Speeds.Rapid, 0);
                Pnt3.PlungeAction = CamPlungeActionType.GoDownAproach;
                Pnt3.PlungeAxis = "Z";
                Pnt3.PlungeAxisMovement = true;
                Pnt3.PlungeValue = num8;
                Pnt3.SpindleSpeed = Tool.CamData.SpindleSpeed;
                Pnt3.ToolNo = (double) Tool.Data.No;
                camPoint3.Points.Add(Pnt3);
                geoLine geoLine = new geoLine(new Pnt3D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), new Pnt3D(pnt3DList3[0].X, pnt3DList3[0].Y, RefList[index15].Depth), -1);
                geoLine.Color = Tool.Display.PlungeColor;
                geoLine.Thickness = Thickness;
                camPoint3.EntitiesPlunge.Add((geoEntity) geoLine);
              }
              if (OperationData.PlaneSelectedName == planeNames.Right)
              {
                camPoint3.Points.Add(new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), camParMilling.Speeds.Rapid, 0)
                {
                  PlungeAction = CamPlungeActionType.GoUpFirstPoint,
                  PlungeAxis = "Y",
                  PlungeAxisMovement = true,
                  SpindleSpeed = Tool.CamData.SpindleSpeed,
                  PlungeValue = num9,
                  ToolNo = (double) Tool.Data.No
                });
                camPoint3.Points.Add(new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), camParMilling.Speeds.Rapid, 0)
                {
                  Type = 0,
                  Feed = camParMilling.Speeds.Rapid,
                  SpindleSpeed = Tool.CamData.SpindleSpeed,
                  ToolNo = (double) Tool.Data.No,
                  EnableAxes = {
                    Y = false
                  }
                });
                Pnt3 = new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z2), camParMilling.Speeds.Rapid, 0);
                Pnt3.PlungeAction = CamPlungeActionType.GoDownAproach;
                Pnt3.PlungeAxis = "Y";
                Pnt3.PlungeAxisMovement = true;
                Pnt3.PlungeValue = num8;
                Pnt3.SpindleSpeed = Tool.CamData.SpindleSpeed;
                Pnt3.ToolNo = (double) Tool.Data.No;
                camPoint3.Points.Add(Pnt3);
                geoLine geoLine = new geoLine(new Pnt3D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), new Pnt3D(pnt3DList3[0].X, pnt3DList3[0].Y, RefList[index15].Depth), -1);
                geoLine.Color = Tool.Display.PlungeColor;
                geoLine.Thickness = Thickness;
                camPoint3.EntitiesPlunge.Add((geoEntity) geoLine);
              }
              if (OperationData.PlaneSelectedName == planeNames.Left)
              {
                camPoint3.Points.Add(new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), camParMilling.Speeds.Rapid, 0)
                {
                  PlungeAction = CamPlungeActionType.GoUpFirstPoint,
                  PlungeAxis = "Y",
                  PlungeAxisMovement = true,
                  SpindleSpeed = Tool.CamData.SpindleSpeed,
                  PlungeValue = num9,
                  ToolNo = (double) Tool.Data.No
                });
                camPoint3.Points.Add(new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), camParMilling.Speeds.Rapid, 0)
                {
                  Type = 0,
                  Feed = camParMilling.Speeds.Rapid,
                  SpindleSpeed = Tool.CamData.SpindleSpeed,
                  ToolNo = (double) Tool.Data.No,
                  EnableAxes = {
                    Y = false
                  }
                });
                Pnt3 = new Pnt9DCam(new Pnt6D(pnt3DList3[0].X, pnt3DList3[0].Y, z2), camParMilling.Speeds.Rapid, 0);
                Pnt3.PlungeAction = CamPlungeActionType.GoDownAproach;
                Pnt3.PlungeAxis = "Y";
                Pnt3.PlungeAxisMovement = true;
                Pnt3.PlungeValue = num8;
                Pnt3.SpindleSpeed = Tool.CamData.SpindleSpeed;
                Pnt3.ToolNo = (double) Tool.Data.No;
                camPoint3.Points.Add(Pnt3);
                geoLine geoLine = new geoLine(new Pnt3D(pnt3DList3[0].X, pnt3DList3[0].Y, z1), new Pnt3D(pnt3DList3[0].X, pnt3DList3[0].Y, RefList[index15].Depth), -1);
                geoLine.Color = Tool.Display.PlungeColor;
                geoLine.Thickness = Thickness;
                camPoint3.EntitiesPlunge.Add((geoEntity) geoLine);
              }
              flag1 = true;
              flag2 = false;
            }
            for (int index19 = 0; index19 <= pnt3DList3.Count - 1; ++index19)
            {
              double feed = num1;
              if (flag1)
                feed = num4;
              if (Action == actionTypeBU.profileHole)
                feed = num4;
              if (OperationCamType == CamZHeightType.Finish & index15 == RefList.Count - 1)
                feed = num2;
              Pnt3 = new Pnt9DCam(new Pnt6D(pnt3DList3[index19]), feed, 1);
              Pnt3.Type = 1;
              Pnt3.Feed = feed;
              Pnt3.SpindleSpeed = Tool.CamData.SpindleSpeed;
              Pnt3.ToolNo = (double) Tool.Data.No;
              camPoint3.Points.Add(Pnt3);
              pnt3D8 = new Pnt3D(Pnt3);
              flag1 = false;
            }
            if (pnt3DList3.Count >= 2)
            {
              geoPolyline geoPolyline = new geoPolyline(pnt3DList3, -1);
              geoPolyline.Color = Tool.Display.CamColor;
              geoPolyline.Thickness = Thickness;
              camPoint3.EntitiesG1.Add((geoEntity) geoPolyline);
            }
          }
        }
        if (flag4 && OperationData.PlaneSelectedName == planeNames.Top | OperationData.PlaneSelectedName == planeNames.Bottom && !Pnt3D.EqualXY(pnt3D8, RefP2))
          flag2 = true;
        if (!flag4 | flag2)
        {
          if (OperationData.PlaneSelectedName == planeNames.Top | OperationData.PlaneSelectedName == planeNames.Bottom)
          {
            Pnt3 = new Pnt9DCam(new Pnt6D(pnt3D8.X, pnt3D8.Y, z1), camParMilling.Speeds.Rapid, 0);
            Pnt3.PlungeAxis = "Z";
            Pnt3.PlungeAction = CamPlungeActionType.GoUpLastPoint;
            Pnt3.PlungeAxisMovement = true;
            Pnt3.PlungeValue = num9;
            Pnt3.SpindleSpeed = Tool.CamData.SpindleSpeed;
            Pnt3.ToolNo = (double) Tool.Data.No;
            geoLine geoLine = new geoLine(new Pnt3D(pnt3D8), new Pnt3D(pnt3D8.X, pnt3D8.Y, z1), -1);
            geoLine.Color = Tool.Display.LeaveColor;
            geoLine.Thickness = Thickness;
            camPoint3.EntitiesG0.Add((geoEntity) geoLine);
          }
          if (OperationData.PlaneSelectedName == planeNames.Left)
          {
            Pnt3 = new Pnt9DCam(new Pnt6D(pnt3D8.X, pnt3D8.Y, z1), camParMilling.Speeds.Rapid, 0);
            Pnt3.PlungeAxis = "Y";
            Pnt3.PlungeAction = CamPlungeActionType.GoUpLastPoint;
            Pnt3.PlungeAxisMovement = true;
            Pnt3.SpindleSpeed = Tool.CamData.SpindleSpeed;
            Pnt3.PlungeValue = num9;
            Pnt3.ToolNo = (double) Tool.Data.No;
            geoLine geoLine = new geoLine(new Pnt3D(pnt3D8), new Pnt3D(pnt3D8.X, pnt3D8.Y, z1), -1);
            geoLine.Color = Tool.Display.LeaveColor;
            geoLine.Thickness = Thickness;
            camPoint3.EntitiesG0.Add((geoEntity) geoLine);
          }
          if (OperationData.PlaneSelectedName == planeNames.Right)
          {
            Pnt3 = new Pnt9DCam(new Pnt6D(pnt3D8.X, pnt3D8.Y, z1), camParMilling.Speeds.Rapid, 0);
            Pnt3.PlungeAxis = "Y";
            Pnt3.PlungeAction = CamPlungeActionType.GoUpLastPoint;
            Pnt3.PlungeAxisMovement = true;
            Pnt3.PlungeValue = num9;
            Pnt3.SpindleSpeed = Tool.CamData.SpindleSpeed;
            Pnt3.ToolNo = (double) Tool.Data.No;
            geoLine geoLine = new geoLine(new Pnt3D(pnt3D8), new Pnt3D(pnt3D8.X, pnt3D8.Y, z1), -1);
            geoLine.Color = Tool.Display.LeaveColor;
            geoLine.Thickness = Thickness;
            camPoint3.EntitiesG0.Add((geoEntity) geoLine);
          }
          if (OperationData.PlaneSelectedName == planeNames.Free)
          {
            Pnt3 = new Pnt9DCam(new Pnt6D(pnt3D8.X, pnt3D8.Y, z1), camParMilling.Speeds.Rapid, 0);
            Pnt3.PlungeAction = CamPlungeActionType.GoUpLastPoint;
            Pnt3.PlungeAxis = "";
            Pnt3.PlungeAxisMovement = false;
            Pnt3.PlungeValue = num9;
            Pnt3.SpindleSpeed = Tool.CamData.SpindleSpeed;
            Pnt3.ToolNo = (double) Tool.Data.No;
            geoLine geoLine = new geoLine(new Pnt3D(pnt3D8), new Pnt3D(pnt3D8.X, pnt3D8.Y, z1), -1);
            geoLine.Color = Tool.Display.LeaveColor;
            geoLine.Thickness = Thickness;
            camPoint3.EntitiesG0.Add((geoEntity) geoLine);
          }
          camPoint3.Points.Add(Pnt3);
          flag1 = true;
        }
        for (int index20 = 0; index20 <= camPoint3.Points.Count - 1; ++index20)
        {
          if (camPoint3.Points[index20].Type == 1 && index20 > 0)
          {
            double num12 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint3.Points[index20 - 1]), new Pnt3D(camPoint3.Points[index20]));
            CamCalc.TotalOperationTimeSec += num12 / camPoint3.Points[index20].Feed;
            CamCalc.TotalOperationG1Distance += num12;
          }
          if (camPoint3.Points[index20].Type == 0)
          {
            if (index20 == 0)
            {
              double num13 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint3.Points[index20]), new Pnt3D(camPoint3.Points[index20 + 1]));
              CamCalc.TotalOperationG0Distance += num13;
            }
            else
            {
              double num14 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint3.Points[index20 - 1]), new Pnt3D(camPoint3.Points[index20]));
              CamCalc.TotalOperationG0Distance += num14;
            }
          }
        }
        CamCalc.TotalOperationDistance = CamCalc.TotalOperationG0Distance + CamCalc.TotalOperationG1Distance;
        this.SimPointCreatForDetailedPoints(camPoint3.Points, 0.25, 0.1, 3.0, ref camPoint3.SimilationPoint);
        CamCalc.CamPoints.Add(camPoint3);
        CamCalc.Tool = new ToolBase(toolBase);
      }
      P.SelectedPlane = OperationData.PlaneSelectedName;
      P.CamParMilling = new camParameters(camParMilling);
      P.Tool = new ToolBase(toolBase);
      P.OperationData = new ProfileOperationData(OperationData);
      P.CamCalculation.Add(new camBase(CamCalc));
      return 1;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return -1;
    }
  }

  public int ProfileOperationRotateAccordingToPlane(
    ref ProfileOperation P,
    ref List<eEntities> CadEntities,
    ref camBase CamCalc,
    WorkPlane Plane,
    ProfileOperationData OperationData,
    KinematicBase Kinematic)
  {
    try
    {
      if (OperationData.PlaneSelectedName == planeNames.Top)
      {
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.Entities);
        for (int index1 = 0; index1 <= P.CamCalculation.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= P.CamCalculation[index1].CamPoints.Count - 1; ++index2)
          {
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[index1].CamPoints[index2].EntitiesG0);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[index1].CamPoints[index2].EntitiesG1);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[index1].CamPoints[index2].EntitiesLeadIn);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[index1].CamPoints[index2].EntitiesLeadOut);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[index1].CamPoints[index2].EntitiesLeave);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[index1].CamPoints[index2].EntitiesMark);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[index1].CamPoints[index2].EntitiesOther);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[index1].CamPoints[index2].EntitiesPlunge);
            for (int index3 = 0; index3 <= P.CamCalculation[index1].CamPoints[index2].EntitiesG1.Count - 1; ++index3)
            {
              eEntities EEntity = new eEntities();
              geoEntity.GeoEntitiyToEEntity(P.CamCalculation[index1].CamPoints[index2].EntitiesG1[index3], ref EEntity);
              P.AuxEntities.Add(EEntity);
            }
            for (int index4 = 0; index4 <= P.CamCalculation[index1].CamPoints[index2].SimilationPoint.SimDetailedPoints.Count - 1; ++index4)
            {
              Pnt6DSim Point = new Pnt6DSim(P.CamCalculation[index1].CamPoints[index2].SimilationPoint.SimDetailedPoints[index4]);
              buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref Point);
              Point.A = 0.0;
              P.CamCalculation[index1].CamPoints[index2].SimilationPoint.SimDetailedPoints[index4] = Point;
            }
            for (int index5 = 0; index5 <= P.CamCalculation[index1].CamPoints[index2].Points.Count - 1; ++index5)
            {
              Pnt9D Point = new Pnt9D(P.CamCalculation[index1].CamPoints[index2].Points[index5].P9);
              buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref Point);
              Point.A = 0.0;
              if (P.CamCalculation[index1].CamPoints[index2].Points[index5].PlungeAxisMovement)
                P.CamCalculation[index1].CamPoints[index2].Points[index5].PlungeAxis = "Z";
              P.CamCalculation[index1].CamPoints[index2].Points[index5].P9 = Point;
            }
          }
        }
      }
      if (OperationData.PlaneSelectedName == planeNames.Left)
      {
        double Angle = -90.0;
        buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.Entities);
        buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.Entities);
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.Entities);
        for (int index6 = 0; index6 <= P.CamCalculation.Count - 1; ++index6)
        {
          for (int index7 = 0; index7 <= P.CamCalculation[index6].CamPoints.Count - 1; ++index7)
          {
            buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[index6].CamPoints[index7].EntitiesG0);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index6].CamPoints[index7].EntitiesG0);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index6].CamPoints[index7].EntitiesG0);
            buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[index6].CamPoints[index7].EntitiesG1);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index6].CamPoints[index7].EntitiesG1);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index6].CamPoints[index7].EntitiesG1);
            buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeadIn);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeadIn);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeadIn);
            buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeadOut);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeadOut);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeadOut);
            buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeave);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeave);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index6].CamPoints[index7].EntitiesLeave);
            buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[index6].CamPoints[index7].EntitiesMark);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index6].CamPoints[index7].EntitiesMark);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index6].CamPoints[index7].EntitiesMark);
            buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[index6].CamPoints[index7].EntitiesOther);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index6].CamPoints[index7].EntitiesOther);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index6].CamPoints[index7].EntitiesOther);
            buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[index6].CamPoints[index7].EntitiesPlunge);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index6].CamPoints[index7].EntitiesPlunge);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index6].CamPoints[index7].EntitiesPlunge);
            for (int index8 = 0; index8 <= P.CamCalculation[index6].CamPoints[index7].EntitiesG1.Count - 1; ++index8)
            {
              eEntities EEntity = new eEntities();
              geoEntity.GeoEntitiyToEEntity(P.CamCalculation[index6].CamPoints[index7].EntitiesG1[index8], ref EEntity);
              P.AuxEntities.Add(EEntity);
            }
            for (int index9 = 0; index9 <= P.CamCalculation[index6].CamPoints[index7].SimilationPoint.SimDetailedPoints.Count - 1; ++index9)
            {
              Pnt6DSim pnt6Dsim = new Pnt6DSim(P.CamCalculation[index6].CamPoints[index7].SimilationPoint.SimDetailedPoints[index9]);
              buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref pnt6Dsim);
              buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref pnt6Dsim);
              buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref pnt6Dsim);
              pnt6Dsim.A = Angle;
              P.CamCalculation[index6].CamPoints[index7].SimilationPoint.SimDetailedPoints[index9] = pnt6Dsim;
            }
            for (int index10 = 0; index10 <= P.CamCalculation[index6].CamPoints[index7].Points.Count - 1; ++index10)
            {
              Pnt9D pnt9D = new Pnt9D(P.CamCalculation[index6].CamPoints[index7].Points[index10].P9);
              buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref pnt9D);
              buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref pnt9D);
              buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref pnt9D);
              pnt9D.A = Angle;
              if (P.CamCalculation[index6].CamPoints[index7].Points[index10].PlungeAxisMovement)
                P.CamCalculation[index6].CamPoints[index7].Points[index10].PlungeAxis = "Y";
              P.CamCalculation[index6].CamPoints[index7].Points[index10].P9 = pnt9D;
            }
          }
        }
      }
      if (OperationData.PlaneSelectedName == planeNames.Right)
      {
        double Angle = -90.0;
        buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.Entities);
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.Entities);
        for (int index11 = 0; index11 <= P.CamCalculation.Count - 1; ++index11)
        {
          for (int index12 = 0; index12 <= P.CamCalculation[index11].CamPoints.Count - 1; ++index12)
          {
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index11].CamPoints[index12].EntitiesG0);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index11].CamPoints[index12].EntitiesG0);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index11].CamPoints[index12].EntitiesG1);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index11].CamPoints[index12].EntitiesG1);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index11].CamPoints[index12].EntitiesLeadIn);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index11].CamPoints[index12].EntitiesLeadIn);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index11].CamPoints[index12].EntitiesLeadOut);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index11].CamPoints[index12].EntitiesLeadOut);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index11].CamPoints[index12].EntitiesLeave);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index11].CamPoints[index12].EntitiesLeave);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index11].CamPoints[index12].EntitiesMark);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index11].CamPoints[index12].EntitiesMark);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index11].CamPoints[index12].EntitiesOther);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index11].CamPoints[index12].EntitiesOther);
            buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index11].CamPoints[index12].EntitiesPlunge);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[index11].CamPoints[index12].EntitiesPlunge);
            for (int index13 = 0; index13 <= P.CamCalculation[index11].CamPoints[index12].EntitiesG1.Count - 1; ++index13)
            {
              eEntities EEntity = new eEntities();
              geoEntity.GeoEntitiyToEEntity(P.CamCalculation[index11].CamPoints[index12].EntitiesG1[index13], ref EEntity);
              P.AuxEntities.Add(EEntity);
            }
            for (int index14 = 0; index14 <= P.CamCalculation[index11].CamPoints[index12].SimilationPoint.SimDetailedPoints.Count - 1; ++index14)
            {
              Pnt6DSim pnt6Dsim = new Pnt6DSim(P.CamCalculation[index11].CamPoints[index12].SimilationPoint.SimDetailedPoints[index14]);
              buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref pnt6Dsim);
              buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref pnt6Dsim);
              pnt6Dsim.A = -Angle;
              P.CamCalculation[index11].CamPoints[index12].SimilationPoint.SimDetailedPoints[index14] = pnt6Dsim;
            }
            for (int index15 = 0; index15 <= P.CamCalculation[index11].CamPoints[index12].Points.Count - 1; ++index15)
            {
              Pnt9D pnt9D = new Pnt9D(P.CamCalculation[index11].CamPoints[index12].Points[index15].P9);
              buAppCalc.cVector.Rotate(new Pnt3D(), Angle, new WorkPlane(planeType.YZ, 1), ref pnt9D);
              buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref pnt9D);
              pnt9D.A = -Angle;
              if (P.CamCalculation[index11].CamPoints[index12].Points[index15].PlungeAxisMovement)
                P.CamCalculation[index11].CamPoints[index12].Points[index15].PlungeAxis = "Y";
              P.CamCalculation[index11].CamPoints[index12].Points[index15].P9 = pnt9D;
            }
          }
        }
      }
      if (OperationData.PlaneSelectedName == planeNames.Free)
      {
        double a = Plane.Angles.A;
        eEntities.CopyEntities(P.Entities, ref P.NoRotatedEntities);
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.NoRotatedEntities);
        buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.Entities);
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.Entities);
        for (int index16 = 0; index16 <= P.CamCalculation.Count - 1; ++index16)
        {
          for (int index17 = 0; index17 <= P.CamCalculation[index16].CamPoints.Count - 1; ++index17)
          {
            buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index16].CamPoints[index17].EntitiesG0);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[index16].CamPoints[index17].EntitiesG0);
            buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index16].CamPoints[index17].EntitiesG1);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[index16].CamPoints[index17].EntitiesG1);
            buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index16].CamPoints[index17].EntitiesLeadIn);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[index16].CamPoints[index17].EntitiesLeadIn);
            buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index16].CamPoints[index17].EntitiesLeadOut);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[index16].CamPoints[index17].EntitiesLeadOut);
            buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index16].CamPoints[index17].EntitiesLeave);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[index16].CamPoints[index17].EntitiesLeave);
            buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index16].CamPoints[index17].EntitiesMark);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[index16].CamPoints[index17].EntitiesMark);
            buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index16].CamPoints[index17].EntitiesOther);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[index16].CamPoints[index17].EntitiesOther);
            buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[index16].CamPoints[index17].EntitiesPlunge);
            buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[index16].CamPoints[index17].EntitiesPlunge);
            for (int index18 = 0; index18 <= P.CamCalculation[index16].CamPoints[index17].EntitiesG1.Count - 1; ++index18)
            {
              eEntities EEntity = new eEntities();
              geoEntity.GeoEntitiyToEEntity(P.CamCalculation[index16].CamPoints[index17].EntitiesG1[index18], ref EEntity);
              P.AuxEntities.Add(EEntity);
            }
            for (int index19 = 0; index19 <= P.CamCalculation[index16].CamPoints[index17].SimilationPoint.SimDetailedPoints.Count - 1; ++index19)
            {
              Pnt6DSim pnt6Dsim = new Pnt6DSim(P.CamCalculation[index16].CamPoints[index17].SimilationPoint.SimDetailedPoints[index19]);
              buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref pnt6Dsim);
              buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref pnt6Dsim);
              pnt6Dsim.A = a;
              P.CamCalculation[index16].CamPoints[index17].SimilationPoint.SimDetailedPoints[index19] = pnt6Dsim;
            }
            for (int index20 = 0; index20 <= P.CamCalculation[index16].CamPoints[index17].Points.Count - 1; ++index20)
            {
              Pnt9D pnt9D1 = new Pnt9D(P.CamCalculation[index16].CamPoints[index17].Points[index20].P9);
              buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref pnt9D1);
              buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref pnt9D1);
              double length = P.Tool.Geometry.Length;
              Pnt6D CalcPoint = new Pnt6D();
              OrientationAngle Orientation = new OrientationAngle(a, 0.0, 0.0);
              buAppCalc.cKinematic.ForwardKinematix4Ax(length, Kinematic, VectorType.XVector, Orientation, new Pnt3D(pnt9D1.X, pnt9D1.Y, pnt9D1.Z), ref CalcPoint);
              Pnt9D pnt9D2 = new Pnt9D(CalcPoint.X, CalcPoint.Y, CalcPoint.Z - Kinematic.RotateCenterOffsetOfA.Z - length, CalcPoint.A, CalcPoint.B, CalcPoint.C);
              if (P.CamCalculation[index16].CamPoints[index17].Points[index20].PlungeAxisMovement)
                P.CamCalculation[index16].CamPoints[index17].Points[index20].PlungeAxis = "Z";
              P.CamCalculation[index16].CamPoints[index17].Points[index20].P9 = pnt9D2;
            }
          }
        }
      }
      return 1;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return -1;
    }
  }

  public int ProfileOperationNotchCalc(
    ref ProfileOperation P,
    ref List<eEntities> CadEntities,
    ref camBase CamCalc,
    actionTypeBU Action,
    ProfileItem Profile,
    ToolBase Tool,
    List<ToolBase> ToolList,
    WorkPlane Plane,
    ProfileOperationData OperationData,
    camParameters camParNotch,
    int LayerIndex,
    double YSing)
  {
    try
    {
      string str = "";
      CamCalc = new camBase();
      CamPoint camPoint1 = new CamPoint();
      CamCalc.Name = "Profile -" + str;
      Pnt9DCam pnt9Dcam = new Pnt9DCam();
      ToolBase tool1 = (ToolBase) null;
      ToolBase tool2 = new ToolBase(Tool);
      for (int index = 0; index <= ToolList.Count - 1; ++index)
      {
        if (ToolList[index].Purpose == ToolPurpose.Saw)
          tool2 = new ToolBase(ToolList[index]);
        if (ToolList[index].Purpose == ToolPurpose.Milling)
        {
          if (tool1 == null)
          {
            if (ToolList[index].Geometry.Length > OperationData.NotchData.NotchLHeight && ToolList[index].Geometry.Diameter / 2.0 <= OperationData.NotchData.NotchLDepth)
              tool1 = new ToolBase(ToolList[index]);
          }
          else if (ToolList[index].Geometry.Length > OperationData.NotchData.NotchLHeight && ToolList[index].Geometry.Diameter / 2.0 <= OperationData.NotchData.NotchLDepth && ToolList[index].Geometry.Diameter < tool1.Geometry.Diameter)
            tool1 = new ToolBase(ToolList[index]);
        }
      }
      List<double> doubleList = new List<double>();
      double x1 = 0.0;
      double x2 = 0.0;
      double x3 = 0.0;
      if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
      {
        x2 = -camParNotch.Distances.Safe;
        x3 = OperationData.NotchData.NotchLDepth - tool1.Geometry.Diameter / 2.0;
      }
      if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
      {
        x2 = Profile.Length + camParNotch.Distances.Safe;
        x3 = Profile.Length - OperationData.NotchData.NotchLDepth + tool1.Geometry.Diameter / 2.0;
      }
      if (OperationData.NotchData.NotchType == ProfileNotchType.LType)
      {
        P = (ProfileOperation) new ProfileOperationNotch();
        ((ProfileOperationNotch) P).Type = OperationData.NotchData.NotchType;
        ((ProfileOperationNotch) P).Width = OperationData.NotchData.NotchLWidth;
        ((ProfileOperationNotch) P).Height = OperationData.NotchData.NotchLHeight;
        P.Depth = OperationData.NotchData.NotchLDepth;
        ((ProfileOperationNotch) P).ToolCutPersentage = OperationData.NotchData.NotchCutPersentage;
        ((ProfileOperationNotch) P).UpDown = OperationData.NotchData.NotchLUpDown;
        ((ProfileOperationNotch) P).LeftRight = OperationData.NotchData.NotchLeftRight;
        str = "Notch L";
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
          x1 = OperationData.NotchData.NotchLDepth;
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
          x1 = Profile.Length - OperationData.NotchData.NotchLDepth;
        if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up)
        {
          double num1 = OperationData.NotchData.NotchLHeight - tool2.Geometry.Thickness * 2.0;
          double num2 = tool2.Geometry.Thickness * OperationData.NotchData.NotchCutPersentage / 100.0;
          int int32 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num1 / num2)));
          double num3 = Math.Round(num1 / (double) int32, 5);
          doubleList.Add(Profile.Height - tool2.Geometry.Thickness / 2.0);
          double num4 = Profile.Height - tool2.Geometry.Thickness / 2.0;
          for (int index = 1; index <= int32; ++index)
          {
            double num5 = Math.Round(num4 - num3, 5);
            doubleList.Add(num5);
            num4 = num5;
          }
          doubleList.Add(Profile.Height - OperationData.NotchData.NotchLHeight + tool2.Geometry.Thickness / 2.0);
        }
        if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Down)
        {
          double num6 = OperationData.NotchData.NotchLHeight - tool2.Geometry.Thickness * 2.0;
          double num7 = tool2.Geometry.Thickness * OperationData.NotchData.NotchCutPersentage / 100.0;
          int int32 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num6 / num7)));
          double num8 = Math.Round(num6 / (double) int32, 5);
          doubleList.Add(OperationData.NotchData.NotchLHeight - tool2.Geometry.Thickness / 2.0);
          double num9 = OperationData.NotchData.NotchLHeight - tool2.Geometry.Thickness / 2.0;
          for (int index = 1; index <= int32; ++index)
          {
            double num10 = Math.Round(num9 - num8, 5);
            doubleList.Add(num10);
            num9 = num10;
          }
          doubleList.Add(tool2.Geometry.Thickness / 2.0);
        }
      }
      if (OperationData.NotchData.NotchType == ProfileNotchType.UType)
      {
        P = (ProfileOperation) new ProfileOperationNotch();
        ((ProfileOperationNotch) P).Type = OperationData.NotchData.NotchType;
        ((ProfileOperationNotch) P).Width = OperationData.NotchData.NotchUWidth;
        ((ProfileOperationNotch) P).Height = OperationData.NotchData.NotchUHeight;
        ((ProfileOperationNotch) P).Start = OperationData.NotchData.NotchUStart;
        P.Depth = OperationData.NotchData.NotchUDepth;
        ((ProfileOperationNotch) P).ToolCutPersentage = OperationData.NotchData.NotchCutPersentage;
        ((ProfileOperationNotch) P).LeftRight = OperationData.NotchData.NotchLeftRight;
        str = "Notch U";
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
          x1 = OperationData.NotchData.NotchUDepth;
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
          x1 = Profile.Length - OperationData.NotchData.NotchUDepth;
        double num11 = OperationData.NotchData.NotchUHeight - tool2.Geometry.Thickness * 2.0;
        double num12 = tool2.Geometry.Thickness * OperationData.NotchData.NotchCutPersentage / 100.0;
        int int32 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num11 / num12)));
        double num13 = Math.Round(num11 / (double) int32, 5);
        doubleList.Add(OperationData.NotchData.NotchUStart - tool2.Geometry.Thickness / 2.0);
        double num14 = OperationData.NotchData.NotchUStart - tool2.Geometry.Thickness / 2.0;
        for (int index = 1; index <= int32; ++index)
        {
          double num15 = Math.Round(num14 - num13, 5);
          doubleList.Add(num15);
          num14 = num15;
        }
        doubleList.Add(OperationData.NotchData.NotchUStart - OperationData.NotchData.NotchUHeight + tool2.Geometry.Thickness / 2.0);
      }
      if (OperationData.NotchData.NotchType == ProfileNotchType.LType & OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up & OperationData.NotchData.NotchCutType == ProfileNotchCutType.BySawAndMilling)
      {
        if (tool1 == null)
          return -1;
        CamCalc.Tool = new ToolBase(tool2);
        double z = Profile.Height + Profile.SupportBlockZHeight - OperationData.NotchData.NotchLHeight + tool2.Geometry.Thickness / 2.0;
        List<Pnt3D> vertice1 = new List<Pnt3D>();
        Pnt9DCam Pnt1 = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Rapid, 0);
        Pnt1.PlungeAxis = "X";
        Pnt1.PlungeAxisMovement = true;
        camPoint1.Points.Add(Pnt1);
        vertice1.Add(new Pnt3D(Pnt1));
        Pnt9DCam Pnt2 = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Rapid, 0);
        Pnt2.Type = 0;
        Pnt2.Feed = camParNotch.Speeds.Rapid;
        camPoint1.Points.Add(Pnt2);
        vertice1.Add(new Pnt3D(Pnt2));
        Pnt9DCam Pnt3 = new Pnt9DCam(new Pnt6D(x1, 0.0, z), camParNotch.Speeds.Plunge, 1);
        Pnt3.Type = 1;
        Pnt3.Feed = camParNotch.Speeds.Plunge;
        camPoint1.Points.Add(Pnt3);
        vertice1.Add(new Pnt3D(Pnt3));
        Pnt9DCam Pnt4 = new Pnt9DCam(new Pnt6D(x1, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
        Pnt4.Type = 1;
        Pnt4.Feed = camParNotch.Speeds.Feed;
        camPoint1.Points.Add(Pnt4);
        vertice1.Add(new Pnt3D(Pnt4));
        Pnt9DCam Pnt5 = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
        Pnt5.Type = 1;
        Pnt5.Feed = camParNotch.Speeds.Leave;
        camPoint1.Points.Add(Pnt5);
        vertice1.Add(new Pnt3D(Pnt5));
        geoPolyline geoPolyline1 = new geoPolyline(vertice1, -1);
        geoPolyline1.Color = OperationData.NotchData.NotchColor;
        geoPolyline1.Thickness = OperationData.NotchData.NotchThickness;
        camPoint1.EntitiesG1.Add((geoEntity) geoPolyline1);
        this.SimPointCreatForDetailedPoints(camPoint1.Points, 0.25, 0.1, 3.0, ref camPoint1.SimilationPoint);
        CamCalc.CamPoints.Add(camPoint1);
        CamCalc.Tool = new ToolBase(tool2);
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
          CamCalc.Tool.CamData.SimMoveOffset.X = -tool2.Geometry.Diameter / 2.0;
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
          CamCalc.Tool.CamData.SimMoveOffset.X = tool2.Geometry.Diameter / 2.0;
        P.CamCalculation.Add(new camBase(CamCalc));
        CamCalc = new camBase();
        CamPoint camPoint2 = new CamPoint();
        CamCalc.Name = "Profile -" + str;
        pnt9Dcam = new Pnt9DCam();
        List<Pnt3D> vertice2 = new List<Pnt3D>();
        Pnt9DCam Pnt6 = new Pnt9DCam(new Pnt6D(x3, 0.0, Profile.Height + camParNotch.Distances.Safe), camParNotch.Speeds.Rapid, 0);
        Pnt6.PlungeAxis = "Z";
        Pnt6.PlungeAxisMovement = true;
        camPoint2.Points.Add(Pnt6);
        vertice2.Add(new Pnt3D(Pnt6));
        Pnt9DCam Pnt7 = new Pnt9DCam(new Pnt6D(x3, 0.0, Profile.Height + camParNotch.Distances.Safe), camParNotch.Speeds.Rapid, 0);
        Pnt7.Type = 0;
        Pnt7.Feed = camParNotch.Speeds.Rapid;
        camPoint2.Points.Add(Pnt7);
        vertice2.Add(new Pnt3D(Pnt7));
        Pnt9DCam Pnt8 = new Pnt9DCam(new Pnt6D(x3, 0.0, z - tool2.Geometry.Thickness / 2.0), camParNotch.Speeds.Plunge, 1);
        Pnt8.Type = 1;
        Pnt8.Feed = camParNotch.Speeds.Plunge;
        camPoint2.Points.Add(Pnt8);
        vertice2.Add(new Pnt3D(Pnt8));
        Pnt9DCam Pnt9 = new Pnt9DCam(new Pnt6D(x3, Profile.Width * YSing, z - tool2.Geometry.Thickness / 2.0), camParNotch.Speeds.Plunge, 1);
        Pnt9.Type = 1;
        Pnt9.Feed = camParNotch.Speeds.Feed;
        camPoint2.Points.Add(Pnt9);
        vertice2.Add(new Pnt3D(Pnt9));
        Pnt9DCam Pnt10 = new Pnt9DCam(new Pnt6D(x3, Profile.Width * YSing, Profile.Height + camParNotch.Distances.Safe), camParNotch.Speeds.Plunge, 1);
        Pnt10.Type = 1;
        Pnt10.Feed = camParNotch.Speeds.Leave;
        camPoint2.Points.Add(Pnt10);
        vertice2.Add(new Pnt3D(Pnt10));
        geoPolyline geoPolyline2 = new geoPolyline(vertice2, -1);
        geoPolyline2.Color = OperationData.NotchData.NotchColor;
        geoPolyline2.Thickness = OperationData.NotchData.NotchThickness;
        camPoint2.EntitiesG1.Add((geoEntity) geoPolyline2);
        this.SimPointCreatForDetailedPoints(camPoint2.Points, 0.25, 0.1, 3.0, ref camPoint2.SimilationPoint);
        CamCalc.CamPoints.Add(camPoint2);
        CamCalc.Tool = new ToolBase(tool1);
        doubleList.Clear();
      }
      for (int index = 0; index <= doubleList.Count - 1; ++index)
      {
        CamCalc.Tool = new ToolBase(tool2);
        List<Pnt3D> vertice = new List<Pnt3D>();
        CamPoint camPoint3 = new CamPoint();
        double z = doubleList[index];
        if (OperationData.NotchData.NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
        {
          camPoint3.Points.Add(new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Rapid, 0)
          {
            PlungeAxis = "X",
            PlungeAxisMovement = true
          });
          Pnt9DCam Pnt11 = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Rapid, 0);
          Pnt11.Type = 0;
          Pnt11.Feed = camParNotch.Speeds.Rapid;
          camPoint3.Points.Add(Pnt11);
          vertice.Add(new Pnt3D(Pnt11));
          Pnt9DCam Pnt12 = new Pnt9DCam(new Pnt6D(x1, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
          Pnt12.Type = 1;
          Pnt12.Feed = camParNotch.Speeds.Plunge;
          camPoint3.Points.Add(Pnt12);
          vertice.Add(new Pnt3D(Pnt12));
          Pnt9DCam Pnt13 = new Pnt9DCam(new Pnt6D(x1, 0.0, z), camParNotch.Speeds.Plunge, 1);
          Pnt13.Type = 1;
          Pnt13.Feed = camParNotch.Speeds.Feed;
          camPoint3.Points.Add(Pnt13);
          vertice.Add(new Pnt3D(Pnt13));
          Pnt9DCam Pnt14 = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Plunge, 1);
          Pnt14.Type = 1;
          Pnt14.Feed = camParNotch.Speeds.Leave;
          camPoint3.Points.Add(Pnt14);
          vertice.Add(new Pnt3D(Pnt14));
        }
        if (OperationData.NotchData.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
        {
          if (index % 2 == 1)
          {
            Pnt9DCam Pnt15 = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Rapid, 0);
            Pnt15.PlungeAxis = "X";
            Pnt15.PlungeAxisMovement = true;
            camPoint3.Points.Add(Pnt15);
            vertice.Add(new Pnt3D(Pnt15));
            Pnt9DCam Pnt16 = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Rapid, 0);
            Pnt16.Type = 0;
            Pnt16.Feed = camParNotch.Speeds.Rapid;
            camPoint3.Points.Add(Pnt16);
            vertice.Add(new Pnt3D(Pnt16));
            Pnt9DCam Pnt17 = new Pnt9DCam(new Pnt6D(x1, 0.0, z), camParNotch.Speeds.Plunge, 1);
            Pnt17.Type = 1;
            Pnt17.Feed = camParNotch.Speeds.Plunge;
            camPoint3.Points.Add(Pnt17);
            vertice.Add(new Pnt3D(Pnt17));
            Pnt9DCam Pnt18 = new Pnt9DCam(new Pnt6D(x1, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
            Pnt18.Type = 1;
            Pnt18.Feed = camParNotch.Speeds.Feed;
            camPoint3.Points.Add(Pnt18);
            vertice.Add(new Pnt3D(Pnt18));
            Pnt9DCam Pnt19 = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
            Pnt19.Type = 1;
            Pnt19.Feed = camParNotch.Speeds.Leave;
            camPoint3.Points.Add(Pnt19);
            vertice.Add(new Pnt3D(Pnt19));
          }
          else
          {
            camPoint3.Points.Add(new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Rapid, 0)
            {
              PlungeAxis = "X",
              PlungeAxisMovement = true
            });
            Pnt9DCam Pnt20 = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Rapid, 0);
            Pnt20.Type = 0;
            Pnt20.Feed = camParNotch.Speeds.Rapid;
            camPoint3.Points.Add(Pnt20);
            vertice.Add(new Pnt3D(Pnt20));
            Pnt9DCam Pnt21 = new Pnt9DCam(new Pnt6D(x1, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
            Pnt21.Type = 1;
            Pnt21.Feed = camParNotch.Speeds.Plunge;
            camPoint3.Points.Add(Pnt21);
            vertice.Add(new Pnt3D(Pnt21));
            Pnt9DCam Pnt22 = new Pnt9DCam(new Pnt6D(x1, 0.0, z), camParNotch.Speeds.Plunge, 1);
            Pnt22.Type = 1;
            Pnt22.Feed = camParNotch.Speeds.Feed;
            camPoint3.Points.Add(Pnt22);
            vertice.Add(new Pnt3D(Pnt22));
            Pnt9DCam Pnt23 = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Plunge, 1);
            Pnt23.Type = 1;
            Pnt23.Feed = camParNotch.Speeds.Leave;
            camPoint3.Points.Add(Pnt23);
            vertice.Add(new Pnt3D(Pnt23));
          }
        }
        geoPolyline geoPolyline = new geoPolyline(vertice, -1);
        geoPolyline.Color = OperationData.RectangleData.RectangleColor;
        geoPolyline.Thickness = OperationData.RectangleData.RectangleThickness;
        camPoint3.EntitiesG1.Add((geoEntity) geoPolyline);
        this.SimPointCreatForDetailedPoints(camPoint3.Points, 0.25, 0.1, 3.0, ref camPoint3.SimilationPoint);
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
          CamCalc.Tool.CamData.SimMoveOffset.X = -tool2.Geometry.Diameter / 2.0;
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
          CamCalc.Tool.CamData.SimMoveOffset.X = tool2.Geometry.Diameter / 2.0;
        CamCalc.CamPoints.Add(camPoint3);
      }
      if (OperationData.NotchData.NotchType == ProfileNotchType.LType)
      {
        List<List<Pnt3D>> Vertices1 = new List<List<Pnt3D>>();
        List<Triangle3D> Triangles = new List<Triangle3D>();
        List<TriangleIndex> TrianglesIndex = new List<TriangleIndex>();
        List<Pnt3D> Vertices2 = new List<Pnt3D>();
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
        {
          if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up)
          {
            buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, Profile.Height - OperationData.NotchData.NotchLHeight), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices2);
            buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, Profile.Height - OperationData.NotchData.NotchLHeight), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref Vertices1, ref Triangles);
          }
          if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Down)
          {
            buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, 0.0), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices2);
            buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, 0.0), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref Vertices1, ref Triangles);
          }
        }
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
        {
          if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up)
          {
            buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, Profile.Height - OperationData.NotchData.NotchLHeight), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices2);
            buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, Profile.Height - OperationData.NotchData.NotchLHeight), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref Vertices1, ref Triangles);
          }
          if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Down)
          {
            buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, 0.0), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices2);
            buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, 0.0), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref Vertices1, ref Triangles);
          }
        }
        List<eEntities> eEntitiesList = new List<eEntities>();
        CadEntities.Clear();
        for (int index = 0; index <= Vertices1.Count - 1; ++index)
        {
          ePolyline ePolyline = new ePolyline(Vertices1[index]);
          ePolyline.LayerIndex = LayerIndex;
          CadEntities.Add((eEntities) ePolyline);
          eEntitiesList.Add((eEntities) ePolyline);
        }
        P.Entities.Add(eEntitiesList);
        eMesh eMesh = new eMesh(TrianglesIndex, Vertices2, Color.Gold);
        eMesh.LayerIndex = LayerIndex;
        CadEntities.Add((eEntities) eMesh);
        P.SolidEntities.Add((eEntities) eMesh);
      }
      if (OperationData.NotchData.NotchType == ProfileNotchType.UType)
      {
        List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
        List<Triangle3D> triangle3DList = new List<Triangle3D>();
        List<TriangleIndex> TrianglesIndex = new List<TriangleIndex>();
        List<Pnt3D> Vertices = new List<Pnt3D>();
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
          buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchUDepth / 2.0, YSing * OperationData.NotchData.NotchUWidth / 2.0, OperationData.NotchData.NotchUStart - OperationData.NotchData.NotchUHeight), OperationData.NotchData.NotchUDepth, YSing * OperationData.NotchData.NotchUWidth, OperationData.NotchData.NotchUHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices);
        if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
          buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchUDepth / 2.0, YSing * OperationData.NotchData.NotchUWidth / 2.0, OperationData.NotchData.NotchUStart - OperationData.NotchData.NotchUHeight), OperationData.NotchData.NotchUDepth, YSing * OperationData.NotchData.NotchUWidth, OperationData.NotchData.NotchUHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices);
        CadEntities.Clear();
        List<eEntities> eEntitiesList = new List<eEntities>();
        for (int index = 0; index <= pnt3DListList.Count - 1; ++index)
        {
          ePolyline ePolyline = new ePolyline(pnt3DListList[index]);
          ePolyline.LayerIndex = LayerIndex;
          CadEntities.Add((eEntities) ePolyline);
          eEntitiesList.Add((eEntities) ePolyline);
        }
        P.Entities.Add(eEntitiesList);
        eMesh eMesh = new eMesh(TrianglesIndex, Vertices, Color.Gold);
        eMesh.LayerIndex = LayerIndex;
        CadEntities.Add((eEntities) eMesh);
        P.SolidEntities.Add((eEntities) eMesh);
      }
      P.CamParNotch = new camParameters(camParNotch);
      P.CamCalculation.Add(new camBase(CamCalc));
      P.OperationData = new ProfileOperationData(OperationData);
      return 1;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return -1;
    }
  }

  public int ProfileContourOffsets(
    List<Pnt3D> ContourPoints,
    double ExtraOffset,
    camParameters camParMilling,
    ToolBase toolSelected,
    CamZHeightType OperationCamType,
    ref List<List<Pnt3D>> pntCalculated)
  {
    try
    {
      pntCalculated.Clear();
      if (ContourPoints.Count > 0)
      {
        bool flag = buAppCalc.cVector.IsClosed(ContourPoints);
        if (OperationCamType == CamZHeightType.Contour | OperationCamType == CamZHeightType.Finish)
        {
          if (flag)
          {
            if (camParMilling.Offsets.ClosedContour != CamClosedContourType.Center)
            {
              double Offset = toolSelected.Geometry.Diameter / 2.0 + toolSelected.CamData.ExtraOffset + ExtraOffset;
              if (camParMilling.Offsets.ClosedContour == CamClosedContourType.Inner)
                Offset = -Offset;
              buAppCalc.cVector.OffsetContour(ContourPoints, Offset, camParMilling.Offsets.Corner, CamOpenContourType2.Center, new WorkPlane(), 0.0, ref pntCalculated);
            }
            else
            {
              List<Pnt3D> CopiedPnt = new List<Pnt3D>();
              Pnt3D.Copy(ContourPoints, ref CopiedPnt);
              pntCalculated.Add(CopiedPnt);
            }
          }
          else if (camParMilling.Offsets.OpenContourOld == CamOpenContourType2.Center)
          {
            List<Pnt3D> CopiedPnt = new List<Pnt3D>();
            Pnt3D.Copy(ContourPoints, ref CopiedPnt);
            pntCalculated.Add(CopiedPnt);
          }
          else
          {
            double Offset = toolSelected.Geometry.Diameter / 2.0 + toolSelected.CamData.ExtraOffset + ExtraOffset;
            buAppCalc.cVector.OffsetContour(ContourPoints, Offset, camParMilling.Offsets.Corner, camParMilling.Offsets.OpenContourOld, new WorkPlane(), 0.0, ref pntCalculated);
            List<Pnt3D> CalcPoints = new List<Pnt3D>();
            if (pntCalculated.Count > 0)
            {
              buAppCalc.cVector.OpenProfileCalculation(pntCalculated[0], ContourPoints, Offset, new WorkPlane(), camParMilling.Offsets.OpenContourOld, ref CalcPoints);
              pntCalculated[0] = CalcPoints;
            }
          }
        }
        if (OperationCamType == CamZHeightType.AreaClearance & flag)
        {
          ContourPoints RefPoint = new ContourPoints();
          List<PocketPoints> Pockets = new List<PocketPoints>();
          List<List<eEntities>> PocketEntities = new List<List<eEntities>>();
          Pnt3D.Copy(ContourPoints, ref RefPoint.Outter);
          buAppCalc.cVector.camPocketCircular(RefPoint, -(toolSelected.Geometry.Diameter / 2.0 + toolSelected.CamData.ExtraOffset + ExtraOffset), camParMilling.Offsets.Corner, new WorkPlane(), 0.0, ClockDirectionType.CW, ref Pockets, ref PocketEntities);
          if (Pockets.Count > 0)
          {
            for (int index1 = 0; index1 <= Pockets.Count - 1; ++index1)
            {
              List<Pnt3D> pnt3DList = new List<Pnt3D>();
              for (int index2 = 0; index2 <= Pockets[index1].Pockets.Count - 1; ++index2)
              {
                for (int index3 = 0; index3 <= Pockets[index1].Pockets[index2].Count - 1; ++index3)
                  pnt3DList.Add(new Pnt3D(Pockets[index1].Pockets[index2][index3]));
              }
              if (pnt3DList.Count > 0)
              {
                if (camParMilling.Operations.AreaClearanceDirection == InToOutType.InToOut & camParMilling.Operations.AreaClearanceEnable)
                  pnt3DList.Reverse();
                pntCalculated.Add(pnt3DList);
              }
            }
          }
        }
      }
      return 1;
    }
    catch (Exception ex)
    {
      return -1;
    }
  }

  public void Cam5AxisWithSaw(
    List<List<eEntities>> Entities,
    KinematicBase Kinematic,
    ToolBase Tool,
    camParameters camParameter,
    ref camBase calcCam)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt6D pnt6D1 = new Pnt6D();
      List<Triangle3D> Triangles = new List<Triangle3D>();
      calcCam = new camBase();
      calcCam.Tool = new ToolBase(Tool);
      calcCam.Kinematic = new KinematicBase(Kinematic);
      KinematicItem kinematicItem = new KinematicItem();
      kinematicItem.Axis.A = true;
      kinematicItem.Axis.C = true;
      buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, -Kinematic.RotateCenterOffsetOfC.Y, -Kinematic.RotateCenterOffsetOfC.Z), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 1.0, 0.0), new EntityResolution(), ref Triangles);
      eEntities eEntities = (eEntities) new eSurface(Triangles, Tool.Display.Solid.SkinColor);
      kinematicItem.Entities.Add(eEntities);
      calcCam.Kinematic.Items.Add(kinematicItem);
      CamPoint camPoint1 = new CamPoint();
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.calculationEventHandler_1(new CalculationEventArg());
      }
      List<List<Pnt6D>> pnt6DListList = new List<List<Pnt6D>>();
      for (int index1 = 0; index1 <= Entities.Count - 1; ++index1)
      {
        List<Pnt6D> pnt6DList1 = new List<Pnt6D>();
        if (Entities[index1].Count >= 1)
        {
          List<Pnt6D> Points = new List<Pnt6D>();
          List<Pnt6D> pnt6DList2 = new List<Pnt6D>();
          buAppCalc.cVector.EntityToPoint(Entities[index1], buSystem.EntitiesResolution, ref Points);
          buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points, 0.01);
          if (Points.Count > 1)
          {
            double c1 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[1]), new Pnt3D(Points[0]));
            if (Entities[index1].Count == 1 & Points[0].C != 0.0)
              c1 = Points[0].C;
            double num1 = c1;
            pnt6DList1.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, c1));
            for (int index2 = 1; index2 <= Points.Count - 2; ++index2)
            {
              double c2 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index2]), new Pnt3D(Points[index2 - 1]));
              if (Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C) > 185.0)
              {
                if (pnt6DList1[pnt6DList1.Count - 1].C > c2)
                  c2 += 360.0;
                else
                  c2 -= 360.0;
              }
              double c3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[index2 + 1]), new Pnt3D(Points[index2]));
              double num2 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(pnt6DList1[pnt6DList1.Count - 1]), new Pnt3D(Points[index2]), new Pnt3D(Points[index2]), new Pnt3D(Points[index2 + 1]), new WorkPlane());
              double num3 = 180.0 - num2;
              if (num3 >= 360.0 - camParameter.Strategy.AngleLimit)
                num3 = 360.0 - num2;
              Math.Abs(c2 - num1);
              if (num3 > camParameter.Strategy.AngleLimit)
              {
                pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                pnt6DListList.Add(pnt6DList1);
                pnt6DList1 = new List<Pnt6D>();
                pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c3));
              }
              else
              {
                double num4 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                if (num4 >= 360.0 - camParameter.Strategy.AngleLimit)
                {
                  if (c2 > pnt6DList1[pnt6DList1.Count - 1].C)
                    c2 -= 360.0;
                  else
                    c2 += 360.0;
                  num4 = Math.Abs(c2 - pnt6DList1[pnt6DList1.Count - 1].C);
                }
                if (num4 > 185.0)
                  c2 += 360.0;
                pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                if (Math.Abs(c2 - c3) > 180.1)
                {
                  double num5 = c2 - c3;
                  if (c2 > c3)
                  {
                    double lower = buNumeric.RoundToLower(Math.Abs(num5) / 360.0);
                    c3 += 360.0 + lower * 360.0;
                  }
                  else
                  {
                    double lower = buNumeric.RoundToLower(Math.Abs(num5) / 360.0);
                    c3 -= 360.0 + lower * 360.0;
                  }
                }
                if (camParameter.Options.AxesLimit.MinLimit != camParameter.Options.AxesLimit.MaxLimit)
                {
                  if (c3 > camParameter.Options.AxesLimit.MaxLimit.C)
                  {
                    pnt6DListList.Add(pnt6DList1);
                    c2 -= 360.0;
                    pnt6DList1 = new List<Pnt6D>();
                    pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                  }
                  if (c3 < camParameter.Options.AxesLimit.MinLimit.C)
                  {
                    pnt6DListList.Add(pnt6DList1);
                    c2 += 360.0;
                    pnt6DList1 = new List<Pnt6D>();
                    pnt6DList1.Add(new Pnt6D(Points[index2].X, Points[index2].Y, Points[index2].Z, Points[index2].A, 0.0, c2));
                  }
                }
              }
              num1 = c2;
            }
            if (pnt6DList1.Count > 0)
            {
              double c4 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[Points.Count - 1]), new Pnt3D(Points[Points.Count - 2]));
              if (Entities[index1].Count == 1 & Points[Points.Count - 1].C != 0.0)
                c4 = Points[Points.Count - 1].C;
              double num6 = Math.Abs(c4 - pnt6DList1[pnt6DList1.Count - 1].C);
              if (num6 >= 360.0 - camParameter.Strategy.AngleLimit)
              {
                num6 = 360.0 - c4;
                if (c4 > pnt6DList1[pnt6DList1.Count - 1].C)
                  c4 -= 360.0;
              }
              if (num6 > 185.0)
                c4 += 360.0;
              pnt6DList1.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, c4));
              pnt6DListList.Add(pnt6DList1);
            }
          }
        }
      }
      int int32 = Convert.ToInt32((double) pnt6DListList.Count / 100.0);
      int num7 = 0;
      Pnt6D pnt6D2 = new Pnt6D();
      Pnt6D pnt6D3 = new Pnt6D();
      double num8 = camParameter.Distances.Safe;
      OrientationAngle orientationAngle1 = new OrientationAngle();
      if (pnt6DListList.Count > 0 && pnt6DListList[0].Count > 0)
      {
        double z = pnt6DListList[0][0].Z;
      }
      for (int index3 = 0; index3 <= pnt6DListList.Count - 1; ++index3)
      {
        double ToolLength = Tool.Geometry.Diameter / 2.0;
        double feed1 = camParameter.Speeds.Feed;
        double safe = camParameter.Distances.Safe;
        double stepUp = camParameter.Distances.StepUp;
        Pnt6D pnt6D4 = new Pnt6D();
        Pnt6D pnt6D5 = new Pnt6D();
        Pnt6D CalcPoint = new Pnt6D();
        Pnt3D pnt3D2 = new Pnt3D();
        Pnt3D calcPoint = new Pnt3D();
        Pnt3D pnt3D3 = new Pnt3D();
        OrientationAngle orientationAngle2 = new OrientationAngle();
        OrientationAngle orientationAngle3 = new OrientationAngle();
        if (index3 <= pnt6DListList.Count - 2)
          orientationAngle3 = new OrientationAngle(new Pnt6D(pnt6DListList[index3 + 1][0]));
        CamPoint camPoint2 = new CamPoint();
        camPoint2.Type = 0;
        camPoint2.IsRapid = true;
        CalcPoint = new Pnt6D();
        Pnt6D Pnt1 = new Pnt6D(pnt6DListList[index3][0]);
        Pnt3D pnt3D4 = new Pnt3D(Pnt1);
        calcPoint = new Pnt3D();
        pnt3D3 = new Pnt3D();
        OrientationAngle orientationAngle4 = new OrientationAngle(Pnt1);
        double feed2 = camParameter.Speeds.Feed;
        double Length1 = (num8 - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        calcCam.Tool.Geometry.Length = ToolLength;
        CalcPoint = new Pnt6D();
        calcPoint = new Pnt3D();
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D4, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length1, ref calcPoint);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        if (orientationAngle4.A != orientationAngle1.A && pnt6D3.Z > CalcPoint.Z)
          CalcPoint.Z = pnt6D3.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camParameter.Speeds.Rapid, 0, true));
        pnt3D1 = new Pnt3D(calcPoint);
        Pnt6D pnt6D6 = new Pnt6D(CalcPoint);
        CalcPoint = new Pnt6D();
        calcPoint = new Pnt3D();
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D4, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length1, ref calcPoint);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camParameter.Speeds.Rapid, 0));
        Pnt3D Pnt2 = new Pnt3D(calcPoint);
        Pnt6D pnt6D7 = new Pnt6D(CalcPoint);
        if (index3 == 0)
        {
          Pnt6D pnt6D8 = new Pnt6D(CalcPoint);
        }
        CalcPoint = new Pnt6D();
        Pnt3D Pnt3 = new Pnt3D(pnt3D4.X, pnt3D4.Y, pnt3D4.Z);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(Pnt3), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camParameter.Speeds.Plunge, 1));
        camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(Pnt2), new Pnt3D(Pnt3), Color.Lime));
        Pnt3D pnt3D5 = new Pnt3D(pnt3D4);
        Pnt6D pnt6D9 = new Pnt6D(CalcPoint);
        for (int index4 = 1; index4 <= pnt6DListList[index3].Count - 1; ++index4)
        {
          Pnt1 = new Pnt6D(pnt6DListList[index3][index4]);
          orientationAngle4 = new OrientationAngle(Pnt1);
          CalcPoint = new Pnt6D();
          Pnt3D Pnt4 = new Pnt3D(Pnt1);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(Pnt4), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, feed2, 1));
          camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(pnt3D5), new Pnt3D(Pnt4), Color.Blue));
          pnt3D5 = new Pnt3D(Pnt1);
          Pnt6D pnt6D10 = new Pnt6D(CalcPoint);
          OrientationAngle orientationAngle5 = new OrientationAngle(orientationAngle4);
        }
        double Length2 = (camParameter.Distances.Safe - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        double Length3 = (camParameter.Operations.Thickness + camParameter.Distances.StepUp - Pnt1.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle4.A));
        bool flag = orientationAngle4.A != orientationAngle3.A;
        if (index3 == pnt6DListList.Count - 1)
          flag = true;
        CalcPoint = new Pnt6D();
        calcPoint = new Pnt3D();
        pnt3D3 = new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z + Length3);
        buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length3, ref calcPoint);
        buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint), ref CalcPoint);
        CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
        camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camParameter.Speeds.Leave, 1));
        camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(pnt3D5), new Pnt3D(calcPoint), Color.Red));
        num8 = camParameter.Operations.Thickness + camParameter.Distances.StepUp;
        orientationAngle1 = new OrientationAngle(orientationAngle4);
        if (flag)
        {
          CalcPoint = new Pnt6D();
          calcPoint = new Pnt3D();
          pnt3D3 = new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z + Length2);
          buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle4.A * -1.0, 0.0, orientationAngle4.C), Length2, ref calcPoint);
          buAppCalc.cKinematic.ForwardKinematix5Ax(ToolLength, Kinematic, orientationAngle4, new Pnt3D(calcPoint), ref CalcPoint);
          CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
          camPoint2.Points.Add(new Pnt9DCam(CalcPoint, camParameter.Speeds.Rapid, 0));
          camPoint2.EntitiesG0.Add((geoEntity) new geoLine(new Pnt3D(pnt3D5), new Pnt3D(calcPoint), Color.Gold));
          num8 = camParameter.Distances.Safe;
        }
        pnt6D3 = new Pnt6D(CalcPoint);
        if (index3 != pnt6DListList.Count - 1)
          ;
        if (camPoint2.Points.Count > 0)
          camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[0]));
        for (int index5 = 1; index5 <= camPoint2.Points.Count - 1; ++index5)
        {
          List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
          double dt = 0.1;
          if (camPoint2.Points[index5].Type == 0)
            dt = 0.25;
          if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint2.Points[index5 - 1]), new Pnt3D(camPoint2.Points[index5])) > 3.0)
          {
            buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint2.Points[index5 - 1]), new Pnt6D(camPoint2.Points[index5]), dt, ref CalculatedPoints);
            CalculatedPoints.RemoveAt(0);
            camPoint2.SimilationPoint.SimPoints.AddRange((IEnumerable<Pnt6D>) CalculatedPoints);
          }
          else
            camPoint2.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint2.Points[index5]));
        }
        calcCam.CamPoints.Add(camPoint2);
        // ISSUE: reference to a compiler-generated field
        if (buSystem.ProgressControlEnable && this.calculationEventHandler_0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          this.calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double) index3 / (double) (pnt6DListList.Count - 1)) * 100.0, Convert.ToDouble((double) index3 / (double) (pnt6DListList.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
        }
        if (buSystem.DoEventEnable & int32 > 0 & num7 > 0 && num7 % int32 == 0)
          Application.DoEvents();
        if (!buSystem.Cancel)
        {
          ++num7;
        }
        else
        {
          buSystem.Cancel = false;
          buSystem.Canceled = true;
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_2(new CalculationEventArg());
          }
          // ISSUE: reference to a compiler-generated field
          if (this.calculationEventHandler_3 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
          }
          buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
          return;
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (this.calculationEventHandler_2 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.calculationEventHandler_2(new CalculationEventArg());
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void camClosedContour(
    Pnt3D StartPoint,
    List<List<Pnt3D>> RefPoints,
    double Offset,
    bool AfterFirstPointReverseOffsetDirection,
    CamClosedContourType CamDirection,
    ClockDirectionType ClockDirection,
    OffsetCornerType CornerType,
    ToolBase Tool,
    WorkPlane Plane,
    camSpeeds Speed,
    camDistances Distance,
    camStep Steps,
    camOperation Operation,
    camOptions Options,
    ref camBase CamCalculated)
  {
    try
    {
      List<List<eEntities>> eEntitiesListList = new List<List<eEntities>>();
      for (int index1 = 0; index1 <= RefPoints.Count - 1; ++index1)
      {
        List<List<Pnt3D>> OffsetedPoints = new List<List<Pnt3D>>();
        if (CamDirection != CamClosedContourType.Center)
        {
          if (!AfterFirstPointReverseOffsetDirection)
            buAppCalc.cVector.OffsetContour(RefPoints[index1], Offset, CornerType, CamOpenContourType2.Center, Plane, Operation.Height, ref OffsetedPoints);
          else if (index1 == 0)
            buAppCalc.cVector.OffsetContour(RefPoints[index1], Offset, CornerType, CamOpenContourType2.Center, Plane, Operation.Height, ref OffsetedPoints);
          else
            buAppCalc.cVector.OffsetContour(RefPoints[index1], -Offset, CornerType, CamOpenContourType2.Center, Plane, Operation.Height, ref OffsetedPoints);
        }
        else
        {
          List<Pnt3D> CopiedPnt = new List<Pnt3D>();
          Pnt3D.Copy(RefPoints[index1], ref CopiedPnt);
          OffsetedPoints.Add(CopiedPnt);
        }
        for (int index2 = 0; index2 <= OffsetedPoints.Count - 1; ++index2)
        {
          List<Pnt3D> pnt3DList = new List<Pnt3D>();
          Pnt3D.Copy(OffsetedPoints[index2], ref pnt3DList);
          buAppCalc.cVector.ShiftPointsByLength(RefPoints[index1][0], ref pnt3DList);
          OffsetedPoints[index2] = pnt3DList;
        }
        for (int index3 = 0; index3 <= OffsetedPoints.Count - 1; ++index3)
        {
          if (buAppCalc.cVector.PolygonDirection(OffsetedPoints[index3], Plane) != ClockDirection & OffsetedPoints[index3].Count > 2)
            OffsetedPoints[index3].Reverse();
          List<eEntities> CalcEntities = new List<eEntities>();
          buAppCalc.cVector.PointsToEntities(OffsetedPoints[index3], Plane, buSystem.PointsToEntities, ref CalcEntities);
          eEntitiesListList.Add(CalcEntities);
        }
        OffsetedPoints.Clear();
      }
      if (CamDirection == CamClosedContourType.Center)
        CamCalculated.CamType = CamType.ContourClosedCenter;
      if (CamDirection == CamClosedContourType.Outter)
        CamCalculated.CamType = CamType.ContourClosedOutside;
      if (CamDirection == CamClosedContourType.Inner)
        CamCalculated.CamType = CamType.ContourClosedInside;
      CamCalculated.Name = "Contour : " + CamDirection.ToString();
      CamPoint camPoint = new CamPoint();
      if (Operation.StepHeights.Count == 0)
        Operation.StepHeights.Add(Operation.Height);
      bool isFirst = true;
      bool isLast = false;
      bool flag1 = false;
      bool flag2 = false;
      if (Steps.Sequence == CamMachiningSequenceType.Level)
      {
        Pnt6D NextContourStartPoint = new Pnt6D();
        List<Pnt3D> Points = new List<Pnt3D>();
        for (int index4 = 0; index4 <= Operation.StepHeights.Count - 1; ++index4)
        {
          bool isStep = true;
          for (int index5 = 0; index5 <= eEntitiesListList.Count - 1; ++index5)
          {
            if (index4 == Operation.StepHeights.Count - 1 & index5 == eEntitiesListList.Count - 1)
              isLast = true;
            if (index5 < eEntitiesListList.Count - 1)
            {
              Points.Clear();
              buAppCalc.cVector.EntityToPoint(eEntitiesListList[index5 + 1], new EntityResolution(), ref Points);
              if (Points.Count > 0)
                NextContourStartPoint = new Pnt6D(Points[0]);
            }
            else
            {
              Points.Clear();
              buAppCalc.cVector.EntityToPoint(eEntitiesListList[0], new EntityResolution(), ref Points);
              if (Points.Count > 0)
                NextContourStartPoint = new Pnt6D(Points[0]);
            }
            flag1 = true;
            this.camContourCalculation(eEntitiesListList[index5], NextContourStartPoint, Operation.StepHeights[index4], Tool, isFirst, true, isStep, isLast, ref CamCalculated, Speed, Distance, Steps, Operation, Options);
            isFirst = false;
            isStep = false;
          }
        }
      }
      if (Steps.Sequence == CamMachiningSequenceType.Region)
      {
        Pnt6D NextContourStartPoint = new Pnt6D();
        List<Pnt3D> Points = new List<Pnt3D>();
        for (int index6 = 0; index6 <= eEntitiesListList.Count - 1; ++index6)
        {
          bool isContourToContour = true;
          if (index6 < eEntitiesListList.Count - 1)
          {
            Points.Clear();
            buAppCalc.cVector.EntityToPoint(eEntitiesListList[index6 + 1], new EntityResolution(), ref Points);
            if (Points.Count > 0)
              NextContourStartPoint = new Pnt6D(Points[0]);
          }
          for (int index7 = 0; index7 <= Operation.StepHeights.Count - 1; ++index7)
          {
            if (index7 == Operation.StepHeights.Count - 1 & index6 == eEntitiesListList.Count - 1)
              isLast = true;
            if (index7 < Operation.StepHeights.Count - 1)
            {
              Points.Clear();
              buAppCalc.cVector.EntityToPoint(eEntitiesListList[index6], new EntityResolution(), ref Points);
              if (Points.Count > 0)
              {
                NextContourStartPoint = new Pnt6D(Points[0]);
                if (!buAppCalc.cVector.IsClosed(Points) & Steps.Enable & !Steps.MoveUpEnable & index7 % 2 == 0)
                  NextContourStartPoint = new Pnt6D(Points[Points.Count - 1]);
              }
            }
            else if (index6 < eEntitiesListList.Count - 1)
            {
              Points.Clear();
              buAppCalc.cVector.EntityToPoint(eEntitiesListList[index6 + 1], new EntityResolution(), ref Points);
              if (Points.Count > 0)
              {
                NextContourStartPoint = new Pnt6D(Points[0]);
                if (!buAppCalc.cVector.IsClosed(Points) & Steps.Enable & !Steps.MoveUpEnable & index7 % 2 == 0)
                  NextContourStartPoint = new Pnt6D(Points[Points.Count - 1]);
              }
            }
            List<eEntities> eEntitiesList = new List<eEntities>();
            eEntities.CopyEntities(eEntitiesListList[index6], ref eEntitiesList);
            if (!buAppCalc.cVector.IsEntitiesClosedPath(eEntitiesList) & Steps.Enable & !Steps.MoveUpEnable & index7 % 2 == 1)
            {
              buAppCalc.cVector.ReverseEntitiesDirection(ref eEntitiesList);
              eEntitiesList.Reverse();
            }
            flag2 = true;
            this.camContourCalculation(eEntitiesList, NextContourStartPoint, Operation.StepHeights[index7], Tool, isFirst, isContourToContour, true, isLast, ref CamCalculated, Speed, Distance, Steps, Operation, Options);
            isFirst = false;
            isContourToContour = false;
          }
        }
      }
      eEntitiesListList.Clear();
    }
    catch (Exception ex)
    {
      string str = $"StartPoint: {StartPoint.ToString()} - RefPoints: {RefPoints.Count.ToString()} - Offset: {Offset.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void camContourCalculation(
    List<eEntities> OffsetedEntities,
    Pnt6D NextContourStartPoint,
    double Height,
    ToolBase Tool,
    bool isFirst,
    bool isContourToContour,
    bool isStep,
    bool isLast,
    ref camBase CamCalculated,
    camSpeeds Speed,
    camDistances Distance,
    camStep Steps,
    camOperation Operation,
    camOptions Options)
  {
    Pnt9DCam pnt9Dcam1 = new Pnt9DCam();
    Pnt3D pnt3D1 = new Pnt3D();
    CamPoint CamPnt = new CamPoint();
    if (OffsetedEntities.Count > 0)
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      Pnt3D.Copy(OffsetedEntities[0].Vertice, ref CopiedPnt);
      if (OffsetedEntities[0].camDirections == camPathDirectionType.Reverse)
        CopiedPnt.Reverse();
      Pnt3D pnt3D2 = new Pnt3D(CopiedPnt[0]);
      this.CamSafeDistanceCalculation(isFirst, isContourToContour, isStep, false, true, false, new Pnt6D(pnt3D2), NextContourStartPoint, pnt3D2.Z, Tool, Distance, Speed, Steps, Operation, ref CamPnt);
      CamCalculated.Tool = new ToolBase(Tool);
      for (int index1 = 0; index1 <= OffsetedEntities.Count - 1; ++index1)
      {
        List<Pnt3D> vertice = new List<Pnt3D>();
        Pnt3D.Copy(OffsetedEntities[index1].Vertice, ref vertice);
        Pnt3D.SetValue(Height, AxesXYZ.Z, ref vertice);
        if (OffsetedEntities[index1].camDirections == camPathDirectionType.Reverse)
          vertice.Reverse();
        if (index1 == 0)
        {
          pnt3D2 = new Pnt3D(this.Pnt9LastPoint.X, this.Pnt9LastPoint.Y, Height);
          Pnt9DCam pnt9Dcam2 = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Plunge, 1);
          CamPnt.Points.Add(pnt9Dcam2);
          CamPnt.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), pnt3D2, Tool.Display.PlungeColor, Tool.Display.PlungeThickness));
          CamPnt.EntitiesPlunge.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), pnt3D2, Tool.Display.PlungeColor, Tool.Display.PlungeThickness));
          this.Pnt9LastPoint = new Pnt9D(pnt9Dcam2.P9);
        }
        if (OffsetedEntities[index1].GetType() != typeof (eArc))
        {
          vertice.RemoveAt(0);
          for (int index2 = 0; index2 <= vertice.Count - 1; ++index2)
          {
            pnt3D2 = new Pnt3D(vertice[index2].X, vertice[index2].Y, Height);
            Pnt9DCam pnt9Dcam3 = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Feed, 1);
            CamPnt.Points.Add(pnt9Dcam3);
            CamPnt.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), pnt3D2, Tool.Display.CamColor, Tool.Display.CamThickness));
            this.Pnt9LastPoint = new Pnt9D(pnt9Dcam3.P9);
          }
        }
        else
        {
          eArc eArc = new eArc(new Pnt3D(((ePlaneEntities) OffsetedEntities[index1]).CenterPoint.X, ((ePlaneEntities) OffsetedEntities[index1]).CenterPoint.Y, Height), ((eCircle) OffsetedEntities[index1]).Radius, ((eArc) OffsetedEntities[index1]).StartAngle, ((eArc) OffsetedEntities[index1]).EndAngle, ((ePlaneEntities) OffsetedEntities[index1]).Plane);
          int type = 3;
          if (OffsetedEntities[index1].camDirections == camPathDirectionType.Reverse)
            type = 2;
          pnt3D2 = new Pnt3D(vertice[vertice.Count - 1].X, vertice[vertice.Count - 1].Y, Height);
          Pnt9DCam pnt9Dcam4 = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Feed, type);
          pnt9Dcam4.Radius = eArc.Radius;
          pnt9Dcam4.ArcType = type;
          pnt9Dcam4.ArcData = new geoArc(eArc.CenterPoint, eArc.Radius, eArc.StartAngle, eArc.EndAngle, eArc.Plane);
          CamPnt.Points.Add(pnt9Dcam4);
          CamPnt.EntitiesG1.Add((geoEntity) new geoPolyline(vertice, Tool.Display.CamColor, Tool.Display.CamThickness));
          this.Pnt9LastPoint = new Pnt9D(pnt9Dcam4.P9);
        }
      }
      this.CamSafeDistanceCalculation(false, isContourToContour, isStep, isLast, false, true, new Pnt6D(this.Pnt9LastPoint), NextContourStartPoint, pnt3D2.Z, Tool, Distance, Speed, Steps, Operation, ref CamPnt);
      this.SimPointCreat(CamPnt.Points, 0.25, 0.1, 3.0, ref CamPnt.SimilationPoint);
    }
    if (CamPnt.Points.Count <= 0)
      return;
    CamCalculated.CamPoints.Add(CamPnt);
    CamPnt = new CamPoint();
  }

  public void CamSafeDistanceCalculation(
    bool isFirst,
    bool isContourToContour,
    bool isStep,
    bool isLast,
    bool isPlunge,
    bool isLeave,
    Pnt6D PointActual,
    Pnt6D PointNext,
    double LastZ,
    ToolBase Tool,
    camDistances Distance,
    camSpeeds Speed,
    camStep Steps,
    camOperation Operation,
    ref CamPoint CamPnt)
  {
    Pnt9DCam Pnt = new Pnt9DCam();
    if (isFirst)
    {
      if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.Air)
      {
        double air = Distance.Air;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Leave, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0);
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.AirThenSmallSafe)
      {
        double air = Distance.Air;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt9DCam pnt9Dcam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0);
        CamPnt.Points.Add(pnt9Dcam);
        double safeSmall = Distance.SafeSmall;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Rapid, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.PlungeAxisMovement = true;
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.AirThenSafe)
      {
        double air = Distance.Air;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt9DCam pnt9Dcam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0);
        CamPnt.Points.Add(pnt9Dcam);
        double safe = Distance.Safe;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.PlungeAxisMovement = true;
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.Safe)
      {
        double safe = Distance.Safe;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0);
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.SafeThenSmallSafe)
      {
        double safe = Distance.Safe;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt9DCam pnt9Dcam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0);
        CamPnt.Points.Add(pnt9Dcam);
        double safeSmall = Distance.SafeSmall;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Rapid, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.PlungeAxisMovement = true;
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.SmallSafe)
      {
        double safeSmall = Distance.SafeSmall;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Leave, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.PlungeAxisMovement = true;
        CamPnt.Points.Add(Pnt);
      }
      this.Pnt9LastPoint = new Pnt9D(Pnt.P9);
    }
    else if (isLast)
    {
      if (Operation.SafeLeaveForLastPoint == CamSafeForLeave.Air | Operation.SafeLeaveForLastPoint == CamSafeForLeave.SafeThenAir | Operation.SafeLeaveForLastPoint == CamSafeForLeave.SmallSafeThenAir)
      {
        double air = Distance.Air;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Leave, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.LeaveAxisMovement = true;
        CamPnt.EntitiesLeave.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), new Pnt3D(Pnt), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafeLeaveForLastPoint == CamSafeForLeave.Safe | Operation.SafeLeaveForLastPoint == CamSafeForLeave.SmallSafeThenSafe)
      {
        double safe = Distance.Safe;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Leave, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.LeaveAxisMovement = true;
        CamPnt.EntitiesLeave.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), new Pnt3D(Pnt), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafeLeaveForLastPoint == CamSafeForLeave.SmallSafe)
      {
        double safeSmall = Distance.SafeSmall;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Leave, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.LeaveAxisMovement = true;
        CamPnt.EntitiesLeave.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), new Pnt3D(Pnt), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
        CamPnt.Points.Add(Pnt);
      }
      this.Pnt9LastPoint = new Pnt9D(Pnt.P9);
    }
    else if (isPlunge)
    {
      if (Pnt3D.EqualXY(new Pnt3D(PointActual), new Pnt3D(this.Pnt9LastPoint.X, this.Pnt9LastPoint.Y, this.Pnt9LastPoint.Z)) && Operation.SafePlungeForIfLastAndNextPointSameXY == CamSafeForPlunge.NotMove)
        return;
      if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.Air)
      {
        double air = Distance.Air;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0);
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.AirThenSafe)
      {
        double air = Distance.Air;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt9DCam pnt9Dcam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0);
        CamPnt.Points.Add(pnt9Dcam);
        double safe = Distance.Safe;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.PlungeAxisMovement = true;
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.AirThenSmallSafe)
      {
        double air = Distance.Air;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt9DCam pnt9Dcam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Rapid, 0);
        CamPnt.Points.Add(pnt9Dcam);
        double safeSmall = Distance.SafeSmall;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Rapid, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.PlungeAxisMovement = true;
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.Safe)
      {
        double safe = Distance.Safe;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0);
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.SafeThenSmallSafe)
      {
        double safe = Distance.Safe;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt9DCam pnt9Dcam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Rapid, 0);
        CamPnt.Points.Add(pnt9Dcam);
        double safeSmall = Distance.SafeSmall;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Rapid, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.PlungeAxisMovement = true;
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.SmallSafe)
      {
        double safeSmall = Distance.SafeSmall;
        CamPnt.Points.Add(new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Rapid, 0)
        {
          PlungeAxis = "Z",
          PlungeAxisMovement = true
        });
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Rapid, 0);
        CamPnt.Points.Add(Pnt);
      }
      this.Pnt9LastPoint = new Pnt9D(Pnt.P9);
    }
    else if (isLeave)
    {
      if (Pnt3D.EqualXY(new Pnt3D(PointActual), new Pnt3D(PointNext.X, PointNext.Y, PointNext.Z)) && Operation.SafeLeaveForIfLastAndNextPointSameXY == CamSafeForLeave.NotMove)
        return;
      if (Operation.SafeLeaveForContoutToContour == CamSafeForLeave.Air | Operation.SafeLeaveForContoutToContour == CamSafeForLeave.SafeThenAir | Operation.SafeLeaveForContoutToContour == CamSafeForLeave.SmallSafeThenAir)
      {
        double air = Distance.Air;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, air), Speed.Leave, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.LeaveAxisMovement = true;
        CamPnt.EntitiesLeave.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), new Pnt3D(Pnt), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafeLeaveForContoutToContour == CamSafeForLeave.Safe | Operation.SafeLeaveForContoutToContour == CamSafeForLeave.SmallSafeThenSafe)
      {
        double safe = Distance.Safe;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safe), Speed.Leave, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.LeaveAxisMovement = true;
        CamPnt.EntitiesLeave.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), new Pnt3D(Pnt), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
        CamPnt.Points.Add(Pnt);
      }
      if (Operation.SafeLeaveForContoutToContour == CamSafeForLeave.SmallSafe)
      {
        double safeSmall = Distance.SafeSmall;
        Pnt = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, safeSmall), Speed.Leave, 0);
        Pnt.PlungeAxis = "Z";
        Pnt.LeaveAxisMovement = true;
        CamPnt.EntitiesLeave.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), new Pnt3D(Pnt), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
        CamPnt.Points.Add(Pnt);
      }
      this.Pnt9LastPoint = new Pnt9D(Pnt.P9);
    }
    else if (!(isFirst | isLast))
      ;
  }

  public void camPoint(
    List<Pnt3D> RefPoints,
    ToolBase Tool,
    WorkPlane Plane,
    camSpeeds Speed,
    camDistances Distance,
    camStep Steps,
    camOperation Operation,
    camOptions Options,
    ref camBase CamCalculated)
  {
    CamCalculated.Name = "Point  ";
    CamPoint camPoint1 = new CamPoint();
    Pnt9DCam pnt9Dcam1 = new Pnt9DCam();
    Pnt3D pnt3D1 = new Pnt3D();
    Pnt3D First = new Pnt3D();
    CamCalculated.CamType = CamType.Point;
    if (Operation.StepHeights.Count == 0)
      Operation.StepHeights.Add(Operation.Height);
    for (int index1 = 0; index1 <= RefPoints.Count - 1; ++index1)
    {
      CamPoint camPoint2 = new CamPoint();
      Pnt3D pnt3D2 = new Pnt3D(RefPoints[index1]);
      camPoint2.Points.Add(new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, Distance.Safe), Speed.Leave, 0)
      {
        PlungeAxis = "Z",
        PlungeAxisMovement = true
      });
      for (int index2 = 0; index2 <= Operation.StepHeights.Count - 1; ++index2)
      {
        if (index2 == 0)
        {
          Pnt3D pnt3D3 = new Pnt3D(RefPoints[index1]);
          Pnt9DCam pnt9Dcam2 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, Distance.Safe), Speed.Rapid, 0);
          camPoint2.Points.Add(pnt9Dcam2);
          Pnt3D pnt3D4 = new Pnt3D(pnt3D3.X, pnt3D3.Y, Distance.Safe);
          Pnt3D pnt3D5 = new Pnt3D(RefPoints[index1]);
          camPoint2.Points.Add(new Pnt9DCam(new Pnt6D(pnt3D5.X, pnt3D5.Y, Distance.SafeSmall), Speed.Rapid, 0)
          {
            PlungeAxis = "Z",
            PlungeAxisMovement = true
          });
          First = new Pnt3D(pnt3D5.X, pnt3D5.Y, Distance.Safe);
        }
        Pnt3D pnt3D6 = new Pnt3D(RefPoints[index1].X, RefPoints[index1].Y, Operation.StepHeights[index2]);
        Pnt9DCam pnt9Dcam3 = new Pnt9DCam(new Pnt6D(pnt3D6.X, pnt3D6.Y, pnt3D6.Z), Speed.Plunge, 1);
        camPoint2.Points.Add(pnt9Dcam3);
        camPoint2.EntitiesG1.Add((geoEntity) new geoLine(First, pnt3D6));
        camPoint2.EntitiesOther.Add((geoEntity) new geoCircle(pnt3D6, Tool.Geometry.Diameter / 2.0));
        Pnt3D pnt3D7 = new Pnt3D(pnt3D6.X, pnt3D6.Y, pnt3D6.Z);
        if (index2 < Operation.StepHeights.Count - 1)
        {
          Pnt3D pnt3D8 = new Pnt3D(RefPoints[index1]);
          Pnt9DCam pnt9Dcam4 = new Pnt9DCam(new Pnt6D(pnt3D8.X, pnt3D8.Y, pnt3D7.Z + Steps.MoveUp), Speed.Rapid, 0);
          camPoint2.Points.Add(pnt9Dcam4);
          First = new Pnt3D(pnt3D8.X, pnt3D8.Y, pnt3D7.Z + Steps.MoveUp);
        }
        else
        {
          Pnt3D pnt3D9 = new Pnt3D(RefPoints[index1]);
          Pnt9DCam pnt9Dcam5 = new Pnt9DCam(new Pnt6D(pnt3D9.X, pnt3D9.Y, Distance.Safe), Speed.Rapid, 0);
          camPoint2.Points.Add(pnt9Dcam5);
          First = new Pnt3D(pnt3D9.X, pnt3D9.Y, Distance.Safe);
        }
      }
      this.SimPointCreat(camPoint2.Points, 0.25, 0.1, 3.0, ref camPoint2.SimilationPoint);
      if (camPoint2.Points.Count > 0)
      {
        CamCalculated.CamPoints.Add(camPoint2);
        camPoint1 = new CamPoint();
      }
    }
  }

  public void camPocketCircular(
    ContourPoints RefPoint,
    double Offset,
    OffsetCornerType CornerTypes,
    camPocket Pocket,
    WorkPlane Plane,
    double PlaneOffset,
    ClockDirectionType NeededDirection,
    camSpeeds Speed,
    camDistances Distance,
    camStep Steps,
    camOperation Operation,
    camOptions Options,
    ref camBase CamCalculated,
    ref List<PocketPoints> Pockets,
    ref List<List<eEntities>> PocketEntities)
  {
    if (Offset > 0.0)
      Offset *= -1.0;
    int num1 = 0;
    bool flag1 = true;
    Pnt3D pnt3D1 = new Pnt3D();
    Pnt3D Pnt1 = new Pnt3D();
    List<Pnt3D> CopiedPnt1 = new List<Pnt3D>();
    List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
    List<List<Pnt3D>> InnerPoints = new List<List<Pnt3D>>();
    List<List<Pnt3D>> RefPoints = new List<List<Pnt3D>>();
    List<List<Pnt3D>> CopiedPnt3 = new List<List<Pnt3D>>();
    PocketPoints pocketPoints = new PocketPoints();
    List<eEntities> eEntitiesList1 = new List<eEntities>();
    bool Closed;
    if (Closed = buAppCalc.cVector.IsClosed(RefPoint.Outter))
      Pnt3D.Copy(RefPoint.Outter, ref CopiedPnt1);
    for (int index = 0; index <= RefPoint.Holes.Count - 1; ++index)
    {
      if (Closed = buAppCalc.cVector.IsClosed(RefPoint.Holes[index]))
      {
        List<Pnt3D> CopiedPnt4 = new List<Pnt3D>();
        Pnt3D.Copy(RefPoint.Holes[index], ref CopiedPnt4);
        InnerPoints.Add(CopiedPnt4);
      }
    }
    if (CopiedPnt1.Count <= 0)
      return;
    Pnt3D pnt3D2 = new Pnt3D(CopiedPnt1[0]);
    Pnt3D.Copy(CopiedPnt1, ref CopiedPnt2);
    CopiedPnt3.Add(CopiedPnt2);
    do
    {
      List<List<Pnt3D>> OffsetedPoints = new List<List<Pnt3D>>();
      List<List<Pnt3D>> TargetList = new List<List<Pnt3D>>();
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      if (num1 != 0)
      {
        for (int index = 0; index <= CopiedPnt3.Count - 1; ++index)
        {
          if (InnerPoints.Count == 0)
            buAppCalc.cVector.OffsetContour(CopiedPnt3[index], Offset, CornerTypes, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
          else
            buAppCalc.cVector.OffsetContour(CopiedPnt3[index], InnerPoints, Offset, CornerTypes, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
          Pnt3D.Add(OffsetedPoints, ref TargetList);
        }
      }
      else
        goto label_39;
label_17:
      ++num1;
      CopiedPnt3.Clear();
      List<eEntities> CalcEntities;
      if (TargetList.Count == 1)
      {
        if (pocketPoints.Pockets.Count > 0)
        {
          pnt3DList = new List<Pnt3D>();
          Pnt3D.Copy(TargetList, ref pnt3DList);
          buAppCalc.cVector.ShiftPointsByLength(new Pnt3D(Pnt1), ref pnt3DList);
          pnt3DList.Add(new Pnt3D(pnt3DList[0]));
          buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref pnt3DList);
        }
        else
          Pnt3D.Copy(TargetList, ref pnt3DList);
        Pnt3D.Copy(TargetList, ref CopiedPnt3);
        if (buAppCalc.cVector.PolygonDirection(pnt3DList, new WorkPlane()) != NeededDirection)
          pnt3DList.Reverse();
        List<eEntities> eEntitiesList2 = new List<eEntities>();
        pocketPoints.Pockets.Add(pnt3DList);
        CalcEntities = new List<eEntities>();
        PointsToEntitiesPar pointsToEntitiesPar = new PointsToEntitiesPar();
        buAppCalc.cVector.PointsToEntities(pnt3DList, Plane, buSystem.PointsToEntities, ref CalcEntities);
        PocketEntities.Add(CalcEntities);
        Pnt1 = new Pnt3D(pnt3DList[pnt3DList.Count - 1]);
      }
      if (TargetList.Count > 1)
      {
        pnt3DList = new List<Pnt3D>();
        Pnt3D.Copy(TargetList[0], ref pnt3DList);
        buAppCalc.cVector.ShiftPointsByLength(new Pnt3D(Pnt1), ref pnt3DList);
        pnt3DList.Add(new Pnt3D(pnt3DList[0]));
        buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref pnt3DList);
        pocketPoints.Pockets.Add(pnt3DList);
        CalcEntities = new List<eEntities>();
        PointsToEntitiesPar pointsToEntitiesPar = new PointsToEntitiesPar();
        buAppCalc.cVector.PointsToEntities(pnt3DList, Plane, buSystem.PointsToEntities, ref CalcEntities);
        PocketEntities.Add(CalcEntities);
        CopiedPnt3.Add(pnt3DList);
        Pnt1 = new Pnt3D(pnt3DList[pnt3DList.Count - 1]);
        for (int index = 1; index <= TargetList.Count - 1; ++index)
        {
          if (buAppCalc.cVector.PolygonDirection(TargetList[index], new WorkPlane()) != NeededDirection)
            TargetList[index].Reverse();
          pnt3DList = new List<Pnt3D>();
          Pnt3D.Copy(TargetList[index], ref pnt3DList);
          if (!buAppCalc.cVector.IsPointsSame(RefPoints, pnt3DList))
            RefPoints.Add(pnt3DList);
        }
      }
      if (TargetList.Count == 0 & RefPoints.Count == 0)
        flag1 = false;
      if (TargetList.Count == 0 & RefPoints.Count > 0)
      {
        CopiedPnt1.Clear();
        pnt3DList = new List<Pnt3D>();
        if (buAppCalc.cVector.PolygonDirection(RefPoints[0], new WorkPlane()) != NeededDirection)
          RefPoints[0].Reverse();
        Pnt3D.Copy(RefPoints[0], ref pnt3DList);
        pocketPoints.Pockets.Add(pnt3DList);
        CalcEntities = new List<eEntities>();
        PointsToEntitiesPar Pars = new PointsToEntitiesPar();
        buAppCalc.cVector.PointsToEntities(pnt3DList, Plane, Pars, ref CalcEntities);
        PocketEntities.Add(CalcEntities);
        CopiedPnt3.Add(pnt3DList);
        RefPoints.RemoveAt(0);
      }
      TargetList.Clear();
      continue;
label_39:
      for (int index1 = 0; index1 <= CopiedPnt3.Count - 1; ++index1)
      {
        if (InnerPoints.Count == 0)
          buAppCalc.cVector.OffsetContour(CopiedPnt3[index1], Offset, CornerTypes, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
        else
          buAppCalc.cVector.OffsetContour(CopiedPnt3[index1], InnerPoints, Offset, CornerTypes, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
        List<eEntities> CalcEnt = new List<eEntities>();
        buAppCalc.cVector.AddPointOffsetedPath(OffsetedPoints, CopiedPnt2, Offset, Closed, NeededDirection, 0.1, ref CalcEnt);
        for (int index2 = 0; index2 <= CalcEnt.Count - 1; ++index2)
        {
          pnt3DList = new List<Pnt3D>();
          Pnt3D.Copy(CalcEnt[index2].Vertice, ref pnt3DList);
          buAppCalc.cVector.ShiftPointsByLength(pnt3D2, ref pnt3DList);
          pnt3DList.Add(new Pnt3D(pnt3DList[0]));
          buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref pnt3DList);
          TargetList.Add(pnt3DList);
        }
        if (TargetList.Count > 1)
        {
          for (int index3 = 0; index3 <= TargetList.Count - 1; ++index3)
          {
            for (int index4 = 1; index4 <= TargetList.Count - 1; ++index4)
            {
              if (buAppCalc.cVector.Length3D(pnt3D2, TargetList[index4][0]) < buAppCalc.cVector.Length3D(pnt3D2, TargetList[index4 - 1][0]))
              {
                List<Pnt3D> CopiedPnt5 = new List<Pnt3D>();
                List<Pnt3D> CopiedPnt6 = new List<Pnt3D>();
                Pnt3D.Copy(TargetList[index4 - 1], ref CopiedPnt5);
                Pnt3D.Copy(TargetList[index4], ref CopiedPnt6);
                TargetList[index4 - 1] = CopiedPnt6;
                TargetList[index4] = CopiedPnt5;
              }
            }
          }
        }
      }
      goto label_17;
    }
    while (flag1);
    Pockets.Add(pocketPoints);
    CamCalculated.Name = "Pocket : " + NeededDirection.ToString();
    CamPoint camPoint1 = new CamPoint();
    Pnt9DCam pnt9Dcam1 = new Pnt9DCam();
    Pnt3D pnt3D3 = new Pnt3D();
    Pnt3D pnt3D4 = new Pnt3D();
    bool flag2 = false;
    if (Operation.StepHeights.Count == 0)
      Operation.StepHeights.Add(Operation.Height);
    CamPoint camPoint2 = new CamPoint();
    for (int index5 = 0; index5 <= Operation.StepHeights.Count - 1; ++index5)
    {
      bool flag3 = true;
      if (Pocket.UsePoints)
      {
        for (int index6 = 0; index6 <= pocketPoints.Pockets.Count - 1; ++index6)
        {
          bool flag4 = false;
          Pnt3D EndPoint = new Pnt3D();
          if (index6 < pocketPoints.Pockets.Count - 1 && pocketPoints.Pockets[index6 + 1].Count > 1)
          {
            flag4 = true;
            EndPoint = new Pnt3D(pocketPoints.Pockets[index6 + 1][0]);
          }
          if (pocketPoints.Pockets[index6].Count > 0)
          {
            List<Pnt3D> pnt3DList = new List<Pnt3D>();
            Pnt3D.Copy(pocketPoints.Pockets[index6], ref pnt3DList);
            Pnt3D.SetValue(Operation.StepHeights[index5], AxesXYZ.Z, ref pnt3DList);
            if (flag3)
            {
              double z = Distance.Safe;
              if (index5 > 0 & Operation.PocketStepToStepSmallSafe)
                z = Distance.SafeSmall;
              camPoint2.Points.Add(new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, z), Speed.Rapid, 0)
              {
                PlungeAxis = "Z",
                PlungeAxisMovement = true
              });
              Pnt3D pnt3D5 = new Pnt3D(pnt3DList[0]);
              Pnt9DCam pnt9Dcam2 = new Pnt9DCam(new Pnt6D(pnt3D5.X, pnt3D5.Y, z), Speed.Rapid, 0);
              camPoint2.Points.Add(pnt9Dcam2);
              Pnt3D First = new Pnt3D(pnt3D5.X, pnt3D5.Y, z);
              if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.SafeThenSmallSafe)
              {
                camPoint2.Points.Add(new Pnt9DCam(new Pnt6D(pnt3D5.X, pnt3D5.Y, Distance.SafeSmall), Speed.Rapid, 0)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
                First = new Pnt3D(pnt3D5.X, pnt3D5.Y, Distance.SafeSmall);
              }
              pnt3D3 = new Pnt3D(pnt3DList[0].X, pnt3DList[0].Y, Operation.StepHeights[index5]);
              Pnt9DCam pnt9Dcam3 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z), Speed.Plunge, 1);
              camPoint2.Points.Add(pnt9Dcam3);
              camPoint2.EntitiesG1.Add((geoEntity) new geoLine(First, pnt3D3));
              pnt3D4 = new Pnt3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
              pnt3DList.RemoveAt(0);
            }
            for (int index7 = 0; index7 <= pnt3DList.Count - 1; ++index7)
            {
              pnt3D3 = new Pnt3D(pnt3DList[index7].X, pnt3DList[index7].Y, Operation.StepHeights[index5]);
              Pnt3D First = new Pnt3D(pnt3D3);
              Pnt9DCam pnt9Dcam4 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z), Speed.Feed, 1);
              camPoint2.Points.Add(pnt9Dcam4);
              camPoint2.EntitiesG1.Add((geoEntity) new geoLine(First, pnt3D3));
              pnt3D4 = new Pnt3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
            }
            flag3 = false;
            if (flag4)
            {
              double num2 = buAppCalc.cVector.Length3D(pnt3D4, EndPoint, Plane);
              if (Options.PocketNextContourMaxDistance <= 0.0)
                ;
              if (buAppCalc.cVector.IsLineIntersectContourPoints(pnt3D4, EndPoint, RefPoint, Plane) | num2 > Math.Abs(Offset) * 2.0 && camPoint2.Points.Count > 0)
              {
                pnt3D3 = new Pnt3D(pnt3D4);
                Pnt9DCam pnt9Dcam5 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, Distance.Safe), Speed.Leave, 0);
                camPoint2.Points.Add(pnt9Dcam5);
                this.SimPointCreat(camPoint2.Points, 0.25, 0.1, 3.0, ref camPoint2.SimilationPoint);
                CamCalculated.CamPoints.Add(camPoint2);
                camPoint2 = new CamPoint();
                flag3 = true;
              }
            }
          }
        }
      }
      if (!Pocket.UsePoints)
      {
        Pnt9DCam pnt9Dcam6 = new Pnt9DCam();
        for (int index8 = 0; index8 <= PocketEntities.Count - 1; ++index8)
        {
          bool flag5 = false;
          Pnt3D EndPoint = new Pnt3D();
          Pnt3D pnt3D6 = new Pnt3D();
          if (index8 < PocketEntities.Count - 1 && PocketEntities[index8 + 1].Count > 1)
          {
            flag5 = true;
            EndPoint = PocketEntities[index8 + 1][0].camDirections != camPathDirectionType.Normal ? new Pnt3D(PocketEntities[index8 + 1][0].Vertice[PocketEntities[index8 + 1][0].Vertice.Count - 1]) : new Pnt3D(PocketEntities[index8 + 1][0].Vertice[0]);
          }
          if (PocketEntities[index8].Count > 0)
          {
            Pnt3D Pnt2 = PocketEntities[index8][0].camDirections != camPathDirectionType.Normal ? new Pnt3D(PocketEntities[index8][0].Vertice[PocketEntities[index8][0].Vertice.Count - 1]) : new Pnt3D(PocketEntities[index8][0].Vertice[0]);
            if (flag3)
            {
              double z = Distance.Safe;
              if (index5 > 0 & Operation.PocketStepToStepSmallSafe)
                z = Distance.SafeSmall;
              camPoint2.Points.Add(new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, z), Speed.Rapid, 0)
              {
                PlungeAxis = "Z",
                PlungeAxisMovement = true
              });
              Pnt3D pnt3D7 = new Pnt3D(Pnt2);
              Pnt9DCam pnt9Dcam7 = new Pnt9DCam(new Pnt6D(pnt3D7.X, pnt3D7.Y, z), Speed.Rapid, 0);
              camPoint2.Points.Add(pnt9Dcam7);
              Pnt3D First = new Pnt3D(pnt3D7.X, pnt3D7.Y, z);
              if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.SafeThenSmallSafe)
              {
                camPoint2.Points.Add(new Pnt9DCam(new Pnt6D(pnt3D7.X, pnt3D7.Y, Distance.SafeSmall), Speed.Rapid, 0)
                {
                  PlungeAxis = "Z",
                  PlungeAxisMovement = true
                });
                First = new Pnt3D(pnt3D7.X, pnt3D7.Y, Distance.SafeSmall);
              }
              pnt3D3 = new Pnt3D(Pnt2.X, Pnt2.Y, Operation.StepHeights[index5]);
              Pnt9DCam pnt9Dcam8 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z), Speed.Plunge, 1);
              camPoint2.Points.Add(pnt9Dcam8);
              camPoint2.EntitiesG1.Add((geoEntity) new geoLine(First, pnt3D3));
              pnt3D4 = new Pnt3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
              this.Pnt9LastPoint = new Pnt9D(pnt3D4);
            }
            else
            {
              pnt3D3 = new Pnt3D(Pnt2.X, Pnt2.Y, Operation.StepHeights[index5]);
              Pnt9DCam pnt9Dcam9 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z), Speed.Feed, 1);
              camPoint2.Points.Add(pnt9Dcam9);
              camPoint2.EntitiesG1.Add((geoEntity) new geoLine(pnt3D4, pnt3D3));
              pnt3D4 = new Pnt3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
              this.Pnt9LastPoint = new Pnt9D(pnt3D4);
            }
            for (int index9 = 0; index9 <= PocketEntities[index8].Count - 1; ++index9)
            {
              List<Pnt3D> vertice = new List<Pnt3D>();
              Pnt3D.Copy(PocketEntities[index8][index9].Vertice, ref vertice);
              Pnt3D.SetValue(Operation.StepHeights[index5], AxesXYZ.Z, ref vertice);
              if (PocketEntities[index8][index9].camDirections == camPathDirectionType.Reverse)
                vertice.Reverse();
              if (PocketEntities[index8][index9].GetType() != typeof (eArc))
              {
                vertice.RemoveAt(0);
                for (int index10 = 0; index10 <= vertice.Count - 1; ++index10)
                {
                  pnt3D3 = new Pnt3D(vertice[index10].X, vertice[index10].Y, Operation.StepHeights[index5]);
                  Pnt9DCam pnt9Dcam10 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z), Speed.Feed, 1);
                  camPoint2.Points.Add(pnt9Dcam10);
                  camPoint2.EntitiesG1.Add((geoEntity) new geoLine(new Pnt3D(this.Pnt9LastPoint), pnt3D3));
                  this.Pnt9LastPoint = new Pnt9D(pnt9Dcam10.P9);
                }
              }
              else
              {
                eArc eArc = new eArc(new Pnt3D(((ePlaneEntities) PocketEntities[index8][index9]).CenterPoint.X, ((ePlaneEntities) PocketEntities[index8][index9]).CenterPoint.Y, Operation.StepHeights[index5]), ((eCircle) PocketEntities[index8][index9]).Radius, ((eArc) PocketEntities[index8][index9]).StartAngle, ((eArc) PocketEntities[index8][index9]).EndAngle, ((ePlaneEntities) PocketEntities[index8][index9]).Plane);
                int type = 3;
                if (PocketEntities[index8][index9].camDirections == camPathDirectionType.Reverse)
                  type = 2;
                pnt3D3 = new Pnt3D(vertice[vertice.Count - 1].X, vertice[vertice.Count - 1].Y, Operation.StepHeights[index5]);
                Pnt9DCam pnt9Dcam11 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z), Speed.Feed, type);
                pnt9Dcam11.Radius = eArc.Radius;
                pnt9Dcam11.ArcType = type;
                pnt9Dcam11.ArcData = new geoArc(eArc.CenterPoint, eArc.Radius, eArc.StartAngle, eArc.EndAngle, eArc.Plane);
                camPoint2.Points.Add(pnt9Dcam11);
                camPoint2.EntitiesG1.Add((geoEntity) new geoPolyline(vertice));
                this.Pnt9LastPoint = new Pnt9D(pnt9Dcam11.P9);
              }
            }
            flag3 = false;
            if (flag5)
            {
              double num3 = buAppCalc.cVector.Length3D(pnt3D4, EndPoint, Plane);
              if (Options.PocketNextContourMaxDistance <= 0.0)
                ;
              if (buAppCalc.cVector.IsLineIntersectContourPoints(pnt3D4, EndPoint, RefPoint, Plane) | num3 > Math.Abs(Offset) * 2.0 && camPoint2.Points.Count > 0)
              {
                pnt3D3 = new Pnt3D(pnt3D4);
                Pnt9DCam pnt9Dcam12 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, Distance.Safe), Speed.Leave, 0);
                camPoint2.Points.Add(pnt9Dcam12);
                this.SimPointCreat(camPoint2.Points, 0.25, 0.1, 3.0, ref camPoint2.SimilationPoint);
                CamCalculated.CamPoints.Add(camPoint2);
                camPoint2 = new CamPoint();
                flag3 = true;
              }
            }
          }
        }
        if (camPoint2.Points.Count > 0)
        {
          pnt3D3 = new Pnt3D(pnt3D4);
          Pnt9DCam pnt9Dcam13 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, Distance.Safe), Speed.Leave, 0);
          camPoint2.Points.Add(pnt9Dcam13);
          this.SimPointCreat(camPoint2.Points, 0.25, 0.1, 3.0, ref camPoint2.SimilationPoint);
          CamCalculated.CamPoints.Add(camPoint2);
          camPoint2 = new CamPoint();
          flag2 = true;
        }
      }
      if (camPoint2.Points.Count > 0)
      {
        double z = Distance.Safe;
        if (index5 < Operation.StepHeights.Count - 1 & Operation.PocketStepToStepSmallSafe)
          z = Distance.SafeSmall;
        pnt3D3 = new Pnt3D(pnt3D4);
        Pnt9DCam pnt9Dcam14 = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, z), Speed.Leave, 0);
        camPoint2.Points.Add(pnt9Dcam14);
        this.SimPointCreat(camPoint2.Points, 0.25, 0.1, 3.0, ref camPoint2.SimilationPoint);
      }
      if (camPoint2.Points.Count > 0)
      {
        CamCalculated.CamPoints.Add(camPoint2);
        camPoint2 = new CamPoint();
      }
    }
  }

  public void CamFlatPocket(
    List<Pnt3D> OutsideContour,
    List<List<Pnt3D>> Holes,
    double Step,
    double Offset,
    double PlaneOffset,
    CamFlatPocketType Type,
    CamFlatPocketSortType Sort,
    WorkPlane Plane,
    ref List<eEntities> CalcEntities)
  {
    List<List<Pnt3D>> OffsetedPoints1 = new List<List<Pnt3D>>();
    List<List<Pnt3D>> CheckPoints = new List<List<Pnt3D>>();
    if (Step <= 0.0)
      return;
    buAppCalc.cVector.OffsetContour(OutsideContour, Math.Abs(Offset) * -1.0, OffsetCornerType.Line, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints1);
    for (int index1 = 0; index1 <= Holes.Count - 1; ++index1)
    {
      List<List<Pnt3D>> OffsetedPoints2 = new List<List<Pnt3D>>();
      buAppCalc.cVector.OffsetContour(Holes[index1], Math.Abs(Offset), OffsetCornerType.Line, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints2);
      for (int index2 = 0; index2 <= OffsetedPoints2.Count - 1; ++index2)
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        Pnt3D.Copy(OffsetedPoints2[index2], ref CopiedPnt);
        CheckPoints.Add(CopiedPnt);
      }
    }
    Pnt3D MaxPoint = new Pnt3D();
    Pnt3D MinPoint = new Pnt3D();
    buAppCalc.cVector.BoxSizeCalculate(OffsetedPoints1, ref MinPoint, ref MaxPoint);
    List<eLine> eLineList = new List<eLine>();
    double num1 = MaxPoint.X - MinPoint.X + 2.0;
    double num2 = MaxPoint.Y - MinPoint.Y + 2.0;
    if (Type == CamFlatPocketType.Horizontal)
    {
      int int32 = Convert.ToInt32(num2 / Math.Abs(Step));
      double num3 = num2 / Convert.ToDouble(int32);
      for (int index = 0; index <= int32; ++index)
      {
        if (index == 0)
        {
          eLine eLine = new eLine(new Pnt3D(MinPoint.X - 1.0, MinPoint.Y + 1.0 + (double) index * num3), new Pnt3D(MaxPoint.X + 1.0, MinPoint.Y + 1.0 + (double) index * num3));
          eLineList.Add(eLine);
        }
        else if (index > 0 & index < int32)
        {
          eLine eLine = new eLine(new Pnt3D(MinPoint.X - 1.0, MinPoint.Y + (double) index * num3), new Pnt3D(MaxPoint.X + 1.0, MinPoint.Y + (double) index * num3));
          eLineList.Add(eLine);
        }
        else
        {
          eLine eLine = new eLine(new Pnt3D(MinPoint.X - 1.0, MaxPoint.Y - 1.0), new Pnt3D(MaxPoint.X + 1.0, MaxPoint.Y - 1.0));
          eLineList.Add(eLine);
        }
      }
    }
    if (Type == CamFlatPocketType.Vertical)
    {
      int int32 = Convert.ToInt32(num1 / Math.Abs(Step));
      double num4 = num1 / Convert.ToDouble(int32);
      for (int index = 0; index <= int32; ++index)
      {
        if (index == 0)
        {
          eLine eLine = new eLine(new Pnt3D(MinPoint.X + 1.0, MinPoint.Y - 1.0), new Pnt3D(MinPoint.X + 1.0, MaxPoint.Y + 1.0));
          eLineList.Add(eLine);
        }
        else if (index > 0 & index < int32)
        {
          eLine eLine = new eLine(new Pnt3D(MinPoint.X + (double) index * num4, MinPoint.Y - 1.0), new Pnt3D(MinPoint.X + (double) index * num4, MaxPoint.Y + 1.0));
          eLineList.Add(eLine);
        }
        else
        {
          eLine eLine = new eLine(new Pnt3D(MaxPoint.X - 1.0, MinPoint.Y - 1.0), new Pnt3D(MaxPoint.X - 1.0, MaxPoint.Y + 1.0));
          eLineList.Add(eLine);
        }
      }
    }
    List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
    for (int index3 = 0; index3 <= eLineList.Count - 1; ++index3)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index4 = 0; index4 <= OffsetedPoints1.Count - 1; ++index4)
      {
        for (int index5 = 1; index5 <= OffsetedPoints1[index4].Count - 1; ++index5)
        {
          Pnt3D IntersectionPoint = new Pnt3D();
          buAppCalc.cVector.LineLineIntersection(eLineList[index3].StartPoint, eLineList[index3].EndPoint, OffsetedPoints1[index4][index5 - 1], OffsetedPoints1[index4][index5], Plane, ref IntersectionPoint);
          if (buAppCalc.cVector.IsPointInsideLine(OffsetedPoints1[index4][index5 - 1], OffsetedPoints1[index4][index5], IntersectionPoint, Plane))
            pnt3DList.Add(IntersectionPoint);
          else if (!buAppCalc.cVector.IsPointInsidePolygon(OffsetedPoints1[index4], IntersectionPoint))
            ;
        }
      }
      for (int index6 = 0; index6 <= CheckPoints.Count - 1; ++index6)
      {
        for (int index7 = 1; index7 <= CheckPoints[index6].Count - 1; ++index7)
        {
          Pnt3D IntersectionPoint = new Pnt3D();
          buAppCalc.cVector.LineLineIntersection(eLineList[index3].StartPoint, eLineList[index3].EndPoint, CheckPoints[index6][index7 - 1], CheckPoints[index6][index7], Plane, ref IntersectionPoint);
          if (buAppCalc.cVector.IsPointInsideLine(CheckPoints[index6][index7 - 1], CheckPoints[index6][index7], IntersectionPoint, Plane))
            pnt3DList.Add(IntersectionPoint);
        }
      }
      if (pnt3DList.Count > 0)
        pnt3DListList.Add(pnt3DList);
    }
    List<eEntities> baseEnt = new List<eEntities>();
    List<eEntities> CopiedEnt = new List<eEntities>();
    CalcEntities = new List<eEntities>();
    for (int index8 = 0; index8 <= pnt3DListList.Count - 1; ++index8)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      Pnt3D.Copy(pnt3DListList[index8], ref pnt3DList);
      buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref pnt3DList);
      if (Type == CamFlatPocketType.Horizontal)
        buAppCalc.cVector.SortQuickDeltaX(MinPoint, 0, pnt3DList.Count - 1, ref pnt3DList);
      if (Type == CamFlatPocketType.Vertical)
        buAppCalc.cVector.SortQuickDeltaY(MinPoint, 0, pnt3DList.Count - 1, ref pnt3DList);
      double num5 = (double) (pnt3DList.Count % 2);
      if (num5 == 1.0)
      {
        int num6 = (int) MessageBox.Show("Tek Sayı");
      }
      if (num5 == 0.0)
      {
        for (int index9 = 0; index9 <= pnt3DList.Count - 1; index9 += 2)
        {
          eLine eLine = new eLine(pnt3DList[index9], pnt3DList[index9 + 1]);
          baseEnt.Add((eEntities) eLine);
        }
      }
    }
    int num7 = 1;
    CalcEntities.Add(eEntities.CopyEntity(baseEnt[0]));
    Pnt3D pnt3D1 = new Pnt3D(baseEnt[0].Vertice[baseEnt[0].Vertice.Count - 1]);
    baseEnt.RemoveAt(0);
    eEntities.CopyEntities(baseEnt, ref CopiedEnt);
    for (int index10 = 0; index10 <= baseEnt.Count - 1; ++index10)
    {
      int index11 = -1;
      int num8 = 0;
      int index12 = -1;
      int num9 = 0;
      double num10 = double.MaxValue;
      double num11 = double.MaxValue;
      for (int index13 = 0; index13 <= CopiedEnt.Count - 1; ++index13)
      {
        Pnt3D pnt3D2 = new Pnt3D(CopiedEnt[index13].Vertice[0]);
        Pnt3D pnt3D3 = new Pnt3D(CopiedEnt[index13].Vertice[CopiedEnt[index13].Vertice.Count - 1]);
        double num12 = buAppCalc.cVector.Length3D(pnt3D2, pnt3D1);
        double num13 = buAppCalc.cVector.Length3D(pnt3D3, pnt3D1);
        double num14 = buAppCalc.cVector.DeltaX(pnt3D2, pnt3D1);
        double num15 = Math.Abs(buAppCalc.cVector.DeltaY(pnt3D2, pnt3D1));
        double num16 = buAppCalc.cVector.DeltaX(pnt3D3, pnt3D1);
        double num17 = Math.Abs(buAppCalc.cVector.DeltaY(pnt3D3, pnt3D1));
        double num18 = 0.0;
        double num19 = 0.0;
        double num20 = 0.0;
        double Degree1 = buAppCalc.cVector.PointAngle(pnt3D2, pnt3D1, Plane);
        if (Type == CamFlatPocketType.Horizontal)
        {
          double num21 = Math.Sin(buConversion.DegreeToRadian(Degree1));
          if (num21 != 0.0)
            num18 = Step / num21 * 1.1;
          num19 = num15;
          num20 = num17;
        }
        if (Type == CamFlatPocketType.Vertical)
        {
          double num22 = Math.Cos(buConversion.DegreeToRadian(Degree1));
          if (num22 != 0.0)
            num18 = Step / num22 * 1.1;
          num19 = num14;
          num20 = num16;
        }
        if (Sort == CamFlatPocketSortType.ByClosestLength && num12 < num10 & num19 < Step * 2.0 & num12 < num18 & num7 == 0 && !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D1, pnt3D2, false, Plane, buSystem.resolutionCompare, OffsetedPoints1) & !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D2, pnt3D1, false, Plane, buSystem.resolutionCompare, CheckPoints))
        {
          num10 = num12;
          index11 = index13;
          num8 = 0;
        }
        if (Sort == CamFlatPocketSortType.ByDirection && num19 < num10 & num19 < Step * 2.0 & num12 < num18 & num7 == 0 && !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D1, pnt3D2, false, Plane, buSystem.resolutionCompare, OffsetedPoints1) & !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D2, pnt3D1, false, Plane, buSystem.resolutionCompare, CheckPoints))
        {
          num10 = num15;
          index11 = index13;
          num8 = 0;
        }
        double num23 = 0.0;
        double Degree2 = buAppCalc.cVector.PointAngle(pnt3D3, pnt3D1, Plane);
        if (Type == CamFlatPocketType.Horizontal)
        {
          double num24 = Math.Sin(buConversion.DegreeToRadian(Degree2));
          if (num24 != 0.0)
            num23 = Step / num24 * 1.1;
        }
        if (Type == CamFlatPocketType.Vertical)
        {
          double num25 = Math.Cos(buConversion.DegreeToRadian(Degree2));
          if (num25 != 0.0)
            num23 = Step / num25 * 1.1;
        }
        if (Sort == CamFlatPocketSortType.ByClosestLength && num13 < num10 & num20 < Step * 2.0 & num13 < num23 & num7 == 1 && !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D1, pnt3D3, false, Plane, buSystem.resolutionCompare, OffsetedPoints1) & !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D3, pnt3D1, false, Plane, buSystem.resolutionCompare, CheckPoints))
        {
          num10 = num13;
          index11 = index13;
          num8 = 1;
        }
        if (Sort == CamFlatPocketSortType.ByDirection && num20 < num10 & num20 < Step * 2.0 & num13 < num23 & num7 == 1 && !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D1, pnt3D3, false, Plane, buSystem.resolutionCompare, OffsetedPoints1) & !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D3, pnt3D1, false, Plane, buSystem.resolutionCompare, CheckPoints))
        {
          num10 = num17;
          index11 = index13;
          num8 = 1;
        }
        if (Sort == CamFlatPocketSortType.ByClosestLength)
        {
          if (num12 < num11)
          {
            num11 = num12;
            index12 = index13;
            num9 = 0;
          }
          if (num13 < num11)
          {
            num11 = num13;
            index12 = index13;
            num9 = 1;
          }
        }
        if (Sort == CamFlatPocketSortType.ByDirection)
        {
          if (num19 < num11)
          {
            num11 = num15;
            index12 = index13;
            num9 = 0;
          }
          if (num20 < num11)
          {
            num11 = num17;
            index12 = index13;
            num9 = 1;
          }
        }
      }
      if (index11 >= 0)
      {
        if (num8 == 0)
        {
          num7 = 1;
          eLine eLine1 = new eLine(pnt3D1, CopiedEnt[index11].Vertice[0]);
          CalcEntities.Add((eEntities) eLine1);
          eLine eLine2 = new eLine(CopiedEnt[index11].Vertice[0], CopiedEnt[index11].Vertice[CopiedEnt[index11].Vertice.Count - 1]);
          CalcEntities.Add((eEntities) eLine2);
          pnt3D1 = new Pnt3D(CalcEntities[CalcEntities.Count - 1].Vertice[CalcEntities[CalcEntities.Count - 1].Vertice.Count - 1]);
        }
        if (num8 == 1)
        {
          num7 = 0;
          eLine eLine3 = new eLine(pnt3D1, CopiedEnt[index11].Vertice[CopiedEnt[index11].Vertice.Count - 1]);
          CalcEntities.Add((eEntities) eLine3);
          eLine eLine4 = new eLine(CopiedEnt[index11].Vertice[CopiedEnt[index11].Vertice.Count - 1], CopiedEnt[index11].Vertice[0]);
          CalcEntities.Add((eEntities) eLine4);
          pnt3D1 = new Pnt3D(CalcEntities[CalcEntities.Count - 1].Vertice[CalcEntities[CalcEntities.Count - 1].Vertice.Count - 1]);
        }
        CopiedEnt.RemoveAt(index11);
      }
      else
      {
        if (num9 == 0)
        {
          eUpperLine eUpperLine = new eUpperLine(pnt3D1, CopiedEnt[index12].Vertice[0]);
          CalcEntities.Add((eEntities) eUpperLine);
          eLine eLine = new eLine(CopiedEnt[index12].Vertice[0], CopiedEnt[index12].Vertice[CopiedEnt[index12].Vertice.Count - 1]);
          CalcEntities.Add((eEntities) eLine);
          pnt3D1 = new Pnt3D(CalcEntities[CalcEntities.Count - 1].Vertice[CalcEntities[CalcEntities.Count - 1].Vertice.Count - 1]);
          num7 = 1;
        }
        if (num9 == 1)
        {
          eUpperLine eUpperLine = new eUpperLine(pnt3D1, CopiedEnt[index12].Vertice[CopiedEnt[index12].Vertice.Count - 1]);
          CalcEntities.Add((eEntities) eUpperLine);
          eLine eLine = new eLine(CopiedEnt[index12].Vertice[CopiedEnt[index12].Vertice.Count - 1], CopiedEnt[index12].Vertice[0]);
          CalcEntities.Add((eEntities) eLine);
          pnt3D1 = new Pnt3D(CalcEntities[CalcEntities.Count - 1].Vertice[CalcEntities[CalcEntities.Count - 1].Vertice.Count - 1]);
          num7 = 0;
        }
        CopiedEnt.RemoveAt(index12);
      }
    }
  }

  public void HatchCamCalculation(
    camHatch Hatch,
    camDistances Distances,
    camSpeeds Velocity,
    camStep Steps,
    camStrategy Strategy,
    camOperation Operations,
    camOptions Options,
    KinematicBase Kinematic,
    ToolBase Tool,
    ref camBase calcCam,
    ref List<eEntities> Entities)
  {
    if (Hatch.CutStep <= 0.0 || Hatch.TotalWidth <= 0.0 || Hatch.CutLength <= 0.0 || Hatch.CutStep > Hatch.TotalWidth)
      return;
    List<List<eEntities>> eEntitiesListList = new List<List<eEntities>>();
    Entities.Clear();
    int num1 = (int) buNumeric.RoundToLower(Hatch.TotalWidth / Hatch.CutStep);
    if (num1 == 0)
      num1 = 1;
    double num2 = Hatch.TotalWidth / (double) num1;
    if (Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
    {
      Pnt3D Pnt = new Pnt3D();
      List<eEntities> eEntitiesList = new List<eEntities>();
      for (int index = 0; index <= num1; ++index)
      {
        if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
        {
          double num3 = (double) index * num2;
          eEntities eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          eEntitiesListList.Add(eEntitiesList);
        }
        if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
        {
          eEntitiesList = new List<eEntities>();
          Strategy.OverrideCEnable = true;
          Strategy.OverrideC = 0.0;
          double num4 = (double) index * num2;
          eEntities eEntities1 = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num4, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num4, Hatch.OperationZ));
          Entities.Add(eEntities1);
          eEntitiesList.Add(eEntities1);
          eEntities eEntities2 = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num4, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num4, Hatch.OperationZ));
          Entities.Add(eEntities2);
          eEntitiesList.Add(eEntities2);
          eEntitiesListList.Add(eEntitiesList);
        }
        if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        {
          double y = (double) index * num2;
          eEntities eEntities = (eEntities) null;
          if (Entities.Count > 0)
          {
            eEntities = (eEntities) new eLine(new Pnt3D(Pnt), new Pnt3D(Pnt.X, y, Hatch.OperationZ));
            Entities.Add(eEntities);
            eEntitiesList.Add(eEntities);
          }
          if (index % 2 == 0)
            eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + y, Hatch.OperationZ));
          if (index % 2 == 1)
            eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + y, Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Pnt = new Pnt3D(eEntities.Vertice[eEntities.Vertice.Count - 1]);
        }
      }
      if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
      {
        Strategy.AngleLimit = 20.0;
        eEntitiesListList.Add(eEntitiesList);
      }
    }
    if (Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
    {
      Pnt3D Pnt = new Pnt3D();
      List<eEntities> eEntitiesList = new List<eEntities>();
      for (int index = 0; index <= num1; ++index)
      {
        if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
        {
          eEntitiesList = new List<eEntities>();
          double num5 = (double) index * num2;
          eEntities eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + num5, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num5, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          eEntitiesListList.Add(eEntitiesList);
        }
        if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
        {
          eEntitiesList = new List<eEntities>();
          Strategy.OverrideCEnable = true;
          Strategy.OverrideC = 90.0;
          double num6 = (double) index * num2;
          eEntities eEntities3 = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + num6, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num6, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
          Entities.Add(eEntities3);
          eEntitiesList.Add(eEntities3);
          eEntities eEntities4 = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + num6, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num6, Hatch.CornerPoint.Y, Hatch.OperationZ));
          Entities.Add(eEntities4);
          eEntitiesList.Add(eEntities4);
          eEntitiesListList.Add(eEntitiesList);
        }
        if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
        {
          double x = (double) index * num2;
          eEntities eEntities = (eEntities) null;
          if (Entities.Count > 0)
          {
            eEntities = (eEntities) new eLine(new Pnt3D(Pnt), new Pnt3D(x, Pnt.Y, Hatch.OperationZ));
            Entities.Add(eEntities);
            eEntitiesList.Add(eEntities);
          }
          if (index % 2 == 0)
            eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + x, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + x, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
          if (index % 2 == 1)
            eEntities = (eEntities) new eLine(new Pnt3D(Hatch.CornerPoint.X + x, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + x, Hatch.CornerPoint.Y, Hatch.OperationZ));
          Entities.Add(eEntities);
          eEntitiesList.Add(eEntities);
          Pnt = new Pnt3D(eEntities.Vertice[eEntities.Vertice.Count - 1]);
        }
      }
      if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
      {
        Strategy.AngleLimit = 20.0;
        eEntitiesListList.Add(eEntitiesList);
      }
    }
    List<List<Pnt3D>> Points = new List<List<Pnt3D>>();
    List<eEntities> SortedEntities = new List<eEntities>();
    buAppCalc.cSort.SortEntitiesByRefPoint(new Pnt3D(), ref Entities, new SortingOptions()
    {
      IntersectionRules = SortingIntersectionRulesType.LowerIndex,
      NextGroupRules = SortingNextGroupFindRulesType.ClosestLength
    }, ref SortedEntities);
    buAppCalc.cVector.EntityToPoint(SortedEntities, new EntityResolution(), ref Points);
    new marbleOperation().TargetZ = Hatch.OperationZ;
    List<List<Pnt3D>> pnt3DListList = new List<List<Pnt3D>>();
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      List<Pnt3D> CopiedPnt = new List<Pnt3D>();
      Pnt3D.Copy(Entities[index].Vertice, ref CopiedPnt);
      pnt3DListList.Add(CopiedPnt);
    }
    this.camClosedContour(new Pnt3D(), Points, 0.0, false, CamClosedContourType.Center, ClockDirectionType.CW, OffsetCornerType.Line, Tool, new WorkPlane(), Velocity, Distances, Steps, Operations, Options, ref calcCam);
  }

  public void LeadInOutCalculation(
    LeadInOutEntitiesProperties FirstEntity,
    LeadInOutEntitiesProperties LastEntitiy,
    LeadIn LeadInProp,
    LeadOut LeadOutProp,
    WorkPlane Plane,
    ClockDirectionType Direction,
    ref List<eEntities> LeadInEntitiy,
    ref List<eEntities> LeadOutEntitiy)
  {
    try
    {
      double pointTangentAngle1 = FirstEntity.PointTangentAngle;
      double pointTangentAngle2 = LastEntitiy.PointTangentAngle;
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt3D pnt3D2 = new Pnt3D();
      Pnt3D pnt3D3;
      if (FirstEntity.RefEntity.camDirections == camPathDirectionType.Reverse)
      {
        pnt3D3 = new Pnt3D(FirstEntity.RefEntity.Vertice[FirstEntity.RefEntity.Vertice.Count - 1]);
        if (LeadInProp.ExtendLength > 0.0)
        {
          Pnt3D EndPoint = new Pnt3D(pnt3D3);
          Pnt3D EndPnt = new Pnt3D();
          buAppCalc.cVector.LineWithLengthAndAngle(pnt3D3, LeadInProp.ExtendLength, FirstEntity.PointTangentAngle + 180.0, Plane, ref EndPnt);
          eEntities eEntities = (eEntities) new eLine(EndPnt, EndPoint);
          eEntities.Purpose = EntityPurposeType.LeadIn;
          LeadInEntitiy.Add(eEntities);
          pnt3D3 = new Pnt3D(EndPnt);
        }
      }
      else
      {
        pnt3D3 = new Pnt3D(FirstEntity.RefEntity.Vertice[0]);
        if (LeadInProp.ExtendLength > 0.0)
        {
          Pnt3D EndPoint = new Pnt3D(pnt3D3);
          Pnt3D EndPnt = new Pnt3D();
          buAppCalc.cVector.LineWithLengthAndAngle(pnt3D3, LeadInProp.ExtendLength, FirstEntity.PointTangentAngle + 180.0, Plane, ref EndPnt);
          eEntities eEntities = (eEntities) new eLine(EndPnt, EndPoint);
          eEntities.Purpose = EntityPurposeType.LeadIn;
          LeadInEntitiy.Add(eEntities);
          pnt3D3 = new Pnt3D(EndPnt);
        }
      }
      Pnt3D pnt3D4;
      if (LastEntitiy.RefEntity.camDirections == camPathDirectionType.Reverse)
      {
        pnt3D4 = new Pnt3D(LastEntitiy.RefEntity.Vertice[0]);
        if (LeadOutProp.ExtendLength > 0.0)
        {
          Pnt3D StartPoint = new Pnt3D(pnt3D4);
          Pnt3D EndPnt = new Pnt3D();
          buAppCalc.cVector.LineWithLengthAndAngle(pnt3D4, LeadOutProp.ExtendLength, LastEntitiy.PointTangentAngle, Plane, ref EndPnt);
          eEntities eEntities = (eEntities) new eLine(StartPoint, EndPnt);
          eEntities.Purpose = EntityPurposeType.LeadOut;
          LeadOutEntitiy.Add(eEntities);
          pnt3D4 = new Pnt3D(EndPnt);
        }
      }
      else
      {
        pnt3D4 = new Pnt3D(LastEntitiy.RefEntity.Vertice[LastEntitiy.RefEntity.Vertice.Count - 1]);
        if (LeadOutProp.ExtendLength > 0.0)
        {
          Pnt3D StartPoint = new Pnt3D(pnt3D4);
          Pnt3D EndPnt = new Pnt3D();
          buAppCalc.cVector.LineWithLengthAndAngle(pnt3D4, LeadOutProp.ExtendLength, LastEntitiy.PointTangentAngle, Plane, ref EndPnt);
          eEntities eEntities = (eEntities) new eLine(StartPoint, EndPnt);
          eEntities.Purpose = EntityPurposeType.LeadOut;
          LeadOutEntitiy.Add(eEntities);
          pnt3D4 = new Pnt3D(EndPnt);
        }
      }
      if (LeadInProp.LeadType == LeadInOutType.Line & LeadInProp.Enable)
      {
        Pnt3D EndPnt = new Pnt3D();
        double num = 1.0;
        if (LeadOutProp.ClockDir == ClockDirectionType.CCW)
          num = -1.0;
        buAppCalc.cVector.LineWithLengthAndAngle(pnt3D3, LeadInProp.Length, pointTangentAngle1 + 180.0 + LeadInProp.TangentAngle * num, Plane, ref EndPnt);
        eEntities eEntities = (eEntities) new eLine(EndPnt, pnt3D3);
        eEntities.Purpose = EntityPurposeType.LeadIn;
        LeadInEntitiy.Add(eEntities);
      }
      if (LeadInProp.LeadType == LeadInOutType.Arc & LeadInProp.Enable)
      {
        eArc eArc = (eArc) null;
        Pnt3D EndPnt = new Pnt3D();
        if (LeadInProp.ClockDir == ClockDirectionType.CW)
        {
          buAppCalc.cVector.LineWithLengthAndAngle(pnt3D3, LeadInProp.ArcRadius, pointTangentAngle1 - 90.0, Plane, ref EndPnt);
          double StartAngle = buAppCalc.cVector.PointAngle(pnt3D3, EndPnt, Plane);
          double EndAngle = StartAngle + LeadInProp.ArcSweepAngle;
          eArc = new eArc(EndPnt, LeadInProp.ArcRadius, StartAngle, EndAngle, Plane);
          eArc.camDirections = camPathDirectionType.Reverse;
        }
        if (LeadInProp.ClockDir == ClockDirectionType.CCW)
        {
          buAppCalc.cVector.LineWithLengthAndAngle(pnt3D3, LeadInProp.ArcRadius, pointTangentAngle1 + 90.0, Plane, ref EndPnt);
          double EndAngle = buAppCalc.cVector.PointAngle(pnt3D3, EndPnt, Plane);
          double StartAngle = EndAngle - LeadInProp.ArcSweepAngle;
          eArc = new eArc(EndPnt, LeadInProp.ArcRadius, StartAngle, EndAngle, Plane);
        }
        if (eArc != null)
        {
          eArc.Purpose = EntityPurposeType.LeadIn;
          LeadInEntitiy.Insert(0, (eEntities) eArc);
        }
      }
      if (LeadOutProp.LeadType == LeadInOutType.Line & LeadOutProp.Enable)
      {
        Pnt3D EndPnt = new Pnt3D();
        double num = 1.0;
        if (LeadOutProp.ClockDir == ClockDirectionType.CW)
          num = -1.0;
        buAppCalc.cVector.LineWithLengthAndAngle(pnt3D4, LeadOutProp.Length, pointTangentAngle2 + LeadOutProp.TangentAngle * num, Plane, ref EndPnt);
        eEntities eEntities = (eEntities) new eLine(pnt3D4, EndPnt);
        eEntities.Purpose = EntityPurposeType.LeadOut;
        LeadOutEntitiy.Add(eEntities);
      }
      if (!(LeadOutProp.LeadType == LeadInOutType.Arc & LeadOutProp.Enable))
        return;
      eArc eArc1 = (eArc) null;
      Pnt3D EndPnt1 = new Pnt3D();
      if (LeadOutProp.ClockDir == ClockDirectionType.CW)
      {
        buAppCalc.cVector.LineWithLengthAndAngle(pnt3D4, LeadOutProp.ArcRadius, pointTangentAngle2 - 90.0, Plane, ref EndPnt1);
        double EndAngle = buAppCalc.cVector.PointAngle(pnt3D4, EndPnt1, Plane);
        double StartAngle = EndAngle - LeadOutProp.ArcSweepAngle;
        eArc1 = new eArc(EndPnt1, LeadOutProp.ArcRadius, StartAngle, EndAngle, Plane);
        eArc1.camDirections = camPathDirectionType.Reverse;
      }
      if (LeadOutProp.ClockDir == ClockDirectionType.CCW)
      {
        buAppCalc.cVector.LineWithLengthAndAngle(pnt3D4, LeadOutProp.ArcRadius, pointTangentAngle2 + 90.0, Plane, ref EndPnt1);
        double StartAngle = buAppCalc.cVector.PointAngle(pnt3D4, EndPnt1, Plane);
        double EndAngle = StartAngle + LeadOutProp.ArcSweepAngle;
        eArc1 = new eArc(EndPnt1, LeadOutProp.ArcRadius, StartAngle, EndAngle, Plane);
        eArc1.camDirections = camPathDirectionType.Normal;
      }
      if (eArc1 == null)
        return;
      eArc1.Purpose = EntityPurposeType.LeadOut;
      LeadOutEntitiy.Add((eEntities) eArc1);
    }
    catch (Exception ex)
    {
      string str = $"FirstEntity: {FirstEntity.ToString()} - LastEntitiyEntity: {LastEntitiy.ToString()} - In: {LeadInProp.ToString()} - Out: {LeadOutProp.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LeadInOutCalculation(
    eEntities FirstEntity,
    eEntities LastEntitiy,
    LeadIn In,
    LeadOut Out,
    WorkPlane Plane,
    ClockDirectionType Direction,
    ref eEntities LeadInEntitiy,
    ref eEntities LeadOutEntitiy)
  {
    try
    {
      Pnt3D pnt3D1 = new Pnt3D(FirstEntity.Vertice[0]);
      Pnt3D pnt3D2 = new Pnt3D(LastEntitiy.Vertice[LastEntitiy.Vertice.Count - 1]);
      double num1 = !(FirstEntity.GetType() == typeof (eArc)) ? buAppCalc.cVector.PointAngle(FirstEntity.Vertice[1], FirstEntity.Vertice[0], Plane) : ((eArc) FirstEntity).StartAngle + 90.0;
      double num2 = !(LastEntitiy.GetType() == typeof (eArc)) ? buAppCalc.cVector.PointAngle(FirstEntity.Vertice[FirstEntity.Vertice.Count - 2], FirstEntity.Vertice[FirstEntity.Vertice.Count - 1], Plane) : ((eArc) FirstEntity).EndAngle - 90.0;
      if (FirstEntity.camDirections == camPathDirectionType.Reverse)
      {
        pnt3D1 = new Pnt3D(FirstEntity.Vertice[FirstEntity.Vertice.Count - 1]);
        pnt3D2 = new Pnt3D(LastEntitiy.Vertice[0]);
        num1 = !(FirstEntity.GetType() == typeof (eArc)) ? buAppCalc.cVector.PointAngle(FirstEntity.Vertice[0], FirstEntity.Vertice[1], Plane) : ((eArc) FirstEntity).EndAngle - 90.0;
        num2 = !(LastEntitiy.GetType() == typeof (eArc)) ? buAppCalc.cVector.PointAngle(FirstEntity.Vertice[FirstEntity.Vertice.Count - 1], FirstEntity.Vertice[FirstEntity.Vertice.Count - 2], Plane) : ((eArc) FirstEntity).StartAngle + 90.0;
      }
      if (In.LeadType == LeadInOutType.Line)
      {
        Pnt3D EndPnt = new Pnt3D();
        buAppCalc.cVector.LineWithLengthAndAngle(pnt3D1, In.Length, num1 + 180.0 + In.TangentAngle, Plane, ref EndPnt);
        LeadInEntitiy = (eEntities) new eLine(EndPnt, pnt3D1);
      }
      if (In.LeadType == LeadInOutType.Arc)
      {
        Pnt3D EndPnt = new Pnt3D();
        buAppCalc.cVector.LineWithLengthAndAngle(pnt3D1, In.ArcRadius, num1 + In.ArcSweepAngle, Plane, ref EndPnt);
        double EndAngle = buAppCalc.cVector.PointAngle(pnt3D1, EndPnt, Plane);
        double StartAngle = EndAngle - In.ArcSweepAngle;
        LeadInEntitiy = (eEntities) new eArc(EndPnt, In.ArcRadius, StartAngle, EndAngle, Plane);
      }
      if (Out.LeadType == LeadInOutType.Line)
      {
        Pnt3D EndPnt = new Pnt3D();
        buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, Out.Length, num2 + 180.0 + Out.TangentAngle, Plane, ref EndPnt);
        LeadOutEntitiy = (eEntities) new eLine(pnt3D2, EndPnt);
      }
      if (Out.LeadType != LeadInOutType.Arc)
        return;
      Pnt3D EndPnt1 = new Pnt3D();
      buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, In.ArcRadius, num2 + 180.0 + In.ArcSweepAngle, Plane, ref EndPnt1);
      double StartAngle1 = buAppCalc.cVector.PointAngle(pnt3D2, EndPnt1, Plane);
      double EndAngle1 = StartAngle1 + In.ArcSweepAngle;
      LeadOutEntitiy = (eEntities) new eArc(EndPnt1, In.ArcRadius, StartAngle1, EndAngle1, Plane);
    }
    catch (Exception ex)
    {
      string str = $"FirstEntity: {FirstEntity.ToString()} - LastEntitiyEntity: {LastEntitiy.ToString()} - In: {In.ToString()} - Out: {Out.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void SimPointCreat(
    List<Pnt9DCam> Points,
    double G0DevideRatio,
    double G1DevideRatio,
    double PointFilterLength,
    ref Simulation simulation)
  {
    this.SimPointCreat(Points, G0DevideRatio, G1DevideRatio, PointFilterLength, new Pnt9D(), ref simulation);
  }

  public void SimPointCreat(
    List<Pnt9DCam> Points,
    double G0DevideRatio,
    double G1DevideRatio,
    double PointFilterLength,
    Pnt9D Offsets,
    ref Simulation simulation)
  {
    if (G0DevideRatio <= 0.0)
      G0DevideRatio = 0.25;
    if (G1DevideRatio <= 0.0)
      G1DevideRatio = 0.1;
    int num = 1;
    if (Points.Count <= 0)
      return;
    if (Points[0].PlungeAxisMovement)
      num = 2;
    if (Points.Count > 0 & num <= Points.Count)
    {
      Pnt6D pnt6D = new Pnt6D(Points[num - 1].P9.X + Offsets.X, Points[num - 1].P9.Y + Offsets.Y, Points[num - 1].P9.Z + Offsets.Z, Points[num - 1].P9.A + Offsets.A, Points[num - 1].P9.B + Offsets.B, Points[num - 1].P9.C + Offsets.C);
      simulation.SimPoints.Add(new Pnt6D(Points[num - 1]));
    }
    for (int index1 = num; index1 <= Points.Count - 1; ++index1)
    {
      List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
      double dt = G1DevideRatio;
      if (Points[index1].Type == 0)
        dt = 0.25;
      if (Points[index1].Type == 0 | Points[index1].Type == 1)
      {
        if (buAppCalc.cVector.Length3D(new Pnt3D(Points[index1 - 1]), new Pnt3D(Points[index1])) > PointFilterLength)
        {
          buAppCalc.cVector.LineerInterpolation(new Pnt6D(Points[index1 - 1]), new Pnt6D(Points[index1]), dt, ref CalculatedPoints);
          CalculatedPoints.RemoveAt(0);
          for (int index2 = 0; index2 <= CalculatedPoints.Count - 1; ++index2)
          {
            Pnt6D pnt6D = new Pnt6D(CalculatedPoints[index2].X + Offsets.X, CalculatedPoints[index2].Y + Offsets.Y, CalculatedPoints[index2].Z + Offsets.Z, CalculatedPoints[index2].A + Offsets.A, CalculatedPoints[index2].B + Offsets.B, CalculatedPoints[index2].C + Offsets.C);
            simulation.SimPoints.Add(pnt6D);
          }
        }
        else
        {
          Pnt6D pnt6D = new Pnt6D(Points[index1].P9.X + Offsets.X, Points[index1].P9.Y + Offsets.Y, Points[index1].P9.Z + Offsets.Z, Points[index1].P9.A + Offsets.A, Points[index1].P9.B + Offsets.B, Points[index1].P9.C + Offsets.C);
          simulation.SimPoints.Add(pnt6D);
        }
      }
      if (Points[index1].Type == 2 | Points[index1].Type == 3)
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        if (Points[index1].ArcData != null)
        {
          Pnt3D.Copy(Points[index1].ArcData.Vertice, ref CopiedPnt);
          if (Points[index1].Type == 2)
            CopiedPnt.Reverse();
          if (CopiedPnt.Count > 0)
          {
            for (int index3 = 1; index3 <= CopiedPnt.Count - 1; ++index3)
            {
              Pnt6D pnt6D = new Pnt6D(CopiedPnt[index3].X + Offsets.X, CopiedPnt[index3].Y + Offsets.Y, CopiedPnt[index3].Z + Offsets.Z, Offsets.A, Offsets.B, Offsets.C);
              simulation.SimPoints.Add(pnt6D);
            }
          }
        }
      }
    }
  }

  public void SimPointCreatForDetailedPoints(
    List<Pnt9DCam> Points,
    double G0DevideRatio,
    double G1DevideRatio,
    double PointFilterLength,
    ref Simulation simulation)
  {
    this.SimPointCreatForDetailedPoints(Points, G0DevideRatio, G1DevideRatio, PointFilterLength, new Pnt9D(), ref simulation);
  }

  public void SimPointCreatForDetailedPoints(
    List<Pnt9DCam> Points,
    double G0DevideRatio,
    double G1DevideRatio,
    double PointFilterLength,
    Pnt9D Offsets,
    ref Simulation simulation)
  {
    if (G0DevideRatio <= 0.0)
      G0DevideRatio = 0.25;
    if (G1DevideRatio <= 0.0)
      G1DevideRatio = 0.1;
    int num = 1;
    if (Points.Count <= 0)
      return;
    if (Points[0].PlungeAxisMovement)
      num = 2;
    if (Points.Count > 0 & num <= Points.Count)
    {
      Pnt6DSim pnt6Dsim = new Pnt6DSim(Points[num - 1].P9.X + Offsets.X, Points[num - 1].P9.Y + Offsets.Y, Points[num - 1].P9.Z + Offsets.Z, Points[num - 1].P9.A + Offsets.A, Points[num - 1].P9.B + Offsets.B, Points[num - 1].P9.C + Offsets.C, Points[num - 1].Feed, Points[num - 1].ToolNo, Points[num - 1].SpindleSpeed, new Pnt3D());
      simulation.SimDetailedPoints.Add(pnt6Dsim);
    }
    for (int index1 = num; index1 <= Points.Count - 1; ++index1)
    {
      List<Pnt6DSim> CalculatedPoints = new List<Pnt6DSim>();
      double dt = G1DevideRatio;
      if (Points[index1].Type == 0)
        dt = 0.25;
      if (Points[index1].Type == 0 | Points[index1].Type == 1)
      {
        if (buAppCalc.cVector.Length3D(new Pnt3D(Points[index1 - 1]), new Pnt3D(Points[index1])) > PointFilterLength)
        {
          buAppCalc.cVector.LineerInterpolation(new Pnt6DSim(Points[index1 - 1]), new Pnt6DSim(Points[index1]), dt, ref CalculatedPoints);
          CalculatedPoints.RemoveAt(0);
          for (int index2 = 0; index2 <= CalculatedPoints.Count - 1; ++index2)
          {
            Pnt6DSim pnt6Dsim = new Pnt6DSim(CalculatedPoints[index2].X + Offsets.X, CalculatedPoints[index2].Y + Offsets.Y, CalculatedPoints[index2].Z + Offsets.Z, CalculatedPoints[index2].A + Offsets.A, CalculatedPoints[index2].B + Offsets.B, CalculatedPoints[index2].C + Offsets.C, CalculatedPoints[index2].FeedRate, CalculatedPoints[index2].ToolNo, CalculatedPoints[index2].SpindleRpm, new Pnt3D());
            simulation.SimDetailedPoints.Add(pnt6Dsim);
          }
        }
        else
        {
          Pnt6DSim pnt6Dsim = new Pnt6DSim(Points[index1].P9.X + Offsets.X, Points[index1].P9.Y + Offsets.Y, Points[index1].P9.Z + Offsets.Z, Points[index1].P9.A + Offsets.A, Points[index1].P9.B + Offsets.B, Points[index1].P9.C + Offsets.C, Points[index1].Feed, Points[index1].ToolNo, Points[index1].SpindleSpeed, new Pnt3D());
          simulation.SimDetailedPoints.Add(pnt6Dsim);
        }
      }
      if (Points[index1].Type == 2 | Points[index1].Type == 3)
      {
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        if (Points[index1].ArcData != null)
        {
          Pnt3D.Copy(Points[index1].ArcData.Vertice, ref CopiedPnt);
          if (Points[index1].Type == 2)
            CopiedPnt.Reverse();
          if (CopiedPnt.Count > 0)
          {
            for (int index3 = 1; index3 <= CopiedPnt.Count - 1; ++index3)
            {
              Pnt6DSim pnt6Dsim = new Pnt6DSim(CopiedPnt[index3].X + Offsets.X, CopiedPnt[index3].Y + Offsets.Y, CopiedPnt[index3].Z + Offsets.Z, Offsets.A, Offsets.B, Offsets.C, Points[index1].Feed, Points[index1].ToolNo, Points[index1].SpindleSpeed, new Pnt3D());
              simulation.SimDetailedPoints.Add(pnt6Dsim);
            }
          }
        }
      }
    }
  }

  public void ClippingPattern(
    List<Pnt3D> OutterPoints,
    List<List<Pnt3D>> InnerPoints,
    ref List<List<Pnt3D>> CalculatedPolygons)
  {
    buClipper buClipper = new buClipper();
    List<List<IntPoint>> ppg1 = new List<List<IntPoint>>();
    List<List<IntPoint>> ppg2 = new List<List<IntPoint>>();
    List<List<IntPoint>> solution = new List<List<IntPoint>>();
    List<IntPoint> collection1 = new List<IntPoint>();
    for (int index = 0; index <= OutterPoints.Count - 1; ++index)
    {
      IntPoint intPoint = new IntPoint((long) Convert.ToInt32(OutterPoints[index].X * 1000.0), (long) Convert.ToInt32(OutterPoints[index].Y * 1000.0));
      collection1.Add(intPoint);
    }
    List<IntPoint> intPointList1 = new List<IntPoint>((IEnumerable<IntPoint>) collection1);
    ppg1.Add(intPointList1);
    for (int index1 = 0; index1 <= InnerPoints.Count - 1; ++index1)
    {
      List<IntPoint> collection2 = new List<IntPoint>();
      for (int index2 = 0; index2 <= InnerPoints[index1].Count - 1; ++index2)
      {
        IntPoint intPoint = new IntPoint((long) Convert.ToInt32(InnerPoints[index1][index2].X * 1000.0), (long) Convert.ToInt32(InnerPoints[index1][index2].Y * 1000.0));
        collection2.Add(intPoint);
      }
      List<IntPoint> intPointList2 = new List<IntPoint>((IEnumerable<IntPoint>) collection2);
      ppg2.Add(intPointList2);
    }
    buClipper.AddPaths(ppg1, PolyType.ptSubject, true);
    buClipper.AddPaths(ppg2, PolyType.ptClip, true);
    buClipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftEvenOdd, PolyFillType.pftNonZero);
    for (int index3 = 0; index3 <= solution.Count - 1; ++index3)
    {
      List<Pnt3D> pnt3DList = new List<Pnt3D>();
      for (int index4 = 0; index4 <= solution[index3].Count - 1; ++index4)
      {
        Pnt3D pnt3D = new Pnt3D((double) solution[index3][index4].X / (double) buSystem.DoubleToIntegerConts, (double) solution[index3][index4].Y / (double) buSystem.DoubleToIntegerConts, (double) solution[index3][index4].Z);
        pnt3DList.Add(pnt3D);
      }
      if (pnt3DList.Count >= 2 && !buCompare.EQ(pnt3DList[0], pnt3DList[pnt3DList.Count - 1], buSystem.resolutionCompare))
      {
        Pnt3D pnt3D = new Pnt3D(pnt3DList[0]);
        pnt3DList.Add(new Pnt3D(pnt3DList[0]));
      }
      CalculatedPolygons.Add(pnt3DList);
    }
  }
}
