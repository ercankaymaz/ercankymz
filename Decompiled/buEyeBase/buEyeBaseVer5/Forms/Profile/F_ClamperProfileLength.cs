using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using ns71;

namespace buEyeBaseVer5.Forms.Profile;

public class F_ClamperProfileLength : Form
{
	public ProfileClamperSettings varProfileClamperSettings = new ProfileClamperSettings();

	public FormProperties Properties = new FormProperties();

	public string strPath = Application.StartupPath;

	public static List<string> Captions = new List<string>();

	private int int_0 = 0;

	public List<ProfileLengthClamperCount> Lengths = new List<ProfileLengthClamperCount>();

	public List<ProfileClamper> Clampers = new List<ProfileClamper>();

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_0;

	internal Button button_0;

	internal Label label_2;

	internal Button button_1;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Button button_2;

	internal Button button_3;

	internal ListBox listBox_0;

	internal Button button_4;

	public F_ClamperProfileLength()
	{
		Class186.smethod_376(this);
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
		listBox_0.Items.Clear();
		for (int i = 0; i <= Lengths.Count - 1; i++)
		{
			listBox_0.Items.Add(i + 1 + " - " + method_4(Lengths[i]));
		}
		Text = buLangTranslate.preDef.Clamp;
		label_2.Text = buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Length;
		label_0.Text = buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Length;
		label_1.Text = buLangTranslate.preDef.Clamp + " " + buLangTranslate.preDef.Count;
		btn_ok.Text = buLangTranslate.preDef.Ok;
		btn_cancel.Text = buLangTranslate.preDef.Cancel;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
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
				Class186.smethod_553(this);
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
			if (control.Name == button_4.Name)
			{
				Lengths[int_0].ProfileLength = (double)numericUpDown_0.Value;
				Lengths[int_0].ClamperCount = (int)numericUpDown_1.Value;
				new ArrayList();
				listBox_0.Items.Clear();
				for (int i = 0; i <= Lengths.Count - 1; i++)
				{
					listBox_0.Items.Add(i + 1 + " - " + method_4(Lengths[i]));
				}
			}
			if (control.Name == button_3.Name)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.InitialDirectory = strPath;
				openFileDialog.Filter = "Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
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
						for (int j = 0; j <= CalcList2.Count - 1; j++)
						{
							ArrayList arrayList = new ArrayList();
							arrayList.AddRange(CalcList2[j].ToArray());
							ProfileClamper profileClamper = new ProfileClamper();
							buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, profileClamper);
							Clampers.Add(profileClamper);
						}
						CalcList2 = new List<List<string>>();
						buString5.ListToSpecificList("<ProfileLengthCountData>", "</ProfileLengthCountData>", AddStartEndKey: true, StringList, ref CalcList2);
						Lengths.Clear();
						for (int k = 0; k <= CalcList2.Count - 1; k++)
						{
							ArrayList arrayList2 = new ArrayList();
							arrayList2.AddRange(CalcList2[k].ToArray());
							ProfileLengthClamperCount profileLengthClamperCount = new ProfileLengthClamperCount();
							buSerilization5.Decode(arrayList2, "", SerilizationMode5.MultiLine, profileLengthClamperCount);
							Lengths.Add(profileLengthClamperCount);
						}
						Init();
						CalcList2.Clear();
						StringList.Clear();
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
				saveFileDialog.Filter = "Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
				saveFileDialog.FilterIndex = 1;
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					strPath = buFile.GetPath(saveFileDialog.FileName);
					ArrayList arrayList3 = new ArrayList();
					arrayList3.Add("------------------------------------------------------------------------");
					arrayList3.Add("   Profile Settings");
					arrayList3.Add("------------------------------------------------------------------------");
					arrayList3.Add("<ProfileSettings>");
					arrayList3.AddRange(varProfileClamperSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
					arrayList3.Add("</ProfileSettings>");
					arrayList3.Add("------------------------------------------------------------------------");
					arrayList3.Add("   Clampers ");
					arrayList3.Add("------------------------------------------------------------------------");
					arrayList3.Add("  <Clampers>");
					for (int l = 0; l <= Clampers.Count - 1; l++)
					{
						arrayList3.AddRange(Clampers[l].ToDefAll("", 4, SerilizationMode5.MultiLine));
					}
					arrayList3.Add("  </Clampers>");
					arrayList3.Add("------------------------------------------------------------------------");
					arrayList3.Add("   ProfileLengthCount ");
					arrayList3.Add("------------------------------------------------------------------------");
					arrayList3.Add("  <ProfileLengthCountData>");
					for (int m = 0; m <= Lengths.Count - 1; m++)
					{
						arrayList3.AddRange(Lengths[m].ToDefAll("", 4, SerilizationMode5.MultiLine));
					}
					arrayList3.Add("  </ProfileLengthCountData>");
					buFile.SaveToFile(arrayList3, saveFileDialog.FileName);
					arrayList3.Clear();
				}
			}
			if (control.Name == button_0.Name)
			{
				ProfileLengthClamperCount item = new ProfileLengthClamperCount((double)numericUpDown_0.Value, (int)numericUpDown_1.Value);
				Lengths.Add(item);
				listBox_0.Items.Add(Lengths.Count + " - " + method_4(Lengths[Lengths.Count - 1]));
				listBox_0.SelectedIndex = Clampers.Count - 1;
			}
			if (control.Name == button_1.Name && ((int_0 >= 0) & (int_0 <= Lengths.Count - 1)) && buString.MessageBoxQuestion(buLangTranslate.preSentences.DoYouWantToDelete + " " + buLangTranslate.preDef.Length) == DialogResult.Yes)
			{
				Lengths.RemoveAt(int_0);
				listBox_0.Items.RemoveAt(int_0);
				int_0--;
				if (int_0 < 0)
				{
					int_0 = 0;
				}
				if (listBox_0.Items.Count > 0)
				{
					listBox_0.SelectedIndex = int_0;
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
				Lengths[listBox_0.SelectedIndex].ProfileLength = (double)numericUpDown_0.Value;
			}
			if (control.Name == numericUpDown_1.Name && ((int_0 >= 0) & (int_0 <= Clampers.Count - 1)))
			{
				Lengths[listBox_0.SelectedIndex].ClamperCount = (int)numericUpDown_1.Value;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.Inited && ((listBox_0.SelectedIndex >= 0) & (listBox_0.SelectedIndex <= Lengths.Count - 1)))
		{
			Properties.Inited = false;
			int_0 = listBox_0.SelectedIndex;
			numericUpDown_1.Value = Lengths[int_0].ClamperCount;
			numericUpDown_0.Value = (decimal)Lengths[listBox_0.SelectedIndex].ProfileLength;
			Properties.Inited = true;
		}
	}

	private string method_4(ProfileLengthClamperCount profileLengthClamperCount_0)
	{
		string text = "";
		return buLangTranslate.preDef.Profile + buLangTranslate.preDef.Length + " : " + profileLengthClamperCount_0.ProfileLength + " - " + buLangTranslate.preDef.Clamp + " " + buLangTranslate.preDef.Count + " : " + profileLengthClamperCount_0.ClamperCount;
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
