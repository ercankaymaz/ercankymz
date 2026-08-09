using System;
using System.Collections.Generic;

internal sealed class _0023_003Dzq_0024P_8a33b4HE : IComparer<Tuple<float, uint>>
{
	private int _0023_003Dqob_0024Lk0iqRqtEEutlFKjtl0ZojyMEl8yGBx4Lg3FeFp9LE6hqh9_0024nqz7XpAh2cu6cjm0woZ8Y8aN5hnsU54TfP_hYusTiaYWZQvF420Tv9FE5nLfJC6sk2pe8TCFqQ1p8(Tuple<float, uint> _0023_003DzBJFJHwk_003D, Tuple<float, uint> _0023_003Dz40R7bAU_003D)
	{
		if (_0023_003DzBJFJHwk_003D.Item1 < _0023_003Dz40R7bAU_003D.Item1 || (!(_0023_003Dz40R7bAU_003D.Item1 < _0023_003DzBJFJHwk_003D.Item1) && _0023_003DzBJFJHwk_003D.Item2 < _0023_003Dz40R7bAU_003D.Item2))
		{
			return -1;
		}
		return 1;
	}

	int IComparer<Tuple<float, uint>>.Compare(Tuple<float, uint> _0023_003DzBJFJHwk_003D, Tuple<float, uint> _0023_003Dz40R7bAU_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qob$Lk0iqRqtEEutlFKjtl0ZojyMEl8yGBx4Lg3FeFp9LE6hqh9$nqz7XpAh2cu6cjm0woZ8Y8aN5hnsU54TfP_hYusTiaYWZQvF420Tv9FE5nLfJC6sk2pe8TCFqQ1p8
		return this._0023_003Dqob_0024Lk0iqRqtEEutlFKjtl0ZojyMEl8yGBx4Lg3FeFp9LE6hqh9_0024nqz7XpAh2cu6cjm0woZ8Y8aN5hnsU54TfP_hYusTiaYWZQvF420Tv9FE5nLfJC6sk2pe8TCFqQ1p8(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
	}
}
