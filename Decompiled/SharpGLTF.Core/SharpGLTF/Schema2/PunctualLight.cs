using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("{LightType} {Color} {Intensity} {Range}")]
public sealed class PunctualLight : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "light";

	private static readonly Vector3 _colorDefault = Vector3.One;

	private Vector3? _color = _colorDefault;

	private const double _intensityDefault = 1.0;

	private const double _intensityMinimum = 0.0;

	private double? _intensity = 1.0;

	private const double _rangeExclusiveMinimum = 0.0;

	private double? _range;

	private PunctualLightSpot _spot;

	private string _type;

	private const double _rangeDefault = double.PositiveInfinity;

	public static Vector3 LocalDirection => -Vector3.UnitZ;

	public PunctualLightType LightType
	{
		get
		{
			if (!string.IsNullOrEmpty(_type))
			{
				return (PunctualLightType)Enum.Parse(typeof(PunctualLightType), _type, ignoreCase: true);
			}
			return PunctualLightType.Directional;
		}
	}

	public float InnerConeAngle => _spot?.InnerConeAngle ?? 0f;

	public float OuterConeAngle => _spot?.OuterConeAngle ?? 0f;

	public Vector3 Color
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _color.AsValue<Vector3>(_colorDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			_color = value.AsNullable(_colorDefault, Vector3.Zero, Vector3.One);
		}
	}

	public float Intensity
	{
		get
		{
			return (float)_intensity.AsValue(1.0);
		}
		set
		{
			_intensity = _Schema2Extensions.AsNullable(value, 1.0, 0.0, 3.4028234663852886E+38);
		}
	}

	public float Range
	{
		get
		{
			return (float)_range.AsValue(double.PositiveInfinity);
		}
		set
		{
			if (LightType == PunctualLightType.Directional)
			{
				_range = null;
				return;
			}
			if ((double)value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			_range = _Schema2Extensions.AsNullable(value, double.PositiveInfinity, 0.0, 3.4028234663852886E+38);
		}
	}

	protected override string GetSchemaName()
	{
		return "light";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "color";
		yield return "intensity";
		yield return "range";
		yield return "spot";
		yield return "type";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "color":
			value = FieldInfo.From("color", this, (PunctualLight instance) => (Vector3)(((_003F?)instance._color) ?? Vector3.One));
			return true;
		case "intensity":
			value = FieldInfo.From("intensity", this, (PunctualLight instance) => instance._intensity ?? 1.0);
			return true;
		case "range":
			value = FieldInfo.From("range", this, (PunctualLight instance) => instance._range);
			return true;
		case "spot":
			value = FieldInfo.From("spot", this, (PunctualLight instance) => instance._spot);
			return true;
		case "type":
			value = FieldInfo.From("type", this, (PunctualLight instance) => instance._type);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "color", _color, _colorDefault);
		JsonSerializable.SerializeProperty(writer, "intensity", _intensity, 1.0);
		JsonSerializable.SerializeProperty(writer, "range", _range);
		JsonSerializable.SerializePropertyObject(writer, "spot", _spot);
		JsonSerializable.SerializeProperty(writer, "type", _type);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "color":
			JsonSerializable.DeserializePropertyValue<PunctualLight, Vector3?>(ref reader, this, out _color);
			break;
		case "intensity":
			JsonSerializable.DeserializePropertyValue<PunctualLight, double?>(ref reader, this, out _intensity);
			break;
		case "range":
			JsonSerializable.DeserializePropertyValue<PunctualLight, double?>(ref reader, this, out _range);
			break;
		case "spot":
			JsonSerializable.DeserializePropertyValue<PunctualLight, PunctualLightSpot>(ref reader, this, out _spot);
			break;
		case "type":
			JsonSerializable.DeserializePropertyValue<PunctualLight, string>(ref reader, this, out _type);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal PunctualLight()
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	internal PunctualLight(PunctualLightType ltype)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		_type = ltype.ToString().ToLowerInvariant();
		if (ltype == PunctualLightType.Spot)
		{
			_spot = new PunctualLightSpot();
		}
	}

	public void SetSpotCone(float innerConeAngle, float outerConeAngle)
	{
		if (_spot == null)
		{
			throw new InvalidOperationException($"Expected {PunctualLightType.Spot} but found {LightType}");
		}
		if (innerConeAngle > outerConeAngle)
		{
			throw new ArgumentException("innerConeAngle must be equal or smaller than outerConeAngle");
		}
		_spot.InnerConeAngle = innerConeAngle;
		_spot.OuterConeAngle = outerConeAngle;
	}

	public void SetColor(Vector3 color, float intensity = 1f, float range = float.PositiveInfinity)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		Color = color;
		Intensity = intensity;
		Range = range;
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		validate.IsAnyOf("Type", _type, "directional", "point", "spot");
		if (LightType == PunctualLightType.Spot)
		{
			validate.IsDefined("Spot", _spot);
		}
		base.OnValidateReferences(validate);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		validate.IsDefaultOrWithin("Intensity", _intensity, 0.0, 3.4028234663852886E+38);
		base.OnValidateContent(validate);
	}
}
