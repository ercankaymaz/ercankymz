using System.Collections.Generic;

internal sealed class _0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D : _0023_003DzUQB2kRME9xLX78IfsYf5M4A_003D
{
	internal List<_0023_003DzUQB2kRME9xLX78IfsYf5M4A_003D> _0023_003Dz2Da2iiF0bXnNbxfehw_003D_003D = new List<_0023_003DzUQB2kRME9xLX78IfsYf5M4A_003D>();

	public List<_0023_003DzUQB2kRME9xLX78IfsYf5M4A_003D> _0023_003DzTSAXx7Mw5HqJkcM_Ig_003D_003D()
	{
		return _0023_003Dz2Da2iiF0bXnNbxfehw_003D_003D;
	}

	~_0023_003DzxPLDd_00245_JarLmp5aLIuPrE4_003D()
	{
		_0023_003DztXK6GnE_003D();
	}

	public void _0023_003DztXK6GnE_003D()
	{
		for (int i = 0; i < _0023_003Dz2Da2iiF0bXnNbxfehw_003D_003D.Count; i++)
		{
			_0023_003Dz2Da2iiF0bXnNbxfehw_003D_003D[i] = null;
		}
		_0023_003Dz2Da2iiF0bXnNbxfehw_003D_003D.Clear();
		_0023_003DzEIQQk_TkMw0Qa_Nh_g_003D_003D.Clear();
	}

	public _0023_003DzUQB2kRME9xLX78IfsYf5M4A_003D _0023_003Dza7R8tDo_003D()
	{
		if (_0023_003DzEIQQk_TkMw0Qa_Nh_g_003D_003D.Count > 0)
		{
			return _0023_003DzEIQQk_TkMw0Qa_Nh_g_003D_003D[0];
		}
		return null;
	}

	public int _0023_003DziNvyGmCYVSgV()
	{
		int num = _0023_003Dz2Da2iiF0bXnNbxfehw_003D_003D.Count;
		if (num > 0 && _0023_003DzEIQQk_TkMw0Qa_Nh_g_003D_003D[0] != _0023_003Dz2Da2iiF0bXnNbxfehw_003D_003D[0])
		{
			num--;
		}
		return num;
	}
}
