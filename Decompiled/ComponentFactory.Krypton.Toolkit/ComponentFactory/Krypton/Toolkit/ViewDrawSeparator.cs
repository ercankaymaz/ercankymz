#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawSeparator : ViewLeaf
{
	internal IPaletteDouble _paletteDisabled;

	internal IPaletteDouble _paletteNormal;

	internal IPaletteDouble _paletteTracking;

	internal IPaletteDouble _palettePressed;

	internal IPaletteMetric _metricDisabled;

	internal IPaletteMetric _metricNormal;

	internal IPaletteMetric _metricTracking;

	internal IPaletteMetric _metricPressed;

	internal IPaletteDouble _palette;

	internal IPaletteMetric _metric;

	private ISeparatorSource _source;

	private PaletteMetricPadding _metricPadding;

	private Orientation _orientation;

	private int _length;

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

	public ISeparatorSource Source
	{
		get
		{
			return _source;
		}
		set
		{
			_source = value;
		}
	}

	public Orientation Orientation
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

	public int Length
	{
		get
		{
			return _length;
		}
		set
		{
			_length = value;
		}
	}

	public ViewDrawSeparator(IPaletteDouble paletteDisabled, IPaletteDouble paletteNormal, IPaletteDouble paletteTracking, IPaletteDouble palettePressed, IPaletteMetric metricDisabled, IPaletteMetric metricNormal, IPaletteMetric metricTracking, IPaletteMetric metricPressed, PaletteMetricPadding metricPadding, Orientation orientation)
	{
		Debug.Assert(paletteDisabled != null);
		Debug.Assert(paletteNormal != null);
		Debug.Assert(paletteTracking != null);
		Debug.Assert(palettePressed != null);
		Debug.Assert(metricDisabled != null);
		Debug.Assert(metricNormal != null);
		Debug.Assert(metricTracking != null);
		Debug.Assert(metricPressed != null);
		_paletteDisabled = paletteDisabled;
		_paletteNormal = paletteNormal;
		_paletteTracking = paletteTracking;
		_palettePressed = palettePressed;
		_metricDisabled = metricDisabled;
		_metricNormal = metricNormal;
		_metricTracking = metricTracking;
		_metricPressed = metricPressed;
		_metricPadding = metricPadding;
		_orientation = orientation;
		_length = 0;
	}

	public override string ToString()
	{
		return "ViewDrawSeparator:" + base.Id;
	}

	public void SetPalettes(IPaletteDouble paletteDisabled, IPaletteDouble paletteNormal, IPaletteDouble paletteTracking, IPaletteDouble palettePressed, IPaletteMetric metricDisabled, IPaletteMetric metricNormal, IPaletteMetric metricTracking, IPaletteMetric metricPressed)
	{
		Debug.Assert(paletteDisabled != null);
		Debug.Assert(paletteNormal != null);
		Debug.Assert(paletteTracking != null);
		Debug.Assert(palettePressed != null);
		Debug.Assert(metricDisabled != null);
		Debug.Assert(metricNormal != null);
		Debug.Assert(metricTracking != null);
		Debug.Assert(metricPressed != null);
		_paletteDisabled = paletteDisabled;
		_paletteNormal = paletteNormal;
		_paletteTracking = paletteTracking;
		_palettePressed = palettePressed;
		_metricDisabled = metricDisabled;
		_metricNormal = metricNormal;
		_metricTracking = metricTracking;
		_metricPressed = metricPressed;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		return new Size(_length, _length);
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		Debug.Assert(context != null);
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		CheckPaletteState();
		Rectangle displayRect = CommonHelper.ApplyPadding(Orientation, ClientRectangle, _metric.GetMetricPadding(ElementState, _metricPadding));
		context.Renderer.RenderGlyph.DrawSeparator(context, displayRect, _palette.PaletteBack, _palette.PaletteBorder, Orientation, State, Source == null || Source.SeparatorCanMove);
	}

	private void CheckPaletteState()
	{
		switch (IsFixed ? FixedState : State)
		{
		case PaletteState.Disabled:
			_palette = _paletteDisabled;
			_metric = _metricDisabled;
			break;
		case PaletteState.Normal:
			_palette = _paletteNormal;
			_metric = _metricNormal;
			break;
		case PaletteState.Pressed:
			_palette = _palettePressed;
			_metric = _metricPressed;
			break;
		case PaletteState.Tracking:
			_palette = _paletteTracking;
			_metric = _metricTracking;
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
	}
}
