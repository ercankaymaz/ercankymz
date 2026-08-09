#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteFormRedirect : PaletteDoubleRedirect, IPaletteMetric
{
	private PaletteRedirect _redirect;

	private InheritBool _overlayHeaders;

	private PaletteHeaderButtonRedirect _paletteHeader;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _paletteHeader.IsDefault && OverlayHeaders == InheritBool.Inherit;

	[Category("Visuals")]
	[Description("Overrides for defining header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteHeaderButtonRedirect Header => _paletteHeader;

	[Category("Visuals")]
	[Description("Should headers overlay the border.")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public InheritBool OverlayHeaders
	{
		get
		{
			return _overlayHeaders;
		}
		set
		{
			if (_overlayHeaders != value)
			{
				_overlayHeaders = value;
				PerformNeedPaint();
			}
		}
	}

	public PaletteFormRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
		: this(redirect, redirect, needPaint)
	{
	}

	public PaletteFormRedirect(PaletteRedirect redirectForm, PaletteRedirect redirectHeader, NeedPaintHandler needPaint)
		: base(redirectForm, PaletteBackStyle.FormMain, PaletteBorderStyle.FormMain, needPaint)
	{
		Debug.Assert(redirectForm != null);
		Debug.Assert(redirectHeader != null);
		_redirect = redirectForm;
		_paletteHeader = new PaletteHeaderButtonRedirect(redirectHeader, PaletteBackStyle.HeaderForm, PaletteBorderStyle.HeaderForm, PaletteContentStyle.HeaderForm, needPaint);
		_overlayHeaders = InheritBool.Inherit;
	}

	private bool ShouldSerializeHeader()
	{
		return !_paletteHeader.IsDefault;
	}

	public int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return _redirect.GetMetricInt(state, metric);
	}

	public InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		if (metric == PaletteMetricBool.HeaderGroupOverlay && OverlayHeaders != InheritBool.Inherit)
		{
			return OverlayHeaders;
		}
		return _redirect.GetMetricBool(state, metric);
	}

	public Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		return _redirect.GetMetricPadding(state, metric);
	}
}
