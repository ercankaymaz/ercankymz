using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialDiffuseTransmission : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_diffuse_transmission";

	private static readonly Vector3 _diffuseTransmissionColorFactorDefault = Vector3.One;

	private Vector3? _diffuseTransmissionColorFactor = _diffuseTransmissionColorFactorDefault;

	private TextureInfo _diffuseTransmissionColorTexture;

	private const double _diffuseTransmissionFactorDefault = 0.0;

	private const double _diffuseTransmissionFactorMinimum = 0.0;

	private const double _diffuseTransmissionFactorMaximum = 1.0;

	private double? _diffuseTransmissionFactor = 0.0;

	private TextureInfo _diffuseTransmissionTexture;

	public float DiffuseTransmissionFactor
	{
		get
		{
			return (float)_diffuseTransmissionFactor.AsValue(0.0);
		}
		set
		{
			_diffuseTransmissionFactor = _Schema2Extensions.AsNullable(value, 0.0, 0.0, 1.0);
		}
	}

	public Vector3 DiffuseTransmissionColorFactor
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _diffuseTransmissionColorFactor.AsValue<Vector3>(_diffuseTransmissionColorFactorDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_diffuseTransmissionColorFactor = value.AsNullable<Vector3>(_diffuseTransmissionColorFactorDefault);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_diffuse_transmission";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "diffuseTransmissionColorFactor";
		yield return "diffuseTransmissionColorTexture";
		yield return "diffuseTransmissionFactor";
		yield return "diffuseTransmissionTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "diffuseTransmissionColorFactor":
			value = FieldInfo.From("diffuseTransmissionColorFactor", this, (MaterialDiffuseTransmission instance) => (Vector3)(((_003F?)instance._diffuseTransmissionColorFactor) ?? Vector3.One));
			return true;
		case "diffuseTransmissionColorTexture":
			value = FieldInfo.From("diffuseTransmissionColorTexture", this, (MaterialDiffuseTransmission instance) => instance._diffuseTransmissionColorTexture);
			return true;
		case "diffuseTransmissionFactor":
			value = FieldInfo.From("diffuseTransmissionFactor", this, (MaterialDiffuseTransmission instance) => instance._diffuseTransmissionFactor.GetValueOrDefault());
			return true;
		case "diffuseTransmissionTexture":
			value = FieldInfo.From("diffuseTransmissionTexture", this, (MaterialDiffuseTransmission instance) => instance._diffuseTransmissionTexture);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "diffuseTransmissionColorFactor", _diffuseTransmissionColorFactor, _diffuseTransmissionColorFactorDefault);
		JsonSerializable.SerializePropertyObject(writer, "diffuseTransmissionColorTexture", _diffuseTransmissionColorTexture);
		JsonSerializable.SerializeProperty(writer, "diffuseTransmissionFactor", _diffuseTransmissionFactor, 0.0);
		JsonSerializable.SerializePropertyObject(writer, "diffuseTransmissionTexture", _diffuseTransmissionTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "diffuseTransmissionColorFactor":
			JsonSerializable.DeserializePropertyValue<MaterialDiffuseTransmission, Vector3?>(ref reader, this, out _diffuseTransmissionColorFactor);
			break;
		case "diffuseTransmissionColorTexture":
			JsonSerializable.DeserializePropertyValue<MaterialDiffuseTransmission, TextureInfo>(ref reader, this, out _diffuseTransmissionColorTexture);
			break;
		case "diffuseTransmissionFactor":
			JsonSerializable.DeserializePropertyValue<MaterialDiffuseTransmission, double?>(ref reader, this, out _diffuseTransmissionFactor);
			break;
		case "diffuseTransmissionTexture":
			JsonSerializable.DeserializePropertyValue<MaterialDiffuseTransmission, TextureInfo>(ref reader, this, out _diffuseTransmissionTexture);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal MaterialDiffuseTransmission(Material material)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (_diffuseTransmissionFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_diffuseTransmissionFactor.Value, 0.0, 1.0, "_diffuseTransmissionFactor");
		}
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _diffuseTransmissionTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _diffuseTransmissionTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter = new _MaterialParameter<float>(_MaterialParameterKey.DiffuseTransmissionFactor, 0f, () => DiffuseTransmissionFactor, delegate(float v)
		{
			DiffuseTransmissionFactor = v;
		});
		yield return new MaterialChannel(material, "DiffuseTransmissionFactor", texInfo, materialParameter);
		_MaterialTexture texInfo2 = new _MaterialTexture(() => _diffuseTransmissionColorTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _diffuseTransmissionColorTexture, new TextureInfo());
		});
		_MaterialParameter<Vector3> materialParameter2 = new _MaterialParameter<Vector3>(_MaterialParameterKey.RGB, _diffuseTransmissionColorFactorDefault, () => DiffuseTransmissionColorFactor, delegate(Vector3 v)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			DiffuseTransmissionColorFactor = v;
		});
		yield return new MaterialChannel(material, "DiffuseTransmissionColor", texInfo2, materialParameter2);
	}
}
