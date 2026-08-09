#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteHeaderGroupRedirect : PaletteDoubleRedirect, IPaletteMetric
{
	private PaletteRedirect _redirect;

	private InheritBool _overlayHeaders;

	private PaletteHeaderPaddingRedirect _paletteHeaderPrimary;

	private PaletteHeaderPaddingRedirect _paletteHeaderSecondary;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && _paletteHeaderPrimary.IsDefault && _paletteHeaderSecondary.IsDefault && OverlayHeaders == InheritBool.Inherit;

	[Category("Visuals")]
	[Description("Overrides for defining primary header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteHeaderPaddingRedirect HeaderPrimary => _paletteHeaderPrimary;

	[Category("Visuals")]
	[Description("Overrides for defining secondary header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteHeaderPaddingRedirect HeaderSecondary => _paletteHeaderSecondary;

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

	public PaletteHeaderGroupRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
		: this(redirect, redirect, redirect, needPaint)
	{
	}

	public PaletteHeaderGroupRedirect(PaletteRedirect redirectHeaderGroup, PaletteRedirect redirectHeaderPrimary, PaletteRedirect redirectHeaderSecondary, NeedPaintHandler needPaint)
		: base(redirectHeaderGroup, PaletteBackStyle.ControlClient, PaletteBorderStyle.ControlClient, needPaint)
	{
		Debug.Assert(redirectHeaderGroup != null);
		Debug.Assert(redirectHeaderSecondary != null);
		Debug.Assert(redirectHeaderPrimary != null);
		_redirect = redirectHeaderGroup;
		_paletteHeaderPrimary = new PaletteHeaderPaddingRedirect(redirectHeaderPrimary, PaletteBackStyle.HeaderPrimary, PaletteBorderStyle.HeaderPrimary, PaletteContentStyle.HeaderPrimary, needPaint);
		_paletteHeaderSecondary = new PaletteHeaderPaddingRedirect(redirectHeaderSecondary, PaletteBackStyle.HeaderSecondary, PaletteBorderStyle.HeaderSecondary, PaletteContentStyle.HeaderSecondary, needPaint);
		_overlayHeaders = InheritBool.Inherit;
	}

	private bool ShouldSerializeHeaderPrimary()
	{
		return !_paletteHeaderPrimary.IsDefault;
	}

	private bool ShouldSerializeHeaderSecondary()
	{
		return !_paletteHeaderSecondary.IsDefault;
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
