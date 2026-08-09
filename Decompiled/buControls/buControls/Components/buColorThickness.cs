using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns27;

namespace buControls.Components;

public class buColorThickness : UserControl
{
	private Color color_0;

	private string string_0;

	private bool bool_0 = false;

	[CompilerGenerated]
	private buControlEvents.buColorChangedEventHandler buColorChangedEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buColorChangedEventHandler buColorChangedEventHandler_1;

	public double ItemThickness = 1.0;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal buSpin buSpin_0;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(string), "Color Text")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string ItemText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			label_0.Text = string_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "Gray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color ItemColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			label_0.BackColor = color_0;
		}
	}

	public event buControlEvents.buColorChangedEventHandler ColorChanged
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buColorChangedEventHandler buColorChangedEventHandler = buColorChangedEventHandler_0;
			buControlEvents.buColorChangedEventHandler buColorChangedEventHandler2;
			do
			{
				buColorChangedEventHandler2 = buColorChangedEventHandler;
				buControlEvents.buColorChangedEventHandler value2 = (buControlEvents.buColorChangedEventHandler)Delegate.Combine(buColorChangedEventHandler2, value);
				buColorChangedEventHandler = Interlocked.CompareExchange(ref buColorChangedEventHandler_0, value2, buColorChangedEventHandler2);
			}
			while ((object)buColorChangedEventHandler != buColorChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buColorChangedEventHandler buColorChangedEventHandler = buColorChangedEventHandler_0;
			buControlEvents.buColorChangedEventHandler buColorChangedEventHandler2;
			do
			{
				buColorChangedEventHandler2 = buColorChangedEventHandler;
				buControlEvents.buColorChangedEventHandler value2 = (buControlEvents.buColorChangedEventHandler)Delegate.Remove(buColorChangedEventHandler2, value);
				buColorChangedEventHandler = Interlocked.CompareExchange(ref buColorChangedEventHandler_0, value2, buColorChangedEventHandler2);
			}
			while ((object)buColorChangedEventHandler != buColorChangedEventHandler2);
		}
	}

	public event buControlEvents.buColorChangedEventHandler ColorDoubleClick
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buColorChangedEventHandler buColorChangedEventHandler = buColorChangedEventHandler_1;
			buControlEvents.buColorChangedEventHandler buColorChangedEventHandler2;
			do
			{
				buColorChangedEventHandler2 = buColorChangedEventHandler;
				buControlEvents.buColorChangedEventHandler value2 = (buControlEvents.buColorChangedEventHandler)Delegate.Combine(buColorChangedEventHandler2, value);
				buColorChangedEventHandler = Interlocked.CompareExchange(ref buColorChangedEventHandler_1, value2, buColorChangedEventHandler2);
			}
			while ((object)buColorChangedEventHandler != buColorChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buColorChangedEventHandler buColorChangedEventHandler = buColorChangedEventHandler_1;
			buControlEvents.buColorChangedEventHandler buColorChangedEventHandler2;
			do
			{
				buColorChangedEventHandler2 = buColorChangedEventHandler;
				buControlEvents.buColorChangedEventHandler value2 = (buControlEvents.buColorChangedEventHandler)Delegate.Remove(buColorChangedEventHandler2, value);
				buColorChangedEventHandler = Interlocked.CompareExchange(ref buColorChangedEventHandler_1, value2, buColorChangedEventHandler2);
			}
			while ((object)buColorChangedEventHandler != buColorChangedEventHandler2);
		}
	}

	public buColorThickness()
	{
		Class76.smethod_362(this);
		base.Height = 25;
		label_0.DoubleClick += label_0_DoubleClick;
	}

	public void UpdateControl()
	{
		bool_0 = true;
		label_0.BackColor = ItemColor;
		label_0.Text = ItemText;
		label_0.ForeColor = buImage.InvertColorNoGray(label_0.BackColor);
		buSpin_0.Value = ItemThickness;
		bool_0 = false;
	}

	private void label_0_DoubleClick(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			ItemColor = label_0.BackColor;
			if (buColorChangedEventHandler_1 != null)
			{
				buColorChangedEventHandler_1(this, ItemColor, ItemThickness, 255);
			}
			if (buColorChangedEventHandler_0 != null)
			{
				buColorChangedEventHandler_0(this, ItemColor, ItemThickness, 255);
			}
		}
	}

	internal void method_0(object object_0, double double_0)
	{
		if (!bool_0)
		{
			ItemColor = label_0.BackColor;
			if (buColorChangedEventHandler_0 != null)
			{
				buColorChangedEventHandler_0(this, ItemColor, ItemThickness, 255);
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		ColorDialogBox.ShowDialog(label_0.BackColor);
		if (ColorDialogBox.Result == DialogResult.OK)
		{
			ItemColor = ColorDialogBox.Color;
			label_0.BackColor = ColorDialogBox.Color;
			label_0.ForeColor = buImage.InvertColorNoGray(label_0.BackColor);
			if (buColorChangedEventHandler_0 != null)
			{
				buColorChangedEventHandler_0(this, ItemColor, ItemThickness, 255);
			}
		}
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
