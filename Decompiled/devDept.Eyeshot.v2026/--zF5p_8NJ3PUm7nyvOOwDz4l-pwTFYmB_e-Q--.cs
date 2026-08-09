using System.Collections.Generic;
using System.Drawing;

internal sealed class _0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	public int[] _0023_003DzzsWvP_3BfrPS;

	public bool[] _0023_003DzGInQsaa5ZW2U60JXbg_003D_003D;

	public _0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D(int[] _0023_003DzpPOEJqcAh7Lr, bool[] _0023_003Dz3qHoFLDZT8nx, string _0023_003DzaROjBYA_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzaROjBYA_003D, Color.Black)
	{
		_0023_003DzzsWvP_3BfrPS = _0023_003DzpPOEJqcAh7Lr;
		_0023_003DzGInQsaa5ZW2U60JXbg_003D_003D = _0023_003Dz3qHoFLDZT8nx;
		_0023_003Dz4_0024W9kMn1nUWQ = 514;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987465);
	}

	public _0023_003DzF5p_8NJ3PUm7nyvOOwDz4l_0024pwTFYmB_e_0024Q_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		int num = _0023_003DzzsWvP_3BfrPS.Length;
		_0023_003Dzf0R_9gymLWqU(num, ',');
		for (int i = 0; i < num - 1; i++)
		{
			_0023_003Dzf0R_9gymLWqU(_0023_003DzzsWvP_3BfrPS[i], ',');
			_0023_003Dzf0R_9gymLWqU(_0023_003DzGInQsaa5ZW2U60JXbg_003D_003D[i], ',');
		}
		_0023_003Dzf0R_9gymLWqU(_0023_003DzzsWvP_3BfrPS[num - 1], ',');
		_0023_003Dzf0R_9gymLWqU(_0023_003DzGInQsaa5ZW2U60JXbg_003D_003D[num - 1], ';');
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		int num = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[1]);
		_0023_003DzzsWvP_3BfrPS = new int[num];
		_0023_003DzGInQsaa5ZW2U60JXbg_003D_003D = new bool[num];
		for (int i = 0; i < num; i++)
		{
			_0023_003DzzsWvP_3BfrPS[i] = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[2 + i * 2]);
			_0023_003DzGInQsaa5ZW2U60JXbg_003D_003D[i] = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[3 + i * 2]) == 1;
		}
	}
}
