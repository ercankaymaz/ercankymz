using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

[DebuggerDisplay("Points[{Points.Count}] {_Material}")]
internal sealed class PointsPrimitiveBuilder<TMaterial, TvG, TvM, TvS> : PrimitiveBuilder<TMaterial, TvG, TvM, TvS> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	private readonly struct PointListWrapper<T>(IReadOnlyList<T> vertices) : IReadOnlyList<int>, IEnumerable<int>, IEnumerable, IReadOnlyCollection<int>
	{
		private readonly IReadOnlyList<T> _Vertices = vertices;

		public int this[int index] => index;

		public int Count => _Vertices.Count;

		public IEnumerator<int> GetEnumerator()
		{
			return Enumerable.Range(0, _Vertices.Count).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Enumerable.Range(0, _Vertices.Count).GetEnumerator();
		}
	}

	public override int VerticesPerPrimitive => 1;

	public override IReadOnlyList<int> Points => new PointListWrapper<VertexBuilder<TvG, TvM, TvS>>(base.Vertices);

	internal PointsPrimitiveBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TMaterial material)
		: base(mesh, material)
	{
	}

	internal override PrimitiveBuilder<TMaterial, TvG, TvM, TvS> Clone(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TMaterial material)
	{
		return new PointsPrimitiveBuilder<TMaterial, TvG, TvM, TvS>(mesh, this, material);
	}

	private PointsPrimitiveBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, PointsPrimitiveBuilder<TMaterial, TvG, TvM, TvS> other, TMaterial material)
		: base(mesh, (PrimitiveBuilder<TMaterial, TvG, TvM, TvS>)other, material)
	{
	}

	public override int AddPoint(VertexBuilder<TvG, TvM, TvS> a)
	{
		if (base.Mesh.VertexPreprocessor != null && !base.Mesh.VertexPreprocessor.PreprocessVertex(ref a))
		{
			return -1;
		}
		return UseVertex(in a);
	}

	public override IReadOnlyList<int> GetIndices()
	{
		return Array.Empty<int>();
	}
}
