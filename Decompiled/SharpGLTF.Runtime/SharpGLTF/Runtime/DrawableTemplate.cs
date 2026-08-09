using System.Diagnostics;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

internal abstract class DrawableTemplate : IDrawableTemplate
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _NodeName;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _LogicalMeshIndex;

	public string NodeName => _NodeName;

	public int LogicalMeshIndex => _LogicalMeshIndex;

	protected DrawableTemplate(Node node)
	{
		_LogicalMeshIndex = node.Mesh.LogicalIndex;
		_NodeName = node.Name;
	}

	public abstract IGeometryTransform CreateGeometryTransform();

	public abstract void UpdateGeometryTransform(IGeometryTransform geoxform, ArmatureInstance armature);
}
