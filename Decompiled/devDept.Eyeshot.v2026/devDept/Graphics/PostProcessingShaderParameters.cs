namespace devDept.Graphics;

public abstract class PostProcessingShaderParameters : ShaderParametersBase
{
	public int[] ViewFrame;

	protected PostProcessingShaderParameters(RenderContextBase renderContext, int[] viewFrame)
		: base(renderContext)
	{
		ViewFrame = viewFrame;
	}
}
