using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Animations;
using SharpGLTF.Geometry;
using SharpGLTF.Materials;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Scenes;

internal class Schema2SceneBuilder
{
	public interface IOperator<T>
	{
		void ApplyTo(T target, Schema2SceneBuilder context);
	}

	private readonly Dictionary<MaterialBuilder, Material> _Materials = new Dictionary<MaterialBuilder, Material>();

	private readonly Dictionary<IMeshBuilder<MaterialBuilder>, Mesh> _Meshes = new Dictionary<IMeshBuilder<MaterialBuilder>, Mesh>();

	private readonly Dictionary<NodeBuilder, Node> _Nodes = new Dictionary<NodeBuilder, Node>();

	public int GpuMeshInstancingMinCount { get; set; }

	public Mesh GetMesh(IMeshBuilder<MaterialBuilder> key)
	{
		if (key != null)
		{
			if (!_Meshes.TryGetValue(key, out var value))
			{
				return null;
			}
			return value;
		}
		return null;
	}

	public Node GetNode(NodeBuilder key)
	{
		if (key != null)
		{
			if (!_Nodes.TryGetValue(key, out var value))
			{
				return null;
			}
			return value;
		}
		return null;
	}

	public static bool HasContent(Node node, bool checkTransform = true)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (checkTransform && node.LocalMatrix != Matrix4x4.Identity)
		{
			return true;
		}
		if (node.VisualChildren.Any())
		{
			return true;
		}
		if (node.Mesh != null)
		{
			return true;
		}
		if (node.Skin != null)
		{
			return true;
		}
		if (node.Camera != null)
		{
			return true;
		}
		if (node.PunctualLight != null)
		{
			return true;
		}
		if (node.GetGpuInstancing() != null)
		{
			return true;
		}
		return false;
	}

	public void AddGeometryResources(ModelRoot root, IEnumerable<SceneBuilder> srcScenes, SceneBuilderSchema2Settings settings)
	{
		IMeshBuilder<MaterialBuilder>[] array = (from item in srcScenes.SelectMany((SceneBuilder item) => item.Instances)
			select item.Content?.GetGeometryAsset() into item
			where !item.IsEmpty()
			select item).Distinct().ToArray();
		IEnumerable<IGrouping<MaterialBuilder, MaterialBuilder>> enumerable = (from item in array.SelectMany((IMeshBuilder<MaterialBuilder> item) => item.Primitives)
			where !item.IsEmpty()
			select item.Material).Distinct().ToList().GroupBy((MaterialBuilder item) => item, MaterialBuilder.ContentComparer);
		foreach (IGrouping<MaterialBuilder, MaterialBuilder> item in enumerable)
		{
			Material value = root.CreateMaterial(item.Key);
			foreach (MaterialBuilder item2 in item)
			{
				_Materials[item2] = value;
			}
		}
		IReadOnlyList<Mesh> readOnlyList = root.CreateMeshes((MaterialBuilder mat) => _Materials[mat], settings, array);
		for (int num = 0; num < array.Length; num++)
		{
			_Meshes[array[num]] = readOnlyList[num];
		}
	}

	private void AddArmatureResources(IEnumerable<SceneBuilder> srcScenes, Func<Node> nodeFactory)
	{
		List<NodeBuilder> list = (from item in srcScenes.SelectMany((SceneBuilder item) => item.Instances)
			select item.Content?.GetArmatureRoot() into item
			where item != null
			select item.Root).Distinct().ToList();
		foreach (NodeBuilder item in list)
		{
			CreateArmature(item, nodeFactory);
		}
	}

	private void CreateArmature(NodeBuilder srcNode, Func<Node> nodeFactory)
	{
		Node dstNode = nodeFactory();
		srcNode.TryCopyNameAndExtrasTo(dstNode);
		_Nodes[srcNode] = dstNode;
		if (srcNode.HasAnimations)
		{
			dstNode.LocalTransform = srcNode.LocalTransform.GetDecomposed();
			if (srcNode.Scale != null)
			{
				foreach (KeyValuePair<string, ICurveSampler<Vector3>> track in srcNode.Scale.Tracks)
				{
					dstNode.WithScaleAnimation(track.Key, track.Value);
				}
			}
			if (srcNode.Rotation != null)
			{
				foreach (KeyValuePair<string, ICurveSampler<Quaternion>> track2 in srcNode.Rotation.Tracks)
				{
					dstNode.WithRotationAnimation(track2.Key, track2.Value);
				}
			}
			if (srcNode.Translation != null)
			{
				foreach (KeyValuePair<string, ICurveSampler<Vector3>> track3 in srcNode.Translation.Tracks)
				{
					dstNode.WithTranslationAnimation(track3.Key, track3.Value);
				}
			}
		}
		else
		{
			dstNode.LocalTransform = srcNode.LocalTransform;
		}
		foreach (NodeBuilder visualChild in srcNode.VisualChildren)
		{
			CreateArmature(visualChild, () => dstNode.CreateNode());
		}
	}

	public static void SetMorphAnimation(Node dstNode, AnimatableProperty<SparseWeight8> animation)
	{
		SharpGLTF.Guard.NotNull(dstNode, "dstNode");
		SharpGLTF.Guard.NotNull(dstNode.Mesh, "Mesh", "call after IOperator.ApplyTo");
		if (animation == null)
		{
			return;
		}
		Mesh mesh = dstNode.Mesh;
		mesh.SetMorphWeights(animation.Value);
		foreach (KeyValuePair<string, ICurveSampler<SparseWeight8>> track in animation.Tracks)
		{
			dstNode.WithMorphingAnimation(track.Key, track.Value);
		}
	}

	public static void SetMorphAnimation(Node dstNode, AnimatableProperty<ArraySegment<float>> animation)
	{
		SharpGLTF.Guard.NotNull(dstNode, "dstNode");
		SharpGLTF.Guard.NotNull(dstNode.Mesh, "Mesh", "call after IOperator.ApplyTo");
		if (animation == null)
		{
			return;
		}
		Mesh mesh = dstNode.Mesh;
		mesh.SetMorphWeights(animation.Value);
		foreach (KeyValuePair<string, ICurveSampler<ArraySegment<float>>> track in animation.Tracks)
		{
			dstNode.WithMorphingAnimation(track.Key, track.Value);
		}
	}

	public void AddScene(Scene dstScene, SceneBuilder srcScene)
	{
		_Nodes.Clear();
		AddArmatureResources(new SceneBuilder[1] { srcScene }, () => dstScene.CreateNode());
		AddMeshes(dstScene, srcScene);
		AddLightsAndCameras(dstScene, srcScene);
	}

	private void AddMeshes(Scene dstScene, SceneBuilder srcScene)
	{
		IEnumerable<IOperator<Scene>> first = (from item in srcScene.Instances
			select item.Content into item
			where !item.GetGeometryAsset().IsEmpty()
			select item).OfType<IOperator<Scene>>();
		IEnumerable<FixedTransformer> instances = (from item in srcScene.Instances
			select item.Content into item
			where !item.GetGeometryAsset().IsEmpty()
			select item).OfType<FixedTransformer>();
		IEnumerable<IOperator<Scene>> second = _MeshInstancing.CreateFrom(instances, GpuMeshInstancingMinCount);
		IEnumerable<IOperator<Scene>> enumerable = first.Concat(second);
		foreach (IOperator<Scene> item in enumerable)
		{
			item.ApplyTo(dstScene, this);
		}
	}

	private void AddLightsAndCameras(Scene dstScene, SceneBuilder srcScene)
	{
		IEnumerable<IOperator<Scene>> first = srcScene.Instances.Select((InstanceBuilder item) => item.Content).Where(isCameraOrLight).OfType<RigidTransformer>()
			.Cast<IOperator<Scene>>();
		IEnumerable<IOperator<Scene>> second = (from item in srcScene.Instances.Select((InstanceBuilder item) => item.Content).Where(isCameraOrLight).OfType<FixedTransformer>()
			select new _FixedIntance(item)).Cast<IOperator<Scene>>();
		IEnumerable<IOperator<Scene>> enumerable = first.Concat(second);
		foreach (IOperator<Scene> item in enumerable)
		{
			item.ApplyTo(dstScene, this);
		}
		static bool isCameraOrLight(ContentTransformer xformer)
		{
			if (xformer?.Content is CameraContent)
			{
				return true;
			}
			if (xformer?.Content is LightContent)
			{
				return true;
			}
			return false;
		}
	}
}
