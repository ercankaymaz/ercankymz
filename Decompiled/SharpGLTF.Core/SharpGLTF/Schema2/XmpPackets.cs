using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
public class XmpPackets : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_xmp_json_ld";

	private const int _packetsMinItems = 1;

	private List<JsonNode> _packets;

	public IReadOnlyList<JsonNode> JsonPackets => _packets;

	internal XmpPackets(ModelRoot root)
	{
		_packets = new List<JsonNode>();
	}

	public int AddPacket(JsonNode packet)
	{
		if (_packets.Contains(packet))
		{
			throw new ArgumentException("Already exists", "packet");
		}
		_packets.Add(packet);
		return _packets.Count - 1;
	}

	protected override string GetSchemaName()
	{
		return "KHR_xmp_json_ld";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "packets";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "packets")
		{
			value = FieldInfo.From("packets", this, (XmpPackets instance) => instance._packets);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "packets", _packets, 1);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "packets")
		{
			JsonSerializable.DeserializePropertyList(ref reader, this, _packets);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}
}
