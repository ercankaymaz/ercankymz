using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_NestSheetShapeAdd : Form
{
	public static List<string> Captions = new List<string>();

	public FormProperties PropertiesForm = new FormProperties();

	public buNestingSheet Sheet = new buNestingSheet();

	public buNestingVar Settings = new buNestingVar();

	private Design design_0 = null;

	private Timer timer_0 = new Timer();

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal Panel panel_0;

	internal Label label_1;

	internal Button button_0;

	internal ImageList imageList_0;

	internal Button button_1;

	internal Label label_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_0;

	internal Panel panel_1;

	internal Label label_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_2;

	internal Label label_6;

	internal Panel panel_3;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	public TextBox txt_name;

	public F_NestSheetShapeAdd()
	{
		buFunctions.CultureSettings();
		Class186.smethod_805(this);
		timer_0.Tick += timer_0_Tick;
	}

	internal void method_0(object sender, EventArgs e)
	{
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
		numericUpDown_0.Value = Settings.AddMaterial.Quantity;
		numericUpDown_1.Value = (decimal)Settings.AddMaterial.Thickness;
		txt_name.Text = Settings.AddMaterial.Name;
		checkBox_0.Checked = Settings.AddMaterial.AddUselessEntities;
		checkBox_1.Checked = Settings.AddMaterial.DeleteSelectedEntities;
		LoadLanguage();
		if (design_0 == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = false;
			eyeCreateProps.ShowCoordinateArrow = false;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref design_0);
			design_0.Dock = DockStyle.Fill;
			if (panel_3.Controls.Count == 0)
			{
				panel_3.Controls.Add(design_0);
			}
		}
		timer_0.Interval = 50;
		timer_0.Enabled = true;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		buCall.buVector5_0.DrawSheet(Sheet, Settings, ref design_0);
	}

	public void LoadLanguage()
	{
		string callMethod = "NestSheetAdd LoadLanguage";
		try
		{
			if (Captions.Count >= 7)
			{
				Text = Captions[0];
				label_1.Text = Captions[1];
				label_5.Text = Captions[2];
				label_3.Text = Captions[3];
				checkBox_0.Text = Captions[4];
				checkBox_1.Text = Captions[5];
				button_0.Text = Captions[6];
				button_1.Text = Captions[7];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_0.Name)
		{
			Settings.AddMaterial.Quantity = (int)numericUpDown_0.Value;
			Settings.AddMaterial.Thickness = (double)numericUpDown_1.Value;
			Settings.AddMaterial.AddUselessEntities = checkBox_0.Checked;
			Settings.AddMaterial.DeleteSelectedEntities = checkBox_1.Checked;
			Sheet.MaterialData.Thickness = (double)numericUpDown_1.Value;
			Sheet.MaterialData.Quantity = (int)numericUpDown_0.Value;
			Sheet.MaterialData.Name = txt_name.Text;
			if (Sheet.MaterialData.Quantity <= 0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[37]);
				return;
			}
			if (Sheet.MaterialData.Width <= 0.0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[38]);
				return;
			}
			if (Sheet.MaterialData.Height <= 0.0)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[39]);
				return;
			}
			if ((Sheet.MaterialData.Thickness <= 0.0) & panel_2.Visible)
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[40]);
				return;
			}
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
		if (control.Name == button_1.Name)
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

	internal void method_2(object sender, FormClosingEventArgs e)
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

	internal void method_3(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			buNestingVar buNestingVar2 = new buNestingVar(Settings);
			buNestingVar2.Draw.SheetUselessShow = checkBox_0.Checked;
			buCall.buVector5_0.DrawSheet(Sheet, buNestingVar2, ref design_0);
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
