using System;
using System.Runtime.InteropServices;

internal sealed class _0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D
{
	public byte _0023_003DzNaZfx10_003D = 2;

	public byte _0023_003Dzu1KFZHw_003D;

	public ushort _0023_003DzfMOL2E_0024F0iBbZ3RI8w_003D_003D;

	public void _0023_003DzsYIAz_s_003D(uint _0023_003Dz2Y42KbdAnxTm)
	{
		if (_0023_003DzNaZfx10_003D != 2)
		{
			throw new Exception();
		}
		int num = _0023_003DzfMOL2E_0024F0iBbZ3RI8w_003D_003D + 1;
		if (num < Marshal.SizeOf(this))
		{
			throw new Exception();
		}
		if (num % 4 != 0)
		{
			throw new Exception();
		}
		if (_0023_003Dz2Y42KbdAnxTm != 0 && num > _0023_003Dz2Y42KbdAnxTm)
		{
			throw new Exception();
		}
	}
}
