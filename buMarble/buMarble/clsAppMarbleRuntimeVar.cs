// Decompiled with JetBrains decompiler
// Type: buMarble.clsAppMarbleRuntimeVar
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buEyeBaseVer5;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace buMarble;

[Serializable]
public class clsAppMarbleRuntimeVar : buSerilization5
{
  public static ImageList IC32;
  public bool isMainTab;
  public bool isSingleTab;
  public bool isHorizontalTab;
  public bool isVerticalTab;
  public bool isDryRunActivated;
  public bool isHorizontalVerticalTab;
  public bool isWarmUpVisible;
  public bool isMaintanenceVisible;
  public bool SpindleDown;
  public bool WarmUpMillingDone;
  public bool PointerArcMode;
  public bool WarmUpSawDone;
  public bool VacuumNotAllowDown;
  public bool APositiveMoveNotAllow;
  public bool OnlineSimulationAllow;
  public bool SpindleDiameterTooBigForMoveUp;
  public bool ZLimitControlDisable;
  public double G54ExtraOffsetX;
  public double G54ExtraOffsetY;
  public int AxX;
  public int AxY;
  public int AxZ;
  public int AxC;
  public int AxA;
  public int AxX2;
  public int AxY2;
  public int AxZ2;
  public int AxC2;
  public int AxA2;
  public int MaterialIndex;
  public int MarbleWarningCount;
  public int OperationIndex;
  public double MaterialMeasuredThickness;
  public Point3D pntG54Offset;
  public List<int> SimMovePartIndex;

  public clsAppMarbleRuntimeVar()
  {
  }

  public clsAppMarbleRuntimeVar()
  {
    ((clsAppMarbleOPVar) this).pntSim = new Pnt6DSimMove();
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }
}
