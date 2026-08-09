using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5;

[Serializable]
public class camStrategy5 : buSerilization5
{
	public bool UseTangentLimit = true;

	public bool UseLimitAngleForOtherPlane = false;

	public bool TangentFirstAngleGreaterThen180StartMinusAngle = false;

	public double AngleLimitXY = 30.0;

	public double AngleLimitXZ = 30.0;

	public double AngleLimitYZ = 30.0;

	public double AngleLimit = 30.0;

	public double ParallelCutAngleXY = 0.0;

	public double ParallelMachAngleFromZ = 0.0;

	public double MinTangentValue = -360.0;

	public double MaxTangentValue = 360.0;

	public double TangentOffset = 0.0;

	public double ContantTangent = 0.0;

	public double OverrideC = 0.0;

	public double SpinCStartAngle = 0.0;

	public double SpinCEndAngle = 1080.0;

	public double SpinSpeed = 500.0;

	public double CutTolerance = 0.1;

	public bool UseContantTangent = false;

	public bool OverrideCEnable = false;

	public bool ArcToPoints = false;

	public bool StartFromAnyPoint = false;

	public bool OpenContourTwoDirectionCut = true;

	public bool RemoveCornerPeg = false;

	public bool RoughLeadOut = false;

	public bool MinimizeLink = false;

	public bool ReverseCuttingOrder = false;

	public bool ReverseCut = false;

	public bool MaintainCuttingDirection = false;

	public bool ClosedOffset = false;

	public bool EdgeRolling = true;

	public bool MachiningDirectionAsReferenceForDirectionOfCutsFlg = false;

	public bool VerticalWallMachine = false;

	public bool VerticalWallExclude = false;

	public bool OutputPatternFlag = false;

	public CamSilhouetteContainmentTriangleMeshType SilhouetteTriangleMeshType = CamSilhouetteContainmentTriangleMeshType.ScctPartSilhouette;

	public double SilhouetteStockRemain = 0.0;

	public bool SilhouetteEnable = false;

	public bool UseRamp = false;

	public bool UseRampAreaLinks = false;

	public bool UseRampBetweenSlices = false;

	public bool UseRampBetweenRegion = false;

	public double RampMaxDiameterFromToolPerc = 80.0;

	public double RampMinDiameterFromToolPerc = 50.0;

	public CamRampModeTriangleMeshType RampModeTriangleMesh = CamRampModeTriangleMeshType.TmbRmAngle;

	public CamRampTypeTriangleMeshType RampTypeTriangleMesh = CamRampTypeTriangleMeshType.TmbRtHelical;

	public double RampAngle = 5.0;

	public double RampPitch = 1.0;

	public bool RampMinDiameterToolDiameterEnable = false;

	public CamParallelCutDirection ParallelCutDireiton = CamParallelCutDirection.XDirection;

	public CamParallelCutsStartCorner ParallelCutStartCorner = CamParallelCutsStartCorner.TmbScLowerLeft;

	public CamConstantZStart ConstantZStart = CamConstantZStart.ShbZsTop;

	public VectorType RotaryAxis = VectorType.ZVector;

	public CamCuttingMethod CuttingMethod = CamCuttingMethod.MachtypeZigzag;

	public CamGroupMethod GroupMethod = CamGroupMethod.MachByRegions;

	public CamMachiningParamsDirection ClosedCutDirection = CamMachiningParamsDirection.DirClimb;

	public CamMachiningAreaMode MachiningAreaMode = CamMachiningAreaMode.MachByLanes;

	public CamGeodesicType GeodesicType = CamGeodesicType.TmbGeodesicOffset;

	public CamGeodesicDriveInputType GeodesicDriveInputType = CamGeodesicDriveInputType.TmbGditMachining;

	public CamGeodesicContainmentType GeodesicContainmetType = CamGeodesicContainmentType.TmbGdpdAuto;

	public CamGeodesicStepover GeodesicStepoverType = CamGeodesicStepover.TmbGsMaximum;

	public double FlatToleranceFactor = 1.0;

	public double MinWidth = 1.0;

	public bool MaxWidthFlg = false;

	public double MaxWidth = 100.0;

	public double ChainingDistanceInPercOfToolDiameter = 10.0;

	public bool SingleCut = false;

	public CamMachiningAreasType MachiningAreaType = CamMachiningAreasType.MatNarrow;

	public bool CornerDetectionThresholdFlg = false;

	public bool OverThicknessFlg = false;

	public double CornerDetectionThreshold = 45.0;

	public double OverThickness = 0.0;

	public bool MultiPencil = false;

	public int NumberOfCuts = 2;

	public CamOffsetDirection StepDirection = CamOffsetDirection.PcpOdBoth;

	public bool LeftDirNumberOfCutsFlg = false;

	public int LeftDirNumberOfCuts = 0;

	public bool RightDirNumberOfCutsFlg = false;

	public int RightDirNumberOfCuts = 0;

	public bool SteepStepoverFlg = false;

	public double SteepStepover = 1.0;

	public bool CornerRefinementFlg = false;

	public CamCutOrder CutOrder = CamCutOrder.OrderStandard;

	public bool RadiuFitFlag = false;

	public double SplineMaxDeviation = 0.0;

	public bool AngleRangeEnable = false;

	public double AngleRangeSlopeAngleStart = 0.0;

	public double AngleRangeSlopeAngleEnd = 10.0;

	public CamMachiningAreaType AngleRangeMachiningAreaType = CamMachiningAreaType.MatSteepAreas;

	public double CylinderRadiusAroundLine = 10.0;

	public double SideShift = 0.0;

	public double ProjectionLineX = 0.0;

	public double ProjectionLineY = 0.0;

	public double ProjectionLineZ = 0.0;

	public double ProjectionStartHeight = 0.0;

	public double ProjectionEndHeight = 10.0;

	public double ProjectionStartAngles = 0.0;

	public double ProjectionEndAngles = 0.0;

	public CamProjectionDirection ProjectionDirection = CamProjectionDirection.TcTmbPdOutwards;

	public bool MultiPass = false;

	public int MultiPassNumberOfRoughCuts = 0;

	public double MultiPassRoughPassSpacing = 0.0;

	public int MultiPassNumberOFinishCuts = 0;

	public double MultiPassFinishPassSpacing = 0.0;

	public CamRoughSortType MultiPassSortType = CamRoughSortType.McSortByPasses;

	public static List<string> Captions = new List<string>();

	public camStrategy5()
	{
	}

	public camStrategy5(double anglelimit)
	{
		AngleLimit = anglelimit;
	}

	public camStrategy5(camStrategy5 Data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(Data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}

	public override string ToString()
	{
		return "AngleLimit: " + AngleLimit;
	}
}
