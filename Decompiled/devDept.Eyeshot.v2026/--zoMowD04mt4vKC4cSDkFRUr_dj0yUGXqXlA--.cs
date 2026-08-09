using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;

internal sealed class _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	public _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D(Color _0023_003Dz1MMYB1g_003D, string _0023_003DzaROjBYA_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986469), _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzaROjBYA_003D, _0023_003Dz1MMYB1g_003D)
	{
		_0023_003Dz4_0024W9kMn1nUWQ = 314;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829);
	}

	public _0023_003DzoMowD04mt4vKC4cSDkFRUr_dj0yUGXqXlA_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		double _0023_003DzPzO_0024GUk_003D = (double)(100 * _0023_003Dz1MMYB1g_003D.R) / 255.0;
		double _0023_003DzPzO_0024GUk_003D2 = (double)(100 * _0023_003Dz1MMYB1g_003D.G) / 255.0;
		double _0023_003DzPzO_0024GUk_003D3 = (double)(100 * _0023_003Dz1MMYB1g_003D.B) / 255.0;
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzPzO_0024GUk_003D, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzPzO_0024GUk_003D2, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzPzO_0024GUk_003D3, ';');
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		int red = (int)(Utility.DoubleParse(array[1]) * 255.0 / 100.0);
		int green = (int)(Utility.DoubleParse(array[2]) * 255.0 / 100.0);
		int blue = (int)(Utility.DoubleParse(array[3]) * 255.0 / 100.0);
		_0023_003Dz1MMYB1g_003D = Color.FromArgb(red, green, blue);
	}

	public Color _0023_003Dz_8C3BH8_003D()
	{
		return _0023_003Dz1MMYB1g_003D;
	}
}
