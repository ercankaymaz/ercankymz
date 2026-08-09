using System.Collections.Generic;
using System.Text.Json.Nodes;
using SharpGLTF.IO;

namespace SharpGLTF.Schema2;

public interface IExtraProperties
{
	IReadOnlyCollection<JsonSerializable> Extensions { get; }

	JsonNode Extras { get; set; }
}
