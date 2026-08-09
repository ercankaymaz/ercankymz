using devDept.Geometry;

namespace devDept.Graphics;

public class AoShaderParameters : PostProcessingShaderParameters
{
	public float[] Projection;

	public float[] ProjectionInv;

	public Vector2D UnprojectMult;

	public Vector2D UnprojectAdd;

	public Vector2D NearFar;

	public Vector2D DepthRange;

	public float Radius;

	public int FilterRadius;

	public float FilterSmoothness;

	public float FilterFactor;

	public AoShaderParameters(RenderContextBase renderContext, int[] viewFrame, float[] projection, float[] projectionInv, Vector2D unprojectMult, Vector2D unprojectAdd, Vector2D nearFar, Vector2D depthRange, float radius, int filterRadius, float filterSmoothness, float filterFactor)
		: base(renderContext, viewFrame)
	{
		Projection = projection;
		ProjectionInv = projectionInv;
		UnprojectMult = unprojectMult;
		UnprojectAdd = unprojectAdd;
		NearFar = nearFar;
		DepthRange = depthRange;
		Radius = radius;
		FilterRadius = filterRadius;
		FilterSmoothness = filterSmoothness;
		FilterFactor = filterFactor;
	}
}
