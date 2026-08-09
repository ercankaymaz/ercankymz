using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.Json.Nodes;
using SharpGLTF.Animations;
using SharpGLTF.Geometry;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.IO;
using SharpGLTF.Materials;
using SharpGLTF.Memory;
using SharpGLTF.Runtime;
using SharpGLTF.Scenes;
using SharpGLTF.Transforms;

namespace SharpGLTF.Schema2;

public static class Toolkit
{
	public static Accessor CreateMorphTargetAccessor(this ModelRoot root, MemoryAccessor memAccessor, int sparsityPercent = 60)
	{
		SharpGLTF.Guard.NotNull(root, "root");
		SharpGLTF.Guard.NotNull(memAccessor, "memAccessor");
		Accessor accessor = root.CreateAccessor(memAccessor.Attribute.Name);
		var (memoryAccessor, sparseValues) = memAccessor.ConvertToSparse();
		if (memoryAccessor.Attribute.ItemsCount == 0)
		{
			accessor.SetZeros(memAccessor.Attribute);
			return accessor;
		}
		int num = memoryAccessor.Attribute.ItemsCount * 100 / memAccessor.Attribute.ItemsCount;
		if (num > sparsityPercent)
		{
			accessor.SetVertexData(memAccessor);
			return accessor;
		}
		accessor.SetZeros(memAccessor.Attribute);
		accessor.SetSparseData(memoryAccessor, sparseValues);
		return accessor;
	}

	public static Accessor CreateVertexAccessor(this ModelRoot root, MemoryAccessor memAccessor)
	{
		SharpGLTF.Guard.NotNull(root, "root");
		SharpGLTF.Guard.NotNull(memAccessor, "memAccessor");
		Accessor accessor = root.CreateAccessor(memAccessor.Attribute.Name);
		accessor.SetVertexData(memAccessor);
		return accessor;
	}

	public unsafe static BufferView CreateBufferView<T>(this ModelRoot root, IReadOnlyList<T> data) where T : unmanaged
	{
		SharpGLTF.Guard.NotNull(root, "root");
		SharpGLTF.Guard.NotNull(data, "data");
		BufferView bufferView = root.CreateBufferView(sizeof(T) * data.Count);
		if (typeof(T) == typeof(int))
		{
			new IntegerArray(bufferView.Content).Fill(data as IReadOnlyList<int>);
			return bufferView;
		}
		if (typeof(T) == typeof(float))
		{
			new ScalarArray(bufferView.Content).Fill(data as IReadOnlyList<float>);
			return bufferView;
		}
		if (typeof(T) == typeof(Vector2))
		{
			new Vector2Array(bufferView.Content).Fill(data as IReadOnlyList<Vector2>);
			return bufferView;
		}
		if (typeof(T) == typeof(Vector3))
		{
			new Vector3Array(bufferView.Content).Fill(data as IReadOnlyList<Vector3>);
			return bufferView;
		}
		if (typeof(T) == typeof(Vector4))
		{
			new Vector4Array(bufferView.Content).Fill(data as IReadOnlyList<Vector4>);
			return bufferView;
		}
		if (typeof(T) == typeof(Quaternion))
		{
			new QuaternionArray(bufferView.Content).Fill(data as IReadOnlyList<Quaternion>);
			return bufferView;
		}
		if (typeof(T) == typeof(Matrix4x4))
		{
			new Matrix4x4Array(bufferView.Content).Fill(data as IReadOnlyList<Matrix4x4>);
			return bufferView;
		}
		throw new ArgumentException(typeof(T).Name);
	}

	public static Animation UseAnimation(this ModelRoot root, string name)
	{
		SharpGLTF.Guard.NotNull(root, "root");
		Animation animation = root.LogicalAnimations.FirstOrDefault((Animation item) => item.Name == name);
		return animation ?? root.CreateAnimation(name);
	}

	public static Node WithScaleAnimation(this Node node, string animationName, ICurveSampler<Vector3> sampler)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		if (sampler is IConvertibleCurve<Vector3> convertibleCurve)
		{
			Animation animation = node.LogicalParent.UseAnimation(animationName);
			int maxDegree = convertibleCurve.MaxDegree;
			if (maxDegree == 0)
			{
				animation.CreateScaleChannel(node, convertibleCurve.ToStepCurve(), linear: false);
			}
			if (maxDegree == 1)
			{
				animation.CreateScaleChannel(node, convertibleCurve.ToLinearCurve());
			}
			if (maxDegree == 3)
			{
				animation.CreateScaleChannel(node, convertibleCurve.ToSplineCurve());
			}
			return node;
		}
		throw new ArgumentException("Must implement IConvertibleCurve<Vector3>", "sampler");
	}

	public static Node WithTranslationAnimation(this Node node, string animationName, ICurveSampler<Vector3> sampler)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		if (sampler is IConvertibleCurve<Vector3> convertibleCurve)
		{
			Animation animation = node.LogicalParent.UseAnimation(animationName);
			int maxDegree = convertibleCurve.MaxDegree;
			if (maxDegree == 0)
			{
				animation.CreateTranslationChannel(node, convertibleCurve.ToStepCurve(), linear: false);
			}
			if (maxDegree == 1)
			{
				animation.CreateTranslationChannel(node, convertibleCurve.ToLinearCurve());
			}
			if (maxDegree == 3)
			{
				animation.CreateTranslationChannel(node, convertibleCurve.ToSplineCurve());
			}
			return node;
		}
		throw new ArgumentException("Must implement IConvertibleCurve<Vector3>", "sampler");
	}

	public static Node WithMorphingAnimation(this Node node, string animationName, ICurveSampler<SparseWeight8> sampler)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNull(node.MorphWeights, "MorphWeights", "Set node.MorphWeights before setting morphing animation");
		SharpGLTF.Guard.MustBeGreaterThanOrEqualTo(node.MorphWeights.Count, 0, "MorphWeights");
		if (sampler is IConvertibleCurve<SparseWeight8> convertibleCurve)
		{
			Animation animation = node.LogicalParent.UseAnimation(animationName);
			int maxDegree = convertibleCurve.MaxDegree;
			if (maxDegree == 0)
			{
				animation.CreateMorphChannel(node, convertibleCurve.ToStepCurve(), node.MorphWeights.Count, linear: false);
			}
			if (maxDegree == 1)
			{
				animation.CreateMorphChannel(node, convertibleCurve.ToLinearCurve(), node.MorphWeights.Count);
			}
			if (maxDegree == 3)
			{
				animation.CreateMorphChannel(node, convertibleCurve.ToSplineCurve(), node.MorphWeights.Count);
			}
		}
		return node;
	}

	public static Node WithMorphingAnimation<T>(this Node node, string animationName, ICurveSampler<T> sampler) where T : IReadOnlyList<float>
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNull(node.MorphWeights, "MorphWeights", "Set node.MorphWeights before setting morphing animation");
		SharpGLTF.Guard.MustBeGreaterThanOrEqualTo(node.MorphWeights.Count, 0, "MorphWeights");
		if (sampler is IConvertibleCurve<float[]> convertibleCurve)
		{
			Animation animation = node.LogicalParent.UseAnimation(animationName);
			int maxDegree = convertibleCurve.MaxDegree;
			if (maxDegree == 0)
			{
				animation.CreateMorphChannel(node, convertibleCurve.ToStepCurve(), node.MorphWeights.Count, linear: false);
			}
			if (maxDegree == 1)
			{
				animation.CreateMorphChannel(node, convertibleCurve.ToLinearCurve(), node.MorphWeights.Count);
			}
			if (maxDegree == 3)
			{
				animation.CreateMorphChannel(node, convertibleCurve.ToSplineCurve(), node.MorphWeights.Count);
			}
		}
		if (sampler is IConvertibleCurve<ArraySegment<float>> convertibleCurve2)
		{
			Animation animation2 = node.LogicalParent.UseAnimation(animationName);
			int maxDegree2 = convertibleCurve2.MaxDegree;
			if (maxDegree2 == 0)
			{
				animation2.CreateMorphChannel(node, convertibleCurve2.ToStepCurve(), node.MorphWeights.Count, linear: false);
			}
			if (maxDegree2 == 1)
			{
				animation2.CreateMorphChannel(node, convertibleCurve2.ToLinearCurve(), node.MorphWeights.Count);
			}
			if (maxDegree2 == 3)
			{
				animation2.CreateMorphChannel(node, convertibleCurve2.ToSplineCurve(), node.MorphWeights.Count);
			}
		}
		return node;
	}

	public static Node WithRotationAnimation(this Node node, string animationName, ICurveSampler<Quaternion> sampler)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		if (sampler is IConvertibleCurve<Quaternion> convertibleCurve)
		{
			Animation animation = node.LogicalParent.UseAnimation(animationName);
			int maxDegree = convertibleCurve.MaxDegree;
			if (maxDegree == 0)
			{
				animation.CreateRotationChannel(node, convertibleCurve.ToStepCurve(), linear: false);
			}
			if (maxDegree == 1)
			{
				animation.CreateRotationChannel(node, convertibleCurve.ToLinearCurve());
			}
			if (maxDegree == 3)
			{
				animation.CreateRotationChannel(node, convertibleCurve.ToSplineCurve());
			}
			return node;
		}
		throw new ArgumentException("Must implement IConvertibleCurve<Quaternion>", "sampler");
	}

	public static Node WithScaleAnimation(this Node node, string animationName, params (float Key, Vector3 Value)[] keyframes)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNullOrEmpty(keyframes, "keyframes");
		Dictionary<float, Vector3> keyframes2 = keyframes.ToDictionary(((float Key, Vector3 Value) kvp) => kvp.Key, ((float Key, Vector3 Value) kvp) => kvp.Value);
		return node.WithScaleAnimation(animationName, keyframes2);
	}

	public static Node WithRotationAnimation(this Node node, string animationName, params (float Key, Quaternion Value)[] keyframes)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNullOrEmpty(keyframes, "keyframes");
		Dictionary<float, Quaternion> keyframes2 = keyframes.ToDictionary(((float Key, Quaternion Value) kvp) => kvp.Key, ((float Key, Quaternion Value) kvp) => kvp.Value);
		return node.WithRotationAnimation(animationName, keyframes2);
	}

	public static Node WithTranslationAnimation(this Node node, string animationName, params (float Key, Vector3 Value)[] keyframes)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNullOrEmpty(keyframes, "keyframes");
		Dictionary<float, Vector3> keyframes2 = keyframes.ToDictionary(((float Key, Vector3 Value) kvp) => kvp.Key, ((float Key, Vector3 Value) kvp) => kvp.Value);
		return node.WithTranslationAnimation(animationName, keyframes2);
	}

	public static Node WithScaleAnimation(this Node node, string animationName, IReadOnlyDictionary<float, Vector3> keyframes)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNullOrEmpty(keyframes, "keyframes");
		ModelRoot logicalParent = node.LogicalParent;
		Animation animation = logicalParent.UseAnimation(animationName);
		animation.CreateScaleChannel(node, keyframes);
		return node;
	}

	public static Node WithRotationAnimation(this Node node, string animationName, IReadOnlyDictionary<float, Quaternion> keyframes)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNullOrEmpty(keyframes, "keyframes");
		ModelRoot logicalParent = node.LogicalParent;
		Animation animation = logicalParent.UseAnimation(animationName);
		animation.CreateRotationChannel(node, keyframes);
		return node;
	}

	public static Node WithTranslationAnimation(this Node node, string animationName, IReadOnlyDictionary<float, Vector3> keyframes)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNullOrEmpty(keyframes, "keyframes");
		ModelRoot logicalParent = node.LogicalParent;
		Animation animation = logicalParent.UseAnimation(animationName);
		animation.CreateTranslationChannel(node, keyframes);
		return node;
	}

	public static PunctualLight WithSpotCone(this PunctualLight light, float innerConeAngle, float outerConeAngle)
	{
		SharpGLTF.Guard.NotNull(light, "light");
		light.SetSpotCone(innerConeAngle, outerConeAngle);
		return light;
	}

	public static PunctualLight WithColor(this PunctualLight light, Vector3 color, float intensity = 1f, float range = float.PositiveInfinity)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(light, "light");
		light.Color = color;
		light.Intensity = intensity;
		light.Range = range;
		return light;
	}

	public static Material WithDefault(this Material material)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		return material.WithPBRMetallicRoughness();
	}

	public static Material WithDefault(this Material material, Vector4 diffuseColor)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(material, "material");
		MaterialChannel value = material.WithPBRMetallicRoughness().FindChannel("BaseColor").Value;
		value.Color = diffuseColor;
		return material;
	}

	public static Material WithDoubleSide(this Material material, bool enabled)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		material.DoubleSided = enabled;
		return material;
	}

	[Obsolete("don't use vector4 based parameter. Use WithChannelColor and WithChannelFactor instead.")]
	public static Material WithChannelParameter(this Material material, string channelName, Vector4 parameter)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(material, "material");
		MaterialChannel value = material.FindChannel(channelName).Value;
		value.Parameter = parameter;
		return material;
	}

	public static Material WithChannelColor(this Material material, string channelName, Vector4 color)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(material, "material");
		MaterialChannel value = material.FindChannel(channelName).Value;
		value.Color = color;
		return material;
	}

	public static Material WithChannelFactor(this Material material, string channelName, string paramName, float factor)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		material.FindChannel(channelName).Value.SetFactor(paramName, factor);
		return material;
	}

	public static Material WithChannelTexture(this Material material, string channelName, int textureSet, string imageFilePath)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		Image image = material.LogicalParent.UseImageWithFile(imageFilePath);
		return material.WithChannelTexture(channelName, textureSet, image);
	}

	public static Material WithChannelTexture(this Material material, string channelName, int textureSet, Image image)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		material.FindChannel(channelName).Value.SetTexture(textureSet, image);
		return material;
	}

	public static Material WithPBRMetallicRoughness(this Material material)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		material.InitializePBRMetallicRoughness();
		return material;
	}

	public static Material WithPBRMetallicRoughness(this Material material, Vector4 baseColor, string baseColorImageFilePath, string metallicImageFilePath = null, float metallicFactor = 1f, float roughnessFactor = 1f)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(material, "material");
		material.WithPBRMetallicRoughness().WithChannelColor("BaseColor", baseColor).WithChannelFactor("MetallicRoughness", "MetallicFactor", metallicFactor)
			.WithChannelFactor("MetallicRoughness", "RoughnessFactor", roughnessFactor);
		if (!string.IsNullOrWhiteSpace(baseColorImageFilePath))
		{
			material.WithChannelTexture("BaseColor", 0, baseColorImageFilePath);
		}
		if (!string.IsNullOrWhiteSpace(metallicImageFilePath))
		{
			material.WithChannelTexture("Metallic", 0, baseColorImageFilePath);
		}
		return material;
	}

	[Obsolete("SpecularGlossiness Extension has been declared deprecated by the Khronos Group. Use newer extensions instead.")]
	public static Material WithPBRSpecularGlossiness(this Material material)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		material.InitializePBRSpecularGlossiness();
		return material;
	}

	public static Material WithUnlit(this Material material)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		material.InitializeUnlit();
		return material;
	}

	public static Image UseImageWithFile(this ModelRoot root, string filePath)
	{
		byte[] array = File.ReadAllBytes(filePath);
		return root.UseImageWithContent(array);
	}

	public static Image UseImageWithContent(this ModelRoot root, MemoryImage image)
	{
		SharpGLTF.Guard.NotNull(root, "root");
		return root.UseImage(image);
	}

	public static Material CreateMaterial(this ModelRoot root, MaterialBuilder mb)
	{
		SharpGLTF.Guard.NotNull(root, "root");
		SharpGLTF.Guard.NotNull(mb, "mb");
		Material material = root.CreateMaterial();
		mb.CopyTo(material);
		return material;
	}

	public static MaterialBuilder ToMaterialBuilder(this Material srcMaterial)
	{
		if (srcMaterial == null)
		{
			return MaterialBuilder.CreateDefault();
		}
		MaterialBuilder materialBuilder = new MaterialBuilder(srcMaterial.Name);
		srcMaterial.CopyTo(materialBuilder);
		return materialBuilder;
	}

	public static AlphaMode ToSchema2(this SharpGLTF.Materials.AlphaMode alpha)
	{
		return alpha switch
		{
			SharpGLTF.Materials.AlphaMode.BLEND => AlphaMode.BLEND, 
			SharpGLTF.Materials.AlphaMode.MASK => AlphaMode.MASK, 
			SharpGLTF.Materials.AlphaMode.OPAQUE => AlphaMode.OPAQUE, 
			_ => throw new NotImplementedException(alpha.ToString()), 
		};
	}

	public static SharpGLTF.Materials.AlphaMode ToToolkit(this AlphaMode alpha)
	{
		return alpha switch
		{
			AlphaMode.BLEND => SharpGLTF.Materials.AlphaMode.BLEND, 
			AlphaMode.MASK => SharpGLTF.Materials.AlphaMode.MASK, 
			AlphaMode.OPAQUE => SharpGLTF.Materials.AlphaMode.OPAQUE, 
			_ => throw new NotImplementedException(alpha.ToString()), 
		};
	}

	public static void CopyTo(this Material srcMaterial, MaterialBuilder dstMaterial)
	{
		SharpGLTF.Guard.NotNull(srcMaterial, "srcMaterial");
		SharpGLTF.Guard.NotNull(dstMaterial, "dstMaterial");
		_CopyDefaultTo(srcMaterial, dstMaterial);
		if (srcMaterial.Unlit)
		{
			dstMaterial.WithUnlitShader();
			srcMaterial.CopyChannelsTo(dstMaterial, "BaseColor");
		}
		else if (srcMaterial.FindChannel("Diffuse").HasValue || srcMaterial.FindChannel("SpecularGlossiness").HasValue)
		{
			dstMaterial.WithSpecularGlossinessShader();
			srcMaterial.CopyChannelsTo(dstMaterial, "Diffuse", "SpecularGlossiness");
			if (srcMaterial.FindChannel("BaseColor").HasValue || srcMaterial.FindChannel("MetallicRoughness").HasValue)
			{
				MaterialBuilder materialBuilder = new MaterialBuilder(srcMaterial.Name);
				_CopyDefaultTo(srcMaterial, materialBuilder);
				_CopyMetallicRoughnessTo(srcMaterial, materialBuilder);
				dstMaterial.WithFallback(materialBuilder);
			}
		}
		else if (srcMaterial.FindChannel("BaseColor").HasValue || srcMaterial.FindChannel("MetallicRoughness").HasValue)
		{
			_CopyMetallicRoughnessTo(srcMaterial, dstMaterial);
		}
	}

	private static void _CopyMetallicRoughnessTo(Material srcMaterial, MaterialBuilder dstMaterial)
	{
		dstMaterial.WithMetallicRoughnessShader();
		string[] channelKeys = MaterialBuilder._MetRouChannels.Select((KnownChannel item) => item.ToString()).ToArray();
		srcMaterial.CopyChannelsTo(dstMaterial, channelKeys);
	}

	private static void _CopyDefaultTo(Material srcMaterial, MaterialBuilder dstMaterial)
	{
		SharpGLTF.Guard.NotNull(srcMaterial, "srcMaterial");
		SharpGLTF.Guard.NotNull(dstMaterial, "dstMaterial");
		dstMaterial.SetNameAndExtrasFrom(srcMaterial);
		dstMaterial.AlphaMode = srcMaterial.Alpha.ToToolkit();
		dstMaterial.AlphaCutoff = srcMaterial.AlphaCutoff;
		dstMaterial.DoubleSided = srcMaterial.DoubleSided;
		dstMaterial.Dispersion = srcMaterial.Dispersion;
		dstMaterial.IndexOfRefraction = srcMaterial.IndexOfRefraction;
		srcMaterial.CopyChannelsTo(dstMaterial, "Normal", "Occlusion", "Emissive");
	}

	public static void CopyChannelsTo(this Material srcMaterial, MaterialBuilder dstMaterial, params string[] channelKeys)
	{
		SharpGLTF.Guard.NotNull(srcMaterial, "srcMaterial");
		SharpGLTF.Guard.NotNull(dstMaterial, "dstMaterial");
		SharpGLTF.Guard.NotNull(channelKeys, "channelKeys");
		foreach (string text in channelKeys)
		{
			if (Enum.TryParse<KnownChannel>(text, ignoreCase: true, out var result))
			{
				MaterialChannel? materialChannel = srcMaterial.FindChannel(text);
				if (materialChannel.HasValue && !materialChannel.Value.HasDefaultContent)
				{
					ChannelBuilder dstChannel = dstMaterial.UseChannel(result);
					materialChannel.Value.CopyTo(dstChannel);
				}
			}
		}
	}

	public static void CopyTo(this MaterialChannel srcChannel, ChannelBuilder dstChannel)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(srcChannel, "srcChannel");
		SharpGLTF.Guard.NotNull(dstChannel, "dstChannel");
		foreach (IMaterialParameter parameter in srcChannel.Parameters)
		{
			dstChannel.Parameters[parameter.Name] = MaterialValue.CreateFrom(parameter.Value);
		}
		if (srcChannel.Texture != null)
		{
			if (dstChannel.Texture == null)
			{
				dstChannel.UseTexture();
			}
			dstChannel.Texture.SetNameAndExtrasFrom(srcChannel.Texture);
			dstChannel.Texture.CoordinateSet = srcChannel.TextureCoordinate;
			if (srcChannel.TextureSampler != null)
			{
				dstChannel.Texture.MinFilter = srcChannel.TextureSampler.MinFilter;
				dstChannel.Texture.MagFilter = srcChannel.TextureSampler.MagFilter;
				dstChannel.Texture.WrapS = srcChannel.TextureSampler.WrapS;
				dstChannel.Texture.WrapT = srcChannel.TextureSampler.WrapT;
			}
			TextureTransform textureTransform = srcChannel.TextureTransform;
			if (textureTransform != null)
			{
				dstChannel.Texture.WithTransform(textureTransform.Offset, textureTransform.Scale, textureTransform.Rotation, textureTransform.TextureCoordinateOverride);
			}
			dstChannel.Texture.PrimaryImage = _convert(srcChannel.Texture.PrimaryImage);
			dstChannel.Texture.FallbackImage = _convert(srcChannel.Texture.FallbackImage);
		}
		static ImageBuilder _convert(Image src)
		{
			if (src == null)
			{
				return null;
			}
			ImageBuilder imageBuilder = ImageBuilder.From(src.Content, src.Name, src.Extras?.DeepClone());
			imageBuilder.AlternateWriteFileName = src.AlternateWriteFileName;
			return imageBuilder;
		}
	}

	public static void CopyTo(this MaterialBuilder srcMaterial, Material dstMaterial)
	{
		SharpGLTF.Guard.NotNull(srcMaterial, "srcMaterial");
		SharpGLTF.Guard.NotNull(dstMaterial, "dstMaterial");
		srcMaterial.ValidateForSchema2();
		srcMaterial.TryCopyNameAndExtrasTo(dstMaterial);
		dstMaterial.Alpha = srcMaterial.AlphaMode.ToSchema2();
		dstMaterial.AlphaCutoff = ((dstMaterial.Alpha == AlphaMode.MASK) ? srcMaterial.AlphaCutoff : 0.5f);
		dstMaterial.DoubleSided = srcMaterial.DoubleSided;
		bool flag = srcMaterial.GetChannel(KnownChannel.ClearCoat) != null || srcMaterial.GetChannel(KnownChannel.ClearCoatNormal) != null || srcMaterial.GetChannel(KnownChannel.ClearCoatRoughness) != null;
		bool flag2 = srcMaterial.GetChannel(KnownChannel.SheenColor) != null || srcMaterial.GetChannel(KnownChannel.SheenRoughness) != null;
		bool flag3 = srcMaterial.GetChannel(KnownChannel.SpecularColor) != null || srcMaterial.GetChannel(KnownChannel.SpecularFactor) != null;
		bool flag4 = srcMaterial.GetChannel(KnownChannel.VolumeThickness) != null || srcMaterial.GetChannel(KnownChannel.VolumeAttenuation) != null;
		bool flag5 = srcMaterial.GetChannel(KnownChannel.Iridescence) != null || srcMaterial.GetChannel(KnownChannel.IridescenceThickness) != null;
		bool flag6 = srcMaterial.GetChannel(KnownChannel.Anisotropy) != null;
		bool flag7 = srcMaterial.GetChannel(KnownChannel.Transmission) != null;
		bool flag8 = srcMaterial.GetChannel(KnownChannel.DiffuseTransmissionColor) != null || srcMaterial.GetChannel(KnownChannel.DiffuseTransmissionFactor) != null;
		srcMaterial.CopyChannelsTo(dstMaterial, KnownChannel.Normal, KnownChannel.Occlusion, KnownChannel.Emissive);
		MaterialBuilder materialBuilder = null;
		if (srcMaterial.ShaderStyle == "Unlit")
		{
			dstMaterial.InitializeUnlit();
			srcMaterial.CopyChannelsTo(dstMaterial, KnownChannel.BaseColor);
			return;
		}
		if (srcMaterial.ShaderStyle == "PBRMetallicRoughness")
		{
			dstMaterial.InitializePBRMetallicRoughness(flag2 ? "Sheen" : null, flag4 ? "Volume" : null, flag3 ? "Specular" : null, flag ? "ClearCoat" : null, flag6 ? "Anisotropy" : null, flag5 ? "Iridescence" : null, flag7 ? "Transmission" : null, flag8 ? "DiffuseTransmission" : null);
			materialBuilder = srcMaterial;
		}
		if (srcMaterial.ShaderStyle == "PBRSpecularGlossiness")
		{
			dstMaterial.InitializePBRSpecularGlossiness(srcMaterial.CompatibilityFallback != null);
			srcMaterial.CopyChannelsTo(dstMaterial, KnownChannel.Diffuse, KnownChannel.SpecularGlossiness);
			materialBuilder = srcMaterial.CompatibilityFallback;
		}
		dstMaterial.Dispersion = srcMaterial.Dispersion;
		dstMaterial.IndexOfRefraction = srcMaterial.IndexOfRefraction;
		if (materialBuilder != null)
		{
			if (materialBuilder.ShaderStyle != "PBRMetallicRoughness")
			{
				throw new ArgumentException("ShaderStyle");
			}
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.BaseColor, KnownChannel.MetallicRoughness);
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.ClearCoat, KnownChannel.ClearCoatNormal, KnownChannel.ClearCoatRoughness);
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.Transmission);
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.SheenColor, KnownChannel.SheenRoughness);
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.SpecularColor, KnownChannel.SpecularFactor);
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.VolumeThickness, KnownChannel.VolumeAttenuation);
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.Iridescence, KnownChannel.IridescenceThickness);
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.Anisotropy);
			materialBuilder.CopyChannelsTo(dstMaterial, KnownChannel.DiffuseTransmissionColor, KnownChannel.DiffuseTransmissionFactor);
		}
	}

	[Obsolete]
	public static void CopyChannelsTo(this MaterialBuilder srcMaterial, Material dstMaterial, params string[] channels)
	{
		KnownChannel[] channels2 = channels.Select((string key) => Enum.TryParse<KnownChannel>(key, out var result) ? result : KnownChannel.Normal).ToArray();
		srcMaterial.CopyChannelsTo(dstMaterial, channels2);
	}

	public static void CopyChannelsTo(this MaterialBuilder srcMaterial, Material dstMaterial, params KnownChannel[] channels)
	{
		SharpGLTF.Guard.NotNull(srcMaterial, "srcMaterial");
		SharpGLTF.Guard.NotNull(dstMaterial, "dstMaterial");
		SharpGLTF.Guard.NotNull(channels, "channels");
		for (int i = 0; i < channels.Length; i++)
		{
			KnownChannel channelKey = channels[i];
			ChannelBuilder channel = srcMaterial.GetChannel(channelKey);
			if (channel != null)
			{
				MaterialChannel? materialChannel = dstMaterial.FindChannel(channelKey.ToString());
				if (materialChannel.HasValue)
				{
					channel.CopyTo(materialChannel.Value);
				}
			}
		}
	}

	public static void CopyTo(this ChannelBuilder srcChannel, MaterialChannel dstChannel)
	{
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(srcChannel, "srcChannel");
		SharpGLTF.Guard.NotNull(dstChannel, "dstChannel");
		foreach (IMaterialParameter parameter in dstChannel.Parameters)
		{
			parameter.Value = srcChannel.Parameters[parameter.Name].ToTypeless();
		}
		TextureBuilder validTexture = srcChannel.GetValidTexture();
		if (validTexture == null)
		{
			return;
		}
		Image image = null;
		Image fallbackImg = null;
		if (ImageBuilder.IsValid(validTexture.PrimaryImage))
		{
			image = _ConvertToImage(dstChannel, validTexture.PrimaryImage);
		}
		if (image != null)
		{
			if (ImageBuilder.IsValid(validTexture.FallbackImage))
			{
				fallbackImg = _ConvertToImage(dstChannel, validTexture.FallbackImage);
			}
			Texture target = dstChannel.SetTexture(validTexture.CoordinateSet, image, fallbackImg, validTexture.WrapS, validTexture.WrapT, validTexture.MinFilter, validTexture.MagFilter);
			validTexture.TryCopyNameAndExtrasTo(target);
			TextureTransformBuilder transform = validTexture.Transform;
			if (transform != null)
			{
				dstChannel.SetTransform(transform.Offset, transform.Scale, transform.Rotation, transform.CoordinateSetOverride);
			}
		}
	}

	private static Image _ConvertToImage(MaterialChannel dstChannel, ImageBuilder srcImage)
	{
		Image image = dstChannel.LogicalParent.LogicalParent.UseImageWithContent(srcImage.Content);
		image.AlternateWriteFileName = srcImage.AlternateWriteFileName;
		srcImage.TryCopyNameAndExtrasTo(image);
		return image;
	}

	public static Vector4 GetDiffuseColor(this Material material, Vector4 defaultColor)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (material == null)
		{
			return defaultColor;
		}
		MaterialChannel? materialChannel = material.FindChannel("Diffuse");
		if (materialChannel.HasValue)
		{
			return materialChannel.Value.Color;
		}
		materialChannel = material.FindChannel("BaseColor");
		if (materialChannel.HasValue)
		{
			return materialChannel.Value.Color;
		}
		return defaultColor;
	}

	public static Texture GetDiffuseTexture(this Material material)
	{
		if (material == null)
		{
			return null;
		}
		MaterialChannel? materialChannel = material.FindChannel("Diffuse");
		if (materialChannel.HasValue)
		{
			return materialChannel.Value.Texture;
		}
		materialChannel = material.FindChannel("BaseColor");
		if (materialChannel.HasValue)
		{
			return materialChannel.Value.Texture;
		}
		return null;
	}

	public static TextureTransform GetDiffuseTextureTransform(this Material material)
	{
		if (material == null)
		{
			return null;
		}
		MaterialChannel? materialChannel = material.FindChannel("Diffuse");
		if (materialChannel.HasValue)
		{
			return materialChannel.Value.TextureTransform;
		}
		materialChannel = material.FindChannel("BaseColor");
		if (materialChannel.HasValue)
		{
			return materialChannel.Value.TextureTransform;
		}
		return null;
	}

	public static Matrix3x2? GetDiffuseTextureMatrix(this Material material, Animation track, float time)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		return material.GetDiffuseTextureTransform()?.Matrix;
	}

	public static Mesh CreateMesh(this ModelRoot root, IMeshBuilder<MaterialBuilder> mesh)
	{
		return root.CreateMeshes(mesh)[0];
	}

	public static Mesh CreateMesh<TMaterial>(this ModelRoot root, Converter<TMaterial, Material> materialEvaluator, IMeshBuilder<TMaterial> mesh)
	{
		return root.CreateMeshes(materialEvaluator, mesh)[0];
	}

	public static IReadOnlyList<Mesh> CreateMeshes(this ModelRoot root, params IMeshBuilder<MaterialBuilder>[] meshBuilders)
	{
		Dictionary<MaterialBuilder, Material> materials = new Dictionary<MaterialBuilder, Material>(MaterialBuilder.ContentComparer);
		return root.CreateMeshes(matFactory, meshBuilders);
		Material matFactory(MaterialBuilder srcMat)
		{
			if (materials.TryGetValue(srcMat, out var value))
			{
				return value;
			}
			return materials[srcMat] = root.CreateMaterial(srcMat);
		}
	}

	public static IReadOnlyList<Mesh> CreateMeshes<TMaterial>(this ModelRoot root, Converter<TMaterial, Material> materialConverter, params IMeshBuilder<TMaterial>[] meshBuilders)
	{
		SharpGLTF.Guard.NotNull(root, "root");
		SharpGLTF.Guard.NotNull(materialConverter, "materialConverter");
		SharpGLTF.Guard.NotNull(meshBuilders, "meshBuilders");
		return root.CreateMeshes(materialConverter, SceneBuilderSchema2Settings.Default, meshBuilders);
	}

	public static IReadOnlyList<Mesh> CreateMeshes<TMaterial>(this ModelRoot root, Converter<TMaterial, Material> materialConverter, SceneBuilderSchema2Settings settings, params IMeshBuilder<TMaterial>[] meshBuilders)
	{
		SharpGLTF.Guard.NotNull(root, "root");
		SharpGLTF.Guard.NotNull(materialConverter, "materialConverter");
		SharpGLTF.Guard.NotNull(meshBuilders, "meshBuilders");
		SharpGLTF.Guard.IsTrue(meshBuilders.Length == meshBuilders.Distinct().Count(), "meshBuilders", "The collection has repeated meshes.");
		foreach (IMeshBuilder<TMaterial> meshBuilder in meshBuilders)
		{
			meshBuilder.Validate();
		}
		Dictionary<TMaterial, Material> mapMaterials = (from primitiveReader in meshBuilders.SelectMany((IMeshBuilder<TMaterial> meshBuilder2) => meshBuilder2.Primitives)
			where !primitiveReader.IsEmpty()
			select primitiveReader.Material).Distinct().ToDictionary((TMaterial m) => m, (TMaterial m) => materialConverter(m));
		List<PackedMeshBuilder<TMaterial>> list = PackedMeshBuilder<TMaterial>.CreatePackedMeshes(meshBuilders, settings).ToList();
		if (settings.MergeBuffers)
		{
			PackedMeshBuilder<TMaterial>.MergeBuffers(list);
		}
		List<Mesh> list2 = new List<Mesh>();
		foreach (PackedMeshBuilder<TMaterial> item2 in list)
		{
			Mesh item = item2.CreateSchema2Mesh(root, (TMaterial m) => mapMaterials[m]);
			list2.Add(item);
		}
		return list2;
	}

	public static MeshPrimitive WithIndicesAutomatic(this MeshPrimitive primitive, PrimitiveType primitiveType)
	{
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		ModelRoot logicalParent = primitive.LogicalParent.LogicalParent;
		primitive.DrawPrimitiveType = primitiveType;
		primitive.SetIndexAccessor(null);
		return primitive;
	}

	public static MeshPrimitive WithIndicesAccessor(this MeshPrimitive primitive, PrimitiveType primitiveType, IReadOnlyList<int> values)
	{
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.NotNull(values, "values");
		ModelRoot logicalParent = primitive.LogicalParent.LogicalParent;
		BufferView bufferView = logicalParent.CreateBufferView(4 * values.Count, 0, BufferMode.ELEMENT_ARRAY_BUFFER);
		new IntegerArray(bufferView.Content).Fill(values);
		Accessor accessor = logicalParent.CreateAccessor();
		accessor.SetIndexData(bufferView, 0, values.Count, IndexEncodingType.UNSIGNED_INT);
		primitive.DrawPrimitiveType = primitiveType;
		primitive.SetIndexAccessor(accessor);
		return primitive;
	}

	public static MeshPrimitive WithVertexAccessor<T>(this MeshPrimitive primitive, string attribute, IReadOnlyList<T> values, bool useExplicitByteStride = false) where T : unmanaged
	{
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.NotNull(values, "values");
		ModelRoot root = primitive.LogicalParent.LogicalParent;
		SharpGLTF.Guard.NotNull(root, "primitive", "not initialized.");
		IReadOnlyList<float> readOnlyList = values as IReadOnlyList<float>;
		if (readOnlyList == null)
		{
			IReadOnlyList<Vector2> readOnlyList2 = values as IReadOnlyList<Vector2>;
			if (readOnlyList2 == null)
			{
				IReadOnlyList<Vector3> readOnlyList3 = values as IReadOnlyList<Vector3>;
				if (readOnlyList3 == null)
				{
					IReadOnlyList<Vector4> readOnlyList4 = values as IReadOnlyList<Vector4>;
					if (readOnlyList4 == null)
					{
						IReadOnlyList<Quaternion> readOnlyList5 = values as IReadOnlyList<Quaternion>;
						if (readOnlyList5 == null)
						{
							throw new InvalidOperationException("Unsupported type " + typeof(T).Name);
						}
						_initialize(DimensionType.VEC4, delegate(BufferView view)
						{
							new QuaternionArray(view.Content).Fill(readOnlyList5);
						});
					}
					else
					{
						_initialize(DimensionType.VEC4, delegate(BufferView view)
						{
							new Vector4Array(view.Content).Fill(readOnlyList4);
						});
					}
				}
				else
				{
					_initialize(DimensionType.VEC3, delegate(BufferView view)
					{
						new Vector3Array(view.Content).Fill(readOnlyList3);
					});
				}
			}
			else
			{
				_initialize(DimensionType.VEC2, delegate(BufferView view)
				{
					new Vector2Array(view.Content).Fill(readOnlyList2);
				});
			}
		}
		else
		{
			_initialize(DimensionType.SCALAR, delegate(BufferView view)
			{
				new ScalarArray(view.Content).Fill(readOnlyList);
			});
		}
		return primitive;
		unsafe void _initialize(DimensionType dims, Action<BufferView> fillFunc)
		{
			int num = sizeof(T);
			BufferView bufferView = root.CreateBufferView(num * values.Count, useExplicitByteStride ? num : 0, BufferMode.ARRAY_BUFFER);
			fillFunc(bufferView);
			Accessor accessor = root.CreateAccessor();
			primitive.SetVertexAccessor(attribute, accessor);
			accessor.SetVertexData(bufferView, 0, values.Count, new AttributeFormat(dims, EncodingType.FLOAT, nrm: false));
		}
	}

	public static MeshPrimitive WithVertexAccessors(this MeshPrimitive primitive, IReadOnlyList<VertexPosition> vertices)
	{
		List<VertexBuilder<VertexPosition, VertexEmpty, VertexEmpty>> vertices2 = vertices.Select((VertexPosition item) => new VertexBuilder<VertexPosition, VertexEmpty, VertexEmpty>(in item)).ToList();
		return primitive.WithVertexAccessors(vertices2);
	}

	public static MeshPrimitive WithVertexAccessors(this MeshPrimitive primitive, IReadOnlyList<VertexPositionNormal> vertices)
	{
		List<VertexBuilder<VertexPositionNormal, VertexEmpty, VertexEmpty>> vertices2 = vertices.Select((VertexPositionNormal item) => new VertexBuilder<VertexPositionNormal, VertexEmpty, VertexEmpty>(in item)).ToList();
		return primitive.WithVertexAccessors(vertices2);
	}

	public static MeshPrimitive WithVertexAccessors<TvP, TvM>(this MeshPrimitive primitive, IReadOnlyList<(TvP Geo, TvM Mat)> vertices) where TvP : struct, IVertexGeometry where TvM : struct, IVertexMaterial
	{
		List<VertexBuilder<TvP, TvM, VertexEmpty>> vertices2 = vertices.Select(((TvP Geo, TvM Mat) item) => new VertexBuilder<TvP, TvM, VertexEmpty>(in item.Geo, in item.Mat)).ToList();
		return primitive.WithVertexAccessors(vertices2);
	}

	public static MeshPrimitive WithVertexAccessors<TvP, TvM, TvS>(this MeshPrimitive primitive, IReadOnlyList<(TvP Geo, TvM Mat, TvS Skin)> vertices) where TvP : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
	{
		List<VertexBuilder<TvP, TvM, TvS>> vertices2 = vertices.Select(((TvP Geo, TvM Mat, TvS Skin) item) => new VertexBuilder<TvP, TvM, TvS>(in item.Geo, in item.Mat, in item.Skin)).ToList();
		return primitive.WithVertexAccessors(vertices2);
	}

	public static MeshPrimitive WithVertexAccessors<TVertex>(this MeshPrimitive primitive, IReadOnlyList<TVertex> vertices) where TVertex : IVertexBuilder
	{
		MemoryAccessor[] memAccessors = vertices.CreateVertexMemoryAccessors(new PackedEncoding());
		return primitive.WithVertexAccessors((IEnumerable<MemoryAccessor>)memAccessors);
	}

	public static MeshPrimitive WithVertexAccessors(this MeshPrimitive primitive, IEnumerable<MemoryAccessor> memAccessors)
	{
		SharpGLTF.Guard.NotNull(memAccessors, "memAccessors");
		memAccessors = memAccessors.EnsureList();
		SharpGLTF.Guard.IsTrue(memAccessors.All((MemoryAccessor item) => item != null), "memAccessors");
		foreach (MemoryAccessor memAccessor in memAccessors)
		{
			primitive.WithVertexAccessor(memAccessor);
		}
		return primitive;
	}

	public static MeshPrimitive WithVertexAccessor(this MeshPrimitive primitive, MemoryAccessor memAccessor)
	{
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.NotNull(memAccessor, "memAccessor");
		ModelRoot logicalParent = primitive.LogicalParent.LogicalParent;
		primitive.SetVertexAccessor(memAccessor.Attribute.Name, logicalParent.CreateVertexAccessor(memAccessor));
		return primitive;
	}

	public static MeshPrimitive WithIndicesAccessor(this MeshPrimitive primitive, PrimitiveType primitiveType, MemoryAccessor memAccessor)
	{
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		ModelRoot logicalParent = primitive.LogicalParent.LogicalParent;
		Accessor accessor = logicalParent.CreateAccessor();
		accessor.SetIndexData(memAccessor);
		primitive.DrawPrimitiveType = primitiveType;
		primitive.SetIndexAccessor(accessor);
		return primitive;
	}

	public static MeshPrimitive WithMorphTargetAccessors(this MeshPrimitive primitive, int targetIndex, IEnumerable<MemoryAccessor> memAccessors)
	{
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		SharpGLTF.Guard.MustBeGreaterThanOrEqualTo(targetIndex, 0, "targetIndex");
		SharpGLTF.Guard.NotNull(memAccessors, "memAccessors");
		ModelRoot root = primitive.LogicalParent.LogicalParent;
		Dictionary<string, Accessor> accessors = memAccessors.ToDictionary((MemoryAccessor item) => item.Attribute.Name, (MemoryAccessor item) => root.CreateMorphTargetAccessor(item));
		primitive.SetMorphTargetAccessors(targetIndex, accessors);
		return primitive;
	}

	public static MeshGpuInstancing WithInstanceAccessor<T>(this MeshGpuInstancing instancing, string attribute, IReadOnlyList<T> values) where T : unmanaged
	{
		SharpGLTF.Guard.NotNull(instancing, "instancing");
		SharpGLTF.Guard.NotNull(values, "values");
		ModelRoot logicalParent = instancing.LogicalParent.LogicalParent;
		BufferView buffer = logicalParent.CreateBufferView(values);
		Accessor accessor = logicalParent.CreateAccessor();
		if (typeof(T) == typeof(int))
		{
			accessor.SetIndexData(buffer, 0, values.Count, IndexEncodingType.UNSIGNED_INT);
		}
		else
		{
			accessor.SetVertexData(buffer, 0, values.Count, new AttributeFormat(typeof(T).ToDimension()));
		}
		instancing.SetAccessor(attribute, accessor);
		return instancing;
	}

	public static MeshGpuInstancing WithInstanceAccessors(this MeshGpuInstancing instancing, IReadOnlyList<AffineTransform> transforms)
	{
		SharpGLTF.Guard.NotNull(instancing, "instancing");
		SharpGLTF.Guard.NotNull(transforms, "transforms");
		List<AffineTransform> source = transforms.Select((AffineTransform item) => item.GetDecomposed()).ToList();
		bool flag = source.Any((AffineTransform item) => item.Scale != Vector3.One);
		bool flag2 = source.Any((AffineTransform item) => item.Rotation != Quaternion.Identity);
		bool flag3 = source.Any((AffineTransform item) => item.Translation != Vector3.Zero);
		if (flag)
		{
			instancing.WithInstanceAccessor<Vector3>("SCALE", (IReadOnlyList<Vector3>)source.Select((AffineTransform item) => item.Scale).ToList());
		}
		if (flag2)
		{
			instancing.WithInstanceAccessor<Quaternion>("ROTATION", (IReadOnlyList<Quaternion>)source.Select((AffineTransform item) => item.Rotation).ToList());
		}
		if (flag3)
		{
			instancing.WithInstanceAccessor<Vector3>("TRANSLATION", (IReadOnlyList<Vector3>)source.Select((AffineTransform item) => item.Translation).ToList());
		}
		return instancing;
	}

	public static MeshGpuInstancing WithInstanceCustomAccessors(this MeshGpuInstancing instancing, IReadOnlyList<JsonNode> extras)
	{
		SharpGLTF.Guard.NotNull(instancing, "instancing");
		IEnumerable<string> enumerable = from item in (from item in extras.OfType<JsonObject>().SelectMany((JsonObject item) => item)
				select item.Key).Distinct()
			where SharpGLTF._Extensions.StartsWith(item, '_')
			select item;
		foreach (string item in enumerable)
		{
			instancing.WithInstanceCustomAccessor(item, extras);
		}
		return instancing;
	}

	public static MeshGpuInstancing WithInstanceCustomAccessor(this MeshGpuInstancing instancing, string attribute, IReadOnlyList<JsonNode> values)
	{
		SharpGLTF.Guard.NotNullOrEmpty(attribute, "attribute");
		attribute = attribute.ToUpperInvariant();
		List<int> list = _SelectAttribute<int>(values, attribute);
		if (list != null)
		{
			return instancing.WithInstanceAccessor(attribute, list);
		}
		List<float> list2 = _SelectAttribute<float>(values, attribute);
		if (list2 != null)
		{
			return instancing.WithInstanceAccessor(attribute, list2);
		}
		throw new ArgumentException("Can't retrieve " + attribute + " from values", "attribute");
	}

	private static List<T> _SelectAttribute<T>(IReadOnlyList<JsonNode> values, string propertyName)
	{
		List<T> list = new List<T>();
		foreach (JsonNode value2 in values)
		{
			JsonNode jsonNode = value2;
			if (jsonNode is JsonObject jsonObject && !jsonObject.TryGetPropertyValue(propertyName, out jsonNode))
			{
				return null;
			}
			if (!(jsonNode is JsonValue jsonValue))
			{
				return null;
			}
			if (!jsonValue.TryGetValue<T>(out T value))
			{
				return null;
			}
			list.Add(value);
		}
		return list;
	}

	public static MeshPrimitive WithMaterial(this MeshPrimitive primitive, Material material)
	{
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		primitive.Material = material;
		return primitive;
	}

	public static IEnumerable<(IVertexBuilder A, Material Material)> EvaluatePoints(this Mesh mesh, IGeometryTransform xform = null)
	{
		if (mesh == null)
		{
			return Enumerable.Empty<(IVertexBuilder, Material)>();
		}
		return mesh.Primitives.SelectMany((MeshPrimitive item) => item.EvaluatePoints(xform));
	}

	public static IEnumerable<(IVertexBuilder A, Material Material)> EvaluatePoints(this MeshPrimitive prim, IGeometryTransform xform = null)
	{
		if (prim == null || (xform != null && !xform.Visible))
		{
			yield break;
		}
		IEnumerable<int> points = prim.GetPointIndices();
		VertexBufferColumns vertices = null;
		Func<IVertexBuilder> vtype = null;
		foreach (IGeometryTransform item in InstancingTransform.Evaluate(xform))
		{
			if (vertices == null)
			{
				vertices = prim.GetVertexColumns();
			}
			if (vtype == null)
			{
				vtype = vertices.GetCompatibleVertexType().BuilderFactory;
			}
			VertexBufferColumns xvertices = ((item != null) ? vertices.WithTransform(item) : vertices);
			foreach (int item2 in points)
			{
				IVertexBuilder vertex = xvertices.GetVertex(vtype, item2);
				yield return (A: vertex, Material: prim.Material);
			}
		}
	}

	public static IEnumerable<(IVertexBuilder A, IVertexBuilder B, Material Material)> EvaluateLines(this Mesh mesh, IGeometryTransform xform = null)
	{
		if (mesh == null)
		{
			return Enumerable.Empty<(IVertexBuilder, IVertexBuilder, Material)>();
		}
		return mesh.Primitives.SelectMany((MeshPrimitive item) => item.EvaluateLines(xform));
	}

	public static IEnumerable<(IVertexBuilder A, IVertexBuilder B, Material Material)> EvaluateLines(this MeshPrimitive prim, IGeometryTransform xform = null)
	{
		if (prim == null || (xform != null && !xform.Visible))
		{
			yield break;
		}
		IEnumerable<(int A, int B)> lines = prim.GetLineIndices();
		if (!lines.Any())
		{
			yield break;
		}
		VertexBufferColumns vertices = prim.GetVertexColumns();
		Func<IVertexBuilder> vtype = vertices.GetCompatibleVertexType().BuilderFactory;
		foreach (IGeometryTransform item3 in InstancingTransform.Evaluate(xform))
		{
			VertexBufferColumns xvertices = ((item3 != null) ? vertices.WithTransform(item3) : vertices);
			foreach (var item4 in lines)
			{
				int item = item4.A;
				int item2 = item4.B;
				IVertexBuilder vertex = xvertices.GetVertex(vtype, item);
				IVertexBuilder vertex2 = xvertices.GetVertex(vtype, item2);
				yield return (A: vertex, B: vertex2, Material: prim.Material);
			}
		}
	}

	public static IEnumerable<(IVertexBuilder A, IVertexBuilder B, IVertexBuilder C, Material Material)> EvaluateTriangles(this Mesh mesh, IGeometryTransform xform = null)
	{
		if (mesh == null)
		{
			return Enumerable.Empty<(IVertexBuilder, IVertexBuilder, IVertexBuilder, Material)>();
		}
		return mesh.Primitives.SelectMany((MeshPrimitive item) => item.EvaluateTriangles(xform));
	}

	public static IEnumerable<(IVertexBuilder A, IVertexBuilder B, IVertexBuilder C, Material Material)> EvaluateTriangles(this MeshPrimitive prim, IGeometryTransform xform = null)
	{
		if (prim == null || (xform != null && !xform.Visible))
		{
			yield break;
		}
		VertexBufferColumns vertices = prim.GetVertexColumns();
		IEnumerable<(int A, int B, int C)> triangles = prim.GetTriangleIndices();
		if (!triangles.Any())
		{
			yield break;
		}
		foreach (IGeometryTransform item4 in InstancingTransform.Evaluate(xform))
		{
			VertexBufferColumns xvertices = ((item4 != null) ? vertices.WithTransform(item4) : vertices);
			Func<IVertexBuilder> vtype = vertices.GetCompatibleVertexType().BuilderFactory;
			foreach (var item5 in triangles)
			{
				int item = item5.A;
				int item2 = item5.B;
				int item3 = item5.C;
				IVertexBuilder vertex = xvertices.GetVertex(vtype, item);
				IVertexBuilder vertex2 = xvertices.GetVertex(vtype, item2);
				IVertexBuilder vertex3 = xvertices.GetVertex(vtype, item3);
				yield return (A: vertex, B: vertex2, C: vertex3, Material: prim.Material);
			}
		}
	}

	public static IEnumerable<EvaluatedTriangle<TvG, TvM, TvS>> EvaluateTriangles<TvG, TvM, TvS>(this Mesh mesh, IGeometryTransform xform = null) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
	{
		return EvaluatedTriangle<TvG, TvM, TvS>.GetTrianglesFromMesh(mesh, xform);
	}

	public static VertexBufferColumns GetVertexColumns(this MeshPrimitive primitive)
	{
		SharpGLTF.Guard.NotNull(primitive, "primitive");
		VertexBufferColumns vertexBufferColumns = new VertexBufferColumns();
		_Initialize(primitive.VertexAccessors, vertexBufferColumns);
		for (int i = 0; i < primitive.MorphTargetsCount; i++)
		{
			IReadOnlyDictionary<string, Accessor> morphTargetAccessors = primitive.GetMorphTargetAccessors(i);
			_Initialize(morphTargetAccessors, vertexBufferColumns.AddMorphTarget());
		}
		return vertexBufferColumns;
	}

	private static void _Initialize(IReadOnlyDictionary<string, Accessor> vertexAccessors, VertexBufferColumns dstColumns)
	{
		if (vertexAccessors.ContainsKey("POSITION"))
		{
			dstColumns.Positions = vertexAccessors["POSITION"].AsVector3Array();
		}
		if (vertexAccessors.ContainsKey("NORMAL"))
		{
			dstColumns.Normals = vertexAccessors["NORMAL"].AsVector3Array();
		}
		if (vertexAccessors.ContainsKey("TANGENT"))
		{
			dstColumns.Tangents = vertexAccessors["TANGENT"].AsColorArray(0f);
		}
		if (vertexAccessors.ContainsKey("COLOR_0"))
		{
			dstColumns.Colors0 = vertexAccessors["COLOR_0"].AsColorArray();
		}
		if (vertexAccessors.ContainsKey("COLOR_1"))
		{
			dstColumns.Colors1 = vertexAccessors["COLOR_1"].AsColorArray();
		}
		if (vertexAccessors.ContainsKey("TEXCOORD_0"))
		{
			dstColumns.TexCoords0 = vertexAccessors["TEXCOORD_0"].AsVector2Array();
		}
		if (vertexAccessors.ContainsKey("TEXCOORD_1"))
		{
			dstColumns.TexCoords1 = vertexAccessors["TEXCOORD_1"].AsVector2Array();
		}
		if (vertexAccessors.ContainsKey("TEXCOORD_2"))
		{
			dstColumns.TexCoords2 = vertexAccessors["TEXCOORD_2"].AsVector2Array();
		}
		if (vertexAccessors.ContainsKey("TEXCOORD_3"))
		{
			dstColumns.TexCoords3 = vertexAccessors["TEXCOORD_3"].AsVector2Array();
		}
		if (vertexAccessors.ContainsKey("JOINTS_0"))
		{
			dstColumns.Joints0 = vertexAccessors["JOINTS_0"].AsVector4Array();
		}
		if (vertexAccessors.ContainsKey("JOINTS_1"))
		{
			dstColumns.Joints1 = vertexAccessors["JOINTS_1"].AsVector4Array();
		}
		if (vertexAccessors.ContainsKey("WEIGHTS_0"))
		{
			dstColumns.Weights0 = vertexAccessors["WEIGHTS_0"].AsVector4Array();
		}
		if (vertexAccessors.ContainsKey("WEIGHTS_1"))
		{
			dstColumns.Weights1 = vertexAccessors["WEIGHTS_1"].AsVector4Array();
		}
	}

	public static void AddMesh<TMaterial, TvG, TvM, TvS>(this MeshBuilder<TMaterial, TvG, TvM, TvS> meshBuilder, Mesh srcMesh, Converter<Material, TMaterial> materialFunc) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
	{
		SharpGLTF.Guard.NotNull(meshBuilder, "meshBuilder");
		SharpGLTF.Guard.NotNull(materialFunc, "materialFunc");
		if (srcMesh == null)
		{
			return;
		}
		Dictionary<Material, TMaterial> dictionary = srcMesh.Primitives.Select((MeshPrimitive prim) => prim.Material).Distinct().ToDictionary((Material mat) => mat, (Material mat) => materialFunc(mat));
		Material material = null;
		PrimitiveBuilder<TMaterial, TvG, TvM, TvS> primitiveBuilder = null;
		foreach (EvaluatedTriangle<TvG, TvM, TvS> item in srcMesh.EvaluateTriangles<TvG, TvM, TvS>())
		{
			if (material != item.Material)
			{
				material = item.Material;
				primitiveBuilder = meshBuilder.UsePrimitive(dictionary[material]);
			}
			primitiveBuilder.AddTriangle(item.A, item.B, item.C);
		}
	}

	public static MeshBuilder<TMaterial, TvG, TvM, VertexEmpty> ToStaticMeshBuilder<TMaterial, TvG, TvM>(this Scene srcScene, Converter<Material, TMaterial> materialFunc, RuntimeOptions options, Animation animation, float time) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial
	{
		MeshBuilder<TMaterial, TvG, TvM, VertexEmpty> meshBuilder = new MeshBuilder<TMaterial, TvG, TvM, VertexEmpty>();
		if (srcScene == null)
		{
			return meshBuilder;
		}
		if (animation != null)
		{
			SharpGLTF.Guard.MustShareLogicalParent(srcScene, animation, "animation");
		}
		SharpGLTF.Guard.NotNull(materialFunc, "materialFunc");
		foreach (EvaluatedTriangle<VertexPositionNormal, VertexColor1Texture1, VertexEmpty> item in srcScene.EvaluateTriangles<VertexPositionNormal, VertexColor1Texture1>(options, animation, time))
		{
			TMaterial material = materialFunc(item.Material);
			meshBuilder.UsePrimitive(material).AddTriangle(item.A, item.B, item.C);
		}
		return meshBuilder;
	}

	public static MeshBuilder<MaterialBuilder, TvG, TvM, VertexEmpty> ToStaticMeshBuilder<TvG, TvM>(this Scene srcScene, RuntimeOptions options, Animation animation, float time) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial
	{
		Dictionary<Material, MaterialBuilder> materials = new Dictionary<Material, MaterialBuilder>();
		return srcScene.ToStaticMeshBuilder<MaterialBuilder, TvG, TvM>(convertMaterial, options, animation, time);
		MaterialBuilder convertMaterial(Material srcMaterial)
		{
			if (materials.TryGetValue(srcMaterial, out var dstMaterial))
			{
				return dstMaterial;
			}
			dstMaterial = new MaterialBuilder();
			srcMaterial.CopyTo(dstMaterial);
			MaterialBuilder materialBuilder = materials.Values.FirstOrDefault((MaterialBuilder item) => MaterialBuilder.AreEqualByContent(dstMaterial, item));
			if (materialBuilder != null)
			{
				dstMaterial = materialBuilder;
			}
			return materials[srcMaterial] = dstMaterial;
		}
	}

	public static IMeshBuilder<MaterialBuilder> ToMeshBuilder(this Mesh srcMesh)
	{
		if (srcMesh == null)
		{
			return null;
		}
		string[] vertexAttributes = srcMesh.Primitives.SelectMany((MeshPrimitive item) => item.VertexAccessors.Keys).Distinct().ToArray();
		IMeshBuilder<MaterialBuilder> dstMesh = MeshBuilderToolkit.CreateMeshBuilderFromVertexAttributes<MaterialBuilder>(vertexAttributes);
		dstMesh.Name = srcMesh.Name;
		dstMesh.Extras = srcMesh.Extras?.DeepClone();
		MaterialBuilder defMat = null;
		Dictionary<Material, MaterialBuilder> dstMaterials = new Dictionary<Material, MaterialBuilder>();
		foreach (MeshPrimitive primitive in srcMesh.Primitives)
		{
			int vcount = 0;
			if (primitive.GetPointIndices().Any())
			{
				vcount = 1;
			}
			if (primitive.GetLineIndices().Any())
			{
				vcount = 2;
			}
			if (primitive.GetTriangleIndices().Any())
			{
				vcount = 3;
			}
			IPrimitiveBuilder dstPrim = GetPrimitive(primitive.Material, vcount);
			dstPrim.AddPrimitiveGeometry(primitive);
		}
		return dstMesh;
		IPrimitiveBuilder GetPrimitive(Material srcMaterial, int primitiveVertexCount)
		{
			IPrimitiveBuilder primitiveBuilder = null;
			if (srcMaterial == null)
			{
				if (defMat == null)
				{
					defMat = MaterialBuilder.CreateDefault();
				}
				return dstMesh.UsePrimitive(defMat, primitiveVertexCount);
			}
			if (!dstMaterials.TryGetValue(srcMaterial, out var value))
			{
				value = new MaterialBuilder();
				srcMaterial.CopyTo(value);
				dstMaterials[srcMaterial] = value;
			}
			return dstMesh.UsePrimitive(value, primitiveVertexCount);
		}
	}

	public static MeshBuilder<MaterialBuilder, TvG, TvM, TvS> ToMeshBuilder<TvG, TvM, TvS>(this IEnumerable<EvaluatedTriangle<TvG, TvM, TvS>> triangles) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
	{
		return triangles.Select((EvaluatedTriangle<TvG, TvM, TvS> item) => (A: item.A, B: item.B, C: item.C, Material: item.Material)).ToMeshBuilder((Material m) => m.ToMaterialBuilder());
	}

	public static MeshBuilder<MaterialBuilder, TvG, TvM, TvS> ToMeshBuilder<TMaterial, TvG, TvM, TvS>(this IEnumerable<(VertexBuilder<TvG, TvM, TvS> A, VertexBuilder<TvG, TvM, TvS> B, VertexBuilder<TvG, TvM, TvS> C, TMaterial Material)> triangles, Converter<TMaterial, MaterialBuilder> materialFunc) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
	{
		SharpGLTF.Guard.NotNull(triangles, "triangles");
		SharpGLTF.Guard.NotNull(materialFunc, "materialFunc");
		Dictionary<TMaterial, MaterialBuilder> mats = new Dictionary<TMaterial, MaterialBuilder>();
		MeshBuilder<MaterialBuilder, TvG, TvM, TvS> meshBuilder = new MeshBuilder<MaterialBuilder, TvG, TvM, TvS>();
		foreach (var triangle in triangles)
		{
			PrimitiveBuilder<MaterialBuilder, TvG, TvM, TvS> primitiveBuilder = meshBuilder.UsePrimitive(useMaterial(triangle.Material));
			primitiveBuilder.AddTriangle(triangle.A, triangle.B, triangle.C);
		}
		return meshBuilder;
		MaterialBuilder useMaterial(TMaterial srcMat)
		{
			if (mats.TryGetValue(srcMat, out var value))
			{
				return value;
			}
			return mats[srcMat] = materialFunc(srcMat);
		}
	}

	private static void AddPrimitiveGeometry(this IPrimitiveBuilder dstPrim, MeshPrimitive srcPrim)
	{
		SharpGLTF.Guard.NotNull(dstPrim, "dstPrim");
		VertexBufferColumns vertexColumns = srcPrim.GetVertexColumns();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int pointIndex in srcPrim.GetPointIndices())
		{
			IVertexBuilder vertex = vertexColumns.GetVertex(dstPrim.VertexFactory, pointIndex);
			int value = dstPrim.AddPoint(vertex);
			dictionary[pointIndex] = value;
		}
		foreach (var lineIndex in srcPrim.GetLineIndices())
		{
			int item = lineIndex.A;
			int item2 = lineIndex.B;
			IVertexBuilder vertex2 = vertexColumns.GetVertex(dstPrim.VertexFactory, item);
			IVertexBuilder vertex3 = vertexColumns.GetVertex(dstPrim.VertexFactory, item2);
			(int A, int B) tuple = dstPrim.AddLine(vertex2, vertex3);
			int item3 = tuple.A;
			int item4 = tuple.B;
			dictionary[item] = item3;
			dictionary[item2] = item4;
		}
		foreach (var triangleIndex in srcPrim.GetTriangleIndices())
		{
			int item5 = triangleIndex.A;
			int item6 = triangleIndex.B;
			int item7 = triangleIndex.C;
			IVertexBuilder vertex4 = vertexColumns.GetVertex(dstPrim.VertexFactory, item5);
			IVertexBuilder vertex5 = vertexColumns.GetVertex(dstPrim.VertexFactory, item6);
			IVertexBuilder vertex6 = vertexColumns.GetVertex(dstPrim.VertexFactory, item7);
			(int A, int B, int C) tuple2 = dstPrim.AddTriangle(vertex4, vertex5, vertex6);
			int item8 = tuple2.A;
			int item9 = tuple2.B;
			int item10 = tuple2.C;
			dictionary[item5] = item8;
			dictionary[item6] = item9;
			dictionary[item7] = item10;
		}
		for (int i = 0; i < vertexColumns.MorphTargets.Count; i++)
		{
			VertexBufferColumns vertexBufferColumns = vertexColumns.MorphTargets[i];
			foreach (KeyValuePair<int, int> item11 in dictionary)
			{
				if (item11.Value >= 0)
				{
					IVertexBuilder vertex7 = vertexBufferColumns.GetVertex(dstPrim.VertexFactory, item11.Key);
					dstPrim.SetVertexDelta(i, item11.Value, new VertexGeometryDelta(vertex7.GetGeometry()), new VertexMaterialDelta(vertex7.GetMaterial()));
				}
			}
		}
	}

	public static void SaveAsWavefront(this ModelRoot model, string filePath)
	{
		SharpGLTF.Guard.NotNull(model, "model");
		WavefrontWriter wavefrontWriter = new WavefrontWriter();
		wavefrontWriter.AddModel(model);
		wavefrontWriter.WriteFiles(filePath);
	}

	public static void SaveAsWavefront(this ModelRoot model, string filePath, Animation animation, float time)
	{
		SharpGLTF.Guard.NotNull(model, "model");
		WavefrontWriter wavefrontWriter = new WavefrontWriter();
		wavefrontWriter.AddModel(model, animation, time);
		wavefrontWriter.WriteFiles(filePath);
	}

	public static Node WithLocalTransform(this Node node, AffineTransform xform)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		node.LocalTransform = xform;
		return node;
	}

	public static Node WithLocalTranslation(this Node node, Vector3 translation)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(node, "node");
		node.LocalTransform = node.LocalTransform.WithTranslation(translation);
		return node;
	}

	public static Node WithLocalRotation(this Node node, Quaternion rotation)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(node, "node");
		node.LocalTransform = node.LocalTransform.WithRotation(rotation);
		return node;
	}

	public static Node WithLocalScale(this Node node, Vector3 scale)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(node, "node");
		node.LocalTransform = node.LocalTransform.WithScale(scale);
		return node;
	}

	public static Node WithMesh(this Node node, Mesh mesh)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		node.Mesh = mesh;
		return node;
	}

	public static Node WithSkin(this Node node, Skin skin)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		node.Skin = skin;
		return node;
	}

	public static Node WithSkinBinding(this Node node, Matrix4x4 meshPoseTransform, params Node[] joints)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNull(joints, "joints");
		foreach (Node b in joints)
		{
			SharpGLTF.Guard.MustShareLogicalParent(node, b, "joints");
		}
		Skin skin = node.LogicalParent.CreateSkin();
		skin.BindJoints(meshPoseTransform, joints);
		node.Skin = skin;
		return node;
	}

	public static Node WithSkinBinding(this Node node, params (Node Joint, Matrix4x4 InverseBindMatrix)[] joints)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNull(joints, "joints");
		Matrix4x4 val2 = default(Matrix4x4);
		for (int i = 0; i < joints.Length; i++)
		{
			var (b, val) = joints[i];
			SharpGLTF.Guard.MustShareLogicalParent(node, b, "joints");
			SharpGLTF.Guard.IsTrue(Matrix4x4.Invert(val, ref val2), "joints", "Invalid Matrix");
		}
		Skin skin = node.LogicalParent.CreateSkin();
		skin.BindJoints((IReadOnlyList<(Node Joint, Matrix4x4 InverseBindMatrix)>)joints);
		node.Skin = skin;
		return node;
	}

	public static Node WithSkinnedMesh(this Node node, Mesh mesh, Matrix4x4 meshPoseTransform, params Node[] joints)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		SharpGLTF.Guard.NotNull(joints, "joints");
		SharpGLTF.Guard.MustShareLogicalParent(node, mesh, "mesh");
		foreach (Node b in joints)
		{
			SharpGLTF.Guard.MustShareLogicalParent(node, b, "joints");
		}
		return node.WithMesh(mesh).WithSkinBinding(meshPoseTransform, joints);
	}

	public static Node WithSkinnedMesh(this Node node, Mesh mesh, params (Node Joint, Matrix4x4 InverseBindMatrix)[] joints)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNull(mesh, "mesh");
		SharpGLTF.Guard.NotNull(joints, "joints");
		SharpGLTF.Guard.MustShareLogicalParent(node, mesh, "mesh");
		Matrix4x4 val2 = default(Matrix4x4);
		for (int i = 0; i < joints.Length; i++)
		{
			var (b, val) = joints[i];
			SharpGLTF.Guard.MustShareLogicalParent(node, b, "joints");
			SharpGLTF.Guard.IsTrue(Matrix4x4.Invert(val, ref val2), "joints", "Invalid Matrix");
		}
		return node.WithMesh(mesh).WithSkinBinding(joints);
	}

	public static Node WithPerspectiveCamera(this Node node, float? aspectRatio, float fovy, float znear, float zfar = float.PositiveInfinity)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		CameraPerspective.VerifyParameters(aspectRatio, fovy, znear, zfar);
		Camera camera = node.LogicalParent.CreateCamera();
		camera.SetPerspectiveMode(aspectRatio, fovy, znear, zfar);
		node.Camera = camera;
		return node;
	}

	public static Node WithOrthographicCamera(this Node node, float xmag, float ymag, float znear, float zfar)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		CameraOrthographic.VerifyParameters(xmag, ymag, znear, zfar);
		Camera camera = node.LogicalParent.CreateCamera();
		camera.SetOrthographicMode(xmag, ymag, znear, zfar);
		node.Camera = camera;
		return node;
	}

	public static Node FindNode(this Scene scene, Predicate<Node> predicate)
	{
		SharpGLTF.Guard.NotNull(scene, "scene");
		SharpGLTF.Guard.NotNull(predicate, "predicate");
		return scene.VisualChildren.FirstOrDefault((Node n) => predicate(n));
	}

	public static Node FindNode(this Node node, Predicate<Node> predicate)
	{
		SharpGLTF.Guard.NotNull(node, "node");
		SharpGLTF.Guard.NotNull(predicate, "predicate");
		if (predicate(node))
		{
			return node;
		}
		foreach (Node visualChild in node.VisualChildren)
		{
			Node node2 = visualChild.FindNode(predicate);
			if (node2 != null)
			{
				return node2;
			}
		}
		return null;
	}

	public static IEnumerable<(IVertexBuilder A, IVertexBuilder B, IVertexBuilder C, Material Material)> EvaluateTriangles(this Scene scene, RuntimeOptions options = null, Animation animation = null, float time = 0f)
	{
		if (scene == null)
		{
			return Enumerable.Empty<(IVertexBuilder, IVertexBuilder, IVertexBuilder, Material)>();
		}
		SceneInstance sceneInstance = SceneTemplate.Create(scene, options).CreateInstance();
		if (animation == null)
		{
			sceneInstance.Armature.SetPoseTransforms();
		}
		else
		{
			sceneInstance.Armature.SetAnimationFrame(animation.LogicalIndex, time);
		}
		IReadOnlyList<Mesh> meshes = scene.LogicalParent.LogicalMeshes;
		return sceneInstance.Where((DrawableInstance item) => item.Transform.Visible).SelectMany((DrawableInstance item) => meshes[item.Template.LogicalMeshIndex].EvaluateTriangles(item.Transform));
	}

	public static IEnumerable<EvaluatedTriangle<TvG, TvM, VertexEmpty>> EvaluateTriangles<TvG, TvM>(this Scene scene, RuntimeOptions options = null, Animation animation = null, float time = 0f) where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial
	{
		if (scene == null)
		{
			return Enumerable.Empty<EvaluatedTriangle<TvG, TvM, VertexEmpty>>();
		}
		SceneInstance sceneInstance = SceneTemplate.Create(scene, options).CreateInstance();
		if (animation == null)
		{
			sceneInstance.Armature.SetPoseTransforms();
		}
		else
		{
			sceneInstance.Armature.SetAnimationFrame(animation.LogicalIndex, time);
		}
		IReadOnlyList<Mesh> meshes = scene.LogicalParent.LogicalMeshes;
		return sceneInstance.Where((DrawableInstance item) => item.Transform.Visible).SelectMany((DrawableInstance item) => meshes[item.Template.LogicalMeshIndex].EvaluateTriangles<TvG, TvM, VertexEmpty>(item.Transform));
	}

	public static SceneBuilder ToSceneBuilder(this Scene srcScene)
	{
		return SceneBuilder.CreateFrom(srcScene);
	}
}
