using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileArrayCircular : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public ProfileOperationData OperationData = new ProfileOperationData();

	public bool CircularArrayVisible = false;

	internal IContainer icontainer_0 = null;

	public CheckBox chk_lineer;

	public Panel panel4;

	public Label label4;

	public Label label5;

	public NumericUpDown spn_linearlen;

	public NumericUpDown spn_linearcount;

	public CheckBox chk_circular;

	public Panel pnl_circular;

	public Label label3;

	public Label label1;

	public NumericUpDown spn_circularangle;

	public NumericUpDown spn_circularcount;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public F_ProfileArrayCircular()
	{
		Class186.smethod_478(this);
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
		spn_circularangle.Value = (decimal)OperationData.Array.CircularAngle;
		spn_circularcount.Value = OperationData.Array.CircularCount;
		spn_linearcount.Value = OperationData.Array.LineerXCount;
		spn_linearlen.Value = (decimal)OperationData.Array.LineerXDistance;
		chk_circular.Checked = OperationData.Array.CircularEnable;
		chk_lineer.Checked = OperationData.Array.LineerEnable;
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
			Class186.smethod_201(this);
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
