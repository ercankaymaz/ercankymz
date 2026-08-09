namespace SharpGLTF.Reflection;

public interface IReflectionArray : IReflectionObject
{
	int Count { get; }

	FieldInfo GetField(int index);
}
