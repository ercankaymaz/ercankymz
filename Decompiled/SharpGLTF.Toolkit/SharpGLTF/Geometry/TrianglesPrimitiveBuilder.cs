using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

[DebuggerDisplay("Triangles[{Triangles.Count}] {_Material}")]
internal sealed class TrianglesPrimitiveBuilder<TMaterial, TvG, TvM, TvS> : PrimitiveBuilder<TMaterial, TvG, TvM, TvS> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	private readonly struct TriangleList(IReadOnlyList<(int, int, int)> tris, IReadOnlyList<(int, int, int, int)> quads) : IReadOnlyList<(int A, int B, int C)>, IEnumerable<(int A, int B, int C)>, IEnumerable, IReadOnlyCollection<(int A, int B, int C)>
	{
		private readonly IReadOnlyList<(int A, int B, int C)> _Tris = tris;

		private readonly IReadOnlyList<(int A, int B, int C, int D)> _Quads = quads;

		public int Count => _Tris.Count + _Quads.Count * 2;

		public (int A, int B, int C) this[int index]
		{
			get
			{
				if (index < _Tris.Count)
				{
					return _Tris[index];
				}
				index -= _Tris.Count;
				(int, int, int, int) tuple = _Quads[index / 2];
				if ((index & 1) != 0)
				{
					return (A: tuple.Item1, B: tuple.Item3, C: tuple.Item4);
				}
				return (A: tuple.Item1, B: tuple.Item2, C: tuple.Item3);
			}
		}

		public IEnumerator<(int A, int B, int C)> GetEnumerator()
		{
			int c = Count;
			int i = 0;
			while (i < c)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			int c = Count;
			int i = 0;
			while (i < c)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}
	}

	private readonly struct SurfaceList(IReadOnlyList<(int, int, int)> tris, IReadOnlyList<(int, int, int, int)> quads) : IReadOnlyList<(int A, int B, int C, int? D)>, IEnumerable<(int A, int B, int C, int? D)>, IEnumerable, IReadOnlyCollection<(int A, int B, int C, int? D)>
	{
		private readonly IReadOnlyList<(int A, int B, int C)> _Tris = tris;

		private readonly IReadOnlyList<(int A, int B, int C, int D)> _Quads = quads;

		public int Count => _Tris.Count + _Quads.Count;

		public (int A, int B, int C, int? D) this[int index]
		{
			get
			{
				if (index < _Tris.Count)
				{
					(int, int, int) tuple = _Tris[index];
					return (A: tuple.Item1, B: tuple.Item2, C: tuple.Item3, D: null);
				}
				index -= _Tris.Count;
				(int, int, int, int) tuple2 = _Quads[index];
				return (A: tuple2.Item1, B: tuple2.Item2, C: tuple2.Item3, D: tuple2.Item4);
			}
		}

		public IEnumerator<(int A, int B, int C, int? D)> GetEnumerator()
		{
			int c = Count;
			int i = 0;
			while (i < c)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			int c = Count;
			int i = 0;
			while (i < c)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}
	}

	private readonly List<(int A, int B, int C)> _TriIndices = new List<(int, int, int)>();

	private readonly List<(int A, int B, int C, int D)> _QuadIndices = new List<(int, int, int, int)>();

	public override int VerticesPerPrimitive => 3;

	public override IReadOnlyList<(int A, int B, int C)> Triangles => new TriangleList(_TriIndices, _QuadIndices);

	public override IReadOnlyList<(int A, int B, int C, int? D)> Surfaces => new SurfaceList(_TriIndices, _QuadIndices);

	internal TrianglesPrimitiveBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TMaterial material)
		: base(mesh, material)
	{
	}

	internal override PrimitiveBuilder<TMaterial, TvG, TvM, TvS> Clone(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TMaterial material)
	{
		return new TrianglesPrimitiveBuilder<TMaterial, TvG, TvM, TvS>(mesh, this, material);
	}

	private TrianglesPrimitiveBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TrianglesPrimitiveBuilder<TMaterial, TvG, TvM, TvS> other, TMaterial material)
		: base(mesh, (PrimitiveBuilder<TMaterial, TvG, TvM, TvS>)other, material)
	{
		_TriIndices.AddRange(other._TriIndices);
		_QuadIndices.AddRange(other._QuadIndices);
	}

	public override (int A, int B, int C) AddTriangle(VertexBuilder<TvG, TvM, TvS> a, VertexBuilder<TvG, TvM, TvS> b, VertexBuilder<TvG, TvM, TvS> c)
	{
		if (base.Mesh.VertexPreprocessor != null)
		{
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref a))
			{
				return (A: -1, B: -1, C: -1);
			}
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref b))
			{
				return (A: -1, B: -1, C: -1);
			}
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref c))
			{
				return (A: -1, B: -1, C: -1);
			}
		}
		return _AddTriangle(in a, in b, in c);
	}

	public override (int A, int B, int C, int D) AddQuadrangle(VertexBuilder<TvG, TvM, TvS> a, VertexBuilder<TvG, TvM, TvS> b, VertexBuilder<TvG, TvM, TvS> c, VertexBuilder<TvG, TvM, TvS> d)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		if (base.Mesh.VertexPreprocessor != null)
		{
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref a))
			{
				return (A: -1, B: -1, C: -1, D: -1);
			}
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref b))
			{
				return (A: -1, B: -1, C: -1, D: -1);
			}
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref c))
			{
				return (A: -1, B: -1, C: -1, D: -1);
			}
			if (!base.Mesh.VertexPreprocessor.PreprocessVertex(ref d))
			{
				return (A: -1, B: -1, C: -1, D: -1);
			}
		}
		if (a.Position == c.Position || b.Position == d.Position)
		{
			return (A: -1, B: -1, C: -1, D: -1);
		}
		if (a.Position == b.Position)
		{
			(int, int, int) tuple = _AddTriangle(in b, in c, in d);
			return (A: -1, B: tuple.Item1, C: tuple.Item2, D: tuple.Item3);
		}
		if (b.Position == c.Position)
		{
			(int, int, int) tuple2 = _AddTriangle(in a, in c, in d);
			return (A: tuple2.Item1, B: -1, C: tuple2.Item2, D: tuple2.Item3);
		}
		if (c.Position == d.Position)
		{
			(int, int, int) tuple3 = _AddTriangle(in a, in b, in d);
			return (A: tuple3.Item1, B: tuple3.Item2, C: -1, D: tuple3.Item3);
		}
		if (d.Position == a.Position)
		{
			(int, int, int) tuple4 = _AddTriangle(in a, in b, in c);
			return (A: tuple4.Item1, B: tuple4.Item2, C: tuple4.Item3, D: -1);
		}
		int num = UseVertex(in a);
		int num2 = UseVertex(in b);
		int num3 = UseVertex(in c);
		int num4 = UseVertex(in d);
		if (MeshBuilderToolkit.GetQuadrangleDiagonal(a.Position, b.Position, c.Position, d.Position))
		{
			_QuadIndices.Add((num, num2, num3, num4));
			return (A: num, B: num2, C: num3, D: num4);
		}
		_QuadIndices.Add((num2, num3, num4, num));
		return (A: num, B: num2, C: num3, D: num4);
	}

	private (int A, int B, int C) _AddTriangle(in VertexBuilder<TvG, TvM, TvS> a, in VertexBuilder<TvG, TvM, TvS> b, in VertexBuilder<TvG, TvM, TvS> c)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (a.Position == b.Position || a.Position == c.Position || b.Position == c.Position)
		{
			return (A: -1, B: -1, C: -1);
		}
		int item = UseVertex(in a);
		int item2 = UseVertex(in b);
		int item3 = UseVertex(in c);
		_TriIndices.Add((item, item2, item3));
		return (A: item, B: item2, C: item3);
	}

	public override IReadOnlyList<int> GetIndices()
	{
		return Triangles.SelectMany(((int A, int B, int C) item) => new int[3] { item.A, item.B, item.C }).ToList();
	}
}
