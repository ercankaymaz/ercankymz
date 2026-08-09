using System;
using System.Collections.Generic;
using System.Numerics;
using SharpGLTF.Geometry.VertexTypes;

namespace SharpGLTF.Geometry;

public sealed class MorphTargetBuilder<TMaterial, TvG, TvS, TvM> : IMorphTargetBuilder where TvG : struct, IVertexGeometry where TvS : struct, IVertexSkinning where TvM : struct, IVertexMaterial
{
	private readonly MeshBuilder<TMaterial, TvG, TvM, TvS> _Mesh;

	private readonly int _MorphTargetIndex;

	private readonly Dictionary<TvG, List<(PrimitiveBuilder<TMaterial, TvG, TvM, TvS>, int)>> _Vertices = new Dictionary<TvG, List<(PrimitiveBuilder<TMaterial, TvG, TvM, TvS>, int)>>();

	private readonly Dictionary<Vector3, List<TvG>> _Positions = new Dictionary<Vector3, List<TvG>>();

	public IReadOnlyCollection<TvG> Vertices => _Vertices.Keys;

	public IReadOnlyCollection<Vector3> Positions => _Positions.Keys;

	IReadOnlyCollection<IVertexGeometry> IMorphTargetBuilder.Vertices => ((IReadOnlyCollection<TvG>)_Vertices.Keys).SelectCollection((Func<TvG, IVertexGeometry>)((TvG item) => item));

	internal MorphTargetBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> mesh, int morphTargetIndex)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		_Mesh = mesh;
		_MorphTargetIndex = morphTargetIndex;
		foreach (PrimitiveBuilder<TMaterial, TvG, TvM, TvS> primitive in _Mesh.Primitives)
		{
			primitive._UseMorphTarget(morphTargetIndex);
			for (int i = 0; i < primitive.Vertices.Count; i++)
			{
				TvG geometry = primitive.Vertices[i].Geometry;
				if (!_Vertices.TryGetValue(geometry, out var value))
				{
					value = (_Vertices[geometry] = new List<(PrimitiveBuilder<TMaterial, TvG, TvM, TvS>, int)>());
				}
				value.Add((primitive, i));
				if (!_Positions.TryGetValue(geometry.GetPosition(), out var value2))
				{
					value2 = (_Positions[geometry.GetPosition()] = new List<TvG>());
				}
				value2.Add(geometry);
			}
		}
	}

	public IReadOnlyList<TvG> GetVertices(Vector3 position)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if (!_Positions.TryGetValue(position, out var value))
		{
			return Array.Empty<TvG>();
		}
		return value;
	}

	public void SetVertexDelta(TvG meshVertex, VertexGeometryDelta geometryDelta)
	{
		if (!_Vertices.TryGetValue(meshVertex, out var value))
		{
			return;
		}
		foreach (var item in value)
		{
			item.Item1._UseMorphTarget(_MorphTargetIndex).SetVertexDelta(item.Item2, geometryDelta, VertexMaterialDelta.Zero);
		}
	}

	public void SetVertexDelta(TvG meshVertex, VertexGeometryDelta geometryDelta, VertexMaterialDelta materialDelta)
	{
		if (!_Vertices.TryGetValue(meshVertex, out var value))
		{
			return;
		}
		foreach (var item in value)
		{
			item.Item1._UseMorphTarget(_MorphTargetIndex).SetVertexDelta(item.Item2, geometryDelta, materialDelta);
		}
	}

	public void SetVertex(TvG meshVertex, VertexBuilder<TvG, TvM, VertexEmpty> morphVertex)
	{
		if (!_Vertices.TryGetValue(meshVertex, out var value))
		{
			return;
		}
		foreach (var item in value)
		{
			item.Item1._UseMorphTarget(_MorphTargetIndex).SetVertex(item.Item2, morphVertex);
		}
	}

	public void SetVertex(TvG meshVertex, TvG morphVertex)
	{
		if (!_Vertices.TryGetValue(meshVertex, out var value))
		{
			return;
		}
		foreach (var item in value)
		{
			TvM m = item.Item1.Vertices[item.Item2].Material;
			item.Item1._UseMorphTarget(_MorphTargetIndex).SetVertex(item.Item2, new VertexBuilder<TvG, TvM, VertexEmpty>(in morphVertex, in m));
		}
	}

	IReadOnlyList<IVertexGeometry> IMorphTargetBuilder.GetVertices(Vector3 position)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if (!_Positions.TryGetValue(position, out var value))
		{
			return Array.Empty<IVertexGeometry>();
		}
		return ((IReadOnlyList<TvG>)value).SelectList((Func<TvG, IVertexGeometry>)((TvG item) => item));
	}

	void IMorphTargetBuilder.SetVertex(IVertexGeometry meshVertex, IVertexGeometry morphVertex)
	{
		VertexBuilder<TvG, TvM, VertexEmpty> morphVertex2 = new VertexBuilder<TvG, TvM, VertexEmpty>(morphVertex.ConvertToGeometry<TvG>(), default(VertexEmpty).ConvertToMaterial<TvM>());
		SetVertex(meshVertex.ConvertToGeometry<TvG>(), morphVertex2);
	}

	void IMorphTargetBuilder.SetVertex(IVertexGeometry meshVertex, IVertexGeometry morphVertex, IVertexMaterial morphMaterial)
	{
		VertexBuilder<TvG, TvM, VertexEmpty> morphVertex2 = new VertexBuilder<TvG, TvM, VertexEmpty>(morphVertex.ConvertToGeometry<TvG>(), morphMaterial.ConvertToMaterial<TvM>());
		SetVertex(meshVertex.ConvertToGeometry<TvG>(), morphVertex2);
	}

	void IMorphTargetBuilder.SetVertexDelta(IVertexGeometry meshVertex, VertexGeometryDelta geometryDelta)
	{
		SetVertexDelta(meshVertex.ConvertToGeometry<TvG>(), geometryDelta, VertexMaterialDelta.Zero);
	}

	void IMorphTargetBuilder.SetVertexDelta(IVertexGeometry meshVertex, VertexGeometryDelta geometryDelta, VertexMaterialDelta materialDelta)
	{
		SetVertexDelta(meshVertex.ConvertToGeometry<TvG>(), geometryDelta, materialDelta);
	}

	public void SetVertexDelta(Vector3 meshVertex, VertexGeometryDelta geometryDelta)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if (!_Positions.TryGetValue(meshVertex, out var value))
		{
			return;
		}
		foreach (TvG item in value)
		{
			SetVertexDelta(item, geometryDelta, VertexMaterialDelta.Zero);
		}
	}

	public void SetVertexDelta(Vector3 meshVertex, VertexGeometryDelta geometryDelta, VertexMaterialDelta materialDelta)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if (!_Positions.TryGetValue(meshVertex, out var value))
		{
			return;
		}
		foreach (TvG item in value)
		{
			SetVertexDelta(item, geometryDelta, materialDelta);
		}
	}
}
