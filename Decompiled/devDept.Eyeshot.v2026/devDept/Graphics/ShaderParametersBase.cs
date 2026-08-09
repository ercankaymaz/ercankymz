namespace devDept.Graphics;

public abstract class ShaderParametersBase
{
	public RenderContextBase RenderContext;

	public ShaderParametersBase(RenderContextBase renderContext)
	{
		RenderContext = renderContext;
	}
}
