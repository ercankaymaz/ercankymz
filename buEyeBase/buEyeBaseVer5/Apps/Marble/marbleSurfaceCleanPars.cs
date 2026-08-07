// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleSurfaceCleanPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSurfaceCleanPars : buSerilization5
{
  public double CamArrowConeDiameter;
  public bool DrawMaterialDimension;
  public static List<string> Captions;
  public static byte f004BBD;
  public double PixelToMmX;
  public double PixelToMmY;
  public bool SheetInnerMakeItHoleas3D;
  public static List<string> Captions;
  public static byte f004BC2;
  public double CountertopSlatOffset;

  public double CircularSpeedReductionCalculate(buEntity refEntity)
  {
    try
    {
      double Diameter = 0.0;
      double FoundPersentage = 100.0;
      double num = 1.0;
      if (refEntity is buCircle | refEntity is buArc | refEntity is buEllipse)
      {
        switch (refEntity)
        {
          case buCircle _:
            Diameter = ((CustomDataSurrogate) refEntity).Radius * 2.0;
            break;
          case buArc _:
            Diameter = ((CustomDataSurrogate) refEntity).Radius * 2.0;
            break;
          case buEllipse _:
            Diameter = ((CustomDataSurrogate) refEntity).RadiusX >= ((CustomDataSurrogate) refEntity).RadiusY ? ((CustomDataSurrogate) refEntity).RadiusY * 2.0 : ((CustomDataSurrogate) refEntity).RadiusX * 2.0;
            break;
        }
        buCompare5.GetPersentage(MarbleEntitiesSettings.CircularSpeedReductions, Diameter, ref FoundPersentage);
        if (FoundPersentage <= 0.0)
          FoundPersentage = 100.0;
        num = FoundPersentage / 100.0;
      }
      if (num > 1.0)
        num = 1.0;
      if (num < 0.01)
        num = 1.0;
      return num;
    }
    catch (Exception ex)
    {
      return 1.0;
    }
  }

  public void CommonLinesToWireEntities(List<buEntity> calcLines, ref MarbleJob Job)
  {
    // ISSUE: unable to decompile the method.
  }

  public bool MergeCollinearLines(
    List<buEntity> lines,
    ref List<buEntity> Result,
    double collinearTol = 0.01,
    double gapTol = 0.1)
  {
    try
    {
      List<(Vector3D, Vector3D, double, List<buEntity>)> valueTupleList = new List<(Vector3D, Vector3D, double, List<buEntity>)>();
      double num1 = 1E-09;
      bool flag1 = false;
      if (Result == null)
        Result = new List<buEntity>();
      Result.Clear();
      foreach (buEntity line in lines)
      {
        Vector3D vector3D1 = new Vector3D(((CustomData) line).StartPoint, ((CustomData) line).EndPoint);
        if (vector3D1.Length >= num1)
        {
          Vector3D vector3D2 = \u0007.\u0001.\u0001((buMarbleCalc) this, vector3D1);
          Vector3D vector3D3 = Vector3D.Cross(vector3D2, Vector3D.AxisZ);
          if (vector3D3.Length < num1)
            vector3D3 = Vector3D.Cross(vector3D2, Vector3D.AxisX);
          vector3D3.Normalize();
          double num2 = vector3D3.X * ((CustomData) line).StartPoint.X + vector3D3.Y * ((CustomData) line).StartPoint.Y + vector3D3.Z * ((CustomData) line).StartPoint.Z;
          bool flag2 = false;
          for (int index = 0; index < valueTupleList.Count; ++index)
          {
            (Vector3D, Vector3D, double, List<buEntity>) valueTuple = valueTupleList[index];
            if (Vector3D.Cross(valueTuple.Item1, vector3D2).Length <= 1E-06 && Math.Abs(valueTuple.Item3 - num2) <= collinearTol)
            {
              valueTuple.Item4.Add(line);
              flag2 = true;
              break;
            }
          }
          if (!flag2)
            valueTupleList.Add((vector3D2, vector3D3, num2, new List<buEntity>()
            {
              line
            }));
          else
            flag1 = true;
        }
      }
      foreach ((Vector3D, Vector3D, double, List<buEntity>) valueTuple in valueTupleList)
      {
        // ISSUE: variable of a compiler-generated type
        buMarbleCalc.\u0001 obj = (buMarbleCalc.\u0001) new marbleSlatData();
        Vector3D vector3D;
        double num3;
        List<buEntity> source;
        (((MarbleProgramSettings) obj).\u0001, vector3D, num3, source) = valueTuple;
        List<(double, double)> list = source.Select<buEntity, (double, double)>(new Func<buEntity, (double, double)>(((marbleSlatData) obj).\u0001)).OrderBy<(double, double), double>(MarbleProgramSettings.\u003C\u003E9__92_1 ?? (MarbleProgramSettings.\u003C\u003E9__92_1 = new Func<(double, double), double>(((marbleSlatData) MarbleProgramSettings.\u003C\u003E9).\u0001))).ToList<(double, double)>();
        double num4 = list[0].Item1;
        double val1 = list[0].Item2;
        for (int index = 1; index < list.Count; ++index)
        {
          (double num5, double val2) = list[index];
          if (num5 <= val1 + gapTol)
          {
            val1 = Math.Max(val1, val2);
          }
          else
          {
            buLine buLine = \u0007.\u0001.\u0001(num4, vector3D, (buMarbleCalc) this, num3, ((MarbleProgramSettings) obj).\u0001, val1);
            if (buLine != null)
            {
              ((CustomDataSurrogate) buLine).Orientation = new OrientationAngle(((CustomDataSurrogate) source[0]).Orientation);
              ((CustomData) buLine).Marble = (MarbleInfo) new Line2D(((CustomData) source[0]).Marble);
              ((buUpperLine) buLine).Update();
              Result.Add((buEntity) buLine);
            }
            num4 = num5;
            val1 = val2;
          }
        }
        buLine buLine1 = \u0007.\u0001.\u0001(num4, vector3D, (buMarbleCalc) this, num3, ((MarbleProgramSettings) obj).\u0001, val1);
        if (buLine1 != null)
        {
          ((CustomDataSurrogate) buLine1).Orientation = new OrientationAngle(((CustomDataSurrogate) source[0]).Orientation);
          ((CustomData) buLine1).Marble = (MarbleInfo) new Line2D(((CustomData) source[0]).Marble);
          ((buUpperLine) buLine1).Update();
          Result.Add((buEntity) buLine1);
        }
      }
      return flag1;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public void JobCamCalculatedReset(
    bool GCodeCreate,
    bool CamCalculated,
    bool CamItems,
    int ItemIndex,
    ref MarbleJob activeJob)
  {
    if (GCodeCreate)
      ((MarbleProgramSettings) activeJob).isGCodeCreated = false;
    if (CamCalculated)
      ((MarbleProgramSettings) activeJob).CamCalculated = false;
    ((MarbleProgramSettings) activeJob).isFileSend = false;
    ((MarbleProgramSettings) activeJob).isCommonPathDone = false;
    if (!CamItems)
      return;
    if (ItemIndex < 0)
    {
      for (int index1 = 0; index1 <= ((MarbleProgramSettings) activeJob).Items.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) activeJob).Items[index1]).CamList.Count - 1; ++index2)
          ((MarbleScreenCaptureSettings) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) activeJob).Items[index1]).CamList[index2]).isCamCalculated = false;
      }
    }
    else
    {
      if (!(ItemIndex >= 0 & ItemIndex <= ((MarbleProgramSettings) activeJob).Items.Count - 1))
        return;
      for (int index = 0; index <= ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) activeJob).Items[ItemIndex]).CamList.Count - 1; ++index)
        ((MarbleScreenCaptureSettings) ((MarbleScreenCaptureSettings) ((MarbleProgramSettings) activeJob).Items[ItemIndex]).CamList[index]).isCamCalculated = false;
    }
  }

  public void CamWireItemEntityToExtendEntity(ref MarbleItem Item)
  {
    if (((MarbleScreenCaptureSettings) Item).Extends.Count <= 0)
      return;
    for (int index1 = 0; index1 <= ((MarbleScreenCaptureSettings) Item).Extends.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ((MarbleScreenCaptureSettings) Item).CamList.Count - 1; ++index2)
      {
        MarbleItemCam cam = ((MarbleScreenCaptureSettings) Item).CamList[index2];
        if (((MarbleMachineSettings) cam).CamID == ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index1]).CamID && ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index1]).indexWire <= ((MarbleMachineOptionsSettings) cam).WireEntities.Count - 1 && ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index1]).indexWireSub <= ((MarbleMachineOptionsSettings) cam).WireEntities[((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index1]).indexWire].Count - 1)
          buDiametricDim.Copy(((MarbleMachineOptionsSettings) cam).WireEntities[((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index1]).indexWire][((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index1]).indexWireSub], ref ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).Extends[index1]).entityExtend);
      }
    }
  }
}
