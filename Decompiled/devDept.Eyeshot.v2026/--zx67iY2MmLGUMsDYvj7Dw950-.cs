using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal sealed class _0023_003Dzx67iY2MmLGUMsDYvj7Dw950_003D
{
	public _0023_003DzLuRDo0FsrOarlgd02g_003D_003D _0023_003Dz16WKMO4_003D = (_0023_003DzLuRDo0FsrOarlgd02g_003D_003D)1;

	public byte[] _0023_003Dzu1KFZHw_003D = new byte[7];

	public ulong _0023_003DzLfRs8jNjp3Mp;

	public ulong _0023_003DzdJHlW3fBTsSu;

	public ulong _0023_003DztbGLKaiJc2jY;

	public void _0023_003DzsYIAz_s_003D(ulong _0023_003DzbhZDRvHP20_0024y)
	{
		if (_0023_003Dz16WKMO4_003D != (_0023_003DzLuRDo0FsrOarlgd02g_003D_003D)1)
		{
			throw new Exception();
		}
		for (int i = 0; i < _0023_003Dzu1KFZHw_003D.Length; i++)
		{
			if (_0023_003Dzu1KFZHw_003D[i] != 0)
			{
				throw new Exception();
			}
		}
		if ((_0023_003DzLfRs8jNjp3Mp & 3) != 0L)
		{
			throw new Exception();
		}
		if (_0023_003DzbhZDRvHP20_0024y != 0 && _0023_003DzLfRs8jNjp3Mp >= _0023_003DzbhZDRvHP20_0024y)
		{
			throw new Exception();
		}
		if (_0023_003DzbhZDRvHP20_0024y != 0 && _0023_003DztbGLKaiJc2jY >= _0023_003DzbhZDRvHP20_0024y)
		{
			throw new Exception();
		}
	}
}
