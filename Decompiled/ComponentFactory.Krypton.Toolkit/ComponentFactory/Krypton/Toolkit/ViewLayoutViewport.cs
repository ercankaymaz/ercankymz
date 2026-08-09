#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutViewport : ViewComposite
{
	private const float _scrollPercentage = 0.66f;

	private const int _scrollMinimum = 3;

	private const int _scrollOvers = 15;

	private const int _animationInterval = 22;

	private const int _animationMinimum = 8;

	private Timer _animationTimer;

	private IPaletteMetric _paletteMetrics;

	private PaletteMetricPadding _metricPadding;

	private PaletteMetricInt _metricOvers;

	private VisualOrientation _orientation;

	private RelativePositionAlign _alignment;

	private RelativePositionAlign _counterAlignment;

	private RightToLeft _rightToLeft;

	private bool _rightToLeftLayout;

	private bool _fillSpace;

	private bool _animateChange;

	private Point _offset;

	private Point _limit;

	private Size _extent;

	private Point _animationOffset;

	public bool AnimateChange
	{
		[DebuggerStepThrough]
		get
		{
			return _animateChange;
		}
		set
		{
			_animateChange = value;
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

	public RelativePositionAlign Alignment
	{
		[DebuggerStepThrough]
		get
		{
			return _alignment;
		}
		set
		{
			_alignment = value;
		}
	}

	public RelativePositionAlign CounterAlignment
	{
		[DebuggerStepThrough]
		get
		{
			return _counterAlignment;
		}
		set
		{
			_counterAlignment = value;
		}
	}

	public bool FillSpace
	{
		[DebuggerStepThrough]
		get
		{
			return _fillSpace;
		}
		set
		{
			_fillSpace = value;
		}
	}

	public Point Offset
	{
		[DebuggerStepThrough]
		get
		{
			return _offset;
		}
		set
		{
			_offset = value;
		}
	}

	public bool CanScrollV
	{
		[DebuggerStepThrough]
		get
		{
			return _limit.Y != 0;
		}
	}

	public bool CanScrollH
	{
		[DebuggerStepThrough]
		get
		{
			return _limit.X != 0;
		}
	}

	public Size ScrollExtent => new Size(Math.Abs(_extent.Width), Math.Abs(_extent.Height));

	public Point ScrollOffset => new Point(Math.Abs(_offset.X), Math.Abs(_offset.Y));

	public bool CanScrollNext
	{
		get
		{
			int num = 0;
			int num2 = 0;
			switch (Orientation)
			{
			case VisualOrientation.Top:
			case VisualOrientation.Bottom:
				num = _limit.X;
				num2 = _offset.X;
				break;
			case VisualOrientation.Left:
			case VisualOrientation.Right:
				num = _limit.Y;
				num2 = _offset.Y;
				break;
			}
			switch (AlignmentRTL)
			{
			case RelativePositionAlign.Near:
			case RelativePositionAlign.Center:
				return num2 > num;
			case RelativePositionAlign.Far:
				return num2 < 0;
			default:
				Debug.Assert(condition: false);
				return false;
			}
		}
	}

	public bool CanScrollPrevious
	{
		get
		{
			int num = 0;
			int num2 = 0;
			switch (Orientation)
			{
			case VisualOrientation.Top:
			case VisualOrientation.Bottom:
				num = _limit.X;
				num2 = _offset.X;
				break;
			case VisualOrientation.Left:
			case VisualOrientation.Right:
				num = _limit.Y;
				num2 = _offset.Y;
				break;
			}
			switch (AlignmentRTL)
			{
			case RelativePositionAlign.Near:
			case RelativePositionAlign.Center:
				return num2 < 0;
			case RelativePositionAlign.Far:
				return num2 > num;
			default:
				Debug.Assert(condition: false);
				return false;
			}
		}
	}

	public bool NeedScrolling => CanScrollNext || CanScrollPrevious;

	private bool Horizontal => Orientation == VisualOrientation.Top || Orientation == VisualOrientation.Bottom;

	private RelativePositionAlign AlignmentRTL
	{
		get
		{
			if (Horizontal && _rightToLeft == RightToLeft.Yes)
			{
				switch (Alignment)
				{
				case RelativePositionAlign.Near:
					return RelativePositionAlign.Far;
				case RelativePositionAlign.Far:
					return RelativePositionAlign.Near;
				}
			}
			return Alignment;
		}
	}

	private RelativePositionAlign CounterAlignmentRTL
	{
		get
		{
			if (!Horizontal && _rightToLeft == RightToLeft.Yes && _rightToLeftLayout)
			{
				switch (CounterAlignment)
				{
				case RelativePositionAlign.Near:
					return RelativePositionAlign.Far;
				case RelativePositionAlign.Far:
					return RelativePositionAlign.Near;
				}
			}
			return CounterAlignment;
		}
	}

	public event EventHandler AnimateStep;

	public ViewLayoutViewport(IPaletteMetric paletteMetrics, PaletteMetricPadding metricPadding, PaletteMetricInt metricOvers, VisualOrientation orientation, RelativePositionAlign alignment, bool animateChange)
	{
		_paletteMetrics = paletteMetrics;
		_metricPadding = metricPadding;
		_metricOvers = metricOvers;
		_orientation = orientation;
		_alignment = alignment;
		_animateChange = animateChange;
		_offset = Point.Empty;
		_extent = Size.Empty;
		_rightToLeft = RightToLeft.No;
		_rightToLeftLayout = false;
		_fillSpace = false;
		_counterAlignment = RelativePositionAlign.Far;
		_animationTimer = new Timer();
		_animationTimer.Interval = 22;
		_animationTimer.Tick += OnAnimationTick;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_animationTimer.Stop();
			_animationTimer.Dispose();
		}
		base.Dispose(disposing);
	}

	public override string ToString()
	{
		return "ViewLayoutViewport:" + base.Id;
	}

	public void SetMetrics(IPaletteMetric paletteMetric)
	{
		_paletteMetrics = paletteMetric;
	}

	public void SetMetrics(IPaletteMetric paletteMetric, PaletteMetricPadding metricPadding, PaletteMetricInt metricOvers)
	{
		_paletteMetrics = paletteMetric;
		_metricPadding = metricPadding;
		_metricOvers = metricOvers;
	}

	public void SetOffsetV(int offset)
	{
		switch (AlignmentRTL)
		{
		case RelativePositionAlign.Near:
		case RelativePositionAlign.Center:
			_offset.Y = -offset;
			break;
		case RelativePositionAlign.Far:
			_offset.Y = offset;
			break;
		}
	}

	public void SetOffsetH(int offset)
	{
		switch (AlignmentRTL)
		{
		case RelativePositionAlign.Near:
		case RelativePositionAlign.Center:
			_offset.X = -offset;
			break;
		case RelativePositionAlign.Far:
			_offset.X = offset;
			break;
		}
	}

	public void MoveNext()
	{
		MoveDirection(next: true);
	}

	public void MovePrevious()
	{
		MoveDirection(next: false);
	}

	public void BringIntoView(Rectangle rect)
	{
		Point point = OffsetForChildRect(rect);
		if (!_animateChange || _offset.Equals(point))
		{
			_animationTimer.Stop();
			_offset = point;
		}
		else
		{
			_animationTimer.Stop();
			_animationOffset = point;
			_animationTimer.Start();
		}
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Rectangle displayRectangle = context.DisplayRectangle;
		if (_paletteMetrics != null)
		{
			context.DisplayRectangle = CommonHelper.ApplyPadding(Orientation, displayRectangle, _paletteMetrics.GetMetricPadding(State, _metricPadding));
		}
		_extent = base.GetPreferredSize(context);
		if (_paletteMetrics == null)
		{
			return _extent;
		}
		context.DisplayRectangle = displayRectangle;
		return CommonHelper.ApplyPadding(Orientation, _extent, _paletteMetrics.GetMetricPadding(State, _metricPadding));
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		_rightToLeft = context.Control.RightToLeft;
		_rightToLeftLayout = CommonHelper.GetRightToLeftLayout(context.Control);
		ClientRectangle = context.DisplayRectangle;
		Rectangle rectangle = ClientRectangle;
		if (_paletteMetrics != null)
		{
			Padding metricPadding = _paletteMetrics.GetMetricPadding(State, _metricPadding);
			rectangle = ApplyPadding(rectangle, metricPadding);
		}
		if (FillSpace)
		{
			if (_extent.Width < rectangle.Width)
			{
				_extent.Width = rectangle.Width;
			}
			if (_extent.Height < rectangle.Height)
			{
				_extent.Height = rectangle.Height;
			}
		}
		_limit = new Point(Math.Min(rectangle.Width - _extent.Width, 0), Math.Min(rectangle.Height - _extent.Height, 0));
		if (_offset.X < _limit.X)
		{
			_offset.X = _limit.X;
		}
		if (_offset.Y < _limit.Y)
		{
			_offset.Y = _limit.Y;
		}
		int x;
		int y;
		if (Horizontal)
		{
			x = CalculateAlignedOffset(AlignmentRTL, rectangle.X, rectangle.Width, _offset.X, _extent.Width, _limit.X);
			y = CalculateAlignedOffset(CounterAlignmentRTL, rectangle.Y, rectangle.Height, _offset.Y, _extent.Height, _limit.Y);
		}
		else
		{
			x = CalculateAlignedOffset(CounterAlignmentRTL, rectangle.X, rectangle.Width, _offset.X, _extent.Width, _limit.X);
			y = CalculateAlignedOffset(AlignmentRTL, rectangle.Y, rectangle.Height, _offset.Y, _extent.Height, _limit.Y);
		}
		Point location = new Point(x, y);
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (!current.Visible)
				{
					continue;
				}
				context.DisplayRectangle = rectangle;
				Size preferredSize = current.GetPreferredSize(context);
				if (FillSpace)
				{
					if (preferredSize.Width < rectangle.Width)
					{
						preferredSize.Width = rectangle.Width;
					}
					if (preferredSize.Height < rectangle.Height)
					{
						preferredSize.Height = rectangle.Height;
					}
				}
				context.DisplayRectangle = new Rectangle(location, preferredSize);
				current.Layout(context);
			}
		}
		context.DisplayRectangle = ClientRectangle;
	}

	public override void Render(RenderContext context)
	{
		Rectangle rect = ClientRectangle;
		if (_paletteMetrics != null)
		{
			Padding metricPadding = _paletteMetrics.GetMetricPadding(State, _metricPadding);
			rect = ApplyPadding(rect, metricPadding);
		}
		using Region region = new Region(rect);
		Region region2 = context.Graphics.Clip.Clone();
		region.Intersect(region2);
		context.Graphics.Clip = region;
		RenderBefore(context);
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					current.Render(context);
				}
			}
		}
		RenderAfter(context);
		context.Graphics.Clip = region2;
	}

	private int CalculateAlignedOffset(RelativePositionAlign alignment, int posRect, int posRectLength, int offset, int extent, int limit)
	{
		switch (alignment)
		{
		case RelativePositionAlign.Near:
			return posRect + offset;
		case RelativePositionAlign.Center:
			if (limit == 0)
			{
				return posRect + (posRectLength - extent) / 2;
			}
			return posRect + offset;
		case RelativePositionAlign.Far:
			return posRect + posRectLength - extent - offset;
		default:
			Debug.Assert(condition: false);
			return 0;
		}
	}

	private Rectangle ApplyPadding(Rectangle rect, Padding padding)
	{
		if (!padding.Equals(CommonHelper.InheritPadding))
		{
			VisualOrientation visualOrientation = Orientation;
			if (_rightToLeftLayout && _rightToLeft == RightToLeft.Yes)
			{
				switch (visualOrientation)
				{
				case VisualOrientation.Left:
					visualOrientation = VisualOrientation.Right;
					break;
				case VisualOrientation.Right:
					visualOrientation = VisualOrientation.Left;
					break;
				}
			}
			switch (visualOrientation)
			{
			case VisualOrientation.Top:
				rect = new Rectangle(rect.X + padding.Left, rect.Y + padding.Top, rect.Width - padding.Horizontal, rect.Height - padding.Vertical);
				break;
			case VisualOrientation.Bottom:
				rect = new Rectangle(rect.X + padding.Left, rect.Y + padding.Bottom, rect.Width - padding.Horizontal, rect.Height - padding.Vertical);
				break;
			case VisualOrientation.Left:
				rect = new Rectangle(rect.X + padding.Top, rect.Y + padding.Left, rect.Width - padding.Vertical, rect.Height - padding.Horizontal);
				break;
			case VisualOrientation.Right:
				rect = new Rectangle(rect.X + padding.Bottom, rect.Y + padding.Left, rect.Width - padding.Vertical, rect.Height - padding.Horizontal);
				break;
			default:
				Debug.Assert(condition: false);
				break;
			}
		}
		return rect;
	}

	private void MoveDirection(bool next)
	{
		Point offset = _offset;
		if (Orientation == VisualOrientation.Top || Orientation == VisualOrientation.Bottom)
		{
			int num = Math.Max((int)((float)ClientSize.Width * 0.66f), 3);
			switch (AlignmentRTL)
			{
			case RelativePositionAlign.Near:
			case RelativePositionAlign.Center:
				if (next)
				{
					offset.X -= num;
				}
				else
				{
					offset.X += num;
				}
				break;
			case RelativePositionAlign.Far:
				if (next)
				{
					offset.X += num;
				}
				else
				{
					offset.X -= num;
				}
				break;
			}
		}
		else
		{
			int num2 = Math.Max((int)((float)ClientSize.Height * 0.66f), 3);
			switch (AlignmentRTL)
			{
			case RelativePositionAlign.Near:
			case RelativePositionAlign.Center:
				if (next)
				{
					offset.Y -= num2;
				}
				else
				{
					offset.Y += num2;
				}
				break;
			case RelativePositionAlign.Far:
				if (next)
				{
					offset.Y += num2;
				}
				else
				{
					offset.Y -= num2;
				}
				break;
			}
		}
		offset.X = Math.Min(Math.Max(offset.X, _limit.X), 0);
		offset.Y = Math.Min(Math.Max(offset.Y, _limit.Y), 0);
		if (!_animateChange || _offset.Equals(offset))
		{
			_offset = offset;
			return;
		}
		_animationTimer.Stop();
		_animationOffset = offset;
		_animationTimer.Start();
	}

	private Point OffsetForChildRect(Rectangle rect)
	{
		Point offset = _offset;
		int num = 0;
		if (_paletteMetrics != null)
		{
			num = _paletteMetrics.GetMetricInt(State, _metricOvers) + 15;
		}
		if (Orientation == VisualOrientation.Top || Orientation == VisualOrientation.Bottom)
		{
			rect.X -= num;
			rect.Width += num * 2;
		}
		else
		{
			rect.Y -= num;
			rect.Height += num * 2;
		}
		if ((_limit.X != 0 || _limit.Y != 0) && !ClientRectangle.Contains(rect))
		{
			RelativePositionAlign relativePositionAlign = AlignmentRTL;
			if (relativePositionAlign == RelativePositionAlign.Center)
			{
				relativePositionAlign = RelativePositionAlign.Near;
			}
			switch (relativePositionAlign)
			{
			case RelativePositionAlign.Near:
				if (rect.Right > ClientRectangle.Right)
				{
					offset.X += ClientRectangle.Right - rect.Right;
				}
				if (rect.Left < ClientRectangle.Left)
				{
					offset.X += ClientRectangle.Left - rect.Left;
				}
				if (rect.Bottom > ClientRectangle.Bottom)
				{
					offset.Y += ClientRectangle.Bottom - rect.Bottom;
				}
				if (rect.Top < ClientRectangle.Top)
				{
					offset.Y += ClientRectangle.Top - rect.Top;
				}
				break;
			case RelativePositionAlign.Far:
				if (rect.Right > ClientRectangle.Right)
				{
					offset.X -= ClientRectangle.Right - rect.Right;
				}
				if (rect.Left < ClientRectangle.Left)
				{
					offset.X -= ClientRectangle.Left - rect.Left;
				}
				if (rect.Bottom > ClientRectangle.Bottom)
				{
					offset.Y -= ClientRectangle.Bottom - rect.Bottom;
				}
				if (rect.Top < ClientRectangle.Top)
				{
					offset.Y -= ClientRectangle.Top - rect.Top;
				}
				break;
			}
		}
		offset.X = Math.Min(Math.Max(offset.X, _limit.X), 0);
		offset.Y = Math.Min(Math.Max(offset.Y, _limit.Y), 0);
		return offset;
	}

	private void OnAnimationTick(object sender, EventArgs e)
	{
		_animationOffset.X = Math.Min(Math.Max(_animationOffset.X, _limit.X), 0);
		_animationOffset.Y = Math.Min(Math.Max(_animationOffset.Y, _limit.Y), 0);
		int val = (_animationOffset.X - _offset.X) / 2;
		int val2 = (_animationOffset.Y - _offset.Y) / 2;
		if (_animationOffset.X < _offset.X)
		{
			val = Math.Min(val, -8);
			_offset.X = Math.Max(_animationOffset.X, _offset.X + val);
		}
		else
		{
			val = Math.Max(val, 8);
			_offset.X = Math.Min(_animationOffset.X, _offset.X + val);
		}
		if (_animationOffset.Y < _offset.Y)
		{
			val2 = Math.Min(val2, -8);
			_offset.Y = Math.Max(_animationOffset.Y, _offset.Y + val2);
		}
		else
		{
			val2 = Math.Max(val2, 8);
			_offset.Y = Math.Min(_animationOffset.Y, _offset.Y + val2);
		}
		if (_offset.X == _animationOffset.X && _offset.Y == _animationOffset.Y)
		{
			_animationTimer.Stop();
		}
		_offset.X = Math.Min(Math.Max(_offset.X, _limit.X), 0);
		_offset.Y = Math.Min(Math.Max(_offset.Y, _limit.Y), 0);
		if (this.AnimateStep != null)
		{
			this.AnimateStep(this, EventArgs.Empty);
		}
	}
}
