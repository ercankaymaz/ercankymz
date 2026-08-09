namespace devDept.Graphics;

public class BlurShaderParameters : ShaderParametersBase
{
	public float[] offset;

	public float[] kerValue;

	public BlurShaderParameters(RenderContextBase renderContext, float[] offset, float[] kerValue)
		: base(renderContext)
	{
		this.offset = offset;
		this.kerValue = kerValue;
	}
}
