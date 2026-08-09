using OpenGL;
using devDept.Graphics;

internal sealed class _0023_003DzG3LYUDJIsjFLYNGH7338y9pgb1H5 : _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d
{
	public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
	{
		base.SetParameters(_0023_003DzgcK4Z11iT1YA);
		if (!_0023_003DzVN1nvI3DqMA2dnttRXyWjCqYCGK76SA33A_003D_003D())
		{
			_0023_003DzOv21lrA_003D(_0023_003DzgcK4Z11iT1YA, _0023_003Dz5QEgmA1bHJlJ(), _0023_003DzdgD2ty_bamaCCChq6bLWIT5ciZew(), programObj);
		}
		ShaderParameters shaderParameters = (ShaderParameters)_0023_003DzgcK4Z11iT1YA;
		gl.Uniform1i(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610536)), _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d._0023_003DzNM31MVCgV2f_(shaderParameters.AlphaClip));
	}

	internal static void _0023_003DzOv21lrA_003D(object _0023_003DzgcK4Z11iT1YA, bool _0023_003DzxAshdwOYgM5J, bool _0023_003Dzv9CdFsxyctAJc_stkFZJ6YI_003D, uint _0023_003DzpSvaDOA_003D)
	{
		if (_0023_003DzgcK4Z11iT1YA is _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2)
		{
			gl.Uniform1f(GLShader.GetUniformLocation(_0023_003DzpSvaDOA_003D, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612675)), _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzOnHva6wpqpFv);
			if (_0023_003Dzv9CdFsxyctAJc_stkFZJ6YI_003D)
			{
				gl.Uniform1i(GLShader.GetUniformLocation(_0023_003DzpSvaDOA_003D, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612719)), _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d._0023_003DzNM31MVCgV2f_(_0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2._0023_003DzHtNbVaLv1tw6oApvlY6grW0_003D));
			}
		}
		gl.Uniform1i(GLShader.GetUniformLocation(_0023_003DzpSvaDOA_003D, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612725)), 0);
		if (_0023_003DzxAshdwOYgM5J)
		{
			gl.Uniform1i(GLShader.GetUniformLocation(_0023_003DzpSvaDOA_003D, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612993)), 4);
		}
		if (_0023_003Dzv9CdFsxyctAJc_stkFZJ6YI_003D)
		{
			gl.Uniform1i(GLShader.GetUniformLocation(_0023_003DzpSvaDOA_003D, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612719)), _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d._0023_003DzNM31MVCgV2f_(((ShaderParameters)_0023_003DzgcK4Z11iT1YA).TextureOverExposure));
		}
	}
}
