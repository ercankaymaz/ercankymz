using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D : _0023_003DqgLKG65nYMoFTixsWbeZ91eF4pfF8y0U6Kcm9bS84M8A_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Stream _0023_003Dz5rQzobg_003D;

	public _0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D(Stream _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		this._0023_003Dz5rQzobg_003D = _0023_003DziDLVpbY_003D;
		this._0023_003DziDLVpbY_003D = _0023_003Dz5rQzobg_003D ^ -559030707;
	}

	public Stream _0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D()
	{
		return _0023_003Dz5rQzobg_003D;
	}

	[SpecialName]
	public override bool _0023_003DzZmS2S24ChN1wnkvFtQiEiiI6mLEokf_f7OnkClYx3lm_vaV_0024YtAEzTrETj_0024XsT3Fs3tXV_w_003D()
	{
		return _0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().CanRead;
	}

	[SpecialName]
	public override bool _0023_003DzWpbADLL4o6kgUq7wtkwgc6Ts7xNzexyhm3yYYoorSu8mGABRFiobQ7xDRwiDafuMK6Cr_OdlHBFd()
	{
		return _0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().CanSeek;
	}

	[SpecialName]
	public override bool _0023_003Dzh9EKEBxGXiCJwxkbztzw4uEZWPCC57sbjdRx7L6YU2e0iPn1_0024rDVjT1xurLVS7nmml2swI8eal3Bu_rsTh6Tdl4_003D()
	{
		return _0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().CanWrite;
	}

	public override void _0023_003DzFtAD4jVL_F7USN8PT4Kx8dmyjUM6PkZ9RFfXsLYrEFa0G9DdYj1vKjg3mDzZWG73qteQwCMQsdD6tZF1qA_003D_003D()
	{
		_0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().Flush();
	}

	[SpecialName]
	public override long _0023_003DzraNgARjX4QSbGcrZYaUV_Kt5FJD_0024RmALGpou1doOgwLvbYwEh88yFgkavQ_0024_0024lIyzZM73DVaXA_e6k069AX2zF5I_003D()
	{
		return _0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().Length;
	}

	[SpecialName]
	public override long _0023_003Dzwl9sCcsvR4k6PzVcPKWWotTJzm4oD4gNUyoQC7OJjpk_00241M08s70UvYFNG9PxA9cCifL33i8_003D()
	{
		return _0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().Position;
	}

	[SpecialName]
	public override void _0023_003DzQZ8To03pqmaE0_0024_s_0024MPn8tSR4QVXl_JNjN3rTa3mIQ_UWPJ027H8ZJC6fkO7HSABoir32uY_003D(long _0023_003DziDLVpbY_003D)
	{
		_0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().Position = _0023_003DziDLVpbY_003D;
	}

	private byte _0023_003DzBGS6q1YXkao66mOfTCv8dFjSYRVNMXu4Q7gKx7g_003D(byte _0023_003DziDLVpbY_003D, uint _0023_003Dz5rQzobg_003D)
	{
		byte b = (byte)((uint)this._0023_003DziDLVpbY_003D ^ _0023_003Dz5rQzobg_003D);
		return (byte)(_0023_003DziDLVpbY_003D ^ b);
	}

	public override void _0023_003DznRraYymMBsP7i90bQMDED5umU3cS7uHX639nw6I84RHefV9Bq6xiU0PXLJI7rh8sUOby8z4QDbCtMrWW_vneQSE_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		uint num = (uint)_0023_003Dzwl9sCcsvR4k6PzVcPKWWotTJzm4oD4gNUyoQC7OJjpk_00241M08s70UvYFNG9PxA9cCifL33i8_003D();
		byte[] array = new byte[_0023_003DzAvn2b38_003D];
		for (uint num2 = 0u; num2 < _0023_003DzAvn2b38_003D; num2++)
		{
			array[num2] = _0023_003DzBGS6q1YXkao66mOfTCv8dFjSYRVNMXu4Q7gKx7g_003D(_0023_003DziDLVpbY_003D[num2 + _0023_003Dz5rQzobg_003D], num + num2);
		}
		_0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().Write(array, 0, _0023_003DzAvn2b38_003D);
	}

	public override int _0023_003Dzu_0024wz50Gq3LJ8xd5lgsToLbHhVCfptTZN7NjjPuQ1kWJGK38M7lFOyzt0sHhCoqpa_0024W_0024ZkwQgzp275i1d_A_003D_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		uint num = (uint)_0023_003Dzwl9sCcsvR4k6PzVcPKWWotTJzm4oD4gNUyoQC7OJjpk_00241M08s70UvYFNG9PxA9cCifL33i8_003D();
		int num2 = _0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().Read(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
		int num3 = _0023_003Dz5rQzobg_003D + num2;
		for (int i = _0023_003Dz5rQzobg_003D; i < num3; i++)
		{
			_0023_003DziDLVpbY_003D[i] = _0023_003DzBGS6q1YXkao66mOfTCv8dFjSYRVNMXu4Q7gKx7g_003D(_0023_003DziDLVpbY_003D[i], num++);
		}
		return num2;
	}

	public override long _0023_003DzUQ_bGErryTDpszeAu244IzixOQag9otlJo42_0024oeegDPivRgB6_0024XwD9KrkyM3tgZwAvXv4b_A7Pkg5OViPw_003D_003D(long _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D)
	{
		SeekOrigin origin = _0023_003Dz5rQzobg_003D switch
		{
			0 => SeekOrigin.Begin, 
			1 => SeekOrigin.Current, 
			2 => SeekOrigin.End, 
			_ => throw new ArgumentException(), 
		};
		return _0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().Seek(_0023_003DziDLVpbY_003D, origin);
	}

	public override void _0023_003DzoZOrTTafI92aUamlP8XOqT9r3cifR_9OhA3b8QszFM617Axh9aSZQp7SlAHVpjFwwQECGOJCTZacpYcqfGw5dDnN0ZJi(long _0023_003DziDLVpbY_003D)
	{
		_0023_003Dzb7HqvYYB0ff55GhpzauKpy_8flrzmYe6gC93wYA_003D().SetLength(_0023_003DziDLVpbY_003D);
	}
}
