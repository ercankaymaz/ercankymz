using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry;

internal static class MeshBuilderToolkit
{
	public static VertexBuilder<VertexGeometryDelta, VertexMaterialDelta, VertexEmpty>[] GetMorphTargetVertices(this IPrimitiveMorphTargetReader morphTarget, int vertexCount)
	{
		VertexBuilder<VertexGeometryDelta, VertexMaterialDelta, VertexEmpty>[] array = new VertexBuilder<VertexGeometryDelta, VertexMaterialDelta, VertexEmpty>[vertexCount];
		for (int i = 0; i < vertexCount; i++)
		{
			array[i] = morphTarget.GetVertexDelta(i);
		}
		return array;
	}

	public static EncodingType GetOptimalIndexEncoding<TMaterial>(this IEnumerable<IMeshBuilder<TMaterial>> meshes)
	{
		SharpGLTF.Guard.NotNull(meshes, "meshes");
		IEnumerable<int> source = (from item in meshes.SelectMany((IMeshBuilder<TMaterial> item) => item.Primitives)
			where item.VerticesPerPrimitive >= 2
			select item).SelectMany((IPrimitiveReader<TMaterial> prim) => prim.GetIndices());
		int num = source.Aggregate(0, (int a, int b) => Math.Max(a, b));
		if (num >= 65535)
		{
			return EncodingType.UNSIGNED_INT;
		}
		return EncodingType.UNSIGNED_SHORT;
	}

	public static EncodingType GetOptimalJointEncoding<TMaterial>(this IEnumerable<IMeshBuilder<TMaterial>> meshes)
	{
		SharpGLTF.Guard.NotNull(meshes, "meshes");
		IEnumerable<int> source = from item in meshes.SelectMany((IMeshBuilder<TMaterial> item) => item.Primitives).SelectMany((IPrimitiveReader<TMaterial> item) => item.Vertices)
			select item.GetSkinning().GetBindings().MaxIndex;
		int num = source.Aggregate(0, (int a, int b) => Math.Max(a, b));
		if (num >= 256)
		{
			return EncodingType.UNSIGNED_SHORT;
		}
		return EncodingType.UNSIGNED_BYTE;
	}

	public static IMeshBuilder<TMaterial> CreateMeshBuilderFromVertexAttributes<TMaterial>(params string[] vertexAttributes)
	{
		return VertexUtils.GetVertexBuilderType(vertexAttributes).BuilderFactory().CreateCompatibleMesh<TMaterial>();
	}

	public static IReadOnlyDictionary<Vector3, Vector3> CalculateSmoothNormals<TMaterial>(this IMeshBuilder<TMaterial> srcMesh)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<Vector3, Vector3> dictionary = new Dictionary<Vector3, Vector3>();
		foreach (IPrimitiveReader<TMaterial> primitive in srcMesh.Primitives)
		{
			foreach (var triangle in primitive.Triangles)
			{
				Vector3 position = primitive.Vertices[triangle.A].GetGeometry().GetPosition();
				Vector3 position2 = primitive.Vertices[triangle.B].GetGeometry().GetPosition();
				Vector3 position3 = primitive.Vertices[triangle.C].GetGeometry().GetPosition();
				Vector3 dir = Vector3.Cross(position2 - position, position3 - position);
				addDirection(dictionary, position, dir);
				addDirection(dictionary, position2, dir);
				addDirection(dictionary, position3, dir);
			}
		}
		foreach (Vector3 item in dictionary.Keys.ToList())
		{
			dictionary[item] = Vector3.Normalize(dictionary[item]);
		}
		return dictionary;
		static void addDirection(Dictionary<Vector3, Vector3> dict, Vector3 pos, Vector3 val)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			if (val._IsFinite())
			{
				if (!dict.TryGetValue(pos, out var value))
				{
					value = Vector3.Zero;
				}
				dict[pos] = value + val;
			}
		}
	}

	public static bool IsEmpty<TMaterial>(this IPrimitiveReader<TMaterial> primitive)
	{
		if (primitive == null)
		{
			return true;
		}
		if (primitive.Points.Count > 0)
		{
			return false;
		}
		if (primitive.Lines.Count > 0)
		{
			return false;
		}
		if (primitive.Triangles.Count > 0)
		{
			return false;
		}
		return true;
	}

	public static bool IsEmpty<TMaterial>(this IMeshBuilder<TMaterial> mesh)
	{
		if (mesh == null)
		{
			return true;
		}
		if (mesh.Primitives.Count == 0)
		{
			return true;
		}
		return mesh.Primitives.All((IPrimitiveReader<TMaterial> prim) => prim.IsEmpty());
	}

	public static bool GetQuadrangleDiagonal(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Vector3.Cross(a - b, c - b);
		float num = ((Vector3)(ref val)).Length();
		val = Vector3.Cross(a - d, c - d);
		float num2 = num + ((Vector3)(ref val)).Length();
		val = Vector3.Cross(b - a, d - a);
		float num3 = ((Vector3)(ref val)).Length();
		val = Vector3.Cross(b - c, d - c);
		float num4 = num3 + ((Vector3)(ref val)).Length();
		return num2 <= num4;
	}
}
