using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D : _0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Stream _0023_003DzVC9FBdo_003D;

	public _0023_003DqtbJxvJw6M0U0jdSJFXU4FnD5vd8DF0SCSwLmJknSUk8_003D(Stream _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		this._0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D;
		this._0023_003DzjYYAPCA_003D = _0023_003DzVC9FBdo_003D ^ -559030707;
	}

	public Stream _0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D()
	{
		return _0023_003DzVC9FBdo_003D;
	}

	[SpecialName]
	public override bool _0023_003Dz6LNiAXLEYQlQLhIkkSFj5ZQYE8rNPD_0024BXH6mpKJP2IT_0024SaA3nI9RmFOW32GicKEjvUQ06R4_003D()
	{
		return _0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().CanRead;
	}

	[SpecialName]
	public override bool _0023_003DzYdkhPjC_bnFruKiyolthzhcBKRUySfU87viCpZBvxOdbMkrNTBgbISTFYe_0024eUsqOLirln_0024dKhOfc()
	{
		return _0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().CanSeek;
	}

	[SpecialName]
	public override bool _0023_003DzNmGtzU4b3_nlB34INzYAY_0024n12E2he6A52NFrbLE3SlhX__HwyAGTso_0024bP_0024ZVetcOV7ujISxqBFqCxgspra8yPwY_003D()
	{
		return _0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().CanWrite;
	}

	public override void _0023_003DzMMoV2Utk9POZKrnfb5F4vmFD0tN_0024Gis9GPcUXK7SFb7QlEBuELfIiUNi7WU4ykteYlYgjUvI0BLeFAoRnA_003D_003D()
	{
		_0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().Flush();
	}

	[SpecialName]
	public override long _0023_003DzSo_gaJJm3gV22vwn_0024ZQKP2jkH1Wi8Q1d_0024iW8L0sqejJVZPcg9_XQ6lNh50Arlf2kDIcUyU9sztWajFgX9XnbyJg_003D()
	{
		return _0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().Length;
	}

	[SpecialName]
	public override long _0023_003DzVVh_VOOPvzE8OIDVjtj7IIyotysgSsjRp5iJTq6jEV_00246A2hzlq2gX1_0024tau7otE4P6cvwwsQ_003D()
	{
		return _0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().Position;
	}

	[SpecialName]
	public override void _0023_003Dzn_t9hyVATRPnUxdqXwaUj9BPcyICJFt_8Z7_002402XyW0bjVPch0w_YOa0C7Qx9nd4TCWcwQcY_003D(long _0023_003DzjYYAPCA_003D)
	{
		_0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().Position = _0023_003DzjYYAPCA_003D;
	}

	private byte _0023_003DzgNzanJqwiOPl9J_00240bnaQjJDZqJ_qwWB6LUYp66o_003D(byte _0023_003DzjYYAPCA_003D, uint _0023_003DzVC9FBdo_003D)
	{
		byte b = (byte)((uint)this._0023_003DzjYYAPCA_003D ^ _0023_003DzVC9FBdo_003D);
		return (byte)(_0023_003DzjYYAPCA_003D ^ b);
	}

	public override void _0023_003Dzf2o5xB36wl5j8THLGxH7GtetBjB_Blua0v44kb1Ad3tco7z7uPjB0jSEWmyHLYgvEjs9D4NDPX5ETcf08P3w5yw_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		uint num = (uint)_0023_003DzVVh_VOOPvzE8OIDVjtj7IIyotysgSsjRp5iJTq6jEV_00246A2hzlq2gX1_0024tau7otE4P6cvwwsQ_003D();
		byte[] array = new byte[_0023_003DzwBouG0w_003D];
		for (uint num2 = 0u; num2 < _0023_003DzwBouG0w_003D; num2++)
		{
			array[num2] = _0023_003DzgNzanJqwiOPl9J_00240bnaQjJDZqJ_qwWB6LUYp66o_003D(_0023_003DzjYYAPCA_003D[num2 + _0023_003DzVC9FBdo_003D], num + num2);
		}
		_0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().Write(array, 0, _0023_003DzwBouG0w_003D);
	}

	public override int _0023_003DzOVN4VvoLFL2S9tW2hEeVpby89pOXbMnEKyWxF7sXdkjazNQBxn_0024MlbVfdzFAEhNpVwGKfA5miLbFebKbcQ_003D_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		uint num = (uint)_0023_003DzVVh_VOOPvzE8OIDVjtj7IIyotysgSsjRp5iJTq6jEV_00246A2hzlq2gX1_0024tau7otE4P6cvwwsQ_003D();
		int num2 = _0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().Read(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
		int num3 = _0023_003DzVC9FBdo_003D + num2;
		for (int i = _0023_003DzVC9FBdo_003D; i < num3; i++)
		{
			_0023_003DzjYYAPCA_003D[i] = _0023_003DzgNzanJqwiOPl9J_00240bnaQjJDZqJ_qwWB6LUYp66o_003D(_0023_003DzjYYAPCA_003D[i], num++);
		}
		return num2;
	}

	public override long _0023_003DzF9bNse9wHJLLtepk_gT8nT7RoArbYZ5O7BM_0024pvRSfZZCcif09QuhqkEcicQBZU2Q_1FotqnGeCeOOleA6w_003D_003D(long _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		SeekOrigin origin = _0023_003DzVC9FBdo_003D switch
		{
			0 => SeekOrigin.Begin, 
			1 => SeekOrigin.Current, 
			2 => SeekOrigin.End, 
			_ => throw new ArgumentException(), 
		};
		return _0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().Seek(_0023_003DzjYYAPCA_003D, origin);
	}

	public override void _0023_003DzRlokVKuxX46IVyoBMh2LGpphiTHC0TFFk0H8Tx1NE1x002pfmkCt9vrGY6uCEUuw7Bncz2NmhNaufaVEn3rtierfB0iU(long _0023_003DzjYYAPCA_003D)
	{
		_0023_003DziOQRdFVVccrVqzlqDjuzTdGGD6Oc8IfV5PNrX04_003D().SetLength(_0023_003DzjYYAPCA_003D);
	}
}
