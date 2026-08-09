using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecFormWindowClose : ButtonSpecFormFixed
{
	public ButtonSpecFormWindowClose(KryptonForm form)
		: base(form, PaletteButtonSpecStyle.FormClose)
	{
	}

	public override bool GetVisible(IPalette palette)
	{
		if (base.KryptonForm.ApplyComposition && base.KryptonForm.ApplyCustomChrome)
		{
			return false;
		}
		if (!base.KryptonForm.ControlBox)
		{
			return false;
		}
		return true;
	}

	public override ButtonEnabled GetEnabled(IPalette palette)
	{
		return ButtonEnabled.True;
	}

	public override ButtonCheckState GetChecked(IPalette palette)
	{
		return ButtonCheckState.NotCheckButton;
	}

	protected override void OnClick(EventArgs e)
	{
		if (GetViewEnabled() && !base.KryptonForm.InertForm)
		{
			MouseEventArgs e2 = (MouseEventArgs)e;
			if (GetView().ClientRectangle.Contains(e2.Location))
			{
				PropertyInfo property = typeof(Form).GetProperty("CloseReason", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
				property.SetValue(base.KryptonForm, CloseReason.UserClosing, null);
				Point mousePosition = Control.MousePosition;
				IntPtr lParam = (IntPtr)(PI.MAKELOWORD(mousePosition.X) | PI.MAKEHIWORD(mousePosition.Y));
				base.KryptonForm.SendSysCommand(61536, lParam);
				base.OnClick(e);
			}
		}
	}
}
