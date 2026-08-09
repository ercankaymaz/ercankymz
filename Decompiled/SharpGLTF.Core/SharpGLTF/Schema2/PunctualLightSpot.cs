using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal class PunctualLightSpot : ExtraProperties
{
	public new const string SCHEMANAME = "spot";

	private const double _innerConeAngleDefault = 0.0;

	private const double _innerConeAngleMinimum = 0.0;

	private const double _innerConeAngleExclusiveMaximum = Math.PI / 2.0;

	private double? _innerConeAngle = 0.0;

	private const double _outerConeAngleDefault = Math.PI / 4.0;

	private const double _outerConeAngleExclusiveMinimum = 0.0;

	private const double _outerConeAngleMaximum = Math.PI / 2.0;

	private double? _outerConeAngle = Math.PI / 4.0;

	public float InnerConeAngle
	{
		get
		{
			return (float)_innerConeAngle.AsValue(0.0);
		}
		set
		{
			Guard.MustBeLessThan(value, Math.PI / 2.0, "value");
			_innerConeAngle = value.AsNullable(0f, 0f, MathF.PI / 2f);
		}
	}

	public float OuterConeAngle
	{
		get
		{
			return (float)_outerConeAngle.AsValue(Math.PI / 4.0);
		}
		set
		{
			Guard.MustBeGreaterThan(value, 0.0, "value");
			_outerConeAngle = value.AsNullable(MathF.PI / 4f, 0f, MathF.PI / 2f);
		}
	}

	protected override string GetSchemaName()
	{
		return "spot";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "innerConeAngle";
		yield return "outerConeAngle";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (!(name == "innerConeAngle"))
		{
			if (name == "outerConeAngle")
			{
				value = FieldInfo.From("outerConeAngle", this, (PunctualLightSpot instance) => instance._outerConeAngle ?? (Math.PI / 4.0));
				return true;
			}
			return base.TryReflectField(name, out value);
		}
		value = FieldInfo.From("innerConeAngle", this, (PunctualLightSpot instance) => instance._innerConeAngle.GetValueOrDefault());
		return true;
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "innerConeAngle", _innerConeAngle, 0.0);
		JsonSerializable.SerializeProperty(writer, "outerConeAngle", _outerConeAngle, Math.PI / 4.0);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (!(jsonPropertyName == "innerConeAngle"))
		{
			if (jsonPropertyName == "outerConeAngle")
			{
				JsonSerializable.DeserializePropertyValue<PunctualLightSpot, double?>(ref reader, this, out _outerConeAngle);
			}
			else
			{
				base.DeserializeProperty(jsonPropertyName, ref reader);
			}
		}
		else
		{
			JsonSerializable.DeserializePropertyValue<PunctualLightSpot, double?>(ref reader, this, out _innerConeAngle);
		}
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		validate.IsDefaultOrWithin("InnerConeAngle", InnerConeAngle, 0f, MathF.PI / 2f).IsDefaultOrWithin("OuterConeAngle", OuterConeAngle, 0f, MathF.PI / 2f).IsLess("InnerConeAngle", InnerConeAngle, OuterConeAngle);
		base.OnValidateContent(validate);
	}
}
