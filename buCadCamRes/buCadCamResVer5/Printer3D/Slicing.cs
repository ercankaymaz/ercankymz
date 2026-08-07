// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Printer3D.Slicing
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buEyeBaseVer5.Apps;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections.Generic;

#nullable disable
namespace buCadCamResVer5.Printer3D;

public class Slicing : WorkUnit
{
  private readonly bool simplify;
  private readonly bool computeInfill;
  private readonly Point3D point3D_0;
  private readonly Point3D point3D_1;
  private readonly Size3D size3D_0;

  public Mesh[] TessellatedMeshes { get; }

  public int NumSlices { get; }

  public double BaseDiagonal { get; }

  public double ActualOffset { get; private set; }

  public Plane[][] PlaneByMeshByLayer { get; private set; }

  public Entity[][] SectionsByMesh { get; private set; }

  public Entity[][][] SectionsByMeshByLayer { get; private set; }

  public Entity[][] OffsetSectionsByMesh { get; private set; }

  public Entity[][][] OffsetSectionsByMeshByLayer { get; private set; }

  public Entity[][][] CuttingRegionByMeshByLayer { get; private set; }

  public Line[][] HatchingByMesh { get; private set; }

  public Line[][][] HatchingByMeshByLayer { get; private set; }

  public int NumMeshes => this.TessellatedMeshes.Length;

  public bool HasSlices(int iM)
  {
    return this.SectionsByMesh[iM] != null && this.SectionsByMesh[iM].Length != 0;
  }

  public bool HasOffsetSlices(int iM)
  {
    return this.OffsetSectionsByMesh[iM] != null && this.OffsetSectionsByMesh[iM].Length != 0;
  }

  public bool HasHatching(int iM)
  {
    return this.HatchingByMesh[iM] != null && this.HatchingByMesh[iM].Length != 0;
  }

  public Slicing(
    Mesh[] mesh,
    int numSlices,
    int inflateFactor = 0,
    bool simplify = true,
    bool computeInfill = true)
  {
    this.TessellatedMeshes = new Mesh[mesh.Length];
    for (int index = 0; index < mesh.Length; ++index)
      this.TessellatedMeshes[index] = (Mesh) mesh[index].Clone();
    this.computeInfill = computeInfill;
    this.simplify = simplify;
    List<Point3D> pointList = new List<Point3D>();
    foreach (Mesh tessellatedMesh in this.TessellatedMeshes)
      pointList.AddRange((IEnumerable<Point3D>) tessellatedMesh.Vertices);
    Utility.BoundingBox((IList<Point3D>) pointList, out this.point3D_0, out this.point3D_1);
    this.size3D_0 = new Size3D(this.point3D_0, this.point3D_1);
    this.BaseDiagonal = Point2D.Distance(new Point2D(this.point3D_0.X, this.point3D_0.Y), new Point2D(this.point3D_1.X, this.point3D_1.Y));
    this.NumSlices = numSlices;
    this.ActualOffset = buPrinter3D.varPrinter3DSettings.OffsetXY;
    this.SectionsByMesh = new Entity[this.TessellatedMeshes.Length][];
    this.SectionsByMeshByLayer = new Entity[this.TessellatedMeshes.Length][][];
    this.OffsetSectionsByMesh = new Entity[this.TessellatedMeshes.Length][];
    this.OffsetSectionsByMeshByLayer = new Entity[this.TessellatedMeshes.Length][][];
    this.HatchingByMesh = new Line[this.TessellatedMeshes.Length][];
    this.HatchingByMeshByLayer = new Line[this.TessellatedMeshes.Length][][];
    this.PlaneByMeshByLayer = new Plane[this.TessellatedMeshes.Length][];
    this.CuttingRegionByMeshByLayer = new Entity[this.TessellatedMeshes.Length][][];
  }
}
