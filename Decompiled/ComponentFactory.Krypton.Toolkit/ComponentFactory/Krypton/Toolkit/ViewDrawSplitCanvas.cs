#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawSplitCanvas : ViewComposite
{
	private IPaletteBack _paletteBack;

	private IPaletteBorder _paletteBorder;

	private IPaletteMetric _paletteMetric;

	private IPaletteBack _paletteBackNormal;

	private IPaletteBorder _paletteBorderNormal;

	private PaletteMetricPadding _metricPadding;

	private PaletteBackInheritForced _paletteBackDraw;

	private PaletteBackLightenColors _paletteBackLight;

	private IDisposable _mementoBack;

	private PaletteBorderInheritForced _borderForced;

	private VisualOrientation _orientation;

	private TabBorderStyle _tabBorderStyle;

	private Region _clipRegion;

	private Rectangle _splitRectangle;

	private Rectangle _nonSplitRectangle;

	private bool _drawTabBorder;

	private bool _drawCanvas;

	private bool _drawOnComposition;

	private bool _splitter;

	public IPaletteBack PaletteBack
	{
		[DebuggerStepThrough]
		get
		{
			return _paletteBack;
		}
	}

	public IPaletteBorder PaletteBorder
	{
		[DebuggerStepThrough]
		get
		{
			return _paletteBorder;
		}
	}

	public IPaletteMetric PaletteMetric
	{
		[DebuggerStepThrough]
		get
		{
			return _paletteMetric;
		}
	}

	public Rectangle SplitRectangle
	{
		get
		{
			return _splitRectangle;
		}
		set
		{
			_splitRectangle = value;
			if (FindMouseController() is ButtonController buttonController)
			{
				buttonController.SplitRectangle = value;
			}
		}
	}

	public Rectangle NonSplitRectangle
	{
		get
		{
			return _nonSplitRectangle;
		}
		set
		{
			_nonSplitRectangle = value;
		}
	}

	public bool Splitter
	{
		get
		{
			return _splitter;
		}
		set
		{
			_splitter = value;
		}
	}

	public VisualOrientation Orientation
	{
		[DebuggerStepThrough]
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
		}
	}

	public bool DrawTabBorder
	{
		get
		{
			return _drawTabBorder;
		}
		set
		{
			_drawTabBorder = value;
		}
	}

	public TabBorderStyle TabBorderStyle
	{
		get
		{
			return _tabBorderStyle;
		}
		set
		{
			_tabBorderStyle = value;
		}
	}

	public PaletteDrawBorders MaxBorderEdges
	{
		get
		{
			if (_borderForced == null)
			{
				return PaletteDrawBorders.All;
			}
			return _borderForced.MaxBorderEdges;
		}
		set
		{
			if (_borderForced == null)
			{
				_borderForced = new PaletteBorderInheritForced(_paletteBorder);
				_paletteBorder = _borderForced;
			}
			_borderForced.MaxBorderEdges = value;
		}
	}

	public PaletteGraphicsHint ForceGraphicsHint
	{
		get
		{
			if (_borderForced == null)
			{
				return PaletteGraphicsHint.Inherit;
			}
			return _borderForced.ForceGraphicsHint;
		}
		set
		{
			if (_borderForced == null)
			{
				_borderForced = new PaletteBorderInheritForced(_paletteBorder);
				_paletteBorder = _borderForced;
			}
			_borderForced.ForceGraphicsHint = value;
		}
	}

	public virtual bool DrawBorderLast => true;

	public bool DrawCanvas
	{
		get
		{
			return _drawCanvas;
		}
		set
		{
			_drawCanvas = value;
		}
	}

	public bool DrawCanvasOnComposition
	{
		get
		{
			return _drawOnComposition;
		}
		set
		{
			_drawOnComposition = value;
		}
	}

	private bool MouseInSplit
	{
		get
		{
			if (FindMouseController() is ButtonController { MousePoint: var mousePoint } buttonController && !mousePoint.Equals(CommonHelper.NullPoint))
			{
				return _splitRectangle.Contains(buttonController.MousePoint);
			}
			return false;
		}
	}

	private bool SplitWithFading => _paletteMetric == null || _paletteMetric.GetMetricBool(State, PaletteMetricBool.SplitWithFading) == InheritBool.True;

	public ViewDrawSplitCanvas(IPaletteBack paletteBack, IPaletteBorder paletteBorder, VisualOrientation orientation)
		: this(paletteBack, paletteBorder, null, PaletteMetricPadding.HeaderGroupPaddingPrimary, orientation)
	{
	}

	public ViewDrawSplitCanvas(IPaletteBack paletteBack, IPaletteBorder paletteBorder, IPaletteMetric paletteMetric, PaletteMetricPadding metricPadding, VisualOrientation orientation)
	{
		_paletteBorder = paletteBorder;
		_paletteBack = paletteBack;
		_paletteBackDraw = new PaletteBackInheritForced(_paletteBack);
		_paletteBackDraw.ForceDraw = InheritBool.True;
		_paletteBackLight = new PaletteBackLightenColors(_paletteBack);
		_paletteMetric = paletteMetric;
		_paletteBorderNormal = paletteBorder;
		_paletteBackNormal = paletteBack;
		_metricPadding = metricPadding;
		_orientation = orientation;
		_drawTabBorder = false;
		_drawCanvas = true;
		_splitter = false;
	}

	public override string ToString()
	{
		return "ViewDrawSplitCanvas:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_mementoBack != null)
			{
				_mementoBack.Dispose();
				_mementoBack = null;
			}
			if (_clipRegion != null)
			{
				_clipRegion.Dispose();
				_clipRegion = null;
			}
		}
		base.Dispose(disposing);
	}

	public virtual void SetPalettes(IPaletteBack paletteBack, IPaletteBorder paletteBorder)
	{
		SetPalettes(paletteBack, paletteBorder, _paletteMetric);
	}

	public virtual void SetPalettes(IPaletteBack paletteBack, IPaletteBorder paletteBorder, IPaletteMetric paletteMetric)
	{
		Debug.Assert(paletteBorder != null);
		Debug.Assert(paletteBack != null);
		_paletteBack = paletteBack;
		_paletteBackDraw.SetInherit(paletteBack);
		_paletteBackLight.Inherit = paletteBack;
		if (_borderForced == null)
		{
			_paletteBorder = paletteBorder;
		}
		else
		{
			_borderForced.SetInherit(paletteBorder);
		}
		_paletteMetric = paletteMetric;
	}

	public GraphicsPath GetOuterBorderPath(RenderContext context)
	{
		if (_paletteBorder != null)
		{
			return context.Renderer.RenderStandardBorder.GetOutsideBorderPath(context, ClientRectangle, _paletteBorder, Orientation, State);
		}
		return null;
	}

	public override bool EvalTransparentPaint(ViewContext context)
	{
		Debug.Assert(context != null);
		return context.Renderer.EvalTransparentPaint(_paletteBack, _paletteBorder, State);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current is ViewDrawContent)
				{
					ViewDrawContent viewDrawContent = (ViewDrawContent)current;
					viewDrawContent.DrawContentOnComposition = DrawCanvasOnComposition;
				}
			}
		}
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize = ((!DrawTabBorder) ? CommonHelper.ApplyPadding(Orientation, preferredSize, context.Renderer.RenderStandardBorder.GetBorderDisplayPadding(_paletteBorder, State, Orientation)) : CommonHelper.ApplyPadding(Orientation, preferredSize, context.Renderer.RenderTabBorder.GetTabBorderDisplayPadding(context, _paletteBorder, State, Orientation, TabBorderStyle)));
		if (_paletteMetric != null && _metricPadding != PaletteMetricPadding.None)
		{
			preferredSize = CommonHelper.ApplyPadding(Orientation, preferredSize, _paletteMetric.GetMetricPadding(State, _metricPadding));
		}
		return preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		ClientRectangle = context.DisplayRectangle;
		if (_paletteMetric != null && _metricPadding != PaletteMetricPadding.None)
		{
			Padding metricPadding = _paletteMetric.GetMetricPadding(State, _metricPadding);
			ClientRectangle = CommonHelper.ApplyPadding(Orientation, ClientRectangle, metricPadding);
		}
		context.DisplayRectangle = CommonHelper.ApplyPadding(padding: (!DrawTabBorder) ? context.Renderer.RenderStandardBorder.GetBorderDisplayPadding(_paletteBorder, State, Orientation) : context.Renderer.RenderTabBorder.GetTabBorderDisplayPadding(context, _paletteBorder, State, Orientation, TabBorderStyle), orientation: Orientation, rect: ClientRectangle);
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current is ViewDrawContent)
				{
					bool flag = _drawCanvas && _paletteBack.GetBackDraw(State) == InheritBool.True;
					ViewDrawContent viewDrawContent = (ViewDrawContent)current;
					viewDrawContent.DrawContentOnComposition = DrawCanvasOnComposition && !flag;
				}
			}
		}
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		RenderBackground(context, ClientRectangle);
		if (_drawCanvas && _paletteBorder != null)
		{
			if (!DrawBorderLast)
			{
				RenderBorder(context, ClientRectangle);
				return;
			}
			_clipRegion = context.Graphics.Clip.Clone();
			GraphicsPath graphicsPath = ((!DrawTabBorder) ? context.Renderer.RenderStandardBorder.GetBorderPath(context, ClientRectangle, _paletteBorder, Orientation, State) : context.Renderer.RenderTabBorder.GetTabBorderPath(context, ClientRectangle, _paletteBorder, Orientation, State, TabBorderStyle));
			Region region = new Region(graphicsPath);
			region.Intersect(_clipRegion);
			context.Graphics.Clip = region;
			graphicsPath.Dispose();
		}
	}

	public override void RenderAfter(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (_drawCanvas && _paletteBorder != null && DrawBorderLast)
		{
			Region clip = context.Graphics.Clip;
			context.Graphics.Clip = _clipRegion;
			_clipRegion = null;
			clip.Dispose();
			RenderBorder(context, ClientRectangle);
		}
	}

	private void RenderBackground(RenderContext context, Rectangle rect)
	{
		if (!_drawCanvas || _paletteBack.GetBackDraw(State) != InheritBool.True)
		{
			return;
		}
		if (Splitter)
		{
			bool mouseInSplit = MouseInSplit;
			switch (State)
			{
			case PaletteState.Tracking:
				using (new Clipping(context.Graphics, _nonSplitRectangle))
				{
					if (SplitWithFading)
					{
						IPaletteBack paletteBack5;
						if (!mouseInSplit)
						{
							paletteBack5 = _paletteBack;
						}
						else
						{
							IPaletteBack paletteBackLight = _paletteBackLight;
							paletteBack5 = paletteBackLight;
						}
						DrawBackground(context, rect, paletteBack5, _paletteBorder, PaletteState.Tracking);
					}
					else
					{
						IPaletteBack paletteBack6;
						if (!mouseInSplit)
						{
							paletteBack6 = _paletteBack;
						}
						else
						{
							IPaletteBack paletteBackLight = _paletteBackDraw;
							paletteBack6 = paletteBackLight;
						}
						DrawBackground(context, rect, paletteBack6, _paletteBorder, mouseInSplit ? PaletteState.Normal : PaletteState.Tracking);
					}
				}
				using (new Clipping(context.Graphics, _splitRectangle))
				{
					if (SplitWithFading)
					{
						IPaletteBack paletteBack7;
						if (!mouseInSplit)
						{
							IPaletteBack paletteBackLight = _paletteBackLight;
							paletteBack7 = paletteBackLight;
						}
						else
						{
							paletteBack7 = _paletteBack;
						}
						DrawBackground(context, rect, paletteBack7, _paletteBorder, PaletteState.Tracking);
					}
					else
					{
						IPaletteBack paletteBack8;
						if (!mouseInSplit)
						{
							IPaletteBack paletteBackLight = _paletteBackDraw;
							paletteBack8 = paletteBackLight;
						}
						else
						{
							paletteBack8 = _paletteBack;
						}
						DrawBackground(context, rect, paletteBack8, _paletteBorder, mouseInSplit ? PaletteState.Tracking : PaletteState.Normal);
					}
					break;
				}
			case PaletteState.Pressed:
				using (new Clipping(context.Graphics, _splitRectangle))
				{
					if (SplitWithFading)
					{
						IPaletteBack paletteBack;
						if (!mouseInSplit)
						{
							IPaletteBack paletteBackLight = _paletteBackLight;
							paletteBack = paletteBackLight;
						}
						else
						{
							paletteBack = _paletteBack;
						}
						DrawBackground(context, rect, paletteBack, _paletteBorder, mouseInSplit ? PaletteState.Pressed : PaletteState.Tracking);
					}
					else
					{
						IPaletteBack paletteBack2;
						if (!mouseInSplit)
						{
							IPaletteBack paletteBackLight = _paletteBackDraw;
							paletteBack2 = paletteBackLight;
						}
						else
						{
							paletteBack2 = _paletteBack;
						}
						DrawBackground(context, rect, paletteBack2, _paletteBorder, mouseInSplit ? PaletteState.Pressed : PaletteState.Normal);
					}
				}
				using (new Clipping(context.Graphics, _nonSplitRectangle))
				{
					if (SplitWithFading)
					{
						IPaletteBack paletteBack3;
						if (!mouseInSplit)
						{
							paletteBack3 = _paletteBack;
						}
						else
						{
							IPaletteBack paletteBackLight = _paletteBackLight;
							paletteBack3 = paletteBackLight;
						}
						DrawBackground(context, rect, paletteBack3, _paletteBorder, mouseInSplit ? PaletteState.Tracking : PaletteState.Pressed);
					}
					else
					{
						IPaletteBack paletteBack4;
						if (!mouseInSplit)
						{
							paletteBack4 = _paletteBack;
						}
						else
						{
							IPaletteBack paletteBackLight = _paletteBackDraw;
							paletteBack4 = paletteBackLight;
						}
						DrawBackground(context, rect, paletteBack4, _paletteBorder, mouseInSplit ? PaletteState.Normal : PaletteState.Pressed);
					}
					break;
				}
			default:
				DrawBackground(context, rect, _paletteBack, _paletteBorder, State);
				break;
			}
		}
		else
		{
			DrawBackground(context, rect, _paletteBack, _paletteBorder, State);
		}
	}

	private void RenderBorder(RenderContext context, Rectangle rect)
	{
		Debug.Assert(context != null);
		if (_paletteBorder.GetBorderDraw(State) != InheritBool.True)
		{
			return;
		}
		if (Splitter)
		{
			bool mouseInSplit = MouseInSplit;
			switch (State)
			{
			case PaletteState.Tracking:
				DrawBorder(context, rect, _paletteBorder, PaletteState.Tracking);
				break;
			case PaletteState.Pressed:
				DrawBorder(context, rect, _paletteBorder, PaletteState.Tracking);
				using (new Clipping(context.Graphics, mouseInSplit ? _splitRectangle : _nonSplitRectangle))
				{
					DrawBorder(context, rect, _paletteBorder, PaletteState.Pressed);
					break;
				}
			default:
				DrawBorder(context, rect, _paletteBorder, State);
				break;
			}
		}
		else
		{
			DrawBorder(context, rect, _paletteBorder, State);
		}
	}

	private void DrawBackground(RenderContext context, Rectangle rect, IPaletteBack paletteBack, IPaletteBorder paletteBorder, PaletteState state)
	{
		GraphicsPath graphicsPath;
		Padding padding;
		if (DrawTabBorder)
		{
			graphicsPath = context.Renderer.RenderTabBorder.GetTabBackPath(context, rect, paletteBorder, Orientation, state, TabBorderStyle);
			padding = Padding.Empty;
		}
		else
		{
			graphicsPath = context.Renderer.RenderStandardBorder.GetBackPath(context, rect, paletteBorder, Orientation, state);
			padding = context.Renderer.RenderStandardBorder.GetBorderRawPadding(paletteBorder, state, Orientation);
		}
		Rectangle rect2 = CommonHelper.ApplyPadding(_orientation, rect, padding);
		_mementoBack = context.Renderer.RenderStandardBack.DrawBack(context, rect2, graphicsPath, paletteBack, _orientation, state, _mementoBack);
		graphicsPath.Dispose();
	}

	private void DrawBorder(RenderContext context, Rectangle rect, IPaletteBorder paletteBorder, PaletteState state)
	{
		if (DrawTabBorder)
		{
			context.Renderer.RenderTabBorder.DrawTabBorder(context, rect, _paletteBorder, _orientation, state, TabBorderStyle);
		}
		else
		{
			context.Renderer.RenderStandardBorder.DrawBorder(context, rect, _paletteBorder, _orientation, state);
		}
	}
}
