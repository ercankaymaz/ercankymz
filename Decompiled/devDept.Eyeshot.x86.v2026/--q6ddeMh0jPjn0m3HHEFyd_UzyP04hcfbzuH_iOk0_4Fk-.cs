using System.Security.Cryptography;

internal abstract class _0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D
{
	private readonly SymmetricAlgorithm[] _0023_003Dzq80RbjQ_003D;

	public _0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D(byte[] _0023_003Dzq80RbjQ_003D, long _0023_003DzZzVr6_0024U_003D)
		: this(_0023_003Dzq80RbjQ_003D, _0023_003DzRADJbtBEzYdc0hhgwyms4FJylaHls5E4KQ_003D_003D(_0023_003DzZzVr6_0024U_003D))
	{
	}

	public _0023_003Dq6ddeMh0jPjn0m3HHEFyd_UzyP04hcfbzuH_iOk0_4Fk_003D(byte[] _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D)
	{
		_0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D _0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D2 = new _0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, 1);
		SymmetricAlgorithm[] array = new SymmetricAlgorithm[5];
		for (int i = 0; i < 5; i++)
		{
			_0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D _0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D2 = new _0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D(new _0023_003Dqd8JBeTDbtnpIEDoflGijNzyIXA7E8aXrIZBrj9XgbSE_003D());
			_0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D2.Key = _0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D2.GetBytes(_0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D2.KeySize / 8);
			_0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D2.IV = _0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D2.GetBytes(_0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D2._0023_003Dz_0024KbFjgGgMMzh5q2AKcFFjpw_003D() / 8);
			array[i] = _0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D2;
		}
		this._0023_003Dzq80RbjQ_003D = array;
	}

	protected static int _0023_003DzIDt9xZyyxSpoFEN_zy6XL4fUJaTw207rAA_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		return (_0023_003Dzq80RbjQ_003D + 3) / 4 * 4;
	}

	public static int _0023_003DzPfA3Uw7vkcjX8tmk6mF4leo_003D(int _0023_003Dzq80RbjQ_003D)
	{
		return _0023_003DzIDt9xZyyxSpoFEN_zy6XL4fUJaTw207rAA_003D_003D(_0023_003Dzq80RbjQ_003D + 4);
	}

	protected static byte[] _0023_003DzRADJbtBEzYdc0hhgwyms4FJylaHls5E4KQ_003D_003D(long _0023_003Dzq80RbjQ_003D)
	{
		byte[] array = new byte[8];
		_0023_003Dz9V2T1xUBu5KDdlKT3g_003D_003D(_0023_003Dzq80RbjQ_003D, array, 0);
		return array;
	}

	protected static void _0023_003Dz9V2T1xUBu5KDdlKT3g_003D_003D(long _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D] = (byte)_0023_003Dzq80RbjQ_003D;
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 1] = (byte)(_0023_003Dzq80RbjQ_003D >> 8);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 2] = (byte)(_0023_003Dzq80RbjQ_003D >> 16);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 3] = (byte)(_0023_003Dzq80RbjQ_003D >> 24);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 4] = (byte)(_0023_003Dzq80RbjQ_003D >> 32);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 5] = (byte)(_0023_003Dzq80RbjQ_003D >> 40);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 6] = (byte)(_0023_003Dzq80RbjQ_003D >> 48);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 7] = (byte)(_0023_003Dzq80RbjQ_003D >> 56);
	}

	protected static int _0023_003DzrjUa6ufn96h0LfoNASi2lhZjv4UqxBJdLQ_003D_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		return _0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D] | (_0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + 1] << 8) | (_0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + 2] << 16) | (_0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + 3] << 24);
	}

	protected static void _0023_003DzrML1ciJWslaZSSMhwwGpjbciso5k_0024djbHA_003D_003D(int _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D] = (byte)_0023_003Dzq80RbjQ_003D;
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 1] = (byte)(_0023_003Dzq80RbjQ_003D >> 8);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 2] = (byte)(_0023_003Dzq80RbjQ_003D >> 16);
		_0023_003DzZzVr6_0024U_003D[_0023_003Dz7hRN5Rg_003D + 3] = (byte)(_0023_003Dzq80RbjQ_003D >> 24);
	}

	protected byte[] _0023_003DzzbA91WKeCBMbNibzdeL7HDfdb_00246qUxDBRjg_00247zDof9N4(byte[] _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003DzZzVr6_0024U_003D)
		{
			SymmetricAlgorithm[] array = this._0023_003Dzq80RbjQ_003D;
			foreach (SymmetricAlgorithm symmetricAlgorithm in array)
			{
				if (_0023_003DzZzVr6_0024U_003D)
				{
					using ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateEncryptor();
					_0023_003Dzq80RbjQ_003D = cryptoTransform.TransformFinalBlock(_0023_003Dzq80RbjQ_003D, 0, _0023_003Dzq80RbjQ_003D.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform2 = symmetricAlgorithm.CreateDecryptor();
					_0023_003Dzq80RbjQ_003D = cryptoTransform2.TransformFinalBlock(_0023_003Dzq80RbjQ_003D, 0, _0023_003Dzq80RbjQ_003D.Length);
				}
				_0023_003DzZzVr6_0024U_003D = !_0023_003DzZzVr6_0024U_003D;
			}
		}
		else
		{
			for (int num = 4; num >= 0; num--)
			{
				SymmetricAlgorithm symmetricAlgorithm2 = this._0023_003Dzq80RbjQ_003D[num];
				if (_0023_003DzZzVr6_0024U_003D)
				{
					using ICryptoTransform cryptoTransform3 = symmetricAlgorithm2.CreateEncryptor();
					_0023_003Dzq80RbjQ_003D = cryptoTransform3.TransformFinalBlock(_0023_003Dzq80RbjQ_003D, 0, _0023_003Dzq80RbjQ_003D.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform4 = symmetricAlgorithm2.CreateDecryptor();
					_0023_003Dzq80RbjQ_003D = cryptoTransform4.TransformFinalBlock(_0023_003Dzq80RbjQ_003D, 0, _0023_003Dzq80RbjQ_003D.Length);
				}
				_0023_003DzZzVr6_0024U_003D = !_0023_003DzZzVr6_0024U_003D;
			}
		}
		return _0023_003Dzq80RbjQ_003D;
	}
}
