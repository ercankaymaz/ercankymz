using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;

internal sealed class _0023_003Dqg2XVMDwOcutFmLZPrQ_0024gP9yGZk4ZuLZGkMatxVqljts_003D : IDisposable
{
	private sealed class _0023_003DzjYYAPCA_003D
	{
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqZNGhCS7lv8L9iilC3VWH6r7KLoWFqWvoL0M3uhKhBJc_003D m__0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D _0023_003DzVC9FBdo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzwBouG0w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dzf4Pqh9s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static volatile Type _0023_003DzTFNDoh0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzraVZG9g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzRoqMfFc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SymmetricAlgorithm _0023_003Dz1SmHC4c_003D;

	public _0023_003Dqg2XVMDwOcutFmLZPrQ_0024gP9yGZk4ZuLZGkMatxVqljts_003D()
	{
		_0023_003DzRXHqQpaHW3x9uexWwEJKzplbpvq5((_0023_003DqZNGhCS7lv8L9iilC3VWH6r7KLoWFqWvoL0M3uhKhBJc_003D)1);
	}

	public void Dispose()
	{
		((IDisposable)_0023_003Dz1SmHC4c_003D)?.Dispose();
	}

	public _0023_003DqZNGhCS7lv8L9iilC3VWH6r7KLoWFqWvoL0M3uhKhBJc_003D _0023_003Dz_zpN5f6cN_sElg05zs3akGM_003D()
	{
		return this.m__0023_003DzjYYAPCA_003D;
	}

	public void _0023_003DzRXHqQpaHW3x9uexWwEJKzplbpvq5(_0023_003DqZNGhCS7lv8L9iilC3VWH6r7KLoWFqWvoL0M3uhKhBJc_003D _0023_003DzjYYAPCA_003D)
	{
		if (this.m__0023_003DzjYYAPCA_003D != _0023_003DzjYYAPCA_003D)
		{
			this.m__0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
			_0023_003DzRoqMfFc_003D = true;
		}
	}

	public _0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D _0023_003DzKDDUUneJSSls9HGDW4VNxHMlWKj65uH9yjRRHCE_003D()
	{
		return _0023_003DzVC9FBdo_003D;
	}

	public void _0023_003DzCC0rFYfx2lJko_0024_0024UrNwjYRfgu18kmOn_rsoGPIqoJfyY(_0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzVC9FBdo_003D != _0023_003DzjYYAPCA_003D)
		{
			_0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D;
			_0023_003DzRoqMfFc_003D = true;
		}
	}

	public byte[] _0023_003Dz0VZBTYD7dXOsjO5S1lhenHeqTEzq()
	{
		return _0023_003DzwBouG0w_003D;
	}

	public void _0023_003Dz6oSbbu_JsQWPzQ0VKqrChaVZMVD48kmZbw_003D_003D(byte[] _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzwBouG0w_003D = _0023_003DzjYYAPCA_003D;
		_0023_003DzRoqMfFc_003D = true;
	}

	public byte[] _0023_003DzJ4nQy4z5J6IfeAaMLfSlHN4_003D()
	{
		return _0023_003Dzf4Pqh9s_003D;
	}

	public void _0023_003DzZvpm9ZNyBYIlhWoRw_u5d_A_003D(byte[] _0023_003DzjYYAPCA_003D)
	{
		_0023_003Dzf4Pqh9s_003D = _0023_003DzjYYAPCA_003D;
		_0023_003DzRoqMfFc_003D = true;
	}

	private static SymmetricAlgorithm _0023_003Dz_0024ZJVreZ95gqaRJ5uZ2zSLzbx82TnND4JqpHaQG0_003D()
	{
		if (_0023_003DzTFNDoh0_003D != null)
		{
			if (_0023_003DzTFNDoh0_003D == typeof(_0023_003DzjYYAPCA_003D))
			{
				return null;
			}
			return Activator.CreateInstance(_0023_003DzTFNDoh0_003D) as SymmetricAlgorithm;
		}
		_0023_003DzTFNDoh0_003D = typeof(_0023_003DzjYYAPCA_003D);
		Assembly assembly = null;
		try
		{
			assembly = Assembly.Load(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620497));
		}
		catch
		{
		}
		if (assembly == null)
		{
			return null;
		}
		try
		{
			Type type = assembly.GetType(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620348));
			if (type != null)
			{
				SymmetricAlgorithm result = Activator.CreateInstance(type) as SymmetricAlgorithm;
				_0023_003DzTFNDoh0_003D = type;
				return result;
			}
		}
		catch
		{
		}
		try
		{
			Type type2 = assembly.GetType(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620384));
			if (type2 != null)
			{
				SymmetricAlgorithm result2 = Activator.CreateInstance(type2) as SymmetricAlgorithm;
				_0023_003DzTFNDoh0_003D = type2;
				return result2;
			}
		}
		catch
		{
		}
		return null;
	}

	private static CipherMode _0023_003Dz8Bf3fV0jtsA8YTCjXWd59IEb7WSfPUzVsA_003D_003D(_0023_003DqZNGhCS7lv8L9iilC3VWH6r7KLoWFqWvoL0M3uhKhBJc_003D _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D == (_0023_003DqZNGhCS7lv8L9iilC3VWH6r7KLoWFqWvoL0M3uhKhBJc_003D)1)
		{
			return CipherMode.CBC;
		}
		throw new InvalidOperationException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620690));
	}

	private static PaddingMode _0023_003DzLZ0fHUlfV2EvwvOH4zOWwOJc87Pxio_Oyn3qdic_003D(_0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D _0023_003DzjYYAPCA_003D)
	{
		return _0023_003DzjYYAPCA_003D switch
		{
			(_0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D)1 => PaddingMode.None, 
			(_0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D)2 => PaddingMode.PKCS7, 
			_ => throw new InvalidOperationException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620751)), 
		};
	}

	public _0023_003Dq_ibtQ1uSDbfMzR2aZwe8aJ_qUbgrdIrzp9AqqqgWLPs_003D _0023_003DzpZ8rU5lnz1wCSCAaDg61kvzKxkUV()
	{
		return _0023_003DzuJnL2CLxUUSFx7cH6V_0024tGvo_003D(_0023_003DzjYYAPCA_003D: true);
	}

	public _0023_003Dq_ibtQ1uSDbfMzR2aZwe8aJ_qUbgrdIrzp9AqqqgWLPs_003D _0023_003DzdQ_00249_0024_0024Pe1wwjjUG1_CbOjCY9GSTX()
	{
		return _0023_003DzuJnL2CLxUUSFx7cH6V_0024tGvo_003D(_0023_003DzjYYAPCA_003D: false);
	}

	private _0023_003Dq_ibtQ1uSDbfMzR2aZwe8aJ_qUbgrdIrzp9AqqqgWLPs_003D _0023_003DzuJnL2CLxUUSFx7cH6V_0024tGvo_003D(bool _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003DzraVZG9g_003D)
		{
			bool flag = _0023_003DzRoqMfFc_003D || _0023_003Dz1SmHC4c_003D == null;
			if (_0023_003Dz1SmHC4c_003D == null)
			{
				_0023_003Dz1SmHC4c_003D = _0023_003Dz_0024ZJVreZ95gqaRJ5uZ2zSLzbx82TnND4JqpHaQG0_003D();
				if (_0023_003Dz1SmHC4c_003D == null)
				{
					_0023_003DzraVZG9g_003D = true;
				}
			}
			if (_0023_003Dz1SmHC4c_003D != null)
			{
				if (flag)
				{
					_0023_003Dz1SmHC4c_003D.Key = _0023_003Dz0VZBTYD7dXOsjO5S1lhenHeqTEzq();
					_0023_003Dz1SmHC4c_003D.IV = _0023_003DzJ4nQy4z5J6IfeAaMLfSlHN4_003D();
					_0023_003Dz1SmHC4c_003D.Mode = _0023_003Dz8Bf3fV0jtsA8YTCjXWd59IEb7WSfPUzVsA_003D_003D(_0023_003Dz_zpN5f6cN_sElg05zs3akGM_003D());
					_0023_003Dz1SmHC4c_003D.Padding = _0023_003DzLZ0fHUlfV2EvwvOH4zOWwOJc87Pxio_Oyn3qdic_003D(_0023_003DzKDDUUneJSSls9HGDW4VNxHMlWKj65uH9yjRRHCE_003D());
				}
				return new _0023_003Dqv5jNEINgRiU3U0uL89SFazWZlPujI4XaQ4TJIxsu8VU_003D(_0023_003DzjYYAPCA_003D ? _0023_003Dz1SmHC4c_003D.CreateEncryptor() : _0023_003Dz1SmHC4c_003D.CreateDecryptor());
			}
		}
		_0023_003DqLf4viDU2wvFRK07jggsCNmjc_0024ZFlmMz0fdboppWFyoo_003D _0023_003DqLf4viDU2wvFRK07jggsCNmjc_0024ZFlmMz0fdboppWFyoo_003D2 = new _0023_003DqLf4viDU2wvFRK07jggsCNmjc_0024ZFlmMz0fdboppWFyoo_003D(new _0023_003DqC8pO6ek2CrYCqqBrdQ_0024UWSDbopizdlDpSKKrxyoUgKc_003D());
		_0023_003Dqw7szHSw6WLraHNWp8IxpCKbojfYzljq0fsnnIVYjJLs_003D _0023_003Dqw7szHSw6WLraHNWp8IxpCKbojfYzljq0fsnnIVYjJLs_003D2 = ((_0023_003DzKDDUUneJSSls9HGDW4VNxHMlWKj65uH9yjRRHCE_003D() == (_0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D)1) ? new _0023_003Dqw7szHSw6WLraHNWp8IxpCKbojfYzljq0fsnnIVYjJLs_003D(_0023_003DqLf4viDU2wvFRK07jggsCNmjc_0024ZFlmMz0fdboppWFyoo_003D2) : new _0023_003DqBtO_Ln5vbudMbzVGmzEMI3U6jZ68i707t_0024oPPtslP9M_003D(_0023_003DqLf4viDU2wvFRK07jggsCNmjc_0024ZFlmMz0fdboppWFyoo_003D2, _0023_003DzpmJskuZMWqCuauwtsQKtGMY_003D(_0023_003DzKDDUUneJSSls9HGDW4VNxHMlWKj65uH9yjRRHCE_003D())));
		_0023_003DqVLE856NmzWhU_bIXHFUSoJ2J5g7J5M7JIA155i_9ji4_003D _0023_003DqVLE856NmzWhU_bIXHFUSoJ2J5g7J5M7JIA155i_9ji4_003D2 = new _0023_003DqVLE856NmzWhU_bIXHFUSoJ2J5g7J5M7JIA155i_9ji4_003D(new _0023_003DqtFN_00241TjdaenuCmn9GBmqptPfjTUxtfhRNfxI_0024iGsTHc_003D(_0023_003Dz0VZBTYD7dXOsjO5S1lhenHeqTEzq()), _0023_003DzJ4nQy4z5J6IfeAaMLfSlHN4_003D());
		_0023_003Dqw7szHSw6WLraHNWp8IxpCKbojfYzljq0fsnnIVYjJLs_003D2._0023_003DzjyFlgOuUtph0jKFANXTXV1awFewl4c7cCrMFZ67Y8_TWj78dQDYZVHerTuy64aAQJ_0024Q8iMs59OJgxAmjd9nl75U_003D(_0023_003DzjYYAPCA_003D, _0023_003DqVLE856NmzWhU_bIXHFUSoJ2J5g7J5M7JIA155i_9ji4_003D2);
		return new _0023_003DqRhRZlYf2fNrXHviAJ2PxvkPlehAmJ_YHdX5RzgMcfu4_003D(_0023_003Dqw7szHSw6WLraHNWp8IxpCKbojfYzljq0fsnnIVYjJLs_003D2);
	}

	private static _0023_003Dqa6z9PFIiJLOfR0XkEA_0024LQQEzVX1yZe1B1VYTr_0024prpIE_003D _0023_003DzpmJskuZMWqCuauwtsQKtGMY_003D(_0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D _0023_003DzjYYAPCA_003D)
	{
		return _0023_003DzjYYAPCA_003D switch
		{
			(_0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D)1 => null, 
			(_0023_003Dqud6X3rWlf1KppQZHrSvLRBtFM6P9wMnX5_aTna7Y2qw_003D)2 => new _0023_003DqAApRutk_0024_0024_r10xpZwFNxeOdje6TDwHvn2SfqdsWa4AA_003D(), 
			_ => throw new InvalidOperationException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620751)), 
		};
	}
}
