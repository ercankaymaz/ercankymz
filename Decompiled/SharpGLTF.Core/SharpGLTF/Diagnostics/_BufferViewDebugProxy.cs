using System.Diagnostics;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Diagnostics;

internal sealed class _BufferViewDebugProxy
{
	private readonly BufferView _Value;

	public int LogicalIndex => _Value.LogicalIndex;

	public int ByteStride => _Value.ByteStride;

	public int ByteLength => _Value.Content.Count;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public Accessor[] Accessors => _Value.FindAccessors().ToArray();

	public _BufferViewDebugProxy(BufferView value)
	{
		_Value = value;
	}
}
