using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_SortingSettings : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public SortSettings SortSetting = new SortSettings();

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal CheckBox checkBox_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal ComboBox comboBox_0;

	internal Label label_2;

	internal CheckBox checkBox_1;

	internal PictureBox pictureBox_0;

	public Button btn_cancel;

	internal ImageList imageList_0;

	public Button btn_ok;

	internal ComboBox comboBox_1;

	internal Label label_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_1;

	internal NumericUpDown numericUpDown_2;

	internal Label label_5;

	internal NumericUpDown numericUpDown_3;

	internal Label label_6;

	internal Label label_7;

	public F_SortingSettings()
	{
		Class186.smethod_767(this);
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
		comboBox_1.Items.Clear();
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[0]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[1]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[2]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[3]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[4]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[5]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[6]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[7]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[8]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[9]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[10]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[11]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[12]);
		comboBox_1.Items.Add(buClassLanguage.SortingNextGroupFindRulesType[13]);
		comboBox_1.SelectedIndex = Convert.ToInt32(SortSetting.Option.NextGroupRules);
		comboBox_0.Items.Clear();
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[0]);
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[1]);
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[2]);
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[3]);
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[4]);
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[5]);
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[6]);
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[7]);
		comboBox_0.Items.Add(buClassLanguage.SortingIntersectionRulesType[8]);
		comboBox_0.SelectedIndex = Convert.ToInt32(SortSetting.Option.IntersectionRules);
		checkBox_0.Checked = SortSetting.Option.isFirstPointCatchFromStartPointForDrawSequence;
		numericUpDown_0.Value = (decimal)SortSetting.Option.Resolution;
		numericUpDown_1.Value = (decimal)SortSetting.Option.ConstantPoint.X;
		numericUpDown_3.Value = (decimal)SortSetting.Option.ConstantPoint.Y;
		numericUpDown_2.Value = (decimal)SortSetting.Option.ConstantPoint.Z;
		ControlUpdate();
		LoadLanguage();
		pictureBox_0.Image = null;
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

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
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

	public void ControlUpdate()
	{
		checkBox_0.Enabled = false;
		if (comboBox_1.SelectedIndex == 11)
		{
			checkBox_0.Enabled = true;
		}
		panel_1.Enabled = false;
		if ((comboBox_1.SelectedIndex == 12) | (comboBox_1.SelectedIndex == 13))
		{
			panel_1.Enabled = true;
		}
	}

	public void Apply()
	{
		SortSetting.Option.NextGroupRules = (SortingNextGroupFindRulesType)comboBox_1.SelectedIndex;
		SortSetting.Option.IntersectionRules = (SortingIntersectionRulesType)comboBox_0.SelectedIndex;
		SortSetting.Option.isFirstPointCatchFromStartPointForDrawSequence = checkBox_0.Checked;
		SortSetting.Option.Resolution = (double)numericUpDown_0.Value;
		SortSetting.Option.ConstantPoint = new Point3D((double)numericUpDown_1.Value, (double)numericUpDown_3.Value, (double)numericUpDown_2.Value);
	}

	internal void method_1(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			PropertiesForm.Inited = true;
		}
	}

	internal void method_2(object sender, KeyEventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(control.Tag.ToString(), out result);
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (PropertiesForm.TouchPad & !checkBox_1.Checked)
		{
			NumericUpDown numericUpDown = new NumericUpDown();
			numericUpDown = (NumericUpDown)sender;
			if (numericUpDown.Enabled)
			{
			}
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			PropertiesForm.Inited = false;
			Apply();
			ControlUpdate();
			PropertiesForm.Inited = true;
			method_6(sender, null);
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		new Control();
		if (PropertiesForm.Inited)
		{
			PropertiesForm.Inited = false;
			Apply();
			ControlUpdate();
			PropertiesForm.Inited = true;
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		new Control();
		checkBox_1.Checked = false;
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
