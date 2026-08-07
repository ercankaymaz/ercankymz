// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Profile.F_ProfileSim
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.Controls;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.Profile;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Profile;

public class F_ProfileSim : Form
{
  public FormProperties Properties = new FormProperties();
  private Timer timer_0 = (Timer) null;
  internal int int_0 = -1;
  private bool bool_0 = false;
  private bool bool_1 = false;
  private bool bool_2 = false;
  private bool bool_3 = false;
  public GProfileOperation selectedOP = (GProfileOperation) null;
  public ProfileItemCalc selectedCalcItem = (ProfileItemCalc) null;
  internal int int_1 = 0;
  private bool bool_4 = false;
  internal IContainer icontainer_0 = (IContainer) null;
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
    this.mnu_up.Image = this.imageList_4.Images[0];
    this.mnu_down.Image = this.imageList_4.Images[1];
    this.mnu_priorityoperation.Image = this.imageList_4.Images[4];
    this.mnu_selectall.Image = this.imageList_4.Images[5];
    this.mnu_unselectall.Image = this.imageList_4.Images[6];
    this.mnu_setclamper.Image = this.imageList_4.Images[9];
    this.mnu_enable.Image = this.imageList_4.Images[7];
    this.mnu_disable.Image = this.imageList_4.Images[8];
  }

  public void Init()
  {
    this.Properties.Inited = false;
    this.bool_1 = false;
    this.bool_0 = false;
    this.bool_2 = false;
    buProfileCalc.varProfileRunSettings.activeOPIndex = 0;
    this.OperationTreeFill();
    ProfileTempVars.ClamperMoved = false;
    this.textBox_0.Text = "";
    this.int_1 = 0;
    this.txt_message.Visible = false;
    this.txt_message.Text = "";
    this.checkBox_0.Checked = buProfileCalc.varProfileRunSettings.SelectModeSim;
    this.treeView_0.CheckBoxes = buProfileCalc.varProfileRunSettings.SelectModeSim;
    Class5.smethod_71(this);
    this.chk_hideclapers.Checked = buProfileCalc.varProfileRunSettings.HideClampers;
    this.chk__hidemachine.Checked = buProfileCalc.varProfileRunSettings.HideMachine;
    this.chk__hidemachinbody.Checked = buProfileCalc.varProfileRunSettings.HideMachineBody;
    this.chk__hidecam.Checked = buProfileCalc.varProfileRunSettings.HideCam;
    this.chk__hidecontours.Checked = buProfileCalc.varProfileRunSettings.HideContour;
    this.chk__hideoperation.Checked = buProfileCalc.varProfileRunSettings.HideOperations;
    this.chk__hideprofiles.Checked = buProfileCalc.varProfileRunSettings.HideProfile;
    this.chk__hidesupports.Checked = buProfileCalc.varProfileRunSettings.HideSupport;
    clsInit.appProfile.listToCheck1.Clear();
    clsInit.appProfile.listToCheck2.Clear();
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
      ;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
      ;
    clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
    if (this.dgv_clamper.Columns.Count == 0)
    {
      this.dgv_clamper.RowHeadersVisible = false;
      this.dgv_clamper.ColumnHeadersVisible = false;
      this.dgv_clamper.AllowUserToAddRows = false;
      this.dgv_clamper.AllowUserToResizeColumns = false;
      this.dgv_clamper.AllowUserToResizeRows = false;
      this.dgv_clamper.Columns.Clear();
      this.dgv_clamper.Rows.Clear();
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = "No";
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      this.dgv_clamper.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.Width = this.dgv_clamper.Width - dataGridViewColumn1.Width - 10;
      dataGridViewColumn2.HeaderText = "X Pos";
      dataGridViewColumn2.Name = "X Pos";
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.ReadOnly = true;
      this.dgv_clamper.Columns.Add(dataGridViewColumn2);
    }
    clsInit.appProfile.ClamperUpdate(true);
    this.numericUpDown_0.Value = (Decimal) buProfileCalc.varProfileRunSettings.ClamperMoveStep;
    this.numericUpDown_2.Value = (Decimal) buProfileCalc.varProfileRunSettings.SimStep;
    this.chk_ghostright.Checked = buProfileCalc.varProfileRunSettings.GhostClamper;
    this.chk_collisiondetect.Checked = buProfileCalc.varProfileRunSettings.CollisionDetect;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    if (this.timer_0 == null)
    {
      this.timer_0 = new Timer();
      this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
    }
    this.timer_0.Interval = 100;
    this.timer_0.Enabled = true;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (clsInit.appProfile.timSim.Enabled)
      this.method_4((object) this.button_26, (EventArgs) null);
    if (this.Properties.Result != DialogResult.OK)
    {
      Class5.smethod_217(this);
      e.Cancel = true;
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if ((clsInit.appProfile.FrmSimCodes == null ? 0 : (clsInit.appProfile.FrmSimCodes.Visible ? 1 : 0)) == 0)
      return;
    clsInit.appProfile.FrmSimCodes.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
  }

  internal void method_2(object sender, DataGridViewCellEventArgs e)
  {
    if (e.ColumnIndex != 1)
      return;
    this.method_4((object) this.button_13, (EventArgs) null);
  }

  internal void method_3(object sender, DataGridViewCellEventArgs e)
  {
    this.TopMost = false;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
      ;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
      ;
    clsInit.appProfile.SelectedClamperIndex = e.RowIndex;
    clsInit.appProfile.ClamperSetTrackValue();
    this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
    this.SelectClamperGrid(clsInit.appProfile.SelectedClamperIndex);
  }

  internal void method_4(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) sender;
      if (buProfileCalc.varProfileRunSettings.activeProfileIndex == -1)
      {
        if ((clsInit.appProfile.activeProfile.FirstItem == null ? 0 : (clsInit.appProfile.activeProfile.FirstItem.Enable ? 1 : 0)) != 0)
        {
          buProfileCalc.varProfileRunSettings.activeProfileIndex = 0;
        }
        else
        {
          if ((clsInit.appProfile.activeProfile.SecondItem == null ? 0 : (clsInit.appProfile.activeProfile.SecondItem.Enable ? 1 : 0)) == 0)
            return;
          buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
        }
      }
      buEyeBaseVer5.Apps.ProfileItem profileItem = (buEyeBaseVer5.Apps.ProfileItem) null;
      if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
      {
        profileItem = clsInit.appProfile.activeProfile.FirstItem;
        if (profileItem == null & clsInit.appProfile.activeProfile.SecondItem != null)
          buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
        if ((profileItem == null ? 0 : (!profileItem.Enable ? 1 : 0)) != 0)
          buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
      }
      if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
        profileItem = clsInit.appProfile.activeProfile.SecondItem;
      if (control2.Name == this.button_34.Name)
      {
        try
        {
          F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
          classViewerDialog.FormCaption = "Sheet";
          classViewerDialog.Value = (object) buProfileCalc.varProfileSettings;
          classViewerDialog.StartPosition = FormStartPosition.CenterParent;
          classViewerDialog.Width = 500;
          classViewerDialog.Height = 750;
          classViewerDialog.ValuePersentage = 35.0;
          classViewerDialog.Init();
          int num = (int) classViewerDialog.ShowDialog();
          if (classViewerDialog.Result == DialogResult.OK)
          {
            buProfileCalc.varProfileSettings = new buEyeBaseVer5.Apps.ProfileSettings((buEyeBaseVer5.Apps.ProfileSettings) classViewerDialog.Value);
            clsInit.appProfile.SaveProfileFile();
          }
        }
        catch (Exception ex)
        {
        }
      }
      if (control2.Name == this.button_33.Name)
      {
        F_Clampers fClampers = new F_Clampers();
        fClampers.Clampers.Clear();
        for (int index = 0; index <= clsInit.appProfile.Clampers.Count - 1; ++index)
        {
          buEyeBaseVer5.Apps.ProfileClamper profileClamper = new buEyeBaseVer5.Apps.ProfileClamper(clsInit.appProfile.Clampers[index]);
          fClampers.Clampers.Add(profileClamper);
        }
        fClampers.strPath = clsVar.varInterface.pathMisc;
        fClampers.varProfileClamperSettings = new buEyeBaseVer5.Apps.ProfileClamperSettings(buProfileCalc.varProfileClamperSettings);
        fClampers.Properties = new FormProperties();
        fClampers.Properties.FormCloseMode = FormCloseModeType.Invisible;
        fClampers.Init();
        fClampers.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fClampers.ShowDialog();
        if (fClampers.Properties.Result == DialogResult.OK)
        {
          clsVar.varInterface.pathMisc = fClampers.strPath;
          buProfileCalc.varProfileClamperSettings = new buEyeBaseVer5.Apps.ProfileClamperSettings(fClampers.varProfileClamperSettings);
          clsInit.appProfile.Clampers.Clear();
          clsInit.appProfile.Clampers = new List<buEyeBaseVer5.Apps.ProfileClamper>();
          for (int index = 0; index <= fClampers.Clampers.Count - 1; ++index)
          {
            buEyeBaseVer5.Apps.ProfileClamper profileClamper = new buEyeBaseVer5.Apps.ProfileClamper(fClampers.Clampers[index]);
            clsInit.appProfile.Clampers.Add(profileClamper);
          }
          clsInit.appProfile.SaveProfileFile();
        }
      }
      if (control2.Name == this.button_29.Name)
      {
        if (clsInit.appProfile.timSim.Enabled)
          return;
        Class5.smethod_217(this);
        if ((clsInit.appProfile.FrmSimCodes == null ? 0 : (clsInit.appProfile.FrmSimCodes.Visible ? 1 : 0)) != 0)
          clsInit.appProfile.FrmSimCodes.Visible = false;
        clsInit.appProfile.SaveProfileFile();
        clsInit.appProfile.timSim.Enabled = false;
        this.Properties.Result = DialogResult.OK;
        this.Visible = false;
      }
      if (control2.Name == this.button_32.Name)
      {
        if (clsInit.appProfile.timSim.Enabled)
          return;
        if (clsInit.appProfile.viewportSimilasyon.Entities.Count > 0)
        {
          Entity entity1 = clsInit.appProfile.viewportSimilasyon.Entities[clsInit.appProfile.viewportSimilasyon.Entities.Count - 1];
          if ((entity1.EntityData == null ? 0 : (entity1.EntityData is CustomData ? 1 : 0)) != 0 && ((CustomData) entity1.EntityData).typeDefination == entityTypeDefination.TempDraw | ((CustomData) entity1.EntityData).typeDefination == entityTypeDefination.TempText)
            clsInit.appProfile.viewportSimilasyon.Entities.RemoveAt(clsInit.appProfile.viewportSimilasyon.Entities.Count - 1);
          Entity entity2 = clsInit.appProfile.viewportSimilasyon.Entities[clsInit.appProfile.viewportSimilasyon.Entities.Count - 1];
          if ((entity2.EntityData == null ? 0 : (entity2.EntityData is CustomData ? 1 : 0)) != 0 && ((CustomData) entity2.EntityData).typeDefination == entityTypeDefination.TempDraw | ((CustomData) entity2.EntityData).typeDefination == entityTypeDefination.TempText)
            clsInit.appProfile.viewportSimilasyon.Entities.RemoveAt(clsInit.appProfile.viewportSimilasyon.Entities.Count - 1);
        }
        clsInit.appProfile.viewportSimilasyon.Invalidate();
        buProfileCalc.varTemps.MeasureActive = true;
        buProfileCalc.varTemps.DrawMouseDown = false;
      }
      if (control2.Name == this.button_23.Name)
      {
        this.Properties.Inited = false;
        buProfileCalc.varProfileRunSettings.HideCam = false;
        buProfileCalc.varProfileRunSettings.HideClampers = false;
        buProfileCalc.varProfileRunSettings.HideContour = false;
        buProfileCalc.varProfileRunSettings.HideMachine = false;
        buProfileCalc.varProfileRunSettings.HideMachineBody = false;
        buProfileCalc.varProfileRunSettings.HideOperations = false;
        buProfileCalc.varProfileRunSettings.HideProfile = false;
        buProfileCalc.varProfileRunSettings.HideSupport = false;
        this.chk_hideclapers.Checked = buProfileCalc.varProfileRunSettings.HideClampers;
        this.chk__hidemachine.Checked = buProfileCalc.varProfileRunSettings.HideMachine;
        this.chk__hidemachinbody.Checked = buProfileCalc.varProfileRunSettings.HideMachineBody;
        this.chk__hidecam.Checked = buProfileCalc.varProfileRunSettings.HideCam;
        this.chk__hidecontours.Checked = buProfileCalc.varProfileRunSettings.HideContour;
        this.chk__hideoperation.Checked = buProfileCalc.varProfileRunSettings.HideOperations;
        this.chk__hideprofiles.Checked = buProfileCalc.varProfileRunSettings.HideProfile;
        this.chk__hidesupports.Checked = buProfileCalc.varProfileRunSettings.HideSupport;
        clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
        this.panel_6.Visible = false;
        this.Properties.Inited = true;
      }
      if (control2.Name == this.button_31.Name && clsInit.appProfile.activeProfile.GCodes != null)
      {
        clsInit.appProfile.FrmSimCodes.Width = 500;
        clsInit.appProfile.FrmSimCodes.Height = 600;
        if (buProfileCalc.varProfileSettings.SimulasyonGCodeWindowWidth > 50)
          clsInit.appProfile.FrmSimCodes.Width = buProfileCalc.varProfileSettings.SimulasyonGCodeWindowWidth;
        if (buProfileCalc.varProfileSettings.SimulasyonGCodeWindowHeight > 50)
          clsInit.appProfile.FrmSimCodes.Height = buProfileCalc.varProfileSettings.SimulasyonGCodeWindowHeight;
        clsInit.appProfile.frmSim.TopMost = false;
        clsInit.appProfile.FrmSimCodes.Init(clsInit.appProfile.activeProfile.GCodes);
        clsInit.appProfile.FrmSimCodes.TopMost = true;
        clsInit.appProfile.FrmSimCodes.Show();
      }
      if (control2.Name == this.button_30.Name)
      {
        if (this.panel_6.Visible)
          this.panel_6.Visible = false;
        else
          this.panel_6.Visible = true;
      }
      if (control2.Name == this.button_24.Name)
      {
        if (this.txt_message.Visible)
        {
          buString5.MessageBoxWarning(this.txt_message.Text);
          return;
        }
        if (!clsInit.appProfile.FrmSimCodes.Visible)
          this.TopMost = false;
        buProfileCalc.varTemps.MeasureActive = false;
        buProfileCalc.varTemps.DrawMouseDown = false;
        if (clsInit.appProfile.SimIndex > 0)
        {
          clsInit.appProfile.timSim.Enabled = true;
          return;
        }
        if (ProfileTempVars.ClamperMoved | !profileItem.isGCodeCreated)
        {
          clsInit.appProfile.doCalculateAll(ref profileItem, false, false, true);
          ProfileTempVars.ClamperMoved = false;
        }
        clsInit.appProfile.listToCheck1.Clear();
        clsInit.appProfile.listToCheck2.Clear();
        for (int index = 0; index <= profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count - 1; ++index)
        {
          if (profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[index].Enable)
          {
            this.treeView_0.Nodes[0].Nodes[index].ImageIndex = 3;
            this.treeView_0.Nodes[0].Nodes[index].SelectedImageIndex = 3;
          }
          else
          {
            this.treeView_0.Nodes[0].Nodes[index].ImageIndex = 4;
            this.treeView_0.Nodes[0].Nodes[index].SelectedImageIndex = 4;
          }
          this.treeView_0.Nodes[0].Nodes[index].ForeColor = Color.Black;
        }
        if (!buProfileCalc.varProfileSettings.SimulationCanStartFromRightProfile && (clsInit.appProfile.activeProfile.FirstItem == null ? 0 : (clsInit.appProfile.activeProfile.FirstItem.Enable ? 1 : 0)) != 0)
          buProfileCalc.varProfileRunSettings.activeProfileIndex = 0;
        profileItem.isError = false;
        clsInit.appProfile.SimIndex = 0;
        clsInit.appProfile.SimOperationBaseIndex = 0;
        clsInit.appProfile.isCollisionRunning = false;
        clsInit.appProfile.DeleteSimulationTempEntities();
        clsInit.appProfile.DeleteAllSimPartsFromViewport();
        clsInit.appProfile.SimMachinePartAdd(profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[clsInit.appProfile.SimOperationBaseIndex].Tool, ccVars.KinematicOrjinal);
        clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, 0, new List<buEyeBaseVer5.Apps.ProfileClamper>());
        clsInit.appProfile.cmdOnlineSimulationStart();
        Class5.smethod_71(this);
        clsInit.appProfile.timSim.Interval = 5;
        clsInit.appProfile.timSim.Enabled = true;
      }
      if (control2.Name == this.button_26.Name)
      {
        if (!clsInit.appProfile.FrmSimCodes.Visible)
          this.TopMost = false;
        clsInit.appProfile.timSim.Enabled = false;
        clsInit.appProfile.viewportSimilasyon.CancelWork();
        clsInit.appProfile.isCollisionRunning = false;
        clsInit.appProfile.SimOperationBaseIndex = 0;
        clsInit.appProfile.SimIndex = 0;
        buProfileCalc.varProfileRunSettings.activeCalcDataIndex = 0;
        clsInit.appProfile.DeleteSimulationTempEntities();
        clsInit.appProfile.DeleteAllSimPartsFromViewport();
        if (!clsInit.appProfile.viewportSimilasyon.IsBusy)
          clsInit.appProfile.MovePark();
        clsInit.appProfile.viewportSimilasyon.Invalidate();
      }
      if (control2.Name == this.button_25.Name)
        clsInit.appProfile.timSim.Enabled = false;
      if (control2.Name == this.button_28.Name)
      {
        clsInit.appProfile.Sim_Tick((object) null, (EventArgs) null);
        clsInit.appProfile.timSim.Enabled = false;
      }
      if (control2.Name == this.button_27.Name)
      {
        clsInit.appProfile.SimIndex -= Convert.ToInt32(this.numericUpDown_2.Value * 2M);
        clsInit.appProfile.Sim_Tick((object) null, (EventArgs) null);
        clsInit.appProfile.timSim.Enabled = false;
      }
      if (control2.Name == this.button_22.Name)
      {
        clsInit.appProfile.cmdSimulation(false, ReCalculate: true);
        this.txt_message.Visible = false;
        this.txt_message.Text = "";
      }
      if (control2.Name == this.button_14.Name & !clsInit.appProfile.timSim.Enabled)
      {
        try
        {
          if (clsVar.appModes_0.DemoMode)
          {
            int num = (int) MessageBox.Show("Not Available in Demo Mode");
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
            List<List<string>> CalcList1 = new List<List<string>>();
            buString.ListToSpecificList("<ClamperOP>", "</ClamperOP>", true, StringList, ref CalcList1);
            if (CalcList1.Count != profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count && buString5.MessageBoxQuestion(buProfile.LangProfileMessage[22]) != DialogResult.Yes)
              return;
            if (CalcList1.Count == profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count)
            {
              if (CalcList1.Count > 0)
              {
                List<List<string>> CalcList2 = new List<List<string>>();
                buString.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", true, CalcList1[0], ref CalcList2);
                if (CalcList2.Count == profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[0].Clampers.Count)
                {
                  for (int index1 = 0; index1 <= CalcList1.Count - 1; ++index1)
                  {
                    List<List<string>> CalcList3 = new List<List<string>>();
                    buString.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", true, CalcList1[index1], ref CalcList3);
                    List<buEyeBaseVer5.Apps.ProfileClamper> profileClamperList1 = new List<buEyeBaseVer5.Apps.ProfileClamper>();
                    if (CalcList3.Count == profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[index1].Clampers.Count)
                    {
                      List<buEyeBaseVer5.Apps.ProfileClamper> profileClamperList2 = new List<buEyeBaseVer5.Apps.ProfileClamper>();
                      profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[index1].Clampers.Clear();
                      profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[index1].Clampers = new List<buEyeBaseVer5.Apps.ProfileClamper>();
                      for (int index2 = 0; index2 <= CalcList3.Count - 1; ++index2)
                      {
                        ArrayList AL = new ArrayList();
                        AL.AddRange((ICollection) CalcList3[index2].ToArray());
                        buEyeBaseVer5.Apps.ProfileClamper profileClamper = new buEyeBaseVer5.Apps.ProfileClamper();
                        buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, (object) profileClamper);
                        profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[index1].Clampers.Add(profileClamper);
                      }
                    }
                  }
                  ProfileTempVars.ClamperMoved = true;
                  clsInit.appProfile.ClamperUpdate(true);
                  clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
                }
                else
                  buString5.MessageBoxWarning(buProfile.LangProfileMessage[32 /*0x20*/]);
              }
              else
                buString5.MessageBoxWarning(buProfile.LangProfileMessage[34]);
            }
            else
              buString5.MessageBoxWarning(buProfile.LangProfileMessage[32 /*0x20*/]);
            clsVar.varInterface.pathMisc = buFile.GetPath(openFileDialog.FileName);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
        }
      }
      if (control2.Name == this.button_15.Name & !clsInit.appProfile.timSim.Enabled)
      {
        try
        {
          if (clsVar.appModes_0.DemoMode)
          {
            int num = (int) MessageBox.Show("Not Available in Demo Mode");
            return;
          }
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = clsVar.varInterface.pathMisc;
          saveFileDialog.Filter = "Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
          saveFileDialog.FilterIndex = 1;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            if (buProfileCalc.varProfileRunSettings.activeOPIndex >= 0 & buProfileCalc.varProfileRunSettings.activeOPIndex <= profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count - 1)
            {
              ArrayList StringList = new ArrayList();
              for (int index3 = 0; index3 <= profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations.Count - 1; ++index3)
              {
                StringList.Add((object) "<ClamperOP>");
                for (int index4 = 0; index4 <= profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[index3].Clampers.Count - 1; ++index4)
                  StringList.AddRange((ICollection) profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[index3].Clampers[index4].ToDefAll("", 2, SerilizationMode5.MultiLine));
                StringList.Add((object) "</ClamperOP>");
              }
              buFile.SaveToFile(StringList, saveFileDialog.FileName);
              clsVar.varInterface.pathMisc = buFile.GetPath(saveFileDialog.FileName);
            }
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
        }
      }
      if (control2.Name == this.button_1.Name & !clsInit.appProfile.timSim.Enabled)
      {
        clsInit.appProfile.ClamperMoveBwdFwd(-(double) this.numericUpDown_0.Value);
        ProfileTempVars.ClamperMoved = true;
      }
      if (control2.Name == this.button_0.Name & !clsInit.appProfile.timSim.Enabled)
      {
        clsInit.appProfile.ClamperMoveBwdFwd((double) this.numericUpDown_0.Value);
        ProfileTempVars.ClamperMoved = true;
      }
      if (control2.Name == this.button_13.Name & !clsInit.appProfile.timSim.Enabled)
      {
        clsInit.appProfile.ClamperEdit();
        ProfileTempVars.ClamperMoved = true;
        this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
      }
      if (control2.Name == this.button_16.Name & !clsInit.appProfile.timSim.Enabled && buString5.MessageBoxQuestion(buLangTranslate.preSentencesProfile.DoYouWantToCopyOpClampPosRestOpClampPos) == DialogResult.Yes)
      {
        clsInit.appProfile.ClamperCopy();
        ProfileTempVars.ClamperMoved = true;
      }
      if (control2.Name == this.button_19.Name & !clsInit.appProfile.timSim.Enabled && buString5.MessageBoxQuestion(buLangTranslate.preSentencesProfile.DoYouWantToCreateNewFixturePositions) == DialogResult.Yes)
      {
        clsInit.appProfile.ClamperNewSetPosition();
        ProfileTempVars.ClamperMoved = true;
        this.numericUpDown_1.Value = (Decimal) profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].ClamperLists.Count;
        this.OperationTreeFill();
        this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
      }
      if (control2.Name == this.button_20.Name & !clsInit.appProfile.timSim.Enabled && profileItem != null & buProfileCalc.varProfileRunSettings.activeOPIndex >= 0 & buProfileCalc.varProfileRunSettings.activeCalcDataIndex >= 0)
      {
        GProfileOperation calcOperation = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
        if (calcOperation.ClamperIndex > 0)
        {
          ProfileItemCalc profileItemCalc = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
          int index = calcOperation.ClamperIndex - 1;
          if (index <= profileItemCalc.ClamperLists.Count - 1)
          {
            calcOperation.ClamperIndex = index;
            calcOperation.Clampers.Clear();
            buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.ClamperLists[index], ref calcOperation.Clampers);
            clsInit.appProfile.UpdateOperationFromNewClamperSet(buProfileCalc.varProfileRunSettings.activeOPIndex, calcOperation.ClamperIndex, ref calcOperation, ref profileItemCalc.calcOperations);
            this.OperationTreeFill();
            ProfileTempVars.DontMoveClamperForPark = true;
            clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
            ProfileTempVars.DontMoveClamperForPark = false;
            Class5.smethod_71(this);
            this.numericUpDown_1.Value = (Decimal) (calcOperation.ClamperIndex + 1);
            profileItem.isGCodeCreated = false;
            clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true);
            this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
          }
        }
      }
      if (control2.Name == this.button_21.Name & !clsInit.appProfile.timSim.Enabled && profileItem != null & buProfileCalc.varProfileRunSettings.activeOPIndex >= 0 & buProfileCalc.varProfileRunSettings.activeCalcDataIndex >= 0)
      {
        ProfileItemCalc profileItemCalc = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
        GProfileOperation calcOperation = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
        if (calcOperation.ClamperIndex < profileItemCalc.ClamperLists.Count - 1)
        {
          int index = calcOperation.ClamperIndex + 1;
          if (index <= profileItemCalc.ClamperLists.Count - 1)
          {
            calcOperation.ClamperIndex = index;
            calcOperation.Clampers.Clear();
            buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.ClamperLists[index], ref calcOperation.Clampers);
            clsInit.appProfile.UpdateOperationFromNewClamperSet(buProfileCalc.varProfileRunSettings.activeOPIndex, calcOperation.ClamperIndex, ref calcOperation, ref profileItemCalc.calcOperations);
            this.OperationTreeFill();
            ProfileTempVars.DontMoveClamperForPark = true;
            clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
            ProfileTempVars.DontMoveClamperForPark = false;
            Class5.smethod_71(this);
            this.numericUpDown_1.Value = (Decimal) (calcOperation.ClamperIndex + 1);
            profileItem.isGCodeCreated = false;
            clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true);
            this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
          }
        }
      }
      if (control2.Name == this.button_12.Name)
        clsInit.appProfile.viewportSimilasyon.ActionMode = actionType.None;
      if (control2.Name == this.button_5.Name)
        buEyeShotFunctions.ViewZoomIn(ref clsInit.appProfile.viewportSimilasyon);
      if (control2.Name == this.button_2.Name)
        buEyeShotFunctions.ViewZoomNormal(ref clsInit.appProfile.viewportSimilasyon);
      if (control2.Name == this.button_4.Name)
        buEyeShotFunctions.ViewZoomOut(ref clsInit.appProfile.viewportSimilasyon);
      if (control2.Name == this.button_3.Name)
        buEyeShotFunctions.ViewZoomWindow(ref clsInit.appProfile.viewportSimilasyon);
      if (control2.Name == this.button_11.Name)
      {
        clsInit.appProfile.planeActive = Plane.XY;
        buEyeShotFunctions.ViewTop(ref clsInit.appProfile.viewportSimilasyon, true);
      }
      if (control2.Name == this.button_10.Name)
      {
        clsInit.appProfile.planeActive = Plane.XZ;
        buEyeShotFunctions.Viewfront(ref clsInit.appProfile.viewportSimilasyon, true);
      }
      if (control2.Name == this.button_18.Name)
      {
        clsInit.appProfile.planeActive = Plane.XZ;
        buEyeShotFunctions.ViewBack(ref clsInit.appProfile.viewportSimilasyon, true);
      }
      if (control2.Name == this.button_9.Name)
      {
        clsInit.appProfile.planeActive = Plane.YZ;
        buEyeShotFunctions.ViewRight(ref clsInit.appProfile.viewportSimilasyon, true);
      }
      if (control2.Name == this.button_17.Name)
      {
        clsInit.appProfile.planeActive = Plane.YZ;
        buEyeShotFunctions.ViewLeft(ref clsInit.appProfile.viewportSimilasyon, true);
      }
      if (control2.Name == this.button_8.Name)
      {
        clsInit.appProfile.planeActive = Plane.XY;
        clsInit.appProfile.viewportSimilasyon.SetView(viewType.vcFrontFaceTopLeft);
        clsInit.appProfile.viewportSimilasyon.Invalidate();
      }
      if (control2.Name == this.button_7.Name)
        buEyeShotFunctions.ViewRotate(ref clsInit.appProfile.viewportSimilasyon);
      if (!(control2.Name == this.button_6.Name))
        return;
      buEyeShotFunctions.ViewPan(ref clsInit.appProfile.viewportSimilasyon);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  internal void method_5(object sender, TreeViewEventArgs e)
  {
    if (!(this.Properties.Inited & !this.bool_4))
      return;
    if (e.Node != null)
    {
      TreeViewNodeSettings viewNodeSettings = new TreeViewNodeSettings();
      TreeViewNodeSettings node = (TreeViewNodeSettings) e.Node;
      this.int_0 = node.ClassSubSubIndex;
      int classIndex = node.ClassIndex;
      int classSubIndex = node.ClassSubIndex;
      buEyeBaseVer5.Apps.ProfileItem profileItem = (buEyeBaseVer5.Apps.ProfileItem) null;
      if (this.int_0 == 0)
        profileItem = clsInit.appProfile.activeProfile.FirstItem;
      if (this.int_0 == 1)
        profileItem = clsInit.appProfile.activeProfile.SecondItem;
      if (profileItem == null)
        return;
      buProfileCalc.varProfileRunSettings.activeProfileIndex = this.int_0;
      if (classSubIndex == -1)
      {
        for (int index = 0; index <= clsInit.appProfile.viewportSimilasyon.Entities.Count - 1; ++index)
          clsInit.appProfile.viewportSimilasyon.Entities[index].Selected = false;
        this.selectedOP = (GProfileOperation) null;
        clsInit.appProfile.viewportSimilasyon.Invalidate();
        clsInit.appProfile.DrawGhostClamp((GProfileOperation) null, this.selectedCalcItem);
      }
      this.selectedCalcItem = (ProfileItemCalc) null;
      if (classSubIndex >= 0 & classIndex >= 0)
      {
        this.selectedCalcItem = profileItem.CalculationData[classIndex];
        if (classSubIndex >= 0 & classSubIndex <= profileItem.CalculationData[classIndex].calcOperations.Count - 1)
        {
          buProfileCalc.varProfileRunSettings.activeOPIndex = classSubIndex;
          buProfileCalc.varProfileRunSettings.activeCalcDataIndex = classIndex;
          this.selectedOP = profileItem.CalculationData[classIndex].calcOperations[classSubIndex];
          clsInit.appProfile.SimOperationBaseIndex = buProfileCalc.varProfileRunSettings.activeOPIndex;
          this.numericUpDown_1.Value = (Decimal) (profileItem.CalculationData[classIndex].calcOperations[classSubIndex].ClamperIndex + 1);
          clsInit.appProfile.ClamperUpdate(true);
          double RotateFirstProfile = 0.0;
          double ProfileXOffset = 0.0;
          if (profileItem.CalculationData[classIndex].CalcType == ProfileExcType.NormalBottom)
            RotateFirstProfile = 180.0;
          if (profileItem.CalculationData[classIndex].CalcType == ProfileExcType.LongSecondPart)
            ProfileXOffset = -profileItem.CalculationData[classIndex].Length;
          ProfileTempVars.DontMoveClamperForPark = false;
          clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, classSubIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>(), ProfileXOffset, RotateFirstProfile);
          ProfileTempVars.DontMoveClamperForPark = false;
          this.textBox_0.Text = clsInit.appProfile.GetOperationInfo(profileItem.CalculationData[classIndex].calcOperations[classSubIndex]);
          this.OperationSelect(classSubIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, profileItem.CalculationData[classIndex].calcOperations[classSubIndex]);
        }
      }
    }
    Class5.smethod_71(this);
  }

  internal void method_6(object sender, TreeViewEventArgs e)
  {
    TreeViewNodeSettings node = (TreeViewNodeSettings) e.Node;
    if (this.bool_3 || node == null)
      return;
    bool flag = node.Checked;
    switch (node.Command)
    {
      case "profileitem":
        if (node.ClassIndex >= 0)
          break;
        break;
      case "profileop":
        if (node.ClassSubSubIndex == 0 && clsInit.appProfile.activeProfile.FirstItem != null)
        {
          ProfileItemCalc profileItemCalc = clsInit.appProfile.activeProfile.FirstItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
          if (node.ClassSubIndex >= 0 & node.ClassSubIndex <= profileItemCalc.calcOperations.Count - 1)
            profileItemCalc.calcOperations[node.ClassSubIndex].Selected = flag;
        }
        if (node.ClassSubSubIndex != 1 || clsInit.appProfile.activeProfile.SecondItem == null)
          break;
        ProfileItemCalc profileItemCalc1 = clsInit.appProfile.activeProfile.SecondItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
        if (!(node.ClassSubIndex >= 0 & node.ClassSubIndex <= profileItemCalc1.calcOperations.Count - 1))
          break;
        profileItemCalc1.calcOperations[node.ClassSubIndex].Selected = flag;
        break;
    }
  }

  internal void method_7(object sender, EventArgs e)
  {
    if (!this.Properties.Inited)
      return;
    buProfileCalc.varProfileRunSettings.SimStep = (int) this.numericUpDown_2.Value;
  }

  internal void method_8(object object_0, double double_0)
  {
    if (clsInit.appProfile.ClamperUpdating)
      return;
    buEyeBaseVer5.Apps.ProfileItem profileItem = (buEyeBaseVer5.Apps.ProfileItem) null;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
      profileItem = clsInit.appProfile.activeProfile.FirstItem;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
      profileItem = clsInit.appProfile.activeProfile.SecondItem;
    if (profileItem == null || clsInit.appProfile.SelectedClamperIndex < 0)
      return;
    ProfileItemCalc profileItemCalc = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
    clsInit.appProfile.ClampersOldPosBeforeMove.Clear();
    buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Clampers, ref clsInit.appProfile.ClampersOldPosBeforeMove);
    profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Clampers[clsInit.appProfile.SelectedClamperIndex].XPosition = double_0;
    clsInit.appProfile.ClamperSetUpdate(profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].ClamperIndex, profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Clampers);
    clsInit.appProfile.ClamperUpdate(true);
    clsInit.appProfile.BasicCollsionControl(ref profileItem);
    clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
    ProfileTempVars.ClamperMoved = true;
  }

  internal void method_9(object sender, MouseEventArgs e) => this.bool_0 = true;

  internal void method_10(object sender, MouseEventArgs e)
  {
    if (!(this.bool_0 & this.bool_1))
      return;
    this.bool_0 = false;
    this.bool_1 = false;
    buEyeBaseVer5.Apps.ProfileItem profileItem = (buEyeBaseVer5.Apps.ProfileItem) null;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
      profileItem = clsInit.appProfile.activeProfile.FirstItem;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
      profileItem = clsInit.appProfile.activeProfile.SecondItem;
    if (profileItem == null)
      return;
    clsInit.appProfile.BasicCollsionControl(ref profileItem);
    clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true);
  }

  internal void method_11(object sender, EventArgs e)
  {
    Control control = sender as Control;
    if (control.Name == this.checkBox_0.Name)
    {
      buProfileCalc.varProfileRunSettings.SelectModeSim = this.checkBox_0.Checked;
      this.treeView_0.CheckBoxes = buProfileCalc.varProfileRunSettings.SelectModeSim;
      if (this.treeView_0.Nodes != null)
      {
        if (this.treeView_0.Nodes.Count >= 1)
          this.treeView_0.Nodes[0].Expand();
        if (this.treeView_0.Nodes.Count >= 2)
          this.treeView_0.Nodes[1].Expand();
      }
      if (!buProfileCalc.varProfileRunSettings.SelectModeSim)
      {
        if (clsInit.appProfile.activeProfile.FirstItem != null)
        {
          for (int index1 = 0; index1 <= clsInit.appProfile.activeProfile.FirstItem.CalculationData.Count - 1; ++index1)
          {
            for (int index2 = 0; index2 <= clsInit.appProfile.activeProfile.FirstItem.CalculationData[index1].calcOperations.Count - 1; ++index2)
              clsInit.appProfile.activeProfile.FirstItem.CalculationData[index1].calcOperations[index2].Selected = false;
          }
        }
        if (clsInit.appProfile.activeProfile.SecondItem != null)
        {
          for (int index3 = 0; index3 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData.Count - 1; ++index3)
          {
            for (int index4 = 0; index4 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData[index3].calcOperations.Count - 1; ++index4)
              clsInit.appProfile.activeProfile.SecondItem.CalculationData[index3].calcOperations[index4].Selected = false;
          }
        }
      }
    }
    if (control.Name == this.chk_ghostright.Name)
    {
      clsInit.appProfile.DrawGhostClamp(this.selectedOP, this.selectedCalcItem);
      clsInit.appProfile.viewportSimilasyon.Invalidate();
    }
    if (!(control.Name == this.chk_hideclapers.Name | control.Name == this.chk__hidemachine.Name | control.Name == this.chk__hidecam.Name | control.Name == this.chk__hidecontours.Name | control.Name == this.chk__hideoperation.Name | control.Name == this.chk__hideprofiles.Name | control.Name == this.chk__hidesupports.Name | control.Name == this.chk__hidemachinbody.Name) || !this.Properties.Inited)
      return;
    buProfileCalc.varProfileRunSettings.HideClampers = this.chk_hideclapers.Checked;
    buProfileCalc.varProfileRunSettings.HideMachine = this.chk__hidemachine.Checked;
    buProfileCalc.varProfileRunSettings.HideMachineBody = this.chk__hidemachinbody.Checked;
    buProfileCalc.varProfileRunSettings.HideCam = this.chk__hidecam.Checked;
    buProfileCalc.varProfileRunSettings.HideContour = this.chk__hidecontours.Checked;
    buProfileCalc.varProfileRunSettings.HideOperations = this.chk__hideoperation.Checked;
    buProfileCalc.varProfileRunSettings.HideProfile = this.chk__hideprofiles.Checked;
    buProfileCalc.varProfileRunSettings.HideSupport = this.chk__hidesupports.Checked;
    clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
  }

  internal void method_12(object sender, EventArgs e)
  {
    string str = "";
    switch (sender)
    {
      case Control _:
        str = (sender as Control).Name;
        break;
      case ToolStripMenuItem _:
        str = (sender as ToolStripMenuItem).Name;
        break;
    }
    buEyeBaseVer5.Apps.ProfileItem profileItem = (buEyeBaseVer5.Apps.ProfileItem) null;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
    {
      profileItem = clsInit.appProfile.activeProfile.FirstItem;
      if (profileItem == null & clsInit.appProfile.activeProfile.SecondItem != null)
        buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
      if ((profileItem == null ? 0 : (!profileItem.Enable ? 1 : 0)) != 0)
        buProfileCalc.varProfileRunSettings.activeProfileIndex = 1;
    }
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
      profileItem = clsInit.appProfile.activeProfile.SecondItem;
    if (profileItem == null)
      return;
    if (str == this.mnu_setclamper.Name)
    {
      F_ProfileClamperSet profileClamperSet = new F_ProfileClamperSet();
      profileClamperSet.spn_priority.Maximum = (Decimal) profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].ClamperLists.Count;
      profileClamperSet.ClamperSet = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].ClamperIndex + 1;
      profileClamperSet.Init();
      int num1 = (int) profileClamperSet.ShowDialog((IWin32Window) this);
      if (profileClamperSet.Properties.Result == DialogResult.OK)
      {
        int index1 = profileClamperSet.ClamperSet - 1;
        ProfileItemCalc profileItemCalc = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
        if (!this.checkBox_0.Checked)
        {
          GProfileOperation calcOperation = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
          calcOperation.Clampers.Clear();
          calcOperation.ClamperIndex = index1;
          buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.ClamperLists[index1], ref calcOperation.Clampers);
          clsInit.appProfile.UpdateOperationFromNewClamperSet(buProfileCalc.varProfileRunSettings.activeOPIndex, calcOperation.ClamperIndex, ref calcOperation, ref profileItemCalc.calcOperations);
          this.OperationTreeFill();
          ProfileTempVars.DontMoveClamperForPark = true;
          clsInit.appProfile.BasicCollsionControl(ref clsInit.appProfile.activeProfile.FirstItem);
          clsInit.appProfile.BasicCollsionControl(ref clsInit.appProfile.activeProfile.SecondItem);
          clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
          ProfileTempVars.DontMoveClamperForPark = false;
          Class5.smethod_71(this);
          this.numericUpDown_1.Value = (Decimal) (calcOperation.ClamperIndex + 1);
          profileItem.isGCodeCreated = false;
          clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true);
          this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
        }
        else
        {
          List<GProfileOperation> gprofileOperationList = new List<GProfileOperation>();
          for (int index2 = profileItemCalc.calcOperations.Count - 1; index2 >= 0; --index2)
          {
            if (profileItemCalc.calcOperations[index2].Selected)
            {
              GProfileOperation calcOperation = profileItemCalc.calcOperations[index2];
              calcOperation.Clampers.Clear();
              calcOperation.ClamperIndex = index1;
              buEyeBaseVer5.Apps.ProfileClamper.Copy(profileItemCalc.ClamperLists[index1], ref calcOperation.Clampers);
              calcOperation.Selected = false;
              gprofileOperationList.Add(calcOperation);
              profileItemCalc.calcOperations.RemoveAt(index2);
            }
          }
          if (gprofileOperationList.Count > 0)
          {
            gprofileOperationList.Reverse();
            int num2 = -1;
            for (int index3 = 0; index3 <= profileItemCalc.calcOperations.Count - 1; ++index3)
            {
              if (profileItemCalc.calcOperations[index3].ClamperIndex > index1)
              {
                num2 = index3;
                index3 = profileItemCalc.calcOperations.Count;
              }
            }
            if (num2 >= 0)
            {
              for (int index4 = 0; index4 <= gprofileOperationList.Count - 1; ++index4)
                profileItemCalc.calcOperations.Insert(num2 + index4, gprofileOperationList[index4]);
            }
            else
            {
              for (int index5 = 0; index5 <= gprofileOperationList.Count - 1; ++index5)
                profileItemCalc.calcOperations.Add(gprofileOperationList[index5]);
              gprofileOperationList.Clear();
            }
            this.OperationTreeFill();
            ProfileTempVars.DontMoveClamperForPark = true;
            clsInit.appProfile.BasicCollsionControl(ref clsInit.appProfile.activeProfile.FirstItem);
            clsInit.appProfile.BasicCollsionControl(ref clsInit.appProfile.activeProfile.SecondItem);
            clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
            ProfileTempVars.DontMoveClamperForPark = false;
            Class5.smethod_71(this);
            this.numericUpDown_1.Value = (Decimal) profileClamperSet.ClamperSet;
            profileItem.isGCodeCreated = false;
            clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true);
            this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
          }
        }
      }
    }
    if (str == this.mnu_enable.Name | str == this.mnu_disable.Name)
    {
      bool flag = true;
      if (str == this.mnu_disable.Name)
        flag = false;
      ProfileItemCalc profileItemCalc = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
      if (!this.checkBox_0.Checked)
      {
        profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Enable = flag;
        this.OperationTreeFill();
        ProfileTempVars.DontMoveClamperForPark = true;
        clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
        ProfileTempVars.DontMoveClamperForPark = false;
        Class5.smethod_71(this);
        profileItem.isGCodeCreated = false;
        clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true);
        this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
      }
      else
      {
        for (int index = 0; index <= profileItemCalc.calcOperations.Count - 1; ++index)
        {
          if (profileItemCalc.calcOperations[index].Selected)
            profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex].calcOperations[index].Enable = flag;
        }
        this.OperationTreeFill();
        ProfileTempVars.DontMoveClamperForPark = true;
        clsInit.appProfile.DrawSimulationEntities(clsInit.appProfile.activeProfile.FirstItem, clsInit.appProfile.activeProfile.SecondItem, buProfileCalc.varProfileRunSettings.activeOPIndex, new List<buEyeBaseVer5.Apps.ProfileClamper>());
        ProfileTempVars.DontMoveClamperForPark = false;
        Class5.smethod_71(this);
        profileItem.isGCodeCreated = false;
        clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true);
        this.OperationSelect(buProfileCalc.varProfileRunSettings.activeOPIndex, buProfileCalc.varProfileRunSettings.activeCalcDataIndex, this.selectedOP);
      }
    }
    if (str == clsItem.FrmProfileJob.mnu_selectall.Name && clsInit.appProfile.activeProfile != null)
    {
      if (!this.checkBox_0.Checked)
        this.checkBox_0.Checked = true;
      if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
      {
        this.bool_3 = true;
        for (int index6 = 0; index6 <= clsInit.appProfile.activeProfile.FirstItem.CalculationData.Count - 1; ++index6)
        {
          for (int index7 = 0; index7 <= clsInit.appProfile.activeProfile.FirstItem.CalculationData[index6].calcOperations.Count - 1; ++index7)
            clsInit.appProfile.activeProfile.FirstItem.CalculationData[index6].calcOperations[index7].Selected = true;
        }
        if ((this.treeView_0.Nodes == null ? 0 : (this.treeView_0.Nodes.Count >= 1 ? 1 : 0)) != 0)
        {
          for (int index = 0; index <= this.treeView_0.Nodes[0].Nodes.Count - 1; ++index)
            this.treeView_0.Nodes[0].Nodes[index].Checked = true;
        }
        this.bool_3 = false;
      }
      if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
      {
        this.bool_3 = true;
        for (int index8 = 0; index8 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData.Count - 1; ++index8)
        {
          for (int index9 = 0; index9 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData[index8].calcOperations.Count - 1; ++index9)
            clsInit.appProfile.activeProfile.SecondItem.CalculationData[index8].calcOperations[index9].Selected = true;
        }
        if ((this.treeView_0.Nodes == null ? 0 : (this.treeView_0.Nodes.Count >= 2 ? 1 : 0)) != 0)
        {
          for (int index = 0; index <= this.treeView_0.Nodes[0].Nodes.Count - 1; ++index)
            this.treeView_0.Nodes[1].Nodes[index].Checked = true;
        }
        this.bool_3 = false;
      }
    }
    if (str == clsItem.FrmProfileJob.mnu_unselectall.Name)
    {
      if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
      {
        this.bool_3 = true;
        for (int index10 = 0; index10 <= clsInit.appProfile.activeProfile.FirstItem.CalculationData.Count - 1; ++index10)
        {
          for (int index11 = 0; index11 <= clsInit.appProfile.activeProfile.FirstItem.CalculationData[index10].calcOperations.Count - 1; ++index11)
            clsInit.appProfile.activeProfile.FirstItem.CalculationData[index10].calcOperations[index11].Selected = false;
        }
        if ((this.treeView_0.Nodes == null ? 0 : (this.treeView_0.Nodes.Count >= 1 ? 1 : 0)) != 0)
        {
          for (int index = 0; index <= this.treeView_0.Nodes[0].Nodes.Count - 1; ++index)
            this.treeView_0.Nodes[0].Nodes[index].Checked = false;
        }
        this.bool_3 = false;
      }
      if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
      {
        this.bool_3 = true;
        for (int index12 = 0; index12 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData.Count - 1; ++index12)
        {
          for (int index13 = 0; index13 <= clsInit.appProfile.activeProfile.SecondItem.CalculationData[index12].calcOperations.Count - 1; ++index13)
            clsInit.appProfile.activeProfile.SecondItem.CalculationData[index12].calcOperations[index13].Selected = false;
        }
        if ((this.treeView_0.Nodes == null ? 0 : (this.treeView_0.Nodes.Count >= 2 ? 1 : 0)) != 0)
        {
          for (int index = 0; index <= this.treeView_0.Nodes[0].Nodes.Count - 1; ++index)
            this.treeView_0.Nodes[1].Nodes[index].Checked = false;
        }
        this.bool_3 = false;
      }
    }
    if (str == this.mnu_up.Name | str == this.mnu_down.Name)
    {
      bool flag = false;
      ProfileItemCalc profileItemCalc = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
      if (str == this.mnu_up.Name && buProfileCalc.varProfileRunSettings.activeOPIndex > 0)
      {
        GProfileOperation calcOperation = profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
        profileItemCalc.calcOperations.RemoveAt(buProfileCalc.varProfileRunSettings.activeOPIndex);
        profileItemCalc.calcOperations.Insert(buProfileCalc.varProfileRunSettings.activeOPIndex - 1, calcOperation);
        clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true, true);
        flag = true;
      }
      if (str == this.mnu_down.Name && buProfileCalc.varProfileRunSettings.activeOPIndex < profileItemCalc.calcOperations.Count - 1)
      {
        GProfileOperation calcOperation = profileItemCalc.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex];
        profileItemCalc.calcOperations.RemoveAt(buProfileCalc.varProfileRunSettings.activeOPIndex);
        profileItemCalc.calcOperations.Insert(buProfileCalc.varProfileRunSettings.activeOPIndex + 1, calcOperation);
        clsInit.appProfile.doCalculateAll(ref profileItem, false, true, true, true);
        flag = true;
      }
      if (flag)
        this.OperationTreeFill();
    }
    if (!(str == this.mnu_priorityoperation.Name))
      return;
    ProfileItemCalc profileItemCalc1 = profileItem.CalculationData[buProfileCalc.varProfileRunSettings.activeCalcDataIndex];
    if (!(buProfileCalc.varProfileRunSettings.activeOPIndex >= 0 & buProfileCalc.varProfileRunSettings.activeOPIndex <= profileItemCalc1.calcOperations.Count - 1))
      return;
    F_ProfilePriority fProfilePriority = new F_ProfilePriority();
    fProfilePriority.Priority = profileItemCalc1.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Priority;
    fProfilePriority.Init();
    int num = (int) fProfilePriority.ShowDialog();
    if (fProfilePriority.Properties.Result != DialogResult.OK)
      return;
    profileItemCalc1.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Priority = fProfilePriority.Priority;
    if (!this.checkBox_0.Checked)
    {
      profileItemCalc1.calcOperations[buProfileCalc.varProfileRunSettings.activeOPIndex].Priority = fProfilePriority.Priority;
    }
    else
    {
      for (int index14 = 0; index14 <= profileItemCalc1.calcOperations.Count - 1; ++index14)
      {
        if (profileItemCalc1.calcOperations[index14].Selected)
        {
          profileItemCalc1.calcOperations[index14].Priority = fProfilePriority.Priority;
          for (int index15 = 0; index15 <= profileItem.Operations.Count - 1; ++index15)
          {
            if (profileItem.Operations[index15].ID == profileItemCalc1.calcOperations[index14].ID)
              profileItem.Operations[index15].Priority = fProfilePriority.Priority;
          }
        }
      }
    }
    this.txt_message.Visible = true;
    this.txt_message.Text = buLangTranslate.preSentencesProfile.OperationsChangedReCalculateNeeded;
    this.OperationTreeFill();
  }

  public void SelectClamperGrid(int ClamperIndex)
  {
    if (ClamperIndex < 0)
      return;
    for (int index = 0; index <= this.dgv_clamper.Rows.Count - 1; ++index)
    {
      this.dgv_clamper.Rows[index].Cells[0].Selected = false;
      this.dgv_clamper.Rows[index].Cells[1].Selected = false;
    }
    this.dgv_clamper.Rows[ClamperIndex].Cells[0].Selected = true;
  }

  public void OperationSelect(int indexOP, int indexGroup, GProfileOperation OP)
  {
    clsInit.appProfile.DrawGhostClamp(OP, this.selectedCalcItem);
    for (int index = 0; index <= clsInit.appProfile.viewportSimilasyon.Entities.Count - 1; ++index)
    {
      clsInit.appProfile.viewportSimilasyon.Entities[index].Selected = false;
      if (clsInit.appProfile.viewportSimilasyon.Entities[index].EntityData != null && clsInit.appProfile.viewportSimilasyon.Entities[index].EntityData is CustomData)
      {
        CustomData entityData = clsInit.appProfile.viewportSimilasyon.Entities[index].EntityData as CustomData;
        if (entityData.RefIndex == this.int_0 & entityData.Sequence == indexOP & entityData.GroupIdIndex == indexGroup & entityData.typeDefination == entityTypeDefination.Operation)
          clsInit.appProfile.viewportSimilasyon.Entities[index].Selected = true;
      }
    }
  }

  private void timer_0_Tick(object sender, EventArgs e)
  {
    this.TopMost = false;
    this.timer_0.Enabled = false;
    if (clsInit.appProfile.SelectedClamperIndex == -1)
      clsInit.appProfile.SelectedClamperIndex = 0;
    this.SelectClamperGrid(clsInit.appProfile.SelectedClamperIndex);
    clsInit.appProfile.MovePark();
    buEyeShotFunctions.ZoomFit(ref clsInit.appProfile.viewportSimilasyon);
  }

  public void OperationTreeFill()
  {
    string str1 = "";
    this.TopMost = false;
    buEyeBaseVer5.Apps.ProfileItem profileItem = (buEyeBaseVer5.Apps.ProfileItem) null;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 0)
      profileItem = clsInit.appProfile.activeProfile.FirstItem;
    if (buProfileCalc.varProfileRunSettings.activeProfileIndex == 1)
      profileItem = clsInit.appProfile.activeProfile.SecondItem;
    this.treeView_0.Nodes.Clear();
    TreeViewNodeSettings node1 = (TreeViewNodeSettings) null;
    TreeViewNodeSettings node2 = (TreeViewNodeSettings) null;
    int num;
    if ((clsInit.appProfile.activeProfile.FirstItem == null ? 0 : (clsInit.appProfile.activeProfile.FirstItem.Enable ? 1 : 0)) != 0)
    {
      node1 = new TreeViewNodeSettings();
      node1.Text = $"{buLangTranslate.preDef.Left} {buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Length}: {clsInit.appProfile.activeProfile.FirstItem.Length.ToString("f1")} - {buLangTranslate.preChar.Width}: {clsInit.appProfile.activeProfile.FirstItem.Width.ToString("f1")} - {buLangTranslate.preChar.Height}: {clsInit.appProfile.activeProfile.FirstItem.Height.ToString("f1")}";
      node1.Name = buLangTranslate.preDef.Left;
      node1.ImageIndex = 6;
      node1.SelectedImageIndex = 6;
      node1.ClassSubSubIndex = buProfileCalc.varProfileRunSettings.activeProfileIndex;
      node1.Command = "profileitem";
      buEyeBaseVer5.Apps.ProfileItem firstItem = clsInit.appProfile.activeProfile.FirstItem;
      for (int index1 = 0; index1 <= firstItem.CalculationData.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= firstItem.CalculationData[index1].calcOperations.Count - 1; ++index2)
        {
          num = firstItem.CalculationData[index1].calcOperations[index2].ClamperIndex + 1;
          TreeViewNodeSettings node3 = new TreeViewNodeSettings();
          node3.Command = "profileop";
          string str2 = $"{(index2 + 1).ToString()}- [{buProfileCalc.varProfileSettings.ClamperChar}= {num.ToString()}] - ";
          if (firstItem.CalculationData[index1].calcOperations[index2].Priority > 0)
            str2 = $"{str2}[{buProfileCalc.varProfileSettings.PriorityChar}= {firstItem.CalculationData[index1].calcOperations[index2].Priority.ToString()}] - ";
          string str3 = str2 + buProfileCalc.OperationItemStringV2(firstItem.CalculationData[index1].calcOperations[index2]);
          node3.Text = str3;
          node3.ForeColor = Color.Black;
          node3.Tag = (object) firstItem.CalculationData[index1].calcOperations[index2].Name;
          if (firstItem.CalculationData[index1].calcOperations[index2].Enable)
          {
            node3.ImageIndex = 3;
            node3.SelectedImageIndex = 3;
          }
          else
          {
            node3.ImageIndex = 4;
            node3.SelectedImageIndex = 4;
          }
          node3.ClassIndex = index1;
          node3.ClassSubIndex = index2;
          node3.ClassSubSubIndex = 0;
          string str4 = $"T{firstItem.CalculationData[index1].calcOperations[index2].Tool.Data.No.ToString()} - {firstItem.CalculationData[index1].calcOperations[index2].OperationData.selectedPlaneName.ToString()}";
          node1.Nodes.Add((TreeNode) node3);
        }
      }
    }
    num = 1;
    if ((clsInit.appProfile.activeProfile.SecondItem == null ? 0 : (clsInit.appProfile.activeProfile.SecondItem.Enable ? 1 : 0)) != 0)
    {
      node2 = new TreeViewNodeSettings();
      node2.Text = $"{buLangTranslate.preDef.Right} {buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Length}: {clsInit.appProfile.activeProfile.SecondItem.Length.ToString("f1")} - {buLangTranslate.preChar.Width}: {clsInit.appProfile.activeProfile.SecondItem.Width.ToString("f1")} - {buLangTranslate.preChar.Height}: {clsInit.appProfile.activeProfile.SecondItem.Height.ToString("f1")}";
      node2.Name = buLangTranslate.preDef.Right;
      node2.ImageIndex = 7;
      node2.SelectedImageIndex = 7;
      node2.ClassSubSubIndex = buProfileCalc.varProfileRunSettings.activeProfileIndex;
      node2.Command = "profileitem";
      buEyeBaseVer5.Apps.ProfileItem secondItem = clsInit.appProfile.activeProfile.SecondItem;
      for (int index3 = 0; index3 <= secondItem.CalculationData.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= secondItem.CalculationData[index3].calcOperations.Count - 1; ++index4)
        {
          num = secondItem.CalculationData[index3].calcOperations[index4].ClamperIndex + 1;
          TreeViewNodeSettings node4 = new TreeViewNodeSettings();
          node4.Command = "profileop";
          string str5 = $"{(index4 + 1).ToString()}- [{buProfileCalc.varProfileSettings.ClamperChar}= {num.ToString()}] - ";
          if (secondItem.CalculationData[index3].calcOperations[index4].Priority > 0)
            str5 = $"{str5}[{buProfileCalc.varProfileSettings.PriorityChar}= {secondItem.CalculationData[index3].calcOperations[index4].Priority.ToString()}] - ";
          string str6 = str5 + buProfileCalc.OperationItemStringV2(secondItem.CalculationData[index3].calcOperations[index4]);
          node4.Text = str6;
          node4.ForeColor = Color.Black;
          node4.Tag = (object) secondItem.CalculationData[index3].calcOperations[index4].Name;
          if (secondItem.CalculationData[index3].calcOperations[index4].Enable)
          {
            node4.ImageIndex = 3;
            node4.SelectedImageIndex = 3;
          }
          else
          {
            node4.ImageIndex = 4;
            node4.SelectedImageIndex = 4;
          }
          node4.ClassIndex = index3;
          node4.ClassSubIndex = index4;
          node4.ClassSubSubIndex = 1;
          string str7 = $"T{secondItem.CalculationData[index3].calcOperations[index4].Tool.Data.No.ToString()} - {secondItem.CalculationData[index3].calcOperations[index4].OperationData.selectedPlaneName.ToString()}";
          node2.Nodes.Add((TreeNode) node4);
        }
      }
    }
    string str8 = $"{str1} {buLangTranslate.preDef.Profile}";
    if (node1 != null)
      this.treeView_0.Nodes.Add((TreeNode) node1);
    if (node2 != null)
      this.treeView_0.Nodes.Add((TreeNode) node2);
    this.treeView_0.ExpandAll();
  }

  public void UpdateTreeOperation()
  {
    if ((clsInit.appProfile.activeProfile.FirstItem == null ? 0 : (clsInit.appProfile.activeProfile.FirstItem.Enable ? 1 : 0)) != 0)
    {
      int index1 = 0;
      buEyeBaseVer5.Apps.ProfileItem firstItem = clsInit.appProfile.activeProfile.FirstItem;
      for (int index2 = 0; index2 <= firstItem.CalculationData.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= firstItem.CalculationData[index2].calcOperations.Count - 1; ++index3)
        {
          if (this.treeView_0.Nodes.Count > 0 && index1 <= this.treeView_0.Nodes[0].Nodes.Count - 1)
          {
            TreeViewNodeSettings node = new TreeViewNodeSettings();
            node.Text = buLangTranslate.preSentences.CollisionAvailable;
            node.ForeColor = Color.Red;
            node.Tag = (object) firstItem.CalculationData[index2].calcOperations[index3].Name;
            if (this.treeView_0.Nodes[0].Nodes[index1].Nodes != null)
              this.treeView_0.Nodes[0].Nodes[index1].Nodes.Clear();
            if (firstItem.CalculationData[index2].calcOperations[index3].isCollision)
            {
              this.treeView_0.Nodes[0].Nodes[index1].Nodes.Add((TreeNode) node);
              this.treeView_0.Nodes[0].Nodes[index1].Expand();
            }
          }
          ++index1;
        }
      }
    }
    if ((clsInit.appProfile.activeProfile.SecondItem == null ? 0 : (clsInit.appProfile.activeProfile.SecondItem.Enable ? 1 : 0)) == 0)
      return;
    int index4 = 0;
    buEyeBaseVer5.Apps.ProfileItem secondItem = clsInit.appProfile.activeProfile.SecondItem;
    for (int index5 = 0; index5 <= secondItem.CalculationData.Count - 1; ++index5)
    {
      for (int index6 = 0; index6 <= secondItem.CalculationData[index5].calcOperations.Count - 1; ++index6)
      {
        int index7 = 1;
        if (this.treeView_0.Nodes.Count == 1)
          index7 = 0;
        if (this.treeView_0.Nodes.Count > 0 && index4 <= this.treeView_0.Nodes[index7].Nodes.Count - 1)
        {
          TreeViewNodeSettings node = new TreeViewNodeSettings();
          node.Text = buLangTranslate.preSentencesProfile.NoCollisionControlDone;
          node.ForeColor = Color.Red;
          node.Tag = (object) secondItem.CalculationData[index5].calcOperations[index6].Name;
          if (this.treeView_0.Nodes[index7].Nodes[index4].Nodes != null)
            this.treeView_0.Nodes[index7].Nodes[index4].Nodes.Clear();
          if (secondItem.CalculationData[index5].calcOperations[index6].isCollision)
          {
            this.treeView_0.Nodes[index7].Nodes[index4].Nodes.Add((TreeNode) node);
            this.treeView_0.Nodes[index7].Nodes[index4].Expand();
          }
        }
        ++index4;
      }
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
