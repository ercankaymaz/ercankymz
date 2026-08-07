// Decompiled with JetBrains decompiler
// Type: buClass.Apps.marbleOperation
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class marbleOperation : buSerilization
{
  public double MaterialThickness = 20.0;
  public double CutAngle = 0.0;
  public double TargetZ = 0.0;
  public double CutLength = 200.0;
  public double CutLengthHorizontal = 200.0;
  public double CutLengthVertical = 200.0;
  public double OffsetX = 0.0;
  public double OffsetY = 0.0;
  public int SheetNumber = 0;
  public bool CutSawDistanceFromStartPoint = false;
  public bool CutSawDistanceFromEndPoint = false;
  public double CutSawDistanceOverlap = 0.0;
  public double InnerCutSafeDistance = 0.0;
  public Pnt6D AxisValues = new Pnt6D();
  public bool VerticalFirst = false;
  public bool SweepFollowTangent = true;
  public double SweepConstantAngle = 0.0;
  public double SweepOffsetAngleForTangent = 90.0;
  public bool SweepZUpSharpCorner = false;
  public bool UseSweepOperation = false;
  public VectorXYType ProfileCutFinishVector = VectorXYType.XVector;
  public bool ProfileCutFinishEnable = false;
  public bool SawRampEnable = false;
  public double SawRampLenght = 50.0;
  public double SawRampHeight = 10.0;
  public CamZRampType SawRampType = CamZRampType.Circular;
  public double SawDevideLength = 0.5;
  public bool ReverseAngleA = false;
  public bool WaterJet5AxisConcaveCalculation = false;
  public double WaterJet5AxisCOffsetStartEnd = 0.0;
  public double WaterJet5AxisCOffsetMiddle = 0.0;
  public bool ApplySurfaceReadData = false;
  public double SurfaceReadDevideLength = 5.0;
  public double SawDistanceWithDepth = 0.0;
  public bool BreakEntitiesByMouseClickForSaw = false;
  public bool BreakEntitiesByMouseClickForMilling = false;
  public bool BreakEntitiesByMouseClickForWaterJet = true;
  public bool isVertical = false;
  public double OperationMode = 0.0;
  public double WaterJet5AxisReAdjustAPerc1 = 1.0;
  public double WaterJet5AxisReAdjustAPerc2 = 4.5;
  public double WaterJet5AxisReAdjustAPerc3 = 10.0;
  public double WaterJet5AxisReAdjustAPerc4 = 17.0;
  public double WaterJet5AxisReAdjustAPerc5 = 27.0;
  public double WaterJet5AxisReAdjustAPerc6 = 38.0;
  public double WaterJet5AxisReAdjustAPerc7 = 51.0;
  public double WaterJet5AxisReAdjustAPerc8 = 66.0;
  public double WaterJet5AxisReAdjustAPerc9 = 83.0;
  public double WaterJet5AxisReAdjustAPerc10 = 100.0;
  public double WaterJet5AxisARatioCornerAngle60 = 1.462;
  public double WaterJet5AxisARatioCornerAngle70 = 1.381;
  public double WaterJet5AxisARatioCornerAngle80 = 1.301;
  public double WaterJet5AxisARatioCornerAngle90 = 1.235;
  public double WaterJet5AxisARatioCornerAngle100 = 1.185;
  public double WaterJet5AxisARatioCornerAngle110 = 1.114;
  public double WaterJet5AxisARatioCornerAngle120 = 1.1;
  public double WaterJet5AxisARatioCornerAngle130 = 1.068;
  public double WaterJet5AxisARatioCornerAngle140 = 1.044;
  public double WaterJet5AxisARatioCornerAngle150 = 1.024;
  public double WaterJet5AxisARatioCornerAngle160 = 1.01;
  public double WaterJet5AxisARatioCornerAngle170 = 1003.0 / 1000.0;
  public double WaterJet5AxisARatioCornerAngle180 = 1.0;
  public double WaterJet5AxisARtForA0 = 1.0;
  public double WaterJet5AxisARtForA1 = 1.28;
  public double WaterJet5AxisARtForA5 = 1.2;
  public double WaterJet5AxisARtForA10 = 1.15;
  public double WaterJet5AxisARtForA20 = 1.12;
  public double WaterJet5AxisARtForA30 = 1.07;
  public double WaterJet5AxisARtForA40 = 1.05;
  public double WaterJet5AxisARtForA45 = 1.0;
  public double WaterJet5AxisARtForA50 = 0.95;
  public double WaterJetLeadInLength = 0.0;
  public double WaterJetLeadInInsideAngle = 90.0;
  public double WaterJetLeadInOutsideAngle = 0.0;
  public double WaterJetLeadOutLength = 0.0;
  public double WaterJetLeadOutInsideAngle = 90.0;
  public double WaterJetLeadOutOutsideAngle = 0.0;
  public double WaterJet5AxisCRtForA0 = 1.0;
  public double WaterJet5AxisCRtForA1 = 0.54;
  public double WaterJet5AxisCRtForA5 = 0.54;
  public double WaterJet5AxisCRtForA10 = 0.54;
  public double WaterJet5AxisCRtForA20 = 0.54;
  public double WaterJet5AxisCRtForA30 = 0.54;
  public double WaterJet5AxisCRtForA40 = 0.54;
  public double WaterJet5AxisCRtForA45 = 0.54;
  public double WaterJet5AxisCRtForA50 = 0.54;
  public int HorizontalLayerIndex = 2;
  public int VerticalLayerIndex = 3;
  public double MinArcRadiusToCalculate = 1.0;
  public double PointFilterLength = 0.2;
  public marbleCamParameters CamParameters = new marbleCamParameters();
  public static List<string> Captions = new List<string>();

  public marbleOperation()
  {
  }

  public marbleOperation(marbleOperation data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.CamParameters = new marbleCamParameters(data.CamParameters);
  }

  public static void Copy(marbleOperation Source, ref marbleOperation Target)
  {
    Target = new marbleOperation(Source);
  }

  public override string ToString()
  {
    return $"CutLength : {this.CutLength.ToString()} , MaterialThickness : {this.MaterialThickness.ToString()}";
  }
}
