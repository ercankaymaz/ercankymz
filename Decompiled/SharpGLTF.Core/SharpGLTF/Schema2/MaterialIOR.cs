using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialIOR : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_ior";

	private const double _iorDefault = 1.5;

	private double? _ior = 1.5;

	public static float DefaultIndexOfRefraction => 1.5f;

	public float IndexOfRefraction
	{
		get
		{
			return (float)(_ior ?? 1.5);
		}
		set
		{
			_ior = _Schema2Extensions.AsNullable(value, 1.5);
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_materials_ior";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "ior";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "ior")
		{
			value = FieldInfo.From("ior", this, (MaterialIOR instance) => instance._ior ?? 1.5);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "ior", _ior, 1.5);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "ior")
		{
			JsonSerializable.DeserializePropertyValue<MaterialIOR, double?>(ref reader, this, out _ior);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal MaterialIOR(Material material)
	{
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (_ior == 0.0 || !(_ior < 1.0))
		{
			return;
		}
		throw new ArgumentOutOfRangeException("IndexOfRefraction");
	}
}
