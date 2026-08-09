using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal class TextureKTX2 : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_texture_basisu";

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
				Guard.IsTrue(value.Content.IsKtx2, "value");
			}
			_source = value?.LogicalIndex;
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_texture_basisu";
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
			value = FieldInfo.From("source", this, (TextureKTX2 instance) => instance._source);
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
			JsonSerializable.DeserializePropertyValue<TextureKTX2, int?>(ref reader, this, out _source);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}

	internal TextureKTX2(Texture parent)
	{
		_Parent = parent;
	}
}
