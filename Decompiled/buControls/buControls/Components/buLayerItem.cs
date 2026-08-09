using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buControls.Controls;
using ns27;

namespace buControls.Components;

public class buLayerItem : UserControl
{
	private Color color_0;

	private Color color_1;

	private bool bool_0 = false;

	[CompilerGenerated]
	private buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler_0;

	public int LayerIndex = -1;

	public string LayerName = "Default";

	public Color LayerColor = Color.Blue;

	public bool LayerVisible = true;

	public bool LayerLock = false;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal CheckBox checkBox_0;

	internal Label label_1;

	internal CheckBox checkBox_1;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "Gray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color LayerNameItemColor
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "White")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color LayerColorItemColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			label_1.BackColor = color_1;
		}
	}

	public event buControlEvents.buLayerChangedEventHandler LayerChanged
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler = buLayerChangedEventHandler_0;
			buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler2;
			do
			{
				buLayerChangedEventHandler2 = buLayerChangedEventHandler;
				buControlEvents.buLayerChangedEventHandler value2 = (buControlEvents.buLayerChangedEventHandler)Delegate.Combine(buLayerChangedEventHandler2, value);
				buLayerChangedEventHandler = Interlocked.CompareExchange(ref buLayerChangedEventHandler_0, value2, buLayerChangedEventHandler2);
			}
			while ((object)buLayerChangedEventHandler != buLayerChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler = buLayerChangedEventHandler_0;
			buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler2;
			do
			{
				buLayerChangedEventHandler2 = buLayerChangedEventHandler;
				buControlEvents.buLayerChangedEventHandler value2 = (buControlEvents.buLayerChangedEventHandler)Delegate.Remove(buLayerChangedEventHandler2, value);
				buLayerChangedEventHandler = Interlocked.CompareExchange(ref buLayerChangedEventHandler_0, value2, buLayerChangedEventHandler2);
			}
			while ((object)buLayerChangedEventHandler != buLayerChangedEventHandler2);
		}
	}

	public event buControlEvents.buLayerDoubleClickEventHandler LayerDoubleClick
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler = buLayerDoubleClickEventHandler_0;
			buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler2;
			do
			{
				buLayerDoubleClickEventHandler2 = buLayerDoubleClickEventHandler;
				buControlEvents.buLayerDoubleClickEventHandler value2 = (buControlEvents.buLayerDoubleClickEventHandler)Delegate.Combine(buLayerDoubleClickEventHandler2, value);
				buLayerDoubleClickEventHandler = Interlocked.CompareExchange(ref buLayerDoubleClickEventHandler_0, value2, buLayerDoubleClickEventHandler2);
			}
			while ((object)buLayerDoubleClickEventHandler != buLayerDoubleClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler = buLayerDoubleClickEventHandler_0;
			buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler2;
			do
			{
				buLayerDoubleClickEventHandler2 = buLayerDoubleClickEventHandler;
				buControlEvents.buLayerDoubleClickEventHandler value2 = (buControlEvents.buLayerDoubleClickEventHandler)Delegate.Remove(buLayerDoubleClickEventHandler2, value);
				buLayerDoubleClickEventHandler = Interlocked.CompareExchange(ref buLayerDoubleClickEventHandler_0, value2, buLayerDoubleClickEventHandler2);
			}
			while ((object)buLayerDoubleClickEventHandler != buLayerDoubleClickEventHandler2);
		}
	}

	public buLayerItem()
	{
		Class76.smethod_91(this);
		base.Height = 25;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		checkBox_1.CheckedChanged += checkBox_1_CheckedChanged;
		label_0.Click += label_0_Click;
		label_0.DoubleClick += label_0_DoubleClick;
	}

	public void UpdateControl()
	{
		bool_0 = true;
		label_0.Text = LayerName;
		label_1.BackColor = LayerColor;
		checkBox_0.Checked = LayerVisible;
		checkBox_1.Checked = LayerLock;
		bool_0 = false;
	}

	private void label_0_Click(object sender, EventArgs e)
	{
		if ((buLayerChangedEventHandler_0 != null) & !bool_0)
		{
			LayerVisible = checkBox_0.Checked;
			LayerLock = checkBox_1.Checked;
			LayerName = label_0.Text;
			LayerColor = label_1.BackColor;
			buLayerChangedEventHandler_0(this, LayerColor, LayerVisible, LayerLock, LayerName, LayerIndex);
		}
	}

	private void label_0_DoubleClick(object sender, EventArgs e)
	{
		if ((buLayerDoubleClickEventHandler_0 != null) & !bool_0)
		{
			LayerVisible = checkBox_0.Checked;
			LayerLock = checkBox_1.Checked;
			LayerName = label_0.Text;
			LayerColor = label_1.BackColor;
			buLayerDoubleClickEventHandler_0(this, LayerColor, LayerVisible, LayerLock, LayerName, LayerIndex);
		}
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if ((buLayerChangedEventHandler_0 != null) & !bool_0)
		{
			LayerVisible = checkBox_0.Checked;
			LayerLock = checkBox_1.Checked;
			LayerName = label_0.Text;
			LayerColor = label_1.BackColor;
			buLayerChangedEventHandler_0(this, LayerColor, LayerVisible, LayerLock, LayerName, LayerIndex);
		}
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		if ((buLayerChangedEventHandler_0 != null) & !bool_0)
		{
			LayerVisible = checkBox_0.Checked;
			LayerLock = checkBox_1.Checked;
			LayerName = label_0.Text;
			LayerColor = label_1.BackColor;
			buLayerChangedEventHandler_0(this, LayerColor, LayerVisible, LayerLock, LayerName, LayerIndex);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
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
