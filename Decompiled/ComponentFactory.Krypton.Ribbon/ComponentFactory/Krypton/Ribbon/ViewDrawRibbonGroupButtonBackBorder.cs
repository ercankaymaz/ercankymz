#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupButtonBackBorder : ViewComposite
{
	private static readonly Size _viewSize = new Size(22, 22);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupItem _groupItem;

	private GroupButtonController _controller;

	private EventHandler _finishDelegate;

	private IDisposable _mementoBack;

	private IPaletteBack _paletteBack;

	private PaletteBackInheritForced _paletteBackDraw;

	private PaletteBackLightenColors _paletteBackLight;

	private IPaletteBorder _paletteBorder;

	private PaletteBorderInheritForced _paletteBorderAll;

	private bool _splitVertical;

	private bool _constantBorder;

	private bool _drawNonTrackingAreas;

	private bool _checked;

	public KryptonRibbonGroupItem GroupItem => _groupItem;

	public GroupButtonController Controller => _controller;

	public bool SplitVertical
	{
		get
		{
			return _splitVertical;
		}
		set
		{
			_splitVertical = value;
		}
	}

	public Rectangle SplitRectangle
	{
		get
		{
			return _controller.SplitRectangle;
		}
		set
		{
			_controller.SplitRectangle = value;
		}
	}

	public GroupButtonType ButtonType
	{
		get
		{
			return _controller.ButtonType;
		}
		set
		{
			_controller.ButtonType = value;
		}
	}

	public bool Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			_checked = value;
		}
	}

	public bool ConstantBorder
	{
		get
		{
			return _constantBorder;
		}
		set
		{
			_constantBorder = value;
		}
	}

	public bool DrawNonTrackingAreas
	{
		get
		{
			return _drawNonTrackingAreas;
		}
		set
		{
			_drawNonTrackingAreas = value;
		}
	}

	public EventHandler FinishDelegate => _finishDelegate;

	public event EventHandler Click;

	public event MouseEventHandler ContextClick;

	public event EventHandler DropDown;

	public ViewDrawRibbonGroupButtonBackBorder(KryptonRibbon ribbon, KryptonRibbonGroupItem groupItem, IPaletteBack paletteBack, IPaletteBorder paletteBorder, bool constantBorder, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(groupItem != null);
		Debug.Assert(paletteBack != null);
		Debug.Assert(paletteBorder != null);
		_ribbon = ribbon;
		_groupItem = groupItem;
		_paletteBack = paletteBack;
		_paletteBackDraw = new PaletteBackInheritForced(paletteBack);
		_paletteBackDraw.ForceDraw = InheritBool.True;
		_paletteBackLight = new PaletteBackLightenColors(paletteBack);
		_paletteBorderAll = new PaletteBorderInheritForced(paletteBorder);
		_paletteBorderAll.ForceBorderEdges(PaletteDrawBorders.All);
		_paletteBorder = paletteBorder;
		_constantBorder = constantBorder;
		_checked = false;
		_drawNonTrackingAreas = true;
		_finishDelegate = ActionFinished;
		_controller = new GroupButtonController(_ribbon, this, needPaint);
		_controller.Click += OnClick;
		_controller.ContextClick += OnContextClick;
		_controller.DropDown += OnDropDown;
		MouseController = _controller;
		SourceController = _controller;
		KeyController = _controller;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupButtonBackBorder:" + base.Id;
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

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
	}

	public override void RenderBefore(RenderContext context)
	{
		PaletteState paletteState = State;
		if (paletteState == PaletteState.Disabled)
		{
			paletteState = PaletteState.Normal;
		}
		else if (Checked && ButtonType == GroupButtonType.Check)
		{
			switch (paletteState)
			{
			case PaletteState.Normal:
				paletteState = PaletteState.CheckedNormal;
				break;
			case PaletteState.Tracking:
				paletteState = PaletteState.CheckedTracking;
				break;
			case PaletteState.Pressed:
				paletteState = PaletteState.CheckedPressed;
				break;
			}
		}
		switch (ButtonType)
		{
		case GroupButtonType.Push:
		case GroupButtonType.Check:
		case GroupButtonType.DropDown:
			DrawBackground(_paletteBack, context, ClientRectangle, paletteState);
			if (_constantBorder)
			{
				DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Normal);
			}
			else
			{
				DrawBorder(_paletteBorder, context, ClientRectangle, paletteState);
			}
			break;
		case GroupButtonType.Split:
			if (_splitVertical)
			{
				DrawVerticalSplit(context, paletteState);
			}
			else
			{
				DrawHorizontalSplit(context, paletteState);
			}
			break;
		}
		base.RenderBefore(context);
	}

	private void DrawVerticalSplit(RenderContext context, PaletteState drawState)
	{
		int height = ClientHeight / 3 * 2;
		Rectangle rect = new Rectangle(ClientLocation, new Size(ClientWidth, height));
		Rectangle splitRectangle = _controller.SplitRectangle;
		Rectangle rect2 = new Rectangle(ClientLocation, new Size(ClientWidth, splitRectangle.Y - ClientLocation.Y));
		Rectangle rect3 = new Rectangle(splitRectangle.Location, new Size(ClientWidth, 1));
		Rectangle rect4 = new Rectangle(ClientLocation.X, splitRectangle.Y, ClientWidth, splitRectangle.Height);
		bool flag = SplitWithFading(drawState);
		switch (drawState)
		{
		case PaletteState.Normal:
			if (_constantBorder)
			{
				DrawBackground(_paletteBack, context, ClientRectangle, PaletteState.Normal);
				DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Normal);
			}
			break;
		case PaletteState.Tracking:
			if (_controller.MouseInSplit)
			{
				using (new Clipping(context.Graphics, rect4))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
				using (new Clipping(rect: new Rectangle(rect4.X, rect4.Y + 1, rect4.Width, rect4.Height - 1), graphics: context.Graphics))
				{
					DrawBackground(_paletteBack, context, ClientRectangle, PaletteState.Tracking);
				}
				using (new Clipping(context.Graphics, rect2))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, rect, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, rect, PaletteState.Normal);
					}
				}
			}
			else
			{
				using (new Clipping(context.Graphics, rect2))
				{
					DrawBackground(_paletteBack, context, rect, PaletteState.Tracking);
				}
				using (new Clipping(context.Graphics, rect4))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
			}
			using (new Clipping(context.Graphics, rect3))
			{
				DrawBorder(_paletteBorderAll, context, new Rectangle(splitRectangle.X, splitRectangle.Y, splitRectangle.Width, 2), PaletteState.Tracking);
			}
			DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Tracking);
			break;
		case PaletteState.Pressed:
			if (_controller.MouseInSplit)
			{
				using (new Clipping(context.Graphics, rect4))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Pressed);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
				using (new Clipping(rect: new Rectangle(rect4.X, rect4.Y + 1, rect4.Width, rect4.Height - 1), graphics: context.Graphics))
				{
					DrawBackground(_paletteBack, context, ClientRectangle, PaletteState.Pressed);
				}
				using (new Clipping(context.Graphics, rect2))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, rect, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, rect, PaletteState.Normal);
					}
				}
			}
			else
			{
				using (new Clipping(context.Graphics, rect2))
				{
					DrawBackground(_paletteBack, context, rect, PaletteState.Pressed);
				}
				using (new Clipping(context.Graphics, rect4))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
			}
			DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Tracking);
			using (new Clipping(context.Graphics, rect3))
			{
				DrawBorder(_paletteBorderAll, context, new Rectangle(splitRectangle.X, splitRectangle.Y, splitRectangle.Width, 2), PaletteState.Pressed);
			}
			if (_controller.MouseInSplit)
			{
				using (new Clipping(context.Graphics, rect4))
				{
					DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Pressed);
					break;
				}
			}
			using (new Clipping(context.Graphics, rect2))
			{
				DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Pressed);
				break;
			}
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	private void DrawHorizontalSplit(RenderContext context, PaletteState drawState)
	{
		int num = ClientWidth / 3 * 2;
		Rectangle splitRectangle = _controller.SplitRectangle;
		Rectangle rect = new Rectangle(ClientLocation, new Size(splitRectangle.X - ClientLocation.X, ClientHeight));
		Rectangle rect2 = new Rectangle(splitRectangle.Location, new Size(1, ClientHeight));
		Rectangle rect3 = new Rectangle(splitRectangle.X, ClientLocation.Y, splitRectangle.Width, ClientHeight);
		bool flag = SplitWithFading(drawState);
		switch (drawState)
		{
		case PaletteState.Normal:
			if (_constantBorder)
			{
				DrawBackground(_paletteBack, context, ClientRectangle, PaletteState.Normal);
				DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Normal);
			}
			break;
		case PaletteState.Tracking:
			if (_controller.MouseInSplit)
			{
				using (new Clipping(context.Graphics, rect3))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
				using (new Clipping(rect: new Rectangle(rect3.X + 1, rect3.Y, rect3.Width - 1, rect3.Height), graphics: context.Graphics))
				{
					DrawBackground(_paletteBack, context, ClientRectangle, PaletteState.Tracking);
				}
				using (new Clipping(context.Graphics, rect))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
			}
			else
			{
				using (new Clipping(context.Graphics, rect))
				{
					DrawBackground(_paletteBack, context, ClientRectangle, PaletteState.Tracking);
				}
				using (new Clipping(context.Graphics, rect3))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
			}
			using (new Clipping(context.Graphics, rect2))
			{
				DrawBorder(_paletteBorderAll, context, new Rectangle(splitRectangle.X, splitRectangle.Y, 2, splitRectangle.Height), PaletteState.Tracking);
			}
			if (_constantBorder)
			{
				DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Normal);
			}
			if (!_constantBorder)
			{
				DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Tracking);
			}
			break;
		case PaletteState.Pressed:
			if (_controller.MouseInSplit)
			{
				using (new Clipping(context.Graphics, rect3))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Pressed);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
				using (new Clipping(rect: new Rectangle(rect3.X + 1, rect3.Y, rect3.Width - 1, rect3.Height), graphics: context.Graphics))
				{
					DrawBackground(_paletteBack, context, ClientRectangle, PaletteState.Pressed);
				}
				using (new Clipping(context.Graphics, rect))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
			}
			else
			{
				using (new Clipping(context.Graphics, rect))
				{
					DrawBackground(_paletteBack, context, ClientRectangle, PaletteState.Pressed);
				}
				using (new Clipping(context.Graphics, rect3))
				{
					if (flag)
					{
						if (_drawNonTrackingAreas)
						{
							DrawBackground(_paletteBackLight, context, ClientRectangle, PaletteState.Tracking);
						}
					}
					else
					{
						DrawBackground(_paletteBackDraw, context, ClientRectangle, PaletteState.Normal);
					}
				}
			}
			using (new Clipping(context.Graphics, rect2))
			{
				DrawBorder(_paletteBorderAll, context, new Rectangle(splitRectangle.X, splitRectangle.Y, 2, splitRectangle.Height), PaletteState.Pressed);
			}
			if (_constantBorder)
			{
				DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Normal);
			}
			if (_constantBorder)
			{
				break;
			}
			DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Tracking);
			if (_controller.MouseInSplit)
			{
				using (new Clipping(context.Graphics, rect3))
				{
					DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Pressed);
					break;
				}
			}
			using (new Clipping(context.Graphics, rect))
			{
				DrawBorder(_paletteBorder, context, ClientRectangle, PaletteState.Pressed);
				break;
			}
		default:
			Debug.Assert(condition: false);
			break;
		}
	}

	private void DrawBackground(IPaletteBack paletteBack, RenderContext context, Rectangle rect, PaletteState state)
	{
		if (paletteBack.GetBackDraw(state) == InheritBool.True)
		{
			using (GraphicsPath path = context.Renderer.RenderStandardBorder.GetBackPath(context, rect, _paletteBorder, VisualOrientation.Top, state))
			{
				Padding borderRawPadding = context.Renderer.RenderStandardBorder.GetBorderRawPadding(_paletteBorder, state, VisualOrientation.Top);
				Rectangle rect2 = CommonHelper.ApplyPadding(VisualOrientation.Top, rect, borderRawPadding);
				_mementoBack = context.Renderer.RenderStandardBack.DrawBack(context, rect2, path, paletteBack, VisualOrientation.Top, state, _mementoBack);
			}
		}
	}

	private void DrawBorder(IPaletteBorder paletteBorder, RenderContext context, Rectangle rect, PaletteState state)
	{
		if (paletteBorder.GetBorderDraw(state) == InheritBool.True)
		{
			context.Renderer.RenderStandardBorder.DrawBorder(context, rect, paletteBorder, VisualOrientation.Top, state);
		}
	}

	private bool SplitWithFading(PaletteState drawState)
	{
		IPalette redirector = _ribbon.GetRedirector();
		return redirector.GetMetricBool(drawState, PaletteMetricBool.SplitWithFading) == InheritBool.True;
	}

	private void ActionFinished(object sender, EventArgs e)
	{
		bool flag = true;
		if (e is ToolStripDropDownClosedEventArgs)
		{
			ToolStripDropDownClosedEventArgs e2 = (ToolStripDropDownClosedEventArgs)e;
			if (e2.CloseReason != ToolStripDropDownCloseReason.ItemClicked)
			{
				flag = false;
			}
		}
		if (_ribbon != null && flag)
		{
			_ribbon.ActionOccured();
		}
		_controller.RemoveFixed();
	}

	private void OnClick(object sender, EventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		if (this.ContextClick != null)
		{
			this.ContextClick(this, e);
		}
	}

	private void OnDropDown(object sender, EventArgs e)
	{
		if (this.DropDown != null)
		{
			this.DropDown(this, e);
		}
	}
}
