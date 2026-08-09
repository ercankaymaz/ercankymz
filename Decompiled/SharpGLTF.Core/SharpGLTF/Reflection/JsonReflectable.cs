using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using SharpGLTF.IO;

namespace SharpGLTF.Reflection;

public abstract class JsonReflectable : JsonSerializable, IReflectionObject
{
	public const string SCHEMANAME = "Object";

	protected override string GetSchemaName()
	{
		return "Object";
	}

	protected virtual IEnumerable<string> ReflectFieldsNames()
	{
		return Enumerable.Empty<string>();
	}

	protected virtual bool TryReflectField(string name, out FieldInfo value)
	{
		value = default(FieldInfo);
		return false;
	}

	IEnumerable<FieldInfo> IReflectionObject.GetFields()
	{
		foreach (string item in ReflectFieldsNames())
		{
			if (TryReflectField(item, out var value))
			{
				yield return value;
			}
		}
	}

	bool IReflectionObject.TryGetField(string name, out FieldInfo value)
	{
		return TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		reader.Skip();
	}
}
