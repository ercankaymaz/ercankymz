using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using ns71;

namespace buEyeBaseVer5.Forms.Door;

public class F_DoorMat : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public MaterialBase5 Material = new MaterialBase5();

	public Design viewportLayout;

	public SizeObject Case1 = new SizeObject();

	public SizeObject Case2 = new SizeObject();

	public static List<string> Captions = new List<string>();

	private Timer timer_0 = new Timer();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_4;

	public Panel pnl_model;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Label label_5;

	internal NumericUpDown numericUpDown_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_6;

	internal Label label_7;

	internal NumericUpDown numericUpDown_7;

	internal Label label_8;

	internal NumericUpDown numericUpDown_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_9;

	internal Label label_10;

	internal NumericUpDown numericUpDown_10;

	public F_DoorMat()
	{
		Class186.smethod_790(this);
	}

	public void Init(MaterialBase5 material)
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
		btn_ok.Enabled = false;
		if (material != null)
		{
			Material = new MaterialBase5(material);
		}
		LoadLanguage();
		PropertiesForm.Inited = false;
		label_0.Text = buLangTranslate.preDef.Door + " " + AppLanguage.CadCamDynamic[0] + " (X) ";
		label_1.Text = buLangTranslate.preDef.Door + " " + AppLanguage.CadCamDynamic[16] + " (Y) ";
		label_2.Text = buLangTranslate.preDef.Door + " " + AppLanguage.CadCamDynamic[113] + " (Z) ";
		label_3.Text = AppLanguage.CadCamDynamic[131] + " " + AppLanguage.CadCamDynamic[2];
		label_4.Text = AppLanguage.CadCamDynamic[132] + " " + AppLanguage.CadCamDynamic[2];
		viewportLayout.ActiveViewport.CoordinateSystemIcon.Visible = true;
		label_7.Text = "1. " + buLangTranslate.preDef.Case + " " + AppLanguage.CadCamDynamic[0] + " (X) ";
		label_6.Text = "1. " + buLangTranslate.preDef.Case + " " + AppLanguage.CadCamDynamic[16] + " (Y) ";
		label_5.Text = "1. " + buLangTranslate.preDef.Case + " " + AppLanguage.CadCamDynamic[113] + " (Z) ";
		label_10.Text = "2. " + buLangTranslate.preDef.Case + " " + AppLanguage.CadCamDynamic[0] + " (X) ";
		label_9.Text = "2. " + buLangTranslate.preDef.Case + " " + AppLanguage.CadCamDynamic[16] + " (Y) ";
		label_8.Text = "2. " + buLangTranslate.preDef.Case + " " + AppLanguage.CadCamDynamic[113] + " (Z) ";
		numericUpDown_0.Value = (decimal)Material.Size.Width;
		numericUpDown_1.Value = (decimal)Material.Size.Height;
		numericUpDown_2.Value = (decimal)Material.Size.Depth;
		numericUpDown_3.Value = (decimal)Material.FrontAngle;
		numericUpDown_4.Value = (decimal)Material.BackAngle;
		if (Material.Purpose != MaterialPurpose.Door)
		{
			radioButton_1.Checked = true;
		}
		else
		{
			radioButton_0.Checked = true;
		}
		numericUpDown_7.Value = (decimal)Case1.Width;
		numericUpDown_6.Value = (decimal)Case1.Height;
		numericUpDown_5.Value = (decimal)Case1.Depth;
		numericUpDown_10.Value = (decimal)Case2.Width;
		numericUpDown_9.Value = (decimal)Case2.Height;
		numericUpDown_8.Value = (decimal)Case2.Depth;
		timer_0.Interval = 100;
		timer_0.Tick += timer_0_Tick;
		timer_0.Enabled = true;
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
		if (control.Name == btn_ok.Name)
		{
			Material.Entities.Clear();
			for (int i = 0; i <= viewportLayout.Entities.Count - 1; i++)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(viewportLayout.Entities[i], ref copiedEnt);
				CustomData entityData = new CustomData();
				copiedEnt.EntityData = entityData;
				Material.Entities.Add(copiedEnt);
			}
			Apply();
			PropertiesForm.Result = DialogResult.OK;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
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

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Class186.smethod_521(this);
		btn_ok.Enabled = true;
		timer_0.Enabled = false;
	}

	public void Apply()
	{
		Material.Size.Width = (double)numericUpDown_0.Value;
		Material.Size.Height = (double)numericUpDown_1.Value;
		Material.Size.Depth = (double)numericUpDown_2.Value;
		Material.FrontAngle = (double)numericUpDown_3.Value;
		Material.BackAngle = (double)numericUpDown_4.Value;
		Case1.Width = (double)numericUpDown_7.Value;
		Case1.Height = (double)numericUpDown_6.Value;
		Case1.Depth = (double)numericUpDown_5.Value;
		Case2.Width = (double)numericUpDown_10.Value;
		Case2.Height = (double)numericUpDown_9.Value;
		Case2.Depth = (double)numericUpDown_8.Value;
		if (!radioButton_0.Checked)
		{
			Material.Purpose = MaterialPurpose.Case;
		}
		else
		{
			Material.Purpose = MaterialPurpose.Door;
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			Material.Size.Width = (double)numericUpDown_0.Value;
			Material.Size.Height = (double)numericUpDown_1.Value;
			Material.Size.Depth = (double)numericUpDown_2.Value;
			Material.FrontAngle = (double)numericUpDown_3.Value;
			Material.BackAngle = (double)numericUpDown_4.Value;
			Class186.smethod_521(this);
			PropertiesForm.Inited = true;
		}
	}

	internal void method_3(object sender, EventArgs e)
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
