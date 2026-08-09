using System;
using System.Collections.Generic;

internal sealed class _0023_003DqiKG8cMtDhvDx0IwX7MlRZlGvI9dnj4DQ9imxEd_xNkc_003D
{
	private object _0023_003Dzq80RbjQ_003D = new object();

	private Dictionary<_0023_003Dqf_1TygBFcnFf0K9AFFRX5tWreByfCSY_0024wb98KsAZz08_003D, _0023_003Dq0aa58W10obKnKDKIHo_WWnIkvyqtS67nfLmpWg3JZ6M_003D> _0023_003DzZzVr6_0024U_003D;

	internal _0023_003Dq0aa58W10obKnKDKIHo_WWnIkvyqtS67nfLmpWg3JZ6M_003D _0023_003DzNcip0nEYxS_nf0p_0024sa0iWYk5BNcpK_0024a0No7NbX8_003D(_0023_003Dqf_1TygBFcnFf0K9AFFRX5tWreByfCSY_0024wb98KsAZz08_003D _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException();
		}
		lock (this._0023_003Dzq80RbjQ_003D)
		{
			if (_0023_003DzZzVr6_0024U_003D == null)
			{
				_0023_003DzZzVr6_0024U_003D = new Dictionary<_0023_003Dqf_1TygBFcnFf0K9AFFRX5tWreByfCSY_0024wb98KsAZz08_003D, _0023_003Dq0aa58W10obKnKDKIHo_WWnIkvyqtS67nfLmpWg3JZ6M_003D>();
			}
			if (!_0023_003DzZzVr6_0024U_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value))
			{
				value = new _0023_003Dq0aa58W10obKnKDKIHo_WWnIkvyqtS67nfLmpWg3JZ6M_003D(_0023_003Dzq80RbjQ_003D);
				_0023_003DzZzVr6_0024U_003D[_0023_003Dzq80RbjQ_003D] = value;
			}
			return value;
		}
	}
}
