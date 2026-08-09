using System.Collections.Generic;
using System.Diagnostics;
using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

public class HitVertex
{
	public Point3D Vertex;

	public List<BlockReference> Parents;

	public int EntityIndex;

	public int FaceIndex;

	public int ShellOrElementIndex;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzJcz3BovM8rB1E0il0g_003D_003D;

	public int VertexIndex
	{
		get
		{
			return _0023_003DzJcz3BovM8rB1E0il0g_003D_003D;
		}
		set
		{
			_0023_003DzJcz3BovM8rB1E0il0g_003D_003D = value;
			Parents = null;
			EntityIndex = -1;
		}
	}

	public HitVertex()
	{
		FaceIndex = -1;
		ShellOrElementIndex = -1;
		EntityIndex = -1;
	}

	internal HitVertex(Point3D _0023_003DzkEYxO1SuR1Kw, int _0023_003DzcJpaJQAcgoDn, int _0023_003Dzfe2zeQMumw_4, int _0023_003DzoyRKt52KZ28N, int _0023_003Dz7xzxLVk_003D, List<BlockReference> _0023_003Dzq5nwX2I_003D)
		: this()
	{
		Vertex = _0023_003DzkEYxO1SuR1Kw;
		VertexIndex = _0023_003DzcJpaJQAcgoDn;
		FaceIndex = _0023_003Dzfe2zeQMumw_4;
		ShellOrElementIndex = _0023_003DzoyRKt52KZ28N;
		EntityIndex = _0023_003Dz7xzxLVk_003D;
		Parents = _0023_003Dzq5nwX2I_003D;
	}
}
