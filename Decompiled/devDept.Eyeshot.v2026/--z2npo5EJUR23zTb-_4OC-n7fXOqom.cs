using System;

internal sealed class _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom
{
	public int _0023_003DzQW_0024hBdI_003D;

	public int _0023_003DzCmn_5Z0_003D;

	public int _0023_003DzqePf_00244c_003D;

	public readonly bool _0023_003Dz7vjfoLA_003D;

	public readonly int[][] _0023_003DzhMDfC7g_003D;

	public _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom(int[][] _0023_003Dzcv8o5nO25OjS)
	{
		_0023_003DzhMDfC7g_003D = _0023_003Dzcv8o5nO25OjS;
		_0023_003DzKBTqdfsMT5pPIyN8xg_003D_003D();
		_0023_003Dz7vjfoLA_003D = _0023_003DzhMDfC7g_003D[0].Length < 4;
	}

	private void _0023_003DzKBTqdfsMT5pPIyN8xg_003D_003D()
	{
		_0023_003DzQW_0024hBdI_003D = _0023_003DzhMDfC7g_003D[0][0];
		_0023_003DzCmn_5Z0_003D = _0023_003DzhMDfC7g_003D[0][1];
		_0023_003DzqePf_00244c_003D = _0023_003DzhMDfC7g_003D[0][2];
	}

	internal void _0023_003Dz0wcqTpk_003D()
	{
		int[][] array = _0023_003DzhMDfC7g_003D;
		for (int i = 0; i < array.Length; i++)
		{
			Array.Reverse(array[i]);
		}
		_0023_003DzKBTqdfsMT5pPIyN8xg_003D_003D();
	}

	internal _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom _0023_003Dzx9P_oXY_003D()
	{
		int[][] array = new int[_0023_003DzhMDfC7g_003D.Length][];
		for (int i = 0; i < _0023_003DzhMDfC7g_003D.Length; i++)
		{
			array[i] = new int[_0023_003DzhMDfC7g_003D[i].Length];
			Array.Copy(_0023_003DzhMDfC7g_003D[i], array[i], _0023_003DzhMDfC7g_003D[i].Length);
		}
		return new _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom(array);
	}
}
