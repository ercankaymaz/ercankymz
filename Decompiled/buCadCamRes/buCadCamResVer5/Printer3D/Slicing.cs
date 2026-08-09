using System.Collections.Generic;
using System.Runtime.CompilerServices;
using buEyeBaseVer5.Apps;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Printer3D;

public class Slicing : WorkUnit
{
	[CompilerGenerated]
	private readonly Mesh[] mesh_0;

	[CompilerGenerated]
	private readonly int numSlices;

	private readonly bool simplify;

	private readonly bool computeInfill;

	private readonly Point3D point3D_0;

	private readonly Point3D point3D_1;

	private readonly Size3D size3D_0;

	[CompilerGenerated]
	private readonly double double_0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private Plane[][] plane_0;

	[CompilerGenerated]
	private Entity[][] entity_0;

	[CompilerGenerated]
	private Entity[][][] entity_1;

	[CompilerGenerated]
	private Entity[][] entity_2;

	[CompilerGenerated]
	private Entity[][][] entity_3;

	[CompilerGenerated]
	private Entity[][][] entity_4;

	[CompilerGenerated]
	private Line[][] line_0;

	[CompilerGenerated]
	private Line[][][] line_1;

	public Mesh[] TessellatedMeshes
	{
		[CompilerGenerated]
		get
		{
			return mesh_0;
		}
	}

	public int NumSlices
	{
		[CompilerGenerated]
		get
		{
			return numSlices;
		}
	}

	public double BaseDiagonal
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
	}

	public double ActualOffset
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		private set
		{
			double_1 = value;
		}
	}

	public Plane[][] PlaneByMeshByLayer
	{
		[CompilerGenerated]
		get
		{
			return plane_0;
		}
		[CompilerGenerated]
		private set
		{
			plane_0 = value;
		}
	}

	public Entity[][] SectionsByMesh
	{
		[CompilerGenerated]
		get
		{
			return entity_0;
		}
		[CompilerGenerated]
		private set
		{
			entity_0 = value;
		}
	}

	public Entity[][][] SectionsByMeshByLayer
	{
		[CompilerGenerated]
		get
		{
			return entity_1;
		}
		[CompilerGenerated]
		private set
		{
			entity_1 = value;
		}
	}

	public Entity[][] OffsetSectionsByMesh
	{
		[CompilerGenerated]
		get
		{
			return entity_2;
		}
		[CompilerGenerated]
		private set
		{
			entity_2 = value;
		}
	}

	public Entity[][][] OffsetSectionsByMeshByLayer
	{
		[CompilerGenerated]
		get
		{
			return entity_3;
		}
		[CompilerGenerated]
		private set
		{
			entity_3 = value;
		}
	}

	public Entity[][][] CuttingRegionByMeshByLayer
	{
		[CompilerGenerated]
		get
		{
			return entity_4;
		}
		[CompilerGenerated]
		private set
		{
			entity_4 = value;
		}
	}

	public Line[][] HatchingByMesh
	{
		[CompilerGenerated]
		get
		{
			return line_0;
		}
		[CompilerGenerated]
		private set
		{
			line_0 = value;
		}
	}

	public Line[][][] HatchingByMeshByLayer
	{
		[CompilerGenerated]
		get
		{
			return line_1;
		}
		[CompilerGenerated]
		private set
		{
			line_1 = value;
		}
	}

	public int NumMeshes => TessellatedMeshes.Length;

	public bool HasSlices(int iM)
	{
		return SectionsByMesh[iM] != null && SectionsByMesh[iM].Length != 0;
	}

	public bool HasOffsetSlices(int iM)
	{
		return OffsetSectionsByMesh[iM] != null && OffsetSectionsByMesh[iM].Length != 0;
	}

	public bool HasHatching(int iM)
	{
		return HatchingByMesh[iM] != null && HatchingByMesh[iM].Length != 0;
	}

	public Slicing(Mesh[] mesh, int numSlices, int inflateFactor = 0, bool simplify = true, bool computeInfill = true)
	{
		mesh_0 = new Mesh[mesh.Length];
		for (int i = 0; i < mesh.Length; i++)
		{
			TessellatedMeshes[i] = (Mesh)mesh[i].Clone();
		}
		this.computeInfill = computeInfill;
		this.simplify = simplify;
		List<Point3D> list = new List<Point3D>();
		Mesh[] tessellatedMeshes = TessellatedMeshes;
		foreach (Mesh mesh2 in tessellatedMeshes)
		{
			list.AddRange(mesh2.Vertices);
		}
		Utility.BoundingBox(list, out point3D_0, out point3D_1);
		size3D_0 = new Size3D(point3D_0, point3D_1);
		double_0 = Point2D.Distance(new Point2D(point3D_0.X, point3D_0.Y), new Point2D(point3D_1.X, point3D_1.Y));
		this.numSlices = numSlices;
		ActualOffset = buPrinter3D.varPrinter3DSettings.OffsetXY;
		SectionsByMesh = new Entity[TessellatedMeshes.Length][];
		SectionsByMeshByLayer = new Entity[TessellatedMeshes.Length][][];
		OffsetSectionsByMesh = new Entity[TessellatedMeshes.Length][];
		OffsetSectionsByMeshByLayer = new Entity[TessellatedMeshes.Length][][];
		HatchingByMesh = new Line[TessellatedMeshes.Length][];
		HatchingByMeshByLayer = new Line[TessellatedMeshes.Length][][];
		PlaneByMeshByLayer = new Plane[TessellatedMeshes.Length][];
		CuttingRegionByMeshByLayer = new Entity[TessellatedMeshes.Length][][];
	}
}
