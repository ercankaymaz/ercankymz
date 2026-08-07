// Decompiled with JetBrains decompiler
// Type: buCore.AppCalc.buMarbleCalc
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using buClass.Apps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buCore.AppCalc;

public class buMarbleCalc
{
  public static List<marbleCutItems> itemsMultiCut = new List<marbleCutItems>();
  public static List<marbleCutItems> itemsPerpendicularCutHor = new List<marbleCutItems>();
  public static List<marbleCutItems> itemsPerpendicularCutVer = new List<marbleCutItems>();
  public static List<string> LangMarbleStatus = new List<string>();
  public static List<string> LangMarbleMessage = new List<string>();
  public static List<string> LangMarbleCaptions = new List<string>();
  public static List<List<Pnt3D>> pntTeachGrids = new List<List<Pnt3D>>();

  public buMarbleCalc()
  {
    if (!buVector.smethod_0(nameof (buMarbleCalc)))
      throw new RegisterException(nameof (buMarbleCalc));
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

  public void MarbleItemHeightByDirection(
    CamCuttingDirectionType CutDir,
    HeightStepCalculationType StepType,
    double ForwardStep,
    double BackwardStep,
    double StartZ,
    double EndZ,
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    ref List<Pnt3D> CalcPoints)
  {
    try
    {
      List<double> doubleList = new List<double>();
      CalcPoints.Clear();
      if (CutDir == CamCuttingDirectionType.Forward)
      {
        buAppCalc.cVector.StepLengthCalculation(StepType, ForwardStep, StartZ, EndZ, ref doubleList);
        for (int index = 0; index <= doubleList.Count - 1; ++index)
        {
          Pnt3D CalcPoint = new Pnt3D();
          buAppCalc.cVector.XYFromZ(StartPoint, EndPoint, doubleList[index], ref CalcPoint);
          CalcPoints.Add(CalcPoint);
        }
      }
      if (CutDir == CamCuttingDirectionType.Backward)
      {
        buAppCalc.cVector.StepLengthCalculation(StepType, BackwardStep, StartZ, EndZ, ref doubleList);
        for (int index = 0; index <= doubleList.Count - 1; ++index)
        {
          Pnt3D CalcPoint = new Pnt3D();
          buAppCalc.cVector.XYFromZ(StartPoint, EndPoint, doubleList[index], ref CalcPoint);
          CalcPoints.Add(CalcPoint);
        }
      }
      if (CutDir != CamCuttingDirectionType.ForwardBackward)
        return;
      buAppCalc.cVector.StepLengthCalculation(StepType, ForwardStep + BackwardStep, StartZ, EndZ, ref doubleList);
      List<double> SourceList = new List<double>();
      double num1 = StartZ;
      for (int index = 0; index <= doubleList.Count - 1; ++index)
      {
        double num2 = num1 - doubleList[index];
        double num3 = BackwardStep / num2;
        if (num2 >= ForwardStep + BackwardStep)
        {
          SourceList.Add(num2 * num3 + doubleList[index]);
          SourceList.Add(doubleList[index]);
        }
        else
          SourceList.Add(doubleList[index]);
        num1 = doubleList[index];
      }
      buGeneral.CopyLists(SourceList, ref doubleList);
      for (int index = 0; index <= doubleList.Count - 1; ++index)
      {
        Pnt3D CalcPoint = new Pnt3D();
        buAppCalc.cVector.XYFromZ(StartPoint, EndPoint, doubleList[index], ref CalcPoint);
        CalcPoints.Add(CalcPoint);
      }
    }
    catch (Exception ex)
    {
      string str = $"CutDir: {CutDir.ToString()} - StepType: {StepType.ToString()} - ForwardStep: {ForwardStep.ToString()} - BackwardStep: {BackwardStep.ToString()} - StepStartZ: {StartZ.ToString()} - EndZ: {EndZ.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public bool MarbleItemEntitiesCalculation(
    Pnt3D StartPoint,
    Pnt3D EndPoint,
    double MaterialThickness,
    double ToolThickness,
    double PitchAngle,
    double TangentAngle,
    bool Perpendicular,
    marbleOperation OperationPars,
    List<marbleCutItems> Items,
    ref List<List<eEntities>> CalcEntities,
    ref List<Quad3D> ItemSlices)
  {
    try
    {
      List<eEntities> eEntitiesList1 = new List<eEntities>();
      Pnt3D EndPnt1 = new Pnt3D(StartPoint);
      Pnt3D EndPnt2 = new Pnt3D(EndPoint);
      Pnt3D BasePnt = new Pnt3D();
      Pnt3D StartPoint1 = new Pnt3D();
      Pnt9D pnt9D1 = new Pnt9D();
      int num1 = 0;
      double num2 = MaterialThickness - OperationPars.TargetZ;
      double num3 = OperationPars.CamParameters.ForwardStepDownDistance;
      double num4 = ToolThickness / 2.0;
      CalcEntities = new List<List<eEntities>>();
      if (OperationPars.CamParameters.FirstEnterDistance > 0.0)
        buAppCalc.cVector.LineWithLengthAndAngle(StartPoint, OperationPars.CamParameters.FirstEnterDistance, TangentAngle + 180.0, new WorkPlane(), ref BasePnt, ref EndPnt1);
      if (OperationPars.CamParameters.LastOutDistance > 0.0)
        buAppCalc.cVector.LineWithLengthAndAngle(EndPoint, OperationPars.CamParameters.LastOutDistance, TangentAngle, new WorkPlane(), ref BasePnt, ref EndPnt2);
      Pnt3D pnt3D1 = new Pnt3D(EndPnt1);
      Pnt3D pnt3D2 = new Pnt3D(EndPnt2);
      Pnt3D pnt3D3 = new Pnt3D();
      Pnt3D pnt3D4 = new Pnt3D();
      Pnt3D pnt3D5 = new Pnt3D();
      Pnt3D pnt3D6 = new Pnt3D();
      for (int index1 = 0; index1 <= Items.Count - 1; ++index1)
      {
        eLine eLine1 = new eLine();
        if (!Perpendicular)
        {
          double num5 = (Items[index1].Length + ToolThickness) / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
          double num6 = Items[index1].Length / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
          double num7 = ToolThickness / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
          double num8 = ToolThickness * 0.5 / Math.Cos(buConversion.DegreeToRadian(TangentAngle));
          for (int index2 = 0; index2 <= Items[index1].Count - 1; ++index2)
          {
            Pnt3D FirstPoint = new Pnt3D(EndPnt1.X, EndPnt1.Y + num7, EndPnt1.Z);
            Pnt3D SecondPoint = new Pnt3D(EndPnt2.X, EndPnt2.Y + num7, EndPnt2.Z);
            Pnt3D pnt3D7 = new Pnt3D(FirstPoint.X, FirstPoint.Y + num6, FirstPoint.Z);
            Pnt3D pnt3D8 = new Pnt3D(SecondPoint.X, SecondPoint.Y + num6, SecondPoint.Z);
            Quad3D quad3D = new Quad3D(FirstPoint, SecondPoint, pnt3D8, pnt3D7);
            ItemSlices.Add(quad3D);
            if (index1 == 0 & index2 == 0)
            {
              eLine eLine2 = new eLine(new Pnt3D(FirstPoint.X, FirstPoint.Y - num8, FirstPoint.Z), new Pnt3D(SecondPoint.X, SecondPoint.Y - num8, SecondPoint.Z));
              eLine2.Orientation = new OrientationAngle(Items[index1].StartAngle, 0.0, TangentAngle);
              eEntitiesList1.Add((eEntities) eLine2);
            }
            if (index1 > 0 | index2 > 0 & eEntitiesList1[eEntitiesList1.Count - 1].Orientation.A != Items[index1].StartAngle)
            {
              eLine eLine3 = new eLine(new Pnt3D(FirstPoint.X, FirstPoint.Y - num8, FirstPoint.Z), new Pnt3D(SecondPoint.X, SecondPoint.Y - num8, SecondPoint.Z));
              eLine3.Orientation = new OrientationAngle(Items[index1].StartAngle, 0.0, TangentAngle);
              eEntitiesList1.Add((eEntities) eLine3);
            }
            eLine eLine4 = new eLine(new Pnt3D(pnt3D7.X, pnt3D7.Y + num8, pnt3D7.Z), new Pnt3D(pnt3D8.X, pnt3D8.Y + num8, pnt3D8.Z));
            eLine4.Orientation = new OrientationAngle(Items[index1].EndAngle * -1.0, 0.0, TangentAngle);
            eEntitiesList1.Add((eEntities) eLine4);
            EndPnt1 = new Pnt3D(pnt3D7);
            EndPnt2 = new Pnt3D(pnt3D8);
          }
        }
        if (Perpendicular)
        {
          double num9 = (Items[index1].Length + ToolThickness) / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
          double num10 = Items[index1].Length / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
          double num11 = ToolThickness / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
          double num12 = ToolThickness * 0.5 / Math.Sin(buConversion.DegreeToRadian(TangentAngle));
          for (int index3 = 0; index3 <= Items[index1].Count - 1; ++index3)
          {
            Pnt3D FirstPoint = new Pnt3D(EndPnt1.X + num11, EndPnt1.Y, EndPnt1.Z);
            Pnt3D SecondPoint = new Pnt3D(EndPnt2.X + num11, EndPnt2.Y, EndPnt2.Z);
            Pnt3D pnt3D9 = new Pnt3D(FirstPoint.X + num10, FirstPoint.Y, FirstPoint.Z);
            Pnt3D pnt3D10 = new Pnt3D(SecondPoint.X + num10, SecondPoint.Y, SecondPoint.Z);
            Quad3D quad3D = new Quad3D(FirstPoint, SecondPoint, pnt3D10, pnt3D9);
            ItemSlices.Add(quad3D);
            if (index1 == 0 & index3 == 0)
            {
              eLine eLine5 = new eLine(new Pnt3D(FirstPoint.X - num12, FirstPoint.Y, FirstPoint.Z), new Pnt3D(SecondPoint.X - num12, SecondPoint.Y, SecondPoint.Z));
              eLine5.Orientation = new OrientationAngle(Items[index1].StartAngle, 0.0, TangentAngle);
              eEntitiesList1.Add((eEntities) eLine5);
            }
            if (index1 > 0 | index3 > 0 & eEntitiesList1[eEntitiesList1.Count - 1].Orientation.A != Items[index1].StartAngle)
            {
              eLine eLine6 = new eLine(new Pnt3D(FirstPoint.X - num12, FirstPoint.Y, FirstPoint.Z), new Pnt3D(SecondPoint.X - num12, SecondPoint.Y, SecondPoint.Z));
              eLine6.Orientation = new OrientationAngle(Items[index1].StartAngle, 0.0, TangentAngle);
              eEntitiesList1.Add((eEntities) eLine6);
            }
            eLine eLine7 = new eLine(new Pnt3D(pnt3D9.X + num12, pnt3D9.Y, pnt3D9.Z), new Pnt3D(pnt3D10.X + num12, pnt3D10.Y, pnt3D10.Z));
            eLine7.Orientation = new OrientationAngle(Items[index1].EndAngle * -1.0, 0.0, TangentAngle);
            eEntitiesList1.Add((eEntities) eLine7);
            EndPnt1 = new Pnt3D(pnt3D9);
            EndPnt2 = new Pnt3D(pnt3D10);
          }
        }
      }
      Pnt9D pnt9D2 = new Pnt9D(EndPnt1.X, EndPnt1.Y, 0.0);
      if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Forward)
        num3 = OperationPars.CamParameters.ForwardStepDownDistance;
      if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
        num3 = OperationPars.CamParameters.BackwardStepDownDistance;
      if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward)
        num3 = OperationPars.CamParameters.ForwardStepDownDistance + OperationPars.CamParameters.BackwardStepDownDistance;
      int int32 = Convert.ToInt32(Math.Ceiling(num2 / num3));
      if (int32 > 1)
        num3 = num2 / (double) int32;
      if (OperationPars.CamParameters.CuttingOrderDirection == CamCuttingOrderDirectionType.Region)
      {
        for (int index4 = 0; index4 <= eEntitiesList1.Count - 1; ++index4)
        {
          List<eEntities> eEntitiesList2 = new List<eEntities>();
          Pnt3D pnt3D11 = new Pnt3D(eEntitiesList1[index4].Vertice[0]);
          Pnt3D pnt3D12 = new Pnt3D(eEntitiesList1[index4].Vertice[eEntitiesList1[index4].Vertice.Count - 1]);
          if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
          {
            pnt3D11 = new Pnt3D(eEntitiesList1[index4].Vertice[eEntitiesList1[index4].Vertice.Count - 1]);
            pnt3D12 = new Pnt3D(eEntitiesList1[index4].Vertice[0]);
          }
          if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward & num1 % 2 == 1)
          {
            pnt3D11 = new Pnt3D(eEntitiesList1[index4].Vertice[eEntitiesList1[index4].Vertice.Count - 1]);
            pnt3D12 = new Pnt3D(eEntitiesList1[index4].Vertice[0]);
          }
          if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Forward | OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
          {
            eLine eLine8 = new eLine();
            for (int index5 = 1; index5 <= int32; ++index5)
            {
              double num13 = MaterialThickness - (double) index5 * num3;
              if (num13 < 0.0)
                num13 = 0.0;
              pnt3D11.Z = num13;
              pnt3D12.Z = num13;
              eLine eLine9 = new eLine(pnt3D11, pnt3D12);
              eLine9.Orientation = new OrientationAngle(eEntitiesList1[index4].Orientation);
              eLine9.auxText = "Fwd";
              if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
                eLine9.auxText = "Bwd";
              eEntitiesList2.Add((eEntities) eLine9);
              if (eEntitiesList2.Count > 0)
                CalcEntities.Add(eEntitiesList2);
              eEntitiesList2 = new List<eEntities>();
              ++num1;
            }
          }
          if (OperationPars.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward)
          {
            List<Pnt3D> pnt3DList = new List<Pnt3D>();
            eLine eLine10 = new eLine();
            for (int index6 = 1; index6 <= int32; ++index6)
            {
              double z1 = MaterialThickness - (double) index6 * num3 + OperationPars.CamParameters.BackwardStepDownDistance;
              if (z1 < 0.0)
                z1 = 0.0;
              if (index6 > 1)
              {
                eLine eLine11 = new eLine(StartPoint1, new Pnt3D(StartPoint1.X, StartPoint1.Y, z1));
                eLine11.Orientation = new OrientationAngle(eEntitiesList1[index4].Orientation);
                eLine11.auxText = "Plunge";
                eEntitiesList2.Add((eEntities) eLine11);
              }
              pnt3D11.Z = z1;
              pnt3D12.Z = z1;
              eLine eLine12 = new eLine(new Pnt3D(pnt3D11), new Pnt3D(pnt3D12));
              eLine12.Orientation = new OrientationAngle(eEntitiesList1[index4].Orientation);
              eLine12.auxText = "Fwd";
              eEntitiesList2.Add((eEntities) eLine12);
              double z2 = MaterialThickness - (double) index6 * num3;
              eLine eLine13 = new eLine(pnt3D12, new Pnt3D(pnt3D12.X, pnt3D12.Y, z2));
              eLine13.Orientation = new OrientationAngle(eEntitiesList1[index4].Orientation);
              eLine13.auxText = "Plunge";
              eEntitiesList2.Add((eEntities) eLine13);
              pnt3D11.Z = z2;
              pnt3D12.Z = z2;
              eLine eLine14 = new eLine(new Pnt3D(pnt3D12), new Pnt3D(pnt3D11));
              eLine14.Orientation = new OrientationAngle(eEntitiesList1[index4].Orientation);
              eLine14.auxText = "Bwd";
              eEntitiesList2.Add((eEntities) eLine14);
              StartPoint1 = new Pnt3D(eLine14.EndPoint);
              ++num1;
            }
          }
          if (eEntitiesList2.Count > 0)
            CalcEntities.Add(eEntitiesList2);
        }
      }
      return true;
    }
    catch (Exception ex)
    {
      string str = $"StartPoint: {StartPoint.ToString()} - EndPoint: {EndPoint.ToString()} - MaterialThickness: {MaterialThickness.ToString()} - ToolThickness: {ToolThickness.ToString()} - TangentAngle: {TangentAngle.ToString()} - PitchAngle: {PitchAngle.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return false;
    }
  }

  public void MarblecalcItemLines(
    Pnt3D FirstUpPnt,
    Pnt3D FirstDownPnt,
    Pnt3D LastUpPnt,
    Pnt3D LastDownPnt,
    ToolBase Tool,
    double StartAngle,
    double EndAngle,
    double LastA,
    Pnt6D Position,
    bool StartMode,
    marbleOperation varOperation,
    ref List<List<eEntities>> Entities)
  {
    List<eEntities> eEntitiesList1 = new List<eEntities>();
    List<Pnt3D> CalcPoints1 = new List<Pnt3D>();
    List<Pnt3D> CalcPoints2 = new List<Pnt3D>();
    this.MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, FirstUpPnt, FirstDownPnt, ref CalcPoints1);
    this.MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, LastUpPnt, LastDownPnt, ref CalcPoints2);
    List<eEntities> eEntitiesList2 = new List<eEntities>();
    for (int index = 0; index <= CalcPoints1.Count - 1; ++index)
    {
      eLine eLine = new eLine(CalcPoints1[index], CalcPoints2[index], (float) Tool.Geometry.Thickness, Color.Lime);
      if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
      {
        eLine.camDirections = camPathDirectionType.Reverse;
        eLine.auxText = "Backward";
      }
      if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward && index % 2 == 1)
      {
        eLine.camDirections = camPathDirectionType.Reverse;
        eLine.auxText = "Backward";
      }
      if (StartMode)
      {
        if (StartAngle > 0.0)
        {
          eLine.Orientation = new OrientationAngle(StartAngle, 0.0, Position.C + 180.0);
          buAppCalc.cVector.CamDirectionChange(ref eLine.camDirections);
        }
        else
          eLine.Orientation = new OrientationAngle(StartAngle * -1.0, 0.0, Position.C);
      }
      else if (EndAngle >= 0.0)
      {
        eLine.Orientation = new OrientationAngle(EndAngle, 0.0, Position.C);
      }
      else
      {
        eLine.Orientation = new OrientationAngle(EndAngle * -1.0, 0.0, Position.C + 180.0);
        buAppCalc.cVector.CamDirectionChange(ref eLine.camDirections);
      }
      eEntitiesList2.Add((eEntities) eLine);
    }
    if (StartMode)
    {
      if (eEntitiesList2.Count <= 0)
        return;
      if (Entities.Count == 0)
      {
        Entities.Add(eEntitiesList2);
      }
      else
      {
        if (LastA == StartAngle)
          return;
        Entities.Add(eEntitiesList2);
      }
    }
    else
    {
      if (eEntitiesList2.Count <= 0)
        return;
      Entities.Add(eEntitiesList2);
    }
  }

  public void MarblecalcItemCam(
    List<List<eEntities>> CamEntities,
    ToolBase Tool,
    List<eEntities> ItemEntities,
    List<marbleCutItems> Items,
    string CamName,
    marbleOperation varOperation,
    KinematicBase Kinematic,
    EntitiesResolution Resolutions,
    ref camBase Cam)
  {
    if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.Forward | varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
    {
      List<List<eEntities>> SourceList = new List<List<eEntities>>();
      for (int index1 = 0; index1 <= CamEntities.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= CamEntities[index1].Count - 1; ++index2)
        {
          List<eEntities> eEntitiesList = new List<eEntities>();
          eEntities copiedEnt = new eEntities();
          eEntities.CopyEntity(CamEntities[index1][index2], ref copiedEnt);
          eEntitiesList.Add(copiedEnt);
          SourceList.Add(eEntitiesList);
        }
      }
      buGeneral.CopyLists(SourceList, ref CamEntities);
    }
    Cam = new camBase();
    Cam.Tool = new ToolBase(Tool);
    camSpeeds speeds = new camSpeeds(varOperation.CamParameters.ForwardCuttingVelocity, varOperation.CamParameters.PlungeVelocity, 100.0, varOperation.CamParameters.LeaveVelocity, varOperation.CamParameters.BackwardCuttingVelocity, 100.0);
    camDistances distance = new camDistances(varOperation.CamParameters.SafeDistance, varOperation.CamParameters.StepUpDistance, varOperation.CamParameters.AirDistance, false);
    buAppCalc.cCam.CalculateMarbleWireFrameWithSaw(CamEntities, new List<List<eEntities>>(), Kinematic, Tool, varOperation, varOperation.CamParameters, new camParameters()
    {
      Speeds = new camSpeeds(speeds),
      Distances = new camDistances(distance)
    }, Resolutions, ref Cam);
    Cam.ItemEntities.AddRange((IEnumerable<eEntities>) ItemEntities);
    Cam.Name = CamName;
    for (int index = 0; index <= Items.Count - 1; ++index)
      Cam.PreCodes.Add((object) $"// Item ;{Items[index].Length.ToString()};{Items[index].Count.ToString()};{Items[index].StartAngle.ToString()};{Items[index].EndAngle.ToString()}");
    for (int index3 = 0; index3 <= Cam.CamPoints.Count - 1; ++index3)
    {
      for (int index4 = 0; index4 <= Cam.CamPoints[index3].Points.Count - 1; ++index4)
      {
        Pnt9D Pnt = new Pnt9D(Cam.CamPoints[index3].Points[index4].P9);
        Pnt.X += Kinematic.OffsetXYZ.X;
        Pnt.Y += Kinematic.OffsetXYZ.Y;
        Pnt.Z = Pnt.Z + Kinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
        Cam.CamPoints[index3].Points[index4].P9 = new Pnt9D(Pnt);
      }
    }
    for (int index5 = 0; index5 <= Cam.CamPoints.Count - 1; ++index5)
    {
      for (int index6 = 0; index6 <= Cam.CamPoints[index5].SimilationPoint.SimDetailedPoints.Count - 1; ++index6)
        new Pnt6DSim(Cam.CamPoints[index5].SimilationPoint.SimDetailedPoints[index6]).Z -= Tool.Geometry.Diameter / 2.0;
    }
  }

  public void doSingleCut(
    Pnt6D Position,
    ToolBase Tool,
    marbleOperation varOperation,
    KinematicBase Kinematic,
    EntitiesResolution Resolution,
    ref camBase Cam)
  {
    List<eEntities> eEntitiesList1 = new List<eEntities>();
    Pnt6D pnt6D = new Pnt6D(Math.Round(Position.X, 3), Math.Round(Position.Y, 3), Math.Round(Position.Z, 3), Math.Round(Position.A, 3), 0.0, Math.Round(Position.C, 3));
    eEntities eEntities = new eEntities();
    List<eEntities> ItemEntities = new List<eEntities>();
    List<List<eEntities>> CamEntities = new List<List<eEntities>>();
    List<Pnt3D> Vertices = new List<Pnt3D>();
    double Height = varOperation.MaterialThickness / Math.Sin(buConversion.DegreeToRadian(pnt6D.A + 90.0));
    buAppCalc.cVector.Plane3D(new Pnt3D(pnt6D.X, pnt6D.Y, varOperation.MaterialThickness), new Vec3D(1.0, 0.0, 0.0), new OrientationAngle(pnt6D.A - 90.0, 0.0, pnt6D.C), varOperation.CutLength, Height, ref Vertices);
    List<Pnt3D> CalcPoints1 = new List<Pnt3D>();
    List<Pnt3D> CalcPoints2 = new List<Pnt3D>();
    this.MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, Vertices[0], Vertices[3], ref CalcPoints1);
    this.MarbleItemHeightByDirection(varOperation.CamParameters.CuttingDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.CamParameters.ForwardStepDownDistance, varOperation.CamParameters.BackwardStepDownDistance, varOperation.MaterialThickness, varOperation.TargetZ, Vertices[1], Vertices[2], ref CalcPoints2);
    List<eEntities> eEntitiesList2 = new List<eEntities>();
    for (int index = 0; index <= CalcPoints1.Count - 1; ++index)
    {
      eLine eLine = new eLine(CalcPoints1[index], CalcPoints2[index], 4f, Color.Lime);
      LeadIn In = new LeadIn(true, 0.0, LeadInOutType.Line, varOperation.CamParameters.FirstEnterDistance);
      LeadOut Out = new LeadOut(true, 0.0, LeadInOutType.Line, varOperation.CamParameters.LastOutDistance);
      eEntities LeadInEntitiy = new eEntities();
      eEntities LeadOutEntitiy = new eEntities();
      buAppCalc.cCam.LeadInOutCalculation((eEntities) eLine, (eEntities) eLine, In, Out, new WorkPlane(), ClockDirectionType.CW, ref LeadInEntitiy, ref LeadOutEntitiy);
      eLine.StartPoint = new Pnt3D(LeadInEntitiy.Vertice[0]);
      eLine.EndPoint = new Pnt3D(LeadOutEntitiy.Vertice[LeadOutEntitiy.Vertice.Count - 1]);
      if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.Backward)
      {
        eLine.camDirections = camPathDirectionType.Reverse;
        eLine.auxText = "BackWard";
      }
      if (varOperation.CamParameters.CuttingDirection == CamCuttingDirectionType.ForwardBackward && index % 2 == 1)
      {
        eLine.camDirections = camPathDirectionType.Reverse;
        eLine.auxText = "Backward";
      }
      if (pnt6D.A >= 0.0)
        eLine.Orientation = new OrientationAngle(pnt6D.A, 0.0, pnt6D.C);
      else
        eLine.Orientation = new OrientationAngle(pnt6D.A * -1.0, 0.0, pnt6D.C);
      eEntitiesList2.Add((eEntities) eLine);
    }
    if (eEntitiesList2.Count > 0)
      CamEntities.Add(eEntitiesList2);
    this.MarblecalcItemCam(CamEntities, Tool, ItemEntities, new List<marbleCutItems>(), "Multi Cut - [Marble]", varOperation, Kinematic, Resolution, ref Cam);
    Cam.Kinematic = new KinematicBase(Kinematic);
  }

  public void doMultiCut(
    Pnt6D Position,
    ToolBase Tool,
    List<marbleCutItems> Items,
    bool VerticalCut,
    marbleOperation varOperation,
    KinematicBase Kinematic,
    EntitiesResolution Resolution,
    ref camBase Cam)
  {
    eEntities eEntities = new eEntities();
    List<eEntities> eEntitiesList = new List<eEntities>();
    List<eEntities> Entities = new List<eEntities>();
    List<List<eEntities>> CalcLines = new List<List<eEntities>>();
    if (!VerticalCut)
      this.HorizontalItemsCalc(Position, Tool, Items, varOperation, varOperation.CutLength, Kinematic, ref Cam, ref Entities, ref CalcLines);
    else
      this.VerticalItemsCalc(Position, Tool, Items, varOperation, varOperation.CutLength, Kinematic, ref Cam, ref Entities, ref CalcLines);
    this.MarblecalcItemCam(CalcLines, Tool, Entities, Items, "Multi Cut - [Marble]", varOperation, Kinematic, Resolution, ref Cam);
  }

  public void doPerpendicularCut(
    Pnt6D HorizontalPosition,
    Pnt6D VerticalPosition,
    ToolBase Tool,
    List<marbleCutItems> HorizontalItems,
    List<marbleCutItems> VerticalItems,
    marbleOperation varOperation,
    KinematicBase Kinematic,
    EntitiesResolution Resolution,
    ref camBase Cam)
  {
    List<List<eEntities>> CalcLines1 = new List<List<eEntities>>();
    List<List<eEntities>> CalcLines2 = new List<List<eEntities>>();
    List<eEntities> Entities = new List<eEntities>();
    List<marbleCutItems> Items = new List<marbleCutItems>();
    if (!varOperation.VerticalFirst)
    {
      if (HorizontalItems.Count > 0)
        this.HorizontalItemsCalc(HorizontalPosition, Tool, HorizontalItems, varOperation, varOperation.CutLengthHorizontal, Kinematic, ref Cam, ref Entities, ref CalcLines1);
      if (VerticalItems.Count > 0)
      {
        if (VerticalPosition.C == HorizontalPosition.C)
          VerticalPosition.C = HorizontalPosition.C + 90.0;
        this.VerticalItemsCalc(VerticalPosition, Tool, VerticalItems, varOperation, varOperation.CutLengthVertical, Kinematic, ref Cam, ref Entities, ref CalcLines2);
      }
      for (int index = 0; index <= CalcLines2.Count - 1; ++index)
      {
        List<eEntities> CopiedEnt = new List<eEntities>();
        eEntities.CopyEntities(CalcLines2[index], ref CopiedEnt);
        CalcLines1.Add(CopiedEnt);
      }
      for (int index = 0; index <= HorizontalItems.Count - 1; ++index)
        Items.Add(new marbleCutItems(HorizontalItems[index]));
      for (int index = 0; index <= VerticalItems.Count - 1; ++index)
        Items.Add(new marbleCutItems(VerticalItems[index]));
      this.MarblecalcItemCam(CalcLines1, Tool, Entities, Items, "Perpendicular Cut - [Marble]", varOperation, Kinematic, Resolution, ref Cam);
    }
    else
    {
      if (VerticalItems.Count > 0)
        this.VerticalItemsCalc(VerticalPosition, Tool, VerticalItems, varOperation, varOperation.CutLengthVertical, Kinematic, ref Cam, ref Entities, ref CalcLines2);
      if (HorizontalItems.Count > 0)
      {
        if (VerticalPosition.C == HorizontalPosition.C)
          HorizontalPosition.C -= 90.0;
        this.HorizontalItemsCalc(HorizontalPosition, Tool, HorizontalItems, varOperation, varOperation.CutLengthHorizontal, Kinematic, ref Cam, ref Entities, ref CalcLines1);
      }
      for (int index = 0; index <= CalcLines1.Count - 1; ++index)
      {
        List<eEntities> CopiedEnt = new List<eEntities>();
        eEntities.CopyEntities(CalcLines1[index], ref CopiedEnt);
        CalcLines2.Add(CopiedEnt);
      }
      for (int index = 0; index <= VerticalItems.Count - 1; ++index)
        Items.Add(new marbleCutItems(VerticalItems[index]));
      for (int index = 0; index <= HorizontalItems.Count - 1; ++index)
        Items.Add(new marbleCutItems(HorizontalItems[index]));
      this.MarblecalcItemCam(CalcLines2, Tool, Entities, Items, "Perpendicular Cut - [Marble]", varOperation, Kinematic, Resolution, ref Cam);
    }
  }

  public void HorizontalItemsCalc(
    Pnt6D Position,
    ToolBase Tool,
    List<marbleCutItems> Items,
    marbleOperation varOperation,
    double CutLength,
    KinematicBase Kinematic,
    ref camBase Cam,
    ref List<eEntities> Entities,
    ref List<List<eEntities>> CalcLines)
  {
    double y = 0.0;
    double LastA = 0.0;
    double num1 = 1.0;
    eEntities SurfaceEntity = new eEntities();
    double materialThickness = varOperation.MaterialThickness;
    double num2 = Math.Round(Position.C);
    if (Items.Count == 0)
      return;
    if (Items[0].Length < 0.0)
      num1 = -1.0;
    for (int index1 = 0; index1 <= Items.Count - 1; ++index1)
    {
      List<Quad3D> Quads = new List<Quad3D>();
      double startAngle = Items[index1].StartAngle;
      double endAngle = Items[index1].EndAngle;
      double TrapezTopWidth = Math.Abs(Items[index1].Length);
      double num3 = 360.0;
      if (startAngle > 0.0)
        TrapezTopWidth -= materialThickness * Math.Tan(buConversion.DegreeToRadian(startAngle));
      if (endAngle > 0.0)
        TrapezTopWidth -= materialThickness * Math.Tan(buConversion.DegreeToRadian(endAngle));
      if (index1 <= Items.Count - 2)
        num3 = Items[index1 + 1].StartAngle;
      buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), TrapezTopWidth, varOperation.MaterialThickness - varOperation.TargetZ, startAngle + 90.0, endAngle + 90.0, new Vec3D(1.0, 0.0, 0.0), CutLength, num2, ref Quads, ref SurfaceEntity);
      if (num1 < 0.0)
      {
        startAngle *= -1.0;
        endAngle *= -1.0;
      }
      for (int index2 = 0; index2 <= Items[index1].Count - 1; ++index2)
      {
        List<Pnt3D> pnt3DList1 = new List<Pnt3D>();
        List<Pnt3D> pnt3DList2 = new List<Pnt3D>();
        eEntities CalcEnt = new eEntities();
        double num4 = 0.0;
        double num5 = Math.Abs(Items[index1].Length) / Math.Cos(buConversion.DegreeToRadian(num2));
        double num6 = 0.0;
        double num7 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(startAngle)));
        double num8 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(endAngle)));
        double num9 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(startAngle)));
        double num10 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(endAngle)));
        double num11 = num8;
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(0.0, y, 0.0), SurfaceEntity, ref CalcEnt);
        CalcEnt.LayerIndex = varOperation.HorizontalLayerIndex;
        Entities.Add(CalcEnt);
        if (index1 == 0 & index2 == 0 | LastA != startAngle)
          num4 = num9;
        if (index2 <= Items[index1].Count - 2 && endAngle != -startAngle)
          num6 = 4.0;
        if (index2 == Items[index1].Count - 1 && endAngle != -num3)
          num6 = 4.0;
        Quad3D Quad1 = new Quad3D(Quads[5]);
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(0.0, y - num4, 0.0), ref Quad1);
        this.MarblecalcItemLines(Quad1.FirstPoint, Quad1.SecondPoint, Quad1.FourthPoint, Quad1.ThirdPoint, Tool, startAngle, endAngle, LastA, Position, true, varOperation, ref CalcLines);
        Quad3D Quad2 = new Quad3D(Quads[3]);
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(0.0, y + num10, 0.0), ref Quad2);
        this.MarblecalcItemLines(Quad2.FirstPoint, Quad2.SecondPoint, Quad2.FourthPoint, Quad2.ThirdPoint, Tool, startAngle, endAngle, LastA, Position, false, varOperation, ref CalcLines);
        LastA = endAngle * -1.0;
        y = y + num5 + num11 + num6;
      }
    }
    if (num1 >= 0.0)
      return;
    buAppCalc.cVector.Mirror(new Pnt3D(0.0, Position.Y, 0.0), new Pnt3D(1.0, Position.Y, 0.0), new WorkPlane(), 0.0, ref Entities);
    buAppCalc.cVector.Mirror(new Pnt3D(0.0, Position.Y, 0.0), new Pnt3D(1.0, Position.Y, 0.0), new WorkPlane(), 0.0, ref CalcLines);
  }

  public void VerticalItemsCalc(
    Pnt6D Position,
    ToolBase Tool,
    List<marbleCutItems> Items,
    marbleOperation varOperation,
    double CutLength,
    KinematicBase Kinematic,
    ref camBase Cam,
    ref List<eEntities> Entities,
    ref List<List<eEntities>> CalcLines)
  {
    double x = 0.0;
    double LastA = 0.0;
    double num1 = 1.0;
    double num2 = 1.0;
    eEntities Ent = new eEntities();
    double materialThickness = varOperation.MaterialThickness;
    double num3 = Math.Round(Position.C);
    if (Items.Count == 0)
      return;
    if (Items[0].Length < 0.0)
      num1 = -1.0;
    if (num3 < 0.0)
    {
      double num4 = num2 * -1.0;
    }
    for (int index1 = 0; index1 <= Items.Count - 1; ++index1)
    {
      List<Quad3D> Quads = new List<Quad3D>();
      double startAngle = Items[index1].StartAngle;
      double endAngle = Items[index1].EndAngle;
      double TrapezTopWidth = Math.Abs(Items[index1].Length);
      double num5 = 360.0;
      if (startAngle < 0.0)
        TrapezTopWidth -= materialThickness * Math.Tan(buConversion.DegreeToRadian(startAngle));
      if (endAngle < 0.0)
        TrapezTopWidth -= materialThickness * Math.Tan(buConversion.DegreeToRadian(endAngle));
      if (index1 <= Items.Count - 2)
        num5 = Items[index1 + 1].StartAngle;
      double num6 = -startAngle;
      double num7 = -endAngle;
      buAppCalc.cVector.Trapezoid3D(new Pnt3D(Position.X, Position.Y, varOperation.MaterialThickness), TrapezTopWidth, varOperation.MaterialThickness, num6 + 90.0, num7 + 90.0, new Vec3D(0.0, 1.0, 0.0), CutLength, Math.Abs(Position.C) - 90.0, ref Quads, ref Ent);
      if (num3 < 0.0)
      {
        buAppCalc.cVector.Mirror(new Pnt3D(0.0, Position.Y, 0.0), new Pnt3D(1.0, Position.Y, 0.0), new WorkPlane(), 0.0, ref Quads);
        buAppCalc.cVector.Mirror(new Pnt3D(0.0, Position.Y, 0.0), new Pnt3D(1.0, Position.Y, 0.0), new WorkPlane(), 0.0, ref Ent);
        startAngle *= -1.0;
        endAngle *= -1.0;
      }
      if (num1 < 0.0)
      {
        startAngle *= -1.0;
        endAngle *= -1.0;
      }
      for (int index2 = 0; index2 <= Items[index1].Count - 1; ++index2)
      {
        List<Pnt3D> pnt3DList1 = new List<Pnt3D>();
        List<Pnt3D> pnt3DList2 = new List<Pnt3D>();
        eEntities CalcEnt = new eEntities();
        double num8 = 0.0;
        double num9 = Math.Abs(Items[index1].Length) / Math.Sin(buConversion.DegreeToRadian(Math.Abs(num3)));
        double num10 = 0.0;
        double num11 = 0.0;
        double num12 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(startAngle)));
        double num13 = Tool.Geometry.Thickness / Math.Cos(buConversion.DegreeToRadian(Math.Abs(endAngle)));
        double num14 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(startAngle)));
        double num15 = Tool.Geometry.Thickness / 2.0 / Math.Cos(buConversion.DegreeToRadian(Math.Abs(endAngle)));
        num10 = Math.Abs(num12) <= Math.Abs(num13) ? num13 : num12;
        double num16 = num13;
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(x, 0.0, 0.0), Ent, ref CalcEnt);
        CalcEnt.LayerIndex = varOperation.VerticalLayerIndex;
        Entities.Add(CalcEnt);
        if (index1 == 0 & index2 == 0 | LastA != startAngle)
          num8 = num14;
        if (index2 <= Items[index1].Count - 2 && endAngle != -startAngle)
          num11 = 4.0;
        if (index2 == Items[index1].Count - 1 && endAngle != -num5)
          num11 = 4.0;
        Quad3D Quad = new Quad3D(Quads[5]);
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(x - num8, 0.0, 0.0), ref Quad);
        this.MarblecalcItemLines(Quad.FirstPoint, Quad.SecondPoint, Quad.ThirdPoint, Quad.FourthPoint, Tool, startAngle, endAngle, LastA, Position, true, varOperation, ref CalcLines);
        Quad = new Quad3D(Quads[3]);
        buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(x + num15, 0.0, 0.0), ref Quad);
        this.MarblecalcItemLines(Quad.FirstPoint, Quad.SecondPoint, Quad.ThirdPoint, Quad.FourthPoint, Tool, startAngle, endAngle, LastA, Position, false, varOperation, ref CalcLines);
        LastA = endAngle * -1.0;
        x = x + num9 + num16 + num11;
      }
    }
    if (num1 >= 0.0)
      return;
    buAppCalc.cVector.Mirror(new Pnt3D(Position.X, 0.0, 0.0), new Pnt3D(Position.X, 1.0, 0.0), new WorkPlane(), 0.0, ref Entities);
    buAppCalc.cVector.Mirror(new Pnt3D(Position.X, 0.0, 0.0), new Pnt3D(Position.X, 1.0, 0.0), new WorkPlane(), 0.0, ref CalcLines);
  }
}
