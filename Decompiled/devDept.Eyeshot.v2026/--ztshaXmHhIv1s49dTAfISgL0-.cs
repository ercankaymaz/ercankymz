using System;

internal sealed class _0023_003DztshaXmHhIv1s49dTAfISgL0_003D : _0023_003Dz7EU3jafgrAIj0FjRJ8wRX1Q_003D
{
	protected _0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D _0023_003Dzp2TN3fQ_003D = (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)1;

	public _0023_003DztshaXmHhIv1s49dTAfISgL0_003D(uint _0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, _0023_003Dzx5fE0Zn26f8WRpa4yw_003D_003D _0023_003DzHFWw_0024Winsv58, _0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D _0023_003DzgyaA9s0_003D, ulong _0023_003DzoLNS3E1Pxgua)
		: base(_0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, _0023_003DzHFWw_0024Winsv58, (_0023_003DzgyaA9s0_003D == (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)1) ? 4u : 8u, _0023_003DzoLNS3E1Pxgua)
	{
		_0023_003Dzp2TN3fQ_003D = _0023_003DzgyaA9s0_003D;
	}

	public override ulong _0023_003DzlR6_0024bFKxIO9L(byte[] _0023_003DzK42AOhaAnl4C, ulong _0023_003DzNYxlP17PRu00, ulong _0023_003Dzv1TeLYMxx2me)
	{
		ulong num = _0023_003Dzc_00245BnRNRPPXZ._0023_003Dzu8sgotQ_003D() - _0023_003Dzc_00245BnRNRPPXZ._0023_003DzQwZDbJQ_003D();
		int num2 = ((_0023_003Dzp2TN3fQ_003D == (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)1) ? 4 : 8);
		if (_0023_003DzNYxlP17PRu00 != 0L)
		{
			throw new Exception();
		}
		ulong num3 = (_0023_003Dzv1TeLYMxx2me - _0023_003DzNYxlP17PRu00) / (ulong)(8L * (long)num2);
		if (num > num3)
		{
			num = num3;
		}
		if (num > _0023_003DziZiYS_Z2g6V4 - _0023_003Dz2F1zp4WtKF3x)
		{
			num = _0023_003DziZiYS_Z2g6V4 - _0023_003Dz2F1zp4WtKF3x;
		}
		if (_0023_003Dzp2TN3fQ_003D == (_0023_003Dz6zJlTnWVwHWB2xe30Q_003D_003D)1)
		{
			for (int i = 0; i < (int)num; i++)
			{
				float _0023_003DzPzO_0024GUk_003D = BitConverter.ToSingle(_0023_003DzK42AOhaAnl4C, i * 4);
				_0023_003Dzc_00245BnRNRPPXZ._0023_003DzdLGjQe3xeeDR(_0023_003DzPzO_0024GUk_003D);
			}
		}
		else
		{
			for (int j = 0; j < (int)num; j++)
			{
				double _0023_003DzPzO_0024GUk_003D2 = BitConverter.ToDouble(_0023_003DzK42AOhaAnl4C, j * 8);
				_0023_003Dzc_00245BnRNRPPXZ._0023_003DzDrwnt2xABXvo(_0023_003DzPzO_0024GUk_003D2);
			}
		}
		_0023_003Dz2F1zp4WtKF3x += num;
		return num * 8 * (ulong)num2;
	}
}
