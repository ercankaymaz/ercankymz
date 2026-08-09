using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleVacuumMove : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private string string_0 = "F_MarbleVacuumMove";

	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	internal IContainer icontainer_0 = null;

	public buButton btn_close;

	public buGround buGround1;

	public ImageList IC32;

	public buLabel lbl_moves;

	public buButton btn_gofwd;

	public buButton btn_gobwd;

	public buButton btn_goleft;

	public buButton btn_goright;

	public buSpin spn_distance;

	public buButton btn_goleftbwd;

	public buButton btn_gorightbwd;

	public buButton btn_goleftforward;

	public buButton btn_gorightforward;

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

	public F_MarbleVacuumMove()
	{
		Class186.smethod_65(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
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
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		Class186.smethod_40(this);
		UpdateVisuals();
	}

	public void UpdateVisuals()
	{
		string text = "UpdateVisuals";
		try
		{
			if (buEyeVars.parVisual == null)
			{
				return;
			}
			if (!PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce)
			{
				FileInfo fileInfo = new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm");
				if (fileInfo.Exists)
				{
					Control.ControlCollection controlCollection = null;
					controlCollection = buGround1.Controls;
					controlCollection = hmiUICommands.SetVisualItem(controlCollection);
					PropertiesForm.VisualUpdated = true;
				}
			}
			Class186.smethod_40(this);
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message, ex.Data.ToString(), 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
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
		try
		{
			Control control = sender as Control;
			if (!(control.Name == btn_close.Name))
			{
				if (okCommandWithFiveDataEventHandler_0 != null)
				{
					PropertiesForm.Result = DialogResult.OK;
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
					{
						Dispose();
					}
					if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
					{
						base.Visible = false;
					}
					if (control.Name == btn_goleft.Name)
					{
						okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeft, spn_distance.Value, MarbleVacuumCommands.Move, null, null);
					}
					if (control.Name == btn_gofwd.Name)
					{
						okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveUp, spn_distance.Value, MarbleVacuumCommands.Move, null, null);
					}
					if (control.Name == btn_gobwd.Name)
					{
						okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveDown, spn_distance.Value, MarbleVacuumCommands.Move, null, null);
					}
					if (control.Name == btn_goright.Name)
					{
						okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRight, spn_distance.Value, MarbleVacuumCommands.Move, null, null);
					}
					if (control.Name == btn_goleftbwd.Name)
					{
						okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeftDown, spn_distance.Value, MarbleVacuumCommands.Move, null, null);
					}
					if (control.Name == btn_goleftforward.Name)
					{
						okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveLeftUp, spn_distance.Value, MarbleVacuumCommands.Move, null, null);
					}
					if (control.Name == btn_gorightbwd.Name)
					{
						okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRightDown, spn_distance.Value, MarbleVacuumCommands.Move, null, null);
					}
					if (control.Name == btn_gorightforward.Name)
					{
						okCommandWithFiveDataEventHandler_0(MarbleCadCamCommands.MoveRightUp, spn_distance.Value, MarbleVacuumCommands.Move, null, null);
					}
				}
			}
			else
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
		}
		catch (Exception)
		{
		}
	}

	public void spn_Leave(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, EventArgs e)
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
