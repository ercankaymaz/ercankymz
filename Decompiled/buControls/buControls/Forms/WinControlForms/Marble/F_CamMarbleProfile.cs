using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Marble;

public class F_CamMarbleProfile : Form
{
	public FormProperties Properties = new FormProperties();

	public camParameters camPars = new camParameters();

	public marbleOperation Operation = new marbleOperation();

	public List<ToolBase> Tools = new List<ToolBase>();

	public int SelectedTool = 0;

	public static List<string> Captions = new List<string>();

	public bool ShowHelps = true;

	public bool ShowNextButton = true;

	public bool ShowPreButton = true;

	internal IContainer icontainer_0 = null;

	internal TabControl tabControl_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	internal TabPage tabPage_2;

	internal ImageList imageList_0;

	public Button btn_next;

	public Button btn_pre;

	public Button btn_cancel;

	public Button btn_ok;

	internal TextBox textBox_0;

	internal ListBox listBox_0;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_1;

	internal Label label_1;

	internal Panel panel_2;

	internal Label label_2;

	internal Panel panel_3;

	internal Label label_3;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal Panel panel_4;

	internal Label label_4;

	internal NumericUpDown numericUpDown_4;

	public F_CamMarbleProfile()
	{
		Class76.smethod_841(this);
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

	public void Init()
	{
		Properties.Inited = false;
		new ArrayList();
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		btn_next.Visible = ShowNextButton;
		btn_pre.Visible = ShowPreButton;
		numericUpDown_3.Value = (decimal)camPars.Speeds.Feed;
		numericUpDown_1.Value = (decimal)camPars.Speeds.Leave;
		numericUpDown_2.Value = (decimal)camPars.Speeds.Plunge;
		numericUpDown_0.Value = (decimal)camPars.Distances.Safe;
		numericUpDown_4.Value = (decimal)camPars.Distances.StepUp;
		if ((SelectedTool >= 0) & (SelectedTool <= Tools.Count - 1))
		{
			textBox_0.Text = buGeneral.GetToolExplanation(Tools[SelectedTool]);
			listBox_0.Items.Clear();
			for (int i = 0; i <= Tools.Count - 1; i++)
			{
				listBox_0.Items.Add(Tools[i].Data.Name + " - No : " + Tools[i].Data.No);
			}
			listBox_0.SelectedIndex = SelectedTool;
		}
		Refresh();
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		ControlUpdate();
		Class76.smethod_574(this);
	}

	public void ControlUpdate()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if (!Properties.Inited)
			{
				return;
			}
			if (Properties.ReadOnly)
			{
				Dispose();
				return;
			}
			Class76.smethod_9(this);
			Properties.Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
		{
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
		if (control.Name == btn_pre.Name && tabControl_0.SelectedIndex > 0)
		{
			tabControl_0.SelectedIndex--;
		}
		if (control.Name == btn_next.Name && tabControl_0.SelectedIndex < tabControl_0.TabPages.Count - 1)
		{
			tabControl_0.SelectedIndex++;
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
