using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialEmissiveStrength : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_emissive_strength";

	private const double _emissiveStrengthDefault = 1.0;

	private const double _emissiveStrengthMinimum = 0.0;

	private double? _emissiveStrength = 1.0;

	public const float DefaultEmissiveStrength = 1f;

	public float EmissiveStrength
	{
		get
		{
			return (float)(_emissiveStrength ?? 1.0);
		}
		set
		{
			_emissiveStrength = _Schema2Extensions.AsNullable(value, 1.0, 0.0, double.MaxValue);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_emissive_strength";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "emissiveStrength";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "emissiveStrength")
		{
			value = FieldInfo.From("emissiveStrength", this, (MaterialEmissiveStrength instance) => instance._emissiveStrength ?? 1.0);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "emissiveStrength", _emissiveStrength, 1.0);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "emissiveStrength")
		{
			JsonSerializable.DeserializePropertyValue<MaterialEmissiveStrength, double?>(ref reader, this, out _emissiveStrength);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal MaterialEmissiveStrength(Material material)
	{
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (_emissiveStrength < 0.0)
		{
			throw new ArgumentOutOfRangeException("EmissiveStrength");
		}
	}

	public static _MaterialParameter<float> GetParameter(Material material)
	{
		return new _MaterialParameter<float>(_MaterialParameterKey.EmissiveStrength, 1f, _getter, _setter);
		float _getter()
		{
			return material.GetExtension<MaterialEmissiveStrength>()?.EmissiveStrength ?? 1f;
		}
		void _setter(float value)
		{
			value = Math.Max(0f, value);
			if (value == 1f)
			{
				material.RemoveExtensions<MaterialEmissiveStrength>();
			}
			else
			{
				material.UseExtension<MaterialEmissiveStrength>().EmissiveStrength = value;
			}
		}
	}
}
