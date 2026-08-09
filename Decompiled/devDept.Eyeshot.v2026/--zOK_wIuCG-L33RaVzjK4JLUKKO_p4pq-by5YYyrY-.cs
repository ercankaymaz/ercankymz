using System.Collections.Generic;
using System.Drawing;
using System.IO;
using devDept.Geometry;

internal sealed class _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	private double _0023_003DzjbqS1qE_003D;

	private double _0023_003Dz1v6oPQk_003D;

	private double _0023_003Dzt_m8zV0_003D;

	private double _0023_003DzXrexKjY_003D;

	public Point3D _0023_003Dzc5c05Yz8iyPS = Point3D.Origin;

	public float _0023_003DzYNYzg64_003D = 10f;

	public int _0023_003DzfSYnO55OkU6S = -1;

	private Point3D[] _0023_003DzCgHObYs_003D;

	public _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D(Point3D _0023_003DzeoY7iyo_003D, PlaneEquation _0023_003DzYO5g7Fc_003D, float _0023_003DzYNYzg64_003D, bool _0023_003Dz_002418Nebs_KL8i, string _0023_003DzaROjBYA_003D, Color _0023_003Dz1MMYB1g_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i, _0023_003DzaROjBYA_003D, _0023_003Dz1MMYB1g_003D)
	{
		_0023_003DzjbqS1qE_003D = _0023_003DzYO5g7Fc_003D.X;
		_0023_003Dz1v6oPQk_003D = _0023_003DzYO5g7Fc_003D.Y;
		_0023_003Dzt_m8zV0_003D = _0023_003DzYO5g7Fc_003D.Z;
		_0023_003DzXrexKjY_003D = 0.0 - _0023_003DzYO5g7Fc_003D.D;
		_0023_003Dzc5c05Yz8iyPS = _0023_003DzeoY7iyo_003D;
		this._0023_003DzYNYzg64_003D = _0023_003DzYNYzg64_003D;
		_0023_003Dz4_0024W9kMn1nUWQ = 108;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845);
		_0023_003Dz_00248bbpaP5fwnx = 0;
	}

	public _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D(Point3D[] _0023_003Dz_SqBXz8_003D, bool _0023_003Dz_002418Nebs_KL8i, string _0023_003DzaROjBYA_003D, Color _0023_003Dz1MMYB1g_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i, _0023_003DzaROjBYA_003D, _0023_003Dz1MMYB1g_003D)
	{
		Plane plane = new Plane(_0023_003Dz_SqBXz8_003D[0], _0023_003Dz_SqBXz8_003D[1], _0023_003Dz_SqBXz8_003D[2]);
		_0023_003DzjbqS1qE_003D = plane.Equation.X;
		_0023_003Dz1v6oPQk_003D = plane.Equation.Y;
		_0023_003Dzt_m8zV0_003D = plane.Equation.Z;
		_0023_003DzXrexKjY_003D = 0.0 - plane.Equation.D;
		_0023_003Dzc5c05Yz8iyPS = plane.Origin;
		_0023_003DzCgHObYs_003D = _0023_003Dz_SqBXz8_003D;
		_0023_003Dz4_0024W9kMn1nUWQ = 108;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845);
		_0023_003Dz_00248bbpaP5fwnx = 0;
	}

	public _0023_003DzOK_wIuCG_0024L33RaVzjK4JLUKKO_p4pq_0024by5YYyrY_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public override void _0023_003DzqkDCo38_003D(ref int _0023_003DzyzK8swU_003D, string _0023_003DzaROjBYA_003D)
	{
		if (_0023_003DzCgHObYs_003D != null)
		{
			base._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, _0023_003DzaROjBYA_003D);
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2 = new _0023_003DzCvMCt05pVvqGJGI368UlSvv09UP9pWWmRo3Qh0YGOXCU(_0023_003DzCgHObYs_003D, _0023_003Dzy2VY7ExflvP_: true, _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495), Color.Black);
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, _0023_003DzaROjBYA_003D);
			_0023_003DzfSYnO55OkU6S = _0023_003DzyzK8swU_003D;
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2._0023_003DznXwBXUw4u1qB(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974921));
			_0023_003Dz7qgjasQ_003D.Add(_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D2);
		}
	}

	public void _0023_003Dz_oTa5etYnxbmzrLwqRFtndA_003D(out double _0023_003DzjbqS1qE_003D, out double _0023_003Dz1v6oPQk_003D, out double _0023_003Dzt_m8zV0_003D, out double _0023_003DzXrexKjY_003D)
	{
		_0023_003DzjbqS1qE_003D = this._0023_003DzjbqS1qE_003D;
		_0023_003Dz1v6oPQk_003D = this._0023_003Dz1v6oPQk_003D;
		_0023_003Dzt_m8zV0_003D = this._0023_003Dzt_m8zV0_003D;
		_0023_003DzXrexKjY_003D = this._0023_003DzXrexKjY_003D;
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzjbqS1qE_003D, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dz1v6oPQk_003D, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzt_m8zV0_003D, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzXrexKjY_003D, ',');
		_0023_003Dzf0R_9gymLWqU(_0023_003DzfSYnO55OkU6S, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzc5c05Yz8iyPS.X, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzc5c05Yz8iyPS.Y, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzc5c05Yz8iyPS.Z, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzYNYzg64_003D, ';');
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		_0023_003DzjbqS1qE_003D = Utility.DoubleParse(array[1]);
		_0023_003Dz1v6oPQk_003D = Utility.DoubleParse(array[2]);
		_0023_003Dzt_m8zV0_003D = Utility.DoubleParse(array[3]);
		_0023_003DzXrexKjY_003D = Utility.DoubleParse(array[4]);
		if (array.Length > 5)
		{
			if (!string.IsNullOrEmpty(array[5]))
			{
				_0023_003DzfSYnO55OkU6S = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[5]);
			}
			if (!string.IsNullOrEmpty(array[6]))
			{
				_0023_003Dzc5c05Yz8iyPS = new Point3D(Utility.DoubleParse(array[6]), Utility.DoubleParse(array[7]), Utility.DoubleParse(array[8]));
			}
			if (!string.IsNullOrEmpty(array[9]))
			{
				_0023_003DzYNYzg64_003D = (float)Utility.DoubleParse(array[9]);
			}
		}
	}

	public override void _0023_003DzwnHyM_uvlOeZ(TextWriter _0023_003DzzvTcRNc_003D, ref int _0023_003DzXrBIpWM_003D)
	{
		_0023_003DzD52Km8VSH47Y(_0023_003DzzvTcRNc_003D, _0023_003Dzwzd6NcMCCV_o, 0, 0, 0, 0, 0, _0023_003DzXrBIpWM_003D, 0, 0);
		_0023_003DzXrBIpWM_003D += 2;
	}

	public Plane _0023_003DzNY5YUv279_SW()
	{
		return new Plane(new double[4]
		{
			_0023_003DzjbqS1qE_003D,
			_0023_003Dz1v6oPQk_003D,
			_0023_003Dzt_m8zV0_003D,
			0.0 - _0023_003DzXrexKjY_003D
		});
	}
}
