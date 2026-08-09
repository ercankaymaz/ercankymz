using System;
using System.Collections.Generic;
using System.Linq;

internal sealed class _0023_003DzX8EQ3V8risPGKjcrkyQQ7NWufK94 : _0023_003Dzq2iTTSx811_0024qBvIVqD7AW7Y_003D
{
	private sealed class _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D
	{
		public Tuple<_0023_003DzoC5nni_JI9M0, double> _0023_003DzrVzEtJULlWfe;

		public Tuple<_0023_003DzoC5nni_JI9M0, double> _0023_003DzXULhp_00248_003D;

		internal bool _0023_003DzDn6hphwRlvMRzL4rqR2GEM2OoGchLmbtQ9ysmV0_003D(Tuple<_0023_003DzoC5nni_JI9M0, double> _0023_003DzoMNiNRw_003D)
		{
			return _0023_003DzoMNiNRw_003D.Item2 >= _0023_003DzrVzEtJULlWfe.Item2;
		}

		internal bool _0023_003DzYukojWK_OHRQXbIEJXVw9bF_00244GlvCP1tagTpdJQ_003D(Tuple<_0023_003DzoC5nni_JI9M0, double> _0023_003DzoMNiNRw_003D)
		{
			return _0023_003DzoMNiNRw_003D.Item2 > _0023_003DzXULhp_00248_003D.Item2;
		}

		internal bool _0023_003Dz3H0f6egsXa14x7MCN8iWt_0024gsOh1b97HvF6xrP30_003D(Tuple<_0023_003DzoC5nni_JI9M0, double> _0023_003DzoMNiNRw_003D)
		{
			return _0023_003DzoMNiNRw_003D.Item2 < _0023_003DzXULhp_00248_003D.Item2;
		}
	}

	public override void Dispose()
	{
		base.Dispose();
	}

	public override void _0023_003DzaCgY2eQ_003D()
	{
		_0023_003Dz00Co9AepzHgNsrfN7S2RV1Q_003D();
		_0023_003DzjJ_P9c9wvYAcpCoZPBzrGTE_003D();
		foreach (_0023_003Dzi7XR59NGN6Cp item in _0023_003DzQZT_0024QgDKtAVQ)
		{
			List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator2 = item._0023_003DzhoegMB067LVL.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Count <= 1)
				{
					continue;
				}
				List<List<_0023_003Dzi7XR59NGN6Cp>.Enumerator>.Enumerator enumerator3 = enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.GetEnumerator();
				enumerator3.MoveNext();
				List<List<_0023_003Dzi7XR59NGN6Cp>.Enumerator>.Enumerator enumerator4 = enumerator3;
				while (enumerator3.MoveNext())
				{
					List<_0023_003Dzi7XR59NGN6Cp>.Enumerator enumerator5 = _0023_003DzcEy0WMEw_0024la1.GetEnumerator();
					int num = -1;
					int num2 = -1;
					int num3 = -1;
					_0023_003Dzi7XR59NGN6Cp _0023_003DzS_0024EIGtI_003D = null;
					_0023_003Dzi7XR59NGN6Cp _0023_003DzS_0024EIGtI_003D2 = null;
					while (enumerator5.MoveNext())
					{
						num3++;
						if (enumerator5.Current == enumerator3.Current.Current)
						{
							num = num3;
							_0023_003DzS_0024EIGtI_003D2 = _0023_003DzcEy0WMEw_0024la1[num - 1];
						}
						if (enumerator5.Current == enumerator4.Current.Current)
						{
							num2 = num3;
							_0023_003DzS_0024EIGtI_003D = _0023_003DzcEy0WMEw_0024la1[num2 + 1];
						}
					}
					int num4 = num - num2;
					if (num4 > 1)
					{
						List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzL30XLe0_003D = _0023_003Dze9GBHjZ_zdpY9UlCqSuUuYAslWaL(item, _0023_003DzS_0024EIGtI_003D);
						_0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(item, _0023_003DzS_0024EIGtI_003D, enumerator2, _0023_003DzL30XLe0_003D, (_0023_003DzLoV38OWkgKii)5);
						if (num4 > 2)
						{
							_0023_003DzL30XLe0_003D = _0023_003Dze9GBHjZ_zdpY9UlCqSuUuYAslWaL(item, _0023_003DzS_0024EIGtI_003D2);
							_0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(item, _0023_003DzS_0024EIGtI_003D2, enumerator2, _0023_003DzL30XLe0_003D, (_0023_003DzLoV38OWkgKii)5);
						}
					}
					enumerator4 = enumerator3;
				}
			}
		}
		foreach (_0023_003Dzi7XR59NGN6Cp item2 in _0023_003DzcEy0WMEw_0024la1)
		{
			List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator6 = item2._0023_003DzhoegMB067LVL.GetEnumerator();
			while (enumerator6.MoveNext())
			{
				if (enumerator6.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Count <= 1)
				{
					continue;
				}
				List<List<_0023_003Dzi7XR59NGN6Cp>.Enumerator>.Enumerator enumerator7 = enumerator6.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.GetEnumerator();
				enumerator7.MoveNext();
				List<List<_0023_003Dzi7XR59NGN6Cp>.Enumerator>.Enumerator enumerator8 = enumerator7;
				while (enumerator7.MoveNext())
				{
					List<_0023_003Dzi7XR59NGN6Cp>.Enumerator enumerator9 = _0023_003DzQZT_0024QgDKtAVQ.GetEnumerator();
					int num5 = -1;
					int num6 = -1;
					int num7 = -1;
					_0023_003Dzi7XR59NGN6Cp _0023_003DzIUjxFe0_003D = null;
					_0023_003Dzi7XR59NGN6Cp _0023_003DzIUjxFe0_003D2 = null;
					while (enumerator9.MoveNext())
					{
						num7++;
						if (enumerator9.Current == enumerator7.Current.Current)
						{
							num5 = num7;
							_0023_003DzIUjxFe0_003D2 = _0023_003DzQZT_0024QgDKtAVQ[num5 - 1];
						}
						if (enumerator9.Current == enumerator8.Current.Current)
						{
							num6 = num7;
							_0023_003DzIUjxFe0_003D = _0023_003DzQZT_0024QgDKtAVQ[num6 + 1];
						}
					}
					int num8 = num5 - num6;
					if (num8 > 1)
					{
						List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzghVYKJ4_003D = _0023_003Dzwr_0024cfhZKfqVTssdf1MpH90KDg3Oc(_0023_003DzIUjxFe0_003D, item2);
						_0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(_0023_003DzIUjxFe0_003D, item2, _0023_003DzghVYKJ4_003D, enumerator6, (_0023_003DzLoV38OWkgKii)5);
						if (num8 > 2)
						{
							_0023_003DzghVYKJ4_003D = _0023_003Dzwr_0024cfhZKfqVTssdf1MpH90KDg3Oc(_0023_003DzIUjxFe0_003D2, item2);
							_0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(_0023_003DzIUjxFe0_003D2, item2, _0023_003DzghVYKJ4_003D, enumerator6, (_0023_003DzLoV38OWkgKii)5);
						}
					}
					enumerator8 = enumerator7;
				}
			}
		}
		_0023_003Dz063zch51NTb2zRScAg_003D_003D();
	}

	protected void _0023_003Dz00Co9AepzHgNsrfN7S2RV1Q_003D()
	{
		List<_0023_003Dzi7XR59NGN6Cp>.Enumerator enumerator = _0023_003DzQZT_0024QgDKtAVQ.GetEnumerator();
		while (enumerator.MoveNext())
		{
			List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator2 = enumerator.Current._0023_003DzhoegMB067LVL.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				int num = -1;
				List<_0023_003Dzi7XR59NGN6Cp>.Enumerator enumerator3 = _0023_003DzcEy0WMEw_0024la1.GetEnumerator();
				enumerator3.MoveNext();
				num++;
				List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzL30XLe0_003D = enumerator3.Current._0023_003DzhoegMB067LVL.GetEnumerator();
				bool flag = _0023_003DzyusT8sjzKATIJzKByQ_003D_003D(enumerator3.Current, ref _0023_003DzL30XLe0_003D, enumerator2.Current, enumerator.Current);
				while (num < _0023_003DzcEy0WMEw_0024la1.Count && !flag)
				{
					enumerator3.MoveNext();
					num++;
					if (num < _0023_003DzcEy0WMEw_0024la1.Count)
					{
						flag = _0023_003DzyusT8sjzKATIJzKByQ_003D_003D(enumerator3.Current, ref _0023_003DzL30XLe0_003D, enumerator2.Current, enumerator.Current);
					}
				}
				if (num >= _0023_003DzcEy0WMEw_0024la1.Count)
				{
					continue;
				}
				_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = new _0023_003DzmKBPh7nOT6nY(enumerator.Current._0023_003DzlY77YgY_003D(enumerator2.Current._0023_003Dz6V_0024QadA_003D));
				_0023_003DzdVCfL2_eSNGkx7mpuw_003D_003D(_0023_003DzmKBPh7nOT6nY2, enumerator2.Current, _0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D);
				_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY3 = new _0023_003DzmKBPh7nOT6nY(enumerator.Current._0023_003DzlY77YgY_003D(enumerator2.Current._0023_003DzCskoEKg_003D));
				_0023_003DzdVCfL2_eSNGkx7mpuw_003D_003D(_0023_003DzmKBPh7nOT6nY3, enumerator2.Current, _0023_003DzmKBPh7nOT6nY3._0023_003DzBJFJHwk_003D);
				_0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(enumerator.Current, enumerator3.Current, enumerator2, _0023_003DzL30XLe0_003D, (_0023_003DzLoV38OWkgKii)4);
				if (!enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Contains(enumerator3))
				{
					enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Add(enumerator3);
				}
				if (!_0023_003DzL30XLe0_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Contains(enumerator))
				{
					_0023_003DzL30XLe0_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Add(enumerator);
				}
				flag = _0023_003DzyusT8sjzKATIJzKByQ_003D_003D(enumerator3.Current, ref _0023_003DzL30XLe0_003D, enumerator2.Current, enumerator.Current);
				while (num < _0023_003DzcEy0WMEw_0024la1.Count && flag)
				{
					enumerator3.MoveNext();
					num++;
					if (num < _0023_003DzcEy0WMEw_0024la1.Count)
					{
						flag = _0023_003DzyusT8sjzKATIJzKByQ_003D_003D(enumerator3.Current, ref _0023_003DzL30XLe0_003D, enumerator2.Current, enumerator.Current);
					}
				}
				num--;
				_0023_003Dzi7XR59NGN6Cp _0023_003DzS_0024EIGtI_003D = _0023_003DzcEy0WMEw_0024la1[num];
				_0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(enumerator.Current, _0023_003DzS_0024EIGtI_003D, enumerator2, _0023_003DzL30XLe0_003D, (_0023_003DzLoV38OWkgKii)4);
				List<_0023_003Dzi7XR59NGN6Cp>.Enumerator enumerator4 = _0023_003DzcEy0WMEw_0024la1.GetEnumerator();
				int num2 = -1;
				while (enumerator4.MoveNext())
				{
					num2++;
					if (num2 == num)
					{
						break;
					}
				}
				if (!enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Contains(enumerator4))
				{
					enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Add(enumerator4);
				}
				if (!_0023_003DzL30XLe0_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Contains(enumerator))
				{
					_0023_003DzL30XLe0_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Add(enumerator);
				}
			}
		}
	}

	protected void _0023_003DzjJ_P9c9wvYAcpCoZPBzrGTE_003D()
	{
		List<_0023_003Dzi7XR59NGN6Cp>.Enumerator enumerator = _0023_003DzcEy0WMEw_0024la1.GetEnumerator();
		while (enumerator.MoveNext())
		{
			List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator2 = enumerator.Current._0023_003DzhoegMB067LVL.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				int num = -1;
				List<_0023_003Dzi7XR59NGN6Cp>.Enumerator enumerator3 = _0023_003DzQZT_0024QgDKtAVQ.GetEnumerator();
				enumerator3.MoveNext();
				num++;
				List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzghVYKJ4_003D = enumerator3.Current._0023_003DzhoegMB067LVL.GetEnumerator();
				bool flag = _0023_003DzBUAHdomAqoevKflINA_003D_003D(enumerator3.Current, ref _0023_003DzghVYKJ4_003D, enumerator2.Current, enumerator.Current);
				while (num < _0023_003DzQZT_0024QgDKtAVQ.Count && !flag)
				{
					enumerator3.MoveNext();
					num++;
					if (num < _0023_003DzQZT_0024QgDKtAVQ.Count)
					{
						flag = _0023_003DzBUAHdomAqoevKflINA_003D_003D(enumerator3.Current, ref _0023_003DzghVYKJ4_003D, enumerator2.Current, enumerator.Current);
					}
				}
				if (num >= _0023_003DzQZT_0024QgDKtAVQ.Count)
				{
					continue;
				}
				_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = new _0023_003DzmKBPh7nOT6nY(enumerator.Current._0023_003DzlY77YgY_003D(enumerator2.Current._0023_003Dz6V_0024QadA_003D));
				_0023_003DzdVCfL2_eSNGkx7mpuw_003D_003D(_0023_003DzmKBPh7nOT6nY2, enumerator2.Current, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D);
				_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY3 = new _0023_003DzmKBPh7nOT6nY(enumerator.Current._0023_003DzlY77YgY_003D(enumerator2.Current._0023_003DzCskoEKg_003D));
				_0023_003DzdVCfL2_eSNGkx7mpuw_003D_003D(_0023_003DzmKBPh7nOT6nY3, enumerator2.Current, _0023_003DzmKBPh7nOT6nY3._0023_003Dz40R7bAU_003D);
				if (_0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(enumerator3.Current, enumerator.Current, _0023_003DzghVYKJ4_003D, enumerator2, (_0023_003DzLoV38OWkgKii)4))
				{
					int i;
					for (i = 0; i < _0023_003DzghVYKJ4_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Count && !(_0023_003DzghVYKJ4_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D[i].Current._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D > enumerator.Current._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D); i++)
					{
					}
					_0023_003DzghVYKJ4_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Insert(i, enumerator);
					for (i = 0; i < enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Count && !(enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D[i].Current._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D > enumerator3.Current._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D); i++)
					{
					}
					enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Insert(i, enumerator3);
				}
				flag = _0023_003DzBUAHdomAqoevKflINA_003D_003D(enumerator3.Current, ref _0023_003DzghVYKJ4_003D, enumerator2.Current, enumerator.Current);
				while (num < _0023_003DzQZT_0024QgDKtAVQ.Count && flag)
				{
					enumerator3.MoveNext();
					num++;
					if (num < _0023_003DzQZT_0024QgDKtAVQ.Count)
					{
						flag = _0023_003DzBUAHdomAqoevKflINA_003D_003D(enumerator3.Current, ref _0023_003DzghVYKJ4_003D, enumerator2.Current, enumerator.Current);
					}
				}
				num--;
				_0023_003Dzi7XR59NGN6Cp _0023_003DzIUjxFe0_003D = _0023_003DzQZT_0024QgDKtAVQ[num];
				if (!_0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(_0023_003DzIUjxFe0_003D, enumerator.Current, _0023_003DzghVYKJ4_003D, enumerator2, (_0023_003DzLoV38OWkgKii)4))
				{
					continue;
				}
				List<_0023_003Dzi7XR59NGN6Cp>.Enumerator enumerator4 = _0023_003DzQZT_0024QgDKtAVQ.GetEnumerator();
				int num2 = -1;
				while (enumerator4.MoveNext())
				{
					num2++;
					if (num2 == num)
					{
						break;
					}
				}
				int j;
				for (j = 0; j < _0023_003DzghVYKJ4_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Count && !(_0023_003DzghVYKJ4_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D[j].Current._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D > enumerator.Current._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D); j++)
				{
				}
				_0023_003DzghVYKJ4_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Insert(j, enumerator);
				for (j = 0; j < enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Count && !(enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D[j].Current._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D > enumerator4.Current._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D); j++)
				{
				}
				enumerator2.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D.Add(enumerator4);
			}
		}
	}

	protected bool _0023_003DzyusT8sjzKATIJzKByQ_003D_003D(_0023_003Dzi7XR59NGN6Cp _0023_003DzS_0024EIGtI_003D, ref List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzL30XLe0_003D, _0023_003DznZQ9NSjF878u _0023_003DzghVYKJ4_003D, _0023_003Dzi7XR59NGN6Cp _0023_003DzIUjxFe0_003D)
	{
		if (_0023_003DzS_0024EIGtI_003D._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D >= _0023_003DzIUjxFe0_003D._0023_003DzlY77YgY_003D(_0023_003DzghVYKJ4_003D._0023_003Dz6V_0024QadA_003D)._0023_003DzBJFJHwk_003D && _0023_003DzS_0024EIGtI_003D._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D <= _0023_003DzIUjxFe0_003D._0023_003DzlY77YgY_003D(_0023_003DzghVYKJ4_003D._0023_003DzCskoEKg_003D)._0023_003DzBJFJHwk_003D)
		{
			List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator = _0023_003DzS_0024EIGtI_003D._0023_003DzhoegMB067LVL.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (_0023_003DzS_0024EIGtI_003D._0023_003DzlY77YgY_003D(enumerator.Current._0023_003Dz6V_0024QadA_003D)._0023_003Dz40R7bAU_003D <= _0023_003DzIUjxFe0_003D._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D && _0023_003DzS_0024EIGtI_003D._0023_003DzlY77YgY_003D(enumerator.Current._0023_003DzCskoEKg_003D)._0023_003Dz40R7bAU_003D >= _0023_003DzIUjxFe0_003D._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D)
				{
					_0023_003DzL30XLe0_003D = enumerator;
					return true;
				}
			}
			return false;
		}
		return false;
	}

	protected bool _0023_003DzBUAHdomAqoevKflINA_003D_003D(_0023_003Dzi7XR59NGN6Cp _0023_003DzIUjxFe0_003D, ref List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzghVYKJ4_003D, _0023_003DznZQ9NSjF878u _0023_003DzL30XLe0_003D, _0023_003Dzi7XR59NGN6Cp _0023_003DzS_0024EIGtI_003D)
	{
		if (_0023_003DzIUjxFe0_003D._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D >= _0023_003DzS_0024EIGtI_003D._0023_003DzlY77YgY_003D(_0023_003DzL30XLe0_003D._0023_003Dz6V_0024QadA_003D)._0023_003Dz40R7bAU_003D && _0023_003DzIUjxFe0_003D._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D <= _0023_003DzS_0024EIGtI_003D._0023_003DzlY77YgY_003D(_0023_003DzL30XLe0_003D._0023_003DzCskoEKg_003D)._0023_003Dz40R7bAU_003D)
		{
			List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator = _0023_003DzIUjxFe0_003D._0023_003DzhoegMB067LVL.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (_0023_003DzIUjxFe0_003D._0023_003DzlY77YgY_003D(enumerator.Current._0023_003Dz6V_0024QadA_003D)._0023_003DzBJFJHwk_003D <= _0023_003DzS_0024EIGtI_003D._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D && _0023_003DzIUjxFe0_003D._0023_003DzlY77YgY_003D(enumerator.Current._0023_003DzCskoEKg_003D)._0023_003DzBJFJHwk_003D >= _0023_003DzS_0024EIGtI_003D._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D)
				{
					_0023_003DzghVYKJ4_003D = enumerator;
					return true;
				}
			}
			return false;
		}
		return false;
	}

	protected List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003Dze9GBHjZ_zdpY9UlCqSuUuYAslWaL(_0023_003Dzi7XR59NGN6Cp _0023_003DzIUjxFe0_003D, _0023_003Dzi7XR59NGN6Cp _0023_003DzS_0024EIGtI_003D)
	{
		List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzghVYKJ4_003D = _0023_003DzIUjxFe0_003D._0023_003DzhoegMB067LVL.GetEnumerator();
		List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator = _0023_003DzS_0024EIGtI_003D._0023_003DzhoegMB067LVL.GetEnumerator();
		enumerator.MoveNext();
		for (int i = 0; i < _0023_003DzS_0024EIGtI_003D._0023_003DzhoegMB067LVL.Count; i++)
		{
			if (_0023_003DzBUAHdomAqoevKflINA_003D_003D(_0023_003DzIUjxFe0_003D, ref _0023_003DzghVYKJ4_003D, enumerator.Current, _0023_003DzS_0024EIGtI_003D))
			{
				break;
			}
			enumerator.MoveNext();
		}
		return enumerator;
	}

	protected List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003Dzwr_0024cfhZKfqVTssdf1MpH90KDg3Oc(_0023_003Dzi7XR59NGN6Cp _0023_003DzIUjxFe0_003D, _0023_003Dzi7XR59NGN6Cp _0023_003DzS_0024EIGtI_003D)
	{
		List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzL30XLe0_003D = _0023_003DzS_0024EIGtI_003D._0023_003DzhoegMB067LVL.GetEnumerator();
		List<_0023_003DznZQ9NSjF878u>.Enumerator enumerator = _0023_003DzIUjxFe0_003D._0023_003DzhoegMB067LVL.GetEnumerator();
		enumerator.MoveNext();
		for (int i = 0; i < _0023_003DzIUjxFe0_003D._0023_003DzhoegMB067LVL.Count; i++)
		{
			if (_0023_003DzyusT8sjzKATIJzKByQ_003D_003D(_0023_003DzS_0024EIGtI_003D, ref _0023_003DzL30XLe0_003D, enumerator.Current, _0023_003DzIUjxFe0_003D))
			{
				break;
			}
			enumerator.MoveNext();
		}
		return enumerator;
	}

	protected _0023_003DzoC5nni_JI9M0 _0023_003DzdVCfL2_eSNGkx7mpuw_003D_003D(_0023_003DzmKBPh7nOT6nY _0023_003DztUjb52A_003D, _0023_003DznZQ9NSjF878u _0023_003DzfbKU_0024Y3_i8b9, double _0023_003DzZ3LF7p9QNlEE)
	{
		_0023_003DzoC5nni_JI9M0 _0023_003DzoC5nni_JI9M1 = _0023_003Dz5rQzobg_003D._0023_003DzInfe_5u_00248P684DWmTQ_003D_003D();
		_0023_003Dz5rQzobg_003D[_0023_003DzoC5nni_JI9M1]._0023_003DztUjb52A_003D = _0023_003DztUjb52A_003D;
		_0023_003Dz5rQzobg_003D[_0023_003DzoC5nni_JI9M1]._0023_003DzEKSHIVc_003D = (_0023_003DzLoV38OWkgKii)0;
		_0023_003DzfbKU_0024Y3_i8b9._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.Add(Tuple.Create(_0023_003DzoC5nni_JI9M1, _0023_003DzZ3LF7p9QNlEE));
		_0023_003DzBB2Doz8jTrD8.Add(_0023_003DzoC5nni_JI9M1);
		return _0023_003DzoC5nni_JI9M1;
	}

	protected bool _0023_003DzInfe_5u_00248P684DWmTQ_003D_003D(_0023_003Dzi7XR59NGN6Cp _0023_003DzIUjxFe0_003D, _0023_003Dzi7XR59NGN6Cp _0023_003DzS_0024EIGtI_003D, List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzghVYKJ4_003D, List<_0023_003DznZQ9NSjF878u>.Enumerator _0023_003DzL30XLe0_003D, _0023_003DzLoV38OWkgKii _0023_003DzEKSHIVc_003D)
	{
		foreach (List<_0023_003Dzi7XR59NGN6Cp>.Enumerator item in _0023_003DzL30XLe0_003D.Current._0023_003DzFcLPkU_0024S1IoXLPrMvMKplPJaUArfOl7oQQ_003D_003D)
		{
			if (item.Current == _0023_003DzIUjxFe0_003D)
			{
				return false;
			}
		}
		_0023_003DzmKBPh7nOT6nY _0023_003DzmKBPh7nOT6nY2 = new _0023_003DzmKBPh7nOT6nY(_0023_003DzS_0024EIGtI_003D._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D, _0023_003DzIUjxFe0_003D._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D, _0023_003DzIUjxFe0_003D._0023_003DzFj_0024IqDQ_003D._0023_003DzId5C3LA_003D);
		_0023_003DzoC5nni_JI9M0 _0023_003DzoC5nni_JI9M1 = _0023_003Dz5rQzobg_003D._0023_003DzInfe_5u_00248P684DWmTQ_003D_003D();
		_0023_003Dz5rQzobg_003D[_0023_003DzoC5nni_JI9M1]._0023_003DztUjb52A_003D = _0023_003DzmKBPh7nOT6nY2;
		_0023_003Dz5rQzobg_003D[_0023_003DzoC5nni_JI9M1]._0023_003DzEKSHIVc_003D = _0023_003DzEKSHIVc_003D;
		_0023_003Dz5rQzobg_003D[_0023_003DzoC5nni_JI9M1]._0023_003DzghVYKJ4_003D = _0023_003DzghVYKJ4_003D;
		_0023_003Dz5rQzobg_003D[_0023_003DzoC5nni_JI9M1]._0023_003DzL30XLe0_003D = _0023_003DzL30XLe0_003D;
		_0023_003DzghVYKJ4_003D.Current._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.Add(Tuple.Create(_0023_003DzoC5nni_JI9M1, _0023_003DzmKBPh7nOT6nY2._0023_003DzBJFJHwk_003D));
		_0023_003DzL30XLe0_003D.Current._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.Add(Tuple.Create(_0023_003DzoC5nni_JI9M1, _0023_003DzmKBPh7nOT6nY2._0023_003Dz40R7bAU_003D));
		return true;
	}

	protected void _0023_003Dz063zch51NTb2zRScAg_003D_003D()
	{
		List<_0023_003DzoC5nni_JI9M0> list = _0023_003Dz5rQzobg_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		foreach (_0023_003DzoC5nni_JI9M0 item in list)
		{
			if (_0023_003Dz5rQzobg_003D[item]._0023_003DzEKSHIVc_003D != (_0023_003DzLoV38OWkgKii)4 && _0023_003Dz5rQzobg_003D[item]._0023_003DzEKSHIVc_003D != (_0023_003DzLoV38OWkgKii)5)
			{
				continue;
			}
			num++;
			List<_0023_003DzoC5nni_JI9M0> list2 = new List<_0023_003DzoC5nni_JI9M0>();
			List<_0023_003DzsZ4ZibZTpgv3> list3 = new List<_0023_003DzsZ4ZibZTpgv3>();
			List<_0023_003DzsZ4ZibZTpgv3> list4 = new List<_0023_003DzsZ4ZibZTpgv3>();
			Tuple<_0023_003DzoC5nni_JI9M0, _0023_003DzoC5nni_JI9M0> tuple = _0023_003DzRDM_0024IBO2RhBeprNPtCD4t_00244L1cdr5nDDBA_003D_003D(Tuple.Create(item, _0023_003Dz5rQzobg_003D[item]._0023_003DztUjb52A_003D._0023_003DzBJFJHwk_003D), _0023_003Dz5rQzobg_003D[item]._0023_003DzghVYKJ4_003D.Current, _0023_003Dz_mH1l4qLK9kvdWd_0024qA_003D_003D: false);
			Tuple<_0023_003DzoC5nni_JI9M0, _0023_003DzoC5nni_JI9M0> tuple2 = _0023_003DzRDM_0024IBO2RhBeprNPtCD4t_00244L1cdr5nDDBA_003D_003D(Tuple.Create(item, _0023_003Dz5rQzobg_003D[item]._0023_003DztUjb52A_003D._0023_003Dz40R7bAU_003D), _0023_003Dz5rQzobg_003D[item]._0023_003DzL30XLe0_003D.Current, _0023_003Dz_mH1l4qLK9kvdWd_0024qA_003D_003D: false);
			list2.Add(tuple.Item2);
			list2.Add(tuple2.Item1);
			list2.Add(tuple.Item1);
			list2.Add(tuple2.Item2);
			List<_0023_003DzoC5nni_JI9M0>.Enumerator enumerator2 = list2.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				_0023_003DzsZ4ZibZTpgv3 _0023_003DzsZ4ZibZTpgv4;
				_0023_003DzsZ4ZibZTpgv3 _0023_003DzsZ4ZibZTpgv5;
				if (_0023_003Dz5rQzobg_003D._0023_003DzGU1GkC51jibS(enumerator2.Current, item))
				{
					_0023_003DzsZ4ZibZTpgv4 = _0023_003Dz5rQzobg_003D._0023_003DzTx2aqr8_003D(enumerator2.Current, item);
					_0023_003DzsZ4ZibZTpgv5 = _0023_003Dz5rQzobg_003D._0023_003DzTx2aqr8_003D(item, enumerator2.Current);
					list3.Add(_0023_003DzsZ4ZibZTpgv4);
					list4.Add(_0023_003DzsZ4ZibZTpgv5);
					num2++;
				}
				else
				{
					_0023_003DzsZ4ZibZTpgv4 = _0023_003Dz5rQzobg_003D._0023_003Dz3flWRseB0P3a(enumerator2.Current, item);
					_0023_003DzsZ4ZibZTpgv5 = _0023_003Dz5rQzobg_003D._0023_003Dz3flWRseB0P3a(item, enumerator2.Current);
					list3.Add(_0023_003DzsZ4ZibZTpgv4);
					list4.Add(_0023_003DzsZ4ZibZTpgv5);
					num3++;
				}
				if (_0023_003Dz5rQzobg_003D[enumerator2.Current]._0023_003DzEKSHIVc_003D == (_0023_003DzLoV38OWkgKii)0)
				{
					_0023_003Dz5rQzobg_003D[_0023_003DzsZ4ZibZTpgv4]._0023_003Dz1BPEjBg_003D = _0023_003DzsZ4ZibZTpgv5;
					_0023_003Dz5rQzobg_003D[_0023_003DzsZ4ZibZTpgv5]._0023_003DzvmFFjUs_003D = _0023_003DzsZ4ZibZTpgv4;
					num4++;
				}
			}
			List<_0023_003DzsZ4ZibZTpgv3>.Enumerator enumerator3 = list3.GetEnumerator();
			List<_0023_003DzsZ4ZibZTpgv3>.Enumerator enumerator4 = list4.GetEnumerator();
			List<_0023_003DzsZ4ZibZTpgv3>.Enumerator enumerator5 = enumerator3;
			while (enumerator3.MoveNext() && enumerator4.MoveNext())
			{
				List<_0023_003DzsZ4ZibZTpgv3>.Enumerator enumerator6 = enumerator4;
				if (enumerator3.Current == list3[0])
				{
					enumerator6.MoveNext();
					_0023_003Dz5rQzobg_003D[enumerator3.Current]._0023_003DzvmFFjUs_003D = enumerator6.Current;
					_0023_003Dz5rQzobg_003D[enumerator4.Current]._0023_003Dz1BPEjBg_003D = list3[list3.Count - 1];
					num5++;
				}
				else if (enumerator3.Current == list3[list3.Count - 1])
				{
					_0023_003Dz5rQzobg_003D[enumerator3.Current]._0023_003DzvmFFjUs_003D = list4[0];
					_0023_003Dz5rQzobg_003D[enumerator4.Current]._0023_003Dz1BPEjBg_003D = enumerator5.Current;
					num6++;
				}
				else
				{
					enumerator6.MoveNext();
					_0023_003Dz5rQzobg_003D[enumerator3.Current]._0023_003DzvmFFjUs_003D = enumerator6.Current;
					_0023_003Dz5rQzobg_003D[enumerator4.Current]._0023_003Dz1BPEjBg_003D = enumerator5.Current;
					num7++;
				}
				enumerator5 = enumerator3;
			}
		}
	}

	protected Tuple<_0023_003DzoC5nni_JI9M0, _0023_003DzoC5nni_JI9M0> _0023_003DzRDM_0024IBO2RhBeprNPtCD4t_00244L1cdr5nDDBA_003D_003D(Tuple<_0023_003DzoC5nni_JI9M0, double> _0023_003DzrVzEtJULlWfe, _0023_003DznZQ9NSjF878u _0023_003DzfbKU_0024Y3_i8b9, bool _0023_003Dz_mH1l4qLK9kvdWd_0024qA_003D_003D)
	{
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D CS_0024_003C_003E8__locals6 = new _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D();
		CS_0024_003C_003E8__locals6._0023_003DzrVzEtJULlWfe = _0023_003DzrVzEtJULlWfe;
		CS_0024_003C_003E8__locals6._0023_003DzXULhp_00248_003D = _0023_003DzfbKU_0024Y3_i8b9._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.ToList().Where(CS_0024_003C_003E8__locals6._0023_003DzDn6hphwRlvMRzL4rqR2GEM2OoGchLmbtQ9ysmV0_003D).First();
		Tuple<_0023_003DzoC5nni_JI9M0, double> tuple = (from _0023_003DzoMNiNRw_003D in _0023_003DzfbKU_0024Y3_i8b9._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.ToList()
			where _0023_003DzoMNiNRw_003D.Item2 > CS_0024_003C_003E8__locals6._0023_003DzXULhp_00248_003D.Item2
			select _0023_003DzoMNiNRw_003D).First();
		Tuple<_0023_003DzoC5nni_JI9M0, double> tuple2 = (from _0023_003DzoMNiNRw_003D in _0023_003DzfbKU_0024Y3_i8b9._0023_003Dz2nAHlJIn5jx3jp64xAliGTs_003D.ToList()
			where _0023_003DzoMNiNRw_003D.Item2 < CS_0024_003C_003E8__locals6._0023_003DzXULhp_00248_003D.Item2
			select _0023_003DzoMNiNRw_003D).Last();
		Tuple<_0023_003DzoC5nni_JI9M0, double> tuple3 = ((!_0023_003Dz_mH1l4qLK9kvdWd_0024qA_003D_003D) ? tuple : CS_0024_003C_003E8__locals6._0023_003DzXULhp_00248_003D);
		Tuple<_0023_003DzoC5nni_JI9M0, double> tuple4 = tuple2;
		return new Tuple<_0023_003DzoC5nni_JI9M0, _0023_003DzoC5nni_JI9M0>(tuple3.Item1, tuple4.Item1);
	}
}
