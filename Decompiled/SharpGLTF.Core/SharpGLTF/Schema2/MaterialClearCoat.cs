using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialClearCoat : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_clearcoat";

	private const double _clearcoatFactorDefault = 0.0;

	private const double _clearcoatFactorMinimum = 0.0;

	private const double _clearcoatFactorMaximum = 1.0;

	private double? _clearcoatFactor = 0.0;

	private MaterialNormalTextureInfo _clearcoatNormalTexture;

	private const double _clearcoatRoughnessFactorDefault = 0.0;

	private const double _clearcoatRoughnessFactorMinimum = 0.0;

	private const double _clearcoatRoughnessFactorMaximum = 1.0;

	private double? _clearcoatRoughnessFactor = 0.0;

	private TextureInfo _clearcoatRoughnessTexture;

	private TextureInfo _clearcoatTexture;

	public float ClearCoatFactor
	{
		get
		{
			return (float)_clearcoatFactor.AsValue(0.0);
		}
		set
		{
			_clearcoatFactor = value.AsNullable(0f);
		}
	}

	public float RoughnessFactor
	{
		get
		{
			return (float)_clearcoatRoughnessFactor.AsValue(0.0);
		}
		set
		{
			_clearcoatRoughnessFactor = value.AsNullable(0f);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_clearcoat";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "clearcoatFactor";
		yield return "clearcoatNormalTexture";
		yield return "clearcoatRoughnessFactor";
		yield return "clearcoatRoughnessTexture";
		yield return "clearcoatTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "clearcoatFactor":
			value = FieldInfo.From("clearcoatFactor", this, (MaterialClearCoat instance) => instance._clearcoatFactor.GetValueOrDefault());
			return true;
		case "clearcoatNormalTexture":
			value = FieldInfo.From("clearcoatNormalTexture", this, (MaterialClearCoat instance) => instance._clearcoatNormalTexture);
			return true;
		case "clearcoatRoughnessFactor":
			value = FieldInfo.From("clearcoatRoughnessFactor", this, (MaterialClearCoat instance) => instance._clearcoatRoughnessFactor.GetValueOrDefault());
			return true;
		case "clearcoatRoughnessTexture":
			value = FieldInfo.From("clearcoatRoughnessTexture", this, (MaterialClearCoat instance) => instance._clearcoatRoughnessTexture);
			return true;
		case "clearcoatTexture":
			value = FieldInfo.From("clearcoatTexture", this, (MaterialClearCoat instance) => instance._clearcoatTexture);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "clearcoatFactor", _clearcoatFactor, 0.0);
		JsonSerializable.SerializePropertyObject(writer, "clearcoatNormalTexture", _clearcoatNormalTexture);
		JsonSerializable.SerializeProperty(writer, "clearcoatRoughnessFactor", _clearcoatRoughnessFactor, 0.0);
		JsonSerializable.SerializePropertyObject(writer, "clearcoatRoughnessTexture", _clearcoatRoughnessTexture);
		JsonSerializable.SerializePropertyObject(writer, "clearcoatTexture", _clearcoatTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "clearcoatFactor":
			JsonSerializable.DeserializePropertyValue<MaterialClearCoat, double?>(ref reader, this, out _clearcoatFactor);
			break;
		case "clearcoatNormalTexture":
			JsonSerializable.DeserializePropertyValue<MaterialClearCoat, MaterialNormalTextureInfo>(ref reader, this, out _clearcoatNormalTexture);
			break;
		case "clearcoatRoughnessFactor":
			JsonSerializable.DeserializePropertyValue<MaterialClearCoat, double?>(ref reader, this, out _clearcoatRoughnessFactor);
			break;
		case "clearcoatRoughnessTexture":
			JsonSerializable.DeserializePropertyValue<MaterialClearCoat, TextureInfo>(ref reader, this, out _clearcoatRoughnessTexture);
			break;
		case "clearcoatTexture":
			JsonSerializable.DeserializePropertyValue<MaterialClearCoat, TextureInfo>(ref reader, this, out _clearcoatTexture);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal MaterialClearCoat(Material material)
	{
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (_clearcoatFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_clearcoatFactor.Value, 0.0, 1.0, "_clearcoatFactor");
		}
		if (_clearcoatRoughnessFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_clearcoatRoughnessFactor.Value, 0.0, 1.0, "_clearcoatRoughnessFactor");
		}
	}

	private TextureInfo _GetClearCoatTexture(bool create)
	{
		if (create && _clearcoatTexture == null)
		{
			ExtraProperties.SetProperty(this, ref _clearcoatTexture, new TextureInfo());
		}
		return _clearcoatTexture;
	}

	private TextureInfo _GetClearCoatRoughnessTexture(bool create)
	{
		if (create && _clearcoatRoughnessTexture == null)
		{
			ExtraProperties.SetProperty(this, ref _clearcoatRoughnessTexture, new TextureInfo());
		}
		return _clearcoatRoughnessTexture;
	}

	private MaterialNormalTextureInfo _GetClearCoatNormalTexture(bool create)
	{
		if (create && _clearcoatNormalTexture == null)
		{
			ExtraProperties.SetProperty(this, ref _clearcoatNormalTexture, new MaterialNormalTextureInfo());
		}
		return _clearcoatNormalTexture;
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _clearcoatTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _clearcoatTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter = new _MaterialParameter<float>(_MaterialParameterKey.ClearCoatFactor, 0f, () => ClearCoatFactor, delegate(float v)
		{
			ClearCoatFactor = v;
		});
		yield return new MaterialChannel(material, "ClearCoat", texInfo, materialParameter);
		_MaterialTexture texInfo2 = new _MaterialTexture(() => _clearcoatRoughnessTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _clearcoatRoughnessTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter2 = new _MaterialParameter<float>(_MaterialParameterKey.RoughnessFactor, 0f, () => RoughnessFactor, delegate(float v)
		{
			RoughnessFactor = v;
		});
		yield return new MaterialChannel(material, "ClearCoatRoughness", texInfo2, materialParameter2);
		_MaterialParameter<float> materialParameter3 = new _MaterialParameter<float>(_MaterialParameterKey.NormalScale, MaterialNormalTextureInfo.ScaleDefault, () => _GetClearCoatNormalTexture(create: false)?.Scale ?? MaterialNormalTextureInfo.ScaleDefault, delegate(float v)
		{
			_GetClearCoatNormalTexture(create: true).Scale = v;
		});
		yield return new MaterialChannel(material, "ClearCoatNormal", new _MaterialTexture(_GetClearCoatNormalTexture), materialParameter3);
	}
}
