using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleProgramSettings : buSerilization5
{
	public MarbleScreenCaptureSettings ScreenCapture = new MarbleScreenCaptureSettings();

	public int MarbleMaterialTransparan = 100;

	public string DxfCuttingLayerName = "0";

	public string DxfMillingDrillLayer = "1006";

	public bool MotionMode = false;

	public bool TouchPad = false;

	public int CameraExposure = 100000;

	public int CameraCropX = 0;

	public int CameraCropY = 0;

	public int CameraCropWidth = 0;

	public int CameraCropHeight = 0;

	public bool CopyImageToArchive = false;

	public double ImageZPosition = -0.1;

	public double ImageRotateAngle = 0.0;

	public double CameraImageOffsetX = 0.0;

	public double CameraImageOffsetY = 0.0;

	public double CameraImagedX = 0.0;

	public double CameraImagedY = 0.0;

	public double CameraImageWidth = 3540.0;

	public double CameraImageHeight = 2100.0;

	public double CameraPixelMMCalibX = 1.0;

	public double CameraPixelMMCalibY = 1.0;

	public int CameraWaitTick = 6;

	public double CameraLensXRatio = 1.0;

	public double CameraLensYRatio = 1.0;

	public bool UseCameraImageThicknessList = false;

	public bool AutoLensCalibrationFromMaterialHeight = false;

	public bool DontAddExtensionEntities = false;

	public bool OutsideEntityIsReferance = false;

	public bool EngraveOnlineCamCalculation = false;

	public bool TextOnlineCamCalculation = false;

	public bool ProfileOnlineCamCalculation = false;

	public bool ContourOnlineCamCalculation = true;

	public bool DrillOnlineCamCalculation = true;

	public bool SliceOnlineCamCalculation = true;

	public bool SweepOnlineCamCalculation = false;

	public bool CavityOnlineCamCalculation = false;

	public bool ColumnsOnlineCamCalculation = false;

	public bool LatheOnlineCamCalculation = false;

	public bool SliceListClearAfterFinished = false;

	public bool StartSpindleBeforePlunge = false;

	public bool StartWaterBeforePlunge = false;

	public bool ShowMaterialLimits = false;

	public bool IntersectionEnable = false;

	public bool MaterialBorderControl = false;

	public bool AutoMagnet = false;

	public bool MagnetPart = false;

	public double GridStep = 100.0;

	public double EntityCatchDistance = 15.0;

	public int GridMajorCount = 5;

	public bool GridLight = true;

	public int SpindleTrackPlusMinusStep = 10;

	public int SpindleTrackMinVal = 20;

	public bool CheckMachineLimits = true;

	public bool CheckPartLimits = true;

	public bool ShowSpindleTrack = true;

	public bool ShowSawTrack = true;

	public bool DrawWoodBase = true;

	public bool TextFromFileAsWireframe = false;

	public bool CloseMenuPageAfterCommand = true;

	public bool ShowPartZero = false;

	public bool ShowStartOption = false;

	public bool ShowWarningList = false;

	public bool ShowWarningPopup = false;

	public bool ShowAlarmPoppup = false;

	public bool ShowOpenSaveButtonAtToolPage = false;

	public bool ShowGoToolZeroAtToolPage = false;

	public bool AskSpeedSawManuelStart = false;

	public bool AskSpeedSpindleManuelStart = false;

	public bool AutoUpdateToolListFromActiveTools = false;

	public MarbleExternalGCode GCodeConversion = MarbleExternalGCode.AspireGCode;

	public ImageRotateFlipType ImageRotateType = ImageRotateFlipType.RotateNoneFlipNone;

	public MarbleCameraType CameraType = MarbleCameraType.Canon250DCable;

	public MarbleToolListMode ToolListMode = MarbleToolListMode.TabListView;

	public string CameraFileName = "Converter.png";

	public string CompareProgramName = "";

	public static List<string> Captions = new List<string>();

	public MarbleProgramSettings()
	{
	}

	public MarbleProgramSettings(MarbleProgramSettings data)
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
		ScreenCapture = new MarbleScreenCaptureSettings(data.ScreenCapture);
	}

	public static void Copy(MarbleProgramSettings Source, ref MarbleProgramSettings Target)
	{
		Target = new MarbleProgramSettings(Source);
	}

	public override string ToString()
	{
		return "";
	}
}
