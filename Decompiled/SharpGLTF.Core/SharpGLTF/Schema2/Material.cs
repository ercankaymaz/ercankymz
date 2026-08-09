using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Material[{LogicalIndex}] {Name}")]
public sealed class Material : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "material";

	private const double _alphaCutoffDefault = 0.5;

	private const double _alphaCutoffMinimum = 0.0;

	private double? _alphaCutoff = 0.5;

	private const AlphaMode _alphaModeDefault = AlphaMode.OPAQUE;

	private AlphaMode? _alphaMode = AlphaMode.OPAQUE;

	private static readonly bool _doubleSidedDefault = false;

	private bool? _doubleSided = _doubleSidedDefault;

	private static readonly Vector3 _emissiveFactorDefault = Vector3.Zero;

	private Vector3? _emissiveFactor = _emissiveFactorDefault;

	private TextureInfo _emissiveTexture;

	private MaterialNormalTextureInfo _normalTexture;

	private MaterialOcclusionTextureInfo _occlusionTexture;

	private MaterialPBRMetallicRoughness _pbrMetallicRoughness;

	public AlphaMode Alpha
	{
		get
		{
			return _alphaMode.AsValue(AlphaMode.OPAQUE);
		}
		set
		{
			_alphaMode = value.AsNullable(AlphaMode.OPAQUE);
		}
	}

	public float AlphaCutoff
	{
		get
		{
			return (float)_alphaCutoff.AsValue(0.5);
		}
		set
		{
			_alphaCutoff = _Schema2Extensions.AsNullable(value, 0.5, 0.0, double.MaxValue);
		}
	}

	public bool DoubleSided
	{
		get
		{
			return _doubleSided.AsValue(_doubleSidedDefault);
		}
		set
		{
			_doubleSided = value.AsNullable(_doubleSidedDefault);
		}
	}

	public bool Unlit => GetExtension<MaterialUnlit>() != null;

	public IEnumerable<MaterialChannel> Channels => _GetChannels();

	public float IndexOfRefraction
	{
		get
		{
			return GetExtension<MaterialIOR>()?.IndexOfRefraction ?? MaterialIOR.DefaultIndexOfRefraction;
		}
		set
		{
			if (GetExtension<MaterialUnlit>() == null && GetExtension<MaterialPBRSpecularGlossiness>() == null)
			{
				if (value == MaterialIOR.DefaultIndexOfRefraction)
				{
					RemoveExtensions<MaterialIOR>();
				}
				else
				{
					UseExtension<MaterialIOR>().IndexOfRefraction = value;
				}
			}
		}
	}

	public float Dispersion
	{
		get
		{
			return GetExtension<MaterialDispersion>()?.Dispersion ?? MaterialDispersion.DefaultDispersion;
		}
		set
		{
			if (GetExtension<MaterialUnlit>() == null && GetExtension<MaterialPBRSpecularGlossiness>() == null)
			{
				if (value == MaterialDispersion.DefaultDispersion)
				{
					RemoveExtensions<MaterialDispersion>();
				}
				else
				{
					UseExtension<MaterialDispersion>().Dispersion = value;
				}
			}
		}
	}

	protected override string GetSchemaName()
	{
		return "material";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "alphaCutoff";
		yield return "alphaMode";
		yield return "doubleSided";
		yield return "emissiveFactor";
		yield return "emissiveTexture";
		yield return "normalTexture";
		yield return "occlusionTexture";
		yield return "pbrMetallicRoughness";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "alphaCutoff":
			value = FieldInfo.From("alphaCutoff", this, (Material instance) => instance._alphaCutoff ?? 0.5);
			return true;
		case "alphaMode":
			value = FieldInfo.From("alphaMode", this, (Material instance) => instance._alphaMode.GetValueOrDefault());
			return true;
		case "doubleSided":
			value = FieldInfo.From("doubleSided", this, (Material instance) => instance._doubleSided == true);
			return true;
		case "emissiveFactor":
			value = FieldInfo.From("emissiveFactor", this, (Material instance) => (Vector3)(((_003F?)instance._emissiveFactor) ?? Vector3.Zero));
			return true;
		case "emissiveTexture":
			value = FieldInfo.From("emissiveTexture", this, (Material instance) => instance._emissiveTexture);
			return true;
		case "normalTexture":
			value = FieldInfo.From("normalTexture", this, (Material instance) => instance._normalTexture);
			return true;
		case "occlusionTexture":
			value = FieldInfo.From("occlusionTexture", this, (Material instance) => instance._occlusionTexture);
			return true;
		case "pbrMetallicRoughness":
			value = FieldInfo.From("pbrMetallicRoughness", this, (Material instance) => instance._pbrMetallicRoughness);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "alphaCutoff", _alphaCutoff, 0.5);
		JsonSerializable.SerializePropertyEnumSymbol(writer, "alphaMode", _alphaMode, AlphaMode.OPAQUE);
		JsonSerializable.SerializeProperty(writer, "doubleSided", _doubleSided, _doubleSidedDefault);
		JsonSerializable.SerializeProperty(writer, "emissiveFactor", _emissiveFactor, _emissiveFactorDefault);
		JsonSerializable.SerializePropertyObject(writer, "emissiveTexture", _emissiveTexture);
		JsonSerializable.SerializePropertyObject(writer, "normalTexture", _normalTexture);
		JsonSerializable.SerializePropertyObject(writer, "occlusionTexture", _occlusionTexture);
		JsonSerializable.SerializePropertyObject(writer, "pbrMetallicRoughness", _pbrMetallicRoughness);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "alphaCutoff":
			JsonSerializable.DeserializePropertyValue<Material, double?>(ref reader, this, out _alphaCutoff);
			break;
		case "alphaMode":
			_alphaMode = JsonSerializable.DeserializePropertyValue<AlphaMode>(ref reader);
			break;
		case "doubleSided":
			JsonSerializable.DeserializePropertyValue<Material, bool?>(ref reader, this, out _doubleSided);
			break;
		case "emissiveFactor":
			JsonSerializable.DeserializePropertyValue<Material, Vector3?>(ref reader, this, out _emissiveFactor);
			break;
		case "emissiveTexture":
			JsonSerializable.DeserializePropertyValue<Material, TextureInfo>(ref reader, this, out _emissiveTexture);
			break;
		case "normalTexture":
			JsonSerializable.DeserializePropertyValue<Material, MaterialNormalTextureInfo>(ref reader, this, out _normalTexture);
			break;
		case "occlusionTexture":
			JsonSerializable.DeserializePropertyValue<Material, MaterialOcclusionTextureInfo>(ref reader, this, out _occlusionTexture);
			break;
		case "pbrMetallicRoughness":
			JsonSerializable.DeserializePropertyValue<Material, MaterialPBRMetallicRoughness>(ref reader, this, out _pbrMetallicRoughness);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal Material()
	{
	}//IL_0031: Unknown result type (might be due to invalid IL or missing references)


	[DebuggerStepThrough]
	public MaterialChannel? FindChannel(string channelKey)
	{
		foreach (MaterialChannel channel in Channels)
		{
			if (channel.Key.Equals(channelKey, StringComparison.OrdinalIgnoreCase))
			{
				return channel;
			}
		}
		return null;
	}

	protected override void OnValidateContent(ValidationContext result)
	{
		base.OnValidateContent(result);
		if (GetExtension<MaterialPBRSpecularGlossiness>() != null || GetExtension<MaterialUnlit>() != null)
		{
			result.MustBeNull("ClearCoat", GetExtension<MaterialClearCoat>());
			result.MustBeNull("Transmission", GetExtension<MaterialTransmission>());
			result.MustBeNull("Sheen", GetExtension<MaterialSheen>());
		}
	}

	internal void ClearExtensions()
	{
		RemoveExtensions<MaterialIOR>();
		RemoveExtensions<MaterialUnlit>();
		RemoveExtensions<MaterialSheen>();
		RemoveExtensions<MaterialClearCoat>();
		RemoveExtensions<MaterialSpecular>();
		RemoveExtensions<MaterialTransmission>();
		RemoveExtensions<MaterialDiffuseTransmission>();
		RemoveExtensions<MaterialVolume>();
		RemoveExtensions<MaterialAnisotropy>();
		RemoveExtensions<MaterialIridescence>();
		RemoveExtensions<MaterialPBRSpecularGlossiness>();
	}

	public void InitializeUnlit()
	{
		ExtraProperties.SetProperty(this, ref _pbrMetallicRoughness, new MaterialPBRMetallicRoughness());
		ClearExtensions();
		UseExtension<MaterialUnlit>();
	}

	public void InitializePBRMetallicRoughness(params string[] extensionNames)
	{
		Guard.NotNull(extensionNames, "extensionNames");
		ClearExtensions();
		ExtraProperties.SetProperty(this, ref _pbrMetallicRoughness, new MaterialPBRMetallicRoughness());
		foreach (string text in extensionNames)
		{
			if (text == "Sheen")
			{
				UseExtension<MaterialSheen>();
			}
			if (text == "Volume")
			{
				UseExtension<MaterialVolume>();
			}
			if (text == "Specular")
			{
				UseExtension<MaterialSpecular>();
			}
			if (text == "ClearCoat")
			{
				UseExtension<MaterialClearCoat>();
			}
			if (text == "Anisotropy")
			{
				UseExtension<MaterialAnisotropy>();
			}
			if (text == "Iridescence")
			{
				UseExtension<MaterialIridescence>();
			}
			if (text == "Transmission")
			{
				UseExtension<MaterialTransmission>();
			}
			if (text == "DiffuseTransmission")
			{
				UseExtension<MaterialDiffuseTransmission>();
			}
		}
	}

	public void InitializePBRSpecularGlossiness(bool useFallback = false)
	{
		ClearExtensions();
		if (useFallback)
		{
			MaterialPBRMetallicRoughness value = _pbrMetallicRoughness ?? (_pbrMetallicRoughness = new MaterialPBRMetallicRoughness());
			ExtraProperties.SetProperty(this, ref _pbrMetallicRoughness, value);
		}
		else
		{
			ExtraProperties.SetProperty<Material, MaterialPBRMetallicRoughness, MaterialPBRMetallicRoughness>(this, ref _pbrMetallicRoughness, null);
		}
		UseExtension<MaterialPBRSpecularGlossiness>();
	}

	private IEnumerable<MaterialChannel> _GetChannels()
	{
		IEnumerable<MaterialChannel> enumerable = _pbrMetallicRoughness?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item in enumerable)
			{
				yield return item;
			}
		}
		enumerable = GetExtension<MaterialPBRSpecularGlossiness>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item2 in enumerable)
			{
				yield return item2;
			}
		}
		enumerable = GetExtension<MaterialClearCoat>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item3 in enumerable)
			{
				yield return item3;
			}
		}
		enumerable = GetExtension<MaterialTransmission>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item4 in enumerable)
			{
				yield return item4;
			}
		}
		enumerable = GetExtension<MaterialDiffuseTransmission>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item5 in enumerable)
			{
				yield return item5;
			}
		}
		enumerable = GetExtension<MaterialSheen>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item6 in enumerable)
			{
				yield return item6;
			}
		}
		enumerable = GetExtension<MaterialSpecular>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item7 in enumerable)
			{
				yield return item7;
			}
		}
		enumerable = GetExtension<MaterialVolume>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item8 in enumerable)
			{
				yield return item8;
			}
		}
		enumerable = GetExtension<MaterialIridescence>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item9 in enumerable)
			{
				yield return item9;
			}
		}
		enumerable = GetExtension<MaterialAnisotropy>()?.GetChannels(this);
		if (enumerable != null)
		{
			foreach (MaterialChannel item10 in enumerable)
			{
				yield return item10;
			}
		}
		_MaterialParameter<float> materialParameter = new _MaterialParameter<float>(_MaterialParameterKey.NormalScale, MaterialNormalTextureInfo.ScaleDefault, () => _GetNormalTexture(create: false)?.Scale ?? MaterialNormalTextureInfo.ScaleDefault, delegate(float value)
		{
			_GetNormalTexture(create: true).Scale = value;
		});
		_MaterialParameter<float> occlusionParam = new _MaterialParameter<float>(_MaterialParameterKey.OcclusionStrength, MaterialOcclusionTextureInfo.StrengthDefault, () => _GetOcclusionTexture(create: false)?.Strength ?? MaterialOcclusionTextureInfo.StrengthDefault, delegate(float value)
		{
			_GetOcclusionTexture(create: true).Strength = value;
		});
		_MaterialParameter<Vector3> emissiveFactorParam = new _MaterialParameter<Vector3>(_MaterialParameterKey.RGB, _emissiveFactorDefault, () => _emissiveFactor.AsValue<Vector3>(_emissiveFactorDefault), delegate(Vector3 value)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_emissiveFactor = value.AsNullable(_emissiveFactorDefault, Vector3.Zero, Vector3.One);
		});
		yield return new MaterialChannel(this, "Normal", new _MaterialTexture(_GetNormalTexture), materialParameter);
		yield return new MaterialChannel(this, "Occlusion", new _MaterialTexture(_GetOcclusionTexture), occlusionParam);
		yield return new MaterialChannel(this, "Emissive", new _MaterialTexture(_GetEmissiveTexture), emissiveFactorParam, MaterialEmissiveStrength.GetParameter(this));
	}

	private MaterialNormalTextureInfo _GetNormalTexture(bool create)
	{
		if (create && _normalTexture == null)
		{
			ExtraProperties.SetProperty(this, ref _normalTexture, new MaterialNormalTextureInfo());
		}
		return _normalTexture;
	}

	private MaterialOcclusionTextureInfo _GetOcclusionTexture(bool create)
	{
		if (create && _occlusionTexture == null)
		{
			ExtraProperties.SetProperty(this, ref _occlusionTexture, new MaterialOcclusionTextureInfo());
		}
		return _occlusionTexture;
	}

	private TextureInfo _GetEmissiveTexture(bool create)
	{
		if (create && _emissiveTexture == null)
		{
			ExtraProperties.SetProperty(this, ref _emissiveTexture, new TextureInfo());
		}
		return _emissiveTexture;
	}
}
