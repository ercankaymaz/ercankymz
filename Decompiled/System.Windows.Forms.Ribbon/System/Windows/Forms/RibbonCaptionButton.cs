using System.Drawing;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms;

public class RibbonCaptionButton : RibbonButton
{
	public enum CaptionButton
	{
		Minimize,
		Maximize,
		Restore,
		Close
	}

	public const string WindowsIconsFont = "Marlett";

	public CaptionButton CaptionButtonType { get; private set; }

	public static string GetCharFor(CaptionButton type)
	{
		if (WinApi.IsWindows)
		{
			return type switch
			{
				CaptionButton.Minimize => "0", 
				CaptionButton.Maximize => "1", 
				CaptionButton.Restore => "2", 
				CaptionButton.Close => "r", 
				_ => "?", 
			};
		}
		return type switch
		{
			CaptionButton.Minimize => "_", 
			CaptionButton.Maximize => "+", 
			CaptionButton.Restore => "^", 
			CaptionButton.Close => "X", 
			_ => "?", 
		};
	}

	public RibbonCaptionButton(CaptionButton buttonType)
	{
		SetCaptionButtonType(buttonType);
	}

	public override void OnClick(EventArgs e)
	{
		base.OnClick(e);
		Form form = base.Owner.FindForm();
		if (form == null)
		{
			return;
		}
		switch (CaptionButtonType)
		{
		case CaptionButton.Minimize:
			form.WindowState = FormWindowState.Minimized;
			break;
		case CaptionButton.Maximize:
			if (form.WindowState == FormWindowState.Normal)
			{
				form.WindowState = FormWindowState.Maximized;
				form.Refresh();
			}
			else
			{
				form.WindowState = FormWindowState.Normal;
				form.Refresh();
			}
			break;
		case CaptionButton.Restore:
			form.WindowState = FormWindowState.Normal;
			break;
		case CaptionButton.Close:
			form.Close();
			break;
		}
	}

	internal void SetCaptionButtonType(CaptionButton buttonType)
	{
		Text = GetCharFor(buttonType);
		CaptionButtonType = buttonType;
	}

	internal override Rectangle OnGetTextBounds(RibbonElementSizeMode sMode, Rectangle bounds)
	{
		Rectangle result = bounds;
		result.X = bounds.Left + 3;
		return result;
	}
}
