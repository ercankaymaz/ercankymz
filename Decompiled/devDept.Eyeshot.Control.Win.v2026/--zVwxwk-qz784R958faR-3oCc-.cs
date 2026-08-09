using System.Diagnostics;
using SharpDX;
using devDept.Graphics;

internal struct _0023_003DzVwxwk_0024qz784R958faR_00243oCc_003D : IGraphicMaterial
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Color4 _0023_003Dz0rG_3k0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Color4 _0023_003DzXN4q_0024zeq8iDq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Color4 _0023_003DzFExOpyHXYZdN17OpLQ_003D_003D;

	private float[] _0023_003DzFaL_GcUMaG9GDLAeNRGudwj_Qo5q4rcZNfB4jlg_003D()
	{
		return _0023_003Dz0rG_3k0_003D.ToArray();
	}

	float[] IGraphicMaterial.get_Ambient()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zFaL_GcUMaG9GDLAeNRGudwj_Qo5q4rcZNfB4jlg=
		return this._0023_003DzFaL_GcUMaG9GDLAeNRGudwj_Qo5q4rcZNfB4jlg_003D();
	}

	private float[] _0023_003Dzr0g2eVljfSRi5d3_JMRVnEVSF2Hlt4NDPSfOZMFDwMbj()
	{
		return _0023_003DzXN4q_0024zeq8iDq.ToArray();
	}

	float[] IGraphicMaterial.get_Diffuse()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zr0g2eVljfSRi5d3_JMRVnEVSF2Hlt4NDPSfOZMFDwMbj
		return this._0023_003Dzr0g2eVljfSRi5d3_JMRVnEVSF2Hlt4NDPSfOZMFDwMbj();
	}

	private float[] _0023_003DzLflCNWb3eh6Vv7zd5qCPy4ayawtkKWKE2kml443zhXYG()
	{
		return _0023_003DzFExOpyHXYZdN17OpLQ_003D_003D.ToArray();
	}

	float[] IGraphicMaterial.get_Specular()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zLflCNWb3eh6Vv7zd5qCPy4ayawtkKWKE2kml443zhXYG
		return this._0023_003DzLflCNWb3eh6Vv7zd5qCPy4ayawtkKWKE2kml443zhXYG();
	}

	private float _0023_003DzJcst7cxGtq_00246f9bHGsUz7UVrmoubtx0H4g6aw4bYYfMbT8iwpw_003D_003D()
	{
		return 0f;
	}

	float IGraphicMaterial.get_Shininess()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zJcst7cxGtq$6f9bHGsUz7UVrmoubtx0H4g6aw4bYYfMbT8iwpw==
		return this._0023_003DzJcst7cxGtq_00246f9bHGsUz7UVrmoubtx0H4g6aw4bYYfMbT8iwpw_003D_003D();
	}
}
