using System.Collections.Generic;
using System.Drawing;
using devDept.Geometry;

internal sealed class _0023_003DzWaDC3cb0r3lI0VgI_0024kKEmG92hIMMgnulmw_003D_003D : _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D
{
	public Vector3D _0023_003DzIpfJsg67FhT0;

	public _0023_003DzWaDC3cb0r3lI0VgI_0024kKEmG92hIMMgnulmw_003D_003D(Vector3D _0023_003DzCJkr8nY_003D, string _0023_003DzaROjBYA_003D)
		: base(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986247), _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzaROjBYA_003D, Color.Black)
	{
		_0023_003DzIpfJsg67FhT0 = _0023_003DzCJkr8nY_003D;
		_0023_003Dz4_0024W9kMn1nUWQ = 123;
		_0023_003Dz0wko66oIrfDg = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986399);
	}

	public _0023_003DzWaDC3cb0r3lI0VgI_0024kKEmG92hIMMgnulmw_003D_003D(int _0023_003DzWmSBQy2wUHb8, int _0023_003Dz_00248bbpaP5fwnx)
		: base(_0023_003DzWmSBQy2wUHb8, 0, 0, 0, _0023_003DzGD9w0Nw_003D: true, _0023_003Dz0HpIYNA_003D: false, _0023_003Dz_00248bbpaP5fwnx)
	{
	}

	public override void _0023_003DzcVkKHrQ_003D(Dictionary<string, int> _0023_003DzjXvuTiW0UCSS)
	{
		base._0023_003DzcVkKHrQ_003D(_0023_003DzjXvuTiW0UCSS);
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzIpfJsg67FhT0.X, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzIpfJsg67FhT0.Y, ',');
		_0023_003Dz4hSg1gGy0FEl(_0023_003DzIpfJsg67FhT0.Z, ';');
	}

	public override void _0023_003Dzs4pJKQU_003D(string _0023_003DzELu0Pss_003D, List<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003DzbFI4OcecSfvaNAbm_0024w_003D_003D)
	{
		string[] array = _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D._0023_003DzhLfptdvMeg_0024X(_0023_003DzELu0Pss_003D);
		_0023_003DzIpfJsg67FhT0 = new Vector3D(Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2]), Utility.DoubleParse(array[3]));
	}
}
