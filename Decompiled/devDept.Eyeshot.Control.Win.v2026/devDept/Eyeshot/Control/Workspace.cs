#define WINFORMS
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using D3DShaders;
using Microsoft.Win32;
using OpenGL;
using devDept.Diagnostic;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Control.Mouse3D;
using devDept.Eyeshot.Control.MultiTouch;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Control;

public abstract class Workspace : WorkspaceBase, IWorkspace, IWorkspaceInternal, ISupportWorkManager
{
	private sealed class _0023_003Dz2JdwzXSv2lMt9rIufG4Q8Xw_003D
	{
		public HashSet<Entity> _0023_003Dz3n7Denxh0jei;

		internal void _0023_003DzR3UYyFZsWD8IDNCrsdTbbV4_003D(SelectedItem _0023_003Dz8GBMuoM_003D)
		{
			_0023_003Dz3n7Denxh0jei.Add((Entity)_0023_003Dz8GBMuoM_003D.Item);
		}

		internal void _0023_003DzOcJi_0024FP73iPySL0aSJ2_0024Y24_003D(SelectedItem _0023_003Dz8GBMuoM_003D)
		{
			_0023_003Dz3n7Denxh0jei.Add((Entity)_0023_003Dz8GBMuoM_003D.Item);
		}
	}

	private sealed class _0023_003Dz2PUehfiyAVn3
	{
		public readonly Rectangle _0023_003DzWFw0btc_003D;

		public readonly int _0023_003DzLfvBTJLlho6b;

		public readonly int _0023_003Dzr5taPomnX8iY;

		public _0023_003Dz2PUehfiyAVn3(PrintPageEventArgs _0023_003Dz1SmHC4c_003D)
		{
			IntPtr hdc = _0023_003Dz1SmHC4c_003D.Graphics.GetHdc();
			_0023_003DzLfvBTJLlho6b = _0023_003DzY5ykWE3nyNxd(hdc, 112);
			_0023_003Dzr5taPomnX8iY = _0023_003DzY5ykWE3nyNxd(hdc, 113);
			_0023_003Dz1SmHC4c_003D.Graphics.ReleaseHdc(hdc);
			_0023_003DzLfvBTJLlho6b = (int)((double)_0023_003DzLfvBTJLlho6b * 100.0 / (double)_0023_003Dz1SmHC4c_003D.Graphics.DpiX);
			_0023_003Dzr5taPomnX8iY = (int)((double)_0023_003Dzr5taPomnX8iY * 100.0 / (double)_0023_003Dz1SmHC4c_003D.Graphics.DpiY);
			_0023_003DzWFw0btc_003D = _0023_003Dz1SmHC4c_003D.MarginBounds;
			_0023_003DzWFw0btc_003D.Offset(-_0023_003DzLfvBTJLlho6b, -_0023_003Dzr5taPomnX8iY);
		}

		[DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps")]
		private static extern int _0023_003DzY5ykWE3nyNxd(IntPtr _0023_003DzMUy2r_A_003D, int _0023_003DzXo_0024Fv2N16yjOpzg_0024hA_003D_003D);
	}

	private sealed class _0023_003Dz4rgC_0024GWsoXmE6EAK3Hh0hv0_003D
	{
		public RenderContextBase _0023_003DzmNZD0Zs_003D;

		internal void _0023_003DzfLPmqfrZGlp6O5ha7sXIkOo_003D(RenderContextBase _0023_003DzNkgzXsMnh9_b, object _0023_003DzuueBYDLjncfR)
		{
			_0023_003DzmNZD0Zs_003D.DrawLineStrip(new Point3D[3]
			{
				new Point3D(-6.0, -3.0),
				new Point3D(0.0, 0.0),
				new Point3D(-6.0, 3.0)
			});
		}
	}

	private sealed class _0023_003Dz8_00241rV1A_003D
	{
		private readonly object _0023_003DzGe1ohzg_003D = new object();

		private Task _0023_003DzBc1hlWtqLo9X = Task.CompletedTask;

		private TaskCompletionSource<bool>? _0023_003DzIqIfrD8_003D;

		private bool _0023_003DzveFNfktCPM12;

		private int _0023_003DzOGEGXx1kkcw6;

		public Task _0023_003DzyYuAQN8_003D()
		{
			lock (_0023_003DzGe1ohzg_003D)
			{
				return _0023_003DzBc1hlWtqLo9X;
			}
		}

		public void _0023_003DzZjL15X8_003D()
		{
			lock (_0023_003DzGe1ohzg_003D)
			{
				_0023_003DzOGEGXx1kkcw6++;
			}
		}

		public bool _0023_003Dz7HticeW00qIl()
		{
			lock (_0023_003DzGe1ohzg_003D)
			{
				return _0023_003DzveFNfktCPM12;
			}
		}

		public void _0023_003DzAiYx9eY_003D()
		{
			lock (_0023_003DzGe1ohzg_003D)
			{
				if (!_0023_003DzveFNfktCPM12)
				{
					_0023_003DzIqIfrD8_003D = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
					_0023_003DzBc1hlWtqLo9X = _0023_003DzIqIfrD8_003D.Task;
					_0023_003DzveFNfktCPM12 = true;
				}
			}
		}

		public void _0023_003DzVOCJm_s_003D()
		{
			TaskCompletionSource<bool> taskCompletionSource = null;
			lock (_0023_003DzGe1ohzg_003D)
			{
				_0023_003DzOGEGXx1kkcw6--;
				if (!_0023_003DzveFNfktCPM12 || _0023_003DzOGEGXx1kkcw6 > 0)
				{
					return;
				}
				taskCompletionSource = _0023_003DzIqIfrD8_003D;
				_0023_003DzIqIfrD8_003D = null;
				_0023_003DzBc1hlWtqLo9X = Task.CompletedTask;
				_0023_003DzveFNfktCPM12 = false;
			}
			taskCompletionSource.TrySetResult(result: true);
		}
	}

	private sealed class _0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D
	{
		public Viewport _0023_003Dz7Xo5EoA_003D;

		public Workspace _0023_003DzKdgtcDsi34jL;

		public object _0023_003DzxwGby4M_003D;

		internal void _0023_003DzITwgkvIIkgIArD6RAITc0JM_003D()
		{
			_0023_003Dz7Xo5EoA_003D._0023_003Dz3w_00240eHwLabq0(_0023_003DzKdgtcDsi34jL, _0023_003DzKdgtcDsi34jL._0023_003DzY7PoD1c_003D, _0023_003DzKdgtcDsi34jL._0023_003DzxIgINtc_003D, 1.0);
			_0023_003DzKdgtcDsi34jL._0023_003DzH_ACO1keHrO4();
			_0023_003DzKdgtcDsi34jL._0023_003DzFBmlAVlkXQOb?.Invoke(_0023_003DzxwGby4M_003D, EventArgs.Empty);
		}
	}

	internal enum _0023_003DzARfd93yYb38F
	{

	}

	private struct _0023_003DzCpv3RVLsUYJ9(Workspace _0023_003DzU0f5_qE_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public rotationType _0023_003DzkBN945tq8dje = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp().Rotate.RotationMode;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public actionType _0023_003DzfcUzrRi_0024u6FZ = _0023_003DzU0f5_qE_003D.ActionMode;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public rotationCenterType _0023_003Dznz2Nz_0024pUXyd9 = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp().Rotate.RotationCenter;

		internal void _0023_003DzDuJLCUo_003D(Workspace _0023_003DzU0f5_qE_003D)
		{
			_0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp().Rotate.RotationMode = _0023_003DzkBN945tq8dje;
			_0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp().Rotate.RotationCenter = _0023_003Dznz2Nz_0024pUXyd9;
			_0023_003DzU0f5_qE_003D.ActionMode = _0023_003DzfcUzrRi_0024u6FZ;
		}
	}

	internal delegate void _0023_003DzE92QaKyEx45_0024(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024);

	internal sealed class _0023_003DzEmdG9Ls_003D
	{
		public HiddenLinesViewOnPaper _0023_003Dz8g7oLeS9qqb_0024pw6_LA_003D_003D;

		public PaperSize _0023_003DzMJQ6R6YKj1pt;

		public bool _0023_003DzCi5cg9E_003D;

		public RectangleF _0023_003DzroyCNuM_003D;

		public _0023_003DzEmdG9Ls_003D(HiddenLinesViewOnPaper _0023_003Dzmob8Et0qDP1_HRP_0024sA_003D_003D, Workspace _0023_003DzU0f5_qE_003D)
		{
			_0023_003Dz8g7oLeS9qqb_0024pw6_LA_003D_003D = _0023_003Dzmob8Et0qDP1_HRP_0024sA_003D_003D;
			if (_0023_003DzU0f5_qE_003D is Drawing drawing && _0023_003DzU0f5_qE_003D._0023_003DzbdLgm9c_003D._0023_003DzVWilOEkLyDxl)
			{
				_0023_003DzUMSSRSw_003D(drawing.ActiveSheet);
				return;
			}
			_0023_003DzMJQ6R6YKj1pt = _0023_003DzU0f5_qE_003D._0023_003DzbdLgm9c_003D.DefaultPageSettings.PaperSize;
			_0023_003DzCi5cg9E_003D = _0023_003DzU0f5_qE_003D._0023_003DzbdLgm9c_003D.DefaultPageSettings.Landscape;
		}

		private void _0023_003DzUMSSRSw_003D(Sheet _0023_003DzO7pLOA27s4z4)
		{
			PrinterSettings printerSettings = new PrinterSettings();
			double num = _0023_003DzO7pLOA27s4z4.Width * Utility.GetLinearUnitsConversionFactor(_0023_003DzO7pLOA27s4z4.Units, linearUnitsType.Inches);
			double num2 = _0023_003DzO7pLOA27s4z4.Height * Utility.GetLinearUnitsConversionFactor(_0023_003DzO7pLOA27s4z4.Units, linearUnitsType.Inches);
			double num3 = num * num2;
			double num4 = double.MaxValue;
			foreach (PaperSize paperSize in printerSettings.PaperSizes)
			{
				double num5 = (double)paperSize.Width / 100.0;
				double num6 = (double)paperSize.Height / 100.0;
				if (Math.Abs(num5 - num) < 0.01 && Math.Abs(num6 - num2) < 0.01)
				{
					_0023_003DzCi5cg9E_003D = false;
					_0023_003DzMJQ6R6YKj1pt = paperSize;
					break;
				}
				if (Math.Abs(num5 - num2) < 0.01 && Math.Abs(num6 - num) < 0.01)
				{
					_0023_003DzCi5cg9E_003D = true;
					_0023_003DzMJQ6R6YKj1pt = paperSize;
					break;
				}
				double num7 = Math.Abs(num5 * num6 - num3);
				if (num7 < num4)
				{
					num4 = num7;
					_0023_003DzMJQ6R6YKj1pt = paperSize;
					_0023_003DzCi5cg9E_003D = ((num5 < num6) ? (num > num2) : (num < num2));
				}
			}
		}
	}

	private sealed class _0023_003DzFS_0024a4CDzXCfMy_0024ciqEQNy88_003D
	{
		public int _0023_003DzcU2W_0024IwZm_0024cF;

		public Workspace _0023_003DzKdgtcDsi34jL;

		internal void _0023_003DzbRFNoVK1vq75tqWpd5rTRjXWyg4G(object _0023_003DzxwGby4M_003D, EventArgs _0023_003DzPmVBsAU_003D)
		{
			foreach (ToolStripMenuItem dropDownItem in _0023_003DzKdgtcDsi34jL._0023_003DzKk1DQUn5co_aN4nO4w_003D_003D.DropDownItems)
			{
				if (dropDownItem == _0023_003DzxwGby4M_003D)
				{
					dropDownItem.Checked = true;
					_0023_003DzKdgtcDsi34jL.Mouse3D.SpeedFactor = tdx._0023_003DzUiPCQHxNFWkm[_0023_003DzcU2W_0024IwZm_0024cF];
				}
				else
				{
					dropDownItem.Checked = false;
				}
			}
		}
	}

	internal delegate void _0023_003DzHdL9CKamSnvn(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024);

	private static class _0023_003DzJmYT_002400_003D
	{
		public static _0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003Dzw0ZEq8VA92eQEu7CGA_003D_003D _0023_003DzAfg9gincPziDhEsG5ZCsi4d_0024cYX8xMRI9LoXOeO7JEX_;

		public static _0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003Dzw0ZEq8VA92eQEu7CGA_003D_003D _0023_003DzA1U2nR9LjOoCBNIKc2D1fjd_jfB_69MzTg_003D_003D;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003DzjNLHL0D_BYhPePeAqN8myP8_003D;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003DzdRhufEVWXwogSYLk5M3SHfaIj_0024LS;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003Dzp_0024aYizK_0024l5XZVhK_0024mAE45nyVIbSZ;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003Dzfopde7ZaTJ_0024h_0024nBXkKYi0460jCotplX4FQ_003D_003D;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003DzCtmt9TTuAxjrUsMPIL9Wfc5dSbzornFxBA_003D_003D;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003Dzq0VglYBBd1xl5azB2IAaZXcKgRzx;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003DzX_vo4t1_0024nYhiZJvZm_Y_0024NCXzKVWw;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003DzNnJSiAtXScDHdA198QoBNdg_003D;

		public static WorkspaceDrawForSelectionEntityDelegate _0023_003Dzr915hjAV_00241wUaL0S9Q_003D_003D;
	}

	internal sealed class _0023_003DzKNo6tLg_003D : PrintDocument
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzILx5ao0Ka_gJ = true;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzCB89SQM6tcPg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dz7IlramNpWwjN;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public List<_0023_003DzEmdG9Ls_003D> _0023_003DzrDcpsS8_003D = new List<_0023_003DzEmdG9Ls_003D>();

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzuw7Bx3c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzA3ipzoQ5sbsK = true;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzVWilOEkLyDxl;

		public _0023_003DzEmdG9Ls_003D IYUQCRJtyhl()
		{
			return _0023_003DzrDcpsS8_003D[_0023_003Dzuw7Bx3c_003D];
		}

		protected override void OnQueryPageSettings(QueryPageSettingsEventArgs _0023_003Dz1SmHC4c_003D)
		{
			base.OnQueryPageSettings(_0023_003Dz1SmHC4c_003D);
			_0023_003DzEmdG9Ls_003D _0023_003DzEmdG9Ls_003D2 = IYUQCRJtyhl();
			PageSettings pageSettings = _0023_003Dz1SmHC4c_003D.PageSettings;
			PaperSize paperSize = (base.DefaultPageSettings.PaperSize = _0023_003DzEmdG9Ls_003D2._0023_003DzMJQ6R6YKj1pt);
			pageSettings.PaperSize = paperSize;
			PageSettings pageSettings2 = _0023_003Dz1SmHC4c_003D.PageSettings;
			bool landscape = (base.DefaultPageSettings.Landscape = _0023_003DzEmdG9Ls_003D2._0023_003DzCi5cg9E_003D);
			pageSettings2.Landscape = landscape;
		}

		protected override void OnPrintPage(PrintPageEventArgs _0023_003Dz1SmHC4c_003D)
		{
			base.OnPrintPage(_0023_003Dz1SmHC4c_003D);
			if (_0023_003Dzuw7Bx3c_003D < _0023_003DzrDcpsS8_003D.Count)
			{
				_0023_003DzEmdG9Ls_003D obj = IYUQCRJtyhl();
				int _0023_003Dzi_0024HtOIYX2veyl1JI0Q_003D_003D;
				int _0023_003DzFu25JxQ54l6eztld4A_003D_003D;
				Rectangle rectangle = _0023_003DzdAsCcR79gZ0g(_0023_003Dz1SmHC4c_003D, base.PrintController.IsPreview, out _0023_003Dzi_0024HtOIYX2veyl1JI0Q_003D_003D, out _0023_003DzFu25JxQ54l6eztld4A_003D_003D);
				RectangleF _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D;
				if (base.DefaultPageSettings.PrintableArea.Width > 0f && base.DefaultPageSettings.PrintableArea.Height > 0f)
				{
					if (_0023_003DzCB89SQM6tcPg)
					{
						RectangleF printableArea = base.DefaultPageSettings.PrintableArea;
						printableArea.Offset(-_0023_003Dzi_0024HtOIYX2veyl1JI0Q_003D_003D, -_0023_003DzFu25JxQ54l6eztld4A_003D_003D);
						_0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D = ((!base.DefaultPageSettings.Landscape) ? printableArea : new RectangleF(printableArea.X, printableArea.Y, printableArea.Height, printableArea.Width));
					}
					else
					{
						_0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D = rectangle;
						if (RegionInfo.CurrentRegion.IsMetric)
						{
							_0023_003DzM1F7D8THIQLlsp0fgEaZubXzp0ct(_0023_003Dz1SmHC4c_003D, ref _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D);
						}
					}
				}
				else
				{
					if (_0023_003Dz1SmHC4c_003D.MarginBounds.Width <= 0 || _0023_003Dz1SmHC4c_003D.MarginBounds.Height <= 0)
					{
						throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591705));
					}
					_0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D = rectangle;
					if (RegionInfo.CurrentRegion.IsMetric)
					{
						_0023_003DzM1F7D8THIQLlsp0fgEaZubXzp0ct(_0023_003Dz1SmHC4c_003D, ref _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D);
					}
				}
				obj._0023_003Dz8g7oLeS9qqb_0024pw6_LA_003D_003D.PrintRect = new RectangleF(_0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.Left, _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.Top, _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.Width, _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.Height);
				HiddenLinesViewSettingsEx obj2 = (HiddenLinesViewSettingsEx)obj._0023_003Dz8g7oLeS9qqb_0024pw6_LA_003D_003D.HdlViewSettings;
				obj2.PenEdge.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
				obj2.PenSilhouette.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
				obj2.PenWire.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
				obj2.PenHiddenEdge.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
				obj2.PenHiddenSilhouette.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
				obj2.PenHiddenWire.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
				obj._0023_003Dz8g7oLeS9qqb_0024pw6_LA_003D_003D.Print(_0023_003Dz1SmHC4c_003D);
				_0023_003Dzuw7Bx3c_003D++;
				_0023_003Dz1SmHC4c_003D.HasMorePages = _0023_003Dzuw7Bx3c_003D < _0023_003DzrDcpsS8_003D.Count;
			}
			else
			{
				_0023_003Dz1SmHC4c_003D.HasMorePages = false;
			}
			if (!_0023_003Dz1SmHC4c_003D.HasMorePages)
			{
				hKxLbCvKjVpI4dvqv3tjvDsUbXA();
			}
		}

		public void hKxLbCvKjVpI4dvqv3tjvDsUbXA()
		{
			if (!_0023_003Dz7IlramNpWwjN)
			{
				_0023_003DzrDcpsS8_003D.Clear();
			}
			_0023_003DzVWilOEkLyDxl = false;
			_0023_003Dzuw7Bx3c_003D = 0;
			_0023_003DzA3ipzoQ5sbsK = true;
		}

		protected override void Dispose(bool _0023_003DzKIzso_w_003D)
		{
			_0023_003Dz7IlramNpWwjN = false;
			hKxLbCvKjVpI4dvqv3tjvDsUbXA();
			base.Dispose(_0023_003DzKIzso_w_003D);
		}
	}

	private enum _0023_003DzKv143IQ_003D
	{

	}

	private sealed class _0023_003DzLliFkdGqG0Ir8wrEPhjY1fk_003D
	{
		public MouseEventArgs _0023_003Dz1SmHC4c_003D;

		internal bool _0023_003DzkmHh2pwXmQclBKAiBQ_003D_003D(ToolBar _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D._0023_003Dzc3vkuqr_ddi7(_0023_003Dz1SmHC4c_003D.X, _0023_003Dz1SmHC4c_003D.Y);
		}
	}

	private sealed class _0023_003DzMO1WVpUW1GsdMI4kNx7bll4_003D
	{
		public object _0023_003DzZoEki8U_003D;

		public string _0023_003DzyTdq_VY_003D;

		internal void _0023_003Dzqxqz1RmCTBEelDYk2naRt3_0024a2zJZpYfcKHKfVb5Xk5Wb()
		{
			_0023_003DzZoEki8U_003D = Clipboard.GetData(_0023_003DzyTdq_VY_003D);
		}
	}

	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<ToolBarButton, bool> _0023_003DzEXZO_yKTxM_0024so0lX3A_003D_003D;

		public static Func<ToolBarButton, bool> _0023_003DzgBXv6kOvtKwNULKw5A_003D_003D;

		public static Func<Entity, double> _0023_003DzeVrciMXYGJBrBWFMqA_003D_003D;

		public static Func<Block, string> _0023_003DzfUwX_ShnbtQTc_2j9w_003D_003D;

		public static Func<Layer, bool> _0023_003Dz5xYekK9Xia83vclUbw_003D_003D;

		public static Func<Entity, bool> _0023_003Dz_002432dHQNYMvnoixlVLA_003D_003D;

		public static _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003Dz8Ipf4dsIKRI_0024_0024h4sdg_003D_003D;

		public static _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003DzhlMbUoXh71TPzutwSw_003D_003D;

		public static _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003DzL3y9gV1J2KvvuGOuLQ_003D_003D;

		public static _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003Dz_0024I8lpUasl8RhAQyHBA_003D_003D;

		public static _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003DzzSKT8ZlxIip28L2AUA_003D_003D;

		public static _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003DzBhZRJkfBgUwKKDAZ0Q_003D_003D;

		public static _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003DzopV7NGQhC2XosQ8jHw_003D_003D;

		public static Func<KeyValuePair<int, Delegate>, int> _0023_003DzbVfitGBKsu7pHZw15g_003D_003D;

		public static Func<WorkUnit, bool> _0023_003Dz_0024iv8ir_0024tCoOP4QOQgQ_003D_003D;

		public static IsInScreenDelegate _0023_003DznWXc00nh_8293a8WXQ_003D_003D;

		public static IsInScreenDelegate _0023_003DznWXc00nh_82lTWZc_0024A_003D_003D;

		public static IsInScreenDelegate _0023_003DzkEr7Xo2jnQ2AjqSJgw_003D_003D;

		internal bool _0023_003DzCEJW_wLMPi8siqW8w9Y4Ib4_003D(ToolBarButton _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D is StartToolBarButton;
		}

		internal bool _0023_003Dz2AcGlOHX7se2ZXxjWMSWRAQ_003D(ToolBarButton _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D is PauseToolBarButton;
		}

		internal double _0023_003Dz7RMggvK_4O2O_0024cayIkoHvST0L9F3(Entity _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.screenSize;
		}

		internal string _0023_003DzHGNFbeenNfY9gvsOy2IcpkC1C6K_0024(Block _0023_003Dz5PxKZP0_003D)
		{
			return _0023_003Dz5PxKZP0_003D.Name;
		}

		internal bool _0023_003DzFqvX6u2h0RW8ygxmZiZPKrimRNgx(Layer _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.isDirtyForFlattenTree;
		}

		internal bool _0023_003Dzt_17mly5sJ30mGcMdQlbCFezYqdj(Entity _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.isDirtyForFlattenTree;
		}

		internal void _0023_003DzL6K8geaJ1txf5D5yMv4RLXC49gDm(Entity _0023_003DztJCl_0024mM_003D)
		{
		}

		internal void _0023_003Dz9f2JXT9BS226LHd6ZgYI8pfjEWX3(Entity _0023_003DztJCl_0024mM_003D)
		{
			if (_0023_003DztJCl_0024mM_003D is CompositeCurve compositeCurve)
			{
				compositeCurve.ClearSubCurvesSelection(selectionStatusType.Permanent);
			}
		}

		internal void _0023_003DzOMcnEXls1moDF_MRF0raLp_0024fHd0J(Entity _0023_003DztJCl_0024mM_003D)
		{
			if (_0023_003DztJCl_0024mM_003D is devDept.Eyeshot.Entities.Region region)
			{
				region.ClearSubContoursSelection(selectionStatusType.Permanent);
			}
		}

		internal void _0023_003DzyIUW8vHv44CinxDd7eg9hxJrYBtd(Entity _0023_003DztJCl_0024mM_003D)
		{
			if (_0023_003DztJCl_0024mM_003D is SketchEntity sketchEntity)
			{
				sketchEntity.ClearSketchCurvesSelection(selectionStatusType.Permanent);
			}
		}

		internal void _0023_003Dzrgf9ease5i_0024uC7bljXH83WH3Rqvy(Entity _0023_003DztJCl_0024mM_003D)
		{
			_0023_003DztJCl_0024mM_003D.ClearSelectionFaces(selectionStatusType.Permanent);
		}

		internal void _0023_003DzL6K8geaJ1txf5D5yMv4RLXEVxUbF(Entity _0023_003DztJCl_0024mM_003D)
		{
			if (_0023_003DztJCl_0024mM_003D is Brep brep)
			{
				brep.ClearEdgesSelection(selectionStatusType.Permanent);
			}
		}

		internal void _0023_003DznajkouNRbAMfkaiE_30CeGs4dIse(Entity _0023_003DztJCl_0024mM_003D)
		{
			if (_0023_003DztJCl_0024mM_003D is Brep brep)
			{
				brep.ClearVerticesSelection(selectionStatusType.Permanent);
			}
		}

		internal int _0023_003Dzn_0024p6Nwx1b0Vsk7MhBVBRMtrpuS6h(KeyValuePair<int, Delegate> _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Key;
		}

		internal bool _0023_003DzTHFsRMLZiy3VLOLU8gbQZrc9V_KA(WorkUnit _0023_003DzgS2U5_c_003D)
		{
			return _0023_003DzgS2U5_c_003D == null;
		}

		internal bool _0023_003DzI6zalH_0024TiClwzYy60HkPHOrOOjb71J5L4A_003D_003D(Entity _0023_003DztJCl_0024mM_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024)
		{
			return ((IEntityInternal)_0023_003DztJCl_0024mM_003D).IsCrossing(_0023_003DzCBM7XJK4_5H_0024);
		}

		internal bool _0023_003DzD0jMW2gmXV_N6reOqHEW2zBWtAOFx_0024yfnQ_003D_003D(Entity _0023_003DztJCl_0024mM_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024)
		{
			return ((IEntityInternal)_0023_003DztJCl_0024mM_003D).IsCrossing(_0023_003DzCBM7XJK4_5H_0024);
		}

		internal bool _0023_003DzLNsvQqdBTrWoNZUySnLnfCNcbrkmCOzx_0024A_003D_003D(Entity _0023_003DztJCl_0024mM_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024)
		{
			return ((IEntityInternal)_0023_003DztJCl_0024mM_003D).AllVerticesInFrustum(_0023_003DzCBM7XJK4_5H_0024);
		}

		internal bool _0023_003Dz5PBor_En4HEIOfG5rxkC8LRa_HNu(PropertyInfo _0023_003DzHw7Dl0k_003D)
		{
			return _0023_003DzHw7Dl0k_003D.PropertyType == typeof(Cursor);
		}

		internal Cursor _0023_003Dz5PBor_En4HEIOfG5rxkC8NYHsejS(PropertyInfo _0023_003DzHw7Dl0k_003D)
		{
			return (Cursor)_0023_003DzHw7Dl0k_003D.GetValue(null);
		}
	}

	internal sealed class _0023_003DzVFaPvPVltPa6
	{
		internal bool _0023_003DzOTCykyo_003D;

		internal bool _0023_003DzZEj9ImBV_0024I0k;

		internal void _0023_003DzSbnsq6aGahYh(Workspace _0023_003DzU0f5_qE_003D, bool _0023_003DzSV3KedQ_003D)
		{
			if (!_0023_003DzU0f5_qE_003D.Moving && _0023_003DzSV3KedQ_003D && !_0023_003DzZEj9ImBV_0024I0k)
			{
				_0023_003DzU0f5_qE_003D._0023_003DzFqaEE7IhVORj(cursorType.Default);
			}
			else if (!_0023_003DzSV3KedQ_003D && _0023_003DzU0f5_qE_003D.ActionMode != actionType.None && _0023_003DzZEj9ImBV_0024I0k)
			{
				_0023_003DzU0f5_qE_003D._0023_003DzFqaEE7IhVORj(_0023_003DzU0f5_qE_003D._0023_003DzSeMqxa6Bcvxs());
			}
			_0023_003DzZEj9ImBV_0024I0k = _0023_003DzSV3KedQ_003D;
		}

		internal void _0023_003DzKGntWXtyylZx(Workspace _0023_003DzU0f5_qE_003D, bool _0023_003DzB0pGFo8_003D, out bool _0023_003DzcTbmALo_003D)
		{
			_0023_003DzcTbmALo_003D = _0023_003DzB0pGFo8_003D ^ _0023_003DzOTCykyo_003D;
			_0023_003DzOTCykyo_003D = _0023_003DzB0pGFo8_003D;
		}
	}

	private sealed class _0023_003Dz_TfVrsMySSfafaJ98dQk5Lg_003D
	{
		public Workspace _0023_003DzKdgtcDsi34jL;

		public _0023_003DzenckdRCXoIVHI3cZbQ_003D_003D _0023_003Dz5bKogamXkVLs;

		internal void _0023_003DzJpK3HgQ_0024WLYWAx5_0024LMkrfGU_003D()
		{
			_0023_003DzKdgtcDsi34jL._0023_003DzKDiCijSjQLjc.WaitOne();
			_0023_003DzKdgtcDsi34jL._0023_003DzKDiCijSjQLjc.Set();
			_0023_003Dz5bKogamXkVLs();
		}
	}

	private delegate void _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D(Entity _0023_003DztJCl_0024mM_003D);

	internal delegate void _0023_003DzenckdRCXoIVHI3cZbQ_003D_003D();

	private sealed class _0023_003DzeolFlXynhpfb
	{
		public actionType? _0023_003Dzq7xhhPo_003D;

		public CursorContainer? _0023_003DzsvHVwxEyCKRY;
	}

	internal enum _0023_003DzhFBmu_0024RpnRJ7
	{

	}

	private sealed class _0023_003DzkT8AkN0DJt3aFfHDxmWXoPc_003D
	{
		public string _0023_003DzyTdq_VY_003D;

		public object _0023_003Dzt5jpbHs_003D;

		internal void _0023_003DzLDGhoK0vtKJ2MRzE2yDubffqpmGcupP5mhCTcI8Afzks()
		{
			Clipboard.SetData(_0023_003DzyTdq_VY_003D, _0023_003Dzt5jpbHs_003D);
		}
	}

	internal enum _0023_003DzrWM_00242Vk_003D
	{

	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dzt1xpMMG5ey0bbtMXmJf_43Eb_0024s1J : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz0FVSO5LFyxyq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzFUVSvBsTIB9Y;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IReadOnlyList<WorkUnit> _0023_003DzHBrzSyG6F8Sb;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Workspace _0023_003DzKdgtcDsi34jL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Progress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzfbRw5MY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<Task> _0023_003DzC77gHuqbQnw2jIz6Ig_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003Dz9ZxzSZcDWPjZ;

		private void MoveNext()
		{
			int num = _0023_003Dz0FVSO5LFyxyq;
			Workspace CS_0024_003C_003E8__locals65 = _0023_003DzKdgtcDsi34jL;
			try
			{
				TaskAwaiter awaiter;
				switch (num)
				{
				default:
					if (_0023_003DzHBrzSyG6F8Sb == null)
					{
						throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591624));
					}
					if (_0023_003DzHBrzSyG6F8Sb.Count != 0)
					{
						if (_0023_003DzHBrzSyG6F8Sb.Any(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzTHFsRMLZiy3VLOLU8gbQZrc9V_KA))
						{
							throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591640), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591624));
						}
						awaiter = CS_0024_003C_003E8__locals65._0023_003Dz09M73mCmWmeK._0023_003DzyYuAQN8_003D().GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0023_003Dz0FVSO5LFyxyq = 0);
							_0023_003Dz9ZxzSZcDWPjZ = awaiter;
							_0023_003DzFUVSvBsTIB9Y.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00e9;
					}
					goto end_IL_000e;
				case 0:
					awaiter = _0023_003Dz9ZxzSZcDWPjZ;
					_0023_003Dz9ZxzSZcDWPjZ = default(TaskAwaiter);
					num = (_0023_003Dz0FVSO5LFyxyq = -1);
					goto IL_00e9;
				case 1:
					awaiter = _0023_003Dz9ZxzSZcDWPjZ;
					_0023_003Dz9ZxzSZcDWPjZ = default(TaskAwaiter);
					num = (_0023_003Dz0FVSO5LFyxyq = -1);
					goto IL_0154;
				case 2:
					break;
					IL_0154:
					awaiter.GetResult();
					if (CS_0024_003C_003E8__locals65.ProgressBar.Active)
					{
						CS_0024_003C_003E8__locals65.ProgressBar.previousVisibility = CS_0024_003C_003E8__locals65.ProgressBar.Visible;
						CS_0024_003C_003E8__locals65.ProgressBar.previousValue = CS_0024_003C_003E8__locals65.ProgressBar.Value;
						CS_0024_003C_003E8__locals65.ProgressBar.Visible = true;
					}
					CS_0024_003C_003E8__locals65.ProgressBar.Value = 0;
					CS_0024_003C_003E8__locals65.ProgressBar.Text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651338);
					CS_0024_003C_003E8__locals65._0023_003DzipBYly6zFKAp()._0023_003DzAmQmFnNJkaOUqpvwTQ_003D_003D().Buttons.Add(CS_0024_003C_003E8__locals65.ProgressBarCancelButton);
					if (_0023_003DzIIIDz8c_003D != null)
					{
						_0023_003DzIIIDz8c_003D.ProgressChanged += delegate(object _0023_003DzxwGby4M_003D, WorkUnit.ProgressChangedEventArgs _0023_003Dz1SmHC4c_003D)
						{
							CS_0024_003C_003E8__locals65._0023_003DzlJEZ_iZrKpueW96a_0024Q_003D_003D(_0023_003Dz1SmHC4c_003D);
						};
					}
					else
					{
						_0023_003DzIIIDz8c_003D = new Progress<WorkUnit.ProgressChangedEventArgs>(delegate(WorkUnit.ProgressChangedEventArgs _0023_003Dz1SmHC4c_003D)
						{
							Task _0023_003DzxIG92rhdr_0024Fd = CS_0024_003C_003E8__locals65._0023_003DzxIG92rhdr_0024Fd;
							if ((_0023_003DzxIG92rhdr_0024Fd != null && !_0023_003DzxIG92rhdr_0024Fd.IsCompleted) || _0023_003Dz1SmHC4c_003D.Progress == 100)
							{
								CancellationTokenSource _0023_003DzIZDfsMhRoEGn = CS_0024_003C_003E8__locals65._0023_003DzIZDfsMhRoEGn;
								if ((_0023_003DzIZDfsMhRoEGn == null || !_0023_003DzIZDfsMhRoEGn.IsCancellationRequested) && !CS_0024_003C_003E8__locals65.IsDisposed)
								{
									CS_0024_003C_003E8__locals65.ProgressBar.Value = _0023_003Dz1SmHC4c_003D.Progress;
									CS_0024_003C_003E8__locals65.ProgressBar.Text = _0023_003Dz1SmHC4c_003D.Text;
									if (CS_0024_003C_003E8__locals65.ProgressBar.Visible)
									{
										if (_0023_003Dz1SmHC4c_003D.Continuous)
										{
											CS_0024_003C_003E8__locals65.ProgressBar._0023_003Dzfhv6eFBtERoy();
										}
										else
										{
											CS_0024_003C_003E8__locals65.ProgressBar._0023_003DzwdY8uuMuAeqB();
											if (CS_0024_003C_003E8__locals65._0023_003DzR9WOThn15SZhpgA2FA_003D_003D)
											{
												return;
											}
											CS_0024_003C_003E8__locals65._0023_003DzR9WOThn15SZhpgA2FA_003D_003D = true;
											CS_0024_003C_003E8__locals65.BeginInvoke(new Action(CS_0024_003C_003E8__locals65._0023_003Dzzr00LSmTUMlMH8anYkB8CjaHk6Cw));
										}
									}
									CS_0024_003C_003E8__locals65.FireProgressChanged(_0023_003Dz1SmHC4c_003D);
								}
							}
						});
					}
					CS_0024_003C_003E8__locals65._0023_003DzIZDfsMhRoEGn = new CancellationTokenSource();
					_0023_003DzC77gHuqbQnw2jIz6Ig_003D_003D = new List<Task>(_0023_003DzHBrzSyG6F8Sb.Count);
					break;
					IL_00e9:
					awaiter.GetResult();
					CS_0024_003C_003E8__locals65._0023_003Dz09M73mCmWmeK._0023_003DzZjL15X8_003D();
					awaiter = CS_0024_003C_003E8__locals65._0023_003Dzpw8WxV_0024adNV7HAEnrA_003D_003D.WaitAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003Dz0FVSO5LFyxyq = 1);
						_0023_003Dz9ZxzSZcDWPjZ = awaiter;
						_0023_003DzFUVSvBsTIB9Y.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_0154;
				}
				try
				{
					if (num != 2)
					{
						if (CS_0024_003C_003E8__locals65._0023_003Dz09M73mCmWmeK._0023_003Dz7HticeW00qIl())
						{
							throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591695));
						}
						CS_0024_003C_003E8__locals65._0023_003DzwFKdhc8_003D = false;
						IEnumerator<WorkUnit> enumerator = _0023_003DzHBrzSyG6F8Sb.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								WorkUnit current = enumerator.Current;
								current.ResetProgress();
								if (current is WriteFile writeFile)
								{
									writeFile.PrepareEnvironmentData();
								}
								if (current is WriteFileAsync)
								{
									CS_0024_003C_003E8__locals65._0023_003DzwFKdhc8_003D = true;
								}
								current.Status = workUnitStatus.InProgress;
								_0023_003DzC77gHuqbQnw2jIz6Ig_003D_003D.Add(current.DoWorkAsync(_0023_003DzIIIDz8c_003D, CS_0024_003C_003E8__locals65._0023_003DzIZDfsMhRoEGn.Token));
							}
						}
						finally
						{
							if (num < 0)
							{
								enumerator?.Dispose();
							}
						}
						if (CS_0024_003C_003E8__locals65._0023_003DzKDiCijSjQLjc != null)
						{
							CS_0024_003C_003E8__locals65._0023_003DzKDiCijSjQLjc.Dispose();
							CS_0024_003C_003E8__locals65._0023_003DzKDiCijSjQLjc = null;
						}
						CS_0024_003C_003E8__locals65._0023_003DzKDiCijSjQLjc = new AutoResetEvent(!CS_0024_003C_003E8__locals65._0023_003DzwFKdhc8_003D);
						CS_0024_003C_003E8__locals65._0023_003DzxIG92rhdr_0024Fd = Task.WhenAll(_0023_003DzC77gHuqbQnw2jIz6Ig_003D_003D);
						awaiter = CS_0024_003C_003E8__locals65._0023_003DzxIG92rhdr_0024Fd.GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0023_003Dz0FVSO5LFyxyq = 2);
							_0023_003Dz9ZxzSZcDWPjZ = awaiter;
							_0023_003DzFUVSvBsTIB9Y.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						awaiter = _0023_003Dz9ZxzSZcDWPjZ;
						_0023_003Dz9ZxzSZcDWPjZ = default(TaskAwaiter);
						num = (_0023_003Dz0FVSO5LFyxyq = -1);
					}
					awaiter.GetResult();
				}
				finally
				{
					if (num < 0)
					{
						try
						{
							CS_0024_003C_003E8__locals65._0023_003DzKDiCijSjQLjc?.Set();
							CS_0024_003C_003E8__locals65._0023_003DzKDiCijSjQLjc?.Dispose();
							CS_0024_003C_003E8__locals65._0023_003DzKDiCijSjQLjc = null;
							_0023_003DzIIIDz8c_003D.ProgressChanged -= delegate(object _0023_003DzxwGby4M_003D, WorkUnit.ProgressChangedEventArgs _0023_003Dz1SmHC4c_003D)
							{
								CS_0024_003C_003E8__locals65._0023_003DzlJEZ_iZrKpueW96a_0024Q_003D_003D(_0023_003Dz1SmHC4c_003D);
							};
							CS_0024_003C_003E8__locals65._0023_003DzIZDfsMhRoEGn?.Dispose();
							CS_0024_003C_003E8__locals65._0023_003DzIZDfsMhRoEGn = null;
							CS_0024_003C_003E8__locals65._0023_003DzxIG92rhdr_0024Fd = null;
						}
						catch
						{
						}
						CS_0024_003C_003E8__locals65._0023_003DzipBYly6zFKAp()._0023_003Dz_0024vGIP8ipyEwE();
						CS_0024_003C_003E8__locals65.ProgressBar?._0023_003Dze5O5R4s_003D(CS_0024_003C_003E8__locals65);
						if (CS_0024_003C_003E8__locals65.ProgressBarCancelButton != null)
						{
							CS_0024_003C_003E8__locals65.ProgressBarCancelButton._0023_003Dzbb_0024Bito_003D((ToolBarButton._0023_003DzJrgugJM_003D)0);
						}
						for (int num2 = 0; num2 < _0023_003DzC77gHuqbQnw2jIz6Ig_003D_003D.Count; num2++)
						{
							Task task = _0023_003DzC77gHuqbQnw2jIz6Ig_003D_003D[num2];
							WorkUnit workUnit = _0023_003DzHBrzSyG6F8Sb[num2];
							switch (task.Status)
							{
							case TaskStatus.Faulted:
								workUnit.Status = workUnitStatus.Failed;
								workUnit.WorkFailed(CS_0024_003C_003E8__locals65);
								if (_0023_003DzfbRw5MY_003D)
								{
									CS_0024_003C_003E8__locals65.FireWorkFailed(new WorkFailedEventArgs(workUnit, task.Exception));
								}
								break;
							case TaskStatus.Canceled:
								workUnit.Status = workUnitStatus.Cancelled;
								CS_0024_003C_003E8__locals65._0023_003Dz09M73mCmWmeK._0023_003DzAiYx9eY_003D();
								workUnit.WorkCancelled(CS_0024_003C_003E8__locals65);
								if (_0023_003DzfbRw5MY_003D)
								{
									CS_0024_003C_003E8__locals65.FireWorkCancelled(new WorkUnitEventArgs(workUnit));
								}
								CS_0024_003C_003E8__locals65._0023_003Dz09M73mCmWmeK._0023_003DzAiYx9eY_003D();
								break;
							case TaskStatus.RanToCompletion:
								workUnit.Status = workUnitStatus.Completed;
								workUnit.WorkCompleted(CS_0024_003C_003E8__locals65);
								if (_0023_003DzfbRw5MY_003D)
								{
									CS_0024_003C_003E8__locals65.FireProgressChanged(new WorkUnit.ProgressChangedEventArgs(100));
									CS_0024_003C_003E8__locals65.FireWorkCompleted(new WorkCompletedEventArgs(workUnit));
								}
								break;
							default:
								throw new ArgumentOutOfRangeException();
							}
						}
						if (!CS_0024_003C_003E8__locals65._0023_003DzhuKRYpQ_003D)
						{
							CS_0024_003C_003E8__locals65._0023_003DzQtM_y9yLRR_0024E();
						}
						CS_0024_003C_003E8__locals65._0023_003DzwFKdhc8_003D = false;
						CS_0024_003C_003E8__locals65._0023_003Dz09M73mCmWmeK._0023_003DzVOCJm_s_003D();
						CS_0024_003C_003E8__locals65._0023_003Dzpw8WxV_0024adNV7HAEnrA_003D_003D.Release();
					}
				}
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_0023_003Dz0FVSO5LFyxyq = -2;
				_0023_003DzC77gHuqbQnw2jIz6Ig_003D_003D = null;
				_0023_003DzFUVSvBsTIB9Y.SetException(exception);
				return;
			}
			_0023_003Dz0FVSO5LFyxyq = -2;
			_0023_003DzC77gHuqbQnw2jIz6Ig_003D_003D = null;
			_0023_003DzFUVSvBsTIB9Y.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			_0023_003DzFUVSvBsTIB9Y.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}
	}

	private enum _0023_003DztncgnbDImno0zX_0024VBw_003D_003D
	{

	}

	private sealed class _0023_003Dzz3zjS5dB4WS61l9T16pDn9c_003D
	{
		public Workspace _0023_003DzKdgtcDsi34jL;

		public Viewport _0023_003DzwXzrcF_0024vKNIp;

		internal double _0023_003DzTGvN1OcWOUSKdVfmi0ejDYE_003D(Entity _0023_003Dz8GBMuoM_003D)
		{
			if (_0023_003DzKdgtcDsi34jL._0023_003DzmP7qOAA_003D(_0023_003Dz8GBMuoM_003D, _0023_003DzwXzrcF_0024vKNIp))
			{
				return _0023_003Dz8GBMuoM_003D.screenSize;
			}
			return -1.0 / (_0023_003Dz8GBMuoM_003D.screenSize + 1.0);
		}
	}

	public delegate void BoundingBoxChangedHandler(object sender);

	public delegate void CameraMoveEventHandler(object sender, CameraMoveEventArgs e);

	[Serializable]
	internal sealed class CurrentBlockRefData : IDisposable
	{
		public int EntityIndex;

		public ParentBlockReference ParentSceneBlockReference;

		public BlockReference BlockReference;

		public CurrentBlockRefData(int _0023_003DztpqrR80_003D, BlockReference _0023_003DzapzvrQOpXNya, ParentBlockReference _0023_003Dzpca72W8crq_0024e)
		{
			EntityIndex = _0023_003DztpqrR80_003D;
			ParentSceneBlockReference = _0023_003Dzpca72W8crq_0024e;
			BlockReference = _0023_003DzapzvrQOpXNya;
		}

		public void Dispose()
		{
			ParentSceneBlockReference.Dispose();
		}
	}

	public struct CursorContainer(Cursor cursor) : ICursorContainer
	{
		public Cursor Cursor = cursor;
	}

	public delegate void DesignTimeFuncHandler();

	public delegate void ErrorEventHandler(object sender, ErrorOccurredEventArgs args);

	public class ErrorOccurredEventArgs : EventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003DzkqAHVKE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003DzcrAFMXve5yzR;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object _0023_003Dz85Rdnyr6bE4c;

		public string Message => _0023_003DzkqAHVKE_003D;

		public string StackTrace => _0023_003DzcrAFMXve5yzR;

		public object ObjectNotCompiled => _0023_003Dz85Rdnyr6bE4c;

		public ErrorOccurredEventArgs(string message, string stackTrace, EntityGraphicsData graphicsDataWithError)
		{
			_0023_003DzkqAHVKE_003D = message;
			_0023_003DzcrAFMXve5yzR = stackTrace;
			if (graphicsDataWithError != null)
			{
				_0023_003Dz85Rdnyr6bE4c = graphicsDataWithError.Parent;
			}
		}
	}

	public delegate void NavigationTimerHandler(object sender, EventArgs e);

	[Serializable]
	internal sealed class OpenBlockData : IDisposable
	{
		public Block Block;

		public Stack<CurrentBlockRefData> CurrentBlockReferencesData;

		public Camera Camera;

		public OpenBlockData(Block _0023_003DzYsabNug_003D)
		{
			Block = _0023_003DzYsabNug_003D;
			CurrentBlockReferencesData = new Stack<CurrentBlockRefData>();
		}

		public void Dispose()
		{
			Camera?.Dispose();
		}
	}

	public delegate void SelectionChangedEventHandler(object sender, SelectionChangedEventArgs e);

	public class ViewChangedEventArgs : HandledEventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private viewType _0023_003DztkQAt45oOULq;

		public viewType ViewType => _0023_003DztkQAt45oOULq;

		public ViewChangedEventArgs(viewType viewType)
		{
			_0023_003DztkQAt45oOULq = viewType;
		}
	}

	public delegate void ViewChangedEventHandler(object sender, ViewChangedEventArgs e);

	public enum assemblySelectionType
	{
		Branch,
		Leaf
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal mouseInputType _0023_003DzBrC4gBvWiHkA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mouse3DSettings _0023_003Dz1hAz1Qd_0024QjMi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzKB5gbX19s0qVrqQGn2o1kUz_00248j1a2nwQKLng_0024XlHe8Ka _0023_003Dzt56IHQQCjMVX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzR6vCqD_0024QocNK418oYWXyu3JzuZ5R8zQlvlaPbTMC3LOOzvro_Q_003D_003D _0023_003Dzpm_00240_u0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ButtonEventHandler _0023_003DztOrlz_zSFCUN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ButtonEventHandler _0023_003Dz0sL73kYUF3eZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MoveEventHandler _0023_003DzNlD1nBz7pQOD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DzVPcNyaBcNDGL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DzKk1DQUn5co_aN4nO4w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DziwPFZD5quyJUARrhpw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DzM_0024RAWGUwy2M6VoDO8g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DzR3te2ECclIvgC98aKjRl1l0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DzFGQmQXKrdjacAiDvFmESkVg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DzqZgiEmb_0024ukpITsN00Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DzF_0024lPCjNBq_z_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripMenuItem _0023_003DzoyItBUrB_0024Vm2yfULwZ0OnBU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolStripItem _0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MultiTouchSettings _0023_003DzYeK2UkCOUbSi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MultiTouchEventHandler _0023_003Dz_0024DKbcuTzjqgK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MultiTouchEventHandler _0023_003Dz_0024inpPjY5h8Jv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MultiTouchEventHandler _0023_003DzoU40Uhh8GTY7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MouseEventHandler _0023_003DzlOvHZEswzSlhuG2jJA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MouseEventHandler _0023_003Dzl1meGtYJNgTP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Document _0023_003DzgfObf7s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DqqSQMR5x0Ss3kUZAkPHTc7hFiG_0024Jx_u6scrhI1QMq7n8_003D _0023_003DzNz_00241Di_amPH5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzQio9vBoBmpUn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzrW6VnBSrG94Y;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz1Ft0yE9Vfrre;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BoundingBoxChangedHandler _0023_003DzOf9Dg_0024c_0024lV_b;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal System.Threading.Timer _0023_003Dz2oXHlo_oZcH3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal IList<Workspace> _0023_003Dzjd7sfj8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ControlData _0023_003DzjC4hA2I_003D = new ControlData();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TempEntityList _0023_003DzEokQrxGBxa1zmznUP6fxb5M_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal BlockKeyedCollection _0023_003DzOA_ac7k_003D = new BlockKeyedCollection(StringComparer.CurrentCultureIgnoreCase);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003Dzg1bzF4l6WKmFDgVSI2C7zfc_003D = new BlockKeyedCollection(StringComparer.CurrentCultureIgnoreCase);

	protected internal bool hasFocus;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzPzGbYk87yMq4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal TextureBase _0023_003DzeDju_XcuxmQA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Bitmap _0023_003DzULRQbgUy6_UYTYuzmpW4oeQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Camera.CameraSharedData _0023_003DzB63nHjW2QzvePp6sgQ_003D_003D = new Camera.CameraSharedData();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzpPO_0024ueTQnaMfLNsISQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003Dzgg0qV0T_00248ave;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected bool _0023_003DzoJ3C7DgwDQct;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzJ4jbvfHrmEXJhAZd3A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly HashSet<Cursor> _0023_003DzSslJtjQ1hZUF = new HashSet<Cursor>(typeof(Cursors).GetProperties(BindingFlags.Static | BindingFlags.Public).Where(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dz5PBor_En4HEIOfG5rxkC8LRa_HNu).Select(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dz5PBor_En4HEIOfG5rxkC8NYHsejS));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzhuKRYpQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzYes3sySVPIBmD955lA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzPzENGX5glhG5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzkD7lKgTh2VSZ4ZBEVOeA7jnO8Hqh0756_0024NKupiU_003D _0023_003Dz32fCUXg4rkVM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Bitmap _0023_003DzO_o8M3HUNFVt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Bitmap _0023_003DzPHIgywQ0bPFl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Bitmap _0023_003DzBlHCDVjJXeoG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Bitmap _0023_003DzkP4DGwYcuX5B;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Bitmap _0023_003DzAekJM0ZtENTE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private viewportLayoutType _0023_003Dz7Ms6XWE0v6md;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzfNVPZ4kzXmPE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal IEnvironment _0023_003DziuvwBNA4duWb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureMosaic _0023_003DzqurM61XyL6Tc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureMosaic _0023_003DzX9dkQU3xfVkG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureMosaic _0023_003DzytRMTWr9k5Ww;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureMosaic _0023_003Dz7foQIumD31m4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzkQRTXiC03yes;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Bitmap _0023_003DzJo5ZCERKuRzT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzry2RTIVdTZ_0024a;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzyYEVfLG1UTpY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string _0023_003Dzuxh58hoEevp2 = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591743);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ErrorEventHandler _0023_003DzDwjKS14_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal System.Threading.Timer _0023_003Dz3ihdp7ALIDhJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stopwatch _0023_003DzCFLw5qY2msbr = new Stopwatch();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dz9cE_0024NqT_0024ydA62IzRLrv73lQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzhfwTtuYclW899eUCjQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DznbDxlZQRhlsy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzvTDEkOkzrzzDeY533g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz6ZdNJusMMW74ZnfJfAbKQ7s_003D = 4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz3FsDfgH0CqdJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzeolFlXynhpfb _0023_003Dznl6vpID_7KEeHuMw7Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzlNGYbbA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SelectionBoxColorsSettings _0023_003Dz_0024whV8aqe6EBc = new SelectionBoxColorsSettings();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzugsxb4RJNAy0QfWTxQ_003D_003D = 0.5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MagnifyingGlassSettings _0023_003DzKELvTsdDA0_SVsFGiPE9tw6eMldU = new MagnifyingGlassSettings();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal TextureBase _0023_003DzxljNCVjBWQzg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IContainer _0023_003DzP5yJ9F4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RunWorkerCompletedEventHandler _0023_003Dzeb2bt49UPa4s;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DoWorkEventHandler _0023_003DzlS8Xxx2wBGJU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProgressChangedEventHandler _0023_003DzEy59KvD6CURO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool _0023_003DzRJdPG6IsPQ8aynwPuw_003D_003D = false;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzZ5L0bhmvC_0024K7 = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzEve6E9qqZPdg = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzFPtvCJM5exDj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz3cqGIkKFSLfbvz879SlfmFY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera _0023_003DzClCMdT3GjxD8PGpNmg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzZw_0024Euke_eh4K = 1000.0 / (double)_0023_003Dzg5Xj0dn9LsZAo_0024aLAJV5nOo_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Stopwatch _0023_003DzI5CJrSxma7iW = new Stopwatch();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Queue<double> _0023_003Dzu7PXbXKLQ0bz = new Queue<double>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzK3q17lOufT1wWnFgbQ_003D_003D = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzCJwP4KyhW2w0pUgULQ_003D_003D;

	protected bool femMeshAnimation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLBAsomUMXlxUzJkZ4ZWyhKLTzXmX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzSUr1lsalFeN1rfXyxw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzK3IgbzPkGgv8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzo_MNAFBAjuGu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private rasterizerStateType _0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzYtqGTMwg_0024Ufr8epgUBxoDPPd_0024XV2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dz_EkZHS2QnMod;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private shaderType _0023_003Dz_0024m0wHyJzdT4E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera _0023_003DzfezfUQ0tGsKVNHMGYnGc3ts_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D _0023_003DziAi88RJXLkKjE48KAg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzY3jw47Lr_syJWDckOg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzioJIQ5Bufb8i;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzQxvqEU4Hk7eQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzOjXO_0024o07AbMN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzByaaFU6UbrUJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dz1XGlB9JqXOr1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private shaderType _0023_003DzxYKjPsMqweAzSfdh_0024g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextureMosaic _0023_003DzUnT21F0UWD2IlVwatg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObjectManipulator _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzQ4jfjaYMr4qjuwCmiw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal BlockReference _0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzRwMrM8lh4Uvo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz6oXjiBbfuRAlBSZl9Fg_0024I_v3AiUA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003DzNcd94uIe40G1;

	protected const string ROOT_SCENE_PREFIX = "Root Scene";

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Stack<OpenBlockData> _0023_003DzzFGpNZit9CtK = new Stack<OpenBlockData>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IReadOnlyCollection<string> _0023_003DzjczFwk1Qrlg9QkeecQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Tuple<Stack<BlockReference>, Entity>[] _0023_003DzomkzA6ARKGCOzn9ijw_003D_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D _0023_003DzSGUVLSk_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003DzdGHIIU4_003D _0023_003DzpW717vDE_JTBaH23pw_003D_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003DzdGHIIU4_003D _0023_003Dzc6W_0024QvlNhBTR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<Entity> _0023_003DzfRVkvW62UnE5fk7N_g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<Entity> _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzPy_UVJqNuye0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal GfxAttributesWire _0023_003DzXr8srg0YPbd8c1LuCBXqlpg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ISelectionSettings _0023_003DzPWJyZlc_003D;

	protected ShortcutKeysSettings shortcutKeys;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzSpehFdn_0024OOBr2rJb7A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0h9vskpSVtRx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Threading.Timer _0023_003Dz_0024tXP7SA143kl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private NavigationTimerHandler _0023_003DzFBmlAVlkXQOb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzHPlVDFvTViEi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<cursorType, Cursor> _0023_003DzJL_00244gFMrjFADCm20e5BPNf0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzjWLowQN0uWZO = 8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Drawing.Point _0023_003DzjRmmVH2Hj_0024KY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Drawing.Point _0023_003Dztt6EItoclqV3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Drawing.Point _0023_003DzXGtRhbJXvcvk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private actionType _0023_003DzjGvm17_0024DzsnS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Stack<actionType> _0023_003DzMf9dmdyhF1ZW = new Stack<actionType>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzgQM_G8SJDLUO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private assemblySelectionType _0023_003DzCBASci_Gpxb1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Stack<BlockReference> _0023_003Dzkm9D6jYtZW1j;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private selectionFilterType _0023_003Dzfk9mqRZJav3i = selectionFilterType.Entity;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Cursor _0023_003Dz2F9_0024pE8Z_0024_002426 = Cursors.Default;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz4urXwVzmTQSX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private actionType _0023_003Dz1AtQxyQVwP3J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal actionType _0023_003Dz8jvVhZY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal actionType _0023_003DzPWir8SCUhlRqvNwZxA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private actionType _0023_003DzB7HKRwpDgejt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzCpv3RVLsUYJ9 _0023_003DznNgMufc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzPPWf23dA_0024OGK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SelectionChangedEventArgs _0023_003DznmpiQBcqK9AE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzNSB0vGy6M4wYO1acTQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DztdGp9MI3CH2w;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dzz2f3UQo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CameraMoveEventHandler _0023_003Dz4QCZfUcWn12C;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CameraMoveEventHandler _0023_003DzLi0Sdf3SlhGQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CameraMoveEventHandler _0023_003DzFqDpQW4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003DzhDYcRHMzGMdJMDZoNA_003D_003D = 100;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal System.Timers.Timer _0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzFKfBt_CG51tvOLuykA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dzkxa5rh7IEj_gGwqk6w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzb9tWFl97201l;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private System.Windows.Forms.Timer _0023_003DzFzzfWzVQfgnR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzsNY3baF_0024GM7MtcGwGAB4MSE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzKmjkuSZXr8_0024Rl_zzrXMbKJa7ooH82Q9K5A_003D_003D _0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D = new _0023_003DzKmjkuSZXr8_0024Rl_zzrXMbKJa7ooH82Q9K5A_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzgowXYVJqM2Vg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ViewportList _0023_003DzbesAu90NcF8KFeewpw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzO9NcOvRo2Yyn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DesignTimeFuncHandler _0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DesignTimeFuncHandler _0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzE7xpH20_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected bool _0023_003Dz8ok_dRe4bjRDcVb_0024afNnmr8_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal BoundingBoxSettings _0023_003Dz6CMmzY6fHGlL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ButtonSettings _0023_003DzMC9Ycx3kKvGA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzTmVXuIf7B_f_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal LightSettings[] _0023_003DzMuApP021PUyU = new LightSettings[8]
	{
		_0023_003Dz7NpJnabG16hc(),
		_0023_003Dz__OrNlvkiVf_0024(),
		_0023_003DzeVWRUBuT_00244su(),
		_0023_003DzGAvKLzvtgdSE(),
		_0023_003DzvlMrltGUGwqD(),
		_0023_003DzxLBZtGeVsnzR(),
		_0023_003Dzy9a2gvNR_0024L5N(),
		_0023_003DzzcdYAd1MAULe()
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Color _0023_003DzXVJ6CvJJYmrqf3ztQQ_003D_003D = Color.FromArgb(50, 50, 50);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzhxZwygT5_0024eSRWpPtOWHuTPM_003D = _0023_003Dz5FN_jliv6I7mvmLmSUzqQ98Ojt_00240();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003Dz1en4hYuH_0024KDC2BdK0g_003D_003D = 0.2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ClippingPlaneBase[] _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D = new ClippingPlane[6]
	{
		new ClippingPlane(),
		new ClippingPlane(),
		new ClippingPlane(),
		new ClippingPlane(),
		new ClippingPlane(),
		new ClippingPlane()
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003Dz1Lr0Ynbqoix0dOscsAeIcqK9qcys _0023_003DzgpecnOZK_rLDYEjHUA_003D_003D = new _0023_003Dz1Lr0Ynbqoix0dOscsAeIcqK9qcys();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BorderSettings _0023_003DzE61nM_aOZBgx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal BackfaceSettings _0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D = new BackfaceSettings();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AmbientOcclusionSettings _0023_003Dztlc4_vYMmHwMNn1eUs_lO_Tk1pwt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal SelectionSettings _0023_003DzQqplHwiu62CW = new SelectionSettings();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal DisplayModeSettings _0023_003DzsliWYheSU0DTuUNAYg_003D_003D = _0023_003DzE86ntJk_bvntbeCPgA_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal DisplayModeSettingsShaded _0023_003DzEfebv86OlSaQUw9POQ_003D_003D = _0023_003DzSWtY5yxqfuBh8s2w07KB3SI_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal DisplayModeSettingsFlat _0023_003Dzl8PjArmAqC_m = _0023_003DzNmcCUKQZrt_0024ZBKfmbQ_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal DisplayModeSettingsRendered _0023_003DzB_4avBudAWM2 = _0023_003DztuL3fSvrLHESbtlEgQ_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal orientationType _0023_003DzLpjRly40lvq1 = orientationType.UpAxisZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzMdZJFmWObL0F;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal float _0023_003DzQmbl9PzBp44d = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal waitCursorType _0023_003DzCf__tCZh1QRt = waitCursorType.RegenAndBoundingBox;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz3W9juyTOSqQmu_1zL6wSiTo_003D = _0023_003Dzg5Xj0dn9LsZAo_0024aLAJV5nOo_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzU6UgNDFo2ST8 = _0023_003Dzzyw4qcFvt7djMFj7Aw_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera.perspectiveFitType _0023_003Dzf5Odjtzb03wW_0024l1D0A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal HiddenLinesSettings _0023_003Dzddm_0024rF6S_0024y27 = _0023_003Dz6pySpQ7YNYytZ7KDm_0024lng_s_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProgressBar _0023_003DzD157GIliOpnX = new ProgressBar();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolBarButton _0023_003DzwsiNROJDQzj_upG53A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SimulationTimeLine _0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzwMU34Oc0NLb_3_0024j4Jg_003D_003D;

	protected float fps;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzPZw2_0024thQNusZq2_00247Sw_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Type _0023_003Dzpg1eSrVpbJEmyn4WvPu_xf0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string _0023_003DzQh7EGBSrMCoK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string _0023_003DzmUn4ilUi_0024CDZqOJaQQ_003D_003D;

	public Dictionary<shaderType, IShaderTechnique> StandardShaders;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzd6z_6vE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CancellationTokenSource _0023_003DzIZDfsMhRoEGn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Task _0023_003DzxIG92rhdr_0024Fd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_Z7KNTKMA06dbr_pHg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003Dz8_00241rV1A_003D _0023_003Dz09M73mCmWmeK = new _0023_003Dz8_00241rV1A_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly SemaphoreSlim _0023_003Dzpw8WxV_0024adNV7HAEnrA_003D_003D = new SemaphoreSlim(1, 1);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AutoResetEvent _0023_003DzKDiCijSjQLjc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzR9WOThn15SZhpgA2FA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WorkUnit.WorkCompletedEventHandler _0023_003Dz0T1Zdz9fIp9t;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WorkUnit.WorkCancelledEventHandler _0023_003Dz106nlntdESk5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WorkUnit.WorkFailedEventHandler _0023_003DzB6s4ltXuApFM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WorkUnit.ProgressChangedEventHandler _0023_003DzJKwcJ2U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzE8RAOjfuSQcK = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _0023_003DzIdtz_FH5YEwn = new object();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal int _0023_003Dz11GAUsevhJJJ = 1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzfrZS1vKuIMTc = 100;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzadGKi_0024sgvFBr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ViewChangedEventHandler _0023_003Dz0pCfd9s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SelectionChangedEventHandler _0023_003DzYVdraYc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0tc02EiRYcVMdJTaZKYfaoo_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzHCo_FUpekslZ_O5CLQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzIQzMdMmuW0nMhvEIaa5o_0024QI_003D = 300;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzWepENTTgbYlseBo8TKkrcv8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SelectedItem _0023_003DzlA0QuPF2P1Np;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzKNo6tLg_003D _0023_003DzbdLgm9c_003D;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Mouse3DSettings Mouse3D
	{
		get
		{
			if (_0023_003Dz1hAz1Qd_0024QjMi == null)
			{
				ResetMouse3D();
			}
			return _0023_003Dz1hAz1Qd_0024QjMi;
		}
		set
		{
			_0023_003Dz1hAz1Qd_0024QjMi = value;
			_0023_003Dz1hAz1Qd_0024QjMi._0023_003DzzGq7V_q1ZaaU(this);
		}
	}

	[Category("Workspace - Input Devices")]
	[Description("Multitouch settings.")]
	public MultiTouchSettings MultiTouch
	{
		get
		{
			return _0023_003DzYeK2UkCOUbSi;
		}
		set
		{
			_0023_003DzYeK2UkCOUbSi = value;
			_0023_003DzYeK2UkCOUbSi.Parent = this;
		}
	}

	public Document Document => _0023_003DzgfObf7s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal IntPtr _0023_003DzZUohT3Y_003D
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.controlHandle;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.controlHandle = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsHardwareAccelerated => _0023_003DzjC4hA2I_003D.isHardwareAccelerated;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsAntiAliasingAvailable => _0023_003DzjC4hA2I_003D.isFsaaAvailable;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("With the adoption of OpenGL 3.3, a HW accelerated context is always requested. A non accelerated one is tried as a fallback. This property will be actively ignored.")]
	public bool ForceHardwareAcceleration
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.ForceHardwareAcceleration;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.ForceHardwareAcceleration = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsBestAdapterAvailable => _0023_003DzjC4hA2I_003D.IsBestAdapterAvailable;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public EntityList Entities => Document.Entities;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TempEntityList TempEntities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEokQrxGBxa1zmznUP6fxb5M_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzEokQrxGBxa1zmznUP6fxb5M_003D = value;
		}
	}

	IList<Entity> IWorkspace.TempEntities => TempEntities;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public BlockKeyedCollection Blocks
	{
		get
		{
			return _0023_003DzgfObf7s_003D.Blocks;
		}
		set
		{
			_0023_003DzgfObf7s_003D.Blocks = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Block RootBlock => Document.RootBlock;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal BlockKeyedCollection _0023_003DznJLjYKflIJCP
	{
		get
		{
			return _0023_003Dzg1bzF4l6WKmFDgVSI2C7zfc_003D;
		}
		set
		{
			_0023_003Dzg1bzF4l6WKmFDgVSI2C7zfc_003D = value;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal MaterialKeyedCollection _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D
	{
		get
		{
			return _0023_003DzgfObf7s_003D.Materials;
		}
		set
		{
			_0023_003DzgfObf7s_003D.Materials = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public LayerKeyedCollection Layers
	{
		get
		{
			return _0023_003DzgfObf7s_003D.Layers;
		}
		set
		{
			_0023_003DzgfObf7s_003D.Layers = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public LineTypeKeyedCollection LineTypes
	{
		get
		{
			return _0023_003DzgfObf7s_003D.LineTypes;
		}
		set
		{
			_0023_003DzgfObf7s_003D.LineTypes = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public float LineTypeScale
	{
		get
		{
			return _0023_003DzgfObf7s_003D.LineTypeScale;
		}
		set
		{
			_0023_003DzgfObf7s_003D.LineTypeScale = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public HatchPatternKeyedCollection HatchPatterns
	{
		get
		{
			return _0023_003DzgfObf7s_003D.HatchPatterns;
		}
		set
		{
			_0023_003DzgfObf7s_003D.HatchPatterns = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TextStyleKeyedCollection TextStyles
	{
		get
		{
			return _0023_003DzgfObf7s_003D.TextStyles;
		}
		set
		{
			_0023_003DzgfObf7s_003D.TextStyles = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Bitmap OriginTextureOverride
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzULRQbgUy6_UYTYuzmpW4oeQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzULRQbgUy6_UYTYuzmpW4oeQ_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string InstanceId
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpPO_0024ueTQnaMfLNsISQ_003D_003D;
		}
		private set
		{
			_0023_003DzpPO_0024ueTQnaMfLNsISQ_003D_003D = value;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal virtual viewportLayoutType _0023_003DzAyrAfQurY_bE
	{
		get
		{
			return _0023_003Dz7Ms6XWE0v6md;
		}
		set
		{
			if (_0023_003DzfNVPZ4kzXmPE || _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
			{
				return;
			}
			_0023_003DzfNVPZ4kzXmPE = true;
			if (!_0023_003DzlNGYbbA_003D && !_0023_003DzYBRkt7OvpTz_0024(value))
			{
				value = _0023_003DzK9iHR98l0rNuEjAV4A_003D_003D();
			}
			bool flag = _0023_003Dz7Ms6XWE0v6md != value;
			_0023_003Dz7Ms6XWE0v6md = value;
			if (_0023_003DzBn2ByFKdwrou >= _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count)
			{
				_0023_003DzBn2ByFKdwrou = 0;
			}
			ProgressBar._0023_003DzVRx5720_003D();
			if (base.IsHandleCreated)
			{
				_0023_003DzxMjXttTc5JNkWQh7J4z9LEwPvett();
				if (flag)
				{
					CompileUserInterfaceElements();
				}
				ProgressBar._0023_003Dz_WlOvqR1pka_();
			}
			if (IsDesignMode() && !_0023_003Dz9cE_0024NqT_0024ydA62IzRLrv73lQ_003D)
			{
				UpdateDesignModeScene();
				Invalidate();
			}
			_0023_003DzfNVPZ4kzXmPE = false;
		}
	}

	[Description("Affects the font of the fps string.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			base.Font = value;
			_0023_003Dzk6IQMQQ_003D(this);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal bool _0023_003Dz_0024zgVvF4OlegG
	{
		get
		{
			return _0023_003Dzry2RTIVdTZ_0024a;
		}
		set
		{
			_0023_003Dzry2RTIVdTZ_0024a = value;
			if (_0023_003Dzry2RTIVdTZ_0024a)
			{
				UpdateDesignModeScene();
				Refresh();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ErrorInPaint => _0023_003DzjC4hA2I_003D.errorInPaint;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal int _0023_003DzIoLIfRTMnbedgBTKjQ_003D_003D
	{
		get
		{
			return _0023_003Dz6ZdNJusMMW74ZnfJfAbKQ7s_003D;
		}
		set
		{
			_0023_003Dz6ZdNJusMMW74ZnfJfAbKQ7s_003D = value;
			if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 1)
			{
				_0023_003DzxMjXttTc5JNkWQh7J4z9LEwPvett();
				_0023_003Dz3tGL3rg_003D();
			}
		}
	}

	[Category("Workspace - Selection")]
	[Description("The colors used to draw the selection box and polygon.")]
	public SelectionBoxColorsSettings SelectionBoxColors
	{
		get
		{
			return _0023_003Dz_0024whV8aqe6EBc;
		}
		set
		{
			_0023_003Dz_0024whV8aqe6EBc = value;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal double _0023_003DzXTX6Wl_tlLz9
	{
		get
		{
			return _0023_003Dzugsxb4RJNAy0QfWTxQ_003D_003D;
		}
		set
		{
			if (value == _0023_003Dzugsxb4RJNAy0QfWTxQ_003D_003D)
			{
				return;
			}
			_0023_003Dzugsxb4RJNAy0QfWTxQ_003D_003D = value;
			_0023_003DzOKUxuj_0024UjDI7jXhG65BUZjE_003D(_0023_003DzOWfUZLjOSimJ());
			foreach (Block item in _0023_003DzoE3BE__0024RS_DJ())
			{
				_0023_003DzOKUxuj_0024UjDI7jXhG65BUZjE_003D(item.Entities);
			}
		}
	}

	[Category("Workspace")]
	[Description("The colors used to draw the selection box and polygon.")]
	public MagnifyingGlassSettings MagnifyingGlass
	{
		get
		{
			return _0023_003DzKELvTsdDA0_SVsFGiPE9tw6eMldU;
		}
		set
		{
			_0023_003DzKELvTsdDA0_SVsFGiPE9tw6eMldU = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool UseFrameBufferObject
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.useFrameBufferObject;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.useFrameBufferObject = value;
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003DzmNZD0Zs_003D.MakeCurrent();
				_0023_003DzmNZD0Zs_003D.ClearShadowMaps();
				_0023_003DzMdFyO9PwRqDMVPMCbFQlj5s_003D();
				_0023_003DzJX61e5MEGtgu();
			}
		}
	}

	[Description("Gets or sets the AttributeReferences visibility mode.")]
	[Category("Workspace")]
	public attributeReferenceVisibilityType AttributeReferenceVisibilityMode
	{
		get
		{
			return _0023_003DzgfObf7s_003D.AttributeReferenceVisibilityMode;
		}
		set
		{
			_0023_003DzgfObf7s_003D.AttributeReferenceVisibilityMode = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AccurateTransparency
	{
		get
		{
			return _0023_003DzQ4jfjaYMr4qjuwCmiw_003D_003D;
		}
		set
		{
			_0023_003DzQ4jfjaYMr4qjuwCmiw_003D_003D = value;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Category("Workspace")]
	[Description("Gets or sets the manipulator used to graphically position the selected entities.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal ObjectManipulator _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D
	{
		get
		{
			return _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D;
		}
		set
		{
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003DzmNZD0Zs_003D.MakeCurrent();
			}
			if (_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D != null)
			{
				_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.Dispose();
			}
			_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D = value;
			_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003DzU0f5_qE_003D = this;
			_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.CheckAndFixDefaultLayerName(this);
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				CompileUserInterfaceElements();
			}
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int AllocatedCharDefs => Document.fontDefs.Count;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsOpenRootLevel => _0023_003DzzFGpNZit9CtK.Count == 1;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public BlockReference CurrentBlockReference
	{
		get
		{
			if (_0023_003DzzFGpNZit9CtK.Count > 0 && _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Count > 0 && !_0023_003DzRwMrM8lh4Uvo)
			{
				return _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Peek().BlockReference;
			}
			return null;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Block CurrentBlock
	{
		get
		{
			if (CurrentBlockReference == null)
			{
				return OpenBlock;
			}
			return Blocks[CurrentBlockReference.BlockName];
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Block OpenBlock
	{
		get
		{
			if (_0023_003DzzFGpNZit9CtK.Count > 0)
			{
				return _0023_003DzzFGpNZit9CtK.Peek().Block;
			}
			return null;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Transformation CurrentTransformation => CurrentBlockReference?.AccumulatedParentsTransform;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Stack<BlockReference> Parents
	{
		get
		{
			Stack<BlockReference> stack = new Stack<BlockReference>();
			foreach (CurrentBlockRefData item in _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D())
			{
				stack.Push(item.BlockReference);
			}
			return new Stack<BlockReference>(stack);
		}
	}

	ISelectionSettings IWorkspace.Selection => Selection;

	IViewport IWorkspace.ActiveViewport => _0023_003DzipBYly6zFKAp();

	IList<IViewport> IWorkspace.Viewports
	{
		get
		{
			IViewport[] array = new IViewport[_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count];
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				array[i] = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i];
			}
			return array;
		}
	}

	[Category("Workspace")]
	[Description("Keyboard shortcuts.")]
	public ShortcutKeysSettings ShortcutKeys
	{
		get
		{
			return shortcutKeys;
		}
		set
		{
			shortcutKeys = value;
		}
	}

	[Category("Workspace - Selection")]
	public int PickBoxSize
	{
		get
		{
			return _0023_003DzjWLowQN0uWZO;
		}
		set
		{
			Utility.LimitRange(4, ref value, 32);
			_0023_003DzjWLowQN0uWZO = value;
			_0023_003DzKrDqx6j0jLR2();
			if (IsSelectByPickAction())
			{
				SetCursor(_0023_003DzMANLSxJk4AWs);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool MultipleSelection
	{
		get
		{
			return _0023_003DzHPlVDFvTViEi;
		}
		set
		{
			_0023_003DzHPlVDFvTViEi = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Dictionary<cursorType, Cursor> CursorTypes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJL_00244gFMrjFADCm20e5BPNf0_003D;
		}
		internal set
		{
			_0023_003DzJL_00244gFMrjFADCm20e5BPNf0_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public actionType ActionMode
	{
		get
		{
			return _0023_003DzjGvm17_0024DzsnS;
		}
		set
		{
			_0023_003DzXvkGANJxfCjf(value, this);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal assemblySelectionType _0023_003DznugYzyWkU3Do
	{
		get
		{
			return _0023_003DzCBASci_Gpxb1;
		}
		set
		{
			_0023_003DzCBASci_Gpxb1 = value;
			if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
			{
				_0023_003DzipBYly6zFKAp().Camera.ZBufferData.ResetCapturedView();
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal selectionFilterType _0023_003Dz28QCun7pbbWH
	{
		get
		{
			return _0023_003Dzfk9mqRZJav3i;
		}
		set
		{
			bool flag = _0023_003Dzfk9mqRZJav3i != value;
			selectionFilterType selectionFilterType2 = _0023_003Dzfk9mqRZJav3i;
			if (flag)
			{
				_0023_003DzZqeDo9pUqALBMFSt2w_003D_003D(value);
			}
			_0023_003Dzfk9mqRZJav3i = value;
			foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
			{
				item.Camera.ZBufferData.SelectionImage.Clear();
			}
			if (!flag)
			{
				return;
			}
			switch (selectionFilterType2)
			{
			case selectionFilterType.Entity:
			{
				foreach (Block block in Blocks)
				{
					_0023_003Dz0_czIjY3d3YXM7nQVA_003D_003D(block.Entities);
				}
				return;
			}
			case selectionFilterType.Face:
			{
				foreach (Block block2 in Blocks)
				{
					_0023_003Dz0uUl8FiJh4Xc0AjWsArN2Yw_003D(block2.Entities);
				}
				return;
			}
			case selectionFilterType.Edge:
			{
				foreach (Block block3 in Blocks)
				{
					_0023_003DzFDljQIYftpvseZPb3g_003D_003D(block3.Entities);
				}
				return;
			}
			case selectionFilterType.Vertex:
			{
				foreach (Block block4 in Blocks)
				{
					_0023_003DzyqHqGuOKMBaDEeML0ppaX3qGzt2F(block4.Entities);
				}
				return;
			}
			}
			_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2 = _0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzL6K8geaJ1txf5D5yMv4RLXC49gDm;
			switch (selectionFilterType2)
			{
			case selectionFilterType.SubCurve:
				_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2 = _0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dz9f2JXT9BS226LHd6ZgYI8pfjEWX3;
				break;
			case selectionFilterType.Contour:
				_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2 = delegate(Entity _0023_003DztJCl_0024mM_003D)
				{
					if (_0023_003DztJCl_0024mM_003D is devDept.Eyeshot.Entities.Region region)
					{
						region.ClearSubContoursSelection(selectionStatusType.Permanent);
					}
				};
				break;
			default:
				if ((selectionFilterType2 & selectionFilterType.SketchPoint) != 0 || (selectionFilterType2 & selectionFilterType.SketchCurve) != 0)
				{
					_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2 = (_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D)Delegate.Combine(_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2, new _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzyIUW8vHv44CinxDd7eg9hxJrYBtd));
				}
				if ((selectionFilterType2 & selectionFilterType.Face) != 0)
				{
					_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2 = (_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D)Delegate.Combine(_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2, (_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D)delegate(Entity _0023_003DztJCl_0024mM_003D)
					{
						_0023_003DztJCl_0024mM_003D.ClearSelectionFaces(selectionStatusType.Permanent);
					});
				}
				if ((selectionFilterType2 & selectionFilterType.Edge) != 0)
				{
					_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2 = (_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D)Delegate.Combine(_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2, new _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzL6K8geaJ1txf5D5yMv4RLXEVxUbF));
				}
				if ((selectionFilterType2 & selectionFilterType.Vertex) != 0)
				{
					_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2 = (_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D)Delegate.Combine(_0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2, new _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DznajkouNRbAMfkaiE_30CeGs4dIse));
				}
				break;
			}
			foreach (Block block5 in Blocks)
			{
				_0023_003DzOOXPlJN4n8PM2s1qJQ_003D_003D(block5.Entities, _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D2);
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal bool _0023_003DzceJZi0o_003D
	{
		get
		{
			return _0023_003Dz4urXwVzmTQSX;
		}
		set
		{
			_0023_003Dz4urXwVzmTQSX = value;
			_0023_003DzipBYly6zFKAp()._0023_003Dz_0024J0MwzgL89fc(_0023_003Dz4urXwVzmTQSX);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected internal bool Moving
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzNSB0vGy6M4wYO1acTQ_003D_003D;
		}
		internal set
		{
			_0023_003DzNSB0vGy6M4wYO1acTQ_003D_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int CameraChangedFrequency
	{
		get
		{
			return _0023_003DzhDYcRHMzGMdJMDZoNA_003D_003D;
		}
		set
		{
			_0023_003DzhDYcRHMzGMdJMDZoNA_003D_003D = value;
			if (_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D != null)
			{
				_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Interval = _0023_003DzhDYcRHMzGMdJMDZoNA_003D_003D;
				if (_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Enabled)
				{
					_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Stop();
					_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Start();
				}
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[NotifyParentProperty(true)]
	internal ViewportList _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D
	{
		get
		{
			return _0023_003DzbesAu90NcF8KFeewpw_003D_003D;
		}
		set
		{
			_0023_003DzbesAu90NcF8KFeewpw_003D_003D = value;
			_0023_003DzbesAu90NcF8KFeewpw_003D_003D._0023_003DzHqqvNbsad_LE(this);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal int _0023_003DzBn2ByFKdwrou
	{
		get
		{
			return _0023_003DzO9NcOvRo2Yyn;
		}
		set
		{
			if (_0023_003DzbesAu90NcF8KFeewpw_003D_003D != null && !_0023_003DzlNGYbbA_003D && (value >= _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count || value < 0))
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595922));
			}
			_0023_003DzO9NcOvRo2Yyn = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public BackgroundSettings Background
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return _0023_003DzipBYly6zFKAp().Background;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal BoundingBoxSettings _0023_003DzK3OaHhra7VrS
	{
		get
		{
			return _0023_003Dz6CMmzY6fHGlL;
		}
		set
		{
			if (_0023_003Dz6CMmzY6fHGlL != null)
			{
				_0023_003Dz6CMmzY6fHGlL.ParentWorkspace = null;
				_0023_003Dz6CMmzY6fHGlL.Dispose();
			}
			_0023_003Dz6CMmzY6fHGlL = value;
			if (_0023_003Dz6CMmzY6fHGlL != null)
			{
				_0023_003Dz6CMmzY6fHGlL.ParentWorkspace = this;
			}
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Legend Legend
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return _0023_003DzipBYly6zFKAp().Legend;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Legend[] Legends
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return _0023_003DzipBYly6zFKAp().Legends;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolBar ToolBar
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return _0023_003DzipBYly6zFKAp().ToolBar;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolBar[] ToolBars
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return _0023_003DzipBYly6zFKAp().ToolBars;
		}
	}

	[Category("Workspace - User Interface")]
	public ButtonSettings ButtonStyle
	{
		get
		{
			return _0023_003DzMC9Ycx3kKvGA;
		}
		set
		{
			if (_0023_003DzMC9Ycx3kKvGA != null)
			{
				_0023_003DzMC9Ycx3kKvGA._0023_003DzU0f5_qE_003D = null;
			}
			_0023_003DzMC9Ycx3kKvGA = value;
			if (_0023_003DzMC9Ycx3kKvGA != null)
			{
				_0023_003DzMC9Ycx3kKvGA._0023_003DzU0f5_qE_003D = this;
			}
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003Dzq0o8PI7V46nBBc7u3A_003D_003D(null);
			}
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Category("Workspace")]
	[Description("If true, curve direction is displayed.")]
	public bool ShowCurveDirection
	{
		get
		{
			return _0023_003DzTmVXuIf7B_f_;
		}
		set
		{
			_0023_003DzTmVXuIf7B_f_ = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal LightSettings _0023_003DzA8xJVfE_003D
	{
		get
		{
			return _0023_003DzMuApP021PUyU[0];
		}
		set
		{
			_0023_003DzMuApP021PUyU[0] = value;
			_0023_003DzBnjb2sFOreKL();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal LightSettings _0023_003DzUHjavx4_003D
	{
		get
		{
			return _0023_003DzMuApP021PUyU[1];
		}
		set
		{
			_0023_003DzMuApP021PUyU[1] = value;
			_0023_003DzBnjb2sFOreKL();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal LightSettings _0023_003Dznb93J4o_003D
	{
		get
		{
			return _0023_003DzMuApP021PUyU[2];
		}
		set
		{
			_0023_003DzMuApP021PUyU[2] = value;
			_0023_003DzBnjb2sFOreKL();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal LightSettings _0023_003Dz_DQFpGk_003D
	{
		get
		{
			return _0023_003DzMuApP021PUyU[3];
		}
		set
		{
			_0023_003DzMuApP021PUyU[3] = value;
			_0023_003DzBnjb2sFOreKL();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal LightSettings _0023_003DzOFMlt_0024c_003D
	{
		get
		{
			return _0023_003DzMuApP021PUyU[4];
		}
		set
		{
			_0023_003DzMuApP021PUyU[4] = value;
			_0023_003DzBnjb2sFOreKL();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal LightSettings _0023_003DzBlyZl0s_003D
	{
		get
		{
			return _0023_003DzMuApP021PUyU[5];
		}
		set
		{
			_0023_003DzMuApP021PUyU[5] = value;
			_0023_003DzBnjb2sFOreKL();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal LightSettings _0023_003DzROpY3fw_003D
	{
		get
		{
			return _0023_003DzMuApP021PUyU[6];
		}
		set
		{
			_0023_003DzMuApP021PUyU[6] = value;
			_0023_003DzBnjb2sFOreKL();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal LightSettings _0023_003DzWf_0024Lcf0_003D
	{
		get
		{
			return _0023_003DzMuApP021PUyU[7];
		}
		set
		{
			_0023_003DzMuApP021PUyU[7] = value;
			_0023_003DzBnjb2sFOreKL();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal Color _0023_003DzB4HyWijCerQJ
	{
		get
		{
			return _0023_003DzXVJ6CvJJYmrqf3ztQQ_003D_003D;
		}
		set
		{
			_0023_003DzXVJ6CvJJYmrqf3ztQQ_003D_003D = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal Material _0023_003Dzxpbv4lQ_003D
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.DefaultMaterial;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.DefaultMaterial = value;
			_0023_003DzmNZD0Zs_003D?.ProcessMaterial();
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal ClippingPlane _0023_003DzG6pm3fB_0024JDYx85tz2g_003D_003D
	{
		get
		{
			return (ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[0];
		}
		set
		{
			_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[0] = value;
			_0023_003Dz_NzWuEbp1_u99cihSQ_003D_003D(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[0]);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal ClippingPlane _0023_003DzUuD80DLRm9m0Ctp_0024LQ_003D_003D
	{
		get
		{
			return (ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[1];
		}
		set
		{
			_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[1] = value;
			_0023_003Dz_NzWuEbp1_u99cihSQ_003D_003D(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[1]);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal ClippingPlane _0023_003DzecljuDpEX8THFTC1Bg_003D_003D
	{
		get
		{
			return (ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[2];
		}
		set
		{
			_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[2] = value;
			_0023_003Dz_NzWuEbp1_u99cihSQ_003D_003D(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[2]);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal ClippingPlane _0023_003Dz7_0024B6af_0024DoIkBDt98sA_003D_003D
	{
		get
		{
			return (ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[3];
		}
		set
		{
			_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[3] = value;
			_0023_003Dz_NzWuEbp1_u99cihSQ_003D_003D(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[3]);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal ClippingPlane _0023_003DzFcrMFMgYL_8vDuzo_0024A_003D_003D
	{
		get
		{
			return (ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[4];
		}
		set
		{
			_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[4] = value;
			_0023_003Dz_NzWuEbp1_u99cihSQ_003D_003D(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[4]);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal ClippingPlane _0023_003DzJD9deTMAEJ3hlvoP_0024A_003D_003D
	{
		get
		{
			return (ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[5];
		}
		set
		{
			_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[5] = value;
			_0023_003Dz_NzWuEbp1_u99cihSQ_003D_003D(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[5]);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	internal BorderSettings _0023_003DzOLP90s_0024AN26E
	{
		get
		{
			return _0023_003DzE61nM_aOZBgx;
		}
		set
		{
			if (_0023_003DzE61nM_aOZBgx != null)
			{
				_0023_003DzE61nM_aOZBgx.ParentWorkspace = null;
			}
			_0023_003DzE61nM_aOZBgx = value;
			if (_0023_003DzE61nM_aOZBgx != null)
			{
				_0023_003DzE61nM_aOZBgx.ParentWorkspace = this;
			}
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Category("Workspace")]
	[Description("Backface color, shared by all viewports.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal BackfaceSettings _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D
	{
		get
		{
			return _0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D;
		}
		set
		{
			_0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public AmbientOcclusionSettings AmbientOcclusion
	{
		get
		{
			return _0023_003Dztlc4_vYMmHwMNn1eUs_lO_Tk1pwt;
		}
		set
		{
			_0023_003DzmNZD0Zs_003D.aoCompositing?.Dispose();
			_0023_003DzmNZD0Zs_003D.aoCompositing = null;
			_0023_003Dztlc4_vYMmHwMNn1eUs_lO_Tk1pwt = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Category("Ambient Occlusion")]
	[Description("Ambient Occlusion settings, shared by all viewports.")]
	public bool EnableAmbientOcclusion
	{
		get
		{
			return AmbientOcclusion?.Enabled ?? false;
		}
		set
		{
			if (AmbientOcclusion != null)
			{
				AmbientOcclusion.Enabled = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SelectionSettings Selection
	{
		get
		{
			return _0023_003DzQqplHwiu62CW;
		}
		set
		{
			_0023_003DzQqplHwiu62CW = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Obsolete("Use SelectionSettings Workspace.Selection instead.")]
	[Category("Workspace - Selection")]
	[Description("Color of selected entities, shared by all viewports.")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color SelectionColor
	{
		get
		{
			return Selection.Color;
		}
		set
		{
			Selection.Color = value;
		}
	}

	[Obsolete("Use SelectionSettings Workspace.Selection instead.")]
	[Category("Workspace - Selection")]
	[Description("Color of dynamic selection, shared by all viewports.")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color SelectionColorDynamic
	{
		get
		{
			return Selection.ColorDynamic;
		}
		set
		{
			Selection.ColorDynamic = value;
		}
	}

	[Obsolete("Use SelectionSettings Workspace.Selection instead.")]
	[Category("Workspace - Selection")]
	[Description("The line weight scale factor for selected entities, shared by all viewports.")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public float SelectionLineWeightScaleFactor
	{
		get
		{
			return Selection.LineWeightScaleFactor;
		}
		set
		{
			Selection.LineWeightScaleFactor = value;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Category("Workspace - Display Settings")]
	[Description("Display Settings for Wireframe mode, shared by all viewports.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal DisplayModeSettings _0023_003DzAdpXPj_0024l7nqBsSXydw_003D_003D
	{
		get
		{
			return _0023_003DzsliWYheSU0DTuUNAYg_003D_003D;
		}
		set
		{
			_0023_003DzsliWYheSU0DTuUNAYg_003D_003D = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Category("Workspace - Display Settings")]
	[Description("Display Settings for Shaded mode, shared by all viewports.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal DisplayModeSettingsShaded _0023_003DzAv2OMNy7DJ5L
	{
		get
		{
			return _0023_003DzEfebv86OlSaQUw9POQ_003D_003D;
		}
		set
		{
			_0023_003DzEfebv86OlSaQUw9POQ_003D_003D = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Category("Workspace - Display Settings")]
	[Description("Display Settings for Flat mode, shared by all viewports.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal DisplayModeSettingsFlat _0023_003Dzipe8ch4_003D
	{
		get
		{
			return _0023_003Dzl8PjArmAqC_m;
		}
		set
		{
			_0023_003Dzl8PjArmAqC_m = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Category("Workspace - Display Settings")]
	[Description("Display Settings for Rendered mode, shared by all viewports.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal DisplayModeSettingsRendered _0023_003DznKkOfo8_003D
	{
		get
		{
			return _0023_003DzB_4avBudAWM2;
		}
		set
		{
			_0023_003DzB_4avBudAWM2 = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Category("Workspace")]
	[Description("Coordinate system orientation mode.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal orientationType _0023_003Dz0fqXN00AlqdN
	{
		get
		{
			return _0023_003DzLpjRly40lvq1;
		}
		set
		{
			bool flag = _0023_003DzLpjRly40lvq1 != value;
			_0023_003DzLpjRly40lvq1 = value;
			if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
			{
				return;
			}
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003DzO5pd3YKMgnZIKCbw0br7uQQ_003D();
			}
			if (IsDesignMode())
			{
				Quaternion quaternion = ((_0023_003DzLpjRly40lvq1 != orientationType.UpAxisY) ? new Quaternion(Vector3D.AxisX, -90.0) : new Quaternion(Vector3D.AxisX, 90.0));
				foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
				{
					item.Camera.Rotation = quaternion * item.Camera.Rotation;
				}
			}
			_0023_003Dz8ok_dRe4bjRDcVb_0024afNnmr8_003D = true;
			foreach (Viewport item2 in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
			{
				if (item2._0023_003Dz4ry2vZefVkxX != null && flag && _0023_003DzmNZD0Zs_003D != null)
				{
					item2._0023_003Dz4ry2vZefVkxX._0023_003DztTeP7_0024pDa3AKQJRYIg_003D_003D(item2, new CompileParams(this), new RegenParams(Entities), _0023_003Dz0fqXN00AlqdN);
				}
			}
			if (IsDesignMode())
			{
				ZoomFit();
				_0023_003Dz3tGL3rg_003D();
			}
		}
	}

	[Category("Workspace")]
	[Description("Frame per second rate text visibility status.")]
	public bool ShowFps
	{
		get
		{
			return _0023_003DzMdZJFmWObL0F;
		}
		set
		{
			_0023_003DzMdZJFmWObL0F = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal linearUnitsType _0023_003DzpYxLcIs_003D
	{
		get
		{
			return _0023_003DzgfObf7s_003D.Units;
		}
		set
		{
			_0023_003DzgfObf7s_003D.Units = value;
		}
	}

	[Category("Workspace")]
	[Description("Wait cursor mode. Controls if and when the wait cursor is displayed.")]
	public waitCursorType WaitCursorMode
	{
		get
		{
			return _0023_003DzCf__tCZh1QRt;
		}
		set
		{
			_0023_003DzCf__tCZh1QRt = value;
		}
	}

	[Category("Workspace - Initialization")]
	[Description("If true, OpenGL accelerated hardware modes are requested during viewport initialization. Set to false if the OpenGL hardware acceleration causes display problems.")]
	[Obsolete("With the adoption of OpenGL 3.3, a HW accelerated context is always requested. A non accelerated one is tried as a fallback. This property will be actively ignored.")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AskForHardwareAcceleration
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.askForHwAcc;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.askForHwAcc = value;
		}
	}

	[Category("Workspace - Initialization")]
	[Description("Asks for the Direct3D feature level 9_3.")]
	public bool AskForDirect3DLevel9_3
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.askForLevel9_3;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.askForLevel9_3 = value;
		}
	}

	[Category("Workspace - Initialization")]
	[Description("If true, Full Screen Anti-Aliasing modes are requested during viewport initialization. The number of samples can be set with the AntiAliasingSamples property.")]
	public bool AskForAntiAliasing
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.askForAntiAliasing;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.askForAntiAliasing = value;
		}
	}

	[Category("Workspace")]
	[Description("Gets or sets a value indicating if full screen anti-aliasing is enabled. Available only if AskForAntiAliasing property is set to true in the constructor.")]
	public bool AntiAliasing
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.AntiAliasing;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.AntiAliasing = value;
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003DzmNZD0Zs_003D.UpdateAntialiasing();
			}
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Category("Workspace - Initialization")]
	[Description("Gets or sets the number of desired samples for Full Screen Anti-Aliasing. The Full Screen Anti-alasing can be set with the AskForAntiAliasing property.")]
	public antialiasingSamplesNumberType AntiAliasingSamples
	{
		get
		{
			return _0023_003DzjC4hA2I_003D.antialiasingSamples;
		}
		set
		{
			_0023_003DzjC4hA2I_003D.antialiasingSamples = value;
		}
	}

	[Category("Workspace - OpenGL")]
	[Description("The company responsible for this GL implementation. This name does not change from release to release.")]
	public string RendererVendor
	{
		get
		{
			if (!_0023_003DzmNZD0Zs_003D.IsDirect3D)
			{
				return _0023_003DzmNZD0Zs_003D.VendorName;
			}
			return string.Empty;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Version ShadingLanguageVersion
	{
		get
		{
			if (!_0023_003DzmNZD0Zs_003D.IsDirect3D)
			{
				return ((OglRenderContext)_0023_003DzmNZD0Zs_003D).ShadingLanguageVersion;
			}
			return new Version();
		}
	}

	[Category("Workspace - Graphics")]
	[Description("The maximum texture size allowed on current OpenGL implementation (in pixel).")]
	public int MaxTextureSize => _0023_003DzmNZD0Zs_003D.MaxTextureSize();

	[Category("Workspace - Graphics")]
	[Description("Name of the renderer. This name is typically specific to a particular configuration of a hardware platform. It does not change from release to release.")]
	public string RendererName => _0023_003DzmNZD0Zs_003D.RendererName.TrimEnd(default(char));

	[Category("Workspace - Graphics")]
	[Description("Renderer version.")]
	public Version RendererVersion => _0023_003DzmNZD0Zs_003D.RendererVersion;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal int _0023_003DzEDUeIexdjfn_EoBUmQ_003D_003D
	{
		get
		{
			return _0023_003Dz3W9juyTOSqQmu_1zL6wSiTo_003D;
		}
		set
		{
			_0023_003Dz3W9juyTOSqQmu_1zL6wSiTo_003D = value;
			_0023_003DzhZBG7nJJTvjGfFveRwoiZ4U_003D();
			_0023_003DzWuKjd4wWwSi6();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	private protected double _0023_003DzW9xZcbsM9yIJ
	{
		get
		{
			return _0023_003DzU6UgNDFo2ST8;
		}
		set
		{
			_0023_003DzU6UgNDFo2ST8 = value;
			_0023_003DzhZBG7nJJTvjGfFveRwoiZ4U_003D();
			_0023_003DzWuKjd4wWwSi6();
		}
	}

	[Category("Workspace - Performance")]
	[Description("Gets or sets the maximum number of pattern repetitions allowed between two vertices of a curve.")]
	public int MaxPatternRepetitions
	{
		get
		{
			return _0023_003DzgfObf7s_003D.MaxPatternRepetitions;
		}
		set
		{
			_0023_003DzgfObf7s_003D.MaxPatternRepetitions = value;
		}
	}

	[Category("Workspace - Performance")]
	[Description("Gets or sets the maximum number of hatch pattern lines allowed for an Hatch.")]
	public int MaxHatchPatternLines
	{
		get
		{
			return _0023_003DzgfObf7s_003D.MaxHatchPatternLines;
		}
		set
		{
			_0023_003DzgfObf7s_003D.MaxHatchPatternLines = value;
		}
	}

	[Category("Workspace - Performance")]
	[Description("Gets or sets the modality used by IsInFrustum() method.")]
	public Camera.perspectiveFitType IsInFrustumMode
	{
		get
		{
			return _0023_003Dzf5Odjtzb03wW_0024l1D0A_003D_003D;
		}
		set
		{
			_0023_003Dzf5Odjtzb03wW_0024l1D0A_003D_003D = value;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Category("Workspace - Display Settings")]
	[Description("Hidden Lines settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal HiddenLinesSettings _0023_003DzP6FAuV4Dwq24
	{
		get
		{
			return _0023_003Dzddm_0024rF6S_0024y27;
		}
		set
		{
			_0023_003Dzddm_0024rF6S_0024y27 = value;
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				CompileUserInterfaceElements();
			}
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Category("Workspace - User Interface")]
	[Description("Progress bar settings.")]
	public ProgressBar ProgressBar
	{
		get
		{
			return _0023_003DzD157GIliOpnX;
		}
		set
		{
			_0023_003DzD157GIliOpnX = value;
			if (_0023_003DzD157GIliOpnX == null)
			{
				_0023_003DzD157GIliOpnX = new ProgressBar();
			}
			_0023_003DzD157GIliOpnX.ParentWorkspace = this;
			_0023_003DzD157GIliOpnX._0023_003Dz8WTvZ9I_003D(this, null);
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Description("The Cancel Button.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ToolBarButton ProgressBarCancelButton
	{
		get
		{
			return _0023_003DzwsiNROJDQzj_upG53A_003D_003D;
		}
		set
		{
			if (_0023_003DzwsiNROJDQzj_upG53A_003D_003D != null)
			{
				_0023_003DzwsiNROJDQzj_upG53A_003D_003D.Dispose();
			}
			_0023_003DzwsiNROJDQzj_upG53A_003D_003D = value;
			if (_0023_003DzwsiNROJDQzj_upG53A_003D_003D != null)
			{
				_0023_003DzwsiNROJDQzj_upG53A_003D_003D._0023_003DzVCRPD_0024GbQNCA = true;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ShowNormals
	{
		get
		{
			return _0023_003DzwMU34Oc0NLb_3_0024j4Jg_003D_003D;
		}
		set
		{
			_0023_003DzwMU34Oc0NLb_3_0024j4Jg_003D_003D = value;
		}
	}

	[Browsable(false)]
	public float FramesPerSecond => fps;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool CompileWires
	{
		get
		{
			return _0023_003DzPZw2_0024thQNusZq2_00247Sw_003D_003D;
		}
		set
		{
			if (base.IsHandleCreated)
			{
				string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596155);
				Logger.Instance.Error(InstanceId, message, null);
				throw new EyeshotException(message);
			}
			_0023_003DzPZw2_0024thQNusZq2_00247Sw_003D_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Type FileSerializerForExtendedFormat
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzpg1eSrVpbJEmyn4WvPu_xf0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzpg1eSrVpbJEmyn4WvPu_xf0_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Obsolete("IsBusy is deprecated. Prefer awaiting Workspace.DoWorkAsync(...) or tracking the returned Task to determine execution state.")]
	public bool IsBusy
	{
		get
		{
			Task task = _0023_003DzxIG92rhdr_0024Fd;
			if (task != null)
			{
				return !task.IsCompleted;
			}
			return false;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal bool _0023_003DzwFKdhc8_003D
	{
		get
		{
			return _0023_003Dz_Z7KNTKMA06dbr_pHg_003D_003D;
		}
		private set
		{
			_0023_003Dz_Z7KNTKMA06dbr_pHg_003D_003D = value;
		}
	}

	[Category("Workspace")]
	[Description("If true, animates the camera in the commands that change its position or orientation.")]
	public bool AnimateCamera
	{
		get
		{
			return _0023_003DzHCo_FUpekslZ_O5CLQ_003D_003D;
		}
		set
		{
			_0023_003DzHCo_FUpekslZ_O5CLQ_003D_003D = value;
		}
	}

	[Category("Workspace")]
	[Description("Gets or sets the duration of the camera animation.")]
	public int AnimateCameraDuration
	{
		get
		{
			return _0023_003DzIQzMdMmuW0nMhvEIaa5o_0024QI_003D;
		}
		set
		{
			_0023_003DzIQzMdMmuW0nMhvEIaa5o_0024QI_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool SuspendSetColorForSelection
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWepENTTgbYlseBo8TKkrcv8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWepENTTgbYlseBo8TKkrcv8_003D = value;
		}
	}

	[Category("Workspace - Printing")]
	[Description("Print document name. It also appears during print preview preparation.")]
	public string PrintDocumentName
	{
		get
		{
			return _0023_003DzbdLgm9c_003D.DocumentName;
		}
		set
		{
			_0023_003DzbdLgm9c_003D.DocumentName = value;
		}
	}

	[Description("Occurs when a Mouse3D button is pressed.")]
	[Category("Workspace")]
	public event ButtonEventHandler Mouse3DButtonDown
	{
		[CompilerGenerated]
		add
		{
			ButtonEventHandler buttonEventHandler = _0023_003DztOrlz_zSFCUN;
			ButtonEventHandler buttonEventHandler2;
			do
			{
				buttonEventHandler2 = buttonEventHandler;
				ButtonEventHandler value2 = (ButtonEventHandler)Delegate.Combine(buttonEventHandler2, value);
				buttonEventHandler = Interlocked.CompareExchange(ref _0023_003DztOrlz_zSFCUN, value2, buttonEventHandler2);
			}
			while ((object)buttonEventHandler != buttonEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ButtonEventHandler buttonEventHandler = _0023_003DztOrlz_zSFCUN;
			ButtonEventHandler buttonEventHandler2;
			do
			{
				buttonEventHandler2 = buttonEventHandler;
				ButtonEventHandler value2 = (ButtonEventHandler)Delegate.Remove(buttonEventHandler2, value);
				buttonEventHandler = Interlocked.CompareExchange(ref _0023_003DztOrlz_zSFCUN, value2, buttonEventHandler2);
			}
			while ((object)buttonEventHandler != buttonEventHandler2);
		}
	}

	[Description("Occurs when a Mouse3D button is released.")]
	[Category("Workspace")]
	public event ButtonEventHandler Mouse3DButtonUp
	{
		[CompilerGenerated]
		add
		{
			ButtonEventHandler buttonEventHandler = _0023_003Dz0sL73kYUF3eZ;
			ButtonEventHandler buttonEventHandler2;
			do
			{
				buttonEventHandler2 = buttonEventHandler;
				ButtonEventHandler value2 = (ButtonEventHandler)Delegate.Combine(buttonEventHandler2, value);
				buttonEventHandler = Interlocked.CompareExchange(ref _0023_003Dz0sL73kYUF3eZ, value2, buttonEventHandler2);
			}
			while ((object)buttonEventHandler != buttonEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ButtonEventHandler buttonEventHandler = _0023_003Dz0sL73kYUF3eZ;
			ButtonEventHandler buttonEventHandler2;
			do
			{
				buttonEventHandler2 = buttonEventHandler;
				ButtonEventHandler value2 = (ButtonEventHandler)Delegate.Remove(buttonEventHandler2, value);
				buttonEventHandler = Interlocked.CompareExchange(ref _0023_003Dz0sL73kYUF3eZ, value2, buttonEventHandler2);
			}
			while ((object)buttonEventHandler != buttonEventHandler2);
		}
	}

	[Description("Occurs when a Mouse3D movement operation is performed.")]
	[Category("Workspace")]
	public event MoveEventHandler Mouse3DMove
	{
		[CompilerGenerated]
		add
		{
			MoveEventHandler moveEventHandler = _0023_003DzNlD1nBz7pQOD;
			MoveEventHandler moveEventHandler2;
			do
			{
				moveEventHandler2 = moveEventHandler;
				MoveEventHandler value2 = (MoveEventHandler)Delegate.Combine(moveEventHandler2, value);
				moveEventHandler = Interlocked.CompareExchange(ref _0023_003DzNlD1nBz7pQOD, value2, moveEventHandler2);
			}
			while ((object)moveEventHandler != moveEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MoveEventHandler moveEventHandler = _0023_003DzNlD1nBz7pQOD;
			MoveEventHandler moveEventHandler2;
			do
			{
				moveEventHandler2 = moveEventHandler;
				MoveEventHandler value2 = (MoveEventHandler)Delegate.Remove(moveEventHandler2, value);
				moveEventHandler = Interlocked.CompareExchange(ref _0023_003DzNlD1nBz7pQOD, value2, moveEventHandler2);
			}
			while ((object)moveEventHandler != moveEventHandler2);
		}
	}

	[Description("Occurs when a multitouch surface is pressed.")]
	[Category("Workspace")]
	public event MultiTouchEventHandler MultiTouchDown
	{
		[CompilerGenerated]
		add
		{
			MultiTouchEventHandler multiTouchEventHandler = _0023_003Dz_0024DKbcuTzjqgK;
			MultiTouchEventHandler multiTouchEventHandler2;
			do
			{
				multiTouchEventHandler2 = multiTouchEventHandler;
				MultiTouchEventHandler value2 = (MultiTouchEventHandler)Delegate.Combine(multiTouchEventHandler2, value);
				multiTouchEventHandler = Interlocked.CompareExchange(ref _0023_003Dz_0024DKbcuTzjqgK, value2, multiTouchEventHandler2);
			}
			while ((object)multiTouchEventHandler != multiTouchEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MultiTouchEventHandler multiTouchEventHandler = _0023_003Dz_0024DKbcuTzjqgK;
			MultiTouchEventHandler multiTouchEventHandler2;
			do
			{
				multiTouchEventHandler2 = multiTouchEventHandler;
				MultiTouchEventHandler value2 = (MultiTouchEventHandler)Delegate.Remove(multiTouchEventHandler2, value);
				multiTouchEventHandler = Interlocked.CompareExchange(ref _0023_003Dz_0024DKbcuTzjqgK, value2, multiTouchEventHandler2);
			}
			while ((object)multiTouchEventHandler != multiTouchEventHandler2);
		}
	}

	[Description("Occurs when a multitouch surface is released.")]
	[Category("Workspace")]
	public event MultiTouchEventHandler MultiTouchUp
	{
		[CompilerGenerated]
		add
		{
			MultiTouchEventHandler multiTouchEventHandler = _0023_003Dz_0024inpPjY5h8Jv;
			MultiTouchEventHandler multiTouchEventHandler2;
			do
			{
				multiTouchEventHandler2 = multiTouchEventHandler;
				MultiTouchEventHandler value2 = (MultiTouchEventHandler)Delegate.Combine(multiTouchEventHandler2, value);
				multiTouchEventHandler = Interlocked.CompareExchange(ref _0023_003Dz_0024inpPjY5h8Jv, value2, multiTouchEventHandler2);
			}
			while ((object)multiTouchEventHandler != multiTouchEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MultiTouchEventHandler multiTouchEventHandler = _0023_003Dz_0024inpPjY5h8Jv;
			MultiTouchEventHandler multiTouchEventHandler2;
			do
			{
				multiTouchEventHandler2 = multiTouchEventHandler;
				MultiTouchEventHandler value2 = (MultiTouchEventHandler)Delegate.Remove(multiTouchEventHandler2, value);
				multiTouchEventHandler = Interlocked.CompareExchange(ref _0023_003Dz_0024inpPjY5h8Jv, value2, multiTouchEventHandler2);
			}
			while ((object)multiTouchEventHandler != multiTouchEventHandler2);
		}
	}

	[Description("Occurs when a multitouch movement is performed.")]
	[Category("Workspace")]
	public event MultiTouchEventHandler MultiTouchMove
	{
		[CompilerGenerated]
		add
		{
			MultiTouchEventHandler multiTouchEventHandler = _0023_003DzoU40Uhh8GTY7;
			MultiTouchEventHandler multiTouchEventHandler2;
			do
			{
				multiTouchEventHandler2 = multiTouchEventHandler;
				MultiTouchEventHandler value2 = (MultiTouchEventHandler)Delegate.Combine(multiTouchEventHandler2, value);
				multiTouchEventHandler = Interlocked.CompareExchange(ref _0023_003DzoU40Uhh8GTY7, value2, multiTouchEventHandler2);
			}
			while ((object)multiTouchEventHandler != multiTouchEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MultiTouchEventHandler multiTouchEventHandler = _0023_003DzoU40Uhh8GTY7;
			MultiTouchEventHandler multiTouchEventHandler2;
			do
			{
				multiTouchEventHandler2 = multiTouchEventHandler;
				MultiTouchEventHandler value2 = (MultiTouchEventHandler)Delegate.Remove(multiTouchEventHandler2, value);
				multiTouchEventHandler = Interlocked.CompareExchange(ref _0023_003DzoU40Uhh8GTY7, value2, multiTouchEventHandler2);
			}
			while ((object)multiTouchEventHandler != multiTouchEventHandler2);
		}
	}

	[Description("Occurs when a multitouch surface is double-clicked.")]
	[Category("Workspace")]
	public event MouseEventHandler MultiTouchDoubleClick
	{
		[CompilerGenerated]
		add
		{
			MouseEventHandler mouseEventHandler = _0023_003DzlOvHZEswzSlhuG2jJA_003D_003D;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref _0023_003DzlOvHZEswzSlhuG2jJA_003D_003D, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventHandler mouseEventHandler = _0023_003DzlOvHZEswzSlhuG2jJA_003D_003D;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref _0023_003DzlOvHZEswzSlhuG2jJA_003D_003D, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
	}

	[Description("Occurs when a finger touches and holds a multitouch surface.")]
	[Category("Workspace")]
	public event MouseEventHandler MultiTouchClick
	{
		[CompilerGenerated]
		add
		{
			MouseEventHandler mouseEventHandler = _0023_003Dzl1meGtYJNgTP;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref _0023_003Dzl1meGtYJNgTP, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventHandler mouseEventHandler = _0023_003Dzl1meGtYJNgTP;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref _0023_003Dzl1meGtYJNgTP, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
	}

	[Description("Occurs when the scene bounding box has changed.")]
	[Category("Workspace")]
	public event BoundingBoxChangedHandler BoundingBoxChanged
	{
		[CompilerGenerated]
		add
		{
			BoundingBoxChangedHandler boundingBoxChangedHandler = _0023_003DzOf9Dg_0024c_0024lV_b;
			BoundingBoxChangedHandler boundingBoxChangedHandler2;
			do
			{
				boundingBoxChangedHandler2 = boundingBoxChangedHandler;
				BoundingBoxChangedHandler value2 = (BoundingBoxChangedHandler)Delegate.Combine(boundingBoxChangedHandler2, value);
				boundingBoxChangedHandler = Interlocked.CompareExchange(ref _0023_003DzOf9Dg_0024c_0024lV_b, value2, boundingBoxChangedHandler2);
			}
			while ((object)boundingBoxChangedHandler != boundingBoxChangedHandler2);
		}
		[CompilerGenerated]
		remove
		{
			BoundingBoxChangedHandler boundingBoxChangedHandler = _0023_003DzOf9Dg_0024c_0024lV_b;
			BoundingBoxChangedHandler boundingBoxChangedHandler2;
			do
			{
				boundingBoxChangedHandler2 = boundingBoxChangedHandler;
				BoundingBoxChangedHandler value2 = (BoundingBoxChangedHandler)Delegate.Remove(boundingBoxChangedHandler2, value);
				boundingBoxChangedHandler = Interlocked.CompareExchange(ref _0023_003DzOf9Dg_0024c_0024lV_b, value2, boundingBoxChangedHandler2);
			}
			while ((object)boundingBoxChangedHandler != boundingBoxChangedHandler2);
		}
	}

	[Description("Occurs when an error happens during the drawing.")]
	[Category("Workspace")]
	public event ErrorEventHandler ErrorOccurred
	{
		[CompilerGenerated]
		add
		{
			ErrorEventHandler errorEventHandler = _0023_003DzDwjKS14_003D;
			ErrorEventHandler errorEventHandler2;
			do
			{
				errorEventHandler2 = errorEventHandler;
				ErrorEventHandler value2 = (ErrorEventHandler)Delegate.Combine(errorEventHandler2, value);
				errorEventHandler = Interlocked.CompareExchange(ref _0023_003DzDwjKS14_003D, value2, errorEventHandler2);
			}
			while ((object)errorEventHandler != errorEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ErrorEventHandler errorEventHandler = _0023_003DzDwjKS14_003D;
			ErrorEventHandler errorEventHandler2;
			do
			{
				errorEventHandler2 = errorEventHandler;
				ErrorEventHandler value2 = (ErrorEventHandler)Delegate.Remove(errorEventHandler2, value);
				errorEventHandler = Interlocked.CompareExchange(ref _0023_003DzDwjKS14_003D, value2, errorEventHandler2);
			}
			while ((object)errorEventHandler != errorEventHandler2);
		}
	}

	public event NavigationTimerHandler NavigationTimerTick
	{
		[CompilerGenerated]
		add
		{
			NavigationTimerHandler navigationTimerHandler = _0023_003DzFBmlAVlkXQOb;
			NavigationTimerHandler navigationTimerHandler2;
			do
			{
				navigationTimerHandler2 = navigationTimerHandler;
				NavigationTimerHandler value2 = (NavigationTimerHandler)Delegate.Combine(navigationTimerHandler2, value);
				navigationTimerHandler = Interlocked.CompareExchange(ref _0023_003DzFBmlAVlkXQOb, value2, navigationTimerHandler2);
			}
			while ((object)navigationTimerHandler != navigationTimerHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NavigationTimerHandler navigationTimerHandler = _0023_003DzFBmlAVlkXQOb;
			NavigationTimerHandler navigationTimerHandler2;
			do
			{
				navigationTimerHandler2 = navigationTimerHandler;
				NavigationTimerHandler value2 = (NavigationTimerHandler)Delegate.Remove(navigationTimerHandler2, value);
				navigationTimerHandler = Interlocked.CompareExchange(ref _0023_003DzFBmlAVlkXQOb, value2, navigationTimerHandler2);
			}
			while ((object)navigationTimerHandler != navigationTimerHandler2);
		}
	}

	[Description("Occurs when a Zoom/Pan/Rotate camera movement begins.")]
	public event CameraMoveEventHandler CameraMoveBegin
	{
		[CompilerGenerated]
		add
		{
			CameraMoveEventHandler cameraMoveEventHandler = _0023_003Dz4QCZfUcWn12C;
			CameraMoveEventHandler cameraMoveEventHandler2;
			do
			{
				cameraMoveEventHandler2 = cameraMoveEventHandler;
				CameraMoveEventHandler value2 = (CameraMoveEventHandler)Delegate.Combine(cameraMoveEventHandler2, value);
				cameraMoveEventHandler = Interlocked.CompareExchange(ref _0023_003Dz4QCZfUcWn12C, value2, cameraMoveEventHandler2);
			}
			while ((object)cameraMoveEventHandler != cameraMoveEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CameraMoveEventHandler cameraMoveEventHandler = _0023_003Dz4QCZfUcWn12C;
			CameraMoveEventHandler cameraMoveEventHandler2;
			do
			{
				cameraMoveEventHandler2 = cameraMoveEventHandler;
				CameraMoveEventHandler value2 = (CameraMoveEventHandler)Delegate.Remove(cameraMoveEventHandler2, value);
				cameraMoveEventHandler = Interlocked.CompareExchange(ref _0023_003Dz4QCZfUcWn12C, value2, cameraMoveEventHandler2);
			}
			while ((object)cameraMoveEventHandler != cameraMoveEventHandler2);
		}
	}

	[Description("Occurs when a Zoom/Pan/Rotate camera movement ends.")]
	public event CameraMoveEventHandler CameraMoveEnd
	{
		[CompilerGenerated]
		add
		{
			CameraMoveEventHandler cameraMoveEventHandler = _0023_003DzLi0Sdf3SlhGQ;
			CameraMoveEventHandler cameraMoveEventHandler2;
			do
			{
				cameraMoveEventHandler2 = cameraMoveEventHandler;
				CameraMoveEventHandler value2 = (CameraMoveEventHandler)Delegate.Combine(cameraMoveEventHandler2, value);
				cameraMoveEventHandler = Interlocked.CompareExchange(ref _0023_003DzLi0Sdf3SlhGQ, value2, cameraMoveEventHandler2);
			}
			while ((object)cameraMoveEventHandler != cameraMoveEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CameraMoveEventHandler cameraMoveEventHandler = _0023_003DzLi0Sdf3SlhGQ;
			CameraMoveEventHandler cameraMoveEventHandler2;
			do
			{
				cameraMoveEventHandler2 = cameraMoveEventHandler;
				CameraMoveEventHandler value2 = (CameraMoveEventHandler)Delegate.Remove(cameraMoveEventHandler2, value);
				cameraMoveEventHandler = Interlocked.CompareExchange(ref _0023_003DzLi0Sdf3SlhGQ, value2, cameraMoveEventHandler2);
			}
			while ((object)cameraMoveEventHandler != cameraMoveEventHandler2);
		}
	}

	[Description("Occurs when camera changes its position.")]
	public event CameraMoveEventHandler CameraChanged
	{
		[CompilerGenerated]
		add
		{
			CameraMoveEventHandler cameraMoveEventHandler = _0023_003DzFqDpQW4_003D;
			CameraMoveEventHandler cameraMoveEventHandler2;
			do
			{
				cameraMoveEventHandler2 = cameraMoveEventHandler;
				CameraMoveEventHandler value2 = (CameraMoveEventHandler)Delegate.Combine(cameraMoveEventHandler2, value);
				cameraMoveEventHandler = Interlocked.CompareExchange(ref _0023_003DzFqDpQW4_003D, value2, cameraMoveEventHandler2);
			}
			while ((object)cameraMoveEventHandler != cameraMoveEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CameraMoveEventHandler cameraMoveEventHandler = _0023_003DzFqDpQW4_003D;
			CameraMoveEventHandler cameraMoveEventHandler2;
			do
			{
				cameraMoveEventHandler2 = cameraMoveEventHandler;
				CameraMoveEventHandler value2 = (CameraMoveEventHandler)Delegate.Remove(cameraMoveEventHandler2, value);
				cameraMoveEventHandler = Interlocked.CompareExchange(ref _0023_003DzFqDpQW4_003D, value2, cameraMoveEventHandler2);
			}
			while ((object)cameraMoveEventHandler != cameraMoveEventHandler2);
		}
	}

	[Description("Occurs when the background work has completed.")]
	[Category("Workspace")]
	[Obsolete("This event is part of the legacy StartWork/event-based pattern. Use await Workspace.DoWorkAsync(...) instead.")]
	public event WorkUnit.WorkCompletedEventHandler WorkCompleted
	{
		[CompilerGenerated]
		add
		{
			WorkUnit.WorkCompletedEventHandler workCompletedEventHandler = _0023_003Dz0T1Zdz9fIp9t;
			WorkUnit.WorkCompletedEventHandler workCompletedEventHandler2;
			do
			{
				workCompletedEventHandler2 = workCompletedEventHandler;
				WorkUnit.WorkCompletedEventHandler value2 = (WorkUnit.WorkCompletedEventHandler)Delegate.Combine(workCompletedEventHandler2, value);
				workCompletedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz0T1Zdz9fIp9t, value2, workCompletedEventHandler2);
			}
			while ((object)workCompletedEventHandler != workCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WorkUnit.WorkCompletedEventHandler workCompletedEventHandler = _0023_003Dz0T1Zdz9fIp9t;
			WorkUnit.WorkCompletedEventHandler workCompletedEventHandler2;
			do
			{
				workCompletedEventHandler2 = workCompletedEventHandler;
				WorkUnit.WorkCompletedEventHandler value2 = (WorkUnit.WorkCompletedEventHandler)Delegate.Remove(workCompletedEventHandler2, value);
				workCompletedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz0T1Zdz9fIp9t, value2, workCompletedEventHandler2);
			}
			while ((object)workCompletedEventHandler != workCompletedEventHandler2);
		}
	}

	[Description("Occurs when the background work is cancelled.")]
	[Category("Workspace")]
	[Obsolete("This event is part of the legacy StartWork/event-based pattern. Use await Workspace.DoWorkAsync(...) instead.")]
	public event WorkUnit.WorkCancelledEventHandler WorkCancelled
	{
		[CompilerGenerated]
		add
		{
			WorkUnit.WorkCancelledEventHandler workCancelledEventHandler = _0023_003Dz106nlntdESk5;
			WorkUnit.WorkCancelledEventHandler workCancelledEventHandler2;
			do
			{
				workCancelledEventHandler2 = workCancelledEventHandler;
				WorkUnit.WorkCancelledEventHandler value2 = (WorkUnit.WorkCancelledEventHandler)Delegate.Combine(workCancelledEventHandler2, value);
				workCancelledEventHandler = Interlocked.CompareExchange(ref _0023_003Dz106nlntdESk5, value2, workCancelledEventHandler2);
			}
			while ((object)workCancelledEventHandler != workCancelledEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WorkUnit.WorkCancelledEventHandler workCancelledEventHandler = _0023_003Dz106nlntdESk5;
			WorkUnit.WorkCancelledEventHandler workCancelledEventHandler2;
			do
			{
				workCancelledEventHandler2 = workCancelledEventHandler;
				WorkUnit.WorkCancelledEventHandler value2 = (WorkUnit.WorkCancelledEventHandler)Delegate.Remove(workCancelledEventHandler2, value);
				workCancelledEventHandler = Interlocked.CompareExchange(ref _0023_003Dz106nlntdESk5, value2, workCancelledEventHandler2);
			}
			while ((object)workCancelledEventHandler != workCancelledEventHandler2);
		}
	}

	[Description("Occurs when the background work has failed.")]
	[Category("Workspace")]
	[Obsolete("This event is part of the legacy StartWork/event-based pattern. Use await Workspace.DoWorkAsync(...) instead.")]
	public event WorkUnit.WorkFailedEventHandler WorkFailed
	{
		[CompilerGenerated]
		add
		{
			WorkUnit.WorkFailedEventHandler workFailedEventHandler = _0023_003DzB6s4ltXuApFM;
			WorkUnit.WorkFailedEventHandler workFailedEventHandler2;
			do
			{
				workFailedEventHandler2 = workFailedEventHandler;
				WorkUnit.WorkFailedEventHandler value2 = (WorkUnit.WorkFailedEventHandler)Delegate.Combine(workFailedEventHandler2, value);
				workFailedEventHandler = Interlocked.CompareExchange(ref _0023_003DzB6s4ltXuApFM, value2, workFailedEventHandler2);
			}
			while ((object)workFailedEventHandler != workFailedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WorkUnit.WorkFailedEventHandler workFailedEventHandler = _0023_003DzB6s4ltXuApFM;
			WorkUnit.WorkFailedEventHandler workFailedEventHandler2;
			do
			{
				workFailedEventHandler2 = workFailedEventHandler;
				WorkUnit.WorkFailedEventHandler value2 = (WorkUnit.WorkFailedEventHandler)Delegate.Remove(workFailedEventHandler2, value);
				workFailedEventHandler = Interlocked.CompareExchange(ref _0023_003DzB6s4ltXuApFM, value2, workFailedEventHandler2);
			}
			while ((object)workFailedEventHandler != workFailedEventHandler2);
		}
	}

	[Description("Occurs when the read/write progress has changed.")]
	[Category("Workspace")]
	[Obsolete("This event is part of the legacy StartWork/event-based pattern. Use await Workspace.DoWorkAsync(...) instead.")]
	public event WorkUnit.ProgressChangedEventHandler ProgressChanged
	{
		[CompilerGenerated]
		add
		{
			WorkUnit.ProgressChangedEventHandler progressChangedEventHandler = _0023_003DzJKwcJ2U_003D;
			WorkUnit.ProgressChangedEventHandler progressChangedEventHandler2;
			do
			{
				progressChangedEventHandler2 = progressChangedEventHandler;
				WorkUnit.ProgressChangedEventHandler value2 = (WorkUnit.ProgressChangedEventHandler)Delegate.Combine(progressChangedEventHandler2, value);
				progressChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzJKwcJ2U_003D, value2, progressChangedEventHandler2);
			}
			while ((object)progressChangedEventHandler != progressChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WorkUnit.ProgressChangedEventHandler progressChangedEventHandler = _0023_003DzJKwcJ2U_003D;
			WorkUnit.ProgressChangedEventHandler progressChangedEventHandler2;
			do
			{
				progressChangedEventHandler2 = progressChangedEventHandler;
				WorkUnit.ProgressChangedEventHandler value2 = (WorkUnit.ProgressChangedEventHandler)Delegate.Remove(progressChangedEventHandler2, value);
				progressChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzJKwcJ2U_003D, value2, progressChangedEventHandler2);
			}
			while ((object)progressChangedEventHandler != progressChangedEventHandler2);
		}
	}

	[Description("Occurs when the SetView is called.")]
	[Category("Workspace")]
	public event ViewChangedEventHandler ViewChanged
	{
		[CompilerGenerated]
		add
		{
			ViewChangedEventHandler viewChangedEventHandler = _0023_003Dz0pCfd9s_003D;
			ViewChangedEventHandler viewChangedEventHandler2;
			do
			{
				viewChangedEventHandler2 = viewChangedEventHandler;
				ViewChangedEventHandler value2 = (ViewChangedEventHandler)Delegate.Combine(viewChangedEventHandler2, value);
				viewChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz0pCfd9s_003D, value2, viewChangedEventHandler2);
			}
			while ((object)viewChangedEventHandler != viewChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ViewChangedEventHandler viewChangedEventHandler = _0023_003Dz0pCfd9s_003D;
			ViewChangedEventHandler viewChangedEventHandler2;
			do
			{
				viewChangedEventHandler2 = viewChangedEventHandler;
				ViewChangedEventHandler value2 = (ViewChangedEventHandler)Delegate.Remove(viewChangedEventHandler2, value);
				viewChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz0pCfd9s_003D, value2, viewChangedEventHandler2);
			}
			while ((object)viewChangedEventHandler != viewChangedEventHandler2);
		}
	}

	[Description("Occurs when entity selection has changed.")]
	[Category("Workspace")]
	public event SelectionChangedEventHandler SelectionChanged
	{
		[CompilerGenerated]
		add
		{
			SelectionChangedEventHandler selectionChangedEventHandler = _0023_003DzYVdraYc_003D;
			SelectionChangedEventHandler selectionChangedEventHandler2;
			do
			{
				selectionChangedEventHandler2 = selectionChangedEventHandler;
				SelectionChangedEventHandler value2 = (SelectionChangedEventHandler)Delegate.Combine(selectionChangedEventHandler2, value);
				selectionChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzYVdraYc_003D, value2, selectionChangedEventHandler2);
			}
			while ((object)selectionChangedEventHandler != selectionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SelectionChangedEventHandler selectionChangedEventHandler = _0023_003DzYVdraYc_003D;
			SelectionChangedEventHandler selectionChangedEventHandler2;
			do
			{
				selectionChangedEventHandler2 = selectionChangedEventHandler;
				SelectionChangedEventHandler value2 = (SelectionChangedEventHandler)Delegate.Remove(selectionChangedEventHandler2, value);
				selectionChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzYVdraYc_003D, value2, selectionChangedEventHandler2);
			}
			while ((object)selectionChangedEventHandler != selectionChangedEventHandler2);
		}
	}

	protected Workspace()
	{
		_0023_003Dzx03fWAvmSbd9();
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592005));
		Utility.RuntimeInstances.Add(new WeakReference<IWorkspaceInternal>(this));
		new MainClass();
		if (System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Designtime || Process.GetCurrentProcess().ProcessName == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592060))
		{
			_0023_003DzPzGbYk87yMq4 = true;
		}
		_0023_003DzlFa_Yaf4PE_0024O();
		shortcutKeys = new ShortcutKeysSettings();
		MultiTouch = _0023_003DzPxWYkwXbBcqd();
		_0023_003DzOLP90s_0024AN26E = new BorderSettings();
		ButtonStyle = new ButtonSettings();
		_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D = new ViewportList(this);
		_0023_003DznbDxlZQRhlsy = base.Size;
		_0023_003Dz6iZ1ZQQ_003D();
		TempEntities = new TempEntityList();
		_0023_003DzK3OaHhra7VrS = _0023_003DzusLvEi5hoe9_0024();
		ResetMouse3D();
		_0023_003Dzwg1qhxF_0024O_ci();
		for (int i = 0; i < _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length; i++)
		{
			((ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[i]).workspace = this;
		}
		_0023_003Dzwrj5SpW0m4rj();
		_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D = new ObjectManipulator();
		ProgressBar = new ProgressBar();
		ProgressBarCancelButton = _0023_003DzOu2KQJ1A0olqF8wpuQ_003D_003D();
	}

	private bool ShouldSerializeMouse3D()
	{
		return Mouse3D.ShouldSerialize(_0023_003DzSZ1nnqv7aw3F());
	}

	private static Mouse3DSettings _0023_003DzSZ1nnqv7aw3F()
	{
		return new Mouse3DSettings
		{
			AutoCenterOfRotation = true
		};
	}

	private void ResetMouse3D()
	{
		Mouse3D = _0023_003DzSZ1nnqv7aw3F();
		Mouse3D._0023_003DzzGq7V_q1ZaaU(this);
	}

	protected internal virtual void OnMouse3DMove(object sender, MoveEventArgs e)
	{
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count != 0)
		{
			Viewport viewport = _0023_003DzipBYly6zFKAp();
			_0023_003Dzpm_00240_u0_003D._0023_003DzHjfFC64_003D(e._0023_003DzwJX1WcPTuBxj);
			if (_0023_003DzsNY3baF_0024GM7MtcGwGAB4MSE_003D++ == 0)
			{
				_0023_003Dzf5NRO7wxeVa07xknUc_l_0024dqNXOfS();
			}
			_0023_003DzH_ACO1keHrO4();
			_0023_003DztdGp9MI3CH2w = true;
			if (!_0023_003DzFzzfWzVQfgnR.Enabled)
			{
				viewport._0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(viewport.Size.Width / 2, viewport.Size.Height / 2);
				_0023_003DzSGfimhJkGdqe(_0023_003DzipBYly6zFKAp());
			}
			_0023_003DzFzzfWzVQfgnR.Stop();
			_0023_003DzSlNAZVP_0024WkQC();
		}
	}

	protected internal virtual void OnMouse3DButtonUp(object sender, ButtonEventArgs e)
	{
	}

	private void _0023_003DzKE_0024xmMn3Wh2jwuEVLQ_003D_003D(ButtonEventArgs _0023_003Dz1SmHC4c_003D)
	{
		virtualKey virtualKey2 = _0023_003Dz1SmHC4c_003D.VirtualKey;
		if (virtualKey2 == virtualKey.V3DkInvalid)
		{
			return;
		}
		Workspace workspace = _0023_003Dz1hAz1Qd_0024QjMi._0023_003Dz0_0024X6OcgLJhm7();
		if (workspace is Drawing && ((uint)(virtualKey2 - 3) <= 9u || virtualKey2 == virtualKey.V3DkRotate))
		{
			return;
		}
		_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D++;
		Viewport viewport = workspace._0023_003DzipBYly6zFKAp();
		switch (virtualKey2)
		{
		case virtualKey.V3DkDominant:
			_0023_003Dz1hAz1Qd_0024QjMi.SingleAxisFilter = !_0023_003Dz1hAz1Qd_0024QjMi.SingleAxisFilter;
			break;
		case virtualKey.V3DkRotate:
			_0023_003DzipBYly6zFKAp().Rotate.Enabled = !_0023_003DzipBYly6zFKAp().Rotate.Enabled;
			break;
		case virtualKey.V3DkPanzoom:
			_0023_003Dz1hAz1Qd_0024QjMi.Enabled = !_0023_003Dz1hAz1Qd_0024QjMi.Enabled;
			break;
		case virtualKey.V3DkPlus:
			_0023_003Dz1hAz1Qd_0024QjMi.SpeedFactor += 0.25;
			break;
		case virtualKey.V3DkMinus:
			_0023_003Dz1hAz1Qd_0024QjMi.SpeedFactor -= 0.25;
			break;
		case virtualKey.V3DkFit:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				workspace.ZoomFit();
			}
			break;
		case virtualKey.V3DkTop:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.SetView(viewType.Top, fit: true, animate: true);
			}
			break;
		case virtualKey.V3DkBottom:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.SetView(viewType.Bottom, fit: true, animate: true);
			}
			break;
		case virtualKey.V3DkLeft:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.SetView(viewType.Left, fit: true, animate: true);
			}
			break;
		case virtualKey.V3DkRight:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.SetView(viewType.Right, fit: true, animate: true);
			}
			break;
		case virtualKey.V3DkFront:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.SetView(viewType.Front, fit: true, animate: true);
			}
			break;
		case virtualKey.V3DkBack:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.SetView(viewType.Rear, fit: true, animate: true);
			}
			break;
		case virtualKey.V3DkRollCw:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.RotateCamera(viewport.Camera.ViewNormal, -90.0, trackBall: false, animate: true);
			}
			break;
		case virtualKey.V3DkRollCcw:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.RotateCamera(viewport.Camera.ViewNormal, 90.0, trackBall: false, animate: true);
			}
			break;
		case virtualKey.V3DkIso1:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.SetView(viewType.Isometric, fit: true, animate: true);
			}
			break;
		case virtualKey.V3DkIso2:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.SetView(viewType.vcBackFaceBottomLeft, fit: true, animate: true);
			}
			break;
		case virtualKey.V3DkSpinCw:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.Camera.Rotation *= new Quaternion(Vector3D.AxisZ, -90.0);
				if (_0023_003Dz1hAz1Qd_0024QjMi.LockHorizon)
				{
					_0023_003Dzpm_00240_u0_003D._0023_003DzXis_6XIWOgeaY5Yu6A_003D_003D(viewport.Camera.centerOfRotation, viewport.Camera.Rotation);
				}
			}
			break;
		case virtualKey.V3DkSpinCcw:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.Camera.Rotation *= new Quaternion(Vector3D.AxisZ, 90.0);
				if (_0023_003Dz1hAz1Qd_0024QjMi.LockHorizon)
				{
					_0023_003Dzpm_00240_u0_003D._0023_003DzXis_6XIWOgeaY5Yu6A_003D_003D(viewport.Camera.centerOfRotation, viewport.Camera.Rotation);
				}
			}
			break;
		case virtualKey.V3DkTiltCw:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.Camera.Rotation *= new Quaternion(Vector3D.AxisX, -90.0);
				if (_0023_003Dz1hAz1Qd_0024QjMi.LockHorizon)
				{
					_0023_003Dzpm_00240_u0_003D._0023_003DzXis_6XIWOgeaY5Yu6A_003D_003D(viewport.Camera.centerOfRotation, viewport.Camera.Rotation);
				}
			}
			break;
		case virtualKey.V3DkTiltCcw:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				viewport.Camera.Rotation *= new Quaternion(Vector3D.AxisX, 90.0);
				if (_0023_003Dz1hAz1Qd_0024QjMi.LockHorizon)
				{
					_0023_003Dzpm_00240_u0_003D._0023_003DzXis_6XIWOgeaY5Yu6A_003D_003D(viewport.Camera.centerOfRotation, viewport.Camera.Rotation);
				}
			}
			break;
		case virtualKey.V3DkCustomView1Loader:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				Mouse3D._0023_003Dz7CoHeey1Do36(1);
			}
			break;
		case virtualKey.V3DkCustomView2Loader:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				Mouse3D._0023_003Dz7CoHeey1Do36(2);
			}
			break;
		case virtualKey.V3DkCustomView3Loader:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				Mouse3D._0023_003Dz7CoHeey1Do36(3);
			}
			break;
		case virtualKey.V3DkCustomView1Saver:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				Mouse3D._0023_003DzURHD1D0a4usl(1);
			}
			break;
		case virtualKey.V3DkCustomView2Saver:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				Mouse3D._0023_003DzURHD1D0a4usl(2);
			}
			break;
		case virtualKey.V3DkCustomView3Saver:
			if (_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D == 1)
			{
				Mouse3D._0023_003DzURHD1D0a4usl(3);
			}
			break;
		}
		workspace.Invalidate();
		_0023_003DzmOOPAyV7iaPIkhoPBg_003D_003D--;
		Telemetry.Instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592068), Telemetry.moduleType.Generic);
	}

	protected internal virtual void OnMouse3DButtonDown(object sender, ButtonEventArgs e)
	{
		_0023_003DzKE_0024xmMn3Wh2jwuEVLQ_003D_003D(e);
	}

	private void _0023_003DzPI8XNNKQYcxK_0024BXUuw_003D_003D()
	{
		ContextMenuStrip contextMenuStrip = ContextMenuStrip;
		if (contextMenuStrip != null)
		{
			if (contextMenuStrip.Visible)
			{
				contextMenuStrip.Hide();
			}
			else
			{
				contextMenuStrip.Show(System.Windows.Forms.Control.MousePosition);
			}
		}
	}

	internal void _0023_003Dz_XPtrr_DYLmiXjAB3A_003D_003D()
	{
		if (_0023_003DzZUohT3Y_003D == IntPtr.Zero)
		{
			return;
		}
		IntPtr _0023_003Dziaz9rYc_003D = _0023_003DzZUohT3Y_003D;
		try
		{
			_0023_003Dzt56IHQQCjMVX = new _0023_003DzKB5gbX19s0qVrqQGn2o1kUz_00248j1a2nwQKLng_0024XlHe8Ka(_0023_003Dziaz9rYc_003D);
		}
		catch (Exception ex)
		{
			_0023_003Dzt56IHQQCjMVX = null;
			Logger.Instance.Trace(InstanceId, ex.Message);
		}
		if (_0023_003Dzpm_00240_u0_003D == null)
		{
			_0023_003Dzpm_00240_u0_003D = new _0023_003DzR6vCqD_0024QocNK418oYWXyu3JzuZ5R8zQlvlaPbTMC3LOOzvro_Q_003D_003D(this);
		}
		Logger.Instance.Trace(InstanceId, (_0023_003Dzt56IHQQCjMVX == null) ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592127) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348592085));
		if (_0023_003Dzt56IHQQCjMVX == null)
		{
			_0023_003DzZ6Vh_2eG3NkG();
			return;
		}
		_0023_003Dzeszsu8ntnZ3R();
		_0023_003DzIrKiHGdeRRkt();
		_0023_003Dzt56IHQQCjMVX._0023_003Dz5a1bhkAW4pks();
		if (Mouse3D != null)
		{
			_0023_003DzB1m_0024n23EMG5fmyf_00241w_003D_003D();
		}
	}

	internal void _0023_003DzWryg780O_mQdQMSv4lj8Od8_003D(object _0023_003DzxwGby4M_003D, CancelEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003Dzt56IHQQCjMVX._0023_003DzLqNpCTE_003D())
		{
			if (_0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D == null)
			{
				AddMouse3DContextMenuItems();
			}
		}
		else if (_0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D != null)
		{
			RemoveMouse3DContextMenuItems();
		}
	}

	private void _0023_003DzEJfAQkdLUMU_0024NYjHcQ_003D_003D()
	{
		if (_0023_003DzVPcNyaBcNDGL == null)
		{
			bool flag = this is Drawing;
			_0023_003DzVPcNyaBcNDGL = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591877));
			_0023_003DzKk1DQUn5co_aN4nO4w_003D_003D = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648790));
			_0023_003DziwPFZD5quyJUARrhpw_003D_003D = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586046))
			{
				Checked = !flag,
				Enabled = !flag,
				CheckOnClick = true
			};
			_0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647950))
			{
				Checked = true,
				CheckOnClick = true
			};
			_0023_003DzM_0024RAWGUwy2M6VoDO8g_003D_003D = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591891))
			{
				CheckOnClick = true
			};
			_0023_003DzR3te2ECclIvgC98aKjRl1l0_003D = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591912));
			_0023_003DzFGQmQXKrdjacAiDvFmESkVg_003D = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591926));
			_0023_003DzqZgiEmb_0024ukpITsN00Q_003D_003D = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591937));
			_0023_003DzF_0024lPCjNBq_z_0024 = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588005))
			{
				Enabled = !flag
			};
			_0023_003DzoyItBUrB_0024Vm2yfULwZ0OnBU_003D = new ToolStripMenuItem(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591958))
			{
				Enabled = !flag,
				CheckOnClick = true
			};
			_0023_003DzVPcNyaBcNDGL.DropDownItems.AddRange(new ToolStripItem[7]
			{
				_0023_003DziwPFZD5quyJUARrhpw_003D_003D,
				_0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D,
				new ToolStripSeparator(),
				_0023_003DzKk1DQUn5co_aN4nO4w_003D_003D,
				new ToolStripSeparator(),
				_0023_003DzF_0024lPCjNBq_z_0024,
				_0023_003DzoyItBUrB_0024Vm2yfULwZ0OnBU_003D
			});
		}
	}

	protected virtual void AddMouse3DContextMenuItems()
	{
		_0023_003DzEJfAQkdLUMU_0024NYjHcQ_003D_003D();
		_0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D = _0023_003DzVPcNyaBcNDGL;
		if (ContextMenuStrip != null && !ContextMenuStrip.Items.Contains(_0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D))
		{
			if (ContextMenuStrip.Items.Count > 0)
			{
				ContextMenuStrip.Items.Add(new ToolStripSeparator());
			}
			ContextMenuStrip.Items.Add(_0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D);
			_0023_003DzrWpJUWjy6YMhgAFznA_003D_003D();
		}
	}

	private void _0023_003DzrWpJUWjy6YMhgAFznA_003D_003D()
	{
		_0023_003DziwPFZD5quyJUARrhpw_003D_003D.CheckedChanged += delegate
		{
			_0023_003DzipBYly6zFKAp().Rotate.Enabled = _0023_003DziwPFZD5quyJUARrhpw_003D_003D.Checked;
			Invalidate();
		};
		_0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D.CheckedChanged += delegate
		{
			Mouse3D.Enabled = _0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D.Checked;
		};
		string text = string.Empty;
		double speedFactor = Mouse3D.SpeedFactor;
		using (IEnumerator<int> enumerator = Enumerable.Range(0, Enum.GetValues(typeof(tdx.eSpeed)).Length).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				_0023_003DzFS_0024a4CDzXCfMy_0024ciqEQNy88_003D _0023_003DzFS_0024a4CDzXCfMy_0024ciqEQNy88_003D2 = new _0023_003DzFS_0024a4CDzXCfMy_0024ciqEQNy88_003D();
				_0023_003DzFS_0024a4CDzXCfMy_0024ciqEQNy88_003D2._0023_003DzKdgtcDsi34jL = this;
				_0023_003DzFS_0024a4CDzXCfMy_0024ciqEQNy88_003D2._0023_003DzcU2W_0024IwZm_0024cF = enumerator.Current;
				text += _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591971);
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(text)
				{
					Checked = (tdx._0023_003DzUiPCQHxNFWkm[_0023_003DzFS_0024a4CDzXCfMy_0024ciqEQNy88_003D2._0023_003DzcU2W_0024IwZm_0024cF] == (float)speedFactor)
				};
				toolStripMenuItem.Click += _0023_003DzFS_0024a4CDzXCfMy_0024ciqEQNy88_003D2._0023_003DzbRFNoVK1vq75tqWpd5rTRjXWyg4G;
				_0023_003DzKk1DQUn5co_aN4nO4w_003D_003D.DropDownItems.Add(toolStripMenuItem);
				_0023_003DzKk1DQUn5co_aN4nO4w_003D_003D.DropDownOpening += _0023_003DzXaS7SkTsX7tQ7Cxr15liOQSJw9P37ae0Jg_003D_003D;
			}
		}
		_0023_003DzM_0024RAWGUwy2M6VoDO8g_003D_003D.CheckedChanged += delegate
		{
			Mouse3D.AutoCenterOfRotation = _0023_003DzM_0024RAWGUwy2M6VoDO8g_003D_003D.Checked;
		};
		_0023_003DzF_0024lPCjNBq_z_0024.DropDownItems.AddRange(new ToolStripItem[5]
		{
			_0023_003DzM_0024RAWGUwy2M6VoDO8g_003D_003D,
			new ToolStripSeparator(),
			_0023_003DzR3te2ECclIvgC98aKjRl1l0_003D,
			_0023_003DzFGQmQXKrdjacAiDvFmESkVg_003D,
			_0023_003DzqZgiEmb_0024ukpITsN00Q_003D_003D
		});
		_0023_003DzF_0024lPCjNBq_z_0024.DropDownOpening += _0023_003Dzb56omDfq3FEePSqfOkizywdQWBsJ;
		_0023_003DzR3te2ECclIvgC98aKjRl1l0_003D.Click += delegate
		{
			Mouse3D.CenterOfRotationVisibilityMode = centerOfRotationVisibilityType.Always;
			Invalidate();
		};
		_0023_003DzFGQmQXKrdjacAiDvFmESkVg_003D.Click += _0023_003DzUtPyH7lsvp_3huiF6inAKHMSnnWs;
		_0023_003DzqZgiEmb_0024ukpITsN00Q_003D_003D.Click += delegate
		{
			Mouse3D.CenterOfRotationVisibilityMode = centerOfRotationVisibilityType.Never;
			Invalidate();
		};
		_0023_003DzoyItBUrB_0024Vm2yfULwZ0OnBU_003D.CheckedChanged += _0023_003DzqgPEJ1POuqIuBiGNtfIDOe3g56vn;
		ContextMenuStrip.Opening += delegate
		{
			_0023_003DziwPFZD5quyJUARrhpw_003D_003D.Checked = _0023_003DzipBYly6zFKAp().Rotate.Enabled;
			_0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D.Checked = Mouse3D.Enabled;
			_0023_003DzoyItBUrB_0024Vm2yfULwZ0OnBU_003D.Checked = Mouse3D.LockHorizon;
		};
	}

	protected virtual void RemoveMouse3DContextMenuItems()
	{
		if (ContextMenuStrip != null)
		{
			if (ContextMenuStrip.Items.Contains(_0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D))
			{
				ContextMenuStrip.Items.Remove(_0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D);
			}
			_0023_003DzY4Xg8GrhIxndJ_0024JHWQ_003D_003D = null;
			if (ContextMenuStrip.Items.Count == 0)
			{
				ContextMenuStrip = null;
			}
		}
	}

	private void _0023_003DzZ6Vh_2eG3NkG()
	{
		_0023_003Dzeszsu8ntnZ3R();
		Mouse3DMove -= OnMouse3DMove;
		Mouse3DButtonDown -= OnMouse3DButtonDown;
		Mouse3DButtonUp -= OnMouse3DButtonUp;
		if (ContextMenuStrip != null)
		{
			ContextMenuStrip.Opening -= _0023_003DzWryg780O_mQdQMSv4lj8Od8_003D;
		}
	}

	public override IntPtr WndProcMouse3D(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		if (_0023_003Dzt56IHQQCjMVX != null)
		{
			_0023_003Dzt56IHQQCjMVX._0023_003Dzmar0fpw_003D(msg, lParam, this);
		}
		return IntPtr.Zero;
	}

	internal void _0023_003Dz8SWerfo_0024SSzY(_0023_003DzKB5gbX19s0qVrqQGn2o1kUz_00248j1a2nwQKLng_0024XlHe8Ka _0023_003Dze0PRU5CrnxPN, MoveEventArgs _0023_003DzWMYfdXl_00245Mfo)
	{
		if (_0023_003DzNlD1nBz7pQOD != null)
		{
			_0023_003DzNlD1nBz7pQOD(_0023_003Dze0PRU5CrnxPN, _0023_003DzWMYfdXl_00245Mfo);
		}
	}

	internal void _0023_003DzzrFpVY413MD3PVoUHw_003D_003D(_0023_003DzKB5gbX19s0qVrqQGn2o1kUz_00248j1a2nwQKLng_0024XlHe8Ka _0023_003Dze0PRU5CrnxPN, ButtonEventArgs _0023_003Dzl0F5RFzlt4S9)
	{
		if (_0023_003DztOrlz_zSFCUN != null)
		{
			_0023_003DztOrlz_zSFCUN(_0023_003Dze0PRU5CrnxPN, _0023_003Dzl0F5RFzlt4S9);
		}
	}

	internal void _0023_003DzLubom8zz1_1LgTvEQQ_003D_003D(_0023_003DzKB5gbX19s0qVrqQGn2o1kUz_00248j1a2nwQKLng_0024XlHe8Ka _0023_003Dze0PRU5CrnxPN, ButtonEventArgs _0023_003Dzl0F5RFzlt4S9)
	{
		if (_0023_003Dz0sL73kYUF3eZ != null)
		{
			_0023_003Dz0sL73kYUF3eZ(_0023_003Dze0PRU5CrnxPN, _0023_003Dzl0F5RFzlt4S9);
		}
	}

	internal bool _0023_003DzCFByznJfli3u()
	{
		int num;
		if (_0023_003Dzt56IHQQCjMVX != null)
		{
			num = (_0023_003Dzt56IHQQCjMVX._0023_003DzLqNpCTE_003D() ? 1 : 0);
			if (num != 0)
			{
				if (ContextMenuStrip == null)
				{
					ContextMenuStrip = new ContextMenuStrip();
				}
				ContextMenuStrip.Opening -= _0023_003DzWryg780O_mQdQMSv4lj8Od8_003D;
				ContextMenuStrip.Opening += _0023_003DzWryg780O_mQdQMSv4lj8Od8_003D;
			}
		}
		else
		{
			num = 0;
		}
		return (byte)num != 0;
	}

	private bool ShouldSerializeMultiTouch()
	{
		return MultiTouch._0023_003Dz4XAvJ5aCRLKs(_0023_003DzPxWYkwXbBcqd());
	}

	private void ResetMultiTouch()
	{
		MultiTouch = _0023_003DzPxWYkwXbBcqd();
	}

	private static MultiTouchSettings _0023_003DzPxWYkwXbBcqd()
	{
		return new MultiTouchSettings(enableMultiTouchMovements: true);
	}

	internal void _0023_003DzXhyp_i4yy7aUWQXJqA_003D_003D(TouchEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003Dz_0024DKbcuTzjqgK != null)
		{
			_0023_003Dz_0024DKbcuTzjqgK(this, _0023_003Dz1SmHC4c_003D);
		}
	}

	internal void _0023_003DzVrPU0EZbFlyD3ePrBA_003D_003D(TouchEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003Dz_0024inpPjY5h8Jv != null)
		{
			_0023_003Dz_0024inpPjY5h8Jv(this, _0023_003Dz1SmHC4c_003D);
		}
	}

	internal void _0023_003DzMCd3y2nX_0024GfE(TouchEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003DzoU40Uhh8GTY7 != null)
		{
			_0023_003DzoU40Uhh8GTY7(this, _0023_003Dz1SmHC4c_003D);
		}
	}

	internal void _0023_003DzUjX3DZgNhR_0024eQkwpZQ_003D_003D(MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003DzlOvHZEswzSlhuG2jJA_003D_003D != null)
		{
			_0023_003DzlOvHZEswzSlhuG2jJA_003D_003D(this, _0023_003Dz1SmHC4c_003D);
		}
	}

	internal void _0023_003DzYm0yfyqVvodd31OPxA_003D_003D(MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003Dzl1meGtYJNgTP != null)
		{
			_0023_003Dzl1meGtYJNgTP(this, _0023_003Dz1SmHC4c_003D);
		}
	}

	internal void _0023_003DzoOUvN_zrx2mU0zQebQ_003D_003D()
	{
		_0023_003DzU_0024SPQYmSpAZq();
		if (MultiTouch.Enabled)
		{
			MultiTouchMove += OnMultiTouchMove;
			MultiTouchDown += OnMultiTouchDown;
			MultiTouchUp += OnMultiTouchUp;
			MultiTouchClick += OnMultiTouchClick;
			MultiTouchDoubleClick += OnMultiTouchDoubleClick;
		}
	}

	internal void _0023_003DzU_0024SPQYmSpAZq()
	{
		if (_0023_003Dz32fCUXg4rkVM != null)
		{
			MultiTouchMove -= OnMultiTouchMove;
			MultiTouchDown -= OnMultiTouchDown;
			MultiTouchUp -= OnMultiTouchUp;
			MultiTouchClick -= OnMultiTouchClick;
			MultiTouchDoubleClick -= OnMultiTouchDoubleClick;
		}
	}

	internal void _0023_003Dz9eDJ96xXX4Se(TouchEventArgs _0023_003DzIa5IVBg_003D)
	{
		if (_0023_003Dz_0024DKbcuTzjqgK != null && _0023_003DzIa5IVBg_003D.IsTouchDown)
		{
			_0023_003Dz_0024DKbcuTzjqgK(this, _0023_003DzIa5IVBg_003D);
		}
		if (_0023_003DzoU40Uhh8GTY7 != null && _0023_003DzIa5IVBg_003D.IsTouchMove)
		{
			_0023_003DzoU40Uhh8GTY7(this, _0023_003DzIa5IVBg_003D);
		}
		if (_0023_003Dz_0024inpPjY5h8Jv != null && _0023_003DzIa5IVBg_003D.IsTouchUp)
		{
			_0023_003Dz_0024inpPjY5h8Jv(this, _0023_003DzIa5IVBg_003D);
		}
	}

	protected internal virtual void OnMultiTouchMove(object sender, TouchEventArgs e)
	{
		_0023_003Dz32fCUXg4rkVM._0023_003DzKCFeXLqW_00240pK(sender, e);
	}

	protected internal virtual void OnMultiTouchDown(object sender, TouchEventArgs e)
	{
		_0023_003Dz32fCUXg4rkVM._0023_003DzUg2nzQZLoTnT(sender, e);
	}

	protected internal virtual void OnMultiTouchUp(object sender, TouchEventArgs e)
	{
		_0023_003Dz32fCUXg4rkVM._0023_003Dzdu4bLzoDDwoi(sender, e);
	}

	protected internal virtual void OnMultiTouchClick(object sender, MouseEventArgs e)
	{
		_0023_003Dz32fCUXg4rkVM._0023_003DzEuQb9yE_003D(sender, e);
	}

	protected internal virtual void OnMultiTouchDoubleClick(object sender, MouseEventArgs e)
	{
		_0023_003Dz32fCUXg4rkVM?._0023_003Dz1B3OeaD67M_T(sender, e);
	}

	private protected abstract void _0023_003Dz6iZ1ZQQ_003D();

	private protected void _0023_003Dzjgaq1UhfISUG(Document _0023_003Dzv5pi7wY_003D)
	{
		if (_0023_003Dzv5pi7wY_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003Dzv5pi7wY_003D.workspace != null)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591994));
		}
		foreach (Block block in _0023_003Dzv5pi7wY_003D.Blocks)
		{
			BlockKeyedCollection.CheckBlockName(block.Name, this);
		}
		_0023_003DzgfObf7s_003D?.SetWorkspace(null);
		_0023_003DzgfObf7s_003D = _0023_003Dzv5pi7wY_003D;
		_0023_003DzgfObf7s_003D.SetWorkspace(this);
	}

	internal bool _0023_003DzCTpPcMUdDrcJ()
	{
		return base.Renderer == rendererType.OpenGL;
	}

	private protected override bool _0023_003Dz8Q16RtM94O0K()
	{
		if (!_0023_003DzjC4hA2I_003D.errorInPaint)
		{
			return _0023_003DzyYEVfLG1UTpY;
		}
		return true;
	}

	internal override void _0023_003DzIRSxr5GrGB6E(IntPtr _0023_003Dziaz9rYc_003D)
	{
		_0023_003DzZUohT3Y_003D = _0023_003Dziaz9rYc_003D;
		Logger.Instance.Info(InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591286), _0023_003Dziaz9rYc_003D));
	}

	protected IntPtr GetParentHandle()
	{
		return _0023_003DzZUohT3Y_003D;
	}

	internal int _0023_003DzNwtRJ3cLTrAy()
	{
		return base.Size.Height;
	}

	internal int _0023_003Dz0P1LCYH__O4t()
	{
		return base.Size.Width;
	}

	protected internal void RestoreCursor(CursorContainer prev)
	{
		waitCursorType waitCursorType2 = _0023_003DzCf__tCZh1QRt;
		if (waitCursorType2 == waitCursorType.RegenOnly || waitCursorType2 == waitCursorType.RegenAndBoundingBox)
		{
			_0023_003DzV0Su6Jg_003D(prev);
		}
	}

	protected internal CursorContainer SetWaitCursor()
	{
		CursorContainer result = _0023_003DzzT36TNE_003D();
		waitCursorType waitCursorType2 = _0023_003DzCf__tCZh1QRt;
		if (waitCursorType2 == waitCursorType.RegenOnly || waitCursorType2 == waitCursorType.RegenAndBoundingBox)
		{
			result = _0023_003DzFqaEE7IhVORj(cursorType.Wait);
		}
		return result;
	}

	internal override bool _0023_003DzJS1ojzsV_0024_85(int _0023_003Dz1xK0BLg_003D, IntPtr _0023_003DzNAnADu0_003D)
	{
		if (_0023_003Dzt56IHQQCjMVX == null)
		{
			return false;
		}
		_0023_003Dzt56IHQQCjMVX._0023_003Dzmar0fpw_003D(_0023_003Dz1xK0BLg_003D, _0023_003DzNAnADu0_003D, this);
		return false;
	}

	public static Assembly GetAssembly(out string product, out string title, out string company, out Version version)
	{
		Assembly assembly = Assembly.GetAssembly(typeof(Workspace));
		AssemblyName name = assembly.GetName();
		version = name.Version;
		product = ((AssemblyProductAttribute)System.Attribute.GetCustomAttribute(assembly, typeof(AssemblyProductAttribute))).Product;
		title = ((AssemblyTitleAttribute)System.Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute))).Title;
		title = title.Replace(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591319), string.Empty);
		company = ((AssemblyCompanyAttribute)System.Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute))).Company;
		return assembly;
	}

	internal static string _0023_003DzKg5Cwe0_003D(bool _0023_003DzNpNehP210092, bool _0023_003DzEgJiPT7OwBRN)
	{
		GetAssembly(out var _, out var title, out var company, out var version);
		title = title.Replace(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591336), string.Empty);
		string text = string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622780), title, version);
		if (_0023_003DzNpNehP210092 && !string.IsNullOrEmpty(company))
		{
			text = string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591353), text, company);
		}
		if (_0023_003DzEgJiPT7OwBRN)
		{
			text += _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591110);
		}
		return text;
	}

	internal void _0023_003DzXDwbax_0024fbiw9g2IBIQ_003D_003D()
	{
		if (_0023_003DzOf9Dg_0024c_0024lV_b != null)
		{
			_0023_003DzOf9Dg_0024c_0024lV_b(this);
		}
	}

	internal BlockKeyedCollection _0023_003DzoE3BE__0024RS_DJ()
	{
		BlockKeyedCollection blockKeyedCollection = _0023_003DzOA_ac7k_003D;
		if (blockKeyedCollection != null && blockKeyedCollection.Count == 0)
		{
			BlockKeyedCollection blockKeyedCollection2 = _0023_003DznJLjYKflIJCP;
			if (blockKeyedCollection2 != null && blockKeyedCollection2.Count == 0)
			{
				return Blocks;
			}
		}
		BlockKeyedCollection blockKeyedCollection3 = new BlockKeyedCollection(Blocks);
		if (_0023_003DzOA_ac7k_003D != null)
		{
			blockKeyedCollection3.AddRange(_0023_003DzOA_ac7k_003D);
		}
		if (_0023_003DznJLjYKflIJCP != null)
		{
			blockKeyedCollection3.AddRange(_0023_003DznJLjYKflIJCP);
		}
		return blockKeyedCollection3;
	}

	private List<string> _0023_003Dzt9ZUN442yoD1b0DsCQ_003D_003D()
	{
		List<string> list = new List<string>();
		list.AddRange(Blocks.BaseDictionary.Keys);
		list.AddRange(_0023_003DzOA_ac7k_003D.BaseDictionary.Keys);
		list.AddRange(_0023_003DznJLjYKflIJCP.BaseDictionary.Keys);
		return list;
	}

	public BlockReference RemoveJittering(string blockName = null)
	{
		return _0023_003Dz9qs3_6tLCSCs5uupo3mOZ4U_003D(blockName, null);
	}

	public void RemoveJittering(BlockReference blockReference)
	{
		_0023_003Dz9qs3_6tLCSCs5uupo3mOZ4U_003D(blockReference.BlockName, blockReference);
	}

	internal BlockReference _0023_003Dz9qs3_6tLCSCs5uupo3mOZ4U_003D(string _0023_003DzeQmEh8Q_003D, BlockReference _0023_003DzNZCWrS4_003D)
	{
		BlockReference blockReference = _0023_003DzNZCWrS4_003D;
		bool flag = false;
		if (_0023_003DzNZCWrS4_003D != null)
		{
			_0023_003DzeQmEh8Q_003D = _0023_003DzNZCWrS4_003D.BlockName;
			if (!Entities.Contains(_0023_003DzNZCWrS4_003D))
			{
				Entities.Add(_0023_003DzNZCWrS4_003D);
				flag = true;
			}
		}
		else
		{
			if (Entities.Count == 0)
			{
				return null;
			}
			if (string.IsNullOrEmpty(_0023_003DzeQmEh8Q_003D))
			{
				_0023_003DzeQmEh8Q_003D = Utility.GetUnusedBlockName(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591149), Blocks);
			}
			else if (Blocks.Contains(_0023_003DzeQmEh8Q_003D))
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591159));
			}
		}
		List<string> list = new List<string>();
		if (_0023_003DzNZCWrS4_003D != null)
		{
			Block block = Blocks[_0023_003DzeQmEh8Q_003D];
			list.Add(_0023_003DzeQmEh8Q_003D);
			foreach (Entity entity2 in block.Entities)
			{
				if (entity2 is BlockReference blockReference2)
				{
					blockReference2.GetBlocksNamesInternal(Blocks, list);
				}
			}
		}
		else
		{
			List<int> list2 = new List<int>();
			for (int i = 0; i < Entities.Count; i++)
			{
				Entity entity = Entities[i];
				if (entity.Selected)
				{
					list2.Add(i);
					entity.Selected = false;
					if (entity is BlockReference blockReference3)
					{
						blockReference3.GetBlocksNamesInternal(Blocks, list);
					}
				}
			}
			if (list2.Count == 0)
			{
				return null;
			}
			Block block2 = new Block(_0023_003DzeQmEh8Q_003D, 0.0, 0.0, 0.0);
			Blocks.Add(block2);
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				int num2 = list2[num];
				block2.Entities.Add(Entities[num2]);
				Entities.RemoveAtNoDispose(num2);
			}
			list.Add(_0023_003DzeQmEh8Q_003D);
			blockReference = new BlockReference(0.0, 0.0, 0.0, _0023_003DzeQmEh8Q_003D, 0.0);
			Entities.Add(blockReference);
		}
		Dictionary<string, Point3D> dictionary = new Dictionary<string, Point3D>();
		Point3D point3D = Point3D.Origin;
		foreach (string item in list)
		{
			Block block3 = Blocks[item];
			Point3D minValue = Point3D.MinValue;
			Point3D maxValue = Point3D.MaxValue;
			List<Point3D> list3 = new List<Point3D>();
			if (block3.Entities.Count == 0)
			{
				continue;
			}
			foreach (Entity entity3 in block3.Entities)
			{
				if (entity3.Visible && Layers[entity3.LayerName].Visible && entity3.BoxMin != null && entity3.BoxMin != Point3D.MinValue)
				{
					list3.Add(entity3.BoxMin);
					list3.Add(entity3.BoxMax);
				}
			}
			Utility.UpdateMinMax(null, list3, list3.Count, maxValue, minValue);
			Point3D point3D2 = Point3D.MidPoint(maxValue, minValue);
			if (item == _0023_003DzeQmEh8Q_003D)
			{
				point3D = point3D2;
			}
			dictionary.Add(item, point3D2);
			foreach (Entity entity4 in block3.Entities)
			{
				entity4.Translate(0.0 - point3D2.X, 0.0 - point3D2.Y, 0.0 - point3D2.Z);
			}
		}
		foreach (string item2 in list)
		{
			foreach (Entity entity5 in Blocks[item2].Entities)
			{
				if (!(entity5 is BlockReference))
				{
					continue;
				}
				BlockReference blockReference4 = (BlockReference)entity5;
				if (blockReference4.Attributes.Count <= 0 || !dictionary.ContainsKey(blockReference4.BlockName))
				{
					continue;
				}
				Point3D point3D3 = dictionary[blockReference4.BlockName];
				foreach (KeyValuePair<string, AttributeReference> attribute in blockReference4.Attributes)
				{
					attribute.Value.InsertionPoint -= point3D3;
				}
			}
		}
		foreach (string item3 in list)
		{
			Block block4 = Blocks[item3];
			if (!dictionary.ContainsKey(item3))
			{
				continue;
			}
			foreach (Entity entity6 in block4.Entities)
			{
				if (entity6 is BlockReference)
				{
					BlockReference blockReference5 = (BlockReference)entity6;
					if (dictionary.ContainsKey(blockReference5.BlockName))
					{
						Point3D point3D4 = dictionary[blockReference5.BlockName];
						blockReference5.Transformation *= (Transformation)new Translation(point3D4.X, point3D4.Y, point3D4.Z);
						blockReference5.RegenMode = regenType.RegenAndCompile;
					}
				}
			}
		}
		blockReference.Transformation *= (Transformation)new Translation(point3D.X, point3D.Y, point3D.Z);
		_0023_003DzVGqbSNIFp89qR5QDdaXWS6tROewlCLVTlw_003D_003D(Blocks[blockReference.BlockName]);
		blockReference.RegenMode = regenType.RegenAndCompile;
		Entities.Regen();
		if (flag)
		{
			Entities.RemoveNoDispose(blockReference);
		}
		return blockReference;
	}

	private void _0023_003DzVGqbSNIFp89qR5QDdaXWS6tROewlCLVTlw_003D_003D(Block _0023_003DzYsabNug_003D)
	{
		foreach (Entity entity in _0023_003DzYsabNug_003D.Entities)
		{
			if (!(entity is Brep))
			{
				if (entity is BlockReference blockReference)
				{
					_0023_003DzVGqbSNIFp89qR5QDdaXWS6tROewlCLVTlw_003D_003D(Blocks[blockReference.BlockName]);
				}
			}
			else
			{
				entity.RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	internal void _0023_003DzySA_0024LLKpRxqJbYvt2g_003D_003D(string _0023_003DzD8mZsz8_003D)
	{
		if (_0023_003DzD8mZsz8_003D == Document.internalElementsLayerName)
		{
			return;
		}
		Document.internalElementsLayerName = _0023_003DzD8mZsz8_003D;
		LayerKeyedCollection.UpdateEntitiesLayerName(_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Entities, Document.internalElementsLayerName);
		LayerKeyedCollection.UpdateEntitiesLayerName(_0023_003DzG6pm3fB_0024JDYx85tz2g_003D_003D.clippingPlaneMesh, Document.internalElementsLayerName);
		LayerKeyedCollection.UpdateEntitiesLayerName(_0023_003DzUuD80DLRm9m0Ctp_0024LQ_003D_003D.clippingPlaneMesh, Document.internalElementsLayerName);
		LayerKeyedCollection.UpdateEntitiesLayerName(_0023_003DzecljuDpEX8THFTC1Bg_003D_003D.clippingPlaneMesh, Document.internalElementsLayerName);
		LayerKeyedCollection.UpdateEntitiesLayerName(_0023_003Dz7_0024B6af_0024DoIkBDt98sA_003D_003D.clippingPlaneMesh, Document.internalElementsLayerName);
		LayerKeyedCollection.UpdateEntitiesLayerName(_0023_003DzFcrMFMgYL_8vDuzo_0024A_003D_003D.clippingPlaneMesh, Document.internalElementsLayerName);
		LayerKeyedCollection.UpdateEntitiesLayerName(_0023_003DzJD9deTMAEJ3hlvoP_0024A_003D_003D.clippingPlaneMesh, Document.internalElementsLayerName);
		foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
		{
			ViewCubeIcon viewCubeIcon = item.ViewCubeIcon;
			if (viewCubeIcon != null)
			{
				LayerKeyedCollection.UpdateEntitiesLayerName(viewCubeIcon.Entities, Document.internalElementsLayerName);
				LayerKeyedCollection.UpdateEntitiesLayerName(viewCubeIcon._0023_003DzE2brWRjSvZMG(), Document.internalElementsLayerName);
			}
			OriginSymbol originSymbol = item.OriginSymbol;
			if (originSymbol != null)
			{
				LayerKeyedCollection.UpdateEntitiesLayerName(originSymbol.Entities, Document.internalElementsLayerName);
			}
			CoordinateSystemIcon coordinateSystemIcon = item.CoordinateSystemIcon;
			if (coordinateSystemIcon != null)
			{
				LayerKeyedCollection.UpdateEntitiesLayerName(coordinateSystemIcon.Entities, Document.internalElementsLayerName);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public sealed override bool IsDesignMode()
	{
		return _0023_003DzPzGbYk87yMq4;
	}

	private void _0023_003Dzx03fWAvmSbd9()
	{
		InstanceId = _0023_003DzjC4hA2I_003D.InstanceId;
		Logger.Instance.WriteHeader();
		Logger.Instance.Info(InstanceId, _0023_003DzKg5Cwe0_003D(_0023_003DzNpNehP210092: true, _0023_003DzEgJiPT7OwBRN: false));
	}

	internal virtual void _0023_003DzSJDeNOUaWXnt()
	{
		_0023_003Dzgg0qV0T_00248ave = base.RenderContext.CreateEntityGraphicsData(this);
	}

	private void _0023_003DzmIjq6yoKtj3_(object _0023_003Dz_H763Oc_003D)
	{
		if (_0023_003Dz3ihdp7ALIDhJ != null)
		{
			_0023_003Dz3ihdp7ALIDhJ.Dispose();
			_0023_003Dz3ihdp7ALIDhJ = null;
		}
		Invalidate();
	}

	internal bool _0023_003DzPxrSykdhxj_0024ErGq9Jg_003D_003D(bool _0023_003DzKgAu6qDy__0024H_0024)
	{
		bool result = false;
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D != null)
		{
			foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
			{
				result = item._0023_003DzPxrSykdhxj_0024ErGq9Jg_003D_003D(_0023_003DzKgAu6qDy__0024H_0024);
			}
		}
		return result;
	}

	private void _0023_003Dzwg1qhxF_0024O_ci()
	{
		object[] _0023_003DzwBouG0w_003D = new object[1] { this };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "=T/7!q\"ach", _0023_003DzwBouG0w_003D);
	}

	internal static void _0023_003DzWx3BmFGxQvWH(string _0023_003DzCxIp_0024rg_003D, TraceLevel _0023_003DzzoqmPiX87PSe, Exception _0023_003DzHwrKer4_003D, object[] _0023_003Dzs9Vs9Ak_003D)
	{
		if ((bool)_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzTIoStId_0024_0024GHgBSutm03Gs9I_003D(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "OT#1Yq\"acX", null))
		{
			switch (_0023_003DzzoqmPiX87PSe)
			{
			case TraceLevel.Error:
				Logger.Instance.Error(_0023_003DzCxIp_0024rg_003D, _0023_003DzHwrKer4_003D, _0023_003Dzs9Vs9Ak_003D);
				break;
			case TraceLevel.Warning:
				Logger.Instance.Warn(_0023_003DzCxIp_0024rg_003D, _0023_003DzHwrKer4_003D, _0023_003Dzs9Vs9Ak_003D);
				break;
			case TraceLevel.Info:
				Logger.Instance.Info(_0023_003DzCxIp_0024rg_003D, _0023_003Dzs9Vs9Ak_003D);
				break;
			case TraceLevel.Verbose:
				Logger.Instance.Trace(_0023_003DzCxIp_0024rg_003D, _0023_003Dzs9Vs9Ak_003D);
				break;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591201));
		if (disposing)
		{
			if (_0023_003DzP5yJ9F4_003D != null)
			{
				_0023_003DzP5yJ9F4_003D.Dispose();
			}
			_0023_003DzyCZYynHYeTy_(_0023_003DzBpmu52eXbLog);
		}
		if (ProgressBarCancelButton != null)
		{
			ProgressBarCancelButton.Dispose();
			ProgressBarCancelButton = null;
		}
		base.Dispose(disposing);
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591491));
		WeakReference<IWorkspaceInternal> weakReference = Utility.RuntimeInstances.FirstOrDefault((WeakReference<IWorkspaceInternal> _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D.TryGetTarget(out var target) && target == this);
		if (weakReference == null)
		{
			Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591527));
		}
		Utility.RuntimeInstances = new ConcurrentBag<WeakReference<IWorkspaceInternal>>(Utility.RuntimeInstances.Except(new WeakReference<IWorkspaceInternal>[1] { weakReference }));
	}

	private void _0023_003DzyCZYynHYeTy_(_0023_003DzenckdRCXoIVHI3cZbQ_003D_003D _0023_003Dz5bKogamXkVLs)
	{
		_0023_003Dz_TfVrsMySSfafaJ98dQk5Lg_003D CS_0024_003C_003E8__locals6 = new _0023_003Dz_TfVrsMySSfafaJ98dQk5Lg_003D();
		CS_0024_003C_003E8__locals6._0023_003DzKdgtcDsi34jL = this;
		CS_0024_003C_003E8__locals6._0023_003Dz5bKogamXkVLs = _0023_003Dz5bKogamXkVLs;
		if (IsBusy && _0023_003DzwFKdhc8_003D)
		{
			new Thread((ThreadStart)delegate
			{
				CS_0024_003C_003E8__locals6._0023_003DzKdgtcDsi34jL._0023_003DzKDiCijSjQLjc.WaitOne();
				CS_0024_003C_003E8__locals6._0023_003DzKdgtcDsi34jL._0023_003DzKDiCijSjQLjc.Set();
				CS_0024_003C_003E8__locals6._0023_003Dz5bKogamXkVLs();
			}).Start();
		}
		else
		{
			CS_0024_003C_003E8__locals6._0023_003Dz5bKogamXkVLs();
		}
	}

	internal override void _0023_003DzBpmu52eXbLog()
	{
		base._0023_003DzBpmu52eXbLog();
		_0023_003DzmNZD0Zs_003D?.MakeCurrent();
		Document.SetWorkspace(null);
		_0023_003DzqYQgL_pXJcCP(_0023_003DzNir3dPKLkVT3: true);
		_0023_003DzbdLgm9c_003D.Dispose();
		_0023_003DzK3OaHhra7VrS.Dispose();
		ParallelConveHull.Instance.Dispose(this);
		_0023_003DzvKRiFE5qp2u2XyCfhw_003D_003D(_0023_003DzgKkl_0024ivLmKr3: false, _0023_003DzIdFNsJJS3mub: true);
		_0023_003DzeDju_XcuxmQA?.Dispose();
		for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
		{
			_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i].Dispose();
		}
		if (IsBusy)
		{
			ProgressBar.cancelling = true;
			_0023_003DzIZDfsMhRoEGn?.Cancel();
			_0023_003DzKDiCijSjQLjc.WaitOne();
		}
		_0023_003DzxIG92rhdr_0024Fd = null;
		try
		{
			_0023_003DzIZDfsMhRoEGn?.Dispose();
		}
		catch
		{
		}
		_0023_003DzIZDfsMhRoEGn = null;
		if (_0023_003DzKDiCijSjQLjc != null)
		{
			_0023_003DzKDiCijSjQLjc.Dispose();
			_0023_003DzKDiCijSjQLjc = null;
		}
		if (_0023_003DzO_o8M3HUNFVt != null)
		{
			_0023_003DzO_o8M3HUNFVt.Dispose();
		}
		if (_0023_003DzPHIgywQ0bPFl != null)
		{
			_0023_003DzPHIgywQ0bPFl.Dispose();
		}
		if (_0023_003DzBlHCDVjJXeoG != null)
		{
			_0023_003DzBlHCDVjJXeoG.Dispose();
		}
		if (_0023_003DzkP4DGwYcuX5B != null)
		{
			_0023_003DzkP4DGwYcuX5B.Dispose();
		}
		if (_0023_003DzAekJM0ZtENTE != null)
		{
			_0023_003DzAekJM0ZtENTE.Dispose();
		}
		_0023_003DzO_o8M3HUNFVt = null;
		_0023_003DzPHIgywQ0bPFl = null;
		_0023_003DzBlHCDVjJXeoG = null;
		_0023_003DzkP4DGwYcuX5B = null;
		_0023_003DzAekJM0ZtENTE = null;
		_0023_003DzD157GIliOpnX?.Dispose();
		_0023_003DzD157GIliOpnX = null;
		if (_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D != null)
		{
			_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Dispose();
		}
		FreeCursors();
		_0023_003Dzi2r38NMlGv6B();
	}

	private void _0023_003DzvxT4VQo_003D(ref Cursor _0023_003DzlwNtVtI_003D)
	{
		if (!(_0023_003DzlwNtVtI_003D == null))
		{
			if (!_0023_003DzSslJtjQ1hZUF.Contains(_0023_003DzlwNtVtI_003D))
			{
				_0023_003DzlwNtVtI_003D?.Dispose();
			}
			_0023_003DzlwNtVtI_003D = null;
		}
	}

	protected override void FreeCursors()
	{
		_0023_003DzvxT4VQo_003D(ref _0023_003DzByXVr0E_0024Xvje);
		_0023_003DzvxT4VQo_003D(ref _0023_003DzCRjLB8xmFyn8);
		_0023_003DzvxT4VQo_003D(ref _0023_003DzPK2U1X_CaUvq);
		_0023_003DzvxT4VQo_003D(ref _0023_003DzOuCsi3Nw7q_0024xhQQx0A_003D_003D);
		_0023_003DzvxT4VQo_003D(ref _0023_003DzMANLSxJk4AWs);
		if (CursorTypes != null)
		{
			foreach (KeyValuePair<cursorType, Cursor> cursorType in CursorTypes)
			{
				Cursor _0023_003DzlwNtVtI_003D = cursorType.Value;
				_0023_003DzvxT4VQo_003D(ref _0023_003DzlwNtVtI_003D);
			}
			CursorTypes.Clear();
		}
		base.FreeCursors();
	}

	private void _0023_003Dzi2r38NMlGv6B()
	{
		_0023_003DzZ6Vh_2eG3NkG();
		if (ContextMenuStrip != null)
		{
			ContextMenuStrip.Dispose();
			ContextMenuStrip = null;
		}
		_0023_003DzKk1DQUn5co_aN4nO4w_003D_003D?.Dispose();
		_0023_003DziwPFZD5quyJUARrhpw_003D_003D?.Dispose();
		_0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D?.Dispose();
		_0023_003DzM_0024RAWGUwy2M6VoDO8g_003D_003D?.Dispose();
		_0023_003DzR3te2ECclIvgC98aKjRl1l0_003D?.Dispose();
		_0023_003DzFGQmQXKrdjacAiDvFmESkVg_003D?.Dispose();
		_0023_003DzqZgiEmb_0024ukpITsN00Q_003D_003D?.Dispose();
		_0023_003DzF_0024lPCjNBq_z_0024?.Dispose();
		_0023_003DzoyItBUrB_0024Vm2yfULwZ0OnBU_003D?.Dispose();
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591598));
		_0023_003DzyCZYynHYeTy_(delegate
		{
			_0023_003DzhuKRYpQ_003D = true;
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				_0023_003DzFzzfWzVQfgnR?.Stop();
				_0023_003DzmNZD0Zs_003D.MakeCurrent();
				_0023_003DzK3OaHhra7VrS._0023_003DzPY_0024ulDyKjEOA();
				_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzPY_0024ulDyKjEOA();
				ClippingPlaneBase[] array = _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D;
				for (int i = 0; i < array.Length; i++)
				{
					((ClippingPlane)array[i]).Dispose();
				}
				Document.FreeGraphicsResources();
				_0023_003DzyqTCZr_00247ER6VmvzexA_003D_003D();
				for (int j = 0; j < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; j++)
				{
					_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[j]._0023_003DzPY_0024ulDyKjEOA();
				}
				_0023_003DzD157GIliOpnX?.Dispose();
				_0023_003DzeDju_XcuxmQA?.FreeResources();
				_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.Dispose();
				_0023_003Dzgg0qV0T_00248ave?.Dispose();
				_0023_003DzgpecnOZK_rLDYEjHUA_003D_003D.Dispose();
				MagnifyingGlass.Dispose();
				_0023_003Dzl9sayiOqFqdH2uqF7A_003D_003D();
				if (_0023_003DzUnT21F0UWD2IlVwatg_003D_003D != null)
				{
					_0023_003DzUnT21F0UWD2IlVwatg_003D_003D.Dispose();
					_0023_003DzUnT21F0UWD2IlVwatg_003D_003D = null;
				}
				if (_0023_003DzqurM61XyL6Tc != null)
				{
					_0023_003DzqurM61XyL6Tc.Dispose();
					_0023_003DzqurM61XyL6Tc = null;
				}
				if (_0023_003DzX9dkQU3xfVkG != null)
				{
					_0023_003DzX9dkQU3xfVkG.Dispose();
					_0023_003DzX9dkQU3xfVkG = null;
				}
				if (_0023_003DzytRMTWr9k5Ww != null)
				{
					_0023_003DzytRMTWr9k5Ww.Dispose();
					_0023_003DzytRMTWr9k5Ww = null;
				}
				if (_0023_003Dz7foQIumD31m4 != null)
				{
					_0023_003Dz7foQIumD31m4.Dispose();
					_0023_003Dz7foQIumD31m4 = null;
				}
				if (_0023_003DziuvwBNA4duWb != null)
				{
					_0023_003DziuvwBNA4duWb.Dispose();
					_0023_003DziuvwBNA4duWb = null;
				}
				if (_0023_003DzxljNCVjBWQzg != null)
				{
					_0023_003DzxljNCVjBWQzg.Dispose();
					_0023_003DzxljNCVjBWQzg = null;
				}
				_0023_003DzmNZD0Zs_003D.Dispose();
				_0023_003DzmNZD0Zs_003D = null;
			}
		});
		_0023_003DzQjChBvWoBmSd();
		base.OnHandleDestroyed(e);
	}

	private void _0023_003DzQjChBvWoBmSd()
	{
		_0023_003DzPzENGX5glhG5 = false;
		if (_0023_003DzFzzfWzVQfgnR != null)
		{
			_0023_003DzFzzfWzVQfgnR.Stop();
			_0023_003DzFzzfWzVQfgnR.Tick -= delegate
			{
				_0023_003DzsNY3baF_0024GM7MtcGwGAB4MSE_003D = 0;
				_0023_003DzFzzfWzVQfgnR.Stop();
				_0023_003DztdGp9MI3CH2w = false;
				if (!_0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW())
				{
					_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: false);
				}
				AdjustNearAndFarPlanes();
				_0023_003DzqCYquA6AxCkt(_0023_003DzBn2ByFKdwrou);
				bool flag = false;
				if (ActionMode == actionType.SelectVisibleByPickDynamic && _0023_003Dzo_MNAFBAjuGu == 0)
				{
					System.Drawing.Point point = _0023_003DzhOqjhfgpYUK7();
					MouseEventArgs _0023_003Dz1SmHC4c_003D2 = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);
					bool _0023_003DzprYbenN6veHPuANVgQ_003D_003D = false;
					_0023_003DzDNLc1QbWJ8j9(_0023_003Dz1SmHC4c_003D2, _0023_003DzR8L_0024Yw_00244jJcu(_0023_003DzipBYly6zFKAp(), _0023_003Dz1SmHC4c_003D2), _0023_003DzipBYly6zFKAp(), ref _0023_003DzprYbenN6veHPuANVgQ_003D_003D);
					if (_0023_003DznmpiQBcqK9AE.AddedItems.Count > 0 || _0023_003DznmpiQBcqK9AE.RemovedItems.Count > 0)
					{
						flag = true;
					}
				}
				_0023_003DzipBYly6zFKAp()._0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: false);
				_0023_003DzBhiHJ1K9qQ76(_0023_003DzipBYly6zFKAp(), out var _0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D);
				if (flag || _0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D)
				{
					PaintBackBuffer();
					SwapBuffers();
				}
			};
			_0023_003DzFzzfWzVQfgnR.Dispose();
			_0023_003DzFzzfWzVQfgnR = null;
		}
		_0023_003DzZ6Vh_2eG3NkG();
		_0023_003Dz32fCUXg4rkVM?._0023_003Dz2EeEWwA_003D();
	}

	internal virtual void _0023_003DzPY_0024ulDyKjEOA()
	{
		_0023_003DzhuKRYpQ_003D = true;
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzFzzfWzVQfgnR?.Stop();
			_0023_003DzmNZD0Zs_003D.MakeCurrent();
			_0023_003DzK3OaHhra7VrS._0023_003DzPY_0024ulDyKjEOA();
			_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzPY_0024ulDyKjEOA();
			ClippingPlaneBase[] array = _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D;
			for (int i = 0; i < array.Length; i++)
			{
				((ClippingPlane)array[i]).Dispose();
			}
			Document.FreeGraphicsResources();
			_0023_003DzyqTCZr_00247ER6VmvzexA_003D_003D();
			for (int j = 0; j < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; j++)
			{
				_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[j]._0023_003DzPY_0024ulDyKjEOA();
			}
			_0023_003DzD157GIliOpnX?.Dispose();
			_0023_003DzeDju_XcuxmQA?.FreeResources();
			_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.Dispose();
			_0023_003Dzgg0qV0T_00248ave?.Dispose();
			_0023_003DzgpecnOZK_rLDYEjHUA_003D_003D.Dispose();
			MagnifyingGlass.Dispose();
			_0023_003Dzl9sayiOqFqdH2uqF7A_003D_003D();
			if (_0023_003DzUnT21F0UWD2IlVwatg_003D_003D != null)
			{
				_0023_003DzUnT21F0UWD2IlVwatg_003D_003D.Dispose();
				_0023_003DzUnT21F0UWD2IlVwatg_003D_003D = null;
			}
			if (_0023_003DzqurM61XyL6Tc != null)
			{
				_0023_003DzqurM61XyL6Tc.Dispose();
				_0023_003DzqurM61XyL6Tc = null;
			}
			if (_0023_003DzX9dkQU3xfVkG != null)
			{
				_0023_003DzX9dkQU3xfVkG.Dispose();
				_0023_003DzX9dkQU3xfVkG = null;
			}
			if (_0023_003DzytRMTWr9k5Ww != null)
			{
				_0023_003DzytRMTWr9k5Ww.Dispose();
				_0023_003DzytRMTWr9k5Ww = null;
			}
			if (_0023_003Dz7foQIumD31m4 != null)
			{
				_0023_003Dz7foQIumD31m4.Dispose();
				_0023_003Dz7foQIumD31m4 = null;
			}
			if (_0023_003DziuvwBNA4duWb != null)
			{
				_0023_003DziuvwBNA4duWb.Dispose();
				_0023_003DziuvwBNA4duWb = null;
			}
			if (_0023_003DzxljNCVjBWQzg != null)
			{
				_0023_003DzxljNCVjBWQzg.Dispose();
				_0023_003DzxljNCVjBWQzg = null;
			}
			_0023_003DzmNZD0Zs_003D.Dispose();
			_0023_003DzmNZD0Zs_003D = null;
		}
	}

	internal void _0023_003Dz_XtI6E7WTKpM()
	{
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591370));
		CompileUserInterfaceElements();
		if (Entities != null)
		{
			Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591416));
			Entities.InitializeGraphicsResources();
		}
		if (_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D != null)
		{
			Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591465));
			_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D.InitializeGraphicsResources();
		}
		for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
		{
			Viewport viewport = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i];
			Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596889), viewport._0023_003DzkOgRqj2Di0m4());
			viewport._0023_003Dz_XtI6E7WTKpM();
		}
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596934));
	}

	internal static bool _0023_003DzXQRWQ3GhBR_Q(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		return _0023_003DzmNZD0Zs_003D?.IsValid() ?? false;
	}

	internal bool _0023_003DzXQRWQ3GhBR_Q()
	{
		return _0023_003DzXQRWQ3GhBR_Q(_0023_003DzmNZD0Zs_003D);
	}

	public virtual void Clear()
	{
		if (TempEntities != null)
		{
			TempEntities.Clear();
		}
		_0023_003DzjczFwk1Qrlg9QkeecQ_003D_003D = null;
		_0023_003DzomkzA6ARKGCOzn9ijw_003D_003D = null;
		_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: true);
		ParallelConveHull.Instance.Dispose(this);
		_0023_003DzvKRiFE5qp2u2XyCfhw_003D_003D(_0023_003DzgKkl_0024ivLmKr3: false, _0023_003DzIdFNsJJS3mub: true);
		_0023_003DztA_YGZTRCJVx();
		_0023_003DzgfObf7s_003D.Clear();
		for (int i = 0; i < _0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count; i++)
		{
			_0023_003DzbesAu90NcF8KFeewpw_003D_003D[i]._0023_003Dz7kSxzpM_003D();
		}
		_0023_003Dz4qdnHLU4p4Ip(_0023_003DzjPUaqyA_003D: false);
	}

	private void _0023_003DztA_YGZTRCJVx()
	{
		_0023_003DzyqTCZr_00247ER6VmvzexA_003D_003D();
		_0023_003DznJLjYKflIJCP.Clear();
		_0023_003DzOA_ac7k_003D.Clear();
	}

	private void _0023_003DzyqTCZr_00247ER6VmvzexA_003D_003D()
	{
		foreach (Block item in _0023_003DznJLjYKflIJCP)
		{
			foreach (Entity entity in item.Entities)
			{
				entity.Dispose();
			}
		}
		foreach (Block item2 in _0023_003DzOA_ac7k_003D)
		{
			foreach (Entity entity2 in item2.Entities)
			{
				entity2.Dispose();
			}
		}
	}

	public void ScaleForDPI()
	{
		base.Size = UtilityEx._0023_003DzowV4NhAf418J(base.Size, UtilityEx.GetScalingLevel());
		_0023_003DzC_0024E7w1YRUP_jIfiptA_003D_003D();
	}

	private void _0023_003DzC_0024E7w1YRUP_jIfiptA_003D_003D()
	{
		Font = UtilityEx._0023_003DzowV4NhAf418J(Font, _0023_003DzzihtqSXtvdcF: false, UtilityEx.GetScalingLevel());
		foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
		{
			item.ScaleForDPI();
		}
		_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Size = UtilityEx._0023_003DzowV4NhAf418J(_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Size, UtilityEx.GetScalingLevel());
		ButtonStyle.Size = UtilityEx._0023_003DzowV4NhAf418J(ButtonStyle.Size, UtilityEx.GetScalingLevel());
		MagnifyingGlass.Size = UtilityEx._0023_003DzowV4NhAf418J(MagnifyingGlass.Size, UtilityEx.GetScalingLevel());
		PickBoxSize = UtilityEx._0023_003DzowV4NhAf418J(PickBoxSize, UtilityEx.GetScalingLevel());
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		try
		{
			Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596961));
			Logger.Instance.Info(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596761), base.Renderer);
			_0023_003DzCOqVKjGnFoU6();
			if (ControlData.IsVirtualMachine())
			{
				Logger.Instance.Info(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596769));
			}
			else
			{
				Logger.Instance.Info(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596802));
			}
			if (base.Size.Width == 0 || base.Size.Height == 0)
			{
				string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596838);
				Logger.Instance.Error(InstanceId, message, null);
				throw new EyeshotException(message);
			}
			if (!IsDesignMode() && !_0023_003DzYes3sySVPIBmD955lA_003D_003D)
			{
				_0023_003DzC_0024E7w1YRUP_jIfiptA_003D_003D();
				_0023_003DzYes3sySVPIBmD955lA_003D_003D = true;
			}
			_0023_003DzIRSxr5GrGB6E(base.Handle);
			_0023_003DzxopYzhAbGfyU();
			SetStyle(ControlStyles.ResizeRedraw, value: true);
			_0023_003DzhuKRYpQ_003D = false;
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]._0023_003Dz1ezwJ4KH2Yxl(e);
				_0023_003Dzk4Sj9EO3_i4N(_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]);
			}
			if (!ErrorInPaint)
			{
				_0023_003Dz2F9_0024pE8Z_0024_002426 = Cursor;
				bool flag = false;
				for (int j = 0; j < 2; j++)
				{
					if (flag)
					{
						break;
					}
					Logger.Instance.Info(InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597151), j + 1, 2));
					switch (base.Renderer)
					{
					case rendererType.OpenGL:
						_0023_003DzmNZD0Zs_003D = new OglRenderContext(base.Size, _0023_003DzjC4hA2I_003D, this);
						flag = _0023_003DzmNZD0Zs_003D.Create();
						if (flag)
						{
							((OglRenderContext)_0023_003DzmNZD0Zs_003D).OpenglSetup(_0023_003DzjC4hA2I_003D);
						}
						else
						{
							Logger.Instance.Error(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597196), null);
						}
						break;
					case rendererType.Direct3D:
						try
						{
							_0023_003DzmNZD0Zs_003D = new D3DRenderContextWF(base.Size, _0023_003DzjC4hA2I_003D, this);
							flag = _0023_003DzmNZD0Zs_003D.Create();
						}
						catch (Exception exception)
						{
							Logger.Instance.Error(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597221), exception);
							_0023_003DzLiazRDDl7mem7npetQ_003D_003D = rendererType.OpenGL;
						}
						break;
					}
				}
				if (!flag)
				{
					string text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597015);
					Logger.Instance.Error(InstanceId, text, null);
					_0023_003Dz4qdnHLU4p4Ip(text);
				}
				else
				{
					_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS9sBW50_003D(_0023_003DzmNZD0Zs_003D);
					if (_0023_003DzCTpPcMUdDrcJ())
					{
						Logger.Instance.Info(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597062), RendererVendor, RendererName, RendererVersion);
					}
					else
					{
						Logger.Instance.Info(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597110), RendererName, RendererVersion);
					}
					Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596369));
					_0023_003DzmNZD0Zs_003D.InitializePreviousColors();
					_0023_003DzmNZD0Zs_003D.InitializeCurrentWireColor();
					Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596431));
					_0023_003DzmNZD0Zs_003D.InitializeStates();
					Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596437));
					_0023_003DzmNZD0Zs_003D.UpdateActiveLights(_0023_003DzMuApP021PUyU);
					if (!IsDesignMode())
					{
						_0023_003DzjdCtQ1JEPT6dhqFgL_4J7bU_003D();
					}
					_0023_003Dztlc4_vYMmHwMNn1eUs_lO_Tk1pwt = new AmbientOcclusionSettings(AmbientOcclusionSettings.aoQuality.Auto, _0023_003DzmNZD0Zs_003D);
					_0023_003DzLBAsomUMXlxUzJkZ4ZWyhKLTzXmX = (!_0023_003DzmNZD0Zs_003D.IsDirect3D && _0023_003DzmNZD0Zs_003D.HasFBBlit() && _0023_003DzmNZD0Zs_003D.HasPackedDepthStencil()) || (_0023_003DzmNZD0Zs_003D.IsDirect3D && (_0023_003DzmNZD0Zs_003D.RendererVersion.Major > 10 || (_0023_003DzmNZD0Zs_003D.RendererVersion.Major == 10 && _0023_003DzmNZD0Zs_003D.RendererVersion.Minor >= 1)));
					Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596472) + (_0023_003DzLBAsomUMXlxUzJkZ4ZWyhKLTzXmX ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596265) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596253)));
					Document.ClearCharDefs();
					Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596281));
					_0023_003DzeDju_XcuxmQA = _0023_003DzmNZD0Zs_003D.CreateTexture2D();
					Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596315));
					using (Bitmap bitmap = OriginTextureOverride ?? _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz2QtZmoTL8x1t())
					{
						_0023_003DzeDju_XcuxmQA.Load(_0023_003DzmNZD0Zs_003D, bitmap, textureFilteringFunctionType.Linear);
						if (OriginTextureOverride != null)
						{
							OriginTextureOverride.Dispose();
							OriginTextureOverride = null;
						}
					}
					Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596350));
					if (IsDesignMode())
					{
						_0023_003DzjC4hA2I_003D.ShadersHqrMainSwitch = false;
					}
					if (StandardShaders == null)
					{
						_0023_003DzwuiFtChRA95l();
					}
					_0023_003DzSJDeNOUaWXnt();
					_0023_003Dz_XtI6E7WTKpM();
					for (int k = 0; k < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; k++)
					{
						_0023_003DzbesAu90NcF8KFeewpw_003D_003D[k]._0023_003DzjDuhintYzbDe(_0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: true);
						_0023_003DzbesAu90NcF8KFeewpw_003D_003D[k]._0023_003DzHKNzRfUCOkwd();
					}
					ProgressBar.ParentWorkspace = this;
					_0023_003DzxopYzhAbGfyU();
					if (IsDesignMode())
					{
						_0023_003DzJX61e5MEGtgu();
					}
					_0023_003DznmpiQBcqK9AE = new SelectionChangedEventArgs();
				}
			}
			_0023_003DzY7PoD1c_003D = new _0023_003DzoFrj_j4xP7LR4PzpMFSwbLcZc_0024wi();
			_0023_003DzxIgINtc_003D = new _0023_003Dz3yTehjY_1ZV5QPm48sNaXRgcW8e5();
			_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D = new System.Timers.Timer(CameraChangedFrequency);
			_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Elapsed += delegate
			{
				if (base.InvokeRequired)
				{
					BeginInvoke(new MethodInvoker(_0023_003DzPFFaaGJBYbmGfv9zdvfdyIjoPKJl));
				}
				else
				{
					_0023_003Dz11CadYMOXmz_(_0023_003DzipBYly6zFKAp());
				}
			};
			_0023_003Dz8O1g1d9SIde4();
			_0023_003DzCFLw5qY2msbr.Start();
			base.OnHandleCreated(e);
			Logger.Instance.Info(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596610));
			if (IsDesignMode() || _0023_003DzR6_0024SSJwlV2vt(this, _0023_003DzvNNbLbz6_0024BH3: false))
			{
				_0023_003DzK1ESoHFY2_Cb(this);
			}
			Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596643));
		}
		catch (Exception exception2)
		{
			Logger.Instance.Error(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596701), exception2);
			throw;
		}
	}

	private void _0023_003DzCOqVKjGnFoU6()
	{
		try
		{
			Telemetry instance = Telemetry.Instance;
			if (!instance.CollectData)
			{
				return;
			}
			instance.AddUsage(base.Renderer.ToString(), Telemetry.moduleType.Renderer);
			instance.AddUsage(this, Telemetry.moduleType.Workspace);
			if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 1)
			{
				instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596731), Telemetry.moduleType.Generic);
			}
			instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596487), Telemetry.moduleType.Platform);
			if (_0023_003DzG83_00246AJK1JqWS6ltVhRJL_I_003D())
			{
				instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596504), Telemetry.moduleType.Graphics);
			}
			if (_0023_003Dzx6q74t9r4Eis7_00241oag_003D_003D() || _0023_003DzD_0024V5s06JeZ8Y0HFjaQ_003D_003D())
			{
				instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596526), Telemetry.moduleType.Graphics);
			}
			if (AntiAliasing)
			{
				instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596537), Telemetry.moduleType.Graphics);
			}
			if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
			{
				if (_0023_003DzipBYly6zFKAp().Navigation.Mode == Camera.navigationType.Fly || _0023_003DzipBYly6zFKAp().Navigation.Mode == Camera.navigationType.Walk)
				{
					instance.AddUsage(_0023_003DzipBYly6zFKAp().Navigation.Mode.ToString(), Telemetry.moduleType.Graphics);
				}
				shadowType shadowType2 = _0023_003DzipBYly6zFKAp().DisplayMode switch
				{
					displayType.Rendered => _0023_003DznKkOfo8_003D.ShadowMode, 
					displayType.Shaded => _0023_003DzAv2OMNy7DJ5L.ShadowMode, 
					_ => shadowType.None, 
				};
				if (shadowType2 != shadowType.None)
				{
					instance.AddUsage(shadowType2.ToString(), Telemetry.moduleType.Graphics);
				}
				if (_0023_003DzipBYly6zFKAp().DisplayMode == displayType.Rendered && _0023_003DznKkOfo8_003D.PlanarReflections)
				{
					instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648205), Telemetry.moduleType.Graphics);
				}
			}
			if (_0023_003DztnrgTmT5sBNd() != new SizeF(1f, 1f))
			{
				instance.AddUsage(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596550), Telemetry.moduleType.Graphics);
			}
		}
		catch (Exception _0023_003DzHwrKer4_003D)
		{
			_0023_003DzWx3BmFGxQvWH(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596567), TraceLevel.Warning, _0023_003DzHwrKer4_003D, Array.Empty<object>());
		}
	}

	private void _0023_003Dz8O1g1d9SIde4()
	{
		if (IsDesignMode() || _0023_003DzPzENGX5glhG5)
		{
			return;
		}
		_0023_003DzhMz2Xb3oiXP2_0024WuRGg_003D_003D();
		_0023_003Dz_XPtrr_DYLmiXjAB3A_003D_003D();
		try
		{
			_0023_003Dz32fCUXg4rkVM = new _0023_003DzkD7lKgTh2VSZ4ZBEVOeA7jnO8Hqh0756_0024NKupiU_003D(this);
		}
		catch
		{
			_0023_003Dz32fCUXg4rkVM = null;
		}
		finally
		{
			Logger.Instance.Trace(InstanceId, (_0023_003Dz32fCUXg4rkVM == null) ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597928) : string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597902), _0023_003Dz32fCUXg4rkVM._0023_003DzxpoNvry1jysi()));
		}
		_0023_003DzPzENGX5glhG5 = true;
	}

	private void _0023_003DzJX61e5MEGtgu()
	{
		if (_0023_003DzmNZD0Zs_003D != null && _0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count != 0 && _0023_003DzmNZD0Zs_003D.HasShadow() && _0023_003DzmNZD0Zs_003D.HasMultiTexture() && _0023_003DzQthAg2kOXptfNjbNhQ_003D_003D())
		{
			bool initHQR = false;
			_0023_003DzmNZD0Zs_003D.ResizeShadowMaps(base.Size, _0023_003DznKkOfo8_003D.RealisticShadowQuality, ref initHQR);
			if (initHQR)
			{
				_0023_003DzkotQIhWAq_x7B3YM9J7RCM4_003D();
				_0023_003DzwuiFtChRA95l();
				_0023_003Dz8ok_dRe4bjRDcVb_0024afNnmr8_003D = true;
			}
		}
	}

	private void _0023_003Dz9fXyPpxJHx492gQQoe9PQHSjzbOI5jEv7A_003D_003D()
	{
		_0023_003DzmNZD0Zs_003D.ResizeCompositingObjects(base.Size);
	}

	private void _0023_003Dz0o3erfmqWnrMS8fSlmdxwrTddQpoV95K07ps0fw_003D()
	{
		_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase?.ResizeTargets();
	}

	internal TextOnly _0023_003DznbhgjDOp1CI9BieK4g_003D_003D(Point3D _0023_003DzfOC0YjY_003D, string _0023_003DzgWGS4uo_003D, Font _0023_003Dz6FupbG0_003D, Color _0023_003Dzlxpb_Og_003D)
	{
		TextOnly textOnly = new TextOnly(_0023_003DzfOC0YjY_003D, _0023_003DzgWGS4uo_003D, _0023_003Dz6FupbG0_003D, _0023_003Dzlxpb_Og_003D);
		textOnly.Regen(_0023_003DzmNZD0Zs_003D, 1f);
		return textOnly;
	}

	internal void _0023_003DzrY6HOpTjhsgd()
	{
		if (base.Renderer != rendererType.OpenGL && (_0023_003DzE61nM_aOZBgx == null || _0023_003DzE61nM_aOZBgx.CornerRadius != 0))
		{
			return;
		}
		_0023_003DzE61nM_aOZBgx._0023_003DzlrEqyC6UUZf8(_0023_003DzsLHxXyo_003D: false);
		Color color = RenderContextUtility.ConvertColor(_0023_003DzE61nM_aOZBgx.Color);
		int cornerRadius = _0023_003DzE61nM_aOZBgx.CornerRadius;
		if (_0023_003DzE61nM_aOZBgx.Visible)
		{
			if (_0023_003DzO_o8M3HUNFVt != null)
			{
				_0023_003DzO_o8M3HUNFVt.Dispose();
				((RenderContext)_0023_003DzmNZD0Zs_003D).DisposeBorderTextures();
			}
			_0023_003DzO_o8M3HUNFVt = new Bitmap(1, 1);
			_0023_003DzO_o8M3HUNFVt.SetPixel(0, 0, color);
		}
		if (cornerRadius <= 0 || !_0023_003DzAn5aCJc_003D())
		{
			return;
		}
		Bitmap bitmap = new Bitmap(cornerRadius * 2, cornerRadius * 2, PixelFormat.Format32bppArgb);
		try
		{
			using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.Transparent);
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddRectangle(new Rectangle(0, 0, cornerRadius * 2, cornerRadius * 2));
				graphicsPath.AddEllipse(0, 0, cornerRadius * 2 - 1, cornerRadius * 2 - 1);
				graphics.FillPath(new SolidBrush(_0023_003DzBkFnx3LCeZ0EQCoBYw_003D_003D()), graphicsPath);
				if (_0023_003DzE61nM_aOZBgx.Visible)
				{
					graphics.DrawEllipse(new Pen(color), 0, 0, cornerRadius * 2 - 1, cornerRadius * 2 - 1);
				}
			}
			if (_0023_003DzPHIgywQ0bPFl != null)
			{
				_0023_003DzPHIgywQ0bPFl.Dispose();
			}
			_0023_003DzPHIgywQ0bPFl = new Bitmap(cornerRadius, cornerRadius);
			using (System.Drawing.Graphics graphics2 = System.Drawing.Graphics.FromImage(_0023_003DzPHIgywQ0bPFl))
			{
				graphics2.DrawImage(bitmap, 0, 0);
			}
			if (_0023_003DzBlHCDVjJXeoG != null)
			{
				_0023_003DzBlHCDVjJXeoG.Dispose();
			}
			_0023_003DzBlHCDVjJXeoG = new Bitmap(cornerRadius, cornerRadius);
			using (System.Drawing.Graphics graphics3 = System.Drawing.Graphics.FromImage(_0023_003DzBlHCDVjJXeoG))
			{
				graphics3.DrawImage(bitmap, -cornerRadius, 0);
			}
			if (_0023_003DzkP4DGwYcuX5B != null)
			{
				_0023_003DzkP4DGwYcuX5B.Dispose();
			}
			_0023_003DzkP4DGwYcuX5B = new Bitmap(cornerRadius, cornerRadius);
			using (System.Drawing.Graphics graphics4 = System.Drawing.Graphics.FromImage(_0023_003DzkP4DGwYcuX5B))
			{
				graphics4.DrawImage(bitmap, -cornerRadius, -cornerRadius);
			}
			if (_0023_003DzAekJM0ZtENTE != null)
			{
				_0023_003DzAekJM0ZtENTE.Dispose();
			}
			_0023_003DzAekJM0ZtENTE = new Bitmap(cornerRadius, cornerRadius);
			using System.Drawing.Graphics graphics5 = System.Drawing.Graphics.FromImage(_0023_003DzAekJM0ZtENTE);
			graphics5.DrawImage(bitmap, 0, -cornerRadius);
		}
		finally
		{
			((IDisposable)bitmap).Dispose();
		}
	}

	public override void InitializeViewports()
	{
		_0023_003DzO9NcOvRo2Yyn = 0;
		if (!_0023_003DzlNGYbbA_003D && _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Add(GetDefaultViewport());
		}
		_0023_003DzxMjXttTc5JNkWQh7J4z9LEwPvett();
	}

	protected virtual Viewport GetDefaultViewport()
	{
		return new Viewport();
	}

	internal virtual void _0023_003DzxMjXttTc5JNkWQh7J4z9LEwPvett()
	{
	}

	internal viewportLayoutType _0023_003DzK9iHR98l0rNuEjAV4A_003D_003D()
	{
		return _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count switch
		{
			1 => viewportLayoutType.SingleViewport, 
			2 => viewportLayoutType.TwoViewportsVertical, 
			3 => viewportLayoutType.ThreeViewportsWithOneOnLeft, 
			4 => viewportLayoutType.FourViewports, 
			_ => viewportLayoutType.Stacked, 
		};
	}

	internal bool _0023_003DzYBRkt7OvpTz_0024()
	{
		return _0023_003DzYBRkt7OvpTz_0024(_0023_003DzAyrAfQurY_bE);
	}

	internal bool _0023_003DzYBRkt7OvpTz_0024(viewportLayoutType _0023_003DzVzeUT9E_003D)
	{
		int count = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count;
		switch (_0023_003DzVzeUT9E_003D)
		{
		case viewportLayoutType.None:
			if (count != 0)
			{
				return false;
			}
			break;
		case viewportLayoutType.SingleViewport:
			if (count != 1)
			{
				return false;
			}
			break;
		case viewportLayoutType.TwoViewportsVertical:
		case viewportLayoutType.TwoViewportsHorizontal:
			if (count != 2)
			{
				return false;
			}
			break;
		case viewportLayoutType.ThreeViewportsWithOneOnLeft:
		case viewportLayoutType.ThreeViewportsWithOneOnTop:
		case viewportLayoutType.ThreeViewportsWithOneOnRight:
		case viewportLayoutType.ThreeViewportsWithOneOnBottom:
			if (count != 3)
			{
				return false;
			}
			break;
		case viewportLayoutType.FourViewports:
			if (count != 4)
			{
				return false;
			}
			break;
		}
		return true;
	}

	internal void _0023_003Dzx_fjDklLVB1Z()
	{
		if (!_0023_003DzYBRkt7OvpTz_0024())
		{
			_0023_003DznqpCv_0024gi2KEG();
		}
	}

	internal void _0023_003DznqpCv_0024gi2KEG()
	{
		_0023_003DzAyrAfQurY_bE = _0023_003DzK9iHR98l0rNuEjAV4A_003D_003D();
	}

	public void CompileUserInterfaceElements()
	{
		CompileUserInterfaceElements(null);
	}

	public void CompileUserInterfaceElements(Viewport viewport)
	{
		if (_0023_003DzE7xpH20_003D)
		{
			Logger.Instance.Warn(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597964), null);
			return;
		}
		if (_0023_003DzmNZD0Zs_003D == null)
		{
			Logger.Instance.Warn(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597762), null);
			return;
		}
		if (!IsDesignMode() && !OpenGL.Windows.IsWindow(_0023_003DzZUohT3Y_003D))
		{
			Logger.Instance.Warn(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597842), null);
			return;
		}
		_0023_003DzmNZD0Zs_003D.MakeCurrent();
		if (viewport == null)
		{
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]._0023_003Dz8WTvZ9I_003D(_0023_003DzeDju_XcuxmQA);
			}
		}
		else
		{
			viewport._0023_003Dz8WTvZ9I_003D(_0023_003DzeDju_XcuxmQA);
		}
		if (_0023_003DzK3OaHhra7VrS.Visible && _0023_003DzK3OaHhra7VrS._0023_003Dz2TOCTXsyZLWU.RegenMode != regenType.NotNeeded)
		{
			_0023_003DzwD6MQKZjqPL8();
			_0023_003DzK3OaHhra7VrS._0023_003Dz2TOCTXsyZLWU.Regen(_0023_003DzmNZD0Zs_003D, 1f);
		}
		_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzU0f5_qE_003D = this;
		_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.ParentViewport = viewport;
		_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003Dz8WTvZ9I_003D(this, _0023_003DzeDju_XcuxmQA);
		_0023_003DzNFTjT933JCr9(_0023_003DzmNZD0Zs_003D);
		if (!IsDesignMode())
		{
			_0023_003DzJX61e5MEGtgu();
		}
		_0023_003Dzq0o8PI7V46nBBc7u3A_003D_003D(viewport);
		if (_0023_003DziuvwBNA4duWb != null)
		{
			_0023_003DziuvwBNA4duWb.Dispose();
		}
		_0023_003DziuvwBNA4duWb = _0023_003DzmNZD0Zs_003D.CompileEnvironment(_0023_003DznKkOfo8_003D.EnvironmentMappingImage);
		_0023_003DzXesuQK_0024FkcBJ(_0023_003DzmNZD0Zs_003D, IsHardwareAccelerated, Font, _0023_003DzZUohT3Y_003D);
		_0023_003Dz3zhiYY8UIekG(_0023_003DzmNZD0Zs_003D, Font, _0023_003DzZUohT3Y_003D);
		_0023_003Dz2nDqp3Z5krSWW71gIQ_003D_003D(_0023_003DzmNZD0Zs_003D, Font, _0023_003DzZUohT3Y_003D);
		_0023_003DzmivCVDsX6Yk_0024colVdg_003D_003D(_0023_003DzmNZD0Zs_003D, Font, _0023_003DzZUohT3Y_003D);
		if (_0023_003DzxljNCVjBWQzg != null)
		{
			_0023_003DzxljNCVjBWQzg.Dispose();
			_0023_003DzxljNCVjBWQzg = null;
		}
	}

	internal void _0023_003DzXesuQK_0024FkcBJ(RenderContextBase _0023_003DzoC62DbA_003D, bool _0023_003Dz9HkjdJaYub6nenDMRvzAFGU_003D, Font _0023_003Dz6FupbG0_003D, IntPtr _0023_003Dzy8TXCdk_003D)
	{
		Color white = Color.White;
		if (_0023_003DzqurM61XyL6Tc != null)
		{
			_0023_003DzqurM61XyL6Tc.Dispose();
		}
		int _0023_003DzMwMN4hU_003D = 0;
		string empty = string.Empty;
		empty = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598199);
		Bitmap[] array = new Bitmap[19];
		if (_0023_003Dz9HkjdJaYub6nenDMRvzAFGU_003D)
		{
			empty = ((!_0023_003DzmNZD0Zs_003D.IsDirect3D) ? (empty + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598224)) : (empty + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598221) + _0023_003DzmNZD0Zs_003D.RendererVersion.Major + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598210) + _0023_003DzmNZD0Zs_003D.RendererVersion.Minor + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598234)));
			empty += _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598243);
		}
		else
		{
			empty += _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598265);
		}
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(empty, _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598026), _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		_0023_003DzE77d8HQndN_0024X(_0023_003Dz6FupbG0_003D, white, _0023_003Dzy8TXCdk_003D, ref _0023_003DzMwMN4hU_003D, array);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598047), _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598054), _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598070), _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598111), _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598117), _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348598139), _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597387), _0023_003Dz6FupbG0_003D, white, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		_0023_003DzqurM61XyL6Tc = new TextureMosaic(_0023_003DzoC62DbA_003D, 4, 5, array);
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597404));
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Dispose();
		}
	}

	private void _0023_003DzE77d8HQndN_0024X(Font _0023_003Dz6FupbG0_003D, Color _0023_003Dzlxpb_Og_003D, IntPtr _0023_003Dzy8TXCdk_003D, ref int _0023_003DzMwMN4hU_003D, Bitmap[] _0023_003DzPHZBWDVgp_Ru)
	{
		int num = 0;
		while (num < 10)
		{
			_0023_003DzPHZBWDVgp_Ru[_0023_003DzMwMN4hU_003D] = _0023_003DzRFGA2zTmmjXj(num.ToString(), _0023_003Dz6FupbG0_003D, _0023_003Dzlxpb_Og_003D, Color.Empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
			_0023_003DzLGy56aIVS2ab2GUVBA_003D_003D(ref _0023_003DzPHZBWDVgp_Ru[_0023_003DzMwMN4hU_003D], Color.Empty);
			num++;
			_0023_003DzMwMN4hU_003D++;
		}
	}

	internal void _0023_003Dz3zhiYY8UIekG(RenderContextBase _0023_003DzoC62DbA_003D, Font _0023_003Dz6FupbG0_003D, IntPtr _0023_003Dzy8TXCdk_003D)
	{
		Color white = Color.White;
		if (_0023_003DzX9dkQU3xfVkG != null)
		{
			_0023_003DzX9dkQU3xfVkG.Dispose();
		}
		Color empty = Color.Empty;
		int _0023_003DzMwMN4hU_003D = 0;
		Bitmap[] array = new Bitmap[13];
		string arg = Logger.Instance.TraceLevel.GetDisplayName();
		if (Logger.Instance.CaptureBackbufferImages && Logger.Instance.TraceLevel == TraceLevel.Off)
		{
			arg = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597411);
		}
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622780), arg, Logger.Instance.Id), _0023_003Dz6FupbG0_003D, white, empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597426), InstanceId), _0023_003Dz6FupbG0_003D, white, empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		array[_0023_003DzMwMN4hU_003D++] = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590286), _0023_003Dz6FupbG0_003D, white, empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		_0023_003DzE77d8HQndN_0024X(_0023_003Dz6FupbG0_003D, white, _0023_003Dzy8TXCdk_003D, ref _0023_003DzMwMN4hU_003D, array);
		_0023_003DzX9dkQU3xfVkG = new TextureMosaic(_0023_003DzoC62DbA_003D, 3, 5, array);
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597445));
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Dispose();
		}
	}

	internal void _0023_003Dz2nDqp3Z5krSWW71gIQ_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D, Font _0023_003Dz6FupbG0_003D, IntPtr _0023_003Dzy8TXCdk_003D)
	{
		if (_0023_003DzytRMTWr9k5Ww != null)
		{
			_0023_003DzytRMTWr9k5Ww.Dispose();
		}
		Color gray = Color.Gray;
		Color empty = Color.Empty;
		using Bitmap bitmap = _0023_003DzRFGA2zTmmjXj(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597477), _0023_003Dz6FupbG0_003D, gray, empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		_0023_003DzytRMTWr9k5Ww = new TextureMosaic(_0023_003DzoC62DbA_003D, 1, 1, new Bitmap[1] { bitmap });
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597306));
	}

	internal void _0023_003DzmivCVDsX6Yk_0024colVdg_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D, Font _0023_003Dz6FupbG0_003D, IntPtr _0023_003Dzy8TXCdk_003D)
	{
		if (_0023_003Dz7foQIumD31m4 != null)
		{
			_0023_003Dz7foQIumD31m4.Dispose();
		}
		Color gray = Color.Gray;
		Color empty = Color.Empty;
		using Bitmap bitmap = _0023_003DzRFGA2zTmmjXj(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597337), LicenseManager.DaysRemaining), _0023_003Dz6FupbG0_003D, gray, empty, _0023_003Dzy8TXCdk_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		_0023_003Dz7foQIumD31m4 = new TextureMosaic(_0023_003DzoC62DbA_003D, 1, 1, new Bitmap[1] { bitmap });
		Logger.Instance.Trace(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597640));
	}

	internal virtual void _0023_003DzNFTjT933JCr9(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003Dz4rgC_0024GWsoXmE6EAK3Hh0hv0_003D _0023_003Dz4rgC_0024GWsoXmE6EAK3Hh0hv0_003D2 = new _0023_003Dz4rgC_0024GWsoXmE6EAK3Hh0hv0_003D();
		_0023_003Dz4rgC_0024GWsoXmE6EAK3Hh0hv0_003D2._0023_003DzmNZD0Zs_003D = _0023_003DzmNZD0Zs_003D;
		_0023_003Dz4rgC_0024GWsoXmE6EAK3Hh0hv0_003D2._0023_003DzmNZD0Zs_003D.Compile(_0023_003Dzgg0qV0T_00248ave, _0023_003Dz4rgC_0024GWsoXmE6EAK3Hh0hv0_003D2._0023_003DzfLPmqfrZGlp6O5ha7sXIkOo_003D, null);
	}

	internal bool _0023_003Dz1h04P8XycEellhFbXA_003D_003D()
	{
		if (!_0023_003DzkQRTXiC03yes && !IsDesignMode())
		{
			return !hasFocus;
		}
		return false;
	}

	internal static void _0023_003Dzk6IQMQQ_003D(Workspace _0023_003DzopDrLGk_003D)
	{
		if (_0023_003DzopDrLGk_003D.IsDesignMode())
		{
			_0023_003DzopDrLGk_003D.UpdateDesignModeScene();
			_0023_003DzopDrLGk_003D.Invalidate();
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (_0023_003Dz8Q16RtM94O0K())
		{
			_0023_003DzHCBmbXkFyCwU(e.Graphics);
			return;
		}
		if (IsDesignMode())
		{
			if (_0023_003DzJo5ZCERKuRzT == null && _0023_003DzmNZD0Zs_003D != null)
			{
				UpdateDesignModeScene();
			}
			if (_0023_003DzJo5ZCERKuRzT != null)
			{
				e.Graphics.DrawImage(_0023_003DzJo5ZCERKuRzT, 0, 0);
			}
		}
		else if (_0023_003Dz_0024zgVvF4OlegG)
		{
			if (_0023_003DzJo5ZCERKuRzT != null)
			{
				e.Graphics.DrawImage(_0023_003DzJo5ZCERKuRzT, 0, 0);
			}
		}
		else
		{
			OnPaint();
		}
		base.OnPaint(e);
	}

	private protected void _0023_003DzHCBmbXkFyCwU(System.Drawing.Graphics _0023_003DzVC9FBdo_003D)
	{
		string s;
		string _0023_003DzOzZvN_0024_89ezkTnhi0iE5RL3fOAVM;
		Color color;
		if (_0023_003DzyYEVfLG1UTpY)
		{
			s = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348640585);
			_0023_003DzOzZvN_0024_89ezkTnhi0iE5RL3fOAVM = _0023_003DzJmK5T9E32z5d._0023_003DzOzZvN_0024_89ezkTnhi0iE5RL3fOAVM;
			color = Color.FromArgb(0, 0, 200);
		}
		else
		{
			s = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597669);
			_0023_003DzOzZvN_0024_89ezkTnhi0iE5RL3fOAVM = _0023_003Dzuxh58hoEevp2;
			color = Color.FromArgb(200, 0, 0);
		}
		_0023_003DzVC9FBdo_003D.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, _0023_003Dz0P1LCYH__O4t(), _0023_003DzNwtRJ3cLTrAy());
		Font font = new Font(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597689), 14f, FontStyle.Bold);
		try
		{
			_0023_003DzVC9FBdo_003D.FillRectangle(new SolidBrush(color), 0, 0, _0023_003Dz0P1LCYH__O4t(), 27);
			Brush brush = new SolidBrush(Color.White);
			try
			{
				_0023_003DzVC9FBdo_003D.DrawString(s, font, brush, new RectangleF(1f, 1f, _0023_003Dz0P1LCYH__O4t(), 27f));
			}
			finally
			{
				((IDisposable)brush).Dispose();
			}
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
		Font font2 = new Font(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597689), 9f);
		try
		{
			Brush brush2 = new SolidBrush(Color.Black);
			try
			{
				_0023_003DzVC9FBdo_003D.DrawString(_0023_003DzOzZvN_0024_89ezkTnhi0iE5RL3fOAVM, font2, brush2, new RectangleF(2f, 32f, _0023_003Dz0P1LCYH__O4t() - 4, _0023_003DzNwtRJ3cLTrAy() - 30), StringFormat.GenericDefault);
			}
			finally
			{
				((IDisposable)brush2).Dispose();
			}
			_0023_003DzjLLmiKcRt1A4(_0023_003DzVC9FBdo_003D);
		}
		finally
		{
			((IDisposable)font2).Dispose();
		}
		_0023_003DzVC9FBdo_003D.Flush();
	}

	protected override void OnPaint()
	{
		if (_0023_003DzCFLw5qY2msbr.ElapsedMilliseconds > 1500)
		{
			_0023_003DzFPtvCJM5exDj = 0;
			_0023_003DzCFLw5qY2msbr.Restart();
		}
		try
		{
			_0023_003Dz6LfbgRAYOjvE((_0023_003DzEve6E9qqZPdg >= 0) ? _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[_0023_003DzEve6E9qqZPdg] : null, 1f, _0023_003DzQmbl9PzBp44d, RectangleF.Empty, _0023_003Dzwf0rgOdP0NZJ: true, _0023_003DzBX_0024lgUSbQHBj: true, _0023_003DznwIKlITwQSgi: false, _0023_003DzLkl_mewv7s2Z: false, _0023_003DzIHwNrERoZxEh: false, null, _0023_003DzsazSka94g8G9H0qAvn5f_0024fw_003D: false);
			_0023_003DzcqwAHLWtCi4L();
		}
		catch (Exception ex)
		{
			_0023_003Dz4qdnHLU4p4Ip(ex.ToString());
			if (_0023_003DzDwjKS14_003D != null)
			{
				_0023_003DzDwjKS14_003D(this, new ErrorOccurredEventArgs(ex.ToString(), ex.StackTrace, _0023_003DzmNZD0Zs_003D.GraphicsDataWithError));
			}
		}
		_0023_003DzFPtvCJM5exDj++;
		if (_0023_003DzCFLw5qY2msbr.ElapsedMilliseconds > 1000)
		{
			_0023_003DzCFLw5qY2msbr.Stop();
			fps = (float)_0023_003DzFPtvCJM5exDj / ((float)_0023_003DzCFLw5qY2msbr.ElapsedMilliseconds / 1000f);
			_0023_003DzFPtvCJM5exDj = 0;
			_0023_003DzCFLw5qY2msbr.Restart();
		}
	}

	private static void _0023_003DzsAOHh6WlNTxpgD4E4A_003D_003D(PaintEventArgs _0023_003Dz1SmHC4c_003D, int _0023_003DznH_hPD5KdTIy, int _0023_003DztZyx6rs_003D, int _0023_003Dzjh0VY5s_003D, int _0023_003DzQ_0024EZDK3DX_SL, int _0023_003Dz1R0AFLg3VdwN)
	{
		_0023_003Dz1SmHC4c_003D.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(140, Color.White)), _0023_003DzQ_0024EZDK3DX_SL + 1, _0023_003DznH_hPD5KdTIy + 2, _0023_003Dz1R0AFLg3VdwN + 2, 11);
		_0023_003Dz1SmHC4c_003D.Graphics.FillRectangle(new LinearGradientBrush(new System.Drawing.Point(_0023_003DzQ_0024EZDK3DX_SL + 1, 0), new System.Drawing.Point(_0023_003DzQ_0024EZDK3DX_SL + _0023_003Dz1R0AFLg3VdwN * 2, 0), Color.FromArgb(220, Color.Green), Color.FromArgb(220, Color.LawnGreen)), _0023_003DzQ_0024EZDK3DX_SL + 2, _0023_003DznH_hPD5KdTIy + 3, _0023_003Dz1R0AFLg3VdwN * _0023_003DztZyx6rs_003D / _0023_003Dzjh0VY5s_003D, 9);
		_0023_003Dz1SmHC4c_003D.Graphics.DrawRectangle(new Pen(Color.FromArgb(240, Color.Green)), _0023_003DzQ_0024EZDK3DX_SL + 2, _0023_003DznH_hPD5KdTIy + 3, _0023_003Dz1R0AFLg3VdwN * _0023_003DztZyx6rs_003D / _0023_003Dzjh0VY5s_003D - 1, 8);
	}

	private static void _0023_003DzDFpnHrxmPzKT(PaintEventArgs _0023_003Dz1SmHC4c_003D, int _0023_003DznH_hPD5KdTIy, int _0023_003DzQ_0024EZDK3DX_SL, string _0023_003DzbsfLc6r4hUJ3, Font _0023_003DzYRYfccJxXYvO)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(0, 0, 5, 0);
		graphicsPath.AddLine(5f, 2f, 2f, 2.05f);
		graphicsPath.AddLine(2.05f, 2f, 2.05f, 10f);
		graphicsPath.AddLine(2.05f, 10f, 0f, 10f);
		graphicsPath.AddLine(0, 10, 0, 0);
		graphicsPath.CloseFigure();
		SizeF sizeF = _0023_003Dz1SmHC4c_003D.Graphics.MeasureString(_0023_003DzbsfLc6r4hUJ3, _0023_003DzYRYfccJxXYvO);
		System.Drawing.Drawing2D.Matrix matrix = new System.Drawing.Drawing2D.Matrix();
		matrix.Translate((float)_0023_003DzQ_0024EZDK3DX_SL + sizeF.Width, (float)_0023_003DznH_hPD5KdTIy + sizeF.Height - 4f);
		matrix.Rotate(225f);
		matrix.Scale(1.5f, 1.5f);
		graphicsPath.Transform(matrix);
		_0023_003Dz1SmHC4c_003D.Graphics.FillPath(new LinearGradientBrush(new System.Drawing.Point(0, _0023_003DznH_hPD5KdTIy + (int)sizeF.Height - 2), new System.Drawing.Point(0, _0023_003DznH_hPD5KdTIy - 6), Color.Green, Color.LawnGreen), graphicsPath);
		_0023_003Dz1SmHC4c_003D.Graphics.DrawPath(new Pen(Color.DarkGreen), graphicsPath);
	}

	internal void _0023_003DzcqwAHLWtCi4L()
	{
		if (!_0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			int error = gl.GetError();
			if (error != 0)
			{
				throw new EyeshotException(_0023_003DzmNZD0Zs_003D.GetErrorString(error));
			}
		}
	}

	private void _0023_003Dz9ggVByNFbSCF()
	{
		_0023_003DzyYEVfLG1UTpY = true;
		_0023_003Dz_PMvBVc_003D(_0023_003DzsLHxXyo_003D: false);
		_0023_003DzMhFbfqb7W7_B(_0023_003DzSgZxUH0_003D: true);
		_0023_003DzWx3BmFGxQvWH(_0023_003DzJmK5T9E32z5d._0023_003DzMI0rlI975C_0024z8sO84_0024IGjKI_003D, TraceLevel.Error, null, Array.Empty<object>());
	}

	internal void _0023_003Dz4qdnHLU4p4Ip(string _0023_003DzCxIp_0024rg_003D)
	{
		_0023_003Dzuxh58hoEevp2 = _0023_003DzCxIp_0024rg_003D;
		_0023_003Dz4qdnHLU4p4Ip(_0023_003DzjPUaqyA_003D: true);
	}

	private void _0023_003Dz4qdnHLU4p4Ip(bool _0023_003DzjPUaqyA_003D)
	{
		_0023_003DzjC4hA2I_003D.errorInPaint = _0023_003DzjPUaqyA_003D;
		if (!_0023_003DzjPUaqyA_003D && _0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.GraphicsDataWithError = null;
		}
		_0023_003Dz_PMvBVc_003D(!_0023_003DzjPUaqyA_003D);
		_0023_003DzMhFbfqb7W7_B(_0023_003DzjPUaqyA_003D);
	}

	private void _0023_003Dz_PMvBVc_003D(bool _0023_003DzsLHxXyo_003D)
	{
		if (!IsDesignMode())
		{
			base.Enabled = _0023_003DzsLHxXyo_003D;
		}
	}

	private GraphicsPath _0023_003DzUhW6GVLZsOlN(Rectangle _0023_003Dzols9v2M_003D, int _0023_003DzvjTHbaTV_0024Ffg)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(_0023_003Dzols9v2M_003D.X, _0023_003Dzols9v2M_003D.Y, _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003DzvjTHbaTV_0024Ffg * 2, 180f, 90f);
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.X + _0023_003DzvjTHbaTV_0024Ffg, _0023_003Dzols9v2M_003D.Y, _0023_003Dzols9v2M_003D.Right - _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003Dzols9v2M_003D.Y);
		graphicsPath.AddArc(_0023_003Dzols9v2M_003D.X + _0023_003Dzols9v2M_003D.Width - _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003Dzols9v2M_003D.Y, _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003DzvjTHbaTV_0024Ffg * 2, 270f, 90f);
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Y + _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Y + _0023_003Dzols9v2M_003D.Height - _0023_003DzvjTHbaTV_0024Ffg * 2);
		graphicsPath.AddArc(_0023_003Dzols9v2M_003D.X + _0023_003Dzols9v2M_003D.Width - _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003Dzols9v2M_003D.Y + _0023_003Dzols9v2M_003D.Height - _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003DzvjTHbaTV_0024Ffg * 2, 0f, 90f);
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.Right - _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003Dzols9v2M_003D.Bottom, _0023_003Dzols9v2M_003D.X + _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003Dzols9v2M_003D.Bottom);
		graphicsPath.AddArc(_0023_003Dzols9v2M_003D.X, _0023_003Dzols9v2M_003D.Bottom - _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003DzvjTHbaTV_0024Ffg * 2, 90f, 90f);
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.X, _0023_003Dzols9v2M_003D.Bottom - _0023_003DzvjTHbaTV_0024Ffg * 2, _0023_003Dzols9v2M_003D.X, _0023_003Dzols9v2M_003D.Y + _0023_003DzvjTHbaTV_0024Ffg * 2);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	private GraphicsPath _0023_003DzhCTDtqXk1DzU(Rectangle _0023_003Dzols9v2M_003D, int _0023_003DzvjTHbaTV_0024Ffg)
	{
		int num = 80;
		int num2 = 20;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.X, _0023_003Dzols9v2M_003D.Y, _0023_003Dzols9v2M_003D.X + num, _0023_003Dzols9v2M_003D.Y);
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.X + num, _0023_003Dzols9v2M_003D.Y, _0023_003Dzols9v2M_003D.X + num, _0023_003Dzols9v2M_003D.Y + num2);
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Y + num2, _0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Y + _0023_003Dzols9v2M_003D.Height);
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.Right, _0023_003Dzols9v2M_003D.Bottom, _0023_003Dzols9v2M_003D.X, _0023_003Dzols9v2M_003D.Bottom);
		graphicsPath.AddLine(_0023_003Dzols9v2M_003D.X, _0023_003Dzols9v2M_003D.Bottom, _0023_003Dzols9v2M_003D.X, _0023_003Dzols9v2M_003D.Y);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	[Conditional("WINFORMS")]
	internal void UpdateDesignModeScene()
	{
		if (!_0023_003Dz9cE_0024NqT_0024ydA62IzRLrv73lQ_003D && !_0023_003DzE7xpH20_003D)
		{
			_0023_003Dz9cE_0024NqT_0024ydA62IzRLrv73lQ_003D = true;
			if (_0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D != null)
			{
				_0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D();
			}
			_0023_003Dzm7MuUa57kNPc();
			if (_0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE != null)
			{
				_0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE();
			}
			_0023_003Dz9cE_0024NqT_0024ydA62IzRLrv73lQ_003D = false;
		}
	}

	internal bool _0023_003Dzm7MuUa57kNPc()
	{
		if (_0023_003DzlNGYbbA_003D || _0023_003DzmNZD0Zs_003D == null)
		{
			return false;
		}
		_0023_003DzmNZD0Zs_003D.MakeCurrent();
		bool flag = false;
		for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
		{
			Viewport viewport = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i];
			if (viewport.Camera == null)
			{
				viewport.Camera = Viewport._0023_003DzUuEDRsCIpmOw();
			}
			viewport._0023_003DzjDuhintYzbDe(_0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: true);
			flag |= viewport._0023_003DzL28lpFu5le27();
		}
		if (flag | _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzL28lpFu5le27())
		{
			CompileUserInterfaceElements();
		}
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
		{
			_0023_003DzgES1H_48XRD7GgtPkA_003D_003D();
		}
		int _0023_003DzNcT2wHJlbLpO = _0023_003Dz0P1LCYH__O4t();
		int _0023_003DzhaMurLM8BvXm = _0023_003DzNwtRJ3cLTrAy();
		if (_0023_003DzNwtRJ3cLTrAy() == 0 || _0023_003Dz0P1LCYH__O4t() == 0)
		{
			return false;
		}
		if (_0023_003DzJo5ZCERKuRzT != null)
		{
			_0023_003DzJo5ZCERKuRzT.Dispose();
		}
		_0023_003DzJo5ZCERKuRzT = new Bitmap(_0023_003DzNcT2wHJlbLpO, _0023_003DzhaMurLM8BvXm, PixelFormat.Format24bppRgb);
		Rectangle rect = new Rectangle(0, 0, _0023_003DzNcT2wHJlbLpO, _0023_003DzhaMurLM8BvXm);
		hasFocus = true;
		BitmapData bitmapData = _0023_003DzJo5ZCERKuRzT.LockBits(rect, ImageLockMode.WriteOnly, _0023_003DzJo5ZCERKuRzT.PixelFormat);
		for (int j = 0; j < 2; j++)
		{
			_0023_003DzxZAI1cgKJ8nHr9eHHQ_003D_003D(new DrawSceneParams
			{
				DrawScale = 1f,
				LineWeightFactor = 1f,
				DrawOverlay = true,
				IsDesignMode = true,
				SwapBuffer = false,
				Entities = Entities,
				Blocks = Blocks,
				RenderContext = _0023_003DzmNZD0Zs_003D,
				Bpp = 3
			}, 0, 0, _0023_003DzNcT2wHJlbLpO, _0023_003DzhaMurLM8BvXm, bitmapData, null, _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D: true, _0023_003Dz6LfbgRAYOjvE);
		}
		_0023_003DzJo5ZCERKuRzT.UnlockBits(bitmapData);
		_0023_003DzJo5ZCERKuRzT.RotateFlip(RotateFlipType.Rotate180FlipX);
		return true;
	}

	internal void _0023_003DzxZAI1cgKJ8nHr9eHHQ_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, int _0023_003DzNcT2wHJlbLpO, int _0023_003DzhaMurLM8BvXm, BitmapData _0023_003DzV0dC6To_003D, TextureBase _0023_003DzwIeLugkvScK_, bool _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, RenderContextBase.drawSceneFuncDelegate _0023_003DzLBvQI4DzXYouAOTiMQ_003D_003D)
	{
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		int strideInPixels = 0;
		TextureBase texture = null;
		if (_0023_003DzwIeLugkvScK_ == null)
		{
			strideInPixels = _0023_003DzV0dC6To_003D.Stride / _0023_003DzCBM7XJK4_5H_0024.Bpp;
		}
		else
		{
			texture = _0023_003DzwIeLugkvScK_;
		}
		System.Drawing.Point location = default(System.Drawing.Point);
		if (viewport != null)
		{
			location = viewport.Location;
			viewport.Location = new System.Drawing.Point(0, _0023_003DzNwtRJ3cLTrAy() - viewport.Size.Height);
			_0023_003DzCBM7XJK4_5H_0024.UpdateViewFrame();
		}
		((RenderContext)_0023_003DzmNZD0Zs_003D).DrawOnTextureOrBitmap(texture, null, _0023_003DzV0dC6To_003D, strideInPixels, IsAntiAliasingAvailable, AskForAntiAliasing, _0023_003DzjC4hA2I_003D.RealAntialiasingSamples, _0023_003DzNcT2wHJlbLpO, _0023_003DzhaMurLM8BvXm, _0023_003DzLBvQI4DzXYouAOTiMQ_003D_003D, _0023_003DzCBM7XJK4_5H_0024, _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, _0023_003DzCBM7XJK4_5H_0024.Bpp);
		if (viewport != null)
		{
			viewport.Location = location;
		}
	}

	internal void _0023_003DzHkkIXSV_0024RKwUEop64bKWkus_003D(int _0023_003DzAdM0WkTc_umh, int _0023_003DzxKSUsTc53qMy, System.Drawing.Graphics _0023_003DzVC9FBdo_003D, Image _0023_003DzmPRo6QY_003D)
	{
		float num = _0023_003DzmPRo6QY_003D.Width;
		float num2 = _0023_003DzmPRo6QY_003D.Height;
		int num3 = _0023_003DzAdM0WkTc_umh / 2;
		int num4 = _0023_003DzxKSUsTc53qMy / 2;
		float val = (float)_0023_003DzAdM0WkTc_umh / num;
		float val2 = (float)_0023_003DzxKSUsTc53qMy / num2;
		float num5 = Math.Max(val, val2);
		_0023_003DzVC9FBdo_003D.DrawImage(_0023_003DzmPRo6QY_003D, (float)num3 - num / 2f * num5, (float)num4 - num2 / 2f * num5, num * num5, num2 * num5);
	}

	private void _0023_003DzjdCtQ1JEPT6dhqFgL_4J7bU_003D()
	{
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzJX61e5MEGtgu();
			_0023_003DzMdFyO9PwRqDMVPMCbFQlj5s_003D();
			_0023_003Dz0o3erfmqWnrMS8fSlmdxwrTddQpoV95K07ps0fw_003D();
			_0023_003Dz9fXyPpxJHx492gQQoe9PQHSjzbOI5jEv7A_003D_003D();
		}
	}

	private void _0023_003DzPCg26RyshXDfVaJgAg_003D_003D(bool _0023_003DzezR9PKF_0024f_0024YL, bool _0023_003DzH0PKcbzBAdtQ)
	{
		base.RenderContext.SetupPolygonOffsetForShadow(_0023_003DzezR9PKF_0024f_0024YL, _0023_003DzH0PKcbzBAdtQ);
	}

	protected override void OnResize(EventArgs e)
	{
		if (_0023_003DzhuKRYpQ_003D)
		{
			return;
		}
		Form form = FindForm();
		if (form != null && form.WindowState == FormWindowState.Minimized)
		{
			_0023_003DzvTDEkOkzrzzDeY533g_003D_003D = true;
			return;
		}
		if (_0023_003DzvTDEkOkzrzzDeY533g_003D_003D)
		{
			_0023_003DzvTDEkOkzrzzDeY533g_003D_003D = false;
			if (_0023_003DznbDxlZQRhlsy == base.Size)
			{
				return;
			}
		}
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.MakeCurrent();
			_0023_003DzmNZD0Zs_003D.Resize(base.Size);
			_0023_003DztdGp9MI3CH2w = true;
		}
		ProgressBar._0023_003DzVRx5720_003D();
		ResizeViewports();
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D != null && _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count != 0)
		{
			_0023_003DzxMjXttTc5JNkWQh7J4z9LEwPvett();
			if (_0023_003DzsNY3baF_0024GM7MtcGwGAB4MSE_003D++ == 0 && _0023_003DztdGp9MI3CH2w)
			{
				_0023_003Dzf5NRO7wxeVa07xknUc_l_0024dqNXOfS();
			}
		}
		if (_0023_003Dz0P1LCYH__O4t() > 2 && _0023_003DzNwtRJ3cLTrAy() > 2 && _0023_003DzbesAu90NcF8KFeewpw_003D_003D != null)
		{
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				Viewport viewport = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i];
				viewport._0023_003DzjDuhintYzbDe(_0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: false);
				if (_0023_003DzmNZD0Zs_003D != null)
				{
					viewport.CompileBackground();
				}
			}
			_0023_003DzjdCtQ1JEPT6dhqFgL_4J7bU_003D();
			_0023_003DznbDxlZQRhlsy = base.Size;
		}
		if ((IsDesignMode() || _0023_003Dzry2RTIVdTZ_0024a) && _0023_003DzmNZD0Zs_003D != null)
		{
			ProgressBar._0023_003Dz_WlOvqR1pka_();
			UpdateDesignModeScene();
		}
		else if (_0023_003DzmNZD0Zs_003D != null)
		{
			Invalidate();
			_0023_003DzhfwTtuYclW899eUCjQ_003D_003D = true;
		}
		if (_0023_003DzmNZD0Zs_003D != null && _0023_003DzFzzfWzVQfgnR != null)
		{
			_0023_003DzFzzfWzVQfgnR.Stop();
			_0023_003DzSlNAZVP_0024WkQC();
		}
		base.OnResize(e);
	}

	private void _0023_003DzMdFyO9PwRqDMVPMCbFQlj5s_003D()
	{
		if (_0023_003DzmNZD0Zs_003D != null && _0023_003Dz0P1LCYH__O4t() > 0 && _0023_003DzNwtRJ3cLTrAy() > 0)
		{
			_0023_003DzmNZD0Zs_003D.ResizeSurfacesForCapture(base.Size, _0023_003DzjC4hA2I_003D.IsAntiAliasingEnabled());
		}
	}

	protected void ResizeViewports()
	{
		if (Math.Min(_0023_003Dz0P1LCYH__O4t(), _0023_003DzNwtRJ3cLTrAy()) <= 2 || _0023_003DzbesAu90NcF8KFeewpw_003D_003D == null)
		{
			return;
		}
		float num = (float)_0023_003DzNwtRJ3cLTrAy() / (float)_0023_003DznbDxlZQRhlsy.Height;
		foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
		{
			if (Math.Min(item.Size.Width, item.Size.Height) > 2)
			{
				item.Camera.ZoomFactor *= num;
			}
		}
	}

	private void _0023_003Dzq0o8PI7V46nBBc7u3A_003D_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count == 0)
		{
			return;
		}
		if (_0023_003DzYzWi5Yw_003D == null)
		{
			foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
			{
				_0023_003DzS4m8e_HXpv3j4pyo4Xaxyi0_003D(item);
			}
			return;
		}
		_0023_003DzS4m8e_HXpv3j4pyo4Xaxyi0_003D(_0023_003DzYzWi5Yw_003D);
	}

	private void _0023_003DzS4m8e_HXpv3j4pyo4Xaxyi0_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		ToolBar[] toolBars = _0023_003DzYzWi5Yw_003D.ToolBars;
		for (int i = 0; i < toolBars.Length; i++)
		{
			toolBars[i]._0023_003Dz8WTvZ9I_003D(this, _0023_003DzYzWi5Yw_003D);
		}
		ProgressBarCancelButton._0023_003DzPY_0024ulDyKjEOA();
		int dim = ButtonStyle.Size;
		int dim2 = ButtonStyle.Size;
		TextureBase.MakePowerOfTwoBigger(_0023_003DzmNZD0Zs_003D, ref dim);
		TextureBase.MakePowerOfTwoBigger(_0023_003DzmNZD0Zs_003D, ref dim2);
		GraphicsPath graphicsPath = ToolBar._0023_003DzcEByg_3wjQog(new Rectangle(0, 0, dim, dim2), ButtonStyle.CornerRadius, ButtonStyle.CornerRadius, ButtonStyle.CornerRadius, ButtonStyle.CornerRadius);
		ProgressBarCancelButton.CreateTextures(_0023_003DzmNZD0Zs_003D, this, graphicsPath, null, ButtonStyle.Size, ButtonStyle.Size, dim, dim2, RenderContextUtility.ConvertColor(ButtonStyle.HighlightColor));
		graphicsPath.Dispose();
		if (_0023_003DzipBYly6zFKAp() == _0023_003DzYzWi5Yw_003D)
		{
			ProgressBar._0023_003Dz8WTvZ9I_003D(this, _0023_003DzYzWi5Yw_003D);
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		hasFocus = true;
		_0023_003Dz_XPtrr_DYLmiXjAB3A_003D_003D();
		if (IsDesignMode())
		{
			_0023_003DzQtM_y9yLRR_0024E();
		}
		else if (_0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count > 0 && _0023_003DzmNZD0Zs_003D != null)
		{
			PaintBackBuffer();
			SwapBuffers();
		}
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		hasFocus = false;
		if (IsDesignMode())
		{
			Invalidate();
		}
		else if (!base.Disposing)
		{
			PaintBackBuffer();
			SwapBuffers();
		}
		if (!_0023_003Dz3FsDfgH0CqdJ)
		{
			_0023_003DzY7PoD1c_003D._0023_003DzvUkLDVo88jah();
			_0023_003DzxIgINtc_003D._0023_003DzvUkLDVo88jah();
		}
		_0023_003Dz3FsDfgH0CqdJ = false;
		base.OnLostFocus(e);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		bool flag = false;
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
		{
			ViewCubeIcon viewCubeIcon = _0023_003DzipBYly6zFKAp().ViewCubeIcon;
			if (viewCubeIcon != null && viewCubeIcon.Visible && viewCubeIcon.PickedEntity != null)
			{
				viewCubeIcon.PickedEntity = null;
				flag = true;
			}
			ToolBar[] toolBars = _0023_003DzipBYly6zFKAp().ToolBars;
			foreach (ToolBar toolBar in toolBars)
			{
				if (!toolBar.Visible)
				{
					continue;
				}
				foreach (ToolBarButton button in toolBar.Buttons)
				{
					if (button._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)1)
					{
						button._0023_003Dzbb_0024Bito_003D((ToolBarButton._0023_003DzJrgugJM_003D)0);
						flag = true;
					}
				}
			}
			if (ProgressBarCancelButton != null && ProgressBarCancelButton.Visible && ProgressBarCancelButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)1)
			{
				ProgressBarCancelButton._0023_003Dzbb_0024Bito_003D((ToolBarButton._0023_003DzJrgugJM_003D)0);
				flag = true;
			}
		}
		if (ActionMode == actionType.MagnifyingGlass)
		{
			MagnifyingGlass._0023_003DzPTfEdKLFXzku(_0023_003DzsLHxXyo_003D: true);
			flag = true;
		}
		if (flag && !_0023_003DzZ5L0bhmvC_0024K7)
		{
			PaintBackBuffer();
			SwapBuffers();
		}
	}

	private void _0023_003DzQt_00244rxgMFuM6PMi1LaBJvjEkba_0024zi_sy3ALTzYFmSefX(bool _0023_003DzGAlSkUs_003D)
	{
		_0023_003Dznl6vpID_7KEeHuMw7Q_003D_003D = new _0023_003DzeolFlXynhpfb
		{
			_0023_003Dzq7xhhPo_003D = ActionMode,
			_0023_003DzsvHVwxEyCKRY = _0023_003DzFqaEE7IhVORj(cursorType.Wait)
		};
		ActionMode = actionType.None;
		if (_0023_003DzGAlSkUs_003D)
		{
			Clear();
		}
	}

	void IWorkspaceInternal.PreSaveOpenFile(bool _0023_003DzGAlSkUs_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zQt$4rxgMFuM6PMi1LaBJvjEkba$zi_sy3ALTzYFmSefX
		this._0023_003DzQt_00244rxgMFuM6PMi1LaBJvjEkba_0024zi_sy3ALTzYFmSefX(_0023_003DzGAlSkUs_003D);
	}

	private void _0023_003DzWrF_0024U8QBySY8L1C33j8VRVQSxU9VdlgZbRWCcyBvEHB3()
	{
		_0023_003DzV0Su6Jg_003D(_0023_003Dznl6vpID_7KEeHuMw7Q_003D_003D._0023_003DzsvHVwxEyCKRY.Value);
		ActionMode = _0023_003Dznl6vpID_7KEeHuMw7Q_003D_003D._0023_003Dzq7xhhPo_003D.Value;
		_0023_003Dznl6vpID_7KEeHuMw7Q_003D_003D = null;
	}

	void IWorkspaceInternal.PostSaveOpenFile()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zWrF$U8QBySY8L1C33j8VRVQSxU9VdlgZbRWCcyBvEHB3
		this._0023_003DzWrF_0024U8QBySY8L1C33j8VRVQSxU9VdlgZbRWCcyBvEHB3();
	}

	public static void EvaluateBoundingBox(ICollection<Entity> entList, out Point3D globalMin, out Point3D globalMax)
	{
		globalMin = Point3D.MaxValue;
		globalMax = Point3D.MinValue;
		foreach (Entity ent in entList)
		{
			if (ent.BoxMin.X < globalMin.X)
			{
				globalMin.X = ent.BoxMin.X;
			}
			if (ent.BoxMax.X > globalMax.X)
			{
				globalMax.X = ent.BoxMax.X;
			}
			if (ent.BoxMin.Y < globalMin.Y)
			{
				globalMin.Y = ent.BoxMin.Y;
			}
			if (ent.BoxMax.Y > globalMax.Y)
			{
				globalMax.Y = ent.BoxMax.Y;
			}
			if (ent.BoxMin.Z < globalMin.Z)
			{
				globalMin.Z = ent.BoxMin.Z;
			}
			if (ent.BoxMax.Z > globalMax.Z)
			{
				globalMax.Z = ent.BoxMax.Z;
			}
		}
	}

	public override void BeginInit()
	{
		_0023_003DzlNGYbbA_003D = true;
	}

	public override void EndInit()
	{
		_0023_003DzlNGYbbA_003D = false;
		UpdateDesignModeScene();
	}

	internal void _0023_003DzB1m_0024n23EMG5fmyf_00241w_003D_003D()
	{
		Mouse3DMove -= OnMouse3DMove;
		Mouse3DButtonDown -= OnMouse3DButtonDown;
		Mouse3DButtonUp -= OnMouse3DButtonUp;
		if (base.Enabled)
		{
			Mouse3DMove += OnMouse3DMove;
			Mouse3DButtonDown += OnMouse3DButtonDown;
			Mouse3DButtonUp += OnMouse3DButtonUp;
		}
	}

	private static SelectionBoxColorsSettings _0023_003Dzh0ZkCLj0saH9BNNbaQ_003D_003D()
	{
		return new SelectionBoxColorsSettings();
	}

	private bool ShouldSerializeSelectionBoxColors()
	{
		return SelectionBoxColors._0023_003Dz4XAvJ5aCRLKs(_0023_003Dzh0ZkCLj0saH9BNNbaQ_003D_003D());
	}

	private void ResetSelectionBoxColors()
	{
		SelectionBoxColors = _0023_003Dzh0ZkCLj0saH9BNNbaQ_003D_003D();
	}

	private static void _0023_003DzOKUxuj_0024UjDI7jXhG65BUZjE_003D(IList<Entity> _0023_003DzQDU9c0AE6yqQ)
	{
		for (int i = 0; i < _0023_003DzQDU9c0AE6yqQ.Count; i++)
		{
			Entity entity = _0023_003DzQDU9c0AE6yqQ[i];
			if (entity is Solid)
			{
				if (((Solid)entity).Faces != null)
				{
					((Solid)entity).Faces.Clear();
				}
			}
			else if (entity is Mesh && ((Mesh)entity).Faces != null)
			{
				((Mesh)entity).Faces.Clear();
			}
		}
	}

	private static MagnifyingGlassSettings _0023_003Dz7va6ZxKHVCwTnwuSAsAJLHbJRta7()
	{
		return new MagnifyingGlassSettings();
	}

	private bool ShouldSerializeMagnifyingGlass()
	{
		return MagnifyingGlass._0023_003Dz4XAvJ5aCRLKs(_0023_003Dz7va6ZxKHVCwTnwuSAsAJLHbJRta7());
	}

	private void ResetMagnifyingGlass()
	{
		MagnifyingGlass = _0023_003Dz7va6ZxKHVCwTnwuSAsAJLHbJRta7();
	}

	internal void _0023_003DzwuiFtChRA95l()
	{
		try
		{
			if (_0023_003DznKkOfo8_003D.PlanarReflections)
			{
				_0023_003DzO5pd3YKMgnZIKCbw0br7uQQ_003D();
			}
			_0023_003DzmNZD0Zs_003D.InitStandardShaders(_0023_003DznKkOfo8_003D.RealisticShadowQuality, ref StandardShaders, _0023_003DzmNZD0Zs_003D.ActiveLights);
			_0023_003DzmNZD0Zs_003D.InitBlurShader();
		}
		catch (GraphicsException)
		{
			_0023_003DzjC4hA2I_003D.ShadersHqrMainSwitch = false;
			_0023_003Dzl9sayiOqFqdH2uqF7A_003D_003D();
		}
		if (_0023_003DzmNZD0Zs_003D.CurrentShaderTechnique == null)
		{
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights, null, force: true);
		}
	}

	internal void _0023_003DzO5pd3YKMgnZIKCbw0br7uQQ_003D()
	{
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.MakeCurrent();
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]._0023_003Dz6OsFdMKWc7KaMbntUA_003D_003D();
			}
		}
	}

	internal void _0023_003DzaZN_GzT00MrX(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.MakeCurrent();
			_0023_003DzYzWi5Yw_003D._0023_003Dz6OsFdMKWc7KaMbntUA_003D_003D();
		}
	}

	private void _0023_003DzkotQIhWAq_x7B3YM9J7RCM4_003D()
	{
		_0023_003DzmNZD0Zs_003D.FreeCompositingObjects();
	}

	private void _0023_003Dzl9sayiOqFqdH2uqF7A_003D_003D()
	{
		if (_0023_003DzbesAu90NcF8KFeewpw_003D_003D != null)
		{
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]._0023_003Dzl9sayiOqFqdH2uqF7A_003D_003D();
			}
			if (_0023_003DzmNZD0Zs_003D.IsDirect3D && _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
			{
				Dictionary<shaderType, IShaderTechnique> shaders = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0]._0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D();
				_0023_003DzmNZD0Zs_003D.CleanUpShaders(ref shaders);
			}
			_0023_003DzmNZD0Zs_003D.CleanUpShaders(ref StandardShaders);
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.None);
			_0023_003DzmNZD0Zs_003D.SetShaders(null, planarReflections: false);
		}
	}

	private bool ShouldSerializeAttributeReferenceVisibilityMode()
	{
		return AttributeReferenceVisibilityMode != attributeReferenceVisibilityType.Normal;
	}

	private void ResetAttributeReferenceVisibilityMode()
	{
		AttributeReferenceVisibilityMode = attributeReferenceVisibilityType.Normal;
	}

	public void SynchronizeAttributes(string blockName)
	{
		Document.SynchronizeAttributes(blockName);
	}

	public void SynchronizeAttributes(IList<BlockReference> blockReferences)
	{
		Document.SynchronizeAttributes(blockReferences);
	}

	internal virtual ToolBar _0023_003DzTN1DFSSGkW6c(Viewport _0023_003Dz7Xo5EoA_003D)
	{
		return null;
	}

	internal virtual ToolBar _0023_003Dz7CYefrTDPabx()
	{
		return null;
	}

	internal void _0023_003Dzk4Sj9EO3_i4N(Viewport _0023_003Dz7Xo5EoA_003D)
	{
		ToolBar toolBar = _0023_003Dz7CYefrTDPabx();
		if (toolBar != null)
		{
			if (_0023_003Dz7Xo5EoA_003D.ToolBars == null || _0023_003Dz7Xo5EoA_003D.ToolBars.Length == 0)
			{
				_0023_003Dz7Xo5EoA_003D.ToolBars = new ToolBar[1] { toolBar };
			}
			else if (_0023_003DzTN1DFSSGkW6c(_0023_003Dz7Xo5EoA_003D) == null)
			{
				List<ToolBar> list = _0023_003Dz7Xo5EoA_003D.ToolBars.ToList();
				list.Insert(1, toolBar);
				_0023_003Dz7Xo5EoA_003D.ToolBars = list.ToArray();
			}
			_0023_003DzqyIi0qJHHOrU(_0023_003Dz7Xo5EoA_003D, _0023_003DzsLHxXyo_003D: true);
		}
	}

	internal void _0023_003DzqyIi0qJHHOrU(Viewport _0023_003Dz7Xo5EoA_003D, bool _0023_003DzsLHxXyo_003D)
	{
		ToolBar toolBar = _0023_003DzTN1DFSSGkW6c(_0023_003Dz7Xo5EoA_003D);
		if (toolBar != null)
		{
			ToolBarButton[] source = toolBar.Buttons.ToArray();
			ToolBarButton toolBarButton = source.FirstOrDefault(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzCEJW_wLMPi8siqW8w9Y4Ib4_003D);
			if (toolBarButton != null)
			{
				toolBarButton.Visible = _0023_003DzsLHxXyo_003D;
			}
			ToolBarButton toolBarButton2 = source.FirstOrDefault(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dz2AcGlOHX7se2ZXxjWMSWRAQ_003D);
			if (toolBarButton2 != null)
			{
				toolBarButton2.Visible = !_0023_003DzsLHxXyo_003D;
			}
		}
	}

	private protected void _0023_003DzHZMqgEfrVWAi(Viewport _0023_003Dz7Xo5EoA_003D, bool _0023_003DzWtFDQr8_003D)
	{
		ToolBar toolBar = _0023_003DzTN1DFSSGkW6c(_0023_003Dz7Xo5EoA_003D);
		if (toolBar == null)
		{
			return;
		}
		foreach (ToolBarButton button in toolBar.Buttons)
		{
			if (button is PauseToolBarButton)
			{
				button.Enabled = !_0023_003DzWtFDQr8_003D;
			}
			else
			{
				button.Enabled = _0023_003DzWtFDQr8_003D;
			}
		}
	}

	internal void _0023_003Dzwrj5SpW0m4rj()
	{
		_0023_003DzP5yJ9F4_003D = new Container();
		_0023_003DzbdLgm9c_003D = new _0023_003DzKNo6tLg_003D();
		base.Size = new Size(200, 200);
	}

	internal static void RunEyeshotToolsForSupport()
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597708),
			UseShellExecute = true
		});
	}

	internal static void _0023_003DzK1ESoHFY2_Cb(Workspace _0023_003DzU0f5_qE_003D)
	{
		if (_0023_003DzU0f5_qE_003D is Drawing _0023_003DzfdgxWgs_003D)
		{
			_0023_003DzYAvelXvz3ksq(_0023_003DzfdgxWgs_003D);
		}
		else if (_0023_003DzU0f5_qE_003D is Manufacture _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D)
		{
			_0023_003Dzo8MpX6w0MwC2lV03B20_0024TUk_003D(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D);
		}
		else if (_0023_003DzU0f5_qE_003D is Simulation _0023_003DzWHe05aBZg1xEg2IohA_003D_003D)
		{
			_0023_003Dzg1oAVTJCHtNe(_0023_003DzWHe05aBZg1xEg2IohA_003D_003D);
		}
		else
		{
			_0023_003Dzl3x_0Aw_k0es(_0023_003DzU0f5_qE_003D as Design, null);
		}
		if (_0023_003DzU0f5_qE_003D.Parent != null)
		{
			_0023_003DzU0f5_qE_003D.BackColor = Color.FromArgb(255, _0023_003DzU0f5_qE_003D.Parent.BackColor);
			_0023_003DzU0f5_qE_003D.UpdateDesignModeScene();
		}
	}

	internal static void _0023_003DzYAvelXvz3ksq(Drawing _0023_003DzfdgxWgs_003D)
	{
		try
		{
			if (_0023_003DzfdgxWgs_003D._0023_003DzmNZD0Zs_003D == null)
			{
				_0023_003DzfdgxWgs_003D.CreateControl();
			}
			if (_0023_003DzfdgxWgs_003D.Sheets == null)
			{
				_0023_003DzfdgxWgs_003D.Sheets = new SheetKeyedCollection();
			}
			ReadFile readFile = new ReadFile(new MemoryStream(_0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzacN2fWQYFfZiUvmPGg_003D_003D()));
			readFile.RestoreCamera = false;
			readFile.DoWork();
			readFile.OpenTo(_0023_003DzfdgxWgs_003D);
			_0023_003DzfdgxWgs_003D.ActiveSheetIndex = 0;
			_0023_003DzfdgxWgs_003D.Invalidate();
			_0023_003DzfdgxWgs_003D.SetView(viewType.Top, fit: true, animate: false);
		}
		catch (Exception exception)
		{
			Logger.Instance.Error(_0023_003DzfdgxWgs_003D.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597756), exception);
		}
	}

	internal static void _0023_003Dzl3x_0Aw_k0es(Design _0023_003DzFjK2_0024i0_003D, Drawing _0023_003DzfdgxWgs_003D)
	{
		try
		{
			bool flag = _0023_003DzR6_0024SSJwlV2vt(_0023_003DzFjK2_0024i0_003D, _0023_003DzvNNbLbz6_0024BH3: true);
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.Labels.Clear();
			_0023_003DzFjK2_0024i0_003D.Entities.Clear();
			_0023_003DzFjK2_0024i0_003D.Materials.Clear();
			_0023_003DzfdgxWgs_003D?.Clear();
			ReadFile readFile = new ReadFile(new MemoryStream(_0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzacN2fWQYFfZiUvmPGg_003D_003D()))
			{
				RestoreCamera = flag
			};
			readFile.DoWork();
			readFile.OpenTo(_0023_003DzFjK2_0024i0_003D);
			if (flag)
			{
				_0023_003DzN0AE_7lX4bcMnyV9Yg_003D_003D(_0023_003DzFjK2_0024i0_003D);
			}
			if (_0023_003DzfdgxWgs_003D != null)
			{
				readFile.OpenTo(_0023_003DzfdgxWgs_003D);
				_0023_003DzfdgxWgs_003D.Invalidate();
			}
		}
		catch (Exception exception)
		{
			Logger.Instance.Error(_0023_003DzFjK2_0024i0_003D.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597526), exception);
		}
	}

	private static bool _0023_003DzR6_0024SSJwlV2vt(Workspace _0023_003DzU0f5_qE_003D, bool _0023_003DzvNNbLbz6_0024BH3)
	{
		bool result = _0023_003DzU0f5_qE_003D.Tag != null && _0023_003DzU0f5_qE_003D.Tag.ToString().Equals(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597558));
		if (_0023_003DzvNNbLbz6_0024BH3)
		{
			_0023_003DzU0f5_qE_003D.Tag = null;
		}
		return result;
	}

	private static void _0023_003DzN0AE_7lX4bcMnyV9Yg_003D_003D(Design _0023_003DzFjK2_0024i0_003D)
	{
		if (_0023_003DzFjK2_0024i0_003D.ActiveViewport.Grid != null)
		{
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.Grid.AutoSize = false;
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.Grid.Min = new Point2D(-100.0, -100.0);
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.Grid.Max = new Point2D(100.0, 100.0);
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.Grid.Step = 10.0;
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.Grid.Lighting = false;
		}
		if (_0023_003DzFjK2_0024i0_003D.ActiveViewport.OriginSymbol != null)
		{
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.OriginSymbol.Lighting = false;
		}
		if (_0023_003DzFjK2_0024i0_003D.ActiveViewport.CoordinateSystemIcon != null)
		{
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.CoordinateSystemIcon.Lighting = false;
		}
		if (_0023_003DzFjK2_0024i0_003D.ActiveViewport.ViewCubeIcon != null)
		{
			_0023_003DzFjK2_0024i0_003D.ActiveViewport.ViewCubeIcon.Lighting = false;
		}
	}

	internal static void _0023_003Dzo8MpX6w0MwC2lV03B20_0024TUk_003D(Manufacture _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D)
	{
		try
		{
			bool flag = _0023_003DzR6_0024SSJwlV2vt(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D, _0023_003DzvNNbLbz6_0024BH3: true);
			_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.ActiveViewport.Labels.Clear();
			_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.Entities.Clear();
			_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.Materials.Clear();
			ReadFile readFile = new ReadFile(new MemoryStream(_0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzOx_250ztDZgFqQZqmwcSkPq5ktz9()));
			readFile.RestoreCamera = flag;
			readFile.DoWork();
			readFile.OpenTo(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D);
			if (flag)
			{
				_0023_003DzN0AE_7lX4bcMnyV9Yg_003D_003D(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D);
				if (_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.ActiveViewport.OriginSymbol != null)
				{
					_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.ActiveViewport.OriginSymbol.Visible = false;
				}
				if (_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.ActiveViewport.Grid != null)
				{
					_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.ActiveViewport.Grid.Visible = true;
				}
			}
		}
		catch (Exception exception)
		{
			Logger.Instance.Error(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597594), exception);
		}
	}

	internal static void _0023_003Dzg1oAVTJCHtNe(Simulation _0023_003DzWHe05aBZg1xEg2IohA_003D_003D)
	{
		try
		{
			bool flag = _0023_003DzR6_0024SSJwlV2vt(_0023_003DzWHe05aBZg1xEg2IohA_003D_003D, _0023_003DzvNNbLbz6_0024BH3: true);
			_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.ActiveViewport.Labels.Clear();
			_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.Entities.Clear();
			_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.Materials.Clear();
			ReadFile readFile = new ReadFile(new MemoryStream(_0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003Dz6r9zvAmXrfKOWaJ9QQ_003D_003D()));
			readFile.RestoreCamera = flag;
			readFile.DoWork();
			readFile.OpenTo(_0023_003DzWHe05aBZg1xEg2IohA_003D_003D);
			if (flag)
			{
				_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.ActiveViewport.DisplayMode = displayType.Shaded;
				_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.Shaded.ShadowMode = shadowType.None;
				if (_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.ActiveViewport.Legends == null || _0023_003DzWHe05aBZg1xEg2IohA_003D_003D.ActiveViewport.Legends.Length == 0)
				{
					_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.ActiveViewport.Legends = new Legend[1]
					{
						new Legend()
					};
				}
				_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.ActiveViewport.Legends[0].Lighting = false;
				if (_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.ActiveViewport.Histogram != null)
				{
					_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.ActiveViewport.Histogram.Visible = true;
				}
				_0023_003DzN0AE_7lX4bcMnyV9Yg_003D_003D(_0023_003DzWHe05aBZg1xEg2IohA_003D_003D);
			}
		}
		catch (Exception exception)
		{
			Logger.Instance.Error(_0023_003DzWHe05aBZg1xEg2IohA_003D_003D.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597594), exception);
		}
	}

	internal void _0023_003DzQtM_y9yLRR_0024E()
	{
		Invalidate();
		_0023_003Dzwp0pao5NhqfO();
	}

	public new void Invalidate()
	{
		_0023_003DzOKl0QUWVZez4();
		base.Invalidate();
	}

	public override void Refresh()
	{
		_0023_003DzOKl0QUWVZez4();
		base.Refresh();
	}

	internal void _0023_003DzOKl0QUWVZez4()
	{
		_0023_003DzZ5L0bhmvC_0024K7 = true;
		_0023_003DzEve6E9qqZPdg = -1;
		_0023_003DzlPALPXW8i7Fn11_cJNElnPw_003D();
	}

	internal void _0023_003DzH_ACO1keHrO4()
	{
		_0023_003DzxGGgnz7xWECo(_0023_003DzBn2ByFKdwrou);
	}

	internal void _0023_003DzxGGgnz7xWECo(int _0023_003DzZnwLfu4_003D)
	{
		if (_0023_003DzZ5L0bhmvC_0024K7)
		{
			_0023_003DzfQAlCNjaguj4Z7M_Pw_003D_003D(_0023_003DzZnwLfu4_003D);
		}
		_0023_003DzlPALPXW8i7Fn11_cJNElnPw_003D();
		_0023_003DzEve6E9qqZPdg = _0023_003DzZnwLfu4_003D;
		_0023_003DzZ5L0bhmvC_0024K7 = false;
		base.Invalidate();
	}

	private void _0023_003DzfQAlCNjaguj4Z7M_Pw_003D_003D(int _0023_003DzBY3F_0024QVf1NMY)
	{
		if (_0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count == 0 || _0023_003DzmNZD0Zs_003D == null)
		{
			return;
		}
		_0023_003DzmNZD0Zs_003D.MakeCurrent();
		if (!_0023_003Dz8Q16RtM94O0K())
		{
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				if (i != _0023_003DzBY3F_0024QVf1NMY)
				{
					_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i].Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
					_0023_003Dz6LfbgRAYOjvE(_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i], 1f, _0023_003DzQmbl9PzBp44d, default(RectangleF), _0023_003Dzwf0rgOdP0NZJ: false, _0023_003DzBX_0024lgUSbQHBj: false, _0023_003DznwIKlITwQSgi: false, _0023_003DzLkl_mewv7s2Z: true, _0023_003DzIHwNrERoZxEh: false, null, _0023_003DzsazSka94g8G9H0qAvn5f_0024fw_003D: true);
				}
			}
		}
		if (_0023_003Dzo_MNAFBAjuGu == 0)
		{
			_0023_003DzyhKDqgU_003D(_0023_003DzfGQgbSqgv2vE: true, _0023_003DzMNQtdF5md6lME489aqjEcF0_003D: false);
		}
		_0023_003DzZ5L0bhmvC_0024K7 = false;
	}

	internal void _0023_003Dzwp0pao5NhqfO()
	{
		if (_0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count != 0 && _0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.MakeCurrent();
			_0023_003DzmNZD0Zs_003D.ClearColor(Color.White);
			_0023_003DzX9WWjBxxe947(-1);
			_0023_003DzZ5L0bhmvC_0024K7 = false;
		}
	}

	internal void _0023_003Dzwp0pao5NhqfO(int _0023_003DzZnwLfu4_003D)
	{
		if (_0023_003DzZnwLfu4_003D != -1 && _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 1)
		{
			_0023_003Dz79nZuepFnxns0RGZBQ_003D_003D(_0023_003DzMNQtdF5md6lME489aqjEcF0_003D: false);
		}
		else
		{
			_0023_003DzZ5L0bhmvC_0024K7 = false;
		}
		_0023_003DzX9WWjBxxe947(_0023_003DzZnwLfu4_003D);
		_0023_003DzEve6E9qqZPdg = -1;
	}

	internal static bool _0023_003Dz90lrgtZ04hwu(Size _0023_003DzsLHxXyo_003D)
	{
		if (_0023_003DzsLHxXyo_003D.Width < 2 || _0023_003DzsLHxXyo_003D.Height < 2)
		{
			return false;
		}
		return true;
	}

	private void _0023_003DzX9WWjBxxe947(int _0023_003DzZnwLfu4_003D)
	{
		if (!_0023_003Dz90lrgtZ04hwu(base.Size) || _0023_003Dz8Q16RtM94O0K())
		{
			return;
		}
		if (_0023_003DzZnwLfu4_003D == -1)
		{
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i].Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
			}
		}
		else
		{
			Viewport viewport = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[_0023_003DzZnwLfu4_003D];
			if (viewport == null)
			{
				return;
			}
			viewport.Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
		}
		_0023_003Dz6LfbgRAYOjvE((_0023_003DzZnwLfu4_003D == -1) ? null : _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[_0023_003DzZnwLfu4_003D], 1f, _0023_003DzQmbl9PzBp44d, default(RectangleF), _0023_003Dzwf0rgOdP0NZJ: false, _0023_003DzBX_0024lgUSbQHBj: false, _0023_003DznwIKlITwQSgi: false, _0023_003DzLkl_mewv7s2Z: true, _0023_003DzIHwNrERoZxEh: false, null, _0023_003DzsazSka94g8G9H0qAvn5f_0024fw_003D: true);
		if (_0023_003Dzo_MNAFBAjuGu == 0)
		{
			_0023_003DzyhKDqgU_003D(_0023_003DzfGQgbSqgv2vE: true, _0023_003DzMNQtdF5md6lME489aqjEcF0_003D: false);
		}
		if (_0023_003DzmNZD0Zs_003D.NeedsToCaptureDepth())
		{
			_0023_003DzmNZD0Zs_003D.BeginDrawForDepth();
			Viewport viewport2 = _0023_003DzipBYly6zFKAp();
			viewport2.Camera.useProjectionMatrixForSelected = false;
			_0023_003Dz6LfbgRAYOjvE(viewport2, 1f, _0023_003DzQmbl9PzBp44d, default(RectangleF), _0023_003Dzwf0rgOdP0NZJ: false, _0023_003DzBX_0024lgUSbQHBj: false, _0023_003DznwIKlITwQSgi: false, _0023_003DzLkl_mewv7s2Z: true, _0023_003DzIHwNrERoZxEh: true, null, _0023_003DzsazSka94g8G9H0qAvn5f_0024fw_003D: true);
			viewport2.Camera.useProjectionMatrixForSelected = true;
			_0023_003DzmNZD0Zs_003D.EndDrawForDepth();
		}
	}

	private void _0023_003DzyhKDqgU_003D(bool _0023_003DzfGQgbSqgv2vE, bool _0023_003DzMNQtdF5md6lME489aqjEcF0_003D)
	{
		if (_0023_003Dz0P1LCYH__O4t() > 0 && _0023_003DzNwtRJ3cLTrAy() > 0)
		{
			Size size = _0023_003DzipBYly6zFKAp().Size;
			if (size.Width > 0 && size.Height > 0)
			{
				_0023_003DzmNZD0Zs_003D.ReadSurface(base.Size, _0023_003DzfGQgbSqgv2vE, _0023_003DzjC4hA2I_003D.IsAntiAliasingEnabled());
			}
		}
	}

	internal void _0023_003DzHcYFj1p87o4J(Viewport _0023_003DzYzWi5Yw_003D, IList<Entity> _0023_003DzHyqiRqo_003D)
	{
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.MakeCurrent();
		}
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.ColorMaskOff);
		_0023_003DzmNZD0Zs_003D.LockBlendState(lockBlendState: true);
		_0023_003Dz6LfbgRAYOjvE(_0023_003DzYzWi5Yw_003D, 1f, _0023_003DzQmbl9PzBp44d, RectangleF.Empty, _0023_003Dzwf0rgOdP0NZJ: false, _0023_003DzBX_0024lgUSbQHBj: false, _0023_003DznwIKlITwQSgi: false, _0023_003DzLkl_mewv7s2Z: false, _0023_003DzIHwNrERoZxEh: true, _0023_003DzHyqiRqo_003D, _0023_003DzsazSka94g8G9H0qAvn5f_0024fw_003D: true);
		_0023_003DzmNZD0Zs_003D.LockBlendState(lockBlendState: false);
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
	}

	internal void _0023_003Dz79nZuepFnxns0RGZBQ_003D_003D(bool _0023_003DzMNQtdF5md6lME489aqjEcF0_003D)
	{
		if (_0023_003Dz0P1LCYH__O4t() > 0 && _0023_003DzNwtRJ3cLTrAy() > 0 && !_0023_003Dz8Q16RtM94O0K())
		{
			_0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
			_0023_003DzmNZD0Zs_003D.PaintBackBuffer(base.Size, _0023_003DzipBYly6zFKAp().Camera, _0023_003DzjC4hA2I_003D.IsAntiAliasingEnabled());
		}
	}

	protected void DrawScene(Viewport viewport, float drawScale, float lineWeightFactor, RectangleF zoomRect, bool drawOverlay, bool swapBuffer, bool isDesignMode)
	{
		_0023_003Dz6LfbgRAYOjvE(viewport, drawScale, lineWeightFactor, zoomRect, drawOverlay, swapBuffer, isDesignMode, _0023_003DzLkl_mewv7s2Z: false, _0023_003DzIHwNrERoZxEh: false, null, _0023_003DzsazSka94g8G9H0qAvn5f_0024fw_003D: true);
	}

	internal void _0023_003Dz6LfbgRAYOjvE(Viewport _0023_003DzYzWi5Yw_003D, float _0023_003DzCzsr4CTVr_Ea, float _0023_003DzCs_ZxbN2mZ30, RectangleF _0023_003DzF7kGEgqMZE2_, bool _0023_003Dzwf0rgOdP0NZJ, bool _0023_003DzBX_0024lgUSbQHBj, bool _0023_003DznwIKlITwQSgi, bool _0023_003DzLkl_mewv7s2Z, bool _0023_003DzIHwNrERoZxEh, IList<Entity> _0023_003DzduSfKRsNCJOs, bool _0023_003DzsazSka94g8G9H0qAvn5f_0024fw_003D)
	{
		if (_0023_003DzsazSka94g8G9H0qAvn5f_0024fw_003D)
		{
			_0023_003DzlPALPXW8i7Fn11_cJNElnPw_003D();
		}
		DrawSceneParams _0023_003Dzt5jpbHs_003D = new DrawSceneParams
		{
			Viewport = _0023_003DzYzWi5Yw_003D,
			DrawScale = _0023_003DzCzsr4CTVr_Ea,
			LineWeightFactor = _0023_003DzCs_ZxbN2mZ30,
			DrawOverlay = _0023_003Dzwf0rgOdP0NZJ,
			IsDesignMode = _0023_003DznwIKlITwQSgi,
			SwapBuffer = _0023_003DzBX_0024lgUSbQHBj,
			ZoomRect = _0023_003DzF7kGEgqMZE2_,
			CaptureSurface = _0023_003DzLkl_mewv7s2Z,
			ZBufferOnly = _0023_003DzIHwNrERoZxEh,
			Entities = _0023_003DzduSfKRsNCJOs,
			Blocks = _0023_003DzoE3BE__0024RS_DJ(),
			RenderContext = _0023_003DzmNZD0Zs_003D,
			Simplify = _0023_003DzTAGVj_ePZ3pfzt_uDQ_003D_003D(),
			isSketchActive = (this is Design design && design.CurrentSketch != null)
		};
		_0023_003Dz6LfbgRAYOjvE(_0023_003Dzt5jpbHs_003D);
	}

	internal void _0023_003Dz6LfbgRAYOjvE(object _0023_003Dzt5jpbHs_003D)
	{
		if (_0023_003Dz8Q16RtM94O0K())
		{
			return;
		}
		DrawSceneParams drawSceneParams = (DrawSceneParams)_0023_003Dzt5jpbHs_003D;
		_0023_003DzmNZD0Zs_003D.MakeCurrent();
		if (_0023_003Dz8Q16RtM94O0K())
		{
			return;
		}
		_0023_003DzgES1H_48XRD7GgtPkA_003D_003D();
		_0023_003DzS_0024HznE_piKROMPCyBg_003D_003D(drawSceneParams);
		_0023_003DzI5CJrSxma7iW.Restart();
		_0023_003DzmNZD0Zs_003D.UpdateActiveLights(_0023_003DzMuApP021PUyU);
		if (drawSceneParams.Viewport == null)
		{
			DrawBackground(drawSceneParams);
		}
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
		{
			if (_0023_003DzJ4jbvfHrmEXJhAZd3A_003D_003D && drawSceneParams.Entities.Count > 0)
			{
				Exception ex = null;
				object[] array = null;
				array = new object[1] { ex };
				_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "\"TA?\"q\"acS", array);
			}
			drawSceneParams.RenderContext.CheckShadersAndLights(StandardShaders, _0023_003DznKkOfo8_003D.RealisticShadowQuality, _0023_003DzipBYly6zFKAp().Background);
			if (drawSceneParams.Viewport == null || (_0023_003DzZ5L0bhmvC_0024K7 && drawSceneParams.SwapBuffer))
			{
				if (drawSceneParams.IsDesignMode)
				{
					_0023_003Dzo9fnIg17P_0024XX(drawSceneParams);
				}
				else
				{
					for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
					{
						if (i != _0023_003DzBn2ByFKdwrou)
						{
							drawSceneParams.Viewport = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i];
							DrawViewport(drawSceneParams);
						}
					}
					drawSceneParams.Viewport = _0023_003DzipBYly6zFKAp();
					DrawViewport(drawSceneParams);
				}
			}
			else
			{
				if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 1 && !drawSceneParams.CaptureSurface && drawSceneParams.SwapBuffer)
				{
					_0023_003Dz79nZuepFnxns0RGZBQ_003D_003D(_0023_003DzMNQtdF5md6lME489aqjEcF0_003D: false);
				}
				DrawViewport(drawSceneParams);
			}
		}
		_0023_003DzWSqUvCw_003D(drawSceneParams);
		if (!drawSceneParams.ssaoEnabled)
		{
			_0023_003Dz3DkUdi9lDAzOnDliOSavl_0024Q_003D(drawSceneParams);
		}
	}

	private void _0023_003DzS_0024HznE_piKROMPCyBg_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzoJ3C7DgwDQct)
		{
			_0023_003DzCBM7XJK4_5H_0024.Entities = new List<Entity>();
		}
		else if (_0023_003DzCBM7XJK4_5H_0024.Entities == null)
		{
			_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing = _0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW() && !_0023_003DzCBM7XJK4_5H_0024.Simplify && !_0023_003DzCBM7XJK4_5H_0024.ZBufferOnly && !_0023_003DzCBM7XJK4_5H_0024.IsDesignMode && !_0023_003DzkQRTXiC03yes;
			_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers = _0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW() && !_0023_003DzCBM7XJK4_5H_0024.ZBufferOnly && !_0023_003DzCBM7XJK4_5H_0024.IsDesignMode;
			if (_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers)
			{
				_0023_003Dz1KRwfFqyZNLurMj2oRC6_YZThceT();
			}
			if ((_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing || _0023_003DzkQRTXiC03yes) && _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers && _0023_003Dzo_MNAFBAjuGu == 0)
			{
				double _0023_003DzBRNuU48_003D = (_0023_003DzkQRTXiC03yes ? 0.0 : _0023_003DzW9xZcbsM9yIJ);
				_0023_003Dz0oVCAhJkx9xLbPH1_00241DKD_9KTOFjLxLflQ_003D_003D(_0023_003DzBRNuU48_003D);
			}
			if ((_0023_003DzCBM7XJK4_5H_0024.Simplify || _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers) && _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D != null)
			{
				_0023_003DzCBM7XJK4_5H_0024.Entities = _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D;
			}
			else
			{
				_0023_003DzCBM7XJK4_5H_0024.Entities = _0023_003DzOWfUZLjOSimJ();
			}
		}
	}

	protected internal virtual void DrawBackground(DrawSceneParams myParams)
	{
		Color color = _0023_003DzU7yFFKcRyseX();
		if (!myParams.isProgressiveDrawing || _0023_003Dzo_MNAFBAjuGu == 0)
		{
			_0023_003DzmNZD0Zs_003D.ClearColor(color);
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(myParams))
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.ClearAllBuffers(Color.FromArgb(0, 0, 0, 0));
			}
		}
		else if (myParams.isProgressiveDrawing && _0023_003DzK3IgbzPkGgv8)
		{
			_0023_003Dz79nZuepFnxns0RGZBQ_003D_003D(_0023_003DzMNQtdF5md6lME489aqjEcF0_003D: true);
		}
	}

	private void _0023_003DzWSqUvCw_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003Dz8Q16RtM94O0K())
		{
			return;
		}
		if (_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing && (_0023_003Dzo_MNAFBAjuGu != 0 || !_0023_003DzCBM7XJK4_5H_0024.isLastBatch))
		{
			_0023_003DzyhKDqgU_003D(_0023_003DzfGQgbSqgv2vE: true, !_0023_003DzCBM7XJK4_5H_0024.isLastBatch);
			MagnifyingGlass._0023_003DzPTfEdKLFXzku(_0023_003DzsLHxXyo_003D: true);
		}
		if (_0023_003DzCBM7XJK4_5H_0024.DrawOverlay)
		{
			if (Mouse3D._0023_003DzKtY32O6TIGh92V9VOrkpc9c_003D())
			{
				Mouse3D._0023_003DzI8QnuD_uT7AD(null);
			}
			_0023_003DzhJ_0024tWgoKIkC8hUNqKg_003D_003D(_0023_003DzCBM7XJK4_5H_0024);
		}
		if (_0023_003DzCBM7XJK4_5H_0024.ssaoEnabled)
		{
			_0023_003Dz3DkUdi9lDAzOnDliOSavl_0024Q_003D(_0023_003DzCBM7XJK4_5H_0024);
		}
		_0023_003DzmNZD0Zs_003D.EndDraw(_0023_003DzCBM7XJK4_5H_0024.SwapBuffer);
		if (!_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing)
		{
			return;
		}
		if (_0023_003DzCBM7XJK4_5H_0024.isLastBatch)
		{
			bool num = _0023_003Dzo_MNAFBAjuGu != 0;
			_0023_003DzlPALPXW8i7Fn11_cJNElnPw_003D();
			if (num)
			{
				_0023_003DzqXHhezDGoHtfbDsULOweypwzHKGTXdClTg_003D_003D((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport);
				Telemetry.Instance.ProgressiveDrawing = true;
			}
		}
		else
		{
			_0023_003Dzo_MNAFBAjuGu++;
			base.Invalidate();
		}
	}

	private void _0023_003DzqXHhezDGoHtfbDsULOweypwzHKGTXdClTg_003D_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (ActionMode != actionType.SelectVisibleByPickDynamic && ActionMode != actionType.MagnifyingGlass)
		{
			return;
		}
		System.Drawing.Point point = _0023_003DzhOqjhfgpYUK7();
		MouseEventArgs e = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);
		if (_0023_003DzYzWi5Yw_003D.Contains(e.Location) && !_0023_003DzR8L_0024Yw_00244jJcu(_0023_003DzYzWi5Yw_003D, e))
		{
			bool _0023_003DzprYbenN6veHPuANVgQ_003D_003D = false;
			if (ActionMode == actionType.SelectVisibleByPickDynamic)
			{
				_0023_003DzprYbenN6veHPuANVgQ_003D_003D = _0023_003DzDNLc1QbWJ8j9(e, _0023_003DzTH5R2akZauqJ: false, _0023_003DzYzWi5Yw_003D, ref _0023_003DzprYbenN6veHPuANVgQ_003D_003D);
			}
			else
			{
				MagnifyingGlass._0023_003DzPTfEdKLFXzku(_0023_003DzsLHxXyo_003D: false);
				MagnifyingGlass._0023_003DzMhJnK2KPd8YE(this, e.Location);
				_0023_003DzprYbenN6veHPuANVgQ_003D_003D = true;
			}
			if (_0023_003DzprYbenN6veHPuANVgQ_003D_003D)
			{
				PaintBackBuffer();
				SwapBuffers();
			}
		}
	}

	internal bool _0023_003DztwOIOjldWKgIr8FLtvj_0024kdA_003D()
	{
		if (_0023_003DzmNZD0Zs_003D.smoothUICompositing != null)
		{
			return _0023_003DzmNZD0Zs_003D.smoothUICompositing.IsAvailable();
		}
		return false;
	}

	private static bool _0023_003Dz6UjqFddSBMbXkG5MSg_003D_003D(IViewportInternal _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DzYzWi5Yw_003D.parent is Design design)
		{
			return design.CurrentSketch != null;
		}
		return false;
	}

	internal bool _0023_003Dz1KGNi_0024Q0b0RBwwPsIg_003D_003D(IViewportInternal _0023_003DzYzWi5Yw_003D)
	{
		if (!_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(_0023_003DzYzWi5Yw_003D))
		{
			return _0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(_0023_003DzYzWi5Yw_003D);
		}
		return true;
	}

	internal bool _0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(IViewportInternal _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DzD_0024V5s06JeZ8Y0HFjaQ_003D_003D() && !AccurateTransparency && _0023_003DzYzWi5Yw_003D.DisplayMode != displayType.Wireframe && !_0023_003Dz6UjqFddSBMbXkG5MSg_003D_003D(_0023_003DzYzWi5Yw_003D) && _0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing != null)
		{
			return _0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing.IsAvailable();
		}
		return false;
	}

	internal bool _0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(IViewportInternal _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003Dzx6q74t9r4Eis7_00241oag_003D_003D() && !AccurateTransparency && _0023_003DzYzWi5Yw_003D.DisplayMode != displayType.Wireframe && !_0023_003Dz6UjqFddSBMbXkG5MSg_003D_003D(_0023_003DzYzWi5Yw_003D) && _0023_003DzmNZD0Zs_003D.staticSelectionCompositing != null)
		{
			return _0023_003DzmNZD0Zs_003D.staticSelectionCompositing.IsAvailable();
		}
		return false;
	}

	internal bool _0023_003DznD5ss1xVO0yzRCM6X3zl_ow_003D()
	{
		if (_0023_003DzmNZD0Zs_003D.aoCompositing != null && _0023_003DzmNZD0Zs_003D.aoCompositing.IsAvailable())
		{
			return _0023_003DzmNZD0Zs_003D.DepthForPostProcessingAvailable(_0023_003DzjC4hA2I_003D.ControlSize);
		}
		return false;
	}

	internal bool _0023_003DzquyVonCV8C0HGiKMHOwaK808RGjL()
	{
		if (_0023_003DzmNZD0Zs_003D.silhoCompositing != null && _0023_003DzmNZD0Zs_003D.silhoCompositing.IsAvailable())
		{
			return _0023_003DzmNZD0Zs_003D.DepthForPostProcessingAvailable(_0023_003DzjC4hA2I_003D.ControlSize);
		}
		return false;
	}

	private bool _0023_003DzcldL_7X0g_0024muFoDe_002405Mk9Q_003D()
	{
		return AmbientOcclusion?.Enabled ?? false;
	}

	private bool _0023_003DzD_0024V5s06JeZ8Y0HFjaQ_003D_003D()
	{
		return Selection.ColorDynamic.A < byte.MaxValue;
	}

	private bool _0023_003Dzx6q74t9r4Eis7_00241oag_003D_003D()
	{
		return Selection.Color.A < byte.MaxValue;
	}

	private void _0023_003DzhJ_0024tWgoKIkC8hUNqKg_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003Dz0P1LCYH__O4t() < 1 || _0023_003DzNwtRJ3cLTrAy() < 1 || (IsDesignMode() && _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0))
		{
			return;
		}
		Viewport _0023_003DzYzWi5Yw_003D = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		_0023_003Dz3cqGIkKFSLfbvz879SlfmFY_003D = true;
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff);
		_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		if (TempEntities.Count > 0 && _0023_003DzCBM7XJK4_5H_0024.Viewport != null)
		{
			_0023_003Dz89cPk57rASTGmdmTnA_003D_003D(_0023_003DzipBYly6zFKAp(), _0023_003DzPHqp5dQ_003D: false, _0023_003DzCBM7XJK4_5H_0024.ZoomRect, CameraEyePosType.Center, _0023_003Dzk7pNhlbdSzPJ: true);
			_0023_003DzNhVK8gNoCnQg(_0023_003DzCBM7XJK4_5H_0024);
		}
		_0023_003DzsDZysFFbOXiw(_0023_003DzCBM7XJK4_5H_0024.ZoomRect, new int[4]
		{
			0,
			0,
			base.Size.Width,
			base.Size.Height
		}, base.Size, _0023_003DzYzWi5Yw_003D, !_0023_003Dz1Ft0yE9Vfrre);
		_0023_003DzkzMHCdfVR8LuqFGjNA_003D_003D(_0023_003DzCBM7XJK4_5H_0024);
		DrawOverlay(_0023_003DzCBM7XJK4_5H_0024);
		if (_0023_003DzjC4hA2I_003D.isFsaaAvailable && AntiAliasing)
		{
			_0023_003DzmNZD0Zs_003D.EnableMultisample(enable: true);
		}
		if (!_0023_003DzCBM7XJK4_5H_0024.SwapBuffer && _0023_003DzCBM7XJK4_5H_0024.Viewport != null)
		{
			_0023_003DzxRT2nHwkpqIv(_0023_003DzCBM7XJK4_5H_0024);
		}
		else
		{
			for (int i = 0; i < _0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count; i++)
			{
				_0023_003DzCBM7XJK4_5H_0024.Viewport = _0023_003DzbesAu90NcF8KFeewpw_003D_003D[i];
				_0023_003DzxRT2nHwkpqIv(_0023_003DzCBM7XJK4_5H_0024);
				if (_0023_003DzCBM7XJK4_5H_0024.IsDesignMode && i != _0023_003DzBn2ByFKdwrou && !_0023_003DzCBM7XJK4_5H_0024.Thumbnail)
				{
					_0023_003Dz24IP8F2ZpNmdizSfvQ_003D_003D(_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]);
				}
			}
		}
		_0023_003DzsDZysFFbOXiw(_0023_003DzCBM7XJK4_5H_0024.ZoomRect, new int[4]
		{
			0,
			0,
			base.Size.Width,
			base.Size.Height
		}, base.Size, _0023_003DzYzWi5Yw_003D, !_0023_003DzCBM7XJK4_5H_0024.ZoomRect.IsEmpty);
		if (!_0023_003DzCBM7XJK4_5H_0024.Thumbnail)
		{
			_0023_003Dz0P1LCYH__O4t();
			_0023_003DzNwtRJ3cLTrAy();
			if (!_0023_003DzCBM7XJK4_5H_0024.Rectangle.IsEmpty)
			{
				_ = _0023_003DzCBM7XJK4_5H_0024.Rectangle.Width;
				_ = _0023_003DzCBM7XJK4_5H_0024.Rectangle.Height;
			}
		}
		if (!_0023_003DzCBM7XJK4_5H_0024.IsUIElement)
		{
			BackgroundSettings background = _0023_003DzipBYly6zFKAp().Background;
			if (_0023_003DzoJ3C7DgwDQct)
			{
				SizeF scalingLevel = UtilityEx.GetScalingLevel();
				DrawText((int)(30f * scalingLevel.Width), _0023_003DzNwtRJ3cLTrAy() - (int)(50f * scalingLevel.Height), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348640585), new Font(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597621), 14f), Color.FromArgb(127, background.GetContrastColor()), Color.Empty, ContentAlignment.TopLeft);
				DrawText((int)(30f * scalingLevel.Width), _0023_003DzNwtRJ3cLTrAy() - (int)(80f * scalingLevel.Height), _0023_003DzJmK5T9E32z5d._0023_003DzOzZvN_0024_89ezkTnhi0iE5RL3fOAVM, new Font(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590336), 14f), Color.FromArgb(127, background.GetContrastColor()), Color.Empty, ContentAlignment.TopLeft);
			}
			if (_0023_003DzCBM7XJK4_5H_0024.RenderContext.Shaders != null)
			{
				foreach (KeyValuePair<shaderType, IShaderTechnique> shader in _0023_003DzCBM7XJK4_5H_0024.RenderContext.Shaders)
				{
					shader.Value.UpdatedInFrame = false;
				}
			}
			if (_0023_003DzE61nM_aOZBgx != null && _0023_003DzCBM7XJK4_5H_0024.ZoomRect.IsEmpty)
			{
				if (_0023_003DzE61nM_aOZBgx._0023_003DzAU_lUOBu3f_00246())
				{
					_0023_003DzrY6HOpTjhsgd();
				}
				for (int j = 0; j < _0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count; j++)
				{
					_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[j]._0023_003Dz_lRXhjlDOTvb(_0023_003DzE61nM_aOZBgx.CornerRadius, _0023_003DzE61nM_aOZBgx.Visible, _0023_003DzO_o8M3HUNFVt, _0023_003DzPHIgywQ0bPFl, _0023_003DzBlHCDVjJXeoG, _0023_003DzAekJM0ZtENTE, _0023_003DzkP4DGwYcuX5B);
				}
			}
		}
		if (_0023_003DzjC4hA2I_003D.isFsaaAvailable && AntiAliasing)
		{
			_0023_003DzmNZD0Zs_003D.EnableMultisample(enable: false);
		}
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		_0023_003DzmNZD0Zs_003D.SetViewport(new int[4]
		{
			0,
			0,
			_0023_003Dz0P1LCYH__O4t(),
			_0023_003DzNwtRJ3cLTrAy()
		}, 0.001f, 1f);
		_0023_003Dz3cqGIkKFSLfbvz879SlfmFY_003D = false;
		_0023_003DznmpiQBcqK9AE.Clear();
	}

	private void _0023_003DzkzMHCdfVR8LuqFGjNA_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (this is Design { CurrentSketch: not null } design)
		{
			design.CurrentSketch.DrawOverlay(_0023_003DzCBM7XJK4_5H_0024);
		}
	}

	private bool _0023_003DzHGvJFuFQK858aICrUrxjaUpdZt8H()
	{
		if (_0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count > 1)
		{
			return _0023_003DzmNZD0Zs_003D.HasStencil();
		}
		return false;
	}

	internal void _0023_003DzsDZysFFbOXiw(RectangleF _0023_003DzF7kGEgqMZE2_, int[] _0023_003DzBppTnBIbeUl7, Size _0023_003Dz0ERMHbg_003D, Viewport _0023_003DzYzWi5Yw_003D, bool _0023_003Dz9Rnv95_0024TldTZ)
	{
		_0023_003DzmNZD0Zs_003D.SetViewport(_0023_003DzBppTnBIbeUl7, 0f, 0.001f);
		double[] array = Camera.myOrtho(_0023_003DzmNZD0Zs_003D, 0.0, _0023_003Dz0ERMHbg_003D.Width, 0.0, _0023_003Dz0ERMHbg_003D.Height, -1.0, 1.0);
		if (_0023_003Dz9Rnv95_0024TldTZ && _0023_003DzYzWi5Yw_003D != null)
		{
			array = Camera.ApplyPickMatrix(_0023_003DzmNZD0Zs_003D.ComputePickMatrix(_0023_003DzF7kGEgqMZE2_, new Size(_0023_003DzYzWi5Yw_003D.Size.Width, _0023_003DzYzWi5Yw_003D.Size.Height), new int[4]
			{
				0,
				0,
				_0023_003DzYzWi5Yw_003D.Size.Width,
				_0023_003DzYzWi5Yw_003D.Size.Height
			}), array);
		}
		_0023_003DzmNZD0Zs_003D.SetMatrices(array, null);
	}

	private void _0023_003Dzo9fnIg17P_0024XX(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			return;
		}
		if (_0023_003DzBn2ByFKdwrou >= _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count)
		{
			_0023_003DzBn2ByFKdwrou = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count - 1;
		}
		DrawBackground(_0023_003DzCBM7XJK4_5H_0024);
		_0023_003DzCBM7XJK4_5H_0024.ZBufferOnly = false;
		_0023_003DzCBM7XJK4_5H_0024.Simplify = false;
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
		{
			_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]._0023_003DzjDuhintYzbDe(_0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: true);
			if (i != _0023_003DzBn2ByFKdwrou)
			{
				_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
				_0023_003DzCBM7XJK4_5H_0024.Viewport = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i];
				DrawViewport(_0023_003DzCBM7XJK4_5H_0024);
			}
		}
		_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		_0023_003DzCBM7XJK4_5H_0024.Viewport = _0023_003DzipBYly6zFKAp();
		DrawViewport(_0023_003DzCBM7XJK4_5H_0024);
		_0023_003DzCBM7XJK4_5H_0024.Viewport = viewport;
	}

	private void _0023_003Dz24IP8F2ZpNmdizSfvQ_003D_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		_0023_003DzYzWi5Yw_003D._0023_003DzsDZysFFbOXiw(_0023_003DzNwtRJ3cLTrAy());
		RenderContextBase renderContextBase = _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D;
		renderContextBase.SetLighting(enable: false);
		renderContextBase.SetState(depthStencilStateType.DepthTestOff);
		renderContextBase.SetColorWireframe(Color.FromArgb(127, _0023_003DzU7yFFKcRyseX()));
		Size size = _0023_003DzYzWi5Yw_003D.Size;
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		renderContextBase.DrawQuad(new RectangleF(0f, size.Height, size.Width, size.Height));
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
	}

	internal Plane _0023_003DzrnMI_SiQDx8_0024QFSmZA3zGE6q_QjC4hO9xRf6Hz8_003D()
	{
		Plane xY = Plane.XY;
		double zPos = _0023_003DzgpecnOZK_rLDYEjHUA_003D_003D.GetZPos(_0023_003DzLpjRly40lvq1, null, _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF, _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr, _0023_003DzhxZwygT5_0024eSRWpPtOWHuTPM_003D);
		if (double.IsNaN(zPos))
		{
			return xY;
		}
		_ = Vector3D.AxisZ;
		if (_0023_003DzLpjRly40lvq1 == orientationType.UpAxisZ)
		{
			return new Plane(new double[4]
			{
				0.0,
				0.0,
				1.0,
				0.0 - zPos
			});
		}
		return new Plane(new double[4]
		{
			0.0,
			1.0,
			0.0,
			0.0 - zPos
		});
	}

	private void _0023_003Dz8OFw4fJIo_bHzzEEfGBYMwDs0bYK(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		Camera camera = _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera;
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		_0023_003DzCBM7XJK4_5H_0024.PlanarReflectionsPlane = _0023_003DzrnMI_SiQDx8_0024QFSmZA3zGE6q_QjC4hO9xRf6Hz8_003D();
		if (camera.ProjectionMode == projectionType.Perspective)
		{
			if (_0023_003DzCBM7XJK4_5H_0024.PlanarReflectionsPlane.DistanceTo(camera.Location) < 0.0)
			{
				return;
			}
		}
		else if (Vector3D.Dot(_0023_003DzCBM7XJK4_5H_0024.PlanarReflectionsPlane.AxisZ, camera.ViewNormal) < 0.0)
		{
			return;
		}
		camera.UpdateMatrices();
		_0023_003DzClCMdT3GjxD8PGpNmg_003D_003D = (Camera)camera.Clone();
		camera.Reflect(_0023_003DzCBM7XJK4_5H_0024.PlanarReflectionsPlane);
		_0023_003DzmNZD0Zs_003D.FrontFaceCW = true;
		_0023_003DzCBM7XJK4_5H_0024.ShaderParams = null;
		if (viewport._0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D() == null)
		{
			viewport._0023_003Dz6OsFdMKWc7KaMbntUA_003D_003D();
		}
		_0023_003DzmNZD0Zs_003D.CheckShadersAndLights(viewport._0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D(), _0023_003DznKkOfo8_003D.RealisticShadowQuality, _0023_003DzipBYly6zFKAp().Background);
		_0023_003DzmNZD0Zs_003D.PushShader();
		_0023_003DzmNZD0Zs_003D.SetShaders(viewport._0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D(), planarReflections: true);
		_0023_003DzCBM7XJK4_5H_0024.PlanarReflections = true;
		Draw3D(_0023_003DzCBM7XJK4_5H_0024);
		_0023_003DzCBM7XJK4_5H_0024.PlanarReflections = false;
		_0023_003DzmNZD0Zs_003D.SetShaders(StandardShaders, planarReflections: false, _0023_003DzCBM7XJK4_5H_0024.ShaderParams);
		_0023_003DzmNZD0Zs_003D.PopShader();
		_0023_003DzmNZD0Zs_003D.FrontFaceCW = false;
		camera.Reflect(_0023_003DzCBM7XJK4_5H_0024.PlanarReflectionsPlane);
		camera.UpdateMatrices();
		_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
	}

	private ShaderParameters _0023_003DzGhVyc3iwfBwt(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		Point3D boxMin = _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF;
		Point3D boxMax = _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr;
		Utility.GetBoundingBoxTransformed(null, boxMin, boxMax, out boxMin, out boxMax);
		float reflectionMaxHeight = (float)_0023_003DzCBM7XJK4_5H_0024.PlanarReflectionsPlane.DistanceTo(boxMax);
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		return new ReflectionShaderParameters(_0023_003DzmNZD0Zs_003D, _0023_003DzCBM7XJK4_5H_0024.ViewFrame, viewport.Camera, _0023_003DznKkOfo8_003D.ShadowMode, _0023_003DznKkOfo8_003D.RealisticShadowQuality, viewport._0023_003Dz2bwAPoQwFwzX, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D, _0023_003DznKkOfo8_003D.EnvironmentMapping, _0023_003DzCBM7XJK4_5H_0024.DrawScale / _0023_003DzCBM7XJK4_5H_0024.ViewportScaleRatio, _0023_003DzCBM7XJK4_5H_0024.ZoomRect, _0023_003DzU7yFFKcRyseX(), _0023_003DznKkOfo8_003D.PlanarReflectionsIntensity, _0023_003DzCBM7XJK4_5H_0024.PlanarReflectionsPlane, reflectionMaxHeight, CurrentTransformation ?? new Identity());
	}

	private double _0023_003Dz3v6felo7iqBAZH1Lmw_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, Camera _0023_003DzClCMdT3GjxD8PGpNmg_003D_003D, Plane _0023_003DzOrtNSQnn48wG)
	{
		Plane nearPlane = _0023_003DzClCMdT3GjxD8PGpNmg_003D_003D.NearPlane;
		int num = _0023_003Dz0P1LCYH__O4t() / 2;
		int num2 = _0023_003DzNwtRJ3cLTrAy() / 2;
		int[] viewFrame = _0023_003DzYzWi5Yw_003D.GetViewFrame();
		_0023_003DzClCMdT3GjxD8PGpNmg_003D_003D.ScreenToPlaneInternal(new System.Drawing.Point(num, num2 + 1), nearPlane.Equation, _0023_003DzNwtRJ3cLTrAy(), viewFrame, out var _0023_003DzPjm3jErOBm);
		_0023_003DzClCMdT3GjxD8PGpNmg_003D_003D.ScreenToPlaneInternal(new System.Drawing.Point(num, num2), nearPlane.Equation, _0023_003DzNwtRJ3cLTrAy(), viewFrame, out var _0023_003DzPjm3jErOBm2);
		Vector3D vector3D = Vector3D.Subtract(_0023_003DzPjm3jErOBm2, _0023_003DzPjm3jErOBm);
		vector3D.Normalize();
		Vector3D vector3D2 = _0023_003DzOrtNSQnn48wG.Reflect(vector3D);
		Point3D point3D = _0023_003DzPjm3jErOBm2 + vector3D2;
		Point2D point2D = _0023_003DzClCMdT3GjxD8PGpNmg_003D_003D.WorldToScreen(point3D.X, point3D.Y, point3D.Z, viewFrame);
		System.Drawing.Point point = _0023_003DzYzWi5Yw_003D._0023_003DzSeGspan5F6gF(new System.Drawing.Point((int)point2D.X, (int)point2D.Y));
		Vector3D vector3D3 = new Vector3D(point.X - num, point.Y - num2, 0.0);
		vector3D3.Normalize();
		double num3 = vector3D3.X;
		double num4 = vector3D3.Y;
		double num5 = 0.0;
		if (num4 != 0.0)
		{
			num5 = 180.0 - Utility.RadToDeg(Math.Atan(num3 / num4));
			if (num4 > 0.0)
			{
				num5 -= 180.0;
			}
		}
		return num5;
	}

	private bool _0023_003DzG83_00246AJK1JqWS6ltVhRJL_I_003D()
	{
		if (_0023_003DzEDUeIexdjfn_EoBUmQ_003D_003D > 0)
		{
			return !(this is Drawing);
		}
		return false;
	}

	internal bool _0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW()
	{
		if (_0023_003DzG83_00246AJK1JqWS6ltVhRJL_I_003D() && _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 1 && _0023_003DzmNZD0Zs_003D != null && (!_0023_003DzyobtGSd5_zcs() || femMeshAnimation) && _0023_003DzipBYly6zFKAp()._0023_003DzK_00241ezHQJ9Z3c != displayType.HiddenLines && (!IsAntiAliasingAvailable || !AntiAliasing) && !AccurateTransparency)
		{
			return _0023_003DzLBAsomUMXlxUzJkZ4ZWyhKLTzXmX;
		}
		return false;
	}

	private void _0023_003Dzf5NRO7wxeVa07xknUc_l_0024dqNXOfS()
	{
		if (_0023_003DzG83_00246AJK1JqWS6ltVhRJL_I_003D() && !_0023_003DzyobtGSd5_zcs())
		{
			bool flag = !_0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW();
			if (_0023_003DzfRVkvW62UnE5fk7N_g_003D_003D == null || _0023_003DzL9m3bXnFrb0F())
			{
				_0023_003DzfRVkvW62UnE5fk7N_g_003D_003D = _0023_003Dzgo07rC4SNeru();
				flag = true;
			}
			if (flag)
			{
				_0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D = _0023_003DzB5hGO8lwFPSw(_0023_003DzfRVkvW62UnE5fk7N_g_003D_003D, _0023_003DzW9xZcbsM9yIJ);
				_0023_003DzNfLvQb1InVte(ref _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D);
			}
		}
	}

	private void _0023_003Dz0oVCAhJkx9xLbPH1_00241DKD_9KTOFjLxLflQ_003D_003D(double _0023_003DzBRNuU48_003D)
	{
		if (_0023_003DzfRVkvW62UnE5fk7N_g_003D_003D == null || _0023_003DzL9m3bXnFrb0F())
		{
			_0023_003DzfRVkvW62UnE5fk7N_g_003D_003D = _0023_003Dzgo07rC4SNeru();
		}
		_0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D = _0023_003DzB5hGO8lwFPSw(_0023_003DzfRVkvW62UnE5fk7N_g_003D_003D, _0023_003DzBRNuU48_003D);
		_0023_003DzNfLvQb1InVte(ref _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D);
	}

	private protected virtual void _0023_003DzNfLvQb1InVte(ref List<Entity> _0023_003DzY_0024ABPwh9wryC)
	{
		_0023_003Dzz3zjS5dB4WS61l9T16pDn9c_003D _0023_003Dzz3zjS5dB4WS61l9T16pDn9c_003D2 = new _0023_003Dzz3zjS5dB4WS61l9T16pDn9c_003D();
		_0023_003Dzz3zjS5dB4WS61l9T16pDn9c_003D2._0023_003DzKdgtcDsi34jL = this;
		if (_0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW())
		{
			_0023_003Dzz3zjS5dB4WS61l9T16pDn9c_003D2._0023_003DzwXzrcF_0024vKNIp = _0023_003DzipBYly6zFKAp();
			_0023_003DzY_0024ABPwh9wryC = _0023_003DzY_0024ABPwh9wryC.OrderByDescending(_0023_003Dzz3zjS5dB4WS61l9T16pDn9c_003D2._0023_003DzTGvN1OcWOUSKdVfmi0ejDYE_003D).ToList();
		}
		else
		{
			_0023_003DzY_0024ABPwh9wryC = _0023_003DzY_0024ABPwh9wryC.OrderByDescending((Entity _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D.screenSize).ToList();
		}
	}

	private void _0023_003DzWuKjd4wWwSi6()
	{
		_0023_003DzZw_0024Euke_eh4K = ((_0023_003DzEDUeIexdjfn_EoBUmQ_003D_003D == 0) ? double.MaxValue : (1000.0 / (double)_0023_003DzEDUeIexdjfn_EoBUmQ_003D_003D));
	}

	private void _0023_003Dz1KRwfFqyZNLurMj2oRC6_YZThceT()
	{
		if (_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase == null)
		{
			_0023_003DzmNZD0Zs_003D.InitProgDrawCompositing();
		}
	}

	private void _0023_003Dz_0024Wtm1Rxp4CW0V6Iy2ukugo2m6fPn()
	{
		if (_0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing == null)
		{
			_0023_003DzmNZD0Zs_003D.InitDynamicSelectionCompositing();
		}
	}

	private void _0023_003Dz10cjaUpmisQwhIAYQdLEjeLwfRrE()
	{
		if (_0023_003DzmNZD0Zs_003D.staticSelectionCompositing == null)
		{
			_0023_003DzmNZD0Zs_003D.InitStaticSelectionCompositing();
		}
	}

	private void _0023_003DzTT607now8UkBMMkxB6e9_0024TLPYiMF()
	{
		if (_0023_003DzmNZD0Zs_003D.aoCompositing == null)
		{
			_0023_003DzmNZD0Zs_003D.InitAoCompositing(_0023_003Dztlc4_vYMmHwMNn1eUs_lO_Tk1pwt._0023_003DzsmRyu9M_003D == (AmbientOcclusionSettings._0023_003DzVZPmwzuJewLS)1);
		}
	}

	private void _0023_003DzhzTzyLh6zMfMwCq4E795HvMm4Sj3()
	{
		if (_0023_003DzmNZD0Zs_003D.silhoCompositing == null)
		{
			_0023_003DzmNZD0Zs_003D.InitSilhoCompositing();
		}
	}

	private void _0023_003DzUsHKCw0NUp_uFfQ_0024in1W74813J_sfWUzVA_003D_003D()
	{
		if (_0023_003DzmNZD0Zs_003D.smoothUICompositing == null)
		{
			_0023_003DzmNZD0Zs_003D.InitSmoothUICompositing();
		}
	}

	private void _0023_003DzhZBG7nJJTvjGfFveRwoiZ4U_003D()
	{
		_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D = -1;
		_0023_003Dzu7PXbXKLQ0bz.Clear();
		_0023_003DzCJwP4KyhW2w0pUgULQ_003D_003D = 0;
	}

	private void _0023_003DzlPALPXW8i7Fn11_cJNElnPw_003D()
	{
		_0023_003Dzo_MNAFBAjuGu = 0;
		_0023_003DzSUr1lsalFeN1rfXyxw_003D_003D = 0;
		_0023_003DzK3IgbzPkGgv8 = false;
	}

	private void _0023_003Dz3DkUdi9lDAzOnDliOSavl_0024Q_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzI5CJrSxma7iW.Stop();
		double totalMilliseconds = _0023_003DzI5CJrSxma7iW.Elapsed.TotalMilliseconds;
		if (!_0023_003DzppsdDUxL8MoNpsvok2_0024eG4c_003D(_0023_003DzCBM7XJK4_5H_0024))
		{
			return;
		}
		int count = _0023_003DzCBM7XJK4_5H_0024.Entities.Count;
		if (_0023_003DzCJwP4KyhW2w0pUgULQ_003D_003D == 0)
		{
			_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D = (int)Math.Ceiling((double)count / totalMilliseconds * _0023_003DzZw_0024Euke_eh4K);
		}
		else if (count == _0023_003DzK3q17lOufT1wWnFgbQ_003D_003D || totalMilliseconds > _0023_003DzZw_0024Euke_eh4K)
		{
			if (_0023_003Dzu7PXbXKLQ0bz.Count >= 5)
			{
				_0023_003Dzu7PXbXKLQ0bz.Dequeue();
			}
			_0023_003Dzu7PXbXKLQ0bz.Enqueue(totalMilliseconds);
			double num = _0023_003Dzu7PXbXKLQ0bz.Average();
			if (_0023_003DzCJwP4KyhW2w0pUgULQ_003D_003D <= 5 || Math.Abs(num - _0023_003DzZw_0024Euke_eh4K) > _0023_003DzZw_0024Euke_eh4K * 0.1)
			{
				if (num < _0023_003DzZw_0024Euke_eh4K)
				{
					_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D += (int)Math.Ceiling((double)((float)_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D * 0.1f) * ((_0023_003DzZw_0024Euke_eh4K - num) / _0023_003DzZw_0024Euke_eh4K));
				}
				else
				{
					_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D -= (int)Math.Ceiling((double)((float)_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D * 0.1f) * (1.0 - _0023_003DzZw_0024Euke_eh4K / num));
				}
			}
			if (_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D == 0)
			{
				_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D = 1;
			}
			if (_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D > _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D.Count)
			{
				_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D = _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D.Count;
			}
		}
		_0023_003DzCJwP4KyhW2w0pUgULQ_003D_003D++;
	}

	private Entity[] _0023_003Dz5hg793fWBXXkDWvOWC__pM8_003D(ComputeEntitiesVisibilityParams _0023_003Dzt5jpbHs_003D, FrustumParams _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D, DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (!_0023_003DzBnb5yu3Zdgc7tl4iVkxuANw_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D) || _0023_003Dzt5jpbHs_003D.entities.Count == 0)
		{
			_0023_003DzCBM7XJK4_5H_0024.isLastBatch = true;
			return new Entity[0];
		}
		if (_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D == -1)
		{
			_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D = Math.Min(_0023_003Dzt5jpbHs_003D.entities.Count, 20000);
		}
		int num = (_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing ? _0023_003DzSUr1lsalFeN1rfXyxw_003D_003D : 0);
		int num2 = ((_0023_003DzK3q17lOufT1wWnFgbQ_003D_003D > 0) ? _0023_003DzK3q17lOufT1wWnFgbQ_003D_003D : _0023_003Dzt5jpbHs_003D.entities.Count);
		Entity[] array = new Entity[num2];
		int num3 = 0;
		for (int i = num; i < _0023_003Dzt5jpbHs_003D.entities.Count; i++)
		{
			_0023_003Dzt5jpbHs_003D.entities[i].visibleAndInFrustum = _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D.Frustum == null || _0023_003Dzt5jpbHs_003D.entities[i].IsInFrustum(_0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D);
			if (_0023_003Dzt5jpbHs_003D.entities[i].visibleAndInFrustum)
			{
				array[num3++] = _0023_003Dzt5jpbHs_003D.entities[i];
			}
			if (num3 == num2)
			{
				if (_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing)
				{
					i = (_0023_003DzSUr1lsalFeN1rfXyxw_003D_003D = i + 1);
					_0023_003DzCBM7XJK4_5H_0024.isLastBatch = _0023_003DzSUr1lsalFeN1rfXyxw_003D_003D == _0023_003Dzt5jpbHs_003D.entities.Count;
				}
				break;
			}
		}
		if (num3 < num2)
		{
			if (_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing)
			{
				_0023_003DzCBM7XJK4_5H_0024.isLastBatch = true;
			}
			Array.Resize(ref array, num3);
		}
		return array;
	}

	internal void _0023_003Dz63GJxgPNPnh1Xegeiw_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights, _0023_003DzCBM7XJK4_5H_0024.ShaderParams);
		_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(_0023_003DzCBM7XJK4_5H_0024.ShaderParams);
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		DisplayModeSettings _0023_003DzOUFng_M_003D = _0023_003Dz0fTtstT4IqGh(viewport._0023_003DzK_00241ezHQJ9Z3c);
		if (viewport._0023_003DzK_00241ezHQJ9Z3c != displayType.HiddenLines || !_0023_003DzP6FAuV4Dwq24.DashedHiddenLines)
		{
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLessEqual);
			_0023_003Dznmirx4AJFkdvIkj_rjmL0sU_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: false);
			if (_0023_003Dzvt__00241pgXtBNV3_0024rQivX341Z9tfxc(viewport, _0023_003DzCBM7XJK4_5H_0024.PlanarReflections, _0023_003DzCBM7XJK4_5H_0024.Simplify, _0023_003DzOUFng_M_003D))
			{
				_0023_003DzmNZD0Zs_003D.PushShader();
				_0023_003DzKm24hrH9IcmmaARdVrPi0mw_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: false);
				_0023_003DzmNZD0Zs_003D.PopShader();
			}
		}
		_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1);
	}

	private bool _0023_003DzppsdDUxL8MoNpsvok2_0024eG4c_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.Simplify && _0023_003DzG83_00246AJK1JqWS6ltVhRJL_I_003D())
		{
			return _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D != null;
		}
		return false;
	}

	private bool _0023_003Dzvt__00241pgXtBNV3_0024rQivX341Z9tfxc(Viewport _0023_003DzYzWi5Yw_003D, bool _0023_003Dzk3KGpSl0I48qPYLcl6ZgXyfgAmDk, bool _0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D, DisplayModeSettings _0023_003DzOUFng_M_003D)
	{
		if (!_0023_003Dzk3KGpSl0I48qPYLcl6ZgXyfgAmDk && _0023_003DzyPPFAn2wOKkLAuBojlsEL2A_003D(_0023_003DzOUFng_M_003D, _0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D))
		{
			if (_0023_003DzYzWi5Yw_003D.DisplayMode == displayType.Flat)
			{
				return _0023_003DzOUFng_M_003D.EdgeColorMethod == edgeColorMethodType.SingleColor;
			}
			return true;
		}
		return false;
	}

	internal void _0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003Dzz4aiLqY_0024r7bL, _0023_003DzARfd93yYb38F _0023_003Dzf9ON1O9R9yD9)
	{
		_0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzz4aiLqY_0024r7bL, _0023_003Dzf9ON1O9R9yD9, _0023_003Dz0fTtstT4IqGh(_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode));
	}

	private void _0023_003DzWp5X7PvcuErenq1_00240Ofokko_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.PlanarReflections || _0023_003DzCBM7XJK4_5H_0024.ObjectManipulatorDrawPreview)
		{
			return;
		}
		bool[] array = UtilityEx._0023_003DzIBrdGNM_003D(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzCBM7XJK4_5H_0024.RenderContext);
		_0023_003DzmNZD0Zs_003D.PushRasterizerState();
		_0023_003DzmNZD0Zs_003D.PushDepthStencilState();
		_0023_003DzmNZD0Zs_003D.PushShader();
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		IList<Entity> list;
		if (_0023_003DzG83_00246AJK1JqWS6ltVhRJL_I_003D() && _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D != null)
		{
			list = _0023_003DzCBM7XJK4_5H_0024.Entities;
		}
		else
		{
			IList<Entity> list2 = _0023_003Dzjf_0024BZto9_0024Rys_vlKUa_93O0_003D(_0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003DzoE3BE__0024RS_DJ(), 0);
			list = list2;
		}
		IList<Entity> list3 = list;
		for (int i = 0; i < _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length; i++)
		{
			ClippingPlane clippingPlane = (ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[i];
			if (!clippingPlane.Active || clippingPlane.CappingMode == ClippingPlane.cappingType.None || clippingPlane.clippingPlaneMesh == null || _0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo)
			{
				continue;
			}
			if (clippingPlane.CappingMode == ClippingPlane.cappingType.EntityColor && !_0023_003DzCBM7XJK4_5H_0024.isDepthPrepass)
			{
				Utility.TurnOffClippingPlanes(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzCBM7XJK4_5H_0024.RenderContext, i);
				Stack<BlockReference> stack = new Stack<BlockReference>();
				_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: false, stencilBuffer: true, 0);
				RenderParams data = new RenderParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks);
				foreach (Entity item in list3)
				{
					if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(item, stack) || NestedEntity.IsGrayMinFr(item) || item is ParentBlockReference || !item.IsClippable(stack, Layers))
					{
						continue;
					}
					_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.None);
					_0023_003DzmNZD0Zs_003D.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.Front);
					_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Always_0_0_Op_Keep_Keep_Increment);
					((IEntityInternal)item).DrawForShadow(data);
					_0023_003DzmNZD0Zs_003D.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.Back);
					_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Always_0_0_Op_Keep_Keep_Decrement);
					((IEntityInternal)item).DrawForShadow(data);
					_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.RGBA);
					_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOn_StencilOn_Func_NotEqual_0_0xFF);
					_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
					_0023_003DzmNZD0Zs_003D.SetColorWireframe(item.GetColor(Layers));
					for (int j = 0; j < _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length; j++)
					{
						if (array[j] && ((ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[j]).CappingMode != ClippingPlane.cappingType.None)
						{
							_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[j].Active = !_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[j].Active;
						}
					}
					_0023_003DzmNZD0Zs_003D.ProcessClippingPlanesVisibility(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, updateGraphics: true);
					_0023_003DzmNZD0Zs_003D.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.None);
					Transformation transformation = new Align3D(Plane.XY, clippingPlane.Plane);
					if (_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.SceneTransformationInverted != null)
					{
						transformation = _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.SceneTransformationInverted * transformation;
					}
					_0023_003DzmNZD0Zs_003D.PushModelView();
					_0023_003DzmNZD0Zs_003D.MultMatrixModelView(transformation.MatrixAsVectorByColumn);
					((IEntityInternal)clippingPlane.clippingPlaneMesh).DrawForShadow(data);
					_0023_003DzmNZD0Zs_003D.PopModelView();
					Utility.RestoreClippingPlanesStatus(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzCBM7XJK4_5H_0024.RenderContext, array);
				}
				Utility.RestoreClippingPlanesStatus(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzCBM7XJK4_5H_0024.RenderContext, array);
				continue;
			}
			_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: false, stencilBuffer: true, 0);
			Utility.TurnOffClippingPlanes(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzCBM7XJK4_5H_0024.RenderContext, i);
			RenderParams data2 = new RenderParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks);
			_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.None);
			_0023_003DzmNZD0Zs_003D.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.Front);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Always_0_0_Op_Keep_Keep_Increment);
			Stack<BlockReference> stack2 = new Stack<BlockReference>();
			foreach (Entity entity in _0023_003DzCBM7XJK4_5H_0024.Entities)
			{
				if (_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, stack2) && !NestedEntity.IsGrayMinFr(entity) && !(entity is ParentBlockReference) && entity.IsClippable(stack2, Layers))
				{
					((IEntityInternal)entity).DrawForShadow(data2);
				}
			}
			_0023_003DzmNZD0Zs_003D.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.Back);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Always_0_0_Op_Keep_Keep_Decrement);
			foreach (Entity entity2 in _0023_003DzCBM7XJK4_5H_0024.Entities)
			{
				if (_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity2, stack2) && !NestedEntity.IsGrayMinFr(entity2) && !(entity2 is ParentBlockReference) && entity2.IsClippable(stack2, Layers))
				{
					((IEntityInternal)entity2).DrawForShadow(data2);
				}
			}
			_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.RGBA);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOn_StencilOn_Func_NotEqual_0_0xFF);
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(clippingPlane.CappingColor);
			for (int k = 0; k < _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length; k++)
			{
				if (array[k] && ((ClippingPlane)_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[k]).CappingMode != ClippingPlane.cappingType.None)
				{
					_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[k].Active = !_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[k].Active;
				}
			}
			_0023_003DzmNZD0Zs_003D.ProcessClippingPlanesVisibility(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, updateGraphics: true);
			_0023_003DzmNZD0Zs_003D.SetRasterizerState(rasterizerPolygonDrawingType.Fill, rasterizerCullFaceType.None);
			Transformation transformation2 = new Align3D(Plane.XY, clippingPlane.Plane);
			if (_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.SceneTransformationInverted != null)
			{
				transformation2 = _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.SceneTransformationInverted * transformation2;
			}
			_0023_003DzmNZD0Zs_003D.PushModelView();
			_0023_003DzmNZD0Zs_003D.MultMatrixModelView(transformation2.MatrixAsVectorByColumn);
			((IEntityInternal)clippingPlane.clippingPlaneMesh).DrawForShadow(data2);
			_0023_003DzmNZD0Zs_003D.PopModelView();
			Utility.RestoreClippingPlanesStatus(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzCBM7XJK4_5H_0024.RenderContext, array);
		}
		_0023_003DzmNZD0Zs_003D.PopShader();
		_0023_003DzmNZD0Zs_003D.PopDepthStencilState();
		_0023_003DzmNZD0Zs_003D.PopRasterizerState();
	}

	private void _0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003Dzz4aiLqY_0024r7bL, _0023_003DzARfd93yYb38F _0023_003Dzf9ON1O9R9yD9, DisplayModeSettings _0023_003DzOUFng_M_003D)
	{
		if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
		{
			_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.BindTarget(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons);
		}
		_0023_003DzWp5X7PvcuErenq1_00240Ofokko_003D(_0023_003DzCBM7XJK4_5H_0024);
		if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
		{
			_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.RestoreBuffers();
		}
		_0023_003DzmNZD0Zs_003D.SetPointSize(4f * _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor, setShader: false);
		_0023_003DzmNZD0Zs_003D.SetLineSize(_0023_003DzCBM7XJK4_5H_0024.LineWeightFactor, setShader: false);
		_0023_003DzmNZD0Zs_003D.InitializeCurrentWireColor();
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		_0023_003DzmNZD0Zs_003D.PushRasterizerState();
		switch (_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode)
		{
		case displayType.Wireframe:
			_0023_003Dzt8loS4NwrEdTTy59ndCrVyo_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzf9ON1O9R9yD9, _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesWire>());
			break;
		case displayType.Flat:
			if (_0023_003Dzipe8ch4_003D.ColorMethod == flatColorMethodType.EntityColor)
			{
				_0023_003DzvbKKf0QnOkD8(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL, _0023_003Dzf9ON1O9R9yD9, _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesWire>());
			}
			else
			{
				_0023_003DzvbKKf0QnOkD8(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL, _0023_003Dzf9ON1O9R9yD9, _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesMaterialFlat>());
			}
			break;
		case displayType.Shaded:
			_0023_003Dz0A8TKD685NBlZmQt0w_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL, _0023_003Dzf9ON1O9R9yD9, _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesWire>());
			break;
		case displayType.Rendered:
			_0023_003DzJlnqFeTjCoAl(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzz4aiLqY_0024r7bL, _0023_003DzOUFng_M_003D, _0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003Dzf9ON1O9R9yD9);
			break;
		case displayType.HiddenLines:
			_0023_003DzK7VZ_4kW_0024LELJhA5lA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzf9ON1O9R9yD9, _0023_003DzOUFng_M_003D, _0023_003DzCBM7XJK4_5H_0024.Entities);
			break;
		}
	}

	private void _0023_003Dz0mTAjAZCb5coBNJKNA_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003DzgFJqRMdb78KqPyuouw_003D_003D)
	{
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.staticSelectionCompositing.SetTarget();
		_0023_003DzjsLPYiZZ7BDQHMbI2g_003D_003D(_0023_003DzOUFng_M_003D, _0023_003DzgFJqRMdb78KqPyuouw_003D_003D, out var _0023_003Dz9QlIAYpRuoz, out var _0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D);
		_0023_003DzCBM7XJK4_5H_0024.isDrawingStaticWithHalo = true;
		bool shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		bool isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers = false;
		_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing = false;
		if (_0023_003DzgFJqRMdb78KqPyuouw_003D_003D)
		{
			_0023_003DzCBM7XJK4_5H_0024.ShaderParams.PrimitiveType = shaderPrimitiveType.Polygon;
			_0023_003DzCBM7XJK4_5H_0024.ShaderParams.Environment = null;
			_0023_003DzCBM7XJK4_5H_0024.ShaderParams.Texture2D = false;
			_0023_003DzCBM7XJK4_5H_0024.ShaderParams.ShadowMode = shadowType.None;
			_0023_003DzvbKKf0QnOkD8(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzipe8ch4_003D, _0023_003Dzz4aiLqY_0024r7bL: false, (_0023_003DzARfd93yYb38F)1, _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesWire>());
		}
		else
		{
			_0023_003DzUuKcWs7AMvWH(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzipe8ch4_003D, _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: false);
		}
		_0023_003DzCBM7XJK4_5H_0024.isDrawingStaticWithHalo = false;
		_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers = shouldUseSeparateBuffers;
		_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing = isProgressiveDrawing;
		_0023_003DzefjT7qlP3g3TbTa29w_003D_003D(_0023_003Dz9QlIAYpRuoz, _0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D);
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.staticSelectionCompositing.ResetTarget();
	}

	private T _0023_003DzQ2WyM_0024wWRRUc<T>() where T : GfxAttributes, new()
	{
		T val = new T();
		if (CurrentBlockReference != null)
		{
			val.Assign(CurrentBlockReference.AccumulatedParentsAttributes);
		}
		else
		{
			val.Init(Document.DefaultColor, Layers);
		}
		return val;
	}

	private void _0023_003Dz4M3QUETNx7gr3VY7vKD8WYqX7vPS()
	{
		bool[] _0023_003DzR_0024c5epA_003D = null;
		if (!_0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			_0023_003DzR_0024c5epA_003D = Utility.TurnOffClippingPlanes(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzmNZD0Zs_003D);
		}
		_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.MinDepth(ProgDrawCompositingBase.progDrawFrameBuffer.FrozenPolygons, ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons, ProgDrawCompositingBase.progDrawFrameBuffer.ActiveWires);
		if (!_0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			Utility.RestoreClippingPlanesStatus(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzmNZD0Zs_003D, _0023_003DzR_0024c5epA_003D);
		}
	}

	private void _0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, WorkspaceDrawCallback _0023_003DzgiBiywzBnB2E, bool _0023_003DzWTyrp_pMvYC4)
	{
		_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.BindTarget((_0023_003DzWTyrp_pMvYC4 || _0023_003DzCBM7XJK4_5H_0024.isDrawingWireframeEntities) ? ProgDrawCompositingBase.progDrawFrameBuffer.ActiveWires : ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons);
		_0023_003DzCBM7XJK4_5H_0024.frozenFound = false;
		_0023_003DzgiBiywzBnB2E(_0023_003DzCBM7XJK4_5H_0024);
		_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.RestoreBuffers();
		if (_0023_003DzCBM7XJK4_5H_0024.frozenFound)
		{
			_0023_003DzCBM7XJK4_5H_0024.drawFrozen = true;
			_0023_003DzmNZD0Zs_003D.DisableClipPlanes();
			_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.BindTarget((_0023_003DzWTyrp_pMvYC4 || _0023_003DzCBM7XJK4_5H_0024.isDrawingWireframeEntities) ? ProgDrawCompositingBase.progDrawFrameBuffer.FrozenWires : ProgDrawCompositingBase.progDrawFrameBuffer.FrozenPolygons);
			_0023_003DzgiBiywzBnB2E(_0023_003DzCBM7XJK4_5H_0024);
			_0023_003DzmNZD0Zs_003D.ProcessClippingPlanesVisibility(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, updateGraphics: true);
			_0023_003DzCBM7XJK4_5H_0024.drawFrozen = false;
			_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.RestoreBuffers();
		}
	}

	private void _0023_003DzaEZv8NHpRIdvGRoW0A_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003Dz_l8qMDtuWfSD3gVZCQ_003D_003D, bool _0023_003Dz6dkM6H2_wQWT, bool _0023_003DznDL1YPo_003D)
	{
		if (_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase != null)
		{
			bool[] _0023_003DzR_0024c5epA_003D = null;
			if (!_0023_003DzmNZD0Zs_003D.IsDirect3D)
			{
				_0023_003DzR_0024c5epA_003D = Utility.TurnOffClippingPlanes(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzmNZD0Zs_003D);
			}
			if (_0023_003Dz_l8qMDtuWfSD3gVZCQ_003D_003D)
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.DrawActivePolygons();
			}
			if (_0023_003Dz6dkM6H2_wQWT)
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.DrawActiveWires();
			}
			if (_0023_003DznDL1YPo_003D)
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.BlendDepthWise(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons, ProgDrawCompositingBase.progDrawFrameBuffer.ActiveWires, ProgDrawCompositingBase.progDrawFrameBuffer.FrozenPolygons, ProgDrawCompositingBase.progDrawFrameBuffer.FrozenWires);
				((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport)._0023_003DzjDuhintYzbDe(_0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: true);
			}
			if (!_0023_003DzmNZD0Zs_003D.IsDirect3D)
			{
				Utility.RestoreClippingPlanesStatus(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzmNZD0Zs_003D, _0023_003DzR_0024c5epA_003D);
			}
		}
	}

	private bool _0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers && !_0023_003DzK3IgbzPkGgv8)
		{
			return !_0023_003DzCBM7XJK4_5H_0024.ObjectManipulatorDrawPreview;
		}
		return false;
	}

	private bool _0023_003Dzrm2bYUVg_0024nLeR0WlCQ_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers && _0023_003DzCBM7XJK4_5H_0024.isLastBatch && !_0023_003DzCBM7XJK4_5H_0024.ObjectManipulatorDrawPreview)
		{
			return _0023_003Dz_EkZHS2QnMod;
		}
		return false;
	}

	private void _0023_003Dz0A8TKD685NBlZmQt0w_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003Dzz4aiLqY_0024r7bL, _0023_003DzARfd93yYb38F _0023_003Dzf9ON1O9R9yD9, GfxAttributesWire _0023_003DzENMN0txU2r4G)
	{
		_0023_003Dzj6CxAfItGiBE7EhX2OgB2vo_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL);
		DrawParams _0023_003DzrFXPIITH9q = new DrawParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor,
			Attributes = _0023_003DzENMN0txU2r4G,
			ParentSelected = false,
			SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
			PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections,
			shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
		drawEntitiesParams.DrawParams.ColorMode = colorType.Shaded;
		drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		IList<Entity> entList = drawEntitiesParams.entList;
		_ = drawEntitiesParams.DrawParams.ForceGray;
		if ((_0023_003Dzf9ON1O9R9yD9 & (_0023_003DzARfd93yYb38F)1) == (_0023_003DzARfd93yYb38F)1)
		{
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003Dzic8sgWeDlpB66wdSTUkxPVg_003D, _0023_003DzWTyrp_pMvYC4: false);
			}
			else
			{
				_0023_003Dzic8sgWeDlpB66wdSTUkxPVg_003D(drawEntitiesParams);
			}
			drawEntitiesParams.entList = entList;
			_0023_003DzCBM7XJK4_5H_0024.transparencyFound |= drawEntitiesParams.transparencyFound;
		}
		if ((_0023_003Dzf9ON1O9R9yD9 & (_0023_003DzARfd93yYb38F)2) == (_0023_003DzARfd93yYb38F)2)
		{
			if (_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing)
			{
				_0023_003DzK3IgbzPkGgv8 = true;
			}
			if (_0023_003DzjC4hA2I_003D.isHardwareAccelerated && _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod != backfaceColorMethodType.Cull)
			{
				drawEntitiesParams.drawFastTransparencyEntityCallBack = _0023_003Dz7WwPpjSmZ2e0;
			}
			else
			{
				drawEntitiesParams.drawFastTransparencyEntityCallBack = _0023_003DzMdGmwljERbDdJtw75A_003D_003D;
			}
			_0023_003DzC5REXepTAzmHLaLJ_0024NPKwp5IL_xx(drawEntitiesParams, _0023_003DzcQ4Fko_GXDMmjq9Hiyxy9wQ_003D);
			drawEntitiesParams.entList = entList;
		}
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= drawEntitiesParams.selectionFound;
	}

	private bool _0023_003DzbjqYxAof66jg()
	{
		return _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Count > 0;
	}

	private void _0023_003Dz2frVzxD_002453RgnxuhQQ_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, GfxAttributesWire _0023_003DzENMN0txU2r4G)
	{
		DrawParams _0023_003DzrFXPIITH9q = new DrawParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor,
			Attributes = _0023_003DzENMN0txU2r4G,
			ParentSelected = false,
			SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
			PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections,
			shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, Entities, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
		drawEntitiesParams.DrawParams.ColorMode = colorType.Wireframe;
		drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		_0023_003DzmNZD0Zs_003D.PushDepthStencilState();
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestAlways);
		drawEntitiesParams.isDrawingSketchEntities = true;
		_0023_003Dzb_JtlBQHuPmWG0zla82zxns_003D(drawEntitiesParams);
		drawEntitiesParams.isDrawingSketchEntities = false;
		_0023_003DzmNZD0Zs_003D.PopDepthStencilState();
	}

	private void _0023_003Dzt8loS4NwrEdTTy59ndCrVyo_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, _0023_003DzARfd93yYb38F _0023_003Dzf9ON1O9R9yD9, GfxAttributesWire _0023_003DzENMN0txU2r4G)
	{
		DrawParams _0023_003DzrFXPIITH9q = new DrawParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor,
			Attributes = _0023_003DzENMN0txU2r4G,
			ParentSelected = false,
			SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
			PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections,
			shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
		drawEntitiesParams.DrawParams.ColorMode = colorType.Wireframe;
		drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		IList<Entity> entList = drawEntitiesParams.entList;
		_ = drawEntitiesParams.DrawParams.ForceGray;
		if ((_0023_003Dzf9ON1O9R9yD9 & (_0023_003DzARfd93yYb38F)1) == (_0023_003DzARfd93yYb38F)1)
		{
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003Dzb_JtlBQHuPmWG0zla82zxns_003D, _0023_003DzWTyrp_pMvYC4: false);
			}
			else
			{
				_0023_003Dzb_JtlBQHuPmWG0zla82zxns_003D(drawEntitiesParams);
			}
		}
		drawEntitiesParams.entList = entList;
		_0023_003DzCBM7XJK4_5H_0024.transparencyFound |= drawEntitiesParams.transparencyFound;
		if ((_0023_003Dzf9ON1O9R9yD9 & (_0023_003DzARfd93yYb38F)2) == (_0023_003DzARfd93yYb38F)2)
		{
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLess);
			_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
			if (_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing)
			{
				_0023_003DzK3IgbzPkGgv8 = true;
			}
			_0023_003DzblKf805HyZNJDvsEtprPtGK39D_4(drawEntitiesParams);
			drawEntitiesParams.entList = entList;
			_0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		}
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= drawEntitiesParams.selectionFound;
	}

	private void _0023_003DzvbKKf0QnOkD8(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003Dzz4aiLqY_0024r7bL, _0023_003DzARfd93yYb38F _0023_003Dzf9ON1O9R9yD9, GfxAttributesWire _0023_003DzENMN0txU2r4G)
	{
		_0023_003DzmNZD0Zs_003D.InitializePreviousColors();
		_0023_003Dz_9qS3W815tFjCa_RC_0024JgHyk_003D(_0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL);
		DrawParams _0023_003DzrFXPIITH9q = new DrawParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor,
			Attributes = _0023_003DzENMN0txU2r4G,
			ParentSelected = false,
			SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
			PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections,
			shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers,
			IsDrawingForHaloDynamic = _0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo,
			IsDrawingForHaloStatic = _0023_003DzCBM7XJK4_5H_0024.isDrawingStaticWithHalo
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
		drawEntitiesParams.DrawParams.BackFaceColorMethod = _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod;
		drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		drawEntitiesParams.isDrawingDynamicWithHalo = _0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo;
		drawEntitiesParams.isDrawingStaticWithHalo = _0023_003DzCBM7XJK4_5H_0024.isDrawingStaticWithHalo;
		bool[] _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D = null;
		if (_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
		{
			_0023_003Dzk9HwUQ4uSzdtWt6BErpx4Zw_003D(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, ref _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D);
			drawEntitiesParams.SetStatesFunc = _0023_003DzOr9rWHwxwTcnkR_Kxg7_Hlc_003D;
		}
		else
		{
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			drawEntitiesParams.SetStatesFunc = _0023_003DzaS1WXEc73ayPfJTWfdhYVKk_003D;
			drawEntitiesParams.DrawParams.ShaderParams.Lighting = false;
		}
		IList<Entity> entList = drawEntitiesParams.entList;
		_ = drawEntitiesParams.DrawParams.ForceGray;
		if ((_0023_003Dzf9ON1O9R9yD9 & (_0023_003DzARfd93yYb38F)1) == (_0023_003DzARfd93yYb38F)1)
		{
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
			{
				if (_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
				{
					drawEntitiesParams.SetStatesFunc = _0023_003DzSAdUYiiIyUKXbmiyAJcLb2qAouwG;
				}
				else
				{
					drawEntitiesParams.SetStatesFunc = _0023_003DzMcSxMItosfoZ6tgvPSq8UEalN0lh;
				}
				_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003DzzbHPX6XNACYHWWISoQ_003D_003D, _0023_003DzWTyrp_pMvYC4: false);
			}
			else
			{
				_0023_003DzzbHPX6XNACYHWWISoQ_003D_003D(drawEntitiesParams);
			}
			drawEntitiesParams.entList = entList;
			_0023_003DzCBM7XJK4_5H_0024.transparencyFound |= drawEntitiesParams.transparencyFound;
		}
		if ((_0023_003Dzf9ON1O9R9yD9 & (_0023_003DzARfd93yYb38F)2) == (_0023_003DzARfd93yYb38F)2)
		{
			if (_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing)
			{
				_0023_003DzK3IgbzPkGgv8 = true;
			}
			if (_0023_003DzjC4hA2I_003D.isHardwareAccelerated && _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod != backfaceColorMethodType.Cull)
			{
				drawEntitiesParams.drawFastTransparencyEntityCallBack = _0023_003Dz3EA82HCByTTb;
			}
			else
			{
				drawEntitiesParams.drawFastTransparencyEntityCallBack = delegate(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawFlat(_0023_003Dzt5jpbHs_003D);
				};
			}
			if (_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
			{
				drawEntitiesParams.SetStatesFunc = _0023_003DzSAdUYiiIyUKXbmiyAJcLb2qAouwG;
			}
			else
			{
				_0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D = rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1;
				drawEntitiesParams.SetStatesFunc = _0023_003DzMcSxMItosfoZ6tgvPSq8UEalN0lh;
			}
			_0023_003DzC5REXepTAzmHLaLJ_0024NPKwp5IL_xx(drawEntitiesParams, _0023_003Dz1cy2xxzUYyS3rl30Bw_003D_003D);
			drawEntitiesParams.entList = entList;
		}
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= drawEntitiesParams.selectionFound;
		if (_0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D != null)
		{
			_0023_003DzWsXtT_0024NYYJ_0024or5QLaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D);
		}
	}

	private void _0023_003DzWsXtT_0024NYYJ_0024or5QLaQ_003D_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, bool[] _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D)
	{
		_0023_003DzmNZD0Zs_003D.SetSceneAmbient(Utility.ColorToFloatArray(_0023_003DzXVJ6CvJJYmrqf3ztQQ_003D_003D));
		_0023_003DzmNZD0Zs_003D.EndDrawMulticolorWithAmbientAndDiffuse(_0023_003DzgcK4Z11iT1YA);
		for (int i = 0; i < _0023_003DzmNZD0Zs_003D.ActiveLights.Length; i++)
		{
			_0023_003DzmNZD0Zs_003D.ActiveLights[i].Active = _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D[i];
			_0023_003DzmNZD0Zs_003D.SetLightStatus(i, _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D[i]);
		}
	}

	private void _0023_003Dzk9HwUQ4uSzdtWt6BErpx4Zw_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, ref bool[] _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D)
	{
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
		_0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D = new bool[_0023_003DzmNZD0Zs_003D.ActiveLights.Length];
		for (int i = 0; i < _0023_003DzmNZD0Zs_003D.ActiveLights.Length; i++)
		{
			_0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D[i] = _0023_003DzmNZD0Zs_003D.ActiveLights[i].Active;
			_0023_003DzmNZD0Zs_003D.ActiveLights[i].Active = false;
			_0023_003DzmNZD0Zs_003D.SetLightStatus(i, active: false);
		}
		_0023_003DzmNZD0Zs_003D.SetSceneAmbient(new float[4] { 1f, 1f, 1f, 1f });
		_0023_003DzmNZD0Zs_003D.SetMaterialBackAmbient(_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.Color);
		_0023_003DzmNZD0Zs_003D.BeginDrawMulticolorWithAmbientAndDiffuse(_0023_003DzgcK4Z11iT1YA);
		if (_0023_003DzgcK4Z11iT1YA != null)
		{
			_0023_003DzgcK4Z11iT1YA.Lighting = true;
			if (!StandardShaders[shaderType.Texture2D].IsCompiled)
			{
				StandardShaders[shaderType.Texture2D].Compile(_0023_003DzgcK4Z11iT1YA.RenderContext);
			}
			StandardShaders[shaderType.Texture2D].SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (!StandardShaders[shaderType.MultiColor].IsCompiled)
			{
				StandardShaders[shaderType.MultiColor].Compile(_0023_003DzgcK4Z11iT1YA.RenderContext);
			}
			StandardShaders[shaderType.MultiColor].SetParameters(_0023_003DzgcK4Z11iT1YA);
			_0023_003DzmNZD0Zs_003D.GetShaderAndEnable(_0023_003DzgcK4Z11iT1YA);
			_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(_0023_003DzgcK4Z11iT1YA);
		}
	}

	internal Color _0023_003Dz172y4KzLmCm83OqS4g_003D_003D(Color _0023_003Dzhpb8QNg_003D, double _0023_003Dz1CEjt3w_003D)
	{
		return Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, (int)((double)(int)_0023_003Dzhpb8QNg_003D.R * _0023_003Dz1CEjt3w_003D), (int)((double)(int)_0023_003Dzhpb8QNg_003D.G * _0023_003Dz1CEjt3w_003D), (int)((double)(int)_0023_003Dzhpb8QNg_003D.B * _0023_003Dz1CEjt3w_003D));
	}

	private void _0023_003Dznmirx4AJFkdvIkj_rjmL0sU_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D)
	{
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		_0023_003DzmNZD0Zs_003D.InitializeCurrentWireColor();
		if (_0023_003DzCBM7XJK4_5H_0024.PlanarReflections)
		{
			return;
		}
		_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonLine_NoCullFace);
		if (_0023_003DzOUFng_M_003D.ShowEdges)
		{
			_0023_003DzUuKcWs7AMvWH(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D);
		}
		_0023_003DzmNZD0Zs_003D.SetLineSize(_0023_003DzCBM7XJK4_5H_0024.LineWeightFactor, setShader: false);
		_0023_003DzmNZD0Zs_003D.EnableThickLinesInPolygonLineMode();
		if (_0023_003DzOUFng_M_003D.ShowInternalWires && !_0023_003DzCBM7XJK4_5H_0024.PlanarReflections)
		{
			DrawParams _0023_003DzrFXPIITH9q = new DrawParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
			{
				LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor,
				ParentSelected = false,
				SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
				PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections,
				shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers
			};
			DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
			drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
			drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
			if (_0023_003DzOUFng_M_003D.EdgeColorMethod == edgeColorMethodType.EntityColor)
			{
				if (_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode != displayType.Flat)
				{
					drawEntitiesParams.DrawParams.Attributes = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesColor>();
					if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
					{
						_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003DzPTXMkk7FTOSwGAbibQ_003D_003D, _0023_003DzWTyrp_pMvYC4: true);
					}
					else
					{
						_0023_003DzPTXMkk7FTOSwGAbibQ_003D_003D(drawEntitiesParams);
					}
				}
			}
			else
			{
				drawEntitiesParams.DrawParams.Attributes = new GfxAttributes(_0023_003DzOUFng_M_003D.EdgeColor);
				if (_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode == displayType.Flat)
				{
					if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
					{
						_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003Dz7TcPg458oBkO4TfvnkmsQmo_003D, _0023_003DzWTyrp_pMvYC4: true);
					}
					else
					{
						_0023_003Dz7TcPg458oBkO4TfvnkmsQmo_003D(drawEntitiesParams);
					}
				}
				else if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
				{
					_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003DzPTXMkk7FTOSwGAbibQ_003D_003D, _0023_003DzWTyrp_pMvYC4: true);
				}
				else
				{
					_0023_003DzPTXMkk7FTOSwGAbibQ_003D_003D(drawEntitiesParams);
				}
			}
		}
		if (_0023_003DzCBM7XJK4_5H_0024.selectionFound && _0023_003DzCBM7XJK4_5H_0024.SelectionStatus == selectionStatusType.Permanent && _0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(_0023_003DzCBM7XJK4_5H_0024.viewportInternal))
		{
			_0023_003Dz0mTAjAZCb5coBNJKNA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003DzgFJqRMdb78KqPyuouw_003D_003D: false);
		}
	}

	internal void _0023_003DzC5REXepTAzmHLaLJ_0024NPKwp5IL_xx(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, WorkspaceDrawCallback _0023_003DzUsjvHKs8LNYe3vS_Cg_003D_003D)
	{
		_0023_003DzmNZD0Zs_003D.PushDepthStencilState();
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLess);
		_0023_003DzmNZD0Zs_003D.PushBlendState();
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		_0023_003DzmNZD0Zs_003D.ProcessClippingPlanesVisibility(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, updateGraphics: true);
		bool flag = _0023_003DzjC4hA2I_003D.isHardwareAccelerated || _0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D.ColorMethod == backfaceColorMethodType.Cull;
		bool flag2 = _0023_003DzwRbyHapHUGov(_0023_003Dz0fTtstT4IqGh(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Viewport.DisplayMode));
		_0023_003DzmNZD0Zs_003D.SetState((!flag2) ? (flag ? rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset : rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset) : (flag ? rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1 : rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1));
		IList<Entity> entList = null;
		if (AccurateTransparency)
		{
			entList = _0023_003DzCBM7XJK4_5H_0024.entList;
			_0023_003DzCBM7XJK4_5H_0024.entList = new Entity[1] { _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Peek().ParentSceneBlockReference };
		}
		_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame();
		_0023_003DzUsjvHKs8LNYe3vS_Cg_003D_003D(_0023_003DzCBM7XJK4_5H_0024);
		if (AccurateTransparency)
		{
			_0023_003DzCBM7XJK4_5H_0024.entList = entList;
		}
		_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1);
		_0023_003DzmNZD0Zs_003D.PopBlendState();
		_0023_003DzmNZD0Zs_003D.PopDepthStencilState();
		if (_0023_003DzYtqGTMwg_0024Ufr8epgUBxoDPPd_0024XV2 || _0023_003Dz_EkZHS2QnMod)
		{
			_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.None);
			_0023_003DzCBM7XJK4_5H_0024.drawZBufferOnly = true;
			_0023_003DzUsjvHKs8LNYe3vS_Cg_003D_003D(_0023_003DzCBM7XJK4_5H_0024);
			_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.RGBA);
		}
	}

	private void _0023_003DzJlnqFeTjCoAl(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003Dzz4aiLqY_0024r7bL, DisplayModeSettings _0023_003DzOUFng_M_003D, IList<Entity> _0023_003DzQDU9c0AE6yqQ, _0023_003DzARfd93yYb38F _0023_003Dzf9ON1O9R9yD9)
	{
		_0023_003Dzj6CxAfItGiBE7EhX2OgB2vo_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL);
		HqrData hqrData = new HqrData(_0023_003DzmNZD0Zs_003D, _0023_003DziuvwBNA4duWb, _0023_003DznKkOfo8_003D.EnvironmentMapping);
		RenderParams _0023_003DzrFXPIITH9q = new RenderParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor,
			Attributes = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesRendered>(),
			ParentSelected = false,
			SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
			PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections,
			shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzQDU9c0AE6yqQ, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
		drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		drawEntitiesParams.DrawParams.ColorMode = colorType.Rendered;
		((RenderParams)drawEntitiesParams.DrawParams).hqrData = hqrData;
		if ((_0023_003Dzf9ON1O9R9yD9 & (_0023_003DzARfd93yYb38F)1) == (_0023_003DzARfd93yYb38F)1)
		{
			if (_0023_003DzCBM7XJK4_5H_0024.PlanarReflections)
			{
				if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
				{
					_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003Dz0hyE9qB8Z7NvBCoV5g_003D_003D, _0023_003DzWTyrp_pMvYC4: false);
				}
				else
				{
					_0023_003Dz0hyE9qB8Z7NvBCoV5g_003D_003D(drawEntitiesParams);
				}
			}
			else if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003Dzx0_dIgGavykSE30soQ_003D_003D, _0023_003DzWTyrp_pMvYC4: false);
			}
			else
			{
				_0023_003Dzx0_dIgGavykSE30soQ_003D_003D(drawEntitiesParams);
			}
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.CloseEnvironment();
			_0023_003DzCBM7XJK4_5H_0024.transparencyFound |= drawEntitiesParams.transparencyFound;
		}
		if ((_0023_003Dzf9ON1O9R9yD9 & (_0023_003DzARfd93yYb38F)2) == (_0023_003DzARfd93yYb38F)2)
		{
			if (!_0023_003DzCBM7XJK4_5H_0024.PlanarReflections && _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing)
			{
				_0023_003DzK3IgbzPkGgv8 = true;
			}
			if (_0023_003DzjC4hA2I_003D.isHardwareAccelerated && _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod != backfaceColorMethodType.Cull)
			{
				if (_0023_003DzCBM7XJK4_5H_0024.PlanarReflections)
				{
					drawEntitiesParams.drawFastTransparencyEntityCallBack = _0023_003DznVTEqZ9bwrkx;
				}
				else
				{
					drawEntitiesParams.drawFastTransparencyEntityCallBack = delegate(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
					{
						if (_0023_003Dzt5jpbHs_003D.ForceGray)
						{
							((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawFast(_0023_003Dzt5jpbHs_003D);
						}
						else
						{
							((IEntityInternal)_0023_003DztJCl_0024mM_003D).RenderFast((RenderParams)_0023_003Dzt5jpbHs_003D);
						}
					};
				}
			}
			else if (_0023_003DzCBM7XJK4_5H_0024.PlanarReflections)
			{
				drawEntitiesParams.drawFastTransparencyEntityCallBack = _0023_003DzyxKJZtJUEmPmHWHDhRvh0ns_003D;
			}
			else
			{
				drawEntitiesParams.drawFastTransparencyEntityCallBack = delegate(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
				{
					if (_0023_003Dzt5jpbHs_003D.ForceGray)
					{
						((IEntityInternal)_0023_003DztJCl_0024mM_003D).Draw(_0023_003Dzt5jpbHs_003D);
					}
					else
					{
						((IEntityInternal)_0023_003DztJCl_0024mM_003D).Render((RenderParams)_0023_003Dzt5jpbHs_003D);
					}
				};
			}
			_0023_003DzC5REXepTAzmHLaLJ_0024NPKwp5IL_xx(drawEntitiesParams, delegate(DrawEntitiesParams drawEntitiesParams2)
			{
				// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
				GfxAttributesRendered _0023_003DzJxsQW2k8xtCB = (GfxAttributesRendered)drawEntitiesParams2.DrawParams.Attributes.Clone();
				int count = drawEntitiesParams2.entList.Count;
				bool _0023_003DzUH2MOzxMv_0024gC = false;
				for (int i = 0; i < count; i++)
				{
					Entity _0023_003DztJCl_0024mM_003D = drawEntitiesParams2.entList[i];
					if (_0023_003DzPc__00241eoVaxWYZ5K8Aw_003D_003D(drawEntitiesParams2, _0023_003DzJxsQW2k8xtCB, _0023_003DzYkVaBhK6AhTIiv_0024zmQ_003D_003D, ref _0023_003DztJCl_0024mM_003D, ref _0023_003DzUH2MOzxMv_0024gC))
					{
						if (_0023_003DzUH2MOzxMv_0024gC)
						{
							break;
						}
					}
					else if (!_0023_003DzH64tBc6U9aeYWvpkOFVxPG0_003D(_0023_003DztJCl_0024mM_003D, drawEntitiesParams2))
					{
						_0023_003DzR45REbGtVacFfA93fA_003D_003D(drawEntitiesParams2, _0023_003DztJCl_0024mM_003D);
						base.RenderContext.SetClippable(drawEntitiesParams2.DrawParams.Clippable);
						drawEntitiesParams2.drawFastTransparencyEntityCallBack((RenderParams)drawEntitiesParams2.DrawParams, _0023_003DztJCl_0024mM_003D, (GfxAttributesRendered)drawEntitiesParams2.DrawParams.Attributes);
					}
				}
				base.RenderContext.SetTextureLength(0f);
				base.RenderContext.SetClippable(clippable: true);
				_0023_003DzzThxH8goktC_0024();
			});
		}
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= drawEntitiesParams.selectionFound;
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.CloseEnvironment();
	}

	private void _0023_003Dzgi2Ebcq_0024zxbg(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.aoCompositing.UpdateAoData(_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.ProjectionMatrix, 0.001f, 1f, (float)_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.Near, (float)_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.Far, AmbientOcclusionSettings._0023_003Dz0lpxPEmp4iKm, AmbientOcclusionSettings._0023_003Dz2t_v6DnM8indvXOkrg_003D_003D, AmbientOcclusion.Radius * (float)_0023_003DzCBM7XJK4_5H_0024.Viewport.Size.Height, AmbientOcclusion.Strength);
	}

	private void _0023_003DzYT5U7iwXC42u(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		DisplayModeSettings displayModeSettings = _0023_003Dz0fTtstT4IqGh(_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode);
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.silhoCompositing.UpdateSilhoData((int)displayModeSettings.SilhouetteThickness, _0023_003Dz172y4KzLmCm83OqS4g_003D_003D(displayModeSettings.EdgeColor, 0.8), _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.ProjectionMatrix, 0.001f, 1f, (float)_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.Near, (float)_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.Far);
	}

	private void _0023_003Dzu7qIyF1LiH3N(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.aoCompositing.DrawOnTopOfCurrentTarget(((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport)._0023_003Dzr_AjDsvNuuYG(), _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D);
	}

	private bool _0023_003Dzmq468FOl1RBUpGlrEpFsBdQ4ifHS(DrawEntitiesParams _0023_003DzyrRdBi78wMnR)
	{
		if ((!AccurateTransparency || CurrentBlockReference != null) && _0023_003DzyrRdBi78wMnR.transparencyFound)
		{
			return !_0023_003DzyrRdBi78wMnR.Workspace.RenderContext.IsDrawingForDepth;
		}
		return false;
	}

	private bool _0023_003Dzmq468FOl1RBUpGlrEpFsBdQ4ifHS(DrawSceneParams _0023_003DzyrRdBi78wMnR)
	{
		if ((!AccurateTransparency || CurrentBlockReference != null) && _0023_003DzyrRdBi78wMnR.transparencyFound)
		{
			return !_0023_003DzyrRdBi78wMnR.RenderContext.IsDrawingForDepth;
		}
		return false;
	}

	private bool _0023_003Dz50vA7BeIaD3NZwgnDIQJNIA_003D(DrawSceneParams _0023_003DzyrRdBi78wMnR)
	{
		if (_0023_003DzyrRdBi78wMnR.selectionFound && _0023_003DzyrRdBi78wMnR.SelectionStatus == selectionStatusType.Permanent && !_0023_003DzyrRdBi78wMnR.PlanarReflections)
		{
			return !_0023_003DzyrRdBi78wMnR.RenderContext.IsDrawingForDepth;
		}
		return false;
	}

	private bool _0023_003Dz6VoEBpmCq7f_ip0wIg_003D_003D(DrawSceneParams _0023_003DzyrRdBi78wMnR)
	{
		if (_0023_003DzcldL_7X0g_0024muFoDe_002405Mk9Q_003D() && !_0023_003DzyrRdBi78wMnR.SkipSsao && _0023_003DzyrRdBi78wMnR.Viewport.DisplayMode == displayType.Rendered && !_0023_003DzyrRdBi78wMnR.PlanarReflections && !_0023_003DzyrRdBi78wMnR.RenderContext.IsDrawingForDepth && (!_0023_003DzyrRdBi78wMnR.isProgressiveDrawing || !_0023_003DzK3IgbzPkGgv8))
		{
			if (_0023_003DzfRVkvW62UnE5fk7N_g_003D_003D != null)
			{
				return _0023_003DzPy_UVJqNuye0;
			}
			return true;
		}
		return false;
	}

	private bool _0023_003Dz_0024A8nMqSWV3y48zCc3X04SjaFKfXZ(DrawSceneParams _0023_003DzyrRdBi78wMnR)
	{
		if (_0023_003Dz0fTtstT4IqGh(_0023_003DzyrRdBi78wMnR.Viewport.DisplayMode).SilhouettesDrawingMode == silhouettesDrawingType.ImageBased && !_0023_003DzyrRdBi78wMnR.SkipImageBasedSilho && (_0023_003DzyrRdBi78wMnR.Viewport.DisplayMode == displayType.Rendered || _0023_003DzyrRdBi78wMnR.Viewport.DisplayMode == displayType.Shaded || _0023_003DzyrRdBi78wMnR.Viewport.DisplayMode == displayType.Flat) && !_0023_003DzyrRdBi78wMnR.PlanarReflections && !_0023_003DzyrRdBi78wMnR.RenderContext.IsDrawingForDepth && !_0023_003DzyrRdBi78wMnR.ObjectManipulatorDrawPreview)
		{
			if (_0023_003DzyrRdBi78wMnR.isProgressiveDrawing)
			{
				return !_0023_003DzK3IgbzPkGgv8;
			}
			return true;
		}
		return false;
	}

	private GfxAttributesHDLWiresSingleColor _0023_003DzIL3W95R6Q9Dj()
	{
		GfxAttributesHDLWiresSingleColor gfxAttributesHDLWiresSingleColor = null;
		switch (_0023_003Dzddm_0024rF6S_0024y27.ColorMethod)
		{
		case hiddenLinesColorMethodType.EntityColor:
			if (_0023_003Dzddm_0024rF6S_0024y27.WireColorMethod == edgeColorMethodType.EntityColor)
			{
				gfxAttributesHDLWiresSingleColor = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesHDL>();
				gfxAttributesHDLWiresSingleColor.Init(Document.DefaultColor, Layers);
			}
			else
			{
				gfxAttributesHDLWiresSingleColor = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesHDLWiresSingleColor>();
				gfxAttributesHDLWiresSingleColor.Init(Document.DefaultColor, _0023_003DzP6FAuV4Dwq24.WireColor, Layers);
			}
			break;
		case hiddenLinesColorMethodType.EntityMaterial:
			if (_0023_003Dzddm_0024rF6S_0024y27.WireColorMethod == edgeColorMethodType.EntityColor)
			{
				gfxAttributesHDLWiresSingleColor = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesHDLMaterial>();
				break;
			}
			gfxAttributesHDLWiresSingleColor = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesHDLMaterialWiresSingleColor>();
			gfxAttributesHDLWiresSingleColor.Init(Document.DefaultColor, _0023_003DzP6FAuV4Dwq24.WireColor, Layers);
			break;
		case hiddenLinesColorMethodType.SingleColor:
			if (_0023_003Dzddm_0024rF6S_0024y27.WireColorMethod == edgeColorMethodType.EntityColor)
			{
				gfxAttributesHDLWiresSingleColor = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesHDLSingleColorWiresEntityColor>();
				gfxAttributesHDLWiresSingleColor.Init(_0023_003Dzddm_0024rF6S_0024y27.PolygonColor, Document.DefaultColor, Layers);
			}
			else
			{
				gfxAttributesHDLWiresSingleColor = new GfxAttributesHDLSingleColor(_0023_003Dzddm_0024rF6S_0024y27.PolygonColor, _0023_003DzP6FAuV4Dwq24.WireColor, Layers);
			}
			break;
		}
		return gfxAttributesHDLWiresSingleColor;
	}

	private void _0023_003DzK7VZ_4kW_0024LELJhA5lA_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, _0023_003DzARfd93yYb38F _0023_003Dzf9ON1O9R9yD9, DisplayModeSettings _0023_003DzOUFng_M_003D, IList<Entity> _0023_003DzQDU9c0AE6yqQ)
	{
		WorkspaceSetMatrixAndColorFunc workspaceSetMatrixAndColorFunc = null;
		WorkspaceSetMatrixAndColorFunc workspaceSetMatrixAndColorFunc2 = null;
		WorkspaceSetMatrixAndColorFunc workspaceSetMatrixAndColorFunc3 = null;
		GfxAttributesHDLWiresSingleColor attributes = _0023_003DzIL3W95R6Q9Dj();
		_0023_003Dz_0024m0wHyJzdT4E = shaderType.NoLights;
		DrawEntitiesParams.SetHiddenLinesAttributesFunc setAttributesFunc = _0023_003Dz4shdnmn2ECfg;
		if (_0023_003Dzddm_0024rF6S_0024y27.Lighting)
		{
			switch (_0023_003DzP6FAuV4Dwq24.ColorMethod)
			{
			case hiddenLinesColorMethodType.SingleColor:
			case hiddenLinesColorMethodType.EntityMaterial:
				workspaceSetMatrixAndColorFunc = _0023_003DzgIRnQ_KZkLTC11x8uw_003D_003D;
				workspaceSetMatrixAndColorFunc3 = delegate(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
				{
					_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
					_0023_003DzmNZD0Zs_003D.SetColorShadedInternal(_0023_003Dz5iRcFgagQUUy, _0023_003DzXluM0iA_003D ? _0023_003DzXgBARg0tIZEa : _0023_003Dzhpb8QNg_003D, _0023_003DzXluM0iA_003D, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D);
					if (_0023_003DzXluM0iA_003D && _0023_003Dz5eJIEOtJbD5X)
					{
						_0023_003Dzt5jpbHs_003D.InsideSelectionColor = Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, _0023_003DzXgBARg0tIZEa);
						_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
						_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Shaded;
					}
				};
				break;
			case hiddenLinesColorMethodType.EntityColor:
				workspaceSetMatrixAndColorFunc = delegate(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
				{
					_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
					_0023_003DzmNZD0Zs_003D.SetColorShadedInternal(_0023_003Dz5iRcFgagQUUy, _0023_003DzXluM0iA_003D ? _0023_003DzXgBARg0tIZEa : _0023_003Dzhpb8QNg_003D, _0023_003DzXluM0iA_003D, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D);
					if (_0023_003DzXluM0iA_003D && _0023_003Dz5eJIEOtJbD5X)
					{
						_0023_003Dzt5jpbHs_003D.InsideSelectionColor = Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, _0023_003DzXgBARg0tIZEa);
						_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
						_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Shaded;
					}
				};
				workspaceSetMatrixAndColorFunc3 = delegate(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
				{
					_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
					_0023_003DzmNZD0Zs_003D.SetColorShadedInternal(_0023_003Dz5iRcFgagQUUy, _0023_003DzXluM0iA_003D ? _0023_003DzXgBARg0tIZEa : _0023_003Dzhpb8QNg_003D, _0023_003DzXluM0iA_003D, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D);
					if (_0023_003DzXluM0iA_003D && _0023_003Dz5eJIEOtJbD5X)
					{
						_0023_003Dzt5jpbHs_003D.InsideSelectionColor = Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, _0023_003DzXgBARg0tIZEa);
						_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
						_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Shaded;
					}
				};
				break;
			}
			workspaceSetMatrixAndColorFunc2 = workspaceSetMatrixAndColorFunc3;
		}
		else if (_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
		{
			workspaceSetMatrixAndColorFunc = ((_0023_003DzP6FAuV4Dwq24.ColorMethod != hiddenLinesColorMethodType.EntityMaterial) ? new WorkspaceSetMatrixAndColorFunc(_0023_003DzAszWjnpwwvmA7UlhuaDKRUBZAZE8NeOkIg_003D_003D) : ((WorkspaceSetMatrixAndColorFunc)delegate(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
			{
				_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
				if (!_0023_003DzXluM0iA_003D && _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.TextureImage != null)
				{
					_0023_003DzmNZD0Zs_003D.SetShader((_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.AlphaMapImage != null) ? shaderType.Texture2DWithAlphaMap : shaderType.Texture2D, _0023_003DzgcK4Z11iT1YA);
					_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.SetTexture(_0023_003DzmNZD0Zs_003D);
				}
				if (_0023_003DzXluM0iA_003D)
				{
					Color color = Color.FromArgb(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse.A, _0023_003DzXgBARg0tIZEa);
					if (_0023_003Dz5eJIEOtJbD5X)
					{
						_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse;
						_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
						_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientNotSelected;
					}
					_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(color);
				}
				else
				{
					_0023_003Dzt5jpbHs_003D.RenderContext.SetMaterialFrontAmbient(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse);
				}
			}));
			workspaceSetMatrixAndColorFunc2 = workspaceSetMatrixAndColorFunc;
			_0023_003Dz_0024m0wHyJzdT4E = shaderType.Standard;
			workspaceSetMatrixAndColorFunc3 = _0023_003DzQUi8lQuSRV4fBZFsA9EOs94_003D;
			setAttributesFunc = delegate(DrawEntitiesParams drawEntitiesParams2, out bool _0023_003DzAYcbN5Y_003D, ref Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzgiBiywzBnB2E)
			{
				bool flag = _0023_003DzlT_tPDs_003D(drawEntitiesParams2.DrawParams.ParentSelected, drawEntitiesParams2.DrawParams, _0023_003DztJCl_0024mM_003D);
				drawEntitiesParams2.selectionFound |= flag;
				drawEntitiesParams2.DrawParams.Selected = (_0023_003DzAYcbN5Y_003D = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, drawEntitiesParams2.DrawParams));
				drawEntitiesParams2.DrawParams.Clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(drawEntitiesParams2.DrawParams.ParentClippable, drawEntitiesParams2.DrawParams, _0023_003DztJCl_0024mM_003D);
				if (_0023_003DztJCl_0024mM_003D.GetPrimitiveTypeForHiddenLines(drawEntitiesParams2.DrawParams) == shaderPrimitiveType.Polygon)
				{
					if (_0023_003DzAYcbN5Y_003D)
					{
						GfxAttributesHDLWiresSingleColor gfxAttributesHDLWiresSingleColor = (GfxAttributesHDLWiresSingleColor)drawEntitiesParams2.DrawParams.Attributes;
						Color mySelectionColor = ((_0023_003DzAYcbN5Y_003D && _0023_003DztJCl_0024mM_003D.IsPolygonal()) ? drawEntitiesParams2.DrawParams.SelectionColor : drawEntitiesParams2.DrawParams.WireSelectionColor);
						Color color = Color.Empty;
						Material material = null;
						if (drawEntitiesParams2.UseMaterial)
						{
							material = gfxAttributesHDLWiresSingleColor.GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, _0023_003Dzxpbv4lQ_003D, drawEntitiesParams2.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
						}
						else
						{
							color = gfxAttributesHDLWiresSingleColor.GetColor(drawEntitiesParams2.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
						}
						bool flag2 = _0023_003DztJCl_0024mM_003D.SelectedInternal();
						if (flag2)
						{
							_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
							_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Standard);
							drawEntitiesParams2.SetMatrixAndColorForPolygons(drawEntitiesParams2.ShaderParams, drawEntitiesParams2.DrawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, material, _0023_003DzAYcbN5Y_003D, mySelectionColor, flag2);
						}
						else
						{
							_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
							_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
							drawEntitiesParams2.SetMatrixAndColorForWire(drawEntitiesParams2.ShaderParams, drawEntitiesParams2.DrawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, material, _0023_003DzAYcbN5Y_003D, mySelectionColor, flag2);
						}
						return true;
					}
					_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
				}
				else
				{
					_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
				}
				return _0023_003DzVJz9IYLkDSUBljWpNA_003D_003D(drawEntitiesParams2, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E);
			};
		}
		else
		{
			workspaceSetMatrixAndColorFunc = ((_0023_003DzP6FAuV4Dwq24.ColorMethod != hiddenLinesColorMethodType.EntityMaterial) ? new WorkspaceSetMatrixAndColorFunc(_0023_003DzQUi8lQuSRV4fBZFsA9EOs94_003D) : new WorkspaceSetMatrixAndColorFunc(_0023_003DzocPHp9R8S4UZceQMIg_003D_003D));
			workspaceSetMatrixAndColorFunc3 = delegate(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
			{
				_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
				_0023_003DzmNZD0Zs_003D.SetColorShadedInternal(_0023_003Dz5iRcFgagQUUy, _0023_003DzXluM0iA_003D ? _0023_003DzXgBARg0tIZEa : _0023_003Dzhpb8QNg_003D, _0023_003DzXluM0iA_003D, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D);
				if (_0023_003DzXluM0iA_003D && _0023_003Dz5eJIEOtJbD5X)
				{
					_0023_003Dzt5jpbHs_003D.InsideSelectionColor = Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, _0023_003DzXgBARg0tIZEa);
					_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
					_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Shaded;
				}
			};
			workspaceSetMatrixAndColorFunc2 = workspaceSetMatrixAndColorFunc3;
		}
		_0023_003DzmNZD0Zs_003D.InitializePreviousColorsHiddenLines(_0023_003Dzddm_0024rF6S_0024y27.ColorMethod == hiddenLinesColorMethodType.SingleColor);
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		_0023_003DzmNZD0Zs_003D.SetLighting(_0023_003Dzddm_0024rF6S_0024y27.Lighting);
		if (_0023_003Dzddm_0024rF6S_0024y27.Lighting || _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
		{
			_0023_003DzxYKjPsMqweAzSfdh_0024g_003D_003D = shaderType.Standard;
			if (_0023_003DzCBM7XJK4_5H_0024.ShaderParams != null)
			{
				_0023_003DzCBM7XJK4_5H_0024.ShaderParams.Lighting = true;
			}
		}
		else
		{
			_0023_003DzxYKjPsMqweAzSfdh_0024g_003D_003D = shaderType.NoLights;
			if (_0023_003DzCBM7XJK4_5H_0024.ShaderParams != null)
			{
				_0023_003DzCBM7XJK4_5H_0024.ShaderParams.Lighting = false;
			}
		}
		_0023_003Dz_9qS3W815tFjCa_RC_0024JgHyk_003D(_0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL: true);
		float size = _0023_003Dzddm_0024rF6S_0024y27.WireThickness * _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor;
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetPointSize(size, setShader: false);
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetLineSize(size, setShader: false);
		RenderParams _0023_003DzrFXPIITH9q = new RenderParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			LineWeightFactor = 1f,
			Attributes = attributes,
			ParentSelected = false,
			SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
			PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzQDU9c0AE6yqQ, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify)
		{
			SetMatrixAndColorForPolygons = workspaceSetMatrixAndColorFunc,
			SetMatrixAndColorForText = workspaceSetMatrixAndColorFunc2,
			SetMatrixAndColorForWire = workspaceSetMatrixAndColorFunc3,
			ShaderParams = _0023_003DzCBM7XJK4_5H_0024.ShaderParams,
			SetAttributesFunc = setAttributesFunc,
			UseMaterial = (_0023_003DzP6FAuV4Dwq24.ColorMethod == hiddenLinesColorMethodType.EntityMaterial)
		};
		bool[] _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D = null;
		if (_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor && !_0023_003Dzddm_0024rF6S_0024y27.Lighting)
		{
			_0023_003Dzk9HwUQ4uSzdtWt6BErpx4Zw_003D(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, ref _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D);
		}
		IList<Entity> entList = drawEntitiesParams.entList;
		_ = drawEntitiesParams.DrawParams.ForceGray;
		_0023_003DzXjYhqZfCe1_0024fD9iLuw_003D_003D(drawEntitiesParams);
		drawEntitiesParams.entList = entList;
		if (!_0023_003DzmNZD0Zs_003D.IsDrawingForDepth)
		{
			if (_0023_003Dzmq468FOl1RBUpGlrEpFsBdQ4ifHS(drawEntitiesParams))
			{
				if (_0023_003DzjC4hA2I_003D.isHardwareAccelerated && _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod != backfaceColorMethodType.Cull)
				{
					drawEntitiesParams.drawFastTransparencyEntityCallBack = _0023_003DzpdqKdfyxDQUXvopvQQ_003D_003D;
				}
				else
				{
					drawEntitiesParams.drawFastTransparencyEntityCallBack = _0023_003Dzs_JW4tuF3Va1cQDSbGuydX8_003D;
				}
				if (_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor && !_0023_003Dzddm_0024rF6S_0024y27.Lighting)
				{
					_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
					workspaceSetMatrixAndColorFunc = ((_0023_003DzP6FAuV4Dwq24.ColorMethod != hiddenLinesColorMethodType.EntityMaterial) ? ((WorkspaceSetMatrixAndColorFunc)delegate(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003DzprdlCI4ebqkL, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
					{
						_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
						Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003DzprdlCI4ebqkL.A, _0023_003DzXgBARg0tIZEa) : _0023_003DzprdlCI4ebqkL);
						if (_0023_003DzXluM0iA_003D)
						{
							_0023_003DzmNZD0Zs_003D.SetColorWireframe(color);
							if (_0023_003Dz5eJIEOtJbD5X)
							{
								_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzprdlCI4ebqkL;
								_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
								_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientDiffuse_ColorBackMaterialDiffuseNotSelected;
							}
						}
						else
						{
							_0023_003DzmNZD0Zs_003D.SetMaterialFrontAmbientAndDiffuse(color);
							_0023_003DzmNZD0Zs_003D.SetMaterialBackDiffuse(color);
						}
					}) : new WorkspaceSetMatrixAndColorFunc(_0023_003Dz6RP_FjC6g9P5zebyAUf9tjM1ALsaM02HoqhlzdE_003D));
					_0023_003Dz_0024m0wHyJzdT4E = shaderType.Standard;
					workspaceSetMatrixAndColorFunc3 = delegate(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003DzprdlCI4ebqkL, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
					{
						_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
						Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003DzprdlCI4ebqkL.A, _0023_003DzXgBARg0tIZEa) : _0023_003DzprdlCI4ebqkL);
						if (_0023_003DzXluM0iA_003D)
						{
							_0023_003DzmNZD0Zs_003D.SetColorWireframe(color);
							if (_0023_003Dz5eJIEOtJbD5X)
							{
								_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzprdlCI4ebqkL;
								_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
								_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientDiffuse_ColorBackMaterialDiffuseNotSelected;
							}
						}
						else
						{
							_0023_003DzmNZD0Zs_003D.SetMaterialFrontAmbientAndDiffuse(color);
							_0023_003DzmNZD0Zs_003D.SetMaterialBackDiffuse(color);
						}
					};
				}
				drawEntitiesParams.SetMatrixAndColorForPolygons = workspaceSetMatrixAndColorFunc;
				drawEntitiesParams.SetMatrixAndColorForWire = workspaceSetMatrixAndColorFunc3;
				_0023_003DzC5REXepTAzmHLaLJ_0024NPKwp5IL_xx(drawEntitiesParams, _0023_003DzisAcDtuSRYrAV8R7Az_qYJk_003D);
				drawEntitiesParams.entList = entList;
			}
			_0023_003DzCBM7XJK4_5H_0024.selectionFound |= drawEntitiesParams.selectionFound;
			if (AccurateTransparency && _0023_003Dzddm_0024rF6S_0024y27.ColorMethod != hiddenLinesColorMethodType.SingleColor)
			{
				if (_0023_003Dzddm_0024rF6S_0024y27.Lighting || _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
				{
					_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
				}
				_0023_003DzAjlbXONkieO7(_0023_003DzCBM7XJK4_5H_0024, drawEntitiesParams.DrawParams.SelectionColor);
			}
			if (_0023_003Dzddm_0024rF6S_0024y27.DashedHiddenLines)
			{
				if (!AccurateTransparency)
				{
					_0023_003DzmNZD0Zs_003D.SetState(blendStateType.ColorMaskOff);
					drawEntitiesParams.drawFastTransparencyEntityCallBack = _0023_003Dzs_JW4tuF3Va1cQDSbGuydX8_003D;
					drawEntitiesParams.DrawParams.LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor;
					drawEntitiesParams.DrawParams.SelectionLineWeightScaleFactor = Selection.LineWeightScaleFactor;
					drawEntitiesParams.drawZBufferOnly = true;
					drawEntitiesParams.SetMatrixAndColorForPolygons = workspaceSetMatrixAndColorFunc;
					drawEntitiesParams.SetMatrixAndColorForWire = workspaceSetMatrixAndColorFunc3;
					_0023_003DzisAcDtuSRYrAV8R7Az_qYJk_003D(drawEntitiesParams);
					_0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
				}
				_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
				_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthMaskFalse_DepthTestGreater);
				bool num = _0023_003DzyPPFAn2wOKkLAuBojlsEL2A_003D(_0023_003DzOUFng_M_003D, _0023_003DzCBM7XJK4_5H_0024.Simplify);
				_0023_003DzmNZD0Zs_003D.SetLineStipple(3, _0023_003Dzddm_0024rF6S_0024y27.DashedHiddenLinesPattern, _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera);
				_0023_003DzmNZD0Zs_003D.EnableLineStipple(enable: true);
				_0023_003Dznmirx4AJFkdvIkj_rjmL0sU_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: true);
				if (num)
				{
					_0023_003DzKm24hrH9IcmmaARdVrPi0mw_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: true);
				}
				_0023_003DzmNZD0Zs_003D.EnableLineStipple(enable: false);
				_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLessEqual);
				_0023_003Dznmirx4AJFkdvIkj_rjmL0sU_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: false);
				if (num)
				{
					_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
					_0023_003DzKm24hrH9IcmmaARdVrPi0mw_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzOUFng_M_003D, _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: false);
				}
				_0023_003DzmNZD0Zs_003D.EnableLineStipple(enable: false);
				_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
			}
		}
		if (_0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D != null)
		{
			_0023_003DzWsXtT_0024NYYJ_0024or5QLaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D);
		}
		_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
	}

	private bool _0023_003DzyPPFAn2wOKkLAuBojlsEL2A_003D(DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D)
	{
		if (_0023_003DzOUFng_M_003D.SilhouettesDrawingMode != silhouettesDrawingType.Never && _0023_003DzOUFng_M_003D.SilhouettesDrawingMode != silhouettesDrawingType.ImageBased)
		{
			if (_0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D)
			{
				return _0023_003DzOUFng_M_003D.SilhouettesDrawingMode == silhouettesDrawingType.Always;
			}
			return true;
		}
		return false;
	}

	internal void _0023_003DzXS86eTnj2Efz(ComputeEntitiesVisibilityParams _0023_003Dzt5jpbHs_003D, bool _0023_003Dzk3KGpSl0I48qPYLcl6ZgXyfgAmDk, BlockKeyedCollection _0023_003Dz9W2nj9A_003D, bool _0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D, bool _0023_003DzR_Y4Y8l6CHTLWNjKvLz_0024Yag_003D)
	{
		FrustumParams _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D = new FrustumParams(_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[_0023_003Dzt5jpbHs_003D.viewportIndex]._0023_003DzLK0OwXvAsOsnI9nS_0024Q_003D_003D(_0023_003Dzk3KGpSl0I48qPYLcl6ZgXyfgAmDk), this, _0023_003Dz9W2nj9A_003D);
		_0023_003DzXS86eTnj2Efz(_0023_003Dzt5jpbHs_003D, _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D, _0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D, _0023_003DzR_Y4Y8l6CHTLWNjKvLz_0024Yag_003D);
	}

	internal void _0023_003DzXS86eTnj2Efz(ComputeEntitiesVisibilityParams _0023_003Dzt5jpbHs_003D, FrustumParams _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D, bool _0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D, bool _0023_003DzR_Y4Y8l6CHTLWNjKvLz_0024Yag_003D)
	{
		if (!_0023_003DzBnb5yu3Zdgc7tl4iVkxuANw_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D))
		{
			return;
		}
		if ((_0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D || _0023_003DzR_Y4Y8l6CHTLWNjKvLz_0024Yag_003D) && _0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D != null)
		{
			_0023_003DzjXihpCSaialtFv__0024bQ_003D_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D);
			return;
		}
		int count = _0023_003Dzt5jpbHs_003D.entities.Count;
		if (_0023_003Dzt5jpbHs_003D.animating || _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D.Frustum == null)
		{
			for (int i = 0; i < count; i++)
			{
				Entity entity = _0023_003Dzt5jpbHs_003D.entities[i];
				entity.visibleAndInFrustum = entity.IsVisible(Layers);
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				Entity entity2 = _0023_003Dzt5jpbHs_003D.entities[j];
				entity2.visibleAndInFrustum = entity2.IsVisible(Layers) && entity2.IsInFrustum(_0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D);
			}
		}
	}

	private void _0023_003DzjXihpCSaialtFv__0024bQ_003D_003D(ComputeEntitiesVisibilityParams _0023_003Dzt5jpbHs_003D, FrustumParams _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D)
	{
		if (_0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D.Frustum != null)
		{
			foreach (Entity entity in _0023_003Dzt5jpbHs_003D.entities)
			{
				entity.visibleAndInFrustum = entity.IsInFrustum(_0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D);
			}
			return;
		}
		foreach (Entity entity2 in _0023_003Dzt5jpbHs_003D.entities)
		{
			entity2.visibleAndInFrustum = true;
		}
	}

	private void _0023_003DzKmbwXZYU8FSOGS0_Yg_003D_003D(Entity _0023_003DzpWC0efg_003D)
	{
		if (!_0023_003DzpWC0efg_003D.visibleAndInFrustum || !(_0023_003DzpWC0efg_003D is BlockReference blockReference))
		{
			return;
		}
		foreach (Entity entity in blockReference.GetEntities(Blocks))
		{
			entity.visibleAndInFrustum = true;
		}
	}

	internal void _0023_003DzNoWo3ia9iHbpna8dpg_003D_003D(ComputeEntitiesVisibilityParams _0023_003Dzt5jpbHs_003D, FrustumParams _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D)
	{
		if (!_0023_003DzBnb5yu3Zdgc7tl4iVkxuANw_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D))
		{
			return;
		}
		int count = _0023_003Dzt5jpbHs_003D.entities.Count;
		if (_0023_003Dzt5jpbHs_003D.animating || _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D.Frustum == null)
		{
			for (int i = 0; i < count; i++)
			{
				Entity entity = _0023_003Dzt5jpbHs_003D.entities[i];
				entity.visibleAndInFrustum = entity.IsVisible(new Stack<BlockReference>(), Layers, AttributeReferenceVisibilityMode);
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				Entity entity2 = _0023_003Dzt5jpbHs_003D.entities[j];
				entity2.visibleAndInFrustum = entity2.IsVisible(new Stack<BlockReference>(), Layers, AttributeReferenceVisibilityMode) && entity2.IsInFrustum(_0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D);
			}
		}
	}

	private bool _0023_003DzBnb5yu3Zdgc7tl4iVkxuANw_003D(ComputeEntitiesVisibilityParams _0023_003Dzt5jpbHs_003D, FrustumParams _0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D)
	{
		if (!_0023_003Dzt5jpbHs_003D.animating)
		{
			if (_0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D.Frustum == null)
			{
				return false;
			}
			Point3D[] array = ((!_0023_003Dz6CMmzY6fHGlL.OverrideSceneExtents) ? Utility.GetBoundingBoxCorners(_0023_003Dzt5jpbHs_003D.entityGlobalMin, _0023_003Dzt5jpbHs_003D.entityGlobalMax) : Utility.GetBoundingBoxCorners(_0023_003Dz6CMmzY6fHGlL.Min, _0023_003Dz6CMmzY6fHGlL.Max));
			for (int i = 0; i < 8 && Utility.IsInFrustum(_0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D.Frustum, array[i], 0.0); i++)
			{
				if (i == 7)
				{
					_0023_003Dz3Y1gUqSmYYMWeKZ3gA_003D_003D.Frustum = null;
				}
			}
		}
		return true;
	}

	[DebuggerStepThrough]
	internal int _0023_003DzPEEjwoPxhT6e(Viewport _0023_003DzYzWi5Yw_003D)
	{
		for (int i = 0; i < _0023_003DzbesAu90NcF8KFeewpw_003D_003D.Count; i++)
		{
			if (_0023_003DzbesAu90NcF8KFeewpw_003D_003D[i] == _0023_003DzYzWi5Yw_003D)
			{
				return i;
			}
		}
		return -1;
	}

	private bool _0023_003Dz4Ncif4_V86w4jt_0024_0024Rel0fVILAbWX(DrawSceneParams _0023_003Dzt5jpbHs_003D)
	{
		if ((_0023_003Dz28QCun7pbbWH & selectionFilterType.Vertex) != 0 && (_0023_003DzHjFAmfaGpEeM() || (_0023_003DzceJZi0o_003D && _0023_003DzHjFAmfaGpEeM(_0023_003Dz1AtQxyQVwP3J))))
		{
			return !_0023_003Dzt5jpbHs_003D.ZBufferOnly;
		}
		return false;
	}

	internal virtual void _0023_003Dzemj_0024cuX1Dkz_KyAnyw_003D_003D(DrawSceneParams _0023_003Dzt5jpbHs_003D)
	{
		Viewport viewport = (Viewport)_0023_003Dzt5jpbHs_003D.Viewport;
		bool simplify = _0023_003Dzt5jpbHs_003D.Simplify;
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.Black);
		bool flag = _0023_003Dz4Ncif4_V86w4jt_0024_0024Rel0fVILAbWX(_0023_003Dzt5jpbHs_003D);
		if (viewport.ShowVertices || flag)
		{
			_0023_003Dz_00245AA7MKw1Rjg6c1dZ31GM1Y_003D(_0023_003Dzt5jpbHs_003D, flag, viewport.ShowVertices, selectionStatusType.Permanent);
		}
		if (_0023_003DzwMU34Oc0NLb_3_0024j4Jg_003D_003D)
		{
			Color contrastColor = _0023_003DzipBYly6zFKAp().Background.GetContrastColor();
			_0023_003DzmNZD0Zs_003D.SetLineSize(1f, setShader: false);
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(contrastColor);
			DrawParams _0023_003DzrFXPIITH9q = new DrawParams(viewport, _0023_003Dzt5jpbHs_003D.Blocks)
			{
				LineWeightFactor = 1f,
				SelectionLineWeightScaleFactor = 1f,
				Attributes = new GfxAttributes(contrastColor),
				ParentSelected = false,
				SelectionStatus = _0023_003Dzt5jpbHs_003D.SelectionStatus,
				PlanarReflections = false
			};
			DrawEntitiesParams _0023_003Dzt5jpbHs_003D2 = new DrawEntitiesParams(this, _0023_003Dzt5jpbHs_003D.Entities, _0023_003DzrFXPIITH9q, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D: false);
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003Dzt5jpbHs_003D) && !_0023_003Dzt5jpbHs_003D.isLastBatch && _0023_003Dzt5jpbHs_003D.isProgressiveDrawing)
			{
				_0023_003Dzt5jpbHs_003D.RenderContext.ProgDrawCompositingBase.BindTarget(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons);
				_0023_003DzI0krhr3o0LGChFWi9Q_003D_003D(_0023_003Dzt5jpbHs_003D2);
				_0023_003Dzt5jpbHs_003D.RenderContext.ProgDrawCompositingBase.RestoreBuffers();
			}
			else
			{
				_0023_003DzI0krhr3o0LGChFWi9Q_003D_003D(_0023_003Dzt5jpbHs_003D2);
			}
		}
		if (_0023_003DzTmVXuIf7B_f_)
		{
			GfxAttributes attributes = ((viewport._0023_003DzK_00241ezHQJ9Z3c != displayType.HiddenLines || _0023_003DzP6FAuV4Dwq24.ColorMethod != hiddenLinesColorMethodType.SingleColor) ? new GfxAttributesColor(Document.DefaultColor, Layers) : new GfxAttributes(_0023_003DzP6FAuV4Dwq24.WireColor));
			DrawParams _0023_003DzrFXPIITH9q2 = new DrawParams(viewport, _0023_003Dzt5jpbHs_003D.Blocks, _0023_003Dzt5jpbHs_003D.ShaderParams)
			{
				LineWeightFactor = 1f,
				Attributes = attributes,
				ParentSelected = false,
				SelectionStatus = _0023_003Dzt5jpbHs_003D.SelectionStatus,
				PlanarReflections = false
			};
			DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003Dzt5jpbHs_003D.Entities, _0023_003DzrFXPIITH9q2, simplify);
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
			_0023_003DzioJIQ5Bufb8i = true;
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003Dzt5jpbHs_003D) && !_0023_003Dzt5jpbHs_003D.isLastBatch && _0023_003Dzt5jpbHs_003D.isProgressiveDrawing)
			{
				_0023_003Dzt5jpbHs_003D.RenderContext.ProgDrawCompositingBase.BindTarget(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons);
				_0023_003DzKcRA6DL6d_8l(drawEntitiesParams);
				_0023_003Dzt5jpbHs_003D.RenderContext.ProgDrawCompositingBase.RestoreBuffers();
			}
			else
			{
				_0023_003DzKcRA6DL6d_8l(drawEntitiesParams);
			}
			if ((_0023_003Dzt5jpbHs_003D.SelectionStatus == selectionStatusType.Permanent && _0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(viewport)) || (_0023_003Dzt5jpbHs_003D.SelectionStatus == selectionStatusType.Temporary && _0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(viewport)))
			{
				drawEntitiesParams.DrawParams.WireSelectionColor = RenderContextBase.selectionWithoutHaloColor;
				drawEntitiesParams.isDrawingStaticWithHalo = (drawEntitiesParams.DrawParams.IsDrawingForHaloStatic = _0023_003Dzt5jpbHs_003D.SelectionStatus == selectionStatusType.Permanent);
				drawEntitiesParams.isDrawingDynamicWithHalo = (drawEntitiesParams.DrawParams.IsDrawingForHaloDynamic = _0023_003Dzt5jpbHs_003D.SelectionStatus == selectionStatusType.Temporary);
				HaloSelectionCompositingBase obj = (drawEntitiesParams.isDrawingDynamicWithHalo ? _0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing : _0023_003DzmNZD0Zs_003D.staticSelectionCompositing);
				obj.SetTarget();
				_0023_003DzKcRA6DL6d_8l(drawEntitiesParams);
				obj.ResetTarget();
			}
			_0023_003DzioJIQ5Bufb8i = false;
		}
	}

	private void _0023_003Dz_00245AA7MKw1Rjg6c1dZ31GM1Y_003D(DrawSceneParams _0023_003Dzt5jpbHs_003D, bool _0023_003Dz7lHhy1sRzZpO8EN9H6byh5QASR31, bool _0023_003Dz5vxPVaF6_0024csnbahlHIqw2Dk_003D, selectionStatusType _0023_003Dzo1hajQa70VH4)
	{
		_0023_003DzVDWKENEvkICzu1pmCwhQFoc_003D((Viewport)_0023_003Dzt5jpbHs_003D.Viewport);
		GfxAttributes attributes = new GfxAttributes(_0023_003DzipBYly6zFKAp().Background.GetContrastColor());
		DrawParams _0023_003DzrFXPIITH9q = new DrawParams(_0023_003Dzt5jpbHs_003D.Viewport, _0023_003Dzt5jpbHs_003D.Blocks)
		{
			LineWeightFactor = 1f,
			SelectionLineWeightScaleFactor = 1f,
			Attributes = attributes,
			ParentSelected = false,
			SelectionStatus = (_0023_003Dz7lHhy1sRzZpO8EN9H6byh5QASR31 ? _0023_003Dzo1hajQa70VH4 : selectionStatusType.None),
			PlanarReflections = false,
			ShowVertices = _0023_003Dz5vxPVaF6_0024csnbahlHIqw2Dk_003D
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003Dzt5jpbHs_003D.Entities, _0023_003DzrFXPIITH9q, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D: false);
		drawEntitiesParams.DrawParams.ColorMode = colorType.Wireframe;
		drawEntitiesParams.DrawParams.InsideSelectionColor = (drawEntitiesParams.DrawParams.SelectionColor = ((_0023_003Dzo1hajQa70VH4 == selectionStatusType.Temporary) ? Selection.ColorDynamic : Selection.Color));
		if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003Dzt5jpbHs_003D) && !_0023_003Dzt5jpbHs_003D.isLastBatch && _0023_003Dzt5jpbHs_003D.isProgressiveDrawing)
		{
			_0023_003Dzt5jpbHs_003D.RenderContext.ProgDrawCompositingBase.BindTarget(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons);
			DrawVertices(drawEntitiesParams);
			_0023_003Dzt5jpbHs_003D.RenderContext.ProgDrawCompositingBase.RestoreBuffers();
		}
		else
		{
			DrawVertices(drawEntitiesParams);
		}
		IViewportInternal viewportInternal = _0023_003Dzt5jpbHs_003D.viewportInternal;
		if ((_0023_003Dzo1hajQa70VH4 == selectionStatusType.Permanent && _0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(viewportInternal)) || (_0023_003Dzo1hajQa70VH4 == selectionStatusType.Temporary && _0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(viewportInternal)))
		{
			drawEntitiesParams.isDrawingStaticWithHalo = (drawEntitiesParams.DrawParams.IsDrawingForHaloStatic = _0023_003Dzo1hajQa70VH4 == selectionStatusType.Permanent);
			drawEntitiesParams.isDrawingDynamicWithHalo = (drawEntitiesParams.DrawParams.IsDrawingForHaloDynamic = _0023_003Dzo1hajQa70VH4 == selectionStatusType.Temporary);
			HaloSelectionCompositingBase obj = (drawEntitiesParams.isDrawingDynamicWithHalo ? _0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing : _0023_003DzmNZD0Zs_003D.staticSelectionCompositing);
			obj.SetTarget();
			_0023_003DzZXXk_zTofCaZo4oAL4h_0024Aj6IxdJJ(out var _0023_003DzY0QKsduO660t, out var _0023_003DzIrjRBKtrORSoH3gT4A_003D_003D);
			drawEntitiesParams.DrawParams.SelectionColor = ((_0023_003Dzo1hajQa70VH4 == selectionStatusType.Temporary) ? Selection.ColorDynamic : Selection.Color);
			DrawVertices(drawEntitiesParams);
			_0023_003DzG3sj0FFSBkNrHyujN8NeHIHd8KYm(_0023_003DzY0QKsduO660t, _0023_003DzIrjRBKtrORSoH3gT4A_003D_003D);
			obj.ResetTarget();
		}
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
	}

	private void _0023_003DzVDWKENEvkICzu1pmCwhQFoc_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLightsThickPoints);
		_0023_003DzmNZD0Zs_003D.SetPointSize((float)_0023_003DzYzWi5Yw_003D._0023_003Dzl8iYFG8_0024fwR_0024 * _0023_003DztnrgTmT5sBNd().Height, setShader: false);
		_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CW_PolygonFill_NoCullFace_NoPolygonOffset);
	}

	private void _0023_003DzMlxPoe72PCRQhFUzlNK1XCo_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.MultiColorNoLightsThickPoints);
		_0023_003DzmNZD0Zs_003D.SetPointSize((float)_0023_003DzYzWi5Yw_003D._0023_003Dzl8iYFG8_0024fwR_0024 * _0023_003DztnrgTmT5sBNd().Height, setShader: false);
		_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CW_PolygonFill_NoCullFace_NoPolygonOffset);
	}

	private void _0023_003DzKcRA6DL6d_8l(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		DrawParams drawParams = _0023_003DzCBM7XJK4_5H_0024.DrawParams;
		GfxAttributes _0023_003DzJxsQW2k8xtCB = (GfxAttributes)drawParams.Attributes.Clone();
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(drawParams);
		for (int i = 0; i < _0023_003DzCBM7XJK4_5H_0024.entList.Count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, _0023_003Dzbq3BJR0_003D) && _0023_003DzKzpx8cdmzcbK3YQybQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, entity, _0023_003DzJxsQW2k8xtCB, _0023_003DzKcRA6DL6d_8l))
			{
				bool _0023_003DzXluM0iA_003D = _0023_003DzlT_tPDs_003D(drawParams.ParentSelected, drawParams, entity);
				bool flag = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(_0023_003DzXluM0iA_003D, drawParams);
				if (!_0023_003DzIyZshL4CGo8KJOTfZQ_003D_003D(flag, _0023_003DzCBM7XJK4_5H_0024))
				{
					_0023_003DzX0fuIZ0_003D(drawParams.Viewport.Camera, flag);
					_0023_003DzMp6Z0a_0024RUMaP(drawParams, drawParams.Attributes.GetColor(), flag);
					_0023_003DzmNZD0Zs_003D.SetLineSize(GetEntityLineWeight(entity, null, Layers));
					drawParams.RenderContext = _0023_003DzmNZD0Zs_003D;
					entity.DrawDirection(drawParams);
				}
			}
		}
	}

	private bool _0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(Entity _0023_003DztJCl_0024mM_003D, Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		return _0023_003DztJCl_0024mM_003D.IsVisibleAndInFrustum(_0023_003Dzbq3BJR0_003D, Layers, AttributeReferenceVisibilityMode);
	}

	internal bool _0023_003DzlT_tPDs_003D<T>(bool _0023_003Dzl7FZ5_su2I_0024n, T _0023_003DzyrRdBi78wMnR, Entity _0023_003DztJCl_0024mM_003D) where T : DrawParams
	{
		if (!_0023_003Dzl7FZ5_su2I_0024n)
		{
			return _0023_003DztJCl_0024mM_003D.IsSelected(_0023_003DzyrRdBi78wMnR.Parents, _0023_003DzyrRdBi78wMnR.SelectionStatus);
		}
		return true;
	}

	internal bool _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D<T>(bool _0023_003Dz1pV06LTHfQzd4lXqpw_003D_003D, T _0023_003DzyrRdBi78wMnR, Entity _0023_003DztJCl_0024mM_003D) where T : DrawParams
	{
		if (_0023_003Dz1pV06LTHfQzd4lXqpw_003D_003D)
		{
			return _0023_003DztJCl_0024mM_003D.IsClippable(_0023_003DzyrRdBi78wMnR.Parents, Layers);
		}
		return false;
	}

	internal bool _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D<T>(bool _0023_003DzXluM0iA_003D, T _0023_003DzyrRdBi78wMnR) where T : DrawParams
	{
		if (_0023_003DzXluM0iA_003D && !_0023_003DzyrRdBi78wMnR.ForceGray)
		{
			return !_0023_003DzCeOS0DIwnrC2vi6UgQ_003D_003D(_0023_003DzyrRdBi78wMnR);
		}
		return false;
	}

	private bool _0023_003DzCeOS0DIwnrC2vi6UgQ_003D_003D<T>(T _0023_003DzyrRdBi78wMnR) where T : DrawParams
	{
		IViewportInternal viewportInternal = _0023_003DzyrRdBi78wMnR.viewportInternal;
		if (_0023_003DzyrRdBi78wMnR.IsDrawingForHaloStatic || !_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(viewportInternal) || _0023_003DzyrRdBi78wMnR.SelectionStatus != selectionStatusType.Permanent)
		{
			if (!_0023_003DzyrRdBi78wMnR.IsDrawingForHaloDynamic && _0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(viewportInternal))
			{
				return _0023_003DzyrRdBi78wMnR.SelectionStatus == selectionStatusType.Temporary;
			}
			return false;
		}
		return true;
	}

	private void _0023_003Dzj6CxAfItGiBE7EhX2OgB2vo_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003Dzz4aiLqY_0024r7bL)
	{
		_0023_003DzmNZD0Zs_003D.InitializePreviousColors();
		_0023_003Dz_9qS3W815tFjCa_RC_0024JgHyk_003D(_0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL);
		_0023_003DzmNZD0Zs_003D.GetShaderAndEnable(_0023_003DzCBM7XJK4_5H_0024.ShaderParams);
		_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(_0023_003DzCBM7XJK4_5H_0024.ShaderParams);
	}

	private bool _0023_003DzwRbyHapHUGov(DisplayModeSettings _0023_003DzOUFng_M_003D)
	{
		if (!_0023_003DzOUFng_M_003D.ShowEdges)
		{
			return _0023_003DzOUFng_M_003D?.ShowInternalWires ?? false;
		}
		return true;
	}

	private void _0023_003Dz_9qS3W815tFjCa_RC_0024JgHyk_003D(DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003Dzz4aiLqY_0024r7bL)
	{
		bool num = _0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D.ColorMethod == backfaceColorMethodType.Cull;
		bool flag = _0023_003Dzz4aiLqY_0024r7bL || _0023_003DzwRbyHapHUGov(_0023_003DzOUFng_M_003D);
		if (num)
		{
			if (flag)
			{
				_0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D = rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1;
			}
			else
			{
				_0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D = rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset;
			}
		}
		else if (flag)
		{
			_0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D = rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1;
		}
		else
		{
			_0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D = rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset;
		}
		_0023_003DzmNZD0Zs_003D.SetState(_0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D);
	}

	private void _0023_003DzUuKcWs7AMvWH(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D)
	{
		Color color = Color.Empty;
		float num;
		if (_0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D)
		{
			num = _0023_003Dzddm_0024rF6S_0024y27.DashedHiddenLinesThickness;
			color = _0023_003Dzddm_0024rF6S_0024y27.DashedHiddenLinesColor;
		}
		else
		{
			num = _0023_003DzOUFng_M_003D.EdgeThickness;
		}
		_0023_003DzmNZD0Zs_003D.SetLineSize(num * _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor, setShader: false);
		_0023_003DzmNZD0Zs_003D.EnableThickLinesInPolygonLineMode();
		if (!_0023_003DzOUFng_M_003D.ShowEdges)
		{
			return;
		}
		IList<Entity> entities = _0023_003DzCBM7XJK4_5H_0024.Entities;
		DrawParams drawParams = new DrawParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			LineWeightFactor = _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor,
			ParentSelected = false,
			SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
			PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections,
			EdgeThickness = num,
			shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers,
			IsDrawingForHaloDynamic = _0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo,
			IsDrawingForHaloStatic = _0023_003DzCBM7XJK4_5H_0024.isDrawingStaticWithHalo
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzCBM7XJK4_5H_0024.Entities, drawParams, _0023_003DzCBM7XJK4_5H_0024.Simplify);
		drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		drawEntitiesParams.isDrawingStaticWithHalo = _0023_003DzCBM7XJK4_5H_0024.isDrawingStaticWithHalo;
		drawEntitiesParams.isDrawingDynamicWithHalo = _0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo;
		if (_0023_003DzOUFng_M_003D.EdgeColorMethod == edgeColorMethodType.EntityColor)
		{
			if (_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode == displayType.Flat)
			{
				return;
			}
			if (_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode == displayType.Rendered)
			{
				drawParams.Attributes = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesMaterialOrColor>();
			}
			else
			{
				drawParams.Attributes = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesColor>();
			}
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003Dz3GItZNaPOXNt, _0023_003DzWTyrp_pMvYC4: true);
			}
			else
			{
				_0023_003Dz3GItZNaPOXNt(drawEntitiesParams);
			}
		}
		else
		{
			drawParams.Attributes = new GfxAttributes(_0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D ? color : _0023_003DzOUFng_M_003D.EdgeColor);
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003DzQqPMQa5z5fgt, _0023_003DzWTyrp_pMvYC4: true);
			}
			else
			{
				_0023_003DzQqPMQa5z5fgt(drawEntitiesParams);
			}
		}
		_0023_003DzCBM7XJK4_5H_0024.Entities = entities;
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= drawEntitiesParams.selectionFound;
	}

	protected void PostRemoveJitteringForFastZPR(RenderContextBase renderContext)
	{
		renderContext.PopModelView();
	}

	protected void PreRemoveJitteringForFastZPR(DrawSceneParams myParams, bool removeSceneTransformation = false)
	{
		myParams.RenderContext.PushModelView();
		if (removeSceneTransformation)
		{
			myParams.Viewport.Camera.RemoveSceneTransformation();
		}
	}

	private void _0023_003DzKm24hrH9IcmmaARdVrPi0mw_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, DisplayModeSettings _0023_003DzOUFng_M_003D, bool _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D)
	{
		if (!_0023_003DzyobtGSd5_zcs())
		{
			bool flag = _0023_003DzOUFng_M_003D is HiddenLinesSettings;
			Color color = Color.Empty;
			float num;
			float edgeThickness;
			if (_0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D)
			{
				num = _0023_003Dzddm_0024rF6S_0024y27.DashedHiddenLinesThickness;
				color = _0023_003Dzddm_0024rF6S_0024y27.DashedHiddenLinesColor;
				edgeThickness = num;
			}
			else
			{
				num = _0023_003DzOUFng_M_003D.SilhouetteThickness;
				edgeThickness = _0023_003DzOUFng_M_003D.EdgeThickness;
				_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetState(depthStencilStateType.DepthTestLessEqual);
			}
			_0023_003DzmNZD0Zs_003D.SetLineSize(num * _0023_003DzCBM7XJK4_5H_0024.LineWeightFactor, setShader: false);
			_0023_003DzmNZD0Zs_003D.EnableThickLinesInPolygonLineMode();
			GfxAttributes attributes = ((_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode == displayType.Flat || _0023_003DzOUFng_M_003D.EdgeColorMethod != edgeColorMethodType.EntityColor) ? new GfxAttributes(_0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D ? color : (flag ? _0023_003DzP6FAuV4Dwq24.SilhouetteColor : _0023_003DzOUFng_M_003D.EdgeColor)) : ((_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode != displayType.Rendered) ? _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesColor>() : _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesMaterialOrColor>()));
			DrawSilhouettesParams _0023_003DzrFXPIITH9q = new DrawSilhouettesParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.ProjectionMode, _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.GetModelViewProjectionMatrix(), _0023_003DzCBM7XJK4_5H_0024.viewportInternal.screenToWorld, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
			{
				LineWeightFactor = 0f,
				Attributes = attributes,
				ParentSelected = false,
				SelectionStatus = _0023_003DzCBM7XJK4_5H_0024.SelectionStatus,
				PlanarReflections = _0023_003DzCBM7XJK4_5H_0024.PlanarReflections,
				SilhoThickness = num,
				EdgeThickness = edgeThickness,
				shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers
			};
			DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
			drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
			drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
			if (CurrentBlockReference != null)
			{
				drawEntitiesParams.DrawParams.Attributes.Propagate(CurrentBlockReference, Layers[CurrentBlockReference.LayerName], _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
			}
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003Dzp_G1WU_qljazy3POZa9wfzY_003D(drawEntitiesParams, _0023_003Dz3lQVIQlV9uTseWasaoHaHLs_003D, _0023_003DzWTyrp_pMvYC4: true);
			}
			else
			{
				_0023_003Dz3lQVIQlV9uTseWasaoHaHLs_003D(drawEntitiesParams);
			}
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetState(depthStencilStateType.DepthTestLess);
		}
	}

	internal DisplayModeSettings _0023_003Dz0fTtstT4IqGh(displayType _0023_003DzK_00241ezHQJ9Z3c)
	{
		return _0023_003DzK_00241ezHQJ9Z3c switch
		{
			displayType.Wireframe => _0023_003DzsliWYheSU0DTuUNAYg_003D_003D, 
			displayType.Flat => _0023_003Dzl8PjArmAqC_m, 
			displayType.Shaded => _0023_003DzEfebv86OlSaQUw9POQ_003D_003D, 
			displayType.Rendered => _0023_003DzB_4avBudAWM2, 
			displayType.HiddenLines => _0023_003Dzddm_0024rF6S_0024y27, 
			_ => _0023_003DzEfebv86OlSaQUw9POQ_003D_003D, 
		};
	}

	protected virtual void DrawVertices(DrawEntitiesParams myParams)
	{
		if (!myParams.DrawParams.IsDrawingForHalo && myParams.DrawParams.ShowVertices)
		{
			GfxAttributes _0023_003DzJxsQW2k8xtCB = (GfxAttributes)myParams.DrawParams.Attributes.Clone();
			Stack<BlockReference> parents = _0023_003DzZuBsUvr900Ui(myParams.DrawParams);
			for (int i = 0; i < myParams.entList.Count; i++)
			{
				Entity entity = myParams.entList[i];
				if (entity.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode) && _0023_003DzKzpx8cdmzcbK3YQybQ_003D_003D(myParams, entity, _0023_003DzJxsQW2k8xtCB, DrawVertices))
				{
					_0023_003Dze99ar8BiiBSo(myParams.DrawParams, entity);
					bool flag = _0023_003DzlT_tPDs_003D(myParams.DrawParams.ParentSelected, myParams.DrawParams, entity);
					bool flag2 = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, myParams.DrawParams);
					myParams.selectionFound |= flag;
					if (!_0023_003DzIyZshL4CGo8KJOTfZQ_003D_003D(flag2, myParams))
					{
						bool clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(myParams.DrawParams.ParentClippable, myParams.DrawParams, entity);
						_0023_003DzmNZD0Zs_003D.SetClippable(clippable);
						_0023_003DzX0fuIZ0_003D(myParams.DrawParams.Viewport.Camera, flag2);
						_0023_003DzdFImu0JhVact(myParams.DrawParams, myParams.DrawParams.Attributes.GetColor(myParams.DrawParams.ForceGray, this, entity, edge: false, myParams.shouldUseSeparateBuffers), myParams.DrawParams.SelectionColor, _0023_003DzXluM0iA_003D: false);
						((IEntityInternal)entity).DrawVertices(myParams.DrawParams);
					}
				}
			}
		}
		_0023_003DzmNZD0Zs_003D.SetClippable(clippable: true);
		if (myParams.DrawParams.SelectionStatus != selectionStatusType.None)
		{
			_0023_003DzOAmuROAHZ5n_RS3gqSTRepY_003D(myParams);
		}
	}

	private void _0023_003DzOAmuROAHZ5n_RS3gqSTRepY_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributes _0023_003DzJxsQW2k8xtCB = (GfxAttributes)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		Stack<BlockReference> parents = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < _0023_003DzCBM7XJK4_5H_0024.entList.Count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (entity.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode) && _0023_003DzKzpx8cdmzcbK3YQybQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, entity, _0023_003DzJxsQW2k8xtCB, _0023_003DzOAmuROAHZ5n_RS3gqSTRepY_003D))
			{
				_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				bool flag = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				bool flag2 = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, _0023_003DzCBM7XJK4_5H_0024.DrawParams);
				_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
				if (!_0023_003DzIyZshL4CGo8KJOTfZQ_003D_003D(flag2, _0023_003DzCBM7XJK4_5H_0024))
				{
					bool clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
					_0023_003DzmNZD0Zs_003D.SetClippable(clippable);
					_0023_003DzX0fuIZ0_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Viewport.Camera, flag2);
					_0023_003DzdFImu0JhVact(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, entity, edge: false, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers), _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor, flag2);
					entity.DrawSelectedVertices(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
			}
		}
		_0023_003DzmNZD0Zs_003D.SetClippable(clippable: true);
	}

	private void _0023_003DzI0krhr3o0LGChFWi9Q_003D_003D(DrawEntitiesParams _0023_003Dzt5jpbHs_003D)
	{
		Stack<BlockReference> parents = _0023_003DzZuBsUvr900Ui(_0023_003Dzt5jpbHs_003D.DrawParams);
		for (int i = 0; i < _0023_003Dzt5jpbHs_003D.entList.Count; i++)
		{
			Entity entity = _0023_003Dzt5jpbHs_003D.entList[i];
			if (entity.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode))
			{
				if (entity is BlockReference)
				{
					((BlockReference)entity).Draw(_0023_003Dzt5jpbHs_003D, _0023_003DzI0krhr3o0LGChFWi9Q_003D_003D);
				}
				((IEntityInternal)entity).DrawNormals(_0023_003Dzt5jpbHs_003D.DrawParams);
			}
		}
	}

	private bool _0023_003Dz1SsHHjj6TVAG(Entity _0023_003DztJCl_0024mM_003D)
	{
		if (_0023_003DztJCl_0024mM_003D.entityNature != entityNatureType.None && _0023_003DztJCl_0024mM_003D.entityNature != entityNatureType.Polygon)
		{
			return _0023_003DztJCl_0024mM_003D.entityNature == entityNatureType.RichPolygon;
		}
		return true;
	}

	internal static void _0023_003DzheyifuKzO4fu(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawForSelection(_0023_003Dzt5jpbHs_003D);
	}

	internal static void _0023_003Dz1F3L86rBA66dWUpVtg_003D_003D(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawForSelectionFaces(_0023_003Dzt5jpbHs_003D);
	}

	internal static void _0023_003DzPE1raRPmmJNN(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawForSelectionEdges(_0023_003Dzt5jpbHs_003D);
	}

	internal static void _0023_003Dzk_0024UNrhzmH1xVBy4idlGVl5s_003D(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawForSelectionVertices(_0023_003Dzt5jpbHs_003D);
	}

	internal static void _0023_003Dz3h6UoJhfPPLMQQh4GUQU5oQ_003D(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawForSelectionSubCurves(_0023_003Dzt5jpbHs_003D);
	}

	internal static void _0023_003DzqaFVmwa_Rh9hzGrvEJwDUa4_003D(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawForSelectionSubContours(_0023_003Dzt5jpbHs_003D);
	}

	internal static void _0023_003DzwExT75lusObyLomd_qrgUEk_003D(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawForSelectionSketchPoints(_0023_003Dzt5jpbHs_003D);
	}

	internal static void _0023_003DzAL8qDSHLboIKNUhrOx2Q_0024w8pJHjS(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawForSelectionSketchCurves(_0023_003Dzt5jpbHs_003D);
	}

	internal static void _0023_003Dzt7i_0024Av6NnnpTrGX6Fl9fw20_003D(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams _0023_003Dzt5jpbHs_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawForSelectionWireframe(_0023_003Dzt5jpbHs_003D);
	}

	private void _0023_003Dzb_JtlBQHuPmWG0zla82zxns_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesWire _0023_003DzJxsQW2k8xtCB = (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		bool _0023_003DzAYcbN5Y_003D = false;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(_0023_003DztJCl_0024mM_003D, _0023_003Dzbq3BJR0_003D) || !_0023_003DzXUtUiHEMz_0024a5(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, ref _0023_003DztJCl_0024mM_003D, ref _0023_003DzAYcbN5Y_003D, _0023_003Dzb_JtlBQHuPmWG0zla82zxns_003D))
			{
				continue;
			}
			Color color = _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, edge: false, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers);
			if (!_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024))
			{
				if (color.A != byte.MaxValue && !AccurateTransparency && (!_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers || !NestedEntity.IsGrayMinFr(_0023_003DztJCl_0024mM_003D)))
				{
					_0023_003DzCBM7XJK4_5H_0024.transparencyFound = true;
				}
				else
				{
					_0023_003DzTdt_002451lXETWi(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D, color);
				}
			}
		}
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003DzzbHPX6XNACYHWWISoQ_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesWire _0023_003DzJxsQW2k8xtCB = (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		bool _0023_003DzAYcbN5Y_003D = false;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = _0023_003DzhkWmjEBIvoue(_0023_003DzCBM7XJK4_5H_0024); i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(_0023_003DztJCl_0024mM_003D, _0023_003Dzbq3BJR0_003D) || !_0023_003DzXUtUiHEMz_0024a5(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, ref _0023_003DztJCl_0024mM_003D, ref _0023_003DzAYcbN5Y_003D, _0023_003DzzbHPX6XNACYHWWISoQ_003D_003D) || !_0023_003Dz93R3M8noap87(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E: true) || _0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) || _0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) || _0023_003DzIyZshL4CGo8KJOTfZQ_003D_003D(_0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024))
			{
				continue;
			}
			_0023_003DzR45REbGtVacFfA93fA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D);
			base.RenderContext.SetClippable(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable);
			if (_0023_003DzAYcbN5Y_003D || _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray)
			{
				if (_0023_003DzCBM7XJK4_5H_0024.isDrawingWithHalo)
				{
					_0023_003DzycEvByhSyCb91SxUpPVThupo_0024awi(_0023_003DztJCl_0024mM_003D, out var _, out var _0023_003DzakC65tE_003D);
					_0023_003DzmNZD0Zs_003D.SetMaterialBackAmbient(_0023_003DzakC65tE_003D);
				}
				((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawFlatSelected(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
			}
			else
			{
				((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawFlat(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
			}
		}
		_0023_003DzmNZD0Zs_003D.SetTextureLength(0f);
		base.RenderContext.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003DzR45REbGtVacFfA93fA_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D)
	{
		if (_0023_003DztJCl_0024mM_003D.UseMaterialTextureLength)
		{
			Material parentMaterial = null;
			if (!string.IsNullOrEmpty(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.MaterialName))
			{
				parentMaterial = _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D[_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.MaterialName];
			}
			Material material = _0023_003DztJCl_0024mM_003D.GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, Layers, parentMaterial);
			if (material?.Texture != null)
			{
				_0023_003DzLiyRmi7DQ0fx(material?.Name);
				return;
			}
		}
		base.RenderContext.SetTextureLength(0f);
	}

	private void _0023_003Dz1cy2xxzUYyS3rl30Bw_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesWire _0023_003DzJxsQW2k8xtCB = (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		bool _0023_003DzAYcbN5Y_003D = false;
		Stack<BlockReference> parents = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = _0023_003DzhkWmjEBIvoue(_0023_003DzCBM7XJK4_5H_0024); i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003DztJCl_0024mM_003D.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode) && _0023_003DzXUtUiHEMz_0024a5(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, ref _0023_003DztJCl_0024mM_003D, ref _0023_003DzAYcbN5Y_003D, _0023_003Dz1cy2xxzUYyS3rl30Bw_003D_003D) && _0023_003Dz93R3M8noap87(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E: false) && !_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003DzIyZshL4CGo8KJOTfZQ_003D_003D(_0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003DzH64tBc6U9aeYWvpkOFVxPG0_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003DzR45REbGtVacFfA93fA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D);
				base.RenderContext.SetClippable(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable);
				_0023_003DzCBM7XJK4_5H_0024.drawFastTransparencyEntityCallBack(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D, (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes);
			}
		}
		base.RenderContext.SetTextureLength(0f);
		base.RenderContext.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	internal virtual void _0023_003DzEqBQ2waUAbQ7(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D, ref bool _0023_003DzAYcbN5Y_003D)
	{
	}

	private static void _0023_003DzycEvByhSyCb91SxUpPVThupo_0024awi(Entity _0023_003DztJCl_0024mM_003D, out Color _0023_003DzgHSXAeA_003D, out Color _0023_003DzakC65tE_003D)
	{
		switch (_0023_003DztJCl_0024mM_003D.HaloMode)
		{
		case haloType.None:
			_0023_003DzgHSXAeA_003D = RenderContextBase.selectionWithoutHaloColor;
			_0023_003DzakC65tE_003D = RenderContextBase.selectionWithoutHaloColor;
			break;
		case haloType.Slim:
			_0023_003DzgHSXAeA_003D = RenderContextBase.selectionWithHaloColor;
			_0023_003DzakC65tE_003D = RenderContextBase.selectionWithHaloBackColor;
			break;
		case haloType.Thick:
			_0023_003DzgHSXAeA_003D = RenderContextBase.selectionWithThickHaloColor;
			_0023_003DzakC65tE_003D = RenderContextBase.selectionWithThickHaloBackColor;
			break;
		default:
			_0023_003DzgHSXAeA_003D = RenderContextBase.selectionWithoutHaloColor;
			_0023_003DzakC65tE_003D = RenderContextBase.selectionWithoutHaloColor;
			break;
		}
	}

	private bool _0023_003Dz93R3M8noap87(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzAYcbN5Y_003D, Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzgiBiywzBnB2E)
	{
		Color color = _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, edge: false, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers);
		string materialName = _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.MaterialName;
		bool _0023_003DzHZUy6FI2Z5vX = color.A != byte.MaxValue || (!string.IsNullOrEmpty(materialName) && _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D[_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.MaterialName].IsTransparent());
		_0023_003Dz3K9P2qVNDagdSsl0lDQZuJ0_003D(_0023_003DztJCl_0024mM_003D, ref _0023_003DzHZUy6FI2Z5vX);
		_0023_003DzEqBQ2waUAbQ7(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, ref _0023_003DzAYcbN5Y_003D);
		if (_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers)
		{
			_0023_003DzHZUy6FI2Z5vX &= !NestedEntity.IsGrayMinFr(_0023_003DztJCl_0024mM_003D);
		}
		if (_0023_003DzCBM7XJK4_5H_0024.isDrawingWithHalo)
		{
			_0023_003DzHZUy6FI2Z5vX = _0023_003DzHZUy6FI2Z5vX && !_0023_003DzAYcbN5Y_003D;
		}
		if (_0023_003DzgiBiywzBnB2E)
		{
			if (_0023_003DzHZUy6FI2Z5vX && (!AccurateTransparency || _0023_003DztJCl_0024mM_003D.IsPolygonal()))
			{
				_0023_003DzCBM7XJK4_5H_0024.transparencyFound = true;
				return false;
			}
		}
		else if (!_0023_003DzHZUy6FI2Z5vX)
		{
			return false;
		}
		Color _0023_003DzgHSXAeA_003D = ((_0023_003DzAYcbN5Y_003D && _0023_003DztJCl_0024mM_003D.IsPolygonal()) ? _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor : _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor);
		if (_0023_003DzAYcbN5Y_003D && _0023_003DzCBM7XJK4_5H_0024.isDrawingWithHalo)
		{
			_0023_003DzycEvByhSyCb91SxUpPVThupo_0024awi(_0023_003DztJCl_0024mM_003D, out _0023_003DzgHSXAeA_003D, out var _);
		}
		shaderPrimitiveType primitiveTypeForFlat = _0023_003DztJCl_0024mM_003D.GetPrimitiveTypeForFlat(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.ShaderParams.PrimitiveType = primitiveTypeForFlat;
		_0023_003DzCBM7XJK4_5H_0024.SetStatesFunc(primitiveTypeForFlat, _0023_003DzCBM7XJK4_5H_0024.DrawParams, color, materialName, _0023_003DzgHSXAeA_003D, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D.SelectedInternal());
		return true;
	}

	private void _0023_003DzaS1WXEc73ayPfJTWfdhYVKk_003D(shaderPrimitiveType _0023_003DzYSl0dl4_003D, DrawParams _0023_003DzyrRdBi78wMnR, Color _0023_003Dzhpb8QNg_003D, string _0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003DzXluM0iA_003D, bool _0023_003Dz5eJIEOtJbD5X)
	{
		switch (_0023_003DzYSl0dl4_003D)
		{
		case shaderPrimitiveType.Polygon:
			_0023_003DzmNZD0Zs_003D.SetState(_0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D);
			_0023_003DzUIOYewgG_00242gY(_0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: false, _0023_003DzXluM0iA_003D);
			break;
		case shaderPrimitiveType.Line:
			_0023_003DzmNZD0Zs_003D.EnableThickLines();
			break;
		case shaderPrimitiveType.Point:
			_0023_003DzmNZD0Zs_003D.EnableThickPoints();
			break;
		}
		_0023_003DzX0fuIZ0_003D(_0023_003DzyrRdBi78wMnR.Viewport.Camera, _0023_003DzXluM0iA_003D);
		_0023_003DzdFImu0JhVact(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
	}

	private void _0023_003DzMcSxMItosfoZ6tgvPSq8UEalN0lh(shaderPrimitiveType _0023_003DzYSl0dl4_003D, DrawParams _0023_003DzyrRdBi78wMnR, Color _0023_003Dzhpb8QNg_003D, string _0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003DzXluM0iA_003D, bool _0023_003Dz5eJIEOtJbD5X)
	{
		switch (_0023_003DzYSl0dl4_003D)
		{
		case shaderPrimitiveType.Polygon:
			_0023_003DzmNZD0Zs_003D.SetState(_0023_003DzDpdyjYCbgWVZq111tWKKuQLBj86MIoUwBg_003D_003D);
			_0023_003DzUIOYewgG_00242gY(_0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: false, _0023_003DzXluM0iA_003D);
			break;
		case shaderPrimitiveType.Line:
			_0023_003DzmNZD0Zs_003D.EnableThickLines();
			break;
		case shaderPrimitiveType.Point:
			_0023_003DzmNZD0Zs_003D.EnableThickPoints();
			break;
		}
		_0023_003DzmRSovObl_VKYUFtVkA_003D_003D(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
	}

	private void _0023_003DzUIOYewgG_00242gY(string _0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, bool _0023_003DzXluM0iA_003D)
	{
		if (!(string.IsNullOrEmpty(_0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D) || _0023_003DzXluM0iA_003D))
		{
			Material material = _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D[_0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D];
			if (material.TextureImage != null)
			{
				material.SetTexture(_0023_003DzmNZD0Zs_003D);
				if (material.AlphaMapImage != null)
				{
					_0023_003DzmNZD0Zs_003D.SetShader(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D ? shaderType.Texture2DWithAlphaMap : shaderType.Texture2DNoLightsWithAlphaMap);
				}
				else
				{
					_0023_003DzmNZD0Zs_003D.SetShader(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D ? shaderType.Texture2D : shaderType.Texture2DNoLights);
				}
				return;
			}
		}
		_0023_003DzmNZD0Zs_003D.SetShader(_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D ? shaderType.Standard : shaderType.NoLights);
	}

	private void _0023_003DzOr9rWHwxwTcnkR_Kxg7_Hlc_003D(shaderPrimitiveType _0023_003DzYSl0dl4_003D, DrawParams _0023_003DzyrRdBi78wMnR, Color _0023_003Dzhpb8QNg_003D, string _0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003DzXluM0iA_003D, bool _0023_003Dz5eJIEOtJbD5X)
	{
		switch (_0023_003DzYSl0dl4_003D)
		{
		case shaderPrimitiveType.Polygon:
			if (_0023_003DzXluM0iA_003D && !_0023_003Dz5eJIEOtJbD5X && !_0023_003DzyrRdBi78wMnR.IsDrawingForHalo)
			{
				_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
				_0023_003DzX0fuIZ0_003D(_0023_003DzyrRdBi78wMnR.Viewport.Camera, _0023_003DzXluM0iA_003D);
				_0023_003DzdFImu0JhVact(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
			}
			else
			{
				_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
				_0023_003Dz1MiTpno8NdtRbdtdGdxgjkaE4CL1(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
				_0023_003DzUIOYewgG_00242gY(_0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: true, _0023_003DzXluM0iA_003D);
			}
			break;
		case shaderPrimitiveType.Line:
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
			_0023_003DzmNZD0Zs_003D.EnableThickLines();
			_0023_003DzX0fuIZ0_003D(_0023_003DzyrRdBi78wMnR.Viewport.Camera, _0023_003DzXluM0iA_003D);
			_0023_003DzdFImu0JhVact(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
			break;
		case shaderPrimitiveType.Point:
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
			_0023_003DzmNZD0Zs_003D.EnableThickPoints();
			_0023_003DzX0fuIZ0_003D(_0023_003DzyrRdBi78wMnR.Viewport.Camera, _0023_003DzXluM0iA_003D);
			_0023_003DzdFImu0JhVact(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
			break;
		}
	}

	private void _0023_003DzSAdUYiiIyUKXbmiyAJcLb2qAouwG(shaderPrimitiveType _0023_003DzYSl0dl4_003D, DrawParams _0023_003DzyrRdBi78wMnR, Color _0023_003Dzhpb8QNg_003D, string _0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003DzXluM0iA_003D, bool _0023_003Dz5eJIEOtJbD5X)
	{
		switch (_0023_003DzYSl0dl4_003D)
		{
		case shaderPrimitiveType.Polygon:
			if (_0023_003DzXluM0iA_003D && !_0023_003Dz5eJIEOtJbD5X)
			{
				_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
				_0023_003DzmRSovObl_VKYUFtVkA_003D_003D(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
			}
			else
			{
				_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
				_0023_003DzPXj2bn4NVjeaUVk9CNomNwCcZmk2(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
				_0023_003DzUIOYewgG_00242gY(_0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: true, _0023_003DzXluM0iA_003D);
				_0023_003DzmNZD0Zs_003D.SetMaterialBackDiffuse(_0023_003Dzhpb8QNg_003D);
			}
			break;
		case shaderPrimitiveType.Line:
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
			_0023_003DzmNZD0Zs_003D.EnableThickLines();
			_0023_003DzmRSovObl_VKYUFtVkA_003D_003D(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
			break;
		case shaderPrimitiveType.Point:
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
			_0023_003DzmNZD0Zs_003D.EnableThickPoints();
			_0023_003DzmRSovObl_VKYUFtVkA_003D_003D(_0023_003DzyrRdBi78wMnR, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzXluM0iA_003D);
			break;
		}
	}

	private void _0023_003DzDFzjieontV2E(DrawParams _0023_003DzyrRdBi78wMnR, Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzXluM0iA_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		if (_0023_003DzXluM0iA_003D)
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawSelected(_0023_003DzyrRdBi78wMnR);
		}
		else
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).Draw(_0023_003DzyrRdBi78wMnR);
		}
	}

	private void _0023_003DzblKf805HyZNJDvsEtprPtGK39D_4(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesWire _0023_003DzJxsQW2k8xtCB = (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		bool _0023_003DzAYcbN5Y_003D = false;
		Stack<BlockReference> parents = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003DztJCl_0024mM_003D.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode) && _0023_003DzXUtUiHEMz_0024a5(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, ref _0023_003DztJCl_0024mM_003D, ref _0023_003DzAYcbN5Y_003D, _0023_003DzblKf805HyZNJDvsEtprPtGK39D_4))
			{
				Color color = _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, edge: false, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers);
				if (color.A != byte.MaxValue)
				{
					_0023_003DzTdt_002451lXETWi(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D, color);
				}
			}
		}
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003DzzThxH8goktC_0024()
	{
		_0023_003DzmNZD0Zs_003D.EndDrawBufferedLines();
	}

	private void _0023_003DzTdt_002451lXETWi(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzAYcbN5Y_003D, Entity _0023_003DztJCl_0024mM_003D, Color _0023_003Dzhpb8QNg_003D)
	{
		Color _0023_003DzXgBARg0tIZEa = _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor;
		if (_0023_003DzAYcbN5Y_003D && _0023_003DztJCl_0024mM_003D.IsPolygonal())
		{
			_0023_003DzXgBARg0tIZEa = _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor;
		}
		_0023_003DzX0fuIZ0_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Viewport.Camera, _0023_003DzAYcbN5Y_003D);
		_0023_003DzdFImu0JhVact(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003Dzhpb8QNg_003D, _0023_003DzXgBARg0tIZEa, _0023_003DzAYcbN5Y_003D);
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.ShaderParams.PrimitiveType = _0023_003DztJCl_0024mM_003D.GetPrimitiveTypeForWireframe(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		rasterizerStateType? rasterizerStateType2 = null;
		switch (_0023_003DzCBM7XJK4_5H_0024.DrawParams.ShaderParams.PrimitiveType)
		{
		case shaderPrimitiveType.Polygon:
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
			rasterizerStateType2 = _0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonLine_NoCullFace);
			break;
		case shaderPrimitiveType.Line:
			_0023_003DzmNZD0Zs_003D.EnableThickLinesInPolygonLineMode();
			break;
		case shaderPrimitiveType.Point:
			_0023_003DzmNZD0Zs_003D.EnableThickPointsInPolygonLineMode();
			break;
		}
		if (_0023_003DzAYcbN5Y_003D || _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray)
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawWireframeSelected(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		}
		else
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawWireframe(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		}
		if (rasterizerStateType2.HasValue)
		{
			_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType2.Value);
		}
	}

	private bool _0023_003DzXUtUiHEMz_0024a5(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, GfxAttributesWire _0023_003DzJxsQW2k8xtCB, ref Entity _0023_003DztJCl_0024mM_003D, ref bool _0023_003DzAYcbN5Y_003D, WorkspaceDrawCallback _0023_003Dzas5BPeRUABdU)
	{
		_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		if (!_0023_003DzHNOZ8WqUfnmzEWXwjw_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzJxsQW2k8xtCB, _0023_003Dzas5BPeRUABdU))
		{
			return false;
		}
		DrawParams drawParams = _0023_003DzCBM7XJK4_5H_0024.DrawParams;
		bool flag = _0023_003DzlT_tPDs_003D(drawParams.ParentSelected, drawParams, _0023_003DztJCl_0024mM_003D);
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
		drawParams.Selected = (_0023_003DzAYcbN5Y_003D = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, drawParams));
		drawParams.Clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(drawParams.ParentClippable, drawParams, _0023_003DztJCl_0024mM_003D);
		GfxAttributesWire gfxAttributesWire = (GfxAttributesWire)drawParams.Attributes;
		_0023_003DztJCl_0024mM_003D.SetLineWeight(_0023_003DzmNZD0Zs_003D, (_0023_003DzAYcbN5Y_003D ? (Selection.LineWeightScaleFactor * gfxAttributesWire.LineWeight) : gfxAttributesWire.LineWeight) * drawParams.LineWeightFactor);
		return true;
	}

	protected internal virtual Color ComputeNonCurrentEntityColor(Entity entity, Color color, bool edge = false, bool forBlending = false)
	{
		if (forBlending)
		{
			return Color.FromArgb(edge ? 50 : 40, _0023_003DzipBYly6zFKAp()._0023_003DzKcjcHP9Ku7D9);
		}
		if (entity is ICurve || entity is PointCloud || entity is FastPointCloud || entity is Table)
		{
			return Color.FromArgb(color.A / 4, Color.Black);
		}
		return Color.FromArgb(color.A / 20, Color.Black);
	}

	private bool _0023_003DzjBNf4IXodMmT1UhJbA_003D_003D(Entity _0023_003DztJCl_0024mM_003D, DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		bool _0023_003DzHZUy6FI2Z5vX = _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, edge: false, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers).A != byte.MaxValue;
		_0023_003Dz3K9P2qVNDagdSsl0lDQZuJ0_003D(_0023_003DztJCl_0024mM_003D, ref _0023_003DzHZUy6FI2Z5vX);
		if (_0023_003DzHZUy6FI2Z5vX && (!_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers || !NestedEntity.IsGrayMinFr(_0023_003DztJCl_0024mM_003D)))
		{
			if (AccurateTransparency)
			{
				return _0023_003DztJCl_0024mM_003D.IsPolygonal();
			}
			return true;
		}
		return false;
	}

	private void _0023_003Dzic8sgWeDlpB66wdSTUkxPVg_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesWire _0023_003DzJxsQW2k8xtCB = (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(_0023_003DztJCl_0024mM_003D, _0023_003Dzbq3BJR0_003D) || !_0023_003Dz6H_0024cDQF6vc1bUxHN9eUXKoc_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzJxsQW2k8xtCB, _0023_003Dzic8sgWeDlpB66wdSTUkxPVg_003D))
			{
				continue;
			}
			if (_0023_003DzjBNf4IXodMmT1UhJbA_003D_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003DzCBM7XJK4_5H_0024.transparencyFound = true;
				continue;
			}
			_0023_003DzJRZmUFqZ8YbIMHkbPw_003D_003D(_0023_003DzCBM7XJK4_5H_0024, out var _0023_003DzAYcbN5Y_003D, ref _0023_003DztJCl_0024mM_003D);
			if (!_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003DzIyZshL4CGo8KJOTfZQ_003D_003D(_0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024) && _0023_003DzRp8J_0024Kh3iThTKr5IZQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzAYcbN5Y_003D))
			{
				base.RenderContext.SetClippable(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable);
				if (_0023_003DzAYcbN5Y_003D || _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray)
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawSelected(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
				else
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).Draw(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
			}
		}
		base.RenderContext.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003DzJRZmUFqZ8YbIMHkbPw_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, out bool _0023_003DzAYcbN5Y_003D, ref Entity _0023_003DztJCl_0024mM_003D)
	{
		DrawParams drawParams = _0023_003DzCBM7XJK4_5H_0024.DrawParams;
		bool flag = _0023_003DzlT_tPDs_003D(drawParams.ParentSelected, drawParams, _0023_003DztJCl_0024mM_003D);
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
		drawParams.Selected = (_0023_003DzAYcbN5Y_003D = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, drawParams));
		drawParams.Clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(drawParams.ParentClippable, drawParams, _0023_003DztJCl_0024mM_003D);
	}

	private bool _0023_003DzRp8J_0024Kh3iThTKr5IZQ_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzAYcbN5Y_003D)
	{
		DrawParams drawParams = _0023_003DzCBM7XJK4_5H_0024.DrawParams;
		GfxAttributesWire gfxAttributesWire = (GfxAttributesWire)drawParams.Attributes;
		_0023_003DztJCl_0024mM_003D.SetLineWeight(_0023_003DzmNZD0Zs_003D, (_0023_003DzAYcbN5Y_003D ? (Selection.LineWeightScaleFactor * gfxAttributesWire.LineWeight) : gfxAttributesWire.LineWeight) * drawParams.LineWeightFactor);
		Color color = gfxAttributesWire.GetColor(drawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, edge: false, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers);
		if (UtilityEx._0023_003Dzh_0024PIPDO0q5pY(_0023_003DztJCl_0024mM_003D))
		{
			drawParams.ShaderParams.Lighting = true;
			drawParams.ShaderParams.PrimitiveType = shaderPrimitiveType.Polygon;
		}
		else
		{
			drawParams.ShaderParams.Lighting = false;
			drawParams.ShaderParams.PrimitiveType = _0023_003DztJCl_0024mM_003D.GetPrimitiveTypeForWireframe(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		}
		if (!AccurateTransparency)
		{
			_0023_003DzrjxntBLLusq9GU9zGm9D38k_003D(drawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, _0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor);
		}
		else
		{
			_0023_003DzaVcwbLFYvSR1g5_0024XIA_003D_003D(null, drawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, null, _0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor, _0023_003DztJCl_0024mM_003D.SelectedInternal());
		}
		((IEntityInternal)_0023_003DztJCl_0024mM_003D).SetShader(drawParams);
		return true;
	}

	private void _0023_003DzcQ4Fko_GXDMmjq9Hiyxy9wQ_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesWire _0023_003DzJxsQW2k8xtCB = (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> parents = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (!_0023_003DztJCl_0024mM_003D.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode) || !_0023_003Dz6H_0024cDQF6vc1bUxHN9eUXKoc_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzJxsQW2k8xtCB, _0023_003DzcQ4Fko_GXDMmjq9Hiyxy9wQ_003D) || !_0023_003DzjBNf4IXodMmT1UhJbA_003D_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) || _0023_003DzH64tBc6U9aeYWvpkOFVxPG0_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024))
			{
				continue;
			}
			if (_0023_003DzCBM7XJK4_5H_0024.drawZBufferOnly)
			{
				((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawSelected(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				continue;
			}
			_0023_003DzJRZmUFqZ8YbIMHkbPw_003D_003D(_0023_003DzCBM7XJK4_5H_0024, out var _0023_003DzAYcbN5Y_003D, ref _0023_003DztJCl_0024mM_003D);
			if (_0023_003DzRp8J_0024Kh3iThTKr5IZQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzAYcbN5Y_003D))
			{
				_0023_003DzCBM7XJK4_5H_0024.drawFastTransparencyEntityCallBack(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D, (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes);
			}
		}
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003Dz7WwPpjSmZ2e0(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawFast(_0023_003Dzt5jpbHs_003D);
	}

	private void _0023_003Dz3EA82HCByTTb(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		_0023_003DztJCl_0024mM_003D.DrawFlatFast(_0023_003Dzt5jpbHs_003D);
	}

	private void _0023_003Dzxo00_0024E4HyGkclKe3bg_003D_003D(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawFlat(_0023_003Dzt5jpbHs_003D);
	}

	private void _0023_003DzMdGmwljERbDdJtw75A_003D_003D(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		((IEntityInternal)_0023_003DztJCl_0024mM_003D).Draw(_0023_003Dzt5jpbHs_003D);
	}

	private void _0023_003DzLiyRmi7DQ0fx(string _0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D)
	{
		if (string.IsNullOrEmpty(_0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D))
		{
			base.RenderContext.SetTextureLength(0f);
			return;
		}
		Material material = _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D[_0023_003Dzeqpb_cijhX53Tbh3jw_003D_003D];
		float textureLength = (float)(Utility.GetLinearUnitsConversionFactor(material.LinearUnits, Blocks.RootBlock.Units) * (double)material.TextureLength);
		base.RenderContext.SetTextureLength(textureLength);
	}

	private void _0023_003Dzx0_dIgGavykSE30soQ_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesRendered _0023_003DzJxsQW2k8xtCB = (GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		bool _0023_003DzAYcbN5Y_003D = false;
		bool _0023_003DzUH2MOzxMv_0024gC = false;
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003Dzgm6hLRyrhaOnRZrPZQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, _0023_003Dzx0_dIgGavykSE30soQ_003D_003D, ref _0023_003DztJCl_0024mM_003D, ref _0023_003DzAYcbN5Y_003D, ref _0023_003DzUH2MOzxMv_0024gC))
			{
				if (_0023_003DzUH2MOzxMv_0024gC)
				{
					break;
				}
			}
			else if (!_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003DzIyZshL4CGo8KJOTfZQ_003D_003D(_0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003DzR45REbGtVacFfA93fA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D);
				base.RenderContext.SetClippable(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable);
				if (_0023_003DzAYcbN5Y_003D || _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray)
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawSelected(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
				else
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).Render((RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
			}
		}
		base.RenderContext.SetTextureLength(0f);
		base.RenderContext.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003Dz0hyE9qB8Z7NvBCoV5g_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesRendered _0023_003DzJxsQW2k8xtCB = (GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		bool _0023_003DzAYcbN5Y_003D = false;
		bool _0023_003DzUH2MOzxMv_0024gC = false;
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003Dzgm6hLRyrhaOnRZrPZQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, _0023_003Dz0hyE9qB8Z7NvBCoV5g_003D_003D, ref _0023_003DztJCl_0024mM_003D, ref _0023_003DzAYcbN5Y_003D, ref _0023_003DzUH2MOzxMv_0024gC))
			{
				if (_0023_003DzUH2MOzxMv_0024gC)
				{
					break;
				}
			}
			else if (_0023_003DztJCl_0024mM_003D.IsPolygonal() && !_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003DzR45REbGtVacFfA93fA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D);
				base.RenderContext.SetClippable(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable);
				if (_0023_003DzAYcbN5Y_003D || _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray)
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawSelected(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
				else
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).Render((RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
			}
		}
		base.RenderContext.SetTextureLength(0f);
		base.RenderContext.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private bool _0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(Entity _0023_003DztJCl_0024mM_003D, DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		bool flag = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers && (_0023_003DzCBM7XJK4_5H_0024.drawFrozen ^ NestedEntity.IsGrayMinFr(_0023_003DztJCl_0024mM_003D));
		_0023_003DzCBM7XJK4_5H_0024.frozenFound |= flag;
		return flag;
	}

	private bool _0023_003DzH64tBc6U9aeYWvpkOFVxPG0_003D(Entity _0023_003DztJCl_0024mM_003D, DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.drawZBufferOnly)
		{
			if (_0023_003Dz_EkZHS2QnMod || !_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray)
			{
				if (!_0023_003DzYtqGTMwg_0024Ufr8epgUBxoDPPd_0024XV2)
				{
					return !_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private bool _0023_003DzIyZshL4CGo8KJOTfZQ_003D_003D(bool _0023_003DzXluM0iA_003D, DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		IViewportInternal viewportInternal = _0023_003DzCBM7XJK4_5H_0024.DrawParams.viewportInternal;
		if (!_0023_003DzXluM0iA_003D)
		{
			if (!_0023_003DzCBM7XJK4_5H_0024.isDrawingStaticWithHalo || !_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(viewportInternal))
			{
				if (_0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo)
				{
					return _0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(viewportInternal);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private bool _0023_003DzknJ6JlHEVfVbc_95XI8EIqY_003D(bool _0023_003DzXluM0iA_003D, DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		IViewportInternal viewportInternal = _0023_003DzCBM7XJK4_5H_0024.DrawParams.viewportInternal;
		if (!_0023_003DzXluM0iA_003D || _0023_003Dz28QCun7pbbWH == selectionFilterType.Entity)
		{
			if (!_0023_003DzCBM7XJK4_5H_0024.isDrawingStaticWithHalo || !_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(viewportInternal))
			{
				if (_0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo)
				{
					return _0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(viewportInternal);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private bool _0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(Entity _0023_003DztJCl_0024mM_003D, DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		return _0023_003DztJCl_0024mM_003D.IsSketchEntity() ^ _0023_003DzCBM7XJK4_5H_0024.isDrawingSketchEntities;
	}

	private bool _0023_003Dzgm6hLRyrhaOnRZrPZQ_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, GfxAttributesRendered _0023_003DzJxsQW2k8xtCB, WorkspaceDrawCallback _0023_003DzWMccOMDjvyjQ, ref Entity _0023_003DztJCl_0024mM_003D, ref bool _0023_003DzAYcbN5Y_003D, ref bool _0023_003DzUH2MOzxMv_0024gC)
	{
		if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams)))
		{
			_0023_003DzUH2MOzxMv_0024gC = false;
			return true;
		}
		if (!_0023_003Dz4ZPGnnedSdbU(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, _0023_003DztJCl_0024mM_003D, _0023_003DzWMccOMDjvyjQ, out var _0023_003DzJ1rVW_0024wqwTV, out var _0023_003DzeTmvM9c_003D))
		{
			return true;
		}
		if (_0023_003DzeTmvM9c_003D && (!AccurateTransparency || _0023_003DztJCl_0024mM_003D.IsPolygonal()))
		{
			_0023_003DzCBM7XJK4_5H_0024.transparencyFound = true;
			return true;
		}
		if (!_0023_003DzRjlKLZH6lyf9(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJ1rVW_0024wqwTV, out _0023_003DzAYcbN5Y_003D, ref _0023_003DztJCl_0024mM_003D))
		{
			return true;
		}
		((IEntityInternal)_0023_003DztJCl_0024mM_003D).SetShader(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		return false;
	}

	private static void _0023_003Dz3K9P2qVNDagdSsl0lDQZuJ0_003D(Entity _0023_003DztJCl_0024mM_003D, ref bool _0023_003DzHZUy6FI2Z5vX)
	{
		if (((_0023_003DztJCl_0024mM_003D is NestedEntity nestedEntity) ? nestedEntity.entity : _0023_003DztJCl_0024mM_003D) is Picture picture)
		{
			_0023_003DzHZUy6FI2Z5vX = picture.HasTransparentImage;
		}
	}

	private bool _0023_003Dz4ZPGnnedSdbU(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, GfxAttributesRendered _0023_003DzJxsQW2k8xtCB, Entity _0023_003DztJCl_0024mM_003D, WorkspaceDrawCallback _0023_003Dzas5BPeRUABdU, out bool _0023_003DzJ1rVW_0024wqwTV8, out bool _0023_003DzeTmvM9c_003D)
	{
		_0023_003DzJ1rVW_0024wqwTV8 = false;
		_0023_003DzeTmvM9c_003D = false;
		if (_0023_003DzQxvqEU4Hk7eQ && !_0023_003DztJCl_0024mM_003D.IsPolygonal() && !(_0023_003DztJCl_0024mM_003D is BlockReference))
		{
			return false;
		}
		if (!_0023_003Dz6H_0024cDQF6vc1bUxHN9eUXKoc_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzJxsQW2k8xtCB, _0023_003Dzas5BPeRUABdU))
		{
			return false;
		}
		_0023_003DzJ1rVW_0024wqwTV8 = UtilityEx._0023_003Dzh_0024PIPDO0q5pY(_0023_003DztJCl_0024mM_003D);
		_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		GfxAttributesRendered gfxAttributesRendered = (GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes;
		if (_0023_003DzJ1rVW_0024wqwTV8)
		{
			_0023_003DzeTmvM9c_003D = gfxAttributesRendered.IsMaterialTransparent(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, _0023_003Dzxpbv4lQ_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers);
		}
		else
		{
			_0023_003DzeTmvM9c_003D = gfxAttributesRendered.IsColorTransparent(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers);
		}
		_0023_003Dz3K9P2qVNDagdSsl0lDQZuJ0_003D(_0023_003DztJCl_0024mM_003D, ref _0023_003DzeTmvM9c_003D);
		if (_0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers)
		{
			_0023_003DzeTmvM9c_003D &= !NestedEntity.IsGrayMinFr(_0023_003DztJCl_0024mM_003D);
		}
		return true;
	}

	private void _0023_003Dze99ar8BiiBSo(DrawParams _0023_003DzyrRdBi78wMnR, Entity _0023_003DztJCl_0024mM_003D)
	{
		_0023_003DzyrRdBi78wMnR.ForceGray = _0023_003DzyrRdBi78wMnR.ParentForceGray || NestedEntity.IsGrayMinFr(_0023_003DztJCl_0024mM_003D) || (!(_0023_003DztJCl_0024mM_003D is NestedEntity) && !_0023_003Dzlrl6ZJY_003D(_0023_003DzyrRdBi78wMnR, _0023_003DztJCl_0024mM_003D));
	}

	private bool _0023_003DzRjlKLZH6lyf9(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzJ1rVW_0024wqwTV8, out bool _0023_003DzAYcbN5Y_003D, ref Entity _0023_003DztJCl_0024mM_003D)
	{
		DrawParams drawParams = _0023_003DzCBM7XJK4_5H_0024.DrawParams;
		bool flag = _0023_003DzlT_tPDs_003D(drawParams.ParentSelected, drawParams, _0023_003DztJCl_0024mM_003D);
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
		drawParams.Selected = (_0023_003DzAYcbN5Y_003D = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, drawParams));
		drawParams.Clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(drawParams.ParentClippable, drawParams, _0023_003DztJCl_0024mM_003D);
		GfxAttributesRendered gfxAttributesRendered = (GfxAttributesRendered)drawParams.Attributes;
		_0023_003DztJCl_0024mM_003D.SetLineWeight(_0023_003DzmNZD0Zs_003D, (_0023_003DzAYcbN5Y_003D ? (Selection.LineWeightScaleFactor * gfxAttributesRendered.LineWeight) : gfxAttributesRendered.LineWeight) * drawParams.LineWeightFactor);
		if (_0023_003DzJ1rVW_0024wqwTV8)
		{
			if (drawParams.ShaderParams != null)
			{
				drawParams.ShaderParams.PrimitiveType = shaderPrimitiveType.Polygon;
			}
			RenderParams renderParams = (RenderParams)drawParams;
			renderParams.hqrData.Material = gfxAttributesRendered.GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, _0023_003Dzxpbv4lQ_003D, drawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers);
			if (AccurateTransparency)
			{
				_0023_003DzK537gtu1HwLL(renderParams, _0023_003DztJCl_0024mM_003D.entityNature, _0023_003DztJCl_0024mM_003D.Color, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D.SelectedInternal());
			}
			else
			{
				_0023_003Dzrt21_0024hjpckJPRHbyxQ_003D_003D(renderParams, _0023_003DztJCl_0024mM_003D.entityNature, _0023_003DztJCl_0024mM_003D.Color, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D.SelectedInternal());
			}
		}
		else
		{
			drawParams.ShaderParams.PrepareForWireframe();
			drawParams.ShaderParams.PrimitiveType = _0023_003DztJCl_0024mM_003D.GetPrimitiveTypeForWireframe(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
			_0023_003DzaVcwbLFYvSR1g5_0024XIA_003D_003D(null, drawParams, _0023_003DztJCl_0024mM_003D.entityNature, gfxAttributesRendered.GetColor(drawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, edge: false, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers), null, _0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor, _0023_003DztJCl_0024mM_003D.SelectedInternal());
		}
		return true;
	}

	private void _0023_003DzYkVaBhK6AhTIiv_0024zmQ_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		GfxAttributesRendered _0023_003DzJxsQW2k8xtCB = (GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		bool _0023_003DzUH2MOzxMv_0024gC = false;
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003DzPc__00241eoVaxWYZ5K8Aw_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, _0023_003DzYkVaBhK6AhTIiv_0024zmQ_003D_003D, ref _0023_003DztJCl_0024mM_003D, ref _0023_003DzUH2MOzxMv_0024gC))
			{
				if (_0023_003DzUH2MOzxMv_0024gC)
				{
					break;
				}
			}
			else if (!_0023_003DzH64tBc6U9aeYWvpkOFVxPG0_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzCBM7XJK4_5H_0024))
			{
				_0023_003DzR45REbGtVacFfA93fA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D);
				base.RenderContext.SetClippable(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable);
				_0023_003DzCBM7XJK4_5H_0024.drawFastTransparencyEntityCallBack((RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D, (GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes);
			}
		}
		base.RenderContext.SetTextureLength(0f);
		base.RenderContext.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003DznVTEqZ9bwrkx(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		if (_0023_003DztJCl_0024mM_003D.IsPolygonal())
		{
			_0023_003Dzv_0024JKc7d2lEkq(_0023_003Dzt5jpbHs_003D, _0023_003DztJCl_0024mM_003D, _0023_003Dz8z7C7Cw_003D);
		}
	}

	private void _0023_003Dzv_0024JKc7d2lEkq(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		if (_0023_003Dzt5jpbHs_003D.ForceGray)
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawFast(_0023_003Dzt5jpbHs_003D);
		}
		else
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).RenderFast((RenderParams)_0023_003Dzt5jpbHs_003D);
		}
	}

	private void _0023_003DzyxKJZtJUEmPmHWHDhRvh0ns_003D(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		if (_0023_003DztJCl_0024mM_003D.IsPolygonal())
		{
			_0023_003Dz2vn_0024H5Gwb6Nmx_0024py4w_003D_003D(_0023_003Dzt5jpbHs_003D, _0023_003DztJCl_0024mM_003D, _0023_003Dz8z7C7Cw_003D);
		}
	}

	private void _0023_003Dz2vn_0024H5Gwb6Nmx_0024py4w_003D_003D(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		if (_0023_003Dzt5jpbHs_003D.ForceGray)
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).Draw(_0023_003Dzt5jpbHs_003D);
		}
		else
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).Render((RenderParams)_0023_003Dzt5jpbHs_003D);
		}
	}

	private bool _0023_003DzPc__00241eoVaxWYZ5K8Aw_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, GfxAttributesRendered _0023_003DzJxsQW2k8xtCB, WorkspaceDrawCallback _0023_003DzWMccOMDjvyjQ, ref Entity _0023_003DztJCl_0024mM_003D, ref bool _0023_003DzUH2MOzxMv_0024gC)
	{
		if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(_0023_003DztJCl_0024mM_003D, _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams)))
		{
			_0023_003DzUH2MOzxMv_0024gC = false;
			return true;
		}
		if (!_0023_003Dz4ZPGnnedSdbU(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJxsQW2k8xtCB, _0023_003DztJCl_0024mM_003D, _0023_003DzWMccOMDjvyjQ, out var _0023_003DzJ1rVW_0024wqwTV, out var _0023_003DzeTmvM9c_003D))
		{
			return true;
		}
		if (!_0023_003DzeTmvM9c_003D)
		{
			return true;
		}
		if (_0023_003DzCBM7XJK4_5H_0024.drawZBufferOnly)
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawSelected(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
			return true;
		}
		if (!_0023_003DzRjlKLZH6lyf9(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzJ1rVW_0024wqwTV, out var _, ref _0023_003DztJCl_0024mM_003D))
		{
			return true;
		}
		((IEntityInternal)_0023_003DztJCl_0024mM_003D).SetShader(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		return false;
	}

	private void _0023_003DzisAcDtuSRYrAV8R7Az_qYJk_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesHDLWiresSingleColor _0023_003DzJxsQW2k8xtCB = (GfxAttributesHDLWiresSingleColor)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> parents = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003DztJCl_0024mM_003D.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode) && _0023_003Dz6H_0024cDQF6vc1bUxHN9eUXKoc_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzJxsQW2k8xtCB, _0023_003DzisAcDtuSRYrAV8R7Az_qYJk_003D) && _0023_003Dzsx2bAtxKnLb6(_0023_003DzCBM7XJK4_5H_0024, out var _, ref _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E: false))
			{
				_0023_003DzR45REbGtVacFfA93fA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D);
				base.RenderContext.SetClippable(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable);
				if (_0023_003DzCBM7XJK4_5H_0024.drawZBufferOnly)
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawSelected(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
				_0023_003DzCBM7XJK4_5H_0024.drawFastTransparencyEntityCallBack((RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D, (GfxAttributesWire)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes);
			}
		}
		base.RenderContext.SetTextureLength(0f);
		base.RenderContext.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003DzpdqKdfyxDQUXvopvQQ_003D_003D(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		if (_0023_003Dzddm_0024rF6S_0024y27.ColorMethod == hiddenLinesColorMethodType.EntityMaterial && !_0023_003Dzt5jpbHs_003D.ForceGray)
		{
			_0023_003DztJCl_0024mM_003D.DrawHiddenLinesMaterialFast((RenderParams)_0023_003Dzt5jpbHs_003D);
		}
		else
		{
			_0023_003DztJCl_0024mM_003D.DrawHiddenLinesFast(_0023_003Dzt5jpbHs_003D);
		}
	}

	private void _0023_003Dzs_JW4tuF3Va1cQDSbGuydX8_003D(DrawParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D)
	{
		if (_0023_003Dzddm_0024rF6S_0024y27.ColorMethod == hiddenLinesColorMethodType.EntityMaterial && !_0023_003Dzt5jpbHs_003D.ForceGray)
		{
			_0023_003DztJCl_0024mM_003D.DrawHiddenLinesMaterial((RenderParams)_0023_003Dzt5jpbHs_003D);
		}
		else
		{
			((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawHiddenLines(_0023_003Dzt5jpbHs_003D);
		}
	}

	private bool _0023_003Dzsx2bAtxKnLb6(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, out bool _0023_003DzAYcbN5Y_003D, ref Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzgiBiywzBnB2E)
	{
		_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		return _0023_003DzCBM7XJK4_5H_0024.SetAttributesFunc(_0023_003DzCBM7XJK4_5H_0024, out _0023_003DzAYcbN5Y_003D, ref _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E);
	}

	private bool _0023_003Dz_0024pd0AW3PZ0vWYhDfDPTnnFUhjQgYRi1brkDqCzQ_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, out bool _0023_003DzAYcbN5Y_003D, ref Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzgiBiywzBnB2E)
	{
		bool flag = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Selected = (_0023_003DzAYcbN5Y_003D = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, _0023_003DzCBM7XJK4_5H_0024.DrawParams));
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		if (_0023_003DztJCl_0024mM_003D.GetPrimitiveTypeForHiddenLines(_0023_003DzCBM7XJK4_5H_0024.DrawParams) == shaderPrimitiveType.Polygon)
		{
			if (_0023_003DzAYcbN5Y_003D)
			{
				GfxAttributesHDLWiresSingleColor gfxAttributesHDLWiresSingleColor = (GfxAttributesHDLWiresSingleColor)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes;
				Color mySelectionColor = ((_0023_003DzAYcbN5Y_003D && _0023_003DztJCl_0024mM_003D.IsPolygonal()) ? _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor : _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor);
				Color color = Color.Empty;
				Material material = null;
				if (_0023_003DzCBM7XJK4_5H_0024.UseMaterial)
				{
					material = gfxAttributesHDLWiresSingleColor.GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, _0023_003Dzxpbv4lQ_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
				}
				else
				{
					color = gfxAttributesHDLWiresSingleColor.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
				}
				bool flag2 = _0023_003DztJCl_0024mM_003D.SelectedInternal();
				if (flag2)
				{
					_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
					_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Standard);
					_0023_003DzCBM7XJK4_5H_0024.SetMatrixAndColorForPolygons(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, material, _0023_003DzAYcbN5Y_003D, mySelectionColor, flag2);
				}
				else
				{
					_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
					_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
					_0023_003DzCBM7XJK4_5H_0024.SetMatrixAndColorForWire(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, material, _0023_003DzAYcbN5Y_003D, mySelectionColor, flag2);
				}
				return true;
			}
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
		}
		else
		{
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		}
		return _0023_003DzVJz9IYLkDSUBljWpNA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E);
	}

	private bool _0023_003Dz4shdnmn2ECfg(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, out bool _0023_003DzAYcbN5Y_003D, ref Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzgiBiywzBnB2E)
	{
		bool flag = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Selected = (_0023_003DzAYcbN5Y_003D = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, _0023_003DzCBM7XJK4_5H_0024.DrawParams));
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		return _0023_003DzVJz9IYLkDSUBljWpNA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzAYcbN5Y_003D, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E);
	}

	private bool _0023_003DzVJz9IYLkDSUBljWpNA_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzAYcbN5Y_003D, Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzgiBiywzBnB2E)
	{
		GfxAttributesHDLWiresSingleColor gfxAttributesHDLWiresSingleColor = (GfxAttributesHDLWiresSingleColor)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes;
		shaderPrimitiveType primitiveTypeForHiddenLines = _0023_003DztJCl_0024mM_003D.GetPrimitiveTypeForHiddenLines(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		Material material = null;
		if (_0023_003DzCBM7XJK4_5H_0024.UseMaterial && primitiveTypeForHiddenLines == shaderPrimitiveType.Polygon)
		{
			material = gfxAttributesHDLWiresSingleColor.GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, _0023_003Dzxpbv4lQ_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
		}
		Color color = Color.White;
		switch (primitiveTypeForHiddenLines)
		{
		case shaderPrimitiveType.Polygon:
			if (_0023_003DztJCl_0024mM_003D is Text || (_0023_003DztJCl_0024mM_003D is NestedEntity nestedEntity && nestedEntity.entity is Text))
			{
				if (_0023_003DzCBM7XJK4_5H_0024.UseMaterial)
				{
					material = gfxAttributesHDLWiresSingleColor.GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, _0023_003Dzxpbv4lQ_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
				}
				color = gfxAttributesHDLWiresSingleColor.GetWireColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
				if (!_0023_003DzqvyDK3oibMcN(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E, color, material))
				{
					return false;
				}
				_0023_003DzmNZD0Zs_003D.SetShader(_0023_003Dz_0024m0wHyJzdT4E);
				_0023_003DzCBM7XJK4_5H_0024.SetMatrixAndColorForText(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, material, _0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor, _0023_003DztJCl_0024mM_003D.SelectedInternal());
			}
			else
			{
				if (!_0023_003DzCBM7XJK4_5H_0024.UseMaterial)
				{
					color = gfxAttributesHDLWiresSingleColor.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D, edge: false, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers);
				}
				if (!_0023_003DzqvyDK3oibMcN(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E, color, material))
				{
					return false;
				}
				_0023_003DzmNZD0Zs_003D.SetShader(_0023_003DzxYKjPsMqweAzSfdh_0024g_003D_003D);
				_0023_003DzCBM7XJK4_5H_0024.SetMatrixAndColorForPolygons(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, material, _0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor, _0023_003DztJCl_0024mM_003D.SelectedInternal());
			}
			break;
		case shaderPrimitiveType.Line:
			color = gfxAttributesHDLWiresSingleColor.GetWireColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
			if (!_0023_003DzqvyDK3oibMcN(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E, color, material))
			{
				return false;
			}
			_0023_003DzmNZD0Zs_003D.EnableThickLines();
			_0023_003DzCBM7XJK4_5H_0024.SetMatrixAndColorForWire(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, null, _0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor, _0023_003DztJCl_0024mM_003D.SelectedInternal());
			break;
		case shaderPrimitiveType.Point:
			color = gfxAttributesHDLWiresSingleColor.GetWireColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, _0023_003DztJCl_0024mM_003D);
			if (!_0023_003DzqvyDK3oibMcN(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E, color, material))
			{
				return false;
			}
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			_0023_003DzmNZD0Zs_003D.EnableThickPoints();
			_0023_003DzCBM7XJK4_5H_0024.SetMatrixAndColorForWire(_0023_003DzCBM7XJK4_5H_0024.ShaderParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D.entityNature, color, null, _0023_003DzAYcbN5Y_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor, _0023_003DztJCl_0024mM_003D.SelectedInternal());
			break;
		}
		return true;
	}

	private bool _0023_003DzqvyDK3oibMcN(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzgiBiywzBnB2E, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D)
	{
		bool _0023_003DzHZUy6FI2Z5vX = _0023_003Dzhpb8QNg_003D.A != byte.MaxValue || (_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D?.IsTransparent() ?? false);
		_0023_003Dz3K9P2qVNDagdSsl0lDQZuJ0_003D(_0023_003DztJCl_0024mM_003D, ref _0023_003DzHZUy6FI2Z5vX);
		if (_0023_003DzgiBiywzBnB2E)
		{
			if (_0023_003DzHZUy6FI2Z5vX && (!AccurateTransparency || _0023_003DztJCl_0024mM_003D.IsPolygonal()))
			{
				_0023_003DzCBM7XJK4_5H_0024.transparencyFound = true;
				return false;
			}
		}
		else if (!_0023_003DzHZUy6FI2Z5vX)
		{
			return false;
		}
		return true;
	}

	private void _0023_003DzXjYhqZfCe1_0024fD9iLuw_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		GfxAttributesHDLWiresSingleColor _0023_003DzJxsQW2k8xtCB = (GfxAttributesHDLWiresSingleColor)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity _0023_003DztJCl_0024mM_003D = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(_0023_003DztJCl_0024mM_003D, _0023_003Dzbq3BJR0_003D) && _0023_003Dz6H_0024cDQF6vc1bUxHN9eUXKoc_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D, _0023_003DzJxsQW2k8xtCB, _0023_003DzXjYhqZfCe1_0024fD9iLuw_003D_003D) && _0023_003Dzsx2bAtxKnLb6(_0023_003DzCBM7XJK4_5H_0024, out var _0023_003DzAYcbN5Y_003D, ref _0023_003DztJCl_0024mM_003D, _0023_003DzgiBiywzBnB2E: true))
			{
				_0023_003DzR45REbGtVacFfA93fA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DztJCl_0024mM_003D);
				base.RenderContext.SetClippable(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Clippable);
				if (!_0023_003DzAYcbN5Y_003D && _0023_003Dzddm_0024rF6S_0024y27.ColorMethod == hiddenLinesColorMethodType.EntityMaterial)
				{
					_0023_003DztJCl_0024mM_003D.DrawHiddenLinesMaterial((RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
				else
				{
					((IEntityInternal)_0023_003DztJCl_0024mM_003D).DrawHiddenLines(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
			}
		}
		base.RenderContext.SetTextureLength(0f);
		base.RenderContext.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003Dz3lQVIQlV9uTseWasaoHaHLs_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributes other = (GfxAttributes)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, _0023_003Dzbq3BJR0_003D))
			{
				continue;
			}
			_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Assign(other);
			_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Propagate(entity, Layers[entity.LayerName], _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
			if (entity is BlockReference)
			{
				((BlockReference)entity).Draw(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz3lQVIQlV9uTseWasaoHaHLs_003D);
				continue;
			}
			_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
			bool _0023_003DzXluM0iA_003D = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
			bool flag = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(_0023_003DzXluM0iA_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams);
			flag &= !_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.viewportInternal);
			_0023_003DzCBM7XJK4_5H_0024.DrawParams.Selected = flag;
			if (!_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(entity, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(entity, _0023_003DzCBM7XJK4_5H_0024))
			{
				bool clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				_0023_003DzmNZD0Zs_003D.SetClippable(clippable);
				entity.SetLineWeightForSilhouettes((DrawSilhouettesParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				_0023_003DzX0fuIZ0_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Viewport.Camera, flag);
				_0023_003DzdFImu0JhVact(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, entity, edge: true, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers), _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor, flag);
				((IEntityInternal)entity).DrawSilhouettes((DrawSilhouettesParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams);
			}
		}
		_0023_003DzmNZD0Zs_003D.SetClippable(clippable: true);
	}

	private void _0023_003DzAjlbXONkieO7(DrawSceneParams _0023_003DzyrRdBi78wMnR, Color _0023_003DzXgBARg0tIZEa)
	{
		Viewport viewport = (Viewport)_0023_003DzyrRdBi78wMnR.Viewport;
		RenderContextBase renderContextBase = viewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D;
		_0023_003DzX0fuIZ0_003D(viewport.Camera, _0023_003DzAYcbN5Y_003D: false);
		renderContextBase.SetMaterialFrontAmbient(_0023_003Dzxpbv4lQ_003D.Ambient);
		renderContextBase.SetMaterialBackAmbient(_0023_003Dzxpbv4lQ_003D.Ambient);
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		if (_0023_003DzSGUVLSk_003D == null)
		{
			ProcessSemiTransparent();
		}
		_0023_003DzSGUVLSk_003D._0023_003DzYC1I5dS2UycK = _0023_003DzmNZD0Zs_003D.SetColorMaterial;
		_0023_003DzSGUVLSk_003D._0023_003DzFQ3s9o5wcGs6 = _0023_003DzmNZD0Zs_003D.SetMaterialBackDiffuse;
		bool[] _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D = null;
		bool flag = false;
		ShaderParameters shaderParams = _0023_003DzyrRdBi78wMnR.ShaderParams;
		if (_0023_003DzyrRdBi78wMnR.ShaderParams == null)
		{
			_0023_003DzyrRdBi78wMnR.ShaderParams = (_0023_003DzyrRdBi78wMnR.PlanarReflections ? _0023_003DzGhVyc3iwfBwt(_0023_003DzyrRdBi78wMnR) : _0023_003DzdfzPZ4BvPfHu(_0023_003DzyrRdBi78wMnR));
		}
		_0023_003DzyrRdBi78wMnR.ShaderParams.PrepareForTransparency(_0023_003DzyrRdBi78wMnR.RenderContext, _0023_003DznKkOfo8_003D.EnvironmentMapping ? _0023_003DziuvwBNA4duWb : null);
		if (_0023_003DzyrRdBi78wMnR.DoShadows)
		{
			flag = true;
			_0023_003DzmNZD0Zs_003D.EnableShadowMap(0);
		}
		switch (viewport._0023_003DzK_00241ezHQJ9Z3c)
		{
		case displayType.HiddenLines:
			if (!_0023_003Dzddm_0024rF6S_0024y27.Lighting && _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
			{
				_0023_003Dz1RFiLgbb5KRyzDELNfeiMStOjV3yQfahtD5pkr4_003D(_0023_003DzyrRdBi78wMnR);
				break;
			}
			_0023_003DzmNZD0Zs_003D.SetLighting(_0023_003Dzddm_0024rF6S_0024y27.Lighting);
			if (_0023_003DzyrRdBi78wMnR.ShaderParams != null)
			{
				_0023_003DzyrRdBi78wMnR.ShaderParams.Lighting = _0023_003Dzddm_0024rF6S_0024y27.Lighting;
				if (!_0023_003Dzddm_0024rF6S_0024y27.Lighting)
				{
					_0023_003DzyrRdBi78wMnR.ShaderParams.Multicolor = false;
					_0023_003DzyrRdBi78wMnR.ShaderParams.MulticolorNoLightsWithNormals = true;
				}
			}
			break;
		case displayType.Flat:
			if (_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
			{
				_0023_003Dzk9HwUQ4uSzdtWt6BErpx4Zw_003D(_0023_003DzyrRdBi78wMnR.ShaderParams, ref _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D);
				_0023_003Dz1RFiLgbb5KRyzDELNfeiMStOjV3yQfahtD5pkr4_003D(_0023_003DzyrRdBi78wMnR);
				break;
			}
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			if (_0023_003DzyrRdBi78wMnR.ShaderParams != null)
			{
				_0023_003DzyrRdBi78wMnR.ShaderParams.Lighting = false;
				_0023_003DzyrRdBi78wMnR.ShaderParams.Multicolor = false;
				_0023_003DzyrRdBi78wMnR.ShaderParams.MulticolorNoLightsWithNormals = true;
			}
			break;
		default:
			_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
			break;
		}
		shaderType _0023_003DzLesGjMPSCmqS = _0023_003DzmNZD0Zs_003D.CurrentShader;
		shaderType _0023_003DzOBG2vyU9oroe = _0023_003DzmNZD0Zs_003D.CurrentShader;
		if (_0023_003DzyrRdBi78wMnR.ShaderParams != null)
		{
			_0023_003DzLesGjMPSCmqS = _0023_003DzmNZD0Zs_003D.GetShaderAndEnable(_0023_003DzyrRdBi78wMnR.ShaderParams);
			_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(_0023_003DzyrRdBi78wMnR.ShaderParams);
			_0023_003DzyrRdBi78wMnR.ShaderParams.Texture2D = true;
			_0023_003DzOBG2vyU9oroe = _0023_003DzmNZD0Zs_003D.GetShaderAndEnable(_0023_003DzyrRdBi78wMnR.ShaderParams);
			_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(_0023_003DzyrRdBi78wMnR.ShaderParams);
		}
		_0023_003DzSGUVLSk_003D._0023_003DzrHqKleI_003D = Color.Empty;
		_0023_003DzSGUVLSk_003D._0023_003DzUI5wrJBKgelQ(_0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D.Color);
		_0023_003DzSGUVLSk_003D._0023_003DzaLEt5Rf0aeF7 = 0f;
		IEnvironment environment = null;
		if (viewport._0023_003DzK_00241ezHQJ9Z3c == displayType.Rendered && _0023_003DznKkOfo8_003D.EnvironmentMapping)
		{
			environment = _0023_003DziuvwBNA4duWb;
		}
		_0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003Dzw0ZEq8VA92eQEu7CGA_003D_003D _0023_003DzMZP5PYMvleKrqG2qng_003D_003D = ((viewport.Camera.ProjectionMode != projectionType.Orthographic) ? ((_0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003Dzw0ZEq8VA92eQEu7CGA_003D_003D)((_0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003DzdpbpOGub7X4i _0023_003DzOrtNSQnn48wG, Point3D _0023_003DzhEjPeMs_003D, Vector3D _0023_003Dzv_0024Gzcjk_003D) => (float)((double)_0023_003DzOrtNSQnn48wG._0023_003DzKNWoe_A_003D * _0023_003DzhEjPeMs_003D.X + (double)_0023_003DzOrtNSQnn48wG._0023_003Dzg6W6oCU_003D * _0023_003DzhEjPeMs_003D.Y + (double)_0023_003DzOrtNSQnn48wG._0023_003DzbhVhT6o_003D * _0023_003DzhEjPeMs_003D.Z + (double)_0023_003DzOrtNSQnn48wG._0023_003DzoLX1o88_003D) > 0f)) : ((_0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003Dzw0ZEq8VA92eQEu7CGA_003D_003D)((_0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003DzdpbpOGub7X4i _0023_003DzOrtNSQnn48wG, Point3D _0023_003DzhEjPeMs_003D, Vector3D _0023_003Dzv_0024Gzcjk_003D) => _0023_003Dzv_0024Gzcjk_003D.X * (double)_0023_003DzOrtNSQnn48wG._0023_003DzKNWoe_A_003D + _0023_003Dzv_0024Gzcjk_003D.Y * (double)_0023_003DzOrtNSQnn48wG._0023_003Dzg6W6oCU_003D + _0023_003Dzv_0024Gzcjk_003D.Z * (double)_0023_003DzOrtNSQnn48wG._0023_003DzbhVhT6o_003D > 0.0)));
		_0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D._0023_003DzdGHIIU4_003D _0023_003DzVKJlFNI_003D = null;
		switch (viewport._0023_003DzK_00241ezHQJ9Z3c)
		{
		case displayType.Shaded:
			_0023_003DzVKJlFNI_003D = _0023_003DzpW717vDE_JTBaH23pw_003D_003D;
			break;
		case displayType.Rendered:
			_0023_003DzVKJlFNI_003D = _0023_003Dzc6W_0024QvlNhBTR;
			break;
		case displayType.HiddenLines:
			_0023_003DzVKJlFNI_003D = ((_0023_003Dzddm_0024rF6S_0024y27.ColorMethod != hiddenLinesColorMethodType.EntityMaterial) ? _0023_003DzpW717vDE_JTBaH23pw_003D_003D : _0023_003Dzc6W_0024QvlNhBTR);
			break;
		case displayType.Flat:
			_0023_003DzVKJlFNI_003D = ((_0023_003Dzl8PjArmAqC_m.ColorMethod != flatColorMethodType.EntityMaterial) ? _0023_003DzpW717vDE_JTBaH23pw_003D_003D : _0023_003Dzc6W_0024QvlNhBTR);
			break;
		}
		renderContextBase.UpdateConstantBufferPerObject();
		_0023_003DzSGUVLSk_003D._0023_003DzOBG2vyU9oroe = _0023_003DzOBG2vyU9oroe;
		_0023_003DzSGUVLSk_003D._0023_003DzLesGjMPSCmqS = _0023_003DzLesGjMPSCmqS;
		_0023_003DzSGUVLSk_003D._0023_003DzgcK4Z11iT1YA = _0023_003DzyrRdBi78wMnR.ShaderParams;
		_0023_003DzSGUVLSk_003D._0023_003DzBSXUhiQp_yRY(viewport, _0023_003DzVKJlFNI_003D, _0023_003DzMZP5PYMvleKrqG2qng_003D_003D, environment, _0023_003DzXgBARg0tIZEa, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D);
		renderContextBase.DrawCurrentBuffer();
		_0023_003DzmNZD0Zs_003D.EndDrawMulticolorWithAmbientAndDiffuse(_0023_003DzyrRdBi78wMnR.ShaderParams);
		if (_0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D != null)
		{
			_0023_003DzWsXtT_0024NYYJ_0024or5QLaQ_003D_003D(_0023_003DzyrRdBi78wMnR.ShaderParams, _0023_003Dzg_icjwuaogiVhg__0024CQ_003D_003D);
		}
		_0023_003DzmNZD0Zs_003D.CloseTexture();
		if (environment != null)
		{
			_0023_003DzmNZD0Zs_003D.CloseEnvironment();
		}
		if (flag)
		{
			_0023_003DzmNZD0Zs_003D.DisableShadowMap();
		}
		_0023_003DzyrRdBi78wMnR.ShaderParams = shaderParams;
		renderContextBase.ColorMaterialMode = colorMaterialType.Disabled;
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
	}

	private void _0023_003Dz1RFiLgbb5KRyzDELNfeiMStOjV3yQfahtD5pkr4_003D(DrawSceneParams _0023_003DzyrRdBi78wMnR)
	{
		_0023_003DzmNZD0Zs_003D.BeginDrawMulticolorWithAmbientAndDiffuse(_0023_003DzyrRdBi78wMnR.ShaderParams);
		if (_0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			_0023_003DzSGUVLSk_003D._0023_003DzYC1I5dS2UycK = _0023_003DzmNZD0Zs_003D.SetMaterialFrontAmbientAndDiffuse;
		}
		else
		{
			_0023_003DzSGUVLSk_003D._0023_003DzYC1I5dS2UycK = _0023_003DzSGUVLSk_003D._0023_003DzKa9500mDdetrlJphXQ_003D_003D;
		}
		_0023_003DzSGUVLSk_003D._0023_003DzFQ3s9o5wcGs6 = _0023_003DzmNZD0Zs_003D.SetMaterialBackAmbientAndDiffuse;
		if (_0023_003DzyrRdBi78wMnR.ShaderParams != null && !_0023_003DzmNZD0Zs_003D.IsDirect3D)
		{
			_0023_003DzyrRdBi78wMnR.ShaderParams.Multicolor = false;
		}
	}

	private void _0023_003Dz3GItZNaPOXNt(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributes _0023_003DzJxsQW2k8xtCB = (GfxAttributes)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, _0023_003Dzbq3BJR0_003D) && _0023_003DzKzpx8cdmzcbK3YQybQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, entity, _0023_003DzJxsQW2k8xtCB, _0023_003Dz3GItZNaPOXNt))
			{
				_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				bool flag = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				bool flag2 = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, _0023_003DzCBM7XJK4_5H_0024.DrawParams);
				_0023_003DzCBM7XJK4_5H_0024.DrawParams.Selected = flag2;
				_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
				if (!_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(entity, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(entity, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003DzknJ6JlHEVfVbc_95XI8EIqY_003D(flag2, _0023_003DzCBM7XJK4_5H_0024))
				{
					entity.SetLineWeightForEdges(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
					bool clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
					_0023_003DzmNZD0Zs_003D.SetClippable(clippable);
					_0023_003DzX0fuIZ0_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Viewport.Camera, flag2);
					_0023_003DzdFImu0JhVact(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, entity, edge: true, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers), _0023_003DzCBM7XJK4_5H_0024.DrawParams.SelectionColor, flag2);
					((IEntityInternal)entity).DrawEdges(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
			}
		}
		_0023_003DzmNZD0Zs_003D.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003DzQqPMQa5z5fgt(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributes _0023_003DzJxsQW2k8xtCB = (GfxAttributes)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = _0023_003DzhkWmjEBIvoue(_0023_003DzCBM7XJK4_5H_0024); i < count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, _0023_003Dzbq3BJR0_003D) && _0023_003Dz1SsHHjj6TVAG(entity) && _0023_003DzKzpx8cdmzcbK3YQybQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, entity, _0023_003DzJxsQW2k8xtCB, _0023_003DzQqPMQa5z5fgt))
			{
				bool num = _0023_003DzCBM7XJK4_5H_0024.Workspace is Drawing && _0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Count > 0 && _0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Peek() is VectorView;
				_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				bool flag = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				bool flag2 = !num && _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, _0023_003DzCBM7XJK4_5H_0024.DrawParams);
				_0023_003DzCBM7XJK4_5H_0024.DrawParams.Selected = flag2;
				_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
				if (!_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(entity, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(entity, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003DzknJ6JlHEVfVbc_95XI8EIqY_003D(flag2, _0023_003DzCBM7XJK4_5H_0024))
				{
					entity.SetLineWeightForEdges(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
					bool clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
					_0023_003DzmNZD0Zs_003D.SetClippable(clippable);
					_0023_003DzX0fuIZ0_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Viewport.Camera, flag2);
					_0023_003DzMp6Z0a_0024RUMaP(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, entity, edge: true, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers), flag2);
					((IEntityInternal)entity).DrawEdges(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
			}
		}
		_0023_003DzmNZD0Zs_003D.SetClippable(clippable: true);
		_0023_003DzzThxH8goktC_0024();
	}

	private void _0023_003DzPTXMkk7FTOSwGAbibQ_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributes _0023_003DzJxsQW2k8xtCB = (GfxAttributes)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, _0023_003Dzbq3BJR0_003D) || !_0023_003Dz1SsHHjj6TVAG(entity) || !_0023_003DzKzpx8cdmzcbK3YQybQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, entity, _0023_003DzJxsQW2k8xtCB, _0023_003DzPTXMkk7FTOSwGAbibQ_003D_003D))
			{
				continue;
			}
			_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
			bool _0023_003DzXluM0iA_003D = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
			bool flag = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(_0023_003DzXluM0iA_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams);
			flag &= !_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.viewportInternal);
			_0023_003DzX0fuIZ0_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Viewport.Camera, flag);
			_0023_003DzdFImu0JhVact(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, entity, edge: true, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers), _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor, flag);
			if (!_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(entity, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(entity, _0023_003DzCBM7XJK4_5H_0024))
			{
				bool clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				_0023_003DzmNZD0Zs_003D.SetClippable(clippable);
				if (entity.IsPolygonal() || entity is Text)
				{
					_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
					_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonLine_NoCullFace);
				}
				else
				{
					_0023_003DzmNZD0Zs_003D.EnableThickLinesInPolygonLineMode();
				}
				((IEntityInternal)entity).DrawIsocurves(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
			}
		}
		_0023_003DzmNZD0Zs_003D.SetClippable(clippable: true);
	}

	private void _0023_003Dz7TcPg458oBkO4TfvnkmsQmo_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributes _0023_003DzJxsQW2k8xtCB = (GfxAttributes)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		int count = _0023_003DzCBM7XJK4_5H_0024.entList.Count;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = _0023_003DzhkWmjEBIvoue(_0023_003DzCBM7XJK4_5H_0024); i < count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, _0023_003Dzbq3BJR0_003D) || !_0023_003Dz1SsHHjj6TVAG(entity) || !_0023_003DzKzpx8cdmzcbK3YQybQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, entity, _0023_003DzJxsQW2k8xtCB, _0023_003Dz7TcPg458oBkO4TfvnkmsQmo_003D))
			{
				continue;
			}
			_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
			bool _0023_003DzXluM0iA_003D = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
			bool flag = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(_0023_003DzXluM0iA_003D, _0023_003DzCBM7XJK4_5H_0024.DrawParams);
			flag &= !_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.viewportInternal);
			_0023_003DzX0fuIZ0_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Viewport.Camera, flag);
			_0023_003DzdFImu0JhVact(_0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.GetColor(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray, this, entity, edge: true, _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers), _0023_003DzCBM7XJK4_5H_0024.DrawParams.WireSelectionColor, flag);
			if (!_0023_003Dzr9icccpgYpGuBDB4Wj2DoAspD7wf(entity, _0023_003DzCBM7XJK4_5H_0024) && !_0023_003Dz8tOPldJQHXeDDV_0024oSw_003D_003D(entity, _0023_003DzCBM7XJK4_5H_0024))
			{
				bool clippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				_0023_003DzmNZD0Zs_003D.SetClippable(clippable);
				if (entity.IsPolygonal() || entity is Text)
				{
					_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
					_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonLine_NoCullFace);
				}
				else
				{
					_0023_003DzmNZD0Zs_003D.EnableThickLinesInPolygonLineMode();
				}
				entity.DrawIsocurvesForFlat(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
			}
		}
		_0023_003DzmNZD0Zs_003D.SetClippable(clippable: true);
	}

	private static int _0023_003DzhkWmjEBIvoue(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.Workspace is Drawing && _0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Count > 0 && _0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Peek() is VectorView vectorView)
		{
			return vectorView.hdlCount;
		}
		return 0;
	}

	private static int _0023_003DzafjhIPuMEU_KHEZdIg_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.Workspace is Drawing && _0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Count > 0 && _0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Peek() is VectorView { inScope: false } vectorView)
		{
			return vectorView.hdlCount;
		}
		return 0;
	}

	private bool _0023_003DzKzpx8cdmzcbK3YQybQ_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D, GfxAttributes _0023_003DzJxsQW2k8xtCB, WorkspaceDrawCallback _0023_003Dzas5BPeRUABdU)
	{
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Assign(_0023_003DzJxsQW2k8xtCB);
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Propagate(_0023_003DztJCl_0024mM_003D, Layers[_0023_003DztJCl_0024mM_003D.LayerName], _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
		if (_0023_003DztJCl_0024mM_003D is BlockReference)
		{
			((BlockReference)_0023_003DztJCl_0024mM_003D).Draw(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzas5BPeRUABdU);
			return false;
		}
		return true;
	}

	private bool _0023_003DzHNOZ8WqUfnmzEWXwjw_003D_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D, GfxAttributes _0023_003DzJxsQW2k8xtCB, WorkspaceDrawCallback _0023_003Dzas5BPeRUABdU)
	{
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Assign(_0023_003DzJxsQW2k8xtCB);
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Propagate(_0023_003DztJCl_0024mM_003D, Layers[_0023_003DztJCl_0024mM_003D.LayerName], _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
		if (_0023_003DztJCl_0024mM_003D is BlockReference)
		{
			((BlockReference)_0023_003DztJCl_0024mM_003D).Draw(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzas5BPeRUABdU);
			return false;
		}
		return true;
	}

	private bool _0023_003Dz6H_0024cDQF6vc1bUxHN9eUXKoc_003D(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D, GfxAttributesWire _0023_003DzJxsQW2k8xtCB, WorkspaceDrawCallback _0023_003Dzas5BPeRUABdU)
	{
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Assign(_0023_003DzJxsQW2k8xtCB);
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Propagate(_0023_003DztJCl_0024mM_003D, Layers[_0023_003DztJCl_0024mM_003D.LayerName], _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
		if (_0023_003DztJCl_0024mM_003D is BlockReference)
		{
			((BlockReference)_0023_003DztJCl_0024mM_003D).Draw(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzas5BPeRUABdU);
			return false;
		}
		return true;
	}

	private void _0023_003DzX0fuIZ0_003D(Camera _0023_003DzZ_0024IejP0R_0024_Cw, bool _0023_003DzAYcbN5Y_003D)
	{
		_0023_003DzZ_0024IejP0R_0024_Cw.SetProjectionMatrixType(_0023_003DzAYcbN5Y_003D ? Camera.projectionMatrixType.Selected : Camera.projectionMatrixType.Standard);
	}

	private void _0023_003Dz1MiTpno8NdtRbdtdGdxgjkaE4CL1(DrawParams _0023_003Dzt5jpbHs_003D, Color _0023_003Dzhpb8QNg_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003DzXluM0iA_003D)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		_0023_003Dzt5jpbHs_003D.RenderContext.SetMaterialFrontAmbient(_0023_003DzXluM0iA_003D ? _0023_003DzXgBARg0tIZEa : _0023_003Dzhpb8QNg_003D);
		if (_0023_003DzXluM0iA_003D)
		{
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = _0023_003DzXgBARg0tIZEa;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientNotSelected;
		}
	}

	private void _0023_003DzPXj2bn4NVjeaUVk9CNomNwCcZmk2(DrawParams _0023_003Dzt5jpbHs_003D, Color _0023_003Dzhpb8QNg_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003DzXluM0iA_003D)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, _0023_003DzXgBARg0tIZEa) : _0023_003Dzhpb8QNg_003D);
		_0023_003Dzt5jpbHs_003D.RenderContext.SetMaterialFrontAmbientAndDiffuse(color);
		if (_0023_003DzXluM0iA_003D)
		{
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientDiffuse_ColorBackMaterialDiffuseNotSelected;
		}
	}

	private void _0023_003DzdFImu0JhVact(DrawParams _0023_003Dzt5jpbHs_003D, Color _0023_003Dzhpb8QNg_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003DzXluM0iA_003D)
	{
		_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(_0023_003DzXluM0iA_003D ? _0023_003DzXgBARg0tIZEa : _0023_003Dzhpb8QNg_003D);
		_0023_003Dzt5jpbHs_003D.Selected = _0023_003DzXluM0iA_003D;
		if (_0023_003DzXluM0iA_003D)
		{
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = _0023_003DzXgBARg0tIZEa;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Wireframe;
		}
	}

	private void _0023_003DzmRSovObl_VKYUFtVkA_003D_003D(DrawParams _0023_003Dzt5jpbHs_003D, Color _0023_003Dzhpb8QNg_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003DzXluM0iA_003D)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, _0023_003DzXgBARg0tIZEa) : _0023_003Dzhpb8QNg_003D);
		_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(color);
		if (_0023_003DzXluM0iA_003D)
		{
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Wireframe;
		}
	}

	private void _0023_003DzaVcwbLFYvSR1g5_0024XIA_003D_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		_0023_003DzmNZD0Zs_003D.SetColorShadedInternal(_0023_003Dz5iRcFgagQUUy, _0023_003DzXluM0iA_003D ? _0023_003DzXgBARg0tIZEa : _0023_003Dzhpb8QNg_003D, _0023_003DzXluM0iA_003D, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D);
		if (_0023_003DzXluM0iA_003D && _0023_003Dz5eJIEOtJbD5X)
		{
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, _0023_003DzXgBARg0tIZEa);
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Shaded;
		}
	}

	private void _0023_003DzrjxntBLLusq9GU9zGm9D38k_003D(DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003Dzhpb8QNg_003D.A, _0023_003DzXgBARg0tIZEa) : _0023_003Dzhpb8QNg_003D);
		if (_0023_003DzXluM0iA_003D)
		{
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003Dzhpb8QNg_003D;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Shaded;
		}
		_0023_003DzmNZD0Zs_003D.SetColorShadedInternal(_0023_003Dz5iRcFgagQUUy, color, _0023_003DzXluM0iA_003D, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D);
	}

	private void _0023_003DzgIRnQ_KZkLTC11x8uw_003D_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		if (_0023_003Dz5iRcFgagQUUy != entityNatureType.Polygon && _0023_003Dz5iRcFgagQUUy != entityNatureType.RichPolygon)
		{
			return;
		}
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
		if (_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D == null)
		{
			return;
		}
		if (_0023_003DzXluM0iA_003D)
		{
			Color diffuse = _0023_003Dzt5jpbHs_003D.SelectionMaterial.Diffuse;
			_0023_003Dzt5jpbHs_003D.SelectionMaterial.Diffuse = Color.FromArgb(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse.A, _0023_003DzXgBARg0tIZEa);
			_0023_003DzmNZD0Zs_003D.SetMaterial(_0023_003Dzt5jpbHs_003D.SelectionMaterial, _0023_003DzXluM0iA_003D, _0023_003Dzt5jpbHs_003D);
			_0023_003Dzt5jpbHs_003D.SelectionMaterial.Diffuse = diffuse;
			if (_0023_003Dz5eJIEOtJbD5X)
			{
				_0023_003Dzt5jpbHs_003D.InsideSelectionMaterial = _0023_003Dzt5jpbHs_003D.SelectionMaterial;
				_0023_003Dzt5jpbHs_003D.InsideMaterial = _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D;
				_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Rendered;
			}
		}
		else
		{
			if (_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.TextureImage != null)
			{
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Texture2D, _0023_003DzgcK4Z11iT1YA);
			}
			_0023_003DzmNZD0Zs_003D.SetMaterial(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, _0023_003DzXluM0iA_003D, _0023_003Dzt5jpbHs_003D);
		}
	}

	private void _0023_003Dzrt21_0024hjpckJPRHbyxQ_003D_003D(RenderParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, bool _0023_003DzXluM0iA_003D, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		if (_0023_003DzXluM0iA_003D)
		{
			Color diffuse = _0023_003Dzt5jpbHs_003D.SelectionMaterial.Diffuse;
			_0023_003Dzt5jpbHs_003D.SelectionMaterial.Diffuse = Color.FromArgb(_0023_003Dzt5jpbHs_003D.hqrData.Material.Diffuse.A, _0023_003Dzt5jpbHs_003D.SelectionMaterial.Diffuse);
			_0023_003Dzt5jpbHs_003D.RenderContext.SetColorRenderedInternal(_0023_003Dz5iRcFgagQUUy, _0023_003Dzt5jpbHs_003D.SelectionMaterial, _0023_003DzXluM0iA_003D, _0023_003Dzt5jpbHs_003D);
			if (_0023_003Dz5eJIEOtJbD5X)
			{
				_0023_003Dzt5jpbHs_003D.InsideSelectionMaterial = _0023_003Dzt5jpbHs_003D.SelectionMaterial.SoftClone();
				_0023_003Dzt5jpbHs_003D.InsideMaterial = _0023_003Dzt5jpbHs_003D.hqrData.Material;
				_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Rendered;
			}
			_0023_003Dzt5jpbHs_003D.SelectionMaterial.Diffuse = diffuse;
		}
		else
		{
			_0023_003Dzt5jpbHs_003D.RenderContext.SetColorRenderedInternal(_0023_003Dz5iRcFgagQUUy, _0023_003Dzt5jpbHs_003D.hqrData.Material, _0023_003DzXluM0iA_003D, _0023_003Dzt5jpbHs_003D);
		}
	}

	private void _0023_003DzK537gtu1HwLL(RenderParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, bool _0023_003DzXluM0iA_003D, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		Material material = (_0023_003DzXluM0iA_003D ? _0023_003Dzt5jpbHs_003D.SelectionMaterial : _0023_003Dzt5jpbHs_003D.hqrData.Material);
		if (_0023_003Dz5eJIEOtJbD5X)
		{
			_0023_003Dzt5jpbHs_003D.InsideSelectionMaterial = material;
			_0023_003Dzt5jpbHs_003D.InsideMaterial = _0023_003Dzt5jpbHs_003D.hqrData.Material;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Rendered;
		}
		_0023_003Dzt5jpbHs_003D.RenderContext.SetColorRenderedInternal(_0023_003Dz5iRcFgagQUUy, material, _0023_003DzXluM0iA_003D, _0023_003Dzt5jpbHs_003D);
	}

	private void _0023_003DzMp6Z0a_0024RUMaP(DrawParams _0023_003Dzt5jpbHs_003D, Color _0023_003DzprdlCI4ebqkL, bool _0023_003DzXluM0iA_003D)
	{
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(_0023_003DzXluM0iA_003D ? _0023_003Dzt5jpbHs_003D.WireSelectionColor : _0023_003DzprdlCI4ebqkL);
		_0023_003Dzt5jpbHs_003D.Selected = _0023_003DzXluM0iA_003D;
		if (_0023_003DzXluM0iA_003D)
		{
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = _0023_003Dzt5jpbHs_003D.WireSelectionColor;
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzprdlCI4ebqkL;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Wireframe;
		}
	}

	private void _0023_003DzocPHp9R8S4UZceQMIg_003D_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		if (!_0023_003DzXluM0iA_003D && _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.TextureImage != null)
		{
			_0023_003DzmNZD0Zs_003D.SetShader((_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.AlphaMapImage != null) ? shaderType.Texture2DNoLightsWithAlphaMap : shaderType.Texture2DNoLights, _0023_003DzgcK4Z11iT1YA);
			_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.SetTexture(_0023_003DzmNZD0Zs_003D);
		}
		Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse.A, _0023_003DzXgBARg0tIZEa) : _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse);
		if (_0023_003DzXluM0iA_003D && _0023_003Dz5eJIEOtJbD5X)
		{
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse;
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Wireframe;
		}
		_0023_003Dzt5jpbHs_003D.RenderContext.SetLighting(enable: false);
		_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(color);
	}

	private void _0023_003Dzul__0024y8U0lZCH84R6aUpMcAm_mZDzDSn2jQ_003D_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		if (!_0023_003DzXluM0iA_003D && _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.TextureImage != null)
		{
			_0023_003DzmNZD0Zs_003D.SetShader((_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.AlphaMapImage != null) ? shaderType.Texture2DWithAlphaMap : shaderType.Texture2D, _0023_003DzgcK4Z11iT1YA);
			_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.SetTexture(_0023_003DzmNZD0Zs_003D);
		}
		if (_0023_003DzXluM0iA_003D)
		{
			Color color = Color.FromArgb(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse.A, _0023_003DzXgBARg0tIZEa);
			if (_0023_003Dz5eJIEOtJbD5X)
			{
				_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse;
				_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
				_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientNotSelected;
			}
			_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(color);
		}
		else
		{
			_0023_003Dzt5jpbHs_003D.RenderContext.SetMaterialFrontAmbient(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse);
		}
	}

	private void _0023_003Dz6RP_FjC6g9P5zebyAUf9tjM1ALsaM02HoqhlzdE_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003Dzhpb8QNg_003D, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		if (!_0023_003DzXluM0iA_003D && _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.TextureImage != null)
		{
			_0023_003DzmNZD0Zs_003D.SetShader((_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.AlphaMapImage != null) ? shaderType.Texture2DWithAlphaMap : shaderType.Texture2D, _0023_003DzgcK4Z11iT1YA);
			_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.SetTexture(_0023_003DzmNZD0Zs_003D);
		}
		Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse.A, _0023_003DzXgBARg0tIZEa) : _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse);
		if (_0023_003DzXluM0iA_003D)
		{
			_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(color);
			if (_0023_003Dz5eJIEOtJbD5X)
			{
				_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
				_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D.Diffuse;
				_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientDiffuse_ColorBackMaterialDiffuseNotSelected;
			}
		}
		else
		{
			_0023_003Dzt5jpbHs_003D.RenderContext.SetMaterialFrontAmbientAndDiffuse(color);
			_0023_003Dzt5jpbHs_003D.RenderContext.SetMaterialBackDiffuse(color);
		}
	}

	private void _0023_003DzAszWjnpwwvmA7UlhuaDKRUBZAZE8NeOkIg_003D_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003DzprdlCI4ebqkL, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003DzprdlCI4ebqkL.A, _0023_003DzXgBARg0tIZEa) : _0023_003DzprdlCI4ebqkL);
		_0023_003DzmNZD0Zs_003D.SetMaterialFrontAmbient(color);
		if (_0023_003DzXluM0iA_003D && _0023_003Dz5eJIEOtJbD5X)
		{
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzprdlCI4ebqkL;
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientNotSelected;
		}
	}

	private void _0023_003DzMIYpoqsv0YH_0024pC4lcxO1P9XYwxC9Rpd7SQNbT_A_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003DzprdlCI4ebqkL, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003DzprdlCI4ebqkL.A, _0023_003DzXgBARg0tIZEa) : _0023_003DzprdlCI4ebqkL);
		if (_0023_003DzXluM0iA_003D)
		{
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(color);
			if (_0023_003Dz5eJIEOtJbD5X)
			{
				_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzprdlCI4ebqkL;
				_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
				_0023_003Dzt5jpbHs_003D.ColorMode = colorType.ColorWireFrameSelected_ColorFrontMaterialAmbientDiffuse_ColorBackMaterialDiffuseNotSelected;
			}
		}
		else
		{
			_0023_003DzmNZD0Zs_003D.SetMaterialFrontAmbientAndDiffuse(color);
			_0023_003DzmNZD0Zs_003D.SetMaterialBackDiffuse(color);
		}
	}

	private void _0023_003DzQUi8lQuSRV4fBZFsA9EOs94_003D(ShaderParameters _0023_003DzgcK4Z11iT1YA, DrawParams _0023_003Dzt5jpbHs_003D, entityNatureType _0023_003Dz5iRcFgagQUUy, Color _0023_003DzprdlCI4ebqkL, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D, bool _0023_003DzXluM0iA_003D, Color _0023_003DzXgBARg0tIZEa, bool _0023_003Dz5eJIEOtJbD5X)
	{
		_0023_003DzX0fuIZ0_003D(_0023_003Dzt5jpbHs_003D.Viewport.Camera, _0023_003DzXluM0iA_003D);
		Color color = (_0023_003DzXluM0iA_003D ? Color.FromArgb(_0023_003DzprdlCI4ebqkL.A, _0023_003DzXgBARg0tIZEa) : _0023_003DzprdlCI4ebqkL);
		_0023_003Dzt5jpbHs_003D.RenderContext.SetLighting(enable: false);
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(color);
		if (_0023_003DzXluM0iA_003D && _0023_003Dz5eJIEOtJbD5X)
		{
			_0023_003Dzt5jpbHs_003D.InsideColor = _0023_003DzprdlCI4ebqkL;
			_0023_003Dzt5jpbHs_003D.InsideSelectionColor = color;
			_0023_003Dzt5jpbHs_003D.ColorMode = colorType.Wireframe;
		}
	}

	internal static bool _0023_003DzLI3s2ivNhUmU(Entity _0023_003DztJCl_0024mM_003D, LayerKeyedCollection _0023_003DzjDdbnzc6miMJ, MaterialKeyedCollection _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D, Workspace _0023_003DzopDrLGk_003D)
	{
		return _0023_003DztJCl_0024mM_003D.GetMaterial(_0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D, _0023_003DzjDdbnzc6miMJ, _0023_003DzopDrLGk_003D?._0023_003Dzxpbv4lQ_003D)?.IsTransparent() ?? (_0023_003DztJCl_0024mM_003D.GetColor(_0023_003DzjDdbnzc6miMJ, _0023_003DzopDrLGk_003D?.Document.DefaultColor).A < byte.MaxValue);
	}

	internal static Color _0023_003DzV2aF4bEf7HcG(Entity _0023_003DztJCl_0024mM_003D, Entity _0023_003Dz0TvaYNo_003D, LayerKeyedCollection _0023_003DzjDdbnzc6miMJ, MaterialKeyedCollection _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D)
	{
		switch (_0023_003DztJCl_0024mM_003D.ColorMethod)
		{
		case colorMethodType.byEntity:
			if (string.IsNullOrEmpty(_0023_003DztJCl_0024mM_003D.MaterialName))
			{
				return _0023_003DztJCl_0024mM_003D.Color;
			}
			return _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D.GetItemFast(_0023_003DztJCl_0024mM_003D.MaterialName).Diffuse;
		case colorMethodType.byParent:
			if (_0023_003Dz0TvaYNo_003D != null)
			{
				return _0023_003DzV2aF4bEf7HcG(_0023_003Dz0TvaYNo_003D, null, _0023_003DzjDdbnzc6miMJ, _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D);
			}
			return _0023_003DzLG6uS1OyM8Rt(_0023_003DzjDdbnzc6miMJ.GetItemFast(_0023_003DztJCl_0024mM_003D.LayerName), _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D);
		default:
			return _0023_003DzLG6uS1OyM8Rt(_0023_003DzjDdbnzc6miMJ.GetItemFast(_0023_003DztJCl_0024mM_003D.LayerName), _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D);
		}
	}

	internal static Color _0023_003DzV2aF4bEf7HcG(Entity _0023_003DztJCl_0024mM_003D, Entity _0023_003Dz0TvaYNo_003D, LayerKeyedCollection _0023_003DzjDdbnzc6miMJ, Material _0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D)
	{
		MaterialKeyedCollection materialKeyedCollection = new MaterialKeyedCollection();
		if (!string.IsNullOrEmpty(_0023_003DztJCl_0024mM_003D.MaterialName))
		{
			materialKeyedCollection.Add(_0023_003DzKFzmIB5JuW_i7dxNsA_003D_003D);
		}
		return _0023_003DzV2aF4bEf7HcG(_0023_003DztJCl_0024mM_003D, _0023_003Dz0TvaYNo_003D, _0023_003DzjDdbnzc6miMJ, materialKeyedCollection);
	}

	private static Color _0023_003DzLG6uS1OyM8Rt(Layer _0023_003Dzi4AZsjQ_003D, MaterialKeyedCollection _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D)
	{
		if (string.IsNullOrEmpty(_0023_003Dzi4AZsjQ_003D.MaterialName))
		{
			return _0023_003Dzi4AZsjQ_003D.Color;
		}
		return _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D[_0023_003Dzi4AZsjQ_003D.MaterialName].Diffuse;
	}

	protected static float GetEntityLineWeight(Entity ent, Entity parent, LayerKeyedCollection layers)
	{
		float result = layers[ent.LayerName].LineWeight;
		switch (ent.LineWeightMethod)
		{
		case colorMethodType.byEntity:
			result = ent.LineWeight;
			break;
		case colorMethodType.byParent:
			if (parent != null)
			{
				result = GetEntityLineWeight(parent, null, layers);
			}
			break;
		}
		return result;
	}

	protected internal virtual void DrawOMWithPreview(DrawSceneParams data)
	{
		_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.ParentViewport = (Viewport)data.Viewport;
		((Viewport)data.Viewport)._0023_003DzdzRS8TI_003D(0.001f, 1f);
		Color color = Selection.Color;
		Color colorDynamic = Selection.ColorDynamic;
		Selection.Color = Color.FromArgb(255, color);
		Selection.ColorDynamic = Color.FromArgb(255, colorDynamic);
		if (_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.ShowPreviewOnTop && !_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
		{
			_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzqOMaE4ZfTqy4(data);
		}
		_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.UpdateScreenToWorld((Viewport)data.Viewport, data.ViewFrame);
		bool flag = false;
		if (_0023_003DztwOIOjldWKgIr8FLtvj_0024kdA_003D())
		{
			_0023_003DzmNZD0Zs_003D.smoothUICompositing.SetMSTarget();
			flag = true;
		}
		_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.DrawInternal(data);
		Selection.Color = color;
		Selection.ColorDynamic = colorDynamic;
		if (flag)
		{
			_0023_003DzmNZD0Zs_003D.smoothUICompositing.ResetTarget();
		}
	}

	internal void _0023_003Dzpc54XeTgVHkp1Cv4lA_003D_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		_0023_003DzmNZD0Zs_003D.staticSelectionCompositing.Update(Selection.HaloInnerColor, Selection.HaloOuterColor, Selection.Color, _0023_003Dz172y4KzLmCm83OqS4g_003D_003D(Selection.Color, 0.3), Selection.HaloWidthPolygons, Selection.HaloWidthWires);
		_0023_003DzmNZD0Zs_003D.staticSelectionCompositing.DrawOnTopOfCurrentTarget(_0023_003DzYzWi5Yw_003D._0023_003Dzr_AjDsvNuuYG(), _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D);
	}

	private bool _0023_003Dznyu0_TxNfbrjZIurLg_003D_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if ((_0023_003DzjGvm17_0024DzsnS == actionType.Rotate && Moving) || _0023_003DzSpehFdn_0024OOBr2rJb7A_003D_003D)
		{
			return _0023_003DzYzWi5Yw_003D.Rotate.ShowCenter;
		}
		return false;
	}

	private bool _0023_003DzEV8F0al6GnHEesAF0g_003D_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (!_0023_003Dznyu0_TxNfbrjZIurLg_003D_003D(_0023_003DzYzWi5Yw_003D))
		{
			return Mouse3D._0023_003DziBVjds1pKQd9DR73Vw_003D_003D();
		}
		return true;
	}

	private void _0023_003DzZFbC4uYYLuy9(Viewport _0023_003DzYzWi5Yw_003D, ShaderParameters _0023_003DzgcK4Z11iT1YA)
	{
		if (_0023_003DzYzWi5Yw_003D == _0023_003DzipBYly6zFKAp() && _0023_003DzEV8F0al6GnHEesAF0g_003D_003D(_0023_003DzYzWi5Yw_003D))
		{
			if (_0023_003DzxljNCVjBWQzg == null)
			{
				_0023_003Dz3CawVYDeC9WK();
			}
			_0023_003DzYzWi5Yw_003D._0023_003Dzpupdtp8TpznE(_0023_003DzmNZD0Zs_003D, _0023_003DzgcK4Z11iT1YA, _0023_003DzxljNCVjBWQzg);
		}
	}

	internal void _0023_003DzxRT2nHwkpqIv(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		if (viewport == null)
		{
			return;
		}
		if (!_0023_003DzCBM7XJK4_5H_0024.PlanarReflections)
		{
			_0023_003DzUsHKCw0NUp_uFfQ_0024in1W74813J_sfWUzVA_003D_003D();
		}
		if (_0023_003DztwOIOjldWKgIr8FLtvj_0024kdA_003D())
		{
			_0023_003DzmNZD0Zs_003D.smoothUICompositing.Clear();
		}
		bool flag = false;
		DisplayModeSettingsFlat _0023_003Dz9QlIAYpRuoz = null;
		BackfaceSettings _0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D = null;
		displayType displayMode = viewport.DisplayMode;
		if (viewport.OriginSymbols != null || _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Visible || _0023_003DznmpiQBcqK9AE.AddedItems.Count > 0)
		{
			if (_0023_003DzD_0024V5s06JeZ8Y0HFjaQ_003D_003D() && !_0023_003DzCBM7XJK4_5H_0024.PlanarReflections)
			{
				_0023_003Dz_0024Wtm1Rxp4CW0V6Iy2ukugo2m6fPn();
			}
			if (_0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(viewport))
			{
				DisplayModeSettings _0023_003Dzfyn_l283BhEUCdw1jw_003D_003D = _0023_003Dz0fTtstT4IqGh(viewport._0023_003DzK_00241ezHQJ9Z3c);
				_0023_003DzjsLPYiZZ7BDQHMbI2g_003D_003D(_0023_003Dzfyn_l283BhEUCdw1jw_003D_003D, _0023_003DzgFJqRMdb78KqPyuouw_003D_003D: false, out _0023_003Dz9QlIAYpRuoz, out _0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D);
				_0023_003DzXRmPWIn6oGDi();
				viewport.DisplayMode = displayType.Flat;
				_0023_003DzzznZbBezl6L_();
				flag = true;
			}
		}
		if (_0023_003DzCBM7XJK4_5H_0024.ShaderParams == null)
		{
			_0023_003DzCBM7XJK4_5H_0024.ShaderParams = _0023_003DzdfzPZ4BvPfHu(_0023_003DzCBM7XJK4_5H_0024);
		}
		bool flag2 = _0023_003DzCBM7XJK4_5H_0024.IsCurrentViewport();
		viewport._0023_003Dzl_s8qNo_003D(0f, 0.001f);
		if (_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(viewport) && _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing && !_0023_003DzCBM7XJK4_5H_0024.isLastBatch)
		{
			_0023_003Dzpc54XeTgVHkp1Cv4lA_003D_003D(viewport);
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.DisableClipPlanes();
		}
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetLineSize(1f, setShader: false);
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetState(rasterizerStateType.CW_PolygonFill_CullFaceBack_PolygonOffset_1_1);
		bool flag3 = !_0023_003DzCBM7XJK4_5H_0024.ZoomRect.IsEmpty;
		bool flag4 = false;
		if (viewport.OriginSymbols != null || _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Visible || _0023_003DznmpiQBcqK9AE.AddedItems.Count > 0)
		{
			_0023_003Dz89cPk57rASTGmdmTnA_003D_003D(viewport, _0023_003DzPHqp5dQ_003D: false, _0023_003DzCBM7XJK4_5H_0024.ZoomRect, CameraEyePosType.Center, _0023_003Dzk7pNhlbdSzPJ: true);
			_0023_003DzquuYPMJBed38(viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks);
			if (flag)
			{
				_0023_003DzefjT7qlP3g3TbTa29w_003D_003D(_0023_003Dz9QlIAYpRuoz, _0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D);
				_0023_003DzXRmPWIn6oGDi();
				viewport.DisplayMode = displayMode;
				_0023_003DzzznZbBezl6L_();
			}
			if (_0023_003DztwOIOjldWKgIr8FLtvj_0024kdA_003D())
			{
				_0023_003DzmNZD0Zs_003D.smoothUICompositing.SetMSTarget();
				flag4 = true;
			}
			OriginSymbol[] originSymbols = viewport.OriginSymbols;
			foreach (OriginSymbol originSymbol in originSymbols)
			{
				if (originSymbol.Visible)
				{
					_0023_003DzCBM7XJK4_5H_0024.CameraEyePos = CameraEyePosType.Center;
					originSymbol.DrawInternal(_0023_003DzCBM7XJK4_5H_0024);
				}
			}
			if (flag4)
			{
				_0023_003DzmNZD0Zs_003D.smoothUICompositing.ResetTarget();
			}
			if (_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Visible && (!flag3 || _0023_003DzCBM7XJK4_5H_0024.DrawAllUIElements) && _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzW2xdm0h0L74_0024(flag2, _0023_003DzCBM7XJK4_5H_0024.IsDesignMode))
			{
				_0023_003DzCBM7XJK4_5H_0024.ShaderParams = _0023_003DzdfzPZ4BvPfHu(_0023_003DzCBM7XJK4_5H_0024);
				_0023_003DzXsG3_0024Rpj5_iYwQvVnA_003D_003D(DrawOMWithPreview, _0023_003DzCBM7XJK4_5H_0024);
			}
		}
		flag4 = false;
		if (_0023_003DztwOIOjldWKgIr8FLtvj_0024kdA_003D())
		{
			_0023_003DzmNZD0Zs_003D.smoothUICompositing.SetMSTarget();
			flag4 = true;
		}
		if (viewport.ViewCubeIcon != null && viewport.ViewCubeIcon.Visible && viewport.ViewCubeIcon._0023_003DzW2xdm0h0L74_0024(flag2, _0023_003DzCBM7XJK4_5H_0024.IsDesignMode) && (!flag3 || _0023_003DzCBM7XJK4_5H_0024.DrawAllUIElements))
		{
			viewport._0023_003Dzl_s8qNo_003D(0f, 0.001f);
			viewport.ViewCubeIcon.DrawInternal(_0023_003DzCBM7XJK4_5H_0024);
		}
		if (viewport._0023_003DzFfOjsSRCbzpd != null && viewport._0023_003DzFfOjsSRCbzpd.Visible)
		{
			viewport._0023_003Dzl_s8qNo_003D(0f, 0.001f);
			viewport._0023_003DzFfOjsSRCbzpd.DrawInternal(_0023_003DzCBM7XJK4_5H_0024);
		}
		if (flag4)
		{
			_0023_003DzmNZD0Zs_003D.smoothUICompositing.ResetTarget();
		}
		viewport._0023_003DzsDZysFFbOXiw(_0023_003DzNwtRJ3cLTrAy(), _0023_003DzCBM7XJK4_5H_0024.ZoomRect, _0023_003Dz9Rnv95_0024TldTZ: false);
		_0023_003DzZFbC4uYYLuy9(viewport, _0023_003DzCBM7XJK4_5H_0024.ShaderParams);
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff);
		if (_0023_003Dzz2f3UQo_003D && flag2)
		{
			viewport._0023_003DzhXjMbKHjJh6K(_0023_003DzmNZD0Zs_003D, viewport, SelectionBoxColors, viewport.Size.Height, _0023_003DzjGvm17_0024DzsnS, _0023_003Dztt6EItoclqV3, _0023_003DzjRmmVH2Hj_0024KY);
		}
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff);
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Texture2DNoLights);
		if (_0023_003DzCBM7XJK4_5H_0024.SwapBuffer && flag2)
		{
			int num = 10;
			if (Logger.Instance.DisplayDiagnosticInfo && (Logger.Instance.TraceLevel != TraceLevel.Off || Logger.Instance.CaptureBackbufferImages))
			{
				_0023_003DzXeSpRyH7bWwi(_0023_003DzCBM7XJK4_5H_0024);
				num += 20;
			}
			if (_0023_003DzMdZJFmWObL0F)
			{
				_0023_003DzB82zQcTjBbdi(_0023_003DzCBM7XJK4_5H_0024, num);
			}
		}
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.None);
		viewport.PreDrawOverlay(_0023_003DzCBM7XJK4_5H_0024);
		viewport.DrawOverlay(_0023_003DzCBM7XJK4_5H_0024);
		DrawOverlayBlended(_0023_003DzCBM7XJK4_5H_0024, flag2);
		if (_0023_003DztwOIOjldWKgIr8FLtvj_0024kdA_003D())
		{
			Rectangle rect = (_0023_003DzCBM7XJK4_5H_0024.ZoomRect.IsEmpty ? viewport._0023_003Dzr_AjDsvNuuYG() : new Rectangle(viewport._0023_003Dzr_AjDsvNuuYG().Location, _0023_003DzmNZD0Zs_003D.ControlData.ControlSize));
			_0023_003DzmNZD0Zs_003D.smoothUICompositing.DrawOnTopOfCurrentTarget(rect, null);
		}
		MagnifyingGlass._0023_003DzshGHYXMIRfsi(this, _0023_003DzCBM7XJK4_5H_0024);
		if (_0023_003DzHGvJFuFQK858aICrUrxjaUpdZt8H())
		{
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		}
		viewport.PostDrawOverlay(_0023_003DzCBM7XJK4_5H_0024);
		if (_0023_003DzQio9vBoBmpUn && flag2 && _0023_003DzCBM7XJK4_5H_0024.SwapBuffer)
		{
			if (LicenseManager.IsOffline)
			{
				_0023_003DzHMPgdMt7tr6iGHh4tQ_003D_003D(_0023_003DzytRMTWr9k5Ww, _0023_003DzCBM7XJK4_5H_0024);
			}
			else if (_0023_003DzrW6VnBSrG94Y)
			{
				_0023_003DzHMPgdMt7tr6iGHh4tQ_003D_003D(_0023_003Dz7foQIumD31m4, _0023_003DzCBM7XJK4_5H_0024);
			}
		}
	}

	private void _0023_003DzjsLPYiZZ7BDQHMbI2g_003D_003D(DisplayModeSettings _0023_003Dzfyn_l283BhEUCdw1jw_003D_003D, bool _0023_003DzgFJqRMdb78KqPyuouw_003D_003D, out DisplayModeSettingsFlat _0023_003Dz9QlIAYpRuoz4, out BackfaceSettings _0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D)
	{
		_0023_003Dz9QlIAYpRuoz4 = new DisplayModeSettingsFlat(_0023_003Dzipe8ch4_003D.ShowEdges, _0023_003Dzipe8ch4_003D.EdgeColorMethod, _0023_003Dzipe8ch4_003D.EdgeColor, _0023_003Dzipe8ch4_003D.EdgeThickness, _0023_003Dzipe8ch4_003D.SilhouetteThickness, _0023_003Dzipe8ch4_003D.SilhouettesDrawingMode, _0023_003Dzipe8ch4_003D.ShowInternalWires, _0023_003Dzipe8ch4_003D.ColorMethod);
		_0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D = new BackfaceSettings(_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.Color);
		_0023_003Dzipe8ch4_003D.ShowEdges = !_0023_003DzgFJqRMdb78KqPyuouw_003D_003D;
		_0023_003Dzipe8ch4_003D.ShowInternalWires = false;
		if (!_0023_003DzgFJqRMdb78KqPyuouw_003D_003D)
		{
			_0023_003Dzipe8ch4_003D.SilhouettesDrawingMode = silhouettesDrawingType.Never;
			_0023_003Dzipe8ch4_003D.EdgeThickness = _0023_003Dzfyn_l283BhEUCdw1jw_003D_003D.EdgeThickness;
			_0023_003Dzipe8ch4_003D.EdgeColorMethod = edgeColorMethodType.SingleColor;
		}
		_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.ColorMethod = backfaceColorMethodType.SingleColor;
		_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D.Color = RenderContextBase.selectionWithThickHaloBackColor;
	}

	private void _0023_003DzefjT7qlP3g3TbTa29w_003D_003D(DisplayModeSettingsFlat _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D, BackfaceSettings _0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D)
	{
		_0023_003Dzipe8ch4_003D.ShowEdges = _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D.ShowEdges;
		_0023_003Dzipe8ch4_003D.EdgeColorMethod = _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D.EdgeColorMethod;
		_0023_003Dzipe8ch4_003D.EdgeColor = _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D.EdgeColor;
		_0023_003Dzipe8ch4_003D.EdgeThickness = _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D.EdgeThickness;
		_0023_003Dzipe8ch4_003D.SilhouetteThickness = _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D.SilhouetteThickness;
		_0023_003Dzipe8ch4_003D.SilhouettesDrawingMode = _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D.SilhouettesDrawingMode;
		_0023_003Dzipe8ch4_003D.ShowInternalWires = _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D.ShowInternalWires;
		_0023_003Dzipe8ch4_003D.ColorMethod = _0023_003Dz_Atx5Tae6W3BekXLrA_003D_003D.ColorMethod;
		_0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D = _0023_003DzjMoYEIl8TN9ogyYXZ573cdo_003D;
	}

	private void _0023_003Dz3CawVYDeC9WK()
	{
		_0023_003DzxljNCVjBWQzg = _0023_003DzmNZD0Zs_003D.CreateTexture2D(_0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzXdNN56CdF4a7(), textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest);
	}

	private void _0023_003DzB82zQcTjBbdi(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, int _0023_003DzJx6crCU_003D)
	{
		if (_0023_003DzqurM61XyL6Tc == null)
		{
			Logger.Instance.Warn(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594822), null);
			return;
		}
		PointF pointF = new PointF(10f, _0023_003DzCBM7XJK4_5H_0024.Viewport.Size.Height - _0023_003DzJx6crCU_003D);
		_0023_003Dz5xHaFz6XVogi(_0023_003DzmNZD0Zs_003D, pointF.X, pointF.Y, (int)_0023_003DzqurM61XyL6Tc.imagesSize[0].Width, (int)_0023_003DzqurM61XyL6Tc.imagesSize[0].Height, ContentAlignment.TopLeft, out var _0023_003DzGuW5l4E_003D, out var _0023_003DzVDBzBJQ_003D);
		pointF = new PointF(_0023_003DzGuW5l4E_003D, _0023_003DzVDBzBJQ_003D);
		_0023_003DzmNZD0Zs_003D.EnableXORForTexture(enable: true, _0023_003DzCBM7XJK4_5H_0024.ShaderParams);
		List<int> list = new List<int>(12);
		list.Add(0);
		int num = 2;
		int[] digits = Entity.GetDigits((int)Math.Round(fps));
		for (int i = 0; i < digits.Length; i++)
		{
			digits[i] += num;
		}
		list.AddRange(digits);
		list.Add(num - 1);
		_0023_003DzqurM61XyL6Tc.Draw(_0023_003DzmNZD0Zs_003D, list.ToArray(), ref pointF, drawBuffered: false);
		_0023_003DzmNZD0Zs_003D.EnableXORForTexture(enable: false, _0023_003DzCBM7XJK4_5H_0024.ShaderParams);
	}

	private void _0023_003DzXeSpRyH7bWwi(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzX9dkQU3xfVkG == null)
		{
			Logger.Instance.Warn(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594850), null);
			return;
		}
		PointF pointF = new PointF(10f, _0023_003DzCBM7XJK4_5H_0024.Viewport.Size.Height - 10);
		_0023_003Dz5xHaFz6XVogi(_0023_003DzmNZD0Zs_003D, pointF.X, pointF.Y, (int)_0023_003DzX9dkQU3xfVkG.imagesSize[0].Width, (int)_0023_003DzX9dkQU3xfVkG.imagesSize[0].Height, ContentAlignment.TopLeft, out var _0023_003DzGuW5l4E_003D, out var _0023_003DzVDBzBJQ_003D);
		pointF = new PointF(_0023_003DzGuW5l4E_003D, _0023_003DzVDBzBJQ_003D);
		_0023_003DzmNZD0Zs_003D.EnableXORForTexture(enable: true, _0023_003DzCBM7XJK4_5H_0024.ShaderParams);
		_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(_0023_003DzCBM7XJK4_5H_0024.ShaderParams);
		List<int> list = new List<int>(2);
		list.Add(0);
		list.Add(1);
		list.Add(2);
		int num = 3;
		int[] digits = Entity.GetDigits(_0023_003DzBn2ByFKdwrou);
		for (int i = 0; i < digits.Length; i++)
		{
			digits[i] += num;
		}
		list.AddRange(digits);
		_0023_003DzX9dkQU3xfVkG.Draw(_0023_003DzmNZD0Zs_003D, list.ToArray(), ref pointF, drawBuffered: false);
		_0023_003DzmNZD0Zs_003D.EnableXORForTexture(enable: false, _0023_003DzCBM7XJK4_5H_0024.ShaderParams);
	}

	private void _0023_003DzHMPgdMt7tr6iGHh4tQ_003D_003D(TextureMosaic _0023_003Dz_IfKSJY_003D, DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003Dz_IfKSJY_003D == null)
		{
			Logger.Instance.Warn(InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594903), null);
			return;
		}
		PointF pointF = new PointF(_0023_003DzCBM7XJK4_5H_0024.Viewport.Size.Width - 10, 10f);
		_0023_003Dz5xHaFz6XVogi(_0023_003DzmNZD0Zs_003D, pointF.X, pointF.Y, (int)_0023_003Dz_IfKSJY_003D.imagesSize[0].Width, (int)_0023_003Dz_IfKSJY_003D.imagesSize[0].Height, ContentAlignment.BottomRight, out var _0023_003DzGuW5l4E_003D, out var _0023_003DzVDBzBJQ_003D);
		pointF = new PointF(_0023_003DzGuW5l4E_003D, _0023_003DzVDBzBJQ_003D);
		_0023_003DzmNZD0Zs_003D.PushBlendState();
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		int[] source = new int[1];
		_0023_003Dz_IfKSJY_003D.Draw(_0023_003DzmNZD0Zs_003D, source.ToArray(), ref pointF, drawBuffered: false);
		_0023_003DzmNZD0Zs_003D.PopBlendState();
	}

	internal bool _0023_003DzdvWdO0ceOKDt(IUserInterfaceElementBase _0023_003DzV05tippAlGNv, object _0023_003Dz2geqaCQ_003D)
	{
		if (_0023_003DzV05tippAlGNv != null && !(_0023_003DzV05tippAlGNv is Viewport))
		{
			return _0023_003Dz2geqaCQ_003D == _0023_003DzV05tippAlGNv;
		}
		return true;
	}

	internal virtual void _0023_003DzNhVK8gNoCnQg(DrawSceneParams _0023_003Dzt5jpbHs_003D)
	{
		((Viewport)_0023_003Dzt5jpbHs_003D.Viewport)._0023_003Dzl_s8qNo_003D(0f, 0.001f);
		Color currentWireColor = _0023_003Dzt5jpbHs_003D.RenderContext.CurrentWireColor;
		float currentLineWidth = _0023_003Dzt5jpbHs_003D.RenderContext.CurrentLineWidth;
		float currentPointSize = _0023_003Dzt5jpbHs_003D.RenderContext.CurrentPointSize;
		_0023_003Dzt5jpbHs_003D.RenderContext.PushBlendState();
		_0023_003Dzt5jpbHs_003D.RenderContext.SetState(blendStateType.Blend);
		Entity[][] array = new Entity[TempEntities.Count][];
		Point3D[][][] array2 = new Point3D[TempEntities.Count][][];
		Point3D[][][] array3 = new Point3D[TempEntities.Count][][];
		for (int i = 0; i < TempEntities.Count; i++)
		{
			Entity entity = TempEntities[i];
			if (!entity.Visible)
			{
				continue;
			}
			if (entity is IFace)
			{
				int num = i;
				Entity[] tessellation = ((IFace)entity).GetTessellation();
				array[num] = tessellation;
				array3[i] = new Point3D[array[i].Length][];
				for (int j = 0; j < array[i].Length; j++)
				{
					Mesh mesh = (Mesh)array[i][j];
					if (mesh.Normals == null)
					{
						mesh.UpdateNormals();
					}
					if (mesh.Edges == null)
					{
						mesh.ComputeEdges();
					}
					if (mesh.Edges != null)
					{
						array3[i][j] = new Point3D[mesh.Edges.Length * 2];
						int num2 = 0;
						for (int k = 0; k < mesh.Edges.Length; k++)
						{
							IndexLine indexLine = mesh.Edges[k];
							array3[i][j][num2++] = (Point3D)mesh.Vertices[indexLine.V1].Clone();
							array3[i][j][num2++] = (Point3D)mesh.Vertices[indexLine.V2].Clone();
						}
					}
				}
			}
			else if (entity is Dimension)
			{
				Dimension dimension = (Dimension)entity;
				Point3D[][] triangles = dimension.GetTriangles(0.01, this);
				array2[i] = new Point3D[triangles.Length][];
				for (int l = 0; l < triangles.Length; l++)
				{
					array2[i][l] = new Point3D[triangles[l].Length];
					Array.Copy(triangles[l], array2[i][l], triangles[l].Length);
				}
				array3[i] = new Point3D[1][];
				dimension.GetLines(0.01, this, _0023_003DzzGo2_Wb1L5us: true, out array3[i][0], out var _);
			}
			else if (entity is Text)
			{
				int num3 = i;
				Entity[] tessellation = ((Text)entity).ConvertToMesh(_0023_003Dzt5jpbHs_003D.Workspace, skipNormals: true);
				array[num3] = tessellation;
			}
			else
			{
				if (!(entity is ICurve))
				{
					continue;
				}
				if (entity is devDept.Eyeshot.Entities.Point)
				{
					array3[i] = new Point3D[1][] { new Point3D[1] { entity.Vertices[0] } };
				}
				else
				{
					array3[i] = new Point3D[1][] { new Point3D[entity.Vertices.Length * 2 - 2] };
					int num4 = 0;
					for (int m = 0; m < entity.Vertices.Length - 1; m++)
					{
						array3[i][0][num4++] = entity.Vertices[m];
						array3[i][0][num4++] = entity.Vertices[m + 1];
					}
				}
			}
			_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(entity.Color);
			if (array[i] != null)
			{
				for (int n = 0; n < array[i].Length; n++)
				{
					if (array[i][n] is Mesh mesh2)
					{
						if (mesh2.Normals == null)
						{
							mesh2.UpdateNormals();
						}
						_0023_003Dzt5jpbHs_003D.RenderContext.DrawTrianglesPlanar(mesh2.Vertices, mesh2.Triangles, mesh2.Normals[0]);
					}
					else if (array[i][n] is FastMesh fastMesh)
					{
						VBOParams myParams = new VBOParams
						{
							indices = fastMesh.TriangleArray,
							vertices = fastMesh.PointArray,
							normals = fastMesh.NormalArray
						};
						_0023_003Dzt5jpbHs_003D.RenderContext.DrawIndexedTriangles(myParams);
					}
				}
			}
			else if (array2[i] != null)
			{
				for (int num5 = 0; num5 < array2[i].GetLength(0); num5++)
				{
					_0023_003Dzt5jpbHs_003D.RenderContext.DrawTriangles(array2[i][num5]);
				}
			}
			if (array3[i] == null)
			{
				continue;
			}
			if (entity is devDept.Eyeshot.Entities.Point)
			{
				_0023_003Dzt5jpbHs_003D.RenderContext.SetPointSize(entity.LineWeight, setShader: false);
				if (_0023_003Dzt5jpbHs_003D.RenderContext.IsDirect3D)
				{
					_0023_003Dzt5jpbHs_003D.RenderContext.PushShader();
					_0023_003Dzt5jpbHs_003D.RenderContext.SetShader(shaderType.NoLightsThickPoints);
					RenderContextBase renderContext = _0023_003Dzt5jpbHs_003D.RenderContext;
					Point3D[] vertices = new PointRGB[1]
					{
						new PointRGB(array3[i][0][0].X, array3[i][0][0].Y, array3[i][0][0].Z, entity.Color)
					};
					renderContext.DrawPointsRGB(vertices);
					_0023_003Dzt5jpbHs_003D.RenderContext.PopShader();
				}
				else
				{
					_0023_003Dzt5jpbHs_003D.RenderContext.DrawBufferedPoint(array3[i][0][0]);
				}
				continue;
			}
			_0023_003Dzt5jpbHs_003D.RenderContext.PushShader();
			_0023_003Dzt5jpbHs_003D.RenderContext.SetLineSize(entity.LineWeight);
			for (int num6 = 0; num6 < array3[i].GetLength(0); num6++)
			{
				if (array3[i][num6] != null)
				{
					_0023_003Dzt5jpbHs_003D.RenderContext.DrawLines(array3[i][num6]);
				}
			}
			_0023_003Dzt5jpbHs_003D.RenderContext.PopShader();
		}
		_0023_003Dzt5jpbHs_003D.RenderContext.SetLineSize(currentLineWidth);
		_0023_003Dzt5jpbHs_003D.RenderContext.SetPointSize(currentPointSize, setShader: false);
		_0023_003Dzt5jpbHs_003D.RenderContext.SetColorWireframe(currentWireColor);
		_0023_003Dzt5jpbHs_003D.RenderContext.PopBlendState();
	}

	protected virtual void DrawOverlay(DrawSceneParams data)
	{
	}

	private Point2D _0023_003DzRB2V4Jo_003D(Point3D _0023_003DzHw7Dl0k_003D)
	{
		return new Point2D(_0023_003DzHw7Dl0k_003D.X, _0023_003DzHw7Dl0k_003D.Y);
	}

	private Point2D[] _0023_003DzRB2V4Jo_003D(Point3D[] _0023_003Dz_KfgXoE_003D)
	{
		Point2D[] array = new Point2D[_0023_003Dz_KfgXoE_003D.Length];
		for (int i = 0; i < _0023_003Dz_KfgXoE_003D.Length; i++)
		{
			array[i] = new Point2D(_0023_003Dz_KfgXoE_003D[i].X, _0023_003Dz_KfgXoE_003D[i].Y);
		}
		return array;
	}

	private void _0023_003Dz0nPl6dYTdVGb(Rectangle _0023_003DzLCFtN0k_003D)
	{
		_0023_003DzmNZD0Zs_003D.PrepareStencilForDrawing();
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff);
		_0023_003DzmNZD0Zs_003D.DrawQuad(_0023_003DzLCFtN0k_003D);
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		_0023_003DzmNZD0Zs_003D.EnableStencilCompare();
	}

	private void _0023_003DzFTgQxaR3atKs(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003Dz_Gins76ssUS7)
	{
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		viewport._0023_003DzdzRS8TI_003D(0f, 0.001f);
		_0023_003DzK3OaHhra7VrS._0023_003DzqDGueC67yP8K(_0023_003DzmNZD0Zs_003D, viewport.Camera.GetModelViewProjectionMatrix(), _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
		viewport._0023_003Dz4DjPZGU_003D(_0023_003DzCBM7XJK4_5H_0024.ViewFrame);
		if (_0023_003DzK3OaHhra7VrS.Visible)
		{
			_0023_003DzK3OaHhra7VrS.DrawLabel(_0023_003DzCBM7XJK4_5H_0024);
		}
		if (_0023_003DzjC4hA2I_003D.isFsaaAvailable && AntiAliasing)
		{
			_0023_003DzmNZD0Zs_003D.EnableMultisample(enable: false);
		}
		_0023_003DzmNZD0Zs_003D.SetLineSize(1f, setShader: false);
		if (_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Visible && _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.ShowTransformationLabel)
		{
			double[] _0023_003DzYgijFM_0024VNOEd = _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzUiFXEqJwC41M(viewport.Camera.GetModelViewProjectionMatrix());
			_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzqDGueC67yP8K(_0023_003DzmNZD0Zs_003D, _0023_003DzYgijFM_0024VNOEd, _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
			bool num = _0023_003DztwOIOjldWKgIr8FLtvj_0024kdA_003D();
			if (num)
			{
				_0023_003DzmNZD0Zs_003D.smoothUICompositing.SetMSTarget();
			}
			if (_0023_003DzCBM7XJK4_5H_0024.ZoomRect.IsEmpty)
			{
				_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.DrawLabel(_0023_003DzCBM7XJK4_5H_0024);
			}
			if (num)
			{
				_0023_003DzmNZD0Zs_003D.smoothUICompositing.ResetTarget();
			}
		}
		if (_0023_003DzCBM7XJK4_5H_0024.DrawLabels)
		{
			viewport.DrawLabels(_0023_003DzmNZD0Zs_003D, _0023_003DzCBM7XJK4_5H_0024.DrawScale);
		}
		if (_0023_003DzjC4hA2I_003D.isFsaaAvailable && AntiAliasing)
		{
			_0023_003DzmNZD0Zs_003D.EnableMultisample(enable: true);
		}
		int _0023_003Dz7nXk4nAdrYuD = 0;
		int _0023_003DzHGcYaz9_t1wE = 0;
		float num2 = 0f;
		if (_0023_003DzCBM7XJK4_5H_0024.DrawLegends)
		{
			if (!_0023_003DzCBM7XJK4_5H_0024.ZoomRect.IsEmpty)
			{
				float num3 = (float)_0023_003DzCBM7XJK4_5H_0024.ViewFrame[3] / _0023_003DzCBM7XJK4_5H_0024.ZoomRect.Height;
				num2 = _0023_003DzCBM7XJK4_5H_0024.ZoomRect.Y / _0023_003DzCBM7XJK4_5H_0024.ZoomRect.Height;
				_0023_003Dz7nXk4nAdrYuD = (int)Math.Round(_0023_003DzCBM7XJK4_5H_0024.ZoomRect.X / _0023_003DzCBM7XJK4_5H_0024.ZoomRect.Width * (float)_0023_003DzCBM7XJK4_5H_0024.ViewFrame[2]);
				_0023_003DzHGcYaz9_t1wE = (int)Math.Round((num3 - num2 - 1f) * (float)_0023_003DzCBM7XJK4_5H_0024.ViewFrame[3]);
			}
			Legend[] legends = viewport.Legends;
			foreach (Legend legend in legends)
			{
				if (legend._0023_003DzW2xdm0h0L74_0024(_0023_003Dz_Gins76ssUS7, _0023_003DzCBM7XJK4_5H_0024.IsDesignMode) && legend.Visible)
				{
					if (_0023_003DzCBM7XJK4_5H_0024.ZoomRect.IsEmpty)
					{
						legend.Draw(this, viewport);
					}
					else
					{
						legend._0023_003Dz99kJFjE_003D(this, viewport, _0023_003DzCBM7XJK4_5H_0024.DrawScale, _0023_003DzCBM7XJK4_5H_0024.ViewportScaleRatio, _0023_003Dz7nXk4nAdrYuD, _0023_003DzHGcYaz9_t1wE);
					}
				}
			}
		}
		if (viewport._0023_003Dze_0024CNZ_Memiiw)
		{
			_0023_003DzCBM7XJK4_5H_0024.Entities = Entities;
			DrawVertexIndices(_0023_003DzCBM7XJK4_5H_0024);
		}
	}

	protected virtual void DrawVertexIndices(DrawSceneParams mySceneParams)
	{
		if (_0023_003DzUnT21F0UWD2IlVwatg_003D_003D == null)
		{
			_0023_003DzDSW5N9nVQuQC();
		}
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Texture2DNoLights);
		_0023_003DzmNZD0Zs_003D.EnableXORForTexture(enable: true, mySceneParams.ShaderParams);
		_0023_003DzmNZD0Zs_003D.PushDepthStencilState();
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthMaskFalse_DepthTestLess);
		int[] viewFrame = mySceneParams.ViewFrame;
		Transformation additionalModelViewTransformation = null;
		if (CurrentTransformation != null)
		{
			new GfxAttributes(_0023_003DzipBYly6zFKAp().Background.GetContrastColor());
			DrawParams _0023_003DzrFXPIITH9q = new DrawParams(mySceneParams.Viewport, mySceneParams.Blocks);
			DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, mySceneParams.Entities, _0023_003DzrFXPIITH9q, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D: false);
			Stack<BlockReference> stack = _0023_003DzZuBsUvr900Ui(drawEntitiesParams.DrawParams);
			if (stack.Count > 0)
			{
				additionalModelViewTransformation = stack.Peek().AccumulatedParentsTransform;
			}
		}
		if (mySceneParams.Viewport.DisplayMode == displayType.Wireframe)
		{
			DrawOnScreenParams myParams = new DrawOnScreenParams(_0023_003DzmNZD0Zs_003D, mySceneParams.Viewport.Camera, null, 0, viewFrame, _0023_003DzUnT21F0UWD2IlVwatg_003D_003D, 0, 0, 0, 0, additionalModelViewTransformation);
			for (int i = 0; i < mySceneParams.Entities.Count; i++)
			{
				Entity entity = mySceneParams.Entities[i];
				if (entity.IsVisible(mySceneParams.Workspace.Layers))
				{
					entity.DrawOnScreenWireframe(myParams);
				}
			}
		}
		else
		{
			int stride;
			short[] depthValues = _0023_003DzmNZD0Zs_003D.ReadDepthValues(viewFrame, out stride);
			int num = (int)Math.Ceiling((double)Camera.ViewportPointSize / 2.0);
			int leftBorder = num;
			int rightBorder = viewFrame[2] - num;
			int bottomBorder = num;
			int topBorder = viewFrame[3] - num;
			DrawOnScreenParams drawOnScreenParams = new DrawOnScreenParams(_0023_003DzmNZD0Zs_003D, mySceneParams.Viewport.Camera, depthValues, stride, viewFrame, _0023_003DzUnT21F0UWD2IlVwatg_003D_003D, leftBorder, rightBorder, bottomBorder, topBorder, additionalModelViewTransformation);
			for (int j = 0; j < mySceneParams.Entities.Count; j++)
			{
				Entity entity2 = mySceneParams.Entities[j];
				if (entity2.IsVisible(mySceneParams.Workspace.Layers))
				{
					entity2.DrawOnScreen(drawOnScreenParams);
				}
			}
		}
		_0023_003DzmNZD0Zs_003D.DrawCurrentBuffer();
		_0023_003DzmNZD0Zs_003D.PopDepthStencilState();
		_0023_003DzmNZD0Zs_003D.EnableXORForTexture(enable: false, mySceneParams.ShaderParams);
	}

	private void _0023_003DzDSW5N9nVQuQC()
	{
		Bitmap[] array = new Bitmap[10];
		Font font = new Font(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597689), 8.25f);
		try
		{
			for (int i = 0; i < 10; i++)
			{
				array[i] = _0023_003DzRFGA2zTmmjXj(i.ToString(), font, Color.White, Color.Empty, IntPtr.Zero, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
				_0023_003DzLGy56aIVS2ab2GUVBA_003D_003D(ref array[i], Color.FromArgb(0, Color.Black));
			}
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
		_0023_003DzUnT21F0UWD2IlVwatg_003D_003D = new TextureMosaic(_0023_003DzmNZD0Zs_003D, 2, 5, array);
		for (int j = 0; j < 10; j++)
		{
			array[j].Dispose();
		}
	}

	protected virtual void DrawOverlayBlended(DrawSceneParams myParams, bool isCurrentViewport)
	{
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		Viewport viewport = (Viewport)myParams.Viewport;
		_0023_003DzFTgQxaR3atKs(myParams, isCurrentViewport);
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Texture2DNoLights);
		bool flag = _0023_003DztwOIOjldWKgIr8FLtvj_0024kdA_003D();
		if (flag)
		{
			_0023_003DzmNZD0Zs_003D.smoothUICompositing.SetMSTarget();
		}
		if (myParams.DrawLabels)
		{
			OriginSymbol[] originSymbols = viewport.OriginSymbols;
			foreach (OriginSymbol originSymbol in originSymbols)
			{
				if (originSymbol.Visible)
				{
					originSymbol._0023_003Dz_SqxI8ntug_A(myParams);
					originSymbol._0023_003Dz1lQiK8IwvEb9(myParams.RenderContext, myParams.DrawScale);
				}
			}
			if (viewport.CoordinateSystemIcon != null && viewport.CoordinateSystemIcon.Visible)
			{
				viewport.CoordinateSystemIcon._0023_003Dz_SqxI8ntug_A(myParams);
				viewport.CoordinateSystemIcon.DrawLabels(myParams);
			}
		}
		if (flag)
		{
			_0023_003DzmNZD0Zs_003D.smoothUICompositing.ResetTarget();
		}
		if (viewport._0023_003DznPu5SKE_003D != null && viewport._0023_003DznPu5SKE_003D.Visible)
		{
			_0023_003DzmNZD0Zs_003D.PushMatrices();
			viewport._0023_003DzsDZysFFbOXiw(_0023_003DzNwtRJ3cLTrAy(), myParams.ZoomRect, _0023_003Dz9Rnv95_0024TldTZ: true);
			viewport._0023_003DznPu5SKE_003D.Draw(myParams);
			_0023_003DzmNZD0Zs_003D.PopMatrices();
		}
		bool flag2 = !myParams.ZoomRect.IsEmpty;
		if (viewport.ScaleBar != null && viewport.ScaleBar.Visible && (!flag2 || myParams.DrawAllUIElements))
		{
			_0023_003DzmNZD0Zs_003D.PushMatrices();
			viewport._0023_003DzsDZysFFbOXiw(_0023_003DzNwtRJ3cLTrAy(), myParams.ZoomRect, _0023_003Dz9Rnv95_0024TldTZ: true);
			viewport.ScaleBar.Draw(myParams);
			_0023_003DzmNZD0Zs_003D.PopMatrices();
		}
		if (myParams.SwapBuffer || myParams.IsDesignMode || myParams.DrawAllUIElements)
		{
			if (flag)
			{
				_0023_003DzmNZD0Zs_003D.smoothUICompositing.SetMSTarget();
			}
			if (ProgressBar.Visible)
			{
				ProgressBar.Draw(myParams);
			}
			ToolBar[] toolBars = viewport.ToolBars;
			foreach (ToolBar toolBar in toolBars)
			{
				if (toolBar.Visible && toolBar._0023_003DzW2xdm0h0L74_0024(isCurrentViewport, myParams.IsDesignMode))
				{
					toolBar.Draw(myParams);
				}
			}
			if (flag)
			{
				_0023_003DzmNZD0Zs_003D.smoothUICompositing.ResetTarget();
			}
		}
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
	}

	private void _0023_003DzjLLmiKcRt1A4(System.Drawing.Graphics _0023_003DzVC9FBdo_003D)
	{
		int cornerRadius = _0023_003DzE61nM_aOZBgx.CornerRadius;
		if (Dock == DockStyle.Fill)
		{
			return;
		}
		if (_0023_003DzE61nM_aOZBgx.Visible)
		{
			Pen pen = new Pen(RenderContextUtility.ConvertColor(_0023_003DzOLP90s_0024AN26E.Color));
			try
			{
				_0023_003DzVC9FBdo_003D.DrawRectangle(pen, 0, 0, _0023_003Dz0P1LCYH__O4t() - 1, _0023_003DzNwtRJ3cLTrAy() - 1);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}
		if (cornerRadius > 0)
		{
			if (_0023_003DzPHIgywQ0bPFl != null)
			{
				_0023_003DzVC9FBdo_003D.DrawImage(_0023_003DzPHIgywQ0bPFl, 0, 0);
			}
			if (_0023_003DzBlHCDVjJXeoG != null)
			{
				_0023_003DzVC9FBdo_003D.DrawImage(_0023_003DzBlHCDVjJXeoG, _0023_003Dz0P1LCYH__O4t() - cornerRadius, 0);
			}
			if (_0023_003DzkP4DGwYcuX5B != null)
			{
				_0023_003DzVC9FBdo_003D.DrawImage(_0023_003DzkP4DGwYcuX5B, _0023_003Dz0P1LCYH__O4t() - cornerRadius, _0023_003DzNwtRJ3cLTrAy() - cornerRadius);
			}
			if (_0023_003DzAekJM0ZtENTE != null)
			{
				_0023_003DzVC9FBdo_003D.DrawImage(_0023_003DzAekJM0ZtENTE, 0, _0023_003DzNwtRJ3cLTrAy() - cornerRadius);
			}
		}
	}

	protected virtual void Draw3D(DrawSceneParams myParams)
	{
		if (myParams.RenderContext.Shaders != null)
		{
			foreach (KeyValuePair<shaderType, IShaderTechnique> shader in myParams.RenderContext.Shaders)
			{
				shader.Value.UpdatedInFrame = false;
			}
		}
		Viewport viewport = (Viewport)myParams.Viewport;
		_0023_003Dz89cPk57rASTGmdmTnA_003D_003D(viewport, myParams.PlanarReflections, myParams.ZoomRect, myParams.CameraEyePos, _0023_003Dzk7pNhlbdSzPJ: false);
		if (myParams.PlanarReflections)
		{
			myParams.ShaderParams = _0023_003DzGhVyc3iwfBwt(myParams);
			myParams.ShaderParams.PrepareForRender(_0023_003DzmNZD0Zs_003D, _0023_003DznKkOfo8_003D.EnvironmentMapping ? _0023_003DziuvwBNA4duWb : null);
			_0023_003DzmNZD0Zs_003D.GetShaderAndEnable(myParams.ShaderParams);
			_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(myParams.ShaderParams);
		}
		else
		{
			myParams.ShaderParams = _0023_003DzdfzPZ4BvPfHu(myParams);
			if (viewport.DisplayMode == displayType.Rendered)
			{
				myParams.ShaderParams.PrepareForRender(myParams.RenderContext, _0023_003DznKkOfo8_003D.EnvironmentMapping ? _0023_003DziuvwBNA4duWb : null);
			}
			myParams.RenderContext.GetShaderAndEnable(myParams.ShaderParams);
		}
		_0023_003DzmNZD0Zs_003D.UpdateShaders(myParams.ShaderParams);
		viewport._0023_003DzdzRS8TI_003D();
		if (_0023_003Dzx6q74t9r4Eis7_00241oag_003D_003D() && !myParams.PlanarReflections)
		{
			_0023_003Dz10cjaUpmisQwhIAYQdLEjeLwfRrE();
		}
		Camera camera = viewport.Camera;
		if (_0023_003DzjC4hA2I_003D.isFsaaAvailable)
		{
			_0023_003DzmNZD0Zs_003D.EnableMultisample(_0023_003DzjC4hA2I_003D.AntiAliasing);
		}
		camera.SetProjectionMatrixType(Camera.projectionMatrixType.Standard);
		if (!myParams.isProgressiveDrawing || _0023_003Dzo_MNAFBAjuGu == 0)
		{
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(myParams))
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.BindTarget(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons);
			}
			viewport._0023_003DzC9qfRaqDpHaFw3uV_g_003D_003D(myParams.RenderContext, myParams.PlanarReflections, _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF, _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr, Entities.Count, _0023_003DzNwtRJ3cLTrAy(), myParams.CameraEyePos);
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(myParams))
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.RestoreBuffers();
			}
		}
		_0023_003DzmNZD0Zs_003D.ProcessClippingPlanes(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D);
		viewport.Camera.SetupModelView(setGraphics: true, myParams.PlanarReflections, myParams.CameraEyePos, applySceneTransformation: false);
		if (!myParams.PlanarReflections && !myParams.ZBufferOnly && _0023_003Dz0fTtstT4IqGh(viewport.DisplayMode)._0023_003DzLipASLNgxA13 == shadowType.Planar && myParams.Entities.Count > 0 && _0023_003DzaIkiwmUCZEncrNAqSQ_003D_003D() && (!myParams.isProgressiveDrawing || _0023_003Dzo_MNAFBAjuGu == 0))
		{
			bool[] _0023_003DzR_0024c5epA_003D = Utility.TurnOffClippingPlanes(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, myParams.RenderContext);
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(myParams))
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.BindTarget(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons);
			}
			_0023_003DzgpecnOZK_rLDYEjHUA_003D_003D._0023_003Dz99kJFjE_003D(myParams.RenderContext, _0023_003Dz1en4hYuH_0024KDC2BdK0g_003D_003D, _0023_003DzrnMI_SiQDx8_0024QFSmZA3zGE6q_QjC4hO9xRf6Hz8_003D(), null, _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF, _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr);
			if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(myParams))
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.RestoreBuffers();
			}
			Utility.RestoreClippingPlanesStatus(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, myParams.RenderContext, _0023_003DzR_0024c5epA_003D);
		}
		viewport.Camera.ApplySceneTransformation();
		if (!_0023_003DzppsdDUxL8MoNpsvok2_0024eG4c_003D(myParams) && !myParams.isProgressiveDrawing)
		{
			_0023_003DzXS86eTnj2Efz(_0023_003DzdWWqz40ROLb5Pp383A_003D_003D(_0023_003DzPEEjwoPxhT6e(viewport), myParams.Entities), new FrustumParams(viewport._0023_003DzLK0OwXvAsOsnI9nS_0024Q_003D_003D(myParams.PlanarReflections), this, myParams.Blocks), myParams.Simplify, myParams.isProgressiveDrawing);
		}
		_0023_003DzmNZD0Zs_003D.PushModelView();
		if (!myParams.PlanarReflections)
		{
			viewport._0023_003DzEoxSq3a9jDkF(myParams.ViewFrame);
		}
		if (!myParams.isProgressiveDrawing || _0023_003Dzo_MNAFBAjuGu == 0)
		{
			_0023_003DzmNZD0Zs_003D.ClearDepthStencil(myParams.ClearDepthBuffer, stencilBuffer: false, 0);
		}
		if (myParams.DoShadows)
		{
			_0023_003DzBUFJRkmN2AUU(myParams);
		}
		else
		{
			_0023_003DzmNZD0Zs_003D.ProcessLightAttributes(shadowPass: false, myParams.PlanarReflections);
			_0023_003DztyHACw9KoliV(myParams, _0023_003DzyeguIwq0Zzv1: false);
			if (myParams.ShowObjectManipulatorPreviewInScene)
			{
				myParams.RenderContext.PushModelView();
				myParams.RenderContext.SetModelView(_0023_003DzipBYly6zFKAp().Camera);
				_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzqOMaE4ZfTqy4(myParams);
				myParams.RenderContext.PopModelView();
			}
		}
		_0023_003DzmNZD0Zs_003D.CloseTexture(force: true);
		if (AccurateTransparency && (viewport.DisplayMode == displayType.Rendered || viewport.DisplayMode == displayType.Shaded || viewport.DisplayMode == displayType.Flat) && !_0023_003DzmNZD0Zs_003D.IsDrawingForDepth)
		{
			DisplayModeSettings _0023_003DzOUFng_M_003D = _0023_003Dz0fTtstT4IqGh(viewport.DisplayMode);
			_0023_003DzmNZD0Zs_003D.PushRasterizerState();
			_0023_003Dz_9qS3W815tFjCa_RC_0024JgHyk_003D(_0023_003DzOUFng_M_003D, _0023_003Dzz4aiLqY_0024r7bL: false);
			if (viewport.DisplayMode == displayType.Flat)
			{
				_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			}
			_0023_003DzmNZD0Zs_003D.PushShader();
			_0023_003DzAjlbXONkieO7(myParams, Selection.Color);
			_0023_003DzmNZD0Zs_003D.PopShader();
			_0023_003DzmNZD0Zs_003D.PopRasterizerState();
		}
		if (!myParams.PlanarReflections)
		{
			_0023_003Dzemj_0024cuX1Dkz_KyAnyw_003D_003D(myParams);
		}
		if (!myParams.isProgressiveDrawing || myParams.isLastBatch)
		{
			viewport._0023_003Dz1aD3FvrMPVZvq2oC0g_003D_003D((Grid._0023_003Dzp2xC_56LDhr6)0, myParams.PlanarReflections, _0023_003DzNwtRJ3cLTrAy());
		}
		if (_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(viewport) && (!myParams.isProgressiveDrawing || myParams.isLastBatch) && !myParams.PlanarReflections)
		{
			_0023_003Dzpc54XeTgVHkp1Cv4lA_003D_003D(viewport);
		}
		if (!myParams.PlanarReflections)
		{
			_0023_003DzmNZD0Zs_003D.DisableClipPlanes();
		}
		if (!myParams.PlanarReflections && _0023_003DzK3OaHhra7VrS.Visible)
		{
			_0023_003DzmNZD0Zs_003D.PushModelView();
			Point3D _0023_003Dze4TpmVqI26AF = _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF;
			Point3D _0023_003DzD4HjvLi8HsVr = _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr;
			_0023_003DzmNZD0Zs_003D.SetMatrices(viewport.Camera.ProjectionMatrix, viewport.Camera.ModelViewMatrix);
			_0023_003DzmNZD0Zs_003D.TranslateMatrixModelView(_0023_003Dze4TpmVqI26AF.X, _0023_003Dze4TpmVqI26AF.Y, _0023_003Dze4TpmVqI26AF.Z);
			_0023_003DzK3OaHhra7VrS.Draw(viewport, myParams.RenderContext, myParams.DrawScale, Point3D.Origin, new Point3D(_0023_003DzD4HjvLi8HsVr.X - _0023_003Dze4TpmVqI26AF.X, _0023_003DzD4HjvLi8HsVr.Y - _0023_003Dze4TpmVqI26AF.Y, _0023_003DzD4HjvLi8HsVr.Z - _0023_003Dze4TpmVqI26AF.Z));
			_0023_003DzmNZD0Zs_003D.PopModelView();
		}
		_0023_003DzmNZD0Zs_003D.PopModelView();
		if (_0023_003DzjC4hA2I_003D.IsAntiAliasingEnabled())
		{
			_0023_003DzmNZD0Zs_003D.EnableMultisample(enable: false);
		}
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
	}

	internal void _0023_003Dz_0024fPU_Lwns_0024lL(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		RenderParams _0023_003DzrFXPIITH9q = new RenderParams(_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			Attributes = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesRendered>()
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
		drawEntitiesParams.DrawParams.ForceGray = false;
		drawEntitiesParams.layers = Layers;
		drawEntitiesParams.Blocks = _0023_003DzCBM7XJK4_5H_0024.Blocks;
		drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		drawEntitiesParams.animating = _0023_003DzyobtGSd5_zcs();
		drawEntitiesParams.defaultMaterial = _0023_003Dzxpbv4lQ_003D;
		drawEntitiesParams.boundingBox = _0023_003DzK3OaHhra7VrS;
		_0023_003DzCBM7XJK4_5H_0024.isDepthPrepass = true;
		base.RenderContext.PushDepthStencilState();
		base.RenderContext.PushRasterizerState();
		base.RenderContext.PushBlendState();
		_0023_003DzmNZD0Zs_003D.PushShader();
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		bool flag = _0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D.ColorMethod == backfaceColorMethodType.Cull;
		base.RenderContext.SetState(flag ? rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset : rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		base.RenderContext.SetState(depthStencilStateType.DepthTestLessEqual);
		base.RenderContext.SetDepthForPostProcessingAsCurrentTarget();
		base.RenderContext.SetColorMask(colorMaskFlags.None);
		_0023_003DzmNZD0Zs_003D.LockBlendState(lockBlendState: true);
		_0023_003DzWp5X7PvcuErenq1_00240Ofokko_003D(_0023_003DzCBM7XJK4_5H_0024);
		base.RenderContext.LockBlendState(lockBlendState: false);
		base.RenderContext.SetColorMask(colorMaskFlags.RGBA);
		_0023_003DzjLzB452mA_0024FoSHhFo4DfqyxvrjCF(drawEntitiesParams);
		base.RenderContext.RestoreFBO();
		base.RenderContext.PopShader();
		base.RenderContext.PopBlendState();
		base.RenderContext.PopRasterizerState();
		base.RenderContext.PopDepthStencilState();
		_0023_003DzCBM7XJK4_5H_0024.isDepthPrepass = false;
	}

	internal void _0023_003DztyHACw9KoliV(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzyeguIwq0Zzv1)
	{
		bool flag = _0023_003Dz6VoEBpmCq7f_ip0wIg_003D_003D(_0023_003DzCBM7XJK4_5H_0024);
		if (flag)
		{
			_0023_003DzTT607now8UkBMMkxB6e9_0024TLPYiMF();
		}
		_0023_003DzCBM7XJK4_5H_0024.ssaoEnabled = flag && _0023_003DznD5ss1xVO0yzRCM6X3zl_ow_003D();
		bool num = _0023_003Dz_0024A8nMqSWV3y48zCc3X04SjaFKfXZ(_0023_003DzCBM7XJK4_5H_0024);
		if (num)
		{
			_0023_003DzhzTzyLh6zMfMwCq4E795HvMm4Sj3();
		}
		bool flag2 = num && _0023_003DzquyVonCV8C0HGiKMHOwaK808RGjL();
		if ((_0023_003DzCBM7XJK4_5H_0024.ssaoEnabled || flag2) && (!_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing || _0023_003Dzo_MNAFBAjuGu == 0))
		{
			base.RenderContext.SetDepthForPostProcessingAsCurrentTarget();
			base.RenderContext.ClearColor(Color.Empty);
			base.RenderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: true, 0);
			base.RenderContext.RestoreFBO();
		}
		if (_0023_003DzCBM7XJK4_5H_0024.ssaoEnabled || flag2)
		{
			_0023_003Dz_0024fPU_Lwns_0024lL(_0023_003DzCBM7XJK4_5H_0024);
		}
		_0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzCBM7XJK4_5H_0024.ZBufferOnly, (_0023_003DzARfd93yYb38F)1);
		if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
		{
			_0023_003DzaEZv8NHpRIdvGRoW0A_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz_l8qMDtuWfSD3gVZCQ_003D_003D: true, _0023_003Dz6dkM6H2_wQWT: false, _0023_003DznDL1YPo_003D: false);
		}
		if (_0023_003DzCBM7XJK4_5H_0024.ssaoEnabled)
		{
			_0023_003Dzgi2Ebcq_0024zxbg(_0023_003DzCBM7XJK4_5H_0024);
			_0023_003Dzu7qIyF1LiH3N(_0023_003DzCBM7XJK4_5H_0024);
		}
		_0023_003Dz63GJxgPNPnh1Xegeiw_003D_003D(_0023_003DzCBM7XJK4_5H_0024);
		if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
		{
			_0023_003DzaEZv8NHpRIdvGRoW0A_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz_l8qMDtuWfSD3gVZCQ_003D_003D: false, _0023_003Dz6dkM6H2_wQWT: true, _0023_003DznDL1YPo_003D: false);
		}
		if (flag2)
		{
			_0023_003DzYT5U7iwXC42u(_0023_003DzCBM7XJK4_5H_0024);
			_0023_003DzaIBxX7ek89JnUblmBa9dkruUalAG(_0023_003DzCBM7XJK4_5H_0024);
		}
		if (_0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
		{
			_0023_003DzaEZv8NHpRIdvGRoW0A_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz_l8qMDtuWfSD3gVZCQ_003D_003D: false, _0023_003Dz6dkM6H2_wQWT: false, _0023_003DznDL1YPo_003D: true);
		}
		if ((!_0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing || _0023_003DzCBM7XJK4_5H_0024.isLastBatch) && !_0023_003DzyeguIwq0Zzv1)
		{
			((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport)._0023_003Dz1aD3FvrMPVZvq2oC0g_003D_003D((Grid._0023_003Dzp2xC_56LDhr6)1, _0023_003DzCBM7XJK4_5H_0024.PlanarReflections, _0023_003DzNwtRJ3cLTrAy());
		}
		if (_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode != displayType.HiddenLines && _0023_003Dzmq468FOl1RBUpGlrEpFsBdQ4ifHS(_0023_003DzCBM7XJK4_5H_0024))
		{
			_0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzCBM7XJK4_5H_0024.ZBufferOnly, (_0023_003DzARfd93yYb38F)2);
		}
		if (_0023_003Dzrm2bYUVg_0024nLeR0WlCQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024))
		{
			_0023_003Dz4M3QUETNx7gr3VY7vKD8WYqX7vPS();
		}
		if (_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(_0023_003DzCBM7XJK4_5H_0024.viewportInternal) && _0023_003Dz50vA7BeIaD3NZwgnDIQJNIA_003D(_0023_003DzCBM7XJK4_5H_0024))
		{
			_0023_003Dz0mTAjAZCb5coBNJKNA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz0fTtstT4IqGh(_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode), _0023_003DzgFJqRMdb78KqPyuouw_003D_003D: true);
		}
		if (_0023_003DzCBM7XJK4_5H_0024.isSketchActive && !_0023_003DzCBM7XJK4_5H_0024.PlanarReflections)
		{
			_0023_003Dz2frVzxD_002453RgnxuhQQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesWire>());
		}
		if (Mouse3D._0023_003DziBVjds1pKQd9DR73Vw_003D_003D() && _0023_003Dz6oXjiBbfuRAlBSZl9Fg_0024I_v3AiUA)
		{
			Mouse3D._0023_003DzBilDqwru8u5B();
			_0023_003Dz6oXjiBbfuRAlBSZl9Fg_0024I_v3AiUA = false;
		}
	}

	private void _0023_003DzaIBxX7ek89JnUblmBa9dkruUalAG(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzmNZD0Zs_003D.silhoCompositing?.DrawOnTopOfCurrentTarget(((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport)._0023_003Dzr_AjDsvNuuYG(), _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D);
	}

	private bool _0023_003Dzst7PSrE3exCjKedVKg_003D_003D()
	{
		for (int i = 0; i < _0023_003DzMuApP021PUyU.Length; i++)
		{
			if (_0023_003DzMuApP021PUyU[i].Active && _0023_003DzMuApP021PUyU[i].YieldShadow)
			{
				return true;
			}
		}
		return false;
	}

	protected IList<Entity> SortEntitiesForTransparency(Viewport viewport, IList<Entity> ents)
	{
		_0023_003Dz3yTehjY_1ZV5QPm48sNaXQlqR5IV8x_0024WIg_003D_003D comparer = ((viewport.DisplayMode != displayType.Shaded) ? ((_0023_003Dz3yTehjY_1ZV5QPm48sNaXQlqR5IV8x_0024WIg_003D_003D)new _0023_003DztL7IHxOdXPBiydjgJog_I4lYlVgShd7wLnGBG9I_003D(viewport.Camera.Location, Layers, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D)) : ((_0023_003Dz3yTehjY_1ZV5QPm48sNaXQlqR5IV8x_0024WIg_003D_003D)new _0023_003DzNz6gqU1mbbrx68v6hi0ZpJH3KTHbmwGlMpF7jO7pW2Yf(viewport.Camera.Location, Layers, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D)));
		List<Entity> list = new List<Entity>(ents);
		list.Sort(comparer);
		return list;
	}

	private void _0023_003Dz89cPk57rASTGmdmTnA_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, bool _0023_003DzPHqp5dQ_003D, RectangleF _0023_003DzF7kGEgqMZE2_, CameraEyePosType _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D, bool _0023_003Dzk7pNhlbdSzPJ)
	{
		_0023_003DzmNZD0Zs_003D.SetMatrices(null, null);
		if (!_0023_003DzPHqp5dQ_003D)
		{
			_0023_003DzizmWu9NqdXzq(_0023_003Dzj8Y3En1zLFs4: true, _0023_003DzPHqp5dQ_003D: false);
		}
		_0023_003DzYzWi5Yw_003D.Camera.SetupModelViewProjection(_0023_003DzF7kGEgqMZE2_, setGraphics: true, shadowPass: false, _0023_003DzPHqp5dQ_003D, _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D, applySceneTransformation: false);
		_0023_003DzizmWu9NqdXzq(_0023_003Dzj8Y3En1zLFs4: false, _0023_003DzPHqp5dQ_003D);
		_0023_003DzYzWi5Yw_003D.Camera.SetupModelView(setGraphics: true, _0023_003DzPHqp5dQ_003D, _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D, _0023_003Dzk7pNhlbdSzPJ);
		_0023_003DzmNZD0Zs_003D.SetSceneAmbient(Utility.ColorToFloatArray(_0023_003DzXVJ6CvJJYmrqf3ztQQ_003D_003D));
		_0023_003DzmNZD0Zs_003D.ProcessMaterial();
	}

	internal bool _0023_003DzaIkiwmUCZEncrNAqSQ_003D_003D()
	{
		double num = 0.0;
		switch (_0023_003DzLpjRly40lvq1)
		{
		case orientationType.UpAxisZ:
			num = _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr.Z - _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF.Z;
			break;
		case orientationType.UpAxisY:
			num = _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr.Y - _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF.Y;
			break;
		}
		return num / Entities.BoxSize.Max > 0.001;
	}

	private bool _0023_003Dzopq9Ty0GCUq5(LightSettings _0023_003DzDlBJzrs_003D, bool _0023_003Dzj8Y3En1zLFs4, bool _0023_003DzPHqp5dQ_003D, out float[] _0023_003Dz7fYqpNc_003D, out float[] _0023_003DzhEjPeMs_003D)
	{
		if ((_0023_003DzDlBJzrs_003D.Stationary && ((_0023_003Dzj8Y3En1zLFs4 && !_0023_003DzPHqp5dQ_003D) || (!_0023_003Dzj8Y3En1zLFs4 && _0023_003DzPHqp5dQ_003D))) || (!_0023_003DzDlBJzrs_003D.Stationary && !_0023_003Dzj8Y3En1zLFs4))
		{
			_0023_003DzDlBJzrs_003D.GetLightDirection(_0023_003DzPHqp5dQ_003D ? _0023_003DzClCMdT3GjxD8PGpNmg_003D_003D.ModelViewMatrix : null, out _0023_003Dz7fYqpNc_003D, out _0023_003DzhEjPeMs_003D);
			return true;
		}
		_0023_003Dz7fYqpNc_003D = (_0023_003DzhEjPeMs_003D = null);
		return false;
	}

	internal void _0023_003DzizmWu9NqdXzq(bool _0023_003Dzj8Y3En1zLFs4, bool _0023_003DzPHqp5dQ_003D)
	{
		LightSettings[] activeLights = _0023_003DzmNZD0Zs_003D.ActiveLights;
		for (int i = 0; i < activeLights.Length; i++)
		{
			LightSettings lightSettings = activeLights[i];
			if (lightSettings.Active && _0023_003Dzopq9Ty0GCUq5(lightSettings, _0023_003Dzj8Y3En1zLFs4, _0023_003DzPHqp5dQ_003D, out var _0023_003Dz7fYqpNc_003D, out var _0023_003DzhEjPeMs_003D))
			{
				_0023_003DzmNZD0Zs_003D.SetLightPosition(i, lightSettings.Type, _0023_003Dz7fYqpNc_003D, _0023_003DzhEjPeMs_003D);
			}
		}
	}

	protected virtual void DrawShadow(float drawScale)
	{
	}

	protected internal void PaintBackBuffer()
	{
		if (_0023_003Dz0P1LCYH__O4t() < 1 || _0023_003DzNwtRJ3cLTrAy() < 1 || _0023_003Dz8Q16RtM94O0K() || _0023_003Dzo_MNAFBAjuGu > 0 || _0023_003DzTAGVj_ePZ3pfzt_uDQ_003D_003D() || _0023_003DzmNZD0Zs_003D == null)
		{
			return;
		}
		_0023_003DzmNZD0Zs_003D.MakeCurrent();
		if (_0023_003DzZ5L0bhmvC_0024K7)
		{
			int _0023_003DzsLHxXyo_003D = _0023_003DzBn2ByFKdwrou;
			_0023_003Dzwp0pao5NhqfO();
			_0023_003DzBn2ByFKdwrou = _0023_003DzsLHxXyo_003D;
			if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
			{
				_0023_003DzipBYly6zFKAp()._0023_003Dzl_s8qNo_003D(0f, 1f);
			}
		}
		else if (_0023_003DzEve6E9qqZPdg >= 0)
		{
			_0023_003Dzwp0pao5NhqfO(_0023_003DzEve6E9qqZPdg);
		}
		_0023_003Dz79nZuepFnxns0RGZBQ_003D_003D(_0023_003DzMNQtdF5md6lME489aqjEcF0_003D: false);
		_0023_003DzhJ_0024tWgoKIkC8hUNqKg_003D_003D(new DrawSceneParams
		{
			DrawScale = 1f,
			Viewport = _0023_003DzipBYly6zFKAp(),
			SwapBuffer = true,
			IsDesignMode = false,
			RenderContext = _0023_003DzmNZD0Zs_003D,
			Blocks = _0023_003DzoE3BE__0024RS_DJ()
		});
	}

	protected internal void SwapBuffers()
	{
		if (!_0023_003Dz8Q16RtM94O0K() && _0023_003Dzo_MNAFBAjuGu <= 0 && !_0023_003DzTAGVj_ePZ3pfzt_uDQ_003D_003D() && _0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.SwapBuffers();
		}
	}

	protected internal virtual void DrawViewport(DrawSceneParams myParams)
	{
		_0023_003DzmNZD0Zs_003D.SetLineSize(1f, setShader: false);
		Viewport viewport = (Viewport)myParams.Viewport;
		viewport.Camera.UpdateConvergenceDistance();
		myParams.DoShadows = false;
		if (!myParams.ZBufferOnly)
		{
			myParams.DoShadows = _0023_003DzQthAg2kOXptfNjbNhQ_003D_003D() && viewport._0023_003DzK_00241ezHQJ9Z3c == displayType.Rendered && _0023_003Dzst7PSrE3exCjKedVKg_003D_003D();
		}
		viewport._0023_003DzdzRS8TI_003D(0.001f, 1f);
		if (viewport.Size.Width < 1 || viewport.Size.Height < 1)
		{
			return;
		}
		myParams.ShaderParams = null;
		if (viewport.Camera.ProjectionMode == projectionType.Orthographic)
		{
			viewport.Camera.AdjustNearAndFarPlanes();
		}
		if (_0023_003DzppsdDUxL8MoNpsvok2_0024eG4c_003D(myParams) || myParams.isProgressiveDrawing)
		{
			viewport.Camera.SetupModelViewProjection(myParams.ZoomRect, setGraphics: true, shadowPass: false, myParams.PlanarReflections, myParams.CameraEyePos, applySceneTransformation: false);
			myParams.Entities = _0023_003Dz5hg793fWBXXkDWvOWC__pM8_003D(_0023_003DzdWWqz40ROLb5Pp383A_003D_003D(_0023_003DzPEEjwoPxhT6e(viewport), myParams.Entities), new FrustumParams(viewport._0023_003DzLK0OwXvAsOsnI9nS_0024Q_003D_003D(myParams.PlanarReflections), quick: true, this), myParams);
		}
		if (!myParams.ZBufferOnly && myParams.DoShadows)
		{
			myParams.ShaderParams = _0023_003DzdfzPZ4BvPfHu(myParams);
			if (viewport.DisplayMode == displayType.Rendered && _0023_003DznKkOfo8_003D.ShadowMode == shadowType.Realistic && (!myParams.isProgressiveDrawing || _0023_003Dzo_MNAFBAjuGu == 0))
			{
				_0023_003DzADgrV_9c30Dj(myParams);
				if (_0023_003DzppsdDUxL8MoNpsvok2_0024eG4c_003D(myParams) || myParams.isProgressiveDrawing)
				{
					for (int i = 0; i < myParams.Entities.Count; i++)
					{
						myParams.Entities[i].visibleAndInFrustum = true;
					}
				}
			}
		}
		if (!myParams.isProgressiveDrawing || _0023_003Dzo_MNAFBAjuGu == 0)
		{
			if (_0023_003Dzo_MNAFBAjuGu == 0 && _0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(myParams))
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.ClearAllBuffers(Color.FromArgb(0, 0, 0, 0));
			}
			if (!myParams.ZBufferOnly)
			{
				DrawViewportBackground(myParams);
				if (_0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(viewport))
				{
					_0023_003DzmNZD0Zs_003D.staticSelectionCompositing.Clear(viewport._0023_003Dzr_AjDsvNuuYG(), _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D);
				}
			}
			_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
			if (_0023_003Dzo_MNAFBAjuGu == 0 && _0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(myParams))
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.CopyBackBufferTo(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons, color: true, depth: false);
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.ClearAllBuffers(Color.Empty, color: false);
			}
		}
		_0023_003Dzcz0XxBtQReNi_0024ibu6ZtaThXWgm78(myParams, viewport, out var _0023_003DzbAHrXhG3Q08G, out var _0023_003DzucryZ66s0GAU, out var _0023_003Dzn4qQNBUZ_qCZ);
		_0023_003DzXsG3_0024Rpj5_iYwQvVnA_003D_003D(Draw3D, myParams);
		if (myParams.ShowObjectManipulatorPreviewInScene)
		{
			_0023_003Dz6Zq8OC0Hs2lSPbwIhK3PnrfYAZe4(myParams, viewport, _0023_003DzbAHrXhG3Q08G, _0023_003DzucryZ66s0GAU, _0023_003Dzn4qQNBUZ_qCZ);
		}
		viewport.Camera.ZBufferData.Dirty = false;
		viewport.Camera.ResetProjectionMatrixStack();
	}

	private void _0023_003Dzcz0XxBtQReNi_0024ibu6ZtaThXWgm78(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, Viewport _0023_003DzYzWi5Yw_003D, out double _0023_003DzbAHrXhG3Q08G, out double _0023_003DzucryZ66s0GAU, out double[] _0023_003Dzn4qQNBUZ_qCZ)
	{
		_0023_003DzbAHrXhG3Q08G = 0.0;
		_0023_003DzucryZ66s0GAU = 0.0;
		_0023_003Dzn4qQNBUZ_qCZ = null;
		_0023_003DzCBM7XJK4_5H_0024.ShowObjectManipulatorPreviewInScene = _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D != null && (!_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.ShowPreviewOnTop || _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D()) && _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Visible && _0023_003DzCBM7XJK4_5H_0024.IsCurrentViewport();
		if (_0023_003DzCBM7XJK4_5H_0024.ShowObjectManipulatorPreviewInScene)
		{
			_0023_003DzbAHrXhG3Q08G = _0023_003DzYzWi5Yw_003D.Camera.Near;
			_0023_003DzucryZ66s0GAU = _0023_003DzYzWi5Yw_003D.Camera.Far;
			_0023_003Dzn4qQNBUZ_qCZ = new double[16];
			Array.Copy(_0023_003DzYzWi5Yw_003D.Camera.ProjectionMatrix, _0023_003Dzn4qQNBUZ_qCZ, 16);
			_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzTbFm48YmIfae(_0023_003DzYzWi5Yw_003D, _0023_003DzCBM7XJK4_5H_0024.ZoomRect, _0023_003DzCBM7XJK4_5H_0024.CameraEyePos);
			_0023_003DzXsG3_0024Rpj5_iYwQvVnA_003D_003D(_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzqOMaE4ZfTqy4, _0023_003DzCBM7XJK4_5H_0024);
		}
	}

	private void _0023_003Dz6Zq8OC0Hs2lSPbwIhK3PnrfYAZe4(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, Viewport _0023_003DzYzWi5Yw_003D, double _0023_003DzbAHrXhG3Q08G, double _0023_003DzucryZ66s0GAU, double[] _0023_003Dzn4qQNBUZ_qCZ)
	{
		_0023_003DzYzWi5Yw_003D.Camera.Near = _0023_003DzbAHrXhG3Q08G;
		_0023_003DzYzWi5Yw_003D.Camera.Far = _0023_003DzucryZ66s0GAU;
		Array.Copy(_0023_003Dzn4qQNBUZ_qCZ, _0023_003DzYzWi5Yw_003D.Camera.ProjectionMatrix, 16);
	}

	protected virtual void DrawViewportBackground(DrawSceneParams data)
	{
		Viewport obj = (Viewport)data.Viewport;
		obj._0023_003Dz191ozMVp28cu(data.RenderContext, _0023_003DzNwtRJ3cLTrAy(), data.ZoomRect, _0023_003DzPHqp5dQ_003D: false, 0f, _0023_003DzU7yFFKcRyseX(), _0023_003DzIHwNrERoZxEh: false);
		if (obj.DisplayMode == displayType.Rendered && _0023_003DznKkOfo8_003D.PlanarReflections && _0023_003DznKkOfo8_003D.PlanarReflectionsIntensity > 0f && !data.TransparentBackground() && _0023_003DzmNZD0Zs_003D.ReflectionsSupported)
		{
			_0023_003DzmNZD0Zs_003D.PushMatrices();
			if ((!data.isProgressiveDrawing || _0023_003Dzo_MNAFBAjuGu == 0) && _0023_003DzgiHXkyindbv2UqHRaQ_003D_003D(data))
			{
				_0023_003DzmNZD0Zs_003D.ProgDrawCompositingBase.CopyBackBufferTo(ProgDrawCompositingBase.progDrawFrameBuffer.ActivePolygons, color: true, depth: false);
			}
			_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
			_0023_003DzXsG3_0024Rpj5_iYwQvVnA_003D_003D(_0023_003Dz8OFw4fJIo_bHzzEEfGBYMwDs0bYK, data);
			_0023_003DzmNZD0Zs_003D.PopMatrices();
		}
	}

	internal void _0023_003DzXsG3_0024Rpj5_iYwQvVnA_003D_003D(_0023_003DzE92QaKyEx45_0024 _0023_003DzWMccOMDjvyjQ, DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.Anaglyph3D && _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.ProjectionMode == projectionType.Perspective)
		{
			_0023_003DzSopgdypqTjltLacqFOK3Q48_003D();
			_0023_003DzCBM7XJK4_5H_0024.CameraEyePos = CameraEyePosType.Left;
			_0023_003DzWMccOMDjvyjQ(_0023_003DzCBM7XJK4_5H_0024);
			_0023_003DzoRoTh134TiHJGRd_Bhha9TQ_003D();
			_0023_003DzCBM7XJK4_5H_0024.CameraEyePos = CameraEyePosType.Right;
			_0023_003DzWMccOMDjvyjQ(_0023_003DzCBM7XJK4_5H_0024);
			_0023_003DzS1EtT_Y0IX1BqDwE0g_003D_003D(_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera);
		}
		else
		{
			_0023_003DzCBM7XJK4_5H_0024.CameraEyePos = CameraEyePosType.Center;
			_0023_003DzWMccOMDjvyjQ(_0023_003DzCBM7XJK4_5H_0024);
		}
		_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.ResetProjectionMatrixStack();
	}

	internal ShaderParameters _0023_003DzdfzPZ4BvPfHu(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		return new ShaderParameters(_0023_003DzmNZD0Zs_003D, _0023_003DzCBM7XJK4_5H_0024.ViewFrame, _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera, _0023_003DznKkOfo8_003D.ShadowMode, _0023_003DznKkOfo8_003D.RealisticShadowQuality, _0023_003DzCBM7XJK4_5H_0024.Viewport.Background, _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D, _0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode == displayType.Rendered && _0023_003DznKkOfo8_003D.EnvironmentMapping, _0023_003DzCBM7XJK4_5H_0024.DrawScale, _0023_003DzCBM7XJK4_5H_0024.ZoomRect, CurrentTransformation ?? new Identity())
		{
			DoShadows = _0023_003DzCBM7XJK4_5H_0024.DoShadows
		};
	}

	private void _0023_003DzSopgdypqTjltLacqFOK3Q48_003D()
	{
		_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.Red | colorMaskFlags.Alpha);
	}

	private void _0023_003DzoRoTh134TiHJGRd_Bhha9TQ_003D()
	{
		_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.Green | colorMaskFlags.Blue | colorMaskFlags.Alpha);
	}

	private void _0023_003DzS1EtT_Y0IX1BqDwE0g_003D_003D(Camera _0023_003DzZ_0024IejP0R_0024_Cw)
	{
		_0023_003DzmNZD0Zs_003D.SetColorMask(colorMaskFlags.RGBA);
		_0023_003DzZ_0024IejP0R_0024_Cw.UpdateMatrices();
	}

	internal string _0023_003DzRgjbyjnWY98K(string _0023_003DzYQvHPFc_003D)
	{
		int num = 0;
		if (!_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D.TryGetValue(_0023_003DzYQvHPFc_003D, out var value))
		{
			return _0023_003DzYQvHPFc_003D;
		}
		while (_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D.TryGetValue(_0023_003DzYQvHPFc_003D + num, out value))
		{
			num++;
		}
		return _0023_003DzYQvHPFc_003D + num;
	}

	public Bitmap GetPresetManagerThumbnail(int thumbnailSize)
	{
		Size size = _0023_003DzTRjGTao_003D(base.Size, 512);
		Size size2 = base.Size;
		base.Size = size;
		_0023_003DzkQRTXiC03yes = true;
		DrawSceneParams _0023_003DzCBM7XJK4_5H_0024 = new DrawSceneParams
		{
			Viewport = (IsDesignMode() ? null : _0023_003DzipBYly6zFKAp()),
			DrawScale = 1f,
			LineWeightFactor = 1f,
			DrawOverlay = true,
			IsDesignMode = true,
			SwapBuffer = false,
			CaptureSurface = true,
			DrawAllUIElements = true,
			Thumbnail = true,
			Entities = Entities,
			Blocks = Blocks,
			RenderContext = _0023_003DzmNZD0Zs_003D,
			Bpp = 4
		};
		Bitmap bitmap = new Bitmap(size.Width, size.Height);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, size.Width, size.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
		_0023_003DzxZAI1cgKJ8nHr9eHHQ_003D_003D(_0023_003DzCBM7XJK4_5H_0024, 0, 0, size.Width, size.Height, bitmapData, null, _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D: true, _0023_003Dz6LfbgRAYOjvE);
		bitmap.UnlockBits(bitmapData);
		bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
		base.Size = size2;
		if (thumbnailSize > 256)
		{
			thumbnailSize = 256;
		}
		Bitmap result = new Bitmap(bitmap, _0023_003DzTRjGTao_003D(base.Size, thumbnailSize));
		bitmap.Dispose();
		_0023_003DzkQRTXiC03yes = false;
		return result;
	}

	internal static Size _0023_003DzTRjGTao_003D(Size _0023_003Dz0ERMHbg_003D, int _0023_003DzBPqZHAs_003D)
	{
		int num = _0023_003Dz0ERMHbg_003D.Width;
		int num2 = _0023_003Dz0ERMHbg_003D.Height;
		double num3 = (double)num / (double)num2;
		if (num > num2)
		{
			num = _0023_003DzBPqZHAs_003D;
			num2 = (int)((double)num / num3);
		}
		else
		{
			num2 = _0023_003DzBPqZHAs_003D;
			num = (int)((double)num2 * num3);
		}
		return new Size(num, num2);
	}

	private Stack<BlockReference> _0023_003DzZuBsUvr900Ui(DrawParams _0023_003DzmfiOMu6nigKS)
	{
		return _0023_003DzmfiOMu6nigKS.FullParents;
	}

	[DllImport("gdi32.dll")]
	public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

	[DllImport("gdi32.dll")]
	public static extern IntPtr DeleteObject(IntPtr bmp);

	protected internal Size DrawText(int x, int y, string text, Font textFont, Color textColor, ContentAlignment textAlign)
	{
		return DrawText(x, y, text, textFont, textColor, Color.Empty, textAlign, RotateFlipType.Rotate180FlipX);
	}

	protected internal Size DrawText(int x, int y, string text, Font textFont, Color textColor, Color fillColor, ContentAlignment textAlign)
	{
		return DrawText(x, y, text, textFont, textColor, fillColor, textAlign, RotateFlipType.Rotate180FlipX);
	}

	protected internal Size DrawText(int x, int y, string text, Font textFont, Color textColor, Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip)
	{
		_0023_003Dz4cMrjAkIhb6J(x, y, text, textFont, textColor, fillColor, textAlign, rotateFlip, out var _0023_003DzHk91AdQ7qeHY);
		return _0023_003DzHk91AdQ7qeHY.Size;
	}

	internal void _0023_003Dz4cMrjAkIhb6J(int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, string _0023_003DzgWGS4uo_003D, Font _0023_003DzDKqDnmtyvc31, Color _0023_003Dzlxpb_Og_003D, Color _0023_003DzgUg07Uk_003D, ContentAlignment _0023_003DzyPgqEp4WuoqF, RotateFlipType _0023_003DzgumMmXEw_0024MRuB8uEuw_003D_003D, out Rectangle _0023_003DzHk91AdQ7qeHY)
	{
		Bitmap textImage = GetTextImage(_0023_003DzgWGS4uo_003D, _0023_003DzDKqDnmtyvc31, _0023_003Dzlxpb_Og_003D, _0023_003DzgUg07Uk_003D, _0023_003DzyPgqEp4WuoqF, _0023_003DzgumMmXEw_0024MRuB8uEuw_003D_003D);
		_0023_003DzCWfxG0qvWJNe(textImage, _0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzyPgqEp4WuoqF, out _0023_003DzHk91AdQ7qeHY);
		textImage.Dispose();
	}

	private void _0023_003DzCWfxG0qvWJNe(Bitmap _0023_003DzoMb5r_0024o_003D, int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, ContentAlignment _0023_003DzyPgqEp4WuoqF, out Rectangle _0023_003DzHk91AdQ7qeHY)
	{
		TextureBase textureBase = _0023_003DzmNZD0Zs_003D.CreateTexture2D(_0023_003DzoMb5r_0024o_003D, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, enlargeIfSizeNotSupported: true);
		_0023_003DzmNZD0Zs_003D.PushShader();
		_0023_003DzmNZD0Zs_003D.PushBlendState();
		_0023_003DzwCL3lEhabo_0024g(_0023_003DzmNZD0Zs_003D, textureBase, _0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzyPgqEp4WuoqF, _0023_003DzPuIG8z4Ok7Hn: false, _0023_003DzJQ_0024zQtc_003D: true, out _0023_003DzHk91AdQ7qeHY);
		_0023_003DzmNZD0Zs_003D.PopBlendState();
		_0023_003DzmNZD0Zs_003D.PopShader();
		textureBase.Dispose();
	}

	protected Bitmap GetTextImage(string text, Font font, Color color, Color fillColor, ContentAlignment textAlign, RotateFlipType rotateFlip, bool antialias = true)
	{
		if (color.ToArgb() == fillColor.ToArgb())
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594695));
		}
		Bitmap _0023_003DzoMb5r_0024o_003D = _0023_003DzRFGA2zTmmjXj(text, font, color, fillColor, _0023_003DzZUohT3Y_003D, rotateFlip, antialias, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
		if (fillColor.A > 0 || (textAlign != ContentAlignment.BottomLeft && textAlign != ContentAlignment.MiddleLeft && textAlign != ContentAlignment.TopLeft))
		{
			_0023_003Dze0mIdOoE_ebo(ref _0023_003DzoMb5r_0024o_003D, fillColor);
		}
		return _0023_003DzoMb5r_0024o_003D;
	}

	private static void _0023_003DzLGy56aIVS2ab2GUVBA_003D_003D(ref Bitmap _0023_003DzoMb5r_0024o_003D, Color _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D)
	{
		int _0023_003Dz7PIPnGI_003D;
		int _0023_003DzssihP0ihgi5u;
		byte[] array = _0023_003DzMcsHWpzURn_0024T(_0023_003DzoMb5r_0024o_003D, out _0023_003Dz7PIPnGI_003D, out _0023_003DzssihP0ihgi5u);
		int num = 0;
		int num2 = 0;
		int num3 = _0023_003Dz7PIPnGI_003D;
		if (_0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.A == 0)
		{
			for (int i = 0; i < _0023_003DzoMb5r_0024o_003D.Height; i++)
			{
				int num4 = num + 3;
				int num5 = 0;
				while (num5 < _0023_003Dz7PIPnGI_003D)
				{
					if (array[num4] != 0)
					{
						if (num5 > num2)
						{
							num2 = num5;
						}
						if (num5 < num3)
						{
							num3 = num5;
						}
					}
					num5 += 4;
					num4 += 4;
				}
				num += _0023_003DzssihP0ihgi5u;
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzoMb5r_0024o_003D.Height; j++)
			{
				int num6 = num;
				int num7 = 0;
				while (num7 < _0023_003Dz7PIPnGI_003D)
				{
					byte b = array[num6];
					byte b2 = array[num6 + 1];
					byte b3 = array[num6 + 2];
					byte b4 = array[num6 + 3];
					if (b3 != _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.R || b2 != _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.G || b != _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.B || b4 != _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.A)
					{
						if (num7 > num2)
						{
							num2 = num7;
						}
						if (num7 < num3)
						{
							num3 = num7;
						}
					}
					num7 += 4;
					num6 += 4;
				}
				num += _0023_003DzssihP0ihgi5u;
			}
		}
		num3 /= 4;
		num2 /= 4;
		num3--;
		num2++;
		if ((num2 > 0 && num2 < _0023_003DzoMb5r_0024o_003D.Width) || (num3 > 0 && num3 < _0023_003DzoMb5r_0024o_003D.Width))
		{
			Bitmap bitmap = new Bitmap(num2 - num3, _0023_003DzoMb5r_0024o_003D.Height, _0023_003DzoMb5r_0024o_003D.PixelFormat);
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			graphics.DrawImage(_0023_003DzoMb5r_0024o_003D, -num3, 0);
			graphics.Dispose();
			_0023_003DzoMb5r_0024o_003D.Dispose();
			_0023_003DzoMb5r_0024o_003D = bitmap;
		}
	}

	private void _0023_003Dze0mIdOoE_ebo(ref Bitmap _0023_003DzoMb5r_0024o_003D, Color _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D)
	{
		int _0023_003Dz7PIPnGI_003D;
		int _0023_003DzssihP0ihgi5u;
		byte[] array = _0023_003DzMcsHWpzURn_0024T(_0023_003DzoMb5r_0024o_003D, out _0023_003Dz7PIPnGI_003D, out _0023_003DzssihP0ihgi5u);
		int num = 0;
		int num2 = 0;
		if (_0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.A == 0)
		{
			for (int i = 0; i < _0023_003DzoMb5r_0024o_003D.Height; i++)
			{
				int num3 = num + 3;
				int num4 = 0;
				while (num4 < _0023_003Dz7PIPnGI_003D)
				{
					if (array[num3] != 0 && num4 > num2)
					{
						num2 = num4;
					}
					num4 += 4;
					num3 += 4;
				}
				num += _0023_003DzssihP0ihgi5u;
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzoMb5r_0024o_003D.Height; j++)
			{
				int num5 = num;
				int num6 = 0;
				while (num6 < _0023_003Dz7PIPnGI_003D)
				{
					byte b = array[num5];
					byte b2 = array[num5 + 1];
					byte b3 = array[num5 + 2];
					byte b4 = array[num5 + 3];
					if ((b3 != _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.R || b2 != _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.G || b != _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.B || b4 != _0023_003Dzf_Ksi9Vf1VASQ18HJA_003D_003D.A) && num6 > num2)
					{
						num2 = num6;
					}
					num6 += 4;
					num5 += 4;
				}
				num += _0023_003DzssihP0ihgi5u;
			}
		}
		num2 /= 4;
		num2 += _0023_003DzoMb5r_0024o_003D.Height / 6;
		if (num2 > 0 && num2 < _0023_003DzoMb5r_0024o_003D.Width)
		{
			Bitmap bitmap = new Bitmap(num2, _0023_003DzoMb5r_0024o_003D.Height, _0023_003DzoMb5r_0024o_003D.PixelFormat);
			System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
			graphics.DrawImage(_0023_003DzoMb5r_0024o_003D, 0, 0);
			graphics.Dispose();
			_0023_003DzoMb5r_0024o_003D.Dispose();
			_0023_003DzoMb5r_0024o_003D = bitmap;
		}
	}

	private static byte[] _0023_003DzMcsHWpzURn_0024T(Bitmap _0023_003DzoMb5r_0024o_003D, out int _0023_003Dz7PIPnGI_003D, out int _0023_003DzssihP0ihgi5u)
	{
		Rectangle rect = new Rectangle(0, 0, _0023_003DzoMb5r_0024o_003D.Width, _0023_003DzoMb5r_0024o_003D.Height);
		BitmapData bitmapData = _0023_003DzoMb5r_0024o_003D.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		int num = bitmapData.Stride * bitmapData.Height;
		byte[] array = new byte[num];
		IntPtr scan = bitmapData.Scan0;
		_0023_003Dz7PIPnGI_003D = Math.Min(bitmapData.Stride, _0023_003DzoMb5r_0024o_003D.Width * 4);
		Marshal.Copy(scan, array, 0, num);
		_0023_003DzssihP0ihgi5u = bitmapData.Stride;
		_0023_003DzoMb5r_0024o_003D.UnlockBits(bitmapData);
		return array;
	}

	internal void _0023_003Dzu73ezHSl_00246dq(int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, Bitmap _0023_003DzoMb5r_0024o_003D, ContentAlignment _0023_003DzyPgqEp4WuoqF, bool _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D, bool _0023_003DzPuIG8z4Ok7Hn)
	{
		TextureBase textureBase = _0023_003DzmNZD0Zs_003D.CreateTexture2D(_0023_003DzoMb5r_0024o_003D, textureFilteringFunctionType.Linear, textureFilteringFunctionType.Linear, anisotropicFiltering: true, _0023_003Dzj_0024fRfFoTIUIImaQq_DcuYEs_003D);
		_0023_003DzwCL3lEhabo_0024g(_0023_003DzmNZD0Zs_003D, textureBase, _0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzyPgqEp4WuoqF, _0023_003DzPuIG8z4Ok7Hn, _0023_003DzJQ_0024zQtc_003D: true, out var _);
		textureBase.Dispose();
	}

	protected void DrawTexture(TextureBase texture, int x, int y, ContentAlignment align, bool flipY = false)
	{
		_0023_003DzwCL3lEhabo_0024g(_0023_003DzmNZD0Zs_003D, texture, x, y, align, flipY, _0023_003DzJQ_0024zQtc_003D: true, out var _);
	}

	internal static void _0023_003DzwCL3lEhabo_0024g(RenderContextBase _0023_003DzmNZD0Zs_003D, TextureBase _0023_003Dz_IfKSJY_003D, int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, ContentAlignment _0023_003DzyPgqEp4WuoqF, bool _0023_003DzPuIG8z4Ok7Hn, bool _0023_003DzJQ_0024zQtc_003D, out Rectangle _0023_003Dz6g4Y6AMwu8y5)
	{
		Size size = ((_0023_003Dz_IfKSJY_003D.BitmapSize.Width <= _0023_003Dz_IfKSJY_003D.Size.Width) ? _0023_003Dz_IfKSJY_003D.BitmapSize : _0023_003Dz_IfKSJY_003D.Size);
		_0023_003Dz5xHaFz6XVogi(_0023_003DzmNZD0Zs_003D, _0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, size.Width, size.Height, _0023_003DzyPgqEp4WuoqF, out var _0023_003DzGuW5l4E_003D, out var _0023_003DzVDBzBJQ_003D);
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Texture2DNoLights);
		if (_0023_003DzJQ_0024zQtc_003D)
		{
			_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		}
		float num = (float)_0023_003Dz_IfKSJY_003D.BitmapSize.Width / (float)_0023_003Dz_IfKSJY_003D.Size.Width;
		float num2 = (float)_0023_003Dz_IfKSJY_003D.BitmapSize.Height / (float)_0023_003Dz_IfKSJY_003D.Size.Height;
		float num3 = 0f;
		float num4 = num2;
		if (_0023_003DzPuIG8z4Ok7Hn)
		{
			num3 = num2;
			num4 = 0f;
		}
		_0023_003DzmNZD0Zs_003D.DrawQuadWithTextures(_0023_003Dz_IfKSJY_003D, new float[8] { 0f, num3, num, num3, num, num4, 0f, num4 }, byte.MaxValue, new RectangleF(_0023_003DzGuW5l4E_003D, _0023_003DzVDBzBJQ_003D, size.Width, size.Height), 0f, buffered: false);
		_0023_003Dz6g4Y6AMwu8y5 = new Rectangle((int)_0023_003DzGuW5l4E_003D, (int)_0023_003DzVDBzBJQ_003D, size.Width, size.Height);
	}

	private static void _0023_003Dz5xHaFz6XVogi(RenderContextBase _0023_003DzoC62DbA_003D, float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, int _0023_003DznM_BbKmsCSNL, int _0023_003DzT14JKKonT6uo, ContentAlignment _0023_003DzyPgqEp4WuoqF, out float _0023_003DzGuW5l4E_003D, out float _0023_003DzVDBzBJQ_003D)
	{
		_0023_003DzGuW5l4E_003D = 0f;
		_0023_003DzVDBzBJQ_003D = 0f;
		switch (_0023_003DzyPgqEp4WuoqF)
		{
		case ContentAlignment.BottomLeft:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D;
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D;
			break;
		case ContentAlignment.BottomCenter:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D - (float)(_0023_003DznM_BbKmsCSNL / 2);
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D;
			break;
		case ContentAlignment.BottomRight:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D - (float)_0023_003DznM_BbKmsCSNL;
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D;
			break;
		case ContentAlignment.MiddleLeft:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D;
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D - (float)(_0023_003DzT14JKKonT6uo / 2);
			break;
		case ContentAlignment.MiddleCenter:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D - (float)(_0023_003DznM_BbKmsCSNL / 2);
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D - (float)(_0023_003DzT14JKKonT6uo / 2);
			break;
		case ContentAlignment.MiddleRight:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D - (float)_0023_003DznM_BbKmsCSNL;
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D - (float)(_0023_003DzT14JKKonT6uo / 2);
			break;
		case ContentAlignment.TopLeft:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D;
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D - (float)_0023_003DzT14JKKonT6uo;
			break;
		case ContentAlignment.TopCenter:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D - (float)(_0023_003DznM_BbKmsCSNL / 2);
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D - (float)_0023_003DzT14JKKonT6uo;
			break;
		case ContentAlignment.TopRight:
			_0023_003DzGuW5l4E_003D = _0023_003Dz8GBMuoM_003D - (float)_0023_003DznM_BbKmsCSNL;
			_0023_003DzVDBzBJQ_003D = _0023_003DzJU0R6e0_003D - (float)_0023_003DzT14JKKonT6uo;
			break;
		}
	}

	protected internal void DrawTextOutlined(int x, int y, string text, Font textFont, Color textColor, Color outlineColor, float outlineThickness, ContentAlignment textAlign)
	{
		_0023_003Dz7jAuuGUOjwBrKpkzbPtlK4s_003D(x, y, text, textFont, textColor, outlineColor, outlineThickness, textAlign, out var _);
	}

	internal void _0023_003Dz7jAuuGUOjwBrKpkzbPtlK4s_003D(int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, string _0023_003DzgWGS4uo_003D, Font _0023_003DzDKqDnmtyvc31, Color _0023_003Dzlxpb_Og_003D, Color _0023_003DzD3HZksZ9Qx_0024tL0fpNg_003D_003D, float _0023_003DzftC4d5P_0024m7TTmdiYig_003D_003D, ContentAlignment _0023_003DzyPgqEp4WuoqF, out Rectangle _0023_003DzHk91AdQ7qeHY)
	{
		Bitmap textOutlinedImage = GetTextOutlinedImage(_0023_003DzgWGS4uo_003D, _0023_003DzDKqDnmtyvc31, _0023_003Dzlxpb_Og_003D, _0023_003DzD3HZksZ9Qx_0024tL0fpNg_003D_003D, RotateFlipType.Rotate180FlipX, _0023_003DzftC4d5P_0024m7TTmdiYig_003D_003D);
		_0023_003DzCWfxG0qvWJNe(textOutlinedImage, _0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzyPgqEp4WuoqF, out _0023_003DzHk91AdQ7qeHY);
		textOutlinedImage.Dispose();
	}

	protected internal void DrawImage(int x, int y, Bitmap image)
	{
		_0023_003DzmNZD0Zs_003D.PushBlendState();
		_0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
		TextureBase textureBase = _0023_003DzmNZD0Zs_003D.CreateTexture2D(image, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: true, enlargeIfSizeNotSupported: true);
		DrawTexture(textureBase, x, y, ContentAlignment.BottomLeft, flipY: true);
		_0023_003DzmNZD0Zs_003D.PopBlendState();
		textureBase.Dispose();
	}

	internal static Bitmap _0023_003DzRFGA2zTmmjXj(string _0023_003DzgWGS4uo_003D, Font _0023_003Dz6FupbG0_003D, Color _0023_003Dzlxpb_Og_003D, Color _0023_003DzgUg07Uk_003D, IntPtr _0023_003DzVg1BG_0024g_003D, RotateFlipType _0023_003DzgumMmXEw_0024MRuB8uEuw_003D_003D, bool _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D, bool _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D, Color _0023_003Dz_MTHyUzel9SB, int _0023_003DzvjTHbaTV_0024Ffg)
	{
		Bitmap bitmap;
		using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(_0023_003DzVg1BG_0024g_003D))
		{
			SizeF sizeF = graphics.MeasureString(_0023_003DzgWGS4uo_003D, _0023_003Dz6FupbG0_003D);
			if (sizeF.IsEmpty)
			{
				sizeF = new SizeF(1f, 1f);
			}
			bitmap = new Bitmap((int)Math.Ceiling(sizeF.Width), (int)Math.Ceiling(sizeF.Height), PixelFormat.Format32bppArgb);
			using System.Drawing.Graphics graphics2 = System.Drawing.Graphics.FromImage(bitmap);
			SolidBrush solidBrush = new SolidBrush(_0023_003Dzlxpb_Og_003D);
			try
			{
				if (_0023_003DzgUg07Uk_003D.A > 0 && _0023_003DzgUg07Uk_003D.A < byte.MaxValue && _0023_003DzvjTHbaTV_0024Ffg == 0)
				{
					Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
					BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);
					IntPtr scan = bitmapData.Scan0;
					int num = bitmap.Width * bitmap.Height;
					int[] array = new int[num];
					Marshal.Copy(scan, array, 0, num);
					int num2 = _0023_003DzgUg07Uk_003D.ToArgb();
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = num2;
					}
					Marshal.Copy(array, 0, scan, num);
					bitmap.UnlockBits(bitmapData);
				}
				else if (_0023_003DzvjTHbaTV_0024Ffg > 0)
				{
					graphics2.Clear(_0023_003DzgUg07Uk_003D);
					if (bitmap.Width > 1)
					{
						_0023_003DzSgzazzdw8Vavikx09Eyn_0024rQ_003D(bitmap, _0023_003DzgUg07Uk_003D, _0023_003DzvjTHbaTV_0024Ffg);
					}
				}
				else
				{
					graphics2.Clear(_0023_003DzgUg07Uk_003D);
				}
				if (_0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D)
				{
					graphics2.SmoothingMode = SmoothingMode.HighQuality;
					graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
					graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
				}
				else
				{
					graphics2.SmoothingMode = SmoothingMode.HighSpeed;
					graphics2.InterpolationMode = InterpolationMode.NearestNeighbor;
					graphics2.TextRenderingHint = TextRenderingHint.SystemDefault;
				}
				if (_0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D)
				{
					_0023_003DzwTEy1TMJ1Wm2rGQhnA_003D_003D(_0023_003DzgWGS4uo_003D, _0023_003Dz6FupbG0_003D, _0023_003Dzlxpb_Og_003D, _0023_003Dz_MTHyUzel9SB, 1f, graphics2, 0f, 0f);
				}
				else
				{
					graphics2.DrawString(_0023_003DzgWGS4uo_003D, _0023_003Dz6FupbG0_003D, solidBrush, 0f, 0f);
				}
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}
		bitmap.RotateFlip(_0023_003DzgumMmXEw_0024MRuB8uEuw_003D_003D);
		return bitmap;
	}

	private static void _0023_003DzSgzazzdw8Vavikx09Eyn_0024rQ_003D(Bitmap _0023_003DzVn_Y3Uk14rqo, Color _0023_003DzgUg07Uk_003D, int _0023_003DzvjTHbaTV_0024Ffg)
	{
		_0023_003DzVn_Y3Uk14rqo.SetPixel(0, 0, Color.Transparent);
		_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, 0, Color.Transparent);
		_0023_003DzVn_Y3Uk14rqo.SetPixel(0, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
		_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
		if (_0023_003DzvjTHbaTV_0024Ffg > 1)
		{
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(2, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 3, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, _0023_003DzVn_Y3Uk14rqo.Height - 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, _0023_003DzVn_Y3Uk14rqo.Height - 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, _0023_003DzVn_Y3Uk14rqo.Height - 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(2, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, _0023_003DzVn_Y3Uk14rqo.Height - 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, _0023_003DzVn_Y3Uk14rqo.Height - 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 3, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, _0023_003DzVn_Y3Uk14rqo.Height - 3, Color.Transparent);
		}
		if (_0023_003DzvjTHbaTV_0024Ffg > 2)
		{
			_0023_003DzVn_Y3Uk14rqo.SetPixel(3, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(4, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(5, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, 4, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, 5, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(2, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(3, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(4, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, 4, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(2, 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 4, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 5, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 6, 0, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, 4, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, 5, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 3, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 4, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 5, 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, 4, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 3, 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(3, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(4, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(5, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 4, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(0, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 5, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(2, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(3, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(4, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 4, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(2, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 4, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 5, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 6, _0023_003DzVn_Y3Uk14rqo.Height - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 4, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 1, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 5, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 3, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 4, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 5, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 1, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 2, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 3, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 4, Color.Transparent);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 3, _0023_003DzVn_Y3Uk14rqo.Height - 1 - 2, Color.Transparent);
		}
		Color color = Color.FromArgb(127, _0023_003DzgUg07Uk_003D);
		switch (_0023_003DzvjTHbaTV_0024Ffg)
		{
		case 2:
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, 1, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, 1, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, _0023_003DzVn_Y3Uk14rqo.Height - 2, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, _0023_003DzVn_Y3Uk14rqo.Height - 2, color);
			break;
		case 3:
			_0023_003DzVn_Y3Uk14rqo.SetPixel(2, 2, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, 4, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(4, 1, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 3, 2, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, 4, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 5, 1, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(2, _0023_003DzVn_Y3Uk14rqo.Height - 3, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(1, _0023_003DzVn_Y3Uk14rqo.Height - 5, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(4, _0023_003DzVn_Y3Uk14rqo.Height - 2, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 3, _0023_003DzVn_Y3Uk14rqo.Height - 3, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 2, _0023_003DzVn_Y3Uk14rqo.Height - 5, color);
			_0023_003DzVn_Y3Uk14rqo.SetPixel(_0023_003DzVn_Y3Uk14rqo.Width - 5, _0023_003DzVn_Y3Uk14rqo.Height - 2, color);
			break;
		}
	}

	protected internal static Bitmap GetTextOutlinedImage(string text, Font font, Color color, Color outlineColor, RotateFlipType rotateFlip, float thickness)
	{
		Bitmap bitmap = null;
		using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
		{
			SizeF sizeF = graphics.MeasureString(text, font);
			if (sizeF.IsEmpty)
			{
				sizeF = new SizeF(1f, 1f);
			}
			bitmap = new Bitmap((int)Math.Ceiling(sizeF.Width + thickness), (int)Math.Ceiling(sizeF.Height + thickness));
			using System.Drawing.Graphics graphics2 = System.Drawing.Graphics.FromImage(bitmap);
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.InterpolationMode = InterpolationMode.HighQualityBilinear;
			graphics2.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
			_0023_003DzwTEy1TMJ1Wm2rGQhnA_003D_003D(text, font, color, outlineColor, thickness, graphics2, 0f, 0f);
		}
		bitmap.RotateFlip(rotateFlip);
		return bitmap;
	}

	internal static void _0023_003DzwTEy1TMJ1Wm2rGQhnA_003D_003D(string _0023_003DzgWGS4uo_003D, Font _0023_003Dz6FupbG0_003D, Color _0023_003Dzhpb8QNg_003D, Color _0023_003DzD3HZksZ9Qx_0024tL0fpNg_003D_003D, float _0023_003DzTDqOjIm8hokP7wQY3g_003D_003D, System.Drawing.Graphics _0023_003Dz1xtNHug_003D, float _0023_003DzXI0kc5Y_003D, float _0023_003DzZkDwBWE_003D)
	{
		SolidBrush solidBrush = new SolidBrush(_0023_003DzD3HZksZ9Qx_0024tL0fpNg_003D_003D);
		try
		{
			SolidBrush solidBrush2 = new SolidBrush(_0023_003Dzhpb8QNg_003D);
			try
			{
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						_0023_003Dz1xtNHug_003D.DrawString(_0023_003DzgWGS4uo_003D, _0023_003Dz6FupbG0_003D, solidBrush, _0023_003DzXI0kc5Y_003D + (float)i * _0023_003DzTDqOjIm8hokP7wQY3g_003D_003D, _0023_003DzZkDwBWE_003D + (float)j * _0023_003DzTDqOjIm8hokP7wQY3g_003D_003D);
					}
				}
				_0023_003Dz1xtNHug_003D.DrawString(_0023_003DzgWGS4uo_003D, _0023_003Dz6FupbG0_003D, solidBrush2, _0023_003DzXI0kc5Y_003D + _0023_003DzTDqOjIm8hokP7wQY3g_003D_003D, _0023_003DzZkDwBWE_003D + _0023_003DzTDqOjIm8hokP7wQY3g_003D_003D);
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
	}

	internal void _0023_003DzQmpF9ucFWaYSd_ec6pQQq6E_003D(Font _0023_003Dz6FupbG0_003D, double _0023_003DzspS9PE7w1VowYulluw_003D_003D)
	{
	}

	internal Transformation _0023_003DzFq8cO_00245h9dst()
	{
		if (CurrentTransformation != null)
		{
			if (_0023_003DzNcd94uIe40G1 == null)
			{
				_0023_003DzNcd94uIe40G1 = (Transformation)CurrentTransformation.Clone();
				_0023_003DzNcd94uIe40G1.Invert();
			}
			return _0023_003DzNcd94uIe40G1;
		}
		return null;
	}

	public void OpenCurrentBlock(bool updateBoundingBox = true)
	{
		if (CurrentBlockReference != null)
		{
			SaveView(out _0023_003DzzFGpNZit9CtK.Peek().Camera);
			_0023_003DzzFGpNZit9CtK.Push(new OpenBlockData(Blocks[CurrentBlockReference.BlockName]));
			_0023_003DzmqsGvi6ju9zO();
			if (updateBoundingBox)
			{
				UpdateBoundingBox();
			}
		}
	}

	public void CloseOpenBlock(bool updateBoundingBox = true)
	{
		if (!IsOpenRootLevel)
		{
			_0023_003DzPXm4mIIHkAQ_0024(_0023_003DzgKkl_0024ivLmKr3: false);
			_0023_003DzzFGpNZit9CtK.Pop().Dispose();
			RestoreView(_0023_003DzzFGpNZit9CtK.Peek().Camera);
			_0023_003DzmqsGvi6ju9zO();
			if (updateBoundingBox)
			{
				UpdateBoundingBox();
			}
		}
	}

	public void ResetOpenBlocks(bool updateBoundingBox = true)
	{
		_0023_003DzvKRiFE5qp2u2XyCfhw_003D_003D(updateBoundingBox, _0023_003DzIdFNsJJS3mub: false);
		if (this is Design { CurrentSketch: not null } design)
		{
			design.CurrentSketch.Exit();
		}
	}

	private void _0023_003DzvKRiFE5qp2u2XyCfhw_003D_003D(bool _0023_003DzgKkl_0024ivLmKr3, bool _0023_003DzIdFNsJJS3mub)
	{
		while (_0023_003DzzFGpNZit9CtK.Count > 1)
		{
			_0023_003DzPXm4mIIHkAQ_0024(_0023_003DzgKkl_0024ivLmKr3: false);
			_0023_003DzzFGpNZit9CtK.Pop().Dispose();
			RestoreView(_0023_003DzzFGpNZit9CtK.Peek().Camera);
		}
		if (_0023_003DzzFGpNZit9CtK.Count == 1)
		{
			_0023_003DzPXm4mIIHkAQ_0024(_0023_003DzgKkl_0024ivLmKr3: false);
			if (_0023_003DzIdFNsJJS3mub)
			{
				_0023_003DzzFGpNZit9CtK.Pop().Dispose();
			}
		}
		if (_0023_003DzgKkl_0024ivLmKr3)
		{
			UpdateBoundingBox();
		}
	}

	public void SetCurrentStack(Stack<BlockReference> parents, bool updateBoundingBox = true)
	{
		if (parents == null || parents.Count == 0)
		{
			SetCurrent(null, updateBoundingBox);
			return;
		}
		BlockReference[] array = parents.Reverse().ToArray();
		int num = array.Length - 1;
		BlockReference[] array2 = array;
		foreach (BlockReference blockReference in array2)
		{
			SetCurrent(blockReference, updateBoundingBox: false);
			num--;
		}
		if (updateBoundingBox)
		{
			UpdateBoundingBox();
		}
	}

	public Transformation GetStackTransformation(Stack<BlockReference> parents)
	{
		Transformation transformation = new Identity();
		foreach (BlockReference parent in parents)
		{
			transformation = parent.GetFullTransformation(Blocks) * transformation;
		}
		return transformation;
	}

	public void SetCurrent(BlockReference blockReference, bool updateBoundingBox = true)
	{
		if (blockReference == null)
		{
			_0023_003DzPXm4mIIHkAQ_0024(updateBoundingBox);
			return;
		}
		if (_0023_003DzjczFwk1Qrlg9QkeecQ_003D_003D != null)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594759));
		}
		if (_0023_003DzomkzA6ARKGCOzn9ijw_003D_003D != null)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595102));
		}
		if (blockReference is ParentBlockReference)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595153) + blockReference.BlockName + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594974));
		}
		bool flag = _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Count == 0;
		int num = 0;
		BlockKeyedCollection blockKeyedCollection = _0023_003DzoE3BE__0024RS_DJ();
		string text;
		do
		{
			text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594982) + num++;
		}
		while (blockKeyedCollection.Contains(text));
		Block block = new Block(text);
		block.Entities.AddRange(Entities);
		int num2 = _0023_003DzVjDe_0024LiqB9qw(block.Entities, blockReference);
		if (num2 < 0)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594997));
		}
		blockReference.PropagateParentAttributes(flag ? null : _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Peek().BlockReference, this);
		blockReference.Selected = false;
		block.Entities.RemoveAtNoDispose(num2);
		if (!flag)
		{
			block.Entities.Add(_0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Peek().ParentSceneBlockReference);
		}
		_0023_003DzOA_ac7k_003D.Add(block);
		ParentBlockReference parentBlockReference = new ParentBlockReference(0.0, 0.0, 0.0, text, 0.0);
		Layers.CheckAndFixDefaultLayerName(parentBlockReference);
		if (!flag)
		{
			_0023_003Dzij8WUPNUwpjS(_0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Peek(), parentBlockReference);
		}
		_0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Push(new CurrentBlockRefData(num2, blockReference, parentBlockReference));
		_0023_003DzNcd94uIe40G1 = null;
		parentBlockReference.Transformation = (Transformation)CurrentBlockReference.GetFullTransformation(Blocks).Clone();
		parentBlockReference.Transformation.Invert();
		parentBlockReference.RegenMode = regenType.NotNeeded;
		UpdateVisibleSelection();
		_0023_003DzmqsGvi6ju9zO();
		parentBlockReference.UpdateBoundingBoxQuick(new TraversalParams(this, _0023_003DzoE3BE__0024RS_DJ()));
		if (updateBoundingBox)
		{
			UpdateBoundingBox();
		}
	}

	internal void _0023_003DzaxZuxNzApM2J()
	{
		_0023_003DzvKRiFE5qp2u2XyCfhw_003D_003D(_0023_003DzgKkl_0024ivLmKr3: false, _0023_003DzIdFNsJJS3mub: true);
		_0023_003DzzFGpNZit9CtK.Push(new OpenBlockData(RootBlock));
		_0023_003DzNcd94uIe40G1 = null;
	}

	private void _0023_003Dzij8WUPNUwpjS(CurrentBlockRefData _0023_003DzCnHpCsW0MuB3, ParentBlockReference _0023_003DzapzvrQOpXNya)
	{
		BlockReference blockReference = _0023_003DzCnHpCsW0MuB3.BlockReference;
		GfxAttributesRendered accumulatedParentsAttributes = blockReference.AccumulatedParentsAttributes;
		switch (blockReference.LineTypeMethod)
		{
		case colorMethodType.byEntity:
			_0023_003DzapzvrQOpXNya.LineTypeName = blockReference.LineTypeName;
			_0023_003DzapzvrQOpXNya.LineTypeMethod = colorMethodType.byEntity;
			break;
		case colorMethodType.byLayer:
			_0023_003DzapzvrQOpXNya.LineTypeMethod = colorMethodType.byLayer;
			break;
		default:
			_0023_003DzapzvrQOpXNya.LineTypeName = accumulatedParentsAttributes.LineTypeName;
			_0023_003DzapzvrQOpXNya.LineTypeMethod = colorMethodType.byParent;
			break;
		}
		switch (blockReference.LineWeightMethod)
		{
		case colorMethodType.byEntity:
			_0023_003DzapzvrQOpXNya.LineWeight = blockReference.LineWeight;
			_0023_003DzapzvrQOpXNya.LineWeightMethod = colorMethodType.byEntity;
			break;
		case colorMethodType.byLayer:
			_0023_003DzapzvrQOpXNya.LineWeightMethod = colorMethodType.byLayer;
			break;
		default:
			_0023_003DzapzvrQOpXNya.LineWeight = accumulatedParentsAttributes.LineWeight;
			_0023_003DzapzvrQOpXNya.LineWeightMethod = colorMethodType.byParent;
			break;
		}
	}

	internal Stack<CurrentBlockRefData> _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D()
	{
		return _0023_003DzzFGpNZit9CtK.Peek().CurrentBlockReferencesData;
	}

	internal Stack<Block> _0023_003Dz0Ho1jARga6O0()
	{
		Stack<Block> stack = new Stack<Block>();
		foreach (OpenBlockData item in _0023_003DzzFGpNZit9CtK)
		{
			stack.Push(item.Block);
		}
		return new Stack<Block>(stack);
	}

	public void SetParentAsCurrent(bool updateBoundingBox = true)
	{
		_0023_003Dzht_mG25JAo_00248(updateBoundingBox);
	}

	internal void _0023_003Dzht_mG25JAo_00248(bool _0023_003DzgKkl_0024ivLmKr3)
	{
		if (_0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Count == 0)
		{
			return;
		}
		EntityList entities = CurrentBlock.Entities;
		for (int i = 0; i < entities.Count; i++)
		{
			entities[i].Selected = false;
		}
		_0023_003DzVZNe8TnuvpD1();
		CurrentBlockRefData currentBlockRefData = _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Pop();
		_0023_003DzNcd94uIe40G1 = null;
		_0023_003DzmqsGvi6ju9zO();
		Block block = Blocks[currentBlockRefData.BlockReference.BlockName];
		TraversalParams data = new TraversalParams(this);
		foreach (Entity entity in block.Entities)
		{
			entity.UpdateBoundingBox(data);
		}
		_0023_003DzOA_ac7k_003D.Remove(currentBlockRefData.ParentSceneBlockReference.BlockName);
		data = new TraversalParams(this);
		foreach (Entity item in entities)
		{
			item.UpdateBoundingBox(data);
		}
		UpdateVisibleSelection();
		if (this is Design { CurrentSketch: not null } design)
		{
			design.CurrentSketch.Exit();
			OpenBlock.Entities.Regen();
		}
		if (_0023_003DzgKkl_0024ivLmKr3)
		{
			UpdateBoundingBox();
		}
		currentBlockRefData.Dispose();
	}

	private void _0023_003DzVZNe8TnuvpD1()
	{
		if (_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzF3HKD2trntQC())
		{
			_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Cancel();
		}
	}

	private void _0023_003DzmqsGvi6ju9zO()
	{
		if (_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzF3HKD2trntQC())
		{
			_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Cancel();
		}
		for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
		{
			_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i].Camera.SetSceneTransformation(CurrentTransformation);
		}
	}

	public void SetSelectionAsCurrent(bool updateBoundingBox = true)
	{
		bool flag = false;
		EntityList entities = Entities;
		for (int i = 0; i < entities.Count; i++)
		{
			if (entities[i].Selected)
			{
				flag = true;
				if (entities[i] is BlockReference blockReference)
				{
					SetCurrent(blockReference, updateBoundingBox);
					break;
				}
			}
		}
		if (!flag)
		{
			SetCurrent(null, updateBoundingBox);
		}
	}

	private void _0023_003DzPXm4mIIHkAQ_0024(bool _0023_003DzgKkl_0024ivLmKr3)
	{
		while (_0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Count > 0)
		{
			_0023_003Dzht_mG25JAo_00248(_0023_003DzgKkl_0024ivLmKr3: false);
		}
		if (_0023_003DzgKkl_0024ivLmKr3)
		{
			UpdateBoundingBox();
		}
		UpdateVisibleSelection();
	}

	internal IList<Entity> _0023_003DzOWfUZLjOSimJ()
	{
		if (_0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Count > 0)
		{
			return new List<Entity>(Entities) { _0023_003DzTpKlmr8FAaW2PckFGg_003D_003D().Peek().ParentSceneBlockReference };
		}
		return Entities;
	}

	private static int _0023_003DzVjDe_0024LiqB9qw(IList<Entity> _0023_003DzHyqiRqo_003D, Entity _0023_003DzgGRKdOw_003D)
	{
		for (int i = 0; i < _0023_003DzHyqiRqo_003D.Count; i++)
		{
			if (_0023_003DzgGRKdOw_003D == _0023_003DzHyqiRqo_003D[i])
			{
				return i;
			}
		}
		return -1;
	}

	internal BlockReference _0023_003DzpU_kB1T_2Sae()
	{
		Block openBlock = OpenBlock;
		Transformation transformation = new Translation(openBlock.BasePoint.X, openBlock.BasePoint.Y, openBlock.BasePoint.Z);
		transformation = ((_0023_003DzipBYly6zFKAp().Camera.SceneTransformationInverted == null) ? transformation : (_0023_003DzipBYly6zFKAp().Camera.SceneTransformationInverted * transformation));
		return new ParentBlockReference(transformation, openBlock.Name)
		{
			LayerName = Layers.GetDefaultLayerName(),
			RegenMode = regenType.NotNeeded
		};
	}

	internal void _0023_003DzTdGsKPrsLPf8lMrax9_0024HWb0_003D(IReadOnlyList<Block> _0023_003Dz9W2nj9A_003D, bool _0023_003DzdT0PBw1onYvu)
	{
		if (_0023_003DzdT0PBw1onYvu)
		{
			ParallelConveHull.Instance.Stop();
		}
		foreach (Block item in _0023_003Dz9W2nj9A_003D)
		{
			item.zoomFitConvexHull = null;
		}
	}

	internal void _0023_003DzgChooeM7YyYsnw0AK4qKYfg_003D()
	{
		ParallelConveHull.Instance.Stop();
		foreach (Block item in _0023_003Dz0Ho1jARga6O0())
		{
			item.zoomFitConvexHull = null;
		}
		if (CurrentBlockReference == null)
		{
			return;
		}
		foreach (BlockReference parent in Parents)
		{
			Blocks[parent.BlockName].zoomFitConvexHull = null;
		}
	}

	public void IsolateBlocks(IReadOnlyCollection<Block> blocks)
	{
		_0023_003Dz37pxF_3X_0024eNrucsWIg_003D_003D();
		if (blocks != null)
		{
			_0023_003DzNfebctI_003D();
			_0023_003DzjczFwk1Qrlg9QkeecQ_003D_003D = blocks.Select((Block _0023_003Dz5PxKZP0_003D) => _0023_003Dz5PxKZP0_003D.Name).ToArray();
		}
	}

	public void IsolateInstances(IReadOnlyList<Tuple<Stack<BlockReference>, Entity>> instances)
	{
		_0023_003Dz37pxF_3X_0024eNrucsWIg_003D_003D();
		if (instances != null)
		{
			_0023_003DzNfebctI_003D();
			_0023_003DzomkzA6ARKGCOzn9ijw_003D_003D = new Tuple<Stack<BlockReference>, Entity>[instances.Count];
			for (int i = 0; i < instances.Count; i++)
			{
				Tuple<Stack<BlockReference>, Entity> tuple = instances[i];
				Stack<BlockReference> item = ((tuple.Item1 != null) ? Utility.CloneStack(tuple.Item1) : new Stack<BlockReference>());
				_0023_003DzomkzA6ARKGCOzn9ijw_003D_003D[i] = new Tuple<Stack<BlockReference>, Entity>(item, tuple.Item2);
			}
		}
	}

	public void IsolateSelected(IReadOnlyList<SelectedItemBase> instances)
	{
		_0023_003Dz37pxF_3X_0024eNrucsWIg_003D_003D();
		if (instances != null)
		{
			_0023_003DzNfebctI_003D();
			_0023_003DzomkzA6ARKGCOzn9ijw_003D_003D = new Tuple<Stack<BlockReference>, Entity>[instances.Count];
			for (int i = 0; i < instances.Count; i++)
			{
				SelectedItemBase selectedItemBase = instances[i];
				Stack<BlockReference> item = ((selectedItemBase.Parents != null) ? Utility.CloneStack(selectedItemBase.Parents) : new Stack<BlockReference>());
				_0023_003DzomkzA6ARKGCOzn9ijw_003D_003D[i] = new Tuple<Stack<BlockReference>, Entity>(item, (Entity)selectedItemBase.Item);
			}
		}
	}

	private void _0023_003Dz37pxF_3X_0024eNrucsWIg_003D_003D()
	{
		_0023_003DzjczFwk1Qrlg9QkeecQ_003D_003D = null;
		_0023_003DzomkzA6ARKGCOzn9ijw_003D_003D = null;
		_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: true);
		UpdateVisibleSelection();
	}

	private bool _0023_003DzSTCto4yqfbV4()
	{
		if (_0023_003DzjczFwk1Qrlg9QkeecQ_003D_003D == null)
		{
			return _0023_003DzomkzA6ARKGCOzn9ijw_003D_003D != null;
		}
		return true;
	}

	private void _0023_003DzNfebctI_003D()
	{
		if (_0023_003DzbjqYxAof66jg())
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595064));
		}
	}

	public void UpdateBoundingBox()
	{
		_0023_003Dz__ogbSIFtpdK();
	}

	internal virtual void _0023_003Dz__ogbSIFtpdK()
	{
		_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: true);
		_0023_003DzhZBG7nJJTvjGfFveRwoiZ4U_003D();
		if (_0023_003Dz6CMmzY6fHGlL.OverrideSceneExtents)
		{
			_0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF = _0023_003Dz6CMmzY6fHGlL.Min;
			_0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr = _0023_003Dz6CMmzY6fHGlL.Max;
		}
		else
		{
			Document.UpdateBoundingBox();
			_0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF = OpenBlock.Entities.BoxMin;
			_0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr = OpenBlock.Entities.BoxMax;
			_0023_003Dz6CMmzY6fHGlL._0023_003DzDFTJsrsRDL5Z = OpenBlock.Entities.BoxOffset;
		}
		_0023_003DzgngvrWJq3A3YrTL3_trCsCU_003D();
		_0023_003DzwD6MQKZjqPL8();
		_0023_003DzhMz2Xb3oiXP2_0024WuRGg_003D_003D();
		_0023_003Dz8ok_dRe4bjRDcVb_0024afNnmr8_003D = true;
		for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
		{
			Viewport viewport = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i];
			viewport.Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
			Grid[] grids = viewport.Grids;
			foreach (Grid grid in grids)
			{
				if (grid.AutoSize)
				{
					grid.Recompute = true;
				}
			}
			viewport._0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003DzyU8zEa9rYhPN(viewport));
		}
		UpdateVisibleSelection();
		Document.isBoundingBoxDirty = false;
		_0023_003Dz6oXjiBbfuRAlBSZl9Fg_0024I_v3AiUA = true;
		_0023_003DzXDwbax_0024fbiw9g2IBIQ_003D_003D();
	}

	private void _0023_003DzwD6MQKZjqPL8()
	{
		int count = OpenBlock.Entities.Count;
		Point3D _0023_003Dze4TpmVqI26AF = _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF;
		Point3D _0023_003DzD4HjvLi8HsVr = _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr;
		double num = _0023_003DzD4HjvLi8HsVr.X - _0023_003Dze4TpmVqI26AF.X;
		double num2 = _0023_003DzD4HjvLi8HsVr.Y - _0023_003Dze4TpmVqI26AF.Y;
		double num3 = _0023_003DzD4HjvLi8HsVr.Z - _0023_003Dze4TpmVqI26AF.Z;
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.MakeCurrent();
			if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0)
			{
				double num4 = ((!_0023_003DzK3OaHhra7VrS.UnitsOverride.HasValue) ? 1.0 : Utility.GetLinearUnitsConversionFactor(_0023_003DzpYxLcIs_003D, _0023_003DzK3OaHhra7VrS.UnitsOverride.Value));
				_0023_003DzK3OaHhra7VrS._0023_003DzKFkHb4MBq9bk(_0023_003DzmNZD0Zs_003D, num2 * num4, num3 * num4, num * num4, count, _0023_003DzD4HjvLi8HsVr, _0023_003DzipBYly6zFKAp(), _0023_003DzK3OaHhra7VrS.UnitsOverride ?? _0023_003DzpYxLcIs_003D);
			}
		}
	}

	public RegenParams GetVisualRefinement()
	{
		return Document.GetVisualRefinement();
	}

	public void ProcessSemiTransparent()
	{
		if (!AccurateTransparency)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594375));
		}
		_0023_003DzSGUVLSk_003D = new _0023_003Dzr0jCnURn6b4IPBJIQjQadJWOSMvtA7pxlA_003D_003D(_0023_003DzmNZD0Zs_003D, Entities.BoxSize.Diagonal);
		GfxAttributesColorAndMaterial _0023_003Dzum3KJsHCscCu = new GfxAttributesColorAndMaterial(Document.DefaultColor, Layers, this)
		{
			EnvironmentIntensity = _0023_003Dzxpbv4lQ_003D.Environment
		};
		_0023_003Dz7ON4ieW9fIeh(Entities, Entities.Count, Blocks, null, null, _0023_003Dzum3KJsHCscCu, null);
		_0023_003DzSGUVLSk_003D._0023_003DzIeusLNGcCnRJ(out _0023_003DzpW717vDE_JTBaH23pw_003D_003D, out _0023_003Dzc6W_0024QvlNhBTR);
	}

	private void _0023_003Dz7ON4ieW9fIeh(IList<Entity> _0023_003DzY_0024ABPwh9wryC, int _0023_003Dzi2BEvYp6GX6e, BlockKeyedCollection _0023_003Dz9W2nj9A_003D, Entity _0023_003Dz0TvaYNo_003D, Stack<BlockReference> _0023_003Dzbq3BJR0_003D, GfxAttributesColorAndMaterial _0023_003Dzum3KJsHCscCu, GfxAttributesColorAndMaterial[] _0023_003DzycabB_0024z_00241KWA)
	{
		GfxAttributesColorAndMaterial other = (GfxAttributesColorAndMaterial)_0023_003Dzum3KJsHCscCu.Clone();
		for (int i = 0; i < _0023_003Dzi2BEvYp6GX6e; i++)
		{
			Entity entity = _0023_003DzY_0024ABPwh9wryC[i];
			if (!Layers[entity.LayerName].Visible || entity.entityNature == entityNatureType.Point || entity.entityNature == entityNatureType.Wire || !entity.Visible)
			{
				continue;
			}
			bool _0023_003DzXluM0iA_003D = entity.IsSelected(new Stack<BlockReference>(), selectionStatusType.Permanent);
			if (_0023_003Dz0TvaYNo_003D == null)
			{
				_0023_003Dzum3KJsHCscCu.Assign(other);
				_0023_003Dzum3KJsHCscCu.Propagate(entity, Layers[entity.LayerName], _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
			}
			else
			{
				_0023_003Dzum3KJsHCscCu = _0023_003DzycabB_0024z_00241KWA[i];
			}
			if (_0023_003Dzum3KJsHCscCu.GetColor().A == byte.MaxValue && _0023_003Dzum3KJsHCscCu.RenderedColor.A == byte.MaxValue && !_0023_003Dzum3KJsHCscCu.IsMaterialTransparent() && !(entity is BlockReference))
			{
				continue;
			}
			if (entity is Triangle)
			{
				Triangle triangle = (Triangle)entity;
				if ((object)triangle.Normal == null)
				{
					triangle.Regen(0.0);
				}
				_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(triangle._vertices[0], triangle._vertices[1], triangle._vertices[2], triangle.Normal, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
				continue;
			}
			if (entity is Quad)
			{
				Quad quad = (Quad)entity;
				if ((object)quad.Normal == null)
				{
					quad.Regen(0.0);
				}
				_0023_003DzSGUVLSk_003D._0023_003Dz_00244pZ4eY_003D(quad._vertices[0], quad._vertices[1], quad._vertices[2], quad._vertices[3], quad.Normal, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
				continue;
			}
			if (entity is BlockReference)
			{
				BlockReference blockReference = (BlockReference)entity;
				Stack<BlockReference> stack = new Stack<BlockReference>();
				GfxAttributesColorAndMaterial[] _0023_003DzxDMUADmeZWrF;
				Entity[] array = blockReference.ExplodeInternal(_0023_003Dz7fKuZap8h713: true, Layers, new TraversalParams(blockReference, _0023_003Dz9W2nj9A_003D, this), (GfxAttributesColorAndMaterial)_0023_003Dzum3KJsHCscCu.Clone(), _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, out _0023_003DzxDMUADmeZWrF, stack, _0023_003Dz7xgVbr5zq1_B: true, _0023_003Dzu9oxwJ_zKlMt: true);
				_0023_003Dz7ON4ieW9fIeh(array, array.Length, _0023_003Dz9W2nj9A_003D, blockReference, stack, _0023_003Dzum3KJsHCscCu, _0023_003DzxDMUADmeZWrF);
				continue;
			}
			if (entity is Mesh)
			{
				_0023_003DznZ_0024QybVSfq5N(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, entity, _0023_003DzXluM0iA_003D);
				continue;
			}
			if (entity is Surface)
			{
				Mesh _0023_003DztJCl_0024mM_003D = ((Surface)entity).ConvertToMesh(0.0, 0.0, Mesh.natureType.Smooth, skipEdges: true);
				_0023_003DznZ_0024QybVSfq5N(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D);
				continue;
			}
			if (entity is Solid)
			{
				Solid solid = (Solid)entity;
				if (solid.RegenMode == regenType.RegenAndCompile)
				{
					solid.Regen(0.0);
				}
				GfxAttributesColorAndMaterial other2 = null;
				if (solid.UseInnerColors)
				{
					other2 = (GfxAttributesColorAndMaterial)_0023_003Dzum3KJsHCscCu.Clone();
				}
				for (int j = 0; j < solid.Portions.Count; j++)
				{
					Solid.Portion portion = solid.Portions[j];
					if (solid.UseInnerColors)
					{
						_0023_003Dzum3KJsHCscCu.Assign(other2);
						_0023_003Dzum3KJsHCscCu.Propagate(portion, Layers[portion.LayerName], _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
						if (_0023_003Dzum3KJsHCscCu.GetColor().A == byte.MaxValue && _0023_003Dzum3KJsHCscCu.RenderedColor.A == byte.MaxValue)
						{
							continue;
						}
					}
					_0023_003DznZ_0024QybVSfq5N(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, portion, _0023_003DzXluM0iA_003D);
				}
				continue;
			}
			if (entity is Bar)
			{
				Bar bar = (Bar)entity;
				for (int k = 0; k < bar.Slices; k++)
				{
					Utility.GetSliceVerticesAndNormals(k, bar.Radius, bar.Slices, bar.StartPoint, bar.EndPoint, bar.Vertices, out var v, out var v2, out var v3, out var v4, out var n, out var n2, out var n3, out var n4);
					_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(v, v2, v3, n, n2, n3, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
					_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(v2, v4, v3, n2, n4, n3, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
				}
				continue;
			}
			if (entity is Joint)
			{
				Joint joint = (Joint)entity;
				Vector3D vector3D = new Vector3D();
				Vector3D vector3D2 = new Vector3D();
				Vector3D vector3D3 = new Vector3D();
				for (int l = 0; l < joint.Triangles.Length; l++)
				{
					joint.GetTriangleVerticesAndNormals(l, out var _0023_003DzDVubtvo_003D, out var _0023_003DzFj_0024IqDQ_003D, out var _0023_003DzjdeMMkk_003D, vector3D, vector3D2, vector3D3);
					_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(_0023_003DzDVubtvo_003D, _0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, vector3D, vector3D2, vector3D3, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
				}
				continue;
			}
			if (entity is Hatch hatch && hatch.IsSolid())
			{
				for (int m = 0; m < hatch.Triangles.Length; m++)
				{
					IndexTriangle indexTriangle = hatch.Triangles[m];
					_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(hatch._vertices[indexTriangle.V1], hatch._vertices[indexTriangle.V2], hatch._vertices[indexTriangle.V3], hatch.Plane.AxisZ, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
				}
				continue;
			}
			if (entity is FastMesh fastMesh)
			{
				if (fastMesh.TriangleArray != null)
				{
					for (int num = 0; num < fastMesh.TriangleArray.Length; num += 3)
					{
						int num2 = fastMesh.TriangleArray[num];
						int num3 = fastMesh.TriangleArray[num + 1];
						int num4 = fastMesh.TriangleArray[num + 2];
						Point3D _0023_003DzkW_0024DzQk_003D = new Point3D(fastMesh.PointArray[num2 * 3], fastMesh.PointArray[num2 * 3 + 1], fastMesh.PointArray[num2 * 3 + 2]);
						Point3D _0023_003Dz8ecWqr4_003D = new Point3D(fastMesh.PointArray[num3 * 3], fastMesh.PointArray[num3 * 3 + 1], fastMesh.PointArray[num3 * 3 + 2]);
						Point3D _0023_003Dz9AEnWh4_003D = new Point3D(fastMesh.PointArray[num4 * 3], fastMesh.PointArray[num4 * 3 + 1], fastMesh.PointArray[num4 * 3 + 2]);
						Vector3D _0023_003DzYWn94JY_003D = new Vector3D(fastMesh.NormalArray[num2 * 3], fastMesh.NormalArray[num2 * 3 + 1], fastMesh.NormalArray[num2 * 3 + 2]);
						Vector3D _0023_003DzkAUEPP0_003D = new Vector3D(fastMesh.NormalArray[num3 * 3], fastMesh.NormalArray[num3 * 3 + 1], fastMesh.NormalArray[num3 * 3 + 2]);
						Vector3D _0023_003DzWwmzTMs_003D = new Vector3D(fastMesh.NormalArray[num4 * 3], fastMesh.NormalArray[num4 * 3 + 1], fastMesh.NormalArray[num4 * 3 + 2]);
						_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(_0023_003DzkW_0024DzQk_003D, _0023_003Dz8ecWqr4_003D, _0023_003Dz9AEnWh4_003D, _0023_003DzYWn94JY_003D, _0023_003DzkAUEPP0_003D, _0023_003DzWwmzTMs_003D, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
					}
				}
				else
				{
					for (int num5 = 0; num5 < fastMesh.PointArray.Length; num5 += 9)
					{
						Point3D _0023_003DzkW_0024DzQk_003D2 = new Point3D(fastMesh.PointArray[num5], fastMesh.PointArray[num5 + 1], fastMesh.PointArray[num5 + 2]);
						Point3D _0023_003Dz8ecWqr4_003D2 = new Point3D(fastMesh.PointArray[num5 + 3], fastMesh.PointArray[num5 + 4], fastMesh.PointArray[num5 + 5]);
						Point3D _0023_003Dz9AEnWh4_003D2 = new Point3D(fastMesh.PointArray[num5 + 6], fastMesh.PointArray[num5 + 7], fastMesh.PointArray[num5 + 8]);
						Vector3D _0023_003DzYWn94JY_003D2 = new Vector3D(fastMesh.NormalArray[num5], fastMesh.NormalArray[num5 + 1], fastMesh.NormalArray[num5 + 2]);
						Vector3D _0023_003DzkAUEPP0_003D2 = new Vector3D(fastMesh.NormalArray[num5 + 3], fastMesh.NormalArray[num5 + 4], fastMesh.NormalArray[num5 + 5]);
						Vector3D _0023_003DzWwmzTMs_003D2 = new Vector3D(fastMesh.NormalArray[num5 + 6], fastMesh.NormalArray[num5 + 7], fastMesh.NormalArray[num5 + 8]);
						_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(_0023_003DzkW_0024DzQk_003D2, _0023_003Dz8ecWqr4_003D2, _0023_003Dz9AEnWh4_003D2, _0023_003DzYWn94JY_003D2, _0023_003DzkAUEPP0_003D2, _0023_003DzWwmzTMs_003D2, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
					}
				}
				continue;
			}
			if (entity is devDept.Eyeshot.Entities.Region)
			{
				devDept.Eyeshot.Entities.Region region = (devDept.Eyeshot.Entities.Region)entity;
				for (int num6 = 0; num6 < region.Triangles.Length; num6++)
				{
					IndexTriangle indexTriangle2 = region.Triangles[num6];
					_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(region._vertices[indexTriangle2.V1], region._vertices[indexTriangle2.V2], region._vertices[indexTriangle2.V3], region.Plane.AxisZ, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? entity, _0023_003DzXluM0iA_003D);
				}
				continue;
			}
			if (entity is Brep)
			{
				Brep brep = (Brep)entity;
				_0023_003DzqK5ZTn1dYQ7Xea5Wm1S0XUfPAVV3(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, brep, brep.Faces, _0023_003DzXluM0iA_003D);
				if (brep.Inners != null)
				{
					for (int num7 = 0; num7 < brep.Inners.Length; num7++)
					{
						_0023_003DzqK5ZTn1dYQ7Xea5Wm1S0XUfPAVV3(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, brep, brep.Inners[num7], _0023_003DzXluM0iA_003D);
					}
				}
				continue;
			}
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620914) + entity.GetType()?.ToString() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594209));
		}
	}

	private void _0023_003DznZ_0024QybVSfq5N(Entity _0023_003Dz0TvaYNo_003D, GfxAttributesColorAndMaterial _0023_003Dzum3KJsHCscCu, Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzXluM0iA_003D)
	{
		Mesh mesh = (Mesh)_0023_003DztJCl_0024mM_003D;
		IndexTriangle[] triangles = mesh.Triangles;
		if (mesh.Normals == null)
		{
			mesh.Regen(0.0);
		}
		switch (mesh.MeshNature)
		{
		case Mesh.natureType.Plain:
			_0023_003DzwWEUP9NJ4kdGLBx4OU5qu_0024o_003D(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D, triangles, mesh);
			break;
		case Mesh.natureType.Smooth:
			_0023_003DzaKVViBgKu4sBF7NH9tLScXpJlLsq(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D, triangles, mesh);
			break;
		case Mesh.natureType.RichPlain:
			if (_0023_003Dzum3KJsHCscCu.Material != null && _0023_003Dzum3KJsHCscCu.Material.Texture != null)
			{
				for (int i = 0; i < triangles.Length; i++)
				{
					RichTriangle richTriangle = (RichTriangle)triangles[i];
					_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(mesh._vertices[richTriangle.V1], mesh._vertices[richTriangle.V2], mesh._vertices[richTriangle.V3], mesh.Normals[i], mesh.TextureCoords[richTriangle.T1], mesh.TextureCoords[richTriangle.T2], mesh.TextureCoords[richTriangle.T3], _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D);
				}
			}
			else
			{
				_0023_003DzwWEUP9NJ4kdGLBx4OU5qu_0024o_003D(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D, triangles, mesh);
			}
			break;
		case Mesh.natureType.RichSmooth:
			if (_0023_003Dzum3KJsHCscCu.Material != null && _0023_003Dzum3KJsHCscCu.Material.Texture != null)
			{
				for (int j = 0; j < triangles.Length; j++)
				{
					RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)triangles[j];
					_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(mesh._vertices[richSmoothTriangle.V1], mesh._vertices[richSmoothTriangle.V2], mesh._vertices[richSmoothTriangle.V3], mesh.Normals[richSmoothTriangle.N1], mesh.Normals[richSmoothTriangle.N2], mesh.Normals[richSmoothTriangle.N3], mesh.TextureCoords[richSmoothTriangle.T1], mesh.TextureCoords[richSmoothTriangle.T2], mesh.TextureCoords[richSmoothTriangle.T3], _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D);
				}
			}
			else
			{
				_0023_003DzaKVViBgKu4sBF7NH9tLScXpJlLsq(_0023_003Dz0TvaYNo_003D, _0023_003Dzum3KJsHCscCu, _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D, triangles, mesh);
			}
			break;
		default:
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620914) + _0023_003DztJCl_0024mM_003D.GetType()?.ToString() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594257) + mesh.MeshNature.ToString() + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594295));
		}
	}

	private void _0023_003DzwWEUP9NJ4kdGLBx4OU5qu_0024o_003D(Entity _0023_003Dz0TvaYNo_003D, GfxAttributesColorAndMaterial _0023_003Dzum3KJsHCscCu, Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzXluM0iA_003D, IndexTriangle[] _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, Mesh _0023_003DzLtLprGE_003D)
	{
		for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length; i++)
		{
			IndexTriangle indexTriangle = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(_0023_003DzLtLprGE_003D._vertices[indexTriangle.V1], _0023_003DzLtLprGE_003D._vertices[indexTriangle.V2], _0023_003DzLtLprGE_003D._vertices[indexTriangle.V3], _0023_003DzLtLprGE_003D.Normals[i], _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D);
		}
	}

	private void _0023_003DzaKVViBgKu4sBF7NH9tLScXpJlLsq(Entity _0023_003Dz0TvaYNo_003D, GfxAttributesColorAndMaterial _0023_003Dzum3KJsHCscCu, Entity _0023_003DztJCl_0024mM_003D, bool _0023_003DzXluM0iA_003D, IndexTriangle[] _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, Mesh _0023_003DzLtLprGE_003D)
	{
		for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length; i++)
		{
			SmoothTriangle smoothTriangle = (SmoothTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(_0023_003DzLtLprGE_003D._vertices[smoothTriangle.V1], _0023_003DzLtLprGE_003D._vertices[smoothTriangle.V2], _0023_003DzLtLprGE_003D._vertices[smoothTriangle.V3], _0023_003DzLtLprGE_003D.Normals[smoothTriangle.N1], _0023_003DzLtLprGE_003D.Normals[smoothTriangle.N2], _0023_003DzLtLprGE_003D.Normals[smoothTriangle.N3], _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D);
		}
	}

	private void _0023_003DzqK5ZTn1dYQ7Xea5Wm1S0XUfPAVV3(Entity _0023_003Dz0TvaYNo_003D, GfxAttributesColorAndMaterial _0023_003Dzum3KJsHCscCu, Brep _0023_003DztJCl_0024mM_003D, Brep.Face[] _0023_003DzkRv4SrkmP4Wm, bool _0023_003DzXluM0iA_003D)
	{
		for (int i = 0; i < _0023_003DzkRv4SrkmP4Wm.Length; i++)
		{
			FastMesh tessellation = _0023_003DzkRv4SrkmP4Wm[i].Tessellation;
			for (int j = 0; j < tessellation.TriangleArray.Length; j += 3)
			{
				int num = 3 * tessellation.TriangleArray[j];
				int num2 = 3 * tessellation.TriangleArray[j + 1];
				int num3 = 3 * tessellation.TriangleArray[j + 2];
				int num4 = num + 1;
				int num5 = num + 2;
				int num6 = num2 + 1;
				int num7 = num2 + 2;
				int num8 = num3 + 1;
				int num9 = num3 + 2;
				Point3D _0023_003DzkW_0024DzQk_003D = new Point3D(tessellation.PointArray[num], tessellation.PointArray[num4], tessellation.PointArray[num5]);
				Point3D _0023_003Dz8ecWqr4_003D = new Point3D(tessellation.PointArray[num2], tessellation.PointArray[num6], tessellation.PointArray[num7]);
				Point3D _0023_003Dz9AEnWh4_003D = new Point3D(tessellation.PointArray[num3], tessellation.PointArray[num8], tessellation.PointArray[num9]);
				Vector3D _0023_003DzYWn94JY_003D = new Vector3D(tessellation.NormalArray[num], tessellation.NormalArray[num4], tessellation.NormalArray[num5]);
				Vector3D _0023_003DzkAUEPP0_003D = new Vector3D(tessellation.NormalArray[num2], tessellation.NormalArray[num6], tessellation.NormalArray[num7]);
				Vector3D _0023_003DzWwmzTMs_003D = new Vector3D(tessellation.NormalArray[num3], tessellation.NormalArray[num8], tessellation.NormalArray[num9]);
				_0023_003DzSGUVLSk_003D._0023_003Dz3GeAKo8_003D(_0023_003DzkW_0024DzQk_003D, _0023_003Dz8ecWqr4_003D, _0023_003Dz9AEnWh4_003D, _0023_003DzYWn94JY_003D, _0023_003DzkAUEPP0_003D, _0023_003DzWwmzTMs_003D, _0023_003Dzum3KJsHCscCu, _0023_003Dz0TvaYNo_003D ?? _0023_003DztJCl_0024mM_003D, _0023_003DzXluM0iA_003D);
			}
		}
	}

	private bool _0023_003DzL9m3bXnFrb0F()
	{
		if (Layers.Any(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzFqvX6u2h0RW8ygxmZiZPKrimRNgx))
		{
			return true;
		}
		foreach (Block block in Blocks)
		{
			if (block.Entities.Any(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dzt_17mly5sJ30mGcMdQlbCFezYqdj))
			{
				return true;
			}
		}
		return false;
	}

	internal List<Entity> _0023_003Dzgo07rC4SNeru()
	{
		foreach (Layer layer in Layers)
		{
			layer.isDirtyForFlattenTree = false;
		}
		foreach (Block block in Blocks)
		{
			foreach (Entity entity in block.Entities)
			{
				entity.isDirtyForFlattenTree = false;
			}
		}
		_0023_003DzPy_UVJqNuye0 = false;
		return _0023_003Dzjf_0024BZto9_0024Rys_vlKUa_93O0_003D(_0023_003DzOWfUZLjOSimJ(), _0023_003DzoE3BE__0024RS_DJ(), 0);
	}

	private IsSmallParams _0023_003Dzw7QoUZLTgfsDX6DhlA_003D_003D(double _0023_003DzBRNuU48_003D)
	{
		int[] viewFrame = _0023_003DzipBYly6zFKAp().GetViewFrame();
		double[] array = _0023_003DzipBYly6zFKAp().Camera.GetModelViewProjectionMatrix();
		if (CurrentTransformation != null)
		{
			array = Utility.MultMatrixd(CurrentTransformation.MatrixAsVectorByColumn, array);
		}
		return new IsSmallParams
		{
			ModelViewProj = array,
			ViewFrame = viewFrame,
			SmallSize = _0023_003DzBRNuU48_003D,
			RenderContext = _0023_003DzmNZD0Zs_003D
		};
	}

	internal void _0023_003DzadAqUJcDAmic(bool _0023_003DzIH4xUe5IjPB_0024)
	{
		_0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D?.Clear();
		_0023_003DzBQZ7dkeuOAeGsXKYoQ_003D_003D = null;
		if (_0023_003DzIH4xUe5IjPB_0024)
		{
			_0023_003DzfRVkvW62UnE5fk7N_g_003D_003D = null;
		}
		_0023_003DzlPALPXW8i7Fn11_cJNElnPw_003D();
	}

	private Stack<BlockReference> _0023_003Dze_l5CIMGehRycIbonA_003D_003D(Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		BlockReference[] array = new BlockReference[Parents.Count];
		Parents.CopyTo(array, 0);
		Array.Reverse(array);
		Stack<BlockReference> stack = new Stack<BlockReference>(array);
		array = new BlockReference[_0023_003Dzbq3BJR0_003D.Count];
		_0023_003Dzbq3BJR0_003D.CopyTo(array, 0);
		Array.Reverse(array);
		BlockReference[] array2 = array;
		foreach (BlockReference item in array2)
		{
			stack.Push(item);
		}
		return stack;
	}

	internal List<Entity> _0023_003Dzjf_0024BZto9_0024Rys_vlKUa_93O0_003D(IList<Entity> _0023_003DzY_0024ABPwh9wryC, BlockKeyedCollection _0023_003Dz9W2nj9A_003D, int _0023_003DzK3VuBC0_003D)
	{
		GfxAttributesWire gfxAttributesWire;
		switch (_0023_003DzipBYly6zFKAp().DisplayMode)
		{
		case displayType.Rendered:
			gfxAttributesWire = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesRendered>();
			break;
		case displayType.Flat:
			gfxAttributesWire = ((_0023_003Dzipe8ch4_003D.ColorMethod == flatColorMethodType.EntityColor) ? _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesWire>() : _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesMaterialFlat>());
			break;
		case displayType.Wireframe:
		case displayType.Shaded:
			gfxAttributesWire = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesWire>();
			break;
		case displayType.HiddenLines:
			gfxAttributesWire = _0023_003DzIL3W95R6Q9Dj();
			break;
		default:
			gfxAttributesWire = _0023_003DzQ2WyM_0024wWRRUc<GfxAttributesWire>();
			break;
		}
		_0023_003DzXr8srg0YPbd8c1LuCBXqlpg_003D = (GfxAttributesWire)gfxAttributesWire.Clone();
		List<Entity> list = new List<Entity>(_0023_003Dz9W2nj9A_003D.Count * 2);
		_0023_003DzfCKdLyCtJ6E3izvQj3hgx14_003D(_0023_003DzY_0024ABPwh9wryC, _0023_003Dz9W2nj9A_003D, new Stack<BlockReference>(), new Identity(), gfxAttributesWire, _0023_003DzK3VuBC0_003D, _0023_003Dzl7FZ5_su2I_0024n: false, _0023_003DzL36Y7x9iP3cJ: false, _0023_003DzxuHgbTg63DvP: false, _0023_003Dz1pV06LTHfQzd4lXqpw_003D_003D: true, CurrentBlockReference, list);
		_0023_003DzXr8srg0YPbd8c1LuCBXqlpg_003D = null;
		return list;
	}

	private void _0023_003DzfCKdLyCtJ6E3izvQj3hgx14_003D(IList<Entity> _0023_003DzY_0024ABPwh9wryC, BlockKeyedCollection _0023_003Dz9W2nj9A_003D, Stack<BlockReference> _0023_003Dzbq3BJR0_003D, Transformation _0023_003DzKS2oHPc_003D, GfxAttributesWire _0023_003Dzum3KJsHCscCu, int _0023_003DzK3VuBC0_003D, bool _0023_003Dzl7FZ5_su2I_0024n, bool _0023_003DzL36Y7x9iP3cJ, bool _0023_003DzxuHgbTg63DvP, bool _0023_003Dz1pV06LTHfQzd4lXqpw_003D_003D, BlockReference _0023_003DzCyvEvGpvZo6F, List<Entity> _0023_003DzKsDQg6V2xxDZRL81QkctCwc_003D)
	{
		double maxAbsScaleFactor = _0023_003DzKS2oHPc_003D.MaxAbsScaleFactor;
		foreach (Entity item2 in _0023_003DzY_0024ABPwh9wryC)
		{
			if (item2.IsSketchEntity())
			{
				continue;
			}
			Layer itemFast = Layers.GetItemFast(item2.LayerName);
			Stack<BlockReference> parents = ((_0023_003DzCyvEvGpvZo6F != null) ? _0023_003Dze_l5CIMGehRycIbonA_003D_003D(_0023_003Dzbq3BJR0_003D) : _0023_003Dzbq3BJR0_003D);
			if ((!(item2 is AttributeReferenceData attributeReferenceData) || attributeReferenceData.IsVisible(_0023_003Dzbq3BJR0_003D, Layers, AttributeReferenceVisibilityMode)) && (!(item2 is devDept.Eyeshot.Entities.Attribute attribute) || !attribute.IsHidden(_0023_003Dzbq3BJR0_003D, this)) && item2.GetVisibility(parents) && itemFast.Visible && item2.IsValidForDraw())
			{
				bool flag = _0023_003DzxuHgbTg63DvP || _0023_003Dzlrl6ZJY_003D(_0023_003Dzbq3BJR0_003D, item2);
				bool flag2 = _0023_003Dz1pV06LTHfQzd4lXqpw_003D_003D && item2.GetClippability(_0023_003Dzbq3BJR0_003D);
				bool flag3 = !_0023_003DzL36Y7x9iP3cJ && (_0023_003Dzl7FZ5_su2I_0024n || item2.IsSelected(_0023_003Dzbq3BJR0_003D, selectionStatusType.Permanent));
				if (item2 is BlockReference blockReference)
				{
					GfxAttributesWire gfxAttributesWire = _0023_003Dzum3KJsHCscCu.Clone() as GfxAttributesWire;
					gfxAttributesWire.Propagate(item2, itemFast, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
					gfxAttributesWire.PropagateLayer0(item2, itemFast);
					_0023_003Dzbq3BJR0_003D.Push(blockReference);
					IList<Entity> entities = blockReference.GetEntities(_0023_003Dz9W2nj9A_003D);
					bool _0023_003DzL36Y7x9iP3cJ2 = _0023_003DzL36Y7x9iP3cJ || blockReference is ParentBlockReference;
					_0023_003DzfCKdLyCtJ6E3izvQj3hgx14_003D(entities, _0023_003Dz9W2nj9A_003D, _0023_003Dzbq3BJR0_003D, _0023_003DzKS2oHPc_003D * blockReference.GetFullTransformation(_0023_003Dz9W2nj9A_003D), gfxAttributesWire, _0023_003DzK3VuBC0_003D + 1, flag3, _0023_003DzL36Y7x9iP3cJ2, flag, flag2, _0023_003DzCyvEvGpvZo6F, _0023_003DzKsDQg6V2xxDZRL81QkctCwc_003D);
					_0023_003Dzbq3BJR0_003D.Pop();
				}
				else
				{
					_0023_003DzXr8srg0YPbd8c1LuCBXqlpg_003D.Assign(_0023_003Dzum3KJsHCscCu);
					_0023_003DzXr8srg0YPbd8c1LuCBXqlpg_003D.Propagate(item2, itemFast, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
					NestedEntity item = new NestedEntity(item2, _0023_003DzXr8srg0YPbd8c1LuCBXqlpg_003D, _0023_003Dzbq3BJR0_003D, (_0023_003DzK3VuBC0_003D == 0) ? null : _0023_003DzKS2oHPc_003D, maxAbsScaleFactor, _0023_003Dzl7FZ5_su2I_0024n, flag3, flag2, _0023_003DzL36Y7x9iP3cJ || !flag);
					_0023_003DzPy_UVJqNuye0 = _0023_003DzPy_UVJqNuye0 || item2.IsPolygonal();
					_0023_003DzKsDQg6V2xxDZRL81QkctCwc_003D.Add(item);
				}
			}
		}
	}

	private bool _0023_003Dzlrl6ZJY_003D(IIsolateParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D)
	{
		if (!_0023_003Dzt5jpbHs_003D.ParentIsolated)
		{
			return _0023_003Dzlrl6ZJY_003D(_0023_003Dzt5jpbHs_003D.Parents, _0023_003DztJCl_0024mM_003D);
		}
		return true;
	}

	private bool _0023_003Dzlrl6ZJY_003D(Stack<BlockReference> _0023_003Dzbq3BJR0_003D, Entity _0023_003DztJCl_0024mM_003D)
	{
		bool result = true;
		if (_0023_003DzomkzA6ARKGCOzn9ijw_003D_003D != null)
		{
			result = false;
			Tuple<Stack<BlockReference>, Entity>[] array = _0023_003DzomkzA6ARKGCOzn9ijw_003D_003D;
			foreach (Tuple<Stack<BlockReference>, Entity> tuple in array)
			{
				if (_0023_003DztJCl_0024mM_003D == tuple.Item2 && _0023_003Dzbq3BJR0_003D.SequenceEqual(tuple.Item1))
				{
					result = true;
					break;
				}
			}
		}
		else if (_0023_003DzjczFwk1Qrlg9QkeecQ_003D_003D != null)
		{
			string value = ((_0023_003DztJCl_0024mM_003D is BlockReference blockReference) ? blockReference.BlockName : ((_0023_003Dzbq3BJR0_003D.Count > 0) ? _0023_003Dzbq3BJR0_003D.Peek().BlockName : OpenBlock.Name));
			result = _0023_003DzjczFwk1Qrlg9QkeecQ_003D_003D.Contains(value);
		}
		return result;
	}

	private List<Entity> _0023_003DzB5hGO8lwFPSw(List<Entity> _0023_003Dz_0024gv3_0024ykh68CDA6lTgA_003D_003D, double _0023_003DzBRNuU48_003D)
	{
		IsSmallParams isSmallParams = _0023_003Dzw7QoUZLTgfsDX6DhlA_003D_003D(_0023_003DzBRNuU48_003D);
		if (isSmallParams != null)
		{
			List<Entity> list = new List<Entity>(_0023_003Dz_0024gv3_0024ykh68CDA6lTgA_003D_003D.Count);
			{
				foreach (Entity item in _0023_003Dz_0024gv3_0024ykh68CDA6lTgA_003D_003D)
				{
					if (!item.IsSmall(isSmallParams))
					{
						list.Add(item);
					}
				}
				return list;
			}
		}
		return _0023_003Dz_0024gv3_0024ykh68CDA6lTgA_003D_003D;
	}

	private bool _0023_003DzmP7qOAA_003D(Entity _0023_003DztJCl_0024mM_003D, Viewport _0023_003DzYzWi5Yw_003D)
	{
		string materialName = _0023_003DztJCl_0024mM_003D.MaterialName;
		Color color = ((_0023_003DztJCl_0024mM_003D is NestedEntity && ((NestedEntity)_0023_003DztJCl_0024mM_003D).ForceGray) ? ComputeNonCurrentEntityColor(_0023_003DztJCl_0024mM_003D, _0023_003DztJCl_0024mM_003D.Color, edge: false, forBlending: true) : _0023_003DztJCl_0024mM_003D.Color);
		bool flag = false;
		flag = _0023_003DzYzWi5Yw_003D.DisplayMode switch
		{
			displayType.Rendered => (!UtilityEx._0023_003Dzh_0024PIPDO0q5pY(_0023_003DztJCl_0024mM_003D)) ? (color.A != byte.MaxValue) : GfxAttributesColor.GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, materialName, color, _0023_003Dzxpbv4lQ_003D, _0023_003DztJCl_0024mM_003D is NestedEntity && ((NestedEntity)_0023_003DztJCl_0024mM_003D).ForceGray, this, _0023_003DztJCl_0024mM_003D, forBlending: true).IsTransparent(), 
			displayType.Flat => color.A != byte.MaxValue || (!string.IsNullOrEmpty(materialName) && _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D[materialName].IsTransparent()), 
			_ => color.A != byte.MaxValue, 
		};
		_0023_003Dz3K9P2qVNDagdSsl0lDQZuJ0_003D(_0023_003DztJCl_0024mM_003D, ref flag);
		if (flag && !NestedEntity.IsGrayMinFr(_0023_003DztJCl_0024mM_003D))
		{
			if (AccurateTransparency)
			{
				return !_0023_003DztJCl_0024mM_003D.IsPolygonal();
			}
			return false;
		}
		return true;
	}

	private BlockKeyedCollection _0023_003DzJLkqY2Pl7az_hGLMnMRgmAyD05jmE4HVXzg4_0024C0_003D()
	{
		return _0023_003DzoE3BE__0024RS_DJ();
	}

	BlockKeyedCollection IWorkspaceInternal.GetAllBlocks()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zJLkqY2Pl7az_hGLMnMRgmAyD05jmE4HVXzg4$C0=
		return this._0023_003DzJLkqY2Pl7az_hGLMnMRgmAyD05jmE4HVXzg4_0024C0_003D();
	}

	private IBoundingBoxSettings _0023_003Dz29CWSMNMeK0WRhLqFpfIJqpbTFEuFIOUPL6r22E_003D()
	{
		return _0023_003DzK3OaHhra7VrS;
	}

	IBoundingBoxSettings IWorkspaceInternal.get_BoundingBox()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z29CWSMNMeK0WRhLqFpfIJqpbTFEuFIOUPL6r22E=
		return this._0023_003Dz29CWSMNMeK0WRhLqFpfIJqpbTFEuFIOUPL6r22E_003D();
	}

	private Stack<BlockReference> _0023_003DzJLkqY2Pl7az_hGLMnMRgmHGdaT2qP95eLXYWEtc_003D()
	{
		return Parents;
	}

	Stack<BlockReference> IWorkspaceInternal.get_Parents()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zJLkqY2Pl7az_hGLMnMRgmHGdaT2qP95eLXYWEtc=
		return this._0023_003DzJLkqY2Pl7az_hGLMnMRgmHGdaT2qP95eLXYWEtc_003D();
	}

	private BlockKeyedCollection _0023_003DzUtzv4I0Bcct0kFoJio81HqE5wHAC9aBRaXH7Y48_003D()
	{
		return _0023_003DzOA_ac7k_003D;
	}

	BlockKeyedCollection IWorkspaceInternal.get_ParentBlocks()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zUtzv4I0Bcct0kFoJio81HqE5wHAC9aBRaXH7Y48=
		return this._0023_003DzUtzv4I0Bcct0kFoJio81HqE5wHAC9aBRaXH7Y48_003D();
	}

	private MaterialKeyedCollection _0023_003Dz2bk44vCEavIdC0QWKDes6L0cEhiMAk4mweSmx5CPH_sMNIH3LQ_003D_003D()
	{
		return _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D;
	}

	MaterialKeyedCollection IWorkspaceInternal.get_Materials()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z2bk44vCEavIdC0QWKDes6L0cEhiMAk4mweSmx5CPH_sMNIH3LQ==
		return this._0023_003Dz2bk44vCEavIdC0QWKDes6L0cEhiMAk4mweSmx5CPH_sMNIH3LQ_003D_003D();
	}

	private IEnvironment _0023_003Dz7KePxY6qhtVanBNEAXqlUtZkKJ6sjgJhjXM3c4c_003D()
	{
		return _0023_003DziuvwBNA4duWb;
	}

	IEnvironment IWorkspaceInternal.get_EnvironmentMap()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z7KePxY6qhtVanBNEAXqlUtZkKJ6sjgJhjXM3c4c=
		return this._0023_003Dz7KePxY6qhtVanBNEAXqlUtZkKJ6sjgJhjXM3c4c_003D();
	}

	private BlockKeyedCollection _0023_003DzSxxALXv_0024HdvIzchZM9XrTvIwlS794U57Y8EEAtE_003D()
	{
		return _0023_003DznJLjYKflIJCP;
	}

	BlockKeyedCollection IWorkspaceInternal.get_HiddenBlocks()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zSxxALXv$HdvIzchZM9XrTvIwlS794U57Y8EEAtE=
		return this._0023_003DzSxxALXv_0024HdvIzchZM9XrTvIwlS794U57Y8EEAtE_003D();
	}

	private void _0023_003Dz_0024zfTW7cb_U5kq5uwnBOM94yv8M963TZbo3ttyjo_003D(IViewport _0023_003DzYzWi5Yw_003D)
	{
		_0023_003DzSGfimhJkGdqe((Viewport)_0023_003DzYzWi5Yw_003D);
	}

	void IWorkspaceInternal.RaiseCameraMoveBegin(IViewport _0023_003DzYzWi5Yw_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z$zfTW7cb_U5kq5uwnBOM94yv8M963TZbo3ttyjo=
		this._0023_003Dz_0024zfTW7cb_U5kq5uwnBOM94yv8M963TZbo3ttyjo_003D(_0023_003DzYzWi5Yw_003D);
	}

	private void _0023_003DzYmZRTTnSr8jWIkVGCt_0024nMoXdU1NLpnG_00246e6r30k_003D(IViewport _0023_003DzYzWi5Yw_003D, viewType _0023_003Dzm1Aquqk_003D)
	{
		_0023_003Dz8fFk9aTlvPdc(_0023_003DzYzWi5Yw_003D, _0023_003Dzm1Aquqk_003D);
	}

	void IWorkspaceInternal.RaiseOnViewChanged(IViewport _0023_003DzYzWi5Yw_003D, viewType _0023_003Dzm1Aquqk_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zYmZRTTnSr8jWIkVGCt$nMoXdU1NLpnG$6e6r30k=
		this._0023_003DzYmZRTTnSr8jWIkVGCt_0024nMoXdU1NLpnG_00246e6r30k_003D(_0023_003DzYzWi5Yw_003D, _0023_003Dzm1Aquqk_003D);
	}

	private Color _0023_003DzkgW8ShMbFJ_0024G2N_0024WKf_0024gPO3PuXq3qvmjFtIKI4olFSlr(Entity _0023_003DzpWC0efg_003D, Color _0023_003Dzhpb8QNg_003D, bool _0023_003Dz9kko9rk_003D, bool _0023_003DzQzUKXUKYIVlQ6JMbCg_003D_003D)
	{
		return ComputeNonCurrentEntityColor(_0023_003DzpWC0efg_003D, _0023_003Dzhpb8QNg_003D, _0023_003Dz9kko9rk_003D, _0023_003DzQzUKXUKYIVlQ6JMbCg_003D_003D);
	}

	Color IWorkspaceInternal.ComputeNonCurrentEntityColor(Entity _0023_003DzpWC0efg_003D, Color _0023_003Dzhpb8QNg_003D, bool _0023_003Dz9kko9rk_003D, bool _0023_003DzQzUKXUKYIVlQ6JMbCg_003D_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zkgW8ShMbFJ$G2N$WKf$gPO3PuXq3qvmjFtIKI4olFSlr
		return this._0023_003DzkgW8ShMbFJ_0024G2N_0024WKf_0024gPO3PuXq3qvmjFtIKI4olFSlr(_0023_003DzpWC0efg_003D, _0023_003Dzhpb8QNg_003D, _0023_003Dz9kko9rk_003D, _0023_003DzQzUKXUKYIVlQ6JMbCg_003D_003D);
	}

	private bool _0023_003DzoZ7bjm01sHVXhrj8tUV_kIWGiKsJIxHLdTT6ZBo_003D()
	{
		return _0023_003DzXQRWQ3GhBR_Q();
	}

	bool IWorkspaceInternal.IsRenderingContextValid()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zoZ7bjm01sHVXhrj8tUV_kIWGiKsJIxHLdTT6ZBo=
		return this._0023_003DzoZ7bjm01sHVXhrj8tUV_kIWGiKsJIxHLdTT6ZBo_003D();
	}

	private bool _0023_003DzoZ7bjm01sHVXhrj8tUV_kIWGiKsJIxHLdTT6ZBo_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		return _0023_003DzXQRWQ3GhBR_Q(_0023_003DzmNZD0Zs_003D);
	}

	bool IWorkspaceInternal.IsRenderingContextValid(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zoZ7bjm01sHVXhrj8tUV_kIWGiKsJIxHLdTT6ZBo=
		return this._0023_003DzoZ7bjm01sHVXhrj8tUV_kIWGiKsJIxHLdTT6ZBo_003D(_0023_003DzmNZD0Zs_003D);
	}

	private bool _0023_003DzpntMWv0MwB_deUnvHyub0EUrWEBLXH9g3veI_3lryBjg()
	{
		return _0023_003DzyobtGSd5_zcs();
	}

	bool IWorkspaceInternal.get_IsAnimationRunning()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zpntMWv0MwB_deUnvHyub0EUrWEBLXH9g3veI_3lryBjg
		return this._0023_003DzpntMWv0MwB_deUnvHyub0EUrWEBLXH9g3veI_3lryBjg();
	}

	private bool _0023_003DzCtdaeymUiWYYDBhhYsVctQRMUTiHJWxvDYz_4Hh78vme()
	{
		return SuspendSetColorForSelection;
	}

	bool IWorkspaceInternal.get_SuspendSetColorForSelection()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zCtdaeymUiWYYDBhhYsVctQRMUTiHJWxvDYz_4Hh78vme
		return this._0023_003DzCtdaeymUiWYYDBhhYsVctQRMUTiHJWxvDYz_4Hh78vme();
	}

	private void _0023_003DzAIBfRNcpzEpMYNHw23uTHsI3gCOEAinS1i7aN9sA1o8g(bool _0023_003DzsLHxXyo_003D)
	{
		SuspendSetColorForSelection = _0023_003DzsLHxXyo_003D;
	}

	void IWorkspaceInternal.set_SuspendSetColorForSelection(bool _0023_003DzsLHxXyo_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zAIBfRNcpzEpMYNHw23uTHsI3gCOEAinS1i7aN9sA1o8g
		this._0023_003DzAIBfRNcpzEpMYNHw23uTHsI3gCOEAinS1i7aN9sA1o8g(_0023_003DzsLHxXyo_003D);
	}

	private int _0023_003Dz_00247rFrHtKP0RW8KV2uJ3jOAZ_1hb4KfYHgK1JYJs_003D()
	{
		return _0023_003DzNwtRJ3cLTrAy();
	}

	int IWorkspaceInternal.get_MyHeight()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z$7rFrHtKP0RW8KV2uJ3jOAZ_1hb4KfYHgK1JYJs=
		return this._0023_003Dz_00247rFrHtKP0RW8KV2uJ3jOAZ_1hb4KfYHgK1JYJs_003D();
	}

	private int _0023_003Dzx_Te9p7sfciYXbz1Rzvc3imDQvMD3NRgCkAFXAY_003D()
	{
		return _0023_003Dz0P1LCYH__O4t();
	}

	int IWorkspaceInternal.get_MyWidth()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zx_Te9p7sfciYXbz1Rzvc3imDQvMD3NRgCkAFXAY=
		return this._0023_003Dzx_Te9p7sfciYXbz1Rzvc3imDQvMD3NRgCkAFXAY_003D();
	}

	private BackfaceSettings _0023_003DzGy2dBbQrmU1iUSwXbCFu0sjfGIKr_0024lMSaJUG0ZGri_iZ()
	{
		return _0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D;
	}

	BackfaceSettings IWorkspaceInternal.get_Backface()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zGy2dBbQrmU1iUSwXbCFu0sjfGIKr$lMSaJUG0ZGri_iZ
		return this._0023_003DzGy2dBbQrmU1iUSwXbCFu0sjfGIKr_0024lMSaJUG0ZGri_iZ();
	}

	private Transformation _0023_003DzGtEZ0xrozOFx3Duo6KRlZODizVPTmaULj0urUbVkoUuB()
	{
		return _0023_003DzFq8cO_00245h9dst();
	}

	Transformation IWorkspaceInternal.get_CurrentTransformationInverse()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zGtEZ0xrozOFx3Duo6KRlZODizVPTmaULj0urUbVkoUuB
		return this._0023_003DzGtEZ0xrozOFx3Duo6KRlZODizVPTmaULj0urUbVkoUuB();
	}

	private bool _0023_003DzHTQZ0AKmgLCqFlabbCIP1Kmy66RL_00249_wunJCrpA_003D()
	{
		return _0023_003DzioJIQ5Bufb8i;
	}

	bool IWorkspaceInternal.get_skipMoveTo()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zHTQZ0AKmgLCqFlabbCIP1Kmy66RL$9_wunJCrpA=
		return this._0023_003DzHTQZ0AKmgLCqFlabbCIP1Kmy66RL_00249_wunJCrpA_003D();
	}

	private BlockReference _0023_003DzRk8ZIAeM1PoiTd1B00LY9S2WSEw1aNOA3SXXR_0024l5XvE1_qGwICnGWOw_003D()
	{
		return _0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO;
	}

	BlockReference IWorkspaceInternal.get_BlockReferenceForObjectManipulator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zRk8ZIAeM1PoiTd1B00LY9S2WSEw1aNOA3SXXR$l5XvE1_qGwICnGWOw=
		return this._0023_003DzRk8ZIAeM1PoiTd1B00LY9S2WSEw1aNOA3SXXR_0024l5XvE1_qGwICnGWOw_003D();
	}

	private IObjectManipulator _0023_003DzLqmzTZzgEEQiPss9_vQ_00242rzrWsEI89OqOv9v6LvPTD_0024L42Psxg_003D_003D()
	{
		return _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D;
	}

	IObjectManipulator IWorkspaceInternal.get_ObjectManipulator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zLqmzTZzgEEQiPss9_vQ$2rzrWsEI89OqOv9v6LvPTD$L42Psxg==
		return this._0023_003DzLqmzTZzgEEQiPss9_vQ_00242rzrWsEI89OqOv9v6LvPTD_0024L42Psxg_003D_003D();
	}

	private Stack<Block> _0023_003DzudmJWTT_VblqCzaqn4wK_0024j1j9X9oDcsAV6GjVu0_003D()
	{
		return _0023_003Dz0Ho1jARga6O0();
	}

	Stack<Block> IWorkspaceInternal.get_OpenParents()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zudmJWTT_VblqCzaqn4wK$j1j9X9oDcsAV6GjVu0=
		return this._0023_003DzudmJWTT_VblqCzaqn4wK_0024j1j9X9oDcsAV6GjVu0_003D();
	}

	private int _0023_003DzKthfbBHxtpw9eLMCwiQ12mcJuoRWQi1qVZA4YH3UbImw()
	{
		return _0023_003DzzFGpNZit9CtK.Count;
	}

	int IWorkspaceInternal.get_OpenBlocksDataCount()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zKthfbBHxtpw9eLMCwiQ12mcJuoRWQi1qVZA4YH3UbImw
		return this._0023_003DzKthfbBHxtpw9eLMCwiQ12mcJuoRWQi1qVZA4YH3UbImw();
	}

	private BlockReference _0023_003Dz_0024zfTW7cb_U5kq5uwnBOM97ym0Nd9Oc10qP6bbeg_003D()
	{
		return CurrentBlockReference;
	}

	BlockReference IWorkspaceInternal.get_CurrentBlockReference()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z$zfTW7cb_U5kq5uwnBOM97ym0Nd9Oc10qP6bbeg=
		return this._0023_003Dz_0024zfTW7cb_U5kq5uwnBOM97ym0Nd9Oc10qP6bbeg_003D();
	}

	private Material _0023_003DzkxxL6PUv2OYLl3xaXeTmxDkZSt_0024P54BxYYEW2ac_003D()
	{
		return _0023_003Dzxpbv4lQ_003D;
	}

	Material IWorkspaceInternal.get_DefaultMaterial()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zkxxL6PUv2OYLl3xaXeTmxDkZSt$P54BxYYEW2ac=
		return this._0023_003DzkxxL6PUv2OYLl3xaXeTmxDkZSt_0024P54BxYYEW2ac_003D();
	}

	private IHiddenLinesSettings _0023_003Dzz0rWAF7BGpiU6uGk8YVBKsNA289TlCTQi9ZoXSk_003D()
	{
		return _0023_003DzP6FAuV4Dwq24;
	}

	IHiddenLinesSettings IWorkspaceInternal.get_HiddenLines()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zz0rWAF7BGpiU6uGk8YVBKsNA289TlCTQi9ZoXSk=
		return this._0023_003Dzz0rWAF7BGpiU6uGk8YVBKsNA289TlCTQi9ZoXSk_003D();
	}

	private IDisplayModeSettings _0023_003DzVMQRMeIgfIz1nfo5F2JH7eZBbtBL6J97VuOs_0024bqGhJttalHDhA_003D_003D()
	{
		return _0023_003DzAdpXPj_0024l7nqBsSXydw_003D_003D;
	}

	IDisplayModeSettings IWorkspaceInternal.get_Wireframe()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zVMQRMeIgfIz1nfo5F2JH7eZBbtBL6J97VuOs$bqGhJttalHDhA==
		return this._0023_003DzVMQRMeIgfIz1nfo5F2JH7eZBbtBL6J97VuOs_0024bqGhJttalHDhA_003D_003D();
	}

	private IDisplayModeSettingsRendered _0023_003DzpIcD9h6nNr6r7YYfMcU55ExsbyPjcFqk6VSZlvw_003D()
	{
		return _0023_003DznKkOfo8_003D;
	}

	IDisplayModeSettingsRendered IWorkspaceInternal.get_Rendered()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zpIcD9h6nNr6r7YYfMcU55ExsbyPjcFqk6VSZlvw=
		return this._0023_003DzpIcD9h6nNr6r7YYfMcU55ExsbyPjcFqk6VSZlvw_003D();
	}

	private IDisplayModeSettings _0023_003DzSKN5MimU6Ec4fTtQ8Tr8wzBKxI4GD4uQCof6JK7RdiAL()
	{
		return _0023_003DzAv2OMNy7DJ5L;
	}

	IDisplayModeSettings IWorkspaceInternal.get_Shaded()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zSKN5MimU6Ec4fTtQ8Tr8wzBKxI4GD4uQCof6JK7RdiAL
		return this._0023_003DzSKN5MimU6Ec4fTtQ8Tr8wzBKxI4GD4uQCof6JK7RdiAL();
	}

	private IDisplayModeSettings _0023_003DzPj3Ss4y5y1iTOGbb207HExzYdG_0024gJzVYYPWLKvE_003D()
	{
		return _0023_003Dzipe8ch4_003D;
	}

	IDisplayModeSettings IWorkspaceInternal.get_Flat()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zPj3Ss4y5y1iTOGbb207HExzYdG$gJzVYYPWLKvE=
		return this._0023_003DzPj3Ss4y5y1iTOGbb207HExzYdG_0024gJzVYYPWLKvE_003D();
	}

	private IDisplayModeSettings _0023_003DzyJdYUTxhlDkEjzn7EOzUDKSD7DFyUphMf9_zVZhyunsG(displayType _0023_003DzK_00241ezHQJ9Z3c)
	{
		return _0023_003Dz0fTtstT4IqGh(_0023_003DzK_00241ezHQJ9Z3c);
	}

	IDisplayModeSettings IWorkspaceInternal.GetDisplayModeSettings(displayType _0023_003DzK_00241ezHQJ9Z3c)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zyJdYUTxhlDkEjzn7EOzUDKSD7DFyUphMf9_zVZhyunsG
		return this._0023_003DzyJdYUTxhlDkEjzn7EOzUDKSD7DFyUphMf9_zVZhyunsG(_0023_003DzK_00241ezHQJ9Z3c);
	}

	private Stack<BlockReference> _0023_003DzZXHZ8r_AKGbCsLnm7EUe19Q_0024cagFGpTWNuRDgrs_003D()
	{
		return _0023_003Dzkm9D6jYtZW1j;
	}

	Stack<BlockReference> IWorkspaceInternal.get_selectionScope()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zZXHZ8r_AKGbCsLnm7EUe19Q$cagFGpTWNuRDgrs=
		return this._0023_003DzZXHZ8r_AKGbCsLnm7EUe19Q_0024cagFGpTWNuRDgrs_003D();
	}

	private ClippingPlane _0023_003DzXJpRx_0024Sdo6gLvKtucztWxjbunQdHXgdH_0024fT12t48fFpi()
	{
		return _0023_003DzG6pm3fB_0024JDYx85tz2g_003D_003D;
	}

	ClippingPlane IWorkspaceInternal.get_ClippingPlane1()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zXJpRx$Sdo6gLvKtucztWxjbunQdHXgdH$fT12t48fFpi
		return this._0023_003DzXJpRx_0024Sdo6gLvKtucztWxjbunQdHXgdH_0024fT12t48fFpi();
	}

	private void _0023_003DzGy2dBbQrmU1iUSwXbCFu0mFwf8vV4x31TKmNULShn7xX(ClippingPlane _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzG6pm3fB_0024JDYx85tz2g_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	void IWorkspaceInternal.set_ClippingPlane1(ClippingPlane _0023_003DzsLHxXyo_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zGy2dBbQrmU1iUSwXbCFu0mFwf8vV4x31TKmNULShn7xX
		this._0023_003DzGy2dBbQrmU1iUSwXbCFu0mFwf8vV4x31TKmNULShn7xX(_0023_003DzsLHxXyo_003D);
	}

	private ClippingPlaneBase[] _0023_003DzUXITLb7rqJvXEctvYHmEyNGX4C44ujRF9goCoA7qHSSIJfbfFQ_003D_003D()
	{
		return _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D;
	}

	ClippingPlaneBase[] IWorkspaceInternal.get_clippingPlanes()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zUXITLb7rqJvXEctvYHmEyNGX4C44ujRF9goCoA7qHSSIJfbfFQ==
		return this._0023_003DzUXITLb7rqJvXEctvYHmEyNGX4C44ujRF9goCoA7qHSSIJfbfFQ_003D_003D();
	}

	private LightSettings[] _0023_003DzSry_FCTslrJYXHG2wFxixADo9_0024Nt1sLDEq0NwlZZyXyc()
	{
		return _0023_003DzMuApP021PUyU;
	}

	LightSettings[] IWorkspaceInternal.get_lights()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zSry_FCTslrJYXHG2wFxixADo9$Nt1sLDEq0NwlZZyXyc
		return this._0023_003DzSry_FCTslrJYXHG2wFxixADo9_0024Nt1sLDEq0NwlZZyXyc();
	}

	private void _0023_003DzkkfuYpc6CaUP63iTDvP9LBwR7z2X9hCFoAxcctc_003D(SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e)
	{
		_0023_003Dzvt4CNgJSomsF(_0023_003DzdXQchgXOgG_0024e);
	}

	void IWorkspaceInternal.FireSelectionChanged(SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zkkfuYpc6CaUP63iTDvP9LBwR7z2X9hCFoAxcctc=
		this._0023_003DzkkfuYpc6CaUP63iTDvP9LBwR7z2X9hCFoAxcctc_003D(_0023_003DzdXQchgXOgG_0024e);
	}

	private Color _0023_003DzF7hUnYsa5vutp7oScw9G79AeMylBvdEjFFqdxkQxwOOQ(Color _0023_003Dzhpb8QNg_003D, double _0023_003Dz1CEjt3w_003D)
	{
		return _0023_003Dz172y4KzLmCm83OqS4g_003D_003D(_0023_003Dzhpb8QNg_003D, _0023_003Dz1CEjt3w_003D);
	}

	Color IWorkspaceInternal.MakeDarkerColor(Color _0023_003Dzhpb8QNg_003D, double _0023_003Dz1CEjt3w_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zF7hUnYsa5vutp7oScw9G79AeMylBvdEjFFqdxkQxwOOQ
		return this._0023_003DzF7hUnYsa5vutp7oScw9G79AeMylBvdEjFFqdxkQxwOOQ(_0023_003Dzhpb8QNg_003D, _0023_003Dz1CEjt3w_003D);
	}

	private bool _0023_003Dz6Fk8Jpfx7dDN0Jyk4Ns5Ejwf7J_0024YRQDdRMab10XfkpJ7qobY6g_003D_003D(IViewportInternal _0023_003DzYzWi5Yw_003D)
	{
		return _0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(_0023_003DzYzWi5Yw_003D);
	}

	bool IWorkspaceInternal.ShouldDrawDynamicWithHalo(IViewportInternal _0023_003DzYzWi5Yw_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z6Fk8Jpfx7dDN0Jyk4Ns5Ejwf7J$YRQDdRMab10XfkpJ7qobY6g==
		return this._0023_003Dz6Fk8Jpfx7dDN0Jyk4Ns5Ejwf7J_0024YRQDdRMab10XfkpJ7qobY6g_003D_003D(_0023_003DzYzWi5Yw_003D);
	}

	private bool _0023_003DzADU18F_uLr6Kb7JTIySeMXqKNIIW27yeKnQtJ0LZanaDHiw3FA_003D_003D(IViewportInternal _0023_003DzYzWi5Yw_003D)
	{
		return _0023_003DzQu3GZ_YX9HKhihqq3g_003D_003D(_0023_003DzYzWi5Yw_003D);
	}

	bool IWorkspaceInternal.ShouldDrawStaticWithHalo(IViewportInternal _0023_003DzYzWi5Yw_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zADU18F_uLr6Kb7JTIySeMXqKNIIW27yeKnQtJ0LZanaDHiw3FA==
		return this._0023_003DzADU18F_uLr6Kb7JTIySeMXqKNIIW27yeKnQtJ0LZanaDHiw3FA_003D_003D(_0023_003DzYzWi5Yw_003D);
	}

	private BlockReference _0023_003DzxYO1Tlx3Xv2cYLfz11xNCfUnxL1JKpLJMo_0024R9eA_003D()
	{
		return _0023_003DzpU_kB1T_2Sae();
	}

	BlockReference IWorkspaceInternal.BuildRootEntity()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zxYO1Tlx3Xv2cYLfz11xNCfUnxL1JKpLJMo$R9eA=
		return this._0023_003DzxYO1Tlx3Xv2cYLfz11xNCfUnxL1JKpLJMo_0024R9eA_003D();
	}

	private void _0023_003DzbXPjqrDftDbyM5oi0u4ChMB_0024qCqhG01DOMUBQKPSuCMt7Ch7b4GZmZk_003D(IReadOnlyList<Block> _0023_003Dz9W2nj9A_003D, bool _0023_003DzdT0PBw1onYvu)
	{
		_0023_003DzTdGsKPrsLPf8lMrax9_0024HWb0_003D(_0023_003Dz9W2nj9A_003D, _0023_003DzdT0PBw1onYvu);
	}

	void IWorkspaceInternal.ResetAllConvexHulls(IReadOnlyList<Block> _0023_003Dz9W2nj9A_003D, bool _0023_003DzdT0PBw1onYvu)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zbXPjqrDftDbyM5oi0u4ChMB$qCqhG01DOMUBQKPSuCMt7Ch7b4GZmZk=
		this._0023_003DzbXPjqrDftDbyM5oi0u4ChMB_0024qCqhG01DOMUBQKPSuCMt7Ch7b4GZmZk_003D(_0023_003Dz9W2nj9A_003D, _0023_003DzdT0PBw1onYvu);
	}

	private IList<Entity> _0023_003Dz4Dg7S88__0024H_0024lmhELNhenJ01R867lT52DipquBWo_003D()
	{
		return _0023_003DzOWfUZLjOSimJ();
	}

	IList<Entity> IWorkspaceInternal.GetAllEntities()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z4Dg7S88_$H$lmhELNhenJ01R867lT52DipquBWo=
		return this._0023_003Dz4Dg7S88__0024H_0024lmhELNhenJ01R867lT52DipquBWo_003D();
	}

	private bool _0023_003DzwZ9QhuttrgkQmNnGflFgq6LqLocKZemoL7kJuLg_003D<T>(bool _0023_003Dzl7FZ5_su2I_0024n, T _0023_003DzyrRdBi78wMnR, Entity _0023_003DztJCl_0024mM_003D) where T : DrawParams
	{
		return _0023_003DzlT_tPDs_003D(_0023_003Dzl7FZ5_su2I_0024n, _0023_003DzyrRdBi78wMnR, _0023_003DztJCl_0024mM_003D);
	}

	bool IWorkspaceInternal.IsSelected<T>(bool _0023_003Dzl7FZ5_su2I_0024n, T _0023_003DzyrRdBi78wMnR, Entity _0023_003DztJCl_0024mM_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zwZ9QhuttrgkQmNnGflFgq6LqLocKZemoL7kJuLg=
		return this._0023_003DzwZ9QhuttrgkQmNnGflFgq6LqLocKZemoL7kJuLg_003D<T>(_0023_003Dzl7FZ5_su2I_0024n, _0023_003DzyrRdBi78wMnR, _0023_003DztJCl_0024mM_003D);
	}

	private bool _0023_003DzmhGGKR7pv0p18wL2_EWYNKlUxm0v8L4hl_F1GFaxhFfU<T>(bool _0023_003DzXluM0iA_003D, T _0023_003DzyrRdBi78wMnR) where T : DrawParams
	{
		return _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(_0023_003DzXluM0iA_003D, _0023_003DzyrRdBi78wMnR);
	}

	bool IWorkspaceInternal.ShouldDrawAsSelected<T>(bool _0023_003DzXluM0iA_003D, T _0023_003DzyrRdBi78wMnR)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zmhGGKR7pv0p18wL2_EWYNKlUxm0v8L4hl_F1GFaxhFfU
		return this._0023_003DzmhGGKR7pv0p18wL2_EWYNKlUxm0v8L4hl_F1GFaxhFfU<T>(_0023_003DzXluM0iA_003D, _0023_003DzyrRdBi78wMnR);
	}

	private bool _0023_003DzdPtvklPFzKqxMoTpEOXyeAiFYCV3C2xiDJpiMA17cTjHvIJPgDh8tVg_003D(DrawEntitiesParams _0023_003Dzt5jpbHs_003D)
	{
		return _0023_003DzqycL4xalHFGitSlY6XcpAvGGtqX5(_0023_003Dzt5jpbHs_003D);
	}

	bool IWorkspaceInternal.DrawTrianglesForShadowMap(DrawEntitiesParams _0023_003Dzt5jpbHs_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zdPtvklPFzKqxMoTpEOXyeAiFYCV3C2xiDJpiMA17cTjHvIJPgDh8tVg=
		return this._0023_003DzdPtvklPFzKqxMoTpEOXyeAiFYCV3C2xiDJpiMA17cTjHvIJPgDh8tVg_003D(_0023_003Dzt5jpbHs_003D);
	}

	private void _0023_003DzfH87z2QUnmck0GUXuynaZakChfEF_Ts_00248xK4OEGiiTIsaxEM4A_003D_003D()
	{
		_0023_003DzgChooeM7YyYsnw0AK4qKYfg_003D();
	}

	void IWorkspaceInternal.ResetNeededConvexHull()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zfH87z2QUnmck0GUXuynaZakChfEF_Ts$8xK4OEGiiTIsaxEM4A==
		this._0023_003DzfH87z2QUnmck0GUXuynaZakChfEF_Ts_00248xK4OEGiiTIsaxEM4A_003D_003D();
	}

	private void _0023_003Dz_00245GAm2AVkX5fKPUgi4HHNLzUx2zQj1t4qgC742E_003D()
	{
		_0023_003DzaxZuxNzApM2J();
	}

	void IWorkspaceInternal.InitializeRootBlock()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z$5GAm2AVkX5fKPUgi4HHNLzUx2zQj1t4qgC742E=
		this._0023_003Dz_00245GAm2AVkX5fKPUgi4HHNLzUx2zQj1t4qgC742E_003D();
	}

	private void _0023_003DzdPtvklPFzKqxMoTpEOXyePMSfpg4H6FGlh8a5C4_003D(bool _0023_003DzIH4xUe5IjPB_0024)
	{
		_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024);
	}

	void IWorkspaceInternal.DestroyFlattenedTree(bool _0023_003DzIH4xUe5IjPB_0024)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zdPtvklPFzKqxMoTpEOXyePMSfpg4H6FGlh8a5C4=
		this._0023_003DzdPtvklPFzKqxMoTpEOXyePMSfpg4H6FGlh8a5C4_003D(_0023_003DzIH4xUe5IjPB_0024);
	}

	private void _0023_003DzBJElHqxtPPtMLXcUwpVKUM3p8JSRTYuVi70ve7kZ31DP(string _0023_003DzYQvHPFc_003D)
	{
		_0023_003DzySA_0024LLKpRxqJbYvt2g_003D_003D(_0023_003DzYQvHPFc_003D);
	}

	void IWorkspaceInternal.UpdateLayerNameForInternalElements(string _0023_003DzYQvHPFc_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zBJElHqxtPPtMLXcUwpVKUM3p8JSRTYuVi70ve7kZ31DP
		this._0023_003DzBJElHqxtPPtMLXcUwpVKUM3p8JSRTYuVi70ve7kZ31DP(_0023_003DzYQvHPFc_003D);
	}

	private byte[] _0023_003DzOKWbo7sUM8LpXGAfWbsy7pVGP3aKmbLaTfPvti_kqToxYrCG9A_003D_003D(string _0023_003DzaO_0024_BNc_003D, Color _0023_003DzIQeFgJI_003D, Color _0023_003Dzhpb8QNg_003D, IntPtr _0023_003DzWUgqGwA_003D, out Size _0023_003Dz0ERMHbg_003D)
	{
		Font font = new Font(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348597621), 40f, FontStyle.Bold);
		try
		{
			using Image image = _0023_003DzRFGA2zTmmjXj(_0023_003DzaO_0024_BNc_003D, font, _0023_003DzIQeFgJI_003D, _0023_003Dzhpb8QNg_003D, _0023_003DzWUgqGwA_003D, RotateFlipType.RotateNoneFlipNone, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0);
			_0023_003Dz0ERMHbg_003D = image.Size;
			return image.ToByteArray();
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
	}

	byte[] IWorkspaceInternal.GetMachiningLabelImage(string _0023_003DzaO_0024_BNc_003D, Color _0023_003DzIQeFgJI_003D, Color _0023_003Dzhpb8QNg_003D, IntPtr _0023_003DzWUgqGwA_003D, out Size _0023_003Dz0ERMHbg_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zOKWbo7sUM8LpXGAfWbsy7pVGP3aKmbLaTfPvti_kqToxYrCG9A==
		return this._0023_003DzOKWbo7sUM8LpXGAfWbsy7pVGP3aKmbLaTfPvti_kqToxYrCG9A_003D_003D(_0023_003DzaO_0024_BNc_003D, _0023_003DzIQeFgJI_003D, _0023_003Dzhpb8QNg_003D, _0023_003DzWUgqGwA_003D, out _0023_003Dz0ERMHbg_003D);
	}

	private SizeF _0023_003DzLvWBG7zhJ6b2ie83HJ1FGj8aulqZUneY1jphzko_003D()
	{
		return _0023_003DztnrgTmT5sBNd();
	}

	SizeF IWorkspaceInternal.GetScalingLevel()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zLvWBG7zhJ6b2ie83HJ1FGj8aulqZUneY1jphzko=
		return this._0023_003DzLvWBG7zhJ6b2ie83HJ1FGj8aulqZUneY1jphzko_003D();
	}

	private bool _0023_003DzBRA9vuhjXw8iIYBrrAYOrfxMaYF5CxjrdaqlptUGbA9x(Point3D _0023_003DzbaIR7Idi0nFj, double _0023_003Dzr3UB3cq4OkpMx3b7dw_003D_003D, double _0023_003DzwtkSKOYTrN9W33BLYw_003D_003D)
	{
		return IsCloserVertex(_0023_003DzbaIR7Idi0nFj, _0023_003Dzr3UB3cq4OkpMx3b7dw_003D_003D, _0023_003DzwtkSKOYTrN9W33BLYw_003D_003D);
	}

	bool IWorkspaceInternal.IsCloserVertex(Point3D _0023_003DzbaIR7Idi0nFj, double _0023_003Dzr3UB3cq4OkpMx3b7dw_003D_003D, double _0023_003DzwtkSKOYTrN9W33BLYw_003D_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zBRA9vuhjXw8iIYBrrAYOrfxMaYF5CxjrdaqlptUGbA9x
		return this._0023_003DzBRA9vuhjXw8iIYBrrAYOrfxMaYF5CxjrdaqlptUGbA9x(_0023_003DzbaIR7Idi0nFj, _0023_003Dzr3UB3cq4OkpMx3b7dw_003D_003D, _0023_003DzwtkSKOYTrN9W33BLYw_003D_003D);
	}

	private ICursorContainer _0023_003DzypjSbXydiLqeF2Yb30_00244crXBMOZGzcFsuXww0uo_003D()
	{
		return SetWaitCursor();
	}

	ICursorContainer IWorkspaceInternal.SetWaitCursor()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zypjSbXydiLqeF2Yb30$4crXBMOZGzcFsuXww0uo=
		return this._0023_003DzypjSbXydiLqeF2Yb30_00244crXBMOZGzcFsuXww0uo_003D();
	}

	private void _0023_003Dz7KePxY6qhtVanBNEAXqlUrjy0gWHpgKtukqfmtA_003D(ICursorContainer _0023_003DzXZgsirs_003D)
	{
		RestoreCursor((CursorContainer)(object)_0023_003DzXZgsirs_003D);
	}

	void IWorkspaceInternal.RestoreCursor(ICursorContainer _0023_003DzXZgsirs_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z7KePxY6qhtVanBNEAXqlUrjy0gWHpgKtukqfmtA=
		this._0023_003Dz7KePxY6qhtVanBNEAXqlUrjy0gWHpgKtukqfmtA_003D(_0023_003DzXZgsirs_003D);
	}

	private object _0023_003DzfH87z2QUnmck0GUXuynaZYDEjvec4kipIcjAba4_003D(string _0023_003DzyTdq_VY_003D)
	{
		_0023_003DzMO1WVpUW1GsdMI4kNx7bll4_003D obj = new _0023_003DzMO1WVpUW1GsdMI4kNx7bll4_003D
		{
			_0023_003DzyTdq_VY_003D = _0023_003DzyTdq_VY_003D,
			_0023_003DzZoEki8U_003D = null
		};
		Thread thread = new Thread((ThreadStart)delegate
		{
			obj._0023_003DzZoEki8U_003D = Clipboard.GetData(obj._0023_003DzyTdq_VY_003D);
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
		return obj._0023_003DzZoEki8U_003D;
	}

	object IWorkspaceInternal.GetClipboardData(string _0023_003DzyTdq_VY_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zfH87z2QUnmck0GUXuynaZYDEjvec4kipIcjAba4=
		return this._0023_003DzfH87z2QUnmck0GUXuynaZYDEjvec4kipIcjAba4_003D(_0023_003DzyTdq_VY_003D);
	}

	private void _0023_003DzoSjmcwD_0024fMBWHjBBt3y6mxIc8Anv7TpGGpekFx0_003D(string _0023_003DzyTdq_VY_003D, object _0023_003Dzt5jpbHs_003D)
	{
		Thread thread = new Thread(new _0023_003DzkT8AkN0DJt3aFfHDxmWXoPc_003D
		{
			_0023_003DzyTdq_VY_003D = _0023_003DzyTdq_VY_003D,
			_0023_003Dzt5jpbHs_003D = _0023_003Dzt5jpbHs_003D
		}._0023_003DzLDGhoK0vtKJ2MRzE2yDubffqpmGcupP5mhCTcI8Afzks);
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		thread.Join();
	}

	void IWorkspaceInternal.SetClipboardData(string _0023_003DzyTdq_VY_003D, object _0023_003Dzt5jpbHs_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zoSjmcwD$fMBWHjBBt3y6mxIc8Anv7TpGGpekFx0=
		this._0023_003DzoSjmcwD_0024fMBWHjBBt3y6mxIc8Anv7TpGGpekFx0_003D(_0023_003DzyTdq_VY_003D, _0023_003Dzt5jpbHs_003D);
	}

	private bool _0023_003DzNh8c1zkQE7L3HxgqryZIQJDEi2G2HFnyehYMbS0_003D()
	{
		return RightToLeft == RightToLeft.Yes;
	}

	bool IWorkspaceInternal.IsRightToLeft()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zNh8c1zkQE7L3HxgqryZIQJDEi2G2HFnyehYMbS0=
		return this._0023_003DzNh8c1zkQE7L3HxgqryZIQJDEi2G2HFnyehYMbS0_003D();
	}

	private Color _0023_003DzNjpGxrDPZl6JAYEwSevBQI2u_0024UokMQmT0EFPk6kAQsqXXAb7uw_003D_003D()
	{
		return _0023_003DzXVJ6CvJJYmrqf3ztQQ_003D_003D;
	}

	Color IWorkspaceInternal.get_ambientLight()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zNjpGxrDPZl6JAYEwSevBQI2u$UokMQmT0EFPk6kAQsqXXAb7uw==
		return this._0023_003DzNjpGxrDPZl6JAYEwSevBQI2u_0024UokMQmT0EFPk6kAQsqXXAb7uw_003D_003D();
	}

	private bool _0023_003Dz_00242iQD1FOOBMB8Ag0xLXT0xuf_00243V_9v3Kh2CoZPw_003D(IIsolateParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D)
	{
		return _0023_003Dzlrl6ZJY_003D(_0023_003Dzt5jpbHs_003D, _0023_003DztJCl_0024mM_003D);
	}

	bool IWorkspaceInternal.IsIsolated(IIsolateParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z$2iQD1FOOBMB8Ag0xLXT0xuf$3V_9v3Kh2CoZPw=
		return this._0023_003Dz_00242iQD1FOOBMB8Ag0xLXT0xuf_00243V_9v3Kh2CoZPw_003D(_0023_003Dzt5jpbHs_003D, _0023_003DztJCl_0024mM_003D);
	}

	private bool _0023_003DzAfl1HVv9xY8KtbaPVdrnOXrU1_TklINtfX8z_0024L0_003D(IIsolateParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D)
	{
		return _0023_003Dz4RlPrk9tv7S7(_0023_003Dzt5jpbHs_003D, _0023_003DztJCl_0024mM_003D);
	}

	bool IWorkspaceInternal.IsSelectableForIsolation(IIsolateParams _0023_003Dzt5jpbHs_003D, Entity _0023_003DztJCl_0024mM_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zAfl1HVv9xY8KtbaPVdrnOXrU1_TklINtfX8z$L0=
		return this._0023_003DzAfl1HVv9xY8KtbaPVdrnOXrU1_TklINtfX8z_0024L0_003D(_0023_003Dzt5jpbHs_003D, _0023_003DztJCl_0024mM_003D);
	}

	private zoomFitType _0023_003DzvBYkjV2bojftjGDl9crdcKMLBSV2npYBrAKluHL1LEPZ()
	{
		if (this is Design design)
		{
			return design.ZoomFitMode;
		}
		return zoomFitType.Standard;
	}

	zoomFitType IWorkspaceInternal.get_ZoomFitMode()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zvBYkjV2bojftjGDl9crdcKMLBSV2npYBrAKluHL1LEPZ
		return this._0023_003DzvBYkjV2bojftjGDl9crdcKMLBSV2npYBrAKluHL1LEPZ();
	}

	private byte[] _0023_003DzQPZkqfZHRcivzqTsIUNQCjEgL7T5GGlCrygd3Fc_003D(int _0023_003DzUzJqdYe8H_yCoigCdg_003D_003D, Color _0023_003DzNLGcq5k_003D)
	{
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			return _0023_003DzipBYly6zFKAp()._0023_003DzTgPYdNm9og8y(_0023_003DzUzJqdYe8H_yCoigCdg_003D_003D, _0023_003DzNLGcq5k_003D);
		}
		return null;
	}

	byte[] IWorkspaceInternal.GetThumbnailBytes(int _0023_003DzUzJqdYe8H_yCoigCdg_003D_003D, Color _0023_003DzNLGcq5k_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zQPZkqfZHRcivzqTsIUNQCjEgL7T5GGlCrygd3Fc=
		return this._0023_003DzQPZkqfZHRcivzqTsIUNQCjEgL7T5GGlCrygd3Fc_003D(_0023_003DzUzJqdYe8H_yCoigCdg_003D_003D, _0023_003DzNLGcq5k_003D);
	}

	private void _0023_003Dz3XDsGZ9GiS3bi2_0024WcC3hvKEb_NPLpztvJk2Yk6vfbRNqmKNEmw_003D_003D(WriteMultiFile _0023_003DzeQXXxPAf9PYN, FileSerializer _0023_003DzPQvnoRZw23LX, List<string> _0023_003DzSTLbXssBz20Y, IViewport _0023_003DzGSpOx5G7KdbpHHwPb3vgrD8_003D, bool _0023_003Dz_f45qRs9_0024Fc_9uCJJp7qKZ4_003D, Color _0023_003Dzazl33QeoulkThzFYGktOOGk_003D, StringBuilder _0023_003DzccBsfnw_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D, CancellationToken _0023_003DzkIE5Tx8_003D)
	{
		_0023_003Dz5jXZjqaEuXn58IInTj0oVRdpFSDr9RqgIg_003D_003D(_0023_003DzeQXXxPAf9PYN, _0023_003DzPQvnoRZw23LX, _0023_003DzSTLbXssBz20Y, _0023_003DzGSpOx5G7KdbpHHwPb3vgrD8_003D, _0023_003Dz_f45qRs9_0024Fc_9uCJJp7qKZ4_003D, _0023_003Dzazl33QeoulkThzFYGktOOGk_003D, _0023_003DzccBsfnw_003D, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D);
	}

	void IWorkspaceInternal.UpdateThumbnails(WriteMultiFile _0023_003DzeQXXxPAf9PYN, FileSerializer _0023_003DzPQvnoRZw23LX, List<string> _0023_003DzSTLbXssBz20Y, IViewport _0023_003DzGSpOx5G7KdbpHHwPb3vgrD8_003D, bool _0023_003Dz_f45qRs9_0024Fc_9uCJJp7qKZ4_003D, Color _0023_003Dzazl33QeoulkThzFYGktOOGk_003D, StringBuilder _0023_003DzccBsfnw_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D, CancellationToken _0023_003DzkIE5Tx8_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z3XDsGZ9GiS3bi2$WcC3hvKEb_NPLpztvJk2Yk6vfbRNqmKNEmw==
		this._0023_003Dz3XDsGZ9GiS3bi2_0024WcC3hvKEb_NPLpztvJk2Yk6vfbRNqmKNEmw_003D_003D(_0023_003DzeQXXxPAf9PYN, _0023_003DzPQvnoRZw23LX, _0023_003DzSTLbXssBz20Y, _0023_003DzGSpOx5G7KdbpHHwPb3vgrD8_003D, _0023_003Dz_f45qRs9_0024Fc_9uCJJp7qKZ4_003D, _0023_003Dzazl33QeoulkThzFYGktOOGk_003D, _0023_003DzccBsfnw_003D, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D);
	}

	private void _0023_003Dz5jXZjqaEuXn58IInTj0oVRdpFSDr9RqgIg_003D_003D(WriteMultiFile _0023_003DzeQXXxPAf9PYN, FileSerializer _0023_003DzPQvnoRZw23LX, List<string> _0023_003DzSTLbXssBz20Y, IViewport _0023_003DzGSpOx5G7KdbpHHwPb3vgrD8_003D, bool _0023_003Dz_f45qRs9_0024Fc_9uCJJp7qKZ4_003D, Color _0023_003Dzazl33QeoulkThzFYGktOOGk_003D, StringBuilder _0023_003DzccBsfnw_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D, CancellationToken _0023_003DzkIE5Tx8_003D)
	{
		if (!_0023_003Dz_f45qRs9_0024Fc_9uCJJp7qKZ4_003D)
		{
			return;
		}
		if (_0023_003DzSTLbXssBz20Y == null)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594576));
		}
		if (!(this is Design design))
		{
			return;
		}
		Design design2 = new Design
		{
			WaitCursorMode = waitCursorType.Never,
			ZoomFitMode = zoomFitType.Standard,
			Renderer = rendererType.Direct3D
		};
		if (_0023_003DzGSpOx5G7KdbpHHwPb3vgrD8_003D != null)
		{
			design2.Size = _0023_003DzGSpOx5G7KdbpHHwPb3vgrD8_003D.Size;
			design2.Viewports.Add((Viewport)_0023_003DzGSpOx5G7KdbpHHwPb3vgrD8_003D);
			design.UpdateViewportsSizeAndLocation();
		}
		else
		{
			design2.Size = new Size(1024, 768);
			design2.InitializeViewports();
		}
		design2.CreateControl();
		design2.CreateGraphics();
		for (int i = 0; i < _0023_003DzSTLbXssBz20Y.Count; i++)
		{
			string text = _0023_003DzSTLbXssBz20Y[i];
			if (!_0023_003DzeQXXxPAf9PYN.UpdateProgressAndCheckCancelled(i, _0023_003DzSTLbXssBz20Y.Count, _0023_003DzeQXXxPAf9PYN.UpdatingThumbnailsText, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D, Path.GetFileName(text)))
			{
				return;
			}
			if (Extensions.GetThumbnail(text) == null)
			{
				ReadMultiFile readMultiFile = new ReadMultiFile(text, _0023_003DzPQvnoRZw23LX);
				readMultiFile.DoWork();
				readMultiFile.OpenTo(design2.Document);
				design2.ZoomFit();
				UpdateThumbnail updateThumbnail = new UpdateThumbnail(text, readMultiFile.FileSerializer, design2.ActiveViewport._0023_003DzTgPYdNm9og8y(256, _0023_003Dzazl33QeoulkThzFYGktOOGk_003D.IsEmpty ? Color.White : _0023_003Dzazl33QeoulkThzFYGktOOGk_003D));
				updateThumbnail.DoWork();
				if (!string.IsNullOrEmpty(updateThumbnail.Log))
				{
					_0023_003DzccBsfnw_003D.AppendLine(updateThumbnail.Log);
				}
				design2.Clear();
			}
		}
		design2.Dispose();
	}

	private bool ShouldSerializeShortcutKeys()
	{
		return ShortcutKeys._0023_003Dz4XAvJ5aCRLKs();
	}

	internal void ResetShortcutKeys()
	{
		ShortcutKeys = new ShortcutKeysSettings();
	}

	private void _0023_003DzbreWk9EeSznj(double _0023_003Dz_0024Bbg_0024UJaSjyh, bool _0023_003DzerPaB6icXZKY, bool _0023_003DzXk3FqeMyQ5uP)
	{
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			return;
		}
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		_ = viewport.Camera;
		if (_0023_003DzerPaB6icXZKY)
		{
			viewport._0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(viewport.Size.Width / 2, viewport.Size.Height / 2);
		}
		if (viewport.Rotate.RotationMode == rotationType.Turntable)
		{
			if (_0023_003DzXk3FqeMyQ5uP)
			{
				_0023_003Dzk_0024_0024VvG_00245PP4u(0, (int)(0.0 - _0023_003Dz_0024Bbg_0024UJaSjyh), _0023_003DzBQC8k3F0wJN4: false);
			}
			else
			{
				_0023_003Dzk_0024_0024VvG_00245PP4u((int)(0.0 - _0023_003Dz_0024Bbg_0024UJaSjyh), 0, _0023_003DzBQC8k3F0wJN4: false);
			}
		}
		else
		{
			Vector3D _0023_003DzCXCsNEAoTIbu = (_0023_003DzXk3FqeMyQ5uP ? Vector3D.AxisY : Vector3D.AxisZ);
			viewport.Camera.RotateByAngle(viewport.GetViewFrame(), viewport.Rotate.RotationCenter, _0023_003DzCXCsNEAoTIbu, _0023_003Dz_0024Bbg_0024UJaSjyh, _0023_003DzGkQwE7Vh8NHe: true, _0023_003Dz8SfmelQ8rQFg: false, out var _, out var _, out var _);
		}
		AdjustNearAndFarPlanes();
		Mouse3D._0023_003DzI8QnuD_uT7AD(viewport);
		_0023_003Dz11CadYMOXmz_(_0023_003DzipBYly6zFKAp());
	}

	private void _0023_003Dzi56EWP62KDpe(int _0023_003Dz3W09xZKvMShr, bool _0023_003DzerPaB6icXZKY)
	{
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count != 0)
		{
			if (_0023_003DzerPaB6icXZKY)
			{
				_0023_003DzipBYly6zFKAp().Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
			}
			ZoomCamera(_0023_003Dz3W09xZKvMShr, animate: false);
			AdjustNearAndFarPlanes();
			if (_0023_003DzerPaB6icXZKY)
			{
				_0023_003DzipBYly6zFKAp().Camera.ZBufferData.Dirty = true;
			}
		}
	}

	private void _0023_003DzS_0024b6JBPjk6ke(System.Drawing.Point _0023_003DzdkMOZCU_003D, bool _0023_003DzerPaB6icXZKY)
	{
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count != 0)
		{
			if (_0023_003DzerPaB6icXZKY)
			{
				_0023_003DzipBYly6zFKAp().Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
			}
			PanCamera(new System.Drawing.Point(0, 0), _0023_003DzdkMOZCU_003D, animate: false);
			AdjustNearAndFarPlanes();
		}
	}

	public void ZoomIn(int amount)
	{
		_0023_003Dz_00246jtN2E_003D(amount, _0023_003DzerPaB6icXZKY: true);
	}

	public void ZoomOut(int amount)
	{
		_0023_003Dz4IJrQq0Rg3Hk(amount, _0023_003DzerPaB6icXZKY: true);
	}

	public void PanLeft(int amount)
	{
		_0023_003Dza53kDu73Wwm4(amount, _0023_003DzerPaB6icXZKY: true);
	}

	public void PanRight(int amount)
	{
		_0023_003DzNJcGQ1L9pQMi(amount, _0023_003DzerPaB6icXZKY: true);
	}

	public void PanDown(int amount)
	{
		_0023_003Dze_0024damYstWdlY(amount, _0023_003DzerPaB6icXZKY: true);
	}

	public void PanUp(int amount)
	{
		_0023_003DzhaBbOXDsMci4(amount, _0023_003DzerPaB6icXZKY: true);
	}

	internal void _0023_003DzhFM5QuysOc2a(double _0023_003Dz_0024Bbg_0024UJaSjyh, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003DzqXK12IwuBesy(0.0 - _0023_003Dz_0024Bbg_0024UJaSjyh, _0023_003DzerPaB6icXZKY);
	}

	internal void _0023_003DzqXK12IwuBesy(double _0023_003Dz_0024Bbg_0024UJaSjyh, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003DzbreWk9EeSznj(_0023_003Dz_0024Bbg_0024UJaSjyh, _0023_003DzerPaB6icXZKY, _0023_003DzXk3FqeMyQ5uP: false);
	}

	internal void _0023_003Dz_mIv_0024Fqqnit2(double _0023_003Dz_0024Bbg_0024UJaSjyh, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003DzDnP_iy6mfpH5(0.0 - _0023_003Dz_0024Bbg_0024UJaSjyh, _0023_003DzerPaB6icXZKY);
	}

	internal void _0023_003DzDnP_iy6mfpH5(double _0023_003Dz_0024Bbg_0024UJaSjyh, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003DzbreWk9EeSznj(_0023_003Dz_0024Bbg_0024UJaSjyh, _0023_003DzerPaB6icXZKY, _0023_003DzXk3FqeMyQ5uP: true);
	}

	private void _0023_003Dz_00246jtN2E_003D(int _0023_003Dz3W09xZKvMShr, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003Dzi56EWP62KDpe(_0023_003Dz3W09xZKvMShr, _0023_003DzerPaB6icXZKY);
	}

	private void _0023_003Dz4IJrQq0Rg3Hk(int _0023_003Dz3W09xZKvMShr, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003Dz_00246jtN2E_003D(-_0023_003Dz3W09xZKvMShr, _0023_003DzerPaB6icXZKY);
	}

	private void _0023_003Dza53kDu73Wwm4(int _0023_003Dz3W09xZKvMShr, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003DzNJcGQ1L9pQMi(-_0023_003Dz3W09xZKvMShr, _0023_003DzerPaB6icXZKY);
	}

	private void _0023_003DzNJcGQ1L9pQMi(int _0023_003Dz3W09xZKvMShr, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003DzS_0024b6JBPjk6ke(new System.Drawing.Point(_0023_003Dz3W09xZKvMShr, 0), _0023_003DzerPaB6icXZKY);
	}

	private void _0023_003Dze_0024damYstWdlY(int _0023_003Dz3W09xZKvMShr, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003DzS_0024b6JBPjk6ke(new System.Drawing.Point(0, _0023_003Dz3W09xZKvMShr), _0023_003DzerPaB6icXZKY);
	}

	private void _0023_003DzhaBbOXDsMci4(int _0023_003Dz3W09xZKvMShr, bool _0023_003DzerPaB6icXZKY)
	{
		_0023_003Dze_0024damYstWdlY(-_0023_003Dz3W09xZKvMShr, _0023_003DzerPaB6icXZKY);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		if (e.SuppressKeyPress || _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count <= 0)
		{
			return;
		}
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		bool flag = false;
		if (viewport.Zoom.Enabled)
		{
			_0023_003DzKv143IQ_003D _0023_003DzKv143IQ_003D2 = _0023_003DzBu78rmEesrci(e);
			if (_0023_003DzKv143IQ_003D2 != 0)
			{
				if (!_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(e.KeyCode))
				{
					viewport.Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
				}
				switch (_0023_003DzKv143IQ_003D2)
				{
				case (_0023_003DzKv143IQ_003D)1:
					_0023_003Dz_00246jtN2E_003D(viewport.Zoom.KeysStep, _0023_003DzerPaB6icXZKY: false);
					flag = true;
					break;
				case (_0023_003DzKv143IQ_003D)2:
					_0023_003Dz4IJrQq0Rg3Hk(viewport.Zoom.KeysStep, _0023_003DzerPaB6icXZKY: false);
					flag = true;
					break;
				}
			}
		}
		if (!flag && viewport.Pan.Enabled)
		{
			_0023_003DztncgnbDImno0zX_0024VBw_003D_003D _0023_003DztncgnbDImno0zX_0024VBw_003D_003D2 = _0023_003DzMwODyqUxGd2Q(e);
			if (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D2 != 0)
			{
				if (!_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(e.KeyCode))
				{
					viewport.Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
				}
				switch (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D2)
				{
				case (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)3:
					_0023_003Dza53kDu73Wwm4(viewport.Pan.KeysStep, _0023_003DzerPaB6icXZKY: false);
					flag = true;
					break;
				case (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)4:
					_0023_003DzNJcGQ1L9pQMi(viewport.Pan.KeysStep, _0023_003DzerPaB6icXZKY: false);
					flag = true;
					break;
				case (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)1:
					_0023_003DzhaBbOXDsMci4(viewport.Pan.KeysStep, _0023_003DzerPaB6icXZKY: false);
					flag = true;
					break;
				case (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)2:
					_0023_003Dze_0024damYstWdlY(viewport.Pan.KeysStep, _0023_003DzerPaB6icXZKY: false);
					flag = true;
					break;
				}
			}
		}
		if (!flag && viewport.Rotate.Enabled)
		{
			_0023_003DztncgnbDImno0zX_0024VBw_003D_003D _0023_003DztncgnbDImno0zX_0024VBw_003D_003D3 = _0023_003Dzz9GX4HlUQlvR(e);
			if (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D3 != 0)
			{
				if (!_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(e.KeyCode) || !_0023_003DzSpehFdn_0024OOBr2rJb7A_003D_003D)
				{
					viewport._0023_003Dz2u7h_EfdEOzqD_AXyw_003D_003D(viewport.Size.Width / 2, viewport.Size.Height / 2);
				}
				_0023_003DzSpehFdn_0024OOBr2rJb7A_003D_003D = true;
			}
			switch (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D3)
			{
			case (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)3:
				_0023_003DzhFM5QuysOc2a(viewport.Rotate.KeysStep, _0023_003DzerPaB6icXZKY: false);
				flag = true;
				break;
			case (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)4:
				_0023_003DzqXK12IwuBesy(viewport.Rotate.KeysStep, _0023_003DzerPaB6icXZKY: false);
				flag = true;
				break;
			case (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)1:
				_0023_003Dz_mIv_0024Fqqnit2(viewport.Rotate.KeysStep, _0023_003DzerPaB6icXZKY: false);
				flag = true;
				break;
			case (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)2:
				_0023_003DzDnP_iy6mfpH5(viewport.Rotate.KeysStep, _0023_003DzerPaB6icXZKY: false);
				flag = true;
				break;
			}
		}
		else
		{
			_0023_003DzSpehFdn_0024OOBr2rJb7A_003D_003D = false;
		}
		_0023_003DzY7PoD1c_003D._0023_003DzGFXEo09621gi(e.KeyCode, e.Modifiers);
		if (!flag && _0023_003Dz82TZuxZWbG3Z(e.KeyCode) && _0023_003Dz_0024tXP7SA143kl == null)
		{
			viewport._0023_003Dz3w_00240eHwLabq0(this, _0023_003DzY7PoD1c_003D, _0023_003DzxIgINtc_003D, 1.0);
			flag = true;
			_0023_003Dz0h9vskpSVtRx = true;
		}
		if (e.KeyData == ShortcutKeys.UngroupSelection)
		{
			foreach (Entity entity in Entities)
			{
				if (entity.Selected && entity.GroupIndex != -1)
				{
					CurrentBlock.Ungroup(entity.GroupIndex);
					break;
				}
			}
			_0023_003DzQtM_y9yLRR_0024E();
			flag = false;
			e.Handled = true;
		}
		else if (e.KeyData == ShortcutKeys.SelectAll)
		{
			Entities.SelectAll();
			_0023_003DzQtM_y9yLRR_0024E();
			flag = false;
			e.Handled = true;
		}
		else if (e.KeyData == ShortcutKeys.InvertSelection)
		{
			Entities.InvertSelection();
			_0023_003DzQtM_y9yLRR_0024E();
			flag = false;
			e.Handled = true;
		}
		else if (e.KeyData == ShortcutKeys.ZoomFit)
		{
			ZoomFit();
			_0023_003DzQtM_y9yLRR_0024E();
			flag = false;
			e.Handled = true;
		}
		else if (e.KeyData == ShortcutKeys.CutSelection)
		{
			Entities.CutSelection();
			_0023_003DzQtM_y9yLRR_0024E();
			flag = false;
			e.Handled = true;
		}
		else if (e.KeyData == ShortcutKeys.CopySelection)
		{
			if (_0023_003Dz8Q16RtM94O0K())
			{
				AssemblyName name = Assembly.GetAssembly(typeof(Workspace)).GetName();
				try
				{
					Clipboard.SetText(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594631) + name.Version?.ToString() + Environment.NewLine + _0023_003Dzuxh58hoEevp2);
				}
				catch (Exception)
				{
				}
			}
			else
			{
				Entities.CopySelection();
				e.Handled = true;
			}
		}
		else if (e.KeyData == ShortcutKeys.PasteSelection)
		{
			Entities.Paste();
			_0023_003DzQtM_y9yLRR_0024E();
			flag = false;
			e.Handled = true;
		}
		else if (e.KeyData == ShortcutKeys.GroupSelection)
		{
			CurrentBlock.GroupSelection();
			_0023_003DzQtM_y9yLRR_0024E();
			flag = false;
			e.Handled = true;
		}
		else if (e.KeyData == ShortcutKeys.DeleteSelection)
		{
			Entities.DeleteSelected();
			_0023_003DzQtM_y9yLRR_0024E();
			flag = false;
			e.Handled = true;
		}
		else if (e.KeyData == ShortcutKeys.CancelBackgroundWork)
		{
			CancelWork();
			e.Handled = true;
		}
		else if (_0023_003Dz82TZuxZWbG3Z(e.KeyCode))
		{
			_0023_003DzjZJHOfmCYJDm();
		}
		if (flag)
		{
			_0023_003DzipBYly6zFKAp().SavedViews.Save();
			Invalidate();
		}
	}

	private bool _0023_003Dz82TZuxZWbG3Z(Keys _0023_003DzchTpoW0_003D)
	{
		if (_0023_003DzipBYly6zFKAp().Navigation.Mode != Camera.navigationType.Examine)
		{
			if (_0023_003DzchTpoW0_003D != ShortcutKeys.NavigationBackward && _0023_003DzchTpoW0_003D != ShortcutKeys.NavigationDown && _0023_003DzchTpoW0_003D != ShortcutKeys.NavigationUp && _0023_003DzchTpoW0_003D != ShortcutKeys.NavigationForward && _0023_003DzchTpoW0_003D != ShortcutKeys.NavigationLeft)
			{
				return _0023_003DzchTpoW0_003D == ShortcutKeys.NavigationRight;
			}
			return true;
		}
		return false;
	}

	private _0023_003DztncgnbDImno0zX_0024VBw_003D_003D _0023_003Dzz9GX4HlUQlvR(KeyEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DztncgnbDImno0zX_0024VBw_003D_003D result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)0;
		if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.RotateUp)
		{
			result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)1;
		}
		else if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.RotateDown)
		{
			result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)2;
		}
		else if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.RotateRight)
		{
			result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)4;
		}
		else if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.RotateLeft)
		{
			result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)3;
		}
		return result;
	}

	private _0023_003DzKv143IQ_003D _0023_003DzBu78rmEesrci(KeyEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzKv143IQ_003D result = (_0023_003DzKv143IQ_003D)0;
		if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.ZoomIn)
		{
			result = (_0023_003DzKv143IQ_003D)1;
		}
		else if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.ZoomOut)
		{
			result = (_0023_003DzKv143IQ_003D)2;
		}
		return result;
	}

	private _0023_003DztncgnbDImno0zX_0024VBw_003D_003D _0023_003DzMwODyqUxGd2Q(KeyEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DztncgnbDImno0zX_0024VBw_003D_003D result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)0;
		if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.PanUp)
		{
			result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)1;
		}
		else if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.PanDown)
		{
			result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)2;
		}
		else if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.PanRight)
		{
			result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)4;
		}
		else if (_0023_003Dz1SmHC4c_003D.KeyData == ShortcutKeys.PanLeft)
		{
			result = (_0023_003DztncgnbDImno0zX_0024VBw_003D_003D)3;
		}
		return result;
	}

	protected override bool IsInputKey(Keys keyData)
	{
		switch (keyData)
		{
		case Keys.Tab | Keys.Shift:
		{
			if (_0023_003DzBn2ByFKdwrou == 0)
			{
				return true;
			}
			for (int num = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count - 1; num > 0; num--)
			{
				if (_0023_003DzBn2ByFKdwrou == num)
				{
					_0023_003DzBn2ByFKdwrou = num - 1;
					Invalidate();
					return true;
				}
			}
			break;
		}
		case Keys.Tab:
		{
			if (_0023_003DzBn2ByFKdwrou == _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count - 1)
			{
				return true;
			}
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count - 1; i++)
			{
				if (_0023_003DzBn2ByFKdwrou == i)
				{
					_0023_003DzBn2ByFKdwrou = i + 1;
					Invalidate();
					return true;
				}
			}
			break;
		}
		}
		if (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(modifierKeys.Ctrl))
		{
			if (_0023_003DzipBYly6zFKAp().Zoom.Enabled && (keyData == ShortcutKeys.ZoomIn || keyData == ShortcutKeys.ZoomOut))
			{
				return true;
			}
			if (_0023_003DzipBYly6zFKAp().Pan.Enabled && (keyData == ShortcutKeys.PanUp || keyData == ShortcutKeys.PanDown || keyData == ShortcutKeys.PanLeft || keyData == ShortcutKeys.PanRight))
			{
				return true;
			}
		}
		else if (_0023_003DzipBYly6zFKAp().Rotate.Enabled && (keyData == ShortcutKeys.RotateUp || keyData == ShortcutKeys.RotateDown || keyData == ShortcutKeys.RotateLeft || keyData == ShortcutKeys.RotateRight))
		{
			return true;
		}
		return false;
	}

	protected override void OnKeyUp(KeyEventArgs e)
	{
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count != 0)
		{
			if (e.KeyData == ShortcutKeys.RotateUp || e.KeyData == ShortcutKeys.RotateDown || e.KeyData == ShortcutKeys.RotateLeft || e.KeyData == ShortcutKeys.RotateRight)
			{
				_0023_003DzSpehFdn_0024OOBr2rJb7A_003D_003D = false;
			}
			_0023_003DzY7PoD1c_003D._0023_003DzFPaftSc0Gyt2(e.KeyCode, e.Modifiers);
			base.OnKeyUp(e);
		}
	}

	private void _0023_003DzjZJHOfmCYJDm()
	{
		if (_0023_003Dz_0024tXP7SA143kl != null)
		{
			return;
		}
		_0023_003Dz_0024tXP7SA143kl = new System.Threading.Timer(delegate(object _0023_003DzxwGby4M_003D)
		{
			_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D _0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2 = new _0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D();
			_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003DzKdgtcDsi34jL = this;
			_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003DzxwGby4M_003D = _0023_003DzxwGby4M_003D;
			_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003Dz7Xo5EoA_003D = _0023_003DzipBYly6zFKAp();
			if (_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003Dz7Xo5EoA_003D._0023_003DzF3n3vDE_003D.LengthSquared > 0.0)
			{
				if (base.InvokeRequired)
				{
					BeginInvoke(new MethodInvoker(_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003DzITwgkvIIkgIArD6RAITc0JM_003D));
				}
				else
				{
					_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003Dz7Xo5EoA_003D._0023_003Dz3w_00240eHwLabq0(this, _0023_003DzY7PoD1c_003D, _0023_003DzxIgINtc_003D, 1.0);
					_0023_003DzH_ACO1keHrO4();
					_0023_003DzFBmlAVlkXQOb?.Invoke(_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003DzxwGby4M_003D, EventArgs.Empty);
				}
			}
			else
			{
				_0023_003Dz_0024tXP7SA143kl.Dispose();
				_0023_003Dz_0024tXP7SA143kl = null;
				_0023_003Dz0h9vskpSVtRx = false;
			}
		}, null, 0, 10);
	}

	private void _0023_003Dz3G_0024nZtxnOc_0024r(object _0023_003DzxwGby4M_003D)
	{
		_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D _0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2 = new _0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D();
		_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003DzKdgtcDsi34jL = this;
		_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003DzxwGby4M_003D = _0023_003DzxwGby4M_003D;
		_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003Dz7Xo5EoA_003D = _0023_003DzipBYly6zFKAp();
		if (_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003Dz7Xo5EoA_003D._0023_003DzF3n3vDE_003D.LengthSquared > 0.0)
		{
			if (base.InvokeRequired)
			{
				BeginInvoke(new MethodInvoker(_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003DzITwgkvIIkgIArD6RAITc0JM_003D));
				return;
			}
			_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003Dz7Xo5EoA_003D._0023_003Dz3w_00240eHwLabq0(this, _0023_003DzY7PoD1c_003D, _0023_003DzxIgINtc_003D, 1.0);
			_0023_003DzH_ACO1keHrO4();
			_0023_003DzFBmlAVlkXQOb?.Invoke(_0023_003Dz8w51GroKtiOofmkIYk9WU5I_003D2._0023_003DzxwGby4M_003D, EventArgs.Empty);
		}
		else
		{
			_0023_003Dz_0024tXP7SA143kl.Dispose();
			_0023_003Dz_0024tXP7SA143kl = null;
			_0023_003Dz0h9vskpSVtRx = false;
		}
	}

	internal static void _0023_003DzbksQw_5VXML8(MouseButton _0023_003DzkGobcLg_003D)
	{
		if (_0023_003DzkGobcLg_003D.Button == mouseButtonsZPR.Left && _0023_003DzkGobcLg_003D.ModifierKey == modifierKeys.None)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594648));
		}
	}

	private bool ShouldSerializePickBoxSize()
	{
		return _0023_003DzjWLowQN0uWZO != 8;
	}

	private void ResetPickBoxSize()
	{
		_0023_003DzjWLowQN0uWZO = 8;
	}

	internal void _0023_003DzKrDqx6j0jLR2()
	{
		_0023_003DzvxT4VQo_003D(ref _0023_003DzMANLSxJk4AWs);
		using (Stream stream = _0023_003DzUyKAKuK2rf1X())
		{
			_0023_003DzMANLSxJk4AWs = new Cursor(stream);
		}
		_0023_003DzXRSUSe_0024_8gct(cursorType.Pick, _0023_003DzMANLSxJk4AWs, _0023_003Dzr5eQXr8_003D: true);
		if (IsSelectByPickAction())
		{
			SetCursor(_0023_003DzMANLSxJk4AWs);
		}
	}

	internal void _0023_003Dzm3mTJqFjb_5X()
	{
		_0023_003DztPc8ORzyA8N7();
		CursorTypes.Add(cursorType.Default, _0023_003Dz2F9_0024pE8Z_0024_002426);
		CursorTypes.Add(cursorType.ZoomWindow, _0023_003DzByXVr0E_0024Xvje);
		CursorTypes.Add(cursorType.Zoom, _0023_003DzCRjLB8xmFyn8);
		CursorTypes.Add(cursorType.Pan, _0023_003DzPK2U1X_CaUvq);
		CursorTypes.Add(cursorType.Rotate, _0023_003DzOuCsi3Nw7q_0024xhQQx0A_003D_003D);
		CursorTypes.Add(cursorType.Pick, _0023_003DzMANLSxJk4AWs);
		CursorTypes.Add(cursorType.Cross, Cursors.Cross);
		CursorTypes.Add(cursorType.Arrow, Cursors.Arrow);
		CursorTypes.Add(cursorType.Hand, Cursors.Hand);
		CursorTypes.Add(cursorType.Help, Cursors.Help);
		CursorTypes.Add(cursorType.IBeam, Cursors.IBeam);
		CursorTypes.Add(cursorType.No, Cursors.No);
		CursorTypes.Add(cursorType.UpArrow, Cursors.UpArrow);
		CursorTypes.Add(cursorType.AppStarting, Cursors.AppStarting);
		CursorTypes.Add(cursorType.SizeAll, Cursors.SizeAll);
		CursorTypes.Add(cursorType.SizeNESW, Cursors.SizeNESW);
		CursorTypes.Add(cursorType.SizeNS, Cursors.SizeNS);
		CursorTypes.Add(cursorType.SizeNWSE, Cursors.SizeNWSE);
		CursorTypes.Add(cursorType.SizeWE, Cursors.SizeWE);
		CursorTypes.Add(cursorType.Wait, Cursors.WaitCursor);
		CursorTypes.Add(cursorType.PanEast, Cursors.PanEast);
		CursorTypes.Add(cursorType.PanNE, Cursors.PanNE);
		CursorTypes.Add(cursorType.PanNorth, Cursors.PanNorth);
		CursorTypes.Add(cursorType.PanNW, Cursors.PanNW);
		CursorTypes.Add(cursorType.PanSE, Cursors.PanSE);
		CursorTypes.Add(cursorType.PanSouth, Cursors.PanSouth);
		CursorTypes.Add(cursorType.PanSW, Cursors.PanSW);
		CursorTypes.Add(cursorType.PanWest, Cursors.PanWest);
	}

	internal void _0023_003DztPc8ORzyA8N7()
	{
		CursorTypes = new Dictionary<cursorType, Cursor>();
	}

	internal void _0023_003DzXRSUSe_0024_8gct(cursorType _0023_003DzlIUAx2s_003D, Cursor _0023_003DzlwNtVtI_003D, bool _0023_003Dzr5eQXr8_003D)
	{
		Cursor _0023_003DzlwNtVtI_003D2 = _0023_003Dz_wO_DqEVI_38(_0023_003DzlIUAx2s_003D) as Cursor;
		if ((object)_0023_003DzlwNtVtI_003D != _0023_003DzlwNtVtI_003D2)
		{
			CursorTypes[_0023_003DzlIUAx2s_003D] = _0023_003DzlwNtVtI_003D;
			if (_0023_003Dzr5eQXr8_003D)
			{
				_0023_003DzvxT4VQo_003D(ref _0023_003DzlwNtVtI_003D2);
			}
		}
	}

	internal void _0023_003Dz7_0024YkdBF6ZGdCGfAnKQ_003D_003D(cursorType _0023_003DzlIUAx2s_003D, Cursor _0023_003DzlwNtVtI_003D)
	{
		if (!CursorTypes.ContainsKey(_0023_003DzlIUAx2s_003D) || CursorTypes[_0023_003DzlIUAx2s_003D] == null)
		{
			_0023_003DzXRSUSe_0024_8gct(_0023_003DzlIUAx2s_003D, _0023_003DzlwNtVtI_003D, _0023_003Dzr5eQXr8_003D: true);
		}
	}

	internal object _0023_003Dz_wO_DqEVI_38(cursorType _0023_003DzlIUAx2s_003D)
	{
		if (CursorTypes.TryGetValue(_0023_003DzlIUAx2s_003D, out var value))
		{
			return value;
		}
		return _0023_003Dz2F9_0024pE8Z_0024_002426;
	}

	internal CursorContainer _0023_003DzFqaEE7IhVORj(cursorType _0023_003DzlIUAx2s_003D)
	{
		CursorContainer result = _0023_003DzzT36TNE_003D();
		if (CursorTypes != null)
		{
			Cursor = (Cursor)_0023_003Dz_wO_DqEVI_38(_0023_003DzlIUAx2s_003D);
		}
		return result;
	}

	internal void _0023_003DzXRmPWIn6oGDi()
	{
		_0023_003DzgQM_G8SJDLUO++;
	}

	internal void _0023_003DzzznZbBezl6L_()
	{
		if (_0023_003DzgQM_G8SJDLUO > 0)
		{
			_0023_003DzgQM_G8SJDLUO--;
		}
	}

	internal bool _0023_003Dz86gBZCqRMtpL()
	{
		return _0023_003DzgQM_G8SJDLUO > 0;
	}

	private static void _0023_003DzXvkGANJxfCjf(actionType _0023_003DzsLHxXyo_003D, Workspace _0023_003DzopDrLGk_003D)
	{
		if (_0023_003DzopDrLGk_003D._0023_003Dz86gBZCqRMtpL())
		{
			_0023_003DzopDrLGk_003D._0023_003DzjGvm17_0024DzsnS = _0023_003DzsLHxXyo_003D;
			return;
		}
		_0023_003DzopDrLGk_003D._0023_003Dz8jvVhZY_003D = _0023_003DzopDrLGk_003D._0023_003DzjGvm17_0024DzsnS;
		_0023_003DzopDrLGk_003D._0023_003DzjGvm17_0024DzsnS = _0023_003DzsLHxXyo_003D;
		if (_0023_003DzopDrLGk_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count != 0)
		{
			_0023_003DzopDrLGk_003D._0023_003DzipBYly6zFKAp()._0023_003Dz_0024J0MwzgL89fc(_0023_003DzopDrLGk_003D._0023_003DzjGvm17_0024DzsnS != actionType.None);
			_0023_003DzopDrLGk_003D.SetCursor(_0023_003DzopDrLGk_003D.GetDefaultCursor());
			if (_0023_003DzopDrLGk_003D._0023_003DzukN4kknF0ob8(_0023_003DzsLHxXyo_003D) && _0023_003DzopDrLGk_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D != null && _0023_003DzopDrLGk_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D._0023_003DzF3HKD2trntQC())
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594500));
			}
			_0023_003DzMXttuYzV1wNmoUI94A_003D_003D(_0023_003DzopDrLGk_003D);
			_0023_003DzopDrLGk_003D._0023_003DzqzV4JCDjt4vR();
			if (_0023_003DzopDrLGk_003D._0023_003Dz8jvVhZY_003D != _0023_003DzopDrLGk_003D._0023_003DzjGvm17_0024DzsnS && !_0023_003DzopDrLGk_003D._0023_003DzceJZi0o_003D)
			{
				_0023_003DzopDrLGk_003D._0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzxEpSi5o_003D();
			}
		}
	}

	internal static void _0023_003DzMXttuYzV1wNmoUI94A_003D_003D(Workspace _0023_003DzopDrLGk_003D)
	{
		Type type = _0023_003DzopDrLGk_003D._0023_003DzjGvm17_0024DzsnS switch
		{
			actionType.Zoom => typeof(ZoomToolBarButton), 
			actionType.Pan => typeof(PanToolBarButton), 
			actionType.Rotate => typeof(RotateToolBarButton), 
			actionType.ZoomWindow => typeof(ZoomWindowToolBarButton), 
			actionType.MagnifyingGlass => typeof(MagnifyingGlassToolBarButton), 
			_ => null, 
		};
		ToolBar[] toolBars = _0023_003DzopDrLGk_003D._0023_003DzipBYly6zFKAp().ToolBars;
		foreach (ToolBar toolBar in toolBars)
		{
			if (toolBar == null || !toolBar.Visible)
			{
				continue;
			}
			ToolBarButtonList buttons = toolBar.Buttons;
			if (!_0023_003DzopDrLGk_003D._0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D && buttons != null)
			{
				for (int j = 0; j < buttons.Count; j++)
				{
					ToolBarButton toolBarButton = buttons[j];
					if (toolBarButton.IsDefaultButton())
					{
						toolBarButton._0023_003DzQLjVxM8_003D();
					}
				}
			}
			ToolBarButton toolBarButton2 = null;
			if (!(type != null))
			{
				continue;
			}
			for (int k = 0; k < buttons.Count; k++)
			{
				if (buttons[k].GetType() == type)
				{
					toolBarButton2 = buttons[k];
					break;
				}
			}
			if (toolBarButton2 != null)
			{
				toolBarButton2._0023_003DzqJuYHyY_003D();
			}
		}
		if (!_0023_003DzopDrLGk_003D._0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D)
		{
			_0023_003DzopDrLGk_003D._0023_003DzFqaEE7IhVORj(_0023_003DzopDrLGk_003D._0023_003DzSeMqxa6Bcvxs());
		}
	}

	internal void _0023_003Dz2_dex5RlnxWY(Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		if (_0023_003Dzbq3BJR0_003D != null)
		{
			IEnumerable<BlockReference> enumerable = _0023_003Dzbq3BJR0_003D.Reverse();
			IList<Entity> entities = Entities;
			foreach (BlockReference item in enumerable)
			{
				if (!entities.Contains(item))
				{
					throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595840));
				}
				entities = Blocks[item.BlockName].Entities;
			}
		}
		_0023_003Dzkm9D6jYtZW1j = _0023_003Dzbq3BJR0_003D;
		UpdateVisibleSelection();
	}

	private void _0023_003DzZqeDo9pUqALBMFSt2w_003D_003D(selectionFilterType _0023_003DzTJU1MAGBvuhO)
	{
		bool flag = true;
		switch (_0023_003DzTJU1MAGBvuhO)
		{
		case selectionFilterType.Entity:
		case selectionFilterType.Vertex:
		case selectionFilterType.Edge:
		case selectionFilterType.Vertex | selectionFilterType.Edge:
		case selectionFilterType.Face:
		case selectionFilterType.Vertex | selectionFilterType.Face:
		case selectionFilterType.Edge | selectionFilterType.Face:
		case selectionFilterType.Vertex | selectionFilterType.Edge | selectionFilterType.Face:
		case selectionFilterType.SubCurve:
		case selectionFilterType.Contour:
		case selectionFilterType.SketchPoint:
		case selectionFilterType.SketchCurve:
		case selectionFilterType.SketchPoint | selectionFilterType.SketchCurve:
			flag = false;
			break;
		}
		if (!flag)
		{
			return;
		}
		selectionFilterType[] obj = (selectionFilterType[])Enum.GetValues(typeof(selectionFilterType));
		StringBuilder stringBuilder = new StringBuilder(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595898));
		string arg = string.Empty;
		selectionFilterType[] array = obj;
		foreach (selectionFilterType selectionFilterType2 in array)
		{
			if ((_0023_003DzTJU1MAGBvuhO & selectionFilterType2) != 0)
			{
				stringBuilder.Append(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595935), arg, selectionFilterType2));
				arg = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621248);
			}
		}
		throw new EyeshotException(stringBuilder.ToString());
	}

	private bool _0023_003Dz4xY7BXVU46SkGzfQtg_003D_003D()
	{
		return _0023_003DzmI92LKJxZvwJMfDbVw_003D_003D(_0023_003Dzf4r6oggNIe3m(_0023_003Dz28QCun7pbbWH));
	}

	private bool _0023_003DzmI92LKJxZvwJMfDbVw_003D_003D(_0023_003DzhFBmu_0024RpnRJ7 _0023_003DzAQ07IeY_003D)
	{
		if ((_0023_003DzAQ07IeY_003D ^ (_0023_003DzhFBmu_0024RpnRJ7)4) != 0 && (_0023_003DzAQ07IeY_003D & (_0023_003DzhFBmu_0024RpnRJ7)4) != 0)
		{
			return true;
		}
		if ((_0023_003DzAQ07IeY_003D ^ (_0023_003DzhFBmu_0024RpnRJ7)2) != 0 && (_0023_003DzAQ07IeY_003D & (_0023_003DzhFBmu_0024RpnRJ7)2) != 0)
		{
			return true;
		}
		return false;
	}

	private void _0023_003DzOOXPlJN4n8PM2s1qJQ_003D_003D(IList<Entity> _0023_003DzQDU9c0AE6yqQ, _0023_003DzaqIrcbaWtirayop6jUfDEwY_003D _0023_003DzvVrsSP3cRyTN6khgoBHtLeA_003D)
	{
		foreach (Entity item in _0023_003DzQDU9c0AE6yqQ)
		{
			_0023_003DzvVrsSP3cRyTN6khgoBHtLeA_003D(item);
			item.Selected = false;
		}
	}

	private void _0023_003Dz0_czIjY3d3YXM7nQVA_003D_003D(IList<Entity> _0023_003DzQDU9c0AE6yqQ)
	{
		foreach (Entity item in _0023_003DzQDU9c0AE6yqQ)
		{
			item.Selected = false;
		}
	}

	private void _0023_003Dz0uUl8FiJh4Xc0AjWsArN2Yw_003D(IList<Entity> _0023_003DzQDU9c0AE6yqQ)
	{
		foreach (Entity item in _0023_003DzQDU9c0AE6yqQ)
		{
			item.ClearSelectionFaces(selectionStatusType.Permanent);
			item.Selected = false;
		}
	}

	private void _0023_003DzFDljQIYftpvseZPb3g_003D_003D(IList<Entity> _0023_003DzQDU9c0AE6yqQ)
	{
		foreach (Entity item in _0023_003DzQDU9c0AE6yqQ)
		{
			if (item is Brep)
			{
				((Brep)item).ClearEdgesSelection(selectionStatusType.Permanent);
				item.Selected = false;
			}
		}
	}

	private void _0023_003DzyqHqGuOKMBaDEeML0ppaX3qGzt2F(IList<Entity> _0023_003DzQDU9c0AE6yqQ)
	{
		foreach (Entity item in _0023_003DzQDU9c0AE6yqQ)
		{
			if (item is Brep)
			{
				((Brep)item).ClearVerticesSelection(selectionStatusType.Permanent);
				item.Selected = false;
			}
		}
	}

	private void _0023_003DzqzV4JCDjt4vR()
	{
		switch (_0023_003DzjGvm17_0024DzsnS)
		{
		case actionType.None:
		case actionType.Zoom:
		case actionType.Pan:
		case actionType.Rotate:
		case actionType.SelectByPick:
		case actionType.SelectVisibleByPick:
			_0023_003DzejbXyveNnCjc();
			break;
		case actionType.ZoomWindow:
		case actionType.MagnifyingGlass:
		case actionType.SelectByBox:
		case actionType.SelectByPolygon:
			break;
		}
	}

	private void _0023_003DzejbXyveNnCjc()
	{
		if (_0023_003Dzz2f3UQo_003D)
		{
			_0023_003Dzz2f3UQo_003D = false;
			_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzxEpSi5o_003D();
			if (_0023_003DzmNZD0Zs_003D != null)
			{
				PaintBackBuffer();
				SwapBuffers();
			}
		}
	}

	internal cursorType _0023_003DzSeMqxa6Bcvxs()
	{
		switch (_0023_003DzjGvm17_0024DzsnS)
		{
		case actionType.Zoom:
			return cursorType.Zoom;
		case actionType.Pan:
			return cursorType.Pan;
		case actionType.Rotate:
			return cursorType.Rotate;
		case actionType.SelectByPick:
		case actionType.SelectVisibleByPick:
		case actionType.SelectVisibleByPickDynamic:
		case actionType.SelectVisibleByPickLabel:
			if (_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003DzF3HKD2trntQC())
			{
				return cursorType.Default;
			}
			return cursorType.Pick;
		case actionType.ZoomWindow:
			return cursorType.ZoomWindow;
		case actionType.SelectByBox:
		case actionType.SelectByPolygon:
		case actionType.SelectVisibleByBox:
		case actionType.SelectVisibleByPolygon:
		case actionType.SelectByBoxEnclosed:
		case actionType.SelectByPolygonEnclosed:
			if (_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003DzF3HKD2trntQC())
			{
				return cursorType.Default;
			}
			return cursorType.Cross;
		default:
			return cursorType.Default;
		}
	}

	internal bool _0023_003DzukN4kknF0ob8(actionType _0023_003DzmrtMJ48_003D)
	{
		if (!IsSelectByPickAction() && !IsSelectByBoxAction())
		{
			return IsSelectByPolygonAction();
		}
		return true;
	}

	internal object _0023_003DzYUOgNSstb_PE()
	{
		return _0023_003Dz2F9_0024pE8Z_0024_002426;
	}

	internal void _0023_003DzV0Su6Jg_003D(CursorContainer _0023_003DzlwNtVtI_003D)
	{
		SetCursor(_0023_003DzlwNtVtI_003D.Cursor);
	}

	internal void _0023_003DzV0Su6Jg_003D(cursorType _0023_003DzkNj2PYs_003D, Cursor _0023_003DzlwNtVtI_003D)
	{
		CursorTypes[_0023_003DzkNj2PYs_003D] = _0023_003DzlwNtVtI_003D;
	}

	public void SetCursor(Cursor cursor)
	{
		Cursor = cursor;
	}

	internal CursorContainer _0023_003DzzT36TNE_003D()
	{
		return new CursorContainer(Cursor);
	}

	public void SetDefaultCursor(Cursor cursor)
	{
		_0023_003Dz2F9_0024pE8Z_0024_002426 = cursor;
		_0023_003DzXRSUSe_0024_8gct(cursorType.Default, _0023_003Dz2F9_0024pE8Z_0024_002426, _0023_003Dzr5eQXr8_003D: false);
		if (ActionMode == actionType.None)
		{
			Cursor = _0023_003Dz2F9_0024pE8Z_0024_002426;
		}
	}

	public Cursor GetDefaultCursor()
	{
		return _0023_003DzYUOgNSstb_PE() as Cursor;
	}

	internal override Stream _0023_003DzUyKAKuK2rf1X()
	{
		int num = 32;
		bool[,] array = new bool[32, num];
		bool[,] array2 = new bool[32, num];
		int pickBoxSize = PickBoxSize;
		for (int i = 0; i < array.GetUpperBound(1) + 1; i++)
		{
			for (int j = 0; j < array.GetUpperBound(0) + 1; j++)
			{
				array[j, i] = (j == 1 && i > 0 && i < pickBoxSize - 1) || (i == 1 && j > 0 && j < pickBoxSize - 1) || (j == pickBoxSize - 2 && i > 0 && i < pickBoxSize - 1) || (i == pickBoxSize - 2 && j > 0 && j < pickBoxSize - 1);
				array2[j, i] = (j > 1 || i >= pickBoxSize) && (i > 1 || j >= pickBoxSize) && (j != pickBoxSize - 2 || i >= pickBoxSize) && (i != pickBoxSize - 2 || j >= pickBoxSize) && (j != pickBoxSize - 1 || i >= pickBoxSize) && (i != pickBoxSize - 1 || j >= pickBoxSize);
			}
		}
		return _0023_003DznVOAnWkMIO8A(array, array2);
	}

	private MemoryStream _0023_003DznVOAnWkMIO8A(bool[,] _0023_003DzCqzM3F6JILWi, bool[,] _0023_003DzDNSKepCHF8yA)
	{
		int _0023_003DzwBouG0w_003D = _0023_003DzCqzM3F6JILWi.GetUpperBound(0) + 1;
		int num = _0023_003DzCqzM3F6JILWi.GetUpperBound(1) + 1;
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write((ushort)0);
		binaryWriter.Write((ushort)2);
		binaryWriter.Write((ushort)1);
		_0023_003Dz8huJzXc_HhmJ(binaryWriter, _0023_003DzwBouG0w_003D, num);
		_0023_003DzRuwHzMsuk0aW(binaryWriter, _0023_003DzwBouG0w_003D, num * 2);
		_0023_003DzzJN5GIfaPNn9(binaryWriter, _0023_003DzCqzM3F6JILWi);
		_0023_003DzzJN5GIfaPNn9(binaryWriter, _0023_003DzDNSKepCHF8yA);
		binaryWriter.Flush();
		memoryStream.Position = 0L;
		return memoryStream;
	}

	private void _0023_003Dz8huJzXc_HhmJ(BinaryWriter _0023_003DzmZ9SULg_003D, int _0023_003DzwBouG0w_003D, int _0023_003DzQizPEX8_003D)
	{
		_0023_003DzmZ9SULg_003D.Write((byte)(_0023_003DzwBouG0w_003D % 256));
		_0023_003DzmZ9SULg_003D.Write((byte)(_0023_003DzQizPEX8_003D % 256));
		_0023_003DzmZ9SULg_003D.Write((byte)2);
		_0023_003DzmZ9SULg_003D.Write((byte)0);
		_0023_003DzmZ9SULg_003D.Write((ushort)(PickBoxSize / 2));
		_0023_003DzmZ9SULg_003D.Write((ushort)(PickBoxSize / 2));
		_0023_003DzmZ9SULg_003D.Write((uint)(48 + _0023_003DzIM55J1cBc4EGs1x0oQ_003D_003D(_0023_003DzwBouG0w_003D, 32) * 4 * _0023_003DzQizPEX8_003D * 2));
		_0023_003DzmZ9SULg_003D.Flush();
		_0023_003DzmZ9SULg_003D.Write((uint)((int)_0023_003DzmZ9SULg_003D.BaseStream.Position + 4));
	}

	private void _0023_003DzRuwHzMsuk0aW(BinaryWriter _0023_003DzmZ9SULg_003D, int _0023_003DzwBouG0w_003D, int _0023_003DzQizPEX8_003D)
	{
		_0023_003DzmZ9SULg_003D.Write(40u);
		_0023_003DzmZ9SULg_003D.Write(_0023_003DzwBouG0w_003D);
		_0023_003DzmZ9SULg_003D.Write(_0023_003DzQizPEX8_003D);
		_0023_003DzmZ9SULg_003D.Write((short)1);
		_0023_003DzmZ9SULg_003D.Write((short)1);
		_0023_003DzmZ9SULg_003D.Write(0u);
		_0023_003DzmZ9SULg_003D.Write((uint)(_0023_003DzIM55J1cBc4EGs1x0oQ_003D_003D(_0023_003DzwBouG0w_003D, 32) * 4 * _0023_003DzQizPEX8_003D));
		_0023_003DzmZ9SULg_003D.Write(0);
		_0023_003DzmZ9SULg_003D.Write(0);
		_0023_003DzmZ9SULg_003D.Write(2u);
		_0023_003DzmZ9SULg_003D.Write(0u);
		_0023_003DzmZ9SULg_003D.Write(0u);
		_0023_003DzmZ9SULg_003D.Write(16777215u);
	}

	private void _0023_003DzzJN5GIfaPNn9(BinaryWriter _0023_003DzmZ9SULg_003D, bool[,] _0023_003Dzt5jpbHs_003D)
	{
		int num = _0023_003Dzt5jpbHs_003D.GetUpperBound(0) + 1;
		int num2 = _0023_003Dzt5jpbHs_003D.GetUpperBound(1) + 1;
		uint num3 = 0u;
		int num4 = 31;
		for (int num5 = num2 - 1; num5 >= 0; num5--)
		{
			for (int i = 0; i < num; i++)
			{
				num3 |= (_0023_003Dzt5jpbHs_003D[i, num5] ? 1u : 0u) << num4--;
				if (num4 < 0)
				{
					_0023_003DzmZ9SULg_003D.Write(_0023_003Dzqy9wa5_lpzkG(num3));
					num3 = 0u;
					num4 = 31;
				}
			}
			if (num4 != 31)
			{
				_0023_003DzmZ9SULg_003D.Write(_0023_003Dzqy9wa5_lpzkG(num3));
				num3 = 0u;
				num4 = 31;
			}
		}
	}

	private int _0023_003DzIM55J1cBc4EGs1x0oQ_003D_003D(int _0023_003Dz6It9KyA_003D, int _0023_003Dz5PxKZP0_003D)
	{
		int num = _0023_003Dz6It9KyA_003D / _0023_003Dz5PxKZP0_003D;
		if (_0023_003Dz6It9KyA_003D % _0023_003Dz5PxKZP0_003D != 0)
		{
			num++;
		}
		return num;
	}

	private uint _0023_003Dzqy9wa5_lpzkG(uint _0023_003Dz8GBMuoM_003D)
	{
		return (_0023_003Dz8GBMuoM_003D >> 24) | ((_0023_003Dz8GBMuoM_003D << 8) & 0xFF0000) | ((_0023_003Dz8GBMuoM_003D >> 8) & 0xFF00) | (_0023_003Dz8GBMuoM_003D << 24);
	}

	protected bool IsDragAction()
	{
		if (_0023_003DzjGvm17_0024DzsnS != actionType.ZoomWindow && _0023_003DzjGvm17_0024DzsnS != actionType.SelectVisibleByBox && _0023_003DzjGvm17_0024DzsnS != actionType.SelectByBox && _0023_003DzjGvm17_0024DzsnS != actionType.SelectByBoxEnclosed)
		{
			return IsSelectByPolygonAction();
		}
		return true;
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			return;
		}
		_0023_003DzBrC4gBvWiHkA = mouseInputType.Standard;
		_0023_003DzB7HKRwpDgejt = ActionMode;
		_0023_003DzxIgINtc_003D._0023_003Dzu8_0024tRXp_0024yCuW(e.Button);
		Focus();
		_0023_003DzPVBjq_q_0024E6tt(e.Location);
		MouseEventArgs _0023_003Dz1SmHC4c_003D = e;
		if (!_0023_003Dz_feN2jsfs6O0(_0023_003DzipBYly6zFKAp(), ref _0023_003Dz1SmHC4c_003D))
		{
			return;
		}
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		ToolBar[] toolBars = viewport.ToolBars;
		foreach (ToolBar toolBar in toolBars)
		{
			if (toolBar.Visible && toolBar._0023_003Dzu8_0024tRXp_0024yCuW(this, e))
			{
				return;
			}
		}
		if (viewport._0023_003Dz4ry2vZefVkxX != null && viewport._0023_003Dz4ry2vZefVkxX.OnMouseDown(e, viewport))
		{
			return;
		}
		bool flag = _0023_003DzxLwJIU7r9FKTi06pHA_003D_003D(e);
		if (!_0023_003Dzz2f3UQo_003D || IsSelectByPolygonAction() || flag)
		{
			if (flag)
			{
				_0023_003Dzz2f3UQo_003D = false;
				if (IsSelectByPolygonAction())
				{
					_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzxEpSi5o_003D();
				}
			}
			StartZoomPanRotate(_0023_003Dz1SmHC4c_003D, viewport);
		}
		if (e.Button == (MouseButtons)_0023_003DzipBYly6zFKAp().Rotate.MouseButton.Button)
		{
			Mouse3D.AutoCenterOfRotation = false;
			Mouse3D._0023_003Dzd9xGxp1TOJ8G(viewport, e);
		}
		_0023_003Dzf5NRO7wxeVa07xknUc_l_0024dqNXOfS();
		_0023_003DzFzzfWzVQfgnR.Stop();
		if (e.Button == MouseButtons.Left)
		{
			if (_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003DzF3HKD2trntQC() && _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.OnMouseDown(e, viewport))
			{
				return;
			}
			if (IsDragAction())
			{
				_0023_003Dzz2f3UQo_003D = true;
				_0023_003DzjRmmVH2Hj_0024KY = _0023_003Dz1SmHC4c_003D.Location;
				_0023_003Dztt6EItoclqV3 = _0023_003Dz1SmHC4c_003D.Location;
			}
			else if (!_0023_003DzceJZi0o_003D)
			{
				_0023_003Dzsf8k5Q5BH9Z_0024(e.Button, null);
			}
		}
		else if (!_0023_003DzceJZi0o_003D)
		{
			_0023_003Dzsf8k5Q5BH9Z_0024(e.Button, null);
		}
		if (viewport.Navigation._0023_003DzAC5kXfU_003D(_0023_003DzxIgINtc_003D, _0023_003DzY7PoD1c_003D))
		{
			if (!_0023_003Dzb9tWFl97201l)
			{
				_0023_003DzPqLvbvHc1U1X();
			}
		}
		else if (_0023_003DzceJZi0o_003D && _0023_003Dzb9tWFl97201l)
		{
			_0023_003DzoETR2RT_0024IhPS(_0023_003DzSB0yHII_003D: false);
		}
	}

	private bool _0023_003DzYXwsVBnYB166(MouseEventArgs _0023_003Dz1SmHC4c_003D, Viewport _0023_003DzYzWi5Yw_003D, bool _0023_003Dzb8CY_JPnW5zb)
	{
		if (_0023_003Dzb8CY_JPnW5zb)
		{
			if (_0023_003DzYzWi5Yw_003D.Zoom.Enabled && System.Windows.Forms.Control.MouseButtons == (MouseButtons)_0023_003DzYzWi5Yw_003D.Zoom.MouseButton.Button && (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(_0023_003DzYzWi5Yw_003D.Zoom.MouseButton.ModifierKey) || System.Windows.Forms.Control.ModifierKeys == (Keys)_0023_003DzYzWi5Yw_003D.Zoom.MouseButton.ModifierKey))
			{
				return true;
			}
			return false;
		}
		_0023_003DzceJZi0o_003D = true;
		_0023_003Dz1AtQxyQVwP3J = _0023_003DzjGvm17_0024DzsnS;
		_0023_003DzXRmPWIn6oGDi();
		ActionMode = actionType.Zoom;
		_0023_003DzzznZbBezl6L_();
		_0023_003DzFqaEE7IhVORj(cursorType.Zoom);
		_0023_003DzjRmmVH2Hj_0024KY = _0023_003Dz1SmHC4c_003D.Location;
		return true;
	}

	private bool _0023_003DzsK5lPdKREDNx(MouseEventArgs _0023_003Dz1SmHC4c_003D, Viewport _0023_003DzYzWi5Yw_003D, bool _0023_003Dzb8CY_JPnW5zb)
	{
		if (_0023_003Dzb8CY_JPnW5zb)
		{
			if (_0023_003DzYzWi5Yw_003D.Pan.Enabled && System.Windows.Forms.Control.MouseButtons == (MouseButtons)_0023_003DzYzWi5Yw_003D.Pan.MouseButton.Button && (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(_0023_003DzYzWi5Yw_003D.Pan.MouseButton.ModifierKey) || System.Windows.Forms.Control.ModifierKeys == (Keys)_0023_003DzYzWi5Yw_003D.Pan.MouseButton.ModifierKey))
			{
				return true;
			}
			return false;
		}
		_0023_003DzceJZi0o_003D = true;
		_0023_003Dz1AtQxyQVwP3J = _0023_003DzjGvm17_0024DzsnS;
		_0023_003DzXRmPWIn6oGDi();
		ActionMode = actionType.Pan;
		_0023_003DzzznZbBezl6L_();
		_0023_003DzFqaEE7IhVORj(cursorType.Pan);
		_0023_003DzjRmmVH2Hj_0024KY = _0023_003Dz1SmHC4c_003D.Location;
		return true;
	}

	private bool _0023_003DzxVKlICTSfEi4(MouseEventArgs _0023_003Dz1SmHC4c_003D, Viewport _0023_003DzYzWi5Yw_003D, bool _0023_003Dzb8CY_JPnW5zb)
	{
		if (_0023_003Dzb8CY_JPnW5zb)
		{
			if (_0023_003DzYzWi5Yw_003D.Rotate.Enabled && System.Windows.Forms.Control.MouseButtons == (MouseButtons)_0023_003DzYzWi5Yw_003D.Rotate.MouseButton.Button && (_0023_003DzY7PoD1c_003D._0023_003DzETD8ckar3LuB(_0023_003DzYzWi5Yw_003D.Rotate.MouseButton.ModifierKey) || System.Windows.Forms.Control.ModifierKeys == (Keys)_0023_003DzYzWi5Yw_003D.Rotate.MouseButton.ModifierKey))
			{
				return true;
			}
			return false;
		}
		_0023_003DzceJZi0o_003D = true;
		_0023_003Dz1AtQxyQVwP3J = _0023_003DzjGvm17_0024DzsnS;
		_0023_003DzXRmPWIn6oGDi();
		ActionMode = actionType.Rotate;
		_0023_003DzzznZbBezl6L_();
		_0023_003DzFqaEE7IhVORj(cursorType.Rotate);
		_0023_003DzYzWi5Yw_003D._0023_003DzjUZA_0024Ue8Set2(_0023_003Dz1SmHC4c_003D.Location, _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D, _0023_003DzYzWi5Yw_003D.Rotate.RotationMode);
		_0023_003DzjRmmVH2Hj_0024KY = _0023_003Dz1SmHC4c_003D.Location;
		return true;
	}

	protected internal void StartZoomPanRotate(MouseEventArgs e, Viewport viewport)
	{
		if (_0023_003DzZ5L0bhmvC_0024K7)
		{
			_0023_003Dzwp0pao5NhqfO();
		}
		foreach (KeyValuePair<int, Delegate> item in new Dictionary<int, Delegate>
		{
			{
				viewport.Zoom.MouseButton.ModifierKey._0023_003DzFjSNbw0_003D() + 1,
				new Func<MouseEventArgs, Viewport, bool, bool>(_0023_003DzYXwsVBnYB166)
			},
			{
				viewport.Pan.MouseButton.ModifierKey._0023_003DzFjSNbw0_003D() + 2,
				new Func<MouseEventArgs, Viewport, bool, bool>(_0023_003DzsK5lPdKREDNx)
			},
			{
				viewport.Rotate.MouseButton.ModifierKey._0023_003DzFjSNbw0_003D() + 3,
				new Func<MouseEventArgs, Viewport, bool, bool>(_0023_003DzxVKlICTSfEi4)
			}
		}.OrderByDescending((KeyValuePair<int, Delegate> _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D.Key))
		{
			if ((bool)item.Value.DynamicInvoke(e, viewport, true))
			{
				item.Value.DynamicInvoke(e, viewport, false);
				break;
			}
		}
		if (e.Button == MouseButtons.Left && _0023_003DzjGvm17_0024DzsnS == actionType.Rotate)
		{
			viewport._0023_003DzjUZA_0024Ue8Set2(e.Location, _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D, viewport.Rotate.RotationMode);
			_0023_003DzjRmmVH2Hj_0024KY = e.Location;
		}
		else
		{
			_0023_003DzjRmmVH2Hj_0024KY = e.Location;
			_0023_003Dztt6EItoclqV3 = e.Location;
		}
		if (!Moving)
		{
			_0023_003Dz45nROag3JCGB(viewport, e);
		}
	}

	private void _0023_003DzPqLvbvHc1U1X()
	{
		_0023_003DzPPWf23dA_0024OGK = true;
		_0023_003DzoETR2RT_0024IhPS(_0023_003DzSB0yHII_003D: true);
		_0023_003DzxIgINtc_003D._0023_003Dzgv3CpKlqLndg(this);
		_0023_003DzxIgINtc_003D._0023_003Dz85CTaduOYRBd();
	}

	internal void _0023_003DzNEH_0024_00242U_003D(MouseEventArgs _0023_003Dz1SmHC4c_003D, Viewport _0023_003DzYzWi5Yw_003D, rotationType _0023_003DzkBN945tq8dje)
	{
		if (_0023_003DzYzWi5Yw_003D.Rotate.Enabled)
		{
			_0023_003DznNgMufc_003D = new _0023_003DzCpv3RVLsUYJ9(this);
			_0023_003DzXRmPWIn6oGDi();
			ActionMode = actionType.Rotate;
			_0023_003DzzznZbBezl6L_();
			_0023_003DzYzWi5Yw_003D.Rotate.RotationMode = _0023_003DzkBN945tq8dje;
			if (_0023_003DzYzWi5Yw_003D.Rotate.RotationCenter != rotationCenterType.Point)
			{
				_0023_003DzYzWi5Yw_003D.Rotate.RotationCenter = rotationCenterType.ViewportCenter;
			}
			_0023_003DzYzWi5Yw_003D._0023_003Dzl94UA_0024lVBcra = _0023_003Dz1SmHC4c_003D.Location;
			_0023_003DzYzWi5Yw_003D._0023_003DzjUZA_0024Ue8Set2(_0023_003Dz1SmHC4c_003D.Location, _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D, _0023_003DzYzWi5Yw_003D.Rotate.RotationMode);
			_0023_003DzjRmmVH2Hj_0024KY = _0023_003Dz1SmHC4c_003D.Location;
			_0023_003Dz45nROag3JCGB(_0023_003DzYzWi5Yw_003D, _0023_003Dz1SmHC4c_003D);
		}
	}

	internal void _0023_003DzcWhtcC8_003D(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003DzYzWi5Yw_003D.Rotate.Enabled)
		{
			_0023_003DzYzWi5Yw_003D._0023_003Dzl94UA_0024lVBcra = System.Drawing.Point.Empty;
			_0023_003DznNgMufc_003D._0023_003DzDuJLCUo_003D(this);
		}
	}

	internal int _0023_003DzPVBjq_q_0024E6tt(System.Drawing.Point _0023_003DzTYCHRugcseEq)
	{
		bool flag = false;
		int viewportUnderMouse = GetViewportUnderMouse(_0023_003DzTYCHRugcseEq);
		if (viewportUnderMouse != -1)
		{
			if (_0023_003DzBn2ByFKdwrou != viewportUnderMouse)
			{
				flag = true;
				if (_0023_003DzjGvm17_0024DzsnS == actionType.Pan || _0023_003DzjGvm17_0024DzsnS == actionType.Zoom || _0023_003DzjGvm17_0024DzsnS == actionType.ZoomWindow || _0023_003DzjGvm17_0024DzsnS == actionType.Rotate || _0023_003DzjGvm17_0024DzsnS == actionType.MagnifyingGlass)
				{
					ActionMode = actionType.None;
				}
				_0023_003Dzwp0pao5NhqfO(_0023_003DzBn2ByFKdwrou);
			}
			if (IsBusy && viewportUnderMouse != _0023_003DzBn2ByFKdwrou)
			{
				_0023_003DzipBYly6zFKAp()._0023_003Dz_0024vGIP8ipyEwE();
				_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[viewportUnderMouse]._0023_003DzAmQmFnNJkaOUqpvwTQ_003D_003D().Buttons.Add(ProgressBarCancelButton);
			}
			_0023_003DzBn2ByFKdwrou = viewportUnderMouse;
			flag |= Mouse3D._0023_003DzI8QnuD_uT7AD(_0023_003DzipBYly6zFKAp());
		}
		if (flag)
		{
			PaintBackBuffer();
			DrawScene(_0023_003DzipBYly6zFKAp(), 1f, _0023_003DzQmbl9PzBp44d, RectangleF.Empty, drawOverlay: true, swapBuffer: true, isDesignMode: false);
		}
		return viewportUnderMouse;
	}

	protected internal virtual int GetViewportUnderMouse(System.Drawing.Point mousePos)
	{
		int result = -1;
		for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
		{
			if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]._0023_003Dz_feN2jsfs6O0(mousePos, out var _))
			{
				result = i;
				break;
			}
		}
		return result;
	}

	private bool _0023_003Dz_feN2jsfs6O0(int _0023_003DzZnwLfu4_003D, ref MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		return _0023_003Dz_feN2jsfs6O0(_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[_0023_003DzZnwLfu4_003D], ref _0023_003Dz1SmHC4c_003D);
	}

	internal static bool _0023_003Dz_feN2jsfs6O0(Viewport _0023_003DzYzWi5Yw_003D, ref MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		System.Drawing.Point _0023_003DzD_hjMo9IBHeB;
		bool result = _0023_003DzYzWi5Yw_003D._0023_003Dz_feN2jsfs6O0(_0023_003Dz1SmHC4c_003D.Location, out _0023_003DzD_hjMo9IBHeB);
		_0023_003Dz1SmHC4c_003D = new MouseEventArgs(_0023_003Dz1SmHC4c_003D.Button, _0023_003Dz1SmHC4c_003D.Clicks, _0023_003DzD_hjMo9IBHeB.X, _0023_003DzD_hjMo9IBHeB.Y, _0023_003Dz1SmHC4c_003D.Delta);
		return result;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);
		_0023_003DzxIgINtc_003D._0023_003DzshPEPAc_003D(this, e.Location);
		if (_0023_003DzPPWf23dA_0024OGK || _0023_003Dz0h9vskpSVtRx)
		{
			_0023_003DzPPWf23dA_0024OGK = false;
		}
		else
		{
			if (_0023_003Dz8Q16RtM94O0K() || _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
			{
				return;
			}
			System.Drawing.Point location = e.Location;
			MouseEventArgs _0023_003Dz1SmHC4c_003D = e;
			_0023_003Dz_feN2jsfs6O0(_0023_003DzipBYly6zFKAp(), ref _0023_003Dz1SmHC4c_003D);
			Viewport viewport = _0023_003DzipBYly6zFKAp();
			bool flag = false;
			bool _0023_003DzprYbenN6veHPuANVgQ_003D_003D = false;
			if (_0023_003Dzz2f3UQo_003D)
			{
				if (!_0023_003DzhfwTtuYclW899eUCjQ_003D_003D)
				{
					_0023_003Dztt6EItoclqV3 = _0023_003Dz1SmHC4c_003D.Location;
				}
				_0023_003DzhfwTtuYclW899eUCjQ_003D_003D = false;
				if (_0023_003DzMBy_0024512q0kfX())
				{
					Invalidate();
				}
				else
				{
					PaintBackBuffer();
				}
				if (!_0023_003DzMBy_0024512q0kfX())
				{
					SwapBuffers();
				}
			}
			else
			{
				if ((ActionMode == actionType.MagnifyingGlass || ActionMode == actionType.SelectVisibleByPickDynamic) && _0023_003Dzo_MNAFBAjuGu == 0)
				{
					bool flag2 = _0023_003DzR8L_0024Yw_00244jJcu(viewport, e);
					if (ActionMode == actionType.MagnifyingGlass)
					{
						if (flag2)
						{
							MagnifyingGlass._0023_003DzPTfEdKLFXzku(_0023_003DzsLHxXyo_003D: true);
						}
						else
						{
							MagnifyingGlass._0023_003DzPTfEdKLFXzku(_0023_003DzsLHxXyo_003D: false);
							_0023_003DzprYbenN6veHPuANVgQ_003D_003D |= MagnifyingGlass._0023_003DzMhJnK2KPd8YE(this, e.Location);
						}
					}
					else if (ActionMode == actionType.SelectVisibleByPickDynamic && !Moving && !_0023_003DztdGp9MI3CH2w)
					{
						_0023_003DzprYbenN6veHPuANVgQ_003D_003D |= _0023_003DzDNLc1QbWJ8j9(e, flag2, viewport, ref _0023_003DzprYbenN6veHPuANVgQ_003D_003D);
					}
				}
				ToolBar[] toolBars = viewport.ToolBars;
				foreach (ToolBar toolBar in toolBars)
				{
					if (toolBar.Visible)
					{
						flag |= toolBar._0023_003DzMhJnK2KPd8YE(this, e);
					}
				}
				_0023_003DziO09jLCCMyhZQuGLSQ_003D_003D(viewport, e.Location);
			}
			bool flag3 = viewport.Navigation._0023_003DzAC5kXfU_003D(_0023_003DzxIgINtc_003D, _0023_003DzY7PoD1c_003D);
			if (!Moving && flag3 && !_0023_003Dzb9tWFl97201l)
			{
				_0023_003DzPqLvbvHc1U1X();
			}
			if (Moving || flag3)
			{
				_0023_003Dztt6EItoclqV3 = _0023_003Dz1SmHC4c_003D.Location;
				int num = _0023_003DzjRmmVH2Hj_0024KY.X - _0023_003Dztt6EItoclqV3.X;
				int num2 = _0023_003DzjRmmVH2Hj_0024KY.Y - _0023_003Dztt6EItoclqV3.Y;
				if (num == 0 && num2 == 0)
				{
					return;
				}
				switch (_0023_003DzjGvm17_0024DzsnS)
				{
				case actionType.None:
					if (flag3)
					{
						viewport._0023_003Dz3w_00240eHwLabq0(this, _0023_003DzY7PoD1c_003D, _0023_003DzxIgINtc_003D, 1.0);
						_0023_003DzH_ACO1keHrO4();
					}
					break;
				case actionType.Rotate:
					if (viewport.Rotate.Enabled)
					{
						if (viewport._0023_003Dz4ry2vZefVkxX != null && viewport._0023_003Dz4ry2vZefVkxX.Visible && viewport._0023_003Dz4ry2vZefVkxX.Dragging)
						{
							viewport._0023_003Dz4ry2vZefVkxX._0023_003DzqTTMKmE_003D(e, viewport, e.Location, num, num2);
						}
						else
						{
							viewport._0023_003Dzk_0024_0024VvG_00245PP4u(_0023_003Dz1SmHC4c_003D.Location, num, num2, _0023_003DzBQC8k3F0wJN4: false);
						}
						_0023_003DzH_ACO1keHrO4();
					}
					_0023_003DzjRmmVH2Hj_0024KY = _0023_003Dztt6EItoclqV3;
					break;
				case actionType.Zoom:
					if (viewport.Zoom.Enabled)
					{
						ZoomCamera(num2, animate: false);
						_0023_003DzH_ACO1keHrO4();
						_0023_003DzjRmmVH2Hj_0024KY = _0023_003Dztt6EItoclqV3;
					}
					break;
				case actionType.Pan:
					if (viewport.Pan.Enabled)
					{
						PanCamera(_0023_003DzjRmmVH2Hj_0024KY, _0023_003Dztt6EItoclqV3, animate: false);
						_0023_003DzH_ACO1keHrO4();
						_0023_003DzjRmmVH2Hj_0024KY = _0023_003Dztt6EItoclqV3;
					}
					break;
				}
				return;
			}
			if (viewport._0023_003Dz4ry2vZefVkxX != null)
			{
				_0023_003DzprYbenN6veHPuANVgQ_003D_003D |= viewport._0023_003Dz4ry2vZefVkxX.OnMouseMove(e, viewport, flag);
			}
			if (ActionMode != actionType.MagnifyingGlass && _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003DzF3HKD2trntQC() && ActionMode != actionType.Pan && _0023_003DzjGvm17_0024DzsnS != actionType.Zoom && _0023_003DzjGvm17_0024DzsnS != actionType.Rotate && _0023_003DzjGvm17_0024DzsnS != actionType.ZoomWindow)
			{
				_0023_003DzprYbenN6veHPuANVgQ_003D_003D = ((!_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.Dragging) ? (_0023_003DzprYbenN6veHPuANVgQ_003D_003D | _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003DzMhJnK2KPd8YE(this, viewport, location, flag)) : (_0023_003DzprYbenN6veHPuANVgQ_003D_003D | _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.OnDrag(ref _0023_003DzjRmmVH2Hj_0024KY, _0023_003Dz1SmHC4c_003D.Location, viewport)));
			}
			if (_0023_003DzprYbenN6veHPuANVgQ_003D_003D)
			{
				if (_0023_003DzMBy_0024512q0kfX() || (_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D != null && !_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.ShowPreviewOnTop && _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.Visible && _0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.Dragging))
				{
					Invalidate();
					return;
				}
				PaintBackBuffer();
				SwapBuffers();
			}
		}
	}

	private bool _0023_003DzDNLc1QbWJ8j9(MouseEventArgs _0023_003Dz1SmHC4c_003D, bool _0023_003DzTH5R2akZauqJ, Viewport _0023_003DzYzWi5Yw_003D, ref bool _0023_003DzprYbenN6veHPuANVgQ_003D_003D)
	{
		bool result = false;
		if (_0023_003DzTH5R2akZauqJ)
		{
			_0023_003DzgowXYVJqM2Vg = true;
		}
		else
		{
			_0023_003DzgowXYVJqM2Vg = false;
			_0023_003DzprYbenN6veHPuANVgQ_003D_003D = true;
			Rectangle selectionBox = new Rectangle(_0023_003Dz1SmHC4c_003D.X - PickBoxSize / 2, _0023_003Dz1SmHC4c_003D.Y - PickBoxSize / 2, PickBoxSize, PickBoxSize);
			_0023_003Dz0_czIjY3d3YXM7nQVA_003D_003D(_0023_003DzAqbizhcYZ5va: false, _0023_003DzYzWi5Yw_003D, _0023_003DznmpiQBcqK9AE, _0023_003DzUsW18wvfQQpu: true);
			ProcessSelectionVisibleOnly(selectionBox, firstOnly: true, invert: false, _0023_003DznmpiQBcqK9AE, selectableOnly: true, temporarySelection: true);
			if (!_0023_003DzMBy_0024512q0kfX() && !_0023_003DzFKfBt_CG51tvOLuykA_003D_003D)
			{
				result = _0023_003DznmpiQBcqK9AE.AddedItems.Count > 0 || _0023_003DznmpiQBcqK9AE.RemovedItems.Count > 0;
			}
		}
		return result;
	}

	private void _0023_003DzquuYPMJBed38(Viewport _0023_003DzYzWi5Yw_003D, BlockKeyedCollection _0023_003Dz9W2nj9A_003D)
	{
		if (_0023_003DznmpiQBcqK9AE.AddedItems.Count == 0)
		{
			return;
		}
		DrawSceneParams.IsCurrentViewport(this, _0023_003DzYzWi5Yw_003D);
		_0023_003DzYzWi5Yw_003D._0023_003Dzl_s8qNo_003D(0.001f, 1f);
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		if (!_0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(_0023_003DzYzWi5Yw_003D))
		{
			_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		}
		List<Entity> list = new List<Entity>(_0023_003DznmpiQBcqK9AE.AddedItems.Count);
		for (int i = 0; i < _0023_003DznmpiQBcqK9AE.AddedItems.Count; i++)
		{
			SelectedItem selectedItem = _0023_003DznmpiQBcqK9AE.AddedItems[i];
			if (selectedItem.Item is BlockReference)
			{
				list.Add((Entity)selectedItem.Item);
			}
			else
			{
				list.Add(new NestedEntity(selectedItem, Layers, Blocks, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D));
			}
		}
		if (list.Count > 0)
		{
			_0023_003DzmNZD0Zs_003D.ProcessClippingPlanes(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, updateGraphics: true);
			DrawSceneParams drawSceneParams = new DrawSceneParams
			{
				Viewport = _0023_003DzYzWi5Yw_003D,
				DrawScale = 1f,
				LineWeightFactor = _0023_003DzQmbl9PzBp44d,
				DrawOverlay = false,
				IsDesignMode = false,
				SwapBuffer = false,
				ZoomRect = default(RectangleF),
				CaptureSurface = false,
				ZBufferOnly = true,
				Entities = list,
				Blocks = _0023_003Dz9W2nj9A_003D,
				RenderContext = _0023_003DzmNZD0Zs_003D,
				SelectionStatus = selectionStatusType.Temporary,
				SkipSsao = true
			};
			_0023_003DzmNZD0Zs_003D.UpdateActiveLights(_0023_003DzMuApP021PUyU);
			if (drawSceneParams.ShaderParams == null)
			{
				drawSceneParams.ShaderParams = _0023_003DzdfzPZ4BvPfHu(drawSceneParams);
			}
			if (_0023_003DzYzWi5Yw_003D._0023_003DzK_00241ezHQJ9Z3c == displayType.Rendered)
			{
				drawSceneParams.ShaderParams.PrepareForRender(drawSceneParams.RenderContext, _0023_003DznKkOfo8_003D.EnvironmentMapping ? _0023_003DziuvwBNA4duWb : null);
			}
			shaderType shaderAndEnable = drawSceneParams.RenderContext.GetShaderAndEnable(drawSceneParams.ShaderParams);
			RenderContextBase.UpdateShaders(StandardShaders, drawSceneParams.ShaderParams);
			drawSceneParams.RenderContext.SetShader(shaderAndEnable, drawSceneParams.ShaderParams, force: true);
			_0023_003DzXsG3_0024Rpj5_iYwQvVnA_003D_003D(_0023_003DzaQjlm2QrbCIyC2Mauw_003D_003D, drawSceneParams);
			_0023_003DzmNZD0Zs_003D.DisableClipPlanes();
		}
		_0023_003DzYzWi5Yw_003D._0023_003Dzl_s8qNo_003D(0f, 0.001f);
	}

	private void _0023_003Dz22IbkGvwx_47srnMLDE8I_00240_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003Dz89cPk57rASTGmdmTnA_003D_003D((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzPHqp5dQ_003D: false, default(RectangleF), CameraEyePosType.Center, _0023_003Dzk7pNhlbdSzPJ: true);
		_0023_003Dz_00245AA7MKw1Rjg6c1dZ31GM1Y_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz7lHhy1sRzZpO8EN9H6byh5QASR31: true, _0023_003Dz5vxPVaF6_0024csnbahlHIqw2Dk_003D: false, selectionStatusType.Temporary);
	}

	public virtual bool GetTemporarySelectionFaceData(Stack<BlockReference> parents, Entity ent, List<SelectionInfoSubItems> faceSelInfo, selectionStatusType selStatus)
	{
		return false;
	}

	private void _0023_003DzG3sj0FFSBkNrHyujN8NeHIHd8KYm(Color _0023_003DzmhTI7UsLCN0t, Color _0023_003Dzky2wVp2NfbbX)
	{
		Selection.Color = _0023_003DzmhTI7UsLCN0t;
		Selection.ColorDynamic = _0023_003Dzky2wVp2NfbbX;
	}

	private void _0023_003DzZXXk_zTofCaZo4oAL4h_0024Aj6IxdJJ(out Color _0023_003DzY0QKsduO660t, out Color _0023_003DzIrjRBKtrORSoH3gT4A_003D_003D)
	{
		_0023_003DzY0QKsduO660t = Selection.Color;
		_0023_003DzIrjRBKtrORSoH3gT4A_003D_003D = Selection.ColorDynamic;
		SelectionSettings selection = Selection;
		Color color = (Selection.ColorDynamic = RenderContextBase.selectionWithoutHaloColor);
		selection.Color = color;
	}

	private void _0023_003DzaQjlm2QrbCIyC2Mauw_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.Entities.Count > 0 && _0023_003DzCBM7XJK4_5H_0024.Entities[0] is NestedEntity nestedEntity)
		{
			List<SelectionInfoSubItems> list = null;
			Entity entity = nestedEntity.entity;
			if (entity is Brep brep)
			{
				list = brep.FacesSelectionInfo;
			}
			else if (entity is Solid solid)
			{
				list = solid.FacesSelectionInfo;
			}
			else if (entity is Mesh mesh)
			{
				list = mesh.FacesSelectionInfo;
			}
			if (list != null && GetTemporarySelectionFaceData(nestedEntity.parents, entity, list, _0023_003DzCBM7XJK4_5H_0024.SelectionStatus))
			{
				return;
			}
		}
		bool flag = false;
		Viewport _0023_003DzYzWi5Yw_003D = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		if (_0023_003DzSZrLDr7Hn_yF9Hk8gA_003D_003D(_0023_003DzYzWi5Yw_003D))
		{
			flag = true;
			_0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing?.SetTarget();
			_0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing?.Clear(((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport)._0023_003Dzr_AjDsvNuuYG(), _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D);
			_0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo = true;
		}
		_0023_003DzmNZD0Zs_003D.ProcessLightAttributes(shadowPass: false, reflection: false);
		_0023_003Dz89cPk57rASTGmdmTnA_003D_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzCBM7XJK4_5H_0024.PlanarReflections, _0023_003DzCBM7XJK4_5H_0024.ZoomRect, _0023_003DzCBM7XJK4_5H_0024.CameraEyePos, _0023_003Dzk7pNhlbdSzPJ: true);
		switch (_0023_003Dz28QCun7pbbWH)
		{
		case selectionFilterType.Edge:
		case selectionFilterType.Contour:
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetLighting(enable: false);
			_0023_003DzmNZD0Zs_003D.InitializeCurrentWireColor();
			_0023_003DzUuKcWs7AMvWH(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz0fTtstT4IqGh(_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode), _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: false);
			break;
		case selectionFilterType.Entity:
			if (!flag)
			{
				_0023_003Dz63GJxgPNPnh1Xegeiw_003D_003D(_0023_003DzCBM7XJK4_5H_0024);
			}
			if (_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode != displayType.Wireframe)
			{
				if (flag)
				{
					_0023_003Dzipe8ch4_003D.ShowEdges = false;
				}
				_0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(_0023_003DzCBM7XJK4_5H_0024, !flag, (_0023_003DzARfd93yYb38F)3);
				if (flag)
				{
					_0023_003Dzipe8ch4_003D.ShowEdges = true;
				}
			}
			break;
		case selectionFilterType.Face:
		case selectionFilterType.SubCurve:
		case selectionFilterType.SketchPoint:
		case selectionFilterType.SketchCurve:
		case selectionFilterType.SketchPoint | selectionFilterType.SketchCurve:
			if (flag)
			{
				_0023_003Dzipe8ch4_003D.ShowEdges = false;
			}
			_0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dzz4aiLqY_0024r7bL: true, (_0023_003DzARfd93yYb38F)3);
			if (flag)
			{
				_0023_003Dzipe8ch4_003D.ShowEdges = true;
			}
			break;
		default:
			if ((_0023_003Dz28QCun7pbbWH & selectionFilterType.Vertex) != 0)
			{
				Color _0023_003DzY0QKsduO660t = default(Color);
				Color _0023_003DzIrjRBKtrORSoH3gT4A_003D_003D = default(Color);
				if (flag)
				{
					_0023_003DzZXXk_zTofCaZo4oAL4h_0024Aj6IxdJJ(out _0023_003DzY0QKsduO660t, out _0023_003DzIrjRBKtrORSoH3gT4A_003D_003D);
				}
				_0023_003Dz22IbkGvwx_47srnMLDE8I_00240_003D(_0023_003DzCBM7XJK4_5H_0024);
				if (flag)
				{
					_0023_003DzG3sj0FFSBkNrHyujN8NeHIHd8KYm(_0023_003DzY0QKsduO660t, _0023_003DzIrjRBKtrORSoH3gT4A_003D_003D);
				}
			}
			if ((_0023_003Dz28QCun7pbbWH & selectionFilterType.Edge) != 0)
			{
				_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
				_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetLighting(enable: false);
				_0023_003DzmNZD0Zs_003D.InitializeCurrentWireColor();
				_0023_003DzUuKcWs7AMvWH(_0023_003DzCBM7XJK4_5H_0024, _0023_003Dz0fTtstT4IqGh(_0023_003DzCBM7XJK4_5H_0024.Viewport.DisplayMode), _0023_003Dz4Ar9tWcO_NWZwEwv6w_003D_003D: false);
			}
			if ((_0023_003Dz28QCun7pbbWH & selectionFilterType.Face) != 0)
			{
				if (flag)
				{
					_0023_003Dzipe8ch4_003D.ShowEdges = false;
				}
				_0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(_0023_003DzCBM7XJK4_5H_0024, !flag, (_0023_003DzARfd93yYb38F)3);
				if (flag)
				{
					_0023_003Dzipe8ch4_003D.ShowEdges = true;
				}
			}
			break;
		}
		if (flag)
		{
			_0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing?.ResetTarget();
			_0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing?.Update(Selection.HaloInnerColorDynamic, Selection.HaloOuterColorDynamic, Selection.ColorDynamic, _0023_003Dz172y4KzLmCm83OqS4g_003D_003D(Selection.ColorDynamic, 0.3), Selection.HaloWidthPolygons, Selection.HaloWidthWires);
			_0023_003DzmNZD0Zs_003D.dynamicSelectionCompositing?.DrawOnTopOfCurrentTarget(((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport)._0023_003Dzr_AjDsvNuuYG(), _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D);
			_0023_003DzCBM7XJK4_5H_0024.isDrawingDynamicWithHalo = false;
		}
	}

	private bool _0023_003DzR8L_0024Yw_00244jJcu(Viewport _0023_003DzYzWi5Yw_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzLliFkdGqG0Ir8wrEPhjY1fk_003D _0023_003DzLliFkdGqG0Ir8wrEPhjY1fk_003D2 = new _0023_003DzLliFkdGqG0Ir8wrEPhjY1fk_003D();
		_0023_003DzLliFkdGqG0Ir8wrEPhjY1fk_003D2._0023_003Dz1SmHC4c_003D = _0023_003Dz1SmHC4c_003D;
		if (_0023_003DzYzWi5Yw_003D.ToolBars.Count(_0023_003DzLliFkdGqG0Ir8wrEPhjY1fk_003D2._0023_003DzkmHh2pwXmQclBKAiBQ_003D_003D) <= 0)
		{
			if (_0023_003DzYzWi5Yw_003D.ViewCubeIcon != null && _0023_003DzYzWi5Yw_003D.ViewCubeIcon._0023_003Dzc3vkuqr_ddi7(_0023_003DzYzWi5Yw_003D, _0023_003DzYzWi5Yw_003D.GetViewFrame(), _0023_003DzLliFkdGqG0Ir8wrEPhjY1fk_003D2._0023_003Dz1SmHC4c_003D.Location))
			{
				return _0023_003DzYzWi5Yw_003D.ViewCubeIcon.Contains(_0023_003DzLliFkdGqG0Ir8wrEPhjY1fk_003D2._0023_003Dz1SmHC4c_003D.Location);
			}
			return false;
		}
		return true;
	}

	private void _0023_003DziO09jLCCMyhZQuGLSQ_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq)
	{
		ToolBar toolBar = null;
		ToolBar[] toolBars = _0023_003DzYzWi5Yw_003D.ToolBars;
		foreach (ToolBar toolBar2 in toolBars)
		{
			if (toolBar2.Contains(_0023_003DzTYCHRugcseEq))
			{
				toolBar = toolBar2;
				break;
			}
		}
		if (toolBar != null && !toolBar._0023_003DzzL5IpUnrTwJugl0U9w_003D_003D())
		{
			_0023_003DzhuBlAi9v6TXq(_0023_003DzWtFDQr8_003D: true);
		}
		else
		{
			_0023_003DzhuBlAi9v6TXq(_0023_003DzWtFDQr8_003D: false);
		}
	}

	internal void _0023_003DzswdnfpGrZ2Nx(int _0023_003DzZnwLfu4_003D)
	{
		if (Moving)
		{
			_0023_003DzBhiHJ1K9qQ76(_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[_0023_003DzZnwLfu4_003D]);
			Moving = false;
		}
	}

	internal bool _0023_003DzTAGVj_ePZ3pfzt_uDQ_003D_003D()
	{
		if (!Moving && !_0023_003DztdGp9MI3CH2w)
		{
			if (_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D != null && _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Visible && !_0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.ShowPreviewOnTop)
			{
				return _0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.Dragging;
			}
			return false;
		}
		return true;
	}

	private void _0023_003Dz45nROag3JCGB(Viewport _0023_003DzYzWi5Yw_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		bool flag = _0023_003DzjGvm17_0024DzsnS == actionType.Zoom || _0023_003DzjGvm17_0024DzsnS == actionType.Pan || _0023_003DzjGvm17_0024DzsnS == actionType.Rotate;
		bool flag2 = _0023_003Dz_0024m55wm11QcKH(_0023_003Dz1SmHC4c_003D);
		Moving = flag && flag2;
		Moving |= _0023_003DzjGvm17_0024DzsnS == actionType.None && _0023_003DzYzWi5Yw_003D.Navigation._0023_003DzAC5kXfU_003D(_0023_003DzxIgINtc_003D, _0023_003DzY7PoD1c_003D);
		if (Moving && !_0023_003DzYzWi5Yw_003D._0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			_0023_003DzSGfimhJkGdqe(_0023_003DzipBYly6zFKAp());
		}
	}

	private bool _0023_003Dz_0024m55wm11QcKH(MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if ((_0023_003Dz1SmHC4c_003D.Button & MouseButtons.Left) == 0 || !_0023_003DzxIgINtc_003D._0023_003DzsZJmCwY_003D(MouseButtons.Left))
		{
			return _0023_003DzxLwJIU7r9FKTi06pHA_003D_003D(_0023_003Dz1SmHC4c_003D);
		}
		return true;
	}

	private bool _0023_003DzxLwJIU7r9FKTi06pHA_003D_003D(MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		if ((((uint)_0023_003Dz1SmHC4c_003D.Button & (uint)viewport.Zoom.MouseButton.Button) == 0 || !_0023_003DzxIgINtc_003D._0023_003DzsZJmCwY_003D((MouseButtons)viewport.Zoom.MouseButton.Button) || System.Windows.Forms.Control.ModifierKeys != (Keys)viewport.Zoom.MouseButton.ModifierKey) && (((uint)_0023_003Dz1SmHC4c_003D.Button & (uint)viewport.Pan.MouseButton.Button) == 0 || !_0023_003DzxIgINtc_003D._0023_003DzsZJmCwY_003D((MouseButtons)viewport.Pan.MouseButton.Button) || System.Windows.Forms.Control.ModifierKeys != (Keys)viewport.Pan.MouseButton.ModifierKey) && (((uint)_0023_003Dz1SmHC4c_003D.Button & (uint)viewport.Rotate.MouseButton.Button) == 0 || !_0023_003DzxIgINtc_003D._0023_003DzsZJmCwY_003D((MouseButtons)viewport.Rotate.MouseButton.Button) || System.Windows.Forms.Control.ModifierKeys != (Keys)viewport.Rotate.MouseButton.ModifierKey))
		{
			if (_0023_003Dz1SmHC4c_003D.Button == MouseButtons.None)
			{
				if (viewport.Zoom.MouseButton.Button != mouseButtonsZPR.None && viewport.Pan.MouseButton.Button != mouseButtonsZPR.None)
				{
					return viewport.Rotate.MouseButton.Button == mouseButtonsZPR.None;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	private void _0023_003DzLZo9rSh_0024uTkmB0bDuQ_003D_003D(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (base.InvokeRequired)
		{
			BeginInvoke(new MethodInvoker(_0023_003DzPFFaaGJBYbmGfv9zdvfdyIjoPKJl));
		}
		else
		{
			_0023_003Dz11CadYMOXmz_(_0023_003DzipBYly6zFKAp());
		}
	}

	internal void _0023_003Dz11CadYMOXmz_(Viewport _0023_003DzYzWi5Yw_003D)
	{
		_0023_003DzlPALPXW8i7Fn11_cJNElnPw_003D();
		if (_0023_003DzFqDpQW4_003D != null)
		{
			_0023_003DzFqDpQW4_003D(this, new CameraMoveEventArgs(_0023_003DzYzWi5Yw_003D));
		}
	}

	internal void _0023_003DzSGfimhJkGdqe(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (!_0023_003Dzkxa5rh7IEj_gGwqk6w_003D_003D && !_0023_003DzFKfBt_CG51tvOLuykA_003D_003D)
		{
			_0023_003DzlPALPXW8i7Fn11_cJNElnPw_003D();
			if (_0023_003Dz4QCZfUcWn12C != null)
			{
				_0023_003Dz4QCZfUcWn12C(this, new CameraMoveEventArgs(_0023_003DzYzWi5Yw_003D));
			}
			if (_0023_003DzFqDpQW4_003D != null && !_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Enabled)
			{
				_0023_003Dz11CadYMOXmz_(_0023_003DzipBYly6zFKAp());
				_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Start();
			}
			_0023_003DzFKfBt_CG51tvOLuykA_003D_003D = true;
		}
	}

	internal void _0023_003DzBhiHJ1K9qQ76(Viewport _0023_003DzYzWi5Yw_003D)
	{
		_0023_003DzBhiHJ1K9qQ76(_0023_003DzYzWi5Yw_003D, out var _);
	}

	internal void _0023_003DzBhiHJ1K9qQ76(Viewport _0023_003DzYzWi5Yw_003D, out bool _0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D)
	{
		if (!_0023_003DzFKfBt_CG51tvOLuykA_003D_003D)
		{
			_0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D = false;
			return;
		}
		_0023_003DzYzWi5Yw_003D.SavedViews._0023_003DzBWHJkhEXTRTU();
		if (_0023_003DzLi0Sdf3SlhGQ != null)
		{
			_0023_003DzLi0Sdf3SlhGQ(this, new CameraMoveEventArgs(_0023_003DzYzWi5Yw_003D));
		}
		_0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D = Mouse3D._0023_003DzI8QnuD_uT7AD(_0023_003DzYzWi5Yw_003D);
		if (_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D != null && _0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Enabled)
		{
			_0023_003Dz2abJDZWFN1ExIkiguQ_003D_003D.Stop();
		}
		_0023_003DzFKfBt_CG51tvOLuykA_003D_003D = false;
	}

	public virtual void ZoomCamera(int dy)
	{
		_0023_003DzipBYly6zFKAp().ZoomCamera(dy);
	}

	public virtual void ZoomCamera(int dy, bool animate)
	{
		_0023_003DzipBYly6zFKAp().ZoomCamera(dy, animate);
	}

	public virtual void ZoomCamera(System.Drawing.Point mousePos, int dy)
	{
		_0023_003DzipBYly6zFKAp().ZoomCamera(mousePos, dy);
	}

	public virtual void ZoomCamera(System.Drawing.Point mousePos, int dy, bool animate)
	{
		_0023_003DzipBYly6zFKAp().ZoomCamera(mousePos, dy, animate);
	}

	public virtual void ZoomCamera(int dy, double zoomSpeed)
	{
		_0023_003DzipBYly6zFKAp().ZoomCamera(dy, zoomSpeed);
	}

	public virtual void ZoomCamera(int dy, double zoomSpeed, bool animate)
	{
		_0023_003DzipBYly6zFKAp().ZoomCamera(dy, zoomSpeed, animate);
	}

	public virtual void PanCamera(System.Drawing.Point from, System.Drawing.Point to)
	{
		_0023_003DzipBYly6zFKAp().PanCamera(from, to);
	}

	public virtual void PanCamera(System.Drawing.Point from, System.Drawing.Point to, bool animate)
	{
		_0023_003DzipBYly6zFKAp().PanCamera(from, to, animate);
	}

	internal virtual void _0023_003Dzk_0024_0024VvG_00245PP4u(int _0023_003DzDI8Y9ks_003D, int _0023_003DzJx6crCU_003D)
	{
		_0023_003DzipBYly6zFKAp().RotateCamera(_0023_003DzDI8Y9ks_003D, _0023_003DzJx6crCU_003D);
	}

	internal virtual void _0023_003Dzk_0024_0024VvG_00245PP4u(int _0023_003DzDI8Y9ks_003D, int _0023_003DzJx6crCU_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		_0023_003DzipBYly6zFKAp().RotateCamera(_0023_003DzDI8Y9ks_003D, _0023_003DzJx6crCU_003D, _0023_003DzBQC8k3F0wJN4);
	}

	internal virtual void _0023_003Dzk_0024_0024VvG_00245PP4u(System.Drawing.Point _0023_003DzFrKrmnmn1LqQ, System.Drawing.Point _0023_003Dzx34Z7rf2lLJX)
	{
		_0023_003DzipBYly6zFKAp().RotateCamera(_0023_003DzFrKrmnmn1LqQ, _0023_003Dzx34Z7rf2lLJX);
	}

	internal virtual void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003Dzs8G0wXc_003D, Vector3D _0023_003DzFcXCpKE_003D)
	{
		_0023_003Dzk_0024_0024VvG_00245PP4u(_0023_003Dzs8G0wXc_003D, _0023_003DzFcXCpKE_003D, AnimateCamera);
	}

	internal virtual void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003Dzs8G0wXc_003D, Vector3D _0023_003DzFcXCpKE_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		_0023_003DzipBYly6zFKAp().RotateCamera(_0023_003Dzs8G0wXc_003D, _0023_003DzFcXCpKE_003D, _0023_003DzBQC8k3F0wJN4);
	}

	internal virtual void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003DzfZZZs54_003D, double _0023_003DzgTFdQ0BoTJUxeE6Vz8CMzjg_003D, bool _0023_003DzaDYRbvgbaa7a)
	{
		_0023_003Dzk_0024_0024VvG_00245PP4u(_0023_003DzfZZZs54_003D, _0023_003DzgTFdQ0BoTJUxeE6Vz8CMzjg_003D, _0023_003DzaDYRbvgbaa7a, AnimateCamera);
	}

	internal virtual void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003DzfZZZs54_003D, double _0023_003DzgTFdQ0BoTJUxeE6Vz8CMzjg_003D, bool _0023_003DzaDYRbvgbaa7a, bool _0023_003DzBQC8k3F0wJN4)
	{
		_0023_003DzipBYly6zFKAp().RotateCamera(_0023_003DzfZZZs54_003D, _0023_003DzgTFdQ0BoTJUxeE6Vz8CMzjg_003D, _0023_003DzaDYRbvgbaa7a, _0023_003DzBQC8k3F0wJN4);
	}

	internal bool _0023_003DzhNfdoTKp7Vp4r6IhAdfMNj6_00248vBW()
	{
		if (ActionMode == actionType.MagnifyingGlass)
		{
			return !MagnifyingGlass._0023_003Dz3J1JrgJesybc();
		}
		return false;
	}

	protected override void OnMouseUp(MouseEventArgs e)
	{
		base.OnMouseUp(e);
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			return;
		}
		if (!_0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW())
		{
			_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: false);
		}
		MouseEventArgs _0023_003Dz1SmHC4c_003D = e;
		_0023_003Dz_feN2jsfs6O0(_0023_003DzipBYly6zFKAp(), ref _0023_003Dz1SmHC4c_003D);
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		bool flag = false;
		ToolBar[] toolBars = viewport.ToolBars;
		foreach (ToolBar toolBar in toolBars)
		{
			if (toolBar.Visible)
			{
				flag |= toolBar._0023_003DzA_0024ihSwbmVYvs(this, e, _0023_003DzuDFPqEJA5SPt1pVAXA_003D_003D);
			}
		}
		if (_0023_003DzceJZi0o_003D)
		{
			EndZoomPanRotate(viewport);
		}
		else
		{
			if (!flag)
			{
				_0023_003Dz0sYWuTi_0024wtyB(_0023_003Dz1SmHC4c_003D);
			}
			if (viewport.Navigation._0023_003DzAC5kXfU_003D(_0023_003DzxIgINtc_003D, _0023_003DzY7PoD1c_003D))
			{
				_0023_003DzoETR2RT_0024IhPS(_0023_003DzSB0yHII_003D: false);
			}
		}
		_0023_003DzxIgINtc_003D._0023_003DzA_0024ihSwbmVYvs(e.Button);
		if (viewport._0023_003Dz4ry2vZefVkxX != null)
		{
			viewport._0023_003Dz4ry2vZefVkxX.OnMouseUp(e, viewport);
		}
		_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.OnMouseUp(e, viewport);
		if (_0023_003DzXGtRhbJXvcvk.X == -1)
		{
			_ = 1;
		}
		else
			_ = _0023_003DzXGtRhbJXvcvk == _0023_003Dztt6EItoclqV3;
		_0023_003DzXGtRhbJXvcvk.X = -1;
		_0023_003DzXGtRhbJXvcvk.Y = -1;
		if (e.Button == MouseButtons.Left)
		{
			_0023_003Dztt6EItoclqV3.X = -1;
			_0023_003Dztt6EItoclqV3.Y = -1;
			_0023_003DzjRmmVH2Hj_0024KY.X = -1;
			_0023_003DzjRmmVH2Hj_0024KY.Y = -1;
		}
		if (!_0023_003Dzz2f3UQo_003D)
		{
			_0023_003DzPHKlzPNfviRt(Rectangle.Empty);
		}
		if (!viewport._0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			_0023_003DzswdnfpGrZ2Nx(_0023_003DzBn2ByFKdwrou);
		}
		if (ActionMode == actionType.MagnifyingGlass && MagnifyingGlass._0023_003Dz3J1JrgJesybc())
		{
			MagnifyingGlass._0023_003DzMhJnK2KPd8YE(this, e.Location);
		}
		_0023_003DztdGp9MI3CH2w = false;
		if (!viewport.IsCameraAnimating() && !_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzF3HKD2trntQC())
		{
			PaintBackBuffer();
			SwapBuffers();
		}
	}

	protected void EndZoomPanRotate(Viewport viewport)
	{
		ActionMode = _0023_003Dz1AtQxyQVwP3J;
		_0023_003DzceJZi0o_003D = false;
		if ((Moving || (_0023_003DzjGvm17_0024DzsnS == actionType.ZoomWindow && _0023_003DzB7HKRwpDgejt == actionType.ZoomWindow)) && !viewport._0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			viewport.SavedViews.Save();
			_0023_003DzswdnfpGrZ2Nx(_0023_003DzBn2ByFKdwrou);
		}
	}

	private void _0023_003DzoETR2RT_0024IhPS(bool _0023_003DzSB0yHII_003D)
	{
		if (_0023_003DzSB0yHII_003D)
		{
			if (!_0023_003Dzb9tWFl97201l)
			{
				_0023_003Dzb9tWFl97201l = true;
				_0023_003Dz9nEsxEntbdvX(_0023_003DzSB0yHII_003D: true);
			}
		}
		else if (_0023_003Dzb9tWFl97201l)
		{
			_0023_003Dzb9tWFl97201l = false;
			_0023_003Dz9nEsxEntbdvX(_0023_003DzSB0yHII_003D: false);
		}
	}

	internal void _0023_003DzqCYquA6AxCkt(int _0023_003DzZnwLfu4_003D)
	{
		_0023_003DzEve6E9qqZPdg = _0023_003DzZnwLfu4_003D;
		PaintBackBuffer();
		SwapBuffers();
		_0023_003DzEve6E9qqZPdg = -1;
	}

	protected bool IsSelectAction()
	{
		if (!IsSelectByPickAction() && !IsSelectByBoxAction())
		{
			return IsSelectByPolygonAction();
		}
		return true;
	}

	protected bool IsSelectByPickAction()
	{
		if (_0023_003DzjGvm17_0024DzsnS != actionType.SelectByPick && _0023_003DzjGvm17_0024DzsnS != actionType.SelectVisibleByPick && _0023_003DzjGvm17_0024DzsnS != actionType.SelectVisibleByPickLabel)
		{
			return _0023_003DzjGvm17_0024DzsnS == actionType.SelectVisibleByPickDynamic;
		}
		return true;
	}

	protected bool IsSelectByBoxAction()
	{
		if (_0023_003DzjGvm17_0024DzsnS != actionType.SelectByBox && _0023_003DzjGvm17_0024DzsnS != actionType.SelectVisibleByBox)
		{
			return _0023_003DzjGvm17_0024DzsnS == actionType.SelectByBoxEnclosed;
		}
		return true;
	}

	protected bool IsSelectByPolygonAction()
	{
		if (_0023_003DzjGvm17_0024DzsnS != actionType.SelectByPolygon && _0023_003DzjGvm17_0024DzsnS != actionType.SelectByPolygonEnclosed)
		{
			return _0023_003DzjGvm17_0024DzsnS == actionType.SelectVisibleByPolygon;
		}
		return true;
	}

	public void SaveView(out Camera saved)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().SaveView(out saved);
	}

	public void RestoreView(Camera saved)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().RestoreView(saved);
	}

	private void _0023_003DzhMz2Xb3oiXP2_0024WuRGg_003D_003D()
	{
		if (_0023_003DzFzzfWzVQfgnR != null)
		{
			return;
		}
		_0023_003DzFzzfWzVQfgnR = new System.Windows.Forms.Timer();
		_0023_003DzFzzfWzVQfgnR.Interval = 300;
		_0023_003DzFzzfWzVQfgnR.Tick += delegate
		{
			_0023_003DzsNY3baF_0024GM7MtcGwGAB4MSE_003D = 0;
			_0023_003DzFzzfWzVQfgnR.Stop();
			_0023_003DztdGp9MI3CH2w = false;
			if (!_0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW())
			{
				_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: false);
			}
			AdjustNearAndFarPlanes();
			_0023_003DzqCYquA6AxCkt(_0023_003DzBn2ByFKdwrou);
			bool flag = false;
			if (ActionMode == actionType.SelectVisibleByPickDynamic && _0023_003Dzo_MNAFBAjuGu == 0)
			{
				System.Drawing.Point point = _0023_003DzhOqjhfgpYUK7();
				MouseEventArgs _0023_003Dz1SmHC4c_003D2 = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);
				bool _0023_003DzprYbenN6veHPuANVgQ_003D_003D = false;
				_0023_003DzDNLc1QbWJ8j9(_0023_003Dz1SmHC4c_003D2, _0023_003DzR8L_0024Yw_00244jJcu(_0023_003DzipBYly6zFKAp(), _0023_003Dz1SmHC4c_003D2), _0023_003DzipBYly6zFKAp(), ref _0023_003DzprYbenN6veHPuANVgQ_003D_003D);
				if (_0023_003DznmpiQBcqK9AE.AddedItems.Count > 0 || _0023_003DznmpiQBcqK9AE.RemovedItems.Count > 0)
				{
					flag = true;
				}
			}
			_0023_003DzipBYly6zFKAp()._0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: false);
			_0023_003DzBhiHJ1K9qQ76(_0023_003DzipBYly6zFKAp(), out var _0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D);
			if (flag || _0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D)
			{
				PaintBackBuffer();
				SwapBuffers();
			}
		};
	}

	private bool _0023_003DzSlNAZVP_0024WkQC()
	{
		if (IsDesignMode())
		{
			return false;
		}
		_0023_003DzFzzfWzVQfgnR.Start();
		return true;
	}

	private void _0023_003DzDY7a5P_0024UUZN_0024O0EnyQ_003D_003D(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzsNY3baF_0024GM7MtcGwGAB4MSE_003D = 0;
		_0023_003DzFzzfWzVQfgnR.Stop();
		_0023_003DztdGp9MI3CH2w = false;
		if (!_0023_003DzjRuzfqAXYPyowTYxv4IPtpr1tAaW())
		{
			_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: false);
		}
		AdjustNearAndFarPlanes();
		_0023_003DzqCYquA6AxCkt(_0023_003DzBn2ByFKdwrou);
		bool flag = false;
		if (ActionMode == actionType.SelectVisibleByPickDynamic && _0023_003Dzo_MNAFBAjuGu == 0)
		{
			System.Drawing.Point point = _0023_003DzhOqjhfgpYUK7();
			MouseEventArgs _0023_003Dz1SmHC4c_003D2 = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);
			bool _0023_003DzprYbenN6veHPuANVgQ_003D_003D = false;
			_0023_003DzDNLc1QbWJ8j9(_0023_003Dz1SmHC4c_003D2, _0023_003DzR8L_0024Yw_00244jJcu(_0023_003DzipBYly6zFKAp(), _0023_003Dz1SmHC4c_003D2), _0023_003DzipBYly6zFKAp(), ref _0023_003DzprYbenN6veHPuANVgQ_003D_003D);
			if (_0023_003DznmpiQBcqK9AE.AddedItems.Count > 0 || _0023_003DznmpiQBcqK9AE.RemovedItems.Count > 0)
			{
				flag = true;
			}
		}
		_0023_003DzipBYly6zFKAp()._0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: false);
		_0023_003DzBhiHJ1K9qQ76(_0023_003DzipBYly6zFKAp(), out var _0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D);
		if (flag || _0023_003Dzc0yNWnI_0024KYHS0MYnGgOLqVg_003D)
		{
			PaintBackBuffer();
			SwapBuffers();
		}
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
		base.OnMouseWheel(e);
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			return;
		}
		if (_0023_003DzsNY3baF_0024GM7MtcGwGAB4MSE_003D++ == 0)
		{
			_0023_003Dzf5NRO7wxeVa07xknUc_l_0024dqNXOfS();
		}
		_ = e.Location;
		MouseEventArgs _0023_003Dz1SmHC4c_003D = e;
		if (!_0023_003Dz_feN2jsfs6O0(_0023_003DzipBYly6zFKAp(), ref _0023_003Dz1SmHC4c_003D))
		{
			return;
		}
		if (!_0023_003DzFzzfWzVQfgnR.Enabled)
		{
			_0023_003DzipBYly6zFKAp()._0023_003Dz_0024J0MwzgL89fc(_0023_003Dz5lra25Q_003D: true);
		}
		else if (_0023_003DzBrC4gBvWiHkA == mouseInputType.Space)
		{
			return;
		}
		if (Moving || (_0023_003Dzz2f3UQo_003D && !IsSelectByPolygonAction()))
		{
			return;
		}
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		_0023_003DztdGp9MI3CH2w = true;
		int num = Math.Sign(_0023_003Dz1SmHC4c_003D.Delta) * 32;
		if (viewport.Zoom.ReverseMouseWheel)
		{
			num = -num;
		}
		if (viewport.Zoom.Enabled)
		{
			switch (viewport.Zoom.ZoomStyle)
			{
			case zoomStyleType.AtCursorLocation:
				ZoomCamera(_0023_003Dz1SmHC4c_003D.Location, num, animate: false);
				break;
			case zoomStyleType.Centered:
				ZoomCamera(num, animate: false);
				break;
			}
		}
		viewport._0023_003Dznw4bFFrQpBts3UlWBA_003D_003D(_0023_003DzNwtRJ3cLTrAy(), _0023_003DzmNZD0Zs_003D, _0023_003DzqJnmoiGKtpts: true);
		_0023_003Dz8jvVhZY_003D = actionType.None;
		_0023_003DzH_ACO1keHrO4();
		viewport.Camera.InvalidateZRange(_0023_003DzGk93_rs_003D: true);
		_0023_003DzSGfimhJkGdqe(_0023_003DzipBYly6zFKAp());
		_0023_003DzFzzfWzVQfgnR.Stop();
		_0023_003DzSlNAZVP_0024WkQC();
	}

	private System.Drawing.Point _0023_003DzhOqjhfgpYUK7()
	{
		return PointToClient(System.Windows.Forms.Control.MousePosition);
	}

	public void AdjustNearAndFarPlanes()
	{
		_0023_003DzipBYly6zFKAp()._0023_003DzbDoB99XYsvlZ_EtZ3w_003D_003D(_0023_003DzyU8zEa9rYhPN(_0023_003DzipBYly6zFKAp()));
	}

	internal List<Point3D> _0023_003DzyU8zEa9rYhPN(Viewport _0023_003DzYzWi5Yw_003D)
	{
		List<Point3D> list = new List<Point3D>(13);
		List<Point3D> list2 = new List<Point3D>(2);
		if (_0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF.X != double.MaxValue)
		{
			list2.Add(new Point3D(_0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF.X - _0023_003Dz6CMmzY6fHGlL._0023_003DzDFTJsrsRDL5Z, _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF.Y - _0023_003Dz6CMmzY6fHGlL._0023_003DzDFTJsrsRDL5Z, _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF.Z - _0023_003Dz6CMmzY6fHGlL._0023_003DzDFTJsrsRDL5Z));
			list2.Add(new Point3D(_0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr.X + _0023_003Dz6CMmzY6fHGlL._0023_003DzDFTJsrsRDL5Z, _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr.Y + _0023_003Dz6CMmzY6fHGlL._0023_003DzDFTJsrsRDL5Z, _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr.Z + _0023_003Dz6CMmzY6fHGlL._0023_003DzDFTJsrsRDL5Z));
		}
		if (TempEntities.Count > 0 && TempEntities._0023_003Dze4TpmVqI26AF != null && TempEntities._0023_003Dze4TpmVqI26AF.X != double.MaxValue)
		{
			list2.Add(TempEntities._0023_003Dze4TpmVqI26AF);
			list2.Add(TempEntities._0023_003DzD4HjvLi8HsVr);
		}
		if (list2.Count > 0)
		{
			Utility.ComputeBoundingBox(list2, out var boxMin, out var boxMax);
			if (_0023_003DzYzWi5Yw_003D._0023_003DzK_00241ezHQJ9Z3c == displayType.Rendered && _0023_003DznKkOfo8_003D.PlanarReflections)
			{
				Plane plane = _0023_003DzrnMI_SiQDx8_0024QFSmZA3zGE6q_QjC4hO9xRf6Hz8_003D();
				Point3D point = plane.Reflect(boxMax);
				_0023_003DzFtbmGKuUZLuHEcWD9w_003D_003D(_0023_003DzYzWi5Yw_003D, boxMin, Vector3D.Dot(plane.AxisZ, plane.Origin + plane.DistanceTo(point) * plane.AxisZ));
			}
			else if (_0023_003DzjC4hA2I_003D.isHardwareAccelerated && _0023_003DzYzWi5Yw_003D._0023_003DzK_00241ezHQJ9Z3c != displayType.Wireframe)
			{
				_0023_003DzFtbmGKuUZLuHEcWD9w_003D_003D(_0023_003DzYzWi5Yw_003D, boxMin, _0023_003DzgpecnOZK_rLDYEjHUA_003D_003D.GetZPos(_0023_003Dz0fqXN00AlqdN, null, boxMin, boxMax, _0023_003DzhxZwygT5_0024eSRWpPtOWHuTPM_003D));
			}
			list.AddRange(Utility.GetBoundingBoxCorners(boxMin, boxMax));
		}
		return list;
	}

	private void _0023_003DzFtbmGKuUZLuHEcWD9w_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, Point3D _0023_003DzoYJjnU0_003D, double _0023_003DzsLHxXyo_003D)
	{
		switch (_0023_003DzLpjRly40lvq1)
		{
		case orientationType.UpAxisZ:
			if (_0023_003DzsLHxXyo_003D < _0023_003DzoYJjnU0_003D.Z)
			{
				_0023_003DzoYJjnU0_003D.Z = _0023_003DzsLHxXyo_003D;
			}
			break;
		case orientationType.UpAxisY:
			if (_0023_003DzsLHxXyo_003D < _0023_003DzoYJjnU0_003D.Y)
			{
				_0023_003DzoYJjnU0_003D.Y = _0023_003DzsLHxXyo_003D;
			}
			break;
		}
	}

	internal void _0023_003DzgES1H_48XRD7GgtPkA_003D_003D()
	{
		if (this is Design design && design.Parents.Count > 1 && design.CurrentSketch != null)
		{
			return;
		}
		if (Document.isBoundingBoxDirty)
		{
			CursorContainer _0023_003DzlwNtVtI_003D = _0023_003DzzT36TNE_003D();
			waitCursorType waitCursorType2 = _0023_003DzCf__tCZh1QRt;
			if ((uint)(waitCursorType2 - 2) <= 1u)
			{
				_0023_003DzFqaEE7IhVORj(cursorType.Wait);
			}
			if (TempEntities._0023_003DzTdK_0024hceWvKq_)
			{
				TempEntities._0023_003DzCJy6o9PkJ45N();
			}
			UpdateBoundingBox();
			waitCursorType2 = _0023_003DzCf__tCZh1QRt;
			if ((uint)(waitCursorType2 - 2) <= 1u)
			{
				_0023_003DzV0Su6Jg_003D(_0023_003DzlwNtVtI_003D);
			}
		}
		if (TempEntities._0023_003DzTdK_0024hceWvKq_)
		{
			TempEntities._0023_003DzCJy6o9PkJ45N();
			for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
			{
				_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i].AdjustNearAndFarPlanes();
			}
		}
		_0023_003DzTF7LZ3rWxy08JGdaZb8S2gU_003D();
	}

	private bool _0023_003DzhZAE_J_0024t3x5jjlkwINYgd8Q_003D()
	{
		return true;
	}

	private void _0023_003Dzpu1Uod0NVVSG8RKUlA_003D_003D()
	{
		_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Clear();
		InitializeViewports();
		_0023_003Dz3tGL3rg_003D();
	}

	internal Viewport _0023_003DzipBYly6zFKAp()
	{
		return _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[_0023_003DzO9NcOvRo2Yyn];
	}

	internal void SetViewportsForDesignTime(DesignTimeFuncHandler _0023_003DzIooYK_0024E_003D)
	{
		if (_0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D == null)
		{
			_0023_003Dzo7kPycGLz2cPFDrQoU72cLmCnRIJ(_0023_003DzIooYK_0024E_003D);
		}
	}

	internal void RestoreViewportsForDesignTime(DesignTimeFuncHandler _0023_003DzIooYK_0024E_003D)
	{
		if (_0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE == null)
		{
			_0023_003DzFcKEAJr3cm3njfwPP8L8N20cem1q(_0023_003DzIooYK_0024E_003D);
		}
	}

	private void _0023_003Dzo7kPycGLz2cPFDrQoU72cLmCnRIJ(DesignTimeFuncHandler _0023_003DzsLHxXyo_003D)
	{
		DesignTimeFuncHandler designTimeFuncHandler = _0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D;
		DesignTimeFuncHandler designTimeFuncHandler2;
		do
		{
			designTimeFuncHandler2 = designTimeFuncHandler;
			DesignTimeFuncHandler value = (DesignTimeFuncHandler)Delegate.Combine(designTimeFuncHandler2, _0023_003DzsLHxXyo_003D);
			designTimeFuncHandler = Interlocked.CompareExchange(ref _0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D, value, designTimeFuncHandler2);
		}
		while ((object)designTimeFuncHandler != designTimeFuncHandler2);
	}

	private void _0023_003Dz8SjdvUGnCq1JJLRExxZh5m6YYAvx(DesignTimeFuncHandler _0023_003DzsLHxXyo_003D)
	{
		DesignTimeFuncHandler designTimeFuncHandler = _0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D;
		DesignTimeFuncHandler designTimeFuncHandler2;
		do
		{
			designTimeFuncHandler2 = designTimeFuncHandler;
			DesignTimeFuncHandler value = (DesignTimeFuncHandler)Delegate.Remove(designTimeFuncHandler2, _0023_003DzsLHxXyo_003D);
			designTimeFuncHandler = Interlocked.CompareExchange(ref _0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D, value, designTimeFuncHandler2);
		}
		while ((object)designTimeFuncHandler != designTimeFuncHandler2);
	}

	private void _0023_003DzFcKEAJr3cm3njfwPP8L8N20cem1q(DesignTimeFuncHandler _0023_003DzsLHxXyo_003D)
	{
		DesignTimeFuncHandler designTimeFuncHandler = _0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE;
		DesignTimeFuncHandler designTimeFuncHandler2;
		do
		{
			designTimeFuncHandler2 = designTimeFuncHandler;
			DesignTimeFuncHandler value = (DesignTimeFuncHandler)Delegate.Combine(designTimeFuncHandler2, _0023_003DzsLHxXyo_003D);
			designTimeFuncHandler = Interlocked.CompareExchange(ref _0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE, value, designTimeFuncHandler2);
		}
		while ((object)designTimeFuncHandler != designTimeFuncHandler2);
	}

	private void _0023_003DzrwdVA0xcGaWjWBQ9io6_7TAdWGgN(DesignTimeFuncHandler _0023_003DzsLHxXyo_003D)
	{
		DesignTimeFuncHandler designTimeFuncHandler = _0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE;
		DesignTimeFuncHandler designTimeFuncHandler2;
		do
		{
			designTimeFuncHandler2 = designTimeFuncHandler;
			DesignTimeFuncHandler value = (DesignTimeFuncHandler)Delegate.Remove(designTimeFuncHandler2, _0023_003DzsLHxXyo_003D);
			designTimeFuncHandler = Interlocked.CompareExchange(ref _0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE, value, designTimeFuncHandler2);
		}
		while ((object)designTimeFuncHandler != designTimeFuncHandler2);
	}

	private void _0023_003Dzz0rWAF7BGpiU6uGk8YVBKlX_0024NTqIywNUWBAElgY_003D(bool _0023_003Dz5lra25Q_003D)
	{
		_0023_003Dz27ftPOA_003D(_0023_003Dz5lra25Q_003D);
	}

	void IWorkspaceInternal.SuspendUpdate(bool _0023_003Dz5lra25Q_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zz0rWAF7BGpiU6uGk8YVBKlX$NTqIywNUWBAElgY=
		this._0023_003Dzz0rWAF7BGpiU6uGk8YVBKlX_0024NTqIywNUWBAElgY_003D(_0023_003Dz5lra25Q_003D);
	}

	internal void _0023_003Dz27ftPOA_003D(bool _0023_003Dz5lra25Q_003D)
	{
		Logger.Instance.Warn(InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595717), _0023_003DzE7xpH20_003D, _0023_003Dz5lra25Q_003D), null);
		_0023_003DzE7xpH20_003D = _0023_003Dz5lra25Q_003D;
	}

	private void _0023_003DzvsdPLLWREN1kwrbaZBu2akmjo00Ww8iL7atpUvM_003D()
	{
		_0023_003Dz3tGL3rg_003D();
	}

	void IWorkspaceInternal.UpdateWorkspace()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zvsdPLLWREN1kwrbaZBu2akmjo00Ww8iL7atpUvM=
		this._0023_003DzvsdPLLWREN1kwrbaZBu2akmjo00Ww8iL7atpUvM_003D();
	}

	internal void _0023_003Dz3tGL3rg_003D()
	{
		if (!_0023_003DzE7xpH20_003D && _0023_003DzmNZD0Zs_003D != null && IsDesignMode())
		{
			UpdateDesignModeScene();
			if (_0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D != null)
			{
				_0023_003Dzx8g4aNZni_OPlg2SVbOdfYI_003D();
			}
			if (_0023_003DzBn2ByFKdwrou >= 0 && _0023_003DzBn2ByFKdwrou < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count)
			{
				AdjustNearAndFarPlanes();
			}
			if (_0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE != null)
			{
				_0023_003Dzrqykp9YpDNNtneQxzH0VRijz5hDE();
			}
			Invalidate();
		}
	}

	private protected void _0023_003DzTF7LZ3rWxy08JGdaZb8S2gU_003D()
	{
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0 || _0023_003DzmNZD0Zs_003D == null || !_0023_003Dz8ok_dRe4bjRDcVb_0024afNnmr8_003D || !_0023_003DzkH1pV7iXvEg4SKtLcQ_003D_003D() || !_0023_003DzaIkiwmUCZEncrNAqSQ_003D_003D())
		{
			return;
		}
		IList<Entity> list = _0023_003DzOWfUZLjOSimJ();
		if (list.Count <= 0)
		{
			return;
		}
		try
		{
			_0023_003DzgpecnOZK_rLDYEjHUA_003D_003D._0023_003DzshPEPAc_003D(RendererVersion, list, _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF, _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr, this);
			_0023_003Dz8ok_dRe4bjRDcVb_0024afNnmr8_003D = false;
			_0023_003DzcqwAHLWtCi4L();
		}
		catch (Exception ex)
		{
			_0023_003Dz4qdnHLU4p4Ip(ex.ToString());
			if (_0023_003DzDwjKS14_003D != null)
			{
				_0023_003DzDwjKS14_003D(this, new ErrorOccurredEventArgs(ex.ToString(), ex.StackTrace, _0023_003DzmNZD0Zs_003D.GraphicsDataWithError));
			}
		}
	}

	private protected void _0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D()
	{
		if (_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595829));
		}
	}

	internal static BoundingBoxSettings _0023_003DzusLvEi5hoe9_0024()
	{
		return new BoundingBoxSettings();
	}

	internal bool ShouldSerializeButtonStyle()
	{
		return _0023_003DzMC9Ycx3kKvGA._0023_003Dz4XAvJ5aCRLKs();
	}

	internal void ResetButtonStyle()
	{
		ButtonStyle = new ButtonSettings();
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003Dzq0o8PI7V46nBBc7u3A_003D_003D(null);
		}
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeShowCurveDirection()
	{
		return _0023_003DzTmVXuIf7B_f_;
	}

	private void ResetShowCurveDirection()
	{
		_0023_003DzTmVXuIf7B_f_ = false;
		_0023_003Dz3tGL3rg_003D();
	}

	private void _0023_003DzBnjb2sFOreKL()
	{
		if (_0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzmNZD0Zs_003D.ProcessLightAttributes(shadowPass: false, reflection: false);
		}
		_0023_003Dz3tGL3rg_003D();
	}

	internal static LightSettings _0023_003Dz7NpJnabG16hc()
	{
		return new LightSettings(new Vector3D(1.0, 1.0, -1.0), Color.FromArgb(204, 204, 204), Color.FromArgb(63, 63, 63), stationary: true, active: true, yieldShadow: true);
	}

	internal static LightSettings _0023_003Dz__OrNlvkiVf_0024()
	{
		return new LightSettings(new Vector3D(-1.0, 0.5, -1.0), Color.FromArgb(63, 63, 63), Color.Black, stationary: true, active: true, yieldShadow: false);
	}

	internal static LightSettings _0023_003DzeVWRUBuT_00244su()
	{
		return new LightSettings(new Vector3D(-1.0, 0.5, 1.0), Color.FromArgb(63, 63, 63), Color.Black, stationary: true, active: true, yieldShadow: false);
	}

	internal static LightSettings _0023_003DzGAvKLzvtgdSE()
	{
		return new LightSettings(new Vector3D(1.0, 1.0, 1.0), Color.FromArgb(79, 79, 79), Color.Black, stationary: true, active: true, yieldShadow: false);
	}

	internal static LightSettings _0023_003DzvlMrltGUGwqD()
	{
		return new LightSettings(Vector3D.AxisY, Color.White, Color.White, stationary: true, active: false, yieldShadow: false);
	}

	internal static LightSettings _0023_003DzxLBZtGeVsnzR()
	{
		return new LightSettings(Vector3D.AxisY, Color.White, Color.White, stationary: true, active: false, yieldShadow: false);
	}

	internal static LightSettings _0023_003Dzy9a2gvNR_0024L5N()
	{
		return new LightSettings(Vector3D.AxisY, Color.White, Color.White, stationary: true, active: false, yieldShadow: false);
	}

	internal static LightSettings _0023_003DzzcdYAd1MAULe()
	{
		return new LightSettings(Vector3D.AxisY, Color.White, Color.White, stationary: true, active: false, yieldShadow: false);
	}

	internal static double _0023_003Dz5FN_jliv6I7mvmLmSUzqQ98Ojt_00240()
	{
		return 0.0;
	}

	internal static double _0023_003Dz_0024qFq48Dx8t9MkqcygP0YSu4_003D()
	{
		return 0.2;
	}

	private void _0023_003Dz_NzWuEbp1_u99cihSQ_003D_003D(ClippingPlaneBase _0023_003DzbkaKjOWVC6m5PJb_bBdAmX8_003D)
	{
		_0023_003Dz3tGL3rg_003D();
		ClippingPlane clippingPlane = (ClippingPlane)_0023_003DzbkaKjOWVC6m5PJb_bBdAmX8_003D;
		clippingPlane.workspace = this;
		clippingPlane.CheckAndFixDefaultLayerName();
		if (clippingPlane.CappingMode != ClippingPlane.cappingType.None)
		{
			clippingPlane.BuildClippingPlaneMesh(clippingPlane.CappingColor);
		}
	}

	internal bool _0023_003DzkH1pV7iXvEg4SKtLcQ_003D_003D()
	{
		for (int i = 0; i < _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count; i++)
		{
			if (_0023_003Dz0fTtstT4IqGh(_0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[i]._0023_003DzK_00241ezHQJ9Z3c)._0023_003DzLipASLNgxA13 != shadowType.None)
			{
				return true;
			}
		}
		return false;
	}

	internal void _0023_003DzgngvrWJq3A3YrTL3_trCsCU_003D()
	{
		if (_0023_003DzJQOMinrXgHWjlFmaGZBDrwI_003D())
		{
			ProcessSemiTransparent();
		}
		if (_0023_003DzAOWgvRdHrrw0vb21wP3Hw7o_003D())
		{
			HiddenLinesView.PreProcessSilhouettesForDraw(Entities.baseList, new PreProcessSilhouettesParams
			{
				Parents = null,
				Blocks = Blocks
			});
		}
	}

	internal void _0023_003DzA8RsYfRdfWs4a5OLJCwF9X66ETqDRbikkg_003D_003D(displayType _0023_003DzPjs0xKg_003D)
	{
		if (!_0023_003DzJQOMinrXgHWjlFmaGZBDrwI_003D() && AccurateTransparency && _0023_003DzNLhrDmobdurq(_0023_003DzPjs0xKg_003D))
		{
			ProcessSemiTransparent();
		}
		if (!_0023_003DzAOWgvRdHrrw0vb21wP3Hw7o_003D() && _0023_003DzPjs0xKg_003D == displayType.HiddenLines)
		{
			HiddenLinesView.PreProcessSilhouettesForDraw(Entities, new PreProcessSilhouettesParams
			{
				Parents = null,
				Blocks = Blocks
			});
		}
	}

	private bool _0023_003DzNLhrDmobdurq(displayType _0023_003DzmrtMJ48_003D)
	{
		return _0023_003DzmrtMJ48_003D switch
		{
			displayType.HiddenLines => _0023_003Dzddm_0024rF6S_0024y27.ColorMethod != hiddenLinesColorMethodType.SingleColor, 
			displayType.Wireframe => false, 
			_ => true, 
		};
	}

	private bool _0023_003DzAOWgvRdHrrw0vb21wP3Hw7o_003D()
	{
		foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
		{
			if (item._0023_003DzK_00241ezHQJ9Z3c == displayType.HiddenLines)
			{
				return true;
			}
		}
		return false;
	}

	private bool _0023_003DzJQOMinrXgHWjlFmaGZBDrwI_003D()
	{
		if (AccurateTransparency)
		{
			foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
			{
				if (_0023_003DzNLhrDmobdurq(item.DisplayMode))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool ShouldSerializeEnableAmbientOcclusion()
	{
		return EnableAmbientOcclusion != AmbientOcclusionSettings._0023_003DzlAUaJg4N2d6h();
	}

	private void ResetEnableAmbientOcclusion()
	{
		EnableAmbientOcclusion = AmbientOcclusionSettings._0023_003DzlAUaJg4N2d6h();
	}

	private bool ShouldSerializeSelectionColor()
	{
		return Selection.Color != SelectionSettings._0023_003Dz3S5baIME1gm5();
	}

	private void ResetSelectionColor()
	{
		Selection.Color = SelectionSettings._0023_003Dz3S5baIME1gm5();
	}

	private bool ShouldSerializeSelectionColorDynamic()
	{
		return Selection.ColorDynamic != SelectionSettings._0023_003DzFnGxyKAz69Vq();
	}

	internal void ResetSelectionColorDynamic()
	{
		Selection.ColorDynamic = SelectionSettings._0023_003DzFnGxyKAz69Vq();
	}

	private bool ShouldSerializeSelectionLineWeightScaleFactor()
	{
		return Selection.LineWeightScaleFactor != SelectionSettings._0023_003Dzv8BykSbeEVpnPb7DBw_003D_003D();
	}

	internal void ResetSelectionLineWeightScaleFactor()
	{
		Selection.LineWeightScaleFactor = SelectionSettings._0023_003Dzv8BykSbeEVpnPb7DBw_003D_003D();
	}

	internal static DisplayModeSettings _0023_003DzE86ntJk_bvntbeCPgA_003D_003D()
	{
		return new DisplayModeSettings();
	}

	internal static DisplayModeSettingsShaded _0023_003DzSWtY5yxqfuBh8s2w07KB3SI_003D()
	{
		return new DisplayModeSettingsShaded();
	}

	internal static DisplayModeSettingsFlat _0023_003DzNmcCUKQZrt_0024ZBKfmbQ_003D_003D()
	{
		return new DisplayModeSettingsFlat();
	}

	internal static DisplayModeSettingsRendered _0023_003DztuL3fSvrLHESbtlEgQ_003D_003D()
	{
		return new DisplayModeSettingsRendered();
	}

	private bool ShouldSerializeShowFps()
	{
		return _0023_003DzMdZJFmWObL0F;
	}

	internal void ResetShowFps()
	{
		_0023_003DzMdZJFmWObL0F = false;
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeWaitCursorMode()
	{
		return _0023_003DzCf__tCZh1QRt != waitCursorType.RegenAndBoundingBox;
	}

	internal void ResetWaitCursorMode()
	{
		_0023_003DzCf__tCZh1QRt = waitCursorType.RegenAndBoundingBox;
	}

	private bool ShouldSerializeAskForDirect3DLevel9_3()
	{
		return _0023_003DzjC4hA2I_003D.askForLevel9_3;
	}

	internal void ResetAskForDirect3DLevel9_3()
	{
		_0023_003DzjC4hA2I_003D.askForLevel9_3 = false;
	}

	private bool ShouldSerializeAskForAntiAliasing()
	{
		return _0023_003DzjC4hA2I_003D.askForAntiAliasing;
	}

	internal void ResetAskForAntiAliasing()
	{
		_0023_003DzjC4hA2I_003D.askForAntiAliasing = false;
	}

	private bool ShouldSerializeAntiAliasing()
	{
		return AntiAliasing;
	}

	internal void ResetAntiAliasing()
	{
		AntiAliasing = false;
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeAntiAliasingSamples()
	{
		return AntiAliasingSamples != antialiasingSamplesNumberType.x4;
	}

	private void ResetAntiAliasingSamples()
	{
		AntiAliasingSamples = antialiasingSamplesNumberType.x4;
	}

	internal static int _0023_003Dzg5Xj0dn9LsZAo_0024aLAJV5nOo_003D()
	{
		return 10;
	}

	internal static int _0023_003Dzzyw4qcFvt7djMFj7Aw_003D_003D()
	{
		return 1;
	}

	private bool ShouldSerializeMaxPatternRepetitions()
	{
		return MaxPatternRepetitions != 1000;
	}

	internal void ResetMaxPatternRepetitions()
	{
		MaxPatternRepetitions = 1000;
	}

	private bool ShouldSerializeMaxHatchPatternLines()
	{
		return MaxHatchPatternLines != 1000000;
	}

	internal void ResetMaxHatchPatternLines()
	{
		MaxPatternRepetitions = 1000000;
	}

	private bool ShouldSerializeIsInFrustumMode()
	{
		return _0023_003Dzf5Odjtzb03wW_0024l1D0A_003D_003D != Camera.perspectiveFitType.Quick;
	}

	internal void ResetIsInFrustumMode()
	{
		_0023_003Dzf5Odjtzb03wW_0024l1D0A_003D_003D = Camera.perspectiveFitType.Quick;
	}

	internal static HiddenLinesSettings _0023_003Dz6pySpQ7YNYytZ7KDm_0024lng_s_003D()
	{
		return new HiddenLinesSettings();
	}

	internal virtual void _0023_003DzuDFPqEJA5SPt1pVAXA_003D_003D(object _0023_003DzxwGby4M_003D, HandledEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003Dz1SmHC4c_003D.Handled)
		{
			ActionMode = _0023_003DzPWir8SCUhlRqvNwZxA_003D_003D;
			return;
		}
		_0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D = true;
		bool flag = false;
		actionType actionMode = actionType.None;
		ToolBarButton toolBarButton = (ToolBarButton)_0023_003DzxwGby4M_003D;
		if (toolBarButton is ZoomWindowToolBarButton)
		{
			if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
			{
				actionMode = actionType.ZoomWindow;
			}
			flag = true;
		}
		else if (toolBarButton is MagnifyingGlassToolBarButton)
		{
			if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
			{
				actionMode = actionType.MagnifyingGlass;
			}
			flag = true;
		}
		else if (toolBarButton is ZoomToolBarButton)
		{
			if (_0023_003DzipBYly6zFKAp().Zoom.Enabled)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					actionMode = actionType.Zoom;
				}
				flag = true;
			}
		}
		else if (toolBarButton is PanToolBarButton)
		{
			if (_0023_003DzipBYly6zFKAp().Pan.Enabled)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					actionMode = actionType.Pan;
				}
				flag = true;
			}
		}
		else if (toolBarButton is RotateToolBarButton)
		{
			if (_0023_003DzipBYly6zFKAp().Rotate.Enabled)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					actionMode = actionType.Rotate;
				}
				flag = true;
			}
		}
		else if (toolBarButton is ZoomFitToolBarButton)
		{
			if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
			{
				ZoomFit();
				_0023_003DzEve6E9qqZPdg = _0023_003DzBn2ByFKdwrou;
				toolBarButton._0023_003Dz4iBK5_0024N3N5g7._0023_003Dz9ynrbmYOHj_0024Y(this);
			}
		}
		else if (toolBarButton is HomeToolBarButton)
		{
			if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
			{
				bool _0023_003DzBQC8k3F0wJN = ((_0023_003DzipBYly6zFKAp().ViewCubeIcon == null) ? AnimateCamera : _0023_003DzipBYly6zFKAp().ViewCubeIcon.AnimateCamera);
				_0023_003DznL1WlsQ9pGcL(_0023_003DzWrfLNCo_003D: true, _0023_003DzBQC8k3F0wJN);
				_0023_003DzEve6E9qqZPdg = _0023_003DzBn2ByFKdwrou;
				toolBarButton._0023_003Dz4iBK5_0024N3N5g7._0023_003Dz9ynrbmYOHj_0024Y(this);
			}
		}
		else if (toolBarButton is ShareToolBarButton && toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
		{
			MessageBox.Show(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596118), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593964));
			toolBarButton._0023_003Dz4iBK5_0024N3N5g7._0023_003Dz9ynrbmYOHj_0024Y(this);
		}
		if (flag)
		{
			if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
			{
				ActionMode = actionMode;
			}
			else
			{
				toolBarButton._0023_003Dz4iBK5_0024N3N5g7._0023_003Dz9ynrbmYOHj_0024Y(this);
			}
		}
		_0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D = false;
	}

	private protected virtual void _0023_003DznL1WlsQ9pGcL(bool _0023_003DzWrfLNCo_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		SetView(viewType.Trimetric, _0023_003DzWrfLNCo_003D, _0023_003DzBQC8k3F0wJN4);
	}

	private bool ShouldSerializeProgressBar()
	{
		return _0023_003DzD157GIliOpnX._0023_003Dz4XAvJ5aCRLKs();
	}

	private void ResetProgressBar()
	{
		_0023_003DzD157GIliOpnX = new ProgressBar();
		_0023_003DzD157GIliOpnX.ParentWorkspace = this;
		_0023_003Dz3tGL3rg_003D();
	}

	internal static ToolBarButton _0023_003DzOu2KQJ1A0olqF8wpuQ_003D_003D()
	{
		return new CancelToolBarButton();
	}

	private bool _0023_003DzJYTPdk81Y_0024Rv()
	{
		if (!(ProgressBarCancelButton == null) && ProgressBarCancelButton is CancelToolBarButton)
		{
			return ((CancelToolBarButton)ProgressBarCancelButton)._0023_003Dz4XAvJ5aCRLKs();
		}
		return true;
	}

	private void _0023_003Dztmkc8rJLT_0024f9()
	{
		ProgressBarCancelButton = _0023_003DzOu2KQJ1A0olqF8wpuQ_003D_003D();
	}

	internal SimulationTimeLine _0023_003Dz5rO_0024Fj2CJdsU()
	{
		return _0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D;
	}

	internal void _0023_003DzvuwkOvabY479(SimulationTimeLine _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D = _0023_003DzsLHxXyo_003D;
		if (_0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D == null)
		{
			_0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D = new SimulationTimeLine();
		}
		_0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D.ParentWorkspace = (Manufacture)this;
	}

	private bool _0023_003DzUyviuAIIINNBbBAUYw_003D_003D()
	{
		return _0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D._0023_003Dz4XAvJ5aCRLKs();
	}

	private void _0023_003DznPaanYS9b9bg()
	{
		_0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D = new SimulationTimeLine();
		_0023_003DzjMxtIa5GEhu_0024qI_qn9LFdRg_003D.ParentWorkspace = (Manufacture)this;
		_0023_003Dz3tGL3rg_003D();
	}

	internal static RegistryKey _0023_003DzJwGf4haT3p2NWLkY7Q_003D_003D(RegistryKey _0023_003DzK4yAfCI_003D, bool _0023_003Dza0ZnxLk_003D)
	{
		try
		{
			RegistryKey registryKey;
			if (_0023_003Dza0ZnxLk_003D)
			{
				registryKey = _0023_003DzK4yAfCI_003D.CreateSubKey(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595983));
			}
			else
			{
				registryKey = _0023_003DzK4yAfCI_003D.OpenSubKey(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595991));
				if (registryKey == null)
				{
					registryKey = _0023_003DzK4yAfCI_003D.OpenSubKey(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595983));
				}
			}
			return registryKey;
		}
		catch (Exception)
		{
			return null;
		}
	}

	internal static string _0023_003DzW0w398EiQT8n(string _0023_003DzsLHxXyo_003D, Version _0023_003DzhdGUwPM_003D)
	{
		using RegistryKey registryKey = _0023_003DzJwGf4haT3p2NWLkY7Q_003D_003D(Registry.LocalMachine, _0023_003Dza0ZnxLk_003D: false);
		try
		{
			return (string)registryKey.GetValue(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622780), _0023_003DzsLHxXyo_003D, _0023_003DzhdGUwPM_003D.Major));
		}
		catch (Exception)
		{
			return null;
		}
	}

	internal static string _0023_003DzpM3qWoBymIm4(Version _0023_003DzhdGUwPM_003D)
	{
		if (string.IsNullOrEmpty(_0023_003DzQh7EGBSrMCoK))
		{
			_0023_003DzQh7EGBSrMCoK = _0023_003DzW0w398EiQT8n(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596019), _0023_003DzhdGUwPM_003D);
		}
		return _0023_003DzQh7EGBSrMCoK;
	}

	internal static string _0023_003Dz3z2w2knztBs0(Version _0023_003DzhdGUwPM_003D)
	{
		if (string.IsNullOrEmpty(_0023_003DzmUn4ilUi_0024CDZqOJaQQ_003D_003D))
		{
			_0023_003DzmUn4ilUi_0024CDZqOJaQQ_003D_003D = _0023_003DzW0w398EiQT8n(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596062), _0023_003DzhdGUwPM_003D);
		}
		return _0023_003DzmUn4ilUi_0024CDZqOJaQQ_003D_003D;
	}

	private void _0023_003DzBUFJRkmN2AUU(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzbPk6_2GEpYfxYRV9RPYuviU_003D(_0023_003DzCBM7XJK4_5H_0024);
	}

	private void _0023_003DzbPk6_2GEpYfxYRV9RPYuviU_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzmNZD0Zs_003D.ProcessLightAttributes(shadowPass: false, _0023_003DzCBM7XJK4_5H_0024.PlanarReflections);
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetupPolygonOffset(enable: true);
		_0023_003DzmNZD0Zs_003D.EnableShadowMap(0);
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.ComputeShaderShadowPasses(out var nPasses, out var lightsWithShadow);
		_0023_003DzCBM7XJK4_5H_0024.ShaderParams.FirstPass = true;
		_0023_003DzCBM7XJK4_5H_0024.ShaderParams.NumberOfPasses = nPasses;
		bool environmentMapping = _0023_003DznKkOfo8_003D.EnvironmentMapping;
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		Dictionary<shaderType, IShaderTechnique> shaders = (_0023_003DzCBM7XJK4_5H_0024.PlanarReflections ? viewport._0023_003DzMwZKPw4WUv_75BW0TQ_003D_003D() : StandardShaders);
		for (int i = 0; i < nPasses; i++)
		{
			if (CurrentTransformation != null)
			{
				_0023_003DzCBM7XJK4_5H_0024.ShaderParams.BlockRefTransform = CurrentTransformation;
			}
			_0023_003DzmNZD0Zs_003D.PrepareShadersForShadowPass(i, lightsWithShadow, shaders, _0023_003DzCBM7XJK4_5H_0024.ShaderParams);
			_0023_003DztyHACw9KoliV(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzyeguIwq0Zzv1: false);
			_0023_003DzCBM7XJK4_5H_0024.ShaderParams.FirstPass = false;
			_0023_003DznKkOfo8_003D.EnvironmentMapping = false;
		}
		_0023_003DznKkOfo8_003D.EnvironmentMapping = environmentMapping;
		ShadowMapData.DisableBlending(_0023_003DzCBM7XJK4_5H_0024.RenderContext);
		_0023_003DzHV9DvDwqZYGs(_0023_003DzCBM7XJK4_5H_0024.RenderContext);
	}

	private void _0023_003DzHV9DvDwqZYGs(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003DzmNZD0Zs_003D.DisableShadowMap();
		for (int i = 0; i < _0023_003DzmNZD0Zs_003D.ActiveLights.Length; i++)
		{
			_0023_003DzmNZD0Zs_003D.SetLightStatus(i, _0023_003DzmNZD0Zs_003D.ActiveLights[i].Active);
		}
		_0023_003DzmNZD0Zs_003D.SetupPolygonOffset(enable: true);
		_0023_003DzmNZD0Zs_003D.CloseTexture(force: true);
	}

	private bool _0023_003DzQthAg2kOXptfNjbNhQ_003D_003D()
	{
		if (_0023_003DzmNZD0Zs_003D.SupportShadows)
		{
			return _0023_003DznKkOfo8_003D.ShadowMode == shadowType.Realistic;
		}
		return false;
	}

	private void _0023_003DzADgrV_9c30Dj(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		bool initHQR = false;
		_0023_003DzmNZD0Zs_003D.ResizeShadowMaps(base.Size, _0023_003DznKkOfo8_003D.RealisticShadowQuality, ref initHQR);
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		_0023_003Dz89cPk57rASTGmdmTnA_003D_003D(viewport, _0023_003DzPHqp5dQ_003D: false, RectangleF.Empty, CameraEyePosType.Center, _0023_003Dzk7pNhlbdSzPJ: true);
		if (_0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D.ColorMethod == backfaceColorMethodType.Cull)
		{
			_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceFront_PolygonOffset_1_1);
		}
		else
		{
			_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1);
		}
		Utility.GetBoundingBoxTransformed(null, _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF, _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr, out var boxMin, out var boxMax);
		RenderParams _0023_003DzrFXPIITH9q = new RenderParams(viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks, _0023_003DzCBM7XJK4_5H_0024.ShaderParams)
		{
			LineWeightFactor = 0f,
			SelectionLineWeightScaleFactor = 1f,
			Attributes = new GfxAttributesRendered(Layers),
			ParentSelected = false,
			SelectionStatus = selectionStatusType.Permanent,
			PlanarReflections = false,
			shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers
		};
		DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzCBM7XJK4_5H_0024.Entities, _0023_003DzrFXPIITH9q, _0023_003DzCBM7XJK4_5H_0024.Simplify);
		drawEntitiesParams.DrawParams.ForceGray = false;
		drawEntitiesParams.layers = Layers;
		drawEntitiesParams.Blocks = _0023_003DzCBM7XJK4_5H_0024.Blocks;
		drawEntitiesParams.isProgressiveDrawing = _0023_003DzCBM7XJK4_5H_0024.isProgressiveDrawing;
		drawEntitiesParams.shouldUseSeparateBuffers = _0023_003DzCBM7XJK4_5H_0024.shouldUseSeparateBuffers;
		drawEntitiesParams.gfxShadowParams = new ShadowMapData.GfxShadowParams
		{
			entMin = boxMin,
			entMax = boxMax,
			activeLights = _0023_003DzmNZD0Zs_003D.ActiveLights,
			renderContext = _0023_003DzmNZD0Zs_003D,
			camera = viewport.Camera,
			viewFrame = viewport.GetViewFrame()
		};
		drawEntitiesParams.animating = _0023_003DzyobtGSd5_zcs();
		drawEntitiesParams.defaultMaterial = _0023_003Dzxpbv4lQ_003D;
		drawEntitiesParams.boundingBox = _0023_003DzK3OaHhra7VrS;
		_0023_003DzFyDtgJf2CBf4(drawEntitiesParams, _0023_003DzPEEjwoPxhT6e(viewport));
		_0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
	}

	internal bool _0023_003DzF0I4o4imRuCH(int _0023_003DzZnwLfu4_003D, int _0023_003Dz62_cyiA_003D, bool _0023_003Dz92qz144_P1FU, DrawEntitiesParams _0023_003Dz9I9gxp1ufyw2)
	{
		return _0023_003DzmNZD0Zs_003D.CreateShadowMap(_0023_003Dz62_cyiA_003D, _0023_003Dz92qz144_P1FU, _0023_003Dz9I9gxp1ufyw2.gfxShadowParams, _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, _0023_003DzmNZD0Zs_003D.ActiveLights, delegate(PlaneEquation[] _0023_003DzD7B0muwE6OtQ, object _0023_003DzqkmKMstXA76V)
		{
			DrawForShadowMapParams drawForShadowMapParams = (DrawForShadowMapParams)_0023_003DzqkmKMstXA76V;
			_0023_003DzXS86eTnj2Efz(drawForShadowMapParams.computeEntitiesVisibilityParams, new FrustumParams(_0023_003DzD7B0muwE6OtQ, this, drawForShadowMapParams.drawShadowParams.Blocks), drawForShadowMapParams.drawShadowParams.simplify, drawForShadowMapParams.drawShadowParams.isProgressiveDrawing);
			DrawEntitiesParams drawShadowParams = drawForShadowMapParams.drawShadowParams;
			drawShadowParams.DrawParams.Attributes = new GfxAttributesRendered(Layers);
			drawShadowParams.DrawParams.Parents = new Stack<BlockReference>();
			if (drawShadowParams.DrawParams.Transformation != null)
			{
				_0023_003DzmNZD0Zs_003D.MultMatrixModelView(drawShadowParams.DrawParams.Transformation);
			}
			return _0023_003DzqycL4xalHFGitSlY6XcpAvGGtqX5(drawShadowParams);
		}, new DrawForShadowMapParams
		{
			computeEntitiesVisibilityParams = _0023_003DzdWWqz40ROLb5Pp383A_003D_003D(_0023_003DzZnwLfu4_003D, _0023_003Dz9I9gxp1ufyw2.entList),
			drawShadowParams = _0023_003Dz9I9gxp1ufyw2
		});
	}

	internal bool _0023_003DzFyDtgJf2CBf4(DrawEntitiesParams _0023_003Dz9I9gxp1ufyw2, int _0023_003DzZnwLfu4_003D)
	{
		bool _0023_003Dz92qz144_P1FU = true;
		Viewport viewport = _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[_0023_003DzZnwLfu4_003D];
		_0023_003DzmNZD0Zs_003D.InitShadowMapData(viewport.Camera, null, viewport.GetViewFrame());
		if (!RenderContextBase.MultipleLightsWithShadows)
		{
			int firstShadowLight = _0023_003Dz9I9gxp1ufyw2.GetFirstShadowLight();
			if (firstShadowLight >= 0)
			{
				return _0023_003DzF0I4o4imRuCH(_0023_003DzZnwLfu4_003D, firstShadowLight, _0023_003Dz92qz144_P1FU: true, _0023_003Dz9I9gxp1ufyw2);
			}
		}
		else
		{
			for (int i = 0; i < _0023_003Dz9I9gxp1ufyw2.gfxShadowParams.activeLights.Length; i++)
			{
				if (_0023_003Dz9I9gxp1ufyw2.gfxShadowParams.activeLights[i].YieldShadow)
				{
					if (!_0023_003DzF0I4o4imRuCH(_0023_003DzZnwLfu4_003D, i, _0023_003Dz92qz144_P1FU, _0023_003Dz9I9gxp1ufyw2))
					{
						return false;
					}
					_0023_003Dz92qz144_P1FU = false;
				}
			}
		}
		return true;
	}

	private bool _0023_003Dz228Mt8LTtE4_0024(PlaneEquation[] _0023_003DzD7B0muwE6OtQ, object _0023_003DzqkmKMstXA76V)
	{
		DrawForShadowMapParams drawForShadowMapParams = (DrawForShadowMapParams)_0023_003DzqkmKMstXA76V;
		_0023_003DzXS86eTnj2Efz(drawForShadowMapParams.computeEntitiesVisibilityParams, new FrustumParams(_0023_003DzD7B0muwE6OtQ, this, drawForShadowMapParams.drawShadowParams.Blocks), drawForShadowMapParams.drawShadowParams.simplify, drawForShadowMapParams.drawShadowParams.isProgressiveDrawing);
		DrawEntitiesParams drawShadowParams = drawForShadowMapParams.drawShadowParams;
		drawShadowParams.DrawParams.Attributes = new GfxAttributesRendered(Layers);
		drawShadowParams.DrawParams.Parents = new Stack<BlockReference>();
		if (drawShadowParams.DrawParams.Transformation != null)
		{
			_0023_003DzmNZD0Zs_003D.MultMatrixModelView(drawShadowParams.DrawParams.Transformation);
		}
		return _0023_003DzqycL4xalHFGitSlY6XcpAvGGtqX5(drawShadowParams);
	}

	internal bool _0023_003DzqycL4xalHFGitSlY6XcpAvGGtqX5(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		GfxAttributesRendered other = (GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		bool flag = true;
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		for (int i = 0; i < _0023_003DzCBM7XJK4_5H_0024.entList.Count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, _0023_003Dzbq3BJR0_003D) && entity.IsValidForDraw())
			{
				_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Assign(other);
				_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Propagate(entity, _0023_003DzCBM7XJK4_5H_0024.layers[entity.LayerName], ((RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams).materials);
				if (entity is BlockReference)
				{
					flag &= ((BlockReference)entity).DrawTrianglesForShadowMap(_0023_003DzCBM7XJK4_5H_0024);
				}
				else if (((GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes).GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, _0023_003DzCBM7XJK4_5H_0024.defaultMaterial).Diffuse.A == byte.MaxValue)
				{
					((IEntityInternal)entity).DrawForShadow((RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				}
			}
		}
		return flag;
	}

	internal void _0023_003DzjLzB452mA_0024FoSHhFo4DfqyxvrjCF(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		RenderContextBase renderContext = _0023_003DzCBM7XJK4_5H_0024.DrawParams.RenderContext;
		GfxAttributesRendered other = (GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Clone();
		Stack<BlockReference> _0023_003Dzbq3BJR0_003D = _0023_003DzZuBsUvr900Ui(_0023_003DzCBM7XJK4_5H_0024.DrawParams);
		Color currentWireColor = renderContext.CurrentWireColor;
		for (int i = 0; i < _0023_003DzCBM7XJK4_5H_0024.entList.Count; i++)
		{
			Entity entity = _0023_003DzCBM7XJK4_5H_0024.entList[i];
			if (!_0023_003Dz_Aw9YhlTvYKA2IbJkE61bbA_003D(entity, _0023_003Dzbq3BJR0_003D) || !entity.IsValidForDraw())
			{
				continue;
			}
			_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Assign(other);
			_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.Propagate(entity, _0023_003DzCBM7XJK4_5H_0024.layers[entity.LayerName], ((RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams).materials);
			if (entity is BlockReference)
			{
				bool parentClippable = _0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable;
				_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable = _0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				((BlockReference)entity).Draw(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzjLzB452mA_0024FoSHhFo4DfqyxvrjCF);
				_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable = parentClippable;
			}
			else
			{
				if (((GfxAttributesRendered)_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes).GetMaterial(_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D, _0023_003DzCBM7XJK4_5H_0024.defaultMaterial).Diffuse.A < byte.MaxValue)
				{
					continue;
				}
				_0023_003Dze99ar8BiiBSo(_0023_003DzCBM7XJK4_5H_0024.DrawParams, entity);
				if (_0023_003DzCBM7XJK4_5H_0024.DrawParams.ForceGray)
				{
					continue;
				}
				renderContext.SetShader(shaderType.NoLights, null, force: true);
				renderContext.SetClippable(_0023_003DzQ3lufqwusWn5lEeP9w_003D_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentClippable, _0023_003DzCBM7XJK4_5H_0024.DrawParams, entity));
				Color white = Color.White;
				Color empty = Color.Empty;
				if (entity.IsPolygonal())
				{
					if (renderContext.CurrentWireColor != empty)
					{
						renderContext.SetColorWireframe(empty);
					}
					((IEntityInternal)entity).DrawForDepthPass((DrawParams)(RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams);
					continue;
				}
				bool flag = false;
				switch (entity.entityNature)
				{
				case entityNatureType.Point:
					renderContext.PushRasterizerState();
					renderContext.PushShader();
					renderContext.SetPointSize(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.LineWeight);
					flag = true;
					break;
				case entityNatureType.Wire:
					renderContext.PushRasterizerState();
					renderContext.PushShader();
					renderContext.SetLineSize(_0023_003DzCBM7XJK4_5H_0024.DrawParams.Attributes.LineWeight);
					flag = true;
					break;
				}
				if (renderContext.CurrentWireColor != white)
				{
					renderContext.SetColorWireframe(white);
				}
				((IEntityInternal)entity).DrawForDepthPass((DrawParams)(RenderParams)_0023_003DzCBM7XJK4_5H_0024.DrawParams);
				renderContext.EndDrawBufferedLines();
				if (flag)
				{
					renderContext.PopRasterizerState();
					renderContext.PopShader();
				}
			}
		}
		renderContext.SetColorWireframe(currentWireColor);
		renderContext.SetClippable(clippable: true);
	}

	protected override AccessibleObject CreateAccessibilityInstance()
	{
		return new EnvironmentAccessibleObject(this);
	}

	public void DoWork(WorkUnit workUnit)
	{
		workUnit.DoWork();
		workUnit.WorkCompleted(this);
	}

	[Obsolete("Use DoWorkAsync(WorkUnit) instead.")]
	public void StartWork(WorkUnit workUnit)
	{
		if (workUnit == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596073));
		}
		_0023_003DzCk2nGeKTMTKo(_0023_003DzfbRw5MY_003D: true, null, new global::_0023_003DziLUJ6jAVGIL344io_FRgY7A_003D<WorkUnit>(workUnit));
	}

	public Task DoWorkAsync(WorkUnit workUnit)
	{
		return DoWorkAsync(null, workUnit);
	}

	public Task DoWorkAsync(Progress<WorkUnit.ProgressChangedEventArgs> progress, WorkUnit workUnit)
	{
		if (workUnit == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596094));
		}
		return DoWorkAsync(progress, new global::_0023_003DziLUJ6jAVGIL344io_FRgY7A_003D<WorkUnit>(workUnit));
	}

	public Task DoWorkAsync([_0023_003DzO6d89Q1dB7H7BBRLurXBoLs_003D] IReadOnlyList<WorkUnit> workUnits)
	{
		return _0023_003DzCk2nGeKTMTKo(_0023_003DzfbRw5MY_003D: false, null, workUnits);
	}

	public Task DoWorkAsync(Progress<WorkUnit.ProgressChangedEventArgs> progress, [_0023_003DzO6d89Q1dB7H7BBRLurXBoLs_003D] IReadOnlyList<WorkUnit> workUnits)
	{
		return _0023_003DzCk2nGeKTMTKo(_0023_003DzfbRw5MY_003D: false, progress, workUnits);
	}

	internal async Task _0023_003DzCk2nGeKTMTKo(bool _0023_003DzfbRw5MY_003D, Progress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D, [_0023_003DzO6d89Q1dB7H7BBRLurXBoLs_003D] IReadOnlyList<WorkUnit> _0023_003DzHBrzSyG6F8Sb)
	{
		if (_0023_003DzHBrzSyG6F8Sb == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591624));
		}
		if (_0023_003DzHBrzSyG6F8Sb.Count == 0)
		{
			return;
		}
		if (_0023_003DzHBrzSyG6F8Sb.Any(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzTHFsRMLZiy3VLOLU8gbQZrc9V_KA))
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591640), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591624));
		}
		await _0023_003Dz09M73mCmWmeK._0023_003DzyYuAQN8_003D();
		_0023_003Dz09M73mCmWmeK._0023_003DzZjL15X8_003D();
		await _0023_003Dzpw8WxV_0024adNV7HAEnrA_003D_003D.WaitAsync();
		if (ProgressBar.Active)
		{
			ProgressBar.previousVisibility = ProgressBar.Visible;
			ProgressBar.previousValue = ProgressBar.Value;
			ProgressBar.Visible = true;
		}
		ProgressBar.Value = 0;
		ProgressBar.Text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651338);
		_0023_003DzipBYly6zFKAp()._0023_003DzAmQmFnNJkaOUqpvwTQ_003D_003D().Buttons.Add(ProgressBarCancelButton);
		if (_0023_003DzIIIDz8c_003D != null)
		{
			_0023_003DzIIIDz8c_003D.ProgressChanged += delegate(object _0023_003DzxwGby4M_003D, WorkUnit.ProgressChangedEventArgs _0023_003Dz1SmHC4c_003D)
			{
				_0023_003DzlJEZ_iZrKpueW96a_0024Q_003D_003D(_0023_003Dz1SmHC4c_003D);
			};
		}
		else
		{
			_0023_003DzIIIDz8c_003D = new Progress<WorkUnit.ProgressChangedEventArgs>(delegate(WorkUnit.ProgressChangedEventArgs _0023_003Dz1SmHC4c_003D)
			{
				Task task2 = _0023_003DzxIG92rhdr_0024Fd;
				if ((task2 != null && !task2.IsCompleted) || _0023_003Dz1SmHC4c_003D.Progress == 100)
				{
					CancellationTokenSource cancellationTokenSource = _0023_003DzIZDfsMhRoEGn;
					if ((cancellationTokenSource == null || !cancellationTokenSource.IsCancellationRequested) && !base.IsDisposed)
					{
						ProgressBar.Value = _0023_003Dz1SmHC4c_003D.Progress;
						ProgressBar.Text = _0023_003Dz1SmHC4c_003D.Text;
						if (ProgressBar.Visible)
						{
							if (_0023_003Dz1SmHC4c_003D.Continuous)
							{
								ProgressBar._0023_003Dzfhv6eFBtERoy();
							}
							else
							{
								ProgressBar._0023_003DzwdY8uuMuAeqB();
								if (_0023_003DzR9WOThn15SZhpgA2FA_003D_003D)
								{
									return;
								}
								_0023_003DzR9WOThn15SZhpgA2FA_003D_003D = true;
								BeginInvoke(new Action(_0023_003Dzzr00LSmTUMlMH8anYkB8CjaHk6Cw));
							}
						}
						FireProgressChanged(_0023_003Dz1SmHC4c_003D);
					}
				}
			});
		}
		_0023_003DzIZDfsMhRoEGn = new CancellationTokenSource();
		List<Task> list = new List<Task>(_0023_003DzHBrzSyG6F8Sb.Count);
		try
		{
			if (_0023_003Dz09M73mCmWmeK._0023_003Dz7HticeW00qIl())
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591695));
			}
			_0023_003DzwFKdhc8_003D = false;
			foreach (WorkUnit item in _0023_003DzHBrzSyG6F8Sb)
			{
				item.ResetProgress();
				if (item is WriteFile writeFile)
				{
					writeFile.PrepareEnvironmentData();
				}
				if (item is WriteFileAsync)
				{
					_0023_003DzwFKdhc8_003D = true;
				}
				item.Status = workUnitStatus.InProgress;
				list.Add(item.DoWorkAsync(_0023_003DzIIIDz8c_003D, _0023_003DzIZDfsMhRoEGn.Token));
			}
			if (_0023_003DzKDiCijSjQLjc != null)
			{
				_0023_003DzKDiCijSjQLjc.Dispose();
				_0023_003DzKDiCijSjQLjc = null;
			}
			_0023_003DzKDiCijSjQLjc = new AutoResetEvent(!_0023_003DzwFKdhc8_003D);
			_0023_003DzxIG92rhdr_0024Fd = Task.WhenAll(list);
			await _0023_003DzxIG92rhdr_0024Fd;
		}
		finally
		{
			try
			{
				_0023_003DzKDiCijSjQLjc?.Set();
				_0023_003DzKDiCijSjQLjc?.Dispose();
				_0023_003DzKDiCijSjQLjc = null;
				_0023_003DzIIIDz8c_003D.ProgressChanged -= delegate(object _0023_003DzxwGby4M_003D, WorkUnit.ProgressChangedEventArgs _0023_003Dz1SmHC4c_003D)
				{
					_0023_003DzlJEZ_iZrKpueW96a_0024Q_003D_003D(_0023_003Dz1SmHC4c_003D);
				};
				_0023_003DzIZDfsMhRoEGn?.Dispose();
				_0023_003DzIZDfsMhRoEGn = null;
				_0023_003DzxIG92rhdr_0024Fd = null;
			}
			catch
			{
			}
			_0023_003DzipBYly6zFKAp()._0023_003Dz_0024vGIP8ipyEwE();
			ProgressBar?._0023_003Dze5O5R4s_003D(this);
			if (ProgressBarCancelButton != null)
			{
				ProgressBarCancelButton._0023_003Dzbb_0024Bito_003D((ToolBarButton._0023_003DzJrgugJM_003D)0);
			}
			for (int num = 0; num < list.Count; num++)
			{
				Task task = list[num];
				WorkUnit workUnit = _0023_003DzHBrzSyG6F8Sb[num];
				switch (task.Status)
				{
				case TaskStatus.Faulted:
					workUnit.Status = workUnitStatus.Failed;
					workUnit.WorkFailed(this);
					if (_0023_003DzfbRw5MY_003D)
					{
						FireWorkFailed(new WorkFailedEventArgs(workUnit, task.Exception));
					}
					break;
				case TaskStatus.Canceled:
					workUnit.Status = workUnitStatus.Cancelled;
					_0023_003Dz09M73mCmWmeK._0023_003DzAiYx9eY_003D();
					workUnit.WorkCancelled(this);
					if (_0023_003DzfbRw5MY_003D)
					{
						FireWorkCancelled(new WorkUnitEventArgs(workUnit));
					}
					_0023_003Dz09M73mCmWmeK._0023_003DzAiYx9eY_003D();
					break;
				case TaskStatus.RanToCompletion:
					workUnit.Status = workUnitStatus.Completed;
					workUnit.WorkCompleted(this);
					if (_0023_003DzfbRw5MY_003D)
					{
						FireProgressChanged(new WorkUnit.ProgressChangedEventArgs(100));
						FireWorkCompleted(new WorkCompletedEventArgs(workUnit));
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			if (!_0023_003DzhuKRYpQ_003D)
			{
				_0023_003DzQtM_y9yLRR_0024E();
			}
			_0023_003DzwFKdhc8_003D = false;
			_0023_003Dz09M73mCmWmeK._0023_003DzVOCJm_s_003D();
			_0023_003Dzpw8WxV_0024adNV7HAEnrA_003D_003D.Release();
		}
	}

	public void CancelWork()
	{
		if (IsBusy)
		{
			ProgressBar.cancelling = true;
			try
			{
				_0023_003DzIZDfsMhRoEGn?.Cancel();
			}
			catch
			{
			}
		}
	}

	private void _0023_003Dz3_0024_AS96IltYd(object _0023_003DzxwGby4M_003D, WorkUnit.ProgressChangedEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzlJEZ_iZrKpueW96a_0024Q_003D_003D(_0023_003Dz1SmHC4c_003D);
	}

	internal void _0023_003DzlJEZ_iZrKpueW96a_0024Q_003D_003D(WorkUnit.ProgressChangedEventArgs _0023_003Dz1SmHC4c_003D)
	{
		Task task = _0023_003DzxIG92rhdr_0024Fd;
		if ((task == null || task.IsCompleted) && _0023_003Dz1SmHC4c_003D.Progress != 100)
		{
			return;
		}
		CancellationTokenSource cancellationTokenSource = _0023_003DzIZDfsMhRoEGn;
		if ((cancellationTokenSource != null && cancellationTokenSource.IsCancellationRequested) || base.IsDisposed)
		{
			return;
		}
		ProgressBar.Value = _0023_003Dz1SmHC4c_003D.Progress;
		ProgressBar.Text = _0023_003Dz1SmHC4c_003D.Text;
		if (ProgressBar.Visible)
		{
			if (_0023_003Dz1SmHC4c_003D.Continuous)
			{
				ProgressBar._0023_003Dzfhv6eFBtERoy();
			}
			else
			{
				ProgressBar._0023_003DzwdY8uuMuAeqB();
				if (_0023_003DzR9WOThn15SZhpgA2FA_003D_003D)
				{
					return;
				}
				_0023_003DzR9WOThn15SZhpgA2FA_003D_003D = true;
				BeginInvoke(new Action(_0023_003Dzzr00LSmTUMlMH8anYkB8CjaHk6Cw));
			}
		}
		FireProgressChanged(_0023_003Dz1SmHC4c_003D);
	}

	internal void _0023_003Dz78oB1KCkXEP9()
	{
		if (_0023_003DzjC4hA2I_003D.isHardwareAccelerated)
		{
			PaintBackBuffer();
			SwapBuffers();
		}
		else
		{
			Invalidate();
		}
	}

	protected void FireWorkCompleted(WorkCompletedEventArgs e)
	{
		if (_0023_003Dz0T1Zdz9fIp9t != null)
		{
			_0023_003Dz0T1Zdz9fIp9t(this, e);
		}
	}

	protected void FireWorkCancelled(WorkUnitEventArgs e)
	{
		if (_0023_003Dz106nlntdESk5 != null)
		{
			_0023_003Dz106nlntdESk5(this, e);
		}
	}

	protected void FireWorkFailed(WorkFailedEventArgs e)
	{
		if (_0023_003DzB6s4ltXuApFM != null)
		{
			_0023_003DzB6s4ltXuApFM(this, e);
		}
	}

	protected void FireProgressChanged(WorkUnit.ProgressChangedEventArgs e)
	{
		if (_0023_003DzJKwcJ2U_003D != null)
		{
			_0023_003DzJKwcJ2U_003D(this, e);
		}
	}

	internal bool _0023_003DzMBy_0024512q0kfX()
	{
		return _0023_003Dz2oXHlo_oZcH3 != null;
	}

	public Bitmap RenderToBitmap(Size bitmapSize)
	{
		return RenderToBitmap(bitmapSize, drawBackground: true);
	}

	public Bitmap RenderToBitmap(Size bitmapSize, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(bitmapSize, 0f, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(Size bitmapSize, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return _0023_003DzipBYly6zFKAp().RenderToBitmap(bitmapSize, lineWeightFactor, drawBackground, hdwAcceleration);
	}

	internal void _0023_003DzzpG3rT4lYHMG(TextureBase _0023_003Dz_IfKSJY_003D, Rectangle _0023_003DzLCFtN0k_003D, bool _0023_003DzbUBvby4V64DY, bool _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, float _0023_003DzCs_ZxbN2mZ30)
	{
		_0023_003DzipBYly6zFKAp()._0023_003DzzpG3rT4lYHMG(_0023_003Dz_IfKSJY_003D, _0023_003DzLCFtN0k_003D, _0023_003DzCs_ZxbN2mZ30, _0023_003DzbUBvby4V64DY, _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D, _0023_003DzmAezgho6pU2i: false);
	}

	public Bitmap RenderToBitmap(RectangleF rectangle, Size bitmapSize, bool drawBackground, bool hdwAcceleration)
	{
		return RenderToBitmap(rectangle, bitmapSize, 0f, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(RectangleF rectangle, Size bitmapSize, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return _0023_003DzipBYly6zFKAp().RenderToBitmap(rectangle, bitmapSize, lineWeightFactor, drawBackground, hdwAcceleration, drawUiElements: false);
	}

	public Bitmap RenderToBitmap(float drawScaleFactor)
	{
		return RenderToBitmap(drawScaleFactor, drawBackground: true);
	}

	public Bitmap RenderToBitmap(float drawScaleFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(drawScaleFactor, 0f, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(float drawScaleFactor, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		return _0023_003DzipBYly6zFKAp().RenderToBitmap(drawScaleFactor, lineWeightFactor, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(Rectangle rectangle, float drawScaleFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return RenderToBitmap(rectangle, drawScaleFactor, 0f, drawBackground, hdwAcceleration);
	}

	public Bitmap RenderToBitmap(Rectangle rectangle, float drawScaleFactor, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		return _0023_003DzipBYly6zFKAp().RenderToBitmap(rectangle, drawScaleFactor, lineWeightFactor, drawBackground, hdwAcceleration);
	}

	public void WriteToFileRaster(float drawScaleFactor, string filePath, ImageFormat format)
	{
		WriteToFileRaster(drawScaleFactor, filePath, format, drawBackground: true);
	}

	public void WriteToFileRaster(float drawScaleFactor, string filePath, ImageFormat format, bool drawBackground, bool hdwAcceleration = true)
	{
		WriteToFileRaster(drawScaleFactor, 0f, filePath, format, drawBackground, hdwAcceleration);
	}

	public void WriteToFileRaster(float drawScaleFactor, float lineWeightFactor, string filePath, ImageFormat format, bool drawBackground, bool hdwAcceleration = true)
	{
		_0023_003DzipBYly6zFKAp().WriteToFileRaster(drawScaleFactor, lineWeightFactor, filePath, format, drawBackground, hdwAcceleration);
	}

	public void WriteToFileVector(bool fit, string filePath, bool async = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		Pen penSilhouette = new Pen(Color.Black, 3f);
		Pen penEdge = new Pen(Color.Black, 1f);
		Pen penWire = new Pen(Color.Black, 1f);
		HiddenLinesViewOnFile workUnit = new HiddenLinesViewOnFile(new HiddenLinesViewSettingsEx(_0023_003DzipBYly6zFKAp(), this, (!fit) ? hiddenLinesViewType.Window : hiddenLinesViewType.Extents)
		{
			PenSilhouette = penSilhouette,
			PenEdge = penEdge,
			PenWire = penWire
		}, filePath);
		if (async)
		{
			StartWork(workUnit);
		}
		else
		{
			DoWork(workUnit);
		}
	}

	internal bool _0023_003DzyobtGSd5_zcs()
	{
		return _0023_003Dz2oXHlo_oZcH3 != null;
	}

	internal void _0023_003DzbMij5IjKskzE(int? _0023_003Dz3WmYIvQ_003D, int? _0023_003DzFjzWVmPa7B0C)
	{
		if (_0023_003Dz3WmYIvQ_003D >= -1)
		{
			_0023_003DzfrZS1vKuIMTc = _0023_003Dz3WmYIvQ_003D.Value;
		}
		if (_0023_003DzFjzWVmPa7B0C > 0)
		{
			_0023_003DzE8RAOjfuSQcK = _0023_003DzFjzWVmPa7B0C.Value;
		}
		if (_0023_003Dz2oXHlo_oZcH3 == null)
		{
			_0023_003Dz2oXHlo_oZcH3 = new System.Threading.Timer(OnAnimationTimerTick, null, 0, _0023_003DzfrZS1vKuIMTc);
		}
	}

	internal void _0023_003DzqYQgL_pXJcCP(bool _0023_003DzNir3dPKLkVT3)
	{
		lock (_0023_003DzIdtz_FH5YEwn)
		{
			if (_0023_003Dz2oXHlo_oZcH3 != null)
			{
				_0023_003Dz2oXHlo_oZcH3.Dispose();
				_0023_003Dz2oXHlo_oZcH3 = null;
			}
			_0023_003DzE8RAOjfuSQcK = -1;
			_0023_003DzadGKi_0024sgvFBr = 0;
			if (!_0023_003DzNir3dPKLkVT3)
			{
				Invalidate();
			}
		}
	}

	protected virtual void OnAnimationTimerTick(object stateInfo)
	{
		if (_0023_003Dz11GAUsevhJJJ == 0)
		{
			return;
		}
		_0023_003DzadGKi_0024sgvFBr += _0023_003Dz11GAUsevhJJJ;
		if (_0023_003DzE8RAOjfuSQcK > 0 && _0023_003DzadGKi_0024sgvFBr > _0023_003DzE8RAOjfuSQcK)
		{
			_0023_003DzqYQgL_pXJcCP(_0023_003DzNir3dPKLkVT3: false);
			return;
		}
		lock (_0023_003DzIdtz_FH5YEwn)
		{
			if (_0023_003Dz2oXHlo_oZcH3 == null)
			{
				return;
			}
			foreach (Block block in Blocks)
			{
				foreach (Entity entity in block.Entities)
				{
					((IEntityInternal)entity).Animate(_0023_003DzadGKi_0024sgvFBr);
				}
			}
			foreach (Block item in _0023_003DzOA_ac7k_003D)
			{
				foreach (Entity entity2 in item.Entities)
				{
					((IEntityInternal)entity2).Animate(_0023_003DzadGKi_0024sgvFBr);
				}
			}
		}
		if (base.InvokeRequired)
		{
			BeginInvoke(new Action(Invalidate), null);
		}
		else
		{
			Invalidate();
		}
	}

	public void CopyToClipboardRaster(Size bitmapSize)
	{
		CopyToClipboardRaster(bitmapSize, drawBackground: true);
	}

	public void CopyToClipboardRaster(Size bitmapSize, bool drawBackground, bool hdwAcceleration = true)
	{
		CopyToClipboardRaster(bitmapSize, 0f, drawBackground, hdwAcceleration);
	}

	public void CopyToClipboardRaster(Size bitmapSize, float lineWeightFactor, bool drawBackground, bool hdwAcceleration = true)
	{
		Bitmap bitmap = RenderToBitmap(bitmapSize, lineWeightFactor, drawBackground, hdwAcceleration);
		Clipboard.SetImage(bitmap);
		bitmap.Dispose();
	}

	public void CopyToClipboardRaster()
	{
		CopyToClipboardRaster(1f);
	}

	public void CopyToClipboardRaster(float drawScale)
	{
		CopyToClipboardRaster(drawScale, 0f);
	}

	public void CopyToClipboardRaster(float drawScale, float lineWeightFactor)
	{
		_0023_003DzipBYly6zFKAp()._0023_003DzyTxplglIp34Z1TMeuCdiY4s_003D(drawScale, lineWeightFactor, _0023_003DzbUBvby4V64DY: true, _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D: true);
	}

	public void CopyToClipboardVector(bool fit)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		Pen penSilhouette = new Pen(Color.Black, 3f);
		Pen penEdge = new Pen(Color.Black, 1f);
		Pen penWire = new Pen(Color.Black, 1f);
		HiddenLinesViewOnClipboard workUnit = new HiddenLinesViewOnClipboard(new HiddenLinesViewSettingsEx(_0023_003DzipBYly6zFKAp(), this, (!fit) ? hiddenLinesViewType.Window : hiddenLinesViewType.Extents)
		{
			PenSilhouette = penSilhouette,
			PenEdge = penEdge,
			PenWire = penWire
		});
		StartWork(workUnit);
	}

	[Obsolete("Use Mesh.CreatePlanar() method instead.")]
	public static Point3D[] MakeLoop(IList<ICurve> curveList, int startIndex, double chordalError, bool reverse)
	{
		return _0023_003Dzmb7PhZUTPQPe(curveList, startIndex, chordalError, (_0023_003DzrWM_00242Vk_003D)0, reverse);
	}

	internal static Point3D[] _0023_003Dzmb7PhZUTPQPe(IList<ICurve> _0023_003DzX48mqKSfEK_7, int _0023_003DzivjwkyA_003D, double _0023_003DzyD_b_e0_003D, _0023_003DzrWM_00242Vk_003D _0023_003Dzu3I88Jjo7ihi, bool _0023_003DzobfaVZ4_003D)
	{
		ICurve[] array = ((_0023_003Dzu3I88Jjo7ihi != 0) ? _0023_003Dzby8Nla5DMnhd(_0023_003DzX48mqKSfEK_7, _0023_003DzivjwkyA_003D) : _0023_003Dzby8Nla5DMnhd(_0023_003DzX48mqKSfEK_7, _0023_003DzivjwkyA_003D));
		List<Point3D> list = new List<Point3D>();
		ICurve[] array2 = array;
		foreach (ICurve _0023_003DzSLnz75LnM5Rs in array2)
		{
			if (_0023_003Dzu3I88Jjo7ihi == (_0023_003DzrWM_00242Vk_003D)0)
			{
				list.AddRange(_0023_003DzIZNU9_0024blmtTIuNXcYCIkWoc_003D(_0023_003DzyD_b_e0_003D, _0023_003DzSLnz75LnM5Rs));
			}
			else
			{
				list.AddRange(_0023_003DzBariIsArJL2b(_0023_003DzyD_b_e0_003D, _0023_003DzSLnz75LnM5Rs));
			}
		}
		list.Add(list[0]);
		if (_0023_003DzobfaVZ4_003D)
		{
			list.Reverse();
		}
		return list.ToArray();
	}

	private static ICurve[] _0023_003Dzby8Nla5DMnhd(IList<ICurve> _0023_003DzX48mqKSfEK_7, int _0023_003DzivjwkyA_003D)
	{
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		foreach (Entity item in _0023_003DzX48mqKSfEK_7)
		{
			Point3D[] array = item.EstimateBoundingBox(null, null);
			foreach (Point3D point3D in array)
			{
				if (point3D.X < maxValue.X)
				{
					maxValue.X = point3D.X;
				}
				if (point3D.X > minValue.X)
				{
					minValue.X = point3D.X;
				}
				if (point3D.Y < maxValue.Y)
				{
					maxValue.Y = point3D.Y;
				}
				if (point3D.Y > minValue.Y)
				{
					minValue.Y = point3D.Y;
				}
				if (point3D.Z < maxValue.Z)
				{
					maxValue.Z = point3D.Z;
				}
				if (point3D.Z > minValue.Z)
				{
					minValue.Z = point3D.Z;
				}
			}
		}
		double diagonal = new Size3D(maxValue, minValue).Diagonal;
		List<ICurve> list = new List<ICurve>();
		LinkedList<ICurve> linkedList = new LinkedList<ICurve>();
		for (int j = 0; j < _0023_003DzX48mqKSfEK_7.Count; j++)
		{
			if (j != _0023_003DzivjwkyA_003D)
			{
				linkedList.AddLast(_0023_003DzX48mqKSfEK_7[j]);
			}
		}
		if (_0023_003DzX48mqKSfEK_7[_0023_003DzivjwkyA_003D] == null)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596083), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595375));
		}
		ICurve curve = _0023_003DzX48mqKSfEK_7[_0023_003DzivjwkyA_003D];
		Point3D b = curve.EndPoint;
		list.Add(curve);
		LinkedListNode<ICurve> linkedListNode = linkedList.First;
		int num = 0;
		while (linkedListNode != null)
		{
			curve = linkedListNode.Value;
			if (curve == null)
			{
				throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596083), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595364));
			}
			Point3D startPoint = curve.StartPoint;
			Point3D endPoint = curve.EndPoint;
			if (Point3D.Distance(startPoint, b) / diagonal < 0.001)
			{
				b = endPoint;
				list.Add(curve);
				LinkedListNode<ICurve> linkedListNode2 = Utility.CircularNext(linkedListNode);
				linkedList.Remove(linkedListNode);
				linkedListNode = linkedListNode2;
				num = 0;
			}
			else if (Point3D.Distance(endPoint, b) / diagonal < 0.001)
			{
				b = startPoint;
				curve.Reverse();
				list.Add(curve);
				LinkedListNode<ICurve> linkedListNode3 = Utility.CircularNext(linkedListNode);
				linkedList.Remove(linkedListNode);
				linkedListNode = linkedListNode3;
				num = 0;
			}
			else
			{
				linkedListNode = Utility.CircularNext(linkedListNode);
			}
			if (linkedListNode == null || num > linkedList.Count || linkedList.Count == 0)
			{
				break;
			}
			num++;
		}
		return list.ToArray();
	}

	private static Point3D[] _0023_003DzIZNU9_0024blmtTIuNXcYCIkWoc_003D(double _0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D, ICurve _0023_003DzSLnz75LnM5Rs)
	{
		Entity entity = (Entity)_0023_003DzSLnz75LnM5Rs;
		entity.Regen(_0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D);
		Point3D[] array = new Point3D[entity._vertices.Length];
		Array.Copy(entity._vertices, array, entity._vertices.Length);
		Array.Resize(ref array, array.Length - 1);
		return array;
	}

	private static Point3D[] _0023_003DzBariIsArJL2b(double _0023_003DzdeXr8TY_003D, ICurve _0023_003DzSLnz75LnM5Rs)
	{
		Point3D[] array = null;
		if (_0023_003DzSLnz75LnM5Rs.GetType() == typeof(Line))
		{
			array = ((Line)_0023_003DzSLnz75LnM5Rs).GetPointsByLength(_0023_003DzdeXr8TY_003D);
		}
		else if (_0023_003DzSLnz75LnM5Rs.GetType() == typeof(Circle))
		{
			array = ((Circle)_0023_003DzSLnz75LnM5Rs).GetPointsByLength(_0023_003DzdeXr8TY_003D);
		}
		else
		{
			if (!(_0023_003DzSLnz75LnM5Rs.GetType() == typeof(Arc)))
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595385));
			}
			array = ((Arc)_0023_003DzSLnz75LnM5Rs).GetPointsByLength(_0023_003DzdeXr8TY_003D);
		}
		Array.Resize(ref array, array.Length - 1);
		return array;
	}

	internal void _0023_003Dz8fFk9aTlvPdc(IViewport _0023_003DzYzWi5Yw_003D, viewType _0023_003Dzm1Aquqk_003D)
	{
		if (_0023_003Dz0pCfd9s_003D != null)
		{
			_0023_003Dz0pCfd9s_003D(_0023_003DzYzWi5Yw_003D, new ViewChangedEventArgs(_0023_003Dzm1Aquqk_003D));
		}
	}

	public virtual void ZoomFit()
	{
		ZoomFit(_0023_003DzipBYly6zFKAp().Zoom.FitMargin);
	}

	public virtual void ZoomFit(int margin)
	{
		_0023_003Dz4do4PYoh6JqZ(new List<Entity> { _0023_003DzpU_kB1T_2Sae() }, _0023_003DzGhkfdMlbGS2U: false, margin, AnimateCamera, _0023_003DzfcxLpl4Se0Cc: false);
	}

	public virtual void ZoomFit(bool selectedOnly)
	{
		ZoomFit(selectedOnly, _0023_003DzipBYly6zFKAp().Zoom.FitMargin);
	}

	public virtual void ZoomFit(bool selectedOnly, int margin)
	{
		_0023_003Dz4do4PYoh6JqZ(new List<Entity> { _0023_003DzpU_kB1T_2Sae() }, selectedOnly, margin, AnimateCamera, _0023_003DzfcxLpl4Se0Cc: false);
	}

	public virtual void ZoomFit(IList<Entity> entList, bool selectedOnly)
	{
		ZoomFit(entList, selectedOnly, _0023_003DzipBYly6zFKAp().Zoom.FitMargin);
	}

	public virtual void ZoomFit(IList<Entity> entList, bool selectedOnly, int margin)
	{
		_0023_003Dz4do4PYoh6JqZ(entList, selectedOnly, margin, AnimateCamera, _0023_003DzfcxLpl4Se0Cc: true);
	}

	private void _0023_003Dz4do4PYoh6JqZ(IList<Entity> _0023_003DzY_0024ABPwh9wryC, bool _0023_003DzGhkfdMlbGS2U, int _0023_003DzPG6BDWw_003D, bool _0023_003DzBQC8k3F0wJN4, bool _0023_003DzfcxLpl4Se0Cc)
	{
		_0023_003DzipBYly6zFKAp()._0023_003Dz7hZyO75hkvCs(_0023_003DzY_0024ABPwh9wryC, _0023_003DzGhkfdMlbGS2U, _0023_003DzipBYly6zFKAp().Zoom.FitLabels, _0023_003DzipBYly6zFKAp().Zoom.PerspectiveFitMode, _0023_003DzuHeqvmo_003D: false, _0023_003DzfcxLpl4Se0Cc, _0023_003DzPG6BDWw_003D, _0023_003DzBQC8k3F0wJN4, _0023_003Dz_00246Jev2I_003D: true, _0023_003DzhQd3_0024ARpbtAn: false);
	}

	public virtual void ZoomFitSelectedLeaves()
	{
		ZoomFitSelectedLeaves(_0023_003DzipBYly6zFKAp().Zoom.FitMargin);
	}

	public virtual void ZoomFitSelectedLeaves(int margin)
	{
		ZoomFitSelectedLeaves(margin, _0023_003DzipBYly6zFKAp().Zoom.PerspectiveFitMode);
	}

	public virtual void ZoomFitSelectedLeaves(int margin, Camera.perspectiveFitType perspectiveFitMode)
	{
		_0023_003DzipBYly6zFKAp().ZoomFitSelectedLeaves(margin, perspectiveFitMode);
	}

	public virtual void ZoomFit(IList<SelectedItem> items)
	{
		ZoomFit(items, _0023_003DzipBYly6zFKAp().Zoom.FitMargin);
	}

	public virtual void ZoomFit(IList<SelectedItem> items, int margin)
	{
		_0023_003DzipBYly6zFKAp().ZoomFit(items, margin);
	}

	public virtual void ZoomFit(IList<SelectedItem> items, int margin, Camera.perspectiveFitType perspectiveFitMode)
	{
		_0023_003DzipBYly6zFKAp().ZoomFit(items, margin, perspectiveFitMode);
	}

	public virtual void ZoomWindow(System.Drawing.Point p1, System.Drawing.Point p2)
	{
		_0023_003DzipBYly6zFKAp()._0023_003DzRU2PjWez6nJ3(p1, p2, AnimateCamera);
	}

	internal bool _0023_003Dzsr62oKVDDQue_0024_0024wA43zLq0s_003D()
	{
		return _0023_003Dz0tc02EiRYcVMdJTaZKYfaoo_003D;
	}

	internal void _0023_003DzVB3rG1jFj36mUeWbLcbOAQU_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz0tc02EiRYcVMdJTaZKYfaoo_003D = _0023_003DzsLHxXyo_003D;
	}

	private bool _0023_003DzBoi3x2wZInwIXRdzHiwIcoc_003D()
	{
		return !_0023_003Dzsr62oKVDDQue_0024_0024wA43zLq0s_003D();
	}

	internal void _0023_003DzbgH2i4NcEmkBOeygzdXd4Ac_003D()
	{
		_0023_003DzVB3rG1jFj36mUeWbLcbOAQU_003D(_0023_003DzsLHxXyo_003D: true);
	}

	public void SetView(viewType view)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().SetView(view);
	}

	public void SetView(viewType view, bool fit, bool animate)
	{
		SetView(view, fit, animate, _0023_003DzipBYly6zFKAp().Zoom.FitMargin);
	}

	public void SetView(viewType view, bool fit, bool animate, int margin, bool selectedOnly = false)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().SetView(view, fit, animate, margin, selectedOnly);
	}

	public void SetView(Quaternion rotation, Point3D target, double distance, double zoomFactor)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().SetView(rotation, target, distance, zoomFactor, AnimateCamera);
	}

	public void SetView(Quaternion rotation, Point3D target, double distance, double zoomFactor, bool animate)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().SetView(rotation, target, distance, zoomFactor, animate);
	}

	public void SaveView()
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().SavedViews.Save();
	}

	public void PreviousView()
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().SavedViews.Previous();
	}

	public void NextView()
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		_0023_003DzipBYly6zFKAp().SavedViews.Next();
	}

	private bool ShouldSerializeAnimateCamera()
	{
		return AnimateCamera;
	}

	private void ResetAnimateCamera()
	{
		AnimateCamera = false;
	}

	private bool ShouldSerializeAnimateCameraDuration()
	{
		return AnimateCameraDuration != 300;
	}

	private void ResetAnimateCameraDuration()
	{
		AnimateCameraDuration = 300;
	}

	protected override void OnDoubleClick(EventArgs e)
	{
		_0023_003DzPHKlzPNfviRt(Rectangle.Empty);
		if (_0023_003Dz32fCUXg4rkVM != null && _0023_003Dz32fCUXg4rkVM._0023_003DzxpoNvry1jysi())
		{
			_0023_003DzUjX3DZgNhR_0024eQkwpZQ_003D_003D((MouseEventArgs)e);
		}
		base.OnDoubleClick(e);
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		if (_0023_003Dz32fCUXg4rkVM != null && _0023_003Dz32fCUXg4rkVM._0023_003DzxpoNvry1jysi() && _0023_003Dzl1meGtYJNgTP != null)
		{
			_0023_003Dzl1meGtYJNgTP(this, e);
		}
		base.OnMouseClick(e);
	}

	internal bool _0023_003DzWct4wogVWy2w()
	{
		if (!MultipleSelection)
		{
			return System.Windows.Forms.Control.ModifierKeys == Keys.Control;
		}
		return true;
	}

	internal void _0023_003Dzsf8k5Q5BH9Z_0024(MouseButtons _0023_003Dzs8Ok2lA_003D, Rectangle? _0023_003Dzols9v2M_003D)
	{
		Rectangle selectionBox = (_0023_003Dzols9v2M_003D.HasValue ? _0023_003Dzols9v2M_003D.Value : Rectangle.Empty);
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		if ((_0023_003Dzs8Ok2lA_003D != MouseButtons.Left && _0023_003Dzs8Ok2lA_003D != MouseButtons.Right) || !IsSelectByPickAction())
		{
			return;
		}
		bool flag = _0023_003DzWct4wogVWy2w();
		SelectionChangedEventArgs e = new SelectionChangedEventArgs();
		_0023_003Dz0_czIjY3d3YXM7nQVA_003D_003D(flag, viewport, e, _0023_003DzUsW18wvfQQpu: false);
		if (Entities.Count > 0 || _0023_003DzjGvm17_0024DzsnS == actionType.SelectVisibleByPickLabel)
		{
			_0023_003DznsHxfVrI76un(out var _0023_003DzN0be4hzcg7Lk, out var _, out var _0023_003Dz0ERMHbg_003D);
			if (_0023_003DzjGvm17_0024DzsnS == actionType.SelectByPick || _0023_003DzjGvm17_0024DzsnS == actionType.SelectVisibleByPickLabel || _0023_003DzjGvm17_0024DzsnS == actionType.SelectVisibleByPick || _0023_003DzjGvm17_0024DzsnS == actionType.SelectVisibleByPickDynamic)
			{
				_0023_003Dz0ERMHbg_003D.Width = PickBoxSize;
				_0023_003Dz0ERMHbg_003D.Height = PickBoxSize;
			}
			if (selectionBox.IsEmpty)
			{
				selectionBox = _0023_003DzLihM0a_0024fTauw(viewport, _0023_003DzN0be4hzcg7Lk, _0023_003Dz0ERMHbg_003D, _0023_003DzeUi9A7zbcNV048FIvQ_003D_003D: true);
			}
			switch (_0023_003DzjGvm17_0024DzsnS)
			{
			case actionType.SelectVisibleByPick:
			case actionType.SelectVisibleByPickDynamic:
				ProcessSelectionVisibleOnly(selectionBox, firstOnly: true, flag, e);
				_0023_003Dzvt4CNgJSomsF(e);
				break;
			case actionType.SelectVisibleByPickLabel:
				ProcessSelectionVisibleOnlyLabels(selectionBox, firstOnly: true, flag, e);
				viewport.FireLabelSelectionChanged(e);
				break;
			case actionType.SelectByPick:
				ProcessSelection(selectionBox, firstOnly: true, flag, e);
				_0023_003Dzvt4CNgJSomsF(e);
				break;
			}
		}
		Invalidate();
	}

	private void _0023_003Dz0_czIjY3d3YXM7nQVA_003D_003D(bool _0023_003DzAqbizhcYZ5va, Viewport _0023_003DzYzWi5Yw_003D, SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e, bool _0023_003DzUsW18wvfQQpu)
	{
		List<SelectedItem> list = new List<SelectedItem>();
		selectionStatusType selectionFlag = SelectionInfo.GetSelectionFlag(_0023_003DzUsW18wvfQQpu);
		if (!_0023_003DzAqbizhcYZ5va)
		{
			if (ActionMode == actionType.SelectVisibleByPickLabel)
			{
				foreach (devDept.Eyeshot.Control.Labels.Label label in _0023_003DzYzWi5Yw_003D.Labels)
				{
					if (label._selectionInfo.SelectionInfo.IsFlagSet(selectionFlag))
					{
						list.Add(new SelectedItem(label));
					}
					label.Selected = false;
				}
			}
			else
			{
				foreach (Block block in Blocks)
				{
					int _0023_003DzivjwkyA_003D = 0;
					if (this is Drawing && selectionFlag == selectionStatusType.Temporary && block.referencesToMe.Count == 1 && block.referencesToMe.First() is VectorView { inScope: false } vectorView)
					{
						_0023_003DzivjwkyA_003D = vectorView.hdlCount;
					}
					_0023_003DzUzlQIBwarK8U(block.Entities, selectionFlag, list, _0023_003DzivjwkyA_003D);
				}
				if (selectionFlag == selectionStatusType.Permanent && this is Drawing)
				{
					foreach (Entity entity in Entities)
					{
						if (entity is VectorView vectorView2)
						{
							vectorView2.selectedHdlSegments.Clear();
						}
					}
				}
			}
		}
		_0023_003DzdXQchgXOgG_0024e.RemovedItems = list;
	}

	private void _0023_003DzUzlQIBwarK8U(IList<Entity> _0023_003DzCFE3F_0024Imc2c6, selectionStatusType _0023_003DzNWtosWYCtxJL, List<SelectedItem> _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D, int _0023_003DzivjwkyA_003D)
	{
		for (int i = _0023_003DzivjwkyA_003D; i < _0023_003DzCFE3F_0024Imc2c6.Count; i++)
		{
			Entity entity = _0023_003DzCFE3F_0024Imc2c6[i];
			if (entity._selectionInfo.SelectionInfo.IsFlagSet(_0023_003DzNWtosWYCtxJL))
			{
				_0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D.Add(new SelectedItem(entity));
				entity._selectionInfo.SelectionInfo.UnsetFlag(_0023_003DzNWtosWYCtxJL);
			}
			_0023_003DzOOXPlJN4n8PM2s1qJQ_003D_003D(_0023_003DzNWtosWYCtxJL, entity, entity.InstanceSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
			if (entity is Mesh)
			{
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((Mesh)entity).FacesSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
			}
			else if (entity is Solid)
			{
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((Solid)entity).FacesSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
			}
			else if (entity is Brep)
			{
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((Brep)entity).FacesSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((Brep)entity).InnerFacesSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((Brep)entity).EdgesSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((Brep)entity).VerticesSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
			}
			else if (entity is CompositeCurve)
			{
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((CompositeCurve)entity).SubCurvesSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
			}
			else if (entity is devDept.Eyeshot.Entities.Region)
			{
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((devDept.Eyeshot.Entities.Region)entity).SubContoursSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
			}
			else if (entity is SketchEntity)
			{
				_0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(_0023_003DzNWtosWYCtxJL, entity, ((SketchEntity)entity).SketchCurvesSelectionInfo, _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D);
			}
			if (!((ISelectableItem)entity).IsAnyInstanceSelected())
			{
				entity.InstanceSelectionInfo.Clear();
			}
		}
	}

	private static void _0023_003DzOOXPlJN4n8PM2s1qJQ_003D_003D(selectionStatusType _0023_003DzNWtosWYCtxJL, Entity _0023_003DziGd2KgU_003D, List<SelectionInfoItem> _0023_003DzIJnKYg2rS5Pe, List<SelectedItem> _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D)
	{
		for (int i = 0; i < _0023_003DzIJnKYg2rS5Pe.Count; i++)
		{
			if (_0023_003DzIJnKYg2rS5Pe[i].SelectionInfo.IsFlagSet(_0023_003DzNWtosWYCtxJL))
			{
				_0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D.Add(new SelectedItem(_0023_003DzIJnKYg2rS5Pe[i].Parents, _0023_003DziGd2KgU_003D));
				_0023_003DzIJnKYg2rS5Pe[i].SelectionInfo.UnsetFlag(_0023_003DzNWtosWYCtxJL);
			}
		}
	}

	private static void _0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(selectionStatusType _0023_003DzNWtosWYCtxJL, Entity _0023_003DziGd2KgU_003D, List<SelectionInfoSubItems> _0023_003DzIJnKYg2rS5Pe, List<SelectedItem> _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D)
	{
		for (int i = 0; i < _0023_003DzIJnKYg2rS5Pe.Count; i++)
		{
			SelectionInfo[] subItems = _0023_003DzIJnKYg2rS5Pe[i].SubItems;
			if (subItems == null)
			{
				continue;
			}
			for (int j = 0; j < subItems.Length; j++)
			{
				if (subItems[j].IsFlagSet(_0023_003DzNWtosWYCtxJL))
				{
					_0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D.Add(new SelectedItem(_0023_003DzIJnKYg2rS5Pe[i].Parents, _0023_003DziGd2KgU_003D));
					break;
				}
			}
		}
	}

	private static void _0023_003DzO7DSAO_0024_0024ywwVYELaeacUoeA_003D(selectionStatusType _0023_003DzNWtosWYCtxJL, Entity _0023_003DziGd2KgU_003D, List<SelectionInfoSubItemsArray> _0023_003DzIJnKYg2rS5Pe, List<SelectedItem> _0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D)
	{
		for (int i = 0; i < _0023_003DzIJnKYg2rS5Pe.Count; i++)
		{
			SelectionInfo[][] subItems = _0023_003DzIJnKYg2rS5Pe[i].SubItems;
			for (int j = 0; j < subItems.GetLength(0); j++)
			{
				SelectionInfo[] array = subItems[j];
				if (array == null)
				{
					continue;
				}
				for (int k = 0; k < array.Length; k++)
				{
					if (array[k].IsFlagSet(_0023_003DzNWtosWYCtxJL))
					{
						_0023_003Dzj90zZ_0024RCAIumfnX_0024Cg_003D_003D.Add(new SelectedItem(_0023_003DzIJnKYg2rS5Pe[i].Parents, _0023_003DziGd2KgU_003D));
					}
				}
			}
		}
	}

	private void _0023_003Dz0sYWuTi_0024wtyB(MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		Viewport _0023_003DzYzWi5Yw_003D = _0023_003DzipBYly6zFKAp();
		if (_0023_003Dz1SmHC4c_003D.Button == MouseButtons.Left && _0023_003DzjGvm17_0024DzsnS == actionType.ZoomWindow)
		{
			if (_0023_003DzjRmmVH2Hj_0024KY.X != _0023_003Dztt6EItoclqV3.X && _0023_003DzjRmmVH2Hj_0024KY.Y != _0023_003Dztt6EItoclqV3.Y)
			{
				ZoomWindow(_0023_003DzjRmmVH2Hj_0024KY, _0023_003Dztt6EItoclqV3);
				Invalidate();
			}
			_0023_003Dzz2f3UQo_003D = false;
		}
		if ((_0023_003Dz1SmHC4c_003D.Button != MouseButtons.Left || !IsSelectByBoxAction()) && !IsSelectByPolygonAction())
		{
			return;
		}
		SelectionChangedEventArgs e = new SelectionChangedEventArgs();
		if (_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003DzF3HKD2trntQC())
		{
			return;
		}
		bool flag = _0023_003DzWct4wogVWy2w();
		if (IsSelectByPolygonAction())
		{
			if (_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003Dz0sYWuTi_0024wtyB(_0023_003Dz1SmHC4c_003D, this, _0023_003DzYzWi5Yw_003D))
			{
				_0023_003Dz0_czIjY3d3YXM7nQVA_003D_003D(flag, _0023_003DzYzWi5Yw_003D, e, _0023_003DzUsW18wvfQQpu: false);
				switch (_0023_003DzjGvm17_0024DzsnS)
				{
				case actionType.SelectByPolygon:
					ProcessSelectionByPolygon(_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003Dzc9XpdZjCbZ5c, flag, e);
					_0023_003Dzvt4CNgJSomsF(e);
					break;
				case actionType.SelectByPolygonEnclosed:
					ProcessSelectionByPolygonEnclosed(_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003Dzc9XpdZjCbZ5c, flag, e);
					_0023_003Dzvt4CNgJSomsF(e);
					break;
				case actionType.SelectVisibleByPolygon:
					ProcessSelectionByPolygonVisibleOnly(_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003Dzc9XpdZjCbZ5c, flag, e);
					_0023_003Dzvt4CNgJSomsF(e);
					break;
				}
			}
			if (!_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzF3HKD2trntQC())
			{
				_0023_003Dzz2f3UQo_003D = false;
			}
			return;
		}
		_0023_003Dz0_czIjY3d3YXM7nQVA_003D_003D(flag, _0023_003DzYzWi5Yw_003D, e, _0023_003DzUsW18wvfQQpu: false);
		if (Entities.Count > 0)
		{
			_0023_003DznsHxfVrI76un(out var _0023_003DzN0be4hzcg7Lk, out var _, out var _0023_003Dz0ERMHbg_003D);
			if (_0023_003Dz1SmHC4c_003D.Button == MouseButtons.Left)
			{
				Rectangle selectionBox = _0023_003DzLihM0a_0024fTauw(_0023_003DzYzWi5Yw_003D, _0023_003DzN0be4hzcg7Lk, _0023_003Dz0ERMHbg_003D, _0023_003DzeUi9A7zbcNV048FIvQ_003D_003D: false);
				switch (_0023_003DzjGvm17_0024DzsnS)
				{
				case actionType.SelectVisibleByBox:
					ProcessSelectionVisibleOnly(selectionBox, firstOnly: false, flag, e);
					_0023_003Dzvt4CNgJSomsF(e);
					break;
				case actionType.SelectByBox:
					ProcessSelection(selectionBox, firstOnly: false, flag, e);
					_0023_003Dzvt4CNgJSomsF(e);
					break;
				case actionType.SelectByBoxEnclosed:
					ProcessSelectionEnclosed(selectionBox, firstOnly: false, flag, e);
					_0023_003Dzvt4CNgJSomsF(e);
					break;
				}
			}
		}
		_0023_003Dzz2f3UQo_003D = false;
	}

	private void _0023_003DznsHxfVrI76un(out System.Drawing.Point _0023_003DzN0be4hzcg7Lk, out System.Drawing.Point _0023_003DzAlSEyrsFhJ1u, out Size _0023_003Dz0ERMHbg_003D)
	{
		_0023_003DzN0be4hzcg7Lk = new System.Drawing.Point(_0023_003DzjRmmVH2Hj_0024KY.X, _0023_003DzjRmmVH2Hj_0024KY.Y);
		_0023_003DzAlSEyrsFhJ1u = new System.Drawing.Point(_0023_003Dztt6EItoclqV3.X, _0023_003Dztt6EItoclqV3.Y);
		Utility.NormalizeBox(ref _0023_003DzN0be4hzcg7Lk, ref _0023_003DzAlSEyrsFhJ1u);
		_0023_003Dz0ERMHbg_003D = new Size(_0023_003DzAlSEyrsFhJ1u.X - _0023_003DzN0be4hzcg7Lk.X, _0023_003DzAlSEyrsFhJ1u.Y - _0023_003DzN0be4hzcg7Lk.Y);
		if (_0023_003Dz0ERMHbg_003D.Width < 1)
		{
			_0023_003Dz0ERMHbg_003D.Width = 1;
		}
		if (_0023_003Dz0ERMHbg_003D.Height < 1)
		{
			_0023_003Dz0ERMHbg_003D.Height = 1;
		}
	}

	public virtual void ProcessSelectionByPolygon(List<Point2D> selectionPolygon, bool invert, SelectionChangedEventArgs eventArgs)
	{
		_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzTpZvGLfXRihX(this, selectionPolygon, invert, eventArgs, _0023_003Dzc_0024FDVjzZMRWW: true, _0023_003Dz_bIfLEkNPFmB: false, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, out var _, actionType.SelectByPolygon);
		_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzxEpSi5o_003D();
	}

	public virtual void ProcessSelectionByPolygonEnclosed(List<Point2D> selectionPolygon, bool invert, SelectionChangedEventArgs eventArgs)
	{
		_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzTpZvGLfXRihX(this, selectionPolygon, invert, eventArgs, _0023_003Dzc_0024FDVjzZMRWW: true, _0023_003Dz_bIfLEkNPFmB: false, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, out var _, actionType.SelectByPolygonEnclosed);
		_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzxEpSi5o_003D();
	}

	public virtual void ProcessSelectionByPolygonVisibleOnly(List<Point2D> selectionPolygon, bool invert, SelectionChangedEventArgs eventArgs)
	{
		_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzTpZvGLfXRihX(this, selectionPolygon, invert, eventArgs, _0023_003Dzc_0024FDVjzZMRWW: true, _0023_003Dz_bIfLEkNPFmB: false, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, out var _, actionType.SelectVisibleByPolygon);
		_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzxEpSi5o_003D();
	}

	private Rectangle _0023_003DzLihM0a_0024fTauw(Viewport _0023_003DzYzWi5Yw_003D, System.Drawing.Point _0023_003DzJuGpJ5OaPxY3FXC7hA_003D_003D, Size _0023_003Dz0ERMHbg_003D, bool _0023_003DzeUi9A7zbcNV048FIvQ_003D_003D)
	{
		System.Drawing.Point point = _0023_003DzYzWi5Yw_003D.ViewportToScreen(_0023_003DzJuGpJ5OaPxY3FXC7hA_003D_003D);
		if (_0023_003DzeUi9A7zbcNV048FIvQ_003D_003D)
		{
			return new Rectangle(point.X - _0023_003Dz0ERMHbg_003D.Width / 2, point.Y - _0023_003Dz0ERMHbg_003D.Height / 2, _0023_003Dz0ERMHbg_003D.Width, _0023_003Dz0ERMHbg_003D.Height);
		}
		return new Rectangle(point.X, point.Y, _0023_003Dz0ERMHbg_003D.Width, _0023_003Dz0ERMHbg_003D.Height);
	}

	public virtual void ProcessSelectionVisibleOnly(Rectangle selectionBox, bool firstOnly, bool invert, SelectionChangedEventArgs eventArgs, bool selectableOnly = true, bool temporarySelection = false)
	{
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		if (viewport.DisplayMode == displayType.Wireframe && (_0023_003Dz28QCun7pbbWH & selectionFilterType.Face) != 0)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595419));
		}
		_0023_003DzXVHxU6dYdxpX(viewport, selectionBox, firstOnly, _0023_003DzOWfUZLjOSimJ(), (_0023_003DzhFBmu_0024RpnRJ7)8, selectableOnly, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DznugYzyWkU3Do == assemblySelectionType.Leaf, out var _0023_003DzzDNdOMv1nCY_0024);
		if (this is Drawing drawing)
		{
			drawing._0023_003DzhXHsF9Hmeau3m_pM3g_003D_003D(selectionBox, firstOnly, selectableOnly, temporarySelection, ref _0023_003DzzDNdOMv1nCY_0024);
		}
		if (_0023_003DzzDNdOMv1nCY_0024.Length > 1)
		{
			viewport.Camera.ZBufferData.SelectionImage.InnerSelectionImage = null;
			_0023_003DzlA0QuPF2P1Np = null;
		}
		else if (_0023_003DzzDNdOMv1nCY_0024.Length == 1 && !_0023_003DzzDNdOMv1nCY_0024[0].Equals(_0023_003DzlA0QuPF2P1Np))
		{
			viewport.Camera.ZBufferData.SelectionImage.InnerSelectionImage = null;
			_0023_003DzlA0QuPF2P1Np = _0023_003DzzDNdOMv1nCY_0024[0];
		}
		_0023_003DzHeomB7BdNilY(invert, _0023_003DzzDNdOMv1nCY_0024, eventArgs, temporarySelection);
		if (eventArgs.AddedItems.Count > 0 || eventArgs.RemovedItems.Count > 0)
		{
			_0023_003DzhLlx9pGQbe0q(viewport, selectionBox, firstOnly, invert, eventArgs, temporarySelection);
		}
	}

	internal _0023_003DzhFBmu_0024RpnRJ7 _0023_003Dzf4r6oggNIe3m(selectionFilterType _0023_003DzMtZEKzTzhR_w)
	{
		return _0023_003DzMtZEKzTzhR_w switch
		{
			selectionFilterType.Vertex | selectionFilterType.Edge | selectionFilterType.Face => (_0023_003DzhFBmu_0024RpnRJ7)7, 
			selectionFilterType.Edge | selectionFilterType.Face => (_0023_003DzhFBmu_0024RpnRJ7)3, 
			selectionFilterType.Vertex | selectionFilterType.Face => (_0023_003DzhFBmu_0024RpnRJ7)5, 
			selectionFilterType.Vertex | selectionFilterType.Edge => (_0023_003DzhFBmu_0024RpnRJ7)6, 
			selectionFilterType.Edge => (_0023_003DzhFBmu_0024RpnRJ7)2, 
			selectionFilterType.Face => (_0023_003DzhFBmu_0024RpnRJ7)1, 
			selectionFilterType.Vertex => (_0023_003DzhFBmu_0024RpnRJ7)4, 
			selectionFilterType.SubCurve => (_0023_003DzhFBmu_0024RpnRJ7)128, 
			selectionFilterType.Contour => (_0023_003DzhFBmu_0024RpnRJ7)256, 
			selectionFilterType.SketchPoint => (_0023_003DzhFBmu_0024RpnRJ7)512, 
			selectionFilterType.SketchCurve => (_0023_003DzhFBmu_0024RpnRJ7)1024, 
			selectionFilterType.SketchPoint | selectionFilterType.SketchCurve => (_0023_003DzhFBmu_0024RpnRJ7)1536, 
			_ => (_0023_003DzhFBmu_0024RpnRJ7)8, 
		};
	}

	private SelectedItem[] _0023_003DzIBIolpLAymgla__wFA_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, Rectangle _0023_003DzCiKS5oMdHowF, _0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX, bool _0023_003Dz_bIfLEkNPFmB, SelectedItem[] _0023_003Dzz8hA2KsjwaLa)
	{
		List<SelectedItem> list = new List<SelectedItem>();
		foreach (SelectedItem selectedItem in _0023_003Dzz8hA2KsjwaLa)
		{
			if (_0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)1)
			{
				if (!(selectedItem.Item is IFaceSelectable))
				{
					continue;
				}
			}
			else if (!(selectedItem.Item is Brep))
			{
				continue;
			}
			List<Entity> list2 = new List<Entity>();
			if (selectedItem.Parents.Count > 0)
			{
				list2.Add(new NestedEntity(selectedItem, Layers, Blocks, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D));
			}
			else
			{
				list2.Add((Entity)selectedItem.Item);
			}
			SelectedItem[] _0023_003DzzDNdOMv1nCY_0024;
			int[] _0023_003DzKHBiu_4_003D = _0023_003DzXVHxU6dYdxpX(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, list2, _0023_003DzbOk8RJDeO_0024TX, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out _0023_003DzzDNdOMv1nCY_0024);
			if (!(selectedItem.Item is Brep) && _0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)1)
			{
				_0023_003DzzDNdOMv1nCY_0024 = _0023_003DzSa9nQc1fooX_Sorh5w_003D_003D(selectionStatusType.None, _0023_003DzKHBiu_4_003D, selectedItem).ToArray();
			}
			if (_0023_003DzzDNdOMv1nCY_0024 != null)
			{
				list.AddRange(_0023_003DzzDNdOMv1nCY_0024);
			}
			if (_0023_003Dzz8hA2KsjwaLa.Length != 0)
			{
				_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerSelectionImage = null;
			}
		}
		return list.ToArray();
	}

	private void _0023_003DzhLlx9pGQbe0q(Viewport _0023_003DzYzWi5Yw_003D, Rectangle _0023_003DzCiKS5oMdHowF, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003Dz7MoFvcekkC14, SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e, bool _0023_003DzUsW18wvfQQpu)
	{
		List<SelectedItem> list = new List<SelectedItem>();
		List<SelectedItem> list2 = new List<SelectedItem>();
		foreach (SelectedItem removedItem in _0023_003DzdXQchgXOgG_0024e.RemovedItems)
		{
			list.Add(removedItem);
		}
		foreach (SelectedItem addedItem in _0023_003DzdXQchgXOgG_0024e.AddedItems)
		{
			list2.Add(addedItem);
		}
		if (_0023_003Dz28QCun7pbbWH != selectionFilterType.Entity && _0023_003Dz28QCun7pbbWH != selectionFilterType.Face)
		{
			base.RenderContext.BeginDrawForSelection();
			_0023_003Dzxc6oSybIdBLIrJSFqQXbitE_003D(_0023_003DzYzWi5Yw_003D, list2);
			base.RenderContext.EndDrawForSelection();
		}
		selectionStatusType selectionFlag = SelectionInfo.GetSelectionFlag(_0023_003DzUsW18wvfQQpu);
		List<SelectedItem> _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D = new List<SelectedItem>();
		switch (_0023_003Dz28QCun7pbbWH)
		{
		case selectionFilterType.Entity:
			foreach (SelectedItem item in list)
			{
				if (item.Item is ISelectableSubItems)
				{
					((ISelectableSubItems)item.Item).SelectionMode = selectionFilterType.Entity;
				}
			}
			{
				foreach (SelectedItem item2 in list2)
				{
					if (item2.Item is ISelectableSubItems)
					{
						((ISelectableSubItems)item2.Item).SelectionMode = selectionFilterType.Entity;
					}
				}
				break;
			}
		case selectionFilterType.Face:
			_0023_003Dz5JIWc1YYthkl(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e, _0023_003DzUsW18wvfQQpu, selectionFlag, list2, list, _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D);
			_0023_003DzJa1B3sZRP9Q_tN8hZunTwIk_003D(_0023_003DzdXQchgXOgG_0024e.AddedItems);
			_0023_003DzJa1B3sZRP9Q_tN8hZunTwIk_003D(_0023_003DzdXQchgXOgG_0024e.RemovedItems);
			break;
		case selectionFilterType.Edge:
			_0023_003Dz19wnfFsMuEO7<SelectedEdge>(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e, _0023_003DzUsW18wvfQQpu, selectionFlag, list2, list, _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D, (_0023_003DzhFBmu_0024RpnRJ7)2);
			_0023_003DzgWIc6ZcYe8wWN1BkJQ_003D_003D(_0023_003DzdXQchgXOgG_0024e.AddedItems);
			_0023_003DzgWIc6ZcYe8wWN1BkJQ_003D_003D(_0023_003DzdXQchgXOgG_0024e.RemovedItems);
			break;
		case selectionFilterType.Vertex:
			_0023_003Dz19wnfFsMuEO7<SelectedVertex>(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e, _0023_003DzUsW18wvfQQpu, selectionFlag, list2, list, _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D, (_0023_003DzhFBmu_0024RpnRJ7)4);
			_0023_003Dz2fwAXs_tSXBu29lQwpmVSwd_57up(_0023_003DzdXQchgXOgG_0024e.AddedItems);
			_0023_003Dz2fwAXs_tSXBu29lQwpmVSwd_57up(_0023_003DzdXQchgXOgG_0024e.RemovedItems);
			break;
		case selectionFilterType.SubCurve:
			_0023_003Dz19wnfFsMuEO7(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e, _0023_003DzUsW18wvfQQpu, selectionFlag, list2, list, _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D);
			_0023_003Dz7VZzFZd5J8XZyi9m3JNFRw5sxqKX(_0023_003DzdXQchgXOgG_0024e.AddedItems);
			_0023_003Dz7VZzFZd5J8XZyi9m3JNFRw5sxqKX(_0023_003DzdXQchgXOgG_0024e.RemovedItems);
			break;
		case selectionFilterType.Contour:
			_0023_003Dz19wnfFsMuEO7(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e, _0023_003DzUsW18wvfQQpu, selectionFlag, list2, list, _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D);
			_0023_003Dzw9XxIwI_fQrcYf0qj16irkOKgMt2(_0023_003DzdXQchgXOgG_0024e.AddedItems);
			_0023_003Dzw9XxIwI_fQrcYf0qj16irkOKgMt2(_0023_003DzdXQchgXOgG_0024e.RemovedItems);
			break;
		case selectionFilterType.SketchPoint:
		case selectionFilterType.SketchCurve:
		case selectionFilterType.SketchPoint | selectionFilterType.SketchCurve:
			_0023_003Dz19wnfFsMuEO7(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e, _0023_003DzUsW18wvfQQpu, selectionFlag, list2, list, _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D);
			_0023_003Dzw9XxIwI_fQrcYf0qj16irkOKgMt2(_0023_003DzdXQchgXOgG_0024e.AddedItems);
			_0023_003Dzw9XxIwI_fQrcYf0qj16irkOKgMt2(_0023_003DzdXQchgXOgG_0024e.RemovedItems);
			break;
		case selectionFilterType.Vertex | selectionFilterType.Edge:
		case selectionFilterType.Vertex | selectionFilterType.Face:
		case selectionFilterType.Edge | selectionFilterType.Face:
		case selectionFilterType.Vertex | selectionFilterType.Edge | selectionFilterType.Face:
			_0023_003Dz19wnfFsMuEO7(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, _0023_003Dz7MoFvcekkC14, _0023_003DzdXQchgXOgG_0024e, _0023_003DzUsW18wvfQQpu, selectionFlag, list2, list, _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D);
			_0023_003Dzad6sPY_XTsvE4TDz1icpcHx63cZ7VYPS9A_003D_003D(_0023_003DzdXQchgXOgG_0024e.AddedItems);
			_0023_003Dzad6sPY_XTsvE4TDz1icpcHx63cZ7VYPS9A_003D_003D(_0023_003DzdXQchgXOgG_0024e.RemovedItems);
			break;
		}
	}

	private static void _0023_003DzJa1B3sZRP9Q_tN8hZunTwIk_003D(IList<SelectedItem> _0023_003DzUl92GdI_003D)
	{
		for (int i = 0; i < _0023_003DzUl92GdI_003D.Count; i++)
		{
			SelectedItem selectedItem = _0023_003DzUl92GdI_003D[i];
			if (selectedItem.Item is IFaceSelectable && !((IFaceSelectable)selectedItem.Item).IsAnyFaceSelected())
			{
				((IFaceSelectable)selectedItem.Item).ClearFacesSelectionForAllInstances();
			}
		}
	}

	private static void _0023_003Dz7VZzFZd5J8XZyi9m3JNFRw5sxqKX(IList<SelectedItem> _0023_003DzUl92GdI_003D)
	{
		for (int i = 0; i < _0023_003DzUl92GdI_003D.Count; i++)
		{
			if (_0023_003DzUl92GdI_003D[i].Item is CompositeCurve compositeCurve && !compositeCurve.IsAnySubCurveSelected())
			{
				compositeCurve.ClearSubCurvesSelectionForAllInstances();
			}
		}
	}

	private static void _0023_003Dzw9XxIwI_fQrcYf0qj16irkOKgMt2(IList<SelectedItem> _0023_003DzUl92GdI_003D)
	{
		for (int i = 0; i < _0023_003DzUl92GdI_003D.Count; i++)
		{
			if (_0023_003DzUl92GdI_003D[i].Item is devDept.Eyeshot.Entities.Region region && !region.IsAnySubContourSelected())
			{
				region.ClearSubContoursSelectionForAllInstances();
			}
		}
	}

	private static void _0023_003Dzad6sPY_XTsvE4TDz1icpcHx63cZ7VYPS9A_003D_003D(IList<SelectedItem> _0023_003DzUl92GdI_003D)
	{
		for (int i = 0; i < _0023_003DzUl92GdI_003D.Count; i++)
		{
			if (_0023_003DzUl92GdI_003D[i].Item is Brep brep)
			{
				if (!brep.IsAnyFaceSelected())
				{
					brep.ClearFacesSelectionForAllInstances();
				}
				if (!brep.IsAnyEdgeSelected())
				{
					brep.ClearEdgesSelectionForAllInstances();
				}
				if (!brep.IsAnyVertexSelected())
				{
					brep.ClearVerticesSelectionForAllInstances();
				}
			}
		}
	}

	private static void _0023_003DzgWIc6ZcYe8wWN1BkJQ_003D_003D(IList<SelectedItem> _0023_003DzUl92GdI_003D)
	{
		for (int i = 0; i < _0023_003DzUl92GdI_003D.Count; i++)
		{
			SelectedItem selectedItem = _0023_003DzUl92GdI_003D[i];
			if (selectedItem.Item is Brep && !((Brep)selectedItem.Item).IsAnyEdgeSelected())
			{
				((Brep)selectedItem.Item).ClearEdgesSelectionForAllInstances();
			}
		}
	}

	private static void _0023_003Dz2fwAXs_tSXBu29lQwpmVSwd_57up(IList<SelectedItem> _0023_003DzUl92GdI_003D)
	{
		for (int i = 0; i < _0023_003DzUl92GdI_003D.Count; i++)
		{
			SelectedItem selectedItem = _0023_003DzUl92GdI_003D[i];
			if (selectedItem.Item is Brep && !((Brep)selectedItem.Item).IsAnyVertexSelected())
			{
				((Brep)selectedItem.Item).ClearVerticesSelectionForAllInstances();
			}
		}
	}

	private void _0023_003Dzxc6oSybIdBLIrJSFqQXbitE_003D(Viewport _0023_003DzYzWi5Yw_003D, List<SelectedItem> _0023_003Dz_0024SzJEIUmuSdJ)
	{
		if (_0023_003Dz_0024SzJEIUmuSdJ.Count <= 0)
		{
			return;
		}
		List<Entity> list = new List<Entity>();
		for (int i = 0; i < _0023_003Dz_0024SzJEIUmuSdJ.Count; i++)
		{
			SelectedItem selectedItem = _0023_003Dz_0024SzJEIUmuSdJ[i];
			if (selectedItem.HasParents())
			{
				list.Add(new NestedEntity(selectedItem, Layers, Blocks, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D));
			}
			else
			{
				list.Add((Entity)selectedItem.Item);
			}
		}
		_0023_003DzHcYFj1p87o4J(_0023_003DzYzWi5Yw_003D, list);
	}

	private void _0023_003Dz19wnfFsMuEO7(Viewport _0023_003DzYzWi5Yw_003D, Rectangle _0023_003DzCiKS5oMdHowF, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003Dz7MoFvcekkC14, SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e, bool _0023_003DzUsW18wvfQQpu, selectionStatusType _0023_003DzNWtosWYCtxJL, List<SelectedItem> _0023_003DzdqySRM5BCRQG, List<SelectedItem> _0023_003Dz3NenWUqwkcW4, List<SelectedItem> _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D)
	{
		bool flag = !_0023_003Dz4xY7BXVU46SkGzfQtg_003D_003D();
		List<SelectedItem> list = new List<SelectedItem>();
		List<SelectedItem> list2 = new List<SelectedItem>();
		for (int i = 0; i < _0023_003Dz3NenWUqwkcW4.Count; i++)
		{
			SelectedItem selectedItem = _0023_003Dz3NenWUqwkcW4[i];
			List<SelectedSubItem> list3 = new List<SelectedSubItem>();
			if (selectedItem.Item is Brep)
			{
				Brep brep = (Brep)selectedItem.Item;
				SelectionInfoSubItems selectionInfoSubItems = null;
				if ((_0023_003Dz28QCun7pbbWH & selectionFilterType.Vertex) != 0)
				{
					selectionInfoSubItems = SelectionInfoItemBase.FindInstance(selectedItem.Parents, brep, null, brep.VerticesSelectionInfo);
					if (selectionInfoSubItems != null)
					{
						list3.AddRange(Entity.ClearChildrenItemsSelection<SelectedVertex>(_0023_003DzNWtosWYCtxJL, selectedItem.Parents, selectedItem.Item, selectionInfoSubItems.SubItems, 0));
					}
				}
				if ((_0023_003Dz28QCun7pbbWH & selectionFilterType.Edge) != 0)
				{
					selectionInfoSubItems = SelectionInfoItemBase.FindInstance(selectedItem.Parents, brep, null, brep.EdgesSelectionInfo);
					if (selectionInfoSubItems != null)
					{
						list3.AddRange(Entity.ClearChildrenItemsSelection<SelectedEdge>(_0023_003DzNWtosWYCtxJL, selectedItem.Parents, selectedItem.Item, selectionInfoSubItems.SubItems, 0));
					}
				}
				if ((_0023_003Dz28QCun7pbbWH & selectionFilterType.Face) != 0)
				{
					selectionInfoSubItems = SelectionInfoItemBase.FindInstance(selectedItem.Parents, brep, null, brep.FacesSelectionInfo);
					if (selectionInfoSubItems != null)
					{
						list3.AddRange(Entity.ClearChildrenItemsSelection<SelectedFace>(_0023_003DzNWtosWYCtxJL, selectedItem.Parents, selectedItem.Item, selectionInfoSubItems.SubItems, 0));
					}
					Stack<BlockReference> parents = selectedItem.Parents;
					List<SelectionInfoSubItemsArray> innerFacesSelectionInfo = brep.InnerFacesSelectionInfo;
					object[][] inners = brep.Inners;
					SelectionInfoSubItemsArray selectionInfoSubItemsArray = SelectionInfoItemBase.FindInstanceOrCreate(parents, brep, null, innerFacesSelectionInfo, -1, inners);
					if (selectionInfoSubItemsArray != null)
					{
						for (int j = 0; j < brep.Inners.Length; j++)
						{
							int _0023_003DzRLCcpW4_003D = j + 1;
							list3.AddRange(Entity.ClearChildrenItemsSelection<SelectedFace>(_0023_003DzNWtosWYCtxJL, selectedItem.Parents, selectedItem.Item, selectionInfoSubItemsArray.SubItems[j], _0023_003DzRLCcpW4_003D));
						}
					}
				}
				brep.ResetSelectionMode();
			}
			else if (selectedItem.Item is CompositeCurve compositeCurve)
			{
				if (_0023_003Dz28QCun7pbbWH == selectionFilterType.SubCurve)
				{
					SelectionInfoSubItems selectionInfoSubItems2 = SelectionInfoItemBase.FindInstance(selectedItem.Parents, compositeCurve, null, compositeCurve.SubCurvesSelectionInfo);
					if (selectionInfoSubItems2 != null)
					{
						list3.AddRange(Entity.ClearChildrenItemsSelection<SelectedSubCurve>(_0023_003DzNWtosWYCtxJL, selectedItem.Parents, selectedItem.Item, selectionInfoSubItems2.SubItems, 0));
					}
				}
			}
			else if (selectedItem.Item is devDept.Eyeshot.Entities.Region region)
			{
				if (_0023_003Dz28QCun7pbbWH == selectionFilterType.Contour)
				{
					SelectionInfoSubItems selectionInfoSubItems3 = SelectionInfoItemBase.FindInstance(selectedItem.Parents, region, null, region.SubContoursSelectionInfo);
					if (selectionInfoSubItems3 != null)
					{
						list3.AddRange(Entity.ClearChildrenItemsSelection<SelectedSubCurve>(_0023_003DzNWtosWYCtxJL, selectedItem.Parents, selectedItem.Item, selectionInfoSubItems3.SubItems, 0));
					}
				}
			}
			else if (selectedItem.Item is SketchEntity sketchEntity)
			{
				if ((_0023_003Dz28QCun7pbbWH & selectionFilterType.SketchPoint) != 0 || (_0023_003Dz28QCun7pbbWH & selectionFilterType.SketchCurve) != 0)
				{
					SelectionInfoSubItems selectionInfoSubItems4 = SelectionInfoItemBase.FindInstance(selectedItem.Parents, sketchEntity, null, sketchEntity.SketchCurvesSelectionInfo);
					if (selectionInfoSubItems4 != null)
					{
						list3.AddRange(Entity.ClearChildrenItemsSelection<SelectedSketchCurve>(_0023_003DzNWtosWYCtxJL, selectedItem.Parents, selectedItem.Item, selectionInfoSubItems4.SubItems, 0));
					}
				}
			}
			else if (selectedItem.Item is ISelectableSubItems)
			{
				((ISelectableSubItems)selectedItem.Item).ResetSelectionMode();
			}
			if (list3.Count > 0)
			{
				list2.AddRange(list3);
			}
			else if (flag)
			{
				list2.Add(selectedItem);
			}
		}
		for (int k = 0; k < _0023_003DzdqySRM5BCRQG.Count; k++)
		{
			SelectedItem selectedItem2 = _0023_003DzdqySRM5BCRQG[k];
			if (!_0023_003Dze9MbzCCjOmNj(selectedItem2, out var _0023_003Dz_SRj_0024i0GYVwn, out var _0023_003Dzt0s9LQY_003D, out var _0023_003Dzc4701QQ_003D, out var _0023_003Dzpc5uZPefj7RL))
			{
				continue;
			}
			List<Entity> list4 = new List<Entity>();
			if (selectedItem2.Parents.Count > 0)
			{
				list4.Add(new NestedEntity(selectedItem2, Layers, Blocks, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D));
			}
			else
			{
				list4.Add((Entity)selectedItem2.Item);
			}
			_0023_003DzhFBmu_0024RpnRJ7 _0023_003DzhFBmu_0024RpnRJ8 = _0023_003Dzf4r6oggNIe3m(_0023_003Dz28QCun7pbbWH);
			_0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, list4, _0023_003DzhFBmu_0024RpnRJ8, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out var _0023_003DzzDNdOMv1nCY_0024);
			if (_0023_003DzzDNdOMv1nCY_0024.Length == 0)
			{
				continue;
			}
			SelectionInfoSubItems selectionInfoSubItems5 = null;
			SelectionInfoSubItems selectionInfoSubItems6 = null;
			SelectionInfoSubItems selectionInfoSubItems7 = null;
			SelectionInfoSubItems selectionInfoSubItems8 = null;
			SelectionInfoSubItems selectionInfoSubItems9 = null;
			SelectionInfoSubItems selectionInfoSubItems10 = null;
			SelectionInfoSubItemsArray selectionInfoSubItemsArray2 = null;
			List<SelectionInfoSubItems> list5 = new List<SelectionInfoSubItems>();
			switch (_0023_003DzhFBmu_0024RpnRJ8)
			{
			case (_0023_003DzhFBmu_0024RpnRJ7)128:
				selectionInfoSubItems5 = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, _0023_003Dzt0s9LQY_003D, null, _0023_003Dzt0s9LQY_003D.SubCurvesSelectionInfo, _0023_003Dzt0s9LQY_003D.CurveList.Count);
				list5.AddRange(_0023_003Dzt0s9LQY_003D.SubCurvesSelectionInfo);
				if (selectionInfoSubItems5.SubItems == null)
				{
					selectionInfoSubItems5.InitSubItems(_0023_003Dzt0s9LQY_003D.CurveList.Count);
				}
				break;
			case (_0023_003DzhFBmu_0024RpnRJ7)256:
				selectionInfoSubItems6 = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, _0023_003Dzc4701QQ_003D, null, _0023_003Dzc4701QQ_003D.SubContoursSelectionInfo, _0023_003Dzc4701QQ_003D.ContourList.Count);
				list5.AddRange(_0023_003Dzc4701QQ_003D.SubContoursSelectionInfo);
				if (selectionInfoSubItems6.SubItems == null)
				{
					selectionInfoSubItems6.InitSubItems(_0023_003Dzc4701QQ_003D.ContourList.Count);
				}
				break;
			default:
				if ((_0023_003DzhFBmu_0024RpnRJ8 & (_0023_003DzhFBmu_0024RpnRJ7)4) != 0)
				{
					selectionInfoSubItems8 = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, _0023_003Dz_SRj_0024i0GYVwn, null, _0023_003Dz_SRj_0024i0GYVwn.VerticesSelectionInfo, _0023_003Dz_SRj_0024i0GYVwn.Vertices.Length);
					list5.AddRange(_0023_003Dz_SRj_0024i0GYVwn.VerticesSelectionInfo);
					if (selectionInfoSubItems8.SubItems == null)
					{
						selectionInfoSubItems8.InitSubItems(_0023_003Dz_SRj_0024i0GYVwn.Vertices.Length);
					}
				}
				if ((_0023_003DzhFBmu_0024RpnRJ8 & (_0023_003DzhFBmu_0024RpnRJ7)2) != 0)
				{
					selectionInfoSubItems9 = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, _0023_003Dz_SRj_0024i0GYVwn, null, _0023_003Dz_SRj_0024i0GYVwn.EdgesSelectionInfo, _0023_003Dz_SRj_0024i0GYVwn.Edges.Length);
					list5.AddRange(_0023_003Dz_SRj_0024i0GYVwn.EdgesSelectionInfo);
					if (selectionInfoSubItems9.SubItems == null)
					{
						selectionInfoSubItems9.InitSubItems(_0023_003Dz_SRj_0024i0GYVwn.Edges.Length);
					}
				}
				if ((_0023_003DzhFBmu_0024RpnRJ8 & (_0023_003DzhFBmu_0024RpnRJ7)1) != 0)
				{
					selectionInfoSubItems10 = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, _0023_003Dz_SRj_0024i0GYVwn, null, _0023_003Dz_SRj_0024i0GYVwn.FacesSelectionInfo, ((Brep)selectedItem2.Item).Faces.Length);
					Stack<BlockReference> parents2 = selectedItem2.Parents;
					Brep _0023_003Dzs_0024uS8LA_003D = _0023_003Dz_SRj_0024i0GYVwn;
					List<SelectionInfoSubItemsArray> innerFacesSelectionInfo2 = _0023_003Dz_SRj_0024i0GYVwn.InnerFacesSelectionInfo;
					object[][] inners = _0023_003Dz_SRj_0024i0GYVwn.Inners;
					selectionInfoSubItemsArray2 = SelectionInfoItemBase.FindInstanceOrCreate(parents2, _0023_003Dzs_0024uS8LA_003D, null, innerFacesSelectionInfo2, -1, inners);
					list5.AddRange(_0023_003Dz_SRj_0024i0GYVwn.FacesSelectionInfo);
					if (selectionInfoSubItems10.SubItems == null)
					{
						selectionInfoSubItems10.InitSubItems(_0023_003Dz_SRj_0024i0GYVwn.Faces.Length);
					}
					if (selectionInfoSubItemsArray2.SubItems == null)
					{
						SelectionInfoSubItemsArray selectionInfoSubItemsArray3 = selectionInfoSubItemsArray2;
						inners = _0023_003Dz_SRj_0024i0GYVwn.Inners;
						selectionInfoSubItemsArray3.InitSubItemsArray(inners);
					}
				}
				if ((_0023_003DzhFBmu_0024RpnRJ8 & (_0023_003DzhFBmu_0024RpnRJ7)1024) != 0 || (_0023_003DzhFBmu_0024RpnRJ8 & (_0023_003DzhFBmu_0024RpnRJ7)512) != 0)
				{
					int count = _0023_003Dzpc5uZPefj7RL.CurveList.Count;
					selectionInfoSubItems7 = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, _0023_003Dzpc5uZPefj7RL, null, _0023_003Dzpc5uZPefj7RL.SketchCurvesSelectionInfo, count);
					list5.AddRange(_0023_003Dzpc5uZPefj7RL.SketchCurvesSelectionInfo);
					if (selectionInfoSubItems7.SubItems == null)
					{
						selectionInfoSubItems7.InitSubItems(count);
					}
				}
				break;
			}
			Dictionary<selectionFilterType, Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>> dictionary = new Dictionary<selectionFilterType, Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>>();
			dictionary[selectionFilterType.Vertex] = new Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>(selectionInfoSubItems8, null);
			dictionary[selectionFilterType.Edge] = new Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>(selectionInfoSubItems9, null);
			dictionary[selectionFilterType.Face] = new Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>(selectionInfoSubItems10, selectionInfoSubItemsArray2);
			dictionary[selectionFilterType.SubCurve] = new Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>(selectionInfoSubItems5, null);
			dictionary[selectionFilterType.Contour] = new Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>(selectionInfoSubItems6, null);
			dictionary[selectionFilterType.SketchCurve] = new Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>(selectionInfoSubItems7, null);
			_0023_003DzMSEscuwaFYRaMsMRDg_003D_003D(_0023_003DzzDNdOMv1nCY_0024, dictionary, _0023_003Dz7MoFvcekkC14, _0023_003DzNWtosWYCtxJL, _0023_003DzUsW18wvfQQpu, list, list2);
			if (SelectionInfoSubItems.IsAnySelected(list5))
			{
				((ISelectableSubItems)selectedItem2.Item).SelectionMode = _0023_003Dz28QCun7pbbWH;
			}
			else
			{
				((ISelectableSubItems)selectedItem2.Item).SelectionMode = selectionFilterType.Entity;
			}
			if (list.Count > 0 || list2.Count > 0)
			{
				_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerSelectionImage = null;
			}
		}
		_0023_003DzdXQchgXOgG_0024e.AddedItems = list;
		_0023_003DzdXQchgXOgG_0024e.RemovedItems = list2;
	}

	private static bool _0023_003Dze9MbzCCjOmNj(SelectedItem _0023_003DzWhRHNgk_003D, out Brep _0023_003Dz_SRj_0024i0GYVwn, out CompositeCurve _0023_003Dzt0s9LQY_003D, out devDept.Eyeshot.Entities.Region _0023_003Dzc4701QQ_003D, out SketchEntity _0023_003Dzpc5uZPefj7RL)
	{
		ISelectableItem item = _0023_003DzWhRHNgk_003D.Item;
		_0023_003Dz_SRj_0024i0GYVwn = item as Brep;
		_0023_003Dzt0s9LQY_003D = item as CompositeCurve;
		_0023_003Dzc4701QQ_003D = item as devDept.Eyeshot.Entities.Region;
		_0023_003Dzpc5uZPefj7RL = item as SketchEntity;
		if (_0023_003Dz_SRj_0024i0GYVwn == null && _0023_003Dzt0s9LQY_003D == null && _0023_003Dzc4701QQ_003D == null)
		{
			return _0023_003Dzpc5uZPefj7RL != null;
		}
		return true;
	}

	private void _0023_003Dz19wnfFsMuEO7<T>(Viewport _0023_003DzYzWi5Yw_003D, Rectangle _0023_003DzCiKS5oMdHowF, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003Dz7MoFvcekkC14, SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e, bool _0023_003DzUsW18wvfQQpu, selectionStatusType _0023_003DzNWtosWYCtxJL, List<SelectedItem> _0023_003DzdqySRM5BCRQG, List<SelectedItem> _0023_003Dz3NenWUqwkcW4, List<SelectedItem> _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D, _0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX) where T : SelectedSubItem, new()
	{
		List<SelectedItem> list = new List<SelectedItem>();
		List<SelectedItem> list2 = new List<SelectedItem>();
		for (int i = 0; i < _0023_003Dz3NenWUqwkcW4.Count; i++)
		{
			SelectedItem selectedItem = _0023_003Dz3NenWUqwkcW4[i];
			List<SelectedSubItem> list3 = null;
			if (selectedItem.Item is Brep)
			{
				Brep brep = (Brep)selectedItem.Item;
				SelectionInfoSubItems selectionInfoSubItems = null;
				switch (_0023_003DzbOk8RJDeO_0024TX)
				{
				case (_0023_003DzhFBmu_0024RpnRJ7)4:
					selectionInfoSubItems = SelectionInfoItemBase.FindInstance(selectedItem.Parents, brep, null, brep.VerticesSelectionInfo);
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)2:
					selectionInfoSubItems = SelectionInfoItemBase.FindInstance(selectedItem.Parents, brep, null, brep.EdgesSelectionInfo);
					break;
				}
				if (selectionInfoSubItems != null)
				{
					list3 = Entity.ClearChildrenItemsSelection<T>(_0023_003DzNWtosWYCtxJL, selectedItem.Parents, selectedItem.Item, selectionInfoSubItems.SubItems, 0);
				}
				brep.ResetSelectionMode();
			}
			else if (selectedItem.Item is ISelectableSubItems)
			{
				((ISelectableSubItems)selectedItem.Item).ResetSelectionMode();
			}
			if (list3 != null && list3.Count > 0)
			{
				list2.AddRange(list3);
			}
			else
			{
				list2.Add(selectedItem);
			}
		}
		for (int j = 0; j < _0023_003DzdqySRM5BCRQG.Count; j++)
		{
			SelectedItem selectedItem2 = _0023_003DzdqySRM5BCRQG[j];
			if (selectedItem2.Item is Brep)
			{
				Brep brep2 = (Brep)selectedItem2.Item;
				List<Entity> list4 = new List<Entity>();
				if (selectedItem2.Parents.Count > 0)
				{
					list4.Add(new NestedEntity(selectedItem2, Layers, Blocks, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D));
				}
				else
				{
					list4.Add((Entity)selectedItem2.Item);
				}
				_0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, list4, _0023_003DzbOk8RJDeO_0024TX, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out var _0023_003DzzDNdOMv1nCY_0024);
				SelectionInfoSubItems selectionInfoSubItems2 = null;
				int num = 0;
				List<SelectionInfoSubItems> _0023_003DzhrgkevI_003D;
				if (_0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)4)
				{
					selectionInfoSubItems2 = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, brep2, null, brep2.VerticesSelectionInfo, brep2.Vertices.Length);
					_0023_003DzhrgkevI_003D = brep2.VerticesSelectionInfo;
					num = brep2.Vertices.Length;
				}
				else
				{
					selectionInfoSubItems2 = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, brep2, null, brep2.EdgesSelectionInfo, brep2.Edges.Length);
					_0023_003DzhrgkevI_003D = brep2.EdgesSelectionInfo;
					num = brep2.Edges.Length;
				}
				if (selectionInfoSubItems2.SubItems == null)
				{
					selectionInfoSubItems2.InitSubItems(num);
				}
				_0023_003DzG_bZOS1L8DOIWwfo_0024g_003D_003D(_0023_003DzzDNdOMv1nCY_0024, selectionInfoSubItems2, null, _0023_003Dz7MoFvcekkC14, _0023_003DzNWtosWYCtxJL, _0023_003DzUsW18wvfQQpu, list, list2);
				if (SelectionInfoSubItems.IsAnySelected(_0023_003DzhrgkevI_003D))
				{
					((ISelectableSubItems)brep2).SelectionMode = _0023_003DzvWLQKSc_0024sxXbUSy4oQ_003D_003D(_0023_003DzbOk8RJDeO_0024TX);
				}
				else
				{
					((ISelectableSubItems)brep2).SelectionMode = selectionFilterType.Entity;
				}
				if (list.Count > 0 || list2.Count > 0)
				{
					_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerSelectionImage = null;
				}
			}
		}
		_0023_003DzdXQchgXOgG_0024e.AddedItems = list;
		_0023_003DzdXQchgXOgG_0024e.RemovedItems = list2;
	}

	private selectionFilterType _0023_003DzvWLQKSc_0024sxXbUSy4oQ_003D_003D(_0023_003DzhFBmu_0024RpnRJ7 _0023_003DzyAqpxW8jop_0024U)
	{
		return _0023_003DzyAqpxW8jop_0024U switch
		{
			(_0023_003DzhFBmu_0024RpnRJ7)2 => selectionFilterType.Edge, 
			(_0023_003DzhFBmu_0024RpnRJ7)4 => selectionFilterType.Vertex, 
			_ => selectionFilterType.Face, 
		};
	}

	private void _0023_003Dz5JIWc1YYthkl(Viewport _0023_003DzYzWi5Yw_003D, Rectangle _0023_003DzCiKS5oMdHowF, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003Dz7MoFvcekkC14, SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e, bool _0023_003DzUsW18wvfQQpu, selectionStatusType _0023_003DzNWtosWYCtxJL, List<SelectedItem> _0023_003DzdqySRM5BCRQG, List<SelectedItem> _0023_003Dz3NenWUqwkcW4, List<SelectedItem> _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D)
	{
		List<SelectedItem> list = new List<SelectedItem>();
		List<SelectedItem> list2 = new List<SelectedItem>();
		for (int i = 0; i < _0023_003Dz3NenWUqwkcW4.Count; i++)
		{
			SelectedItem selectedItem = _0023_003Dz3NenWUqwkcW4[i];
			List<SelectedSubItem> list3 = null;
			if (selectedItem.Item is IFaceSelectable)
			{
				list3 = ((Entity)selectedItem.Item).ClearSelectionFaces(selectedItem.Parents, _0023_003DzNWtosWYCtxJL);
				((ISelectableSubItems)selectedItem.Item).ResetSelectionMode();
			}
			if (list3 != null && list3.Count > 0)
			{
				list2.AddRange(list3);
			}
			else
			{
				list2.Add(selectedItem);
			}
		}
		for (int j = 0; j < _0023_003DzdqySRM5BCRQG.Count; j++)
		{
			SelectedItem selectedItem2 = _0023_003DzdqySRM5BCRQG[j];
			if (!(selectedItem2.Item is IFaceSelectable))
			{
				continue;
			}
			List<Entity> list4 = new List<Entity>();
			if (selectedItem2.Parents.Count > 0)
			{
				list4.Add(new NestedEntity(selectedItem2, Layers, Blocks, _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D));
			}
			else
			{
				list4.Add((Entity)selectedItem2.Item);
			}
			SelectedItem[] _0023_003DzzDNdOMv1nCY_0024 = null;
			SelectionInfoSubItems selectionInfoSubItems = null;
			SelectionInfoSubItemsArray selectionInfoSubItemsArray = null;
			if (selectedItem2.Item is Brep)
			{
				_0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, list4, (_0023_003DzhFBmu_0024RpnRJ7)1, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out _0023_003DzzDNdOMv1nCY_0024);
				selectionInfoSubItems = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, selectedItem2.Item, null, ((Brep)selectedItem2.Item).FacesSelectionInfo, ((Brep)selectedItem2.Item).Faces.Length);
				Stack<BlockReference> parents = selectedItem2.Parents;
				ISelectableItem item = selectedItem2.Item;
				List<SelectionInfoSubItemsArray> innerFacesSelectionInfo = ((Brep)selectedItem2.Item).InnerFacesSelectionInfo;
				object[][] inners = ((Brep)selectedItem2.Item).Inners;
				selectionInfoSubItemsArray = SelectionInfoItemBase.FindInstanceOrCreate(parents, item, null, innerFacesSelectionInfo, -1, inners);
				if (selectionInfoSubItems.SubItems == null)
				{
					selectionInfoSubItems.InitSubItems(((Brep)selectedItem2.Item).Faces.Length);
				}
				if (selectionInfoSubItemsArray.SubItems == null)
				{
					SelectionInfoSubItemsArray selectionInfoSubItemsArray2 = selectionInfoSubItemsArray;
					inners = ((Brep)selectedItem2.Item).Inners;
					selectionInfoSubItemsArray2.InitSubItemsArray(inners);
				}
			}
			else if (selectedItem2.Item is IFaceSelectable)
			{
				SelectedItem[] _0023_003DzzDNdOMv1nCY_00242;
				int[] _0023_003DzKHBiu_4_003D = _0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, list4, (_0023_003DzhFBmu_0024RpnRJ7)1, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: false, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out _0023_003DzzDNdOMv1nCY_00242);
				_0023_003DzzDNdOMv1nCY_0024 = _0023_003DzSa9nQc1fooX_Sorh5w_003D_003D(_0023_003DzNWtosWYCtxJL, _0023_003DzKHBiu_4_003D, selectedItem2).ToArray();
				Mesh.FaceCollection faceCollection = null;
				List<SelectionInfoSubItems> list5 = null;
				if (selectedItem2.Item is Solid)
				{
					faceCollection = ((Solid)selectedItem2.Item).Faces;
					list5 = ((Solid)selectedItem2.Item).FacesSelectionInfo;
				}
				else
				{
					faceCollection = ((Mesh)selectedItem2.Item).Faces;
					list5 = ((Mesh)selectedItem2.Item).FacesSelectionInfo;
				}
				selectionInfoSubItems = SelectionInfoItemBase.FindInstanceOrCreate(selectedItem2.Parents, selectedItem2.Item, null, list5, faceCollection.Count);
			}
			if (_0023_003DzzDNdOMv1nCY_0024 != null)
			{
				_0023_003DzDKY8JztsWMUazSo2Yg_003D_003D(_0023_003Dz7MoFvcekkC14, _0023_003DzUsW18wvfQQpu, _0023_003DzNWtosWYCtxJL, _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D, selectedItem2, _0023_003DzzDNdOMv1nCY_0024, selectionInfoSubItems, selectionInfoSubItemsArray, list, list2);
			}
			if (_0023_003DzdqySRM5BCRQG.Count > 0 || _0023_003Dz3NenWUqwkcW4.Count > 0)
			{
				_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerSelectionImage = null;
			}
		}
		_0023_003DzdXQchgXOgG_0024e.AddedItems = list;
		_0023_003DzdXQchgXOgG_0024e.RemovedItems = list2;
	}

	private List<SelectedItem> _0023_003DzSa9nQc1fooX_Sorh5w_003D_003D(selectionStatusType _0023_003DzNWtosWYCtxJL, int[] _0023_003DzKHBiu_4_003D, SelectedItem _0023_003DzP_00247yf9c_003D)
	{
		IFaceSelectable faceSelectable = (IFaceSelectable)_0023_003DzP_00247yf9c_003D.Item;
		List<int> list = new List<int>(_0023_003DzKHBiu_4_003D);
		list.Sort();
		List<SelectedItem> list2 = new List<SelectedItem>();
		Mesh.FaceCollection faces;
		if (faceSelectable is Solid)
		{
			if (((Solid)faceSelectable).Faces == null)
			{
				((Solid)faceSelectable).Faces = new Mesh.FaceCollection();
				((Solid)faceSelectable).Faces.SetDocument(_0023_003DzgfObf7s_003D);
			}
			faces = ((Solid)faceSelectable).Faces;
		}
		else
		{
			if (!(faceSelectable is Mesh))
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586813));
			}
			if (((Mesh)faceSelectable).Faces == null)
			{
				((Mesh)faceSelectable).Faces = new Mesh.FaceCollection();
				((Mesh)faceSelectable).Faces.SetDocument(_0023_003DzgfObf7s_003D);
			}
			faces = ((Mesh)faceSelectable).Faces;
		}
		while (list.Count > 0)
		{
			List<int> list3 = null;
			if (faces != null && list.Count > 0)
			{
				for (int i = 0; i < faces.Count; i++)
				{
					if (faces[i].Triangles.BinarySearch(list[0]) >= 0)
					{
						list3 = faces[i].Triangles;
						break;
					}
				}
			}
			if (list3 == null)
			{
				list3 = ((!(faceSelectable is Solid)) ? ((Mesh)faceSelectable).GetFaceTriangles(list[0], _0023_003DzXTX6Wl_tlLz9) : ((Solid)faceSelectable).GetFaceTriangles(list[0], _0023_003DzXTX6Wl_tlLz9));
				list3.Sort();
			}
			if (list3.Count <= 0)
			{
				continue;
			}
			for (int j = 0; j < list3.Count; j++)
			{
				int num = list.BinarySearch(list3[j]);
				if (num >= 0)
				{
					list.RemoveAt(num);
				}
				if (list.Count == 0)
				{
					break;
				}
			}
			int _0023_003DzdKtDuR5dbiNZW_0l2g_003D_003D = list3[0];
			int num2 = _0023_003Dzy_Dyw09ojpTP(faces, _0023_003DzdKtDuR5dbiNZW_0l2g_003D_003D);
			if (num2 < 0)
			{
				Mesh.FaceElement faceElement = new Mesh.FaceElement(list3);
				faces.Add(faceElement);
				if (faceSelectable is Solid)
				{
					((Solid)faceSelectable).CompileSelectedFace(_0023_003DzmNZD0Zs_003D, faceElement);
				}
				else
				{
					((Mesh)faceSelectable).CompileSelectedFace(_0023_003DzmNZD0Zs_003D, faceElement);
				}
				num2 = faces.Count - 1;
			}
			list2.Add(new SelectedFace(_0023_003DzP_00247yf9c_003D.Parents, _0023_003DzP_00247yf9c_003D.Item, num2));
		}
		return list2;
	}

	private void _0023_003DzDKY8JztsWMUazSo2Yg_003D_003D(bool _0023_003Dz7MoFvcekkC14, bool _0023_003DzUsW18wvfQQpu, selectionStatusType _0023_003DzNWtosWYCtxJL, List<SelectedItem> _0023_003DzCPims4HNGMLndc3fMmMXRO4_003D, SelectedItem _0023_003DzP_00247yf9c_003D, SelectedItem[] _0023_003DzkRv4SrkmP4Wm, SelectionInfoSubItems _0023_003Dz0e8Qi_00245AkPb0, SelectionInfoSubItemsArray _0023_003Dz27CPHJR2eEEPP1dnbQ_003D_003D, List<SelectedItem> _0023_003DzBBsWEz8_003D, List<SelectedItem> _0023_003Dzega9y3w_003D)
	{
		_0023_003DzG_bZOS1L8DOIWwfo_0024g_003D_003D(_0023_003DzkRv4SrkmP4Wm, _0023_003Dz0e8Qi_00245AkPb0, _0023_003Dz27CPHJR2eEEPP1dnbQ_003D_003D, _0023_003Dz7MoFvcekkC14, _0023_003DzNWtosWYCtxJL, _0023_003DzUsW18wvfQQpu, _0023_003DzBBsWEz8_003D, _0023_003Dzega9y3w_003D);
		IFaceSelectable faceSelectable = (IFaceSelectable)_0023_003DzP_00247yf9c_003D.Item;
		if (faceSelectable.IsAnyFaceSelected())
		{
			faceSelectable.SelectionMode = selectionFilterType.Face;
		}
		else
		{
			faceSelectable.SelectionMode = selectionFilterType.Entity;
		}
	}

	private void _0023_003DzG_bZOS1L8DOIWwfo_0024g_003D_003D(SelectedItem[] _0023_003Dzgyc3mjVey4Vd, SelectionInfoSubItems _0023_003Dz0e8Qi_00245AkPb0, SelectionInfoSubItemsArray _0023_003Dz27CPHJR2eEEPP1dnbQ_003D_003D, bool _0023_003Dz7MoFvcekkC14, selectionStatusType _0023_003DzNWtosWYCtxJL, bool _0023_003DzUsW18wvfQQpu, List<SelectedItem> _0023_003DzBBsWEz8_003D, List<SelectedItem> _0023_003Dzega9y3w_003D)
	{
		for (int i = 0; i < _0023_003Dzgyc3mjVey4Vd.Length; i++)
		{
			SelectedSubItem selectedSubItem = (SelectedSubItem)_0023_003Dzgyc3mjVey4Vd[i];
			int index = selectedSubItem.Index;
			SelectionInfo[] array = _0023_003DzJOmzRQ9we3oJ(selectedSubItem, _0023_003Dz0e8Qi_00245AkPb0, _0023_003Dz27CPHJR2eEEPP1dnbQ_003D_003D);
			_0023_003DzG_bZOS1L8DOIWwfo_0024g_003D_003D(index, array, _0023_003Dz7MoFvcekkC14, _0023_003DzNWtosWYCtxJL, _0023_003DzUsW18wvfQQpu);
			if (array[index].IsFlagSet(_0023_003DzNWtosWYCtxJL))
			{
				_0023_003DzBBsWEz8_003D.Add(selectedSubItem);
			}
			else
			{
				_0023_003Dzega9y3w_003D.Add(selectedSubItem);
			}
		}
	}

	private void _0023_003DzMSEscuwaFYRaMsMRDg_003D_003D(SelectedItem[] _0023_003Dzgyc3mjVey4Vd, Dictionary<selectionFilterType, Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray>> _0023_003Dzt12iB5aX9Wh4DZKF4g_003D_003D, bool _0023_003Dz7MoFvcekkC14, selectionStatusType _0023_003DzNWtosWYCtxJL, bool _0023_003DzUsW18wvfQQpu, List<SelectedItem> _0023_003DzBBsWEz8_003D, List<SelectedItem> _0023_003Dzega9y3w_003D)
	{
		for (int i = 0; i < _0023_003Dzgyc3mjVey4Vd.Length; i++)
		{
			SelectedSubItem selectedSubItem = (SelectedSubItem)_0023_003Dzgyc3mjVey4Vd[i];
			int index = selectedSubItem.Index;
			SelectionInfo[] array = null;
			if (!(selectedSubItem is SelectedVertex))
			{
				if (!(selectedSubItem is SelectedEdge))
				{
					if (!(selectedSubItem is SelectedFace))
					{
						if (!(selectedSubItem is SelectedSubCurve))
						{
							if (!(selectedSubItem is SelectedContour))
							{
								if (selectedSubItem is SelectedSketchCurve)
								{
									Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray> tuple = _0023_003Dzt12iB5aX9Wh4DZKF4g_003D_003D[selectionFilterType.SketchCurve];
									array = _0023_003DzJOmzRQ9we3oJ(selectedSubItem, tuple.Item1, tuple.Item2);
								}
							}
							else
							{
								Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray> tuple2 = _0023_003Dzt12iB5aX9Wh4DZKF4g_003D_003D[selectionFilterType.Contour];
								array = _0023_003DzJOmzRQ9we3oJ(selectedSubItem, tuple2.Item1, tuple2.Item2);
							}
						}
						else
						{
							Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray> tuple3 = _0023_003Dzt12iB5aX9Wh4DZKF4g_003D_003D[selectionFilterType.SubCurve];
							array = _0023_003DzJOmzRQ9we3oJ(selectedSubItem, tuple3.Item1, tuple3.Item2);
						}
					}
					else
					{
						Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray> tuple4 = _0023_003Dzt12iB5aX9Wh4DZKF4g_003D_003D[selectionFilterType.Face];
						array = _0023_003DzJOmzRQ9we3oJ(selectedSubItem, tuple4.Item1, tuple4.Item2);
					}
				}
				else
				{
					Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray> tuple5 = _0023_003Dzt12iB5aX9Wh4DZKF4g_003D_003D[selectionFilterType.Edge];
					array = _0023_003DzJOmzRQ9we3oJ(selectedSubItem, tuple5.Item1, tuple5.Item2);
				}
			}
			else
			{
				Tuple<SelectionInfoSubItems, SelectionInfoSubItemsArray> tuple6 = _0023_003Dzt12iB5aX9Wh4DZKF4g_003D_003D[selectionFilterType.Vertex];
				array = _0023_003DzJOmzRQ9we3oJ(selectedSubItem, tuple6.Item1, tuple6.Item2);
			}
			_0023_003DzG_bZOS1L8DOIWwfo_0024g_003D_003D(index, array, _0023_003Dz7MoFvcekkC14, _0023_003DzNWtosWYCtxJL, _0023_003DzUsW18wvfQQpu);
			if (array[index].IsFlagSet(_0023_003DzNWtosWYCtxJL))
			{
				_0023_003DzBBsWEz8_003D.Add(selectedSubItem);
			}
			else
			{
				_0023_003Dzega9y3w_003D.Add(selectedSubItem);
			}
		}
	}

	private SelectionInfo[] _0023_003DzJOmzRQ9we3oJ(SelectedSubItem _0023_003DzWhRHNgk_003D, SelectionInfoSubItems _0023_003Dz0e8Qi_00245AkPb0, SelectionInfoSubItemsArray _0023_003Dz27CPHJR2eEEPP1dnbQ_003D_003D)
	{
		if (_0023_003Dz27CPHJR2eEEPP1dnbQ_003D_003D == null)
		{
			if (_0023_003Dz0e8Qi_00245AkPb0.SubItems == null)
			{
				_0023_003Dz0e8Qi_00245AkPb0.SubItems = new SelectionInfo[_0023_003DzWhRHNgk_003D.Index + 1];
			}
			else if (_0023_003Dz0e8Qi_00245AkPb0.SubItems.Length <= _0023_003DzWhRHNgk_003D.Index + 1)
			{
				Array.Resize(ref _0023_003Dz0e8Qi_00245AkPb0.SubItems, _0023_003DzWhRHNgk_003D.Index + 1);
			}
		}
		else if (((SelectedFace)_0023_003DzWhRHNgk_003D).ShellIndex > 0)
		{
			return _0023_003Dz27CPHJR2eEEPP1dnbQ_003D_003D.SubItems[((SelectedFace)_0023_003DzWhRHNgk_003D).ShellIndex - 1];
		}
		return _0023_003Dz0e8Qi_00245AkPb0.SubItems;
	}

	private void _0023_003DzG_bZOS1L8DOIWwfo_0024g_003D_003D(int _0023_003DzxEyDJ6I_003D, SelectionInfo[] _0023_003DzIJnKYg2rS5Pe, bool _0023_003Dz7MoFvcekkC14, selectionStatusType _0023_003DzNWtosWYCtxJL, bool _0023_003DzUsW18wvfQQpu)
	{
		if (_0023_003Dz7MoFvcekkC14)
		{
			_0023_003DzIJnKYg2rS5Pe[_0023_003DzxEyDJ6I_003D].InvertFlag(_0023_003DzNWtosWYCtxJL);
		}
		else
		{
			_0023_003DzIJnKYg2rS5Pe[_0023_003DzxEyDJ6I_003D].SetFlag(_0023_003DzNWtosWYCtxJL);
		}
	}

	private int _0023_003Dzy_Dyw09ojpTP(EyeshotDisposableCollection<Mesh.FaceElement> _0023_003DzkRv4SrkmP4Wm, int _0023_003DzdKtDuR5dbiNZW_0l2g_003D_003D)
	{
		for (int i = 0; i < _0023_003DzkRv4SrkmP4Wm.Count; i++)
		{
			if (_0023_003DzkRv4SrkmP4Wm[i].Triangles[0] == _0023_003DzdKtDuR5dbiNZW_0l2g_003D_003D)
			{
				return i;
			}
		}
		return -1;
	}

	private void _0023_003DzzfBE5x7sU8q2RQURtA_003D_003D(bool _0023_003Dz7MoFvcekkC14, List<SelectedItem> _0023_003DzBBsWEz8_003D, List<SelectedItem> _0023_003Dzega9y3w_003D, selectionStatusType _0023_003DzNepDdguIsRtl)
	{
		_0023_003Dz2JdwzXSv2lMt9rIufG4Q8Xw_003D CS_0024_003C_003E8__locals5 = new _0023_003Dz2JdwzXSv2lMt9rIufG4Q8Xw_003D();
		HashSet<int> hashSet = new HashSet<int>();
		CS_0024_003C_003E8__locals5._0023_003Dz3n7Denxh0jei = new HashSet<Entity>(_0023_003DzBBsWEz8_003D.Count);
		_0023_003DzBBsWEz8_003D.ForEach(CS_0024_003C_003E8__locals5._0023_003DzR3UYyFZsWD8IDNCrsdTbbV4_003D);
		if (_0023_003DzNepDdguIsRtl != selectionStatusType.Temporary)
		{
			_0023_003Dzega9y3w_003D.ForEach(delegate(SelectedItem _0023_003Dz8GBMuoM_003D)
			{
				CS_0024_003C_003E8__locals5._0023_003Dz3n7Denxh0jei.Add((Entity)_0023_003Dz8GBMuoM_003D.Item);
			});
		}
		foreach (Entity item2 in CS_0024_003C_003E8__locals5._0023_003Dz3n7Denxh0jei)
		{
			int groupIndex = item2.GroupIndex;
			if (groupIndex == -1 || !hashSet.Add(groupIndex))
			{
				continue;
			}
			foreach (int item3 in CurrentBlock.Groups[groupIndex])
			{
				Entity entity = Entities[item3];
				if (CS_0024_003C_003E8__locals5._0023_003Dz3n7Denxh0jei.Contains(entity))
				{
					continue;
				}
				SelectedItem item = new SelectedItem(entity);
				if (_0023_003Dz7MoFvcekkC14)
				{
					entity._selectionInfo.SelectionInfo.InvertFlag(_0023_003DzNepDdguIsRtl);
					if (entity.Selected)
					{
						_0023_003DzBBsWEz8_003D.Add(item);
					}
					else
					{
						_0023_003Dzega9y3w_003D.Add(item);
					}
				}
				else
				{
					entity._selectionInfo.SelectionInfo.SetFlag(_0023_003DzNepDdguIsRtl);
					_0023_003DzBBsWEz8_003D.Add(item);
				}
			}
		}
	}

	public virtual void ProcessSelectionVisibleOnlyLabels(Rectangle selectionBox, bool firstOnly, bool invert, SelectionChangedEventArgs eventArgs, bool selectableOnly = true)
	{
		_0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), selectionBox, firstOnly, Entities, (_0023_003DzhFBmu_0024RpnRJ7)64, selectableOnly, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out var _0023_003DzzDNdOMv1nCY_0024);
		_ = _0023_003DzipBYly6zFKAp()._0023_003DzF5TdZcc_003D;
		for (int i = 0; i < _0023_003DzzDNdOMv1nCY_0024.Length; i++)
		{
			devDept.Eyeshot.Control.Labels.Label label = (devDept.Eyeshot.Control.Labels.Label)_0023_003DzzDNdOMv1nCY_0024[i].Item;
			if (invert)
			{
				label.Selected = !label.Selected;
			}
			else
			{
				label.Selected = true;
			}
			if (label.Selected)
			{
				eventArgs.AddedItems.Add(_0023_003DzzDNdOMv1nCY_0024[i]);
			}
			else
			{
				eventArgs.RemovedItems.Add(_0023_003DzzDNdOMv1nCY_0024[i]);
			}
		}
	}

	public virtual void ProcessSelection(Rectangle selectionBox, bool firstOnly, bool invert, SelectionChangedEventArgs eventArgs, bool selectableOnly = true)
	{
		int[] selectedIndices;
		SelectedItem[] crossingEntities = GetCrossingEntities(selectionBox, firstOnly, out selectedIndices, selectableOnly);
		_0023_003DzHeomB7BdNilY(invert, crossingEntities, eventArgs, _0023_003DzUsW18wvfQQpu: false);
	}

	private bool _0023_003DzHjFAmfaGpEeM()
	{
		return _0023_003DzHjFAmfaGpEeM(ActionMode);
	}

	private static bool _0023_003DzHjFAmfaGpEeM(actionType _0023_003DzfcUzrRi_0024u6FZ)
	{
		if (_0023_003DzfcUzrRi_0024u6FZ != actionType.SelectVisibleByBox && _0023_003DzfcUzrRi_0024u6FZ != actionType.SelectVisibleByPick && _0023_003DzfcUzrRi_0024u6FZ != actionType.SelectVisibleByPolygon)
		{
			return _0023_003DzfcUzrRi_0024u6FZ == actionType.SelectVisibleByPickDynamic;
		}
		return true;
	}

	private bool _0023_003DzQbxIfW_7SaB9(selectionFilterType _0023_003DzmrtMJ48_003D)
	{
		if (_0023_003DzmrtMJ48_003D != selectionFilterType.Entity)
		{
			return _0023_003DzHjFAmfaGpEeM();
		}
		return false;
	}

	internal void _0023_003DzHeomB7BdNilY(bool _0023_003Dz7MoFvcekkC14, IList<SelectedItem> _0023_003DzUl92GdI_003D, SelectionChangedEventArgs _0023_003DzdXQchgXOgG_0024e, bool _0023_003DzUsW18wvfQQpu)
	{
		selectionStatusType selectionFlag = SelectionInfo.GetSelectionFlag(_0023_003DzUsW18wvfQQpu);
		bool flag = _0023_003DzQbxIfW_7SaB9(_0023_003Dz28QCun7pbbWH);
		List<SelectedItem> list = new List<SelectedItem>();
		List<SelectedItem> list2 = new List<SelectedItem>(_0023_003DzdXQchgXOgG_0024e.RemovedItems);
		for (int i = 0; i < _0023_003DzUl92GdI_003D.Count; i++)
		{
			SelectedItem selectedItem = _0023_003DzUl92GdI_003D[i];
			SelectionInfoItem selectionInfoItem = null;
			if (selectedItem.Item is Entity entity)
			{
				selectionInfoItem = entity.GetSelectionInfo(selectedItem.Parents);
				if (!_0023_003DzUsW18wvfQQpu && selectionInfoItem.SelectionInfo._selectionStatus == selectionStatusType.Temporary)
				{
					selectionInfoItem.SelectionInfo._selectionStatus = selectionStatusType.None;
				}
				if (_0023_003Dz7MoFvcekkC14)
				{
					if (selectedItem.Item.GetSelection(selectedItem.Parents) && !flag)
					{
						list2.Add(selectedItem);
					}
					else
					{
						list.Add(selectedItem);
					}
					if (!flag)
					{
						selectionInfoItem.SelectionInfo.InvertFlag(selectionFlag);
					}
				}
				else
				{
					list.Add(selectedItem);
					if (!flag)
					{
						selectionInfoItem.SelectionInfo.SetFlag(selectionFlag);
					}
				}
				continue;
			}
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595223));
		}
		if (_0023_003DznugYzyWkU3Do == assemblySelectionType.Branch && !flag)
		{
			_0023_003DzzfBE5x7sU8q2RQURtA_003D_003D(_0023_003Dz7MoFvcekkC14, list, list2, selectionFlag);
		}
		_0023_003DzdXQchgXOgG_0024e.SetItems(list, list2);
		if (!_0023_003DzUsW18wvfQQpu && (list.Count > 0 || list2.Count > 0))
		{
			_0023_003DzadAqUJcDAmic(_0023_003DzIH4xUe5IjPB_0024: true);
		}
	}

	public SelectedItem[] GetCrossingEntitiesByPolygon(IList<Point2D> screenSelectionPolygon, bool firstOnly, out int[] selectedIndices, bool selectableOnly = true, Transformation accParentTransform = null)
	{
		return new _0023_003DzKmjkuSZXr8_0024Rl_zzrXMbKJa7ooH82Q9K5A_003D_003D()._0023_003DzTpZvGLfXRihX(this, screenSelectionPolygon, _0023_003Dz7MoFvcekkC14: false, null, _0023_003Dzc_0024FDVjzZMRWW: false, firstOnly, selectableOnly, out selectedIndices, actionType.SelectByPolygon);
	}

	public SelectedItem[] GetCrossingEntities(Rectangle selectionBox, bool firstOnly, out int[] selectedIndices, bool selectableOnly = true)
	{
		selectedIndices = _0023_003DzKwAZQN5_0024ZUhsuyhnoQ_003D_003D(selectionBox, _0023_003Dzb27idIA2SfmZ(), firstOnly, selectableOnly, _0023_003Dz8YKEbEWNU93g(), out var _0023_003Dze9sM4IQ_003D, (Entity _0023_003DztJCl_0024mM_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024) => ((IEntityInternal)_0023_003DztJCl_0024mM_003D).IsCrossing(_0023_003DzCBM7XJK4_5H_0024), _0023_003Dzkm9D6jYtZW1j);
		return _0023_003Dze9sM4IQ_003D;
	}

	public virtual SelectedItem[] GetCrossingEntities(Rectangle selectionBox, IList<Entity> entList, bool firstOnly, out int[] selectedIndices, bool selectableOnly = true, Transformation accParentTransform = null)
	{
		selectedIndices = _0023_003DzKwAZQN5_0024ZUhsuyhnoQ_003D_003D(selectionBox, entList, firstOnly, selectableOnly, accParentTransform, out var _0023_003Dze9sM4IQ_003D, (Entity _0023_003DztJCl_0024mM_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024) => ((IEntityInternal)_0023_003DztJCl_0024mM_003D).IsCrossing(_0023_003DzCBM7XJK4_5H_0024), null);
		return _0023_003Dze9sM4IQ_003D;
	}

	private int[] _0023_003DzKwAZQN5_0024ZUhsuyhnoQ_003D_003D(Rectangle _0023_003DzCiKS5oMdHowF, IList<Entity> _0023_003DzY_0024ABPwh9wryC, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, Transformation _0023_003Dz7olvtXbaWalx, out SelectedItem[] _0023_003Dze9sM4IQ_003D, IsInScreenDelegate _0023_003DzHx8m_U_0ER_5, Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		_0023_003Dze9sM4IQ_003D = null;
		bool flag = true;
		object[] array = null;
		array = new object[2] { this, flag };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "/H,SJq\"aca", array);
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		Segment3D[] _0023_003DzscOHRT_KSu11SqtX2w_003D_003D;
		PlaneEquation[] array2 = viewport._0023_003DzRyGJqASiXH0u(_0023_003DzCiKS5oMdHowF, out _0023_003DzscOHRT_KSu11SqtX2w_003D_003D);
		if (array2 == null)
		{
			return Array.Empty<int>();
		}
		FrustumParams frustumParams = new FrustumParams(array2, _0023_003DzscOHRT_KSu11SqtX2w_003D_003D, viewport._0023_003DzK_00241ezHQJ9Z3c, viewport._0023_003DzIjzPUT72VTAG, null, MaxPatternRepetitions, this, _0023_003Dz7olvtXbaWalx)
		{
			IsLeafSelection = (_0023_003DzCBASci_Gpxb1 == assemblySelectionType.Leaf),
			FirstOnly = _0023_003Dz_bIfLEkNPFmB
		};
		if (_0023_003Dzbq3BJR0_003D != null)
		{
			frustumParams.Parents = Utility.CloneStack(_0023_003Dzbq3BJR0_003D);
		}
		return _0023_003Dz971H31F_6_0024g4(frustumParams, _0023_003DzY_0024ABPwh9wryC, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, out _0023_003Dze9sM4IQ_003D, _0023_003DzHx8m_U_0ER_5, _0023_003DzrDIvDNs4suuK6OKacQ_003D_003D: true);
	}

	private int[] _0023_003Dz971H31F_6_0024g4(FrustumParams _0023_003DzCBM7XJK4_5H_0024, IList<Entity> _0023_003DzY_0024ABPwh9wryC, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, out SelectedItem[] _0023_003Dze9sM4IQ_003D, IsInScreenDelegate _0023_003DzHx8m_U_0ER_5, bool _0023_003DzrDIvDNs4suuK6OKacQ_003D_003D)
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		List<int> list = new List<int>();
		_0023_003Dze9sM4IQ_003D = null;
		List<SelectedItem> list2 = new List<SelectedItem>();
		bool flag = _0023_003DzSTCto4yqfbV4();
		for (int i = 0; i < _0023_003DzY_0024ABPwh9wryC.Count; i++)
		{
			Entity entity = _0023_003DzY_0024ABPwh9wryC[i];
			if (!_0023_003Dz4RlPrk9tv7S7(_0023_003DzCBM7XJK4_5H_0024, entity) || !entity.IsSelectable(Layers, !_0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D) || (_0023_003DzrDIvDNs4suuK6OKacQ_003D_003D && !entity.IsInFrustum(_0023_003DzCBM7XJK4_5H_0024)) || AllBranchNodesAreBlockReferences(entity, _0023_003DzCBM7XJK4_5H_0024.Blocks))
			{
				continue;
			}
			if (!_0023_003DzCBM7XJK4_5H_0024.IsLeafSelection && flag && entity is BlockReference blockReference && !_0023_003Dzlrl6ZJY_003D(_0023_003DzCBM7XJK4_5H_0024, entity))
			{
				blockReference.GetEntitiesInPolygon(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, out var _0023_003DzVrinm7g_003D, _0023_003DzHx8m_U_0ER_5, _0023_003DzrDIvDNs4suuK6OKacQ_003D_003D, _0023_003Dz971H31F_6_0024g4);
				list2.AddRange(_0023_003DzVrinm7g_003D);
				if (_0023_003DzVrinm7g_003D.Length != 0 && _0023_003DzCBM7XJK4_5H_0024.FirstOnly)
				{
					break;
				}
			}
			else if (_0023_003DzHx8m_U_0ER_5(entity, _0023_003DzCBM7XJK4_5H_0024))
			{
				list.Add(i);
				if (_0023_003DzCBM7XJK4_5H_0024.FirstOnly)
				{
					break;
				}
			}
		}
		if (_0023_003DzCBM7XJK4_5H_0024.IsLeafSelection)
		{
			_0023_003Dze9sM4IQ_003D = _0023_003DzCBM7XJK4_5H_0024.LeafSelectionInfo.ToArray();
			return null;
		}
		list2.AddRange(SelectedItem.ConvertIndicesToItems(list, _0023_003DzCBM7XJK4_5H_0024.Parents, _0023_003DzY_0024ABPwh9wryC));
		_0023_003Dze9sM4IQ_003D = list2.ToArray();
		if (!flag)
		{
			return list.ToArray();
		}
		return null;
	}

	public bool AllBranchNodesAreBlockReferences(Entity entity, BlockKeyedCollection blocks)
	{
		if (entity is BlockReference blockReference)
		{
			if (blocks[blockReference.BlockName].Entities.Count == 0)
			{
				return true;
			}
			foreach (Entity entity2 in blocks[blockReference.BlockName].Entities)
			{
				if (!AllBranchNodesAreBlockReferences(entity2, blocks))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private bool _0023_003Dz4RlPrk9tv7S7(IIsolateParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DzfzF4rg7fFINY)
	{
		if (!(_0023_003DzfzF4rg7fFINY is BlockReference))
		{
			return _0023_003Dzlrl6ZJY_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzfzF4rg7fFINY);
		}
		return true;
	}

	internal IList<Entity> _0023_003Dzb27idIA2SfmZ()
	{
		if (_0023_003Dzkm9D6jYtZW1j == null || _0023_003Dzkm9D6jYtZW1j.Count == 0)
		{
			return Entities;
		}
		return Blocks[_0023_003Dzkm9D6jYtZW1j.Peek().BlockName].Entities;
	}

	internal Transformation _0023_003Dz8YKEbEWNU93g()
	{
		Transformation result;
		if (_0023_003Dzkm9D6jYtZW1j != null && _0023_003Dzkm9D6jYtZW1j.Count > 0)
		{
			result = new Identity();
			foreach (BlockReference item in _0023_003Dzkm9D6jYtZW1j)
			{
				result *= item.GetFullTransformation(Blocks);
			}
		}
		else
		{
			result = CurrentTransformation;
		}
		return result;
	}

	public virtual void ProcessSelectionEnclosed(Rectangle selectionBox, bool firstOnly, bool invert, SelectionChangedEventArgs eventArgs)
	{
		int[] selectedIndices;
		SelectedItem[] enclosedEntities = GetEnclosedEntities(selectionBox, firstOnly, out selectedIndices, selectableOnly: true);
		_0023_003DzHeomB7BdNilY(invert, enclosedEntities, eventArgs, _0023_003DzUsW18wvfQQpu: false);
	}

	public SelectedItem[] GetEnclosedEntities(Rectangle selectionBox, bool firstOnly, out int[] selectedIndices, bool selectableOnly = false)
	{
		selectedIndices = _0023_003DzKwAZQN5_0024ZUhsuyhnoQ_003D_003D(selectionBox, _0023_003Dzb27idIA2SfmZ(), firstOnly, selectableOnly, _0023_003Dz8YKEbEWNU93g(), out var _0023_003Dze9sM4IQ_003D, (Entity _0023_003DztJCl_0024mM_003D, FrustumParams _0023_003DzCBM7XJK4_5H_0024) => ((IEntityInternal)_0023_003DztJCl_0024mM_003D).AllVerticesInFrustum(_0023_003DzCBM7XJK4_5H_0024), _0023_003Dzkm9D6jYtZW1j);
		return _0023_003Dze9sM4IQ_003D;
	}

	public SelectedItem[] GetEnclosedEntitiesByPolygon(IList<Point2D> screenSelectionPolygon, bool firstOnly, out int[] selectedIndices, bool selectableOnly = false)
	{
		return new _0023_003DzKmjkuSZXr8_0024Rl_zzrXMbKJa7ooH82Q9K5A_003D_003D()._0023_003DzTpZvGLfXRihX(this, screenSelectionPolygon, _0023_003Dz7MoFvcekkC14: false, null, _0023_003Dzc_0024FDVjzZMRWW: false, firstOnly, selectableOnly, out selectedIndices, actionType.SelectByPolygonEnclosed);
	}

	internal int[] _0023_003DzZGKOM7ATzjE8QmOuTQ_003D_003D(IList<Point2D> _0023_003Dzp4f5WRL0NMHY, IList<Segment2D> _0023_003Dz2zHjLVwxp34g, int[] _0023_003DzBppTnBIbeUl7, double[] _0023_003DzYgijFM_0024VNOEd, Point2D _0023_003DzoYJjnU0_003D, Point2D _0023_003DzWRFixiU_003D, IList<Entity> _0023_003DzY_0024ABPwh9wryC, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, Transformation _0023_003Dz7olvtXbaWalx, out SelectedItem[] _0023_003DzzDNdOMv1nCY_0024, IsInScreenDelegate _0023_003DzHx8m_U_0ER_5, Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		_0023_003DzzDNdOMv1nCY_0024 = null;
		bool flag = true;
		object[] array = null;
		array = new object[2] { this, flag };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "/H,SJq\"aca", array);
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		ScreenPolygonParams screenPolygonParams = new ScreenPolygonParams(_0023_003DzBppTnBIbeUl7, _0023_003DzYgijFM_0024VNOEd, _0023_003Dzp4f5WRL0NMHY, _0023_003Dz2zHjLVwxp34g, _0023_003DzoYJjnU0_003D, _0023_003DzWRFixiU_003D, viewport._0023_003DzK_00241ezHQJ9Z3c, viewport._0023_003DzIjzPUT72VTAG, this, _0023_003Dz7olvtXbaWalx)
		{
			IsLeafSelection = (_0023_003DzCBASci_Gpxb1 == assemblySelectionType.Leaf),
			FirstOnly = _0023_003Dz_bIfLEkNPFmB
		};
		if (_0023_003Dzbq3BJR0_003D != null)
		{
			screenPolygonParams.Parents = _0023_003Dzbq3BJR0_003D;
		}
		return _0023_003Dz971H31F_6_0024g4(screenPolygonParams, _0023_003DzY_0024ABPwh9wryC, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, out _0023_003DzzDNdOMv1nCY_0024, _0023_003DzHx8m_U_0ER_5, _0023_003DzrDIvDNs4suuK6OKacQ_003D_003D: false);
	}

	private void _0023_003DzToKx2OsiwBh3kverVA_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, IList<Entity> _0023_003DzY_0024ABPwh9wryC, displayType _0023_003DzK_00241ezHQJ9Z3c, _0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX, ref Dictionary<int, SelectedItem> _0023_003DzVSL16zZBpyqs, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, bool _0023_003Dz7pVnAqEeBn6yN7UggIqxZvg_003D, bool _0023_003DzCq_00248LrgCN_f9)
	{
		_0023_003DzmNZD0Zs_003D.BeginDrawForSelection();
		ShaderParameters shaderParameters = new ShaderParameters(_0023_003DzmNZD0Zs_003D)
		{
			ViewFrame = _0023_003DzYzWi5Yw_003D.GetViewFrame(),
			Camera = _0023_003DzYzWi5Yw_003D.Camera,
			ShadowMode = _0023_003DznKkOfo8_003D.ShadowMode,
			ShadowQuality = _0023_003DznKkOfo8_003D.RealisticShadowQuality
		};
		_0023_003DzMgRCGgfmCVmb(_0023_003DzbOk8RJDeO_0024TX, _0023_003DzYzWi5Yw_003D, shaderParameters);
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		_0023_003DzmNZD0Zs_003D.ClearColor(Color.White);
		bool flag = (_0023_003DzbOk8RJDeO_0024TX & (_0023_003DzhFBmu_0024RpnRJ7)7) != 0 || _0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)128 || _0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)256 || (_0023_003DzbOk8RJDeO_0024TX & (_0023_003DzhFBmu_0024RpnRJ7)1536) != 0;
		_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		_0023_003DzmNZD0Zs_003D.ClearDepthStencil(!flag, stencilBuffer: true, 0);
		int _0023_003Dzsdr_I1A_003D = 0;
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		bool flag2 = _0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)8 || flag;
		if (_0023_003DzjGvm17_0024DzsnS == actionType.SelectVisibleByPolygon && flag2)
		{
			_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003Dz2sqMfo1EXHui(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D.Size, flag);
		}
		if (flag2)
		{
			_0023_003DzmNZD0Zs_003D.ProcessClippingPlanes(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D, updateGraphics: true);
		}
		else
		{
			_0023_003DzmNZD0Zs_003D.DisableClipPlanes();
		}
		if (_0023_003DzK_00241ezHQJ9Z3c == displayType.Wireframe && flag2)
		{
			_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonLine_NoCullFace);
		}
		else
		{
			_0023_003Dz_9qS3W815tFjCa_RC_0024JgHyk_003D(_0023_003Dz0fTtstT4IqGh(_0023_003DzYzWi5Yw_003D.DisplayMode), _0023_003Dzz4aiLqY_0024r7bL: false);
		}
		if (_0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)64)
		{
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff);
			_0023_003DzVSL16zZBpyqs = _0023_003DzYzWi5Yw_003D._0023_003Dz1eFClLc2ASGZ(_0023_003Dzsdr_I1A_003D, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D);
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestLess);
		}
		else
		{
			BlockKeyedCollection blockKeyedCollection = null;
			if (flag2)
			{
				blockKeyedCollection = _0023_003DzoE3BE__0024RS_DJ();
			}
			else if (_0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)32)
			{
				blockKeyedCollection = _0023_003DznJLjYKflIJCP;
			}
			if (_0023_003DzjGvm17_0024DzsnS != actionType.SelectVisibleByPolygon || !flag2)
			{
				_0023_003DzmNZD0Zs_003D.SetState((depthStencilStateType)(flag ? 851968 : 786432));
			}
			if (_0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)8)
			{
				ComputeEntitiesVisibilityParams _0023_003Dzt5jpbHs_003D = _0023_003DzdWWqz40ROLb5Pp383A_003D_003D(_0023_003DzPEEjwoPxhT6e(_0023_003DzYzWi5Yw_003D), _0023_003DzY_0024ABPwh9wryC);
				if (_0023_003Dz7pVnAqEeBn6yN7UggIqxZvg_003D)
				{
					_0023_003DzXS86eTnj2Efz(_0023_003Dzt5jpbHs_003D, _0023_003Dzk3KGpSl0I48qPYLcl6ZgXyfgAmDk: false, blockKeyedCollection, _0023_003DzFJlUhNYqkWjaoxcNmQ_003D_003D: false, _0023_003DzR_Y4Y8l6CHTLWNjKvLz_0024Yag_003D: false);
				}
				else
				{
					_0023_003DzNoWo3ia9iHbpna8dpg_003D_003D(_0023_003Dzt5jpbHs_003D, new FrustumParams(_0023_003DzYzWi5Yw_003D._0023_003DzLK0OwXvAsOsnI9nS_0024Q_003D_003D(_0023_003DzPHqp5dQ_003D: false), this, blockKeyedCollection));
				}
			}
			if ((_0023_003DzbOk8RJDeO_0024TX & (_0023_003DzhFBmu_0024RpnRJ7)4) != 0)
			{
				_0023_003DzMlxPoe72PCRQhFUzlNK1XCo_003D(_0023_003DzYzWi5Yw_003D);
			}
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.White);
			DrawForSelectionParams drawForSelectionParams = new DrawForSelectionParams(_0023_003DzYzWi5Yw_003D, blockKeyedCollection, shaderParameters)
			{
				LineWeightFactor = 0f,
				Attributes = new GfxAttributesWire(Layers),
				ParentSelected = false,
				SelectionStatus = selectionStatusType.Permanent,
				PlanarReflections = false,
				UiElementSelection = _0023_003Dz5ArZz23F17k_0024(_0023_003DzbOk8RJDeO_0024TX),
				LeafSelection = _0023_003DzCq_00248LrgCN_f9,
				InternalSelection = flag
			};
			if (_0023_003DzCq_00248LrgCN_f9)
			{
				drawForSelectionParams.IdItemsMap = new Dictionary<int, SelectedItem>();
			}
			DrawEntitiesParams drawEntitiesParams = new DrawEntitiesParams(this, _0023_003DzY_0024ABPwh9wryC, drawForSelectionParams, _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D: false)
			{
				SelectableOnly = _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D
			};
			bool locked = Layers[0].Locked;
			if (!flag2)
			{
				Layers[0].Locked = false;
			}
			if (_0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)16 || _0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)32)
			{
				_0023_003DzK_00241ezHQJ9Z3c = displayType.Shaded;
			}
			if (flag)
			{
				_0023_003DzX0fuIZ0_003D(_0023_003DzYzWi5Yw_003D.Camera, _0023_003DzAYcbN5Y_003D: true);
			}
			if (_0023_003DzK_00241ezHQJ9Z3c == displayType.Wireframe)
			{
				WorkspaceDrawForSelectionEntityDelegate drawCallBack;
				switch (_0023_003DzbOk8RJDeO_0024TX)
				{
				case (_0023_003DzhFBmu_0024RpnRJ7)6:
					_0023_003DzmNZD0Zs_003D.LockShaders(lockShader: true);
					drawCallBack = _0023_003DzPE1raRPmmJNN;
					drawCallBack = (WorkspaceDrawForSelectionEntityDelegate)Delegate.Combine(drawCallBack, (WorkspaceDrawForSelectionEntityDelegate)delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionVertices(data);
					});
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)2:
					drawCallBack = _0023_003DzPE1raRPmmJNN;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)4:
					_0023_003DzmNZD0Zs_003D.LockShaders(lockShader: true);
					drawCallBack = delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionVertices(data);
					};
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)128:
					drawCallBack = _0023_003Dz3h6UoJhfPPLMQQh4GUQU5oQ_003D;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)256:
					drawCallBack = _0023_003DzqaFVmwa_Rh9hzGrvEJwDUa4_003D;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)1536:
					drawCallBack = delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionSketchCurves(data);
					};
					drawCallBack = (WorkspaceDrawForSelectionEntityDelegate)Delegate.Combine(drawCallBack, new WorkspaceDrawForSelectionEntityDelegate(_0023_003DzwExT75lusObyLomd_qrgUEk_003D));
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)512:
					drawCallBack = _0023_003DzwExT75lusObyLomd_qrgUEk_003D;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)1024:
					drawCallBack = delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionSketchCurves(data);
					};
					break;
				default:
					drawCallBack = delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionWireframe(data);
					};
					break;
				}
				drawEntitiesParams.DrawParams.Isocurves = _0023_003DzAdpXPj_0024l7nqBsSXydw_003D_003D.ShowInternalWires;
				drawEntitiesParams.drawCallBack = drawCallBack;
			}
			else
			{
				WorkspaceDrawForSelectionEntityDelegate drawCallBack;
				switch (_0023_003DzbOk8RJDeO_0024TX)
				{
				case (_0023_003DzhFBmu_0024RpnRJ7)7:
					drawCallBack = _0023_003Dz1F3L86rBA66dWUpVtg_003D_003D;
					drawCallBack = (WorkspaceDrawForSelectionEntityDelegate)Delegate.Combine(drawCallBack, new WorkspaceDrawForSelectionEntityDelegate(_0023_003DzPE1raRPmmJNN));
					drawCallBack = (WorkspaceDrawForSelectionEntityDelegate)Delegate.Combine(drawCallBack, (WorkspaceDrawForSelectionEntityDelegate)delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionVertices(data);
					});
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)3:
					drawCallBack = _0023_003Dz1F3L86rBA66dWUpVtg_003D_003D;
					drawCallBack = (WorkspaceDrawForSelectionEntityDelegate)Delegate.Combine(drawCallBack, new WorkspaceDrawForSelectionEntityDelegate(_0023_003DzPE1raRPmmJNN));
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)5:
					drawCallBack = _0023_003Dz1F3L86rBA66dWUpVtg_003D_003D;
					drawCallBack = (WorkspaceDrawForSelectionEntityDelegate)Delegate.Combine(drawCallBack, (WorkspaceDrawForSelectionEntityDelegate)delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionVertices(data);
					});
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)6:
					drawCallBack = _0023_003DzPE1raRPmmJNN;
					drawCallBack = (WorkspaceDrawForSelectionEntityDelegate)Delegate.Combine(drawCallBack, (WorkspaceDrawForSelectionEntityDelegate)delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionVertices(data);
					});
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)1:
					drawCallBack = _0023_003Dz1F3L86rBA66dWUpVtg_003D_003D;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)2:
					drawCallBack = _0023_003DzPE1raRPmmJNN;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)4:
					drawCallBack = delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionVertices(data);
					};
					_0023_003DzmNZD0Zs_003D.LockShaders(lockShader: true);
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)128:
					drawCallBack = _0023_003Dz3h6UoJhfPPLMQQh4GUQU5oQ_003D;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)256:
					drawCallBack = _0023_003DzqaFVmwa_Rh9hzGrvEJwDUa4_003D;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)1536:
					drawCallBack = delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionSketchCurves(data);
					};
					drawCallBack = (WorkspaceDrawForSelectionEntityDelegate)Delegate.Combine(drawCallBack, new WorkspaceDrawForSelectionEntityDelegate(_0023_003DzwExT75lusObyLomd_qrgUEk_003D));
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)512:
					drawCallBack = _0023_003DzwExT75lusObyLomd_qrgUEk_003D;
					break;
				case (_0023_003DzhFBmu_0024RpnRJ7)1024:
					drawCallBack = delegate(Entity _0023_003DztJCl_0024mM_003D, DrawForSelectionParams data)
					{
						_0023_003DztJCl_0024mM_003D.DrawForSelectionSketchCurves(data);
					};
					break;
				default:
					drawCallBack = _0023_003DzheyifuKzO4fu;
					break;
				}
				drawEntitiesParams.drawCallBack = drawCallBack;
				if (!((DrawForSelectionParams)drawEntitiesParams.DrawParams).InternalSelection && _0023_003Dzkm9D6jYtZW1j != null && _0023_003Dzkm9D6jYtZW1j.Count != 0 && flag2)
				{
					_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.White);
					drawEntitiesParams.SelectInScope = true;
				}
			}
			DrawForSelection(drawEntitiesParams);
			if (flag)
			{
				_0023_003DzX0fuIZ0_003D(_0023_003DzYzWi5Yw_003D.Camera, _0023_003DzAYcbN5Y_003D: false);
			}
			Layers[0].Locked = locked;
			_0023_003DzVSL16zZBpyqs = ((DrawForSelectionParams)drawEntitiesParams.DrawParams).IdItemsMap;
			_0023_003DzmNZD0Zs_003D.LockShaders(lockShader: false);
		}
		if (_0023_003DzjGvm17_0024DzsnS == actionType.SelectVisibleByPolygon)
		{
			_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzwsOBM_pOKhnJ(_0023_003DzmNZD0Zs_003D);
		}
		_0023_003DzmNZD0Zs_003D.DisableClipPlanes();
		_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame();
		if (_0023_003DzbOk8RJDeO_0024TX != (_0023_003DzhFBmu_0024RpnRJ7)8)
		{
			_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.Dirty = true;
		}
		_0023_003DzmNZD0Zs_003D.EndDrawForSelection();
	}

	internal ComputeEntitiesVisibilityParams _0023_003DzdWWqz40ROLb5Pp383A_003D_003D(int _0023_003DzZnwLfu4_003D, IList<Entity> _0023_003DzY_0024ABPwh9wryC)
	{
		return new ComputeEntitiesVisibilityParams
		{
			viewportIndex = _0023_003DzZnwLfu4_003D,
			boundingBox = _0023_003Dz6CMmzY6fHGlL,
			entities = _0023_003DzY_0024ABPwh9wryC,
			entityGlobalMin = _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF,
			entityGlobalMax = _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr,
			layers = Layers,
			animating = _0023_003DzyobtGSd5_zcs()
		};
	}

	private void _0023_003DzMgRCGgfmCVmb(_0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX, Viewport _0023_003DzYzWi5Yw_003D, ShaderParameters _0023_003DzgcK4Z11iT1YA)
	{
		_0023_003DzYzWi5Yw_003D._0023_003DzjDuhintYzbDe(_0023_003DzNwtRJ3cLTrAy(), _0023_003DzR3sFNCI_003D: true);
		int[] viewFrame = _0023_003DzYzWi5Yw_003D.GetViewFrame();
		_0023_003DzYzWi5Yw_003D._0023_003DzEoxSq3a9jDkF(viewFrame);
		switch (_0023_003DzbOk8RJDeO_0024TX)
		{
		case (_0023_003DzhFBmu_0024RpnRJ7)16:
			if (_0023_003DzYzWi5Yw_003D._0023_003Dz4ry2vZefVkxX != null)
			{
				_0023_003DzYzWi5Yw_003D._0023_003Dz4ry2vZefVkxX._0023_003DzEnSwckvY9L5_0024yBIrhA_003D_003D(new DrawSceneParams
				{
					Viewport = _0023_003DzYzWi5Yw_003D,
					RenderContext = _0023_003DzmNZD0Zs_003D
				}, _0023_003DzpIzHYHy1ug2w: false, _0023_003DzFXbolQ32pxbU: false);
			}
			break;
		case (_0023_003DzhFBmu_0024RpnRJ7)1:
		case (_0023_003DzhFBmu_0024RpnRJ7)2:
		case (_0023_003DzhFBmu_0024RpnRJ7)3:
		case (_0023_003DzhFBmu_0024RpnRJ7)4:
		case (_0023_003DzhFBmu_0024RpnRJ7)5:
		case (_0023_003DzhFBmu_0024RpnRJ7)6:
		case (_0023_003DzhFBmu_0024RpnRJ7)7:
		case (_0023_003DzhFBmu_0024RpnRJ7)8:
		case (_0023_003DzhFBmu_0024RpnRJ7)128:
		case (_0023_003DzhFBmu_0024RpnRJ7)256:
		case (_0023_003DzhFBmu_0024RpnRJ7)512:
		case (_0023_003DzhFBmu_0024RpnRJ7)1024:
		case (_0023_003DzhFBmu_0024RpnRJ7)1536:
			_0023_003DzYzWi5Yw_003D.Camera.SetupModelViewProjection(RectangleF.Empty, setGraphics: true, shadowPass: false, reflection: false, CameraEyePosType.Center, applySceneTransformation: true);
			break;
		case (_0023_003DzhFBmu_0024RpnRJ7)32:
		{
			_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D.UpdateScreenToWorld(_0023_003DzYzWi5Yw_003D, viewFrame);
			DrawSceneParams _0023_003DzCBM7XJK4_5H_0024 = new DrawSceneParams
			{
				Viewport = _0023_003DzYzWi5Yw_003D,
				DrawScale = 1f,
				CameraEyePos = CameraEyePosType.Center,
				RenderContext = _0023_003DzmNZD0Zs_003D
			};
			_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003DzKa9hVOo_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzTdL_tg3V5Mp84BhbAA_003D_003D: false);
			_0023_003DzELQP8D2JDqnqVJI9HFgRULg_003D._0023_003Dz89cPk57rASTGmdmTnA_003D_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzpIzHYHy1ug2w: false, _0023_003DzTdL_tg3V5Mp84BhbAA_003D_003D: false);
			break;
		}
		case (_0023_003DzhFBmu_0024RpnRJ7)64:
			_0023_003DzYzWi5Yw_003D._0023_003DzsDZysFFbOXiw(_0023_003DzNwtRJ3cLTrAy());
			break;
		}
	}

	public void SetColorDrawForSelectionAndUpdateIdItemsMap<T>(DrawForSelectionParams data, ISelectableItem item, int partIndex = -1, int shellIndex = -1) where T : SelectedItem, new()
	{
		SetColorDrawForSelection(data.FalseColorIndex);
		if (!SuspendSetColorForSelection)
		{
			if (partIndex == -1)
			{
				data.IdItemsMap.Add(data.FalseColorIndex, new SelectedItem(data.Parents, item));
				return;
			}
			T val = new T();
			val.Init(data.Parents, item, partIndex, shellIndex);
			data.IdItemsMap.Add(data.FalseColorIndex, val);
		}
	}

	public void SetColorDrawForSelection(int currentEntityId)
	{
		if (!SuspendSetColorForSelection)
		{
			_0023_003DzmNZD0Zs_003D.GetRGBForSelection(currentEntityId, out var r, out var g, out var b);
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.FromArgb(r, g, b));
		}
	}

	protected virtual void DrawForSelection(DrawEntitiesParams myParams)
	{
		GfxAttributesWire originalAttributes = (GfxAttributesWire)myParams.DrawParams.Attributes.Clone();
		DrawForSelectionParams drawForSelectionParams = (DrawForSelectionParams)myParams.DrawParams;
		Stack<BlockReference> parents = _0023_003DzXAFLv4rg9xe4Zc55HFVZN491jl1d(drawForSelectionParams);
		Stack<BlockReference> parents2 = _0023_003DzZuBsUvr900Ui(drawForSelectionParams);
		for (int i = _0023_003DzafjhIPuMEU_KHEZdIg_003D_003D(myParams); i < myParams.entList.Count; i++)
		{
			Entity entity = myParams.entList[i];
			if ((entity is BlockReference blockReference && blockReference.BlockName.StartsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348594982))) || (!drawForSelectionParams.InternalSelection && !drawForSelectionParams.UiElementSelection && !_0023_003Dz4RlPrk9tv7S7(drawForSelectionParams, entity)))
			{
				continue;
			}
			if (!myParams.SelectableOnly || (entity.GetSelectability(parents) && !Layers.GetItemFast(entity.LayerName).Locked))
			{
				if (entity.IsVisibleAndInFrustum(parents2, Layers, AttributeReferenceVisibilityMode))
				{
					if (!PropagateAttributesAndProcessBlockReferenceForSelection(myParams, entity, originalAttributes, DrawForSelection))
					{
						continue;
					}
					myParams.drawCallBack(entity, drawForSelectionParams);
				}
			}
			else
			{
				drawForSelectionParams.Viewport.Camera.ZBufferData.Dirty = true;
			}
			if (!drawForSelectionParams.InternalSelection && !(entity is NestedEntity) && ((myParams.SelectInScope && myParams.InScope) || (!myParams.SelectInScope && (drawForSelectionParams.Parents.Count == 0 || drawForSelectionParams.LeafSelection))))
			{
				drawForSelectionParams.FalseColorIndex++;
			}
		}
		_0023_003DzzThxH8goktC_0024();
	}

	private Stack<BlockReference> _0023_003DzXAFLv4rg9xe4Zc55HFVZN491jl1d(DrawForSelectionParams _0023_003DzmfiOMu6nigKS)
	{
		if (_0023_003DzmfiOMu6nigKS.LeafSelection)
		{
			return _0023_003DzmfiOMu6nigKS.FullParents;
		}
		return Parents;
	}

	protected virtual bool PropagateAttributesAndProcessBlockReferenceForSelection(DrawEntitiesParams myParams, Entity ent, GfxAttributesWire originalAttributes, WorkspaceDrawForSelectionCallback callBack)
	{
		myParams.DrawParams.Attributes.Assign(originalAttributes);
		myParams.DrawParams.Attributes.Propagate(ent, Layers.GetItemFast(ent.LayerName), _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D);
		if (ent.IsPolygonal())
		{
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		}
		else
		{
			switch (ent.GetPrimitiveTypeForWireframe(myParams.DrawParams))
			{
			case shaderPrimitiveType.Polygon:
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
				break;
			case shaderPrimitiveType.Point:
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLightsThickPoints);
				break;
			default:
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLightsThickLines);
				break;
			}
		}
		DrawForSelectionParams drawForSelectionParams = (DrawForSelectionParams)myParams.DrawParams;
		if (myParams.SelectInScope)
		{
			if (myParams.InScope && ((!drawForSelectionParams.LeafSelection && drawForSelectionParams.Parents.Count == _0023_003Dzkm9D6jYtZW1j.Count) || (drawForSelectionParams.LeafSelection && !(ent is BlockReference))))
			{
				SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedItem>(drawForSelectionParams, ent);
			}
		}
		else if (!drawForSelectionParams.InternalSelection)
		{
			if ((!drawForSelectionParams.LeafSelection && drawForSelectionParams.Parents.Count == 0) || (drawForSelectionParams.LeafSelection && !(ent is BlockReference)))
			{
				SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedItem>(drawForSelectionParams, ent);
			}
			else if (!drawForSelectionParams.LeafSelection && drawForSelectionParams.Parents.Count > 0 && !drawForSelectionParams.ParentIsolated && _0023_003Dzlrl6ZJY_003D(drawForSelectionParams, ent))
			{
				drawForSelectionParams.FalseColorIndex++;
				SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedItem>(drawForSelectionParams, ent);
			}
		}
		if (ent is BlockReference blockReference)
		{
			blockReference.DrawForSelection(myParams, callBack);
			return false;
		}
		float num = ((GfxAttributesWire)drawForSelectionParams.Attributes).LineWeight;
		if (_0023_003Dzfk9mqRZJav3i == selectionFilterType.Vertex && num < 1f)
		{
			num = 1f;
		}
		ent.SetLineWeight(_0023_003DzmNZD0Zs_003D, num);
		return true;
	}

	internal void _0023_003Dzvt4CNgJSomsF(SelectionChangedEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzRQvCVfFe6NEO(_0023_003Dz1SmHC4c_003D);
		_0023_003DzZ5L0bhmvC_0024K7 = true;
		if (_0023_003DzYVdraYc_003D == null)
		{
			return;
		}
		for (int i = 0; i < _0023_003Dz1SmHC4c_003D.AddedItems.Count; i++)
		{
			bool flag = false;
			for (int j = 0; j < _0023_003Dz1SmHC4c_003D.RemovedItems.Count; j++)
			{
				if (_0023_003Dz1SmHC4c_003D.AddedItems[i].Equals(_0023_003Dz1SmHC4c_003D.RemovedItems[j]))
				{
					_0023_003Dz1SmHC4c_003D.RemovedItems.RemoveAt(j);
					j--;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				_0023_003Dz1SmHC4c_003D.AddedItems.RemoveAt(i);
				i--;
			}
		}
		_0023_003DzYVdraYc_003D(this, _0023_003Dz1SmHC4c_003D);
	}

	private void _0023_003DzRQvCVfFe6NEO(SelectionChangedEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (!_0023_003DzJQOMinrXgHWjlFmaGZBDrwI_003D())
		{
			return;
		}
		foreach (SelectedItem addedItem in _0023_003Dz1SmHC4c_003D.AddedItems)
		{
			if (addedItem.Item is Entity entity && entity.GetColorRecursively(addedItem.Parents, Layers, this).A < byte.MaxValue)
			{
				ProcessSemiTransparent();
				return;
			}
		}
		foreach (SelectedItem removedItem in _0023_003Dz1SmHC4c_003D.RemovedItems)
		{
			if (removedItem.Item is Entity entity2 && entity2.GetColorRecursively(removedItem.Parents, Layers, this).A < byte.MaxValue)
			{
				ProcessSemiTransparent();
				break;
			}
		}
	}

	public bool ScreenToPlane(System.Drawing.Point mousePos, Plane plane, out Point3D intPoint)
	{
		return ScreenToPlane(mousePos, plane.Equation, out intPoint);
	}

	public bool ScreenToPlane(System.Drawing.Point mousePos, PlaneEquation pe, out Point3D intPoint)
	{
		return _0023_003DzipBYly6zFKAp()._0023_003DzeMAiWyb2kqLcCvqczQ_003D_003D(mousePos, pe, out intPoint);
	}

	public Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, Plane plane)
	{
		return _0023_003DzipBYly6zFKAp()._0023_003DzeMAiWyb2kqLcCvqczQ_003D_003D(mousePointList, plane.Equation);
	}

	public Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, PlaneEquation pe)
	{
		return _0023_003DzipBYly6zFKAp()._0023_003DzeMAiWyb2kqLcCvqczQ_003D_003D(mousePointList, pe);
	}

	public Point3D[] ScreenToWorld(IList<System.Drawing.Point> mousePointList)
	{
		return _0023_003DzipBYly6zFKAp().ScreenToWorld(mousePointList);
	}

	public Point3D ScreenToWorld(System.Drawing.Point mousePos)
	{
		return _0023_003DzipBYly6zFKAp().ScreenToWorld(mousePos);
	}

	public Point3D WorldToScreen(Point3D point)
	{
		return WorldToScreen(point.X, point.Y, point.Z);
	}

	public Point3D WorldToScreen(double x, double y, double z)
	{
		return _0023_003DzipBYly6zFKAp()._0023_003Dzr5tJNXIIzUWm(x, y, z);
	}

	public Point3D[] WorldToScreen(IList<Point3D> pointList)
	{
		return _0023_003DzipBYly6zFKAp()._0023_003Dzr5tJNXIIzUWm(pointList);
	}

	public int FindClosestVertex(System.Drawing.Point mousePos, double maxDistance, out Point3D closest)
	{
		return FindClosestVertex(mousePos, maxDistance, typeof(object), out closest);
	}

	public int FindClosestVertex(System.Drawing.Point mousePos, double maxDistance, Type entType, out Point3D closest)
	{
		HitVertex _0023_003Dzm3MCkbPXRCTH;
		int result = _0023_003DzAbDPDZGfEizbj6PLYw_003D_003D(null, mousePos, maxDistance, entType, out _0023_003Dzm3MCkbPXRCTH);
		closest = _0023_003Dzm3MCkbPXRCTH.Vertex;
		return result;
	}

	public int FindClosestVertex(System.Drawing.Point mousePos, double maxDistance, out int closestIndex)
	{
		return FindClosestVertex(mousePos, maxDistance, typeof(object), out closestIndex);
	}

	public HitVertex FindClosestVertex(Entity entity, System.Drawing.Point mousePos, double maxDistance)
	{
		_0023_003DzAbDPDZGfEizbj6PLYw_003D_003D(entity, mousePos, maxDistance, typeof(object), out var _0023_003Dzm3MCkbPXRCTH);
		return _0023_003Dzm3MCkbPXRCTH;
	}

	public int FindClosestVertex(System.Drawing.Point mousePos, double maxDistance, out HitVertex closestVertex)
	{
		return _0023_003DzAbDPDZGfEizbj6PLYw_003D_003D(null, mousePos, maxDistance, typeof(object), out closestVertex);
	}

	public int FindClosestVertex(System.Drawing.Point mousePos, double maxDistance, Type entType, out HitVertex closestVertex)
	{
		return _0023_003DzAbDPDZGfEizbj6PLYw_003D_003D(null, mousePos, maxDistance, entType, out closestVertex);
	}

	public List<HitVertex> FindClosestVertices(System.Drawing.Point mousePos, double maxDistance)
	{
		return _0023_003DzuQaXqLriwx2HG6qRRHPFKMQ_003D(null, mousePos, maxDistance, typeof(object));
	}

	public List<HitVertex> FindClosestVertices(System.Drawing.Point mousePos, double maxDistance, Type entType)
	{
		return _0023_003DzuQaXqLriwx2HG6qRRHPFKMQ_003D(null, mousePos, maxDistance, entType);
	}

	public List<HitVertex> FindClosestVertices(Entity entity, System.Drawing.Point mousePos, double maxDistance)
	{
		return _0023_003DzuQaXqLriwx2HG6qRRHPFKMQ_003D(entity, mousePos, maxDistance, typeof(object));
	}

	private List<HitVertex> _0023_003DzuQaXqLriwx2HG6qRRHPFKMQ_003D(Entity _0023_003DzpWC0efg_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq, double _0023_003DzI5kIR1l4XL1i, Type _0023_003DzuYgZ0Q4xmWsG)
	{
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		int[] viewFrame = viewport.GetViewFrame();
		double sqrDistance = _0023_003DzI5kIR1l4XL1i * _0023_003DzI5kIR1l4XL1i;
		FindClosestVerticesParams findClosestVerticesParams = new FindClosestVerticesParams(null, this, _0023_003DzuYgZ0Q4xmWsG, _0023_003DzTYCHRugcseEq, sqrDistance, _0023_003Dz0P1LCYH__O4t(), _0023_003DzNwtRJ3cLTrAy(), viewport.Camera, viewFrame);
		if (_0023_003DzpWC0efg_003D != null)
		{
			if (_0023_003DznAcOiVJYxa1q(_0023_003DzpWC0efg_003D))
			{
				_0023_003DzpWC0efg_003D.FindClosestVertices(findClosestVerticesParams, 0);
			}
		}
		else
		{
			int count = Entities.Count;
			Stack<BlockReference> parents = new Stack<BlockReference>();
			if (_0023_003DzuYgZ0Q4xmWsG == typeof(object))
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = Entities[i];
					if (entity.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode))
					{
						entity.FindClosestVertices(findClosestVerticesParams, i);
					}
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					Entity entity = Entities[j];
					if ((_0023_003DzuYgZ0Q4xmWsG == entity.GetType() || entity is BlockReference) && entity.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode))
					{
						entity.FindClosestVertices(findClosestVerticesParams, j);
					}
				}
			}
		}
		return findClosestVerticesParams.ClosestVertices;
	}

	public int FindClosestVertex(System.Drawing.Point mousePos, double maxDistance, Type entType, out int closestIndex)
	{
		HitVertex _0023_003Dzm3MCkbPXRCTH;
		int result = _0023_003DzAbDPDZGfEizbj6PLYw_003D_003D(null, mousePos, maxDistance, entType, out _0023_003Dzm3MCkbPXRCTH);
		closestIndex = _0023_003Dzm3MCkbPXRCTH.VertexIndex;
		return result;
	}

	private int _0023_003DzAbDPDZGfEizbj6PLYw_003D_003D(Entity _0023_003DzpWC0efg_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq, double _0023_003DzI5kIR1l4XL1i, Type _0023_003DzuYgZ0Q4xmWsG, out HitVertex _0023_003Dzm3MCkbPXRCTH)
	{
		int num = -1;
		Viewport viewport = _0023_003DzipBYly6zFKAp();
		int[] viewFrame = viewport.GetViewFrame();
		double sqrDistance = _0023_003DzI5kIR1l4XL1i * _0023_003DzI5kIR1l4XL1i;
		FindClosestVertexParams findClosestVertexParams = new FindClosestVertexParams(CurrentTransformation, this, _0023_003DzuYgZ0Q4xmWsG, _0023_003DzTYCHRugcseEq, sqrDistance, _0023_003Dz0P1LCYH__O4t(), _0023_003DzNwtRJ3cLTrAy(), viewport.Camera, viewFrame);
		if (_0023_003DzpWC0efg_003D != null)
		{
			_0023_003Dzm3MCkbPXRCTH = null;
			if (_0023_003DznAcOiVJYxa1q(_0023_003DzpWC0efg_003D) && _0023_003DzpWC0efg_003D.FindClosestVertex(findClosestVertexParams, 0))
			{
				_0023_003Dzm3MCkbPXRCTH = findClosestVertexParams.ClosestVertex;
				num = 0;
			}
		}
		else
		{
			int count = Entities.Count;
			Stack<BlockReference> parents = new Stack<BlockReference>();
			if (_0023_003DzuYgZ0Q4xmWsG == typeof(object))
			{
				for (int i = 0; i < count; i++)
				{
					Entity entity = Entities[i];
					if (entity.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode) && entity.FindClosestVertex(findClosestVertexParams, i))
					{
						num = i;
					}
				}
			}
			else
			{
				for (int j = 0; j < count; j++)
				{
					Entity entity = Entities[j];
					if ((_0023_003DzuYgZ0Q4xmWsG == entity.GetType() || entity is BlockReference) && entity.IsVisibleAndInFrustum(parents, Layers, AttributeReferenceVisibilityMode) && entity.FindClosestVertex(findClosestVertexParams, j))
					{
						num = j;
					}
				}
			}
			HitVertex closestVertex = findClosestVertexParams.ClosestVertex;
			if (num >= 0)
			{
				Entity entity = ((closestVertex.Parents == null || closestVertex.Parents.Count <= 0) ? Entities[num] : Blocks[closestVertex.Parents[closestVertex.Parents.Count - 1].BlockName].Entities[closestVertex.EntityIndex]);
				if (!(entity is Brep))
				{
					if (!(entity is Solid))
					{
						closestVertex.FaceIndex = -1;
					}
					closestVertex.ShellOrElementIndex = -1;
				}
			}
			_0023_003Dzm3MCkbPXRCTH = closestVertex;
		}
		return num;
	}

	protected internal virtual bool IsCloserVertex(Point3D projectedPt, double squareDistance, double currentMinimumSquareDistance)
	{
		return squareDistance < currentMinimumSquareDistance;
	}

	public void UpdateVisibleSelection()
	{
		foreach (Viewport item in _0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
		{
			item.Camera.ZBufferData.SelectionImage.Clear();
		}
	}

	public int GetEntityUnderMouseCursor(System.Drawing.Point mousePos, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		if (_0023_003DzSTCto4yqfbV4())
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595256));
		}
		int result = -1;
		if (_0023_003DzipBYly6zFKAp().Contains(mousePos))
		{
			Rectangle _0023_003DzCiKS5oMdHowF = _0023_003DzSIHqNiiiNjYN(mousePos, (_0023_003DzhFBmu_0024RpnRJ7)8);
			SelectedItem[] _0023_003DzzDNdOMv1nCY_0024;
			int[] array = _0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB: true, _0023_003DzOWfUZLjOSimJ(), (_0023_003DzhFBmu_0024RpnRJ7)8, selectableOnly, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out _0023_003DzzDNdOMv1nCY_0024);
			if (array != null && array.Length != 0)
			{
				result = array[0];
			}
		}
		return result;
	}

	public SelectedItem GetItemUnderMouseCursor(System.Drawing.Point mousePos, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		SelectedItem[] array = _0023_003DzqbHFKAkQdkNK4Y2H5A_003D_003D(_0023_003DzipBYly6zFKAp(), mousePos, _0023_003DzOWfUZLjOSimJ(), _0023_003Dzf4r6oggNIe3m(_0023_003Dz28QCun7pbbWH), _0023_003Dz_bIfLEkNPFmB: true, selectableOnly, _0023_003DznugYzyWkU3Do == assemblySelectionType.Leaf);
		if (array.Length == 0)
		{
			return null;
		}
		return array[0];
	}

	public int GetLabelUnderMouseCursor(System.Drawing.Point mousePos, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		int result = -1;
		if (_0023_003DzipBYly6zFKAp().Contains(mousePos))
		{
			Rectangle _0023_003DzCiKS5oMdHowF = _0023_003DzSIHqNiiiNjYN(mousePos, (_0023_003DzhFBmu_0024RpnRJ7)64);
			SelectedItem[] _0023_003DzzDNdOMv1nCY_0024;
			int[] array = _0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB: true, Entities, (_0023_003DzhFBmu_0024RpnRJ7)64, selectableOnly, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out _0023_003DzzDNdOMv1nCY_0024);
			if (array != null && array.Length != 0)
			{
				result = array[0];
			}
		}
		return result;
	}

	internal int _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(IFace _0023_003DzpWC0efg_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq, out Point3D _0023_003DzFDE95F8PBjPy, out int _0023_003DzOV1WUCpWLDhq)
	{
		IList<HitTriangle> list = _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(_0023_003DzpWC0efg_003D, _0023_003DzTYCHRugcseEq);
		if (list.Count > 0)
		{
			_0023_003DzFDE95F8PBjPy = list[0].IntersectionPoint;
			_0023_003DzOV1WUCpWLDhq = list[0].TriangleIndex;
		}
		else
		{
			_0023_003DzFDE95F8PBjPy = new Point3D();
			_0023_003DzOV1WUCpWLDhq = -1;
		}
		return list.Count;
	}

	internal int _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(SelectedItem _0023_003DzWhRHNgk_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq, out Point3D _0023_003DzFDE95F8PBjPy, out int _0023_003DzOV1WUCpWLDhq)
	{
		IList<HitTriangle> list = _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(_0023_003DzWhRHNgk_003D, _0023_003DzTYCHRugcseEq);
		if (list != null && list.Count > 0)
		{
			_0023_003DzFDE95F8PBjPy = list[0].IntersectionPoint;
			_0023_003DzOV1WUCpWLDhq = list[0].TriangleIndex;
			return list.Count;
		}
		_0023_003DzFDE95F8PBjPy = Point3D.Origin;
		_0023_003DzOV1WUCpWLDhq = -1;
		return 0;
	}

	internal IList<HitTriangle> _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(IFace _0023_003DzpWC0efg_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq)
	{
		return _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(new SelectedItem((Entity)_0023_003DzpWC0efg_003D), _0023_003DzTYCHRugcseEq);
	}

	internal IList<HitTriangle> _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(SelectedItem _0023_003DzWhRHNgk_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq)
	{
		if (_0023_003DzWhRHNgk_003D == null)
		{
			return null;
		}
		_0023_003DzbC32PQM_003D(_0023_003DzWhRHNgk_003D);
		Segment3D rayUnderCursor = _0023_003DzipBYly6zFKAp().GetRayUnderCursor(_0023_003DzTYCHRugcseEq);
		Transformation transformation = GetStackTransformation(_0023_003DzWhRHNgk_003D.Parents);
		if (CurrentTransformation != null)
		{
			transformation = CurrentTransformation * transformation;
		}
		return ((IFace)_0023_003DzWhRHNgk_003D.Item).FindClosestTriangle(transformation, rayUnderCursor);
	}

	private bool _0023_003DzbC32PQM_003D(SelectedItem _0023_003DzWhRHNgk_003D)
	{
		if (_0023_003DzWhRHNgk_003D.Parents.Count == 0)
		{
			for (int i = 0; i < Entities.Count; i++)
			{
				if (Entities[i] == _0023_003DzWhRHNgk_003D.Item)
				{
					return true;
				}
			}
		}
		else
		{
			BlockReference blockReference = _0023_003DzWhRHNgk_003D.Parents.Last();
			for (int j = 0; j < Entities.Count; j++)
			{
				if (Entities[j] == blockReference)
				{
					return true;
				}
			}
		}
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595629));
	}

	private bool _0023_003DznAcOiVJYxa1q(Entity _0023_003DztJCl_0024mM_003D)
	{
		for (int i = 0; i < Entities.Count; i++)
		{
			if (Entities[i] == _0023_003DztJCl_0024mM_003D)
			{
				return true;
			}
		}
		throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595629));
	}

	public void RotateCamera(System.Drawing.Point mouseLocation)
	{
		_0023_003DzipBYly6zFKAp().RotateCamera(mouseLocation);
	}

	public void SetView(Vector3D direction, bool fit, int margin = 10, bool selectedOnly = false)
	{
		SetView(direction, fit, AnimateCamera, margin, selectedOnly);
	}

	public void SetView(Vector3D direction, bool fit, bool animate, int margin = 10, bool selectedOnly = false)
	{
		_0023_003DzipBYly6zFKAp().SetView(direction, fit, animate, margin, selectedOnly);
	}

	public void SetView(Vector3D direction, Vector3D upVector, bool fit, int margin = 10, bool selectedOnly = false)
	{
		SetView(direction, upVector, fit, AnimateCamera, margin, selectedOnly);
	}

	public void SetView(Vector3D direction, Vector3D upVector, bool fit, bool animate, int margin = 10, bool selectedOnly = false)
	{
		_0023_003DzipBYly6zFKAp().SetView(direction, upVector, fit, animate, margin, selectedOnly);
	}

	public int[] GetAllEntitiesUnderMouseCursor(System.Drawing.Point mousePos, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		if (_0023_003DzipBYly6zFKAp().Contains(mousePos))
		{
			if (Entities.Count == 0)
			{
				return new int[0];
			}
			Rectangle _0023_003DzCiKS5oMdHowF = _0023_003DzSIHqNiiiNjYN(mousePos, (_0023_003DzhFBmu_0024RpnRJ7)8);
			SelectedItem[] _0023_003DzzDNdOMv1nCY_0024;
			return _0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB: false, _0023_003DzOWfUZLjOSimJ(), (_0023_003DzhFBmu_0024RpnRJ7)8, selectableOnly, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DznugYzyWkU3Do == assemblySelectionType.Leaf, out _0023_003DzzDNdOMv1nCY_0024);
		}
		return new int[0];
	}

	public SelectedItem[] GetAllItemsUnderMouseCursor(System.Drawing.Point mousePos, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		if (_0023_003DzipBYly6zFKAp().Contains(mousePos))
		{
			if (Entities.Count == 0)
			{
				return new SelectedItem[0];
			}
			return _0023_003DzqbHFKAkQdkNK4Y2H5A_003D_003D(_0023_003DzipBYly6zFKAp(), mousePos, _0023_003DzOWfUZLjOSimJ(), _0023_003Dzf4r6oggNIe3m(_0023_003Dz28QCun7pbbWH), _0023_003Dz_bIfLEkNPFmB: false, selectableOnly, _0023_003DznugYzyWkU3Do == assemblySelectionType.Leaf);
		}
		return new SelectedItem[0];
	}

	public int[] GetAllLabelsUnderMouseCursor(System.Drawing.Point mousePos, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		if (_0023_003DzipBYly6zFKAp().Contains(mousePos))
		{
			if (_0023_003DzipBYly6zFKAp()._0023_003DzF5TdZcc_003D.Count == 0)
			{
				return new int[0];
			}
			Rectangle _0023_003DzCiKS5oMdHowF = _0023_003DzSIHqNiiiNjYN(mousePos, (_0023_003DzhFBmu_0024RpnRJ7)64);
			SelectedItem[] _0023_003DzzDNdOMv1nCY_0024;
			return _0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB: false, _0023_003DzOWfUZLjOSimJ(), (_0023_003DzhFBmu_0024RpnRJ7)64, selectableOnly, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DznugYzyWkU3Do == assemblySelectionType.Leaf, out _0023_003DzzDNdOMv1nCY_0024);
		}
		return new int[0];
	}

	private Rectangle _0023_003DzSIHqNiiiNjYN(System.Drawing.Point _0023_003DzTYCHRugcseEq, _0023_003DzhFBmu_0024RpnRJ7 _0023_003DzyAqpxW8jop_0024U)
	{
		int num = PickBoxSize;
		if (_0023_003DzyAqpxW8jop_0024U == (_0023_003DzhFBmu_0024RpnRJ7)16 || _0023_003DzyAqpxW8jop_0024U == (_0023_003DzhFBmu_0024RpnRJ7)32)
		{
			num = 2;
		}
		return new Rectangle(_0023_003DzTYCHRugcseEq.X - num / 2, _0023_003DzTYCHRugcseEq.Y - num / 2, num, num);
	}

	internal SelectedItem[] _0023_003DzqbHFKAkQdkNK4Y2H5A_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq, IList<Entity> _0023_003DzY_0024ABPwh9wryC, _0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, bool _0023_003DzCq_00248LrgCN_f9)
	{
		if (!_0023_003DzYzWi5Yw_003D.Contains(_0023_003DzTYCHRugcseEq))
		{
			return Array.Empty<SelectedItem>();
		}
		Rectangle _0023_003DzCiKS5oMdHowF = _0023_003DzSIHqNiiiNjYN(_0023_003DzTYCHRugcseEq, _0023_003DzbOk8RJDeO_0024TX);
		return _0023_003Dz59_89Uw0jMUB7bKAfw_003D_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003DzY_0024ABPwh9wryC, _0023_003DzbOk8RJDeO_0024TX, _0023_003Dz_bIfLEkNPFmB, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, _0023_003DzCq_00248LrgCN_f9);
	}

	internal SelectedItem[] _0023_003Dz59_89Uw0jMUB7bKAfw_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, Rectangle _0023_003DzCiKS5oMdHowF, IList<Entity> _0023_003DzY_0024ABPwh9wryC, _0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, bool _0023_003DzCq_00248LrgCN_f9)
	{
		_0023_003DzmNZD0Zs_003D.MakeCurrent();
		bool flag = (_0023_003DzbOk8RJDeO_0024TX & (_0023_003DzhFBmu_0024RpnRJ7)2) != 0 || (_0023_003DzbOk8RJDeO_0024TX & (_0023_003DzhFBmu_0024RpnRJ7)1) != 0 || (_0023_003DzbOk8RJDeO_0024TX & (_0023_003DzhFBmu_0024RpnRJ7)4) != 0;
		_0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX2 = (flag ? ((_0023_003DzhFBmu_0024RpnRJ7)8) : _0023_003DzbOk8RJDeO_0024TX);
		_0023_003DzXVHxU6dYdxpX(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, _0023_003DzY_0024ABPwh9wryC, _0023_003DzbOk8RJDeO_0024TX2, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9, out var _0023_003DzzDNdOMv1nCY_0024);
		if (_0023_003DzzDNdOMv1nCY_0024.Length == 0 || !flag)
		{
			return _0023_003DzzDNdOMv1nCY_0024;
		}
		if (_0023_003DzzDNdOMv1nCY_0024.Length > 1)
		{
			_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerSelectionImage = null;
			_0023_003DzlA0QuPF2P1Np = null;
		}
		else if (_0023_003DzzDNdOMv1nCY_0024.Length == 1 && !_0023_003DzzDNdOMv1nCY_0024[0].Equals(_0023_003DzlA0QuPF2P1Np))
		{
			_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerSelectionImage = null;
			_0023_003DzlA0QuPF2P1Np = _0023_003DzzDNdOMv1nCY_0024[0];
		}
		return _0023_003DzIBIolpLAymgla__wFA_003D_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzCiKS5oMdHowF, _0023_003DzbOk8RJDeO_0024TX, _0023_003Dz_bIfLEkNPFmB, _0023_003DzzDNdOMv1nCY_0024);
	}

	public int[] GetAllVisibleEntities(Rectangle selectionBox, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		SelectedItem[] _0023_003DzzDNdOMv1nCY_0024;
		return _0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), selectionBox, _0023_003Dz_bIfLEkNPFmB: false, _0023_003DzOWfUZLjOSimJ(), (_0023_003DzhFBmu_0024RpnRJ7)8, selectableOnly, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out _0023_003DzzDNdOMv1nCY_0024);
	}

	public SelectedItem[] GetAllVisibleItems(Rectangle selectionBox, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		return _0023_003Dz59_89Uw0jMUB7bKAfw_003D_003D(_0023_003DzipBYly6zFKAp(), selectionBox, _0023_003DzOWfUZLjOSimJ(), _0023_003Dzf4r6oggNIe3m(_0023_003Dz28QCun7pbbWH), _0023_003Dz_bIfLEkNPFmB: false, selectableOnly, _0023_003DznugYzyWkU3Do == assemblySelectionType.Leaf);
	}

	public SelectedItem[] GetAllVisibleItemsByPolygon(IList<Point2D> screenSelectionPolygon, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		if (_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzF3HKD2trntQC())
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595695));
		}
		int[] _0023_003Dz5IUleg8WwUAm;
		SelectedItem[] result = _0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzTpZvGLfXRihX(this, screenSelectionPolygon, _0023_003Dz7MoFvcekkC14: false, null, _0023_003Dzc_0024FDVjzZMRWW: false, _0023_003Dz_bIfLEkNPFmB: false, selectableOnly, out _0023_003Dz5IUleg8WwUAm, actionType.SelectVisibleByPolygon);
		_0023_003DzUmBxYAzU2uTkg_0024RCYg_003D_003D._0023_003DzxEpSi5o_003D();
		return result;
	}

	public int[] GetAllVisibleLabels(Rectangle selectionBox, bool selectableOnly = true)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		SelectedItem[] _0023_003DzzDNdOMv1nCY_0024;
		return _0023_003DzXVHxU6dYdxpX(_0023_003DzipBYly6zFKAp(), selectionBox, _0023_003Dz_bIfLEkNPFmB: false, Entities, (_0023_003DzhFBmu_0024RpnRJ7)64, selectableOnly, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: false, out _0023_003DzzDNdOMv1nCY_0024);
	}

	private bool _0023_003Dz5ArZz23F17k_0024(_0023_003DzhFBmu_0024RpnRJ7 _0023_003DzP5xFpBj3V9MA)
	{
		if (_0023_003DzP5xFpBj3V9MA != (_0023_003DzhFBmu_0024RpnRJ7)32 && _0023_003DzP5xFpBj3V9MA != (_0023_003DzhFBmu_0024RpnRJ7)16)
		{
			return _0023_003DzP5xFpBj3V9MA == (_0023_003DzhFBmu_0024RpnRJ7)64;
		}
		return true;
	}

	private protected int[] _0023_003DzXVHxU6dYdxpX(Viewport _0023_003DzYzWi5Yw_003D, Rectangle _0023_003DzCiKS5oMdHowF, bool _0023_003Dz_bIfLEkNPFmB, IList<Entity> _0023_003DzY_0024ABPwh9wryC, _0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, bool _0023_003DzAai34pBQWjIKyoZ60A_003D_003D, bool _0023_003DzCq_00248LrgCN_f9, out SelectedItem[] _0023_003DzzDNdOMv1nCY_0024)
	{
		if (_0023_003Dz3cqGIkKFSLfbvz879SlfmFY_003D)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595498));
		}
		bool flag = _0023_003DzmI92LKJxZvwJMfDbVw_003D_003D(_0023_003DzbOk8RJDeO_0024TX);
		bool firstOnly = _0023_003Dz_bIfLEkNPFmB && !flag;
		_0023_003DzmNZD0Zs_003D.MakeCurrent();
		int num = ((_0023_003DzbOk8RJDeO_0024TX != (_0023_003DzhFBmu_0024RpnRJ7)64) ? _0023_003DzY_0024ABPwh9wryC.Count : _0023_003DzYzWi5Yw_003D.Labels.Count);
		Dictionary<int, SelectedItem> _0023_003DzVSL16zZBpyqs = null;
		_0023_003DzzDNdOMv1nCY_0024 = Array.Empty<SelectedItem>();
		if (num == 0)
		{
			return null;
		}
		bool num2 = _0023_003Dz5ArZz23F17k_0024(_0023_003DzbOk8RJDeO_0024TX);
		bool flag2 = !num2 && _0023_003DzbOk8RJDeO_0024TX != (_0023_003DzhFBmu_0024RpnRJ7)8;
		int stride;
		int bpp;
		byte[] rgbValues;
		if (num2 || (flag2 && _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerSelectionImage == null) || ActionMode == actionType.SelectVisibleByPolygon || _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.ChangedView(_0023_003DzYzWi5Yw_003D.Camera.GetModelViewProjectionMatrix(), _0023_003DzCq_00248LrgCN_f9) || (!flag2 && _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D != _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.SelectableOnly))
		{
			_0023_003DzToKx2OsiwBh3kverVA_003D_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzY_0024ABPwh9wryC, _0023_003DzYzWi5Yw_003D.DisplayMode, _0023_003DzbOk8RJDeO_0024TX, ref _0023_003DzVSL16zZBpyqs, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D, _0023_003DzCq_00248LrgCN_f9);
			if (!(_0023_003DzbOk8RJDeO_0024TX == (_0023_003DzhFBmu_0024RpnRJ7)8 || flag2))
			{
				_0023_003DzfzE7kdHq_uxBug6V0g_003D_003D(_0023_003DzYzWi5Yw_003D, ref _0023_003DzCiKS5oMdHowF);
				rgbValues = _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.CaptureBackbuffer(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzBn2ByFKdwrou, InstanceId, keepData: false, _0023_003DzVSL16zZBpyqs, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, null, _0023_003DzCiKS5oMdHowF, _0023_003DzCq_00248LrgCN_f9, out stride, out bpp);
				_0023_003DzCiKS5oMdHowF.Location = new System.Drawing.Point(0, 0);
				return _0023_003DzeWR3pemRmHMy(_0023_003DzmNZD0Zs_003D.GetEntityIndicesFromBmp(_0023_003DzCiKS5oMdHowF, firstOnly, rgbValues, bpp, stride), _0023_003DzVSL16zZBpyqs, flag, _0023_003Dz_bIfLEkNPFmB, out _0023_003DzzDNdOMv1nCY_0024);
			}
			double[] modelViewProjectionMatrix = _0023_003DzYzWi5Yw_003D.Camera.GetModelViewProjectionMatrix();
			rgbValues = _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.CaptureBackbuffer(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzBn2ByFKdwrou, InstanceId, keepData: true, _0023_003DzVSL16zZBpyqs, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, modelViewProjectionMatrix, new Rectangle(_0023_003DzYzWi5Yw_003D.Location, _0023_003DzYzWi5Yw_003D.Size), _0023_003DzCq_00248LrgCN_f9, out stride, out bpp, flag2);
		}
		else
		{
			if (flag2)
			{
				rgbValues = _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerSelectionImage;
				_0023_003DzVSL16zZBpyqs = (Dictionary<int, SelectedItem>)_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.InnerIdItemsMap;
			}
			else
			{
				rgbValues = _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.Image;
				_0023_003DzVSL16zZBpyqs = (Dictionary<int, SelectedItem>)_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.IdItemsMap;
			}
			stride = _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.Stride;
			bpp = _0023_003DzYzWi5Yw_003D.Camera.ZBufferData.SelectionImage.Bpp;
		}
		int[] visibleEntitiesFromBackBuffer = GetVisibleEntitiesFromBackBuffer(_0023_003DzYzWi5Yw_003D, rgbValues, stride, bpp, _0023_003DzCiKS5oMdHowF, firstOnly);
		return _0023_003DzeWR3pemRmHMy(visibleEntitiesFromBackBuffer, _0023_003DzVSL16zZBpyqs, flag, _0023_003Dz_bIfLEkNPFmB, out _0023_003DzzDNdOMv1nCY_0024);
	}

	private int[] _0023_003DzeWR3pemRmHMy(int[] _0023_003DzKHBiu_4_003D, Dictionary<int, SelectedItem> _0023_003DzZXcyxzbBFQ6h, bool _0023_003DztF681GRWCEPT, bool _0023_003Dz_bIfLEkNPFmB, out SelectedItem[] _0023_003DzzDNdOMv1nCY_0024)
	{
		int[] array = _0023_003DzKHBiu_4_003D;
		if (_0023_003DzKHBiu_4_003D != null && _0023_003DzKHBiu_4_003D.Length > 1 && _0023_003Dz_bIfLEkNPFmB && _0023_003DztF681GRWCEPT)
		{
			SelectedItem[] array2 = new SelectedItem[_0023_003DzKHBiu_4_003D.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = _0023_003DzZXcyxzbBFQ6h[_0023_003DzKHBiu_4_003D[i]];
			}
			Array.Sort(array2, _0023_003DzKHBiu_4_003D);
			array = new int[1] { _0023_003DzKHBiu_4_003D[0] };
		}
		_0023_003DzzDNdOMv1nCY_0024 = _0023_003DzSD0pBy_k12H8IikBVA_003D_003D(array, _0023_003DzZXcyxzbBFQ6h);
		return array;
	}

	private SelectedItem[] _0023_003DzSD0pBy_k12H8IikBVA_003D_003D(int[] _0023_003DzKHBiu_4_003D, Dictionary<int, SelectedItem> _0023_003DzZXcyxzbBFQ6h)
	{
		if (_0023_003DzZXcyxzbBFQ6h != null)
		{
			SelectedItem[] array = new SelectedItem[_0023_003DzKHBiu_4_003D.Length];
			for (int i = 0; i < _0023_003DzKHBiu_4_003D.Length; i++)
			{
				array[i] = _0023_003DzZXcyxzbBFQ6h[_0023_003DzKHBiu_4_003D[i]];
			}
			return array;
		}
		return Array.Empty<SelectedItem>();
	}

	protected internal virtual int[] GetVisibleEntitiesFromBackBuffer(Viewport viewport, byte[] rgbValues, int stride, int bpp, Rectangle selectionBox, bool firstOnly)
	{
		_0023_003DzfzE7kdHq_uxBug6V0g_003D_003D(viewport, ref selectionBox);
		selectionBox.Location = viewport.ScreenToViewport(selectionBox.Location);
		if (selectionBox.X < 0 || selectionBox.Y < 0 || selectionBox.Width <= 0 || selectionBox.Height <= 0)
		{
			return new int[0];
		}
		return _0023_003DzmNZD0Zs_003D.GetEntityIndicesFromBmp(selectionBox, firstOnly, rgbValues, bpp, stride);
	}

	private void _0023_003DzfzE7kdHq_uxBug6V0g_003D_003D(Viewport _0023_003DzYzWi5Yw_003D, ref Rectangle _0023_003Dzols9v2M_003D)
	{
		if (_0023_003Dzols9v2M_003D.X < 0)
		{
			_0023_003Dzols9v2M_003D.Width = PickBoxSize + _0023_003Dzols9v2M_003D.X;
			_0023_003Dzols9v2M_003D.X = 0;
		}
		else if (_0023_003Dzols9v2M_003D.Right > _0023_003DzYzWi5Yw_003D.Location.X + _0023_003DzYzWi5Yw_003D.Size.Width - 1)
		{
			_0023_003Dzols9v2M_003D.Width = _0023_003DzYzWi5Yw_003D.Location.X + _0023_003DzYzWi5Yw_003D.Size.Width - _0023_003Dzols9v2M_003D.X;
		}
		if (_0023_003Dzols9v2M_003D.Y < 0)
		{
			_0023_003Dzols9v2M_003D.Height = PickBoxSize + _0023_003Dzols9v2M_003D.Y;
			_0023_003Dzols9v2M_003D.Y = 0;
		}
		else if (_0023_003Dzols9v2M_003D.Bottom > _0023_003DzYzWi5Yw_003D.Location.Y + _0023_003DzYzWi5Yw_003D.Size.Height - 1)
		{
			_0023_003Dzols9v2M_003D.Height = _0023_003DzYzWi5Yw_003D.Location.Y + _0023_003DzYzWi5Yw_003D.Size.Height - _0023_003Dzols9v2M_003D.Y;
		}
	}

	public Color GetPixel(int x, int y)
	{
		return _0023_003DzmNZD0Zs_003D.GetPixel(x, y);
	}

	public void CopyTo(Workspace destination, bool replaceRootBlock = true, bool keepTessellation = false)
	{
		_0023_003DzcEouqDajTDte9AV8Ig_003D_003D(destination);
		Document.CopyTo(destination.Document, replaceRootBlock, keepTessellation);
	}

	private protected void _0023_003DzcEouqDajTDte9AV8Ig_003D_003D(Workspace _0023_003DzWqDnK9A_003D)
	{
		if (_0023_003DzWqDnK9A_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			_0023_003DzWqDnK9A_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Add(new Viewport());
		}
		foreach (devDept.Eyeshot.Control.Labels.Label label in _0023_003DzipBYly6zFKAp().Labels)
		{
			_0023_003DzWqDnK9A_003D._0023_003DzipBYly6zFKAp().Labels.Add((devDept.Eyeshot.Control.Labels.Label)label.Clone());
		}
	}

	public void Purge()
	{
		ResetOpenBlocks();
		_0023_003DzgfObf7s_003D.Purge();
	}

	private bool ShouldSerializePrintDocumentName()
	{
		return _0023_003DzbdLgm9c_003D.DocumentName != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595580);
	}

	private void ResetPrintDocumentName()
	{
		_0023_003DzbdLgm9c_003D.DocumentName = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348595580);
	}

	public bool PageSetup(bool allowMargins = false, bool showDialog = true, int? defaultMargins = null, PaperSize paperSize = null, bool? landscape = null)
	{
		if (paperSize != null)
		{
			_0023_003DzbdLgm9c_003D.DefaultPageSettings.PaperSize = paperSize;
		}
		if (showDialog && _0023_003DzbdLgm9c_003D.DefaultPageSettings.PaperSize.Kind == PaperKind.Custom)
		{
			PaperSize paperSize2 = _0023_003DzbdLgm9c_003D.PrinterSettings.PaperSizes.Cast<PaperSize>().FirstOrDefault();
			if (paperSize2 != null)
			{
				_0023_003DzbdLgm9c_003D.DefaultPageSettings.PaperSize = paperSize2;
			}
		}
		if (landscape.HasValue)
		{
			_0023_003DzbdLgm9c_003D.DefaultPageSettings.Landscape = landscape.Value;
		}
		PageSetupDialog pageSetupDialog = new PageSetupDialog();
		pageSetupDialog.Document = _0023_003DzbdLgm9c_003D;
		pageSetupDialog.AllowMargins = allowMargins;
		_0023_003DzbdLgm9c_003D._0023_003DzCB89SQM6tcPg = !allowMargins;
		Margins margins = pageSetupDialog.Document.DefaultPageSettings.Margins;
		if (defaultMargins.HasValue)
		{
			Margins margins2 = pageSetupDialog.Document.DefaultPageSettings.Margins;
			Margins margins3 = pageSetupDialog.Document.DefaultPageSettings.Margins;
			Margins margins4 = pageSetupDialog.Document.DefaultPageSettings.Margins;
			int num = (pageSetupDialog.Document.DefaultPageSettings.Margins.Bottom = defaultMargins.Value);
			int num2 = (margins4.Top = num);
			int left = (margins3.Right = num2);
			margins2.Left = left;
		}
		DialogResult dialogResult;
		if (showDialog)
		{
			dialogResult = pageSetupDialog.ShowDialog();
		}
		else
		{
			pageSetupDialog.Document.DefaultPageSettings.Margins = pageSetupDialog.Document.DefaultPageSettings.Margins;
			dialogResult = DialogResult.OK;
		}
		if (dialogResult != DialogResult.OK)
		{
			pageSetupDialog.Document.DefaultPageSettings.Margins = margins;
		}
		else
		{
			if (RegionInfo.CurrentRegion.IsMetric)
			{
				pageSetupDialog.Document.DefaultPageSettings.Margins = PrinterUnitConvert.Convert(pageSetupDialog.Document.DefaultPageSettings.Margins, PrinterUnit.Display, PrinterUnit.TenthsOfAMillimeter);
			}
			_0023_003DzbdLgm9c_003D = (_0023_003DzKNo6tLg_003D)pageSetupDialog.Document;
		}
		return dialogResult == DialogResult.OK;
	}

	public void SetPrinterSettings(PrinterSettings printerSettings, bool showDialog = true)
	{
		_0023_003DzbdLgm9c_003D.PrinterSettings = printerSettings;
		_0023_003DzbdLgm9c_003D._0023_003DzILx5ao0Ka_gJ = showDialog;
	}

	public void SetPrintController(PrintController printController)
	{
		if (printController != null)
		{
			_0023_003DzbdLgm9c_003D.PrintController = printController;
		}
	}

	internal virtual void _0023_003Dzws3VyglDjXPb(Size _0023_003Dzx2Qdu8dSb6VBSAVPJQ_003D_003D, bool _0023_003Dz8Sjn85TIry34, bool _0023_003DzWrfLNCo_003D)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		HiddenLinesView workUnit = ((!_0023_003Dz8Sjn85TIry34) ? new HiddenLinesViewOnPaper(new HiddenLinesViewSettingsEx(_0023_003DzipBYly6zFKAp(), this, (!_0023_003DzWrfLNCo_003D) ? hiddenLinesViewType.Window : hiddenLinesViewType.Extents)) : new HiddenLinesViewOnPaperPreview(new HiddenLinesViewSettingsEx(_0023_003DzipBYly6zFKAp(), this, (!_0023_003DzWrfLNCo_003D) ? hiddenLinesViewType.Window : hiddenLinesViewType.Extents), _0023_003Dzx2Qdu8dSb6VBSAVPJQ_003D_003D));
		StartWork(workUnit);
	}

	internal static void _0023_003DzM1F7D8THIQLlsp0fgEaZubXzp0ct(PrintPageEventArgs _0023_003Dz1SmHC4c_003D, ref RectangleF _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D)
	{
	}

	internal static Rectangle _0023_003DzdAsCcR79gZ0g(PrintPageEventArgs _0023_003Dz1SmHC4c_003D, bool _0023_003DzAZk2uaY_003D, out int _0023_003Dzi_0024HtOIYX2veyl1JI0Q_003D_003D, out int _0023_003DzFu25JxQ54l6eztld4A_003D_003D)
	{
		if (_0023_003DzAZk2uaY_003D)
		{
			_0023_003Dzi_0024HtOIYX2veyl1JI0Q_003D_003D = 0;
			_0023_003DzFu25JxQ54l6eztld4A_003D_003D = 0;
			return _0023_003Dz1SmHC4c_003D.MarginBounds;
		}
		_0023_003Dz2PUehfiyAVn3 _0023_003Dz2PUehfiyAVn4 = new _0023_003Dz2PUehfiyAVn3(_0023_003Dz1SmHC4c_003D);
		_0023_003Dzi_0024HtOIYX2veyl1JI0Q_003D_003D = _0023_003Dz2PUehfiyAVn4._0023_003DzLfvBTJLlho6b;
		_0023_003DzFu25JxQ54l6eztld4A_003D_003D = _0023_003Dz2PUehfiyAVn4._0023_003Dzr5taPomnX8iY;
		return _0023_003Dz2PUehfiyAVn4._0023_003DzWFw0btc_003D;
	}

	private void _0023_003Dz4ceszKd059Tc6kqzCEw6jjS_0024clkJ(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		_0023_003DzipBYly6zFKAp().Rotate.Enabled = _0023_003DziwPFZD5quyJUARrhpw_003D_003D.Checked;
		Invalidate();
	}

	private void _0023_003Dz4DTzq03biCTSl3js5Wkhjm_0024ICND8(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		Mouse3D.Enabled = _0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D.Checked;
	}

	private void _0023_003DzXaS7SkTsX7tQ7Cxr15liOQSJw9P37ae0Jg_003D_003D(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		float num = (float)Mouse3D.SpeedFactor;
		for (int i = 0; i < _0023_003DzKk1DQUn5co_aN4nO4w_003D_003D.DropDownItems.Count; i++)
		{
			((ToolStripMenuItem)_0023_003DzKk1DQUn5co_aN4nO4w_003D_003D.DropDownItems[i]).Checked = i == (int)num;
		}
	}

	private void _0023_003DziYnUDc8TArNyh_kZhn2qyV_0024sD_0024_n(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		Mouse3D.AutoCenterOfRotation = _0023_003DzM_0024RAWGUwy2M6VoDO8g_003D_003D.Checked;
	}

	private void _0023_003Dzb56omDfq3FEePSqfOkizywdQWBsJ(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		_0023_003DzM_0024RAWGUwy2M6VoDO8g_003D_003D.Checked = Mouse3D.AutoCenterOfRotation;
		centerOfRotationVisibilityType centerOfRotationVisibilityMode = Mouse3D.CenterOfRotationVisibilityMode;
		_0023_003DzR3te2ECclIvgC98aKjRl1l0_003D.Checked = centerOfRotationVisibilityMode == centerOfRotationVisibilityType.Always;
		_0023_003DzFGQmQXKrdjacAiDvFmESkVg_003D.Checked = centerOfRotationVisibilityMode == centerOfRotationVisibilityType.OnMotion;
		_0023_003DzqZgiEmb_0024ukpITsN00Q_003D_003D.Checked = centerOfRotationVisibilityMode == centerOfRotationVisibilityType.Never;
	}

	private void _0023_003DzoL1VwIMP_0024ZbORyayv1lQn3TpSHbX(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		Mouse3D.CenterOfRotationVisibilityMode = centerOfRotationVisibilityType.Always;
		Invalidate();
	}

	private void _0023_003DzUtPyH7lsvp_3huiF6inAKHMSnnWs(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		Mouse3D.CenterOfRotationVisibilityMode = centerOfRotationVisibilityType.OnMotion;
		Invalidate();
	}

	private void _0023_003DzEDbKYv3hKTtMgU_00249sj9MlY3Ib0jg(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		Mouse3D.CenterOfRotationVisibilityMode = centerOfRotationVisibilityType.Never;
		Invalidate();
	}

	private void _0023_003DzqgPEJ1POuqIuBiGNtfIDOe3g56vn(object _0023_003Dz_0024gykH6k_003D, EventArgs _0023_003DzPmVBsAU_003D)
	{
		Mouse3D.LockHorizon = _0023_003DzoyItBUrB_0024Vm2yfULwZ0OnBU_003D.Checked;
	}

	private void _0023_003Dzyvk4rsSdxsYbw_0024bA4Rx_0024da7k_0024LbR(object _0023_003Dz_0024gykH6k_003D, CancelEventArgs _0023_003DzPmVBsAU_003D)
	{
		_0023_003DziwPFZD5quyJUARrhpw_003D_003D.Checked = _0023_003DzipBYly6zFKAp().Rotate.Enabled;
		_0023_003Dz1mYPWbcfyPcUVCtHeA_003D_003D.Checked = Mouse3D.Enabled;
		_0023_003DzoyItBUrB_0024Vm2yfULwZ0OnBU_003D.Checked = Mouse3D.LockHorizon;
	}

	private bool _0023_003DzxskMQCGED12v_IA4_0024A_003D_003D(WeakReference<IWorkspaceInternal> _0023_003Dz8GBMuoM_003D)
	{
		if (_0023_003Dz8GBMuoM_003D.TryGetTarget(out var target))
		{
			return target == this;
		}
		return false;
	}

	private void _0023_003DzPFFaaGJBYbmGfv9zdvfdyIjoPKJl()
	{
		_0023_003Dz11CadYMOXmz_(_0023_003DzipBYly6zFKAp());
	}

	private void _0023_003Dzzr00LSmTUMlMH8anYkB8CjaHk6Cw()
	{
		_0023_003DzR9WOThn15SZhpgA2FA_003D_003D = false;
		_0023_003Dz78oB1KCkXEP9();
	}
}
