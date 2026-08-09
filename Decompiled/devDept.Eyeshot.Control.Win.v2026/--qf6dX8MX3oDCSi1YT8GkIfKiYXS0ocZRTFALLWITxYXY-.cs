using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKiYXS0ocZRTFALLWITxYXY_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DzVC9FBdo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D[] _0023_003DzwBouG0w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqpOsddWbqwzI4Xv5sOvd5rvVf6_0024PoGMnUhfFmcHiYw4c_003D _0023_003Dzf4Pqh9s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqqSQMR5x0Ss3kUZAkPHTc7nI_0024hMM_0024DN9_00246GuPBlinnzY_003D _0023_003DzTFNDoh0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqjP_cCVqr6eDH37DmNYzUTp_0024MqRALMWP3i3ApelaNl5I_003D _0023_003DzraVZG9g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzRoqMfFc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dz1SmHC4c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzLtLprGE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzmZWYhFQ_003D;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length => _0023_003DzVC9FBdo_003D.Length;

	public override long Position
	{
		get
		{
			return _0023_003DzVC9FBdo_003D.Position + (_0023_003DzLtLprGE_003D - _0023_003DzmZWYhFQ_003D);
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public _0023_003Dqf6dX8MX3oDCSi1YT8GkIfKiYXS0ocZRTFALLWITxYXY_003D(Stream _0023_003DzjYYAPCA_003D, _0023_003DqpOsddWbqwzI4Xv5sOvd5rvVf6_0024PoGMnUhfFmcHiYw4c_003D _0023_003DzVC9FBdo_003D = null, _0023_003DqqSQMR5x0Ss3kUZAkPHTc7nI_0024hMM_0024DN9_00246GuPBlinnzY_003D _0023_003DzwBouG0w_003D = null, bool _0023_003Dzf4Pqh9s_003D = false)
	{
		this._0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D;
		this._0023_003DzjYYAPCA_003D = _0023_003Dzf4Pqh9s_003D;
		_0023_003DzTFNDoh0_003D = _0023_003DzwBouG0w_003D;
		this._0023_003Dzf4Pqh9s_003D = _0023_003DzVC9FBdo_003D;
		if (this._0023_003Dzf4Pqh9s_003D == null)
		{
			this._0023_003Dzf4Pqh9s_003D = _0023_003DqpOsddWbqwzI4Xv5sOvd5rvVf6_0024PoGMnUhfFmcHiYw4c_003D._0023_003Dzc8C_0024nSdKlx1x99p_LJ3yvgFRXO6AFbeyoiqeOY8_003D();
		}
		if (this._0023_003Dzf4Pqh9s_003D._0023_003DzQBbymuT9PWnPNJWsvP_0024grpyBG6kx27Ru2z01hYQ_003D() == 0)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621527));
		}
		if (this._0023_003Dzf4Pqh9s_003D._0023_003Dz_wyLtNL_0PZD9YT2JKl_Q8P7RcQUCAdpgQ_003D_003D() == 0)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621527));
		}
		if (!this._0023_003DzVC9FBdo_003D.CanRead)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621542));
		}
		if (!this._0023_003DzVC9FBdo_003D.CanSeek)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621542));
		}
	}

	private void _0023_003DzyiCQW7wPq4OkcaoGFS562AbTu8ED()
	{
		if (!_0023_003DzRoqMfFc_003D)
		{
			_0023_003DzwBouG0w_003D = new _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D[_0023_003Dzf4Pqh9s_003D._0023_003DzQBbymuT9PWnPNJWsvP_0024grpyBG6kx27Ru2z01hYQ_003D()];
			for (int i = 0; i < _0023_003Dzf4Pqh9s_003D._0023_003DzQBbymuT9PWnPNJWsvP_0024grpyBG6kx27Ru2z01hYQ_003D(); i++)
			{
				_0023_003DzwBouG0w_003D[i] = new _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D();
			}
			if (_0023_003DzTFNDoh0_003D != null)
			{
				_0023_003DzraVZG9g_003D = _0023_003DzTFNDoh0_003D._0023_003DzhcsB8uYJgKYFxutimewKVER8n29I_0024PTTWWuRx54_003D(_0023_003Dzf4Pqh9s_003D);
			}
			_0023_003DzRoqMfFc_003D = true;
		}
	}

	protected override void Dispose(bool _0023_003DzjYYAPCA_003D)
	{
		try
		{
			if (_0023_003DzjYYAPCA_003D && !this._0023_003DzjYYAPCA_003D)
			{
				_0023_003DzVC9FBdo_003D.Close();
			}
		}
		finally
		{
			base.Dispose(_0023_003DzjYYAPCA_003D);
		}
	}

	public override void SetLength(long _0023_003DzjYYAPCA_003D)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		throw new NotSupportedException();
	}

	public override void Flush()
	{
	}

	private int _0023_003DzcqfyeEOOFNxp3UPq8_0024U4WVc_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		int num = _0023_003DzmZWYhFQ_003D - _0023_003DzLtLprGE_003D;
		if (num <= 0)
		{
			return 0;
		}
		if (num > _0023_003DzwBouG0w_003D)
		{
			num = _0023_003DzwBouG0w_003D;
		}
		Buffer.BlockCopy(_0023_003Dz1SmHC4c_003D, _0023_003DzLtLprGE_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, num);
		_0023_003DzLtLprGE_003D += num;
		return num;
	}

	private void _0023_003Dzvmfr3RHGXz6GScvdomAlpNs_003D(int _0023_003DzjYYAPCA_003D)
	{
		int num = (int)_0023_003DzVC9FBdo_003D.Position;
		if (num >= _0023_003DzVC9FBdo_003D.Length)
		{
			return;
		}
		int num2 = num + _0023_003DzjYYAPCA_003D;
		_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D[] array = _0023_003DzwBouG0w_003D;
		foreach (_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2 in array)
		{
			if (_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2._0023_003DzVC9FBdo_003D <= num && _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2._0023_003DzwBouG0w_003D >= num2)
			{
				_0023_003Dz1SmHC4c_003D = _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2._0023_003DzjYYAPCA_003D;
				_0023_003DzmZWYhFQ_003D = _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2._0023_003DzwBouG0w_003D - _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2._0023_003DzVC9FBdo_003D;
				_0023_003DzLtLprGE_003D = num - _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2._0023_003DzVC9FBdo_003D;
				_0023_003DzVC9FBdo_003D.Position = _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2._0023_003DzwBouG0w_003D;
				_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D2._0023_003Dzf4Pqh9s_003D = DateTime.UtcNow;
				return;
			}
		}
		int num3 = 0;
		DateTime dateTime = _0023_003DzwBouG0w_003D[0]._0023_003Dzf4Pqh9s_003D;
		for (int j = 1; j < _0023_003DzwBouG0w_003D.Length; j++)
		{
			if (_0023_003DzwBouG0w_003D[j]._0023_003Dzf4Pqh9s_003D < dateTime)
			{
				num3 = j;
			}
		}
		_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3 = _0023_003DzwBouG0w_003D[num3];
		if (_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003DzjYYAPCA_003D == null)
		{
			_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003DzjYYAPCA_003D = new byte[_0023_003Dzf4Pqh9s_003D._0023_003Dz7rfxjNYf7m131JcNrICTrScq29MR14Fry2juQyHOa0EA()];
		}
		int num4 = num;
		num = _0023_003Dz2A5VO5uhPU8c9dz_0024euo8CT6mRBsU(num);
		if (num < 0)
		{
			num = 0;
		}
		num2 = num + _0023_003Dzf4Pqh9s_003D._0023_003Dz7rfxjNYf7m131JcNrICTrScq29MR14Fry2juQyHOa0EA();
		if (_0023_003DzraVZG9g_003D == null || !_0023_003DzraVZG9g_003D._0023_003DzmzTNVLyI0U2UndontwPEFJQ_003D(num, ref _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3))
		{
			_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003DzVC9FBdo_003D = num;
			_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003Dzf4Pqh9s_003D = DateTime.UtcNow;
			_0023_003Dz1SmHC4c_003D = _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003DzjYYAPCA_003D;
			_0023_003DzVC9FBdo_003D.Position = num;
			_0023_003DzmZWYhFQ_003D = _0023_003DzVC9FBdo_003D.Read(_0023_003Dz1SmHC4c_003D, 0, num2 - num);
			_0023_003DzLtLprGE_003D = num4 - num;
			_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003DzwBouG0w_003D = num + _0023_003DzmZWYhFQ_003D;
			if (_0023_003DzraVZG9g_003D != null)
			{
				_0023_003DzraVZG9g_003D._0023_003DzkkivY4eGX2QrfvSjJPgZI5s_003D(_0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3);
			}
		}
		else
		{
			_0023_003Dz1SmHC4c_003D = _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003DzjYYAPCA_003D;
			_0023_003DzmZWYhFQ_003D = _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003DzwBouG0w_003D - num;
			_0023_003DzVC9FBdo_003D.Position = _0023_003DqYRqji0NHJc0joHMYUu2HS1vtS61q6dMPxoLK6xNCZ_g_003D3._0023_003DzwBouG0w_003D;
			_0023_003DzLtLprGE_003D = num4 - num;
		}
	}

	private int _0023_003Dz2A5VO5uhPU8c9dz_0024euo8CT6mRBsU(int _0023_003DzjYYAPCA_003D)
	{
		return _0023_003DzjYYAPCA_003D - _0023_003DzjYYAPCA_003D % _0023_003Dzf4Pqh9s_003D._0023_003Dz7rfxjNYf7m131JcNrICTrScq29MR14Fry2juQyHOa0EA();
	}

	public override int Read(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621561));
		}
		if (_0023_003DzVC9FBdo_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621326));
		}
		if (_0023_003DzwBouG0w_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621315));
		}
		if (_0023_003DzjYYAPCA_003D.Length - _0023_003DzVC9FBdo_003D < _0023_003DzwBouG0w_003D)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzVC9FBdo_003D;
		int num2 = _0023_003DzcqfyeEOOFNxp3UPq8_0024U4WVc_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
		if (num2 == _0023_003DzwBouG0w_003D)
		{
			return num2;
		}
		int num3 = num2;
		if (num2 > 0)
		{
			_0023_003DzwBouG0w_003D -= num2;
			_0023_003DzVC9FBdo_003D += num2;
		}
		_0023_003DzLtLprGE_003D = (_0023_003DzmZWYhFQ_003D = 0);
		_0023_003DzyiCQW7wPq4OkcaoGFS562AbTu8ED();
		if (_0023_003DzwBouG0w_003D >= _0023_003Dzf4Pqh9s_003D._0023_003Dz7rfxjNYf7m131JcNrICTrScq29MR14Fry2juQyHOa0EA())
		{
			if (_0023_003DzraVZG9g_003D == null)
			{
				return this._0023_003DzVC9FBdo_003D.Read(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D) + num3;
			}
			int num4 = (int)this._0023_003DzVC9FBdo_003D.Position - num3;
			if (_0023_003DzraVZG9g_003D._0023_003DzfzZCO0DNnwNq8trQbw_003D_003D(num4, _0023_003DzjYYAPCA_003D, num, _0023_003DzwBouG0w_003D + num3, out var num5))
			{
				this._0023_003DzVC9FBdo_003D.Seek(num5 - num3, SeekOrigin.Current);
				return num5;
			}
			num5 = this._0023_003DzVC9FBdo_003D.Read(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			if (num5 != 0)
			{
				_0023_003DzraVZG9g_003D._0023_003Dz5OAr7bzcg6t5Jm_A8xmaIunmW706lTpT2nZ3uLo_003D(num4, _0023_003DzjYYAPCA_003D, num, num5 + num3, num5 < _0023_003DzwBouG0w_003D);
			}
			return num5 + num3;
		}
		_0023_003Dzvmfr3RHGXz6GScvdomAlpNs_003D(_0023_003DzwBouG0w_003D);
		num2 = _0023_003DzcqfyeEOOFNxp3UPq8_0024U4WVc_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
		return num2 + num3;
	}

	public override long Seek(long _0023_003DzjYYAPCA_003D, SeekOrigin _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzmZWYhFQ_003D - _0023_003DzLtLprGE_003D > 0 && _0023_003DzVC9FBdo_003D == SeekOrigin.Current)
		{
			_0023_003DzjYYAPCA_003D -= _0023_003DzmZWYhFQ_003D - _0023_003DzLtLprGE_003D;
		}
		long position = Position;
		long num = this._0023_003DzVC9FBdo_003D.Seek(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		_0023_003DzLtLprGE_003D = (int)(num - (position - _0023_003DzLtLprGE_003D));
		if (0 <= _0023_003DzLtLprGE_003D && _0023_003DzLtLprGE_003D < _0023_003DzmZWYhFQ_003D)
		{
			this._0023_003DzVC9FBdo_003D.Seek(_0023_003DzmZWYhFQ_003D - _0023_003DzLtLprGE_003D, SeekOrigin.Current);
		}
		else
		{
			_0023_003DzLtLprGE_003D = (_0023_003DzmZWYhFQ_003D = 0);
		}
		return num;
	}
}
