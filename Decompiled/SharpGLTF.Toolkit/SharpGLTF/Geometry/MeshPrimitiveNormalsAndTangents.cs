using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Runtime;

namespace SharpGLTF.Geometry;

internal sealed class MeshPrimitiveNormalsAndTangents<TMaterial> : SharpGLTF.Runtime.VertexNormalsFactory.IMeshPrimitive, SharpGLTF.Runtime.VertexTangentsFactory.IMeshPrimitive
{
	private readonly IPrimitiveReader<TMaterial> _Source;

	private Vector3[] _Normals;

	private Vector4[] _Tangents;

	public int VertexCount => _Source.Vertices.Count;

	public static IReadOnlyDictionary<IPrimitiveReader<TMaterial>, MeshPrimitiveNormalsAndTangents<TMaterial>> GenerateNormalsTangents(IMeshBuilder<TMaterial> mesh)
	{
		Dictionary<IPrimitiveReader<TMaterial>, MeshPrimitiveNormalsAndTangents<TMaterial>> dictionary = mesh.Primitives.Where((IPrimitiveReader<TMaterial> item) => item.VerticesPerPrimitive > 2).ToDictionary((IPrimitiveReader<TMaterial> p) => p, (IPrimitiveReader<TMaterial> p) => new MeshPrimitiveNormalsAndTangents<TMaterial>(p));
		SharpGLTF.Runtime.VertexNormalsFactory.CalculateSmoothNormals(dictionary.Values.ToList());
		SharpGLTF.Runtime.VertexTangentsFactory.CalculateTangents(dictionary.Values.ToList());
		return dictionary;
	}

	private MeshPrimitiveNormalsAndTangents(IPrimitiveReader<TMaterial> source)
	{
		_Source = source;
	}

	public IEnumerable<(int A, int B, int C)> GetTriangleIndices()
	{
		return _Source.Triangles;
	}

	public Vector3 GetVertexPosition(int idx)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		IVertexBuilder vertexBuilder = _Source.Vertices[idx];
		return vertexBuilder.GetGeometry().GetPosition();
	}

	public Vector3 GetVertexNormal(int idx)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		IVertexBuilder vertexBuilder = _Source.Vertices[idx];
		if (!vertexBuilder.GetGeometry().TryGetNormal(out var normal))
		{
			return _Normals[idx];
		}
		return normal;
	}

	public Vector4 GetVertexTangent(int idx)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		IVertexBuilder vertexBuilder = _Source.Vertices[idx];
		if (!vertexBuilder.GetGeometry().TryGetTangent(out var tangent))
		{
			return _Tangents[idx];
		}
		return tangent;
	}

	public Vector2 GetVertexTexCoord(int idx)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		IVertexBuilder vertexBuilder = _Source.Vertices[idx];
		IVertexMaterial material = vertexBuilder.GetMaterial();
		if (material.MaxTextCoords <= 0)
		{
			return Vector2.Zero;
		}
		return material.GetTexCoord(0);
	}

	public void SetVertexNormal(int idx, Vector3 normal)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (_Normals == null)
		{
			_Normals = (Vector3[])(object)new Vector3[VertexCount];
		}
		_Normals[idx] = normal;
	}

	public void SetVertexTangent(int idx, Vector4 tangent)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (_Tangents == null)
		{
			_Tangents = (Vector4[])(object)new Vector4[VertexCount];
		}
		_Tangents[idx] = tangent;
	}
}
