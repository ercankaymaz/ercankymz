using System;
using System.Collections.Generic;

internal sealed class _0023_003DqI9SEM_0024xY3_z7xlRX5ZGWoVE3lfkLN_27nmAmcwyTmZc_003D
{
	private object _0023_003Dz9jrlnWk_003D = new object();

	private Dictionary<_0023_003Dqi6yIuMh5RevZxwaFpAFM8mHMbXz6O0vAMU_0024CQC_9iM0_003D, _0023_003DqHG1TmG_0024dSF7XquINMc2Zz0W_0024ylD8AkBMmDuMbnL1GJY_003D> _0023_003DzBxpHhQ0_003D;

	internal _0023_003DqHG1TmG_0024dSF7XquINMc2Zz0W_0024ylD8AkBMmDuMbnL1GJY_003D _0023_003DzpLUAflNG_qPsC6OiXxsEpWxFuZxs0q5RmkDYLvE_003D(_0023_003Dqi6yIuMh5RevZxwaFpAFM8mHMbXz6O0vAMU_0024CQC_9iM0_003D _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException();
		}
		lock (this._0023_003Dz9jrlnWk_003D)
		{
			if (_0023_003DzBxpHhQ0_003D == null)
			{
				_0023_003DzBxpHhQ0_003D = new Dictionary<_0023_003Dqi6yIuMh5RevZxwaFpAFM8mHMbXz6O0vAMU_0024CQC_9iM0_003D, _0023_003DqHG1TmG_0024dSF7XquINMc2Zz0W_0024ylD8AkBMmDuMbnL1GJY_003D>();
			}
			if (!_0023_003DzBxpHhQ0_003D.TryGetValue(_0023_003Dz9jrlnWk_003D, out var value))
			{
				value = new _0023_003DqHG1TmG_0024dSF7XquINMc2Zz0W_0024ylD8AkBMmDuMbnL1GJY_003D(_0023_003Dz9jrlnWk_003D);
				_0023_003DzBxpHhQ0_003D[_0023_003Dz9jrlnWk_003D] = value;
			}
			return value;
		}
	}
}
