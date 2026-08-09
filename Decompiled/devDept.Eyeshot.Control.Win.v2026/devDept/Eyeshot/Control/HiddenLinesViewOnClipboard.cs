using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace devDept.Eyeshot.Control;

public class HiddenLinesViewOnClipboard : HiddenLinesView
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Workspace _0023_003DzA5OxWwM_003D;

	public string FilePath;

	public float Scale;

	public HiddenLinesViewOnClipboard(HiddenLinesViewSettingsEx viewSettings)
		: this(viewSettings, 1.0)
	{
	}

	public HiddenLinesViewOnClipboard(HiddenLinesViewSettingsEx viewSettings, double scale)
		: this(viewSettings, null, scale)
	{
	}

	protected HiddenLinesViewOnClipboard(HiddenLinesViewSettingsEx viewSettings, string filePath, double scale)
		: base(viewSettings, forceTextsAsTriangles: true)
	{
		Scale = (float)scale;
		FilePath = filePath;
	}

	public override void WorkCompleted(object sender)
	{
		Workspace workspace = (Workspace)HdlViewSettings.document.workspace;
		SaveFile(workspace, FilePath);
	}

	protected internal void SaveFile(Workspace workspace, string filePath)
	{
		float num = Scale;
		HiddenLinesViewSettingsEx hiddenLinesViewSettingsEx = (HiddenLinesViewSettingsEx)HdlViewSettings;
		if (hiddenLinesViewSettingsEx.hdlViewMode == hiddenLinesViewType.Extents)
		{
			float num2 = (float)(hiddenLinesViewSettingsEx.boxMax.X - hiddenLinesViewSettingsEx.boxMin.X);
			float num3 = (float)(hiddenLinesViewSettingsEx.boxMax.Y - hiddenLinesViewSettingsEx.boxMin.Y);
			num *= (float)hiddenLinesViewSettingsEx.ViewportSize.Height / num3;
			if (num * num2 > (float)hiddenLinesViewSettingsEx.ViewportSize.Width)
			{
				num = (float)hiddenLinesViewSettingsEx.ViewportSize.Width / num2;
			}
		}
		float num4 = (float)(1.0 / (double)num);
		float width = hiddenLinesViewSettingsEx.PenSilhouette.Width;
		float width2 = hiddenLinesViewSettingsEx.PenEdge.Width;
		float width3 = hiddenLinesViewSettingsEx.PenWire.Width;
		hiddenLinesViewSettingsEx.PenSilhouette.Width *= num4;
		hiddenLinesViewSettingsEx.PenEdge.Width *= num4;
		hiddenLinesViewSettingsEx.PenWire.Width *= num4;
		hiddenLinesViewSettingsEx.PenSilhouette.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
		hiddenLinesViewSettingsEx.PenEdge.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
		hiddenLinesViewSettingsEx.PenWire.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);
		Metafile metafile = _0023_003DzE3pvLB8dByEEOGdqpw_003D_003D(filePath, workspace, num, num4);
		hiddenLinesViewSettingsEx.PenSilhouette.Width = width;
		hiddenLinesViewSettingsEx.PenEdge.Width = width2;
		hiddenLinesViewSettingsEx.PenWire.Width = width3;
		if (metafile != null)
		{
			_0023_003Dzx6HzsKM5jJwBHivt6uyLQh7_hGNbkML2r9jG1Qi7196P._0023_003Dzpsu_R_rE40EtpTmxvcjNosUfJq7E(IntPtr.Zero, metafile);
		}
	}

	private Metafile _0023_003DzE3pvLB8dByEEOGdqpw_003D_003D(string _0023_003DzYQvHPFc_003D, Workspace _0023_003DzA5OxWwM_003D, double _0023_003DzW_Mwciw_003D, float _0023_003Dz5keHpXqrJjAd)
	{
		float width = HdlViewSettings.ViewBounds[2];
		float num = HdlViewSettings.ViewBounds[3];
		GetComputedLines(out var silho, out var edges, out var wires, out var hiddenSilho, out var hiddenEdges, out var hiddenWires, out var pictures, out var texts, out var sections);
		System.Windows.Forms.Control control = new System.Windows.Forms.Control();
		Metafile metafile;
		try
		{
			System.Drawing.Graphics graphics = control.CreateGraphics();
			IntPtr hdc = graphics.GetHdc();
			if (string.IsNullOrEmpty(_0023_003DzYQvHPFc_003D))
			{
				metafile = new Metafile(hdc, EmfType.EmfOnly);
			}
			else
			{
				string extension = Path.GetExtension(_0023_003DzYQvHPFc_003D);
				string fileName = ((!string.IsNullOrEmpty(extension) && !(extension.ToLower() != _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589502))) ? _0023_003DzYQvHPFc_003D : (_0023_003DzYQvHPFc_003D + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589502)));
				metafile = new Metafile(fileName, hdc, EmfType.EmfOnly);
			}
			using (System.Drawing.Graphics graphics2 = System.Drawing.Graphics.FromImage(metafile))
			{
				graphics2.PageUnit = GraphicsUnit.Pixel;
				if (((HiddenLinesViewSettingsEx)HdlViewSettings).hdlViewMode != hiddenLinesViewType.Extents)
				{
					graphics2.FillRectangle(Brushes.Transparent, 0f, 0f, width, num);
					graphics2.TranslateTransform(0f, num);
				}
				graphics2.ScaleTransform((float)_0023_003DzW_Mwciw_003D, (float)(0.0 - _0023_003DzW_Mwciw_003D));
				_0023_003DzBwMLvUBcMOtVBl9zqK4W9NbHleezt3Qs5LF1H5w_003D._0023_003Dz40b83AC2XYDJKEY7aG3nP94_003D((HiddenLinesViewSettingsEx)HdlViewSettings, graphics2, _0023_003Dz5keHpXqrJjAd, silho, edges, wires, hiddenSilho, hiddenEdges, hiddenWires, texts, pictures, printOrderValues, wireAndTriangleDatas, sections, _0023_003DzW_Mwciw_003D);
				graphics.ReleaseHdc();
			}
			graphics.Dispose();
			if (!string.IsNullOrEmpty(_0023_003DzYQvHPFc_003D))
			{
				metafile.Dispose();
				metafile = null;
			}
		}
		finally
		{
			((IDisposable)control).Dispose();
		}
		return metafile;
	}
}
