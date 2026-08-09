#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutDocker : ViewComposite
{
	private VisualOrientation _orientation;

	private ViewDockStyleLookup _childDocking;

	private Rectangle _fillRectangle;

	private PaletteDrawBorders _maxBorderEdges;

	private bool _preferredSizeAll;

	private bool _removeChildBorders;

	private bool _ignoreRightToLeftLayout;

	private Padding _padding;

	private object _tag;

	public bool IgnoreRightToLeftLayout
	{
		get
		{
			return _ignoreRightToLeftLayout;
		}
		set
		{
			_ignoreRightToLeftLayout = value;
		}
	}

	public VisualOrientation Orientation
	{
		get
		{
			return _orientation;
		}
		set
		{
			_orientation = value;
		}
	}

	public Padding Padding
	{
		get
		{
			return _padding;
		}
		set
		{
			_padding = value;
		}
	}

	public PaletteDrawBorders MaxBorderEdges
	{
		get
		{
			return _maxBorderEdges;
		}
		set
		{
			_maxBorderEdges = value;
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

	public Rectangle FillRectangle => _fillRectangle;

	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	public ViewLayoutDocker()
	{
		_childDocking = new ViewDockStyleLookup();
		_fillRectangle = Rectangle.Empty;
		_orientation = VisualOrientation.Top;
		_maxBorderEdges = PaletteDrawBorders.All;
		_preferredSizeAll = false;
		_removeChildBorders = false;
		_ignoreRightToLeftLayout = false;
		_padding = Padding.Empty;
	}

	public override string ToString()
	{
		return "ViewLayoutDocker:" + base.Id + " " + _childDocking.Count;
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

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ViewDockStyleLookup viewDockStyleLookup = new ViewDockStyleLookup();
		Rectangle displayRectangle = context.DisplayRectangle;
		Rectangle displayRectangle2 = context.DisplayRectangle;
		Size empty = Size.Empty;
		Size empty2 = Size.Empty;
		PaletteDrawBorders leftEdges = PaletteDrawBorders.All;
		PaletteDrawBorders rightEdges = PaletteDrawBorders.All;
		PaletteDrawBorders topEdges = PaletteDrawBorders.All;
		PaletteDrawBorders bottomEdges = PaletteDrawBorders.All;
		PaletteDrawBorders fillEdges = PaletteDrawBorders.All;
		foreach (ViewBase item in Reverse())
		{
			ViewDockStyle dock = GetDock(item);
			viewDockStyleLookup.Add(item, dock);
			if ((!item.Visible && !PreferredSizeAll) || GetDock(item) == ViewDockStyle.Fill)
			{
				continue;
			}
			UpdateChildBorders(item, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);
			context.DisplayRectangle = displayRectangle2;
			Size preferredSize = item.GetPreferredSize(context);
			switch (OrientateDock(dock))
			{
			case ViewDockStyle.Top:
				empty.Height += preferredSize.Height;
				displayRectangle2.Y += preferredSize.Height;
				displayRectangle2.Height -= preferredSize.Height;
				if (empty2.Width < preferredSize.Width)
				{
					empty2.Width = preferredSize.Width;
				}
				break;
			case ViewDockStyle.Bottom:
				empty.Height += preferredSize.Height;
				displayRectangle2.Height -= preferredSize.Height;
				if (empty2.Width < preferredSize.Width)
				{
					empty2.Width = preferredSize.Width;
				}
				break;
			case ViewDockStyle.Left:
				empty.Width += preferredSize.Width;
				displayRectangle2.X += preferredSize.Width;
				displayRectangle2.Width -= preferredSize.Width;
				if (empty2.Height < preferredSize.Height)
				{
					empty2.Height = preferredSize.Height;
				}
				break;
			case ViewDockStyle.Right:
				empty.Width += preferredSize.Width;
				displayRectangle2.Width -= preferredSize.Width;
				if (empty2.Height < preferredSize.Height)
				{
					empty2.Height = preferredSize.Height;
				}
				break;
			}
		}
		foreach (ViewBase item2 in Reverse())
		{
			if ((item2.Visible || PreferredSizeAll) && GetDock(item2) == ViewDockStyle.Fill)
			{
				UpdateChildBorders(item2, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);
				context.DisplayRectangle = displayRectangle2;
				Size preferredSize2 = item2.GetPreferredSize(context);
				empty.Width += preferredSize2.Width;
				empty.Height += preferredSize2.Height;
				break;
			}
		}
		_childDocking = viewDockStyleLookup;
		context.DisplayRectangle = displayRectangle;
		empty.Width = Math.Max(empty.Width, empty2.Width);
		empty.Height = Math.Max(empty.Height, empty2.Height);
		switch (Orientation)
		{
		case VisualOrientation.Top:
		case VisualOrientation.Bottom:
			empty.Width += Padding.Horizontal;
			empty.Height += Padding.Vertical;
			break;
		case VisualOrientation.Left:
		case VisualOrientation.Right:
			empty.Width += Padding.Vertical;
			empty.Height += Padding.Horizontal;
			break;
		}
		return UpdatePreferredSize(empty);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		Rectangle clientRectangle = ClientRectangle;
		switch (Orientation)
		{
		case VisualOrientation.Top:
			clientRectangle.X += Padding.Left;
			clientRectangle.Y += Padding.Top;
			clientRectangle.Width -= Padding.Horizontal;
			clientRectangle.Height -= Padding.Vertical;
			break;
		case VisualOrientation.Bottom:
			clientRectangle.X += Padding.Right;
			clientRectangle.Y += Padding.Bottom;
			clientRectangle.Width -= Padding.Horizontal;
			clientRectangle.Height -= Padding.Vertical;
			break;
		case VisualOrientation.Left:
			clientRectangle.X += Padding.Top;
			clientRectangle.Y += Padding.Right;
			clientRectangle.Width -= Padding.Vertical;
			clientRectangle.Height -= Padding.Horizontal;
			break;
		case VisualOrientation.Right:
			clientRectangle.X += Padding.Bottom;
			clientRectangle.Y += Padding.Left;
			clientRectangle.Width -= Padding.Vertical;
			clientRectangle.Height -= Padding.Horizontal;
			break;
		}
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
				context.DisplayRectangle = clientRectangle;
				Size preferredSize = item.GetPreferredSize(context);
				switch (CalculateDock(OrientateDock(GetDock(item)), context.Control))
				{
				case ViewDockStyle.Top:
					context.DisplayRectangle = new Rectangle(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, preferredSize.Height);
					clientRectangle.Height -= preferredSize.Height;
					clientRectangle.Y += preferredSize.Height;
					break;
				case ViewDockStyle.Bottom:
					context.DisplayRectangle = new Rectangle(clientRectangle.X, clientRectangle.Bottom - preferredSize.Height, clientRectangle.Width, preferredSize.Height);
					clientRectangle.Height -= preferredSize.Height;
					break;
				case ViewDockStyle.Left:
					context.DisplayRectangle = new Rectangle(clientRectangle.X, clientRectangle.Y, preferredSize.Width, clientRectangle.Height);
					clientRectangle.Width -= preferredSize.Width;
					clientRectangle.X += preferredSize.Width;
					break;
				case ViewDockStyle.Right:
					context.DisplayRectangle = new Rectangle(clientRectangle.Right - preferredSize.Width, clientRectangle.Y, preferredSize.Width, clientRectangle.Height);
					clientRectangle.Width -= preferredSize.Width;
					break;
				}
				item.Layout(context);
			}
		}
		clientRectangle = UpdateFillerRect(clientRectangle, context.Control);
		foreach (ViewBase item2 in Reverse())
		{
			if (item2.Visible && GetDock(item2) == ViewDockStyle.Fill)
			{
				UpdateChildBorders(item2, context, ref leftEdges, ref rightEdges, ref topEdges, ref bottomEdges, ref fillEdges);
				context.DisplayRectangle = clientRectangle;
				item2.Layout(context);
			}
		}
		context.DisplayRectangle = ClientRectangle;
		_fillRectangle = clientRectangle;
	}

	protected virtual Size UpdatePreferredSize(Size preferredSize)
	{
		return preferredSize;
	}

	protected virtual Rectangle UpdateFillerRect(Rectangle fillerRect, Control control)
	{
		return fillerRect;
	}

	protected ViewDockStyle CalculateDock(ViewDockStyle ds, Control control)
	{
		if (IgnoreRightToLeftLayout)
		{
			return ds;
		}
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
		switch (Orientation)
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

	private void UpdateChildBorders(ViewBase child, ViewLayoutContext context, ref PaletteDrawBorders leftEdges, ref PaletteDrawBorders rightEdges, ref PaletteDrawBorders topEdges, ref PaletteDrawBorders bottomEdges, ref PaletteDrawBorders fillEdges)
	{
		if (!RemoveChildBorders)
		{
			return;
		}
		ViewDrawCanvas viewDrawCanvas = child as ViewDrawCanvas;
		switch (CalculateDock(GetDock(child), context.Control))
		{
		case ViewDockStyle.Fill:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(fillEdges, viewDrawCanvas.Orientation);
			}
			else
			{
				if (!(child is ViewLayoutDocker viewLayoutDocker))
				{
					break;
				}
				{
					foreach (ViewBase item in viewLayoutDocker)
					{
						if (item is ViewDrawCanvas viewDrawCanvas2)
						{
							viewDrawCanvas2.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(fillEdges, viewDrawCanvas2.Orientation);
						}
					}
					break;
				}
			}
			break;
		case ViewDockStyle.Top:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(topEdges, viewDrawCanvas.Orientation);
			}
			leftEdges &= PaletteDrawBorders.BottomLeftRight;
			rightEdges &= PaletteDrawBorders.BottomLeftRight;
			topEdges &= PaletteDrawBorders.BottomLeftRight;
			fillEdges &= PaletteDrawBorders.BottomLeftRight;
			break;
		case ViewDockStyle.Bottom:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(bottomEdges, viewDrawCanvas.Orientation);
			}
			leftEdges &= PaletteDrawBorders.TopLeftRight;
			rightEdges &= PaletteDrawBorders.TopLeftRight;
			bottomEdges &= PaletteDrawBorders.TopLeftRight;
			fillEdges &= PaletteDrawBorders.TopLeftRight;
			break;
		case ViewDockStyle.Left:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(leftEdges, viewDrawCanvas.Orientation);
			}
			topEdges &= PaletteDrawBorders.TopBottomRight;
			bottomEdges &= PaletteDrawBorders.TopBottomRight;
			leftEdges &= PaletteDrawBorders.TopBottomRight;
			fillEdges &= PaletteDrawBorders.TopBottomRight;
			break;
		case ViewDockStyle.Right:
			if (viewDrawCanvas != null)
			{
				viewDrawCanvas.MaxBorderEdges = CommonHelper.ReverseOrientateDrawBorders(rightEdges, viewDrawCanvas.Orientation);
			}
			topEdges &= PaletteDrawBorders.TopBottomLeft;
			bottomEdges &= PaletteDrawBorders.TopBottomLeft;
			rightEdges &= PaletteDrawBorders.TopBottomLeft;
			fillEdges &= PaletteDrawBorders.TopBottomLeft;
			break;
		}
	}
}
