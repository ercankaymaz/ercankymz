using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buControls.ColorPicker;

public class buColorBox : UserControl
{
	public enum eDrawStyle
	{
		Hue,
		Saturation,
		Brightness,
		Red,
		Green,
		Blue
	}

	internal int int_0 = 0;

	internal int int_1 = 0;

	private bool bool_0 = false;

	internal eDrawStyle eDrawStyle_0 = eDrawStyle.Hue;

	internal buAdobeColors.HSL hsl_0;

	internal Color color_0;

	private Container container_0 = null;

	[CompilerGenerated]
	private EventHandler eventHandler_0;

	public eDrawStyle DrawStyle
	{
		get
		{
			return eDrawStyle_0;
		}
		set
		{
			eDrawStyle_0 = value;
			Class76.smethod_781(true, this);
			Class76.smethod_782(this);
		}
	}

	public buAdobeColors.HSL HSL
	{
		get
		{
			return hsl_0;
		}
		set
		{
			hsl_0 = value;
			color_0 = buAdobeColors.HSL_to_RGB(hsl_0);
			Class76.smethod_781(true, this);
			Class76.smethod_782(this);
		}
	}

	public Color RGB
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			hsl_0 = buAdobeColors.RGB_to_HSL(color_0);
			Class76.smethod_781(true, this);
			Class76.smethod_782(this);
		}
	}

	public event EventHandler ScrollColor
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public buColorBox()
	{
		Class76.smethod_412(this);
		hsl_0 = new buAdobeColors.HSL();
		hsl_0.H = 1.0;
		hsl_0.S = 1.0;
		hsl_0.L = 1.0;
		color_0 = buAdobeColors.HSL_to_RGB(hsl_0);
		eDrawStyle_0 = eDrawStyle.Hue;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Class76.smethod_782(this);
	}

	internal void method_1(object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Left)
		{
			return;
		}
		bool_0 = true;
		int num = e.X - 2;
		int num2 = e.Y - 2;
		if (num < 0)
		{
			num = 0;
		}
		if (num > base.Width - 4)
		{
			num = base.Width - 4;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num2 > base.Height - 4)
		{
			num2 = base.Height - 4;
		}
		if (num != int_0 || num2 != int_1)
		{
			Class76.smethod_322(this, num, num2, true);
			Class76.smethod_366(this);
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, e);
			}
		}
	}

	internal void method_2(object sender, MouseEventArgs e)
	{
		if (!bool_0)
		{
			return;
		}
		int num = e.X - 2;
		int num2 = e.Y - 2;
		if (num < 0)
		{
			num = 0;
		}
		if (num > base.Width - 4)
		{
			num = base.Width - 4;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num2 > base.Height - 4)
		{
			num2 = base.Height - 4;
		}
		if (num != int_0 || num2 != int_1)
		{
			Class76.smethod_322(this, num, num2, true);
			Class76.smethod_366(this);
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, e);
			}
		}
	}

	internal void method_3(object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Left || !bool_0)
		{
			return;
		}
		bool_0 = false;
		int num = e.X - 2;
		int num2 = e.Y - 2;
		if (num < 0)
		{
			num = 0;
		}
		if (num > base.Width - 4)
		{
			num = base.Width - 4;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num2 > base.Height - 4)
		{
			num2 = base.Height - 4;
		}
		if (num != int_0 || num2 != int_1)
		{
			Class76.smethod_322(this, num, num2, true);
			Class76.smethod_366(this);
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, e);
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Class76.smethod_782(this);
	}

	internal void method_5(object sender, PaintEventArgs e)
	{
		Class76.smethod_782(this);
	}
}
