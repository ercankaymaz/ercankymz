using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialVolume : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_volume";

	private static readonly Vector3 _attenuationColorDefault = Vector3.One;

	private Vector3? _attenuationColor = _attenuationColorDefault;

	private const double _attenuationDistanceExclusiveMinimum = 0.0;

	private double? _attenuationDistance;

	private const double _thicknessFactorDefault = 0.0;

	private const double _thicknessFactorMinimum = 0.0;

	private double? _thicknessFactor = 0.0;

	private TextureInfo _thicknessTexture;

	public float ThicknessFactor
	{
		get
		{
			return (float)_thicknessFactor.AsValue(0.0);
		}
		set
		{
			_thicknessFactor = _Schema2Extensions.AsNullable(value, 0.0, 0.0, double.MaxValue);
		}
	}

	public Vector3 AttenuationColor
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _attenuationColor.AsValue<Vector3>(_attenuationColorDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_attenuationColor = value.AsNullable<Vector3>(_attenuationColorDefault);
		}
	}

	public float AttenuationDistance
	{
		get
		{
			return (float)_attenuationDistance.AsValue(3.4028234663852886E+38);
		}
		set
		{
			_attenuationDistance = _Schema2Extensions.AsNullable(value, double.MaxValue, 0.0, double.MaxValue);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_volume";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "attenuationColor";
		yield return "attenuationDistance";
		yield return "thicknessFactor";
		yield return "thicknessTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "attenuationColor":
			value = FieldInfo.From("attenuationColor", this, (MaterialVolume instance) => (Vector3)(((_003F?)instance._attenuationColor) ?? Vector3.One));
			return true;
		case "attenuationDistance":
			value = FieldInfo.From("attenuationDistance", this, (MaterialVolume instance) => instance._attenuationDistance);
			return true;
		case "thicknessFactor":
			value = FieldInfo.From("thicknessFactor", this, (MaterialVolume instance) => instance._thicknessFactor.GetValueOrDefault());
			return true;
		case "thicknessTexture":
			value = FieldInfo.From("thicknessTexture", this, (MaterialVolume instance) => instance._thicknessTexture);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "attenuationColor", _attenuationColor, _attenuationColorDefault);
		JsonSerializable.SerializeProperty(writer, "attenuationDistance", _attenuationDistance);
		JsonSerializable.SerializeProperty(writer, "thicknessFactor", _thicknessFactor, 0.0);
		JsonSerializable.SerializePropertyObject(writer, "thicknessTexture", _thicknessTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "attenuationColor":
			JsonSerializable.DeserializePropertyValue<MaterialVolume, Vector3?>(ref reader, this, out _attenuationColor);
			break;
		case "attenuationDistance":
			JsonSerializable.DeserializePropertyValue<MaterialVolume, double?>(ref reader, this, out _attenuationDistance);
			break;
		case "thicknessFactor":
			JsonSerializable.DeserializePropertyValue<MaterialVolume, double?>(ref reader, this, out _thicknessFactor);
			break;
		case "thicknessTexture":
			JsonSerializable.DeserializePropertyValue<MaterialVolume, TextureInfo>(ref reader, this, out _thicknessTexture);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal MaterialVolume(Material material)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	protected override void OnValidateContent(ValidationContext validate)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		base.OnValidateContent(validate);
		if (_attenuationColor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_attenuationColor.Value.X, 0f, float.MaxValue, "_attenuationColor");
			Guard.MustBeBetweenOrEqualTo(_attenuationColor.Value.Y, 0f, float.MaxValue, "_attenuationColor");
			Guard.MustBeBetweenOrEqualTo(_attenuationColor.Value.Z, 0f, float.MaxValue, "_attenuationColor");
		}
		if (_thicknessFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_thicknessFactor.Value, 0.0, 3.4028234663852886E+38, "_thicknessFactor");
		}
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _thicknessTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _thicknessTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter = new _MaterialParameter<float>(_MaterialParameterKey.ThicknessFactor, 0f, () => ThicknessFactor, delegate(float v)
		{
			ThicknessFactor = v;
		});
		yield return new MaterialChannel(material, "VolumeThickness", texInfo, materialParameter);
		_MaterialParameter<Vector3> materialParameter2 = new _MaterialParameter<Vector3>(_MaterialParameterKey.RGB, _attenuationColorDefault, () => AttenuationColor, delegate(Vector3 v)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			AttenuationColor = v;
		});
		_MaterialParameter<float> materialParameter3 = new _MaterialParameter<float>(_MaterialParameterKey.AttenuationDistance, 0f, () => AttenuationDistance, delegate(float v)
		{
			AttenuationDistance = v;
		});
		yield return new MaterialChannel(material, "VolumeAttenuation", default(_MaterialTexture), materialParameter2, materialParameter3);
	}
}
