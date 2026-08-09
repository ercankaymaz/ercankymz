using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;

internal sealed class _0023_003DzzqQMnVz1u4B7Ao5VuLHfFnIEzCMKuUZ_0024gQ_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	public Point3D[] _0023_003DzFsatqHw_003D;

	public _0023_003DzzqQMnVz1u4B7Ao5VuLHfFnIEzCMKuUZ_0024gQ_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, string _0023_003DzaROjBYA_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzaROjBYA_003D, Color.Black)
	{
		_0023_003DzFsatqHw_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		_0023_003Dz4_0024W9kMn1nUWQ = 502;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988087);
		_0023_003Dz_00248bbpaP5fwnx = 1;
	}

	public _0023_003DzzqQMnVz1u4B7Ao5VuLHfFnIEzCMKuUZ_0024gQ_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, 0, 0, 0, _0023_003DzGD9w0Nw_003D: true, _0023_003Dz0HpIYNA_003D: false, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		int num = _0023_003DzFsatqHw_003D.Length;
		_0023_003Dzf0R_9gymLWqU(num, ',');
		Point3D point3D;
		for (int i = 0; i < num - 1; i++)
		{
			point3D = _0023_003DzFsatqHw_003D[i];
			_0023_003Dz4hSg1gGy0FEl(point3D.X, ',');
			_0023_003Dz4hSg1gGy0FEl(point3D.Y, ',');
			_0023_003Dz4hSg1gGy0FEl(point3D.Z, ',');
		}
		point3D = _0023_003DzFsatqHw_003D[num - 1];
		_0023_003Dz4hSg1gGy0FEl(point3D.X, ',');
		_0023_003Dz4hSg1gGy0FEl(point3D.Y, ',');
		_0023_003Dz4hSg1gGy0FEl(point3D.Z, ';');
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		int num = _0023_003Dz38od8vOHDENlXGsAjsoZ8Xiqrhhr1igKCJg65bo_003D._0023_003DzOGf_0024qVfKC_ZL(array[1]);
		_0023_003DzFsatqHw_003D = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			_0023_003DzFsatqHw_003D[i] = new Point3D(Utility.DoubleParse(array[2 + i * 3]), Utility.DoubleParse(array[3 + i * 3]), Utility.DoubleParse(array[4 + i * 3]));
		}
	}
}
