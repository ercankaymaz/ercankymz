using devDept.Geometry;

namespace devDept.Graphics;

public class SilhoShaderParameters : PostProcessingShaderParameters
{
	public float[] Projection;

	public Vector2D NearFar;

	public Vector2D DepthRange;

	public SilhoShaderParameters(RenderContextBase renderContext, int[] viewFrame, float[] projection, Vector2D nearFar, Vector2D depthRange)
		: base(renderContext, viewFrame)
	{
		Projection = projection;
		NearFar = nearFar;
		DepthRange = depthRange;
	}
}
