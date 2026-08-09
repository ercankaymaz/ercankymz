using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialIridescence : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_iridescence";

	private const double _iridescenceFactorDefault = 0.0;

	private const double _iridescenceFactorMinimum = 0.0;

	private const double _iridescenceFactorMaximum = 1.0;

	private double? _iridescenceFactor = 0.0;

	private const double _iridescenceIorDefault = 1.3;

	private const double _iridescenceIorMinimum = 1.0;

	private double? _iridescenceIor = 1.3;

	private TextureInfo _iridescenceTexture;

	private const double _iridescenceThicknessMaximumDefault = 400.0;

	private const double _iridescenceThicknessMaximumMinimum = 0.0;

	private double? _iridescenceThicknessMaximum = 400.0;

	private const double _iridescenceThicknessMinimumDefault = 100.0;

	private const double _iridescenceThicknessMinimumMinimum = 0.0;

	private double? _iridescenceThicknessMinimum = 100.0;

	private TextureInfo _iridescenceThicknessTexture;

	public float IridescenceFactor
	{
		get
		{
			return (float)_iridescenceFactor.AsValue(0.0);
		}
		set
		{
			_iridescenceFactor = _Schema2Extensions.AsNullable(value, 0.0, 0.0, 1.0);
		}
	}

	public float IridescenceIndexOfRefraction
	{
		get
		{
			return (float)_iridescenceIor.AsValue(1.3);
		}
		set
		{
			_iridescenceIor = _Schema2Extensions.AsNullable(value, 1.3, 1.0, double.MaxValue);
		}
	}

	public float IridescenceThicknessMinimum
	{
		get
		{
			return (float)_iridescenceThicknessMinimum.AsValue(100.0);
		}
		set
		{
			_iridescenceThicknessMinimum = _Schema2Extensions.AsNullable(value, 100.0, 0.0, double.MaxValue);
		}
	}

	public float IridescenceThicknessMaximum
	{
		get
		{
			return (float)_iridescenceThicknessMaximum.AsValue(400.0);
		}
		set
		{
			_iridescenceThicknessMaximum = _Schema2Extensions.AsNullable(value, 400.0, 0.0, double.MaxValue);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_iridescence";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "iridescenceFactor";
		yield return "iridescenceIor";
		yield return "iridescenceTexture";
		yield return "iridescenceThicknessMaximum";
		yield return "iridescenceThicknessMinimum";
		yield return "iridescenceThicknessTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "iridescenceFactor":
			value = FieldInfo.From("iridescenceFactor", this, (MaterialIridescence instance) => instance._iridescenceFactor.GetValueOrDefault());
			return true;
		case "iridescenceIor":
			value = FieldInfo.From("iridescenceIor", this, (MaterialIridescence instance) => instance._iridescenceIor ?? 1.3);
			return true;
		case "iridescenceTexture":
			value = FieldInfo.From("iridescenceTexture", this, (MaterialIridescence instance) => instance._iridescenceTexture);
			return true;
		case "iridescenceThicknessMaximum":
			value = FieldInfo.From("iridescenceThicknessMaximum", this, (MaterialIridescence instance) => instance._iridescenceThicknessMaximum ?? 400.0);
			return true;
		case "iridescenceThicknessMinimum":
			value = FieldInfo.From("iridescenceThicknessMinimum", this, (MaterialIridescence instance) => instance._iridescenceThicknessMinimum ?? 100.0);
			return true;
		case "iridescenceThicknessTexture":
			value = FieldInfo.From("iridescenceThicknessTexture", this, (MaterialIridescence instance) => instance._iridescenceThicknessTexture);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "iridescenceFactor", _iridescenceFactor, 0.0);
		JsonSerializable.SerializeProperty(writer, "iridescenceIor", _iridescenceIor, 1.3);
		JsonSerializable.SerializePropertyObject(writer, "iridescenceTexture", _iridescenceTexture);
		JsonSerializable.SerializeProperty(writer, "iridescenceThicknessMaximum", _iridescenceThicknessMaximum, 400.0);
		JsonSerializable.SerializeProperty(writer, "iridescenceThicknessMinimum", _iridescenceThicknessMinimum, 100.0);
		JsonSerializable.SerializePropertyObject(writer, "iridescenceThicknessTexture", _iridescenceThicknessTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "iridescenceFactor":
			JsonSerializable.DeserializePropertyValue<MaterialIridescence, double?>(ref reader, this, out _iridescenceFactor);
			break;
		case "iridescenceIor":
			JsonSerializable.DeserializePropertyValue<MaterialIridescence, double?>(ref reader, this, out _iridescenceIor);
			break;
		case "iridescenceTexture":
			JsonSerializable.DeserializePropertyValue<MaterialIridescence, TextureInfo>(ref reader, this, out _iridescenceTexture);
			break;
		case "iridescenceThicknessMaximum":
			JsonSerializable.DeserializePropertyValue<MaterialIridescence, double?>(ref reader, this, out _iridescenceThicknessMaximum);
			break;
		case "iridescenceThicknessMinimum":
			JsonSerializable.DeserializePropertyValue<MaterialIridescence, double?>(ref reader, this, out _iridescenceThicknessMinimum);
			break;
		case "iridescenceThicknessTexture":
			JsonSerializable.DeserializePropertyValue<MaterialIridescence, TextureInfo>(ref reader, this, out _iridescenceThicknessTexture);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal MaterialIridescence(Material material)
	{
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (_iridescenceFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_iridescenceFactor.Value, 0.0, 1.0, "_iridescenceFactor");
		}
		if (_iridescenceIor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_iridescenceIor.Value, 1.0, double.MaxValue, "_iridescenceIor");
		}
		double num = _iridescenceThicknessMinimum ?? 100.0;
		double num2 = _iridescenceThicknessMaximum ?? 400.0;
		Guard.MustBeBetweenOrEqualTo(num, 0.0, num2, "_iridescenceThicknessMinimum");
		Guard.MustBeBetweenOrEqualTo(num2, num, double.MaxValue, "_iridescenceThicknessMaximum");
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _iridescenceTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _iridescenceTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter = new _MaterialParameter<float>(_MaterialParameterKey.IridescenceFactor, 0f, () => IridescenceFactor, delegate(float v)
		{
			IridescenceFactor = v;
		});
		_MaterialParameter<float> materialParameter2 = new _MaterialParameter<float>(_MaterialParameterKey.IndexOfRefraction, 1.3f, () => IridescenceIndexOfRefraction, delegate(float v)
		{
			IridescenceIndexOfRefraction = v;
		});
		yield return new MaterialChannel(material, "Iridescence", texInfo, materialParameter, materialParameter2);
		_MaterialTexture texInfo2 = new _MaterialTexture(() => _iridescenceThicknessTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _iridescenceThicknessTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter3 = new _MaterialParameter<float>(_MaterialParameterKey.Minimum, 100f, () => IridescenceThicknessMinimum, delegate(float v)
		{
			IridescenceThicknessMinimum = v;
		});
		_MaterialParameter<float> materialParameter4 = new _MaterialParameter<float>(_MaterialParameterKey.Maximum, 400f, () => IridescenceThicknessMaximum, delegate(float v)
		{
			IridescenceThicknessMaximum = v;
		});
		yield return new MaterialChannel(material, "IridescenceThickness", texInfo2, materialParameter3, materialParameter4);
	}
}
