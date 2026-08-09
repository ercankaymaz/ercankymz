using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.CAD;

public class F_Measure : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	[CompilerGenerated]
	private OkCommandWithDataEventHandler okCommandWithDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal ImageList imageList_0;

	internal PictureBox pictureBox_0;

	public TextBox txt_explanation;

	public Button btn_clear;

	public Button btn_vertex;

	public Button btn_entity;

	public Button btn_edge;

	public Button btn_face;

	public TreeView tree_item;

	public RadioButton radio_max;

	public RadioButton radio_min;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	public CheckBox chk_z;

	public CheckBox chk_y;

	public CheckBox chk_x;

	internal ImageList imageList_1;

	public Label lbl_selected;

	public Button btn_clearlast;

	public Button btn_points;

	public event OkCommandWithDataEventHandler CommandMeasure
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Combine(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithDataEventHandler okCommandWithDataEventHandler = okCommandWithDataEventHandler_0;
			OkCommandWithDataEventHandler okCommandWithDataEventHandler2;
			do
			{
				okCommandWithDataEventHandler2 = okCommandWithDataEventHandler;
				OkCommandWithDataEventHandler value2 = (OkCommandWithDataEventHandler)Delegate.Remove(okCommandWithDataEventHandler2, value);
				okCommandWithDataEventHandler = Interlocked.CompareExchange(ref okCommandWithDataEventHandler_0, value2, okCommandWithDataEventHandler2);
			}
			while ((object)okCommandWithDataEventHandler != okCommandWithDataEventHandler2);
		}
	}

	public F_Measure()
	{
		Class76.smethod_378(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		Properties.Result = DialogResult.None;
		LoadLangueage();
		Properties.Inited = true;
	}

	public void LoadLangueage()
	{
		string callMethod = "Report LoadLanguage";
		try
		{
			if (Captions.Count >= 8)
			{
				Text = Captions[0];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (btn_clear.Name == control.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0("clear");
		}
		if (btn_clearlast.Name == control.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0("clearlast");
		}
		if (btn_face.Name == control.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0("face");
		}
		if (btn_edge.Name == control.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0("edge");
		}
		if (btn_entity.Name == control.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0("entity");
		}
		if (btn_vertex.Name == control.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0("vertex");
		}
		if (btn_points.Name == control.Name && okCommandWithDataEventHandler_0 != null)
		{
			okCommandWithDataEventHandler_0("point");
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		new Control();
		if (Properties.Inited)
		{
			if (radio_min.Checked)
			{
				okCommandWithDataEventHandler_0("min");
			}
			if (radio_max.Checked)
			{
				okCommandWithDataEventHandler_0("max");
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!Properties.Inited)
		{
			return;
		}
		if (chk_x.Name == control.Name)
		{
			if (!chk_x.Checked)
			{
				okCommandWithDataEventHandler_0("xdisable");
			}
			else
			{
				okCommandWithDataEventHandler_0("xenable");
			}
		}
		if (chk_y.Name == control.Name)
		{
			if (!chk_y.Checked)
			{
				okCommandWithDataEventHandler_0("ydisable");
			}
			else
			{
				okCommandWithDataEventHandler_0("yenable");
			}
		}
		if (chk_z.Name == control.Name)
		{
			if (!chk_z.Checked)
			{
				okCommandWithDataEventHandler_0("zdisable");
			}
			else
			{
				okCommandWithDataEventHandler_0("zenable");
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
