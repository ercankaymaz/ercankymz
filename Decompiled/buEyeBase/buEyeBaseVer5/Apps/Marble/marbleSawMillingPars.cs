using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleSawMillingPars : buSerilization5
{
	public double SawMillingRoughHorTopOffset = 0.0;

	public double SawMillingRoughHorBottomOffset = 0.0;

	public double SawMillingRoughHorMinZValue = 0.0;

	public double SawMillingRoughHorZDownStep = 5.0;

	public double SawMillingRoughHorStepover = 5.0;

	public double SawMillingRoughHorSurfaceOffset = 0.0;

	public double SawMillingRoughHorSafeDistance = 100.0;

	public double SawMillingRoughHorForwardCuttingFeed = 100.0;

	public double SawMillingRoughHorBackwardCuttingFeed = 100.0;

	public double SawMillingRoughHorPlungeFeed = 15.0;

	public double SawMillingRoughHorXYOffset = 0.0;

	public double SawMillingRoughHorSingleLayerDepth = 100.0;

	public int SawMillingRoughHorCurvatureDegree = 5;

	public bool SawMillingRoughHorUseSingleLayer = false;

	public bool SawMillingRoughHorZigzag = true;

	public bool SawMillingRoughHorReverseC = false;

	public MarbleCamAreaMode SawMillingRoughHorAreaMode = MarbleCamAreaMode.Level;

	public double SawMillingRoughVerTopOffset = 0.0;

	public double SawMillingRoughVerBottomOffset = 0.0;

	public double SawMillingRoughVerMinZValue = 0.0;

	public double SawMillingRoughVerZDownStep = 5.0;

	public double SawMillingRoughVerApproach = 20.0;

	public double SawMillingRoughVerMaxCutDepth = 150.0;

	public double SawMillingRoughVerCutStep = 50.0;

	public double SawMillingRoughVerSurfaceOffset = 0.0;

	public double SawMillingRoughVerSafeDistance = 100.0;

	public double SawMillingRoughVerForwardCuttingFeed = 100.0;

	public double SawMillingRoughVerBackwardCuttingFeed = 100.0;

	public double SawMillingRoughVerPlungeFeed = 15.0;

	public double SawMillingRoughVerXYOffset = 0.0;

	public double SawMillingRoughVerCutTolerance = 0.2;

	public double SawMillingRoughVerSplineDt = 0.2;

	public double SawMillingRoughVerSingleLayerDepth = 100.0;

	public int SawMillingRoughVerCurvatureDegree = 5;

	public bool SawMillingRoughVerUseSingleLayer = false;

	public bool SawMillingRoughVerSplineEnable = false;

	public bool SawMillingRoughVerZigzag = true;

	public bool SawMillingRoughVerReverseC = false;

	public MarbleCamAreaMode SawMillingRoughVerAreaMode = MarbleCamAreaMode.Level;

	public double SawMillingFinishHorStartOffset = 0.0;

	public double SawMillingFinishHorEndOffset = 0.0;

	public double SawMillingFinishHorMinZValue = 0.0;

	public double SawMillingFinishVerTopOffset = 0.0;

	public double SawMillingFinishVerBottomOffset = 0.0;

	public double SawMillingFinishVerMinZValue = 0.0;

	public double SawMillingFinishVerZDownStep = 5.0;

	public double SawMillingFinishVerApproach = 20.0;

	public double SawMillingFinishVerSurfaceOffset = 0.0;

	public double SawMillingFinishVerAngleStep = 5.0;

	public double SawMillingFinishVerSafeDistance = 100.0;

	public double SawMillingFinishVerForwardCuttingFeed = 100.0;

	public double SawMillingFinishVerBackwardCuttingFeed = 100.0;

	public double SawMillingFinishVerPlungeFeed = 15.0;

	public double SawMillingFinishVerXYOffset = 0.0;

	public bool SawMillingFinishVerZigzag = true;

	public bool SawMillingFinishVerReverseC = false;

	public double SawMillingApproachDistance = 20.0;

	public double SawMillingSafeDistance = 100.0;

	public double SawMillingRapidDistance = 20.0;

	public double SawMillingForwardCuttingFeed = 100.0;

	public double SawMillingBackwardCuttingFeed = 100.0;

	public double SawMillingPlungeFeed = 15.0;

	public double SawMillingZStepDown = 40.0;

	public double SawMillingXYOffset = 0.0;

	public bool SawMillingZigzag = true;

	public bool SawMillingReverseC = false;

	public double SawMillingVerCornerTopOffset = 0.0;

	public double SawMillingVerCornerBottomOffset = 0.0;

	public double SawMillingVerCornerZDownStep = 10.0;

	public double SawMillingVerCornerXYAproachStep = 40.0;

	public double SawMillingVerCornerSafeDistanceZ = 100.0;

	public double SawMillingVerCornerSafeDistanceXY = 100.0;

	public double SawMillingVerCornerForwardCuttingFeed = 100.0;

	public double SawMillingVerCornerBackwardCuttingFeed = 60.0;

	public double SawMillingVerCornerPlungeFeed = 15.0;

	public double SawMillingVerCornerXYOffset = 0.0;

	public double SawMillingVerCornerCutTolerance = 0.1;

	public double SawMillingVerCornerSplineDt = 0.1;

	public double SawMillingVerCornerSingleLayerDepth = 100.0;

	public int SawMillingVerCornerCurvatureDegree = 5;

	public bool SawMillingVerCornerSplineEnable = false;

	public bool SawMillingVerCornerZigzag = true;

	public bool SawMillingVerCornerUseLastContour = true;

	public bool SawMillingVerCornerUseSingleLayer = false;

	public bool SawMillingVerCornerTrimToBorder = true;

	public MarbleCamAreaMode SawMillingVerCornerAreaMode = MarbleCamAreaMode.Level;

	public MarbleSawCornerCleanMode SawMillingVerCornerMode = MarbleSawCornerCleanMode.FitArc;

	public Color SawMillingCamColor = Color.Red;

	public static List<string> Captions = new List<string>();

	public marbleSawMillingPars()
	{
	}

	public marbleSawMillingPars(marbleSawMillingPars data)
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

	public static void Copy(marbleSawMillingPars Source, ref marbleSawMillingPars Target)
	{
		Target = new marbleSawMillingPars(Source);
	}

	public override string ToString()
	{
		return "RoughHorStartOffset : " + SawMillingRoughHorTopOffset;
	}
}
