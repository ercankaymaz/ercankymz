#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteHeaderGroupState : Storage, IPaletteMetric
{
	private PaletteRedirect _redirect;

	private InheritBool _overlayHeaders;

	private Padding _primaryHeaderPadding;

	private Padding _secondaryHeaderPadding;

	private Padding _dockInactiveHeaderPadding;

	private Padding _dockActiveHeaderPadding;

	[Browsable(false)]
	public override bool IsDefault => PrimaryHeaderPadding.Equals(CommonHelper.InheritPadding) && SecondaryHeaderPadding.Equals(CommonHelper.InheritPadding) && DockInactiveHeaderPadding.Equals(CommonHelper.InheritPadding) && DockActiveHeaderPadding.Equals(CommonHelper.InheritPadding) && OverlayHeaders == InheritBool.Inherit;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used to position the primary header.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding PrimaryHeaderPadding
	{
		get
		{
			return _primaryHeaderPadding;
		}
		set
		{
			if (_primaryHeaderPadding != value)
			{
				_primaryHeaderPadding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used to position the secondary header.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding SecondaryHeaderPadding
	{
		get
		{
			return _secondaryHeaderPadding;
		}
		set
		{
			if (_secondaryHeaderPadding != value)
			{
				_secondaryHeaderPadding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used to position the dock inactive header.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding DockInactiveHeaderPadding
	{
		get
		{
			return _dockInactiveHeaderPadding;
		}
		set
		{
			if (_dockInactiveHeaderPadding != value)
			{
				_dockInactiveHeaderPadding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used to position the dock active header.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding DockActiveHeaderPadding
	{
		get
		{
			return _dockActiveHeaderPadding;
		}
		set
		{
			if (_dockActiveHeaderPadding != value)
			{
				_dockActiveHeaderPadding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
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

	public KryptonPaletteHeaderGroupState(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		NeedPaint = needPaint;
		_primaryHeaderPadding = CommonHelper.InheritPadding;
		_secondaryHeaderPadding = CommonHelper.InheritPadding;
		_dockInactiveHeaderPadding = CommonHelper.InheritPadding;
		_dockActiveHeaderPadding = CommonHelper.InheritPadding;
		_overlayHeaders = InheritBool.Inherit;
	}

	public void PopulateFromBase()
	{
		PrimaryHeaderPadding = _redirect.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.HeaderGroupPaddingPrimary);
		SecondaryHeaderPadding = _redirect.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.HeaderGroupPaddingSecondary);
		DockInactiveHeaderPadding = _redirect.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.HeaderGroupPaddingDockInactive);
		DockActiveHeaderPadding = _redirect.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.HeaderGroupPaddingDockActive);
		OverlayHeaders = _redirect.GetMetricBool(PaletteState.Normal, PaletteMetricBool.HeaderGroupOverlay);
	}

	public void ResetPrimaryHeaderPadding()
	{
		PrimaryHeaderPadding = CommonHelper.InheritPadding;
	}

	public void ResetSecondaryHeaderPadding()
	{
		SecondaryHeaderPadding = CommonHelper.InheritPadding;
	}

	public void ResetDockInactiveHeaderPadding()
	{
		DockInactiveHeaderPadding = CommonHelper.InheritPadding;
	}

	public void ResetDockActiveHeaderPadding()
	{
		DockActiveHeaderPadding = CommonHelper.InheritPadding;
	}

	public void ResetOverlayHeaders()
	{
		OverlayHeaders = InheritBool.Inherit;
	}

	public virtual int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		return _redirect.GetMetricInt(state, metric);
	}

	public virtual InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		if (metric == PaletteMetricBool.HeaderGroupOverlay && OverlayHeaders != InheritBool.Inherit)
		{
			return OverlayHeaders;
		}
		return _redirect.GetMetricBool(state, metric);
	}

	public virtual Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		switch (metric)
		{
		case PaletteMetricPadding.HeaderGroupPaddingPrimary:
			if (!PrimaryHeaderPadding.Equals(CommonHelper.InheritPadding))
			{
				return PrimaryHeaderPadding;
			}
			break;
		case PaletteMetricPadding.HeaderGroupPaddingSecondary:
			if (!SecondaryHeaderPadding.Equals(CommonHelper.InheritPadding))
			{
				return SecondaryHeaderPadding;
			}
			break;
		case PaletteMetricPadding.HeaderGroupPaddingDockInactive:
			if (!DockInactiveHeaderPadding.Equals(CommonHelper.InheritPadding))
			{
				return DockInactiveHeaderPadding;
			}
			break;
		case PaletteMetricPadding.HeaderGroupPaddingDockActive:
			if (!DockActiveHeaderPadding.Equals(CommonHelper.InheritPadding))
			{
				return DockActiveHeaderPadding;
			}
			break;
		}
		return _redirect.GetMetricPadding(state, metric);
	}
}
