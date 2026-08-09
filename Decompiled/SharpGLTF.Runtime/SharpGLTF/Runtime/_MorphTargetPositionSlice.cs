using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("Vertex {_VertexIndex} Positions deltas")]
internal readonly struct _MorphTargetPositionSlice(IReadOnlyList<_MorphTargetDecoder> ggg, int idx) : IReadOnlyList<Vector3>, IEnumerable<Vector3>, IEnumerable, IReadOnlyCollection<Vector3>
{
	private readonly IReadOnlyList<_MorphTargetDecoder> _Geometries = ggg;

	private readonly int _VertexIndex = idx;

	public Vector3 this[int index] => _Geometries[index].GetPositionDelta(_VertexIndex);

	public int Count => _Geometries.Count;

	public IEnumerator<Vector3> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
