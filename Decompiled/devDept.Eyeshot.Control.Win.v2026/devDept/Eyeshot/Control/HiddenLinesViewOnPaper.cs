using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using devDept.Geometry;

namespace devDept.Eyeshot.Control;

public class HiddenLinesViewOnPaper : HiddenLinesView
{
	public RectangleF PrintRect;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private linearUnitsType _0023_003DzAB3VFkk_003D = linearUnitsType.Millimeters;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private lineWeightPrintingUnitsType _0023_003Dz61cZjyYD9LLs = lineWeightPrintingUnitsType.Pixels;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzjcrWZbv_nvgteJYa2tk_0024WrHDIO5huVLxGg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzvaGMWMZcs5qtfhPMnWAD3Ao_003D;

	public double OrthographicScale
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzjcrWZbv_nvgteJYa2tk_0024WrHDIO5huVLxGg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzjcrWZbv_nvgteJYa2tk_0024WrHDIO5huVLxGg_003D_003D = value;
		}
	}

	public linearUnitsType Units
	{
		get
		{
			return _0023_003DzAB3VFkk_003D;
		}
		set
		{
			_0023_003DzAB3VFkk_003D = value;
		}
	}

	public lineWeightPrintingUnitsType LineWeightUnits
	{
		get
		{
			return _0023_003Dz61cZjyYD9LLs;
		}
		set
		{
			_0023_003Dz61cZjyYD9LLs = value;
		}
	}

	public Point2D ScaleViewToPageUnits
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvaGMWMZcs5qtfhPMnWAD3Ao_003D;
		}
	}

	public HiddenLinesViewOnPaper(HiddenLinesViewSettingsEx viewSettings)
		: this(viewSettings, 0.0)
	{
	}

	public HiddenLinesViewOnPaper(HiddenLinesViewSettingsEx viewSettings, double orthographicScale)
		: this(viewSettings, orthographicScale, default(RectangleF))
	{
	}

	public HiddenLinesViewOnPaper(HiddenLinesViewSettingsEx viewSettings, double orthographicScale, RectangleF printRect)
		: base(viewSettings)
	{
		PrintRect = printRect;
		OrthographicScale = orthographicScale;
	}

	private bool _0023_003Dzab1Uwx4bGHZY()
	{
		return OrthographicScale == 0.0;
	}

	public override void WorkCompleted(object sender)
	{
		Workspace workspace = (Workspace)HdlViewSettings.document.workspace;
		DialogResult dialogResult = DialogResult.OK;
		if (workspace._0023_003DzbdLgm9c_003D._0023_003DzILx5ao0Ka_gJ && !workspace._0023_003DzbdLgm9c_003D._0023_003DzVWilOEkLyDxl)
		{
			PrintDialog printDialog = new PrintDialog();
			printDialog.UseEXDialog = true;
			printDialog.Document = workspace._0023_003DzbdLgm9c_003D;
			dialogResult = printDialog.ShowDialog();
			workspace._0023_003DzbdLgm9c_003D = (Workspace._0023_003DzKNo6tLg_003D)printDialog.Document;
		}
		if (dialogResult != DialogResult.OK)
		{
			return;
		}
		workspace._0023_003DzbdLgm9c_003D._0023_003DzrDcpsS8_003D.Add(new Workspace._0023_003DzEmdG9Ls_003D(this, workspace));
		try
		{
			if (workspace._0023_003DzbdLgm9c_003D._0023_003DzA3ipzoQ5sbsK)
			{
				workspace._0023_003DzbdLgm9c_003D._0023_003Dzuw7Bx3c_003D = 0;
				workspace._0023_003DzbdLgm9c_003D.Print();
				workspace._0023_003DzbdLgm9c_003D.hKxLbCvKjVpI4dvqv3tjvDsUbXA();
			}
		}
		catch (Exception ex)
		{
			workspace._0023_003DzbdLgm9c_003D.hKxLbCvKjVpI4dvqv3tjvDsUbXA();
			MessageBox.Show(ex.Message);
		}
	}

	private void _0023_003DzwK_xqX9_ZEu728bUYw_003D_003D(float _0023_003DzgBjMJHM6tIXY, ref double _0023_003DzEEi3__oLnUi2, ref double _0023_003DzeCOmMNhZlLTb, out double _0023_003DzdXvRxtM_003D, out double _0023_003DzmLeBsy4_003D)
	{
		float num = (float)OrthographicScale;
		bool flag = _0023_003Dzab1Uwx4bGHZY();
		HiddenLinesViewSettingsEx hiddenLinesViewSettingsEx = (HiddenLinesViewSettingsEx)HdlViewSettings;
		if (hiddenLinesViewSettingsEx.Camera.ProjectionMode == projectionType.Perspective)
		{
			flag = true;
			num = 1f;
		}
		else if (num == 0f)
		{
			num = 1f;
		}
		if (flag)
		{
			if (hiddenLinesViewSettingsEx.hdlViewMode == hiddenLinesViewType.Extents)
			{
				_0023_003DzEEi3__oLnUi2 = hiddenLinesViewSettingsEx.boxMax.X - hiddenLinesViewSettingsEx.boxMin.X;
				_0023_003DzeCOmMNhZlLTb = hiddenLinesViewSettingsEx.boxMax.Y - hiddenLinesViewSettingsEx.boxMin.Y;
			}
			float num2 = PrintRect.Height / PrintRect.Width;
			float num3 = PrintRect.Width * _0023_003DzgBjMJHM6tIXY;
			float num4 = PrintRect.Height * _0023_003DzgBjMJHM6tIXY;
			num = ((!(num2 < 1f)) ? (num3 / (float)_0023_003DzEEi3__oLnUi2) : (num4 / (float)_0023_003DzeCOmMNhZlLTb));
			float num5 = (float)_0023_003DzEEi3__oLnUi2 * num;
			if (num5 > num3)
			{
				num *= num3 / num5;
			}
			float num6 = (float)_0023_003DzeCOmMNhZlLTb * num;
			if (num6 > num4)
			{
				num *= num4 / num6;
			}
		}
		else
		{
			num *= (float)hiddenLinesViewSettingsEx.ViewToWorldConversion();
		}
		_0023_003DzdXvRxtM_003D = num;
		_0023_003DzmLeBsy4_003D = 0f - num;
	}

	internal double _0023_003Dzx6z93YwpYtYdAIUaC_0024d6n9SmIDFs(float _0023_003DzGZUvFA_xlJOn, double _0023_003DzEEi3__oLnUi2, Point3D _0023_003DzpV4_U8o4JR26, Point3D _0023_003DzkokL1qtcIMpB)
	{
		return (double)_0023_003DzGZUvFA_xlJOn / HdlViewSettings.ViewToWorldConversion();
	}

	public void Print(PrintPageEventArgs e)
	{
		if (PrintRect.IsEmpty)
		{
			int _0023_003Dzi_0024HtOIYX2veyl1JI0Q_003D_003D;
			int _0023_003DzFu25JxQ54l6eztld4A_003D_003D;
			RectangleF _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D = Workspace._0023_003DzdAsCcR79gZ0g(e, _0023_003DzAZk2uaY_003D: false, out _0023_003Dzi_0024HtOIYX2veyl1JI0Q_003D_003D, out _0023_003DzFu25JxQ54l6eztld4A_003D_003D);
			if (RegionInfo.CurrentRegion.IsMetric)
			{
				Workspace._0023_003DzM1F7D8THIQLlsp0fgEaZubXzp0ct(e, ref _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D);
			}
			_0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.X = 0f;
			_0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.Y = 0f;
			PrintRect = new RectangleF(_0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.X, _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.Y, _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.Width, _0023_003Dzv_NLDZN41jNYRgEWuA_003D_003D.Height);
		}
		GetComputedLines(out var silho, out var edges, out var wires, out var hiddenSilho, out var hiddenEdges, out var hiddenWires, out var pictures, out var texts, out var sections);
		if ((edges == null || edges.Length == 0) && (wires == null || wires.Length == 0) && (silho == null || silho.Length == 0) && (wireAndTriangleDatas == null || wireAndTriangleDatas.Count == 0) && (texts == null || texts.Length == 0) && (pictures == null || pictures.Length == 0) && (sections == null || sections.Length == 0))
		{
			return;
		}
		HiddenLinesViewSettingsEx hiddenLinesViewSettingsEx = (HiddenLinesViewSettingsEx)HdlViewSettings;
		List<SilhoWireAndTriangleData> list = wireAndTriangleDatas;
		if (list != null && list.Count > 0 && (hiddenLinesViewSettingsEx.boxMin == null || hiddenLinesViewSettingsEx.boxMax == null))
		{
			SilhoWireAndTriangleData silhoWireAndTriangleData = wireAndTriangleDatas[0];
			Point2D point2D = new Point2D(silhoWireAndTriangleData.Vertices[0, 0], silhoWireAndTriangleData.Vertices[0, 1]);
			Point2D point2D2 = new Point2D(silhoWireAndTriangleData.Vertices[0, 0], silhoWireAndTriangleData.Vertices[0, 1]);
			for (int i = 0; i < wireAndTriangleDatas.Count; i++)
			{
				for (int j = 0; j < silhoWireAndTriangleData.Vertices.GetLength(0); j++)
				{
					float num = silhoWireAndTriangleData.Vertices[j, 0];
					double num2 = silhoWireAndTriangleData.ScreenVertices[j, 1];
					point2D2.X = (((double)num > point2D2.X) ? ((double)num) : point2D2.X);
					point2D2.Y = ((num2 > point2D2.Y) ? num2 : point2D2.Y);
					point2D.X = (((double)num < point2D.X) ? ((double)num) : point2D.X);
					point2D.Y = ((num2 < point2D.Y) ? num2 : point2D.Y);
				}
			}
			if (hiddenLinesViewSettingsEx.boxMin == null)
			{
				hiddenLinesViewSettingsEx.boxMin = point2D;
			}
			if (hiddenLinesViewSettingsEx.boxMax == null)
			{
				hiddenLinesViewSettingsEx.boxMax = point2D2;
			}
		}
		System.Drawing.Drawing2D.Matrix transform = e.Graphics.Transform;
		float num3 = (float)UtilityEx._0023_003DzSg7URJz1jbSCe_0024oh0g_003D_003D(e.Graphics.PageUnit, Units);
		Pen pen = (Pen)hiddenLinesViewSettingsEx.PenSilhouette.Clone();
		Pen pen2 = (Pen)hiddenLinesViewSettingsEx.PenEdge.Clone();
		Pen pen3 = (Pen)hiddenLinesViewSettingsEx.PenWire.Clone();
		if (hiddenLinesViewSettingsEx.boxMin == null || hiddenLinesViewSettingsEx.boxMax == null)
		{
			return;
		}
		double num4;
		double _0023_003DzEEi3__oLnUi = (num4 = hiddenLinesViewSettingsEx.Window.Width);
		double num5;
		double _0023_003DzeCOmMNhZlLTb = (num5 = hiddenLinesViewSettingsEx.Window.Height);
		if (hiddenLinesViewSettingsEx.Camera.ProjectionMode == projectionType.Perspective && hiddenLinesViewSettingsEx.hdlViewMode == hiddenLinesViewType.Extents)
		{
			hiddenLinesViewSettingsEx.boxMin = Point2D.MaxValue;
			hiddenLinesViewSettingsEx.boxMax = Point2D.MinValue;
			HiddenLinesViewSettingsEx._0023_003DzcIZzbYOESlSdTJrFpmbrUdQ_003D(edges, hiddenLinesViewSettingsEx.boxMin, hiddenLinesViewSettingsEx.boxMax);
			HiddenLinesViewSettingsEx._0023_003DzpNoVPZF61FfPSoKgBQ_003D_003D(wires, pictures, texts, hiddenLinesViewSettingsEx.boxMin, hiddenLinesViewSettingsEx.boxMax);
			HiddenLinesViewSettingsEx._0023_003DzcIZzbYOESlSdTJrFpmbrUdQ_003D(silho, hiddenLinesViewSettingsEx.boxMin, hiddenLinesViewSettingsEx.boxMax);
			_0023_003DzEEi3__oLnUi = (num4 = hiddenLinesViewSettingsEx.boxMax.X - hiddenLinesViewSettingsEx.boxMin.X);
			_0023_003DzeCOmMNhZlLTb = (num5 = hiddenLinesViewSettingsEx.boxMax.Y - hiddenLinesViewSettingsEx.boxMin.Y);
		}
		_0023_003DzwK_xqX9_ZEu728bUYw_003D_003D(num3, ref _0023_003DzEEi3__oLnUi, ref _0023_003DzeCOmMNhZlLTb, out var _0023_003DzdXvRxtM_003D, out var _0023_003DzmLeBsy4_003D);
		float num6 = (float)_0023_003DzdXvRxtM_003D / num3;
		if (hiddenLinesViewSettingsEx.Camera.ProjectionMode != projectionType.Perspective || hiddenLinesViewSettingsEx.hdlViewMode != hiddenLinesViewType.Extents)
		{
			num4 = (double)(PrintRect.Width * num3) / _0023_003DzdXvRxtM_003D;
			num5 = (double)((0f - PrintRect.Height) * num3) / _0023_003DzmLeBsy4_003D;
			Point2D point2D3 = ((hiddenLinesViewSettingsEx.hdlViewMode != hiddenLinesViewType.Extents) ? new Point2D((double)hiddenLinesViewSettingsEx.Window.Left + _0023_003DzEEi3__oLnUi / 2.0, (double)hiddenLinesViewSettingsEx.Window.Top + _0023_003DzeCOmMNhZlLTb / 2.0) : Point2D.MidPoint(hiddenLinesViewSettingsEx.boxMin, hiddenLinesViewSettingsEx.boxMax));
			hiddenLinesViewSettingsEx.boxMin = new Point2D(point2D3.X - num4 / 2.0, point2D3.Y - num5 / 2.0);
			hiddenLinesViewSettingsEx.boxMax = new Point2D(point2D3.X + num4 / 2.0, point2D3.Y + num5 / 2.0);
		}
		_0023_003DzuuZzef0x1km9_0024Hz_CQ_003D_003D(new Point2D(num6, (float)_0023_003DzmLeBsy4_003D / num3));
		if (_0023_003DzdXvRxtM_003D != 0.0 && _0023_003DzmLeBsy4_003D != 0.0)
		{
			float num7 = 0f;
			float num8 = 1f;
			lineWeightPrintingUnitsType lineWeightUnits = LineWeightUnits;
			if ((uint)lineWeightUnits <= 1u)
			{
				float num9 = (float)UtilityEx._0023_003DzSg7URJz1jbSCe_0024oh0g_003D_003D(e.Graphics.PageUnit, (_0023_003Dz61cZjyYD9LLs != lineWeightPrintingUnitsType.Millimeters) ? linearUnitsType.Inches : linearUnitsType.Millimeters);
				num8 = (float)(1.0 / (double)num9);
				num7 = (float)(1.0 / (double)(num9 * num6));
			}
			else
			{
				num7 = (float)((double)num3 / _0023_003DzdXvRxtM_003D);
			}
			float num10 = Math.Max(Math.Max(pen2.Width, pen.Width), pen3.Width) * num8;
			pen.Width *= num7;
			pen2.Width *= num7;
			pen3.Width *= num7;
			Rectangle clip = new Rectangle((int)Math.Ceiling(PrintRect.Left - num10), (int)Math.Ceiling(PrintRect.Top - num10), (int)Math.Ceiling(PrintRect.Width + 2f * num10), (int)Math.Ceiling(PrintRect.Height + 2f * num10));
			e.Graphics.SetClip(clip);
			e.Graphics.ResetTransform();
			double num11 = (double)(PrintRect.Width * num3) / _0023_003DzdXvRxtM_003D;
			double num12 = (double)(PrintRect.Height * num3) / _0023_003DzmLeBsy4_003D;
			e.Graphics.TranslateTransform((float)(0.0 - hiddenLinesViewSettingsEx.boxMin.X), (float)(0.0 - hiddenLinesViewSettingsEx.boxMin.Y), MatrixOrder.Append);
			e.Graphics.TranslateTransform((float)(num11 - num4) / 2f, (float)(0.0 - (num12 + num5) / 2.0), MatrixOrder.Append);
			e.Graphics.ScaleTransform((float)ScaleViewToPageUnits.X, (float)ScaleViewToPageUnits.Y, MatrixOrder.Append);
			e.Graphics.TranslateTransform(PrintRect.X, PrintRect.Bottom, MatrixOrder.Append);
			System.Drawing.Drawing2D.Matrix transform2 = e.Graphics.Transform;
			e.Graphics.Transform = transform;
			e.Graphics.MultiplyTransform(transform2);
			Pen pen4 = null;
			Pen pen5 = null;
			if (hiddenLinesViewSettingsEx.KeepHiddenSegments)
			{
				Pen obj = (Pen)hiddenLinesViewSettingsEx.PenHiddenSilhouette.Clone();
				pen4 = (Pen)hiddenLinesViewSettingsEx.PenHiddenEdge.Clone();
				pen5 = (Pen)hiddenLinesViewSettingsEx.PenHiddenWire.Clone();
				obj.Width *= num7;
				pen4.Width *= num7;
				pen5.Width *= num7;
			}
			_0023_003DzBwMLvUBcMOtVBl9zqK4W9NbHleezt3Qs5LF1H5w_003D._0023_003Dz40b83AC2XYDJKEY7aG3nP94_003D((HiddenLinesViewSettingsEx)HdlViewSettings, e.Graphics, num7, silho, edges, wires, hiddenSilho, hiddenEdges, hiddenWires, texts, pictures, printOrderValues, wireAndTriangleDatas, sections, ScaleViewToPageUnits.X);
			e.Graphics.Transform = transform;
			e.Graphics.ResetClip();
		}
	}

	internal void _0023_003DzuuZzef0x1km9_0024Hz_CQ_003D_003D(Point2D _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzvaGMWMZcs5qtfhPMnWAD3Ao_003D = _0023_003DzsLHxXyo_003D;
	}
}
