using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialDispersion : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_dispersion";

	private const double _dispersionDefault = 0.0;

	private const double _dispersionMinimum = 0.0;

	private double? _dispersion = 0.0;

	public static float DefaultDispersion => 0f;

	public float Dispersion
	{
		get
		{
			return (float)_dispersion.GetValueOrDefault();
		}
		set
		{
			_dispersion = Math.Max(0.0, value).AsNullable(0.0);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_dispersion";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "dispersion";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "dispersion")
		{
			value = FieldInfo.From("dispersion", this, (MaterialDispersion instance) => instance._dispersion.GetValueOrDefault());
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "dispersion", _dispersion, 0.0);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "dispersion")
		{
			JsonSerializable.DeserializePropertyValue<MaterialDispersion, double?>(ref reader, this, out _dispersion);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal MaterialDispersion(Material material)
	{
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (_dispersion < 0.0)
		{
			throw new ArgumentOutOfRangeException("Dispersion");
		}
	}
}
