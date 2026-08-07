// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_Tool
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_Tool : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public ToolBase5 Tool = new ToolBase5();
  public Design viewportLayout;
  public string pathTool = Application.StartupPath;
  private int int_0 = -1;
  private int int_1 = -1;
  private List<TabPage> list_0 = new List<TabPage>();
  private Timer timer_0 = new Timer();
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal ComboBox comboBox_0;
  internal Label label_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal Panel panel_0;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal Label label_4;
  internal NumericUpDown numericUpDown_3;
  internal Panel panel_1;
  internal TextBox textBox_0;
  internal Label label_5;
  internal TabPage tabPage_1;
  internal Label label_6;
  internal NumericUpDown numericUpDown_4;
  internal NumericUpDown numericUpDown_5;
  internal Label label_7;
  internal Panel panel_2;
  internal Label label_8;
  internal NumericUpDown numericUpDown_6;
  internal Panel panel_3;
  internal Label label_9;
  internal NumericUpDown numericUpDown_7;
  internal Label label_10;
  internal NumericUpDown numericUpDown_8;
  internal Panel panel_4;
  internal NumericUpDown numericUpDown_9;
  internal Label label_11;
  internal Panel panel_5;
  internal TextBox textBox_1;
  internal TextBox textBox_2;
  internal TextBox textBox_3;
  internal TextBox textBox_4;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal CheckBox checkBox_2;
  internal CheckBox checkBox_3;
  internal Label label_12;
  internal Label label_13;
  internal NumericUpDown numericUpDown_10;
  internal ComboBox comboBox_1;
  internal Label label_14;
  internal TabPage tabPage_2;
  internal Panel panel_6;
  internal Panel panel_7;
  internal NumericUpDown numericUpDown_11;
  internal Label label_15;
  internal NumericUpDown numericUpDown_12;
  internal Label label_16;
  internal Panel panel_8;
  internal Label label_17;
  internal NumericUpDown numericUpDown_13;
  internal Label label_18;
  internal NumericUpDown numericUpDown_14;
  internal Panel panel_9;
  internal Label label_19;
  internal NumericUpDown numericUpDown_15;
  internal Label label_20;
  internal NumericUpDown numericUpDown_16;
  internal Label label_21;
  internal Panel panel_10;
  internal CheckBox checkBox_4;
  internal CheckBox checkBox_5;
  internal CheckBox checkBox_6;
  internal Label label_22;
  internal Panel panel_11;
  internal Panel panel_12;
  internal NumericUpDown numericUpDown_17;
  internal Label label_23;
  internal NumericUpDown numericUpDown_18;
  internal Label label_24;
  internal Panel panel_13;
  internal Label label_25;
  internal NumericUpDown numericUpDown_19;
  internal Label label_26;
  internal NumericUpDown numericUpDown_20;
  internal Panel panel_14;
  internal Label label_27;
  internal NumericUpDown numericUpDown_21;
  internal Label label_28;
  internal NumericUpDown numericUpDown_22;
  internal Label label_29;
  internal Panel panel_15;
  internal CheckBox checkBox_7;
  internal CheckBox checkBox_8;
  internal CheckBox checkBox_9;
  internal CheckBox checkBox_10;
  internal CheckBox checkBox_11;
  internal CheckBox checkBox_12;
  internal CheckBox checkBox_13;
  internal CheckBox checkBox_14;
  internal Label label_30;
  internal TabPage tabPage_3;
  internal Label label_31;
  internal TextBox textBox_5;
  internal Label label_32;
  internal Label label_33;
  internal NumericUpDown numericUpDown_23;
  internal Label label_34;
  internal TextBox textBox_6;
  internal Panel panel_16;
  internal CheckBox checkBox_15;
  internal Label label_35;
  internal Button button_0;
  internal Panel panel_17;
  internal CheckBox checkBox_16;
  internal NumericUpDown numericUpDown_24;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal NumericUpDown numericUpDown_25;
  internal Label label_36;
  internal Panel panel_18;
  internal Label label_37;
  internal Label label_38;
  internal CheckBox checkBox_17;
  internal CheckBox checkBox_18;
  internal Label label_39;
  internal Label label_40;
  internal ComboBox comboBox_2;
  internal NumericUpDown numericUpDown_26;
  internal Label label_41;
  internal Label label_42;
  internal NumericUpDown numericUpDown_27;
  internal NumericUpDown numericUpDown_28;
  internal Label label_43;
  internal NumericUpDown numericUpDown_29;
  internal Label label_44;
  internal NumericUpDown numericUpDown_30;
  internal Label label_45;
  internal NumericUpDown numericUpDown_31;
  internal Label label_46;
  internal Label label_47;
  internal NumericUpDown numericUpDown_32;
  internal Label label_48;
  internal NumericUpDown numericUpDown_33;
  internal NumericUpDown numericUpDown_34;
  internal Label label_49;
  internal Label label_50;
  internal NumericUpDown numericUpDown_35;
  internal Label label_51;
  internal NumericUpDown numericUpDown_36;
  internal TabPage tabPage_4;
  internal TabPage tabPage_5;
  internal Label label_52;
  internal NumericUpDown numericUpDown_37;
  internal Label label_53;
  internal RadioButton radioButton_2;
  internal RadioButton radioButton_3;
  internal RadioButton radioButton_4;
  internal Label label_54;
  internal NumericUpDown numericUpDown_38;
  internal Label label_55;
  internal RadioButton radioButton_5;
  internal RadioButton radioButton_6;
  internal NumericUpDown numericUpDown_39;
  internal Label label_56;
  internal Label label_57;
  internal NumericUpDown numericUpDown_40;
  internal Label label_58;
  internal NumericUpDown numericUpDown_41;
  internal Label label_59;
  internal RadioButton radioButton_7;
  internal RadioButton radioButton_8;
  internal RadioButton radioButton_9;
  internal Label label_60;
  internal NumericUpDown numericUpDown_42;
  internal NumericUpDown numericUpDown_43;
  internal Label label_61;
  internal Label label_62;
  internal NumericUpDown numericUpDown_44;
  internal Label label_63;
  internal NumericUpDown numericUpDown_45;
  internal Label label_64;
  internal NumericUpDown numericUpDown_46;
  internal NumericUpDown numericUpDown_47;
  internal Label label_65;
  internal Label label_66;
  internal NumericUpDown numericUpDown_48;
  internal Label label_67;
  internal NumericUpDown numericUpDown_49;
  internal Label label_68;
  internal NumericUpDown numericUpDown_50;
  internal NumericUpDown numericUpDown_51;
  internal Label label_69;
  internal Label label_70;
  internal NumericUpDown numericUpDown_52;
  internal Label label_71;
  internal NumericUpDown numericUpDown_53;
  internal Label label_72;
  internal TextBox textBox_7;
  internal Label label_73;
  internal TextBox textBox_8;
  internal Label label_74;
  internal TextBox textBox_9;
  internal Label label_75;
  internal TextBox textBox_10;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList imageList_0;
  internal NumericUpDown numericUpDown_54;
  internal Label label_76;
  internal Label label_77;
  internal NumericUpDown numericUpDown_55;
  internal Label label_78;
  internal RadioButton radioButton_10;
  internal RadioButton radioButton_11;
  internal RadioButton radioButton_12;
  internal NumericUpDown numericUpDown_56;
  internal Label label_79;
  public Button btn_aggregatesettings;
  internal CheckBox checkBox_19;
  internal Label label_80;
  public Panel pnl_model;
  internal Panel panel_19;
  internal Label label_81;
  internal Label label_82;
  internal Label label_83;
  internal Label label_84;
  internal Label label_85;
  internal Label label_86;
  internal Label label_87;
  internal Label label_88;
  internal Label label_89;
  internal Label label_90;
  internal Label label_91;
  internal Label label_92;
  internal Label label_93;
  internal Label label_94;
  internal Label label_95;
  internal Label label_96;
  internal Label label_97;
  internal Button button_1;
  internal CheckBox checkBox_20;
  internal CheckBox checkBox_21;
  internal CheckBox checkBox_22;
  public DataGridView DGV_Arbor;
  public DataGridView DGV_Holder;
  internal Button button_2;
  internal Panel panel_20;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Button button_7;
  internal Panel panel_21;
  internal Button button_8;
  internal Button button_9;
  internal Button button_10;
  internal Button button_11;
  internal Label label_98;
  internal Label label_99;
  internal CheckBox checkBox_23;
  internal Button button_12;
  internal Label label_100;
  internal NumericUpDown numericUpDown_57;
  internal Label label_101;
  internal TabControl tabControl_1;
  internal TabPage tabPage_6;
  internal TabPage tabPage_7;
  internal TabPage tabPage_8;
  internal TabPage tabPage_9;
  internal TabPage tabPage_10;
  internal TabPage tabPage_11;
  internal TabPage tabPage_12;
  internal TabPage tabPage_13;
  internal TabPage tabPage_14;
  internal TabPage tabPage_15;
  internal TabPage tabPage_16;
  internal TabPage tabPage_17;
  internal ImageList imageList_1;
  internal TabPage tabPage_18;
  internal Label label_102;
  internal NumericUpDown numericUpDown_58;
  internal TabPage tabPage_19;
  internal Label label_103;
  internal NumericUpDown numericUpDown_59;
  internal Button button_13;
  internal Button button_14;
  internal NumericUpDown numericUpDown_60;
  internal Label label_104;
  internal Label label_105;
  internal NumericUpDown numericUpDown_61;
  internal Label label_106;
  internal NumericUpDown numericUpDown_62;

  public F_Tool()
  {
    Class5.smethod_108(this);
    if (this.viewportLayout != null)
      return;
    this.viewportLayout = new Design();
  }

  public void Init()
  {
    this.Properties.Inited = false;
    ArrayList arrayList = new ArrayList();
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    for (int index = 0; index <= this.tabControl_1.TabPages.Count - 1; ++index)
      this.list_0.Add(this.tabControl_1.TabPages[index]);
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.Purpose, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) this.Tool.Purpose), ref this.comboBox_0);
    this.numericUpDown_3.Value = (Decimal) this.Tool.Data.No;
    this.numericUpDown_2.Value = (Decimal) this.Tool.Data.Sector;
    this.numericUpDown_1.Value = (Decimal) this.Tool.Data.HeightOffsetIndex;
    this.numericUpDown_0.Value = (Decimal) this.Tool.Data.Priority;
    this.numericUpDown_61.Value = (Decimal) this.Tool.Data.TappingInfo;
    this.numericUpDown_62.Value = (Decimal) this.Tool.Data.HeadNumber;
    this.textBox_0.Text = this.Tool.Data.Name;
    this.textBox_6.Text = this.Tool.Data.Tag;
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.Geometry.GeometryType, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tool.Geometry.GeometryType), ref this.comboBox_2);
    this.checkBox_19.Checked = this.Tool.Data.isAgregate;
    this.numericUpDown_27.Value = (Decimal) this.Tool.Geometry.Length;
    this.numericUpDown_28.Value = (Decimal) this.Tool.Geometry.CutLength;
    this.checkBox_21.Checked = this.Tool.Geometry.DrawArbor;
    this.checkBox_22.Checked = this.Tool.Geometry.DrawHolder;
    this.checkBox_20.Checked = this.Tool.Geometry.DrawLength;
    this.numericUpDown_26.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_32.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_34.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_33.Value = (Decimal) this.Tool.Geometry.RoundRadius;
    this.numericUpDown_37.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_29.Value = (Decimal) this.Tool.Geometry.Thickness;
    this.numericUpDown_36.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_30.Value = (Decimal) this.Tool.Geometry.TaperAngle;
    this.numericUpDown_56.Value = (Decimal) this.Tool.Geometry.LowerRadius;
    this.numericUpDown_35.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_54.Value = (Decimal) this.Tool.Geometry.LowerRadius;
    this.numericUpDown_55.Value = (Decimal) this.Tool.Geometry.UpperRadius;
    this.numericUpDown_38.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_31.Value = (Decimal) this.Tool.Geometry.OutsideDiameter;
    this.numericUpDown_41.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_39.Value = (Decimal) this.Tool.Geometry.LowerRadius;
    this.numericUpDown_40.Value = (Decimal) this.Tool.Geometry.TaperAngle;
    this.numericUpDown_45.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_43.Value = (Decimal) this.Tool.Geometry.LowerRadius;
    this.numericUpDown_42.Value = (Decimal) this.Tool.Geometry.OutsideDiameter;
    this.numericUpDown_44.Value = (Decimal) this.Tool.Geometry.TaperAngle;
    this.numericUpDown_47.Value = (Decimal) this.Tool.Geometry.LowerRadius;
    this.numericUpDown_46.Value = (Decimal) this.Tool.Geometry.MaxDiameter;
    this.numericUpDown_48.Value = (Decimal) this.Tool.Geometry.ProfileRadius;
    this.numericUpDown_49.Value = (Decimal) this.Tool.Geometry.UpperDiameter;
    this.numericUpDown_50.Value = (Decimal) this.Tool.Geometry.FlatnessDiameter;
    this.numericUpDown_53.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_51.Value = (Decimal) this.Tool.Geometry.LowerRadius;
    this.numericUpDown_52.Value = (Decimal) this.Tool.Geometry.ConvexTipRadius;
    this.numericUpDown_57.Value = (Decimal) this.Tool.Geometry.FromFileAngle;
    this.checkBox_23.Checked = this.Tool.Geometry.FromFileEnable;
    this.label_101.Text = this.Tool.Geometry.FromFileFileName;
    if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.None)
    {
      this.radioButton_9.Checked = true;
      this.radioButton_6.Checked = true;
      this.radioButton_12.Checked = true;
      this.radioButton_4.Checked = true;
    }
    else if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner)
    {
      this.radioButton_8.Checked = true;
      this.radioButton_5.Checked = true;
      this.radioButton_11.Checked = true;
      this.radioButton_3.Checked = true;
    }
    else
    {
      this.radioButton_7.Checked = true;
      this.radioButton_10.Checked = true;
      this.radioButton_2.Checked = true;
    }
    Class5.smethod_178(this);
    ArrayList EnumItems3 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.CamData.SpindleDirection, ref EnumItems3);
    buControlCommands.ComboboxAddItem(EnumItems3, Convert.ToInt32((object) this.Tool.CamData.SpindleDirection), ref this.comboBox_1);
    if (this.Tool.CamData.DepthType == CamDepthType.Constant)
      this.radioButton_1.Checked = true;
    else
      this.radioButton_0.Checked = true;
    this.numericUpDown_25.Value = (Decimal) this.Tool.CamData.DepthConstant;
    this.numericUpDown_24.Value = (Decimal) this.Tool.CamData.DepthSliceCount;
    this.numericUpDown_5.Value = (Decimal) this.Tool.CamData.Cutover;
    this.numericUpDown_6.Value = (Decimal) this.Tool.CamData.OperationHeight;
    this.numericUpDown_7.Value = (Decimal) this.Tool.CamData.FeedSpeed;
    this.numericUpDown_4.Value = (Decimal) this.Tool.CamData.FinishSpeed;
    this.numericUpDown_23.Value = (Decimal) this.Tool.CamData.RetractSpeed;
    this.numericUpDown_8.Value = (Decimal) this.Tool.CamData.PlungeSpeed;
    this.numericUpDown_10.Value = (Decimal) this.Tool.CamData.SpindleSpeed;
    this.numericUpDown_9.Value = (Decimal) this.Tool.CamData.SafeDistance;
    this.numericUpDown_60.Value = (Decimal) this.Tool.CamData.RapidDistance;
    this.checkBox_2.Checked = this.Tool.CamData.Air;
    this.checkBox_0.Checked = this.Tool.CamData.InnerCooling;
    this.checkBox_1.Checked = this.Tool.CamData.Oil;
    this.checkBox_3.Checked = this.Tool.CamData.Water;
    this.checkBox_17.Checked = this.Tool.CamData.FeedFromTool;
    this.checkBox_18.Checked = this.Tool.CamData.DistanceFromTool;
    this.checkBox_16.Checked = this.Tool.CamData.DepthFromTool;
    this.checkBox_15.Checked = this.Tool.CamData.CutOverrideFromTool;
    this.textBox_3.Text = buString.ArrayListToString(this.Tool.CamData.AirText, true);
    this.textBox_4.Text = buString.ArrayListToString(this.Tool.CamData.WaterText, true);
    this.textBox_2.Text = buString.ArrayListToString(this.Tool.CamData.InnerCoolText, true);
    this.textBox_1.Text = buString.ArrayListToString(this.Tool.CamData.OilText, true);
    this.label_93.BackColor = this.Tool.Display.ToolBodySolid.SkinColor;
    this.label_95.BackColor = this.Tool.Display.ToolCutSolid.SkinColor;
    this.label_92.BackColor = this.Tool.Display.HolderSolid.SkinColor;
    this.label_90.BackColor = this.Tool.Display.ArborSolid.SkinColor;
    this.label_88.BackColor = this.Tool.Display.CamColor;
    this.label_86.BackColor = this.Tool.Display.UpperCamColor;
    this.label_84.BackColor = this.Tool.Display.PlungeColor;
    this.label_82.BackColor = this.Tool.Display.LeaveColor;
    this.numericUpDown_19.Value = (Decimal) this.Tool.Limits.AxesMinLimits.A;
    this.numericUpDown_21.Value = (Decimal) this.Tool.Limits.AxesMinLimits.B;
    this.numericUpDown_18.Value = (Decimal) this.Tool.Limits.AxesMinLimits.C;
    this.numericUpDown_20.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.A;
    this.numericUpDown_22.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.B;
    this.numericUpDown_17.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.C;
    this.numericUpDown_13.Value = (Decimal) this.Tool.Limits.AxesMinLimits.X;
    this.numericUpDown_15.Value = (Decimal) this.Tool.Limits.AxesMinLimits.Y;
    this.numericUpDown_12.Value = (Decimal) this.Tool.Limits.AxesMinLimits.Z;
    this.numericUpDown_14.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.X;
    this.numericUpDown_16.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.Y;
    this.numericUpDown_11.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.Z;
    this.checkBox_14.Checked = this.Tool.Limits.PlaneTop;
    this.checkBox_13.Checked = this.Tool.Limits.PlaneBottom;
    this.checkBox_10.Checked = this.Tool.Limits.PlaneFront;
    this.checkBox_9.Checked = this.Tool.Limits.PlaneBack;
    this.checkBox_12.Checked = this.Tool.Limits.PlaneLeft;
    this.checkBox_11.Checked = this.Tool.Limits.PlaneRight;
    this.checkBox_8.Checked = this.Tool.Limits.PlaneAll;
    this.checkBox_7.Checked = this.Tool.Limits.PlaneSlope;
    this.checkBox_6.Checked = this.Tool.Limits.RotationA;
    this.checkBox_5.Checked = this.Tool.Limits.RotationB;
    this.checkBox_4.Checked = this.Tool.Limits.RotationC;
    this.textBox_5.Text = buString.ArrayListToString(this.Tool.Aux, true);
    this.textBox_10.Text = buString.ArrayListToString(this.Tool.ToolPre, true);
    this.textBox_9.Text = buString.ArrayListToString(this.Tool.ToolNext, true);
    this.textBox_8.Text = buString.ArrayListToString(this.Tool.SpindlePre, true);
    this.textBox_7.Text = buString.ArrayListToString(this.Tool.SpindleNext, true);
    this.numericUpDown_61.Visible = false;
    this.label_105.Visible = false;
    if (this.Tool.Purpose == ToolPurpose.Tapping)
    {
      this.numericUpDown_61.Visible = true;
      this.label_105.Visible = true;
    }
    this.DGV_Holder.RowHeadersVisible = false;
    this.DGV_Holder.ColumnHeadersVisible = false;
    this.DGV_Holder.AllowUserToAddRows = false;
    this.DGV_Holder.AllowUserToResizeColumns = false;
    this.DGV_Holder.AllowUserToResizeRows = false;
    DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
    dataGridViewColumn1.Width = 70;
    dataGridViewColumn1.HeaderText = "X";
    dataGridViewColumn1.Name = "X";
    dataGridViewColumn1.ReadOnly = false;
    dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.DGV_Holder.Columns.Add(dataGridViewColumn1);
    DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
    dataGridViewColumn2.Width = 70;
    dataGridViewColumn2.HeaderText = "Y";
    dataGridViewColumn2.Name = "Y";
    dataGridViewColumn2.ReadOnly = false;
    dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.DGV_Holder.Columns.Add(dataGridViewColumn2);
    this.DGV_Arbor.RowHeadersVisible = false;
    this.DGV_Arbor.ColumnHeadersVisible = false;
    this.DGV_Arbor.AllowUserToAddRows = false;
    this.DGV_Arbor.AllowUserToResizeColumns = false;
    this.DGV_Arbor.AllowUserToResizeRows = false;
    DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
    dataGridViewColumn3.Width = 60;
    dataGridViewColumn3.HeaderText = "X";
    dataGridViewColumn3.Name = "X";
    dataGridViewColumn3.ReadOnly = false;
    dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.DGV_Arbor.Columns.Add(dataGridViewColumn3);
    DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
    dataGridViewColumn4.Width = 60;
    dataGridViewColumn4.HeaderText = "Y";
    dataGridViewColumn4.Name = "Y";
    dataGridViewColumn4.ReadOnly = false;
    dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
    dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
    this.DGV_Arbor.Columns.Add(dataGridViewColumn4);
    this.pnl_model.Controls.Add((System.Windows.Forms.Control) this.viewportLayout);
    this.TabPAgeVisibility();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.timer_0.Tick += new EventHandler(this.Init_Tick);
    this.timer_0.Interval = 10;
    this.timer_0.Enabled = true;
  }

  public void Init_Tick(object sender, EventArgs e)
  {
    this.timer_0.Enabled = false;
    this.DrawTool();
    Class5.smethod_57(this);
    Class5.smethod_36(this);
  }

  public void DrawTool()
  {
    List<Mesh> refMeshes = new List<Mesh>();
    this.viewportLayout.Entities.Clear();
    if (!this.Tool.Geometry.FromFileEnable)
    {
      clsInit.appMW.CreateTool(this.Tool, true, this.Tool.Geometry.DrawLength, this.Tool.Geometry.DrawArbor, this.Tool.Geometry.DrawHolder, ref refMeshes);
    }
    else
    {
      FileInfo fileInfo = new FileInfo(this.Tool.Geometry.FromFileFileName);
      if (fileInfo.Exists)
      {
        ReadSTL readStl = new ReadSTL(fileInfo.FullName);
        readStl.DoWork();
        readStl.OpenTo((IDesign) this.viewportLayout);
        if (this.viewportLayout.Entities.Count > 0)
        {
          for (int index = 0; index <= this.viewportLayout.Entities.Count - 1; ++index)
          {
            if (this.viewportLayout.Entities[index] is Mesh)
            {
              this.viewportLayout.Entities[index].ColorMethod = colorMethodType.byEntity;
              if (this.viewportLayout.Entities[index].Color == Color.Black)
                this.viewportLayout.Entities[index].Color = Color.DarkGray;
              this.viewportLayout.Entities[index].Rotate(buConversion5.DegreeToRadian(this.Tool.Geometry.FromFileAngle), new Vector3D(0.0, 0.0, 1.0));
            }
          }
          this.viewportLayout.Entities.Regen();
          this.viewportLayout.ActiveViewport.ViewCubeIcon.Visible = false;
          this.viewportLayout.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
          this.viewportLayout.SetView(viewType.Top, true, false);
          this.viewportLayout.ZoomOut(2);
          this.viewportLayout.Invalidate();
        }
      }
    }
    if (refMeshes.Count <= 0)
      return;
    for (int index = 0; index <= refMeshes.Count - 1; ++index)
    {
      if (refMeshes[index].Vertices.Length != 0)
        this.viewportLayout.Entities.Add((Entity) refMeshes[index]);
    }
    List<Entity> dimEntities = new List<Entity>();
    clsInit.cVector5.ToolDimensionEntities(this.Tool, ref dimEntities);
    for (int index = 0; index <= dimEntities.Count - 1; ++index)
      this.viewportLayout.Entities.Add(dimEntities[index]);
    this.viewportLayout.ActiveViewport.ViewCubeIcon.Visible = false;
    this.viewportLayout.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    this.viewportLayout.SetView(viewType.Front, true, false);
    this.viewportLayout.ZoomOut(2);
    this.viewportLayout.Invalidate();
  }

  public void TabPAgeVisibility()
  {
    this.tabControl_1.TabPages.Clear();
    if (this.Tool.Geometry.GeometryType == ToolType.Flat)
      this.tabControl_1.TabPages.Add(this.list_0[0]);
    if (this.Tool.Geometry.GeometryType == ToolType.Sphere)
      this.tabControl_1.TabPages.Add(this.list_0[1]);
    if (this.Tool.Geometry.GeometryType == ToolType.Saw)
      this.tabControl_1.TabPages.Add(this.list_0[2]);
    if (this.Tool.Geometry.GeometryType == ToolType.Bullnose)
      this.tabControl_1.TabPages.Add(this.list_0[3]);
    if (this.Tool.Geometry.GeometryType == ToolType.Slot)
      this.tabControl_1.TabPages.Add(this.list_0[4]);
    if (this.Tool.Geometry.GeometryType == ToolType.Taper)
      this.tabControl_1.TabPages.Add(this.list_0[5]);
    if (this.Tool.Geometry.GeometryType == ToolType.Lollipop)
      this.tabControl_1.TabPages.Add(this.list_0[6]);
    if (this.Tool.Geometry.GeometryType == ToolType.Dove)
      this.tabControl_1.TabPages.Add(this.list_0[7]);
    if (this.Tool.Geometry.GeometryType == ToolType.Chamfer)
      this.tabControl_1.TabPages.Add(this.list_0[8]);
    if (this.Tool.Geometry.GeometryType == ToolType.Barrel)
      this.tabControl_1.TabPages.Add(this.list_0[9]);
    if (this.Tool.Geometry.GeometryType == ToolType.ConvexTip)
      this.tabControl_1.TabPages.Add(this.list_0[10]);
    if (this.Tool.Geometry.GeometryType == ToolType.FromFile)
      this.tabControl_1.TabPages.Add(this.list_0[11]);
    if (this.Tool.Geometry.GeometryType == ToolType.WateJet)
      this.tabControl_1.TabPages.Add(this.list_0[12]);
    if (this.Tool.Geometry.GeometryType != ToolType.Laser)
      return;
    this.tabControl_1.TabPages.Add(this.list_0[13]);
  }

  internal void method_0(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.btn_ok.Name)
    {
      if (this.numericUpDown_28.Value > this.numericUpDown_27.Value)
        buString5.MessageBoxWarning(AppLanguage.CadCamMessages[98]);
      Class5.smethod_218(this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_14.Name)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = AppPath.ToolHolder;
      saveFileDialog.Filter = "Tool Holder Files (*.butoolholder)|*.butoolholder";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        AppPath.ToolHolder = buFile5.GetPath(saveFileDialog.FileName);
        ToolBase5.SaveToolHolder(this.Tool, saveFileDialog.FileName);
      }
    }
    if (control2.Name == this.button_13.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = AppPath.ToolHolder;
      openFileDialog.Filter = "Tool Holder Files (*.butoolholder)|*.butoolholder";
      openFileDialog.FilterIndex = 1;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        AppPath.ToolHolder = buFile5.GetPath(openFileDialog.FileName);
        ToolBase5.OpenToolHolder(ref this.Tool, openFileDialog.FileName);
        this.DrawTool();
      }
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      this.Visible = false;
    }
    if (control2.Name == this.button_0.Name)
    {
      if (!this.panel_0.Visible)
        this.panel_0.Visible = true;
      else
        this.panel_0.Visible = false;
    }
    if (control2.Name == this.button_2.Name)
    {
      if (!this.panel_20.Visible)
      {
        Class5.smethod_57(this);
        this.panel_20.Visible = true;
      }
      else
        this.panel_20.Visible = false;
    }
    if (control2.Name == this.button_5.Name)
      this.panel_20.Visible = false;
    if (control2.Name == this.button_6.Name)
    {
      this.Tool.Geometry.HolderPoints.Clear();
      for (int index = 0; index <= this.DGV_Holder.Rows.Count - 1; ++index)
      {
        double result1 = 0.0;
        double result2 = 0.0;
        double.TryParse(this.DGV_Holder.Rows[index].Cells[0].Value.ToString(), out result1);
        double.TryParse(this.DGV_Holder.Rows[index].Cells[1].Value.ToString(), out result2);
        this.Tool.Geometry.HolderPoints.Add(new Pnt3D(result1, result2));
      }
      this.DrawTool();
      this.panel_20.Visible = false;
    }
    if (control2.Name == this.button_4.Name)
    {
      if (this.DGV_Holder.Rows.Count - 1 == this.int_0 | this.int_0 == -1)
        this.DGV_Holder.Rows.Add((object) 0, (object) 0);
      else
        this.DGV_Holder.Rows.Insert(this.int_0, (object) 0, (object) 0);
    }
    if (control2.Name == this.button_3.Name && this.int_0 >= 0 & this.int_0 <= this.DGV_Holder.Rows.Count - 1)
    {
      this.DGV_Holder.Rows.RemoveAt(this.int_0);
      --this.int_0;
    }
    if (control2.Name == this.button_7.Name)
    {
      if (!this.panel_21.Visible)
      {
        Class5.smethod_36(this);
        this.panel_21.Visible = true;
      }
      else
        this.panel_21.Visible = false;
    }
    if (control2.Name == this.button_8.Name)
      this.panel_21.Visible = false;
    if (control2.Name == this.button_9.Name)
    {
      this.Tool.Geometry.ArborPoints.Clear();
      for (int index = 0; index <= this.DGV_Arbor.Rows.Count - 1; ++index)
      {
        double result3 = 0.0;
        double result4 = 0.0;
        double.TryParse(this.DGV_Arbor.Rows[index].Cells[0].Value.ToString(), out result3);
        double.TryParse(this.DGV_Arbor.Rows[index].Cells[1].Value.ToString(), out result4);
        this.Tool.Geometry.ArborPoints.Add(new Pnt3D(result3, result4));
      }
      this.DrawTool();
      this.panel_21.Visible = false;
    }
    if (control2.Name == this.button_11.Name)
    {
      if (this.DGV_Arbor.Rows.Count - 1 == this.int_1 | this.int_1 == -1)
        this.DGV_Arbor.Rows.Add((object) 0, (object) 0);
      else
        this.DGV_Arbor.Rows.Insert(this.int_1, (object) 0, (object) 0);
    }
    if (control2.Name == this.button_10.Name && this.int_1 >= 0 & this.int_1 <= this.DGV_Arbor.Rows.Count - 1)
    {
      this.DGV_Arbor.Rows.RemoveAt(this.int_1);
      --this.int_1;
    }
    if (control2.Name == this.button_1.Name)
    {
      if (this.Tool.Geometry.GeometryType == ToolType.Flat)
      {
        this.numericUpDown_27.Value = 40M;
        this.numericUpDown_28.Value = 20M;
        this.numericUpDown_26.Value = 10M;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Sphere)
      {
        this.numericUpDown_27.Value = 40M;
        this.numericUpDown_28.Value = 20M;
        this.numericUpDown_32.Value = 10M;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Bullnose)
      {
        this.numericUpDown_27.Value = 40M;
        this.numericUpDown_28.Value = 20M;
        this.numericUpDown_34.Value = 10M;
        this.numericUpDown_33.Value = 2M;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Lollipop)
      {
        this.numericUpDown_27.Value = 40M;
        this.numericUpDown_28.Value = 10M;
        this.numericUpDown_38.Value = 10M;
        this.numericUpDown_31.Value = 6M;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Slot)
      {
        this.numericUpDown_27.Value = 40M;
        this.numericUpDown_28.Value = 5M;
        this.numericUpDown_35.Value = 80M;
        this.numericUpDown_54.Value = 2M;
        this.numericUpDown_55.Value = 2M;
        this.radioButton_12.Checked = true;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Taper)
      {
        this.numericUpDown_27.Value = 50M;
        this.numericUpDown_28.Value = 28M;
        this.numericUpDown_30.Value = 8M;
        this.numericUpDown_36.Value = 6M;
        this.numericUpDown_56.Value = 0M;
        this.radioButton_4.Checked = true;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Dove)
      {
        this.numericUpDown_27.Value = 40M;
        this.numericUpDown_28.Value = 6M;
        this.numericUpDown_30.Value = 8M;
        this.numericUpDown_41.Value = 20M;
        this.numericUpDown_39.Value = 2M;
        this.numericUpDown_40.Value = 45M;
        this.radioButton_6.Checked = true;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Chamfer)
      {
        this.numericUpDown_27.Value = 50M;
        this.numericUpDown_28.Value = 20M;
        this.numericUpDown_45.Value = 2M;
        this.numericUpDown_43.Value = 0M;
        this.numericUpDown_42.Value = 20M;
        this.numericUpDown_44.Value = 45M;
        this.radioButton_9.Checked = true;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Barrel)
      {
        this.numericUpDown_27.Value = 30M;
        this.numericUpDown_28.Value = 18M;
        this.numericUpDown_47.Value = 0.1M;
        this.numericUpDown_46.Value = 20M;
        this.numericUpDown_48.Value = 12M;
        this.numericUpDown_49.Value = 10M;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.ConvexTip)
      {
        this.numericUpDown_27.Value = 40M;
        this.numericUpDown_28.Value = 20M;
        this.numericUpDown_50.Value = 0M;
        this.numericUpDown_53.Value = 10M;
        this.numericUpDown_51.Value = 1M;
        this.numericUpDown_52.Value = 10M;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Saw)
      {
        this.numericUpDown_27.Value = 40M;
        this.numericUpDown_28.Value = 4M;
        this.numericUpDown_37.Value = 200M;
        this.numericUpDown_29.Value = 2M;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.WateJet)
      {
        this.numericUpDown_27.Value = 30M;
        this.numericUpDown_28.Value = 5M;
        this.numericUpDown_58.Value = 2M;
      }
      else if (this.Tool.Geometry.GeometryType == ToolType.Laser)
      {
        this.checkBox_22.Checked = false;
        this.checkBox_21.Checked = false;
        this.numericUpDown_27.Value = 30M;
        this.numericUpDown_28.Value = 5M;
        this.numericUpDown_59.Value = 2M;
      }
      Class5.smethod_218(this);
      this.DrawTool();
    }
    if (!(control2.Name == this.button_12.Name))
      return;
    OpenFileDialog openFileDialog1 = new OpenFileDialog();
    openFileDialog1.InitialDirectory = this.pathTool;
    openFileDialog1.Multiselect = false;
    openFileDialog1.Filter = "Tool Geometry Stl File (*.stl)|*.stl";
    openFileDialog1.FilterIndex = 1;
    if (openFileDialog1.ShowDialog() != DialogResult.OK)
      return;
    this.pathTool = new FileInfo(openFileDialog1.FileName).DirectoryName;
    this.label_101.Text = openFileDialog1.FileName;
    this.Tool.Geometry.FromFileFileName = openFileDialog1.FileName;
    Class5.smethod_218(this);
    this.DrawTool();
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, KeyEventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    Class5.smethod_218(this);
    this.DrawTool();
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.tabControl_0.SelectedTab.Controls, result, e.Shift);
  }

  internal void method_3(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (sender.GetType() == typeof (TextBox))
      {
        TextBox textBox = new TextBox();
        buControlCommands.ShowKeyPad((Form) this, (System.Windows.Forms.Control) sender);
      }
      if (!(sender.GetType() == typeof (NumericUpDown)))
        return;
      NumericUpDown numericUpDown = new NumericUpDown();
      buControlCommands.ShowKeyPad((Form) this, (System.Windows.Forms.Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_4(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (control2.Name == this.label_95.Name)
    {
      Color backColor = this.label_95.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        this.label_95.BackColor = backColor;
        this.Tool.Display.ToolCutSolid.SkinColor = backColor;
      }
    }
    if (control2.Name == this.label_93.Name)
    {
      Color backColor = this.label_93.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        this.label_93.BackColor = backColor;
        this.Tool.Display.ToolBodySolid.SkinColor = backColor;
      }
    }
    if (control2.Name == this.label_90.Name)
    {
      Color backColor = this.label_90.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        this.label_90.BackColor = backColor;
        this.Tool.Display.ArborSolid.SkinColor = backColor;
      }
    }
    if (control2.Name == this.label_92.Name)
    {
      Color backColor = this.label_92.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        this.label_92.BackColor = backColor;
        this.Tool.Display.HolderSolid.SkinColor = backColor;
      }
    }
    if (control2.Name == this.label_88.Name)
    {
      Color backColor = this.label_88.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        this.label_88.BackColor = backColor;
        this.Tool.Display.CamColor = backColor;
      }
    }
    if (control2.Name == this.label_86.Name)
    {
      Color backColor = this.label_86.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        this.label_86.BackColor = backColor;
        this.Tool.Display.UpperCamColor = backColor;
      }
    }
    if (control2.Name == this.label_84.Name)
    {
      Color backColor = this.label_84.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        this.label_84.BackColor = backColor;
        this.Tool.Display.PlungeColor = backColor;
      }
    }
    if (control2.Name == this.label_82.Name)
    {
      Color backColor = this.label_82.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
      {
        this.label_82.BackColor = backColor;
        this.Tool.Display.LeaveColor = backColor;
      }
    }
    this.DrawTool();
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (!this.Properties.Inited)
      return;
    this.Tool.Geometry.GeometryType = (ToolType) buGeneral.EnumValueFromInt((object) this.Tool.Geometry.GeometryType, this.comboBox_2.SelectedIndex);
    this.Tool.Purpose = (ToolPurpose) buGeneral.EnumValueFromInt((object) this.Tool.Purpose, this.comboBox_0.SelectedIndex);
    this.numericUpDown_61.Visible = false;
    this.label_105.Visible = false;
    if (this.Tool.Purpose == ToolPurpose.Tapping)
    {
      this.numericUpDown_61.Visible = true;
      this.label_105.Visible = true;
    }
    this.TabPAgeVisibility();
    this.method_0((object) this.button_1, (EventArgs) null);
    this.DrawTool();
  }

  internal void method_6(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.radioButton_3.Name | control2.Name == this.radioButton_2.Name | control2.Name == this.radioButton_4.Name)
    {
      if (this.radioButton_4.Checked)
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
      if (this.radioButton_3.Checked)
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
      if (this.radioButton_2.Checked)
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
      Class5.smethod_178(this);
      this.DrawTool();
    }
    if (control2.Name == this.radioButton_11.Name | control2.Name == this.radioButton_10.Name | control2.Name == this.radioButton_12.Name)
    {
      if (this.radioButton_12.Checked)
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
      if (this.radioButton_11.Checked)
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
      if (this.radioButton_10.Checked)
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
      Class5.smethod_178(this);
      this.DrawTool();
    }
    if (control2.Name == this.radioButton_5.Name | control2.Name == this.radioButton_6.Name)
    {
      if (this.radioButton_6.Checked)
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
      if (this.radioButton_5.Checked)
        this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
      Class5.smethod_178(this);
      this.DrawTool();
    }
    if (!(control2.Name == this.radioButton_8.Name | control2.Name == this.radioButton_7.Name | control2.Name == this.radioButton_9.Name))
      return;
    if (this.radioButton_9.Checked)
      this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
    if (this.radioButton_8.Checked)
      this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
    if (this.radioButton_7.Checked)
      this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
    Class5.smethod_178(this);
    this.DrawTool();
  }

  internal void method_7(object sender, EventArgs e)
  {
    Class5.smethod_218(this);
    this.DrawTool();
  }

  internal void method_8(object sender, EventArgs e)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.checkBox_21.Name)
      this.Tool.Geometry.DrawArbor = this.checkBox_21.Checked;
    if (control2.Name == this.checkBox_22.Name)
      this.Tool.Geometry.DrawHolder = this.checkBox_22.Checked;
    if (control2.Name == this.checkBox_20.Name)
      this.Tool.Geometry.DrawLength = this.checkBox_20.Checked;
    this.DrawTool();
  }

  internal void method_9(object sender, DataGridViewCellEventArgs e)
  {
    System.Windows.Forms.Control control = (System.Windows.Forms.Control) sender;
    if (control.Name == this.DGV_Holder.Name)
      this.int_0 = e.RowIndex;
    if (!(control.Name == this.DGV_Arbor.Name))
      return;
    this.int_1 = e.RowIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
