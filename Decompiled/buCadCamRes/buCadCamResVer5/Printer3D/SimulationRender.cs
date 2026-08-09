using System.Runtime.CompilerServices;
using devDept;
using devDept.Eyeshot.Entities;

namespace buCadCamResVer5.Printer3D;

public class SimulationRender : WorkUnit
{
	private readonly Simulation simulation;

	private readonly int fromLayer;

	private readonly int toLayer;

	[CompilerGenerated]
	private Mesh mesh_0;

	[CompilerGenerated]
	private Mesh mesh_1;

	public Mesh ContourMesh
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

	public Mesh HatchingMesh
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

	public bool HasContour => ContourMesh != null;

	public bool HasHatching => HatchingMesh != null;

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
