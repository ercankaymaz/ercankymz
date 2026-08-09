using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Components.Marble;

public class buMarbleOPItem : UserControl
{
	private Color color_0 = Color.Gray;

	private Color color_1 = Color.LightGreen;

	private Color color_2 = Color.LightCoral;

	private int int_0 = -1;

	private bool bool_0 = false;

	[CompilerGenerated]
	private ItemCommandEventHandler itemCommandEventHandler_0;

	public bool OperationEnable = false;

	public bool OperationSelected = false;

	public string OperationName = "-";

	public int OperationIndex = -1;

	public int OperationID = -1;

	public string OperationInfo = "";

	private IContainer icontainer_0 = null;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	internal buCheckBox buCheckBox_0;

	internal buButton buButton_3;

	internal buPanel buPanel_0;

	internal buButton buButton_4;

	internal buButton buButton_5;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "Gray")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color OperationItemColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "LightGreen")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color SelectedItemColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(Color), "LightCoral")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public Color DisableColor
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(typeof(int), "-1")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public int IndexControl
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public event ItemCommandEventHandler ItemCommand
	{
		[CompilerGenerated]
		add
		{
			ItemCommandEventHandler itemCommandEventHandler = itemCommandEventHandler_0;
			ItemCommandEventHandler itemCommandEventHandler2;
			do
			{
				itemCommandEventHandler2 = itemCommandEventHandler;
				ItemCommandEventHandler value2 = (ItemCommandEventHandler)Delegate.Combine(itemCommandEventHandler2, value);
				itemCommandEventHandler = Interlocked.CompareExchange(ref itemCommandEventHandler_0, value2, itemCommandEventHandler2);
			}
			while ((object)itemCommandEventHandler != itemCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ItemCommandEventHandler itemCommandEventHandler = itemCommandEventHandler_0;
			ItemCommandEventHandler itemCommandEventHandler2;
			do
			{
				itemCommandEventHandler2 = itemCommandEventHandler;
				ItemCommandEventHandler value2 = (ItemCommandEventHandler)Delegate.Remove(itemCommandEventHandler2, value);
				itemCommandEventHandler = Interlocked.CompareExchange(ref itemCommandEventHandler_0, value2, itemCommandEventHandler2);
			}
			while ((object)itemCommandEventHandler != itemCommandEventHandler2);
		}
	}

	public buMarbleOPItem()
	{
		Class76.smethod_637(this);
		buCheckBox_0.CheckedChanged += buCheckBox_0_CheckedChanged;
		buButton_0.Click += buButton_0_Click;
		buButton_0.DoubleClick += buButton_0_DoubleClick;
		buButton_3.Click += buButton_3_Click;
		buButton_1.Click += buButton_5_Click;
		buButton_2.Click += buButton_5_Click;
		buButton_4.Click += buButton_5_Click;
		buButton_5.Click += buButton_5_Click;
	}

	public void UpdateControl()
	{
		bool_0 = true;
		buButton_0.Text = OperationName;
		if (!OperationEnable)
		{
			buButton_0.Display.BackColor = color_2;
			buButton_0.ButtonDownDisplay.BackColor = buImage.ColorToneChange(color_2, 0.9);
			buButton_0.ButtonOverDisplay.BackColor = buImage.ColorToneChange(color_2, 1.1);
			buCheckBox_0.Display.BackColor = color_2;
		}
		else if (!OperationSelected)
		{
			buButton_0.Display.BackColor = color_0;
			buButton_0.ButtonDownDisplay.BackColor = buImage.ColorToneChange(color_0, 0.9);
			buButton_0.ButtonOverDisplay.BackColor = buImage.ColorToneChange(color_0, 1.1);
			buCheckBox_0.Display.BackColor = color_0;
		}
		else
		{
			buButton_0.Display.BackColor = color_1;
			buButton_0.ButtonDownDisplay.BackColor = buImage.ColorToneChange(color_1, 0.9);
			buButton_0.ButtonOverDisplay.BackColor = buImage.ColorToneChange(color_1, 1.1);
			buCheckBox_0.Display.BackColor = color_1;
		}
		buCheckBox_0.Check = OperationEnable;
		bool_0 = false;
	}

	private void buButton_0_Click(object sender, EventArgs e)
	{
		if (((itemCommandEventHandler_0 != null) & !bool_0) && OperationID >= 1)
		{
			OperationIndex = IndexControl;
			if (!OperationSelected)
			{
				OperationSelected = true;
			}
			else
			{
				OperationSelected = false;
			}
			UpdateControl();
			itemCommandEventHandler_0(this, new ItemCommandEventArgs(MarbleOperationMenuCommands.IndexChanged, OperationIndex, buCheckBox_0.Check, OperationID, IndexControl, OperationSelected));
		}
	}

	private void buButton_5_Click(object sender, EventArgs e)
	{
		if ((itemCommandEventHandler_0 != null) & !bool_0)
		{
			Control control = sender as Control;
			if (control.Name == buButton_1.Name)
			{
				buPanel_0.Visible = false;
				itemCommandEventHandler_0(this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Up, OperationIndex, buCheckBox_0.Check, OperationID, IndexControl, OperationSelected));
			}
			if (control.Name == buButton_2.Name)
			{
				buPanel_0.Visible = false;
				itemCommandEventHandler_0(this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Down, OperationIndex, buCheckBox_0.Check, OperationID, IndexControl, OperationSelected));
			}
			if (control.Name == buButton_4.Name)
			{
				buPanel_0.Visible = false;
				itemCommandEventHandler_0(this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Edit, OperationIndex, buCheckBox_0.Check, OperationID, IndexControl, OperationSelected));
			}
			if (control.Name == buButton_5.Name)
			{
				buPanel_0.Visible = false;
				itemCommandEventHandler_0(this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Delete, OperationIndex, buCheckBox_0.Check, OperationID, IndexControl, OperationSelected));
			}
		}
	}

	private void buButton_3_Click(object sender, EventArgs e)
	{
		if (!buPanel_0.Visible)
		{
			buPanel_0.Visible = true;
		}
		else
		{
			buPanel_0.Visible = false;
		}
	}

	private void buButton_0_DoubleClick(object sender, EventArgs e)
	{
	}

	private void buCheckBox_0_CheckedChanged(object object_0, bool bool_1)
	{
		if (bool_0)
		{
			return;
		}
		OperationIndex = IndexControl;
		OperationEnable = bool_1;
		UpdateControl();
		if (itemCommandEventHandler_0 != null)
		{
			if (!buCheckBox_0.Check)
			{
				itemCommandEventHandler_0(this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Disable, OperationIndex, buCheckBox_0.Check, OperationID, IndexControl, OperationSelected));
			}
			else
			{
				itemCommandEventHandler_0(this, new ItemCommandEventArgs(MarbleOperationMenuCommands.Enable, OperationIndex, buCheckBox_0.Check, OperationID, IndexControl, OperationSelected));
			}
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
