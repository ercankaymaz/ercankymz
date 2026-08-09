using System.Collections.Generic;
using System.Drawing;

internal class _0023_003DzWPy7Mq_LyWeTazTXtajtCZ8FDawgWm5p_A_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	public object[] _0023_003Dzd4U12fI_003D;

	public _0023_003DzWPy7Mq_LyWeTazTXtajtCZ8FDawgWm5p_A_003D_003D(object[] _0023_003DzHSO_00246A0_003D, string _0023_003DzaROjBYA_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987268), _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzaROjBYA_003D, Color.Black)
	{
		_0023_003Dzd4U12fI_003D = _0023_003DzHSO_00246A0_003D;
		_0023_003Dz4_0024W9kMn1nUWQ = 406;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987505);
	}

	public _0023_003DzWPy7Mq_LyWeTazTXtajtCZ8FDawgWm5p_A_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		_0023_003Dzf0R_9gymLWqU(_0023_003Dzd4U12fI_003D.Length, ',');
		for (int i = 0; i < _0023_003Dzd4U12fI_003D.Length - 1; i++)
		{
			if (_0023_003Dzd4U12fI_003D[i] is string)
			{
				_0023_003DzemD6ZpU_003D((string)_0023_003Dzd4U12fI_003D[i], ',');
			}
			else if (_0023_003Dzd4U12fI_003D[i] is double)
			{
				_0023_003Dz4hSg1gGy0FEl((double)_0023_003Dzd4U12fI_003D[i], ',');
			}
			else
			{
				_0023_003Dzf0R_9gymLWqU((int)_0023_003Dzd4U12fI_003D[i], ',');
			}
		}
		int num = _0023_003Dzd4U12fI_003D.Length - 1;
		if (_0023_003Dzd4U12fI_003D[num] is string)
		{
			_0023_003DzemD6ZpU_003D((string)_0023_003Dzd4U12fI_003D[num], ';');
		}
		else if (_0023_003Dzd4U12fI_003D[num] is double)
		{
			_0023_003Dz4hSg1gGy0FEl((double)_0023_003Dzd4U12fI_003D[num], ';');
		}
		else
		{
			_0023_003Dzf0R_9gymLWqU((int)_0023_003Dzd4U12fI_003D[num], ';');
		}
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DzELu0Pss_003D.TrimEnd(';').Split(',');
		int num = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[1]);
		object[] array2 = new string[num];
		_0023_003Dzd4U12fI_003D = array2;
		for (int i = 0; i < num; i++)
		{
			_0023_003Dzd4U12fI_003D[i] = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzwYn0jkoawYlGZOKAyZJ365A_003D(array[2 + i]);
		}
	}
}
