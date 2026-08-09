using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewLayoutRibbonGroupButton : ViewLayoutDocker
{
	private ViewDrawRibbonGroupDialogButton _groupButton;

	private ViewLayoutRibbonCenter _centerButton;

	public DialogLauncherButtonController DialogButtonController => _groupButton.DialogButtonController;

	public ViewLayoutRibbonGroupButton(KryptonRibbon ribbon, KryptonRibbonGroup ribbonGroup, NeedPaintHandler needPaint)
	{
		_groupButton = new ViewDrawRibbonGroupDialogButton(ribbon, ribbonGroup, needPaint);
		_centerButton = new ViewLayoutRibbonCenter();
		_centerButton.Add(_groupButton);
		Add(_centerButton, ViewDockStyle.Fill);
	}

	public override string ToString()
	{
		return "ViewLayoutRibbonGroupButton:" + base.Id;
	}

	public ViewBase GetFocusView()
	{
		if (Visible && Enabled && _groupButton.Visible && _groupButton.Enabled)
		{
			return _groupButton;
		}
		return null;
	}
}
