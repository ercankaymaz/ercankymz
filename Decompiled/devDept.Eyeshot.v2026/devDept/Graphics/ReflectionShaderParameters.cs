using System.Drawing;
using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Graphics;

public class ReflectionShaderParameters : ShaderParameters
{
	public Color ParentBackColor;

	public float ReflectionIntensity;

	public Plane ReflectionPlane;

	public float ReflectionMaxHeight;

	public Vector3D ReflectionPlaneNormal => ReflectionPlane.AxisZ;

	public ReflectionShaderParameters(RenderContextBase renderContext)
		: base(renderContext)
	{
	}

	public ReflectionShaderParameters(RenderContextBase renderContext, int[] viewFrame, Camera camera, shadowType shadowMode, realisticShadowQualityType shadowQuality, IBackgroundSettings background, BackfaceSettings backface, bool environmentMapping, float drawScale, RectangleF zoomRect, Color parentBackColor, float reflectionIntensity, Plane reflectionPlane, float reflectionMaxHeight, Transformation initialSceneTransformation)
		: base(renderContext, viewFrame, camera, shadowMode, shadowQuality, background, backface, environmentMapping, drawScale, zoomRect, initialSceneTransformation)
	{
		ParentBackColor = parentBackColor;
		ReflectionIntensity = reflectionIntensity;
		ReflectionPlane = reflectionPlane;
		ReflectionMaxHeight = reflectionMaxHeight;
	}
}
