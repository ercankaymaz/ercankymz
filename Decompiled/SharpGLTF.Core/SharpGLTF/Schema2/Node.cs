using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public sealed class Node : LogicalChildOfRoot, IVisualNodeContainer
{
	public new const string SCHEMANAME = "node";

	private int? _camera;

	private const int _childrenMinItems = 1;

	private List<int> _children;

	private static readonly Matrix4x4 _matrixDefault = Matrix4x4.Identity;

	private Matrix4x4? _matrix = _matrixDefault;

	private int? _mesh;

	private static readonly Quaternion _rotationDefault = Quaternion.Identity;

	private Quaternion? _rotation = _rotationDefault;

	private static readonly Vector3 _scaleDefault = Vector3.One;

	private Vector3? _scale = _scaleDefault;

	private int? _skin;

	private static readonly Vector3 _translationDefault = Vector3.Zero;

	private Vector3? _translation = _translationDefault;

	private const int _weightsMinItems = 1;

	private List<double> _weights;

	private const string _NOTRANSFORMMESSAGE = "Node instances with a Skin must not contain spatial transformations.";

	public Node VisualParent => base.LogicalParent._FindVisualParentNode(this);

	public Node VisualRoot => _FindVisualRootNode(this);

	public IEnumerable<Scene> VisualScenes
	{
		get
		{
			Node rootNode = VisualRoot;
			return base.LogicalParent.LogicalScenes.Where((Scene item) => item._ContainsVisualNode(rootNode, recursive: false));
		}
	}

	public IEnumerable<Node> VisualChildren => _GetVisualChildren();

	public bool IsSkinJoint => Skin.FindSkinsUsingJoint(this).Any();

	public bool IsSkinSkeleton => Skin.FindSkinsUsingSkeleton(this).Any();

	public Camera Camera
	{
		get
		{
			if (!_camera.HasValue)
			{
				return null;
			}
			return base.LogicalParent.LogicalCameras[_camera.Value];
		}
		set
		{
			if (value == null)
			{
				_camera = null;
				return;
			}
			Guard.MustShareLogicalParent(base.LogicalParent, "LogicalParent", value, "value");
			_camera = value.LogicalIndex;
		}
	}

	public Mesh Mesh
	{
		get
		{
			if (!_mesh.HasValue)
			{
				return null;
			}
			return base.LogicalParent.LogicalMeshes[_mesh.Value];
		}
		set
		{
			if (value == null)
			{
				_mesh = null;
				return;
			}
			Guard.MustShareLogicalParent(base.LogicalParent, "LogicalParent", value, "value");
			_mesh = value.LogicalIndex;
		}
	}

	public Skin Skin
	{
		get
		{
			if (!_skin.HasValue)
			{
				return null;
			}
			return base.LogicalParent.LogicalSkins[_skin.Value];
		}
		set
		{
			if (value == null)
			{
				_skin = null;
				return;
			}
			Guard.MustShareLogicalParent(base.LogicalParent, "LogicalParent", value, "value");
			Guard.IsFalse(_matrix.HasValue, "Node instances with a Skin must not contain spatial transformations.");
			Guard.IsFalse(_scale.HasValue, "Node instances with a Skin must not contain spatial transformations.");
			Guard.IsFalse(_rotation.HasValue, "Node instances with a Skin must not contain spatial transformations.");
			Guard.IsFalse(_translation.HasValue, "Node instances with a Skin must not contain spatial transformations.");
			_skin = value.LogicalIndex;
		}
	}

	public IReadOnlyList<float> MorphWeights => GetMorphWeights();

	public Matrix4x4 WorldMatrix
	{
		get
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			Node visualParent = VisualParent;
			if (visualParent != null)
			{
				return Matrix4x4Factory.LocalToWorld(visualParent.WorldMatrix, LocalMatrix);
			}
			return LocalMatrix;
		}
		set
		{
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			Matrix4x4Factory.GuardMatrix("value", value, Matrix4x4Factory.MatrixCheck.WorldTransform);
			Node visualParent = VisualParent;
			LocalMatrix = ((visualParent == null) ? value : Matrix4x4Factory.WorldToLocal(visualParent.WorldMatrix, in value));
		}
	}

	public AffineTransform LocalTransform
	{
		get
		{
			return AffineTransform.CreateFromAny(_matrix, _scale, _rotation, _translation);
		}
		set
		{
			_SetLocalTransform(value);
		}
	}

	public Matrix4x4 LocalMatrix
	{
		get
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			return LocalTransform.Matrix;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			LocalTransform = value;
		}
	}

	internal Matrix4x4Double LocalMatrixPrecise
	{
		get
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			if (_matrix.HasValue)
			{
				return new Matrix4x4Double(_matrix.Value);
			}
			Vector3 val = (Vector3)(((_003F?)_scale) ?? Vector3.One);
			Quaternion q = (Quaternion)(((_003F?)_rotation) ?? Quaternion.Identity);
			Vector3 val2 = (Vector3)(((_003F?)_translation) ?? Vector3.Zero);
			return Matrix4x4Double.CreateScale(val.X, val.Y, val.Z) * Matrix4x4Double.CreateFromQuaternion(q.Sanitized()) * Matrix4x4Double.CreateTranslation(val2.X, val2.Y, val2.Z);
		}
	}

	internal Matrix4x4Double WorldMatrixPrecise
	{
		get
		{
			Node visualParent = VisualParent;
			if (visualParent != null)
			{
				return LocalMatrixPrecise * visualParent.WorldMatrixPrecise;
			}
			return LocalMatrixPrecise;
		}
	}

	public bool IsTransformAnimated
	{
		get
		{
			ModelRoot logicalParent = base.LogicalParent;
			if (logicalParent.LogicalAnimations.Count == 0)
			{
				return false;
			}
			return (from item in logicalParent.LogicalAnimations.SelectMany((Animation item) => item.FindChannels(this))
				where _isTransformPath(item.TargetNodePath)
				select item).Any();
			static bool _isTransformPath(PropertyPath path)
			{
				return path switch
				{
					PropertyPath.scale => true, 
					PropertyPath.rotation => true, 
					PropertyPath.translation => true, 
					_ => false, 
				};
			}
		}
	}

	internal bool IsTransformDecomposed
	{
		get
		{
			if (_scale.HasValue)
			{
				return true;
			}
			if (_rotation.HasValue)
			{
				return true;
			}
			if (_translation.HasValue)
			{
				return true;
			}
			return false;
		}
	}

	public PunctualLight PunctualLight
	{
		get
		{
			_NodePunctualLight extension = GetExtension<_NodePunctualLight>();
			if (extension == null)
			{
				return null;
			}
			return base.LogicalParent.LogicalPunctualLights[extension.LightIndex];
		}
		set
		{
			if (value == null)
			{
				RemoveExtensions<_NodePunctualLight>();
				return;
			}
			Guard.MustShareLogicalParent(this, value, "value");
			_NodePunctualLight nodePunctualLight = new _NodePunctualLight(this);
			nodePunctualLight.LightIndex = value.LogicalIndex;
			SetExtension(nodePunctualLight);
		}
	}

	protected override string GetSchemaName()
	{
		return "node";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "camera";
		yield return "children";
		yield return "matrix";
		yield return "mesh";
		yield return "rotation";
		yield return "scale";
		yield return "skin";
		yield return "translation";
		yield return "weights";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "camera":
			value = FieldInfo.From("camera", this, (Node instance) => instance._camera);
			return true;
		case "children":
			value = FieldInfo.From("children", this, (Node instance) => instance._children);
			return true;
		case "matrix":
			value = FieldInfo.From("matrix", this, (Node instance) => (Matrix4x4)(((_003F?)instance._matrix) ?? Matrix4x4.Identity));
			return true;
		case "mesh":
			value = FieldInfo.From("mesh", this, (Node instance) => instance._mesh);
			return true;
		case "rotation":
			value = FieldInfo.From("rotation", this, (Node instance) => (Quaternion)(((_003F?)instance._rotation) ?? Quaternion.Identity));
			return true;
		case "scale":
			value = FieldInfo.From("scale", this, (Node instance) => (Vector3)(((_003F?)instance._scale) ?? Vector3.One));
			return true;
		case "skin":
			value = FieldInfo.From("skin", this, (Node instance) => instance._skin);
			return true;
		case "translation":
			value = FieldInfo.From("translation", this, (Node instance) => (Vector3)(((_003F?)instance._translation) ?? Vector3.Zero));
			return true;
		case "weights":
			value = FieldInfo.From("weights", this, (Node instance) => instance._weights);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "camera", _camera);
		JsonSerializable.SerializeProperty(writer, "children", _children, 1);
		JsonSerializable.SerializeProperty(writer, "matrix", _matrix, _matrixDefault);
		JsonSerializable.SerializeProperty(writer, "mesh", _mesh);
		JsonSerializable.SerializeProperty(writer, "rotation", _rotation, _rotationDefault);
		JsonSerializable.SerializeProperty(writer, "scale", _scale, _scaleDefault);
		JsonSerializable.SerializeProperty(writer, "skin", _skin);
		JsonSerializable.SerializeProperty(writer, "translation", _translation, _translationDefault);
		JsonSerializable.SerializeProperty(writer, "weights", _weights, 1);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "camera":
			JsonSerializable.DeserializePropertyValue<Node, int?>(ref reader, this, out _camera);
			break;
		case "children":
			JsonSerializable.DeserializePropertyList(ref reader, this, _children);
			break;
		case "matrix":
			JsonSerializable.DeserializePropertyValue<Node, Matrix4x4?>(ref reader, this, out _matrix);
			break;
		case "mesh":
			JsonSerializable.DeserializePropertyValue<Node, int?>(ref reader, this, out _mesh);
			break;
		case "rotation":
			JsonSerializable.DeserializePropertyValue<Node, Quaternion?>(ref reader, this, out _rotation);
			break;
		case "scale":
			JsonSerializable.DeserializePropertyValue<Node, Vector3?>(ref reader, this, out _scale);
			break;
		case "skin":
			JsonSerializable.DeserializePropertyValue<Node, int?>(ref reader, this, out _skin);
			break;
		case "translation":
			JsonSerializable.DeserializePropertyValue<Node, Vector3?>(ref reader, this, out _translation);
			break;
		case "weights":
			JsonSerializable.DeserializePropertyList(ref reader, this, _weights);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	private string _GetDebuggerDisplay()
	{
		string text = $"Node[{base.LogicalIndex}ᴵᵈˣ]";
		if (!string.IsNullOrWhiteSpace(base.Name))
		{
			text = text + " \"" + base.Name + "\" ";
		}
		if (Mesh != null)
		{
			if (Skin != null)
			{
				text += $" / Skin[{Skin.LogicalIndex}ᴵᵈˣ]";
			}
			text += $" / Mesh[{Mesh.LogicalIndex}ᴵᵈˣ]";
			MeshGpuInstancing gpuInstancing = GetGpuInstancing();
			if (gpuInstancing != null)
			{
				text += $" x {gpuInstancing.Count} instances.";
			}
		}
		if (VisualChildren.Any())
		{
			if (VisualChildren.Count() < 16)
			{
				string text2 = string.Join(", ", VisualChildren.Select((Node item) => item.LogicalIndex));
				text = text + " / Children[" + text2 + "]";
			}
			else
			{
				text += $" / Children x {VisualChildren.Count()}";
			}
		}
		if (!LocalTransform.IsIdentity)
		{
			text = text + " At " + LocalTransform.ToDebuggerDisplayString();
		}
		return text;
	}

	internal Node()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_children = new List<int>();
		_weights = new List<double>();
		_scale = null;
		_rotation = null;
		_translation = null;
		_matrix = null;
	}

	public AffineTransform GetLocalTransform(Animation animation, float time)
	{
		if (animation == null)
		{
			return LocalTransform;
		}
		return GetCurveSamplers(animation).GetLocalTransform(time);
	}

	public Matrix4x4 GetWorldMatrix(Animation animation, float time)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (animation == null)
		{
			return WorldMatrix;
		}
		Node visualParent = VisualParent;
		Matrix4x4 childLocal = GetLocalTransform(animation, time).Matrix;
		if (visualParent != null)
		{
			return Matrix4x4Factory.LocalToWorld(visualParent.GetWorldMatrix(animation, time), in childLocal);
		}
		return childLocal;
	}

	public IReadOnlyList<float> GetMorphWeights()
	{
		if (!_mesh.HasValue)
		{
			return Array.Empty<float>();
		}
		if (_weights == null || _weights.Count == 0)
		{
			return Mesh.MorphWeights;
		}
		return _weights.Select((double item) => (float)item).ToList();
	}

	public void SetMorphWeights(SparseWeight8 weights)
	{
		Guard.IsTrue(_mesh.HasValue, "weights", "Nodes with no mesh cannot have morph weights");
		int maxCount = Mesh.Primitives.Max((MeshPrimitive item) => item.MorphTargetsCount);
		_weights.SetMorphWeights(maxCount, weights);
	}

	internal static Node _FindVisualRootNode(Node childNode)
	{
		while (true)
		{
			Node visualParent = childNode.VisualParent;
			if (visualParent == null)
			{
				break;
			}
			childNode = visualParent;
		}
		return childNode;
	}

	public Node CreateNode(string name = null)
	{
		Node node = base.LogicalParent._CreateVisualNode(_children);
		node.Name = name;
		return node;
	}

	public static IEnumerable<Node> Flatten(IVisualNodeContainer container)
	{
		if (container == null)
		{
			yield break;
		}
		if (container is Node node)
		{
			yield return node;
		}
		foreach (Node visualChild in container.VisualChildren)
		{
			IEnumerable<Node> enumerable = Flatten(visualChild);
			foreach (Node item in enumerable)
			{
				yield return item;
			}
		}
	}

	public static IEnumerable<Node> FindNodesUsingMesh(Mesh mesh)
	{
		if (mesh == null)
		{
			return Enumerable.Empty<Node>();
		}
		int meshIdx = mesh.LogicalIndex;
		return mesh.LogicalParent.LogicalNodes.Where((Node item) => item._mesh.AsValue(int.MinValue) == meshIdx);
	}

	public static IEnumerable<Node> FindNodesUsingSkin(Skin skin)
	{
		if (skin == null)
		{
			return Enumerable.Empty<Node>();
		}
		int meshIdx = skin.LogicalIndex;
		return skin.LogicalParent.LogicalNodes.Where((Node item) => item._skin.AsValue(int.MinValue) == meshIdx);
	}

	internal bool _ContainsVisualNode(Node node, bool recursive)
	{
		Guard.MustShareLogicalParent(this, node, "node");
		if (!recursive)
		{
			return VisualChildren.Any((Node item) => item == node);
		}
		return VisualChildren.Any((Node item) => item == node || item._ContainsVisualNode(node, recursive));
	}

	internal bool _HasVisualChild(int nodeIndex)
	{
		return _children.Contains(nodeIndex);
	}

	internal IEnumerable<Node> _GetVisualChildren()
	{
		return _children.Select((int idx) => base.LogicalParent.LogicalNodes[idx]);
	}

	internal void _SetVisualParent(Node parentNode)
	{
		Guard.MustShareLogicalParent(this, parentNode, "parentNode");
		Guard.IsFalse(_ContainsVisualNode(parentNode, recursive: true), "parentNode");
		foreach (Scene logicalScene in base.LogicalParent.LogicalScenes)
		{
			logicalScene._RemoveVisualNode(this);
		}
		_RemoveFromVisualParent();
		parentNode._children.Add(base.LogicalIndex);
	}

	internal void _RemoveFromVisualParent()
	{
		VisualParent?._children.Remove(base.LogicalIndex);
	}

	public NodeCurveSamplers GetCurveSamplers(Animation animation)
	{
		Guard.NotNull(animation, "animation");
		Guard.MustShareLogicalParent(this, animation, "animation");
		return new NodeCurveSamplers(this, animation);
	}

	private void _SetLocalTransform(AffineTransform value)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		Guard.IsFalse(_skin.HasValue, "Node instances with a Skin must not contain spatial transformations.");
		Guard.IsTrue(value.IsValid, "value");
		if (value.IsMatrix && IsTransformAnimated)
		{
			value = value.GetDecomposed();
		}
		if (value.IsMatrix)
		{
			_matrix = value.Matrix.AsNullable<Matrix4x4>(Matrix4x4.Identity);
			_scale = null;
			_rotation = null;
			_translation = null;
			return;
		}
		if (value.IsSRT)
		{
			_matrix = null;
			_scale = value.Scale.AsNullable<Vector3>(Vector3.One);
			_rotation = value.Rotation.Sanitized().AsNullable<Quaternion>(Quaternion.Identity);
			_translation = value.Translation.AsNullable<Vector3>(Vector3.Zero);
			return;
		}
		throw new ArgumentException("Undefined", "value");
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		foreach (int child in _children)
		{
			validate.IsNullOrIndex("VisualChildren", child, base.LogicalParent.LogicalNodes);
		}
		validate.IsNullOrIndex("Mesh", _mesh, base.LogicalParent.LogicalMeshes).IsNullOrIndex("Skin", _skin, base.LogicalParent.LogicalSkins).IsNullOrIndex("Camera", _camera, base.LogicalParent.LogicalCameras);
	}

	internal static void _ValidateParentHierarchy(IEnumerable<Node> nodes, ValidationContext validate)
	{
		List<int> list = new List<int>();
		foreach (Node node in nodes)
		{
			list.AddRange(node._children);
		}
		int num = list.Distinct().Count();
		if (num == list.Count)
		{
			return;
		}
		IEnumerable<IGrouping<int, int>> enumerable = from item in list
			group item by item into @group
			where @group.Count() > 1
			select @group;
		foreach (IGrouping<int, int> item in enumerable)
		{
			validate._LinkThrow($"LogicalNode[{item.Key}]", "has more than one parent.");
		}
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		_ValidateChildrenHierarchy(validate);
		_ValidateTransforms(validate);
		_ValidateMeshAndSkin(validate, Mesh, Skin, _weights);
	}

	private void _ValidateChildrenHierarchy(ValidationContext validate)
	{
		IReadOnlyList<Node> allNodes = base.LogicalParent.LogicalNodes;
		Stack<int> nodePath = new Stack<int>();
		checkTree(this);
		void checkTree(Node n)
		{
			int logicalIndex = n.LogicalIndex;
			if (nodePath.Contains(logicalIndex))
			{
				validate._LinkThrow($"LogicalNode[{logicalIndex}]", "has a circular reference.");
			}
			nodePath.Push(logicalIndex);
			foreach (int child in n._children)
			{
				checkTree(allNodes[child]);
			}
			nodePath.Pop();
		}
	}

	private void _ValidateTransforms(ValidationContext validate)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		if (_matrix.HasValue)
		{
			validate.IsUndefined<Vector3>((ValueLocation)"_scale", _scale).IsUndefined<Quaternion>((ValueLocation)"_rotation", _rotation).IsUndefined<Vector3>((ValueLocation)"_translation", _translation)
				.IsNullOrMatrix4x3("Matrix", _matrix);
		}
		validate.IsPosition("Scale", _scale.AsValue<Vector3>(Vector3.One)).IsRotation("Rotation", _rotation.AsValue<Quaternion>(Quaternion.Identity)).IsPosition("Translation", _translation.AsValue<Vector3>(Vector3.Zero));
	}

	private static void _ValidateMeshAndSkin(ValidationContext validate, Mesh mesh, Skin skin, List<double> weights)
	{
		int num = weights?.Count ?? 0;
		if (mesh != null || skin != null || num != 0)
		{
			if (skin != null)
			{
				validate.IsDefined("Mesh", mesh);
				validate.IsTrue("Mesh", mesh.AllPrimitivesHaveJoints, "Node has skin defined, but mesh has no joints data.");
			}
			if (mesh == null)
			{
				validate.AreEqual("weights", num, 0);
			}
		}
	}

	public MeshGpuInstancing GetGpuInstancing()
	{
		return GetExtension<MeshGpuInstancing>();
	}

	public MeshGpuInstancing UseGpuInstancing()
	{
		MeshGpuInstancing meshGpuInstancing = GetGpuInstancing();
		if (meshGpuInstancing == null)
		{
			meshGpuInstancing = new MeshGpuInstancing(this);
			SetExtension(meshGpuInstancing);
		}
		return meshGpuInstancing;
	}

	public void RemoveGpuInstancing()
	{
		RemoveExtensions<MeshGpuInstancing>();
	}
}
