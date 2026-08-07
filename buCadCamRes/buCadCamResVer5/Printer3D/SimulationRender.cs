// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Printer3D.SimulationRender
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using devDept;
using devDept.Eyeshot.Entities;

#nullable disable
namespace buCadCamResVer5.Printer3D;

public class SimulationRender : WorkUnit
{
  private readonly Simulation simulation;
  private readonly int fromLayer;
  private readonly int toLayer;

  public Mesh ContourMesh { get; private set; }

  public Mesh HatchingMesh { get; private set; }

  public bool HasContour => this.ContourMesh != null;

  public bool HasHatching => this.HatchingMesh != null;

  public SimulationRender(Simulation simulation, int fromLayer, int toLayer)
  {
    this.simulation = simulation;
    this.fromLayer = fromLayer;
    this.toLayer = toLayer;
  }

  public SimulationRender(Simulation simulation)
    : this(simulation, 0, int.MaxValue)
  {
  }
}
