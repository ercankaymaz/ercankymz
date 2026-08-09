using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Graphics;

public abstract class GraphicsEnvironmentParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_0024u_FKu8iYpdfeDjMXmJXYo8_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RenderContextBase _0023_003DzaFJdwkah3EUD;

	public bool Direct3D => RenderContext.IsDirect3D;

	public int MaxPatternRepetitions
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzLcpV1jsZxM6yrbTXv4iw8j7dPQDoGBPftA_003D_003D = value;
		}
	}

	public bool CompileWires
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_0024u_FKu8iYpdfeDjMXmJXYo8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_0024u_FKu8iYpdfeDjMXmJXYo8_003D = value;
		}
	}

	public RenderContextBase RenderContext
	{
		get
		{
			return _0023_003DzaFJdwkah3EUD;
		}
		set
		{
			_0023_003DzaFJdwkah3EUD = value;
		}
	}

	protected GraphicsEnvironmentParams()
	{
	}

	protected GraphicsEnvironmentParams(RenderContextBase renderContext, int maxPatternRepetitions, bool compileWires)
	{
		MaxPatternRepetitions = maxPatternRepetitions;
		RenderContext = renderContext;
		CompileWires = compileWires;
	}
}
