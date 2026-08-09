using System;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecFormWindowMin : ButtonSpecFormFixed
{
	public ButtonSpecFormWindowMin(KryptonForm form)
		: base(form, PaletteButtonSpecStyle.FormMin)
	{
	}

	public override bool GetVisible(IPalette palette)
	{
		if (base.KryptonForm.ApplyComposition && base.KryptonForm.ApplyCustomChrome)
		{
			return false;
		}
		FormBorderStyle formBorderStyle = base.KryptonForm.FormBorderStyle;
		FormBorderStyle formBorderStyle2 = formBorderStyle;
		if ((uint)(formBorderStyle2 - 5) <= 1u)
		{
			return false;
		}
		if (!base.KryptonForm.ControlBox)
		{
			return false;
		}
		if (!base.KryptonForm.MinimizeBox && !base.KryptonForm.MaximizeBox)
		{
			return false;
		}
		return true;
	}

	public override ButtonEnabled GetEnabled(IPalette palette)
	{
		if (!base.KryptonForm.MinimizeBox)
		{
			return ButtonEnabled.False;
		}
		return ButtonEnabled.True;
	}

	public override ButtonCheckState GetChecked(IPalette palette)
	{
		return ButtonCheckState.NotCheckButton;
	}

	protected override void OnClick(EventArgs e)
	{
		if (!GetViewEnabled() || base.KryptonForm.InertForm)
		{
			return;
		}
		MouseEventArgs e2 = (MouseEventArgs)e;
		if (GetView().ClientRectangle.Contains(e2.Location))
		{
			if (base.KryptonForm.WindowState == FormWindowState.Minimized)
			{
				base.KryptonForm.SendSysCommand(61728);
			}
			else
			{
				base.KryptonForm.SendSysCommand(61472);
			}
			base.OnClick(e);
		}
	}
}
