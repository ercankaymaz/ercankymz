using SharpGLTF.IO;

namespace SharpGLTF.Validation;

public class DataException : ModelException
{
	internal DataException(JsonSerializable target, string message)
		: base(target, message)
	{
	}
}
