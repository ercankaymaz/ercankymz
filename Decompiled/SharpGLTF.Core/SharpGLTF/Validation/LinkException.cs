using SharpGLTF.IO;

namespace SharpGLTF.Validation;

public class LinkException : ModelException
{
	internal LinkException(JsonSerializable target, string message)
		: base(target, message)
	{
	}
}
