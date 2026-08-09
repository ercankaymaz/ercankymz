using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D : _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Stream _0023_003DzBxpHhQ0_003D;

	public _0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D(Stream _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		this._0023_003DzBxpHhQ0_003D = _0023_003Dz9jrlnWk_003D;
		this._0023_003Dz9jrlnWk_003D = _0023_003DzBxpHhQ0_003D ^ -559030707;
	}

	public Stream _0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D()
	{
		return _0023_003DzBxpHhQ0_003D;
	}

	[SpecialName]
	public override bool _0023_003DzjK5kKydld_cz6OMcWYuveIcRsC3DEUwsUJEjet12ggDhghMyDJs1ToxgWcnaztgQsVuh0vo_003D()
	{
		return _0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().CanRead;
	}

	[SpecialName]
	public override bool _0023_003DzwX11mF2T9N_0024q2RUO8GOB5Jcl_0024vC87a1tdddqF2Ze7Abi7AAbj2LBGnHuTb_D0bIJMeqAfZyIZO1Q()
	{
		return _0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().CanSeek;
	}

	[SpecialName]
	public override bool _0023_003DzNmGtzU4b3_nlB34INzYAY_0024n12E2he6A52NFrbLE3SlhX__HwyAGTso_0024bP_0024ZVetcOV7ujISxqBFqCxgspra8yPwY_003D()
	{
		return _0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().CanWrite;
	}

	public override void _0023_003DzhSa6k2ftcudYxyG1ZX3NfWbv4mjhSsPIMFkIgKNONjPBwv64ZKoTxJPxpzDSJzFVaqjc_ndc6xxnm4p6Vw_003D_003D()
	{
		_0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().Flush();
	}

	[SpecialName]
	public override long _0023_003Dz0O0V9w8_kQ0BXR7pipw_TeE_0024mwds2QcLM1eCMLEXnNNrcyRNFhfAZq8nMBVy5R5U21yPM54QEfEcLaoIAYOkj80_003D()
	{
		return _0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().Length;
	}

	[SpecialName]
	public override long _0023_003Dz_0024PxYTL_nlzJnpvFXwwRZmMj6PIfqbJZrp54foI9tn5jPksqeRkurekdA04xNnozUhhfo4rA_003D()
	{
		return _0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().Position;
	}

	[SpecialName]
	public override void _0023_003DzYoGHUZEwKTu13kV8l1r1tB_0024dht2uqAQcK2u4e7dZySI8XM__Dz3SaTmm5Rtni4wKX3rKkto_003D(long _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().Position = _0023_003Dz9jrlnWk_003D;
	}

	private byte _0023_003DzwknALH6Q35Z_HH_0024U003IoepioOIlnQK_00241J6ZSVc_003D(byte _0023_003Dz9jrlnWk_003D, uint _0023_003DzBxpHhQ0_003D)
	{
		byte b = (byte)((uint)this._0023_003Dz9jrlnWk_003D ^ _0023_003DzBxpHhQ0_003D);
		return (byte)(_0023_003Dz9jrlnWk_003D ^ b);
	}

	public override void _0023_003DzbSZaYZ8BSCEcshQRwBrSJEHG4NM2gaHw3u5ByyVi_0024wzLdCi0MuXQ3QPzKw1O5qhIQl4qZJ53qFAOx00aVIJmrrk_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		uint num = (uint)_0023_003Dz_0024PxYTL_nlzJnpvFXwwRZmMj6PIfqbJZrp54foI9tn5jPksqeRkurekdA04xNnozUhhfo4rA_003D();
		byte[] array = new byte[_0023_003Dztgqm2r4_003D];
		for (uint num2 = 0u; num2 < _0023_003Dztgqm2r4_003D; num2++)
		{
			array[num2] = _0023_003DzwknALH6Q35Z_HH_0024U003IoepioOIlnQK_00241J6ZSVc_003D(_0023_003Dz9jrlnWk_003D[num2 + _0023_003DzBxpHhQ0_003D], num + num2);
		}
		_0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().Write(array, 0, _0023_003Dztgqm2r4_003D);
	}

	public override int _0023_003DzulSx4Jx4Pj9eE81TPL1Iwudj2y0tGiYiNkUqLldPkK9oqhsQpYmtt9A1zPuRhvzmcjJb1LlRm9dF7M_002427A_003D_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		uint num = (uint)_0023_003Dz_0024PxYTL_nlzJnpvFXwwRZmMj6PIfqbJZrp54foI9tn5jPksqeRkurekdA04xNnozUhhfo4rA_003D();
		int num2 = _0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().Read(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
		int num3 = _0023_003DzBxpHhQ0_003D + num2;
		for (int i = _0023_003DzBxpHhQ0_003D; i < num3; i++)
		{
			_0023_003Dz9jrlnWk_003D[i] = _0023_003DzwknALH6Q35Z_HH_0024U003IoepioOIlnQK_00241J6ZSVc_003D(_0023_003Dz9jrlnWk_003D[i], num++);
		}
		return num2;
	}

	public override long _0023_003Dzz5uSZofwQCQyOcEKwfVQmiivZ_0024bgBfg6QfI4mYf6tHIC42rk18fkszOb_ezLTX5YRgaBPKGRm6aQTYVwBg_003D_003D(long _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		SeekOrigin origin = _0023_003DzBxpHhQ0_003D switch
		{
			0 => SeekOrigin.Begin, 
			1 => SeekOrigin.Current, 
			2 => SeekOrigin.End, 
			_ => throw new ArgumentException(), 
		};
		return _0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().Seek(_0023_003Dz9jrlnWk_003D, origin);
	}

	public override void _0023_003Dz3cEkCr6nJgH8VwhI82JooFSfsJeLHEtFiFLagsYbiZxMDGCmITnozlJPu20z5pu5aYTf9r3lF8GG85Nms1LW66ANhH3b(long _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dz28OkYbjFFnpRZMkM0t0w0QVQxKk7Xav4fIbw7mU_003D().SetLength(_0023_003Dz9jrlnWk_003D);
	}
}
