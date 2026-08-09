using System;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class ButtonSpecAppMenu : ButtonSpecAny
{
	protected override void OnClick(EventArgs e)
	{
		if (!GetViewEnabled())
		{
			return;
		}
		if (base.KryptonContextMenu == null && base.ContextMenuStrip == null)
		{
			VisualPopupManager.Singleton.EndAllTracking();
		}
		if (base.Checked != ButtonCheckState.NotCheckButton)
		{
			if (base.Checked == ButtonCheckState.Unchecked)
			{
				base.Checked = ButtonCheckState.Checked;
			}
			else
			{
				base.Checked = ButtonCheckState.Unchecked;
			}
		}
		GenerateClick(e);
	}
}
