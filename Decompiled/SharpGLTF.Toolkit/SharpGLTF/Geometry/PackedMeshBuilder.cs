using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using SharpGLTF.Scenes;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry;

internal class PackedMeshBuilder<TMaterial> : BaseBuilder
{
	private readonly List<PackedPrimitiveBuilder<TMaterial>> _Primitives = new List<PackedPrimitiveBuilder<TMaterial>>();

	internal static IEnumerable<PackedMeshBuilder<TMaterial>> CreatePackedMeshes(IEnumerable<IMeshBuilder<TMaterial>> meshBuilders, SceneBuilderSchema2Settings settings)
	{
		SharpGLTF.Guard.NotNull(meshBuilders, "meshBuilders");
		meshBuilders = meshBuilders.EnsureList();
		try
		{
			foreach (IMeshBuilder<TMaterial> meshBuilder in meshBuilders)
			{
				meshBuilder.Validate();
			}
		}
		catch (Exception ex)
		{
			throw new ArgumentException(ex.Message, "meshBuilders", ex);
		}
		PackedEncoding vertexEncodings = new PackedEncoding
		{
			JointsEncoding = meshBuilders.GetOptimalJointEncoding(),
			WeightsEncoding = (settings.CompactVertexWeights ? EncodingType.UNSIGNED_SHORT : EncodingType.FLOAT)
		};
		EncodingType indexEncoding = meshBuilders.GetOptimalIndexEncoding();
		foreach (IMeshBuilder<TMaterial> meshBuilder2 in meshBuilders)
		{
			yield return Create(meshBuilder2, vertexEncodings, indexEncoding, settings);
		}
	}

	private static PackedMeshBuilder<TMaterial> Create(IMeshBuilder<TMaterial> srcMesh, PackedEncoding vertexEncodings, EncodingType indexEncoding, SceneBuilderSchema2Settings settings)
	{
		List<IPrimitiveReader<TMaterial>> list = srcMesh.Primitives.Where((IPrimitiveReader<TMaterial> item) => item.Vertices.Count > 0).ToList();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (IPrimitiveReader<TMaterial> item in list)
		{
			item._GatherMorphTargetAttributes(hashSet);
		}
		if (hashSet.Count > 0)
		{
			settings.UseStridedBuffers = false;
		}
		bool flag = hashSet.Contains("COLOR_0DELTA") || hashSet.Contains("COLOR_1DELTA") || hashSet.Contains("COLOR_2DELTA") || hashSet.Contains("COLOR_3DELTA");
		vertexEncodings.ColorEncoding = (flag ? new EncodingType?(EncodingType.FLOAT) : ((EncodingType?)null));
		PackedMeshBuilder<TMaterial> packedMeshBuilder = new PackedMeshBuilder<TMaterial>(srcMesh.Name, srcMesh.Extras);
		foreach (IPrimitiveReader<TMaterial> item2 in list)
		{
			PackedPrimitiveBuilder<TMaterial> packedPrimitiveBuilder = packedMeshBuilder.AddPrimitive(item2.Material, item2.VerticesPerPrimitive);
			if (settings.UseStridedBuffers)
			{
				packedPrimitiveBuilder.SetStridedVertices(item2, vertexEncodings);
			}
			else
			{
				packedPrimitiveBuilder.SetStreamedVertices(item2, vertexEncodings);
			}
			packedPrimitiveBuilder.SetIndices(item2, indexEncoding);
			if (hashSet.Count > 0)
			{
				packedPrimitiveBuilder.SetMorphTargets(item2, vertexEncodings, hashSet);
			}
		}
		return packedMeshBuilder;
	}

	private PackedMeshBuilder(string name, JsonNode extras)
		: base(name, extras)
	{
	}

	public PackedPrimitiveBuilder<TMaterial> AddPrimitive(TMaterial material, int primitiveVertexCount)
	{
		PackedPrimitiveBuilder<TMaterial> packedPrimitiveBuilder = new PackedPrimitiveBuilder<TMaterial>(material, primitiveVertexCount);
		_Primitives.Add(packedPrimitiveBuilder);
		return packedPrimitiveBuilder;
	}

	public Mesh CreateSchema2Mesh(ModelRoot root, Converter<TMaterial, Material> materialEvaluator)
	{
		if (_Primitives.Count == 0)
		{
			return null;
		}
		Mesh mesh = root.CreateMesh();
		TryCopyNameAndExtrasTo(mesh);
		foreach (PackedPrimitiveBuilder<TMaterial> primitive in _Primitives)
		{
			primitive.CopyToMesh(mesh, materialEvaluator);
		}
		mesh.SetMorphWeights(null);
		return mesh;
	}

	public static void MergeBuffers(IEnumerable<PackedMeshBuilder<TMaterial>> meshes)
	{
		PackedPrimitiveBuilder<TMaterial>.MergeBuffers(meshes.SelectMany((PackedMeshBuilder<TMaterial> m) => m._Primitives));
	}
}
