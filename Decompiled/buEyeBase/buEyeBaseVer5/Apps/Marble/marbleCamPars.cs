using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCamPars : buSerilization5
{
	public double SawSafeDistance = 60.0;

	public double SawRapidDistance = 25.0;

	public double SawPlungeVelocity = 50.0;

	public double SawLeaveVelocity = 50.0;

	public double SawPlungeFirstVelocity = 30.0;

	public double SawForwardFirstCuttingVelocity = 15.0;

	public double SawForwardCuttingVelocity = 20.0;

	public double SawForwardCircularCuttingVelocity = 10.0;

	public double SawForwardCircularFirstCuttingVelocity = 10.0;

	public double SawBackwardCuttingVelocity = 5.0;

	public double SawBackwardCircularCuttingVelocity = 10.0;

	public double SawForwardStepFirstDownDistance = 0.0;

	public double SawForwardStepDownDistance = 30.0;

	public double SawForwardCircularStepFirstDownDistance = 0.0;

	public double SawForwardCircularStepDownDistance = 5.0;

	public double SawBackwardStepDownDistance = 2.0;

	public double MillingSafeDistance = 60.0;

	public double MillingRapidDistance = 25.0;

	public double MillingPlungeVelocity = 20.0;

	public double MillingPlungeFirstVelocity = 10.0;

	public double MillingCuttingVelocity = 20.0;

	public double MillingFirstCuttingVelocity = 15.0;

	public double MillingDrillVelocity = 20.0;

	public double MillingDrillLeaveVelocity = 50.0;

	public double MillingFirstStepDown = 1.0;

	public double MillingStepDown = 3.0;

	public double MillingStepOverPersentage = 90.0;

	public double MillingHeadPlungeVelocity = 20.0;

	public double MillingHeadPlungeFirstVelocity = 10.0;

	public double MillingHeadSafeDistance = 50.0;

	public double MillingHeadRapidDistance = 20.0;

	public double MillingHeadCuttingVelocity = 20.0;

	public double MillingHeadFirstCuttingVelocity = 15.0;

	public double MillingHeadDrillVelocity = 20.0;

	public double MillingHeadDrillLeaveVelocity = 20.0;

	public double MillingHeadFirstStepDown = 1.0;

	public double MillingHeadStepDown = 3.0;

	public double MillingHeadStepOverPersentage = 90.0;

	public double WaterjetSafeDistance = 60.0;

	public double WaterjetRapidDistance = 25.0;

	public double TargetZ = 0.0;

	public double TargetZDrill = 1.0;

	public double QuickVelocity = 100.0;

	public double JobFinishZPostion = 100.0;

	public bool MoveZCAAxesToSafeDistance = true;

	public bool UseCZero = false;

	public bool UseConstantCAngle = false;

	public bool AlwaysSafeDistance = false;

	public bool isFirstCutSafeDistance = false;

	public bool NoAngleCAxisCheck = false;

	public bool UseTangentLimit = true;

	public double ConstantAngleC = 0.0;

	public double OffsetAngleC = 0.0;

	public double AngleCLimit = 20.0;

	public double AngleCMin = -380.0;

	public double AngleCMax = 380.0;

	public double MaxAllowedAngleA = 50.0;

	public bool DontCheckZValues = false;

	public bool VerticalBackToFront = false;

	public bool HorizontalLeftToRight = false;

	public bool UseSawCuttings = true;

	public bool UseCornerByMilling = true;

	public bool UseCornerByDrill = true;

	public bool UseMillingCuttings = true;

	public bool UseDrillCut = true;

	public bool ToolPathPointDistributionMode = false;

	public bool CutSameDirection = false;

	public double CutTolerance = 0.05;

	public bool UseG38G39 = true;

	public bool AutoWaterOpenClose = false;

	public bool AutoWaterWhenCRotating = false;

	public bool OutsideArcCuttingByMilling = false;

	public double OutsideArcCuttingMinDiameterBySaw = 400.0;

	public bool LastStepAtSameTime = true;

	public bool isCircularFirst = true;

	public bool isInsideFirst = true;

	public bool isA45First = true;

	public bool InsideCutSizeFromTop = true;

	public bool CommonPathCalculation = false;

	public double CommonPathGapDistance = 2.0;

	public double OutsideContourLeadIn = 0.0;

	public double OutsideContourLeadOut = 0.0;

	public bool OutsideContourLeadInOutForArc = false;

	public double CutSawDistanceOverlap = 0.0;

	public double InnerCutSafeDistance = 0.0;

	public double ConcaveCornerExtraOffset = 0.0;

	public double ConvexCornerExtraOffset = 0.0;

	public double OutterCutSafeDistance = 0.0;

	public double Inside45DegreeExtraOffset = 0.0;

	public double Inside0DegreeExtraOffset = 0.0;

	public bool DontMoveSafeForForwardBackwardDirection = false;

	public double RegenDeviation = 0.1;

	public MarbleConcaveArcOffsetCalculationType ConcaveArcOffsetType = MarbleConcaveArcOffsetCalculationType.NoCalculation;

	public MarbleConcaveCuttingType ConcaveCuttingType = MarbleConcaveCuttingType.None;

	public MarbleConcaveCuttingType ConvexCuttingType = MarbleConcaveCuttingType.None;

	public MarbleConcaveDrillType ConcaveDrillType = MarbleConcaveDrillType.OneDrill;

	public CamCuttingDirectionType CuttingDirection = CamCuttingDirectionType.Forward;

	public ClockDirectionType ContourDirection = ClockDirectionType.CCW;

	public ClockDirectionType ContourInsideDirection = ClockDirectionType.CCW;

	public ClockDirectionType ConcaveDirection = ClockDirectionType.CW;

	public ClockDirectionType ConvexDirection = ClockDirectionType.CW;

	public MarbleContourCutSequence CutSequence = MarbleContourCutSequence.MillingChamferCutting;

	public MarbleMillingToolType DefaultMillingTool = MarbleMillingToolType.Milling;

	public MarbleMillingToolType DefaultDrillTool = MarbleMillingToolType.Milling;

	public MarbleCornerCleanToolType DefaultCornerCleanTool = MarbleCornerCleanToolType.Milling;

	public MarbleMaterialHardness MaterialHardness = MarbleMaterialHardness.Medium;

	public MarbleStepType StepType = MarbleStepType.Level;

	public bool isBuWireframeCalculation = true;

	public double MaterialMonsHardness = 4.0;

	public double MaterialDensity = 2.71;

	public double MaterialUnitVolumeWeight = 2.69;

	public double MaterialPorosity = 1.0;

	public string MaterialName = "Material";

	public bool Contour3DCreate = true;

	public bool UseG53 = false;

	public List<marbleStepAnsFeedForCircular> StepCircularLimits = new List<marbleStepAnsFeedForCircular>();

	public static List<string> Captions = new List<string>();

	public marbleCamPars()
	{
	}

	public marbleCamPars(marbleCamPars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
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
		StepCircularLimits.Clear();
		for (int j = 0; j <= data.StepCircularLimits.Count - 1; j++)
		{
			StepCircularLimits.Add(data.StepCircularLimits[j]);
		}
	}

	public static void Copy(marbleCamPars Source, ref marbleCamPars Target)
	{
		Target = new marbleCamPars(Source);
	}

	public override string ToString()
	{
		return "TargetZ : " + TargetZ + " , ForwardCuttingVelocity : " + SawForwardCuttingVelocity + " , SafeDistance : " + SawSafeDistance + " , PlungeVelocity : " + SawPlungeVelocity;
	}
}
