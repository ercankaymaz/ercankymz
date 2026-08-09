using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using devDept;
using devDept.Eyeshot;
using devDept.Geometry;

internal sealed class _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D : _0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D
{
	private sealed class _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D
	{
		public List<List<int>> _0023_003DzCULckQQ_003D;

		public _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D _0023_003DzopRx0_MBcTQs;

		public HiddenLinesView _0023_003Dzu0TbekT8Y_00249p;

		public _0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u[] _0023_003DztIKjFz8_003D;

		public bool _0023_003DzxZfQlFbigLzS;

		public double _0023_003DzxH4ozIo_003D;

		public int _0023_003DzEZSghPGWLpgl;

		public IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		internal void _0023_003DzIbPwwtI_sSnmBB94jUCxPVc_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			List<int> _0023_003DzE3POwBw_003D = _0023_003DzCULckQQ_003D[_0023_003Dz437_00244ak_003D];
			_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D2 = (_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D)_0023_003DzopRx0_MBcTQs._0023_003Dzdaq5UoE_003D(_0023_003DzE3POwBw_003D);
			IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D = _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D2._0023_003DzyIUKu5w_003D;
			for (int i = 0; i < _0023_003DzyIUKu5w_003D.Count; i++)
			{
				_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2 = _0023_003DzyIUKu5w_003D[i];
				_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D = new List<double[]>();
				_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Add(new double[3]
				{
					_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0],
					_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1],
					_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2]
				});
				_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Add(new double[3]
				{
					_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3],
					_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4],
					_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[5]
				});
			}
			List<_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D> list = null;
			List<_0023_003DzWkhKoqmI2_0024VJ> _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D = null;
			if (_0023_003DzyIUKu5w_003D.Count > 0)
			{
				list = _0023_003DzopRx0_MBcTQs._0023_003DzFvzWkxpPPvYQnn17HA_003D_003D(_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D2, _0023_003Dzu0TbekT8Y_00249p.HdlViewSettings._0023_003DzA8ZfmVFtMUmw);
				_0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D = _0023_003DzopRx0_MBcTQs._0023_003DzeGycrgHRy2BCdDjavHDHe8Y_003D(list);
			}
			_0023_003DztIKjFz8_003D[_0023_003Dz437_00244ak_003D] = new _0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u();
			_0023_003DzopRx0_MBcTQs._0023_003DzmsGCYWf3e73E(list, _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D, _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D2._0023_003Dzb8b9JMl4Ocb_(), _0023_003DzyIUKu5w_003D, out var _0023_003DzGXaMc7bNNCOKK1Ti7Q_003D_003D, _0023_003Dzu0TbekT8Y_00249p._0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D);
			if (_0023_003DzxZfQlFbigLzS)
			{
				_0023_003DzopRx0_MBcTQs._0023_003Dz2aSpP9waYZSZ(_0023_003DzGXaMc7bNNCOKK1Ti7Q_003D_003D, _0023_003DztIKjFz8_003D[_0023_003Dz437_00244ak_003D]);
			}
			for (int j = 0; j < _0023_003DzyIUKu5w_003D.Count; j++)
			{
				_0023_003DzjWL1zt96TzvcIRmlBT3gixWVHGzL(j, _0023_003DzyIUKu5w_003D, _0023_003DzxH4ozIo_003D);
				_0023_003DzopRx0_MBcTQs._0023_003DzCXMt5xpWHB53(_0023_003DzyIUKu5w_003D[j], _0023_003DztIKjFz8_003D[_0023_003Dz437_00244ak_003D], list, _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D, _0023_003DzxZfQlFbigLzS, _0023_003Dzu0TbekT8Y_00249p._0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D);
			}
			if (!_0023_003Dzu0TbekT8Y_00249p.UpdateProgressAndCheckCancelledParallel(_0023_003DzEZSghPGWLpgl, _0023_003Dzu0TbekT8Y_00249p._0023_003Dz3lURioVh8358, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
		}
	}

	private sealed class _0023_003DzCUvOMl6aAtaw : IComparer<double[]>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _0023_003Dzm0CYiiE_003D;

		public _0023_003DzCUvOMl6aAtaw(double _0023_003DzxH4ozIo_003D)
		{
			_0023_003Dzm0CYiiE_003D = _0023_003DzxH4ozIo_003D * Utility._0023_003DzheSR8QM7q9ya;
		}

		public int Compare(double[] _0023_003DzFj_0024IqDQ_003D, double[] _0023_003DzjdeMMkk_003D)
		{
			if (_0023_003DzFj_0024IqDQ_003D[0] > _0023_003DzjdeMMkk_003D[0] + _0023_003Dzm0CYiiE_003D)
			{
				return 1;
			}
			if (_0023_003DzFj_0024IqDQ_003D[0] < _0023_003DzjdeMMkk_003D[0] - _0023_003Dzm0CYiiE_003D)
			{
				return -1;
			}
			if (_0023_003DzFj_0024IqDQ_003D[1] > _0023_003DzjdeMMkk_003D[1] + _0023_003Dzm0CYiiE_003D)
			{
				return 1;
			}
			if (_0023_003DzFj_0024IqDQ_003D[1] < _0023_003DzjdeMMkk_003D[1] - _0023_003Dzm0CYiiE_003D)
			{
				return -1;
			}
			if (_0023_003DzFj_0024IqDQ_003D[2] > _0023_003DzjdeMMkk_003D[2] + _0023_003Dzm0CYiiE_003D)
			{
				return 1;
			}
			if (_0023_003DzFj_0024IqDQ_003D[2] < _0023_003DzjdeMMkk_003D[2] - _0023_003Dzm0CYiiE_003D)
			{
				return -1;
			}
			return 0;
		}
	}

	private static class _0023_003DzQm9ltrs_003D
	{
		public static Comparison<_0023_003DzWkhKoqmI2_0024VJ> _0023_003DzIjHKqV_bjGx2;
	}

	internal sealed class _0023_003DzWkhKoqmI2_0024VJ
	{
		public int _0023_003Dzfe2zeQMumw_4;

		public int _0023_003DzAdg8iZA_003D;

		public double _0023_003Dz0B52BHY_003D;

		public _0023_003DzWkhKoqmI2_0024VJ(int _0023_003Dzfe2zeQMumw_4, int _0023_003DzAdg8iZA_003D, double _0023_003DzXWCF4rA_003D)
		{
			this._0023_003Dzfe2zeQMumw_4 = _0023_003Dzfe2zeQMumw_4;
			this._0023_003DzAdg8iZA_003D = _0023_003DzAdg8iZA_003D;
			_0023_003Dz0B52BHY_003D = _0023_003DzXWCF4rA_003D;
		}

		public static int _0023_003Dzwz6CZyI_003D(_0023_003DzWkhKoqmI2_0024VJ _0023_003DzBJFJHwk_003D, _0023_003DzWkhKoqmI2_0024VJ _0023_003Dz40R7bAU_003D)
		{
			if (_0023_003DzBJFJHwk_003D._0023_003Dz0B52BHY_003D < _0023_003Dz40R7bAU_003D._0023_003Dz0B52BHY_003D)
			{
				return -1;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003Dz0B52BHY_003D > _0023_003Dz40R7bAU_003D._0023_003Dz0B52BHY_003D)
			{
				return 1;
			}
			return 0;
		}
	}

	internal IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D;

	internal double _0023_003DzeMBeuAQ_003D;

	internal double _0023_003DznYtQKck_003D;

	internal double _0023_003Dz5F7_i_0024U_003D;

	internal double _0023_003DzXmrDMdc_003D;

	public _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D(double _0023_003DzeMBeuAQ_003D, double _0023_003DznYtQKck_003D, double _0023_003Dz5F7_i_0024U_003D, double _0023_003DzXmrDMdc_003D)
		: this(_0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D, _0023_003Dz5F7_i_0024U_003D, _0023_003DzXmrDMdc_003D, null)
	{
	}

	public _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D(double _0023_003DzeMBeuAQ_003D, double _0023_003DznYtQKck_003D, double _0023_003Dz5F7_i_0024U_003D, double _0023_003DzXmrDMdc_003D, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D)
	{
		this._0023_003DzyIUKu5w_003D = _0023_003DzyIUKu5w_003D;
		this._0023_003DzeMBeuAQ_003D = _0023_003DzeMBeuAQ_003D;
		this._0023_003DznYtQKck_003D = _0023_003DznYtQKck_003D;
		this._0023_003Dz5F7_i_0024U_003D = _0023_003Dz5F7_i_0024U_003D;
		this._0023_003DzXmrDMdc_003D = _0023_003DzXmrDMdc_003D;
		_0023_003DzazjhR_x3yt_fri46O7QwA_aKyCiimtSb4w_003D_003D[] array = new _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D[4];
		_0023_003Dz7qgjasQ_003D = array;
	}

	public _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D[] _0023_003Dz6Kki30ewh_0024dZ()
	{
		return (_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D[])_0023_003Dz7qgjasQ_003D;
	}

	public double _0023_003Dzb8b9JMl4Ocb_()
	{
		return (_0023_003DznYtQKck_003D - _0023_003DzeMBeuAQ_003D) * (_0023_003DzXmrDMdc_003D - _0023_003Dz5F7_i_0024U_003D);
	}

	public int _0023_003Dzse5L_LQ_003D(HiddenLinesView _0023_003Dz_0024fuCYfM_003D, double _0023_003DzxH4ozIo_003D, double _0023_003DzKjCH8JldgEWa, List<List<int>> _0023_003DzCULckQQ_003D)
	{
		int _0023_003Dz7Q5cFTJkZXky = 0;
		LinkedList<int> _0023_003DzPJ7u8NQ_003D = new LinkedList<int>();
		_0023_003DzqFkWDscPxqrR(_0023_003Dz_0024fuCYfM_003D, _0023_003DzxH4ozIo_003D, _0023_003DzKjCH8JldgEWa, _0023_003DzPJ7u8NQ_003D, _0023_003DzCULckQQ_003D, ref _0023_003Dz7Q5cFTJkZXky);
		return _0023_003Dz7Q5cFTJkZXky;
	}

	private List<int> _0023_003Dz83AyXT2UvIeq(LinkedList<int> _0023_003DzHBc20Fc_003D)
	{
		List<int> list = new List<int>();
		for (LinkedListNode<int> linkedListNode = _0023_003DzHBc20Fc_003D.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			list.Add(linkedListNode.Value);
		}
		return list;
	}

	private void _0023_003DzqFkWDscPxqrR(HiddenLinesView _0023_003Dz_0024fuCYfM_003D, double _0023_003DzxH4ozIo_003D, double _0023_003DzKjCH8JldgEWa, LinkedList<int> _0023_003DzPJ7u8NQ_003D, List<List<int>> _0023_003DzCULckQQ_003D, ref int _0023_003Dz7Q5cFTJkZXky)
	{
		HiddenLinesViewSettings hdlViewSettings = _0023_003Dz_0024fuCYfM_003D.HdlViewSettings;
		if (!_0023_003Dz71WyZDMasCb9(hdlViewSettings, _0023_003DzxH4ozIo_003D, _0023_003DzKjCH8JldgEWa, ref _0023_003Dz7Q5cFTJkZXky))
		{
			_0023_003DzCULckQQ_003D.Add(_0023_003Dz83AyXT2UvIeq(_0023_003DzPJ7u8NQ_003D));
			_0023_003Dz_0024fuCYfM_003D._0023_003Dz2_zO1L9VqNAx(_0023_003DzyIUKu5w_003D, null, default(CancellationToken));
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			_0023_003DzPJ7u8NQ_003D.AddLast(i);
			_0023_003Dz6Kki30ewh_0024dZ()[i]._0023_003DzqFkWDscPxqrR(_0023_003Dz_0024fuCYfM_003D, _0023_003DzxH4ozIo_003D, _0023_003DzKjCH8JldgEWa, _0023_003DzPJ7u8NQ_003D, _0023_003DzCULckQQ_003D, ref _0023_003Dz7Q5cFTJkZXky);
			_0023_003DzPJ7u8NQ_003D.RemoveLast();
		}
	}

	private bool _0023_003Dz71WyZDMasCb9(HiddenLinesViewSettings _0023_003DzlA0741irOW4x, double _0023_003DzxH4ozIo_003D, double _0023_003DzKjCH8JldgEWa, ref int _0023_003Dz7Q5cFTJkZXky)
	{
		if (_0023_003DzyIUKu5w_003D.Count <= 25)
		{
			_0023_003Dz7qgjasQ_003D = null;
			_0023_003Dz7Q5cFTJkZXky++;
			return false;
		}
		double num = (_0023_003DzeMBeuAQ_003D + _0023_003DznYtQKck_003D) / 2.0;
		double num2 = (_0023_003Dz5F7_i_0024U_003D + _0023_003DzXmrDMdc_003D) / 2.0;
		if (num - _0023_003DzeMBeuAQ_003D < _0023_003DzKjCH8JldgEWa || num2 - _0023_003Dz5F7_i_0024U_003D < _0023_003DzKjCH8JldgEWa)
		{
			_0023_003Dz7qgjasQ_003D = null;
			_0023_003Dz7Q5cFTJkZXky++;
			return false;
		}
		_0023_003Dz7qgjasQ_003D[0] = new _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D(_0023_003DzeMBeuAQ_003D, num, _0023_003Dz5F7_i_0024U_003D, num2);
		_0023_003Dz7qgjasQ_003D[1] = new _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D(num, _0023_003DznYtQKck_003D, _0023_003Dz5F7_i_0024U_003D, num2);
		_0023_003Dz7qgjasQ_003D[2] = new _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D(_0023_003DzeMBeuAQ_003D, num, num2, _0023_003DzXmrDMdc_003D);
		_0023_003Dz7qgjasQ_003D[3] = new _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D(num, _0023_003DznYtQKck_003D, num2, _0023_003DzXmrDMdc_003D);
		List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>[] array = HiddenLinesView._0023_003DzPT2M26s8ljDY(_0023_003DzyIUKu5w_003D, 0, num, _0023_003DzlA0741irOW4x, _0023_003DzxH4ozIo_003D);
		IList<IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>> list = HiddenLinesView._0023_003DzPT2M26s8ljDY(((IList<IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>>)array)[0], 1, num2, _0023_003DzlA0741irOW4x, _0023_003DzxH4ozIo_003D);
		IList<IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>> list2 = HiddenLinesView._0023_003DzPT2M26s8ljDY(((IList<IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>>)array)[1], 1, num2, _0023_003DzlA0741irOW4x, _0023_003DzxH4ozIo_003D);
		_0023_003Dz6Kki30ewh_0024dZ()[0]._0023_003DzyIUKu5w_003D = list[0];
		_0023_003Dz6Kki30ewh_0024dZ()[1]._0023_003DzyIUKu5w_003D = list2[0];
		_0023_003Dz6Kki30ewh_0024dZ()[2]._0023_003DzyIUKu5w_003D = list[1];
		_0023_003Dz6Kki30ewh_0024dZ()[3]._0023_003DzyIUKu5w_003D = list2[1];
		_0023_003DzyIUKu5w_003D = null;
		return true;
	}

	private List<_0023_003DzWkhKoqmI2_0024VJ> _0023_003DzeGycrgHRy2BCdDjavHDHe8Y_003D(List<_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D> _0023_003DzDvuIQCU_003D)
	{
		List<_0023_003DzWkhKoqmI2_0024VJ> list = new List<_0023_003DzWkhKoqmI2_0024VJ>();
		for (int i = 0; i < _0023_003DzDvuIQCU_003D.Count; i++)
		{
			_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D _0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D2 = _0023_003DzDvuIQCU_003D[i];
			for (int j = 0; j < _0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D2._0023_003DzOUlmthl3JWuBjRHzkg_003D_003D.Count; j++)
			{
				int num = _0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D2._0023_003DzOUlmthl3JWuBjRHzkg_003D_003D[j];
				list.Add(new _0023_003DzWkhKoqmI2_0024VJ(num, i, _0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D2._0023_003DzvZQLq3xGwoLj._0023_003DzmN5Mam9VUpygzj_00243Sw_003D_003D[num]));
			}
		}
		list.Sort(_0023_003DzWkhKoqmI2_0024VJ._0023_003Dzwz6CZyI_003D);
		return list;
	}

	internal void _0023_003DzTvoDUQUBQXMi(HiddenLinesView _0023_003Dzu0TbekT8Y_00249p, double _0023_003DzxH4ozIo_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, List<List<int>> _0023_003DzCULckQQ_003D, int _0023_003Dz7Q5cFTJkZXky)
	{
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2 = new _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D();
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzCULckQQ_003D = _0023_003DzCULckQQ_003D;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p = _0023_003Dzu0TbekT8Y_00249p;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzxH4ozIo_003D = _0023_003DzxH4ozIo_003D;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003DzTtgGeeqBjD2i++;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003Dz3lURioVh8358 = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p.ComputingVisibilityText;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p.UpdateProgress(_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003DzTtgGeeqBjD2i, _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003DzwJ3QaGJFHQh4, _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003Dz3lURioVh8358, _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzmHS7frs_003D);
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzxZfQlFbigLzS = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p.HdlViewSettings.KeepHiddenSegments;
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DztIKjFz8_003D = new _0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u[_0023_003Dz7Q5cFTJkZXky];
		HiddenLinesViewSettings hdlViewSettings = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p.HdlViewSettings;
		foreach (SilhoWireData item in _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p.HdlViewSettings._0023_003DzA8ZfmVFtMUmw)
		{
			if (item is _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2)
			{
				_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzexqDWFK72cEWXpSSzQ_003D_003D();
				_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003Dzab4M_0024oaJ7IdKql486g_003D_003D();
			}
		}
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzEZSghPGWLpgl = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003Dz5Faw6jTsdRm7wsDgbA_003D_003D(_0023_003Dz7Q5cFTJkZXky);
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p.ResetProgressParallel();
		Parallel.For(0, _0023_003Dz7Q5cFTJkZXky, _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzIbPwwtI_sSnmBB94jUCxPVc_003D);
		if (_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p.Cancelled(_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzjvn7P10_003D))
		{
			return;
		}
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D;
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzJpDx6YUyvUeu = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003DzJpDx6YUyvUeu;
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzhZz9rIEFDTwJ = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003DzhZz9rIEFDTwJ;
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D;
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzyrfqyvnF0yLf = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003DzyrfqyvnF0yLf;
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003Dzu0TbekT8Y_00249p._0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D;
		_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u[] _0023_003DztIKjFz8_003D = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DztIKjFz8_003D;
		foreach (_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u _0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u2 in _0023_003DztIKjFz8_003D)
		{
			_0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D.AddRange(_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u2._0023_003DzlBtE7jXfejlTp6gC6g_003D_003D);
			_0023_003DzJpDx6YUyvUeu.AddRange(_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u2._0023_003DzU3hosSAzkxO7);
			_0023_003DzhZz9rIEFDTwJ.AddRange(_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u2._0023_003DzMr9HUT_0024Sk_yF);
		}
		if (hdlViewSettings.KeepHiddenSegments)
		{
			_0023_003DztIKjFz8_003D = _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DztIKjFz8_003D;
			foreach (_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u _0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u3 in _0023_003DztIKjFz8_003D)
			{
				_0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D.AddRange(_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u3._0023_003DzKT24YmfTU4YndZWPwCnUXiA_003D);
				_0023_003DzyrfqyvnF0yLf.AddRange(_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u3._0023_003DzPLwxWABf6QMF);
				_0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D.AddRange(_0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u3._0023_003Dz7k5_0024vtUBISlg);
			}
		}
	}

	private List<_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D> _0023_003DzFvzWkxpPPvYQnn17HA_003D_003D(_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D _0023_003Dz_0024TrVfN4_003D, IList<SilhoWireData> _0023_003DzVckbAV4Du_0024ZJ)
	{
		List<_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D> list = new List<_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D>();
		foreach (SilhoWireData item in _0023_003DzVckbAV4Du_0024ZJ)
		{
			if (!(item is _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D))
			{
				continue;
			}
			_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2 = (_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D)item;
			if (!(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.screenBoxMin.X >= _0023_003Dz_0024TrVfN4_003D._0023_003DznYtQKck_003D) && !(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.screenBoxMax.X <= _0023_003Dz_0024TrVfN4_003D._0023_003DzeMBeuAQ_003D) && !(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.screenBoxMin.Y >= _0023_003Dz_0024TrVfN4_003D._0023_003DzXmrDMdc_003D) && !(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.screenBoxMax.Y <= _0023_003Dz_0024TrVfN4_003D._0023_003Dz5F7_i_0024U_003D))
			{
				HiddenLinesView._0023_003Dz4dUuAkqMFHbDrGnHdg_003D_003D(_0023_003Dz_0024TrVfN4_003D._0023_003DzeMBeuAQ_003D, _0023_003Dz_0024TrVfN4_003D._0023_003DznYtQKck_003D, _0023_003Dz_0024TrVfN4_003D._0023_003Dz5F7_i_0024U_003D, _0023_003Dz_0024TrVfN4_003D._0023_003DzXmrDMdc_003D, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.ScreenVertices, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzbiEHIdtmxpLPvJBt7Q_003D_003D, out var _0023_003DzNLCpK1_05T8n);
				if (_0023_003DzNLCpK1_05T8n.Count > 0)
				{
					list.Add(new _0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D
					{
						_0023_003DzOUlmthl3JWuBjRHzkg_003D_003D = _0023_003DzNLCpK1_05T8n,
						_0023_003DzvZQLq3xGwoLj = _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2
					});
				}
			}
		}
		return list;
	}

	private void _0023_003DzmsGCYWf3e73E(List<_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D> _0023_003DzAXvkcTP9ljj0, List<_0023_003DzWkhKoqmI2_0024VJ> _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D, double _0023_003DzeqXFBYc_003D, IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, out IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzGXaMc7bNNCOKK1Ti7Q_003D_003D, double _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D)
	{
		int count = _0023_003DzyIUKu5w_003D.Count;
		_0023_003DzGXaMc7bNNCOKK1Ti7Q_003D_003D = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>(count / 2);
		double num = _0023_003DzeqXFBYc_003D / 10.0;
		for (int num2 = count - 1; num2 >= 0; num2--)
		{
			_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2 = _0023_003DzyIUKu5w_003D[num2];
			for (int num3 = _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D.Count - 1; num3 >= 0; num3--)
			{
				_0023_003DzWkhKoqmI2_0024VJ _0023_003DzWkhKoqmI2_0024VJ2 = _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D[num3];
				if (_0023_003DzWkhKoqmI2_0024VJ2._0023_003Dz0B52BHY_003D < num)
				{
					break;
				}
				_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D obj = _0023_003DzAXvkcTP9ljj0[_0023_003DzWkhKoqmI2_0024VJ2._0023_003DzAdg8iZA_003D];
				int _0023_003Dzfe2zeQMumw_ = _0023_003DzWkhKoqmI2_0024VJ2._0023_003Dzfe2zeQMumw_4;
				_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzvZQLq3xGwoLj = obj._0023_003DzvZQLq3xGwoLj;
				if ((_0023_003Dzfe2zeQMumw_ != _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzxEr071xAssYe && _0023_003Dzfe2zeQMumw_ != _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzJefTJpnXqBD9) || _0023_003DzvZQLq3xGwoLj.Attributes != _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzHptl2yRuV4Y_0024())
				{
					int[] array = _0023_003DzvZQLq3xGwoLj._0023_003DzZSnvfVF8Y5Qg[_0023_003Dzfe2zeQMumw_]._0023_003DzhMDfC7g_003D[0];
					double[] array2 = _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D[0];
					double[] array3 = _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D[1];
					double num4 = array2[2];
					double num5 = array3[2];
					bool flag = true;
					for (int i = 0; i < array.Length; i++)
					{
						if (num4 > _0023_003DzvZQLq3xGwoLj.ScreenVertices[array[i], 2] || num5 > _0023_003DzvZQLq3xGwoLj.ScreenVertices[array[i], 2])
						{
							flag = false;
							break;
						}
					}
					if (!flag && _0023_003Dz_Vfq22SlYaCm(_0023_003DzvZQLq3xGwoLj, _0023_003Dzfe2zeQMumw_, array2, array3, _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D))
					{
						double[] array4 = new double[3]
						{
							_0023_003DzvZQLq3xGwoLj.ScreenVertices[array[0], 0],
							_0023_003DzvZQLq3xGwoLj.ScreenVertices[array[0], 1],
							_0023_003DzvZQLq3xGwoLj.ScreenVertices[array[0], 2]
						};
						double num6 = Vector3D.Dot(new Point3D(array2[0] - array4[0], array2[1] - array4[1], array2[2] - array4[2]), _0023_003DzvZQLq3xGwoLj._0023_003DzLUPb4pvedYKYJ9evdg_003D_003D[_0023_003Dzfe2zeQMumw_]);
						double num7 = Vector3D.Dot(new Point3D(array3[0] - array4[0], array3[1] - array4[1], array3[2] - array4[2]), _0023_003DzvZQLq3xGwoLj._0023_003DzLUPb4pvedYKYJ9evdg_003D_003D[_0023_003Dzfe2zeQMumw_]);
						double num8 = num4 * 1E-06;
						double num9 = num5 * 1E-06;
						if (num6 > num8 && num7 > num9)
						{
							_0023_003DzGXaMc7bNNCOKK1Ti7Q_003D_003D.Add(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2);
							_0023_003DzyIUKu5w_003D.RemoveAt(num2);
							break;
						}
					}
				}
			}
		}
	}

	private void _0023_003Dz2aSpP9waYZSZ(IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, _0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u _0023_003Dz9j4kMjs_003D)
	{
		foreach (_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D item in _0023_003DzyIUKu5w_003D)
		{
			IList<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list;
			switch (item._0023_003DzEKSHIVc_003D)
			{
			default:
				return;
			case HiddenLinesViewSettings.lineType.Edge:
				list = _0023_003Dz9j4kMjs_003D._0023_003DzPLwxWABf6QMF;
				break;
			case HiddenLinesViewSettings.lineType.Silho:
				list = _0023_003Dz9j4kMjs_003D._0023_003DzKT24YmfTU4YndZWPwCnUXiA_003D;
				break;
			case HiddenLinesViewSettings.lineType.Wire:
				list = _0023_003Dz9j4kMjs_003D._0023_003Dz7k5_0024vtUBISlg;
				break;
			}
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT(new double[6]
			{
				item._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D[0][0],
				item._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D[0][1],
				0.0,
				item._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D[1][0],
				item._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D[1][1],
				0.0
			}, item._0023_003DzHptl2yRuV4Y_0024(), item._0023_003DzIr63dnY3EK8N(), item._0023_003Dz0tIOZG5ZfcAY(), item._0023_003DzuxTqAp2a_0024JOK(), item._0023_003DzSy0j_0024ACSBvym()));
		}
	}

	internal void _0023_003DzCXMt5xpWHB53(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003DzQ9zpGF0_003D, _0023_003Dz5T0WtbTrFiCtfL_4fEmRH62uQd7u _0023_003Dz9j4kMjs_003D, List<_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D> _0023_003Dzz_0024rjznKsCptYKQ_00240uw_003D_003D, List<_0023_003DzWkhKoqmI2_0024VJ> _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D, bool _0023_003DzxZfQlFbigLzS, double _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D)
	{
		if (_0023_003DzQ9zpGF0_003D._0023_003DzkZ5nG5U_003D)
		{
			return;
		}
		IList<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list;
		IList<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list2;
		switch (_0023_003DzQ9zpGF0_003D._0023_003DzEKSHIVc_003D)
		{
		default:
			return;
		case HiddenLinesViewSettings.lineType.Edge:
			list = _0023_003Dz9j4kMjs_003D._0023_003DzU3hosSAzkxO7;
			list2 = _0023_003Dz9j4kMjs_003D._0023_003DzPLwxWABf6QMF;
			break;
		case HiddenLinesViewSettings.lineType.Silho:
			list = _0023_003Dz9j4kMjs_003D._0023_003DzlBtE7jXfejlTp6gC6g_003D_003D;
			list2 = _0023_003Dz9j4kMjs_003D._0023_003DzKT24YmfTU4YndZWPwCnUXiA_003D;
			break;
		case HiddenLinesViewSettings.lineType.Wire:
			list = _0023_003Dz9j4kMjs_003D._0023_003DzMr9HUT_0024Sk_yF;
			list2 = _0023_003Dz9j4kMjs_003D._0023_003Dz7k5_0024vtUBISlg;
			break;
		}
		double[] array = new double[3];
		for (int i = 1; i < _0023_003DzQ9zpGF0_003D._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Count; i++)
		{
			double[] array2 = _0023_003DzQ9zpGF0_003D._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D[i - 1];
			double[] array3 = _0023_003DzQ9zpGF0_003D._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D[i];
			array[0] = (array2[0] + array3[0]) / 2.0;
			array[1] = (array2[1] + array3[1]) / 2.0;
			array[2] = (array2[2] + array3[2]) / 2.0;
			if (array[2] < _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D)
			{
				continue;
			}
			if (_0023_003DzQ9zpGF0_003D._0023_003Dzx9ez3pU_003D || _0023_003DzTQZtmDV3RZmS(_0023_003Dzz_0024rjznKsCptYKQ_00240uw_003D_003D, _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D, _0023_003DzQ9zpGF0_003D, array, _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D))
			{
				if (_0023_003DzxZfQlFbigLzS)
				{
					list2.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT(new double[6]
					{
						array2[0],
						array2[1],
						0.0,
						array3[0],
						array3[1],
						0.0
					}, _0023_003DzQ9zpGF0_003D._0023_003DzHptl2yRuV4Y_0024(), _0023_003DzQ9zpGF0_003D._0023_003DzIr63dnY3EK8N(), _0023_003DzQ9zpGF0_003D._0023_003Dz0tIOZG5ZfcAY(), _0023_003DzQ9zpGF0_003D._0023_003DzuxTqAp2a_0024JOK(), _0023_003DzQ9zpGF0_003D._0023_003DzSy0j_0024ACSBvym()));
				}
			}
			else
			{
				list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT(new double[6]
				{
					array2[0],
					array2[1],
					0.0,
					array3[0],
					array3[1],
					0.0
				}, _0023_003DzQ9zpGF0_003D._0023_003DzHptl2yRuV4Y_0024(), _0023_003DzQ9zpGF0_003D._0023_003DzIr63dnY3EK8N(), _0023_003DzQ9zpGF0_003D._0023_003Dz0tIOZG5ZfcAY(), _0023_003DzQ9zpGF0_003D._0023_003DzuxTqAp2a_0024JOK(), _0023_003DzQ9zpGF0_003D._0023_003DzSy0j_0024ACSBvym()));
			}
		}
	}

	internal static void _0023_003DzjWL1zt96TzvcIRmlBT3gixWVHGzL(int _0023_003DzyzK8swU_003D, IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DznKjUt2M_003D, double _0023_003DzxH4ozIo_003D)
	{
		_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2 = _0023_003DznKjUt2M_003D[_0023_003DzyzK8swU_003D];
		if (_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzSy0j_0024ACSBvym())
		{
			return;
		}
		double[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		Segment2D _0023_003DzgPsOl1A_003D = new Segment2D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4]);
		Segment2D segment2D = new Segment2D();
		HiddenLinesViewSettings.lineType _0023_003DzEKSHIVc_003D = _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzEKSHIVc_003D;
		for (int i = _0023_003DzyzK8swU_003D + 1; i < _0023_003DznKjUt2M_003D.Count; i++)
		{
			_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3 = _0023_003DznKjUt2M_003D[i];
			if (_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3._0023_003DzSy0j_0024ACSBvym() || (_0023_003DzEKSHIVc_003D == HiddenLinesViewSettings.lineType.Wire && _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3._0023_003DzEKSHIVc_003D == HiddenLinesViewSettings.lineType.Wire))
			{
				continue;
			}
			double[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D2 = _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
			segment2D.P0.X = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D2[0];
			segment2D.P0.Y = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D2[1];
			segment2D.P1.X = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D2[3];
			segment2D.P1.Y = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D2[4];
			double[] _0023_003Dz3pZQu_UmBPOzvbb3d8MQmKwJi2Rx = new double[3];
			double[] _0023_003DzdgDbOkp0OsObqXOH4ZvsQQB5v2_0024 = new double[3];
			double[] _0023_003Dz6W5sf9JNXGBbnGFTwKuQ8K3oUOS = null;
			double[] _0023_003DziHePK_OCa9fUnEQZLqZw_s37u33E = null;
			if (_0023_003Dz9h5MY_A_003D(_0023_003DzyzK8swU_003D, i, _0023_003DznKjUt2M_003D, _0023_003DzgPsOl1A_003D, segment2D, ref _0023_003Dz3pZQu_UmBPOzvbb3d8MQmKwJi2Rx, ref _0023_003DzdgDbOkp0OsObqXOH4ZvsQQB5v2_0024, ref _0023_003Dz6W5sf9JNXGBbnGFTwKuQ8K3oUOS, ref _0023_003DziHePK_OCa9fUnEQZLqZw_s37u33E, _0023_003DzxH4ozIo_003D))
			{
				_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Add(_0023_003Dz3pZQu_UmBPOzvbb3d8MQmKwJi2Rx);
				_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Add(_0023_003DzdgDbOkp0OsObqXOH4ZvsQQB5v2_0024);
				if (_0023_003Dz6W5sf9JNXGBbnGFTwKuQ8K3oUOS != null)
				{
					_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Add(_0023_003Dz6W5sf9JNXGBbnGFTwKuQ8K3oUOS);
					_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Add(_0023_003DziHePK_OCa9fUnEQZLqZw_s37u33E);
				}
			}
		}
		_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Sort(new _0023_003DzCUvOMl6aAtaw(_0023_003DzxH4ozIo_003D));
		if (_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D.Count > 2)
		{
			_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D = _0023_003DztQYbo9c_003D(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzYG_0024zo2nntMcFmPYj12u_ERQ_003D, _0023_003DzxH4ozIo_003D);
		}
	}

	private static List<double[]> _0023_003DztQYbo9c_003D(List<double[]> _0023_003DzcDEsV8s_003D, double _0023_003DzxH4ozIo_003D)
	{
		List<double[]> list = new List<double[]>(_0023_003DzcDEsV8s_003D.Count);
		for (int i = 0; i < _0023_003DzcDEsV8s_003D.Count; i++)
		{
			double[] array = _0023_003DzcDEsV8s_003D[i];
			for (int j = i + 1; j < _0023_003DzcDEsV8s_003D.Count; j++)
			{
				double[] p = _0023_003DzcDEsV8s_003D[j];
				if (!Utility.AreEqual2D(array, p, _0023_003DzxH4ozIo_003D))
				{
					i = j - 1;
					break;
				}
			}
			list.Add(array);
		}
		return list;
	}

	private static bool _0023_003DzTGWtaFgHIFQt(Segment2D _0023_003DzgPsOl1A_003D, Segment2D _0023_003DzD5YCi2M_003D, out Point2D _0023_003Dz348XSZM_003D)
	{
		double[] array = new double[2]
		{
			_0023_003DzgPsOl1A_003D.P1.X - _0023_003DzgPsOl1A_003D.P0.X,
			_0023_003DzgPsOl1A_003D.P1.Y - _0023_003DzgPsOl1A_003D.P0.Y
		};
		double[] array2 = new double[2]
		{
			_0023_003DzD5YCi2M_003D.P1.X - _0023_003DzD5YCi2M_003D.P0.X,
			_0023_003DzD5YCi2M_003D.P1.Y - _0023_003DzD5YCi2M_003D.P0.Y
		};
		double[] array3 = new double[2]
		{
			_0023_003DzgPsOl1A_003D.P0.X - _0023_003DzD5YCi2M_003D.P0.X,
			_0023_003DzgPsOl1A_003D.P0.Y - _0023_003DzD5YCi2M_003D.P0.Y
		};
		double num = array[0] * array2[1] - array[1] * array2[0];
		double num2 = array2[0] * array3[1] - array2[1] * array3[0];
		double num3 = array[0] * array3[1] - array[1] * array3[0];
		if (Math.Abs(num) < Utility._0023_003DzheSR8QM7q9ya)
		{
			_0023_003Dz348XSZM_003D = null;
			return false;
		}
		double num4 = num2 / num;
		double num5 = num3 / num;
		if (num4 > 0.0 && num4 < 1.0 && num5 > 0.0 && num5 < 1.0)
		{
			_0023_003Dz348XSZM_003D = new Point2D(_0023_003DzgPsOl1A_003D.P0.X + num4 * array[0], _0023_003DzgPsOl1A_003D.P0.Y + num4 * array[1]);
			return true;
		}
		_0023_003Dz348XSZM_003D = null;
		return false;
	}

	private static bool _0023_003Dz9h5MY_A_003D(int _0023_003DzyzK8swU_003D, int _0023_003Dz0Nmqf_00240_003D, IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DznKjUt2M_003D, Segment2D _0023_003DzgPsOl1A_003D, Segment2D _0023_003DzD5YCi2M_003D, ref double[] _0023_003Dz3pZQu_UmBPOzvbb3d8MQmKwJi2Rx, ref double[] _0023_003DzdgDbOkp0OsObqXOH4ZvsQQB5v2_00249, ref double[] _0023_003Dz6W5sf9JNXGBbnGFTwKuQ8K3oUOS4, ref double[] _0023_003DziHePK_OCa9fUnEQZLqZw_s37u33E, double _0023_003DzxH4ozIo_003D)
	{
		Point2D i;
		Point2D i2;
		segmentIntersectionType segmentIntersectionType2 = Segment2D.Intersection(_0023_003DzgPsOl1A_003D, _0023_003DzD5YCi2M_003D, out i, out i2, _0023_003DzxH4ozIo_003D);
		if (segmentIntersectionType2 == segmentIntersectionType.Cross || segmentIntersectionType2 == segmentIntersectionType.OverlapInSegment || segmentIntersectionType2 == segmentIntersectionType.Touch)
		{
			_0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(_0023_003DzgPsOl1A_003D, i, _0023_003DznKjUt2M_003D[_0023_003DzyzK8swU_003D]._0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003Dz3pZQu_UmBPOzvbb3d8MQmKwJi2Rx);
			_0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(_0023_003DzD5YCi2M_003D, i, _0023_003DznKjUt2M_003D[_0023_003Dz0Nmqf_00240_003D]._0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003DzdgDbOkp0OsObqXOH4ZvsQQB5v2_00249);
			if (i2 != null)
			{
				_0023_003Dz6W5sf9JNXGBbnGFTwKuQ8K3oUOS4 = new double[3];
				_0023_003DziHePK_OCa9fUnEQZLqZw_s37u33E = new double[3];
				_0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(_0023_003DzgPsOl1A_003D, i2, _0023_003DznKjUt2M_003D[_0023_003DzyzK8swU_003D]._0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003Dz6W5sf9JNXGBbnGFTwKuQ8K3oUOS4);
				_0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(_0023_003DzD5YCi2M_003D, i2, _0023_003DznKjUt2M_003D[_0023_003Dz0Nmqf_00240_003D]._0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003DziHePK_OCa9fUnEQZLqZw_s37u33E);
			}
			return true;
		}
		return false;
	}

	internal static void _0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(Segment2D _0023_003DzuwH5j5s_003D, Point2D _0023_003DzM1obBmDgFdhJ, double[] _0023_003DzQ9zpGF0_003D, ref double[] _0023_003DzeEk0BGeXmyvR)
	{
		double num = _0023_003DzuwH5j5s_003D.P0.X - _0023_003DzM1obBmDgFdhJ.X;
		double num2 = _0023_003DzuwH5j5s_003D.P0.Y - _0023_003DzM1obBmDgFdhJ.Y;
		double num3 = Math.Sqrt(num * num + num2 * num2) / _0023_003DzuwH5j5s_003D.Length;
		_0023_003DzeEk0BGeXmyvR[0] = _0023_003DzQ9zpGF0_003D[0] + num3 * (_0023_003DzQ9zpGF0_003D[3] - _0023_003DzQ9zpGF0_003D[0]);
		_0023_003DzeEk0BGeXmyvR[1] = _0023_003DzQ9zpGF0_003D[1] + num3 * (_0023_003DzQ9zpGF0_003D[4] - _0023_003DzQ9zpGF0_003D[1]);
		_0023_003DzeEk0BGeXmyvR[2] = _0023_003DzQ9zpGF0_003D[2] + num3 * (_0023_003DzQ9zpGF0_003D[5] - _0023_003DzQ9zpGF0_003D[2]);
	}

	private static bool _0023_003DzTQZtmDV3RZmS(List<_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D> _0023_003DzTUeuAFiB4Zy4, List<_0023_003DzWkhKoqmI2_0024VJ> _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D, _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003DzbWAWt5wx_dJsnV52TWYgKYQ_003D, double[] _0023_003DzZTe_0024jFG9ebLg, double _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D)
	{
		double num = _0023_003DzZTe_0024jFG9ebLg[2];
		for (int num2 = _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D.Count - 1; num2 >= 0; num2--)
		{
			_0023_003DzWkhKoqmI2_0024VJ _0023_003DzWkhKoqmI2_0024VJ2 = _0023_003DzGqMb9EmU_Cu1vwBqaw_003D_003D[num2];
			_0023_003DzDG4fow3h2HZSiAEwne05UMgoQ6mu8uNAxQ_003D_003D obj = _0023_003DzTUeuAFiB4Zy4[_0023_003DzWkhKoqmI2_0024VJ2._0023_003DzAdg8iZA_003D];
			int _0023_003Dzfe2zeQMumw_ = _0023_003DzWkhKoqmI2_0024VJ2._0023_003Dzfe2zeQMumw_4;
			_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzvZQLq3xGwoLj = obj._0023_003DzvZQLq3xGwoLj;
			if ((_0023_003Dzfe2zeQMumw_ != _0023_003DzbWAWt5wx_dJsnV52TWYgKYQ_003D._0023_003DzxEr071xAssYe && _0023_003Dzfe2zeQMumw_ != _0023_003DzbWAWt5wx_dJsnV52TWYgKYQ_003D._0023_003DzJefTJpnXqBD9) || _0023_003DzvZQLq3xGwoLj.Attributes != _0023_003DzbWAWt5wx_dJsnV52TWYgKYQ_003D._0023_003DzHptl2yRuV4Y_0024())
			{
				int[] array = _0023_003DzvZQLq3xGwoLj._0023_003DzZSnvfVF8Y5Qg[_0023_003Dzfe2zeQMumw_]._0023_003DzhMDfC7g_003D[0];
				bool flag = true;
				for (int i = 0; i < array.Length; i++)
				{
					if (num > _0023_003DzvZQLq3xGwoLj.ScreenVertices[array[i], 2])
					{
						flag = false;
						break;
					}
				}
				if (!flag && _0023_003DzBBv14fXPKl1N(_0023_003DzvZQLq3xGwoLj, _0023_003Dzfe2zeQMumw_, _0023_003DzZTe_0024jFG9ebLg[0], _0023_003DzZTe_0024jFG9ebLg[1], _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D))
				{
					double num3 = Vector3D.Dot(new Point3D(_0023_003DzZTe_0024jFG9ebLg[0] - _0023_003DzvZQLq3xGwoLj.ScreenVertices[array[0], 0], _0023_003DzZTe_0024jFG9ebLg[1] - _0023_003DzvZQLq3xGwoLj.ScreenVertices[array[0], 1], _0023_003DzZTe_0024jFG9ebLg[2] - _0023_003DzvZQLq3xGwoLj.ScreenVertices[array[0], 2]), _0023_003DzvZQLq3xGwoLj._0023_003DzLUPb4pvedYKYJ9evdg_003D_003D[_0023_003Dzfe2zeQMumw_]);
					double num4 = num * 1E-06;
					if (num3 > num4)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private static bool _0023_003Dz_Vfq22SlYaCm(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, int _0023_003DzomwlH6xJN_0024ld, double[] _0023_003DzDVubtvo_003D, double[] _0023_003DzFj_0024IqDQ_003D, double _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D)
	{
		if (_0023_003DzBBv14fXPKl1N(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, _0023_003DzomwlH6xJN_0024ld, _0023_003DzDVubtvo_003D[0], _0023_003DzDVubtvo_003D[1], _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D) && _0023_003DzBBv14fXPKl1N(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, _0023_003DzomwlH6xJN_0024ld, _0023_003DzFj_0024IqDQ_003D[0], _0023_003DzFj_0024IqDQ_003D[1], _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D))
		{
			int[][] _0023_003DzhMDfC7g_003D = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg[_0023_003DzomwlH6xJN_0024ld]._0023_003DzhMDfC7g_003D;
			if (_0023_003DzhMDfC7g_003D[0].Length < 4)
			{
				return true;
			}
			Segment2D s = new Segment2D(_0023_003DzDVubtvo_003D[0], _0023_003DzDVubtvo_003D[1], _0023_003DzFj_0024IqDQ_003D[0], _0023_003DzFj_0024IqDQ_003D[1]);
			Segment2D segment2D = new Segment2D();
			for (int i = 0; i < _0023_003DzhMDfC7g_003D.Length; i++)
			{
				segment2D.P0.X = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices[_0023_003DzhMDfC7g_003D[i][0], 0];
				segment2D.P0.Y = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices[_0023_003DzhMDfC7g_003D[i][0], 1];
				Point2D i2;
				for (int j = 1; j < _0023_003DzhMDfC7g_003D[i].Length; j++)
				{
					segment2D.P1.X = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices[_0023_003DzhMDfC7g_003D[i][j], 0];
					segment2D.P1.Y = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices[_0023_003DzhMDfC7g_003D[i][j], 1];
					if (Segment2D.Intersection(s, segment2D, out i2))
					{
						return false;
					}
					segment2D.P0.X = segment2D.P1.X;
					segment2D.P0.Y = segment2D.P1.Y;
				}
				segment2D.P1.X = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices[_0023_003DzhMDfC7g_003D[i][0], 0];
				segment2D.P1.Y = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices[_0023_003DzhMDfC7g_003D[i][0], 1];
				if (Segment2D.Intersection(s, segment2D, out i2))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private static bool _0023_003DzBBv14fXPKl1N(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, int _0023_003DzomwlH6xJN_0024ld, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D)
	{
		_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom2 = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg[_0023_003DzomwlH6xJN_0024ld];
		if (_0023_003DzpZ7mKCucyB_0024g(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices, _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom2._0023_003DzhMDfC7g_003D[0]))
		{
			if (_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzwsVdE4aCB04rlTu9E7BEoXkNDRGraWob5A_003D_003D[_0023_003DzomwlH6xJN_0024ld])
			{
				Plane plane = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzWPOC_00241m_KrQbs_0024YxHGQ73_00244_003D[_0023_003DzomwlH6xJN_0024ld];
				Point3D p = new Point3D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, 0.0);
				if (plane.PointAt(plane.Project(p)).Z < _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D)
				{
					return false;
				}
			}
			for (int i = 1; i < _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom2._0023_003DzhMDfC7g_003D.Length; i++)
			{
				if (_0023_003DzpZ7mKCucyB_0024g(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices, _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom2._0023_003DzhMDfC7g_003D[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private static bool _0023_003DzpZ7mKCucyB_0024g(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double[,] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int[] _0023_003DzDPPdnUk_003D)
	{
		int num = _0023_003DzDPPdnUk_003D.Length;
		int num2 = 0;
		int num3 = 0;
		int num4 = num - 1;
		while (num3 < num)
		{
			double num5 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzDPPdnUk_003D[num3], 0];
			double num6 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzDPPdnUk_003D[num3], 1];
			double num7 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzDPPdnUk_003D[num4], 0];
			double num8 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzDPPdnUk_003D[num4], 1];
			if (((num6 <= _0023_003Dz40R7bAU_003D && _0023_003Dz40R7bAU_003D < num8) || (num8 <= _0023_003Dz40R7bAU_003D && _0023_003Dz40R7bAU_003D < num6)) && _0023_003DzBJFJHwk_003D < (num7 - num5) * (_0023_003Dz40R7bAU_003D - num6) / (num8 - num6) + num5)
			{
				num2++;
			}
			num4 = num3++;
		}
		return (num2 & 1) != 0;
	}

	internal static bool _0023_003DzmPn2XXu8_L2D(double _0023_003DzuTkHiyI_003D, double _0023_003Dz0KVPVlc_003D, double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D, double _0023_003DzuPuPztg_003D, double _0023_003Dz4693IIk_003D, out double _0023_003Dz_eY3Y4c_003D, out double _0023_003Dz77g161c_003D)
	{
		double[] array = new double[2]
		{
			_0023_003DzuPuPztg_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz4693IIk_003D - _0023_003DzpilgH4E_003D
		};
		double[] array2 = new double[2]
		{
			_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz8qV981c_003D - _0023_003DzpilgH4E_003D
		};
		double[] array3 = new double[2]
		{
			_0023_003DzuTkHiyI_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz0KVPVlc_003D - _0023_003DzpilgH4E_003D
		};
		double num = array[0] * array[0] + array[1] * array[1];
		double num2 = array2[0] * array2[0] + array2[1] * array2[1];
		double num3 = array[0] * array2[0] + array[1] * array2[1];
		double num4 = array[0] * array3[0] + array[1] * array3[1];
		double num5 = array2[0] * array3[0] + array2[1] * array3[1];
		double num6 = num * num2 - num3 * num3;
		double num7 = 1.0 / num6;
		_0023_003Dz_eY3Y4c_003D = (num2 * num4 - num3 * num5) * num7;
		_0023_003Dz77g161c_003D = (num * num5 - num3 * num4) * num7;
		if ((Math.Abs(_0023_003Dz_eY3Y4c_003D) < 1E-06 || _0023_003Dz_eY3Y4c_003D > 0.0) && (Math.Abs(_0023_003Dz77g161c_003D) < 1E-06 || _0023_003Dz77g161c_003D > 0.0) && (Math.Abs(_0023_003Dz_eY3Y4c_003D + _0023_003Dz77g161c_003D - 1.0) < 1E-06 || _0023_003Dz_eY3Y4c_003D + _0023_003Dz77g161c_003D < 1.0))
		{
			return true;
		}
		return false;
	}
}
