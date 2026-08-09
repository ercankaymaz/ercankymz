using System.Diagnostics;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Translators;
using devDept.Serialization;

internal sealed class _0023_003DzyfpgbkoqJF24YFxVKu2FD0mBwXw2xTILyn_ppCVbzxH1 : WriteFile
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string[] _0023_003Dzh2fc4Px1d96Izw29vg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private fileType[] _0023_003DzF0pJQYivdRevJaPuYQ_003D_003D;

	public _0023_003DzyfpgbkoqJF24YFxVKu2FD0mBwXw2xTILyn_ppCVbzxH1(WriteFileParams _0023_003DzRZgBnidtSRIp, string _0023_003Dzg5oC_Hs_003D, Block _0023_003DzK8Kwyo8MF5AD, Camera _0023_003Dz10qtbIGWAWjL, byte[] _0023_003Dzes3OoosNHoOi6yRH1w_003D_003D, string[] _0023_003DzCULckQQ_003D, fileType[] _0023_003DzTLd6lkE_003D, FileSerializer _0023_003DzqCbQjE_0024V12fc = null)
		: base(_0023_003DzRZgBnidtSRIp, _0023_003Dzg5oC_Hs_003D, _0023_003DzqCbQjE_0024V12fc)
	{
		_0023_003DzHrYpAw_0024SXjJ2(_0023_003DzCULckQQ_003D);
		_0023_003DzxtRI_ZERsq3U(_0023_003DzTLd6lkE_003D);
		base._0023_003DzK8Kwyo8MF5AD = _0023_003DzK8Kwyo8MF5AD;
		base._0023_003Dz10qtbIGWAWjL = _0023_003Dz10qtbIGWAWjL;
		base._0023_003Dzes3OoosNHoOi6yRH1w_003D_003D = _0023_003Dzes3OoosNHoOi6yRH1w_003D_003D;
		_0023_003DzK8Kwyo8MF5AD._filePath = _0023_003Dzg5oC_Hs_003D;
	}

	public string[] _0023_003DzSdjataLNnYJ8()
	{
		return _0023_003Dzh2fc4Px1d96Izw29vg_003D_003D;
	}

	private void _0023_003DzHrYpAw_0024SXjJ2(string[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzh2fc4Px1d96Izw29vg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public fileType[] _0023_003DzKIncAvklEJ6Z()
	{
		return _0023_003DzF0pJQYivdRevJaPuYQ_003D_003D;
	}

	private void _0023_003DzxtRI_ZERsq3U(fileType[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzF0pJQYivdRevJaPuYQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal override void _0023_003DzZag1e9zhSIvR(FileBody _0023_003Dzk347ngQ_003D)
	{
		base._0023_003DzZag1e9zhSIvR(_0023_003Dzk347ngQ_003D);
		_0023_003Dzk347ngQ_003D.Paths = _0023_003DzSdjataLNnYJ8().ToArray();
		_0023_003Dzk347ngQ_003D.Types = _0023_003DzKIncAvklEJ6Z().ToArray();
	}

	internal override fileType _0023_003Dz_EydSol_JO59()
	{
		return fileType.Assembly;
	}
}
