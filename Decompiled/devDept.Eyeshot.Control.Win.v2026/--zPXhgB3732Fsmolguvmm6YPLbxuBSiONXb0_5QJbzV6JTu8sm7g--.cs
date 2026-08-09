using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

internal sealed class _0023_003DzPXhgB3732Fsmolguvmm6YPLbxuBSiONXb0_5QJbzV6JTu8sm7g_003D_003D : _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D
{
	public _0023_003DzPXhgB3732Fsmolguvmm6YPLbxuBSiONXb0_5QJbzV6JTu8sm7g_003D_003D(string _0023_003DzD8mZsz8_003D, double _0023_003DzW_Mwciw_003D, double _0023_003Dz8DKA0oD3cgK0, Vector3D _0023_003DzURBEAMYs10Da, _0023_003DzemvFlrg_003D _0023_003DzjqAAENI_003D)
		: base(_0023_003DzD8mZsz8_003D, natureType.Smooth, _0023_003DzW_Mwciw_003D, _0023_003Dz8DKA0oD3cgK0, _0023_003DzURBEAMYs10Da, _0023_003DzjqAAENI_003D)
	{
	}

	protected override void _0023_003DzCr91__0024HyQlKJ(DrawParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003Dzt5jpbHs_003D.RenderContext.Draw(drawData);
	}

	internal void _0023_003Dz8WTvZ9I_003D(CompileParams _0023_003Dzt5jpbHs_003D, int[] _0023_003DzdYqgaGA6QkqK, float[] _0023_003DzGU2gw3JkzseVomOrmg_003D_003D, float[] _0023_003DzCPGKLcbme39xHB1UVw_003D_003D)
	{
		InitGraphicsData(_0023_003Dzt5jpbHs_003D.RenderContext);
		_0023_003Dzt5jpbHs_003D.RenderContext.CompileVBO(drawData, delegate(RenderContextBase _0023_003DzoC62DbA_003D, object _0023_003DzCBM7XJK4_5H_0024)
		{
			_0023_003DzoC62DbA_003D.DrawIndexedTriangles((VBOParams)_0023_003DzCBM7XJK4_5H_0024);
		}, new VBOParams
		{
			indices = _0023_003DzdYqgaGA6QkqK,
			vertices = _0023_003DzGU2gw3JkzseVomOrmg_003D_003D,
			normals = _0023_003DzCPGKLcbme39xHB1UVw_003D_003D,
			primitiveMode = primitiveType.TriangleList
		});
	}

	internal void _0023_003DzoUrbLfme_0024y6s_00243FXxczbugU_003D(RenderContextBase _0023_003DzoC62DbA_003D, object _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzoC62DbA_003D.DrawIndexedTriangles((VBOParams)_0023_003DzCBM7XJK4_5H_0024);
	}

	public override void Dispose()
	{
		if (_0023_003DzcJIdS_jd32ls == null)
		{
			base.Dispose();
		}
	}

	public bool _0023_003DzL28lpFu5le27()
	{
		return drawData.NeedToCompile();
	}
}
