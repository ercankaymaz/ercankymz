using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003DqWrIzG7Np3JBvOzzB_00244Wig9ib5qxSFrXs8C583ay5yBE_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003Dz5rQzobg_003D;

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

	public _0023_003DqWrIzG7Np3JBvOzzB_00244Wig9ib5qxSFrXs8C583ay5yBE_003D(Stream _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dz9cfRvRj2OalwpuKf_0024Y75IZM4kSD1WbpDxg_003D_003D(_0023_003DziDLVpbY_003D);
		this._0023_003DziDLVpbY_003D = _0023_003Dz5rQzobg_003D;
	}

	public Stream ef02GHck4PnvdaId1ow17zigMMkYD()
	{
		return _0023_003Dz5rQzobg_003D;
	}

	private void _0023_003Dz9cfRvRj2OalwpuKf_0024Y75IZM4kSD1WbpDxg_003D_003D(Stream _0023_003DziDLVpbY_003D)
	{
		_0023_003Dz5rQzobg_003D = _0023_003DziDLVpbY_003D;
	}

	public override void Flush()
	{
		ef02GHck4PnvdaId1ow17zigMMkYD().Flush();
	}

	private byte _0023_003DzaRS0dopIVXGp8m1JzAs61AuC61xTJEVVsKRd92I_003D(byte _0023_003DziDLVpbY_003D, long _0023_003Dz5rQzobg_003D)
	{
		byte b = (byte)((uint)this._0023_003DziDLVpbY_003D | _0023_003Dz5rQzobg_003D);
		return (byte)(_0023_003DziDLVpbY_003D ^ b);
	}

	public override void Write(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		byte[] array = new byte[_0023_003DzAvn2b38_003D];
		Buffer.BlockCopy(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, array, 0, _0023_003DzAvn2b38_003D);
		long position = Position;
		for (int i = 0; i < _0023_003DzAvn2b38_003D; i++)
		{
			array[i] = _0023_003DzaRS0dopIVXGp8m1JzAs61AuC61xTJEVVsKRd92I_003D(array[i], position + i);
		}
		ef02GHck4PnvdaId1ow17zigMMkYD().Write(array, 0, _0023_003DzAvn2b38_003D);
	}

	public override int Read(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		long position = Position;
		byte[] array = new byte[_0023_003DzAvn2b38_003D];
		int num = ef02GHck4PnvdaId1ow17zigMMkYD().Read(array, 0, _0023_003DzAvn2b38_003D);
		for (int i = 0; i < num; i++)
		{
			_0023_003DziDLVpbY_003D[i + _0023_003Dz5rQzobg_003D] = _0023_003DzaRS0dopIVXGp8m1JzAs61AuC61xTJEVVsKRd92I_003D(array[i], position + i);
		}
		return num;
	}

	public override long Seek(long _0023_003DziDLVpbY_003D, SeekOrigin _0023_003Dz5rQzobg_003D)
	{
		return ef02GHck4PnvdaId1ow17zigMMkYD().Seek(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D);
	}

	public override void SetLength(long _0023_003DziDLVpbY_003D)
	{
		ef02GHck4PnvdaId1ow17zigMMkYD().SetLength(_0023_003DziDLVpbY_003D);
	}
}
