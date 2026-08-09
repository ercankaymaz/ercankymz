using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using devDept.Diagnostic;
using devDept.Eyeshot;

namespace devDept.Graphics;

public class ZBuffer : ZBufferBase
{
	public Bitmap Bmp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzZXg_7t6x7hPl0XTwMNhPVuc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzujZOPV7OUEWg7MrHQLH9kAk_003D;

	public override Size Size
	{
		get
		{
			return base.Size;
		}
		set
		{
			base.Size = value;
			if (Bmp != null)
			{
				ResetBmp();
			}
		}
	}

	public override void Dispose()
	{
		if (Bmp != null)
		{
			Bmp.Dispose();
			Bmp = null;
		}
	}

	public override bool ReadZRange(RenderContextBase renderContextBase, Point centerCameraScreen, int width, int height, ref double zMin, ref double zMax, bool optimizeRead, int layoutWidth, int layoutHeight)
	{
		RenderContext renderContext = (RenderContext)renderContextBase;
		if (centerCameraScreen.X < 0 || centerCameraScreen.Y < 0)
		{
			return false;
		}
		if (optimizeRead && height < LinesReadIncrement)
		{
			return false;
		}
		int _0023_003DzhXpC6io_003D = (int)((double)centerCameraScreen.X - (double)width / 2.0);
		int _0023_003DznPWAePU_003D = (int)((double)centerCameraScreen.Y - (double)height / 2.0);
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		int num = ((!optimizeRead) ? 1 : LinesReadIncrement);
		int num2 = height / num;
		List<short[]> list = null;
		int _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D = 0;
		renderContext._0023_003DzYDHFZIvmSA1e(Size, ref Bmp, out _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D);
		if (num > 1)
		{
			list = new List<short[]>(num2);
			if (width == 0)
			{
				_0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D = 1;
			}
			int num3 = 0;
			int num4 = 0;
			while (num3 < num2)
			{
				list.Add(_0023_003Dzrt0uzQdUdAeV(renderContext, Size, _0023_003DzhXpC6io_003D, num4, width, 1, layoutWidth, layoutHeight));
				num3++;
				num4 += num;
			}
		}
		else
		{
			list = new List<short[]>(1);
			if (width == 0 || height == 0)
			{
				_0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D = 1;
			}
			list.Add(_0023_003Dzrt0uzQdUdAeV(renderContext, Size, _0023_003DzhXpC6io_003D, _0023_003DznPWAePU_003D, width, height, layoutWidth, layoutHeight));
		}
		renderContext.EndReadDepthValues();
		stopwatch.Stop();
		bool result = _0023_003Dzv4EuiJdFlHVJ(list, width, _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D, 32767.0, ref zMin, ref zMax);
		long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
		if (optimizeRead)
		{
			if (elapsedMilliseconds > 20)
			{
				if (LinesReadIncrement == 1)
				{
					LinesReadIncrement = 4;
				}
				else
				{
					LinesReadIncrement++;
				}
			}
			else if (elapsedMilliseconds < 10)
			{
				LinesReadIncrement--;
			}
			if (LinesReadIncrement < 4)
			{
				LinesReadIncrement = 1;
			}
		}
		return result;
	}

	private static short[] _0023_003Dzrt0uzQdUdAeV(RenderContextBase _0023_003DzmNZD0Zs_003D, Size _0023_003Dz0ERMHbg_003D, int _0023_003DzhXpC6io_003D, int _0023_003DznPWAePU_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, int _0023_003DzBjioNHRH5zes, int _0023_003Dz85HE7X6tpfr1)
	{
		if (_0023_003DzhXpC6io_003D < 0)
		{
			_0023_003DzhXpC6io_003D = 0;
		}
		if (_0023_003DznPWAePU_003D < 0)
		{
			_0023_003DznPWAePU_003D = 0;
		}
		if (_0023_003DzBjioNHRH5zes != 0 && _0023_003Dz85HE7X6tpfr1 != 0)
		{
			if (_0023_003DzhXpC6io_003D + _0023_003Dz7PIPnGI_003D > _0023_003DzBjioNHRH5zes)
			{
				_0023_003Dz7PIPnGI_003D = _0023_003DzBjioNHRH5zes - _0023_003DzhXpC6io_003D;
			}
			if (_0023_003DznPWAePU_003D + _0023_003DzkQAiKLA_003D > _0023_003Dz85HE7X6tpfr1)
			{
				_0023_003DzkQAiKLA_003D = _0023_003Dz85HE7X6tpfr1 - _0023_003DznPWAePU_003D;
			}
		}
		if (_0023_003Dz7PIPnGI_003D > _0023_003Dz0ERMHbg_003D.Width)
		{
			_0023_003Dz7PIPnGI_003D = _0023_003Dz0ERMHbg_003D.Width;
		}
		if (_0023_003DzkQAiKLA_003D > _0023_003Dz0ERMHbg_003D.Height)
		{
			_0023_003DzkQAiKLA_003D = _0023_003Dz0ERMHbg_003D.Height;
		}
		if (_0023_003Dz7PIPnGI_003D <= 0 || _0023_003DzkQAiKLA_003D <= 0)
		{
			return new short[0];
		}
		return _0023_003DzmNZD0Zs_003D.ReadDepthValues(new Point(_0023_003DzhXpC6io_003D + _0023_003Dz7PIPnGI_003D / 2, _0023_003DznPWAePU_003D + _0023_003DzkQAiKLA_003D / 2), new Size(_0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D));
	}

	internal static Bitmap _0023_003DzbIYOX1UZPWO7(IList<short[]> _0023_003DzMnWRp_0024o_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, int _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D)
	{
		double _0023_003DzoYJjnU0_003D = 0.0;
		double _0023_003DzWRFixiU_003D = 0.0;
		if (!_0023_003Dzv4EuiJdFlHVJ(_0023_003DzMnWRp_0024o_003D, _0023_003Dz7PIPnGI_003D, _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D, 32767.0, ref _0023_003DzoYJjnU0_003D, ref _0023_003DzWRFixiU_003D))
		{
			return null;
		}
		Bitmap bitmap = new Bitmap(_0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D, PixelFormat.Format24bppRgb);
		ushort num = (ushort)(_0023_003DzoYJjnU0_003D * 32767.0);
		int num2 = (ushort)(_0023_003DzWRFixiU_003D * 32767.0) - num;
		int num3 = _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D - _0023_003Dz7PIPnGI_003D;
		int num4 = 0;
		if (_0023_003DzMnWRp_0024o_003D.Count == 1)
		{
			int num5 = _0023_003DzMnWRp_0024o_003D[0].Length / _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D;
			for (int i = 0; i < num5; i++)
			{
				int num6 = 0;
				while (num6 < _0023_003Dz7PIPnGI_003D)
				{
					if (_0023_003DzMnWRp_0024o_003D[0][num4] == short.MaxValue)
					{
						bitmap.SetPixel(num6, _0023_003DzkQAiKLA_003D - i - 1, Color.FromArgb(255, 255, 0, 0));
					}
					else
					{
						byte b = (byte)((double)(_0023_003DzMnWRp_0024o_003D[0][num4] - num) * 255.0 / (double)num2);
						bitmap.SetPixel(num6, _0023_003DzkQAiKLA_003D - i - 1, Color.FromArgb(255, b, b, b));
					}
					num6++;
					num4++;
				}
				num4 += num3;
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzMnWRp_0024o_003D.Count; j++)
			{
				num4 = 0;
				int num7 = 0;
				while (num7 < _0023_003Dz7PIPnGI_003D)
				{
					if (_0023_003DzMnWRp_0024o_003D[j][num7] == short.MaxValue)
					{
						bitmap.SetPixel(num7, _0023_003DzkQAiKLA_003D - j - 1, Color.FromArgb(255, 255, 0, 0));
					}
					else
					{
						byte b2 = (byte)((double)(_0023_003DzMnWRp_0024o_003D[j][num4] - num) * 255.0 / (double)num2);
						bitmap.SetPixel(num7, _0023_003DzkQAiKLA_003D - j - 1, Color.FromArgb(255, b2, b2, b2));
					}
					num7++;
					num4++;
				}
			}
		}
		return bitmap;
	}

	public override bool ReadPickBoxZRange(RenderContextBase renderContext, Point cameraScreenPos, int pickBoxSizeInPixels, ref double min, ref double max)
	{
		Size size = new Size(pickBoxSizeInPixels, pickBoxSizeInPixels);
		renderContext.BeginReadDepthValues(size, out var strideInPixels);
		List<short[]> list = new List<short[]>();
		short[] array = renderContext.ReadDepthValues(cameraScreenPos, size);
		if (array != null)
		{
			list.Add(array);
		}
		renderContext.EndReadDepthValues();
		return _0023_003Dzv4EuiJdFlHVJ(list, pickBoxSizeInPixels, strideInPixels, 32767.0, ref min, ref max);
	}

	internal static double _0023_003Dzb5ze3RGxKPAJ(double _0023_003DzaNkZ4Os_003D)
	{
		double num = 0.001;
		return (_0023_003DzaNkZ4Os_003D - num) / (1.0 - num);
	}

	private static bool _0023_003Dzv4EuiJdFlHVJ(IList<short[]> _0023_003DzMnWRp_0024o_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D, double _0023_003DzcTfTD6Y_003D, ref double _0023_003DzoYJjnU0_003D, ref double _0023_003DzWRFixiU_003D)
	{
		if (_0023_003DzMnWRp_0024o_003D.Count > 0 && _0023_003DzMnWRp_0024o_003D[0].Length < _0023_003Dz7PIPnGI_003D)
		{
			return false;
		}
		int num = _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D - _0023_003Dz7PIPnGI_003D;
		double num2 = _0023_003DzcTfTD6Y_003D;
		int num3 = 0;
		ushort num4 = (ushort)(0.001 * _0023_003DzcTfTD6Y_003D);
		double num5 = (int)num4;
		if (_0023_003DzMnWRp_0024o_003D.Count == 1)
		{
			int num6 = _0023_003DzMnWRp_0024o_003D[0].Length / _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D;
			for (int i = 0; i < num6; i++)
			{
				int num7 = 0;
				while (num7 < _0023_003Dz7PIPnGI_003D)
				{
					short num8 = _0023_003DzMnWRp_0024o_003D[0][num3];
					if ((double)num8 != _0023_003DzcTfTD6Y_003D && num8 > num4)
					{
						if ((double)num8 > num5)
						{
							num5 = num8;
						}
						if ((double)num8 < num2)
						{
							num2 = num8;
						}
					}
					num7++;
					num3++;
				}
				num3 += num;
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzMnWRp_0024o_003D.Count; j++)
			{
				num3 = 0;
				int num9 = 0;
				while (num9 < _0023_003Dz7PIPnGI_003D)
				{
					short num8 = _0023_003DzMnWRp_0024o_003D[j][num9];
					if ((double)num8 != _0023_003DzcTfTD6Y_003D && num8 > num4)
					{
						if ((double)num8 > num5)
						{
							num5 = num8;
						}
						if ((double)num8 < num2)
						{
							num2 = num8;
						}
					}
					num9++;
					num3++;
				}
			}
		}
		double num10 = 1.0 / (_0023_003DzcTfTD6Y_003D - (double)(int)num4);
		num5 = (num5 - (double)(int)num4) * num10;
		num2 = (num2 - (double)(int)num4) * num10;
		int num11;
		if (num5 != 0.0)
		{
			num11 = ((num2 != 1.0) ? 1 : 0);
			if (num11 != 0)
			{
				_0023_003DzoYJjnU0_003D = num2;
				_0023_003DzWRFixiU_003D = num5;
			}
		}
		else
		{
			num11 = 0;
		}
		return (byte)num11 != 0;
	}

	public override void ResetBmp()
	{
		if (Size.Width > 0 && Size.Height > 0)
		{
			if (Bmp != null && Bmp.Size != Size)
			{
				Dispose();
			}
			if (Bmp == null)
			{
				Bmp = new Bitmap(Size.Width, Size.Height, PixelFormat.Format16bppGrayScale);
			}
			base.ResetBmp();
		}
	}

	public override byte[] CaptureBackbuffer(RenderContextBase renderContextBase, IViewport viewport, int viewportId, string workspaceId, bool keepData, object idItemsMap, bool selectableOnly, double[] modelViewProjectionMatrix, Rectangle rect, bool leafSelection, out int stride, out int bpp, bool innerImage = false)
	{
		RenderContext renderContext = (RenderContext)renderContextBase;
		byte[] array = renderContext.ReadColorBuffer(viewport, rect, out stride, out bpp);
		if (Logger.Instance.CaptureBackbufferImages)
		{
			Rectangle rectangle = new Rectangle(0, 0, viewport.GetViewFrame()[2], viewport.GetViewFrame()[3]);
			int stride2;
			byte[] _0023_003DzqQPYGq3qIt9X = renderContext.ReadColorBuffer(viewport, rectangle, out stride2, out bpp);
			renderContext._0023_003DzAg0R7vgxCXdu(rectangle, _0023_003DzqQPYGq3qIt9X, stride2, _0023_003DzM_6ddEsar_0024m73hc85bkjupQ_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613010), workspaceId, viewportId), _0023_003Dzr5eQXr8_003D: true);
			int stride3;
			byte[] _0023_003DzqQPYGq3qIt9X2 = renderContext.ReadDepthBuffer(rectangle, out stride3, out bpp);
			renderContext._0023_003DzAg0R7vgxCXdu(rectangle, _0023_003DzqQPYGq3qIt9X2, stride3, _0023_003DzM_6ddEsar_0024m73hc85bkjupQ_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613024), workspaceId, viewportId), _0023_003Dzr5eQXr8_003D: true);
			_0023_003DzZXg_7t6x7hPl0XTwMNhPVuc_003D++;
		}
		if (keepData)
		{
			if (innerImage)
			{
				SelectionImage.InnerSelectionImage = array;
				SelectionImage.InnerIdItemsMap = idItemsMap;
			}
			else
			{
				SelectionImage.Image = array;
				SelectionImage.IdItemsMap = idItemsMap;
				SelectionImage.leafSelection = leafSelection;
				SelectionImage.InnerSelectionImage = null;
				SelectionImage.InnerIdItemsMap = null;
				SelectionImage.Stride = stride;
				SelectionImage.Bpp = bpp;
				SelectionImage.SelectableOnly = selectableOnly;
				Array.Copy(modelViewProjectionMatrix, SelectionImage.matrixAtCaptureInstant, 16);
			}
		}
		return array;
	}

	private string _0023_003DzM_6ddEsar_0024m73hc85bkjupQ_003D(string _0023_003Dzede4j5s_003D, string _0023_003DzywqD7gY_003D, int _0023_003DzE0McywA_003D)
	{
		if (_0023_003DzujZOPV7OUEWg7MrHQLH9kAk_003D == null)
		{
			_0023_003DzujZOPV7OUEWg7MrHQLH9kAk_003D = Path.GetDirectoryName(Logger.Instance.GetFullPath());
			if (string.IsNullOrEmpty(_0023_003DzujZOPV7OUEWg7MrHQLH9kAk_003D) || !Directory.Exists(_0023_003DzujZOPV7OUEWg7MrHQLH9kAk_003D))
			{
				_0023_003DzujZOPV7OUEWg7MrHQLH9kAk_003D = Path.GetTempPath();
			}
		}
		return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613070), _0023_003DzujZOPV7OUEWg7MrHQLH9kAk_003D, _0023_003Dzede4j5s_003D, Logger.Instance.Id, _0023_003DzywqD7gY_003D, _0023_003DzE0McywA_003D, _0023_003DzZXg_7t6x7hPl0XTwMNhPVuc_003D.ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348613109)));
	}
}
