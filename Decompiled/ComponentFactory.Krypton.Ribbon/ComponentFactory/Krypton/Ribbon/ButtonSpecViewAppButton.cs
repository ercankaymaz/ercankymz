using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class ButtonSpecViewAppButton : ButtonSpecView
{
	private ButtonSpecAppButtonController _controller;

	public ButtonSpecViewAppButton(PaletteRedirect redirector, IPaletteMetric paletteMetric, PaletteMetricPadding metricPadding, ButtonSpecManagerBase manager, ButtonSpec buttonSpec)
		: base(redirector, paletteMetric, metricPadding, manager, buttonSpec)
	{
	}

	public override ButtonSpecViewControllers CreateController(ViewDrawButton viewButton, NeedPaintHandler needPaint, MouseEventHandler clickHandler)
	{
		ButtonSpecManagerLayoutAppButton buttonSpecManagerLayoutAppButton = (ButtonSpecManagerLayoutAppButton)base.Manager;
		_controller = new ButtonSpecAppButtonController(buttonSpecManagerLayoutAppButton.ViewManager, viewButton, needPaint);
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
