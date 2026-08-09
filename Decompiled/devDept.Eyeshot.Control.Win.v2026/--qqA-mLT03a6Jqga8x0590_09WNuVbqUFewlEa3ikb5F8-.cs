using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003DqqA_0024mLT03a6Jqga8x0590_09WNuVbqUFewlEa3ikb5F8_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzVC9FBdo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzwBouG0w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003Dzf4Pqh9s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DzTFNDoh0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzraVZG9g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzRoqMfFc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz1SmHC4c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLtLprGE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzmZWYhFQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzt2pW2yo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzJ6W8874_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzmjtwFUo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzDp118Pw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzbAh_0024yNw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzivyja_00240_003D;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length
	{
		get
		{
			_0023_003Dzd89KrGLu87L2NKURmvN0Wz0mqaK8TKKdV6L8_s4_003D();
			return _0023_003DzjYYAPCA_003D;
		}
	}

	public override long Position
	{
		get
		{
			return _0023_003DzraVZG9g_003D * _0023_003DzbAh_0024yNw_003D + _0023_003DzDp118Pw_003D;
		}
		set
		{
			int num = (int)value / _0023_003DzbAh_0024yNw_003D;
			_0023_003DzDp118Pw_003D = (int)value % _0023_003DzbAh_0024yNw_003D;
			if (_0023_003DzraVZG9g_003D != num)
			{
				_0023_003DzraVZG9g_003D = num;
				_0023_003DzLtLprGE_003D = true;
				_0023_003DzRoqMfFc_003D = false;
			}
		}
	}

	public _0023_003DqqA_0024mLT03a6Jqga8x0590_09WNuVbqUFewlEa3ikb5F8_003D(Stream _0023_003DzjYYAPCA_003D, _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621542));
		}
		if (_0023_003DzVC9FBdo_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348618903));
		}
		_0023_003Dzf4Pqh9s_003D = _0023_003DzjYYAPCA_003D;
		_0023_003DzTFNDoh0_003D = _0023_003DzVC9FBdo_003D;
		if (_0023_003Dzf4Pqh9s_003D.Length < 4)
		{
			throw new InvalidOperationException();
		}
		_0023_003DztY1L0L2Dlx_1O_Sn0WQ0BIaxFexlL3i9e3iyeIk_003D();
	}

	private void _0023_003DztY1L0L2Dlx_1O_Sn0WQ0BIaxFexlL3i9e3iyeIk_003D()
	{
		_0023_003Dzt2pW2yo_003D = _0023_003DzTFNDoh0_003D._0023_003Dz6yWKn5RWb7TX7YfTPmAuYkQGbBUVyb7IKq9weDETUYolhIQUjGNVzu8Rgtk0LZEsFpyFDs_3SQhqAnPpIg_003D_003D();
		_0023_003DzmZWYhFQ_003D = new byte[_0023_003Dzt2pW2yo_003D];
		_0023_003DzbAh_0024yNw_003D = _0023_003DzTFNDoh0_003D._0023_003DzxmlC_Zo_oW81BAJ8I65ymN9fvteApvKrAhr_ENOUJQ_eQprME4lFPgaCIgbDK_01_sDs3v8_003D();
		_0023_003DzJ6W8874_003D = new byte[_0023_003DzbAh_0024yNw_003D];
	}

	public override long Seek(long _0023_003DzjYYAPCA_003D, SeekOrigin _0023_003DzVC9FBdo_003D)
	{
		switch (_0023_003DzVC9FBdo_003D)
		{
		case SeekOrigin.Begin:
			Position = _0023_003DzjYYAPCA_003D;
			break;
		case SeekOrigin.Current:
			Position += _0023_003DzjYYAPCA_003D;
			break;
		case SeekOrigin.End:
			Position = Length + _0023_003DzjYYAPCA_003D;
			break;
		}
		return Position;
	}

	public override void SetLength(long _0023_003DzjYYAPCA_003D)
	{
		throw new NotSupportedException();
	}

	public override int Read(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzVC9FBdo_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348618919));
		}
		if (_0023_003DzwBouG0w_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348618940));
		}
		if (_0023_003DzjYYAPCA_003D.Length - _0023_003DzVC9FBdo_003D < _0023_003DzwBouG0w_003D)
		{
			throw new ArgumentException();
		}
		if (_0023_003DzwBouG0w_003D == 0)
		{
			return 0;
		}
		int num = _0023_003DzwBouG0w_003D;
		int num2 = _0023_003DzVC9FBdo_003D;
		if (_0023_003DzDp118Pw_003D < _0023_003DzbAh_0024yNw_003D)
		{
			_0023_003DzQvEHoBL8oBYcx_00248414VqA2znFZ1GqYpk0eOQD1c_003D();
			int num3 = _0023_003DzmjtwFUo_003D - _0023_003DzDp118Pw_003D;
			if (num3 > _0023_003DzwBouG0w_003D)
			{
				Buffer.BlockCopy(_0023_003DzJ6W8874_003D, _0023_003DzDp118Pw_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
				_0023_003DzDp118Pw_003D += _0023_003DzwBouG0w_003D;
				return _0023_003DzwBouG0w_003D;
			}
			Buffer.BlockCopy(_0023_003DzJ6W8874_003D, _0023_003DzDp118Pw_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, num3);
			_0023_003DzDp118Pw_003D = _0023_003DzmjtwFUo_003D;
			if (_0023_003Dz1SmHC4c_003D)
			{
				return num3;
			}
			num -= num3;
			num2 += num3;
		}
		if (_0023_003Dz1SmHC4c_003D)
		{
			return _0023_003DzwBouG0w_003D - num;
		}
		while (num > 0)
		{
			_0023_003DzBUohuB4iP6OxqEvhtimNJhW_8nIMPu_LiPyJioWuEW_00248();
			if (_0023_003Dz1SmHC4c_003D)
			{
				return _0023_003DzwBouG0w_003D - num;
			}
			int num4 = _0023_003DzmjtwFUo_003D;
			if (num >= num4)
			{
				Buffer.BlockCopy(_0023_003DzJ6W8874_003D, 0, _0023_003DzjYYAPCA_003D, num2, num4);
				num2 += num4;
				num -= num4;
				_0023_003DzDp118Pw_003D = num4;
				continue;
			}
			Buffer.BlockCopy(_0023_003DzJ6W8874_003D, 0, _0023_003DzjYYAPCA_003D, num2, num);
			_0023_003DzDp118Pw_003D = num;
			return _0023_003DzwBouG0w_003D;
		}
		return _0023_003DzwBouG0w_003D;
	}

	private void _0023_003DzQvEHoBL8oBYcx_00248414VqA2znFZ1GqYpk0eOQD1c_003D()
	{
		_0023_003Dzd89KrGLu87L2NKURmvN0Wz0mqaK8TKKdV6L8_s4_003D();
		if (!_0023_003DzRoqMfFc_003D)
		{
			_0023_003DzRoqMfFc_003D = true;
			_0023_003Dz1SmHC4c_003D = false;
			int num = _0023_003DzraVZG9g_003D;
			if (_0023_003DzLtLprGE_003D)
			{
				_0023_003Dzf4Pqh9s_003D.Position = 4 + num * _0023_003Dzt2pW2yo_003D;
				_0023_003DzLtLprGE_003D = false;
			}
			_0023_003DzhU7VXM9_0024qA5nodjO34TizFy0ozgv6r796w_003D_003D(num);
		}
	}

	private void _0023_003DzBUohuB4iP6OxqEvhtimNJhW_8nIMPu_LiPyJioWuEW_00248()
	{
		int num = _0023_003DzraVZG9g_003D + 1;
		if (_0023_003DzhU7VXM9_0024qA5nodjO34TizFy0ozgv6r796w_003D_003D(num))
		{
			_0023_003DzraVZG9g_003D = num;
			_0023_003DzDp118Pw_003D = 0;
		}
		_0023_003DzRoqMfFc_003D = true;
	}

	private bool _0023_003DzhU7VXM9_0024qA5nodjO34TizFy0ozgv6r796w_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		int num;
		for (int i = 0; i < _0023_003Dzt2pW2yo_003D; i += num)
		{
			num = _0023_003Dzf4Pqh9s_003D.Read(_0023_003DzmZWYhFQ_003D, i, _0023_003Dzt2pW2yo_003D - i);
			if (num == 0)
			{
				if (i != 0)
				{
					throw new InvalidOperationException();
				}
				_0023_003Dz1SmHC4c_003D = true;
				return false;
			}
		}
		_0023_003DzmjtwFUo_003D = _0023_003DzTFNDoh0_003D._0023_003Dz9htoK_3JkptM8kqGKCoLls0gCyl0YxEaqpdWRGC0cgW64QQ0i2FuHnA5ifidkO1VpyhTlQoeTNtHe8H3_00243_HfdI_003D(_0023_003DzmZWYhFQ_003D, 0, _0023_003Dzt2pW2yo_003D, _0023_003DzJ6W8874_003D, 0, null);
		if (_0023_003DzjYYAPCA_003D == _0023_003DzVC9FBdo_003D)
		{
			_0023_003DzmjtwFUo_003D = _0023_003DzwBouG0w_003D;
		}
		return true;
	}

	private void _0023_003Dzd89KrGLu87L2NKURmvN0Wz0mqaK8TKKdV6L8_s4_003D()
	{
		if (!_0023_003Dzivyja_00240_003D)
		{
			if (_0023_003Dzf4Pqh9s_003D.Position != 0L)
			{
				_0023_003Dzf4Pqh9s_003D.Position = 0L;
				_0023_003DzLtLprGE_003D = true;
			}
			_0023_003DzjYYAPCA_003D = _0023_003DzCZRtlADe0u82I5w2tgIf4aY_003D(_0023_003Dzf4Pqh9s_003D)._0023_003DzjYYAPCA_003D;
			_0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D / _0023_003DzbAh_0024yNw_003D;
			_0023_003DzwBouG0w_003D = _0023_003DzjYYAPCA_003D % _0023_003DzbAh_0024yNw_003D;
			_0023_003Dzivyja_00240_003D = true;
		}
	}

	private static _0023_003Dqi4iXOdMglrsSAbutWk0n_0b8ZttXxt8KHke2y8hVukM_003D _0023_003DzCZRtlADe0u82I5w2tgIf4aY_003D(Stream _0023_003DzjYYAPCA_003D)
	{
		_0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D _0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D2 = new _0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D(_0023_003DzjYYAPCA_003D, 0);
		try
		{
			_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D2 = new _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D(_0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D2);
			try
			{
				return new _0023_003Dqi4iXOdMglrsSAbutWk0n_0b8ZttXxt8KHke2y8hVukM_003D(_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D2._0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D());
			}
			finally
			{
				((IDisposable)_0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D2).Dispose();
			}
		}
		finally
		{
			((IDisposable)_0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D2).Dispose();
		}
	}

	public override void Flush()
	{
	}

	public override void Write(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		throw new NotSupportedException();
	}
}
