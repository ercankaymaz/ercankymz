using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using SharpGLTF.IO;

namespace SharpGLTF.Schema2;

public static class ExtensionsFactory
{
	[DebuggerDisplay("{Name} {ParentType} {ExtType}")]
	internal readonly struct ExtensionEntry
	{
		public readonly string Name;

		public readonly Type ParentType;

		public readonly Type ExtType;

		public readonly Func<JsonSerializable, JsonSerializable> Factory;

		public static ExtensionEntry Create<TParent, TExtension>(string persistentName) where TParent : JsonSerializable where TExtension : JsonSerializable
		{
			Type extType = typeof(TExtension);
			return new ExtensionEntry(persistentName, typeof(TParent), extType, factory);
			JsonSerializable factory(JsonSerializable parent)
			{
				return Activator.CreateInstance(extType, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[1] { parent }, null) as JsonSerializable;
			}
		}

		public ExtensionEntry(string n, Type p, Type e, Func<JsonSerializable, JsonSerializable> f)
		{
			Name = n;
			ParentType = p;
			ExtType = e;
			Factory = f;
		}

		public bool IsMatch(Type parentType, string extensionName)
		{
			if (ParentType.IsAssignableFrom(parentType))
			{
				return Name == extensionName;
			}
			return false;
		}

		public bool IsMatch(Type parentType, Type extensionType)
		{
			if (ParentType.IsAssignableFrom(parentType))
			{
				return ExtType == extensionType;
			}
			return false;
		}
	}

	private static readonly List<ExtensionEntry> _Extensions;

	public static IEnumerable<string> SupportedExtensions => _Extensions.Select((ExtensionEntry item) => item.Name).Concat(new string[1] { "KHR_mesh_quantization" });

	static ExtensionsFactory()
	{
		_Extensions = new List<ExtensionEntry>();
		RegisterExtension<ModelRoot, _ModelPunctualLights>("KHR_lights_punctual", (ModelRoot p) => new _ModelPunctualLights(p));
		RegisterExtension<Node, _NodePunctualLight>("KHR_lights_punctual", (Node p) => new _NodePunctualLight(p));
		RegisterExtension<Node, MeshGpuInstancing>("EXT_mesh_gpu_instancing", (Node p) => new MeshGpuInstancing(p));
		RegisterExtension<Material, MaterialUnlit>("KHR_materials_unlit", (Material p) => new MaterialUnlit(p));
		RegisterExtension<Material, MaterialSheen>("KHR_materials_sheen", (Material p) => new MaterialSheen(p));
		RegisterExtension<Material, MaterialIOR>("KHR_materials_ior", (Material p) => new MaterialIOR(p));
		RegisterExtension<Material, MaterialDispersion>("KHR_materials_dispersion", (Material p) => new MaterialDispersion(p));
		RegisterExtension<Material, MaterialSpecular>("KHR_materials_specular", (Material p) => new MaterialSpecular(p));
		RegisterExtension<Material, MaterialClearCoat>("KHR_materials_clearcoat", (Material p) => new MaterialClearCoat(p));
		RegisterExtension<Material, MaterialTransmission>("KHR_materials_transmission", (Material p) => new MaterialTransmission(p));
		RegisterExtension<Material, MaterialDiffuseTransmission>("KHR_materials_diffuse_transmission", (Material p) => new MaterialDiffuseTransmission(p));
		RegisterExtension<Material, MaterialVolume>("KHR_materials_volume", (Material p) => new MaterialVolume(p));
		RegisterExtension<Material, MaterialEmissiveStrength>("KHR_materials_emissive_strength", (Material p) => new MaterialEmissiveStrength(p));
		RegisterExtension<Material, MaterialPBRSpecularGlossiness>("KHR_materials_pbrSpecularGlossiness", (Material p) => new MaterialPBRSpecularGlossiness(p));
		RegisterExtension<Material, MaterialIridescence>("KHR_materials_iridescence", (Material p) => new MaterialIridescence(p));
		RegisterExtension<Material, MaterialAnisotropy>("KHR_materials_anisotropy", (Material p) => new MaterialAnisotropy(p));
		RegisterExtension<TextureInfo, TextureTransform>("KHR_texture_transform", (TextureInfo p) => new TextureTransform(p));
		RegisterExtension<Texture, TextureDDS>("MSFT_texture_dds", (Texture p) => new TextureDDS(p));
		RegisterExtension<Texture, TextureWEBP>("EXT_texture_webp", (Texture p) => new TextureWEBP(p));
		RegisterExtension<Texture, TextureKTX2>("KHR_texture_basisu", (Texture p) => new TextureKTX2(p));
		RegisterExtension<ModelRoot, XmpPackets>("KHR_xmp_json_ld", (ModelRoot p) => new XmpPackets(p));
		RegisterExtension<ExtraProperties, XmpPacketReference>("KHR_xmp_json_ld", (ExtraProperties p) => new XmpPacketReference(p));
		RegisterExtension<AnimationChannelTarget, AnimationPointer>("KHR_animation_pointer", (AnimationChannelTarget p) => new AnimationPointer(p));
	}

	[Obsolete("Use RegisterExtension(name, factory) instead.")]
	public static void RegisterExtension<TParent, TExtension>(string persistentName) where TParent : JsonSerializable where TExtension : JsonSerializable
	{
		Guard.NotNullOrEmpty(persistentName, "persistentName");
		Guard.MustBeNull(Identify(typeof(TParent), typeof(TExtension)), "TExtension already registered for TParent");
		ExtensionEntry item = ExtensionEntry.Create<TParent, TExtension>(persistentName);
		_Extensions.Add(item);
	}

	public static void RegisterExtension<TParent, TExtension>(string persistentName, Func<TParent, JsonSerializable> factory) where TParent : JsonSerializable where TExtension : JsonSerializable
	{
		Guard.NotNullOrEmpty(persistentName, "persistentName");
		Guard.MustBeNull(Identify(typeof(TParent), typeof(TExtension)), "TExtension already registered for TParent");
		ExtensionEntry item = new ExtensionEntry(persistentName, typeof(TParent), typeof(TExtension), (JsonSerializable p) => factory((TParent)p));
		_Extensions.Add(item);
	}

	internal static JsonSerializable Create(JsonSerializable parent, string extensionName)
	{
		Type ptype = parent.GetType();
		ExtensionEntry extensionEntry = _Extensions.FirstOrDefault((ExtensionEntry item) => item.IsMatch(ptype, extensionName));
		if (extensionEntry.Name == null)
		{
			return null;
		}
		JsonSerializable jsonSerializable = extensionEntry.Factory(parent);
		return jsonSerializable ?? throw new InvalidOperationException("Could not create an instance of " + extensionName);
	}

	internal static string Identify(Type parentType, Type extensionType)
	{
		foreach (ExtensionEntry extension in _Extensions)
		{
			if (extension.IsMatch(parentType, extensionType))
			{
				return extension.Name;
			}
		}
		return null;
	}
}
