using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buCore;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Forms;

public class F_BendingLRAList : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public static List<string> Captions = new List<string>();

	public List<BendingLRAMaterialData> BendingList = new List<BendingLRAMaterialData>();

	public string strRemoveCaption = "Do You Want to Remove Item";

	public string pathLRA = Application.StartupPath;

	public int RowIndex = -1;

	public int ColIndex = -1;

	public Design viewportPart = null;

	private Timer timer_0 = new Timer();

	public PipeBendJob Job = null;

	internal IContainer icontainer_0 = null;

	internal DataGridView dataGridView_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_0;

	public Button btn_remove;

	public Button btn_add;

	internal Panel panel_0;

	internal Label label_0;

	public Button btn_canceldata;

	public Button btn_adddata;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal NumericUpDown numericUpDown_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_3;

	public Button btn_open;

	public Button btn_save;

	internal Panel panel_1;

	public Button btn_sim;

	public Button btn_clear;

	internal NumericUpDown numericUpDown_4;

	internal Label label_5;

	public F_BendingLRAList()
	{
		Class186.smethod_823(this);
		timer_0.Tick += Tick_Timer;
		timer_0.Interval = 10;
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
		numericUpDown_4.Value = (decimal)PipeBendTempVars._pipeDiameter;
		dataGridView_0.Columns.Clear();
		DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
		dataGridViewColumn.Width = 40;
		dataGridViewColumn.HeaderText = "No";
		dataGridViewColumn.Name = "No";
		dataGridViewColumn.ReadOnly = true;
		dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
		dataGridView_0.Columns.Add(dataGridViewColumn);
		DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
		dataGridViewColumn2.Width = 200;
		dataGridViewColumn2.HeaderText = "Length";
		dataGridViewColumn2.Name = "Length";
		dataGridViewColumn2.ReadOnly = false;
		dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
		dataGridView_0.Columns.Add(dataGridViewColumn2);
		DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
		dataGridViewColumn3.Width = 140;
		dataGridViewColumn3.HeaderText = "Rotation";
		dataGridViewColumn3.Name = "Rotation";
		dataGridViewColumn3.ReadOnly = false;
		dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn3.CellTemplate = new DataGridViewTextBoxCell();
		dataGridView_0.Columns.Add(dataGridViewColumn3);
		DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
		dataGridViewColumn4.Width = 100;
		dataGridViewColumn4.HeaderText = "Angle";
		dataGridViewColumn4.Name = "Angle";
		dataGridViewColumn4.ReadOnly = false;
		dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn4.CellTemplate = new DataGridViewTextBoxCell();
		dataGridView_0.Columns.Add(dataGridViewColumn4);
		DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
		dataGridViewColumn5.Width = 100;
		dataGridViewColumn5.HeaderText = "Radius";
		dataGridViewColumn5.Name = "Radius";
		dataGridViewColumn5.ReadOnly = false;
		dataGridViewColumn5.CellTemplate = new DataGridViewTextBoxCell();
		dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
		dataGridViewColumn5.ReadOnly = false;
		dataGridView_0.Columns.Add(dataGridViewColumn5);
		dataGridViewColumn2.Width = dataGridView_0.Width - dataGridViewColumn.Width - dataGridViewColumn3.Width - dataGridViewColumn4.Width - dataGridViewColumn5.Width - 15;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToResizeColumns = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.Rows.Clear();
		for (int i = 0; i <= BendingList.Count - 1; i++)
		{
			dataGridView_0.Rows.Add((i + 1).ToString(), BendingList[i].Length, BendingList[i].Rotation, BendingList[i].Angle, BendingList[i].Radius);
		}
		panel_0.Visible = false;
		if (viewportPart == null)
		{
			EyeCreateProps eyeCreateProps = new EyeCreateProps();
			eyeCreateProps.ShowToolBar = false;
			eyeCreateProps.ShowViewCube = true;
			eyeCreateProps.ShowCoordinateArrow = true;
			buEyeShotFunctions.CreateControlsTool(FirstCreate: true, eyeCreateProps, ref viewportPart);
			viewportPart.Dock = DockStyle.Fill;
			panel_1.Controls.Add(viewportPart);
		}
		ControlUpdate();
		LoadLanguage();
		panel_0.Visible = false;
		PropertiesForm.Result = DialogResult.None;
		PropertiesForm.Inited = true;
		if (BendingList.Count > 0)
		{
			timer_0.Enabled = true;
		}
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

	public void Tick_Timer(object sender, EventArgs e)
	{
		if (viewportPart.IsHandleCreated)
		{
			timer_0.Enabled = false;
			method_1(btn_sim, e);
		}
	}

	public void ControlUpdate()
	{
	}

	public void Apply()
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			Job.PipeDiameter = (double)numericUpDown_4.Value;
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
		if (control.Name == btn_add.Name)
		{
			BendingLRAMaterialData bendingLRAMaterialData = new BendingLRAMaterialData();
			BendingList.Add(bendingLRAMaterialData);
			dataGridView_0.Rows.Add(BendingList.Count.ToString(), bendingLRAMaterialData.Length, bendingLRAMaterialData.Rotation, bendingLRAMaterialData.Angle, bendingLRAMaterialData.Radius);
			method_1(btn_sim, null);
		}
		if (!(control.Name == btn_adddata.Name))
		{
		}
		if (control.Name == btn_canceldata.Name)
		{
			panel_0.Visible = false;
		}
		if (control.Name == btn_remove.Name && ((RowIndex >= 0) & (RowIndex <= BendingList.Count - 1)) && buString.MessageBoxQuestion(strRemoveCaption) == DialogResult.Yes)
		{
			BendingList.RemoveAt(RowIndex);
			dataGridView_0.Rows.RemoveAt(RowIndex);
		}
		if (control.Name == btn_clear.Name && buString.MessageBoxQuestion(strRemoveCaption) == DialogResult.Yes)
		{
			BendingList.Clear();
			dataGridView_0.Rows.Clear();
			viewportPart.Entities.Clear();
			viewportPart.Invalidate();
		}
		if (control.Name == btn_sim.Name)
		{
			PipeBendTempVars._pipeDiameter = (double)numericUpDown_4.Value;
			if (PipeBendTempVars._pipeDiameter <= 0.0)
			{
				PipeBendTempVars._pipeDiameter = 10.0;
			}
			PipeBendTempVars._c1 = new Circle(Plane.YZ, PipeBendTempVars._pipeDiameter);
			PipeBendTempVars._c1.Reverse();
			PipeBendTempVars._pipeColor = Color.Gray;
			PipeBendTempVars._pipeTotalLength = buCall.buPipeBendCalc_0.GetPipeLength(BendingList);
			PipeBendTempVars._excecutionPipe += PipeBendTempVars.PipeExecStep;
			PipeBendTempVars._excecutionPipe = PipeBendTempVars._pipeTotalLength;
			BendingList.Clear();
			for (int i = 0; i <= dataGridView_0.Rows.Count - 1; i++)
			{
				BendingLRAMaterialData bendingLRAMaterialData2 = new BendingLRAMaterialData();
				bendingLRAMaterialData2.Length = double.Parse(Convert.ToString(dataGridView_0.Rows[i].Cells[1].Value));
				bendingLRAMaterialData2.Rotation = double.Parse(Convert.ToString(dataGridView_0.Rows[i].Cells[2].Value));
				bendingLRAMaterialData2.Angle = double.Parse(Convert.ToString(dataGridView_0.Rows[i].Cells[3].Value));
				bendingLRAMaterialData2.Radius = double.Parse(Convert.ToString(dataGridView_0.Rows[i].Cells[4].Value));
				BendingList.Add(bendingLRAMaterialData2);
			}
			viewportPart = buCall.buPipeBendCalc_0.PipeProgressAll(viewportPart, BendingList);
			if (viewportPart.Entities.Count > 0)
			{
				viewportPart.Entities[viewportPart.Entities.Count - 1].Color = Color.Green;
				viewportPart.Entities[viewportPart.Entities.Count - 1].ColorMethod = colorMethodType.byLayer;
				viewportPart.Invalidate();
			}
			if (Job != null)
			{
				for (int j = 0; j <= Job.AuxEntityList.Count - 1; j++)
				{
					viewportPart.Entities.Add(Job.AuxEntityList[j]);
				}
				viewportPart.Invalidate();
			}
		}
		if (control.Name == btn_save.Name)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.InitialDirectory = pathLRA;
			saveFileDialog.Filter = "LRA Bending File (*.bulra)|*.bulra";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				buFile5.SaveLRAFile(saveFileDialog.FileName, BendingList);
				pathLRA = buFile.GetPath(saveFileDialog.FileName);
			}
		}
		if (!(control.Name == btn_open.Name))
		{
			return;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = pathLRA;
		openFileDialog.Filter = "LRA Bending File (*.bulra)|*.bulra";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			BendingList.Clear();
			buFile5.OpenLRAFile(openFileDialog.FileName, ref BendingList);
			dataGridView_0.Rows.Clear();
			for (int k = 0; k <= BendingList.Count - 1; k++)
			{
				dataGridView_0.Rows.Add((k + 1).ToString(), BendingList[k].Length, BendingList[k].Rotation, BendingList[k].Angle, BendingList[k].Radius);
			}
			pathLRA = buFile.GetPath(openFileDialog.FileName);
			method_1(btn_sim, e);
		}
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		if (PropertiesForm.Inited && e.RowIndex >= 0)
		{
			if (e.ColumnIndex == 1)
			{
				BendingList[RowIndex].Length = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if (e.ColumnIndex == 2)
			{
				BendingList[RowIndex].Rotation = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if (e.ColumnIndex == 3)
			{
				BendingList[RowIndex].Angle = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			if (e.ColumnIndex == 4)
			{
				BendingList[RowIndex].Radius = Convert.ToDouble(dataGridView_0.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			}
			method_1(btn_sim, null);
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		RowIndex = e.RowIndex;
		ColIndex = e.ColumnIndex;
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
