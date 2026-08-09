using System.Drawing;
using devDept.Eyeshot;

namespace devDept.Graphics;

internal abstract class HaloSelectionCompositingBase : CompositingBase
{
	protected Color HaloInnerColor;

	protected Color HaloOuterColor;

	protected Color FillColorFront;

	protected Color FillColorBack;

	protected int HaloWidthPolygons;

	protected int HaloWidthWires;

	protected IShaderTechnique Shader;

	protected TextureBase _texColor;

	protected TextureBase _texDepth;

	protected static Color ClearColor => Color.Empty;

	protected override _0023_003DzYxAFqflazMmC AvailabilityMask => (_0023_003DzYxAFqflazMmC)2;

	protected override void FreeTargets()
	{
		_texColor?.Dispose();
		_texDepth?.Dispose();
		_texDepth = null;
		_texColor = null;
	}

	protected override void FreeShaders()
	{
		if (ParentRenderContext.Shaders != null && ParentRenderContext.Shaders.ContainsKey(shaderType.Outline))
		{
			ParentRenderContext.Shaders.Remove(shaderType.Outline);
		}
		Shader?.Dispose();
	}

	internal virtual void Clear(Rectangle rect, ClippingPlaneBase[] clippingPlanes)
	{
		SetTarget();
		DrawQuadForClear(rect, clippingPlanes);
		ResetTarget();
	}

	protected abstract void ClearForInit();

	protected override bool InitTargets(Size newSize)
	{
		ClearForInit();
		return true;
	}

	internal override void DrawOnTopOfCurrentTarget(Rectangle viewportRect, ClippingPlaneBase[] clippingPlanes)
	{
		ParentRenderContext.PushBlendState();
		ParentRenderContext.SetState(blendStateType.Blend);
		DrawQuadForPostProcessing(viewportRect, null, clippingPlanes, shaderType.Outline, null, _texColor);
		ParentRenderContext.PopBlendState();
	}

	protected internal abstract void SetTarget();

	protected internal virtual void Update(Color haloInnerColor, Color haloOuterColor, Color fillColorFront, Color fillColorBack, int haloWidthPolygons, int haloWidthWires)
	{
		HaloInnerColor = haloInnerColor;
		HaloOuterColor = haloOuterColor;
		FillColorFront = fillColorFront;
		FillColorBack = fillColorBack;
		HaloWidthPolygons = haloWidthPolygons;
		HaloWidthWires = haloWidthWires;
		Shader.UpdatedInFrame = false;
	}
}
