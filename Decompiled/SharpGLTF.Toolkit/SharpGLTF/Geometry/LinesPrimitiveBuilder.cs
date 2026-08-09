using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

[DebuggerDisplay("Lines[{Lines.Count}] {_Material}")]
internal sealed class LinesPrimitiveBuilder<TMaterial, TvG, TvM, TvS> : PrimitiveBuilder<TMaterial, TvG, TvM, TvS> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	private readonly List<(int A, int B)> _Indices = new List<(int, int)>();

	public override int VerticesPerPrimitive => 2;

	public override IReadOnlyList<(int A, int B)> Lines => _Indices;

	internal LinesPrimitiveBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TMaterial material)
		: base(mesh, material)
	{
	}

	internal override PrimitiveBuilder<TMaterial, TvG, TvM, TvS> Clone(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TMaterial material)
	{
		return new LinesPrimitiveBuilder<TMaterial, TvG, TvM, TvS>(mesh, this, material);
	}

	private LinesPrimitiveBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, LinesPrimitiveBuilder<TMaterial, TvG, TvM, TvS> other, TMaterial material)
		: base(mesh, (PrimitiveBuilder<TMaterial, TvG, TvM, TvS>)other, material)
	{
		_Indices.AddRange(other._Indices);
	}

	public override (int A, int B) AddLine(VertexBuilder<TvG, TvM, TvS> a, VertexBuilder<TvG, TvM, TvS> b)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		if (base.Mesh.VertexPreprocessor != null)
		{
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref a))
			{
				return (A: -1, B: -1);
			}
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref b))
			{
				return (A: -1, B: -1);
			}
		}
		if (a.Position == b.Position)
		{
			return (A: -1, B: -1);
		}
		int item = UseVertex(in a);
		int item2 = UseVertex(in b);
		_Indices.Add((item, item2));
		return (A: item, B: item2);
	}

	public override IReadOnlyList<int> GetIndices()
	{
		return _Indices.SelectMany(((int A, int B) item) => new int[2] { item.A, item.B }).ToList();
	}
}
