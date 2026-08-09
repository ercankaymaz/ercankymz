using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D : _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Stream _0023_003DzZzVr6_0024U_003D;

	public _0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D(Stream _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		this._0023_003DzZzVr6_0024U_003D = _0023_003Dzq80RbjQ_003D;
		this._0023_003Dzq80RbjQ_003D = _0023_003DzZzVr6_0024U_003D ^ -559030707;
	}

	public Stream _0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D()
	{
		return _0023_003DzZzVr6_0024U_003D;
	}

	[SpecialName]
	public override bool _0023_003DzHFGE36X4nG8G46m87ZI49vnZCuVAnD4cLmEooV24GJj7PQlYvpARIVItXtBx2lFmv0RZ02M_003D()
	{
		return _0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().CanRead;
	}

	[SpecialName]
	public override bool _0023_003DzvMmIPP0H_S13CBVMIx3BuF_riMzeAsoTCpQsVefjLuYXUAXG6V8zFYCl_FDbqkaoTaOFi4Bjn40q()
	{
		return _0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().CanSeek;
	}

	[SpecialName]
	public override bool _0023_003DzITWEjiGogYkJOd7sGsxfYM4NvdseJGtNKCItLX4wwHqpu7_0024BbAc8iPG7cIU7Ap7sEPTHdaHxn6qM2faN5y_00245ovk_003D()
	{
		return _0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().CanWrite;
	}

	public override void _0023_003Dzv3klLckR6GYJ_db3LErj9FAuc7FerFKgy4mDcLFzMliLwIyQoTBvjFSuKoKK84_0024DEx_0024lTjeG4iW4Qw7V0w_003D_003D()
	{
		_0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().Flush();
	}

	[SpecialName]
	public override long _0023_003DzCw1_0024ldBjs0aUP3McccU_9Sjt_mWYXegwAz1XgjD5sZO2YJKkSww9WmC4Df0X_LF4W2M9EoA9a9fwM1Q04iTehag_003D()
	{
		return _0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().Length;
	}

	[SpecialName]
	public override long _0023_003DzobG9IxqhwRDSPcfxNOqGyLk4ZhoGqGKIxRc5EwzLMnMXwgfZ90nCXR8JGEQLK55L4VFmzy0_003D()
	{
		return _0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().Position;
	}

	[SpecialName]
	public override void _0023_003DzeAfqD85UAYY1g8prJCu4S9JwzuyBHOSQrVdSiwf3Lj4Gqu9mD0yaZmrEmeHhlRxoawLGCBo_003D(long _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().Position = _0023_003Dzq80RbjQ_003D;
	}

	private byte _0023_003DzKfX6OBHaiWEal7NQ7sxw_CIl9den1tyt0TSVTAY_003D(byte _0023_003Dzq80RbjQ_003D, uint _0023_003DzZzVr6_0024U_003D)
	{
		byte b = (byte)((uint)this._0023_003Dzq80RbjQ_003D ^ _0023_003DzZzVr6_0024U_003D);
		return (byte)(_0023_003Dzq80RbjQ_003D ^ b);
	}

	public override void _0023_003Dz8RZ33Qgc1tJw0mBVJCrKD61ZYjZ_2JLKozA0bEs8bzZG_0024m1mZPtBgdkXoQxvGRZlx8NlYDRO4jRTKwqrHM_0024Ebqg_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		uint num = (uint)_0023_003DzobG9IxqhwRDSPcfxNOqGyLk4ZhoGqGKIxRc5EwzLMnMXwgfZ90nCXR8JGEQLK55L4VFmzy0_003D();
		byte[] array = new byte[_0023_003Dz7hRN5Rg_003D];
		for (uint num2 = 0u; num2 < _0023_003Dz7hRN5Rg_003D; num2++)
		{
			array[num2] = _0023_003DzKfX6OBHaiWEal7NQ7sxw_CIl9den1tyt0TSVTAY_003D(_0023_003Dzq80RbjQ_003D[num2 + _0023_003DzZzVr6_0024U_003D], num + num2);
		}
		_0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().Write(array, 0, _0023_003Dz7hRN5Rg_003D);
	}

	public override int _0023_003DzJOoT4gsPGoibAzkPGQ31PpiYn_hZ3qvRCOxibWgYa3KnAQHxK9Wt69jVIDs25kwu05DuT1KcBeXXwLt8kA_003D_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		uint num = (uint)_0023_003DzobG9IxqhwRDSPcfxNOqGyLk4ZhoGqGKIxRc5EwzLMnMXwgfZ90nCXR8JGEQLK55L4VFmzy0_003D();
		int num2 = _0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().Read(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
		int num3 = _0023_003DzZzVr6_0024U_003D + num2;
		for (int i = _0023_003DzZzVr6_0024U_003D; i < num3; i++)
		{
			_0023_003Dzq80RbjQ_003D[i] = _0023_003DzKfX6OBHaiWEal7NQ7sxw_CIl9den1tyt0TSVTAY_003D(_0023_003Dzq80RbjQ_003D[i], num++);
		}
		return num2;
	}

	public override long _0023_003DzI4vE0RkXfN1pne8gbSVDgBlALYg3vbbRkBocu_0024P6sDNdA9J9PRaszMCsJP8vkAvSyWXjY_0024fkw_sdJCJA_0024Q_003D_003D(long _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		SeekOrigin origin = _0023_003DzZzVr6_0024U_003D switch
		{
			0 => SeekOrigin.Begin, 
			1 => SeekOrigin.Current, 
			2 => SeekOrigin.End, 
			_ => throw new ArgumentException(), 
		};
		return _0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().Seek(_0023_003Dzq80RbjQ_003D, origin);
	}

	public override void _0023_003Dzq9sSScLMecynoevHD3htzjHlhzPCWd35ZjYlubS52EE5NgIEEiUcOA7LMbh5g1u1_zQvc0laa9e6SQymmssF0Wb3ZxLL(long _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzttYyCGtJApU7Wr5FL1Jo8R_1GHi_0024BAf92aJ1stg_003D().SetLength(_0023_003Dzq80RbjQ_003D);
	}
}
