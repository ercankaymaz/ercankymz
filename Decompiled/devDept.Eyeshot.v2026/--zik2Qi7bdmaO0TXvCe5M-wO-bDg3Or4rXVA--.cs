using System;
using System.Collections.Generic;

internal sealed class _0023_003Dzik2Qi7bdmaO0TXvCe5M_0024wO_0024bDg3Or4rXVA_003D_003D
{
	private Dictionary<int, _0023_003Dze40BN1DxW2tmFXIfi8Suvba61l6xx1d_mA_003D_003D> _0023_003DzCebvYKs4dpRi;

	public _0023_003Dzik2Qi7bdmaO0TXvCe5M_0024wO_0024bDg3Or4rXVA_003D_003D(int _0023_003DzQRMV62AXh5Ks, Dictionary<int, _0023_003Dze40BN1DxW2tmFXIfi8Suvba61l6xx1d_mA_003D_003D> _0023_003DzBYsu5BtJjehp)
	{
		_0023_003DzCebvYKs4dpRi = _0023_003DzBYsu5BtJjehp;
	}

	public virtual _0023_003Dze40BN1DxW2tmFXIfi8Suvba61l6xx1d_mA_003D_003D _0023_003DzODIr7N3Vaaz6(int _0023_003DzfQ4N5Jk_003D)
	{
		if (_0023_003DzCebvYKs4dpRi.ContainsKey(_0023_003DzfQ4N5Jk_003D))
		{
			return _0023_003DzCebvYKs4dpRi[_0023_003DzfQ4N5Jk_003D];
		}
		return null;
	}

	public static _0023_003Dzik2Qi7bdmaO0TXvCe5M_0024wO_0024bDg3Or4rXVA_003D_003D _0023_003DzuuY9lIM_003D(_0023_003Dz1k8g79YtmFbIePcxbICwvq0f_Fuo9R7q0g_003D_003D _0023_003DzEP3lrAc_003D)
	{
		_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9 = _0023_003DzEP3lrAc_003D._0023_003DzpFQU3MrOxdf3();
		Dictionary<int, _0023_003Dze40BN1DxW2tmFXIfi8Suvba61l6xx1d_mA_003D_003D> dictionary = new Dictionary<int, _0023_003Dze40BN1DxW2tmFXIfi8Suvba61l6xx1d_mA_003D_003D>();
		int num = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003DzYeSlt_NVa_00248u();
		if (num != 1)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935043) + num);
		}
		int num2 = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzmf8mDHW8MUJO();
		for (int i = 0; i < num2; i++)
		{
			int key = _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9._0023_003Dzmf8mDHW8MUJO();
			dictionary[key] = _0023_003Dze40BN1DxW2tmFXIfi8Suvba61l6xx1d_mA_003D_003D._0023_003DzuuY9lIM_003D(_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH9);
		}
		return new _0023_003Dzik2Qi7bdmaO0TXvCe5M_0024wO_0024bDg3Or4rXVA_003D_003D(num, dictionary);
	}
}
