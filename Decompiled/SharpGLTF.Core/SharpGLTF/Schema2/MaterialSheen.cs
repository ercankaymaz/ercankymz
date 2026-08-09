using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialSheen : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_sheen";

	private static readonly Vector3 _sheenColorFactorDefault = Vector3.Zero;

	private Vector3? _sheenColorFactor = _sheenColorFactorDefault;

	private TextureInfo _sheenColorTexture;

	private const float _sheenRoughnessFactorDefault = 0f;

	private const float _sheenRoughnessFactorMinimum = 0f;

	private const float _sheenRoughnessFactorMaximum = 1f;

	private float? _sheenRoughnessFactor = 0f;

	private TextureInfo _sheenRoughnessTexture;

	public Vector3 ColorFactor
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _sheenColorFactor.AsValue<Vector3>(_sheenColorFactorDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_sheenColorFactor = value.AsNullable<Vector3>(_sheenColorFactorDefault);
		}
	}

	public float RoughnessFactor
	{
		get
		{
			return _sheenRoughnessFactor.AsValue(0f);
		}
		set
		{
			_sheenRoughnessFactor = value.AsNullable(0f);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_sheen";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "sheenColorFactor";
		yield return "sheenColorTexture";
		yield return "sheenRoughnessFactor";
		yield return "sheenRoughnessTexture";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "sheenColorFactor":
			value = FieldInfo.From("sheenColorFactor", this, (MaterialSheen instance) => (Vector3)(((_003F?)instance._sheenColorFactor) ?? Vector3.Zero));
			return true;
		case "sheenColorTexture":
			value = FieldInfo.From("sheenColorTexture", this, (MaterialSheen instance) => instance._sheenColorTexture);
			return true;
		case "sheenRoughnessFactor":
			value = FieldInfo.From("sheenRoughnessFactor", this, (MaterialSheen instance) => instance._sheenRoughnessFactor.GetValueOrDefault());
			return true;
		case "sheenRoughnessTexture":
			value = FieldInfo.From("sheenRoughnessTexture", this, (MaterialSheen instance) => instance._sheenRoughnessTexture);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "sheenColorFactor", _sheenColorFactor, _sheenColorFactorDefault);
		JsonSerializable.SerializePropertyObject(writer, "sheenColorTexture", _sheenColorTexture);
		JsonSerializable.SerializeProperty(writer, "sheenRoughnessFactor", _sheenRoughnessFactor, 0f);
		JsonSerializable.SerializePropertyObject(writer, "sheenRoughnessTexture", _sheenRoughnessTexture);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "sheenColorFactor":
			JsonSerializable.DeserializePropertyValue<MaterialSheen, Vector3?>(ref reader, this, out _sheenColorFactor);
			break;
		case "sheenColorTexture":
			JsonSerializable.DeserializePropertyValue<MaterialSheen, TextureInfo>(ref reader, this, out _sheenColorTexture);
			break;
		case "sheenRoughnessFactor":
			JsonSerializable.DeserializePropertyValue<MaterialSheen, float?>(ref reader, this, out _sheenRoughnessFactor);
			break;
		case "sheenRoughnessTexture":
			JsonSerializable.DeserializePropertyValue<MaterialSheen, TextureInfo>(ref reader, this, out _sheenRoughnessTexture);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal MaterialSheen(Material material)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	protected override void OnValidateContent(ValidationContext validate)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		base.OnValidateContent(validate);
		if (_sheenColorFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_sheenColorFactor.Value.X, 0f, 1f, "_sheenColorFactor");
			Guard.MustBeBetweenOrEqualTo(_sheenColorFactor.Value.Y, 0f, 1f, "_sheenColorFactor");
			Guard.MustBeBetweenOrEqualTo(_sheenColorFactor.Value.Z, 0f, 1f, "_sheenColorFactor");
		}
		if (_sheenRoughnessFactor.HasValue)
		{
			Guard.MustBeBetweenOrEqualTo(_sheenRoughnessFactor.Value, 0f, 1f, "_sheenRoughnessFactor");
		}
	}

	public IEnumerable<MaterialChannel> GetChannels(Material material)
	{
		_MaterialTexture texInfo = new _MaterialTexture(() => _sheenColorTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _sheenColorTexture, new TextureInfo());
		});
		_MaterialParameter<Vector3> materialParameter = new _MaterialParameter<Vector3>(_MaterialParameterKey.RGB, _sheenColorFactorDefault, () => ColorFactor, delegate(Vector3 v)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			ColorFactor = v;
		});
		yield return new MaterialChannel(material, "SheenColor", texInfo, materialParameter);
		_MaterialTexture texInfo2 = new _MaterialTexture(() => _sheenRoughnessTexture, delegate
		{
			ExtraProperties.SetProperty(this, ref _sheenRoughnessTexture, new TextureInfo());
		});
		_MaterialParameter<float> materialParameter2 = new _MaterialParameter<float>(_MaterialParameterKey.RoughnessFactor, 0f, () => RoughnessFactor, delegate(float v)
		{
			RoughnessFactor = v;
		});
		yield return new MaterialChannel(material, "SheenRoughness", texInfo2, materialParameter2);
	}
}
