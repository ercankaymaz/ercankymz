using OpenGL;

internal class _0023_003Dz8c48L3io97hgbcOGqF4_gs7G62mn : _0023_003Dz93PBZvWYykCOmt_nOv8ZTYF9bvLS
{
	public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
	{
		base.SetParameters(_0023_003DzgcK4Z11iT1YA);
		_0023_003Dz3Sov7XZFjL_4ArNnVF7vee1sMh4_0024._0023_003DzOv21lrA_003D(this, _0023_003DzgcK4Z11iT1YA, programObj);
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
