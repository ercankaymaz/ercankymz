using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace SharpGLTF.Runtime;

internal static class VertexTangentsFactory
{
	public interface IMeshPrimitive
	{
		int VertexCount { get; }

		Vector3 GetVertexPosition(int idx);

		Vector3 GetVertexNormal(int idx);

		Vector2 GetVertexTexCoord(int idx);

		void SetVertexTangent(int idx, Vector4 tangent);

		IEnumerable<(int A, int B, int C)> GetTriangleIndices();
	}

	public static void CalculateTangents<T>(IEnumerable<T> primitives) where T : IMeshPrimitive
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(primitives, "primitives");
		primitives = primitives.EnsureList();
		Dictionary<(Vector3, Vector3, Vector2), (Vector3, Vector3)> dictionary = new Dictionary<(Vector3, Vector3, Vector2), (Vector3, Vector3)>();
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
				if (vertexPosition == vertexPosition2 || vertexPosition == vertexPosition3 || vertexPosition2 == vertexPosition3)
				{
					continue;
				}
				Vector2 vertexTexCoord = primitive.GetVertexTexCoord(item);
				Vector2 vertexTexCoord2 = primitive.GetVertexTexCoord(item2);
				Vector2 vertexTexCoord3 = primitive.GetVertexTexCoord(item3);
				if (vertexTexCoord == vertexTexCoord2 || vertexTexCoord == vertexTexCoord3 || vertexTexCoord2 == vertexTexCoord3)
				{
					continue;
				}
				Vector3 vertexNormal = primitive.GetVertexNormal(item);
				Vector3 vertexNormal2 = primitive.GetVertexNormal(item2);
				Vector3 vertexNormal3 = primitive.GetVertexNormal(item3);
				Vector3 val = vertexPosition2 - vertexPosition;
				Vector3 val2 = vertexPosition3 - vertexPosition;
				Vector2 val3 = vertexTexCoord2 - vertexTexCoord;
				Vector2 val4 = vertexTexCoord3 - vertexTexCoord;
				float x = val3.X;
				float x2 = val4.X;
				float y = val3.Y;
				float y2 = val4.Y;
				float num = 1f / (x * y2 - x2 * y);
				if (num._IsFinite())
				{
					Vector3 val5 = new Vector3(y2 * val.X - y * val2.X, y2 * val.Y - y * val2.Y, y2 * val.Z - y * val2.Z) * num;
					Vector3 val6 = new Vector3(x * val2.X - x2 * val.X, x * val2.Y - x2 * val.Y, x * val2.Z - x2 * val.Z) * num;
					if (val5._IsFinite() && val6._IsFinite())
					{
						_AddTangent(dictionary, (vertexPosition, vertexNormal, vertexTexCoord), (tu: val5, tv: val6));
						_AddTangent(dictionary, (vertexPosition2, vertexNormal2, vertexTexCoord2), (tu: val5, tv: val6));
						_AddTangent(dictionary, (vertexPosition3, vertexNormal3, vertexTexCoord3), (tu: val5, tv: val6));
					}
				}
			}
		}
		foreach (var item4 in dictionary.Keys.ToList())
		{
			(Vector3, Vector3) value = dictionary[item4];
			value.Item1 = Vector3.Normalize(value.Item1 - item4.Item2 * Vector3.Dot(item4.Item2, value.Item1));
			value.Item2 = Vector3.Normalize(value.Item2 - item4.Item2 * Vector3.Dot(item4.Item2, value.Item2));
			dictionary[item4] = value;
		}
		foreach (T primitive2 in primitives)
		{
			T current4 = primitive2;
			for (int i = 0; i < current4.VertexCount; i++)
			{
				Vector3 vertexPosition4 = current4.GetVertexPosition(i);
				Vector3 vertexNormal4 = current4.GetVertexNormal(i);
				Vector2 vertexTexCoord4 = current4.GetVertexTexCoord(i);
				T val7;
				if (dictionary.TryGetValue((vertexPosition4, vertexNormal4, vertexTexCoord4), out var value2))
				{
					float num2 = ((Vector3.Dot(Vector3.Cross(value2.Item1, vertexNormal4), value2.Item2) < 0f) ? (-1f) : 1f);
					ref T reference = ref current4;
					val7 = default(T);
					if (val7 == null)
					{
						val7 = reference;
						reference = ref val7;
					}
					int idx = i;
					Vector4 tangent = new Vector4(value2.Item1, num2);
					reference.SetVertexTangent(idx, tangent);
				}
				else
				{
					ref T reference2 = ref current4;
					val7 = default(T);
					if (val7 == null)
					{
						val7 = reference2;
						reference2 = ref val7;
					}
					int idx2 = i;
					Vector4 tangent2 = new Vector4(1f, 0f, 0f, 1f);
					reference2.SetVertexTangent(idx2, tangent2);
				}
			}
		}
	}

	private static void _AddTangent(Dictionary<(Vector3, Vector3, Vector2), (Vector3, Vector3)> dict, (Vector3, Vector3, Vector2) key, (Vector3 tu, Vector3 tv) alpha)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		dict.TryGetValue(key, out var value);
		dict[key] = (alpha.tu + value.Item1, alpha.tv + value.Item2);
	}
}
