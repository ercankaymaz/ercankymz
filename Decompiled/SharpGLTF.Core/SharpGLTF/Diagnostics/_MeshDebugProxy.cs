using System.Diagnostics;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Diagnostics;

internal sealed class _MeshDebugProxy
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Mesh _Value;

	public string Name => _Value.Name;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public MeshPrimitive[] Primitives => _Value.Primitives.ToArray();

	public _MeshDebugProxy(Mesh value)
	{
		_Value = value;
	}
}
