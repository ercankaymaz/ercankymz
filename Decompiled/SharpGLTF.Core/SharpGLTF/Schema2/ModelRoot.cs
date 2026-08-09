using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Model Root")]
public sealed class ModelRoot : ExtraProperties, IConvertibleToGltf2
{
	public new const string SCHEMANAME = "glTF";

	private Asset _asset;

	private const int _extensionsRequiredMinItems = 1;

	private List<string> _extensionsRequired;

	private const int _extensionsUsedMinItems = 1;

	private List<string> _extensionsUsed;

	private const int _accessorsMinItems = 1;

	private ChildrenList<Accessor, ModelRoot> _accessors;

	private const int _animationsMinItems = 1;

	private ChildrenList<Animation, ModelRoot> _animations;

	private const int _bufferViewsMinItems = 1;

	private ChildrenList<BufferView, ModelRoot> _bufferViews;

	private const int _buffersMinItems = 1;

	private ChildrenList<Buffer, ModelRoot> _buffers;

	private const int _camerasMinItems = 1;

	private ChildrenList<Camera, ModelRoot> _cameras;

	private const int _imagesMinItems = 1;

	private ChildrenList<Image, ModelRoot> _images;

	private const int _materialsMinItems = 1;

	private ChildrenList<Material, ModelRoot> _materials;

	private const int _meshesMinItems = 1;

	private ChildrenList<Mesh, ModelRoot> _meshes;

	private const int _nodesMinItems = 1;

	private ChildrenList<Node, ModelRoot> _nodes;

	private const int _samplersMinItems = 1;

	private ChildrenList<TextureSampler, ModelRoot> _samplers;

	private int? _scene;

	private const int _scenesMinItems = 1;

	private ChildrenList<Scene, ModelRoot> _scenes;

	private const int _skinsMinItems = 1;

	private ChildrenList<Skin, ModelRoot> _skins;

	private const int _texturesMinItems = 1;

	private ChildrenList<Texture, ModelRoot> _textures;

	public Asset Asset
	{
		get
		{
			return _asset;
		}
		set
		{
			ExtraProperties.SetProperty(this, ref _asset, value);
		}
	}

	public bool MeshQuantizationAllowed => _extensionsRequired.Contains("KHR_mesh_quantization");

	public IEnumerable<string> ExtensionsUsed => _extensionsUsed;

	public IEnumerable<string> ExtensionsRequired => _extensionsRequired;

	public IEnumerable<string> IncompatibleExtensions => _extensionsRequired.Except(ExtensionsFactory.SupportedExtensions).ToList();

	public IReadOnlyList<Material> LogicalMaterials => _materials;

	public IReadOnlyList<Texture> LogicalTextures => _textures;

	public IReadOnlyList<TextureSampler> LogicalTextureSamplers => _samplers;

	public IReadOnlyList<Image> LogicalImages => _images;

	public IReadOnlyList<Buffer> LogicalBuffers => _buffers;

	public IReadOnlyList<BufferView> LogicalBufferViews => _bufferViews;

	public IReadOnlyList<Accessor> LogicalAccessors => _accessors;

	public IReadOnlyList<Mesh> LogicalMeshes => _meshes;

	public IReadOnlyList<Skin> LogicalSkins => _skins;

	public IReadOnlyList<Camera> LogicalCameras => _cameras;

	public IReadOnlyList<Node> LogicalNodes => _nodes;

	public IReadOnlyList<Scene> LogicalScenes => _scenes;

	public IReadOnlyList<Animation> LogicalAnimations => _animations;

	public Scene DefaultScene
	{
		get
		{
			if (_scenes.Count != 0)
			{
				return _scenes[_scene.AsValue(0)];
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				_scene = null;
				return;
			}
			Guard.MustShareLogicalParent(this, "this", value, "value");
			_scene = value.LogicalIndex;
		}
	}

	public IReadOnlyList<PunctualLight> LogicalPunctualLights
	{
		get
		{
			_ModelPunctualLights extension = GetExtension<_ModelPunctualLights>();
			if (extension != null)
			{
				return extension.Lights;
			}
			return Array.Empty<PunctualLight>();
		}
	}

	protected override string GetSchemaName()
	{
		return "glTF";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "asset";
		yield return "extensionsRequired";
		yield return "extensionsUsed";
		yield return "accessors";
		yield return "animations";
		yield return "bufferViews";
		yield return "buffers";
		yield return "cameras";
		yield return "images";
		yield return "materials";
		yield return "meshes";
		yield return "nodes";
		yield return "samplers";
		yield return "scene";
		yield return "scenes";
		yield return "skins";
		yield return "textures";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "asset":
			value = FieldInfo.From("asset", this, (ModelRoot instance) => instance._asset);
			return true;
		case "extensionsRequired":
			value = FieldInfo.From("extensionsRequired", this, (ModelRoot instance) => instance._extensionsRequired);
			return true;
		case "extensionsUsed":
			value = FieldInfo.From("extensionsUsed", this, (ModelRoot instance) => instance._extensionsUsed);
			return true;
		case "accessors":
			value = FieldInfo.From("accessors", this, (ModelRoot instance) => instance._accessors);
			return true;
		case "animations":
			value = FieldInfo.From("animations", this, (ModelRoot instance) => instance._animations);
			return true;
		case "bufferViews":
			value = FieldInfo.From("bufferViews", this, (ModelRoot instance) => instance._bufferViews);
			return true;
		case "buffers":
			value = FieldInfo.From("buffers", this, (ModelRoot instance) => instance._buffers);
			return true;
		case "cameras":
			value = FieldInfo.From("cameras", this, (ModelRoot instance) => instance._cameras);
			return true;
		case "images":
			value = FieldInfo.From("images", this, (ModelRoot instance) => instance._images);
			return true;
		case "materials":
			value = FieldInfo.From("materials", this, (ModelRoot instance) => instance._materials);
			return true;
		case "meshes":
			value = FieldInfo.From("meshes", this, (ModelRoot instance) => instance._meshes);
			return true;
		case "nodes":
			value = FieldInfo.From("nodes", this, (ModelRoot instance) => instance._nodes);
			return true;
		case "samplers":
			value = FieldInfo.From("samplers", this, (ModelRoot instance) => instance._samplers);
			return true;
		case "scene":
			value = FieldInfo.From("scene", this, (ModelRoot instance) => instance._scene);
			return true;
		case "scenes":
			value = FieldInfo.From("scenes", this, (ModelRoot instance) => instance._scenes);
			return true;
		case "skins":
			value = FieldInfo.From("skins", this, (ModelRoot instance) => instance._skins);
			return true;
		case "textures":
			value = FieldInfo.From("textures", this, (ModelRoot instance) => instance._textures);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializePropertyObject(writer, "asset", _asset);
		JsonSerializable.SerializeProperty(writer, "extensionsRequired", _extensionsRequired, 1);
		JsonSerializable.SerializeProperty(writer, "extensionsUsed", _extensionsUsed, 1);
		JsonSerializable.SerializeProperty(writer, "accessors", _accessors, 1);
		JsonSerializable.SerializeProperty(writer, "animations", _animations, 1);
		JsonSerializable.SerializeProperty(writer, "bufferViews", _bufferViews, 1);
		JsonSerializable.SerializeProperty(writer, "buffers", _buffers, 1);
		JsonSerializable.SerializeProperty(writer, "cameras", _cameras, 1);
		JsonSerializable.SerializeProperty(writer, "images", _images, 1);
		JsonSerializable.SerializeProperty(writer, "materials", _materials, 1);
		JsonSerializable.SerializeProperty(writer, "meshes", _meshes, 1);
		JsonSerializable.SerializeProperty(writer, "nodes", _nodes, 1);
		JsonSerializable.SerializeProperty(writer, "samplers", _samplers, 1);
		JsonSerializable.SerializeProperty(writer, "scene", _scene);
		JsonSerializable.SerializeProperty(writer, "scenes", _scenes, 1);
		JsonSerializable.SerializeProperty(writer, "skins", _skins, 1);
		JsonSerializable.SerializeProperty(writer, "textures", _textures, 1);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "asset":
			JsonSerializable.DeserializePropertyValue<ModelRoot, Asset>(ref reader, this, out _asset);
			break;
		case "extensionsRequired":
			JsonSerializable.DeserializePropertyList(ref reader, this, _extensionsRequired);
			break;
		case "extensionsUsed":
			JsonSerializable.DeserializePropertyList(ref reader, this, _extensionsUsed);
			break;
		case "accessors":
			JsonSerializable.DeserializePropertyList(ref reader, this, _accessors);
			break;
		case "animations":
			JsonSerializable.DeserializePropertyList(ref reader, this, _animations);
			break;
		case "bufferViews":
			JsonSerializable.DeserializePropertyList(ref reader, this, _bufferViews);
			break;
		case "buffers":
			JsonSerializable.DeserializePropertyList(ref reader, this, _buffers);
			break;
		case "cameras":
			JsonSerializable.DeserializePropertyList(ref reader, this, _cameras);
			break;
		case "images":
			JsonSerializable.DeserializePropertyList(ref reader, this, _images);
			break;
		case "materials":
			JsonSerializable.DeserializePropertyList(ref reader, this, _materials);
			break;
		case "meshes":
			JsonSerializable.DeserializePropertyList(ref reader, this, _meshes);
			break;
		case "nodes":
			JsonSerializable.DeserializePropertyList(ref reader, this, _nodes);
			break;
		case "samplers":
			JsonSerializable.DeserializePropertyList(ref reader, this, _samplers);
			break;
		case "scene":
			JsonSerializable.DeserializePropertyValue<ModelRoot, int?>(ref reader, this, out _scene);
			break;
		case "scenes":
			JsonSerializable.DeserializePropertyList(ref reader, this, _scenes);
			break;
		case "skins":
			JsonSerializable.DeserializePropertyList(ref reader, this, _skins);
			break;
		case "textures":
			JsonSerializable.DeserializePropertyList(ref reader, this, _textures);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	public Accessor CreateAccessor(string name = null)
	{
		Accessor accessor = new Accessor
		{
			Name = name
		};
		_accessors.Add(accessor);
		return accessor;
	}

	public Animation CreateAnimation(string name = null)
	{
		Animation animation = new Animation
		{
			Name = name
		};
		_animations.Add(animation);
		return animation;
	}

	public Buffer CreateBuffer(int byteCount)
	{
		Buffer buffer = new Buffer(new byte[byteCount]);
		_buffers.Add(buffer);
		return buffer;
	}

	public Buffer UseBuffer(byte[] content)
	{
		Guard.NotNull(content, "content");
		foreach (Buffer logicalBuffer in LogicalBuffers)
		{
			if (logicalBuffer.Content == content)
			{
				return logicalBuffer;
			}
		}
		Buffer buffer = new Buffer(content);
		_buffers.Add(buffer);
		return buffer;
	}

	public void MergeBuffers()
	{
		List<BufferView> list = _bufferViews.OrderByDescending((BufferView bufferView) => bufferView.Content.Count).ToList();
		if (list.Count <= 1)
		{
			return;
		}
		long num = ((IEnumerable<BufferView>)list).Sum((Func<BufferView, long>)((BufferView bufferView) => bufferView.Content.Count.WordPadded()));
		if (num >= int.MaxValue)
		{
			throw new InvalidOperationException("Can't merge a buffer larger than 2Gb");
		}
		int initialCapacity = (int)((double)num * 1.01);
		_StaticBufferBuilder staticBufferBuilder = new _StaticBufferBuilder(0, initialCapacity);
		foreach (BufferView item2 in list)
		{
			item2._IsolateBufferMemory(staticBufferBuilder);
		}
		_buffers.Clear();
		Buffer item = new Buffer(staticBufferBuilder.ToArray());
		_buffers.Add(item);
	}

	public void MergeBuffers(int maxSize)
	{
		List<BufferView> list = _bufferViews.OrderByDescending((BufferView bufferView) => bufferView.Content.Count).ToList();
		if (list.Count <= 1)
		{
			return;
		}
		List<_StaticBufferBuilder> list2 = new List<_StaticBufferBuilder>();
		list2.Add(new _StaticBufferBuilder(0));
		foreach (BufferView item2 in list)
		{
			_StaticBufferBuilder staticBufferBuilder = list2.Last();
			bool flag = staticBufferBuilder.BufferSize >= maxSize;
			bool flag2 = staticBufferBuilder.BufferSize > 0;
			bool flag3 = (long)item2.Content.Count + (long)staticBufferBuilder.BufferSize >= maxSize;
			if (flag || (flag2 && flag3))
			{
				staticBufferBuilder = new _StaticBufferBuilder(list2.Count);
				list2.Add(staticBufferBuilder);
			}
			item2._IsolateBufferMemory(staticBufferBuilder);
		}
		_buffers.Clear();
		foreach (_StaticBufferBuilder item3 in list2)
		{
			Buffer item = new Buffer(item3.ToArray());
			_buffers.Add(item);
		}
	}

	public void IsolateMemory()
	{
		foreach (Buffer logicalBuffer in LogicalBuffers)
		{
			logicalBuffer._IsolateMemory();
		}
	}

	public BufferView CreateBufferView(int byteSize, int byteStride = 0, BufferMode? target = null)
	{
		Guard.MustBeGreaterThan(byteSize, 0, "byteSize");
		Buffer buffer = CreateBuffer(byteSize);
		BufferView bufferView = new BufferView(buffer, 0, null, byteStride, target);
		_bufferViews.Add(bufferView);
		return bufferView;
	}

	public BufferView UseBufferView(ArraySegment<byte> data, int byteStride = 0, BufferMode? target = null)
	{
		Guard.NotNull(data.Array, "data");
		return UseBufferView(data.Array, data.Offset, data.Count, byteStride, target);
	}

	public BufferView UseBufferView(byte[] buffer, int byteOffset = 0, int? byteLength = null, int byteStride = 0, BufferMode? target = null)
	{
		Guard.NotNull(buffer, "buffer");
		return UseBufferView(UseBuffer(buffer), byteOffset, byteLength, byteStride, target);
	}

	public BufferView UseBufferView(Buffer buffer, int byteOffset = 0, int? byteLength = null, int byteStride = 0, BufferMode? target = null)
	{
		Guard.NotNull(buffer, "buffer");
		Guard.MustShareLogicalParent(this, "this", buffer, "buffer");
		ArraySegment<byte> content = new ArraySegment<byte>(buffer.Content, byteOffset, byteLength.AsValue(buffer.Content.Length - byteOffset));
		foreach (BufferView logicalBufferView in LogicalBufferViews)
		{
			if (BufferView.AreEqual(logicalBufferView, content, byteStride, target))
			{
				return logicalBufferView;
			}
		}
		BufferView bufferView = new BufferView(buffer, byteOffset, byteLength, byteStride, target);
		_bufferViews.Add(bufferView);
		return bufferView;
	}

	public Camera CreateCamera(string name = null)
	{
		Camera camera = new Camera
		{
			Name = name
		};
		_cameras.Add(camera);
		return camera;
	}

	internal void UpdateExtensionsSupport()
	{
		IEnumerable<string> collection = GatherUsedExtensions();
		_extensionsUsed.Clear();
		_extensionsUsed.AddRange(collection);
		_SetExtensionUsage("KHR_mesh_quantization", _extensionsUsed.Contains("KHR_mesh_quantization"), required: true);
	}

	internal IEnumerable<string> GatherUsedExtensions()
	{
		List<ExtraProperties> list = new ModelRoot[1] { this }.Concat(GetLogicalChildrenFlattened()).ToList();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (ExtraProperties c in list)
		{
			IEnumerable<string> other = from item in c.Extensions
				select ExtensionsFactory.Identify(c.GetType(), item.GetType()) into item
				where !string.IsNullOrWhiteSpace(item)
				select item;
			hashSet.UnionWith(other);
		}
		foreach (UnknownNode item in list.SelectMany((ExtraProperties item) => item.Extensions).OfType<UnknownNode>())
		{
			hashSet.Add(item.Name);
		}
		if (MeshPrimitive.CheckAttributesQuantizationRequired(this))
		{
			hashSet.Add("KHR_mesh_quantization");
		}
		return hashSet;
	}

	private void _SetExtensionUsage(string extension, bool used, bool required)
	{
		if (!used)
		{
			_extensionsUsed.Remove(extension);
			_extensionsRequired.Remove(extension);
			return;
		}
		if (!_extensionsUsed.Contains(extension))
		{
			_extensionsUsed.Add(extension);
		}
		if (required && !_extensionsRequired.Contains(extension))
		{
			_extensionsRequired.Add(extension);
		}
	}

	internal void _ValidateExtensions(ValidationContext validate)
	{
		foreach (string incompatibleExtension in IncompatibleExtensions)
		{
			validate._LinkThrow("Extensions", incompatibleExtension);
		}
		foreach (string item in GatherUsedExtensions())
		{
			if (!_extensionsUsed.Contains(item))
			{
				validate._LinkThrow("Extensions", item);
			}
		}
	}

	public Image CreateImage(string name = null)
	{
		Image image = new Image();
		image.Name = name;
		_images.Add(image);
		return image;
	}

	public Image UseImage(MemoryImage imageContent)
	{
		MemoryImage._Verify(imageContent, "imageContent");
		foreach (Image logicalImage in LogicalImages)
		{
			if (logicalImage.Content.Equals(imageContent))
			{
				return logicalImage;
			}
		}
		Image image = CreateImage();
		image.Content = imageContent;
		return image;
	}

	public void MergeImages()
	{
		foreach (Image image in _images)
		{
			image.TransferToInternalBuffer();
		}
	}

	public Material CreateMaterial(string name = null)
	{
		Material material = new Material();
		material.Name = name;
		_materials.Add(material);
		return material;
	}

	public Mesh CreateMesh(string name = null)
	{
		Mesh mesh = new Mesh();
		mesh.Name = name;
		_meshes.Add(mesh);
		return mesh;
	}

	internal Node _FindVisualParentNode(Node childNode)
	{
		int childIdx = _nodes.IndexOf(childNode);
		if (childIdx < 0)
		{
			return null;
		}
		return _nodes.FirstOrDefault((Node item) => item._HasVisualChild(childIdx));
	}

	public Node CreateLogicalNode()
	{
		Node node = new Node();
		_nodes.Add(node);
		return node;
	}

	internal Node _CreateVisualNode(IList<int> parentChildren)
	{
		Node node = CreateLogicalNode();
		parentChildren.Add(node.LogicalIndex);
		return node;
	}

	public void ApplyBasisTransform(Matrix4x4 basisTransform, string basisNodeName = "BasisTransform")
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4Factory.GuardMatrix("basisTransform", basisTransform, Matrix4x4Factory.MatrixCheck.WorldTransform);
		List<Node> list = LogicalNodes.Where((Node item) => item.VisualRoot == item).ToList();
		List<Node> list2 = list.Where((Node item) => isSensible(item)).ToList();
		List<Node> list3 = list.Except(list2).ToList();
		foreach (Node item in list3)
		{
			item.LocalMatrix *= basisTransform;
		}
		if (list2.Count == 0)
		{
			return;
		}
		Node node = CreateLogicalNode();
		node.Name = basisNodeName;
		node.LocalMatrix = basisTransform;
		foreach (Scene logicalScene in LogicalScenes)
		{
			logicalScene._UseVisualNode(node);
		}
		foreach (Node item2 in list2)
		{
			item2._SetVisualParent(node);
		}
		static bool isSensible(Node node2)
		{
			if (node2.IsTransformAnimated)
			{
				return true;
			}
			if (node2.IsTransformDecomposed)
			{
				return true;
			}
			return false;
		}
	}

	public static ModelRoot CreateModel()
	{
		ModelRoot modelRoot = new ModelRoot();
		modelRoot.Asset = Asset.CreateDefault(string.Empty);
		return modelRoot;
	}

	internal ModelRoot()
	{
		_extensionsUsed = new List<string>();
		_extensionsRequired = new List<string>();
		_accessors = new ChildrenList<Accessor, ModelRoot>(this);
		_animations = new ChildrenList<Animation, ModelRoot>(this);
		_buffers = new ChildrenList<Buffer, ModelRoot>(this);
		_bufferViews = new ChildrenList<BufferView, ModelRoot>(this);
		_cameras = new ChildrenList<Camera, ModelRoot>(this);
		_images = new ChildrenList<Image, ModelRoot>(this);
		_materials = new ChildrenList<Material, ModelRoot>(this);
		_meshes = new ChildrenList<Mesh, ModelRoot>(this);
		_nodes = new ChildrenList<Node, ModelRoot>(this);
		_samplers = new ChildrenList<TextureSampler, ModelRoot>(this);
		_scenes = new ChildrenList<Scene, ModelRoot>(this);
		_skins = new ChildrenList<Skin, ModelRoot>(this);
		_textures = new ChildrenList<Texture, ModelRoot>(this);
	}

	public ModelRoot DeepClone()
	{
		Dictionary<string, ArraySegment<byte>> dictionary = new Dictionary<string, ArraySegment<byte>>();
		WriteContext writeContext = WriteContext.CreateFromDictionary(dictionary).WithDeepCloneSettings();
		writeContext.WriteTextSchema2("$$$deepclone$$$", this);
		ReadContext readContext = ReadContext.CreateFromDictionary(dictionary, writeContext._UpdateSupportedExtensions);
		readContext.Validation = ValidationMode.Skip;
		ModelRoot modelRoot = readContext.ReadSchema2("$$$deepclone$$$.gltf");
		foreach (Image logicalImage in LogicalImages)
		{
			Image image = modelRoot.LogicalImages[logicalImage.LogicalIndex];
			MemoryImage content = image.Content;
			image.Content = new MemoryImage(content, logicalImage.Content.SourcePath);
			image.AlternateWriteFileName = logicalImage.AlternateWriteFileName;
		}
		return modelRoot;
	}

	ModelRoot IConvertibleToGltf2.ToGltf2()
	{
		return this;
	}

	internal IEnumerable<ExtraProperties> GetLogicalChildrenFlattened()
	{
		return GetLogicalChildren().SelectMany((ExtraProperties item) => ExtraProperties.Flatten(item));
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		validate.NotNull("Asset", Asset).IsNullOrIndex("DefaultScene", _scene, LogicalScenes);
		Asset.ValidateReferences(validate);
		base.OnValidateReferences(validate);
		Node._ValidateParentHierarchy(LogicalNodes, validate);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		Asset.ValidateContent(validate);
		base.OnValidateContent(validate);
	}

	public PunctualLight CreatePunctualLight(PunctualLightType lightType)
	{
		return CreatePunctualLight(null, lightType);
	}

	public PunctualLight CreatePunctualLight(string name, PunctualLightType lightType)
	{
		return UseExtension<_ModelPunctualLights>().CreateLight(name, lightType);
	}

	public Scene UseScene(int index)
	{
		Guard.MustBeGreaterThanOrEqualTo(index, 0, "index");
		while (index >= _scenes.Count)
		{
			_scenes.Add(new Scene());
		}
		return _scenes[index];
	}

	public Scene UseScene(string name)
	{
		Scene scene = _scenes.FirstOrDefault((Scene item) => item.Name == name);
		if (scene != null)
		{
			return scene;
		}
		scene = new Scene
		{
			Name = name
		};
		_scenes.Add(scene);
		return scene;
	}

	public Skin CreateSkin(string name = null)
	{
		Skin skin = new Skin();
		skin.Name = name;
		_skins.Add(skin);
		return skin;
	}

	public TextureSampler UseTextureSampler(TextureWrapMode ws, TextureWrapMode wt, TextureMipMapFilter min, TextureInterpolationFilter mag)
	{
		if (TextureSampler.IsDefault(min, mag, ws, wt))
		{
			return null;
		}
		foreach (TextureSampler sampler in _samplers)
		{
			if (sampler.IsEqualTo(min, mag, ws, wt))
			{
				return sampler;
			}
		}
		TextureSampler textureSampler = new TextureSampler(min, mag, ws, wt);
		_samplers.Add(textureSampler);
		return textureSampler;
	}

	public Texture UseTexture(Image primary, TextureSampler sampler = null)
	{
		if (primary == null)
		{
			return null;
		}
		return UseTexture(primary, null, sampler);
	}

	public Texture UseTexture(Image primary, Image fallback, TextureSampler sampler = null)
	{
		if (primary == null)
		{
			Guard.MustBeNull(fallback, "fallback");
			return null;
		}
		Guard.MustShareLogicalParent(this, "this", primary, "primary");
		if (fallback != null)
		{
			Guard.MustShareLogicalParent(this, "this", fallback, "primary");
		}
		if (sampler != null)
		{
			Guard.MustShareLogicalParent(this, "this", sampler, "sampler");
		}
		Texture texture = _textures.FirstOrDefault((Texture item) => item._IsEqualentTo(primary, fallback, sampler));
		if (texture != null)
		{
			return texture;
		}
		texture = new Texture();
		_textures.Add(texture);
		if (fallback == null)
		{
			texture.SetImage(primary);
		}
		else
		{
			texture.SetImages(primary, fallback);
		}
		texture.Sampler = sampler;
		return texture;
	}

	public static ValidationResult Validate(string filePath)
	{
		Guard.NotNull(filePath, "filePath");
		FileInfo fileInfo = new FileInfo(filePath);
		Guard.MustExist(fileInfo, "filePath");
		return ReadContext.CreateFromDirectory(fileInfo.Directory).Validate(fileInfo.Name);
	}

	public static ModelRoot Load(string filePath, ReadSettings settings = null)
	{
		Guard.NotNull(filePath, "filePath");
		ReadContext readContext = settings as ReadContext;
		if (readContext == null)
		{
			FileInfo fileInfo = new FileInfo(filePath);
			Guard.MustExist(fileInfo, "filePath");
			readContext = ReadContext.CreateFromDirectory(fileInfo.Directory).WithSettingsFrom(settings);
			filePath = fileInfo.Name;
		}
		return readContext.ReadSchema2(filePath);
	}

	public static ModelRoot ParseGLB(ArraySegment<byte> glb, ReadSettings settings = null)
	{
		Guard.NotNull(glb, "glb");
		using MemoryStream stream = new MemoryStream(glb.Array, glb.Offset, glb.Count, writable: false);
		return ReadGLB(stream, settings);
	}

	public static ModelRoot ReadGLB(Stream stream, ReadSettings settings = null)
	{
		Guard.NotNull(stream, "stream");
		Guard.IsTrue(stream.CanRead, "stream");
		ReadContext readContext = ReadContext.Create(delegate
		{
			throw new NotSupportedException();
		}).WithSettingsFrom(settings);
		return readContext.ReadBinarySchema2(stream);
	}

	public static string[] GetSatellitePaths(string filePath)
	{
		Guard.FilePathMustExist(filePath, "filePath");
		ReadOnlyMemory<byte> json = ReadOnlyMemory<byte>.Empty;
		using (FileStream stream = File.OpenRead(filePath))
		{
			json = ReadContext.ReadJsonBytes(stream);
		}
		return ParseSatellitePaths(json);
	}

	private static string[] ParseSatellitePaths(ReadOnlyMemory<byte> json)
	{
		HashSet<string> uris = new HashSet<string>();
		using (JsonDocument jsonDocument = JsonDocument.Parse(json))
		{
			if (jsonDocument.RootElement.TryGetProperty("buffers", out var value))
			{
				foreach (JsonElement item in value.EnumerateArray())
				{
					if (item.TryGetProperty("uri", out var value2))
					{
						_addUri(value2);
					}
				}
			}
			if (jsonDocument.RootElement.TryGetProperty("images", out var value3))
			{
				foreach (JsonElement item2 in value3.EnumerateArray())
				{
					if (item2.TryGetProperty("uri", out var value4))
					{
						_addUri(value4);
					}
				}
			}
		}
		return uris.ToArray();
		void _addUri(JsonElement property)
		{
			string text = property.GetString();
			if (!string.IsNullOrWhiteSpace(text) && !text.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
			{
				uris.Add(text);
			}
		}
	}

	internal void OnDeserializationCompleted()
	{
	}

	internal void _ResolveSatelliteDependencies(ReadContext context)
	{
		foreach (Buffer buffer in _buffers)
		{
			buffer._ResolveUri(context);
		}
		foreach (Image image in _images)
		{
			image._ResolveUri(context);
			if (context.ImageDecoder != null && !context.ImageDecoder(image))
			{
				image._DiscardContent();
			}
		}
	}

	public void Save(string filePath, WriteSettings settings = null)
	{
		Guard.NotNull(filePath, "filePath");
		if (filePath.EndsWith(".gltf", StringComparison.OrdinalIgnoreCase))
		{
			SaveGLTF(filePath, settings);
		}
		else
		{
			SaveGLB(filePath, settings);
		}
	}

	public void SaveGLB(string filePath, WriteSettings settings = null)
	{
		Guard.NotNull(filePath, "filePath");
		WriteContext writeContext = settings as WriteContext;
		if (writeContext == null)
		{
			FileInfo fileInfo = new FileInfo(filePath);
			writeContext = WriteContext.CreateFromDirectory(fileInfo.Directory).WithSettingsFrom(settings);
			filePath = fileInfo.Name;
		}
		string fileName = Path.GetFileName(filePath);
		writeContext.WithBinarySettings();
		writeContext.WriteBinarySchema2(fileName, this);
	}

	public void SaveGLTF(string filePath, WriteSettings settings = null)
	{
		Guard.NotNull(filePath, "filePath");
		WriteContext writeContext = settings as WriteContext;
		if (writeContext == null)
		{
			FileInfo fileInfo = new FileInfo(filePath);
			writeContext = WriteContext.CreateFromDirectory(fileInfo.Directory).WithSettingsFrom(settings);
			filePath = fileInfo.Name;
		}
		string fileName = Path.GetFileName(filePath);
		writeContext.WithTextSettings();
		writeContext.WriteTextSchema2(fileName, this);
	}

	[Obsolete("Use GetJsonPreview", true)]
	public string GetJSON(bool indented)
	{
		return GetJsonPreview();
	}

	public string GetJsonPreview()
	{
		return _GetJSON(indented: true);
	}

	internal string _GetJSON(bool indented)
	{
		JsonWriterOptions options = new JsonWriterOptions
		{
			Indented = indented,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};
		using MemoryStream memoryStream = new MemoryStream();
		_WriteJSON(memoryStream, options, null);
		memoryStream.Position = 0L;
		using StreamReader streamReader = new StreamReader(memoryStream);
		return streamReader.ReadToEnd();
	}

	public ArraySegment<byte> WriteGLB(WriteSettings settings = null)
	{
		using MemoryStream memoryStream = new MemoryStream();
		WriteGLB(memoryStream, settings);
		return memoryStream.ToArraySegment();
	}

	public void WriteGLB(Stream stream, WriteSettings settings = null)
	{
		Guard.NotNull(stream, "stream");
		Guard.IsTrue(stream.CanWrite, "stream");
		WriteContext writeContext = WriteContext.CreateFromStream(stream).WithSettingsFrom(settings);
		writeContext.WithBinarySettings();
		writeContext.WriteBinarySchema2("model", this);
	}

	internal void _WriteJSON(Stream sw, JsonWriterOptions options, JsonFilterCallback filter)
	{
		if (filter == null)
		{
			using (Utf8JsonWriter writer = new Utf8JsonWriter(sw, options))
			{
				Serialize(writer);
				return;
			}
		}
		string json = null;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			_WriteJSON(memoryStream, options, null);
			memoryStream.Position = 0L;
			using StreamReader streamReader = new StreamReader(memoryStream);
			json = streamReader.ReadToEnd();
		}
		json = filter(json);
		byte[] bytes = Encoding.UTF8.GetBytes(json);
		using MemoryStream memoryStream2 = new MemoryStream(bytes, writable: false);
		memoryStream2.CopyTo(sw);
	}

	internal void _PrepareBuffersForSatelliteWriting(WriteContext context, string baseName)
	{
		for (int i = 0; i < _buffers.Count; i++)
		{
			Buffer buffer = _buffers[i];
			string satelliteUri = ((_buffers.Count != 1) ? $"{baseName}_{i}.bin" : (baseName + ".bin"));
			buffer._WriteToSatellite(context, satelliteUri);
		}
	}

	internal void _PrepareBuffersForInternalWriting()
	{
		for (int i = 0; i < _buffers.Count; i++)
		{
			Buffer buffer = _buffers[i];
			buffer._WriteToInternal();
		}
	}

	internal void _PrepareImagesForWriting(WriteContext context, string baseName, bool isBinary, ResourceWriteMode rmode)
	{
		if (context.ImageWriting != ResourceWriteMode.Default)
		{
			rmode = context.ImageWriting;
		}
		if (rmode == ResourceWriteMode.Default)
		{
			throw new InvalidOperationException("ResourceWriteMode is not set");
		}
		if (isBinary)
		{
			if (rmode == ResourceWriteMode.EmbeddedAsBase64)
			{
				throw new InvalidOperationException("EmbeddedAsBase64 not supported when writing binary GLB.");
			}
		}
		else if (rmode == ResourceWriteMode.BufferView)
		{
			throw new InvalidOperationException("BufferView not supported when writing text glTF.");
		}
		for (int i = 0; i < _images.Count; i++)
		{
			Image image = _images[i];
			if (rmode != ResourceWriteMode.SatelliteFile)
			{
				image._WriteToInternal();
				continue;
			}
			string satelliteUri = ((_images.Count != 1) ? $"{baseName}_{i}" : (baseName ?? ""));
			image._WriteToSatellite(context, satelliteUri);
		}
	}

	internal void _AfterWriting()
	{
		foreach (Buffer buffer in _buffers)
		{
			buffer._ClearAfterWrite();
		}
		foreach (Image image in _images)
		{
			image._ClearAfterWrite();
		}
	}
}
