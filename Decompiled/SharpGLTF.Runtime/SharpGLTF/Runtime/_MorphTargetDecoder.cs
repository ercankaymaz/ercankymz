using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("Vertices: {VertexCount}")]
internal sealed class _MorphTargetDecoder : VertexNormalsFactory.IMeshPrimitive, VertexTangentsFactory.IMeshPrimitive
{
	private readonly _MeshGeometryDecoder _Geometry;

	internal readonly IReadOnlyList<Vector3> _PositionsDeltas;

	private IReadOnlyList<Vector3> _NormalsDeltas;

	private IReadOnlyList<Vector3> _TangentsDeltas;

	private IReadOnlyList<Vector2> _TexCoordDeltas_0;

	private IReadOnlyList<Vector2> _TexCoordDeltas_1;

	private IReadOnlyList<Vector4> _ColorDeltas_0;

	private IReadOnlyList<Vector4> _ColorDeltas_1;

	private Vector3[] _GeneratedNormals;

	private Vector3[] _GeneratedTangents;

	public int VertexCount => _PositionsDeltas?.Count ?? 0;

	public bool HasNormals => _NormalsDeltas != null;

	public bool HasTangents => _TangentsDeltas != null;

	public _MorphTargetDecoder(_MeshGeometryDecoder geometry, MeshPrimitive srcPrim, int morphTargetIndex)
	{
		_Geometry = geometry;
		IReadOnlyDictionary<string, Accessor> morphTargetAccessors = srcPrim.GetMorphTargetAccessors(morphTargetIndex);
		if (morphTargetAccessors.TryGetValue("POSITION", out var value))
		{
			_PositionsDeltas = value.AsVector3Array();
		}
		if (morphTargetAccessors.TryGetValue("NORMAL", out var value2))
		{
			_NormalsDeltas = value2.AsVector3Array();
		}
		if (morphTargetAccessors.TryGetValue("TANGENT", out var value3))
		{
			_TangentsDeltas = value3.AsVector3Array();
		}
		if (morphTargetAccessors.TryGetValue("TEXCOORD_0", out var value4))
		{
			_TexCoordDeltas_0 = value4.AsVector2Array();
		}
		if (morphTargetAccessors.TryGetValue("TEXCOORD_1", out var value5))
		{
			_TexCoordDeltas_1 = value5.AsVector2Array();
		}
		if (morphTargetAccessors.TryGetValue("COLOR_0", out var value6))
		{
			_ColorDeltas_0 = value6.AsVector4Array();
		}
		if (morphTargetAccessors.TryGetValue("COLOR_1", out var value7))
		{
			_ColorDeltas_1 = value7.AsVector4Array();
		}
	}

	public bool HasTexCoord(int set)
	{
		return set switch
		{
			0 => _TexCoordDeltas_0 != null, 
			1 => _TexCoordDeltas_1 != null, 
			_ => false, 
		};
	}

	public bool HasColor(int set)
	{
		return set switch
		{
			0 => _ColorDeltas_0 != null, 
			1 => _ColorDeltas_1 != null, 
			_ => false, 
		};
	}

	public Vector3 GetPositionBase(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Geometry.GetPosition(vertexIndex);
	}

	public Vector3 GetPositionDelta(int vertexIndex)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (_PositionsDeltas != null)
		{
			return _PositionsDeltas[vertexIndex];
		}
		return Vector3.Zero;
	}

	public Vector3 GetNormalBase(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Geometry.GetNormal(vertexIndex);
	}

	public Vector3 GetNormalDelta(int vertexIndex)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (_NormalsDeltas != null)
		{
			return _NormalsDeltas[vertexIndex];
		}
		return Vector3.Zero;
	}

	public Vector4 GetTangentBase(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Geometry.GetTangent(vertexIndex);
	}

	public Vector3 GetTangentDelta(int vertexIndex)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (_TangentsDeltas != null)
		{
			return _TangentsDeltas[vertexIndex];
		}
		return Vector3.Zero;
	}

	public Vector2 GetTextureCoord(int vertexIndex, int set)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return _Geometry.GetTextureCoord(vertexIndex, set);
	}

	public Vector2 GetTextureCoordDelta(int vertexIndex, int set)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		switch (set)
		{
		case 0:
			if (_TexCoordDeltas_0 != null)
			{
				return _TexCoordDeltas_0[vertexIndex];
			}
			return Vector2.Zero;
		case 1:
			if (_TexCoordDeltas_1 != null)
			{
				return _TexCoordDeltas_1[vertexIndex];
			}
			return Vector2.Zero;
		default:
			return Vector2.Zero;
		}
	}

	public Vector4 GetColor(int vertexIndex, int set)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return _Geometry.GetColor(vertexIndex, set);
	}

	public Vector4 GetColorDelta(int vertexIndex, int set)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		switch (set)
		{
		case 0:
			if (_ColorDeltas_0 != null)
			{
				return _ColorDeltas_0[vertexIndex];
			}
			return Vector4.Zero;
		case 1:
			if (_ColorDeltas_1 != null)
			{
				return _ColorDeltas_1[vertexIndex];
			}
			return Vector4.Zero;
		default:
			return Vector4.Zero;
		}
	}

	IEnumerable<(int A, int B, int C)> VertexNormalsFactory.IMeshPrimitive.GetTriangleIndices()
	{
		return ((VertexNormalsFactory.IMeshPrimitive)_Geometry).GetTriangleIndices();
	}

	IEnumerable<(int A, int B, int C)> VertexTangentsFactory.IMeshPrimitive.GetTriangleIndices()
	{
		return ((VertexTangentsFactory.IMeshPrimitive)_Geometry).GetTriangleIndices();
	}

	Vector3 VertexNormalsFactory.IMeshPrimitive.GetVertexPosition(int idx)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		return GetPositionBase(idx) + GetPositionDelta(idx);
	}

	Vector3 VertexTangentsFactory.IMeshPrimitive.GetVertexPosition(int idx)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		return GetPositionBase(idx) + GetPositionDelta(idx);
	}

	Vector3 VertexTangentsFactory.IMeshPrimitive.GetVertexNormal(int idx)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		return GetNormalBase(idx) + GetNormalDelta(idx);
	}

	Vector2 VertexTangentsFactory.IMeshPrimitive.GetVertexTexCoord(int idx)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return GetTextureCoord(idx, 0);
	}

	void VertexNormalsFactory.IMeshPrimitive.SetVertexNormal(int idx, Vector3 normal)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if (_NormalsDeltas == null)
		{
			_NormalsDeltas = (_GeneratedNormals = (Vector3[])(object)new Vector3[VertexCount]);
		}
		if (_GeneratedNormals != null)
		{
			_GeneratedNormals[idx] = normal - GetNormalBase(idx);
		}
	}

	void VertexTangentsFactory.IMeshPrimitive.SetVertexTangent(int idx, Vector4 tangent)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (_TangentsDeltas == null)
		{
			_TangentsDeltas = (_GeneratedTangents = (Vector3[])(object)new Vector3[VertexCount]);
		}
		if (_GeneratedTangents == null)
		{
			Vector4 val = tangent - GetTangentBase(idx);
			_GeneratedTangents[idx] = new Vector3(val.X, val.Y, val.Z);
		}
	}
}
