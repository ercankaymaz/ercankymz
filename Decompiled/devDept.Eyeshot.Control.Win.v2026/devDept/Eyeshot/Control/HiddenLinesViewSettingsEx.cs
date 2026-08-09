using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Control;

public class HiddenLinesViewSettingsEx : HiddenLinesViewSettings
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private displayType _0023_003DzaKy28msa34o0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private hiddenLinesColorMethodType _0023_003DzVmVAQyel0PPj = hiddenLinesColorMethodType.EntityColor;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzWaSwbKKQQ5hK = Color.Black;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzvOuD_ODzHYSEU6sVWGORkP_7zC2IKJpK_0024w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzYw97lcbmYSoU14pvtt64LkE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzUdJaG6Cf2CisUllx0zNQgV0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzXnIjbPexfa_VGADQaUb7dAj6Zi_0024MIJZqSg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003Dzq0wjK5ALrPoSSqJcTK_tzAY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzGSHuaqK6hdrGeluZGPGk1gA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SolidBrush _0023_003DzgPqhRECA3_Ldr7qLJg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SolidBrush _0023_003Dza5S706vXzNFFhISVFAWQ5Ws_003D;

	public Pen PenSilhouette
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvOuD_ODzHYSEU6sVWGORkP_7zC2IKJpK_0024w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzvOuD_ODzHYSEU6sVWGORkP_7zC2IKJpK_0024w_003D_003D = value;
		}
	}

	public Pen PenEdge
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYw97lcbmYSoU14pvtt64LkE_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYw97lcbmYSoU14pvtt64LkE_003D = value;
		}
	}

	public Pen PenWire
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzUdJaG6Cf2CisUllx0zNQgV0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzUdJaG6Cf2CisUllx0zNQgV0_003D = value;
		}
	}

	public Pen PenHiddenSilhouette
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXnIjbPexfa_VGADQaUb7dAj6Zi_0024MIJZqSg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXnIjbPexfa_VGADQaUb7dAj6Zi_0024MIJZqSg_003D_003D = value;
		}
	}

	public Pen PenHiddenEdge
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzq0wjK5ALrPoSSqJcTK_tzAY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzq0wjK5ALrPoSSqJcTK_tzAY_003D = value;
		}
	}

	public Pen PenHiddenWire
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzGSHuaqK6hdrGeluZGPGk1gA_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzGSHuaqK6hdrGeluZGPGk1gA_003D = value;
		}
	}

	public SolidBrush BrushTriangle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzgPqhRECA3_Ldr7qLJg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzgPqhRECA3_Ldr7qLJg_003D_003D = value;
		}
	}

	public HiddenLinesViewSettingsEx(HiddenLinesViewSettingsEx another)
		: base(another)
	{
		_0023_003DzaKy28msa34o0 = another._0023_003DzaKy28msa34o0;
		_0023_003DzVmVAQyel0PPj = another._0023_003DzVmVAQyel0PPj;
		_0023_003DzWaSwbKKQQ5hK = another._0023_003DzWaSwbKKQQ5hK;
		PenSilhouette = (Pen)another.PenSilhouette.Clone();
		PenEdge = (Pen)another.PenEdge.Clone();
		PenWire = (Pen)another.PenWire.Clone();
		PenHiddenSilhouette = (Pen)another.PenHiddenSilhouette.Clone();
		PenHiddenEdge = (Pen)another.PenHiddenEdge.Clone();
		PenHiddenWire = (Pen)another.PenHiddenWire.Clone();
		BrushTriangle = (SolidBrush)another.BrushTriangle.Clone();
	}

	public HiddenLinesViewSettingsEx(Workspace workspace, hiddenLinesViewType viewMode)
		: base(workspace._0023_003DzipBYly6zFKAp().Camera, workspace.Document, viewMode, workspace._0023_003DzipBYly6zFKAp().Size)
	{
		_0023_003DzUMSSRSw_003D(workspace._0023_003DzipBYly6zFKAp(), workspace);
	}

	public HiddenLinesViewSettingsEx(Viewport viewport, Workspace workspace, hiddenLinesViewType viewMode, RectangleF? window = null)
		: base(viewport.Camera, workspace.Document, viewMode, viewport.Size, window)
	{
		_0023_003DzUMSSRSw_003D(viewport, workspace);
	}

	public HiddenLinesViewSettingsEx(Camera camera, Document document, hiddenLinesViewType viewMode, Size? viewportSize = null, RectangleF? window = null)
		: base(camera, document, viewMode, viewportSize, window)
	{
		_0023_003DzHg1kPq8buvmQ();
	}

	public HiddenLinesViewSettingsEx(viewType view, Document document, Size? viewportSize = null)
		: base(view, document, viewportSize)
	{
		_0023_003DzHg1kPq8buvmQ();
	}

	public HiddenLinesViewSettingsEx(Plane sectionPlane, Document document, Size? viewportSize = null)
		: base(sectionPlane, document, viewportSize)
	{
		_0023_003DzHg1kPq8buvmQ();
	}

	private SolidBrush _0023_003Dz6ByZofM6hEbU()
	{
		return _0023_003Dza5S706vXzNFFhISVFAWQ5Ws_003D;
	}

	private void _0023_003DzUWVCefa9sCNj(SolidBrush _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dza5S706vXzNFFhISVFAWQ5Ws_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzUMSSRSw_003D(Viewport _0023_003DzYzWi5Yw_003D, Workspace _0023_003DzU0f5_qE_003D)
	{
		_0023_003DzaKy28msa34o0 = _0023_003DzYzWi5Yw_003D.DisplayMode;
		_0023_003DzVmVAQyel0PPj = _0023_003DzU0f5_qE_003D._0023_003DzP6FAuV4Dwq24.ColorMethod;
		_0023_003DzWaSwbKKQQ5hK = _0023_003DzU0f5_qE_003D._0023_003DzP6FAuV4Dwq24.WireColor;
		_0023_003DzHg1kPq8buvmQ();
	}

	private void _0023_003DzHg1kPq8buvmQ()
	{
		PenSilhouette = new Pen(Color.Black, 3f);
		PenEdge = new Pen(Color.Black, 1f);
		PenWire = new Pen(Color.Black, 1f);
		PenHiddenSilhouette = new Pen(Color.LightGray, 3f);
		PenHiddenEdge = new Pen(Color.LightGray, 1f);
		PenHiddenWire = new Pen(Color.LightGray, 1f);
		BrushTriangle = new SolidBrush(Color.Black);
		_0023_003DzUWVCefa9sCNj(new SolidBrush(Color.Black));
	}

	internal static void _0023_003DzcIZzbYOESlSdTJrFpmbrUdQ_003D<T>(IList<T> _0023_003Dzm_gdWbg_003D, Point2D _0023_003DzpV4_U8o4JR26, Point2D _0023_003DzkokL1qtcIMpB) where T : HiddenLinesView.HdlCurve
	{
		HiddenLinesViewSettings.UpdateExtents2DForHdlCurves(_0023_003Dzm_gdWbg_003D, _0023_003DzpV4_U8o4JR26, _0023_003DzkokL1qtcIMpB);
	}

	internal static void _0023_003DzpNoVPZF61FfPSoKgBQ_003D_003D<T, Q, V>(IList<T> _0023_003Dzm_gdWbg_003D, IList<Q> _0023_003DzLW0ikdj1oemqiCtJHA_003D_003D, IList<V> _0023_003DzbCE1Un9G1jBX, Point2D _0023_003DzpV4_U8o4JR26, Point2D _0023_003DzkokL1qtcIMpB) where T : HiddenLinesView.HdlCurve where Q : HiddenLinesView.HdlPicture where V : HiddenLinesView.HdlText
	{
		HiddenLinesViewSettings.UpdateExtents2DForHdlEntities(_0023_003Dzm_gdWbg_003D, _0023_003DzLW0ikdj1oemqiCtJHA_003D_003D, _0023_003DzbCE1Un9G1jBX, _0023_003DzpV4_U8o4JR26, _0023_003DzkokL1qtcIMpB);
	}

	internal void _0023_003DzyiaK2qTugB_F(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, IList<HiddenLinesView.HdlPicture> _0023_003DzLW0ikdj1oemqiCtJHA_003D_003D)
	{
		InterpolationMode interpolationMode = _0023_003DzVC9FBdo_003D.InterpolationMode;
		_0023_003DzVC9FBdo_003D.InterpolationMode = InterpolationMode.HighQualityBicubic;
		foreach (HiddenLinesView.HdlPicture item in _0023_003DzLW0ikdj1oemqiCtJHA_003D_003D)
		{
			_0023_003Dz4hRg0Rmm8JsG(item, _0023_003DzVC9FBdo_003D, null, 1.0);
		}
		_0023_003DzVC9FBdo_003D.InterpolationMode = interpolationMode;
	}

	internal void _0023_003DzFEchN98QAX8NauMzyw_003D_003D(System.Drawing.Graphics _0023_003DzrV6eaSI_003D, Pen _0023_003DzysN3hjI_003D, IList<HiddenLinesView.HdlCurve> _0023_003Dzm_gdWbg_003D, float _0023_003Dz5keHpXqrJjAd)
	{
		_0023_003Dzm_gdWbg_003D = _0023_003Dzm_gdWbg_003D.Reverse().ToArray();
		if (base.KeepEntityColor)
		{
			if (base.KeepEntityLineWeight)
			{
				_0023_003DzBzb_YP_0024kVChCyHAKQ_0024IDkGU_003D(_0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, _0023_003Dz5keHpXqrJjAd, _0023_003Dzm_gdWbg_003D);
			}
			else
			{
				_0023_003DzHIWb8HQSfSGjdJwobA_003D_003D(_0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, _0023_003Dzm_gdWbg_003D);
			}
		}
		else if (base.KeepEntityLineWeight)
		{
			_0023_003Dz10tF_P9eOM401ZKJOF_Ki38_003D(_0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, _0023_003Dz5keHpXqrJjAd, _0023_003Dzm_gdWbg_003D);
		}
		else
		{
			_0023_003DzokDzEEnLGz6Mw_L89w_003D_003D(_0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, _0023_003Dzm_gdWbg_003D);
		}
	}

	private void _0023_003DzokDzEEnLGz6Mw_L89w_003D_003D(System.Drawing.Graphics _0023_003DzrV6eaSI_003D, Pen _0023_003DzysN3hjI_003D, IList<HiddenLinesView.HdlCurve> _0023_003DzacFINwJAMRZX)
	{
		foreach (HiddenLinesView.HdlCurve item in _0023_003DzacFINwJAMRZX)
		{
			_0023_003Dz4hRg0Rmm8JsG(item, _0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, 1.0);
		}
	}

	internal void _0023_003DzvH_4W62doY_C(System.Drawing.Graphics _0023_003DzrV6eaSI_003D, Pen _0023_003DzysN3hjI_003D, IList<HiddenLinesView.HdlText> _0023_003DzbCE1Un9G1jBX)
	{
		if (_0023_003DzbCE1Un9G1jBX.Count <= 0)
		{
			return;
		}
		int _0023_003DzLIZTOJw_003D = _0023_003DzysN3hjI_003D.Color.ToArgb();
		foreach (HiddenLinesView.HdlText item in _0023_003DzbCE1Un9G1jBX)
		{
			if (base.KeepEntityColor)
			{
				_0023_003Dzne1xAqk_003D(_0023_003DzysN3hjI_003D, item.Attributes, ref _0023_003DzLIZTOJw_003D);
			}
			_0023_003Dz4hRg0Rmm8JsG(item, _0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, 1.0);
		}
	}

	internal void _0023_003Dz8ic3vZey7H_00246(System.Drawing.Graphics _0023_003DzrV6eaSI_003D, Pen _0023_003DzysN3hjI_003D, float _0023_003Dz5keHpXqrJjAd, IList<HiddenLinesView.HdlSection> _0023_003DzBLT6VCI_003D, double _0023_003Dz6VaqBeg2493U)
	{
		if (_0023_003DzBLT6VCI_003D.Count <= 0)
		{
			return;
		}
		float _0023_003DzSX_0024zcC1QfT = _0023_003DzysN3hjI_003D.Width / _0023_003Dz5keHpXqrJjAd;
		int _0023_003DzLIZTOJw_003D = _0023_003DzysN3hjI_003D.Color.ToArgb();
		foreach (HiddenLinesView.HdlSection item in _0023_003DzBLT6VCI_003D)
		{
			if (base.KeepEntityLineWeight)
			{
				_0023_003Dz_0024GdVus0EY_a2(_0023_003DzysN3hjI_003D, _0023_003Dz5keHpXqrJjAd, item.Attributes, ref _0023_003DzSX_0024zcC1QfT);
			}
			if (base.KeepEntityColor)
			{
				_0023_003Dzne1xAqk_003D(_0023_003DzysN3hjI_003D, item.Attributes, ref _0023_003DzLIZTOJw_003D);
			}
			_0023_003Dz4hRg0Rmm8JsG(item, _0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, 1.0);
		}
	}

	internal void _0023_003DzDUm62tZpEMC9sC3vHkKbYyU_003D(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, IList<SilhoWireAndTriangleData> _0023_003Dzt5jpbHs_003D)
	{
		SolidBrush solidBrush = new SolidBrush(Color.Black);
		int _0023_003DzLIZTOJw_003D = solidBrush.Color.ToArgb();
		Pen pen = new Pen(Color.Black);
		pen.LineJoin = LineJoin.Bevel;
		for (int i = 0; i < _0023_003Dzt5jpbHs_003D.Count; i++)
		{
			double[,] screenVertices = _0023_003Dzt5jpbHs_003D[i].ScreenVertices;
			_0023_003Dzne1xAqk_003D(solidBrush, _0023_003Dzt5jpbHs_003D[i].Attributes, ref _0023_003DzLIZTOJw_003D);
			pen.Color = solidBrush.Color;
			int num = 0;
			while (num < screenVertices.GetLength(0))
			{
				_0023_003DzVC9FBdo_003D.FillPolygon(solidBrush, new PointF[3]
				{
					new PointF((float)screenVertices[num, 0], (float)screenVertices[num++, 1]),
					new PointF((float)screenVertices[num, 0], (float)screenVertices[num++, 1]),
					new PointF((float)screenVertices[num, 0], (float)screenVertices[num++, 1])
				}, FillMode.Winding);
			}
		}
	}

	internal void _0023_003DzUNsJlaF_0024l2jS1FWZLQ_003D_003D(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, IList<SilhoWireAndTriangleData> _0023_003Dzt5jpbHs_003D)
	{
		SolidBrush solidBrush = (SolidBrush)BrushTriangle.Clone();
		solidBrush.Color = BrushTriangle.Color;
		new Pen(solidBrush.Color).LineJoin = LineJoin.Bevel;
		for (int i = 0; i < _0023_003Dzt5jpbHs_003D.Count; i++)
		{
			double[,] screenVertices = _0023_003Dzt5jpbHs_003D[i].ScreenVertices;
			int num = 0;
			while (num < screenVertices.GetLength(0))
			{
				_0023_003DzVC9FBdo_003D.FillPolygon(solidBrush, new PointF[3]
				{
					new PointF((float)screenVertices[num, 0], (float)screenVertices[num++, 1]),
					new PointF((float)screenVertices[num, 0], (float)screenVertices[num++, 1]),
					new PointF((float)screenVertices[num, 0], (float)screenVertices[num++, 1])
				}, FillMode.Alternate);
			}
		}
	}

	private static void _0023_003Dz_0024GdVus0EY_a2(Pen _0023_003DzysN3hjI_003D, float _0023_003Dz5keHpXqrJjAd, GfxAttributesWire _0023_003Dz8z7C7Cw_003D, ref float _0023_003DzSX_0024zcC1QfT04)
	{
		if (_0023_003Dz8z7C7Cw_003D.LineWeight != _0023_003DzSX_0024zcC1QfT04)
		{
			_0023_003DzSX_0024zcC1QfT04 = _0023_003Dz8z7C7Cw_003D.LineWeight;
			_0023_003DzysN3hjI_003D.Width = _0023_003DzSX_0024zcC1QfT04 * _0023_003Dz5keHpXqrJjAd;
		}
	}

	private static void _0023_003Dzne1xAqk_003D(Pen _0023_003DzysN3hjI_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D, ref int _0023_003DzLIZTOJw_003D)
	{
		Color color = Color.FromArgb(255, _0023_003Dz8z7C7Cw_003D.GetColor());
		if (color.ToArgb() != _0023_003DzLIZTOJw_003D)
		{
			_0023_003DzysN3hjI_003D.Color = color;
			_0023_003DzLIZTOJw_003D = color.ToArgb();
		}
	}

	private static void _0023_003Dzne1xAqk_003D(SolidBrush _0023_003Dz5PxKZP0_003D, GfxAttributesWire _0023_003Dz8z7C7Cw_003D, ref int _0023_003DzLIZTOJw_003D)
	{
		Color color = _0023_003Dz8z7C7Cw_003D.GetColor();
		if (color.ToArgb() != _0023_003DzLIZTOJw_003D)
		{
			_0023_003Dz5PxKZP0_003D.Color = color;
			_0023_003DzLIZTOJw_003D = color.ToArgb();
		}
	}

	private void _0023_003DzBzb_YP_0024kVChCyHAKQ_0024IDkGU_003D(System.Drawing.Graphics _0023_003DzrV6eaSI_003D, Pen _0023_003DzysN3hjI_003D, float _0023_003Dz5keHpXqrJjAd, IList<HiddenLinesView.HdlCurve> _0023_003DzacFINwJAMRZX)
	{
		float _0023_003DzSX_0024zcC1QfT = _0023_003DzysN3hjI_003D.Width / _0023_003Dz5keHpXqrJjAd;
		int _0023_003DzLIZTOJw_003D = _0023_003DzysN3hjI_003D.Color.ToArgb();
		foreach (HiddenLinesView.HdlCurve item in _0023_003DzacFINwJAMRZX)
		{
			_0023_003Dz_0024GdVus0EY_a2(_0023_003DzysN3hjI_003D, _0023_003Dz5keHpXqrJjAd, item.Attributes, ref _0023_003DzSX_0024zcC1QfT);
			_0023_003Dzne1xAqk_003D(_0023_003DzysN3hjI_003D, item.Attributes, ref _0023_003DzLIZTOJw_003D);
			_0023_003Dz4hRg0Rmm8JsG(item, _0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, 1.0);
		}
	}

	private void _0023_003Dz10tF_P9eOM401ZKJOF_Ki38_003D(System.Drawing.Graphics _0023_003DzrV6eaSI_003D, Pen _0023_003DzysN3hjI_003D, float _0023_003Dz5keHpXqrJjAd, IList<HiddenLinesView.HdlCurve> _0023_003DzacFINwJAMRZX)
	{
		float _0023_003DzSX_0024zcC1QfT = _0023_003DzysN3hjI_003D.Width / _0023_003Dz5keHpXqrJjAd;
		foreach (HiddenLinesView.HdlCurve item in _0023_003DzacFINwJAMRZX)
		{
			_0023_003Dz_0024GdVus0EY_a2(_0023_003DzysN3hjI_003D, _0023_003Dz5keHpXqrJjAd, item.Attributes, ref _0023_003DzSX_0024zcC1QfT);
			_0023_003Dz4hRg0Rmm8JsG(item, _0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, 1.0);
		}
	}

	private void _0023_003DzHIWb8HQSfSGjdJwobA_003D_003D(System.Drawing.Graphics _0023_003DzrV6eaSI_003D, Pen _0023_003DzysN3hjI_003D, IList<HiddenLinesView.HdlCurve> _0023_003DzacFINwJAMRZX)
	{
		int _0023_003DzLIZTOJw_003D = _0023_003DzysN3hjI_003D.Color.ToArgb();
		foreach (HiddenLinesView.HdlCurve item in _0023_003DzacFINwJAMRZX)
		{
			_0023_003Dzne1xAqk_003D(_0023_003DzysN3hjI_003D, item.Attributes, ref _0023_003DzLIZTOJw_003D);
			_0023_003Dz4hRg0Rmm8JsG(item, _0023_003DzrV6eaSI_003D, _0023_003DzysN3hjI_003D, 1.0);
		}
	}

	private void _0023_003Dz4hRg0Rmm8JsG(HiddenLinesView.HdlResult _0023_003Dz3rdr2zZa8uwc, System.Drawing.Graphics _0023_003DzVC9FBdo_003D, Pen _0023_003DzysN3hjI_003D, double _0023_003Dz6VaqBeg2493U)
	{
		if (!(_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlEllipticalArc hdlEllipticalArc))
		{
			if (!(_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlArc hdlArc))
			{
				if (!(_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlPoint hdlPoint))
				{
					if (!(_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlLinearPath hdlLinearPath))
					{
						if (_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlMesh)
						{
							throw new NotImplementedException();
						}
						if (!(_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlPicture hdlPicture))
						{
							if (!(_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlText { Text: var text } hdlText))
							{
								if (!(_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlSpline hdlSpline))
								{
									if (!(_0023_003Dz3rdr2zZa8uwc is HiddenLinesView.HdlSection hdlSection))
									{
										throw new ArgumentOutOfRangeException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589491));
									}
									DesignDocument designDocument = new DesignDocument();
									designDocument.HatchPatterns.AddDefaultPattern();
									hdlSection.Hatch.PatternScale = (float)(new Size2D(boxMin, boxMax).Diagonal * _0023_003Dz6VaqBeg2493U * 0.1);
									hdlSection.Hatch.Regen(new RegenParams(Utility.ComputeTolerance(new Size2D(boxMin, boxMax).Diagonal), designDocument));
									Entity[] array = hdlSection.Hatch.Explode();
									foreach (Entity entity in array)
									{
										if (entity is Line line)
										{
											_0023_003DzVC9FBdo_003D.DrawLine(_0023_003DzysN3hjI_003D, (float)line.StartPoint.X, (float)line.StartPoint.Y, (float)line.EndPoint.X, (float)line.EndPoint.Y);
											continue;
										}
										devDept.Eyeshot.Entities.Point point = (devDept.Eyeshot.Entities.Point)entity;
										_0023_003Dz6ByZofM6hEbU().Color = _0023_003DzysN3hjI_003D.Color;
										float num = ((_0023_003DzysN3hjI_003D.Width > 2f) ? _0023_003DzysN3hjI_003D.Width : 2f);
										_0023_003DzVC9FBdo_003D.FillEllipse(_0023_003Dz6ByZofM6hEbU(), (float)point.Position.X - num / 2f, (float)point.Position.Y - num / 2f, num, num);
									}
								}
								else
								{
									Curve curve = new Curve(hdlSpline.Degree, hdlSpline.KnotVector, hdlSpline.ControlPoints, checkKnotsAndCtrlPts: false);
									curve.Regen(Utility.ComputeTolerance(new Size2D(boxMin, boxMax).Diagonal));
									for (int j = 0; j < curve.Vertices.Length - 1; j++)
									{
										_0023_003DzVC9FBdo_003D.DrawLine(_0023_003DzysN3hjI_003D, (float)curve.Vertices[j].X, (float)curve.Vertices[j].Y, (float)curve.Vertices[j + 1].X, (float)curve.Vertices[j + 1].Y);
									}
								}
							}
							else if (!string.IsNullOrEmpty(text.Trim()))
							{
								string fontFamilyName = hdlText.FontFamilyName;
								fontStyle style = hdlText.FontStyle;
								RectangleF rectangleText = hdlText.RectangleText;
								float height = rectangleText.Height;
								Font font = new Font(fontFamilyName, height, (FontStyle)style);
								_0023_003DziQF5uLKSLtYVTB7W9iVolgQ_003D(_0023_003DzVC9FBdo_003D, hdlText.GetAngle(), text, hdlText.IsFlipped, font, _0023_003DzysN3hjI_003D.Brush, rectangleText);
								font.Dispose();
							}
						}
						else
						{
							GraphicsState gstate = _0023_003DzVC9FBdo_003D.Save();
							System.Drawing.Drawing2D.Matrix transform = _0023_003DzVC9FBdo_003D.Transform;
							_0023_003DzVC9FBdo_003D.ResetTransform();
							_0023_003DzVC9FBdo_003D.RotateTransform(hdlPicture.GetAngle(), MatrixOrder.Append);
							_0023_003DzVC9FBdo_003D.TranslateTransform(hdlPicture.Rectangle.X, hdlPicture.Rectangle.Y, MatrixOrder.Append);
							_0023_003DzVC9FBdo_003D.MultiplyTransform(transform, MatrixOrder.Append);
							using (Bitmap bitmap = UtilityEx.ConvertBytesToImage(hdlPicture.Image))
							{
								bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
								_0023_003DzVC9FBdo_003D.DrawImage(bitmap, 0f, 0f - hdlPicture.Rectangle.Height, hdlPicture.Rectangle.Width, hdlPicture.Rectangle.Height);
							}
							_0023_003DzVC9FBdo_003D.Restore(gstate);
						}
					}
					else
					{
						for (int k = 0; k < hdlLinearPath.Vertices.Length - 1; k++)
						{
							_0023_003DzVC9FBdo_003D.DrawLine(_0023_003DzysN3hjI_003D, (float)hdlLinearPath.Vertices[k].X, (float)hdlLinearPath.Vertices[k].Y, (float)hdlLinearPath.Vertices[k + 1].X, (float)hdlLinearPath.Vertices[k + 1].Y);
						}
					}
				}
				else
				{
					_0023_003Dz6ByZofM6hEbU().Color = _0023_003DzysN3hjI_003D.Color;
					float num2 = ((_0023_003DzysN3hjI_003D.Width > 2f) ? _0023_003DzysN3hjI_003D.Width : 2f);
					_0023_003DzVC9FBdo_003D.FillEllipse(_0023_003Dz6ByZofM6hEbU(), (float)hdlPoint.Vertex.X - num2 / 2f, (float)hdlPoint.Vertex.Y - num2 / 2f, num2, num2);
				}
			}
			else
			{
				_0023_003DzVC9FBdo_003D.DrawArc(_0023_003DzysN3hjI_003D, (float)(hdlArc.Center.X - hdlArc.Radius), (float)(hdlArc.Center.Y - hdlArc.Radius), 2f * (float)hdlArc.Radius, 2f * (float)hdlArc.Radius, (float)Utility.RadToDeg(hdlArc.Angle.Low), (float)Utility.RadToDeg(hdlArc.Angle.Length));
			}
		}
		else
		{
			GraphicsState gstate2 = _0023_003DzVC9FBdo_003D.Save();
			System.Drawing.Drawing2D.Matrix transform2 = _0023_003DzVC9FBdo_003D.Transform;
			_0023_003DzVC9FBdo_003D.ResetTransform();
			float num3 = (float)hdlEllipticalArc.Plane.Origin.X;
			float num4 = (float)hdlEllipticalArc.Plane.Origin.Y;
			_0023_003DzVC9FBdo_003D.TranslateTransform(0f - num3, 0f - num4, MatrixOrder.Append);
			_0023_003DzVC9FBdo_003D.RotateTransform((float)Utility.RadToDeg(Vector2D.SignedAngleBetween(Vector2D.AxisX, hdlEllipticalArc.Plane.AxisX)), MatrixOrder.Append);
			_0023_003DzVC9FBdo_003D.TranslateTransform(num3, num4, MatrixOrder.Append);
			_0023_003DzVC9FBdo_003D.MultiplyTransform(transform2, MatrixOrder.Append);
			EllipticalArc.GetIntervalOfAngles(hdlEllipticalArc.RadiusX, hdlEllipticalArc.RadiusY, hdlEllipticalArc.Angle.t0, hdlEllipticalArc.Angle.t1, out var startAngleInRadians, out var endAngleInRadians);
			_0023_003DzVC9FBdo_003D.DrawArc(_0023_003DzysN3hjI_003D, (float)((double)num3 - hdlEllipticalArc.RadiusX), (float)((double)num4 - hdlEllipticalArc.RadiusY), 2f * (float)hdlEllipticalArc.RadiusX, 2f * (float)hdlEllipticalArc.RadiusY, (float)Utility.RadToDeg(startAngleInRadians), (float)Utility.RadToDeg(endAngleInRadians - startAngleInRadians));
			_0023_003DzVC9FBdo_003D.Restore(gstate2);
		}
	}

	private void _0023_003DziQF5uLKSLtYVTB7W9iVolgQ_003D(System.Drawing.Graphics _0023_003DzVC9FBdo_003D, float _0023_003DzuiltSgU_003D, string _0023_003DzqF54oSk_003D, bool _0023_003DzVyTtLHkgZxcayTLI0g_003D_003D, Font _0023_003Dz6FupbG0_003D, Brush _0023_003Dz_xlLNbo_003D, RectangleF _0023_003Dzkm01BMQ_003D)
	{
		SizeF sizeF = _0023_003DzVC9FBdo_003D.MeasureString(_0023_003DzqF54oSk_003D, _0023_003Dz6FupbG0_003D, new PointF(0f, 0f), StringFormat.GenericTypographic);
		float num = 1f;
		GraphicsState gstate = _0023_003DzVC9FBdo_003D.Save();
		System.Drawing.Drawing2D.Matrix transform = _0023_003DzVC9FBdo_003D.Transform;
		_0023_003DzVC9FBdo_003D.ResetTransform();
		if (_0023_003DzVyTtLHkgZxcayTLI0g_003D_003D)
		{
			_0023_003DzVC9FBdo_003D.ScaleTransform(0f - num, 1f, MatrixOrder.Append);
		}
		else
		{
			_0023_003DzVC9FBdo_003D.ScaleTransform(num, -1f, MatrixOrder.Append);
		}
		_0023_003DzVC9FBdo_003D.RotateTransform(_0023_003DzuiltSgU_003D, MatrixOrder.Append);
		_0023_003DzVC9FBdo_003D.TranslateTransform(_0023_003Dzkm01BMQ_003D.X, _0023_003Dzkm01BMQ_003D.Y, MatrixOrder.Append);
		_0023_003DzVC9FBdo_003D.MultiplyTransform(transform, MatrixOrder.Append);
		_0023_003DzVC9FBdo_003D.DrawString(_0023_003DzqF54oSk_003D, _0023_003Dz6FupbG0_003D, _0023_003Dz_xlLNbo_003D, _0023_003DzVyTtLHkgZxcayTLI0g_003D_003D ? (0f - _0023_003Dzkm01BMQ_003D.Width) : 0f, (_0023_003Dzkm01BMQ_003D.Height - sizeF.Height) / 2f, StringFormat.GenericTypographic);
		_0023_003DzVC9FBdo_003D.Restore(gstate);
	}

	protected internal override float PenWidth(lineType lineType)
	{
		return lineType switch
		{
			lineType.Silho => PenSilhouette.Width, 
			lineType.Edge => PenEdge.Width, 
			lineType.Wire => PenWire.Width, 
			_ => 0f, 
		};
	}

	protected internal override GfxAttributesWire GetGfxAttributes()
	{
		return _0023_003DzaKy28msa34o0 switch
		{
			displayType.Rendered => new GfxAttributesWireMaterialOrColor(Layers), 
			displayType.HiddenLines => _0023_003DzVmVAQyel0PPj switch
			{
				hiddenLinesColorMethodType.EntityColor => new GfxAttributesHDL(Color.White, _0023_003DzWaSwbKKQQ5hK, Layers), 
				hiddenLinesColorMethodType.EntityMaterial => new GfxAttributesWireMaterialOrColor(Layers), 
				_ => new GfxAttributesHDLSingleColor(Color.White, _0023_003DzWaSwbKKQQ5hK, Layers), 
			}, 
			_ => base.GetGfxAttributes(), 
		};
	}
}
