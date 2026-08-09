using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;

internal sealed class _0023_003Dz3Zx4KFlYXhE6x5ocfLkICI9BSGRZVvqe1SYkVItmXGYVkWg25w_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	private int _0023_003DzEKSHIVc_003D;

	private int _0023_003DzSvvbybU_003D;

	private double[] _0023_003Dze_Mokvc_003D;

	private double[] _0023_003DzH_9cnwY_003D;

	private Vector3D[,][,] _0023_003Dz1v6oPQk_003D;

	public _0023_003Dz3Zx4KFlYXhE6x5ocfLkICI9BSGRZVvqe1SYkVItmXGYVkWg25w_003D_003D(bool _0023_003Dz_002418Nebs_KL8i, string _0023_003DzaROjBYA_003D, Color _0023_003Dz1MMYB1g_003D, bool _0023_003Dz_KjZG5vEM9v9)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i, _0023_003DzaROjBYA_003D, _0023_003Dz1MMYB1g_003D)
	{
		_0023_003Dz4_0024W9kMn1nUWQ = 114;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987324);
	}

	public _0023_003Dz3Zx4KFlYXhE6x5ocfLkICI9BSGRZVvqe1SYkVItmXGYVkWg25w_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public void _0023_003DzEt7rVh0_003D(out int _0023_003DzEKSHIVc_003D, out double[] _0023_003Dze_Mokvc_003D, out double[] _0023_003DzH_9cnwY_003D, out Vector3D[,][,] _0023_003Dz1v6oPQk_003D)
	{
		_0023_003DzEKSHIVc_003D = this._0023_003DzEKSHIVc_003D;
		_0023_003Dze_Mokvc_003D = this._0023_003Dze_Mokvc_003D;
		_0023_003DzH_9cnwY_003D = this._0023_003DzH_9cnwY_003D;
		_0023_003Dz1v6oPQk_003D = this._0023_003Dz1v6oPQk_003D;
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		_0023_003DzEKSHIVc_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[1]);
		if (_0023_003DzEKSHIVc_003D != 3)
		{
			return;
		}
		_0023_003DzSvvbybU_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[2]);
		int num = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[3]);
		int num2 = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[4]);
		_0023_003Dze_Mokvc_003D = new double[num + 1];
		int num3 = 5;
		for (int i = 0; i < num + 1; i++)
		{
			_0023_003Dze_Mokvc_003D[i] = Utility.DoubleParse(array[num3++]);
		}
		_0023_003DzH_9cnwY_003D = new double[num2 + 1];
		for (int j = 0; j < num2 + 1; j++)
		{
			_0023_003DzH_9cnwY_003D[j] = Utility.DoubleParse(array[num3++]);
		}
		_0023_003Dz1v6oPQk_003D = new Vector3D[num, num2][,];
		for (int k = 0; k < num; k++)
		{
			if (k != 0)
			{
				num3 += 48;
			}
			for (int l = 0; l < num2; l++)
			{
				_0023_003Dz1v6oPQk_003D[k, l] = new Vector3D[4, 4];
				for (int m = 0; m < 4; m++)
				{
					for (int n = 0; n < 4; n++)
					{
						_0023_003Dz1v6oPQk_003D[k, l][n, m] = new Vector3D(Utility.DoubleParse(array[num3]), Utility.DoubleParse(array[num3 + 16]), Utility.DoubleParse(array[num3 + 32]));
						num3++;
					}
				}
				num3 += 32;
			}
		}
	}
}
