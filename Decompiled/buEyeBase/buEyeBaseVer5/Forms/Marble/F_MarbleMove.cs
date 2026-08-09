using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using ns71;

namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleMove : Form
{
	[CompilerGenerated]
	private OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler_0;

	public Color SpinBaseColor = Color.LightGreen;

	public Color SpinFocusColor = Color.MistyRose;

	public double AngleValue = 0.0;

	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	private IContainer icontainer_0 = null;

	public buButton btn_movedown;

	public buSpin spn_move;

	internal buPanel buPanel_0;

	public buButton btn_rotateccw;

	public buButton btn_moveleft;

	public buButton btn_moveup;

	public buButton btn_rotatecw;

	public buButton btn_moveright;

	public buSpin spn_rotate;

	internal buGround buGround_0;

	public buButton btn_close;

	public buButton btn_ok;

	public buButton btn_cancel;

	public event OkCommandWithThreeDataEventHandler CommandExecute
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Combine(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Remove(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
	}

	public F_MarbleMove()
	{
		Class186.smethod_668(this);
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
		spn_move.Value = AngleValue;
		LoadLanguage();
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		try
		{
			Text = buLangTranslate.preDef.Move;
			spn_move.Caption.Caption = buLangTranslate.preDef.Move;
			spn_rotate.Caption.Caption = buLangTranslate.preDef.Rotate;
		}
		catch (Exception)
		{
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				okCommandWithThreeDataEventHandler_0("Close", null, null);
			}
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
		AngleValue = spn_move.Value;
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == btn_ok.Name)
		{
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				okCommandWithThreeDataEventHandler_0("MoveOk", null, null);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if ((control.Name == btn_cancel.Name) | (control.Name == btn_close.Name))
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					okCommandWithThreeDataEventHandler_0("Close", null, null);
				}
			}
		}
		if (control.Name == btn_movedown.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("MoveY", 0.0 - spn_move.Value, null);
		}
		if (control.Name == btn_moveup.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("MoveY", spn_move.Value, null);
		}
		if (control.Name == btn_moveleft.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("MoveX", 0.0 - spn_move.Value, null);
		}
		if (control.Name == btn_moveright.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("MoveX", spn_move.Value, null);
		}
		if (control.Name == btn_rotateccw.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("Rotate", spn_rotate.Value, null);
		}
		if (control.Name == btn_rotatecw.Name && okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("Rotate", 0.0 - spn_rotate.Value, null);
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
