#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutScrollViewport : ViewLayoutDocker
{
	private ViewLayoutControl _viewControl;

	private ViewLayoutViewport _viewport;

	private ViewDrawScrollBar _scrollbarV;

	private ViewDrawScrollBar _scrollbarH;

	private ViewDrawBorderEdge _borderEdgeV;

	private ViewDrawBorderEdge _borderEdgeH;

	private NeedPaintHandler _needPaintDelegate;

	private bool _viewportVertical;

	public bool VerticalViewport
	{
		get
		{
			return _viewportVertical;
		}
		set
		{
			if (_viewportVertical != value)
			{
				_viewportVertical = value;
				Viewport.Orientation = ViewportOrientation(value);
			}
		}
	}

	public bool AnimateChange
	{
		get
		{
			return Viewport.AnimateChange;
		}
		set
		{
			Viewport.AnimateChange = value;
		}
	}

	public ViewLayoutControl ViewControl
	{
		[DebuggerStepThrough]
		get
		{
			return _viewControl;
		}
	}

	public ViewLayoutViewport Viewport
	{
		[DebuggerStepThrough]
		get
		{
			return _viewport;
		}
	}

	public ViewDrawScrollBar ScrollbarV
	{
		[DebuggerStepThrough]
		get
		{
			return _scrollbarV;
		}
	}

	public ViewDrawScrollBar ScrollbarH
	{
		[DebuggerStepThrough]
		get
		{
			return _scrollbarH;
		}
	}

	public ViewDrawBorderEdge BorderEdgeV
	{
		[DebuggerStepThrough]
		get
		{
			return _borderEdgeV;
		}
	}

	public ViewDrawBorderEdge BorderEdgeH
	{
		[DebuggerStepThrough]
		get
		{
			return _borderEdgeH;
		}
	}

	public event EventHandler AnimateStep;

	public ViewLayoutScrollViewport(VisualControl rootControl, ViewBase viewportFiller, PaletteBorderEdge paletteBorderEdge, IPaletteMetric paletteMetrics, PaletteMetricPadding metricPadding, PaletteMetricInt metricOvers, VisualOrientation orientation, RelativePositionAlign alignment, bool animateChange, bool vertical, NeedPaintHandler needPaintDelegate)
	{
		Debug.Assert(rootControl != null);
		Debug.Assert(viewportFiller != null);
		Debug.Assert(needPaintDelegate != null);
		_needPaintDelegate = needPaintDelegate;
		_viewportVertical = vertical;
		base.Orientation = orientation;
		_viewport = new ViewLayoutViewport(paletteMetrics, metricPadding, metricOvers, ViewportOrientation(_viewportVertical), alignment, animateChange);
		_viewport.CounterAlignment = alignment;
		_viewport.FillSpace = true;
		_viewport.Add(viewportFiller);
		_viewport.AnimateStep += OnAnimateStep;
		_viewControl = new ViewLayoutControl(rootControl, _viewport);
		_viewControl.InDesignMode = rootControl.InDesignMode;
		_scrollbarV = new ViewDrawScrollBar(vertical: true);
		_scrollbarH = new ViewDrawScrollBar(vertical: false);
		_borderEdgeV = new ViewDrawBorderEdge(paletteBorderEdge, System.Windows.Forms.Orientation.Vertical);
		_borderEdgeH = new ViewDrawBorderEdge(paletteBorderEdge, System.Windows.Forms.Orientation.Horizontal);
		_scrollbarV.ScrollChanged += OnScrollVChanged;
		_scrollbarH.ScrollChanged += OnScrollHChanged;
		Add(_viewControl, ViewDockStyle.Fill);
		Add(_borderEdgeV, ViewDockStyle.Right);
		Add(_borderEdgeH, ViewDockStyle.Bottom);
		Add(_scrollbarV, ViewDockStyle.Right);
		Add(_scrollbarH, ViewDockStyle.Bottom);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			Viewport.AnimateStep -= OnAnimateStep;
			ScrollbarV.ScrollChanged -= OnScrollVChanged;
			ScrollbarH.ScrollChanged -= OnScrollHChanged;
		}
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewLayoutScrollViewport:" + base.Id;
	}

	public void MakeParent(Control c)
	{
		ViewControl.MakeParent(c);
	}

	public void RevertParent(Control newParent, Control c)
	{
		CommonHelper.RemoveControlFromParent(c);
		CommonHelper.AddControlToParent(newParent, c);
	}

	public void SetPalettes(PaletteBorderEdge borderEdge)
	{
		BorderEdgeV.SetPalettes(borderEdge);
		BorderEdgeH.SetPalettes(borderEdge);
	}

	public void BringIntoView(Rectangle rect)
	{
		if (VerticalViewport)
		{
			rect.Width = Viewport.ClientWidth;
		}
		else
		{
			rect.Height = Viewport.ClientHeight;
		}
		Viewport.BringIntoView(rect);
	}

	public override void Layout(ViewLayoutContext context)
	{
		ViewControl.Enabled = Enabled;
		ScrollbarV.Enabled = Enabled;
		ScrollbarH.Enabled = Enabled;
		BorderEdgeV.Enabled = Enabled;
		BorderEdgeH.Enabled = Enabled;
		Point offset = Viewport.Offset;
		ViewDrawBorderEdge borderEdgeV = BorderEdgeV;
		bool visible = (ScrollbarV.Visible = false);
		borderEdgeV.Visible = visible;
		ViewDrawBorderEdge borderEdgeH = BorderEdgeH;
		visible = (ScrollbarH.Visible = false);
		borderEdgeH.Visible = visible;
		context.ViewManager.DoNotLayoutControls = true;
		bool flag3;
		bool canScrollV;
		bool canScrollH;
		do
		{
			flag3 = false;
			Viewport.Offset = offset;
			Viewport.GetPreferredSize(context);
			base.Layout(context);
			canScrollV = Viewport.CanScrollV;
			canScrollH = Viewport.CanScrollH;
			if (canScrollV != ScrollbarV.Visible)
			{
				ScrollbarV.Visible = canScrollV;
				BorderEdgeV.Visible = canScrollV;
				flag3 = true;
			}
			if (canScrollH != ScrollbarH.Visible)
			{
				ScrollbarH.Visible = canScrollH;
				BorderEdgeH.Visible = canScrollH;
				flag3 = true;
			}
			bool flag4 = ScrollbarV.Visible && ScrollbarH.Visible;
			if (ScrollbarH.ShortSize != flag4)
			{
				ScrollbarH.ShortSize = flag4;
				flag3 = true;
			}
		}
		while (flag3);
		context.ViewManager.DoNotLayoutControls = false;
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				context.DisplayRectangle = current.ClientRectangle;
				current.Layout(context);
			}
		}
		if (canScrollV)
		{
			ScrollbarV.SetScrollValues(0, Viewport.ScrollExtent.Height - 1, 1, Viewport.ClientSize.Height, Viewport.ScrollOffset.Y);
		}
		if (canScrollH)
		{
			ScrollbarH.SetScrollValues(0, Viewport.ScrollExtent.Width - 1, 1, Viewport.ClientSize.Width, Viewport.ScrollOffset.X);
		}
	}

	protected void DockerLayout(ViewLayoutContext context)
	{
		base.Layout(context);
	}

	protected void NeedPaint(bool needLayout)
	{
		if (_needPaintDelegate != null)
		{
			_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout));
		}
	}

	private VisualOrientation ViewportOrientation(bool vertical)
	{
		if (vertical)
		{
			return VisualOrientation.Left;
		}
		return VisualOrientation.Top;
	}

	private void OnScrollVChanged(object sender, EventArgs e)
	{
		Viewport.SetOffsetV(ScrollbarV.ScrollPosition);
		if (_needPaintDelegate != null)
		{
			NeedPaint(needLayout: true);
			ViewControl.ChildControl.Refresh();
		}
	}

	private void OnScrollHChanged(object sender, EventArgs e)
	{
		Viewport.SetOffsetH(ScrollbarH.ScrollPosition);
		if (_needPaintDelegate != null)
		{
			NeedPaint(needLayout: true);
			ViewControl.ChildControl.Refresh();
		}
	}

	private void OnAnimateStep(object sender, EventArgs e)
	{
		if (this.AnimateStep != null)
		{
			this.AnimateStep(sender, e);
		}
	}
}
