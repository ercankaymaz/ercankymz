using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.Apps;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileRuntimeSettings : buSerilization5
{
	public ShapeRuntimeData ShapeDataParameters = new ShapeRuntimeData();

	public camParameters5 CamParNotch = new camParameters5();

	public ProfileMirror MirrorData = new ProfileMirror();

	public ProfileArray ArrayData = new ProfileArray();

	public AnalyseEntitiesSetting AnalyseSettings = new AnalyseEntitiesSetting();

	public bool MultiplyProfileEnable = false;

	public bool MultiplyProfileMirror = false;

	public int MultiplyProfileCount = 1;

	public double MultiplyProfileSpace = 0.0;

	public double NewProfileWidth = 100.0;

	public double NewProfileHeight = 100.0;

	public double NewProfileThickness = 2.0;

	public double FreeDrawOrjinalWidth = 0.0;

	public double FreeDrawOrjinalHeight = 0.0;

	public int SimStep = 2;

	public double ClamperMoveStep = 10.0;

	public int DrawingeLayerIndex = 0;

	public int OperationWireframeLayerIndex = 1;

	public int AuxLayerIndex = 2;

	public int SupportBlockLayerIndex = 3;

	public int OperationPlaneLayerIndex = 4;

	public int CamLayerIndex = 5;

	public int OperationSolidLayerIndex = 7;

	public int ProfileLayerIndex = 8;

	public double PatternCopyDistance = 100.0;

	public double PatternCopyCutSpace = 4.0;

	public int PatternCopyCount = 1;

	public bool PatternShowSeperators = true;

	public bool TemplateScaleXEnable = true;

	public bool TemplateScaleYZEnable = true;

	public bool JobListDeleteLoaded = true;

	public bool SelectMode = false;

	public bool SelectModeSim = false;

	public double TemplateOffset = 0.0;

	public double ProfileLength = 1000.0;

	public double SupportBlockZHeight = 0.0;

	public double SupportBlockY1Height = 0.0;

	public double SupportBlockY2Height = 0.0;

	public double SupportBlockZWidth = 0.0;

	public double SupportBlockY1Width = 0.0;

	public double SupportBlockY2Width = 0.0;

	public ProfileNewType ProfileType = ProfileNewType.Drawing;

	public string pathProfiles = Application.StartupPath;

	public string pathSaveProfiles = Application.StartupPath;

	public string pathPlanes = Application.StartupPath;

	public string pathDepths = Application.StartupPath;

	public string pathClampers = Application.StartupPath;

	public string pathOperationFromFile = Application.StartupPath;

	public string pathOperationFromFileList = Application.StartupPath;

	public string pathNCXFiles = Application.StartupPath;

	public string pathJobList = Application.StartupPath;

	public string pathMacro = Application.StartupPath;

	public string path3DFiles = Application.StartupPath;

	public string LastLoadedProfileName = "";

	public string LastSavedProfileJobName = "";

	public ProfileMacroOpenSave MacroSaveOpen = new ProfileMacroOpenSave();

	public ProfileOperationData OPData = new ProfileOperationData();

	public double selectedFreePlaneLength = 0.0;

	public bool TextureEnable = false;

	public bool IncrementalMode = false;

	public bool FromFileKeepRatio = true;

	public bool HideClampers = false;

	public bool HideMachine = false;

	public bool HideMachineBody = false;

	public bool HideCam = false;

	public bool HideContour = false;

	public bool HideSupport = false;

	public bool HideProfile = false;

	public bool HideOperations = false;

	public int activeProfileIndex = -1;

	public int activeOPIndex = -1;

	public string activeOPName = "";

	public int activeCalcDataIndex = -1;

	public bool ProfileKeepRatio = true;

	public bool GhostClamper = false;

	public bool CollisionDetect = true;

	public bool CopyMoveUseOriginalePlane = true;

	public int CopyCount = 1;

	public double CopyDistanceHor = 0.0;

	public double CopyDistanceVer = 0.0;

	public bool CopyUseDistance = false;

	public double LeftAngle = 0.0;

	public double RigthAngle = 0.0;

	public string path3DJob = Application.StartupPath;

	public string pathEngraving = Application.StartupPath;

	public string lastToolName = "";

	public bool EngravingKeepRatio = true;

	public string RecentSaveFile1 = "-";

	public string RecentSaveFile2 = "-";

	public string RecentSaveFile3 = "-";

	public string RecentSaveFile4 = "-";

	public string RecentSaveFile5 = "-";

	public string RecentSaveFile6 = "-";

	public string RecentOpenFile1 = "-";

	public string RecentOpenFile2 = "-";

	public string RecentOpenFile3 = "-";

	public string RecentOpenFile4 = "-";

	public string RecentOpenFile5 = "-";

	public string RecentOpenFile6 = "-";

	public List<string> Transformations = new List<string>();

	public ProfileRuntimeSettings()
	{
	}

	public ProfileRuntimeSettings(ProfileRuntimeSettings data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		ShapeDataParameters = new ShapeRuntimeData(data.ShapeDataParameters);
		CamParNotch = new camParameters5(data.CamParNotch);
		ArrayData = new ProfileArray(data.ArrayData);
		MirrorData = new ProfileMirror(data.MirrorData);
		AnalyseSettings = new AnalyseEntitiesSetting(data.AnalyseSettings);
		MacroSaveOpen = new ProfileMacroOpenSave(data.MacroSaveOpen);
		OPData = new ProfileOperationData(data.OPData);
	}
}
