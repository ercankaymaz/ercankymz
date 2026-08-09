using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialAnisotropy : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_anisotropy";

	private const double _anisotropyRotationDefault = 0.0;

	private double? _anisotropyRotation = 0.0;

	private const double _anisotropyStrengthDefault = 0.0;

	private const double _anisotropyStrengthMinimum = 0.0;

	private const double _anisotropyStrengthMaximum = 1.0;

	private double? _anisotropyStrength = 0.0;

	private TextureInfo _anisotropyTexture;

	public float AnisotropyStrength
	{
		get
		{
			return (float)_anisotropyStrength.AsValue(0.0);
		}
		set
		{
			_anisotropyStrength = _Schema2Extensions.AsNullable(value, 0.0, 0.0, 1.0);
		}
	}

	public float AnisotropyRotation
	{
		get
		{
			return (float)_anisotropyRotation.AsValue(0.0);
		}
		set
		{
			_anisotropyRotation = value.AsNullable(0f);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_anisotropy";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "anisotropyRotation";
		yield return "anisotropyStrength";
		yield return "anisotropyTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "anisotropyRotation":
			value = FieldInfo.From("anisotropyRotation", this, (MaterialAnisotropy instance) => instance._anisotropyRotation.GetValueOrDefault());
			return true;
		case "anisotropyStrength":
			value = FieldInfo.From("anisotropyStrength", this, (MaterialAnisotropy instance) => instance._anisotropyStrength.GetValueOrDefault());
			return true;
		case "anisotropyTexture":
			value = FieldInfo.From("anisotropyTexture", this, (MaterialAnisotropy instance) => instance._anisotropyTexture);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "anisotropyRotation", _anisotropyRotation, 0.0);
		JsonSerializable.SerializeProperty(writer, "anisotropyStrength", _anisotropyStrength, 0.0);
		JsonSerializable.SerializePropertyObject(writer, "anisotropyTexture", _anisotropyTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "anisotropyRotation":
			JsonSerializable.DeserializePropertyValue<MaterialAnisotropy, double?>(ref reader, this, out _anisotropyRotation);
			break;
		case "anisotropyStrength":
			JsonSerializable.DeserializePropertyValue<MaterialAnisotropy, double?>(ref reader, this, out _anisotropyStrength);
			break;
		case "anisotropyTexture":
			JsonSerializable.DeserializePropertyValue<MaterialAnisotropy, TextureInfo>(ref reader, this, out _anisotropyTexture);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal MaterialAnisotropy(Material material)
	{
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (_anisotropyStrength.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_anisotropyStrength.Value, 0.0, 1.0, "_anisotropyStrength");
		}
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _anisotropyTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _anisotropyTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter = new _MaterialParameter<float>(_MaterialParameterKey.AnisotropyStrength, 0f, () => AnisotropyStrength, delegate(float v)
		{
			AnisotropyStrength = v;
		});
		_MaterialParameter<float> materialParameter2 = new _MaterialParameter<float>(_MaterialParameterKey.AnisotropyRotation, 0f, () => AnisotropyRotation, delegate(float v)
		{
			AnisotropyRotation = v;
		});
		yield return new MaterialChannel(material, "Anisotropy", texInfo, materialParameter, materialParameter2);
	}
}
