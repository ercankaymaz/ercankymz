// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileDrawings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileDrawings : buSerilization5
{
  public double Layer2Speed;
  public double Layer3Speed;
  public double Layer4Speed;
  public double Layer5Speed;
  public double Layer6Speed;

  public bool GetOperationDepthValueFromProfile1(
    ProfileItem Profile,
    DepthPositionOptions Options,
    double ExternalDepth,
    double ExtraDepth,
    bool EachLayer,
    ToolBase5 Tool,
    ref ProfileOperation Operation)
  {
    bool valueFromProfile1;
    if (Profile == null)
    {
      valueFromProfile1 = false;
    }
    else
    {
      Point3D MinPoint = new Point3D();
      Point3D MaxPoint = new Point3D();
      ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Clear();
      ((ProfileRuntimeSettings) Operation).ProfileWidth = ((ProfileSettings) Profile).Width;
      ((ProfileRuntimeSettings) Operation).ProfileHeight = ((ProfileSettings) Profile).Height;
      ((ProfileRuntimeSettings) Operation).ProfileLength = ((ProfileSettings) Profile).Length;
      ((ProfileRuntimeSettings) Operation).ProfileName = ((ProfileSettings) Profile).ItemName;
      List<double> List = new List<double>();
      List<Point3D> Points = new List<Point3D>();
      List<Line> lineList = new List<Line>();
      List<double> Values = new List<double>();
      if (((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Action == actionTypeBU.profileRectangle)
        buFile5.DevideMinMaxValueByNumber(-((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).RectangleData).RectangleHeight / 2.0, ((OperationUpdateArg) ((DepthPositions) ((ProfileRuntimeSettings) Operation).OperationData).RectangleData).RectangleHeight / 2.0, 10, ref Values);
      for (int index1 = 0; index1 <= ((ProfileSettings) Profile).Drawings.Count - 1; ++index1)
      {
        LinearPath linearPath = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).OutterPoints);
        Line C2 = !(((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom) ? (!(((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front) ? new Line(new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Y * 10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Z * 10000.0), new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Y * -10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlane.AxisZ.Z * -10000.0)) : new Line(new Point3D(0.0, -10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y + ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).movePlanePoint.Z), new Point3D(0.0, 10000.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y + ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).movePlanePoint.Z))) : new Line(new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y, -10000.0), new Point3D(0.0, ((ProfilePatternCopy) ((ProfileRuntimeSettings) Operation).OperationData).Position.Y, 10000.0));
        Point3D[] collection1 = linearPath.IntersectWith((ICurve) C2, 0.0, true);
        Points.AddRange((IEnumerable<Point3D>) collection1);
        for (int index2 = 0; index2 <= ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints.Count - 1; ++index2)
        {
          Point3D[] collection2 = new LinearPath((ICollection<Point3D>) ((MarbleJob) ((ProfileSettings) Profile).Drawings[index1]).InnerPoints[index2]).IntersectWith((ICurve) C2, 0.0, true);
          Points.AddRange((IEnumerable<Point3D>) collection2);
        }
      }
      buCall.\u0001.BoxSizeCalculate(Points, ref MinPoint, ref MaxPoint);
      for (int index = 0; index <= Points.Count - 1; ++index)
      {
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top)
        {
          if (Points[index].Z >= MaxPoint.Z - ExternalDepth)
            List.Add(Math.Round(Points[index].Z, 3));
        }
        else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
        {
          if (Points[index].Z <= MinPoint.Z + ExternalDepth)
            List.Add(Math.Round(Points[index].Z, 3));
        }
        else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
        {
          if (Points[index].Y <= MinPoint.Y + ExternalDepth)
            List.Add(Math.Round(Points[index].Y, 3));
        }
        else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back && Points[index].Y >= MaxPoint.Y - ExternalDepth)
          List.Add(Math.Round(Points[index].Y, 3));
      }
      if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top)
        buFile5.AddValueToList(Math.Round(MaxPoint.Z - ExternalDepth, 3), ref List);
      else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom)
        buFile5.AddValueToList(Math.Round(MinPoint.Z + ExternalDepth, 3), ref List);
      else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
        buFile5.AddValueToList(Math.Round(MinPoint.Y + ExternalDepth, 3), ref List);
      else if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
        buFile5.AddValueToList(Math.Round(MaxPoint.Y - ExternalDepth, 3), ref List);
      if (List.Count >= 2)
      {
        List.Sort();
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
          List.Reverse();
      }
      bool flag = false;
      if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Back)
      {
        for (int index = 0; index <= List.Count - 1; index += 2)
        {
          if (index < List.Count - 1)
          {
            double num = List[index] - List[index + 1];
            if (num >= ((MarbleRuntimeSettings) Options).MinThickness & num <= ((MarbleRuntimeSettings) Options).MaxThickness)
            {
              DepthPositions data = (DepthPositions) new MarbleColorSettings();
              ((MarbleRuntimeSettings) data).TopPosition = List[index];
              ((MarbleRuntimeSettings) data).BottomPosition = List[index + 1] - ExtraDepth;
              ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).BottomPosition - ((MarbleRuntimeSettings) data).TopPosition;
              if (EachLayer)
                ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Add(data);
              else if (!flag)
              {
                ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth = (DepthPositions) new MarbleColorSettings(data);
                flag = true;
              }
            }
          }
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZEnable)
        {
          ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Clear();
          DepthPositions data = (DepthPositions) new MarbleColorSettings();
          ((MarbleRuntimeSettings) data).TopPosition = ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZVal;
          ((MarbleRuntimeSettings) data).BottomPosition = ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZVal - ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExternalDepth - ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExtraDepth;
          ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).BottomPosition - ((MarbleRuntimeSettings) data).TopPosition;
          ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth = (DepthPositions) new MarbleColorSettings(data);
        }
      }
      if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Bottom | ((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Front)
      {
        for (int index = 0; index <= List.Count - 1; index += 2)
        {
          if (index < List.Count - 1)
          {
            double num = List[index + 1] - List[index];
            if (num >= ((MarbleRuntimeSettings) Options).MinThickness & num <= ((MarbleRuntimeSettings) Options).MaxThickness)
            {
              DepthPositions data = (DepthPositions) new MarbleColorSettings();
              ((MarbleRuntimeSettings) data).TopPosition = List[index];
              ((MarbleRuntimeSettings) data).BottomPosition = List[index + 1] + ExtraDepth;
              ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).BottomPosition - ((MarbleRuntimeSettings) data).TopPosition;
              if (EachLayer)
                ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Add(data);
              else if (!flag)
              {
                ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth = (DepthPositions) new MarbleColorSettings(data);
                flag = true;
              }
            }
          }
        }
        if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZEnable)
        {
          ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).DepthValues.Clear();
          DepthPositions data = (DepthPositions) new MarbleColorSettings();
          ((MarbleRuntimeSettings) data).TopPosition = ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZVal;
          ((MarbleRuntimeSettings) data).BottomPosition = ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ManuelZVal + ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExternalDepth + ((ProfileArray) ((ProfileRuntimeSettings) Operation).OperationData).ExtraDepth;
          ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).BottomPosition - ((MarbleRuntimeSettings) data).TopPosition;
          ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth = (DepthPositions) new MarbleColorSettings(data);
        }
      }
      if (((ProfileMirror) ((ProfileRuntimeSettings) Operation).OperationData).selectedPlaneName == planeNames.Free)
      {
        DepthPositions data = (DepthPositions) new MarbleColorSettings();
        ((MarbleRuntimeSettings) data).TopPosition = 0.0;
        ((MarbleRuntimeSettings) data).BottomPosition = 0.0;
        ((MarbleRuntimeSettings) data).Depth = ExternalDepth;
        if (((MarbleRuntimeSettings) data).Depth == 0.0)
          ((MarbleRuntimeSettings) data).Depth = 2.0;
        ((MarbleRuntimeSettings) data).Depth = ((MarbleRuntimeSettings) data).Depth + ExtraDepth;
        ((CreateProfileFromDataOptions) ((ProfileRuntimeSettings) Operation).OperationData).Depth = (DepthPositions) new MarbleColorSettings(data);
      }
      valueFromProfile1 = true;
    }
    return valueFromProfile1;
  }

  public void OperationStepCalculation(
    ProfileOperationData OperationData,
    DepthPositions DepthVal,
    camStep5 Steps,
    ref List<DepthPositions> calcDepth)
  {
    Steps.StartValue = ((MarbleRuntimeSettings) DepthVal).TopPosition;
    if (((ProfileMirror) OperationData).selectedPlaneName == planeNames.Front | ((ProfileMirror) OperationData).selectedPlaneName == planeNames.Bottom)
      Steps.EndValue = ((MarbleRuntimeSettings) DepthVal).TopPosition + ((MarbleRuntimeSettings) DepthVal).Depth;
    if (((ProfileMirror) OperationData).selectedPlaneName == planeNames.Top | ((ProfileMirror) OperationData).selectedPlaneName == planeNames.Back)
      Steps.EndValue = ((MarbleRuntimeSettings) DepthVal).TopPosition + ((MarbleRuntimeSettings) DepthVal).Depth;
    if (((ProfileMirror) OperationData).selectedPlaneName == planeNames.Free)
      Steps.EndValue = ((MarbleRuntimeSettings) DepthVal).Depth;
    Steps.Distance = Steps.EndValue - Steps.StartValue;
    List<double> CalcValues = new List<double>();
    buCall.\u0001.CamStepCalculation(Steps, ref CalcValues);
    if (CalcValues.Count <= 0)
      return;
    for (int index = 0; index <= CalcValues.Count - 1; ++index)
    {
      if (index == 0)
      {
        DepthPositions depthPositions = (DepthPositions) new MarbleColorSettings();
        ((MarbleRuntimeSettings) depthPositions).TopPosition = ((MarbleRuntimeSettings) DepthVal).TopPosition;
        ((MarbleRuntimeSettings) depthPositions).BottomPosition = CalcValues[index];
        ((MarbleRuntimeSettings) depthPositions).Depth = ((MarbleRuntimeSettings) depthPositions).BottomPosition - ((MarbleRuntimeSettings) depthPositions).TopPosition;
        if (((MarbleRuntimeSettings) depthPositions).Depth == 0.0)
          ((MarbleRuntimeSettings) depthPositions).Depth = 2.0;
        calcDepth.Add(depthPositions);
      }
      else
      {
        DepthPositions depthPositions = (DepthPositions) new MarbleColorSettings();
        ((MarbleRuntimeSettings) depthPositions).TopPosition = CalcValues[index - 1];
        ((MarbleRuntimeSettings) depthPositions).BottomPosition = CalcValues[index];
        ((MarbleRuntimeSettings) depthPositions).Depth = ((MarbleRuntimeSettings) depthPositions).BottomPosition - ((MarbleRuntimeSettings) depthPositions).TopPosition;
        if (((MarbleRuntimeSettings) depthPositions).Depth == 0.0)
          ((MarbleRuntimeSettings) depthPositions).Depth = 2.0;
        calcDepth.Add(depthPositions);
      }
    }
  }
}
