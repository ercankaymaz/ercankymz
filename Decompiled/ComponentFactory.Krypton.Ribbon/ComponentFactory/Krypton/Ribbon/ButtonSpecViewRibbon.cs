using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class ButtonSpecViewRibbon : ButtonSpecView
{
	private ButtonSpecRibbonController _controller;

	public ButtonSpecViewRibbon(PaletteRedirect redirector, IPaletteMetric paletteMetric, PaletteMetricPadding metricPadding, ButtonSpecManagerBase manager, ButtonSpec buttonSpec)
		: base(redirector, paletteMetric, metricPadding, manager, buttonSpec)
	{
	}

	public override ButtonSpecViewControllers CreateController(ViewDrawButton viewButton, NeedPaintHandler needPaint, MouseEventHandler clickHandler)
	{
		_controller = new ButtonSpecRibbonController(viewButton, needPaint);
		_controller.BecomesFixed = true;
		_controller.Click += clickHandler;
		IMouseController mouseController = _controller;
		if (base.Manager.ToolTipManager != null)
		{
			mouseController = new ToolTipController(base.Manager.ToolTipManager, viewButton, _controller);
		}
		return new ButtonSpecViewControllers(mouseController, _controller, _controller);
	}

	protected override void OnFinishDelegate(object sender, EventArgs e)
	{
		_controller.RemoveFixed();
	}
}
