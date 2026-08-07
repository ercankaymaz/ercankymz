// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleTempVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using System.Drawing;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public static class MarbleTempVars
{
  public ProfileSortMethods SortType;
  public double RegenDeviation;
  public int CollisionControlMinStep;
  public bool ParabolicMoveBetweenPlanes;
  public double ParabolicSafeDistance;
  public double ParabolicMoveFeed;
  public ProfileParaolicAxesType ParabolicAllowedAxes;
  public bool AutoSave;
  public bool AutoSaveWithTimeFileName;
  public int AutoSaveTimeSec;
  public int AutoSaveMaxCount;
  public bool UseDrillToolForDrill;
  public double PlaneToPlaneSafeDisance;
  public bool NotchSideSafeAtXAxis;
  public bool NotchVerticalSafeAtXAxis;
  public bool NotchVerticalForbiddenAtSide;
  public bool alarmIfToolDiaDifferentThenHoleDia;
  public double SimAAxisDirection;
  public double SimYAxisDirection;
  public bool SimAddZAxisKinematicAndToolLength;
  public double ProfileStartAllowedNegativeDistance;
  public double ProfileEndAllowedPositiveDistance;
  public double ProfilePreviewRefDrawingThickness;
  public double ProfilePreviewRefDrawingExtraHeight;
  public double ProfileDrawingRefThickness;
  public double SimilasyonClamperOpenDistance;
  public bool SaveStlFileWhileCreatingCode;
  public bool SaveImageFileWhileCreatingCode;
  public bool SimulationCanStartFromRightProfile;
  public double ImageScaleFactor;
  public int SimulasyonGCodeWindowWidth;
  public int SimulasyonGCodeWindowHeight;
  public double MinSpindleSpeed;
  public string ClamperChar;
  public string PriorityChar;
  public double PlaneThickness;
  public string LongProfileMCode;
  public string BottomProfileMCode;
  public string LongBottomProfileMCode;
  public bool G91Mode;
  public static byte f00469F;
  public Color TreeItemColor;
  public Color TreeItemSelectedColor;
  public Color TreeOPColor;
  public Color TreeOPSelectedColor;
  public Color TreeOPWarningColor;
  public Color TreeOPErrorColor;
  public Color TreeOPInfoColor;
  public Color FreePlaneColor;
  public Color ProfileRefeanceColor;
  public Color OnlineDrawCamColor;
  public Color OnlineDrawContourColor;
  public Color OperationSelectedColor;
  public Color OperationDisableColor;
  public double OnlineDrawThickness;
  public int ProfileRefeanceTranparentLeft;
  public int ProfileRefeanceTranparentBottom;
  public int ProfileRefeanceTranparentBack;
  public double TreeItemFontSize;
  public double TreeOPFontSize;
  public string TreeItemFontName;
  public string TreeOPFontName;
  public string TreeMessageFontName;
  public static byte f0046B6;
  public ShapeRuntimeData ShapeDataParameters;
  public camParameters5 CamParNotch;
  public ProfileMirror MirrorData;
  public buEyeBaseVer5.Apps.ProfileArray ArrayData;
  public AnalyseEntitiesSetting AnalyseSettings;
  public bool MultiplyProfileEnable;
  public bool MultiplyProfileMirror;
  public int MultiplyProfileCount;
  public double MultiplyProfileSpace;
  public double NewProfileWidth;
  public double NewProfileHeight;
  public double NewProfileThickness;
  public double FreeDrawOrjinalWidth;
  public double FreeDrawOrjinalHeight;
  public int SimStep;
  public double ClamperMoveStep;
  public int DrawingeLayerIndex;
  public int OperationWireframeLayerIndex;
  public int AuxLayerIndex;
  public int SupportBlockLayerIndex;
  public int OperationPlaneLayerIndex;
  public int CamLayerIndex;
  public int OperationSolidLayerIndex;
  public int ProfileLayerIndex;
  public double PatternCopyDistance;
  public double PatternCopyCutSpace;
  public int PatternCopyCount;
  public bool PatternShowSeperators;
  public bool TemplateScaleXEnable;
  public bool TemplateScaleYZEnable;
  public bool JobListDeleteLoaded;
  public bool SelectMode;
  public bool SelectModeSim;
  public double TemplateOffset;
  public double ProfileLength;
  public double SupportBlockZHeight;
  public double SupportBlockY1Height;
  public double SupportBlockY2Height;
  public double SupportBlockZWidth;
  public double SupportBlockY1Width;
  public double SupportBlockY2Width;
  public ProfileNewType ProfileType;
  public string pathProfiles;
  public string pathSaveProfiles;
  public string pathPlanes;
  public string pathDepths;
  public string pathClampers;
  public string pathOperationFromFile;
  public string pathOperationFromFileList;
  public string pathNCXFiles;
  public string pathJobList;
  public string pathMacro;
  public string path3DFiles;
  public string LastLoadedProfileName;
  public string LastSavedProfileJobName;
  public ProfileMacroOpenSave MacroSaveOpen;
  public buEyeBaseVer5.Apps.ProfileOperationData OPData;
  public double selectedFreePlaneLength;
  public bool TextureEnable;

  public MarbleTempVars()
  {
    ((MarbleJob) this).SupportBlockEnable = false;
    ((MarbleJob) this).SupportBlockZWidth = 0.0;
    ((MarbleJob) this).SupportBlockZHeight = 0.0;
    ((MarbleJob) this).SupportBlockZLength = 0.0;
    ((MarbleJob) this).SupportBlockY1FrontWidth = 0.0;
    ((MarbleJob) this).SupportBlockY1FrontHeight = 0.0;
    ((MarbleJob) this).SupportBlockY1FrontLength = 0.0;
    ((MarbleJob) this).SupportBlockY2BackWidth = 0.0;
    ((MarbleJob) this).SupportBlockY2BackHeight = 0.0;
    ((MarbleJob) this).SupportBlockY2BackLength = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
