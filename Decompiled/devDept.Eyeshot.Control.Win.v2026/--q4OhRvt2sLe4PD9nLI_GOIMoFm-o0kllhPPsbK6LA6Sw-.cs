using System;

internal sealed class _0023_003Dq4OhRvt2sLe4PD9nLI_GOIMoFm_0024o0kllhPPsbK6LA6Sw_003D : _0023_003Dq3ipWst5_59XwJtJhoIr2KZVbV_29OF3acY8jFebyfDw_003D
{
	public _0023_003Dq4OhRvt2sLe4PD9nLI_GOIMoFm_0024o0kllhPPsbK6LA6Sw_003D(byte[] _0023_003DzjYYAPCA_003D, long _0023_003DzVC9FBdo_003D)
		: base(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D)
	{
	}

	public byte[] _0023_003DzUkPPuiIBkLbiKzilkzg1OsAgdW_s(_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DzjYYAPCA_003D, _0023_003Dq7Y_X1LJ_wwdl9r12hZAPJW0Nk5TC7bPnt56l4Szt8fw_003D _0023_003DzVC9FBdo_003D)
	{
		byte[] array = new byte[4];
		_0023_003DzDXepVL3TAYidm2bAyw_003D_003D(_0023_003DzjYYAPCA_003D, array, 0, array.Length);
		int num = _0023_003Dq3ipWst5_59XwJtJhoIr2KZVbV_29OF3acY8jFebyfDw_003D._0023_003DzfyRxTp6DV6zkxXpmbx_0024YE7IbfBjs8k4y_0024A_003D_003D(_0023_003Dzy4lEpQfImivZO_Ju1Zm9qRRtVJ6BG38q2WvzidsSn9eV(array, _0023_003DzVC9FBdo_003D: false), 0);
		int num2 = _0023_003Dq3ipWst5_59XwJtJhoIr2KZVbV_29OF3acY8jFebyfDw_003D._0023_003DzE8ZqUKqP0by6F02RxvOAQYQ_003D(num);
		int value = num2 - 4;
		byte[] array2 = new byte[num2];
		_0023_003DzDXepVL3TAYidm2bAyw_003D_003D(_0023_003DzjYYAPCA_003D, array2, 4, value);
		Buffer.BlockCopy(array, 0, array2, 0, 4);
		byte[] src = _0023_003Dzy4lEpQfImivZO_Ju1Zm9qRRtVJ6BG38q2WvzidsSn9eV(array2, _0023_003DzVC9FBdo_003D: false);
		byte[] array3 = new byte[num];
		Buffer.BlockCopy(src, 4, array3, 0, num);
		return array3;
	}

	public byte[] _0023_003DzzrrmONg3p_liCs_Qb_0024rS9bCdV779(byte[] _0023_003DzjYYAPCA_003D)
	{
		byte[] src = _0023_003Dzy4lEpQfImivZO_Ju1Zm9qRRtVJ6BG38q2WvzidsSn9eV(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D: false);
		int num = _0023_003Dq3ipWst5_59XwJtJhoIr2KZVbV_29OF3acY8jFebyfDw_003D._0023_003DzfyRxTp6DV6zkxXpmbx_0024YE7IbfBjs8k4y_0024A_003D_003D(src, 0);
		byte[] array = new byte[num];
		Buffer.BlockCopy(src, 4, array, 0, num);
		return array;
	}

	private static void _0023_003DzDXepVL3TAYidm2bAyw_003D_003D(_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, int? _0023_003Dzf4Pqh9s_003D)
	{
		int num = _0023_003Dzf4Pqh9s_003D ?? (_0023_003DzVC9FBdo_003D.Length - _0023_003DzwBouG0w_003D);
		int num2;
		while ((num2 = _0023_003DzjYYAPCA_003D._0023_003DzOVN4VvoLFL2S9tW2hEeVpby89pOXbMnEKyWxF7sXdkjazNQBxn_0024MlbVfdzFAEhNpVwGKfA5miLbFebKbcQ_003D_003D(_0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, num)) > 0)
		{
			_0023_003DzwBouG0w_003D += num2;
			num -= num2;
		}
	}
}
