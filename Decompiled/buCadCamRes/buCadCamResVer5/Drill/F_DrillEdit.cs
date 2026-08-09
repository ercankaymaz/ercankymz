using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns8;

namespace buCadCamResVer5.Drill;

public class F_DrillEdit : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public bool isList = false;

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private ValueChangedWithDataEventHandler valueChangedWithDataEventHandler_0;

	public int RowIndex = -1;

	public int ColIndex = -1;

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Panel pnl_viewport;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	public Label lbl_z;

	public Label lbl_y;

	public Label lbl_x;

	public TreeView tree_jobs;

	internal ImageList imageList_1;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Panel panel_0;

	internal ImageList imageList_2;

	public DataGridView dgv_data;

	public Button btn_planeback;

	public Button btn_planeleft;

	public Button btn_planebottom;

	public Button btn_planefront;

	public Button btn_planetop;

	public Button btn_planeright;

	internal Label label_0;

	internal CheckBox checkBox_0;

	internal Button button_12;

	public event ValueChangedWithDataEventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler = valueChangedWithDataEventHandler_0;
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler2;
			do
			{
				valueChangedWithDataEventHandler2 = valueChangedWithDataEventHandler;
				ValueChangedWithDataEventHandler value2 = (ValueChangedWithDataEventHandler)Delegate.Combine(valueChangedWithDataEventHandler2, value);
				valueChangedWithDataEventHandler = Interlocked.CompareExchange(ref valueChangedWithDataEventHandler_0, value2, valueChangedWithDataEventHandler2);
			}
			while ((object)valueChangedWithDataEventHandler != valueChangedWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler = valueChangedWithDataEventHandler_0;
			ValueChangedWithDataEventHandler valueChangedWithDataEventHandler2;
			do
			{
				valueChangedWithDataEventHandler2 = valueChangedWithDataEventHandler;
				ValueChangedWithDataEventHandler value2 = (ValueChangedWithDataEventHandler)Delegate.Remove(valueChangedWithDataEventHandler2, value);
				valueChangedWithDataEventHandler = Interlocked.CompareExchange(ref valueChangedWithDataEventHandler_0, value2, valueChangedWithDataEventHandler2);
			}
			while ((object)valueChangedWithDataEventHandler != valueChangedWithDataEventHandler2);
		}
	}

	public F_DrillEdit()
	{
		Class5.smethod_28(this);
		timer_0.Tick += timer_0_Tick;
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		PropertiesForm.Inited = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
	}

	public object[] AddNewSheetRow(string Parameter, object Value, int baseIndex, int itemIndex)
	{
		return new object[4] { Parameter, Value, baseIndex, itemIndex };
	}

	internal void method_2(object sender, EventArgs e)
	{
	}

	internal void method_3(object sender, TreeViewEventArgs e)
	{
	}

	public void PlaneColor(planeBoxNames Plane)
	{
	}

	internal void method_4(object sender, EventArgs e)
	{
	}

	internal void method_5(object sender, DataGridViewCellEventArgs e)
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
