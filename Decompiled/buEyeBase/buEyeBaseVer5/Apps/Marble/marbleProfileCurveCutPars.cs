using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleProfileCurveCutPars : buSerilization5
{
	public double Radius = 100.0;

	public double StartAngle = 0.0;

	public double SweepAngle = 90.0;

	public double BaseHeight = 50.0;

	public double RoughPlungeFeed = 20.0;

	public double RoughCutForwardFeed = 50.0;

	public double RoughCutBackwardFeed = 50.0;

	public double RoughSafeDis = 50.0;

	public double RoughRapid = 5.0;

	public double RoughAngleStep = 5.0;

	public double RoughSurfOffset = 0.0;

	public double RoughVerticalDevideLen = 10.0;

	public double RoughMinZ = 0.0;

	public double RoughCOffsetAngle = 0.0;

	public double RoughLeadInAngle = 1.0;

	public double RoughLeadOutAngle = 1.0;

	public double RoughStep = 10.0;

	public double RoughTopOffset = 0.0;

	public double RoughBottomOffset = 0.0;

	public double RoughInsideOffset = 0.0;

	public double RoughOutsideOffset = 0.0;

	public double RoughZForwardDownStep = 10.0;

	public double RoughStepover = 3.0;

	public bool RoughEnable = true;

	public bool RoughZigzagMode = false;

	public bool RoughPerpendicularA = false;

	public bool RoughReverseCAngle = false;

	public bool RoughMoveUpSafeDistance = true;

	public MarbleCamAreaMode RoughAreaMode = MarbleCamAreaMode.Level;

	public double FinishPlungeFeed = 20.0;

	public double FinishCutForwardFeed = 50.0;

	public double FinishCutBackwardFeed = 50.0;

	public double FinishSafeDis = 50.0;

	public double FinishRapid = 5.0;

	public double FinishSurfOffset = 0.0;

	public double FinishAngleStep = 2.0;

	public double FinishDevideLen = 1.0;

	public double FinishVerticalDevideLen = 10.0;

	public double FinishMinZ = 0.0;

	public double FinishCOffsetAngle = 0.0;

	public double FinishLeadInAngle = 1.0;

	public double FinishLeadOutAngle = 1.0;

	public double FinishTopOffset = 0.0;

	public double FinishBottomOffset = 0.0;

	public double FinishInsideOffset = 0.0;

	public double FinishOutsideOffset = 0.0;

	public bool FinishEnable = true;

	public bool FinishZigzagMode = false;

	public bool FinishPerpendicularA = false;

	public bool FinishReverseCAngle = false;

	public bool FinishMoveUpSafe = true;

	public bool FinishExecuteVerticalWalls = false;

	public bool Finish5Axis = false;

	public double OffsetPlungeFeed = 20.0;

	public double OffsetCutForwardFeed = 50.0;

	public double OffsetCutBackwardFeed = 50.0;

	public double OffsetSafeDis = 50.0;

	public double OffsetAngleStep = 1.0;

	public double OffsetMinZ = 0.0;

	public double OffsetLeadInAngle = 1.0;

	public double OffsetLeadOutAngle = 1.0;

	public double OffsetInsideOffset = 0.0;

	public double OffsetOutsideOffset = 0.0;

	public double OffsetEdgeOffset = 0.0;

	public double OffsetZForwardDownStep = 10.0;

	public double OffsetInnerCutAAngle = 0.0;

	public bool OffsetEnable = true;

	public bool OffsetZigzagMode = false;

	public bool OffsetReverseCAngle = false;

	public bool OffsetCutInisde = true;

	public bool OffsetCutOutside = true;

	public bool OffsetCutEdges = true;

	public double CurveToSurfaceResolution = 1.0;

	public bool CutProfileStart = false;

	public bool CutProfileEnd = false;

	public double CutProfileDepthStep = 50.0;

	public double CurveAngleStep = 1.0;

	public bool VerticalCut = false;

	public bool TwistEnable = false;

	public double TwistStartAngle = 5.0;

	public double TwistEndAngle = -5.0;

	public double TwisStepAngle = 0.1;

	public CamAxisCountType CamTypeRough = CamAxisCountType.Axis3;

	public CamAxisCountType CamTypeFinish = CamAxisCountType.Axis3;

	public static List<string> Captions = new List<string>();

	public marbleProfileCurveCutPars()
	{
	}

	public marbleProfileCurveCutPars(marbleProfileCurveCutPars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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

	public static void Copy(marbleProfileCurveCutPars Source, ref marbleProfileCurveCutPars Target)
	{
		Target = new marbleProfileCurveCutPars(Source);
	}

	public override string ToString()
	{
		return "Radius : " + Radius + " , StartAngle : " + StartAngle + " , SweepAngle : " + SweepAngle;
	}
}
