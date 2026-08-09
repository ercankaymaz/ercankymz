using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using SharpDX.Direct3D11;

namespace devDept.Graphics;

public abstract class D3DTextureBase : Texture, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CLSCompliant(false)]
	internal Resource _0023_003Dz_IfKSJY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CLSCompliant(false)]
	internal ShaderResourceView _0023_003DzV_0024hxxsU_0024ZCJW;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dzxc5GrhYq3y_0024E;

	protected D3DTextureBase()
	{
	}

	protected D3DTextureBase(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override void FreeResources()
	{
		if (_0023_003Dz_IfKSJY_003D != null)
		{
			_0023_003Dz_IfKSJY_003D.Dispose();
			_0023_003Dz_IfKSJY_003D = null;
		}
		if (_0023_003DzV_0024hxxsU_0024ZCJW != null)
		{
			_0023_003DzV_0024hxxsU_0024ZCJW.Dispose();
			_0023_003DzV_0024hxxsU_0024ZCJW = null;
		}
	}

	protected override void EnableTexture(RenderContextBase renderContext, textureUnitType textureUnit)
	{
		base.EnableTexture(renderContext, textureUnit);
		D3DRenderContext d3DRenderContext = (D3DRenderContext)renderContext;
		d3DRenderContext._0023_003DzP7fhLh8_003D.PixelShader.SetSampler((int)textureUnit, d3DRenderContext._0023_003DzCs9juxBz5x1N[_0023_003Dzxc5GrhYq3y_0024E]);
		d3DRenderContext._0023_003DzP7fhLh8_003D.PixelShader.SetShaderResource((int)textureUnit, _0023_003DzV_0024hxxsU_0024ZCJW);
	}

	public override bool IsValid()
	{
		return _0023_003DzV_0024hxxsU_0024ZCJW != null;
	}
}
