// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.buMarbleForms
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public class buMarbleForms
{
  public static int Cavity;
  public static int Angle;
  public static int CornerRectangle;
  public static int Pocket;
  public static int Slat;
  public static int Chamfer;
  public static int Edge;
  public static int CornerChamfer;
  public static int CornerRadius;
  public string Command;
  public int ItemID;
  public int EdgeIndex;
  public int EntityOutsideIndex;
  public int EntityInsideIndex;
  public int EntityInsideSubIndex;
  public string Info;
  public string Aux;
  public bool Result;
  public static byte f004FD9;
  public int IndexEntity;
  public int IndexEdge;
  public int ID;
  public int EdgeID;
  public int CamID;
  public int IndexInsideEntity;
  public int ItemID;
  public MarbleToolType ToolType;
  public MarbleCamType MarbleCamType;
  public MarbleCamMode MarbleCamMode;
  public CamType GeneralCamType;
  public double ZOffset;
  public double SafeDistance;
  public double RapidDistance;
  public double CuttingVel;
  public double PlungeVel;
  public double PlungeFirstVel;
  public double CuttingStep;
  public double CuttingFirstStep;
  public double TargetZ;
  public double MaterialThickness;
  public int ItemID;
  public int indexItem;
  public int indexCam;
  public int indexEdge;
  public int indexEdgeSub;
  public int indexCamList;
  public Point3D pntMin;
  public Point3D pntMax;
  public MarbleItem MI;
  public MarbleOperationSelectionCommand SelectionCommand;
  public List<MarbleSelectionItems> SelectionItems;
  public MarbleSelectionItems ActiveItem;
  public Point3D pntTotalMin;
  public Point3D pntTotalMax;
  public Pnt6D OffsetPoint;
  public string Name;
  public static byte f004FFF;
  public double PlungeSpeed;
  public double ForwardCutSpeed;
  public double BackwardSpeed;
  public double SafeDistance;
  public double RapidDistance;
  public bool ZigzagMode;
  public bool MoveUpSafe;
  public MarbleCamAreaMode RoughAreaMode;
  public bool isRough;
  public bool isFinish;
  public bool isOffset;
  public double PlungeSpeed;
  public double ForwardCutSpeed;
  public double BackwardCutSpeed;
  public double SafeDistanceZ;
  public double SafeDistanceXY;
  public double RapidDistance;
  public bool SplineEnable;
  public double Splinedt;
  public bool ZigzagMode;

  public static void Copy(
    MarbleScreenCaptureSettings Source,
    ref MarbleScreenCaptureSettings Target)
  {
    Target = (MarbleScreenCaptureSettings) new buMarbleControls(Source);
  }

  public override string ToString() => "";
}
