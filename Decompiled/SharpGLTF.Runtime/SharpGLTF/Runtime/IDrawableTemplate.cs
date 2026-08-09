namespace SharpGLTF.Runtime;

public interface IDrawableTemplate
{
	string NodeName { get; }

	int LogicalMeshIndex { get; }
}
