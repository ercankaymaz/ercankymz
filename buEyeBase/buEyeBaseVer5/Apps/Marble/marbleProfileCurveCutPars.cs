// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleProfileCurveCutPars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.PanelCut;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleProfileCurveCutPars : buSerilization5
{
  public MarbleCorners HorVerHorCornerType;
  public MarbleCorners HorVerVerCornerType;
  public MarbleCorners HorCornerType;
  public MarbleCorners VerCornerType;
  public marbleMenuType selectedContour;
  public marbleMenuType selectedProfile;
  public marbleMenuType selectedProfileCurve;
  public marbleMenuType selectedLibrary;
  public marbleMenuType selectedText;
  public marbleMenuType selectedSweep;
  public marbleMenuType selectedDrill;
  public marbleMenuType selectedDrawing;
  public marbleMenuType selectedColumns;
  public marbleMenuType selectedLathe;
  public marbleMenuType selectedLathePerpendicular;
  public marbleMenuType selectedEngraving;
  public marbleMenuType selectedType;
  public marbleMenuType selectedSawMilling;
  public marbleMenuType selectedMilling5Axis;
  public static byte f004A5A;
  public double ContourDeviationResolution;
  public double LatheDeviationResolution;
  public double ColumnsDeviationResolution;
  public double EngravingDeviationResolution;
  public double ProfileDeviationResolution;
  public double SweepDeviationResolution;
  public double SolidDeviationResolution;
  public Color DimensionColor;
  public double DimensionThickness;
  public double DimensionTextHeight;
  public static List<string> Captions;
  public static byte f004A66;
  public MarbleScreenCaptureSettings ScreenCapture;
  public int MarbleMaterialTransparan;
  public string DxfCuttingLayerName;
  public string DxfMillingDrillLayer;
  public bool MotionMode;
  public bool TouchPad;
  public int CameraExposure;
  public int CameraCropX;
  public int CameraCropY;
  public int CameraCropWidth;
  public int CameraCropHeight;
  public bool CopyImageToArchive;
  public double ImageZPosition;
  public double ImageRotateAngle;
  public double CameraImageOffsetX;
  public double CameraImageOffsetY;
  public double CameraImagedX;
  public double CameraImagedY;
  public double CameraImageWidth;
  public double CameraImageHeight;
  public double CameraPixelMMCalibX;
  public double CameraPixelMMCalibY;
  public int CameraWaitTick;
  public double CameraLensXRatio;
  public double CameraLensYRatio;
  public bool UseCameraImageThicknessList;
  public bool AutoLensCalibrationFromMaterialHeight;
  public bool DontAddExtensionEntities;
  public bool OutsideEntityIsReferance;
  public bool EngraveOnlineCamCalculation;
  public bool TextOnlineCamCalculation;
  public bool ProfileOnlineCamCalculation;
  public bool ContourOnlineCamCalculation;
  public bool DrillOnlineCamCalculation;
  public bool SliceOnlineCamCalculation;
  public bool SweepOnlineCamCalculation;
  public bool CavityOnlineCamCalculation;
  public bool ColumnsOnlineCamCalculation;
  public bool LatheOnlineCamCalculation;
  public bool SliceListClearAfterFinished;
  public bool StartSpindleBeforePlunge;
  public bool StartWaterBeforePlunge;
  public bool ShowMaterialLimits;
  public bool IntersectionEnable;
  public bool MaterialBorderControl;
  public bool AutoMagnet;
  public bool MagnetPart;
  public double GridStep;
  public double EntityCatchDistance;
  public int GridMajorCount;
  public bool GridLight;
  public int SpindleTrackPlusMinusStep;
  public int SpindleTrackMinVal;

  public marbleProfileCurveCutPars()
  {
    ((MarbleRuntimeSettings) this).Panel = (Rectangle2D) new AnalyseEntitiesResultError();
    ((MarbleRuntimeSettings) this).PartID = -1;
    ((MarbleRuntimeSettings) this).Count = 0;
    ((MarbleRuntimeSettings) this).Name = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleProfileCurveCutPars(PanelDonePart data)
  {
    ((MarbleRuntimeSettings) this).Panel = (Rectangle2D) new AnalyseEntitiesResultError();
    ((MarbleRuntimeSettings) this).PartID = -1;
    ((MarbleRuntimeSettings) this).Count = 0;
    ((MarbleRuntimeSettings) this).Name = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public abstract void m001EED();

  public marbleProfileCurveCutPars()
  {
    ((MarbleRuntimeSettings) this).Panel = (Rectangle2D) new AnalyseEntitiesResultError();
    ((MarbleRuntimeSettings) this).NodeID = -1;
    ((MarbleRuntimeSettings) this).Count = 0;
    ((MarbleRuntimeSettings) this).Name = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleProfileCurveCutPars(PanelWaitAssembly data)
  {
    ((MarbleRuntimeSettings) this).Panel = (Rectangle2D) new AnalyseEntitiesResultError();
    ((MarbleRuntimeSettings) this).NodeID = -1;
    ((MarbleRuntimeSettings) this).Count = 0;
    ((MarbleRuntimeSettings) this).Name = "";
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
