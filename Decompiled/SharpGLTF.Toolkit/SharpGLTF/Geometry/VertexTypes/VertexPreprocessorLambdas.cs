using System;
using System.Numerics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Geometry.VertexTypes;

internal static class VertexPreprocessorLambdas
{
	public static TvG? ValidateVertexGeometry<TvG>(TvG vertex) where TvG : struct, IVertexGeometry
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = vertex.GetPosition();
		SharpGLTF.Guard.IsTrue(position._IsFinite(), "Position", "Values are not finite.");
		if (vertex.TryGetNormal(out var normal))
		{
			SharpGLTF.Guard.IsTrue(normal._IsFinite(), "Normal", "Values are not finite.");
			SharpGLTF.Guard.MustBeBetweenOrEqualTo(((Vector3)(ref normal)).Length(), 0.99f, 1.01f, "Normal.Length");
		}
		if (vertex.TryGetTangent(out var tangent))
		{
			SharpGLTF.Guard.IsTrue(tangent._IsFinite(), "Tangent", "Values are not finite.");
			SharpGLTF.Guard.IsTrue(tangent.W == 1f || tangent.W == -1f, "Tangent.W", "Invalid value");
			Vector3 val = new Vector3(tangent.X, tangent.Y, tangent.Z);
			SharpGLTF.Guard.MustBeBetweenOrEqualTo(((Vector3)(ref val)).Length(), 0.99f, 1.01f, "Tangent.XYZ.Length");
		}
		return vertex;
	}

	public static TvM? ValidateVertexMaterial<TvM>(TvM vertex) where TvM : struct, IVertexMaterial
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < vertex.MaxColors; i++)
		{
			Vector4 v = vertex.GetColor(i);
			if (!v._IsFinite())
			{
				throw new ArgumentException("Values are not finite.", $"Color{i}");
			}
			if (v.X < 0f || v.X > 1f)
			{
				throw new ArgumentOutOfRangeException($"Color{i}.R");
			}
			if (v.Y < 0f || v.Y > 1f)
			{
				throw new ArgumentOutOfRangeException($"Color{i}.G");
			}
			if (v.Z < 0f || v.Z > 1f)
			{
				throw new ArgumentOutOfRangeException($"Color{i}.B");
			}
			if (v.W < 0f || v.W > 1f)
			{
				throw new ArgumentOutOfRangeException($"Color{i}.A");
			}
		}
		for (int j = 0; j < vertex.MaxTextCoords; j++)
		{
			Vector2 texCoord = vertex.GetTexCoord(j);
			if (!texCoord._IsFinite())
			{
				throw new ArgumentException("Values are not finite.", $"TexCoord{j}");
			}
		}
		if ((object)vertex is IVertexCustom vertexCustom)
		{
			vertexCustom.Validate();
		}
		return vertex;
	}

	public static TvS? ValidateVertexSkinning<TvS>(TvS vertex) where TvS : struct, IVertexSkinning
	{
		if (vertex.MaxBindings == 0)
		{
			return vertex;
		}
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < vertex.MaxBindings; i++)
		{
			var (num3, num4) = vertex.GetBinding(i);
			if (num3 < 0)
			{
				throw new ArgumentOutOfRangeException($"Joint{i}");
			}
			if (!num4._IsFinite())
			{
				throw new ArgumentException("Values are not finite.", $"Weight{i}");
			}
			if (num4 == 0f)
			{
				SharpGLTF.Guard.IsTrue(num3 == 0, "joints with weight zero must be set to zero");
			}
			num += num4;
			if (num4 > 0f)
			{
				num2 += 2E-07f;
			}
		}
		if (Math.Abs(num - 1f) >= num2)
		{
			throw new ArgumentOutOfRangeException($"Weights must sum 1, but found {num}");
		}
		return vertex;
	}

	public static TvG? SanitizeVertexGeometry<TvG>(TvG vertex) where TvG : struct, IVertexGeometry
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = vertex.GetPosition();
		if (!position._IsFinite())
		{
			return null;
		}
		if (vertex.TryGetNormal(out var normal))
		{
			bool flag = false;
			if (!normal._IsFinite())
			{
				normal = position;
				flag = true;
			}
			if (normal == Vector3.Zero)
			{
				normal = position;
				flag = true;
			}
			if (normal == Vector3.Zero)
			{
				return null;
			}
			float num = ((Vector3)(ref normal)).Length();
			if (Math.Abs(num - 1f) > 0.01f)
			{
				flag = true;
			}
			if (flag)
			{
				vertex.SetNormal(Vector3.Normalize(normal));
			}
		}
		if (vertex.TryGetTangent(out var tangent))
		{
			if (!tangent._IsFinite())
			{
				return null;
			}
			Vector3 val = default(Vector3);
			((Vector3)(ref val))._002Ector(tangent.X, tangent.Y, tangent.Z);
			if (val == Vector3.Zero)
			{
				return null;
			}
			bool flag2 = false;
			if (tangent.W > 0f)
			{
				tangent.W = 1f;
				flag2 = true;
			}
			if (tangent.W < 0f)
			{
				tangent.W = -1f;
				flag2 = true;
			}
			float num2 = ((Vector3)(ref val)).Length();
			if (Math.Abs(num2 - 1f) > 0.01f)
			{
				val = Vector3.Normalize(val);
				flag2 = true;
			}
			if (flag2)
			{
				vertex.SetTangent(new Vector4(val, tangent.W));
			}
		}
		return vertex;
	}

	public static TvM? SanitizeVertexMaterial<TvM>(TvM vertex) where TvM : struct, IVertexMaterial
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < vertex.MaxColors; i++)
		{
			Vector4 v = vertex.GetColor(i);
			if (!v._IsFinite())
			{
				v = Vector4.Zero;
			}
			v = Vector4.Min(Vector4.One, v);
			v = Vector4.Max(Vector4.Zero, v);
			vertex.SetColor(i, v);
		}
		for (int j = 0; j < vertex.MaxTextCoords; j++)
		{
			Vector2 texCoord = vertex.GetTexCoord(j);
			if (!texCoord._IsFinite())
			{
				vertex.SetTexCoord(j, Vector2.Zero);
			}
		}
		return vertex;
	}

	public static TvS? SanitizeVertexSkinning<TvS>(TvS vertex) where TvS : struct, IVertexSkinning
	{
		if (vertex.MaxBindings == 0)
		{
			return vertex;
		}
		SparseWeight8 x = SparseWeight8.OrderedByWeight(vertex.GetBindings());
		float weightSum = x.WeightSum;
		if (weightSum == 0f)
		{
			return default(TvS);
		}
		if (weightSum != 1f)
		{
			x = SparseWeight8.Multiply(in x, 1f / weightSum);
		}
		vertex.SetBindings(in x);
		return vertex;
	}
}
