using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003DqrXg5vZzBo2JalZ5m4YWWIuAYrsGBipOm0OBCKxd_0024T2Q_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DzVC9FBdo_003D;

	public override bool CanRead => ef02GHck4PnvdaId1ow17zigMMkYD().CanRead;

	public override bool CanSeek => ef02GHck4PnvdaId1ow17zigMMkYD().CanSeek;

	public override bool CanWrite => ef02GHck4PnvdaId1ow17zigMMkYD().CanWrite;

	public override long Length => ef02GHck4PnvdaId1ow17zigMMkYD().Length;

	public override long Position
	{
		get
		{
			return ef02GHck4PnvdaId1ow17zigMMkYD().Position;
		}
		set
		{
			ef02GHck4PnvdaId1ow17zigMMkYD().Position = value;
		}
	}

	public _0023_003DqrXg5vZzBo2JalZ5m4YWWIuAYrsGBipOm0OBCKxd_0024T2Q_003D(Stream _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		_0023_003DzSpL_Gd49F0Epkw5zaYjpXnXzXMn34GlU_g_003D_003D(_0023_003DzjYYAPCA_003D);
		this._0023_003DzjYYAPCA_003D = _0023_003DzVC9FBdo_003D;
	}

	public Stream ef02GHck4PnvdaId1ow17zigMMkYD()
	{
		return _0023_003DzVC9FBdo_003D;
	}

	private void _0023_003DzSpL_Gd49F0Epkw5zaYjpXnXzXMn34GlU_g_003D_003D(Stream _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D;
	}

	public override void Flush()
	{
		ef02GHck4PnvdaId1ow17zigMMkYD().Flush();
	}

	private byte _0023_003Dz_0024S9lOi1NtxbkLFLjxZX6_0024pORKxqQMsRUDvQlYqg_003D(byte _0023_003DzjYYAPCA_003D, long _0023_003DzVC9FBdo_003D)
	{
		byte b = (byte)((uint)this._0023_003DzjYYAPCA_003D | _0023_003DzVC9FBdo_003D);
		return (byte)(_0023_003DzjYYAPCA_003D ^ b);
	}

	public override void Write(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		byte[] array = new byte[_0023_003DzwBouG0w_003D];
		Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, array, 0, _0023_003DzwBouG0w_003D);
		long position = Position;
		for (int i = 0; i < _0023_003DzwBouG0w_003D; i++)
		{
			array[i] = _0023_003Dz_0024S9lOi1NtxbkLFLjxZX6_0024pORKxqQMsRUDvQlYqg_003D(array[i], position + i);
		}
		ef02GHck4PnvdaId1ow17zigMMkYD().Write(array, 0, _0023_003DzwBouG0w_003D);
	}

	public override int Read(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		long position = Position;
		byte[] array = new byte[_0023_003DzwBouG0w_003D];
		int num = ef02GHck4PnvdaId1ow17zigMMkYD().Read(array, 0, _0023_003DzwBouG0w_003D);
		for (int i = 0; i < num; i++)
		{
			_0023_003DzjYYAPCA_003D[i + _0023_003DzVC9FBdo_003D] = _0023_003Dz_0024S9lOi1NtxbkLFLjxZX6_0024pORKxqQMsRUDvQlYqg_003D(array[i], position + i);
		}
		return num;
	}

	public override long Seek(long _0023_003DzjYYAPCA_003D, SeekOrigin _0023_003DzVC9FBdo_003D)
	{
		return ef02GHck4PnvdaId1ow17zigMMkYD().Seek(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
	}

	public override void SetLength(long _0023_003DzjYYAPCA_003D)
	{
		ef02GHck4PnvdaId1ow17zigMMkYD().SetLength(_0023_003DzjYYAPCA_003D);
	}
}
