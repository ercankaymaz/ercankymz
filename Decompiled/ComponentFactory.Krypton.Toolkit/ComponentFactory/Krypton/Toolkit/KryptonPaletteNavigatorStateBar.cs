#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteNavigatorStateBar : Storage, IPaletteMetric
{
	private PaletteRedirect _redirect;

	private Padding _barPaddingTabs;

	private Padding _barPaddingInside;

	private Padding _barPaddingOutside;

	private Padding _barPaddingOnly;

	private Padding _buttonPadding;

	private int _buttonEdgeInside;

	private int _buttonEdgeOutside;

	private int _checkButtonGap;

	private int _ribbonTabGap;

	[Browsable(false)]
	public override bool IsDefault => BarPaddingTabs.Equals(CommonHelper.InheritPadding) && BarPaddingInside.Equals(CommonHelper.InheritPadding) && BarPaddingOutside.Equals(CommonHelper.InheritPadding) && BarPaddingOnly.Equals(CommonHelper.InheritPadding) && ButtonPadding.Equals(CommonHelper.InheritPadding) && ButtonEdgeInside == -1 && ButtonEdgeOutside == -1 && CheckButtonGap == -1 && RibbonTabGap == -1;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used around the bar when displaying tabs.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding BarPaddingTabs
	{
		get
		{
			return _barPaddingTabs;
		}
		set
		{
			if (_barPaddingTabs != value)
			{
				_barPaddingTabs = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used around the bar when placed inside the group.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding BarPaddingInside
	{
		get
		{
			return _barPaddingInside;
		}
		set
		{
			if (_barPaddingInside != value)
			{
				_barPaddingInside = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used around the bar when placed outside the group.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding BarPaddingOutside
	{
		get
		{
			return _barPaddingOutside;
		}
		set
		{
			if (_barPaddingOutside != value)
			{
				_barPaddingOutside = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used around the bar when placed on its own.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding BarPaddingOnly
	{
		get
		{
			return _barPaddingOnly;
		}
		set
		{
			if (_barPaddingOnly != value)
			{
				_barPaddingOnly = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding used around each button on the button bar.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding ButtonPadding
	{
		get
		{
			return _buttonPadding;
		}
		set
		{
			if (_buttonPadding != value)
			{
				_buttonPadding = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("How far to inset buttons from the control edge.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public int ButtonEdgeOutside
	{
		get
		{
			return _buttonEdgeOutside;
		}
		set
		{
			if (_buttonEdgeOutside != value)
			{
				_buttonEdgeOutside = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("How far to inset buttons from the button bar.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public int ButtonEdgeInside
	{
		get
		{
			return _buttonEdgeInside;
		}
		set
		{
			if (_buttonEdgeInside != value)
			{
				_buttonEdgeInside = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Spacing gap between each check button.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public int CheckButtonGap
	{
		get
		{
			return _checkButtonGap;
		}
		set
		{
			if (_checkButtonGap != value)
			{
				_checkButtonGap = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Spacing gap between each ribbon tab.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public int RibbonTabGap
	{
		get
		{
			return _ribbonTabGap;
		}
		set
		{
			if (_ribbonTabGap != value)
			{
				_ribbonTabGap = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public KryptonPaletteNavigatorStateBar(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		_redirect = redirect;
		NeedPaint = needPaint;
		_barPaddingTabs = CommonHelper.InheritPadding;
		_barPaddingInside = CommonHelper.InheritPadding;
		_barPaddingOutside = CommonHelper.InheritPadding;
		_barPaddingOnly = CommonHelper.InheritPadding;
		_buttonPadding = CommonHelper.InheritPadding;
		_buttonEdgeInside = -1;
		_buttonEdgeOutside = -1;
		_checkButtonGap = -1;
		_ribbonTabGap = -1;
	}

	public void PopulateFromBase()
	{
		BarPaddingInside = _redirect.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.BarPaddingInside);
		BarPaddingOutside = _redirect.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.BarPaddingOutside);
		BarPaddingOnly = _redirect.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.BarPaddingOnly);
		ButtonPadding = _redirect.GetMetricPadding(PaletteState.Normal, PaletteMetricPadding.BarButtonPadding);
		ButtonEdgeInside = _redirect.GetMetricInt(PaletteState.Normal, PaletteMetricInt.BarButtonEdgeInside);
		ButtonEdgeOutside = _redirect.GetMetricInt(PaletteState.Normal, PaletteMetricInt.BarButtonEdgeOutside);
		CheckButtonGap = _redirect.GetMetricInt(PaletteState.Normal, PaletteMetricInt.CheckButtonGap);
		RibbonTabGap = _redirect.GetMetricInt(PaletteState.Normal, PaletteMetricInt.RibbonTabGap);
	}

	public void ResetBarPaddingTabs()
	{
		BarPaddingTabs = CommonHelper.InheritPadding;
	}

	public void ResetBarPaddingInside()
	{
		BarPaddingInside = CommonHelper.InheritPadding;
	}

	public void ResetBarPaddingOutside()
	{
		BarPaddingOutside = CommonHelper.InheritPadding;
	}

	public void ResetBarPaddingOnly()
	{
		BarPaddingOnly = CommonHelper.InheritPadding;
	}

	public void ResetButtonPadding()
	{
		ButtonPadding = CommonHelper.InheritPadding;
	}

	public void ResetButtonEdgeOutside()
	{
		ButtonEdgeOutside = -1;
	}

	public void ResetButtonEdgeInside()
	{
		ButtonEdgeInside = -1;
	}

	public void ResetCheckButtonGap()
	{
		CheckButtonGap = -1;
	}

	public void ResetRibbonTabGap()
	{
		RibbonTabGap = -1;
	}

	public virtual int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		switch (metric)
		{
		case PaletteMetricInt.BarButtonEdgeInside:
			if (ButtonEdgeInside != -1)
			{
				return ButtonEdgeInside;
			}
			break;
		case PaletteMetricInt.BarButtonEdgeOutside:
			if (ButtonEdgeOutside != -1)
			{
				return ButtonEdgeOutside;
			}
			break;
		case PaletteMetricInt.CheckButtonGap:
			if (CheckButtonGap != -1)
			{
				return CheckButtonGap;
			}
			break;
		case PaletteMetricInt.RibbonTabGap:
			if (RibbonTabGap != -1)
			{
				return RibbonTabGap;
			}
			break;
		}
		return _redirect.GetMetricInt(state, metric);
	}

	public virtual InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		return _redirect.GetMetricBool(state, metric);
	}

	public virtual Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		switch (metric)
		{
		case PaletteMetricPadding.BarPaddingTabs:
			if (!BarPaddingTabs.Equals(CommonHelper.InheritPadding))
			{
				return BarPaddingTabs;
			}
			break;
		case PaletteMetricPadding.BarPaddingInside:
			if (!BarPaddingInside.Equals(CommonHelper.InheritPadding))
			{
				return BarPaddingInside;
			}
			break;
		case PaletteMetricPadding.BarPaddingOutside:
			if (!BarPaddingOutside.Equals(CommonHelper.InheritPadding))
			{
				return BarPaddingOutside;
			}
			break;
		case PaletteMetricPadding.BarPaddingOnly:
			if (!BarPaddingOnly.Equals(CommonHelper.InheritPadding))
			{
				return BarPaddingOnly;
			}
			break;
		case PaletteMetricPadding.BarButtonPadding:
			if (!ButtonPadding.Equals(CommonHelper.InheritPadding))
			{
				return ButtonPadding;
			}
			break;
		}
		return _redirect.GetMetricPadding(state, metric);
	}
}
