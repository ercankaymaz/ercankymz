using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("Vertices: {VertexCount}")]
internal sealed class _MeshGeometryDecoder : VertexNormalsFactory.IMeshPrimitive, VertexTangentsFactory.IMeshPrimitive
{
	private readonly _MeshPrimitiveDecoder _Owner;

	internal readonly IReadOnlyList<Vector3> _Positions;

	private IReadOnlyList<Vector3> _Normals;

	private IReadOnlyList<Vector4> _Tangents;

	private Vector3[] _GeneratedNormals;

	private Vector4[] _GeneratedTangents;

	public int VertexCount => _Positions?.Count ?? 0;

	public bool HasNormals => _Normals != null;

	public bool HasTangents => _Tangents != null;

	public _MeshGeometryDecoder(_MeshPrimitiveDecoder owner, MeshPrimitive srcPrim)
	{
		_Owner = owner;
		_Positions = srcPrim.GetVertexAccessor("POSITION")?.AsVector3Array();
		_Normals = srcPrim.GetVertexAccessor("NORMAL")?.AsVector3Array();
		_Tangents = srcPrim.GetVertexAccessor("TANGENT")?.AsVector4Array();
	}

	public Vector3 GetPosition(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Positions[vertexIndex];
	}

	public Vector3 GetNormal(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Normals[vertexIndex];
	}

	public Vector4 GetTangent(int vertexIndex)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		return _Tangents[vertexIndex];
	}

	public Vector2 GetTextureCoord(int vertexIndex, int set)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return _Owner.GetTextureCoord(vertexIndex, set);
	}

	public Vector4 GetColor(int vertexIndex, int set)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return _Owner.GetColor(vertexIndex, set);
	}

	IEnumerable<(int A, int B, int C)> VertexNormalsFactory.IMeshPrimitive.GetTriangleIndices()
	{
		return _Owner.TriangleIndices;
	}

	IEnumerable<(int A, int B, int C)> VertexTangentsFactory.IMeshPrimitive.GetTriangleIndices()
	{
		return _Owner.TriangleIndices;
	}

	Vector3 VertexNormalsFactory.IMeshPrimitive.GetVertexPosition(int idx)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return GetPosition(idx);
	}

	Vector3 VertexTangentsFactory.IMeshPrimitive.GetVertexPosition(int idx)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return GetPosition(idx);
	}

	Vector3 VertexTangentsFactory.IMeshPrimitive.GetVertexNormal(int idx)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return GetNormal(idx);
	}

	Vector2 VertexTangentsFactory.IMeshPrimitive.GetVertexTexCoord(int idx)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return GetTextureCoord(idx, 0);
	}

	void VertexNormalsFactory.IMeshPrimitive.SetVertexNormal(int idx, Vector3 normal)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (_Normals == null)
		{
			_Normals = (_GeneratedNormals = (Vector3[])(object)new Vector3[VertexCount]);
		}
		if (_GeneratedNormals != null)
		{
			_GeneratedNormals[idx] = normal;
		}
	}

	void VertexTangentsFactory.IMeshPrimitive.SetVertexTangent(int idx, Vector4 tangent)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (_Tangents == null)
		{
			_Tangents = (_GeneratedTangents = (Vector4[])(object)new Vector4[VertexCount]);
		}
		if (_GeneratedTangents != null)
		{
			_GeneratedTangents[idx] = tangent;
		}
	}
}
