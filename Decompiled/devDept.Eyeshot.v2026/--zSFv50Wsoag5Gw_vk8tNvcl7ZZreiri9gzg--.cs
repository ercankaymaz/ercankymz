using devDept.Eyeshot;
using devDept.Geometry;

internal sealed class _0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D : MeshEditor
{
	public _0023_003DzSFv50Wsoag5Gw_vk8tNvcl7ZZreiri9gzg_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		: base(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
	}

	public bool _0023_003DzFPEj_mZrLVDn(int _0023_003DzbUvT9Pc_003D, int[] _0023_003DzzRR2S30_003D)
	{
		return _0023_003DzFPEj_mZrLVDn(base.Vertices[_0023_003DzbUvT9Pc_003D], _0023_003DzzRR2S30_003D);
	}

	public bool _0023_003DzFPEj_mZrLVDn(Point2D _0023_003DzbUvT9Pc_003D, int[] _0023_003DzzRR2S30_003D)
	{
		if (_0023_003DzzRR2S30_003D.Length < 1)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DzzRR2S30_003D.Length; i++)
		{
			int num = _0023_003DzzRR2S30_003D[i];
			int num2 = _0023_003DzzRR2S30_003D[(i + 1) % _0023_003DzzRR2S30_003D.Length];
			if (!_0023_003Dzl3Q_0024_0024QA_003D(_0023_003DzbUvT9Pc_003D, base.Vertices[num], base.Vertices[num2]))
			{
				return false;
			}
		}
		return true;
	}

	public bool _0023_003Dz3Wlh2oaz6fuw(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		int v;
		SharedEdge edge = GetEdge(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, out v);
		int[] _0023_003DzCjKvDZD851nk;
		return _0023_003Dz3Wlh2oaz6fuw(v, edge, out _0023_003DzCjKvDZD851nk);
	}

	public bool _0023_003Dz3Wlh2oaz6fuw(int _0023_003DzffqPLNQ_003D, SharedEdge _0023_003DzTx2aqr8_003D, out int[] _0023_003DzCjKvDZD851nk)
	{
		_0023_003DzCjKvDZD851nk = null;
		if (_0023_003DzTx2aqr8_003D.Dad < 0)
		{
			return false;
		}
		IndexTriangle mum = base.Triangles[_0023_003DzTx2aqr8_003D.Mum];
		IndexTriangle dad = base.Triangles[_0023_003DzTx2aqr8_003D.Dad];
		_0023_003DzCjKvDZD851nk = MeshEditor.Quad(mum, dad, _0023_003DzffqPLNQ_003D, _0023_003DzTx2aqr8_003D.V2);
		if (_0023_003Dzl3Q_0024_0024QA_003D(_0023_003DzCjKvDZD851nk[1], _0023_003DzCjKvDZD851nk[2], _0023_003DzCjKvDZD851nk[3]))
		{
			return _0023_003Dzl3Q_0024_0024QA_003D(_0023_003DzCjKvDZD851nk[3], _0023_003DzCjKvDZD851nk[0], _0023_003DzCjKvDZD851nk[1]);
		}
		return false;
	}

	public bool _0023_003Dzl3Q_0024_0024QA_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzZe6oCrQ_003D)
	{
		return _0023_003Dzl3Q_0024_0024QA_003D(base.Vertices[_0023_003DzffqPLNQ_003D], base.Vertices[_0023_003Dz5Azd7L8_003D], base.Vertices[_0023_003DzZe6oCrQ_003D]);
	}

	public bool _0023_003Dzl3Q_0024_0024QA_003D(IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D)
	{
		return _0023_003Dzl3Q_0024_0024QA_003D(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3);
	}

	public bool _0023_003Dzl3Q_0024_0024QA_003D(Point2D _0023_003DzFj_0024IqDQ_003D, Point2D _0023_003DzjdeMMkk_003D, Point2D _0023_003Dzm4eSPQQ_003D)
	{
		return _0023_003Dz0B52BHY_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D) > 0.0;
	}

	public double _0023_003Dz0B52BHY_003D(Point2D _0023_003DzFj_0024IqDQ_003D, Point2D _0023_003DzjdeMMkk_003D, Point2D _0023_003Dzm4eSPQQ_003D)
	{
		return 0.5 * ((0.0 - (_0023_003DzjdeMMkk_003D.X - _0023_003DzFj_0024IqDQ_003D.X)) * (_0023_003DzFj_0024IqDQ_003D.Y - _0023_003Dzm4eSPQQ_003D.Y) + (_0023_003DzjdeMMkk_003D.Y - _0023_003DzFj_0024IqDQ_003D.Y) * (_0023_003DzFj_0024IqDQ_003D.X - _0023_003Dzm4eSPQQ_003D.X));
	}
}
