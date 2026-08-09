using System.Diagnostics;

namespace devDept.Graphics;

public class OglEntityGraphicsData : EntityGraphicsData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal OGLEntityBuffer _0023_003DzrGVDsYRQZJCT;

	public OglEntityGraphicsData()
	{
	}

	public OglEntityGraphicsData(object parent)
		: base(parent)
	{
	}

	public override void Dispose()
	{
		if (_0023_003DzrGVDsYRQZJCT != null)
		{
			_0023_003DzrGVDsYRQZJCT.Dispose();
			_0023_003DzrGVDsYRQZJCT = null;
		}
	}

	public override void DrawBuffer(RenderContextBase context, int part)
	{
		if (_0023_003DzrGVDsYRQZJCT == null)
		{
			((RenderContext)context).ThrowEntityNotCompiledError(this);
		}
		_0023_003DzrGVDsYRQZJCT.Draw(context, part);
	}

	public override void DrawBuffer(RenderContextBase context, bool nextPart)
	{
		if (_0023_003DzrGVDsYRQZJCT == null)
		{
			((RenderContext)context).ThrowEntityNotCompiledError(this);
		}
		_0023_003DzrGVDsYRQZJCT.Draw(context, nextPart);
	}

	public override bool IsValid()
	{
		return _0023_003DzrGVDsYRQZJCT != null;
	}

	public override bool IsVbo()
	{
		return IsValid();
	}
}
