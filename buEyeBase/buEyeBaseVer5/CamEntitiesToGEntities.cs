// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.CamEntitiesToGEntities
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class CamEntitiesToGEntities : buSerilization5
{
  public int NumberofAxis;
  public int CamID;
  public string FourthAxis;
  public CamMode Mode;
  public ClockDirectionType Direction;
  public CamWireFrameType CamWireframeType;
  public CamTriangularMeshType CamTriMeshType;
  public CamTriangularMesh5AxType CamTriMesh5AXType;
  public CamSurfaceType CamSurfType;

  static CamEntitiesToGEntities() => MWCalculationOptions.Captions = new List<string>();

  public CamEntitiesToGEntities()
  {
    ((MWCalculationOptions) this).Enable = false;
    ((MWCalculationOptions) this).TangentAngle = 90.0;
    ((MWCalculationOptions) this).LeadType = LeadInOutType.Arc;
    ((MWCalculationOptions) this).ArcRadius = 10.0;
    ((MWCalculationOptions) this).ArcSweepAngle = 90.0;
    ((MWCalculationOptions) this).Length = 10.0;
    ((MWCalculationOptions) this).ExtendLength = 0.0;
    ((MWCalculationOptions) this).ClockDir = ClockDirectionType.CW;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
