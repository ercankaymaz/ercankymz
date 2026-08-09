using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using devDept.Geometry;

namespace devDept.Graphics;

[Serializable]
public class D3DTexture2D : D3DTexture
{
	public D3DTexture2D()
	{
	}

	public D3DTexture2D(RenderContextBase renderContext, Bitmap bmp)
		: this(renderContext, bmp, textureFilteringFunctionType.Nearest, anisotropicFiltering: true)
	{
	}

	public D3DTexture2D(RenderContextBase renderContext, Bitmap bmp, textureFilteringFunctionType minFunc, bool anisotropicFiltering)
	{
		_0023_003DzSpXm1l_Bq4NB(renderContext, bmp, bmp.Size, D3DTexture._0023_003DzBum_5fBFid7F(minFunc, textureFilteringFunctionType.Linear), anisotropicFiltering, _0023_003DzDXSkCVA_003D: true, _0023_003DzLYY7OMQ_003D: true, _0023_003DzorHz8sxwhiTJ: true, _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D: false);
	}

	public D3DTexture2D(RenderContextBase renderContext, Bitmap bmp, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc, bool anisotropicFiltering, bool repeatX = true, bool repeatY = true)
	{
		_0023_003DzSpXm1l_Bq4NB(renderContext, bmp, bmp.Size, D3DTexture._0023_003DzBum_5fBFid7F(minFunc, magFunc), anisotropicFiltering, repeatX, repeatY, _0023_003DzorHz8sxwhiTJ: true, _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D: false);
	}

	public D3DTexture2D(D3DRenderContext renderContext, System.Drawing.Color[] colorTable)
	{
		base.Bitmap = Texture.BitmapFromColors(colorTable);
	}

	protected D3DTexture2D(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public override void Load(RenderContextBase renderContext, byte[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		if (bitmap == null)
		{
			return;
		}
		using Bitmap bitmap2 = UtilityEx.ConvertBytesToImage(bitmap);
		_0023_003DzSpXm1l_Bq4NB(renderContext, bitmap2, bitmap2.Size, D3DTexture._0023_003DzBum_5fBFid7F(minFunc, magFunc), anisotropicFiltering, repeatX, repeatY, checkPowerOfTwo, enlargeIfSizeNotSupported);
	}

	public override void Load(RenderContextBase renderContext, IDisposable[] bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		throw new NotImplementedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602902));
	}

	public override void Load(RenderContextBase renderContext, Bitmap bitmap, textureFilteringFunctionType minFunc, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true, bool repeatY = true, bool checkPowerOfTwo = true, bool enlargeIfSizeNotSupported = false)
	{
		if (bitmap != null)
		{
			_0023_003DzSpXm1l_Bq4NB(renderContext, bitmap, bitmap.Size, D3DTexture._0023_003DzBum_5fBFid7F(minFunc, magFunc), anisotropicFiltering, repeatX, repeatY, checkPowerOfTwo, enlargeIfSizeNotSupported);
		}
	}

	internal void _0023_003Dzcp4fLOSZApya(RenderContextBase _0023_003DzmNZD0Zs_003D, Size _0023_003Dz0ERMHbg_003D, CpuAccessFlags _0023_003DzVvA36XjMLfAJ, ResourceUsage _0023_003DzSt_0024Fe38_003D, Format _0023_003DzyTdq_VY_003D, BindFlags _0023_003DzjM9ecwk_003D, SampleDescription _0023_003DzCEGI0ngjOjCn)
	{
		D3DRenderContext d3DRenderContext = (D3DRenderContext)_0023_003DzmNZD0Zs_003D;
		SharpDX.Direct3D11.Device _0023_003DzTzFVZ_00240_003D = d3DRenderContext._0023_003DzTzFVZ_00240_003D;
		CheckTextureSize(d3DRenderContext, new Size(_0023_003Dz0ERMHbg_003D.Width, _0023_003Dz0ERMHbg_003D.Height));
		_0023_003Dz_IfKSJY_003D = new Texture2D(_0023_003DzTzFVZ_00240_003D, new Texture2DDescription
		{
			Width = _0023_003Dz0ERMHbg_003D.Width,
			Height = _0023_003Dz0ERMHbg_003D.Height,
			ArraySize = 1,
			MipLevels = 1,
			Format = _0023_003DzyTdq_VY_003D,
			Usage = _0023_003DzSt_0024Fe38_003D,
			OptionFlags = ResourceOptionFlags.None,
			CpuAccessFlags = _0023_003DzVvA36XjMLfAJ,
			SampleDescription = _0023_003DzCEGI0ngjOjCn,
			BindFlags = _0023_003DzjM9ecwk_003D
		});
		base.Size = _0023_003Dz0ERMHbg_003D;
	}

	private void _0023_003DzSpXm1l_Bq4NB(RenderContextBase _0023_003DzmNZD0Zs_003D, Bitmap _0023_003Dza0pUM94_003D, Size _0023_003Dz0ERMHbg_003D, Filter _0023_003DzyEJxcb2yCP94, bool _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D, bool _0023_003DzDXSkCVA_003D, bool _0023_003DzLYY7OMQ_003D, bool _0023_003DzorHz8sxwhiTJ, bool _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D)
	{
		base.FirstPixelColor = System.Drawing.Color.FromArgb(255, _0023_003Dza0pUM94_003D.GetPixel(0, 0));
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
		base.BitmapSize = _0023_003Dza0pUM94_003D.Size;
		BitmapData bitmapData = _0023_003Dza0pUM94_003D.LockBits(new System.Drawing.Rectangle(0, 0, _0023_003Dza0pUM94_003D.Width, _0023_003Dza0pUM94_003D.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		int num = 1;
		BindFlags bindFlags = BindFlags.ShaderResource;
		ResourceOptionFlags resourceOptionFlags = ResourceOptionFlags.None;
		ResourceUsage usage = ResourceUsage.Default;
		DataBox[] data = null;
		MipMapping = false;
		switch (_0023_003DzyEJxcb2yCP94)
		{
		case Filter.MinMagPointMipLinear:
		case Filter.MinPointMagMipLinear:
		case Filter.MinLinearMagPointMipLinear:
		case Filter.MinMagMipLinear:
			num = 0;
			bindFlags |= BindFlags.RenderTarget;
			resourceOptionFlags |= ResourceOptionFlags.GenerateMipMaps;
			MipMapping = true;
			break;
		default:
			data = new DataBox[1]
			{
				new DataBox(bitmapData.Scan0, bitmapData.Stride, 0)
			};
			break;
		}
		CheckTextureSize(d3DRenderContext, _0023_003Dz0ERMHbg_003D);
		_0023_003Dz_IfKSJY_003D = new Texture2D(_0023_003DzTzFVZ_00240_003D, new Texture2DDescription
		{
			Width = _0023_003Dz0ERMHbg_003D.Width,
			Height = _0023_003Dz0ERMHbg_003D.Height,
			ArraySize = 1,
			MipLevels = num,
			Format = Format.B8G8R8A8_UNorm,
			Usage = usage,
			SampleDescription = new SampleDescription(1, 0),
			BindFlags = bindFlags,
			OptionFlags = resourceOptionFlags
		}, data);
		_0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(_0023_003DzTzFVZ_00240_003D, _0023_003Dz_IfKSJY_003D);
		if (num == 0)
		{
			DataStream dataStream = new DataStream(_0023_003Dz0ERMHbg_003D.Height * bitmapData.Stride, canRead: true, canWrite: true);
			dataStream.WriteRange(bitmapData.Scan0, dataStream.Length);
			DataBox source = new DataBox(dataStream.DataPointer, bitmapData.Stride, 1);
			d3DRenderContext._0023_003DzP7fhLh8_003D.UpdateSubresource(source, _0023_003Dz_IfKSJY_003D);
			dataStream.Dispose();
			((D3DRenderContext)_0023_003DzmNZD0Zs_003D)._0023_003DzP7fhLh8_003D.GenerateMips(_0023_003DzV_0024hxxsU_0024ZCJW);
		}
		_0023_003Dzxc5GrhYq3y_0024E = d3DRenderContext._0023_003DzKjAPrkH_0024OGSs(_0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D ? Filter.Anisotropic : _0023_003DzyEJxcb2yCP94, _0023_003DzDXSkCVA_003D, _0023_003DzLYY7OMQ_003D, _0023_003DzTzFVZ_00240_003D, 16f);
		base.Size = _0023_003Dz0ERMHbg_003D;
		_0023_003Dza0pUM94_003D.UnlockBits(bitmapData);
	}

	public override void AllocateMemory(RenderContextBase context, bool renderTarget, int width, int height, textureFilteringFunctionType minFilter, textureFilteringFunctionType magFilter, bool repeatS, bool repeatT, IntPtr pixels, bool multisample)
	{
		base.AllocateMemory(context, renderTarget, width, height, minFilter, magFilter, repeatS, repeatT, pixels, multisample);
		D3DRenderContext d3DRenderContext = (D3DRenderContext)context;
		Texture2DDescription _0023_003Dz9BXbES9OsYCS = d3DRenderContext._0023_003Dz9BXbES9OsYCS;
		_0023_003Dz9BXbES9OsYCS.Width = width;
		_0023_003Dz9BXbES9OsYCS.Height = height;
		_0023_003Dz9BXbES9OsYCS.OptionFlags = ResourceOptionFlags.None;
		MipMapping = false;
		if (minFilter == textureFilteringFunctionType.LinearMipmapLinear)
		{
			_0023_003Dz9BXbES9OsYCS.MipLevels = 0;
			_0023_003Dz9BXbES9OsYCS.OptionFlags = ResourceOptionFlags.GenerateMipMaps;
			MipMapping = true;
		}
		if (renderTarget)
		{
			_0023_003Dz9BXbES9OsYCS.BindFlags = BindFlags.ShaderResource | BindFlags.RenderTarget;
			if (d3DRenderContext._0023_003DzlzeQWTRlPk6m())
			{
				_0023_003Dz9BXbES9OsYCS.Format = Format.B8G8R8A8_UNorm;
			}
			else
			{
				_0023_003Dz9BXbES9OsYCS.Format = Format.R8G8B8A8_UNorm;
			}
			if (minFilter != textureFilteringFunctionType.LinearMipmapLinear)
			{
				_0023_003Dz9BXbES9OsYCS.MipLevels = 1;
			}
			_0023_003Dz9BXbES9OsYCS.Usage = ResourceUsage.Default;
			_0023_003Dz9BXbES9OsYCS.CpuAccessFlags = CpuAccessFlags.None;
			_0023_003Dz9BXbES9OsYCS.ArraySize = 1;
		}
		else
		{
			_0023_003Dz9BXbES9OsYCS.CpuAccessFlags = CpuAccessFlags.Write;
			_0023_003Dz9BXbES9OsYCS.Usage = ResourceUsage.Dynamic;
			_0023_003Dz9BXbES9OsYCS.BindFlags = BindFlags.ShaderResource;
		}
		if (d3DRenderContext._0023_003DzGIPo6pY0ShMi > FeatureLevel.Level_9_3 && multisample)
		{
			_0023_003Dz9BXbES9OsYCS.SampleDescription = d3DRenderContext._0023_003DzoZFDtSI_003D;
		}
		else
		{
			_0023_003Dz9BXbES9OsYCS.SampleDescription = new SampleDescription(1, 0);
		}
		if (_0023_003Dz9BXbES9OsYCS.SampleDescription.Count > 1)
		{
			_0023_003Dz9BXbES9OsYCS.MipLevels = 1;
		}
		CheckTextureSize(d3DRenderContext, new Size(_0023_003Dz9BXbES9OsYCS.Width, _0023_003Dz9BXbES9OsYCS.Height));
		_0023_003Dz_IfKSJY_003D = new Texture2D(d3DRenderContext._0023_003DzTzFVZ_00240_003D, _0023_003Dz9BXbES9OsYCS);
		_0023_003DzV_0024hxxsU_0024ZCJW = new ShaderResourceView(d3DRenderContext._0023_003DzTzFVZ_00240_003D, _0023_003Dz_IfKSJY_003D);
		_0023_003Dzxc5GrhYq3y_0024E = ((D3DRenderContext)context)._0023_003DzKjAPrkH_0024OGSs(D3DTexture._0023_003DzBum_5fBFid7F(minFilter, magFilter), repeatS, repeatT, d3DRenderContext._0023_003DzTzFVZ_00240_003D, 16f);
		base.Size = new Size(width, height);
		if (renderTarget)
		{
			_0023_003Dz59osH17qGO0V = new RenderTargetView(d3DRenderContext._0023_003DzTzFVZ_00240_003D, _0023_003Dz_IfKSJY_003D);
		}
	}

	public void FillTextureFromScreen(Size controlSize, int x, int y, int width, int height, D3DRenderContext renderContext)
	{
		int num = Math.Min(x + width, controlSize.Width);
		int num2 = Math.Min(y + height, controlSize.Height);
		if (num >= x && num2 >= y)
		{
			renderContext._0023_003DzP7fhLh8_003D.CopySubresourceRegion(renderContext._0023_003DzxPP8x2119RobVE2x5A_003D_003D(), 0, new ResourceRegion(x, y, 0, num, num2, 1), _0023_003Dz_IfKSJY_003D, 0);
		}
	}

	public short[] ReadDepths(System.Drawing.Rectangle rect)
	{
		return _0023_003DzfaPKPFFTbIMY5EK3Vg_003D_003D(rect, (Texture2D)_0023_003Dz_IfKSJY_003D);
	}

	internal static short[] _0023_003DzfaPKPFFTbIMY5EK3Vg_003D_003D(System.Drawing.Rectangle _0023_003Dzols9v2M_003D, Texture2D _0023_003Dz_IfKSJY_003D)
	{
		short[] array = null;
		using Surface surface = _0023_003Dz_IfKSJY_003D.QueryInterface<Surface>();
		int num = 4;
		DataStream dataStream;
		DataRectangle dataRectangle = surface.Map(SharpDX.DXGI.MapFlags.Read, out dataStream);
		array = new short[_0023_003Dzols9v2M_003D.Width * _0023_003Dzols9v2M_003D.Height];
		int num2 = _0023_003Dzols9v2M_003D.Width * num;
		byte[] array2 = new byte[num2];
		int num3 = dataRectangle.Pitch - num2;
		int num4 = _0023_003Dzols9v2M_003D.Y + _0023_003Dzols9v2M_003D.Height;
		dataStream.Seek(_0023_003Dzols9v2M_003D.Y * dataRectangle.Pitch + _0023_003Dzols9v2M_003D.X * num, SeekOrigin.Begin);
		if (_0023_003Dz_IfKSJY_003D.Description.Format == Format.D24_UNorm_S8_UInt)
		{
			int[] array3 = new int[_0023_003Dzols9v2M_003D.Width];
			float num5 = (float)Math.Pow(2.0, 24.0) - 1f;
			float num6 = 32767f / num5;
			int num7 = _0023_003Dzols9v2M_003D.Y;
			int num8 = 0;
			while (num7 < num4)
			{
				dataStream.Read(array2, 0, num2);
				System.Buffer.BlockCopy(array2, 0, array3, 0, num2);
				int num9 = _0023_003Dzols9v2M_003D.Size.Width * (_0023_003Dzols9v2M_003D.Size.Height - num8 - 1);
				for (int i = 0; i < array3.Length; i++)
				{
					array[num9++] = (short)Math.Round(num6 * (float)array3[i]);
				}
				if (dataStream.Position + num3 <= dataStream.Length)
				{
					dataStream.Seek(num3, SeekOrigin.Current);
				}
				num7++;
				num8++;
			}
		}
		else
		{
			float[] array4 = new float[_0023_003Dzols9v2M_003D.Width];
			float num10 = 32767f;
			int num11 = _0023_003Dzols9v2M_003D.Y;
			int num12 = 0;
			while (num11 < num4)
			{
				dataStream.Read(array2, 0, num2);
				System.Buffer.BlockCopy(array2, 0, array4, 0, num2);
				int num13 = _0023_003Dzols9v2M_003D.Size.Width * (_0023_003Dzols9v2M_003D.Size.Height - num12 - 1);
				for (int j = 0; j < array4.Length; j++)
				{
					array[num13++] = (short)Math.Round(num10 * array4[j]);
				}
				if (dataStream.Position + num3 <= dataStream.Length)
				{
					dataStream.Seek(num3, SeekOrigin.Current);
				}
				num11++;
				num12++;
			}
		}
		dataStream.Dispose();
		surface.Unmap();
		return array;
	}

	[CLSCompliant(false)]
	internal byte[] _0023_003DzV9WuMm8_003D(System.Drawing.Rectangle _0023_003Dzols9v2M_003D, D3DRenderContext _0023_003DzmNZD0Zs_003D, Texture2D _0023_003DzPJVUiq_dfV6E)
	{
		if (_0023_003DzPJVUiq_dfV6E.Description.SampleDescription.Count > 1)
		{
			D3DTexture2D d3DTexture2D = null;
			d3DTexture2D = new D3DTexture2D();
			d3DTexture2D._0023_003Dzcp4fLOSZApya(_0023_003DzmNZD0Zs_003D, base.Size, CpuAccessFlags.None, ResourceUsage.Default, Format.R8G8B8A8_UNorm, BindFlags.ShaderResource, new SampleDescription(1, 0));
			_0023_003DzmNZD0Zs_003D._0023_003DzP7fhLh8_003D.ResolveSubresource(_0023_003DzPJVUiq_dfV6E, 0, d3DTexture2D._0023_003Dz_IfKSJY_003D, 0, _0023_003DzPJVUiq_dfV6E.Description.Format);
			_0023_003DzmNZD0Zs_003D._0023_003DzP7fhLh8_003D.CopySubresourceRegion(d3DTexture2D._0023_003Dz_IfKSJY_003D, 0, new ResourceRegion(_0023_003Dzols9v2M_003D.Left, _0023_003Dzols9v2M_003D.Top, 0, _0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Bottom, 1), _0023_003Dz_IfKSJY_003D, 0);
			d3DTexture2D.Dispose();
		}
		else
		{
			_0023_003DzmNZD0Zs_003D._0023_003DzP7fhLh8_003D.CopySubresourceRegion(_0023_003DzPJVUiq_dfV6E, 0, new ResourceRegion(_0023_003Dzols9v2M_003D.Left, _0023_003Dzols9v2M_003D.Top, 0, _0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Bottom, 1), _0023_003Dz_IfKSJY_003D, 0);
		}
		byte[] array = null;
		using Surface surface = _0023_003Dz_IfKSJY_003D.QueryInterface<Surface>();
		DataStream dataStream;
		DataRectangle dataRectangle = surface.Map(SharpDX.DXGI.MapFlags.Read, out dataStream);
		array = new byte[_0023_003Dzols9v2M_003D.Width * _0023_003Dzols9v2M_003D.Height * 4];
		int num = _0023_003Dzols9v2M_003D.Width * 4;
		byte[] array2 = new byte[num];
		int num2 = 0;
		int num3 = dataRectangle.Pitch - num;
		for (int i = 0; i < _0023_003Dzols9v2M_003D.Height; i++)
		{
			dataStream.Read(array2, 0, num);
			dataStream.Seek(num3, SeekOrigin.Current);
			Array.Copy(array2, 0, array, num2, num);
			num2 += num;
		}
		dataStream.Dispose();
		surface.Unmap();
		return array;
	}

	public void Load(RenderContextBase renderContext, Bitmap bmp)
	{
		_0023_003DzSpXm1l_Bq4NB(renderContext, bmp, bmp.Size, Filter.MinMagMipLinear, _0023_003DzmhFohlD_xpfJaZo1nm8fiYc_003D: true, _0023_003DzDXSkCVA_003D: true, _0023_003DzLYY7OMQ_003D: true, _0023_003DzorHz8sxwhiTJ: true, _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D: false);
	}
}
