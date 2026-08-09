using OpenGL;
using devDept.Graphics;

internal class _0023_003Dz3Sov7XZFjL_4ArNnVF7vee1sMh4_0024 : _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d
{
	public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
	{
		base.SetParameters(_0023_003DzgcK4Z11iT1YA);
		_0023_003DzOv21lrA_003D(this, _0023_003DzgcK4Z11iT1YA, programObj);
	}

	internal static void _0023_003DzOv21lrA_003D(GLShader _0023_003DzmwEGTTf7inME, object _0023_003DzgcK4Z11iT1YA, uint _0023_003DzpSvaDOA_003D)
	{
		gl.Uniform1i(GLShader.GetUniformLocation(_0023_003DzpSvaDOA_003D, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603340)), 1);
		_0023_003DzmwEGTTf7inME._0023_003DzzbfSoE7FWZwd8nNyL5G3f5U_003D();
		if (!((ShaderParameters)_0023_003DzgcK4Z11iT1YA).EnvironmentMapping)
		{
			_0023_003DzmwEGTTf7inME.SetEnvironmentIntensity(0f);
		}
	}

	public override void SetEnvironmentIntensity(float _0023_003Dz2WxCUwdbWLg9KRDBVw_003D_003D)
	{
		if (lastEnvironmentIntensity != _0023_003Dz2WxCUwdbWLg9KRDBVw_003D_003D)
		{
			lastEnvironmentIntensity = _0023_003Dz2WxCUwdbWLg9KRDBVw_003D_003D;
			gl.Uniform1f(_0023_003DzJmJcceb3Jx1zTAeXcu67ovk_003D, _0023_003Dz2WxCUwdbWLg9KRDBVw_003D_003D);
		}
	}
}
