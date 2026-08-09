using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using SharpDX;
using SharpDX.D3DCompiler;

internal sealed class _0023_003Dzt7C3u11ZuFOuRROEQqbCI78_003D : Include, ICallbackable, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IDisposable _0023_003DzUQwZjiLSBkFiKaVSuw_003D_003D;

	public IDisposable Shadow
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzUQwZjiLSBkFiKaVSuw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzUQwZjiLSBkFiKaVSuw_003D_003D = value;
		}
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}

	public Stream Open(IncludeType _0023_003DzhklmJFQ_003D, string _0023_003Dz83HaHYE_003D, Stream _0023_003DzREtxfr9O_0024eX0)
	{
		return new FileStream(_0023_003Dz83HaHYE_003D, FileMode.Open);
	}

	public void Close(Stream _0023_003DzRKBNJQQ_003D)
	{
		_0023_003DzRKBNJQQ_003D.Close();
	}
}
