using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;

internal sealed class _0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	public Point3D _0023_003DzAqOpw0w_003D;

	public Point3D _0023_003Dzk64JNOo_003D;

	public _0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D(Point3D _0023_003DzAqOpw0w_003D, Point3D _0023_003Dzk64JNOo_003D, bool _0023_003Dz_002418Nebs_KL8i, string _0023_003DzaROjBYA_003D, Color _0023_003Dz1MMYB1g_003D, bool _0023_003Dz_KjZG5vEM9v9)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i, _0023_003DzaROjBYA_003D, _0023_003Dz1MMYB1g_003D)
	{
		this._0023_003DzAqOpw0w_003D = _0023_003DzAqOpw0w_003D;
		this._0023_003Dzk64JNOo_003D = _0023_003Dzk64JNOo_003D;
		_0023_003Dz4_0024W9kMn1nUWQ = 110;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987655);
	}

	public _0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003DzpsRKBgeDZGw4, int _0023_003DzVruOeK_soNft, int _0023_003Dztfry3Xjye35X, bool _0023_003DzGD9w0Nw_003D, bool _0023_003Dz0HpIYNA_003D, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, _0023_003DzpsRKBgeDZGw4, _0023_003DzVruOeK_soNft, _0023_003Dztfry3Xjye35X, _0023_003DzGD9w0Nw_003D, _0023_003Dz0HpIYNA_003D, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public Point3D _0023_003DzTlWHc6c_003D()
	{
		return _0023_003DzAqOpw0w_003D;
	}

	public Point3D _0023_003Dz6FBK7II_003D()
	{
		return _0023_003Dzk64JNOo_003D;
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzAqOpw0w_003D.X, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzAqOpw0w_003D.Y, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzAqOpw0w_003D.Z, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzk64JNOo_003D.X, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzk64JNOo_003D.Y, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003Dzk64JNOo_003D.Z, ';');
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		_0023_003DzAqOpw0w_003D = new Point3D(Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2]), Utility.DoubleParse(array[3]));
		_0023_003Dzk64JNOo_003D = new Point3D(Utility.DoubleParse(array[4]), Utility.DoubleParse(array[5]), Utility.DoubleParse(array[6]));
	}
}
