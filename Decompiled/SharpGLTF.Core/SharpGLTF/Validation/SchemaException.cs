using System.Text.Json;
using SharpGLTF.IO;

namespace SharpGLTF.Validation;

public class SchemaException : ModelException
{
	internal SchemaException(JsonSerializable target, string message)
		: base(target, message)
	{
	}

	internal SchemaException(JsonSerializable target, JsonException rex)
		: base(target, rex)
	{
	}
}
