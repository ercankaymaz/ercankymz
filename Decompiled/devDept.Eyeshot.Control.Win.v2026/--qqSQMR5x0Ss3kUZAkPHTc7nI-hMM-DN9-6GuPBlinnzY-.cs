using System;
using System.Collections.Generic;

internal sealed class _0023_003DqqSQMR5x0Ss3kUZAkPHTc7nI_0024hMM_0024DN9_00246GuPBlinnzY_003D
{
	private object _0023_003DzjYYAPCA_003D = new object();

	private Dictionary<_0023_003DqpOsddWbqwzI4Xv5sOvd5rvVf6_0024PoGMnUhfFmcHiYw4c_003D, _0023_003DqjP_cCVqr6eDH37DmNYzUTp_0024MqRALMWP3i3ApelaNl5I_003D> _0023_003DzVC9FBdo_003D;

	internal _0023_003DqjP_cCVqr6eDH37DmNYzUTp_0024MqRALMWP3i3ApelaNl5I_003D _0023_003DzhcsB8uYJgKYFxutimewKVER8n29I_0024PTTWWuRx54_003D(_0023_003DqpOsddWbqwzI4Xv5sOvd5rvVf6_0024PoGMnUhfFmcHiYw4c_003D _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException();
		}
		lock (this._0023_003DzjYYAPCA_003D)
		{
			if (_0023_003DzVC9FBdo_003D == null)
			{
				_0023_003DzVC9FBdo_003D = new Dictionary<_0023_003DqpOsddWbqwzI4Xv5sOvd5rvVf6_0024PoGMnUhfFmcHiYw4c_003D, _0023_003DqjP_cCVqr6eDH37DmNYzUTp_0024MqRALMWP3i3ApelaNl5I_003D>();
			}
			if (!_0023_003DzVC9FBdo_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value))
			{
				value = new _0023_003DqjP_cCVqr6eDH37DmNYzUTp_0024MqRALMWP3i3ApelaNl5I_003D(_0023_003DzjYYAPCA_003D);
				_0023_003DzVC9FBdo_003D[_0023_003DzjYYAPCA_003D] = value;
			}
			return value;
		}
	}
}
