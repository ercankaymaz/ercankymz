using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using OpenGL;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Graphics;

internal class _0023_003Dz93PBZvWYykCOmt_nOv8ZTYF9bvLS : _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected int _0023_003DzvS_0024Scn_0024i9guw;

	private void _0023_003DzGslS8Y8_003D(OglRenderContext _0023_003DzmNZD0Zs_003D, realisticShadowQualityType _0023_003DzM7ye9srZVEJJ, BackgroundSettings _0023_003DzRaVp1sk_003D, LightSettings[] _0023_003Dzz6Yr_8gP5Mz7k_0024N9hw_003D_003D)
	{
		Dispose();
		_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2 = (_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d)new _0023_003DzwHzEaqHhe_ahPJ_0024dpHIcDBdbVLpdhZ9RTQ_003D_003D(_0023_003DzmNZD0Zs_003D, _0023_003Dzd59lTZgxTYre: true, _0023_003Dzz6Yr_8gP5Mz7k_0024N9hw_003D_003D, _0023_003DzM7ye9srZVEJJ, _0023_003DzRaVp1sk_003D)._0023_003DzlcHI16E_003D(this);
		_0023_003Dz_0024Y7C9dH_IHo6(_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2);
		_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2.Dispose();
	}

	public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
	{
		if (_0023_003DzgcK4Z11iT1YA is _0023_003Dz7yOiDQOqKH5qbW73eaKlOGASXbRj || _0023_003DzgcK4Z11iT1YA is _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			return;
		}
		ReflectionShaderParameters reflectionShaderParameters = (ReflectionShaderParameters)_0023_003DzgcK4Z11iT1YA;
		int[] viewFrame = reflectionShaderParameters.ViewFrame;
		BackgroundSettings backgroundSettings = (BackgroundSettings)reflectionShaderParameters.Background;
		if (_0023_003DzEZgLHYAPuuUJ() != backgroundSettings.StyleMode)
		{
			_0023_003DzGslS8Y8_003D((OglRenderContext)reflectionShaderParameters.RenderContext, reflectionShaderParameters.ShadowQuality, backgroundSettings, reflectionShaderParameters.RenderContext.ActiveLights);
			Compile(reflectionShaderParameters.RenderContext);
		}
		base.SetParameters((object)reflectionShaderParameters);
		reflectionShaderParameters.Background.SetTexture(reflectionShaderParameters.RenderContext, TextureBase.textureUnitType.Background);
		Color color = RenderContextUtility.ConvertColor(backgroundSettings.BottomColor);
		float[] array = new float[4]
		{
			(float)(int)color.R / 255f,
			(float)(int)color.G / 255f,
			(float)(int)color.B / 255f,
			(float)(int)color.A / 255f
		};
		color = RenderContextUtility.ConvertColor(backgroundSettings.TopColor);
		float[] array2 = new float[4]
		{
			(float)(int)color.R / 255f,
			(float)(int)color.G / 255f,
			(float)(int)color.B / 255f,
			(float)(int)color.A / 255f
		};
		switch (backgroundSettings.StyleMode)
		{
		case backgroundStyleType.None:
			color = reflectionShaderParameters.ParentBackColor;
			gl.Uniform4f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613142)), (float)(int)color.R / 255f, (float)(int)color.G / 255f, (float)(int)color.B / 255f, (float)(int)color.A / 255f);
			break;
		case backgroundStyleType.Solid:
			gl.Uniform4f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613142)), array2[0], array2[1], array2[2], array2[3]);
			break;
		case backgroundStyleType.LinearGradient:
			gl.Uniform4f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613159)), array[0], array[1], array[2], array[3]);
			gl.Uniform4f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613142)), array2[0], array2[1], array2[2], array2[3]);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613173)), (float)viewFrame[3] * reflectionShaderParameters.DrawScale);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613184)), viewFrame[1]);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613205)), reflectionShaderParameters.ZoomRect.Y / (float)viewFrame[3]);
			break;
		case backgroundStyleType.CubicGradient:
			gl.Uniform1i(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613247)), 2);
			_0023_003DzvS_0024Scn_0024i9guw = 3553;
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613173)), (float)viewFrame[3] * reflectionShaderParameters.DrawScale);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613184)), viewFrame[1]);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613205)), reflectionShaderParameters.ZoomRect.Y / (float)viewFrame[3]);
			break;
		case backgroundStyleType.Image:
		{
			gl.Uniform1i(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613247)), 2);
			_0023_003DzvS_0024Scn_0024i9guw = 3553;
			float bmpWidth;
			float bmpHeight;
			float imageScale = backgroundSettings.GetImageScale(viewFrame[2], viewFrame[3], out bmpWidth, out bmpHeight);
			float x = (float)viewFrame[2] / (bmpWidth * imageScale);
			float x2 = (float)viewFrame[3] / (bmpHeight * imageScale);
			float x3 = reflectionShaderParameters.ZoomRect.X / (float)viewFrame[2];
			float x4 = reflectionShaderParameters.ZoomRect.Y / (float)viewFrame[3];
			float x5 = viewFrame[0];
			float x6 = viewFrame[1];
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613509)), x);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613543)), x2);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613577)), viewFrame[2]);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613173)), viewFrame[3]);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613589)), x5);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613184)), x6);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613610)), x3);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613205)), x4);
			gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613620)), reflectionShaderParameters.DrawScale);
			break;
		}
		default:
			_0023_003DzvS_0024Scn_0024i9guw = 0;
			break;
		}
		gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613384)), reflectionShaderParameters.ReflectionIntensity);
		float x7 = (float)(0.0 - reflectionShaderParameters.ReflectionPlane.Equation.D);
		gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613422)), reflectionShaderParameters.ReflectionMaxHeight * 0.8f);
		gl.Uniform1f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613431)), x7);
		gl.Uniform4f(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613443)), (float)reflectionShaderParameters.ReflectionPlaneNormal.X, (float)reflectionShaderParameters.ReflectionPlaneNormal.Y, (float)reflectionShaderParameters.ReflectionPlaneNormal.Z, 0f);
	}

	public override void SetParametersForShadow(object _0023_003DzgcK4Z11iT1YA)
	{
		if (_0023_003Dzi0CGkDUPRSrg())
		{
			base.SetParametersForShadow(_0023_003DzgcK4Z11iT1YA);
			ShaderParameters shaderParameters = (ShaderParameters)_0023_003DzgcK4Z11iT1YA;
			gl.Uniform1i(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613457)), shaderParameters.NumberOfPasses);
		}
	}

	public override bool Enable(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (!base.Enable(_0023_003DzmNZD0Zs_003D))
		{
			return false;
		}
		_0023_003DzmNZD0Zs_003D.SetActiveTexture(TextureBase.textureUnitType.Background);
		_0023_003DzmNZD0Zs_003D.SetActiveTexture(TextureBase.textureUnitType.Base);
		return true;
	}

	[SpecialName]
	internal override bool _0023_003DzT5lT1YFdRDAvUzE2Bg_003D_003D()
	{
		return true;
	}

	public override string ToString()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606275) + base.ToString();
	}
}
