using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("Vertex {_VertexIndex} Tangents deltas")]
internal readonly struct _MorphTargetColorSlice(IReadOnlyList<_MorphTargetDecoder> ggg, int idx, int set) : IReadOnlyList<Vector4>, IEnumerable<Vector4>, IEnumerable, IReadOnlyCollection<Vector4>
{
	private readonly IReadOnlyList<_MorphTargetDecoder> _Geometries = ggg;

	private readonly int _VertexIndex = idx;

	private readonly int _ColorSet = set;

	public Vector4 this[int index] => _Geometries[index].GetColorDelta(_VertexIndex, _ColorSet);

	public int Count => _Geometries.Count;

	public IEnumerator<Vector4> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
