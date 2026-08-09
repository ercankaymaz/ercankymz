using System;
using System.Collections.Generic;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemSettings : buSerilization5
{
	public marbleCamPars settingMarbleCam = new marbleCamPars();

	public marbleSawMillingPars settingSawMilling = new marbleSawMillingPars();

	public marbleSlicesPars settingSliceCut = new marbleSlicesPars();

	public marbleProfileCutPars settingProfileCut = new marbleProfileCutPars();

	public marbleProfileCurveCutPars settingProfileCurveCut = new marbleProfileCurveCutPars();

	public marbleAirDryPars settingAirDry = new marbleAirDryPars();

	public marbleMatrialCleanPars settingMaterialClean = new marbleMatrialCleanPars();

	public marbleColoumsPars settingColoumnsCut = new marbleColoumsPars();

	public marbleLathePars settingLatheCut = new marbleLathePars();

	public marbleLatheVerticalPars settingLatheVerticalCut = new marbleLatheVerticalPars();

	public marbleChamferPars settingChamferCut = new marbleChamferPars();

	public marbleSweepPars settingSweepCut = new marbleSweepPars();

	public marbleDrillPars settingDrillCut = new marbleDrillPars();

	public marbleCavityPars settingCavity = new marbleCavityPars();

	public marbleTapPars settingTap = new marbleTapPars();

	public marbleVacuumPars settingVacuum = new marbleVacuumPars();

	public marbleMaterialPars MaterialParameter = new marbleMaterialPars();

	public marbleCamSawFeedAnalysisPars SawFeedAnalysisParameter = new marbleCamSawFeedAnalysisPars();

	public marbleReadSurfacePars ReadSurfaceParameter = new marbleReadSurfacePars();

	public marbleEventPar settingEvent = new marbleEventPar();

	public marbleSurfaceCleanPars settingSurfaceClean = new marbleSurfaceCleanPars();

	public marbleCutRemainMaterial settingCutRemailMaterial = new marbleCutRemainMaterial();

	public List<MarbleOperationSequence> CuttingSequence = new List<MarbleOperationSequence>();

	public MarbleItemSettings()
	{
	}

	public MarbleItemSettings(MarbleItemSettings data)
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
		MaterialParameter = new marbleMaterialPars(data.MaterialParameter);
		SawFeedAnalysisParameter = new marbleCamSawFeedAnalysisPars(data.SawFeedAnalysisParameter);
		ReadSurfaceParameter = new marbleReadSurfacePars(data.ReadSurfaceParameter);
		settingProfileCut = new marbleProfileCutPars(data.settingProfileCut);
		settingProfileCurveCut = new marbleProfileCurveCutPars(data.settingProfileCurveCut);
		settingAirDry = new marbleAirDryPars(data.settingAirDry);
		settingMaterialClean = new marbleMatrialCleanPars(data.settingMaterialClean);
		settingColoumnsCut = new marbleColoumsPars(data.settingColoumnsCut);
		settingLatheCut = new marbleLathePars(data.settingLatheCut);
		settingLatheVerticalCut = new marbleLatheVerticalPars(data.settingLatheVerticalCut);
		settingSweepCut = new marbleSweepPars(data.settingSweepCut);
		settingSliceCut = new marbleSlicesPars(data.settingSliceCut);
		settingChamferCut = new marbleChamferPars(data.settingChamferCut);
		settingDrillCut = new marbleDrillPars(data.settingDrillCut);
		settingMarbleCam = new marbleCamPars(data.settingMarbleCam);
		settingEvent = new marbleEventPar(data.settingEvent);
		settingSawMilling = new marbleSawMillingPars(data.settingSawMilling);
		settingSurfaceClean = new marbleSurfaceCleanPars(data.settingSurfaceClean);
		settingCavity = new marbleCavityPars(data.settingCavity);
		settingTap = new marbleTapPars(data.settingTap);
		settingVacuum = new marbleVacuumPars(data.settingVacuum);
		settingCutRemailMaterial = new marbleCutRemainMaterial(data.settingCutRemailMaterial);
	}

	public static void Copy(MarbleItemSettings refCam, ref MarbleItemSettings copiedCam)
	{
		if (refCam != null)
		{
			copiedCam = new MarbleItemSettings(refCam);
		}
	}

	public override string ToString()
	{
		return "Target Z:" + settingMarbleCam.TargetZ;
	}
}
