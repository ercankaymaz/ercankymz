using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns71;

namespace buEyeBaseVer5.Forms.Machine;

public class F_MachineGCodeCfg : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public MachineGCodeConfigrasyon GCodeCongif = new MachineGCodeConfigrasyon();

	internal string string_0 = "F_MachineGCodeCfg";

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ListBox listBox_0;

	internal Label label_0;

	public NumericUpDown spn_extratime;

	internal Label label_1;

	internal Label label_2;

	internal ListBox listBox_1;

	internal Label label_3;

	internal ListBox listBox_2;

	public Button btn_addaxis;

	public Button btn_removeaxis;

	public Button btn_removemcodes;

	public Button btn_addmcodes;

	public Button btn_removeothercodes;

	public Button btn_addothercodes;

	internal ComboBox comboBox_0;

	internal Label label_4;

	internal Label label_5;

	internal ComboBox comboBox_1;

	public F_MachineGCodeCfg()
	{
		Class186.smethod_198(this);
	}

	public void Init()
	{
		string text = string_0 + " Init";
		try
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
			listBox_0.Items.Clear();
			listBox_1.Items.Clear();
			listBox_2.Items.Clear();
			for (int i = 0; i <= GCodeCongif.AxesList.Count - 1; i++)
			{
				listBox_0.Items.Add(MachineAxisInfo.AxisToString(GCodeCongif.AxesList[i]));
			}
			for (int j = 0; j <= GCodeCongif.MCodeList.Count - 1; j++)
			{
				listBox_1.Items.Add(MachineMCodeInfo.MCodeToString(GCodeCongif.MCodeList[j]));
			}
			for (int k = 0; k <= GCodeCongif.OtherCodeList.Count - 1; k++)
			{
				listBox_2.Items.Add(MachineOtherCodeInfo.OtherCodeToString(GCodeCongif.OtherCodeList[k]));
			}
			spn_extratime.Value = (decimal)GCodeCongif.ExstraTime;
			List<string> list = new List<string>();
			list.AddRange(buConversion5.EnumToString(typeof(LengthUnit)));
			List<string> list2 = new List<string>();
			list2.AddRange(buConversion5.EnumToString(typeof(SpeedUnit)));
			for (int l = 0; l <= list.Count - 1; l++)
			{
				comboBox_0.Items.Add(list[l]);
			}
			comboBox_0.Text = GCodeCongif.LengthType.ToString();
			for (int m = 0; m <= list2.Count - 1; m++)
			{
				comboBox_1.Items.Add(list2[m]);
			}
			comboBox_1.Text = GCodeCongif.SpeedType.ToString();
			Properties.Result = DialogResult.None;
			Properties.Inited = true;
			LoadLangueage();
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
		}
	}

	public void LoadLangueage()
	{
		string text = string_0 + " LoadLangueage";
		try
		{
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
		}
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		string text = string_0 + " F_FormClosing";
		try
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
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		string text = string_0 + " btn_Click";
		try
		{
			Control control = sender as Control;
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
				Class186.smethod_541(this);
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
			if (control.Name == btn_addaxis.Name)
			{
				F_MachineAxisCfg f_MachineAxisCfg = new F_MachineAxisCfg();
				f_MachineAxisCfg.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_MachineAxisCfg.Properties.FormPosition = FormStartPosition.CenterParent;
				f_MachineAxisCfg.Axis = new MachineAxisInfo();
				f_MachineAxisCfg.Init();
				f_MachineAxisCfg.ShowDialog();
				if (f_MachineAxisCfg.Properties.Result == DialogResult.OK)
				{
					listBox_0.Items.Add(MachineAxisInfo.AxisToString(f_MachineAxisCfg.Axis));
					GCodeCongif.AxesList.Add(new MachineAxisInfo(f_MachineAxisCfg.Axis));
				}
			}
			if (control.Name == btn_removeaxis.Name && listBox_0.SelectedIndex >= 0 && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
			{
				listBox_0.Items.RemoveAt(listBox_0.SelectedIndex);
				GCodeCongif.AxesList.RemoveAt(listBox_0.SelectedIndex);
			}
			if (control.Name == btn_addmcodes.Name)
			{
				F_MachineMCodeCfg f_MachineMCodeCfg = new F_MachineMCodeCfg();
				f_MachineMCodeCfg.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_MachineMCodeCfg.Properties.FormPosition = FormStartPosition.CenterParent;
				f_MachineMCodeCfg.MCode = new MachineMCodeInfo();
				f_MachineMCodeCfg.Init();
				f_MachineMCodeCfg.ShowDialog();
				if (f_MachineMCodeCfg.Properties.Result == DialogResult.OK)
				{
					listBox_1.Items.Add(MachineMCodeInfo.MCodeToString(f_MachineMCodeCfg.MCode));
					GCodeCongif.MCodeList.Add(new MachineMCodeInfo(f_MachineMCodeCfg.MCode));
				}
			}
			if (control.Name == btn_removemcodes.Name && listBox_1.SelectedIndex >= 0 && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
			{
				listBox_1.Items.RemoveAt(listBox_1.SelectedIndex);
				GCodeCongif.MCodeList.RemoveAt(listBox_1.SelectedIndex);
			}
			if (control.Name == btn_addothercodes.Name)
			{
				F_MachineOtherCodeCfg f_MachineOtherCodeCfg = new F_MachineOtherCodeCfg();
				f_MachineOtherCodeCfg.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_MachineOtherCodeCfg.Properties.FormPosition = FormStartPosition.CenterParent;
				f_MachineOtherCodeCfg.OtherCode = new MachineOtherCodeInfo();
				f_MachineOtherCodeCfg.Init();
				f_MachineOtherCodeCfg.ShowDialog();
				if (f_MachineOtherCodeCfg.Properties.Result == DialogResult.OK)
				{
					listBox_2.Items.Add(MachineOtherCodeInfo.OtherCodeToString(f_MachineOtherCodeCfg.OtherCode));
					GCodeCongif.OtherCodeList.Add(new MachineOtherCodeInfo(f_MachineOtherCodeCfg.OtherCode));
				}
			}
			if (control.Name == btn_removeothercodes.Name && listBox_2.SelectedIndex >= 0 && buString5.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete) == DialogResult.Yes)
			{
				listBox_2.Items.RemoveAt(listBox_2.SelectedIndex);
				GCodeCongif.OtherCodeList.RemoveAt(listBox_2.SelectedIndex);
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
		}
	}

	internal void method_2(object sender, MouseEventArgs e)
	{
		string text = string_0 + " lst_MouseDoubleClick";
		try
		{
			Control control = sender as Control;
			if (control.Name == listBox_0.Name && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= GCodeCongif.AxesList.Count - 1)))
			{
				F_MachineAxisCfg f_MachineAxisCfg = new F_MachineAxisCfg();
				f_MachineAxisCfg.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_MachineAxisCfg.Properties.FormPosition = FormStartPosition.CenterParent;
				f_MachineAxisCfg.Axis = new MachineAxisInfo(GCodeCongif.AxesList[listBox_0.SelectedIndex]);
				f_MachineAxisCfg.Init();
				f_MachineAxisCfg.ShowDialog();
				if (f_MachineAxisCfg.Properties.Result == DialogResult.OK)
				{
					listBox_0.Items[listBox_0.SelectedIndex] = MachineAxisInfo.AxisToString(f_MachineAxisCfg.Axis);
					GCodeCongif.AxesList[listBox_0.SelectedIndex] = new MachineAxisInfo(f_MachineAxisCfg.Axis);
				}
			}
			if (control.Name == listBox_1.Name && ((listBox_1.SelectedIndex >= 0) & (listBox_1.SelectedIndex <= GCodeCongif.MCodeList.Count - 1)))
			{
				F_MachineMCodeCfg f_MachineMCodeCfg = new F_MachineMCodeCfg();
				f_MachineMCodeCfg.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_MachineMCodeCfg.Properties.FormPosition = FormStartPosition.CenterParent;
				f_MachineMCodeCfg.MCode = new MachineMCodeInfo(GCodeCongif.MCodeList[listBox_1.SelectedIndex]);
				f_MachineMCodeCfg.Init();
				f_MachineMCodeCfg.ShowDialog();
				if (f_MachineMCodeCfg.Properties.Result == DialogResult.OK)
				{
					listBox_1.Items[listBox_1.SelectedIndex] = MachineMCodeInfo.MCodeToString(f_MachineMCodeCfg.MCode);
					GCodeCongif.MCodeList[listBox_1.SelectedIndex] = new MachineMCodeInfo(f_MachineMCodeCfg.MCode);
				}
			}
			if (control.Name == listBox_2.Name && ((listBox_2.SelectedIndex >= 0) & (listBox_2.SelectedIndex <= GCodeCongif.AxesList.Count - 1)))
			{
				F_MachineOtherCodeCfg f_MachineOtherCodeCfg = new F_MachineOtherCodeCfg();
				f_MachineOtherCodeCfg.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_MachineOtherCodeCfg.Properties.FormPosition = FormStartPosition.CenterParent;
				f_MachineOtherCodeCfg.OtherCode = new MachineOtherCodeInfo(GCodeCongif.OtherCodeList[listBox_2.SelectedIndex]);
				f_MachineOtherCodeCfg.Init();
				f_MachineOtherCodeCfg.ShowDialog();
				if (f_MachineOtherCodeCfg.Properties.Result == DialogResult.OK)
				{
					listBox_2.Items[listBox_2.SelectedIndex] = MachineOtherCodeInfo.OtherCodeToString(f_MachineOtherCodeCfg.OtherCode);
					GCodeCongif.OtherCodeList[listBox_2.SelectedIndex] = new MachineOtherCodeInfo(f_MachineOtherCodeCfg.OtherCode);
				}
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Exception", ex.Message);
			buException.throwException(ex, text, ShowMessageBox: true);
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
