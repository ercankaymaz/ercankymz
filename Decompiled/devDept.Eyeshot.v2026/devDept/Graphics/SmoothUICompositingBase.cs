using System.Drawing;
using devDept.Eyeshot;

namespace devDept.Graphics;

internal abstract class SmoothUICompositingBase : CompositingBase
{
	protected TextureBase _msTexColor;

	protected TextureBase _msTexDepth;

	protected TextureBase _resolveTex;

	protected static Color ClearColor => Color.Empty;

	protected override _0023_003DzYxAFqflazMmC AvailabilityMask => (_0023_003DzYxAFqflazMmC)1;

	protected override void FreeTargets()
	{
		_msTexColor?.Dispose();
		_msTexDepth?.Dispose();
		_resolveTex?.Dispose();
	}

	protected override void FreeShaders()
	{
	}

	protected internal abstract void Clear();

	protected abstract void ResolveMSTexture();

	internal override void DrawOnTopOfCurrentTarget(Rectangle viewportRect, ClippingPlaneBase[] clippingPlanes)
	{
		ResolveMSTexture();
		ParentRenderContext.PushBlendState();
		ParentRenderContext.SetState(blendStateType.Blend_SrcOne_DstOneMinusSrcAlpha);
		DrawQuadForPostProcessing(viewportRect, null, clippingPlanes, shaderType.Texture2DNoLights, null, _resolveTex);
		ParentRenderContext.PopBlendState();
	}

	protected internal virtual void SetMSTarget()
	{
		ParentRenderContext.EnableMultisample(enable: true);
	}

	protected internal override void ResetTarget()
	{
		base.ResetTarget();
		ParentRenderContext.EnableMultisample(enable: false);
	}
}
