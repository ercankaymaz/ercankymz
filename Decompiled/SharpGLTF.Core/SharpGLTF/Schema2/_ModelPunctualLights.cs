using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal class _ModelPunctualLights : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_lights_punctual";

	private const int _lightsMinItems = 1;

	private ChildrenList<PunctualLight, ModelRoot> _lights;

	public IReadOnlyList<PunctualLight> Lights => _lights;

	protected override string GetSchemaName()
	{
		return "KHR_lights_punctual";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "lights";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "lights")
		{
			value = FieldInfo.From("lights", this, (_ModelPunctualLights instance) => instance._lights);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "lights", _lights, 1);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "lights")
		{
			JsonSerializable.DeserializePropertyList(ref reader, this, _lights);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal _ModelPunctualLights(ModelRoot root)
	{
		_lights = new ChildrenList<PunctualLight, ModelRoot>(root);
	}

	public PunctualLight CreateLight(string name, PunctualLightType ltype)
	{
		PunctualLight punctualLight = new PunctualLight(ltype);
		punctualLight.Name = name;
		_lights.Add(punctualLight);
		return punctualLight;
	}
}
