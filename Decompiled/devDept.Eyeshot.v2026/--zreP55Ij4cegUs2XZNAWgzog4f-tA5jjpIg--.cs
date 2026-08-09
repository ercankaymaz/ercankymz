using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;

internal sealed class _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	private double[,] _0023_003Dzy_WOH9c_003D;

	internal _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D(Transformation _0023_003DzNDQ_E88_003D, string _0023_003DzaROjBYA_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzaROjBYA_003D, Color.Black)
	{
		_0023_003Dzy_WOH9c_003D = new double[4, 4];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				_0023_003Dzy_WOH9c_003D[i, j] = _0023_003DzNDQ_E88_003D.Matrix[i, j];
			}
		}
		_0023_003Dz4_0024W9kMn1nUWQ = 124;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988121);
	}

	public _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D(double[,] _0023_003DzlTrXFNo_003D, string _0023_003DzaROjBYA_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzaROjBYA_003D, Color.Black)
	{
		_0023_003Dzy_WOH9c_003D = _0023_003DzlTrXFNo_003D;
		_0023_003Dz4_0024W9kMn1nUWQ = 124;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988121);
	}

	public _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[0, 0], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[0, 1], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[0, 2], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[0, 3], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[1, 0], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[1, 1], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[1, 2], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[1, 3], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[2, 0], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[2, 1], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[2, 2], ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzy_WOH9c_003D[2, 3], ';');
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		_0023_003Dzy_WOH9c_003D = new double[4, 4];
		_0023_003Dzy_WOH9c_003D[0, 0] = Utility.DoubleParse(array[1]);
		_0023_003Dzy_WOH9c_003D[0, 1] = Utility.DoubleParse(array[2]);
		_0023_003Dzy_WOH9c_003D[0, 2] = Utility.DoubleParse(array[3]);
		_0023_003Dzy_WOH9c_003D[0, 3] = Utility.DoubleParse(array[4]);
		_0023_003Dzy_WOH9c_003D[1, 0] = Utility.DoubleParse(array[5]);
		_0023_003Dzy_WOH9c_003D[1, 1] = Utility.DoubleParse(array[6]);
		_0023_003Dzy_WOH9c_003D[1, 2] = Utility.DoubleParse(array[7]);
		_0023_003Dzy_WOH9c_003D[1, 3] = Utility.DoubleParse(array[8]);
		_0023_003Dzy_WOH9c_003D[2, 0] = Utility.DoubleParse(array[9]);
		_0023_003Dzy_WOH9c_003D[2, 1] = Utility.DoubleParse(array[10]);
		_0023_003Dzy_WOH9c_003D[2, 2] = Utility.DoubleParse(array[11]);
		_0023_003Dzy_WOH9c_003D[2, 3] = Utility.DoubleParse(array[12]);
		_0023_003Dzy_WOH9c_003D[3, 3] = 1.0;
	}

	public Transformation _0023_003DzKJgErG0_003D()
	{
		Transformation transformation = new Transformation();
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				transformation.Matrix[i, j] = _0023_003Dzy_WOH9c_003D[i, j];
			}
		}
		return transformation;
	}

	public _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D _0023_003Dz20mUZavLJjBB(out double _0023_003DzrbIvx9sfBtxt)
	{
		Transformation transformation = new Transformation(_0023_003Dzy_WOH9c_003D);
		Transformation transformation2 = (Transformation)transformation.Clone();
		_0023_003DzrbIvx9sfBtxt = transformation.ScaleFactorX;
		if (Utility.Compare(Utility._0023_003DzxhnLabVjXjPg, _0023_003DzrbIvx9sfBtxt, 1.0) != 0)
		{
			transformation2[0, 0] /= _0023_003DzrbIvx9sfBtxt;
			transformation2[0, 1] /= _0023_003DzrbIvx9sfBtxt;
			transformation2[0, 2] /= _0023_003DzrbIvx9sfBtxt;
			transformation2[1, 0] /= _0023_003DzrbIvx9sfBtxt;
			transformation2[1, 1] /= _0023_003DzrbIvx9sfBtxt;
			transformation2[1, 2] /= _0023_003DzrbIvx9sfBtxt;
			transformation2[2, 0] /= _0023_003DzrbIvx9sfBtxt;
			transformation2[2, 1] /= _0023_003DzrbIvx9sfBtxt;
			transformation2[2, 2] /= _0023_003DzrbIvx9sfBtxt;
		}
		return new _0023_003DzreP55Ij4cegUs2XZNAWgzog4f_0024tA5jjpIg_003D_003D(transformation2, _0023_003DzaROjBYA_003D);
	}
}
