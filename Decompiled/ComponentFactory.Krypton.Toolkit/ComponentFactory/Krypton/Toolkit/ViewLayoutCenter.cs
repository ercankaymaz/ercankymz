#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewLayoutCenter : ViewComposite
{
	private Padding _rectPadding;

	private IPaletteMetric _paletteMetric;

	private PaletteMetricPadding _metricPadding;

	private VisualOrientation _orientation;

	public PaletteMetricPadding MetricPadding
	{
		get
		{
			return _metricPadding;
		}
		set
		{
			_metricPadding = value;
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

	public ViewLayoutCenter()
		: this(null, PaletteMetricPadding.None, VisualOrientation.Top, null)
	{
	}

	public ViewLayoutCenter(ViewBase childElement)
		: this(null, PaletteMetricPadding.None, VisualOrientation.Top, childElement)
	{
	}

	public ViewLayoutCenter(IPaletteMetric paletteMetric, PaletteMetricPadding metricPadding, VisualOrientation orientation)
		: this(paletteMetric, metricPadding, orientation, null)
	{
	}

	public ViewLayoutCenter(IPaletteMetric paletteMetric, PaletteMetricPadding metricPadding, VisualOrientation orientation, ViewBase childElement)
	{
		_paletteMetric = paletteMetric;
		_metricPadding = metricPadding;
		_orientation = orientation;
		if (childElement != null)
		{
			Add(childElement);
		}
	}

	public ViewLayoutCenter(int size)
		: this(null, PaletteMetricPadding.None, VisualOrientation.Top, null)
	{
		_rectPadding = new Padding(size);
	}

	public override string ToString()
	{
		return "ViewLayoutCenter:" + base.Id;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		Size preferredSize = base.GetPreferredSize(context);
		if (_paletteMetric != null && _metricPadding != PaletteMetricPadding.None)
		{
			Padding metricPadding = _paletteMetric.GetMetricPadding(ElementState, _metricPadding);
			switch (Orientation)
			{
			case VisualOrientation.Top:
			case VisualOrientation.Bottom:
				preferredSize.Width += metricPadding.Horizontal;
				preferredSize.Height += metricPadding.Vertical;
				break;
			case VisualOrientation.Left:
			case VisualOrientation.Right:
				preferredSize.Width += metricPadding.Vertical;
				preferredSize.Height += metricPadding.Horizontal;
				break;
			}
		}
		_ = _rectPadding;
		if (true)
		{
			switch (Orientation)
			{
			case VisualOrientation.Top:
			case VisualOrientation.Bottom:
				preferredSize.Width += _rectPadding.Horizontal;
				preferredSize.Height += _rectPadding.Vertical;
				break;
			case VisualOrientation.Left:
			case VisualOrientation.Right:
				preferredSize.Width += _rectPadding.Vertical;
				preferredSize.Height += _rectPadding.Horizontal;
				break;
			}
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
		Rectangle displayRectangle = (ClientRectangle = context.DisplayRectangle);
		if (_paletteMetric != null && _metricPadding != PaletteMetricPadding.None)
		{
			Padding metricPadding = _paletteMetric.GetMetricPadding(ElementState, _metricPadding);
			switch (Orientation)
			{
			case VisualOrientation.Top:
				ClientRectangle = new Rectangle(ClientLocation.X + metricPadding.Left, ClientLocation.Y + metricPadding.Top, ClientWidth - metricPadding.Horizontal, ClientHeight - metricPadding.Vertical);
				break;
			case VisualOrientation.Bottom:
				ClientRectangle = new Rectangle(ClientLocation.X + metricPadding.Right, ClientLocation.Y + metricPadding.Bottom, ClientWidth - metricPadding.Horizontal, ClientHeight - metricPadding.Vertical);
				break;
			case VisualOrientation.Left:
				ClientRectangle = new Rectangle(ClientLocation.X + metricPadding.Top, ClientLocation.Y + metricPadding.Right, ClientWidth - metricPadding.Vertical, ClientHeight - metricPadding.Horizontal);
				break;
			case VisualOrientation.Right:
				ClientRectangle = new Rectangle(ClientLocation.X + metricPadding.Bottom, ClientLocation.Y + metricPadding.Left, ClientWidth - metricPadding.Vertical, ClientHeight - metricPadding.Horizontal);
				break;
			}
		}
		_ = _rectPadding;
		if (true)
		{
			switch (Orientation)
			{
			case VisualOrientation.Top:
				ClientRectangle = new Rectangle(ClientLocation.X + _rectPadding.Left, ClientLocation.Y + _rectPadding.Top, ClientWidth - _rectPadding.Horizontal, ClientHeight - _rectPadding.Vertical);
				break;
			case VisualOrientation.Bottom:
				ClientRectangle = new Rectangle(ClientLocation.X + _rectPadding.Right, ClientLocation.Y + _rectPadding.Bottom, ClientWidth - _rectPadding.Horizontal, ClientHeight - _rectPadding.Vertical);
				break;
			case VisualOrientation.Left:
				ClientRectangle = new Rectangle(ClientLocation.X + _rectPadding.Top, ClientLocation.Y + _rectPadding.Right, ClientWidth - _rectPadding.Vertical, ClientHeight - _rectPadding.Horizontal);
				break;
			case VisualOrientation.Right:
				ClientRectangle = new Rectangle(ClientLocation.X + _rectPadding.Bottom, ClientLocation.Y + _rectPadding.Left, ClientWidth - _rectPadding.Vertical, ClientHeight - _rectPadding.Horizontal);
				break;
			}
		}
		using (IEnumerator<ViewBase> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ViewBase current = enumerator.Current;
				if (current.Visible)
				{
					Size preferredSize = current.GetPreferredSize(context);
					if (preferredSize.Width > ClientWidth)
					{
						preferredSize.Width = ClientWidth;
					}
					if (preferredSize.Height > ClientHeight)
					{
						preferredSize.Height = ClientHeight;
					}
					int num = (ClientWidth - preferredSize.Width) / 2;
					int num2 = (ClientHeight - preferredSize.Height) / 2;
					context.DisplayRectangle = new Rectangle(ClientRectangle.X + num, ClientRectangle.Y + num2, preferredSize.Width, preferredSize.Height);
					current.Layout(context);
				}
			}
		}
		context.DisplayRectangle = displayRectangle;
	}
}
