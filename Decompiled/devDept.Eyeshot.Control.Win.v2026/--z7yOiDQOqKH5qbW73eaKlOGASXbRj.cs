using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using devDept.Eyeshot;
using devDept.Graphics;

internal sealed class _0023_003Dz7yOiDQOqKH5qbW73eaKlOGASXbRj : ShaderParameters, IDataPerFrame
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<ClipPlane, float[]> _0023_003Dz3OtnxrAZTXpYyEK4FA_003D_003D;

		internal float[] _0023_003Dzv3LYwi0XJGl4HFb7PKy1mdKghZfrr7FHwduj_0024yakfxZK(ClipPlane _0023_003Dz3gif_00241c_003D)
		{
			return _0023_003Dz3gif_00241c_003D.Params;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float[] _0023_003DzZ1uhwOsE4Q__QrmXPw_003D_003D;

	public _0023_003Dz7yOiDQOqKH5qbW73eaKlOGASXbRj(RenderContextBase _0023_003DzmNZD0Zs_003D)
		: base(_0023_003DzmNZD0Zs_003D)
	{
		OglRenderContext oglRenderContext = (OglRenderContext)_0023_003DzmNZD0Zs_003D;
		_0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg _0023_003DzNT32oUkqGeGp = oglRenderContext._0023_003DzNT32oUkqGeGp;
		AlphaClip = _0023_003DzNT32oUkqGeGp._0023_003Dzemb5TmiWZnwc != 0f;
		oglRenderContext._0023_003DzOtaDtEeirNP0(base.ClipPlanes, base.ClipPlanesEnabled);
		Lighting = oglRenderContext.CurrentShaderTechnique.Shader is ILightingShader lightingShader && lightingShader.Lighting;
		if (Lighting)
		{
			Lights = oglRenderContext._0023_003DzdEhV3KOWoijDidJl_0024w_003D_003D(LightsEnabled);
		}
		base.SceneAmbient = new float[4]
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON.X,
			_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON.Y,
			_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON.Z,
			_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON.W
		};
		UseColorForAmbientAndDiffuse = _0023_003DzNT32oUkqGeGp._0023_003Dz32GKgec08ez24iO1GoJN_0024Jo_003D;
		Backface = ((IWorkspaceInternal)oglRenderContext._0023_003Dzj88PH_0024h_Osj8()).Backface;
		ShadowTextureScale = _0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzRg5NBWQCHAcK.ToArray();
		ShadowAmbientFactor = _0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzDlelRQHE9I5t;
		if (_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1 != null)
		{
			for (int i = 0; i < _0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1.Length; i++)
			{
				if (_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[i]._0023_003DzBjT3PLCBXnbL > 0f)
				{
					LightWithShadow = i;
					break;
				}
			}
		}
		_0023_003DzPgFAGTGImbWs(new float[2]
		{
			_0023_003DzNT32oUkqGeGp._0023_003Dzqi43Drs_003D.Width,
			_0023_003DzNT32oUkqGeGp._0023_003Dzqi43Drs_003D.Height
		});
	}

	private ILightsData[] _0023_003DzAf4PrHPQ3w_0024BK22UxWmsdNbmykv_0024YQJGLKgkRs8_003D()
	{
		return Lights;
	}

	ILightsData[] IDataPerFrame.get_Lights()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zAf4PrHPQ3w$BK22UxWmsdNbmykv$YQJGLKgkRs8=
		return this._0023_003DzAf4PrHPQ3w_0024BK22UxWmsdNbmykv_0024YQJGLKgkRs8_003D();
	}

	private Size _0023_003Dzg4HOig7TaGJzoMZ9AAL05Ey0Tpmls2T09w_003D_003D()
	{
		return new Size((int)Math.Floor(_0023_003DzNc98jj13QguQ()[0]), (int)Math.Floor(_0023_003DzNc98jj13QguQ()[1]));
	}

	Size IDataPerFrame.get_ViewportSize()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zg4HOig7TaGJzoMZ9AAL05Ey0Tpmls2T09w==
		return this._0023_003Dzg4HOig7TaGJzoMZ9AAL05Ey0Tpmls2T09w_003D_003D();
	}

	private float[][] _0023_003DzSSgUDbnjtlIztqkCWWiPlDH74RE68Jck8g_003D_003D()
	{
		return base.ClipPlanes.Select((ClipPlane _0023_003Dz3gif_00241c_003D) => _0023_003Dz3gif_00241c_003D.Params).ToArray();
	}

	float[][] IDataPerFrame.get_ClipPlanes()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zSSgUDbnjtlIztqkCWWiPlDH74RE68Jck8g==
		return this._0023_003DzSSgUDbnjtlIztqkCWWiPlDH74RE68Jck8g_003D_003D();
	}

	public float[] _0023_003DzNc98jj13QguQ()
	{
		return _0023_003DzZ1uhwOsE4Q__QrmXPw_003D_003D;
	}

	private void _0023_003DzPgFAGTGImbWs(float[] _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzZ1uhwOsE4Q__QrmXPw_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private bool[] _0023_003DzAEahbDE8bnObBwfZ3YEshHFs_3zduJgzEMvXDW4_003D()
	{
		return base.ClipPlanesEnabled;
	}

	bool[] IDataPerFrame.get_ClipPlanesEnabled()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zAEahbDE8bnObBwfZ3YEshHFs_3zduJgzEMvXDW4=
		return this._0023_003DzAEahbDE8bnObBwfZ3YEshHFs_3zduJgzEMvXDW4_003D();
	}
}
