// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleCountertopMainPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCountertopMainPars : buSerilization5
{
  public double TargetZDrill;
  public double QuickVelocity;
  public double JobFinishZPostion;
  public bool MoveZCAAxesToSafeDistance;
  public bool UseCZero;
  public bool UseConstantCAngle;
  public bool AlwaysSafeDistance;
  public bool isFirstCutSafeDistance;
  public bool NoAngleCAxisCheck;
  public bool UseTangentLimit;
  public double ConstantAngleC;
  public double OffsetAngleC;
  public double AngleCLimit;
  public double AngleCMin;
  public double AngleCMax;

  public void SawCornerCurvature(
    List<Point3D> refPoints,
    List<Point3D> CurvePoints,
    int Degree,
    MarbleSawCornerCleanMode CornerMode,
    double Deviation,
    ref List<Point3D> fillPoints)
  {
    // ISSUE: unable to decompile the method.
  }

  public void SawCornerLine(
    Entity rectBox,
    List<Point3D> PLRef,
    double XYStep,
    double XYSafeDistance,
    double ZPos,
    bool isReverse,
    int CntZ,
    ref List<Point3DList> PLLFill)
  {
    List<Entity> entHat = new List<Entity>();
    List<Entity> entitiesLine1 = new List<Entity>();
    List<Entity> entitiesLine2 = new List<Entity>();
    List<Point3D> point3DList = new List<Point3D>();
    Point3D EndPnt = new Point3D();
    buCall.\u0001.Hatch(rectBox, ZPos, 45.0, XYStep, ref entHat);
    buCall.\u0001.GetHatchLines(entHat, 45.0, XYStep, ref entitiesLine1);
    entHat.Clear();
    buCall.\u0001.Hatch(rectBox, ZPos, 135.0, XYStep, ref entHat);
    buCall.\u0001.GetHatchLines(entHat, 135.0, XYStep, ref entitiesLine2);
    LinearPath C2 = new LinearPath((ICollection<Point3D>) PLRef);
    if (!isReverse)
    {
      List<Point3D> collection1 = new List<Point3D>();
      int num1 = 0;
      for (int index = 0; index <= entitiesLine2.Count - 1; ++index)
      {
        if (((ICurve) entitiesLine2[index]).IntersectWith((ICurve) C2).Length != 0)
          index = entitiesLine1.Count;
        else if (num1 % 2 == 0)
        {
          collection1.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[0]));
          collection1.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[entitiesLine2[index].Vertices.Length - 1]));
        }
        else
        {
          collection1.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[entitiesLine2[index].Vertices.Length - 1]));
          collection1.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[0]));
        }
        ++num1;
      }
      Point3DList point3Dlist1 = (Point3DList) new ToolBase5();
      buCall.\u0001.LineWithLengthAndAngle(collection1[0], XYStep + XYSafeDistance, 225.0, ref EndPnt);
      collection1.Insert(0, EndPnt);
      buCall.\u0001.LineWithLengthAndAngle(collection1[collection1.Count - 1], XYStep * (double) num1 + XYSafeDistance, 225.0, ref EndPnt);
      collection1.Add(EndPnt);
      ((ToolGeometry5) point3Dlist1).Points.AddRange((IEnumerable<Point3D>) collection1);
      MarbleSawCalcParameters sawCalcParameters1 = (MarbleSawCalcParameters) new \u0007.\u0001();
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters1).DevideLength = 0.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters1).ShiftPoint = (Point3D) null;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters1).ShiftEnable = false;
      ((buMarbleForms) sawCalcParameters1).SplineEnable = false;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters1).ConstantAngle = 315.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters1).UseContantAngle = true;
      if (CntZ == 0)
        ((RoboticSettings) sawCalcParameters1).isFirst = true;
      ((ToolGeometry5) point3Dlist1).Settings = (object) sawCalcParameters1;
      PLLFill.Add(point3Dlist1);
      entitiesLine1.Reverse();
      List<Point3D> collection2 = new List<Point3D>();
      int num2 = 0;
      for (int index = 0; index <= entitiesLine1.Count - 1; ++index)
      {
        if (((ICurve) entitiesLine1[index]).IntersectWith((ICurve) C2).Length != 0)
          index = entitiesLine1.Count;
        else if (num2 % 2 == 0)
        {
          collection2.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[0]));
          collection2.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[entitiesLine1[index].Vertices.Length - 1]));
        }
        else
        {
          collection2.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[entitiesLine1[index].Vertices.Length - 1]));
          collection2.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[0]));
        }
        ++num2;
      }
      Point3DList point3Dlist2 = (Point3DList) new ToolBase5();
      buCall.\u0001.LineWithLengthAndAngle(collection2[0], XYStep + XYSafeDistance, 135.0, ref EndPnt);
      collection2.Insert(0, EndPnt);
      buCall.\u0001.LineWithLengthAndAngle(collection2[collection2.Count - 1], XYStep * (double) num2 + XYSafeDistance, 135.0, ref EndPnt);
      collection2.Add(EndPnt);
      ((ToolGeometry5) point3Dlist2).Points.AddRange((IEnumerable<Point3D>) collection2);
      MarbleSawCalcParameters sawCalcParameters2 = (MarbleSawCalcParameters) new \u0007.\u0001();
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters2).DevideLength = 0.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters2).ShiftPoint = (Point3D) null;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters2).ShiftEnable = false;
      ((buMarbleForms) sawCalcParameters2).SplineEnable = false;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters2).ConstantAngle = 225.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters2).UseContantAngle = true;
      ((ToolGeometry5) point3Dlist2).Settings = (object) sawCalcParameters2;
      PLLFill.Add(point3Dlist2);
      List<Point3D> collection3 = new List<Point3D>();
      int num3 = 0;
      entitiesLine2.Reverse();
      for (int index = 0; index <= entitiesLine2.Count - 1; ++index)
      {
        if (((ICurve) entitiesLine2[index]).IntersectWith((ICurve) C2).Length != 0)
          index = entitiesLine1.Count;
        else if (num3 % 2 == 0)
        {
          collection3.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[0]));
          collection3.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[entitiesLine2[index].Vertices.Length - 1]));
        }
        else
        {
          collection3.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[entitiesLine2[index].Vertices.Length - 1]));
          collection3.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[0]));
        }
        ++num3;
      }
      Point3DList point3Dlist3 = (Point3DList) new ToolBase5();
      buCall.\u0001.LineWithLengthAndAngle(collection3[0], XYStep + XYSafeDistance, 45.0, ref EndPnt);
      collection3.Insert(0, EndPnt);
      buCall.\u0001.LineWithLengthAndAngle(collection3[collection3.Count - 1], XYStep * (double) num3 + XYSafeDistance, 45.0, ref EndPnt);
      collection3.Add(EndPnt);
      ((ToolGeometry5) point3Dlist3).Points.AddRange((IEnumerable<Point3D>) collection3);
      MarbleSawCalcParameters sawCalcParameters3 = (MarbleSawCalcParameters) new \u0007.\u0001();
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters3).DevideLength = 0.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters3).ShiftPoint = (Point3D) null;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters3).ShiftEnable = false;
      ((buMarbleForms) sawCalcParameters3).SplineEnable = false;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters3).ConstantAngle = 135.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters3).UseContantAngle = true;
      ((ToolGeometry5) point3Dlist3).Settings = (object) sawCalcParameters3;
      PLLFill.Add(point3Dlist3);
      entitiesLine1.Reverse();
      List<Point3D> collection4 = new List<Point3D>();
      int num4 = 0;
      for (int index = 0; index <= entitiesLine1.Count - 1; ++index)
      {
        if (((ICurve) entitiesLine1[index]).IntersectWith((ICurve) C2).Length != 0)
          index = entitiesLine1.Count;
        else if (num4 % 2 == 0)
        {
          collection4.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[0]));
          collection4.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[entitiesLine1[index].Vertices.Length - 1]));
        }
        else
        {
          collection4.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[entitiesLine1[index].Vertices.Length - 1]));
          collection4.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[0]));
        }
        ++num4;
      }
      Point3DList point3Dlist4 = (Point3DList) new ToolBase5();
      buCall.\u0001.LineWithLengthAndAngle(collection4[0], XYStep + XYSafeDistance, -45.0, ref EndPnt);
      collection4.Insert(0, EndPnt);
      buCall.\u0001.LineWithLengthAndAngle(collection4[collection4.Count - 1], XYStep * (double) num4 + XYSafeDistance, -45.0, ref EndPnt);
      collection4.Add(EndPnt);
      ((ToolGeometry5) point3Dlist4).Points.AddRange((IEnumerable<Point3D>) collection4);
      MarbleSawCalcParameters sawCalcParameters4 = (MarbleSawCalcParameters) new \u0007.\u0001();
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters4).DevideLength = 0.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters4).ShiftPoint = (Point3D) null;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters4).ShiftEnable = false;
      ((buMarbleForms) sawCalcParameters4).SplineEnable = false;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters4).ConstantAngle = 45.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters4).UseContantAngle = true;
      ((ToolGeometry5) point3Dlist4).Settings = (object) sawCalcParameters4;
      PLLFill.Add(point3Dlist4);
    }
    else
    {
      List<Point3D> collection5 = new List<Point3D>();
      int num5 = 0;
      for (int index = 0; index <= entitiesLine1.Count - 1; ++index)
      {
        if (((ICurve) entitiesLine1[index]).IntersectWith((ICurve) C2).Length != 0)
          index = entitiesLine1.Count;
        else if (num5 % 2 == 0)
        {
          collection5.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[0]));
          collection5.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[entitiesLine1[index].Vertices.Length - 1]));
        }
        else
        {
          collection5.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[entitiesLine1[index].Vertices.Length - 1]));
          collection5.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[0]));
        }
        ++num5;
      }
      Point3DList point3Dlist5 = (Point3DList) new ToolBase5();
      buCall.\u0001.LineWithLengthAndAngle(collection5[0], XYStep + XYSafeDistance, -45.0, ref EndPnt);
      collection5.Insert(0, EndPnt);
      buCall.\u0001.LineWithLengthAndAngle(collection5[collection5.Count - 1], XYStep * (double) num5 + XYSafeDistance, -45.0, ref EndPnt);
      collection5.Add(EndPnt);
      ((ToolGeometry5) point3Dlist5).Points.AddRange((IEnumerable<Point3D>) collection5);
      MarbleSawCalcParameters sawCalcParameters5 = (MarbleSawCalcParameters) new \u0007.\u0001();
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters5).DevideLength = 0.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters5).ShiftPoint = (Point3D) null;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters5).ShiftEnable = false;
      ((buMarbleForms) sawCalcParameters5).SplineEnable = false;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters5).ConstantAngle = 45.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters5).UseContantAngle = true;
      ((ToolGeometry5) point3Dlist5).Settings = (object) sawCalcParameters5;
      PLLFill.Add(point3Dlist5);
      List<Point3D> collection6 = new List<Point3D>();
      int num6 = 0;
      entitiesLine2.Reverse();
      for (int index = 0; index <= entitiesLine2.Count - 1; ++index)
      {
        if (((ICurve) entitiesLine2[index]).IntersectWith((ICurve) C2).Length != 0)
          index = entitiesLine1.Count;
        else if (num6 % 2 == 0)
        {
          collection6.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[0]));
          collection6.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[entitiesLine2[index].Vertices.Length - 1]));
        }
        else
        {
          collection6.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[entitiesLine2[index].Vertices.Length - 1]));
          collection6.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[0]));
        }
        ++num6;
      }
      Point3DList point3Dlist6 = (Point3DList) new ToolBase5();
      buCall.\u0001.LineWithLengthAndAngle(collection6[0], XYStep + XYSafeDistance, 45.0, ref EndPnt);
      collection6.Insert(0, EndPnt);
      buCall.\u0001.LineWithLengthAndAngle(collection6[collection6.Count - 1], XYStep * (double) num6 + XYSafeDistance, 45.0, ref EndPnt);
      collection6.Add(EndPnt);
      ((ToolGeometry5) point3Dlist6).Points.AddRange((IEnumerable<Point3D>) collection6);
      MarbleSawCalcParameters sawCalcParameters6 = (MarbleSawCalcParameters) new \u0007.\u0001();
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters6).DevideLength = 0.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters6).ShiftPoint = (Point3D) null;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters6).ShiftEnable = false;
      ((buMarbleForms) sawCalcParameters6).SplineEnable = false;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters6).ConstantAngle = 135.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters6).UseContantAngle = true;
      ((ToolGeometry5) point3Dlist6).Settings = (object) sawCalcParameters6;
      PLLFill.Add(point3Dlist6);
      entitiesLine1.Reverse();
      List<Point3D> collection7 = new List<Point3D>();
      int num7 = 0;
      for (int index = 0; index <= entitiesLine1.Count - 1; ++index)
      {
        if (((ICurve) entitiesLine1[index]).IntersectWith((ICurve) C2).Length != 0)
          index = entitiesLine1.Count;
        else if (num7 % 2 == 0)
        {
          collection7.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[0]));
          collection7.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[entitiesLine1[index].Vertices.Length - 1]));
        }
        else
        {
          collection7.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[entitiesLine1[index].Vertices.Length - 1]));
          collection7.Add(F_NotchEdit.ToPoint3D(entitiesLine1[index].Vertices[0]));
        }
        ++num7;
      }
      Point3DList point3Dlist7 = (Point3DList) new ToolBase5();
      buCall.\u0001.LineWithLengthAndAngle(collection7[0], XYStep + XYSafeDistance, 135.0, ref EndPnt);
      collection7.Insert(0, EndPnt);
      buCall.\u0001.LineWithLengthAndAngle(collection7[collection7.Count - 1], XYStep * (double) num7 + XYSafeDistance, 135.0, ref EndPnt);
      collection7.Add(EndPnt);
      ((ToolGeometry5) point3Dlist7).Points.AddRange((IEnumerable<Point3D>) collection7);
      MarbleSawCalcParameters sawCalcParameters7 = (MarbleSawCalcParameters) new \u0007.\u0001();
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters7).DevideLength = 0.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters7).ShiftPoint = (Point3D) null;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters7).ShiftEnable = false;
      ((buMarbleForms) sawCalcParameters7).SplineEnable = false;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters7).ConstantAngle = 225.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters7).UseContantAngle = true;
      ((ToolGeometry5) point3Dlist7).Settings = (object) sawCalcParameters7;
      PLLFill.Add(point3Dlist7);
      entitiesLine2.Reverse();
      List<Point3D> collection8 = new List<Point3D>();
      int num8 = 0;
      for (int index = 0; index <= entitiesLine2.Count - 1; ++index)
      {
        if (((ICurve) entitiesLine2[index]).IntersectWith((ICurve) C2).Length != 0)
          index = entitiesLine1.Count;
        else if (num8 % 2 == 0)
        {
          collection8.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[0]));
          collection8.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[entitiesLine2[index].Vertices.Length - 1]));
        }
        else
        {
          collection8.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[entitiesLine2[index].Vertices.Length - 1]));
          collection8.Add(F_NotchEdit.ToPoint3D(entitiesLine2[index].Vertices[0]));
        }
        ++num8;
      }
      Point3DList point3Dlist8 = (Point3DList) new ToolBase5();
      buCall.\u0001.LineWithLengthAndAngle(collection8[0], XYStep + XYSafeDistance, 225.0, ref EndPnt);
      collection8.Insert(0, EndPnt);
      buCall.\u0001.LineWithLengthAndAngle(collection8[collection8.Count - 1], XYStep * (double) num8 + XYSafeDistance, 225.0, ref EndPnt);
      collection8.Add(EndPnt);
      ((ToolGeometry5) point3Dlist8).Points.AddRange((IEnumerable<Point3D>) collection8);
      MarbleSawCalcParameters sawCalcParameters8 = (MarbleSawCalcParameters) new \u0007.\u0001();
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters8).DevideLength = 0.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters8).ShiftPoint = (Point3D) null;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters8).ShiftEnable = false;
      ((buMarbleForms) sawCalcParameters8).SplineEnable = false;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters8).ConstantAngle = 315.0;
      ((buEyeBaseVer5.Apps.Robotic.DoorJob) sawCalcParameters8).UseContantAngle = true;
      ((ToolGeometry5) point3Dlist8).Settings = (object) sawCalcParameters8;
      PLLFill.Add(point3Dlist8);
    }
  }

  public bool isVertical(double AngleC)
  {
    return AngleC >= 45.0 & AngleC <= 135.0 || AngleC >= 225.0 & AngleC <= 315.0;
  }

  public bool isCAngleSuitable(double CAngle, bool isHorizontal)
  {
    try
    {
      if (isHorizontal)
      {
        if (CAngle >= -45.0 & CAngle <= 45.0 || CAngle >= 135.0 & CAngle <= 225.0)
          return true;
      }
      else if (CAngle >= -135.0 & CAngle <= -45.0 || CAngle >= 45.0 & CAngle <= 135.0 || CAngle >= 225.0 & CAngle <= 315.0)
        return true;
      return false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }
}
