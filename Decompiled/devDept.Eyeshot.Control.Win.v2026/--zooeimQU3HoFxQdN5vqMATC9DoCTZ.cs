using System.Drawing;
using devDept.Eyeshot;
using devDept.Graphics;

internal sealed class _0023_003DzooeimQU3HoFxQdN5vqMATC9DoCTZ : ShadowMapData
{
	protected override double[] biasMatrix => new double[16]
	{
		0.5, 0.0, 0.0, 0.0, 0.0, -0.5, 0.0, 0.0, 0.0, 0.0,
		1.0, 0.0, 0.5, 0.5, 0.0, 1.0
	};

	protected internal override bool EnableFBO(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		((D3DRenderContext)_0023_003DzoC62DbA_003D)._0023_003DzElzSDDQsrPlQ();
		return true;
	}

	public override void Disable(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003DzmNZD0Zs_003D.CloseTexture(TextureBase.textureUnitType.ShadowMap);
	}

	protected internal override void SetDepthFBO(RenderContextBase _0023_003DzoC62DbA_003D, TextureBase _0023_003Dz_IfKSJY_003D)
	{
		((D3DRenderContext)_0023_003DzoC62DbA_003D)._0023_003DzaQ3b8dxHyWP6(null, _0023_003Dz_IfKSJY_003D);
	}

	protected internal override void Create(GfxShadowParams _0023_003Dz9I9gxp1ufyw2, int _0023_003Dz62_cyiA_003D, uint _0023_003Dz8GBMuoM_003D, uint _0023_003DzJU0R6e0_003D, FrustumData _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D, ClippingPlaneBase[] _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, DrawForShadowMapDelegate _0023_003Dz_0024INnEyvAOHmJY0dT_0024Q_003D_003D, object _0023_003DzB1cOiZO7bPjY)
	{
		Size controlSize = _0023_003Dz9I9gxp1ufyw2.renderContext.ControlData.ControlSize;
		_0023_003Dz9I9gxp1ufyw2.renderContext.ControlData.ControlSize = base.Size;
		base.Create(_0023_003Dz9I9gxp1ufyw2, _0023_003Dz62_cyiA_003D, _0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D, _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003Dz_0024INnEyvAOHmJY0dT_0024Q_003D_003D, _0023_003DzB1cOiZO7bPjY);
		_0023_003Dz9I9gxp1ufyw2.renderContext.ControlData.ControlSize = controlSize;
	}
}
