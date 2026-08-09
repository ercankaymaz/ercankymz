using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialPBRSpecularGlossiness : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_pbrSpecularGlossiness";

	private static readonly Vector4 _diffuseFactorDefault = Vector4.One;

	private Vector4? _diffuseFactor = _diffuseFactorDefault;

	private TextureInfo _diffuseTexture;

	private const double _glossinessFactorDefault = 1.0;

	private const double _glossinessFactorMinimum = 0.0;

	private const double _glossinessFactorMaximum = 1.0;

	private double? _glossinessFactor = 1.0;

	private static readonly Vector3 _specularFactorDefault = Vector3.One;

	private Vector3? _specularFactor = _specularFactorDefault;

	private TextureInfo _specularGlossinessTexture;

	public Vector4 DiffuseFactor
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _diffuseFactor.AsValue<Vector4>(_diffuseFactorDefault);
		}
		set
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			_diffuseFactor = (_diffuseFactor = value.AsNullable<Vector4>(_diffuseFactorDefault));
		}
	}

	public Vector3 SpecularFactor
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _specularFactor.AsValue<Vector3>(_specularFactorDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_specularFactor = value.AsNullable<Vector3>(_specularFactorDefault);
		}
	}

	public float GlossinessFactor
	{
		get
		{
			return (float)_glossinessFactor.AsValue(1.0);
		}
		set
		{
			_glossinessFactor = _Schema2Extensions.AsNullable(value, 1.0, 0.0, 1.0);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_pbrSpecularGlossiness";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "diffuseFactor";
		yield return "diffuseTexture";
		yield return "glossinessFactor";
		yield return "specularFactor";
		yield return "specularGlossinessTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "diffuseFactor":
			value = FieldInfo.From("diffuseFactor", this, (MaterialPBRSpecularGlossiness instance) => (Vector4)(((_003F?)instance._diffuseFactor) ?? Vector4.One));
			return true;
		case "diffuseTexture":
			value = FieldInfo.From("diffuseTexture", this, (MaterialPBRSpecularGlossiness instance) => instance._diffuseTexture);
			return true;
		case "glossinessFactor":
			value = FieldInfo.From("glossinessFactor", this, (MaterialPBRSpecularGlossiness instance) => instance._glossinessFactor ?? 1.0);
			return true;
		case "specularFactor":
			value = FieldInfo.From("specularFactor", this, (MaterialPBRSpecularGlossiness instance) => (Vector3)(((_003F?)instance._specularFactor) ?? Vector3.One));
			return true;
		case "specularGlossinessTexture":
			value = FieldInfo.From("specularGlossinessTexture", this, (MaterialPBRSpecularGlossiness instance) => instance._specularGlossinessTexture);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "diffuseFactor", _diffuseFactor, _diffuseFactorDefault);
		JsonSerializable.SerializePropertyObject(writer, "diffuseTexture", _diffuseTexture);
		JsonSerializable.SerializeProperty(writer, "glossinessFactor", _glossinessFactor, 1.0);
		JsonSerializable.SerializeProperty(writer, "specularFactor", _specularFactor, _specularFactorDefault);
		JsonSerializable.SerializePropertyObject(writer, "specularGlossinessTexture", _specularGlossinessTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "diffuseFactor":
			JsonSerializable.DeserializePropertyValue<MaterialPBRSpecularGlossiness, Vector4?>(ref reader, this, out _diffuseFactor);
			break;
		case "diffuseTexture":
			JsonSerializable.DeserializePropertyValue<MaterialPBRSpecularGlossiness, TextureInfo>(ref reader, this, out _diffuseTexture);
			break;
		case "glossinessFactor":
			JsonSerializable.DeserializePropertyValue<MaterialPBRSpecularGlossiness, double?>(ref reader, this, out _glossinessFactor);
			break;
		case "specularFactor":
			JsonSerializable.DeserializePropertyValue<MaterialPBRSpecularGlossiness, Vector3?>(ref reader, this, out _specularFactor);
			break;
		case "specularGlossinessTexture":
			JsonSerializable.DeserializePropertyValue<MaterialPBRSpecularGlossiness, TextureInfo>(ref reader, this, out _specularGlossinessTexture);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal MaterialPBRSpecularGlossiness(Material material)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)
	//IL_0025: Unknown result type (might be due to invalid IL or missing references)


	protected override void OnValidateContent(ValidationContext validate)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		base.OnValidateContent(validate);
		if (_specularFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_specularFactor.Value.X, 0f, 1f, "_specularFactor");
			Guard.MustBeBetweenOrEqualTo(_specularFactor.Value.Y, 0f, 1f, "_specularFactor");
			Guard.MustBeBetweenOrEqualTo(_specularFactor.Value.Z, 0f, 1f, "_specularFactor");
		}
		if (_glossinessFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_glossinessFactor.Value, 0.0, 1.0, "_glossinessFactor");
		}
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _diffuseTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _diffuseTexture, new TextureInfo());
		});
		_MaterialParameter<Vector4> materialParameter = new _MaterialParameter<Vector4>(_MaterialParameterKey.RGBA, _diffuseFactorDefault, () => DiffuseFactor, delegate(Vector4 v)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			DiffuseFactor = v;
		});
		yield return new MaterialChannel(material, "Diffuse", texInfo, materialParameter);
		_MaterialTexture texInfo2 = new _MaterialTexture(() => _specularGlossinessTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _specularGlossinessTexture, new TextureInfo());
		});
		_MaterialParameter<Vector3> materialParameter2 = new _MaterialParameter<Vector3>(_MaterialParameterKey.SpecularFactor, _specularFactorDefault, () => SpecularFactor, delegate(Vector3 v)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			SpecularFactor = v;
		});
		_MaterialParameter<float> materialParameter3 = new _MaterialParameter<float>(_MaterialParameterKey.GlossinessFactor, 1f, () => GlossinessFactor, delegate(float v)
		{
			GlossinessFactor = v;
		});
		yield return new MaterialChannel(material, "SpecularGlossiness", texInfo2, materialParameter2, materialParameter3);
	}
}
