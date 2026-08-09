using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SharpGLTF.Materials;

[DebuggerDisplay("{_DebuggerDisplay(),nq}")]
public class MaterialBuilder : BaseBuilder, ICloneable
{
	private sealed class _ContentComparer : IEqualityComparer<MaterialBuilder>
	{
		public static readonly _ContentComparer Default = new _ContentComparer();

		public bool Equals(MaterialBuilder x, MaterialBuilder y)
		{
			return AreEqualByContent(x, y);
		}

		public int GetHashCode(MaterialBuilder obj)
		{
			return GetContentHashCode(obj);
		}
	}

	private sealed class _ReferenceComparer : IEqualityComparer<MaterialBuilder>
	{
		public static readonly _ReferenceComparer Default = new _ReferenceComparer();

		public bool Equals(MaterialBuilder x, MaterialBuilder y)
		{
			return x == y;
		}

		public int GetHashCode(MaterialBuilder obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}
	}

	public const string SHADERUNLIT = "Unlit";

	public const string SHADERPBRMETALLICROUGHNESS = "PBRMetallicRoughness";

	public const string SHADERPBRSPECULARGLOSSINESS = "PBRSpecularGlossiness";

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly List<ChannelBuilder> _Channels = new List<ChannelBuilder>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialBuilder _CompatibilityFallbackMaterial;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _ShaderStyle = "PBRMetallicRoughness";

	private static readonly KnownChannel[] _UnlitChannels = new KnownChannel[1] { KnownChannel.BaseColor };

	internal static readonly KnownChannel[] _MetRouChannels = new KnownChannel[20]
	{
		KnownChannel.Normal,
		KnownChannel.Occlusion,
		KnownChannel.Emissive,
		KnownChannel.BaseColor,
		KnownChannel.MetallicRoughness,
		KnownChannel.ClearCoat,
		KnownChannel.ClearCoatNormal,
		KnownChannel.ClearCoatRoughness,
		KnownChannel.Transmission,
		KnownChannel.SheenColor,
		KnownChannel.SheenRoughness,
		KnownChannel.SpecularColor,
		KnownChannel.SpecularFactor,
		KnownChannel.VolumeThickness,
		KnownChannel.VolumeAttenuation,
		KnownChannel.Iridescence,
		KnownChannel.IridescenceThickness,
		KnownChannel.Anisotropy,
		KnownChannel.DiffuseTransmissionColor,
		KnownChannel.DiffuseTransmissionFactor
	};

	[Obsolete("Deprecated by Khronos")]
	private static readonly KnownChannel[] _SpeGloChannels = new KnownChannel[5]
	{
		KnownChannel.Normal,
		KnownChannel.Occlusion,
		KnownChannel.Emissive,
		KnownChannel.Diffuse,
		KnownChannel.SpecularGlossiness
	};

	public AlphaMode AlphaMode { get; set; }

	public float AlphaCutoff { get; set; } = 0.5f;

	public bool DoubleSided { get; set; }

	public string ShaderStyle
	{
		get
		{
			return _ShaderStyle;
		}
		set
		{
			_SetShader(value);
		}
	}

	public float IndexOfRefraction { get; set; } = 1.5f;

	public float Dispersion { get; set; }

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public IReadOnlyCollection<ChannelBuilder> Channels => _Channels;

	public MaterialBuilder CompatibilityFallback
	{
		get
		{
			return _CompatibilityFallbackMaterial;
		}
		set
		{
			SharpGLTF.Guard.IsFalse(_CompatibilityFallbackMaterial == this, "value", "Cannot use self as fallback material");
			_CompatibilityFallbackMaterial = value;
		}
	}

	public static IEqualityComparer<MaterialBuilder> ContentComparer => _ContentComparer.Default;

	public static IEqualityComparer<MaterialBuilder> ReferenceComparer => _ReferenceComparer.Default;

	internal string _DebuggerDisplay()
	{
		string text = "MatBuilder ";
		if (!string.IsNullOrWhiteSpace(base.Name))
		{
			text = text + " \"" + base.Name + "\"";
		}
		text = text + " " + _ShaderStyle;
		if (AlphaMode == AlphaMode.BLEND)
		{
			text += " AlphaBlend";
		}
		if (AlphaMode == AlphaMode.MASK)
		{
			text += $" AlphaMask({AlphaCutoff})";
		}
		if (DoubleSided)
		{
			text += " DoubleSided";
		}
		return text;
	}

	public static MaterialBuilder CreateDefault()
	{
		return new MaterialBuilder("Default");
	}

	public MaterialBuilder(string name = null)
		: base(name)
	{
	}

	object ICloneable.Clone()
	{
		return new MaterialBuilder(this);
	}

	public MaterialBuilder Clone()
	{
		return new MaterialBuilder(this);
	}

	public MaterialBuilder(MaterialBuilder other)
		: base(other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		AlphaMode = other.AlphaMode;
		AlphaCutoff = other.AlphaCutoff;
		DoubleSided = other.DoubleSided;
		ShaderStyle = other.ShaderStyle;
		Dispersion = other.Dispersion;
		IndexOfRefraction = other.IndexOfRefraction;
		_CompatibilityFallbackMaterial = ((other._CompatibilityFallbackMaterial == null) ? null : new MaterialBuilder(other._CompatibilityFallbackMaterial));
		foreach (ChannelBuilder channel in other._Channels)
		{
			ChannelBuilder other2 = UseChannel(channel.Key);
			channel.CopyTo(other2);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return this == obj;
	}

	public static bool AreEqualByContent(MaterialBuilder x, MaterialBuilder y)
	{
		if ((x: x, y: y).AreSameReference(out var result))
		{
			return result;
		}
		if (!BaseBuilder.AreEqualByContent(x, y))
		{
			return false;
		}
		if (x.AlphaMode != y.AlphaMode)
		{
			return false;
		}
		if (x.AlphaMode == AlphaMode.MASK && x.AlphaCutoff != y.AlphaCutoff)
		{
			return false;
		}
		if (x.DoubleSided != y.DoubleSided)
		{
			return false;
		}
		if (x.Dispersion != y.Dispersion)
		{
			return false;
		}
		if (x.IndexOfRefraction != y.IndexOfRefraction)
		{
			return false;
		}
		if (x._ShaderStyle != y._ShaderStyle)
		{
			return false;
		}
		if (!AreEqualByContent(x._CompatibilityFallbackMaterial, y._CompatibilityFallbackMaterial))
		{
			return false;
		}
		IEnumerable<KnownChannel> enumerable = (from item in x._Channels.Concat(y._Channels)
			select item.Key).Distinct();
		foreach (KnownChannel item in enumerable)
		{
			ChannelBuilder channel = x.GetChannel(item);
			ChannelBuilder channel2 = y.GetChannel(item);
			if (!ChannelBuilder.AreEqualByContent(channel, channel2))
			{
				return false;
			}
		}
		return true;
	}

	public static int GetContentHashCode(MaterialBuilder x)
	{
		if (x == null)
		{
			return 0;
		}
		int contentHashCode = BaseBuilder.GetContentHashCode(x);
		contentHashCode ^= x.AlphaMode.GetHashCode();
		contentHashCode ^= x.AlphaCutoff.GetHashCode();
		contentHashCode ^= x.DoubleSided.GetHashCode();
		contentHashCode ^= x.Dispersion.GetHashCode();
		contentHashCode ^= x.IndexOfRefraction.GetHashCode();
		contentHashCode ^= SharpGLTF._Extensions.GetHashCode(x.ShaderStyle, StringComparison.InvariantCulture);
		contentHashCode ^= x._Channels.Select((ChannelBuilder item) => ChannelBuilder.GetContentHashCode(item)).GetContentHashCode();
		return contentHashCode ^ GetContentHashCode(x._CompatibilityFallbackMaterial);
	}

	private void _SetShader(string shader)
	{
		SharpGLTF.Guard.NotNullOrEmpty(shader, "shader");
		SharpGLTF.Guard.IsTrue(shader == "Unlit" || shader == "PBRMetallicRoughness" || shader == "PBRSpecularGlossiness", "shader");
		_ShaderStyle = shader;
		IReadOnlyList<KnownChannel> source = _GetValidChannels();
		for (int num = _Channels.Count - 1; num >= 0; num--)
		{
			ChannelBuilder channelBuilder = _Channels[num];
			if (!source.Contains(channelBuilder.Key))
			{
				_Channels.RemoveAt(num);
			}
		}
	}

	[Obsolete("Use GetChannel with KnownChannel whenever possible")]
	public ChannelBuilder GetChannel(string channelKey)
	{
		SharpGLTF.Guard.NotNullOrEmpty(channelKey, "channelKey");
		KnownChannel channelKey2 = (KnownChannel)Enum.Parse(typeof(KnownChannel), channelKey, ignoreCase: true);
		return GetChannel(channelKey2);
	}

	[Obsolete("Use UseChannel with KnownChannel whenever possible")]
	public ChannelBuilder UseChannel(string channelKey)
	{
		SharpGLTF.Guard.NotNullOrEmpty(channelKey, "channelKey");
		KnownChannel channelKey2 = (KnownChannel)Enum.Parse(typeof(KnownChannel), channelKey, ignoreCase: true);
		return UseChannel(channelKey2);
	}

	public ChannelBuilder GetChannel(KnownChannel channelKey)
	{
		return _Channels.FirstOrDefault((ChannelBuilder item) => item.Key == channelKey);
	}

	public ChannelBuilder UseChannel(KnownChannel channelKey)
	{
		SharpGLTF.Guard.IsTrue(_GetValidChannels().Contains(channelKey), "channelKey");
		ChannelBuilder channel = GetChannel(channelKey);
		if (channel != null)
		{
			return channel;
		}
		channel = new ChannelBuilder(this, channelKey);
		_Channels.Add(channel);
		return channel;
	}

	public void RemoveChannel(KnownChannel key)
	{
		int num = _Channels.IndexOf((ChannelBuilder item) => item.Key == key);
		if (num >= 0)
		{
			_Channels.RemoveAt(num);
		}
	}

	internal void ValidateForSchema2()
	{
		bool target = GetChannel(KnownChannel.ClearCoat) != null || GetChannel(KnownChannel.ClearCoatNormal) != null || GetChannel(KnownChannel.ClearCoatRoughness) != null;
		bool target2 = GetChannel(KnownChannel.Transmission) != null;
		if (ShaderStyle == "PBRSpecularGlossiness")
		{
			SharpGLTF.Guard.IsFalse(target, KnownChannel.ClearCoat.ToString(), "Clear Coat not supported for Specular Glossiness materials.");
			SharpGLTF.Guard.IsFalse(target2, KnownChannel.Transmission.ToString(), "Transmission not supported for Specular Glossiness materials.");
			if (CompatibilityFallback != null)
			{
				SharpGLTF.Guard.MustBeNull(CompatibilityFallback.CompatibilityFallback, "CompatibilityFallback");
				SharpGLTF.Guard.MustBeEqualTo(base.Name, CompatibilityFallback.Name, "Name");
				SharpGLTF.Guard.IsTrue(CompatibilityFallback.ShaderStyle == "PBRMetallicRoughness", "ShaderStyle");
				SharpGLTF.Guard.IsTrue(AlphaMode == CompatibilityFallback.AlphaMode, "AlphaMode");
				SharpGLTF.Guard.MustBeEqualTo(AlphaCutoff, CompatibilityFallback.AlphaCutoff, "AlphaCutoff");
				SharpGLTF.Guard.MustBeEqualTo(DoubleSided, CompatibilityFallback.DoubleSided, "DoubleSided");
				SharpGLTF.Guard.MustBeEqualTo(Dispersion, CompatibilityFallback.Dispersion, "Dispersion");
				SharpGLTF.Guard.MustBeEqualTo(IndexOfRefraction, CompatibilityFallback.IndexOfRefraction, "IndexOfRefraction");
				KnownChannel[] array = new KnownChannel[3]
				{
					KnownChannel.Normal,
					KnownChannel.Occlusion,
					KnownChannel.Emissive
				};
				for (int i = 0; i < array.Length; i++)
				{
					KnownChannel channelKey = array[i];
					ChannelBuilder channel = GetChannel(channelKey);
					ChannelBuilder channel2 = CompatibilityFallback.GetChannel(channelKey);
					SharpGLTF.Guard.IsTrue(ChannelBuilder.AreEqualByContent(channel, channel2), channelKey.ToString(), "Primary and fallback materials must have the same channel properties");
				}
			}
		}
		else
		{
			SharpGLTF.Guard.MustBeNull(CompatibilityFallback, "CompatibilityFallback");
		}
	}

	public MaterialBuilder WithShader(string shader)
	{
		_SetShader(shader);
		return this;
	}

	public MaterialBuilder WithUnlitShader()
	{
		_SetShader("Unlit");
		return this;
	}

	public MaterialBuilder WithMetallicRoughnessShader()
	{
		_SetShader("PBRMetallicRoughness");
		return this;
	}

	[Obsolete("SpecularGlossiness has been deprecated by Khronos")]
	public MaterialBuilder WithSpecularGlossinessShader()
	{
		_SetShader("PBRSpecularGlossiness");
		return this;
	}

	public MaterialBuilder WithAlpha(AlphaMode alphaMode = AlphaMode.OPAQUE, float alphaCutoff = 0.5f)
	{
		AlphaMode = alphaMode;
		AlphaCutoff = alphaCutoff;
		return this;
	}

	public MaterialBuilder WithDoubleSide(bool enabled)
	{
		DoubleSided = enabled;
		return this;
	}

	[Obsolete("Use WithChannelParam(KnownChannel channelKey, KnownProperty propertyName, Object parameter)")]
	public MaterialBuilder WithChannelParam(KnownChannel channelKey, Vector4 parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		UseChannel(channelKey).Parameter = parameter;
		return this;
	}

	[Obsolete("Use WithChannelParam(KnownChannel channelKey, KnownProperty propertyName, Object parameter)")]
	public MaterialBuilder WithChannelParam(string channelKey, Vector4 parameter)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		UseChannel(channelKey).Parameter = parameter;
		return this;
	}

	[Obsolete("Use WithChannelImage(KnownChannel channelKey, ImageBuilder primaryImage)")]
	public MaterialBuilder WithChannelImage(string channelKey, ImageBuilder primaryImage)
	{
		UseChannel(channelKey).UseTexture().WithPrimaryImage(primaryImage);
		return this;
	}

	public MaterialBuilder WithChannelParam(KnownChannel channelKey, KnownProperty propertyName, object parameter)
	{
		UseChannel(channelKey).Parameters[propertyName] = MaterialValue.CreateFrom(parameter);
		return this;
	}

	public MaterialBuilder WithChannelImage(KnownChannel channelKey, ImageBuilder primaryImage)
	{
		if (ImageBuilder.IsEmpty(primaryImage))
		{
			GetChannel(channelKey)?.RemoveTexture();
			return this;
		}
		UseChannel(channelKey).UseTexture().WithPrimaryImage(primaryImage);
		return this;
	}

	public MaterialBuilder WithFallback(MaterialBuilder fallback)
	{
		CompatibilityFallback = fallback;
		return this;
	}

	public MaterialBuilder WithMetallicRoughnessFallback(ImageBuilder baseColor, Vector4? rgba, ImageBuilder metallicRoughness, float? metallic, float? roughness)
	{
		MaterialBuilder fallback = Clone().WithMetallicRoughnessShader().WithBaseColor(baseColor, rgba).WithMetallicRoughness(metallicRoughness, metallic, roughness);
		return WithFallback(fallback);
	}

	public MaterialBuilder WithNormal(ImageBuilder imageFile, float scale = 1f)
	{
		WithChannelImage(KnownChannel.Normal, imageFile);
		WithChannelParam(KnownChannel.Normal, KnownProperty.NormalScale, scale);
		return this;
	}

	public MaterialBuilder WithOcclusion(ImageBuilder imageFile, float strength = 1f)
	{
		WithChannelImage(KnownChannel.Occlusion, imageFile);
		WithChannelParam(KnownChannel.Occlusion, KnownProperty.OcclusionStrength, strength);
		return this;
	}

	public MaterialBuilder WithEmissive(Vector3 rgb, float strength = 1f)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		WithChannelParam(KnownChannel.Emissive, KnownProperty.EmissiveStrength, strength);
		WithChannelParam(KnownChannel.Emissive, KnownProperty.RGB, rgb);
		return this;
	}

	public MaterialBuilder WithEmissive(ImageBuilder imageFile, Vector3? rgb = null, float strength = 1f)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		WithChannelImage(KnownChannel.Emissive, imageFile);
		if (rgb.HasValue)
		{
			WithEmissive(rgb.Value, strength);
		}
		return this;
	}

	public MaterialBuilder WithBaseColor(Vector4 rgba)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return WithChannelParam(KnownChannel.BaseColor, KnownProperty.RGBA, rgba);
	}

	public MaterialBuilder WithBaseColor(ImageBuilder imageFile, Vector4? rgba = null)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		WithChannelImage(KnownChannel.BaseColor, imageFile);
		if (rgba.HasValue)
		{
			WithBaseColor(rgba.Value);
		}
		return this;
	}

	public MaterialBuilder WithMetallicRoughness(float? metallic = null, float? roughness = null)
	{
		if (!metallic.HasValue && !roughness.HasValue)
		{
			return this;
		}
		ChannelBuilder channelBuilder = UseChannel(KnownChannel.MetallicRoughness);
		if (metallic.HasValue)
		{
			channelBuilder.Parameters[KnownProperty.MetallicFactor] = metallic.Value;
		}
		if (roughness.HasValue)
		{
			channelBuilder.Parameters[KnownProperty.RoughnessFactor] = roughness.Value;
		}
		return this;
	}

	public MaterialBuilder WithMetallicRoughness(ImageBuilder imageFile, float? metallic = null, float? roughness = null)
	{
		WithChannelImage(KnownChannel.MetallicRoughness, imageFile);
		WithMetallicRoughness(metallic, roughness);
		return this;
	}

	public MaterialBuilder WithClearCoatNormal(ImageBuilder imageFile)
	{
		WithChannelImage(KnownChannel.ClearCoatNormal, imageFile);
		return this;
	}

	public MaterialBuilder WithClearCoat(ImageBuilder imageFile, float intensity)
	{
		WithChannelImage(KnownChannel.ClearCoat, imageFile);
		WithChannelParam(KnownChannel.ClearCoat, KnownProperty.ClearCoatFactor, intensity);
		return this;
	}

	public MaterialBuilder WithClearCoatRoughness(ImageBuilder imageFile, float roughness)
	{
		WithChannelImage(KnownChannel.ClearCoatRoughness, imageFile);
		WithChannelParam(KnownChannel.ClearCoatRoughness, KnownProperty.RoughnessFactor, roughness);
		return this;
	}

	public MaterialBuilder WithTransmission(ImageBuilder imageFile, float intensity)
	{
		WithChannelImage(KnownChannel.Transmission, imageFile);
		WithChannelParam(KnownChannel.Transmission, KnownProperty.TransmissionFactor, intensity);
		return this;
	}

	public MaterialBuilder WithDiffuseTransmissionFactor(ImageBuilder imageFile, float factor)
	{
		WithChannelImage(KnownChannel.DiffuseTransmissionFactor, imageFile);
		WithChannelParam(KnownChannel.DiffuseTransmissionFactor, KnownProperty.DiffuseTransmissionFactor, factor);
		return this;
	}

	public MaterialBuilder WithDiffuseTransmissionColor(ImageBuilder imageFile, Vector3? rgb = null)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		WithChannelImage(KnownChannel.DiffuseTransmissionColor, imageFile);
		if (rgb.HasValue)
		{
			WithChannelParam(KnownChannel.DiffuseTransmissionColor, KnownProperty.RGB, rgb.Value);
		}
		return this;
	}

	public MaterialBuilder WithSpecularColor(ImageBuilder imageFile, Vector3? rgb = null)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		WithChannelImage(KnownChannel.SpecularColor, imageFile);
		if (rgb.HasValue)
		{
			WithChannelParam(KnownChannel.SpecularColor, KnownProperty.RGB, rgb.Value);
		}
		return this;
	}

	public MaterialBuilder WithSpecularFactor(ImageBuilder imageFile, float factor)
	{
		WithChannelImage(KnownChannel.SpecularFactor, imageFile);
		WithChannelParam(KnownChannel.SpecularFactor, KnownProperty.SpecularFactor, factor);
		return this;
	}

	public MaterialBuilder WithVolumeThickness(ImageBuilder imageFile, float factor)
	{
		WithChannelImage(KnownChannel.VolumeThickness, imageFile);
		WithChannelParam(KnownChannel.VolumeThickness, KnownProperty.ThicknessFactor, factor);
		return this;
	}

	public MaterialBuilder WithVolumeAttenuation(Vector3 color, float distance)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		WithChannelParam(KnownChannel.VolumeAttenuation, KnownProperty.RGB, color);
		WithChannelParam(KnownChannel.VolumeAttenuation, KnownProperty.AttenuationDistance, distance);
		return this;
	}

	public MaterialBuilder WithIridescence(ImageBuilder imageFile, float factor = 0f, float ior = 1.3f)
	{
		WithChannelImage(KnownChannel.Iridescence, imageFile);
		WithChannelParam(KnownChannel.Iridescence, KnownProperty.IridescenceFactor, factor);
		WithChannelParam(KnownChannel.Iridescence, KnownProperty.IndexOfRefraction, ior);
		return this;
	}

	public MaterialBuilder WithIridescenceThickness(ImageBuilder imageFile, float min = 100f, float max = 400f)
	{
		WithChannelImage(KnownChannel.IridescenceThickness, imageFile);
		WithChannelParam(KnownChannel.IridescenceThickness, KnownProperty.Minimum, min);
		WithChannelParam(KnownChannel.IridescenceThickness, KnownProperty.Maximum, max);
		return this;
	}

	public MaterialBuilder WithAnisotropy(ImageBuilder imageFile, float strength = 0f, float rotation = 0f)
	{
		WithChannelImage(KnownChannel.Anisotropy, imageFile);
		WithChannelParam(KnownChannel.Anisotropy, KnownProperty.AnisotropyStrength, strength);
		WithChannelParam(KnownChannel.Anisotropy, KnownProperty.AnisotropyRotation, rotation);
		return this;
	}

	[Obsolete("This channel is used by KHR_materials_pbrSpecularGlossiness extension, which has been deprecated by Khronos; use WithBaseColor instead.")]
	public MaterialBuilder WithDiffuse(Vector4 rgba)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return WithChannelParam(KnownChannel.Diffuse, KnownProperty.RGBA, rgba);
	}

	[Obsolete("This channel is used by KHR_materials_pbrSpecularGlossiness extension, which has been deprecated by Khronos; use WithBaseColor instead.")]
	public MaterialBuilder WithDiffuse(ImageBuilder imageFile, Vector4? rgba = null)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		WithChannelImage(KnownChannel.Diffuse, imageFile);
		if (rgba.HasValue)
		{
			WithDiffuse(rgba.Value);
		}
		return this;
	}

	[Obsolete("This channel is used by KHR_materials_pbrSpecularGlossiness extension, which has been deprecated by Khronos; use WithSpecularColor instead.")]
	public MaterialBuilder WithSpecularGlossiness(Vector3? specular = null, float? glossiness = null)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (!specular.HasValue && !glossiness.HasValue)
		{
			return this;
		}
		ChannelBuilder channelBuilder = UseChannel(KnownChannel.SpecularGlossiness);
		if (specular.HasValue)
		{
			channelBuilder.Parameters[KnownProperty.SpecularFactor] = specular.Value;
		}
		if (glossiness.HasValue)
		{
			channelBuilder.Parameters[KnownProperty.GlossinessFactor] = glossiness.Value;
		}
		return this;
	}

	[Obsolete("This channel is used by KHR_materials_pbrSpecularGlossiness extension, which has been deprecated by Khronos; use WithSpecularColor instead.")]
	public MaterialBuilder WithSpecularGlossiness(ImageBuilder imageFile, Vector3? specular = null, float? glossiness = null)
	{
		WithChannelImage(KnownChannel.SpecularGlossiness, imageFile);
		WithSpecularGlossiness(specular, glossiness);
		return this;
	}

	private IReadOnlyList<KnownChannel> _GetValidChannels()
	{
		return ShaderStyle switch
		{
			"Unlit" => _UnlitChannels, 
			"PBRMetallicRoughness" => _MetRouChannels, 
			"PBRSpecularGlossiness" => _SpeGloChannels, 
			_ => throw new NotImplementedException(), 
		};
	}
}
