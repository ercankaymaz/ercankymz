using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;

internal sealed class _0023_003DzOKQiiYVsLKx6c65wwxfwYTu0ENOXS1pHlaJUbq8QGC1LOQs_0024LQ_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	private int _0023_003DzEKSHIVc_003D;

	private int _0023_003DzDnnD6QZKrSSbD_0024YSfA_003D_003D;

	private int _0023_003DzsLr8dLA_003D;

	private double[] _0023_003DzNDQ_E88_003D;

	private Vector3D[][] _0023_003Dz1v6oPQk_003D;

	public _0023_003DzOKQiiYVsLKx6c65wwxfwYTu0ENOXS1pHlaJUbq8QGC1LOQs_0024LQ_003D_003D(bool _0023_003Dz_002418Nebs_KL8i, string _0023_003DzaROjBYA_003D, Color _0023_003Dz1MMYB1g_003D, bool _0023_003Dz_KjZG5vEM9v9)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i, _0023_003DzaROjBYA_003D, _0023_003Dz1MMYB1g_003D)
	{
		_0023_003Dz4_0024W9kMn1nUWQ = 112;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987341);
	}

	public _0023_003DzOKQiiYVsLKx6c65wwxfwYTu0ENOXS1pHlaJUbq8QGC1LOQs_0024LQ_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public void _0023_003DzEt7rVh0_003D(out int _0023_003DzEKSHIVc_003D, out double[] _0023_003DzNDQ_E88_003D, out Vector3D[][] _0023_003Dz1v6oPQk_003D)
	{
		_0023_003DzEKSHIVc_003D = this._0023_003DzEKSHIVc_003D;
		_0023_003DzNDQ_E88_003D = this._0023_003DzNDQ_E88_003D;
		_0023_003Dz1v6oPQk_003D = this._0023_003Dz1v6oPQk_003D;
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		_0023_003DzEKSHIVc_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[1]);
		if (_0023_003DzEKSHIVc_003D == 3)
		{
			_0023_003DzDnnD6QZKrSSbD_0024YSfA_003D_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[2]);
			_0023_003DzsLr8dLA_003D = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[3]);
			int num = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[4]);
			_0023_003DzNDQ_E88_003D = new double[num + 1];
			int num2 = 5;
			for (int i = 0; i < num + 1; i++)
			{
				_0023_003DzNDQ_E88_003D[i] = Utility.DoubleParse(array[num2++]);
			}
			_0023_003Dz1v6oPQk_003D = new Vector3D[num][];
			for (int j = 0; j < num; j++)
			{
				_0023_003Dz1v6oPQk_003D[j] = new Vector3D[4];
				_0023_003Dz1v6oPQk_003D[j][0] = new Vector3D(Utility.DoubleParse(array[num2]), Utility.DoubleParse(array[num2 + 4]), Utility.DoubleParse(array[num2 + 8]));
				_0023_003Dz1v6oPQk_003D[j][1] = new Vector3D(Utility.DoubleParse(array[num2 + 1]), Utility.DoubleParse(array[num2 + 5]), Utility.DoubleParse(array[num2 + 9]));
				_0023_003Dz1v6oPQk_003D[j][2] = new Vector3D(Utility.DoubleParse(array[num2 + 2]), Utility.DoubleParse(array[num2 + 6]), Utility.DoubleParse(array[num2 + 10]));
				_0023_003Dz1v6oPQk_003D[j][3] = new Vector3D(Utility.DoubleParse(array[num2 + 3]), Utility.DoubleParse(array[num2 + 7]), Utility.DoubleParse(array[num2 + 11]));
				num2 += 12;
			}
		}
	}
}
