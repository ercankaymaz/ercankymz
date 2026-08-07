// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.LeadIn5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class LeadIn5 : buSerilization5
{
  public double AngleRangeSlopeAngleEnd;
  public CamMachiningAreaType AngleRangeMachiningAreaType;
  public double CylinderRadiusAroundLine;
  public double SideShift;
  public double ProjectionLineX;
  public double ProjectionLineY;
  public double ProjectionLineZ;
  public double ProjectionStartHeight;
  public double ProjectionEndHeight;

  public LeadIn5(camHatch5 Data)
  {
    ((camStrategy5) this).CutStep = 5.0;
    ((camStrategy5) this).XDirectionLength = 1000.0;
    ((camStrategy5) this).YDirectionWidth = 500.0;
    ((camStrategy5) this).CornerPoint = new Pnt3D();
    ((camStrategy5) this).CuttingDirection = CamHatchCuttingDirection.XDirection;
    ((camStrategy5) this).CuttingModes = CamHatchCuttingMode.ForwardNextBackward;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"XDirectionLength: {((camStrategy5) this).XDirectionLength.ToString()} , CutStep: {((camStrategy5) this).CutStep.ToString()} , YDirectionWidth: {((camStrategy5) this).YDirectionWidth.ToString()}";
  }

  static LeadIn5() => camStrategy5.Captions = new List<string>();

  public LeadIn5()
  {
    ((camStrategy5) this).UseTangentLimit = true;
    ((camStrategy5) this).UseLimitAngleForOtherPlane = false;
    ((camStrategy5) this).TangentFirstAngleGreaterThen180StartMinusAngle = false;
    ((camStrategy5) this).AngleLimitXY = 30.0;
    ((camStrategy5) this).AngleLimitXZ = 30.0;
    ((camStrategy5) this).AngleLimitYZ = 30.0;
    ((camStrategy5) this).AngleLimit = 30.0;
    ((camStrategy5) this).ParallelCutAngleXY = 0.0;
    ((camStrategy5) this).ParallelMachAngleFromZ = 0.0;
    ((camStrategy5) this).MinTangentValue = -360.0;
    ((camStrategy5) this).MaxTangentValue = 360.0;
    ((camStrategy5) this).TangentOffset = 0.0;
    ((camStrategy5) this).ContantTangent = 0.0;
    ((camStrategy5) this).OverrideC = 0.0;
    ((camStrategy5) this).SpinCStartAngle = 0.0;
    ((camStrategy5) this).SpinCEndAngle = 1080.0;
    ((camStrategy5) this).SpinSpeed = 500.0;
    ((camStrategy5) this).CutTolerance = 0.1;
    ((camStrategy5) this).UseContantTangent = false;
    ((camStrategy5) this).OverrideCEnable = false;
    ((camStrategy5) this).ArcToPoints = false;
    ((camStrategy5) this).StartFromAnyPoint = false;
    ((camStrategy5) this).OpenContourTwoDirectionCut = true;
    ((camStrategy5) this).RemoveCornerPeg = false;
    ((camStrategy5) this).RoughLeadOut = false;
    ((camStrategy5) this).MinimizeLink = false;
    ((camStrategy5) this).ReverseCuttingOrder = false;
    ((camStrategy5) this).ReverseCut = false;
    ((camStrategy5) this).MaintainCuttingDirection = false;
    ((camStrategy5) this).ClosedOffset = false;
    ((camStrategy5) this).EdgeRolling = true;
    ((camStrategy5) this).MachiningDirectionAsReferenceForDirectionOfCutsFlg = false;
    ((camStrategy5) this).VerticalWallMachine = false;
    ((camStrategy5) this).VerticalWallExclude = false;
    ((camStrategy5) this).OutputPatternFlag = false;
    ((camStrategy5) this).SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctPartSilhouette;
    ((camStrategy5) this).SilhouetteStockRemain = 0.0;
    ((camStrategy5) this).SilhouetteEnable = false;
    ((camStrategy5) this).UseRamp = false;
    ((camStrategy5) this).UseRampAreaLinks = false;
    ((camStrategy5) this).UseRampBetweenSlices = false;
    ((camStrategy5) this).UseRampBetweenRegion = false;
    ((camStrategy5) this).RampMaxDiameterFromToolPerc = 80.0;
    ((camStrategy5) this).RampMinDiameterFromToolPerc = 50.0;
    ((camStrategy5) this).RampModeTriangleMesh = CamRampModeTriangleMeshType.TmbRmAngle;
    ((camStrategy5) this).RampTypeTriangleMesh = CamRampTypeTriangleMeshType.TmbRtHelical;
    ((camStrategy5) this).RampAngle = 5.0;
    ((camStrategy5) this).RampPitch = 1.0;
    ((camStrategy5) this).RampMinDiameterToolDiameterEnable = false;
    ((camStrategy5) this).ParallelCutDireiton = CamParallelCutDirection.XDirection;
    ((camStrategy5) this).ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScLowerLeft;
    ((camStrategy5) this).ConstantZStart = CamConstantZStart.ShbZsTop;
    ((camStrategy5) this).RotaryAxis = VectorType.ZVector;
    ((camStrategy5) this).CuttingMethod = CamCuttingMethod.MachtypeZigzag;
    ((camStrategy5) this).GroupMethod = CamGroupMethod.MachByRegions;
    ((camStrategy5) this).ClosedCutDirection = CamMachiningParamsDirection.DirClimb;
    ((camStrategy5) this).MachiningAreaMode = CamMachiningAreaMode.MachByLanes;
    ((camStrategy5) this).GeodesicType = CamGeodesicType.TmbGeodesicOffset;
    ((camStrategy5) this).GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditMachining;
    ((camStrategy5) this).GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdAuto;
    ((camStrategy5) this).GeodesicStepoverType = CamGeodesicStepover.TmbGsMaximum;
    ((camStrategy5) this).FlatToleranceFactor = 1.0;
    ((camStrategy5) this).MinWidth = 1.0;
    ((camStrategy5) this).MaxWidthFlg = false;
    ((camStrategy5) this).MaxWidth = 100.0;
    ((camStrategy5) this).ChainingDistanceInPercOfToolDiameter = 10.0;
    ((camStrategy5) this).SingleCut = false;
    ((camStrategy5) this).MachiningAreaType = CamMachiningAreasType.MatNarrow;
    ((camStrategy5) this).CornerDetectionThresholdFlg = false;
    ((camStrategy5) this).OverThicknessFlg = false;
    ((camStrategy5) this).CornerDetectionThreshold = 45.0;
    ((camStrategy5) this).OverThickness = 0.0;
    ((camStrategy5) this).MultiPencil = false;
    ((camStrategy5) this).NumberOfCuts = 2;
    ((camStrategy5) this).StepDirection = CamOffsetDirection.PcpOdBoth;
    ((camStrategy5) this).LeftDirNumberOfCutsFlg = false;
    ((camStrategy5) this).LeftDirNumberOfCuts = 0;
    ((camStrategy5) this).RightDirNumberOfCutsFlg = false;
    ((camStrategy5) this).RightDirNumberOfCuts = 0;
    ((camStrategy5) this).SteepStepoverFlg = false;
    ((camStrategy5) this).SteepStepover = 1.0;
    ((camStrategy5) this).CornerRefinementFlg = false;
    ((camStrategy5) this).CutOrder = CamCutOrder.OrderStandard;
    ((camNotch5) this).RadiuFitFlag = false;
    ((camNotch5) this).SplineMaxDeviation = 0.0;
    ((camNotch5) this).AngleRangeEnable = false;
    ((camNotch5) this).AngleRangeSlopeAngleStart = 0.0;
    this.AngleRangeSlopeAngleEnd = 10.0;
    this.AngleRangeMachiningAreaType = CamMachiningAreaType.MatSteepAreas;
    this.CylinderRadiusAroundLine = 10.0;
    this.SideShift = 0.0;
    this.ProjectionLineX = 0.0;
    this.ProjectionLineY = 0.0;
    this.ProjectionLineZ = 0.0;
    this.ProjectionStartHeight = 0.0;
    this.ProjectionEndHeight = 10.0;
    ((LeadOut5) this).ProjectionStartAngles = 0.0;
    ((LeadOut5) this).ProjectionEndAngles = 0.0;
    ((LeadOut5) this).ProjectionDirection = CamProjectionDirection.TcTmbPdOutwards;
    ((LeadOut5) this).MultiPass = false;
    ((LeadOut5) this).MultiPassNumberOfRoughCuts = 0;
    ((LeadOut5) this).MultiPassRoughPassSpacing = 0.0;
    ((LeadOut5) this).MultiPassNumberOFinishCuts = 0;
    ((LeadOut5) this).MultiPassFinishPassSpacing = 0.0;
    ((LeadOut5) this).MultiPassSortType = CamRoughSortType.McSortByPasses;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public LeadIn5(double anglelimit)
  {
    ((camStrategy5) this).UseTangentLimit = true;
    ((camStrategy5) this).UseLimitAngleForOtherPlane = false;
    ((camStrategy5) this).TangentFirstAngleGreaterThen180StartMinusAngle = false;
    ((camStrategy5) this).AngleLimitXY = 30.0;
    ((camStrategy5) this).AngleLimitXZ = 30.0;
    ((camStrategy5) this).AngleLimitYZ = 30.0;
    ((camStrategy5) this).AngleLimit = 30.0;
    ((camStrategy5) this).ParallelCutAngleXY = 0.0;
    ((camStrategy5) this).ParallelMachAngleFromZ = 0.0;
    ((camStrategy5) this).MinTangentValue = -360.0;
    ((camStrategy5) this).MaxTangentValue = 360.0;
    ((camStrategy5) this).TangentOffset = 0.0;
    ((camStrategy5) this).ContantTangent = 0.0;
    ((camStrategy5) this).OverrideC = 0.0;
    ((camStrategy5) this).SpinCStartAngle = 0.0;
    ((camStrategy5) this).SpinCEndAngle = 1080.0;
    ((camStrategy5) this).SpinSpeed = 500.0;
    ((camStrategy5) this).CutTolerance = 0.1;
    ((camStrategy5) this).UseContantTangent = false;
    ((camStrategy5) this).OverrideCEnable = false;
    ((camStrategy5) this).ArcToPoints = false;
    ((camStrategy5) this).StartFromAnyPoint = false;
    ((camStrategy5) this).OpenContourTwoDirectionCut = true;
    ((camStrategy5) this).RemoveCornerPeg = false;
    ((camStrategy5) this).RoughLeadOut = false;
    ((camStrategy5) this).MinimizeLink = false;
    ((camStrategy5) this).ReverseCuttingOrder = false;
    ((camStrategy5) this).ReverseCut = false;
    ((camStrategy5) this).MaintainCuttingDirection = false;
    ((camStrategy5) this).ClosedOffset = false;
    ((camStrategy5) this).EdgeRolling = true;
    ((camStrategy5) this).MachiningDirectionAsReferenceForDirectionOfCutsFlg = false;
    ((camStrategy5) this).VerticalWallMachine = false;
    ((camStrategy5) this).VerticalWallExclude = false;
    ((camStrategy5) this).OutputPatternFlag = false;
    ((camStrategy5) this).SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctPartSilhouette;
    ((camStrategy5) this).SilhouetteStockRemain = 0.0;
    ((camStrategy5) this).SilhouetteEnable = false;
    ((camStrategy5) this).UseRamp = false;
    ((camStrategy5) this).UseRampAreaLinks = false;
    ((camStrategy5) this).UseRampBetweenSlices = false;
    ((camStrategy5) this).UseRampBetweenRegion = false;
    ((camStrategy5) this).RampMaxDiameterFromToolPerc = 80.0;
    ((camStrategy5) this).RampMinDiameterFromToolPerc = 50.0;
    ((camStrategy5) this).RampModeTriangleMesh = CamRampModeTriangleMeshType.TmbRmAngle;
    ((camStrategy5) this).RampTypeTriangleMesh = CamRampTypeTriangleMeshType.TmbRtHelical;
    ((camStrategy5) this).RampAngle = 5.0;
    ((camStrategy5) this).RampPitch = 1.0;
    ((camStrategy5) this).RampMinDiameterToolDiameterEnable = false;
    ((camStrategy5) this).ParallelCutDireiton = CamParallelCutDirection.XDirection;
    ((camStrategy5) this).ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScLowerLeft;
    ((camStrategy5) this).ConstantZStart = CamConstantZStart.ShbZsTop;
    ((camStrategy5) this).RotaryAxis = VectorType.ZVector;
    ((camStrategy5) this).CuttingMethod = CamCuttingMethod.MachtypeZigzag;
    ((camStrategy5) this).GroupMethod = CamGroupMethod.MachByRegions;
    ((camStrategy5) this).ClosedCutDirection = CamMachiningParamsDirection.DirClimb;
    ((camStrategy5) this).MachiningAreaMode = CamMachiningAreaMode.MachByLanes;
    ((camStrategy5) this).GeodesicType = CamGeodesicType.TmbGeodesicOffset;
    ((camStrategy5) this).GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditMachining;
    ((camStrategy5) this).GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdAuto;
    ((camStrategy5) this).GeodesicStepoverType = CamGeodesicStepover.TmbGsMaximum;
    ((camStrategy5) this).FlatToleranceFactor = 1.0;
    ((camStrategy5) this).MinWidth = 1.0;
    ((camStrategy5) this).MaxWidthFlg = false;
    ((camStrategy5) this).MaxWidth = 100.0;
    ((camStrategy5) this).ChainingDistanceInPercOfToolDiameter = 10.0;
    ((camStrategy5) this).SingleCut = false;
    ((camStrategy5) this).MachiningAreaType = CamMachiningAreasType.MatNarrow;
    ((camStrategy5) this).CornerDetectionThresholdFlg = false;
    ((camStrategy5) this).OverThicknessFlg = false;
    ((camStrategy5) this).CornerDetectionThreshold = 45.0;
    ((camStrategy5) this).OverThickness = 0.0;
    ((camStrategy5) this).MultiPencil = false;
    ((camStrategy5) this).NumberOfCuts = 2;
    ((camStrategy5) this).StepDirection = CamOffsetDirection.PcpOdBoth;
    ((camStrategy5) this).LeftDirNumberOfCutsFlg = false;
    ((camStrategy5) this).LeftDirNumberOfCuts = 0;
    ((camStrategy5) this).RightDirNumberOfCutsFlg = false;
    ((camStrategy5) this).RightDirNumberOfCuts = 0;
    ((camStrategy5) this).SteepStepoverFlg = false;
    ((camStrategy5) this).SteepStepover = 1.0;
    ((camStrategy5) this).CornerRefinementFlg = false;
    ((camStrategy5) this).CutOrder = CamCutOrder.OrderStandard;
    ((camNotch5) this).RadiuFitFlag = false;
    ((camNotch5) this).SplineMaxDeviation = 0.0;
    ((camNotch5) this).AngleRangeEnable = false;
    ((camNotch5) this).AngleRangeSlopeAngleStart = 0.0;
    this.AngleRangeSlopeAngleEnd = 10.0;
    this.AngleRangeMachiningAreaType = CamMachiningAreaType.MatSteepAreas;
    this.CylinderRadiusAroundLine = 10.0;
    this.SideShift = 0.0;
    this.ProjectionLineX = 0.0;
    this.ProjectionLineY = 0.0;
    this.ProjectionLineZ = 0.0;
    this.ProjectionStartHeight = 0.0;
    this.ProjectionEndHeight = 10.0;
    ((LeadOut5) this).ProjectionStartAngles = 0.0;
    ((LeadOut5) this).ProjectionEndAngles = 0.0;
    ((LeadOut5) this).ProjectionDirection = CamProjectionDirection.TcTmbPdOutwards;
    ((LeadOut5) this).MultiPass = false;
    ((LeadOut5) this).MultiPassNumberOfRoughCuts = 0;
    ((LeadOut5) this).MultiPassRoughPassSpacing = 0.0;
    ((LeadOut5) this).MultiPassNumberOFinishCuts = 0;
    ((LeadOut5) this).MultiPassFinishPassSpacing = 0.0;
    ((LeadOut5) this).MultiPassSortType = CamRoughSortType.McSortByPasses;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((camStrategy5) this).AngleLimit = anglelimit;
  }

  public LeadIn5(camStrategy5 Data)
  {
    ((camStrategy5) this).UseTangentLimit = true;
    ((camStrategy5) this).UseLimitAngleForOtherPlane = false;
    ((camStrategy5) this).TangentFirstAngleGreaterThen180StartMinusAngle = false;
    ((camStrategy5) this).AngleLimitXY = 30.0;
    ((camStrategy5) this).AngleLimitXZ = 30.0;
    ((camStrategy5) this).AngleLimitYZ = 30.0;
    ((camStrategy5) this).AngleLimit = 30.0;
    ((camStrategy5) this).ParallelCutAngleXY = 0.0;
    ((camStrategy5) this).ParallelMachAngleFromZ = 0.0;
    ((camStrategy5) this).MinTangentValue = -360.0;
    ((camStrategy5) this).MaxTangentValue = 360.0;
    ((camStrategy5) this).TangentOffset = 0.0;
    ((camStrategy5) this).ContantTangent = 0.0;
    ((camStrategy5) this).OverrideC = 0.0;
    ((camStrategy5) this).SpinCStartAngle = 0.0;
    ((camStrategy5) this).SpinCEndAngle = 1080.0;
    ((camStrategy5) this).SpinSpeed = 500.0;
    ((camStrategy5) this).CutTolerance = 0.1;
    ((camStrategy5) this).UseContantTangent = false;
    ((camStrategy5) this).OverrideCEnable = false;
    ((camStrategy5) this).ArcToPoints = false;
    ((camStrategy5) this).StartFromAnyPoint = false;
    ((camStrategy5) this).OpenContourTwoDirectionCut = true;
    ((camStrategy5) this).RemoveCornerPeg = false;
    ((camStrategy5) this).RoughLeadOut = false;
    ((camStrategy5) this).MinimizeLink = false;
    ((camStrategy5) this).ReverseCuttingOrder = false;
    ((camStrategy5) this).ReverseCut = false;
    ((camStrategy5) this).MaintainCuttingDirection = false;
    ((camStrategy5) this).ClosedOffset = false;
    ((camStrategy5) this).EdgeRolling = true;
    ((camStrategy5) this).MachiningDirectionAsReferenceForDirectionOfCutsFlg = false;
    ((camStrategy5) this).VerticalWallMachine = false;
    ((camStrategy5) this).VerticalWallExclude = false;
    ((camStrategy5) this).OutputPatternFlag = false;
    ((camStrategy5) this).SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctPartSilhouette;
    ((camStrategy5) this).SilhouetteStockRemain = 0.0;
    ((camStrategy5) this).SilhouetteEnable = false;
    ((camStrategy5) this).UseRamp = false;
    ((camStrategy5) this).UseRampAreaLinks = false;
    ((camStrategy5) this).UseRampBetweenSlices = false;
    ((camStrategy5) this).UseRampBetweenRegion = false;
    ((camStrategy5) this).RampMaxDiameterFromToolPerc = 80.0;
    ((camStrategy5) this).RampMinDiameterFromToolPerc = 50.0;
    ((camStrategy5) this).RampModeTriangleMesh = CamRampModeTriangleMeshType.TmbRmAngle;
    ((camStrategy5) this).RampTypeTriangleMesh = CamRampTypeTriangleMeshType.TmbRtHelical;
    ((camStrategy5) this).RampAngle = 5.0;
    ((camStrategy5) this).RampPitch = 1.0;
    ((camStrategy5) this).RampMinDiameterToolDiameterEnable = false;
    ((camStrategy5) this).ParallelCutDireiton = CamParallelCutDirection.XDirection;
    ((camStrategy5) this).ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScLowerLeft;
    ((camStrategy5) this).ConstantZStart = CamConstantZStart.ShbZsTop;
    ((camStrategy5) this).RotaryAxis = VectorType.ZVector;
    ((camStrategy5) this).CuttingMethod = CamCuttingMethod.MachtypeZigzag;
    ((camStrategy5) this).GroupMethod = CamGroupMethod.MachByRegions;
    ((camStrategy5) this).ClosedCutDirection = CamMachiningParamsDirection.DirClimb;
    ((camStrategy5) this).MachiningAreaMode = CamMachiningAreaMode.MachByLanes;
    ((camStrategy5) this).GeodesicType = CamGeodesicType.TmbGeodesicOffset;
    ((camStrategy5) this).GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditMachining;
    ((camStrategy5) this).GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdAuto;
    ((camStrategy5) this).GeodesicStepoverType = CamGeodesicStepover.TmbGsMaximum;
    ((camStrategy5) this).FlatToleranceFactor = 1.0;
    ((camStrategy5) this).MinWidth = 1.0;
    ((camStrategy5) this).MaxWidthFlg = false;
    ((camStrategy5) this).MaxWidth = 100.0;
    ((camStrategy5) this).ChainingDistanceInPercOfToolDiameter = 10.0;
    ((camStrategy5) this).SingleCut = false;
    ((camStrategy5) this).MachiningAreaType = CamMachiningAreasType.MatNarrow;
    ((camStrategy5) this).CornerDetectionThresholdFlg = false;
    ((camStrategy5) this).OverThicknessFlg = false;
    ((camStrategy5) this).CornerDetectionThreshold = 45.0;
    ((camStrategy5) this).OverThickness = 0.0;
    ((camStrategy5) this).MultiPencil = false;
    ((camStrategy5) this).NumberOfCuts = 2;
    ((camStrategy5) this).StepDirection = CamOffsetDirection.PcpOdBoth;
    ((camStrategy5) this).LeftDirNumberOfCutsFlg = false;
    ((camStrategy5) this).LeftDirNumberOfCuts = 0;
    ((camStrategy5) this).RightDirNumberOfCutsFlg = false;
    ((camStrategy5) this).RightDirNumberOfCuts = 0;
    ((camStrategy5) this).SteepStepoverFlg = false;
    ((camStrategy5) this).SteepStepover = 1.0;
    ((camStrategy5) this).CornerRefinementFlg = false;
    ((camStrategy5) this).CutOrder = CamCutOrder.OrderStandard;
    ((camNotch5) this).RadiuFitFlag = false;
    ((camNotch5) this).SplineMaxDeviation = 0.0;
    ((camNotch5) this).AngleRangeEnable = false;
    ((camNotch5) this).AngleRangeSlopeAngleStart = 0.0;
    this.AngleRangeSlopeAngleEnd = 10.0;
    this.AngleRangeMachiningAreaType = CamMachiningAreaType.MatSteepAreas;
    this.CylinderRadiusAroundLine = 10.0;
    this.SideShift = 0.0;
    this.ProjectionLineX = 0.0;
    this.ProjectionLineY = 0.0;
    this.ProjectionLineZ = 0.0;
    this.ProjectionStartHeight = 0.0;
    this.ProjectionEndHeight = 10.0;
    ((LeadOut5) this).ProjectionStartAngles = 0.0;
    ((LeadOut5) this).ProjectionEndAngles = 0.0;
    ((LeadOut5) this).ProjectionDirection = CamProjectionDirection.TcTmbPdOutwards;
    ((LeadOut5) this).MultiPass = false;
    ((LeadOut5) this).MultiPassNumberOfRoughCuts = 0;
    ((LeadOut5) this).MultiPassRoughPassSpacing = 0.0;
    ((LeadOut5) this).MultiPassNumberOFinishCuts = 0;
    ((LeadOut5) this).MultiPassFinishPassSpacing = 0.0;
    ((LeadOut5) this).MultiPassSortType = CamRoughSortType.McSortByPasses;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }
}
