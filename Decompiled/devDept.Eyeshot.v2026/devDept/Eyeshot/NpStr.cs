using System;

namespace devDept.Eyeshot;

[Serializable]
internal sealed class NpStr
{
	public int ident;

	public int hnp;

	public int ort;

	public int lab;

	public int len;

	public int b;

	public void _0023_003DzbByTzLTAlIM7(NpStr _0023_003Dz_0024n2nrac_003D)
	{
		b = _0023_003Dz_0024n2nrac_003D.b;
		hnp = _0023_003Dz_0024n2nrac_003D.hnp;
		ident = _0023_003Dz_0024n2nrac_003D.ident;
		lab = _0023_003Dz_0024n2nrac_003D.lab;
		len = _0023_003Dz_0024n2nrac_003D.len;
		ort = _0023_003Dz_0024n2nrac_003D.ort;
	}

	public void _0023_003DztGdcVOA_003D()
	{
		b = 0;
		hnp = 0;
		ident = 0;
		lab = 0;
		len = 0;
		ort = 0;
	}
}
