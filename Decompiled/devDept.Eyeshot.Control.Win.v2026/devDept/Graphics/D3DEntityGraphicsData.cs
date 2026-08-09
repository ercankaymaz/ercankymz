using System.Diagnostics;

namespace devDept.Graphics;

public class D3DEntityGraphicsData : EntityGraphicsData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003Dz8EMUkmWmWaEywcTB_0024x5vS1jOPxbU _0023_003DzyO_593HDldkn;

	public D3DEntityGraphicsData()
	{
	}

	public D3DEntityGraphicsData(object parent)
		: base(parent)
	{
	}

	public override void Dispose()
	{
		if (_0023_003DzyO_593HDldkn != null)
		{
			_0023_003DzyO_593HDldkn.Dispose();
			_0023_003DzyO_593HDldkn = null;
		}
	}

	public override void DrawBuffer(RenderContextBase context, int part)
	{
		if (_0023_003DzyO_593HDldkn == null)
		{
			((RenderContext)context).ThrowEntityNotCompiledError(this);
		}
		_0023_003DzyO_593HDldkn._0023_003Dz99kJFjE_003D(context, part);
	}

	public override void DrawBuffer(RenderContextBase context, bool nextPart)
	{
		if (_0023_003DzyO_593HDldkn == null)
		{
			((RenderContext)context).ThrowEntityNotCompiledError(this);
		}
		_0023_003DzyO_593HDldkn._0023_003Dz99kJFjE_003D(context, nextPart);
	}

	public override bool IsValid()
	{
		return _0023_003DzyO_593HDldkn != null;
	}

	public override bool IsVbo()
	{
		return IsValid();
	}
}
