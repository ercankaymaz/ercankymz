using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventVacuum : Form
{
	private string string_0 = "F_MarbleEventVacuum";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buGround ground_base;

	public buButton btn_close;

	public buButton btn_move_right;

	public buButton btn_move_left;

	public buButton btn_move_up;

	public buButton btn_move_rightdown;

	public buButton btn_move_down;

	public buButton btn_move_leftup;

	public buButton btn_move_leftdown;

	public buButton btn_move_rightup;

	public buSpin spn_moveval;

	public buButton btn_removevacuum;

	public buButton btn_addvacuum;

	public buListBox lst_vacuumlist;

	public event OkCommandWithFiveDataEventHandler VacuumCommand
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler = okCommandWithFiveDataEventHandler_0;
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler2;
			do
			{
				okCommandWithFiveDataEventHandler2 = okCommandWithFiveDataEventHandler;
				OkCommandWithFiveDataEventHandler value2 = (OkCommandWithFiveDataEventHandler)Delegate.Combine(okCommandWithFiveDataEventHandler2, value);
				okCommandWithFiveDataEventHandler = Interlocked.CompareExchange(ref okCommandWithFiveDataEventHandler_0, value2, okCommandWithFiveDataEventHandler2);
			}
			while ((object)okCommandWithFiveDataEventHandler != okCommandWithFiveDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler = okCommandWithFiveDataEventHandler_0;
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler2;
			do
			{
				okCommandWithFiveDataEventHandler2 = okCommandWithFiveDataEventHandler;
				OkCommandWithFiveDataEventHandler value2 = (OkCommandWithFiveDataEventHandler)Delegate.Remove(okCommandWithFiveDataEventHandler2, value);
				okCommandWithFiveDataEventHandler = Interlocked.CompareExchange(ref okCommandWithFiveDataEventHandler_0, value2, okCommandWithFiveDataEventHandler2);
			}
			while ((object)okCommandWithFiveDataEventHandler != okCommandWithFiveDataEventHandler2);
		}
	}

	public F_MarbleEventVacuum()
	{
		Class186.smethod_95(this);
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			if (buEyeVars.parVisual == null)
			{
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		if (!PropertiesForm.Updated)
		{
			UpdateVisuals();
			PropertiesForm.Updated = true;
		}
		if (PropertiesForm.Height > 10)
		{
			base.Height = PropertiesForm.Height;
		}
		if (PropertiesForm.Width > 10)
		{
			base.Width = PropertiesForm.Width;
		}
		base.TopMost = PropertiesForm.TopMost;
		base.StartPosition = PropertiesForm.FormPosition;
		spn_moveval.Value = buMarbleCalc.varMarbleRunSettings.AlignMoveValue;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			ground_base.Text = buLangTranslate.preDef.Vacuum;
			spn_moveval.Caption.Caption = buLangTranslate.preDef.Distance;
		}
		catch (Exception)
		{
		}
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

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (okCommandWithFiveDataEventHandler_0 != null)
		{
			buMarbleCalc.varMarbleRunSettings.AlignMoveValue = spn_moveval.Value;
			if (control.Name == btn_addvacuum.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.VacuumAdd, 0, MarbleVacuumCommands.Vacuum, null, null);
			}
			if (control.Name == btn_removevacuum.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.VacuumRemove, 0, MarbleVacuumCommands.Vacuum, null, null);
			}
			if (control.Name == btn_move_leftup.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeftUp, spn_moveval.Value, MarbleVacuumCommands.Move, null, null);
			}
			if (control.Name == btn_move_leftdown.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeftDown, spn_moveval.Value, MarbleVacuumCommands.Move, null, null);
			}
			if (control.Name == btn_move_left.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeft, spn_moveval.Value, MarbleVacuumCommands.Move, null, null);
			}
			if (control.Name == btn_move_up.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveUp, spn_moveval.Value, MarbleVacuumCommands.Move, null, null);
			}
			if (control.Name == btn_move_down.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveDown, spn_moveval.Value, MarbleVacuumCommands.Move, null, null);
			}
			if (control.Name == btn_move_right.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRight, spn_moveval.Value, MarbleVacuumCommands.Move, null, null);
			}
			if (control.Name == btn_move_rightdown.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRightDown, spn_moveval.Value, MarbleVacuumCommands.Move, null, null);
			}
			if (control.Name == btn_move_rightup.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRightUp, spn_moveval.Value, MarbleVacuumCommands.Move, null, null);
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
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

	internal void method_3(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString(), this);
			if (buNumeric5.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
				Focus();
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.VacuumChanged, lst_vacuumlist.SelectedIndex, MarbleVacuumCommands.Vacuum, null, null);
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
