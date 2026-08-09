using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

public class ViewBuilderEx : ViewBuilder
{
	private sealed class _0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D
	{
		public Design _0023_003DzFjK2_0024i0_003D;

		public ViewBuilderEx _0023_003DzKdgtcDsi34jL;

		public devDept.Eyeshot.Entities.View _0023_003Dzm1Aquqk_003D;

		public bool _0023_003Dze1lDxgR_0024CFyb;

		public displayType _0023_003DzK_00241ezHQJ9Z3c;

		public Sheet _0023_003DzO7pLOA27s4z4;

		public Picture _0023_003DzQF2zgBU_003D;

		internal void _0023_003DziqlIu9hzGg0URlMhvcGAiCwZWbbX()
		{
			if (_0023_003DzFjK2_0024i0_003D.Entities.Count == 0)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591057));
			}
			Viewport _0023_003DzcFbNb372UVgE = _0023_003DzKdgtcDsi34jL._0023_003DzcFbNb372UVgE;
			bool accurateTransparency = _0023_003DzFjK2_0024i0_003D.AccurateTransparency;
			backfaceColorMethodType colorMethod = _0023_003DzFjK2_0024i0_003D.Backface.ColorMethod;
			edgeColorMethodType edgeColorMethod = _0023_003DzFjK2_0024i0_003D.Rendered.EdgeColorMethod;
			edgeColorMethodType edgeColorMethod2 = _0023_003DzFjK2_0024i0_003D.Shaded.EdgeColorMethod;
			edgeColorMethodType edgeColorMethod3 = _0023_003DzFjK2_0024i0_003D.Flat.EdgeColorMethod;
			edgeColorMethodType edgeColorMethod4 = _0023_003DzFjK2_0024i0_003D.HiddenLines.EdgeColorMethod;
			shadowType shadowMode = _0023_003DzFjK2_0024i0_003D.Rendered.ShadowMode;
			shadowType shadowMode2 = _0023_003DzFjK2_0024i0_003D.Shaded.ShadowMode;
			silhouettesDrawingType silhouettesDrawingMode = _0023_003DzFjK2_0024i0_003D.Rendered.SilhouettesDrawingMode;
			silhouettesDrawingType silhouettesDrawingMode2 = _0023_003DzFjK2_0024i0_003D.Shaded.SilhouettesDrawingMode;
			bool showEdges = _0023_003DzFjK2_0024i0_003D.Rendered.ShowEdges;
			bool showEdges2 = _0023_003DzFjK2_0024i0_003D.Shaded.ShowEdges;
			Camera camera = _0023_003DzcFbNb372UVgE.Camera;
			displayType displayMode = _0023_003DzcFbNb372UVgE.DisplayMode;
			backgroundStyleType styleMode = _0023_003DzcFbNb372UVgE.Background.StyleMode;
			bool autoHideLabels = _0023_003DzcFbNb372UVgE.AutoHideLabels;
			Size size = _0023_003DzcFbNb372UVgE.Size;
			bool? flag = _0023_003DzcFbNb372UVgE.OriginSymbol?.Visible;
			bool? flag2 = _0023_003DzcFbNb372UVgE.ViewCubeIcon?.Visible;
			bool? flag3 = _0023_003DzcFbNb372UVgE.CoordinateSystemIcon?.Visible;
			int num = _0023_003DzcFbNb372UVgE.Grids.Length;
			int num2 = _0023_003DzcFbNb372UVgE.ToolBars.Length;
			int num3 = ((_0023_003DzcFbNb372UVgE.Legends != null) ? _0023_003DzcFbNb372UVgE.Legends.Length : 0);
			bool[] array = new bool[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = _0023_003DzcFbNb372UVgE.Grids[i].Visible;
				_0023_003DzcFbNb372UVgE.Grids[i].Visible = false;
			}
			bool[] array2 = new bool[num2];
			for (int j = 0; j < num2; j++)
			{
				array2[j] = _0023_003DzcFbNb372UVgE.ToolBars[j].Visible;
				_0023_003DzcFbNb372UVgE.ToolBars[j].Visible = false;
			}
			bool[] array3 = new bool[num3];
			for (int k = 0; k < num3; k++)
			{
				array3[k] = _0023_003DzcFbNb372UVgE.Legends[k].Visible;
				_0023_003DzcFbNb372UVgE.Legends[k].Visible = false;
			}
			_0023_003DzFjK2_0024i0_003D.AccurateTransparency = false;
			_0023_003DzFjK2_0024i0_003D.Backface.ColorMethod = backfaceColorMethodType.EntityColor;
			DisplayModeSettingsRendered rendered = _0023_003DzFjK2_0024i0_003D.Rendered;
			DisplayModeSettingsShaded shaded = _0023_003DzFjK2_0024i0_003D.Shaded;
			DisplayModeSettingsFlat flat = _0023_003DzFjK2_0024i0_003D.Flat;
			edgeColorMethodType edgeColorMethodType2 = (_0023_003DzFjK2_0024i0_003D.HiddenLines.EdgeColorMethod = edgeColorMethodType.SingleColor);
			edgeColorMethodType edgeColorMethodType4 = (flat.EdgeColorMethod = edgeColorMethodType2);
			edgeColorMethodType edgeColorMethod5 = (shaded.EdgeColorMethod = edgeColorMethodType4);
			rendered.EdgeColorMethod = edgeColorMethod5;
			DisplayModeSettingsRendered rendered2 = _0023_003DzFjK2_0024i0_003D.Rendered;
			shadowType shadowMode3 = (_0023_003DzFjK2_0024i0_003D.Shaded.ShadowMode = (_0023_003Dzm1Aquqk_003D.Shadow ? shadowType.Realistic : shadowType.None));
			rendered2.ShadowMode = shadowMode3;
			DisplayModeSettingsRendered rendered3 = _0023_003DzFjK2_0024i0_003D.Rendered;
			bool showEdges3 = (_0023_003DzFjK2_0024i0_003D.Shaded.ShowEdges = _0023_003Dze1lDxgR_0024CFyb);
			rendered3.ShowEdges = showEdges3;
			_0023_003DzFjK2_0024i0_003D.Rendered.SilhouettesDrawingMode = (_0023_003Dze1lDxgR_0024CFyb ? silhouettesDrawingType.Always : silhouettesDrawingType.Never);
			_0023_003DzFjK2_0024i0_003D.Shaded.SilhouettesDrawingMode = silhouettesDrawingType.Never;
			_0023_003DzcFbNb372UVgE.DisplayMode = _0023_003DzK_00241ezHQJ9Z3c;
			_0023_003DzcFbNb372UVgE.Background.StyleMode = backgroundStyleType.None;
			_0023_003DzcFbNb372UVgE.AutoHideLabels = false;
			if (_0023_003DzcFbNb372UVgE.OriginSymbol != null)
			{
				_0023_003DzcFbNb372UVgE.OriginSymbol.Visible = false;
			}
			if (_0023_003DzcFbNb372UVgE.ViewCubeIcon != null)
			{
				_0023_003DzcFbNb372UVgE.ViewCubeIcon.Visible = false;
			}
			if (_0023_003DzcFbNb372UVgE.CoordinateSystemIcon != null)
			{
				_0023_003DzcFbNb372UVgE.CoordinateSystemIcon.Visible = false;
			}
			_0023_003DzKdgtcDsi34jL._0023_003Dz_0024aLOJqwkuuQe(_0023_003DzcFbNb372UVgE);
			_0023_003DzcFbNb372UVgE.Camera = _0023_003DzKdgtcDsi34jL._camera;
			Size2D size2D;
			if (_0023_003Dzm1Aquqk_003D.Window.IsEmpty)
			{
				double num4;
				double num5;
				if (_0023_003Dzm1Aquqk_003D.Width > _0023_003Dzm1Aquqk_003D.Height)
				{
					num4 = _0023_003Dzm1Aquqk_003D.Width / 1.15;
					num5 = _0023_003Dzm1Aquqk_003D.Height - 0.15 * num4;
				}
				else
				{
					num5 = _0023_003Dzm1Aquqk_003D.Height / 1.15;
					num4 = _0023_003Dzm1Aquqk_003D.Width - 0.15 * num5;
				}
				size2D = new Size2D(num4, num5);
			}
			else
			{
				size2D = new Size2D(_0023_003Dzm1Aquqk_003D.Width, _0023_003Dzm1Aquqk_003D.Height);
			}
			double num6 = size2D.Y / size2D.X;
			double num7 = Utility.GetLinearUnitsConversionFactor(_0023_003DzO7pLOA27s4z4.Units, linearUnitsType.Inches) * (double)_0023_003Dzm1Aquqk_003D.Dpi;
			Size size2 = new Size((int)Math.Round(size2D.X * num7), (int)Math.Round(size2D.Y * num7));
			if (size2.Width > 16384 || size2.Height > 16384)
			{
				if (size2.Width > size2.Height)
				{
					size2.Width = 16384;
					size2.Height = (int)((double)size2.Width * num6);
				}
				else
				{
					size2.Height = 16384;
					size2.Width = (int)((double)size2.Width / num6);
				}
			}
			_0023_003DzFjK2_0024i0_003D._0023_003DztdGp9MI3CH2w = false;
			if (_0023_003Dzm1Aquqk_003D.Window.IsEmpty)
			{
				_0023_003DzcFbNb372UVgE.Size = size2;
				_0023_003DzcFbNb372UVgE.ZoomFit(0);
			}
			else
			{
				_0023_003DzcFbNb372UVgE.Size = new Size((int)_0023_003Dzm1Aquqk_003D.Window.Width, (int)_0023_003Dzm1Aquqk_003D.Window.Height);
				_0023_003DzcFbNb372UVgE.Camera.ZoomFactor = _0023_003Dzm1Aquqk_003D.Camera.ZoomFactor;
				_0023_003DzcFbNb372UVgE.Camera.Target = _0023_003Dzm1Aquqk_003D.WindowCenter;
			}
			Size2D size2D2 = new Size2D(size2D.X / _0023_003Dzm1Aquqk_003D.Scale, size2D.Y / _0023_003Dzm1Aquqk_003D.Scale);
			try
			{
				List<Tuple<Stack<BlockReference>, Entity, bool>> _0023_003DzE3RrqbeXPubT = _0023_003DzKdgtcDsi34jL._0023_003DzvUKqYMkRpGcefbyFnA_003D_003D(_0023_003Dzm1Aquqk_003D.EntitiesToHide.Distinct().ToList());
				Bitmap image = _0023_003DzcFbNb372UVgE.RenderToBitmap(size2, (float)_0023_003Dzm1Aquqk_003D.Scale, drawBackground: false, hdwAcceleration: true, drawUiElements: false);
				_0023_003DzQF2zgBU_003D = new Picture(Plane.XY, size2D2.X, size2D2.Y, image.ToByteArray());
				_0023_003DzKdgtcDsi34jL._0023_003DzLzSSen1NH_OqAqDQDg_003D_003D(_0023_003DzE3RrqbeXPubT);
				if (_0023_003Dzm1Aquqk_003D.EntitiesToHide.Count > 0)
				{
					_0023_003DzKdgtcDsi34jL._designDoc.isBoundingBoxDirty = true;
				}
			}
			catch (Exception)
			{
				int num8 = 512;
				int num9;
				int num10;
				if (size2D.X > size2D.Y)
				{
					num9 = num8;
					num10 = (int)((double)num9 * num6);
				}
				else
				{
					num10 = num8;
					num9 = (int)((double)num10 / num6);
				}
				Bitmap image = new Bitmap(num9, num10);
				System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(image);
				HatchBrush brush = new HatchBrush(HatchStyle.Cross, Color.DarkRed, Color.Empty);
				graphics.FillRectangle(brush, 0, 0, num9, num10);
				graphics.Flush();
				_0023_003DzQF2zgBU_003D = new Picture(Plane.XY, size2D2.X, size2D2.Y, image.ToByteArray());
			}
			finally
			{
				_0023_003DzKdgtcDsi34jL._0023_003Dzfqr_0024QVgXuT6A(_0023_003DzcFbNb372UVgE);
			}
			_0023_003DzQF2zgBU_003D.ColorMethod = colorMethodType.byEntity;
			_0023_003DzQF2zgBU_003D.Color = Color.FromArgb(254, Color.White);
			_0023_003DzQF2zgBU_003D.DrawEdge = false;
			_0023_003DzQF2zgBU_003D.Translate((0.0 - _0023_003DzQF2zgBU_003D.Width) / 2.0, (0.0 - _0023_003DzQF2zgBU_003D.Height) / 2.0);
			_0023_003DzQF2zgBU_003D.Selectable = false;
			_0023_003DzFjK2_0024i0_003D.AccurateTransparency = accurateTransparency;
			_0023_003DzFjK2_0024i0_003D.Backface.ColorMethod = colorMethod;
			_0023_003DzFjK2_0024i0_003D.Rendered.EdgeColorMethod = edgeColorMethod;
			_0023_003DzFjK2_0024i0_003D.Shaded.EdgeColorMethod = edgeColorMethod2;
			_0023_003DzFjK2_0024i0_003D.Flat.EdgeColorMethod = edgeColorMethod3;
			_0023_003DzFjK2_0024i0_003D.HiddenLines.EdgeColorMethod = edgeColorMethod4;
			_0023_003DzFjK2_0024i0_003D.Rendered.ShadowMode = shadowMode;
			_0023_003DzFjK2_0024i0_003D.Shaded.ShadowMode = shadowMode2;
			_0023_003DzFjK2_0024i0_003D.Rendered.SilhouettesDrawingMode = silhouettesDrawingMode;
			_0023_003DzFjK2_0024i0_003D.Shaded.SilhouettesDrawingMode = silhouettesDrawingMode2;
			_0023_003DzFjK2_0024i0_003D.Rendered.ShowEdges = showEdges;
			_0023_003DzFjK2_0024i0_003D.Shaded.ShowEdges = showEdges2;
			_0023_003DzcFbNb372UVgE.Camera = camera;
			_0023_003DzcFbNb372UVgE.DisplayMode = displayMode;
			_0023_003DzcFbNb372UVgE.Background.StyleMode = styleMode;
			_0023_003DzcFbNb372UVgE.AutoHideLabels = autoHideLabels;
			_0023_003DzcFbNb372UVgE.Size = size;
			for (int l = 0; l < num; l++)
			{
				_0023_003DzcFbNb372UVgE.Grids[l].Visible = array[l];
			}
			for (int m = 0; m < num2; m++)
			{
				_0023_003DzcFbNb372UVgE.ToolBars[m].Visible = array2[m];
			}
			for (int n = 0; n < num3; n++)
			{
				_0023_003DzcFbNb372UVgE.Legends[n].Visible = array3[n];
			}
			if (_0023_003DzcFbNb372UVgE.OriginSymbol != null)
			{
				_0023_003DzcFbNb372UVgE.OriginSymbol.Visible = flag.Value;
			}
			if (_0023_003DzcFbNb372UVgE.ViewCubeIcon != null)
			{
				_0023_003DzcFbNb372UVgE.ViewCubeIcon.Visible = flag2.Value;
			}
			if (_0023_003DzcFbNb372UVgE.CoordinateSystemIcon != null)
			{
				_0023_003DzcFbNb372UVgE.CoordinateSystemIcon.Visible = flag3.Value;
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Viewport _0023_003DzcFbNb372UVgE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private viewportLayoutType _0023_003DzQXvf4pv6bhMJ;

	public ViewBuilderEx(Design design, Drawing drawing, bool changedOnly = false)
		: base(design.Document, drawing.Document, changedOnly)
	{
		_0023_003DzUMSSRSw_003D(design, drawing);
	}

	public ViewBuilderEx(Design design, Drawing drawing, devDept.Eyeshot.Entities.View view, Sheet sheet)
		: base(design.Document, drawing.Document, view, sheet)
	{
		_0023_003DzUMSSRSw_003D(design, drawing);
	}

	internal ViewBuilderEx(Design _0023_003DzFjK2_0024i0_003D, Drawing _0023_003DzfdgxWgs_003D, Dictionary<Sheet, IList<devDept.Eyeshot.Entities.View>> _0023_003Dz4Y3bwEpSpQfWlhDHew_003D_003D)
		: base(_0023_003DzFjK2_0024i0_003D.Document, _0023_003DzfdgxWgs_003D.Document, _0023_003Dz4Y3bwEpSpQfWlhDHew_003D_003D)
	{
		_0023_003DzUMSSRSw_003D(_0023_003DzFjK2_0024i0_003D, _0023_003DzfdgxWgs_003D);
	}

	private void _0023_003DzUMSSRSw_003D(Design _0023_003DzFjK2_0024i0_003D, Drawing _0023_003DzfdgxWgs_003D)
	{
		_0023_003DzcFbNb372UVgE = (Viewport)_0023_003DzFjK2_0024i0_003D.ActiveViewport.Clone();
		_0023_003DzcFbNb372UVgE._0023_003DzzgjrOMU_003D(_0023_003DzFjK2_0024i0_003D);
		base.BuildingViewText = _0023_003DzfdgxWgs_003D.ViewBuilderText;
		base.BuildingViewSuffix = _0023_003DzfdgxWgs_003D.ViewBuilderSuffix;
	}

	private void _0023_003Dz_0024aLOJqwkuuQe(Viewport _0023_003DzYzWi5Yw_003D)
	{
		Design design = _designDoc.workspace as Design;
		_0023_003DzQXvf4pv6bhMJ = design.LayoutMode;
		design.LayoutMode = viewportLayoutType.Stacked;
		design.Viewports.Add(_0023_003DzYzWi5Yw_003D);
	}

	private void _0023_003Dzfqr_0024QVgXuT6A(Viewport _0023_003DzYzWi5Yw_003D)
	{
		Design obj = _designDoc.workspace as Design;
		obj.Viewports.Remove(_0023_003DzYzWi5Yw_003D);
		obj.LayoutMode = _0023_003DzQXvf4pv6bhMJ;
	}

	private protected override void ApplyOrientationModeRotation(Camera _0023_003DzZ_0024IejP0R_0024_Cw)
	{
		if (((Design)_designDoc.workspace).OrientationMode == orientationType.UpAxisY)
		{
			_0023_003DzZ_0024IejP0R_0024_Cw.Rotation = new Quaternion(Vector3D.AxisX, 90.0) * _0023_003DzZ_0024IejP0R_0024_Cw.Rotation;
		}
	}

	private protected override Block DoWorkVector(VectorView _0023_003Dz8xtYzeA_003D, Sheet _0023_003DzO7pLOA27s4z4, IProgress<ProgressChangedEventArgs> _0023_003DzIIIDz8c_003D, CancellationToken _0023_003DzkIE5Tx8_003D)
	{
		Block block = base.DoWorkVector(_0023_003Dz8xtYzeA_003D, _0023_003DzO7pLOA27s4z4, _0023_003DzIIIDz8c_003D, _0023_003DzkIE5Tx8_003D);
		if (_0023_003Dz8xtYzeA_003D.Shaded && block != null && !Cancelled(_0023_003DzkIE5Tx8_003D))
		{
			Picture item = _0023_003DzKoAWM6SAKl3K_XOk1w_003D_003D(_0023_003Dz8xtYzeA_003D, _0023_003DzO7pLOA27s4z4, displayType.Rendered, _0023_003Dze1lDxgR_0024CFyb: false);
			block.Entities.Add(item);
		}
		return block;
	}

	private protected override Block DoWorkRaster(RasterView _0023_003Dzm1Aquqk_003D, Sheet _0023_003DzO7pLOA27s4z4)
	{
		Block block = new Block(_0023_003Dzm1Aquqk_003D.BlockName);
		InitializeCameraAndUpdateView(_0023_003Dzm1Aquqk_003D, _0023_003DzO7pLOA27s4z4);
		Picture item = _0023_003DzKoAWM6SAKl3K_XOk1w_003D_003D(_0023_003Dzm1Aquqk_003D, _0023_003DzO7pLOA27s4z4, _0023_003Dzm1Aquqk_003D.DisplayMode, _0023_003Dze1lDxgR_0024CFyb: true);
		block.Entities.Add(item);
		return block;
	}

	private Picture _0023_003DzKoAWM6SAKl3K_XOk1w_003D_003D(devDept.Eyeshot.Entities.View _0023_003Dzm1Aquqk_003D, Sheet _0023_003DzO7pLOA27s4z4, displayType _0023_003DzK_00241ezHQJ9Z3c, bool _0023_003Dze1lDxgR_0024CFyb)
	{
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D _0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2 = new _0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D();
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DzKdgtcDsi34jL = this;
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003Dzm1Aquqk_003D = _0023_003Dzm1Aquqk_003D;
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003Dze1lDxgR_0024CFyb = _0023_003Dze1lDxgR_0024CFyb;
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DzK_00241ezHQJ9Z3c = _0023_003DzK_00241ezHQJ9Z3c;
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DzO7pLOA27s4z4 = _0023_003DzO7pLOA27s4z4;
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DzQF2zgBU_003D = null;
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DzFjK2_0024i0_003D = _designDoc.workspace as Design;
		_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DzFjK2_0024i0_003D.Invoke(new MethodInvoker(_0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DziqlIu9hzGg0URlMhvcGAiCwZWbbX));
		return _0023_003Dz8V9lrJX6QT6MsZnc9YziUBU_003D2._0023_003DzQF2zgBU_003D;
	}

	private List<Tuple<Stack<BlockReference>, Entity, bool>> _0023_003DzvUKqYMkRpGcefbyFnA_003D_003D(List<Tuple<Stack<BlockReference>, Entity>> _0023_003DztsmBbDl27NVe)
	{
		List<Tuple<Stack<BlockReference>, Entity, bool>> list = new List<Tuple<Stack<BlockReference>, Entity, bool>>();
		for (int i = 0; i < _0023_003DztsmBbDl27NVe.Count; i++)
		{
			Tuple<Stack<BlockReference>, Entity> tuple = _0023_003DztsmBbDl27NVe[i];
			list.Add(new Tuple<Stack<BlockReference>, Entity, bool>(tuple.Item1, tuple.Item2, tuple.Item2.GetVisibility(tuple.Item1)));
			tuple.Item2.SetVisibility(status: false, tuple.Item1);
		}
		return list;
	}

	private void _0023_003DzLzSSen1NH_OqAqDQDg_003D_003D(List<Tuple<Stack<BlockReference>, Entity, bool>> _0023_003DzE3RrqbeXPubT)
	{
		for (int i = 0; i < _0023_003DzE3RrqbeXPubT.Count; i++)
		{
			Tuple<Stack<BlockReference>, Entity, bool> tuple = _0023_003DzE3RrqbeXPubT[i];
			tuple.Item2.SetVisibility(tuple.Item3, tuple.Item1);
		}
	}

	public override void Dispose()
	{
		_0023_003DzcFbNb372UVgE?.Dispose();
		base.Dispose();
	}

	public void AddTo(Drawing drawing)
	{
		AddTo(drawing.Document);
	}
}
