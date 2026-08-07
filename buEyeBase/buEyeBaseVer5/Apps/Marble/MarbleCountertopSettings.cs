// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleCountertopSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleCountertopSettings : buSerilization5
{
  public static int CountertopItemindex;
  public static int EdgeIndex;
  public static int EdgeInsideItemIndex;
  public static string EdgeOutsideInside;
  public static int CornerIndex;
  public static int VacuumIndex;
  public static bool VacuumEnable;
  public static bool DrawIsArc;
  public static bool DrawIsInside;
  public static byte f004959;
  public string WoodTextureName;
  public string MarbleTextureName;
  public bool SnapEnable;
  public bool ShowGridCNC;
  public bool RotateCameraCNC;
  public bool ShowGridCadCam;
  public bool RotateCameraCadCam;
  public double GridStep;
  public double ManuelMove;
  public double ManuelRotate;
  public double HorizontalLenght;
  public double VerticalLenght;
  public double TextWireframeHeight;
  public string TextWireframeString;
  public string pathItems;
  public string pathFromFileMilling5Axis;
  public string pathFromFileEngraving;
  public string pathFromFileSawMilling;
  public string pathFromFileProfiling;
  public string pathFromFileProfileCurve;
  public string pathFromFileContour;
  public string pathFromFileSweep;
  public string pathFromFileSweepForm;
  public string pathFromFileLibray;
  public string pathFromFileLathe;
  public string pathFromFileColumns;
  public string pathFromFileDrill;
  public string pathFromPhoto;
  public string pathFromSheet;
  public string pathExternalGCode;
  public string pathGCode;
  public string pathImportImage;
  public string pathTextFile;
  public string pathTools;
  public string pathJob;
  public string pathG54;
  public string pathMaterialMeasure;
  public string pathParks;
  public string pathEasyDraw;
  public string fileWood;
  public string fileMarble;
  public string textFontDrawing;
  public string textWireframeDrawing;
  public bool FromFileKeepRatio;
  public bool ShowAllDrawing;
  public bool Text3D;
  public double CameraBaseXPosition;
  public double CameraBaseYPosition;
  public double CameraFirstXPosition;
  public double CameraFirstYPosition;
  public double CameraFirstMaterial;
  public double CameraSecondXPosition;
  public double CameraSecondYPosition;
  public double CameraSecondMaterial;
  public double LathePartLength;
  public double DrillXPosition;
  public double DrillYPosition;
  public double DrillZPosition;
  public double DrillDiameter;
  public double DrillDepth;

  public MarbleCountertopSettings()
  {
    ((MarbleRuntimeSettings) this).Distance = 100.0;
    ((MarbleRuntimeSettings) this).CutSpace = 2.0;
    ((MarbleRuntimeSettings) this).Count = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleCountertopSettings(double distance, double cutspace, int count)
  {
    ((MarbleRuntimeSettings) this).Distance = 100.0;
    ((MarbleRuntimeSettings) this).CutSpace = 2.0;
    ((MarbleRuntimeSettings) this).Count = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MarbleRuntimeSettings) this).Distance = distance;
    ((MarbleRuntimeSettings) this).CutSpace = cutspace;
    ((MarbleRuntimeSettings) this).Count = count;
  }
}
