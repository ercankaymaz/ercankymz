// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleScreenCaptureSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleScreenCaptureSettings : buSerilization5
{
  public MarbleShapeTypes ShapeType;
  public MarbleToolType ToolType;
  public ClockDirectionType ClockDir;
  public List<MarbleItemCommands> ItemCommands;
  public Color colorItem;
  public ObjectSize3D SizeItem;
  public Point3D MovePoint;
  public Point3D BasePoint;
  public Point3D CalcMovePoint;
  public Pnt6D CamPoint;
  public Point3D SortRefPoint;
  public MaterialSkin Skin;
  public buEntitiesGroup EntGroup;
  public buEntitiesGroup EntGroupBottom;
  public MarbleItemEntities ItemEntities;
  public List<marbleEdgeItem> Edges;
  public List<marbleCollapseItem> Collapses;
  public List<MarbleItemCam> CamList;
  public MarbleItemSettings Settings;
  public List<OsnapPoint> OsnapPoints;
  public List<MarbleItemExtend> Extends;
  public marbleCounterTopBase Countertop;
  public List<string> ErrorMessages;
  public List<string> WarningMessages;
  public static byte f004862;
  public string CamName;
  public bool isCamCalculated;
  public bool isConcave;
  public bool isConvex;
  public bool isTempCam;

  public MarbleScreenCaptureSettings()
  {
    ((MarbleTempVars) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands();
    ((MarbleTempVars) this).CamParNotch = new camParameters5();
    ((MarbleTempVars) this).MirrorData = (ProfileMirror) new MarbleImageSettings();
    ((MarbleTempVars) this).ArrayData = (buEyeBaseVer5.Apps.ProfileArray) new MarbleDrawingSetting();
    ((MarbleTempVars) this).AnalyseSettings = (AnalyseEntitiesSetting) new PlaneAngle();
    ((MarbleTempVars) this).MultiplyProfileEnable = false;
    ((MarbleTempVars) this).MultiplyProfileMirror = false;
    ((MarbleTempVars) this).MultiplyProfileCount = 1;
    ((MarbleTempVars) this).MultiplyProfileSpace = 0.0;
    ((MarbleTempVars) this).NewProfileWidth = 100.0;
    ((MarbleTempVars) this).NewProfileHeight = 100.0;
    ((MarbleTempVars) this).NewProfileThickness = 2.0;
    ((MarbleTempVars) this).FreeDrawOrjinalWidth = 0.0;
    ((MarbleTempVars) this).FreeDrawOrjinalHeight = 0.0;
    ((MarbleTempVars) this).SimStep = 2;
    ((MarbleTempVars) this).ClamperMoveStep = 10.0;
    ((MarbleTempVars) this).DrawingeLayerIndex = 0;
    ((MarbleTempVars) this).OperationWireframeLayerIndex = 1;
    ((MarbleTempVars) this).AuxLayerIndex = 2;
    ((MarbleTempVars) this).SupportBlockLayerIndex = 3;
    ((MarbleTempVars) this).OperationPlaneLayerIndex = 4;
    ((MarbleTempVars) this).CamLayerIndex = 5;
    ((MarbleTempVars) this).OperationSolidLayerIndex = 7;
    ((MarbleTempVars) this).ProfileLayerIndex = 8;
    ((MarbleTempVars) this).PatternCopyDistance = 100.0;
    ((MarbleTempVars) this).PatternCopyCutSpace = 4.0;
    ((MarbleTempVars) this).PatternCopyCount = 1;
    ((MarbleTempVars) this).PatternShowSeperators = true;
    ((MarbleTempVars) this).TemplateScaleXEnable = true;
    ((MarbleTempVars) this).TemplateScaleYZEnable = true;
    ((MarbleTempVars) this).JobListDeleteLoaded = true;
    ((MarbleTempVars) this).SelectMode = false;
    ((MarbleTempVars) this).SelectModeSim = false;
    ((MarbleTempVars) this).TemplateOffset = 0.0;
    ((MarbleTempVars) this).ProfileLength = 1000.0;
    ((MarbleTempVars) this).SupportBlockZHeight = 0.0;
    ((MarbleTempVars) this).SupportBlockY1Height = 0.0;
    ((MarbleTempVars) this).SupportBlockY2Height = 0.0;
    ((MarbleTempVars) this).SupportBlockZWidth = 0.0;
    ((MarbleTempVars) this).SupportBlockY1Width = 0.0;
    ((MarbleTempVars) this).SupportBlockY2Width = 0.0;
    ((MarbleTempVars) this).ProfileType = ProfileNewType.Drawing;
    ((MarbleTempVars) this).pathProfiles = Application.StartupPath;
    ((MarbleTempVars) this).pathSaveProfiles = Application.StartupPath;
    ((MarbleTempVars) this).pathPlanes = Application.StartupPath;
    ((MarbleTempVars) this).pathDepths = Application.StartupPath;
    ((MarbleTempVars) this).pathClampers = Application.StartupPath;
    ((MarbleTempVars) this).pathOperationFromFile = Application.StartupPath;
    ((MarbleTempVars) this).pathOperationFromFileList = Application.StartupPath;
    ((MarbleTempVars) this).pathNCXFiles = Application.StartupPath;
    ((MarbleTempVars) this).pathJobList = Application.StartupPath;
    ((MarbleTempVars) this).pathMacro = Application.StartupPath;
    ((MarbleTempVars) this).path3DFiles = Application.StartupPath;
    ((MarbleTempVars) this).LastLoadedProfileName = "";
    ((MarbleTempVars) this).LastSavedProfileJobName = "";
    ((MarbleTempVars) this).MacroSaveOpen = new ProfileMacroOpenSave();
    ((MarbleTempVars) this).OPData = (buEyeBaseVer5.Apps.ProfileOperationData) new buMarbleCalc();
    ((MarbleTempVars) this).selectedFreePlaneLength = 0.0;
    ((MarbleTempVars) this).TextureEnable = false;
    ((MarbleRuntimeSettings) this).IncrementalMode = false;
    ((MarbleRuntimeSettings) this).FromFileKeepRatio = true;
    ((MarbleRuntimeSettings) this).HideClampers = false;
    ((MarbleRuntimeSettings) this).HideMachine = false;
    ((MarbleRuntimeSettings) this).HideMachineBody = false;
    ((MarbleRuntimeSettings) this).HideCam = false;
    ((MarbleRuntimeSettings) this).HideContour = false;
    ((MarbleRuntimeSettings) this).HideSupport = false;
    ((MarbleRuntimeSettings) this).HideProfile = false;
    ((MarbleRuntimeSettings) this).HideOperations = false;
    ((MarbleRuntimeSettings) this).activeProfileIndex = -1;
    ((MarbleRuntimeSettings) this).activeOPIndex = -1;
    ((MarbleRuntimeSettings) this).activeOPName = "";
    ((MarbleRuntimeSettings) this).activeCalcDataIndex = -1;
    ((MarbleRuntimeSettings) this).ProfileKeepRatio = true;
    ((MarbleRuntimeSettings) this).GhostClamper = false;
    ((MarbleRuntimeSettings) this).CollisionDetect = true;
    ((MarbleRuntimeSettings) this).CopyMoveUseOriginalePlane = true;
    ((MarbleRuntimeSettings) this).CopyCount = 1;
    ((MarbleRuntimeSettings) this).CopyDistanceHor = 0.0;
    ((MarbleRuntimeSettings) this).CopyDistanceVer = 0.0;
    ((MarbleRuntimeSettings) this).CopyUseDistance = false;
    ((MarbleRuntimeSettings) this).LeftAngle = 0.0;
    ((MarbleRuntimeSettings) this).RigthAngle = 0.0;
    ((MarbleRuntimeSettings) this).path3DJob = Application.StartupPath;
    ((MarbleRuntimeSettings) this).pathEngraving = Application.StartupPath;
    ((MarbleRuntimeSettings) this).lastToolName = "";
    ((MarbleRuntimeSettings) this).EngravingKeepRatio = true;
    ((MarbleRuntimeSettings) this).RecentSaveFile1 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile2 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile3 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile4 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile5 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile6 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile1 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile2 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile3 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile4 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile5 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile6 = "-";
    ((MarbleRuntimeSettings) this).Transformations = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleScreenCaptureSettings(buEyeBaseVer5.Apps.ProfileRuntimeSettings data)
  {
    ((MarbleTempVars) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands();
    ((MarbleTempVars) this).CamParNotch = new camParameters5();
    ((MarbleTempVars) this).MirrorData = (ProfileMirror) new MarbleImageSettings();
    ((MarbleTempVars) this).ArrayData = (buEyeBaseVer5.Apps.ProfileArray) new MarbleDrawingSetting();
    ((MarbleTempVars) this).AnalyseSettings = (AnalyseEntitiesSetting) new PlaneAngle();
    ((MarbleTempVars) this).MultiplyProfileEnable = false;
    ((MarbleTempVars) this).MultiplyProfileMirror = false;
    ((MarbleTempVars) this).MultiplyProfileCount = 1;
    ((MarbleTempVars) this).MultiplyProfileSpace = 0.0;
    ((MarbleTempVars) this).NewProfileWidth = 100.0;
    ((MarbleTempVars) this).NewProfileHeight = 100.0;
    ((MarbleTempVars) this).NewProfileThickness = 2.0;
    ((MarbleTempVars) this).FreeDrawOrjinalWidth = 0.0;
    ((MarbleTempVars) this).FreeDrawOrjinalHeight = 0.0;
    ((MarbleTempVars) this).SimStep = 2;
    ((MarbleTempVars) this).ClamperMoveStep = 10.0;
    ((MarbleTempVars) this).DrawingeLayerIndex = 0;
    ((MarbleTempVars) this).OperationWireframeLayerIndex = 1;
    ((MarbleTempVars) this).AuxLayerIndex = 2;
    ((MarbleTempVars) this).SupportBlockLayerIndex = 3;
    ((MarbleTempVars) this).OperationPlaneLayerIndex = 4;
    ((MarbleTempVars) this).CamLayerIndex = 5;
    ((MarbleTempVars) this).OperationSolidLayerIndex = 7;
    ((MarbleTempVars) this).ProfileLayerIndex = 8;
    ((MarbleTempVars) this).PatternCopyDistance = 100.0;
    ((MarbleTempVars) this).PatternCopyCutSpace = 4.0;
    ((MarbleTempVars) this).PatternCopyCount = 1;
    ((MarbleTempVars) this).PatternShowSeperators = true;
    ((MarbleTempVars) this).TemplateScaleXEnable = true;
    ((MarbleTempVars) this).TemplateScaleYZEnable = true;
    ((MarbleTempVars) this).JobListDeleteLoaded = true;
    ((MarbleTempVars) this).SelectMode = false;
    ((MarbleTempVars) this).SelectModeSim = false;
    ((MarbleTempVars) this).TemplateOffset = 0.0;
    ((MarbleTempVars) this).ProfileLength = 1000.0;
    ((MarbleTempVars) this).SupportBlockZHeight = 0.0;
    ((MarbleTempVars) this).SupportBlockY1Height = 0.0;
    ((MarbleTempVars) this).SupportBlockY2Height = 0.0;
    ((MarbleTempVars) this).SupportBlockZWidth = 0.0;
    ((MarbleTempVars) this).SupportBlockY1Width = 0.0;
    ((MarbleTempVars) this).SupportBlockY2Width = 0.0;
    ((MarbleTempVars) this).ProfileType = ProfileNewType.Drawing;
    ((MarbleTempVars) this).pathProfiles = Application.StartupPath;
    ((MarbleTempVars) this).pathSaveProfiles = Application.StartupPath;
    ((MarbleTempVars) this).pathPlanes = Application.StartupPath;
    ((MarbleTempVars) this).pathDepths = Application.StartupPath;
    ((MarbleTempVars) this).pathClampers = Application.StartupPath;
    ((MarbleTempVars) this).pathOperationFromFile = Application.StartupPath;
    ((MarbleTempVars) this).pathOperationFromFileList = Application.StartupPath;
    ((MarbleTempVars) this).pathNCXFiles = Application.StartupPath;
    ((MarbleTempVars) this).pathJobList = Application.StartupPath;
    ((MarbleTempVars) this).pathMacro = Application.StartupPath;
    ((MarbleTempVars) this).path3DFiles = Application.StartupPath;
    ((MarbleTempVars) this).LastLoadedProfileName = "";
    ((MarbleTempVars) this).LastSavedProfileJobName = "";
    ((MarbleTempVars) this).MacroSaveOpen = new ProfileMacroOpenSave();
    ((MarbleTempVars) this).OPData = (buEyeBaseVer5.Apps.ProfileOperationData) new buMarbleCalc();
    ((MarbleTempVars) this).selectedFreePlaneLength = 0.0;
    ((MarbleTempVars) this).TextureEnable = false;
    ((MarbleRuntimeSettings) this).IncrementalMode = false;
    ((MarbleRuntimeSettings) this).FromFileKeepRatio = true;
    ((MarbleRuntimeSettings) this).HideClampers = false;
    ((MarbleRuntimeSettings) this).HideMachine = false;
    ((MarbleRuntimeSettings) this).HideMachineBody = false;
    ((MarbleRuntimeSettings) this).HideCam = false;
    ((MarbleRuntimeSettings) this).HideContour = false;
    ((MarbleRuntimeSettings) this).HideSupport = false;
    ((MarbleRuntimeSettings) this).HideProfile = false;
    ((MarbleRuntimeSettings) this).HideOperations = false;
    ((MarbleRuntimeSettings) this).activeProfileIndex = -1;
    ((MarbleRuntimeSettings) this).activeOPIndex = -1;
    ((MarbleRuntimeSettings) this).activeOPName = "";
    ((MarbleRuntimeSettings) this).activeCalcDataIndex = -1;
    ((MarbleRuntimeSettings) this).ProfileKeepRatio = true;
    ((MarbleRuntimeSettings) this).GhostClamper = false;
    ((MarbleRuntimeSettings) this).CollisionDetect = true;
    ((MarbleRuntimeSettings) this).CopyMoveUseOriginalePlane = true;
    ((MarbleRuntimeSettings) this).CopyCount = 1;
    ((MarbleRuntimeSettings) this).CopyDistanceHor = 0.0;
    ((MarbleRuntimeSettings) this).CopyDistanceVer = 0.0;
    ((MarbleRuntimeSettings) this).CopyUseDistance = false;
    ((MarbleRuntimeSettings) this).LeftAngle = 0.0;
    ((MarbleRuntimeSettings) this).RigthAngle = 0.0;
    ((MarbleRuntimeSettings) this).path3DJob = Application.StartupPath;
    ((MarbleRuntimeSettings) this).pathEngraving = Application.StartupPath;
    ((MarbleRuntimeSettings) this).lastToolName = "";
    ((MarbleRuntimeSettings) this).EngravingKeepRatio = true;
    ((MarbleRuntimeSettings) this).RecentSaveFile1 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile2 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile3 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile4 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile5 = "-";
    ((MarbleRuntimeSettings) this).RecentSaveFile6 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile1 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile2 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile3 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile4 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile5 = "-";
    ((MarbleRuntimeSettings) this).RecentOpenFile6 = "-";
    ((MarbleRuntimeSettings) this).Transformations = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
    ((MarbleTempVars) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands(((MarbleTempVars) data).ShapeDataParameters);
    ((MarbleTempVars) this).CamParNotch = (camParameters5) new camRuntime5(((MarbleTempVars) data).CamParNotch);
    ((MarbleTempVars) this).ArrayData = (buEyeBaseVer5.Apps.ProfileArray) new MarbleDrawingSetting(((MarbleTempVars) data).ArrayData);
    ((MarbleTempVars) this).MirrorData = (ProfileMirror) new MarbleImageSettings(((MarbleTempVars) data).MirrorData);
    ((MarbleTempVars) this).AnalyseSettings = (AnalyseEntitiesSetting) new PlaneAngle(((MarbleTempVars) data).AnalyseSettings);
    ((MarbleTempVars) this).MacroSaveOpen = new ProfileMacroOpenSave(((MarbleTempVars) data).MacroSaveOpen);
    ((MarbleTempVars) this).OPData = (buEyeBaseVer5.Apps.ProfileOperationData) new buMarbleCalc(((MarbleTempVars) data).OPData);
  }

  public abstract void m001EA3();

  public MarbleScreenCaptureSettings()
  {
    ((MarbleRuntimeSettings) this).LeftMinDis = 0.0;
    ((MarbleRuntimeSettings) this).LeftMaxDis = 0.0;
    ((MarbleRuntimeSettings) this).LeftMinClamperPos = 0.0;
    ((MarbleRuntimeSettings) this).LeftMaxClamperPos = 0.0;
    ((MarbleRuntimeSettings) this).RightMinDis = 0.0;
    ((MarbleRuntimeSettings) this).RightMaxDis = 0.0;
    ((MarbleRuntimeSettings) this).RightMinClamperPos = 0.0;
    ((MarbleRuntimeSettings) this).RightMaxClamperPos = 0.0;
    ((MarbleRuntimeSettings) this).OperationAboveClamper = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
