using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Cam;

public class F_CamTable : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MachineTableType CamTable = MachineTableType.OnlyA;

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	public F_CamTable()
	{
		Class186.smethod_779(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		button_0.BackColor = Color.LightGray;
		button_1.BackColor = Color.LightGray;
		button_2.BackColor = Color.LightGray;
		button_3.BackColor = Color.LightGray;
		if (CamTable == MachineTableType.OnlyA)
		{
			button_0.BackColor = Color.LemonChiffon;
		}
		if (CamTable == MachineTableType.OnlyB)
		{
			button_1.BackColor = Color.LemonChiffon;
		}
		if (CamTable == MachineTableType.SingleTable)
		{
			button_3.BackColor = Color.LemonChiffon;
		}
		if (CamTable == MachineTableType.TableAThenB)
		{
			button_2.BackColor = Color.LemonChiffon;
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 1)
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

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			CamTable = MachineTableType.OnlyA;
		}
		if (control.Name == button_1.Name)
		{
			CamTable = MachineTableType.OnlyB;
		}
		if (control.Name == button_2.Name)
		{
			CamTable = MachineTableType.TableAThenB;
		}
		if (control.Name == button_3.Name)
		{
			CamTable = MachineTableType.SingleTable;
		}
		Properties.Result = DialogResult.OK;
		if (Properties.FormCloseMode == FormCloseModeType.Dispose)
		{
			Dispose();
		}
		if (Properties.FormCloseMode == FormCloseModeType.Invisible)
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
