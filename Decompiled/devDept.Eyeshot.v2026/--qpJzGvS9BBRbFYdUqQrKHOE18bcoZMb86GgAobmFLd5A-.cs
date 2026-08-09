using System.Security.Cryptography;

internal abstract class _0023_003DqpJzGvS9BBRbFYdUqQrKHOE18bcoZMb86GgAobmFLd5A_003D
{
	private readonly SymmetricAlgorithm[] _0023_003DziDLVpbY_003D;

	public _0023_003DqpJzGvS9BBRbFYdUqQrKHOE18bcoZMb86GgAobmFLd5A_003D(byte[] _0023_003DziDLVpbY_003D, long _0023_003Dz5rQzobg_003D)
		: this(_0023_003DziDLVpbY_003D, _0023_003DzbYFx5MU9_002434QMXEjIo_IJxINxtEGCANxxA_003D_003D(_0023_003Dz5rQzobg_003D))
	{
	}

	public _0023_003DqpJzGvS9BBRbFYdUqQrKHOE18bcoZMb86GgAobmFLd5A_003D(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D)
	{
		_0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D2 = new _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, 1);
		SymmetricAlgorithm[] array = new SymmetricAlgorithm[5];
		for (int i = 0; i < 5; i++)
		{
			_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D _0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D2 = new _0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D(new _0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D());
			_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D2.Key = _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D2.GetBytes(_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D2.KeySize / 8);
			_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D2.IV = _0023_003Dqm4OzGfMTlpmRe0y2Z__0024bCb1978Op8ElpgDYdvvWXkf0_003D2.GetBytes(_0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D2._0023_003Dz7Mma8g0M4x5oxCURI3UoRMQ_003D() / 8);
			array[i] = _0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D2;
		}
		this._0023_003DziDLVpbY_003D = array;
	}

	protected static int _0023_003Dz3Mnz3VsarejnX2b_0024ftcuinThEywDrafiBw_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		return (_0023_003DziDLVpbY_003D + 3) / 4 * 4;
	}

	public static int _0023_003DzDBXut6tCvgc0S1YNOJSraJU_003D(int _0023_003DziDLVpbY_003D)
	{
		return _0023_003Dz3Mnz3VsarejnX2b_0024ftcuinThEywDrafiBw_003D_003D(_0023_003DziDLVpbY_003D + 4);
	}

	protected static byte[] _0023_003DzbYFx5MU9_002434QMXEjIo_IJxINxtEGCANxxA_003D_003D(long _0023_003DziDLVpbY_003D)
	{
		byte[] array = new byte[8];
		_0023_003DzhvnooJLIqeOHL4pqZQ_003D_003D(_0023_003DziDLVpbY_003D, array, 0);
		return array;
	}

	protected static void _0023_003DzhvnooJLIqeOHL4pqZQ_003D_003D(long _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D] = (byte)_0023_003DziDLVpbY_003D;
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 1] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 2] = (byte)(_0023_003DziDLVpbY_003D >> 16);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 3] = (byte)(_0023_003DziDLVpbY_003D >> 24);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 4] = (byte)(_0023_003DziDLVpbY_003D >> 32);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 5] = (byte)(_0023_003DziDLVpbY_003D >> 40);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 6] = (byte)(_0023_003DziDLVpbY_003D >> 48);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 7] = (byte)(_0023_003DziDLVpbY_003D >> 56);
	}

	protected static int _0023_003DzWAwCHLeE7K6SG0xdk_0024BqNkOvS4rbLrPZmw_003D_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		return _0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D] | (_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 1] << 8) | (_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 2] << 16) | (_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + 3] << 24);
	}

	protected static void _0023_003DzpyEFmfdbA6Q1HqlYJs5A9JpJC8jdge5mxw_003D_003D(int _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D] = (byte)_0023_003DziDLVpbY_003D;
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 1] = (byte)(_0023_003DziDLVpbY_003D >> 8);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 2] = (byte)(_0023_003DziDLVpbY_003D >> 16);
		_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 3] = (byte)(_0023_003DziDLVpbY_003D >> 24);
	}

	protected byte[] _0023_003DzCMZJGTujzHLQeuSVipqhrDv6DjxHipJmfA1rDn2gfZFi(byte[] _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003Dz5rQzobg_003D)
		{
			SymmetricAlgorithm[] array = this._0023_003DziDLVpbY_003D;
			foreach (SymmetricAlgorithm symmetricAlgorithm in array)
			{
				if (_0023_003Dz5rQzobg_003D)
				{
					using ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateEncryptor();
					_0023_003DziDLVpbY_003D = cryptoTransform.TransformFinalBlock(_0023_003DziDLVpbY_003D, 0, _0023_003DziDLVpbY_003D.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform2 = symmetricAlgorithm.CreateDecryptor();
					_0023_003DziDLVpbY_003D = cryptoTransform2.TransformFinalBlock(_0023_003DziDLVpbY_003D, 0, _0023_003DziDLVpbY_003D.Length);
				}
				_0023_003Dz5rQzobg_003D = !_0023_003Dz5rQzobg_003D;
			}
		}
		else
		{
			for (int num = 4; num >= 0; num--)
			{
				SymmetricAlgorithm symmetricAlgorithm2 = this._0023_003DziDLVpbY_003D[num];
				if (_0023_003Dz5rQzobg_003D)
				{
					using ICryptoTransform cryptoTransform3 = symmetricAlgorithm2.CreateEncryptor();
					_0023_003DziDLVpbY_003D = cryptoTransform3.TransformFinalBlock(_0023_003DziDLVpbY_003D, 0, _0023_003DziDLVpbY_003D.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform4 = symmetricAlgorithm2.CreateDecryptor();
					_0023_003DziDLVpbY_003D = cryptoTransform4.TransformFinalBlock(_0023_003DziDLVpbY_003D, 0, _0023_003DziDLVpbY_003D.Length);
				}
				_0023_003Dz5rQzobg_003D = !_0023_003Dz5rQzobg_003D;
			}
		}
		return _0023_003DziDLVpbY_003D;
	}
}
