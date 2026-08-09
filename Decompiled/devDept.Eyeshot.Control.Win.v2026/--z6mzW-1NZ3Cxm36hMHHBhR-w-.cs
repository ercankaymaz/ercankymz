using System;
using System.Diagnostics;
using SharpDX;
using devDept.Graphics;

internal struct _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D : ILightsData
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003Dz0rG_3k0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003DzXN4q_0024zeq8iDq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector4 _0023_003DzFExOpyHXYZdN17OpLQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector3 _0023_003DzJuJanCE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzbiPzcTk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector3 _0023_003DzEsu9Jcc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzObmXzlJIFTmL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector3 _0023_003Dzs91I1MdqldH0pe8iOA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003Dz4r_0024mn64_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzGhupw8QIiPQeTSq64g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public float _0023_003DzBjT3PLCBXnbL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector2 _0023_003Dzu6Q8WDg_003D;

	internal void _0023_003DzCCBca0k_003D(bool _0023_003DzQVsx1WI_003D, float[] _0023_003DzUmTol9c_00244XPu, float[] _0023_003DzRKLdjpmJ7vaB, float[] _0023_003DzQsX1HgPWEjDNkVh76A_003D_003D)
	{
		_0023_003DzbiPzcTk_003D = (_0023_003DzQVsx1WI_003D ? 1 : 0);
		if (_0023_003DzQVsx1WI_003D && _0023_003DzUmTol9c_00244XPu != null)
		{
			_0023_003DzXN4q_0024zeq8iDq = new Vector4(_0023_003DzUmTol9c_00244XPu);
			_0023_003Dz0rG_3k0_003D = new Vector4(_0023_003DzRKLdjpmJ7vaB);
			_0023_003DzFExOpyHXYZdN17OpLQ_003D_003D = new Vector4(_0023_003DzQsX1HgPWEjDNkVh76A_003D_003D);
		}
	}

	private float[] _0023_003DzrpyFNrIsXmBPWxXlFw5Ear9Xc_lEZ6J4uw_003D_003D()
	{
		return _0023_003DzEsu9Jcc_003D.ToArray();
	}

	float[] ILightsData.get_Position()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zrpyFNrIsXmBPWxXlFw5Ear9Xc_lEZ6J4uw==
		return this._0023_003DzrpyFNrIsXmBPWxXlFw5Ear9Xc_lEZ6J4uw_003D_003D();
	}

	private float[] _0023_003Dzmi_h_00246nI_48XIA6eI5NwVZ_rZHQ01agkmA_003D_003D()
	{
		return _0023_003DzJuJanCE_003D.ToArray();
	}

	float[] ILightsData.get_Direction()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zmi_h$6nI_48XIA6eI5NwVZ_rZHQ01agkmA==
		return this._0023_003Dzmi_h_00246nI_48XIA6eI5NwVZ_rZHQ01agkmA_003D_003D();
	}

	private float[] _0023_003Dzc2pV4JSyS0F0WuXF_0024SlM_2TIw0_0024UCDgIuQ_003D_003D()
	{
		return _0023_003Dz0rG_3k0_003D.ToArray();
	}

	float[] ILightsData.get_Ambient()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zc2pV4JSyS0F0WuXF$SlM_2TIw0$UCDgIuQ==
		return this._0023_003Dzc2pV4JSyS0F0WuXF_0024SlM_2TIw0_0024UCDgIuQ_003D_003D();
	}

	private float[] _0023_003DzMhFw7qB8WxSLdCxwWDAgA6RzqjB2zt8uUisv_hLNvO_U()
	{
		return _0023_003DzXN4q_0024zeq8iDq.ToArray();
	}

	float[] ILightsData.get_Diffuse()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zMhFw7qB8WxSLdCxwWDAgA6RzqjB2zt8uUisv_hLNvO_U
		return this._0023_003DzMhFw7qB8WxSLdCxwWDAgA6RzqjB2zt8uUisv_hLNvO_U();
	}

	private float[] _0023_003DzscsCntPsq39UdgPdjxElDC5TQOufWM0AF0011Gk1bsO_0024()
	{
		return _0023_003DzFExOpyHXYZdN17OpLQ_003D_003D.ToArray();
	}

	float[] ILightsData.get_Specular()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zscsCntPsq39UdgPdjxElDC5TQOufWM0AF0011Gk1bsO$
		return this._0023_003DzscsCntPsq39UdgPdjxElDC5TQOufWM0AF0011Gk1bsO_0024();
	}

	private float _0023_003DzRc3mE_0024sVb0Lqmd55DFW2g_TnLC3ATN57_0024moprOAhOeJN5DII7A_003D_003D()
	{
		return _0023_003Dzs91I1MdqldH0pe8iOA_003D_003D.X;
	}

	float ILightsData.get_ConstantAttenuation()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zRc3mE$sVb0Lqmd55DFW2g_TnLC3ATN57$moprOAhOeJN5DII7A==
		return this._0023_003DzRc3mE_0024sVb0Lqmd55DFW2g_TnLC3ATN57_0024moprOAhOeJN5DII7A_003D_003D();
	}

	private float _0023_003Dz_t2ue76YykUqtVQF23daPlUUYzxjH7cZftfqRicWA6mOTOcwkg_003D_003D()
	{
		return _0023_003Dzs91I1MdqldH0pe8iOA_003D_003D.Y;
	}

	float ILightsData.get_LinearAttenuation()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z_t2ue76YykUqtVQF23daPlUUYzxjH7cZftfqRicWA6mOTOcwkg==
		return this._0023_003Dz_t2ue76YykUqtVQF23daPlUUYzxjH7cZftfqRicWA6mOTOcwkg_003D_003D();
	}

	private float _0023_003DzpklLGsMtsdSh_0024pwGXHD_00242iC3_K39UahoyGH1uxBoNsibngPKFQ_003D_003D()
	{
		return _0023_003Dzs91I1MdqldH0pe8iOA_003D_003D.Z;
	}

	float ILightsData.get_QuadraticAttenuation()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zpklLGsMtsdSh$pwGXHD$2iC3_K39UahoyGH1uxBoNsibngPKFQ==
		return this._0023_003DzpklLGsMtsdSh_0024pwGXHD_00242iC3_K39UahoyGH1uxBoNsibngPKFQ_003D_003D();
	}

	private float _0023_003DzbHbdHdtJ64ajcIlbBaK2u0ZAfgZfcbV_0024BCctHvA_W7nP()
	{
		return _0023_003DzGhupw8QIiPQeTSq64g_003D_003D;
	}

	float ILightsData.get_SpotCosCutoff()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zbHbdHdtJ64ajcIlbBaK2u0ZAfgZfcbV$BCctHvA_W7nP
		return this._0023_003DzbHbdHdtJ64ajcIlbBaK2u0ZAfgZfcbV_0024BCctHvA_W7nP();
	}

	private float _0023_003Dz_jpNi4EzqwXajEc_0024AWpX4dPZnv8J89qkt3T78ow_003D()
	{
		return _0023_003DzObmXzlJIFTmL;
	}

	float ILightsData.get_SpotExponent()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z_jpNi4EzqwXajEc$AWpX4dPZnv8J89qkt3T78ow=
		return this._0023_003Dz_jpNi4EzqwXajEc_0024AWpX4dPZnv8J89qkt3T78ow_003D();
	}

	private int _0023_003DzNM_0024UUGHpA_0024SgprdsE7Y4heF_eEz9rYpr0JA9VS8_003D()
	{
		return (int)Math.Floor(_0023_003DzBjT3PLCBXnbL);
	}

	int ILightsData.get_YieldShadow()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zNM$UUGHpA$SgprdsE7Y4heF_eEz9rYpr0JA9VS8=
		return this._0023_003DzNM_0024UUGHpA_0024SgprdsE7Y4heF_eEz9rYpr0JA9VS8_003D();
	}

	private lightType _0023_003Dz3ZrYD0ncvA_DRd_5EU_k5tHf_00249vIldC_0024oQ_003D_003D()
	{
		return (lightType)_0023_003Dz4r_0024mn64_003D;
	}

	lightType ILightsData.get_Type()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z3ZrYD0ncvA_DRd_5EU_k5tHf$9vIldC$oQ==
		return this._0023_003Dz3ZrYD0ncvA_DRd_5EU_k5tHf_00249vIldC_0024oQ_003D_003D();
	}
}
