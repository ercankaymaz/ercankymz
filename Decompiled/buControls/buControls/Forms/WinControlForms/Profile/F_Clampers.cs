using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Profile;

public class F_Clampers : Form
{
	public ProfileClamperSettings varProfileClamperSettings = new ProfileClamperSettings();

	public FormProperties Properties = new FormProperties();

	public string strPath = Application.StartupPath;

	public static List<string> Captions = new List<string>();

	public static string msgRemove = "Do You Want to Remove This Clamper";

	private int int_0 = 0;

	public List<ProfileClamper> Clampers = new List<ProfileClamper>();

	internal IContainer icontainer_0 = null;

	internal CheckedListBox checkedListBox_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_0;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	internal Label label_3;

	internal NumericUpDown numericUpDown_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_4;

	internal Label label_5;

	internal NumericUpDown numericUpDown_5;

	internal Label label_6;

	internal Panel panel_1;

	internal Button button_0;

	internal Label label_7;

	internal Button button_1;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_8;

	internal NumericUpDown numericUpDown_6;

	internal Label label_9;

	internal NumericUpDown numericUpDown_7;

	internal Label label_10;

	internal NumericUpDown numericUpDown_8;

	internal Button button_2;

	internal Button button_3;

	public F_Clampers()
	{
		Class76.smethod_248(this);
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
		new ArrayList();
		checkedListBox_0.Items.Clear();
		for (int i = 0; i <= Clampers.Count - 1; i++)
		{
			checkedListBox_0.Items.Add(i + 1 + " - Min X: " + Clampers[i].MinPositionRange + " - Max X: " + Clampers[i].MaxPositionRange + " , W: " + Clampers[i].Width, Clampers[i].Enable);
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		numericUpDown_2.Value = (decimal)varProfileClamperSettings.EndOffset;
		numericUpDown_3.Value = (decimal)varProfileClamperSettings.StartOffset;
		numericUpDown_6.Value = (decimal)varProfileClamperSettings.ClamperWidth;
		numericUpDown_4.Value = (decimal)varProfileClamperSettings.MaxDistanceFor2Clamper;
		numericUpDown_5.Value = (decimal)varProfileClamperSettings.MinDistanceFor2Clamper;
		numericUpDown_7.Value = (decimal)varProfileClamperSettings.OperationMinDistance;
		numericUpDown_8.Value = (decimal)varProfileClamperSettings.MaxFreeDistanceForProfile;
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
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (control.Name == btn_ok.Name)
			{
				Class76.smethod_211(this);
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
			if (control.Name == button_3.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = strPath;
				openFileDialog.Filter = "buCad/Cam Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
				openFileDialog.FilterIndex = 1;
				openFileDialog.Multiselect = false;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					ArrayList StringList = new ArrayList();
					buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
					try
					{
						strPath = buFile.GetPath(openFileDialog.FileName);
						ArrayList CalcList = new ArrayList();
						buString.ListToSpecificList("<ProfileSettings>", "</ProfileSettings>", AddStartEndKey: true, StringList, ref CalcList);
						if (CalcList.Count > 0)
						{
							buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, varProfileClamperSettings);
						}
						List<List<string>> CalcList2 = new List<List<string>>();
						buString.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", AddStartEndKey: true, StringList, ref CalcList2);
						Clampers.Clear();
						for (int i = 0; i <= CalcList2.Count - 1; i++)
						{
							ArrayList arrayList = new ArrayList();
							arrayList.AddRange(CalcList2[i].ToArray());
							ProfileClamper profileClamper = new ProfileClamper();
							buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, profileClamper);
							Clampers.Add(profileClamper);
						}
						Init();
					}
					catch (Exception mSException)
					{
						buLog.addLog("Profile Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
						buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Profile Settings Decoder Error");
					}
				}
			}
			if (control.Name == button_2.Name)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.InitialDirectory = strPath;
				saveFileDialog.Filter = "buCad/Cam Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					strPath = buFile.GetPath(saveFileDialog.FileName);
					ArrayList arrayList2 = new ArrayList();
					arrayList2.Add("------------------------------------------------------------------------");
					arrayList2.Add("   Profile Settings");
					arrayList2.Add("------------------------------------------------------------------------");
					arrayList2.Add("<ProfileSettings>");
					arrayList2.AddRange(varProfileClamperSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
					arrayList2.Add("</ProfileSettings>");
					arrayList2.Add("------------------------------------------------------------------------");
					arrayList2.Add("   Clampers ");
					arrayList2.Add("------------------------------------------------------------------------");
					arrayList2.Add("  <Clampers>");
					for (int j = 0; j <= Clampers.Count - 1; j++)
					{
						arrayList2.AddRange(Clampers[j].ToDefAll("", 4, SerilizationMode.MultiLine));
					}
					arrayList2.Add("  </Clampers>");
					buFile.SaveToFile(arrayList2, saveFileDialog.FileName);
				}
			}
			if (control.Name == button_0.Name)
			{
				ProfileClamper item = new ProfileClamper();
				Clampers.Add(item);
				checkedListBox_0.Items.Add(Clampers.Count + " - Min X: " + Clampers[Clampers.Count - 1].MinPositionRange + " - Max X: " + Clampers[Clampers.Count - 1].MaxPositionRange + " , W: " + Clampers[Clampers.Count - 1].Width, Clampers[Clampers.Count - 1].Enable);
				checkedListBox_0.SelectedIndex = Clampers.Count - 1;
			}
			if (control.Name == button_1.Name && ((int_0 >= 0) & (int_0 <= Clampers.Count - 1)) && buString.MessageBoxQuestion(msgRemove) == DialogResult.Yes)
			{
				Clampers.RemoveAt(int_0);
				checkedListBox_0.Items.RemoveAt(int_0);
				int_0--;
				if (int_0 < 0)
				{
					int_0 = 0;
				}
				if (checkedListBox_0.Items.Count > 0)
				{
					checkedListBox_0.SelectedIndex = int_0;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited)
		{
			if (control.Name == numericUpDown_0.Name && ((int_0 >= 0) & (int_0 <= Clampers.Count - 1)))
			{
				Clampers[checkedListBox_0.SelectedIndex].MinPositionRange = (double)numericUpDown_0.Value;
			}
			if (control.Name == numericUpDown_1.Name && ((int_0 >= 0) & (int_0 <= Clampers.Count - 1)))
			{
				Clampers[checkedListBox_0.SelectedIndex].MaxPositionRange = (double)numericUpDown_1.Value;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.Inited && ((checkedListBox_0.SelectedIndex >= 0) & (checkedListBox_0.SelectedIndex <= Clampers.Count - 1)))
		{
			Properties.Inited = false;
			int_0 = checkedListBox_0.SelectedIndex;
			numericUpDown_1.Value = (decimal)Clampers[int_0].MaxPositionRange;
			numericUpDown_0.Value = (decimal)Clampers[checkedListBox_0.SelectedIndex].MinPositionRange;
			Properties.Inited = true;
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
