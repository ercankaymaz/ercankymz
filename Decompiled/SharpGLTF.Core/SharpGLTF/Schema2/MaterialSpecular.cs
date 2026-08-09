using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialSpecular : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_specular";

	private static readonly Vector3 _specularColorFactorDefault = Vector3.One;

	private Vector3? _specularColorFactor = _specularColorFactorDefault;

	private TextureInfo _specularColorTexture;

	private const double _specularFactorDefault = 1.0;

	private const double _specularFactorMinimum = 0.0;

	private const double _specularFactorMaximum = 1.0;

	private double? _specularFactor = 1.0;

	private TextureInfo _specularTexture;

	public Vector3 SpecularColor
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _specularColorFactor.AsValue<Vector3>(_specularColorFactorDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_specularColorFactor = value.AsNullable<Vector3>(_specularColorFactorDefault);
		}
	}

	public float SpecularFactor
	{
		get
		{
			return (float)_specularFactor.AsValue(1.0);
		}
		set
		{
			_specularFactor = _Schema2Extensions.AsNullable(value, 1.0, 0.0, 1.0);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_specular";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "specularColorFactor";
		yield return "specularColorTexture";
		yield return "specularFactor";
		yield return "specularTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "specularColorFactor":
			value = FieldInfo.From("specularColorFactor", this, (MaterialSpecular instance) => (Vector3)(((_003F?)instance._specularColorFactor) ?? Vector3.One));
			return true;
		case "specularColorTexture":
			value = FieldInfo.From("specularColorTexture", this, (MaterialSpecular instance) => instance._specularColorTexture);
			return true;
		case "specularFactor":
			value = FieldInfo.From("specularFactor", this, (MaterialSpecular instance) => instance._specularFactor ?? 1.0);
			return true;
		case "specularTexture":
			value = FieldInfo.From("specularTexture", this, (MaterialSpecular instance) => instance._specularTexture);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "specularColorFactor", _specularColorFactor, _specularColorFactorDefault);
		JsonSerializable.SerializePropertyObject(writer, "specularColorTexture", _specularColorTexture);
		JsonSerializable.SerializeProperty(writer, "specularFactor", _specularFactor, 1.0);
		JsonSerializable.SerializePropertyObject(writer, "specularTexture", _specularTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "specularColorFactor":
			JsonSerializable.DeserializePropertyValue<MaterialSpecular, Vector3?>(ref reader, this, out _specularColorFactor);
			break;
		case "specularColorTexture":
			JsonSerializable.DeserializePropertyValue<MaterialSpecular, TextureInfo>(ref reader, this, out _specularColorTexture);
			break;
		case "specularFactor":
			JsonSerializable.DeserializePropertyValue<MaterialSpecular, double?>(ref reader, this, out _specularFactor);
			break;
		case "specularTexture":
			JsonSerializable.DeserializePropertyValue<MaterialSpecular, TextureInfo>(ref reader, this, out _specularTexture);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal MaterialSpecular(Material material)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	protected override void OnValidateContent(ValidationContext validate)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		base.OnValidateContent(validate);
		if (_specularColorFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_specularColorFactor.Value.X, 0f, float.MaxValue, "_specularColorFactor");
			Guard.MustBeBetweenOrEqualTo(_specularColorFactor.Value.Y, 0f, float.MaxValue, "_specularColorFactor");
			Guard.MustBeBetweenOrEqualTo(_specularColorFactor.Value.Z, 0f, float.MaxValue, "_specularColorFactor");
		}
		if (_specularFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_specularFactor.Value, 0.0, 1.0, "_specularFactor");
		}
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _specularColorTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _specularColorTexture, new TextureInfo());
		});
		_MaterialParameter<Vector3> materialParameter = new _MaterialParameter<Vector3>(_MaterialParameterKey.RGB, _specularColorFactorDefault, () => SpecularColor, delegate(Vector3 v)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			SpecularColor = v;
		});
		yield return new MaterialChannel(material, "SpecularColor", texInfo, materialParameter);
		_MaterialTexture texInfo2 = new _MaterialTexture(() => _specularTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _specularTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter2 = new _MaterialParameter<float>(_MaterialParameterKey.SpecularFactor, 1f, () => SpecularFactor, delegate(float v)
		{
			SpecularFactor = v;
		});
		yield return new MaterialChannel(material, "SpecularFactor", texInfo2, materialParameter2);
	}
}
