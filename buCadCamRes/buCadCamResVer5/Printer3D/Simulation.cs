// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Printer3D.Simulation
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using devDept;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

#nullable disable
namespace buCadCamResVer5.Printer3D;

public class Simulation : WorkUnit
{
  private readonly Slicing slicing;
  private readonly bool computeInfill;
  private readonly double double_0 = Utility.DegToRad(30.0);
  private readonly double NozzleDiameter;
  private readonly double NozzleDiameter;

  public Mesh[][] HatchingMesh { get; private set; }

  public Mesh[][] SimulationMesh { get; private set; }

  public int NumMeshes => this.slicing.NumMeshes;

  public bool HasSimulation(int iM, int iL)
  {
    return this.SimulationMesh[iM] != null && this.SimulationMesh[iM][iL] != null;
  }

  public bool HasHatching(int iM, int iL)
  {
    return this.HatchingMesh[iM] != null && this.HatchingMesh[iM][iL] != null;
  }

  public int NumLayers => this.slicing.NumSlices;

  public Simulation(Slicing slicing, bool computeInfill = true, double NozzleDiameter = 0.0)
  {
    this.slicing = slicing;
    this.computeInfill = computeInfill;
    this.HatchingMesh = new Mesh[this.slicing.NumMeshes][];
    this.SimulationMesh = new Mesh[this.slicing.NumMeshes][];
    if (NozzleDiameter == 0.0)
    {
      this.NozzleDiameter = 0.01 * this.slicing.BaseDiagonal;
      this.NozzleDiameter = 0.8 * this.NozzleDiameter;
    }
    else
    {
      this.NozzleDiameter = NozzleDiameter;
      this.NozzleDiameter = NozzleDiameter;
    }
  }
}
