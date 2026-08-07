// Decompiled with JetBrains decompiler
// Type: buMW.Variables.buMWDiamalerVars
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using ModuleWorks;
using ModuleWorks.Graphics;
using ModuleWorks.Graphics.OpenGL;
using System.Collections.Generic;

#nullable disable
namespace buMW.Variables;

public class buMWDiamalerVars
{
  public int CutSimStep;
  public int CutSimCount;
  public static byte f000096;
  public static GeoLib varMWDiemakerCamMeshRoughPars;
  public static camParameters5 varbuDiemakerCamMeshRoughPars;
  public static GeoLib varMWDiemakerCamMeshParalelPars;
  public static camParameters5 varbuDiemakerCamMeshParallelPars;
  public static GeoLib varMWDiemakerCamMeshContantZPars;
  public static camParameters5 varbuDiemakerCamMeshConstantZPars;
  public static GeoLib varMWDiemakerCamMeshPencilPars;
  public static camParameters5 varbuDiemakerCamMeshPencilPars;
  public static GeoLib varMWDiemakerCamMeshProjectionPars;
  public static camParameters5 varbuDiemakerCamMeshProjectionPars;
  public static GeoLib varMWDiemakerCamMeshFlatlandPars;
  public static camParameters5 varbuDiemakerCamMeshFlatlandsPars;
  public static GeoLib varMWDiemakerCamMeshContantCuspPars;
  public static camParameters5 varbuDiemakerCamMeshConstantCuspPars;
  public static GeoLib varMWDiemakerCamWFPocketPars;
  public static camParameters5 varbuDiemakerCamWFPocketPars;
  public static GeoLib varMWDiemakerCamWFContourPars;
  public static camParameters5 varbuDiemakerCamWFContourPars;
  public static GeoLib varMWDiemakerCamWFContour4XPars;
  public static camParameters5 varbuDiemakerCamWFContour4XPars;
  public static GeoLib varMWDiemakerCamDrillPars;

  public buMWDiamalerVars()
  {
    ((buMwCutSim) this).RenderD = (AsyncRenderer) new AsyncVBORenderer();
    ((buMwCutSim) this).Verify = (Verification) null;
    ((buMwCutSim) this).MoveID = 1;
    this.CutSimStep = 10;
    this.CutSimCount = 0;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  static buMWDiamalerVars()
  {
    buMwCutSim.CutSimTri = new List<List<Triangle3D>>();
    buMwCutSim.ListTRi = new List<Triangle3D>();
  }
}
