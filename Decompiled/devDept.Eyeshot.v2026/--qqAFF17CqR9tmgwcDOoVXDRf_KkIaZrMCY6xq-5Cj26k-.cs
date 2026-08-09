using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D : _0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz5rQzobg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzAvn2b38_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzR58imxw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzmQTFaQA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzWYPqg2E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEWLeis8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzbfrNXYE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzkKfJheA_003D;

	public _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D()
		: this(0)
	{
	}

	public _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D(int _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		this._0023_003DziDLVpbY_003D = new byte[_0023_003DziDLVpbY_003D];
		_0023_003DzmQTFaQA_003D = _0023_003DziDLVpbY_003D;
		_0023_003DzWYPqg2E_003D = true;
		_0023_003DzEWLeis8_003D = true;
		_0023_003Dz5rQzobg_003D = 0;
		_0023_003DzbfrNXYE_003D = true;
	}

	public _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D(byte[] _0023_003DziDLVpbY_003D)
		: this(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D: true)
	{
	}

	public _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D(byte[] _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
		_0023_003DzR58imxw_003D = (_0023_003DzmQTFaQA_003D = _0023_003DziDLVpbY_003D.Length);
		_0023_003DzEWLeis8_003D = _0023_003Dz5rQzobg_003D;
		this._0023_003Dz5rQzobg_003D = 0;
		_0023_003DzbfrNXYE_003D = true;
	}

	public _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
		: this(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, _0023_003DzR58imxw_003D: true)
	{
	}

	public _0023_003DqqAFF17CqR9tmgwcDOoVXDRf_KkIaZrMCY6xq_00245Cj26k_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003Dz5rQzobg_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzAvn2b38_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DziDLVpbY_003D.Length - _0023_003Dz5rQzobg_003D < _0023_003DzAvn2b38_003D)
		{
			throw new ArgumentException();
		}
		this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
		this._0023_003Dz5rQzobg_003D = (this._0023_003DzAvn2b38_003D = _0023_003Dz5rQzobg_003D);
		this._0023_003DzR58imxw_003D = (_0023_003DzmQTFaQA_003D = _0023_003Dz5rQzobg_003D + _0023_003DzAvn2b38_003D);
		_0023_003DzEWLeis8_003D = _0023_003DzR58imxw_003D;
		_0023_003DzWYPqg2E_003D = false;
		_0023_003DzbfrNXYE_003D = true;
	}

	[SpecialName]
	public override bool _0023_003DzZmS2S24ChN1wnkvFtQiEiiI6mLEokf_f7OnkClYx3lm_vaV_0024YtAEzTrETj_0024XsT3Fs3tXV_w_003D()
	{
		return _0023_003DzbfrNXYE_003D;
	}

	[SpecialName]
	public override bool _0023_003DzWpbADLL4o6kgUq7wtkwgc6Ts7xNzexyhm3yYYoorSu8mGABRFiobQ7xDRwiDafuMK6Cr_OdlHBFd()
	{
		return _0023_003DzbfrNXYE_003D;
	}

	[SpecialName]
	public override bool _0023_003Dzh9EKEBxGXiCJwxkbztzw4uEZWPCC57sbjdRx7L6YU2e0iPn1_0024rDVjT1xurLVS7nmml2swI8eal3Bu_rsTh6Tdl4_003D()
	{
		return _0023_003DzEWLeis8_003D;
	}

	protected override void _0023_003DzKyBSdOboAiM1SCoZnIxTZKDjxwX7pDBfDyUhtydGIinqawHVdVG_00246Gy_00245yPBWRdYkN_Xs9BsiI7lYXej84RR5oc_003D(bool _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzkKfJheA_003D)
		{
			if (_0023_003DziDLVpbY_003D)
			{
				_0023_003DzbfrNXYE_003D = false;
				_0023_003DzEWLeis8_003D = false;
				_0023_003DzWYPqg2E_003D = false;
			}
			_0023_003DzkKfJheA_003D = true;
		}
	}

	private bool _0023_003DzYFqNsQE8l3kdpg1MuSM6O7IA2qrINwaxKQ_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D < 0)
		{
			throw new IOException();
		}
		if (_0023_003DziDLVpbY_003D > _0023_003DzmQTFaQA_003D)
		{
			int num = _0023_003DziDLVpbY_003D;
			if (num < 256)
			{
				num = 256;
			}
			if (num < _0023_003DzmQTFaQA_003D * 2)
			{
				num = _0023_003DzmQTFaQA_003D * 2;
			}
			_0023_003Dzamhx13lhASWf44zzEz1C67cZQNSQ(num);
			return true;
		}
		return false;
	}

	public override void _0023_003DzFtAD4jVL_F7USN8PT4Kx8dmyjUM6PkZ9RFfXsLYrEFa0G9DdYj1vKjg3mDzZWG73qteQwCMQsdD6tZF1qA_003D_003D()
	{
	}

	internal byte[] _0023_003Dzi2oPv05k_0024QM_NYl7geg9JSI_003D()
	{
		return _0023_003DziDLVpbY_003D;
	}

	internal void _0023_003DzYoRHRt2r8KQ7F4kPCarGdxw_003D(out int _0023_003DziDLVpbY_003D, out int _0023_003Dz5rQzobg_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		_0023_003DziDLVpbY_003D = this._0023_003Dz5rQzobg_003D;
		_0023_003Dz5rQzobg_003D = _0023_003DzR58imxw_003D;
	}

	internal int _0023_003DzvGW4LLMZ9Y1kwSGSMYjFhaEDQ0tv()
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		return _0023_003DzAvn2b38_003D;
	}

	public int _0023_003DznJf77NmtMgaDkN3wxD_00248tFuvT8gi(int _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		int num = _0023_003DzR58imxw_003D - _0023_003DzAvn2b38_003D;
		if (num > _0023_003DziDLVpbY_003D)
		{
			num = _0023_003DziDLVpbY_003D;
		}
		if (num < 0)
		{
			num = 0;
		}
		_0023_003DzAvn2b38_003D += num;
		return num;
	}

	public int _0023_003Dzne5fvhxDVYDRggMFdj_SRg2PdlcD()
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		return _0023_003DzmQTFaQA_003D - _0023_003Dz5rQzobg_003D;
	}

	public void _0023_003Dzamhx13lhASWf44zzEz1C67cZQNSQ(int _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		if (_0023_003DziDLVpbY_003D == _0023_003DzmQTFaQA_003D)
		{
			return;
		}
		if (!_0023_003DzWYPqg2E_003D)
		{
			throw new Exception();
		}
		if (_0023_003DziDLVpbY_003D < _0023_003DzR58imxw_003D)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DziDLVpbY_003D > 0)
		{
			byte[] dst = new byte[_0023_003DziDLVpbY_003D];
			if (_0023_003DzR58imxw_003D > 0)
			{
				Buffer.BlockCopy(this._0023_003DziDLVpbY_003D, 0, dst, 0, _0023_003DzR58imxw_003D);
			}
			this._0023_003DziDLVpbY_003D = dst;
		}
		else
		{
			this._0023_003DziDLVpbY_003D = null;
		}
		_0023_003DzmQTFaQA_003D = _0023_003DziDLVpbY_003D;
	}

	[SpecialName]
	public override long _0023_003DzraNgARjX4QSbGcrZYaUV_Kt5FJD_0024RmALGpou1doOgwLvbYwEh88yFgkavQ_0024_0024lIyzZM73DVaXA_e6k069AX2zF5I_003D()
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		return _0023_003DzR58imxw_003D - _0023_003Dz5rQzobg_003D;
	}

	[SpecialName]
	public override long _0023_003Dzwl9sCcsvR4k6PzVcPKWWotTJzm4oD4gNUyoQC7OJjpk_00241M08s70UvYFNG9PxA9cCifL33i8_003D()
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		return _0023_003DzAvn2b38_003D - _0023_003Dz5rQzobg_003D;
	}

	[SpecialName]
	public override void _0023_003DzQZ8To03pqmaE0_0024_s_0024MPn8tSR4QVXl_JNjN3rTa3mIQ_UWPJ027H8ZJC6fkO7HSABoir32uY_003D(long _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		if (_0023_003DziDLVpbY_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DziDLVpbY_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		_0023_003DzAvn2b38_003D = _0023_003Dz5rQzobg_003D + (int)_0023_003DziDLVpbY_003D;
	}

	public override int _0023_003Dzu_0024wz50Gq3LJ8xd5lgsToLbHhVCfptTZN7NjjPuQ1kWJGK38M7lFOyzt0sHhCoqpa_0024W_0024ZkwQgzp275i1d_A_003D_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003Dz5rQzobg_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzAvn2b38_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DziDLVpbY_003D.Length - _0023_003Dz5rQzobg_003D < _0023_003DzAvn2b38_003D)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzR58imxw_003D - this._0023_003DzAvn2b38_003D;
		if (num > _0023_003DzAvn2b38_003D)
		{
			num = _0023_003DzAvn2b38_003D;
		}
		if (num <= 0)
		{
			return 0;
		}
		if (num <= 8)
		{
			int num2 = num;
			while (--num2 >= 0)
			{
				_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + num2] = this._0023_003DziDLVpbY_003D[this._0023_003DzAvn2b38_003D + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(this._0023_003DziDLVpbY_003D, this._0023_003DzAvn2b38_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, num);
		}
		this._0023_003DzAvn2b38_003D += num;
		return num;
	}

	public override int _0023_003Dzrq0YfyAp0Nijy1Gvlte5XnxkCzFwVSNGc7wElpy_0024LW_0024qFsQyWHa1sQRploiX7vdAEMt_0024ksvXpwjxqTH2_0024pC_IxlcWXCn()
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzAvn2b38_003D >= _0023_003DzR58imxw_003D)
		{
			return -1;
		}
		return _0023_003DziDLVpbY_003D[_0023_003DzAvn2b38_003D++];
	}

	public override long _0023_003DzUQ_bGErryTDpszeAu244IzixOQag9otlJo42_0024oeegDPivRgB6_0024XwD9KrkyM3tgZwAvXv4b_A7Pkg5OViPw_003D_003D(long _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		if (_0023_003DziDLVpbY_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		switch (_0023_003Dz5rQzobg_003D)
		{
		case 0:
			if (_0023_003DziDLVpbY_003D < 0)
			{
				throw new IOException();
			}
			_0023_003DzAvn2b38_003D = this._0023_003Dz5rQzobg_003D + (int)_0023_003DziDLVpbY_003D;
			break;
		case 1:
			if (_0023_003DziDLVpbY_003D + _0023_003DzAvn2b38_003D < this._0023_003Dz5rQzobg_003D)
			{
				throw new IOException();
			}
			_0023_003DzAvn2b38_003D += (int)_0023_003DziDLVpbY_003D;
			break;
		case 2:
			if (_0023_003DzR58imxw_003D + _0023_003DziDLVpbY_003D < this._0023_003Dz5rQzobg_003D)
			{
				throw new IOException();
			}
			_0023_003DzAvn2b38_003D = _0023_003DzR58imxw_003D + (int)_0023_003DziDLVpbY_003D;
			break;
		default:
			throw new ArgumentException();
		}
		return _0023_003DzAvn2b38_003D;
	}

	public override void _0023_003DzoZOrTTafI92aUamlP8XOqT9r3cifR_9OhA3b8QszFM617Axh9aSZQp7SlAHVpjFwwQECGOJCTZacpYcqfGw5dDnN0ZJi(long _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzEWLeis8_003D)
		{
			throw new Exception();
		}
		if (_0023_003DziDLVpbY_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DziDLVpbY_003D < 0 || _0023_003DziDLVpbY_003D > int.MaxValue - _0023_003Dz5rQzobg_003D)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = _0023_003Dz5rQzobg_003D + (int)_0023_003DziDLVpbY_003D;
		if (!_0023_003DzYFqNsQE8l3kdpg1MuSM6O7IA2qrINwaxKQ_003D_003D(num) && num > _0023_003DzR58imxw_003D)
		{
			Array.Clear(this._0023_003DziDLVpbY_003D, _0023_003DzR58imxw_003D, num - _0023_003DzR58imxw_003D);
		}
		_0023_003DzR58imxw_003D = num;
		if (_0023_003DzAvn2b38_003D > num)
		{
			_0023_003DzAvn2b38_003D = num;
		}
	}

	public byte[] _0023_003DzgPub9c20_0024V9QQAuzbhy_0024MuhDlBdX3Iywf7qzqsc_003D()
	{
		byte[] array = new byte[_0023_003DzR58imxw_003D - _0023_003Dz5rQzobg_003D];
		Buffer.BlockCopy(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, array, 0, _0023_003DzR58imxw_003D - _0023_003Dz5rQzobg_003D);
		return array;
	}

	public override void _0023_003DznRraYymMBsP7i90bQMDED5umU3cS7uHX639nw6I84RHefV9Bq6xiU0PXLJI7rh8sUOby8z4QDbCtMrWW_vneQSE_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		if (!_0023_003DzEWLeis8_003D)
		{
			throw new Exception();
		}
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003Dz5rQzobg_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzAvn2b38_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DziDLVpbY_003D.Length - _0023_003Dz5rQzobg_003D < _0023_003DzAvn2b38_003D)
		{
			throw new ArgumentException();
		}
		int num = this._0023_003DzAvn2b38_003D + _0023_003DzAvn2b38_003D;
		if (num < 0)
		{
			throw new IOException();
		}
		if (num > _0023_003DzR58imxw_003D)
		{
			bool flag = this._0023_003DzAvn2b38_003D > _0023_003DzR58imxw_003D;
			if (num > _0023_003DzmQTFaQA_003D && _0023_003DzYFqNsQE8l3kdpg1MuSM6O7IA2qrINwaxKQ_003D_003D(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this._0023_003DziDLVpbY_003D, _0023_003DzR58imxw_003D, num - _0023_003DzR58imxw_003D);
			}
			_0023_003DzR58imxw_003D = num;
		}
		if (_0023_003DzAvn2b38_003D <= 8)
		{
			int num2 = _0023_003DzAvn2b38_003D;
			while (--num2 >= 0)
			{
				this._0023_003DziDLVpbY_003D[this._0023_003DzAvn2b38_003D + num2] = _0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, this._0023_003DziDLVpbY_003D, this._0023_003DzAvn2b38_003D, _0023_003DzAvn2b38_003D);
		}
		this._0023_003DzAvn2b38_003D = num;
	}

	public override void _0023_003Dz9kGhGjjlBbjYiKaVBxYEYHIQPGnQzYBArxoZWwefkuJd6d_0024B4DQRh2Rpbq2kdfGEHLPIkfpVYyXoyZE4ir10STQ_003D(byte _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		if (!_0023_003DzEWLeis8_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzAvn2b38_003D >= _0023_003DzR58imxw_003D)
		{
			int num = _0023_003DzAvn2b38_003D + 1;
			bool flag = _0023_003DzAvn2b38_003D > _0023_003DzR58imxw_003D;
			if (num >= _0023_003DzmQTFaQA_003D && _0023_003DzYFqNsQE8l3kdpg1MuSM6O7IA2qrINwaxKQ_003D_003D(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this._0023_003DziDLVpbY_003D, _0023_003DzR58imxw_003D, _0023_003DzAvn2b38_003D - _0023_003DzR58imxw_003D);
			}
			_0023_003DzR58imxw_003D = num;
		}
		this._0023_003DziDLVpbY_003D[_0023_003DzAvn2b38_003D++] = _0023_003DziDLVpbY_003D;
	}

	public void _0023_003Dz07ww1Z0Bs9z0RPPo_e7yxiU_003D(Stream _0023_003DziDLVpbY_003D)
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException();
		}
		_0023_003DziDLVpbY_003D.Write(this._0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzR58imxw_003D - _0023_003Dz5rQzobg_003D);
	}

	internal int _0023_003DzsdY66sNiEj5Kg3_Ap_0024PKjkXBp2L1QO4_0024qc5do2Brn9FJ()
	{
		if (!_0023_003DzbfrNXYE_003D)
		{
			throw new Exception();
		}
		int num = (_0023_003DzAvn2b38_003D += 4);
		if (num > _0023_003DzR58imxw_003D)
		{
			_0023_003DzAvn2b38_003D = _0023_003DzR58imxw_003D;
			throw new Exception();
		}
		return (_0023_003DziDLVpbY_003D[num - 1] << 24) | (_0023_003DziDLVpbY_003D[num - 2] << 8) | (_0023_003DziDLVpbY_003D[num - 3] << 16) | _0023_003DziDLVpbY_003D[num - 4];
	}
}
