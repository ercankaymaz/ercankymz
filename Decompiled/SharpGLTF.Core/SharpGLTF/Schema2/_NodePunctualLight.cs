using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal class _NodePunctualLight : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_lights_punctual";

	private int _light;

	public int LightIndex
	{
		get
		{
			return _light;
		}
		set
		{
			_light = value;
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_lights_punctual";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "light";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "light")
		{
			value = FieldInfo.From("light", this, (_NodePunctualLight instance) => instance._light);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "light", _light);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "light")
		{
			JsonSerializable.DeserializePropertyValue<_NodePunctualLight, int>(ref reader, this, out _light);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal _NodePunctualLight(Node node)
	{
	}
}
