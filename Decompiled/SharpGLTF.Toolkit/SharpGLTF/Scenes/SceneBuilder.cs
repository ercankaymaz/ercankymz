using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using SharpGLTF.Animations;
using SharpGLTF.Geometry;
using SharpGLTF.Materials;
using SharpGLTF.Runtime;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("Scene {Name}")]
public class SceneBuilder(string name = null) : BaseBuilder(name), IConvertibleToGltf2
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal readonly List<InstanceBuilder> _Instances = new List<InstanceBuilder>();

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public IReadOnlyList<InstanceBuilder> Instances => _Instances;

	public IEnumerable<MaterialBuilder> Materials => _Instances.SelectMany((InstanceBuilder item) => item.Materials).Distinct(MaterialBuilder.ReferenceComparer);

	internal IEnumerable<string> AnimationTrackNames => _Instances.SelectMany((InstanceBuilder item) => item.Content.GetAnimationTracksNames()).Distinct();

	public SceneBuilder DeepClone(bool cloneArmatures = true)
	{
		SceneBuilder sceneBuilder = new SceneBuilder();
		sceneBuilder.SetNameAndExtrasFrom(this);
		Dictionary<NodeBuilder, NodeBuilder> dictionary = new Dictionary<NodeBuilder, NodeBuilder>();
		if (cloneArmatures)
		{
			foreach (NodeBuilder item2 in FindArmatures())
			{
				Dictionary<NodeBuilder, NodeBuilder> dictionary2 = item2.DeepClone();
				foreach (KeyValuePair<NodeBuilder, NodeBuilder> item3 in dictionary2)
				{
					dictionary[item3.Key] = item3.Value;
				}
			}
		}
		ContentTransformer.DeepCloneContext args = new ContentTransformer.DeepCloneContext(dictionary);
		foreach (InstanceBuilder instance in _Instances)
		{
			InstanceBuilder item = instance._CopyTo(sceneBuilder, args);
			sceneBuilder._Instances.Add(item);
		}
		return sceneBuilder;
	}

	[Obsolete("Use LoadDefaultScene(...); or LoadAllScenes(...) instead.", true)]
	public static SceneBuilder Load(string filePath, ReadSettings settings = null)
	{
		return LoadDefaultScene(filePath, settings);
	}

	public static SceneBuilder LoadDefaultScene(string filePath, ReadSettings settings = null)
	{
		ModelRoot modelRoot = ModelRoot.Load(filePath, settings);
		return CreateFrom(modelRoot.DefaultScene);
	}

	public static SceneBuilder[] LoadAllScenes(string filePath, ReadSettings settings = null)
	{
		ModelRoot model = ModelRoot.Load(filePath, settings);
		return CreateFrom(model);
	}

	public InstanceBuilder AddRigidMesh(IMeshBuilder<MaterialBuilder> mesh, NodeBuilder node)
	{
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		SharpGLTF.Guard.NotNull(node, "node");
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new RigidTransformer(mesh, node);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddRigidMesh(IMeshBuilder<MaterialBuilder> mesh, AffineTransform meshWorldTransform)
	{
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new FixedTransformer(mesh, meshWorldTransform);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddRigidMesh(IMeshBuilder<MaterialBuilder> mesh, NodeBuilder node, AffineTransform instanceTransform)
	{
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		SharpGLTF.Guard.NotNull(node, "node");
		if (instanceTransform.IsIdentity)
		{
			return AddRigidMesh(mesh, node);
		}
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new FixedTransformer(mesh, node, instanceTransform);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddSkinnedMesh(IMeshBuilder<MaterialBuilder> mesh, Matrix4x4 meshWorldMatrix, params NodeBuilder[] joints)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		Matrix4x4Factory.GuardMatrix("meshWorldMatrix", meshWorldMatrix, Matrix4x4Factory.MatrixCheck.WorldTransform);
		SharpGLTF.Guard.NotNull(joints, "joints");
		SharpGLTF.GuardAll.NotNull(joints, "joints");
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new SkinnedTransformer(mesh, meshWorldMatrix, joints);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddSkinnedMesh(IMeshBuilder<MaterialBuilder> mesh, params (NodeBuilder Joint, Matrix4x4 InverseBindMatrix)[] joints)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		SharpGLTF.GuardAll.NotNull(joints.Select(((NodeBuilder Joint, Matrix4x4 InverseBindMatrix) item) => item.Joint), "joints");
		for (int num = 0; num < joints.Length; num++)
		{
			Matrix4x4Factory.GuardMatrix(string.Format("{0}[{1}]", "joints", num), joints[num].InverseBindMatrix, Matrix4x4Factory.MatrixCheck.WorldTransform, 0.01f);
		}
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new SkinnedTransformer(mesh, joints);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddCamera(CameraBuilder camera, NodeBuilder node)
	{
		SharpGLTF.Guard.NotNull(camera, "camera");
		SharpGLTF.Guard.NotNull(node, "node");
		CameraContent content = new CameraContent(camera);
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new RigidTransformer(content, node);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddCamera(CameraBuilder camera, Vector3 cameraPosition, Vector3 targetPosition)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(camera, "camera");
		SharpGLTF.Guard.IsTrue(cameraPosition._IsFinite(), "cameraPosition");
		SharpGLTF.Guard.IsTrue(targetPosition._IsFinite(), "targetPosition");
		Matrix4x4 val = Matrix4x4.CreateWorld(cameraPosition, Vector3.Normalize(targetPosition - cameraPosition), Vector3.UnitY);
		return AddCamera(camera, val);
	}

	public InstanceBuilder AddCamera(CameraBuilder camera, AffineTransform cameraTransform)
	{
		SharpGLTF.Guard.NotNull(camera, "camera");
		CameraContent content = new CameraContent(camera);
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new FixedTransformer(content, cameraTransform);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddLight(LightBuilder light, AffineTransform lightTransform)
	{
		SharpGLTF.Guard.NotNull(light, "light");
		LightContent content = new LightContent(light);
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new FixedTransformer(content, lightTransform);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddLight(LightBuilder light, NodeBuilder node)
	{
		SharpGLTF.Guard.NotNull(light, "light");
		SharpGLTF.Guard.NotNull(node, "node");
		LightContent content = new LightContent(light);
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		instanceBuilder.Content = new RigidTransformer(content, node);
		_Instances.Add(instanceBuilder);
		return instanceBuilder;
	}

	public InstanceBuilder AddNode(NodeBuilder node)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		EmptyContent content = new EmptyContent();
		InstanceBuilder instanceBuilder = new InstanceBuilder(this);
		_Instances.Add(instanceBuilder);
		instanceBuilder.Content = new RigidTransformer(content, node);
		return instanceBuilder;
	}

	public IReadOnlyList<NodeBuilder> FindArmatures()
	{
		return (from item in _Instances
			select item.Content.GetArmatureRoot() into item
			where item != null
			select item).Distinct().ToList();
	}

	public void ApplyBasisTransform(Matrix4x4 basisTransform, string basisNodeName = "BasisTransform")
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		if (basisTransform == Matrix4x4.Identity)
		{
			return;
		}
		Matrix4x4Factory.GuardMatrix("basisTransform", basisTransform, Matrix4x4Factory.MatrixCheck.WorldTransform);
		foreach (FixedTransformer item in _Instances.Select((InstanceBuilder item) => item.Content).OfType<FixedTransformer>())
		{
			item.ChildTransform = AffineTransform.Multiply(item.ChildTransform, (AffineTransform)basisTransform);
		}
		IReadOnlyList<NodeBuilder> readOnlyList = FindArmatures();
		List<NodeBuilder> list = readOnlyList.Where((NodeBuilder item) => isExtrinsic(item)).ToList();
		List<NodeBuilder> list2 = readOnlyList.Except(list).ToList();
		foreach (NodeBuilder item2 in list2)
		{
			item2.LocalMatrix *= basisTransform;
		}
		if (list.Count == 0)
		{
			return;
		}
		NodeBuilder nodeBuilder = new NodeBuilder();
		nodeBuilder.Name = basisNodeName;
		nodeBuilder.LocalMatrix = basisTransform;
		foreach (NodeBuilder item3 in list)
		{
			nodeBuilder.AddNode(item3);
		}
		static bool isExtrinsic(NodeBuilder node)
		{
			if (node.Scale != null)
			{
				return true;
			}
			if (node.Rotation != null)
			{
				return true;
			}
			if (node.Translation != null)
			{
				return true;
			}
			if (node.HasAnimations)
			{
				return true;
			}
			return false;
		}
	}

	public IReadOnlyList<InstanceBuilder> AddScene(SceneBuilder scene, Matrix4x4 sceneTransform)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(scene, "scene");
		Matrix4x4Factory.GuardMatrix("sceneTransform", sceneTransform, Matrix4x4Factory.MatrixCheck.WorldTransform);
		scene = scene.DeepClone();
		scene.ApplyBasisTransform(sceneTransform);
		_Instances.AddRange(scene._Instances);
		return scene._Instances;
	}

	public ModelRoot ToGltf2()
	{
		return ToGltf2(new SceneBuilder[1] { this }, SceneBuilderSchema2Settings.Default);
	}

	public ModelRoot ToGltf2(SceneBuilderSchema2Settings settings)
	{
		return ToGltf2(new SceneBuilder[1] { this }, settings);
	}

	public static ModelRoot ToGltf2(IEnumerable<SceneBuilder> srcScenes, SceneBuilderSchema2Settings settings)
	{
		SharpGLTF.Guard.NotNull(srcScenes, "srcScenes");
		Schema2SceneBuilder schema2SceneBuilder = new Schema2SceneBuilder();
		schema2SceneBuilder.GpuMeshInstancingMinCount = settings.GpuMeshInstancingMinCount;
		ModelRoot modelRoot = ModelRoot.CreateModel();
		schema2SceneBuilder.AddGeometryResources(modelRoot, srcScenes, settings);
		foreach (SceneBuilder srcScene in srcScenes)
		{
			Scene scene = modelRoot.UseScene(modelRoot.LogicalScenes.Count);
			srcScene.TryCopyNameAndExtrasTo(scene);
			schema2SceneBuilder.AddScene(scene, srcScene);
		}
		modelRoot.DefaultScene = modelRoot.LogicalScenes[0];
		if (settings.MergeBuffers)
		{
			modelRoot.MergeBuffers();
		}
		return modelRoot;
	}

	public static SceneBuilder[] CreateFrom(ModelRoot model)
	{
		if (model != null)
		{
			return CreateFrom(model.LogicalScenes).ToArray();
		}
		return Array.Empty<SceneBuilder>();
	}

	public static SceneBuilder CreateFrom(Scene srcScene)
	{
		if (srcScene == null)
		{
			return null;
		}
		Dictionary<Node, IMeshBuilder<MaterialBuilder>> meshInstances = _GatherMeshInstances(Node.Flatten(srcScene));
		return _CreateFrom(srcScene, meshInstances);
	}

	public static IEnumerable<SceneBuilder> CreateFrom(IEnumerable<Scene> srcScenes)
	{
		if (srcScenes == null)
		{
			yield break;
		}
		srcScenes = srcScenes.Distinct();
		Dictionary<Node, IMeshBuilder<MaterialBuilder>> dstMeshIntances = _GatherMeshInstances(srcScenes.SelectMany((Scene s) => Node.Flatten(s)));
		foreach (Scene srcScene in srcScenes)
		{
			yield return _CreateFrom(srcScene, dstMeshIntances);
		}
	}

	private static SceneBuilder _CreateFrom(Scene srcScene, IReadOnlyDictionary<Node, IMeshBuilder<MaterialBuilder>> meshInstances)
	{
		Dictionary<Node, NodeBuilder> dictionary = new Dictionary<Node, NodeBuilder>();
		foreach (Node visualChild in srcScene.VisualChildren)
		{
			NodeBuilder dstNode = new NodeBuilder();
			_CopyToNodeBuilder(dstNode, visualChild, dictionary);
		}
		SceneBuilder sceneBuilder = new SceneBuilder();
		sceneBuilder.SetNameAndExtrasFrom(srcScene);
		_AddMeshInstances(sceneBuilder, Node.Flatten(srcScene), dictionary, meshInstances);
		List<Node> list = (from item in Node.Flatten(srcScene)
			where item.Camera != null
			select item).ToList();
		_AddCameraInstances(sceneBuilder, dictionary, list);
		List<Node> list2 = (from item in Node.Flatten(srcScene)
			where item.PunctualLight != null
			select item).ToList();
		_AddLightInstances(sceneBuilder, dictionary, list2);
		List<Node> srcInstances = (from item in Node.Flatten(srcScene).Except(meshInstances.Keys).Except(list)
				.Except(list2)
			where item.Name != null
			select item).ToList();
		_AddEmptyInstances(sceneBuilder, dictionary, srcInstances);
		return sceneBuilder;
	}

	private static Dictionary<Node, IMeshBuilder<MaterialBuilder>> _GatherMeshInstances(IEnumerable<Node> srcNodes)
	{
		List<Node> source = srcNodes.Where((Node item) => item.Mesh != null).ToList();
		Dictionary<Mesh, IMeshBuilder<MaterialBuilder>> srcMeshes = source.Select((Node item) => item.Mesh).Distinct().ToDictionary((Mesh item) => item, (Mesh item) => item.ToMeshBuilder());
		return source.ToDictionary((Node item) => item, (Node item) => srcMeshes[item.Mesh]);
	}

	private static void _AddMeshInstances(SceneBuilder dstScene, IEnumerable<Node> srcNodes, IReadOnlyDictionary<Node, NodeBuilder> nodesDict, IReadOnlyDictionary<Node, IMeshBuilder<MaterialBuilder>> meshesDict)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		foreach (Node srcNode in srcNodes)
		{
			if (!meshesDict.TryGetValue(srcNode, out var value))
			{
				continue;
			}
			if (srcNode.Skin == null)
			{
				NodeBuilder node = nodesDict[srcNode];
				MeshGpuInstancing gpuInstancing = srcNode.GetGpuInstancing();
				if (gpuInstancing == null)
				{
					InstanceBuilder dstInst = dstScene.AddRigidMesh(value, node);
					_CopyMorphingAnimation(dstInst, srcNode);
					continue;
				}
				foreach (AffineTransform localTransform in gpuInstancing.LocalTransforms)
				{
					InstanceBuilder dstInst2 = dstScene.AddRigidMesh(value, node, localTransform);
					_CopyMorphingAnimation(dstInst2, srcNode);
				}
			}
			else
			{
				(NodeBuilder, Matrix4x4)[] array = new(NodeBuilder, Matrix4x4)[srcNode.Skin.JointsCount];
				for (int i = 0; i < array.Length; i++)
				{
					var (key, item) = srcNode.Skin.GetJoint(i);
					array[i] = (nodesDict[key], item);
				}
				InstanceBuilder dstInst3 = dstScene.AddSkinnedMesh(value, array);
				_CopyMorphingAnimation(dstInst3, srcNode);
			}
		}
	}

	private static void _AddCameraInstances(SceneBuilder dstScene, IReadOnlyDictionary<Node, NodeBuilder> dstNodes, IReadOnlyList<Node> srcInstances)
	{
		if (srcInstances.Count == 0)
		{
			return;
		}
		foreach (Node srcInstance in srcInstances)
		{
			NodeBuilder node = dstNodes[srcInstance];
			Camera camera = srcInstance.Camera;
			if (camera != null)
			{
				CameraBuilder cameraBuilder = null;
				if (camera.Settings is CameraPerspective persp)
				{
					cameraBuilder = new CameraBuilder.Perspective(persp);
				}
				if (camera.Settings is CameraOrthographic ortho)
				{
					cameraBuilder = new CameraBuilder.Orthographic(ortho);
				}
				if (cameraBuilder != null)
				{
					cameraBuilder.SetNameAndExtrasFrom(camera);
					dstScene.AddCamera(cameraBuilder, node);
				}
			}
		}
	}

	private static void _AddLightInstances(SceneBuilder dstScene, IReadOnlyDictionary<Node, NodeBuilder> dstNodes, IReadOnlyList<Node> srcInstances)
	{
		if (srcInstances.Count == 0)
		{
			return;
		}
		foreach (Node srcInstance in srcInstances)
		{
			NodeBuilder node = dstNodes[srcInstance];
			PunctualLight punctualLight = srcInstance.PunctualLight;
			if (punctualLight != null)
			{
				LightBuilder lightBuilder = null;
				if (punctualLight.LightType == PunctualLightType.Directional)
				{
					lightBuilder = new LightBuilder.Directional(punctualLight);
				}
				if (punctualLight.LightType == PunctualLightType.Point)
				{
					lightBuilder = new LightBuilder.Point(punctualLight);
				}
				if (punctualLight.LightType == PunctualLightType.Spot)
				{
					lightBuilder = new LightBuilder.Spot(punctualLight);
				}
				if (lightBuilder != null)
				{
					lightBuilder.SetNameAndExtrasFrom(srcInstance);
					dstScene.AddLight(lightBuilder, node);
				}
			}
		}
	}

	private static void _AddEmptyInstances(SceneBuilder dstScene, IReadOnlyDictionary<Node, NodeBuilder> dstNodes, IReadOnlyList<Node> srcInstances)
	{
		if (srcInstances.Count == 0)
		{
			return;
		}
		foreach (Node srcInstance in srcInstances)
		{
			NodeBuilder node = dstNodes[srcInstance];
			dstScene.AddNode(node);
		}
	}

	private static void _CopyToNodeBuilder(NodeBuilder dstNode, Node srcNode, IDictionary<Node, NodeBuilder> nodeMapping)
	{
		SharpGLTF.Guard.NotNull(srcNode, "srcNode");
		SharpGLTF.Guard.NotNull(dstNode, "dstNode");
		dstNode.SetNameAndExtrasFrom(srcNode);
		dstNode.LocalTransform = srcNode.LocalTransform;
		_CopyTransformAnimation(dstNode, srcNode);
		if (nodeMapping == null)
		{
			return;
		}
		nodeMapping[srcNode] = dstNode;
		foreach (Node visualChild in srcNode.VisualChildren)
		{
			NodeBuilder dstNode2 = dstNode.CreateNode();
			_CopyToNodeBuilder(dstNode2, visualChild, nodeMapping);
		}
	}

	private static void _CopyTransformAnimation(NodeBuilder dstNode, Node srcNode)
	{
		foreach (Animation logicalAnimation in srcNode.LogicalParent.LogicalAnimations)
		{
			string text = logicalAnimation.Name;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = logicalAnimation.LogicalIndex.ToString(CultureInfo.InvariantCulture);
			}
			NodeCurveSamplers curveSamplers = srcNode.GetCurveSamplers(logicalAnimation);
			if (curveSamplers.Scale != null)
			{
				dstNode.UseScale(text).SetCurve(curveSamplers.Scale);
			}
			if (curveSamplers.Rotation != null)
			{
				dstNode.UseRotation(text).SetCurve(curveSamplers.Rotation);
			}
			if (curveSamplers.Translation != null)
			{
				dstNode.UseTranslation(text).SetCurve(curveSamplers.Translation);
			}
		}
	}

	private static void _CopyMorphingAnimation(InstanceBuilder dstInst, Node srcNode)
	{
		bool flag = false;
		IReadOnlyList<float> morphWeights = srcNode.GetMorphWeights();
		if (morphWeights != null && morphWeights.Count > 0)
		{
			dstInst.Content.UseMorphing().SetValue(morphWeights.ToArray());
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		foreach (Animation logicalAnimation in srcNode.LogicalParent.LogicalAnimations)
		{
			string text = logicalAnimation.Name;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = logicalAnimation.LogicalIndex.ToString(CultureInfo.InvariantCulture);
			}
			IAnimationSampler<ArraySegment<float>> morphingSampler = srcNode.GetCurveSamplers(logicalAnimation).GetMorphingSampler<ArraySegment<float>>();
			if (morphingSampler != null)
			{
				CurveBuilder<ArraySegment<float>> curveBuilder = dstInst.Content.UseMorphing(text);
				curveBuilder.SetCurve(morphingSampler);
				_VerifyCurveConversion(morphingSampler, curveBuilder, (ArraySegment<float> a, ArraySegment<float> b) => MemoryExtensions.AsSpan(a).SequenceEqual(b));
			}
		}
	}

	internal static void _VerifyCurveConversion<T>(IAnimationSampler<T> a, IConvertibleCurve<T> b, Func<T, T, bool> equalityComparer)
	{
		if (a.InterpolationMode == AnimationInterpolationMode.CUBICSPLINE)
		{
			if (b.MaxDegree != 3)
			{
				throw new ArgumentException("MaxDegree must be 3", "b");
			}
			IReadOnlyDictionary<float, (T, T, T)> readOnlyDictionary = b.ToSplineCurve();
			foreach (var (num, tuple2) in a.GetCubicKeys())
			{
				if (!readOnlyDictionary.TryGetValue(num, out var value))
				{
					throw new ArgumentException($"Missing key {num}", "b");
				}
				if (!equalityComparer(tuple2.Item1, value.Item1))
				{
					throw new ArgumentException("Conversion failed.", "b");
				}
				if (!equalityComparer(tuple2.Item2, value.Item2))
				{
					throw new ArgumentException("Conversion failed.", "b");
				}
				if (!equalityComparer(tuple2.Item3, value.Item3))
				{
					throw new ArgumentException("Conversion failed.", "b");
				}
			}
		}
		else if (a.InterpolationMode == AnimationInterpolationMode.LINEAR)
		{
			if (b.MaxDegree != 1)
			{
				throw new ArgumentException("MaxDegree");
			}
			IReadOnlyDictionary<float, T> readOnlyDictionary2 = b.ToLinearCurve();
			foreach (var (num2, arg) in a.GetLinearKeys())
			{
				if (!readOnlyDictionary2.TryGetValue(num2, out var value2))
				{
					throw new ArgumentException($"Missing key {num2}", "b");
				}
				if (!equalityComparer(arg, value2))
				{
					throw new ArgumentException("Conversion failed.", "b");
				}
			}
		}
		if (a.InterpolationMode != AnimationInterpolationMode.STEP)
		{
			return;
		}
		if (b.MaxDegree != 0)
		{
			throw new ArgumentException("MaxDegree");
		}
		IReadOnlyDictionary<float, T> readOnlyDictionary3 = b.ToStepCurve();
		foreach (var (num3, arg2) in a.GetLinearKeys())
		{
			if (!readOnlyDictionary3.TryGetValue(num3, out var value3))
			{
				throw new ArgumentException($"Missing key {num3}", "b");
			}
			if (!equalityComparer(arg2, value3))
			{
				throw new ArgumentException("Conversion failed.", "b");
			}
		}
	}

	internal void _VerifyConversion(Scene gltfScene)
	{
		int num = (from item in Instances
			select item.Content.GetGeometryAsset() into item
			where !item.IsEmpty()
			select item).Count();
		int num2 = (from item in Node.Flatten(gltfScene)
			where item.Mesh != null
			select item).Sum((Node item) => item.GetGpuInstancing()?.Count ?? 1);
		if (num != num2)
		{
			throw new InvalidOperationException($"Expected {Instances.Count}, but found {num2}");
		}
		RuntimeOptions runtimeOptions = new RuntimeOptions();
		runtimeOptions.IsolateMemory = false;
		runtimeOptions.GpuMeshInstancing = MeshInstancing.Enabled;
		SceneInstance source = SceneTemplate.Create(gltfScene, runtimeOptions).CreateInstance();
		int num3 = source.Sum((DrawableInstance item) => item.InstanceCount);
		if (num != num3)
		{
			throw new InvalidOperationException($"Expected {Instances.Count}, but found {num3}");
		}
		List<LightContent> list = Instances.Select((InstanceBuilder item) => item.Content.Content).OfType<LightContent>().ToList();
		List<Node> list2 = (from item in Node.Flatten(gltfScene)
			where item.PunctualLight != null
			select item).ToList();
		if (list.Count != list2.Count)
		{
			throw new InvalidOperationException($"Expected {list.Count}, but found {list2.Count}");
		}
		List<CameraContent> list3 = Instances.Select((InstanceBuilder item) => item.Content.Content).OfType<CameraContent>().ToList();
		List<Node> list4 = (from item in Node.Flatten(gltfScene)
			where item.Camera != null
			select item).ToList();
		if (list3.Count != list4.Count)
		{
			throw new InvalidOperationException($"Expected {list3.Count}, but found {list4.Count}");
		}
	}
}
