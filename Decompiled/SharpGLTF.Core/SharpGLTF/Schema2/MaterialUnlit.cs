using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class MaterialUnlit : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_materials_unlit";

	protected override string GetSchemaName()
	{
		return "KHR_materials_unlit";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		base.DeserializeProperty(jsonPropertyName, ref reader);
	}

	internal MaterialUnlit(Material material)
	{
	}
}
