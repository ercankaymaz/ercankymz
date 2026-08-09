using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialTransmission : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_transmission";

	private const double _transmissionFactorDefault = 0.0;

	private const double _transmissionFactorMinimum = 0.0;

	private const double _transmissionFactorMaximum = 1.0;

	private double? _transmissionFactor = 0.0;

	private TextureInfo _transmissionTexture;

	public float TransmissionFactor
	{
		get
		{
			return (float)_transmissionFactor.AsValue(0.0);
		}
		set
		{
			_transmissionFactor = value.AsNullable(0f);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_transmission";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "transmissionFactor";
		yield return "transmissionTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "transmissionFactor"))
		{
			if (name == "transmissionTexture")
			{
				value = FieldInfo.From("transmissionTexture", this, (MaterialTransmission instance) => instance._transmissionTexture);
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("transmissionFactor", this, (MaterialTransmission instance) => instance._transmissionFactor.GetValueOrDefault());
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "transmissionFactor", _transmissionFactor, 0.0);
		JsonSerializable.SerializePropertyObject(writer, "transmissionTexture", _transmissionTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "transmissionFactor"))
		{
			if (jsonPropertyName == "transmissionTexture")
			{
				JsonSerializable.DeserializePropertyValue<MaterialTransmission, TextureInfo>(ref reader, this, out _transmissionTexture);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyValue<MaterialTransmission, double?>(ref reader, this, out _transmissionFactor);
		}
	}

	internal MaterialTransmission(Material material)
	{
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (_transmissionFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_transmissionFactor.Value, 0.0, 1.0, "_transmissionFactor");
		}
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _transmissionTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _transmissionTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter = new _MaterialParameter<float>(_MaterialParameterKey.TransmissionFactor, 0f, () => TransmissionFactor, delegate(float v)
		{
			TransmissionFactor = v;
		});
		yield return new MaterialChannel(material, "Transmission", texInfo, materialParameter);
	}
}
