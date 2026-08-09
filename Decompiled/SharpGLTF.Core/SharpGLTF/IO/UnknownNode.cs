using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SharpGLTF.IO;

[DebuggerDisplay("Unknown {_Name}")]
internal class UnknownNode : JsonSerializable
{
	private readonly string _Name;

	private readonly Dictionary<string, JsonNode> _Properties = new Dictionary<string, JsonNode>();

	public string Name => _Name;

	public IReadOnlyDictionary<string, JsonNode> Properties => _Properties;

	public UnknownNode(string name)
	{
		_Name = name;
	}

	protected override void DeserializeProperty(string property, ref Utf8JsonReader reader)
	{
		reader.Read();
		_Properties[property] = JsonNode.Parse(ref reader);
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		foreach (KeyValuePair<string, JsonNode> property in _Properties)
		{
			JsonSerializable.SerializeProperty(writer, property.Key, property.Value);
		}
	}
}
