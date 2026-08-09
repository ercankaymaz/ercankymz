using System.Collections.Generic;
using System.Diagnostics;

namespace devDept.Graphics;

public class vertexBufferData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private primitiveType _0023_003Dzn7V_0024_0024gh_0024Ur21iIeAHQ_003D_003D;

	public List<int> nElementsPerChunk = new List<int>();

	public int startVertex;

	public int startIndex = -1;

	public int firstChunk;

	public int lastChunk;

	internal primitiveType _0023_003DzDX_IlROkgDgt()
	{
		return _0023_003Dzn7V_0024_0024gh_0024Ur21iIeAHQ_003D_003D;
	}

	internal void _0023_003Dz_002475wn_0024QGlEFt(primitiveType _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzn7V_0024_0024gh_0024Ur21iIeAHQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}
}
