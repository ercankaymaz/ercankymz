using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Jewellary;

public class F_ModeSelection : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<JewelVar> Modes = new List<JewelVar>();

	public string strDelete = "Do You Want to Delete Mode";

	public string strNotAllowedDelete = "You Can't Delete this Mode";

	public string strNotAllowedEdit = "You Can't Edit this Mode";

	public string strFolder = Application.StartupPath;

	public bool SpindleEnable = true;

	public bool Dia1Enable = true;

	public bool Dia2Enable = true;

	public bool EngraveEnable = true;

	public bool LaserEnable = true;

	public bool LatheEnable = true;

	private int int_0 = -1;

	private DataColumn dataColumn_0;

	private DataTable dataTable_0 = new DataTable();

	private IContainer icontainer_0 = null;

	public DataGridView DGV;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Button button_3;

	internal Button button_4;

	public F_ModeSelection()
	{
		Class76.smethod_662(this);
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
		base.AutoScaleMode = Properties.ScaleFromMode;
		dataTable_0 = new DataTable();
		dataColumn_0 = new DataColumn("No", Type.GetType("System.Int32"));
		dataTable_0.Columns.Add(dataColumn_0);
		dataColumn_0 = new DataColumn("Name", Type.GetType("System.String"));
		dataTable_0.Columns.Add(dataColumn_0);
		dataColumn_0 = new DataColumn("Prepare", Type.GetType("System.String"));
		dataTable_0.Columns.Add(dataColumn_0);
		dataColumn_0 = new DataColumn("Update", Type.GetType("System.String"));
		dataTable_0.Columns.Add(dataColumn_0);
		dataColumn_0 = new DataColumn("Delete", Type.GetType("System.String"));
		dataTable_0.Columns.Add(dataColumn_0);
		DGV.DataSource = dataTable_0;
		DGV.RowHeadersVisible = false;
		DGV.AllowUserToAddRows = false;
		DGV.AllowUserToResizeColumns = true;
		DGV.Columns[0].Width = 40;
		DGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV.Columns[1].Width = 200;
		DGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV.Columns[2].Width = 100;
		DGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV.Columns[3].Width = 100;
		DGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV.Columns[3].ReadOnly = true;
		DGV.Columns[4].Width = 100;
		DGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
		DGV.Columns[4].ReadOnly = true;
		for (int i = 0; i <= Modes.Count - 1; i++)
		{
			DataRowCollection rows = dataTable_0.Rows;
			ref DataTable reference = ref dataTable_0;
			string modeName = Modes[i].ModeName;
			string modePreparedBy = Modes[i].ModePreparedBy;
			rows.Add(Class76.smethod_753(modePreparedBy, ref reference, this, modeName, i + 1));
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_0(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			int_0 = e.RowIndex;
			if (e.ColumnIndex == 3 && ((int_0 >= 0) & (int_0 <= Modes.Count - 1)))
			{
				JewelVar jewelVar = new JewelVar(Modes[int_0]);
				if ((jewelVar.ModePreparedBy.ToLower() == "manufacturer") & (AppSecurity.PasswordLevel < 2))
				{
					buString.MessageBoxWarning(strNotAllowedEdit);
					return;
				}
				F_JewelWizardForModes f_JewelWizardForModes = new F_JewelWizardForModes();
				f_JewelWizardForModes.SpindleEnable = SpindleEnable;
				f_JewelWizardForModes.Dia1Enable = Dia1Enable;
				f_JewelWizardForModes.Dia2Enable = Dia2Enable;
				f_JewelWizardForModes.EngraveEnable = EngraveEnable;
				f_JewelWizardForModes.LaserEnable = LaserEnable;
				f_JewelWizardForModes.LatheEnable = LatheEnable;
				f_JewelWizardForModes.ParJewel = new JewelVar(Modes[int_0]);
				f_JewelWizardForModes.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_JewelWizardForModes.Init();
				f_JewelWizardForModes.ShowDialog();
				if (f_JewelWizardForModes.Properties.Result == DialogResult.OK)
				{
					JewelVar jewel = new JewelVar(f_JewelWizardForModes.ParJewel);
					Modes[int_0] = new JewelVar(jewel);
					dataTable_0.Rows.Clear();
					for (int i = 0; i <= Modes.Count - 1; i++)
					{
						DataRowCollection rows = dataTable_0.Rows;
						ref DataTable reference = ref dataTable_0;
						string modeName = Modes[i].ModeName;
						string modePreparedBy = Modes[i].ModePreparedBy;
						rows.Add(Class76.smethod_753(modePreparedBy, ref reference, this, modeName, i + 1));
					}
				}
			}
			if (e.ColumnIndex != 4 || !((int_0 >= 0) & (int_0 <= Modes.Count - 1)))
			{
				return;
			}
			JewelVar jewelVar2 = new JewelVar(Modes[int_0]);
			if (!((jewelVar2.ModePreparedBy.ToLower() == "manufacturer") & (AppSecurity.PasswordLevel < 2)))
			{
				if (buString.MessageBoxQuestion(strDelete) == DialogResult.Yes)
				{
					Modes.RemoveAt(int_0);
					dataTable_0.Rows.Clear();
					for (int j = 0; j <= Modes.Count - 1; j++)
					{
						DataRowCollection rows2 = dataTable_0.Rows;
						ref DataTable reference = ref dataTable_0;
						string modeName = Modes[j].ModeName;
						string modePreparedBy = Modes[j].ModePreparedBy;
						rows2.Add(Class76.smethod_753(modePreparedBy, ref reference, this, modeName, j + 1));
					}
				}
			}
			else
			{
				buString.MessageBoxWarning(strNotAllowedDelete);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
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
		if (!(control.Name == btn_cancel.Name))
		{
		}
		if (control.Name == button_0.Name)
		{
			F_JewelWizardForModes f_JewelWizardForModes = new F_JewelWizardForModes();
			f_JewelWizardForModes.SpindleEnable = SpindleEnable;
			f_JewelWizardForModes.Dia1Enable = Dia1Enable;
			f_JewelWizardForModes.Dia2Enable = Dia2Enable;
			f_JewelWizardForModes.EngraveEnable = EngraveEnable;
			f_JewelWizardForModes.LaserEnable = LaserEnable;
			f_JewelWizardForModes.LatheEnable = LatheEnable;
			f_JewelWizardForModes.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_JewelWizardForModes.Init();
			f_JewelWizardForModes.ShowDialog();
			if (f_JewelWizardForModes.Properties.Result == DialogResult.OK)
			{
				JewelVar jewelVar = new JewelVar(f_JewelWizardForModes.ParJewel);
				Modes.Add(jewelVar);
				DataRowCollection rows = dataTable_0.Rows;
				ref DataTable reference = ref dataTable_0;
				int count = Modes.Count;
				string modeName = jewelVar.ModeName;
				string modePreparedBy = jewelVar.ModePreparedBy;
				rows.Add(Class76.smethod_753(modePreparedBy, ref reference, this, modeName, count));
			}
		}
		if (control.Name == button_3.Name && ((int_0 >= 0) & (int_0 <= Modes.Count - 1)))
		{
			JewelVar jewelVar2 = new JewelVar(Modes[int_0]);
			Modes.Add(jewelVar2);
			DataRowCollection rows2 = dataTable_0.Rows;
			ref DataTable reference = ref dataTable_0;
			int count = Modes.Count;
			string modeName = jewelVar2.ModeName;
			string modePreparedBy = jewelVar2.ModePreparedBy;
			rows2.Add(Class76.smethod_753(modePreparedBy, ref reference, this, modeName, count));
		}
		if (control.Name == button_4.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = strFolder;
			openFileDialog.Multiselect = false;
			openFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				FileInfo fileInfo = new FileInfo(fileName);
				if (fileInfo.Exists)
				{
					strFolder = buFile.GetPath(openFileDialog.FileName);
					ArrayList arrayList = new ArrayList();
					TextReader textReader = System.IO.File.OpenText(fileInfo.FullName);
					string text = "";
					while ((text = textReader.ReadLine()) != null)
					{
						arrayList.Add(text);
					}
					textReader.Close();
					try
					{
						ArrayList CalcList = new ArrayList();
						buString.ListToSpecificList("<OperationMod>", "</OperationMod>", AddStartEndKey: true, arrayList, ref CalcList);
						if (CalcList.Count <= 0)
						{
							buLog.addLog("No Available Modes", "Not Ok", MethodBase.GetCurrentMethod().Name);
							buString.MessageBoxInfo("No Available Modes");
						}
						else
						{
							dataTable_0.Rows.Clear();
							List<List<string>> CalcList2 = new List<List<string>>();
							buString.ListToSpecificList("<JewelVar>", "</JewelVar>", AddStartEndKey: true, CalcList, ref CalcList2);
							if (CalcList2.Count <= 0)
							{
								buLog.addLog("No Available Modes", "Not Ok", MethodBase.GetCurrentMethod().Name);
								buString.MessageBoxInfo("No Available Modes");
							}
							else
							{
								for (int i = 0; i <= CalcList2.Count - 1; i++)
								{
									JewelVar jewelVar3 = new JewelVar();
									buSerilization.Decode(CalcList2[i], "", SerilizationMode.MultiLine, jewelVar3);
									Modes.Add(jewelVar3);
								}
								for (int j = 0; j <= Modes.Count - 1; j++)
								{
									DataRowCollection rows3 = dataTable_0.Rows;
									ref DataTable reference = ref dataTable_0;
									string modeName = Modes[j].ModeName;
									string modePreparedBy = Modes[j].ModePreparedBy;
									rows3.Add(Class76.smethod_753(modePreparedBy, ref reference, this, modeName, j + 1));
								}
							}
						}
					}
					catch (Exception mSException)
					{
						buLog.addLog("Open KutezDefault.cncuser", "Not Ok", MethodBase.GetCurrentMethod().Name);
						buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Open KutezDefault.cncuser");
					}
				}
			}
		}
		if (control.Name == button_2.Name)
		{
			OpenFileDialog openFileDialog2 = new OpenFileDialog();
			openFileDialog2.InitialDirectory = strFolder;
			openFileDialog2.Multiselect = false;
			openFileDialog2.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
			openFileDialog2.FilterIndex = 1;
			if (openFileDialog2.ShowDialog() == DialogResult.OK)
			{
				string fileName2 = openFileDialog2.FileName;
				FileInfo fileInfo2 = new FileInfo(fileName2);
				if (fileInfo2.Exists)
				{
					strFolder = buFile.GetPath(openFileDialog2.FileName);
					ArrayList arrayList2 = new ArrayList();
					TextReader textReader2 = System.IO.File.OpenText(fileInfo2.FullName);
					string text2 = "";
					while ((text2 = textReader2.ReadLine()) != null)
					{
						arrayList2.Add(text2);
					}
					textReader2.Close();
					try
					{
						ArrayList CalcList3 = new ArrayList();
						buString.ListToSpecificList("<OperationMod>", "</OperationMod>", AddStartEndKey: true, arrayList2, ref CalcList3);
						if (CalcList3.Count <= 0)
						{
							buLog.addLog("No Available Modes", "Not Ok", MethodBase.GetCurrentMethod().Name);
							buString.MessageBoxInfo("No Available Modes");
						}
						else
						{
							dataTable_0.Rows.Clear();
							List<List<string>> CalcList4 = new List<List<string>>();
							buString.ListToSpecificList("<JewelVar>", "</JewelVar>", AddStartEndKey: true, CalcList3, ref CalcList4);
							if (CalcList4.Count <= 0)
							{
								buLog.addLog("No Available Modes", "Not Ok", MethodBase.GetCurrentMethod().Name);
								buString.MessageBoxInfo("No Available Modes");
							}
							else
							{
								Modes.Clear();
								for (int k = 0; k <= CalcList4.Count - 1; k++)
								{
									JewelVar jewelVar4 = new JewelVar();
									buSerilization.Decode(CalcList4[k], "", SerilizationMode.MultiLine, jewelVar4);
									Modes.Add(jewelVar4);
								}
								for (int l = 0; l <= Modes.Count - 1; l++)
								{
									DataRowCollection rows4 = dataTable_0.Rows;
									ref DataTable reference = ref dataTable_0;
									string modeName = Modes[l].ModeName;
									string modePreparedBy = Modes[l].ModePreparedBy;
									rows4.Add(Class76.smethod_753(modePreparedBy, ref reference, this, modeName, l + 1));
								}
							}
						}
					}
					catch (Exception mSException2)
					{
						buLog.addLog("Open KutezDefault.cncuser", "Not Ok", MethodBase.GetCurrentMethod().Name);
						buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Open KutezDefault.cncuser");
					}
				}
			}
		}
		if (!(control.Name == button_1.Name))
		{
			return;
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = strFolder;
		saveFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			ArrayList arrayList3 = new ArrayList();
			arrayList3.Add("------------------------------------------------------------------------");
			arrayList3.Add("   Mods");
			arrayList3.Add("------------------------------------------------------------------------");
			arrayList3.Add("<OperationMod>");
			for (int m = 0; m <= Modes.Count - 1; m++)
			{
				arrayList3.AddRange(Modes[m].ToDefAll("", 2, SerilizationMode.MultiLine));
			}
			arrayList3.Add("</OperationMod>");
			buFile.SaveToFile(arrayList3, saveFileDialog.FileName);
			strFolder = buFile.GetPath(saveFileDialog.FileName);
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
