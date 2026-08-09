#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawCanvas : ViewComposite
{
	internal IPaletteBack _paletteBack;

	internal IPaletteBorder _paletteBorder;

	internal IPaletteMetric _paletteMetric;

	internal PaletteMetricPadding _metricPadding;

	private IDisposable _mementoBack;

	private PaletteBorderInheritForced _borderForced;

	private VisualOrientation _orientation;

	private VisualOrientation _includeBorderEdge;

	private TabBorderStyle _tabBorderStyle;

	private Region _clipRegion;

	private bool _drawTabBorder;

	private bool _drawCanvas;

	private bool _drawOnComposition;

	private bool _applyIncludeBorderEdge;

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

	public VisualOrientation IncludeBorderEdge
	{
		get
		{
			return _includeBorderEdge;
		}
		set
		{
			_includeBorderEdge = value;
		}
	}

	public bool ApplyIncludeBorderEdge
	{
		get
		{
			return _applyIncludeBorderEdge;
		}
		set
		{
			_applyIncludeBorderEdge = value;
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
			if (_applyIncludeBorderEdge)
			{
				switch (_includeBorderEdge)
				{
				case VisualOrientation.Top:
					value |= PaletteDrawBorders.Top;
					break;
				case VisualOrientation.Bottom:
					value |= PaletteDrawBorders.Bottom;
					break;
				case VisualOrientation.Left:
					value |= PaletteDrawBorders.Left;
					break;
				case VisualOrientation.Right:
					value |= PaletteDrawBorders.Right;
					break;
				}
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

	public ViewDrawCanvas(IPaletteBack paletteBack, IPaletteBorder paletteBorder, VisualOrientation orientation)
		: this(paletteBack, paletteBorder, null, PaletteMetricPadding.HeaderGroupPaddingPrimary, orientation)
	{
	}

	public ViewDrawCanvas(IPaletteBack paletteBack, IPaletteBorder paletteBorder, IPaletteMetric paletteMetric, PaletteMetricPadding metricPadding, VisualOrientation orientation)
	{
		_paletteBorder = paletteBorder;
		_paletteBack = paletteBack;
		_paletteMetric = paletteMetric;
		_metricPadding = metricPadding;
		_orientation = orientation;
		_includeBorderEdge = orientation;
		_applyIncludeBorderEdge = false;
		_drawTabBorder = false;
		_drawCanvas = true;
	}

	public override string ToString()
	{
		return "ViewDrawCanvas:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _mementoBack != null)
		{
			_mementoBack.Dispose();
			_mementoBack = null;
		}
		base.Dispose(disposing);
	}

	public virtual void SetPalettes(IPaletteBack paletteBack, IPaletteBorder paletteBorder)
	{
		SetPalettes(paletteBack, paletteBorder, null);
	}

	public virtual void SetPalettes(IPaletteBack paletteBack, IPaletteBorder paletteBorder, IPaletteMetric paletteMetric)
	{
		Debug.Assert(paletteBorder != null);
		Debug.Assert(paletteBack != null);
		_paletteBack = paletteBack;
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
		if (_paletteMetric != null)
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
		if (_paletteMetric != null)
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
		if (_drawCanvas && _paletteBack.GetBackDraw(State) == InheritBool.True)
		{
			GraphicsPath graphicsPath;
			Padding padding;
			if (DrawTabBorder)
			{
				graphicsPath = context.Renderer.RenderTabBorder.GetTabBackPath(context, ClientRectangle, _paletteBorder, Orientation, State, TabBorderStyle);
				padding = Padding.Empty;
			}
			else
			{
				graphicsPath = context.Renderer.RenderStandardBorder.GetBackPath(context, ClientRectangle, _paletteBorder, Orientation, State);
				padding = context.Renderer.RenderStandardBorder.GetBorderRawPadding(_paletteBorder, State, Orientation);
			}
			Rectangle rect = CommonHelper.ApplyPadding(_orientation, ClientRectangle, padding);
			_mementoBack = context.Renderer.RenderStandardBack.DrawBack(context, rect, graphicsPath, _paletteBack, _orientation, State, _mementoBack);
			graphicsPath.Dispose();
		}
		if (_drawCanvas && _paletteBorder != null)
		{
			if (!DrawBorderLast)
			{
				RenderBorder(context);
				return;
			}
			_clipRegion = context.Graphics.Clip.Clone();
			GraphicsPath graphicsPath2 = ((!DrawTabBorder) ? context.Renderer.RenderStandardBorder.GetBorderPath(context, ClientRectangle, _paletteBorder, Orientation, State) : context.Renderer.RenderTabBorder.GetTabBorderPath(context, ClientRectangle, _paletteBorder, Orientation, State, TabBorderStyle));
			Region region = new Region(graphicsPath2);
			region.Intersect(_clipRegion);
			context.Graphics.Clip = region;
			graphicsPath2.Dispose();
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
			clip.Dispose();
			RenderBorder(context);
		}
	}

	public virtual void RenderBorder(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_paletteBorder.GetBorderDraw(State) == InheritBool.True)
		{
			if (DrawTabBorder)
			{
				context.Renderer.RenderTabBorder.DrawTabBorder(context, ClientRectangle, _paletteBorder, _orientation, State, TabBorderStyle);
			}
			else
			{
				context.Renderer.RenderStandardBorder.DrawBorder(context, ClientRectangle, _paletteBorder, _orientation, State);
			}
		}
	}
}
