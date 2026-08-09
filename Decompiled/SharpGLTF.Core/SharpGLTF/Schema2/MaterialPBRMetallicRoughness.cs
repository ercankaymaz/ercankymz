using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialPBRMetallicRoughness : ExtraProperties, IChildOf<Material>
{
	public new const string SCHEMANAME = "pbrMetallicRoughness";

	private static readonly Vector4 _baseColorFactorDefault = Vector4.One;

	private Vector4? _baseColorFactor = _baseColorFactorDefault;

	private TextureInfo _baseColorTexture;

	private const double _metallicFactorDefault = 1.0;

	private const double _metallicFactorMinimum = 0.0;

	private const double _metallicFactorMaximum = 1.0;

	private double? _metallicFactor = 1.0;

	private TextureInfo _metallicRoughnessTexture;

	private const double _roughnessFactorDefault = 1.0;

	private const double _roughnessFactorMinimum = 0.0;

	private const double _roughnessFactorMaximum = 1.0;

	private double? _roughnessFactor = 1.0;

	private Material _Parent;

	Material IChildOf<Material>.LogicalParent => _Parent;

	public Vector4 Color
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _baseColorFactor.AsValue<Vector4>(_baseColorFactorDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_baseColorFactor = value.AsNullable<Vector4>(_baseColorFactorDefault);
		}
	}

	public float MetallicFactor
	{
		get
		{
			return (float)_metallicFactor.AsValue(1.0);
		}
		set
		{
			_metallicFactor = _Schema2Extensions.AsNullable(value, 1.0, 0.0, 1.0);
		}
	}

	public float RoughnessFactor
	{
		get
		{
			return (float)_roughnessFactor.AsValue(1.0);
		}
		set
		{
			_roughnessFactor = _Schema2Extensions.AsNullable(value, 1.0, 0.0, 1.0);
		}
	}

	protected override string GetSchemaName()
	{
		return "pbrMetallicRoughness";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "baseColorFactor";
		yield return "baseColorTexture";
		yield return "metallicFactor";
		yield return "metallicRoughnessTexture";
		yield return "roughnessFactor";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "baseColorFactor":
			value = FieldInfo.From("baseColorFactor", this, (MaterialPBRMetallicRoughness instance) => (Vector4)(((_003F?)instance._baseColorFactor) ?? Vector4.One));
			return true;
		case "baseColorTexture":
			value = FieldInfo.From("baseColorTexture", this, (MaterialPBRMetallicRoughness instance) => instance._baseColorTexture);
			return true;
		case "metallicFactor":
			value = FieldInfo.From("metallicFactor", this, (MaterialPBRMetallicRoughness instance) => instance._metallicFactor ?? 1.0);
			return true;
		case "metallicRoughnessTexture":
			value = FieldInfo.From("metallicRoughnessTexture", this, (MaterialPBRMetallicRoughness instance) => instance._metallicRoughnessTexture);
			return true;
		case "roughnessFactor":
			value = FieldInfo.From("roughnessFactor", this, (MaterialPBRMetallicRoughness instance) => instance._roughnessFactor ?? 1.0);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "baseColorFactor", _baseColorFactor, _baseColorFactorDefault);
		JsonSerializable.SerializePropertyObject(writer, "baseColorTexture", _baseColorTexture);
		JsonSerializable.SerializeProperty(writer, "metallicFactor", _metallicFactor, 1.0);
		JsonSerializable.SerializePropertyObject(writer, "metallicRoughnessTexture", _metallicRoughnessTexture);
		JsonSerializable.SerializeProperty(writer, "roughnessFactor", _roughnessFactor, 1.0);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "baseColorFactor":
			JsonSerializable.DeserializePropertyValue<MaterialPBRMetallicRoughness, Vector4?>(ref reader, this, out _baseColorFactor);
			break;
		case "baseColorTexture":
			JsonSerializable.DeserializePropertyValue<MaterialPBRMetallicRoughness, TextureInfo>(ref reader, this, out _baseColorTexture);
			break;
		case "metallicFactor":
			JsonSerializable.DeserializePropertyValue<MaterialPBRMetallicRoughness, double?>(ref reader, this, out _metallicFactor);
			break;
		case "metallicRoughnessTexture":
			JsonSerializable.DeserializePropertyValue<MaterialPBRMetallicRoughness, TextureInfo>(ref reader, this, out _metallicRoughnessTexture);
			break;
		case "roughnessFactor":
			JsonSerializable.DeserializePropertyValue<MaterialPBRMetallicRoughness, double?>(ref reader, this, out _roughnessFactor);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	void IChildOf<Material>.SetLogicalParent(Material parent)
	{
		_Parent = parent;
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		base.OnValidateContent(validate);
		if (_baseColorFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_baseColorFactor.Value.X, 0f, 1f, "_baseColorFactor");
			Guard.MustBeBetweenOrEqualTo(_baseColorFactor.Value.Y, 0f, 1f, "_baseColorFactor");
			Guard.MustBeBetweenOrEqualTo(_baseColorFactor.Value.Z, 0f, 1f, "_baseColorFactor");
			Guard.MustBeBetweenOrEqualTo(_baseColorFactor.Value.W, 0f, 1f, "_baseColorFactor");
		}
		if (_metallicFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_metallicFactor.Value, 0.0, 1.0, "_metallicFactor");
		}
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _baseColorTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _baseColorTexture, new TextureInfo());
		});
		_MaterialParameter<Vector4> materialParameter = new _MaterialParameter<Vector4>(_MaterialParameterKey.RGBA, _baseColorFactorDefault, () => Color, delegate(Vector4 v)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			Color = v;
		});
		yield return new MaterialChannel(material, "BaseColor", texInfo, materialParameter);
		_MaterialTexture texInfo2 = new _MaterialTexture(() => _metallicRoughnessTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _metallicRoughnessTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter2 = new _MaterialParameter<float>(_MaterialParameterKey.MetallicFactor, 1f, () => MetallicFactor, delegate(float v)
		{
			MetallicFactor = v;
		});
		_MaterialParameter<float> materialParameter3 = new _MaterialParameter<float>(_MaterialParameterKey.RoughnessFactor, 1f, () => RoughnessFactor, delegate(float v)
		{
			RoughnessFactor = v;
		});
		yield return new MaterialChannel(material, "MetallicRoughness", texInfo2, materialParameter2, materialParameter3);
	}
}
