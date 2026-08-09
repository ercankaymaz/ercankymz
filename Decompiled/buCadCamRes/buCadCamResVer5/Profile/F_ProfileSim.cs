using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.Controls;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Profile;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Profile;

public class F_ProfileSim : Form
{
	public FormProperties Properties = new FormProperties();

	private Timer timer_0 = null;

	internal int int_0 = -1;

	private bool bool_0 = false;

	private bool bool_1 = false;

	private bool bool_2 = false;

	private bool bool_3 = false;

	public GProfileOperation selectedOP = null;

	public ProfileItemCalc selectedCalcItem = null;

	internal int int_1 = 0;

	private bool bool_4 = false;

	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Panel panel_1;

	internal Label label_0;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_2;

	internal Panel panel_2;

	internal Panel panel_3;

	internal TreeView treeView_0;

	internal Label label_1;

	internal Panel panel_4;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	internal Button button_9;

	internal Button button_10;

	internal Button button_11;

	internal Button button_12;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Panel panel_5;

	internal TextBox textBox_0;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	internal Label label_9;

	internal Label label_10;

	internal Button button_13;

	internal NumericUpDown numericUpDown_0;

	internal ImageList imageList_3;

	internal Button button_14;

	internal Button button_15;

	public Panel pnl_viewport;

	public TextBox txt_simf;

	public TextBox txt_simx;

	public TextBox txt_simz;

	public TextBox txt_simy;

	public TextBox txt_sims;

	public TextBox txt_simt;

	public TextBox txt_sima;

	public Panel panel5;

	public Label lbl_z;

	public Label lbl_y;

	public Label lbl_x;

	public DataGridView dgv_clamper;

	public ImageList IC32_Clamper;

	internal Button button_16;

	internal Button button_17;

	internal Button button_18;

	internal Button button_19;

	internal NumericUpDown numericUpDown_1;

	internal Button button_20;

	internal Button button_21;

	internal Button button_22;

	public buTrackMarker track_clamper;

	public CheckBox chk_ghostright;

	internal Panel panel_6;

	internal Button button_23;

	public CheckBox chk__hidecontours;

	public CheckBox chk__hidecam;

	public CheckBox chk__hideoperation;

	public CheckBox chk__hideprofiles;

	public CheckBox chk__hidesupports;

	public CheckBox chk__hidemachine;

	public CheckBox chk_hideclapers;

	internal Label label_11;

	internal Button button_24;

	internal Button button_25;

	internal Button button_26;

	internal Button button_27;

	internal Button button_28;

	internal Button button_29;

	internal Label label_12;

	internal NumericUpDown numericUpDown_2;

	public CheckBox chk_collisiondetect;

	internal Panel panel_7;

	internal Button button_30;

	internal Button button_31;

	internal CheckBox checkBox_0;

	public ContextMenuStrip mnu_profile;

	public ToolStripMenuItem mnu_up;

	public ToolStripMenuItem mnu_down;

	public ToolStripSeparator toolStripSeparator5;

	public ToolStripMenuItem mnu_priorityoperation;

	public ToolStripSeparator toolStripSeparator2;

	public ToolStripMenuItem mnu_selectall;

	public ToolStripMenuItem mnu_unselectall;

	public ToolStripSeparator toolStripSeparator6;

	public ToolStripMenuItem mnu_setclamper;

	public ToolStripSeparator toolStripSeparator3;

	public ToolStripMenuItem mnu_enable;

	public ToolStripMenuItem mnu_disable;

	public ToolStripSeparator toolStripSeparator7;

	internal ImageList imageList_4;

	public TextBox txt_message;

	internal Button button_32;

	internal Label label_13;

	internal Button button_33;

	internal Button button_34;

	public CheckBox chk__hidemachinbody;

	public TextBox txt_command;

	public F_ProfileSim()
	{
		Class5.smethod_173(this);
		mnu_up.Image = imageList_4.Images[0];
		mnu_down.Image = imageList_4.Images[1];
		mnu_priorityoperation.Image = imageList_4.Images[4];
		mnu_selectall.Image = imageList_4.Images[5];
		mnu_unselectall.Image = imageList_4.Images[6];
		mnu_setclamper.Image = imageList_4.Images[9];
		mnu_enable.Image = imageList_4.Images[7];
		mnu_disable.Image = imageList_4.Images[8];
	}

	public void Init()
	{
		Properties.Inited = false;
		bool_1 = false;
		bool_0 = false;
		bool_2 = false;
		buProfileCalc.varProfileRunSettings.activeOPIndex = 0;
		OperationTreeFill();
		ProfileTempVars.ClamperMoved = false;
		textBox_0.Text = "";
		int_1 = 0;
		txt_message.Visible = false;
		txt_message.Text = "";
		checkBox_0.Checked = buProfileCalc.varProfileRunSettings.SelectModeSim;
		treeView_0.CheckBoxes = buProfileCalc.varProfileRunSettings.SelectModeSim;
		Class5.smethod_71(this);
		chk_hideclapers.Checked = buProfileCalc.varProfileRunSettings.HideClampers;
		chk__hidemachine.Checked = buProfileCalc.varProfileRunSettings.HideMachine;
		chk__hidemachinbody.Checked = buProfileCalc.varProfileRunSettings.HideMachineBody;
		chk__hidecam.Checked = buProfileCalc.varProfileRunSettings.HideCam;
		chk__hidecontours.Checked = buProfileCalc.varProfileRunSettings.HideContour;
		chk__hideoperation.Checked = buProfileCalc.varProfileRunSettings.HideOperations;
		chk__hideprofiles.Checked = buProfileCalc.varProfileRunSettings.HideProfile;
		chk__hidesupports.Checked = buProfileCalc.varProfileRunSettings.HideSupport;
		clsInit.appProfile.listToCheck1.Clear();
		clsInit.appProfile.listToCheck2.Clear();
		if (buProfileCalc.varProfileRunSettings.activeProfileIndex != 0)
		{
		}
		if (buProfileCalc.varProfileRunSettings.activeProfileIndex != 1)
		{
		}
		clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
		if (dgv_clamper.Columns.Count == 0)
		{
			dgv_clamper.RowHeadersVisible = false;
			dgv_clamper.ColumnHeadersVisible = false;
			dgv_clamper.AllowUserToAddRows = false;
			dgv_clamper.AllowUserToResizeColumns = false;
			dgv_clamper.AllowUserToResizeRows = false;
			dgv_clamper.Columns.Clear();
			dgv_clamper.Rows.Clear();
			DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
			dataGridViewColumn.Width = 40;
			dataGridViewColumn.HeaderText = "No";
			dataGridViewColumn.Name = "No";
			dataGridViewColumn.ReadOnly = true;
			dataGridViewColumn.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
			dgv_clamper.Columns.Add(dataGridViewColumn);
			DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
			dataGridViewColumn2.Width = dgv_clamper.Width - dataGridViewColumn.Width - 10;
			dataGridViewColumn2.HeaderText = "X Pos";
			dataGridViewColumn2.Name = "X Pos";
			dataGridViewColumn2.CellTemplate = new DataGridViewTextBoxCell();
			dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
			dataGridViewColumn2.ReadOnly = true;
			dgv_clamper.Columns.Add(dataGridViewColumn2);
		}
		clsInit.appProfile.ClamperUpdate(ClearList: true);
		numericUpDown_0.Value = (decimal)buProfileCalc.varProfileRunSettings.ClamperMoveStep;
		numericUpDown_2.Value = buProfileCalc.varProfileRunSettings.SimStep;
		chk_ghostright.Checked = buProfileCalc.varProfileRunSettings.GhostClamper;
		chk_collisiondetect.Checked = buProfileCalc.varProfileRunSettings.CollisionDetect;
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		if (timer_0 == null)
		{
			timer_0 = new Timer();
			timer_0.Tick += timer_0_Tick;
		}
		timer_0.Interval = 100;
		timer_0.Enabled = true;
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (clsInit.appProfile.timSim.Enabled)
		{
			method_4(button_26, null);
		}
		if (Properties.Result != DialogResult.OK)
		{
			Class5.smethod_217(this);
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
		if (clsInit.appProfile.FrmSimCodes != null && clsInit.appProfile.FrmSimCodes.Visible)
		{
			clsInit.appProfile.FrmSimCodes.Visible = false;
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
	}

	internal void method_2(object sender, DataGridViewCellEventArgs e)
	{
		if (e.ColumnIndex == 1)
		{
			method_4(button_13, null);
		}
	}

	internal void method_3(object sender, DataGridViewCellEventArgs e)
	{
		base.TopMost = false;
		if (buProfileCalc.varProfileRunSettings.activeProfileIndex != 0)
		{
		}
		if (buProfileCalc.varProfileRunSettings.activeProfileIndex != 1)
		{
		}
		clsInit.appProfile.SelectedClamperIndex = e.RowIndex;
		clsInit.appProfile.ClamperSetTrackValue();
		OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
		SelectClamperGrid(clsInit.appProfile.SelectedClamperIndex);
	}

	internal void method_4(object sender, EventArgs e)
	{
		try
		{
			Control control = new Control();
			control = (Control)sender;
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == -1)
			{
				if (clsInit.appProfile.activeProfile.FirstItem == null || !clsInit.appProfile.activeProfile.FirstItem.Enable)
				{
					if (clsInit.appProfile.activeProfile.SecondItem == null || !clsInit.appProfile.activeProfile.SecondItem.Enable)
					{
						return;
					}
					buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
				}
				else
				{
					buProfileCalc.varProfileRunSettings.activeProfileIndex = 0;
				}
			}
			buEyeBaseVer5.Apps.ProfileItem Item = null;
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
			{
				Item = clsInit.appProfile.activeProfile.FirstItem;
				if ((Item == null) & (clsInit.appProfile.activeProfile.SecondItem != null))
				{
					buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
				}
				if (Item != null && !Item.Enable)
				{
					buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
				}
			}
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
			{
				Item = clsInit.appProfile.activeProfile.SecondItem;
			}
			if (control.Name == button_34.Name)
			{
				try
				{
					F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
					f_ClassViewerDialog.FormCaption = "Sheet";
					f_ClassViewerDialog.Value = buProfileCalc.varProfileSettings;
					f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
					f_ClassViewerDialog.Width = 500;
					f_ClassViewerDialog.Height = 750;
					f_ClassViewerDialog.ValuePersentage = 35.0;
					f_ClassViewerDialog.Init();
					f_ClassViewerDialog.ShowDialog();
					if (f_ClassViewerDialog.Result == DialogResult.OK)
					{
						buProfileCalc.varProfileSettings = new buEyeBaseVer5.Apps.ProfileSettings((buEyeBaseVer5.Apps.ProfileSettings)f_ClassViewerDialog.Value);
						clsInit.appProfile.SaveProfileFile();
					}
				}
				catch (Exception)
				{
				}
			}
			if (control.Name == button_33.Name)
			{
				F_Clampers f_Clampers = new F_Clampers();
				f_Clampers.Clampers.Clear();
				for (int i = 0; i <= clsInit.appProfile.Clampers.Count - 1; i++)
				{
					buEyeBaseVer5.Apps.ProfileClamper item = new buEyeBaseVer5.Apps.ProfileClamper(clsInit.appProfile.Clampers[i]);
					f_Clampers.Clampers.Add(item);
				}
				f_Clampers.strPath = clsVar.varInterface.pathMisc;
				f_Clampers.varProfileClamperSettings = new buEyeBaseVer5.Apps.ProfileClamperSettings(buProfileCalc.varProfileClamperSettings);
				f_Clampers.Properties = new FormProperties();
				f_Clampers.Properties.FormCloseMode = FormCloseModeType.Invisible;
				f_Clampers.Init();
				f_Clampers.StartPosition = FormStartPosition.CenterParent;
				f_Clampers.ShowDialog();
				if (f_Clampers.Properties.Result == DialogResult.OK)
				{
					clsVar.varInterface.pathMisc = f_Clampers.strPath;
					buProfileCalc.varProfileClamperSettings = new buEyeBaseVer5.Apps.ProfileClamperSettings(f_Clampers.varProfileClamperSettings);
					clsInit.appProfile.Clampers.Clear();
					clsInit.appProfile.Clampers = new List<buEyeBaseVer5.Apps.ProfileClamper>();
					for (int j = 0; j <= f_Clampers.Clampers.Count - 1; j++)
					{
						buEyeBaseVer5.Apps.ProfileClamper item2 = new buEyeBaseVer5.Apps.ProfileClamper(f_Clampers.Clampers[j]);
						clsInit.appProfile.Clampers.Add(item2);
					}
					clsInit.appProfile.SaveProfileFile();
				}
			}
			if (control.Name == button_29.Name)
			{
				if (clsInit.appProfile.timSim.Enabled)
				{
					return;
				}
				Class5.smethod_217(this);
				if (clsInit.appProfile.FrmSimCodes != null && clsInit.appProfile.FrmSimCodes.Visible)
				{
					clsInit.appProfile.FrmSimCodes.Visible = false;
				}
				clsInit.appProfile.SaveProfileFile();
				clsInit.appProfile.timSim.Enabled = false;
				Properties.Result = DialogResult.OK;
				base.Visible = false;
			}
			if (control.Name == button_32.Name)
			{
				if (clsInit.appProfile.timSim.Enabled)
				{
					return;
				}
				if (clsInit.appProfile.viewportSimilasyon.Entities.Count > 0)
				{
					Entity entity = clsInit.appProfile.viewportSimilasyon.Entities[clsInit.appProfile.viewportSimilasyon.Entities.Count - 1];
					if (entity.EntityData != null && entity.EntityData is CustomData && ((((CustomData)entity.EntityData).typeDefination == entityTypeDefination.TempDraw) | (((CustomData)entity.EntityData).typeDefination == entityTypeDefination.TempText)))
					{
						clsInit.appProfile.viewportSimilasyon.Entities.RemoveAt(clsInit.appProfile.viewportSimilasyon.Entities.Count - 1);
					}
					entity = clsInit.appProfile.viewportSimilasyon.Entities[clsInit.appProfile.viewportSimilasyon.Entities.Count - 1];
					if (entity.EntityData != null && entity.EntityData is CustomData && ((((CustomData)entity.EntityData).typeDefination == entityTypeDefination.TempDraw) | (((CustomData)entity.EntityData).typeDefination == entityTypeDefination.TempText)))
					{
						clsInit.appProfile.viewportSimilasyon.Entities.RemoveAt(clsInit.appProfile.viewportSimilasyon.Entities.Count - 1);
					}
				}
				clsInit.appProfile.viewportSimilasyon.Invalidate();
				buProfileCalc.varTemps.MeasureActive = true;
				buProfileCalc.varTemps.DrawMouseDown = false;
			}
			if (control.Name == button_23.Name)
			{
				Properties.Inited = false;
				buProfileCalc.varProfileRunSettings.HideCam = false;
				buProfileCalc.varProfileRunSettings.HideClampers = false;
				buProfileCalc.varProfileRunSettings.HideContour = false;
				buProfileCalc.varProfileRunSettings.HideMachine = false;
				buProfileCalc.varProfileRunSettings.HideMachineBody = false;
				buProfileCalc.varProfileRunSettings.HideOperations = false;
				buProfileCalc.varProfileRunSettings.HideProfile = false;
				buProfileCalc.varProfileRunSettings.HideSupport = false;
				chk_hideclapers.Checked = buProfileCalc.varProfileRunSettings.HideClampers;
				chk__hidemachine.Checked = buProfileCalc.varProfileRunSettings.HideMachine;
				chk__hidemachinbody.Checked = buProfileCalc.varProfileRunSettings.HideMachineBody;
				chk__hidecam.Checked = buProfileCalc.varProfileRunSettings.HideCam;
				chk__hidecontours.Checked = buProfileCalc.varProfileRunSettings.HideContour;
				chk__hideoperation.Checked = buProfileCalc.varProfileRunSettings.HideOperations;
				chk__hideprofiles.Checked = buProfileCalc.varProfileRunSettings.HideProfile;
				chk__hidesupports.Checked = buProfileCalc.varProfileRunSettings.HideSupport;
				clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
				panel_6.Visible = false;
				Properties.Inited = true;
			}
			if (control.Name == button_31.Name && clsInit.appProfile.activeProfile.GCodes != null)
			{
				clsInit.appProfile.FrmSimCodes.Width = 500;
				clsInit.appProfile.FrmSimCodes.Height = 600;
				if (buProfileCalc.varProfileSettings.SimulasyonGCodeWindowWidth > 50)
				{
					clsInit.appProfile.FrmSimCodes.Width = buProfileCalc.varProfileSettings.SimulasyonGCodeWindowWidth;
				}
				if (buProfileCalc.varProfileSettings.SimulasyonGCodeWindowHeight > 50)
				{
					clsInit.appProfile.FrmSimCodes.Height = buProfileCalc.varProfileSettings.SimulasyonGCodeWindowHeight;
				}
				clsInit.appProfile.frmSim.TopMost = false;
				clsInit.appProfile.FrmSimCodes.Init(clsInit.appProfile.activeProfile.GCodes);
				clsInit.appProfile.FrmSimCodes.TopMost = true;
				clsInit.appProfile.FrmSimCodes.Show();
			}
			if (control.Name == button_30.Name)
			{
				if (!panel_6.Visible)
				{
					panel_6.Visible = true;
				}
				else
				{
					panel_6.Visible = false;
				}
			}
			if (control.Name == button_24.Name)
			{
				if (txt_message.Visible)
				{
					buString5.MessageBoxWarning(txt_message.Text);
					return;
				}
				if (!clsInit.appProfile.FrmSimCodes.Visible)
				{
					base.TopMost = false;
				}
				buProfileCalc.varTemps.MeasureActive = false;
				buProfileCalc.varTemps.DrawMouseDown = false;
				if (clsInit.appProfile.SimIndex > 0)
				{
					clsInit.appProfile.timSim.Enabled = true;
					return;
				}
				if (ProfileTempVars.ClamperMoved | !Item.isGCodeCreated)
				{
					clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: false, GCodeToSim: true);
					ProfileTempVars.ClamperMoved = false;
				}
				clsInit.appProfile.listToCheck1.Clear();
				clsInit.appProfile.listToCheck2.Clear();
				for (int k = 0; k <= Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count - 1; k++)
				{
					if (!Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[k].Enable)
					{
						treeView_0.Nodes[0].Nodes[k].ImageIndex = 4;
						treeView_0.Nodes[0].Nodes[k].SelectedImageIndex = 4;
					}
					else
					{
						treeView_0.Nodes[0].Nodes[k].ImageIndex = 3;
						treeView_0.Nodes[0].Nodes[k].SelectedImageIndex = 3;
					}
					treeView_0.Nodes[0].Nodes[k].ForeColor = Color.Black;
				}
				if (!buProfileCalc.varProfileSettings.SimulationCanStartFromRightProfile && clsInit.appProfile.activeProfile.FirstItem != null && clsInit.appProfile.activeProfile.FirstItem.Enable)
				{
					buProfileCalc.varProfileRunSettings.activeProfileIndex = 0;
				}
				Item.isError = false;
				clsInit.appProfile.SimIndex = 0;
				clsInit.appProfile.SimOperationBaseIndex = 0;
				clsInit.appProfile.isCollisionRunning = false;
				clsInit.appProfile.DeleteSimulationTempEntities();
				clsInit.appProfile.DeleteAllSimPartsFromViewport();
				clsInit.appProfile.SimMachinePartAdd(Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[clsInit.appProfile.SimOperationBaseIndex].Tool, ccVars.KinematicOrjinal);
				clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, 0, new List<buEyeBaseVer5.Apps.ProfileClamper>());
				clsInit.appProfile.cmdOnlineSimulationStart();
				Class5.smethod_71(this);
				clsInit.appProfile.timSim.Interval = 5;
				clsInit.appProfile.timSim.Enabled = true;
			}
			if (control.Name == button_26.Name)
			{
				if (!clsInit.appProfile.FrmSimCodes.Visible)
				{
					base.TopMost = false;
				}
				clsInit.appProfile.timSim.Enabled = false;
				clsInit.appProfile.viewportSimilasyon.CancelWork();
				clsInit.appProfile.isCollisionRunning = false;
				clsInit.appProfile.SimOperationBaseIndex = 0;
				clsInit.appProfile.SimIndex = 0;
				buProfileCalc.varProfileRunSettings.activeCalcDataIndex = 0;
				clsInit.appProfile.DeleteSimulationTempEntities();
				clsInit.appProfile.DeleteAllSimPartsFromViewport();
				if (!clsInit.appProfile.viewportSimilasyon.IsBusy)
				{
					clsInit.appProfile.MovePark();
				}
				clsInit.appProfile.viewportSimilasyon.Invalidate();
			}
			if (control.Name == button_25.Name)
			{
				clsInit.appProfile.timSim.Enabled = false;
			}
			if (control.Name == button_28.Name)
			{
				clsInit.appProfile.Sim_Tick(null, null);
				clsInit.appProfile.timSim.Enabled = false;
			}
			if (control.Name == button_27.Name)
			{
				clsInit.appProfile.SimIndex -= Convert.ToInt32(numericUpDown_2.Value * 2m);
				clsInit.appProfile.Sim_Tick(null, null);
				clsInit.appProfile.timSim.Enabled = false;
			}
			if (control.Name == button_22.Name)
			{
				clsInit.appProfile.cmdSimulation(TopMost: false, ManuelSim: false, ReCalculate: true);
				txt_message.Visible = false;
				txt_message.Text = "";
			}
			if ((control.Name == button_14.Name) & !clsInit.appProfile.timSim.Enabled)
			{
				try
				{
					if (clsVar.appModes_0.DemoMode)
					{
						MessageBox.Show("Not Available in Demo Mode");
						return;
					}
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.InitialDirectory = clsVar.varInterface.pathMisc;
					openFileDialog.Filter = "Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
					openFileDialog.FilterIndex = 1;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						ArrayList StringList = new ArrayList();
						buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
						List<List<string>> CalcList = new List<List<string>>();
						buString.ListToSpecificList("<ClamperOP>", "</ClamperOP>", AddStartEndKey: true, StringList, ref CalcList);
						if (CalcList.Count != Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count)
						{
							DialogResult dialogResult = buString5.MessageBoxQuestion(buProfile.LangProfileMessage[22]);
							if (dialogResult != DialogResult.Yes)
							{
								return;
							}
						}
						if (CalcList.Count != Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count)
						{
							buString5.MessageBoxWarning(buProfile.LangProfileMessage[32]);
						}
						else if (CalcList.Count <= 0)
						{
							buString5.MessageBoxWarning(buProfile.LangProfileMessage[34]);
						}
						else
						{
							List<List<string>> CalcList2 = new List<List<string>>();
							buString.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", AddStartEndKey: true, CalcList[0], ref CalcList2);
							if (CalcList2.Count != Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[0].Clampers.Count)
							{
								buString5.MessageBoxWarning(buProfile.LangProfileMessage[32]);
							}
							else
							{
								for (int l = 0; l <= CalcList.Count - 1; l++)
								{
									CalcList2 = new List<List<string>>();
									buString.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", AddStartEndKey: true, CalcList[l], ref CalcList2);
									new List<buEyeBaseVer5.Apps.ProfileClamper>();
									if (CalcList2.Count == Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[l].Clampers.Count)
									{
										new List<buEyeBaseVer5.Apps.ProfileClamper>();
										Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[l].Clampers.Clear();
										Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[l].Clampers = new List<buEyeBaseVer5.Apps.ProfileClamper>();
										for (int m = 0; m <= CalcList2.Count - 1; m++)
										{
											ArrayList arrayList = new ArrayList();
											arrayList.AddRange(CalcList2[m].ToArray());
											buEyeBaseVer5.Apps.ProfileClamper profileClamper = new buEyeBaseVer5.Apps.ProfileClamper();
											buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, profileClamper);
											Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[l].Clampers.Add(profileClamper);
										}
									}
								}
								ProfileTempVars.ClamperMoved = true;
								clsInit.appProfile.ClamperUpdate(ClearList: true);
								clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
							}
						}
						clsVar.varInterface.pathMisc = buFile.GetPath(openFileDialog.FileName);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
				}
			}
			if ((control.Name == button_15.Name) & !clsInit.appProfile.timSim.Enabled)
			{
				try
				{
					if (clsVar.appModes_0.DemoMode)
					{
						MessageBox.Show("Not Available in Demo Mode");
						return;
					}
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = clsVar.varInterface.pathMisc;
					saveFileDialog.Filter = "Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
					saveFileDialog.FilterIndex = 1;
					if (saveFileDialog.ShowDialog() == DialogResult.OK && ((buProfileCalc.varProfileRunSettings.activeOPIndex >= 0) & (buProfileCalc.varProfileRunSettings.activeOPIndex <= Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count - 1)))
					{
						ArrayList arrayList2 = new ArrayList();
						for (int n = 0; n <= Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count - 1; n++)
						{
							arrayList2.Add("<ClamperOP>");
							for (int num = 0; num <= Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[n].Clampers.Count - 1; num++)
							{
								arrayList2.AddRange(Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[n].Clampers[num].ToDefAll("", 2, SerilizationMode5.MultiLine));
							}
							arrayList2.Add("</ClamperOP>");
						}
						buFile.SaveToFile(arrayList2, saveFileDialog.FileName);
						clsVar.varInterface.pathMisc = buFile.GetPath(saveFileDialog.FileName);
					}
				}
				catch (Exception mSException2)
				{
					buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
				}
			}
			if ((control.Name == button_1.Name) & !clsInit.appProfile.timSim.Enabled)
			{
				clsInit.appProfile.ClamperMoveBwdFwd(0.0 - (double)numericUpDown_0.Value);
				ProfileTempVars.ClamperMoved = true;
			}
			if ((control.Name == button_0.Name) & !clsInit.appProfile.timSim.Enabled)
			{
				clsInit.appProfile.ClamperMoveBwdFwd((double)numericUpDown_0.Value);
				ProfileTempVars.ClamperMoved = true;
			}
			if ((control.Name == button_13.Name) & !clsInit.appProfile.timSim.Enabled)
			{
				clsInit.appProfile.ClamperEdit();
				ProfileTempVars.ClamperMoved = true;
				OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
			}
			if (((control.Name == button_16.Name) & !clsInit.appProfile.timSim.Enabled) && buString5.MessageBoxQuestion(buLangTranslate.preSentencesProfile.DoYouWantToCopyOpClampPosRestOpClampPos) == DialogResult.Yes)
			{
				clsInit.appProfile.ClamperCopy();
				ProfileTempVars.ClamperMoved = true;
			}
			if (((control.Name == button_19.Name) & !clsInit.appProfile.timSim.Enabled) && buString5.MessageBoxQuestion(buLangTranslate.preSentencesProfile.DoYouWantToCreateNewFixturePositions) == DialogResult.Yes)
			{
				clsInit.appProfile.ClamperNewSetPosition();
				ProfileTempVars.ClamperMoved = true;
				numericUpDown_1.Value = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].ClamperLists.Count;
				OperationTreeFill();
				OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
			}
			if (((control.Name == button_20.Name) & !clsInit.appProfile.timSim.Enabled) && ((Item != null) & (buProfileCalc.varProfileRunSettings.activeOPIndex >= 0) & (buProfileCalc.varProfileRunSettings.activeCalcDataIndex >= 0)))
			{
				GProfileOperation refOP = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
				if (refOP.ClamperIndex > 0)
				{
					ProfileItemCalc profileItemCalc = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
					int clamperIndex = refOP.ClamperIndex;
					clamperIndex--;
					if (clamperIndex <= profileItemCalc.ClamperLists.Count - 1)
					{
						refOP.ClamperIndex = clamperIndex;
						refOP.Clampers.Clear();
						buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.ClamperLists[clamperIndex], ref refOP.Clampers);
						clsInit.appProfile.UpdateOperationFromNewClamperSet(buProfileCalc.varProfileRunSettings.activeOPIndex, refOP.ClamperIndex, ref refOP, ref profileItemCalc.calcOperations);
						OperationTreeFill();
						ProfileTempVars.DontMoveClamperForPark = true;
						clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
						ProfileTempVars.DontMoveClamperForPark = false;
						Class5.smethod_71(this);
						numericUpDown_1.Value = refOP.ClamperIndex + 1;
						Item.isGCodeCreated = false;
						clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true);
						OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
					}
				}
			}
			if (((control.Name == button_21.Name) & !clsInit.appProfile.timSim.Enabled) && ((Item != null) & (buProfileCalc.varProfileRunSettings.activeOPIndex >= 0) & (buProfileCalc.varProfileRunSettings.activeCalcDataIndex >= 0)))
			{
				ProfileItemCalc profileItemCalc2 = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
				GProfileOperation refOP2 = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
				if (refOP2.ClamperIndex < profileItemCalc2.ClamperLists.Count - 1)
				{
					int clamperIndex2 = refOP2.ClamperIndex;
					clamperIndex2++;
					if (clamperIndex2 <= profileItemCalc2.ClamperLists.Count - 1)
					{
						refOP2.ClamperIndex = clamperIndex2;
						refOP2.Clampers.Clear();
						buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc2.ClamperLists[clamperIndex2], ref refOP2.Clampers);
						clsInit.appProfile.UpdateOperationFromNewClamperSet(buProfileCalc.varProfileRunSettings.activeOPIndex, refOP2.ClamperIndex, ref refOP2, ref profileItemCalc2.calcOperations);
						OperationTreeFill();
						ProfileTempVars.DontMoveClamperForPark = true;
						clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
						ProfileTempVars.DontMoveClamperForPark = false;
						Class5.smethod_71(this);
						numericUpDown_1.Value = refOP2.ClamperIndex + 1;
						Item.isGCodeCreated = false;
						clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true);
						OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
					}
				}
			}
			if (control.Name == button_12.Name)
			{
				clsInit.appProfile.viewportSimilasyon.ActionMode = actionType.None;
			}
			if (control.Name == button_5.Name)
			{
				buEyeShotFunctions.ViewZoomIn(ref clsInit.appProfile.viewportSimilasyon);
			}
			if (control.Name == button_2.Name)
			{
				buEyeShotFunctions.ViewZoomNormal(ref clsInit.appProfile.viewportSimilasyon);
			}
			if (control.Name == button_4.Name)
			{
				buEyeShotFunctions.ViewZoomOut(ref clsInit.appProfile.viewportSimilasyon);
			}
			if (control.Name == button_3.Name)
			{
				buEyeShotFunctions.ViewZoomWindow(ref clsInit.appProfile.viewportSimilasyon);
			}
			if (control.Name == button_11.Name)
			{
				clsInit.appProfile.planeActive = Plane.XY;
				buEyeShotFunctions.ViewTop(ref clsInit.appProfile.viewportSimilasyon, isZoomFit: true);
			}
			if (control.Name == button_10.Name)
			{
				clsInit.appProfile.planeActive = Plane.XZ;
				buEyeShotFunctions.Viewfront(ref clsInit.appProfile.viewportSimilasyon, isZoomFit: true);
			}
			if (control.Name == button_18.Name)
			{
				clsInit.appProfile.planeActive = Plane.XZ;
				buEyeShotFunctions.ViewBack(ref clsInit.appProfile.viewportSimilasyon, isZoomFit: true);
			}
			if (control.Name == button_9.Name)
			{
				clsInit.appProfile.planeActive = Plane.YZ;
				buEyeShotFunctions.ViewRight(ref clsInit.appProfile.viewportSimilasyon, isZoomFit: true);
			}
			if (control.Name == button_17.Name)
			{
				clsInit.appProfile.planeActive = Plane.YZ;
				buEyeShotFunctions.ViewLeft(ref clsInit.appProfile.viewportSimilasyon, isZoomFit: true);
			}
			if (control.Name == button_8.Name)
			{
				clsInit.appProfile.planeActive = Plane.XY;
				clsInit.appProfile.viewportSimilasyon.SetView(viewType.vcFrontFaceTopLeft);
				clsInit.appProfile.viewportSimilasyon.Invalidate();
			}
			if (control.Name == button_7.Name)
			{
				buEyeShotFunctions.ViewRotate(ref clsInit.appProfile.viewportSimilasyon);
			}
			if (control.Name == button_6.Name)
			{
				buEyeShotFunctions.ViewPan(ref clsInit.appProfile.viewportSimilasyon);
			}
		}
		catch (Exception mSException3)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	internal void method_5(object sender, TreeViewEventArgs e)
	{
		if (!(Properties.Inited & !bool_4))
		{
			return;
		}
		if (e.Node != null)
		{
			TreeViewNodeSettings treeViewNodeSettings = new TreeViewNodeSettings();
			treeViewNodeSettings = (TreeViewNodeSettings)e.Node;
			int_0 = treeViewNodeSettings.ClassSubSubIndex;
			int classIndex = treeViewNodeSettings.ClassIndex;
			int classSubIndex = treeViewNodeSettings.ClassSubIndex;
			buEyeBaseVer5.Apps.ProfileItem profileItem = null;
			if (int_0 == 0)
			{
				profileItem = clsInit.appProfile.activeProfile.FirstItem;
			}
			if (int_0 == 1)
			{
				profileItem = clsInit.appProfile.activeProfile.SecondItem;
			}
			if (profileItem == null)
			{
				return;
			}
			buProfileCalc.varProfileRunSettings.activeProfileIndex = int_0;
			if (classSubIndex == -1)
			{
				for (int i = 0; i <= clsInit.appProfile.viewportSimilasyon.Entities.Count - 1; i++)
				{
					clsInit.appProfile.viewportSimilasyon.Entities[i].Selected = false;
				}
				selectedOP = null;
				clsInit.appProfile.viewportSimilasyon.Invalidate();
				clsInit.appProfile.DrawGhostClamp(null, selectedCalcItem);
			}
			selectedCalcItem = null;
			if (classSubIndex >= 0 && classIndex >= 0)
			{
				selectedCalcItem = profileItem.CalculationData[classIndex];
				if ((classSubIndex >= 0) & (classSubIndex <= profileItem.CalculationData[classIndex].calcOperations.Count - 1))
				{
					buProfileCalc.varProfileRunSettings.activeOPIndex = classSubIndex;
					buProfileCalc.varProfileRunSettings.activeCalcDataIndex = classIndex;
					selectedOP = profileItem.CalculationData[classIndex].calcOperations[classSubIndex];
					clsInit.appProfile.SimOperationBaseIndex = buProfileCalc.varProfileRunSettings.activeOPIndex;
					numericUpDown_1.Value = profileItem.CalculationData[classIndex].calcOperations[classSubIndex].ClamperIndex + 1;
					clsInit.appProfile.ClamperUpdate(ClearList: true);
					double rotateFirstProfile = 0.0;
					double profileXOffset = 0.0;
					if (profileItem.CalculationData[classIndex].CalcType == ProfileExcType.NormalBottom)
					{
						rotateFirstProfile = 180.0;
					}
					if (profileItem.CalculationData[classIndex].CalcType == ProfileExcType.LongSecondPart)
					{
						profileXOffset = 0.0 - profileItem.CalculationData[classIndex].Length;
					}
					ProfileTempVars.DontMoveClamperForPark = false;
					clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, classSubIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>(), profileXOffset, rotateFirstProfile);
					ProfileTempVars.DontMoveClamperForPark = false;
					textBox_0.Text = clsInit.appProfile.GetOperationInfo(profileItem.CalculationData[classIndex].calcOperations[classSubIndex]);
					OperationSelect(classSubIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, profileItem.CalculationData[classIndex].calcOperations[classSubIndex]);
				}
			}
		}
		Class5.smethod_71(this);
	}

	internal void method_6(object sender, TreeViewEventArgs e)
	{
		TreeViewNodeSettings treeViewNodeSettings = (TreeViewNodeSettings)e.Node;
		if (bool_3 || treeViewNodeSettings == null)
		{
			return;
		}
		bool selected = treeViewNodeSettings.Checked;
		string command = treeViewNodeSettings.Command;
		string text = command;
		if (text == "profileitem")
		{
			if (treeViewNodeSettings.ClassIndex < 0)
			{
			}
		}
		else
		{
			if (!(text == "profileop"))
			{
				return;
			}
			if (treeViewNodeSettings.ClassSubSubIndex == 0 && clsInit.appProfile.activeProfile.FirstItem != null)
			{
				ProfileItemCalc profileItemCalc = clsInit.appProfile.activeProfile.FirstItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
				if ((treeViewNodeSettings.ClassSubIndex >= 0) & (treeViewNodeSettings.ClassSubIndex <= profileItemCalc.calcOperations.Count - 1))
				{
					profileItemCalc.calcOperations[treeViewNodeSettings.ClassSubIndex].Selected = selected;
				}
			}
			if (treeViewNodeSettings.ClassSubSubIndex == 1 && clsInit.appProfile.activeProfile.SecondItem != null)
			{
				ProfileItemCalc profileItemCalc2 = clsInit.appProfile.activeProfile.SecondItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
				if ((treeViewNodeSettings.ClassSubIndex >= 0) & (treeViewNodeSettings.ClassSubIndex <= profileItemCalc2.calcOperations.Count - 1))
				{
					profileItemCalc2.calcOperations[treeViewNodeSettings.ClassSubIndex].Selected = selected;
				}
			}
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
			buProfileCalc.varProfileRunSettings.SimStep = (int)numericUpDown_2.Value;
		}
	}

	internal void method_8(object object_0, double double_0)
	{
		if (!clsInit.appProfile.ClamperUpdating)
		{
			buEyeBaseVer5.Apps.ProfileItem Item = null;
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
			{
				Item = clsInit.appProfile.activeProfile.FirstItem;
			}
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
			{
				Item = clsInit.appProfile.activeProfile.SecondItem;
			}
			if (Item != null && clsInit.appProfile.SelectedClamperIndex >= 0)
			{
				ProfileItemCalc profileItemCalc = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
				clsInit.appProfile.ClampersOldPosBeforeMove.Clear();
				buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Clampers, ref clsInit.appProfile.ClampersOldPosBeforeMove);
				profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Clampers[clsInit.appProfile.SelectedClamperIndex].XPosition = double_0;
				clsInit.appProfile.ClamperSetUpdate(profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].ClamperIndex, profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Clampers);
				clsInit.appProfile.ClamperUpdate(ClearList: true);
				clsInit.appProfile.BasicCollsionControl(ref Item);
				clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
				ProfileTempVars.ClamperMoved = true;
			}
		}
	}

	internal void method_9(object sender, MouseEventArgs e)
	{
		bool_0 = true;
	}

	internal void method_10(object sender, MouseEventArgs e)
	{
		if (bool_0 & bool_1)
		{
			bool_0 = false;
			bool_1 = false;
			buEyeBaseVer5.Apps.ProfileItem Item = null;
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
			{
				Item = clsInit.appProfile.activeProfile.FirstItem;
			}
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
			{
				Item = clsInit.appProfile.activeProfile.SecondItem;
			}
			if (Item != null)
			{
				clsInit.appProfile.BasicCollsionControl(ref Item);
				clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true);
			}
		}
	}

	internal void method_11(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == checkBox_0.Name)
		{
			buProfileCalc.varProfileRunSettings.SelectModeSim = checkBox_0.Checked;
			treeView_0.CheckBoxes = buProfileCalc.varProfileRunSettings.SelectModeSim;
			if (treeView_0.Nodes != null)
			{
				if (treeView_0.Nodes.Count >= 1)
				{
					treeView_0.Nodes[0].Expand();
				}
				if (treeView_0.Nodes.Count >= 2)
				{
					treeView_0.Nodes[1].Expand();
				}
			}
			if (!buProfileCalc.varProfileRunSettings.SelectModeSim)
			{
				if (clsInit.appProfile.activeProfile.FirstItem != null)
				{
					for (int i = 0; i <= clsInit.appProfile.activeProfile.FirstItem.CalculationData.Count - 1; i++)
					{
						for (int j = 0; j <= clsInit.appProfile.activeProfile.FirstItem.CalculationData[i].calcOperations.Count - 1; j++)
						{
							clsInit.appProfile.activeProfile.FirstItem.CalculationData[i].calcOperations[j].Selected = false;
						}
					}
				}
				if (clsInit.appProfile.activeProfile.SecondItem != null)
				{
					for (int k = 0; k <= clsInit.appProfile.activeProfile.SecondItem.CalculationData.Count - 1; k++)
					{
						for (int l = 0; l <= clsInit.appProfile.activeProfile.SecondItem.CalculationData[k].calcOperations.Count - 1; l++)
						{
							clsInit.appProfile.activeProfile.SecondItem.CalculationData[k].calcOperations[l].Selected = false;
						}
					}
				}
			}
		}
		if (control.Name == chk_ghostright.Name)
		{
			clsInit.appProfile.DrawGhostClamp(selectedOP, selectedCalcItem);
			clsInit.appProfile.viewportSimilasyon.Invalidate();
		}
		if (((control.Name == chk_hideclapers.Name) | (control.Name == chk__hidemachine.Name) | (control.Name == chk__hidecam.Name) | (control.Name == chk__hidecontours.Name) | (control.Name == chk__hideoperation.Name) | (control.Name == chk__hideprofiles.Name) | (control.Name == chk__hidesupports.Name) | (control.Name == chk__hidemachinbody.Name)) && Properties.Inited)
		{
			buProfileCalc.varProfileRunSettings.HideClampers = chk_hideclapers.Checked;
			buProfileCalc.varProfileRunSettings.HideMachine = chk__hidemachine.Checked;
			buProfileCalc.varProfileRunSettings.HideMachineBody = chk__hidemachinbody.Checked;
			buProfileCalc.varProfileRunSettings.HideCam = chk__hidecam.Checked;
			buProfileCalc.varProfileRunSettings.HideContour = chk__hidecontours.Checked;
			buProfileCalc.varProfileRunSettings.HideOperations = chk__hideoperation.Checked;
			buProfileCalc.varProfileRunSettings.HideProfile = chk__hideprofiles.Checked;
			buProfileCalc.varProfileRunSettings.HideSupport = chk__hidesupports.Checked;
			clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
		}
	}

	internal void method_12(object sender, EventArgs e)
	{
		string text = "";
		if (!(sender is Control))
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				text = toolStripMenuItem.Name;
			}
		}
		else
		{
			Control control = sender as Control;
			text = control.Name;
		}
		buEyeBaseVer5.Apps.ProfileItem Item = null;
		if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
		{
			Item = clsInit.appProfile.activeProfile.FirstItem;
			if ((Item == null) & (clsInit.appProfile.activeProfile.SecondItem != null))
			{
				buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
			}
			if (Item != null && !Item.Enable)
			{
				buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
			}
		}
		if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
		{
			Item = clsInit.appProfile.activeProfile.SecondItem;
		}
		if (Item == null)
		{
			return;
		}
		if (text == mnu_setclamper.Name)
		{
			F_ProfileClamperSet f_ProfileClamperSet = new F_ProfileClamperSet();
			f_ProfileClamperSet.spn_priority.Maximum = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].ClamperLists.Count;
			f_ProfileClamperSet.ClamperSet = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].ClamperIndex + 1;
			f_ProfileClamperSet.Init();
			f_ProfileClamperSet.ShowDialog(this);
			if (f_ProfileClamperSet.Properties.Result == DialogResult.OK)
			{
				int num = f_ProfileClamperSet.ClamperSet - 1;
				ProfileItemCalc profileItemCalc = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
				if (checkBox_0.Checked)
				{
					List<GProfileOperation> list = new List<GProfileOperation>();
					for (int num2 = profileItemCalc.calcOperations.Count - 1; num2 >= 0; num2--)
					{
						if (profileItemCalc.calcOperations[num2].Selected)
						{
							GProfileOperation gProfileOperation = profileItemCalc.calcOperations[num2];
							gProfileOperation.Clampers.Clear();
							gProfileOperation.ClamperIndex = num;
							buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.ClamperLists[num], ref gProfileOperation.Clampers);
							gProfileOperation.Selected = false;
							list.Add(gProfileOperation);
							profileItemCalc.calcOperations.RemoveAt(num2);
						}
					}
					if (list.Count > 0)
					{
						list.Reverse();
						int num3 = -1;
						for (int i = 0; i <= profileItemCalc.calcOperations.Count - 1; i++)
						{
							if (profileItemCalc.calcOperations[i].ClamperIndex > num)
							{
								num3 = i;
								i = profileItemCalc.calcOperations.Count;
							}
						}
						if (num3 < 0)
						{
							for (int j = 0; j <= list.Count - 1; j++)
							{
								profileItemCalc.calcOperations.Add(list[j]);
							}
							list.Clear();
						}
						else
						{
							for (int k = 0; k <= list.Count - 1; k++)
							{
								profileItemCalc.calcOperations.Insert(num3 + k, list[k]);
							}
						}
						OperationTreeFill();
						ProfileTempVars.DontMoveClamperForPark = true;
						clsInit.appProfile.BasicCollsionControl(ref clsInit.appProfile.activeProfile.FirstItem);
						clsInit.appProfile.BasicCollsionControl(ref clsInit.appProfile.activeProfile.SecondItem);
						clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
						ProfileTempVars.DontMoveClamperForPark = false;
						Class5.smethod_71(this);
						numericUpDown_1.Value = f_ProfileClamperSet.ClamperSet;
						Item.isGCodeCreated = false;
						clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true);
						OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
					}
				}
				else
				{
					GProfileOperation refOP = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
					refOP.Clampers.Clear();
					refOP.ClamperIndex = num;
					buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.ClamperLists[num], ref refOP.Clampers);
					clsInit.appProfile.UpdateOperationFromNewClamperSet(buProfileCalc.varProfileRunSettings.activeOPIndex, refOP.ClamperIndex, ref refOP, ref profileItemCalc.calcOperations);
					OperationTreeFill();
					ProfileTempVars.DontMoveClamperForPark = true;
					clsInit.appProfile.BasicCollsionControl(ref clsInit.appProfile.activeProfile.FirstItem);
					clsInit.appProfile.BasicCollsionControl(ref clsInit.appProfile.activeProfile.SecondItem);
					clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
					ProfileTempVars.DontMoveClamperForPark = false;
					Class5.smethod_71(this);
					numericUpDown_1.Value = refOP.ClamperIndex + 1;
					Item.isGCodeCreated = false;
					clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true);
					OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
				}
			}
		}
		if ((text == mnu_enable.Name) | (text == mnu_disable.Name))
		{
			bool enable = true;
			if (text == mnu_disable.Name)
			{
				enable = false;
			}
			ProfileItemCalc profileItemCalc2 = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
			if (checkBox_0.Checked)
			{
				for (int l = 0; l <= profileItemCalc2.calcOperations.Count - 1; l++)
				{
					if (profileItemCalc2.calcOperations[l].Selected)
					{
						GProfileOperation gProfileOperation2 = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[l];
						gProfileOperation2.Enable = enable;
					}
				}
				OperationTreeFill();
				ProfileTempVars.DontMoveClamperForPark = true;
				clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
				ProfileTempVars.DontMoveClamperForPark = false;
				Class5.smethod_71(this);
				Item.isGCodeCreated = false;
				clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true);
				OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
			}
			else
			{
				GProfileOperation gProfileOperation3 = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
				gProfileOperation3.Enable = enable;
				OperationTreeFill();
				ProfileTempVars.DontMoveClamperForPark = true;
				clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
				ProfileTempVars.DontMoveClamperForPark = false;
				Class5.smethod_71(this);
				Item.isGCodeCreated = false;
				clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true);
				OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, selectedOP);
			}
		}
		if (text == clsItem.FrmProfileJob.mnu_selectall.Name && clsInit.appProfile.activeProfile != null)
		{
			if (!checkBox_0.Checked)
			{
				checkBox_0.Checked = true;
			}
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
			{
				bool_3 = true;
				for (int m = 0; m <= clsInit.appProfile.activeProfile.FirstItem.CalculationData.Count - 1; m++)
				{
					for (int n = 0; n <= clsInit.appProfile.activeProfile.FirstItem.CalculationData[m].calcOperations.Count - 1; n++)
					{
						clsInit.appProfile.activeProfile.FirstItem.CalculationData[m].calcOperations[n].Selected = true;
					}
				}
				if (treeView_0.Nodes != null && treeView_0.Nodes.Count >= 1)
				{
					for (int num4 = 0; num4 <= treeView_0.Nodes[0].Nodes.Count - 1; num4++)
					{
						treeView_0.Nodes[0].Nodes[num4].Checked = true;
					}
				}
				bool_3 = false;
			}
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
			{
				bool_3 = true;
				for (int num5 = 0; num5 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData.Count - 1; num5++)
				{
					for (int num6 = 0; num6 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData[num5].calcOperations.Count - 1; num6++)
					{
						clsInit.appProfile.activeProfile.SecondItem.CalculationData[num5].calcOperations[num6].Selected = true;
					}
				}
				if (treeView_0.Nodes != null && treeView_0.Nodes.Count >= 2)
				{
					for (int num7 = 0; num7 <= treeView_0.Nodes[0].Nodes.Count - 1; num7++)
					{
						treeView_0.Nodes[1].Nodes[num7].Checked = true;
					}
				}
				bool_3 = false;
			}
		}
		if (text == clsItem.FrmProfileJob.mnu_unselectall.Name)
		{
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
			{
				bool_3 = true;
				for (int num8 = 0; num8 <= clsInit.appProfile.activeProfile.FirstItem.CalculationData.Count - 1; num8++)
				{
					for (int num9 = 0; num9 <= clsInit.appProfile.activeProfile.FirstItem.CalculationData[num8].calcOperations.Count - 1; num9++)
					{
						clsInit.appProfile.activeProfile.FirstItem.CalculationData[num8].calcOperations[num9].Selected = false;
					}
				}
				if (treeView_0.Nodes != null && treeView_0.Nodes.Count >= 1)
				{
					for (int num10 = 0; num10 <= treeView_0.Nodes[0].Nodes.Count - 1; num10++)
					{
						treeView_0.Nodes[0].Nodes[num10].Checked = false;
					}
				}
				bool_3 = false;
			}
			if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
			{
				bool_3 = true;
				for (int num11 = 0; num11 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData.Count - 1; num11++)
				{
					for (int num12 = 0; num12 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData[num11].calcOperations.Count - 1; num12++)
					{
						clsInit.appProfile.activeProfile.SecondItem.CalculationData[num11].calcOperations[num12].Selected = false;
					}
				}
				if (treeView_0.Nodes != null && treeView_0.Nodes.Count >= 2)
				{
					for (int num13 = 0; num13 <= treeView_0.Nodes[0].Nodes.Count - 1; num13++)
					{
						treeView_0.Nodes[1].Nodes[num13].Checked = false;
					}
				}
				bool_3 = false;
			}
		}
		if ((text == mnu_up.Name) | (text == mnu_down.Name))
		{
			bool flag = false;
			ProfileItemCalc profileItemCalc3 = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
			if (text == mnu_up.Name && buProfileCalc.varProfileRunSettings.activeOPIndex > 0)
			{
				GProfileOperation item = profileItemCalc3.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
				profileItemCalc3.calcOperations.RemoveAt(buProfileCalc.varProfileRunSettings.activeOPIndex);
				profileItemCalc3.calcOperations.Insert(buProfileCalc.varProfileRunSettings.activeOPIndex - 1, item);
				clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true, JustCam: true);
				flag = true;
			}
			if (text == mnu_down.Name && buProfileCalc.varProfileRunSettings.activeOPIndex < profileItemCalc3.calcOperations.Count - 1)
			{
				GProfileOperation item2 = profileItemCalc3.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
				profileItemCalc3.calcOperations.RemoveAt(buProfileCalc.varProfileRunSettings.activeOPIndex);
				profileItemCalc3.calcOperations.Insert(buProfileCalc.varProfileRunSettings.activeOPIndex + 1, item2);
				clsInit.appProfile.doCalculateAll(ref Item, Clamper: false, Cam: true, GCodeToSim: true, JustCam: true);
				flag = true;
			}
			if (flag)
			{
				OperationTreeFill();
			}
		}
		if (!(text == mnu_priorityoperation.Name))
		{
			return;
		}
		ProfileItemCalc profileItemCalc4 = Item.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
		if (!((buProfileCalc.varProfileRunSettings.activeOPIndex >= 0) & (buProfileCalc.varProfileRunSettings.activeOPIndex <= profileItemCalc4.calcOperations.Count - 1)))
		{
			return;
		}
		F_ProfilePriority f_ProfilePriority = new F_ProfilePriority();
		f_ProfilePriority.Priority = profileItemCalc4.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Priority;
		f_ProfilePriority.Init();
		f_ProfilePriority.ShowDialog();
		if (f_ProfilePriority.Properties.Result != DialogResult.OK)
		{
			return;
		}
		profileItemCalc4.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Priority = f_ProfilePriority.Priority;
		if (checkBox_0.Checked)
		{
			for (int num14 = 0; num14 <= profileItemCalc4.calcOperations.Count - 1; num14++)
			{
				if (!profileItemCalc4.calcOperations[num14].Selected)
				{
					continue;
				}
				profileItemCalc4.calcOperations[num14].Priority = f_ProfilePriority.Priority;
				for (int num15 = 0; num15 <= Item.Operations.Count - 1; num15++)
				{
					if (Item.Operations[num15].ID == profileItemCalc4.calcOperations[num14].ID)
					{
						Item.Operations[num15].Priority = f_ProfilePriority.Priority;
					}
				}
			}
		}
		else
		{
			profileItemCalc4.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Priority = f_ProfilePriority.Priority;
		}
		txt_message.Visible = true;
		txt_message.Text = buLangTranslate.preSentencesProfile.OperationsChangedReCalculateNeeded;
		OperationTreeFill();
	}

	public void SelectClamperGrid(int ClamperIndex)
	{
		if (ClamperIndex >= 0)
		{
			for (int i = 0; i <= dgv_clamper.Rows.Count - 1; i++)
			{
				dgv_clamper.Rows[i].Cells[0].Selected = false;
				dgv_clamper.Rows[i].Cells[1].Selected = false;
			}
			dgv_clamper.Rows[ClamperIndex].Cells[0].Selected = true;
		}
	}

	public void OperationSelect(int indexOP, int indexGroup, GProfileOperation OP)
	{
		clsInit.appProfile.DrawGhostClamp(OP, selectedCalcItem);
		for (int i = 0; i <= clsInit.appProfile.viewportSimilasyon.Entities.Count - 1; i++)
		{
			clsInit.appProfile.viewportSimilasyon.Entities[i].Selected = false;
			if (clsInit.appProfile.viewportSimilasyon.Entities[i].EntityData != null && clsInit.appProfile.viewportSimilasyon.Entities[i].EntityData is CustomData)
			{
				CustomData customData = clsInit.appProfile.viewportSimilasyon.Entities[i].EntityData as CustomData;
				if ((customData.RefIndex == int_0) & (customData.Sequence == indexOP) & (customData.GroupIdIndex == indexGroup) & (customData.typeDefination == entityTypeDefination.Operation))
				{
					clsInit.appProfile.viewportSimilasyon.Entities[i].Selected = true;
				}
			}
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		base.TopMost = false;
		timer_0.Enabled = false;
		if (clsInit.appProfile.SelectedClamperIndex == -1)
		{
			clsInit.appProfile.SelectedClamperIndex = 0;
		}
		SelectClamperGrid(clsInit.appProfile.SelectedClamperIndex);
		clsInit.appProfile.MovePark();
		buEyeShotFunctions.ZoomFit(ref clsInit.appProfile.viewportSimilasyon);
	}

	public void OperationTreeFill()
	{
		string text = "";
		int num = 1;
		base.TopMost = false;
		buEyeBaseVer5.Apps.ProfileItem profileItem = null;
		if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
		{
			profileItem = clsInit.appProfile.activeProfile.FirstItem;
		}
		if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
		{
			profileItem = clsInit.appProfile.activeProfile.SecondItem;
		}
		treeView_0.Nodes.Clear();
		TreeViewNodeSettings treeViewNodeSettings = null;
		TreeViewNodeSettings treeViewNodeSettings2 = null;
		if (clsInit.appProfile.activeProfile.FirstItem != null && clsInit.appProfile.activeProfile.FirstItem.Enable)
		{
			treeViewNodeSettings = new TreeViewNodeSettings();
			treeViewNodeSettings.Text = buLangTranslate.preDef.Left + " " + buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Length + ": " + clsInit.appProfile.activeProfile.FirstItem.Length.ToString("f1") + " - " + buLangTranslate.preChar.Width + ": " + clsInit.appProfile.activeProfile.FirstItem.Width.ToString("f1") + " - " + buLangTranslate.preChar.Height + ": " + clsInit.appProfile.activeProfile.FirstItem.Height.ToString("f1");
			treeViewNodeSettings.Name = buLangTranslate.preDef.Left;
			treeViewNodeSettings.ImageIndex = 6;
			treeViewNodeSettings.SelectedImageIndex = 6;
			treeViewNodeSettings.ClassSubSubIndex = buProfileCalc.varProfileRunSettings.activeProfileIndex;
			treeViewNodeSettings.Command = "profileitem";
			profileItem = clsInit.appProfile.activeProfile.FirstItem;
			for (int i = 0; i <= profileItem.CalculationData.Count - 1; i++)
			{
				for (int j = 0; j <= profileItem.CalculationData[i].calcOperations.Count - 1; j++)
				{
					num = profileItem.CalculationData[i].calcOperations[j].ClamperIndex + 1;
					TreeViewNodeSettings treeViewNodeSettings3 = new TreeViewNodeSettings();
					treeViewNodeSettings3.Command = "profileop";
					string text2 = j + 1 + "- [" + buProfileCalc.varProfileSettings.ClamperChar + "= " + num + "] - ";
					if (profileItem.CalculationData[i].calcOperations[j].Priority > 0)
					{
						text2 = text2 + "[" + buProfileCalc.varProfileSettings.PriorityChar + "= " + profileItem.CalculationData[i].calcOperations[j].Priority + "] - ";
					}
					text2 += buProfileCalc.OperationItemStringV2(profileItem.CalculationData[i].calcOperations[j]);
					treeViewNodeSettings3.Text = text2;
					treeViewNodeSettings3.ForeColor = Color.Black;
					treeViewNodeSettings3.Tag = profileItem.CalculationData[i].calcOperations[j].Name;
					if (!profileItem.CalculationData[i].calcOperations[j].Enable)
					{
						treeViewNodeSettings3.ImageIndex = 4;
						treeViewNodeSettings3.SelectedImageIndex = 4;
					}
					else
					{
						treeViewNodeSettings3.ImageIndex = 3;
						treeViewNodeSettings3.SelectedImageIndex = 3;
					}
					treeViewNodeSettings3.ClassIndex = i;
					treeViewNodeSettings3.ClassSubIndex = j;
					treeViewNodeSettings3.ClassSubSubIndex = 0;
					text2 = "T" + profileItem.CalculationData[i].calcOperations[j].Tool.Data.No + " - " + profileItem.CalculationData[i].calcOperations[j].OperationData.selectedPlaneName;
					treeViewNodeSettings.Nodes.Add(treeViewNodeSettings3);
				}
			}
		}
		num = 1;
		if (clsInit.appProfile.activeProfile.SecondItem != null && clsInit.appProfile.activeProfile.SecondItem.Enable)
		{
			treeViewNodeSettings2 = new TreeViewNodeSettings();
			treeViewNodeSettings2.Text = buLangTranslate.preDef.Right + " " + buLangTranslate.preDef.Profile + " " + buLangTranslate.preDef.Length + ": " + clsInit.appProfile.activeProfile.SecondItem.Length.ToString("f1") + " - " + buLangTranslate.preChar.Width + ": " + clsInit.appProfile.activeProfile.SecondItem.Width.ToString("f1") + " - " + buLangTranslate.preChar.Height + ": " + clsInit.appProfile.activeProfile.SecondItem.Height.ToString("f1");
			treeViewNodeSettings2.Name = buLangTranslate.preDef.Right;
			treeViewNodeSettings2.ImageIndex = 7;
			treeViewNodeSettings2.SelectedImageIndex = 7;
			treeViewNodeSettings2.ClassSubSubIndex = buProfileCalc.varProfileRunSettings.activeProfileIndex;
			treeViewNodeSettings2.Command = "profileitem";
			profileItem = clsInit.appProfile.activeProfile.SecondItem;
			for (int k = 0; k <= profileItem.CalculationData.Count - 1; k++)
			{
				for (int l = 0; l <= profileItem.CalculationData[k].calcOperations.Count - 1; l++)
				{
					num = profileItem.CalculationData[k].calcOperations[l].ClamperIndex + 1;
					TreeViewNodeSettings treeViewNodeSettings4 = new TreeViewNodeSettings();
					treeViewNodeSettings4.Command = "profileop";
					string text3 = l + 1 + "- [" + buProfileCalc.varProfileSettings.ClamperChar + "= " + num + "] - ";
					if (profileItem.CalculationData[k].calcOperations[l].Priority > 0)
					{
						text3 = text3 + "[" + buProfileCalc.varProfileSettings.PriorityChar + "= " + profileItem.CalculationData[k].calcOperations[l].Priority + "] - ";
					}
					text3 += buProfileCalc.OperationItemStringV2(profileItem.CalculationData[k].calcOperations[l]);
					treeViewNodeSettings4.Text = text3;
					treeViewNodeSettings4.ForeColor = Color.Black;
					treeViewNodeSettings4.Tag = profileItem.CalculationData[k].calcOperations[l].Name;
					if (!profileItem.CalculationData[k].calcOperations[l].Enable)
					{
						treeViewNodeSettings4.ImageIndex = 4;
						treeViewNodeSettings4.SelectedImageIndex = 4;
					}
					else
					{
						treeViewNodeSettings4.ImageIndex = 3;
						treeViewNodeSettings4.SelectedImageIndex = 3;
					}
					treeViewNodeSettings4.ClassIndex = k;
					treeViewNodeSettings4.ClassSubIndex = l;
					treeViewNodeSettings4.ClassSubSubIndex = 1;
					text3 = "T" + profileItem.CalculationData[k].calcOperations[l].Tool.Data.No + " - " + profileItem.CalculationData[k].calcOperations[l].OperationData.selectedPlaneName;
					treeViewNodeSettings2.Nodes.Add(treeViewNodeSettings4);
				}
			}
		}
		text = text + " " + buLangTranslate.preDef.Profile;
		if (treeViewNodeSettings != null)
		{
			treeView_0.Nodes.Add(treeViewNodeSettings);
		}
		if (treeViewNodeSettings2 != null)
		{
			treeView_0.Nodes.Add(treeViewNodeSettings2);
		}
		treeView_0.ExpandAll();
	}

	public void UpdateTreeOperation()
	{
		if (clsInit.appProfile.activeProfile.FirstItem != null && clsInit.appProfile.activeProfile.FirstItem.Enable)
		{
			int num = 0;
			buEyeBaseVer5.Apps.ProfileItem firstItem = clsInit.appProfile.activeProfile.FirstItem;
			for (int i = 0; i <= firstItem.CalculationData.Count - 1; i++)
			{
				for (int j = 0; j <= firstItem.CalculationData[i].calcOperations.Count - 1; j++)
				{
					if (treeView_0.Nodes.Count > 0 && num <= treeView_0.Nodes[0].Nodes.Count - 1)
					{
						TreeViewNodeSettings treeViewNodeSettings = new TreeViewNodeSettings();
						treeViewNodeSettings.Text = buLangTranslate.preSentences.CollisionAvailable;
						treeViewNodeSettings.ForeColor = Color.Red;
						treeViewNodeSettings.Tag = firstItem.CalculationData[i].calcOperations[j].Name;
						if (treeView_0.Nodes[0].Nodes[num].Nodes != null)
						{
							treeView_0.Nodes[0].Nodes[num].Nodes.Clear();
						}
						if (firstItem.CalculationData[i].calcOperations[j].isCollision)
						{
							treeView_0.Nodes[0].Nodes[num].Nodes.Add(treeViewNodeSettings);
							treeView_0.Nodes[0].Nodes[num].Expand();
						}
					}
					num++;
				}
			}
		}
		if (clsInit.appProfile.activeProfile.SecondItem == null || !clsInit.appProfile.activeProfile.SecondItem.Enable)
		{
			return;
		}
		int num2 = 0;
		buEyeBaseVer5.Apps.ProfileItem secondItem = clsInit.appProfile.activeProfile.SecondItem;
		for (int k = 0; k <= secondItem.CalculationData.Count - 1; k++)
		{
			for (int l = 0; l <= secondItem.CalculationData[k].calcOperations.Count - 1; l++)
			{
				int index = 1;
				if (treeView_0.Nodes.Count == 1)
				{
					index = 0;
				}
				if (treeView_0.Nodes.Count > 0 && num2 <= treeView_0.Nodes[index].Nodes.Count - 1)
				{
					TreeViewNodeSettings treeViewNodeSettings2 = new TreeViewNodeSettings();
					treeViewNodeSettings2.Text = buLangTranslate.preSentencesProfile.NoCollisionControlDone;
					treeViewNodeSettings2.ForeColor = Color.Red;
					treeViewNodeSettings2.Tag = secondItem.CalculationData[k].calcOperations[l].Name;
					if (treeView_0.Nodes[index].Nodes[num2].Nodes != null)
					{
						treeView_0.Nodes[index].Nodes[num2].Nodes.Clear();
					}
					if (secondItem.CalculationData[k].calcOperations[l].isCollision)
					{
						treeView_0.Nodes[index].Nodes[num2].Nodes.Add(treeViewNodeSettings2);
						treeView_0.Nodes[index].Nodes[num2].Expand();
					}
				}
				num2++;
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
