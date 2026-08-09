using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventAling : Form
{
	private string string_0 = "F_MarbleViewV1";

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public buGround ground_base;

	public buButton btn_close;

	public buSpin spn_magnetoffset;

	public buButton btn_magnet_rightup;

	public buButton btn_magnet_leftdown;

	public buButton btn_magnet_leftup;

	public buButton btn_magnet_down;

	internal buTab buTab_0;

	internal TabPage tabPage_0;

	internal TabPage tabPage_1;

	public buButton btn_move;

	public buButton btn_magnet;

	public buButton btn_side;

	public buButton btn_magnet_rightdown;

	public buButton btn_magnet_right;

	public buButton btn_magnet_left;

	public buButton btn_magnet_up;

	public buButton btn_move_right;

	public buButton btn_move_left;

	public buButton btn_move_up;

	public buButton btn_move_rightdown;

	public buButton btn_move_down;

	public buButton btn_move_leftup;

	public buButton btn_move_leftdown;

	public buButton btn_move_rightup;

	internal TabPage tabPage_2;

	public buButton btn_side_right;

	public buButton btn_side_left;

	public buButton btn_side_up;

	public buButton btn_side_down;

	public buButton btn_side_centerver;

	public buButton btn_side_centerhor;

	public buSpin spn_moveval;

	public buSpin spn_sideoffset;

	public event OkCommandWithFiveDataEventHandler AlingCommand
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

	public F_MarbleEventAling()
	{
		Class186.smethod_471(this);
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			buTab_0.ItemSize = new Size(1, 1);
			tabPage_0.Text = "";
			tabPage_1.Text = "";
			tabPage_2.Text = "";
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
		spn_magnetoffset.Value = buMarbleCalc.varMarbleRunSettings.AlignMagnetOffset;
		spn_moveval.Value = buMarbleCalc.varMarbleRunSettings.AlignMoveValue;
		spn_sideoffset.Value = buMarbleCalc.varMarbleRunSettings.AlignSideOffset;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			ground_base.Text = buLangTranslate.preDef.Alignment;
			spn_magnetoffset.Caption.Caption = buLangTranslate.preDef.Offset;
			spn_moveval.Caption.Caption = buLangTranslate.preDef.Distance;
			spn_sideoffset.Caption.Caption = buLangTranslate.preDef.Offset;
			btn_magnet.Text = buLangTranslate.preDef.Magnet;
			btn_move.Text = buLangTranslate.preDef.Move;
			btn_side.Text = buLangTranslate.preDef.Side;
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
			buMarbleCalc.varMarbleRunSettings.AlignMagnetOffset = spn_magnetoffset.Value;
			buMarbleCalc.varMarbleRunSettings.AlignMoveValue = spn_moveval.Value;
			buMarbleCalc.varMarbleRunSettings.AlignSideOffset = spn_sideoffset.Value;
			if (control.Name == btn_magnet_leftup.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MagnetLeftUp, spn_magnetoffset.Value, MarbleAlingmentCommands.Magnet, null, null);
			}
			if (control.Name == btn_magnet_leftdown.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MagnetLeftDown, spn_magnetoffset.Value, MarbleAlingmentCommands.Magnet, null, null);
			}
			if (control.Name == btn_magnet_left.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MagnetLeft, spn_magnetoffset.Value, MarbleAlingmentCommands.Magnet, null, null);
			}
			if (control.Name == btn_magnet_up.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MagnetUp, spn_magnetoffset.Value, MarbleAlingmentCommands.Magnet, null, null);
			}
			if (control.Name == btn_magnet_down.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MagnetDown, spn_magnetoffset.Value, MarbleAlingmentCommands.Magnet, null, null);
			}
			if (control.Name == btn_magnet_right.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MagnetRight, spn_magnetoffset.Value, MarbleAlingmentCommands.Magnet, null, null);
			}
			if (control.Name == btn_magnet_rightdown.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MagnetRightDown, spn_magnetoffset.Value, MarbleAlingmentCommands.Magnet, null, null);
			}
			if (control.Name == btn_magnet_rightup.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MagnetRightUp, spn_magnetoffset.Value, MarbleAlingmentCommands.Magnet, null, null);
			}
			if (control.Name == btn_move_leftup.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeftUp, spn_moveval.Value, MarbleAlingmentCommands.Move, null, null);
			}
			if (control.Name == btn_move_leftdown.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeftDown, spn_moveval.Value, MarbleAlingmentCommands.Move, null, null);
			}
			if (control.Name == btn_move_left.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeft, spn_moveval.Value, MarbleAlingmentCommands.Move, null, null);
			}
			if (control.Name == btn_move_up.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveUp, spn_moveval.Value, MarbleAlingmentCommands.Move, null, null);
			}
			if (control.Name == btn_move_down.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveDown, spn_moveval.Value, MarbleAlingmentCommands.Move, null, null);
			}
			if (control.Name == btn_move_right.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRight, spn_moveval.Value, MarbleAlingmentCommands.Move, null, null);
			}
			if (control.Name == btn_move_rightdown.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRightDown, spn_moveval.Value, MarbleAlingmentCommands.Move, null, null);
			}
			if (control.Name == btn_move_rightup.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRightUp, spn_moveval.Value, MarbleAlingmentCommands.Move, null, null);
			}
			if (control.Name == btn_side_left.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.SideLeft, spn_sideoffset.Value, MarbleAlingmentCommands.Side, null, null);
			}
			if (control.Name == btn_side_up.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.SideUp, spn_sideoffset.Value, MarbleAlingmentCommands.Side, null, null);
			}
			if (control.Name == btn_side_down.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.SideDown, spn_sideoffset.Value, MarbleAlingmentCommands.Side, null, null);
			}
			if (control.Name == btn_side_right.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.SideRight, spn_sideoffset.Value, MarbleAlingmentCommands.Side, null, null);
			}
			if (control.Name == btn_side_centerhor.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.SideCenterHorizontal, spn_sideoffset.Value, MarbleAlingmentCommands.Side, null, null);
			}
			if (control.Name == btn_side_centerver.Name)
			{
				okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.SideCenterVertical, spn_sideoffset.Value, MarbleAlingmentCommands.Side, null, null);
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		Control.ControlCollection controls = ground_base.Controls;
		controls = hmiUICommands.SetVisualItem(controls);
		if (btn_magnet.Name == control.Name)
		{
			btn_magnet.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_magnet.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_magnet.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab_0.SelectedIndex = 0;
		}
		if (btn_move.Name == control.Name)
		{
			btn_move.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_move.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_move.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab_0.SelectedIndex = 1;
		}
		if (btn_side.Name == control.Name)
		{
			btn_side.Display.BackColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_side.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			btn_side.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
			buTab_0.SelectedIndex = 2;
		}
	}

	internal void method_3(object sender, EventArgs e)
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

	internal void method_4(object sender, EventArgs e)
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
