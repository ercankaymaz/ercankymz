using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

internal sealed class _0023_003Dq0aa58W10obKnKDKIHo_WWgOW9JtktHiQ_0024YmOP_0024z1aZw_003D : _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D, IDisposable
{
	private sealed class _0023_003DzjYYAPCA_003D
	{
		public bool _0023_003DzjYYAPCA_003D;

		public _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DzVC9FBdo_003D;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DqUwzBjw0UTwLX7f6bfoiplKSK_0024XOti30XAiGHDXcUdU8_003D m__0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzVC9FBdo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzwBouG0w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dzf4Pqh9s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzTFNDoh0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzjYYAPCA_003D _0023_003DzraVZG9g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzRoqMfFc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly object _0023_003Dz1SmHC4c_003D = new object();

	public _0023_003Dq0aa58W10obKnKDKIHo_WWgOW9JtktHiQ_0024YmOP_0024z1aZw_003D(bool _0023_003DzjYYAPCA_003D, _0023_003DqUwzBjw0UTwLX7f6bfoiplKSK_0024XOti30XAiGHDXcUdU8_003D _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D = false)
	{
		this._0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D;
		this.m__0023_003DzjYYAPCA_003D = _0023_003DzVC9FBdo_003D;
		this._0023_003DzwBouG0w_003D = _0023_003DzwBouG0w_003D;
		this._0023_003DzwBouG0w_003D = true;
		int num = _0023_003DzVC9FBdo_003D._0023_003DzTLpMkwjrjHxMkJaZlRvHQI1s60DEOXBNObrg_A0_003D()._0023_003DzEY5UKAkCBDRDauM_Xu2bpHOQcRtY();
		_0023_003Dzf4Pqh9s_003D = _0023_003DztUsa3xDQTanhMbHmDGYxhsC5ZUSsTnU_0024UshRnN4_003D(num, _0023_003DzjYYAPCA_003D);
		_0023_003DzTFNDoh0_003D = _0023_003Dz0wLo2peUBHw8lUjJqxwnfxw_003D(num, _0023_003DzjYYAPCA_003D);
	}

	public bool _0023_003DznHswNGTTW_0024v2rqReUH06Udns5tWTx81QrOsY5XGyGRKH()
	{
		return _0023_003DzVC9FBdo_003D;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0023_003Dz6yWKn5RWb7TX7YfTPmAuYkQGbBUVyb7IKq9weDETUYolhIQUjGNVzu8Rgtk0LZEsFpyFDs_3SQhqAnPpIg_003D_003D()
	{
		return _0023_003Dzf4Pqh9s_003D;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0023_003DzxmlC_Zo_oW81BAJ8I65ymN9fvteApvKrAhr_ENOUJQ_eQprME4lFPgaCIgbDK_01_sDs3v8_003D()
	{
		return _0023_003DzTFNDoh0_003D;
	}

	private static int _0023_003DztUsa3xDQTanhMbHmDGYxhsC5ZUSsTnU_0024UshRnN4_003D(int _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		if (!_0023_003DzVC9FBdo_003D)
		{
			return (_0023_003DzjYYAPCA_003D + 7) / 8;
		}
		return (_0023_003DzjYYAPCA_003D - 1) / 8;
	}

	private static int _0023_003Dz0wLo2peUBHw8lUjJqxwnfxw_003D(int _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		if (!_0023_003DzVC9FBdo_003D)
		{
			return (_0023_003DzjYYAPCA_003D - 1) / 8;
		}
		return (_0023_003DzjYYAPCA_003D + 7) / 8;
	}

	public int _0023_003Dz9htoK_3JkptM8kqGKCoLls0gCyl0YxEaqpdWRGC0cgW64QQ0i2FuHnA5ifidkO1VpyhTlQoeTNtHe8H3_00243_HfdI_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, byte[] _0023_003Dzf4Pqh9s_003D, int _0023_003DzTFNDoh0_003D, RandomNumberGenerator _0023_003DzraVZG9g_003D)
	{
		_0023_003Dz5_00243kQdiB991Sh5Ax2e0K2AolEU6o();
		_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D2 = this._0023_003DzraVZG9g_003D;
		try
		{
			return _0023_003DzjYYAPCA_003D2._0023_003DzVC9FBdo_003D._0023_003Dz9htoK_3JkptM8kqGKCoLls0gCyl0YxEaqpdWRGC0cgW64QQ0i2FuHnA5ifidkO1VpyhTlQoeTNtHe8H3_00243_HfdI_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D);
		}
		catch when (_0023_003DzjYYAPCA_003D2._0023_003DzjYYAPCA_003D)
		{
			_0023_003DzXs_Yh_002461GNRCnLeBo8FC0pk_003D();
			_0023_003DzjYYAPCA_003D2 = this._0023_003DzraVZG9g_003D;
			return _0023_003DzjYYAPCA_003D2._0023_003DzVC9FBdo_003D._0023_003Dz9htoK_3JkptM8kqGKCoLls0gCyl0YxEaqpdWRGC0cgW64QQ0i2FuHnA5ifidkO1VpyhTlQoeTNtHe8H3_00243_HfdI_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D, _0023_003DzraVZG9g_003D);
		}
	}

	private void _0023_003DzXs_Yh_002461GNRCnLeBo8FC0pk_003D()
	{
		lock (_0023_003Dz1SmHC4c_003D)
		{
			_0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D2 = _0023_003DzraVZG9g_003D;
			if (!_0023_003DzjYYAPCA_003D2._0023_003DzjYYAPCA_003D)
			{
				return;
			}
			try
			{
				if (_0023_003DzjYYAPCA_003D2._0023_003DzVC9FBdo_003D is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			catch
			{
			}
			_0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2 = _0023_003DztFUKVct3p4S_uF_0024aqqVuzYloKXvsMbd0UqI8lkouvbDWtsn5Q4vdmYaLIv5ugPcuCHRg6KKxFCnUIdptlnPmPko_003D(_0023_003DzVC9FBdo_003D, this.m__0023_003DzjYYAPCA_003D);
			if (_0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2 == null)
			{
				throw new InvalidOperationException();
			}
			_0023_003DzraVZG9g_003D = new _0023_003DzjYYAPCA_003D
			{
				_0023_003DzjYYAPCA_003D = false,
				_0023_003DzVC9FBdo_003D = _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2
			};
		}
	}

	private void _0023_003Dz5_00243kQdiB991Sh5Ax2e0K2AolEU6o()
	{
		if (_0023_003DzRoqMfFc_003D)
		{
			return;
		}
		lock (_0023_003Dz1SmHC4c_003D)
		{
			if (_0023_003DzRoqMfFc_003D)
			{
				return;
			}
			_0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2;
			if (!_0023_003DzwBouG0w_003D && (_0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2 = _0023_003DzYha4CkJmHcWh7Q4cvxnxmfAS11z3_0024P17j_0024PxwsMTsN9kUsbje0OmHIw2fP3iGHPTauesUQqFJKmQ9BTg7M7EgAU_003D(_0023_003DzVC9FBdo_003D, this.m__0023_003DzjYYAPCA_003D)) != null)
			{
				_0023_003DzraVZG9g_003D = new _0023_003DzjYYAPCA_003D
				{
					_0023_003DzjYYAPCA_003D = true,
					_0023_003DzVC9FBdo_003D = _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2
				};
			}
			else
			{
				_0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2 = _0023_003DztFUKVct3p4S_uF_0024aqqVuzYloKXvsMbd0UqI8lkouvbDWtsn5Q4vdmYaLIv5ugPcuCHRg6KKxFCnUIdptlnPmPko_003D(_0023_003DzVC9FBdo_003D, this.m__0023_003DzjYYAPCA_003D);
				if (_0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2 == null)
				{
					throw new InvalidOperationException();
				}
				_0023_003DzraVZG9g_003D = new _0023_003DzjYYAPCA_003D
				{
					_0023_003DzjYYAPCA_003D = false,
					_0023_003DzVC9FBdo_003D = _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D2
				};
			}
			_0023_003DzRoqMfFc_003D = true;
		}
	}

	protected virtual _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DztFUKVct3p4S_uF_0024aqqVuzYloKXvsMbd0UqI8lkouvbDWtsn5Q4vdmYaLIv5ugPcuCHRg6KKxFCnUIdptlnPmPko_003D(bool _0023_003DzjYYAPCA_003D, _0023_003DqUwzBjw0UTwLX7f6bfoiplKSK_0024XOti30XAiGHDXcUdU8_003D _0023_003DzVC9FBdo_003D)
	{
		return new _0023_003DqiKG8cMtDhvDx0IwX7MlRZlcIjpx4HLLwqkPMv_0024jpS9s_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
	}

	protected virtual _0023_003DqtdOfWBQ1IWF7LpY14n4YH9TeyhxIdOmjIurRE9BP_iY_003D _0023_003DzYha4CkJmHcWh7Q4cvxnxmfAS11z3_0024P17j_0024PxwsMTsN9kUsbje0OmHIw2fP3iGHPTauesUQqFJKmQ9BTg7M7EgAU_003D(bool _0023_003DzjYYAPCA_003D, _0023_003DqUwzBjw0UTwLX7f6bfoiplKSK_0024XOti30XAiGHDXcUdU8_003D _0023_003DzVC9FBdo_003D)
	{
		return _0023_003DqIx7Es0991cC2X_00245IB4D_00241bg8dcsTFrNCQ7DwcOsHhzo_003D._0023_003DzjiH4y5WYvVx1FHrNKdyX9OjzQhdzdySlkYSBlk4_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
	}

	public void Dispose()
	{
		if (_0023_003DzraVZG9g_003D?._0023_003DzVC9FBdo_003D is IDisposable disposable)
		{
			disposable.Dispose();
			_0023_003DzraVZG9g_003D = null;
		}
	}
}
