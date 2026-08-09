using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.Machine;

public class F_MachineSelect : Form
{
	public DialogResult Result = DialogResult.None;

	public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;

	public List<MachineType> Machines = new List<MachineType>();

	public int SelectedMachineIndex = 0;

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ListBox listBox_0;

	public F_MachineSelect()
	{
		Class76.smethod_411(this);
	}

	public void Init()
	{
		Result = DialogResult.Cancel;
		listBox_0.Items.Clear();
		for (int i = 0; i <= Machines.Count - 1; i++)
		{
			listBox_0.Items.Add(Machines[i].Name + " - ID: " + Machines[i].ID);
		}
		if ((SelectedMachineIndex >= 0) & (SelectedMachineIndex <= Machines.Count - 1))
		{
			listBox_0.SelectedIndex = SelectedMachineIndex;
		}
		Class76.smethod_449(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Result != DialogResult.OK)
		{
			e.Cancel = true;
			Result = DialogResult.Cancel;
			if (FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.OK;
		SelectedMachineIndex = listBox_0.SelectedIndex;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		if (FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
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
