#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawDocker : ViewDrawCanvas
{
	private PaletteMetricBool _metricOverlay;

	private ViewDockStyleLookup _childDocking;

	private Rectangle _fillRectangle;

	private bool _ignoreBorderSpace;

	private bool _ignoreAllBorderAndPadding;

	private bool _removeChildBorders;

	private bool _preferredSizeAll;

	private bool _forceBorderFirst;

	public bool IgnoreBorderSpace
	{
		get
		{
			return _ignoreBorderSpace;
		}
		set
		{
			_ignoreBorderSpace = value;
		}
	}

	public bool IgnoreAllBorderAndPadding
	{
		get
		{
			return _ignoreAllBorderAndPadding;
		}
		set
		{
			_ignoreAllBorderAndPadding = value;
		}
	}

	public bool RemoveChildBorders
	{
		get
		{
			return _removeChildBorders;
		}
		set
		{
			_removeChildBorders = value;
		}
	}

	public bool ForceBorderFirst
	{
		get
		{
			return _forceBorderFirst;
		}
		set
		{
			_forceBorderFirst = value;
		}
	}

	public bool PreferredSizeAll
	{
		get
		{
			return _preferredSizeAll;
		}
		set
		{
			_preferredSizeAll = value;
		}
	}

	public override bool DrawBorderLast
	{
		get
		{
			if (_forceBorderFirst)
			{
				return false;
			}
			if (_paletteMetric != null && _metricOverlay != PaletteMetricBool.None)
			{
				InheritBool metricBool = _paletteMetric.GetMetricBool(ElementState, _metricOverlay);
				return metricBool == InheritBool.False;
			}
			return base.DrawBorderLast;
		}
	}

	public Rectangle FillRectangle => _fillRectangle;

	public ViewDrawDocker()
		: this(null, null, null, PaletteMetricBool.None)
	{
	}

	public ViewDrawDocker(IPaletteBack paletteBack, IPaletteBorder paletteBorder)
		: this(paletteBack, paletteBorder, null, PaletteMetricBool.None)
	{
	}

	public ViewDrawDocker(IPaletteBack paletteBack, IPaletteBorder paletteBorder, IPaletteMetric paletteMetric)
		: this(paletteBack, paletteBorder, paletteMetric, PaletteMetricBool.None)
	{
	}

	public ViewDrawDocker(IPaletteBack paletteBack, IPaletteBorder paletteBorder, IPaletteMetric paletteMetric, PaletteMetricBool metricOverlay)
		: this(paletteBack, paletteBorder, paletteMetric, metricOverlay, PaletteMetricPadding.None, VisualOrientation.Top)
	{
	}

	public ViewDrawDocker(IPaletteBack paletteBack, IPaletteBorder paletteBorder, IPaletteMetric paletteMetric, PaletteMetricBool metricOverlay, PaletteMetricPadding metricPadding, VisualOrientation orientation)
		: base(paletteBack, paletteBorder, paletteMetric, metricPadding, orientation)
	{
		_metricOverlay = metricOverlay;
		_childDocking = new ViewDockStyleLookup();
		_fillRectangle = Rectangle.Empty;
		_ignoreBorderSpace = false;
		_removeChildBorders = false;
		_preferredSizeAll = false;
	}

	public override string ToString()
	{
		return "ViewDrawDocker:" + base.Id;
	}

	public ViewDockStyle GetDock(ViewBase child)
	{
		Debug.Assert(child != null);
		if (!_childDocking.ContainsKey(child))
		{
			_childDocking.Add(child, ViewDockStyle.Top);
		}
		return _childDocking[child];
	}

	public void SetDock(ViewBase child, ViewDockStyle dock)
	{
		Debug.Assert(child != null);
		if (!_childDocking.ContainsKey(child))
		{
			_childDocking.Add(child, dock);
		}
		else
		{
			_childDocking[child] = dock;
		}
	}

	public void Add(ViewBase item, ViewDockStyle dock)
	{
		Add(item);
		SetDock(item, dock);
	}

	public override bool EvalTransparentPaint(ViewContext context)
	{
		Debug.Assert(context != null);
		if (base.EvalTransparentPaint(context))
		{
			return true;
		}
		if (!DrawBorderLast)
		{
			foreach (ViewBase item in Reverse())
			{
				if (item.Visible)
				{
					ViewDockStyle dock = GetDock(item);
					ViewDockStyle viewDockStyle = dock;
					if ((uint)(viewDockStyle - 1) <= 3u && item.EvalTransparentPaint(context))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public Size GetNonChildSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Rectangle displayRectangle = context.DisplayRectangle;
		Rectangle rect = context.DisplayRectangle;
		Size size = Size.Empty;
		Size size2 = Size.Empty;
		Size empty = Size.Empty;
		if (!IgnoreAllBorderAndPadding)
		{
			if (IgnoreBorderSpace)
			{
				size = CommonHelper.ApplyPadding(base.Orientation, size, context.Renderer.RenderStandardBorder.GetBorderDisplayPadding(_paletteBorder, State, base.Orientation));
			}
			else
			{
				Padding borderDisplayPadding = context.Renderer.RenderStandardBorder.GetBorderDisplayPadding(_paletteBorder, State, base.Orientation);
				size2 = CommonHelper.ApplyPadding(base.Orientation, size2, borderDisplayPadding);
				rect = CommonHelper.ApplyPadding(base.Orientation, rect, borderDisplayPadding);
			}
			if (_paletteMetric != null && _metricPadding != PaletteMetricPadding.None)
			{
				Padding metricPadding = _paletteMetric.GetMetricPadding(State, _metricPadding);
				size2 = CommonHelper.ApplyPadding(base.Orientation, size2, metricPadding);
				rect = CommonHelper.ApplyPadding(base.Orientation, rect, metricPadding);
			}
		}
		context.DisplayRectangle = displayRectangle;
		size2.Width = Math.Max(size2.Width, empty.Width);
		size2.Height = Math.Max(size2.Height, empty.Height);
		size2.Width = Math.Max(size2.Width, size.Width);
		size2.Height = Math.Max(size2.Height, size.Height);
		return size2;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		Rectangle displayRectangle = context.DisplayRectangle;
		Rectangle rectangle = context.DisplayRectangle;
		Size size = Size.Empty;
		Size size2 = Size.Empty;
		Size empty = Size.Empty;
		if (!IgnoreAllBorderAndPadding)
		{
			if (IgnoreBorderSpace)
			{
				size = CommonHelper.ApplyPadding(base.Orientation, size, context.Renderer.RenderStandardBorder.GetBorderDisplayPadding(_paletteBorder, State, base.Orientation));
			}
			else
			{
				Padding borderDisplayPadding = context.Renderer.RenderStandardBorder.GetBorderDisplayPadding(_paletteBorder, State, base.Orientation);
				size2 = CommonHelper.ApplyPadding(base.Orientation, size2, borderDisplayPadding);
				rectangle = CommonHelper.ApplyPadding(base.Orientation, rectangle, borderDisplayPadding);
			}
			if (_paletteMetric != null && _metricPadding != PaletteMetricPadding.None)
			{
				Padding metricPadding = _paletteMetric.GetMetricPadding(State, _metricPadding);
				size2 = CommonHelper.ApplyPadding(base.Orientation, size2, metricPadding);
				rectangle = CommonHelper.ApplyPadding(base.Orientation, rectangle, metricPadding);
			}
		}
		PaletteDrawBorders leftEdges = PaletteDrawBorders.All;
		PaletteDrawBorders rightEdges = PaletteDrawBorders.All;
		PaletteDrawBorders topEdges = PaletteDrawBorders.All;
		PaletteDrawBorders bottomEdges = PaletteDrawBorders.All;
		PaletteDrawBorders fillEdges = PaletteDrawBorders.All;
		foreach (ViewBase item in Reverse())
		{
			if ((!item.Visible && !PreferredSizeAll) || GetDock(item) == ViewDockStyle.Fill)
			{
				continue;
			}
			UpdateChildBorders(item, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);
			context.DisplayRectangle = rectangle;
			Size preferredSize = item.GetPreferredSize(context);
			switch (OrientateDock(GetDock(item)))
			{
			case ViewDockStyle.Top:
				size2.Height += preferredSize.Height;
				rectangle.Y += preferredSize.Height;
				rectangle.Height -= preferredSize.Height;
				if (empty.Width < preferredSize.Width)
				{
					empty.Width = preferredSize.Width;
				}
				break;
			case ViewDockStyle.Bottom:
				size2.Height += preferredSize.Height;
				rectangle.Height -= preferredSize.Height;
				if (empty.Width < preferredSize.Width)
				{
					empty.Width = preferredSize.Width;
				}
				break;
			case ViewDockStyle.Left:
				size2.Width += preferredSize.Width;
				rectangle.X += preferredSize.Width;
				rectangle.Width -= preferredSize.Width;
				if (empty.Height < preferredSize.Height)
				{
					empty.Height = preferredSize.Height;
				}
				break;
			case ViewDockStyle.Right:
				size2.Width += preferredSize.Width;
				rectangle.Width -= preferredSize.Width;
				if (empty.Height < preferredSize.Height)
				{
					empty.Height = preferredSize.Height;
				}
				break;
			}
		}
		foreach (ViewBase item2 in Reverse())
		{
			if ((item2.Visible || PreferredSizeAll) && GetDock(item2) == ViewDockStyle.Fill)
			{
				UpdateChildBorders(item2, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);
				context.DisplayRectangle = rectangle;
				Size preferredSize2 = item2.GetPreferredSize(context);
				size2.Width += preferredSize2.Width;
				size2.Height += preferredSize2.Height;
			}
		}
		context.DisplayRectangle = displayRectangle;
		size2.Width = Math.Max(size2.Width, empty.Width);
		size2.Height = Math.Max(size2.Height, empty.Height);
		size2.Width = Math.Max(size2.Width, size.Width);
		size2.Height = Math.Max(size2.Height, size.Height);
		return size2;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		if (!IgnoreAllBorderAndPadding && _paletteMetric != null && _metricPadding != PaletteMetricPadding.None)
		{
			Padding metricPadding = _paletteMetric.GetMetricPadding(State, _metricPadding);
			ClientRectangle = CommonHelper.ApplyPadding(base.Orientation, ClientRectangle, metricPadding);
		}
		Rectangle rectangle = (context.DisplayRectangle = ClientRectangle);
		PaletteDrawBorders leftEdges = PaletteDrawBorders.All;
		PaletteDrawBorders rightEdges = PaletteDrawBorders.All;
		PaletteDrawBorders topEdges = PaletteDrawBorders.All;
		PaletteDrawBorders bottomEdges = PaletteDrawBorders.All;
		PaletteDrawBorders fillEdges = PaletteDrawBorders.All;
		foreach (ViewBase item in Reverse())
		{
			if (item.Visible && GetDock(item) != ViewDockStyle.Fill)
			{
				UpdateChildBorders(item, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);
				Size preferredSize = item.GetPreferredSize(context);
				switch (CalculateDock(OrientateDock(GetDock(item)), context.Control))
				{
				case ViewDockStyle.Top:
					context.DisplayRectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, preferredSize.Height);
					rectangle.Height -= preferredSize.Height;
					rectangle.Y += preferredSize.Height;
					break;
				case ViewDockStyle.Bottom:
					context.DisplayRectangle = new Rectangle(rectangle.X, rectangle.Bottom - preferredSize.Height, rectangle.Width, preferredSize.Height);
					rectangle.Height -= preferredSize.Height;
					break;
				case ViewDockStyle.Left:
					context.DisplayRectangle = new Rectangle(rectangle.X, rectangle.Y, preferredSize.Width, rectangle.Height);
					rectangle.Width -= preferredSize.Width;
					rectangle.X += preferredSize.Width;
					break;
				case ViewDockStyle.Right:
					context.DisplayRectangle = new Rectangle(rectangle.Right - preferredSize.Width, rectangle.Y, preferredSize.Width, rectangle.Height);
					rectangle.Width -= preferredSize.Width;
					break;
				}
				item.Layout(context);
			}
		}
		int num = 0;
		Rectangle clientRectangle2 = ClientRectangle;
		Padding padding = Padding.Empty;
		if (!IgnoreAllBorderAndPadding)
		{
			num = _paletteBorder.GetBorderWidth(State);
			padding = context.Renderer.RenderStandardBorder.GetBorderDisplayPadding(_paletteBorder, State, base.Orientation);
			padding = CommonHelper.OrientatePadding(base.Orientation, padding);
			padding = AdjustPaddingForDockers(padding, rectangle, num);
		}
		clientRectangle2 = new Rectangle(clientRectangle2.X + padding.Left, clientRectangle2.Y + padding.Top, clientRectangle2.Width - padding.Horizontal, clientRectangle2.Height - padding.Vertical);
		if (rectangle.X < clientRectangle2.X)
		{
			rectangle.Width -= clientRectangle2.X - rectangle.X;
			rectangle.X = clientRectangle2.X;
		}
		if (rectangle.Y < clientRectangle2.Y)
		{
			rectangle.Height -= clientRectangle2.Y - rectangle.Y;
			rectangle.Y = clientRectangle2.Y;
		}
		if (rectangle.Right > clientRectangle2.Right)
		{
			rectangle.Width -= rectangle.Right - clientRectangle2.Right;
		}
		if (rectangle.Bottom > clientRectangle2.Bottom)
		{
			rectangle.Height -= rectangle.Bottom - clientRectangle2.Bottom;
		}
		foreach (ViewBase item2 in Reverse())
		{
			if (item2.Visible && GetDock(item2) == ViewDockStyle.Fill)
			{
				UpdateChildBorders(item2, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);
				context.DisplayRectangle = rectangle;
				item2.Layout(context);
			}
		}
		context.DisplayRectangle = ClientRectangle;
		_fillRectangle = rectangle;
	}

	private void UpdateChildBorders(ViewBase child, ViewLayoutContext context, ref PaletteDrawBorders leftEdges, ref PaletteDrawBorders rightEdges, ref PaletteDrawBorders topEdges, ref PaletteDrawBorders bottomEdges, ref PaletteDrawBorders fillEdges)
	{
		if (!RemoveChildBorders)
		{
			return;
		}
		ViewDrawCanvas viewDrawCanvas = child as ViewDrawCanvas;
		switch (CalculateDock(GetDock(child), context.Control))
		{
		case ViewDockStyle.Top:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(topEdges, viewDrawCanvas.Orientation);
			}
			leftEdges &= PaletteDrawBorders.BottomLeftRight;
			rightEdges &= PaletteDrawBorders.BottomLeftRight;
			topEdges &= PaletteDrawBorders.BottomLeftRight;
			break;
		case ViewDockStyle.Bottom:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(bottomEdges, viewDrawCanvas.Orientation);
			}
			leftEdges &= PaletteDrawBorders.TopLeftRight;
			rightEdges &= PaletteDrawBorders.TopLeftRight;
			bottomEdges &= PaletteDrawBorders.TopLeftRight;
			break;
		case ViewDockStyle.Left:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(leftEdges, viewDrawCanvas.Orientation);
			}
			topEdges &= PaletteDrawBorders.TopBottomRight;
			bottomEdges &= PaletteDrawBorders.TopBottomRight;
			leftEdges &= PaletteDrawBorders.TopBottomRight;
			break;
		case ViewDockStyle.Right:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(rightEdges, viewDrawCanvas.Orientation);
			}
			topEdges &= PaletteDrawBorders.TopBottomLeft;
			bottomEdges &= PaletteDrawBorders.TopBottomLeft;
			rightEdges &= PaletteDrawBorders.TopBottomLeft;
			break;
		}
	}

	private Padding AdjustPaddingForDockers(Padding padding, Rectangle fillerRect, int borderWidth)
	{
		int y = fillerRect.Y;
		int x = fillerRect.X;
		int num = ClientRectangle.Bottom - fillerRect.Bottom;
		int num2 = ClientRectangle.Right - fillerRect.Right;
		int num3 = padding.Top * 2;
		int num4 = padding.Bottom * 2;
		int num5 = padding.Left * 2;
		int num6 = padding.Right * 2;
		if (padding.Left > borderWidth && y >= num3 && y >= padding.Top && num >= num4 && num >= padding.Bottom)
		{
			padding.Left = borderWidth;
		}
		if (padding.Right > borderWidth && y >= num3 && y >= padding.Top && num >= num4 && num >= padding.Bottom)
		{
			padding.Right = borderWidth;
		}
		if (padding.Top > borderWidth && x >= num5 && x >= padding.Left && num2 >= num6 && num2 >= padding.Right)
		{
			padding.Top = borderWidth;
		}
		if (padding.Bottom > borderWidth && x >= num5 && x >= padding.Left && num2 >= num6 && num2 >= padding.Right)
		{
			padding.Bottom = borderWidth;
		}
		return padding;
	}

	protected ViewDockStyle CalculateDock(ViewDockStyle ds, Control control)
	{
		if (CommonHelper.GetRightToLeftLayout(control) && control.RightToLeft == RightToLeft.Yes)
		{
			switch (ds)
			{
			case ViewDockStyle.Left:
				ds = ViewDockStyle.Right;
				break;
			case ViewDockStyle.Right:
				ds = ViewDockStyle.Left;
				break;
			}
		}
		return ds;
	}

	protected ViewDockStyle OrientateDock(ViewDockStyle style)
	{
		switch (base.Orientation)
		{
		case VisualOrientation.Left:
			switch (style)
			{
			case ViewDockStyle.Top:
				return ViewDockStyle.Left;
			case ViewDockStyle.Left:
				return ViewDockStyle.Bottom;
			case ViewDockStyle.Right:
				return ViewDockStyle.Top;
			case ViewDockStyle.Bottom:
				return ViewDockStyle.Right;
			}
			break;
		case VisualOrientation.Right:
			switch (style)
			{
			case ViewDockStyle.Top:
				return ViewDockStyle.Right;
			case ViewDockStyle.Left:
				return ViewDockStyle.Top;
			case ViewDockStyle.Right:
				return ViewDockStyle.Bottom;
			case ViewDockStyle.Bottom:
				return ViewDockStyle.Left;
			}
			break;
		case VisualOrientation.Bottom:
			switch (style)
			{
			case ViewDockStyle.Top:
				return ViewDockStyle.Bottom;
			case ViewDockStyle.Left:
				return ViewDockStyle.Right;
			case ViewDockStyle.Right:
				return ViewDockStyle.Left;
			case ViewDockStyle.Bottom:
				return ViewDockStyle.Top;
			}
			break;
		default:
			Debug.Assert(condition: false);
			break;
		case VisualOrientation.Top:
			break;
		}
		return style;
	}
}
