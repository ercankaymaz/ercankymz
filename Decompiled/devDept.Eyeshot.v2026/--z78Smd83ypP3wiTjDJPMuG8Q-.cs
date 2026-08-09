using System;

internal sealed class _0023_003Dz78Smd83ypP3wiTjDJPMuG8Q_003D
{
	private double _0023_003DzBJv2Q0MuxxyABVMWscJYrne4Xmi1;

	private double _0023_003DzmhmrMpH8qR8QUB5ZS8lP8YnC6QL0;

	public _0023_003Dz78Smd83ypP3wiTjDJPMuG8Q_003D()
	{
	}

	public _0023_003Dz78Smd83ypP3wiTjDJPMuG8Q_003D(double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzMROw3BBhqaNLucmp58KIJoc_003D(_0023_003DzF7v9r2A_003D);
		_0023_003DzAtnM578dyaUzmecAXKNZZ7s_003D(_0023_003Dz8dK2uhU_003D);
	}

	public double _0023_003Dzzz_00242i8I9uCGJLbssgu7qw6w_003D()
	{
		return _0023_003DzBJv2Q0MuxxyABVMWscJYrne4Xmi1;
	}

	public void _0023_003DzMROw3BBhqaNLucmp58KIJoc_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzBJv2Q0MuxxyABVMWscJYrne4Xmi1 = _0023_003DzPzO_0024GUk_003D;
	}

	public double _0023_003DzlTI6_ckvE3byRUobHtnxqvg_003D()
	{
		return _0023_003DzmhmrMpH8qR8QUB5ZS8lP8YnC6QL0;
	}

	public void _0023_003DzAtnM578dyaUzmecAXKNZZ7s_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzmhmrMpH8qR8QUB5ZS8lP8YnC6QL0 = _0023_003DzPzO_0024GUk_003D;
	}

	public override bool Equals(object _0023_003DzCX9Hbao_003D)
	{
		if (_0023_003DzCX9Hbao_003D is _0023_003Dz78Smd83ypP3wiTjDJPMuG8Q_003D _0023_003Dz78Smd83ypP3wiTjDJPMuG8Q_003D2)
		{
			if (_0023_003Dzzz_00242i8I9uCGJLbssgu7qw6w_003D() == _0023_003Dz78Smd83ypP3wiTjDJPMuG8Q_003D2._0023_003Dzzz_00242i8I9uCGJLbssgu7qw6w_003D())
			{
				return _0023_003DzlTI6_ckvE3byRUobHtnxqvg_003D() == _0023_003Dz78Smd83ypP3wiTjDJPMuG8Q_003D2._0023_003DzlTI6_ckvE3byRUobHtnxqvg_003D();
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (527 + BitConverter.DoubleToInt64Bits(_0023_003Dzzz_00242i8I9uCGJLbssgu7qw6w_003D()).GetHashCode()) * 31 + BitConverter.DoubleToInt64Bits(_0023_003DzlTI6_ckvE3byRUobHtnxqvg_003D()).GetHashCode();
	}
}
