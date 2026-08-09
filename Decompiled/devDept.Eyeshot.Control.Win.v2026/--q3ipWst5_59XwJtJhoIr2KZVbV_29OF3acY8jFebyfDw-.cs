using System.Security.Cryptography;

internal abstract class _0023_003Dq3ipWst5_59XwJtJhoIr2KZVbV_29OF3acY8jFebyfDw_003D
{
	private readonly SymmetricAlgorithm[] _0023_003DzjYYAPCA_003D;

	public _0023_003Dq3ipWst5_59XwJtJhoIr2KZVbV_29OF3acY8jFebyfDw_003D(byte[] _0023_003DzjYYAPCA_003D, long _0023_003DzVC9FBdo_003D)
		: this(_0023_003DzjYYAPCA_003D, _0023_003DzaRPbPgSkeX6s1wJLS6KoLPOVoMNK0rF64A_003D_003D(_0023_003DzVC9FBdo_003D))
	{
	}

	public _0023_003Dq3ipWst5_59XwJtJhoIr2KZVbV_29OF3acY8jFebyfDw_003D(byte[] _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D)
	{
		_0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D _0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D2 = new _0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, 1);
		SymmetricAlgorithm[] array = new SymmetricAlgorithm[5];
		for (int i = 0; i < 5; i++)
		{
			_0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D _0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D2 = new _0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D(new _0023_003DqHG1TmG_0024dSF7XquINMc2Zz8FOS8zDlD6LmCMSxAsIMxk_003D());
			_0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D2.Key = _0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D2.GetBytes(_0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D2.KeySize / 8);
			_0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D2.IV = _0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D2.GetBytes(_0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D2._0023_003DztYcYBAC4dcSo6fQS7a0CWBo_003D() / 8);
			array[i] = _0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D2;
		}
		this._0023_003DzjYYAPCA_003D = array;
	}

	protected static int _0023_003DzGuYKDkyWBGmkkK_0024Dl4HgB_3ssiA76hLv1w_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		return (_0023_003DzjYYAPCA_003D + 3) / 4 * 4;
	}

	public static int _0023_003DzE8ZqUKqP0by6F02RxvOAQYQ_003D(int _0023_003DzjYYAPCA_003D)
	{
		return _0023_003DzGuYKDkyWBGmkkK_0024Dl4HgB_3ssiA76hLv1w_003D_003D(_0023_003DzjYYAPCA_003D + 4);
	}

	protected static byte[] _0023_003DzaRPbPgSkeX6s1wJLS6KoLPOVoMNK0rF64A_003D_003D(long _0023_003DzjYYAPCA_003D)
	{
		byte[] array = new byte[8];
		_0023_003Dzy1hmSgJZgjx_r9REMQ_003D_003D(_0023_003DzjYYAPCA_003D, array, 0);
		return array;
	}

	protected static void _0023_003Dzy1hmSgJZgjx_r9REMQ_003D_003D(long _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D] = (byte)_0023_003DzjYYAPCA_003D;
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 1] = (byte)(_0023_003DzjYYAPCA_003D >> 8);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 2] = (byte)(_0023_003DzjYYAPCA_003D >> 16);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 3] = (byte)(_0023_003DzjYYAPCA_003D >> 24);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 4] = (byte)(_0023_003DzjYYAPCA_003D >> 32);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 5] = (byte)(_0023_003DzjYYAPCA_003D >> 40);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 6] = (byte)(_0023_003DzjYYAPCA_003D >> 48);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 7] = (byte)(_0023_003DzjYYAPCA_003D >> 56);
	}

	protected static int _0023_003DzfyRxTp6DV6zkxXpmbx_0024YE7IbfBjs8k4y_0024A_003D_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		return _0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D] | (_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 1] << 8) | (_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 2] << 16) | (_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + 3] << 24);
	}

	protected static void _0023_003DzkWDUGZ1z2ZO8LiBfHZpe_0024ScE4xgQzOhpNA_003D_003D(int _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D] = (byte)_0023_003DzjYYAPCA_003D;
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 1] = (byte)(_0023_003DzjYYAPCA_003D >> 8);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 2] = (byte)(_0023_003DzjYYAPCA_003D >> 16);
		_0023_003DzVC9FBdo_003D[_0023_003DzwBouG0w_003D + 3] = (byte)(_0023_003DzjYYAPCA_003D >> 24);
	}

	protected byte[] _0023_003Dzy4lEpQfImivZO_Ju1Zm9qRRtVJ6BG38q2WvzidsSn9eV(byte[] _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzVC9FBdo_003D)
		{
			SymmetricAlgorithm[] array = this._0023_003DzjYYAPCA_003D;
			foreach (SymmetricAlgorithm symmetricAlgorithm in array)
			{
				if (_0023_003DzVC9FBdo_003D)
				{
					using ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateEncryptor();
					_0023_003DzjYYAPCA_003D = cryptoTransform.TransformFinalBlock(_0023_003DzjYYAPCA_003D, 0, _0023_003DzjYYAPCA_003D.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform2 = symmetricAlgorithm.CreateDecryptor();
					_0023_003DzjYYAPCA_003D = cryptoTransform2.TransformFinalBlock(_0023_003DzjYYAPCA_003D, 0, _0023_003DzjYYAPCA_003D.Length);
				}
				_0023_003DzVC9FBdo_003D = !_0023_003DzVC9FBdo_003D;
			}
		}
		else
		{
			for (int num = 4; num >= 0; num--)
			{
				SymmetricAlgorithm symmetricAlgorithm2 = this._0023_003DzjYYAPCA_003D[num];
				if (_0023_003DzVC9FBdo_003D)
				{
					using ICryptoTransform cryptoTransform3 = symmetricAlgorithm2.CreateEncryptor();
					_0023_003DzjYYAPCA_003D = cryptoTransform3.TransformFinalBlock(_0023_003DzjYYAPCA_003D, 0, _0023_003DzjYYAPCA_003D.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform4 = symmetricAlgorithm2.CreateDecryptor();
					_0023_003DzjYYAPCA_003D = cryptoTransform4.TransformFinalBlock(_0023_003DzjYYAPCA_003D, 0, _0023_003DzjYYAPCA_003D.Length);
				}
				_0023_003DzVC9FBdo_003D = !_0023_003DzVC9FBdo_003D;
			}
		}
		return _0023_003DzjYYAPCA_003D;
	}
}
