using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;
using ns42;

namespace buControls.ColorPicker;

public class buColorComboBox : UserControl
{
	private Color color_0;

	[CompilerGenerated]
	private colorChangedEventHandler colorChangedEventHandler_0;

	private IContainer icontainer_0 = null;

	internal Class108 class108_0;

	public virtual Color Color
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			class108_0.Text = color_0.Name;
		}
	}

	[Category("Appearance")]
	[DefaultValue(typeof(Color), "0, 0, 0")]
	public event colorChangedEventHandler ColorChanged
	{
		[CompilerGenerated]
		add
		{
			colorChangedEventHandler colorChangedEventHandler2 = colorChangedEventHandler_0;
			colorChangedEventHandler colorChangedEventHandler3;
			do
			{
				colorChangedEventHandler3 = colorChangedEventHandler2;
				colorChangedEventHandler value2 = (colorChangedEventHandler)Delegate.Combine(colorChangedEventHandler3, value);
				colorChangedEventHandler2 = Interlocked.CompareExchange(ref colorChangedEventHandler_0, value2, colorChangedEventHandler3);
			}
			while ((object)colorChangedEventHandler2 != colorChangedEventHandler3);
		}
		[CompilerGenerated]
		remove
		{
			colorChangedEventHandler colorChangedEventHandler2 = colorChangedEventHandler_0;
			colorChangedEventHandler colorChangedEventHandler3;
			do
			{
				colorChangedEventHandler3 = colorChangedEventHandler2;
				colorChangedEventHandler value2 = (colorChangedEventHandler)Delegate.Remove(colorChangedEventHandler3, value);
				colorChangedEventHandler2 = Interlocked.CompareExchange(ref colorChangedEventHandler_0, value2, colorChangedEventHandler3);
			}
			while ((object)colorChangedEventHandler2 != colorChangedEventHandler3);
		}
	}

	public buColorComboBox()
	{
		Class76.smethod_520(this);
		base.Height = 28;
	}

	internal void method_0(object sender, EventArgs e)
	{
		base.Height = 28;
	}

	internal void method_1(object sender, EventArgs e)
	{
		Class108 @class = sender as Class108;
		Color color = Color.FromName(@class.Items[@class.SelectedIndex].ToString());
		if (colorChangedEventHandler_0 != null)
		{
			colorChangedEventHandler_0(this, color);
		}
		Color = color;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
