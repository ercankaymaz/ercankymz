using System;
using System.Collections.Generic;

internal sealed class _0023_003DzJ2icDOrKZr4t : IComparer<Tuple<double, uint>>
{
	private int _0023_003DqJuStnsjIcPwRUWjFqs1XWbqPjjKO3gv5xYz2V6eW2R2iARtwXA_t6RUbhev9Lpocfeeq3ufBRZd67xxDydAnV6Ovjxo2qUxbxOt0s_wuDWbWnxkuONxrnVcgCF_Hvn7M(Tuple<double, uint> _0023_003DzBJFJHwk_003D, Tuple<double, uint> _0023_003Dz40R7bAU_003D)
	{
		if (_0023_003DzBJFJHwk_003D.Item1 < _0023_003Dz40R7bAU_003D.Item1 || (!(_0023_003Dz40R7bAU_003D.Item1 < _0023_003DzBJFJHwk_003D.Item1) && _0023_003DzBJFJHwk_003D.Item2 < _0023_003Dz40R7bAU_003D.Item2))
		{
			return -1;
		}
		return 1;
	}

	int IComparer<Tuple<double, uint>>.Compare(Tuple<double, uint> _0023_003DzBJFJHwk_003D, Tuple<double, uint> _0023_003Dz40R7bAU_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qJuStnsjIcPwRUWjFqs1XWbqPjjKO3gv5xYz2V6eW2R2iARtwXA_t6RUbhev9Lpocfeeq3ufBRZd67xxDydAnV6Ovjxo2qUxbxOt0s_wuDWbWnxkuONxrnVcgCF_Hvn7M
		return this._0023_003DqJuStnsjIcPwRUWjFqs1XWbqPjjKO3gv5xYz2V6eW2R2iARtwXA_t6RUbhev9Lpocfeeq3ufBRZd67xxDydAnV6Ovjxo2qUxbxOt0s_wuDWbWnxkuONxrnVcgCF_Hvn7M(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
	}
}
