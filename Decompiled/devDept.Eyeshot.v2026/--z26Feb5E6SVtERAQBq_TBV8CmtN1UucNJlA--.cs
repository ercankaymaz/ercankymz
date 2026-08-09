using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using devDept.Geometry;

internal sealed class _0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D : _0023_003DzoqxUtuBN57mB_0024fEohMvzQJxQdK9XaDKcZV_D3uSBz1wn
{
	public List<_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D> _0023_003DzRE_Y7daquMq7;

	public _0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D(string _0023_003DzwyYng5o_003D, double _0023_003Dz52DtAfOW3JcG, double _0023_003DzIgncvKxbPTEd, double[,] _0023_003DzkMwL1oI_003D, bool _0023_003Dz_002418Nebs_KL8i, string _0023_003DzaROjBYA_003D, Color _0023_003Dz1MMYB1g_003D)
		: base(_0023_003DzkMwL1oI_003D, _0023_003Dz_002418Nebs_KL8i, _0023_003DzaROjBYA_003D, _0023_003Dz1MMYB1g_003D)
	{
		string[] array = _0023_003DzwyYng5o_003D.Split(new string[1] { Environment.NewLine }, StringSplitOptions.None);
		_0023_003DzRE_Y7daquMq7 = new List<_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D>();
		string[] array2 = array;
		foreach (string _0023_003DzwyYng5o_003D2 in array2)
		{
			_0023_003DzRE_Y7daquMq7.Add(new _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D(_0023_003DzwyYng5o_003D2, _0023_003Dz52DtAfOW3JcG, _0023_003DzIgncvKxbPTEd));
		}
		_0023_003Dz4_0024W9kMn1nUWQ = 212;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981463);
	}

	public _0023_003Dz26Feb5E6SVtERAQBq_TBV8CmtN1UucNJlA_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		int count = _0023_003DzRE_Y7daquMq7.Count;
		_0023_003Dzf0R_9gymLWqU(count, ',');
		for (int i = 0; i < count; i++)
		{
			_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D _0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2 = _0023_003DzRE_Y7daquMq7[i];
			_0023_003Dzf0R_9gymLWqU(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzwyYng5o_003D.Length, ',');
			_0023_003Dz4hSg1gGy0FEl(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003Dz52DtAfOW3JcG, ',');
			_0023_003Dz4hSg1gGy0FEl(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzIgncvKxbPTEd, ',');
			_0023_003Dzf0R_9gymLWqU(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzthNnHPk_003D, ',');
			_0023_003Dz4hSg1gGy0FEl(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzN_0024RoH_0024rHzF1Q, ',');
			_0023_003Dz4hSg1gGy0FEl(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzphuopNr1cMwyXJRT7Q_003D_003D, ',');
			_0023_003Dzf0R_9gymLWqU(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzTre_00240F851An_00247nIXlg_003D_003D, ',');
			_0023_003Dzf0R_9gymLWqU(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzRQF2kC1j_0024KbT5i_79w_003D_003D, ',');
			_0023_003Dz4hSg1gGy0FEl(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzJPR4E5ZNOD6H.X, ',');
			_0023_003Dz4hSg1gGy0FEl(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzJPR4E5ZNOD6H.Y, ',');
			_0023_003Dz4hSg1gGy0FEl(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzJPR4E5ZNOD6H.Z, ',');
			if (i == count - 1)
			{
				_0023_003DzemD6ZpU_003D(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzwyYng5o_003D, ';');
			}
			else
			{
				_0023_003DzemD6ZpU_003D(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D2._0023_003DzwyYng5o_003D, ',');
			}
		}
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		int num = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[1]);
		_0023_003DzRE_Y7daquMq7 = new List<_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D>(num);
		try
		{
			_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D item = default(_0023_003DzyswY1YGhtSRVVHaRPJrsdKFftUkixvF1GieW_qI_003D);
			for (int i = 0; i < num; i++)
			{
				item._0023_003DzoFWofp4mnsC5 = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[2 + i * 12]);
				item._0023_003Dz52DtAfOW3JcG = Utility.DoubleParse(array[3 + i * 12]);
				item._0023_003DzIgncvKxbPTEd = Utility.DoubleParse(array[4 + i * 12]);
				string text = array[5 + i * 12];
				item._0023_003DzthNnHPk_003D = ((!string.IsNullOrEmpty(text)) ? _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(text) : 0);
				string value = array[6 + i * 12];
				item._0023_003DzN_0024RoH_0024rHzF1Q = (string.IsNullOrEmpty(value) ? 0.0 : Utility.DoubleParse(value));
				string value2 = array[7 + i * 12];
				item._0023_003DzphuopNr1cMwyXJRT7Q_003D_003D = (string.IsNullOrEmpty(value2) ? 0.0 : Utility.DoubleParse(value2));
				string text2 = array[8 + i * 12];
				item._0023_003DzTre_00240F851An_00247nIXlg_003D_003D = ((!string.IsNullOrEmpty(text2)) ? _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(text2) : 0);
				string text3 = array[9 + i * 12];
				item._0023_003DzRQF2kC1j_0024KbT5i_79w_003D_003D = ((!string.IsNullOrEmpty(text3)) ? _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(text3) : 0);
				item._0023_003DzJPR4E5ZNOD6H = new Point3D(Utility.DoubleParse(array[10 + i * 12]), Utility.DoubleParse(array[11 + i * 12]), Utility.DoubleParse(array[12 + i * 12]));
				item._0023_003DzwyYng5o_003D = array[13 + i * 12];
				_0023_003DzRE_Y7daquMq7.Add(item);
			}
		}
		catch (Exception)
		{
		}
	}

	public override void _0023_003DzwnHyM_uvlOeZ(TextWriter _0023_003DzzvTcRNc_003D, ref int _0023_003DzXrBIpWM_003D)
	{
		int _0023_003Dzj7yulN4DIiFP0g2hld8tEaJSwG3r = 0;
		if (_0023_003DzkMwL1oI_003D != null)
		{
			_0023_003Dzj7yulN4DIiFP0g2hld8tEaJSwG3r = ((!_0023_003Dz_002418Nebs_KL8i) ? _0023_003Dz7qgjasQ_003D[0]._0023_003DzmCN2WwtnqjPZ() : _0023_003Dz7qgjasQ_003D[1]._0023_003DzmCN2WwtnqjPZ());
		}
		_0023_003DzD52Km8VSH47Y(_0023_003DzzvTcRNc_003D, _0023_003Dzwzd6NcMCCV_o, 0, 0, 0, _0023_003Dzj7yulN4DIiFP0g2hld8tEaJSwG3r, 0, _0023_003DzXrBIpWM_003D, 0, 0);
		_0023_003DzXrBIpWM_003D += 2;
	}
}
