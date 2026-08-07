// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MachineMCodeInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class MachineMCodeInfo : buSerilization5
{
  internal static string \u0001;
  public static byte f00098A;
  public static byte f00098B;
  [SpecialName]
  public int value__;

  public void LineToLineer(
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    double Length,
    ref List<Pnt6DSimMove> Vertices)
  {
    try
    {
      double num = ((buVector5) this).Length3D(StartPoint, EndPoint);
      if (Length <= 0.0)
      {
        Vertices.Add((Pnt6DSimMove) new PointAndAngleRange(StartPoint));
        Vertices.Add((Pnt6DSimMove) new PointAndAngleRange(EndPoint));
      }
      else
      {
        int int32 = Convert.ToInt32(num / Length);
        Vertices.Clear();
        if (int32 <= 1)
        {
          Vertices.Add((Pnt6DSimMove) new PointAndAngleRange(StartPoint));
          Vertices.Add((Pnt6DSimMove) new PointAndAngleRange(EndPoint));
        }
        else
        {
          double dt = 1.0 / (double) int32;
          ((MachineAxisInfo) this).LineerInterpolation((Pnt6DSimMove) new PointAndAngleRange(StartPoint), (Pnt6DSimMove) new PointAndAngleRange(EndPoint), dt, ref Vertices);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"SP: {StartPoint.ToString()} - EP: {EndPoint.ToString()} - Len: {Length.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void LineToLineer(
    Pnt6DSimMove StartPoint,
    Pnt6DSimMove EndPoint,
    double Length,
    ref List<Pnt6DSimMove> Vertices)
  {
    try
    {
      double num = ((buVector5) this).Length3D(StartPoint, EndPoint);
      if (num == 0.0)
        num = ((buVector5) this).Length6D(StartPoint, EndPoint);
      if (Length <= 0.0)
      {
        Vertices.Add((Pnt6DSimMove) new AlingmentPoints3D(StartPoint));
        Vertices.Add((Pnt6DSimMove) new AlingmentPoints3D(EndPoint));
      }
      else
      {
        int int32 = Convert.ToInt32(num / Length);
        Vertices.Clear();
        if (int32 <= 1)
        {
          Vertices.Add((Pnt6DSimMove) new AlingmentPoints3D(StartPoint));
          Vertices.Add((Pnt6DSimMove) new AlingmentPoints3D(EndPoint));
        }
        else
        {
          double dt = 1.0 / (double) int32;
          ((MachineAxisInfo) this).LineerInterpolation(StartPoint, EndPoint, dt, ref Vertices);
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"SP: {StartPoint.ToString()} - EP: {EndPoint.ToString()} - Len: {Length.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void ArcToLineer(
    Pnt3D Center,
    double Radius,
    double SA,
    double EA,
    double Length,
    WorkPlane Plane,
    ref List<Pnt3D> Vertices)
  {
    try
    {
      double num1 = 0.0;
      Pnt3D pnt3D1 = new Pnt3D();
      if (buConversion5.EQ(SA, EA))
      {
        Vertices.Clear();
      }
      else
      {
        double num2 = EA - SA;
        int num3 = (int) (2.0 * Math.PI * Radius * (EA - SA) / 360.0 / Length);
        if (num3 <= 0)
        {
          Vertices.Clear();
        }
        else
        {
          if (num3 > 0)
            num1 = num2 / (double) num3;
          Vertices.Clear();
          for (int index = 0; index <= num3; ++index)
          {
            Pnt3D pnt3D2 = new Pnt3D();
            if (WorkPlane.isPlaneXY(Plane))
            {
              pnt3D2.X = Center.X + Radius * Math.Cos(buString5.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Y = Center.Y + Radius * Math.Sin(buString5.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Z = Center.Z;
            }
            if (WorkPlane.isPlaneXZ(Plane))
            {
              pnt3D2.X = Center.X + Radius * Math.Cos(buString5.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Y = Center.Y;
              pnt3D2.Z = Center.Z + Radius * Math.Sin(buString5.DegreeToRadian(SA + (double) index * num1));
            }
            if (WorkPlane.isPlaneYZ(Plane))
            {
              pnt3D2.X = Center.X;
              pnt3D2.Y = Center.Y + Radius * Math.Cos(buString5.DegreeToRadian(SA + (double) index * num1));
              pnt3D2.Z = Center.Z + Radius * Math.Sin(buString5.DegreeToRadian(SA + (double) index * num1));
            }
            Vertices.Add(pnt3D2);
          }
        }
      }
    }
    catch (Exception ex)
    {
      string str = $"Center:{Center.ToString()}R: {Radius.ToString()} - SA: {SA.ToString()} - EA: {EA.ToString()} - Plane: {Plane.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public void CreateCamHeightPlane(
    double Height,
    planeBoxNames refPlane,
    Point3D pntMin,
    Point3D pntMax,
    Color color,
    int Transparent,
    string TextString,
    CamPlaneHeightType HeightType,
    ref buEntity calcEntity,
    ref buEntity textEntity)
  {
    Entity calcEntity1 = (Entity) null;
    Entity textEntity1 = (Entity) null;
    ((MachineOtherCodeInfo) this).CreateCamHeightPlane(Height, refPlane, pntMin, pntMax, color, Transparent, TextString, HeightType, ref calcEntity1, ref textEntity1);
    buAngularDim.Copy(calcEntity1, ref calcEntity);
    buAngularDim.Copy(textEntity1, ref textEntity);
  }
}
