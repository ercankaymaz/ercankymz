using System;
using System.Drawing;
using System.Drawing.Imaging;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using devDept.Geometry;
using devDept.Graphics;

internal sealed class _0023_003Dz0F0alDAPpvjxD7vGCF6uwpvHPCis : D3DTexture
{
	public _0023_003Dz0F0alDAPpvjxD7vGCF6uwpvHPCis(System.Drawing.Color[] _0023_003DzXSIcYos_003D)
	{
		base.Bitmap = Texture.BitmapFromColors(_0023_003DzXSIcYos_003D);
	}

	public _0023_003Dz0F0alDAPpvjxD7vGCF6uwpvHPCis(RenderContextBase _0023_003DzoC62DbA_003D, System.Drawing.Color[] _0023_003DzXSIcYos_003D, textureFilteringFunctionType _0023_003Dzjf2lB30tMq_Q = textureFilteringFunctionType.LinearMipmapLinear, textureFilteringFunctionType _0023_003DzMkJ4lhG0mqmw = textureFilteringFunctionType.LinearMipmapLinear, bool _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D = true)
		: this(_0023_003DzXSIcYos_003D)
	{
	}

	public override void Load(RenderContextBase _0023_003DzmNZD0Zs_003D, byte[] _0023_003DzmPRo6QY_003D, textureFilteringFunctionType _0023_003Dzjf2lB30tMq_Q, textureFilteringFunctionType _0023_003DzMkJ4lhG0mqmw = textureFilteringFunctionType.Linear, bool _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D = true, bool _0023_003DzDXSkCVA_003D = true, bool _0023_003DzLYY7OMQ_003D = true, bool _0023_003DzorHz8sxwhiTJ = true, bool _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D = false)
	{
		if (_0023_003DzmPRo6QY_003D == null)
		{
			return;
		}
		base.Bitmap = _0023_003DzmPRo6QY_003D;
		using Bitmap _0023_003DzmPRo6QY_003D2 = UtilityEx.ConvertBytesToImage(_0023_003DzmPRo6QY_003D);
		_0023_003DzSpXm1l_Bq4NB(_0023_003DzmNZD0Zs_003D, _0023_003DzmPRo6QY_003D2, _0023_003Dzjf2lB30tMq_Q, _0023_003DzMkJ4lhG0mqmw, _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D, _0023_003DzDXSkCVA_003D, _0023_003DzLYY7OMQ_003D);
	}

	public override void Load(RenderContextBase _0023_003DzmNZD0Zs_003D, IDisposable[] _0023_003DzmPRo6QY_003D, textureFilteringFunctionType _0023_003Dzjf2lB30tMq_Q, textureFilteringFunctionType _0023_003DzMkJ4lhG0mqmw = textureFilteringFunctionType.Linear, bool _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D = true, bool _0023_003DzDXSkCVA_003D = true, bool _0023_003DzLYY7OMQ_003D = true, bool _0023_003DzorHz8sxwhiTJ = true, bool _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D = false)
	{
		throw new NotImplementedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602902));
	}

	public override void Load(RenderContextBase _0023_003DzmNZD0Zs_003D, Bitmap _0023_003DzmPRo6QY_003D, textureFilteringFunctionType _0023_003Dzjf2lB30tMq_Q, textureFilteringFunctionType _0023_003DzMkJ4lhG0mqmw = textureFilteringFunctionType.Linear, bool _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D = true, bool _0023_003DzDXSkCVA_003D = true, bool _0023_003DzLYY7OMQ_003D = true, bool _0023_003DzorHz8sxwhiTJ = true, bool _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D = false)
	{
		if (_0023_003DzmPRo6QY_003D != null)
		{
			base.Bitmap = UtilityEx.ConvertImageToBytes(_0023_003DzmPRo6QY_003D);
			_0023_003DzSpXm1l_Bq4NB(_0023_003DzmNZD0Zs_003D, _0023_003DzmPRo6QY_003D, _0023_003Dzjf2lB30tMq_Q, _0023_003DzMkJ4lhG0mqmw, _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D, _0023_003DzDXSkCVA_003D, _0023_003DzLYY7OMQ_003D);
		}
	}

	private void _0023_003DzSpXm1l_Bq4NB(RenderContextBase _0023_003DzmNZD0Zs_003D, Bitmap _0023_003DzmPRo6QY_003D, textureFilteringFunctionType _0023_003Dzjf2lB30tMq_Q, textureFilteringFunctionType _0023_003DzMkJ4lhG0mqmw, bool _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D, bool _0023_003DzDXSkCVA_003D, bool _0023_003DzLYY7OMQ_003D)
	{
		base.FirstPixelColor = System.Drawing.Color.FromArgb(255, _0023_003DzmPRo6QY_003D.GetPixel(0, 0));
		D3DRenderContext d3DRenderContext = (D3DRenderContext)_0023_003DzmNZD0Zs_003D;
		SharpDX.Direct3D11.Device _0023_003DzTzFVZ_00240_003D = d3DRenderContext._0023_003DzTzFVZ_00240_003D;
		if (_0023_003Dz_IfKSJY_003D != null)
		{
			FreeResources();
			if (_0023_003DzmNZD0Zs_003D is D3DRenderContextWF && _0023_003DzmNZD0Zs_003D.IsControlMinimized)
			{
				_0023_003DzTzFVZ_00240_003D.ImmediateContext.Flush();
			}
		}
		BitmapData bitmapData = _0023_003DzmPRo6QY_003D.LockBits(new System.Drawing.Rectangle(0, 0, _0023_003DzmPRo6QY_003D.Width, _0023_003DzmPRo6QY_003D.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		CheckTextureSize(d3DRenderContext, new Size(bitmapData.Width, 1));
		_0023_003Dz_IfKSJY_003D = new Texture1D(_0023_003DzTzFVZ_00240_003D, new Texture1DDescription
		{
			Width = bitmapData.Width,
			ArraySize = 1,
			BindFlags = BindFlags.ShaderResource,
			Format = Format.B8G8R8A8_UNorm,
			MipLevels = 1
		}, new DataBox[1]
		{
			new DataBox(bitmapData.Scan0, bitmapData.Stride, 0)
		});
		_0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(_0023_003DzTzFVZ_00240_003D, _0023_003Dz_IfKSJY_003D);
		_0023_003DzmPRo6QY_003D.UnlockBits(bitmapData);
		Filter filter = D3DTexture._0023_003DzBum_5fBFid7F(_0023_003Dzjf2lB30tMq_Q, _0023_003DzMkJ4lhG0mqmw);
		if (_0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D && filter != Filter.MinMagMipPoint)
		{
			filter = Filter.Anisotropic;
		}
		_0023_003Dzxc5GrhYq3y_0024E = d3DRenderContext._0023_003DzKjAPrkH_0024OGSs(filter, _0023_003DzDXSkCVA_003D, _0023_003DzLYY7OMQ_003D, _0023_003DzTzFVZ_00240_003D, 16f);
	}

	public override void AllocateMemory(RenderContextBase _0023_003DzoC62DbA_003D, bool _0023_003DzMYTzTqg_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, textureFilteringFunctionType _0023_003DzM8_0024IAmCyT0tt, textureFilteringFunctionType _0023_003DzfM8e85npVBIi, bool _0023_003DzMOUqauw_003D, bool _0023_003Dz07HQcxg_003D, IntPtr _0023_003DzTpOjvFMsZxgg, bool _0023_003DzPDCTi2_0024M0Kh5lwINuw_003D_003D)
	{
		throw new NotImplementedException();
	}
}
