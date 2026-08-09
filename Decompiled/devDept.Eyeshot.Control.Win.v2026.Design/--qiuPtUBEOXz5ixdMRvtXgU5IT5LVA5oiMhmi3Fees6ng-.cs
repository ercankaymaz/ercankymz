using System;

internal sealed class _0023_003DqiuPtUBEOXz5ixdMRvtXgU5IT5LVA5oiMhmi3Fees6ng_003D : _0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D
{
	public _0023_003DqiuPtUBEOXz5ixdMRvtXgU5IT5LVA5oiMhmi3Fees6ng_003D(byte[] _0023_003Dz9jrlnWk_003D, long _0023_003DzBxpHhQ0_003D)
		: base(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D)
	{
	}

	public byte[] _0023_003DzDOPeMXI1OjHdm9Jn7PhQ_0024KMKrDz8(_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dz9jrlnWk_003D, _0023_003DqjP_cCVqr6eDH37DmNYzUTphG4q0kOPLZAtNf70T3TCs_003D _0023_003DzBxpHhQ0_003D)
	{
		byte[] array = new byte[4];
		_0023_003DzloDkWfWxYPMSv0kZVw_003D_003D(_0023_003Dz9jrlnWk_003D, array, 0, array.Length);
		int num = _0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D._0023_003DzdRRkGDsZaP3G5AkIzRltb15Dve13RRWZ7Q_003D_003D(_0023_003Dz_0024KOjyQxhEv4NBoFgjLj0bqYoYE1X4KjLIVlM0O_667bO(array, _0023_003DzBxpHhQ0_003D: false), 0);
		int num2 = _0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D._0023_003DzoJTaTomf7RYLavkod89ufvU_003D(num);
		int value = num2 - 4;
		byte[] array2 = new byte[num2];
		_0023_003DzloDkWfWxYPMSv0kZVw_003D_003D(_0023_003Dz9jrlnWk_003D, array2, 4, value);
		Buffer.BlockCopy(array, 0, array2, 0, 4);
		byte[] src = _0023_003Dz_0024KOjyQxhEv4NBoFgjLj0bqYoYE1X4KjLIVlM0O_667bO(array2, _0023_003DzBxpHhQ0_003D: false);
		byte[] array3 = new byte[num];
		Buffer.BlockCopy(src, 4, array3, 0, num);
		return array3;
	}

	public byte[] _0023_003DzUvdEgh6Avhi4LlMSLS7x47rekd0V(byte[] _0023_003Dz9jrlnWk_003D)
	{
		byte[] src = _0023_003Dz_0024KOjyQxhEv4NBoFgjLj0bqYoYE1X4KjLIVlM0O_667bO(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D: false);
		int num = _0023_003Dqy79GaFqXfJyGRxADW8SzoS_QgCk0_0024_0024Ut2TwY6OCHt3c_003D._0023_003DzdRRkGDsZaP3G5AkIzRltb15Dve13RRWZ7Q_003D_003D(src, 0);
		byte[] array = new byte[num];
		Buffer.BlockCopy(src, 4, array, 0, num);
		return array;
	}

	private static void _0023_003DzloDkWfWxYPMSv0kZVw_003D_003D(_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, int? _0023_003DzzKDx05I_003D)
	{
		int num = _0023_003DzzKDx05I_003D ?? (_0023_003DzBxpHhQ0_003D.Length - _0023_003Dztgqm2r4_003D);
		int num2;
		while ((num2 = _0023_003Dz9jrlnWk_003D._0023_003DzulSx4Jx4Pj9eE81TPL1Iwudj2y0tGiYiNkUqLldPkK9oqhsQpYmtt9A1zPuRhvzmcjJb1LlRm9dF7M_002427A_003D_003D(_0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, num)) > 0)
		{
			_0023_003Dztgqm2r4_003D += num2;
			num -= num2;
		}
	}
}
