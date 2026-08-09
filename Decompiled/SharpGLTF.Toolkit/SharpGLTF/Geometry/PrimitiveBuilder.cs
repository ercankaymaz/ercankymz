using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Collections;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

public abstract class PrimitiveBuilder<TMaterial, TvG, TvM, TvS> : IPrimitiveBuilder, IPrimitiveReader<TMaterial> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	private sealed class VertexListWrapper : ValueListSet<VertexBuilder<TvG, TvM, TvS>>, IReadOnlyList<IVertexBuilder>, IEnumerable<IVertexBuilder>, IEnumerable, IReadOnlyCollection<IVertexBuilder>
	{
		IVertexBuilder IReadOnlyList<IVertexBuilder>.this[int index] => base[index];

		IEnumerator<IVertexBuilder> IEnumerable<IVertexBuilder>.GetEnumerator()
		{
			using IEnumerator<VertexBuilder<TvG, TvM, TvS>> enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				VertexBuilder<TvG, TvM, TvS> current = enumerator.Current;
				yield return current;
			}
		}
	}

	private readonly MeshBuilder<TMaterial, TvG, TvM, TvS> _Mesh;

	private readonly TMaterial _Material;

	private readonly VertexListWrapper _Vertices = new VertexListWrapper();

	private readonly List<PrimitiveMorphTargetBuilder<TvG, TvM>> _MorphTargets = new List<PrimitiveMorphTargetBuilder<TvG, TvM>>();

	public MeshBuilder<TMaterial, TvG, TvM, TvS> Mesh => _Mesh;

	public TMaterial Material => _Material;

	public abstract int VerticesPerPrimitive { get; }

	public Type VertexType => typeof(VertexBuilder<TvG, TvM, TvS>);

	public Func<IVertexBuilder> VertexFactory => () => default(VertexBuilder<TvG, TvM, TvS>);

	public IReadOnlyList<VertexBuilder<TvG, TvM, TvS>> Vertices => _Vertices;

	IReadOnlyList<IVertexBuilder> IPrimitiveReader<TMaterial>.Vertices => _Vertices;

	IReadOnlyList<IPrimitiveMorphTargetReader> IPrimitiveReader<TMaterial>.MorphTargets => _MorphTargets;

	public virtual IReadOnlyList<int> Points => Array.Empty<int>();

	public virtual IReadOnlyList<(int A, int B)> Lines => Array.Empty<(int, int)>();

	public virtual IReadOnlyList<(int A, int B, int C)> Triangles => Array.Empty<(int, int, int)>();

	public virtual IReadOnlyList<(int A, int B, int C, int? D)> Surfaces => Array.Empty<(int, int, int, int?)>();

	internal IReadOnlyList<PrimitiveMorphTargetBuilder<TvG, TvM>> MorphTargets => _MorphTargets;

	internal PrimitiveBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TMaterial material)
	{
		_Mesh = mesh;
		_Material = material;
	}

	protected PrimitiveBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, PrimitiveBuilder<TMaterial, TvG, TvM, TvS> other, TMaterial material)
	{
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		SharpGLTF.Guard.NotNull(other, "other");
		_Mesh = mesh;
		_Material = ((material != null) ? material : other.Material);
		other._Vertices.CopyTo(_Vertices);
		foreach (PrimitiveMorphTargetBuilder<TvG, TvM> morphTarget in other._MorphTargets)
		{
			PrimitiveMorphTargetBuilder<TvG, TvM> primitiveMorphTargetBuilder = new PrimitiveMorphTargetBuilder<TvG, TvM>((int idx) => (_Vertices[idx].Geometry, _Vertices[idx].Material), morphTarget);
			_MorphTargets.Add(morphTarget);
		}
	}

	internal abstract PrimitiveBuilder<TMaterial, TvG, TvM, TvS> Clone(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, TMaterial material);

	internal PrimitiveMorphTargetBuilder<TvG, TvM> _UseMorphTarget(int morphTargetIndex)
	{
		while (_MorphTargets.Count <= morphTargetIndex)
		{
			_MorphTargets.Add(new PrimitiveMorphTargetBuilder<TvG, TvM>((int idx) => (_Vertices[idx].Geometry, _Vertices[idx].Material)));
		}
		return _MorphTargets[morphTargetIndex];
	}

	public void Validate()
	{
		int expected = Mesh.Primitives.Max((PrimitiveBuilder<TMaterial, TvG, TvM, TvS> item) => item.MorphTargets.Count);
		SharpGLTF.Guard.MustBeEqualTo(MorphTargets.Count, expected, "MorphTargets");
		foreach (VertexBuilder<TvG, TvM, TvS> vertex in _Vertices)
		{
			vertex.Validate();
		}
	}

	private static VertexBuilder<TvG, TvM, TvS> ConvertVertex(IVertexBuilder vertex)
	{
		return VertexBuilder<TvG, TvM, TvS>.CreateFrom(vertex);
	}

	protected int UseVertex(in VertexBuilder<TvG, TvM, TvS> vertex)
	{
		return _Vertices.Use(in vertex);
	}

	void IPrimitiveBuilder.SetVertexDelta(int morphTargetIndex, int vertexIndex, VertexGeometryDelta geometryDelta, VertexMaterialDelta materialDelta)
	{
		_UseMorphTarget(morphTargetIndex).SetVertexDelta(vertexIndex, geometryDelta, materialDelta);
	}

	public bool ContainsVertex(in VertexBuilder<TvG, TvM, TvS> vertex)
	{
		return _Vertices.IndexOf(in vertex) >= 0;
	}

	public int AddPoint(IVertexBuilder a)
	{
		SharpGLTF.Guard.NotNull(a, "a");
		return AddPoint(ConvertVertex(a));
	}

	public (int A, int B) AddLine(IVertexBuilder a, IVertexBuilder b)
	{
		SharpGLTF.Guard.NotNull(a, "a");
		SharpGLTF.Guard.NotNull(b, "b");
		return AddLine(ConvertVertex(a), ConvertVertex(b));
	}

	public (int A, int B, int C) AddTriangle(IVertexBuilder a, IVertexBuilder b, IVertexBuilder c)
	{
		SharpGLTF.Guard.NotNull(a, "a");
		SharpGLTF.Guard.NotNull(b, "b");
		SharpGLTF.Guard.NotNull(c, "c");
		return AddTriangle(ConvertVertex(a), ConvertVertex(b), ConvertVertex(c));
	}

	public (int A, int B, int C, int D) AddQuadrangle(IVertexBuilder a, IVertexBuilder b, IVertexBuilder c, IVertexBuilder d)
	{
		SharpGLTF.Guard.NotNull(a, "a");
		SharpGLTF.Guard.NotNull(b, "b");
		SharpGLTF.Guard.NotNull(c, "c");
		SharpGLTF.Guard.NotNull(d, "d");
		return AddQuadrangle(ConvertVertex(a), ConvertVertex(b), ConvertVertex(c), ConvertVertex(d));
	}

	internal void AddPrimitive(PrimitiveBuilder<TMaterial, TvG, TvM, TvS> primitive, Converter<VertexBuilder<TvG, TvM, TvS>, VertexBuilder<TvG, TvM, TvS>> vertexTransformFunc)
	{
		if (primitive == null)
		{
			return;
		}
		if (vertexTransformFunc == null)
		{
			vertexTransformFunc = (VertexBuilder<TvG, TvM, TvS> v) => v;
		}
		AddPrimitive(primitive, (IVertexBuilder v) => vertexTransformFunc((VertexBuilder<TvG, TvM, TvS>)(object)v));
	}

	internal void AddPrimitive<TAnyMaterial>(IPrimitiveReader<TAnyMaterial> primitive, Converter<IVertexBuilder, VertexBuilder<TvG, TvM, TvS>> vertexTransformFunc)
	{
		if (primitive == null)
		{
			return;
		}
		SharpGLTF.Guard.NotNull(vertexTransformFunc, "vertexTransformFunc");
		Dictionary<int, int> dictionary = ((primitive.MorphTargets.Count == 0) ? null : new Dictionary<int, int>());
		if (VerticesPerPrimitive == 1)
		{
			foreach (int point in primitive.Points)
			{
				VertexBuilder<TvG, TvM, TvS> a = vertexTransformFunc(primitive.Vertices[point]);
				int value = AddPoint(a);
				if (dictionary != null)
				{
					dictionary[point] = value;
				}
			}
		}
		if (VerticesPerPrimitive == 2)
		{
			foreach (var line in primitive.Lines)
			{
				int item = line.A;
				int item2 = line.B;
				VertexBuilder<TvG, TvM, TvS> a2 = vertexTransformFunc(primitive.Vertices[item]);
				VertexBuilder<TvG, TvM, TvS> b = vertexTransformFunc(primitive.Vertices[item2]);
				var (value2, value3) = AddLine(a2, b);
				if (dictionary != null)
				{
					dictionary[item] = value2;
					dictionary[item2] = value3;
				}
			}
		}
		if (VerticesPerPrimitive == 3)
		{
			foreach (var surface in primitive.Surfaces)
			{
				int item3 = surface.A;
				int item4 = surface.B;
				int item5 = surface.C;
				int? item6 = surface.D;
				VertexBuilder<TvG, TvM, TvS> a3 = vertexTransformFunc(primitive.Vertices[item3]);
				VertexBuilder<TvG, TvM, TvS> b2 = vertexTransformFunc(primitive.Vertices[item4]);
				VertexBuilder<TvG, TvM, TvS> c = vertexTransformFunc(primitive.Vertices[item5]);
				if (item6.HasValue)
				{
					VertexBuilder<TvG, TvM, TvS> d = vertexTransformFunc(primitive.Vertices[item6.Value]);
					var (value4, value5, value6, value7) = AddQuadrangle(a3, b2, c, d);
					if (dictionary != null)
					{
						dictionary[item3] = value4;
						dictionary[item4] = value5;
						dictionary[item5] = value6;
						dictionary[item6.Value] = value7;
					}
				}
				else
				{
					var (value8, value9, value10) = AddTriangle(a3, b2, c);
					if (dictionary != null)
					{
						dictionary[item3] = value8;
						dictionary[item4] = value9;
						dictionary[item5] = value10;
					}
				}
			}
		}
		if (dictionary != null)
		{
			for (int i = 0; i < primitive.MorphTargets.Count; i++)
			{
				IPrimitiveMorphTargetReader other = primitive.MorphTargets[i];
				_UseMorphTarget(i).SetMorphTargets(other, dictionary, geoTransformFunc);
			}
		}
		VertexBuilder<TvG, TvM, VertexEmpty> geoTransformFunc(IVertexGeometry g)
		{
			VertexBuilder<TvG, TvM, TvS> vertexBuilder = vertexTransformFunc(new VertexBuilder(g));
			return (vertexBuilder.Geometry, vertexBuilder.Material);
		}
	}

	public void TransformVertices(Func<VertexBuilder<TvG, TvM, TvS>, VertexBuilder<TvG, TvM, TvS>> vertexTransformFunc)
	{
		SharpGLTF.Guard.NotNull(vertexTransformFunc, "vertexTransformFunc");
		_Vertices.ApplyTransform(vertexTransformFunc);
		foreach (PrimitiveMorphTargetBuilder<TvG, TvM> morphTarget in _MorphTargets)
		{
			morphTarget.TransformVertices(geoFunc);
		}
		VertexBuilder<TvG, TvM, VertexEmpty> geoFunc(VertexBuilder<TvG, TvM, VertexEmpty> g)
		{
			VertexBuilder<TvG, TvM, TvS> vertexBuilder = vertexTransformFunc(new VertexBuilder<TvG, TvM, TvS>(in g.Geometry, in g.Material, default(TvS)));
			return new VertexBuilder<TvG, TvM, VertexEmpty>(in vertexBuilder.Geometry, in vertexBuilder.Material);
		}
	}

	public abstract IReadOnlyList<int> GetIndices();

	public virtual int AddPoint(VertexBuilder<TvG, TvM, TvS> a)
	{
		throw new NotSupportedException("Points are not supported for this primitive");
	}

	public virtual (int A, int B) AddLine(VertexBuilder<TvG, TvM, TvS> a, VertexBuilder<TvG, TvM, TvS> b)
	{
		throw new NotSupportedException("Lines are not supported for this primitive");
	}

	public virtual (int A, int B, int C) AddTriangle(VertexBuilder<TvG, TvM, TvS> a, VertexBuilder<TvG, TvM, TvS> b, VertexBuilder<TvG, TvM, TvS> c)
	{
		throw new NotSupportedException("Triangles are not supported for this primitive");
	}

	public virtual (int A, int B, int C, int D) AddQuadrangle(VertexBuilder<TvG, TvM, TvS> a, VertexBuilder<TvG, TvM, TvS> b, VertexBuilder<TvG, TvM, TvS> c, VertexBuilder<TvG, TvM, TvS> d)
	{
		throw new NotSupportedException("Quadrangles are not supported for this primitive");
	}
}
