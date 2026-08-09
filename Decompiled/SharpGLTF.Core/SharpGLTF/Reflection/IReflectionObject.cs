using System.Collections.Generic;

namespace SharpGLTF.Reflection;

public interface IReflectionObject
{
	IEnumerable<FieldInfo> GetFields();

	bool TryGetField(string name, out FieldInfo value);
}
