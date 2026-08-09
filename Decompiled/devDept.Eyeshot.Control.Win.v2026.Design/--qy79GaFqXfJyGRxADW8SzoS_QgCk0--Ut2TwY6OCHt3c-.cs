using System.Security.Cryptography;

internal abstract class _0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D
{
	private readonly SymmetricAlgorithm[] _0023_003Dz9jrlnWk_003D;

	public _0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D(byte[] _0023_003Dz9jrlnWk_003D, long _0023_003DzBxpHhQ0_003D)
		: this(_0023_003Dz9jrlnWk_003D, _0023_003DzI3hRUO71UPPMtII0Gk_2aSevsAZDdS27ZQ_003D_003D(_0023_003DzBxpHhQ0_003D))
	{
	}

	public _0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D(byte[] _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D)
	{
		_0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D _0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D2 = new _0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, 1);
		SymmetricAlgorithm[] array = new SymmetricAlgorithm[5];
		for (int i = 0; i < 5; i++)
		{
			_0023_003Dq9tIt1z5U8kopb592jTl1DgA9u2kp_0024622BydDm5TyDiQ_003D _0023_003Dq9tIt1z5U8kopb592jTl1DgA9u2kp_0024622BydDm5TyDiQ_003D2 = new _0023_003Dq9tIt1z5U8kopb592jTl1DgA9u2kp_0024622BydDm5TyDiQ_003D(new _0023_003DqWVl3k9o_0024NafWYkhLm3BXUB0mDGzfTKh_0024jwqhBvM5xhw_003D());
			_0023_003Dq9tIt1z5U8kopb592jTl1DgA9u2kp_0024622BydDm5TyDiQ_003D2.Key = _0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D2.GetBytes(_0023_003Dq9tIt1z5U8kopb592jTl1DgA9u2kp_0024622BydDm5TyDiQ_003D2.KeySize / 8);
			_0023_003Dq9tIt1z5U8kopb592jTl1DgA9u2kp_0024622BydDm5TyDiQ_003D2.IV = _0023_003Dq_O99az3cTQJ8_0024lj7V4s7PmjNlIlBxyniRhYIElYTO78_003D2.GetBytes(_0023_003Dq9tIt1z5U8kopb592jTl1DgA9u2kp_0024622BydDm5TyDiQ_003D2._0023_003Dzbk8G82zJwQJqQ_fPzZxp4ho_003D() / 8);
			array[i] = _0023_003Dq9tIt1z5U8kopb592jTl1DgA9u2kp_0024622BydDm5TyDiQ_003D2;
		}
		this._0023_003Dz9jrlnWk_003D = array;
	}

	protected static int _0023_003Dzs_0024dhD3VDmuZBAEmkLNN6hwccqmA1QIDdQQ_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		return (_0023_003Dz9jrlnWk_003D + 3) / 4 * 4;
	}

	public static int _0023_003DzoJTaTomf7RYLavkod89ufvU_003D(int _0023_003Dz9jrlnWk_003D)
	{
		return _0023_003Dzs_0024dhD3VDmuZBAEmkLNN6hwccqmA1QIDdQQ_003D_003D(_0023_003Dz9jrlnWk_003D + 4);
	}

	protected static byte[] _0023_003DzI3hRUO71UPPMtII0Gk_2aSevsAZDdS27ZQ_003D_003D(long _0023_003Dz9jrlnWk_003D)
	{
		byte[] array = new byte[8];
		_0023_003DzhBqNzicPJnlQ0WRIHA_003D_003D(_0023_003Dz9jrlnWk_003D, array, 0);
		return array;
	}

	protected static void _0023_003DzhBqNzicPJnlQ0WRIHA_003D_003D(long _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D] = (byte)_0023_003Dz9jrlnWk_003D;
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 1] = (byte)(_0023_003Dz9jrlnWk_003D >> 8);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 2] = (byte)(_0023_003Dz9jrlnWk_003D >> 16);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 3] = (byte)(_0023_003Dz9jrlnWk_003D >> 24);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 4] = (byte)(_0023_003Dz9jrlnWk_003D >> 32);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 5] = (byte)(_0023_003Dz9jrlnWk_003D >> 40);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 6] = (byte)(_0023_003Dz9jrlnWk_003D >> 48);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 7] = (byte)(_0023_003Dz9jrlnWk_003D >> 56);
	}

	protected static int _0023_003DzdRRkGDsZaP3G5AkIzRltb15Dve13RRWZ7Q_003D_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		return _0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D] | (_0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + 1] << 8) | (_0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + 2] << 16) | (_0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + 3] << 24);
	}

	protected static void _0023_003DzUTn0_rl_zc8hy_cVc3iSvEvT_0024S9Im0iP9w_003D_003D(int _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D] = (byte)_0023_003Dz9jrlnWk_003D;
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 1] = (byte)(_0023_003Dz9jrlnWk_003D >> 8);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 2] = (byte)(_0023_003Dz9jrlnWk_003D >> 16);
		_0023_003DzBxpHhQ0_003D[_0023_003Dztgqm2r4_003D + 3] = (byte)(_0023_003Dz9jrlnWk_003D >> 24);
	}

	protected byte[] _0023_003Dz_0024KOjyQxhEv4NBoFgjLj0bqYoYE1X4KjLIVlM0O_667bO(byte[] _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003DzBxpHhQ0_003D)
		{
			SymmetricAlgorithm[] array = this._0023_003Dz9jrlnWk_003D;
			foreach (SymmetricAlgorithm symmetricAlgorithm in array)
			{
				if (_0023_003DzBxpHhQ0_003D)
				{
					using ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateEncryptor();
					_0023_003Dz9jrlnWk_003D = cryptoTransform.TransformFinalBlock(_0023_003Dz9jrlnWk_003D, 0, _0023_003Dz9jrlnWk_003D.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform2 = symmetricAlgorithm.CreateDecryptor();
					_0023_003Dz9jrlnWk_003D = cryptoTransform2.TransformFinalBlock(_0023_003Dz9jrlnWk_003D, 0, _0023_003Dz9jrlnWk_003D.Length);
				}
				_0023_003DzBxpHhQ0_003D = !_0023_003DzBxpHhQ0_003D;
			}
		}
		else
		{
			for (int num = 4; num >= 0; num--)
			{
				SymmetricAlgorithm symmetricAlgorithm2 = this._0023_003Dz9jrlnWk_003D[num];
				if (_0023_003DzBxpHhQ0_003D)
				{
					using ICryptoTransform cryptoTransform3 = symmetricAlgorithm2.CreateEncryptor();
					_0023_003Dz9jrlnWk_003D = cryptoTransform3.TransformFinalBlock(_0023_003Dz9jrlnWk_003D, 0, _0023_003Dz9jrlnWk_003D.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform4 = symmetricAlgorithm2.CreateDecryptor();
					_0023_003Dz9jrlnWk_003D = cryptoTransform4.TransformFinalBlock(_0023_003Dz9jrlnWk_003D, 0, _0023_003Dz9jrlnWk_003D.Length);
				}
				_0023_003DzBxpHhQ0_003D = !_0023_003DzBxpHhQ0_003D;
			}
		}
		return _0023_003Dz9jrlnWk_003D;
	}
}
