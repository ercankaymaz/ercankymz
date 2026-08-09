using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.Forms.buControlForms.Marble;

public class F_ItemCutCamParameters : Form
{
	public static List<string> Captions = new List<string>();

	public marbleOperation Value = new marbleOperation();

	public DialogResult Result = DialogResult.None;

	private IContainer icontainer_0 = null;

	internal buGround buGround_0;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal buButton buButton_2;

	public buSpin spn_bwdvel;

	public buSpin spn_fwdvel;

	public buSpin spn_leadout;

	public buSpin spn_leadin;

	public buSpin spn_plungevel;

	public buSpin spn_matthickness;

	public buSpin spn_leavevel;

	public buSpin spn_backwardcutstep;

	public buSpin spn_forwardcutstep;

	public buComboBox cmb_cutdir;

	public buSpin spn_stepupdistance;

	public buSpin spn_safedistance;

	public F_ItemCutCamParameters()
	{
		Class76.smethod_673(this);
		spn_bwdvel.Click += spn_plungevel_Click;
		spn_fwdvel.Click += spn_plungevel_Click;
		spn_leadin.Click += spn_plungevel_Click;
		spn_leadout.Click += spn_plungevel_Click;
		spn_plungevel.Click += spn_plungevel_Click;
	}

	public void Init()
	{
		spn_bwdvel.Value = Value.CamParameters.BackwardCuttingVelocity;
		spn_fwdvel.Value = Value.CamParameters.ForwardCuttingVelocity;
		spn_leadin.Value = Value.CamParameters.FirstEnterDistance;
		spn_leadout.Value = Value.CamParameters.LastOutDistance;
		spn_plungevel.Value = Value.CamParameters.PlungeVelocity;
		spn_leavevel.Value = Value.CamParameters.LeaveVelocity;
		spn_matthickness.Value = Value.MaterialThickness;
		spn_forwardcutstep.Value = Value.CamParameters.ForwardStepDownDistance;
		spn_backwardcutstep.Value = Value.CamParameters.BackwardStepDownDistance;
		spn_safedistance.Value = Value.CamParameters.SafeDistance;
		spn_stepupdistance.Value = Value.CamParameters.StepUpDistance;
		LoadLanguage();
		ArrayList EnumItems = new ArrayList();
		buGeneral.GetEnumTypeValues(Value.CamParameters.CuttingDirection, ref EnumItems);
		buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32(Value.CamParameters.CuttingDirection), ref cmb_cutdir);
	}

	public void LoadLanguage()
	{
		try
		{
			if (Captions.Count > 14)
			{
				buGround_0.Text = Captions[0];
				spn_fwdvel.Caption.Caption = Captions[1];
				spn_bwdvel.Caption.Caption = Captions[2];
				spn_leadin.Caption.Caption = Captions[3];
				spn_leadout.Caption.Caption = Captions[4];
				spn_plungevel.Caption.Caption = Captions[5];
				spn_leavevel.Caption.Caption = Captions[6];
				spn_forwardcutstep.Caption.Caption = Captions[7];
				spn_backwardcutstep.Caption.Caption = Captions[8];
				spn_matthickness.Caption.Caption = Captions[9];
				spn_safedistance.Caption.Caption = Captions[10];
				spn_stepupdistance.Caption.Caption = Captions[11];
				cmb_cutdir.Caption.Caption = Captions[12];
				buButton_1.Text = Captions[13];
				buButton_2.Text = Captions[14];
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_0(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(buGround_0.Controls, result, e.Shift);
		}
	}

	internal void spn_plungevel_Click(object sender, EventArgs e)
	{
		try
		{
			if (AppBool.TouchPad)
			{
				buSpin buSpin2 = new buSpin();
				buSpin2 = (buSpin)sender;
				buControlCommands.ShowKeyPad(this, buSpin2);
			}
		}
		catch (Exception ee)
		{
			string message = "";
			CalculationErrorEventArg calcError = new CalculationErrorEventArg(showmessage: true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ee);
			buException.throwException(calcError, ShowMessageBox: true);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Value.CamParameters.BackwardCuttingVelocity = spn_bwdvel.Value;
		Value.CamParameters.ForwardCuttingVelocity = spn_fwdvel.Value;
		Value.CamParameters.FirstEnterDistance = spn_leadin.Value;
		Value.CamParameters.LastOutDistance = spn_leadout.Value;
		Value.CamParameters.PlungeVelocity = spn_plungevel.Value;
		Value.CamParameters.LeaveVelocity = spn_leavevel.Value;
		Value.MaterialThickness = spn_matthickness.Value;
		Value.CamParameters.ForwardStepDownDistance = spn_forwardcutstep.Value;
		Value.CamParameters.BackwardStepDownDistance = spn_backwardcutstep.Value;
		Value.CamParameters.SafeDistance = spn_safedistance.Value;
		Value.CamParameters.StepUpDistance = spn_stepupdistance.Value;
		Value.CamParameters.CuttingDirection = (CamCuttingDirectionType)buGeneral.EnumValueFromInt(Value.CamParameters.CuttingDirection, cmb_cutdir.SelectedIndex);
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_2(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
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
