using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SharpGLTF.Runtime;

internal static class VertexNormalsFactory
{
	public interface IMeshPrimitive
	{
		int VertexCount { get; }

		Vector3 GetVertexPosition(int idx);

		void SetVertexNormal(int idx, Vector3 normal);

		IEnumerable<(int A, int B, int C)> GetTriangleIndices();
	}

	public static void CalculateSmoothNormals<T>(IEnumerable<T> primitives) where T : IMeshPrimitive
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(primitives, "primitives");
		primitives = primitives.EnsureList();
		Dictionary<Vector3, Vector3> dictionary = new Dictionary<Vector3, Vector3>();
		foreach (T primitive in primitives)
		{
			foreach (var triangleIndex in primitive.GetTriangleIndices())
			{
				int item = triangleIndex.A;
				int item2 = triangleIndex.B;
				int item3 = triangleIndex.C;
				Vector3 vertexPosition = primitive.GetVertexPosition(item);
				Vector3 vertexPosition2 = primitive.GetVertexPosition(item2);
				Vector3 vertexPosition3 = primitive.GetVertexPosition(item3);
				Vector3 dir = Vector3.Cross(vertexPosition2 - vertexPosition, vertexPosition3 - vertexPosition);
				_AddDirection(dictionary, vertexPosition, dir);
				_AddDirection(dictionary, vertexPosition2, dir);
				_AddDirection(dictionary, vertexPosition3, dir);
			}
		}
		foreach (Vector3 item4 in dictionary.Keys.ToList())
		{
			Vector3 val = Vector3.Normalize(dictionary[item4]);
			dictionary[item4] = ((val._IsFinite() && ((Vector3)(ref val)).LengthSquared() > 0.5f) ? val : Vector3.UnitZ);
		}
		foreach (T primitive2 in primitives)
		{
			for (int i = 0; i < primitive2.VertexCount; i++)
			{
				Vector3 vertexPosition4 = primitive2.GetVertexPosition(i);
				if (dictionary.TryGetValue(vertexPosition4, out var value))
				{
					int idx = i;
					Vector3 normal = value;
					primitive2.SetVertexNormal(idx, normal);
				}
				else
				{
					primitive2.SetVertexNormal(i, Vector3.UnitZ);
				}
			}
		}
	}

	private static void _AddDirection(Dictionary<Vector3, Vector3> dict, Vector3 pos, Vector3 dir)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (dir._IsFinite())
		{
			if (!dict.TryGetValue(pos, out var value))
			{
				value = Vector3.Zero;
			}
			dict[pos] = value + dir;
		}
	}
}
