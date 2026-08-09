using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("Vertex {_VertexIndex} Tangents deltas")]
internal readonly struct _MorphTargetTexCoordSlice(IReadOnlyList<_MorphTargetDecoder> ggg, int idx, int set) : IReadOnlyList<Vector2>, IEnumerable<Vector2>, IEnumerable, IReadOnlyCollection<Vector2>
{
	private readonly IReadOnlyList<_MorphTargetDecoder> _Geometries = ggg;

	private readonly int _VertexIndex = idx;

	private readonly int _TexCoordSet = set;

	public Vector2 this[int index] => _Geometries[index].GetTextureCoordDelta(_VertexIndex, _TexCoordSet);

	public int Count => _Geometries.Count;

	public IEnumerator<Vector2> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
