using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
public class XmpPacketReference : ExtraProperties
{
	private ExtraProperties _Owner;

	public new const string SCHEMANAME = "KHR_xmp_json_ld";

	private int _packet;

	public int PacketLogicalIndex => _packet;

	public JsonNode JsonPacket => _GetPackets()?.JsonPackets[_packet];

	internal XmpPacketReference(ExtraProperties owner)
	{
		_Owner = owner;
	}

	private ModelRoot _FindRoot()
	{
		if (_Owner is LogicalChildOfRoot logicalChildOfRoot)
		{
			return logicalChildOfRoot.LogicalParent;
		}
		return null;
	}

	private XmpPackets _GetPackets()
	{
		return _FindRoot()?.GetExtension<XmpPackets>();
	}

	public void SetPacket(int logicalIndex)
	{
		if (logicalIndex < 0)
		{
			throw new ArgumentOutOfRangeException("logicalIndex");
		}
		XmpPackets xmpPackets = _GetPackets();
		if (xmpPackets != null && logicalIndex >= xmpPackets.JsonPackets.Count)
		{
			throw new ArgumentOutOfRangeException("logicalIndex");
		}
		_packet = logicalIndex;
	}

	protected override string GetSchemaName()
	{
		return "KHR_xmp_json_ld";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "packet";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		if (name == "packet")
		{
			value = FieldInfo.From("packet", this, (XmpPacketReference instance) => instance._packet);
			return true;
		}
		return base.TryReflectField(name, out value);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "packet", _packet);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		if (jsonPropertyName == "packet")
		{
			JsonSerializable.DeserializePropertyValue<XmpPacketReference, int>(ref reader, this, out _packet);
		}
		else
		{
			base.DeserializeProperty(jsonPropertyName, ref reader);
		}
	}
}
