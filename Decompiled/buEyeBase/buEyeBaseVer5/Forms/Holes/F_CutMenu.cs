using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Holes;

public class F_CutMenu : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public drillCommands Commands = drillCommands.SingleHole;

	public drillCommandBase CommandsBase = drillCommandBase.Slot;

	public static List<string> Captions = new List<string>();

	private Timer timer_0 = new Timer();

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	public F_CutMenu()
	{
		Class186.smethod_295(this);
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
		ControlUpdate();
		LoadLanguage();
		PropertiesForm.Inited = false;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	public void LoadLanguage()
	{
		string callMethod = "LoadLanguage";
		try
		{
			if (Captions.Count >= 9)
			{
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
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_4.Name)
		{
			Commands = drillCommands.CutHorizontal;
			CommandsBase = drillCommandBase.Slot;
		}
		if (control.Name == button_2.Name)
		{
			Commands = drillCommands.CutFree;
			CommandsBase = drillCommandBase.Slot;
		}
		if (control.Name == button_3.Name)
		{
			Commands = drillCommands.CutVertical;
			CommandsBase = drillCommandBase.Slot;
		}
		if (control.Name == button_0.Name)
		{
			Commands = drillCommands.CutVerticalLine;
			CommandsBase = drillCommandBase.Slot;
		}
		if (control.Name == button_1.Name)
		{
			Commands = drillCommands.CutHorizontalLine;
			CommandsBase = drillCommandBase.Slot;
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
		{
			base.Visible = false;
		}
		PropertiesForm.Result = DialogResult.OK;
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
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
