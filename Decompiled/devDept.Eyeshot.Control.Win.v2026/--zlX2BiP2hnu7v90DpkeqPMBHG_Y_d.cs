using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using OpenGL;
using devDept.Eyeshot;
using devDept.Geometry;
using devDept.Graphics;

internal class _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d : GLShader, ILightingShader
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzj4q6c_0024PW7mNd_0024ehSZVsgI_c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzj3RwAjX5tL6yLfYF5S50kUIfTzXRpj5XW34AoAkRzPT3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzUkMPGKlmVzI9UNsu0mHF8bHqkCSU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private shadowType _0023_003DzPtMcFBk5ZsdhNhC29J9GRcs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DztpXfRe7XdV_0024LbXqfhaGKWoU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private textureEnvironmentType _0023_003DzHOCp_0024QO2evAN1DOQ25GY4SI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dza25jYzh6cA_0024WgNC6MapXhKQKEFNfDNobuw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private backgroundStyleType _0023_003DzIcLCF_FjGP7j_0024TJsSOAFzvo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? _0023_003DzwmBqrnNnsqlQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? _0023_003DzYpybKChhbmJt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? _0023_003Dzc6p7oMkotQHSAiflykXqPSE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? _0023_003Dz9AceIrCKk0weXjNzhK8cUoM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzBquORJ_LmQ_U;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzySe0kclP2h1Af1Fb4w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? _0023_003DzXT5d7uC7bVvy5CoipvU2kRU_003D;

	public bool Lighting
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn;
		}
	}

	protected void _0023_003Dz_0024Y7C9dH_IHo6(_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d _0023_003DzyQmY6T8_003D)
	{
		vertexCode = _0023_003DzyQmY6T8_003D.vertexCode;
		fragmentCode = _0023_003DzyQmY6T8_003D.fragmentCode;
		_0023_003DzAQQ_Qz7VxA88JZKibg_003D_003D(_0023_003DzyQmY6T8_003D._0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D());
		_0023_003DzaMwYn4fJ3qBlEc7aGXd2gr2I3HJ_xZ9B0w_003D_003D(_0023_003DzyQmY6T8_003D._0023_003DzVN1nvI3DqMA2dnttRXyWjCqYCGK76SA33A_003D_003D());
		_0023_003DzLKhN2lDW8inNJl3qZQ_003D_003D(_0023_003DzyQmY6T8_003D.Lighting);
		_0023_003DzytX7bIMCtjVlL0itcTvowyk_003D(_0023_003DzyQmY6T8_003D._0023_003DzGJ_Tn_0024EAKXCXFLh_HbhyHU0_003D());
		_0023_003DzhIc1LpAQ184G(_0023_003DzyQmY6T8_003D._0023_003DzCjUlAcTjqEDL());
		_0023_003Dz1RIkCaGqJQr6(_0023_003DzyQmY6T8_003D._0023_003DzA0wWpuFALvSD());
		_0023_003Dzbe8n31LqV9P8io8_BRNNZ0ZtWBzc(_0023_003DzyQmY6T8_003D._0023_003DzdgD2ty_bamaCCChq6bLWIT5ciZew());
		_0023_003Dzv_I8VXB8VQ1M(_0023_003DzyQmY6T8_003D._0023_003DzEZgLHYAPuuUJ());
	}

	protected internal int _0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D()
	{
		return _0023_003Dzj4q6c_0024PW7mNd_0024ehSZVsgI_c_003D;
	}

	private void _0023_003DzAQQ_Qz7VxA88JZKibg_003D_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzj4q6c_0024PW7mNd_0024ehSZVsgI_c_003D = _0023_003DzsLHxXyo_003D;
	}

	protected internal bool _0023_003DzVN1nvI3DqMA2dnttRXyWjCqYCGK76SA33A_003D_003D()
	{
		return _0023_003Dzj3RwAjX5tL6yLfYF5S50kUIfTzXRpj5XW34AoAkRzPT3;
	}

	private void _0023_003DzaMwYn4fJ3qBlEc7aGXd2gr2I3HJ_xZ9B0w_003D_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzj3RwAjX5tL6yLfYF5S50kUIfTzXRpj5XW34AoAkRzPT3 = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzLKhN2lDW8inNJl3qZQ_003D_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn = _0023_003DzsLHxXyo_003D;
	}

	protected internal bool _0023_003DzGJ_Tn_0024EAKXCXFLh_HbhyHU0_003D()
	{
		return _0023_003DzUkMPGKlmVzI9UNsu0mHF8bHqkCSU;
	}

	private void _0023_003DzytX7bIMCtjVlL0itcTvowyk_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzUkMPGKlmVzI9UNsu0mHF8bHqkCSU = _0023_003DzsLHxXyo_003D;
	}

	protected internal bool _0023_003Dzi0CGkDUPRSrg()
	{
		return _0023_003DzCjUlAcTjqEDL() == shadowType.Realistic;
	}

	protected internal shadowType _0023_003DzCjUlAcTjqEDL()
	{
		return _0023_003DzPtMcFBk5ZsdhNhC29J9GRcs_003D;
	}

	private void _0023_003DzhIc1LpAQ184G(shadowType _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzPtMcFBk5ZsdhNhC29J9GRcs_003D = _0023_003DzsLHxXyo_003D;
	}

	protected internal bool _0023_003Dz5QEgmA1bHJlJ()
	{
		return _0023_003DztpXfRe7XdV_0024LbXqfhaGKWoU_003D;
	}

	private void _0023_003DzWw67sEhtRls2(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003DztpXfRe7XdV_0024LbXqfhaGKWoU_003D = _0023_003DzsLHxXyo_003D;
	}

	protected internal textureEnvironmentType _0023_003DzA0wWpuFALvSD()
	{
		return _0023_003DzHOCp_0024QO2evAN1DOQ25GY4SI_003D;
	}

	private void _0023_003Dz1RIkCaGqJQr6(textureEnvironmentType _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzHOCp_0024QO2evAN1DOQ25GY4SI_003D = _0023_003DzsLHxXyo_003D;
	}

	protected internal bool _0023_003DzdgD2ty_bamaCCChq6bLWIT5ciZew()
	{
		return _0023_003Dza25jYzh6cA_0024WgNC6MapXhKQKEFNfDNobuw_003D_003D;
	}

	private void _0023_003Dzbe8n31LqV9P8io8_BRNNZ0ZtWBzc(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dza25jYzh6cA_0024WgNC6MapXhKQKEFNfDNobuw_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	protected internal backgroundStyleType _0023_003DzEZgLHYAPuuUJ()
	{
		return _0023_003DzIcLCF_FjGP7j_0024TJsSOAFzvo_003D;
	}

	private void _0023_003Dzv_I8VXB8VQ1M(backgroundStyleType _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzIcLCF_FjGP7j_0024TJsSOAFzvo_003D = _0023_003DzsLHxXyo_003D;
	}

	public virtual void _0023_003DzUMSSRSw_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA)
	{
		_0023_003DzAQQ_Qz7VxA88JZKibg_003D_003D(_0023_003DzgcK4Z11iT1YA.RenderContext.ActiveLights.Length);
		_0023_003DzLKhN2lDW8inNJl3qZQ_003D_003D(_0023_003DzgcK4Z11iT1YA.Lighting);
		_0023_003DzytX7bIMCtjVlL0itcTvowyk_003D(_0023_003DzgcK4Z11iT1YA.Multicolor);
		_0023_003DzhIc1LpAQ184G(_0023_003DzgcK4Z11iT1YA.ShadowMode);
		_0023_003DzaMwYn4fJ3qBlEc7aGXd2gr2I3HJ_xZ9B0w_003D_003D(_0023_003DzgcK4Z11iT1YA.ColorsModulatedByIntensity);
		_0023_003DzWw67sEhtRls2(_0023_003DzgcK4Z11iT1YA.AlphaMap);
		_0023_003Dz1RIkCaGqJQr6(_0023_003DzgcK4Z11iT1YA.TextureEnvironment);
		_0023_003Dzbe8n31LqV9P8io8_BRNNZ0ZtWBzc(_0023_003DzgcK4Z11iT1YA.TextureOverExposure);
		if (_0023_003DzgcK4Z11iT1YA.Background != null)
		{
			_0023_003Dzv_I8VXB8VQ1M(_0023_003DzgcK4Z11iT1YA.Background.StyleMode);
		}
	}

	[SpecialName]
	internal override bool _0023_003DzT5lT1YFdRDAvUzE2Bg_003D_003D()
	{
		if (Lighting)
		{
			return _0023_003Dzi0CGkDUPRSrg();
		}
		return false;
	}

	protected static int _0023_003DzNM31MVCgV2f_(bool _0023_003Dz5PxKZP0_003D)
	{
		return _0023_003Dz5PxKZP0_003D ? 1 : 0;
	}

	public override void Disable(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		base.Disable(_0023_003DzoC62DbA_003D);
		_0023_003DzoC62DbA_003D.SetActiveTexture(TextureBase.textureUnitType.Environment);
		_0023_003DzoC62DbA_003D.SetActiveTexture(TextureBase.textureUnitType.Base);
	}

	public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
	{
		ShaderParameters shaderParameters = (ShaderParameters)_0023_003DzgcK4Z11iT1YA;
		RenderContextBase renderContext = shaderParameters.RenderContext;
		Enable(renderContext);
		if (_0023_003Dz3tVhSIk6FhBCKtkRYw_003D_003D() != -1)
		{
			gl.Uniform1f(_0023_003Dz3tVhSIk6FhBCKtkRYw_003D_003D(), 1f);
		}
		if (shaderParameters is _0023_003Dz7yOiDQOqKH5qbW73eaKlOGASXbRj _0023_003Dz7yOiDQOqKH5qbW73eaKlOGASXbRj2)
		{
			if (shaderParameters.SceneAmbient != null)
			{
				gl.Uniform4fv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608101)), 1, shaderParameters.SceneAmbient);
			}
			if (_0023_003Dzgq26HCPaOKjX() != -1)
			{
				gl.Uniform2fv(_0023_003Dzgq26HCPaOKjX(), 1, _0023_003Dz7yOiDQOqKH5qbW73eaKlOGASXbRj2._0023_003DzNc98jj13QguQ());
			}
		}
		else if (shaderParameters is _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2)
		{
			gl.UniformMatrix4fvARB(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610111)), 1, transpose: false, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2.WorldViewProj);
			gl.UniformMatrix4fvARB(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608114)), 1, transpose: false, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2.WorldView);
			int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608393));
			if (uniformLocation != -1)
			{
				gl.UniformMatrix3fvARB(uniformLocation, 1, transpose: false, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2.WorldViewInvTranspose);
			}
			int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608406));
			if (uniformLocation2 != -1)
			{
				gl.Uniform4f(uniformLocation2, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzAV10KJo_003D._0023_003Dz19V87tw_003D, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzAV10KJo_003D._0023_003DzaKmBh2M_003D, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzAV10KJo_003D._0023_003DzFrc_0024oLQ_003D, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzAV10KJo_003D._0023_003DzDw__wI8_003D);
			}
			_0023_003DqQ_6_0024K2JlS0K8pzfP4mLwKGuemiYalOxcJ0Vax3kIz5TFe2TWptKapstK7ebHrS9x(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608425), _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003Dz9un3NC_M_JPo);
			_0023_003DqQ_6_0024K2JlS0K8pzfP4mLwKGuemiYalOxcJ0Vax3kIz5TFe2TWptKapstK7ebHrS9x(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608437), _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzHPv8IbL56FXb);
			gl.Uniform1f(_0023_003DzJmJcceb3Jx1zTAeXcu67ovk_003D, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003Dzyz_0024bfF2zwT8WPfon7g_003D_003D);
			if (_0023_003DzPdayYnrrWBrXDHbUdSf52XY_003D() != -1)
			{
				gl.Uniform1f(_0023_003DzPdayYnrrWBrXDHbUdSf52XY_003D(), _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzRVNtcj0ilKIsW3W5qA_003D_003D);
			}
			if (_0023_003DzjukP20LeG3PR3PVXFAfYthQ_003D() != -1)
			{
				gl.Uniform1ui(_0023_003DzjukP20LeG3PR3PVXFAfYthQ_003D(), _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzdM7iTrCiMP954JENCg_003D_003D);
			}
			if (_0023_003Dz3tVhSIk6FhBCKtkRYw_003D_003D() != -1)
			{
				gl.Uniform1f(_0023_003Dz3tVhSIk6FhBCKtkRYw_003D_003D(), _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzcLeF_4uietaA);
			}
			if (_0023_003Dzd9rI48ZNs98yXv_00247uXSxGSw_003D() != -1)
			{
				gl.Uniform1f(_0023_003Dzd9rI48ZNs98yXv_00247uXSxGSw_003D(), _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzYRbzTAwIoBjDBgji_0024g_003D_003D);
			}
			return;
		}
		_0023_003DzNRz1hLEBqYKA(shaderParameters.ClipPlanesEnabled, shaderParameters.ClipPlanes);
		if (Lighting)
		{
			if (shaderParameters.Lights != null)
			{
				for (int i = 0; i < shaderParameters.Lights.Length; i++)
				{
					ShaderParameters.LightsData lightsData = shaderParameters.Lights[i];
					gl.Uniform4fv(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608450), i)), 1, (lightsData.Position[3] == 0f) ? lightsData.Direction : lightsData.Position);
					gl.Uniform4fv(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608482), i)), 1, lightsData.Ambient);
					gl.Uniform4fv(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608259), i)), 1, lightsData.Diffuse);
					gl.Uniform4fv(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608292), i)), 1, lightsData.Specular);
					gl.Uniform1f(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608324), i)), lightsData.ConstantAttenuation);
					gl.Uniform1f(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608377), i)), lightsData.LinearAttenuation);
					gl.Uniform1f(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607632), i)), lightsData.QuadraticAttenuation);
					gl.Uniform1f(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607684), i)), lightsData.SpotExponent);
					gl.Uniform3fv(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607712), i)), 1, lightsData.Direction.Take(3).ToArray());
					gl.Uniform1f(GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607515), i)), lightsData.SpotCosCutoff);
				}
			}
			gl.Uniform1i(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607542)), _0023_003DzNM31MVCgV2f_(shaderParameters.Backface.ColorMethod == backfaceColorMethodType.SingleColor));
			if (_0023_003DzGJ_Tn_0024EAKXCXFLh_HbhyHU0_003D())
			{
				if (_0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D() > 0)
				{
					gl.Uniform4fv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607578)), 1, Utility.ColorToFloatArray(shaderParameters.Backface.Color));
				}
				gl.Uniform1i(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607590)), _0023_003DzNM31MVCgV2f_(shaderParameters.UseColorForAmbientAndDiffuse));
				if (shaderParameters.SceneAmbient != null)
				{
					gl.Uniform4fv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608101)), 1, shaderParameters.SceneAmbient);
				}
			}
		}
		if (Lighting && !_0023_003Dzi0CGkDUPRSrg())
		{
			int[] array = new int[_0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D()];
			for (int j = 0; j < _0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D(); j++)
			{
				array[j] = _0023_003DzNM31MVCgV2f_(renderContext.ActiveLights[j].Active);
			}
			gl.Uniform1iv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607875)), _0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D(), array);
		}
		if (_0023_003DzT5lT1YFdRDAvUzE2Bg_003D_003D() && shaderParameters.BlockRefTansformMatrix != null)
		{
			_0023_003DzHC_00247E8Iff85gVpS2Sg_003D_003D();
			gl.UniformMatrix4fvARB(_0023_003Dz2WEszK_0024uPdjGuRGIzQ_003D_003D, 1, transpose: false, shaderParameters.BlockRefTansformMatrix);
		}
		if (_0023_003Dzi0CGkDUPRSrg() && Lighting)
		{
			int[] array2 = new int[_0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D()];
			LightSettings[] activeLights = renderContext.ActiveLights;
			for (int k = 0; k < activeLights.Length; k++)
			{
				array2[k] = _0023_003DzNM31MVCgV2f_(activeLights[k].YieldShadow);
			}
			_ = array2[0];
			gl.Uniform1iv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607919)), _0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D(), array2);
			gl.Uniform1i(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607933)), 3);
			SetParametersForShadow(shaderParameters);
			double[] splitPositions = shaderParameters.RenderContext.frustumData.SplitPositions;
			gl.Uniform4f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607949)), (float)(0.0 - splitPositions[0]), (float)(0.0 - splitPositions[1]), (float)(0.0 - splitPositions[2]), (float)(0.0 - splitPositions[3]));
			gl.Uniform2fv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607963)), 1, shaderParameters.ShadowTextureScale);
			float[] value = new float[4] { 0f, 0.5f, 0.5f, 0f };
			float[] value2 = new float[4] { 0f, 0f, 0.5f, 0.5f };
			gl.Uniform4fv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607970)), 1, value);
			gl.Uniform4fv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607748)), 1, value2);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607782)), shaderParameters.ShadowAmbientFactor);
		}
	}

	internal void _0023_003DzNRz1hLEBqYKA(bool[] _0023_003DzSSU_OrNwA8uS, ShaderParameters.ClipPlane[] _0023_003DzpFLDdDs7TwqB)
	{
		int[] array = new int[6];
		for (int i = 0; i < 6; i++)
		{
			if (_0023_003DzSSU_OrNwA8uS[i])
			{
				gl.Uniform4fv(_0023_003DzAAIO0RYsMi61()[i], 1, _0023_003DzpFLDdDs7TwqB[i].Params);
				array[i] = 1;
			}
		}
		gl.Uniform1iv(_0023_003Dz5PQeurLix3OU94rXfA_003D_003D()[0], 6, array);
	}

	public override void SetParametersForShadow(object _0023_003DzgcK4Z11iT1YA)
	{
		if (!_0023_003Dzi0CGkDUPRSrg())
		{
			return;
		}
		ShaderParameters shaderParameters = (ShaderParameters)_0023_003DzgcK4Z11iT1YA;
		float[] array = new float[shaderParameters.NumberOfSplits * 16];
		int num = 0;
		int[] array2 = new int[8];
		float[] array3 = new float[2];
		if (shaderParameters.LightWithShadow >= 0)
		{
			array2[shaderParameters.LightWithShadow] = 1;
			for (int i = 0; i < shaderParameters.NumberOfSplits; i++)
			{
				float[] array4 = shaderParameters.ShadowMapData.textureMatrix[i];
				if (array4 != null)
				{
					for (int j = 0; j < 16; j++)
					{
						array[num++] = array4[j];
					}
				}
				else
				{
					num += 16;
				}
			}
			gl.UniformMatrix4fvARB(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607820)), shaderParameters.NumberOfSplits, transpose: false, array);
			array3[0] = (array3[1] = 0f);
		}
		gl.Uniform1iv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607875)), _0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D(), shaderParameters.LightsEnabled);
		gl.Uniform1iv(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607919)), _0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D(), array2);
		gl.Uniform1i(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607832)), shaderParameters.FirstPass ? 1 : 0);
	}

	private int _0023_003Dz3tVhSIk6FhBCKtkRYw_003D_003D()
	{
		if (!_0023_003DzwmBqrnNnsqlQ.HasValue)
		{
			_0023_003DzwmBqrnNnsqlQ = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607848));
		}
		return _0023_003DzwmBqrnNnsqlQ.Value;
	}

	private int _0023_003Dzgq26HCPaOKjX()
	{
		if (!_0023_003DzYpybKChhbmJt.HasValue)
		{
			_0023_003DzYpybKChhbmJt = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610407));
		}
		return _0023_003DzYpybKChhbmJt.Value;
	}

	private int _0023_003DzjukP20LeG3PR3PVXFAfYthQ_003D()
	{
		if (!_0023_003Dzc6p7oMkotQHSAiflykXqPSE_003D.HasValue)
		{
			_0023_003Dzc6p7oMkotQHSAiflykXqPSE_003D = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613260));
		}
		return _0023_003Dzc6p7oMkotQHSAiflykXqPSE_003D.Value;
	}

	private int _0023_003DzPdayYnrrWBrXDHbUdSf52XY_003D()
	{
		if (!_0023_003Dz9AceIrCKk0weXjNzhK8cUoM_003D.HasValue)
		{
			_0023_003Dz9AceIrCKk0weXjNzhK8cUoM_003D = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608894));
		}
		return _0023_003Dz9AceIrCKk0weXjNzhK8cUoM_003D.Value;
	}

	private int[] _0023_003DzAAIO0RYsMi61()
	{
		if (_0023_003DzBquORJ_LmQ_U == null)
		{
			_0023_003DzBquORJ_LmQ_U = new int[6];
			for (int i = 0; i < _0023_003DzBquORJ_LmQ_U.Length; i++)
			{
				_0023_003DzBquORJ_LmQ_U[i] = GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613277), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613294), i));
			}
		}
		return _0023_003DzBquORJ_LmQ_U;
	}

	private int[] _0023_003Dz5PQeurLix3OU94rXfA_003D_003D()
	{
		if (_0023_003DzySe0kclP2h1Af1Fb4w_003D_003D == null)
		{
			_0023_003DzySe0kclP2h1Af1Fb4w_003D_003D = new int[6];
			for (int i = 0; i < _0023_003DzySe0kclP2h1Af1Fb4w_003D_003D.Length; i++)
			{
				_0023_003DzySe0kclP2h1Af1Fb4w_003D_003D[i] = GetUniformLocation(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613277), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613309), i));
			}
		}
		return _0023_003DzySe0kclP2h1Af1Fb4w_003D_003D;
	}

	private int _0023_003Dzd9rI48ZNs98yXv_00247uXSxGSw_003D()
	{
		if (!_0023_003DzXT5d7uC7bVvy5CoipvU2kRU_003D.HasValue)
		{
			_0023_003DzXT5d7uC7bVvy5CoipvU2kRU_003D = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613317));
		}
		return _0023_003DzXT5d7uC7bVvy5CoipvU2kRU_003D.Value;
	}

	private void _0023_003DqQ_6_0024K2JlS0K8pzfP4mLwKGuemiYalOxcJ0Vax3kIz5TFe2TWptKapstK7ebHrS9x(string _0023_003Dz1_0024aH1_0024NSeZ_q5nTwzg_003D_003D, _0023_003DzCC58QB8A70FjfpZEXrOZ0Bw_003D _0023_003DzC_BuJOQ_003D)
	{
		int uniformLocation = GetUniformLocation(_0023_003Dz1_0024aH1_0024NSeZ_q5nTwzg_003D_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613333));
		if (uniformLocation != -1)
		{
			int uniformLocation2 = GetUniformLocation(_0023_003Dz1_0024aH1_0024NSeZ_q5nTwzg_003D_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613350));
			int uniformLocation3 = GetUniformLocation(_0023_003Dz1_0024aH1_0024NSeZ_q5nTwzg_003D_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613367));
			int uniformLocation4 = GetUniformLocation(_0023_003Dz1_0024aH1_0024NSeZ_q5nTwzg_003D_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613127));
			gl.Uniform4fv(uniformLocation, 1, _0023_003DzC_BuJOQ_003D._0023_003Dz0rG_3k0_003D._0023_003DzE1Ph3_00248_003D());
			gl.Uniform4fv(uniformLocation2, 1, _0023_003DzC_BuJOQ_003D._0023_003DzXN4q_0024zeq8iDq._0023_003DzE1Ph3_00248_003D());
			gl.Uniform4fv(uniformLocation3, 1, _0023_003DzC_BuJOQ_003D._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D._0023_003DzE1Ph3_00248_003D());
			gl.Uniform1f(uniformLocation4, _0023_003DzC_BuJOQ_003D.Shininess);
		}
	}
}
