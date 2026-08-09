using SharpGLTF.IO;

namespace SharpGLTF.Validation;

public class SemanticException : ModelException
{
	internal SemanticException(JsonSerializable target, string message)
		: base(target, message)
	{
	}
}
