using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_AnalyseSettings : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public AnalyseEntitiesSetting Settings = new AnalyseEntitiesSetting();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	public NumericUpDown spn_entminlen;

	internal Label label_0;

	internal Label label_1;

	public NumericUpDown spn_gapminlen;

	internal Label label_2;

	public NumericUpDown spn_gapmaxlen;

	internal Label label_3;

	internal CheckBox checkBox_5;

	internal CheckBox checkBox_6;

	public NumericUpDown spn_intersectiongap;

	internal Label label_4;

	public F_AnalyseSettings()
	{
		Class186.smethod_814(this);
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
		spn_entminlen.Value = (decimal)Settings.EntityLengthLimit;
		spn_gapmaxlen.Value = (decimal)Settings.SmallGapMaxDistance;
		spn_gapminlen.Value = (decimal)Settings.SmallGapMinDistance;
		spn_intersectiongap.Value = (decimal)Settings.IntersectionGap;
		checkBox_0.Checked = Settings.FindProblems;
		checkBox_1.Checked = Settings.FixProblems;
		checkBox_3.Checked = Settings.isSameMoreThanOneCheck;
		checkBox_2.Checked = Settings.isSameMoreThanOneCheck;
		checkBox_4.Checked = Settings.isEntityLengthSmall;
		checkBox_5.Checked = Settings.isClosedEntities;
		checkBox_6.Checked = Settings.IntersectionEntities;
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
			Class186.smethod_443(this);
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
