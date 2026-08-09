using System;
using System.Collections.Generic;

internal sealed class _0023_003DzxSb3CjiXgxiT : IComparer<Tuple<uint, uint>>
{
	private int _0023_003DqS3Tvwna5j2Gdce4jJQ_0024_0024ZQelovaQ42XOAGabRRKm_002440pdQ_ID2vwYixqtGfjRxX8amU_0024iwgL_0024CHhtXfErFLsXr5pXuFn9W38NJcBgB6k9Joi_0024Ui58s9agLVWyUGU9vyS(Tuple<uint, uint> _0023_003DzBJFJHwk_003D, Tuple<uint, uint> _0023_003Dz40R7bAU_003D)
	{
		if (_0023_003DzBJFJHwk_003D.Item1 < _0023_003Dz40R7bAU_003D.Item1 || (_0023_003Dz40R7bAU_003D.Item1 >= _0023_003DzBJFJHwk_003D.Item1 && _0023_003DzBJFJHwk_003D.Item2 < _0023_003Dz40R7bAU_003D.Item2))
		{
			return -1;
		}
		return 1;
	}

	int IComparer<Tuple<uint, uint>>.Compare(Tuple<uint, uint> _0023_003DzBJFJHwk_003D, Tuple<uint, uint> _0023_003Dz40R7bAU_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qS3Tvwna5j2Gdce4jJQ$$ZQelovaQ42XOAGabRRKm$40pdQ_ID2vwYixqtGfjRxX8amU$iwgL$CHhtXfErFLsXr5pXuFn9W38NJcBgB6k9Joi$Ui58s9agLVWyUGU9vyS
		return this._0023_003DqS3Tvwna5j2Gdce4jJQ_0024_0024ZQelovaQ42XOAGabRRKm_002440pdQ_ID2vwYixqtGfjRxX8amU_0024iwgL_0024CHhtXfErFLsXr5pXuFn9W38NJcBgB6k9Joi_0024Ui58s9agLVWyUGU9vyS(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
	}
}
