using System;
using System.Collections.Generic;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

internal class PrimitiveMorphTargetBuilder<TvG, TvM> : IPrimitiveMorphTargetReader where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial
{
	private readonly Func<int, VertexBuilder<TvG, TvM, VertexEmpty>> _BaseVertexFunc;

	private readonly Dictionary<int, VertexBuilder<TvG, TvM, VertexEmpty>> _MorphVertices;

	internal PrimitiveMorphTargetBuilder(Func<int, VertexBuilder<TvG, TvM, VertexEmpty>> baseVertexFunc)
	{
		_BaseVertexFunc = baseVertexFunc;
		_MorphVertices = new Dictionary<int, VertexBuilder<TvG, TvM, VertexEmpty>>();
	}

	internal PrimitiveMorphTargetBuilder(Func<int, VertexBuilder<TvG, TvM, VertexEmpty>> baseVertexFunc, PrimitiveMorphTargetBuilder<TvG, TvM> other)
	{
		_BaseVertexFunc = baseVertexFunc;
		_MorphVertices = new Dictionary<int, VertexBuilder<TvG, TvM, VertexEmpty>>(other._MorphVertices);
	}

	public IReadOnlyCollection<int> GetTargetIndices()
	{
		return _MorphVertices.Keys;
	}

	public VertexBuilder<VertexGeometryDelta, VertexMaterialDelta, VertexEmpty> GetVertexDelta(int vertexIndex)
	{
		if (!_MorphVertices.TryGetValue(vertexIndex, out var value))
		{
			return default(VertexBuilder<VertexGeometryDelta, VertexMaterialDelta, VertexEmpty>);
		}
		VertexBuilder<TvG, TvM, VertexEmpty> vertexBuilder = _BaseVertexFunc(vertexIndex);
		return new VertexBuilder<VertexGeometryDelta, VertexMaterialDelta, VertexEmpty>(value.Geometry.Subtract(vertexBuilder.Geometry), value.Material.Subtract(vertexBuilder.Material));
	}

	public void SetVertexDelta(int vertexIndex, VertexGeometryDelta geometryDelta, VertexMaterialDelta materialDelta)
	{
		if (object.Equals(geometryDelta, default(VertexGeometryDelta)) && object.Equals(materialDelta, default(VertexMaterialDelta)))
		{
			_RemoveVertex(vertexIndex);
			return;
		}
		VertexBuilder<TvG, TvM, VertexEmpty> vertex = _BaseVertexFunc(vertexIndex);
		vertex.Geometry.Add(in geometryDelta);
		if (typeof(TvM) != typeof(VertexEmpty))
		{
			vertex.Material.Add(in materialDelta);
		}
		_SetVertex(vertexIndex, vertex);
	}

	IVertexBuilder IPrimitiveMorphTargetReader.GetVertex(int vertexIndex)
	{
		VertexBuilder<TvG, TvM, VertexEmpty> value;
		return _MorphVertices.TryGetValue(vertexIndex, out value) ? value : _BaseVertexFunc(vertexIndex);
	}

	public VertexBuilder<TvG, TvM, VertexEmpty> GetVertex(int vertexIndex)
	{
		if (!_MorphVertices.TryGetValue(vertexIndex, out var value))
		{
			return _BaseVertexFunc(vertexIndex);
		}
		return value;
	}

	public void SetVertex(int vertexIndex, VertexBuilder<TvG, TvM, VertexEmpty> vertex)
	{
		if (object.Equals(vertex, _BaseVertexFunc(vertexIndex)))
		{
			_RemoveVertex(vertexIndex);
		}
		else
		{
			_SetVertex(vertexIndex, vertex);
		}
	}

	private void _SetVertex(int vertexIndex, VertexBuilder<TvG, TvM, VertexEmpty> vertex)
	{
		_MorphVertices[vertexIndex] = vertex;
	}

	private void _RemoveVertex(int vertexIndex)
	{
		_MorphVertices.Remove(vertexIndex);
	}

	internal void TransformVertices(Func<VertexBuilder<TvG, TvM, VertexEmpty>, VertexBuilder<TvG, TvM, VertexEmpty>> vertexFunc)
	{
		foreach (int key in _MorphVertices.Keys)
		{
			VertexBuilder<TvG, TvM, VertexEmpty> vertex = GetVertex(key);
			vertex = vertexFunc(vertex);
			SetVertex(key, vertex);
		}
	}

	internal void SetMorphTargets(IPrimitiveMorphTargetReader other, IReadOnlyDictionary<int, int> vertexMap, Func<IVertexGeometry, VertexBuilder<TvG, TvM, VertexEmpty>> vertexFunc)
	{
		SharpGLTF.Guard.NotNull(vertexFunc, "vertexFunc");
		IReadOnlyCollection<int> targetIndices = other.GetTargetIndices();
		foreach (int item in targetIndices)
		{
			VertexBuilder<TvG, TvM, VertexEmpty> vertex = vertexFunc(other.GetVertex(item).GetGeometry());
			int value = item;
			if (vertexMap != null && !vertexMap.TryGetValue(item, out value))
			{
				value = -1;
			}
			if (value >= 0)
			{
				SetVertex(value, vertex);
			}
		}
	}
}
