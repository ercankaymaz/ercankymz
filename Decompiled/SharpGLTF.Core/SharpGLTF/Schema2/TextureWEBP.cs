using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal class TextureWEBP : ExtraProperties
{
	public new const string SCHEMANAME = "EXT_texture_webp";

	private int? _source;

	private readonly Texture _Parent;

	public Image Image
	{
		get
		{
			if (!_source.HasValue)
			{
				return null;
			}
			return _Parent.LogicalParent.LogicalImages[_source.Value];
		}
		set
		{
			if (value != null)
			{
				Guard.MustShareLogicalParent(_Parent, value, "value");
				Guard.IsTrue(value.Content.IsWebp, "value");
			}
			_source = value?.LogicalIndex;
		}
	}

	protected override string GetSchemaName()
	{
		return "EXT_texture_webp";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "source";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "source")
		{
			value = FieldInfo.From("source", this, (TextureWEBP instance) => instance._source);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "source", _source);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "source")
		{
			JsonSerializable.DeserializePropertyValue<TextureWEBP, int?>(ref reader, this, out _source);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal TextureWEBP(Texture parent)
	{
		_Parent = parent;
	}
}
