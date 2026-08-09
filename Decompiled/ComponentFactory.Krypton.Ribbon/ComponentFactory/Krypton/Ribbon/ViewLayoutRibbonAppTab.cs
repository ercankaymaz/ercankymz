#define DEBUG
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonAppTab : ViewLayoutDocker
{
	private KryptonRibbon _ribbon;

	private ViewDrawRibbonAppTab _appTab;

	public ViewDrawRibbonAppTab AppTab => _appTab;

	public ViewLayoutRibbonAppTab(KryptonRibbon ribbon)
	{
		Debug.Assert(ribbon != null);
		_ribbon = ribbon;
		_appTab = new ViewDrawRibbonAppTab(ribbon);
		Add(_appTab, ViewDockStyle.Bottom);
		Add(new ViewLayoutSeparator(1), ViewDockStyle.Left);
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonAppTab:" + base.Id;
	}
}
