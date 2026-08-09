using System.Runtime.CompilerServices;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Printer3D;

public class Simulation : WorkUnit
{
	private readonly Slicing slicing;

	private readonly bool computeInfill;

	[CompilerGenerated]
	private Mesh[][] mesh_0;

	[CompilerGenerated]
	private Mesh[][] mesh_1;

	private readonly double double_0 = Utility.DegToRad(30.0);

	private readonly double NozzleDiameter;

	private readonly double NozzleDiameter;

	public Mesh[][] HatchingMesh
	{
		[CompilerGenerated]
		get
		{
			return mesh_0;
		}
		[CompilerGenerated]
		private set
		{
			mesh_0 = value;
		}
	}

	public Mesh[][] SimulationMesh
	{
		[CompilerGenerated]
		get
		{
			return mesh_1;
		}
		[CompilerGenerated]
		private set
		{
			mesh_1 = value;
		}
	}

	public int NumMeshes => slicing.NumMeshes;

	public int NumLayers => slicing.NumSlices;

	public bool HasSimulation(int iM, int iL)
	{
		return SimulationMesh[iM] != null && SimulationMesh[iM][iL] != null;
	}

	public bool HasHatching(int iM, int iL)
	{
		return HatchingMesh[iM] != null && HatchingMesh[iM][iL] != null;
	}

	public Simulation(Slicing slicing, bool computeInfill = true, double NozzleDiameter = 0.0)
	{
		this.slicing = slicing;
		this.computeInfill = computeInfill;
		HatchingMesh = new Mesh[this.slicing.NumMeshes][];
		SimulationMesh = new Mesh[this.slicing.NumMeshes][];
		if (NozzleDiameter != 0.0)
		{
			this.NozzleDiameter = NozzleDiameter;
			this.NozzleDiameter = NozzleDiameter;
		}
		else
		{
			this.NozzleDiameter = 0.01 * this.slicing.BaseDiagonal;
			this.NozzleDiameter = 0.8 * this.NozzleDiameter;
		}
	}
}
