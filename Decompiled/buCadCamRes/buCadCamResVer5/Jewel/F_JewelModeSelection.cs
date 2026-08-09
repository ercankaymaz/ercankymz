using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5;
using ns8;

namespace buCadCamResVer5.Jewel;

public class F_JewelModeSelection : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public JewelMode CurrentModePars = new JewelMode();

	public string strDelete = "Do You Want to Delete Mode";

	public string strNotAllowedDelete = "You Can't Delete this Mode";

	public string strNotAllowedEdit = "You Can't Edit this Mode";

	public string strFolder = Application.StartupPath;

	private int int_0 = -1;

	private IContainer icontainer_0 = null;

	public DataGridView DGV;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Button button_3;

	public F_JewelModeSelection()
	{
		Class5.smethod_195(this);
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
		base.AutoScaleMode = PropertiesForm.ScaleFromMode;
		DGV.Columns.Clear();
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = 40;
		dataGridViewColumn.HeaderText = "No";
		dataGridViewColumn.Name = "No";
		dataGridViewColumn.ReadOnly = true;
		dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		DGV.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.Width = 200;
		dataGridViewColumn2.HeaderText = "Name";
		dataGridViewColumn2.Name = "Name";
		dataGridViewColumn2.ReadOnly = true;
		dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		DGV.Columns.Add(dataGridViewColumn2);
		DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
		dataGridViewColumn3.Width = 140;
		dataGridViewColumn3.HeaderText = "Prepare";
		dataGridViewColumn3.Name = "Prepare";
		dataGridViewColumn3.ReadOnly = true;
		dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
		DGV.Columns.Add(dataGridViewColumn3);
		DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
		dataGridViewColumn4.Width = 100;
		dataGridViewColumn4.HeaderText = "Update";
		dataGridViewColumn4.Name = "Update";
		dataGridViewColumn4.ReadOnly = true;
		dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
		DGV.Columns.Add(dataGridViewColumn4);
		DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
		dataGridViewColumn5.Width = 100;
		dataGridViewColumn5.HeaderText = "Delete";
		dataGridViewColumn5.Name = "Delete";
		dataGridViewColumn5.ReadOnly = true;
		dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
		dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn5.ReadOnly = false;
		DGV.Columns.Add(dataGridViewColumn5);
		dataGridViewColumn2.Width = DGV.Width - dataGridViewColumn.Width - dataGridViewColumn3.Width - dataGridViewColumn4.Width - dataGridViewColumn5.Width - 15;
		DGV.RowHeadersVisible = false;
		DGV.AllowUserToAddRows = false;
		DGV.AllowUserToResizeColumns = false;
		DGV.AllowUserToResizeRows = false;
		DGV.Rows.Clear();
		for (int i = 0; i <= clsJewel.JewelModes.Count - 1; i++)
		{
			DGV.Rows.Add((i + 1).ToString(), clsJewel.JewelModes[i].Name, clsJewel.JewelModes[i].Prepared, "Update", "Delete");
		}
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
	}

	internal void method_1(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			int_0 = e.RowIndex;
			if (e.ColumnIndex == 3 && ((int_0 >= 0) & (int_0 <= clsJewel.JewelModes.Count - 1)))
			{
				JewelMode jewelMode = new JewelMode(clsJewel.JewelModes[int_0]);
				if ((jewelMode.Prepared.ToLower() == "manufacturer") & (AppSecurity.PasswordLevel < 2))
				{
					buString5.MessageBoxWarning(strNotAllowedEdit);
					return;
				}
				F_JewelModes f_JewelModes = new F_JewelModes();
				f_JewelModes.CurrentModePars = new JewelMode(clsJewel.JewelModes[int_0]);
				f_JewelModes.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_JewelModes.Init();
				f_JewelModes.ShowDialog();
				if (f_JewelModes.PropertiesForm.Result == DialogResult.OK)
				{
					JewelMode data = new JewelMode(f_JewelModes.CurrentModePars);
					clsJewel.JewelModes[int_0] = new JewelMode(data);
					DGV.Rows.Clear();
					for (int i = 0; i <= clsJewel.JewelModes.Count - 1; i++)
					{
						DGV.Rows.Add((i + 1).ToString(), clsJewel.JewelModes[i].Name, clsJewel.JewelModes[i].Prepared, "Update", "Delete");
					}
				}
			}
			if (e.ColumnIndex != 4 || !((int_0 >= 0) & (int_0 <= clsJewel.JewelModes.Count - 1)))
			{
				return;
			}
			JewelMode jewelMode2 = new JewelMode(clsJewel.JewelModes[int_0]);
			if (!((jewelMode2.Prepared.ToLower() == "manufacturer") & (AppSecurity.PasswordLevel < 2)))
			{
				if (buString5.MessageBoxQuestion(strDelete) == DialogResult.Yes)
				{
					clsJewel.JewelModes.RemoveAt(int_0);
					DGV.Rows.Clear();
					for (int j = 0; j <= clsJewel.JewelModes.Count - 1; j++)
					{
						DGV.Rows.Add((j + 1).ToString(), clsJewel.JewelModes[j].Name, clsJewel.JewelModes[j].Prepared, "Update", "Delete");
					}
				}
			}
			else
			{
				buString5.MessageBoxWarning(strNotAllowedDelete);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			if ((int_0 >= 0) & (int_0 <= clsJewel.JewelModes.Count - 1))
			{
				CurrentModePars = new JewelMode(clsJewel.JewelModes[int_0]);
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
		if (control.Name == button_0.Name)
		{
			F_JewelModes f_JewelModes = new F_JewelModes();
			if (!((int_0 >= 0) & (int_0 <= clsJewel.JewelModes.Count - 1)))
			{
				f_JewelModes.CurrentModePars = new JewelMode(CurrentModePars);
			}
			else
			{
				f_JewelModes.CurrentModePars = new JewelMode(clsJewel.JewelModes[int_0]);
			}
			f_JewelModes.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
			f_JewelModes.Init();
			f_JewelModes.ShowDialog();
			if (f_JewelModes.PropertiesForm.Result == DialogResult.OK)
			{
				JewelMode jewelMode = new JewelMode(f_JewelModes.CurrentModePars);
				clsJewel.JewelModes.Add(jewelMode);
				DGV.Rows.Add(clsJewel.JewelModes.Count.ToString(), jewelMode.Name, jewelMode.Prepared, "Update", "Delete");
			}
		}
		if (control.Name == button_3.Name && ((int_0 >= 0) & (int_0 <= clsJewel.JewelModes.Count - 1)))
		{
			JewelMode jewelMode2 = new JewelMode(clsJewel.JewelModes[int_0]);
			jewelMode2.Name += " - Copy";
			clsJewel.JewelModes.Add(jewelMode2);
			DGV.Rows.Add(clsJewel.JewelModes.Count.ToString(), clsJewel.JewelModes[clsJewel.JewelModes.Count - 1].Name, clsJewel.JewelModes[clsJewel.JewelModes.Count - 1].Prepared, "Update", "Delete");
		}
		if (control.Name == button_2.Name)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = clsVar.varInterface.pathJewelModes;
			openFileDialog.Multiselect = false;
			openFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				clsVar.varInterface.pathJewelModes = buFile5.GetPath(openFileDialog.FileName);
				clsJewel.JewelModeOpen(openFileDialog.FileName);
				DGV.Rows.Clear();
				for (int i = 0; i <= clsJewel.JewelModes.Count - 1; i++)
				{
					DGV.Rows.Add((i + 1).ToString(), clsJewel.JewelModes[i].Name, clsJewel.JewelModes[i].Prepared, "Update", "Delete");
				}
				clsFiles.SaveParameter();
			}
		}
		if (control.Name == button_1.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = clsVar.varInterface.pathJewelModes;
			saveFileDialog.Filter = "Jewelary Mode File (*.bujewelmode)|*.bujewelmode";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				clsVar.varInterface.pathJewelModes = buFile5.GetPath(saveFileDialog.FileName);
				clsJewel.JewelModeSave(saveFileDialog.FileName, CheckExist: true);
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
