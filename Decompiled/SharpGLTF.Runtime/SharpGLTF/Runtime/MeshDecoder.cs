using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

public static class MeshDecoder
{
	public static IMeshDecoder<Material> Decode(this Mesh mesh, RuntimeOptions options = null)
	{
		if (mesh == null)
		{
			return null;
		}
		_MeshDecoder<Material> meshDecoder = new _MeshDecoder<Material>(mesh, options);
		meshDecoder.GenerateNormalsAndTangents();
		return meshDecoder;
	}

	public static IMeshDecoder<Material>[] Decode(this IReadOnlyList<Mesh> meshes, RuntimeOptions options = null)
	{
		SharpGLTF.Guard.NotNull(meshes, "meshes");
		return meshes.Select((Mesh item) => item.Decode(options)).ToArray();
	}

	public static Vector3 GetPosition(this IMeshPrimitiveDecoder primitive, int vertexIdx, IGeometryTransform xform)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(vertexIdx, 0, primitive.VertexCount - 1, "vertexIdx");
		SharpGLTF.Guard.NotNull(xform, "xform");
		Vector3 position = primitive.GetPosition(vertexIdx);
		IReadOnlyList<Vector3> positionDeltas = primitive.GetPositionDeltas(vertexIdx);
		return xform.TransformPosition(position, positionDeltas, primitive.GetSkinWeights(vertexIdx));
	}

	public static Vector3 GetNormal(this IMeshPrimitiveDecoder primitive, int vertexIdx, IGeometryTransform xform)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(vertexIdx, 0, primitive.VertexCount - 1, "vertexIdx");
		SharpGLTF.Guard.NotNull(xform, "xform");
		Vector3 normal = primitive.GetNormal(vertexIdx);
		IReadOnlyList<Vector3> normalDeltas = primitive.GetNormalDeltas(vertexIdx);
		return xform.TransformNormal(normal, normalDeltas, primitive.GetSkinWeights(vertexIdx));
	}

	public static Vector4 GetTangent(this IMeshPrimitiveDecoder primitive, int vertexIdx, IGeometryTransform xform)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(vertexIdx, 0, primitive.VertexCount - 1, "vertexIdx");
		SharpGLTF.Guard.NotNull(xform, "xform");
		Vector4 tangent = primitive.GetTangent(vertexIdx);
		IReadOnlyList<Vector3> tangentDeltas = primitive.GetTangentDeltas(vertexIdx);
		return xform.TransformTangent(tangent, tangentDeltas, primitive.GetSkinWeights(vertexIdx));
	}

	public static Vector2 GetTextureCoord(this IMeshPrimitiveDecoder primitive, int vertexIdx, int textureSetIndex, IGeometryTransform xform)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(vertexIdx, 0, primitive.VertexCount - 1, "vertexIdx");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(textureSetIndex, 0, primitive.TexCoordsCount - 1, "textureSetIndex");
		SharpGLTF.Guard.NotNull(xform, "xform");
		Vector2 val = primitive.GetTextureCoord(vertexIdx, textureSetIndex);
		if (xform is IMaterialTransform materialTransform)
		{
			IReadOnlyList<Vector2> textureCoordDeltas = primitive.GetTextureCoordDeltas(vertexIdx, textureSetIndex);
			val = materialTransform.MorphTexCoord(val, textureCoordDeltas);
		}
		return val;
	}

	public static Vector4 GetColor(this IMeshPrimitiveDecoder primitive, int vertexIdx, int colorSetIndex, IGeometryTransform xform)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(vertexIdx, 0, primitive.VertexCount - 1, "vertexIdx");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(colorSetIndex, 0, primitive.ColorsCount - 1, "colorSetIndex");
		SharpGLTF.Guard.NotNull(xform, "xform");
		Vector4 val = primitive.GetColor(vertexIdx, colorSetIndex);
		if (xform is IMaterialTransform materialTransform)
		{
			IReadOnlyList<Vector4> colorDeltas = primitive.GetColorDeltas(vertexIdx, colorSetIndex);
			val = materialTransform.MorphColors(val, colorDeltas);
		}
		return val;
	}

	public static (Vector3 Min, Vector3 Max) EvaluateBoundingBox(this Scene scene, float samplingTimeStep = 1f)
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(scene, "scene");
		IMeshDecoder<Material>[] meshes = scene.LogicalParent.LogicalMeshes.Decode();
		SceneTemplate sceneTemplate = SceneTemplate.Create(scene);
		SceneInstance sceneInstance = sceneTemplate.CreateInstance();
		ArmatureInstance armature = sceneInstance.Armature;
		if (armature.AnimationTracks.Count == 0)
		{
			armature.SetPoseTransforms();
			return sceneInstance.EvaluateBoundingBox(meshes);
		}
		Vector3 val = default(Vector3);
		((Vector3)(ref val))._002Ector(float.PositiveInfinity);
		Vector3 val2 = default(Vector3);
		((Vector3)(ref val2))._002Ector(float.NegativeInfinity);
		for (int i = 0; i < armature.AnimationTracks.Count; i++)
		{
			float duration = armature.AnimationTracks[i].Duration;
			for (float num = 0f; num < duration; num += samplingTimeStep)
			{
				armature.SetAnimationFrame(i, num);
				(Vector3 Min, Vector3 Max) tuple = sceneInstance.EvaluateBoundingBox(meshes);
				Vector3 item = tuple.Min;
				Vector3 item2 = tuple.Max;
				val = Vector3.Min(val, item);
				val2 = Vector3.Max(val2, item2);
			}
		}
		return (Min: val, Max: val2);
	}

	public static (Vector3 Center, float Radius) EvaluateBoundingSphere(this Scene scene, float samplingTimeStep = 1f)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(scene, "scene");
		IMeshDecoder<Material>[] meshes = scene.LogicalParent.LogicalMeshes.Decode();
		SceneTemplate sceneTemplate = SceneTemplate.Create(scene);
		SceneInstance sceneInstance = sceneTemplate.CreateInstance();
		ArmatureInstance armature = sceneInstance.Armature;
		if (armature.AnimationTracks.Count == 0)
		{
			armature.SetPoseTransforms();
			return sceneInstance.EvaluateBoundingSphere(meshes);
		}
		Vector3 c = Vector3.Zero;
		float r = -1f;
		for (int i = 0; i < armature.AnimationTracks.Count; i++)
		{
			float duration = armature.AnimationTracks[i].Duration;
			for (float num = 0f; num < duration; num += samplingTimeStep)
			{
				armature.SetAnimationFrame(i, num);
				var (c2, r2) = sceneInstance.EvaluateBoundingSphere(meshes);
				_MergeSphere(ref c, ref r, c2, r2);
			}
		}
		return (Center: c, Radius: r);
	}

	public static (Vector3 Min, Vector3 Max) EvaluateBoundingBox<TMaterial>(this SceneInstance instance, IReadOnlyList<IMeshDecoder<TMaterial>> meshes) where TMaterial : class
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(instance, "instance");
		SharpGLTF.Guard.NotNull(meshes, "meshes");
		Vector3 val = default(Vector3);
		((Vector3)(ref val))._002Ector(float.PositiveInfinity);
		Vector3 val2 = default(Vector3);
		((Vector3)(ref val2))._002Ector(float.NegativeInfinity);
		foreach (Vector3 worldVertex in instance.GetWorldVertices(meshes))
		{
			val = Vector3.Min(val, worldVertex);
			val2 = Vector3.Max(val2, worldVertex);
		}
		return (Min: val, Max: val2);
	}

	public static (Vector3 Center, float Radius) EvaluateBoundingSphere<TMaterial>(this SceneInstance instance, IReadOnlyList<IMeshDecoder<TMaterial>> meshes) where TMaterial : class
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(instance, "instance");
		SharpGLTF.Guard.NotNull(meshes, "meshes");
		Vector3 c = Vector3.Zero;
		float r = -1f;
		foreach (Vector3 worldVertex in instance.GetWorldVertices(meshes))
		{
			_AddPointToSphere(ref c, ref r, worldVertex);
		}
		return (Center: c, Radius: r);
	}

	private static void _AddPointToSphere(ref Vector3 c1, ref float r1, Vector3 c2)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (r1 < 0f)
		{
			c1 = c2;
			r1 = 0f;
			return;
		}
		Vector3 val = c2 - c1;
		float num = ((Vector3)(ref val)).Length();
		if (!(num <= r1))
		{
			val /= num;
			Vector3 val2 = c1 - val * r1;
			c1 = (val2 + c2) / 2f;
			Vector3 val3 = val2 - c2;
			r1 = ((Vector3)(ref val3)).Length() / 2f;
		}
	}

	private static void _MergeSphere(ref Vector3 c1, ref float r1, Vector3 c2, float r2)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (r1 < 0f)
		{
			c1 = c2;
			r1 = r2;
			return;
		}
		Vector3 val = c2 - c1;
		float num = ((Vector3)(ref val)).Length();
		if (!(r1 >= r2 + num))
		{
			if (r2 >= r1 + num)
			{
				c1 = c2;
				r1 = r2;
				return;
			}
			val /= num;
			Vector3 val2 = c1 - val * r1;
			Vector3 val3 = c2 + val * r2;
			c1 = (val2 + val3) / 2f;
			Vector3 val4 = val2 - val3;
			r1 = ((Vector3)(ref val4)).Length() / 2f;
		}
	}

	public static IEnumerable<Vector3> GetWorldVertices<TMaterial>(this SceneInstance instance, IReadOnlyList<IMeshDecoder<TMaterial>> meshes) where TMaterial : class
	{
		SharpGLTF.Guard.NotNull(instance, "instance");
		SharpGLTF.Guard.NotNull(meshes, "meshes");
		for (int i = 0; i < meshes.Count; i++)
		{
			SharpGLTF.Guard.MustBeEqualTo(meshes[i].LogicalIndex, i, "meshes" + $"[{i}]");
		}
		return instance.Where((DrawableInstance item) => item.Transform.Visible).SelectMany((DrawableInstance item) => meshes[item.Template.LogicalMeshIndex].GetWorldVertices(item.Transform));
	}

	public static IEnumerable<Vector3> GetWorldVertices<TMaterial>(this IMeshDecoder<TMaterial> mesh, IGeometryTransform xform) where TMaterial : class
	{
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		SharpGLTF.Guard.NotNull(xform, "xform");
		foreach (IGeometryTransform childXform in InstancingTransform.Evaluate(xform))
		{
			foreach (IMeshPrimitiveDecoder<TMaterial> primitive in mesh.Primitives)
			{
				int i = 0;
				while (i < primitive.VertexCount)
				{
					yield return primitive.GetPosition(i, childXform);
					int num = i + 1;
					i = num;
				}
			}
		}
	}
}
